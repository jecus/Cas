using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// ЭУ для предствления списков объектов определенного типа, унаследованных от <see cref="BaseEntityObject"/>
    ///</summary>
    [Designer(typeof(CommonDataGridViewControlDesigner))]
    public partial class CommonDataGridViewControl : UserControl, IReference
    {
        #region Fields
        /// <summary>
        /// Тип, объекты которого будут отображаться в списке
        /// </summary>
        private Type _viewedType;
        /// <summary>
        /// Своиство типа, по которому нужно произвести первичную группировку
        /// </summary>
        protected PropertyInfo _beginGroup;
        /// <summary>
        /// Своиство типа, по которому нужно произвести первичную группировку
        /// </summary>
        protected List<PropertyInfo> _viewedTypeProperties;

        private bool _clearSearch;

        /// <summary>
        /// Значение, возможно ли открыть форму редактирования на двойной щелчок
        /// </summary>
        private bool _canOpenEditFormOnDoubleClick;
        /// <summary>
        /// Словарь кэша для поиска
        /// </summary>
        protected Dictionary<DataGridViewRow, string> _searchCache = new Dictionary<DataGridViewRow, string>();
        //коллекция исходных элементов
        protected List<BaseEntityObject> _sourceCollection = new List<BaseEntityObject>();
        //коллекция выделенных элементов
        protected ICommonCollection _selectedItemsList;
        //заголовки списка
        protected readonly List<DataGridViewColumn> ColumnHeaderList = new List<DataGridViewColumn>();
        //номер последней колонки, по которой производилась сортировка
        protected int OldColumnIndex;
        ///<summary>
        ///направление сортировки списка
        ///</summary>
        protected int SortMultiplier = -1;
        ///<summary>
        ///предварительный список элементов DataGridView
        ///</summary>
        public List<DataGridViewRow> PreResultRowList = new List<DataGridViewRow>();
        #endregion

        #region Properties

        #region public int Count
        /// <summary>
        /// Возвращает кол-во элементов в списке
        /// </summary>
        public int Count
        {
            get
            {
                return dataGridView.Rows.OfType<DataGridViewRow>().Count(r => r.Tag is BaseEntityObject);
            }
        }
        #endregion

        #region public bool RowHeadersVisible
        /// <summary>
        /// Возвращает или задает значение, нужно ли отображать заголовки строк
        /// </summary>
        [DefaultValue(true)]
        public bool RowHeadersVisible
        {
            get { return dataGridView.RowHeadersVisible; }
            set { dataGridView.RowHeadersVisible = value; }
        }
        #endregion

        #region public bool CanOpenEditFormOnDoubleClick
        /// <summary>
        /// Возвращает или задает значение, возможно ли открыть форму редактирования на двойной щелчок
        /// </summary>
        [DefaultValue(true)]
        public bool CanOpenEditFormOnDoubleClick
        {
            get { return _canOpenEditFormOnDoubleClick; }
            set { _canOpenEditFormOnDoubleClick = value; }
        }
        #endregion

        #region public DataGridViewSelectionMode SelectionMode
        /// <summary>
        /// Возвращает или задает значение, каким образом будут выбираться ячейки
        /// </summary>
        [DefaultValue(DataGridViewSelectionMode.FullRowSelect)]
        public DataGridViewSelectionMode SelectionMode
        {
            get { return dataGridView.SelectionMode; }
            set { dataGridView.SelectionMode = value; }
        }
        #endregion

        #region public bool ReadOnly

        private bool _readOnly;
        /// <summary>
        /// Скрывает кпонки и переводит строки списка в режим "Только для чтения"
        /// </summary>
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;

                linkLabelAddNew.Visible = linkLabelDelete.Visible = !_readOnly;
            }
        }
        #endregion

        #region public bool ShowGroups
        ///// <summary>
        ///// Нужно ли показывать группы
        ///// </summary>
        //public bool ShowGroups
        //{
        //    get { return ItemsDataGridView.ShowGroups; }
        //    set { ItemsDataGridView.ShowGroups = value; }
        //}
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
                _selectedItemsList.AddRange(dataGridView.SelectedRows
                                                .Cast<DataGridViewRow>()
                                                .Where(i => i.Tag is BaseEntityObject)
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
                if (dataGridView.SelectedRows.Count == 1)
                    return (dataGridView.SelectedRows[0].Tag as BaseEntityObject);
                return null;
            }
        }
        #endregion

        #region public bool ShowQuickSearch
        /// <summary>
        /// Возвращает или устанавливает значение отображения панели быстрого поиска
        /// </summary>
        [Category("Layout"), Description("Показывать панель быстрого поиска")]
        [DefaultValue(true)]
        public bool ShowQuickSearch
        {
            get { return quickSearchControl.Visible; }
            set { quickSearchControl.Visible = value; }
        }

        #endregion

        #region public bool ShowAddNew
        /// <summary>
        /// Возвращает или устанавливает значение отображения панели быстрого поиска
        /// </summary>
        [Category("Layout"), Description("Показывать панель кнопку добавления записи")]
        [DefaultValue(true)]
        public bool ShowAddNew
        {
            get { return linkLabelAddNew.Visible; }
            set { linkLabelAddNew.Visible = value; }
        }

        #endregion

        #region public bool ShowDelete
        /// <summary>
        /// Возвращает или устанавливает значение отображения панели быстрого поиска
        /// </summary>
        [Category("Layout"), Description("Показывать панель кнопку удления записей")]
        [DefaultValue(true)]
        public bool ShowDelete
        {
            get { return linkLabelDelete.Visible; }
            set { linkLabelDelete.Visible = value; }
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
                if (value.Name != typeof(BaseEntityObject).Name && !value.IsSubclassOf(typeof(BaseEntityObject)))
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

        #region public List<PropertyInfo> ViewedTypeProperties;
        /// <summary>
        /// Свойства типа, которые будут испльзованы для создания и заполнения колонок
        /// </summary>
        public List<PropertyInfo> ViewedTypeProperties
        {
            get { return _viewedTypeProperties ?? (_viewedTypeProperties = new List<PropertyInfo>()); }
            set { _viewedTypeProperties = value; }
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

        #region public CommonDataGridViewControl()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        public CommonDataGridViewControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public CommonDataGridViewControl(PropertyInfo beginGroup) : this()
        ///<summary>
        /// конструктор по умолчанию для простого создания ЭУ в Дизайнере
        ///</summary>
        ///<param name="beginGroup">Задает своиство класса, по которому нужно сделать первичную группировку</param>
        public CommonDataGridViewControl(PropertyInfo beginGroup)
            : this()
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
            PreResultRowList.Clear();
            //очистка исходной коллекции элементов
            _sourceCollection.Clear();

            Dispose(true);
        }
        #endregion

        #region protected List<PropertyInfo> GetTypeProperties()
        protected List<PropertyInfo> GetTypeProperties()
        {
            if (_viewedType == null) 
                throw new NullReferenceException("_viewedType is null");

            List<PropertyInfo> properties;
            if (_viewedTypeProperties != null && _viewedTypeProperties.Count > 0)
                properties = new List<PropertyInfo>(_viewedTypeProperties);
            else
            {
                //определение своиств, имеющих атрибут "отображаемое в списке"
                properties =
                    _viewedType.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();   
            }

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
            PreResultRowList.Clear();
            //очищение элементов ListViewa
            dataGridView.Rows.Clear();
            //очищение коллекции выбранных элементов
            _selectedItemsList.Clear();
            //очистка исходной коллекции элементов
            _sourceCollection.Clear();
            try
            {
                CreateItems(itemsArray);
                SetRowsBackColor();
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
            PreResultRowList.Clear();
            //очищение элементов ListViewa
            dataGridView.Rows.Clear();
            //очищение коллекции выбранных элементов
            _selectedItemsList.Clear();
            //очистка исходной коллекции элементов
            _sourceCollection.Clear();
            try
            {
                CreateItems(itemsArray);
                SetRowsBackColor();
                SetTotalText();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
            }
        }
        #endregion

        #region  public virtual ICommonCollection GetItemsArray()
        /// <summary>
        /// Возвращает все (действительные/недействительные) директивы списка
        /// </summary>
        /// <returns>Директивы</returns>
        public virtual ICommonCollection GetItemsArray()
        {
            try
            {
                Type genericType = typeof(CommonCollection<>);
                Type genericList = genericType.MakeGenericType(_viewedType);
                ICommonCollection returnDetailArray = (ICommonCollection)Activator.CreateInstance(genericList);
                returnDetailArray.AddRange(_sourceCollection.ToArray());
                return returnDetailArray;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building collection", ex);
                return null;
            }
        }
        #endregion

        #region public virtual ICommonCollection GetSelectedItemsArray()
        /// <summary>
        /// Метод возвращает массив директив
        /// </summary>
        /// <returns>Массив директив</returns>
        public virtual ICommonCollection GetSelectedItemsArray()
        {
            try
            {
                int count = dataGridView.SelectedRows.Count;
                Type genericType = typeof(CommonCollection<>);
                Type genericList = genericType.MakeGenericType(_viewedType);
                ICommonCollection returnDetailArray = (ICommonCollection)Activator.CreateInstance(genericList);
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        returnDetailArray.Add(dataGridView.SelectedRows[i].Tag as BaseEntityObject);
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
                AddItem(item);

                SetGroupsToItems();
                SetRowsBackColor();
                SetTotalText();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while building data", ex);
                return;
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
                int columnsWidth = 0;
                List<PropertyInfo> properties = GetTypeProperties();
                DataGridViewColumn columnHeader;
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

                        columnHeader = new DataGridViewComboBoxColumn();
                        DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)columnHeader;
                        //поиск своиства Items у типа StaticDictionary
                        Type t = propertyInfo.PropertyType;
                        PropertyInfo p = t.GetProperty("Items");

                        ConstructorInfo ci = t.GetConstructor(new Type[0]);
                        StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                        IEnumerable staticList = (IEnumerable)p.GetValue(instance, null);

                        foreach (StaticDictionary o in staticList)
                            comboBoxColumn.Items.Add(o);
                    }
                    else if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
                    {
                        columnHeader = new DataGridViewComboBoxColumn();
                        DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)columnHeader;
                        //comboBoxColumn.Resizable = DataGridViewTriState.True;
                        //ComboBox nc = new ComboBox { Enabled = controlEnabled, Tag = propertyInfo };
                        IDictionaryCollection dc;
                        try
                        {
                            dc = GlobalObjects.CasEnvironment.GetDictionary(propertyInfo.PropertyType);
                        }
                        catch (Exception)
                        {
                            dc = null;
                        }
                        if(dc != null)
                        {
                            List<KeyValuePair<string, IDictionaryItem>> list = new List<KeyValuePair<string, IDictionaryItem>>();
                            foreach (IDictionaryItem item in dc)
                            {
                                list.Add(new KeyValuePair<string, IDictionaryItem>(item.ToString(), item));
                            }
                            comboBoxColumn.DisplayMember = "Key";
                            comboBoxColumn.ValueMember = "Value";
                            comboBoxColumn.DataSource = list;
                        }
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
                        if (attr.ReadOnly)
                        {
                            columnHeader = new DataGridViewTextBoxColumn();
                            columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            columnHeader.ReadOnly = true;   
                        }
                        else
                        {
                            columnHeader = new DataGridViewLookupColumn();
                            
                            DataGridViewLookupColumn lookupColumn = (DataGridViewLookupColumn) columnHeader;
                            lookupColumn.ViewedType = propertyInfo.PropertyType;
                        }
                    }
                    else if (propertyInfo.PropertyType.IsEnum)
                    {
                        //object val = propertyInfo.GetValue(obj, null);
                        //if (propertyInfo.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                        //{
                        //    CommonFlagsControl cfc = new CommonFlagsControl
                        //    {
                        //        Enabled = controlEnabled,
                        //        SourceEnum = propertyInfo.PropertyType,
                        //        Tag = propertyInfo
                        //    };
                        //    return cfc;
                        //}
                        columnHeader = new DataGridViewComboBoxColumn();
                        DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn) columnHeader;

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
                        comboBoxColumn.DisplayMember = "Key";
                        comboBoxColumn.ValueMember = "Value";
                        comboBoxColumn.DataSource = list;
                    }
                    else
                    {
                        #region  ЭУ для базовых типов

                        string typeName = propertyInfo.PropertyType.Name.ToLower();
                        switch (typeName)
                        {
                            case "string":
                                {
                                    columnHeader = new DataGridViewTextBoxColumn();
                                    columnHeader.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                    break;
                                }
                            case "int32":
                            case "int16":
                                {
                                    columnHeader = new DataGridViewNumericUpDownColumn();
                                    MinMaxValueAttribute mmValue =
                                        (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                                    if (mmValue != null)
                                    {
                                        DataGridViewNumericUpDownColumn nudc = (DataGridViewNumericUpDownColumn)columnHeader;
                                        nudc.Maximum = (decimal)mmValue.Max;
                                        nudc.Minimum = (decimal)mmValue.Min;
                                        nudc.DecimalPlaces = 0;
                                    }
                                    break;
                                }
                            case "datetime":
                                {
                                    columnHeader = new DataGridViewCalendarColumn();
                                    break;
                                }
                            case "bool":
                            case "boolean":
                                {
                                    columnHeader = new DataGridViewCheckBoxColumn();
                                    break;
                                }
                            case "double":
                                {
                                    columnHeader = new DataGridViewNumericUpDownColumn();
                                    MinMaxValueAttribute mmValue =
                                        (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                                    if (mmValue != null)
                                    {
                                        DataGridViewNumericUpDownColumn nudc = (DataGridViewNumericUpDownColumn)columnHeader;
                                        nudc.Maximum = (decimal)mmValue.Max;
                                        nudc.Minimum = (decimal)mmValue.Min;
                                        nudc.DecimalPlaces = 2;

									}
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

                    columnHeader.Width = (int)(attr.HeaderWidth < 1 ? dataGridView.Width * attr.HeaderWidth : attr.HeaderWidth);
                    columnHeader.HeaderText = attr.Title;
                    columnHeader.ReadOnly = attr.ReadOnly;
                    columnHeader.Tag = propertyInfo;
                    //Поиск NotNullAttribute для определения возможности задавать пустые значения в колонке
                    NotNullAttribute notNullAttribute =
                        (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                    if (notNullAttribute != null)
                    {
                        //Если имеется атрибут NotNullAttribute то шрифт заголовка задается Жирным
                        columnHeader.HeaderCell.Style.Font = new Font(dataGridView.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                        columnHeader.HeaderCell.ToolTipText =
	                        $"The cells in column {columnHeader.HeaderText} should be filled";
                    }
                    ColumnHeaderList.Add(columnHeader);
                    columnsWidth += columnHeader.Width;
                }

                if (columnsWidth <= dataGridView.Width)
                {
                    //double c = (double)dataGridView.Width / columnsWidth;
                    //for (int i = 0; i < ColumnHeaderList.Count; i++)
                    //{
                    //    if (i >= properties.Count)
                    //    {
                    //        ColumnHeaderList[i].Width = (int)(dataGridView.Width * 0.1f * c);
                    //        continue;
                    //    }
                    //    ColumnHeaderList[i].Width = (int)(ColumnHeaderList[i].Width * c);
                    //}    
                }

				dataGridView.Columns.Clear();
				dataGridView.Columns.AddRange(ColumnHeaderList.ToArray());
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
                    _sourceCollection.Add(o);
                    CreateItem(o);
                }
                //dataGridView.Rows.AddRange(PreResultRowList.ToArray());
                //ShowGroups = true;
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
                    if(o == null)
                        continue;
                    _sourceCollection.Add(o);
                    CreateItem(o);
                }
                //dataGridView.Rows.AddRange(PreResultRowList.ToArray());
                //ShowGroups = true;
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
                dataGridView.Rows.Add(1);
                DataGridViewRow dataGridViewRow  = dataGridView.Rows[dataGridView.Rows.Count - 1];
                dataGridViewRow.ReadOnly = _readOnly;
                SetRowCellsValues(dataGridViewRow, item);
                dataGridViewRow.Tag = item;
                PreResultRowList.Add(dataGridViewRow);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log(ex);
            }
        }
        #endregion

        #region public void ClearItems()
        ///<summary>
        /// Производит очистку элементов
        ///</summary>
        public void ClearItems()
        {
            dataGridView.Rows.Clear();

            if(_selectedItemsList != null)
                _selectedItemsList.Clear();

            //очищение предварительной коллекции элементов
            if (PreResultRowList != null)
                PreResultRowList.Clear();
            //очищение элементов ListViewa
            dataGridView.Rows.Clear();
            //очистка исходной коллекции элементов
            if (_sourceCollection != null)
                _sourceCollection.Clear();
        }

        #endregion

        #region protected virtual void SetTotalText()
        /// <summary>
        /// Устанавивает информацию об общем количестве элементов в нижней панели
        /// </summary>
        protected virtual void SetTotalText()
        {
            labelTotal.Text = "Total: " + dataGridView.Rows.Count;
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
            dataGridView.Rows.Clear();
            SetGroupsToItems();
            PreResultRowList.Sort(new BaseDataGridViewRowComparer(columnIndex, SortMultiplier));
            dataGridView.Rows.AddRange(PreResultRowList.ToArray());
            OldColumnIndex = columnIndex;
            SetRowsBackColor();
        }
        #endregion

        #region protected virtual void SetGroupsToItems()
        protected virtual void SetGroupsToItems()
        {
            //if(_beginGroup == null || 
            //   _beginGroup.ReflectedType.Name != _viewedType.Name ||
            //   _viewedType.GetProperty(_beginGroup.Name) == null)
            //    return;

            //dataGridView.Groups.Clear();
            //foreach (ListViewItem item in PreResultRowList)
            //{
            //    String temp;

            //    if (item.Tag == null) continue;
            //    BaseEntityObject ob = item.Tag as BaseEntityObject;
            //    if (ob == null) continue;

            //    //Извлечение значения
            //    object value = _beginGroup.GetValue(ob, null);
            //    //Проверка значения на null
            //    if (value == null) 
            //        continue;

            //    if (value is IDictionaryItem)
            //        temp = ((IDictionaryItem)value).FullName;
            //    else if (value is BaseEntityObject)
            //        temp = value.ToString();
            //    else if (value is IThreshold)
            //        temp = value.ToString();
            //    else if (value is Lifelength)
            //        temp = value.ToString();
            //    else if (value.GetType().IsEnum)
            //        temp = UsefulMethods.EnumToString((Enum)value);
            //    else if (value is string)
            //        temp = (string)value;  
            //    else if (value is int)
            //        temp = ((int)value).ToString();
            //    else if (value is short)
            //        temp = ((short)value).ToString();
            //    else if (value is DateTime)
            //        temp = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
            //    else if (value is bool)
            //        temp = value.ToString();
            //    else if (value is double)
            //        temp = ((double)value).ToString();
            //    else
            //        temp = "Can't define group";

            //    itemsListView.Groups.Add(temp, temp);
            //    item.Group = itemsListView.Groups[temp];
            //}
        }
        #endregion

        #region protected void SetRowsBackColor()
        protected void SetRowsBackColor()
        {
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                SetRowBackColor(item, (BaseEntityObject)item.Tag);
            }
        }
        #endregion

        #region protected virtual void SetItemColor(DataGridViewRow dataGridViewRow, BaseSmartCoreObject item)
        protected virtual void SetRowBackColor(DataGridViewRow dataGridViewRow, BaseEntityObject item)
        {
            IDirective imd = item as IDirective;
            if (imd == null) return;

            if (imd.Condition == ConditionState.Overdue)
                dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Red.Color);
            if (imd.Condition == ConditionState.Notify)
                dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Yellow.Color);
            if (imd.Condition == ConditionState.NotEstimated)
                dataGridViewRow.DefaultCellStyle.BackColor = Color.FromArgb(Highlight.Blue.Color);
        }
        #endregion

        #region public void UpdateItemsColor(IEnumerable<BaseEntityObject> items)
        /// <summary>
        /// Обновляет подсветку для переданных элементов
        /// </summary>
        /// <param name="items">Элементы, для которых требуется обновить подсветку</param>
        public void UpdateItemsColor(IEnumerable<BaseEntityObject> items)
        {
            List<DataGridViewRow> dataGridViewRows =
                items.SelectMany(i => dataGridView.Rows.Cast<DataGridViewRow>()
                                                       .Where(listViewItem => listViewItem.Tag == i))
                     .ToList();

            foreach (DataGridViewRow item in dataGridViewRows)
            {
                SetRowBackColor(item, (BaseEntityObject)item.Tag);
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
            List<DataGridViewRow> lvi =
                dataGridView.Rows.Cast<DataGridViewRow>()
                                   .Where(listViewItem => listViewItem.Tag == item)
                                   .ToList();

            foreach (DataGridViewRow listViewItem in lvi)
            {
                SetRowBackColor(listViewItem, (BaseEntityObject)listViewItem.Tag);
            }
        }
        #endregion

        #region protected virtual DataGridViewCell[] GetRowCells(BaseEntityObject item)

        protected virtual DataGridViewCell[] GetRowCells(BaseEntityObject item)
        {
            List<PropertyInfo> properties = GetTypeProperties();
            DataGridViewCell[] rowCells = new DataGridViewCell[properties.Count];
            
            for (int i = 0; i < properties.Count; i++ )
            {
                object value = properties[i].GetValue(item, null);
                
                DataGridViewCell dataGridViewCell;

                if (properties[i].PropertyType.IsSubclassOf(typeof(StaticDictionary)))
                {
                    dataGridViewCell = new DataGridViewComboBoxCell();
                }
                else if (properties[i].PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
                {
                    dataGridViewCell = new DataGridViewComboBoxCell();
                }
                else if (properties[i].PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    dataGridViewCell = new DataGridViewTextBoxCell();
                }
                else if (properties[i].PropertyType.IsEnum)
                {
                    dataGridViewCell = new DataGridViewComboBoxCell();
                }
                else
                {
                    #region  ЭУ для базовых типов

                    string typeName = properties[i].PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "string":
                            {
                                dataGridViewCell = new DataGridViewTextBoxCell();
                                break;
                            }
                        case "int32":
                        case "int16":
                            {
                                dataGridViewCell = new DataGridViewNumericUpDownCell();
                                MinMaxValueAttribute mmValue =
                                    (MinMaxValueAttribute)
                                    properties[i].GetCustomAttributes(typeof (MinMaxValueAttribute), false).
                                        FirstOrDefault();
                                if (mmValue != null)
                                {
                                    DataGridViewNumericUpDownCell nudc =
                                        (DataGridViewNumericUpDownCell) dataGridViewCell;
                                    nudc.Maximum = (decimal) mmValue.Max;
                                    nudc.Minimum = (decimal) mmValue.Min;
                                    nudc.DecimalPlaces = 0;
                                }
                                break;
                            }
                        case "datetime":
                            {
                                dataGridViewCell = new DataGridViewCalendarCell();
                                break;
                            }
                        case "bool":
                        case "boolean":
                            {
                                dataGridViewCell = new DataGridViewCheckBoxCell();
                                break;
                            }
                        case "double":
                            {
                                dataGridViewCell = new DataGridViewNumericUpDownCell();
                                MinMaxValueAttribute mmValue =
                                    (MinMaxValueAttribute)
                                    properties[i].GetCustomAttributes(typeof (MinMaxValueAttribute), false).
                                        FirstOrDefault();
                                if (mmValue != null)
                                {
                                    DataGridViewNumericUpDownCell nudc =
                                        (DataGridViewNumericUpDownCell) dataGridViewCell;
                                    nudc.Maximum = (decimal) mmValue.Max;
                                    nudc.Minimum = (decimal) mmValue.Min;
                                    nudc.DecimalPlaces = 2;
                                }
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
                            dataGridViewCell = null;
                            break;
                    }

                    #endregion
                }

                if(dataGridViewCell == null)
                    continue;
                dataGridViewCell.Value = value;
                dataGridViewCell.Tag = value;
                rowCells[i] = dataGridViewCell;
            }
            return rowCells;
        }

        #endregion

        #region protected virtual bool ApplyRowCellsValues(DataGridViewRow row, BaseEntityObject item)

        protected virtual void ApplyRowCellsValues(DataGridViewRow row, BaseEntityObject item)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                PropertyInfo propertyInfo = cell.OwningColumn.Tag as PropertyInfo;
                if (propertyInfo == null 
                    || propertyInfo.GetSetMethod() == null 
                    || propertyInfo.GetSetMethod(false) == null) 
                    continue;

                if(cell is DataGridViewNumericUpDownCell)
                {
                    string typeName = propertyInfo.PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "int32":
                            {
                                propertyInfo.SetValue(item, Convert.ToInt32(cell.Value), null); 
                                break;
                            }
                        case "int16":
                            {
                                propertyInfo.SetValue(item, Convert.ToInt16(cell.Value), null); 
                                break;
                            }
                        case "decimal":
                            {
                                propertyInfo.SetValue(item, cell.Value, null);
                                break;
                            }
                        case "double":
                            {
                                propertyInfo.SetValue(item, Convert.ToDouble(cell.Value), null); 
                                break;
                            }
                        default:
                            propertyInfo.SetValue(item, 0, null);
                            break;
                    }    
                }
                else if (cell is DataGridViewLookupCell &&
                         propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    propertyInfo.SetValue(item, cell.Value, null);  
                }
                else if (cell is DataGridViewTextBoxCell &&
                         propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    //    
                }
                else propertyInfo.SetValue(item, cell.Value, null);
            }
        }

        #endregion

        #region protected virtual void SetRowCellsValues(DataGridViewRow row, BaseEntityObject item)

        protected virtual void SetRowCellsValues(DataGridViewRow row, BaseEntityObject item)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                PropertyInfo propertyInfo = cell.OwningColumn.Tag as PropertyInfo;
                if (propertyInfo == null) 
                    continue;

                object val = propertyInfo.GetValue(item, null);
                cell.Value = val;
            }
        }

        #endregion

        #region protected virtual bool RowCellsValuesEquals(DataGridViewRow row, BaseEntityObject item)

        protected virtual bool RowCellsValuesEquals(DataGridViewRow row, BaseEntityObject item)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                PropertyInfo propertyInfo = cell.OwningColumn.Tag as PropertyInfo;
                if (propertyInfo == null) continue;

                object val = propertyInfo.GetValue(item, null);

                if (cell.Value == null && val != null)
                    return false;
                if (cell.Value != null && !cell.Value.Equals(val))
                    return false;
            }
            return true;
        }

        #endregion

        #region protected virtual bool ValidateRowCellsValues(DataGridViewRow row, BaseEntityObject item, out string message)

        protected virtual bool ValidateRowCellsValues(DataGridViewRow row, BaseEntityObject item, out string message)
        {
            message = "";
            foreach (DataGridViewCell cell in row.Cells)
            {
                PropertyInfo propertyInfo = cell.OwningColumn.Tag as PropertyInfo;
                if (propertyInfo == null) continue;

                object val = propertyInfo.GetValue(item, null);
                //Поиск NotNullAttribute для определения возможности задавать пустые значения в колонке
                NotNullAttribute notNullAttribute =
                    (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                if (notNullAttribute != null)
                {
                    if (cell.Value == null || (propertyInfo.PropertyType.Name.ToLower() == "string" &&
                                               ((cell.Value is string) == false || string.IsNullOrEmpty((string) cell.Value))))
                    {
                        if (message != "") message += "\n ";
                        ListViewDataAttribute lvda = (ListViewDataAttribute)
                                                     propertyInfo.GetCustomAttributes(typeof (ListViewDataAttribute),
                                                                                      false).First();
                        message += $"cells in column '{lvda.Title}' should not be empty";
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region private void ClearSelectedItems()
        ///<summary>
        /// Производит очистку выделенных элементов
        ///</summary>
        private void ClearSelectedItems()
        {
			if(dataGridView.SelectedRows.Count == 0)
				return;

            dataGridView.SelectedRows.Clear();
            _selectedItemsList.Clear();
        }

        #endregion

        #region public bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            IEnumerable<DataGridViewRow> rowsInGrid =
                dataGridView.Rows.OfType<DataGridViewRow>()
                                 .Where(r => r.Tag is BaseEntityObject)
                                 .ToArray();
            IEnumerable<BaseEntityObject> itemsInGrid =
                rowsInGrid.Select(r => r.Tag as BaseEntityObject)
                          .ToArray();

            if(itemsInGrid.Count() != _sourceCollection.Count)
            {
                //Проверка на равенствно кол-ва элементов в гриде кол-ву элементов в исходной коллекции
                return true;
            }
            if(itemsInGrid.Count(i => i.ItemId <= 0) > 0)
            {
                //Проверка на добавленные элементы
                return true;
            }
            //Проверка на изменения значений в строках
            return rowsInGrid.Any(row => !RowCellsValuesEquals(row, row.Tag as BaseEntityObject));
        }

        #endregion
		 
        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";

            IEnumerable<DataGridViewRow> rowsInGrid =
                dataGridView.Rows.OfType<DataGridViewRow>()
                                 .Where(r => r.Tag != null && r.Tag is BaseEntityObject);
            IEnumerable<BaseEntityObject> itemsInGrid =
                rowsInGrid.Select(r => r.Tag as BaseEntityObject);

            foreach (DataGridViewRow row in rowsInGrid)
            {
                string m;
                if(!ValidateRowCellsValues(row, row.Tag as BaseEntityObject, out m))
                {
                    if (message != "") 
                        message += "\n ";
                    message += m;

                    dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows.IndexOf(row);

                    return false;        
                }
            }

            return true;
        }

        #endregion

        #region public void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public void ApplyChanges(bool ignoreCondition = false)
        {
            IEnumerable<DataGridViewRow> rowsInGrid =
               dataGridView.Rows.OfType<DataGridViewRow>()
                                .Where(r => r.Tag is BaseEntityObject)
                                .ToArray();
            foreach (DataGridViewRow row in rowsInGrid)
            {
                ApplyRowCellsValues(row, row.Tag as BaseEntityObject);
            }

	        if (!ignoreCondition)
	        {
				IEnumerable<BaseEntityObject> newItemsInGrid =
				rowsInGrid.Select(r => r.Tag as BaseEntityObject)
						  .Where(i => i.ItemId <= 0);

				_sourceCollection.AddRange(newItemsInGrid);
			}
        }
        #endregion

        #region private void Save()
        private void Save()
        {
            try
            {
                foreach (BaseEntityObject o in _sourceCollection)
                {
                    GlobalObjects.NewKeeper.Save(o);
                }
                //в исходной коллекции остаются только действительные элементы
                _sourceCollection = _sourceCollection.Where(i => i.ItemId > 0 && i.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save smsEventType", ex);
            }
        }
        #endregion

        #region private void SearchItem(string stringToSearch)
        ///<summary>
        /// Функция для поиска подстроки в списке в элементах списка 
        ///</summary>
        private void SearchItem(string stringToSearch)
        {
            //int searchStartIndex = 0;
            //очистка выделенных элементов списка
            ClearSelectedItems();
            List<DataGridViewRow> findItems = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string rowString = "";
                if (_searchCache.ContainsKey(row))
                    rowString = _searchCache[row];
                else
                {
                    rowString = row.Cells.Cast<DataGridViewCell>()
                        .Where(rowCell => rowCell.Value != null)
                        .Aggregate(rowString, (current, rowCell) => current + rowCell.Value.ToString());
                    _searchCache.Add(row, rowString);
                }
                string pattern = ".*";
                //читается так:
                // . - любой одиночный символ * -0 или более раз
                foreach (char c in stringToSearch)
                {
                    pattern += c + ".*";
                    //читается так: буква из строки поиска
                    // . - любой одиночный символ * -0 или более раз
                }
                Match m = Regex.Match(rowString, pattern);
                if (m.Success)
                {
                    row.Selected = true;
                    findItems.Add(row);
                }
            }

            //DataGridViewRow row = dataGridView.FindItemWithText(stringToSearch, true, searchStartIndex);
            //while (row != null && searchStartIndex < dataGridView.Rows.Count)
            //{
            //    row.Selected = true;
            //    findItems.Add(row);
            //    searchStartIndex = dataGridView.Rows.IndexOf(row) + 1;
            //    if (searchStartIndex >= dataGridView.Rows.Count)
            //        break;
            //    row = dataGridView.FindItemWithText(stringToSearch, true, searchStartIndex);
            //}
            if (findItems.Count > 0)
            {
                dataGridView.Focus();
                dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows.IndexOf(findItems[0]);
                quickSearchControl.SuccessBackgroundColor = true;
            }
            else
                quickSearchControl.SuccessBackgroundColor = false;
        }

        #endregion

        #region private void DataGridViewDefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        private void DataGridViewDefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewCell cell in e.Row.Cells)
            {
                PropertyInfo propertyInfo = cell.OwningColumn.Tag as PropertyInfo;
                if (propertyInfo == null) continue;

                #region Определение ЭУ
                
                if (cell is DataGridViewCheckBoxCell)
                {
                    cell.Value = true;
                    continue;
                }
                if(cell is DataGridViewComboBoxCell)
                {
                    cell.Value = null;
                    continue;
                }
                if (cell is DataGridViewCalendarCell)
                {
                    cell.Value = DateTime.Today;
                    continue;
                }
                if (cell is DataGridViewNumericUpDownCell)
                {
                    DataGridViewNumericUpDownCell nudc = (DataGridViewNumericUpDownCell)cell;
                    MinMaxValueAttribute mmValue =
                        (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                    nudc.Value = mmValue != null ? mmValue.Min : 0;
                    continue;
                }
                if (cell is DataGridViewTextBoxCell)
                {
                    cell.Value = "";
                }

                #endregion
            }
        }
        #endregion

        #region private void DataGridViewMouseClick(object sender, MouseEventArgs e)
        private void DataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (quickSearchControl.Text == "Quick Search" || string.IsNullOrEmpty(quickSearchControl.Text))
            {
                _clearSearch = true;
            }
        }
		#endregion

		#region private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)

		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
	    {
		    if (CellValueChanged != null)
			    CellValueChanged.Invoke(this, e);
	    }

	    #endregion

		#region private void DataGridViewKeyPress(object sender, KeyPressEventArgs e)
		private void DataGridViewKeyPress(object sender, KeyPressEventArgs e)
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

        #region private void DataGridViewColumnHeaderMouseClick(object sender, ColumnClickEventArgs e)

        private void DataGridViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SortItems(e.ColumnIndex);
            SetRowsBackColor();
        }

        #endregion

        #region private void DataGridViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)

        private void DataGridViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        #region protected virtual void DataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        /// <summary>
        /// Реагирует на двойной щелчок мыши по ячейкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void DataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem == null || !_canOpenEditFormOnDoubleClick) return;
	        
			var form = ScreenAndFormManager.GetEditForm(SelectedItem);
			if (form.ShowDialog() == DialogResult.OK)
            {
                DataGridViewRow r = dataGridView.Rows[dataGridView.Rows.IndexOf(dataGridView.SelectedRows[0])];
                r.Cells.Clear();
                r.Cells.AddRange(GetRowCells(SelectedItem));
            }
            
        }
        #endregion

        #region private void DataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        private void DataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            PreResultRowList.Remove(e.Row);
            _searchCache.Remove(e.Row);

            BaseEntityObject item = e.Row.Tag as BaseEntityObject;
            if(item != null)
            {
                if(item.ItemId > 0)
                {
                    //Если элемент сохранен в БД, то он помечается как недействительный
                    item.IsDeleted = true;
                }
                else
                {
                    //Если элемент не был сохранен в БД, то он удаляется из исходной коллекции
                    _sourceCollection.Remove(item);
                }
            }
        }
        #endregion

        #region private void DataGridViewSelectionChanged(object sender, EventArgs e)
        private void DataGridViewSelectionChanged(object sender, EventArgs e)
        {
            linkLabelDelete.Enabled = dataGridView.SelectedRows.Count > 0;

            if (SelectedItemsChanged != null)
                SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(_selectedItemsList.Count));
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //dataGridView.Rows.Add(1);
            //ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
            //BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
            //CommonEditorForm form = new CommonEditorForm(item);

            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    dataGridView.Rows.Add(1);
            //    DataGridViewRow r = dataGridView.Rows[dataGridView.Rows.Count - 1];
            //    GetRowCellsValues(r, form.CurrentObject);
            //    //if (r != null)
            //    //{
                    
            //    //    //try
            //    //    //{
            //    //    //    dataGridView.DataError += dataGridView_DataError;
            //    //    //    dataGridView.Rows.Add(r);
            //    //    //}
            //    //    //catch (Exception ex)
            //    //    //{
            //    //    //    Program.Provider.Logger.Log("error while create datagridview item", ex);
            //    //    //}
            //    //    //finally
            //    //    //{
            //    //    //    dataGridView.DataError -= dataGridView_DataError;
            //    //    //}
            //    //}
            //} 
            ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
            if(ci == null)
                return;
            BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
            dataGridView.Rows.Add(1);
            DataGridViewRow r = dataGridView.Rows[dataGridView.Rows.Count - 1];
            r.ReadOnly = _readOnly;
            SetRowCellsValues(r, item);
            r.Tag = item;
            
            PreResultRowList.Add(r);
        }
        #endregion

        #region private void LinkLabelDeleteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelDeleteLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedItems == null || SelectedItems.Count == 0) 
                return;

            DialogResult confirmResult =
                MessageBox.Show( SelectedItem != null
                        ? "Do you really want to delete selected Item ?"
                        : "Do you really want to delete selected Items ? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                ICommonCollection selectedItems = SelectedItems;

                for (int i = 0; i < selectedItems.Count; i++)
                {
                    try
                    {
                        IBaseEntityObject o = selectedItems[i];
                        if (o != null)
                            o.IsDeleted = true;
                        DataGridViewRow row =
                            dataGridView.Rows.OfType<DataGridViewRow>().FirstOrDefault(r => Equals(r.Tag, o));
                        if (row != null)
                            dataGridView.Rows.Remove(row);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to delete item: Parent container is invalid", "Operation failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)

        //private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)
        //{
        //    Point po = ((DataGridView)sender).CurrentCellAddress;

        //    DataGridViewCell cell = ((DataGridView)sender).CurrentCell;
        //    if (cell is DataGridViewLookupCell)
        //    {
        //        dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    }
        //    //if (po.X == ColumnDate.Index || po.X == ColumnClosed.Index)
        //    //    dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //}
        #endregion

        #region private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.Provider.Logger.Log("error while create datagridview item", e.Exception);
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

            if (_viewedType == null)
                return;

            int columnsWidth = 0;
            //определение своиств типа
            List<PropertyInfo> preProrerty = GetTypeProperties();
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                preProrerty.Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();
            for (int i = 0; i < ColumnHeaderList.Count; i++)
            {
                if (i >= properties.Count)
                {
                    ColumnHeaderList[i].Width = (int)(dataGridView.Width * 0.1f);
                    continue;
                }
                ListViewDataAttribute attr =
                    (ListViewDataAttribute)properties[i].GetCustomAttributes(typeof(ListViewDataAttribute), false).FirstOrDefault();
                if(attr != null)
                    ColumnHeaderList[i].Width = (int)(attr.HeaderWidth < 1 ? dataGridView.Width * attr.HeaderWidth : attr.HeaderWidth);
                else ColumnHeaderList[i].Width = (dataGridView.Width / properties.Count);

                columnsWidth += ColumnHeaderList[i].Width;
            }

            if (columnsWidth >= dataGridView.Width) 
                return;
            double c = (double)dataGridView.Width/columnsWidth;
            for (int i = 0; i < ColumnHeaderList.Count; i++)
            {
                if (i >= properties.Count)
                {
                    ColumnHeaderList[i].Width = (int)(dataGridView.Width * 0.1f * c);
                    continue;
                }
                ListViewDataAttribute attr =
                    (ListViewDataAttribute)properties[i].GetCustomAttributes(typeof(ListViewDataAttribute), false).FirstOrDefault();
                if (attr != null)
                    ColumnHeaderList[i].Width = (int)(ColumnHeaderList[i].Width * c);
                else ColumnHeaderList[i].Width = (dataGridView.Width / properties.Count);

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

	            try
	            {
		            FillDisplayerRequestedParams(e);
		            DisplayerRequested(this, e);
	            }
	            catch (Exception ex)
	            {
					Program.Provider.Logger.Log("Error while opening record", ex);
				}
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

	    public event EventHandler CellValueChanged;

	    #endregion
    }

    internal class CommonDataGridViewControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("ViewedType");
            properties.Remove("ViewedTypeProperties");
        }
    }
}
