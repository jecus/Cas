using System;
using System.Windows.Forms;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceCheckEditNew : MetroForm
    {
        #region Fields
        private MaintenanceCheck _maintenanceLiminationItem;
        private MaintenanceCheckCollection _allMaintenanceChecks = new MaintenanceCheckCollection();
        #endregion

        #region Constructor
        ///<summary>
        ///</summary>
        public MaintenanceCheckEditNew()
        {
            InitializeComponent();
        }
        ///<summary>
        ///</summary>
        ///<param name="maintenanceLiminationItem"></param>
        public MaintenanceCheckEditNew(MaintenanceCheck maintenanceLiminationItem) : this()
        {
            _maintenanceLiminationItem = maintenanceLiminationItem;
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (_maintenanceLiminationItem.ParentAircraft.ItemId > 0)
            {
                _textBoxName.Text = _maintenanceLiminationItem.Name;

               _lifelengthViewerInterval.Lifelength = _maintenanceLiminationItem.Interval;
            }
        }
        #endregion

        #region private void FillCheckType()
        private void FillCheckType()
        {

        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";
            if (comboBoxCheckType.SelectedItem == null)
            {
                message = "Select check type";
                return false;
            }
            
            return true;
        }

        #endregion

        #region private void Save()
        private void Save()
        {
            _maintenanceLiminationItem.Name = _textBoxName.Text;
            _maintenanceLiminationItem.CheckType = comboBoxCheckType.SelectedItem as MaintenanceCheckType ?? MaintenanceCheckType.Unknown;
            
            _maintenanceLiminationItem.Interval = _lifelengthViewerInterval.Lifelength;
            
            GlobalObjects.CasEnvironment.NewKeeper.Save(_maintenanceLiminationItem);
        }

        #endregion

        #region private void ButtonCancelClick(object sender, System.EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save();
            Close();
        }
        #endregion

        #endregion
    }
}
