using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Deprecated;

namespace CAS.UI.UIControls.JobCardControls
{

    /// <summary>
    /// ������� ��������� ������ ���������� �� ������� ������� �����
    /// </summary>
    public partial class JobCardTaskListControl : Interfaces.EditObjectControl
    {

        #region public Specialist Employee
        /// <summary>
        /// ������� �����, � ������� ������ �������
        /// </summary>
        public JobCard JobCard
        {
            get { return AttachedObject as JobCard; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * �����������
         */

        #region public JobCardTaskListControl()
        /// <summary>
        /// ������ �����������
        /// </summary>
        public JobCardTaskListControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * ������������� ������
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// ��������� � ������� ��������� ��������� �� ��������. 
        /// ���� �� ��� ������ ������������� ������� ����� (�������� ��� ����� �����), �������� ������� �� ����������, ������������ false
        /// ����� base.ApplyChanges() ����������
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (JobCard != null)
            {
                JobCard.JobCardTasks.Clear();
                List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

                foreach (JobCardTaskControl fc in fcs)
                {
                    fc.ApplyChanges();
                    JobCard.JobCardTasks.Add(fc.JobCardTask);
                }
            }
            //
            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// ��������� �������� �����
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            BuildControls();
            EndUpdate();
        }
        #endregion

        #region public override bool GetChangeStatus()
        /// <summary>
        /// ��������� ��������� ������.
        /// ���� �����-���� ���� �� �������� �� �������, ������� ����� ������ MessageBox, ������� ������ � ����������� ���� � ���������� false � �������� ���������� ������
        /// </summary>
        /// <returns></returns>
        public override bool GetChangeStatus()
        {
            //�������� �� ���������� ������� � ���������
            IEnumerable<JobCardTaskControl> conds = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>();
            if (conds.Any(cond => cond.GetChangeStatus()))
            {
                return true;
            }
            return false;
            //
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// ��������� ��������� ������.
        /// ���� �����-���� ���� �� �������� �� �������, ������� ����� ������ MessageBox, ������� ������ � ����������� ���� � ���������� false � �������� ���������� ������
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            // � ���� �������� ������ ��������� ������
            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

            if (fcs.Count == 0)
            {
                MessageBox.Show(flowLayoutPanelMain, "Not assigned Job Card Task", "Error");
                return false;
            }

            foreach (JobCardTaskControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Job Card Task", "Error");
                return false;
            }

            return true;
            //
        }
        #endregion

        /*
         * ����������
         */

        #region private void BuildControls()
        /// <summary>
        /// ������ ������ ��������
        /// </summary>
        private void BuildControls()
        {
            // ����������� ������ ��������
            flowLayoutPanelMain.Controls.Clear();

            if (JobCard != null && JobCard.JobCardTasks != null)
            {
                for (int i = 0; i < JobCard.JobCardTasks.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    JobCardTaskControl c = new JobCardTaskControl(JobCard.JobCardTasks[i]){Dock = DockStyle.Top};
                    c.Deleted += ConditionControlDeleted;
                    if (JobCard.JobCardTasks.Count <= 1)
                        c.EnableToDelete = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JobCardTaskControl performance =
                new JobCardTaskControl(new JobCardTask { JobCard = JobCard });
            performance.Deleted += ConditionControlDeleted;

            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();
            if (fcs.Count > 1)
            {
                foreach (JobCardTaskControl fc in fcs)
                {
                    fc.EnableToDelete = true;    
                }
            }

            performance.Dock = DockStyle.Top;

            flowLayoutPanelMain.Controls.Add(performance);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            JobCardTaskControl control = (JobCardTaskControl)sender;
            JobCardTask cond = control.JobCardTask;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Job Card Task?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //���� ���������� � ��������� ��������� � �� 
                //� ������� ������������� ����� �� �� ��������
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }

            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();
            if (fcs.Count == 1)
            {
                fcs[0].EnableToDelete = false;
            }
        }

        #endregion
    }
}

