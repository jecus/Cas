using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления - вкладка с информацией о рабочей карте
    /// </summary>
    public class JobCardTabPageControl : Control
    {
        
        #region Fields

        private readonly JobCard currentJobCard;
        private readonly MaintenanceSubCheck parentMaintenanceSubCheck;
        private readonly NonRoutineJob nonRoutineJob;
        private readonly DetailDirective detailDirective;
        private readonly BaseDetailDirective directive;
        private readonly AbstractDetail detail;

        private readonly Label labelJobCard = new Label();
        private readonly Label labelWorkArea = new Label();
        private readonly Label labelRevision = new Label();
        private readonly Label labelDate = new Label();
        private readonly Label labelRemarks = new Label();
        private readonly Label labelManHours = new Label();
        private readonly Label labelCost = new Label();
        private readonly Label labelKitRequired = new Label();
        private readonly TextBox textBoxJobCard = new TextBox();
        private readonly TextBox textBoxWorkArea = new TextBox();
        private readonly TextBox textBoxRevision = new TextBox();
        private readonly DateTimePicker dateTimePickerDate = new DateTimePicker();
        private readonly TextBox textBoxManHours = new TextBox();
        private readonly TextBox textBoxCost = new TextBox();
        private readonly TextBox textBoxKitRequired = new TextBox();
        private readonly TextBox textBoxRemarks = new TextBox();
        private readonly PictureBox pictureBoxPDF = new PictureBox();
        private readonly Label labelDescription = new Label();
        private readonly LinkLabel linkLabelBrowse = new LinkLabel();
        private readonly LinkLabel linkLabelOpen = new LinkLabel();
        private readonly LinkLabel linkLabelRemove = new LinkLabel();
        private readonly Label labelSeparator = new Label();
        private readonly Label labelSeparator2 = new Label();
        private readonly Label labelSeparator3 = new Label();

        private ScreenMode mode;
        private readonly Icons icons = new Icons();
        private readonly bool permissionForUpdate = true;
        private byte[] pdfFileData;
        private bool pdfFileDataChanged = false;

        #endregion

        #region Constructors

        #region public JobCardTabPageControl(NonRoutineJob nonRoutineJob)

        /// <summary>
        /// Создает вкладку для привязывания Non-Routine Job к рабочей карте
        /// </summary>
        /// <param name="nonRoutineJob">Non Routine Job</param>
        public JobCardTabPageControl(NonRoutineJob nonRoutineJob)
        {
            this.nonRoutineJob = nonRoutineJob;
            currentJobCard = new JobCard();
            currentJobCard.Date = DateTime.Today;
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public JobCardTabPageControl(DetailDirective detailDirective)

        /// <summary>
        /// Создает вкладку для привязывания Detail Directive к рабочей карте
        /// </summary>
        /// <param name="detailDirective"></param>
        public JobCardTabPageControl(DetailDirective detailDirective)
        {
            this.detailDirective = detailDirective;
            currentJobCard = new JobCard();
            currentJobCard.Date = DateTime.Today;
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public JobCardTabPageControl(DetailDirective detailDirective)

        /// <summary>
        /// Создает вкладку для привязывания Abstartct Detail к рабочей карте
        /// </summary>
        /// <param name="detail"></param>
        public JobCardTabPageControl(AbstractDetail detail)
        {
            this.detail = detail;
            currentJobCard = new JobCard();
            currentJobCard.Date = DateTime.Today;
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public JobCardTabPageControl(BaseDetailDirective directive)

        /// <summary>
        /// Создает вкладку для привязывания Detail Directive к рабочей карте
        /// </summary>
        /// <param name="directive"></param>
        public JobCardTabPageControl(BaseDetailDirective directive)
        {
            this.directive = directive;
            currentJobCard = new JobCard();
            currentJobCard.Date = DateTime.Today;
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion
        
        #region public JobCardTabPageControl(MaintenanceSubCheck maintenanceSubCheck, string dialogFileName)

        /// <summary>
        /// Создает вкладку с информацией о рабочей карте
        /// </summary>
        /// <param name="maintenanceSubCheck"></param>
        /// <param name="dialogFileName"></param>
        public JobCardTabPageControl(MaintenanceSubCheck maintenanceSubCheck, string dialogFileName)
        {
            parentMaintenanceSubCheck = maintenanceSubCheck;
            currentJobCard = new JobCard();
            currentJobCard.Date = DateTime.Today;
            currentJobCard.AttachedFile.FileData= UsefulMethods.GetByteArrayFromFile(dialogFileName);
            string cardNumber = dialogFileName.Substring(dialogFileName.LastIndexOf('\\') + 1);
            textBoxJobCard.Text = cardNumber.Substring(0, cardNumber.LastIndexOf('.'));
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public JobCardTabPageControl(MaintenanceJobCard maintenanceJobCard)

        /// <summary>
        /// Создает вкладку с информацией о рабочей карте
        /// </summary>
        /// <param name="jobCard"></param>
        public JobCardTabPageControl(JobCard jobCard)
        {
            currentJobCard = jobCard;
            mode = ScreenMode.Edit;
            InitializeComponent();

            permissionForUpdate = currentJobCard.HasPermission(Users.CurrentUser, DataEvent.Update);
            textBoxJobCard.ReadOnly = !permissionForUpdate;
            textBoxWorkArea.ReadOnly = !permissionForUpdate;
            textBoxRevision.ReadOnly = !permissionForUpdate;
            dateTimePickerDate.Enabled = permissionForUpdate;
            textBoxRemarks.ReadOnly = !permissionForUpdate;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public string JobCardName

        /// <summary>
        /// Возвращает или устанавливает название Job Card
        /// </summary>
        public string JobCardName
        {
            get
            {
                return textBoxJobCard.Text;
            }
            set
            {
                textBoxJobCard.Text = value;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            //
            // labelJobCard
            //
            labelJobCard.Font = Css.WindowsForm.Fonts.RegularFont;
            labelJobCard.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelJobCard.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelJobCard.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelJobCard.Text = "Job Card:";
            labelJobCard.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxJobCard
            //
            textBoxJobCard.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxJobCard.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxJobCard.BackColor = Color.White;
            textBoxJobCard.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN + Css.WindowsForm.Constants.DefaultLabelSize.Width, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxJobCard.Multiline = true;
            textBoxJobCard.Height = Css.WindowsForm.Constants.TEXT_BOX_WITH_PICTURE_BOX_HEIGHT;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxJobCard.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelWorkArea
            //
            labelWorkArea.Font = Css.WindowsForm.Fonts.RegularFont;
            labelWorkArea.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelWorkArea.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelWorkArea.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelWorkArea.Text = "Work Area:";
            labelWorkArea.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxWorkArea
            //
            textBoxWorkArea.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxWorkArea.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxWorkArea.BackColor = Color.White;
            textBoxWorkArea.Location = new Point(labelWorkArea.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelWorkArea.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dateTimePickerDate
            //
            dateTimePickerDate.Font = Css.WindowsForm.Fonts.RegularFont;
            dateTimePickerDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            dateTimePickerDate.BackColor = Color.White;
            dateTimePickerDate.Location = new Point(labelDate.Right, labelWorkArea.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            dateTimePickerDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerDate.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            //
            // labelRevision
            //
            labelRevision.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRevision.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRevision.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelRevision.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRevision.Text = "Revision:";
            labelRevision.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRevision
            //
            textBoxRevision.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRevision.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRevision.BackColor = Color.White;
            textBoxRevision.Location = new Point(labelRevision.Right, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelRevision.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Location = new Point(labelRemarks.Right, labelRevision.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxRemarks.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelManHours
            //
            labelManHours.Font = Css.WindowsForm.Fonts.RegularFont;
            labelManHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelManHours.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelManHours.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelManHours.Text = "Man Hours:";
            labelManHours.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxManHours
            //
            textBoxManHours.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxManHours.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxManHours.BackColor = Color.White;
            textBoxManHours.Location = new Point(labelManHours.Right, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelCost
            //
            labelCost.Font = Css.WindowsForm.Fonts.RegularFont;
            labelCost.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelCost.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelManHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelCost.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelCost.Text = "Cost:";
            labelCost.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxCost
            //
            textBoxCost.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxCost.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxCost.BackColor = Color.White;
            textBoxCost.Location = new Point(labelCost.Right, labelManHours.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
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
            // labelSeparator3
            //
            labelSeparator3.AutoSize = false;
            labelSeparator3.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxKitRequired.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator3.Height = 2;
            labelSeparator3.BorderStyle = BorderStyle.Fixed3D;
            //
            // pictureBoxPDF
            //
            pictureBoxPDF.BackgroundImage = icons.PDFSmall;
            pictureBoxPDF.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxPDF.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            pictureBoxPDF.Size = Css.WindowsForm.Constants.DefaultPictureBoxSize;
            //
            // labelDescription
            //
            labelDescription.AutoSize = true;
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(pictureBoxPDF.Right + Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator3.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDescription.SizeChanged += labelDescription_SizeChanged;
            //
            // linkLabelBrowse
            //
            linkLabelBrowse.AutoSize = true;
            linkLabelBrowse.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelBrowse.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelBrowse.Text = "Browse";
            linkLabelBrowse.LinkClicked += linkLabelBrowse_LinkClicked;
            //
            // linkLabelOpen
            //
            linkLabelOpen.AutoSize = true;
            linkLabelOpen.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelOpen.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelOpen.Text = "Open";
            linkLabelOpen.LinkClicked += linkLabelOpen_LinkClicked;
            //
            // linkLabelRemove
            //
            linkLabelRemove.AutoSize = true;
            linkLabelRemove.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelRemove.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelRemove.Text = "Remove";
            linkLabelRemove.LinkClicked += linkLabelRemove_LinkClicked;
            // 
            // BiWeeklyForm
            // 
            BackColor = Css.WindowsForm.Colors.TabBackColor;
            Controls.Add(labelJobCard);
            Controls.Add(textBoxJobCard);
            Controls.Add(labelSeparator);
            Controls.Add(labelWorkArea);
            Controls.Add(textBoxWorkArea);
            Controls.Add(labelDate);
            Controls.Add(dateTimePickerDate);
            Controls.Add(labelRevision);
            Controls.Add(textBoxRevision);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(labelSeparator2);
            Controls.Add(labelManHours);
            Controls.Add(textBoxManHours);
            Controls.Add(labelCost);
            Controls.Add(textBoxCost);
            Controls.Add(labelKitRequired);
            Controls.Add(textBoxKitRequired);
            Controls.Add(labelSeparator3);
            Controls.Add(pictureBoxPDF);
            Controls.Add(labelDescription);
            Controls.Add(linkLabelBrowse);
            Controls.Add(linkLabelOpen);
            Controls.Add(linkLabelRemove);

        }

        #endregion

        #region private bool GetChangeStatus()

        private bool GetChangeStatus()
        {
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return false;
            if (!CheckCost(out cost))
                return false;
            return (textBoxJobCard.Text != currentJobCard.AirlineCardNumber ||
                    textBoxWorkArea.Text != currentJobCard.WorkArea ||
                    textBoxRevision.Text != currentJobCard.Revision ||
                    dateTimePickerDate.Value != currentJobCard.Date ||
                    textBoxRemarks.Text != currentJobCard.Remarks ||
                    currentJobCard.ManHours != manHours ||
                    currentJobCard.Cost != cost ||
                    currentJobCard.KitRequired != textBoxKitRequired.Text ||
                    pdfFileDataChanged);
                
        }

        #endregion
        
        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные
        /// </summary>
        public void UpdateInformation()
        {
            textBoxJobCard.Text = currentJobCard.AirlineCardNumber;
            textBoxWorkArea.Text = currentJobCard.WorkArea;
            textBoxRevision.Text = currentJobCard.Revision;
            dateTimePickerDate.Value = currentJobCard.Date;
            textBoxRemarks.Text = currentJobCard.Remarks;
            if (Math.Abs(currentJobCard.ManHours) > 0.000001)
                textBoxManHours.Text = Math.Round(currentJobCard.ManHours, 2).ToString();
            if (Math.Abs(currentJobCard.Cost) > 0.000001)
                textBoxCost.Text = Math.Round(currentJobCard.Cost, 2).ToString();
            textBoxKitRequired.Text = currentJobCard.KitRequired;
            pdfFileData = currentJobCard.AttachedFile.FileData;
            pdfFileDataChanged = false;
            UpdateDescription();
        }

        #endregion

        #region private void UpdateDescription()

        private void UpdateDescription()
        {
            if (pdfFileData == null)
            {
                labelDescription.Text = "This Job Card does not contain PDF file describing the works under this Job Card. Enclose PDF file to describe the works under this Job Card.";
                linkLabelBrowse.Visible = true;
                linkLabelOpen.Visible = false;
                linkLabelRemove.Visible = false;
            }
            else
            {
                labelDescription.Text = "PDF file includes detailed information about the works under this Job Card." + Environment.NewLine + "File name: " + currentJobCard.AirlineCardNumber + ".pdf" + Environment.NewLine + "Size: " + (pdfFileData.Length/1024) + " KB";
                linkLabelBrowse.Visible = false;
                linkLabelOpen.Visible = true;
                linkLabelRemove.Visible = true;
            }
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохраняет данные
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            bool createJobCard = (parentMaintenanceSubCheck == null && GetChangeStatus());
            double manHours;
            double cost;
            if (!CheckManHours(out manHours))
                return false;
            if (!CheckCost(out cost))
                return false;
            if (textBoxJobCard.Text != currentJobCard.AirlineCardNumber || textBoxWorkArea.Text != currentJobCard.WorkArea)
            {
                currentJobCard.AirlineCardNumber = textBoxJobCard.Text;
                currentJobCard.WorkArea = textBoxWorkArea.Text;
            }
            if (textBoxRevision.Text != currentJobCard.Revision)
                currentJobCard.Revision = textBoxRevision.Text;
            if (dateTimePickerDate.Value != currentJobCard.Date)
                currentJobCard.Date = dateTimePickerDate.Value;
            if (textBoxRemarks.Text != currentJobCard.Remarks)
                currentJobCard.Remarks = textBoxRemarks.Text;
            if (currentJobCard.ManHours != manHours)
                currentJobCard.ManHours = manHours;
            if (currentJobCard.Cost != cost)
                currentJobCard.Cost = cost;
            if (currentJobCard.KitRequired != textBoxKitRequired.Text)
                currentJobCard.KitRequired = textBoxKitRequired.Text;
            if (pdfFileDataChanged)
            {
                currentJobCard.AttachedFile.FileData = pdfFileData;
                currentJobCard.AttachedFile.FileName = currentJobCard.AirlineCardNumber;
            }

            try
            {
                if (mode == ScreenMode.Edit)
                    currentJobCard.Save();
                else
                {
                    if (parentMaintenanceSubCheck != null)
                    {
                        parentMaintenanceSubCheck.AddJobCard(currentJobCard);
                        mode = ScreenMode.Edit;
                    }
                    else if (createJobCard)
                    {
                        if (nonRoutineJob != null)
                            nonRoutineJob.JobCard = currentJobCard;
                        else if (detailDirective != null)
                            detailDirective.JobCard = currentJobCard;
                        else if (detail != null)
                            detail.JobCard = currentJobCard;
                        else
                            directive.JobCard = currentJobCard;
                        mode = ScreenMode.Edit;
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); return false;
            }

            if (Saved != null)
                Saved(this, EventArgs.Empty);
            return true;
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
            if (textBoxManHours.Text == "")
            {
                manHours = 0;
                return true;
            }
            if (double.TryParse(textBoxManHours.Text, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
            {
                MessageBox.Show("Man Hours. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region public bool CheckCost(out double cost)

        /// <summary>
        /// Проверяет значение Cost
        /// </summary>
        /// <param name="cost">Значение Cost</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        public bool CheckCost(out double cost)
        {
            if (textBoxCost.Text == "")
            {
                cost = 0;
                return true;
            }
            if (double.TryParse(textBoxCost.Text, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
            {
                MessageBox.Show("Cost. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void labelDescription_SizeChanged(object sender, EventArgs e)

        private void labelDescription_SizeChanged(object sender, EventArgs e)
        {
            linkLabelBrowse.Location =
                linkLabelOpen.Location = new Point(labelDescription.Left, labelDescription.Bottom);
            linkLabelRemove.Location = new Point(labelDescription.Left, linkLabelOpen.Bottom);
        }

        #endregion

        #region private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pdfFileData = UsefulMethods.GetByteArrayFromFile(dialog.FileName);
                pdfFileDataChanged = true;
                UpdateDescription();
                if (textBoxJobCard.Text == "")
                {
                    string fileName = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                    if (fileName.LastIndexOf('.') == -1)
                        textBoxJobCard.Text = fileName;
                    else
                        textBoxJobCard.Text = fileName.Substring(0, fileName.LastIndexOf('.'));
                }
            }
        }

        #endregion

        #region private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thread = new Thread(OpenAttachmentData);
            thread.Start();
        }

        #endregion

        #region private void OpenAttachmentData()

        private void OpenAttachmentData()
        {
            if (SaveAttachmentData())
            {
                string fileName = TermsProvider.GetTempFolderPath() + "\\" + currentJobCard.AirlineCardNumber + ".pdf";
                if (File.Exists(fileName))
                {
                    Process tempProcess = new Process();
                    tempProcess.StartInfo.FileName = fileName;
                    try
                    {
                        tempProcess.Start();
                        tempProcess.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while loading data", ex);
                    }
                    try
                    {

                        TryDeleteFile();
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex); 
                        
                    }
                }
            }
        }

        #endregion

        #region private bool SaveAttachmentData()

        private bool SaveAttachmentData()
        {
            try
            {
                string fileName = TermsProvider.GetTempFolderPath() + "\\" + currentJobCard.AirlineCardNumber + ".pdf";
                FileStream fileStreamBack = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fileStreamBack.Write(pdfFileData, 0, pdfFileData.Length);
                fileStreamBack.Close();
                return true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); 
                return false;
            }
        }

        #endregion

        #region private void TryDeleteFile()

        private void TryDeleteFile()
        {
            string fileName = TermsProvider.GetTempFolderPath() + "\\" + currentJobCard.AirlineCardNumber + ".pdf";
            while (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
            Thread.CurrentThread.Abort();
        }

        #endregion

        #region private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pdfFileData = null;
            pdfFileDataChanged = true;
            UpdateDescription();
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
            textBoxJobCard.Width =
                textBoxWorkArea.Width =
                dateTimePickerDate.Width =
                textBoxRevision.Width =
                textBoxRemarks.Width =
                textBoxManHours.Width =
                textBoxCost.Width =
                textBoxKitRequired.Width = Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelDescription.MinimumSize = new Size(Width - Css.WindowsForm.Constants.DefaultPictureBoxSize.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN * 2 - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 0);
            labelDescription.MaximumSize = new Size(Width - Css.WindowsForm.Constants.DefaultPictureBoxSize.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN * 2 - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 300);
            labelSeparator.Width =
                labelSeparator2.Width =
                labelSeparator3.Width = Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            labelDescription_SizeChanged(this, e);
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// Событие сохранения данных
        /// </summary>
        public event EventHandler Saved;

        #endregion

    }
}