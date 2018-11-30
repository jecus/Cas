using System;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class ReplaceComponentFormItem : UserControl
    {
        #region Fields

        private Component _parentComponent;
        private readonly TransferRecord _parentDetailTransfer;
        private Component _replacedByComponent;
	    private readonly SmartCoreType _parentType;
	    private TransferRecord _replacedDetailByTransfer;

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public ReplaceComponentFormItem()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public ReplaceComponentFormItem(Component replacedComponent, Component replacedByComponent, SmartCoreType parentType)
        {
            _parentComponent = replacedComponent;
            _replacedByComponent = replacedByComponent;
	        _parentType = parentType;
	        ConfirmTransfer = true;

			InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public ReplaceComponentFormItem(Component replacedComponent, Component replacedByComponent, 
                                     TransferRecord replacedTransfer, TransferRecord replacedByTransfer, SmartCoreType parentType)
        {
            _parentComponent = replacedComponent;
            _parentDetailTransfer = replacedTransfer;
            _replacedByComponent = replacedByComponent;
            _replacedDetailByTransfer = replacedByTransfer;
	        _parentType = parentType;
	        ConfirmTransfer = true;

			InitializeComponent();
        }
        #endregion

        #region Properties

        #region public Detail ParentDetail
        ///<summary>
        ///</summary>
        public Component ParentComponent
        {
            get
            {
                return _parentComponent;
            }
            set
            {
                _parentComponent = value;
            }
        }
        #endregion

        #region public Detail ReplacedByDetail
        ///<summary>
        ///</summary>
        public Component ReplacedByComponent
        {
            get
            {
                return _replacedByComponent;
            }
            set
            {
                _replacedByComponent = value;
            }
        }
        #endregion

        #region public DateTime ReplacedByDate
        ///<summary>
        ///</summary>
        public DateTime ReplacedByDate
        {
            get
            {
                return dateTimePickerReplaceByDate.Value;
            }
        }
        #endregion

        #region public DateTime ConfirmDate
        ///<summary>
        ///</summary>
        public DateTime ConfirmDate
        {
            get
            {
                return dateTimePickerConfirmDate.Value;
            }
        }
        #endregion

		public bool ConfirmTransfer { get; set; }

        #region public TransferRecord ReplacedByDetailTransfer
        ///<summary>
        /// если форма в режиме инсталляции, то это запись об удалении заменяющей детали с
        /// данного самолета/склада
        /// усли в режиме удаления то это запись об устновке заменяющей детали 
        /// на данный склад, самолет
        ///</summary>
        public TransferRecord ReplacedByDetailTransfer
        {
            get
            {
                return _replacedDetailByTransfer;
            }
            set
            {
                _replacedDetailByTransfer = value;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        public void UpdateInformation(bool installed)
        {
			//TODO:костыль пересмотреть лоику метода
	        if (_parentType == SmartCoreType.Store || _parentType == SmartCoreType.Supplier)
	        {
		        dateTimePickerReplaceByDate.Visible = false;
		        comboBoxReplaceByDetail.Visible = false;
				this.Width = 680;
			}

           if(installed)
           {
               if (_parentComponent == null) dateTimePickerConfirmDate.Enabled = false;
               else
               {
                   textBoxReplacedDetails.Text = _parentComponent.ToString();
                   dateTimePickerConfirmDate.Enabled = true;
               }

               if (_replacedByComponent == null)
               {
                   comboBoxReplaceByDetail.Items.Add("No detail for replace");
                   comboBoxReplaceByDetail.SelectedIndex = 0;
                   dateTimePickerReplaceByDate.Enabled = false;
               }
               else
               {
                   comboBoxReplaceByDetail.Items.Add("No detail for replace");
                   comboBoxReplaceByDetail.Items.Add(_replacedByComponent);
                   comboBoxReplaceByDetail.SelectedIndex = 1;

                   dateTimePickerReplaceByDate.Value = _replacedDetailByTransfer != null
                                                           ? _replacedDetailByTransfer.TransferDate
                                                           : DateTime.Today;
                   dateTimePickerReplaceByDate.Enabled = false;
               }
           }
           else
           {
               if (_parentComponent == null) dateTimePickerConfirmDate.Enabled = false;
               else
               {
                   if (_parentDetailTransfer.FromAircraftId == 0 &&
                       _parentDetailTransfer.FromBaseComponentId == 0 &&
                       _parentDetailTransfer.FromStoreId == 0)
                   {
                       //Деталь только что добавлена, ни откуда не перемещалась
                       //Ограничением будет дата производства детали
                       dateTimePickerConfirmDate.MinDate = _parentComponent.ManufactureDate;
                   }
                   else
                   {
                       // Деталь была перемещена откуда - то,
                       // Ограничением будет дата начала перемещения
                       //dateTimePickerConfirmDate.MinDate = _parentDetailTransfer.StartTransferDate;
                   }
                   //dateTimePickerConfirmDate.MaxDate = DateTime.Now;

                   textBoxReplacedDetails.Text = _parentComponent.ToString();
                   dateTimePickerConfirmDate.Value = _parentDetailTransfer.TransferDate;
                   dateTimePickerConfirmDate.Enabled = false;
               }

               if (_replacedByComponent == null)
               {
                   comboBoxReplaceByDetail.Items.Add("No detail for replace");
                   comboBoxReplaceByDetail.SelectedIndex = 0;
                   dateTimePickerReplaceByDate.Enabled = false;
               }
               else
               {
                   comboBoxReplaceByDetail.Items.Add("No detail for replace");
                   comboBoxReplaceByDetail.Items.Add(_replacedByComponent);
                   comboBoxReplaceByDetail.SelectedIndex = 1;
                   
                   dateTimePickerReplaceByDate.MaxDate = DateTime.Now;
                   dateTimePickerReplaceByDate.Value = _replacedDetailByTransfer != null
                                                           ? _replacedDetailByTransfer.TransferDate
                                                           : DateTime.Today;
                   dateTimePickerReplaceByDate.Enabled = true;
               }
           }
        }
        
        #endregion

        #region public void ComboBoxReplaceByDetailSelectedIndexChanged(object sender, EventArgs e)
        ///<summary>
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        public void ComboBoxReplaceByDetailSelectedIndexChanged(object sender, EventArgs e)
        {
	        var selectedItem = ((ComboBox) sender).SelectedItem;


	        if (selectedItem is Component)
	        {
		        ReplacedByComponent = selectedItem as Component;
		        dateTimePickerReplaceByDate.Enabled = true;
			}
	        else
	        {
				ReplacedByComponent = null;
		        dateTimePickerReplaceByDate.Enabled = false;
			}
            InvokeReplaceByDetailChanged(e);
        }
        #endregion

        #endregion

        #region Events

        ///<summary>
        ///</summary>
        public event EventHandler ReplaceByDetailChanged;

        ///<summary>
        ///</summary>
        ///<param name="e"></param>
        private void InvokeReplaceByDetailChanged(EventArgs e)
        {
            EventHandler handler = ReplaceByDetailChanged;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
