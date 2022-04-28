﻿using System;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.Calculations;

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
            listViewCompliance.Items.Clear();
            _animatedThreadWorker = animatedThreadWorker;
            _record = managment.Record;
            
            if (_record.Settings.LastCompliances != null && _record.Settings.LastCompliances.Any())
            {
                foreach (var comp in _record.Settings.LastCompliances)
                {
                    var lastsubs =
                        new[]
                        {
                            managment.Education?.Task?.FullName,
                            SmartCore.Auxiliary.Convert.GetDateFormat(comp.LastDate),
                            comp.Remark
                        };
            
                    var lastItem = new ListViewItem(lastsubs)
                    {
                        BackColor = UsefulMethods.GetColor(managment),
                        Group = listViewCompliance.Groups[1],
                        Tag = comp,
                    };
                    listViewCompliance.Items.Add(lastItem);
                }
            }
            
            if((bool)_record.Education?.Task?.Repeat.IsNullOrZero())
                return;
            
            var subs =
                new[]
                {
                    managment.Education?.Task?.FullName,
                    SmartCore.Auxiliary.Convert.GetDateFormat(_record?.Settings?.Next),
                    ""
                };
            
            var newItem = new ListViewItem(subs)
            {
                BackColor = UsefulMethods.GetColor(managment),
                Group = listViewCompliance.Groups[0],
                Tag = _record,
            };
            listViewCompliance.Items.Add(newItem);
        }
        
        
        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
                return;

            var item = listViewCompliance.SelectedItems[0];

            if (item.Tag is LastCompliance tag)
            {
                var form = new EducationComplianceForm(_record, tag);
                if (form.ShowDialog() == DialogResult.OK)
                    _animatedThreadWorker.RunWorkerAsync();
            }
            else
            {
                var form = new EducationComplianceForm(_record, new LastCompliance());
                if (form.ShowDialog() == DialogResult.OK)
                    _animatedThreadWorker.RunWorkerAsync();
            }
        }


        private void ButtonAddOnClick(object sender, EventArgs e)
        {
            var form = new EducationComplianceForm(_record, new LastCompliance());
            if (form.ShowDialog() == DialogResult.OK)
                _animatedThreadWorker.RunWorkerAsync();
        }
        
        private void ButtonDeleteOnClick(object sender, EventArgs e)
        {
            if (listViewCompliance.SelectedItems.Count == 0)
                return;

            foreach (var item in listViewCompliance.SelectedItems.OfType<ListViewItem>())
            {
                if (item.Tag is LastCompliance tag)
                {
                    _record.Settings.LastCompliances.Remove(tag);
                    listViewCompliance.Items.Remove(item);
                    GlobalObjects.CaaEnvironment.NewKeeper.Save(_record);
                }
            }
        }
    }
}