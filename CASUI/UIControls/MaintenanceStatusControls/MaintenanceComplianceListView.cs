using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения технических записей агрегата
    /// </summary>
    public class MaintenanceComplianceListView : SDList<MaintenancePerformance>
    {
        #region Fields

       // private int sortMultiplier = 1;
        //private readonly float[] HEADER_WIDTH = new float[] { 0.04f, 0.07f, 0.15f, 0.15f, 0.15f, 0.15f, 0.25f };
        private readonly float[] HEADER_WIDTH = new float[] { 0.04f, 0.15f, 0.15f, 0.25f, 0.4f };
        private bool doubleClickEnable = true;
        private int lastIndex;
        private const int HEADER_HEIGHT = 24;
        private const int DEFAULT_HEIGHT = 188;

        #endregion

        #region Constructors

        #region public MaintenanceComplianceListView()
        /// <summary>
        /// Создает элемент управления отображающий listview
        /// </summary>
        public MaintenanceComplianceListView()
        {
            ItemsListView.ForeColor = Css.OrdinaryText.Colors.DarkForeColor;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;

        }
        #endregion

        #region public MaintenanceComplianceListView(MaintenancePerformance[] detailRecordArray) : this()
        /// <summary>
        /// Создает элемент управления отображающий listview по заданому массиву технических записей <see cref="MaintenancePerformance"/>
        /// </summary>
        /// <param name="detailRecordArray">массив технических записей</param>
        public MaintenanceComplianceListView(MaintenancePerformance[] detailRecordArray) : this()
        {
            SetItemsArray(detailRecordArray);
        }

        #endregion

        #endregion

        #region Properties

        #region public MaintenancePerformance SelectedItem
        /// <summary>
        /// Возвращает выделенную техническую запись <see cref="MaintenancePerformance"/>
        /// </summary>
        public override MaintenancePerformance SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as MaintenancePerformance);
                return null;
            }
        }
        #endregion

        #region public new MaintenancePerformance [] SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных технических записей <see cref="MaintenancePerformance"/>
        /// </summary>
        public override List<MaintenancePerformance> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }
        #endregion

        #region public bool DoubleClickEnable
        /// <summary>
        /// Возвращает или устанавливает параметр, показывающий нужно ли открытие какого-либо окна при двойном щелчке мыши
        /// </summary>
        public bool DoubleClickEnable
        {
            get
            {
                return doubleClickEnable;
            }
            set
            {
                doubleClickEnable = value;
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
           // throw new NotImplementedException();
        }

        #endregion
        
        #region protected override void AddItems(MaintenancePerformance[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="MaintenancePerformance"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(MaintenancePerformance[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i], i + 1);
                }
                lastIndex = count;
                ItemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                sortMultiplier = 1;
                SortItems(2);
            }
        }

        #endregion


        #region public override MaintenancePerformance[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив технических записей (MaintenancePerformance)
        /// </summary>
        /// <returns>Массив технических записей (MaintenancePerformance)</returns>
        public override MaintenancePerformance[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            MaintenancePerformance[] returnRecordsArray = new MaintenancePerformance[0];
            if (count > 0)
            {
                returnRecordsArray = new MaintenancePerformance[count];
                for (int i = 0; i < count; i++)
                {
                    returnRecordsArray[i] = (MaintenancePerformance)ListViewItemList[i].Tag;
                }
            }
            return returnRecordsArray;
        }
        #endregion

        #region protected override ListViewItem AddItem(MaintenancePerformance item)

        /// <summary>
        /// Добавляет элемент 
        /// </summary>
        /// <param name="item"></param>
        protected override ListViewItem AddItem(MaintenancePerformance item)
        {
            lastIndex++;
            return AddItem(item, lastIndex);
        }

        #endregion

        #region protected override void AddItem(MaintenancePerformance item)
        /// <summary>
        /// Добавляет элемент в список технических записей (MaintenancePerformance)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (MaintenancePerformance)</param>
        /// <param name="index">Номер записи</param>
        protected ListViewItem AddItem(MaintenancePerformance item, int index)
        {
            string[] itemsString =
                new string[]
                    {
                        index.ToString(),
                        (item.CheckTypeExtended == "" ? item.CheckType.ShortName : item.CheckTypeExtended) + " check",
                        item.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()),
                        item.Lifelength.ToComplianceItemString(),
                        item.Description
                    };
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            ListViewItemList.Add(listViewItem);
            return listViewItem;
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
            columnHeader.Text = "Check";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "TSN/CSN";
            ColumnHeaderList.Add(columnHeader);
/*
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "To be performed";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Remained";
            ColumnHeaderList.Add(columnHeader);*/

            columnHeader = new ColumnHeader();
            //columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[6]);
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Remarks";
            ColumnHeaderList.Add(columnHeader);

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region private void SortItems(int columnIndex)
        private void SortItems(int columnIndex)
        {
            if (columnIndex == 0)
                return;
            if (sortMultiplier == 1) 
                sortMultiplier = -1;
            else
                sortMultiplier = 1;
            ListViewItemList.Sort(new MaintenancePerformanceListViewComparer(columnIndex, sortMultiplier));
            for (int i = 0; i < ListViewItemList.Count; i++)
            {
                ListViewItemList[i].SubItems[0].Text = (i + 1).ToString();
            }
            ItemsListView.Items.Clear();
            ItemsListView.Groups.Clear();
            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            ChangeSize();
        }
        #endregion

        #region protected override void Sort()

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            SortItems(1);
        }

        #endregion

        #region private MaintenancePerformance[] GetSelectedDetailRecordArray()
        private MaintenancePerformance[] GetSelectedDetailRecordArray()
        {
            int count = ItemsListView.SelectedItems.Count;
            MaintenancePerformance[] detailRecordArray = new MaintenancePerformance[count];
            for (int i = 0; i < count; i++)
            {
                detailRecordArray[i] = (MaintenancePerformance)ItemsListView.SelectedItems[i].Tag;
            }
            return detailRecordArray;
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
            if (SelectedItem != null && doubleClickEnable) 
                 OnItemDoubleClick();
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
                        ItemsListView_MouseDoubleClick(this, new MouseEventArgs(MouseButtons.Left, 2, MousePosition.X, MousePosition.Y, 0));
                    }
                    break;
                default:
                    break;
            }
        }


        #endregion

        #region private void ChangeSize()

        private void ChangeSize()
        {
            if (ItemsListView.Items.Count < 10)
                Height = DEFAULT_HEIGHT;
            else
            {
                Rectangle rect = ItemsListView.GetItemRect(ItemsListView.Items.Count - 1);
                Height = ItemsListView.Items.Count * rect.Height + HEADER_HEIGHT + BottomPanel.Height;
            }
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler ItemEdited;

        /// <summary>
        /// Событие, которое возникает после редактирования элемента
        /// </summary>
        public event EventHandler ItemEdited;

        #endregion

        #endregion

    }

    internal class MaintenancePerformanceListViewComparer : IComparer<ListViewItem>
    {

        #region Fields

        private readonly int columnIndex = 0;
        private readonly int sortMultiplier;

        #endregion

        #region Constructors

        #region public MaintenancePerformanceListViewComparer(int columnIndex)

        /// <summary>
        /// Создает компаратор для DirectiveListView
        /// </summary>
        /// <param name="columnIndex"></param>
        public MaintenancePerformanceListViewComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        #endregion

        #region public MaintenancePerformanceListViewComparer(int index, int sortMultiplier) : this(index)

        public MaintenancePerformanceListViewComparer(int index, int sortMultiplier)
            : this(index)
        {
            this.sortMultiplier = sortMultiplier;
        }

        #endregion

        #endregion

        #region Methods

        #region public int Compare(object x, object y)

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 2)
            {
                return
                    sortMultiplier *
                    DateTime.Compare(Convert.ToDateTime(x.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)),
                                     Convert.ToDateTime(y.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)));
            }
            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }
        #endregion

        #endregion


    }
}
