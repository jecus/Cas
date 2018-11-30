using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Класс для отображения атрибутов и дополнительной информации о директиве
    /// </summary>
    public class DirectiveParametersControl : UserControl
    {

        #region Fields

        private const int MARGIN = 10;
        private const int CHECKBOX_WIDTH = 80;
        private const int LABEL_WIDTH = 150;
        private const int TEXTBOX_WIDTH = 350;
        private const int LABEL_REMARK_WIDTH = 500;
        private const int LABEL_HEIGHT = 25;
        private const int HEIGHT_INTERVAL = 20;
        private const int WIDTH_INTERVAL = 600;
        

        private readonly BaseDetailDirective currentDirective;

        private Label labelManHours;
        private TextBox textboxManHours;
        private Label labelCost;
        private TextBox textboxCost;
        private CheckBox checkBoxNDT;
        private Label labelNDT;
        //private readonly Label labelAdditionalParams;
        //private readonly Label labelAttributes;
        private Label labelEngOrderNo;
        private TextBox textBoxEngOrderNo;
        private LinkLabel linkLabelJobCard;
        private Label labelKitRequired;
        private TextBox textBoxKitRequired;
        private WindowsFormAttachedFileControl fileControl;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public DirectiveAttributesControl()

        /// <summary>
        /// Создает объект для отображения атрибутов и дополнительной информации о директиве
        /// </summary>
        public DirectiveParametersControl(DirectiveType directiveType)
        {
            InitializeComponent(directiveType);
        }

        #endregion

        #region public DirectiveAttributesControl (BaseDetailDirective currentDirective):this()

        /// <summary>
        /// Создает объект для отображения атрибутов и дополнительной информации о директиве
        /// </summary>
        /// <param name="currentDirective"></param>
        public DirectiveParametersControl(BaseDetailDirective currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;
            InitializeComponent(currentDirective.DirectiveType);
        }

        #endregion

        #endregion

        #region Properties

        #region public string EngOrderNumber

        /// <summary>
        /// Engineering order no
        /// </summary>
        public string EngOrderNumber
        {
            get
            {
                return textBoxEngOrderNo.Text;
            }
            set
            {
                textBoxEngOrderNo.Text = value;
            }
        }

        #endregion

        #region public string KitRequired
        /// <summary>
        /// Kit Required
        /// </summary>
        public string KitRequired
        {
            get { return textBoxKitRequired.Text; }
            set { textBoxKitRequired.Text = value; }
        }

        #endregion

        #region public bool Ndt

        /// <summary>
        /// NDT parameter
        /// </summary>
        public bool Ndt
        {
            get
            {
                return checkBoxNDT.Checked;
            }
            set
            {
                checkBoxNDT.Checked = value;
            }
        }

        #endregion

        #region public double Manhours

        /// <summary>
        /// Manhours текущей директивы
        /// </summary>
        public double Manhours
        {
            get
            {
                double d;
                double.TryParse(textboxManHours.Text, out d);
                return d;
            }
            set
            {
                currentDirective.ManHours = value;
                if (Math.Abs(value) > 0.000001)
                    textboxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string ManhoursString

        /// <summary>
        /// Manhours текущей директивы
        /// </summary>
        public string ManhoursString
        {
            get
            {
                return textboxManHours.Text;
            }
            set
            {
                textboxManHours.Text = value;
            }
        }

        #endregion

        #region public double Cost

        /// <summary>
        /// Cost текущей директивы
        /// </summary>
        public double Cost
        {
            get
            {
                double d;
                double.TryParse(textboxCost.Text, out d);
                return d;
            }
            set
            {
                currentDirective.Cost = value;
                if (Math.Abs(value) > 0.000001)
                    textboxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string CostString

        /// <summary>
        /// Cost текущей директивы
        /// </summary>
        public string CostString
        {
            get
            {
                return textboxCost.Text;
            }
            set
            {
                textboxCost.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent(DirectiveType directiveType)

        private void InitializeComponent(DirectiveType directiveType)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;

            checkBoxNDT = new CheckBox();
            labelNDT = new Label();
            labelManHours = new Label();
            textboxManHours = new TextBox();
            labelCost = new Label();
            textboxCost = new TextBox();
            labelEngOrderNo = new Label();
            textBoxEngOrderNo = new TextBox();
            linkLabelJobCard = new LinkLabel();
            labelKitRequired = new Label();
            textBoxKitRequired = new TextBox();
            fileControl = new WindowsFormAttachedFileControl(null, "Adobe PDF Files|*.pdf",
                    "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
                    "Attached file proves the compliance.", icons.PDFSmall);
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Location = new Point(MARGIN, MARGIN);
            labelManHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManHours.Text = "Man Hours";
            // 
            // textboxManHours
            // 
            textboxManHours.BackColor = Color.White;
            textboxManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxManHours.Location = new Point(labelManHours.Right, MARGIN);
            textboxManHours.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelCost
            // 
            labelCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCost.Location = new Point(MARGIN, labelManHours.Bottom + HEIGHT_INTERVAL);
            labelCost.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCost.Text = "Cost (USD)";
            // 
            // textboxCost
            // 
            textboxCost.BackColor = Color.White;
            textboxCost.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxCost.Location = new Point(labelCost.Right, labelManHours.Bottom + HEIGHT_INTERVAL);
            textboxCost.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // checkBoxNDT
            // 
            checkBoxNDT.Cursor = Cursors.Hand;
            checkBoxNDT.FlatStyle = FlatStyle.Flat;
            checkBoxNDT.Font = Css.SimpleLink.Fonts.Font;
            checkBoxNDT.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxNDT.Size = new Size(CHECKBOX_WIDTH, LABEL_HEIGHT);
            checkBoxNDT.Text = "NDT";
            // 
            // labelNDT
            // 
            labelNDT.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNDT.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNDT.Size = new Size(LABEL_REMARK_WIDTH, LABEL_HEIGHT);
            labelNDT.Text = "The work requires Non Destructive Test equipment";
            labelNDT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelEngOrderNo
            // 
            labelEngOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngOrderNo.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelEngOrderNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEngOrderNo.Text = "Eng. Order No:";
            // 
            // textBoxEngOrderNo
            // 
            textBoxEngOrderNo.BackColor = Color.White;
            textBoxEngOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxEngOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEngOrderNo.Location = new Point(labelEngOrderNo.Right, MARGIN);
            textBoxEngOrderNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxEngOrderNo.MaxLength = 200;
            // 
            // linkLabelJobCard
            // 
            linkLabelJobCard.Font = Css.SimpleLink.Fonts.Font;
            linkLabelJobCard.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelJobCard.Text = "Job Card";
            linkLabelJobCard.Location = new Point(WIDTH_INTERVAL, textBoxEngOrderNo.Bottom + HEIGHT_INTERVAL);
            linkLabelJobCard.LinkClicked += linkLabelJobCard_LinkClicked;
            linkLabelJobCard.Size = new Size(LABEL_WIDTH + TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelKitRequired
            // 
            labelKitRequired.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelKitRequired.Location = new Point(WIDTH_INTERVAL, linkLabelJobCard.Bottom + HEIGHT_INTERVAL);
            labelKitRequired.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelKitRequired.Text = "Kit Required:";
            // 
            // textBoxKitRequired
            // 
            textBoxKitRequired.BackColor = Color.White;
            textBoxKitRequired.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxKitRequired.Location = new Point(labelKitRequired.Right, linkLabelJobCard.Bottom + HEIGHT_INTERVAL);
            textBoxKitRequired.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxKitRequired.MaxLength = 50;
            // 
            // DirectiveAttributesControl
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                checkBoxNDT.Location = new Point(MARGIN, labelCost.Bottom + HEIGHT_INTERVAL);
                labelNDT.Location = new Point(checkBoxNDT.Right, labelCost.Bottom + HEIGHT_INTERVAL);
                fileControl.Location = new Point(MARGIN, checkBoxNDT.Bottom + HEIGHT_INTERVAL);
                Controls.Add(labelManHours);
                Controls.Add(textboxManHours);
                Controls.Add(labelCost);
                Controls.Add(textboxCost);
            }
            else
            {
                checkBoxNDT.Location = new Point(MARGIN, MARGIN);
                labelNDT.Location = new Point(checkBoxNDT.Right, MARGIN);
                fileControl.Location = new Point(MARGIN, checkBoxNDT.Bottom + HEIGHT_INTERVAL);
            }
            Controls.Add(checkBoxNDT);
            Controls.Add(labelNDT);
            Controls.Add(labelEngOrderNo);
            Controls.Add(textBoxEngOrderNo);
            Controls.Add(linkLabelJobCard);
            Controls.Add(labelKitRequired);
            Controls.Add(textBoxKitRequired);
            Controls.Add(fileControl);

            //fileControl.Width = LABEL_WIDTH + TEXTBOX_WIDTH;
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
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return true;
            if (!CheckCost(out cost))
                return true;
            if (directiveExist)
                return
                    ((currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType && (Math.Abs(currentDirective.ManHours - manHours) > eps || Math.Abs(currentDirective.Cost - cost) > eps))) ||
                    (Ndt != currentDirective.NonDestructiveTest) ||
                    (EngOrderNumber != currentDirective.EngeneeringOrders) ||
                    (KitRequired != currentDirective.KitRequired);
            else
                return (Ndt || (EngOrderNumber != "") || (KitRequired != ""));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                if (Math.Abs(currentDirective.ManHours) > 0.000001)
                    textboxManHours.Text = currentDirective.ManHours.ToString();
                if (Math.Abs(currentDirective.Cost) > 0.000001)
                    textboxCost.Text = currentDirective.Cost.ToString();
            }
            Ndt = currentDirective.NonDestructiveTest;
            EngOrderNumber = currentDirective.EngeneeringOrders;
            KitRequired = currentDirective.KitRequired;
            if (currentDirective.JobCard != null)
                linkLabelJobCard.Text = "Job Card: " + currentDirective.JobCard.AirlineCardNumber;

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            checkBoxNDT.Enabled = permission;
            textBoxEngOrderNo.ReadOnly = !permission;
            linkLabelJobCard.Enabled = permission;
            textBoxKitRequired.ReadOnly = !permission;
        }

        #endregion

        #region public void SaveData(BaseDetailDirective destinationDirective)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData(BaseDetailDirective destinationDirective)
        {
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return;
            if (!CheckCost(out cost))
                return;
            if (destinationDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                if (destinationDirective.ManHours != manHours)
                    destinationDirective.ManHours = manHours;
                if (destinationDirective.Cost != cost)
                    destinationDirective.Cost = cost;
            }
            destinationDirective.NonDestructiveTest = Ndt;
            destinationDirective.EngeneeringOrders = EngOrderNumber;
            destinationDirective.KitRequired = KitRequired;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (currentDirective != null)
            {
                SaveData(currentDirective);
            }
        }

        #endregion

        #region public void ClearFields(DirectiveType directiveType)

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields(DirectiveType directiveType)
        {
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                ManhoursString = "";
                CostString = "";
            }
            Ndt = false;
            EngOrderNumber = "";
            KitRequired = "";
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
            if (ManhoursString == "")
            {
                manHours = 0;
                return true;
            }
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
            if (CostString == "")
            {
                cost = 0;
                return true;
            }
            if (double.TryParse(CostString, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaintenanceJobCardForm form;
            if (currentDirective.JobCard == null)
                form = new MaintenanceJobCardForm(currentDirective);
            else
                form = new MaintenanceJobCardForm(currentDirective.JobCard);
            form.ShowDialog();
        }

        #endregion

        #endregion
    }
}