using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.ATLBs;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Форма для редактирования свойств бортового журнала ВС
    /// </summary>
    public class ATLBForm : Form
    {

        #region Fields

        private readonly ATLB currentATLB;
        private readonly Aircraft parentAircraft;
        private ScreenMode mode;

        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private Label labelAircraft;
        private Label labelATLBNo;
        private Label labelDate;
        private Label labelDateFrom;
        private Label labelDateTo;
        private Label labelStartPageNo;
        private Label labelRemarks;
        private Label labelRevision;
        private TextBox textBoxAircraft;
        private TextBox textBoxATLBNo;
        private TextBox textBoxDateFrom;
        private TextBox textBoxDateTo;
        private TextBox textBoxStartPageNo;
        private TextBox textBoxRemarks;
        private TextBox textBoxRevision;
        private WindowsFormAttachedFileControl fileControl;
        private Label labelSeparator;
        private Label labelSeparator2;
        private Button buttonOK;
        private Button buttonApply;
        private Button buttonCancel;

        private readonly Icons icons = new Icons();
        private readonly TermsProvider termsProvider = new TermsProvider();
        private const int LABEL_DATE_WIDTH = 40;
        private const int TEXT_BOX_DATE_WIDTH = 70;
        private const int DATE_INTERVAL = 20;

        #endregion

        #region Constructors
                
        #region public ATLBForm(ATLB atlb)

        /// <summary>
        /// Создает форму для редактирования свойств бортового журнала ВС
        /// </summary>
        /// <param name="atlb">Бортовой журнал</param>
        public ATLBForm(ATLB atlb)
        {
            currentATLB = atlb;
            parentAircraft = (Aircraft) atlb.Parent;
            mode = ScreenMode.Edit;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #region public ATLBForm(Aircraft aircraft)

        /// <summary>
        /// Создает форму для добавления бортового журнала
        /// </summary>
        /// <param name="aircraft">ВС, к которому добавляется бортовой журнал</param>
        public ATLBForm(Aircraft aircraft)
        {
            parentAircraft = aircraft;
            currentATLB = aircraft.ProposeNextATLB();
            mode = ScreenMode.Add;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion
        
        #endregion
        
        #region Methods
        
        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            labelAircraft = new Label();
            labelATLBNo = new Label();
            labelDate = new Label();
            labelDateFrom = new Label();
            labelDateTo = new Label();
            labelStartPageNo = new Label();
            labelRemarks = new Label();
            labelRevision = new Label();
            textBoxAircraft = new TextBox();
            textBoxATLBNo = new TextBox();
            textBoxDateFrom = new TextBox();
            textBoxDateTo = new TextBox();
            textBoxStartPageNo = new TextBox();
            textBoxRemarks = new TextBox();
            textBoxRevision = new TextBox();
            fileControl = new WindowsFormAttachedFileControl(currentATLB.AttachedFile, "Adobe PDF Files|*.pdf",
                    "There is no enclosed procedure to keep the Aircraft Technical Log Book.",
                    "Open enclosed file to view the procedure how to keep the Aircraft Technical Log Book.", icons.PDFSmall);
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
            tabPageGeneral.Controls.Add(labelAircraft);
            tabPageGeneral.Controls.Add(textBoxAircraft);
            tabPageGeneral.Controls.Add(labelATLBNo);
            tabPageGeneral.Controls.Add(textBoxATLBNo);
            tabPageGeneral.Controls.Add(labelDate);
            tabPageGeneral.Controls.Add(labelDateFrom);
            tabPageGeneral.Controls.Add(textBoxDateFrom);
            tabPageGeneral.Controls.Add(labelDateTo);
            tabPageGeneral.Controls.Add(textBoxDateTo);
            tabPageGeneral.Controls.Add(labelStartPageNo);
            tabPageGeneral.Controls.Add(textBoxStartPageNo);
            tabPageGeneral.Controls.Add(labelRemarks);
            tabPageGeneral.Controls.Add(textBoxRemarks);
            tabPageGeneral.Controls.Add(labelRevision);
            tabPageGeneral.Controls.Add(textBoxRevision);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(labelSeparator2);
            tabPageGeneral.Controls.Add(fileControl);
            //
            // labelAircraft
            //
            labelAircraft.Font = Css.WindowsForm.Fonts.RegularFont;
            labelAircraft.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelAircraft.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            labelAircraft.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelAircraft.Text = "Aircraft:";
            labelAircraft.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxAircraft
            //
            textBoxAircraft.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxAircraft.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxAircraft.Location = new Point(labelAircraft.Right, Css.WindowsForm.Constants.TAB_TOP_MARGIN);
            textBoxAircraft.ReadOnly = true;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelAircraft.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelATLBNo
            //
            labelATLBNo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelATLBNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelATLBNo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelATLBNo.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelATLBNo.Text = "ATLB No:";
            labelATLBNo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxATLBNo
            //
            textBoxATLBNo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxATLBNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxATLBNo.BackColor = Color.White;
            textBoxATLBNo.Location = new Point(labelATLBNo.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            //
            // labelDate
            //
            labelDate.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDate.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDate.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelATLBNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDate.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDate.Text = "Date:";
            labelDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelDateFrom
            //
            labelDateFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDateFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDateFrom.Location = new Point(labelDate.Right - 2, labelATLBNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDateFrom.Size = new Size(LABEL_DATE_WIDTH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelDateFrom.Text = "From";
            labelDateFrom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDateFrom
            // 
            textBoxDateFrom.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDateFrom.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDateFrom.Location = new Point(labelDateFrom.Right, labelATLBNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDateFrom.Size = new Size(TEXT_BOX_DATE_WIDTH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            textBoxDateFrom.ReadOnly = true;
            //
            // labelDateTo
            //
            labelDateTo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDateTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDateTo.Location = new Point(textBoxDateFrom.Right + DATE_INTERVAL, labelATLBNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelDateTo.Size = new Size(LABEL_DATE_WIDTH - 2, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            labelDateTo.Text = "To";
            labelDateTo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxDateTo
            // 
            textBoxDateTo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDateTo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDateTo.Location = new Point(labelDateTo.Right, labelATLBNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxDateTo.Size = new Size(TEXT_BOX_DATE_WIDTH, Css.WindowsForm.Constants.DefaultLabelSize.Height);
            textBoxDateTo.ReadOnly = true;
            //
            // labelStartPageNo
            //
            labelStartPageNo.Font = Css.WindowsForm.Fonts.RegularFont;
            labelStartPageNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelStartPageNo.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelStartPageNo.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelStartPageNo.Text = "Start Page No:";
            labelStartPageNo.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxStartPageNo
            //
            textBoxStartPageNo.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxStartPageNo.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxStartPageNo.BackColor = Color.White;
            textBoxStartPageNo.Location = new Point(labelStartPageNo.Right, labelDate.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelRemarks
            //
            labelRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRemarks.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelStartPageNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelRemarks.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRemarks.Text = "Remarks:";
            labelRemarks.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRemarks
            //
            textBoxRemarks.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRemarks.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRemarks.BackColor = Color.White;
            textBoxRemarks.Location = new Point(labelRemarks.Right, labelStartPageNo.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxRemarks.Multiline = true;
            textBoxRemarks.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            //
            // labelRevision
            //
            labelRevision.Font = Css.WindowsForm.Fonts.RegularFont;
            labelRevision.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelRevision.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, textBoxRemarks.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            labelRevision.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelRevision.Text = "Revision:";
            labelRevision.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxRevision
            //
            textBoxRevision.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxRevision.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxRevision.BackColor = Color.White;
            textBoxRevision.Location = new Point(labelRevision.Right, textBoxRemarks.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            //
            // labelSeparator2
            //
            labelSeparator2.AutoSize = false;
            labelSeparator2.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, labelRevision.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator2.Height = 2;
            labelSeparator2.BorderStyle = BorderStyle.Fixed3D;
            //
            // fileControl
            //
            fileControl.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator2.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
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
            /*string complianceText = ". Compliance";
            if (currentATLB != null)
                Text = "SN " + currentATLB.SerialNumber + complianceText;
            else
                Text = currentDirective.Title + complianceText;*/
            Text = "Aircraft Technical Log Book";
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
            textBoxAircraft.Text = parentAircraft.RegistrationNumber;
            textBoxATLBNo.Text = currentATLB.ATLBNo;
            textBoxDateFrom.Text = currentATLB.DateFrom == null ? "" : currentATLB.DateFrom.Value.ToString(termsProvider["DateFormat"].ToString());
            textBoxDateTo.Text = currentATLB.DateTo == null ? "" : currentATLB.DateTo.Value.ToString(termsProvider["DateFormat"].ToString());
            textBoxStartPageNo.Text = currentATLB.StartPageNo.ToString();
            textBoxRemarks.Text = currentATLB.Remarks;
            textBoxRevision.Text = currentATLB.Revision;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            int startPageNo;
            if (!CheckStartPageNo(out startPageNo))
                return false;
            if (currentATLB.ATLBNo != textBoxATLBNo.Text)
                currentATLB.ATLBNo = textBoxATLBNo.Text;
            if (currentATLB.Revision != textBoxRevision.Text)
                currentATLB.Revision = textBoxRevision.Text;
            if (currentATLB.StartPageNo != startPageNo)
                currentATLB.StartPageNo = startPageNo;
            if (currentATLB.Remarks != textBoxRemarks.Text)
                currentATLB.Remarks = textBoxRemarks.Text;
            if (currentATLB.AttachedFile != fileControl.AttachedFile)
            {
                currentATLB.AttachedFile.FileName = fileControl.AttachedFile.FileName;
                currentATLB.AttachedFile.FileData = fileControl.AttachedFile.FileData;
            }
            try
            {

                if (mode == ScreenMode.Add)
                {
                    parentAircraft.RegisterATLB(currentATLB);
                    if (fileControl.AttachedFile != null)
                    {
                        currentATLB.AttachedFile.FileName = fileControl.AttachedFile.FileName;
                        currentATLB.AttachedFile.FileData = fileControl.AttachedFile.FileData;
                    }
                    mode = ScreenMode.Edit;
                }
                currentATLB.Save(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }

            return true;
        }

        #endregion

        #region public bool CheckStartPageNo(out double manHours)

        /// <summary>
        /// Проверяет значение Start Page No
        /// </summary>
        /// <param name="startPageNo">Значение Start Page No</param>
        /// <returns>Возвращает true если значение можно преобразовать в тип int, иначе возвращает false</returns>
        public bool CheckStartPageNo(out int startPageNo)
        {
            if (int.TryParse(textBoxStartPageNo.Text, out startPageNo) == false)
            {
                MessageBox.Show("Start Page No. Invalid value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            textBoxAircraft.Width = 
            textBoxATLBNo.Width =
            textBoxStartPageNo.Width =
            textBoxRemarks.Width =
            textBoxRevision.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width =
            labelSeparator2.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            fileControl.MinimumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 0);
            fileControl.MaximumSize = new Size(Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN, 300);
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
        }

        #endregion
        
        #endregion
        
    }
}
