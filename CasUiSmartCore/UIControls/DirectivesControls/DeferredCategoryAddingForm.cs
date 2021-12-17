using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DeferredCategoryAddingForm : MetroForm
    {
        #region Fields

        private Aircraft _currentAircraft;
        private DeferredCategory _defferedCategory;

        #endregion

        #region Constructors
        
        #region public DefferedCategoryAddingForm() 
        ///<summary>
        ///</summary>
        public DeferredCategoryAddingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DefferedCategoryAddingForm(Aircraft currentAircraft)
        ///<summary>
        ///</summary>
        public DeferredCategoryAddingForm(Aircraft currentAircraft)
        {
            _currentAircraft = currentAircraft;
            _defferedCategory = new DeferredCategory();

            InitializeComponent();

            UpdateInformation();
        }
        #endregion

        #region public DefferedCategoryAddingForm(Aircraft currentAircraft, DefferedCategory defferedCategory
        ///<summary>
        ///</summary>
        public DeferredCategoryAddingForm(Aircraft currentAircraft, DeferredCategory defferedCategory)
        {
            _currentAircraft = currentAircraft;
            _defferedCategory = defferedCategory;

            InitializeComponent();

            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Properties

        #region public DefferedCategory DefferedCategory
        ///<summary>
        /// Возвращает редактируемую категорию
        ///</summary>
        public DeferredCategory DefferedCategory
        {
            get { return _defferedCategory; }
        }
        #endregion
        
        #endregion

        #region Methods

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        public void UpdateInformation()
        {
            if(_defferedCategory == null) return;

            textBoxCategoryName.Text = _defferedCategory.FullName;
            lifelengthViewer_SinceEffDate.Lifelength = _defferedCategory.Threshold.FirstPerformanceSinceEffectiveDate;
            lifelengthViewer_FirstNotify.Lifelength = _defferedCategory.Threshold.FirstNotification;
            lifelengthViewer_Repeat.Lifelength = _defferedCategory.Threshold.RepeatInterval;
            lifelengthViewer_RepeatNotify.Lifelength = _defferedCategory.Threshold.RepeatNotification;
            
        }

        #endregion

        #region public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            if(textBoxCategoryName.Text != ""
                ||!lifelengthViewer_SinceEffDate.Lifelength.IsNullOrZero()
                || !lifelengthViewer_FirstNotify.Lifelength.IsNullOrZero()
                || !lifelengthViewer_Repeat.Lifelength.IsNullOrZero()
                || !lifelengthViewer_RepeatNotify.Lifelength.IsNullOrZero())
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private void Save()

        ///<summary>
        ///</summary>
        ///<returns></returns>
        private void Save()
        {
            if (!GetChangeStatus() || _defferedCategory == null) return;
            _defferedCategory.FullName = textBoxCategoryName.Text;
            _defferedCategory.Threshold.FirstPerformanceSinceEffectiveDate = lifelengthViewer_SinceEffDate.Lifelength;
            _defferedCategory.Threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
            _defferedCategory.Threshold.RepeatInterval = lifelengthViewer_Repeat.Lifelength;
            _defferedCategory.Threshold.RepeatNotification = lifelengthViewer_RepeatNotify.Lifelength;
            _defferedCategory.AircraftModel = _currentAircraft.Model;

            try
            {
                GlobalObjects.NewKeeper.Save(_defferedCategory);
            }
            catch(Exception exception)
            {
                Program.Provider.Logger.Log("Error while saving data", exception);    
            }

            return;
        }
        #endregion

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            Save();
            Close();
            DialogResult = DialogResult.OK;
        }
       
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
        
        #endregion
    }
}
