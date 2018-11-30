using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DamageChartsAddingForm : Form
    {
        #region Fields

        private Aircraft _currentAircraft;
        private DamageChart _damageChart;

        #endregion

        #region Constructors
        
        #region public DamageChartsAddingForm() 
        ///<summary>
        ///</summary>
        public DamageChartsAddingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChartsAddingForm(Aircraft currentAircraft)
        ///<summary>
        ///</summary>
        public DamageChartsAddingForm(Aircraft currentAircraft)
        {
            _currentAircraft = currentAircraft;
            _damageChart = new DamageChart();

            InitializeComponent();

            UpdateInformation();
        }
        #endregion

        #region public DamageChartsAddingForm(Aircraft currentAircraft, DamageChart damageChart)
        ///<summary>
        ///</summary>
        public DamageChartsAddingForm(Aircraft currentAircraft, DamageChart damageChart)
        {
            _currentAircraft = currentAircraft;
            _damageChart = damageChart;

            InitializeComponent();

            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Properties

        #region public DamageChart DamageChart
        ///<summary>
        ///</summary>
        public DamageChart DamageChart
        {
            get { return _damageChart; }
            set
            {
                _damageChart = value;

            }
        }
        #endregion
        
        #endregion

        #region Methods

        #region public void UpdateInformation()
        ///<summary>
        ///</summary>
        public void UpdateInformation()
        {
            if(_damageChart == null) return;
            textBoxChartName.Text = _damageChart.ChartName;
            fileControlDamageFile.UpdateInfo(_damageChart.AttachedFile, "Adobe PDF Files|*.pdf",
                                 "This record does not contain a file proving the damege chart. Enclose PDF file to prove the compliance.",
                                 "Attached file proves the damage chart.");
        }

        #endregion

        #region public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            if(textBoxChartName.Text != _damageChart.ChartName
               || fileControlDamageFile.GetChangeStatus())
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
            if (!GetChangeStatus() || _damageChart == null) return;


            _damageChart.ChartName = textBoxChartName.Text;
            _damageChart.AircraftModel = _currentAircraft.Model;

            if(fileControlDamageFile.GetChangeStatus())
            {
                fileControlDamageFile.ApplyChanges();
                _damageChart.AttachedFile = fileControlDamageFile.AttachedFile;
            }
            try
            {
                GlobalObjects.DirectiveCore.AddDamageChart(_damageChart);
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
