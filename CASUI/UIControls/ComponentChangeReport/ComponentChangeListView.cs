using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.ComplianceControls;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.ComponentChangeReport

{
    /// <summary>
    /// Элемент управления отображения списка отклонений
    /// </summary>
    public class ComponentChangeListView : SDList<TransferRecord>
    {

       #region Fields

        private readonly Aircraft currentAircraft;
        public List<TransferRecord> records = new List<TransferRecord>();
        private readonly float[] HEADER_WIDTH = new float[] {0.09f,0.44f,0.44f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private const int SORT_MEMORY_COUNT = 8;
        private bool doubleClickEnable = true;
        private const int HEADER_HEIGHT = 24;
        private const int DEFAULT_HEIGHT = 188;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления отображающий listview по ВС (Aircraft)
        /// </summary>
        /// <param name="currentAircraft">ВС, которому принадлежат записи</param>
        public ComponentChangeListView(Aircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
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

       

        #region public TransferRecord SelectedItem
        /// <summary>
        /// Возвращает выделенную техническую запись (AbstractRecord)
        /// </summary>
        public override TransferRecord SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as TransferRecord);
                return null;
            }
        }
        #endregion

        #region public new Trannsfer [] SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных технических записей (AbstractRecord)
        /// </summary>
        public override List<TransferRecord> SelectedItems
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
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();
            AddItems(records.ToArray());
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(TransferRecord[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="AbstractRecord"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(TransferRecord[] itemsArray)
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
        /// Добавляет элемент в список технических записей (AbstractRecord)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected override ListViewItem AddItem(TransferRecord item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.Tag = item;
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void EditItem(TransferRecord oldItem, TransferRecord modifiedItem)

        public override void EditItem(TransferRecord oldItem, TransferRecord modifiedItem)
        {
            string[] itemsString = GetItemString(modifiedItem);
            TransferRecord detail = GetAbstractRecordReferenceByAbstractRecordID(oldItem.ID);
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
        
        #region private bool isTransferContainerIdInBaseDetail(int id)
        /// <summary>
        /// Возращает истину если id Transfer Recorf совпадает с id базового агрегата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool isTransferContainerIdInBaseDetail(int id)
        {
            for (int i = 0; i < currentAircraft.BaseDetails.Length; i++)
                if (currentAircraft.BaseDetails[i].ID == id) return true;
            return false;
        }
        #endregion

        #region private static string[] GetItemString(TransferRecord item)

        private /*static*/ string[] GetItemString(TransferRecord item)
        {
            Detail detail = (Detail) item.Parent;
            string description = detail.Description + " " +
                                 item.Position
                                 + " P/N:" + detail.PartNumber + " S/N: " + detail.SerialNumber;
            if (isTransferContainerIdInBaseDetail(item.TransferContainerId)||
                (item.TransferContainer is Aircraft && item.TransferContainerId==currentAircraft.ID))

                return new[]
                           {
            item.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()),
            "",
            description
        }

    ;
            else
                return new[]
    {item.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()), description, ""};
            

            
        }

        #endregion

        #region public override TransferRecord[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив технических записей (AbstractRecord)
        /// </summary>
        /// <returns>Массив технических записей (AbstractRecord)</returns>
        public override TransferRecord[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            TransferRecord[] returnRecordsArray = new TransferRecord[0];
            if (count > 0)
            {
                returnRecordsArray = new TransferRecord[count];
                for (int i = 0; i < count; i++)
                {
                    returnRecordsArray[i] = (TransferRecord)ListViewItemList[i].Tag;
                }
            }
            return returnRecordsArray;
        }
        #endregion

        #region private AbstractRecord GetAbstractRecordReferenceByAbstractRecordID(int id)

        private TransferRecord GetAbstractRecordReferenceByAbstractRecordID(int id)
        {
            TransferRecord[] details = GetItemsArray();
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
        /// Устанавливает заголовки
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
            columnHeader.Text = "Off";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "On";
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
           // ChangeSize();
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
                    TransferRecordForm form = new TransferRecordForm((AbstractDetail)SelectedItem.Parent, SelectedItem);
                    if (form.ShowDialog() == DialogResult.OK)
                        UpdateItems();
                }
                
            }
        }

        #endregion

        #region private void form_Saved(AbstractRecord record)

        private void form_Saved(TransferRecord record)
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
        /// Событие, которое возникает после редактирования элемента
        /// </summary>
        public event EventHandler ItemEdited;

        #endregion

        #endregion

    }
    
    

    #region internal class DiscrepanciesListViewComparer : IComparer<ListViewItem>

    internal class DiscrepanciesListViewComparer : IComparer<ListViewItem>
    {
        #region Fields
        private readonly int[] indexArray;
        private readonly int sortMultiplier = 1;
        #endregion

        #region Constructors

        #region public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue)

        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue)
        {
            indexArray = columnIndexQueue.ToArray();
        }
        #endregion

        #region public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier): this(columnIndexQueue)
        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndexQueue"></param>
        /// <param name="sortMultiplier"></param>
        public DiscrepanciesListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier)
            : this(columnIndexQueue)
        {
            this.sortMultiplier = sortMultiplier;
        }
        #endregion

        #endregion

        #region Methods

        #region private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 2)
                return ComparerMethods.DescriptionComparer(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
            if (columnIndex == 1)
                return ComparerMethods.AdStatusComparer(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
            if (columnIndex == 6)
                return
                    DateTime.Compare(((IMaintainable) x.Tag).ApproximateDate,
                                     ((IMaintainable) y.Tag).ApproximateDate);
            return String.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);

        }
        #endregion

        #region private int CheckColumnIndexQueue(int index ,ListViewItem x,ListViewItem y)

        private int CheckColumnIndexQueue(int index, ListViewItem x, ListViewItem y)
        {
            if (index < 0) return 0;
            if (0 != ColumnComparer(indexArray[index], x, y))
                return ColumnComparer(indexArray[index], x, y);
            else
                return CheckColumnIndexQueue(index - 1, x, y);

        }
        #endregion

        #region public int Compare(ListViewItem x, ListViewItem y)

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (x.Group == y.Group)
            {
                return -sortMultiplier * CheckColumnIndexQueue(indexArray.Length - 1, x, y);
            }
            return String.Compare(x.Group.Name, y.Group.Name) ;

        }

     
        #endregion

        #endregion
    }

    #endregion

}
