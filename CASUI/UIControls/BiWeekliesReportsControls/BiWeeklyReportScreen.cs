using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Core.Functions;
using CAS.Core.Core.Management;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Management;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.BiWeekliesReportsControls
{
    public class BiWeeklyReportScreen : Control
    {

        #region Fileds

        protected BiWeekly report;
        private BiWeekly tempReport;
        private string tempFilePath = "";
        private Process tempProcess;
        private readonly Panel mainPanel = new Panel();
        private readonly Label labelShortName = new Label();
        private readonly Label labelReportName = new Label();
        private readonly Label labelDescription = new Label();
        private readonly Label labelDownloadDate = new Label();
        private readonly TextBox textBoxShortName = new TextBox();
        private readonly TextBox textBoxReportName = new TextBox();
        private readonly TextBox textBoxDescription = new TextBox();
        private readonly Label labelDownloadDateValue = new Label();                     
        private readonly BiWeeklyItem reportViewItem;
        private readonly RichReferenceButton buttonDeleteReport = new RichReferenceButton();
        private readonly AvButtonT buttonLoad = new AvButtonT();
        private readonly AvButtonT buttonSaveToFile = new AvButtonT();
        private readonly ReferenceLinkLabel linkBiWeeklies =  new ReferenceLinkLabel();
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly BiWeekliesHeaderControl operatorHeaderControl;
        private readonly FooterControl footerControl = new FooterControl();

        private ScreenMode mode;
        private readonly Icons icons = new Icons();
        private readonly Size defaultLabelSize = new Size(150, 25);
        private readonly Size defaultTextBoxSize = new Size(250, 25);
        private const int LEFT_MARGIN = 20;
        private const int TOP_MARGIN = 20;
        private const int HEIGHT_INTERVAL = 10;
        protected bool processStartSuccessfully = true;
        
        #endregion

        #region Constructor

        public BiWeeklyReportScreen(BiWeekly report, ScreenMode mode)
        {
            this.report = report;
            this.mode = mode;
            tempReport = new BiWeekly(report.RealName, report.Report);
            operatorHeaderControl = new BiWeekliesHeaderControl(true);
            //
            // headerControl
            //
            headerControl.Controls.Add(operatorHeaderControl);
            headerControl.ActionControl.ButtonEdit.DisplayerRequested += ButtonEdit_DisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "bi_weekly_reports";
            if (mode == ScreenMode.Edit)
            {
                headerControl.ActionControl.ButtonEdit.Icon = icons.Save;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
                headerControl.ActionControl.ButtonEdit.TextMain = "Save";
                headerControl.ActionControl.ButtonEdit.Enabled = true;
            }
            else
            {
                headerControl.ButtonReload.Icon = icons.SaveAndAdd;
                headerControl.ButtonReload.IconNotEnabled = icons.SaveAndAddGray;
                headerControl.ButtonReload.TextMain = "Save and";
                headerControl.ButtonReload.TextSecondary = "add another";
                headerControl.ButtonEdit.Icon = icons.Save;
                headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
                headerControl.ButtonEdit.TextMain = "Save";
                headerControl.ButtonEdit.TextSecondary = "and close";
                headerControl.ButtonEdit.ReflectionType = ReflectionTypes.CloseSelected;
            }

            //
            // labelShortName
            //
            labelShortName.Location = new Point(LEFT_MARGIN, TOP_MARGIN);
            labelShortName.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelShortName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelShortName.Size = defaultLabelSize;
            labelShortName.Text = "Short Name:";
            labelShortName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxShortName
            //
            textBoxShortName.BackColor = Color.White;
            textBoxShortName.Location = new Point(labelShortName.Right, TOP_MARGIN);
            textBoxShortName.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxShortName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxShortName.Size = defaultTextBoxSize;
            //
            // labelReportName
            //
            labelReportName.Location = new Point(LEFT_MARGIN, labelShortName.Bottom + HEIGHT_INTERVAL);
            labelReportName.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelReportName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelReportName.Size = defaultLabelSize;
            labelReportName.Text = "Report Name:";
            labelReportName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxReportName
            //
            textBoxReportName.BackColor = Color.White;
            textBoxReportName.Location = new Point(labelReportName.Right, textBoxShortName.Bottom + HEIGHT_INTERVAL);
            textBoxReportName.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxReportName.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxReportName.Size = defaultTextBoxSize;
            textBoxReportName.LostFocus += textBoxReportName_LostFocus;
            //
            // labelDescription
            //
            labelDescription.Location = new Point(LEFT_MARGIN, labelReportName.Bottom + HEIGHT_INTERVAL);
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Size = defaultLabelSize;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxDescription
            //
            textBoxDescription.BackColor = Color.White;
            textBoxDescription.Location = new Point(labelDescription.Right, textBoxReportName.Bottom + HEIGHT_INTERVAL);
            textBoxDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxDescription.Multiline = true;
            textBoxDescription.Size = new Size(defaultTextBoxSize.Width, defaultTextBoxSize.Height * 5);
            //
            // labelDownloadDate
            //
            labelDownloadDate.Location = new Point(LEFT_MARGIN, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            labelDownloadDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDownloadDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDownloadDate.Size = defaultLabelSize;
            labelDownloadDate.Text = "Download Date:";
            labelDownloadDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelDownloadDateValue
            //
            labelDownloadDateValue.Location = new Point(labelDownloadDate.Right, textBoxDescription.Bottom + HEIGHT_INTERVAL);
            labelDownloadDateValue.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDownloadDateValue.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDownloadDateValue.Size = defaultTextBoxSize;
            labelDownloadDateValue.TextAlign = ContentAlignment.MiddleLeft;
            //
            // linkBiWeeklies
            //
            linkBiWeeklies.AutoSize = true;
            linkBiWeeklies.Location = new Point(LEFT_MARGIN, labelDownloadDate.Bottom + HEIGHT_INTERVAL);
            linkBiWeeklies.Font = Css.SimpleLink.Fonts.Font;
            linkBiWeeklies.ForeColor = Css.SimpleLink.Colors.LinkColor;
            linkBiWeeklies.Text = "BiWeekly Reports";
            linkBiWeeklies.DisplayerRequested += linkBiWeeklies_DisplayerRequested;
            //
            // reportViewItem
            //
            if (mode == ScreenMode.Edit)
                reportViewItem = new BiWeeklyItem(icons.PDF, "View PDF", Cursors.Hand);
            else
                reportViewItem = new BiWeeklyItem(icons.PDFGray, "View PDF", Cursors.Default);
            reportViewItem.Location = new Point(textBoxShortName.Right + HEIGHT_INTERVAL, TOP_MARGIN);
            reportViewItem.DisplayerRequested += reportViewItem_DisplayerRequested;
            //
            // buttonLoad
            //
            buttonLoad.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonLoad.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonLoad.Location = new Point(reportViewItem.Right + HEIGHT_INTERVAL, reportViewItem.Top);
            buttonLoad.Icon = icons.Load;
            buttonLoad.IconNotEnabled = icons.LoadGray;
            buttonLoad.TextMain = "Load PDF";
            buttonLoad.Click += buttonLoad_Click;
            //
            // buttonSaveToFile
            //
            buttonSaveToFile.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonSaveToFile.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonSaveToFile.Location = new Point(reportViewItem.Right + HEIGHT_INTERVAL, buttonLoad.Bottom);
            buttonSaveToFile.Icon = icons.Save;
            buttonSaveToFile.IconNotEnabled = icons.SaveGray; 
            buttonSaveToFile.TextMain = "Save to file";
            buttonSaveToFile.Click += buttonSaveToFile_Click;
            // 
            // buttonDeleteReport
            // 
            buttonDeleteReport.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteReport.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteReport.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteReport.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteReport.Location = new Point(1100, TOP_MARGIN);
            buttonDeleteReport.Icon = icons.Delete;
            buttonDeleteReport.IconNotEnabled = icons.DeleteGray;
            buttonDeleteReport.Size = new Size(200, 50);
            buttonDeleteReport.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteReport.TextMain = "Delete report";
            buttonDeleteReport.DisplayerRequested += buttonDeleteReport_DisplayerRequested;
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(labelShortName);
            mainPanel.Controls.Add(labelReportName);
            mainPanel.Controls.Add(labelDescription);
            mainPanel.Controls.Add(labelDownloadDate);
            mainPanel.Controls.Add(textBoxShortName);
            mainPanel.Controls.Add(textBoxReportName);
            mainPanel.Controls.Add(textBoxDescription);
            mainPanel.Controls.Add(labelDownloadDateValue);
            mainPanel.Controls.Add(linkBiWeeklies);
            mainPanel.Controls.Add(reportViewItem);
            mainPanel.Controls.Add(buttonLoad);
            mainPanel.Controls.Add(buttonSaveToFile);
            mainPanel.Controls.Add(buttonDeleteReport);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);

            UpdateInformation(false);
        }

        #endregion

        #region Methods

        #region protected bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в элементе управления
        /// </summary>
        /// <returns></returns>
        protected bool GetChangeStatus()
        {
            if (mode == ScreenMode.Edit)
                return report.ShortName != textBoxShortName.Text || report.RealName != textBoxReportName.Text ||
                       report.FullName != textBoxDescription.Text || tempReport.Report != report.Report;
            else
            {
                return textBoxShortName.Text != "" || textBoxReportName.Text != "" || textBoxDescription.Text != "" ||
                       tempReport.Report != null;
            }
        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// Обновляет информацию в данном элементе управления
        /// </summary>
        private void UpdateInformation()
        {
            UpdateInformation(true);
        }

        #endregion
        
        #region private void UpdateInformation(bool reloadReport)

        /// <summary>
        /// Обновляет информацию в данном элементе управления
        /// </summary>
        /// <param name="reloadReport">Синхронизировать ли с базой данных</param>
        private void UpdateInformation(bool reloadReport)
        {
            if (reloadReport)
            {
#if RELEASE
                try
                {

#endif
                report.Reload();
                RemoveTempFile();
#if RELEASE
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading data" + Environment.NewLine + ex.Message, (string) new StaticProjectTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

#endif
            }
            textBoxShortName.Text = report.ShortName;
            textBoxReportName.Text = report.RealName;
            textBoxDescription.Text = report.FullName;
            if (mode == ScreenMode.Edit)
            {
                labelDownloadDateValue.Text = UsefulMethods.NormalizeDate(report.RecievedDate);
            }
            else
                labelDownloadDateValue.Text = UsefulMethods.NormalizeDate(DateTime.Now);


            
            tempReport = new BiWeekly(report.RealName, report.Report);
            if (tempReport.Report != null)
                tempReport.SaveReportToFile(out tempFilePath);

            bool permission = report.HasPermission(Users.CurrentUser, DataEvent.Update);



            if (mode == ScreenMode.Edit)
                headerControl.ButtonEdit.Enabled = permission;
            buttonLoad.Enabled = permission;
            buttonSaveToFile.Enabled = !(tempReport.Report == null);
            textBoxShortName.ReadOnly = !permission;
            textBoxReportName.ReadOnly = !permission;
            textBoxDescription.ReadOnly = !permission;
            
            buttonDeleteReport.Visible = (mode == ScreenMode.Edit);
            buttonDeleteReport.Enabled = report.HasPermission(Users.CurrentUser, DataEvent.Remove);            
        }

        #endregion

        #region protected bool SaveData()

        /// <summary>
        /// Сохраняет данные текущего BiWeekly отчета
        /// </summary>
        /// <returns>Было ли успешным сохранение</returns>
        protected bool SaveData()
        {
            string message = "";
            if (tempReport.Report == null)
                message = "Please load PDF report";
            if (textBoxReportName.Text == "" && message == "")
                message = "Please fill report name";
            if (message != "")
            {
                MessageBox.Show(message, new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (report.ShortName != textBoxShortName.Text)
                report.ShortName = textBoxShortName.Text;
            if (report.RealName != textBoxReportName.Text)
            {
                if (mode == ScreenMode.Add)
                    report.RealName = textBoxReportName.Text;
                else
                {
                    RemoveTempFile();
                    report.RealName = textBoxReportName.Text;
                    report.SaveReportToFile(out tempFilePath);
                }
            }
            if (report.FullName != textBoxDescription.Text)
                report.FullName = textBoxDescription.Text;
            if (report.Report != tempReport.Report)
                report.Report = tempReport.Report;
#if RELEASE
            try
            {

#endif
            if (mode == ScreenMode.Edit)
                    report.Save();
                else
                    BiWeekliesCollection.Instance.Add(report);
#if RELEASE
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving data" + Environment.NewLine + ex.Message, (string)new StaticProjectTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

#endif
                return true;
        }

        #endregion
        
        #region protected void RemoveTempFiles()

        protected void RemoveTempFile()
        {
            if (tempFilePath != "")
            {
                if (tempProcess != null && processStartSuccessfully && !tempProcess.HasExited)
                {
                    tempProcess.Kill();
                    tempProcess.WaitForExit(200);
                }
                try
                {
                    File.Delete(tempFilePath);
                }
                catch(Exception ex)
                {}
            }
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            textBoxShortName.Text = "";
            textBoxReportName.Text = "";
            textBoxDescription.Text = "";
            labelDownloadDateValue.Text = UsefulMethods.NormalizeDate(DateTime.Now);
            buttonSaveToFile.Enabled = false;
            reportViewItem.Icon = icons.PDFGray;
            reportViewItem.Cursor = Cursors.Default;
            report = new BiWeekly("", null);
            tempReport = new BiWeekly("", null);
        }

        #endregion
        

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            if (mode == ScreenMode.Edit)
            {
                if (GetChangeStatus())
                {
                    if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?",
                                        (string) new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        UpdateInformation();
                    }
                }
                else
                {
                    UpdateInformation();
                }
            }
            else
            {
                if (SaveData())
                {
                    ClearFields();
                    MessageBox.Show("Report added successfully", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion
        
        #region private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (mode == ScreenMode.Edit)
                e.Cancel = true;
            if (SaveData())
                mode = ScreenMode.Edit;    
            else
                e.Cancel = true;
        }

        #endregion

        #region private static void linkBiWeeklies_DisplayerRequested(object sender, ReferenceEventArgs e)

        private static void linkBiWeeklies_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = "BiWeekly Reports";
            e.RequestedEntity = new DispatcheredBiWeekliesCollectionScreen();
        }

        #endregion

        #region private void reportViewItem_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void reportViewItem_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (tempReport.Report != null && tempFilePath != "")
            {
                if (!File.Exists(tempFilePath))
                    tempReport.SaveReportToFile(out tempFilePath);
                tempProcess = new Process();
                tempProcess.StartInfo.FileName = tempReport.RealName;
#if RELEASE
                try
                {

#endif
                tempProcess.Start();
#if RELEASE
                }
                catch (Exception ex)
                {
                    CASMessage.Show(MessageType.LoadMessage, new object[] {ex.Message});
                    processStartSuccessfully = false;
                }
#endif
            }
            e.Cancel = true;
        }

        #endregion

        #region private void buttonLoad_Click(object sender, EventArgs e)

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RemoveTempFile();
                tempReport.LoadReport(dialog.FileName);

                if (textBoxReportName.Text == "")
                {
                    string fileName = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                    tempReport.RealName = fileName;
                    if (fileName.LastIndexOf('.') == -1)
                        textBoxShortName.Text = fileName;
                    else 
                        textBoxShortName.Text = fileName.Substring(0, fileName.LastIndexOf('.'));
                    textBoxReportName.Text = fileName;
                }
                else
                    tempReport.RealName = textBoxReportName.Text;
                tempReport.SaveReportToFile(out tempFilePath);
                if (mode == ScreenMode.Add)
                {
                    buttonSaveToFile.Enabled = true;
                    reportViewItem.Icon = icons.PDF;
                    reportViewItem.Cursor = Cursors.Hand;
                }
            }
        }

        #endregion

        #region private void buttonSaveToFile_Click(object sender, EventArgs e)

        private void buttonSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Adobe PDF Files|*.pdf";
            dialog.FileName = textBoxReportName.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tempReport.SaveReportToFile(dialog.FileName);
            }
        }

        #endregion

        #region private void buttonDeleteReport_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteReport_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.CloseSelected;
            DialogResult result = MessageBox.Show("Are sure you want to delete this BiWeekly Report?",
                    "Confirm deleting " + report.RealName, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
#if RELEASE
                try
                {

#endif
                BiWeekliesCollection.Instance.Remove(report);
                    RemoveTempFile();
                    MessageBox.Show("Report was deleted successfully", (string)new TermsProvider()["SystemName"],
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
#if RELEASE
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while deleting data" + Environment.NewLine + ex.Message, (string)new StaticProjectTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

#endif
                }
            else
            {
                e.Cancel = true;
            }

        }

        #endregion

        #region private void textBoxReportName_LostFocus(object sender, EventArgs e)

        private void textBoxReportName_LostFocus(object sender, EventArgs e)
        {
            if (textBoxReportName.Text.Length == 0)
                return;
            if (textBoxReportName.Text.Length < 4 || !Regex.IsMatch(textBoxReportName.Text.Substring(textBoxReportName.Text.Length - 4), ".(?i)pdf"))
            {
                textBoxReportName.Text += ".pdf";
            }
            else
                textBoxReportName.Text = textBoxReportName.Text.Substring(0, textBoxReportName.Text.Length - 4) + ".pdf";
        }

        #endregion

        #endregion

    }

    #region public enum ScreenMode

    /// <summary>
    /// Отпределяет режим отображения элемента управления
    /// </summary>
    public enum ScreenMode
    {
        /// <summary>
        /// Режим добавления 
        /// </summary>
        Add,
        /// <summary>
        /// Режим редактирования 
        /// </summary>
        Edit,
        /// <summary>
        /// Режим просмотра
        /// </summary>
        View

    }

    #endregion
    
}