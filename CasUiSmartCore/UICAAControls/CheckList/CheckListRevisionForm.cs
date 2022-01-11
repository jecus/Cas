using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA.Check;

namespace CAS.UI.UICAAControls.CheckList
{
    public partial class CheckListRevisionForm : MetroForm
    {
        private List<CheckLists> _addedChecks = new List<CheckLists>();
        private List<CheckLists> _updateChecks = new List<CheckLists>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        public CheckListRevisionForm()
        {
            InitializeComponent();

        }

        public CheckListRevisionForm(List<CheckLists> items) : this()
        {
            _addedChecks.AddRange(items);
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
        }

        private void ApplyChanges()
        {
            foreach (var checks in _updateChecks)
            {
                checks.Source = metroTextSource.Text;
                checks.Settings.EditionNumber = metroTextBoxEditionNumber.Text;
                checks.Settings.EditionDate = dateTimePickerEditionDate.Value;
                checks.Settings.EffEditionDate = dateTimePickerEditionEff.Value;
                checks.Settings.RevisionNumber = metroTextBoxRevision.Text;
                checks.Settings.RevisonDate = dateTimePickerRevisionDate.Value;
                checks.Settings.EffRevisonDate = dateTimePickerRevisionEff.Value;
                checks.Settings.RevisonValidTo = checkBoxRevisionValidTo.Checked;
                checks.Settings.RevisonValidToDate = dateTimePickeValidTo.Value;
                checks.Settings.RevisonValidToNotify = (int)numericUpNotify.Value;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {

                var dialogResult = MessageBox.Show("Do you really want update records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.OK)
                {
                    ApplyChanges();
                    foreach (var checks in _updateChecks)
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(checks);


                    MessageBox.Show("All records updated successfull!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    DialogResult = DialogResult.OK;
                    //Close();

                    foreach (var item in _tocheckListView.SelectedItems.ToArray())
                    {
                        _updateChecks.Remove(item);
                        _addedChecks.Add(item);
                    }
                    _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
                    _tocheckListView.SetItemsArray(_updateChecks.ToArray());
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _fromcheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Add(item);
                _addedChecks.Remove(item);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckListView.SelectedItems.Count == 0) return;

            foreach (var item in _tocheckListView.SelectedItems.ToArray())
            {
                _updateChecks.Remove(item);
                _addedChecks.Add(item);
            }

            _fromcheckListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckListView.SetItemsArray(_updateChecks.ToArray());
        }
    }
}
