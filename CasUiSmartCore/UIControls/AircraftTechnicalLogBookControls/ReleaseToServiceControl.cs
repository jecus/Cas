using System;
using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{

    /// <summary>
    /// Контрол позволяет задать данные сертификата на дальнейшую эксплуатацию ВС
    /// </summary>
    public partial class ReleaseToServiceControl : Interfaces.EditObjectControl
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
         * Своиства
         */

        #region public DateTime ReleaseDate
        ///<summary>
        /// Возвращает или задает дату выпуска в тех. эксплуатацю
        ///</summary>
        public DateTime ReleaseDate
        {
            get { return dateTimePickerDate.Value; }
            set { dateTimePickerDate.Value = value; }
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
                Flight.CertificateOfReleaseToService.CheckPerformed = "";
                if (checkPFC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " PFC ";
                if (checkTC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " TC ";
                if (checkDY.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " DY ";
	            if (checkBoxRC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " RC ";
	            if (checkBoxSC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " SC ";
	            if (checkBoxA.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " A ";
	            if (checkBoxC.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " C ";
	            if (checkAdd.Checked) Flight.CertificateOfReleaseToService.CheckPerformed += " ADD ";
				Flight.CertificateOfReleaseToService.RecordDate = dateTimePickerDate.Value.Date;
                //Flight.CertificateOfReleaseToService.AuthorizationNo = textAuth.Text;
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
            if (Flight != null && Flight.CertificateOfReleaseToService != null && 
                !string.IsNullOrEmpty(Flight.CertificateOfReleaseToService.CheckPerformed))
            {
                checkPFC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("PFC");
                checkTC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("TC");
                checkDY.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("DY");
                dateTimePickerDate.Value = Flight.CertificateOfReleaseToService.RecordDate.Date;
	            checkBoxRC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("RC");
	            checkBoxSC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("SC");
	            checkBoxA.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("A");
	            checkBoxC.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("C");
	            checkAdd.Checked = Flight.CertificateOfReleaseToService.CheckPerformed.Contains("ADD");
				//textAuth.Text = Flight.CertificateOfReleaseToService.AuthorizationNo;
			}
            else
            {
                checkPFC.Checked = checkTC.Checked = checkDY.Checked = checkBoxRC.Checked = checkBoxSC.Checked = checkBoxA.Checked = checkBoxC.Checked = checkAdd.Checked = false;
                textAuth.Text = "";
                dateTimePickerDate.Value = DateTime.Today;
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
            //if (UsefulMethods.StringToDate(textDate.Text) == null)
            //{

            //    SimpleBalloon.Show(textDate, ToolTipIcon.Warning, "Incorrect date format", "Please enter the date in the following format: DD.MM.YYYY"); 

            //    return false;
            //}

            //
            return true;
        }
        #endregion

        /*
         * События формы
         */

        #region private void CheckPfcCheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент времени может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPfcCheckedChanged(object sender, EventArgs e)
        {
            //if (checkPFC.Checked) 
            //    checkTC.Checked = checkDY.Checked = false;
        }
        #endregion

        #region private void CheckTcCheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTcCheckedChanged(object sender, EventArgs e)
        {
            //if (checkTC.Checked) checkPFC.Checked = checkDY.Checked = false;
        }
        #endregion

        #region private void checkDY_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// В один момент может быть отмечена только одна галочка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckDyCheckedChanged(object sender, EventArgs e)
        {
            //if (checkDY.Checked) checkPFC.Checked = checkTC.Checked = false;
        }
        #endregion

    }
}

