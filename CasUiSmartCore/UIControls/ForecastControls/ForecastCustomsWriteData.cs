using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.Analyst;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = System.Convert;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    ///</summary>
    public partial class ForecastCustomsWriteData : Form
    {
        private MaintenanceCheckCollection _checkItems;

        private Forecast _currentForecast;
        private AirFleetForecast _airFleetForrecast;
        private bool _callAdvanced;

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #region Properties

        #region public Forecast Forecast
        ///<summary>
        ///</summary>
        public Forecast Forecast
        {
            get { return _currentForecast; }
        }
        #endregion
        
        #region public bool CallAdvanced
        /// <summary>
        /// Определяет, нухно ли вызвать расширенную форму
        /// </summary>
        public bool CallAdvanced 
        {
            get { return _callAdvanced; }
        }
        #endregion

        #region public DateTime ForecastDate
        ///<summary>
        /// Возвращает дату на которую строится прогноз
        ///</summary>
        public DateTime ForecastDate
        {
            get
            {
                if (tabControlMain.SelectedTab == tabPageDateResource)
                    return dateTimePickerForecastDate.Value;
                return dateTimePickerTo.Value;
            }
        }
        #endregion

        #region public bool IncludeNotifyes
        ///<summary>
        /// Нужно ли включить директивы, вошедшие в стадию предупреждения
        ///</summary>
        public bool IncludeNotifyes
        {
            get { return checkBoxNotifyes.Checked; }
        }
        #endregion

        #region public bool IncludePercents
        ///<summary>
        /// Нужно ли включит задачи, остаток ресурка которых меньше указанного кол-ва процентов
        ///</summary>
        public bool IncludePercents
        {
            get { return checkBoxIncludePercents.Checked; }
        }
        #endregion

        #region public int Percent
        ///<summary>
        /// количество ресурса(в процентах) до следующего выполнения задачи
        ///</summary>
        public int Percent
        {
            get { return (int)numericUpDownPercents.Value; }
        }
        #endregion

        #endregion

        #region Constructors

        #region public ForecastCustomsWriteData()
        ///<summary>
        ///</summary>
        public ForecastCustomsWriteData()
        {
            InitializeComponent();
        }
        #endregion

        #region public ForecastCustomsWriteData(Forecast forecast) : this()
        ///<summary>
        ///</summary>
        ///<param name="forecastData">данные прогнозя для изменения</param>
        public ForecastCustomsWriteData(Forecast forecastData) : this()
        {
            _currentForecast = forecastData;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerRunWorkerCompleted;

            UpdateInformation();
        }
        #endregion

        #region public ForecastCustomsWriteData(AirFleetForecast airFleetForecast) : this()

        ///<summary>
        ///</summary>
        ///<param name="airFleetForecast">данные прогнозя для изменения</param>
        public ForecastCustomsWriteData(AirFleetForecast airFleetForecast)
            : this()
        {
            _airFleetForrecast = airFleetForecast;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
            _animatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerRunWorkerCompleted;

            UpdateInformation();
        }
        #endregion

        #endregion

        #region protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            comboBoxCheck.Items.Clear();

            comboBoxByDate.DataSource = null;
            comboBoxByDate.Items.Clear();

            if (_checkItems == null || _checkItems.Count <= 0) return;
            //чеки IsDeleted свойство которых равно false
            MaintenanceCheck[] validChecks = _checkItems.GroupingCheckByType(true)
                .SelectMany(gc => gc.ToArray())
                .SelectMany(gbt => gbt.Checks)
                .ToArray();
            //След. выполнения чеков
            List<NextPerformance> nextPerformances = new List<NextPerformance>();
            foreach (MaintenanceCheck validCheck in validChecks)
            {
                if (validCheck.Grouping)
                    nextPerformances.AddRange(validCheck.GetPergormanceGroupWhereCheckIsSenior().ToArray());
                else nextPerformances.AddRange(validCheck.NextPerformances);
            }
            //Выполнения, сгруппированные по дате
            IEnumerable<IGrouping<DateTime, NextPerformance>> groupByDate =
                nextPerformances.Where(p => p.PerformanceDate != null)
                                .GroupBy(p => Convert.ToDateTime(p.PerformanceDate).Date)
                                .OrderBy(g => g.Key);
            //Строковое представление сгруппированных чеков
            List<KeyValuePair<string, NextPerformance>> strings = new List<KeyValuePair<string, NextPerformance>>();
            foreach (IGrouping<DateTime, NextPerformance> grouping in groupByDate)
            {
                IEnumerable<MaintenanceCheck> mcs = grouping.Select(g => g.Parent as MaintenanceCheck);
                MaintenanceCheck max = mcs.GetMaxCheck();
                if (max == null)
                    continue;
                string result = SmartCore.Auxiliary.Convert.GetDateFormat(grouping.Key) + " ( ";

                //Добавление в название присутствующих на данную дату чеков программы обслуживания
                IEnumerable<NextPerformance> maintenanceCheckPerformances =
                    grouping.Where(np => np.Parent != null && np.Parent is MaintenanceCheck);
                foreach (NextPerformance maintenanceCheckPerformance in maintenanceCheckPerformances)
                {
                    if (maintenanceCheckPerformance is MaintenanceNextPerformance)
                    {
                        MaintenanceNextPerformance maintenancePerformance = maintenanceCheckPerformance as MaintenanceNextPerformance;
                        if (maintenancePerformance.PerformanceGroup != null)
                            result += maintenancePerformance.PerformanceGroup.GetGroupName() + " ";
                        else if (maintenanceCheckPerformance.Parent != null && maintenanceCheckPerformance.Parent is MaintenanceCheck)
                            result += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name + " ";
                    }
                    else if (maintenanceCheckPerformance.Parent != null && maintenanceCheckPerformance.Parent is MaintenanceCheck)
                        result += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name + " ";
                }

                //Добавление в название присутствующих на данную дату директив летной годности
                IEnumerable<NextPerformance> adPerformances =
                    grouping.Where(np => np.Parent != null && np.Parent is Directive);
                if (adPerformances.Count() > 0)
                    result += "AD ";

                //Добавление в название присутствующих на данную дату компонентов или задач по ним
                IEnumerable<NextPerformance> componentPerformances =
                    grouping.Where(np => np.Parent != null && (np.Parent is Component || np.Parent is ComponentDirective));
                if (componentPerformances.Count() > 0)
                    result += "Comp ";

                //Добавление в название присутствующих на данную дату MPD
                IEnumerable<NextPerformance> mpdPerformances =
                    grouping.Where(np => np.Parent != null && np.Parent is MaintenanceDirective);
                if (maintenanceCheckPerformances.Count() == 0 && mpdPerformances.Count() > 0)
                    result += "MPD ";

                result += ")";
                strings.Add(new KeyValuePair<string, NextPerformance>(result, max.NextPerformances.FirstOrDefault(p => p.PerformanceDate != null && p.PerformanceDate.Value.Date == grouping.Key)));
            }

            comboBoxByDate.DisplayMember = "Key";
            comboBoxByDate.ValueMember = "Value";
            comboBoxByDate.DataSource = strings;

            comboBoxCheck.Items.AddRange(validChecks);
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today.AddDays(1);

            MaintenanceCheck mc =
                _checkItems.Where(c => c.CheckType.Priority > 0)
                           .SelectMany(c => c.GetPergormanceGroupWhereCheckIsSenior())
                           .Where(p => p.PerformanceDate != null && p.Parent is MaintenanceCheck)
                           .OrderBy(p => p.PerformanceDate)
                           .Select(p => p.Parent)
                           .Cast<MaintenanceCheck>()
                           .FirstOrDefault();
            comboBoxCheck.SelectedItem = mc ?? _checkItems[0];

            if(tabControlMain.SelectedTab == tabPageCheck)
            {
                if(_currentForecast == null)
                    return;
                ForecastData main = _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0];
                //Чеки и их выполнения уже загружены и просчитаны
                //Можно проставлять параметры
                if (main.SelectedForecastType == ForecastType.ForecastByPeriod)
                {
                    radioButtonByPeriod.Checked = true;
                    dateTimePickerFrom.Value = main.LowerLimit;
                    dateTimePickerTo.Value = main.ForecastDate;

                    radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                    numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
                }
                else if (main.SelectedForecastType == ForecastType.ForecastByCheck)
                {
                    if (main.NextPerformanceByDate)
                    {
                        radioButtonByDate.Checked = true;
                        comboBoxCheck.SelectedItem = main.NextPerformance.Parent;
                        comboBoxPerformance.SelectedItem = main.NextPerformance;
                    }
                    else
                    {
                        radioButtonByPerformance.Checked = true;
                        comboBoxByDate.SelectedItem =
                            comboBoxByDate.Items.OfType<NextPerformance>()
                                                .FirstOrDefault(np => np.PerformanceDate == main.NextPerformance.PerformanceDate);
                    }

                    radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                    numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                }
            }
        }
        #endregion

        #region protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов

            _animatedThreadWorker.ReportProgress(0, "load checks");

            if (_currentForecast == null || _currentForecast.ForecastDataForNonLifelenght != null)
            {
                e.Cancel = true;
                return;
            }

            var main = _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0];
            var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(main.BaseComponent.ParentAircraftId);
			if (aircraft == null)
            {
                e.Cancel = true;
                return;
            }


            if (_checkItems == null)
                _checkItems = new MaintenanceCheckCollection();
            _checkItems.Clear();
            try
            {
                _checkItems.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceCheck(GlobalObjects.AircraftsCore.GetAircraftById(main.BaseComponent.ParentAircraftId)));//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			}
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading directives", ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Калькуляция состояния директив

            _animatedThreadWorker.ReportProgress(40, "calculation of checks");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            //прогнозируемый ресурс
            var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);
            var groupingChecks = _checkItems.Where(c => c.Grouping);
            int? offsetMinutes =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Minutes))
                              .OrderBy(r => r)
                              .LastOrDefault();
            int? offsetCycles =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Cycles))
                              .OrderBy(r => r)
                              .LastOrDefault();
            int? offsetDays =
                groupingChecks.Select(c => c.Interval.GetSubresource(LifelengthSubResource.Calendar))
                              .OrderBy(r => r)
                              .LastOrDefault();
            var offset = new Lifelength(offsetDays, offsetCycles, offsetMinutes);
	        var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(aircraft.AircraftFrameId);
            var approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, aircraftFrame.AverageUtilization));
            var forecastData = new ForecastData(DateTime.Now.AddDays(approxDays),
														 aircraftFrame.AverageUtilization,
                                                         current);
            var mcc = new MaintenanceCheckCollection(_checkItems.Where(c => c.ParentAircraftId == aircraft.ItemId));

            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(mcc, aircraft.Schedule, forecastData);

            mcc.Clear();
            #endregion

            #region Фильтрация директив
            _animatedThreadWorker.ReportProgress(70, "filter directives");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            #region Сравнение с рабочими пакетами

            _animatedThreadWorker.ReportProgress(90, "comparison with the Work Packages");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            _animatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region public void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        public void CancelAsync()
        {
            if (_animatedThreadWorker.IsBusy)
                _animatedThreadWorker.CancelAsync();
        }
        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (_currentForecast != null && _currentForecast.Aircraft != null)
            {
                tabControlMain.Selected -= TabControlMainSelected;
                //строится прогноз по самолету
                ForecastData main = 
                    _currentForecast.Aircraft != null 
                        ? _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0] 
                        : _currentForecast.ForecastDataForNonLifelenght;
                if(main.SelectedForecastType == ForecastType.ForecastByDate)
                {
                    tabControlMain.SelectedTab = tabPageDateResource;

                    lifelengthViewer_ForecastResource.Lifelength = main.ForecastLifelength;
                    checkBoxNotifyes.Checked = main.IncludeNotifyes;
                    checkBoxIncludePercents.Checked = main.IncludePercents;
                    numericUpDownPercents.Value = main.Percents;

                    if (_currentForecast.ForecastDatas.Count <= 1) 
                        buttonAdvanced.Visible = false;
                }
                else
                {
                    tabControlMain.SelectedTab = tabPageCheck;

                    //Если Прогноз задан для выполнения чека, то производится запуск фонового потока для
                    //расчета выполнении чеков
                    if (_checkItems == null)
                    {
                        if (main.SelectedForecastType == ForecastType.ForecastByPeriod)
                        {
                            radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                            numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
                        }
                        else if (main.SelectedForecastType == ForecastType.ForecastByCheck)
                        {
                            radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                            numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                        }
                        _animatedThreadWorker.RunWorkerAsync();
                    }
                    else
                    {
                        //Чеки и их выполнения уже загружены и просчитаны
                        //Можно проставлять параметры
                        if (main.SelectedForecastType == ForecastType.ForecastByPeriod)
                        {
                            radioButtonByPeriod.Checked = true;
                            dateTimePickerFrom.Value = main.LowerLimit;
                            dateTimePickerTo.Value = main.ForecastDate;

                            radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                            numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
                        }
                        else if (main.SelectedForecastType == ForecastType.ForecastByCheck)
                        {
                            if (main.NextPerformanceByDate)
                            {
                                radioButtonByDate.Checked = true;
                                comboBoxCheck.SelectedItem = main.NextPerformance.Parent;
                                comboBoxPerformance.SelectedItem = main.NextPerformance;
                            }
                            else
                            {
                                radioButtonByPerformance.Checked = true;
                                comboBoxByDate.SelectedItem =
                                    comboBoxByDate.Items.OfType<NextPerformance>()
                                                        .FirstOrDefault(np => np.PerformanceDate == main.NextPerformance.PerformanceDate);
                            }

                            radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                            numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                        }   
                    }
                }

                lifelengthViewerCurrent.Lifelength = main.CurrentLifelength;

                if (main.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly)
                    radioButtonDayly.Checked = true;
                else
                    radioButtonMonthly.Checked = true;

                numericUpDownHours.Value = (decimal)main.AverageUtilization.Hours;
                numericUpDownCycles.Value = (decimal)main.AverageUtilization.Cycles;

                tabControlMain.Selected += TabControlMainSelected;

            }
            else
            {
                radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                buttonAdvanced.Visible = false;

                radioButtonByPeriod.Checked = true;
                radioButtonByDate.Enabled = radioButtonByPerformance.Enabled = false;
            }
        }

        #endregion

        #region private AverageUtilization GetAverageUtilization()
        private AverageUtilization GetAverageUtilization()
        {
            double eps = 0.00000001;
            double hours = (double)numericUpDownHours.Value;
            double cycles = (double)numericUpDownCycles.Value;

            if(radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null; 
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                MessageBox.Show(numericUpDownHours.Value + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            AverageUtilization au = new AverageUtilization();
            if (radioButtonDayly.Checked)
                au.SelectedInterval = UtilizationInterval.Dayly;
            else au.SelectedInterval = UtilizationInterval.Monthly;

            if (Math.Abs(au.Hours - hours) > eps)
            {
                if (au.SelectedInterval == UtilizationInterval.Dayly)
                    au.HoursPerDay = hours;
                else
                    au.HoursPerMonth = hours;
            }
            if (Math.Abs(au.Cycles - cycles) > eps)
                if (au.SelectedInterval == UtilizationInterval.Dayly)
                    au.CyclesPerDay = cycles;
                else
                    au.CyclesPerMonth = cycles;
            return au;
        }
        #endregion

        #region private bool SaveData()
        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            if(tabControlMain.SelectedTab == tabPageDateResource)
            {
                if (_currentForecast != null)
                {
                    _currentForecast.ForecastDate = dateTimePickerForecastDate.Value;
                    foreach (ForecastData fd in _currentForecast.ForecastDatas)
                    {
                        fd.AverageUtilization = GetAverageUtilization();
                        //Функция вызывается несколько раз для того что бы каждый
                        //объект прогноза для базовой детали ссылался на собственный
                        //экземпляр утилизации и мог его изменять не затрагивая при этом
                        //утилизацию другой базовой детали.
                        if (fd.AverageUtilization == null) return false;
                        fd.ForecastDate = dateTimePickerForecastDate.Value;
                        fd.ForecastLifelength = lifelengthViewer_ForecastResource.Lifelength;
                        fd.IncludeNotifyes = checkBoxNotifyes.Checked;
                        fd.IncludePercents = checkBoxIncludePercents.Checked;
                        fd.Percents = (int)numericUpDownPercents.Value;
                        fd.SelectedForecastType = ForecastType.ForecastByDate;
                    }
                    return true;
                }
                if(_airFleetForrecast != null)
                {
                    foreach (Forecast forecast in _airFleetForrecast)
                    {
                        //составление нового массива данных по прогнозам
                        foreach (ForecastData fd in forecast.ForecastDatas)
                        {
                            fd.AverageUtilization = GetAverageUtilization();
                            fd.ForecastDate = dateTimePickerForecastDate.Value;
                            fd.ForecastLifelength = lifelengthViewer_ForecastResource.Lifelength;
                            fd.IncludeNotifyes = checkBoxNotifyes.Checked;
                            fd.IncludePercents = checkBoxIncludePercents.Checked;
                            fd.Percents = (int)numericUpDownPercents.Value;
                            fd.SelectedForecastType = ForecastType.ForecastByDate;
                        }
                    }
                    return true;
                }
            }
            if (tabControlMain.SelectedTab == tabPageCheck)
            {
                #region By Performance

                if (radioButtonByPerformance.Checked)
                {
                    MaintenanceCheck selectedCheck = comboBoxCheck.SelectedItem as MaintenanceCheck;
                    NextPerformance selectedPerformance = comboBoxPerformance.SelectedItem as NextPerformance;

                    if (selectedCheck == null)
                    {
                        MessageBox.Show("Not Select Maintenance Check", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxCheck.Focus();
                        return false;
                    }

                    if (selectedPerformance == null)
                    {
                        MessageBox.Show("Not Select Performance", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxPerformance.Focus();
                        return false;
                    }

                    double approvals = (double)(numericUpDownApprovals.Value / 100);
                    MaintenanceCheck minCheckSameType =
                        _checkItems.GetMinStepCheck(selectedCheck.Schedule, selectedCheck.Grouping,
                                                    selectedCheck.Resource, selectedCheck.CheckType);

                    if(_currentForecast != null)
                    {
                        foreach (ForecastData fd in _currentForecast.ForecastDatas)
                        {
                            fd.AverageUtilization = GetAverageUtilization();

                            if (fd.AverageUtilization == null) return false;

                            Lifelength current = fd.CurrentLifelength;
                            Lifelength performance = new Lifelength(selectedPerformance.PerformanceSource) +
                                    (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                            Lifelength lowerLimit = new Lifelength(selectedPerformance.PerformanceSource) -
                                    (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                            Lifelength offset = performance - current;
                            Lifelength lowerOffset = lowerLimit - current;
                            offset.Resemble(selectedCheck.Interval);
                            lowerOffset.Resemble(selectedCheck.Interval);

                            Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, fd.AverageUtilization));
                            Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, fd.AverageUtilization));
                            //определение ресурсов прогноза для каждой базовой детали
                            //DateTime date = selectedPerformance.PerformanceDate != null
                            //                   ? selectedPerformance.PerformanceDate.Value
                            //                   : DateTime.Today;
                            DateTime date = DateTime.Today;
                            fd.LowerLimit = date.AddDays(approxDaysToLower);
                            fd.ForecastDate = date.AddDays(approxDays);
                            fd.NextPerformance = selectedPerformance;
                            fd.NextPerformanceByDate = false;
                            fd.SelectedForecastType = ForecastType.ForecastByCheck;
                        }
                        return true;    
                    }
                    if (_airFleetForrecast != null)
                    {
                        foreach (Forecast forecast in _airFleetForrecast)
                        {
                            //составление нового массива данных по прогнозам
                            foreach (ForecastData fd in forecast.ForecastDatas)
                            {
                                fd.AverageUtilization = GetAverageUtilization();

                                if (fd.AverageUtilization == null) 
                                    return false;

                                Lifelength current = fd.CurrentLifelength;
                                Lifelength performance = new Lifelength(selectedPerformance.PerformanceSource) +
                                        (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                                Lifelength lowerLimit = new Lifelength(selectedPerformance.PerformanceSource) -
                                        (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                                Lifelength offset = performance - current;
                                Lifelength lowerOffset = lowerLimit - current;
                                offset.Resemble(selectedCheck.Interval);
                                lowerOffset.Resemble(selectedCheck.Interval);

                                Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, fd.AverageUtilization));
                                Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, fd.AverageUtilization));
                                //определение ресурсов прогноза для каждой базовой детали
                                //DateTime date = selectedPerformance.PerformanceDate != null
                                //                   ? selectedPerformance.PerformanceDate.Value
                                //                   : DateTime.Today;
                                DateTime date = DateTime.Today;
                                fd.LowerLimit = date.AddDays(approxDaysToLower);
                                fd.ForecastDate = date.AddDays(approxDays);
                                fd.NextPerformance = selectedPerformance;
                                fd.NextPerformanceByDate = false;
                                fd.SelectedForecastType = ForecastType.ForecastByCheck;
                            }
                        }
                        return true;
                    }
                }
                #endregion

                #region ByDate

                if (radioButtonByDate.Checked)
                {
                    NextPerformance selectedPerformance = comboBoxByDate.SelectedValue as NextPerformance;

                    if (selectedPerformance == null)
                    {
                        MessageBox.Show("Not Select Performance", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxByDate.Focus();
                        return false;
                    }

                    MaintenanceCheck selectedCheck = selectedPerformance.Parent as MaintenanceCheck;

                    if (selectedCheck == null)
                    {
                        MessageBox.Show("Not Select Maintenance Check", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBoxByDate.Focus();
                        return false;
                    }

                    double approvals = (double)(numericUpDownApprovals.Value / 100);
                    MaintenanceCheck minCheckSameType =
                        _checkItems.GetMinStepCheck(selectedCheck.Schedule, selectedCheck.Grouping,
                                                    selectedCheck.Resource, selectedCheck.CheckType);

                    if(_currentForecast != null)
                    {
                        //составление нового массива данных по прогнозам
                        foreach (ForecastData fd in _currentForecast.ForecastDatas)
                        {
                            fd.AverageUtilization = GetAverageUtilization();

                            if (fd.AverageUtilization == null) return false;

                            Lifelength current = fd.CurrentLifelength;
                            Lifelength performance = new Lifelength(selectedPerformance.PerformanceSource) +
                                    (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                            Lifelength lowerLimit = new Lifelength(selectedPerformance.PerformanceSource) -
                                    (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                            Lifelength offset = performance - current;
                            Lifelength lowerOffset = lowerLimit - current;
                            offset.Resemble(selectedCheck.Interval);
                            lowerOffset.Resemble(selectedCheck.Interval);

                            Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, fd.AverageUtilization));
                            Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, fd.AverageUtilization));
                            //определение ресурсов прогноза для каждой базовой детали
                            //DateTime date = selectedPerformance.PerformanceDate != null
                            //                   ? selectedPerformance.PerformanceDate.Value
                            //                   : DateTime.Today;
                            DateTime date = DateTime.Today;
                            fd.LowerLimit = date.AddDays(approxDaysToLower);
                            fd.ForecastDate = date.AddDays(approxDays);
                            fd.NextPerformance = selectedPerformance;
                            fd.NextPerformanceByDate = true;
                            fd.NextPerformanceString = comboBoxByDate.Text;
                            fd.SelectedForecastType = ForecastType.ForecastByCheck;
                        }
                        return true;
                    }
                    if (_airFleetForrecast != null)
                    {
                        foreach (Forecast forecast in _airFleetForrecast)
                        {
                            //составление нового массива данных по прогнозам
                            foreach (ForecastData fd in forecast.ForecastDatas)
                            {
                                fd.AverageUtilization = GetAverageUtilization();

                                if (fd.AverageUtilization == null) return false;

                                Lifelength current = fd.CurrentLifelength;
                                Lifelength performance = new Lifelength(selectedPerformance.PerformanceSource) +
                                        (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                                Lifelength lowerLimit = new Lifelength(selectedPerformance.PerformanceSource) -
                                        (minCheckSameType != null ? minCheckSameType.Interval * approvals : selectedCheck.Interval * approvals);
                                Lifelength offset = performance - current;
                                Lifelength lowerOffset = lowerLimit - current;
                                offset.Resemble(selectedCheck.Interval);
                                lowerOffset.Resemble(selectedCheck.Interval);

                                Double approxDays = Convert.ToDouble(AnalystHelper.GetApproximateDays(offset, fd.AverageUtilization));
                                Double approxDaysToLower = Convert.ToDouble(AnalystHelper.GetApproximateDays(lowerOffset, fd.AverageUtilization));
                                //определение ресурсов прогноза для каждой базовой детали
                                //DateTime date = selectedPerformance.PerformanceDate != null
                                //                   ? selectedPerformance.PerformanceDate.Value
                                //                   : DateTime.Today;
                                DateTime date = DateTime.Today;
                                fd.LowerLimit = date.AddDays(approxDaysToLower);
                                fd.ForecastDate = date.AddDays(approxDays);
                                fd.NextPerformance = selectedPerformance;
                                fd.NextPerformanceByDate = true;
                                fd.SelectedForecastType = ForecastType.ForecastByCheck;
                            }
                        }
                        return true;
                    }
                }
                #endregion

                #region ByPeriod

                if (radioButtonByPeriod.Checked)
                {
                    if(_currentForecast != null)
                    {
                        foreach (ForecastData fd in _currentForecast.ForecastDatas)
                        {
                            fd.AverageUtilization = GetAverageUtilization();

                            if (fd.AverageUtilization == null) return false;

                            //определение ресурсов прогноза для каждой базовой детали
                            fd.LowerLimit = dateTimePickerFrom.Value;
                            fd.ForecastDate = dateTimePickerTo.Value;
                            fd.SelectedForecastType = ForecastType.ForecastByPeriod;
                        }
                        return true;    
                    }
                    if(_airFleetForrecast != null)
                    {
                        foreach (Forecast forecast in _airFleetForrecast)
                        {
                            //составление нового массива данных по прогнозам
                            foreach (ForecastData fd in forecast.ForecastDatas)
                            {
                                fd.AverageUtilization = GetAverageUtilization();

                                if (fd.AverageUtilization == null) return false;

                                //определение ресурсов прогноза для каждой базовой детали
                                fd.LowerLimit = dateTimePickerFrom.Value;
                                fd.ForecastDate = dateTimePickerTo.Value;
                                fd.SelectedForecastType = ForecastType.ForecastByPeriod;
                            }
                        }
                        return true;    
                    }
                }
                #endregion

                return false;
            }
            return false;
        }

        #endregion

        #region private void DateTimePickerForecastDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerForecastDateValueChanged(object sender, EventArgs e)
        {
            if(_currentForecast == null)return;

            ForecastData main = _currentForecast.Aircraft != null 
                ? _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0]
                : _currentForecast.ForecastDataForNonLifelenght;
            
            if(main == null)return;
            
            Lifelength baseDetailLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(main.BaseComponent);

            if (dateTimePickerForecastDate.Value <= DateTime.Today)
            {
                //если дата прогноза меньше сегодняшней, то выводиться зписанная наработка на эту дату
                lifelengthViewer_ForecastResource.Lifelength =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(main.BaseComponent, dateTimePickerForecastDate.Value);
                Lifelength different = new Lifelength(lifelengthViewer_ForecastResource.Lifelength);
                different.Substract(baseDetailLifeLenght);
                lifelengthViewerDifferentSource.Lifelength = different;
            }
            else
            {
                //если дата прогноза выше сегодняшней, то сначала вычисляется
                //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
                //между сегодняшним днем и днем прогноза

                //если не задана сердняя утилизация, то прогноз строить нельзя
                AverageUtilization au = GetAverageUtilization();
                if (au == null) return;

                Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, dateTimePickerForecastDate.Value));
                lifelengthViewerDifferentSource.Lifelength = average;
                baseDetailLifeLenght.Add(average);
                lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
            }
        }
        #endregion

        #region private void CheckBoxIncludePercentsClick(object sender, EventArgs e)

        private void CheckBoxIncludePercentsClick(object sender, EventArgs e)
        {
            numericUpDownPercents.Enabled = checkBoxIncludePercents.Checked;
        }
        #endregion

        #region private void NumericUpDownsValueChanged(object sender, EventArgs e)
        private void NumericUpDownsValueChanged(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal) 23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal) 743.9;
            }
            AverageUtilization au = GetAverageUtilization();
            if (au == null || dateTimePickerForecastDate.Value <= DateTime.Today) return;

            ForecastData main = _currentForecast.Aircraft != null
                ? _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0]
                : _currentForecast.ForecastDataForNonLifelenght;

            if (main == null) return;
            
            //наработка агрегата на сегодня
            Lifelength baseDetailLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(main.BaseComponent);

            if (dateTimePickerForecastDate.Value <= DateTime.Today)
            {
                //если дата прогноза меньше сегодняшней, то выводиться зписанная наработка на эту дату
                Lifelength different = new Lifelength(lifelengthViewer_ForecastResource.Lifelength);
                different.Substract(baseDetailLifeLenght);
                lifelengthViewerDifferentSource.Lifelength = different;
            }
            else
            {
                //если дата прогноза выше сегодняшней, то сначала вычисляется
                //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
                //между сегодняшним днем и днем прогноза

                Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, dateTimePickerForecastDate.Value));
                lifelengthViewerDifferentSource.Lifelength = average;
                baseDetailLifeLenght.Add(average);
                lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
            }
        }
        #endregion

        #region private void RadioButtonDaylyClick(object sender, EventArgs e)
        private void RadioButtonDaylyClick(object sender, EventArgs e)
        {
            if (radioButtonDayly.Checked && numericUpDownHours.Value >= 24)
            {
                numericUpDownHours.Value = (decimal)23.9;
            }
            if (radioButtonMonthly.Checked && numericUpDownHours.Value >= 744)
            {
                numericUpDownHours.Value = (decimal)743.9;
            }
            AverageUtilization au = GetAverageUtilization();

            if (_currentForecast == null) return;
            if (au == null || dateTimePickerForecastDate.Value <= DateTime.Today) return;

            if (dateTimePickerForecastDate.Value <= DateTime.Today) return;
            //если дата прогноза выше сегодняшней, то сначала вычисляется
            //наработка на сегодняшний день, а к ней добавляется среднепрогнозируемая наработка
            //между сегодняшним днем и днем прогноза

            ForecastData main = _currentForecast.Aircraft != null
                                    ? _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0]
                                    : _currentForecast.ForecastDataForNonLifelenght;
            //наработка агрегата на сегодня
            Lifelength baseDetailLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(main.BaseComponent);

            Lifelength average = AnalystHelper.GetUtilization(au, Calculator.GetDays(DateTime.Today, dateTimePickerForecastDate.Value));
            lifelengthViewerDifferentSource.Lifelength = average;
            baseDetailLifeLenght.Add(average);
            lifelengthViewer_ForecastResource.Lifelength = baseDetailLifeLenght;
        }
        #endregion

        #region private void ButtonAdvancedClick(object sender, EventArgs e)
        private void ButtonAdvancedClick(object sender, EventArgs e)
        {
            _callAdvanced = true;
            DialogResult = DialogResult.None;
            Close();
        }
        #endregion

        #region private void RadioButtonCheckedChanged(object sender, EventArgs e)

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb == null)
                return;

            radioButtonByPerformance.CheckedChanged -= RadioButtonCheckedChanged;
            radioButtonByDate.CheckedChanged -= RadioButtonCheckedChanged;
            radioButtonByPeriod.CheckedChanged -= RadioButtonCheckedChanged;

            if (radioButtonByPerformance == rb && radioButtonByPerformance.Checked)
            {
                radioButtonByDate.Checked =
                    comboBoxByDate.Enabled =
                    radioButtonByPeriod.Checked =
                    dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = false;

                comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled =
                    numericUpDownApprovals.Enabled = true;

                radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
            }
            if (radioButtonByDate == rb && radioButtonByDate.Checked)
            {
                radioButtonByPerformance.Checked =
                    comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled =
                    radioButtonByPeriod.Checked =
                    dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = false;

                comboBoxByDate.Enabled =
                    numericUpDownApprovals.Enabled = true;

                radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
            }
            if (radioButtonByPeriod == rb && radioButtonByPeriod.Checked)
            {
                radioButtonByPerformance.Checked =
                    comboBoxCheck.Enabled =
                    comboBoxPerformance.Enabled =
                    radioButtonByDate.Checked =
                    comboBoxByDate.Enabled =
                    numericUpDownApprovals.Enabled = false;

                dateTimePickerFrom.Enabled =
                    dateTimePickerTo.Enabled = true;

                radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
            }

            radioButtonByPerformance.CheckedChanged += RadioButtonCheckedChanged;
            radioButtonByDate.CheckedChanged += RadioButtonCheckedChanged;
            radioButtonByPeriod.CheckedChanged += RadioButtonCheckedChanged;
        }
        #endregion

        #region private void ComboBoxCheckSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxCheckSelectedIndexChanged(object sender, EventArgs e)
        {
            //Очистка комбобокса с выполнениями чека
            comboBoxPerformance.Items.Clear();
            comboBoxPerformance.SelectedItem = null;

            MaintenanceCheck mc = comboBoxCheck.SelectedItem as MaintenanceCheck;
            if (mc != null)
            {
                if (mc.Grouping)
                {
                    //Заполнение комбобокса с выполнениями чека
                    //"след. выполнениями" где чека является старшим
                    comboBoxPerformance.Items.AddRange(mc.GetPergormanceGroupWhereCheckIsSenior().ToArray());
                }
                else
                {
                    comboBoxPerformance.Items.AddRange(mc.NextPerformances.ToArray());
                }
            }
        }
        #endregion

        #region private void DateTimePickerFromToValueChanged(object sender, EventArgs e)

        private void DateTimePickerFromToValueChanged(object sender, EventArgs e)
        {
            if (_currentForecast == null) return;

            DateTimePicker dtp = sender as DateTimePicker;
            if (dtp == null)
                return;

            ForecastData main = _currentForecast.Aircraft != null
                ? _currentForecast.GetForecastDataFrame() ?? _currentForecast.ForecastDatas[0]
                : _currentForecast.ForecastDataForNonLifelenght;

            if (main == null) return;

            dateTimePickerFrom.ValueChanged -= DateTimePickerFromToValueChanged;
            dateTimePickerTo.ValueChanged -= DateTimePickerFromToValueChanged;

            if(_currentForecast.Aircraft != null)
            {
                if (dateTimePickerFrom == dtp)
                {
                    if (dateTimePickerFrom.Value < main.BaseComponent.ManufactureDate)
                        dateTimePickerFrom.Value = main.BaseComponent.ManufactureDate;
                    if (dateTimePickerFrom.Value >= dateTimePickerTo.Value)
                        dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
                }
                if (dateTimePickerTo == dtp)
                {
                    if (dateTimePickerTo.Value < main.BaseComponent.ManufactureDate)
                        dateTimePickerTo.Value = main.BaseComponent.ManufactureDate.AddDays(1);
                    if (dateTimePickerTo.Value <= dateTimePickerFrom.Value)
                        dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
                }    
            }
            else
            {
                DateTime min = DateTimeExtend.GetCASMinDateTime();
                if (dateTimePickerFrom == dtp)
                {
                    if (dateTimePickerFrom.Value < min)
                        dateTimePickerFrom.Value = min;
                    if (dateTimePickerFrom.Value >= dateTimePickerTo.Value)
                        dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
                }
                if (dateTimePickerTo == dtp)
                {
                    if (dateTimePickerTo.Value < min)
                        dateTimePickerTo.Value = min.AddDays(1);
                    if (dateTimePickerTo.Value <= dateTimePickerFrom.Value)
                        dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
                }  
            }

            dateTimePickerFrom.ValueChanged += DateTimePickerFromToValueChanged;
            dateTimePickerTo.ValueChanged += DateTimePickerFromToValueChanged;
        }
        #endregion

        #region private void TabControlMainSelected(object sender, TabControlEventArgs e)

        private void TabControlMainSelected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage == tabPageDateResource)
            {
                checkBoxNotifyes.Visible = true;
                checkBoxIncludePercents.Visible = true;
                numericUpDownPercents.Visible = true;

                radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
            }
            else
            {
                checkBoxNotifyes.Visible = false;
                checkBoxIncludePercents.Visible = false;
                numericUpDownPercents.Visible = false;

                if (radioButtonByPerformance.Checked)
                {
                    radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                    numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                }
                if (radioButtonByDate.Checked)
                {
                    radioButtonMonthly.Enabled = radioButtonDayly.Enabled = false;
                    numericUpDownCycles.Enabled = numericUpDownHours.Enabled = false;
                }
                if (radioButtonByPeriod.Checked)
                {
                    radioButtonMonthly.Enabled = radioButtonDayly.Enabled = true;
                    numericUpDownCycles.Enabled = numericUpDownHours.Enabled = true;
                }

                //Если Прогноз задан для выполнения чека, то производится запуск фонового потока для
                //расчета выполнении чеков
                if (_checkItems == null)
                    _animatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (SaveData())
                DialogResult = DialogResult.OK;

            CancelAsync();
            Close();
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            _currentForecast = null;
            DialogResult = DialogResult.Cancel;

            CancelAsync();
            Close();
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

    }
}
