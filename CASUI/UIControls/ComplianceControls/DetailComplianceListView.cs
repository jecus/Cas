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
    /// Ёлемент управлени€ дл€ отображени€ технических записей агрегата
    /// </summary>
    public class DetailComplianceListView : SDList<AbstractRecord>
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly float[] HEADER_WIDTH = new float[] {0.13f, 0.15f, 0.15f, 0.55f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private const int SORT_MEMORY_COUNT = 8;
        private bool doubleClickEnable = true;
        private const int HEADER_HEIGHT = 24;
        private const int DEFAULT_HEIGHT = 188;
        
        #endregion

        #region Constructor

        /// <summary>
        /// —оздает элемент управлени€ отображающий listview по заданому массиву технических записей (AbstractRecord)
        /// </summary>
        /// <param name="currentDetail">јгрегат, которому принадлежат записи</param>
        public DetailComplianceListView(AbstractDetail currentDetail)
        {
            this.currentDetail = currentDetail;
            ItemsListView.ForeColor = Css.OrdinaryText.Colors.DarkForeColor;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;
            oldColumnIndex = 0;
            SetHeaders();
            //UpdateItems();
        }

        #endregion

        #region Properties

        #region public AbstractRecord SelectedItem
        /// <summary>
        /// ¬озвращает выделенную техническую запись (AbstractRecord)
        /// </summary>
        public override AbstractRecord SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as AbstractRecord);
                return null;
            }
        }
        #endregion

        #region public new AbstractRecord [] SelectedItems
        /// <summary>
        /// —войство возвращает массив выбранных технических записей (AbstractRecord)
        /// </summary>
        public override List<AbstractRecord> SelectedItems
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
            List<AbstractRecord> records = new List<AbstractRecord>();
            records.AddRange(currentDetail.GetActualSettingRecords());
            records.AddRange(currentDetail.GetTransferRecords());
            records.AddRange(currentDetail.GetDetailDirectivesPerformances());

            AddItems(records.ToArray());
            SetTotalText();
        }

        #endregion
        
        #region protected override void AddItems(AbstractRecord[] itemsArray)

        /// <summary>
        /// ƒобавл€ет элементы <see cref="AbstractRecord"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(AbstractRecord[] itemsArray)
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
                SortItems(oldColumnIndex);
            }
        }

        #endregion

        #region protected override ListViewItem AddItem(AbstractRecord item)
        /// <summary>
        /// ƒобавл€ет элемент в список технических записей (AbstractRecord)
        /// </summary>
        /// <param name="item">ƒобавл€ема€ техническа€ запись (AbstractRecord)</param>
        protected override ListViewItem AddItem(AbstractRecord item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void EditItem(AbstractRecord oldItem, AbstractRecord modifiedItem)

        public override void EditItem(AbstractRecord oldItem, AbstractRecord modifiedItem)
        {
            string[] itemsString = GetItemString(modifiedItem);
            AbstractRecord detail = GetAbstractRecordReferenceByAbstractRecordID(oldItem.ID);
            if (detail == null) return;
            ListViewItem listViewItem = ItemsHash[detail];
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
                listViewItem.SubItems.Add(itemsString[i]);
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private static string[] GetItemString(AbstractRecord item)

        private static string[] GetItemString(AbstractRecord item)
        {
            string workType = item.RecordType.FullName;
            string lifelength;
            if (item is TransferRecord)
            {
                TransferRecord transferRecord = (TransferRecord) item;
                if (transferRecord.TransferContainer != null)
                    workType = "Transfered to " + transferRecord.TransferContainer.TransferDescription;
                lifelength = item.Lifelength.ToComplianceItemStringFull();
            }
            else if (item is ActualStateRecord)
                lifelength = item.Lifelength.ToComplianceItemString();
            else
            {
                workType = ((DetailDirective) item.Parent).DirectiveType.FullName;
                lifelength = item.Lifelength.ToComplianceItemStringFull();
            }
            return new[]
                       {
                           item.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()),
                           lifelength,
                           workType,
                           item.Description
                       };
        }

        #endregion

        #region public override AbstractRecord[] GetItemsArray()
        /// <summary>
        /// ћетод возвращает массив технических записей (AbstractRecord)
        /// </summary>
        /// <returns>ћассив технических записей (AbstractRecord)</returns>
        public override AbstractRecord[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            AbstractRecord[] returnRecordsArray = new AbstractRecord[0];
            if (count > 0)
            {
                returnRecordsArray = new AbstractRecord[count];
                for (int i = 0; i < count; i++)
                {
                    returnRecordsArray[i] = (AbstractRecord)ListViewItemList[i].Tag;
                }
            }
            return returnRecordsArray;
        }
        #endregion

        #region private AbstractRecord GetAbstractRecordReferenceByAbstractRecordID(int id)

        private AbstractRecord GetAbstractRecordReferenceByAbstractRecordID(int id)
        {
            AbstractRecord[] details = GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ID == id)
                    return details[i];
            }
            return null;
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

            ListViewItemList.Sort(new DetailComplianceListViewComparer(columnIndex, sortMultiplier));
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
                if (SelectedItem.RecordType == RecordTypesCollection.Instance.TransferType)
                {
                    TransferRecordForm form = new TransferRecordForm(currentDetail, (TransferRecord)SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        UpdateItems();
                }
                else if (SelectedItem.RecordType == RecordTypesCollection.Instance.ActualStateRecordType)
                {
                    ActualStateRecordForm form = new ActualStateRecordForm((ActualStateRecord)SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        UpdateItems();
                }
                else
                {
                    ComplianceForm form = new ComplianceForm((DirectiveRecord)SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        UpdateItems();
                }
            }
        }

        #endregion

        #region private void form_Saved(AbstractRecord record)

        private void form_Saved(AbstractRecord record)
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