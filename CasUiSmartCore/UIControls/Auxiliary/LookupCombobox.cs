using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для представления определенного словаря
    /// </summary>
    [Designer(typeof(LookupComboboxDesigner))]
    public partial class LookupCombobox : UserControl, IReference
    {
        #region Fields

        private bool _ignoreConditions;
        private Type _type;

        private bool _buttonCreateVisible = true;
        private bool _buttonEditVisible = true;
        private bool _buttonViewListVisible = true;
        private bool _buttonReloadVisible = true;

        private const int EmSetreadonly = 0xCF;
        private const int WmEnable = 0xA;

        private bool _comboboxReadOnly;
        private bool _doReload;

        private Type _addScreenControlType;
        private object [] _addScreenControlParams;
        private string _addScreenControlDisplayerText = "";

        private Type _editScreenControlType;
        private string _editScreenControlDisplayerText = "";

        private Type _listScreenControlType;
        private object[] _itemsScreenControlParams;
        protected ICommonCollection TypeItemsCollection;
        private BaseEntityObject _selectedItem;

        private Func<object [], ICommonCollection> _loadObjectsDelegate;
        
        private object _filterParam1;
        private object _filterParam2;
        private object _filterParam3;

        private string _filterString = "";
        private string defaultText = "Select Item";
        private string notApplicableText = "N/A NOT APPLICABLE";
        private int _lastSelectedItemId = -1;
        #endregion

        #region Implementation of IReference

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        #endregion

        #region public DisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        #endregion

        #region public ReflectionTypes ReflectionType
        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        ///<summary>
        ///</summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для представления определенного словаря
        /// </summary>
        public LookupCombobox()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Properties

        #region protected override Size DefaultSize
        protected override Size DefaultSize
        {
            get
            {
                return new Size(144, PreferredSize.Height);
            }
        }
        #endregion

        //#region  public override Font Font
        ///// <devdoc>
        /////    <para>
        /////       Возвращает или задает шрифт комбобокса.
        /////    </para>
        ///// </devdoc>
        //public override Font Font
        //{
        //    get { return comboBoxReason.Font; }
        //    set
        //    {
        //        comboBoxReason.Font = value;
        //    }
        //}
        //#endregion

        #region public bool ComboboxEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, Доступен ли Combobox
        /// </summary>
        [Category("Layout"), Description("Доступен ли Combobox")]
        [DefaultValue(true)]
        public bool ComboboxEnabled
        {
            get { return comboBoxReason.Enabled; }
            set
            {
                 comboBoxReason.Enabled = value;
            }
        }
        #endregion

        #region public ComboBoxStyle ComboBoxStyle
        /// <summary>
        /// Возвращает или устанавливает значение стиля поля со списком
        /// </summary>
        [Category("Layout"), Description("Стиль Combobox -а")]
        [DefaultValue(ComboBoxStyle.DropDown)]
        public ComboBoxStyle ComboBoxStyle
        {
            get { return comboBoxReason.DropDownStyle; }
            set
            {
                comboBoxReason.DropDownStyle = value;
            }
        }
        #endregion

        #region public bool ComboboxReadOnly
        ///// <summary>
        ///// Возвращает или устанавливает значение, Доступен ли Combobox только для чтения
        ///// </summary>
        //[Category("Layout"), Description("Доступен ли Combobox только для чтения")]
        //[DefaultValue(false)]
        //public bool ComboboxReadOnly
        //{
        //    get { return _comboboxReadOnly; }
        //    set
        //    {
        //        _comboboxReadOnly = value;
        //        SetReadOnly(comboBoxReason, _comboboxReadOnly);
        //    }
        //}


        #endregion

        #region public bool CreateButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, Доступна ли кнопка Create
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Create")]
        [DefaultValue(true)]
        public bool CreateButtonEnabled
        {
            get { return richReferenceButtonCreate.Enabled; }
            set { richReferenceButtonCreate.Enabled = value; }
        }

        #endregion

        #region public bool EditButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, доступна ли кнопка Edit
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Edit")]
        [DefaultValue(true)]
        public bool EditButtonEnabled
        {
            get { return richReferenceButtonEdit.Enabled; }
            set { richReferenceButtonEdit.Enabled = value; }
        }

        #endregion

        #region public bool EditEnabled

        /// <devdoc>
        ///    <para>
        ///       Возвращает или задает цвет шрифта комбобокса.
        ///    </para>
        /// </devdoc>
        [Category("Layout"), Description("Доступно ли редактирование")]
        [DefaultValue(true)]
        public bool EditEnabled
        {
            get 
            { 
                return comboBoxReason.Enabled
                        || richReferenceButtonCreate.Enabled
                        || richReferenceButtonViewList.Enabled
                        || richReferenceButtonReload.Enabled;
            }
            set
            {
                comboBoxReason.Enabled = value;
                richReferenceButtonCreate.Enabled = value;
                richReferenceButtonEdit.Enabled = true;
                richReferenceButtonViewList.Enabled = value;
                richReferenceButtonReload.Enabled = value;
            }
        }
        #endregion

        #region public override Color ForeColor
        /// <devdoc>
        ///    <para>
        ///       Возвращает или задает цвет шрифта комбобокса.
        ///    </para>
        /// </devdoc>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                comboBoxReason.ForeColor = value;
                richReferenceButtonViewList.ForeColor = value;
                richReferenceButtonCreate.ForeColor = value;
                richReferenceButtonEdit.ForeColor = value;
                richReferenceButtonReload.ForeColor = value;
            }
        }
        #endregion

        #region public override Size MaximumSize
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = new Size(value.Width, 0);
            }
        }
        #endregion

        #region public override Size MinimumSize
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set
            {
                base.MinimumSize = new Size(value.Width, 0);
            }
        }
        #endregion

        #region public new Padding Padding
        /// <devdoc>
        ///    <para>
        ///    <para>[To be supplied.]</para>
        ///    </para>
        /// </devdoc>
        [Browsable(false),
         EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        #endregion

        #region public bool ReloadButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, Доступна ли кнопка Reload
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка Reload")]
        [DefaultValue(true)]
        public bool ReloadButtonEnabled
        {
            get { return richReferenceButtonReload.Enabled; }
            set { richReferenceButtonReload.Enabled = value; }
        }

        #endregion

        #region public bool ViewListButtonEnabled
        /// <summary>
        /// Возвращает или устанавливает значение, Доступна ли кнопка View list
        /// </summary>
        [Category("Layout"), Description("Доступна ли кнопка View list")]
        [DefaultValue(true)]
        public bool ViewListButtonEnabled
        {
            get { return richReferenceButtonViewList.Enabled; }
            set { richReferenceButtonViewList.Enabled = value; }
        }

        #endregion

        #endregion

        #region Properties

        #region public Func<BaseEntityObject, BaseEntityObject, ICommonCollection> LoadObjectsFunc { set; }
        ///<summary>
        /// Функция загрузки объектов
        ///</summary>
        public Func<object [], ICommonCollection> LoadObjectsFunc
        {
            set
            {
                _loadObjectsDelegate = value;
            }
        }
        #endregion

        #region public object FilterParam1 { set; }
        ///<summary>
        /// параметр для загрузки объектов
        ///</summary>
        public object FilterParam1
        {
            set
            {
                _filterParam1 = value;
            }
        }
        #endregion

        #region public object FilterParam2 { set; }
        ///<summary>
        /// параметр для загрузки объектов
        ///</summary>
        public object FilterParam2
        {
            set
            {
                _filterParam2 = value;
            }
        }
        #endregion

        #region public object FilterParam3 { set; }
        ///<summary>
        /// параметр для загрузки объектов
        ///</summary>
        public object FilterParam3
        {
            set
            {
                _filterParam3 = value;
            }
        }
        #endregion

        #region public BaseEntityObject SelectedItem

        /// <summary>
        /// Выбранный элемент (установка)
        /// </summary>
        public BaseEntityObject SelectedItem
        {
            get
            {
                if (comboBoxReason != null && comboBoxReason.SelectedItem != null 
                    && comboBoxReason.SelectedItem.ToString() != "N/A")
                    return (BaseEntityObject)comboBoxReason.SelectedItem;
                return null;
            }
            set
            {
                if (comboBoxReason == null || value == null)
                {
                    richReferenceButtonEdit.Enabled = false;
                    richReferenceButtonCreate.Enabled = true;
                    return;
                }

                foreach (BaseEntityObject item in
                         comboBoxReason.Items.OfType<BaseEntityObject>().Where(item => item.ItemId == value.ItemId))
                {
                    comboBoxReason.SelectedItem = item;
                    break;
                }

                _selectedItem = value;
                _lastSelectedItemId = _selectedItem != null ? _selectedItem.ItemId : -1;
            }
        }

        #endregion

        #region public Int32 SelectedItemId

        /// <summary>
        /// Возвращает Id выбранного элемента (или-1) 
        /// <br/> или делает выбранным элемент с переданным id (или не делает если элемента с переданным id нет)
        /// </summary>
        public Int32 SelectedItemId
        {
            get
            {
                if (comboBoxReason != null && comboBoxReason.SelectedItem != null
                    && comboBoxReason.SelectedItem.ToString() != "N/A")
                    return ((BaseEntityObject)comboBoxReason.SelectedItem).ItemId;
                return -1;
            }
            set
            {
                if (comboBoxReason == null) return;
                if (comboBoxReason.Items.Count <= 0)
                {
                    _lastSelectedItemId = value;
                    return;
                }

                comboBoxReason.SelectedItem = 
                    comboBoxReason.Items.OfType<BaseEntityObject>().FirstOrDefault(item => item.ItemId == value);
                richReferenceButtonEdit.Enabled = _lastSelectedItemId > 0;
                richReferenceButtonCreate.Enabled = _lastSelectedItemId < 0;
            }
        }

        #endregion

        #region public bool ButtonCreateVisible
        /// <summary>
        /// Возвращает или устанавливает значение видимости кнопки добаления нового элемента
        /// </summary>
        [Category("Appearance"), Description("Видна ли кнопка добаления нового элемента")]
        [DefaultValue(true)]
        public bool ButtonCreateVisible
        {
            get { return _buttonCreateVisible; }
            set
            {
                _buttonCreateVisible = value;
                richReferenceButtonCreate.Visible = value;
                AdjustSizes();
            }
        }
        #endregion

        #region public bool ButtonEditVisible
        /// <summary>
        /// Возвращает или устанавливает значение видимости кнопки редактирования выбранного элемента
        /// </summary>
        [Category("Appearance"), Description("Видна ли кнопка редактирования выбранного элемента")]
        [DefaultValue(true)]
        public bool ButtonEditVisible
        {
            get { return _buttonEditVisible; }
            set
            {
                _buttonEditVisible = value;
                richReferenceButtonEdit.Visible = value;
                AdjustSizes();
            }
        }
        #endregion

        #region public bool ButtonViewListVisible
        /// <summary>
        /// Возвращает или устанавливает значение видимости кнопки отображения списка элементов
        /// </summary>
        [Category("Appearance"), Description("Видна ли кнопка отображения списка элементов")]
        [DefaultValue(true)]
        public bool ButtonViewListVisible
        {
            get { return _buttonViewListVisible; }
            set
            {
                _buttonViewListVisible = value;
                richReferenceButtonViewList.Visible = value;
                AdjustSizes();
            }
        }
        #endregion

        #region public bool ButtonReloadVisible
        /// <summary>
        /// Возвращает или устанавливает значение видимости кнопки обновления
        /// </summary>
        [Category("Appearance"), Description("Видна ли кнопка обновления")]
        [DefaultValue(true)]
        public bool ButtonReloadVisible
        {
            get { return _buttonReloadVisible; }
            set
            {
                _buttonReloadVisible = value;
                richReferenceButtonReload.Visible = value;
                AdjustSizes();
            }
        }
        #endregion

        #region public Type Type { get; set; }
        ///<summary>
        /// Тиа, элементы которого будут отображениы в справочнике
        ///</summary>
        public Type Type
        {
            get { return _type; }
            set
            {
                _type = value;

                if (_type == null) return;
                if (_type.IsSubclassOf(typeof (StaticDictionary)))
                {
                    ButtonReloadVisible = false;
                }
                UpdateInformation();
            }
        }
        #endregion

        #region public new bool Enabled

        /// <summary>
        /// Возвращает или задает текст, сопоставляемый с элементом управления
        /// </summary>
        public new bool Enabled
        {
            get
            {
                if (comboBoxReason != null)
                    return comboBoxReason.Enabled;
                return true;
            }
            set
            {
                if (comboBoxReason == null)
                    return;

                comboBoxReason.Enabled = value;
                
                richReferenceButtonCreate.Enabled = value;
                richReferenceButtonViewList.Enabled = value;
                richReferenceButtonEdit.Enabled = value;
                richReferenceButtonReload.Enabled = value;
            }
        }

        #endregion

        #region public override string Text

        /// <summary>
        /// Возвращает или задает текст, сопоставляемый с элементом управления
        /// </summary>
        public override string Text
        {
            get
            {
				if (comboBoxReason != null && comboBoxReason.Text != "Select Item")
					return comboBoxReason.Text;
				return "N/A";
			}
            set
            {
                if (comboBoxReason == null || value == null)
                    return;

                comboBoxReason.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region DLLImport

        [DllImport("user32")]
        private static extern int FindWindowExA(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32")]
        private static extern int SendMessageA(int hWnd, int wMsg, Int16 wParam, Int16 lParam);

        #endregion

        #region public void SetAddScreenControl<T>(object [] parameters) where T : ScreenControl

        ///<summary>
        /// Задает тип экрана для добавления элементов
        ///</summary>
        ///<param name="parameters">Параметры для конструктора экрана для добавления</param>
        ///<param name="addScreenDisplayerText">Текст вкладки экрана для добавления</param>
        public void SetAddScreenControl<T>(object[] parameters, string addScreenDisplayerText) where T : ScreenControl
        {
            _addScreenControlType = typeof(T);
            _addScreenControlParams = parameters;
            _addScreenControlDisplayerText = addScreenDisplayerText;
        }
        #endregion

        #region  public void SetEditScreenControl<T>() where T : ScreenControl
        ///<summary>
        /// Задает тип экрана для редактирования элементов
        ///</summary>
        ///<param name="editScreenDisplayrText">Текст вкладки экрана для редактирования</param>
        public void SetEditScreenControl<T>(string editScreenDisplayrText) where T : ScreenControl
        {
            _editScreenControlType = typeof(T);
            _editScreenControlDisplayerText = editScreenDisplayrText;
        }
        #endregion

        #region public void SetItemsScreenControl<T>(object[] parameters, string itemsScreenDisplayerText) where T : ScreenControl

        ///<summary>
        /// Задает тип экрана для добавления элементов
        ///</summary>
        ///<param name="parameters">Параметры для конструктора экрана элементов</param>
        ///<param name="itemsScreenDisplayerText">Текст вкладки экрана элементов</param>
        public void SetItemsScreenControl<T>(object[] parameters, string itemsScreenDisplayerText) where T : ScreenControl
        {
            _listScreenControlType = typeof(T);
            _itemsScreenControlParams = parameters;
            DisplayerText = itemsScreenDisplayerText;
        }
        #endregion

        #region public void SetType(Type type, bool ignoreContitions) 
        ///<summary>
        /// Тиа, элементы которого будут отображениы в справочнике
        ///</summary>
        public void SetType(Type type, bool ignoreContitions = false)
        {
            _ignoreConditions = ignoreContitions;
            
            Type = type;
        }
        #endregion

        public void ResetSelected()
        {
	        comboBoxReason.SelectedIndex = -1;
        }


        #region private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(50);

            _doReload = false;

            if (_loadObjectsDelegate != null)
            {
                string key = _loadObjectsDelegate.Method.Name;

                key += _filterParam1 != null ? _filterParam1.GetType().Name + _filterParam1 : "";
                key += _filterParam2 != null ? _filterParam2.GetType().Name + _filterParam2 : "";
                key += _filterParam3 != null ? _filterParam3.GetType().Name + _filterParam3 : "";

                if (GlobalObjects.CasEnvironment != null)
                {
                    if (GlobalObjects.CasEnvironment.TempCollections.ContainsKey(key))
                    {
                        try
                        {
                            TypeItemsCollection = GlobalObjects.CasEnvironment.TempCollections[key];

                            if (TypeItemsCollection != null && _doReload)
                            {
                                //коллекция содержится во временных коллекциях
                                //выполнение очистки и перезагрузки коллекции
                                TypeItemsCollection.Clear();
                                TypeItemsCollection.AddRange(_loadObjectsDelegate(new[] { _filterParam1, _filterParam2 }));
                            }
                        }
                        catch (Exception ex)
                        {
                            Program.Provider.Logger.Log("Error while load lookup combobox items. Params:" + key, ex);
                            TypeItemsCollection = null;
                        }
                    }
                    else
                    {
                        if (GlobalObjects.CaaEnvironment.TempCollections.ContainsKey(key))
                        {
                            try
                            {
                                TypeItemsCollection = GlobalObjects.CaaEnvironment.TempCollections[key];

                                if (TypeItemsCollection != null && _doReload)
                                {
                                    //коллекция содержится во временных коллекциях
                                    //выполнение очистки и перезагрузки коллекции
                                    TypeItemsCollection.Clear();
                                    TypeItemsCollection.AddRange(_loadObjectsDelegate(new[]
                                        {_filterParam1, _filterParam2}));
                                }
                            }
                            catch (Exception ex)
                            {
                                Program.Provider.Logger.Log("Error while load lookup combobox items. Params:" + key,
                                    ex);
                                TypeItemsCollection = null;
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        TypeItemsCollection = _loadObjectsDelegate(new[] { _filterParam1, _filterParam2 });

                        if (GlobalObjects.CasEnvironment != null)
                        {
                            if (!GlobalObjects.CasEnvironment.TempCollections.ContainsKey(key))
                                GlobalObjects.CasEnvironment.TempCollections.Add(key, TypeItemsCollection);
                        }
                        else
                        {
                            if (!GlobalObjects.CaaEnvironment.TempCollections.ContainsKey(key))
                                GlobalObjects.CaaEnvironment.TempCollections.Add(key, TypeItemsCollection);
                        }
                            

                        if (backgroundWorker.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while load lookup combobox items. Params:" + key, ex);
                        TypeItemsCollection = null;
                    }
                }
            }
            else if (_type != null)
            {
                if (TypeItemsCollection != null)
                    TypeItemsCollection.Clear();

                if (_type.IsSubclassOf(typeof(StaticDictionary)))
                {
                    PropertyInfo p = _type.GetProperty("Items");

                    ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                    Type genericType = typeof(CommonCollection<>);
                    Type genericList = genericType.MakeGenericType(_type);
                    TypeItemsCollection = (ICommonCollection)Activator.CreateInstance(genericList);
                    TypeItemsCollection.AddRange((IDictionaryCollection)p.GetValue(instance, null));
                    TypeItemsCollection.RemoveById(-1);
                }
				else if (_type.IsSubclassOf(typeof(AbstractDictionary)))
                {
					Type genericType = typeof(CommonCollection<>);
	                Type genericList = genericType.MakeGenericType(_type);
	                TypeItemsCollection = (ICommonCollection)Activator.CreateInstance(genericList);
                    if (GlobalObjects.CasEnvironment != null)
                        TypeItemsCollection.AddRange(GlobalObjects.CasEnvironment.GetDictionary(_type));
                    else
                        TypeItemsCollection.AddRange(GlobalObjects.CaaEnvironment.GetDictionary(_type));
	                TypeItemsCollection.RemoveById(-1);
				}
                else
                {
                    if(GlobalObjects.CasEnvironment != null)
                        TypeItemsCollection = GlobalObjects.CasEnvironment.Loader.GetObjectCollection(_type, loadChild: true, ignoreConditions:_ignoreConditions);
                    else
                    {
                        var dto = (CAADtoAttribute)_type.GetCustomAttributes(typeof(CAADtoAttribute), false).FirstOrDefault();
                        var res = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList(dto.Type, _type, loadChild: true);
                        TypeItemsCollection = new CommonCollection<BaseEntityObject>((IEnumerable<BaseEntityObject>) res);
                    }
                }
            }

            backgroundWorker.ReportProgress(100);
        }
        #endregion

        #region private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)

        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarLoad.Value = e.ProgressPercentage;
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateItems();

            LostFocus -= ComboBoxLostFocus;
            LostFocus += ComboBoxLostFocus;
            GotFocus -= ATAChapterComboBoxGotFocus;
            GotFocus += ATAChapterComboBoxGotFocus;

            if (TypeItemsCollection != null)
            {
                TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;
                TypeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
            }

        }
        #endregion

        #region public void CancelAsync()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsync()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();

                WaitCancelForm wcf = new WaitCancelForm(backgroundWorker)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                wcf.ShowDialog();

                while (backgroundWorker.IsBusy)
                {
                    Thread.Sleep(500);
                }
            }
        }
        #endregion

        #region private static void SetReadOnly(ComboBox comBox, bool readOnly)
        private static void SetReadOnly(ComboBox comBox, bool readOnly)
        {
            int hWndEdit = FindWindowExA(comBox.Handle.ToInt32(), 0, "Edit", "");
            if (hWndEdit != 0)
            {
                SendMessageA(hWndEdit, WmEnable, Convert.ToInt16(true), 0);
                SendMessageA(hWndEdit, EmSetreadonly, Convert.ToInt16(readOnly), 0);
            }
        }
        #endregion

        #region private void ComboBoxLostFocus(object sender, EventArgs e)

        private void ComboBoxLostFocus(object sender, EventArgs e)
        {
            if (comboBoxReason.Text == "")
                comboBoxReason.Text = notApplicableText;
            else
                for (int i = 0; i < TypeItemsCollection.Count; i++)
                {
                    IBaseEntityObject d = TypeItemsCollection[i];
                    string ataChapter = comboBoxReason.Text;
                    int value;
                    if (comboBoxReason.Text.Length == 1 && int.TryParse(comboBoxReason.Text, out value))
                        ataChapter = "0" + comboBoxReason.Text;
                    if (d.ToString().ToLower() == ataChapter.ToLower())
                        Text = d.ToString();
                }
        }

        #endregion

        #region private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)

        private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)
        {
            if (comboBoxReason.Text == defaultText || comboBoxReason.Text == notApplicableText)
                comboBoxReason.Text = "";
        }

        #endregion

        #region private void comboBoxReason_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedItemId = 
                comboBoxReason.SelectedItem != null && comboBoxReason.SelectedItem.ToString() != "N/A" 
                ? ((BaseEntityObject)comboBoxReason.SelectedItem).ItemId : -1;

            //Блокировка кнопки редактирования элемента
            richReferenceButtonEdit.Enabled = _lastSelectedItemId > 0;
            richReferenceButtonCreate.Enabled = _lastSelectedItemId < 0;

            InvokeSelectedIndexChanged();
        }
        #endregion

        #region private void ComboBoxReasonTextUpdate(object sender, EventArgs e)
        private void ComboBoxReasonTextUpdate(object sender, EventArgs e)
        {
            _filterString = comboBoxReason.Text;

            if (string.IsNullOrEmpty(_filterString))
                UpdateItems();
            else
            {
                comboBoxReason.Items.Clear();
                comboBoxReason.Items.Add("N/A");

                if (TypeItemsCollection != null)
                {
                    foreach (BaseEntityObject dic in TypeItemsCollection
                                                     .OfType<BaseEntityObject>()
                                                     .Where(i => i.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
                    {
                        comboBoxReason.Items.Add(dic);
                    }

                    richReferenceButtonEdit.Enabled = false;
                    richReferenceButtonCreate.Enabled = false;
                }
                comboBoxReason.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxReason.SelectionStart = _filterString.Length;
            }
        }
        #endregion

        #region private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (InvokeRequired) 
                BeginInvoke(new Action(UpdateItems));
            else UpdateItems();
        }
        #endregion

        #region public void ClearValue()

        /// <summary>
        /// Обнуляет выбранную ATA-главу и ставит текст "Select ATA Chapter"
        /// </summary>
        public void ClearValue()
        {
            Text = defaultText;
        }

        #endregion

        #region private void ButtonCreateClick(object sender, EventArgs e)
        private void ButtonCreateClick(object sender, EventArgs e)
        {
            if (null != DisplayerRequested && _addScreenControlType != null)
            {
                try
                {
                    //преобразование переданных параметров в Type[]
                    Type[] parameters = _addScreenControlParams != null
                        ? _addScreenControlParams.Where(p => p != null).Select(p => p.GetType()).ToArray()
                        : new Type[0];
                    //поиск у типа конструктора с параметрами, типы которых соответвуют переданным параметрам для конструктора
                    ConstructorInfo ci = _addScreenControlType.GetConstructor(parameters);
                    //создание экземпляра Экрана
                    ScreenControl addScreenControl = (ScreenControl)ci.Invoke(_addScreenControlParams);

                    if (addScreenControl != null)
                    {
                        //Блокирование нажатий кнопок "Оператор" и 1-го дочернего элемента (Самолет/Склад)
                        //Запрет на нажатие кнопки Save and add
                        addScreenControl.NextClickable = false;
                        addScreenControl.OperatorClickable = false;
                        addScreenControl.PrevClickable = false;
                        addScreenControl.ChildClickable = false;
                        addScreenControl.SaveAndAddButtonEnabled = false;
                        addScreenControl.EntityRemoved += AddScreenControlDisplayerRemoving;

                        ReflectionTypes reflection = ReflectionType;
                        Keyboard k = new Keyboard();
                        if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                        ReferenceEventArgs refe = null != Displayer
                            ? new ReferenceEventArgs(Entity, reflection, Displayer, _addScreenControlDisplayerText)
                            : new ReferenceEventArgs(Entity, reflection, _addScreenControlDisplayerText);

                        refe.RequestedEntity = addScreenControl;
                        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        DisplayerRequested(this, refe);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while create add screen", ex);
                }
            }
            else if (_type != null)
            {
                try
                {
                    CommonEditorForm form;
                    if (_type.Name == typeof(AircraftWorkerCategory).Name)
                    {
                        form = new AircraftWorkerCategoryForm(new AircraftWorkerCategory());
                    }
                    else if (_type.Name == typeof(Product).Name)
                    {
                        form = new ProductForm(new Product());
                    }
                    else if (_type.Name == typeof(GoodStandart).Name)
                    {
                        form = new GoodStandardForm(new GoodStandart());
                    }
                    else
                    {
                        ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                        BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
                        form = new CommonEditorForm(item);
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        BaseEntityObject addedObject = form.CurrentObject;

                        if (addedObject != null && addedObject.ItemId > 0 && TypeItemsCollection != null)
                        {
                            _lastSelectedItemId = addedObject.ItemId;
                            TypeItemsCollection.Add(addedObject);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while building new object", ex);
                }
            }
        }
        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            BaseEntityObject o = comboBoxReason.SelectedItem as BaseEntityObject;

            if (null != DisplayerRequested && _editScreenControlType != null && o != null)
            {
                try
                {
                    
                    //поиск у типа конструктора с одним int параметром
                    ConstructorInfo ci = _editScreenControlType.GetConstructor(new[]{typeof(int)});
                    ScreenControl editScreenControl = null;
                    if (ci != null)
                    {
                        //создание экземпляра Экрана
                        editScreenControl = (ScreenControl) ci.Invoke(new object[] {o.ItemId});
                    }
                    else
                    {
                        //поиск у типа конструктора с одним параметром,
                        //тип котогого произведен от BaseEntityObject
                        ci = _editScreenControlType.GetConstructor(new[] { o.GetType() });
                        if (ci != null)
                        {
                            //создание экземпляра Экрана
                            editScreenControl = (ScreenControl)ci.Invoke(new object[] { o });
                        }
                    }
                    
                    if(editScreenControl != null)
                    {
                        //Блокирование нажатий кнопок "Оператор" и 1-го дочернего элемента (Самолет/Склад)
                        //Запрет на нажатие кнопки Save and add
                        editScreenControl.NextClickable = false;
                        editScreenControl.OperatorClickable = false;
                        editScreenControl.PrevClickable = false;
                        editScreenControl.ChildClickable = false;
                        editScreenControl.SaveAndAddButtonEnabled = false;
                        editScreenControl.EntityRemoved += EditScreenControlDisplayerRemoving;

                        ReflectionTypes reflection = ReflectionType;
                        Keyboard k = new Keyboard();
                        if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                        ReferenceEventArgs refe = null != Displayer
                            ? new ReferenceEventArgs(Entity, reflection, Displayer, _editScreenControlDisplayerText + ". " + o)
                            : new ReferenceEventArgs(Entity, reflection, _editScreenControlDisplayerText + ". " + o);

                        refe.RequestedEntity = editScreenControl;
                        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        DisplayerRequested(this, refe);    
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while create edit screen", ex);
                }
            }
            else if (o != null)
            {
                var editForm = ScreenAndFormManager.GetEditForm(o);
                    
                if (editForm.ShowDialog() != DialogResult.OK) 
                    return;
                _lastSelectedItemId = o.ItemId;
                if (TypeItemsCollection.ContainsById(o.ItemId))
                {
                    TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;
                    TypeItemsCollection.RemoveById(o.ItemId);
                    TypeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
                }
                TypeItemsCollection.Add(o);           
            }
        }
        #endregion

        #region private void ButtonViewListClick(object sender, EventArgs e)
        private void ButtonViewListClick(object sender, EventArgs e)
        {
            if (DisplayerRequested == null)
                return;
            if (_listScreenControlType != null)
            {
                try
                {
                    //преобразование переданных параметров в Type[]
                    Type[] parameters = _itemsScreenControlParams != null
                        ? _itemsScreenControlParams.Where(p => p != null).Select(p => p.GetType()).ToArray()
                        : new Type[0];
                    //поиск у типа конструктора с параметрами, типы которых соответвуют переданным параметрам для конструктора
                    ConstructorInfo ci = _listScreenControlType.GetConstructor(parameters);
                    //создание экземпляра Экрана
                    ScreenControl itemsScreenControl = null;
                    if (ci != null)
                    {
                        //создание экземпляра Экрана
                        itemsScreenControl = (ScreenControl)ci.Invoke(_itemsScreenControlParams);
                    }
                    else
                    {
                        //поиск у типа конструктора без параметров,
                        ci = _listScreenControlType.GetConstructor(new Type[0]);
                        if (ci != null)
                        {
                            //создание экземпляра Экрана
                            itemsScreenControl = (ScreenControl)ci.Invoke(new object[0]);
                        }
                    }

                    if (itemsScreenControl != null)
                    {
                        //Блокирование нажатий кнопок "Оператор" и 1-го дочернего элемента (Самолет/Склад)
                        //Запрет на нажатие кнопки Save and add
                        itemsScreenControl.NextClickable = false;
                        itemsScreenControl.OperatorClickable = false;
                        itemsScreenControl.PrevClickable = false;
                        itemsScreenControl.ChildClickable = false;

                        ReflectionTypes reflection = ReflectionType;
                        Keyboard k = new Keyboard();
                        if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                        ReferenceEventArgs refe = null != Displayer
                            ? new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText)
                            : new ReferenceEventArgs(Entity, reflection, DisplayerText);

                        refe.RequestedEntity = itemsScreenControl;
                        refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                        DisplayerRequested(this, refe);
                    }
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while create items screen", ex);
                }
            }
            else if (_type != null)
            {
                try
                {
                    //специальный тип для отображения списка объектов переданного типа не задан
                    //используется общий ЭУ для отображения списка элементов

                    ReflectionTypes reflection = ReflectionType;
                    Keyboard k = new Keyboard();
                    if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                    ReferenceEventArgs refe = null != Displayer
                        ? new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText)
                        : new ReferenceEventArgs(Entity, reflection, DisplayerText);

                    DescriptionAttribute da =
                        _type.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                    string typeName = da != null && !string.IsNullOrEmpty(da.Description)
                        ? da.Description
                        : _type.Name;

                    refe.DisplayerText = typeName;

	                if (typeName == "Product")
	                {
                        if (GlobalObjects.CasEnvironment != null)
                            refe.RequestedEntity = new ProductListScreen(GlobalObjects.CasEnvironment.Operators[0]);
                        else refe.RequestedEntity = new ProductListScreen(GlobalObjects.CaaEnvironment.Operators[0]);
                    }
	                else refe.RequestedEntity = new CommonListScreen(_type);
                    
                    refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    DisplayerRequested(this, refe);

                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while create items screen", ex);
                }   
            }
        }
        #endregion

        #region private void ButtonReloadClick(object sender, EventArgs e)

        private void ButtonReloadClick(object sender, EventArgs e)
        {
            if (TypeItemsCollection != null)
                TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;

            _doReload = true;

            //backgroundWorker.RunWorkerAsync();

            if (_loadObjectsDelegate != null)
            {
                string key = _loadObjectsDelegate.Method.Name;
                //key += _filterParam1 != null ? _filterParam1.GetType().Name + _filterParam1.ItemId : "";
                //key += _filterParam2 != null ? _filterParam2.GetType().Name + _filterParam2.ItemId : "";
                //key += _filterParam3 != null ? _filterParam3.GetType().Name + _filterParam3.ItemId : "";
                key += _filterParam1 != null ? _filterParam1.GetType().Name + _filterParam1 : "";
                key += _filterParam2 != null ? _filterParam2.GetType().Name + _filterParam2 : "";
                key += _filterParam3 != null ? _filterParam3.GetType().Name + _filterParam3 : "";

                if ((GlobalObjects.CasEnvironment != null ? GlobalObjects.CasEnvironment.TempCollections.ContainsKey(key) : GlobalObjects.CaaEnvironment.TempCollections.ContainsKey(key)))
                {
                    try
                    {
                        if (GlobalObjects.CasEnvironment != null)
                            TypeItemsCollection = GlobalObjects.CasEnvironment.TempCollections[key];
                        else TypeItemsCollection = GlobalObjects.CaaEnvironment.TempCollections[key];

                        if (TypeItemsCollection != null && _doReload)
                        {
                            //коллекция содержится во временных коллекциях
                            //выполнение очистки и перезагрузки коллекции
                            TypeItemsCollection.Clear();
                            TypeItemsCollection.AddRange(_loadObjectsDelegate(new[] { _filterParam1, _filterParam2 }));
                        }
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while load lookup combobox items", ex);
                        TypeItemsCollection = null;
                    }
                }
                else
                {
                    try
                    {
                        TypeItemsCollection = _loadObjectsDelegate(new[] { _filterParam1, _filterParam2 });
                        if (GlobalObjects.CasEnvironment != null)
                            GlobalObjects.CasEnvironment.TempCollections.Add(key, TypeItemsCollection);
                        else
                            GlobalObjects.CaaEnvironment.TempCollections.Add(key, TypeItemsCollection);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while load lookup combobox items", ex);
                        TypeItemsCollection = null;
                    }
                }
            }
            else if (_type != null)
            {
                if (TypeItemsCollection != null)
                    TypeItemsCollection.Clear();

                if (_type.IsSubclassOf(typeof(StaticDictionary)))
                {
                    PropertyInfo p = _type.GetProperty("Items");

                    ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                    Type genericType = typeof(CommonCollection<>);
                    Type genericList = genericType.MakeGenericType(_type);
                    TypeItemsCollection = (ICommonCollection)Activator.CreateInstance(genericList);
                    TypeItemsCollection.AddRange((IDictionaryCollection)p.GetValue(instance, null));
                    TypeItemsCollection.RemoveById(-1);
                }
                else
                {
                    if(GlobalObjects.CasEnvironment != null)
                        TypeItemsCollection = GlobalObjects.CasEnvironment.Loader.GetObjectCollection(_type, loadChild: true);
                    else
                    {
                        var dto = (CAADtoAttribute)_type.GetCustomAttributes(typeof(CAADtoAttribute), false).FirstOrDefault();
                        var res = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList(dto.Type, _type, loadChild: true);
                        TypeItemsCollection = new CommonCollection<BaseEntityObject>((IEnumerable<BaseEntityObject>)res);
                    }
                }    
            }

            UpdateItems();

            LostFocus -= ComboBoxLostFocus;
            LostFocus += ComboBoxLostFocus;
            GotFocus -= ATAChapterComboBoxGotFocus;
            GotFocus += ATAChapterComboBoxGotFocus;

            if (TypeItemsCollection != null)
                TypeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
        }
        #endregion

        #region public void UpdateInformation()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        public void UpdateInformation()
        {
            if (TypeItemsCollection != null)
                TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;

            _doReload = false;
            if(!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }
        #endregion
       
        #region private UpdateItems()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        private void UpdateItems()
        {
            comboBoxReason.Items.Clear();
            comboBoxReason.Items.Add("N/A");
            
            if(TypeItemsCollection != null)
            {
                comboBoxReason.Items.AddRange(TypeItemsCollection.ToArray());
                if (_lastSelectedItemId > 0)
                    comboBoxReason.SelectedItem = TypeItemsCollection.GetItemById(_lastSelectedItemId);
                else
                {
                    richReferenceButtonEdit.Enabled = false;
                    richReferenceButtonCreate.Enabled = true;
                }
                _selectedItem = comboBoxReason.SelectedItem as BaseEntityObject;
            }
            
            if (_selectedItem != null)
                comboBoxReason.SelectedItem = _selectedItem;
            else comboBoxReason.Text = defaultText;
            comboBoxReason.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion

        #region private void AdjustSizes()
        private void AdjustSizes()
        {
            Height = comboBoxReason.PreferredHeight;

            int comboboxWidth = Width;
            if (_buttonCreateVisible)
                comboboxWidth -= richReferenceButtonCreate.Width;
            if (_buttonEditVisible)
                comboboxWidth -= richReferenceButtonEdit.Width;
            if (_buttonViewListVisible)
                comboboxWidth -= richReferenceButtonViewList.Width;
            if (_buttonReloadVisible)
                comboboxWidth -= richReferenceButtonReload.Width;
            comboBoxReason.Width = comboboxWidth;
            comboBoxReason.DropDownWidth = Width;     
        }
        #endregion

        #region protected override void OnFontChanged(EventArgs e)
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Height = comboBoxReason.PreferredHeight;
            comboBoxReason.Width = Width - richReferenceButtonCreate.Width - richReferenceButtonEdit.Width - richReferenceButtonViewList.Width - richReferenceButtonReload.Width;
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustSizes();
        }
        #endregion

        #region private void AddScreenControlDisplayerRemoving(object sender, EventArgs e)

        private void AddScreenControlDisplayerRemoving(object sender, EventArgs e)
        {
            ScreenControl screenControl = sender as ScreenControl;

            if (screenControl == null) return;
            screenControl.EntityRemoved -= AddScreenControlDisplayerRemoving;

            if (!(screenControl is IEditScreenControl))
                return;

            BaseEntityObject addedObject = ((IEditScreenControl)screenControl).EditedObject;
            
            if(addedObject != null && addedObject.ItemId > 0 && TypeItemsCollection != null)
            {
                _lastSelectedItemId = addedObject.ItemId;
                TypeItemsCollection.Add(addedObject);
            }
        }
        #endregion

        #region private void EditScreenControlDisplayerRemoving(object sender, EventArgs e)

        private void EditScreenControlDisplayerRemoving(object sender, EventArgs e)
        {
            ScreenControl editScreenControl = sender as ScreenControl;

            if (editScreenControl == null) return;
            editScreenControl.EntityRemoved -= EditScreenControlDisplayerRemoving;

            if (!(editScreenControl is IEditScreenControl))
                return;

            BaseEntityObject editedObject = ((IEditScreenControl)editScreenControl).EditedObject;

            if (editedObject != null && editedObject.ItemId > 0 && TypeItemsCollection != null)
            {
                _lastSelectedItemId = editedObject.ItemId;
                if(TypeItemsCollection.ContainsById(editedObject.ItemId))
                {
                    TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;
                    TypeItemsCollection.RemoveById(editedObject.ItemId);
                    TypeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
                }
                TypeItemsCollection.Add(editedObject);
            }
        }
        #endregion

        #endregion

        #region Events

        #region public new event EventHandler PaddingChanged
        ///<summary>
        /// Происходит при заполении элемента управления
        ///</summary>
        [Browsable(false),
         EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }
        #endregion

        #region public event EventHandler SelectedIndexChanged;
        ///<summary>
        /// Возникает при изменении выбора в элементе управления
        ///</summary>
        [Category("Value changed")]
        [Description("Возникает при изменении выборав элементе управления")]
        public event EventHandler SelectedIndexChanged;

        ///<summary>
        /// Сигнализирует об изменении выбора в элементе управления
        ///</summary>
        protected virtual void InvokeSelectedIndexChanged()
        {
            EventHandler handler = SelectedIndexChanged;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #endregion
    }

    #region internal class LookupComboboxDesigner : ControlDesigner

    internal class LookupComboboxDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("SelectedItem");
            properties.Remove("LoadObjectsFunc");
            properties.Remove("ListScreenControl");
            properties.Remove("ScreenControl");
            properties.Remove("FilterParam1");
            properties.Remove("FilterParam2");
            properties.Remove("FilterParam3");
            properties.Remove("SelectedItemId");
        }

        public override SelectionRules SelectionRules
        {
            get { return base.SelectionRules & ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable); }
        }
    }
    #endregion
}
