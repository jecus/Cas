using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Класс отображающий краткую информацию о директиве
    ///</summary>
    public partial class OutOffPhaseReferenceSummary : UserControl
    {
        #region Fields

        private BaseDetailDirective currentDirective;

        private readonly Label labelDateAsOf = new Label();
        private readonly Label labelDateAsOfValue = new Label();
        private readonly Label labelRequirement = new Label();
        private readonly Label labelRequirementValue = new Label();
        private readonly Label labelFrequency = new Label();
        private readonly Label labelFrequencyValue = new Label();
        private readonly Label labelReference = new Label();
        private readonly Label labelReferenceValue = new Label();
        private readonly Label labelTLPNo = new Label();
        private readonly Label labelTLPNoValue = new Label();
        private readonly Label labelCompliance = new Label();
        private readonly Label labelDate = new Label();
        private readonly Label labelTsnCsn = new Label();
        private readonly Label labelWorkType = new Label();
        private readonly Label labelRemarks = new Label();
        private readonly Label labelLastCompliance = new Label();
        private readonly Label labelDateLast = new Label();
        private readonly Label labelTsnCsnLast = new Label();
        private readonly Label labelWorktypeLast = new Label();
        private readonly Label labelRemarksLast = new Label();
        private readonly Label labelNextCompliance = new Label();
        private readonly Label labelDateNext = new Label();
        private readonly Label labelTsnCsnNext = new Label();
        private readonly Label labelWorktypeNext = new Label();
        private readonly Label labelRemarksNext = new Label();
        private readonly Label labelRemains = new Label();
        private readonly Label labelRemainsValue = new Label();
        private readonly Label labelDetailTsnCsn = new Label();
        private readonly Label labelDetailTsoCso = new Label();
        private readonly Label labelDetailTsnCsnValue = new Label();
        private readonly Label labelDetailTsoCsoValue = new Label();
        private readonly ReferenceLinkLabel linkDetailInfoSecond = new ReferenceLinkLabel();
        private readonly ReferenceLinkLabel linkDirectiveStatus = new ReferenceLinkLabel();

        private const int MEASURE_STRING_EPSILON = 7;
        private const int HEIGHT_INTERVAL = 20;
        private const int DOUBLE_LINE_SPACE = 40;
        private readonly Size labelFirstSize = new Size(180, 30);
        private readonly Size labelSecondSize = new Size(90, 30);
        private readonly Size labelDateSize = new Size(120, 30);
        private readonly Size labelTSNCSNSize = new Size(250, 30);

        #endregion

        #region Constructor

        /// <summary>
        /// Создает объект отображающий краткую информацию о директиве
        /// </summary>
        /// <param name="currentDirective"></param>
        public OutOffPhaseReferenceSummary(BaseDetailDirective currentDirective)
        {
            this.currentDirective = currentDirective;
            // 
            // labelDateAsOf
            // 
            Css.SmallHeader.Adjust(labelDateAsOf);
            labelDateAsOf.Location = new Point(0, 0);
            labelDateAsOf.Size = labelFirstSize;
            labelDateAsOf.TextAlign = ContentAlignment.MiddleLeft;
            labelDateAsOf.Text = "Date As Of:";
            // 
            // labelDateAsOfValue
            // 
            Css.OrdinaryText.Adjust(labelDateAsOfValue);
            labelDateAsOfValue.Location = new Point(labelDateAsOf.Right, 0);
            labelDateAsOfValue.Height = labelFirstSize.Height;
            labelDateAsOfValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelRequirement
            // 
            Css.SmallHeader.Adjust(labelRequirement);
            labelRequirement.Location = new Point(0, labelDateAsOf.Bottom);
            labelRequirement.Size = labelFirstSize;
            labelRequirement.TextAlign = ContentAlignment.MiddleLeft;
            labelRequirement.Text = "Requirement:";
            // 
            // labelRequirementValue
            // 
            Css.OrdinaryText.Adjust(labelRequirementValue);
            labelRequirementValue.MaximumSize = new Size(1060, 40);
            labelRequirementValue.Location = new Point(labelRequirement.Right, labelDateAsOfValue.Bottom);
            labelRequirementValue.Height = DOUBLE_LINE_SPACE;
            labelRequirementValue.TextAlign = ContentAlignment.MiddleLeft;
            labelRequirementValue.TextChanged += labelDirectiveValue_TextChanged;
            // 
            // labelFrequency
            // 
            Css.SmallHeader.Adjust(labelFrequency);
            labelFrequency.Location = new Point(0, labelRequirementValue.Bottom);
            labelFrequency.Size = labelFirstSize;
            labelFrequency.TextAlign = ContentAlignment.MiddleLeft;
            labelFrequency.Text = "Frequency:";
            // 
            // labelFrequencyValue
            //            
            Css.OrdinaryText.Adjust(labelFrequencyValue);
            labelFrequencyValue.Location = new Point(labelFrequency.Right, labelRequirementValue.Bottom);
            labelFrequencyValue.Size = labelFirstSize;
            labelFrequencyValue.TextAlign = ContentAlignment.MiddleLeft;;
            
            // 
            // labelCompliance
            // 
            Css.SmallHeader.Adjust(labelCompliance);
            labelCompliance.Location = new Point(0, labelFrequency.Bottom);
            labelCompliance.Size = labelFirstSize;
            labelCompliance.TextAlign = ContentAlignment.MiddleLeft;
            labelCompliance.Text = "Compliance";
            // 
            // labelDate
            // 
            Css.SmallHeader.Adjust(labelDate);
            labelDate.Location = new Point(labelCompliance.Right, labelFrequency.Bottom);
            labelDate.Size = labelDateSize;
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            labelDate.Text = "Date";
            // 
            // labelTsnCsn
            // 
            Css.SmallHeader.Adjust(labelTsnCsn);
            labelTsnCsn.Location = new Point(labelDate.Right, labelFrequency.Bottom);
            labelTsnCsn.Size = labelTSNCSNSize;
            labelTsnCsn.TextAlign = ContentAlignment.MiddleLeft;
            labelTsnCsn.Text = "TSN/CSN";
            // 
            // labelWorkType
            // 
            Css.SmallHeader.Adjust(labelWorkType);
            labelWorkType.Location = new Point(labelTsnCsn.Right, labelFrequency.Bottom);
            labelWorkType.Size = labelFirstSize;
            labelWorkType.TextAlign = ContentAlignment.MiddleLeft;
            labelWorkType.Text = "Work Type";
            // 
            // labelRemarks
            // 
            Css.SmallHeader.Adjust(labelRemarks);
            labelRemarks.Location = new Point(labelWorkType.Right, labelFrequency.Bottom);
            labelRemarks.Size = labelFirstSize;
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Text = "Remarks";
            // 
            // labelLastCompliance
            // 
            Css.SmallHeader.Adjust(labelLastCompliance);
            labelLastCompliance.Location = new Point(0, labelCompliance.Bottom);
            labelLastCompliance.Size = labelFirstSize;
            labelLastCompliance.TextAlign = ContentAlignment.MiddleLeft;
            labelLastCompliance.Text = "Last Compliance";
            // 
            // labelDateLast
            // 
            Css.OrdinaryText.Adjust(labelDateLast);
            labelDateLast.Location = new Point(labelLastCompliance.Right, labelCompliance.Bottom);
            labelDateLast.Size = labelDateSize;
            labelDateLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTsnCsnLast
            // 
            Css.OrdinaryText.Adjust(labelTsnCsnLast);
            labelTsnCsnLast.Location = new Point(labelDateLast.Right, labelCompliance.Bottom);
            labelTsnCsnLast.Size = labelTSNCSNSize;
            labelTsnCsnLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelWorktypeLast
            // 
            Css.OrdinaryText.Adjust(labelWorktypeLast);
            labelWorktypeLast.Location = new Point(labelTsnCsnLast.Right, labelCompliance.Bottom);
            labelWorktypeLast.Size = labelFirstSize;
            labelWorktypeLast.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelRemarksLast
            // 
            Css.OrdinaryText.Adjust(labelRemarksLast);
            labelRemarksLast.Location = new Point(labelWorktypeLast.Right, labelCompliance.Bottom);
            labelRemarksLast.Size = labelFirstSize;
            labelRemarksLast.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarksLast.TextChanged += Control_TextChanged;
            // 
            // labelNextCompliance
            // 
            Css.SmallHeader.Adjust(labelNextCompliance);
            labelNextCompliance.Location = new Point(0, labelLastCompliance.Bottom);
            labelNextCompliance.Size = labelFirstSize;
            labelNextCompliance.TextAlign = ContentAlignment.MiddleLeft;
            labelNextCompliance.Text = "Next Compliance";
            // 
            // labelDateNext
            // 
            Css.OrdinaryText.Adjust(labelDateNext);
            labelDateNext.Location = new Point(labelNextCompliance.Right, labelLastCompliance.Bottom);
            labelDateNext.Size = labelDateSize;
            labelDateNext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTsnCsnNext
            // 
            Css.OrdinaryText.Adjust(labelTsnCsnNext);
            labelTsnCsnNext.Location = new Point(labelDateNext.Right, labelLastCompliance.Bottom);
            labelTsnCsnNext.Size = labelTSNCSNSize;
            labelTsnCsnNext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelWorktypeNext
            // 
            Css.OrdinaryText.Adjust(labelWorktypeNext);
            labelWorktypeNext.Location = new Point(labelTsnCsnNext.Right, labelLastCompliance.Bottom);
            labelWorktypeNext.Size = labelFirstSize;
            labelWorktypeNext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelRemarksNext
            // 
            Css.OrdinaryText.Adjust(labelRemarksNext);
            labelRemarksNext.Location = new Point(labelWorktypeNext.Right, labelLastCompliance.Bottom);
            labelRemarksNext.Size = labelFirstSize;
            labelRemarksNext.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarksNext.TextChanged += Control_TextChanged;
            // 
            // labelRemains
            // 
            Css.SmallHeader.Adjust(labelRemains);
            labelRemains.Location = new Point(0, labelNextCompliance.Bottom);
            labelRemains.Size = labelFirstSize;
            labelRemains.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelRemainsValue
            // 
            Css.OrdinaryText.Adjust(labelRemainsValue);
            labelRemainsValue.Location = new Point(labelRemains.Right, labelNextCompliance.Bottom);
            labelRemainsValue.Height = labelFirstSize.Height;
            labelRemainsValue.TextAlign = ContentAlignment.MiddleLeft;
            labelRemainsValue.TextChanged += Control_TextChanged;
            // 
            // labelTLPNo
            // 
            Css.SmallHeader.Adjust(labelTLPNo);
            labelTLPNo.Location = new Point(0, labelRemains.Bottom);
            labelTLPNo.Size = labelFirstSize;
            labelTLPNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTLPNoValue
            // 
            Css.OrdinaryText.Adjust(labelTLPNoValue);
            labelTLPNoValue.Location = new Point(labelTLPNo.Right, labelRemains.Bottom);
            labelTLPNoValue.Height = labelFirstSize.Height;
            labelTLPNoValue.TextAlign = ContentAlignment.MiddleLeft;
            labelTLPNoValue.TextChanged += Control_TextChanged;

            // 
            // labelReference
            // 
            Css.SmallHeader.Adjust(labelReference);
            labelReference.Location = new Point(0, labelTLPNo.Bottom);
            labelReference.Size = labelFirstSize;
            labelReference.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelReferenceValue
            // 
            Css.OrdinaryText.Adjust(labelReferenceValue);
            labelReferenceValue.Location = new Point(labelReference.Right, labelTLPNo.Bottom);
            labelReferenceValue.Height = labelFirstSize.Height;
            labelReferenceValue.TextAlign = ContentAlignment.MiddleLeft;
            labelReferenceValue.TextChanged += Control_TextChanged;

            // 
            // linkDetailInfoSecond
            // 
            Css.SimpleLink.Adjust(linkDetailInfoSecond);
            linkDetailInfoSecond.Location = new Point(0, labelReference.Bottom + HEIGHT_INTERVAL);
            linkDetailInfoSecond.Height = labelFirstSize.Height;
            linkDetailInfoSecond.TextAlign = ContentAlignment.MiddleLeft;
            linkDetailInfoSecond.TextChanged += linkDetailInfoSecond_TextChanged;
            linkDetailInfoSecond.DisplayerRequested += DetailReference_DisplayerRequested;
            //
            // labelDetailTsnCsn
            //
            Css.OrdinaryText.Adjust(labelDetailTsnCsn);
            labelDetailTsnCsn.Location = new Point(linkDetailInfoSecond.Right, labelReference.Bottom + HEIGHT_INTERVAL);
            labelDetailTsnCsn.Size = labelSecondSize;
            labelDetailTsnCsn.TextAlign = ContentAlignment.MiddleLeft;
            labelDetailTsnCsn.Text = "TSN/CSN:";
            //
            // labelDetailTsnCsnValue
            //
            Css.OrdinaryText.Adjust(labelDetailTsnCsnValue);
            labelDetailTsnCsnValue.Location = new Point(labelDetailTsnCsn.Right, labelReference.Bottom + HEIGHT_INTERVAL);
            labelDetailTsnCsnValue.Size = labelTSNCSNSize;
            labelDetailTsnCsnValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelDetailTsoCso
            //
            Css.OrdinaryText.Adjust(labelDetailTsoCso);
            labelDetailTsoCso.Location = new Point(linkDetailInfoSecond.Right, labelDetailTsnCsn.Bottom);
            labelDetailTsoCso.Size = labelSecondSize;
            labelDetailTsoCso.TextAlign = ContentAlignment.MiddleLeft;
            labelDetailTsoCso.Text = "TSO/CSO:";
            //
            // labelDetailTsoCsoValue
            //
            Css.OrdinaryText.Adjust(labelDetailTsoCsoValue);
            labelDetailTsoCsoValue.Location = new Point(labelDetailTsoCso.Right, labelDetailTsnCsnValue.Bottom);
            labelDetailTsoCsoValue.Size = labelTSNCSNSize;
            labelDetailTsoCsoValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // linkDirectiveStatus
            // 
            Css.SimpleLink.Adjust(linkDirectiveStatus);
            linkDirectiveStatus.AutoSize = true;
            linkDirectiveStatus.Location = new Point(0, labelDetailTsoCso.Bottom + HEIGHT_INTERVAL);
            linkDirectiveStatus.Height = labelFirstSize.Height;
            linkDirectiveStatus.TextAlign = ContentAlignment.MiddleLeft;
            linkDirectiveStatus.DisplayerRequested += linkDirectiveStatus_DisplayerRequested;
            // 
            // DirectiveSummary
            // 
            AutoSize = true;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(labelDateAsOf);
            Controls.Add(labelDateAsOfValue);
            Controls.Add(labelRequirement);
            Controls.Add(labelRequirementValue);
            Controls.Add(labelReferenceValue);
            Controls.Add(labelReference);
            
            Controls.Add(labelFrequency);
            Controls.Add(labelFrequencyValue);
            Controls.Add(labelTLPNo);
            Controls.Add(labelTLPNoValue);
            Controls.Add(labelCompliance);
            Controls.Add(labelDate);
            Controls.Add(labelTsnCsn);
            Controls.Add(labelWorkType);
            Controls.Add(labelRemarks);
            Controls.Add(labelLastCompliance);
            Controls.Add(labelDateLast);
            Controls.Add(labelTsnCsnLast);
            Controls.Add(labelWorktypeLast);
            Controls.Add(labelRemarksLast);
            Controls.Add(labelNextCompliance);
            Controls.Add(labelDateNext);
            Controls.Add(labelTsnCsnNext);
            Controls.Add(labelWorktypeNext);
            Controls.Add(labelRemarksNext);
            Controls.Add(labelRemains);
            Controls.Add(labelRemainsValue);
            Controls.Add(linkDetailInfoSecond);
            Controls.Add(labelDetailTsnCsn);
            Controls.Add(labelDetailTsnCsnValue);
            Controls.Add(labelDetailTsoCso);
            Controls.Add(labelDetailTsoCsoValue);
            Controls.Add(linkDirectiveStatus);
           

            UpdateInformation();
        }

        #endregion

        #region Properties

        #region public BaseDetailDirective CurrentDirective

        /// <summary>
        /// Текущая директива для отображения
        /// </summary>
        public BaseDetailDirective CurrentDirective
        {
            get { return currentDirective; }
            set { currentDirective = value; }
        }

        #endregion

        #region public BaseDetail CurrentBaseDetail

        /// <summary>
        /// Возвращает базовый агрегат, к которому принадлежит текущая директива
        /// </summary>
        public BaseDetail CurrentBaseDetail
        {
            get
            {
                return currentDirective.Parent as BaseDetail;
            }
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
                if (CurrentBaseDetail == null)
                    return "";
                if (CurrentBaseDetail is AircraftFrame)
                    return CurrentBaseDetail.ParentAircraft.RegistrationNumber + ". " + currentDirective.DirectiveType.CommonName;
                else
                    return CurrentBaseDetail.ParentAircraft.RegistrationNumber + ". " + CurrentBaseDetail.ToString() + ". " + currentDirective.DirectiveType.CommonName;
            }
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
            if ((currentDirective == null) || !(currentDirective.Parent is BaseDetail))
                return;
            BaseDetail inspectedDetail = (BaseDetail)currentDirective.Parent;

            labelDateAsOfValue.Text = DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString());
            labelRequirementValue.Text = currentDirective.Description;
            labelFrequencyValue.Text= currentDirective.RepeatPerform.ToComplianceItemString();
            labelTLPNoValue.Text = currentDirective.Applicability;
            if (currentDirective.Condition == DirectiveConditionState.NotSatisfactory)
                labelRemains.Text = "Overdue:";
            else
                labelRemains.Text = "Remains:";
            if (currentDirective.Closed)
            {
                labelRemainsValue.Text = "";
            }
            else
            {
                //labelRemainsValue.Text = currentDirective.LeftTillNextPerformance.ToComplianceItemStringFull();
                labelRemainsValue.Text = currentDirective.LeftTillNextPerformance.ToComplianceItemString();
            }

            linkDetailInfoSecond.Text = inspectedDetail.ToString();
            
            labelDateLast.Text = "";
            labelTsnCsnLast.Text = "";
            labelWorktypeLast.Text = "";
            labelRemarksLast.Text = "";
            labelDateNext.Text = "";
            labelTsnCsnNext.Text = "";
            labelWorktypeNext.Text = "";
            labelRemarksNext.Text = "";
            if (currentDirective.LastPerformance != null)
            {
                labelDateLast.Text = UsefulMethods.NormalizeDate(currentDirective.LastPerformance.RecordDate);
                labelWorktypeLast.Text = currentDirective.LastPerformance.RecordType.FullName;
                labelRemarksLast.Text = currentDirective.LastPerformance.Description;
                if (currentDirective.LastPerformance.Lifelength != Lifelength.NullLifelength && (currentDirective.LastPerformance.Lifelength.Hours.TotalHours != 0 && currentDirective.LastPerformance.Lifelength.Cycles != 0))
                    labelTsnCsnLast.Text = currentDirective.LastPerformance.Lifelength.ToComplianceItemString();
            }
            if (!currentDirective.Closed)
            {
                labelDateNext.Text = UsefulMethods.NormalizeDate(currentDirective.GetApproximateDate());
                if (currentDirective.NextWorkType != null)
                {
                    labelWorktypeNext.Text = currentDirective.NextWorkType.FullName;
                }
                if (currentDirective.NextPerformance != null)
                {
                    labelTsnCsnNext.Text = currentDirective.NextPerformance.ToComplianceItemString();
                }
            }
            labelDetailTsnCsnValue.Text = inspectedDetail.Lifelength.ToComplianceItemString();
            labelDetailTsoCsoValue.Text = "";// inspectedDetail.Limitation.ResourceSinceOverhaul.ToComplianceItemString();todo
            if (CurrentBaseDetail == null)
                return;
            linkDirectiveStatus.Text = BackLinkText;
        }

        #endregion

        #region private void ChangeWidth(Control control)

        private void ChangeWidth(Control control)
        {
            Graphics graph = control.CreateGraphics();
            control.Width = (int)graph.MeasureString(control.Text, control.Font).Width + MEASURE_STRING_EPSILON;
            graph.Dispose();
        }

        #endregion

        #region private void Control_TextChanged(object sender, EventArgs e)

        private void Control_TextChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control == null)
                return;
            ChangeWidth(control);
        }

        #endregion

        #region private void labelRequirementValue_TextChanged(object sender, EventArgs e)

        private void labelDirectiveValue_TextChanged(object sender, EventArgs e)
        {
            ChangeWidth(labelRequirementValue);
        }

        #endregion

        #region private void linkDetailInfoSecond_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void DetailReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDetailScreen(currentDirective.Parent as AbstractDetail);
            e.DisplayerText = ((Aircraft)currentDirective.Parent.Parent).RegistrationNumber + ". Component SN " +
                              ((AbstractDetail)currentDirective.Parent).SerialNumber;
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
        }

        #endregion

        #region private void linkDetailInfoSecond_TextChanged(object sender, EventArgs e)

        private void linkDetailInfoSecond_TextChanged(object sender, EventArgs e)
        {
            ChangeWidth(linkDetailInfoSecond);
            labelDetailTsnCsn.Left = linkDetailInfoSecond.Right;
            labelDetailTsoCso.Left = linkDetailInfoSecond.Right;
            labelDetailTsnCsnValue.Left = labelDetailTsnCsn.Right;
            labelDetailTsoCsoValue.Left = labelDetailTsoCso.Right;
        }

        #endregion

        #region private void linkDirectiveStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDirectiveStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredСertainDirectivesView(currentDirective);
            if (CurrentBaseDetail == null)
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