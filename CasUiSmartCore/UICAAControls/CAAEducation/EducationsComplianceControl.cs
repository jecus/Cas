using System.Windows.Forms;
using Auxiliary;
using SmartCore.CAA.CAAEducation;
using SmartCore.Calculations;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationsComplianceControl : UserControl
    {
        public EducationsComplianceControl()
        {
            InitializeComponent();
        }
        
        public void UpdateInformation(CAAEducationManagment managment)
        {
            var record = managment.Record;
            if(record.Settings.Repeat == Lifelength.Null)
                return;
            
            var subs =
                new[]
                {
                    managment.Education?.Task?.FullName,
                    SmartCore.Auxiliary.Convert.GetDateFormat(record?.Settings?.Next),
                    ""
                };
            
            var newItem = new ListViewItem(subs)
            {
                BackColor = UsefulMethods.GetColor(record),
                Group = listViewCompliance.Groups[0],
                Tag = record,
            };
            listViewCompliance.Items.Add(newItem);
        }
        
        
        private void ListViewComplainceMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        
    }
}