using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.UIControls.WorkPackages
{
    /// <summary>
    /// ‘орма дл€ редактировани€ свойств нестандартных работ
    /// </summary>
    public class NonRoutineJobForm : Form
    {

        #region Fields

        private readonly WorkPackage parentWorkPackage;
        private NonRoutineJob currentNonRoutineJob;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private TabPage tabPageJobCard;
        private JobCardTabPageControl jobCardControl;

        private Label labelATAChapter;
        private Label labelTitle;
        private Label labelDescription;
        private Label labelManHours;
        private Label labelCost;
        private Label labelKitRequired;
        private ATAChapterComboBox comboBoxATAChapter;
        private TextBox textBoxTitle;
        private TextBox textBoxDescription;
        private TextBox textBoxManHours;
        private TextBox textBoxCost;
        private TextBox textBoxKitRequired;
        private readonly Label labelSeparator = new Label();
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        #endregion

        #region Constructors

        #region public NonRoutineJobForm(WorkPackage parentWorkPackage)

        /// <summary>
        /// —оздает форму дл€ добавлени€ нестандартной работы
        /// </summary>
        /// <param name="parentWorkPackage">–абочий пакет, к которому добавл€етс€ нестандартна€ работа</param>
        public NonRoutineJobForm(WorkPackage parentWorkPackage)
        {
            this.parentWorkPackage = parentWorkPackage;
            currentNonRoutineJob = new NonRoutineJob();
            mode = ScreenMode.Add;
            InitializeComponent();
        }

        #endregion
        
        #region public NonRoutineJobForm(NonRoutineJob currentNonRoutineJob)

        /// <summary>
        /// —оздает форму дл€ редактировани€ свойств нестандартных работ
        /// </summary>
        /// <param name="currentNonRoutineJob">“екуща€ нестандартна€ работа</param>
        public NonRoutineJobForm(NonRoutineJob currentNonRoutineJob)
        {
            this.currentNonRoutineJob = currentNonRoutineJob;
            mode = ScreenMode.Edit;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion
        
        #endregion

        #region Properties

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATAChapter текущей работы
        /// </summary>
        public ATAChapter ATAChapter
        {
            get
            {
                return comboBoxATAChapter.ATAChapter;
            }
            set
            {
                comboBoxATAChapter.ATAChapter = value;
            }
        }

        #endregion

        #region public string Title

        /// <summary>
        /// »м€ текущей работы
        /// </summary>
        public string Title
        {
            get
            {
                return textBoxTitle.Text;
            }
            set
            {
                textBoxTitle.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// ќписание текущей работы
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Text; }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region public double Manhours

        /// <summary>
        /// Manhours текущей работы
        /// </summary>
        public double Manhours
        {
            get
            {
                double d;
                double.TryParse(textBoxManHours.Text, out d);
                return d;
            }
            set
            {
                currentNonRoutineJob.ManHours = value;
                if (Math.Abs(value) > 0.000001)
                    textBoxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string ManhoursString

        /// <summary>
        /// Manhours текущей работы
        /// </summary>
        public string ManhoursString
        {
            get
            {
                return textBoxManHours.Text;
            }
            set
            {
                textBoxManHours.Text = value;
            }
        }

        #endregion

        #region public double Cost

        /// <summary>
        /// Cost текущей работы
        /// </summary>
        public double Cost
        {
            get
            {
                double d;
                double.TryParse(textBoxCost.Text, out d);
                return d;
            }
            set
            {
                currentNonRoutineJob.Cost = value;
                if (Math.Abs(value) > 0.000001)
                    textBoxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public string CostString

        /// <summary>
        /// Cost текущей работы
        /// </summary>
        public string CostString
        {
            get
            {
                return textBoxCost.Text;
            }
            set
            {
                textBoxCost.Text = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelATAChapter = new Label();
            labelTitle = new Label();
            labelDescription = new Label();
            labelManHours = new Label();
            labelCost = new Label();
            labelKitRequired = new Label();
            comboBoxATAChapter = new ATAChapterComboBox();
            textBoxDescription = new TextBox();
            textBoxTitle = new TextBox();
            textBoxManHours = new TextBox();
            textBoxCost = new TextBox();
            textBoxKitRequired = new TextBox();
            buttonOK = new Button();
            buttonApply = new Button();
            buttonCancel = new Button();

            tabControl = new TabControl();
            tabPageGeneral = new TabPage();
            tabPageJobCard = new TabPage();
            if (currentNonRoutineJob.JobCard == null)
                jobCardControl = new JobCardTabPageControl(currentNonRoutineJob);
            else 
                jobCardControl = new JobCardTabPageControl(currentNonRoutineJob.JobCard);
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageGeneral);
            tabControl.Controls.Add(tabPageJobCard);
            tabControl.Location = new Point(Css.WindowsForm.Constants.LEFT_MARGIN, Css.WindowsForm.Constants.TOP_MARGIN);
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(labelATAChapter);
            tabPageGeneral.Controls.Add(comboBoxATAChapter);
            tabPageGeneral.Controls.Add(labelTitle);
            tabPageGeneral.Controls.Add(textBoxTitle);
            tabPageGeneral.Controls.Add(labelDescription);
            tabPageGeneral.Controls.Add(textBoxDescription);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelManHours);
            tabPageGeneral.Controls.Add(textBoxManHours);
            tabPageGeneral.Controls.Add(labelCost);
            tabPageGeneral.Controls.Add(textBoxCost);
            tabPageGeneral.Controls.Add(labelKitRequired);
            tabPageGeneral.Controls.Add(textBoxKitRequired);
            // 
            // tabPageJobCard
            // 
            tabPageJobCard.BackColor = Css.WindowsForm.Colors.TabBackColor;
            tabPageJobCard.Text = "Job Card";
            tabPageJobCard.Controls.Add(jobCardControl);
            //
            // labelATAChapter
            //
            labelATAChapter.Font = Css.WindowsForm.Fonts.RegularFont;
            labelATAChapter.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelATAChapter.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelATAChapter.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelATAChapter.Text = "ATA chapter:";
            labelATAChapter.TextAlign = ContentAlignment.MiddleLeft;
            //
            // comboBoxATAChapter
            //
            comboBoxATAChapter.BackColor = Color.White;
            comboBoxATAChapter.Font = Css.WindowsForm.Fonts.RegularFont;
            comboBoxATAChapter.ForeColor = Css.WindowsForm.Colors.ForeColor;
            comboBoxATAChapter.Location = new Point(labelATAChapter.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            // 
            // labelTitle
            // 
            labelTitle.Font = Css.WindowsForm.Fonts.RegularFont;
            labelTitle.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelTitle.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelATAChapter.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelTitle.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelTitle.Text = "Title:";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxTitle
            // 
            textBoxTitle.BackColor = Color.White;
            textBoxTitle.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxTitle.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxTitle.Location = new Point(labelTitle.Right, labelATAChapter.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            // 
            // labelDescription
            // 
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelTitle.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDescription.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDescription.Location = new Point(labelDescription.Right, labelTitle.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxDescription.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.WindowsForm.Fonts.RegularFont;
            labelManHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelManHours.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelManHours.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelManHours.Text = "Man Hours:";
            labelManHours.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxManHours
            // 
            textBoxManHours.BackColor = Color.White;
            textBoxManHours.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxManHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxManHours.Location = new Point(labelManHours.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //textBoxManHours.Validating += textBoxManHours_Validating;
            // 
            // labelCost
            // 
            labelCost.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCost.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCost.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelManHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelCost.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelCost.Text = "Cost (USD):";
            labelCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCost
            // 
            textBoxCost.BackColor = Color.White;
            textBoxCost.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCost.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCost.Location = new Point(labelCost.Right, labelManHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        //    textBoxCost.Validating += textBoxCost_Validating;
            // 
            // labelKitRequired
            // 
            labelKitRequired.Font = Css.WindowsForm.Fonts.RegularFont;
            labelKitRequired.ForeColor = Css.WindowsForm.Colors.ForeColor; 
            labelKitRequired.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxCost.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelKitRequired.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelKitRequired.Text = "Kit Required:";
            labelKitRequired.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxKitRequired
            // 
            textBoxKitRequired.BackColor = Color.White;
            textBoxKitRequired.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxKitRequired.ForeColor = Css.WindowsForm.Colors.ForeColor; 
            textBoxKitRequired.Location = new Point(labelKitRequired.Right, textBoxCost.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
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


            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = Css.WindowsForm.Constants.DefaultFormSize;
            UpdateFormName();
            StartPosition = FormStartPosition.CenterScreen; //todo
            Controls.Add(tabControl);
            Controls.Add(buttonOK);
            Controls.Add(buttonApply);
            Controls.Add(buttonCancel);
        }

        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            ATAChapter = currentNonRoutineJob.AtaChapter;
            Title = currentNonRoutineJob.Title;
            Description = currentNonRoutineJob.Description;
            Manhours = currentNonRoutineJob.ManHours;
            Cost = currentNonRoutineJob.Cost;
            textBoxKitRequired.Text = currentNonRoutineJob.KitRequired;
            if (currentNonRoutineJob.JobCard != null)
                jobCardControl.UpdateInformation();
        }

        #endregion

        #region private void UpdateFormName()

        private void UpdateFormName()
        {
            if (mode == ScreenMode.Edit)
                Text = ((WorkPackage)currentNonRoutineJob.Parent).Title + ". " + currentNonRoutineJob.Title;
            else
                Text = parentWorkPackage.Title + ". New Non-Routine Job";
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// ƒанные работы обновл€ютс€ по введенным значени€м
        /// </summary>
        private bool SaveData()
        {
            if (mode == ScreenMode.Add)
                currentNonRoutineJob = new NonRoutineJob();
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return false;
            if (!CheckCost(out cost))
                return false;
            if (ATAChapter == null)
                currentNonRoutineJob.AtaChapter = ATAChapterCollection.Instance.GetByID(21);//todo N/A глава
            else if (currentNonRoutineJob.AtaChapter != ATAChapter)
                currentNonRoutineJob.AtaChapter = ATAChapter;
            if (currentNonRoutineJob.Title != Title)
            {
                currentNonRoutineJob.Title = Title;
                UpdateFormName();
            }
            if (currentNonRoutineJob.Description != Description)
                currentNonRoutineJob.Description = Description;
            if (currentNonRoutineJob.ManHours != manHours)
                currentNonRoutineJob.ManHours = manHours;
            if (currentNonRoutineJob.Cost != cost)
                currentNonRoutineJob.Cost = cost;
            if (currentNonRoutineJob.KitRequired != textBoxKitRequired.Text)
                currentNonRoutineJob.KitRequired = textBoxKitRequired.Text;
            try
            {
                if (mode == ScreenMode.Edit)
                {
                    currentNonRoutineJob.Save(true);
                    if (Saved != null)
                        Saved(currentNonRoutineJob);
                }
                else if (mode == ScreenMode.Add)
                {
                    parentWorkPackage.AddItem(currentNonRoutineJob);
                    mode = ScreenMode.Edit;
                    UpdateFormName();
                    if (Added != null)
                        Added(currentNonRoutineJob);
                }
             //   jobCardControl.NonRoutineJob = currentNonRoutineJob;
                if (jobCardControl.JobCardName == "")
                    jobCardControl.JobCardName = ((Aircraft) currentNonRoutineJob.Parent.Parent).RegistrationNumber + ". " + ((WorkPackage) currentNonRoutineJob.Parent).Title + ". " + textBoxTitle.Text;
                if (!jobCardControl.SaveData())
                    return false;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); 
                return false;
            }
            return true;
        }
        #endregion

        #region public bool CheckManHours(out double manHours)

        /// <summary>
        /// ѕровер€ет значение ManHours
        /// </summary>
        /// <param name="manHours">«начение ManHours</param>
        /// <returns>¬озвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
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

        #region public bool CheckCost(out double cost)

        /// <summary>
        /// ѕровер€ет значение Cost
        /// </summary>
        /// <param name="cost">«начение Cost</param>
        /// <returns>¬озвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckCost(out double cost)
        {
            if (CostString == "")
            {
                cost = 0;
                return true;
            }
            if (double.TryParse(CostString, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            jobCardControl.Size = tabControl.Size;
            comboBoxATAChapter.Width =
            textBoxTitle.Width = 
            textBoxDescription.Width = 
            textBoxManHours.Width =
            textBoxCost.Width =
            textBoxKitRequired.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// ќбработчик событий при сохранении и добавлении нестандартных работ
        /// </summary>
        /// <param name="job"></param>
        public delegate void SavedEventHandler(NonRoutineJob job);

        #endregion

        #region Events

        /// <summary>
        /// —обытие сохранени€ нестандартной работы
        /// </summary>
        public event SavedEventHandler Saved;
        /// <summary>
        /// —обытие добавлени€ нестандартной работы
        /// </summary>
        public event SavedEventHandler Added;

        #endregion

    }
}

