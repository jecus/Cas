using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.TemplatesControls
{
    ///<summary>
    /// Элемент управлени для отображения списка шаблонных агрегатов
    ///</summary>
    public class TemplateDetailListView : SDList<TemplateDetail>, IReference
    {
        
        #region Fields

        private readonly ITemplateDetailContainer detailSource;
        private readonly TemplateDetailCollectionFilter filter;
        private TemplateDetailCollectionFilter additionalFilter;
        private readonly float[] HEADER_WIDTH = new float[] { 0.10f, 0.10f, 0.58f, 0.10f, 0.10f, };
        private int ataSortMultiplier = -1;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        

        #endregion
        
        #region Constructors

        #region public TemplateDetailListView(TemplateBaseDetail detailSource, TemplateDetailCollectionFilter filter)

        /// <summary>
        /// Создает элемент управления отображающий список шаблонных агрегатов по заданому масиву агрегатов
        /// </summary>
        /// <param name="detailSource">"Содержатель" агрегатов</param>
        /// <param name="filter">Фильтр</param>
        public TemplateDetailListView(ITemplateDetailContainer detailSource, TemplateDetailCollectionFilter filter)
        {
            this.detailSource = detailSource;
            this.filter = filter;
            selectedItemsList = new List<TemplateDetail>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);
            oldColumnIndex = 1;
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

        #endregion
        
        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion
        
        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion
        
        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region public override TemplateDetail SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override TemplateDetail SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) 
                    return (ItemsListView.SelectedItems[0].Tag as TemplateDetail);
                return null;
            }
        }

        #endregion

        #region public override List<TemplateDetail> SelectedItems

        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<TemplateDetail> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }

        #endregion

        #region public TemplateDirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Возвращает или устанавливает дополнительный фильтр 
        /// </summary>
        public TemplateDetailCollectionFilter AdditionalFilter
        {
            get
            {
                return additionalFilter;
            }
            set
            {
                additionalFilter = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public override void UpdateItems()

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            SetItemsArray(GatherDetails());
        }

        #endregion

        #region public TemplateDetail[] GatherDetails()

        /// <summary>
        /// Собирает все агрегаты
        /// </summary>
        /// <returns></returns>
        public TemplateDetail[] GatherDetails()
        {
            List<TemplateDetailFilter> appliedFilters = new List<TemplateDetailFilter>(filter.Filters);
            if (additionalFilter != null)
                appliedFilters.AddRange(additionalFilter.Filters);
            TemplateDetailCollectionFilter generalFilter = new TemplateDetailCollectionFilter(detailSource.ContainedDetails, appliedFilters.ToArray());
            return generalFilter.GatherDetails();
        }

        #endregion

        #region protected override void AddItems(TemplateDetail[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="TemplateDetail"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(TemplateDetail[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                ListViewItemList.Sort(new ATAComparer());
                SetGroupToItem();
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                sortMultiplier = -1;
                SortItems(oldColumnIndex);
            }
        }

        #endregion
        
        #region public override TemplateDetail[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив агрегатов
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override TemplateDetail[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            TemplateDetail[] returnDetailArray = new TemplateDetail[0];
            if (count > 0)
            {
                returnDetailArray = new TemplateDetail[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (TemplateDetail)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }
        #endregion

        #region protected override void AddItem(TemplateDetail item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(TemplateDetail item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.SubItems.Add(item.AtaChapter.FullName);
            listViewItem.Tag = item;
            ItemsHash.Add(item, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void AddNewItem(TemplateDetail item)

        /// <summary>
        /// Добавляет новый элемент в список
        /// </summary>
        /// <param name="item"></param>
        public override void AddNewItem(TemplateDetail item)
        {
            ItemsListView.Items.Add(AddItem(item));
            if (ItemsListView.Groups.Count != 0)
                SetGroupToItem();
            sortMultiplier = sortMultiplier * (-1);
            ataSortMultiplier = ataSortMultiplier * (-1);
            Sort();
            SetTotalText();
        }

        #endregion

        #region public override void EditItem(TemplateDetail oldItem, TemplateDetail modifiedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(TemplateDetail oldItem, TemplateDetail modifiedItem)
        {
            string[] itemsString = GetItemsString(modifiedItem);
            string[] itemsStringModified = new string[itemsString.Length - 1];
            Array.Copy(itemsString, 1, itemsStringModified, 0, itemsStringModified.Length);
            ListViewItem listViewItem = ItemsHash[GetDetailReferenceByDetailID(oldItem.ID)];
            listViewItem.SubItems.Clear();
            listViewItem.Text = modifiedItem.AtaChapter.ShortName;
            listViewItem.SubItems.AddRange(itemsStringModified);
            listViewItem.SubItems.Add(modifiedItem.AtaChapter.FullName);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            sortMultiplier = sortMultiplier * (-1);
            ataSortMultiplier = ataSortMultiplier * (-1);
            SortItems(oldColumnIndex);
            ItemsListView.Refresh();
        }

        #endregion

        #region private TemplateDetail GetDetailReferenceByDetailID(int id)

        private TemplateDetail GetDetailReferenceByDetailID(int id)
        {
            TemplateDetail[] details = GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ID == id)
                    return details[i];
            }
            return null;
        }

        #endregion

        #region private string[] GetItemsString(TemplateDetail item)

        private string[] GetItemsString(TemplateDetail item)
        {
            return
                new string[]
                    {
                        item.AtaChapter.ShortName, item.PartNumber, item.Description, item.MaintenanceType.ShortName,
                        item.Amount.ToString()
                    };
        }

        #endregion

        #region private void SetGroupToItem()

        private void SetGroupToItem()
        {
            ItemsListView.Groups.Clear();
            int count = ListViewItemList.Count;
            int ataIndex = ListViewItemList[0].SubItems.Count - 1;
            string oldGroupName = ListViewItemList[0].Text + " " + ListViewItemList[0].SubItems[ataIndex].Text;
            AddGroup(oldGroupName);
            for (int i = 0; i < count; i++)
            {
                if (oldGroupName != ListViewItemList[i].Text + " " + ListViewItemList[i].SubItems[ataIndex].Text)
                {
                    oldGroupName = ListViewItemList[i].Text + " " + ListViewItemList[i].SubItems[ataIndex].Text;
                    AddGroup(oldGroupName);
                }
                ListViewItemList[i].Group = ItemsListView.Groups[oldGroupName];
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
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[0]);
            columnHeader.Text = "ATA";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Part. No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "M.F.";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Amount";
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
                if (columnIndex == 0) ataSortMultiplier = -1;
            }
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;

            if (columnIndex == 0) if (ataSortMultiplier == 1) ataSortMultiplier = -1; else ataSortMultiplier = 1;

            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);

            ListViewItemList.Sort(new TemplateDetailListViewComparer(columnIndexQueue, sortMultiplier, ataSortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            SetGroupToItem();
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
                ColumnHeaderList[i].Width = (int)(Width * HEADER_WIDTH[i]);
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

        #region private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //e.DisplayerText = "Templates. " + ((TemplateAircraft)SelectedItem.Parent.Parent).Model + ". Component PN " + SelectedItem.PartNumber;
            e.DisplayerText = ((TemplateAircraft)SelectedItem.Parent.Parent).Model + ". Component PN " + SelectedItem.PartNumber;
            e.RequestedEntity = new DispatcheredTemplateDetailScreen(SelectedItem);
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemsChanged != null) SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
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

        #region Events

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;

        #endregion

        internal class ATAComparer : IComparer<ListViewItem>
        {
            public int Compare(ListViewItem x, ListViewItem y)
            {
                return ComparerMethods.ATACompare(x.Text, y.Text);
            }
        }

        internal class TemplateDetailListViewComparer : IComparer<ListViewItem>
        {
            #region Fields
            private readonly int ataSortMultiplier = 1;
            private readonly int sortMultiplier;
            private readonly Queue<int> columnIndexQueue;
            #endregion

            #region Constructors

            #region public TemplateDetailListViewComparer(int columnIndex)
            /// <summary>
            /// Создает компаратор для ListViewItem
            /// </summary>
            /// <param name="columnIndexQueue">Индексы колонок по котороым производилась сортировка</param>
            public TemplateDetailListViewComparer(Queue<int> columnIndexQueue)
            {
                this.columnIndexQueue = columnIndexQueue;
            }

            #region public TemplateDetailListViewComparer(int index, int sortMultiplier):this(index)
            /// <summary>
            /// 
            /// </summary>
            /// <param name="columnIndexQueue"></param>
            /// <param name="sortMultiplier"></param>
            public TemplateDetailListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier)
                : this(columnIndexQueue)
            {
                this.sortMultiplier = sortMultiplier;
            }
            #endregion

            #region public TemplateDetailListViewComparer(int index, int sortMultiplier, int multiplier): this(index, sortMultiplier)
            /// <summary>
            /// 
            /// </summary>
            /// <param name="columnIndexQueue"></param>
            /// <param name="sortMultiplier"></param>
            /// <param name="ataMultiplier"></param>
            public TemplateDetailListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier, int ataMultiplier)
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
            private int CheckColumnIndexQueue(int index, ListViewItem x, ListViewItem y)
            {
                int[] indexArray = columnIndexQueue.ToArray();
                if (index < 0) return 0;
                if (0 != ColumnComparer(indexArray[index], x, y))
                    return ColumnComparer(indexArray[index], x, y);
                else
                    return CheckColumnIndexQueue(index - 1, x, y);

            }
            #endregion

            #region public int Compare(ListViewItem x, ListViewItem y)

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
                int ataCompareResult = ComparerMethods.ATACompare(x.Text, y.Text);
                if (ataCompareResult == 0)
                {
                    return sortMultiplier * CheckColumnIndexQueue(columnIndexQueue.Count - 1, x, y);
                }
                return ataSortMultiplier * (ataCompareResult);
            }
            #endregion

            #endregion


        }

    }
}
