using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения списка JobCard
    /// </summary>
    public class MaintenanceJobCardsListView : SDList<JobCard>, IReference
    {

        #region Fields

        private readonly MaintenanceSubCheck subCheck;
        private readonly float[] HEADER_WIDTH = new float[] { 0.25f, 0.25f, 0.25f, 0.23f };
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка JobCard
        /// </summary>
        /// <param name="subCheck"></param>
        public MaintenanceJobCardsListView(MaintenanceSubCheck subCheck)
        {
            selectedItemsList = new List<JobCard>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += listViewJobCards_ColumnClick;
            ItemsListView.MouseDoubleClick += listViewJobCards_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += MaintenanceJobCardsListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);

            this.subCheck = subCheck;
            UpdateItems();
        }

        #endregion

        #region Properties

        #region public override MaintenanceJobCard SelectedItem

        /// <summary>
        /// Выбранная Job карта
        /// </summary>
        public override JobCard SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as JobCard);
                return null;
            }
        }

        #endregion

        #region public override List<MaintenanceJobCard> SelectedItems

        /// <summary>
        /// Возвращает список выбранных JobCard
        /// </summary>
        public override List<JobCard> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            sortMultiplier = -1;
            List<JobCard> jobCards = new List<JobCard>(subCheck.JobCards);
            for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++ )
                jobCards.AddRange(subCheck.JoinedSubChecks[i].JobCards);
            SetItemsArray(jobCards.ToArray());
        }
        #endregion

        #region protected override void AddItems(MaintenanceJobCard[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="JobCard"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(JobCard[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                SetGroupsToItems();
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                SortItems(oldColumnIndex);
            }
        }

        #endregion

        #region private void SetGroupsToItems()
        
        private void SetGroupsToItems()
        {
            if (ListViewItemList.Count == 0 || subCheck.JoinedSubChecks.Count == 0) 
                return;
            AddGroup(subCheck.Name);
            for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++ )
                AddGroup(subCheck.JoinedSubChecks[i].Name);
            for (int i = 0; i < ListViewItemList.Count; i++)
                ListViewItemList[i].Group = GetListViewGroup(ListViewItemList[i]);
            
        }

        #endregion

        #region private ListViewGroup GetListViewGroup(ListViewItem item)

        private ListViewGroup GetListViewGroup(ListViewItem item)
        {
            return ItemsListView.Groups[((MaintenanceSubCheck)((JobCard)item.Tag).Parent).Name];
        }

        #endregion

        #region public override MaintenanceJobCard[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив рабочих карт
        /// </summary>
        /// <returns>Массив рабочих карт</returns>
        public override JobCard[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            JobCard[] returnDetailArray = new JobCard[0];
            if (count > 0)
            {
                returnDetailArray = new JobCard[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (JobCard)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }
        #endregion

        #region private string[] GetItemsString(MaintenanceJobCard jobCard)

        private string[] GetItemsString(JobCard jobCard)
        {
            return new string[] { jobCard.AirlineCardNumber, jobCard.WorkArea, jobCard.Revision, UsefulMethods.NormalizeDate(jobCard.Date) };
        }

        #endregion

        #region protected override ListViewItem AddItem(MaintenanceJobCard jobCard)

        protected override ListViewItem AddItem(JobCard jobCard)
        {
            string[] itemsString = GetItemsString(jobCard);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = jobCard;
            ItemsHash.Add(jobCard, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;

        }

        #endregion

        #region public override void EditItem(MaintenanceJobCard oldItem, MaintenanceJobCard modifiedItem)

        public override void EditItem(JobCard oldItem, JobCard modifiedItem)
        {
            string[] itemsString = GetItemsString(modifiedItem);
            string[] itemsStringModified = new string[itemsString.Length - 1];
            Array.Copy(itemsString, 1, itemsStringModified, 0, itemsStringModified.Length);
            ListViewItem listViewItem = ItemsHash[GetJobCardReferenceByJobCardID(oldItem.ID)];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.AirlineCardNumber;
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private JobCard GetJobCardReferenceByJobCardID(int id)

        private JobCard GetJobCardReferenceByJobCardID(int id)
        {
            JobCard[] jobCards = GetItemsArray();
            for (int i = 0; i < jobCards.Length; i++)
            {
                if (jobCards[i].ID == id)
                    return jobCards[i];
            }
            return null;
        }

        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeader columnHeader;
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[0]);
            columnHeader.Text = "Card Number";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Work Area";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Revision";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region private void SortItems(int columnIndex)

        private void SortItems(int columnIndex)
        {

            if (oldColumnIndex != columnIndex)
            {
                sortMultiplier = -1;

            }
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;

            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);

            ListViewItemList.Sort(new ListViewItemsComparer(columnIndex, sortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            SetGroupsToItems();
            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            ShowGroups = true;
            oldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void Sort()

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            SortItems(oldColumnIndex);
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            int count = ColumnHeaderList.Count;
            for (int i = 0; i < count; i++)
            {
                ColumnHeaderList[i].Width = (int)(Width * HEADER_WIDTH[i]);
            }
        }
        #endregion

        #region private void listViewJobCards_ColumnClick(object sender, ColumnClickEventArgs e)

        private void listViewJobCards_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortItems(e.Column);
        }

        #endregion

        #region private void listViewJobCards_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listViewJobCards_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null && e.Button == MouseButtons.Left)
            {
                OnMouseDoubleClicked();
            }
        }

        #endregion

        #region private void MaintenanceJobCardsListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void MaintenanceJobCardsListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                OnMouseDoubleClicked();
            }
            e.Cancel = true;
        }

        #endregion

        #region public void OnMouseDoubleClicked()

        /// <summary>
        /// Обрабатывает событие двойного щелчка мыши по элементу
        /// </summary>
        public void OnMouseDoubleClicked()
        {
            if (SelectedItem.AttachedFile.FileData == null)
                OpenJobCardProperties();
            else
            {
                Thread thread = new Thread(OpenReport);
                thread.Start(SelectedItem);
            }
        }

        #endregion

        #region private void OpenJobCardProperties()

        private void OpenJobCardProperties()
        {
            MaintenanceJobCardForm form = new MaintenanceJobCardForm(SelectedItem);
            form.Saved += form_Saved;
            form.ShowDialog();
        }

        #endregion

        #region private void form_Saved(JobCard jobCard)

        private void form_Saved(JobCard jobCard)
        {
            UpdateItems();
        }

        #endregion

        #region private void OpenReport(object parameter)

        private void OpenReport(object parameter)
        {
            JobCard jobCard = (JobCard)parameter;
            string path = TermsProvider.GetTempFolderPath() + "\\" + jobCard.AirlineCardNumber + ".pdf";
            if (!File.Exists(path))
                UsefulMethods.SaveFileFromByteArray(jobCard.AttachedFile.FileData, path);
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

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemsChange(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
        }

        #endregion

        #region private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            switch (e.KeyData)
            {
                case Keys.Enter:
                    if (SelectedItem != null)
                    {
                        OnMouseDoubleClicked();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

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