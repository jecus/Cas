using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace CAS.UI
{
    /// <summary>
    /// Класс содержит рутины, которые помогают запустить CAS
    /// </summary>
    internal static class Launcher
    {

        #region public static DirectoryInfo WorkingDirectory
        /// <summary> 
        /// Директория, в которой находится программа CAS
        /// </summary>
        private static DirectoryInfo _workingDirectory;
        /// <summary>
        /// Директория, в которой находится программа CAS
        /// </summary>
        public static DirectoryInfo WorkingDirectory
        {
            get
            {
                if (_workingDirectory == null)
                {
                    FileInfo f = new FileInfo(Application.ExecutablePath);
                    _workingDirectory = f.Directory;
                }
                return _workingDirectory;
            }
        }
        #endregion

        #region public static void Prepare()
        /// <summary>
        /// Подготавливается к запуску
        /// 1.Проверка на запуск второго экземпляра КАС
        /// 2.Проверка на наличие обновлений
        /// </summary>
        public static void Prepare()
        {
            //проверка на запуск второго экземпляра КАС
            CheckOneInstance();
            //проверка на обновления
            CheckUpdates();
            //Удаление временных директорий
            DeleteTempDirectories();
        }
        #endregion

        /*
         * Реализация 
         */                             

        private const bool _Debug = false; 

        #region private static void CheckOneInstance()
        /// <summary>
        /// Проверяем, не запущена ли уже программа CAS
        /// </summary>
        private static void CheckOneInstance()
        {
            //if (Process.GetProcessesByName("CAS").Length >= 2)
            //{
            //    // Если две копии приложения было запущено CasLaucher'ом - то сообщение выдавать не будем, чтобы не пугать пользователя
            //    if (Process.GetProcessesByName("CasLauncher").Length == 0)
            //        MessageBox.Show("Only one instance of CAS is allowed.\nClose the first instance and try again.");

            //    // В любом случа выходим
            //    Environment.Exit(0);
            //}
        }
        #endregion

        #region private static void CheckUpdates()
        /// <summary>
        /// Проверяет наличие обновлений
        /// Хотя это и прерогатива CasLauncher - сейчас оказалось, что сам CasLauncher вместе с двумя связанными библиотеками не обновляется
        /// Поэтому мы должны сами на всякий случай проверить обновления
        /// </summary>
        private static void CheckUpdates()
        {
            // Дожидаемся завершения процессов CasLauncher и Copier
            while (Process.GetProcessesByName("CasLauncher").Length > 0 && Process.GetProcessesByName("Copier").Length > 0)
                Thread.Sleep(100);

            // Получаем временные директории 
            DirectoryInfo[] tempDirs = GetTempDirectories();
            if (tempDirs == null || tempDirs.Length == 0) return;

            // В каждой временной директории смотрим три волшебных файла, которые не обновляются
            foreach (DirectoryInfo tempDir in tempDirs)
            {
                CheckForNewerVersion(new FileInfo(Path.Combine(tempDir.FullName, "CasLauncher.exe")));
                CheckForNewerVersion(new FileInfo(Path.Combine(tempDir.FullName, "CasProtocol.dll")));
                CheckForNewerVersion(new FileInfo(Path.Combine(tempDir.FullName, "CasNetworkObserver.dll")));
            }

            // Далее продолжаем работу программы 
        }
        #endregion

        #region private static void DeleteTempDirectories()
        /// <summary>
        /// Удаляет временные директории, которые были созданы во время обновления
        /// </summary>
        private static void DeleteTempDirectories()
        {
            // Данную процедуру можно сделать в фоне - программа уже может работать 
            // Находим все временные директории (в идеале только одна) и удаляем их
            DirectoryInfo[] tempDirs = GetTempDirectories();
            foreach (DirectoryInfo tempDir in tempDirs)
            {
                try
                {
                    tempDir.Delete(true);
                }
                catch
                {
                }
            }
        }
        #endregion

        #region private static DirectoryInfo[] GetTempDirectories()
        /// <summary>
        /// Возвращает временные директории
        /// </summary>
        /// <returns></returns>
        private static DirectoryInfo[] GetTempDirectories()
        {
            // Временные папки CAS в виде 123456-123456-123456-123456
            DirectoryInfo tempDir = new DirectoryInfo(Path.GetTempPath());
            DirectoryInfo[] casDirs = tempDir.GetDirectories("??????-??????-??????-??????");
            return casDirs;
        }
        #endregion

        #region private static void CheckForNewerVersion(FileInfo UpdateCandidate)
        /// <summary>
        /// Проверяем, возможно перед нами файл с более новой версией
        /// </summary>
        /// <param name="updateCandidate"></param>
        private static void CheckForNewerVersion(FileInfo updateCandidate)
        {
            // Если файла не существует то не проверяем его....
            if (!updateCandidate.Exists) return;

            // Есть ли такой файл в папке с программой CAS ? 
            // Если нет то тоже выходим - он должен был быть скопированным программой Copier
            FileInfo workingCopy = new FileInfo(Path.Combine(WorkingDirectory.FullName, updateCandidate.Name));
            if (!workingCopy.Exists) return;
            if (_Debug) MessageBox.Show(updateCandidate.Name + ":\nExisting copy: " + workingCopy.LastWriteTimeUtc.ToString() + "\nUpdate candidate: " + updateCandidate.LastWriteTimeUtc.ToString());

            // Сравниваем файлы по дате
            if (updateCandidate.LastWriteTimeUtc > workingCopy.LastWriteTimeUtc)
            {
                try
                {
                    // Перезаписываем файл
                    updateCandidate.CopyTo(workingCopy.FullName, true);
                    if (_Debug) MessageBox.Show("NEW VERSION UPDATED\n" + updateCandidate.FullName);
                }
                catch
                {
                }
            }
        }
        #endregion

    }
}
