using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
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
    public class OutOffPhaseReferenceInformationControl : UserControl, IReference
    {

        #region Fields

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 150;
        private const int LABEL_HEIGHT = 25;
        private const int TEXTBOX_WIDTH = 350;
        private const int CHECK_BOX_WIDTH = 150;
        private const int HEIGHT_INTERVAL = 20;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int WIDTH_INTERVAL =600;


        private BaseDetailDirective currentDirective;

        private Label labelTitle;
        private TextBox textboxTitle;
        private Label labelRequirement;
        private TextBox textboxReqirement;
        private Label labelFrequency;
        private LifelengthViewer lifelengthViewerFrequency;
        private Label labelNotifyBefore;
        private LifelengthViewer lifelengthViewerNotifyBefore;
        private Label labelTLPNo;
        private TextBox textboxTLPNo;
        private Label labelReferences;
        private TextBox textBoxReferences;
        private Label labelRemarks;
        private TextBox textboxRemarks;
        private Label labelHiddenRemarks;
        private TextBox textboxHiddenRemarks;
        private Label labelEngOrderNo;
        private TextBox textboxEngOrderNo;
        private Label labelJobCardNo;
        private TextBox textboxJobCardNo;
        
        #endregion

        #region Constructors

        #region public DirectiveInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public OutOffPhaseReferenceInformationControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public DirectiveInformationControl(BaseDetailDirective currentDirective)

        ///<summary>
        /// Создает экземпляр класса для отображения информации о директиве
        ///</summary>
        ///<param name="currentDirective"></param>
        public OutOffPhaseReferenceInformationControl(BaseDetailDirective currentDirective)
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

        #region public string Title

        /// <summary>
        /// Title текущей директивы
        /// </summary>
        public string Title
        {
            get
            {
                return textboxTitle.Text;
            }
            set
            {
                textboxTitle.Text = value;
            }
        }

        #endregion

        #region public TextBox TextBoxReferences

        /// <summary>
        /// Возвращает текстбокс с записями
        /// </summary>
        public TextBox TextBoxReferences
        {
            get { return textBoxReferences; }
        }

        #endregion

        #region public string References

        /// <summary>
        /// References текущей директивы
        /// </summary>
        public string References
        {
            get
            {
                return textBoxReferences.Text;
            }
            set
            {
                textBoxReferences.Text = value;
            }
        }

        #endregion

        #region public string TLPNo

        /// <summary>
        /// TLPNo текущей директивы
        /// </summary>
        public string TLPNo
        {
            get
            {
                return textboxTLPNo.Text;
            }
            set
            {
                textboxTLPNo.Text = value;
            }
        }

        #endregion

        #region public string Requirement

        /// <summary>
        /// Описание текущей директивы
        /// </summary>
        public string Requirement
        {
            get { return textboxReqirement.Text; }
            set
            {
                textboxReqirement.Text = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Заметки текущей директивы
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
        /// Заметки текущей директивы
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
        
        #region public Lifelength FirstPerformNotifyBefore

        /// <summary>
        /// Наработка First Perform - Notify Before
        /// </summary>
        public Lifelength FirstPerformNotifyBefore
        {
            get
            {
                return lifelengthViewerNotifyBefore.Lifelength;
            }
            set
            {
                lifelengthViewerNotifyBefore.Lifelength = value;
            }
        }

        #endregion

        #region public string EngOrderNo

        /// <summary>
        /// EngOrderNo
        /// </summary>
        public string EngOrderNo
        {
            get
            {
                return textboxEngOrderNo.Text;
            }
            set
            {
                textboxEngOrderNo.Text = value;
            }
        }

        #endregion

        #region public string JobCardNo
        /// <summary>
        /// JobCardNo
        /// </summary>
        public string JobCardNo
        {
            get
            {
                return textboxJobCardNo.Text;
            }
            set
            {
                textboxJobCardNo.Text = value;
            }
        }

        #endregion

        #region public Lifelength Frequency
        /// <summary>
        /// Frequency
        /// </summary>
        public Lifelength Frequency
        {
            get
            {
                return lifelengthViewerFrequency.Lifelength;
            }
            set
            {
                lifelengthViewerFrequency.Lifelength = value;
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

            labelTitle = new Label();
            textboxTitle = new TextBox();
            labelReferences = new Label();
            labelTLPNo = new Label();
            labelRequirement = new Label();
            labelRemarks = new Label();
            labelHiddenRemarks = new Label();
            labelNotifyBefore = new Label();
            textBoxReferences = new TextBox();
            textboxTLPNo = new TextBox();
            textboxReqirement = new TextBox();
            lifelengthViewerNotifyBefore = new LifelengthViewer();
            lifelengthViewerFrequency = new LifelengthViewer();
            textboxRemarks = new TextBox();
            textboxHiddenRemarks = new TextBox();
            labelEngOrderNo = new Label();
            textboxEngOrderNo = new TextBox();
            labelJobCardNo = new Label();
            textboxJobCardNo = new TextBox();
            labelFrequency = new Label();
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTitle.Location = new Point(MARGIN, MARGIN);
            labelTitle.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTitle.Text = "Title";
            // 
            // textboxTitle
            // 
            textboxTitle.ScrollBars = ScrollBars.Vertical;
            textboxTitle.BackColor = Color.White;
            textboxTitle.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxTitle.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxTitle.Location = new Point(labelTitle.Right, MARGIN);
            textboxTitle.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxTitle.MaxLength = 50;
            // 
            // labelRequirement
            // 
            labelRequirement.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRequirement.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRequirement.Location = new Point(MARGIN, textboxTitle.Bottom + HEIGHT_INTERVAL);
            labelRequirement.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRequirement.Text = "Requirement";
            // 
            // textboxReqirement
            // 
            textboxReqirement.ScrollBars = ScrollBars.Vertical;
            textboxReqirement.BackColor = Color.White;
            textboxReqirement.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxReqirement.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxReqirement.Location = new Point(labelRequirement.Right, textboxTitle.Bottom + HEIGHT_INTERVAL);
            textboxReqirement.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxReqirement.Multiline = true;
            textboxReqirement.MaxLength = 1000;
            // 
            // labelFrequency
            // 
            labelFrequency.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFrequency.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFrequency.Location = new Point(MARGIN, textboxReqirement.Bottom + HEIGHT_INTERVAL + 18);
            labelFrequency.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelFrequency.Text = "Frequency";
            //
            // lifelengthViewerFrequency
            //
            lifelengthViewerFrequency.ShowHeaders = true;
            lifelengthViewerFrequency.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerFrequency.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerFrequency.ShowLeftHeader = false;
            lifelengthViewerFrequency.LeftHeaderWidth = 0;
            lifelengthViewerFrequency.ShowMinutes = false;
            lifelengthViewerFrequency.Location = new Point(labelFrequency.Right, textboxReqirement.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            //
            // labelNotifyBefore
            //
            labelNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotifyBefore.Location = new Point(MARGIN, lifelengthViewerFrequency.Bottom + HEIGHT_INTERVAL);
            labelNotifyBefore.Size = new Size(CHECK_BOX_WIDTH, LABEL_HEIGHT);
            labelNotifyBefore.Text = "Notify Before";
            //
            // lifelengthViewerNotifyBefore
            //
            lifelengthViewerNotifyBefore.ShowHeaders = false;
            lifelengthViewerNotifyBefore.Font = Css.OrdinaryText.Fonts.RegularFont;
            lifelengthViewerNotifyBefore.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            lifelengthViewerNotifyBefore.ShowLeftHeader = false;
            lifelengthViewerNotifyBefore.LeftHeaderWidth = 0;
            lifelengthViewerNotifyBefore.ShowMinutes = false;
            lifelengthViewerNotifyBefore.Location = new Point(labelNotifyBefore.Right, lifelengthViewerFrequency.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            // 
            // labelTLPNo
            // 
            labelTLPNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTLPNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTLPNo.Location = new Point(MARGIN, lifelengthViewerNotifyBefore.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            labelTLPNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelTLPNo.Text = "TPL No";
            // 
            // textboxTLPNo
            // 
            textboxTLPNo.BackColor = Color.White;
            textboxTLPNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxTLPNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxTLPNo.Location = new Point(labelTLPNo.Right, lifelengthViewerNotifyBefore.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            textboxTLPNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxTLPNo.MaxLength = 1000;
            //textboxThreshold.MaxLength = 1000;

            // 
            // labelReferences
            // 
            labelReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelReferences.Location = new Point(MARGIN, labelTLPNo.Bottom + HEIGHT_INTERVAL);
            labelReferences.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelReferences.Text = "References";
            // 
            // textBoxReferences
            // 
            textBoxReferences.BackColor = Color.White;
            textBoxReferences.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxReferences.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxReferences.Location = new Point(labelReferences.Right, labelTLPNo.Bottom + HEIGHT_INTERVAL);
            textBoxReferences.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textBoxReferences.MaxLength = 400;
            // 
            // labelEngOrderNo
            // 
            labelEngOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngOrderNo.Location = new Point(MARGIN, labelReferences.Bottom + HEIGHT_INTERVAL);
            labelEngOrderNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEngOrderNo.Text = "Eng. Order No";
            // 
            // textBoxEngOrderNo
            // 
            textboxEngOrderNo.BackColor = Color.White;
            textboxEngOrderNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxEngOrderNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxEngOrderNo.Location = new Point(labelEngOrderNo.Right, labelReferences.Bottom + HEIGHT_INTERVAL);
            textboxEngOrderNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxEngOrderNo.MaxLength = 400;
            // 
            // labelJobCardNo
            // 
            labelJobCardNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelJobCardNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelJobCardNo.Location = new Point(MARGIN, labelEngOrderNo.Bottom + HEIGHT_INTERVAL);
            labelJobCardNo.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelJobCardNo.Text = "JobCard No";
            // 
            // textboxJobCardNo
            // 
            textboxJobCardNo.BackColor = Color.White;
            textboxJobCardNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxJobCardNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxJobCardNo.Location = new Point(labelJobCardNo.Right, labelEngOrderNo.Bottom + HEIGHT_INTERVAL);
            textboxJobCardNo.Size = new Size(TEXTBOX_WIDTH, LABEL_HEIGHT);
            textboxJobCardNo.MaxLength = 400;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks";
            // 
            // textboxRemarks
            // 
            textboxRemarks.ScrollBars = ScrollBars.Vertical;
            textboxRemarks.BackColor = Color.White;
            textboxRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxRemarks.Multiline = true;
            textboxRemarks.MaxLength = 34000;
            textboxRemarks.Location = new Point(labelRemarks.Right, MARGIN);
            // 
            // labelHiddenRemarks
            // 
            labelHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelHiddenRemarks.Location = new Point(WIDTH_INTERVAL, textboxRemarks.Bottom + HEIGHT_INTERVAL);
            labelHiddenRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelHiddenRemarks.Text = "Hidden Remarks";
            // 
            // textboxHiddenRemarks
            // 
            textboxHiddenRemarks.ScrollBars = ScrollBars.Vertical;
            textboxHiddenRemarks.BackColor = Color.White;
            textboxHiddenRemarks.Font = Css.OrdinaryText.Fonts.RegularFont;
            textboxHiddenRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textboxHiddenRemarks.Size = new Size(TEXTBOX_WIDTH, 3 * LABEL_HEIGHT + 2 * HEIGHT_INTERVAL);
            textboxHiddenRemarks.Multiline = true;
            textboxHiddenRemarks.MaxLength = 34000;
            textboxHiddenRemarks.Location = new Point(labelRemarks.Right, textboxRemarks.Bottom + HEIGHT_INTERVAL);

            Controls.Add(labelTitle);
            Controls.Add(textboxTitle);
            Controls.Add(labelRequirement);
            Controls.Add(textboxReqirement);
            Controls.Add(labelFrequency);
            Controls.Add(lifelengthViewerFrequency);
            Controls.Add(labelNotifyBefore);
            Controls.Add(lifelengthViewerNotifyBefore);
            Controls.Add(labelTLPNo);
            Controls.Add(textboxTLPNo);
            Controls.Add(labelReferences);
            Controls.Add(textBoxReferences);
            Controls.Add(labelEngOrderNo);
            Controls.Add(textboxEngOrderNo);
            Controls.Add(labelJobCardNo);
            Controls.Add(textboxJobCardNo);
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
            Lifelength emptyLifelength = new Lifelength();
            if (directiveExist)
                return (
                           (Title != currentDirective.Title) ||
                           (References != currentDirective.References) ||
                           (TLPNo != currentDirective.Applicability) ||
                           (Requirement != currentDirective.Description) ||
                           (Remarks != currentDirective.Remarks) ||
                           (HiddenRemarks != currentDirective.HiddenRemarks) ||
                           (EngOrderNo != currentDirective.EngeneeringOrders) ||
                           (JobCardNo != currentDirective.JobCardNo) ||
                           lifelengthViewerFrequency.Modified ||
                           lifelengthViewerNotifyBefore.Modified);
            else
                return (
                           (Title != "") ||
                           (References != "") ||
                           (TLPNo != "") ||
                           (Requirement != "") ||
                           (Remarks != "") ||
                           (HiddenRemarks != "") ||
                           (EngOrderNo != "") ||
                           (JobCardNo != "") ||
                           !(lifelengthViewerNotifyBefore.Lifelength.Equals(emptyLifelength)) ||
                           !(lifelengthViewerFrequency.Lifelength.Equals(emptyLifelength))
                       );
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
            Title = sourceDirective.Title;
            References = sourceDirective.References;
            TLPNo = sourceDirective.Applicability;
            Requirement = sourceDirective.Description;
            Remarks = sourceDirective.Remarks;
            HiddenRemarks = sourceDirective.HiddenRemarks;
            FirstPerformNotifyBefore = sourceDirective.Notification;
            Frequency = sourceDirective.RepeatPerform;
            EngOrderNo = sourceDirective.EngeneeringOrders;
            JobCardNo = sourceDirective.JobCardNo;

            bool permission = currentDirective.HasPermission(Users.CurrentUser, DataEvent.Update);

            textboxTitle.ReadOnly = !permission;
            textBoxReferences.ReadOnly = !permission;
            textboxTLPNo.ReadOnly = !permission;
            textboxReqirement.ReadOnly = !permission;
            labelNotifyBefore.Enabled = permission;
            lifelengthViewerNotifyBefore.ReadOnly = !permission;
            lifelengthViewerFrequency.ReadOnly = !permission;
            textboxRemarks.ReadOnly = !permission;
            textboxHiddenRemarks.ReadOnly = !permission;
            textboxEngOrderNo.ReadOnly = !permission;
            textboxJobCardNo.ReadOnly = !permission;
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
                SaveData(currentDirective, true);
            }
        }

        #endregion

        #region  public void SaveData(BaseDetailDirective destinationDirective, bool changePageName)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        /// <param name="changePageName">Менять ли название вкладки</param>
        public void SaveData(BaseDetailDirective destinationDirective, bool changePageName)
        {
            textboxReqirement.Focus();
            if (destinationDirective == null) 
                throw new ArgumentNullException("destinationDirective");

            if (destinationDirective.Title != Title)
            {
                destinationDirective.Title = Title;
                if (changePageName)
                {
                    string caption = "";
                    //if (destinationDirective.Parent.Parent is Aircraft)
                    if (destinationDirective.Parent is BaseDetail)
                    {
                        BaseDetail baseDetail = (BaseDetail)destinationDirective.Parent;
                        if (baseDetail is AircraftFrame)
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " +
                                destinationDirective.DirectiveType.CommonName + ". " +
                                ((destinationDirective.Title.Length > 20)
                                ? destinationDirective.Title.Substring(0, 20)
                                : destinationDirective.Title);
                        else
                            caption = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " +
                                      destinationDirective.DirectiveType.CommonName + ". " +
                                      ((destinationDirective.Title.Length > 20)
                                           ? destinationDirective.Title.Substring(0, 20)
                                           : destinationDirective.Title);
                    }
                    if (DisplayerRequested != null)
                        DisplayerRequested(this, new ReferenceEventArgs(null, ReflectionTypes.ChangeTextOfContainingDisplayer, caption));
                }
            }
            if (destinationDirective.Description != Requirement)
                destinationDirective.Description = Requirement;
            if (destinationDirective.References != References)
                destinationDirective.References = References;
            if (destinationDirective.Applicability != TLPNo)
                destinationDirective.Applicability = TLPNo;
            if (destinationDirective.Remarks != Remarks)
                destinationDirective.Remarks = Remarks;
            if (destinationDirective.HiddenRemarks != HiddenRemarks)
                destinationDirective.HiddenRemarks = HiddenRemarks;
            if (destinationDirective.JobCardNo != JobCardNo)
                destinationDirective.JobCardNo = JobCardNo;
            if (destinationDirective.EngeneeringOrders != EngOrderNo)
                destinationDirective.EngeneeringOrders = EngOrderNo;



            lifelengthViewerNotifyBefore.SaveData(destinationDirective.Notification);
            lifelengthViewerFrequency.SaveData(destinationDirective.RepeatPerform);
            destinationDirective.FirstPerformSinceNew = new Lifelength(lifelengthViewerFrequency.Lifelength);
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            Title = "";
            References = "";
            TLPNo = "";
            Requirement = "";
            Remarks = "";
            HiddenRemarks = "";
            EngOrderNo = "";
            JobCardNo = "";
            lifelengthViewerNotifyBefore.Lifelength = new Lifelength();
            lifelengthViewerFrequency.Lifelength = new Lifelength();
        }

        #endregion
        
        #region public bool CheckLifelengthes()

        /// <summary>
        /// Проверяется корректность введенных данных о наработках
        /// </summary>
        /// <returns></returns>
        public bool CheckLifelengthes()
        {
            return
                lifelengthViewerNotifyBefore.ValidateData() && lifelengthViewerFrequency.ValidateData();
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