using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using Auxiliary.Comparers;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    /// <summary>
    /// Форма для редактирования данных полета ВС
    /// </summary>
    public class AircraftFlightForm : Form
    {

        #region Fields

        private readonly Aircraft parentAircraft;
        private readonly AircraftFlight currentAircraftFlight;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelDate;
        private Label labelFlightNo;
        private Label labelDirection;
        private Label labelReference;
        private Label labelFlightTime;
        private Label labelFlightTimeDash;
        private DateTimePicker dateTimePickerDate;
        private TextBox textBoxFlightNo;
        private TextBox textBoxDirectionFrom;
        private Label labelDirectionDash;
        private TextBox textBoxDirectionTo;
        private TextBox textBoxReference;
        private TextBox textBoxFlightTimeFrom;
        private TextBox textBoxFlightTimeTo;
        private TextBox textBoxFlightTimePeriod;
        private CheckBox checkBoxCorrect;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public AircraftFlightForm(AircraftFlight aircraftFlight)

        /// <summary>
        /// Создает форму для редактирования данных полета ВС
        /// </summary>
        /// <param name="aircraftFlight">Полет ВС</param>
        public AircraftFlightForm(AircraftFlight aircraftFlight)
        {
            currentAircraftFlight = aircraftFlight;
            mode = ScreenMode.Edit;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public AircraftFlightForm(ATLB atlb)

        /// <summary>
        /// Создает форму для редактирования данных полета ВС
        /// </summary>
        /// <param name="aircraft">Бортовой журнал ВС</param>
        public AircraftFlightForm(Aircraft aircraft)
        {
            parentAircraft = aircraft;
            currentAircraftFlight = aircraft.ProposeNextFlight();
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Properties

        #region public DateTime Date

        /// <summary>
        /// Возвращает или устанавливает дату
        /// </summary>
        public DateTime Date
        {
            get
            {
                return dateTimePickerDate.Value;
            }
            set
            {
                dateTimePickerDate.Value = value;
            }
        }

        #endregion

        #region public string FlightNo

        /// <summary>
        /// Возвращает или устанавливает номер полета
        /// </summary>
        public string FlightNo
        {
            get
            {
                return textBoxFlightNo.Text;
            }
            set
            {
                textBoxFlightNo.Text = value;
            }
        }

        #endregion

        #region public string DirectionFrom

        /// <summary>
        /// Возвращает или устанавливает точку вылета
        /// </summary>
        public string DirectionFrom
        {
            get
            {
                return textBoxDirectionFrom.Text;
            }
            set
            {
                textBoxDirectionFrom.Text = value;
            }
        }

        #endregion

        #region public string DirectionTo

        /// <summary>
        /// Возвращает или устанавливает точку прибытия
        /// </summary>
        public string DirectionTo
        {
            get
            {
                return textBoxDirectionTo.Text;
            }
            set
            {
                textBoxDirectionTo.Text = value;
            }
        }

        #endregion

        #region public string Reference

        /// <summary>
        /// Возвращает или устанавливает Reference
        /// </summary>
        public string Reference
        {
            get
            {
                return textBoxReference.Text;
            }
            set
            {
                textBoxReference.Text = value;
            }
        }

        #endregion

        #region public string FlightTimeFrom

        /// <summary>
        /// Возвращает или устанавливает время вылета
        /// </summary>
        public string FlightTimeFrom
        {
            get
            {
                return textBoxFlightTimeFrom.Text;
            }
            set
            {
                textBoxFlightTimeFrom.Text = value;
            }
        }

        #endregion

        #region public string FlightTimeTo

        /// <summary>
        /// Возвращает или устанавливает время прибытия
        /// </summary>
        public string FlightTimeTo
        {
            get
            {
                return textBoxFlightTimeTo.Text;
            }
            set
            {
                textBoxFlightTimeTo.Text = value;
            }
        }

        #endregion

        #region public string FlightTimePeriod

        /// <summary>
        /// Возвращает или устанавливает время полета
        /// </summary>
        public string FlightTimePeriod
        {
            get
            {
                return textBoxFlightTimePeriod.Text;
            }
            set
            {
                textBoxFlightTimePeriod.Text = value;
            }
        }

        #endregion

        #region public bool Correct

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее что данные были введены верно
        /// </summary>
        public bool Correct
        {
            get
            {
                return checkBoxCorrect.Checked;
            }
            set
            {
                checkBoxCorrect.Checked = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelDate = new Label();
            labelFlightNo = new Label();
            labelDirection = new Label();
            labelReference = new Label();
            labelFlightTime = new Label();
            labelFlightTimeDash = new Label();
            dateTimePickerDate = new DateTimePicker();
            textBoxFlightNo = new TextBox();
            textBoxDirectionFrom = new TextBox();
            labelDirectionDash = new Label();
            textBoxDirectionTo = new TextBox();
            textBoxReference = new TextBox();
            textBoxFlightTimeFrom = new TextBox();
            textBoxFlightTimeTo = new TextBox();
            textBoxFlightTimePeriod = new TextBox();
            checkBoxCorrect = new CheckBox();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDate.BackColor = Color.White;
            dateTimePickerDate.Location = new Point(labelDate.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelFlightNo
            //
            labelFlightNo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFlightNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFlightNo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelFlightNo.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFlightNo.Text = "Flight No:";
            labelFlightNo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFlightNo
            //
            textBoxFlightNo.BackColor = Color.White;
            textBoxFlightNo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightNo.Location = new Point(labelFlightNo.Right, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelDirection
            //
            labelDirection.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDirection.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDirection.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelFlightNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDirection.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDirection.Text = "Direction:";
            labelDirection.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDirectionFrom
            //
            textBoxDirectionFrom.BackColor = Color.White;
            textBoxDirectionFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDirectionFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDirectionFrom.Location = new Point(labelDirection.Right, labelFlightNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDirectionFrom.Width = Css.WindowsForm.Constants.TEXT_BOX_WIDTH_SMALL;
            //
            // labelDirectionDash
            //
            labelDirectionDash.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDirectionDash.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDirectionDash.Location = new Point(textBoxDirectionFrom.Right, labelFlightNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDirectionDash.Size = new Size(10, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelDirectionDash.Text = "-";
            labelDirectionDash.TextAlign = ContentAlignment.MiddleCenter;
            //
            // textBoxDirectionTo
            //
            textBoxDirectionTo.BackColor = Color.White;
            textBoxDirectionTo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDirectionTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDirectionTo.Location = new Point(labelDirectionDash.Right, labelFlightNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDirectionTo.Width = Css.WindowsForm.Constants.TEXT_BOX_WIDTH_SMALL;
            // 
            // labelReference
            // 
            labelReference.Font = Css.WindowsForm.Fonts.RegularFont;
            labelReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelReference.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelDirection.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelReference.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelReference.Text = "Reference:";
            labelReference.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxReference
            //
            textBoxReference.BackColor = Color.White;
            textBoxReference.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxReference.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxReference.Location = new Point(labelReference.Right, labelDirection.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelFlightTime
            //
            labelFlightTime.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFlightTime.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFlightTime.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelFlightTime.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFlightTime.Text = "Flight Time:";
            labelFlightTime.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFlightTimeFrom
            //
            textBoxFlightTimeFrom.BackColor = Color.White;
            textBoxFlightTimeFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightTimeFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightTimeFrom.Location = new Point(labelFlightTime.Right, labelReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxFlightTimeFrom.Width = Css.WindowsForm.Constants.TEXT_BOX_WIDTH_SMALL;
            textBoxFlightTimeFrom.LostFocus += textBoxFlightTime_LostFocus;
            //
            // labelFlightTimeDash
            //
            labelFlightTimeDash.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFlightTimeDash.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFlightTimeDash.Location = new Point(textBoxFlightTimeFrom.Right, labelReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelFlightTimeDash.Size = new Size(10, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelFlightTimeDash.Text = "-";
            labelFlightTimeDash.TextAlign = ContentAlignment.MiddleCenter;
            //
            // textBoxFlightTimeTo
            //
            textBoxFlightTimeTo.BackColor = Color.White;
            textBoxFlightTimeTo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightTimeTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightTimeTo.Location = new Point(labelFlightTimeDash.Right, labelReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxFlightTimeTo.Width = Css.WindowsForm.Constants.TEXT_BOX_WIDTH_SMALL;
            textBoxFlightTimeTo.LostFocus += textBoxFlightTime_LostFocus;
            //
            // textBoxFlightTimePeriod
            //
            textBoxFlightTimePeriod.ReadOnly = true;
            textBoxFlightTimePeriod.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightTimePeriod.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightTimePeriod.Location = new Point(textBoxFlightTimeTo.Right + 10, labelReference.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxFlightTimePeriod.Width = Css.WindowsForm.Constants.TEXT_BOX_WIDTH_SMALL;
            //
            // checkBoxCorrect
            //
            checkBoxCorrect.Font = Css.WindowsForm.Fonts.RegularFont;
            checkBoxCorrect.ForeColor = Css.WindowsForm.Colors.ForeColor;
            checkBoxCorrect.Location = new Point(labelFlightTime.Right, labelFlightTime.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            checkBoxCorrect.TextAlign = ContentAlignment.MiddleLeft;
            checkBoxCorrect.Text = "Correct";
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


            if (parentAircraft != null)
                Text = parentAircraft.RegistrationNumber + ". New Aircraft Flight";
            else
                Text = currentAircraftFlight.Aircraft.RegistrationNumber + ". " + currentAircraftFlight.FlightNo;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(dateTimePickerDate);
            tabPageGeneral.Controls.Add(labelFlightNo);
            tabPageGeneral.Controls.Add(textBoxFlightNo);
            tabPageGeneral.Controls.Add(labelDirection);
            tabPageGeneral.Controls.Add(textBoxDirectionFrom);
            tabPageGeneral.Controls.Add(labelDirectionDash);
            tabPageGeneral.Controls.Add(textBoxDirectionTo);
            tabPageGeneral.Controls.Add(labelReference);
            tabPageGeneral.Controls.Add(textBoxReference);
            tabPageGeneral.Controls.Add(labelFlightTime);
            tabPageGeneral.Controls.Add(textBoxFlightTimeFrom);
            tabPageGeneral.Controls.Add(labelFlightTimeDash);
            tabPageGeneral.Controls.Add(textBoxFlightTimeTo);
            tabPageGeneral.Controls.Add(textBoxFlightTimePeriod);
            tabPageGeneral.Controls.Add(checkBoxCorrect);

            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
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
            Date = currentAircraftFlight.FlightDate;
            FlightNo = currentAircraftFlight.FlightNo;
            DirectionFrom = currentAircraftFlight.StationFrom;
            DirectionTo = currentAircraftFlight.StationTo;
            Reference = currentAircraftFlight.Reference;
            FlightTimeFrom = UsefulMethods.TimeToString(currentAircraftFlight.TakeOffTime);
            FlightTimeTo = UsefulMethods.TimeToString(currentAircraftFlight.LdgTime);
            FlightTimePeriod = UsefulMethods.TimeToString(currentAircraftFlight.FlightTime);
            Correct = currentAircraftFlight.Correct;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            TimeSpan timeFrom;
            TimeSpan timeTo;
            if (FlightNo == "")
            {
                SimpleBalloon.Show(textBoxFlightNo, ToolTipIcon.Warning, "Value expected", "Please enter the Flight No");
                return false;
            }
            if (DirectionFrom == "")
            {
                SimpleBalloon.Show(textBoxDirectionFrom, ToolTipIcon.Warning, "Value expected", "Please enter the Direction (from)");
                return false;
            }
            if (DirectionTo == "")
            {
                SimpleBalloon.Show(textBoxDirectionTo, ToolTipIcon.Warning, "Value expected", "Please enter the Direction (to)");
                return false;
            }
            if (!TimeSpan.TryParse(textBoxFlightTimeFrom.Text, out timeFrom))
            {
                SimpleBalloon.Show(textBoxFlightTimeFrom, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH.MM");
                return false;
            }
            if (!TimeSpan.TryParse(textBoxFlightTimeTo.Text, out timeTo))
            {
                SimpleBalloon.Show(textBoxFlightTimeTo, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH.MM");
                return false;
            }

            if (currentAircraftFlight.FlightDate != Date)
                currentAircraftFlight.FlightDate = Date;
            if (currentAircraftFlight.FlightNo != FlightNo)
                currentAircraftFlight.FlightNo = FlightNo;
            if (currentAircraftFlight.StationFrom != DirectionFrom)
                currentAircraftFlight.StationFrom = DirectionFrom;
            if (currentAircraftFlight.StationTo != DirectionTo)
                currentAircraftFlight.StationTo = DirectionTo;
            if (currentAircraftFlight.Reference != Reference)
                currentAircraftFlight.Reference = Reference;
            if (currentAircraftFlight.TakeOffTime != timeFrom)
                currentAircraftFlight.TakeOffTime =  timeFrom;
            if (currentAircraftFlight.LdgTime != timeTo)
                currentAircraftFlight.LdgTime =  timeTo;
            if (currentAircraftFlight.Correct != Correct)
                currentAircraftFlight.Correct = Correct;
            try
            {

                if (mode == ScreenMode.Add)
                {
                    parentAircraft.GetATLB(Date).AddFlight(currentAircraftFlight);
                    mode = ScreenMode.Edit;
                }
                else
                    currentAircraftFlight.Save(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

  


        #region private void textBoxFlightTime_LostFocus(object sender, EventArgs e)

        private void textBoxFlightTime_LostFocus(object sender, EventArgs e)
        {
            TimeSpan time1;
            TimeSpan time2;
            if (TimeSpan.TryParse(textBoxFlightTimeFrom.Text, out time1) && TimeSpan.TryParse(textBoxFlightTimeTo.Text, out time2))
                FlightTimePeriod = UsefulMethods.TimeToString(time2 - time1);
            else
                FlightTimePeriod = "";
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
            dateTimePickerDate.Width = 
                textBoxFlightNo.Width =
                textBoxReference.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion
        
    }
}