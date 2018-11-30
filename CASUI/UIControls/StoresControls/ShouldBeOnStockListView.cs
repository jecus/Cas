using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// Элемент управления для отображения списка агрегатов, хранящихся на складе
    ///</summary>
    public class ShouldBeOnStockListView : SDList<StockDetailInfo> , IReference
    {

        #region Fields

        private readonly Store currentStore;
        private readonly Operator currentOperator;

        private readonly float[] HEADER_WIDTH = new float[] {0.15f, 0.7f, 0.12f};
        private readonly Queue<int> columnIndexQueue = new Queue<int>();
        private readonly int SORT_MEMORY_COUNT = 8;
       
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

        #region public ShouldBeOnStockListView(Store store)

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов, хранящихся на складе
        /// </summary>
        /// <param name="store">Текущий склад</param>
        public ShouldBeOnStockListView(Store store)
        {
            currentStore = store;
            selectedItemsList = new List<StockDetailInfo>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            UpdateItems();
        }

        #endregion

        #region public ShouldBeOnStockListView(Operator op)

        /// <summary>
        /// Создает элемент управления отображающий список агрегатов, хранящихся на всех складах
        /// </summary>
        /// <param name="op">Текущий эксплуатант</param>
        public ShouldBeOnStockListView(Operator op)
        {
            currentOperator = op;
            selectedItemsList = new List<StockDetailInfo>();
            ItemsListView.ColumnClick += ItemsListView_ColumnClick;
            ItemsListView.MouseDoubleClick += ItemsListView_MouseDoubleClick;
            ItemsListView.SelectedIndexChanged += ItemsListView_SelectedIndexChanged;
            ItemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            DisplayerRequested += ComponentStatusListView_DisplayerRequested;
            oldColumnIndex = 0;
            columnIndexQueue.Enqueue(0);
            ShowGroups = true;
            SetHeaders();
            UpdateItems();
        }

        #endregion


        #endregion

        #region Properties

        #region public StockDetailInfo SelectedItem

        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public override StockDetailInfo SelectedItem
        {
            get
            {
                if (ItemsListView.SelectedItems.Count == 1)
                    return (ItemsListView.SelectedItems[0].Tag as StockDetailInfo);
                return null;
            }
        }
        #endregion

        #region public override List<StockDetailInfo>  SelectedItems
        /// <summary>
        /// Свойство возвращает массив выбранных элементов
        /// </summary>
        public override List<StockDetailInfo> SelectedItems
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
            if (currentStore != null)
                AddItems(currentStore.StockDetailInfos);
            else
            {
                List<StockDetailInfo> items = new List<StockDetailInfo>();
                for (int i = 0; i < currentOperator.Stores.Count; i++)
                    items.AddRange(currentOperator.Stores[i].StockDetailInfos);
                AddItems(items.ToArray());
            }
            SetTotalText();
        }

        #endregion

        #region protected override void AddItems(StockDetailInfo[] itemsArray)

        /// <summary>
        /// Добавляет элементы <see cref="Detail"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(StockDetailInfo[] itemsArray)
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

        #region protected override void AddItem(StockDetailInfo item)
        /// <summary>
        /// Добавляет элемент с указанием группы в которой он находится
        /// </summary>
        /// <param name="item">Добавляемый элемент</param>
        protected override ListViewItem AddItem(StockDetailInfo item)
        {
            string[] itemsString = GetItemString(item);
            ListViewItem listViewItem = new ListViewItem(itemsString);
            if (item.Current < item.Amount)
                listViewItem.BackColor = Css.ListView.Colors.NotSatisfactoryColor;
            listViewItem.Tag = item;
            ItemsHash.Add(item,listViewItem);
            ListViewItemList.Add(listViewItem);
            return listViewItem;
        }
        #endregion

        #region public override void EditItem(StockDetailInfo oldItem, StockDetailInfo modifiedItem)

        public override void EditItem(StockDetailInfo oldItem, StockDetailInfo modifiedItem)
        {
            string[] itemsString = GetItemString(modifiedItem);
            StockDetailInfo detail = GetDetailReferenceByDetailID(oldItem.ID);
            if (detail == null) return;
            ListViewItem listViewItem = ItemsHash[detail];
            listViewItem.SubItems.Clear();
            listViewItem.Text = itemsString[0];
            for (int i = 1; i < itemsString.Length; i++ )
                listViewItem.SubItems.Add(itemsString[i]);
            if (modifiedItem.Current < modifiedItem.Amount)
                listViewItem.BackColor = Css.ListView.Colors.NotSatisfactoryColor;
            listViewItem.Tag = modifiedItem;
            ItemsHash.Remove(oldItem);
            ItemsHash.Add(modifiedItem,listViewItem);
            ItemsListView.Refresh();
            SetTotalText();
        }

        #endregion

        #region private static string[] GetItemString(StockDetailInfo item)

        private static string[] GetItemString(StockDetailInfo item)
        {
            return new string[]
                {item.PartNumber, item.Description, item.Current + " / " + item.Amount};
        }

        #endregion
        
        #region private StockDetailInfo GetDetailReferenceByDetailID(int id)

        private StockDetailInfo GetDetailReferenceByDetailID(int id)
        {
            StockDetailInfo[] stockDetailInfos = GetItemsArray();
            for (int i = 0; i < stockDetailInfos.Length; i++)
            {
                if (stockDetailInfos[i].ID == id)
                    return stockDetailInfos[i];
            }
            return null;
        }

        #endregion

        #region public override StockDetailInfo[] GetItemsArray()

        /// <summary>
        /// Метод возвращает массив агрегатов
        /// </summary>
        /// <returns>Массив агрегатов</returns>
        public override StockDetailInfo[] GetItemsArray()
        {
            int count = ListViewItemList.Count;
            StockDetailInfo[] returnDetailArray = new StockDetailInfo[0];
            if (count > 0)
            {
                returnDetailArray = new StockDetailInfo[count];
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray[i] = (StockDetailInfo)ListViewItemList[i].Tag;
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
            columnHeader.Text = "Part Number";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Description";
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(ItemsListView.Width * HEADER_WIDTH[2]);
            columnHeader.Text = "Amount";
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

            ListViewItemList.Sort(new ListViewItemsComparer(columnIndex, sortMultiplier));

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
                StockDetailInfoForm form = new StockDetailInfoForm(SelectedItem);
                form.ShowDialog();
            }
        }

        #endregion

        #region private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ComponentStatusListView_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
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
