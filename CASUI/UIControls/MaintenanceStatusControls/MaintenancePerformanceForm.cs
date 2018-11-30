using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Messages;
using CASTerms;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    ///  ласс, описывающий форму дл€ добавлени€ и редактировани€ записей типа <see cref="MaintenancePerformance"/>
    /// </summary>
    public class MaintenancePerformanceForm : Form
    {

        #region Fields

        private Label labelCheck;
        private TextBox textBoxCheck;
        private Label labelDate;
        private DateTimePicker dateTimePickerPerformDate;
        private Label labelRemarks;
        private TextBox textBoxRemarks;
        private Button buttonCancel;
        private Button buttonOk;

        private string oldCheckText = "";
        private const int MARGIN = 15;
        private const int LABEL_WIDTH = 130;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 220;
        private const int BUTTONS_INTERVAL = 10;
        private const int HEIGHT_INTERVAL = 10;
        private readonly Size buttonSize = new Size(90, 25);
        //private const int MARGIN_AREA = 5;
        
        #endregion

        #region Constructor

        /// <summary>
        /// —оздаетс€ форма дл€ предоставлени€ данных о выполненных работах <see cref="MaintenancePerformance"/> 
        /// </summary>
        /// <param name="caption">Ќазвание формы</param>
        public MaintenancePerformanceForm(string caption)
        {
            InitializeComponent();
            Text = caption;
        }

        #endregion

        #region Properties

        #region public bool ReadOnly

        /// <summary>
        /// ѕараметр - измен€мы ли данные отображаемые на форме
        /// </summary>
        public bool ReadOnly
        {
            get { return textBoxCheck.ReadOnly; }
            set
            {
                textBoxCheck.ReadOnly = value;
                textBoxRemarks.ReadOnly = value;
                dateTimePickerPerformDate.Enabled = !value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelCheck = new Label();
            textBoxCheck = new TextBox();
            labelDate = new Label();
            dateTimePickerPerformDate = new DateTimePicker();
            labelRemarks = new Label();
            textBoxRemarks = new TextBox();
            buttonOk = new Button();
            buttonCancel = new Button();
            
            // 
            // labelCheck
            // 
            labelCheck.AutoSize = true;
            labelCheck.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCheck.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCheck.Location = new Point(MARGIN, MARGIN);
            labelCheck.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCheck.Text = "Check:";
            // 
            // textBoxCheck
            // 
            textBoxCheck.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCheck.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCheck.Location = new Point(labelCheck.Right, MARGIN);
            textBoxCheck.MaxLength = 20;
            textBoxCheck.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxCheck.LostFocus += new EventHandler(textBoxCheck_LostFocus);
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDate.Location = new Point(MARGIN, labelCheck.Bottom + HEIGHT_INTERVAL);
            labelDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDate.Text = "Perform Date:";
            // 
            // dateTimePickerPerformDate
            // 
            dateTimePickerPerformDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerPerformDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerPerformDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerPerformDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerPerformDate.Location = new Point(labelDate.Right, textBoxCheck.Bottom + HEIGHT_INTERVAL);
            dateTimePickerPerformDate.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelRemarks
            // 
            labelRemarks.AutoSize = true;
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(MARGIN, labelDate.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks:";
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Location = new Point(labelRemarks.Right, dateTimePickerPerformDate.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.MaxLength = 300;
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            textBoxRemarks.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT*5);
            // 
            // buttonOk
            // 
            buttonOk.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOk.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOk.Location = new Point(textBoxRemarks.Right - 2 * buttonSize.Width - BUTTONS_INTERVAL, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            buttonOk.Size = buttonSize;
            buttonOk.Text = "Ok";
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Location = new Point(buttonOk.Right + BUTTONS_INTERVAL, textBoxRemarks.Bottom + HEIGHT_INTERVAL);
            buttonCancel.Size = buttonSize;
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;
            // 
            // MaintenancePerformanceForm
            // 
            AcceptButton = buttonOk;
            CancelButton = buttonCancel;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(2*MARGIN + LABEL_WIDTH + TEXTBOX_WIDTH, 2*MARGIN + 7*LABEL_HEIGHT + 3* HEIGHT_INTERVAL + buttonSize.Height);
            Controls.Add(labelCheck);
            Controls.Add(textBoxCheck);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerPerformDate);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
        }

        #endregion

        #region public void UpdateDisplayedData(MaintenancePerformance performance)

        /// <summary>
        /// ќбновить отображаемые данные согласно переданному выполнению
        /// </summary>
        /// <param name="performance"></param>
        public void UpdateDisplayedData(MaintenancePerformance performance)
        {
            if (performance == null) 
                throw new ArgumentNullException("performance");
            textBoxCheck.Text = performance.CheckTypeExtended + " check";
            textBoxRemarks.Text = performance.Description;
            dateTimePickerPerformDate.Value = performance.RecordDate;
        }

        #endregion

        #region public bool SaveDisplayedData(MaintenancePerformance performance)

        /// <summary>
        /// —охранение отображаемых данных объекту
        /// </summary>
        /// <param name="performance"></param>
        public bool SaveDisplayedData(MaintenancePerformance performance)
        {
            if (performance == null)
                throw new ArgumentNullException("performance");
            if (!CheckTypeOfCheck())
                return false;
            SetCheckType(performance);
            performance.Description = textBoxRemarks.Text;
            performance.RecordDate = dateTimePickerPerformDate.Value;
            return true;
        }

        #endregion

        #region private void SetCheckType(MaintenancePerformance performance)

        private void SetCheckType(MaintenancePerformance performance)
        {
            string type = "";
            string typeExtended = "";
            if (Regex.IsMatch(textBoxCheck.Text[0].ToString(), "(?-i)[A-D]"))
            {
                type += textBoxCheck.Text[0];
                int i = 1;
                while (Regex.IsMatch(textBoxCheck.Text[i].ToString(), "[0-9]"))
                    typeExtended += textBoxCheck.Text[i++];
                typeExtended = type + typeExtended;
            }
            else
            {
                int i = 0;
                while (Regex.IsMatch(textBoxCheck.Text[i].ToString(), "[0-9]"))
                    typeExtended += textBoxCheck.Text[i++];
                typeExtended += textBoxCheck.Text[i];
                type += textBoxCheck.Text[i];
            }
            performance.CheckType = GetCheckByShortName(type);
            performance.CheckTypeExtended = typeExtended;
        }

        #endregion

        #region private MaintenanceCheckType GetCheckByShortName(string shortName)

        private MaintenanceCheckType GetCheckByShortName(string shortName)
        {
            for (int i = 0; i < MaintenanceCheckTypesCollection.Instance.Count; i++)
            {
                if (shortName.ToUpper() == MaintenanceCheckTypesCollection.Instance[i].ShortName.ToUpper())
                    return MaintenanceCheckTypesCollection.Instance[i];
            }
            return null;
        }

        #endregion

        #region private bool CheckTypeOfCheck()

        private bool CheckTypeOfCheck()
        {
            return Regex.IsMatch(textBoxCheck.Text, "^((?-i)[A-D]{1}[0-9]* check)|([0-9]*(?-i)[A-D]{1} check)$");
        }

        #endregion

        #region private void textBoxCheck_LostFocus(object sender, EventArgs e)

        private void textBoxCheck_LostFocus(object sender, EventArgs e)
        {
            if (textBoxCheck.Text != oldCheckText)
            {
                if (textBoxCheck.Text.Length >= 6)
                {
                    if (!Regex.IsMatch(textBoxCheck.Text.Substring(textBoxCheck.Text.Length - 6), "^(?-i) check$"))
                        textBoxCheck.Text = textBoxCheck.Text.Trim() + " check";
                }
                else
                    textBoxCheck.Text = textBoxCheck.Text.Trim() + " check";
                oldCheckText = textBoxCheck.Text;
            }
        }

        #endregion

        #region private void buttonOk_Click(object sender, EventArgs e)

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (dateTimePickerPerformDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Picked date can't be higher then current", (string) new TermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!CheckTypeOfCheck())
            {
                CASMessage.Show(MessageType.InvalidValue, new object[] { "Check" });
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #endregion
    }
}