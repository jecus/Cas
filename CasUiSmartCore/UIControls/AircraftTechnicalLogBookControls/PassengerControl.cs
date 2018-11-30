using System;
using CAS.UI.Interfaces;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class PassengerControl : EditObjectControl
    {

        #region public FlightPassengerRecord FlightPassengerRecord

        /// <summary>
        /// Агрегат с которым связан контрол
        /// </summary>
        public FlightPassengerRecord FlightPassengerRecord
        {
            get { return AttachedObject as FlightPassengerRecord; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public AGWCategory PassengerCategory

        /// <summary>
        /// 
        /// </summary>
        public AGWCategory PassengerCategory
        {
            get { return dictComboPassCategory.SelectedItem != null ? dictComboPassCategory.SelectedItem as AGWCategory : null; }
        }
        #endregion

        #region public int CountEconomy

        /// <summary>
        /// 
        /// </summary>
        public int CountEconomy
        {
            get { return (int)numericUpDownEconomy.Value; }
        }
        #endregion

        #region public int CountBusiness

        /// <summary>
        /// 
        /// </summary>
        public int CountBusiness
        {
            get { return (int)numericUpDownBusiness.Value; }
        }
        #endregion

        #region public int CountFirst

        /// <summary>
        /// 
        /// </summary>
        public int CountFirst
        {
            get { return (int)numericUpDownFirst.Value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public PassengerControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private PassengerControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public PassengerControl(FlightPassengerRecord) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PassengerControl(FlightPassengerRecord runup)
            : this()
        {
            AttachedObject = runup;
        }
        #endregion

        #region public PassengerControl(AircraftFlight flight) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public PassengerControl(AircraftFlight flight)
            : this()
        {
            AttachedObject = new FlightPassengerRecord {FlightId = flight.ItemId};
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
            if (FlightPassengerRecord != null)
            {
                if (dictComboPassCategory.SelectedItem is AGWCategory)
                {
                    FlightPassengerRecord.PassengerCategory = (AGWCategory)dictComboPassCategory.SelectedItem;
                }

                FlightPassengerRecord.CountEconomy = (Int16)numericUpDownEconomy.Value;
                FlightPassengerRecord.CountBusiness = (Int16)numericUpDownBusiness.Value;
                FlightPassengerRecord.CountFirst = (Int16)numericUpDownFirst.Value;
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

            dictComboPassCategory.Type = typeof(AGWCategory);

            if (FlightPassengerRecord != null)
            {
                dictComboPassCategory.SelectedItem = FlightPassengerRecord.PassengerCategory;
                numericUpDownEconomy.Value = FlightPassengerRecord.CountEconomy;
                numericUpDownBusiness.Value = FlightPassengerRecord.CountBusiness;
                numericUpDownFirst.Value = FlightPassengerRecord.CountFirst;
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
            return dictComboPassCategory.SelectedItem != null;
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
                labelEconomy.Visible = value;
                labelBusiness.Visible = value;
                labelFirst.Visible = value;
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
            if (PassengerCountChanged != null)
                PassengerCountChanged(this, EventArgs.Empty);     
        }
        #endregion

        #region private void DictComboPassCategorySelectedIndexChanged(object sender, EventArgs e)
        private void DictComboPassCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (PassengerCategoryChanged != null)
                PassengerCategoryChanged(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        ///<summary>
        ///</summary>
        public event EventHandler PassengerCountChanged;

        ///<summary>
        ///</summary>
        public event EventHandler PassengerCategoryChanged;
        #endregion
    }
}
