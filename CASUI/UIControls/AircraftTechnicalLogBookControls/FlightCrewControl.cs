using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;
using CAS.Core.Types.Dictionaries;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по экипажу полета
    /// </summary>
    public partial class FlightCrewControl : CAS.UI.Interfaces.EditObjectControl
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

        #region public FlightCrewControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public FlightCrewControl()
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
                ApplySpecialist(textCaptain, SpecializationCollection.Instance.Captain);
                ApplySpecialist(textCoPilot, SpecializationCollection.Instance.Copilot);
                ApplySpecialist(textGEAP, SpecializationCollection.Instance.GroundEngineerAP);
                ApplySpecialist(textGEAVI, SpecializationCollection.Instance.GroundEngineerAVI);
                ApplySpecialist(textLoadMaster, SpecializationCollection.Instance.LoadMaster);
                ApplySpecialist(textQualityControl, SpecializationCollection.Instance.QualityControl);
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
                FillTextBox(textCaptain, SpecializationCollection.Instance.Captain);
                FillTextBox(textCoPilot, SpecializationCollection.Instance.Copilot);
                FillTextBox(textGEAP, SpecializationCollection.Instance.GroundEngineerAP);
                FillTextBox(textGEAVI, SpecializationCollection.Instance.GroundEngineerAVI);
                FillTextBox(textLoadMaster, SpecializationCollection.Instance.LoadMaster);
                FillTextBox(textQualityControl, SpecializationCollection.Instance.QualityControl);
            }
            else
            {
                textCaptain.Text = textCoPilot.Text = textGEAP.Text = textGEAVI.Text = textLoadMaster.Text = textQualityControl.Text = "";
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
            // В этом контроле только текстовые данные
            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private void FillTextBox(TextBox textBox, Specialization s)
        /// <summary> 
        /// Заполняет поле информацией о сотруднике с нужной специализацией
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="s"></param>
        private void FillTextBox(TextBox textBox, Specialization s)
        {
            Specialist spec = Flight.GetSpecialist(s);
            textBox.Text = spec != null ? spec.FullName : "";
        }
        #endregion

        #region private void ApplySpecialist(TextBox textBox, Specialization s)
        /// <summary> 
        /// Находит нужного сотрудника и применяет к нему сделанные изменения
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="s"></param>
        private void ApplySpecialist(TextBox textBox, Specialization s)
        {
            Specialist spec = Flight.GetSpecialist(s);
            if (spec == null)
            {
                spec = new Specialist();
                spec.Specialization = s;
                spec.FullName = textBox.Text;
                Flight.AddSpecialistToCrew(spec);
            }
            else
            {
                spec.FullName = textBox.Text;
            }

        }
        #endregion

    }
}

