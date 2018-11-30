using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол отображает дистанцию и эшелон полета
    /// </summary>
    public partial class FlightDistanceControl : Interfaces.EditObjectControl
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

        /*
         * Конструктор
         */

        #region public FlightDistanceControl()
        /// <summary>
        /// Контрол отображает дистанцию и эшелон полета
        /// </summary>
        public FlightDistanceControl()
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
                Flight.Level = dictComboBoxLevel.SelectedItem  != null ? (CruiseLevel)dictComboBoxLevel.SelectedItem : null;
                Flight.Distance = (Int16)numericUpDownDistance.Value;
                Flight.DistanceMeasure = (Measure)comboBoxMeasure.SelectedItem;
                Flight.AlignmentBefore = (double) numericUpDownBefore.Value;
                Flight.AlignmentAfter = (double) numericUpDownAfter.Value;
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

            comboBoxMeasure.Items.Clear();
            comboBoxMeasure.Items.Add(Measure.Miles);
            comboBoxMeasure.Items.Add(Measure.Kilometres);

            dictComboBoxLevel.Type = typeof(CruiseLevel);

            if (Flight != null)
            {
                dictComboBoxLevel.SelectedItem = Flight.Level;
                numericUpDownDistance.Value = Flight.Distance;
                comboBoxMeasure.SelectedItem = Flight.DistanceMeasure;
                numericUpDownBefore.Value = (decimal)Flight.AlignmentBefore;
                numericUpDownAfter.Value = (decimal) Flight.AlignmentAfter;
            }
            else
            {
                dictComboBoxLevel.SelectedItem = null;
                numericUpDownDistance.Value = 0;
                numericUpDownBefore.Value = numericUpDownAfter.Value = 0;
                comboBoxMeasure.SelectedItem = null;
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
            if (!ValidateMeasure()) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateMeasure()
        /// <summary>
        /// Проверяем Номер страницы
        /// </summary>
        /// <returns></returns>
        private bool ValidateMeasure()
        {
            if (comboBoxMeasure.SelectedItem == null)
            {
                MessageBox.Show(@"Not set Flight distance measure",
                                new GlobalTermsProvider()["SystemName"].ToString(),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                
                comboBoxMeasure.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region private void DictComboBoxLevelSelectedIndexChanged(object sender, EventArgs e)
        private void DictComboBoxLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            CruiseLevel cruiseLevel = dictComboBoxLevel.SelectedItem as CruiseLevel;
            
            if(cruiseLevel == null)
            {
                numericUpDownMeters.Value = 0;
                numericUpDownFeet.Value = 0;
                textIVFR.Text = "";
                textBoxTrack.Text = "";
            }
            else
            {
                numericUpDownMeters.Value = cruiseLevel.Meter;
                numericUpDownFeet.Value = cruiseLevel.Feet;
                textIVFR.Text = cruiseLevel.IVFR;
                textBoxTrack.Text = cruiseLevel.Track;   
            }
        }
        #endregion
    }
}

