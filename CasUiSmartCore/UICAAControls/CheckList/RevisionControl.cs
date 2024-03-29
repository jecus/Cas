﻿using System;
using System.Windows.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class RevisionControl : UserControl
    {
        public readonly EditionRevisionView Record;

        public RevisionControl()
        {
            InitializeComponent();
        }

        public RevisionControl(EditionRevisionView record) 
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
            label1.Text = Record.Type.ToString();
            metroTextBoxRemark.Text = Record.Remark;
            metroTextBoxRevision.Text = Record.Number.ToString();
            dateTimePickerRevisionDate.Value = Record.Date;
            dateTimePickerEffDate.Value = Record.EffDate;
        }
    }
}
