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
    /// Строит список контролов для отображения информации по маслу
    /// </summary>
    public partial class PowerUnitTimeInRegimeListControl : Interfaces.EditObjectControl
    {

        #region public DetailType DetailType

        private BaseComponentType _componentType;
        ///<summary>
        /// Задает тип деталей для которых будут производится записи о пусках
        ///</summary>
        public BaseComponentType ComponentType
        {
            set { _componentType = value; }
        }
        #endregion

        #region public DateTime FlightDate
       
        private DateTime _flightDate = DateTime.Today;
        ///<summary>
        /// Возвращает или задает дату полета
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
        /// задает время начала полета
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
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public EngineTimeInRegimeListControl()
        /// <summary>
        /// Строит список контролов для отображения информации по маслу
        /// </summary>
        public PowerUnitTimeInRegimeListControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Применяем сделанные изменения объектам
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitTimeInRegimeControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitTimeInRegimeControlItem;
                if (c == null) continue;
                c.ApplyChanges();
                if (Flight != null && Flight.PowerUnitTimeInRegimeCollection != null && !ConditionExists(c.Condition))
                    Flight.PowerUnitTimeInRegimeCollection.Add(c.Condition);
            }


            /*
             * Все изменения сохранены в коллекции 
             * 
             * Здесь необходимо сохранить внесенные данные 
             * Коллекция является StringConvertibleCollection и не имеет отдельной таблицы в базе данных, 
             * а хранится в качестве поля таблицы AircraftFlights
             */

            //
            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BuildControls();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {

            // Проверяем введенные данные
            for (int i = 0; i < flowLayoutPanelMain.Controls.Count; i++)
            {
                PowerUnitTimeInRegimeControlItem c = flowLayoutPanelMain.Controls[i] as PowerUnitTimeInRegimeControlItem;
                if (c != null)
                    if (!c.CheckData()) return false;
            }

            // Все данные введены корректно
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            // Освобождаем старые контролы
            flowLayoutPanelMain.Controls.Clear();
            flowLayoutPanelMain.Controls.Add(label);
            if (Flight != null && Flight.PowerUnitTimeInRegimeCollection != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

				List<EngineTimeInRegime> runUps =
                    Flight.PowerUnitTimeInRegimeCollection.ToArray().Where(r => r.BaseComponent.BaseComponentType.ItemId == _componentType.ItemId).
                        ToList();
                //группировка запусков по ИД детали и определение первого запуска в каждой группе
                for (int i = 0; i < runUps.Count; i++)
                {
                    // Добавляем контрол для ввода данных по запускам
                    PowerUnitTimeInRegimeControlItem c = new PowerUnitTimeInRegimeControlItem(aircraft, runUps[i]) { DetailLabelText = _componentType.ToString() };
                    if (i > 0) c.ShowHeaders = false;

                    c.Deleted += OilConditionControlDeleted;
                    c.PowerUnitChanget += ConditionControlPowerUnitChanget;
                    c.FligthRegimeChanget += ConditionControlFlightRegimeChanget;
                    c.WorkTimeChanget += ConditionControlWorkTimeChanget;

                    flowLayoutPanelMain.Controls.Add(c);

                    //Обновление информации об общем времени работы 
                    //заданной силовой установки в заданном режиме
                    SetWorkTimeGA(c.PowerUnit, c.FlightRegime);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private bool ConditionExists(EngineTimeInRegime con)
        /// <summary>
        /// Существует ли информация по уровню масла для заданного агрегата
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
                //в парамтрах работы требуется расчитать время работы в режиме с 
                //последнего выполнения директивы  
                ComponentDirective dd = powerUnit.ComponentDirectives.GetItemById(inRegimeParams.ResorceProviderId);
                if(dd.LastPerformance == null)
                {
                    baseDetailOhInterval = dd.Threshold.FirstPerformanceSinceNew;
                    //если последнего выполнения директивы нет, 
                    //то расчитывается полная работа агрегата в указанном режиме
                    baseDetailLifeLenghtInRegimeSinceLastOverhaul = 
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate, flightRegime);
                    baseDetailLifeLenghtSinceLastOverhaul =
                       GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(powerUnit, _flightDate);
                }
                else
                {
                    baseDetailOhInterval = dd.Threshold.RepeatInterval;
                    //т.к. может просматриваться старый полет (н: месячной давности)
                    //производится поиск последней записи о выполнении перед текущим полетов
                    AbstractPerformanceRecord r = dd.PerformanceRecords.GetLastKnownRecord(_flightDate);
                    if(r != null)
                    {
                        baseDetailLifeLenghtInRegimeSinceLastOverhaul =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthForPeriod(powerUnit, r.RecordDate, _flightDate.AddHours(-1), flightRegime);
                        baseDetailLifeLenghtSinceLastOverhaul =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthForPeriod(powerUnit, r.RecordDate, _flightDate.AddHours(-1));//TODO:(Evgenii Babak) выяснить почему AddHours(-1)
					}
                }
            }

            if (Flight.AircraftId <= 0)
            {
				//извлечение всех полетов ВС
                var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(Flight.AircraftId, _flightDate);
				//И поиск всех полетов, что были раньше текущего
                foreach (AircraftFlight aircraftFlight in flights)
                {
					//Если полет был раньше текущего, то его наработка добавляется 
					//к рассчитываемым ресурсам базового агрегата
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
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
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

