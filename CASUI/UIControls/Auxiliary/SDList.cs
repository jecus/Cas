using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс для отображения listview
    /// </summary>
    /// <typeparam name="T">Тип отображаемых элементов</typeparam>
    public abstract class SDList<T> : Panel
    {

        #region Fields
        protected List<T> selectedItemsList;
        private ListView itemsListView;
        private List<ListViewItem> listViewItemList = new List<ListViewItem>();
        private Dictionary<T, ListViewItem> itemsHash = new Dictionary<T, ListViewItem>();
        private List<ColumnHeader> columnHeaderList = new List<ColumnHeader>();
        protected int oldColumnIndex = 0;
        protected int sortMultiplier = 1;
        
        private Panel panelBottomContainer;
        private Label labelTotal;
        private QuickSearchControl quickSearchControl;
        private readonly string quickSearchDefaultText = "Quick Search";
        private bool clearSearch = false;
        //private int searchStartIndex = 0;

        #endregion

        #region Constructor

        #region public SDList()
        /// <summary>
        /// Создает элемент управления отображающий listview
        /// </summary>
        public SDList()
        {
            Initialize();
        }
        #endregion

        #endregion

        #region Properties

        #region public bool ShowGroups
        /// <summary>
        /// Нужно ли показывать группы
        /// </summary>
        public bool ShowGroups
        {
            get { return itemsListView.ShowGroups; }
            set { itemsListView.ShowGroups = value; }
        }
        #endregion

        #region public T[] SelectedItems
        /// <summary>
        /// Возвращает выбранные элементы
        /// </summary>
        public abstract List<T> SelectedItems
        {
            get;
        }
        #endregion

        #region public T SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public abstract T SelectedItem { get; }
        #endregion

        #region public int TotalItems
        /// <summary>
        /// Возвращает общее количество элементов
        /// </summary>
        public int TotalItems
        {
            get
            {
                return ListViewItemList.Count;
            }
        }
        #endregion

        #region protected  List<ListViewItem> ListViewItemList
        /// <summary>
        /// Список элементов управления массива
        /// </summary>
        protected List<ListViewItem> ListViewItemList
        {
            get { return listViewItemList; }
            set { listViewItemList = value; }
        }
        #endregion

        #region public bool Scrollable
        /// <summary>
        /// Устанавливает / возвращает использовать ли скролл в списке
        /// </summary>
        public bool Scrollable
        {
            get { return itemsListView.Scrollable; }
            set { itemsListView.Scrollable = value; }
        }
        #endregion

        #region public ListView ItemsListView
        /// <summary>
        /// Возвращает ListView
        /// </summary>
        public ListView ItemsListView
        {
            get { return itemsListView; }
            set { itemsListView = value; }
        }
        #endregion

        #region protected List<ColumnHeader> ColumnHeaderList
        /// <summary>
        /// Возвращает список заголовков
        /// </summary>
        protected List<ColumnHeader> ColumnHeaderList
        {
            get { return columnHeaderList; }
            set { columnHeaderList = value; }
        }
        #endregion

        #region protected SortedList<T, ListViewItem> ItemsHash
        protected Dictionary<T, ListViewItem> ItemsHash
        {
            get { return itemsHash; }
        }
        #endregion

        #region protected Panel BottomPanel

        /// <summary>
        /// Возвращает нижнюю панель
        /// </summary>
        protected Panel BottomPanel
        {
            get
            {
                return panelBottomContainer;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public abstract void UpdateItems();

        /// <summary>
        /// Обновляет элементы ListView
        /// </summary>
        public abstract void UpdateItems();

        #endregion
        
        #region private void Initialize()
        private void Initialize()
        {
            selectedItemsList = new List<T>();
            itemsListView = new ListView();
            labelTotal = new Label();
            quickSearchControl = new QuickSearchControl();
            panelBottomContainer = new Panel();
            //
            // itemsListView
            //
            //itemsListView.BackColor = Css.CommonAppearance.Colors.BackColor;
            itemsListView.Dock = DockStyle.Fill;
            itemsListView.View = View.Details;
            itemsListView.ItemSelectionChanged += itemsListView_ItemSelectionChanged;
            itemsListView.PreviewKeyDown += ItemsListView_PreviewKeyDown;
            itemsListView.KeyPress += ItemsListView_KeyPress;
            itemsListView.MouseClick += itemsListView_MouseClick;
            Css.ListView.Adjust(itemsListView);
            itemsListView.FullRowSelect = true;
            //
            // labelTotal
            //
            labelTotal.AutoSize = true;
            labelTotal.Font = Css.SmallHeader.Fonts.RegularFont;
            labelTotal.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelTotal.Dock = DockStyle.Right;
            labelTotal.Padding = new Padding(0, 5, 25, 0);
            labelTotal.Text = "Total: ";
            //
            // quickSearchControl
            //
            quickSearchControl.Text = quickSearchDefaultText;
            //
            // panelBottomContainer
            //
            panelBottomContainer.Dock = DockStyle.Bottom;
            panelBottomContainer.BackColor = Css.CommonAppearance.Colors.BackColor;
            panelBottomContainer.Size = new Size(Width, 25);
            panelBottomContainer.Controls.Add(labelTotal);
            panelBottomContainer.Controls.Add(quickSearchControl);
            
            Controls.Add(itemsListView);
            Controls.Add(panelBottomContainer);
        }

        #endregion

        #region public bool Contains(T item)
        /// <summary>
        /// Содержит ли список данный элемент
        /// </summary>
        /// <param name="item">элемент</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return ItemsHash.ContainsKey(item);
        }

        #endregion

        #region protected virtual void AddGroup(string groupName)
        /// <summary>
        /// Добавляет группу в listview
        /// </summary>
        /// <param name="groupName">Имя группы</param>
        protected virtual void AddGroup(string groupName)
        {
            ListViewGroup listViewGroup = new ListViewGroup(groupName);
            listViewGroup.Header = groupName;
            listViewGroup.Name = groupName;
            itemsListView.Groups.Add(listViewGroup);
        }
        #endregion

        #region protected abstract ListViewItem AddItem(T item);

        /// <summary>
        /// Добавляет элемент 
        /// </summary>
        /// <param name="item"></param>
        protected abstract ListViewItem AddItem(T item);
        
        #endregion

        #region public virtual void AddNewItem(T item)

        /// <summary>
        /// Добавляет новый элемент в список
        /// </summary>
        /// <param name="item"></param>
        public virtual void AddNewItem(T item)
        {
            selectedItemsList.Clear();
            sortMultiplier = -1;
            //itemsListView.Items.Add(AddItem(item));
            AddItem(item);
            Sort();
            SetTotalText();
        }

        #endregion

        #region public virtual void EditItem(T oldItem, T modifiedItem)
        /// <summary>
        /// Изменяет элемент
        /// </summary>
        /// <param name="oldItem">Элемент до измения</param>
        /// <param name="modifiedItem">Измененный элемент</param>
        public virtual void EditItem(T oldItem, T modifiedItem)
        {
        }
        #endregion

        #region public virtual void DeleteItem(T item)

        /// <summary>
        /// Удаляет элемент
        /// </summary>
        /// <param name="item"></param>
        public virtual void DeleteItem(T item)
        {
            if (Contains(item))
            {
                ItemsListView.Items.Remove(ItemsHash[item]);
                listViewItemList.Remove(ItemsHash[item]);
                ItemsHash.Remove(item);
                SetTotalText();
                itemsListView.Refresh();
            }
        }
        #endregion

        #region protected virtual void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected virtual void SetHeaders()
        {
        }
        #endregion

        #region protected abstract void Sort();

        /// <summary>
        /// Происходит сортировка списка
        /// </summary>
        protected abstract void Sort();

        #endregion

        #region public virtual void SetItemsArray(T[] itemsArray)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="itemsArray">Массив элементов</param>
        public virtual void SetItemsArray(T[] itemsArray)
        {
            if (itemsArray == null) 
                throw new ArgumentNullException("itemsArray", "itemsArray can't be null");
            itemsListView.Clear();
            ItemsHash.Clear();
            ListViewItemList.Clear();
            ColumnHeaderList.Clear();
            ItemsListView.Items.Clear();
            //ItemsListView.Groups.Clear();
            selectedItemsList = new List<T>();
            SetHeaders();

            AddItems(itemsArray);
            SetTotalText();
        }
        #endregion

        #region protected abstract void AddItems(T[] itemsArray);

        /// <summary>
        /// Добавляет элементы <see cref="T"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected abstract void AddItems(T[] itemsArray);

        #endregion

        #region protected virtual void SetTotalText()

        /// <summary>
        /// Устанавивает информацию об общем количестве элементов в нижней панели
        /// </summary>
        protected virtual void SetTotalText()
        {
            labelTotal.Text = "Total: " + TotalItems;
        }

        #endregion
        
        #region public virtual T[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив элементов
        /// </summary>
        /// <returns></returns>
        public virtual T[] GetItemsArray()
        {
            return new T[] {};
        }
        #endregion

        #region protected void OnItemDoubleClick()
        protected void OnItemDoubleClick()
        {
            if (ItemDoubleClick!=null) ItemDoubleClick(this,new ItemDoubleClickEventArgs<T>(SelectedItem));
        }
        #endregion

        #region private void itemsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void itemsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            T item = (T)e.Item.Tag;
            if (e.IsSelected)
            {
                selectedItemsList.Add(item);
            }
            else
            {
                if (selectedItemsList.Contains(item)) selectedItemsList.Remove(item);
            }
        }

        #endregion

        #region private void ClearSelectedItems()

        private void ClearSelectedItems()
        {
            ItemsListView.SelectedItems.Clear();
            selectedItemsList.Clear();
        }

        #endregion


        #region private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void ItemsListView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F3)
                ItemsListView_KeyPress(sender, new KeyPressEventArgs((char)255));
            else if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
                for (int i = 0; i < ItemsListView.Items.Count; i++)
                    ItemsListView.Items[i].Selected = true;
            }
            else if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                if (SelectedItems.Count != 0)
                {
                    List<object> contents = new List<object>();
                    for (int i = 0; i < SelectedItems.Count; i++ )
                        contents.Add(SelectedItems[i]);
                    CASClipboard.Instance.CopyToClipboard(contents);
                }
            }
            else if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                if (ItemsPasted != null && CASClipboard.Instance.Contents.Count > 0 && CASClipboard.Instance.Contains(typeof(T)))
                {
                    List<T> contents = new List<T>();
                    for (int i = 0; i < CASClipboard.Instance.Contents.Count; i++ )
                    {
                        if (CASClipboard.Instance.Contents[i] is T)
                            contents.Add((T)CASClipboard.Instance.Contents[i]);
                    }
                    if (contents.Count > 0)
                        ItemsPasted(contents);
                    ClearSelectedItems();
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (ItemsDeleted != null)
                    ItemsDeleted(this, EventArgs.Empty);
            }
        }

        #endregion

        #region private void ItemsListView_KeyPress(object sender, KeyPressEventArgs e)

        private void ItemsListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (quickSearchControl.Text == quickSearchDefaultText || clearSearch)
                {
                    quickSearchControl.Text = "";
                    clearSearch = false;
                }
                if (quickSearchControl.Text.Length > 0)
                {
                    quickSearchControl.Text = quickSearchControl.Text.Substring(0, quickSearchControl.Text.Length - 1);
                    if (quickSearchControl.Text != "")
                        SearchItem(quickSearchControl.Text);
                }
            }
            else if (e.KeyChar == 27)
            {
                quickSearchControl.Text = quickSearchDefaultText;
                quickSearchControl.SuccessBackgroundColor = true;
            }
            if (e.KeyChar < 32 || e.KeyChar > 126)
            {
               // e.Handled = true;
                return;
            }
            if (quickSearchControl.Text == quickSearchDefaultText || clearSearch)
            {
                quickSearchControl.Text = "";
                clearSearch = false;
            }
            quickSearchControl.Text += e.KeyChar;
            SearchItem(quickSearchControl.Text);
          //  e.Handled = true;
        }

        #endregion

        #region private void itemsListView_MouseClick(object sender, MouseEventArgs e)

        private void itemsListView_MouseClick(object sender, MouseEventArgs e)
        {
            clearSearch = true;
        }

        #endregion

/*        #region private void SearchItem(string stringToSearch, int startIndex)

        private void SearchItem(string stringToSearch, int startIndex)
        {
            ItemsListView.SelectedItems.Clear();
            if (searchStartIndex > ItemsListView.Items.Count - 1)
                return;
            ListViewItem item = ItemsListView.FindItemWithText(stringToSearch, true, startIndex);
            if (item != null)
            {
                item.Selected = true;
                ItemsListView.Focus();
                item.EnsureVisible();
                searchStartIndex = ItemsListView.Items.IndexOf(item) + 1;
                quickSearchControl.SuccessBackgroundColor = true;
            }
            else
            {
                quickSearchControl.SuccessBackgroundColor = false;
            }
        }

        #endregion*/ //todo backup

        #region private void SearchItem(string stringToSearch)

        private void SearchItem(string stringToSearch)
        {
            int searchStartIndex = 0;
            ClearSelectedItems();
            ItemsListView.SelectedItems.Clear();
            List<ListViewItem> findItems = new List<ListViewItem>();
            ListViewItem item = ItemsListView.FindItemWithText(stringToSearch, true, searchStartIndex);
            while (item != null && searchStartIndex < ItemsListView.Items.Count)
            {
                item.Selected = true;
                findItems.Add(item);
                searchStartIndex = ItemsListView.Items.IndexOf(item) + 1;
                if (searchStartIndex >= ItemsListView.Items.Count)
                    break;
                item = ItemsListView.FindItemWithText(stringToSearch, true, searchStartIndex);
            }
            if (findItems.Count > 0)
            {
                ItemsListView.Focus();
                findItems[0].EnsureVisible();
                quickSearchControl.SuccessBackgroundColor = true;
            }
            else
                quickSearchControl.SuccessBackgroundColor = false;
        }

        #endregion

        #region protected void OnSelectedItemsChange(object sender, SelectedItemsChangeEventArgs args)

        protected void OnSelectedItemsChange(object sender, SelectedItemsChangeEventArgs args)
        {
            if (SelectedItemsChanged != null) SelectedItemsChanged(sender, args);
        }

        #endregion
        
        #endregion

        #region Events

        #region public event EventHandler<ItemDoubleClickEventArgs<T>> ItemDoubleClick;

        /// <summary>
        /// Событие возникающее при двойном щелчку мыши по элементу SDList
        /// </summary>
        public event EventHandler<ItemDoubleClickEventArgs<T>> ItemDoubleClick;

        #endregion
        
        #region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #region public event ItemPastedEventHandler ItemsPasted;

        /// <summary>
        /// Событие возникающее при вставке элементов из буфера обмена
        /// </summary>
        public event ItemPastedEventHandler ItemsPasted;

        /// <summary>
        /// Обработчик события <see cref="ItemsPasted"/>
        /// </summary>
        /// <param name="pastedItems"></param>
        public delegate void ItemPastedEventHandler(List<T> pastedItems);

        #endregion

        #region public event EventHandler ItemsDeleted;

        /// <summary>
        /// Событие возникающее при нажатии клавиши DEL в списке
        /// </summary>
        public event EventHandler ItemsDeleted;

        #endregion
        
        #endregion

    }
}
