using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.CAA.CAAEducation;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationsComplianceControl : UserControl
    {
        private AnimatedThreadWorker _animatedThreadWorker;
        private CAAEducationRecord _record;

        public EducationsComplianceControl()
        {
            InitializeComponent();
        }
        
        public void UpdateInformation(CAAEducationManagment managment, AnimatedThreadWorker animatedThreadWorker)
        {
            var last = new List<LastComplianceView>();
            _animatedThreadWorker = animatedThreadWorker;
            _record = managment.Record;
            
            if (_record.Settings.LastCompliances != null && _record.Settings.LastCompliances.Any())
            {
                foreach (var comp in _record.Settings.LastCompliances.OrderByDescending(i => i.LastDate))
                {
                    last.Add(new LastComplianceView()
                    {
                        Record = _record,
                        Course = managment.Education?.Task?.FullName,
                        LastCompliance = comp,
                        Group = "Last compliance"
                    });
                }
                
                
                if((bool)_record.Education?.Task?.Repeat.IsNullOrZero())
                    return;
            }
            
            if (_record.Settings.NextCompliance != null)
            {
                last.Add(new LastComplianceView()
                {
                    Record = _record,
                    Course = managment.Education?.Task?.FullName,
                    LastCompliance = new LastCompliance()
                    {
                        LastDate = _record.Settings.NextCompliance.NextDate
                    },
                    Group = "Need new compliance"
                });
            }
            else
            {
                last.Add(new LastComplianceView()
                {
                    Record = _record,
                    Course = managment.Education?.Task?.FullName,
                    LastCompliance = new LastCompliance(),
                    Group = "Need new compliance"
                });
            }
            
            listViewCompliance.SetItemsArray(last.ToArray());
            listViewCompliance.AnimatedThreadWorker = _animatedThreadWorker;
            listViewCompliance.IsEditable = true;
        }
        
        private void ButtonAddOnClick(object sender, EventArgs e)
        {
            var last = new LastComplianceView(){LastCompliance = new LastCompliance()};
            if(_record?.Settings?.NextCompliance?.NextDate != null)
                last.LastCompliance.LastDate = _record?.Settings?.NextCompliance?.NextDate;
            
            var form = new EducationComplianceForm(_record, last.LastCompliance);
            if (form.ShowDialog() == DialogResult.OK)
                _animatedThreadWorker.RunWorkerAsync();
        }
        
        private void ButtonDeleteOnClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
                return;

            var res = MessageBox.Show(@"Delete selected compliances?", (string)new GlobalTermsProvider()["SystemName"],
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                foreach (var item in listViewCompliance.SelectedItems.OfType<LastComplianceView>())
                {
                    if (item.Group == "Need new compliance")
                        continue;
                    if (item is LastComplianceView tag)
                    {
                        _record.Settings.LastCompliances.Remove(tag.LastCompliance);
                        GlobalObjects.CaaEnvironment.NewKeeper.Save(_record);
                    }
                }
                _animatedThreadWorker.RunWorkerAsync();
            }
        }
    }
}