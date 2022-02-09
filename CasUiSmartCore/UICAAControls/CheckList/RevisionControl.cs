using System;
using System.Windows.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class RevisionControl : UserControl
    {
        public readonly CheckListRevisionRecord Record;

        public RevisionControl()
        {
            InitializeComponent();
        }

        public RevisionControl(CheckListRevisionRecord record) 
        {
            InitializeComponent();
            Record = record;
            EnableControls(false);
            UpdateInformation();

        }

        public void EnableControls(bool state)
        {
            metroTextBoxRemark.Enabled =
                metroTextBoxRevision.Enabled =
                dateTimePickerEffDate.Enabled =
                    dateTimePickerRevisionDate.Enabled = state;
        }

        private void UpdateInformation()
        {
            label1.Text = Record.Parent?.Type.ToString();
            metroTextBoxRemark.Text = Record.Parent?.Settings.Remark;
            metroTextBoxRevision.Text = Record.Parent?.Number;
            dateTimePickerRevisionDate.Value = Record.Parent.Date;
            dateTimePickerEffDate.Value = Record.Parent.EffDate;
        }

        public event EventHandler<EventArgs> Deleted;


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Deleted != null)
                Deleted.Invoke(this, EventArgs.Empty);
        }
    }
}
