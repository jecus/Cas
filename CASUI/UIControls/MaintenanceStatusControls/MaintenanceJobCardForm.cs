using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Форма, для отображения информации о JobCard
    /// </summary>
    public class MaintenanceJobCardForm : Form
    {
        
        #region Fields

        private readonly JobCard currentJobCard;
        private readonly MaintenanceSubCheck parentMaintenanceSubCheck;
        private readonly DetailDirective detailDirective;
        private readonly BaseDetailDirective directive;
        private readonly AbstractDetail detail;
        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private readonly JobCardTabPageControl jobCardControl;
        private readonly Button buttonApply = new Button();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();

        private readonly ScreenMode mode;

        #endregion

        #region Constructors

        #region public MaintenanceJobCardForm(MaintenanceSubCheck maintenanceSubCheck, string dialogFileName)

        /// <summary>
        /// Создает форму для добавления <see cref="JobCard"/>
        /// </summary>
        /// <param name="maintenanceSubCheck"></param>
        /// <param name="dialogFileName"></param>
        public MaintenanceJobCardForm(MaintenanceSubCheck maintenanceSubCheck, string dialogFileName)
        {
            parentMaintenanceSubCheck = maintenanceSubCheck;
            currentJobCard = new JobCard();
            mode = ScreenMode.Add;
            jobCardControl = new JobCardTabPageControl(maintenanceSubCheck, dialogFileName);
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceJobCardForm(MaintenanceJobCard maintenanceJobCard)

        /// <summary>
        /// Создает форму для отображения информации о <see cref="JobCard"/>
        /// </summary>
        /// <param name="jobCard"></param>
        public MaintenanceJobCardForm(JobCard jobCard)
        {
            currentJobCard = jobCard;
            mode = ScreenMode.Edit;
            jobCardControl = new JobCardTabPageControl(currentJobCard);
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public MaintenanceJobCardForm(DetailDirective detailDirective)

        /// <summary>
        /// Создает форму для отображения информации о <see cref="JobCard"/>
        /// </summary>
        /// <param name="detailDirective"></param>
        public MaintenanceJobCardForm(DetailDirective detailDirective)
        {
            this.detailDirective = detailDirective;
            mode = ScreenMode.Edit;
            jobCardControl = new JobCardTabPageControl(detailDirective);
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public MaintenanceJobCardForm(AbstractDetail detail)

        /// <summary>
        /// Создает форму для отображения информации о <see cref="JobCard"/>
        /// </summary>
        /// <param name="detail"></param>
        public MaintenanceJobCardForm(AbstractDetail detail)
        {
            this.detail = detail;
            mode = ScreenMode.Edit;
            jobCardControl = new JobCardTabPageControl(detail);
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public MaintenanceJobCardForm(DetailDirective detailDirective)

        /// <summary>
        /// Создает форму для отображения информации о <see cref="JobCard"/>
        /// </summary>
        /// <param name="directive"></param>
        public MaintenanceJobCardForm(BaseDetailDirective directive)
        {
            this.directive = directive;
            mode = ScreenMode.Edit;
            jobCardControl = new JobCardTabPageControl(directive);
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "Job Card";
            tabPageGeneral.Controls.Add(jobCardControl);
            //
            // buttonOK
            //
            buttonOK.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonOK.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonOK.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonCancel.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            //
            // buttonApply
            //
            buttonApply.Font = Css.WindowsForm.Fonts.RegularFont;
            buttonApply.ForeColor = Css.WindowsForm.Colors.ForeColor;
            buttonApply.Size = new Size(Css.WindowsForm.Constants.BUTTON_WIDTH, Css.WindowsForm.Constants.BUTTON_HEIGHT);
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // BiWeeklyForm
            // 
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
            UpdateFormName();
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);
            Controls.Add(buttonApply);
        }

        #endregion

        #region private void UpdateInformation(bool reloadReport)

        private void UpdateInformation()
        {
            jobCardControl.UpdateInformation();
        }

        #endregion

        #region private void UpdateFormName()

        private void UpdateFormName()
        {
            if (detailDirective != null || detail != null || directive != null)
                Text = "New Job Card";
            else if (mode == ScreenMode.Edit)
            {
                if (currentJobCard.Parent.Parent.Parent.Parent is Aircraft)
                    Text = ((Aircraft) currentJobCard.Parent.Parent.Parent.Parent).RegistrationNumber + ". " + currentJobCard.AirlineCardNumber;
                else if (currentJobCard.Parent.Parent.Parent is Aircraft) 
                    Text = ((Aircraft)currentJobCard.Parent.Parent.Parent).RegistrationNumber + ". " + currentJobCard.AirlineCardNumber;
                else
                    Text = ((Aircraft)currentJobCard.Parent.Parent).RegistrationNumber + ". " + currentJobCard.AirlineCardNumber;
            }
            else
                Text = ((Aircraft)parentMaintenanceSubCheck.Parent.Parent.Parent).RegistrationNumber + ". " + parentMaintenanceSubCheck.Name + ". New Job Card";
        }

        #endregion

        #region private bool SaveData()

        private bool SaveData()
        {
            bool res = jobCardControl.SaveData();
            if (res)
            {
                UpdateFormName();
                if (Saved != null)
                    Saved(currentJobCard);
            }
            return res;
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (SaveData())
                UpdateInformation();
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (SaveData())
                Close();
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
            tabControl.Size = new Size(ClientSize.Width - Css.WindowsForm.Constants.LEFT_MARGIN - Css.WindowsForm.Constants.RIGHT_MARGIN,ClientSize.Height - Css.WindowsForm.Constants.TOP_MARGIN - Css.WindowsForm.Constants.BOTTOM_MARGIN - Css.WindowsForm.Constants.BUTTON_HEIGHT - Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            jobCardControl.Size = tabControl.Size;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// Обработчик событий при сохранении и добавлении рабочих карт
        /// </summary>
        /// <param name="job"></param>
        public delegate void SavedEventHandler(JobCard jobCard);

        #endregion

        #region Events

        /// <summary>
        /// Событие сохранения данных
        /// </summary>
        public event SavedEventHandler Saved;

        #endregion

    }
}