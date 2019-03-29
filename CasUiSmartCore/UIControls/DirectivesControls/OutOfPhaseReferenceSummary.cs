#region

using System;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftsControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using Convert = SmartCore.Auxiliary.Convert;

#endregion

namespace CAS.UI.UIControls.DirectivesControls
{
    public partial class OutOfPhaseReferenceSummary : UserControl
    {
        #region Fields

        private Directive _currentOutOfPhase;

        #endregion

        #region Properties

        #region public Directive CurrentOutOfPhase
        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public Directive CurrentOutOfPhase
        {
            get { return _currentOutOfPhase; }
            set
            {
                _currentOutOfPhase = value;
                UpdateInformation();
            }
        }

        #endregion

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// Возвращает базовый агрегат, к которому принадлежит текущая директива
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get { return GlobalObjects.AircraftsCore.GetParentAircraft(_currentOutOfPhase); }
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
                if (CurrentAircraft == null)
                    return "";
                return CurrentAircraft.RegistrationNumber;
            }
        }

        #endregion

        #endregion

        #region Constructor

        #region public OutOfPhaseReferenceSummary(Directive outOfOhase) : this ()
        /// <summary>
        /// Создает объект отображающий краткую информацию о директиве
        /// </summary>
        /// <param name="outOfOhase"></param>
        public OutOfPhaseReferenceSummary(Directive outOfOhase) : this ()
        {
            _currentOutOfPhase = outOfOhase;
            UpdateInformation();
        }
        #endregion

        #region public OutOfPhaseReferenceSummary()
        ///<summary>
        ///</summary>
        public OutOfPhaseReferenceSummary()
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
            if ((_currentOutOfPhase == null) || _currentOutOfPhase.ParentBaseComponent == null)
                return;
            Aircraft aircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentOutOfPhase);

            labelDirectiveValue.Text = _currentOutOfPhase.Title + " for";
            labelDescriptionValue.Text = _currentOutOfPhase.Description;
            labelEffectiveDateValue.Text = Convert.GetDateFormat(_currentOutOfPhase.Threshold.EffectiveDate);
            labelSBValue.Text = _currentOutOfPhase.ServiceBulletinNo;
            labelEOValue.Text = _currentOutOfPhase.EngineeringOrders;
            labelATAChapterValue.Text = _currentOutOfPhase.ATAChapter.ToString();
            labelApplicabilityValue.Text = "";//_currentOutOfPhase.Applicability;
            linkDetailInfoFirst.Text = aircraft.RegistrationNumber;
            labelRemarksLast.Text = "";
            if (CurrentAircraft != null) linkDirectiveStatus.Text = BackLinkText;

            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentOutOfPhase);
            if (_currentOutOfPhase.Remains != null && _currentOutOfPhase.Condition != ConditionState.NotEstimated)
            {
                if (_currentOutOfPhase.Remains.IsOverdue() && _currentOutOfPhase.Condition == ConditionState.Overdue)
                {
                    labelRemains.Text = "Overdue:";
                    imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                }
                else if (_currentOutOfPhase.Condition == ConditionState.Notify)
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.Notify;
                }
                else if (_currentOutOfPhase.Condition == ConditionState.Satisfactory)
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
            imageLinkLabelStatus.Text = _currentOutOfPhase.WorkType.ToString();

            labelRemainsValue.Text = "";

            if (_currentOutOfPhase.Remains != null)
                labelRemainsValue.Text = _currentOutOfPhase.Remains.ToString();


            labelCostValue.Text = _currentOutOfPhase.Cost.ToString();
            labelManHoursValue.Text = _currentOutOfPhase.ManHours.ToString();
            labelKitValue.Text = _currentOutOfPhase.KitRequired == "" ? "N" : _currentOutOfPhase.KitRequired;
            labelNDTvalue.Text = _currentOutOfPhase.NDTType.ShortName;
            labelRemarksValue.Text = _currentOutOfPhase.Remarks;

            labelHiddenRemarksValue.Text = "";
            if (labelHiddenRemarksValue.Text == "")
                labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

            labelDateLast.Text = "";
            labelAircraftTsnCsnLast.Text = "";
            labelDateNext.Text = "n/a";
            labelAircraftTsnCsnNext.Text = "n/a";
            labelComponentTsnCsnNext.Text = "n/a";
            labelRemarksValue.Text = "";


            var parentBaseComponent = _currentOutOfPhase.ParentBaseComponent;
            if (_currentOutOfPhase.LastPerformance != null)
            {
                labelDateLast.Text = Convert.GetDateFormat(_currentOutOfPhase.LastPerformance.RecordDate);

                if (!_currentOutOfPhase.LastPerformance.OnLifelength.IsNullOrZero())
                {
					labelComponentTsnCsnLast.Text = _currentOutOfPhase.LastPerformance.OnLifelength.ToString();

					labelAircraftTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentOutOfPhase.LastPerformance.RecordDate).ToString();
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////
            labelFirstPerformanceValue.Text = "n/a";
            labelRptIntervalValue.Text = "n/a";

            if (_currentOutOfPhase.Threshold.FirstPerformanceSinceNew != null &&
                !_currentOutOfPhase.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                labelFirstPerformanceValue.Text = "s/n: " + _currentOutOfPhase.Threshold.FirstPerformanceSinceNew;
            }

            if (_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                else labelFirstPerformanceValue.Text = "";
                labelFirstPerformanceValue.Text += "s/e.d: " + _currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate;
            }

            if (_currentOutOfPhase.Threshold.RepeatInterval != null)
            {
                labelRptIntervalValue.Text = _currentOutOfPhase.Threshold.RepeatInterval.IsNullOrZero()
                                                 ? "n/a"
                                                 : _currentOutOfPhase.Threshold.RepeatInterval.ToString();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            labelRemarksValue.Text = _currentOutOfPhase.Remarks;


            if (_currentOutOfPhase.IsClosed) return;//если директива принудительно закрыта пользователем
            //то вычисление следующего выполнения не нужно


            labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
            if (_currentOutOfPhase.LastPerformance == null)
            {
                if (_currentOutOfPhase.Threshold.PerformSinceNew &&
                    _currentOutOfPhase.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentOutOfPhase.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    //если наработка исчисляется с момента выпуска
                    if (_currentOutOfPhase.Threshold.FirstPerformanceSinceNew.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                parentBaseComponent.ManufactureDate.AddDays(
                                    (double)_currentOutOfPhase.Threshold.FirstPerformanceSinceNew.Days)) +
                            " s/n";
                    }
                    else
                    {
                        //иначе, если (дополнительно) дата не определена
                        labelDateNext.Text = "n/a";
                    }
                    labelComponentTsnCsnNext.Text = "s/n: " + _currentOutOfPhase.Threshold.FirstPerformanceSinceNew;
                    //labelAircraftTsnCsnNext.Text = "s/n: " + currentDirective.Threshold.SinceNew.ToString();
                }


                if (_currentOutOfPhase.Threshold.PerformSinceEffectiveDate &&
                    _currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    //если наработка исчисляется с эффективной даты

                    //Определение даты исполнения
                    if (_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        if (labelDateNext.Text != "n/a")
                            labelDateNext.Text += " or ";
                        else labelDateNext.Text = "";


                        labelDateNext.Text +=
                            Convert.GetDateFormat(
                                _currentOutOfPhase.Threshold.EffectiveDate.AddDays
                                    ((double)_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate.Days)) + " s/e.d.";
                    }
                    else
                    {
                        //иначе, дату определить нельзя
                        if (labelDateNext.Text == "") labelDateNext.Text = "n/a";
                    }


                    //Определение наработки
                    if (_currentOutOfPhase.Threshold.EffectiveDate < DateTime.Today)
                    {
                        Lifelength sinceEffDate =
                            GlobalObjects.CasEnvironment.Calculator.
                                GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentOutOfPhase.Threshold.EffectiveDate);
                        sinceEffDate.Add(_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate);
                        sinceEffDate.Resemble(_currentOutOfPhase.Threshold.FirstPerformanceSinceEffectiveDate);

                        if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                        else labelComponentTsnCsnNext.Text = "";
                        labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
                    }
                }
            }
            else
            {
                if (_currentOutOfPhase.Threshold.PerformRepeatedly &&
                    _currentOutOfPhase.Threshold.RepeatInterval != null)
                {
                    //повторяющаяся директива
                    //если есть последнне выполнение, то следующая дата расчитывается
                    //по повторяющемуся интервалу
                    if (_currentOutOfPhase.Threshold.RepeatInterval.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                _currentOutOfPhase.LastPerformance.RecordDate.AddDays(
                                    (double)_currentOutOfPhase.Threshold.RepeatInterval.Days));
                    }
                    else
                    {
                        //иначе, точную дату выполнения расчитать нельзя
                        labelDateNext.Text = "n/a";
                        labelComponentTsnCsnNext.Text = "n/a";
                    }

                    //Определение наработки
                    if (!_currentOutOfPhase.Threshold.RepeatInterval.IsNullOrZero())
                    {
                        Lifelength nextTsnCsn;
                        if (!_currentOutOfPhase.LastPerformance.OnLifelength.IsNullOrZero())
                            nextTsnCsn = new Lifelength(_currentOutOfPhase.LastPerformance.OnLifelength);
                        else
                            nextTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(parentBaseComponent,
                                                                                               _currentOutOfPhase.
                                                                                                   LastPerformance.
                                                                                                   RecordDate);
                        Lifelength nextAircraftTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(
                            parentBaseComponent,
                            _currentOutOfPhase.
                                LastPerformance.
                                RecordDate);

                        nextTsnCsn.Add(_currentOutOfPhase.Threshold.RepeatInterval);
                        nextTsnCsn.Resemble(_currentOutOfPhase.Threshold.RepeatInterval);
                        labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();

                        nextAircraftTsnCsn.Add(_currentOutOfPhase.Threshold.RepeatInterval);
                        nextAircraftTsnCsn.Resemble(_currentOutOfPhase.Threshold.RepeatInterval);
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
            control.Width = (int)graph.MeasureString(control.Text, control.Font).Width + 7;
            graph.Dispose();
        }

        #endregion

        #endregion

        #region Events

        #region private void Control_TextChanged(object sender, EventArgs e)

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

        #region private void linkDetailInfoSecond_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void DetailReferenceDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            Aircraft a = GlobalObjects.AircraftsCore.GetParentAircraft(_currentOutOfPhase);
            //e.RequestedEntity = new DispatcheredAircraftScreen(a);
            e.RequestedEntity = new AircraftScreen(a);
            e.DisplayerText = a.RegistrationNumber;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentAircraft == null)
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
