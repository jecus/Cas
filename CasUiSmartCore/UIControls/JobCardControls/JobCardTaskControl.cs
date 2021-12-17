using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Deprecated;

namespace CAS.UI.UIControls.JobCardControls
{

    /// <summary>
    /// ������� ��������� ������ ���������� �� ������� ������
    /// </summary>
    public partial class JobCardTaskControl : Interfaces.EditObjectControl
    {

        #region public JobCardTask JobCardTask
        /// <summary>
        /// ������ ������� �����, � ������� ������ �������
        /// </summary>
        public JobCardTask JobCardTask
        {
            get { return AttachedObject as JobCardTask; }
            set { AttachedObject = value; }
        }
        #endregion

        #region
        public bool EnableToDelete
        {
            set { buttonDelete.Enabled = value; }
        }
        #endregion

        /*
         * �����������
         */

        #region public JobCardTaskControl()
        /// <summary>
        /// ������ �����������
        /// </summary>
        public JobCardTaskControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public JobCardTaskControl(JobCardTask runup) : this()
        /// <summary>
        /// ������� ����������� ������ � ������ ������� �����
        /// </summary>
        public JobCardTaskControl(JobCardTask runup)
            : this()
        {
            AttachedObject = runup;
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
            if (JobCardTask != null)
            {
                JobCardTask.Number = textBoxJobTaskNumber.Text;
                JobCardTask.Description = richTextBoxDescription.Rtf;
                JobCardTask.Tasks.Clear();
                List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

                foreach (JobCardTaskControl fc in fcs)
                {
                    fc.ApplyChanges();
                    JobCardTask.Tasks.Add(fc.JobCardTask);
                }
            }

            //
            base.ApplyChanges();
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
            if (textBoxJobTaskNumber.Text != JobCardTask.Number ||
                richTextBoxDescription.Rtf != JobCardTask.Description || 
                conds.Any(cond => cond.GetChangeStatus()))
            {
                return true;
            }
            return false;
            //
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

            if (richTextBoxDescription.TextLength == 0 && fcs.Count == 0)
            {
                MessageBox.Show(flowLayoutPanelMain, "Not assigned job description", "Error");
                return false;
            }

            foreach (JobCardTaskControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Work", "Error");
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
            textBoxJobTaskNumber.Text = JobCardTask.Number;

            try
            {
                richTextBoxDescription.Rtf = JobCardTask.Description;

                //Size size = TextRenderer.MeasureText(richTextBoxDescription.Text, richTextBoxDescription.Font);

                ////Graphics graphics = CreateGraphics();
                ////SizeF ef = graphics.MeasureString(richTextBoxDescription.Text, richTextBoxDescription.Font);
                ////graphics.Dispose();

                //richTextBoxDescription.Height = (int)size.Height;
            }
            catch (Exception)
            {
                richTextBoxDescription.Text = JobCardTask.Description;
            }

            // ����������� ������ ��������
            flowLayoutPanelMain.Controls.Clear();

            if (JobCardTask != null && JobCardTask.Tasks != null)
            {
                for (int i = 0; i < JobCardTask.Tasks.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    JobCardTaskControl c = new JobCardTaskControl(JobCardTask.Tasks[i]);
                    c.Deleted += ConditionControlDeleted;
                    //if (i > 0) 
                    //    c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JobCardTaskControl performance =
                new JobCardTaskControl(new JobCardTask { ParentTask = JobCardTask, JobCard = JobCardTask.JobCard});
            performance.Deleted += ConditionControlDeleted;
            //if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
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
        }

        #endregion

        #region private void TextBoxJobTaskNumberTextChanged(object sender, EventArgs e)
        private void TextBoxJobTaskNumberTextChanged(object sender, EventArgs e)
        {
            linkLabelAddNew.Text = "Add sub task to " + textBoxJobTaskNumber.Text;
        }
        #endregion

        #region private void RichTextBoxDescriptionContentsResized(object sender, ContentsResizedEventArgs e)
        private void RichTextBoxDescriptionContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBoxDescription.Height = e.NewRectangle.Height > richTextBoxDescription.MinimumSize.Height 
                ? e.NewRectangle.Height
                : richTextBoxDescription.MinimumSize.Height;
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion
    }
}

