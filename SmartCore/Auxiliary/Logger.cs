using System;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace SmartCore.Auxiliary
{

    /// <summary>
    /// Позволяет гадить лог в файлик
    /// </summary>
    public class Logger
    {

        /*
         * Работа с логером
         */

        #region public Logger(String fileName)
        /// <summary>
        /// Создает логгер и файл 
        /// </summary>
        /// <param name="fileName"></param>
        public Logger(String fileName)
        {
            string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string avnFolder = Path.Combine(appFolder, "Avalon Worldgroup Inc\\Continuing Airworthiness System");
            _FileName = Path.Combine(avnFolder, fileName);
        }
        #endregion

        #region public void Clear()
        /// <summary>
        /// Стирает все записи лога
        /// </summary>
        public void Clear()
        {
            try
            {
                FileInfo file = new FileInfo(_FileName);
                if (file.Exists) file.Delete();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region public void Write(String s)
        /// <summary>
        /// Оставляет запись в файле лога
        /// </summary>
        /// <param name="s"></param>
        public void Write(String s)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_FileName, true, Encoding.Default))
                {
                    sw.WriteLine(s + "\r\n");
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region public void Open()
        /// <summary>
        /// Открывает файл лога для просмотра
        /// </summary>
        public void Open()
        {
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(_FileName);
                p.Start();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        /*
         * Реализация
         */

        #region private String _FileName;
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private String _FileName;
        #endregion

    }
}
