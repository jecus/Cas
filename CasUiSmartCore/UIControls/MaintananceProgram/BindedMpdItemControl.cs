using System;
using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Analyst;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class BindedMpdItemControl : EditObjectControl
    {
        private DateTime? _prevPerfDate;
        private DateTime? _nextPerfDate;
        /// <summary>
        /// Запись о выполнении Чека программы обслуживания, с которым связано данное выполнение
        /// задачи программы обслуживания
        /// </summary>
        private readonly MaintenanceCheckRecord _maintenanceCheckRecord;
        private DirectiveRecord _maintenanceDirectiveRecord;

        #region public MaintenanceDirective MaintenanceDirective

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public MaintenanceDirective MaintenanceDirective
        {
            get { return AttachedObject as MaintenanceDirective; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public DirectiveRecord MaintenanceDirectiveRecord
        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public DirectiveRecord MaintenanceDirectiveRecord
        {
            get { return _maintenanceDirectiveRecord; }
        }
        #endregion

        #region public bool Checked
        /// <summary>
        /// возвращает или Задает значение выбора в чекбоксе
        /// </summary>
        public bool Checked
        {
            get { return checkBoxClose.Checked; }
            set
            {
                if (_maintenanceDirectiveRecord == null ||
                    _maintenanceDirectiveRecord.ItemId <= 0)
                    checkBoxClose.Checked = value;
            }
        }
        #endregion

        #region public DateTime ComplianceDate
        /// <summary>
        /// Задает дату выполнения для привязанных задач
        /// </summary>
        public DateTime ComplianceDate
        {
            set
            {
                if (_maintenanceDirectiveRecord == null ||
                    _maintenanceDirectiveRecord.ItemId <= 0)
                    dateTimePicker1.Value = value;
            }
        }
        #endregion
        /*
         * Конструктор
         */

        #region public BindedMpdItemControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public BindedMpdItemControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public BindedMpdItemControl(MaintenanceDirective mpd, MaintenanceCheckRecord maintenanceCheckRecord) : this()
        /// <summary>
        /// Контрол редактирует данные о закрытии привязанной директивы программы обслуживания
        /// </summary>
        public BindedMpdItemControl(MaintenanceDirective mpd, MaintenanceCheckRecord maintenanceCheckRecord)
            : this()
        {
            _maintenanceCheckRecord = maintenanceCheckRecord;
            AttachedObject = mpd;
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
            if (MaintenanceDirective != null)
            {
                if (_maintenanceDirectiveRecord != null && checkBoxClose.Checked == false)
                {
                    _maintenanceDirectiveRecord.IsDeleted = true;
                }
                if (_maintenanceDirectiveRecord != null && checkBoxClose.Checked)
                {
                    _maintenanceDirectiveRecord.RecordDate = dateTimePicker1.Value;
                }
                if (!MaintenanceDirective.IsClosed && _maintenanceDirectiveRecord == null && checkBoxClose.Checked )
                {
                    DirectiveRecord apr = null;
                    if(MaintenanceDirective.PerformanceRecords.Count > 0)
                    {
                        //Поиск записи о выполнении задачи программы обслуживания
                        //которая могла бы подойти под создаваемую запись
                        //о выполнении чека программы обслуживания
                        double? days;
                        if(MaintenanceDirective.MaintenanceCheck != null && 
                           MaintenanceDirective.MaintenanceCheck.ParentAircraft != null)
                        {
                            var a = MaintenanceDirective.MaintenanceCheck.ParentAircraft;
                            var partInterval = MaintenanceDirective.MaintenanceCheck.Interval * 0.2;
							var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(a.AircraftFrameId);
							var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
							days = AnalystHelper.GetApproximateDays(partInterval, averageUtilization);
                        }
                        else
                        {
                            var partInterval = MaintenanceDirective.RepeatInterval * 0.2;
                            days = AnalystHelper.GetApproximateDays(partInterval, MaintenanceDirective.ParentBaseComponent.AverageUtilization);
                        }

                        IEnumerable<DirectiveRecord> aprs = null;
                        if(days != null && days > 0)
                        {
                            double daysValue = Convert.ToDouble(days);
                            //Производится поиск записей о выполнении дата выполнения которых лежит
                            //в заданном диапозоне
                            aprs = MaintenanceDirective.PerformanceRecords.Where(
                                    pr => pr.RecordDate >= dateTimePicker1.Value.AddDays(-daysValue) &&
                                          pr.RecordDate <= dateTimePicker1.Value.AddDays(daysValue));
                        }
                        if(aprs != null && aprs.Count() > 0)
                        {
                            if(aprs.Count() == 1)
                            {
                                apr = aprs.First();
                            }
                            else
                            {
                                DirectiveRecord min = null;
                                double minDays = int.MaxValue;
                                foreach (DirectiveRecord record in aprs)
                                {
                                    if (min == null)
                                    {
                                        min = record;
                                        minDays = Math.Abs((min.RecordDate - dateTimePicker1.Value).TotalDays);
                                        continue;
                                    }
                                    double candidateMin = Math.Abs((record.RecordDate - dateTimePicker1.Value).TotalDays);
                                    if (candidateMin < minDays)
                                    {
                                        min = record;
                                        minDays = candidateMin;
                                    }
                                }
                                apr = min;
                            }
                        }
                    }

                    if(apr != null)
                    {
                        _maintenanceDirectiveRecord = apr;
                    }
                    else
                    {
                        NextPerformance performance =
                            MaintenanceDirective.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null
                                                                                    && p.PerformanceDate.Value.Date == dateTimePicker1.Value) ??
                            MaintenanceDirective.NextPerformances.LastOrDefault(p => p.PerformanceDate != null
                                                                                    && p.PerformanceDate < dateTimePicker1.Value) ??
                            MaintenanceDirective.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null
                                                                                    && p.PerformanceDate > dateTimePicker1.Value);
                        _maintenanceDirectiveRecord = new DirectiveRecord
                            {
                                PerformanceNum = performance != null ? performance.PerformanceNum : 0,
                                Parent = MaintenanceDirective,
                                ParentId = MaintenanceDirective.ItemId,
                                RecordDate = dateTimePicker1.Value
                            };   
                    }
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

            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            if(MaintenanceDirective != null)
            {
                textBoxMpdItem.Text = MaintenanceDirective.TaskNumberCheck;

                if (_maintenanceCheckRecord != null)
                {
                    _maintenanceDirectiveRecord =
                        MaintenanceDirective.PerformanceRecords
                            .FirstOrDefault(pr => pr.MaintenanceCheckRecordId == _maintenanceCheckRecord.ItemId);
                }
                
                checkBoxClose.Checked = _maintenanceDirectiveRecord != null;
                dateTimePicker1.Value = _maintenanceDirectiveRecord != null ? _maintenanceDirectiveRecord.RecordDate : DateTime.Today;

                #region Определение ограничений по ресурсу и дате выполнения
                if (_maintenanceDirectiveRecord != null && _maintenanceDirectiveRecord.ItemId > 0)
                {
                    //редактируется старая запись
                    int index = MaintenanceDirective.PerformanceRecords.IndexOf(_maintenanceDirectiveRecord);
                    if (index == 0)
                    {
                        //редактируется первая запись о выполнении
                        _prevPerfDate = null;
                        if (MaintenanceDirective.PerformanceRecords.Count > 1)
                        {
                            //было сделано много записей о выполнении
                            _nextPerfDate = MaintenanceDirective.PerformanceRecords[index + 1].RecordDate;
                        }
                        else if (MaintenanceDirective.NextPerformances.Count > 0)
                        {
                            //была сделана одна запись о выполнении и есть "след. выполнения"
                            _nextPerfDate = MaintenanceDirective.NextPerformances[0].PerformanceDate;
                        }
                        else
                        {
                            _nextPerfDate = null;
                        }
                    }
                    else if (index < MaintenanceDirective.PerformanceRecords.Count - 1)
                    {
                        //редактируется запись из середины списка записей о выполнении
                        _prevPerfDate = MaintenanceDirective.PerformanceRecords[index - 1].RecordDate;
                        _nextPerfDate = MaintenanceDirective.PerformanceRecords[index + 1].RecordDate;
                    }
                    else //(index == _currentDirective.PerformanceRecords.Count - 1)
                    {
                        //редактируется запись из середины списка записей о выполнении
                        _prevPerfDate = MaintenanceDirective.PerformanceRecords[index - 1].RecordDate;
                        if (MaintenanceDirective.NextPerformances.Count > 0)
                        {
                            //запись о выполнении сделана последней и есть "след. выполнения"
                            _nextPerfDate = MaintenanceDirective.NextPerformances[0].PerformanceDate;
                        }
                        else
                        {
                            _nextPerfDate = null;
                        }
                    }
                }
                else
                {
                    //редактируется новая запись
                    //int index = MaintenanceDirective.NextPerformances.IndexOf(_nextPerformance);
                    //if (index == 0)
                    //{
                    //    //редактируется первое "след.выполнение"
                    //    if (MaintenanceDirective.LastPerformance != null)
                    //    {
                    //        //была сделана запись о выполнении
                    //        _prevPerfDate = MaintenanceDirective.LastPerformance.RecordDate;
                    //        _prevPerfLifelength =
                    //            GlobalObjects.CasEnvironment.Calculator.GetLifelength(MaintenanceDirective.LifeLengthParent,
                    //                                                                  _prevPerfDate.Value);
                    //    }
                    //    else
                    //    {
                    //        _prevPerfDate = null;
                    //        _prevPerfLifelength = null;
                    //    }
                    //    if (MaintenanceDirective.NextPerformances.Count > 1)
                    //    {
                    //        //"след. выполнений" больше одного
                    //        _nextPerfDate = MaintenanceDirective.NextPerformances[1].PerformanceDate;
                    //        _nextPerfLifelength = MaintenanceDirective.NextPerformances[1].PerformanceSource;
                    //    }
                    //    else
                    //    {
                    //        _nextPerfDate = null;
                    //        _nextPerfLifelength = null;
                    //    }
                    //}
                    //else if (index < MaintenanceDirective.NextPerformances.Count - 1)
                    //{
                    //    //редактируется запись из середины списка "след. выполнений"
                    //    _prevPerfDate = MaintenanceDirective.NextPerformances[index - 1].PerformanceDate;
                    //    _prevPerfLifelength = MaintenanceDirective.NextPerformances[index - 1].PerformanceSource;

                    //    _nextPerfDate = MaintenanceDirective.NextPerformances[index + 1].PerformanceDate;
                    //    _nextPerfLifelength = MaintenanceDirective.NextPerformances[index + 1].PerformanceSource;
                    //}
                    //else //(index == _currentDirective.NextPerformances.Count - 1)
                    //{
                    //    //редактируется запись из середины списка записей о выполнении
                    //    _prevPerfDate = MaintenanceDirective.NextPerformances[index - 1].PerformanceDate;
                    //    _prevPerfLifelength = MaintenanceDirective.NextPerformances[index - 1].PerformanceSource;
                    //    _nextPerfDate = null;
                    //    _nextPerfLifelength = null;
                    //}
                }
                #endregion
            }

            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;

            EndUpdate();
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
            get { return labelMpdItem.Visible; }
            set
            {
                labelMpdItem.Visible = value;
                labelClose.Visible = value;
            }
        }

        #endregion

        #region private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)

        private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = checkBoxClose.Checked;
        }
        #endregion

        #region  private void DateTimePicker1ValueChanged(object sender, EventArgs e)
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

            dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;
        }
        #endregion

    }
}
