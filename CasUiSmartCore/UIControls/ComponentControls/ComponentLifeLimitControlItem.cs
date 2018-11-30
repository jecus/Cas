using System;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class ComponentLifeLimitControlItem : UserControl
    {
        #region Fields

        private readonly Component _currentComponent;
        private readonly LLPLifeLimitCategory _currentCategory;
        private ComponentLLPCategoryData _llpData;
        private Lifelength _limit;
        private Lifelength _remain;
        private bool _mainLimit;

        #endregion

        #region Properties

        #region public LLPLifeLimitCategory CurrentCategory
        ///<summary>
        /// Возвращает тукещую категорию LLP
        ///</summary>
        public LLPLifeLimitCategory CurrentCategory
        {
            get { return _currentCategory; }
        }

        #endregion

        #region public bool IsMainLimit
        ///<summary>
        /// Является ли этот лимит основным
        ///</summary>
        public bool IsMainLimit
        {
            get { return _mainLimit; }
            set
            {
                _mainLimit = value;
                radioButtonCurrent.Checked = value;
            }
        }

        #endregion

        #region public Lifelength LifeLimit
        ///<summary>
        /// Получает или задает значение лимита жизненного цикла
        ///</summary>
        public Lifelength LifeLimit
        {
            get { return lifelengthViewerLifeLimit.Lifelength; }
            set
            {
                _limit = value;
                lifelengthViewerLifeLimit.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength LifeLimitNotify
        ///<summary>
        /// получает или задает значение остатка/предупреждения
        ///</summary>
        public Lifelength LifeLimitNotify
        {
            get { return lifelengthViewerNotify.Lifelength; }
            set 
            {
                lifelengthViewerNotify.Lifelength = value;
                _remain = value; 
            }
        }

        #endregion

        #region public DetailLLPCategoryData LLPData
        ///<summary>
        ///</summary>
        public ComponentLLPCategoryData LLPData
        {
            get
            {
                if(_llpData == null)
                    _llpData = new ComponentLLPCategoryData();
                _llpData.LLPLifeLimit = lifelengthViewerLifeLimit.Lifelength;
                _llpData.Notify = lifelengthViewerNotify.Lifelength;
                return _llpData;
            }
            set
            {
                _llpData = value;
                if (_llpData != null)
                {
                    lifelengthViewerCurrent.Lifelength = _llpData.LLPLifelength;
                    lifelengthViewerRemain.Lifelength = _llpData.Remain;
                    lifelengthViewerNotify.Lifelength = _llpData.Notify;
                    lifelengthViewerLifeLimit.Lifelength = _llpData.LLPLifeLimit;
                }
                else
                {
                    lifelengthViewerCurrent.Lifelength = 
                    lifelengthViewerRemain.Lifelength = 
                    lifelengthViewerNotify.Lifelength = 
                    lifelengthViewerLifeLimit.Lifelength = Lifelength.Null;     
                }
            }
        }
        #endregion

        #endregion

        #region Constructors

        #region public DetailLifeLimitControlItem()
        ///<summary>
        ///</summary>
        public ComponentLifeLimitControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public DetailLifeLimitControlItem(Detail detail) : this()
        ///<summary>
        ///</summary>
        public ComponentLifeLimitControlItem(Component component) : this()
        {
            _currentComponent = component;
            _limit = component.LifeLimit;
            _remain = component.LifeLimitNotify;
            _mainLimit = true;
            UpdateContol();
            UpdateInformation();
        }
        #endregion

        #region public DetailLifeLimitControlItem(DetailLLPCategoryData llpData, bool mainLimit ):this()
        ///<summary>
        ///</summary>
        public ComponentLifeLimitControlItem(ComponentLLPCategoryData llpData, bool mainLimit ):this()
        {
	        lifelengthViewerLifeLimit.EnabledHours = false;
	        lifelengthViewerLifeLimit.EnabledCalendar = false;
	        lifelengthViewerNotify.EnabledHours = false;
	        lifelengthViewerNotify.EnabledCalendar = false;
	        lifelengthViewerRemain.EnabledHours = false;
	        lifelengthViewerRemain.EnabledCalendar = false;

			_currentCategory = llpData.ParentCategory;
            _llpData = llpData;
            _limit = llpData.LLPLifeLimit;
            _remain = llpData.Remain;
            _mainLimit = mainLimit;
            UpdateContol();
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods
        
        #region private void UpdateContol()
        
        private void UpdateContol()
        {
            if(_currentComponent != null)
            {
                radioButtonCurrent.Visible = false;
                lifelengthViewerLifeLimit.LeftHeader = "Life Limit:";
                lifelengthViewerNotify.LeftHeader = "Notify:";
                lifelengthViewerRemain.Visible = false;
                lifelengthViewerCurrent.Visible = false;
            }
            
            if(_currentCategory != null)
            {
                lifelengthViewerLifeLimit.LeftHeader = "Life Limit " +_currentCategory.Category + ":";
                if (_mainLimit)radioButtonCurrent.Checked = true;
            }
        }
        #endregion

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if(_llpData != null)
            { 
                lifelengthViewerLifeLimit.Lifelength = _llpData.LLPLifeLimit;
				lifelengthViewerCurrent.Lifelength = _llpData.LLPCurrent ?? _llpData.LLPTemp;
                lifelengthViewerNotify.Lifelength = _llpData.Notify;
                lifelengthViewerRemain.Lifelength = _llpData.Remain;
            }
            if(_currentComponent!= null)
            {
                lifelengthViewerLifeLimit.Lifelength = _currentComponent.LifeLimit;
                lifelengthViewerNotify.Lifelength = _currentComponent.LifeLimitNotify;    
            }
        }
        #endregion

        #region private void RadioButtonCurrentCheckedChanged(object sender, EventArgs e)
        private void RadioButtonCurrentCheckedChanged(object sender, EventArgs e)
        {
            IsMainLimit = true;
            if (LifeLimitChecked != null)
                LifeLimitChecked(this, e);
        }
        #endregion

        #endregion

        #region Events
        ///<summary>
        ///</summary>
        public event EventHandler LifeLimitChecked;  
        #endregion

    }
}
