using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// ������ ������ ��������� ��� ����������� ���������� �� �����
    /// </summary>
    public partial class HydraulicListControl : Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// �����, � ������� ������ �������
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * �����������
         */

        #region public HydraulicListControl()
        /// <summary>
        /// ������ ������ ��������� ��� ����������� ���������� �� �����
        /// </summary>
        public HydraulicListControl()
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
            // ��������� ��������� ��������� ��������
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                HydraulicControl c = flowLayoutPanelMain.Controls[i] as HydraulicControl;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.HydraulicConditionCollection != null && !ConditionExists(c.HydraulicCondition))
                    Flight.HydraulicConditionCollection.Add(c.HydraulicCondition);
            }


            /*
             * ��� ��������� ��������� � ��������� 
             * 
             * ����� ���������� ��������� ��������� ������ 
             * ��������� �������� StringConvertibleCollection � �� ����� ��������� ������� � ���� ������, 
             * � �������� � �������� ���� ������� AircraftFlights
             */

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
            BuildControls();
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

            // ��������� ��������� ������
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                HydraulicControl c = flowLayoutPanelMain.Controls[i] as HydraulicControl;
                if (c != null)
                    if (!c.CheckData()) return false;
            }

            // ��� ������ ������� ���������
            return true;
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

            if (Flight != null && Flight.HydraulicConditionCollection != null)
            {
                for (int i = 0; i < Flight.HydraulicConditionCollection.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    HydraulicControl c = new HydraulicControl(Flight.HydraulicConditionCollection[i]);
                    c.Deleted += OilConditionControlDeleted;
                    c.AfterRemainChanget += ItemAfterRemainChanget;
                    c.RefuelChanget += ItemRefuelChanget;
                    c.OnBoardChanget += ItemOnBoardChanget;
                    c.SpentChanget += ItemSpentChanget;
                    c.BeforeRemainChanget += ItemBeforeRemainChanget;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }

                GetTotalBefore();
                GetTotalRefuel();
                GetTotalOnBoard();
                GetTotalSpent();
                GetTotalAfter();
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void GetTotalBefore()
        private void GetTotalBefore()
        {
            List<HydraulicControl> fcs = flowLayoutPanelMain.Controls.OfType<HydraulicControl>().ToList();

            double t = fcs.Sum(cr => cr.RemainBefore);

            textRemainTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalRefuel()
        private void GetTotalRefuel()
        {
            List<HydraulicControl> fcs = flowLayoutPanelMain.Controls.OfType<HydraulicControl>().ToList();

            double t = fcs.Sum(cr => cr.Refuel);

            textCorrectionTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalOnBoard()
        private void GetTotalOnBoard()
        {
            List<HydraulicControl> fcs = flowLayoutPanelMain.Controls.OfType<HydraulicControl>().ToList();

            double t = fcs.Sum(cr => cr.OnBoard);

            textOnBoardTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalSpent()
        private void GetTotalSpent()
        {
            List<HydraulicControl> fcs = flowLayoutPanelMain.Controls.OfType<HydraulicControl>().ToList();

            double t = fcs.Sum(cr => cr.Spent);

            textBoxTotalSpent.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalAfter()
        private void GetTotalAfter()
        {
            List<HydraulicControl> fcs = flowLayoutPanelMain.Controls.OfType<HydraulicControl>().ToList();

            double t = fcs.Sum(cr => cr.RemainAfter);

            textBoxRemainAfter.Text = t.ToString("F");
        }
        #endregion

        #region private bool ConditionExists(HydraulicCondition con)
        /// <summary>
        /// ���������� �� ���������� �� ������ ����� ��� ��������� ��������
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(HydraulicCondition con)
        {
            //
            if (Flight == null || Flight.HydraulicConditionCollection == null) return false;

            //
            return Flight.HydraulicConditionCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HydraulicControl performance =
                new HydraulicControl(new HydraulicCondition());
            performance.Deleted += OilConditionControlDeleted;
            performance.AfterRemainChanget += ItemAfterRemainChanget;
            performance.RefuelChanget += ItemRefuelChanget;
            performance.OnBoardChanget += ItemOnBoardChanget;
            performance.SpentChanget += ItemSpentChanget;
            performance.BeforeRemainChanget += ItemBeforeRemainChanget;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            HydraulicControl control = (HydraulicControl)sender;
            HydraulicCondition cond = control.HydraulicCondition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete hydraulic condition?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.Deleted -= OilConditionControlDeleted;
                control.AfterRemainChanget -= ItemAfterRemainChanget;
                control.RefuelChanget -= ItemRefuelChanget;
                control.OnBoardChanget -= ItemOnBoardChanget;
                control.SpentChanget -= ItemSpentChanget;
                control.BeforeRemainChanget -= ItemBeforeRemainChanget;
                control.Dispose();
            }
            else if(cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.AfterRemainChanget -= ItemAfterRemainChanget;
                control.RefuelChanget -= ItemRefuelChanget;
                control.OnBoardChanget -= ItemOnBoardChanget;
                control.SpentChanget -= ItemSpentChanget;
                control.BeforeRemainChanget -= ItemBeforeRemainChanget;
                control.Dispose();
            }

            GetTotalBefore();
            GetTotalRefuel();
            GetTotalOnBoard();
            GetTotalSpent();
            GetTotalAfter();
        }

        #endregion

        #region private void ItemBeforeRemainChanget(object sender, EventArgs e)
        private void ItemBeforeRemainChanget(object sender, EventArgs e)
        {
            GetTotalBefore();
        }
        #endregion

        #region private void ItemSpentChanget(object sender, EventArgs e)
        private void ItemSpentChanget(object sender, EventArgs e)
        {
            GetTotalSpent();
        }
        #endregion

        #region private void ItemOnBoardChanget(object sender, EventArgs e)
        private void ItemOnBoardChanget(object sender, EventArgs e)
        {
            GetTotalOnBoard();
        }
        #endregion

        #region private void ItemRefuelChanget(object sender, EventArgs e)
        private void ItemRefuelChanget(object sender, EventArgs e)
        {
            GetTotalRefuel();
        }
        #endregion

        #region private void ItemAfterRemainChanget(object sender, EventArgs e)
        private void ItemAfterRemainChanget(object sender, EventArgs e)
        {
            GetTotalAfter();
        }
        #endregion
    }
}

