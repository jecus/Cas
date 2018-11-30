using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.ComplianceControls
{
    /// <summary>
    /// Ёлемент управлени€ дл€ отображени€ технических записей директивы
    /// </summary>
    public class DirectiveComplianceListView : SDList<DirectiveRecord>
    {

        #region Fields

        private readonly BaseDetailDirective currentDirective;
        private readonly float[] HEADER_WIDTH = new float[] {0.15f, 0.2f, 0.2f, 0.43f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 8;
        private bool doubleClickEnable = true;
        private const int HEADER_HEIGHT = 24;
        private const int DEFAULT_HEIGHT = 188;

        #endregion

        #region Constructor

        /// <summary>
        /// —оздает элемент управлени€ отображающий listview по заданому массиву технических записей (DetailReocrd)
        /// </summary>
        /// <param name="directive">ƒиректива, которой принадлежат записи</param>
        public DirectiveComplianceListView(BaseDetailDirective directive)
        {
            currentDirective = directive;
            ItemsListView.ForeColor = Css.OrdinaryText.Colors.DarkForeColor;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;
            UpdateItems();
        }
     
        #endregion

        #region Properties

        #region public DirectiveRecord SelectedItem
        /// <summary>
        /// ¬озвращает выделенную техническую запись (DirectiveRecord)
        /// </summary>
        public override DirectiveRecord SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as DirectiveRecord);
                return null;
            }
        }
        #endregion

        #region public new DirectiveRecord[] SelectedItems
        /// <summary>
        /// —войство возвращает массив выбранных технических записей (DetailRecords)
        /// </summary>
        public override List<DirectiveRecord> SelectedItems
        {
            get
            {
                return selectedItemsList;
            }
        }
        #endregion

        #region public bool DoubleClickEnable
        /// <summary>
        /// ¬озвращает или устанавливает параметр, показывающий нужно ли открытие какого-либо окна при двойном щелчке мыши
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
        /// ќбновл€ет элементы ListView
        /// </summary>
        public override void UpdateItems()
        {
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();
            List<DirectiveRecord> records = new List<DirectiveRecord>(currentDirective.GetPerformances());
            DirectiveRecord closingRecord = currentDirective.GetClosingRecord();
            if (closingRecord != null)
                records.Add(closingRecord);
            AddItems(records.ToArray());
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(DirectiveRecord[] itemsArray)

        /// <summary>
        /// ƒобавл€ет элементы <see cref="OfficialRecord"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(DirectiveRecord[] itemsArray)
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
                sortMultiplier = 1;
                SortItems(0);
            }
        }

        #endregion

        #region protected override ListViewItem AddItem(DirectiveRecord item)
        /// <summary>
        /// ƒобавл€ет элемент в список технических записей (DirectiveRecord)
        /// </summary>
        /// <param name="item">ƒобавл€ема€ техническа€ запись (DirectiveRecord)</param>
        protected override ListViewItem AddItem(DirectiveRecord item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region private static string[] GetItemString(DirectiveRecord item)

        private static string[] GetItemString(DirectiveRecord item)
        {
            bool open = item.RecordType == RecordTypesCollection.Instance.DirectivePerformanceRecordType;
            return new string[]
                    {
                        item.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()),
                        open ? item.Lifelength.ToComplianceItemStringFull() : "",
                        item.RecordType.FullName,
                        item.Description
                    };
        }

        #endregion

        #region public override DirectiveRecord[] GetItemsArray()
        /// <summary>
        /// ћетод возвращает массив технических записей (DirectiveRecord)
        /// </summary>
        /// <returns>ћассив технических записей (DirectiveRecord)</returns>
        public override DirectiveRecord[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            DirectiveRecord[] returnRecordsArray = new DirectiveRecord[0];
            if (count > 0)
            {
                returnRecordsArray = new DirectiveRecord[count];
                for (int i = 0; i < count; i++)
                {
                    returnRecordsArray[i] = (DirectiveRecord)ListViewItemList[i].Tag;
                }
            }
            return returnRecordsArray;
        }
        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// ”станавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeader columnHeader;
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[0]);
            columnHeader.Text = "Date";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "TSN/CSN";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "Work Type";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Remarks";
            ColumnHeaderList.Add(columnHeader);

            ItemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
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
            else columnIndexQueue.Enqueue(columnIndex);

            ItemsListView.Items.Clear();

            ListViewItemList.Sort(new DirectiveComplianceListViewComparer(columnIndex, sortMultiplier));
            ItemsListView.Items.AddRange(ListViewItemList.ToArray());
            oldColumnIndex = columnIndex;
            ChangeSize();
        }
        #endregion

        #region protected override void Sort()

        /// <summary>
        /// ѕроисходит сортировка списка
        /// </summary>
        protected override void Sort()
        {
            SortItems(0);
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
            if (SelectedItem != null && doubleClickEnable)
            {
                ComplianceForm form = new ComplianceForm(SelectedItem);
                form.RecordChanged += form_RecordChanged;
                form.ShowDialog();
            }
        }

        #endregion

        #region private void form_RecordChanged(object sender, EventArgs e)

        private void form_RecordChanged(object sender, EventArgs e)
        {
            if (ItemEdited != null)
                ItemEdited(this, EventArgs.Empty);
        }

        #endregion

        #region private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)

        private void ItemsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedItemsChange(this,new SelectedItemsChangeEventArgs(selectedItemsList.Count));
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
        /// —обытие, которое возникает после редактировани€ элемента
        /// </summary>
        public event EventHandler ItemEdited;

        #endregion

        #endregion
        
    }

}