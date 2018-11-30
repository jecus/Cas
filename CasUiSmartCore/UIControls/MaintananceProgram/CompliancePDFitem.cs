using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class CompliancePDFItem : UserControl
    {
        private MaintenanceCheck _currentCheck;
        private MaintenanceCheckRecord _maintenanceCheckRecord;

        #region Properties

        ///<summary>
        ///</summary>
        public MaintenanceCheck Check { get { return _currentCheck; } }
        ///<summary>
        ///</summary>
        public MaintenanceCheckRecord Record { get { return _maintenanceCheckRecord; } }
        /// <summary>
        /// Возвращает записи о выполнении по прикрепленным к чеку задачам, сделанные во время данного выполнения чека
        /// </summary>
        public IEnumerable<DirectiveRecord> BindDirectivesRecords
        {
            get
            {
                return flowLayoutPanelMpds.Controls.OfType<BindedMpdItemControl>()
                                                   .Where(c => c.MaintenanceDirectiveRecord != null)
                                                   .Select(c => c.MaintenanceDirectiveRecord);
            }
        }
        /// <summary>
        /// Задает дату выполнения чеков группы
        /// </summary>
        public DateTime ComplianceDate
        {
            set
            {
                foreach (BindedMpdItemControl control in flowLayoutPanelMpds.Controls.OfType<BindedMpdItemControl>())
                {
                    control.ComplianceDate = value;
                }
            }
        }
        #region public AttachedFile AttachedFile
        ///<summary>
        ///</summary>
        public AttachedFile AttachedFile
        {
            get
            {
                if(windowsFormAttachedFileControl1.GetChangeStatus())
                {
                    windowsFormAttachedFileControl1.ApplyChanges();
                }
                return windowsFormAttachedFileControl1.AttachedFile;
            }
        }
        #endregion

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public CompliancePDFItem()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public CompliancePDFItem(MaintenanceCheck maintenanceCheck)
            : this()
        {
            _currentCheck = maintenanceCheck;
            UpdateInformation();
        }

        ///<summary>
        ///</summary>
        public CompliancePDFItem(MaintenanceCheckRecord maintenanceCheckRecord) : this()
        {
            if(maintenanceCheckRecord == null)
                throw new ArgumentNullException("maintenanceCheckRecord", "must be not null");
            _maintenanceCheckRecord = maintenanceCheckRecord;
            _currentCheck = maintenanceCheckRecord.ParentCheck;

            UpdateInformation();
        }
        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            foreach (Control c in flowLayoutPanelMpds.Controls)
            {
                c.Dispose();
            }
            flowLayoutPanelMpds.Controls.Clear();

            if(_currentCheck == null)
                return;
            labelCheckName.Text = _currentCheck.Name + " check";
            if(_currentCheck.BindMpds.Count > 0)
            {
                extendableRichContainerTaskCards.Visible = true;
                extendableRichContainerTaskCards.LabelCaption.Text = _currentCheck.BindMpds.Count + " Task Cards";
      
                List<MaintenanceDirective> sortedMpds = 
                    _currentCheck.BindMpds.OrderBy(mpd => mpd.TaskNumberCheck).ToList();
                List<BindedMpdItemControl> bindedMpdItemControls = new List<BindedMpdItemControl>();
                for (int i = 0; i < sortedMpds.Count(); i++)
                {
                    BindedMpdItemControl bindedMpdItemControl = new BindedMpdItemControl(sortedMpds[i], Record);
                    if (i > 0) bindedMpdItemControl.ShowHeaders = false;
                    flowLayoutPanelMpds.Controls.Add(bindedMpdItemControl);  
                    bindedMpdItemControls.Add(bindedMpdItemControl);
                }

                checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

                int countChecked = bindedMpdItemControls.Count(bc => bc.Checked);
                int countUnChecked = bindedMpdItemControls.Count(bc => !bc.Checked);
                if (countChecked > 0 && countUnChecked > 0)
                    checkBoxSelectAll.CheckState = CheckState.Indeterminate;
                else if (countChecked > 0)
                    checkBoxSelectAll.CheckState = CheckState.Checked;
                else checkBoxSelectAll.CheckState = CheckState.Unchecked;
                
                checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;
            }
            else
            {
                extendableRichContainerTaskCards.Visible = false;
                Size = new System.Drawing.Size(569, 103);
            }

            if(_maintenanceCheckRecord != null)
            {
                windowsFormAttachedFileControl1.AttachedFile = _maintenanceCheckRecord.AttachedFile;
            }
        }
        #endregion

        #region public void ApplyChanges()
        public void ApplyChanges()
        {
            if(windowsFormAttachedFileControl1.GetChangeStatus())
            {
                windowsFormAttachedFileControl1.ApplyChanges();
            }
            foreach (BindedMpdItemControl control in flowLayoutPanelMpds.Controls.OfType<BindedMpdItemControl>())
            {
                control.ApplyChanges();
            }
        }
        #endregion

        #region private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        {
            IEnumerable<BindedMpdItemControl> bindedMpdItemControls =
                flowLayoutPanelMpds.Controls.OfType<BindedMpdItemControl>();
            if(bindedMpdItemControls.Count() == 0)
                return;
            foreach (BindedMpdItemControl bindedMpdItemControl in bindedMpdItemControls)
            {
                bindedMpdItemControl.Checked = checkBoxSelectAll.Checked;
            }
        }
        #endregion

        #region private void ExtendableRichContainerTaskCardsExtending(object sender, EventArgs e)

        private void ExtendableRichContainerTaskCardsExtending(object sender, EventArgs e)
        {
            flowLayoutPanelMpds.Visible = !flowLayoutPanelMpds.Visible;
        }
        #endregion

        #endregion
    }
}
