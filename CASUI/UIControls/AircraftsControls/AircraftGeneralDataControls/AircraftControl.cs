using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MonthlyUtilizationsControls;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения общей информации о ВС
    /// </summary>
    public partial class AircraftControl : PictureBox, IReference
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int WIDTH_INTERVAL = 600;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 200;
        private const int LABEL_WIDTH = 220;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        private Aircraft currentAircraft;
        private DateTime dateAsOf;

        private readonly Label labelAircraftModel = new Label();
        private readonly Label labelAircraftTypeCertificateNo = new Label();
        private readonly Label labelManufactureDate = new Label();
        private readonly Label labelSerialNumber = new Label();
        private readonly Label labelVariableNumber = new Label();
        private readonly Label labelLineNumber = new Label();
        private readonly Label labelRegistrationNumber = new Label();
        private readonly Label labelAircraftTSNCSN = new Label();
        private readonly Label labelOwner = new Label();
        private readonly Label labelOperator = new Label();

        private readonly TextBox textBoxAircraftModel = new TextBox();
        private readonly TextBox textBoxAircraftTypeCertificateNo = new TextBox();
        private readonly TextBox textBoxManufactureDate = new TextBox();
        private readonly TextBox textBoxSerialNumber = new TextBox();
        private readonly TextBox textBoxVariableNumber = new TextBox();
        private readonly TextBox textBoxLineNumber = new TextBox();
        private readonly TextBox textBoxRegistrationNumber = new TextBox();
        private readonly TextBox textBoxAircraftTSNCSN = new TextBox();
        private readonly TextBox textBoxOwner = new TextBox();
        private readonly TextBox textBoxOperator = new TextBox();
        private readonly DateTimePicker dateTimePickerManufactureDate = new DateTimePicker();
        private readonly ReferenceLinkLabel linkMonthlyUtilization = new ReferenceLinkLabel();
        private readonly ReferenceLinkLabel linkViewAirCompany = new ReferenceLinkLabel();
        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения общей информации о ВС
        /// </summary>
        /// <param name="currentAircraft">ВС</param>
        /// <param name="dateAsOf"></param>
        public AircraftControl(Aircraft currentAircraft, DateTime dateAsOf)
        {
            this.currentAircraft = currentAircraft;
            this.dateAsOf = dateAsOf;
            Size = new Size(WIDTH_INTERVAL * 2, 8 * TEXT_BOX_HEIGHT + 7 * HEIGHT_INTERVAL + TOP_MARGIN + BOTTOM_MARGIN);
            //
            // linkMonthlyUtilization
            //
            linkMonthlyUtilization.Location = new Point(0, TOP_MARGIN);
            linkMonthlyUtilization.Font = Css.SimpleLink.Fonts.Font;
            linkMonthlyUtilization.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkMonthlyUtilization.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            linkMonthlyUtilization.Text = "Monthly Utilization";
            linkMonthlyUtilization.TextAlign = ContentAlignment.MiddleLeft;
            linkMonthlyUtilization.ReflectionType = ReflectionTypes.DisplayInNew;
            linkMonthlyUtilization.DisplayerText = currentAircraft.RegistrationNumber + ". Monthly Utilization";
            linkMonthlyUtilization.DisplayerRequested += linkMonthlyUtilization_DisplayerRequested;
            //
            // linkViewAirCompany
            //
            linkViewAirCompany.Location = new Point(0, linkMonthlyUtilization.Bottom + HEIGHT_INTERVAL);
            linkViewAirCompany.Font = Css.SimpleLink.Fonts.Font;
            linkViewAirCompany.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkViewAirCompany.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            linkViewAirCompany.Text = "View " + currentAircraft.Operator.Name;
            linkViewAirCompany.TextAlign = ContentAlignment.MiddleLeft;
            linkViewAirCompany.ReflectionType = ReflectionTypes.DisplayInNew;
            linkViewAirCompany.DisplayerText = currentAircraft.Operator.Name;
            linkViewAirCompany.DisplayerRequested += linkViewAirCompany_DisplayerRequested;
            //
            // labelAircraftModel
            //
            labelAircraftModel.Location = new Point(0, linkViewAirCompany.Bottom + HEIGHT_INTERVAL);
            labelAircraftModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAircraftModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftModel.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAircraftModel.Text = "Aircraft Model";
            labelAircraftModel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelManufactureDate
            //
            labelManufactureDate.Location = new Point(0, labelAircraftModel.Bottom + HEIGHT_INTERVAL);
            labelManufactureDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufactureDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufactureDate.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelManufactureDate.Text = "Manufacture Date";
            labelManufactureDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelSerialNumber
            //
            labelSerialNumber.Location = new Point(0, labelManufactureDate.Bottom + HEIGHT_INTERVAL);
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelSerialNumber.Text = "Serial Number";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelRegistrationNumber
            //
            labelRegistrationNumber.Location = new Point(0, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelRegistrationNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRegistrationNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRegistrationNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelRegistrationNumber.Text = "Registration Number";
            labelRegistrationNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelAircraftTypeCertificateNo
            //
            labelAircraftTypeCertificateNo.Location = new Point(0, labelRegistrationNumber.Bottom + HEIGHT_INTERVAL);
            labelAircraftTypeCertificateNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAircraftTypeCertificateNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftTypeCertificateNo.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAircraftTypeCertificateNo.Text = "Aircraft Type Certificate No";
            labelAircraftTypeCertificateNo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelAircraftTSNCSN
            //
            labelAircraftTSNCSN.Location = new Point(WIDTH_INTERVAL, linkViewAirCompany.Bottom + HEIGHT_INTERVAL);
            labelAircraftTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAircraftTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftTSNCSN.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelAircraftTSNCSN.Text = "TSN/CSN";
            labelAircraftTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelOwner
            //
            labelOwner.Location = new Point(WIDTH_INTERVAL, labelAircraftTSNCSN.Bottom + HEIGHT_INTERVAL);
            labelOwner.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOwner.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelOwner.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelOwner.Text = "Owner";
            labelOwner.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelOperator
            //
            labelOperator.Location = new Point(WIDTH_INTERVAL, labelOwner.Bottom + HEIGHT_INTERVAL);
            labelOperator.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOperator.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelOperator.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelOperator.Text = "Operator";
            labelOperator.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelVariableNumber
            //
            labelVariableNumber.Location = new Point(WIDTH_INTERVAL, labelOperator.Bottom + HEIGHT_INTERVAL);
            labelVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelVariableNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelVariableNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelVariableNumber.Text = "Variable Number";
            labelVariableNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelLineNumber
            //
            labelLineNumber.Location = new Point(WIDTH_INTERVAL, labelVariableNumber.Bottom + HEIGHT_INTERVAL);
            labelLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLineNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLineNumber.Size = new Size(LABEL_WIDTH, TEXT_BOX_HEIGHT);
            labelLineNumber.Text = "Line Number";
            labelLineNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAircraftModel
            //
            textBoxAircraftModel.Location = new Point(LABEL_WIDTH, linkViewAirCompany.Bottom + HEIGHT_INTERVAL);
            textBoxAircraftModel.BackColor = Color.White;
            textBoxAircraftModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAircraftModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAircraftModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxManufactureDate
            //
            textBoxManufactureDate.Location = new Point(LABEL_WIDTH, textBoxAircraftModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufactureDate.BackColor = Color.White;
            textBoxManufactureDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufactureDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufactureDate.ReadOnly = true;
            textBoxManufactureDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // dateTimePickerManufactureDate
            //
            dateTimePickerManufactureDate.Location = new Point(LABEL_WIDTH, textBoxAircraftModel.Bottom + HEIGHT_INTERVAL);
            dateTimePickerManufactureDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerManufactureDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerManufactureDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerManufactureDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerManufactureDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Location = new Point(LABEL_WIDTH, dateTimePickerManufactureDate.Bottom + HEIGHT_INTERVAL);
            textBoxSerialNumber.BackColor = Color.White;
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxRegistrationNumber
            //
            textBoxRegistrationNumber.Location = new Point(LABEL_WIDTH, textBoxSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxRegistrationNumber.BackColor = Color.White;
            textBoxRegistrationNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRegistrationNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRegistrationNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxAircraftTypeCertificateNo
            //
            textBoxAircraftTypeCertificateNo.Location = new Point(LABEL_WIDTH, textBoxRegistrationNumber.Bottom + HEIGHT_INTERVAL);
            textBoxAircraftTypeCertificateNo.BackColor = Color.White;
            textBoxAircraftTypeCertificateNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAircraftTypeCertificateNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAircraftTypeCertificateNo.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxAircraftTSNCSN
            //
            textBoxAircraftTSNCSN.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, linkViewAirCompany.Bottom + HEIGHT_INTERVAL);
            textBoxAircraftTSNCSN.BackColor = Color.White;
            textBoxAircraftTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxAircraftTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxAircraftTSNCSN.ReadOnly = true;
            textBoxAircraftTSNCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxOwner
            //
            textBoxOwner.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxAircraftTSNCSN.Bottom + HEIGHT_INTERVAL);
            textBoxOwner.BackColor = Color.White;
            textBoxOwner.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxOwner.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxOwner.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxOperator
            //
            textBoxOperator.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxOwner.Bottom + HEIGHT_INTERVAL);
            textBoxOperator.BackColor = Color.White;
            textBoxOperator.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxOperator.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxOperator.ReadOnly = true;
            textBoxOperator.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxVariableNumber
            //
            textBoxVariableNumber.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxOperator.Bottom + HEIGHT_INTERVAL);
            textBoxVariableNumber.BackColor = Color.White;
            textBoxVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxVariableNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxVariableNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxLineNumber
            //
            textBoxLineNumber.Location = new Point(WIDTH_INTERVAL + LABEL_WIDTH, textBoxVariableNumber.Bottom + HEIGHT_INTERVAL);
            textBoxLineNumber.BackColor = Color.White;
            textBoxLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLineNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxLineNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);



            Controls.Add(linkMonthlyUtilization);
            Controls.Add(linkViewAirCompany);
            Controls.Add(labelAircraftModel);
            Controls.Add(labelManufactureDate);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelVariableNumber);
            Controls.Add(labelLineNumber);
            Controls.Add(labelRegistrationNumber);
            Controls.Add(labelAircraftTSNCSN);
            Controls.Add(labelOwner);
            Controls.Add(labelOperator);
            Controls.Add(labelAircraftTypeCertificateNo);
            Controls.Add(textBoxAircraftModel);
            Controls.Add(textBoxManufactureDate);
            Controls.Add(dateTimePickerManufactureDate);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(textBoxRegistrationNumber);
            Controls.Add(textBoxAircraftTypeCertificateNo);
            Controls.Add(textBoxAircraftTSNCSN);
            Controls.Add(textBoxOwner);
            Controls.Add(textBoxOperator);
            Controls.Add(textBoxVariableNumber);
            Controls.Add(textBoxLineNumber);
                        

            UpdateControl();

        }

        #endregion

        #region Properties

        #region public Aircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает текущее ВС
        /// </summary>
        public Aircraft Aircraft
        {
            get
            {
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                UpdateControl();
            }
        }

        #endregion

        #region public DateTime DateAsOf

        /// <summary>
        /// Возвращает или устанавливает дату DateAsOf
        /// </summary>
        public DateTime DateAsOf
        {
            get
            {
                return dateAsOf;
            }
            set
            {
                dateAsOf = value;
                UpdateDateAsOf();
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void CheckPermission()

        /// <summary>
        /// Метод, проверяющий права доступа текущего пользователя и блокирует при необходимости текстовые поля
        /// </summary>
        private void CheckPermission()
        {
            bool permission = currentAircraft.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxAircraftModel.ReadOnly = !permission;
            textBoxAircraftTypeCertificateNo.ReadOnly = !permission;
            textBoxManufactureDate.Visible = !permission;
            dateTimePickerManufactureDate.Visible = permission;
            textBoxSerialNumber.ReadOnly = !permission;
            textBoxVariableNumber.ReadOnly = !permission;
            textBoxLineNumber.ReadOnly = !permission;
            textBoxRegistrationNumber.ReadOnly = !permission;
            textBoxOwner.ReadOnly = !permission;
        }

        #endregion

        #region private void CheckAircraftType()

        /// <summary>
        /// Проверяет, какой тип судна отображается
        /// </summary>
        private void CheckAircraftType()
        {
            bool isWestAircraft = currentAircraft.Type == AircraftType.West ? true : false;
            if (isWestAircraft)
            {
                WestAircraft aircraft = currentAircraft as WestAircraft;
                if (aircraft != null)
                {
                    textBoxVariableNumber.Text = aircraft.VariableNumber;
                    textBoxLineNumber.Text = aircraft.LineNumber;
                    textBoxAircraftTypeCertificateNo.Text = aircraft.TypeCertificateNumber;
                }
                Height = 7 * (HEIGHT_INTERVAL + TEXT_BOX_HEIGHT) + TOP_MARGIN + BOTTOM_MARGIN;
            }
            else
            {
                Height = 6 * (HEIGHT_INTERVAL + TEXT_BOX_HEIGHT) + TOP_MARGIN + BOTTOM_MARGIN;
            }
            labelVariableNumber.Visible = isWestAircraft;
            labelLineNumber.Visible = isWestAircraft;
            labelAircraftTypeCertificateNo.Visible = isWestAircraft;
            textBoxVariableNumber.Visible = isWestAircraft;
            textBoxLineNumber.Visible = isWestAircraft;
            textBoxAircraftTypeCertificateNo.Visible = isWestAircraft;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            // Проверяем, изменены ли поля WestAircraft
            bool changedWestAircraftFields = false;
            if (currentAircraft is WestAircraft)
            {
                WestAircraft westAircraft = (WestAircraft)currentAircraft;
                if ((textBoxAircraftTypeCertificateNo.Text != westAircraft.TypeCertificateNumber) || (textBoxVariableNumber.Text != westAircraft.VariableNumber || (textBoxLineNumber.Text != westAircraft.LineNumber)))
                    changedWestAircraftFields = true;
                else
                    changedWestAircraftFields = false;
            }
            if (currentAircraft is AircraftProxy)
            {
                AircraftProxy westAircraft = (AircraftProxy)currentAircraft;
                if ((textBoxAircraftTypeCertificateNo.Text != westAircraft.TypeCertificateNumber) || (textBoxVariableNumber.Text != westAircraft.VariableNumber || (textBoxLineNumber.Text != westAircraft.LineNumber)))
                    changedWestAircraftFields = true;
                else
                    changedWestAircraftFields = false;
            }
            // Проверям остальные поля
            if ((textBoxAircraftModel.Text != currentAircraft.Model) || (dateTimePickerManufactureDate.Value != currentAircraft.ManufactureDate) || (textBoxSerialNumber.Text != currentAircraft.SerialNumber) || (textBoxRegistrationNumber.Text != currentAircraft.RegistrationNumber) || (textBoxOwner.Text != currentAircraft.Owner) || (changedWestAircraftFields))
            {
                return true;
            }
            else
                return false;
        }

        #endregion
        
        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего ВС
        /// </summary>
        public void SaveData()
        {
            if (textBoxAircraftModel.Text != currentAircraft.Model) 
                currentAircraft.Model = textBoxAircraftModel.Text;
            if (dateTimePickerManufactureDate.Value != currentAircraft.ManufactureDate)
                currentAircraft.ManufactureDate = dateTimePickerManufactureDate.Value;
            if (textBoxSerialNumber.Text != currentAircraft.SerialNumber)
                currentAircraft.SerialNumber = textBoxSerialNumber.Text;
            if (textBoxRegistrationNumber.Text != currentAircraft.RegistrationNumber)
            {
                currentAircraft.RegistrationNumber = textBoxRegistrationNumber.Text;
                linkMonthlyUtilization.Text = currentAircraft.AircraftFrame + ". Log Book";
                linkMonthlyUtilization.DisplayerText = currentAircraft.AircraftFrame + ". Log Book";
                if (DisplayerRequested != null)
                    DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, currentAircraft.RegistrationNumber + ". Aircraft General Data"));
            }
            if (textBoxOwner.Text != currentAircraft.Owner)
                currentAircraft.Owner = textBoxOwner.Text;
            if (currentAircraft is WestAircraft)
            {
                WestAircraft westAircraft = (WestAircraft)currentAircraft;
                if (textBoxAircraftTypeCertificateNo.Text != westAircraft.TypeCertificateNumber)
                    westAircraft.TypeCertificateNumber = textBoxAircraftTypeCertificateNo.Text;
                if (textBoxVariableNumber.Text != westAircraft.VariableNumber)
                    westAircraft.VariableNumber = textBoxVariableNumber.Text;
                if (textBoxLineNumber.Text != westAircraft.LineNumber)
                    westAircraft.LineNumber = textBoxLineNumber.Text;
            }
            if (currentAircraft is AircraftProxy)
            {
                AircraftProxy westAircraft = (AircraftProxy)currentAircraft;
                if (textBoxAircraftTypeCertificateNo.Text != westAircraft.TypeCertificateNumber)
                    westAircraft.TypeCertificateNumber = textBoxAircraftTypeCertificateNo.Text;
                if (textBoxVariableNumber.Text != westAircraft.VariableNumber)
                    westAircraft.VariableNumber = textBoxVariableNumber.Text;
                if (textBoxLineNumber.Text != westAircraft.LineNumber)
                    westAircraft.LineNumber = textBoxLineNumber.Text;
            }
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о текущем ВС
        /// </summary>
        private void UpdateControl()
        {
            textBoxAircraftModel.Text = currentAircraft.Model;
            textBoxManufactureDate.Text = currentAircraft.ManufactureDate.ToString(new TermsProvider()["DateFormat"].ToString());
            dateTimePickerManufactureDate.MaxDate = DateTime.Now;
            dateTimePickerManufactureDate.Value = currentAircraft.ManufactureDate;
            textBoxSerialNumber.Text = currentAircraft.SerialNumber;
            textBoxRegistrationNumber.Text = currentAircraft.RegistrationNumber;
            textBoxOwner.Text = currentAircraft.Owner;
            textBoxOperator.Text = currentAircraft.Operator.Name;
            if (currentAircraft is WestAircraft)
            {
                WestAircraft westAircraft = (WestAircraft)currentAircraft;
                textBoxAircraftTypeCertificateNo.Text = westAircraft.TypeCertificateNumber;
                textBoxVariableNumber.Text = westAircraft.VariableNumber;
                textBoxLineNumber.Text = westAircraft.LineNumber;
            }
            if (currentAircraft is AircraftProxy)
            {
                AircraftProxy westAircraft = (AircraftProxy)currentAircraft;
                textBoxAircraftTypeCertificateNo.Text = westAircraft.TypeCertificateNumber;
                textBoxVariableNumber.Text = westAircraft.VariableNumber;
                textBoxLineNumber.Text = westAircraft.LineNumber;
            }
            CheckAircraftType();
            UpdateDateAsOf();
            CheckPermission();
        }

        #endregion

        #region private void UpdateDateAsOf()

        /// <summary>
        /// Обновляет данные в полях TSN, CSN
        /// </summary>
        private void UpdateDateAsOf()
        {
            Aircraft clonedAircraft;
            object objectClone = currentAircraft.CloneAsDateOf(dateAsOf);
            if (!(objectClone is Aircraft))
                return;
            clonedAircraft = (Aircraft)objectClone;
            textBoxAircraftTSNCSN.Text = clonedAircraft.Lifelength.ToComplianceItemString();
        }

        #endregion

        #region private void linkMonthlyUtilization_DisplayerRequested(object sender, CAS.UI.Interfaces.ReferenceEventArgs e)

        private void linkMonthlyUtilization_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredMonthlyUtilizationScreen(currentAircraft);
        }

        #endregion

        #region private void linkViewAirCompany_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkViewAirCompany_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredAircraftCollectionScreen(currentAircraft.Operator);
        }

        #endregion

        #region IReference Members

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

        #endregion

    }
}
