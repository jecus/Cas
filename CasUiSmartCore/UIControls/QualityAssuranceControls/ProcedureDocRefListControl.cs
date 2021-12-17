using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.QualityAssuranceControls
{

    /// <summary>
    /// ������� ��������� ������ ���������� �� ������� ������
    /// </summary>
    public partial class ProcedureDocRefListControl : Interfaces.EditObjectControl
    {

        #region public Procedure Procedure
        /// <summary>
        /// ���������, � ������� ������ �������
        /// </summary>
        public Procedure Procedure
        {
            get { return AttachedObject as Procedure; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * �����������
         */

        #region public ProcedureDocRefListControl()
        /// <summary>
        /// ������ �����������
        /// </summary>
        public ProcedureDocRefListControl()
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
            if (Procedure != null)
            {
                Procedure.DocumentReferences.Clear();
                List<ProcedureDocRefControl> fcs = flowLayoutPanelMain.Controls.OfType<ProcedureDocRefControl>().ToList();

                foreach (ProcedureDocRefControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Procedure.DocumentReferences.Add(fc.ProcedureDocumentReference);
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

        #region public override bool CheckData()
        /// <summary>
        /// ��������� ��������� ������.
        /// ���� �����-���� ���� �� �������� �� �������, ������� ����� ������ MessageBox, ������� ������ � ����������� ���� � ���������� false � �������� ���������� ������
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            // � ���� �������� ������ ��������� ������
            List<CategoryRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CategoryRecordControl>().ToList();

            //if(fcs.Count == 0)
            //{
            //    MessageBox.Show(flowLayoutPanelMain, "Not assigned crew", "Error");
            //    return false;    
            //}

            foreach (CategoryRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Category", "Error");
                return false;
            }

            foreach (CategoryRecordControl fc in fcs)
            {
                if(fcs.Count(f => f.AircraftWorkerCategory.ItemId == fc.AircraftWorkerCategory.ItemId && f.AircraftModel == fc.AircraftModel) > 1)
                {
                    MessageBox.Show(fc, "Can't have one Category more that once", "Error");
                    return false;
                }
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

            if (Procedure != null && Procedure.DocumentReferences != null)
            {
                for (int i = 0; i < Procedure.DocumentReferences.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    ProcedureDocRefControl c = new ProcedureDocRefControl(Procedure.DocumentReferences[i]);
                    c.Deleted += ConditionControlDeleted;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcedureDocRefControl performance =
                new ProcedureDocRefControl(new ProcedureDocumentReference { Procedure = Procedure });
            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            ProcedureDocRefControl control = (ProcedureDocRefControl)sender;
            ProcedureDocumentReference cond = control.ProcedureDocumentReference;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Category record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
    }
}

