#region

using System;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.DetailsControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using Convert = SmartCore.Auxiliary.Convert;

#endregion

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///</summary>
    public partial class DirectiveSummary : UserControl
    {
        #region Fields

        private Directive _currentDirective;

        #endregion

        #region Properties

        #region public Directive CurrentDirective

        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public Directive CurrentDirective
        {
            get { return _currentDirective; }
            set
            {
                _currentDirective = value;
                UpdateInformation();
            }
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
                if (CurrentBaseComponent.BaseComponentTypeId == BaseComponentType.Frame.ItemId)
                    return DestinationHelper.GetDestinationStringFromAircraft(CurrentBaseComponent.ParentAircraftId, false, null);
				
				return (CurrentBaseComponent.ParentAircraftId > 0
							? DestinationHelper.GetDestinationStringFromAircraft(CurrentBaseComponent.ParentAircraftId, false, null)
							: DestinationHelper.GetDestinationStringFromStore(CurrentBaseComponent.ParentStoreId, CurrentBaseComponent.ItemId, false, '.'));
			}
        }

        #endregion

        #endregion

        #region Constructor

        #region public DirectiveSummary(Directive currentDirective) : this()
        /// <summary>
        /// Создает объект отображающий краткую информацию о директиве
        /// </summary>
        /// <param name="currentDirective"></param>
        public DirectiveSummary(Directive currentDirective) : this()
        {
            _currentDirective = currentDirective;
            
            UpdateInformation();
        }
        #endregion

        #region public DirectiveSummary()
        ///<summary>
        ///</summary>
        public DirectiveSummary()
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
        private void UpdateInformation()
        {
            if ((_currentDirective == null) || _currentDirective.ParentBaseComponent == null)
                return;
            
            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective);
            
            BaseComponent inspectedComponent = _currentDirective.ParentBaseComponent;
            labelDirectiveValue.Text = _currentDirective.Title + " for";
            labelDescriptionValue.Text = _currentDirective.Description;
            labelEffectiveDateValue.Text = Convert.GetDateFormat(_currentDirective.Threshold.EffectiveDate);
                //.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            labelSBValue.Text = _currentDirective.ServiceBulletinNo;
            labelEOValue.Text = _currentDirective.EngineeringOrders;
            labelATAChapterValue.Text = _currentDirective.ATAChapter.ToString();
            labelApplicabilityValue.Text = _currentDirective.Applicability;

            linkDetailInfoFirst.Text = inspectedComponent.ToString();
            labelRemarksLast.Text = "";
            if (CurrentBaseComponent != null) linkDirectiveStatus.Text = BackLinkText;

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
            labelKitValue.Text = _currentDirective.KitRequired == "" ? "N" : _currentDirective.KitRequired;
            labelNDTvalue.Text = _currentDirective.NDTType.ShortName;
            labelRemarksValue.Text = _currentDirective.Remarks;

            labelHiddenRemarksValue.Text = "";
            if (labelHiddenRemarksValue.Text == "")
                labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

            labelDateLast.Text = "";
            labelAircraftTsnCsnLast.Text = "";
            labelDateNext.Text = "n/a";
            labelAircraftTsnCsnNext.Text = "n/a";
            labelComponentTsnCsnNext.Text = "n/a";
            labelRemarksValue.Text = "";


            BaseComponent parentBaseComponent = _currentDirective.ParentBaseComponent;
            if (_currentDirective.LastPerformance != null)
            {
                labelDateLast.Text = Convert.GetDateFormat(_currentDirective.LastPerformance.RecordDate);
                //labelRemarksLast.Text = currentDirective.LastPerformance.Description;

                if (!_currentDirective.LastPerformance.OnLifelength.IsNullOrZero())
                {
					labelComponentTsnCsnLast.Text = _currentDirective.LastPerformance.OnLifelength.ToString();
					//TODO:(Evgenii Babak)Если тип parentBaseDetail будет Frame, то при перерасчете будет проверен тип базового агрегата и если он равен Frame,
					//то берется parentAircraft от базовой детали и считается наработка для ВС. пересмотреть подход калякуляции для ВС
					labelAircraftTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDirective.LastPerformance.RecordDate).ToString();
                }
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
            labelRemarksValue.Text = _currentDirective.Remarks;


            if (_currentDirective.IsClosed) return;//если директива принудительно закрыта пользователем
            //то вычисление следующего выполнения не нужно


            labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
            if (_currentDirective.LastPerformance == null)
            {
                if (_currentDirective.Threshold.PerformSinceNew &&
                    _currentDirective.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    //если наработка исчисляется с момента выпуска
                    if (_currentDirective.Threshold.FirstPerformanceSinceNew.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                parentBaseComponent.ManufactureDate.AddDays(
                                    (double)_currentDirective.Threshold.FirstPerformanceSinceNew.Days)) +
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


                if (_currentDirective.Threshold.PerformSinceEffectiveDate &&
                    _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate != null &&
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
                                _currentDirective.Threshold.EffectiveDate.AddDays
                                    ((double)_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate.Days)) + " s/e.d.";
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
                                GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDirective.Threshold.EffectiveDate);
                        sinceEffDate.Add(_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate);
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
                    if (_currentDirective.Threshold.RepeatInterval.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                _currentDirective.LastPerformance.RecordDate.AddDays(
                                    (double)_currentDirective.Threshold.RepeatInterval.Days));
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
                            nextTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(parentBaseComponent,
                                                                                               _currentDirective.
                                                                                                   LastPerformance.
                                                                                                   RecordDate);
                        Lifelength nextAircraftTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(
                            parentBaseComponent,
                            _currentDirective.
                                LastPerformance.
                                RecordDate);

                        nextTsnCsn.Add(_currentDirective.Threshold.RepeatInterval);
                        nextTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                        labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();

                        nextAircraftTsnCsn.Add(_currentDirective.Threshold.RepeatInterval);
                        nextAircraftTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                        labelAircraftTsnCsnNext.Text = nextAircraftTsnCsn.ToString();

                        if (labelComponentTsnCsnNext.Text == "") labelComponentTsnCsnNext.Text = "n/a";
                        if (labelAircraftTsnCsnNext.Text == "") labelAircraftTsnCsnNext.Text = "n/a";
                    }
                    else labelComponentTsnCsnNext.Text = "n/a";
                }
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
            linkDetailInfoFirst.Left = labelDirectiveValue.Right;
        }

        #endregion

        #region private void DetailReferenceDisplayerRequested(object sender, ReferenceEventArgs e)

        private void DetailReferenceDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        var dp = ScreenAndFormManager.GetBaseComponentScreen(_currentDirective.ParentBaseComponent);
            e.SetParameters(dp);
        }

        #endregion

        #region private void linkDirectiveStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.RequestedEntity = new DispatcheredСertainDirectivesView(currentDirective);
            if (CurrentBaseComponent == null)
                e.Cancel = true;
            else
            {
                e.DisplayerText = BackLinkText;
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            }
        }

        #endregion

        #endregion
    }
}