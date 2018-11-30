using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.WorkPackages
{
    /// <summary>
    /// ListView для отображения списка рабочих пакетов
    /// </summary>
    public class WorkPackagesListView : SDList<WorkPackage>, IReference
    {

        #region Fields

        //private List<ListViewItemM> listViewItemListM = new List<ListViewItemM>();

        private readonly Aircraft parentAircraft;
        private readonly float[] HEADER_WIDTH = new float[] { 0.2f, 0.3f, 0.1f, 0.1f, 0.10f, 0.18f };
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();

        #region private IDisplayer displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        #endregion

        #region private DisplayingEntity entity
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;
        #endregion

        #region private ReflectionTypes reflectionType
        private string displayerText;
        private ReflectionTypes reflectionType;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создает ListView для отображения списка рабочих пакетов
        /// </summary>
        /// <param name="parentAircraft">ВС, которому принадлежат рабочие пакеты</param>
        public WorkPackagesListView(Aircraft parentAircraft)
        {
            this.parentAircraft = parentAircraft;
            selectedItemsList = new List<WorkPackage>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += WorkPackagesListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            AddGroup(GetStatusName(WorkPackageStatus.Open));
            AddGroup(GetStatusName(WorkPackageStatus.Published));
            AddGroup(GetStatusName(WorkPackageStatus.Closed));

            UpdateItems();
        }

        #endregion

        #region Properties

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #region public DisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        #endregion

        #region public override WorkPackage SelectedItem
        /// <summary>
        /// Возврашет выделеный элемент
        /// </summary>
        public override WorkPackage SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                {
                    return ItemsListView.SelectedItems[0].Tag as WorkPackage;
                }
                return null;
            }
        }
        #endregion

        #region public override List<WorkPackage> SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<WorkPackage> SelectedItems
        {
            get { return selectedItemsList; }
        }
        #endregion

        #region public IMaintainable[] Items
        /// <summary>
        /// Return array of contained items
        /// </summary>
        public IMaintainable[] Items
        {
            get
            {
                Int32 count = ListViewItemList.Count;
                IMaintainable[] result = new IMaintainable[count];

                for (int i = 0; i < count; i++)
                {
                    result[i] = ListViewItemList[i].Tag as IMaintainable;
                }
                return result;
            }
        }
        #endregion

/*        #region protected  List<ListViewItem> ListViewItemList
        /// <summary>
        /// Список элементов управления массива
        /// </summary>
        protected new List<ListViewItemM> ListViewItemList
        {
            get { return listViewItemListM; }
            set { listViewItemListM = value; }
        }
        #endregion*/

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        //public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #endregion

        #region Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();
            AddItems(parentAircraft.WorkPackages);
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(WorkPackage[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="WorkPackage"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(WorkPackage[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                    AddItem(itemsArray[i]);
                sortMultiplier = -1;
                SortItems(oldColumnIndex);
            }
            
        }

        #endregion

        #region protected override ListViewItem AddItem(WorkPackage item)

        protected override ListViewItem AddItem(WorkPackage item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            ItemsHash.Add(item, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }

        #endregion

        #region public override void EditItem(WorkPackage oldItem, WorkPackage modifiedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(WorkPackage oldItem, WorkPackage modifiedItem)
        {
            ListViewItem listViewItem = ItemsHash[GetWorkPackageReferenceByWorkPackageID(oldItem.ID)];
            PrepareItem(modifiedItem, ref listViewItem);
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private WorkPackage GetWorkPackageReferenceByWorkPackageID(int id)

        private WorkPackage GetWorkPackageReferenceByWorkPackageID(int id)
        {
            WorkPackage[] workPackages = GetItemsArray();
            for (int i = 0; i < workPackages.Length; i++)
            {
                if (workPackages[i].ID == id)
                    return workPackages[i];
            }
            return null;
        }

        #endregion

        #region private void PrepareItem(WorkPackage item, ref ListViewItem listViewItem)

        private void PrepareItem(WorkPackage item, ref ListViewItem listViewItem)
        {
            string[] itemsString = GetItemsString(item);
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
                listViewItem.SubItems.Add(itemsString[i]);
            listViewItem.Tag = item;
        }

        #endregion




        #region private static string GetStatusName(WorkPackageStatus status)

        private static string GetStatusName(WorkPackageStatus status)
        {
            if (status == WorkPackageStatus.Open)
                return "Open";
            else if (status == WorkPackageStatus.Published)
                return "Published";
            else
                return "Closed";
        }

        #endregion

        #region private void SetGroupsToItems()

        private void SetGroupsToItems()
        {
            for (int i = 0; i < ListViewItemList.Count; i++)
            {
                WorkPackage workPackage = (WorkPackage) ListViewItemList[i].Tag;
                ListViewItemList[i].Group = ItemsListView.Groups[GetStatusName(workPackage.Status)];
            }
        }

        #endregion



        #region private string[] GetItemsString(WorkPackage workPackage)

        private string[] GetItemsString(WorkPackage workPackage)
        {
            string date;
            if (workPackage.Status == WorkPackageStatus.Open)
            {
                date = workPackage.OpeningDate.ToString(new TermsProvider()["DateFormat"].ToString());
            }
            else if (workPackage.Status == WorkPackageStatus.Published)
            {
                date = workPackage.PublishingDate.ToString(new TermsProvider()["DateFormat"].ToString());
            }
            else
            {
                date = workPackage.ClosingDate.ToString(new TermsProvider()["DateFormat"].ToString());
            }
            return new string[]
                {workPackage.Title, workPackage.Description, GetStatusName(workPackage.Status), date,
                    workPackage.Author, workPackage.Remarks};
        }

        #endregion

        #region private void SortItems(int columnIndex)

        private void SortItems(int columnIndex)
        {
            if (oldColumnIndex != columnIndex)
                sortMultiplier = -1;
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;
            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else 
                columnIndexQueue.Enqueue(columnIndex);

            ItemsListView.Items.Clear();
            SetGroupsToItems();
            
            ListViewItemList.Sort(new WorkPackageListViewItemsComparer(columnIndex, sortMultiplier));

            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            
            
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

        #region public override WorkPackage[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив базовых элементов (CoreType)
        /// </summary>
        /// <returns>Массив базовых элементов (CoreType)</returns>
        public override WorkPackage[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            WorkPackage[] returnCoreTypeArray = new WorkPackage[0];
            if (count > 0)
            {
                returnCoreTypeArray = new WorkPackage[count];
                for (int i = 0; i < count; i++)
                {
                    returnCoreTypeArray[i] = (WorkPackage)ListViewItemList[i].Tag;
                }
            }
            return returnCoreTypeArray;
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
            columnHeader.Text = "Title";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Status";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Author";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Remarks";
            ColumnHeaderList.Add(columnHeader);

            if (ItemsListView.Columns.Count == 0) 
                ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
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
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent)
                    reflection = ReflectionTypes.DisplayInNew;
                
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
                ColumnHeaderList[i].Width = (int) (Width * HEADER_WIDTH[i]);
            }
        }
        #endregion

        #region private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)

        private void ItemsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortItems(e.Column);
        }

        #endregion

        #region private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ItemsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null)
            {
                OnDisplayerRequested();
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
                        OnDisplayerRequested();
                    }
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region private void WorkPackagesListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void WorkPackagesListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = parentAircraft.RegistrationNumber + ". " + SelectedItem.Title;
            e.RequestedEntity = new DispatcheredWorkPackageScreen(SelectedItem);
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Сравнивалка <see cref="ListViewItem"/>-ов
    /// </summary>
    public class WorkPackageListViewItemsComparer : IComparer<ListViewItem>
    {
        #region Fields

        private readonly int columnIndex;
        private readonly int sortMultiplier;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает сравнивалку <see cref="ListViewItem"/>
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="sortMultiplier"></param>
        public WorkPackageListViewItemsComparer(int columnIndex, int sortMultiplier)
        {
            this.columnIndex = columnIndex;
            this.sortMultiplier = sortMultiplier;
        }

        #endregion

        #region Methods

        #region IComparer<ListViewItem> Members

        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (x.Group.Name == "Open" && y.Group.Name == "Published")
                return 1;
            if (x.Group.Name == "Open" && y.Group.Name == "Closed")
                return 1;
            if (x.Group.Name == "Published" && y.Group.Name == "Closed")
                return 1;
            if (x.Group.Name == "Published" && y.Group.Name == "Open")
                return -1;
            if (x.Group.Name == "Closed" && y.Group.Name == "Open")
                return -1;
            if (x.Group.Name == "Closed" && y.Group.Name == "Published")
                return -1;

            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }

        #endregion

        #endregion
    }
}
