using System;
using System.Windows.Forms;
using AvControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class ComponentSummaryCompliancePerformanceControl : UserControl
    {
        #region Fields

        private readonly ComponentDirective _currentComponentDirective;

        #endregion

        #region Constructor

        #region DetailSummaryCompliancePerformanceControl()

        ///<summary>
        ///</summary>
        public ComponentSummaryCompliancePerformanceControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DetailCompliancePerformanceControl(DetailDirective detailDirective)

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования отдельной информации Compliance/Performance
        /// </summary>
        /// <param name="componentDirective">Работа агрегата</param>
        public ComponentSummaryCompliancePerformanceControl(ComponentDirective componentDirective)
        {
            _currentComponentDirective = componentDirective;
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Methods

        #region public void UpdateInformation()

        ///<summary>
        ///</summary>
        public void UpdateInformation()
        {
            if(_currentComponentDirective == null) return;

            if (_currentComponentDirective.ParentComponent != null && _currentComponentDirective.ParentComponent is BaseComponent)
            {
                BaseComponent inspectedBaseComponent = (BaseComponent)_currentComponentDirective.ParentComponent;

                string baseDetailTypeString = inspectedBaseComponent.BaseComponentType.ToString();
                labelCompntTCSN.Text = baseDetailTypeString;
            }

            imageLinkLabelStatus.Text = _currentComponentDirective.DirectiveType.ToString();
            labelFirstPerformanceValue.Text = "n/a";
            if (_currentComponentDirective.Threshold.FirstPerformanceSinceNew != null &&
                !_currentComponentDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                labelFirstPerformanceValue.Text = "s/n: " + _currentComponentDirective.Threshold.FirstPerformanceSinceNew;
            }

            if (_currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !_currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                else labelFirstPerformanceValue.Text = "";
                labelFirstPerformanceValue.Text += "s/e.d: " + _currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate;
            }
            labelRptIntervalValue.Text = _currentComponentDirective.Threshold.RepeatInterval.ToString();
            labelKitValue.Text = _currentComponentDirective.KitRequired;
            labelManHoursValue.Text = _currentComponentDirective.ManHours.ToString();
            labelCostValue.Text = _currentComponentDirective.Cost.ToString();
            labelRemarksValue.Text = _currentComponentDirective.Remarks;
            labelHiddenRemarksValue.Text = _currentComponentDirective.HiddenRemarks;
            labelWarrantyRemains.Text = _currentComponentDirective.Threshold.Warranty.ToString();

            //GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentComponentDirective);

            Lifelength temp;
            ComponentDirectiveThreshold threshold;
            Component tempComponent;
            var tempAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponentDirective.ParentComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь

			labelCompntRemains.Text = "";
            labelCompntSince.Text = "";
            if (_currentComponentDirective.Remains != null && _currentComponentDirective.Condition != ConditionState.NotEstimated)
            {
                if (_currentComponentDirective.Remains.IsOverdue() && _currentComponentDirective.Condition == ConditionState.Overdue)
                {
                    labelRemains.Text = "Overdue:";
                    imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                }
                else if (_currentComponentDirective.Condition == ConditionState.Notify)
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.Notify;
                }
                else if (_currentComponentDirective.Condition == ConditionState.Satisfactory)
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.Satisfactory;
                }
                else
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.NotActive;
                }

                labelCompntRemains.Text = _currentComponentDirective.Remains.ToString();
            }

            labelDateLast.Text = "";
            labelCompntTCSNLast.Text = "";
            labelAircraftTCSNLast.Text = "";
            
            labelDateNext.Text = "n/a";
            labelCompntTCSNNext.Text = "n/a";
            labelAircraftTCSNNext.Text = "n/a";

            if (_currentComponentDirective.LastPerformance != null)
            {
                //Заполнение Last-ов
                //дата последнего выполнения
                labelDateLast.Text = SmartCore.Auxiliary.Convert.GetDateFormat(_currentComponentDirective.LastPerformance.RecordDate);

                Lifelength current;
                if(_currentComponentDirective.ParentComponent is BaseComponent)
                    current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseComponent)_currentComponentDirective.ParentComponent);
                else current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentComponentDirective.ParentComponent);
                //наработка компонента на последнем исполнении
                temp = _currentComponentDirective.LastPerformance.OnLifelength;  
                if (temp != Lifelength.Null )
                {
                    labelCompntTCSNLast.Text = temp.ToString();
                    if (!current.IsNullOrZero())
                    {
                        current.Substract(temp);
                        labelCompntSince.Text = current.ToString();
                    }
                }


                temp = tempAircraft != null &&
                      _currentComponentDirective.ParentComponent.TransferRecords.GetLast().TransferDate < _currentComponentDirective.LastPerformance.RecordDate
    ? _currentComponentDirective.LastPerformance.OnLifelength
    : Lifelength.Null;


                //            if (temp != Lifelength.Null)
                //                labelAircraftTCSNLast.Text = temp.ToString();

                //наработка самолета на последнем исполнении
                labelAircraftTCSNLast.Text = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(tempAircraft,
	                    _currentComponentDirective.LastPerformance.RecordDate).ToString();



                //Заполнение Next-ов
                threshold = _currentComponentDirective.Threshold;
                if (threshold.RepeatInterval != null && !threshold.RepeatInterval.IsNullOrZero())
                {
	                //наработка компонента на следующее исполнение
                    //var nextComponentTsnCsn = new Lifelength(_currentComponentDirective.LastPerformance.OnLifelength);
                    //nextComponentTsnCsn.Add(threshold.RepeatInterval);
                    //nextComponentTsnCsn.Resemble(threshold.RepeatInterval);
                    //labelCompntTCSNNext.Text = nextComponentTsnCsn.ToString();
                    labelCompntTCSNNext.Text = _currentComponentDirective.NextPerformance.PerformanceSource.ToString();
					if(_currentComponentDirective.NextPerformanceDate.HasValue)
						labelDateNext.Text = SmartCore.Auxiliary.Convert.GetDateFormat(_currentComponentDirective.NextPerformanceDate.Value);

                    //наработка самолета на следующее исполнение

                    //Могут вводится записи, которые были сделаны на агрегате еще 
                    //до появления этого агрегате в системе. в данном случае надо проверять
                    //не является ли наработка на след.выполнение меньше той наработки
                    //при которой был установлен агрегат

                    var asr = _currentComponentDirective.ParentComponent.ActualStateRecords.GetFirst();
                    //if (asr != null && tempAircraft != null &&
                    //    threshold.FirstPerformanceSinceNew.IsGreaterNullable(_currentComponentDirective.ParentComponent.ActualStateRecords.GetFirst().OnLifelength))
                    //{
                        //наработка на след выполнение больше той, что была при установке агрегата 
                        temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(tempAircraft);
                        //temp.Add(remains);
                        temp.Add(_currentComponentDirective.Remains);
                        temp.Resemble(threshold.RepeatInterval);
                        labelAircraftTCSNNext.Text = temp.ToString();
                    //}
                    //else
                    //{
                    //    labelAircraftTCSNNext.Text = "";    
                    //}
                }
            }
            else
            {
                //последнего исполнения не было
                //расчет ведется по FirstPerformance
                
                //Заполнение Next-ов
                threshold = _currentComponentDirective.Threshold;
                tempComponent = _currentComponentDirective.ParentComponent;
                if (threshold.FirstPerformanceSinceNew != null && !threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
	                if (_currentComponentDirective.NextPerformanceDate.HasValue)
	                    labelDateNext.Text = SmartCore.Auxiliary.Convert.GetDateFormat(_currentComponentDirective.NextPerformanceDate.Value);
					//наработка компонента на следующее исполнение
					//labelCompntTCSNNext.Text = threshold.FirstPerformanceSinceNew.ToString();
					labelCompntTCSNNext.Text = _currentComponentDirective.NextPerformance.PerformanceSource.ToString();

                    //наработка самолета на следующее исполнение
                    //наработка = наработка самолета на сегодня + остаток до первого исполнения
                    ActualStateRecord asr = _currentComponentDirective.ParentComponent.ActualStateRecords.GetFirst();
                    if (asr != null && tempAircraft != null &&  
                        threshold.FirstPerformanceSinceNew.IsGreaterNullable(_currentComponentDirective.ParentComponent.ActualStateRecords.GetFirst().OnLifelength))
                    {
                        //наработка на след выполнение больше той, что была при установке агрегата  
                        temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(tempAircraft);
                        //temp.Add(remains);
                        temp.Add(_currentComponentDirective.Remains);
                        temp.Resemble(threshold.FirstPerformanceSinceNew);
                        labelAircraftTCSNNext.Text = temp.ToString();
                    }
                    else
                        labelAircraftTCSNNext.Text = "";
                }
                else if (threshold.FirstPerformanceSinceEffectiveDate != null && 
                        !threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    //дата Следующего исполнения
                    if (threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения

                        //дата = дата_производства + первое_исполнение.дни
                        labelDateNext.Text =
                           SmartCore.Auxiliary.Convert.GetDateFormat(
                              threshold.EffectiveDate.AddDays((double)threshold.FirstPerformanceSinceEffectiveDate.Days));
                    }//иначе, точную дату выполнения расчитать нельзя


                    //наработка компонента на следующее исполнение
                    //Определение наработки
                    if (threshold.EffectiveDate < DateTime.Today)
                    {
                        Lifelength sinceEffDate =_currentComponentDirective.ParentComponent is BaseComponent 
                            ? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseComponent)_currentComponentDirective.ParentComponent, _currentComponentDirective.Threshold.EffectiveDate)
                            : GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentComponentDirective.ParentComponent, _currentComponentDirective.Threshold.EffectiveDate);
                        sinceEffDate.Add(_currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate);
                        sinceEffDate.Resemble(_currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate);

                        if (labelCompntTCSNNext.Text != "n/a") labelCompntTCSNNext.Text += " or ";
                        else labelCompntTCSNNext.Text = "";
                        labelCompntTCSNNext.Text += "s/e.d: " + sinceEffDate;
                    }
                    //наработка самолета на следующее исполнение
                    //наработка = наработка самолета на сегодня + остаток до первого исполнения
                    ActualStateRecord asr = _currentComponentDirective.ParentComponent.ActualStateRecords.GetFirst();
                    //if (asr != null && tempAircraft != null &&
                    //    threshold.FirstPerformanceSinceEffectiveDate.IsGreaterNullable(asr.OnLifelength))
                    //{
                        //наработка на след выполнение больше той, что была при установке агрегата  
                        temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(tempAircraft);
                        //temp.Add(remains);
                        temp.Add(_currentComponentDirective.Remains);
                        temp.Resemble(threshold.FirstPerformanceSinceNew);
                        labelAircraftTCSNNext.Text = temp.ToString();
                    //}
                    //else
                    //    labelAircraftTCSNNext.Text = "";
                }

            }
        }

        #endregion

        #endregion

    }
}
