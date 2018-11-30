using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DetailsControls
{

    ///<summary>
    /// Элемент управления, использующийся для задания отдельной информации Compliance/Performance при добавлении агрегата
    ///</summary>
    public class DetailAddCompliancePerformanceControl : UserControl
    {
        
        #region Fields

        private readonly Aircraft currentAircraft;

        private const int MARGIN = 10;
        private const int LIFELENGTH_VIEWER_WIDTH = 350;
        private const int DATE_TIME_PICKER_WIDTH = 250;
        private const int LABEL_WIDTH = LIFELENGTH_VIEWER_WIDTH - DATE_TIME_PICKER_WIDTH;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int LABEL_HEIGHT = 25;
        private const int WIDTH_INTERVAL = 400 + MARGIN;
        private const int WIDTH_INTERVAL_SECOND = 800 + MARGIN;
        
        private Label labelWorkType;
        private ComboBox comboBoxWorkType;
        private Label labelInterval;
        private LifelengthViewer lifelengthViewerInterval;
        private Label labelNotify;
        private LifelengthViewer lifelengthViewerNotify;
        private CheckBox checkBoxLastCompliance;
        private Label labelDate;
        private DateTimePicker dateTimePickerDate;
        private Label labelComponentTSNCSN;
        private LifelengthViewer lifelengthViewerComponentLastPerformance;
        private Label labelAircraftTSNCSN;
        private LifelengthViewer lifelengthViewerAircraftLastPerformance;
        private Label labelNext;
        private LifelengthViewer lifelengthViewerNext;
        private Label labelRemains;
        private LifelengthViewer lifelengthViewerRemains;
        private LinkLabel linkLabelClear;
        private Delimiter delimiter1;
        private Delimiter delimiter2;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления, использующийся для задания отдельной информации Compliance/Performance при добавлении агрегата
        /// </summary>
        /// <param name="aircraft">ВС</param>
        public DetailAddCompliancePerformanceControl(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region Propeties

        #region public bool AddActualStateRecordToAircraft

        /// <summary>
        /// Добавлять ли ActualStareRecord к ВС
        /// </summary>
        public bool AddActualStateRecordToAircraft
        {
            get
            {
                return lifelengthViewerAircraftLastPerformance.Modified;
            }
        }

        #endregion

        #region public bool AddActualStateRecordToDetail

        /// <summary>
        /// Добавлять ли ActualStareRecord к агрегату
        /// </summary>
        public bool AddActualStateRecordToDetail
        {
            get
            {
                return lifelengthViewerComponentLastPerformance.Modified;
            }
        }

        #endregion

        #region public Lifelength AircraftLastPerformance

        /// <summary>
        /// Возвращает наработку Last Compliance ВС
        /// </summary>
        public Lifelength AircraftLastPerformance
        {
            get
            {
                return lifelengthViewerAircraftLastPerformance.Lifelength;
            }
        }

        #endregion

        #region public Lifelength ComponentLastPerformance

        /// <summary>
        /// Возвращает наработку Last Compliance агрегата
        /// </summary>
        public Lifelength ComponentLastPerformance
        {
            get
            {
                return lifelengthViewerComponentLastPerformance.Lifelength;
            }
        }

        #endregion

        #region public DateTime RecordDate

        /// <summary>
        /// Возвращает дату ActualStateRecord
        /// </summary>
        public DateTime RecordDate
        {
            get
            {
                return dateTimePickerDate.Value;
            }
        }

        #endregion

        #region public Lifelength Interval

        /// <summary>
        /// Возвращает интервал обслуживания
        /// </summary>
        public Lifelength Interval
        {
            get
            {
                return lifelengthViewerInterval.Lifelength;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void InitializeComponent()

        private void InitializeComponent()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            
            labelWorkType = new Label();
            comboBoxWorkType = new ComboBox();
            labelInterval = new Label();
            lifelengthViewerInterval = new LifelengthViewer();
            labelNotify = new Label();
            lifelengthViewerNotify = new LifelengthViewer();
            checkBoxLastCompliance = new CheckBox();
            labelDate = new Label();
            dateTimePickerDate = new DateTimePicker();
            labelComponentTSNCSN = new Label();
            lifelengthViewerComponentLastPerformance = new LifelengthViewer();
            labelAircraftTSNCSN = new Label();
            lifelengthViewerAircraftLastPerformance = new LifelengthViewer();
            labelNext = new Label();
            lifelengthViewerNext = new LifelengthViewer();
            labelRemains = new Label();
            lifelengthViewerRemains = new LifelengthViewer();
            linkLabelClear = new LinkLabel();
            delimiter1 = new Delimiter();
            delimiter2 = new Delimiter();
            // 
            // labelWorkType
            // 
            labelWorkType.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWorkType.Location = new Point(MARGIN, MARGIN);
            labelWorkType.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelWorkType.Text = "Work Type:";
            labelWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxWorkType
            // 
            comboBoxWorkType.BackColor = Color.White;
            comboBoxWorkType.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxWorkType.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            comboBoxWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxWorkType.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            comboBoxWorkType.Location = new Point(labelWorkType.Right, MARGIN);
            // 
            // labelInterval
            // 
            labelInterval.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInterval.Location = new Point(MARGIN, labelWorkType.Bottom + HEIGHT_INTERVAL);
            labelInterval.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelInterval.Text = "Repeat Interval:";
            labelInterval.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerInterval
            //
            lifelengthViewerInterval.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerInterval.ShowLeftHeader = false;
            lifelengthViewerInterval.LeftHeaderWidth = 0;
            lifelengthViewerInterval.ShowMinutes = false;
            lifelengthViewerInterval.Location = new Point(MARGIN, labelInterval.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerInterval.LifelengthChanged += lifelengthViewerInterval_LifelengthChanged;
            // 
            // labelNotify
            // 
            labelNotify.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelNotify.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotify.Location = new Point(MARGIN, lifelengthViewerInterval.Bottom + HEIGHT_INTERVAL);
            labelNotify.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelNotify.Text = "Notify:";
            labelNotify.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerNotify
            //
            lifelengthViewerNotify.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerNotify.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNotify.ShowLeftHeader = false;
            lifelengthViewerNotify.LeftHeaderWidth = 0;
            lifelengthViewerNotify.ShowMinutes = false;
            lifelengthViewerNotify.Location = new Point(MARGIN, labelNotify.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            //
            // delimiter1
            //
            delimiter1.Orientation = DelimiterOrientation.Vertical;
            delimiter1.Location = new Point(WIDTH_INTERVAL - (WIDTH_INTERVAL - MARGIN - LABEL_WIDTH - DATE_TIME_PICKER_WIDTH) / 2, MARGIN);
            delimiter1.Height = 265;
            //
            // checkBoxLastCompliance
            //
            checkBoxLastCompliance.Cursor = Cursors.Hand;
            checkBoxLastCompliance.FlatStyle = FlatStyle.Flat;
            checkBoxLastCompliance.Font = Css.SimpleLink.Fonts.SmallFont;
            checkBoxLastCompliance.ForeColor = Css.SimpleLink.Colors.LinkColor;
            checkBoxLastCompliance.Location = new Point(WIDTH_INTERVAL, MARGIN);
            checkBoxLastCompliance.Size = new Size(LABEL_WIDTH*2, LABEL_HEIGHT);
            checkBoxLastCompliance.Text = "Last Compliance";
            checkBoxLastCompliance.CheckedChanged += checkBoxLastCompliance_CheckedChanged;
            // 
            // labelDate
            // 
            labelDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDate.Location = new Point(WIDTH_INTERVAL, checkBoxLastCompliance.Bottom + HEIGHT_INTERVAL);
            labelDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerDate       
            // 
            dateTimePickerDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDate.CalendarForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerDate.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            dateTimePickerDate.Location = new Point(labelDate.Right, checkBoxLastCompliance.Bottom + HEIGHT_INTERVAL);
            dateTimePickerDate.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerDate.ValueChanged += dateTimePickerDate_ValueChanged;
            dateTimePickerDate.Enabled = false;
            // 
            // labelComponentTSNCSN
            // 
            labelComponentTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelComponentTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComponentTSNCSN.Location = new Point(WIDTH_INTERVAL, labelDate.Bottom + HEIGHT_INTERVAL);
            labelComponentTSNCSN.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelComponentTSNCSN.Text = "Component TSN/CSN:";
            labelComponentTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerComponentLastPerformance
            //
            lifelengthViewerComponentLastPerformance.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerComponentLastPerformance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerComponentLastPerformance.ShowLeftHeader = false;
            lifelengthViewerComponentLastPerformance.LeftHeaderWidth = 0;
            lifelengthViewerComponentLastPerformance.ShowMinutes = false;
            lifelengthViewerComponentLastPerformance.Location = new Point(WIDTH_INTERVAL, labelComponentTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerComponentLastPerformance.LifelengthChanged += lifelengthViewerComponentLastPerformance_LifelengthChanged;
            lifelengthViewerComponentLastPerformance.ReadOnly = true;
            // 
            // labelAircraftTSNCSN
            // 
            labelAircraftTSNCSN.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelAircraftTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAircraftTSNCSN.Location = new Point(WIDTH_INTERVAL, lifelengthViewerComponentLastPerformance.Bottom + HEIGHT_INTERVAL);
            labelAircraftTSNCSN.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelAircraftTSNCSN.Text = "Aircraft TSN/CSN:";
            labelAircraftTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerAircraftLastPerformance
            //
            lifelengthViewerAircraftLastPerformance.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerAircraftLastPerformance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerAircraftLastPerformance.ShowLeftHeader = false;
            lifelengthViewerAircraftLastPerformance.LeftHeaderWidth = 0;
            lifelengthViewerAircraftLastPerformance.ShowMinutes = false;
            lifelengthViewerAircraftLastPerformance.Location = new Point(WIDTH_INTERVAL, labelAircraftTSNCSN.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerAircraftLastPerformance.ReadOnly = true;
            //
            // delimiter2
            //
            delimiter2.Orientation = DelimiterOrientation.Vertical;
            delimiter2.Location = new Point(WIDTH_INTERVAL_SECOND - (WIDTH_INTERVAL_SECOND - WIDTH_INTERVAL - LABEL_WIDTH - DATE_TIME_PICKER_WIDTH) / 2, MARGIN);
            delimiter2.Height = 265;
            // 
            // labelNext
            // 
            labelNext.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelNext.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNext.Location = new Point(WIDTH_INTERVAL_SECOND, MARGIN);
            labelNext.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelNext.Text = "Next (Component TSN/CSN):";
            labelNext.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerNext
            //
            lifelengthViewerNext.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerNext.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNext.ShowLeftHeader = false;
            lifelengthViewerNext.LeftHeaderWidth = 0;
            lifelengthViewerNext.ShowMinutes = false;
            lifelengthViewerNext.Location = new Point(WIDTH_INTERVAL_SECOND, labelNext.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerNext.ReadOnly = true;
            // 
            // labelRemains
            // 
            labelRemains.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemains.Location = new Point(WIDTH_INTERVAL_SECOND, lifelengthViewerNext.Bottom + HEIGHT_INTERVAL);
            labelRemains.Size = new Size(LIFELENGTH_VIEWER_WIDTH, LABEL_HEIGHT);
            labelRemains.Text = "Remains:";
            labelRemains.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lifelengthViewerRemains
            //
            lifelengthViewerRemains.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            lifelengthViewerRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerRemains.ShowLeftHeader = false;
            lifelengthViewerRemains.LeftHeaderWidth = 0;
            lifelengthViewerRemains.ShowMinutes = false;
            lifelengthViewerRemains.Location = new Point(WIDTH_INTERVAL_SECOND, labelRemains.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            lifelengthViewerRemains.ReadOnly = true;
            //
            // linkLabelClear
            //
            linkLabelClear.Font = Css.SimpleLink.Fonts.Font;
            linkLabelClear.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelClear.Text = "Clear";
            linkLabelClear.Location = new Point(lifelengthViewerRemains.Right - linkLabelClear.Width, lifelengthViewerAircraftLastPerformance.Bottom - linkLabelClear.Height);
            linkLabelClear.TextAlign = ContentAlignment.BottomRight;
            linkLabelClear.LinkClicked += linkLabelClear_LinkClicked;
            // 
            // DetailGeneralInformationControl
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(labelWorkType);
            Controls.Add(comboBoxWorkType);
            Controls.Add(labelInterval);
            Controls.Add(lifelengthViewerInterval);
            Controls.Add(labelNotify);
            Controls.Add(lifelengthViewerNotify);
            Controls.Add(delimiter1);
            Controls.Add(checkBoxLastCompliance);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelComponentTSNCSN);
            Controls.Add(lifelengthViewerComponentLastPerformance);
            Controls.Add(labelAircraftTSNCSN);
            Controls.Add(lifelengthViewerAircraftLastPerformance);
            Controls.Add(delimiter2);
            Controls.Add(labelNext);
            Controls.Add(lifelengthViewerNext);
            Controls.Add(labelRemains);
            Controls.Add(lifelengthViewerRemains);
            Controls.Add(linkLabelClear);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            List<DirectiveType> directiveTypes = new List<DirectiveType>(DirectiveTypeCollection.Instance.GetDetailDirectiveTypes());
            for (int i = 0; i < directiveTypes.Count; i++ )
                comboBoxWorkType.Items.Add(directiveTypes[i]);
            if (comboBoxWorkType.Items.Count > 0)
                comboBoxWorkType.SelectedIndex = 0;
            dateTimePickerDate.Value = DateTime.Now;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            comboBoxWorkType.SelectedIndex = 0;
            lifelengthViewerInterval.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerInterval.Modified = false;
            lifelengthViewerNotify.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerNotify.Modified = false;
            checkBoxLastCompliance.Checked = false;
            dateTimePickerDate.Enabled = false;
            lifelengthViewerComponentLastPerformance.ReadOnly = true;
            lifelengthViewerComponentLastPerformance.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerComponentLastPerformance.Modified = false;
            lifelengthViewerAircraftLastPerformance.ReadOnly = true;
            lifelengthViewerAircraftLastPerformance.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerAircraftLastPerformance.Modified = false;
            lifelengthViewerNext.Lifelength = Lifelength.NullLifelength;
            lifelengthViewerRemains.Lifelength = Lifelength.NullLifelength;
        }

        #endregion

        #region public DetailDirective GetDetailDirective()

        /// <summary>
        /// Возвращает работу агрегата
        /// </summary>
        /// <returns></returns>
        public DetailDirective GetDetailDirective()
        {
            DetailDirective detailDirective = new DetailDirective((DirectiveType)comboBoxWorkType.SelectedItem);
            detailDirective.Interval = lifelengthViewerInterval.Lifelength;
            detailDirective.Notify = lifelengthViewerNotify.Lifelength;
            return detailDirective;
        }

        #endregion


        #region private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerDate_ValueChanged(object sender, EventArgs e)
        {
            if (!lifelengthViewerAircraftLastPerformance.Modified && checkBoxLastCompliance.Checked)
            {
                lifelengthViewerAircraftLastPerformance.Lifelength = currentAircraft.GetLifelength(dateTimePickerDate.Value);
                lifelengthViewerAircraftLastPerformance.Modified = false;
            }
        }

        #endregion

        #region private void checkBoxLastCompliance_CheckedChanged(object sender, EventArgs e)

        private void checkBoxLastCompliance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLastCompliance.Checked)
            {
                dateTimePickerDate.Enabled = true;
                lifelengthViewerComponentLastPerformance.ReadOnly = false;
                lifelengthViewerAircraftLastPerformance.ReadOnly = false;
                lifelengthViewerAircraftLastPerformance.Lifelength = currentAircraft.GetLifelength(dateTimePickerDate.Value);
                lifelengthViewerAircraftLastPerformance.Modified = false;
            }
            else
            {
                dateTimePickerDate.Enabled = false;
                lifelengthViewerComponentLastPerformance.Lifelength = Lifelength.NullLifelength;
                lifelengthViewerAircraftLastPerformance.Lifelength = Lifelength.NullLifelength;
                lifelengthViewerComponentLastPerformance.ReadOnly = true;
                lifelengthViewerAircraftLastPerformance.ReadOnly = true;
                lifelengthViewerComponentLastPerformance.Modified = false;
                lifelengthViewerAircraftLastPerformance.Modified = false;
                lifelengthViewerNext.Lifelength = lifelengthViewerInterval.Lifelength;
                lifelengthViewerRemains.Lifelength = lifelengthViewerNext.Lifelength - lifelengthViewerComponentLastPerformance.Lifelength;
            }
        }

        #endregion

        #region private void lifelengthViewerInterval_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerInterval_LifelengthChanged(object sender, EventArgs e)
        {
            if (checkBoxLastCompliance.Checked)
            {
                lifelengthViewerNext.Lifelength = lifelengthViewerComponentLastPerformance.Lifelength + lifelengthViewerInterval.Lifelength;
                lifelengthViewerRemains.Lifelength = lifelengthViewerNext.Lifelength - lifelengthViewerComponentLastPerformance.Lifelength;
            }
            else
                lifelengthViewerNext.Lifelength = lifelengthViewerRemains.Lifelength = lifelengthViewerInterval.Lifelength;
        }

        #endregion

        #region private void lifelengthViewerComponentLastPerformance_LifelengthChanged(object sender, EventArgs e)

        private void lifelengthViewerComponentLastPerformance_LifelengthChanged(object sender, EventArgs e)
        {
            if (checkBoxLastCompliance.Checked)
            {
                lifelengthViewerNext.Lifelength = lifelengthViewerComponentLastPerformance.Lifelength + lifelengthViewerInterval.Lifelength;
                lifelengthViewerRemains.Lifelength = lifelengthViewerNext.Lifelength - lifelengthViewerComponentLastPerformance.Lifelength;
            }
            else
                lifelengthViewerNext.Lifelength = lifelengthViewerRemains.Lifelength = lifelengthViewerInterval.Lifelength;
        }

        #endregion

        #region private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearFields();
        }

        #endregion

        #endregion

    }
}