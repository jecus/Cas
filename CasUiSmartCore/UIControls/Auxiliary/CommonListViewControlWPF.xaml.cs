using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using ListView = System.Windows.Controls.ListView;
using ListViewItem = System.Windows.Controls.ListViewItem;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using TextBoxBase = System.Windows.Controls.Primitives.TextBoxBase;
using UserControl = System.Windows.Controls.UserControl;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Логика взаимодействия для CommonListViewControlWPF.xaml
    /// </summary>
    public partial class CommonListViewControlWPF : UserControl, IReference
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
        protected readonly List<GridViewColumn> ColumnHeaderList = new List<GridViewColumn>();
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
                    return (itemsListView.SelectedItems[0] as BaseEntityObject);
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

        #region public CommonListViewControlWPF()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        public CommonListViewControlWPF()
        {
            InitializeComponent();
        }
        #endregion

        #region public CommonListViewControlWPF(PropertyInfo beginGroup) : this()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        ///<param name="beginGroup">Задает своиство класса, по которому нужно сделать первичную группировку</param>
        public CommonListViewControlWPF(PropertyInfo beginGroup) : this()
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
                AddItems(itemsArray);
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
                AddItems(itemsArray);
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
            if(!(itemsListView.View is GridView))
                itemsListView.View = new GridView();

            ColumnHeaderList.Clear();

            try
            {
                List<PropertyInfo> properties = GetTypeProperties();
                GridViewColumn columnHeader;
                foreach (PropertyInfo propertyInfo in properties)
                {
                    ListViewDataAttribute attr =
                        (ListViewDataAttribute)propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];

                    #region Определение ЭУ

                    if (propertyInfo.PropertyType.IsSubclassOf(typeof(StaticDictionary)))
                    {
                        //object val = propertyInfo.GetValue(obj, null);

                        //if (propertyInfo.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).Length > 0)
                        //{
                        //    DictionaryComboBox dc = new DictionaryComboBox
                        //    {
                        //        Enabled = controlEnabled,
                        //        Name = propertyInfo.Name,
                        //        SelectedItem = (StaticDictionary)val,
                        //        Tag = propertyInfo,
                        //        Type = propertyInfo.PropertyType,
                        //    };
                        //    //для возможности вызова новой вкладки
                        //    Program.MainDispatcher.ProcessControl(dc);
                        //    //
                        //    return dc;
                        //}
                        Type t = propertyInfo.PropertyType;
                        PropertyInfo p = t.GetProperty("Items");

                        ConstructorInfo ci = t.GetConstructor(new Type[0]);
                        StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                        IEnumerable staticList = (IEnumerable)p.GetValue(instance, null);

                        DataTemplate template = new DataTemplate();
                        FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.ComboBox));
                        template.VisualTree = factory;
                        
                        //System.Windows.Data.Binding sourceBinding = new System.Windows.Data.Binding();
                        //sourceBinding.Source = staticList;
                        //BindingOperations.SetBinding(taskItemListView, ListView.ItemsSourceProperty, sourceBinding );

                        factory.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding {Source = staticList});

                        //childFactory = new FrameworkElementFactory(typeof(Label));

                        //childFactory.SetBinding(Label.ContentProperty, new Binding("Machine.Descriiption"));

                        //childFactory.SetValue(Label.WidthProperty, 170.0);

                        //childFactory.SetValue(Label.HorizontalAlignmentProperty, HorizontalAlignment.Center);

                        //factory.AppendChild(childFactory);
                        columnHeader = new GridViewColumn { CellTemplate = template };
                    }
                    else if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
                    {
                        IDictionaryCollection dc;
                        try
                        {
                            dc = GlobalObjects.CasEnvironment.Dictionaries[propertyInfo.PropertyType];
                        }
                        catch (Exception)
                        {
                            dc = null;
                        }

                        DataTemplate template = new DataTemplate();
                        FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.ComboBox));
                        template.VisualTree = factory;
                        
                        //System.Windows.Data.Binding sourceBinding = new System.Windows.Data.Binding();
                        //sourceBinding.Source = staticList;
                        //BindingOperations.SetBinding(taskItemListView, ListView.ItemsSourceProperty, sourceBinding );

                        if(dc != null)
                        {
                            List<KeyValuePair<string, IDictionaryItem>> list = new List<KeyValuePair<string, IDictionaryItem>>();
                            foreach (IDictionaryItem item in dc)
                            {
                                list.Add(new KeyValuePair<string, IDictionaryItem>(item.ToString(), item));
                            }

                            factory.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding {Source = list});
                            factory.SetBinding(ItemsControl.DisplayMemberPathProperty, new System.Windows.Data.Binding("Key"));
                            factory.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding("Value"));
                        }
                       
                        columnHeader = new GridViewColumn {CellTemplate = template};

                        //AbstractDictionary val = (AbstractDictionary)propertyInfo.GetValue(obj, null);
                        //DictionaryComboBox dc = new DictionaryComboBox
                        //{
                        //    Enabled = controlEnabled,
                        //    SelectedItem = val,
                        //    Tag = propertyInfo,
                        //    Type = propertyInfo.PropertyType,
                        //};
                        //для возможности вызова новой вкладки
                        //Program.MainDispatcher.ProcessControl(dc);
                        //
                        //return dc;
                    }
                    else if (propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
                    {
                        DataTemplate template = new DataTemplate();
                        
                        FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                        factory.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
                        factory.SetValue(TextBoxBase.IsReadOnlyProperty, true);
                        factory.SetBinding(System.Windows.Controls.TextBox.TextProperty, new System.Windows.Data.Binding { Source = list});
                        template.VisualTree = factory;

                        columnHeader = new GridViewColumn {CellTemplate = template};
                    }
                    else if (propertyInfo.PropertyType.IsEnum)
                    {
                        DataTemplate template = new DataTemplate();
                        FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.ComboBox));
                        template.VisualTree = factory;
                        
                        List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();
                        foreach (object o in Enum.GetValues(propertyInfo.PropertyType))
                        {
                            string name = Enum.GetName(propertyInfo.PropertyType, o);
                            string desc = name;
                            FieldInfo fi = propertyInfo.PropertyType.GetField(name);
                            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                            if (attributes.Length > 0)
                            {
                                string s = attributes[0].Description;
                                if (!string.IsNullOrEmpty(s))
                                {
                                    desc = s;
                                }
                            }
                            list.Add(new KeyValuePair<string, object>(desc, o));
                        }

                        factory.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding {Source = list});
                        factory.SetBinding(ItemsControl.DisplayMemberPathProperty, new System.Windows.Data.Binding("Key"));
                        factory.SetBinding(ItemsControl.ItemsSourceProperty, new System.Windows.Data.Binding("Value"));

                        columnHeader = new GridViewColumn {CellTemplate = template};
                    }
                    else
                    {
                        #region  ЭУ для базовых типов

                        string typeName = propertyInfo.PropertyType.Name.ToLower();
                        switch (typeName)
                        {
                            case "string":
                                {
                                    DataTemplate template = new DataTemplate();
                        
                                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                    factory.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
                                    factory.SetValue(TextBoxBase.IsReadOnlyProperty, true);
                                    template.VisualTree = factory;

                                    columnHeader = new GridViewColumn {CellTemplate = template};

                                    break;
                                }
                            case "int32":
                            case "int16":
                                {
                                    DataTemplate template = new DataTemplate();
                        
                                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                    factory.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
                                    factory.SetValue(TextBoxBase.IsReadOnlyProperty, true);
                                    template.VisualTree = factory;

                                    columnHeader = new GridViewColumn {CellTemplate = template};

                                    break;
                                }
                            case "datetime":
                                {
                                    DataTemplate template = new DataTemplate();
                        
                                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                    factory.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
                                    factory.SetValue(TextBoxBase.IsReadOnlyProperty, true);
                                    template.VisualTree = factory;

                                    columnHeader = new GridViewColumn {CellTemplate = template};
                                    break;
                                }
                            case "bool":
                            case "boolean":
                                {
                                    DataTemplate template = new DataTemplate();
                        
                                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.CheckBox));
                                    template.VisualTree = factory;

                                    columnHeader = new GridViewColumn {CellTemplate = template};

                                    break;
                                }
                            case "double":
                                {
                                    DataTemplate template = new DataTemplate();
                        
                                    FrameworkElementFactory factory = new FrameworkElementFactory(typeof(System.Windows.Controls.TextBox));
                                    factory.SetValue(System.Windows.Controls.TextBox.TextWrappingProperty, TextWrapping.Wrap);
                                    factory.SetValue(TextBoxBase.IsReadOnlyProperty, true);
                                    template.VisualTree = factory;

                                    columnHeader = new GridViewColumn {CellTemplate = template};

                                    break;
                                }
                            //case "directivethreshold":
                            //    {
                            //        object val = propertyInfo.GetValue(obj, null);
                            //        return new DirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DirectiveThreshold)val, Tag = propertyInfo };
                            //    }
                            //case "detaildirectivethreshold":
                            //    {
                            //        object val = propertyInfo.GetValue(obj, null);
                            //        return new DetailDirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DetailDirectiveThreshold)val, Tag = propertyInfo };
                            //    }
                            //case "lifelength":
                            //    {
                            //        object val = propertyInfo.GetValue(obj, null);
                            //        return new LifelengthViewer
                            //        {
                            //            Enabled = controlEnabled,
                            //            Lifelength = (Lifelength)val,
                            //            MinimumSize = new Size(20, 17),
                            //            Tag = propertyInfo
                            //        };
                            //    }
                            default:
                                columnHeader = null;
                                break;
                        }
                        #endregion    
                    }
                    #endregion

                    if (columnHeader == null)
                        continue;

                    columnHeader.Width = (int)(attr.HeaderWidth < 1 ? itemsListView.Width * attr.HeaderWidth : attr.HeaderWidth);
                    columnHeader.Header = attr.Title;
                    //columnHeader.Tag = propertyInfo;
                    //Поиск NotNullAttribute для определения возможности задавать пустые значения в колонке
                    //NotNullAttribute notNullAttribute =
                    //    (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                    //if (notNullAttribute != null)
                    //{
                    //    //Если имеется атрибут NotNullAttribute то шрифт заголовка задается Жирным
                    //    columnHeader.HeaderCell.Style.Font = new Font(dataGridView.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                    //    columnHeader.HeaderCell.ToolTipText = 
                    //        string.Format("The cells in column {0} should be filled", columnHeader.HeaderText);
                    //}
                    ColumnHeaderList.Add(columnHeader);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building list headers", ex);
                return;
            }
        }
        #endregion

        #region protected virtual void AddItems(ICommonCollection itemsArray)
        /// <summary>
        /// Добавляет элементы <see cref="_viewedType"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected virtual void AddItems(ICommonCollection itemsArray)
        {
            if (itemsArray.Count != 0)
            {
                foreach (BaseEntityObject o in itemsArray)
                {
                    AddItem(o);
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

        #region protected virtual void AddItems(IEnumerable<BaseEntityObject> itemsArray)
        /// <summary>
        /// Добавляет элементы <see cref="_viewedType"/> в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected virtual void AddItems(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (itemsArray.Count() != 0)
            {
                foreach (BaseEntityObject o in itemsArray)
                {
                    AddItem(o);
                }
                if (SortMultiplier == 1)
                    SortMultiplier = -1;
                else
                    SortMultiplier = 1;
                SortItems(OldColumnIndex);
            }
        }

        #endregion

        #region protected void AddItem(BaseSmartCoreObject item)

        /// <summary>
        /// Добавляет элемент в список технических записей (AbstractRecord)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
        protected void AddItem(BaseEntityObject item)
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
            ListViewItemList.Sort(new BaseListViewWPFComparer(columnIndex,SortMultiplier));
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
               _beginGroup.ReflectedType == null ||
               _beginGroup.ReflectedType.Name != _viewedType.Name ||
               _viewedType.GetProperty(_beginGroup.Name) == null)
                return;

            ICollectionView view = CollectionViewSource.GetDefaultView(itemsListView); 
            view.GroupDescriptions.Clear();

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
                    temp = UsefulMethods.EnumToString((Enum)value);
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

                view.GroupDescriptions.Add(temp, temp);
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

        #region protected virtual void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
        protected virtual void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
            IDirective imd = item as IDirective;
            if (imd == null) return;

            if (imd.Condition == ConditionState.Overdue)
                listViewItem.Background = Color.FromArgb(Highlight.Red.Color);
            if (imd.Condition == ConditionState.Notify)
                listViewItem.Background = Color.FromArgb(Highlight.Yellow.Color);
            if (imd.Condition == ConditionState.NotEstimated)
                listViewItem.Background = Color.FromArgb(Highlight.Blue.Color);
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

        #region private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
        private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
        {
            _clearSearch = true;
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
            DisplayerAttribute da = 
                (DisplayerAttribute)_viewedType.GetCustomAttributes(typeof(DisplayerAttribute), false)
                                        .FirstOrDefault();

            if (da == null || da.DisplayerType == DisplayerType.Form)
            {
                Form form;
                if (SelectedItem is AircraftWorkerCategory)
                {
                    form = new AircraftWorkerCategoryForm((AircraftWorkerCategory)SelectedItem);
                }
                else if (SelectedItem is AccessoryDescription)
                {
                    form = new AccessoryDescriptionForm((AccessoryDescription)SelectedItem);
                }
                else if (SelectedItem is AccessoryRequired)
                {
                    form = new KitForm((AccessoryRequired)SelectedItem);
                }
                else
                {
                    form = new CommonEditorForm(SelectedItem);
                }
                if (form.ShowDialog() == DialogResult.OK)
                {
                    itemsListView.Items[itemsListView.Items.IndexOf(itemsListView.SelectedItems[0])] =
                        new ListViewItem(GetListViewSubItems(SelectedItem), null) { Tag = SelectedItem };
                }
            }
            else if (da.DisplayerType == DisplayerType.Screen)
            {
                OnDisplayerRequested();
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
                else if (ViewedType.Name == typeof(AccessoryDescription).Name)
                {
                    form = new AccessoryDescriptionForm(new AccessoryDescription());
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
}
