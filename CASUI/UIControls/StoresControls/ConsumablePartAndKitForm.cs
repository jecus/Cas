using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// ‘орма дл€ редактировани€/добавлени€ Consumable Part / Kit
    /// </summary>
    public class ConsumablePartAndKitForm : Form
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly Store parentStore;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelType;
        private Label labelSerialNumber;
        private Label labelPartNumber;
        private Label labelDescription;
        private Label labelShelfLife;
        private Label labelMeasure;
        private Label labelQuantity;
        private Label labelExpiryDate;
        private Label labelNotificationDate;
        private Label labelServiceable;
        private Label labelRemarks;
        private Panel panelType;
        private RadioButton radioButtonConsumablePart;
        private RadioButton radioButtonKit;
        private TextBox textBoxSerialNumber;
        private TextBox textBoxPartNumber;
        private TextBox textBoxDescription;
        private TextBox textBoxShelfLife;
        private TextBox textBoxMeasure;
        private TextBox textBoxQuantity;
        private DateTimePicker dateTimePickerExpiryDate;
        private DateTimePicker dateTimePickerNotificationDate;
        private Panel panelServiceable;
        private RadioButton radioButtonServiceable;
        private RadioButton radioButtonUnserviceable;
        private TextBox textBoxRemarks;
        
        private Label labelSeparator;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public ConsumablePartAndKitForm(AbstractDetail detail)

        /// <summary>
        /// —оздает форму дл€ редактировани€ Consumable Part / Kit
        /// </summary>
        /// <param name="detail">јгрегат</param>
        public ConsumablePartAndKitForm(AbstractDetail detail)
        {
            currentDetail = detail;
            mode = ScreenMode.Edit;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public ConsumablePartAndKitForm(Store parentStore)

        /// <summary>
        /// —оздает форму дл€ добавлени€ Consumable Part / Kit
        /// </summary>
        /// <param name="parentStore">—клад, куда добавл€етс€ Consumable Part / Kit</param>
        public ConsumablePartAndKitForm(Store parentStore)
        {
            this.parentStore = parentStore;
            currentDetail = new DetailReal();
            currentDetail.DetailPattern = DetailPattern.ConsumablePart;
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Properties

        #region public DetailPattern DetailPattern

        /// <summary>
        /// ¬озвращает или устанавливает тип агрегата
        /// </summary>
        public DetailPattern DetailPattern
        {
            get
            {
                if (radioButtonConsumablePart.Checked)
                    return DetailPattern.ConsumablePart;
                else
                    return DetailPattern.Kit;
            }
            set
            {
                if (value == DetailPattern.ConsumablePart)
                    radioButtonConsumablePart.Checked = true;
                else
                    radioButtonKit.Checked = true;
            }
        }

        #endregion

        #region public string SerialNumber

        /// <summary>
        /// ¬озвращает или устанавливает серийный номер
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return textBoxSerialNumber.Text;
            }
            set
            {
                textBoxSerialNumber.Text = value;
            }
        }

        #endregion

        #region public string PartNumber

        /// <summary>
        /// ¬озвращает или устанавливает партийный номер
        /// </summary>
        public string PartNumber
        {
            get
            {
                return textBoxPartNumber.Text;
            }
            set
            {
                textBoxPartNumber.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// ¬озвращает или устанавливает описание агрегата
        /// </summary>
        public string Description
        {
            get
            {
                return textBoxDescription.Text;
            }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region public string ShelfLife

        /// <summary>
        /// ¬озвращает или устанавливает cрок хранени€ агрегата на складе
        /// </summary>
        public string ShelfLife
        {
            get
            {
                return textBoxShelfLife.Text;
            }
            set
            {
                textBoxShelfLife.Text = value;
            }
        }

        #endregion

        #region public DateTime ExpiryDate

        /// <summary>
        /// ¬озвращает или устанавливает дату истечени€ срока хранени€/экслуатации агрегата или расходника
        /// </summary>
        public DateTime ExpiryDate
        {
            get
            {
                return dateTimePickerExpiryDate.Value;
            }
            set
            {
                dateTimePickerExpiryDate.Value = value;
            }
        }

        #endregion

        #region public DateTime NotificationDate

        /// <summary>
        /// ¬озвращает или устанавливает дату, с которой агрегат будет подсвечен (желтым цветом)
        /// </summary>
        public DateTime NotificationDate
        {
            get
            {
                return dateTimePickerNotificationDate.Value;
            }
            set
            {
                dateTimePickerNotificationDate.Value = value;
            }
        }

        #endregion

        #region public bool Serviceable

        /// <summary>
        /// ¬озвращает или устанавливает значение, показывающее подлежит ли агрегат обслужеванию
        /// </summary>
        public bool Serviceable
        {
            get
            {
                return radioButtonServiceable.Checked;
            }
            set
            {
                if (value)
                    radioButtonServiceable.Checked = true;
                else
                    radioButtonUnserviceable.Checked = true;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// ¬озвращает или устанавливает замечани€ к агрегату
        /// </summary>
        public string Remarks
        {
            get
            {
                return textBoxRemarks.Text;
            }
            set
            {
                textBoxRemarks.Text = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelType = new Label();
            panelType = new Panel();
            radioButtonConsumablePart = new RadioButton();
            radioButtonKit = new RadioButton();
            labelSerialNumber = new Label();
            textBoxSerialNumber = new TextBox();
            labelPartNumber = new Label();
            textBoxPartNumber = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelShelfLife = new Label();
            textBoxShelfLife = new TextBox();
            labelMeasure = new Label();
            textBoxMeasure = new TextBox();
            labelQuantity = new Label();
            textBoxQuantity = new TextBox();
            labelExpiryDate = new Label();
            dateTimePickerExpiryDate = new DateTimePicker();
            labelNotificationDate = new Label();
            dateTimePickerNotificationDate = new DateTimePicker();
            labelServiceable = new Label();
            panelServiceable = new Panel();
            radioButtonServiceable = new RadioButton();
            radioButtonUnserviceable = new RadioButton();
            labelRemarks = new Label();
            textBoxRemarks = new TextBox();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelSeparator = new Label();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelType);
            tabPageGeneral.Controls.Add(panelType);
            tabPageGeneral.Controls.Add(labelSerialNumber);
            tabPageGeneral.Controls.Add(textBoxSerialNumber);
            tabPageGeneral.Controls.Add(labelPartNumber);
            tabPageGeneral.Controls.Add(textBoxPartNumber);
            tabPageGeneral.Controls.Add(labelDescription);
            tabPageGeneral.Controls.Add(textBoxDescription);
            tabPageGeneral.Controls.Add(labelShelfLife);
            tabPageGeneral.Controls.Add(textBoxShelfLife);
            tabPageGeneral.Controls.Add(labelMeasure);
            tabPageGeneral.Controls.Add(textBoxMeasure);
            tabPageGeneral.Controls.Add(labelQuantity);
            tabPageGeneral.Controls.Add(textBoxQuantity);
            tabPageGeneral.Controls.Add(labelExpiryDate);
            tabPageGeneral.Controls.Add(dateTimePickerExpiryDate);
            tabPageGeneral.Controls.Add(labelNotificationDate);
            tabPageGeneral.Controls.Add(dateTimePickerNotificationDate);
            tabPageGeneral.Controls.Add(labelServiceable);
            tabPageGeneral.Controls.Add(panelServiceable);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            //
            // labelType
            //
            labelType.Font = Css.WindowsForm.Fonts.RegularFont;
            labelType.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelType.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelType.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelType
            //
            panelType.Location = new Point(labelType.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            panelType.Height = Css.WindowsForm.Constants.DefaultLabelSize.Height;
            panelType.Controls.Add(radioButtonConsumablePart);
            panelType.Controls.Add(radioButtonKit);
            //
            // radioButtonConsumablePart
            //
            radioButtonConsumablePart.Font = Css.WindowsForm.Fonts.RegularFont;
            radioButtonConsumablePart.ForeColor = Css.WindowsForm.Colors.ForeColor;
            radioButtonConsumablePart.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonConsumablePart.Text = "Consumable Part";
            //
            // radioButtonKit
            //
            radioButtonKit.Font = Css.WindowsForm.Fonts.RegularFont;
            radioButtonKit.ForeColor = Css.WindowsForm.Colors.ForeColor;
            radioButtonKit.Location = new Point(radioButtonConsumablePart.Right, 0);
            radioButtonKit.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonKit.Text = "Kit";
            //
            // labelSerialNumber
            //
            labelSerialNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            labelSerialNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelSerialNumber.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelSerialNumber.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelSerialNumber.Text = "Serial Number:";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.BackColor = Color.White;
            textBoxSerialNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxSerialNumber.Location = new Point(labelSerialNumber.Right, labelType.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelPartNumber
            //
            labelPartNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            labelPartNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelPartNumber.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSerialNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelPartNumber.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelPartNumber.Text = "Part Number:";
            labelPartNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxPartNumber
            //
            textBoxPartNumber.BackColor = Color.White;
            textBoxPartNumber.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxPartNumber.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxPartNumber.Location = new Point(labelPartNumber.Right, labelSerialNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelDescription
            //
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDescription.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDescription
            //
            textBoxDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Location = new Point(labelDescription.Right, labelPartNumber.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDescription.Multiline = true;
            textBoxDescription.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            //
            // labelShelfLife
            //
            labelShelfLife.Font = Css.WindowsForm.Fonts.RegularFont;
            labelShelfLife.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelShelfLife.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxDescription.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelShelfLife.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelShelfLife.Text = "Shelf Life:";
            labelShelfLife.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxShelfLife
            //
            textBoxShelfLife.BackColor = Color.White;
            textBoxShelfLife.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxShelfLife.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxShelfLife.Location = new Point(labelShelfLife.Right, textBoxDescription.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelMeasure
            //
            labelMeasure.Font = Css.WindowsForm.Fonts.RegularFont;
            labelMeasure.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelMeasure.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelShelfLife.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelMeasure.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelMeasure.Text = "Measure:";
            labelMeasure.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxMeasure
            //
            textBoxMeasure.BackColor = Color.White;
            textBoxMeasure.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxMeasure.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxMeasure.Location = new Point(labelMeasure.Right, labelShelfLife.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelQuantity
            //
            labelQuantity.Font = Css.WindowsForm.Fonts.RegularFont;
            labelQuantity.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelQuantity.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelMeasure.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelQuantity.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelQuantity.Text = "Quantity:";
            labelQuantity.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxQuantity
            //
            textBoxQuantity.BackColor = Color.White;
            textBoxQuantity.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxQuantity.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxQuantity.Location = new Point(labelQuantity.Right, labelMeasure.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            // 
            // labelExpiryDate
            // 
            labelExpiryDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelExpiryDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelExpiryDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelQuantity.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelExpiryDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelExpiryDate.Text = "Expiry Date:";
            labelExpiryDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerExpiryDate
            //
            dateTimePickerExpiryDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerExpiryDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerExpiryDate.BackColor = Color.White;
            dateTimePickerExpiryDate.Location = new Point(labelExpiryDate.Right, labelQuantity.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerExpiryDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerExpiryDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            // 
            // labelNotificationDate
            // 
            labelNotificationDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelNotificationDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelNotificationDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelExpiryDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelNotificationDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelNotificationDate.Text = "Notification:";
            labelNotificationDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerNotificationDate
            //
            dateTimePickerNotificationDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerNotificationDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerNotificationDate.BackColor = Color.White;
            dateTimePickerNotificationDate.Location = new Point(labelNotificationDate.Right, labelExpiryDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerNotificationDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerNotificationDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelServiceable
            //
            labelServiceable.Font = Css.WindowsForm.Fonts.RegularFont;
            labelServiceable.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelServiceable.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelNotificationDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelServiceable.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelServiceable.Text = "Serviceable:";
            labelServiceable.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelServiceable
            //
            panelServiceable.Location = new Point(labelServiceable.Right, labelNotificationDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            panelServiceable.Height = Css.WindowsForm.Constants.DefaultLabelSize.Height;
            panelServiceable.Controls.Add(radioButtonServiceable);
            panelServiceable.Controls.Add(radioButtonUnserviceable);
            //
            // radioButtonServiceable
            //
            radioButtonServiceable.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonServiceable.Text = "Serviceable";
            //
            // radioButtonUnserviceable
            //
            radioButtonUnserviceable.Location = new Point(radioButtonServiceable.Right, 0);
            radioButtonUnserviceable.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonUnserviceable.Text = "Unserviceable";
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelServiceable.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Location = new Point(labelRemarks.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            //
            // buttonOK
            //
            buttonOK.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonOK.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonOK.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonApply
            //
            buttonApply.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonApply.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonApply.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonApply.Text = "Apply";
            buttonApply.Click += buttonApply_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonCancel.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;


            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
            if (mode == ScreenMode.Add)
                Text = "Add Consumable Part / Kit";
            else
                Text = "Consumable Part / Kit";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            DetailPattern = currentDetail.DetailPattern;
            SerialNumber = currentDetail.SerialNumber;
            PartNumber = currentDetail.PartNumber;
            Description = currentDetail.Description;
            ShelfLife = currentDetail.ShelfLife;
            ExpiryDate = currentDetail.ExpirationDate;
            NotificationDate = currentDetail.NotificationDate;
            Serviceable = currentDetail.Serviceable;
            Remarks = currentDetail.Remarks;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// ƒанные работы обновл€ютс€ по введенным значени€м
        /// </summary>
        private bool SaveData()
        {
            if (SerialNumber == "")
            {
                SimpleBalloon.Show(textBoxSerialNumber, ToolTipIcon.Warning, "Value expected", "Please enter serial number");
                return false;
            }
            if (PartNumber== "")
            {
                SimpleBalloon.Show(textBoxPartNumber, ToolTipIcon.Warning, "Value expected", "Please enter part number");
                return false;
            }
            if (DetailPattern != currentDetail.DetailPattern)
                currentDetail.DetailPattern = DetailPattern;
            if (SerialNumber != currentDetail.SerialNumber)
                currentDetail.SerialNumber = SerialNumber;
            if (PartNumber != currentDetail.PartNumber)
                currentDetail.PartNumber = PartNumber;
            if (Description != currentDetail.Description)
                currentDetail.Description = Description;
            if (ShelfLife != currentDetail.ShelfLife)
                currentDetail.ShelfLife = ShelfLife;
            if (ExpiryDate != currentDetail.ExpirationDate)
                currentDetail.ExpirationDate = ExpiryDate;
            if (NotificationDate != currentDetail.NotificationDate)
                currentDetail.NotificationDate = NotificationDate;
            if (Serviceable != currentDetail.Serviceable)
                currentDetail.Serviceable = Serviceable;
            if (Remarks != currentDetail.Remarks)
                currentDetail.Remarks = Remarks;

            try
            {
                if (mode == ScreenMode.Add)
                {
                    parentStore.Add(currentDetail);
                    mode = ScreenMode.Edit;
                }
                else 
                    currentDetail.Save();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
            tabControl.Size = new Size(ClientSize.Width - Css.WindowsForm.Constants.LEFT_MARGIN - Css.WindowsForm.Constants.RIGHT_MARGIN, ClientSize.Height - Css.WindowsForm.Constants.TOP_MARGIN - Css.WindowsForm.Constants.BOTTOM_MARGIN - Css.WindowsForm.Constants.BUTTON_HEIGHT - Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            panelType.Width =
            textBoxSerialNumber.Width = 
            textBoxPartNumber.Width =
            textBoxDescription.Width =
            textBoxShelfLife.Width = 
            dateTimePickerExpiryDate.Width =
            dateTimePickerNotificationDate.Width =
            panelServiceable.Width =
            textBoxRemarks.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion
        
    }
}