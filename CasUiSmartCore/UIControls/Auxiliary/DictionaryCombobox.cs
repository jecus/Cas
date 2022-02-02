using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для представления определенного словаря
    /// </summary>
    [Designer(typeof(DictionaryComboboxDesigner))]
    public partial class DictionaryComboBox : UserControl, IReference
    {
        #region Fields

        private Type _type;
        private ScreenControl _screenControl;
        private IDictionaryCollection _typeItemsCollection;
        private IDictionaryItem _selectedItem;

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
        public DictionaryComboBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

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
                buttonEdit.ForeColor = value;
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

        #region public Type Type { get; set; }
        ///<summary>
        ///</summary>
        public Type Type
        {
            get { return _type; }
            set
            {
                _type = value; 
                if(_type != null)
                    UpdateInformation();
            }
        }
        #endregion

        #region public ScreenControl ScreenControl { get; set; }
        ///<summary>
        ///</summary>
        public ScreenControl ScreenControl
        {
            get { return _screenControl; }
            set
            {
                _screenControl = value;
            }
        }
        #endregion

        #region public Dictionary SelectedItem

        /// <summary>
        /// Выбранный элемент (установка)
        /// </summary>
        public IDictionaryItem SelectedItem
        {
            get
            {
                if (comboBoxReason != null && comboBoxReason.SelectedItem != null 
                    && comboBoxReason.SelectedItem.ToString() != "N/A") 
                    return (IDictionaryItem)comboBoxReason.SelectedItem;
                return null;
            }
            set
            {
                if (comboBoxReason == null || value == null) return;

                foreach (object item in
                    comboBoxReason.Items.Cast<object>().Where(item => (item is IDictionaryItem) && item.ToString() == value.ToString()))
                {
                    comboBoxReason.SelectedItem = item;
                    break;
                }
                _selectedItem = value;
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
                if (comboBoxReason != null)
                    return comboBoxReason.Text;
                return "";
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

        #region private void ComboBoxLostFocus(object sender, EventArgs e)

        private void ComboBoxLostFocus(object sender, EventArgs e)
        {
            if (comboBoxReason.Text == "")
                comboBoxReason.Text = notApplicableText;
            else
                for (int i = 0; i < _typeItemsCollection.Count; i++)
                {
                    IDictionaryItem d = _typeItemsCollection[i];
                    string ataChapter = comboBoxReason.Text;
                    int value;
                    if (comboBoxReason.Text.Length == 1 && int.TryParse(comboBoxReason.Text, out value))
                        ataChapter = "0" + comboBoxReason.Text;
                    if (d.FullName.ToLower() == ataChapter.ToLower())
                        Text = d.FullName;
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

        #region private void AdjustSizes()
        private void AdjustSizes()
        {
            Height = comboBoxReason.PreferredHeight;

            int comboboxWidth = Width;
            if (buttonEdit.Visible)
                comboboxWidth -= buttonEdit.Width;
            comboBoxReason.Width = comboboxWidth;
            comboBoxReason.DropDownWidth = Width;
        }
        #endregion

        #region private void comboBoxReason_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedItemId = 
                comboBoxReason.SelectedItem != null && comboBoxReason.SelectedItem.ToString() != "N/A" 
                ? ((IDictionaryItem)comboBoxReason.SelectedItem).ItemId : -1;

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

                if (_typeItemsCollection != null)
                {
                    foreach (BaseEntityObject dic in _typeItemsCollection
                                                     .OfType<BaseEntityObject>()
                                                     .Where(i => i.ToString().ToLowerInvariant().Contains(
                                                               _filterString.ToLowerInvariant())))
                    {
                        comboBoxReason.Items.Add(dic);
                    }
                }
                comboBoxReason.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxReason.SelectionStart = _filterString.Length;
            }
        }
        #endregion

        #region private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // if (InvokeRequired) 
            //     BeginInvoke(new Action(UpdateItems));
            // else UpdateItems();
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

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (_screenControl != null && _screenControl.IsDisposed)
                _screenControl = null;
            if (_screenControl == null)
            {
                _screenControl = new CommonListScreen(_type);
            }
            
            //Отписка от событий, что бы они не были подписаны 2 и более раз
            _screenControl.EntityRemoving -= ScreenControlEntityRemoving;
            _screenControl.EntityRemoved -= ScreenControlEntityRemoved;
            //Подписка на события
            _screenControl.EntityRemoving += ScreenControlEntityRemoving;
            _screenControl.EntityRemoved += ScreenControlEntityRemoved;

            if (null != DisplayerRequested)
            {
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
                refe.RequestedEntity = _screenControl;
                refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                DisplayerRequested(this, refe);
            }
        }

        #endregion

        #region private UpdateInformation()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        private void UpdateInformation()
        {
            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;

            if(_type.IsSubclassOf(typeof(AbstractDictionary)))
            {
                try
                {
                    if(GlobalObjects.CasEnvironment != null)
                        _typeItemsCollection = GlobalObjects.CasEnvironment.GetDictionary(_type);
                    else _typeItemsCollection = GlobalObjects.CaaEnvironment.GetDictionary(_type);
                }
                catch (Exception)
                {
                    _typeItemsCollection = null;
                }   
            }

            if (_type.IsSubclassOf(typeof(StaticDictionary)))
            {
                try
                {
                    PropertyInfo p = _type.GetProperty("Items");

                    ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);
                    _typeItemsCollection = (IDictionaryCollection)p.GetValue(instance, null);
                }
                catch (Exception)
                {
                    _typeItemsCollection = null;
                }  
            }

            UpdateItems();

            LostFocus += ComboBoxLostFocus;
            GotFocus += ATAChapterComboBoxGotFocus;
            
            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
        }
		#endregion

		#region public void AddItem(IDictionaryItem item)

		public void AddItem(IDictionaryItem item)
	    {
		    comboBoxReason.Items.Add(item);
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
            if(_typeItemsCollection != null)
            {
                foreach (IDictionaryItem dic in _typeItemsCollection.GetValidEntries().OfType<IDictionaryItem>().OrderBy(i => i.ToString()))
                    comboBoxReason.Items.Add(dic);
                if (_lastSelectedItemId > 0)
                    comboBoxReason.SelectedItem = _typeItemsCollection.GetItemById(_lastSelectedItemId);
            }
            
            if (_selectedItem != null)
                comboBoxReason.SelectedItem = _selectedItem;
            else comboBoxReason.Text = defaultText;
        }
        #endregion

        #region protected override void OnFontChanged(EventArgs e)
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Height = comboBoxReason.PreferredHeight;
            comboBoxReason.Width = Width - buttonEdit.Width;
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustSizes();
        }
        #endregion

        #region private void ScreenControlEntityRemoving(object sender, EntityCancelEventArgs e)

        private void ScreenControlEntityRemoving(object sender, EntityCancelEventArgs e)
        {
            if(e.Entity == _screenControl)
                e.Cancel = true;
        }
        #endregion

        #region private void ScreenControlEntityRemoved(object sender, EventArgs e)

        private void ScreenControlEntityRemoved(object sender, EventArgs e)
        {
            _screenControl.EntityRemoving -= ScreenControlEntityRemoving;
            _screenControl.EntityRemoved -= ScreenControlEntityRemoved;
        }
        #endregion

        #endregion

        #region Events

        #region public new event EventHandler PaddingChanged
        ///<summary>
        /// Происходит при заполении элемента управления
        ///</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
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
        private void InvokeSelectedIndexChanged()
        {
            EventHandler handler = SelectedIndexChanged;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #endregion

	    public void UpdateDepartment(int departmentItemId)
	    {
			comboBoxReason.Items.Clear();
		    comboBoxReason.Items.Add("N/A");
		    if (_typeItemsCollection != null)
		    {

			    if (departmentItemId > 0)
			    {
				    foreach (var dic in _typeItemsCollection.GetValidEntries().OfType<Locations>().Where(i => i.LocationsType?.Department?.ItemId == departmentItemId).OrderBy(i => i.ToString()))
					    comboBoxReason.Items.Add(dic);
				}
			    else
			    {
					foreach (var dic in _typeItemsCollection.GetValidEntries().OfType<Locations>().OrderBy(i => i.ToString()))
						comboBoxReason.Items.Add(dic);
				}

			    
			    if (_lastSelectedItemId > 0)
				    comboBoxReason.SelectedItem = _typeItemsCollection.GetItemById(_lastSelectedItemId);
		    }

		    if (_selectedItem != null)
			    comboBoxReason.SelectedItem = _selectedItem;
		    else comboBoxReason.Text = defaultText;
		}
    }

    #region internal class DictionaryComboboxDesigner : ControlDesigner

    internal class DictionaryComboboxDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("SelectedItem");
            properties.Remove("ScreenControl");
            properties.Remove("Type");
        }
    }
    #endregion
}
