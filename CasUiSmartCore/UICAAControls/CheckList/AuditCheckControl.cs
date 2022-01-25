using System.Windows.Forms;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class AuditCheckControl : UserControl
    {
        public  AuditCheckRecord AuditCheckRecord;

        #region Constructors
        public AuditCheckControl()
        {
            InitializeComponent();
        }

        public AuditCheckControl(AuditCheckRecord auditCheckRecord) : this()
        {
            AuditCheckRecord = auditCheckRecord;
            UpdateInformation();
        }

        
        #endregion

        public void ApplyChanges()
        {
            AuditCheckRecord.IsChecked = checkBox1.Checked;
        }


        public void EnableCheckBox(bool flag)
        {
            checkBox1.Enabled = flag;
        }


        private void UpdateInformation()
        {
            metroTextBoxRemark.Text = AuditCheckRecord.CheckListRecord.Remark;
            labelType.Text = AuditCheckRecord.CheckListRecord.Option.ToString();
            checkBox1.Checked = AuditCheckRecord.IsChecked;
        }
    }
}
