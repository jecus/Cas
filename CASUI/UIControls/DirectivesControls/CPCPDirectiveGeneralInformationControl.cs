using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Отображает информацию о директиве
    ///</summary>
    public class CPCPDirectiveGeneralInformationControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int COMBO_BOX_WIDTH = 100;
        private const int HEIGHT_INTERVAL = 20;
        private const int LIFELENGTH_VIEWER_INTERVAL = 15;


        private BaseDetailDirective currentDirective;
        
        private Label labelCPCPNumber;
        private Label labelPart;
        private Label labelCardTitle;
        private Label labelTH;
        private Label labelRepeatInterval;
        private Label labelNotifyBefore;
        private Label labelRemarks;
        private Label labelHiddenRemarks;
        private TextBox textBoxCPCPNumber;
        private TextBox textboxPart;
        private TextBox textBoxCardTitle;
        private TextBox textboxManHours;
        private TextBox textboxRepeatInterval;
        private TextBox textboxRemarks;
        private TextBox textboxHiddenRemarks;
        private ComboBox comboBoxRepeatInterval;
        private TextBox textboxNotifyBefore;
        private ComboBox comboBoxNotifyBefore;
        
        #endregion

        #region Constructors

        #region public CPCPDirectiveGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public CPCPDirectiveGeneralInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public CPCPDirectiveGeneralInformationControl(BaseDetailDirective currentDirective)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public CPCPDirectiveGeneralInformationControl(BaseDetailDirective currentDirective)
        {
            if (null == currentDirective)
                throw new ArgumentNullException("currentDirective", "Argument cannot be null");
            this.currentDirective = currentDirective;
            InitializeComponent();
        }

        #endregion

        #endregion

        #region Properties

        #region public BaseDetailDirective CurrentDirective

        /// <summary>
        /// Текущая директива
        /// </summary>
        public BaseDetailDirective CurrentDirective
        {
            get
            {
                return currentDirective;
            }
            set
            {
                currentDirective = value;
            }
        }

        #endregion

        #region public TextBox TextBoxCPCPNumber

        /// <summary>
        /// Возвращает текстбокс с CPCP Number
        /// </summary>
        public TextBox TextBoxCPCPNumber
        {
            get { return textBoxCPCPNumber; }
        }

        #endregion

        #region public string CPCPNumber

        /// <summary>
        /// CPCP Number текущей директивы
        /// </summary>
        public string CPCPNumber
        {
            get
            {
                return textBoxCPCPNumber.Text;
            }
            set
            {
                textBoxCPCPNumber.Text = value;
            }
        }

        #endregion

        #region public string Part

        /// <summary>
        /// Имя текущей директивы
        /// </summary>
        public string Part
        {
            get
            {
                return textboxPart.Text;
            }
            set
            {
                textboxPart.Text = value;
            }
        }

        #endregion

        #region public string CardTitle

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string CardTitle
        {
            get
            {
                return textBoxCardTitle.Text;
            }
            set
            {
                textBoxCardTitle.Text = value;
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

        #region public string RepeatIntervalString

        /// <summary>
        /// Repeat Interval текущей директивы
        /// </summary>
        public string RepeatIntervalString
        {
            get
            {
                return textboxRepeatInterval.Text;
            }
            set
            {
                textboxRepeatInterval.Text = value;
            }
        }

        #endregion

        #region public string NotifyBeforeString

        /// <summary>
        /// Notify Before текущей директивы
        /// </summary>
        public string NotifyBeforeString
        {
            get
            {
                return textboxNotifyBefore.Text;
            }
            set
            {
                textboxNotifyBefore.Text = value;
            }
        }

        #endregion

        #region public Lifelength RepeatInterval

        /// <summary>
        /// Repeat Interval текущей директивы
        /// </summary>
        public Lifelength RepeatInterval
        {
            get
            {
                if (RepeatIntervalString == "")
                    return Lifelength.NullLifelength;
                int repeatInterval;
                if (!CheckRepeatInterval(out repeatInterval))
                    return Lifelength.NullLifelength;
                TimeSpan calendar;
                if (comboBoxRepeatInterval.SelectedIndex == 0)
                    calendar = new TimeSpan(repeatInterval, 0, 0, 0);
                else if (comboBoxRepeatInterval.SelectedIndex == 1)
                    calendar = new TimeSpan(30 * repeatInterval, 0, 0, 0);
                else
                    calendar = new TimeSpan(365 * repeatInterval, 0, 0, 0);
                Lifelength lifelength = new Lifelength(calendar, 0, new TimeSpan(0));
                lifelength.IsHoursApplicable = false;
                lifelength.IsCyclesApplicable = false;
                return lifelength;
            }
            set
            {
                if (value == null || value == Lifelength.NullLifelength)
                {
                    textboxRepeatInterval.Text = "";
                    comboBoxRepeatInterval.SelectedIndex = 0;
                    return;
                }
                int days = (int)Math.Round(value.Calendar.TotalDays);
                if (days == 0)
                {
                    textboxRepeatInterval.Text = "";
                    comboBoxRepeatInterval.SelectedIndex = 0;
                    return;
                }
                if (days % 365 == 0)
                {
                    comboBoxRepeatInterval.SelectedIndex = 2;
                    textboxRepeatInterval.Text = (days / 365).ToString();
                }
                else if (days % 360 == 0)
                {
                    comboBoxRepeatInterval.SelectedIndex = 2;
                    textboxRepeatInterval.Text = (days / 360).ToString();
                }
                else if (days % 30 == 0)
                {
                    comboBoxRepeatInterval.SelectedIndex = 1;
                    textboxRepeatInterval.Text = (days / 30).ToString();
                }
                else
                {
                    comboBoxRepeatInterval.SelectedIndex = 0;
                    textboxRepeatInterval.Text = days.ToString();
                }
            }
        }

        #endregion

        #region public Lifelength NotifyBefore

        /// <summary>
        /// Наработка Notify Before
        /// </summary>
        public Lifelength NotifyBefore
        {
            get
            {
                if (NotifyBeforeString == "")
                    return Lifelength.NullLifelength;
                int notifyBefore;
                if (!CheckNotification(out notifyBefore))
                    return Lifelength.NullLifelength;
                TimeSpan calendar;
                if (comboBoxNotifyBefore.SelectedIndex == 0)
                    calendar = new TimeSpan(notifyBefore, 0, 0, 0);
                else if (comboBoxNotifyBefore.SelectedIndex == 1)
                    calendar = new TimeSpan(30 * notifyBefore, 0, 0, 0);
                else
                    calendar = new TimeSpan(365 * notifyBefore, 0, 0, 0);
                Lifelength lifelength = new Lifelength(calendar, 0, new TimeSpan(0));
                lifelength.IsHoursApplicable = false;
                lifelength.IsCyclesApplicable = false;
                return lifelength;
            }
            set
            {
                if (value == null || value == Lifelength.NullLifelength)
                {
                    textboxNotifyBefore.Text = "";
                    comboBoxNotifyBefore.SelectedIndex = 0;
                    return;
                }
                int days = (int)Math.Round(value.Calendar.TotalDays);
                if (days == 0)
                {
                    textboxNotifyBefore.Text = "";
                    comboBoxNotifyBefore.SelectedIndex = 0;
                    return;
                }
                if (days % 365 == 0)
                {
                    comboBoxNotifyBefore.SelectedIndex = 2;
                    textboxNotifyBefore.Text = (days / 365).ToString();
                }
                else if (days % 360 == 0)
                {
                    comboBoxNotifyBefore.SelectedIndex = 2;
                    textboxNotifyBefore.Text = (days / 360).ToString();
                }
                else if (days % 30 == 0)
                {
                    comboBoxNotifyBefore.SelectedIndex = 1;
                    textboxNotifyBefore.Text = (days / 30).ToString();
                }
                else
                {
                    comboBoxNotifyBefore.SelectedIndex = 0;
                    textboxNotifyBefore.Text = days.ToString();
                }
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string Remarks
        {
            get
            {
                return textboxRemarks.Text;
            }
            set
            {
                textboxRemarks.Text = value;
            }
        }

        #endregion

        #region public string HiddenRemarks

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string HiddenRemarks
        {
            get
            {
                return textboxHiddenRemarks.Text;
            }
            set
            {
                textboxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;

            labelCPCPNumber = new Label();
            labelPart = new Label();
            labelCardTitle = new Label();
            labelTH = new Label();
            labelRepeatInterval = new Label();
            labelNotifyBefore = new Label();
            textBoxCPCPNumber = new TextBox();
            textboxPart = new TextBox();
            textBoxCardTitle = new TextBox();
            textboxManHours = new TextBox();
            textboxRepeatInterval = new TextBox();
            comboBoxRepeatInterval = new ComboBox();
            textboxNotifyBefore = new TextBox();
            comboBoxNotifyBefore = new ComboBox();
            labelRemarks = new Label();
            textboxRemarks= new TextBox();
            labelHiddenRemarks = new Label();
            textboxHiddenRemarks = new TextBox();


            // 
            // labelCPCPNumber
            // 
            labelCPCPNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCPCPNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCPCPNumber.Location = new Point(MARGIN, MARGIN);
            labelCPCPNumber.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCPCPNumber.Text = "CPCP Number:";
            //
            // textBoxCPCPNumber
            //
            textBoxCPCPNumber.BackColor = Color.White;
            textBoxCPCPNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCPCPNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCPCPNumber.Location = new Point(labelCPCPNumber.Right, MARGIN);
            textBoxCPCPNumber.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelPart
            // 
            labelPart.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelPart.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPart.Location = new Point(MARGIN, labelCPCPNumber.Bottom + HEIGHT_INTERVAL);
            labelPart.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelPart.Text = "Part:";
            // 
            // textboxPart
            // 
            textboxPart.BackColor = Color.White;
            textboxPart.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxPart.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxPart.Location = new Point(labelPart.Right, textBoxCPCPNumber.Bottom + HEIGHT_INTERVAL);
            textboxPart.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            //textboxPart.MaxLength = 50;
            // 
            // labelCardTitle
            // 
            labelCardTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelCardTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCardTitle.Location = new Point(MARGIN, labelPart.Bottom + HEIGHT_INTERVAL);
            labelCardTitle.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCardTitle.Text = "Card Title:";
            //
            //  textBoxCardTitle
            //
            textBoxCardTitle.BackColor = Color.White;
            textBoxCardTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxCardTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCardTitle.Location = new Point(labelCardTitle.Right, textboxPart.Bottom + HEIGHT_INTERVAL);
            textBoxCardTitle.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textBoxCardTitle.Multiline = true;
            // 
            // labelTH
            // 
            labelTH.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTH.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTH.Location = new Point(MARGIN, textBoxCardTitle.Bottom + HEIGHT_INTERVAL);
            labelTH.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTH.Text = "TH:";
            // 
            // textboxManHours
            // 
            textboxManHours.BackColor = Color.White;
            textboxManHours.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxManHours.Location = new Point(labelTH.Right, textBoxCardTitle.Bottom + HEIGHT_INTERVAL);
            textboxManHours.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            // 
            // labelRepeatInterval
            // 
            labelRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRepeatInterval.Location = new Point(MARGIN, labelTH.Bottom + HEIGHT_INTERVAL);
            labelRepeatInterval.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRepeatInterval.Text = "Repeat Interval:";
            // 
            // textboxRepeatInterval
            // 
            textboxRepeatInterval.BackColor = Color.White;
            textboxRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRepeatInterval.Location = new Point(labelRepeatInterval.Right, labelTH.Bottom + HEIGHT_INTERVAL);
            textboxRepeatInterval.Size = new Size(TEXTBOX_WIDTH - COMBO_BOX_WIDTH - MARGIN, LABEL_HEIGHT);
            //textboxRepeatInterval.MaxLength = 1000;
            // 
            // comboBoxRepeatInterval
            // 
            comboBoxRepeatInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRepeatInterval.BackColor = Color.White;
            comboBoxRepeatInterval.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxRepeatInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxRepeatInterval.Location = new Point(textboxRepeatInterval.Right + MARGIN, labelTH.Bottom + HEIGHT_INTERVAL);
            comboBoxRepeatInterval.Size = new Size(COMBO_BOX_WIDTH, LABEL_HEIGHT);
            comboBoxRepeatInterval.Items.Add("Days");
            comboBoxRepeatInterval.Items.Add("Month");
            comboBoxRepeatInterval.Items.Add("Years");
            comboBoxRepeatInterval.SelectedIndex = 0;
            //
            // labelNotifyBefore
            //
            labelNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotifyBefore.Location = new Point(MARGIN, labelRepeatInterval.Bottom + HEIGHT_INTERVAL);
            labelNotifyBefore.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelNotifyBefore.Text = "Notify Before";
            // 
            // textboxNotifyBefore
            // 
            textboxNotifyBefore.BackColor = Color.White;
            textboxNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxNotifyBefore.Location = new Point(labelNotifyBefore.Right, labelRepeatInterval.Bottom + HEIGHT_INTERVAL);
            textboxNotifyBefore.Size = new Size(TEXTBOX_WIDTH - COMBO_BOX_WIDTH - MARGIN, LABEL_HEIGHT);
            // 
            // comboBoxNotifyBefore
            // 
            comboBoxNotifyBefore.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNotifyBefore.BackColor = Color.White;
            comboBoxNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxNotifyBefore.Location = new Point(textboxNotifyBefore.Right + MARGIN, labelRepeatInterval.Bottom + HEIGHT_INTERVAL);
            comboBoxNotifyBefore.Size = new Size(COMBO_BOX_WIDTH, LABEL_HEIGHT);
            comboBoxNotifyBefore.Items.Add("Days");
            comboBoxNotifyBefore.Items.Add("Month");
            comboBoxNotifyBefore.Items.Add("Years");
            comboBoxNotifyBefore.SelectedIndex = 0;
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(MARGIN, labelNotifyBefore.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks:";
            // 
            // textboxRemarks
            // 
            textboxRemarks.BackColor = Color.White;
            textboxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRemarks.Location = new Point(labelRemarks.Right, labelNotifyBefore.Bottom + HEIGHT_INTERVAL);
            textboxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxRemarks.Multiline = true;
            //
            // labelHiddenRemarks
            //
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Location = new Point(MARGIN, textboxRemarks.Bottom + HEIGHT_INTERVAL);
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHiddenRemarks.Text = "Hidden Remarks:";
            // 
            // textboxHiddenRemarks
            // 
            textboxHiddenRemarks.BackColor = Color.White;
            textboxHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxHiddenRemarks.Location = new Point(labelHiddenRemarks.Right, textboxRemarks.Bottom + HEIGHT_INTERVAL);
            textboxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxHiddenRemarks.Multiline = true;


            Controls.Add(labelCPCPNumber);
            Controls.Add(textBoxCPCPNumber);
            Controls.Add(labelPart);
            Controls.Add(textboxPart);
            Controls.Add(labelCardTitle);
            Controls.Add(textBoxCardTitle);
            Controls.Add(labelTH);
            Controls.Add(textboxManHours);
            Controls.Add(labelRepeatInterval);
            Controls.Add(textboxRepeatInterval);
            Controls.Add(comboBoxRepeatInterval);
            Controls.Add(labelNotifyBefore);
            Controls.Add(textboxNotifyBefore);
            Controls.Add(comboBoxNotifyBefore);
            Controls.Add(labelRemarks);
            Controls.Add(textboxRemarks);
            Controls.Add(labelHiddenRemarks);
            Controls.Add(textboxHiddenRemarks);
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
            double eps = 0.000001;
            double manHours;
            int repeatInterval;
            if (!CheckManHours(out manHours))
                return true;
            if (!CheckRepeatInterval(out repeatInterval))
                return true;
            if (directiveExist)
                return ((CPCPNumber != currentDirective.Title) ||
                        (Part != currentDirective.Paragraph) ||
                        (CardTitle != currentDirective.Description) ||
                        (Remarks != currentDirective.Remarks) ||
                        (HiddenRemarks != currentDirective.HiddenRemarks) ||
                        (Math.Abs(manHours - currentDirective.ManHours) > eps) ||
                        (currentDirective.RepeatPerform != null && (int)RepeatInterval.Calendar.TotalDays != (int)currentDirective.RepeatPerform.Calendar.TotalDays) ||
                        ((int)NotifyBefore.Calendar.TotalDays != (int)currentDirective.Notification.Calendar.TotalDays));

            else
                return ((CPCPNumber != "") ||
                        (Part != "") ||
                        (CardTitle != "") ||
                        (Remarks != "") ||
                        (HiddenRemarks != "") ||
                        (ManhoursString != "") ||
                        (RepeatIntervalString != "") ||
                        (NotifyBeforeString != ""));
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDirective != null)
                UpdateInformation(currentDirective);
        }

        #endregion

        #region public void UpdateInformation(BaseDetailDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(BaseDetailDirective sourceDirective)
        {
            if (sourceDirective == null) 
                throw new ArgumentNullException("sourceDirective");
            CPCPNumber = sourceDirective.Title;
            Part = sourceDirective.Paragraph;
            CardTitle = sourceDirective.Description;
            Remarks = sourceDirective.Remarks;
            HiddenRemarks = sourceDirective.HiddenRemarks;
            if (Math.Abs(sourceDirective.ManHours) > 0.000001)
                ManhoursString = sourceDirective.ManHours.ToString();
            RepeatInterval = sourceDirective.RepeatPerform;
            NotifyBefore = sourceDirective.Notification;

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxCPCPNumber.Enabled = permission;
            textboxPart.ReadOnly = !permission;
            textBoxCardTitle.Enabled = permission;
            textboxRepeatInterval.ReadOnly = !permission;
            comboBoxRepeatInterval.Enabled = permission;
            textboxManHours.ReadOnly = !permission;
            textboxNotifyBefore.ReadOnly = !permission;
            comboBoxNotifyBefore.Enabled = permission;
            textboxRemarks.ReadOnly = !permission;
            textboxHiddenRemarks.ReadOnly = !permission;
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public bool SaveData()
        {
            if (currentDirective != null)
            {
                return SaveData(currentDirective, true);
            }
            return false;
        }

        #endregion

        #region  public bool SaveData(BaseDetailDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public bool SaveData(BaseDetailDirective destinationDirective, bool changePageName)
        {
            textBoxCPCPNumber.Focus();
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");
            double manHours;
            int repeatInterval;
            if (!CheckManHours(out manHours))
                return false;
            if (!CheckRepeatInterval(out repeatInterval))
                return false;
            if (destinationDirective.Title != CPCPNumber)
            {
                destinationDirective.Title = CPCPNumber;
                if (changePageName)
                {
                    string caption = "";
                    if (destinationDirective.Parent is BaseDetail)
                    {
                        BaseDetail baseDetail = (BaseDetail)destinationDirective.Parent;
                        if (baseDetail is AircraftFrame)
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                        else 
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + destinationDirective.DirectiveType.CommonName + ". " + destinationDirective.Title;
                    }
                    if (DisplayerRequested != null)
                        DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
                }
            }
            if (destinationDirective.Paragraph != Part)
                destinationDirective.Paragraph = Part;
            if (destinationDirective.Description != CardTitle)
                destinationDirective.Description = CardTitle;
            if (Math.Abs(destinationDirective.ManHours - manHours) > 0.000001)
                destinationDirective.ManHours = manHours;
            if ((int)RepeatInterval.Calendar.TotalDays != (int)destinationDirective.RepeatPerform.Calendar.TotalDays)
            {
                destinationDirective.RepeatPerform = RepeatInterval;
                destinationDirective.FirstPerformSinceNew = new Lifelength(RepeatInterval);
            }
            if ((int)NotifyBefore.Calendar.TotalDays != (int)destinationDirective.Notification.Calendar.TotalDays)
                destinationDirective.Notification = NotifyBefore;
            if (destinationDirective.Remarks != Remarks)
                destinationDirective.Remarks = Remarks;
            if (destinationDirective.HiddenRemarks != HiddenRemarks)
                destinationDirective.HiddenRemarks = HiddenRemarks;
            return true;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            CPCPNumber = "";
            Part = "";
            CardTitle = "";
            ManhoursString = "";
            RepeatIntervalString = "";
            NotifyBeforeString = "";
            comboBoxRepeatInterval.SelectedIndex = 0;
            comboBoxNotifyBefore.SelectedIndex = 0;
            Remarks = "";
            HiddenRemarks = "";
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

        #region public bool CheckRepeatInterval(out int repeatInterval)

        /// <summary>
        /// Проверяет значение Repeat Interval
        /// </summary>
        /// <param name="repeatInterval">Значение Repeat Interval</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckRepeatInterval(out int repeatInterval)
        {
            if (RepeatIntervalString == "")
            {
                repeatInterval = 0;
                return true;
            }
            if (int.TryParse(RepeatIntervalString, NumberStyles.Float, new NumberFormatInfo(), out repeatInterval) == false)
            {
                MessageBox.Show("Repeat Interval. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckNotification(out int notification)

        /// <summary>
        /// Проверяет значение Repeat Interval
        /// </summary>
        /// <param name="notification">Значение Notify Before</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckNotification(out int notification)
        {
            if (NotifyBeforeString == "")
            {
                notification = 0;
                return true;
            }
            if (int.TryParse(NotifyBeforeString, NumberStyles.Float, new NumberFormatInfo(), out notification) == false)
            {
                MessageBox.Show("Notification. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #endregion

        #region IReference Members

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
    }
}