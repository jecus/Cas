using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CAAEducation
{
    public partial class EducationPerformanceControl : UserControl
    {
        private CAAEducationManagment _o;

        public CAAEducationManagment Object
        {
            get => _o;
            set
            {
                _o = value;
                UpdateInformation();
            }
        }

        public EducationPerformanceControl()
        {
            InitializeComponent();
        }

        public void UpdateInformation()
        {
            dateTimePickerStart.Value = Object.Record.Settings.StartDate;
            checkBoxClose.Checked = Object.Record.Settings.IsClosed;
            lifelengthViewer_Repeat.Lifelength = Object.Record.Settings.Repeat;
            lifelengthViewerNotify.Lifelength = Object.Record.Settings.Notify;
        }
        

        public void ApplyChanges()
        {
            Object.Record.Settings.StartDate = dateTimePickerStart.Value;
            Object.Record.Settings.IsClosed = checkBoxClose.Checked;
            Object.Record.Settings.Repeat = lifelengthViewer_Repeat.Lifelength;
            Object.Record.Settings.Notify = lifelengthViewerNotify.Lifelength;
        }
    }
}