#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.OpepatorsControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using Convert = SmartCore.Auxiliary.Convert;

#endregion

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(ProcedureSummaryControlDesigner))]
    public partial class ProcedureSummary : UserControl
    {
        #region Fields

        private Procedure _currentDirective;

        #endregion

        #region Properties

        #region public Procedure CurrentDirective

        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public Procedure CurrentDirective
        {
            get { return _currentDirective; }
            set
            {
                _currentDirective = value;
                UpdateInformation();
            }
        }

        #endregion

        #region public Operator CurrentOperator

        /// <summary>
        /// Возвращает базовый агрегат, к которому принадлежит текущая директива
        /// </summary>
        public Operator CurrentOperator
        {
            get { return _currentDirective.ParentOperator; }
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
                if (CurrentOperator == null)
                    return "";
                return CurrentOperator.Name + ". ";
            }
        }

        #endregion

        #endregion

        #region Constructor

        #region public ProcedureSummary()
        ///<summary>
        ///</summary>
        public ProcedureSummary()
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
            if ((_currentDirective == null) || _currentDirective.ParentOperator == null)
                return;

            //BaseDetail inspectedDetail = _currentDirective.ParentBaseDetail;
            labelDirectiveValue.Text = _currentDirective.Title + " for";
            labelDescriptionValue.Text = _currentDirective.Description;
            labelEffectiveDateValue.Text = Convert.GetDateFormat(_currentDirective.Threshold.EffectiveDate);
            linkDetailInfoFirst.Text = _currentDirective.ParentOperator.ToString();
            labelRemarksLast.Text = "";
            labelApplicabilityValue.Text = _currentDirective.Applicability;
            labelRefDocsValue.Text = _currentDirective.DocumentReferences.ToString();
            if (CurrentOperator != null) 
                linkDirectiveStatus.Text = BackLinkText;

            ///////////////////////////////////////////////////////////////////////
            // Расчетные данные
            //////////////////////////////////////////////////////////////////////

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
            imageLinkLabelStatus.Text = _currentDirective.ProcedureType.ToString();

            labelRemainsValue.Text = "";

            if (_currentDirective.Remains != null)
                labelRemainsValue.Text = _currentDirective.Remains.ToString();

            labelCostValue.Text = _currentDirective.Cost.ToString();
            labelManHoursValue.Text = _currentDirective.ManHours.ToString();
            labelKitValue.Text = _currentDirective.Kits.Count == 0 ? "N" : _currentDirective.Kits.Count + "Kits";
            labelRemarksValue.Text = _currentDirective.Remarks;

            labelHiddenRemarksValue.Text = "";
            if (labelHiddenRemarksValue.Text == "")
                labelHiddenRemarksValue.Text = "No Important information"; // labelHiddenRemarks.Visible = false;

            labelDateLast.Text = "";
            labelAircraftTsnCsnLast.Text = "";
            labelNextCompliance.Text = "Next Compliance";
            labelDateNext.Text = "n/a";
            labelAircraftTsnCsnNext.Text = "n/a";
            labelComponentTsnCsnNext.Text = "n/a";
            labelRemarksValue.Text = "";

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
                    labelComponentTsnCsnLast.Text =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(_currentDirective.LastPerformance).ToString();
                }

                //labelAircraftTsnCsnLast.Text =
                //    GlobalObjects.CasEnvironment.Calculator.
                //        GetOpeningFlightLifelength(inspectedDetail, _currentDirective.LastPerformance.RecordDate).ToString();
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
                if (_currentDirective.Threshold.FirstPerformanceSinceNew != null &&
                    !_currentDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    //если наработка исчисляется с момента выпуска
                    if (_currentDirective.Threshold.FirstPerformanceSinceNew.CalendarValue != null)
                    {
                        //если в первом выполнении заданы дни
                        //то выводится точная дата следующего выполнения
                        //labelDateNext.Text =
                        //    Convert.GetDateFormat(inspectedDetail.ManufactureDate.
                        //        AddCalendarSpan(_currentDirective.Threshold.FirstPerformanceSinceNew.CalendarSpan)) +
                        //    " s/n";
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
                        //Lifelength sinceEffDate =
                        //    GlobalObjects.CasEnvironment.Calculator.
                        //        GetLifelength(inspectedDetail, _currentDirective.Threshold.EffectiveDate);
                        //sinceEffDate.Add(_currentDirective.Threshold.EffectiveDate, _currentDirective.Threshold.FirstPerformanceSinceEffectiveDate);
                        //sinceEffDate.Resemble(_currentDirective.Threshold.FirstPerformanceSinceEffectiveDate);

                        //if (labelComponentTsnCsnNext.Text != "n/a") labelComponentTsnCsnNext.Text += " or ";
                        //else labelComponentTsnCsnNext.Text = "";
                        //labelComponentTsnCsnNext.Text += "s/e.d: " + sinceEffDate;
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
                        //Lifelength nextTsnCsn;
                        //if (!_currentDirective.LastPerformance.OnLifelength.IsNullOrZero())
                        //    nextTsnCsn = new Lifelength(_currentDirective.LastPerformance.OnLifelength);
                        //else
                        //    nextTsnCsn = GlobalObjects.CasEnvironment.Calculator.GetLifelength(inspectedDetail,
                        //                                                                       _currentDirective.
                        //                                                                           LastPerformance.
                        //                                                                           RecordDate);
                        //Lifelength nextAircraftTsnCsn =
                        //    GlobalObjects.CasEnvironment.Calculator.
                        //        GetOpeningFlightLifelength(inspectedDetail, _currentDirective.LastPerformance.RecordDate);

                        //nextTsnCsn.Add(_currentDirective.LastPerformance.RecordDate, _currentDirective.Threshold.RepeatInterval);
                        //nextTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                        //labelComponentTsnCsnNext.Text = nextTsnCsn.ToString();

                        //nextAircraftTsnCsn.Add(_currentDirective.LastPerformance.RecordDate, _currentDirective.Threshold.RepeatInterval);
                        //nextAircraftTsnCsn.Resemble(_currentDirective.Threshold.RepeatInterval);
                        //labelAircraftTsnCsnNext.Text = nextAircraftTsnCsn.ToString();

                        if (labelComponentTsnCsnNext.Text == "") labelComponentTsnCsnNext.Text = "n/a";
                        if (labelAircraftTsnCsnNext.Text == "") labelAircraftTsnCsnNext.Text = "n/a";
                    }
                    else labelComponentTsnCsnNext.Text = "n/a";
                }
            }
            #endregion
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
            if (_currentDirective.ParentOperator == null)
                return;
            e.RequestedEntity = new OperatorSymmaryDemoScreen(_currentDirective.ParentOperator);
            e.DisplayerText = _currentDirective.ParentOperator.Name;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void linkDirectiveStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkDirectiveStatusDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentOperator == null)
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

    #region internal class ProcedureSummaryControlDesigner : ControlDesigner

    internal class ProcedureSummaryControlDesigner : ControlDesigner
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