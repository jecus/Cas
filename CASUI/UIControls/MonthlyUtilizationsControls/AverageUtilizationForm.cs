using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    /// <summary>
    /// Форма ввода данных среднего использования ВС
    /// </summary>
    public class AverageUtilizationForm : Form
    {

        #region Fields

        private readonly Aircraft currentAircraft;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private RadioButton radioButtonDaily;
        private RadioButton radioButtonMonthly;
        private Label labelType;
        private Label labelHours;
        private Label labelCycles;
        private TextBox textBoxHours;
        private TextBox textBoxCycles;
        private Label labelSeparator;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public TransferRecordForm(AbstractDetail detail, TransferRecord detailRecord)

        /// <summary>
        /// Создает форму для редактирования данных среднего использования
        /// </summary>
        /// <param name="aircraft">ВС</param>
        public AverageUtilizationForm(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public Aircraft.UtilizationIntervalType UtilzationIntervalType

        /// <summary>
        /// Возвращает тип использования
        /// </summary>
        public UtilizationIntervalType UtilzationIntervalType
        {
            get
            {
                if (radioButtonDaily.Checked)
                    return UtilizationIntervalType.DailyUtilization;
                return UtilizationIntervalType.MonthlyUtilization;
            }
        }

        #endregion


        #endregion

        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            radioButtonDaily = new RadioButton();
            radioButtonMonthly = new RadioButton();
            labelType = new Label();
            labelHours = new Label();
            labelCycles = new Label();
            textBoxHours = new TextBox();
            textBoxCycles = new TextBox();
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
            tabPageGeneral.Controls.Add(radioButtonDaily);
            tabPageGeneral.Controls.Add(radioButtonMonthly);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelHours);
            tabPageGeneral.Controls.Add(textBoxHours);
            tabPageGeneral.Controls.Add(labelCycles);
            tabPageGeneral.Controls.Add(textBoxCycles);
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
            // radioButtonDaily
            //
            radioButtonDaily.Font = Css.WindowsForm.Fonts.RegularFont;
            radioButtonDaily.ForeColor = Css.WindowsForm.Colors.ForeColor;
            radioButtonDaily.Location = new Point(labelType.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            radioButtonDaily.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonDaily.Text = "Daily";
            //
            // radioButtonMonthly
            //
            radioButtonMonthly.Font = Css.WindowsForm.Fonts.RegularFont;
            radioButtonMonthly.ForeColor = Css.WindowsForm.Colors.ForeColor;
            radioButtonMonthly.Location = new Point(radioButtonDaily.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            radioButtonMonthly.Size = new Size(Css.WindowsForm.Constants.RADIO_BUTTON_WIDTH_SMALL, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            radioButtonMonthly.Text = "Monthly";
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, radioButtonDaily.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelHours
            //
            labelHours.Font = Css.WindowsForm.Fonts.RegularFont;
            labelHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelHours.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelHours.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelHours.Text = "Hours:";
            labelHours.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxHours
            //
            textBoxHours.BackColor = Color.White;
            textBoxHours.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxHours.Location = new Point(labelHours.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelCycles
            //
            labelCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCycles.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelCycles.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelCycles.Text = "Cycles:";
            labelCycles.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxCycles
            //
            textBoxCycles.BackColor = Color.White;
            textBoxCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCycles.Location = new Point(labelCycles.Right, textBoxHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
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


            Text = "SN " + currentAircraft.SerialNumber + ". Average Utilization";
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(Css.WindowsForm.Constants.DefaultFormSize.Width, 200);
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
            if (currentAircraft.UtilizationInterval.UtilizationIntervalType == UtilizationIntervalType.DailyUtilization)
                radioButtonDaily.Checked = true;
            else
                radioButtonMonthly.Checked = true;
            textBoxHours.Text = currentAircraft.UtilizationInterval.Hours.ToString();
            textBoxCycles.Text = currentAircraft.UtilizationInterval.Cycles.ToString();
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            double eps = 0.00000001;
            double hours;
            double cycles;
            if (!UsefulMethods.CheckDoubleValue(textBoxHours.Text, out hours, "Hours"))
            {
                SimpleBalloon.Show(textBoxHours, ToolTipIcon.Warning, "Incorrect value", "Please enter the float number");
                return false;
            }
            if (!UsefulMethods.CheckDoubleValue(textBoxCycles.Text, out cycles, "Cycles"))
            {
                SimpleBalloon.Show(textBoxCycles, ToolTipIcon.Warning, "Incorrect value", "Please enter the float number");
                return false;
            }
            if (currentAircraft.UtilizationInterval.UtilizationIntervalType != UtilzationIntervalType)
                currentAircraft.UtilizationInterval.UtilizationIntervalType = UtilzationIntervalType;
            if (Math.Abs(currentAircraft.UtilizationInterval.Hours - hours) > eps)
                currentAircraft.UtilizationInterval.Hours = hours;
            if (Math.Abs(currentAircraft.UtilizationInterval.Cycles - cycles) > eps)
                currentAircraft.UtilizationInterval.Cycles = cycles;
            
            try
            {
                currentAircraft.Save(true);
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
            textBoxHours.Width =
                textBoxCycles.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion*/
        
        #endregion

    }
}
