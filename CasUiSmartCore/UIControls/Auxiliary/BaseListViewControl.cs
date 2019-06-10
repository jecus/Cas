using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// ЭУ для предствления списков объектов определенного типа, унаследованных от <see cref="IBaseCoreObject"/>
    ///</summary>
    [Designer(typeof(BaseListViewControlDesigner))]
    public partial class BaseListViewControl<T> : UserControl, IReference where T : class, IBaseCoreObject
    {
        #region Fields
        
        private bool _clearSearch;
        //коллекция выделенных элементов
        private readonly List<T> _selectedItemsList = new List<T>();
        //заголовки списка
        protected readonly List<ColumnHeader> ColumnHeaderList = new List<ColumnHeader>();
        //номер последней колонки, по которой производилась сортировка
        protected int OldColumnIndex;
        ///<summary>
        ///направление сортировки списка
        ///</summary>
        protected int SortMultiplier = -1;
        ///<summary>
        ///предварительный список элементов ListView
        ///</summary>
        public List<ListViewItem> ListViewItemList = new List<ListViewItem>();
        
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

        #region public List<T> SelectedItems
        /// <summary>
        /// Возвращает выбранные элементы
        /// </summary>
        public List<T> SelectedItems
        {
            get
            {
                if (_selectedItemsList == null)
                    return null;

                _selectedItemsList.Clear();
                _selectedItemsList.AddRange(itemsListView.SelectedItems
                                                .Cast<ListViewItem>()
                                                .Where(i => i.Tag != null && i.Tag is T)
                                                .Select(i => i.Tag as T)
                                                .ToArray());
                return _selectedItemsList;
            }
        }
        #endregion

        #region public T SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public T SelectedItem
        {
            get
            {
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as T);
                return null;
            }
        }
        #endregion

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        #endregion

        #region public string DisplayerText { get; set;}
        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }
        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        #endregion

        #region public ListView ItemListView
        ///<summary>
        /// возвращает ListView 
        ///</summary>
        public ListView ItemListView
        {
            get { return itemsListView; }
        }
		#endregion

		#region public bool IgnoreAutoResize { get; set; }

		public bool IgnoreAutoResize { get; set; }

	    #endregion

        #endregion
       
        #region Constructors

        #region public BaseListViewControl()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        public BaseListViewControl()
        {
	        InitializeComponent();
			DoubleBuffered = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
			this.DoubleBuffering(true);
        }
        #endregion
       
        #endregion

        #region Methods

        #region public virtual void DisposeView()
        /// <summary>
        /// Очищает ресуры Списка
        /// </summary>
        public virtual void DisposeView()
        {
            _selectedItemsList.Clear();
            //заголовки списка
            ColumnHeaderList.Clear();
            //предварительный список элементов ListView
            ListViewItemList.Clear();

            Dispose(true);
        }
        #endregion

        #region protected virtual List<PropertyInfo> GetTypeProperties()
        /// <summary>
        /// Получает свойства типа, на основе которых будут созданы колонки 
        /// </summary>
        /// <returns></returns>
        protected virtual List<PropertyInfo> GetTypeProperties()
        {
            //определение типа
            Type type = typeof(T);
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                type.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                ListViewDataAttribute lvda = (ListViewDataAttribute)
                    propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).First();
                if (lvda.Order > 0) orderedProperties.Add(lvda.Order, propertyInfo);
                else unOrderedProperties.Add(propertyInfo);
            }

            var ordered = orderedProperties.OrderBy(p => p.Key).ToList();

            properties.Clear();
            properties.AddRange(ordered.Select(keyValuePair => keyValuePair.Value));
            properties.AddRange(unOrderedProperties);

            return properties;

        }
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
            //очищение предварительной коллекции элементов
            ListViewItemList.Clear();
            //очищение элементов ListViewa
            itemsListView.Items.Clear();
            //очищение коллекции выбранных элементов
            _selectedItemsList.Clear();

            try
            {
                //SetHeaders();
                AddItems(itemsArray);
                SetItemsColor();
                SetTotalText();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while deleting data", ex);
                return;
            }
        }
        #endregion

        #region public virtual T[] GetItemsArray()
        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public virtual T[] GetItemsArray()
        {
            int count = itemsListView.Items.Count;
            List<T> returnDetailArray = new List<T>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    returnDetailArray.Add((T)itemsListView.Items[i].Tag);
                }
            }
            return returnDetailArray.ToArray();
        }
        #endregion

        #region protected virtual void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected virtual void SetHeaders()
        {
            List<PropertyInfo> properties = GetTypeProperties();

            ColumnHeaderList.Clear();
            ColumnHeader columnHeader;
            foreach (PropertyInfo propertyInfo in properties)
            {
                ListViewDataAttribute attr =
                    (ListViewDataAttribute) propertyInfo.GetCustomAttributes(typeof (ListViewDataAttribute), false)[0]; 
                columnHeader = new ColumnHeader();
                columnHeader.Width = attr.HeaderWidth > 1 ? (int)attr.HeaderWidth : (int)(itemsListView.Width * attr.HeaderWidth);
                columnHeader.Text = attr.Title;
                columnHeader.Tag = propertyInfo.PropertyType;
                ColumnHeaderList.Add(columnHeader);    
            }
            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected virtual void AddItems(T[] itemsArray)
        /// <summary>
        /// Добавляет элементы в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected virtual void AddItems(T[] itemsArray)
        {
            if (itemsArray.Length != 0)
            {
                int count = itemsArray.Length;
                for (int i = 0; i < count; i++)
                {
                    AddItem(itemsArray[i]);
                }
                itemsListView.Items.AddRange(ListViewItemList.ToArray());
                ShowGroups = true;
                if (SortMultiplier == 1)
                    SortMultiplier = -1;
                else
                    SortMultiplier = 1;
                SortItems(OldColumnIndex);
            }
        }

        #endregion

        #region public virtual void InsertItems(T[] itemsArray)
        /// <summary>
        /// Добавляет элементы в начало ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        public virtual void InsertItems(T[] itemsArray)
        {
            if (itemsArray.Length == 0) 
                return;
            
            List<ListViewItem> listViewItems = itemsArray.Select(GetItem).ToList();
            
            //SortItems(SortMultiplier, listViewItems);
                
            for (int i = listViewItems.Count - 1; i >= 0; i--)
            {
                //ListViewItemList.Insert(0, listViewItems[i]);
                //itemsListView.Items.Insert(0, listViewItems[i]);
                ListViewItemList.Add(listViewItems[i]);
            }

            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;
            SortItems(OldColumnIndex);

            SetItemsColor(listViewItems);

            SetTotalText();
        }

        #endregion

        #region protected virtual void AddItem(T item)

        /// <summary>
        /// Добавляет элемент в список технических записей (AbstractRecord)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected virtual void AddItem(T item)
        {
            try
            {
                ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(item),null) {Tag = item};
                ListViewItemList.Add(listViewItem);
                return;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log(ex);
            }
            return;
        }
        #endregion

        #region protected virtual ListViewItem.ListViewSubItem[] GetItemsString(T item)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual ListViewItem.ListViewSubItem[] GetListViewSubItems(T item)
        {
            List<PropertyInfo> properties = GetTypeProperties();

            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[properties.Count];
            for (int i = 0; i < properties.Count; i++ )
            {
                object value = properties[i].GetValue(item, null);
                if(value != null)
                {
	                if (properties[i].Name == "CorrectorId")
		                value = GlobalObjects.CasEnvironment.GetCorrector((int) value);

					string valueString;
                    if (value is DateTime)
                        valueString = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
                    else if (value is double)
	                    valueString = ((double)value).ToString("F");
					else valueString = value.ToString();

                                   
                    subItems[i] = new ListViewItem.ListViewSubItem
                                  {
                                      Text = valueString,
                                      Tag = value
                                  };
                }
                else
                {
                    subItems[i] = new ListViewItem.ListViewSubItem
                    {
                        Text = "",
                        Tag = ""
                    };  
                }
            }
            return subItems;
        }

        #endregion

        #region protected virtual ListViewItem GetItem(T item)

        /// <summary>
        /// Возвращает элемент списка
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected virtual ListViewItem GetItem(T item)
        {
            try
            {
                ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(item), null) { Tag = item };
                return listViewItem;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log(ex);
            }
            return null;
        }
        #endregion

        #region protected virtual void SetTotalText()
        /// <summary>
        /// Устанавивает информацию об общем количестве элементов в нижней панели
        /// </summary>
        protected virtual void SetTotalText()
        {
            labelTotal.Text = "Total: " + itemsListView.Items.Count;
        }

        #endregion

        #region protected virtual void SortItems(int columnIndex)
        protected virtual void SortItems(int columnIndex)
        {
            if (OldColumnIndex != columnIndex)
                SortMultiplier = -1;
            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;
            itemsListView.Items.Clear();
            SetGroupsToItems(columnIndex);
            ListViewItemList.Sort(new BaseListViewComparer(columnIndex,SortMultiplier));
            itemsListView.Items.AddRange(ListViewItemList.ToArray());
            OldColumnIndex = columnIndex;
            SetItemsColor();
            //ChangeSize();
        }
        #endregion

        #region protected virtual void ListViewItem[]  SortItems(int columnIndex, List<ListViewItem> items)
        protected virtual void SortItems(int columnIndex, List<ListViewItem> items)
        {
            if (OldColumnIndex != columnIndex)
                SortMultiplier = -1;
            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;

            SetGroupsToItems(items, columnIndex);
            
            items.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

            //ChangeSize();
        }
		#endregion

		#region protected virtual void SetGroupsToItems(int columnIndex)
		/// <summary>
		/// Выполняет группировку элементов
		/// </summary>
		protected virtual void SetGroupsToItems(int columnIndex)
        {
            
        }
        #endregion

        #region protected virtual void SetGroupsToItems(List<ListViewItem> listViewItems))
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected virtual void SetGroupsToItems(List<ListViewItem> listViewItems, int colunmIndex)
        {

        }
        #endregion

        #region protected void SetItemsColor()
        protected void SetItemsColor()
        {
            foreach (ListViewItem item in itemsListView.Items)
            {
                SetItemColor(item, (T)item.Tag);
            }
        }
        #endregion

        #region private void SetItemsColor(IEnumerable<ListViewItem> listViewItems)
        private void SetItemsColor(IEnumerable<ListViewItem> listViewItems)
        {
            foreach (ListViewItem item in listViewItems)
            {
                SetItemColor(item, (T)item.Tag);
            }
        }
        #endregion

        #region protected virtual void SetItemColor(ListViewItem listViewItem, T item)
        protected virtual void SetItemColor(ListViewItem listViewItem, T item)
        {
            IDirective imd = item as IDirective;
            if (imd == null) return;

            if(imd.NextPerformanceIsBlocked)
            {
                listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                listViewItem.ToolTipText = "This performance is involved on Work Package:" + imd.NextPerformances[0].BlockedByPackage.Title;
            }
            else
            {
                if (imd.Condition == ConditionState.Overdue)
                    listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
                if (imd.Condition == ConditionState.Notify)
                    listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
                if (imd.Condition == ConditionState.NotEstimated)
                    listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);    
            }
        }
        #endregion

        #region public void UpdateItemsColor(IEnumerable<T> items)
        /// <summary>
        /// Обновляет подсветку для переданных элементов
        /// </summary>
        /// <param name="items">Элементы, для которых требуется обновить подсветку</param>
        public void UpdateItemsColor(IEnumerable<T> items)
        {
            List<ListViewItem> lvi =
                items.SelectMany(i => itemsListView.Items.Cast<ListViewItem>()
                                                         .Where(listViewItem => listViewItem.Tag == i))
                     .ToList();

            foreach (ListViewItem item in lvi)
            {
                SetItemColor(item, (T)item.Tag);
            }
        }
        #endregion

        #region public void UpdateItemColor(T item)
        /// <summary>
        /// Обновляет подсветку для переданного элемента
        /// </summary>
        /// <param name="item">Элемент, для которого требуется обновить подсветку</param>
        public void UpdateItemColor(T item)
        {
            List<ListViewItem> lvi =
                itemsListView.Items.Cast<ListViewItem>()
                                   .Where(listViewItem => listViewItem.Tag == item)
                                   .ToList();

            foreach (ListViewItem listViewItem in lvi)
            {
                SetItemColor(listViewItem, (T)listViewItem.Tag);
            }
        }
        #endregion

        #region private void ClearSelectedItems()
        ///<summary>
        /// Функция для очистки выделенных элементов
        ///</summary>
        private void ClearSelectedItems()
        {
            itemsListView.SelectedItems.Clear();
            _selectedItemsList.Clear();
        }

        #endregion

        #region private void SearchItem(string stringToSearch)
        ///<summary>
        /// Функция для поиска подстроки в списке в элементах списка 
        ///</summary>
        private void SearchItem(string stringToSearch)
        {
            int searchStartIndex = 0;
            //очистка выделенных элементов списка
            ClearSelectedItems();
            List<ListViewItem> findItems = new List<ListViewItem>();
            ListViewItem item = itemsListView.FindItemWithText(stringToSearch, true, searchStartIndex);
            while (item != null && searchStartIndex < itemsListView.Items.Count)
            {
                item.Selected = true;
                findItems.Add(item);
                searchStartIndex = itemsListView.Items.IndexOf(item) + 1;
                if (searchStartIndex >= itemsListView.Items.Count)
                    break;
                item = itemsListView.FindItemWithText(stringToSearch, true, searchStartIndex);
            }
            if (findItems.Count > 0)
            {
                itemsListView.Focus();
                findItems[0].EnsureVisible();
                quickSearchControl.SuccessBackgroundColor = true;
            }
            else
                quickSearchControl.SuccessBackgroundColor = false;
        }

        #endregion

        /*
         *  Копировать - Вставить - Вырезать
         */

        #region protected virtual void CopyToClipboard()
        protected virtual void CopyToClipboard()
        {
            // регистрация формата данных либо получаем его, если он уже зарегистрирован
            DataFormats.Format format = DataFormats.GetFormat(typeof(T[]).FullName);
            // копируем в буфер обмена
            IDataObject dataObj = new DataObject();
            dataObj.SetData(format.Name, false, SelectedItems.ToArray());
            Clipboard.SetDataObject(dataObj, false);
        }
        #endregion

        #region
        //protected Document GetFromClipboard()
        //{
        //    Document doc = null;
        //    IDataObject dataObj = Clipboard.GetDataObject();
        //    string format = typeof(Document).FullName;
        //    if (dataObj.GetDataPresent(format))
        //    {
        //        doc = dataObj.GetData(format) as Document;
        //    }
        //    return doc;
        //}
        #endregion

        #region private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
        private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
        {
            _clearSearch = true;
        }
        #endregion

        #region private void ItemsListViewKeyPress(object sender, KeyPressEventArgs e)
        private void ItemsListViewKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                if (quickSearchControl.Text == "Quick Search" || _clearSearch)
                {
                    quickSearchControl.Text = "";
                    _clearSearch = false;
                }
                if (quickSearchControl.Text.Length > 0)
                {
                    quickSearchControl.Text = quickSearchControl.Text.Substring(0, quickSearchControl.Text.Length - 1);
                    if (quickSearchControl.Text != "")
                        SearchItem(quickSearchControl.Text);
                    return;
                }
            }
            else if (e.KeyChar == 27)
            {
                quickSearchControl.Text = "Quick Search";
                quickSearchControl.SuccessBackgroundColor = true;
            }
            //else if (e.KeyChar < 32 || e.KeyChar > 126)
            //{
            //    // e.Handled = true;
            //    return;
            //}

            if (quickSearchControl.Text == "Quick Search" || _clearSearch)
            {
                quickSearchControl.Text = "";
                _clearSearch = false;
            }

            quickSearchControl.Text += e.KeyChar;
            SearchItem(quickSearchControl.Text);
            return;
        }
        #endregion

        #region private void ItemsListViewColumnClick(object sender, ColumnClickEventArgs e)
        private void ItemsListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            SortItems(e.Column);
            SetItemsColor();
        }
        #endregion

        #region private void ItemsListViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void ItemsListViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        #region protected virtual void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        /// <summary>
        /// Реагирует на двойной щелчок в списке элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnDisplayerRequested();
        }
        #endregion

        #region private void ItemsListViewSelectedIndexChanged(object sender, EventArgs e)
        private void ItemsListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemsChanged != null)
                SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(_selectedItemsList.Count));
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
			if(IgnoreAutoResize)
				return;
            //определение своиств типа
            List<PropertyInfo> preProrerty = GetTypeProperties();
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                preProrerty.Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();
            for (int i = 0; i < ColumnHeaderList.Count; i++)
            {
                if (i >= properties.Count)
                {
                    ColumnHeaderList[i].Width = (int)(itemsListView.Width * 0.1f);
                    continue;
                }
                ListViewDataAttribute attr =
                    (ListViewDataAttribute)properties[i].GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];
                ColumnHeaderList[i].Width = attr.HeaderWidth > 1
                                         ? (int)attr.HeaderWidth
                                         : (int)(itemsListView.Width * attr.HeaderWidth);
            }
        }
        #endregion

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// Метод, возбуждающий событие DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = ReflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) 
                    reflection = ReflectionTypes.DisplayInNew;
                ReferenceEventArgs e;
                if (null != Displayer)
                {
                    e = new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText);
                }
                else
                {
                    e = new ReferenceEventArgs(Entity, reflection, DisplayerText);
                }

	            try
	            {
		            FillDisplayerRequestedParams(e);
		            DisplayerRequested(this, e);
	            }
	            catch (Exception ex)
	            {
		            Program.Provider.Logger.Log("Error while opening record",ex);
	            }
            }
        }

		#endregion

	    public void UpdateHeader()
	    {
		    try
		    {
			    //this.Load -= BaseListViewControlLoad;
				SetHeaders();
		    }
		    catch (Exception ex)
		    {
			    Program.Provider.Logger.Log("Error while building control", ex);
			    return;
		    }
		}

		#region private void BaseListViewControlLoad(object sender, EventArgs e)
		private void BaseListViewControlLoad(object sender, EventArgs e)
        {
            try
            {
                SetHeaders();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building control", ex);
                return;
            }
        }
        #endregion

        #region protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
        }
        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Событие, воздуждаемое при необходимости отобразть что-то в новой/текущей вкладке  
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        /// <summary>
        /// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
        /// </summary>
        public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
        #endregion

        #endregion
    }

    internal class BaseListViewControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("SelectedItem");
            properties.Remove("SelectedItems");
        }
    }
}
