using System;
using System.Windows.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class RevisionControl : UserControl
    {
        public readonly CheckListRevision Revision;

        public RevisionControl()
        {
            InitializeComponent();
        }

        public RevisionControl(CheckListRevision revision) 
        {
            InitializeComponent();
            Revision = revision;
            EnableControls(false);
            UpdateInformation();

        }

        public void EnableControls(bool state)
        {
            metroTextBoxRemark.Enabled =
                metroTextBoxRevision.Enabled =
                    dateTimePickerRevisionDate.Enabled = state;
        }

        private void UpdateInformation()
        {
            label1.Text = Revision.Type.ToString();
            metroTextBoxRemark.Text = Revision.Settings.Remark;
            metroTextBoxRevision.Text = Revision.Number;
            dateTimePickerRevisionDate.Value = Revision.Date;
            dateTimePickerEffDate.Value = Revision.EffDate;
        }

        public event EventHandler<EventArgs> Deleted;


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Deleted != null)
                Deleted.Invoke(this, EventArgs.Empty);
        }
    }
}
