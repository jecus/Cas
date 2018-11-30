using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed;
using CAS.UI.UIControls.Auxiliary;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.ModificationsPerformed
{
    /// <summary>
    /// Элемент управления для работы со списком <see cref="ModificationItem"/> 
    /// </summary>
    internal class ModificationsPerformedListView : SDList<ModificationItem>, IReference
    {
        #region Fields

        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 6;
        private readonly float[] HEADER_WIDTH = new float[] {0.1f, 0.1f, 0.1f, 0.19f, 0.1f, 0.1f, 0.1f, 0.19f};
        private readonly Aircraft parentAircraft;

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

        #region Constructors

        #region public ModificationsPerformedListView()

        /// <summary>
        /// Создает элемент управления для работы со списком <see cref="Core.Types.Directives.ModificationItem"/> 
        /// </summary>
        public ModificationsPerformedListView()
        {
            sortMultiplier = -1;
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.KeyDown += ItemsListView_KeyDown;
            DisplayerRequested += DirectiveListView_DisplayerRequested;
            columnIndexQueue.Enqueue(0);
        }

        #endregion

        #region public ModificationsPerformedListView(Aircraft parentAircraft) : this()

        /// <summary>
        /// Создает элемент управления для работы со списком <see cref="Core.Types.Directives.ModificationItem"/> 
        /// </summary>
        /// <param name="parentAircraft">ВС, которому принадлежат ModificationItem</param>
        public ModificationsPerformedListView(Aircraft parentAircraft) : this()
        {
            this.parentAircraft = parentAircraft;
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

        #region public ModificationItem SelectedItem

        /// <summary>
        /// Возвращает выделенный ModificationItem
        /// </summary>
        public override ModificationItem SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as ModificationItem);
                return null;
            }
        }

        #endregion

        #region public override List<ModificationItem> SelectedItems

        /// <summary>
        /// Свойство возвращает массив выбранных item-ов
        /// </summary>
        public override List<ModificationItem> SelectedItems
        {
            get { return selectedItemsList; }
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
            SetItemsArray(parentAircraft.ModificationItems);
        }

        #endregion

        #region public void PreviousSort()

        /// <summary>
        /// Осушествляет предидущую сортировку
        /// </summary>
        public void PreviousSort()
        {
            SortItems(oldColumnIndex, sortMultiplier);
        }

        #endregion

        #region protected override void AddItems(ModificationItem[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="ModificationItem"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(ModificationItem[] itemsArray)
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
                sortMultiplier = -1;
                if (columnIndexQueue.Count == 1)
                    SortItems(0, sortMultiplier);
            }
        }

        #endregion

        #region public override ModificationItem[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public override ModificationItem[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            ModificationItem[] returnDetailArray = new ModificationItem[0];
            if (count > 0)
            {
                returnDetailArray = new ModificationItem[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (ModificationItem) ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
        }

        #endregion

        #region protected override void AddItem(ModificationItem item)

        /// <summary>
        /// Добавляет элемент в список директив
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(ModificationItem item)
        {
            ListViewItem listViewItem = PrepareItem(item);
            ItemsHash.Add(item, listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }

        #endregion

        #region private ListViewItemSuperable<ModificationItem> PrepareItem(ModificationItem item)

        private ListViewItem PrepareItem(ModificationItem item)
        {
            string[] itemsString = GetItemsString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            listViewItem.SubItems.Add(item.SbNo);
            listViewItem.Tag = item;
            return listViewItem;
        }

        #endregion

        #region public ListViewItem PrepareItem(ModificationItem item, ref ListViewItem listViewItem)

        private void PrepareItem(ModificationItem item, ref ListViewItem listViewItem)
        {
            string[] itemsString = GetItemsString(item);
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++)
            {
                listViewItem.SubItems.Add(itemsString[i]);
            }
            listViewItem.SubItems.Add(item.SbNo);
            listViewItem.Tag = item;
        }

        #endregion

        #region private string[] GetItemsString(ModificationItem item)

        private string[] GetItemsString(ModificationItem item)
        {
            return new string[]
                {
                    item.SbNo, item.EngineeringOrderNo, item.AirworthinessDirectiveNo, item.Description,
                    item.DateOfPerform.ToString(new TermsProvider()["DateFormat"].ToString()), item.StampPPCD,
                    item.NumberWorkPackage, item.Remarks
                };
        }

        #endregion

        #region public override void EditItem(ModificationItem oldItem, ModificationItem modifedItem)

        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public override void EditItem(ModificationItem oldItem,
                                      ModificationItem modifiedItem)
        {
            ListViewItem listViewItem = ItemsHash[GetModificationItemReferenceByModificationItemID(oldItem.ID)];
            PrepareItem(modifiedItem, ref listViewItem);
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem, listViewItem);
            ItemsListView.Refresh();
        }

        #endregion

        #region private ModificationItem GetModificationItemReferenceByModificationItemID(int id)

        private ModificationItem GetModificationItemReferenceByModificationItemID(int id)
        {
            ModificationItem[] modificationItems = GetItemsArray();
            for (int i = 0; i < modificationItems.Length; i++)
            {
                if (modificationItems[i].ID == id)
                    return modificationItems[i];
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
            columnHeader.Text = "SB/Sl No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[1]);
            columnHeader.Text = "EO No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[2]);
            columnHeader.Text = "AD No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[3]);
            columnHeader.Text = "Subject/Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[4]);
            columnHeader.Text = "Date of  Perform";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[5]);
            columnHeader.Text = "Stamp PPCD";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[6]);
            columnHeader.Text = "Work Package";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int) (ItemsListView.Width*HEADER_WIDTH[7]);
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
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (SelectedItem != null)
            {
                e.DisplayerText = parentAircraft.RegistrationNumber + ". " + SelectedItem.SbNo + " " + SelectedItem.EngineeringOrderNo + " " + SelectedItem.AirworthinessDirectiveNo + " Record";
                e.RequestedEntity = new DispatcheredModificationItemScreen(SelectedItem);//, parentAircraft);
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