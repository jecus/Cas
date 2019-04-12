using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// ЭУ для предствления списков объектов определенного типа, унаследованных от <see cref="BaseEntityObject"/>
    ///</summary>
    [Designer(typeof(CommonListViewControlDesigner))]
    public partial class CommonListViewControl : UserControl, IReference
    {
        #region Fields
        /// <summary>
        /// Тип, объекты которого будут отображаться в списке
        /// </summary>
        private Type _viewedType;
        /// <summary>
        /// Своиство типа, по которому нужно произвести первичную группировку
        /// </summary>
        private PropertyInfo _beginGroup;

        private bool _clearSearch;
        //коллекция выделенных элементов
        protected ICommonCollection _selectedItemsList;
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

        #region public Type ViewedType
        /// <summary>
        /// Тип, объекты которого будут отображаться в списке
        /// </summary>
        public Type ViewedType
        {
            get { return _viewedType; }
            set
            {
                #region Проверка типа
                if (value == null)
                    throw new ArgumentNullException("value", "type must be not null");
                //Проверка, является ли переданный тип наследником BaseSmartCoreObject
                if (!value.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    //цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
                    //значит переданный тип не является его наследником
                    throw new ArgumentNullException("value", "not inherit from " + typeof(BaseEntityObject).Name);
                }
                #endregion

                _viewedType = value;

                try
                {
                    if (_selectedItemsList != null) _selectedItemsList.Clear();
                    Type genericType = typeof(CommonCollection<>);
                    Type genericList = genericType.MakeGenericType(_viewedType);
                    _selectedItemsList = (ICommonCollection)Activator.CreateInstance(genericList);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while building collection", ex);
                    return;
                }

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
        }
        #endregion

        #region public ICommonCollection SelectedItems
        /// <summary>
        /// Возвращает выбранные элементы
        /// </summary>
        public ICommonCollection SelectedItems
        {
            get
            {
                if (_selectedItemsList == null)
                    return null;

                _selectedItemsList.Clear();
                _selectedItemsList.AddRange(itemsListView.SelectedItems
                                                .Cast<ListViewItem>()
                                                .Where(i => i.Tag != null && i.Tag is BaseEntityObject)
                                                .Select(i => i.Tag as BaseEntityObject)
                                                .ToArray());
                return _selectedItemsList;
            }
        }
        #endregion

        #region public BaseSmartCoreObject SelectedItem
        /// <summary>
        /// Выбранный элемент
        /// </summary>
        public BaseEntityObject SelectedItem
        {
            get
            {
                if (itemsListView.SelectedItems.Count == 1)
                    return (itemsListView.SelectedItems[0].Tag as BaseEntityObject);
                return null;
            }
        }
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

        #region Implement of IReference

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
        
        #endregion

        #endregion

        #region Constructors

        #region public CommonListViewControl()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        public CommonListViewControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public CommonListViewControl(PropertyInfo beginGroup) : this()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        ///<param name="beginGroup">Задает своиство класса, по которому нужно сделать первичную группировку</param>
        public CommonListViewControl(PropertyInfo beginGroup) : this()
        {
            _beginGroup = beginGroup;
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
            if(_selectedItemsList != null)
                _selectedItemsList.Clear();
            //заголовки списка
            ColumnHeaderList.Clear();
            //предварительный список элементов ListView
            ListViewItemList.Clear();

            Dispose(true);
        }
        #endregion

        #region protected virtual List<PropertyInfo> GetTypeProperties()
        protected virtual List<PropertyInfo> GetTypeProperties()
        {
            if (_viewedType == null) 
                throw new NullReferenceException("_viewedType is null");
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                _viewedType.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                ListViewDataAttribute lvda = (ListViewDataAttribute)
                    propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).FirstOrDefault();
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

        #region public virtual void SetItemsArray(ICommonCollection  itemsArray)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="itemsArray">Массив элементов</param>
        public virtual void SetItemsArray(ICommonCollection itemsArray)
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
                CreateItems(itemsArray);
                SetItemsColor();
                SetTotalText();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
            }
        }
        #endregion

        #region public virtual void SetItemsArray(IEnumerable<BaseEntityObject>  itemsArray)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="itemsArray">Массив элементов</param>
        public virtual void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (itemsArray == null)
                throw new ArgumentNullException("itemsArray", "itemsArray can't be null");
            //очищение предварительной коллекции элементов
            ListViewItemList.Clear();
            //очищение элементов ListViewa
            itemsListView.Items.Clear();
            //очищение коллекции выбранных элементов
            try
            {
                CreateItems(itemsArray);
                SetItemsColor();
                SetTotalText();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
            }
        }
        #endregion

        #region public virtual void InsertItems(ICommonCollection itemsArray)
        /// <summary>
        /// Добавляет элементы в начало ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        public virtual void InsertItems(ICommonCollection itemsArray)
        {
            if (itemsArray.Count == 0)
                return;

            List<ListViewItem> listViewItems = itemsArray.Cast<BaseEntityObject>().Select(GetItemforInserting).ToList();

            for (int i = listViewItems.Count - 1; i >= 0; i--)
            {
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

        #region public virtual void AddItem(BaseEntityObject item)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="item">Массив элементов</param>
        public virtual void AddItem(BaseEntityObject item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "itemsArray can't be null");
            try
            {
                ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(item), null) { Tag = item };
                ListViewItemList.Add(listViewItem);
                ListViewItemList.Sort(new BaseListViewComparer(OldColumnIndex, SortMultiplier));

                SetGroupsToItems();
                SetItemColor(listViewItem, item);
                SetTotalText();

                itemsListView.Items.Insert(ListViewItemList.IndexOf(listViewItem), listViewItem);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
            }
        }
        #endregion

        #region public virtual ICommonCollection GetItemsArray()
        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public virtual ICommonCollection GetItemsArray()
        {
            try
            {
                int count = itemsListView.Items.Count;
                Type genericType = typeof(CommonCollection<>);
                Type genericList = genericType.MakeGenericType(_viewedType);
                ICommonCollection returnDetailArray = (ICommonCollection)Activator.CreateInstance(genericList);
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        returnDetailArray.Add(itemsListView.Items[i].Tag as BaseEntityObject);
                    }
                }
                return returnDetailArray;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building collection", ex);
                return null;
            }
        }
        #endregion

        #region protected virtual void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected virtual void SetHeaders()
        {
            ColumnHeaderList.Clear();

            try
            {
                List<PropertyInfo> properties = GetTypeProperties();
                ColumnHeader columnHeader;
                foreach (PropertyInfo propertyInfo in properties)
                {
                    ListViewDataAttribute attr =
                        (ListViewDataAttribute)propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];
                    columnHeader = new ColumnHeader();
                    columnHeader.Width = attr.HeaderWidth > 1 ? (int)attr.HeaderWidth : (int)(itemsListView.Width * attr.HeaderWidth);
                    columnHeader.Text = attr.Title;
                    columnHeader.Tag = propertyInfo.PropertyType;
                    ColumnHeaderList.Add(columnHeader);
                }
                itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
                return;
            }
        }
        #endregion

        #region protected virtual void CreateItems(ICommonCollection itemsArray)
        /// <summary>
        /// Добавляет элементы <see cref="_viewedType"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected virtual void CreateItems(ICommonCollection itemsArray)
        {
            if (itemsArray.Count != 0)
            {
                foreach (BaseEntityObject o in itemsArray)
                {
                    CreateItem(o);
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

        #region protected virtual void CreateItems(IEnumerable<BaseEntityObject> itemsArray)
        /// <summary>
        /// Добавляет элементы <see cref="_viewedType"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected virtual void CreateItems(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (itemsArray.Count() != 0)
            {
                foreach (BaseEntityObject o in itemsArray)
                {
                    CreateItem(o);
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

        #region protected void CreateItem(BaseSmartCoreObject item)

        /// <summary>
        /// Добавляет элемент в список технических записей (AbstractRecord)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected void CreateItem(BaseEntityObject item)
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

        #region protected virtual ListViewItem GetItemforInserting(BaseEntityObject item)

        /// <summary>
        /// Возвращает элемент списка
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected virtual ListViewItem GetItemforInserting(BaseEntityObject item)
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

        #region public virtual void RemoveItem(BaseEntityObject item)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="item">Массив элементов</param>
        public virtual void RemoveItem(BaseEntityObject item)
        {
            if (item == null)
                throw new ArgumentNullException("item", "itemsArray can't be null");
            try
            {
                ListViewItem listViewItem = itemsListView.Items.OfType<ListViewItem>()
                    .FirstOrDefault(i => i.Tag is BaseEntityObject
                                         && ((BaseEntityObject) i.Tag).ItemId == item.ItemId
                                         && ((BaseEntityObject) i.Tag).SmartCoreObjectType.Equals(item.SmartCoreObjectType));

                if (listViewItem != null)
                {
                    ListViewItemList.Remove(listViewItem);
                    itemsListView.Items.Remove(listViewItem);    
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
            }
        }
        #endregion

        #region protected virtual ListViewItem.ListViewSubItem[] GetItemsString(BaseSmartCoreObject item)

        protected virtual ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
            List<PropertyInfo> properties = GetTypeProperties();

            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[properties.Count];
            for (int i = 0; i < properties.Count; i++ )
            {
                object value = properties[i].GetValue(item, null);
                if(value != null)
                {
	                if (properties[i].Name == "CorrectorId")
		                value = GlobalObjects.CasEnvironment.GetCorrector((int)value);

					string valueString;
                    if (value is DateTime)
                        valueString = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
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
            SetGroupsToItems();
            ListViewItemList.Sort(new BaseListViewComparer(columnIndex,SortMultiplier));
            itemsListView.Items.AddRange(ListViewItemList.ToArray());
            OldColumnIndex = columnIndex;
            SetItemsColor();
            //ChangeSize();
        }
        #endregion

        #region protected virtual void SetGroupsToItems()
        protected virtual void SetGroupsToItems()
        {
            if(_beginGroup == null || 
               _beginGroup.ReflectedType.Name != _viewedType.Name ||
               _viewedType.GetProperty(_beginGroup.Name) == null)
                return;

            itemsListView.Groups.Clear();
            foreach (ListViewItem item in ListViewItemList)
            {
                String temp;

                if (item.Tag == null) continue;
                BaseEntityObject ob = item.Tag as BaseEntityObject;
                if (ob == null) continue;

                //Извлечение значения
                object value = _beginGroup.GetValue(ob, null);
                //Проверка значения на null
                if (value == null) 
                    continue;
                
                if (value is IDictionaryItem)
                    temp = ((IDictionaryItem)value).FullName;
                else if (value is BaseEntityObject)
                    temp = value.ToString();
                else if (value is IThreshold)
                    temp = value.ToString();
                else if (value is Lifelength)
                    temp = value.ToString();
                else if (value.GetType().IsEnum)
                    temp = EnumHelper.EnumToString((Enum)value);
                else if (value is string)
                    temp = (string)value;  
                else if (value is int)
                    temp = ((int)value).ToString();
                else if (value is short)
                    temp = ((short)value).ToString();
                else if (value is DateTime)
                    temp = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
                else if (value is bool)
                    temp = value.ToString();
                else if (value is double)
                    temp = ((double)value).ToString();
                else
                    temp = "Can't define group";

                itemsListView.Groups.Add(temp, temp);
                item.Group = itemsListView.Groups[temp];
            }
        }
        #endregion

        #region private void SetItemsColor()
        private void SetItemsColor()
        {
            foreach (ListViewItem item in itemsListView.Items)
            {
                SetItemColor(item, (BaseEntityObject)item.Tag);
            }
        }
        #endregion

        #region private void SetItemsColor(IEnumerable<ListViewItem> listViewItems)
        private void SetItemsColor(IEnumerable<ListViewItem> listViewItems)
        {
            foreach (ListViewItem item in listViewItems)
            {
                SetItemColor(item, (BaseEntityObject)item.Tag);
            }
        }
        #endregion

        #region protected virtual void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        protected virtual void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
            IDirective imd = item as IDirective;
            if (imd == null) return;

            if (imd.Condition == ConditionState.Overdue)
                listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
            if (imd.Condition == ConditionState.Notify)
                listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
            if (imd.Condition == ConditionState.NotEstimated)
                listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
        }
        #endregion

        #region public void UpdateItemsColor(IEnumerable<BaseEntityObject> items)
        /// <summary>
        /// Обновляет подсветку для переданных элементов
        /// </summary>
        /// <param name="items">Элементы, для которых требуется обновить подсветку</param>
        public void UpdateItemsColor(IEnumerable<BaseEntityObject> items)
        {
            List<ListViewItem> lvi =
                items.SelectMany(i => itemsListView.Items.Cast<ListViewItem>()
                                                         .Where(listViewItem => listViewItem.Tag == i))
                     .ToList();

            foreach (ListViewItem item in lvi)
            {
                SetItemColor(item, (BaseEntityObject)item.Tag);
            }
        }
        #endregion

        #region public void UpdateItemColor(BaseEntityObject item)
        /// <summary>
        /// Обновляет подсветку для переданного элемента
        /// </summary>
        /// <param name="item">Элемент, для которого требуется обновить подсветку</param>
        public void UpdateItemColor(BaseEntityObject item)
        {
            List<ListViewItem> lvi = 
                itemsListView.Items.Cast<ListViewItem>()
                                   .Where(listViewItem => listViewItem.Tag == item)
                                   .ToList();

            foreach (ListViewItem listViewItem in lvi)
            {
                SetItemColor(listViewItem, (BaseEntityObject)listViewItem.Tag);
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
            else if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                // e.Handled = true;
                return;
            }

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
        protected virtual void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem == null) return;

			var form = ScreenAndFormManager.GetEditForm(SelectedItem);
			if (form == null)
                return;

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                itemsListView.Items[itemsListView.Items.IndexOf(itemsListView.SelectedItems[0])] =
                    new ListViewItem(GetListViewSubItems(SelectedItem), null) { Tag = SelectedItem };
            }
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

            if(_viewedType == null)
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
                                         ? (int) attr.HeaderWidth
                                         : (int) (itemsListView.Width*attr.HeaderWidth);
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
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                ReferenceEventArgs e;
                if (null != Displayer)
                {
                    e = new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText);
                }
                else
                {
                    e = new ReferenceEventArgs(Entity, reflection, DisplayerText);
                }

                FillDisplayerRequestedParams(e);
                DisplayerRequested(this, e);
            }
        }

        #endregion

        #region protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            e.DisplayerText = _viewedType.Name;
            e.RequestedEntity = new CommonListScreen(_viewedType);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                Form form;

                if (ViewedType.Name == typeof(AircraftWorkerCategory).Name)
                {
                    form = new AircraftWorkerCategoryForm(new AircraftWorkerCategory());
                }
                else if (ViewedType.Name == typeof(Product).Name)
                {
                    form = new ProductForm(new Product());
                }
                else if (ViewedType.Name == typeof(AccessoryRequired).Name)
                {
                    form = new KitForm(new AccessoryRequired());
                }
                else
                {
                    ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
                    BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
                    form = new CommonEditorForm(item);
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    itemsListView.Items[itemsListView.Items.IndexOf(itemsListView.SelectedItems[0])] =
                        new ListViewItem(GetListViewSubItems(SelectedItem), null) { Tag = SelectedItem };
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building new object", ex);
                return;
            }
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
        /// Событие возникающее при изменении массива выбранных элементов в списке.
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
        public delegate void ItemPastedEventHandler(IEnumerable pastedItems);

        #endregion

        #endregion
    }

    internal class CommonListViewControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("ViewedType");
        }
    }
}
