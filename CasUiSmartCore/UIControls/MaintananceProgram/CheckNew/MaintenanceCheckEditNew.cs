using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CASTerms;
using MetroFramework.Forms;
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
        private List<MaintenanceCheckType> _checks;

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

            Task.Run(() => DoWork())
	            .ContinueWith(task => UpdateInformation(), TaskScheduler.FromCurrentSynchronizationContext());
        }



        #endregion

        #region Methods

        private void DoWork()
        {
	        _checks = new List<MaintenanceCheckType>();
            _checks.Clear();
            _checks.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<MaintenanceCheckTypeDTO, MaintenanceCheckType>());
        }

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
	        comboBoxCheckType.Items.Clear();
	        comboBoxCheckType.Items.AddRange(_checks.ToArray());
	        comboBoxCheckType.Items.Add(MaintenanceCheckType.Unknown);

            if (_maintenanceLiminationItem.ItemId > 0)
            {
                _textBoxName.Text = _maintenanceLiminationItem.Name;
                _lifelengthViewerInterval.Lifelength = _maintenanceLiminationItem.Interval;
                comboBoxCheckType.SelectedItem = _maintenanceLiminationItem.CheckType;

            }
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
            
            GlobalObjects.NewKeeper.Save(_maintenanceLiminationItem);
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
