using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{

    /// <summary>
    /// ������� ��������� ������ ���������� �� ������� ������
    /// </summary>
    public partial class EmployeeCategoriesListControl : Interfaces.EditObjectControl
    {

        #region public Specialist Employee
        /// <summary>
        /// ���������, � ������� ������ �������
        /// </summary>
        public Specialist Employee
        {
            get { return AttachedObject as Specialist; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * �����������
         */

        #region public EmployeeCategoriesControl()
        /// <summary>
        /// ������ �����������
        /// </summary>
        public EmployeeCategoriesListControl()
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
            if (Employee != null)
            {
                Employee.CategoriesRecords.Clear();
                List<CategoryRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CategoryRecordControl>().ToList();

                foreach (CategoryRecordControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Employee.CategoriesRecords.Add(fc.CategoryRecord);
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

            if (Employee != null && Employee.CategoriesRecords != null)
            {
                for (int i = 0; i < Employee.CategoriesRecords.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    CategoryRecordControl c = new CategoryRecordControl(Employee.CategoriesRecords[i]);
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
            CategoryRecordControl performance =
                new CategoryRecordControl(new CategoryRecord { Parent = Employee });
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
            CategoryRecordControl control = (CategoryRecordControl)sender;
            CategoryRecord cond = control.CategoryRecord;

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

