using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using Entity.Abstractions.Filters;
using MetroFramework.Forms;
using SmartCore.CAA.Tasks;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationForm : MetroForm
    {
        private readonly int _operatorId;

        private List<Occupation> _occupation = new List<Occupation>();
        private CommonCollection<CAATask> _addedChecks = new CommonCollection<CAATask>();
        private CommonCollection<SmartCore.CAA.CAAEducation.CAAEducation> _updateChecks = new CommonCollection<SmartCore.CAA.CAAEducation.CAAEducation>();
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        public EducationForm(int operatorId) 
        {
            _operatorId = operatorId;

            InitializeComponent();
            
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            UpdateInformation();
        }
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _updateChecks.Clear();
            _updateChecks.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAAEducationDTO,SmartCore.CAA.CAAEducation.CAAEducation>(new Filter("OperatorId", _operatorId), true));

            _addedChecks.Clear();
            _addedChecks.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<TaskDTO,CAATask>(new Filter("OperatorId", _operatorId)));

            _occupation.Clear();
            var res = GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAASpecializationDTO, Occupation>(new Filter("OperatorId", _operatorId));
            _occupation.AddRange(res);
        }
        private void UpdateInformation()
        {
            comboBoxOccupation.Items.Clear();
            comboBoxOccupation.Items.AddRange(_occupation.ToArray());
            comboBoxOccupation.Items.Add(Occupation.Unknown);
            comboBoxOccupation.SelectedItem = Occupation.Unknown;
            
            _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
            _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save checkList", ex);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_fromcheckRevisionListView.SelectedItems.Count > 0)
            {

                if (comboBoxOccupation.SelectedItem == null)
                {
                    MessageBox.Show("Please select Occupation!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    return;
                }
                
                var occupation = comboBoxOccupation.SelectedItem as Occupation;
                
                foreach (var item in _fromcheckRevisionListView.SelectedItems.ToArray())
                {
                    
                    if(_updateChecks.Any(i => i.TaskId == item.ItemId && i.OccupationId == occupation.ItemId))
                        continue;
                    var newItem = new SmartCore.CAA.CAAEducation.CAAEducation()
                    {
                        OperatorId = _operatorId,
                        Occupation = occupation,
                        OccupationId = occupation.ItemId,
                        Task = item as CAATask,
                        TaskId = item.ItemId,
                    };

                    GlobalObjects.CaaEnvironment.NewKeeper.Save(newItem);
                    _updateChecks.Add(newItem);
                }
                
                _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
            }
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (_tocheckRevisionListView.SelectedItems.Count > 0)
            {
                foreach (var item in _tocheckRevisionListView.SelectedItems.ToArray())
                {
                    GlobalObjects.CaaEnvironment.NewKeeper.Delete(item);
                    _updateChecks.Remove(item);
                }

                _fromcheckRevisionListView.SetItemsArray(_addedChecks.ToArray());
                _tocheckRevisionListView.SetItemsArray(_updateChecks.ToArray());
            }
        }
        private void CheckListRevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
