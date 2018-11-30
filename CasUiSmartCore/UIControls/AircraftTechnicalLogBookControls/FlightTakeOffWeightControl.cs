using System.Collections.Generic;
using System.Linq;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол отображает дистанцию и эшелон полета
    /// </summary>
    public partial class FlightTakeOffWeightControl : Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        #region public List<Specialist> Crew
        ///<summary>
        /// Возвращает или задает экипаж полета
        ///</summary>
        public List<Specialist> Crew
        {
            set
            {
                if(value != null)
                {
                    double crew = value
                        .Where(specialist => specialist.AGWCategory != null)
                        .Aggregate<Specialist, double>(0, (current, specialist) => current + specialist.AGWCategory.WeightSummer);
                    numericUpDownCrew.Value = (decimal)crew;   
                }
                else
                {
                    numericUpDownCrew.Value = 0;
                }
            }
        }
        #endregion

        #region public double OnBoardFuel
        ///<summary>
        /// Задает кол-во топлива на борту
        ///</summary>
        public double OnBoardFuel
        {
            set { numericUpDownFuel.Value = (decimal) value; }
        }
        #endregion

        #region public double RemainAfterFuel
        ///<summary>
        /// Задает кол-во топлива после полета
        ///</summary>
        public double RemainAfterFuel
        {
            set { numericUpDownFuelRemainAfter.Value = (decimal)value; }
        }
        #endregion

        #region public double PassengersWeight
        ///<summary>
        /// вес пассажиров на борту
        ///</summary>
        public double PassengersWeight
        {
            set { numericUpDownPassengers.Value = (decimal)value; }
        }
        #endregion

        #region public double CargoWeight
        ///<summary>
        /// вес груза на борту
        ///</summary>
        public double CargoWeight
        {
            set { numericUpDownCargo.Value = (decimal)value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public FlightTakeOffWeightControl()
        /// <summary>
        /// Контрол отображает дистанцию и эшелон полета
        /// </summary>
        public FlightTakeOffWeightControl()
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
            if (Flight != null)
            {
                Flight.TakeOffWeight = (double)numericUpDownTakeOffWeight.Value;
            }
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

            BeginUpdate();

            if (Flight != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);

				//оперативный пустой вес
				numericUpDownOpEmptyWeight.Value = (decimal)aircraft.OperationalEmptyWeight;
                //Экипаж
                double crew = Flight.FlightCrewRecords
                    .Where(flightCrewRecord => flightCrewRecord.Specialist != null && flightCrewRecord.Specialist.AGWCategory != null)
                    .Aggregate<FlightCrewRecord, double>(0, (current, flightCrewRecord) => current + flightCrewRecord.Specialist.AGWCategory.WeightSummer);

                numericUpDownCrew.Value = (decimal)crew;
                //Пассажиры
                double passengers = Flight.FlightPassengerRecords
                    .Where(fpr => fpr.PassengerCategory != null)
                    .Aggregate<FlightPassengerRecord, double>(0, (current, fpr) => current + (fpr.CountEconomy + fpr.CountBusiness + fpr.CountFirst)*fpr.PassengerCategory.WeightSummer);
                numericUpDownPassengers.Value = (decimal)passengers;
                //груз
                double cargo = Flight.FlightCargoRecords.Sum(fcr => Measure.Convert(fcr.Weigth, fcr.Measure, Measure.Kilograms));
                numericUpDownCargo.Value = (decimal) cargo;
                //Коммерческая нагрузка
                numericUpDownPayload.Value = (decimal)(passengers + cargo);
                //Максимальная Коммерческая нагрузка
                numericUpDownMaxPayload.Value = (decimal)(aircraft.MaxPayloadWeight);
                //вес без топлива
                numericUpDownZeroFuel.Value = (decimal)(aircraft.OperationalEmptyWeight + crew + passengers + cargo);
                //максимальный вес без топлива
                numericUpDownMaxZeroFuel.Value = (decimal)aircraft.MaxZeroFuelWeight;
                #region Топливо
                double fuelOnBoard = 0;
                double fuelRemainAfter = 0;
                for (int i = 0; i < Flight.FuelTankCollection.Count; i++ )
                {
                    fuelOnBoard += Flight.FuelTankCollection[i].OnBoard;
                    fuelRemainAfter += Flight.FuelTankCollection[i].RemainingAfter;
                }
                numericUpDownFuel.Value = (decimal)fuelOnBoard;
                #endregion
                //Максимальный рулежный вес
                numericUpDownMaxTaxiWeight.Value = (decimal)(aircraft.MaxTaxiWeight);
                //взлетный вес
                numericUpDownTakeOffWeight.Value =
                    (decimal)(aircraft.OperationalEmptyWeight + crew + passengers + cargo + fuelOnBoard);
                //максимальный взлетный вес
                numericUpDownMaxTakeOffWeight.Value = (decimal)aircraft.MaxTakeOffCrossWeight;
                //посадочный вес
                numericUpDownLandingWeight.Value =
                    (decimal)(aircraft.OperationalEmptyWeight + crew + passengers + cargo + fuelRemainAfter);
                //максимальный посадочный вес
                numericUpDownMaxLandingWeight.Value = (decimal)aircraft.MaxLandingWeight;
            
            }
            else
            {
                numericUpDownOpEmptyWeight.Value = 0;
                numericUpDownCrew.Value = 0;
                numericUpDownCargo.Value = 0;
                numericUpDownMaxPayload.Value = 0;
                numericUpDownZeroFuel.Value = numericUpDownMaxZeroFuel.Value = 0;
                numericUpDownFuel.Value = 0;
                numericUpDownMaxTaxiWeight.Value = 0;
                numericUpDownTakeOffWeight.Value = numericUpDownMaxTakeOffWeight.Value = 0;
                numericUpDownLandingWeight.Value = numericUpDownMaxLandingWeight.Value = 0;
            }
            EndUpdate();
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
            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void NumericUpDownValueChanged(object sender, System.EventArgs e)
        private void NumericUpDownValueChanged(object sender, System.EventArgs e)
        {
			if (Flight != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Flight.AircraftId);
				//коммерческая нагрузка
				numericUpDownPayload.Value =
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value;
                //вес без топлива
                numericUpDownZeroFuel.Value =
                    (decimal)aircraft.OperationalEmptyWeight + 
                    numericUpDownCrew.Value + 
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value;
                //взлетный вес
                numericUpDownTakeOffWeight.Value =
                    (decimal)aircraft.OperationalEmptyWeight +
                    numericUpDownCrew.Value +
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value +
                    numericUpDownFuel.Value;
                //посадочный вес
                numericUpDownLandingWeight.Value =
                    (decimal)aircraft.OperationalEmptyWeight +
                    numericUpDownCrew.Value +
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value +
                    numericUpDownFuelRemainAfter.Value;
            }
            else
            {
                //вес без топлива
                numericUpDownZeroFuel.Value =
                    numericUpDownCrew.Value +
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value;
                //взлетный вес
                numericUpDownTakeOffWeight.Value =
                    numericUpDownCrew.Value +
                    numericUpDownPassengers.Value +
                    numericUpDownCargo.Value +
                    numericUpDownFuel.Value;
            }    
        }
        #endregion

    }
}

