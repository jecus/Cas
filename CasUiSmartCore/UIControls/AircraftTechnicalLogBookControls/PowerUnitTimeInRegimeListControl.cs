using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// ������ ������ ��������� ��� ����������� ���������� �� �����
    /// </summary>
    public partial class PowerUnitTimeInRegimeListControl : Interfaces.EditObjectControl
    {

        #region public DetailType DetailType

        private BaseComponentType _componentType;
        ///<summary>
        /// ������ ��� ������� ��� ������� ����� ������������ ������ � ������
        ///</summary>
        public BaseComponentType ComponentType
        {
            set { _componentType = value; }
        }
        #endregion

        #region public DateTime FlightDate
       
        private DateTime _flightDate = DateTime.Today;
        ///<summary>
        /// ���������� ��� ������ ���� ������
        ///</summary>
        public DateTime FlightDate
        {
            set
            {
                _flightDate = value;
                SetWorkTimeGA();
            }
        }
        #endregion

        #region public DateTime StartTime

        private DateTime _outTime;
        ///<summary>
        /// ������ ����� ������ ������
        ///</summary>
        public DateTime StartTime
        {
            set
            {
                _outTime = value;
                SetWorkTimeGA();
            }
        }
        #endregion

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

        #region public EngineTimeInRegimeListControl()
        /// <summary>
        /// ������ ������ ��������� ��� ����������� ���������� �� �����
        /// </summary>
        public PowerUnitTimeInRegimeListControl()
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
                PowerUnitTimeInRegimeControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitTimeInRegimeControlItem;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.PowerUnitTimeInRegimeCollection != null && !ConditionExists(c.Condition))
                    Flight.PowerUnitTimeInRegimeCollection.Add(c.Condition);
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
                PowerUnitTimeInRegimeControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitTimeInRegimeControlItem;
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
            flowLayoutPanelMain.Controls.Add(label);
            if (Flight != null && Flight.PowerUnitTimeInRegimeCollection != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

				List<EngineTimeInRegime> runUps =
                    Flight.PowerUnitTimeInRegimeCollection.ToArray().Where(r => r.BaseComponent.BaseComponentType.ItemId == _componentType.ItemId).
                        ToList();
                //����������� �������� �� �� ������ � ����������� ������� ������� � ������ ������
                for (int i = 0; i < runUps.Count; i++)
                {
                    // ��������� ������� ��� ����� ������ �� ��������
                    PowerUnitTimeInRegimeControlItem c = new PowerUnitTimeInRegimeControlItem(aircraft, runUps[i]) { DetailLabelText = _componentType.ToString() };
                    if (i > 0) c.ShowHeaders = false;

                    c.Deleted += OilConditionControlDeleted;
                    c.PowerUnitChanget += ConditionControlPowerUnitChanget;
                    c.FligthRegimeChanget += ConditionControlFlightRegimeChanget;
                    c.WorkTimeChanget += ConditionControlWorkTimeChanget;

                    flowLayoutPanelMain.Controls.Add(c);

                    //���������� ���������� �� ����� ������� ������ 
                    //�������� ������� ��������� � �������� ������
                    SetWorkTimeGA(c.PowerUnit, c.FlightRegime);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private bool ConditionExists(EngineTimeInRegime con)
        /// <summary>
        /// ���������� �� ���������� �� ������ ����� ��� ��������� ��������
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        private bool ConditionExists(EngineTimeInRegime con)
        {
            //
            if (Flight == null || Flight.PowerUnitTimeInRegimeCollection == null) return false;

            //
            return Flight.PowerUnitTimeInRegimeCollection.Any(t => t == con);

            //
        }
        #endregion

        #region private void SetWorkTimeGA()
        private void SetWorkTimeGA()
        {
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                if (!(c is PowerUnitTimeInRegimeControlItem))
                    continue;
                PowerUnitTimeInRegimeControlItem controlItem = (PowerUnitTimeInRegimeControlItem) c;
                
                if(controlItem.PowerUnit != null && controlItem.FlightRegime != null)
                    SetWorkTimeGA(controlItem.PowerUnit, controlItem.FlightRegime);
            }
        }
        #endregion

        #region private void SetWorkTimeGA(BaseDetail powerUnit, FlightRegime flightRegime)
        private void SetWorkTimeGA(BaseComponent powerUnit, FlightRegime flightRegime)
        {
            if (powerUnit == null) return;
            List<PowerUnitTimeInRegimeControlItem> fcs =
                flowLayoutPanelMain.Controls
                .OfType<PowerUnitTimeInRegimeControlItem>()
                .Where(c => c.PowerUnit != null && 
                            c.PowerUnit.ItemId == powerUnit.ItemId &&
                            c.FlightRegime == flightRegime)
                .ToList();
            int t = fcs.Sum(cr => cr.WorkTime);

            Lifelength baseDetailLifeLenghtInRegimeSinceLastOverhaul = null;
            Lifelength baseDetailLifeLenghtSinceLastOverhaul = null;
            Lifelength baseDetailOhInterval = null;
            Lifelength baseDetailLifeLenghtInRegimeSinceNew =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate, flightRegime);
            Lifelength baseDetailLifeLenghtSinceNew =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate);
            Lifelength baseDetailLifeLimit = powerUnit.LifeLimit;

            ComponentWorkInRegimeParams inRegimeParams =
                powerUnit.ComponentWorkParams.Where(p => p.FlightRegime == flightRegime).FirstOrDefault();
            if(inRegimeParams!= null && 
               inRegimeParams.ResorceProvider == SmartCoreType.ComponentDirective && 
               powerUnit.ComponentDirectives.GetItemById(inRegimeParams.ResorceProviderId) != null)
            {
                //� ��������� ������ ��������� ��������� ����� ������ � ������ � 
                //���������� ���������� ���������  
                ComponentDirective dd = powerUnit.ComponentDirectives.GetItemById(inRegimeParams.ResorceProviderId);
                if(dd.LastPerformance == null)
                {
                    baseDetailOhInterval = dd.Threshold.FirstPerformanceSinceNew;
                    //���� ���������� ���������� ��������� ���, 
                    //�� ������������� ������ ������ �������� � ��������� ������
                    baseDetailLifeLenghtInRegimeSinceLastOverhaul = 
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate, flightRegime);
                    baseDetailLifeLenghtSinceLastOverhaul =
                       GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate);
                }
                else
                {
                    baseDetailOhInterval = dd.Threshold.RepeatInterval;
                    //�.�. ����� ��������������� ������ ����� (�: �������� ��������)
                    //������������ ����� ��������� ������ � ���������� ����� ������� �������
                    AbstractPerformanceRecord r = dd.PerformanceRecords.GetLastKnownRecord(_flightDate);
                    if(r != null)
                    {
                        baseDetailLifeLenghtInRegimeSinceLastOverhaul =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthForPeriod(powerUnit, r.RecordDate, _flightDate.AddHours(-1), flightRegime);
                        baseDetailLifeLenghtSinceLastOverhaul =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthForPeriod(powerUnit, r.RecordDate, _flightDate.AddHours(-1));//TODO:(Evgenii Babak) �������� ������ AddHours(-1)
					}
                }
            }

            if (Flight.AircraftId <= 0)
            {
				//���������� ���� ������� ��
                var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(Flight.AircraftId, _flightDate);
				//� ����� ���� �������, ��� ���� ������ ��������
                foreach (AircraftFlight aircraftFlight in flights)
                {
					//���� ����� ��� ������ ��������, �� ��� ��������� ����������� 
					//� �������������� �������� �������� ��������
                    if (aircraftFlight.FlightDate < _flightDate.Date.Add(_outTime.TimeOfDay))
                    {
                        baseDetailLifeLenghtInRegimeSinceNew.Add(GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(aircraftFlight, powerUnit, flightRegime));
                        baseDetailLifeLenghtSinceNew.Add(GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(aircraftFlight, powerUnit));
                        if(baseDetailLifeLenghtInRegimeSinceLastOverhaul == null)
							continue;
                        baseDetailLifeLenghtInRegimeSinceLastOverhaul.Add(GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(aircraftFlight, powerUnit, flightRegime));
                        if (baseDetailLifeLenghtSinceLastOverhaul == null)
							continue;
                        baseDetailLifeLenghtSinceLastOverhaul.Add(GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(aircraftFlight, powerUnit));
                    }
                }
            }
            baseDetailLifeLenghtInRegimeSinceNew.Add(LifelengthSubResource.Minutes, t);
            
            if (baseDetailLifeLenghtInRegimeSinceLastOverhaul != null)
                baseDetailLifeLenghtInRegimeSinceLastOverhaul.Add(LifelengthSubResource.Minutes, t);


            double persentSN = 0, persentLifeLimit = 0, persentSLO = 0, persentOhInt = 0;
            int? resInRegimeSN = baseDetailLifeLenghtInRegimeSinceNew.GetSubresource(LifelengthSubResource.Minutes);
            int? resSN = baseDetailLifeLenghtSinceNew.GetSubresource(LifelengthSubResource.Minutes);
            int? resLl = baseDetailLifeLimit.GetSubresource(LifelengthSubResource.Minutes);
            
            if (resSN != null && resInRegimeSN != null && resSN > 0)
                persentSN = Convert.ToDouble((double)resInRegimeSN * 100/resSN);
            if (resLl != null && resInRegimeSN != null && resLl > 0)
                persentLifeLimit = Convert.ToDouble((double)resInRegimeSN * 100 / resLl);

            if (baseDetailLifeLenghtInRegimeSinceLastOverhaul != null)
            {
                int? resInRegimeSLO = baseDetailLifeLenghtInRegimeSinceLastOverhaul.GetSubresource(LifelengthSubResource.Minutes);
                             
                if (baseDetailLifeLenghtSinceLastOverhaul != null)
                {
                    int? resSLO = baseDetailLifeLenghtSinceLastOverhaul.GetSubresource(LifelengthSubResource.Minutes);
                    if (resSLO != null && resInRegimeSLO != null && resSLO > 0)
                        persentSLO = Convert.ToDouble((double)resInRegimeSLO * 100 / resSLO);
                }
                if (baseDetailOhInterval != null)
                {
                    int? resOhInt = baseDetailOhInterval.GetSubresource(LifelengthSubResource.Minutes);
                    if (resOhInt != null && resInRegimeSLO != null && resOhInt > 0)
                        persentOhInt = Convert.ToDouble((double)resInRegimeSLO * 100 / resOhInt);
                }
            }
              

            foreach (PowerUnitTimeInRegimeControlItem fc in fcs)
            {
                fc.WorkTimeGA = t;
                fc.WorkTimeSinceNew = baseDetailLifeLenghtInRegimeSinceNew;
                fc.WorkTimeSLO = baseDetailLifeLenghtInRegimeSinceLastOverhaul;
                fc.PersentSN = persentSN;
                fc.PersentLifeLimit = persentLifeLimit;
                fc.PersentSLO = persentSLO;
                fc.PersentOhInt = persentOhInt;
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
			PowerUnitTimeInRegimeControlItem performance =
                new PowerUnitTimeInRegimeControlItem(aircraft, new EngineTimeInRegime());
            performance.Deleted += OilConditionControlDeleted;
            performance.PowerUnitChanget += ConditionControlPowerUnitChanget;
            performance.FligthRegimeChanget += ConditionControlFlightRegimeChanget;
            performance.WorkTimeChanget += ConditionControlWorkTimeChanget;

            if (flowLayoutPanelMain.Controls.Count > 2) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
        }

        #endregion

        #region private void OilConditionControlDeleted(object sender, EventArgs e)

        private void OilConditionControlDeleted(object sender, EventArgs e)
        {
            PowerUnitTimeInRegimeControlItem control = (PowerUnitTimeInRegimeControlItem)sender;
            EngineTimeInRegime cond = control.Condition;

            if(cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Time in regime record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
                control.PowerUnitChanget -= ConditionControlPowerUnitChanget;
                control.FligthRegimeChanget -= ConditionControlFlightRegimeChanget;
                control.WorkTimeChanget -= ConditionControlWorkTimeChanget;
                control.Dispose();
            }
            else if(cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= OilConditionControlDeleted;
                control.PowerUnitChanget -= ConditionControlPowerUnitChanget;
                control.FligthRegimeChanget -= ConditionControlFlightRegimeChanget;
                control.WorkTimeChanget -= ConditionControlWorkTimeChanget;
                control.Dispose();
            }
        }

        #endregion

        #region private void ConditionControlPowerUnitChanget(object sender, EventArgs e)
        private void ConditionControlPowerUnitChanget(object sender, EventArgs e)
        {
            if (sender as PowerUnitTimeInRegimeControlItem == null) return;
            BaseComponent prevPowerUnit = ((PowerUnitTimeInRegimeControlItem)sender).PrevPowerUnit;
            FlightRegime fr = ((PowerUnitTimeInRegimeControlItem) sender).FlightRegime;
            if (prevPowerUnit != null)
            {
                SetWorkTimeGA(prevPowerUnit,fr);
            }
            BaseComponent powerUnit = ((PowerUnitTimeInRegimeControlItem)sender).PowerUnit;
            if (powerUnit != null)
            {
                SetWorkTimeGA(powerUnit,fr);
            }
        }
        #endregion

        #region private void ConditionControlFlightRegimeChanget(object sender, EventArgs e)
        private void ConditionControlFlightRegimeChanget(object sender, EventArgs e)
        {
            if (sender as PowerUnitTimeInRegimeControlItem == null) return;
            BaseComponent powerUnit = ((PowerUnitTimeInRegimeControlItem)sender).PowerUnit;
            FlightRegime pfr = ((PowerUnitTimeInRegimeControlItem)sender).PrevFlightRegime;
            FlightRegime fr = ((PowerUnitTimeInRegimeControlItem)sender).FlightRegime;
            
            if (powerUnit != null)
            {
                SetWorkTimeGA(powerUnit, pfr);

                SetWorkTimeGA(powerUnit, fr);
            }
        }
        #endregion

        #region private void ConditionControlWorkTimeChanget(object sender, EventArgs e)
        private void ConditionControlWorkTimeChanget(object sender, EventArgs e)
        {
            if (sender as PowerUnitTimeInRegimeControlItem == null) return;
            BaseComponent powerUnit = ((PowerUnitTimeInRegimeControlItem)sender).PowerUnit;
            FlightRegime fr = ((PowerUnitTimeInRegimeControlItem)sender).FlightRegime;

            if (powerUnit != null)
            {
                SetWorkTimeGA(powerUnit, fr);
            }
        }
        #endregion
    }
}

