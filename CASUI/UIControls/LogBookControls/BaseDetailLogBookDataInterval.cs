using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.LogBookControls;

namespace CAS.UI.UIControls.LogBookControls
{
/*
    /// <summary>
    /// Элемент управления для отображения фильтра наработок
    /// </summary>
    public partial class BaseDetailLogBookDataInterval : UserControl
    {

        #region Fields

        private const int LABEL_WIDTH = 100;
        private const int LABEL_INPUT_INTERVAL_WIDTH = 130;
        private const int DATE_TIME_PICKER_WIDTH = 200;
        private const int LABEL_HEIGHT = 25;
        private const int TEXT_BOX_INTERVAL = 25;
        private const int TEXT_INTERVAL = 10;
        private const int RIGHT_MARGIN = 25;
        private readonly Button buttonApply = new Button();
        private readonly DateTimePicker dateTimePickerEndDate = new DateTimePicker();
        private readonly DateTimePicker dateTimePickerStartDate = new DateTimePicker();
        private readonly Label labelEndDate = new Label();
        private readonly Label labelInputInterval = new Label();
        private readonly Label labelStartDate = new Label();
        private readonly Label labelLinks = new Label();
        private readonly LinkLabel linkLabelCurrentMonth = new LinkLabel();
        private readonly LinkLabel linkLabelSinceLastKnowRecord = new LinkLabel();
        private BaseDetail currentDetail;
        private LifelengthIncrement[] lifeLengthIncrements;
        private DateTime startDate;
        private DateTime endDate;
        readonly List<ReferenceLinkLabel> links = new List<ReferenceLinkLabel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Создает новый элемент для отображения фильтра наработок
        /// </summary>
        /// <param name="currentDetail">Текущий агрегат</param>
        /// <param name="startDate">Дата, с которой следует отображать наработки</param>
        /// <param name="endDate">Дата, по которую следует отображать наработки</param>
        public BaseDetailLogBookDataInterval(BaseDetail currentDetail, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(LABEL_WIDTH + DATE_TIME_PICKER_WIDTH + RIGHT_MARGIN, 500);
            //
            // labelInputInterval
            //
            labelInputInterval.AutoSize = true;
            labelInputInterval.Font = Css.SmallHeader.Fonts.RegularFont;
            labelInputInterval.ForeColor = Css.SmallHeader.Colors.ForeColor;
            labelInputInterval.Location = new Point(0, 0);
            labelInputInterval.Text = "Input Interval:";
            labelInputInterval.TextAlign = ContentAlignment.BottomLeft;
            //
            // linkLabelCurrentMonth
            //
            linkLabelCurrentMonth.Font = Css.SimpleLink.Fonts.Font;
            linkLabelCurrentMonth.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelCurrentMonth.Location = new Point(LABEL_INPUT_INTERVAL_WIDTH, 0);
            linkLabelCurrentMonth.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            linkLabelCurrentMonth.Text = "Current month";
            linkLabelCurrentMonth.TextAlign = ContentAlignment.TopLeft;
            linkLabelCurrentMonth.Click += linkLabelCurrentMonth_Click;
            //
            // linkLabelSinceLastKnowRecord
            //
            linkLabelSinceLastKnowRecord.Font = Css.SimpleLink.Fonts.Font;
            linkLabelSinceLastKnowRecord.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelSinceLastKnowRecord.Location = new Point(LABEL_INPUT_INTERVAL_WIDTH, linkLabelCurrentMonth.Bottom + TEXT_INTERVAL);
            linkLabelSinceLastKnowRecord.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            linkLabelSinceLastKnowRecord.Text = "Since last known record";
            linkLabelSinceLastKnowRecord.TextAlign = ContentAlignment.TopLeft;
            linkLabelSinceLastKnowRecord.Click += linkLabelSinceLastKnowRecord_Click;
            //
            // labelStartDate
            //
            labelStartDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelStartDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelStartDate.Location = new Point(0, linkLabelSinceLastKnowRecord.Bottom + TEXT_INTERVAL);
            labelStartDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelStartDate.Text = "Start date: ";
            labelStartDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerStartDate
            //
            dateTimePickerStartDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerStartDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerStartDate.Location = new Point(LABEL_WIDTH, linkLabelSinceLastKnowRecord.Bottom + TEXT_INTERVAL);
            dateTimePickerStartDate.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerStartDate.GotFocus += dateTimePickerStartDate_GotFocus;
            dateTimePickerStartDate.ValueChanged += dateTimePickerStartDate_ValueChanged;
            //
            // labelEndDate
            //
            labelEndDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEndDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEndDate.Location = new Point(0, dateTimePickerStartDate.Bottom + TEXT_BOX_INTERVAL);
            labelEndDate.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEndDate.Text = "End date: ";
            labelEndDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerEndDate
            //
            dateTimePickerEndDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerEndDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            dateTimePickerEndDate.Location = new Point(LABEL_WIDTH, dateTimePickerStartDate.Bottom + TEXT_BOX_INTERVAL);
            dateTimePickerEndDate.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerEndDate.GotFocus += dateTimePickerEndDate_GotFocus;
            dateTimePickerEndDate.ValueChanged += dateTimePickerEndDate_ValueChanged;
            //
            // buttonApply
            //
            buttonApply.BackColor = Color.White;
            buttonApply.FlatStyle = FlatStyle.Flat;
            buttonApply.FlatAppearance.BorderColor = Css.SimpleLink.Colors.LinkColor;
            buttonApply.Font = Css.OrdinaryText.Fonts.BoldFont;
            buttonApply.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonApply.Size = new Size(100, 30);
            buttonApply.Location = new Point(Width - buttonApply.Width - RIGHT_MARGIN, labelEndDate.Bottom + TEXT_BOX_INTERVAL);
            buttonApply.Text = "Apply";
            buttonApply.Click += buttonApply_Click;
            //
            // labelLinks
            //
            labelLinks.Font = Css.SmallHeader.Fonts.RegularFont;
            labelLinks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLinks.Location = new Point(0, buttonApply.Bottom + TEXT_BOX_INTERVAL);
            labelLinks.Size = new Size(Width, LABEL_HEIGHT);
            labelLinks.Text = "Links";
            labelLinks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // links
            //
            for (int i = 0; i < currentDetail.ParentAircraft.BaseDetails.Length - 1; i++)
            {
                ReferenceLinkLabel linkLabel = new ReferenceLinkLabel();
                linkLabel.Font = Css.SimpleLink.Fonts.Font;
                linkLabel.LinkColor = Css.SimpleLink.Colors.LinkColor;
                linkLabel.Size = new Size(Width,LABEL_HEIGHT);//todo
                if (i == 0)
                    linkLabel.Location = new Point(0, labelLinks.Bottom + TEXT_INTERVAL);
                else
                    linkLabel.Location = new Point(0, links[i - 1].Bottom + TEXT_INTERVAL);
                links.Add(linkLabel);
            }

            this.startDate = startDate;
            this.endDate = endDate;
            CurrentDetail = currentDetail;

            Controls.Add(labelInputInterval);
            Controls.Add(linkLabelCurrentMonth);
            Controls.Add(linkLabelSinceLastKnowRecord);
            Controls.Add(labelStartDate);
            Controls.Add(dateTimePickerStartDate);
            Controls.Add(labelEndDate);
            Controls.Add(dateTimePickerEndDate);
            Controls.Add(buttonApply);
            Controls.Add(labelLinks);
            Controls.AddRange(links.ToArray());
        }

        #endregion

        #region Properties

        #region public LifelengthIncrement[] LifelengthIncrements

        /// <summary>
        /// Возвращает наработки агрегата
        /// </summary>
        public LifelengthIncrement[] LifelengthIncrements
        {
            get
            {
                return lifeLengthIncrements;
            }
        }

        #endregion

        #region public BaseDetail CurrentDetail

        /// <summary>
        /// Возвращает или устанавливает текущий агрегат
        /// </summary>
        public BaseDetail CurrentDetail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                UpdateControl();
            }
        }

        #endregion

        #region public DateTime StartDate

        /// <summary>
        /// Возвращает начальную дату 
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
        }

        #endregion

        #region public DateTime EndDate

        /// <summary>
        /// Возвращает конечную дату 
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void dateTimePickerStartDate_GotFocus(object sender, EventArgs e)

        private void dateTimePickerStartDate_GotFocus(object sender, EventArgs e)
        {
            dateTimePickerStartDate.MaxDate = DateTime.Now;
        }

        #endregion

        #region private void dateTimePickerEndDate_GotFocus(object sender, EventArgs e)

        private void dateTimePickerEndDate_GotFocus(object sender, EventArgs e)
        {
            dateTimePickerEndDate.MaxDate = DateTime.Now;
        }

        #endregion

        #region private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value > dateTimePickerEndDate.MaxDate)
                dateTimePickerEndDate.Value = dateTimePickerEndDate.MaxDate;
            endDate = dateTimePickerEndDate.Value;
        }

        #endregion

        #region private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerStartDate.Value < currentDetail.InstallationDate)
                dateTimePickerStartDate.Value = currentDetail.InstallationDate;
            startDate = dateTimePickerStartDate.Value;
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            GetLifelenghIncrements();
        }

        #endregion

        #region public void GetLifelenghIncrements()

        /// <summary>
        /// Записывает все наработки данного базового агрегата при ограничениях фильтра в коллекцию и посылает событие AplyClicked
        /// </summary>
        public void GetLifelenghIncrements()
        {
            // Проверка на правильность задания интервала времени
            if (dateTimePickerStartDate.Value > dateTimePickerEndDate.Value)
            {
                MessageBox.Show("Start date must be less than end date.", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            lifeLengthIncrements = currentDetail.GetLifelengthIncrements();
            // Объявление временных переменных
            List<LifelengthIncrement> lifeLengthIncrementsFiltered = new List<LifelengthIncrement>();
            List<LifelengthIncrement> resultLifeLengthIncrements = new List<LifelengthIncrement>();
            List<DateTime> dateOfLifelengthIncrements = new List<DateTime>();
            // Выбираем только те наработки, которые входят в интервал
            for (int i = 0; i < lifeLengthIncrements.Length; i++)
            {
                Date date = new Date(lifeLengthIncrements[i].AdditionDate);
                if ((date.ToDateTime() >= startDate) && (date.ToDateTime() < endDate))
                {
                    lifeLengthIncrementsFiltered.Add(lifeLengthIncrements[i]);
                    dateOfLifelengthIncrements.Add(date.ToDateTime());
                }
            }
            // Забиваем остальные даты пустыми наработками
            for (DateTime i = startDate; i < endDate; i = i.AddDays(1))
            {
                bool lifelengthIncrementContains = false;
                // Проверяем есть ли у нас наработка за текущую дату (i)
                for (int j = 0; j < lifeLengthIncrementsFiltered.Count; j++)
                {
                    Date date = new Date(lifeLengthIncrementsFiltered[j].AdditionDate);
                    if (date.ToDateTime() == i) 
                        lifelengthIncrementContains = true;
                }
                if (lifelengthIncrementContains)
                {
                    resultLifeLengthIncrements.Add(lifeLengthIncrementsFiltered[dateOfLifelengthIncrements.IndexOf(i)]);
                }
                else
                {
                    LifelengthIncrement lifelengthIncrement = new LifelengthIncrement();
                    lifelengthIncrement.AdditionDate = i;
                    resultLifeLengthIncrements.Add(lifelengthIncrement);
                }
            }

            lifeLengthIncrements = resultLifeLengthIncrements.ToArray();
            if (AplyClicked != null) 
                AplyClicked(this, new EventArgs());   
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет элемент управления
        /// </summary>
        private void UpdateControl()
        {
            dateTimePickerStartDate.MinDate = currentDetail.InstallationDate;
            dateTimePickerStartDate.Value = startDate;

            dateTimePickerEndDate.MaxDate = DateTime.Now;
            dateTimePickerEndDate.Value = endDate;

            Aircraft aircraft = currentDetail.ParentAircraft;
            int cnt = 0;


            for (int i = 0; i < aircraft.BaseDetails.Length; i++)
            {
                BaseDetail detail = aircraft.BaseDetails[i];
                
                // не добавляем ссылки на тот агрегат, который редактируем
                if (detail.ID == currentDetail.ID) continue;

                links[cnt].Text = detail.ToString() + ". Log Book";
                links[cnt].ReflectionType = ReflectionTypes.DisplayInCurrent;
                links[cnt].DisplayerText = detail.ToString() + ". Log Book";
                links[cnt].Tag = detail;
                links[cnt].DisplayerRequested += BaseDetailLogBookDataInterval_DisplayerRequested;
                cnt++;
            }
        }

        #endregion

        #region private void BaseDetailLogBookDataInterval_DisplayerRequested(object sender, CAS.UI.Interfaces.ReferenceEventArgs e)

        private void BaseDetailLogBookDataInterval_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (! (sender is Control)) return;
            Control cl = (Control) sender;
            BaseDetail detail = (BaseDetail) cl.Tag;
            e.RequestedEntity = new DispatcheredBaseDetailLogBookScreen(detail, startDate > detail.InstallationDate ? startDate : detail.InstallationDate, endDate);
        }

        #endregion

        #region protected override void OnLoad(EventArgs e)

        /// <summary>
        /// Метод, выполняющийся после загрузки элемента управления
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            buttonApply_Click(this, new EventArgs());
            base.OnLoad(e);
        }

        #endregion

        #region private void linkLabelCurrentMonth_Click(object sender, EventArgs e)

        private void linkLabelCurrentMonth_Click(object sender, EventArgs e)
        {
            DateTime currentMonth = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            if (currentMonth > dateTimePickerStartDate.MaxDate)
                currentMonth = dateTimePickerStartDate.MaxDate;
            dateTimePickerStartDate.Value = currentMonth;
            dateTimePickerEndDate.MaxDate = DateTime.Now;
            dateTimePickerEndDate.Value = dateTimePickerEndDate.MaxDate;
            startDate = dateTimePickerStartDate.Value;
            endDate = dateTimePickerEndDate.Value;
        }
        #endregion

        #region private void linkLabelSinceLastKnowRecord_Click(object sender, EventArgs e)

        private void linkLabelSinceLastKnowRecord_Click(object sender, EventArgs e)
        {
            LifelengthIncrement[] increments = currentDetail.GetLifelengthIncrements();
            if (increments.Length > 0)
            {
                dateTimePickerStartDate.Value = increments[increments.Length - 1].AdditionDate;
                dateTimePickerEndDate.MaxDate = DateTime.Now;

                TimeSpan diff = dateTimePickerEndDate.MaxDate - increments[increments.Length - 1].AdditionDate;

                if (diff.Days <= 30)
                    dateTimePickerEndDate.Value = dateTimePickerEndDate.MaxDate;
                else
                    dateTimePickerEndDate.Value = dateTimePickerStartDate.Value.AddMonths(1);
                startDate = dateTimePickerStartDate.Value;
                endDate = dateTimePickerEndDate.Value;
            }
        }
        #endregion

        #endregion

        #region Events

        #region public event EventHandler AplyClicked;

        /// <summary>
        /// Событие нажатия кнопки Apply
        /// </summary>
        public event EventHandler AplyClicked;

        #endregion

        #endregion

    }
*/
}