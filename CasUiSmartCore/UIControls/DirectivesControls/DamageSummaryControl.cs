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
    ///<summary>
    ///</summary>
    public partial class DamageSummaryControl : UserControl
    {
        #region Fields

        private DamageItem _currentDamageItem;
        #endregion

        #region Properties

        #region public DamageItem CurrentDamageItem
        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public DamageItem CurrentDamageItem
        {
            get { return _currentDamageItem; }
            set
            {
                _currentDamageItem = value;
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
            get { return GlobalObjects.AircraftsCore.GetParentAircraft(_currentDamageItem); }
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

        #region public DamageSummaryControl(DamageItem currentPrimaryDirective) : this()
        /// <summary>
        /// Создает объект отображающий краткую информацию о директиве
        /// </summary>
        /// <param name="currentPrimaryDirective"></param>
        public DamageSummaryControl(DamageItem currentPrimaryDirective) : this()
        {
            _currentDamageItem = currentPrimaryDirective;
            
            UpdateInformation();
        }
        #endregion

        #region public DamageSummaryControl()
        ///<summary>
        ///</summary>
        public DamageSummaryControl()
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
            if ((_currentDamageItem == null) || _currentDamageItem.ParentBaseComponent == null)
                return;

            var aircraft = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDamageItem);
            //GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDamageItem);

            labelDirectiveValue.Text = _currentDamageItem.Title + " for";
            labelDescriptionValue.Text = _currentDamageItem.Description;
            labelEffectiveDateValue.Text = Convert.GetDateFormat( _currentDamageItem.Threshold.EffectiveDate);
            labelSBValue.Text = _currentDamageItem.ServiceBulletinNo;
            labelEOValue.Text = _currentDamageItem.EngineeringOrders;
            labelATAChapterValue.Text = _currentDamageItem.ATAChapter.ToString();
            labelApplicabilityValue.Text = "";
            labelLocationValue.Text = _currentDamageItem.Location;
            labelDamageNumberValue.Text = _currentDamageItem.Number;
            labelSizeValue.Text = _currentDamageItem.Size;
            labelInspectionDocumentsValue.Text = _currentDamageItem.InspectionDocumentsNo;
            
            labelDamageTypeValue.Text = _currentDamageItem.DamageType.ToString();
            linkDetailInfoFirst.Text = aircraft.ToString();
            labelRemarksLast.Text = "";
            labelIsTemporaryValue.Text = _currentDamageItem.IsTemporary ? "Yes" : "No";
            if (CurrentAircraft != null) linkDirectiveStatus.Text = BackLinkText;

            if (_currentDamageItem.Remains != null && _currentDamageItem.Condition != ConditionState.NotEstimated)
            {
                if (_currentDamageItem.Remains.IsOverdue() && _currentDamageItem.Condition == ConditionState.Overdue)
                {
                    labelRemains.Text = "Overdue:";
                    imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
                }
                else if (_currentDamageItem.Condition == ConditionState.Notify)
                {
                    labelRemains.Text = "Remains:";
                    imageLinkLabelStatus.Status = Statuses.Notify;
                }
                else if (_currentDamageItem.Condition == ConditionState.Satisfactory)
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
            imageLinkLabelStatus.Text = _currentDamageItem.WorkType.ToString();

            labelRemainsValue.Text = "";

            if (_currentDamageItem.Remains != null)
                labelRemainsValue.Text = _currentDamageItem.Remains.ToString();


            labelCostValue.Text = _currentDamageItem.Cost.ToString();
            labelManHoursValue.Text = _currentDamageItem.ManHours.ToString();
            labelKitValue.Text = _currentDamageItem.KitRequired == "" ? "N" : _currentDamageItem.KitRequired;
            labelNDTvalue.Text = _currentDamageItem.NDTType.ShortName;
            labelRemarksValue.Text = _currentDamageItem.Remarks;

            labelHiddenRemarksValue.Text = "";
            //if (_currentDamageItem.ADNoFileId <= 0) labelHiddenRemarksValue.Text = "No AD File.";
            //if (_currentDamageItem.ServiceBulletinFileId <= 0)
            //    labelHiddenRemarksValue.Text += " No Service Bulletin File.";
            //if (_currentDamageItem.JobCard.FilePDF.ItemId <= 0) labelHiddenRemarksValue.Text += " No Job File.";
            if (labelHiddenRemarksValue.Text == "")
                labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

            labelDateLast.Text = "";
            labelAircraftTsnCsnLast.Text = "";
            labelDateNext.Text = "n/a";
            labelAircraftTsnCsnNext.Text = "n/a";
            labelComponentTsnCsnNext.Text = "n/a";
            labelRemarksValue.Text = "";


            BaseComponent parentBaseComponent = _currentDamageItem.ParentBaseComponent;
            if (_currentDamageItem.LastPerformance != null)
            {
                labelDateLast.Text = Convert.GetDateFormat(_currentDamageItem.LastPerformance.RecordDate);
                //labelRemarksLast.Text = currentDirective.LastPerformance.Description;

                if (!_currentDamageItem.LastPerformance.OnLifelength.IsNullOrZero())
                {
					labelComponentTsnCsnLast.Text = _currentDamageItem.LastPerformance.OnLifelength.ToString();

					labelAircraftTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDamageItem.LastPerformance.RecordDate).ToString();
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////
            labelFirstPerformanceValue.Text = "n/a";
            labelRptIntervalValue.Text = "n/a";

            if (_currentDamageItem.Threshold.FirstPerformanceSinceNew != null &&
                !_currentDamageItem.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                labelFirstPerformanceValue.Text = "s/n: " + _currentDamageItem.Threshold.FirstPerformanceSinceNew;
            }

            if (_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (labelFirstPerformanceValue.Text != "n/a") labelFirstPerformanceValue.Text += " or ";
                else labelFirstPerformanceValue.Text = "";
                labelFirstPerformanceValue.Text += "s/e.d: " + _currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate;
            }

            if (_currentDamageItem.Threshold.RepeatInterval != null)
            {
                labelRptIntervalValue.Text = _currentDamageItem.Threshold.RepeatInterval.IsNullOrZero()
                                                 ? "n/a"
                                                 : _currentDamageItem.Threshold.RepeatInterval.ToString();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            labelRemarksValue.Text = _currentDamageItem.Remarks;


            if (_currentDamageItem.IsClosed) return;//если директива принудительно закрыта пользователем
            //то вычисление следующего выполнения не нужно

            Lifelength temp;
            var tempAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentDamageItem.ParentBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь

			labelDateNext.Text = labelAircraftTsnCsnNext.Text = "n/a";
            if (_currentDamageItem.LastPerformance == null)
            {
                if (_currentDamageItem.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentDamageItem.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    //если наработка исчисляется с момента выпуска
                    if (_currentDamageItem.Threshold.FirstPerformanceSinceNew.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                parentBaseComponent.ManufactureDate.AddDays(
                                    (double)_currentDamageItem.Threshold.FirstPerformanceSinceNew.Days)) +
                            " s/n";
                    }
                    else
                    {
                        //иначе, если (дополнительно) дата не определена
                        labelDateNext.Text = "n/a";
                    }
                    labelComponentTsnCsnNext.Text = "s/n: " + _currentDamageItem.Threshold.FirstPerformanceSinceNew;
                    labelAircraftTsnCsnNext.Text = "s/n: " + _currentDamageItem.Threshold.FirstPerformanceSinceNew;
                    //наработка на след выполнение больше той, что была при установке агрегата 
                }


                if (_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    //если наработка исчисляется с эффективной даты

                    //Определение даты исполнения
                    if (_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        if (labelDateNext.Text != "n/a")
                            labelDateNext.Text += " or ";
                        else labelDateNext.Text = "";


                        labelDateNext.Text +=
                            Convert.GetDateFormat(
                                _currentDamageItem.Threshold.EffectiveDate.AddDays
                                    ((double)_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate.Days)) + " s/e.d.";
                    }
                    else
                    {
                        //иначе, дату определить нельзя
                        if (labelDateNext.Text == "") labelDateNext.Text = "n/a";
                    }


                    //Определение наработки
                    if (_currentDamageItem.Threshold.EffectiveDate < DateTime.Today)
                    {
                        Lifelength sinceEffDate =
                            GlobalObjects.CasEnvironment.Calculator.
                                GetFlightLifelengthOnEndOfDay(parentBaseComponent, _currentDamageItem.Threshold.EffectiveDate);
                        sinceEffDate.Add(_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate);
                        sinceEffDate.Resemble(_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate);

                        if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                        else labelComponentTsnCsnNext.Text = "";
                        
                        labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
                        //labelAircraftTsnCsnNext.Text = "s/n: " + _currentDamageItem.Threshold.FirstPerformanceSinceNew;

                        if (labelAircraftTsnCsnNext.Text != "n/a") labelAircraftTsnCsnNext.Text += " or ";
                        else labelAircraftTsnCsnNext.Text = "";

                        temp = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseEntityObject) tempAircraft, _currentDamageItem.Threshold.EffectiveDate);
                        temp.Add(_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate);
                        temp.Resemble(_currentDamageItem.Threshold.FirstPerformanceSinceEffectiveDate);
                        labelAircraftTsnCsnNext.Text += "s/e.d: " + temp;
                    }
                }
            }
            else
            {
                if (_currentDamageItem.Threshold.PerformRepeatedly &&
                    _currentDamageItem.Threshold.RepeatInterval != null)
                {
                    //повторяющаяся директива
                    //если есть последнне выполнение, то следующая дата расчитывается
                    //по повторяющемуся интервалу
                    if (_currentDamageItem.Threshold.RepeatInterval.Days != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        labelDateNext.Text =
                            Convert.GetDateFormat(
                                _currentDamageItem.LastPerformance.RecordDate.AddDays(
                                    (double)_currentDamageItem.Threshold.RepeatInterval.Days));
                    }
                    else
                    {
                        //иначе, точную дату выполнения расчитать нельзя
                        labelDateNext.Text = "n/a";
                        labelComponentTsnCsnNext.Text = "n/a";
                    }

                    //Определение наработки
                    if (!_currentDamageItem.Threshold.RepeatInterval.IsNullOrZero())
                    {
                        Lifelength nextTsnCsn;
                        if (!_currentDamageItem.LastPerformance.OnLifelength.IsNullOrZero())
                            nextTsnCsn = new Lifelength(_currentDamageItem.LastPerformance.OnLifelength);
                        else
                            nextTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(parentBaseComponent,
                                                                                               _currentDamageItem.
                                                                                                   LastPerformance.
                                                                                                   RecordDate);
                        Lifelength nextAircraftTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(
                            parentBaseComponent,
                            _currentDamageItem.
                                LastPerformance.
                                RecordDate);

                        nextTsnCsn.Add(_currentDamageItem.Threshold.RepeatInterval);
                        nextTsnCsn.Resemble(_currentDamageItem.Threshold.RepeatInterval);
                        labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();

                        nextAircraftTsnCsn.Add(_currentDamageItem.Threshold.RepeatInterval);
                        nextAircraftTsnCsn.Resemble(_currentDamageItem.Threshold.RepeatInterval);
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
            var a = GlobalObjects.AircraftsCore.GetParentAircraft(_currentDamageItem);
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