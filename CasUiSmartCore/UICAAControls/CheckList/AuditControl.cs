using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class AuditControl : UserControl
    {
        public readonly CheckListRecords Record;

        #region Constructors
        public AuditControl()
        {
            InitializeComponent();
        }

        public AuditControl(CheckListRecords records) : this()
        {
            Record = records;
            UpdateControls();
            UpdateInformation();
        }

        

        #endregion

        public void ApplyChanges()
        {
            Record.Remark = metroTextBoxRemark.Text;
            Record.OptionNumber = (int)comboBoxOptionNumber.SelectedItem;
            Record.Option = (OptionType)comboBoxOptionType.SelectedItem;
        }


        private void UpdateInformation()
        {
            metroTextBoxRemark.Text = Record.Remark;
            comboBoxOptionNumber.SelectedItem = Record.OptionNumber;
            comboBoxOptionType.SelectedItem = Record.Option;
        }

        private void UpdateControls()
        {
            var numbers = new List<object> {1, 2, 3};
            comboBoxOptionNumber.Items.Clear();
            comboBoxOptionNumber.Items.AddRange(numbers.ToArray());
            comboBoxOptionNumber.SelectedIndex = 0;

            comboBoxOptionType.Items.Clear();
            comboBoxOptionType.Items.AddRange(OptionType.Items.OrderBy(i => i.ShortName).ToArray());
            comboBoxOptionType.SelectedIndex = 0;
        }

        public event EventHandler<EventArgs> Deleted;

        private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(Deleted != null)
                Deleted.Invoke(this, EventArgs.Empty);
        }
    }
}
