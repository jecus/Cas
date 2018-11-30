using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = System.Convert;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    ///</summary>
    public partial class AircraftSummaryControl : UserControl, IReference
    {
        #region Fields

        private MaintenanceCheckCollection _checkItems;
        private IEnumerable<MaintenanceCheckComplianceGroup> _complianceGroupCollection;
        private List<Document> _aircraftDocuments = new List<Document>();
        private bool _schedule;
        private Lifelength _aircraftLifelength;
        private Aircraft _currentAircraft;
        private BackgroundWorker BackGroundWorker = new BackgroundWorker();

        #endregion

        #region public AircraftSummaryControl()
        ///<summary>
        ///</summary>
        public AircraftSummaryControl()
        {
            InitializeComponent();
            
            linkMonthlyUtilization.DisplayerRequested += LinkMonthlyUtilizationDisplayerRequested;
            BackGroundWorker.DoWork += BwDoWork;
            BackGroundWorker.RunWorkerCompleted += BwRunWorkerCompleted;
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #region void BwDoWork(object sender, DoWorkEventArgs e)
        void BwDoWork(object sender, DoWorkEventArgs e)
        {
            FindLastCheck();
            FindNextCheck();
            UpdateDocumentation();
        }
        #endregion

        #region void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        void BwRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //tableLayoutPanel1.Visible = false;
            //tableLayoutPanel1.Refresh();
            //labelLastCheckName.Text = BT["LastCheckName"];
            //labelLastComplianceDate.Text = BT["LastComplianceDate"];
            //labelLastComplianceLL.Text = BT["LastComplianceLL"];
            //labelNextCheckName.Text = BT["NextCheckName"];
            //labelNextComplianceDate.Text = BT["NextComplianceDate"];
            //labelNextComplianceLL.Text = BT["NextComplianceLL"];
            //labelRamainLL.Text = BT["RemainLL"];
            //tableLayoutPanel1.Visible = true;
        }
        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего ВС
        /// </summary>
        public void SaveData()
        {
        }

        #endregion

        #region public void UpdateInformation(MaintenanceCheckCollection checkItems, Aircraft aircraft, bool schedule)

        ///<summary>
        ///</summary>
        ///<param name="checkItems"></param>
        ///<param name="aircraftDocuments"></param>
        ///<param name="aircraft"></param>
        ///<param name="schedule"></param>
        public void UpdateInformation(MaintenanceCheckCollection checkItems,
                                      IEnumerable<Document> aircraftDocuments,
                                      Aircraft aircraft,
                                      bool schedule)
        {
            _aircraftDocuments.Clear();
            _aircraftDocuments.AddRange(aircraftDocuments);
            _checkItems = checkItems;
            _schedule = schedule;
            _currentAircraft = aircraft;
            _complianceGroupCollection = _checkItems.GetNextComplianceCheckGroups(_schedule).OrderBy(c => c.GetNextComplianceDate());
            _aircraftLifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(aircraft);

            labelMSGValue.Text = aircraft.MSG.ToString();
            labelManufactureDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(aircraft.ManufactureDate);
            labelOwnerValue.Text = aircraft.Owner;
            labelOperatorValue.Text = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _currentAircraft.OperatorId).Name;
            labelAircraftTypeCertificateNoValue.Text = aircraft.TypeCertificateNumber;
            labelCurrentValue.Text = _aircraftLifelength.ToHoursMinutesAndCyclesFormat("FH", "FC");

            labelBasicEmptyWeightValue.Text = aircraft.BasicEmptyWeight.ToString();
            labelBasicEmptyWeightCargoConfigValue.Text = aircraft.BasicEmptyWeightCargoConfig.ToString();
            labelCargoCapacityContainerValue.Text = aircraft.CargoCapacityContainer;
            labelCruiseValue.Text = aircraft.Cruise;
            labelCruiseFuelFlowValue.Text = aircraft.CruiseFuelFlow;
            labelFuelCapacityValue.Text = aircraft.FuelCapacity;
            labelMaxCruiseAltitudeValue.Text = aircraft.MaxCruiseAltitude;
            labelMaxLandingWeightValue.Text = aircraft.MaxLandingWeight.ToString();
            labelMaxPayloadValue.Text = aircraft.MaxPayloadWeight.ToString();
            labelMaxTakeOffCrossWeightValue.Text = aircraft.MaxTakeOffCrossWeight.ToString();
            labelMaxZeroFuelWeightValue.Text = aircraft.MaxZeroFuelWeight.ToString();
            labelMaxTaxiWeightValue.Text = aircraft.MaxTaxiWeight.ToString();
            labelOpertionalEmptyWeightValue.Text = aircraft.OperationalEmptyWeight.ToString();
            labelCockpitSeatingValue.Text = aircraft.CockpitSeating;
            labelGalleysValue.Text = aircraft.Galleys;
            labelLavatoryValue.Text = aircraft.Lavatory;
            labelSeatingEconomyValue.Text = aircraft.SeatingEconomy.ToString();
            labelSeatingBusinessValue.Text = aircraft.SeatingBusiness.ToString();
            labelSeatingFirstValue.Text = aircraft.SeatingFirst.ToString();
            labelOvenValue.Text = aircraft.Oven;
            labelBoilerValue.Text = aircraft.Boiler;
            labelAirStairDoorsValue.Text = aircraft.AirStairsDoors;

			var aircraftEquipment = _currentAircraft.AircraftEquipments.Where(a => a.AircraftEquipmetType == AircraftEquipmetType.Equipmet);
			var aircraftApproval = _currentAircraft.AircraftEquipments.Where(a => a.AircraftEquipmetType == AircraftEquipmetType.TapeOfOperationApproval);

			var row = 4;
			foreach (var equipmentse in aircraftApproval)
	        {
				var labelTitle = new Label
				{
					Text = equipmentse.AircraftOtherParameter + " :",
					Font = new Font("Verdana", 14, GraphicsUnit.Pixel),
					ForeColor = Color.FromArgb(122, 122, 122),
					Width = 150
				};
				var labelValue = new Label
				{
					Text = equipmentse.Description,
					Font = new Font("Verdana", 14, GraphicsUnit.Pixel),
					ForeColor = Color.FromArgb(122, 122, 122),
					Width = 150
				};
				row++;
				tableLayoutPanelMain.Controls.Add(labelTitle, 2, row);
				tableLayoutPanelMain.Controls.Add(labelValue, 3, row);
			}

	        row = 4;
	        foreach (var equipmentse in aircraftEquipment)
	        {
		        var labelTitle = new Label
		        {
			        Text = equipmentse.AircraftOtherParameter + " :",
					Font = new Font("Verdana", 14, GraphicsUnit.Pixel),
					ForeColor = Color.FromArgb(122, 122, 122),
					Width = 150
				};
				var labelValue = new Label
				{
					Text = equipmentse.Description,
					Font = new Font("Verdana", 14, GraphicsUnit.Pixel),
					ForeColor = Color.FromArgb(122, 122, 122),
					Width = 150
				};
		        row++;
				tableLayoutPanelMain.Controls.Add(labelTitle, 6, row);
				tableLayoutPanelMain.Controls.Add(labelValue, 7, row);
			}

			//List<Document> operatorDocs =
			//    GlobalObjects.CasEnvironment.Loader.GetDocuments(aircraft.Operator, DocumentType.Certificate, true);
			//DocumentSubType aocType = (DocumentSubType)
			//    GlobalObjects.CasEnvironment.Dictionaries[typeof(DocumentSubType)].ToArray().FirstOrDefault(d => d.FullName == "AOC");
			//Document awDoc = aocType != null ? operatorDocs.FirstOrDefault(d => d.DocumentSubType == aocType) : null;
			//string aocUpTo = awDoc != null && awDoc.ValidTo
			//                    ? awDoc.DateValidTo.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
			//                    : "";

			var aircraftDocs = GlobalObjects.DocumentCore.GetAircraftDocuments(aircraft);
            var awType = (DocumentSubType)
                GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().ToArray().FirstOrDefault(d => d.FullName == "AW");
            var awDoc = awType != null ? aircraftDocs.FirstOrDefault(d => d.DocumentSubType.ItemId == awType.ItemId) : null;
            string awUpTo = awDoc != null && awDoc.IssueValidTo
                                ? awDoc.IssueDateValidTo.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                                : "";

            labelAWCValue.Text = awUpTo;

            tableLayoutPanelLastChecks.RowCount = 1;
            tableLayoutPanelLastChecks.RowStyles.Clear();
            tableLayoutPanelLastChecks.RowStyles.Add(new RowStyle());
            tableLayoutPanelLastChecks.Controls.Clear();
            tableLayoutPanelLastChecks.Controls.Add(labelLastCheck, 0, 0);
            tableLayoutPanelLastChecks.Controls.Add(labelLastDate, 1, 0);
            tableLayoutPanelLastChecks.Controls.Add(labelLastTsnCsn, 2, 0);
            
            tableLayoutPanelNextChecks.RowCount = 1;
            tableLayoutPanelNextChecks.RowStyles.Clear();
            tableLayoutPanelNextChecks.RowStyles.Add(new RowStyle());
            tableLayoutPanelNextChecks.Controls.Clear();
            tableLayoutPanelNextChecks.Controls.Add(labelNextCheck, 0, 0);
            tableLayoutPanelNextChecks.Controls.Add(labelNextDate, 1, 0);
            tableLayoutPanelNextChecks.Controls.Add(labelNextTsnCan, 2, 0);
            tableLayoutPanelNextChecks.Controls.Add(labelRemains, 3, 0);

            tableLayoutPanelDocs.RowCount = 1;
            tableLayoutPanelDocs.RowStyles.Clear();
            tableLayoutPanelDocs.RowStyles.Add(new RowStyle());
            tableLayoutPanelDocs.Controls.Clear();
            tableLayoutPanelDocs.Controls.Add(labelDocDescription, 0, 0);
            tableLayoutPanelDocs.Controls.Add(labelDocNumber, 1, 0);
            tableLayoutPanelDocs.Controls.Add(labelDocIssue, 2, 0);
            tableLayoutPanelDocs.Controls.Add(labelDocValidTo, 3, 0);
            tableLayoutPanelDocs.Controls.Add(labelDocRemain, 4, 0);

            if (_checkItems.Count == 0)
                return;

            if (!BackGroundWorker.IsBusy)
                BackGroundWorker.RunWorkerAsync();
            List<MaintenanceCheck> orderedBySchedule =
                checkItems.OrderBy(c => c.Schedule)
                          .ThenByDescending(c => c.Grouping)
                          .OrderBy(c => c.Resource)
                          .ToList();

            List<MaintenanceCheckGroupByType> checkGroups = new List<MaintenanceCheckGroupByType>();
            foreach (MaintenanceCheck check in orderedBySchedule)
            {
                MaintenanceCheckGroupByType group = checkGroups
                    .FirstOrDefault(g => g.Schedule == check.Schedule &&
                                         g.Grouping == check.Grouping &&
                                         g.Resource == check.Resource);
                if (group != null)
                {
                    group.Checks.Add(check);
                }
                else
                {
                    group = new MaintenanceCheckGroupByType(check.Schedule)
                    {
                        Grouping = check.Grouping,
                        Resource = check.Resource
                    };
                    group.Checks.Add(check);
                    checkGroups.Add(group);
                }
            }
        }
        #endregion

        #region private void FindLastCheck()
        private void FindLastCheck()
        {
            MaintenanceCheckGroupCollection[] groupByType =
                _checkItems.GroupingCheckByType(_schedule)
                    .OrderByDescending(g => g.GetLastComplianceDate())
                    .ToArray();

            MaintenanceCheckGroupCollection checkGroupCollectionOrdered =
                new MaintenanceCheckGroupCollection(groupByType.SelectMany(gbt => gbt.ToArray())
                                                               .OrderByDescending(gbt => gbt.LastComplianceGroupDate));
            foreach (MaintenanceCheckGroupByType checkGroupByType in checkGroupCollectionOrdered)
            {
                string lastCheck = "", lastComplianceDate = "", lastComplianceLl = "";
                DateTime last = DateTimeExtend.GetCASMinDateTime();
                if (checkGroupByType.Grouping)
                {
                    //Вычисление последней даты выполнения чеков данного типа
                    //A, B или C
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == _schedule))
                    {
                        if (checkItem.LastPerformance != null && last < checkItem.LastPerformance.RecordDate)
                            last = checkItem.LastPerformance.RecordDate;
                    }
                    //Если чеки с данным типом (A, B или C) еще не выполнялись
                    //то производится переход на след. тип. чека
                    if (last <= DateTimeExtend.GetCASMinDateTime() ||
                        last <= checkGroupCollectionOrdered.GetLastComplianceDateOfCheckWithHigherType(checkGroupByType.Schedule,
                                                                                                       checkGroupByType.Resource,
                                                                                                       checkGroupByType.Grouping,
                                                                                                       checkGroupByType.CheckType))
                        continue;
                    //lastGroupComplianceDates[checkGroupByType.Resource] = last;
                    //Если чеки с данным типом выполнялись
                    //то собирается група из чеков данного типа (A, B или C), 
                    //чья дата выполнения равна найденой
                    MaintenanceCheckComplianceGroup lastComplianceGroup = new MaintenanceCheckComplianceGroup(_schedule);
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == _schedule))
                        if (checkItem.LastPerformance != null && last == checkItem.LastPerformance.RecordDate)
                        {
                            lastComplianceGroup.Checks.Add(checkItem);
                            if (lastComplianceGroup.CheckCycle < checkGroupByType.CheckCycle)
                                lastComplianceGroup.CheckCycle = checkGroupByType.CheckCycle;
                            if (lastComplianceGroup.GroupComplianceNum < checkItem.LastPerformance.NumGroup)
                                lastComplianceGroup.GroupComplianceNum = checkItem.LastPerformance.NumGroup;
                        }
                    MaintenanceCheck maxIntervalCheckInGroup;
                    //Поиск старшего чека данного типа в собранной группе
                    //Если его нет, переход к след. типу чеков
                    if ((maxIntervalCheckInGroup = lastComplianceGroup.GetMaxIntervalCheck()) == null)
                        continue;
                    //Упорядочивание собранной группы
                    lastComplianceGroup.Sort();

                    string prefix = lastComplianceGroup.GetComplianceGroupName();
                    lastComplianceDate = UsefulMethods.NormalizeDate(last);
                    lastComplianceLl = maxIntervalCheckInGroup.LastPerformance.OnLifelength.ToString();

                    //название чеков
                    lastCheck = prefix;
                    if (maxIntervalCheckInGroup.ParentAircraft != null &&
                        maxIntervalCheckInGroup.ParentAircraft.MSG < MSG.MSG3)
                    {
                        lastCheck += " (";
                        lastCheck += lastComplianceGroup.Checks.Aggregate("", (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                        lastCheck += ") ";
                    }

                    Action<string, string, string> addLast = AddLastCheckItem;
                    if (InvokeRequired)
                    {
                        Invoke(addLast, lastCheck, lastComplianceDate, lastComplianceLl);
                    }
                    else addLast.Invoke(lastCheck, lastComplianceDate, lastComplianceLl);
                }
                else
                {
                    foreach (MaintenanceCheck checkItem in checkGroupByType.Checks.Where(c => c.Schedule == _schedule))
                    {
                        if (checkItem.LastPerformance != null)
                        {
                            lastComplianceDate = UsefulMethods.NormalizeDate(checkItem.LastPerformance.RecordDate);
                            lastComplianceLl = checkItem.LastPerformance.OnLifelength.ToString();

                            //название чеков
                            lastCheck = checkItem.Name;
                        }

                        Action<string, string, string> addLast = AddLastCheckItem;
                        if (InvokeRequired)
                        {
                            Invoke(addLast, lastCheck, lastComplianceDate, lastComplianceLl);
                        }
                        else addLast.Invoke(lastCheck, lastComplianceDate, lastComplianceLl);
                    }
                }
            }
        }
        #endregion

        #region  private void AddLastCheckItem(string name, string date, string lifelenght)
        private void AddLastCheckItem(string name, string date, string lifelenght)
        {
            if(string.IsNullOrEmpty(name) && 
               string.IsNullOrEmpty(date) && 
               string.IsNullOrEmpty(lifelenght))
                return;

            List<Label> subs = new List<Label>
                                   {
                                       new Label {Text = name == "" ? "N/A" : name, MaximumSize = new Size(190,1000)},
                                       new Label {Text = date == "" ? "N/A" : date},
                                       new Label {Text = lifelenght == "" ? "N/A" : lifelenght},
                                   };
            tableLayoutPanelLastChecks.RowCount += 1;
            tableLayoutPanelLastChecks.RowStyles.Add(new RowStyle());
            for (int i = 0; i < subs.Count; i++)
            {
                GetStyle(subs[i]);
                tableLayoutPanelLastChecks.Controls.Add(subs[i], i, tableLayoutPanelLastChecks.RowCount - 1);
            }
        }
        #endregion

        #region private void FindNextCheck()
        private void FindNextCheck()
        {
            //вычисление самого последнего выполненного чека, вне зависимости от типа
            //последний выполненый чек по типу может нессответствовать текущему типу программы 
            //в случае переключения
            MaintenanceCheck lastComplianceCheck = _checkItems.Where(c => c.LastPerformance != null).OrderByDescending(c => c.LastPerformance.RecordDate).FirstOrDefault();
            if (lastComplianceCheck != null && lastComplianceCheck.Schedule != _schedule && _schedule)
            {
                //тип программмы Maintenance был переключен, переключение с Unschedule на Schedule
                //вычисление самого последнего выполненного чека, заданного типа
                MaintenanceCheck lastComplianceScheduleTypeCheck =
                     _checkItems.Where(c => c.LastPerformance != null && c.Schedule == _schedule).OrderByDescending(c => c.LastPerformance.RecordDate).FirstOrDefault();

                MaintenanceCheckGroupByType group = new List<MaintenanceCheck>(_checkItems).GetNextCheckBySourceDifference(lastComplianceScheduleTypeCheck, _aircraftLifelength.Days);
                //название чеков
                MaintenanceCheck maxIntervalCheckInGroup = group.GetMaxIntervalCheck();
                string tNext = maxIntervalCheckInGroup.Name + " (";
                tNext += group.Checks.Aggregate("", (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                tNext += ") ";
                string tNextDate = UsefulMethods.NormalizeDate(group.GroupComplianceDate);

                group.GroupComplianceLifelength.Cycles = group.GroupComplianceLifelength.Hours = null;
                string tNextLl = group.GroupComplianceLifelength.ToRepeatIntervalsFormat();

                group.GroupComplianceLifelength.Substract(_aircraftLifelength);
                group.GroupComplianceLifelength.Cycles = group.GroupComplianceLifelength.Hours = null;
                string tRemainLl = Convert.ToInt32(group.GroupComplianceLifelength.Days).ToString();

                Action<string, string, string, string> addLast = AddNextCheckItem;
                if (InvokeRequired)
                {
                    Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                }
                else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
            }
            else
            {
                if (_complianceGroupCollection == null)
                    _complianceGroupCollection = _checkItems.GetNextComplianceCheckGroups(_schedule).OrderBy(c => c.GetNextComplianceDate());

                foreach (MaintenanceCheckComplianceGroup complianceGroup in _complianceGroupCollection)
                {
                    string tNext, tNextDate, tNextLl, tRemainLl;
                    MaintenanceCheck maxIntervalCheckInGroup;
                    if ((maxIntervalCheckInGroup = complianceGroup.GetMaxIntervalCheck()) == null)
                        continue;
                    complianceGroup.Sort();

                    string prefix = complianceGroup.GetGroupName();

                    if (complianceGroup.Grouping)
                    {
                        MaintenanceCheck lastOrMinCheck =
                            complianceGroup.GetLastComplianceChecks().FirstOrDefault() != null
                                ? complianceGroup.GetLastComplianceChecks().First()
                                : complianceGroup.GetMinIntervalCheck();


                        //дата следующего выполнения группы чеков
                        if (lastOrMinCheck.Interval.Days != null && lastOrMinCheck.Interval.Days > 0)
                        {
                            DateTime nextDate = lastOrMinCheck.NextPerformances.Count != 0 && lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                                    ? lastOrMinCheck.NextPerformances[0].PerformanceDate.Value
                                                    : lastOrMinCheck.LastPerformance != null
                                                          ? lastOrMinCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days))
                                                          : lastOrMinCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(lastOrMinCheck.Interval.Days));

                            tNextDate = UsefulMethods.NormalizeDate(nextDate);

                            if (lastOrMinCheck.NextPerformances.Count != 0 &&
                                lastOrMinCheck.NextPerformances[0].Remains != null)
                            {
                                //Остаток до выполнения
                                Lifelength remains = lastOrMinCheck.NextPerformances[0].Remains;
                                tRemainLl = remains.IsNullOrZero() ? "N/A" : remains.ToString();
                            }
                            else
                            {
                                tRemainLl = " N/A ";
                            }
                        }
                        else
                        {

                            tNextDate = lastOrMinCheck.NextPerformances.Count != 0 &&
                                         lastOrMinCheck.NextPerformances[0].PerformanceDate != null
                                ? " aprx. " + UsefulMethods.NormalizeDate(lastOrMinCheck.NextPerformances[0].PerformanceDate.Value)
                                : " N/A ";

                            if (lastOrMinCheck.NextPerformances.Count != 0 &&
                                lastOrMinCheck.NextPerformances[0].Remains != null)
                            {
                                //Остаток до выполнения
                                Lifelength remains = lastOrMinCheck.NextPerformances[0].Remains;
                                tRemainLl = remains.IsNullOrZero() ? "N/A" : remains.ToString();
                            }
                            else tRemainLl = " N/A ";
                        }
                        //ресурс, на котором надо поризвести выполнение
                        //след выполнение
                        Lifelength next =
                            lastOrMinCheck.NextPerformances.Count != 0
                                ? lastOrMinCheck.NextPerformances[0].PerformanceSource
                                : Lifelength.Null;
                        next.Resemble(maxIntervalCheckInGroup.Interval);
                        tNextLl = next.IsNullOrZero() ? "N/A" : next.ToString();
                        //название чеков
                        tNext = prefix;
                        if (lastOrMinCheck.ParentAircraft != null &&
                            lastOrMinCheck.ParentAircraft.MSG < MSG.MSG3)
                        {
                            tNext += " (";
                            tNext += complianceGroup.Checks.Aggregate("", (current, maintenanceCheck) => current + (maintenanceCheck.Name + " "));
                            tNext += ") ";
                        }

                        Action<string, string, string, string> addLast = AddNextCheckItem;
                        if (InvokeRequired)
                        {
                            Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                        }
                        else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
                    }
                    else
                    {
                        foreach (MaintenanceCheck maintenanceCheck in complianceGroup.Checks)
                        {
                            DateTime nextDate;
                            if (maintenanceCheck.Interval.Days != null && maintenanceCheck.Interval.Days > 0)
                            {
                                nextDate =
                                    maintenanceCheck.NextPerformances.Count != 0 && maintenanceCheck.NextPerformances[0].PerformanceDate != null
                                                    ? maintenanceCheck.NextPerformances[0].PerformanceDate.Value
                                                    : maintenanceCheck.LastPerformance != null
                                                          ? maintenanceCheck.LastPerformance.RecordDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days))
                                                          : maintenanceCheck.ParentAircraft.ManufactureDate.AddDays(Convert.ToInt32(maintenanceCheck.Interval.Days));

                                tNextDate = UsefulMethods.NormalizeDate(nextDate);

                                if (maintenanceCheck.NextPerformances.Count != 0 &&
                                    maintenanceCheck.NextPerformances[0].Remains != null)
                                {
                                    //Остаток до выполнения
                                    Lifelength remains = maintenanceCheck.NextPerformances[0].Remains;
                                    tRemainLl = (remains.IsNullOrZero() ? "N/A" : remains.ToString());
                                }
                                else
                                {
                                    tRemainLl = "N/A";
                                }
                            }
                            else
                            {
                                if (maintenanceCheck.NextPerformanceDate != null)
                                {
                                    nextDate = maintenanceCheck.NextPerformanceDate.Value;
                                    tNextDate = "aprx. " + UsefulMethods.NormalizeDate(nextDate);
                                }
                                else
                                {
                                    tNextDate = "(N/A) ";
                                }

                                if (maintenanceCheck.NextPerformances.Count != 0 &&
                                    maintenanceCheck.NextPerformances[0].Remains != null)
                                {
                                    //Остаток до выполнения
                                    Lifelength remains = maintenanceCheck.NextPerformances[0].Remains;
                                    tRemainLl = (remains.IsNullOrZero() ? "N/A" : remains.ToString());
                                }
                                else tRemainLl = "(N/A)";
                            }
                            //след выполнение
                            Lifelength next =
                                maintenanceCheck.NextPerformances.Count != 0
                                    ? maintenanceCheck.NextPerformances[0].PerformanceSource
                                    : Lifelength.Null;
                            tNextLl = (next.IsNullOrZero() ? "N/A" : next.ToString());

                            //название чеков
                            tNext = maintenanceCheck.Name + " ";

                            Action<string, string, string, string> addLast = AddNextCheckItem;
                            if (InvokeRequired)
                            {
                                Invoke(addLast, tNext, tNextDate, tNextLl, tRemainLl);
                            }
                            else addLast.Invoke(tNext, tNextDate, tNextLl, tRemainLl);
                        }
                    }
                }
            }
        }
        #endregion

        #region private void AddNextCheckItem(string name, string date, string lifelenght, string remains)
        private void AddNextCheckItem(string name, string date, string lifelenght, string remains)
        {
            List<Label> subs = new List<Label>
                                   {
                                       new Label {Text = name == "" ? "N/A" : name, MaximumSize = new Size(190,1000)},
                                       new Label {Text = date == "" ? "N/A" : date},
                                       new Label {Text = lifelenght == "" ? "N/A" : lifelenght},
                                       new Label {Text = remains == "" ? "N/A" : remains}
                                   };
            tableLayoutPanelNextChecks.RowCount += 1;
            tableLayoutPanelNextChecks.RowStyles.Add(new RowStyle());

            for (int i = 0; i < subs.Count; i++)
            {
                GetStyle(subs[i]);
                tableLayoutPanelNextChecks.Controls.Add(subs[i], i, tableLayoutPanelNextChecks.RowCount - 1);
            } 
        }
        #endregion

        #region private void UpdateDocumentation()
        private void UpdateDocumentation()
        {
            foreach (Document document in _aircraftDocuments)
            {
                AutoCompleteStringCollection parameters = new AutoCompleteStringCollection
                                          {
                                              document.Description, 
                                              document.ContractNumber, 
                                              document.NextPerformanceDate != null 
                                                ? UsefulMethods.NormalizeDate(document.IssueDateValidFrom) 
                                                : "",
                                              document.IssueValidTo  
                                                ? UsefulMethods.NormalizeDate(document.IssueDateValidTo) 
                                                : "",
                                              document.Remains.ToString()
                                          };
                Action<AutoCompleteStringCollection> addLast = AddCertificateItem;
                if (InvokeRequired)
                {
                    Invoke(addLast, parameters);
                }
                else addLast.Invoke(parameters);    
            }
        }
        #endregion

        #region private void AddCertificateItem(StringBuilder description)
        private void AddCertificateItem(AutoCompleteStringCollection parameters)
        {
            List<Label> subs = new List<Label>
                                   {
                                       new Label {Text = parameters.Count > 0 && parameters[0].ToString() == "" ? "N/A" : parameters[0].ToString() },
                                       new Label {Text = parameters.Count > 1 && parameters[1].ToString()  == "" ? "N/A" : parameters[1].ToString() },
                                       new Label {Text = parameters.Count > 2 && parameters[2].ToString()  == "" ? "N/A" : parameters[2].ToString() },
                                       new Label {Text = parameters.Count > 3 && parameters[3].ToString()  == "" ? "N/A" : parameters[3].ToString() },
                                       new Label {Text = parameters.Count > 4 && parameters[4].ToString()  == "" ? "N/A" : parameters[4].ToString() }
                                   };
            tableLayoutPanelDocs.RowCount += 1;
            tableLayoutPanelDocs.RowStyles.Add(new RowStyle());

            for (int i = 0; i < subs.Count; i++)
            {
                GetStyle(subs[i]);
                tableLayoutPanelDocs.Controls.Add(subs[i], i, tableLayoutPanelDocs.RowCount - 1);
            }
        }
        #endregion

        #region private void GetStyle(Label label)
        private void GetStyle(Label label)
        {
            label.AutoSize = true;
            label.Dock = DockStyle.Fill;
            label.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            label.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
            label.Margin = new Padding(4, 6, 4, 0);
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
        #endregion

        #region private void LinkMonthlyUtilizationDisplayerRequested(object sender, CAS.UI.Interfaces.ReferenceEventArgs e)

        private void LinkMonthlyUtilizationDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Monthly Utilization";
            e.RequestedEntity = new MonthlyUtilizationListScreen(_currentAircraft);
        }

        #endregion

        #region private void ReferenceLinkLabelForecastDisplayerRequested(object sender, ReferenceEventArgs e)
        private void ReferenceLinkLabelForecastDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = _currentAircraft.RegistrationNumber + ".Forecast";
            e.RequestedEntity = new ForecastListScreen(_currentAircraft, DirectiveType.All);
        }
        #endregion

        #region private void ReferenceLinkLabelAvionxInvDisplayerRequested(object sender, ReferenceEventArgs e)
        private void ReferenceLinkLabelAvionxInvDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            CommonFilter<AvionicsInventoryMarkType> avionixFilter =
                 new CommonFilter<AvionicsInventoryMarkType>(Component.AvionicsInventoryProperty,
                                                             FilterType.In,
                                                             new[]{AvionicsInventoryMarkType.Optional, 
                                                                  AvionicsInventoryMarkType.Required, 
                                                                  AvionicsInventoryMarkType.Unknown});
            e.DisplayerText = _currentAircraft.RegistrationNumber + ". Avionics inventory";
            e.RequestedEntity = new ComponentsListScreen(_currentAircraft, new ICommonFilter[] { avionixFilter });
        }
        #endregion

        #region  private void ReferenceLinkLabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
        private void ReferenceLinkLabelDocumentsDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = _currentAircraft.RegistrationNumber + ". Documents";
            e.RequestedEntity = new DocumentationListScreen(_currentAircraft);
        }
        #endregion

        #endregion

        #region Implementation of IReference

        public IDisplayer Displayer { get; set; }
        public string DisplayerText { get; set; }
        public IDisplayingEntity Entity { get; set; }
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}
