using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.BiWeekliesReportsControls
{
    /// <summary>
    /// Форма, для отображения информации о BiWeekly-отчете
    /// </summary>
    public class BiWeeklyForm : Form
    {
        
        #region Fields

        private readonly BiWeekly currentBiWeeklyReport;
        private TabControl tabControl;
        private TabPage tabPageGeneral;
        private readonly PictureBox pictureBoxPDF = new PictureBox();
        private readonly Label labelDescription = new Label();
        private readonly TextBox textBoxShortName = new TextBox();
        private readonly TextBox textBoxDescription = new TextBox();
        private readonly Label labelSeparator = new Label();
        private readonly Button buttonApply = new Button();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();

        private ScreenMode mode;
        private readonly Icons icons = new Icons();
        
        #endregion

        #region Constructors

        #region public BiWeeklyForm(string dialogFileName)

        /// <summary>
        /// Создает форму для добавления BiWeekly-отчета
        /// </summary>
        /// <param name="dialogFileName"></param>
        public BiWeeklyForm(string dialogFileName)
        {
            currentBiWeeklyReport = new BiWeekly();
            mode = ScreenMode.Add;
            InitializeComponent();

            string fileName = dialogFileName.Substring(dialogFileName.LastIndexOf('\\') + 1);
            if (fileName.LastIndexOf('.') == -1)
                textBoxShortName.Text = fileName;
            else
                textBoxShortName.Text = fileName.Substring(0, fileName.LastIndexOf('.'));
            currentBiWeeklyReport.LoadReport(dialogFileName);
        }

        #endregion
        
        #region public BiWeeklyForm(BiWeekly biWeeklyReport)

        /// <summary>
        /// Создает форму для отображения информации о BiWeekly-отчете
        /// </summary>
        /// <param name="biWeeklyReport"></param>
        public BiWeeklyForm(BiWeekly biWeeklyReport)
        {
            currentBiWeeklyReport = biWeeklyReport;
            mode = ScreenMode.Edit;
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
            tabPageGeneral.Text = "General";
            tabPageGeneral.Controls.Add(pictureBoxPDF);
            tabPageGeneral.Controls.Add(labelDescription);
            tabPageGeneral.Controls.Add(labelSeparator);
            tabPageGeneral.Controls.Add(textBoxShortName);
            tabPageGeneral.Controls.Add(textBoxDescription);
            //
            // pictureBoxPDF
            //
            pictureBoxPDF.BackgroundImage = icons.PDFSmall;
            pictureBoxPDF.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxPDF.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, Css.WindowsForm.Constants.TAB_TOP_MARGIN_PICTURE_BOX);
            pictureBoxPDF.Size = Css.WindowsForm.Constants.DefaultPictureBoxSize;
            //
            // textBoxShortName
            //
            textBoxShortName.BackColor = Color.White;
            textBoxShortName.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN + Css.WindowsForm.Constants.DefaultLabelSize.Width, Css.WindowsForm.Constants.TAB_TOP_MARGIN_TEXT_BOX_WITH_PICTURE_BOX);
            textBoxShortName.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxShortName.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxShortName.Multiline = true;
            textBoxShortName.Height = Css.WindowsForm.Constants.TEXT_BOX_WITH_PICTURE_BOX_HEIGHT;
            //
            // labelSeparator
            //
            labelSeparator.AutoSize = false;
            labelSeparator.Location = new Point(Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN, textBoxShortName.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelSeparator.Height = 2;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            //
            // labelDescription
            //
            labelDescription.Location = new Point(Css.WindowsForm.Constants.TAB_LEFT_MARGIN, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Size = Css.WindowsForm.Constants.DefaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDescription
            //
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Location = new Point(labelDescription.Right, labelSeparator.Bottom + Css.WindowsForm.Constants.SEPARATOR_INTERVAL);
            textBoxDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            textBoxDescription.Height = Css.WindowsForm.Constants.BIG_TEXT_BOX_HEIGHT;
            textBoxDescription.Multiline = true;
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
            textBoxShortName.Text = currentBiWeeklyReport.ShortName;
            textBoxDescription.Text = currentBiWeeklyReport.FullName;

            bool permission = currentBiWeeklyReport.HasPermission(Users.CurrentUser, DataEvent.Update);

            textBoxShortName.ReadOnly = !permission;
            textBoxDescription.ReadOnly = !permission;
        }

        #endregion

        #region private bool SaveData()

        private bool SaveData()
        {
            /*string message = "";
            if (textBoxReportName.Text == "")
                message = "Please fill report name";
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
*/
            if (currentBiWeeklyReport.ShortName != textBoxShortName.Text)
            {
                currentBiWeeklyReport.ShortName = textBoxShortName.Text;
                UpdateFormName();
            }
            if (currentBiWeeklyReport.FullName != textBoxDescription.Text)
                currentBiWeeklyReport.FullName = textBoxDescription.Text;
            try
            {

            if (mode == ScreenMode.Edit)
                currentBiWeeklyReport.Save();
            else
            {
                BiWeekliesCollection.Instance.Add(currentBiWeeklyReport);
                UpdateFormName();
                mode = ScreenMode.Edit;
            }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }

            if (Saved != null)
                Saved(this, EventArgs.Empty);
            return true;

        }

        #endregion

        #region private void UpdateFormName()

        private void UpdateFormName()
        {
            if (mode == ScreenMode.Edit)
                Text = "BiWeekly Report " + currentBiWeeklyReport.ShortName;
            else
                Text = "New BiWeekly Report " + currentBiWeeklyReport.ShortName;
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            SaveData();
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
            tabControl.Size = new Size(ClientSize.Width - Css.WindowsForm.Constants.LEFT_MARGIN - Css.WindowsForm.Constants.RIGHT_MARGIN, ClientSize.Height - Css.WindowsForm.Constants.TOP_MARGIN - Css.WindowsForm.Constants.BOTTOM_MARGIN - Css.WindowsForm.Constants.BUTTON_HEIGHT - Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            textBoxShortName.Width = 
            textBoxDescription.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_RIGHT_MARGIN - Css.WindowsForm.Constants.DefaultLabelSize.Width;
            labelSeparator.Width = tabControl.Width - Css.WindowsForm.Constants.TAB_SEPARATOR_LEFT_MARGIN - Css.WindowsForm.Constants.TAB_SEPARATOR_RIGHT_MARGIN;
            buttonApply.Location = new Point(ClientSize.Width - Css.WindowsForm.Constants.RIGHT_MARGIN - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonCancel.Location = new Point(buttonApply.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
            buttonOK.Location = new Point(buttonCancel.Left - Css.WindowsForm.Constants.BUTTON_INTERVAL - Css.WindowsForm.Constants.BUTTON_WIDTH, tabControl.Bottom + Css.WindowsForm.Constants.HEIGHT_INTERVAL);
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