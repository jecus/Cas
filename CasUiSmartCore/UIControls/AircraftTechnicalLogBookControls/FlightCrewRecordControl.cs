using System;
using System.Drawing;
using System.Linq;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class FlightCrewRecordControl : EditObjectControl
    {
        private CommonDictionaryCollection<Occupation> _specializations 
            = new CommonDictionaryCollection<Occupation>();
        private CommonCollection<Specialist> _specialists = new CommonCollection<Specialist>();

        #region public FlightCrewRecord FlightCrewRecord

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public FlightCrewRecord FlightCrewRecord
        {
            get { return AttachedObject as FlightCrewRecord; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public Specialist Specialist

        /// <summary>
        /// 
        /// </summary>
        public Specialist Specialist
        {
            get { return comboSpecialist.SelectedItem != null ? comboSpecialist.SelectedItem as Specialist : null; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public FlightCrewRecordControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private FlightCrewRecordControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public FlightCrewRecordControl(FlightCrewRecord runup) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public FlightCrewRecordControl(FlightCrewRecord runup)
            : this()
        {
            AttachedObject = runup;
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
            if (FlightCrewRecord != null)
            {
                if (comboSpecialization.SelectedItem is Occupation)
                {
                    FlightCrewRecord.Occupation = ((Occupation)comboSpecialization.SelectedItem);
                }
                if (comboSpecialist.SelectedItem is Specialist)
                {
                    FlightCrewRecord.Specialist = ((Specialist)comboSpecialist.SelectedItem);
                }
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

            _specializations.Clear();
            _specializations.AddRange(((CommonDictionaryCollection<Occupation>)GlobalObjects.CasEnvironment.GetDictionary<Occupation>()).ToArray());
            _specialists.Clear();
            _specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO,Specialist>());
            if (FlightCrewRecord != null)
            {
                comboSpecialization.Items.Clear();
                comboSpecialization.Items.AddRange(_specializations.ToArray());
                comboSpecialist.Items.Clear();

                if (FlightCrewRecord.ItemId > 0)
                {
                    comboSpecialization.SelectedItem = FlightCrewRecord.Occupation;
                    Specialist selectedSpec = _specialists.GetItemById(FlightCrewRecord.Specialist.ItemId);
                    if(selectedSpec != null)
                        comboSpecialist.SelectedItem = selectedSpec;
                    else
                    {
                        //Искомый специалист недействителен
                        comboSpecialist.Items.Add(FlightCrewRecord.Specialist);
                        comboSpecialist.SelectedItem = FlightCrewRecord.Specialist;
                    }
                }
                else
                {
                    comboSpecialization.SelectedItem = FlightCrewRecord.Occupation;
                    comboSpecialist.SelectedItem = FlightCrewRecord.Specialist != null
                        ? _specialists.GetItemById(FlightCrewRecord.Specialist.ItemId)
                        : null;
                }

                if (comboSpecialist.SelectedItem != null && ((Specialist)comboSpecialist.SelectedItem).IsDeleted)
                    comboSpecialist.BackColor = Color.FromArgb(Highlight.Red.Color);
                else comboSpecialist.BackColor = Color.White;
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
            return comboSpecialist.SelectedItem != null && comboSpecialization.SelectedItem != null;
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
            get { return labelSpecialization.Visible; }
            set
            {
                labelSpecialization.Visible = value;
                labelSpecialist.Visible = value;
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

        #region private void ComboSpecializationSelectedIndexChanged(object sender, EventArgs e)
        private void ComboSpecializationSelectedIndexChanged(object sender, EventArgs e)
        {
            Occupation occupation = comboSpecialization.SelectedItem as Occupation;

            comboSpecialist.Items.Clear();
            if(occupation != null)
            {
                comboSpecialist.Items.AddRange(_specialists.Where(s => s.Occupation == occupation).ToArray());
                comboSpecialist.SelectedItem = _specialists.GetItemById(occupation.ItemId);
            }
            else
            {
                comboSpecialist.SelectedItem = null;
            }
        }
        #endregion

        #region private void ComboSpecialistSelectedIndexChanged(object sender, EventArgs e)
        private void ComboSpecialistSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSpecialist.SelectedItem != null && ((Specialist)comboSpecialist.SelectedItem).IsDeleted)
                comboSpecialist.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboSpecialist.BackColor = Color.White;

            if (CrewMemberChanged != null)
                CrewMemberChanged(this, EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;
        /// <summary>
        /// Возникает при изменении члена экипажа
        /// </summary>
        public event EventHandler CrewMemberChanged;

        #endregion

    }
}
