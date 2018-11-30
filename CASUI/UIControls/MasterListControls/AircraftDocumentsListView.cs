using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.MasterListControls
{
    public class AircraftDocumentsListView : SDList<BaseDetailDirective>, IReference
    {
        #region Fields

        private readonly Aircraft currentAircraft;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly float[] HEADER_WIDTH = new float[] { 0.12f, 0.360f, 0.06f, 0.12f, 0.16f, 0.16f };
        private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor, Css.ListView.Colors.PendingColor };

        #region IReferenceMembers
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;

        private string displayerText;
        private ReflectionTypes reflectionType;

        #endregion

        #endregion

        #region Constructors

        #region public AircraftDocumentsListView()
        /// <summary>
        /// Создает элемент управления для отображения списка документов ВС
        /// </summary>
        public AircraftDocumentsListView()
        {
            sortMultiplier = -1;
            selectedItemsList = new List<BaseDetailDirective>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown; ;
            DisplayerRequested += DirectiveListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);
        }
        #endregion

        #region public DirectiveListView(AircraftDocumentsListView[] directiveArray, BaseDetail parentBaseDetail)
        /// <summary>
        /// Создает элемент управления для отображения списка документов ВС
        /// </summary>
        /// <param name="currentAircraft">ВС, которому принадлежат документы</param>
        public AircraftDocumentsListView(Aircraft currentAircraft) : this()
        {
            this.currentAircraft = currentAircraft;
            UpdateItems();
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
            set { reflectionType = value; }
        }
        #endregion

        #region public BaseDetailDirective SelectedItem
        /// <summary>
        /// Возвращает выделенную директиву
        /// </summary>
        public override BaseDetailDirective SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) return (ItemsListView.SelectedItems[0].Tag as BaseDetailDirective);
                return null;
            }
        }
        #endregion

        #region public override List<BaseDetailDirective> SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных директив
        /// </summary>
        public override List<BaseDetailDirective> SelectedItems
        {
            get
            {
                return selectedItemsList;

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
           //AddItems(currentAircraft.);
        }

        #endregion

        #region protected override void AddItems(BaseDetailDirective[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="BaseDetailDirective"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(BaseDetailDirective[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                if (itemsArray[0].DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                    sortMultiplier = -1;
                else
                    sortMultiplier = 1;
                if (columnIndexQueue.Count == 1)
                    SortItems(0, sortMultiplier);
            }
        }

        #endregion

        #region public override BaseDetailDirective[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public override BaseDetailDirective[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            BaseDetailDirective[] returnDetailArray = new BaseDetailDirective[0];
            if (count > 0)
            {
                returnDetailArray = new BaseDetailDirective[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (BaseDetailDirective)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }
        #endregion

        #region protected override void AddItem(BaseDetailDirective item)
        /// <summary>
        /// Добавляет элемент в список директив
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(BaseDetailDirective item)
        {
            ListViewItem listViewItem = PrepareItem(item);
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
                
        #endregion


        #region private ListViewItem PrepareItem(BaseDetailDirective item)

        private ListViewItem PrepareItem(BaseDetailDirective item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            LoadListViewItem(item, ref listViewItem);
            return listViewItem;
        }

    

        #endregion

        #region private void PrepareItem(BaseDetailDirective item, ref ListViewItem listViewItem)

        private void PrepareItem(BaseDetailDirective item, ref ListViewItem listViewItem)
        {
            string[] itemsString = GetItemsString(item);
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
            {
                listViewItem.SubItems.Add(itemsString[i]);    
            }
            LoadListViewItem(item, ref listViewItem);
        }

        #endregion


        #region private void LoadListViewItem(BaseDetailDirective item, ListViewItem listViewItem)

        private void LoadListViewItem(BaseDetailDirective item, ref ListViewItem listViewItem)
        {
            if (item.AtaChapter != null)
                listViewItem.SubItems.Add(item.AtaChapter.FullName);
            else
                listViewItem.SubItems.Add("0");
            //if (IsNullLifelengthes(item) && !item.Closed)
            //    listViewItem.BackColor = Css.ListView.Colors.PendingColor;
            //else
                listViewItem.BackColor = COLORS[item.Condition.GetHashCode()];
            listViewItem.Tag = item;
        }

        #endregion

        #region private string[] GetItemsString(BaseDetailDirective item)

        private string[] GetItemsString(BaseDetailDirective item)
        {
            string description = Regex.Replace(item.Description, "\r\n", " ");

            //LifelengthFormatter lifelengthFormatter = new LifelengthFormatter(new TimeSpanFormatter(0, 0, 0, false, true, false), 0, new TimeSpanFormatter(0, 0, 0, true, false, false));
            string status = "Open";
            if (item.Closed) status = "Closed";
            else if (item.RepeatedlyPerform && item.FirstPerformOccured) status = "Repeat";
            DateTime manufactureDate = ((BaseDetail) item.Parent).ManufactureDate;
            return new string[]
                {
                    item.Title, description,
                    status, 
                    status != "Closed" ? (item.RepeatPerform != null ? (item.RepeatedlyPerform ? item.RepeatPerform.ToRepeatIntervalsFormat() : "") : "") : "",
                    item.LastPerformance == null ? "" : item.LastPerformance.Lifelength.ToListViewItemString(manufactureDate),
                    item.NextPerformance == null ? "" : item.NextPerformance.ToListViewItemString(manufactureDate)
                };
        }

        #endregion

        #region public override void EditItem(BaseDetailDirective oldItem, BaseDetailDirective modifedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(BaseDetailDirective oldItem, BaseDetailDirective modifiedItem)
        {
            ListViewItem listViewItem = ItemsHash[oldItem];//todo вот тут переделать если надо
            PrepareItem(modifiedItem,ref listViewItem);
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
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
            columnHeader.Text = "#";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Document Name";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Issue Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Expiration Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Remarks";
            ColumnHeaderList.Add(columnHeader);


            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override void Sort()

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            SortItems(oldColumnIndex, sortMultiplier);
        }

        #endregion


        #region private void SortItems(int columnIndex,int sortMultiplier)
        private void SortItems(int columnIndex, int columnSortMultiplier)
        {
            if (columnIndexQueue.Count >= SORT_MEMORY_COUNT)
            {
                columnIndexQueue.Dequeue();
                columnIndexQueue.Enqueue(columnIndex);
            }
            else columnIndexQueue.Enqueue(columnIndex);
            ListViewItemList.Sort(new DirectiveListViewComparer(columnIndexQueue, columnSortMultiplier));
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            ShowGroups = true;
            oldColumnIndex = columnIndex;

        }
        #endregion

        #region protected void OnDisplayerRequested()
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
            if (oldColumnIndex != e.Column) sortMultiplier = -1;
            if (sortMultiplier == 1)
                sortMultiplier = -1;
            else
                sortMultiplier = 1;
            SortItems(e.Column, sortMultiplier);
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

        #region private void DirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void DirectiveListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                bool provideCurrentData = SelectedItem.ProvideCurrentData;
                if (!provideCurrentData) SelectedItem.ProvideCurrentData = true;
                string regNumber = "";
                if (SelectedItem.Parent is AircraftFrame)
                    regNumber = SelectedItem.Parent.ToString();
                else
                {
                    if ((SelectedItem.Parent).Parent is Aircraft)
                        regNumber = ((Aircraft)((SelectedItem.Parent).Parent)).RegistrationNumber + ". " + SelectedItem.Parent;
                }
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = regNumber + ". " + SelectedItem.DirectiveType.CommonName + ". " + SelectedItem.Title;
                e.RequestedEntity = new DispatcheredDirectiveScreen(SelectedItem);
                SelectedItem.ProvideCurrentData = provideCurrentData;
            }
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemsChange(this, new SelectedItemsChangeEventArgs(selectedItemsList.Count));
        }

        #endregion

        #region private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        private void ItemsListView_KeyDown(object sender, KeyEventArgs e)
        {
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

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion

    }

}
