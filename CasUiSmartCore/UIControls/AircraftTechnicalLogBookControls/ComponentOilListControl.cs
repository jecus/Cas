using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CASTerms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// ������ ������ ��������� ��� ����������� ���������� �� �����
    /// </summary>
    public partial class ComponentOilListControl : Interfaces.EditObjectControl
    {
        private Dictionary<int, TimeSpan> _powerUnitsWorkTime = new Dictionary<int, TimeSpan>();

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

        #region public ComponentOilListControl()
        /// <summary>
        /// ������ ������ ��������� ��� ����������� ���������� �� �����
        /// </summary>
        public ComponentOilListControl()
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
                ComponentOilControl c = flowLayoutPanelMain.Controls[i] as ComponentOilControl;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.OilConditionCollection != null && !ConditionExists(c.OilCondition))
                    Flight.OilConditionCollection.Add(c.OilCondition);
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
                ComponentOilControl c = flowLayoutPanelMain.Controls[i] as ComponentOilControl;
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

	        if (Flight != null && Flight.OilConditionCollection != null)
            {
	            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
                for (int i = 0; i < Flight.OilConditionCollection.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� �����
                    ComponentOilControl c = new ComponentOilControl(aircraft, Flight.OilConditionCollection[i]);
                    c.Deleted += OilConditionControlDeleted;
                    c.AfterRemainChanget += ItemAfterRemainChanget;
                    c.RefuelChanget += ItemRefuelChanget;
                    c.OnBoardChanget += ItemOnBoardChanget;
                    c.SpentChanget += ItemSpentChanget;
                    c.BeforeRemainChanget += ItemBeforeRemainChanget;
                    c.ComponentChanget += ItemComponentChanget;
                    c.OilFlowChanget += ItemFlowChanget;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                    SetOilFlow(c.PowerUnit);
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
            List<ComponentOilControl> fcs = flowLayoutPanelMain.Controls.OfType<ComponentOilControl>().ToList();

            double t = fcs.Sum(cr => cr.RemainBefore);

            textRemainTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalRefuel()
        private void GetTotalRefuel()
        {
            List<ComponentOilControl> fcs = flowLayoutPanelMain.Controls.OfType<ComponentOilControl>().ToList();

            double t = fcs.Sum(cr => cr.Refuel);

            textCorrectionTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalOnBoard()
        private void GetTotalOnBoard()
        {
            List<ComponentOilControl> fcs = flowLayoutPanelMain.Controls.OfType<ComponentOilControl>().ToList();

            double t = fcs.Sum(cr => cr.OnBoard);

            textOnBoardTotal.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalSpent()
        private void GetTotalSpent()
        {
            List<ComponentOilControl> fcs = flowLayoutPanelMain.Controls.OfType<ComponentOilControl>().ToList();

            double t = fcs.Sum(cr => cr.Spent);

            textBoxTotalSpent.Text = t.ToString("F");
        }
        #endregion

        #region private void GetTotalAfter()
        private void GetTotalAfter()
        {
            List<ComponentOilControl> fcs = flowLayoutPanelMain.Controls.OfType<ComponentOilControl>().ToList();

            double t = fcs.Sum(cr => cr.RemainAfter);

            textBoxRemainAfter.Text = t.ToString("F");
        }
        #endregion

        #region private void SetOilFlow(BaseDetail powerUnit)
        private void SetOilFlow(BaseComponent powerUnit)
        {
            if(powerUnit !=null && _powerUnitsWorkTime.ContainsKey(powerUnit.ItemId))
            {
                SetOilFlow(powerUnit,_powerUnitsWorkTime[powerUnit.ItemId]);
            }
        }
        #endregion

        #region private void SetOilFlow(BaseDetail powerUnit, TimeSpan workTime)
        private void SetOilFlow(BaseComponent powerUnit, TimeSpan workTime)
        {
            if (powerUnit == null) return;
            List<ComponentOilControl> fcs = 
                flowLayoutPanelMain.Controls
                .OfType<ComponentOilControl>()
                .Where(c=>c.PowerUnit != null && c.PowerUnit.ItemId == powerUnit.ItemId)
                .ToList();
            double t = fcs.Sum(cr => cr.Spent);
            
            foreach (ComponentOilControl fc in fcs)
            {
                if(workTime.TotalMinutes > 0)
                    fc.Flow = (t/workTime.TotalMinutes)*60.0;
            }
        }
        #endregion

        #region private bool ConditionExists(ComponentOilCondition con)
        /// <summary>
        /// ���������� �� ���������� �� ������ ����� ��� ��������� ��������
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(ComponentOilCondition con)
        {
            //
            if (Flight == null || Flight.OilConditionCollection == null) return false;

            //
            for (int i = 0; i < Flight.OilConditionCollection.Count; i++)
                if (Flight.OilConditionCollection[i] == con)
                    return true;

            //
            return false;
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			ComponentOilControl performance =
                new ComponentOilControl(aircraft, new ComponentOilCondition());
            performance.Deleted += OilConditionControlDeleted;
            performance.AfterRemainChanget += ItemAfterRemainChanget;
            performance.RefuelChanget += ItemRefuelChanget;
            performance.OnBoardChanget += ItemOnBoardChanget;
            performance.SpentChanget += ItemSpentChanget;
            performance.BeforeRemainChanget += ItemBeforeRemainChanget;
            performance.ComponentChanget += ItemComponentChanget;
            performance.OilFlowChanget += ItemFlowChanget;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            
            SetOilFlow(performance.PowerUnit);
        }
        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            ComponentOilControl control = (ComponentOilControl)sender;
            ComponentOilCondition cond = control.OilCondition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete oil condition?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.ComponentChanget -= ItemComponentChanget;
                control.OilFlowChanget -= ItemFlowChanget;
                SetOilFlow(control.PowerUnit);
                
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
                control.ComponentChanget -= ItemComponentChanget;
                control.OilFlowChanget -= ItemFlowChanget;

                SetOilFlow(control.PowerUnit);

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

            if (sender is ComponentOilControl)
            {
                if (((ComponentOilControl)sender).PowerUnit != null)
                {
                    SetOilFlow(((ComponentOilControl)sender).PowerUnit);
                }
                else ((ComponentOilControl) sender).Flow = 0;
            }
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

        #region private void ItemFlowChanget(object sender, EventArgs e)
        private void ItemFlowChanget(object sender, EventArgs e)
        {
            ComponentOilControl coc = sender as ComponentOilControl;
            if (coc == null) return;
            InvokeOilFlowChanget(coc.PowerUnit, coc.Flow);
        }
        #endregion

        #region private void ItemComponentChanget(object sender, EventArgs e)
        private void ItemComponentChanget(object sender, EventArgs e)
        {
            if (sender as ComponentOilControl == null) return;
            BaseComponent prevPowerUnit = ((ComponentOilControl)sender).PrevPowerUnit;
            if (prevPowerUnit != null)
            {
                SetOilFlow(prevPowerUnit);
                //InvokeOilFlowChanget(prevPowerUnit, ((ComponentOilControl)sender).Flow);
            }
            BaseComponent powerUnit = ((ComponentOilControl)sender).PowerUnit;
            if (powerUnit != null)
            {
                SetOilFlow(powerUnit);
                //InvokeOilFlowChanget(powerUnit, ((ComponentOilControl)sender).Flow);
            }

        }
        #endregion

        #region public void SetPowerUnitWorkTime(BaseDetail powerUnit, TimeSpan workTime)
        ///<summary>
        /// �������� ����� ������ ������������ ������� ���������
        ///</summary>
        ///<param name="powerUnit">������� ���������</param>
        ///<param name="workTime">����� ������</param>
        public void SetPowerUnitWorkTime(BaseComponent powerUnit, TimeSpan workTime)
        {
            if(powerUnit == null) return;
            if (_powerUnitsWorkTime.ContainsKey(powerUnit.ItemId))
                _powerUnitsWorkTime[powerUnit.ItemId] = workTime;
            else _powerUnitsWorkTime.Add(powerUnit.ItemId, workTime);

            SetOilFlow(powerUnit,workTime);
        }

        public void SetPowerUnitWorkTime(List<BaseComponent> powerUnits, TimeSpan workTime)
        {
	        foreach (var powerUnit in powerUnits)
	        {
				if (powerUnit == null) return;
				if (_powerUnitsWorkTime.ContainsKey(powerUnit.ItemId))
					_powerUnitsWorkTime[powerUnit.ItemId] = workTime;
				else _powerUnitsWorkTime.Add(powerUnit.ItemId, workTime);

				SetOilFlow(powerUnit, workTime);
			}
	        
        }


		#endregion

		#region Events
		///<summary>
		/// ��������� ��� ��������� ������� �����
		///</summary>
		[Category("Oil data")]
        [Description("��������� ��� ��������� ������� �����")]
        public event EventHandler OilFlowChanget;

        ///<summary>
        /// ������������� �� ��������� ������� ����� � ������� ���������
        ///</summary>
        ///<param name="powerUnit">������� ���������</param>
        ///<param name="e"></param>
        private void InvokeOilFlowChanget(BaseComponent powerUnit, double e)
        {
            EventHandler handler = OilFlowChanget;
            if (handler != null)
                handler(powerUnit, new ValueChangedEventArgs(e));
        }
        #endregion
    }
}

