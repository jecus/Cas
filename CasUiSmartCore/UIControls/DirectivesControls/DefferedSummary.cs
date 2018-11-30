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
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using Convert = SmartCore.Auxiliary.Convert;

#endregion

namespace CAS.UI.UIControls.DirectivesControls
{
    public partial class DefferedSummary : UserControl
    {
        #region Fields

        private DeferredItem _currentDefferedItem;

        #endregion

        #region Properties

        #region public DefferedItem CurrentDefferedItem
        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public DeferredItem CurrentDefferedItem
        {
            set
            {
                _currentDefferedItem = value;
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
            get { return GlobalObjects.AircraftsCore.GetParentAircraft(_currentDefferedItem); }
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

        #region public bool AircraftClicable
        ///<summary>
        /// Возвращает или задает значение возможности перехода на род.самолет по ссылке
        ///</summary>
        public bool AircraftClicable
        {
            get { return linkDetailInfoFirst.Enabled; }
            set { linkDetailInfoFirst.Enabled = value; }
        }
        #endregion

        #endregion

        #region Constructor

        #region public DefferedSummary(DefferedItem currentDefferedItem)
        /// <summary>
        /// Создает объект отображающий краткую информацию о директиве
        /// </summary>
        /// <param name="currentDefferedItem"></param>
        public DefferedSummary(DeferredItem currentDefferedItem)
        {
            InitializeComponent();

            _currentDefferedItem = currentDefferedItem;
            
            UpdateInformation();
        }
        #endregion

        #region public DefferedSummary()
        ///<summary>
        ///</summary>
        public DefferedSummary()
        {
            InitializeComponent();
        }
        
        #endregion

        #endregion

        #region Methods

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет краткую информацию о директиве 
        /// </summary>
        public void UpdateInformation()
        {
            if ((_currentDefferedItem == null) || _currentDefferedItem.ParentBaseComponent == null)
                return;

            var aircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDefferedItem);
            GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDefferedItem);
            var ata = _currentDefferedItem.ATAChapter;

            labelDirectiveValue.Text = _currentDefferedItem.Title + " for";
            labelDescriptionValue.Text = _currentDefferedItem.Description;
            labelEffectiveDateValue.Text = Convert.GetDateFormat(_currentDefferedItem.Threshold.EffectiveDate);
            labelSBValue.Text = _currentDefferedItem.ServiceBulletinNo;
            labelEOValue.Text = _currentDefferedItem.EngineeringOrders;
            labelATAChapterValue.Text = ata != null ? ata.ToString() : "";
            labelApplicabilityValue.Text = _currentDefferedItem.Applicability;

            linkDetailInfoFirst.Text = aircraft.RegistrationNumber;
            labelRemarksLast.Text = "";
            if (CurrentAircraft != null) linkDirectiveStatus.Text = BackLinkText;

            if (_currentDefferedItem.Remains != null && _currentDefferedItem.Condition != ConditionState.NotEstimated)
            {
                if (_currentDefferedItem.Remains.IsOverdue() && _currentDefferedItem.Condition == ConditionState.Overdue)
                {
                    labelRemains.Text = "Overdue:";
                    imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                }
                else if (_currentDefferedItem.Condition == ConditionState.Notify)
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.Notify;
                }
                else if (_currentDefferedItem.Condition == ConditionState.Satisfactory)
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
            imageLinkLabelStatus.Text = _currentDefferedItem.WorkType.ToString();

            labelRemainsValue.Text = "";

            if (_currentDefferedItem.Remains != null)
                labelRemainsValue.Text = _currentDefferedItem.Remains.ToString();


            labelCostValue.Text = _currentDefferedItem.Cost.ToString();
            labelManHoursValue.Text = _currentDefferedItem.ManHours.ToString();
            labelKitValue.Text = _currentDefferedItem.KitRequired == "" ? "N" : _currentDefferedItem.KitRequired;
            labelNDTvalue.Text = _currentDefferedItem.NDTType.ShortName;
            labelRemarksValue.Text = _currentDefferedItem.Remarks;

            labelHiddenRemarksValue.Text = "";
            if (labelHiddenRemarksValue.Text == "")
                labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

            labelDateLast.Text = "";
            labelAircraftTsnCsnLast.Text = "";
            labelDateNext.Text = "n/a";
            labelAircraftTsnCsnNext.Text = "n/a";
            labelComponentTsnCsnNext.Text = "n/a";
            labelRemarksValue.Text = "";


            BaseComponent parentBaseComponent = _currentDefferedItem.ParentBaseComponent;
            if (_currentDefferedItem.LastPerformance != null)
            {
                labelDateLast.Text = Convert.GetDateFormat(_currentDefferedItem.LastPerformance.RecordDate);

                if (!_currentDefferedItem.LastPerformance.OnLifelength.IsNullOrZero())
				{
					labelComponentTsnCsnLast.Text = _currentDefferedItem.LastPerformance.OnLifelength.ToString();

					labelAircraftTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDefferedItem.LastPerformance.RecordDate).ToString();
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////
            labelFirstPerformanceValue.Text = "n/a";
            labelRptIntervalValue.Text = "n/a";

            if (_currentDefferedItem.Threshold.FirstPerformanceSinceNew != null &&
                !_currentDefferedItem.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                labelFirstPerformanceValue.Text = "s/n: " + _currentDefferedItem.Threshold.FirstPerformanceSinceNew;
            }

            if (_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                else labelFirstPerformanceValue.Text = "";
                labelFirstPerformanceValue.Text += "s/e.d: " + _currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate;
            }

            if (_currentDefferedItem.Threshold.RepeatInterval != null)
            {
                labelRptIntervalValue.Text = _currentDefferedItem.Threshold.RepeatInterval.IsNullOrZero()
                                                 ? "n/a"
                                                 : _currentDefferedItem.Threshold.RepeatInterval.ToString();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            labelRemarksValue.Text = _currentDefferedItem.Remarks;


            if (_currentDefferedItem.IsClosed) return;//если директива принудительно закрыта пользователем
            //то вычисление следующего выполнения не нужно


            labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
            if (_currentDefferedItem.LastPerformance == null)
            {
                if (_currentDefferedItem.Threshold.PerformSinceNew &&
                    _currentDefferedItem.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentDefferedItem.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    //если наработка исчисляется с момента выпуска
                    if (_currentDefferedItem.Threshold.FirstPerformanceSinceNew.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                parentBaseComponent.ManufactureDate.AddDays(
                                    (double)_currentDefferedItem.Threshold.FirstPerformanceSinceNew.Days)) +
                            " s/n";
                    }
                    else
                    {
                        //иначе, если (дополнительно) дата не определена
                        labelDateNext.Text = "n/a";
                    }
                    labelComponentTsnCsnNext.Text = "s/n: " + _currentDefferedItem.Threshold.FirstPerformanceSinceNew;
                    //labelAircraftTsnCsnNext.Text = "s/n: " + currentDirective.Threshold.SinceNew.ToString();
                }


                if (_currentDefferedItem.Threshold.PerformSinceEffectiveDate &&
                    _currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    //если наработка исчисляется с эффективной даты

                    //Определение даты исполнения
                    if (_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        if (labelDateNext.Text != "n/a")
                            labelDateNext.Text += " or ";
                        else labelDateNext.Text = "";


                        labelDateNext.Text +=
                            Convert.GetDateFormat(
                                _currentDefferedItem.Threshold.EffectiveDate.AddDays
                                    ((double)_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate.Days)) + " s/e.d.";
                    }
                    else
                    {
                        //иначе, дату определить нельзя
                        if (labelDateNext.Text == "") labelDateNext.Text = "n/a";
                    }


                    //Определение наработки
                    if (_currentDefferedItem.Threshold.EffectiveDate < DateTime.Today)
                    {
                        Lifelength sinceEffDate =
                            GlobalObjects.CasEnvironment.Calculator.
                                GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDefferedItem.Threshold.EffectiveDate);
                        sinceEffDate.Add(_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate);
                        sinceEffDate.Resemble(_currentDefferedItem.Threshold.FirstPerformanceSinceEffectiveDate);

                        if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                        else labelComponentTsnCsnNext.Text = "";
                        labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
                    }
                }
            }
            else
            {
                if (_currentDefferedItem.Threshold.PerformRepeatedly &&
                    _currentDefferedItem.Threshold.RepeatInterval != null)
                {
                    //повторяющаяся директива
                    //если есть последнне выполнение, то следующая дата расчитывается
                    //по повторяющемуся интервалу
                    if (_currentDefferedItem.Threshold.RepeatInterval.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                _currentDefferedItem.LastPerformance.RecordDate.AddDays(
                                    (double)_currentDefferedItem.Threshold.RepeatInterval.Days));
                    }
                    else
                    {
                        //иначе, точную дату выполнения расчитать нельзя
                        labelDateNext.Text = "n/a";
                        labelComponentTsnCsnNext.Text = "n/a";
                    }

                    //Определение наработки
                    if (!_currentDefferedItem.Threshold.RepeatInterval.IsNullOrZero())
                    {
                        Lifelength nextTsnCsn;
                        if (!_currentDefferedItem.LastPerformance.OnLifelength.IsNullOrZero())
                            nextTsnCsn = new Lifelength(_currentDefferedItem.LastPerformance.OnLifelength);
                        else
                            nextTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(parentBaseComponent,
                                                                                               _currentDefferedItem.
                                                                                                   LastPerformance.
                                                                                                   RecordDate);
                        Lifelength nextAircraftTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(
                            parentBaseComponent,
                            _currentDefferedItem.
                                LastPerformance.
                                RecordDate);

                        nextTsnCsn.Add(_currentDefferedItem.Threshold.RepeatInterval);
                        nextTsnCsn.Resemble(_currentDefferedItem.Threshold.RepeatInterval);
                        labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();

                        nextAircraftTsnCsn.Add(_currentDefferedItem.Threshold.RepeatInterval);
                        nextAircraftTsnCsn.Resemble(_currentDefferedItem.Threshold.RepeatInterval);
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

        #region private void linkDetailInfoSecond_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void DetailReferenceDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            var a = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDefferedItem);
            //e.RequestedEntity = new DispatcheredAircraftScreen(a);
            e.RequestedEntity = new AircraftScreen(a);
            e.DisplayerText = a.RegistrationNumber;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.RequestedEntity = new DispatcheredСertainDirectivesView(currentDirective);
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