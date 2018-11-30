using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.Core.Types.Aircrafts.Parts;

namespace CAS.UI.UIControls.ComplianceControls
{
    /// <summary>
    /// Форма для редактирования и добавления свойств ActualStateRecord
    /// </summary>
    public class ActualStateRecordForm : Form
    {

        #region Fields

        private readonly AbstractDetail parentDetail;
        private readonly List<Detail> parentDetails = new List<Detail>();
        private readonly ActualStateRecord currentRecord;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelComponent;
        private Label labelDate;
        private Label labelFlightHours;
        private Label labelFlightCycles;
        private Label labelRemarks;
        private TextBox textBoxComponent;
        private DateTimePicker dateTimePickerDate;
        private TextBox textBoxFlightHours;
        private TextBox textBoxFlightCycles;
        private TextBox textBoxRemarks;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public ActualStateRecordForm(AbstractDetail detail)

        /// <summary>
        /// Создает форму для добавления ActualStateRecord
        /// </summary>
        /// <param name="detail">Агрегат, к которому добавляется запись</param>
        public ActualStateRecordForm(AbstractDetail detail)
        {
            mode = ScreenMode.Add;
            parentDetail =  detail;
            currentRecord = new ActualStateRecord();
            InitializeComponent();
        }

        #endregion

        #region public ActualStateRecordForm(AbstractDetail detail)

        /// <summary>
        /// Создает форму для добавления ActualStateRecord
        /// </summary>
        /// <param name="details">Агрегаты, к которым добавляются записи</param>
        public ActualStateRecordForm(List<Detail> details)
        {
            mode = ScreenMode.Add;
            parentDetails = details;
            currentRecord = new ActualStateRecord();
            InitializeComponent();
        }

        #endregion

        #region public ActualStateRecordForm(ActualStateRecord detailRecord)

        /// <summary>
        /// Создает форму для редактирования ActualStateRecord
        /// </summary>
        /// <param name="detailRecord">Актуальное состояние агрегата</param>
        public ActualStateRecordForm(ActualStateRecord detailRecord)
        {
            mode = ScreenMode.Edit;
            parentDetail = (AbstractDetail)detailRecord.Parent;
            currentRecord = detailRecord;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelComponent = new Label();
            labelDate = new Label();
            labelFlightHours = new Label();
            labelFlightCycles = new Label();
            labelRemarks = new Label();
            textBoxComponent = new TextBox();
            dateTimePickerDate = new DateTimePicker();
            textBoxFlightHours = new TextBox();
            textBoxFlightCycles = new TextBox();
            textBoxRemarks = new TextBox();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            labelSeparator = new Label();
            labelSeparator2 = new Label();
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
            tabPageGeneral.Controls.Add(labelComponent);
            tabPageGeneral.Controls.Add(textBoxComponent);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(dateTimePickerDate);
            tabPageGeneral.Controls.Add(labelFlightHours);
            tabPageGeneral.Controls.Add(textBoxFlightHours);
            tabPageGeneral.Controls.Add(labelFlightCycles);
            tabPageGeneral.Controls.Add(textBoxFlightCycles);
            tabPageGeneral.Controls.Add(labelSeparator2);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            //
            // labelComponent
            //
            labelComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            labelComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelComponent.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelComponent.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelComponent.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxComponent
            //
            textBoxComponent.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxComponent.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxComponent.Location = new Point(labelComponent.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxComponent.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxComponent.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDate.BackColor = Color.White;
            dateTimePickerDate.Location = new Point(labelDate.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelFlightHours
            //
            labelFlightHours.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFlightHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFlightHours.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelFlightHours.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFlightHours.Text = "Flight Hours:";
            labelFlightHours.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFlightHours
            //
            textBoxFlightHours.BackColor = Color.White;
            textBoxFlightHours.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightHours.Location = new Point(labelFlightHours.Right, dateTimePickerDate.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxFlightHours.Text = "00:00";
            //
            // labelFlightCycles
            //
            labelFlightCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            labelFlightCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelFlightCycles.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxFlightHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelFlightCycles.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelFlightCycles.Text = "Flight Cycles:";
            labelFlightCycles.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxFlightCycles
            //
            textBoxFlightCycles.BackColor = Color.White;
            textBoxFlightCycles.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxFlightCycles.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxFlightCycles.Location = new Point(labelFlightHours.Right, textBoxFlightHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxFlightCycles.Text = "0";
            //
            // labelSeparator
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxFlightCycles.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            textBoxRemarks.Location = new Point(labelFlightHours.Right, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
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

            if (parentDetail != null)
                Text = "SN " + parentDetail.SerialNumber + ". Actual State record";
            else 
                Text = "Set Actual State records";
            if (parentDetail is BaseDetail)
                textBoxComponent.Text = parentDetail.ToString();
            else if (parentDetail != null)
                textBoxComponent.Text = "S/N " + parentDetail.SerialNumber;
            else
                textBoxComponent.Text = parentDetails.Count + " items";
            if (parentDetail is AircraftFrameReal || parentDetail is AircraftFrame)
                labelComponent.Text = "Aircraft:";
            else
                labelComponent.Text = "Component:";

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
            dateTimePickerDate.Value = currentRecord.RecordDate;
            textBoxFlightHours.Text = UsefulMethods.HoursToString(currentRecord.Lifelength.Hours);
            textBoxFlightCycles.Text = currentRecord.Lifelength.Cycles.ToString();
            textBoxRemarks.Text = currentRecord.Description;
        }

        #endregion

        #region private void SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            TimeSpan hours;
            int cycles;
            if (!UsefulMethods.ParseTime(textBoxFlightHours.Text, out hours))
            {
                SimpleBalloon.Show(textBoxFlightHours, ToolTipIcon.Warning, "Incorrect time format", "Please enter the time period in the following format:\nHH:MM");
                return false;
            }
            if (!int.TryParse(textBoxFlightCycles.Text, out cycles))
            {
                SimpleBalloon.Show(textBoxFlightCycles, ToolTipIcon.Warning, "Incorrect value", "Please enter integer value");
                return false;
            }
            if (currentRecord.RecordDate != dateTimePickerDate.Value)
                currentRecord.RecordDate = dateTimePickerDate.Value;
            if (currentRecord.Lifelength.Hours.ToString() != textBoxFlightHours.Text ||
                currentRecord.Lifelength.Cycles.ToString() != textBoxFlightCycles.Text)
                currentRecord.Lifelength = new Lifelength(new TimeSpan(0), cycles, hours);
            if (currentRecord.Description != textBoxRemarks.Text)
                currentRecord.Description = textBoxRemarks.Text;
            try
            {

                if (mode == ScreenMode.Add)
                {
                    if (parentDetail != null)
                        parentDetail.AddRecord(currentRecord);
                    else
                    {
                        for (int i = 0; i < parentDetails.Count; i++ )
                            parentDetails[i].AddRecord(new ActualStateRecord(currentRecord));
                    }
                    mode = ScreenMode.Edit;
                }
                else
                    currentRecord.Save(true);
                if (RecordChanged != null)
                    RecordChanged(this, EventArgs.Empty);
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
            textBoxComponent.Width =
                dateTimePickerDate.Width = 
                textBoxFlightHours.Width = 
                textBoxFlightCycles.Width =
                textBoxRemarks.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width =
            labelSeparator2.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion

        #region Events

        /// <summary>
        /// Событие изменения записи
        /// </summary>
        public event EventHandler RecordChanged;

        #endregion
    }
}