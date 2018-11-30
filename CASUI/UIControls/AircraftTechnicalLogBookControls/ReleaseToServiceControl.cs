using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using Auxiliary;
using CAS.Core.Types.ATLBs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет задать данные сертификата на дальнейшую эксплуатацию ВС
    /// </summary>
    public partial class ReleaseToServiceControl : CAS.UI.Interfaces.EditObjectControl
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

        #region public ReleaseToServiceControl()
        /// <summary>
        /// Контрол позволяет задать данные сертификата на дальнейшую эксплуатацию ВС
        /// </summary>
        public ReleaseToServiceControl()
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
            if (Flight != null && Flight.CertificateOfReleaseToService != null)
            {
                if (checkPFC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed = "PFC";
                else if (checkTC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed = "TC";
                else if (checkDY.Checked) Flight.CertificateOfReleaseToService.CheckPerformed = "DY";
                else Flight.CertificateOfReleaseToService.CheckPerformed = "";
                Flight.CertificateOfReleaseToService.Date = UsefulMethods.StringToDate(textDate.Text).Value;
                Flight.CertificateOfReleaseToService.AuthorizationNo = textAuth.Text;
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
            if (Flight != null && Flight.CertificateOfReleaseToService != null)
            {
                checkPFC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed == "PFC";
                checkTC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed == "TC";
                checkDY.Checked = Flight.CertificateOfReleaseToService.CheckPerformed == "DY";
                textDate.Text = UsefulMethods.NormalizeDate(Flight.CertificateOfReleaseToService.Date);
                textAuth.Text = Flight.CertificateOfReleaseToService.AuthorizationNo;
            }
            else
            {
                checkPFC.Checked = checkTC.Checked = checkDY.Checked = false;
                textDate.Text = textAuth.Text = "";
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
            if (!ValidateDate()) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateDate()
        /// <summary>
        /// Проверяем введенную дату
        /// </summary>
        /// <returns></returns>
        private bool ValidateDate()
        {
            if (UsefulMethods.StringToDate(textDate.Text) == null)
            {

                SimpleBalloon.Show(textDate, ToolTipIcon.Warning, "Incorrect date format", "Please enter the date in the following format: DD.MM.YYYY"); 

                return false;
            }

            //
            return true;
        }
        #endregion

        /*
         * События формы
         */

        #region private void checkPFC_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент времени может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkPFC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPFC.Checked) 
                checkTC.Checked = checkDY.Checked = false;
        }
        #endregion

        #region private void checkTC_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTC_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTC.Checked) checkPFC.Checked = checkDY.Checked = false;
        }
        #endregion

        #region private void checkDY_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkDY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDY.Checked) checkPFC.Checked = checkTC.Checked = false;
        }
        #endregion

    }
}

