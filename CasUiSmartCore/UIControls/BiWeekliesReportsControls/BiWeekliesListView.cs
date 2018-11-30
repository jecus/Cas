using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Management;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls;
using CAS.UI.Messages;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CASTerms;
using Microsoft.VisualBasic.Devices;


namespace CAS.UI.UIControls.BiWeekliesReportsControls
{
    /// <summary>
    /// Элемент управления для отображения списка BiWeekly-отчетов
    /// </summary>
    public class BiWeekliesListView : Control, IReference
    {

        #region Fields

        private readonly List<BiWeekly> biWeeklyItems = new List<BiWeekly>();
        private readonly ListView listViewBiWeeklies = new ListView();
        private readonly ImageList imageList = new ImageList();
        private readonly List<BiWeekly> selectedItemsArray = new List<BiWeekly>();
        private readonly Icons icons = new Icons();
        private const int LVM_SETICONSPACING = 0x1035;//или 4149  - сообщение для изменения отступов вокруг иконок, во как!

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка BiWeekly-отчетов
        /// </summary>
        public BiWeekliesListView()
        {
            //
            // imageList
            //
            imageList.Images.Add(icons.PDF_GIF);
            imageList.ImageSize = new Size(50, 50);
            //
            // listViewBiWeeklies
            //
            listViewBiWeeklies.View = View.LargeIcon;
            listViewBiWeeklies.LargeImageList = imageList;
            listViewBiWeeklies.Dock = DockStyle.Fill;
            listViewBiWeeklies.ItemSelectionChanged += listViewBiWeeklies_ItemSelectionChanged;
            listViewBiWeeklies.MouseDoubleClick += listViewBiWeeklies_MouseDoubleClick;

            DisplayerRequested += BiWeekliesListView_DisplayerRequested;
            Controls.Add(listViewBiWeeklies);
            SendMessage(listViewBiWeeklies.Handle, LVM_SETICONSPACING, 0, MakeLong(120, 120));
        }

        #endregion

        #region Properties

        #region public BiWeekly SelectedItem

        /// <summary>
        /// Выбранный отчет Biweekly
        /// </summary>
        public BiWeekly SelectedItem
        {
            get
            {
                if (listViewBiWeeklies.SelectedItems.Count == 1) 
                    return (listViewBiWeeklies.SelectedItems[0].Tag as BiWeekly);
                return null;
            }
        }
        #endregion
        
        #region public List<BiWeekly> SelectedItems

        /// <summary>
        /// Возвращает список выбранных отчетов BiWeekly
        /// </summary>
        public List<BiWeekly> SelectedItems
        {
            get
            {
                return selectedItemsArray;
            }
        }
        #endregion

        #region public ListView ListViewBiWeeklies

        /// <summary>
        /// Возвращает объект ListView
        /// </summary>
        public ListView ListViewBiWeeklies
        {
            get { return listViewBiWeeklies; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void UpdateItems(BiWeekliesCollection biWeekliesCollection)

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public void UpdateItems(BiWeekliesCollection biWeekliesCollection)
        {
            listViewBiWeeklies.Items.Clear();
            biWeeklyItems.Clear();
            selectedItemsArray.Clear();
            if (biWeekliesCollection.Count == 0)
                return;
            biWeeklyItems.AddRange(biWeekliesCollection.ToArray());
            biWeeklyItems.Sort(new BiWeeklyComparer());
            DateTime lastBiWeeklyReportReceiveDate = DateTime.MinValue;
            int lastBiWeeklyItemID = 0;
            for (int i = 0; i < biWeeklyItems.Count; i++)
            {
                ListViewItem item = new ListViewItem(biWeeklyItems[i].RealName, 0);
                item.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                item.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
                item.Tag = biWeeklyItems[i];
                listViewBiWeeklies.Items.Add(item);
                if (lastBiWeeklyReportReceiveDate < biWeeklyItems[i].RecievedDate)
                {
                    lastBiWeeklyReportReceiveDate = biWeeklyItems[i].RecievedDate;
                    lastBiWeeklyItemID = listViewBiWeeklies.Items.IndexOf(item);
                }
            }
            listViewBiWeeklies.Items[lastBiWeeklyItemID].Font = new Font(Css.OrdinaryText.Fonts.SmallRegularFont, FontStyle.Bold);
        }
        #endregion

        #region static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        /// <summary>
        /// Имортированный метод для посылки сообщений WinAPI
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        //[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, int lParam);

        #endregion

        #region private static int MakeLong(int x, int y)

        /// <summary>
        /// Как я понял, это какой-то метод, предназначенный для перевода требуемых значений отступа вокруг иконок 
        /// в значения, используещиеся в WinAPI в качестве lParam.. вот такая вот лабудаа..)) (Сергей Д.)
        /// </summary>
        private static int MakeLong(int x, int y)
        {
            return (y << 16) | x;
        }

        #endregion

        #region private void OpenReport(object parameter)

        private void OpenReport(object parameter)
        {
            BiWeekly biWeeklyReport = (BiWeekly) parameter;
            string path = TermsProvider.GetTempFolderPath() + "\\" + biWeeklyReport.RealName;
            bool successCreating = true;
            if (!File.Exists(path))
                successCreating = biWeeklyReport.SaveReportToFile(path);
            if (!successCreating)
                return;
            Process tempProcess = new Process();
            tempProcess.StartInfo = new ProcessStartInfo(path);
            try
            {
                tempProcess.Start();
                tempProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                
            }

            try
            {
                TryDeleteFile(path);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while deleting data", ex);
            }
        }


        #endregion

        #region private void TryDeleteFile(string path)

        private void TryDeleteFile(string path)
        {
            FileInfo file = new FileInfo(path);
            while (file.Exists)
            {
                try
                {
                    file.Delete();
                    Thread.CurrentThread.Abort();
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
        }

        #endregion





        #region protected void OnDisplayerRequested()

        /// <summary>
        /// Метод обработки события DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }

        #endregion

        #region private void listViewBiWeeklies_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listViewBiWeeklies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null && e.Button == MouseButtons.Left)
            {
                OnMouseDoubleClicked();
            }
        }

        #endregion

        #region private void BiWeekliesListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void BiWeekliesListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
/*            string tempPath;
            if (SelectedItem.SaveReportToFile(tempPath))
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = "BiWeekly Report " + SelectedItem.RealName;
                e.RequestedEntity = new DispatcheredBiWeeklyReportScreen(SelectedItem, ScreenMode.Edit);
            }
            else*/
                e.Cancel = true;
        }

        #endregion

        #region private void listViewBiWeeklies_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void listViewBiWeeklies_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            BiWeekly item = (BiWeekly)e.Item.Tag;
            if (e.IsSelected)
            {
                selectedItemsArray.Add(item);
            }
            else
            {
                if (selectedItemsArray.Contains(item)) 
                    selectedItemsArray.Remove(item);
            }
            if (SelectedItemsChanged != null)
                SelectedItemsChanged(this, new EventArgs());
        }

        #endregion

        #region public void OnMouseDoubleClicked()

        /// <summary>
        /// Обрабатывает событие двойного щелчка мыши по элементу
        /// </summary>
        public void OnMouseDoubleClicked()
        {
            Thread thread = new Thread(OpenReport);
            thread.Start(SelectedItem);
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие изменения выделенных элементов ListView
        /// </summary>
        public event EventHandler SelectedItemsChanged;

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}