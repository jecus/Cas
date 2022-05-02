using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.Specialists
{
    public partial class CAAEmployeeTraining : UserControl
    {
        public CAAEmployeeTraining()
        {
            InitializeComponent();
        }

        public void UpdateControl(CommonCollection<CAAEducationManagment> initialDocumentArray, Operator @operator, List<CAAEducationRecord> records)
        {
            _managmentListView.DisableEdit = true;
            _managmentListView.CurrentOperator = @operator;
            _managmentListView.SortDirection = SortDirection.Asc;
            _managmentListView.OldColumnIndex = 12;
            _managmentListView.SetItemsArray(initialDocumentArray.ToArray());
            
            
            listViewCompliance.Items.Clear();
            foreach (var record in records)
            {
                foreach (var comp in record.Settings.LastCompliances.OrderByDescending(i => i.LastDate))
                {
                    var lastsubs =
                        new[]
                        {
                            record.Education?.Task?.FullName,
                            SmartCore.Auxiliary.Convert.GetDateFormat(comp.LastDate),
                            comp.Remark
                        };
            
                    var lastItem = new ListViewItem(lastsubs)
                    {
                        BackColor = UsefulMethods.GetColor(record),
                        Group = listViewCompliance.Groups[1],
                        Tag = comp,
                    };
                    listViewCompliance.Items.Add(lastItem);
                }
            }
        }
    }
}