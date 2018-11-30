using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.MaintenanceStatusControls;
using CASTerms;
using Controls;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.DetailsControls
{

    ///<summary>
    /// Элемент управления, использующийся для редактирования информации Compliance/Performance
    ///</summary>
    public class DetailCompliancePerformanceControl : UserControl
    {
        
        #region Fields

        private readonly DetailDirective currentDetailDirective;

        private const int MARGIN = 10;
        private const int LIFELENGTH_VIEWER_WIDTH = 350;
        private const int DATE_TIME_PICKER_WIDTH = 250;
        private const int LABEL_WIDTH = LIFELENGTH_VIEWER_WIDTH - DATE_TIME_PICKER_WIDTH;
        private const int HEIGHT_INTERVAL = 15;
        private const int HEIGHT_LIFELENGTH_INTERVAL = HEIGHT_INTERVAL - 5;
        private const int LABEL_HEIGHT = 25;
        private const int BIG_TEXTBOX_HEIGHT = 100;
        private const int WIDTH_INTERVAL = 400 + MARGIN;
        private const int WIDTH_INTERVAL_SECOND = 800 + MARGIN;
        
        private StatusImageLinkLabel imageLinkLabelStatus;
        private Label labelManHours;
        private Label labelCost;
        private Label labelKitRequired;
        private Label labelRemarks;
        private LinkLabel linkLabelJobCard;
        private TextBox textBoxManHours;
        private TextBox textBoxCost;
        private TextBox textBoxKitRequired;
        private TextBox textBoxRemarks;
        //private WindowsFormAttachedFileControl fileControl;
        private Label labelInterval;
        private LifelengthViewer lifelengthViewerInterval;
        private Label labelNotify;
        private LifelengthViewer lifelengthViewerNotify;
        private Label labelNext;
        private LifelengthViewer lifelengthViewerNext;
        private Label labelRemains;
        private LifelengthViewer lifelengthViewerRemains;
        private LinkLabel linkLabelRemove;
        private Delimiter delimiter1;
        private Delimiter delimiter2;
        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructor

        #region public DetailCompliancePerformanceControl(DetailDirective detailDirective)

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования отдельной информации Compliance/Performance
        /// </summary>
        /// <param name="detailDirective">Работа агрегата</param>
        public DetailCompliancePerformanceControl(DetailDirective detailDirective)
        {
            currentDetailDirective = detailDirective;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Propeties

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

        #region public DetailDirective DetailDirective

        /// <summary>
        /// Возвращает работу агрегата
        /// </summary>
        public DetailDirective DetailDirective
        {
            get
            {
                return currentDetailDirective;
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
            
            imageLinkLabelStatus = new StatusImageLinkLabel();
            labelManHours = new Label();
            labelCost = new Label();
            labelKitRequired = new Label();
            labelRemarks = new Label();
            textBoxManHours = new TextBox();
            textBoxCost = new TextBox();
            textBoxKitRequired = new TextBox();
            textBoxRemarks = new TextBox();
            linkLabelJobCard = new LinkLabel();
          //  fileControl = new WindowsFormAttachedFileControl(null, "Adobe PDF Files|*.pdf",
           //         "This record does not contain a file proving the compliance. Enclose PDF file to prove the compliance.",
            //        "Attached file proves the compliance.", icons.PDFSmall);
            labelInterval = new Label();
            lifelengthViewerInterval = new LifelengthViewer();
            labelNotify = new Label();
            lifelengthViewerNotify = new LifelengthViewer();
            labelNext = new Label();
            lifelengthViewerNext = new LifelengthViewer();
            labelRemains = new Label();
            lifelengthViewerRemains = new LifelengthViewer();
            linkLabelRemove = new LinkLabel();
            delimiter1 = new Delimiter();
            delimiter2 = new Delimiter();
            //
            // imageLinkLabelStatus
            // 
            imageLinkLabelStatus.BackColor = Color.White;
            imageLinkLabelStatus.Font = Css.ImageLink.Fonts.Font;
            imageLinkLabelStatus.LinkColor = Css.ImageLink.Colors.LinkColor;
            imageLinkLabelStatus.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            imageLinkLabelStatus.Location = new Point(MARGIN, MARGIN);
            imageLinkLabelStatus.Enabled = false;
            // 
            // labelManHours
            // 
            labelManHours.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManHours.Location = new Point(MARGIN, imageLinkLabelStatus.Bottom + HEIGHT_INTERVAL);
            labelManHours.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelManHours.Text = "Man Hours:";
            labelManHours.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxManHours
            // 
            textBoxManHours.BackColor = Color.White;
            textBoxManHours.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxManHours.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManHours.Location = new Point(labelManHours.Right, imageLinkLabelStatus.Bottom + HEIGHT_INTERVAL);
            textBoxManHours.Width = DATE_TIME_PICKER_WIDTH;
            // 
            // labelCost
            // 
            labelCost.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCost.Location = new Point(MARGIN, textBoxManHours.Bottom + HEIGHT_INTERVAL);
            labelCost.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelCost.Text = "Cost (USD):";
            labelCost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCost
            // 
            textBoxCost.BackColor = Color.White;
            textBoxCost.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxCost.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxCost.Location = new Point(labelCost.Right, textBoxManHours.Bottom + HEIGHT_INTERVAL);
            textBoxCost.Width = DATE_TIME_PICKER_WIDTH;
            // 
            // labelKitRequired
            // 
            labelKitRequired.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelKitRequired.Location = new Point(MARGIN, textBoxCost.Bottom + HEIGHT_INTERVAL);
            labelKitRequired.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelKitRequired.Text = "Kit Required:";
            labelKitRequired.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxKitRequired
            // 
            textBoxKitRequired.BackColor = Color.White;
            textBoxKitRequired.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxKitRequired.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxKitRequired.Location = new Point(labelKitRequired.Right, textBoxCost.Bottom + HEIGHT_INTERVAL);
            textBoxKitRequired.Width = DATE_TIME_PICKER_WIDTH;
            // 
            // labelRemarks
            // 
            labelRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemarks.Location = new Point(MARGIN, textBoxKitRequired.Bottom + HEIGHT_INTERVAL);
            labelRemarks.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxRemarks
            // 
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            textBoxRemarks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxRemarks.Location = new Point(labelRemarks.Right, textBoxKitRequired.Bottom + HEIGHT_INTERVAL);
            textBoxRemarks.Size = new Size(DATE_TIME_PICKER_WIDTH, BIG_TEXTBOX_HEIGHT);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.ScrollBars = ScrollBars.Vertical;
            // 
            // linkLabelJobCard
            // 
            linkLabelJobCard.Font = Css.SimpleLink.Fonts.Font;
            linkLabelJobCard.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelJobCard.Text = "Job Card";
            linkLabelJobCard.Location = new Point(MARGIN, textBoxRemarks.Bottom);
            linkLabelJobCard.LinkClicked += linkLabelJobCard_LinkClicked;
            linkLabelJobCard.Size = new Size(DATE_TIME_PICKER_WIDTH, LABEL_HEIGHT);
            //
            // fileControl
            //
            //fileControl.Location = new Point(MARGIN, textBoxKitRequired.Bottom + HEIGHT_INTERVAL);
            //fileControl.Width = LIFELENGTH_VIEWER_WIDTH;
            //
            // delimiter1
            //
            delimiter1.Orientation = DelimiterOrientation.Vertical;
            delimiter1.Location = new Point(WIDTH_INTERVAL - (WIDTH_INTERVAL - MARGIN - LABEL_WIDTH - DATE_TIME_PICKER_WIDTH) / 2, MARGIN);
            delimiter1.Height = 210;
            // 
            // labelInterval
            // 
            labelInterval.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelInterval.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInterval.Location = new Point(WIDTH_INTERVAL, MARGIN);
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
            lifelengthViewerInterval.Location = new Point(WIDTH_INTERVAL, labelInterval.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            // 
            // labelNotify
            // 
            labelNotify.Font = Css.OrdinaryText.Fonts.SmallRegularFont;
            labelNotify.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNotify.Location = new Point(WIDTH_INTERVAL, lifelengthViewerInterval.Bottom + HEIGHT_INTERVAL);
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
            lifelengthViewerNotify.Location = new Point(WIDTH_INTERVAL, labelNotify.Bottom + HEIGHT_LIFELENGTH_INTERVAL);
            //
            // delimiter2
            //
            delimiter2.Orientation = DelimiterOrientation.Vertical;
            delimiter2.Location = new Point(WIDTH_INTERVAL_SECOND - (WIDTH_INTERVAL_SECOND - WIDTH_INTERVAL - LABEL_WIDTH - DATE_TIME_PICKER_WIDTH) / 2, MARGIN);
            delimiter2.Height = 210;
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
            // linkLabelRemove
            //
            linkLabelRemove.Font = Css.SimpleLink.Fonts.Font;
            linkLabelRemove.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelRemove.Text = "Remove";
            linkLabelRemove.Location = new Point(lifelengthViewerRemains.Right - linkLabelRemove.Width, lifelengthViewerRemains.Bottom);
            linkLabelRemove.TextAlign = ContentAlignment.BottomRight;
            linkLabelRemove.LinkClicked += linkLabelClear_LinkClicked;
            // 
            // DetailGeneralInformationControl
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(imageLinkLabelStatus);
            Controls.Add(labelManHours);
            Controls.Add(textBoxManHours);
            Controls.Add(labelCost);
            Controls.Add(textBoxCost);
            Controls.Add(labelKitRequired);
            Controls.Add(textBoxKitRequired);
            Controls.Add(labelRemarks);
            Controls.Add(textBoxRemarks);
            Controls.Add(linkLabelJobCard);
            Controls.Add(delimiter1);
            Controls.Add(labelInterval);
            Controls.Add(lifelengthViewerInterval);
            Controls.Add(labelNotify);
            Controls.Add(lifelengthViewerNotify);
            Controls.Add(delimiter2);
            Controls.Add(labelNext);
            Controls.Add(lifelengthViewerNext);
            Controls.Add(labelRemains);
            Controls.Add(lifelengthViewerRemains);
            Controls.Add(linkLabelRemove);

           // fileControl.Width = LIFELENGTH_VIEWER_WIDTH;
        }



        #endregion
        
        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            imageLinkLabelStatus.Text = currentDetailDirective.DirectiveType.FullName;
            imageLinkLabelStatus.Status = (Statuses)currentDetailDirective.ConditionState;
            if (Math.Abs(currentDetailDirective.ManHours) > 0.000001)
                textBoxManHours.Text = currentDetailDirective.ManHours.ToString();
            if (Math.Abs(currentDetailDirective.Cost) > 0.000001)
                textBoxCost.Text = currentDetailDirective.Cost.ToString();
            textBoxKitRequired.Text = currentDetailDirective.KitRequired;
            textBoxRemarks.Text = currentDetailDirective.Remarks;
            lifelengthViewerInterval.Lifelength = currentDetailDirective.Interval;
            lifelengthViewerNotify.Lifelength = currentDetailDirective.Notify;
            lifelengthViewerNext.Lifelength = currentDetailDirective.NextCompliance;
            lifelengthViewerRemains.Lifelength = currentDetailDirective.Remains;
            if (currentDetailDirective.JobCard != null)
                linkLabelJobCard.Text = "Job Card: " + currentDetailDirective.JobCard.AirlineCardNumber;
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохраняет работу агрегата
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            double manHours;
            double cost;
            if (!CheckDoubleValue("Man Hours", textBoxManHours.Text, out manHours))
                return false;
            if (!CheckDoubleValue("Cost", textBoxCost.Text, out cost))
                return false;
            if (currentDetailDirective.ManHours != manHours)
                currentDetailDirective.ManHours = manHours;
            if (currentDetailDirective.Cost != cost)
                currentDetailDirective.Cost = cost;
            if (currentDetailDirective.KitRequired != textBoxKitRequired.Text)
                currentDetailDirective.KitRequired = textBoxKitRequired.Text;
            if (currentDetailDirective.Remarks != textBoxRemarks.Text)
                currentDetailDirective.Remarks = textBoxRemarks.Text;
            currentDetailDirective.Interval = lifelengthViewerInterval.Lifelength;
            currentDetailDirective.Notify = lifelengthViewerNotify.Lifelength;
            try
            {
                currentDetailDirective.Save(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete performance limitation for this detail?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Deleted != null)
                    Deleted(this, EventArgs.Empty);
            }
        }

        #endregion

        #region private bool CheckDoubleValue(string paramName, string checkedString, out double value)

        /// <summary>
        /// Проверяет значение ManHours
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="checkedString">Строковое значение value</param>
        /// <param name="value">Значение ManHours</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
        private bool CheckDoubleValue(string paramName, string checkedString, out double value)
        {
            if (checkedString == "")
            {
                value = 0;
                return true;
            }
            if (double.TryParse(checkedString, NumberStyles.Float, new NumberFormatInfo(), out value) == false)
            {
                MessageBox.Show(paramName + ". Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelJobCard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MaintenanceJobCardForm form;
            if (currentDetailDirective.JobCard == null)
                form = new MaintenanceJobCardForm(currentDetailDirective);
            else
                form = new MaintenanceJobCardForm(currentDetailDirective.JobCard);
            form.ShowDialog();
        }

        #endregion

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion


    }
}