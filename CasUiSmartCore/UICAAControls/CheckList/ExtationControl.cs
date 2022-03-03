using System;
using System.Windows.Forms;
using SmartCore.CAA.Audit;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class ExtationControl : UserControl
    {
        public readonly Extation Record;
        
        public ExtationControl()
        {
            InitializeComponent();
        }


        public ExtationControl(Extation record) : this()
        {
            Record = record;
            UpdateInformation();
        }

        
        public void ApplyChanges()
        {
            Record.Remark = textBoxRemarks.Text;
            Record.ExtationString = metroTextBoxExtation.Text;
        }
        
        private void UpdateInformation()
        {
            textBoxRemarks.Text = Record.Remark;
            metroTextBoxExtation.Text = Record.ExtationString;
        }
        
        public event EventHandler<EventArgs> Deleted;
        
        private void linkLabelAddNew_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Deleted != null)
                Deleted.Invoke(this, EventArgs.Empty);
        }
    }
}