using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Форма для редактирования записи о смене программы обслуживания
    ///</summary>
    public partial class MaintenanceProgramChangeDialog : MetroForm
    {
        #region Fields

        private bool _needActualState;
        private Aircraft _currentAircraft;
        private MaintenanceProgramChangeRecord _currentMaintenanceProgramChangeRecord;
        private List<MaintenanceCheckRecordGroup> _maintenanceCheckRecordGroups;
       
        #endregion

        #region Methods

        #region private MaintenanceProgramChangeDialog()
        ///<summary>
        /// Создает форму без дополнительных параметров
        ///</summary>
        private MaintenanceProgramChangeDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region public MaintenanceProgramChangeDialog(MaintenanceProgramChangeRecord maintenanceProgramChangeDialog) : this()

        ///<summary>
        ///</summary>
        ///<param name="maintenanceProgramChangeRecord"></param>
        ///<param name="maintenanceCheckRecordGroups"></param>
        public MaintenanceProgramChangeDialog(MaintenanceProgramChangeRecord maintenanceProgramChangeRecord, List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups) 
            : this()
        {
            _currentMaintenanceProgramChangeRecord = maintenanceProgramChangeRecord;
            _currentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentMaintenanceProgramChangeRecord.ParentAircraftId);
            _maintenanceCheckRecordGroups = maintenanceCheckRecordGroups;

            UpdateInformation();
        }

        #endregion

        #region public MaintenanceProgramChangeDialog(Aircraft currentAircraft, List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups) : this()

        ///<summary>
        ///</summary>
        ///<param name="currentAircraft"></param>
        ///<param name="maintenanceCheckRecordGroups"></param>
        public MaintenanceProgramChangeDialog(Aircraft currentAircraft, List<MaintenanceCheckRecordGroup> maintenanceCheckRecordGroups) 
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "must be not null");
            _currentAircraft = currentAircraft;

            _maintenanceCheckRecordGroups = maintenanceCheckRecordGroups;
            _currentMaintenanceProgramChangeRecord = new MaintenanceProgramChangeRecord { RecordDate = _currentAircraft.ManufactureDate.Date};

            UpdateInformation();
        }

        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";

            if(comboBoxCheckRecord.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "You should select a record of the maintenance program check";
                comboBoxCheckRecord.Focus();
                return false;    
            }

            //if (checkRecordCombobox.Value > DateTime.Now)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Record date must be less than current date.";
            //    return false;
            //}
            //if (checkRecordCombobox.Value < _currentAircraft.ManufactureDate)
            //{
            //    if (message != "") message += "\n ";
            //    message += "Record date must be grather than manufacture date.";
            //    return false;
            //}

            //Lifelength perfLifeLength = lifelengthViewer_LastCompliance.Lifelength;

            //if (_currentMaintenanceProgramChangeRecord.ItemId <= 0)
            //{
            //    MaintenanceProgramChangeRecord acr = _currentAircraft.MaintenanceProgramChangeRecords[checkRecordCombobox.Value];
            //    if (acr != null)
            //    {
            //        //Запись о смене программы обслуживания на заданную дату есть
            //        message = string.Format("On a given date {0} have a saved record",
            //                                 SmartCore.Auxiliary.Convert.GetDateFormat(checkRecordCombobox.Value));
            //        return false;
            //    }

            //    acr = _currentAircraft.MaintenanceProgramChangeRecords.GetLastKnownRecord(checkRecordCombobox.Value);
            //    if (acr != null && perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
            //    {
            //        message = "Record source must be grather than " + acr.OnLifelength;
            //        return false;
            //    }

            //    acr = _currentAircraft.MaintenanceProgramChangeRecords.GetFirstKnownRecord(checkRecordCombobox.Value);
            //    if (acr != null && perfLifeLength.IsGreaterByAnyParameter(acr.OnLifelength))
            //    {
            //        message = "Record source must be less than " + acr.OnLifelength;
            //        return false;
            //    }
            //}

            //Lifelength parentLifeLenght =
            //    GlobalObjects.CasEnvironment.Calculator.GetOpeningFlightLifelength(_currentAircraft,
            //                                                                 checkRecordCombobox.Value);
            ////наработка родителя на след. день после введения записи
            //Lifelength lifelengthTomorrow =
            //    GlobalObjects.CasEnvironment.Calculator.GetOpeningFlightLifelength(_currentAircraft, checkRecordCombobox.Value.AddDays(1));

            //if (lifelengthViewer_LastCompliance.Lifelength.Days == null)
            //{
            //    lifelengthViewer_LastCompliance.Lifelength.Days = parentLifeLenght.Days;
            //}

            //if (perfLifeLength.IsLessByAnyParameter(parentLifeLenght))
            //{
            //    //вводимая наработка на дату выполнения меньше, чем расчитанная калькулятором
            //    if (message != "") message += "\n ";
            //    message +=
            //        string.Format("Performance source on date: {0} \nmust be grather than {1}",
            //                       checkRecordCombobox.Value,
            //                       parentLifeLenght.ToHoursAndCyclesFormat());
            //    return false;
            //}
            //if (perfLifeLength.IsGreaterByAnyParameter(lifelengthTomorrow))
            //{
            //    //вводимая наработка на дату выполнения больше, 
            //    //чем расчитанная калькулятором на след. день 
            //    int lifelengthHours = Convert.ToInt32(parentLifeLenght.Hours);
            //    int lifelengthCycles = Convert.ToInt32(parentLifeLenght.Cycles);
            //    int lifelengthTomHours = Convert.ToInt32(lifelengthTomorrow.Hours);
            //    int lifelengthTomCycles = Convert.ToInt32(lifelengthTomorrow.Cycles);

            //    if (lifelengthHours < lifelengthTomHours || lifelengthCycles < lifelengthTomCycles)
            //    {
            //        //при этом наработка на след. день после вводимой даты 
            //        //больше наработки на вводимую дату
            //        //выдача сообщения о некорректности данных
            //        if (message != "") message += "\n ";
            //        message +=
            //            string.Format("Performance source on date: {0} \nmust be less than {1}",
            //                            checkRecordCombobox.Value,
            //                            lifelengthTomorrow.ToHoursAndCyclesFormat());
            //        return false;
            //    }
            //    if (lifelengthHours == lifelengthTomHours || lifelengthCycles == lifelengthTomCycles)
            //    {
            //        //наработка на след. день после вводимой даты 
            //        //равна наработке на вводимую дату
            //        //выдача сообщения о возможности введения актуального состояния  
            //        if (message != "") message += "\n ";
            //        message += string.Format(@"Lifelength {0} for {1} is defferent" +
            //                                  "\nlifelength {2} for {3}." +
            //                                  "\nRegister actual state? (date:{4} lifelength:{0})",
            //                                 perfLifeLength,
            //                                 _currentAircraft,
            //                                 parentLifeLenght,
            //                                 _currentAircraft,
            //                                 checkRecordCombobox.Value);
            //        if (MessageBox.Show(message,
            //                            (string)new GlobalTermsProvider()["SystemName"],
            //                            MessageBoxButtons.YesNo,
            //                            MessageBoxIcon.Exclamation,
            //                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //        {
            //            _needActualState = true;
            //        }
            //    }
            //}
            //if (_prevPerfLifelength != null && perfLifeLength.IsLessByAnyParameter(_prevPerfLifelength))
            //{
            //    if (message != "") message += "\n ";
            //    message += "Performance source must be grather than " + _prevPerfLifelength;
            //    return false;
            //}
            //if (_nextPerfLifelength != null && perfLifeLength.IsGreaterByAnyParameter(_nextPerfLifelength))
            //{
            //    if (message != "") message += "\n ";
            //    message += "Performance source must be less than " + _nextPerfLifelength;
            //    return false;
            //}

            return true;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            MaintenanceCheckRecordGroup mcrg = (MaintenanceCheckRecordGroup)comboBoxCheckRecord.SelectedItem;
            MaintenanceCheckRecord mcr = mcrg.GetMinIntervalCheckRecord();
            if(mcr != null)
            {
                _currentMaintenanceProgramChangeRecord.CalculatedPerformanceSource = 
                    mcr.CalculatedPerformanceSource.IsNullOrZero() 
                    ? new Lifelength(mcr.ParentCheck.Interval * mcr.PerformanceNum) 
                    : new Lifelength(mcr.CalculatedPerformanceSource);
                _currentMaintenanceProgramChangeRecord.PerformanceNum = mcr.PerformanceNum;
                _currentMaintenanceProgramChangeRecord.RecordDate = mcr.RecordDate;
                _currentMaintenanceProgramChangeRecord.MaintenanceCheckRecordId = mcr.ItemId;
            }
            _currentMaintenanceProgramChangeRecord.Remarks = textBox_Remarks.Text;
            _currentMaintenanceProgramChangeRecord.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;

            if (comboBoxMSG.SelectedItem is MSG)
                _currentMaintenanceProgramChangeRecord.MSG = (MSG)comboBoxMSG.SelectedItem;
            else _currentMaintenanceProgramChangeRecord.MSG = MSG.MSG2;
            try
            {
                GlobalObjects.MaintenanceCore.RegisterMaintenanceProgramChangeRecord(_currentAircraft, _currentMaintenanceProgramChangeRecord);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving maintenance program change record", ex);
                return false;
            }

            return true;
        }

        #endregion

        #region private bool Save()
        private bool Save()
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return SaveData();
        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Обновление информации ЭУ
        /// </summary>
        private void UpdateInformation()
        {
            comboBoxMSG.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(MSG)).Cast<MSG>().Where(msg => msg != MSG.Unknown))
                comboBoxMSG.Items.Add(o);
            comboBoxMSG.Enabled = true;  

            comboBoxCheckRecord.Items.Clear();
            comboBoxCheckRecord.Items.AddRange(_maintenanceCheckRecordGroups.Where(crg => crg.Grouping).ToArray());

            if (_currentMaintenanceProgramChangeRecord == null) return;

            if (_currentMaintenanceProgramChangeRecord.OnLifelength != null)
                lifelengthViewer_LastCompliance.Lifelength = _currentMaintenanceProgramChangeRecord.OnLifelength;

            textBox_Remarks.Text = _currentMaintenanceProgramChangeRecord.Remarks ?? "";

            if (comboBoxMSG.Items.Contains(_currentMaintenanceProgramChangeRecord.MSG))
                comboBoxMSG.SelectedItem = _currentMaintenanceProgramChangeRecord.MSG;

            MaintenanceCheckRecordGroup rg = _maintenanceCheckRecordGroups.FirstOrDefault(mcrg => mcrg.Records.Any(r => r.ItemId == _currentMaintenanceProgramChangeRecord.MaintenanceCheckRecordId));
            if (rg != null && comboBoxCheckRecord.Items.Contains(rg))
                comboBoxCheckRecord.SelectedItem = rg;

            if (_currentMaintenanceProgramChangeRecord.OnLifelength != null)
                lifelengthViewer_LastCompliance.Lifelength = _currentMaintenanceProgramChangeRecord.OnLifelength;
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region private void ComboBoxCheckRecordSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxCheckRecordSelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxCheckRecord.SelectedItem as MaintenanceCheckRecordGroup == null)
                return;

            MaintenanceCheckRecordGroup maintenanceCheckRecordGroup = comboBoxCheckRecord.SelectedItem as MaintenanceCheckRecordGroup;
            MaintenanceCheckRecord maintenanceCheckRecord = maintenanceCheckRecordGroup.GetMinIntervalCheckRecord();
            if(maintenanceCheckRecord == null)
                return;
            lifelengthViewer_LastCompliance.Lifelength = new Lifelength(maintenanceCheckRecord.OnLifelength);
        }
        #endregion

        #endregion

        #region Events
        #endregion
    }
}
