using System;
using System.Linq;
using CAS.UI.Interfaces;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class CargoRecordControl : EditObjectControl
    {

        #region public FlightCargoRecord FlightCargoRecord

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public FlightCargoRecord FlightCargoRecord
        {
            get { return AttachedObject as FlightCargoRecord; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public CargoCategory CargoCategory

        /// <summary>
        /// 
        /// </summary>
        public CargoCategory CargoCategory
        {
            get { return comboBoxCargoCategory.SelectedItem != null ? comboBoxCargoCategory.SelectedItem as CargoCategory : null; }
        }
        #endregion

        #region public Measure Measure

        /// <summary>
        /// 
        /// </summary>
        public Measure Measure
        {
            get { return comboBoxMeasure.SelectedItem != null ? comboBoxMeasure.SelectedItem as Measure : null; }
        }
        #endregion

        #region public double Weigth

        /// <summary>
        /// 
        /// </summary>
        public double Weigth
        {
            get { return (double)numericUpDownWeight.Value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public CargoRecordControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private CargoRecordControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public CargoRecordControl(FlightCargoRecord) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public CargoRecordControl(FlightCargoRecord runup)
            : this()
        {
            AttachedObject = runup;
        }
        #endregion

        #region public CargoRecordControl(AircraftFlight flight) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public CargoRecordControl(AircraftFlight flight)
            : this()
        {
            AttachedObject = new FlightCargoRecord {FlightId = flight.ItemId};
        }
        #endregion

        /*
         * Своиства
         */

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
            if (FlightCargoRecord != null)
            {
                if (comboBoxCargoCategory.SelectedItem is CargoCategory)
                {
                    FlightCargoRecord.CargoCategory = (CargoCategory)comboBoxCargoCategory.SelectedItem;
                }
                if (comboBoxMeasure.SelectedItem is Measure)
                {
                    FlightCargoRecord.Measure = (Measure)comboBoxMeasure.SelectedItem;
                }

                FlightCargoRecord.Weigth = (double)numericUpDownWeight.Value;
            }

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
            foreach (Measure o in Measure.Items.Where(i=>i.MeasureCategory == MeasureCategory.Mass))
                comboBoxMeasure.Items.Add(o);
            
            comboBoxCargoCategory.Items.Clear();
            foreach (CargoCategory o in CargoCategory.Items)
                comboBoxCargoCategory.Items.Add(o);

            if (FlightCargoRecord != null)
            {
                comboBoxCargoCategory.SelectedItem = FlightCargoRecord.CargoCategory 
                    ?? CargoCategory.UNK;
                comboBoxMeasure.SelectedItem = FlightCargoRecord.Measure;
                numericUpDownWeight.Value = (decimal)FlightCargoRecord.Weigth;
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
            return comboBoxCargoCategory.SelectedItem != null && comboBoxMeasure.SelectedItem != null;
        }

        #endregion

        /*
         * Реализация
         */

        #region public bool ShowHeaders { get; set; }

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelPassCategory.Visible; }
            set
            {
                labelPassCategory.Visible = value;
                labelWeight.Visible = value;
                labelMeasure.Visible = value;
            }
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void NumericUpDownValueChanged(object sender, EventArgs e)
        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (WeightChanged != null)
                WeightChanged(this, EventArgs.Empty);
        }
        #endregion

        #region private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxMeasureSelectedIndexChanged(object sender, EventArgs e)
        {
            if (WeightChanged != null)
                WeightChanged(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;
        ///<summary>
        ///</summary>
        public event EventHandler WeightChanged;

        #endregion
    }
}
