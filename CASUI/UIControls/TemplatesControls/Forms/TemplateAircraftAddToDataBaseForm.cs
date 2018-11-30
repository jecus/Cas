using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Exceptions;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CasPresenter;
using CASTerms;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class TemplateAircraftAddToDataBaseForm : Form
    {

        #region Fields
       
        private AnimatedThreadWorker animatedThreadWorker;

        private Int32 transferedAircraftID = 0;
        private AircraftProxy transferedAircraft;
        private TemplateAircraft templateAircraft;
        private Operator currentOperator;
        private List<Operator> operators;
        private List<TemplateAircraft> templates;
        private ScreensToOpening screensToOpening = ScreensToOpening.EditAircraftGeneralData;

        private Label labelTitle;
        private PictureBox pictureBoxTitle;
        private Label labelOperator;
        private ComboBox comboBoxOperators;
        private Label labelTemplate;
        private ComboBox comboBoxTemplates;
        private Label labelRegistrationNumber;
        private TextBox textBoxRegistrationNumber;
        private Label labelSerialNumber;
        private TextBox textBoxSerialNumber;
        private Label labelLineNumber;
        private TextBox textBoxLineNumber;
        private Label labelOwner;
        private TextBox textBoxOwner;
        private Label labelModel;
        private TextBox textBoxModel;
        private Label labelManufactureDate;
        private DateTimePicker dateTimePickerManufactureDate;
        private Label labelVariableNumber;
        private TextBox textBoxVariableNumber;
        private Label labelAfterCreating;
        private RadioButton radioButtonTakeNoAction;
        private RadioButton radioButtonAircrafts;
        private RadioButton radioButtonAircraftGeneralData;
        private Button buttonCreateAircraft;
        private Button buttonCancel;
        
        private readonly Icons icons = new Icons();
        private const int LEFT_MARGIN = 10;
        private const int TOP_MARGIN = 10;
        private const int HEIGHT_INTERVAL = 15;
        private const int WIDTH_INTERVAL = 400;
        private const int BUTTON_INTERVAL = 20;
        private const int LABEL_WIDTH = 160;
        private const int LABEL_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 200;
        private const int RADIO_BUTTON_WIDTH = 300;
        private readonly Size pictureBoxSize = new Size(40,40);
        private readonly Size buttonSize = new Size(150,40);

        #endregion

        #region Constructors

        #region public TemplateAircraftAddToDataBaseForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        public TemplateAircraftAddToDataBaseForm()
        {
            InitializeComponents();
            UpdateInformation();
        }

        #endregion
        
        #region public TemplateAircraftAddToDataBaseForm(TemplateAircraft templateAircraft)

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        /// <param name="aircraft"></param>
        public TemplateAircraftAddToDataBaseForm(TemplateAircraft aircraft)
        {
            this.templateAircraft = aircraft;
            InitializeComponents();
            UpdateInformation();
        }

        #endregion
        
        #endregion

        #region Properties

        #region private int TransferedAircraftId
        /// <summary>
        /// ID созданого ВС (возвращает 0 если операция не произашла)
        /// </summary>
        private int TransferedAircraftId
        {
            get { return transferedAircraftID; }
            set { transferedAircraftID = value; }
        }

        #endregion

        #region public Aircraft TransferedAircraft
        /// <summary>
        /// Transfered Aircraft
        /// </summary>
        public AircraftProxy TransferedAircraft
        {
            get { return transferedAircraft; }
        }
        #endregion

        #region public Operator Operator

        /// <summary>
        /// Вовзращает или устанавливает эксплуатанта, к которому добавляются воздушное судно
        /// </summary>
        public Operator Operator
        {
            get { return currentOperator; }
            set { currentOperator = value; }
        }

        #endregion

        #region public ScreensToOpening ScreensToOpening

        /// <summary>
        /// Возвращает значение, показывающее какие вкладки следует открыть
        /// </summary>
        public ScreensToOpening ScreensToOpening
        {
            get { return screensToOpening; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            pictureBoxTitle = new PictureBox();
            labelTitle = new Label();
            labelOperator = new Label();
            comboBoxOperators = new ComboBox();
            labelTemplate = new Label();
            comboBoxTemplates = new ComboBox();
            labelRegistrationNumber = new Label();
            textBoxRegistrationNumber = new TextBox();
            labelSerialNumber = new Label();
            textBoxSerialNumber = new TextBox();
            labelLineNumber = new Label();
            textBoxLineNumber = new TextBox();
            labelOwner = new Label();
            textBoxOwner = new TextBox();
            labelModel = new Label();
            textBoxModel = new TextBox();
            labelManufactureDate = new Label();
            dateTimePickerManufactureDate = new DateTimePicker();
            labelVariableNumber = new Label();
            textBoxVariableNumber = new TextBox();
            labelAfterCreating = new Label();
            radioButtonTakeNoAction = new RadioButton();
            radioButtonAircrafts = new RadioButton();
            radioButtonAircraftGeneralData = new RadioButton();
            buttonCreateAircraft = new Button();
            buttonCancel = new Button();
            // 
            // pictureBoxTitle
            // 
            pictureBoxTitle.Image = icons.GrayArrow;
            pictureBoxTitle.Location = new Point(LEFT_MARGIN, TOP_MARGIN);
            pictureBoxTitle.Size = pictureBoxSize;
            pictureBoxTitle.SizeMode = PictureBoxSizeMode.CenterImage;
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.HeaderText.Fonts.Font;
            labelTitle.ForeColor = Css.HeaderText.Colors.ForeColor;
            labelTitle.Location = new Point(pictureBoxTitle.Right, TOP_MARGIN);
            labelTitle.Size = new Size(RADIO_BUTTON_WIDTH, pictureBoxSize.Height);
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.Text = "Create Aircraft";
            // 
            // labelOperator
            // 
            labelOperator.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOperator.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelOperator.Location = new Point(LEFT_MARGIN, pictureBoxTitle.Bottom + HEIGHT_INTERVAL);
            labelOperator.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelOperator.TextAlign = ContentAlignment.MiddleLeft;
            labelOperator.Text = "Operator";
            // 
            // comboBoxOperators
            // 
            comboBoxOperators.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxOperators.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            comboBoxOperators.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperators.Location = new Point(labelOperator.Right, pictureBoxTitle.Bottom + HEIGHT_INTERVAL);
            comboBoxOperators.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            comboBoxOperators.TabIndex = 0;
            // 
            // labelTemplate
            // 
            labelTemplate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTemplate.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelTemplate.Location = new Point(LEFT_MARGIN, labelOperator.Bottom + HEIGHT_INTERVAL);
            labelTemplate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTemplate.TextAlign = ContentAlignment.MiddleLeft;
            labelTemplate.Text = "Template";
            // 
            // comboBoxTemplates
            // 
            comboBoxTemplates.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxTemplates.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            comboBoxTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTemplates.Location = new Point(labelTemplate.Right, labelOperator.Bottom + HEIGHT_INTERVAL);
            comboBoxTemplates.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            comboBoxTemplates.TabIndex = 1;
            comboBoxTemplates.SelectedIndexChanged += comboBoxTemplates_SelectedIndexChanged;
            // 
            // labelRegistrationNumber
            // 
            labelRegistrationNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRegistrationNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelRegistrationNumber.Location = new Point(LEFT_MARGIN, labelTemplate.Bottom + HEIGHT_INTERVAL);
            labelRegistrationNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRegistrationNumber.TextAlign = ContentAlignment.MiddleLeft;
            labelRegistrationNumber.Text = "Registration Number";
            // 
            // textBoxRegistrationNumber
            // 
            textBoxRegistrationNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRegistrationNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxRegistrationNumber.Location = new Point(labelRegistrationNumber.Right, labelTemplate.Bottom + HEIGHT_INTERVAL);
            textBoxRegistrationNumber.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxRegistrationNumber.TabIndex = 2;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelSerialNumber.Location = new Point(LEFT_MARGIN, labelRegistrationNumber.Bottom + HEIGHT_INTERVAL);
            labelSerialNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            labelSerialNumber.Text = "Serial Number";
            // 
            // textBoxSerialNumber
            // 
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxSerialNumber.Location = new Point(labelSerialNumber.Right, labelRegistrationNumber.Bottom + HEIGHT_INTERVAL);
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxSerialNumber.TabIndex = 3;
            // 
            // labelLineNumber
            // 
            labelLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLineNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelLineNumber.Location = new Point(LEFT_MARGIN, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelLineNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelLineNumber.TextAlign = ContentAlignment.MiddleLeft;
            labelLineNumber.Text = "Line Number";
            // 
            // textBoxLineNumber
            // 
            textBoxLineNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxLineNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxLineNumber.Location = new Point(labelLineNumber.Right, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxLineNumber.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxLineNumber.TabIndex = 4;
            // 
            // labelOwner
            // 
            labelOwner.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOwner.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelOwner.Location = new Point(WIDTH_INTERVAL, pictureBoxTitle.Bottom + HEIGHT_INTERVAL);
            labelOwner.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelOwner.TextAlign = ContentAlignment.MiddleLeft;
            labelOwner.Text = "Owner";
            // 
            // textBoxOwner
            // 
            textBoxOwner.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxOwner.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxOwner.Location = new Point(labelOwner.Right, pictureBoxTitle.Bottom + HEIGHT_INTERVAL);
            textBoxOwner.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxOwner.TabIndex = 5;
            // 
            // labelModel
            // 
            labelModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelModel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelModel.Location = new Point(WIDTH_INTERVAL, labelOwner.Bottom + HEIGHT_INTERVAL);
            labelModel.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelModel.TextAlign = ContentAlignment.MiddleLeft;
            labelModel.Text = "Model";
            // 
            // textBoxModel
            // 
            textBoxModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxModel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxModel.Location = new Point(labelModel.Right, labelOwner.Bottom + HEIGHT_INTERVAL);
            textBoxModel.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxModel.TabIndex = 6;
            // 
            // labelManufactureDate
            // 
            labelManufactureDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManufactureDate.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelManufactureDate.Location = new Point(WIDTH_INTERVAL, labelModel.Bottom + HEIGHT_INTERVAL);
            labelManufactureDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManufactureDate.TextAlign = ContentAlignment.MiddleLeft;
            labelManufactureDate.Text = "Manufacture Date";
            // 
            // dateTimePickerManufactureDate
            // 
            dateTimePickerManufactureDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerManufactureDate.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            dateTimePickerManufactureDate.Location = new Point(labelManufactureDate.Right, labelModel.Bottom + HEIGHT_INTERVAL);
            dateTimePickerManufactureDate.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerManufactureDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerManufactureDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerManufactureDate.TabIndex = 7;
            // 
            // labelVariableNumber
            // 
            labelVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelVariableNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelVariableNumber.Location = new Point(WIDTH_INTERVAL, labelManufactureDate.Bottom + HEIGHT_INTERVAL);
            labelVariableNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelVariableNumber.TextAlign = ContentAlignment.MiddleLeft;
            labelVariableNumber.Text = "Variable Number";
            // 
            // textBoxVariableNumber
            // 
            textBoxVariableNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxVariableNumber.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            textBoxVariableNumber.Location = new Point(labelVariableNumber.Right, labelManufactureDate.Bottom + HEIGHT_INTERVAL);
            textBoxVariableNumber.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxVariableNumber.TabIndex = 8;
            // 
            // labelAfterCreating
            // 
            labelAfterCreating.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelAfterCreating.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            labelAfterCreating.Location = new Point(LEFT_MARGIN, labelLineNumber.Bottom + HEIGHT_INTERVAL);
            labelAfterCreating.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            labelAfterCreating.TextAlign = ContentAlignment.MiddleLeft;
            labelAfterCreating.Text = "After creating templateAircraft";
            // 
            // radioButtonTakeNoAction
            // 
            radioButtonTakeNoAction.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonTakeNoAction.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            radioButtonTakeNoAction.Location = new Point(LEFT_MARGIN, labelAfterCreating.Bottom + HEIGHT_INTERVAL);
            radioButtonTakeNoAction.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonTakeNoAction.TextAlign = ContentAlignment.MiddleLeft;
            radioButtonTakeNoAction.Text = "Take no action";
            radioButtonTakeNoAction.TabIndex = 9;
            radioButtonTakeNoAction.CheckedChanged += radioButtons_CheckedChanged;
            // 
            // radioButtonAircrafts
            // 
            radioButtonAircrafts.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonAircrafts.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            radioButtonAircrafts.Location = new Point(LEFT_MARGIN, radioButtonTakeNoAction.Bottom + HEIGHT_INTERVAL);
            radioButtonAircrafts.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonAircrafts.TextAlign = ContentAlignment.MiddleLeft;
            radioButtonAircrafts.Text = "Open templateAircraft screen";
            radioButtonAircrafts.TabIndex = 10;
            radioButtonAircrafts.CheckedChanged += radioButtons_CheckedChanged;
            // 
            // radioButtonAircraftGeneralData
            // 
            radioButtonAircraftGeneralData.Checked = true;
            radioButtonAircraftGeneralData.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonAircraftGeneralData.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            radioButtonAircraftGeneralData.Location = new Point(LEFT_MARGIN, radioButtonAircrafts.Bottom + HEIGHT_INTERVAL);
            radioButtonAircraftGeneralData.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonAircraftGeneralData.TextAlign = ContentAlignment.MiddleLeft;
            radioButtonAircraftGeneralData.Text = "Edit templateAircraft general data";
            radioButtonAircraftGeneralData.TabIndex = 11;
            radioButtonAircraftGeneralData.CheckedChanged += radioButtons_CheckedChanged;
            // 
            // buttonCreateAircraft
            // 
            buttonCreateAircraft.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCreateAircraft.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonCreateAircraft.FlatStyle = FlatStyle.Flat;
            buttonCreateAircraft.Size = buttonSize;
            buttonCreateAircraft.Text = "Create Aircraft";
            buttonCreateAircraft.Click += buttonCreateAircraft_Click;
            buttonCreateAircraft.TabIndex = 12;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.Size = buttonSize;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            buttonCancel.TabIndex = 13;
            // 
            // TemplateAircraftAddToDataBaseForm
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            AcceptButton = buttonCreateAircraft;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(WIDTH_INTERVAL + LABEL_WIDTH + TEXT_BOX_WIDTH + LEFT_MARGIN, 2 * TOP_MARGIN + pictureBoxSize.Height + 9 * LABEL_HEIGHT + 10 * HEIGHT_INTERVAL + buttonSize.Height);
            Text = "CAS. Add templateAircraft to operator";
            Controls.Add(pictureBoxTitle);
            Controls.Add(labelTitle);
            Controls.Add(labelOperator);
            Controls.Add(comboBoxOperators);
            Controls.Add(labelTemplate);
            Controls.Add(comboBoxTemplates);
            Controls.Add(labelRegistrationNumber);
            Controls.Add(textBoxRegistrationNumber);
            Controls.Add(labelSerialNumber);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(labelLineNumber);
            Controls.Add(textBoxLineNumber);
            Controls.Add(labelOwner);
            Controls.Add(textBoxOwner);
            Controls.Add(labelModel);
            Controls.Add(textBoxModel);
            Controls.Add(labelManufactureDate);
            Controls.Add(dateTimePickerManufactureDate);
            Controls.Add(labelVariableNumber);
            Controls.Add(textBoxVariableNumber);
            Controls.Add(labelAfterCreating);
            Controls.Add(radioButtonTakeNoAction);
            Controls.Add(radioButtonAircrafts);
            Controls.Add(radioButtonAircraftGeneralData);
            Controls.Add(buttonCreateAircraft);
            Controls.Add(buttonCancel);
        }

        #endregion
        
        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            operators = new List<Operator>(OperatorCollection.Instance);
            templates = new List<TemplateAircraft>(TemplateAircraftCollection.Instance);
            operators.Sort(new OperatorNameComparer());
            templates.Sort(new TemplateAircraftModelComparer());
            for (int i = 0; i < operators.Count; i++)
                comboBoxOperators.Items.Add(operators[i].Name);
            for (int i = 0; i < templates.Count; i++)
                comboBoxTemplates.Items.Add(templates[i]);
            if (operators.Count > 0)
                comboBoxOperators.SelectedIndex = 0;
            if (templateAircraft != null)
                comboBoxTemplates.Text = templateAircraft.Model;
            else
                comboBoxTemplates.SelectedIndex = 0;
            buttonCreateAircraft.Enabled = (operators.Count != 0 && templates.Count != 0);
        }
        #endregion

        #region private void buttonCreateAircraft_Click(object sender, EventArgs e)
        /// <summary>
        /// Обработчик события нажатия на кнопку создания Воздушного судна.
        /// </summary>
        private void buttonCreateAircraft_Click(object sender, EventArgs e)
        {
            try
            {
                currentOperator = operators[comboBoxOperators.SelectedIndex];

                templateAircraft = templates[comboBoxTemplates.SelectedIndex];
                templateAircraft = Program.Presenters.AircraftsPresenter.CreateTemplateCopy(
                    templateAircraft,
                    textBoxRegistrationNumber.Text,
                    textBoxSerialNumber.Text,
                    dateTimePickerManufactureDate.Value,
                    textBoxOwner.Text,
                    textBoxLineNumber.Text,
                    textBoxVariableNumber.Text,
                    textBoxModel.Text);
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(
                    String.Format("Invalid value of parameter {0}. {1}", argumentException.ParamName, argumentException.Message),
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }   
         
            Enabled = false;
            animatedThreadWorker = new AnimatedThreadWorker(CreateAircraftFromTemplate, null, this);
            animatedThreadWorker.State = "Creating " + templateAircraft.RegistrationNumber;
            animatedThreadWorker.StartThread();
            animatedThreadWorker.WorkFinished += 
                CreateAircraftFromTemplateFinished;
        }
        #endregion

        #region private void CreateAircraftFromTemplate(Object state, out Object result)
        /// <summary>
        /// Метод создания Воздушного судна в параллельном потоке.
        /// </summary>
        private void CreateAircraftFromTemplate(Object state, out Object result)
        {
            try
            {
                transferedAircraftID =
                    Program.Presenters.AircraftsPresenter.TransferTemplateToOperator(
                        templateAircraft,
                        currentOperator);
                if (transferedAircraftID == 0)
                    throw new TransferException();

                currentOperator.Reload(true);

                transferedAircraft =
                    Program.Presenters.AircraftsPresenter.LoadAircraftById(
                        transferedAircraftID,
                        transferedAircraft,
                        currentOperator);
            }
            catch (TransferException transferException)
            {
                Program.Provider.Logger.Log(transferException.Message, transferException);
                result = false;
                return;
            }
            catch (LoadingException loadingException)
            {
                Program.Provider.Logger.Log(loadingException.Message, loadingException);
                result = false;
                return;
            }
            catch(ArgumentException ex)
            {
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while creation of aircraft", ex);
                result = false;
                return;
            }

            result = true;
        }
        #endregion

        #region private void CreateAircraftFromTemplateFinished(object sender, EventArgs e)
        /// <summary>
        /// Обработчик события, происходящего, когда создание Воздушного судна в
        /// параллельном потоке завершится.
        /// </summary>
        private void CreateAircraftFromTemplateFinished(object sender, EventArgs e)
        {
            Enabled = true;

            Boolean success = (Boolean)animatedThreadWorker.Result;
            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }

            currentOperator.Reload();
        }
        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            buttonCreateAircraft.Location = new Point(Width/2 - BUTTON_INTERVAL/2 - buttonSize.Width, radioButtonAircraftGeneralData.Bottom + HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(Width / 2 + BUTTON_INTERVAL / 2, radioButtonAircraftGeneralData.Bottom + HEIGHT_INTERVAL);
        }

        #endregion

        #region private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxModel.Text = comboBoxTemplates.Text;
        }

        #endregion

        #region private void radioButtons_CheckedChanged(object sender, EventArgs e)

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTakeNoAction.Checked)
                screensToOpening = ScreensToOpening.TakeNoAction;
            else if (radioButtonAircrafts.Checked)
                screensToOpening = ScreensToOpening.OpenAircraftScreen;
            else 
                screensToOpening = ScreensToOpening.EditAircraftGeneralData;
        }

        #endregion

        #endregion
    }

    #region public enum ScreensToOpening

    /// <summary>
    /// Перечисление, показывающее какие вкладки нужно открыть после добавления шаблона ВС
    /// </summary>
    public enum ScreensToOpening
    {
        /// <summary>
        /// Не открывать ничего
        /// </summary>
        TakeNoAction,
        /// <summary>
        /// Открыть вкладку со списком ВС и вкладку самого ВС
        /// </summary>
        OpenAircraftScreen,
        /// <summary>
        /// Открыть вкладку со списком ВС, вкладку самого ВС и вкладку AircraftGeneralData
        /// </summary>
        EditAircraftGeneralData
    }

    #endregion

}