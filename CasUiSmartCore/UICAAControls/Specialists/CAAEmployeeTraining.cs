using System.Windows.Forms;
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

        public void UpdateControl(CommonCollection<CAAEducationManagment> initialDocumentArray, Operator @operator)
        {
            _managmentListView.DisableEdit = true;
            _managmentListView.CurrentOperator = @operator;
            _managmentListView.SetItemsArray(initialDocumentArray.ToArray());
        }
    }
}