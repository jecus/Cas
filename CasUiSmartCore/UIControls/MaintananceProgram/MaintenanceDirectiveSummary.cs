#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.ComponentControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using TempUIExtentions;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = SmartCore.Auxiliary.Convert;

#endregion

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    [Designer(typeof(MaintenanceSummaryControlDesigner))]
    public partial class MaintenanceDirectiveSummary : UserControl
    {
        #region Fields

        private MaintenanceDirective _currentDirective;

		#endregion

		#region Properties

		#region public void Updateparameters(MaintenanceDirective maintenanceDirective, IList<IDirective> bindedItems)

		public void Updateparameters(MaintenanceDirective maintenanceDirective, IList<IDirective> bindedItems)
		{
			_currentDirective = maintenanceDirective;
			UpdateInformation(bindedItems);
		}

		#endregion

		#region public BaseDetail CurrentBaseDetail

		/// <summary>
		/// Возвращает базовый агрегат, к которому принадлежит текущая директива
		/// </summary>
		public BaseComponent CurrentBaseComponent
        {
            get { return _currentDirective.ParentBaseComponent; }
        }

        #endregion

        #region public string BackLinkText

        /// <summary>
        /// Возвращает текст обратной ссылки на список директив
        /// </summary>
        public string BackLinkText
        {
            get
            {
                if (CurrentBaseComponent == null)
                    return "";
                if (CurrentBaseComponent.BaseComponentTypeId == 4)
                    return $"{CurrentBaseComponent.GetParentAircraftRegNumber()}. ";

	            var parentStore = GlobalObjects.StoreCore.GetStoreById(CurrentBaseComponent.ParentStoreId);

                return (CurrentBaseComponent.ParentAircraftId > 0
							? CurrentBaseComponent.GetParentAircraftRegNumber()
							: parentStore.Location) + ". " + CurrentBaseComponent + ". "; 
				// +currentDirective.DirectiveType.CommonName;
			}
        }

        #endregion

        #endregion

        #region Constructor

        #region public MaintenanceDirectiveSummary()
        ///<summary>
        ///</summary>
        public MaintenanceDirectiveSummary()
        {
            InitializeComponent();
        }

		#endregion

		#endregion

		#region Methods

		#region private void UpdateInformation()

		/// <summary>
		/// Заполняет краткую информацию о директиве 
		/// </summary>
		/// <param name="bindedItems"></param>
		private void UpdateInformation(IList<IDirective> bindedItems)
        {
            if ((_currentDirective == null) || _currentDirective.ParentBaseComponent == null)
                return;

            var inspectedComponent = _currentDirective.ParentBaseComponent;
            labelDirectiveValue.Text = _currentDirective.TaskNumberCheck;
            labelDescriptionValue.Text = _currentDirective.Description;
            labelRevisionDateValue.Text = _currentDirective.MpdRevisionNum + " " +Convert.GetDateFormat(_currentDirective.MpdRevisionDate);
	        labelAMP.Text = _currentDirective.ScheduleItem;
			labelAMPRevison.Text = _currentDirective.ScheduleRevisionNum + " " + (_currentDirective.ScheduleRevisionDate > DateTimeExtend.GetCASMinDateTime() ? Convert.GetDateFormat(_currentDirective.ScheduleRevisionDate) : "");
			labelSBValue.Text = _currentDirective.ServiceBulletinNo;
            labelATAChapterValue.Text = _currentDirective.ATAChapter != null 
                ? _currentDirective.ATAChapter.ToString()
                : "";
            labelRemarksLast.Text = "";
            labelApplicabilityValue.Text = _currentDirective.Applicability;
	        labelRemarksValue.Text = _currentDirective.Remarks;
	        labelHiddenRemarksValue.Text = _currentDirective.HiddenRemarks;
			labelMRBValue.Text = _currentDirective.MRB;
            labelMaintManualValue.Text = _currentDirective.MaintenanceManual;
            labelTaskCardNumberValue.Text = _currentDirective.TaskCardNumber;
            labelMPDNumberValue.Text = _currentDirective.MPDTaskNumber;
	        labelWorkArea.Text = _currentDirective.Workarea;
	        labelSkill.Text = _currentDirective.Skill.ToString();
	        labelCategory.Text = _currentDirective.Category.ToString();
            labelProgramValue.Text = _currentDirective.Program.ToString();
            labelCriticalSystemValue.Text = _currentDirective.CriticalSystem.ToString();
            labelZoneValue.Text = _currentDirective.Zone;
            labelAccessValue.Text = _currentDirective.Access;
            labelCheckValue.Text = _currentDirective.MaintenanceCheck != null
                    ? _currentDirective.MaintenanceCheck.Name
                    : "N/A";
	        SetTextBoxComponentsString(bindedItems); 
            if (CurrentBaseComponent != null) linkDirectiveStatus.Text = BackLinkText;
            
            ///////////////////////////////////////////////////////////////////////
            // Расчетные данные
            //////////////////////////////////////////////////////////////////////
            
            if(_currentDirective.ItemRelations.Count == 0)
            {
                #region Расчет при отсутствии привязанных задач

                GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective);
                if (_currentDirective.Remains != null && _currentDirective.Condition != ConditionState.NotEstimated)
                {
                    if (_currentDirective.Remains.IsOverdue() && _currentDirective.Condition == ConditionState.Overdue)
                    {
                        labelRemains.Text = "Overdue:";
                        imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                    }
                    else if (_currentDirective.Condition == ConditionState.Notify)
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.Notify;
                    }
                    else if (_currentDirective.Condition == ConditionState.Satisfactory)
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.Satisfactory;
                    }
                    else
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.NotActive;
                    }
                }
                imageLinkLabelStatus.Text = _currentDirective.WorkType.ToString();

                labelRemainsValue.Text = "";

                if (_currentDirective.Remains != null)
                    labelRemainsValue.Text = _currentDirective.Remains.ToString();

                labelCostValue.Text = _currentDirective.Cost.ToString();
                labelManHoursValue.Text = _currentDirective.ManHours.ToString();
                labelKitValue.Text = _currentDirective.Kits.Count == 0 ? "N" : _currentDirective.Kits.Count + "Kits";
                labelNDTvalue.Text = _currentDirective.NDTType.ShortName;
                //labelRemarksValue.Text = _currentDirective.Remarks;

                //labelHiddenRemarksValue.Text = "";
                //if (labelHiddenRemarksValue.Text == "")
                //    labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

                labelDateLast.Text = "";
                labelAircraftTsnCsnLast.Text = "";
                labelNextCompliance.Text = "Next Compliance";
                labelDateNext.Text = "n/a";
                labelAircraftTsnCsnNext.Text = "n/a";
                labelComponentTsnCsnNext.Text = "n/a";
                //labelRemarksValue.Text = "";

                if (_currentDirective.LastPerformance != null)
                {
                    labelDateLast.Text = Convert.GetDateFormat(_currentDirective.LastPerformance.RecordDate);
                    //labelRemarksLast.Text = currentDirective.LastPerformance.Description;

                    if (!_currentDirective.LastPerformance.OnLifelength.IsNullOrZero())
                    {
                        labelComponentTsnCsnLast.Text = _currentDirective.LastPerformance.OnLifelength.ToString();
                    }
                    else
                    {
						labelComponentTsnCsnLast.Text = _currentDirective.LastPerformance.OnLifelength.ToString();
					}

					//TODO:(Evgenii Babak)Если тип inspectedDetail будет Frame, то при перерасчете будет проверен тип базового агрегата и если он равен Frame,
					//то берется parentAircraft от базовой детали и считается наработка для ВС. пересмотреть подход калякуляции для ВС
					
					//labelAircraftTsnCsnLast.Text =
     //                   GlobalObjects.CasEnvironment.Calculator.
	    //                    GetFlightLifelengthOnStartOfDay(inspectedComponent, _currentDirective.LastPerformance.RecordDate).ToString();
					labelAircraftTsnCsnLast.Text = _currentDirective.LastPerformance.OnLifelength.ToString();
				}

                ///////////////////////////////////////////////////////////////////////////////////////////////
                labelFirstPerformanceValue.Text = "n/a";
                labelRptIntervalValue.Text = "n/a";

                if (_currentDirective.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    labelFirstPerformanceValue.Text = "s/n: " + _currentDirective.Threshold.FirstPerformanceSinceNew;
                }

                if (_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                    else labelFirstPerformanceValue.Text = "";
                    labelFirstPerformanceValue.Text += "s/e.d: " + _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate;
                }

                if (_currentDirective.Threshold.RepeatInterval != null)
                {
                    labelRptIntervalValue.Text = _currentDirective.Threshold.RepeatInterval.IsNullOrZero()
                                                     ? "n/a"
                                                     : _currentDirective.Threshold.RepeatInterval.ToString();
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////
                //labelRemarksValue.Text = _currentDirective.Remarks;


                if (_currentDirective.IsClosed) return;//если директива принудительно закрыта пользователем
                //то вычисление следующего выполнения не нужно


                labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
                if (_currentDirective.LastPerformance == null)
                {
                    if (_currentDirective.Threshold.FirstPerformanceSinceNew != null &&
                        !_currentDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                    {
                        //если наработка исчисляется с момента выпуска
                        if (_currentDirective.Threshold.FirstPerformanceSinceNew.CalendarValue != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            labelDateNext.Text =
                                Convert.GetDateFormat(inspectedComponent.ManufactureDate.
                                    AddCalendarSpan(_currentDirective.Threshold.FirstPerformanceSinceNew.CalendarSpan)) +
                                " s/n";
                        }
                        else
                        {
                            //иначе, если (дополнительно) дата не определена
                            labelDateNext.Text = "n/a";
                        }
                        labelComponentTsnCsnNext.Text = "s/n: " + _currentDirective.Threshold.FirstPerformanceSinceNew;
                        //labelAircraftTsnCsnNext.Text = "s/n: " + currentDirective.Threshold.SinceNew.ToString();
                    }


                    if (_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                        !_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                    {
                        //если наработка исчисляется с эффективной даты

                        //Определение даты исполнения
                        if (_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            if (labelDateNext.Text != "n/a")
                                labelDateNext.Text += " or ";
                            else labelDateNext.Text = "";


                            labelDateNext.Text +=
                                Convert.GetDateFormat(
                                    _currentDirective.Threshold.EffectiveDate.AddCalendarSpan(
                                            _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate.CalendarSpan)) + " s/e.d.";
                        }
                        else
                        {
                            //иначе, дату определить нельзя
                            if (labelDateNext.Text == "") labelDateNext.Text = "n/a";
                        }


                        //Определение наработки
                        if (_currentDirective.Threshold.EffectiveDate < DateTime.Today)
                        {
                            Lifelength sinceEffDate =
                                GlobalObjects.CasEnvironment.Calculator.
                                    GetFlightLifelengthOnEndOfDay(inspectedComponent, _currentDirective.Threshold.EffectiveDate);
                            sinceEffDate.Add(_currentDirective.Threshold.EffectiveDate, _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate);
                            sinceEffDate.Resemble(_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate);

                            if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                            else labelComponentTsnCsnNext.Text = "";
                            labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
                        }
                    }
                }
                else
                {
                    if (_currentDirective.Threshold.PerformRepeatedly &&
                        _currentDirective.Threshold.RepeatInterval != null)
                    {
                        //повторяющаяся директива
                        //если есть последнне выполнение, то следующая дата расчитывается
                        //по повторяющемуся интервалу
                        if (_currentDirective.Threshold.RepeatInterval.CalendarValue != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            labelDateNext.Text =
                                Convert.GetDateFormat(
                                    _currentDirective.LastPerformance.RecordDate.AddCalendarSpan(
                                        _currentDirective.Threshold.RepeatInterval.CalendarSpan));
                            labelDateNext.Text =
	                            Convert.GetDateFormat(_currentDirective.NextPerformance.PerformanceDate.Value);

                        }
                        else
                        {
                            //иначе, точную дату выполнения расчитать нельзя
                            labelDateNext.Text = "n/a";
                            labelComponentTsnCsnNext.Text = "n/a";
                        }

                        //Определение наработки
                        if (!_currentDirective.Threshold.RepeatInterval.IsNullOrZero())
                        {
                            Lifelength nextTsnCsn;
                            if (!_currentDirective.LastPerformance.OnLifelength.IsNullOrZero())
                                nextTsnCsn = new Lifelength(_currentDirective.LastPerformance.OnLifelength);
                            else
								nextTsnCsn =  _currentDirective.LastPerformance.OnLifelength;

							Lifelength nextAircraftTsnCsn =
                                GlobalObjects.CasEnvironment.Calculator.
	                                GetFlightLifelengthOnStartOfDay(inspectedComponent, _currentDirective.LastPerformance.RecordDate);

							nextTsnCsn.Add(_currentDirective.LastPerformance.RecordDate, _currentDirective.Threshold.RepeatInterval);
							nextTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                            //labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();
                            labelComponentTsnCsnNext.Text = _currentDirective.NextPerformance.PerformanceSource.ToString();

                            nextAircraftTsnCsn.Add(_currentDirective.LastPerformance.RecordDate, _currentDirective.Threshold.RepeatInterval);
                            nextAircraftTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                            //labelAircraftTsnCsnNext.Text = nextAircraftTsnCsn.ToString();
                            labelAircraftTsnCsnNext.Text = _currentDirective.NextPerformance.PerformanceSource.ToString(); 

                            if (labelComponentTsnCsnNext.Text == "") labelComponentTsnCsnNext.Text = "n/a";
                            if (labelAircraftTsnCsnNext.Text == "") labelAircraftTsnCsnNext.Text = "n/a";
                        }
                        else labelComponentTsnCsnNext.Text = "n/a";
                    }
                }
                #endregion
            }
            else
            {
                #region Расчет при наличии привязанных задач

                labelDateLast.Text = "";
                labelAircraftTsnCsnLast.Text = "";
                labelNextCompliance.Text = "First Limitter";
                labelDateNext.Text = "n/a";
                labelAircraftTsnCsnNext.Text = "n/a";
                labelComponentTsnCsnNext.Text = "n/a";
                labelRemainsValue.Text = "";
                //labelRemarksValue.Text = "";

				var firstLimitters = new List<NextPerformance>();
				var lastPerformances = new List<DirectiveRecord>();

	            foreach (var bdd in bindedItems)
	            {
		            if (bdd is ComponentDirective)
		            {
			            var componentDirective = (ComponentDirective) bdd;
						GlobalObjects.PerformanceCalculator.GetNextPerformance(componentDirective);

			            if (componentDirective.NextPerformances.Count > 0)
							firstLimitters.Add(componentDirective.NextPerformances[0]);
						if (componentDirective.LastPerformance != null)
							lastPerformances.Add(componentDirective.LastPerformance);	
					}
				}
 
                var firstLimitter = firstLimitters.OrderBy(np => np.PerformanceDate).FirstOrDefault();
                var lastPerformance = lastPerformances.OrderByDescending(p => p.RecordDate).FirstOrDefault() ??
                                                  _currentDirective.LastPerformance;
                IDirective parentOfFirstLimitter = firstLimitter != null 
                    ? firstLimitter.Parent 
                    : lastPerformance != null ? lastPerformance.Parent : _currentDirective;

                if (firstLimitter != null && firstLimitter.Remains != null && firstLimitter.Condition != ConditionState.NotEstimated)
                {
                    if (firstLimitter.Remains.IsOverdue() && firstLimitter.Condition == ConditionState.Overdue)
                    {
                        labelRemains.Text = "Overdue:";
                        imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                    }
                    else if (firstLimitter.Condition == ConditionState.Notify)
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.Notify;
                    }
                    else if (firstLimitter.Condition == ConditionState.Satisfactory)
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.Satisfactory;
                    }
                    else
                    {
                        labelRemains.Text = "Remains:";
                        imageLinkLabelStatus.Status = Statuses.NotActive;
                    }
                    ComponentDirective componentDirective = (ComponentDirective)firstLimitter.Parent;
                    labelRemainsValue.Text = firstLimitter.Remains.ToString();
                    imageLinkLabelStatus.Text = componentDirective.DirectiveType.ToString();
                    labelCostValue.Text = componentDirective.Cost.ToString();
                    labelManHoursValue.Text = componentDirective.ManHours.ToString();
                    labelKitValue.Text = componentDirective.Kits.Count == 0 ? "N" : componentDirective.Kits.Count + "Kits";
                    labelNDTvalue.Text = _currentDirective.NDTType.ShortName;
                    //labelRemarksValue.Text = componentDirective.Remarks;
                }
                else
                {
                    imageLinkLabelStatus.Text = _currentDirective.WorkType.ToString();
                    labelCostValue.Text = _currentDirective.Cost.ToString();
                    labelManHoursValue.Text = _currentDirective.ManHours.ToString();
                    labelKitValue.Text = _currentDirective.Kits.Count == 0 ? "N" : _currentDirective.Kits.Count + "Kits";
                    labelNDTvalue.Text = _currentDirective.NDTType.ShortName;
                   // labelRemarksValue.Text = _currentDirective.Remarks;    
                }

                //labelHiddenRemarksValue.Text = "";
                //if (labelHiddenRemarksValue.Text == "")
                //    labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

                if (lastPerformance != null)
                {
                    labelDateLast.Text = Convert.GetDateFormat(lastPerformance.RecordDate);

                    if (!lastPerformance.OnLifelength.IsNullOrZero())
                    {
                        labelComponentTsnCsnLast.Text = lastPerformance.OnLifelength.ToString();
                    }
                    else
                    {
						labelComponentTsnCsnLast.Text = lastPerformance.OnLifelength.ToString();
					}
					//TODO:(Evgenii Babak)Тип inspectedDetail всегда будет Frame. При перерасчете будет проверен тип базового агрегата и если он равен Frame,
					//то берется parentAircraft от базовой детали и считается наработка для ВС. пересмотреть подход калякуляции для ВС
					labelAircraftTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnStartOfDay(inspectedComponent, lastPerformance.RecordDate).ToString();
                }

                ///////////////////////////////////////////////////////////////////////////////////////////////
                labelFirstPerformanceValue.Text = "n/a";
                labelRptIntervalValue.Text = "n/a";

                if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew != null &&
                    !parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    labelFirstPerformanceValue.Text = "s/n: " + parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew;
                }

                if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                    else labelFirstPerformanceValue.Text = "";
                    labelFirstPerformanceValue.Text += "s/e.d: " + parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate;
                }

                if (parentOfFirstLimitter.Threshold.RepeatInterval != null)
                {
                    labelRptIntervalValue.Text = parentOfFirstLimitter.Threshold.RepeatInterval.IsNullOrZero()
                                                     ? "n/a"
                                                     : parentOfFirstLimitter.Threshold.RepeatInterval.ToString();
                }
                ////////////////////////////////////////////////////////////////////////////////////////////////
                if (parentOfFirstLimitter.IsClosed) return;//если директива принудительно закрыта пользователем
                //то вычисление следующего выполнения не нужно


                labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
                if (parentOfFirstLimitter.LastPerformance == null)
                {
                    if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew != null &&
                        !parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                    {
                        //если наработка исчисляется с момента выпуска
                        if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew.CalendarValue != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            labelDateNext.Text =
                                Convert.GetDateFormat(inspectedComponent.ManufactureDate.
                                    AddCalendarSpan(parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew.CalendarSpan)) +
                                " s/n";
                        }
                        else
                        {
                            //иначе, если (дополнительно) дата не определена
                            labelDateNext.Text = "n/a";
                        }
                        labelComponentTsnCsnNext.Text = "s/n: " + parentOfFirstLimitter.Threshold.FirstPerformanceSinceNew;
                    }

                    if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                        !parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                    {
                        //если наработка исчисляется с эффективной даты

                        //Определение даты исполнения
                        if (parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            if (labelDateNext.Text != "n/a")
                                labelDateNext.Text += " or ";
                            else labelDateNext.Text = "";


                            labelDateNext.Text +=
                                Convert.GetDateFormat(parentOfFirstLimitter.Threshold.EffectiveDate.AddCalendarSpan(
                                                      parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate.CalendarSpan)) + " s/e.d.";
                        }
                        else
                        {
                            //иначе, дату определить нельзя
                            if (labelDateNext.Text == "") labelDateNext.Text = "n/a";
                        }
                        //Определение наработки
                        if (parentOfFirstLimitter.Threshold.EffectiveDate < DateTime.Today)
                        {
                            Lifelength sinceEffDate =
                                GlobalObjects.CasEnvironment.Calculator.
                                    GetFlightLifelengthOnEndOfDay(inspectedComponent, parentOfFirstLimitter.Threshold.EffectiveDate);
                            sinceEffDate.Add(parentOfFirstLimitter.Threshold.EffectiveDate, parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate);
                            sinceEffDate.Resemble(parentOfFirstLimitter.Threshold.FirstPerformanceSinceEffectiveDate);

                            if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                            else labelComponentTsnCsnNext.Text = "";
                            labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
                        }
                    }
                }
                else
                {
                    if (firstLimitter != null)
                    {
                        //повторяющаяся директива
                        //если есть последнне выполнение, то следующая дата расчитывается
                        //по повторяющемуся интервалу
                        if (parentOfFirstLimitter.Threshold.RepeatInterval.CalendarValue != null &&
                            firstLimitter.PerformanceDate != null)
                        {
                            //если в первом выполнении заданы дни
                            //то выводится точная дата следующего выполнения
                            labelDateNext.Text = Convert.GetDateFormat(firstLimitter.PerformanceDate.Value);
                        }
                        else
                        {
                            //иначе, точную дату выполнения расчитать нельзя
                            labelDateNext.Text = "n/a";
                            labelComponentTsnCsnNext.Text = "n/a";
                        }

                        //Определение наработки
                        if (!parentOfFirstLimitter.Threshold.RepeatInterval.IsNullOrZero() &&
                            !firstLimitter.PerformanceSource.IsNullOrZero())
                        {
                            labelComponentTsnCsnNext.Text = firstLimitter.PerformanceSource.ToString();

							//TODO:(Evgenii Babak)Тип inspectedDetail всегда будет Frame. При перерасчете будет проверен тип базового агрегата и если он равен Frame,
							//то берется parentAircraft от базовой детали и считается наработка для ВС. пересмотреть подход калякуляции для ВС
							Lifelength nextAircraftTsnCsn =
                                GlobalObjects.CasEnvironment.Calculator.
                                    GetFlightLifelengthOnStartOfDay(inspectedComponent, lastPerformance.RecordDate);

                            nextAircraftTsnCsn.Add(lastPerformance.RecordDate, parentOfFirstLimitter.Threshold.RepeatInterval);
                            nextAircraftTsnCsn.Resemble(parentOfFirstLimitter.Threshold.RepeatInterval);
                            labelAircraftTsnCsnNext.Text = nextAircraftTsnCsn.ToString();

                            if (labelComponentTsnCsnNext.Text == "") labelComponentTsnCsnNext.Text = "n/a";
                            if (labelAircraftTsnCsnNext.Text == "") labelAircraftTsnCsnNext.Text = "n/a";
                        }
                        else labelComponentTsnCsnNext.Text = "n/a";
                    }
                }
                #endregion
            }
        }

        #endregion

        #region private void ChangeWidth(Control control)

        private void ChangeWidth(Control control)
        {
            Graphics graph = control.CreateGraphics();
            control.Width = (int) graph.MeasureString(control.Text, control.Font).Width + 7;
            graph.Dispose();
        }

		#endregion

        #endregion

        #region Events

        #region private void ControlTextChanged(object sender, EventArgs e)

        private void ControlTextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null)
                return;
            ChangeWidth(control);
        }

        #endregion

        #region private void LabelDirectiveValueTextChanged(object sender, EventArgs e)

        private void LabelDirectiveValueTextChanged(object sender, EventArgs e)
        {
            ChangeWidth(labelDirectiveValue);
        }

        #endregion

        #region private void linkDirectiveStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentBaseComponent == null)
                e.Cancel = true;
            else
            {
                e.DisplayerText = BackLinkText;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
        }

		#endregion

		#region private void SetTextBoxComponentsString()
	    private void SetTextBoxComponentsString(IList<IDirective> bindedItems)
	    {
		    if (_currentDirective.ItemRelations.IsAllRelationWith(SmartCoreType.ComponentDirective))
		    {
			    var bindedDetailDirectives = bindedItems.Cast<ComponentDirective>().ToList();
			    if (_currentDirective.ItemRelations.Count == 0)
				    labelComponentValue.Text = "Select Items";
			    else if (bindedDetailDirectives.Count(dd => dd.ParentComponent != null) == 0)
				    labelComponentValue.Text = _currentDirective.ItemRelations.Count + " Items";
			    else
			    {
				    var sb = new StringBuilder();
				    var bindedDirectivesWithParent = bindedDetailDirectives.Where(dd => dd.ParentComponent != null);
				    foreach (var directive in bindedDirectivesWithParent)
				    {
					    sb.Append($"P/N:{directive.ParentComponent.PartNumber} S/N: {directive.ParentComponent.SerialNumber} Desc. {directive.ParentComponent.Description}; ");
				    }

				    var nullComponentCount = bindedDetailDirectives.Count(dd => dd.ParentComponent == null);
				    if (nullComponentCount > 0)
					    sb.Append($"and more {nullComponentCount} Items");

				    labelComponentValue.Text = sb.ToString();
			    }
		    }
		    else
		    {
			    labelComponentValue.Text = " Incorrect";
		    }

	    }
	    #endregion

		#endregion
	}

	#region internal class MaintenanceSummaryControlDesigner : ControlDesigner

	internal class MaintenanceSummaryControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentDirective");
            properties.Remove("CurrentBaseDetail");
        }
    }
    #endregion
}