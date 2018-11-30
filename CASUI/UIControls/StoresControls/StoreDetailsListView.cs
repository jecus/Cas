using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// Элемент управления для отображения списка агрегатов, хранящихся на складе
    ///</summary>
    public class StoreDetailsListView : SDList<object> , IReference
    {

        #region Fields

        private readonly Store currentStore;
        private readonly Operator currentOperator;
        private readonly float[] HEADER_WIDTH = new float[] {0.04f, 0.10f, 0.10f, 0.30f, 0.30f, 0.14f};
        private readonly Color[] COLORS = new Color[] { Css.CommonAppearance.Colors.BackColor, Css.ListView.Colors.NotifyColor, Css.ListView.Colors.NotSatisfactoryColor};
        private readonly Color highlightColor = Css.ListView.Colors.PendingColor;
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 8;
        private readonly List<string> groups = new List<string>();
        private readonly string enginesGroupName = "Engines";
        private readonly string apuGroupName = "APU";
        private readonly string landingGearsGroupName = "Landing gears";
        private readonly string consumablePartsGroupName = "Consumable Parts";
        private readonly string kitsGroupName = "Kits";
        
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

        #region public StoreDetailsListView(Store store)

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов, хранящихся на складе
        /// </summary>
        /// <param name="store">Текущий склад</param>
        public StoreDetailsListView(Store store)
        {
            currentStore = store;
            selectedItemsList = new List<object>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 1;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            SetGroupsOrder();
            UpdateItems();
        }

        #endregion
        
        #region public StoreDetailsListView(Operator currentOperator)

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов, хранящихся на всех складах эксплуатанта
        /// </summary>
        /// <param name="currentOperator">Эксплуатант</param>
        public StoreDetailsListView(Operator currentOperator)
        {
            this.currentOperator = currentOperator;
            selectedItemsList = new List<object>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 1;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            SetGroupsOrder();
            UpdateItems();
        }

        #endregion
        
        #endregion

        #region Properties

        #region public override object SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override object SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1) 
                    return (ItemsListView.SelectedItems[0].Tag as object);
                return null;
            }
        }
        #endregion

        #region public override List<object> SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<object> SelectedItems
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
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ItemsListView.Items.Clear();
            selectedItemsList.Clear();

            List<AbstractDetail> containedDetails = new List<AbstractDetail>();
            if (currentStore != null)
            {
                containedDetails.AddRange(currentStore.Engines);
                if (currentStore.Apu != null)
                    containedDetails.Add(currentStore.Apu);
                containedDetails.AddRange(currentStore.LandingGears);
                containedDetails.AddRange(currentStore.AircraftFrame.ContainedDetails);
            }
            else
            {
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                    containedDetails.AddRange(currentOperator.Stores[i].Engines);
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                    if (currentOperator.Stores[i].Apu != null)
                        containedDetails.Add(currentOperator.Stores[i].Apu);
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                    containedDetails.AddRange(currentOperator.Stores[i].LandingGears);
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                    containedDetails.AddRange(currentOperator.Stores[i].AircraftFrame.ContainedDetails);
            }
            AddItems(containedDetails.ToArray());
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(AbstractDetail[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="Detail"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(AbstractDetail[] itemsArray)
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

        #region protected override void AddItem(AbstractDetail item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(AbstractDetail item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            int hashCode = item.ConditionState.GetHashCode();

            listViewItem.BackColor = item.Highlight.Color;
            
            if (hashCode == 2 || item.ExpirationDate < DateTime.Now)
                listViewItem.BackColor = COLORS[2];
            else if (hashCode == 1 || item.NotificationDate < DateTime.Today)
                listViewItem.BackColor = COLORS[1];
            else
                listViewItem.BackColor = COLORS[0];
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void EditItem(AbstractDetail oldItem, AbstractDetail modifiedItem)

        public override void EditItem(AbstractDetail oldItem, AbstractDetail modifiedItem)
        {
            string[] itemsString = GetItemString(modifiedItem);
            AbstractDetail detail = GetDetailReferenceByDetailID(oldItem.ID);
            if (detail == null) return;
            ListViewItem listViewItem = ItemsHash[detail];
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++ )
                listViewItem.SubItems.Add(itemsString[i]);
            int hashCode = 1;// modifiedItem.LimitationCondition.GetHashCode(); todo
            listViewItem.BackColor = modifiedItem.Highlight.Color;
            if (hashCode == 2 || modifiedItem.ExpirationDate < DateTime.Now)
                listViewItem.BackColor = COLORS[2];
            else if (hashCode == 1 || modifiedItem.NotificationDate < DateTime.Today)
                listViewItem.BackColor = COLORS[1];
            else
                listViewItem.BackColor = COLORS[0];
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private static string[] GetItemString(AbstractDetail item)

        private static string[] GetItemString(AbstractDetail item)
        {
            return new string[]
                {item.AtaChapter.ShortName, item.PartNumber, item.SerialNumber, item.Description, item.Remarks, ""};
        }

        #endregion
        
        #region private AbstractDetail GetDetailReferenceByDetailID(int id)

        private AbstractDetail GetDetailReferenceByDetailID(int id)
        {
            AbstractDetail[] details = GetItemsArray();
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ID == id)
                    return details[i];
            }
            return null;
        }

        #endregion

        #region public override AbstractDetail[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив агрегатов
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override AbstractDetail[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            AbstractDetail[] returnDetailArray = new AbstractDetail[0];
            if (count > 0)
            {
                returnDetailArray = new AbstractDetail[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (AbstractDetail)ListViewItemList[i].Tag;
                }
            }
            return returnDetailArray;
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
            columnHeader.Text = "Serial No";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[3]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[4]);
            columnHeader.Text = "Remarks";
            ColumnHeaderList.Add(columnHeader);
            
            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[5]);
            columnHeader.Text = "Location";
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

            SetGroupsToItems();
            ListViewItemList.Sort(new CertainGroupsOrderListViewComparer(columnIndex, sortMultiplier, groups));

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
        
        #region private void SetGroupsOrder()

        private void SetGroupsOrder()
        {
            groups.Clear();
            ItemsListView.Groups.Clear();
            ATAChapterCollection ataChapterCollection = ATAChapterCollection.Instance;
            
            groups.Add(enginesGroupName);
            groups.Add(apuGroupName);
            groups.Add(landingGearsGroupName);
            for (int i = 0; i < ataChapterCollection.Count; i++)
                groups.Add(ataChapterCollection[i].ShortName + " " + ataChapterCollection[i].FullName);
            groups.Add(consumablePartsGroupName);
            groups.Add(kitsGroupName);
            for (int i = 0; i < groups.Count; i++)
                AddGroup(groups[i]);
        }

        #endregion

        #region private void SetGroupsToItems()

        private void SetGroupsToItems()
        {
            for (int i = 0; i < ListViewItemList.Count; i++)
                ListViewItemList[i].Group = ItemsListView.Groups[GetGroupNameInStoreDetailList(ListViewItemList[i].Tag)];
        }

        #endregion

        #region public string GetGroupNameInStoreDetailList(object item)

        /// <summary>
        /// Возвращает название группы в списке агрегатов текущего склада, согласно тому, какого типа элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string GetGroupNameInStoreDetailList(object item)
        {
            string groupName;
            if (item is Engine)
                groupName = enginesGroupName;
            else if (item is APU)
                groupName = apuGroupName;
            else if (item is GearAssembly)
                groupName = landingGearsGroupName;
            else
            {
                AbstractDetail detail = (AbstractDetail) item;
                if (detail.DetailPattern == DetailPattern.ConsumablePart)
                    groupName = consumablePartsGroupName;
                else if (detail.DetailPattern == DetailPattern.Kit)
                    groupName = kitsGroupName;
                else
                    groupName = detail.AtaChapter.ShortName + " " + detail.AtaChapter.FullName;
            }
            return groupName;
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
            if (SelectedItem != null)
            {
                if (SelectedItem.DetailPattern == DetailPattern.ConsumablePart || SelectedItem.DetailPattern == DetailPattern.Kit)
                {
                    ConsumablePartAndKitForm form = new ConsumablePartAndKitForm(SelectedItem);
                    form.Show();
                }
                else 
                    OnDisplayerRequested();
            }
        }

        #endregion

        #region private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (SelectedItem is BaseDetail)
                e.DisplayerText = ((Aircraft)SelectedItem.Parent).RegistrationNumber + ". Component SN " + SelectedItem.SerialNumber;
            else
                e.DisplayerText = ((Aircraft)SelectedItem.Parent.Parent).RegistrationNumber + ". Component SN " + SelectedItem.SerialNumber;
            e.RequestedEntity = new DispatcheredDetailScreen(SelectedItem);
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

        #endregion
        
        #region IReference Members

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

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion
        
    }
 
}