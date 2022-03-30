﻿using System;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    public partial class CheckListCAPItem : UserControl
    {
        private AuditCheck _currentAuditCheck;
        private readonly WorkFlowStatus _workFlowStatus;

        public CheckListCAPItem(AuditCheck currentAuditCheck, WorkFlowStatus workFlowStatus)
        {
            InitializeComponent();

            _currentAuditCheck = currentAuditCheck;
            _workFlowStatus = workFlowStatus;
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            buttonAccept.Visible = !(_workFlowStatus == WorkFlowStatus.Closed);
            labelStatus.Text = _workFlowStatus.ToString();

            if (_workFlowStatus == WorkFlowStatus.FAT)
            {
                metroTextBoxComment.Visible = true;
                label1label1.Visible = true;
            }

            if (_currentAuditCheck.WorkflowStatusId != _workFlowStatus.ItemId)
                EnableControls(false);
            else checkBoxItem.Checked = true;

        }

        public void EnableControls(bool enable)
        {
            foreach (var c in this.Controls.OfType<Control>())
            {
                if(c.GetType() == typeof(CheckBox))
                    continue;
                c.Enabled = enable;
            }
        }
        

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void ButtonWf_Click(object sender, EventArgs e)
        {
            var form = new WorkflowCommentsForm(_currentAuditCheck);
            form.ShowDialog();
            Focus();
            
        }
    }
}