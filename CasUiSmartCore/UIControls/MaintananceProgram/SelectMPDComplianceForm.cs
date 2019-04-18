using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// Форма, позволяющая делать выбор MPD Item-ов при для введения выполнения
    /// <br/> при вводе выполнения Maintenance Check-а
    ///</summary>
    public partial class SelectMPDComplianceForm : MetroForm
    {
        #region Fields
        
        private CommonCollection<MaintenanceDirective> _mpdsForSelect = new CommonCollection<MaintenanceDirective>();
        
        #endregion

        #region Properties

        ///<summary>
        /// Возвращает список выбранных MPD Item
        ///</summary>
        public IEnumerable<MaintenanceDirective> MaintenanceDirectives
        {
            get
            {
                List<MaintenanceDirective> directives = new List<MaintenanceDirective>();
                foreach (DataGridViewRow row in dataGridViewItems.Rows)
                {
                    if(!(row.Tag is MaintenanceDirective) 
                        || row.Cells.Count < 2 
                        || !(row.Cells[1] is DataGridViewCheckBoxCell)) 
                        continue;

                    MaintenanceDirective mpd = row.Tag as MaintenanceDirective;

                    DataGridViewCheckBoxCell mpdCell = (DataGridViewCheckBoxCell)row.Cells[1];

                    if ((bool)mpdCell.Value)
                        directives.Add(mpd);
                }
                return directives;
            }
        }

        #endregion

        #region Constructors

        ///<summary>
        ///</summary>
        private SelectMPDComplianceForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public SelectMPDComplianceForm(IEnumerable<MaintenanceDirective> maintenanceDirectives)
            : this()
        {
            if(_mpdsForSelect == null)
                _mpdsForSelect = new CommonCollection<MaintenanceDirective>();
            _mpdsForSelect.AddRange(maintenanceDirectives);

            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            dataGridViewItems.Rows.Clear();

            if(_mpdsForSelect == null)return;

            foreach (MaintenanceDirective mpd in _mpdsForSelect)
            {
                DataGridViewRow row = new DataGridViewRow {Tag = mpd};
                DataGridViewCell discCell = new DataGridViewTextBoxCell {Value = mpd.ToString()};
                DataGridViewCell selectCell = new DataGridViewCheckBoxCell { Value = true };
                
                row.Cells.AddRange(new[]{discCell,selectCell});
                
                dataGridViewItems.Rows.Add(row);
            }
        }
        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)
        private void ButtonOkClick(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #endregion
    }
}
