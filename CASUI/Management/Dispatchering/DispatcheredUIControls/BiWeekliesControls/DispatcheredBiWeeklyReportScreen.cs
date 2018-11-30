using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls
{
    public class DispatcheredBiWeeklyReportScreen : BiWeeklyReportScreen, IDisplayingEntity
    {

        #region Constructor

        public DispatcheredBiWeeklyReportScreen(BiWeekly report, ScreenMode mode) : base(report, mode)
        {
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return report;
            }
            set
            {
                report = (BiWeekly)value;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredBiWeeklyReportScreen))
                return false;
            if (!(obj.ContainedData is BiWeekly))
                return false;

            return (report.ID == ((BiWeekly)obj.ContainedData).ID);
        }

        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (GetChangeStatus())
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        SaveData();
                        arguments.Cancel = false;
                        RemoveTempFile();
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                    default:
                        RemoveTempFile();
                        break;
                }
            }
            else 
                RemoveTempFile();
        }

        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        public event EventHandler InitComplition;

        #endregion
    }
}
