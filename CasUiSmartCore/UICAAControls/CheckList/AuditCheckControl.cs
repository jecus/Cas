using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class AuditCheckControl : UserControl
    {
        public readonly CheckListRecords Record;

        #region Constructors
        public AuditCheckControl()
        {
            InitializeComponent();
        }

        public AuditCheckControl(CheckListRecords records) : this()
        {
            Record = records;
            UpdateInformation();
        }

        
        #endregion

        public void ApplyChanges()
        {

        }


        private void UpdateInformation()
        {
            metroTextBoxRemark.Text = Record.Remark;
            labelType.Text = Record.Option.ToString();
        }
    }
}
