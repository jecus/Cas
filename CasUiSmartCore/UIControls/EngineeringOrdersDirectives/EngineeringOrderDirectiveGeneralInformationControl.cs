using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    ///<summary>
    /// Отображает общую информацию о директиве
    ///</summary>
    public class EngineeringOrderDirectiveGeneralInformationControl : Control, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int HEIGHT_INTERVAL = 20;
        private const int WIDTH_INTERVAL = 600;
        private const int LABEL_WIDTH_SHORT = 100;
        private const int TEXTBOX_WIDTH_SHORT = 125;
        private const int MAN_HOURS_INTERVAL = 50;


        private readonly EngineeringOrderDirective directive;
        

        private Label labelEONumber;
        private Label labelATAChapter;
        private Label labelSubject;
        private Label labelDescription;
        private Label labelNote;
        private Label labelRevision;
        private Label labelRevisionNumber;
        private Label labelRevisionDate;
        private Label labelReasonForRevision;
        private Label labelApprovalDocument;
        private Label labelEffectivity;
        private Label labelWarranty;
        private Label labelSpecialWorkingInstructions;
        private Label labelManHours;
        private Label labelCost;
        private TextBox textboxEONumber;
        private ATAChapterComboBox comboBoxAtaChapter;
        private TextBox textboxSubject;
        private TextBox textboxDescription;
        private TextBox textboxNote;
        private TextBox textboxRevisionNumber;
        private DateTimePicker dateTimePickerRevisionDate;
        private TextBox textBoxReasonForRevision;
        private TextBox textBoxApprovalDocument;
        private TextBox textboxEffectivity;
        private TextBox textboxWarranty;
        private TextBox textboxSpecialWorkingInstructions;
        private TextBox textBoxManHours;
        private TextBox textBoxCost;

        #endregion

        #region Constructors

        #region public EngineeringOrderDirectiveGeneralInformationControl()

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        public EngineeringOrderDirectiveGeneralInformationControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public EngineeringOrderDirectiveGeneralInformationControl(EngineeringOrderDirective directive)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="directive">Отображаемая директива</param>
        public EngineeringOrderDirectiveGeneralInformationControl(EngineeringOrderDirective directive)
        {
            if (null == directive)
                throw new ArgumentNullException("directive", "Argument cannot be null");
            this.directive = directive;
            InitializeComponents();
        }

        #endregion

        #endregion

        #region Properties

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATAChapter текущего агрегата
        /// </summary>
        public ATAChapter ATAChapter
        {
            get
            {
                return comboBoxAtaChapter.ATAChapter;
            }
            set
            {
                comboBoxAtaChapter.ATAChapter = value;
            }
        }

        #endregion

        #region public ComboBox ComboBoxATAChapter

        /// <summary>
        /// Возвращает ComboBox с ATAChapter
        /// </summary>
        public ComboBox ComboBoxATAChapter
        {
            get
            {
                return comboBoxAtaChapter;
            }
        }

        #endregion

        #region public double Manhours

        /// <summary>
        /// Manhours текущего инженерного задания
        /// </summary>
        public double Manhours
        {
            get
            {
                double d;
                double.TryParse(textBoxManHours.Text, out d);
                return d;
            }
            set
            {
                directive.ManHours = value;
                textBoxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string ManhoursString

        /// <summary>
        /// Manhours текущего инженерного задания
        /// </summary>
        public string ManhoursString
        {
            get
            {
                return textBoxManHours.Text;
            }
            set
            {
                textBoxManHours.Text = value;
            }
        }

        #endregion

        #region public double Cost

        /// <summary>
        /// Cost текущего инженерного задания
        /// </summary>
        public double Cost
        {
            get
            {
                double d;
                double.TryParse(textBoxCost.Text, out d);
                return d;
            }
            set
            {
                directive.Cost = value;
                textBoxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string CostString

        /// <summary>
        /// Cost текущего инженерного задания
        /// </summary>
        public string CostString
        {
            get
            {
                return textBoxCost.Text;
            }
            set
            {
                textBoxCost.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            labelEONumber = new Label();
            labelATAChapter = new Label();
            labelSubject = new Label();
            labelDescription = new Label();
            labelNote = new Label();
            labelRevision = new Label();
            labelRevisionNumber = new Label();
            labelRevisionDate = new Label();
            labelReasonForRevision = new Label();
            labelApprovalDocument = new Label();
            labelEffectivity = new Label();
            labelWarranty = new Label();
            labelSpecialWorkingInstructions = new Label();
            labelManHours = new Label();
            labelCost = new Label();
            textboxEONumber = new TextBox();
            comboBoxAtaChapter = new ATAChapterComboBox();
            textboxSubject = new TextBox();
            textboxDescription = new TextBox();
            textboxNote = new TextBox();
            textboxRevisionNumber = new TextBox();
            dateTimePickerRevisionDate = new DateTimePicker();
            textBoxReasonForRevision = new TextBox();
            textBoxApprovalDocument = new TextBox();
            textboxEffectivity = new TextBox();
            textboxWarranty = new TextBox();
            textboxSpecialWorkingInstructions = new TextBox();
            textBoxManHours = new TextBox();
            textBoxCost = new TextBox();
            // 
            // labelEONumber
            // 
            labelEONumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEONumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEONumber.Location = new Point(MARGIN, MARGIN + LABEL_HEIGHT);
            labelEONumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEONumber.Text = "EO Number";
            // 
            // textboxEONumber
            // 
            textboxEONumber.BackColor = Color.White;
            textboxEONumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxEONumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxEONumber.Location = new Point(labelEONumber.Right, MARGIN + LABEL_HEIGHT);
            textboxEONumber.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxEONumber.MaxLength = 50;
            // 
            // labelATAChapter
            // 
            labelATAChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelATAChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelATAChapter.Location = new Point(MARGIN, labelEONumber.Bottom + HEIGHT_INTERVAL);
            labelATAChapter.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelATAChapter.Text = "ATA Chapter";
            //
            // comboBoxAtaChapter
            //
            //comboBoxAtaChapter.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxAtaChapter.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxAtaChapter.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxAtaChapter.Location = new Point(labelATAChapter.Right, textboxEONumber.Bottom + HEIGHT_INTERVAL);
            comboBoxAtaChapter.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelSubject
            // 
            labelSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSubject.Location = new Point(MARGIN, labelATAChapter.Bottom + HEIGHT_INTERVAL);
            labelSubject.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSubject.Text = "Subject";
            // 
            // textboxSubject
            // 
            textboxSubject.BackColor = Color.White;
            textboxSubject.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSubject.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSubject.Location = new Point(labelSubject.Right, comboBoxAtaChapter.Bottom + HEIGHT_INTERVAL);
            textboxSubject.Multiline = true;
            textboxSubject.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT);
            textboxSubject.ScrollBars = ScrollBars.Vertical;
            textboxSubject.MaxLength = 150;
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, textboxSubject.Bottom + HEIGHT_INTERVAL);
            labelDescription.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "Description";
            //
            //  textboxDescription
            //
            textboxDescription.BackColor = Color.White;
            textboxDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxDescription.Location = new Point(labelDescription.Right, textboxSubject.Bottom + HEIGHT_INTERVAL);
            textboxDescription.Multiline = true;
            textboxDescription.Size = new Size(TEXTBOX_WIDTH, 8 * LABEL_HEIGHT);
            textboxDescription.ScrollBars = ScrollBars.Vertical;
            textboxDescription.MaxLength = 1000;
            // 
            // labelApprovalDocument
            // 
            labelApprovalDocument.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelApprovalDocument.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelApprovalDocument.Location = new Point(WIDTH_INTERVAL, MARGIN + LABEL_HEIGHT);
            labelApprovalDocument.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelApprovalDocument.Text = "Approval Document";
            // 
            // textBoxApprovalDocument
            // 
            textBoxApprovalDocument.BackColor = Color.White;
            textBoxApprovalDocument.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxApprovalDocument.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxApprovalDocument.Location = new Point(labelApprovalDocument.Right, MARGIN + LABEL_HEIGHT);
            textBoxApprovalDocument.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxApprovalDocument.MaxLength = 300;
            // 
            // labelWarranty
            // 
            labelWarranty.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelWarranty.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWarranty.Location = new Point(WIDTH_INTERVAL, labelApprovalDocument.Bottom + HEIGHT_INTERVAL);
            labelWarranty.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelWarranty.Text = "Warranty";
            // 
            // textboxWarranty
            // 
            textboxWarranty.BackColor = Color.White;
            textboxWarranty.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxWarranty.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxWarranty.Location = new Point(labelWarranty.Right, textBoxApprovalDocument.Bottom + HEIGHT_INTERVAL);
            textboxWarranty.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxWarranty.MaxLength = 150;
            // 
            // labelNote
            // 
            labelNote.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNote.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNote.Location = new Point(WIDTH_INTERVAL, labelWarranty.Bottom + HEIGHT_INTERVAL);
            labelNote.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelNote.Text = "Note";
            // 
            // textboxNote
            // 
            textboxNote.BackColor = Color.White;
            textboxNote.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxNote.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxNote.Location = new Point(labelNote.Right, textboxWarranty.Bottom + HEIGHT_INTERVAL);
            textboxNote.Multiline = true;
            textboxNote.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT);
            textboxNote.ScrollBars = ScrollBars.Vertical;
            textboxNote.MaxLength = 400;
            // 
            // labelEffectivity
            // 
            labelEffectivity.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEffectivity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEffectivity.Location = new Point(WIDTH_INTERVAL, textboxNote.Bottom + HEIGHT_INTERVAL);
            labelEffectivity.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEffectivity.Text = "Effectivity";
            // 
            // textboxEffectivity
            // 
            textboxEffectivity.BackColor = Color.White;
            textboxEffectivity.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxEffectivity.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxEffectivity.Location = new Point(labelEffectivity.Right, textboxNote.Bottom + HEIGHT_INTERVAL);
            textboxEffectivity.Multiline = true;
            textboxEffectivity.Size = new Size(TEXTBOX_WIDTH, 8 * LABEL_HEIGHT);
            textboxEffectivity.ScrollBars = ScrollBars.Vertical;
            textboxEffectivity.MaxLength = 1000;
            // 
            // labelSpecialWorkingInstructions
            // 
            labelSpecialWorkingInstructions.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSpecialWorkingInstructions.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSpecialWorkingInstructions.Location = new Point(MARGIN, textboxDescription.Bottom + HEIGHT_INTERVAL);
            labelSpecialWorkingInstructions.Size = new Size(2 * LABEL_WIDTH, LABEL_HEIGHT);
            labelSpecialWorkingInstructions.Text = "Special Working Instructions";
            // 
            // textboxSpecialWorkingInstructions
            // 
            textboxSpecialWorkingInstructions.BackColor = Color.White;
            textboxSpecialWorkingInstructions.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxSpecialWorkingInstructions.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxSpecialWorkingInstructions.Location = new Point(MARGIN, labelSpecialWorkingInstructions.Bottom);
            textboxSpecialWorkingInstructions.Multiline = true;
            textboxSpecialWorkingInstructions.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, 6 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxSpecialWorkingInstructions.ScrollBars = ScrollBars.Vertical;
            // 
            // labelRevision
            // 
            labelRevision.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelRevision.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRevision.Location = new Point(WIDTH_INTERVAL, textboxDescription.Bottom + HEIGHT_INTERVAL);
            labelRevision.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRevision.Text = "Revision";
            // 
            // labelRevisionNumber
            // 
            labelRevisionNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRevisionNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRevisionNumber.Location = new Point(WIDTH_INTERVAL, labelRevision.Bottom);
            labelRevisionNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRevisionNumber.Text = "Number";
            // 
            // textboxRevisionNumber
            // 
            textboxRevisionNumber.BackColor = Color.White;
            textboxRevisionNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRevisionNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRevisionNumber.Location = new Point(labelRevisionNumber.Right, labelRevision.Bottom);
            textboxRevisionNumber.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxRevisionNumber.MaxLength = 50;
            // 
            // labelRevisionDate
            // 
            labelRevisionDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRevisionDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRevisionDate.Location = new Point(WIDTH_INTERVAL, labelRevisionNumber.Bottom + HEIGHT_INTERVAL);
            labelRevisionDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRevisionDate.Text = "Date";
            // 
            // dateTimePickerRevisionDate
            // 
            dateTimePickerRevisionDate.BackColor = Color.White;
            dateTimePickerRevisionDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerRevisionDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerRevisionDate.Location = new Point(labelRevisionDate.Right, labelRevisionNumber.Bottom + HEIGHT_INTERVAL);
            dateTimePickerRevisionDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerRevisionDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerRevisionDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            // 
            // labelReasonForRevision
            // 
            labelReasonForRevision.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelReasonForRevision.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelReasonForRevision.Location = new Point(WIDTH_INTERVAL, labelRevisionDate.Bottom + HEIGHT_INTERVAL);
            labelReasonForRevision.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelReasonForRevision.Text = "Reason";
            // 
            // textBoxReasonForRevision
            // 
            textBoxReasonForRevision.BackColor = Color.White;
            textBoxReasonForRevision.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxReasonForRevision.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxReasonForRevision.Location = new Point(WIDTH_INTERVAL, labelReasonForRevision.Bottom);
            textBoxReasonForRevision.Multiline = true;
            textBoxReasonForRevision.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, 3 * LABEL_HEIGHT);
            textBoxReasonForRevision.ScrollBars = ScrollBars.Vertical;
            textBoxReasonForRevision.MaxLength = 150;
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Location = new Point(WIDTH_INTERVAL, textBoxReasonForRevision.Bottom + HEIGHT_INTERVAL);
            labelManHours.Size = new Size(LABEL_WIDTH_SHORT, LABEL_HEIGHT);
            labelManHours.Text = "Man Hours";
            // 
            // textBoxManHours
            // 
            textBoxManHours.BackColor = Color.White;
            textBoxManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManHours.Location = new Point(labelManHours.Right, textBoxReasonForRevision.Bottom + HEIGHT_INTERVAL);
            textBoxManHours.Size = new Size(TEXTBOX_WIDTH_SHORT, LABEL_HEIGHT);
            textBoxManHours.Text = "0.0";
            // 
            // labelCost
            // 
            labelCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCost.Location = new Point(textBoxManHours.Right + MAN_HOURS_INTERVAL, textBoxReasonForRevision.Bottom + HEIGHT_INTERVAL);
            labelCost.Size = new Size(LABEL_WIDTH_SHORT, LABEL_HEIGHT);
            labelCost.Text = "Cost (USD)";
            // 
            // textBoxCost
            // 
            textBoxCost.BackColor = Color.White;
            textBoxCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCost.Location = new Point(labelCost.Right, textBoxReasonForRevision.Bottom + HEIGHT_INTERVAL);
            textBoxCost.Size = new Size(TEXTBOX_WIDTH_SHORT, LABEL_HEIGHT);
            textBoxCost.Text = "0.0";
            

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(WIDTH_INTERVAL + LABEL_WIDTH + TEXTBOX_WIDTH, 22 * LABEL_HEIGHT + 8 * HEIGHT_INTERVAL + 2 * MARGIN);
            Controls.Add(labelEONumber);
            Controls.Add(textboxEONumber);
            Controls.Add(labelATAChapter);
            Controls.Add(comboBoxAtaChapter);
            Controls.Add(labelSubject);
            Controls.Add(textboxSubject);
            Controls.Add(labelDescription);
            Controls.Add(textboxDescription);
            Controls.Add(labelSpecialWorkingInstructions);
            Controls.Add(textboxSpecialWorkingInstructions);
            Controls.Add(labelApprovalDocument);
            Controls.Add(textBoxApprovalDocument);
            Controls.Add(labelWarranty);
            Controls.Add(textboxWarranty);
            Controls.Add(labelNote);
            Controls.Add(textboxNote);
            Controls.Add(labelEffectivity);
            Controls.Add(textboxEffectivity);
            Controls.Add(labelRevision);
            Controls.Add(labelRevisionNumber);
            Controls.Add(textboxRevisionNumber);
            Controls.Add(labelRevisionDate);
            Controls.Add(dateTimePickerRevisionDate);
            Controls.Add(labelReasonForRevision);
            Controls.Add(textBoxReasonForRevision);
            Controls.Add(labelManHours);
            Controls.Add(textBoxManHours);
            Controls.Add(labelCost);
            Controls.Add(textBoxCost);
        }

        #endregion
        
        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            double eps = 0.00001;
            if (directiveExist)
                return ((textboxEONumber.Text != directive.Title) ||
                        (ATAChapter != directive.AtaChapter) ||
                        (textboxNote.Text != directive.Remarks) ||
                        (textboxDescription.Text != directive.Description) ||
                        (textboxSubject.Text != directive.Subject) ||
                        (textboxWarranty.Text != directive.Warranty) ||
                        (textBoxApprovalDocument.Text != directive.ApprovalDocument) ||
                        (textboxEffectivity.Text != directive.Applicability) ||
                        (textboxRevisionNumber.Text != directive.Revision) ||
                        (dateTimePickerRevisionDate.Value != directive.RevisionDate) ||
                        (textBoxReasonForRevision.Text != directive.ReasonForRevision) ||
                        (textboxSpecialWorkingInstructions.Text != directive.SpecialWorkingInstructions) ||
                        (Math.Abs((Manhours - Math.Round(directive.ManHours, 2))) > eps) ||
                        (Math.Abs((Cost - Math.Round(directive.Cost, 2))) > eps));
            else
            {
                Date revisionDate = new Date(dateTimePickerRevisionDate.Value);
                Date today = new Date(DateTime.Today);
                return ((textboxEONumber.Text != "") ||
                        (ATAChapter != null) ||
                        (textboxNote.Text != "") ||
                        (textboxDescription.Text != "") ||
                        (textboxSubject.Text != "") ||
                        (textboxWarranty.Text != "") ||
                        (textBoxApprovalDocument.Text != "") ||
                        (textboxEffectivity.Text != "") ||
                        (textboxRevisionNumber.Text != "") ||
                        (revisionDate.ToDateTime() != today.ToDateTime()) ||
                        (textBoxReasonForRevision.Text != "") ||
                        (textboxSpecialWorkingInstructions.Text != "") ||
                        (ManhoursString != "0.0") ||
                        (CostString != "0.0"));
            }
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (directive != null)
                UpdateInformation(directive);
        }

        #endregion

        #region public void UpdateInformation(EngineeringOrderDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(EngineeringOrderDirective sourceDirective)
        {
            if (sourceDirective == null) 
                throw new ArgumentNullException("sourceDirective");
            textboxEONumber.Text = sourceDirective.Title;
            ATAChapter = sourceDirective.AtaChapter;
            textboxSubject.Text = sourceDirective.Subject;
            textboxDescription.Text = sourceDirective.Description;
            textboxNote.Text = sourceDirective.Remarks;
            textboxWarranty.Text = sourceDirective.Warranty;
            textBoxApprovalDocument.Text = sourceDirective.ApprovalDocument;
            textboxEffectivity.Text = sourceDirective.Applicability;
            textboxRevisionNumber.Text = sourceDirective.Revision;
            dateTimePickerRevisionDate.Value = sourceDirective.RevisionDate;
            textBoxReasonForRevision.Text = sourceDirective.ReasonForRevision;
            textboxSpecialWorkingInstructions.Text = sourceDirective.SpecialWorkingInstructions;
            Manhours = sourceDirective.ManHours;
            Cost = sourceDirective.Cost;

            bool permission = directive.HasPermission(Users.CurrentUser, DataEvent.Update);

            textboxEONumber.ReadOnly = !permission;
            comboBoxAtaChapter.Enabled = permission;
            textboxSubject.ReadOnly = !permission;
            textboxDescription.ReadOnly = !permission;
            textboxNote.ReadOnly = !permission;
            textboxWarranty.ReadOnly = !permission;
            textBoxApprovalDocument.ReadOnly = !permission;
            textboxEffectivity.ReadOnly = !permission;
            textboxRevisionNumber.ReadOnly = !permission;
            dateTimePickerRevisionDate.Enabled = permission;
            textBoxReasonForRevision.Enabled = permission;
            textboxSpecialWorkingInstructions.ReadOnly = !permission;
            textBoxManHours.ReadOnly = !permission;
            textBoxCost.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (directive != null)
            {
                SaveData(directive, true);
            }
        }

        #endregion

        #region public void SaveData(EngineeringOrderDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void SaveData(EngineeringOrderDirective destinationDirective, bool changePageName)
        {
            //textboxEONumber.Focus();
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return;
            if (!CheckCost(out cost))
                return;
            if (destinationDirective.Title != textboxEONumber.Text)
            {
                destinationDirective.Title = textboxEONumber.Text;
                if (changePageName)
                {
                    string caption = "";
                    if (destinationDirective.Parent is BaseDetail)
                    {
                        BaseDetail baseDetail = (BaseDetail)destinationDirective.Parent;
                        if (baseDetail is AircraftFrame)
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                        else
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                    }
                    if (DisplayerRequested != null)
                        DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
                }
            }
            if (destinationDirective.AtaChapter != ATAChapter)
                destinationDirective.AtaChapter = ATAChapter;
            if (destinationDirective.Subject != textboxSubject.Text)
                destinationDirective.Subject = textboxSubject.Text;
            if (destinationDirective.Description != textboxDescription.Text)
                destinationDirective.Description = textboxDescription.Text;
            if (destinationDirective.Remarks != textboxNote.Text)
                destinationDirective.Remarks = textboxNote.Text;
            if (destinationDirective.Warranty != textboxWarranty.Text)
                destinationDirective.Warranty = textboxWarranty.Text;
            if (destinationDirective.ApprovalDocument != textBoxApprovalDocument.Text)
                destinationDirective.ApprovalDocument = textBoxApprovalDocument.Text;
            if (destinationDirective.Applicability != textboxEffectivity.Text)
                destinationDirective.Applicability = textboxEffectivity.Text;
            if (destinationDirective.Revision != textboxRevisionNumber.Text)
                destinationDirective.Revision = textboxRevisionNumber.Text;
            if (destinationDirective.RevisionDate != dateTimePickerRevisionDate.Value)
                destinationDirective.RevisionDate = dateTimePickerRevisionDate.Value;
            if (destinationDirective.ReasonForRevision != textBoxReasonForRevision.Text)
                destinationDirective.ReasonForRevision = textBoxReasonForRevision.Text;
            if (destinationDirective.SpecialWorkingInstructions != textboxSpecialWorkingInstructions.Text)
                destinationDirective.SpecialWorkingInstructions = textboxSpecialWorkingInstructions.Text;
            if (destinationDirective.ManHours != manHours)
                destinationDirective.ManHours = manHours;
            if (destinationDirective.Cost != cost)
                destinationDirective.Cost = cost;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textboxEONumber.Text = "";
            comboBoxAtaChapter.ClearValue();
            textboxSubject.Text = "";
            textboxDescription.Text = "";
            textboxNote.Text = "";
            textboxWarranty.Text = "";
            textBoxApprovalDocument.Text = "";
            textboxEffectivity.Text = "";
            textboxRevisionNumber.Text = "";
            dateTimePickerRevisionDate.Value = DateTime.Today;
            textBoxReasonForRevision.Text = "";
            textboxSpecialWorkingInstructions.Text = "";
            ManhoursString = "0.0";
            CostString = "0.0";
        }

        #endregion

        #region public bool CheckManHours(out double manHours)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="manHours">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckManHours(out double manHours)
        {
            if (double.TryParse(ManhoursString, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckCost(out double cost)

        /// <summary>
        /// Проверяет значение Cost
        /// </summary>
        /// <param name="cost">Значение Cost</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckCost(out double cost)
        {
            if (double.TryParse(CostString, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}