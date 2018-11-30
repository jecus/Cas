using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Форма для редактирования актуального состояния
    ///</summary>
    public partial class ActualStateDialog : Form
    {
        #region Fields

        private Component _currentComponent;
        private ActualStateRecord _currentActualStateRecord;

        private DateTime? _prevPerfDate;
        private DateTime? _nextPerfDate;
        private Lifelength _prevPerfLifelength;
        private Lifelength _nextPerfLifelength;
       
        #endregion

        #region Methods

        #region private ActualStateDialog()
        ///<summary>
        /// Создает форму без дополнительных параметров
        ///</summary>
        private ActualStateDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region public ActualStateDialog(ActualStateRecord actualStateRecord) : this()

        ///<summary>
        ///</summary>
        ///<param name="actualStateRecord"></param>
        public ActualStateDialog(ActualStateRecord actualStateRecord) 
            : this()
        {
            _currentActualStateRecord = actualStateRecord;
            _currentComponent = _currentActualStateRecord.ParentComponent;
            UpdateInformation();
        }

        #endregion

        #region public ActualStateDialog(Detail currentDetai) : this()
        ///<summary>
        ///</summary>
        ///<param name="currentComponent/param>
        public ActualStateDialog(Component currentComponent) 
            : this()
        {
            if (currentComponent == null)
                throw new ArgumentNullException("currentComponent", "must be not null");
            _currentComponent = currentComponent;

            _currentActualStateRecord = new ActualStateRecord { RecordDate = _currentComponent.ManufactureDate.Date};

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

            if (dateTimePicker1.Value > DateTime.Now)
            {
                if (message != "") message += "\n ";
                message += "Performance date must be less than current date.";
                return false;
            }
            if (dateTimePicker1.Value < _currentComponent.ManufactureDate)
            {
                if (message != "") message += "\n ";
                message += "Performance date must be grather than manufacture date.";
                return false;
            }

            Lifelength perfLifeLength = lifelengthViewer_LastCompliance.Lifelength;

            if(_currentActualStateRecord.ItemId <= 0)
            {
                IWorkRegime workRegime = comboBoxFlightRegime.SelectedItem as IWorkRegime ?? FlightRegime.UNK;
                ActualStateRecord acr = _currentComponent.ActualStateRecords[dateTimePicker1.Value, workRegime];
                if (acr != null)
                {
                    //Актуальное состояние на заданную дату есть
                    message = string.Format("On a given date {0} have a saved record", 
                                             SmartCore.Auxiliary.Convert.GetDateFormat(dateTimePicker1.Value));
                    return false;
                }

                acr = _currentComponent.ActualStateRecords.GetLastKnownRecord(dateTimePicker1.Value, workRegime);
                if (acr != null && perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
                {
                    message = "Performance source must be grather than " + acr.OnLifelength;
                    return false;
                }

                acr = _currentComponent.ActualStateRecords.GetFirstKnownRecord(dateTimePicker1.Value, workRegime);
                if (acr != null && perfLifeLength.IsGreaterByAnyParameter(acr.OnLifelength))
                {
                    message = "Performance source must be less than " + acr.OnLifelength;
                    return false;
                }
            }
            //else
            //{
            //    ActualStateRecord acr = _currentDetail.ActualStateRecords[dateTimePicker1.Value];
            //    if (acr != null)
            //    {
            //        if (acr.ItemId != _currentActualStateRecord.ItemId)
            //        {
            //            //Актуальное состояние на заданную дату есть
            //            message = string.Format("On a given date {0} have a saved record",
            //                                     SmartCore.Auxiliary.Convert.GetDateFormat(dateTimePicker1.Value));
            //            return false;   
            //        }
            //        ActualStateRecord lastKnownRecord = _currentDetail.ActualStateRecords.GetLastKnownRecord(dateTimePicker1.Value);
            //        if (lastKnownRecord != null && perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
            //        {
            //            message = "Performance source must be grather than " + perfLifeLength;
            //            return false;
            //        }
            //        ActualStateRecord firstKnownRecord = _currentDetail.ActualStateRecords.GetFirstKnownRecord(dateTimePicker1.Value);
            //        if (firstKnownRecord != null && perfLifeLength.IsGreaterByAnyParameter(acr.OnLifelength))
            //        {
            //            message = "Performance source must be less than " + perfLifeLength;
            //            return false;
            //        }
            //    }
            //    acr = _currentDetail.ActualStateRecords.GetLastKnownRecord(dateTimePicker1.Value);
            //    if (acr != null && perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
            //    {
            //        if (acr.ItemId == _currentActualStateRecord.ItemId)
            //        {
            //            ActualStateRecord lastKnownRecord = _currentDetail.ActualStateRecords.GetLastKnownRecord(acr.RecordDate);
            //            if (lastKnownRecord != null && perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
            //            {
            //                message = "Performance source must be grather than " + perfLifeLength;
            //                return false;
            //            }
            //            ActualStateRecord firstKnownRecord = _currentDetail.ActualStateRecords.GetFirstKnownRecord(acr.RecordDate);
            //            if (firstKnownRecord != null && perfLifeLength.IsGreaterByAnyParameter(acr.OnLifelength))
            //            {
            //                message = "Performance source must be less than " + perfLifeLength;
            //                return false;
            //            }
            //        }
            //        else
            //        {
            //            if (perfLifeLength.IsLessByAnyParameter(acr.OnLifelength))
            //            {
            //                message = "Performance source must be grather than " + perfLifeLength;
            //                return false;
            //            }
            //            ActualStateRecord firstKnownRecord = _currentDetail.ActualStateRecords.GetFirstKnownRecord(acr.RecordDate);
            //            if (firstKnownRecord != null && perfLifeLength.IsGreaterByAnyParameter(acr.OnLifelength))
            //            {
            //                message = "Performance source must be less than " + perfLifeLength;
            //                return false;
            //            }
            //        }
            //        message = "Performance source must be grather than " + perfLifeLength;
            //        return false;
            //    }
            //}

            if(_prevPerfLifelength != null && perfLifeLength.IsLessByAnyParameter(_prevPerfLifelength))
            {
                if (message != "") message += "\n ";
                message += "Performance source must be grather than " + _prevPerfLifelength;
                return false;   
            }
            if (_nextPerfLifelength != null && perfLifeLength.IsGreaterByAnyParameter(_nextPerfLifelength))
            {
                if (message != "") message += "\n ";
                message += "Performance source must be less than " + _nextPerfLifelength;
                return false;
            }
            return true;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            _currentActualStateRecord.RecordDate = dateTimePicker1.Value.Date;
            _currentActualStateRecord.Remarks = textBox_Remarks.Text;
            _currentActualStateRecord.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;

            if (comboBoxFlightRegime.SelectedItem as IWorkRegime != null)
                _currentActualStateRecord.WorkRegime = (IWorkRegime)comboBoxFlightRegime.SelectedItem;
            else _currentActualStateRecord.WorkRegime = FlightRegime.UNK;
            try
            {
                GlobalObjects.ComponentCore.RegisterActualState(_currentComponent, _currentActualStateRecord); 
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving actual state", ex);
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
            if (_currentComponent.ManufactureRegion == ManufactureRegion.Soviet)
            {
                comboBoxFlightRegime.Items.Clear();
                comboBoxFlightRegime.Items.AddRange(FlightRegime.Items.ToArray());
                comboBoxFlightRegime.Enabled = true;
            }
            else if (_currentComponent.ManufactureRegion == ManufactureRegion.Western)
            {
                comboBoxFlightRegime.Items.Clear();
                comboBoxFlightRegime.Items.AddRange(LLPLifeLimitCategoryType.Items.ToArray());
                comboBoxFlightRegime.Enabled = true;    
            }

            if (_currentActualStateRecord == null) return;

            if (_currentActualStateRecord.OnLifelength != null)
                lifelengthViewer_LastCompliance.Lifelength = _currentActualStateRecord.OnLifelength;

            textBox_Remarks.Text = _currentActualStateRecord.Remarks ?? "";
            dateTimePicker1.Value = _currentActualStateRecord.RecordDate.Date;
            
            if(_currentActualStateRecord.WorkRegime != null)
            {
                if(comboBoxFlightRegime.Items.Contains(_currentActualStateRecord.WorkRegime))
                    comboBoxFlightRegime.SelectedItem = _currentActualStateRecord.WorkRegime;
            }

            if (_currentActualStateRecord.OnLifelength != null)
                lifelengthViewer_LastCompliance.Lifelength = _currentActualStateRecord.OnLifelength;
        }
        #endregion

        #region private void SetParams()
        private void SetParams()
        {
            #region Определение ограничений по ресурсу и дате выполнения
            if (_currentActualStateRecord.ItemId > 0)
            {
                //редактируется старая запись
                IWorkRegime workRegime = comboBoxFlightRegime.SelectedItem as IWorkRegime ?? FlightRegime.UNK;
                List<ActualStateRecord> asrs =
                    _currentComponent.ActualStateRecords.Where(r => r.WorkRegime == workRegime)
                                                     .OrderBy(r => r.RecordDate.Date)
                                                     .ToList();

                int index = asrs.Count > 0 ? asrs.IndexOf(_currentActualStateRecord) : 0;
                if (index == 0)
                {
                    //редактируется первая запись о выполнении
                    _prevPerfDate = null;
                    _prevPerfLifelength = null;
                    if (asrs.Count > 1)
                    {
                        //было сделано много записей о выполнении
                        _nextPerfDate = asrs[index + 1].RecordDate.Date;
                        _nextPerfLifelength = asrs[index + 1].OnLifelength;
                    }
                    else
                    {
                        _nextPerfDate = null;
                        _nextPerfLifelength = null;
                    }
                }
                else if (index < asrs.Count - 1)
                {
                    //редактируется запись из середины списка записей о выполнении
                    _prevPerfDate = asrs[index - 1].RecordDate.Date;
                    _prevPerfLifelength = asrs[index - 1].OnLifelength;

                    _nextPerfDate = asrs[index + 1].RecordDate.Date;
                    _nextPerfLifelength = asrs[index + 1].OnLifelength;
                }
                else //(index == _currentDirective.PerformanceRecords.Count - 1)
                {
                    //редактируется последняя запись
                    _prevPerfDate = asrs[index - 1].RecordDate.Date;
                    _prevPerfLifelength = asrs[index - 1].OnLifelength;
                    _nextPerfDate = null;
                    _nextPerfLifelength = null;
                }
            }


            lifelengthViewer_LastCompliance.MinLifelength = _prevPerfLifelength ?? Lifelength.Zero;
            lifelengthViewer_LastCompliance.MaxLifelength =
                _nextPerfLifelength ?? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentComponent);

            dateTimePicker1.MinDate = _prevPerfDate != null
                ? (DateTime)_prevPerfDate
                : DateTimeExtend.GetCASMinDateTime();

            dateTimePicker1.MaxDate = _nextPerfDate != null
                ? (DateTime)_nextPerfDate
                : DateTime.Today;
            #endregion
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

        #region private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

        private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            if (_prevPerfDate != null)
            {
                if (dateTimePicker1.Value < _prevPerfDate.Value) dateTimePicker1.Value = _prevPerfDate.Value;
            }
            if (_nextPerfDate != null)
            {
                if (dateTimePicker1.Value > _nextPerfDate.Value)
                    dateTimePicker1.Value = _nextPerfDate.Value;
            }
            else if (dateTimePicker1.Value > DateTime.Now)
                dateTimePicker1.Value = DateTime.Now;

            Lifelength lifelength = lifelengthViewer_LastCompliance.Lifelength;
            lifelengthViewer_LastCompliance.Lifelength = new Lifelength
            {
                TotalMinutes = lifelength.TotalMinutes,
                Cycles = lifelength.Cycles,
                Days = (dateTimePicker1.Value - _currentComponent.ManufactureDate).Days
            };

            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;
        }
        #endregion

        #region private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxFlightRegimeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFlightRegime.SelectedItem != null && ((IWorkRegime)comboBoxFlightRegime.SelectedItem).IsDeleted)
                comboBoxFlightRegime.BackColor = Color.FromArgb(Highlight.Red.Color);
            else comboBoxFlightRegime.BackColor = Color.White;

            SetParams();
        }
        #endregion

        #endregion

        #region Events
        #endregion
    }
}
