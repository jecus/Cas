using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Форма для отображения настроек Forecast Report
    /// </summary>
    public partial class ForecastReportOptionsForm : Form
    {

        #region Fields

        private readonly BaseDetail parentBaseDetail;
        private DateTime dateAsOf;
        private UtilizationInterval utilizationInterval;
        private DateTime dateAsOfInitial;

        private readonly Label labelDateAsOf;
        private readonly Label labelMonthlyUtilizations;
        private readonly Label labelDescription;
        private readonly Label labelHours;
        private readonly Label labelCycles;
        private readonly DateTimePicker dateTimePickerDateAsOf;
        private readonly TextBox textBoxHours;
        private readonly TextBox textBoxCycles;
        private readonly Button buttonReset;
        private readonly Button buttonOK;
        private readonly Button buttonCancel;
        

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 170;
        private const int LABEL_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 240;
        private const int BUTTON_WIDTH = 90;
        private const int BUTTON_HEIGHT = 25;
        private const int BUTTON_INTERVAL = 10;
        private const int HEIGHT_INTERVAL = 20;
        

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает форму для отображения настроек Forecast Report
        /// </summary>
        /// <param name="parentBaseDetail">Базовый агрегат</param>
        /// <param name="dateAsOf">Дата</param>
        /// <param name="utilizationInterval">Наработка</param>
        public ForecastReportOptionsForm(BaseDetail parentBaseDetail, DateTime dateAsOf, UtilizationInterval utilizationInterval)
        {
            this.parentBaseDetail = parentBaseDetail;
            this.dateAsOf = dateAsOf;
            this.utilizationInterval = utilizationInterval;
            dateAsOfInitial = new DateTime(dateAsOf.Ticks);
            InitializeComponent();
            labelDateAsOf = new Label();
            labelMonthlyUtilizations = new Label();
            labelDescription = new Label();
            labelHours = new Label();
            labelCycles = new Label();
            dateTimePickerDateAsOf = new DateTimePicker();
            textBoxHours = new TextBox();
            textBoxCycles = new TextBox();
            buttonReset = new Button();
            buttonOK = new Button();
            buttonCancel = new Button();
            //
            // labelDateAsOf
            //
            labelDateAsOf.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateAsOf.Location = new Point(MARGIN, MARGIN);
            labelDateAsOf.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDateAsOf.Text = "Date as of:";
            labelDateAsOf.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDateAsOf
            //
            dateTimePickerDateAsOf.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDateAsOf.Location = new Point(labelDateAsOf.Right, MARGIN);
            dateTimePickerDateAsOf.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            dateTimePickerDateAsOf.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateAsOf.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDateAsOf.ValueChanged += dateTimePickerDateAsOf_ValueChanged;
            // 
            // labelMonthlyUtilizations
            // 
            labelMonthlyUtilizations.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelMonthlyUtilizations.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMonthlyUtilizations.Location = new Point(MARGIN, labelDateAsOf.Bottom + HEIGHT_INTERVAL);
            labelMonthlyUtilizations.Size = new Size(LABEL_WIDTH*2, LABEL_HEIGHT);
            labelMonthlyUtilizations.Text = "Monthly utilizations:";
            labelMonthlyUtilizations.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, labelMonthlyUtilizations.Bottom);
            labelDescription.Size = new Size(LABEL_WIDTH + TEXT_BOX_WIDTH, LABEL_HEIGHT);
            labelDescription.Text = "The average utilization is calculated on one month basis";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelHours
            // 
            labelHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHours.Location = new Point(MARGIN, labelDescription.Bottom);
            labelHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHours.Text = "Hours:";
            labelHours.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxHours
            // 
            textBoxHours.BackColor = Color.White;
            textBoxHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxHours.Location = new Point(labelHours.Right, labelDescription.Bottom);
            textBoxHours.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxHours.Validating += textBoxHours_Validating;
            // 
            // labelCycles
            // 
            labelCycles.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCycles.Location = new Point(MARGIN, labelHours.Bottom + HEIGHT_INTERVAL);
            labelCycles.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCycles.Text = "Cycles:";
            labelCycles.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCycles
            // 
            textBoxCycles.BackColor = Color.White;
            textBoxCycles.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCycles.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCycles.Location = new Point(labelHours.Right, labelHours.Bottom + HEIGHT_INTERVAL);
            textBoxCycles.Size = new Size(TEXT_BOX_WIDTH, LABEL_HEIGHT);
            textBoxCycles.Validating += textBoxCycles_Validating;
            //
            // buttonReset
            //
            buttonReset.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonReset.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonReset.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            buttonReset.Text = "Reset";
            buttonReset.Click += buttonReset_Click;
            //
            // buttonOK
            //
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;


            SizeChanged += ForecastReportOptionsForm_SizeChanged;
            Activated += ForecastReportOptionsForm_Activated;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            ClientSize = new Size(2 * MARGIN + LABEL_WIDTH + TEXT_BOX_WIDTH, 2 * MARGIN + LABEL_HEIGHT * 5 + BUTTON_HEIGHT + 3 * HEIGHT_INTERVAL);
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Text = "Forecast Report Options";
            Controls.Add(labelDateAsOf);
            Controls.Add(dateTimePickerDateAsOf);
            Controls.Add(labelMonthlyUtilizations);
            Controls.Add(labelDescription);
            Controls.Add(labelHours);
            Controls.Add(textBoxHours);
            Controls.Add(labelCycles);
            Controls.Add(textBoxCycles);
            Controls.Add(buttonReset);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            dateTimePickerDateAsOf.Value = dateAsOf;
            textBoxHours.Text = utilizationInterval.Hours.ToString();
            textBoxCycles.Text = utilizationInterval.Cycles.ToString();
        }

        #endregion

        public void UpdateInformation(DateTime date, UtilizationInterval utilizationInterval)
        {
            dateAsOf = date;
            this.utilizationInterval = utilizationInterval;
            dateAsOfInitial = new DateTime(date.Ticks);
        }

        #region private void ForecastReportOptionsForm_Activated(object sender, EventArgs e)

        private void ForecastReportOptionsForm_Activated(object sender, EventArgs e)
        {
            UpdateInformation();
        }

        #endregion

        #region private void dateTimePickerDateAsOf_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerDateAsOf_ValueChanged(object sender, EventArgs e)
        {
            dateAsOf = dateTimePickerDateAsOf.Value;
        }

        #endregion
        
        #region private void textBoxHours_Validating(object sender, CancelEventArgs e)

        private void textBoxHours_Validating(object sender, CancelEventArgs e)
        {
            double hours;
            if (Double.TryParse(textBoxHours.Text, out hours) && hours > 0)
                utilizationInterval.Hours = hours;
            else
            {
                MessageBox.Show("Invalid data");
                e.Cancel = true;
            }
        }

        #endregion

        #region private void textBoxCycles_Validating(object sender, CancelEventArgs e)

        private void textBoxCycles_Validating(object sender, CancelEventArgs e)
        {
            Double cycles;
            if (Double.TryParse(textBoxCycles.Text, out cycles) && cycles > 0)
                utilizationInterval.Cycles = cycles;
            else
            {
                MessageBox.Show("Invalid data");
                e.Cancel = true;
            }
        }

        #endregion

        #region private void buttonReset_Click(object sender, EventArgs e)

        private void buttonReset_Click(object sender, EventArgs e)
        {
            dateTimePickerDateAsOf.Value = DateTime.Today;
            UtilizationInterval utilizationInterval = parentBaseDetail.ParentAircraft.UtilizationInterval;
            this.utilizationInterval.Hours = utilizationInterval.Hours;
            this.utilizationInterval.Cycles = utilizationInterval.Cycles;
            textBoxHours.Text = utilizationInterval.Hours.ToString();
            textBoxCycles.Text = utilizationInterval.Cycles.ToString();
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (dateAsOf != dateAsOfInitial)
            {
                if (ApplyClick != null)
                    ApplyClick(dateAsOf, utilizationInterval);
            }
            Close();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region private void ForecastReportOptionsForm_SizeChanged(object sender, EventArgs e)

        private void ForecastReportOptionsForm_SizeChanged(object sender, EventArgs e)
        {
            buttonCancel.Location = new Point(ClientSize.Width - MARGIN - BUTTON_WIDTH, labelCycles.Bottom + HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - BUTTON_INTERVAL - BUTTON_WIDTH, labelCycles.Bottom + HEIGHT_INTERVAL);
            buttonReset.Location = new Point(buttonOK.Left - BUTTON_INTERVAL - BUTTON_WIDTH, labelCycles.Bottom + HEIGHT_INTERVAL);
        }

        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// Обработчик события нажатия кнопки Apply
        /// </summary>
        /// <param name="dateAsOf">Дата</param>
        /// <param name="monthlyUtilizationsLifelength">Наработка</param>
        public delegate void ApplyClickEventHandler(DateTime dateAsOf, UtilizationInterval utilizationInterval);

        #endregion

        #region Events

        /// <summary>
        /// Событие нажатия кнопки Apply
        /// </summary>
        public event ApplyClickEventHandler ApplyClick;

        #endregion

    }
}