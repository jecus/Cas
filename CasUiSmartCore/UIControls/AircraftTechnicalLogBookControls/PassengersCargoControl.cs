using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для отображения информации о пассажирах и грузе
    ///</summary>
    public partial class PassengersCargoControl : EditObjectControl
    {

        #region public AircraftFlight Flight
        ///<summary>
        /// Возвращает редактируемый полет
        ///</summary>
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
                flightTakeOffWeightControl1.Crew = value;
            }
        }
        #endregion

        #region public double OnBoardFuel
        ///<summary>
        /// Задает кол-во топлива на борту
        ///</summary>
        public double OnBoardFuel
        {
            set
            {
                flightTakeOffWeightControl1.OnBoardFuel = value;
            }
        }
        #endregion

        #region public double RemainAfterFuel
        ///<summary>
        /// Задает кол-во топлива после полета
        ///</summary>
        public double RemainAfterFuel
        {
            set
            {
                flightTakeOffWeightControl1.RemainAfterFuel = value;
            }
        }
        #endregion
        /*
         * Конструктор
         */

        #region public PassengersCargoControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public PassengersCargoControl()
        {
            InitializeComponent();
        }
        #endregion

        /*
         * Методы
         */

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            if (Flight != null)
            {
                foreach (Control c in flowLayoutPanelMain.Controls)
                {
                    EditObjectControl cc = c as EditObjectControl;
                    if (cc != null) cc.AttachedObject = AttachedObject;
                }
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Сохраняет данные текущей директивы
        /// </summary>
        public override bool CheckData()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    if (!cc.CheckData()) return false;
            }
            // Все проверки завершились успешно
            return true;
        }

        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Вызывает метод ApplyChanges у каждого контрола
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in flowLayoutPanelMain.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null) cc.ApplyChanges();
            }
        }
        #endregion

        #region private void passengerListControl1_OnPassengersWeightChanget(Auxiliary.Events.ValueChangedEventArgs e)
        private void passengerListControl1_OnPassengersWeightChanget(Auxiliary.Events.ValueChangedEventArgs e)
        {
            if (e.Value is double)
                flightTakeOffWeightControl1.PassengersWeight = (double)e.Value;
            else flightTakeOffWeightControl1.PassengersWeight = 0;
        }
        #endregion

        #region private void cargoListControl1_OnCargoWeightChanget(Auxiliary.Events.ValueChangedEventArgs e)
        private void cargoListControl1_OnCargoWeightChanget(Auxiliary.Events.ValueChangedEventArgs e)
        {
            if (e.Value is double)
                flightTakeOffWeightControl1.CargoWeight = (double)e.Value;
            else flightTakeOffWeightControl1.CargoWeight = 0;
        }
        #endregion
    }
}
