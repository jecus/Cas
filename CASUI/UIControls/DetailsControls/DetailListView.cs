using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.DetailsControls
{
    ///<summary>
    /// Элемент управлени для отображения списка агрегатов
    ///</summary>
    public class DetailListView : SDList<Detail> , IReference
    {
        #region Fields

        private readonly float[] HEADER_WIDTH = new float[] {0.03f, 0.09f, 0.26f, 0.08f, 0.05f, 0.04f, 0.07f, 0.18f, 0.18f,};
        //private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor, Css.ListView.Colors.PendingColor};
        //private readonly Color highlightColor = Css.ListView.Colors.PendingColor;
        private int ataSortMultiplier = -1;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 9;
        private readonly LandingGearsFilter landingGearsFilter = new LandingGearsFilter(true,true,true,true);
        private readonly BaseDetail parentBaseDetail;

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
        private bool groupByLandingGearPostionNumbers;
        private bool isLLPDiskSheetStatus = false;


        #endregion
     
        #endregion

        #region Constructors

        #region public DetailListView()

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов
        /// </summary>
        public DetailListView()
        {
            selectedItemsList = new List<Detail>();
            ItemsListView.Font = Css.ListView.Fonts.SmallRegularFont;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);
            oldColumnIndex = 1;
        }

        #endregion

        #region public DetailListView(BaseDetail parentBaseDetail) : this()

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов по заданому масиву агрегатов
        /// </summary>
        ///// <param name="detailArray">Массив агрегатов</param>
        /// <param name="parentBaseDetail">Базовый агрегат, которому принадлежат директивы</param>
        //public DetailListView(Detail[] detailArray, BaseDetail parentBaseDetail) : this()
        public DetailListView(BaseDetail parentBaseDetail) : this()
        {
            this.parentBaseDetail = parentBaseDetail;
           // SetItemsArray(detailArray);
        }

        #endregion
        
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
            set { reflectionType = value;}
        }
        #endregion

        #region public Detail SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override Detail SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) 
                    return (ItemsListView.SelectedItems[0].Tag as Detail);
                return null;
            }
        }
        #endregion

        #region public new Detail [] SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<Detail>  SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }
        #endregion

        #region public bool GroupByLandingGearPostionNumbers
        /// <summary>
        /// Груперовать ли отчет по позициям агрегатов входящих в состав LandingGear
        /// </summary>
        public bool GroupByLandingGearPostionNumbers
        {
            get
            {
                return groupByLandingGearPostionNumbers;
            }
            set
            {
                groupByLandingGearPostionNumbers = value;
            }
        }

        #endregion

        #region public bool IsLLPDiskSheetStatus

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее является ли отображаемый отчет LLP Disk Sheet Status
        /// </summary>
        public bool IsLLPDiskSheetStatus
        {
            get { return isLLPDiskSheetStatus; }
            set
            {
                isLLPDiskSheetStatus = value;
                if (value)
                {
                    sortMultiplier = -1;
                    oldColumnIndex = 2;
                }
                else
                    oldColumnIndex = 1;
            }
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #endregion

        #region Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            
        }

        #endregion

        #region protected override void AddItems(Detail[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="Detail"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(Detail[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                ListViewItemList.Sort(new ATAComparer());
                if (GroupByLandingGearPostionNumbers)
                    SetGroupToItemLandingGear();
                else
                    SetGroupToItemATAChapter();
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                sortMultiplier = -1;
                SortItems(oldColumnIndex);
            }
        }

        #endregion
        
        #region public override Detail[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив агрегатов
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override Detail[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            Detail[] returnDetailArray = new Detail[0];
            if (count > 0)
            {
                returnDetailArray = new Detail[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (Detail)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }
        #endregion

        #region protected override void AddItem(Detail item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(Detail item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.SubItems.Add(item.AtaChapter.FullName);
            if (landingGearsFilter.Acceptable(item))
            {
                listViewItem.SubItems.Add(TermsProvider.GetLandingGearPositionFullName(((GearAssembly)item.Parent).LandingGearMark.ToString()));
            }
            listViewItem.BackColor = item.Highlight.Color;

            if (item.ConditionState == DirectiveConditionState.Notify)
                listViewItem.BackColor = Css.ListView.Colors.NotifyColor;
            else if (item.ConditionState == DirectiveConditionState.NotSatisfactory)
                listViewItem.BackColor = Css.ListView.Colors.NotSatisfactoryColor; 

            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void AddNewItem(Detail item)

        /// <summary>
        /// Добавляет новый элемент в список
        /// </summary>
        /// <param name="item"></param>
        public override void AddNewItem(Detail item)
        {
            ItemsListView.Items.Add(AddItem(item));
            if (ItemsListView.Groups.Count != 0)
            {
                if (GroupByLandingGearPostionNumbers)
                    SetGroupToItemLandingGear();
                else
                    SetGroupToItemATAChapter();
            }
            Sort();
            SetTotalText();
        }

        #endregion

        #region private string[] GetItemsString(Detail item)

        private string[] GetItemsString(Detail item)
        {
            return new string[]
                       {
                           item.AtaChapter.ShortName, item.PartNumber, item.Description, item.SerialNumber,
                           item.PositionNumber.ToUpper(),
                           item.MaintenanceType.ShortName,
                           item.InstallationDate.ToString(new TermsProvider()["DateFormatShort"].ToString()),
                           "", //item.Limitation.LastPerformance != null ? ToComplianceFormat(item): "",
                           item.ApproximateDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                    };
        }

        #endregion

        #region private string ToComplianceFormat(Detail detail)

        /// <summary>
        /// Создается отображение наработки в виде Date / ? h ? c
        /// </summary>
        private string ToComplianceFormat(Detail detail)
        {
            return detail.ApproximateDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
        }

        #endregion

        #region private string ToNextFormat(Detail detail)

        /// <summary>
        /// Создается отображение наработки в виде WorkType: Date / ? h ? c
        /// </summary>
        private string ToNextFormat(Detail detail)
        {
            return "";// detail.Limitation.NextWorkType.ShortName + ": " + detail.Limitation.NextPerformance.ToListViewItemString(detail.ManufactureDate); todo
        }

        #endregion

        #region public override void EditItem(Detail oldItem,Detail modifiedItem)

        public override void EditItem(Detail oldItem,Detail modifiedItem)
        {
            string[] itemsString = GetItemsString(modifiedItem);
            string[] itemsStringModified = new string[itemsString.Length-1];
            Array.Copy(itemsString,1,itemsStringModified,0,itemsStringModified.Length);
            Detail detail = GetDetailReferenceByDetailID(oldItem.ID);
            if (detail == null) return;
            ListViewItem listViewItem = ItemsHash[detail];
            
            //ListViewItem listViewItem = new ListViewItem(modifiedItem.AtaChapter.ShortName);
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.AtaChapter.ShortName;
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.SubItems.Add(modifiedItem.AtaChapter.FullName);
            if (landingGearsFilter.Acceptable(modifiedItem))
            {
                listViewItem.SubItems.Add(TermsProvider.GetLandingGearPositionFullName(modifiedItem.PositionNumber));
            }
            listViewItem.BackColor = modifiedItem.Highlight.Color;

            if (modifiedItem.ConditionState == DirectiveConditionState.Notify)
                listViewItem.BackColor = Css.ListView.Colors.NotifyColor;
            else if (modifiedItem.ConditionState == DirectiveConditionState.NotSatisfactory)
                listViewItem.BackColor = Css.ListView.Colors.NotSatisfactoryColor; 

            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            //SortItems(oldColumnIndex);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private Detail GetDetailReferenceByDetailID(int id)

        private Detail GetDetailReferenceByDetailID(int id)
        {
            Detail[] details = GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ID == id)
                    return details[i];
            }
            return null;
        }

        #endregion

        #region private void SetGroupToItemATAChapter()
        private void SetGroupToItemATAChapter()
        {
            ItemsListView.Groups.Clear();
            int count = ListViewItemList.Count;
            if (count == 0) return;
            int ataIndex = (landingGearsFilter.Acceptable((Detail)ListViewItemList[0].Tag)) ? ListViewItemList[0].SubItems.Count - 2 : ListViewItemList[0].SubItems.Count - 1;
            string oldGroupName = ListViewItemList[0].Text + " " + ListViewItemList[0].SubItems[ataIndex].Text;
            AddGroup(oldGroupName);
            for (int i = 0; i < count; i++)
            {
                ataIndex = (landingGearsFilter.Acceptable((Detail)ListViewItemList[0].Tag)) ? ListViewItemList[0].SubItems.Count - 2 : ListViewItemList[0].SubItems.Count - 1; ;
                if (oldGroupName != ListViewItemList[i].Text + " " + ListViewItemList[i].SubItems[ataIndex].Text)
                {
                    oldGroupName = ListViewItemList[i].Text + " " + ListViewItemList[i].SubItems[ataIndex].Text;
                    AddGroup(oldGroupName);
                }
                ListViewItemList[i].Group = ItemsListView.Groups[oldGroupName];
            }
        }
        #endregion

        #region private void SetGroupToItemLandingGear()
        private void SetGroupToItemLandingGear()
        {
            ItemsListView.Groups.Clear();
            int count = ListViewItemList.Count;
            if (count == 0) return;
            AddGroup(TermsProvider.GetLandingGearPositionFullName("NLG"));
            AddGroup(TermsProvider.GetLandingGearPositionFullName("LH"));
            AddGroup(TermsProvider.GetLandingGearPositionFullName("RH"));

            for (int i = 0; i < count; i++)
            {
                int landingGearGroupIndex = ListViewItemList[i].SubItems.Count - 1;
                ListViewItemList[i].Group = ItemsListView.Groups[ListViewItemList[i].SubItems[landingGearGroupIndex].Text];
            }
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
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[0]);
            columnHeader.Text = "ATA";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[1]);
            columnHeader.Text = "Part. No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Serial No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Pos. No";
            ColumnHeaderList.Add(columnHeader);
            
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "M.F.";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[6]);
            columnHeader.Text = "Inst. date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[7]);
            columnHeader.Text = "Compliance";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[8]);
            columnHeader.Text = "Next";
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
                if (columnIndex == 0 ) 
                    ataSortMultiplier = -1;
            }
            if (sortMultiplier == 1 ) 
                sortMultiplier = -1;
            else
                sortMultiplier = 1;

            if (columnIndex == 0)
                if (ataSortMultiplier == 1) 
                    ataSortMultiplier = -1; 
                else 
                    ataSortMultiplier = 1;

            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);

            ListViewItemList.Sort(new ComponentStatusListViewComparer(columnIndexQueue, sortMultiplier, ataSortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            if (GroupByLandingGearPostionNumbers) 
                SetGroupToItemLandingGear(); 
            else 
                SetGroupToItemATAChapter();
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
                ColumnHeaderList[i].Width = (int) (Width*HEADER_WIDTH[i]);
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
            if (SelectedItem != null && e.Button == MouseButtons.Left)
            {
                OnDisplayerRequested();
            }
        }

        #endregion

        #region private void DetailListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            bool provideCurrentData = SelectedItem.ProvideCurrentData;
            if (!provideCurrentData) SelectedItem.ProvideCurrentData = true;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = ((Aircraft)SelectedItem.Parent.Parent).RegistrationNumber + ". Component SN " + SelectedItem.SerialNumber;
            e.RequestedEntity = new DispatcheredDetailScreen(SelectedItem);
            SelectedItem.ProvideCurrentData = provideCurrentData;            
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemsChanged!=null) 
                SelectedItemsChanged.Invoke(this,new SelectedItemsChangeEventArgs(selectedItemsList.Count));
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

        #endregion

    }

    internal class ATAComparer : IComparer<ListViewItem>
    {


        public int Compare(ListViewItem x, ListViewItem y)
        {
            return ComparerMethods.ATACompare(x.Text, y.Text);
        }
    }

    internal class ComponentStatusListViewComparer : IComparer<ListViewItem>
    {
        #region Fields
        private readonly int ataSortMultiplier = 1;
        private readonly int sortMultiplier;
        private readonly Queue<int> columnIndexQueue;
        #endregion

        #region Constructors

        #region public ComponentStatusListViewComparer(int columnIndex)
        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndexQueue">Индексы колонок по котороым производилась сортировка</param>
        public ComponentStatusListViewComparer(Queue<int> columnIndexQueue)
        {
            this.columnIndexQueue = columnIndexQueue;
        }

        #region public ComponentStatusListViewComparer(int index, int sortMultiplier):this(index)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        /// <param name="sortMultiplier"></param>
        public ComponentStatusListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier)
            : this(columnIndexQueue)
        {
            this.sortMultiplier = sortMultiplier;
        }
        #endregion

        #region public ComponentStatusListViewComparer(int index, int sortMultiplier, int multiplier): this(index, sortMultiplier)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        /// <param name="sortMultiplier"></param>
        /// <param name="ataMultiplier"></param>
        public ComponentStatusListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier, int ataMultiplier)
            : this(columnIndexQueue, sortMultiplier)
        {
            ataSortMultiplier = ataMultiplier;
        }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 1)
            {
                if (string.Compare(x.SubItems[1].Text, y.SubItems[1].Text) == 0)
                {
                    return string.Compare(x.SubItems[4].Text, y.SubItems[4].Text);
                }
                else return string.Compare(x.SubItems[1].Text, y.SubItems[1].Text);

            }
            if (columnIndex == 2)
                return ComparerMethods.DescriptionComparer(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
            return string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);

        }
        #endregion

        #region private int CheckColumnIndexQueue(int index ,ListViewItem x,ListViewItem y)
        private int CheckColumnIndexQueue(int index ,ListViewItem x,ListViewItem y)
        {
            int[] indexArray = columnIndexQueue.ToArray();
            if (index < 0) return 0;
            if (0 != ColumnComparer(indexArray[index], x, y))
                return ColumnComparer(indexArray[index], x, y);
            else 
                return CheckColumnIndexQueue(index - 1, x, y);

        }
        #endregion

        #region public int Compare(object x, object y)

        public int Compare(ListViewItem x, ListViewItem y)
        {
            int ataCompareResult = ComparerMethods.ATACompare(x.Text, y.Text);
            if (ataCompareResult == 0)
            {
                return sortMultiplier * CheckColumnIndexQueue(columnIndexQueue.Count-1, x, y);
            }
            return ataSortMultiplier * (ataCompareResult);
        }
        #endregion

        #endregion

      
    }
}
