using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.JobCardControls
{
    partial class JobCardControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
            this.labelFooter = new System.Windows.Forms.Label();
            this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
            this.textboxFooter = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxApplicability = new System.Windows.Forms.TextBox();
            this.labelFormRev = new System.Windows.Forms.Label();
            this.labelForm = new System.Windows.Forms.Label();
            this.textBoxForm = new System.Windows.Forms.TextBox();
            this.textboxFormRev = new System.Windows.Forms.TextBox();
            this.labelFormRevDate = new System.Windows.Forms.Label();
            this.dateTimePickerFormRevDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxWorkArea = new System.Windows.Forms.TextBox();
            this.textBoxPhase = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
            this.labelJobCardHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxJobCardHeader = new System.Windows.Forms.TextBox();
            this.comboBoxMMRef = new System.Windows.Forms.ComboBox();
            this.labelJobDescroption = new System.Windows.Forms.Label();
            this.labelEquipmentAndMaterials = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelApprovedBy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCheckedBy = new System.Windows.Forms.Label();
            this.textBoxAttachedTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPreparedBy = new System.Windows.Forms.Label();
            this.labelAttachedTo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownManHours = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMan = new System.Windows.Forms.NumericUpDown();
            this.labelManHours = new System.Windows.Forms.Label();
            this.labelMMRevisionDate = new System.Windows.Forms.Label();
            this.labelMan = new System.Windows.Forms.Label();
            this.labelQualification = new System.Windows.Forms.Label();
            this.labelMMRevision = new System.Windows.Forms.Label();
            this.labelMMRef = new System.Windows.Forms.Label();
            this.labelJCRevDate = new System.Windows.Forms.Label();
            this.labelJCRevNumber = new System.Windows.Forms.Label();
            this.dateTimePickerJCRevDate = new System.Windows.Forms.DateTimePicker();
            this.labelMRO = new System.Windows.Forms.Label();
            this.comboBoxQualification = new System.Windows.Forms.ComboBox();
            this.textboxTitle = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelRelatedTask = new System.Windows.Forms.Label();
            this.labelACTATValue = new System.Windows.Forms.Label();
            this.labelACTACValue = new System.Windows.Forms.Label();
            this.labelACTotalTime = new System.Windows.Forms.Label();
            this.labelACTotalCycles = new System.Windows.Forms.Label();
            this.labelACTypeValue = new System.Windows.Forms.Label();
            this.textBoxZone = new System.Windows.Forms.TextBox();
            this.labelACType = new System.Windows.Forms.Label();
            this.labelACReg = new System.Windows.Forms.Label();
            this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
            this.labelACRegValue = new System.Windows.Forms.Label();
            this.labelRelatedTaskValue = new System.Windows.Forms.Label();
            this.labelDateValue = new System.Windows.Forms.Label();
            this.labelStation = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelIntervalValue = new System.Windows.Forms.Label();
            this.textBoxMRO = new System.Windows.Forms.TextBox();
            this.textBoxStation = new System.Windows.Forms.TextBox();
            this.textBoxJCRevNumber = new System.Windows.Forms.TextBox();
            this.labelATA = new System.Windows.Forms.Label();
            this.labelAccess = new System.Windows.Forms.Label();
            this.labelZone = new System.Windows.Forms.Label();
            this.textBoxAccess = new System.Windows.Forms.TextBox();
            this.textBoxMMRevisionNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerMMRevisionDate = new System.Windows.Forms.DateTimePicker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dateTimePickerCheckedDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerApprovedDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxChechedBy = new System.Windows.Forms.ComboBox();
            this.dateTimePickerPreparedDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPreparedBy = new System.Windows.Forms.ComboBox();
            this.comboBoxApprovedBy = new System.Windows.Forms.ComboBox();
            this.commonListViewControlEqipmentAndMaterials = new CAS.UI.UIControls.Auxiliary.CommonListViewControl();
            this.jobCardTaskListControl = new CAS.UI.UIControls.JobCardControls.JobCardTaskListControl();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMan)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBiWeeklyReport
            // 
            this.labelBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.labelBiWeeklyReport.Name = "labelBiWeeklyReport";
            this.labelBiWeeklyReport.Size = new System.Drawing.Size(150, 25);
            this.labelBiWeeklyReport.TabIndex = 0;
            this.labelBiWeeklyReport.Text = "BiWeekly Report";
            // 
            // labelFooter
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelFooter, 9);
            this.labelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFooter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFooter.Location = new System.Drawing.Point(2, 852);
            this.labelFooter.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(1648, 18);
            this.labelFooter.TabIndex = 0;
            this.labelFooter.Text = "Footer:";
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxBiWeeklyReport
            // 
            this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
            this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.textboxBiWeeklyReport.MaxLength = 1000;
            this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
            this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 26);
            this.textboxBiWeeklyReport.TabIndex = 9;
            // 
            // textboxFooter
            // 
            this.textboxFooter.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textboxFooter, 9);
            this.textboxFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxFooter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxFooter.Location = new System.Drawing.Point(2, 871);
            this.textboxFooter.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textboxFooter.MaxLength = 34000;
            this.textboxFooter.Multiline = true;
            this.textboxFooter.Name = "textboxFooter";
            this.textboxFooter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxFooter.Size = new System.Drawing.Size(1648, 88);
            this.textboxFooter.TabIndex = 23;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1658, 966);
            this.flowLayoutPanelMain.TabIndex = 38;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelFooter, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.textboxFooter, 0, 19);
            this.tableLayoutPanel1.Controls.Add(this.textBoxApplicability, 7, 12);
            this.tableLayoutPanel1.Controls.Add(this.labelFormRev, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelForm, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxForm, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.textboxFormRev, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFormRevDate, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerFormRevDate, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxWorkArea, 5, 12);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPhase, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.label10, 7, 11);
            this.tableLayoutPanel1.Controls.Add(this.label9, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxWorkType, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.labelJobCardHeader, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.textboxJobCardHeader, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMMRef, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelJobDescroption, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.labelEquipmentAndMaterials, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label5, 7, 9);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelApprovedBy, 6, 8);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelCheckedBy, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAttachedTo, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelPreparedBy, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelAttachedTo, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownManHours, 8, 7);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownMan, 7, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelManHours, 8, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelMMRevisionDate, 5, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelMan, 7, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelQualification, 6, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelMMRevision, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelMMRef, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelJCRevDate, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelJCRevNumber, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerJCRevDate, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelMRO, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxQualification, 6, 7);
            this.tableLayoutPanel1.Controls.Add(this.textboxTitle, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelDate, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRelatedTask, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelACTATValue, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelACTACValue, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelACTotalTime, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelACTotalCycles, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelACTypeValue, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxZone, 7, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelACType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelACReg, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ataChapterComboBox, 6, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelACRegValue, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelRelatedTaskValue, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelDateValue, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelStation, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelInterval, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelIntervalValue, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMRO, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxStation, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxJCRevNumber, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelATA, 6, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelAccess, 8, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelZone, 7, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAccess, 8, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMMRevisionNumber, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerMMRevisionDate, 5, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerCheckedDate, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerApprovedDate, 6, 10);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxChechedBy, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerPreparedDate, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPreparedBy, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxApprovedBy, 7, 10);
            this.tableLayoutPanel1.Controls.Add(this.commonListViewControlEqipmentAndMaterials, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.jobCardTaskListControl, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.panelButtons, 8, 14);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 20;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1652, 960);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // textBoxApplicability
            // 
            this.textBoxApplicability.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxApplicability, 2);
            this.textBoxApplicability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxApplicability.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxApplicability.Location = new System.Drawing.Point(1287, 284);
            this.textBoxApplicability.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxApplicability.MaxLength = 1000;
            this.textBoxApplicability.Name = "textBoxApplicability";
            this.textBoxApplicability.Size = new System.Drawing.Size(363, 26);
            this.textBoxApplicability.TabIndex = 84;
            // 
            // labelFormRev
            // 
            this.labelFormRev.AutoSize = true;
            this.labelFormRev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFormRev.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFormRev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFormRev.Location = new System.Drawing.Point(1289, 1);
            this.labelFormRev.Name = "labelFormRev";
            this.labelFormRev.Size = new System.Drawing.Size(156, 25);
            this.labelFormRev.TabIndex = 0;
            this.labelFormRev.Text = "Form Rev.:";
            this.labelFormRev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelForm
            // 
            this.labelForm.AutoSize = true;
            this.labelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelForm.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelForm.Location = new System.Drawing.Point(1086, 1);
            this.labelForm.Name = "labelForm";
            this.labelForm.Size = new System.Drawing.Size(196, 25);
            this.labelForm.TabIndex = 28;
            this.labelForm.Text = "Form:";
            this.labelForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxForm
            // 
            this.textBoxForm.BackColor = System.Drawing.Color.White;
            this.textBoxForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxForm.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxForm.Location = new System.Drawing.Point(1084, 27);
            this.textBoxForm.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxForm.MaxLength = 200;
            this.textBoxForm.Name = "textBoxForm";
            this.textBoxForm.Size = new System.Drawing.Size(200, 26);
            this.textBoxForm.TabIndex = 7;
            // 
            // textboxFormRev
            // 
            this.textboxFormRev.BackColor = System.Drawing.Color.White;
            this.textboxFormRev.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxFormRev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxFormRev.Location = new System.Drawing.Point(1287, 27);
            this.textboxFormRev.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textboxFormRev.MaxLength = 50;
            this.textboxFormRev.Name = "textboxFormRev";
            this.textboxFormRev.Size = new System.Drawing.Size(160, 26);
            this.textboxFormRev.TabIndex = 3;
            // 
            // labelFormRevDate
            // 
            this.labelFormRevDate.AutoSize = true;
            this.labelFormRevDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFormRevDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFormRevDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFormRevDate.Location = new System.Drawing.Point(1452, 1);
            this.labelFormRevDate.Name = "labelFormRevDate";
            this.labelFormRevDate.Size = new System.Drawing.Size(196, 25);
            this.labelFormRevDate.TabIndex = 0;
            this.labelFormRevDate.Text = "Form Rev. Date:";
            this.labelFormRevDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerFormRevDate
            // 
            this.dateTimePickerFormRevDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerFormRevDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerFormRevDate.Location = new System.Drawing.Point(1450, 27);
            this.dateTimePickerFormRevDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerFormRevDate.Name = "dateTimePickerFormRevDate";
            this.dateTimePickerFormRevDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerFormRevDate.TabIndex = 2;
            // 
            // textBoxWorkArea
            // 
            this.textBoxWorkArea.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxWorkArea, 2);
            this.textBoxWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWorkArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWorkArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxWorkArea.Location = new System.Drawing.Point(881, 284);
            this.textBoxWorkArea.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxWorkArea.MaxLength = 1000;
            this.textBoxWorkArea.Name = "textBoxWorkArea";
            this.textBoxWorkArea.Size = new System.Drawing.Size(403, 26);
            this.textBoxWorkArea.TabIndex = 83;
            // 
            // textBoxPhase
            // 
            this.textBoxPhase.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxPhase, 2);
            this.textBoxPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPhase.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPhase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPhase.Location = new System.Drawing.Point(515, 284);
            this.textBoxPhase.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxPhase.MaxLength = 1000;
            this.textBoxPhase.Name = "textBoxPhase";
            this.textBoxPhase.Size = new System.Drawing.Size(363, 26);
            this.textBoxPhase.TabIndex = 82;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label10, 2);
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label10.Location = new System.Drawing.Point(1289, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(359, 18);
            this.label10.TabIndex = 81;
            this.label10.Text = "APPLICABILITY";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label9, 2);
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label9.Location = new System.Drawing.Point(883, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(399, 18);
            this.label9.TabIndex = 80;
            this.label9.Text = "WORK AREA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label8.Location = new System.Drawing.Point(517, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(359, 18);
            this.label8.TabIndex = 79;
            this.label8.Text = "PHASE";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxWorkType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxWorkType, 3);
            this.comboBoxWorkType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxWorkType.FormattingEnabled = true;
            this.comboBoxWorkType.Location = new System.Drawing.Point(2, 284);
            this.comboBoxWorkType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxWorkType.Name = "comboBoxWorkType";
            this.comboBoxWorkType.Size = new System.Drawing.Size(510, 26);
            this.comboBoxWorkType.TabIndex = 78;
            // 
            // labelJobCardHeader
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelJobCardHeader, 6);
            this.labelJobCardHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJobCardHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelJobCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelJobCardHeader.Location = new System.Drawing.Point(2, 1);
            this.labelJobCardHeader.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelJobCardHeader.Name = "labelJobCardHeader";
            this.labelJobCardHeader.Size = new System.Drawing.Size(1079, 25);
            this.labelJobCardHeader.TabIndex = 0;
            this.labelJobCardHeader.Text = "Job Card Header";
            this.labelJobCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(4, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 18);
            this.label1.TabIndex = 77;
            this.label1.Text = "WORK TYPE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxJobCardHeader
            // 
            this.textboxJobCardHeader.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textboxJobCardHeader, 6);
            this.textboxJobCardHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxJobCardHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxJobCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxJobCardHeader.Location = new System.Drawing.Point(2, 27);
            this.textboxJobCardHeader.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textboxJobCardHeader.MaxLength = 1000;
            this.textboxJobCardHeader.Name = "textboxJobCardHeader";
            this.textboxJobCardHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxJobCardHeader.Size = new System.Drawing.Size(1079, 26);
            this.textboxJobCardHeader.TabIndex = 19;
            // 
            // comboBoxMMRef
            // 
            this.comboBoxMMRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxMMRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMMRef.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxMMRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxMMRef.FormattingEnabled = true;
            this.comboBoxMMRef.Location = new System.Drawing.Point(515, 173);
            this.comboBoxMMRef.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxMMRef.Name = "comboBoxMMRef";
            this.comboBoxMMRef.Size = new System.Drawing.Size(200, 26);
            this.comboBoxMMRef.TabIndex = 76;
            // 
            // labelJobDescroption
            // 
            this.labelJobDescroption.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelJobDescroption, 9);
            this.labelJobDescroption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJobDescroption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelJobDescroption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelJobDescroption.Location = new System.Drawing.Point(4, 570);
            this.labelJobDescroption.Name = "labelJobDescroption";
            this.labelJobDescroption.Size = new System.Drawing.Size(1644, 18);
            this.labelJobDescroption.TabIndex = 74;
            this.labelJobDescroption.Text = "JOB DESCRIPTION";
            this.labelJobDescroption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEquipmentAndMaterials
            // 
            this.labelEquipmentAndMaterials.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelEquipmentAndMaterials, 7);
            this.labelEquipmentAndMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEquipmentAndMaterials.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEquipmentAndMaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEquipmentAndMaterials.Location = new System.Drawing.Point(207, 332);
            this.labelEquipmentAndMaterials.Name = "labelEquipmentAndMaterials";
            this.labelEquipmentAndMaterials.Size = new System.Drawing.Size(1238, 36);
            this.labelEquipmentAndMaterials.TabIndex = 71;
            this.labelEquipmentAndMaterials.Text = "EQUIPMENT AND MATERIALS";
            this.labelEquipmentAndMaterials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 2);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label5.Location = new System.Drawing.Point(1289, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 18);
            this.label5.TabIndex = 65;
            this.label5.Text = "SURNAME";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label7.Location = new System.Drawing.Point(1086, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 18);
            this.label7.TabIndex = 67;
            this.label7.Text = "DATE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelApprovedBy
            // 
            this.labelApprovedBy.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelApprovedBy, 3);
            this.labelApprovedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelApprovedBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApprovedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApprovedBy.Location = new System.Drawing.Point(1086, 200);
            this.labelApprovedBy.Name = "labelApprovedBy";
            this.labelApprovedBy.Size = new System.Drawing.Size(562, 18);
            this.labelApprovedBy.TabIndex = 70;
            this.labelApprovedBy.Text = "APPROVED BY";
            this.labelApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 2);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(720, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 18);
            this.label6.TabIndex = 66;
            this.label6.Text = "SURNAME";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCheckedBy
            // 
            this.labelCheckedBy.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelCheckedBy, 3);
            this.labelCheckedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCheckedBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheckedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCheckedBy.Location = new System.Drawing.Point(517, 200);
            this.labelCheckedBy.Name = "labelCheckedBy";
            this.labelCheckedBy.Size = new System.Drawing.Size(562, 18);
            this.labelCheckedBy.TabIndex = 69;
            this.labelCheckedBy.Text = "CHECKED BY";
            this.labelCheckedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAttachedTo
            // 
            this.textBoxAttachedTo.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxAttachedTo, 3);
            this.textBoxAttachedTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxAttachedTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAttachedTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAttachedTo.Location = new System.Drawing.Point(1084, 77);
            this.textBoxAttachedTo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxAttachedTo.MaxLength = 3000;
            this.textBoxAttachedTo.Name = "textBoxAttachedTo";
            this.textBoxAttachedTo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAttachedTo.Size = new System.Drawing.Size(566, 26);
            this.textBoxAttachedTo.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(517, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 18);
            this.label3.TabIndex = 63;
            this.label3.Text = "DATE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label4.Location = new System.Drawing.Point(207, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(303, 18);
            this.label4.TabIndex = 64;
            this.label4.Text = "SURNAME";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPreparedBy
            // 
            this.labelPreparedBy.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelPreparedBy, 3);
            this.labelPreparedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPreparedBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPreparedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPreparedBy.Location = new System.Drawing.Point(4, 200);
            this.labelPreparedBy.Name = "labelPreparedBy";
            this.labelPreparedBy.Size = new System.Drawing.Size(506, 18);
            this.labelPreparedBy.TabIndex = 61;
            this.labelPreparedBy.Text = "PREPARED BY";
            this.labelPreparedBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttachedTo
            // 
            this.labelAttachedTo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelAttachedTo, 3);
            this.labelAttachedTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAttachedTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAttachedTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAttachedTo.Location = new System.Drawing.Point(1086, 54);
            this.labelAttachedTo.Name = "labelAttachedTo";
            this.labelAttachedTo.Size = new System.Drawing.Size(562, 22);
            this.labelAttachedTo.TabIndex = 64;
            this.labelAttachedTo.Text = "ATTACHED TO";
            this.labelAttachedTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(4, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "DATE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownManHours
            // 
            this.numericUpDownManHours.DecimalPlaces = 2;
            this.numericUpDownManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownManHours.Location = new System.Drawing.Point(1450, 173);
            this.numericUpDownManHours.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.numericUpDownManHours.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownManHours.Name = "numericUpDownManHours";
            this.numericUpDownManHours.Size = new System.Drawing.Size(200, 26);
            this.numericUpDownManHours.TabIndex = 62;
            this.numericUpDownManHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownMan
            // 
            this.numericUpDownMan.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownMan.Location = new System.Drawing.Point(1287, 173);
            this.numericUpDownMan.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.numericUpDownMan.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMan.Name = "numericUpDownMan";
            this.numericUpDownMan.Size = new System.Drawing.Size(160, 26);
            this.numericUpDownMan.TabIndex = 63;
            this.numericUpDownMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelManHours
            // 
            this.labelManHours.AutoSize = true;
            this.labelManHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManHours.Location = new System.Drawing.Point(1452, 154);
            this.labelManHours.Name = "labelManHours";
            this.labelManHours.Size = new System.Drawing.Size(196, 18);
            this.labelManHours.TabIndex = 62;
            this.labelManHours.Text = "M/H";
            this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMMRevisionDate
            // 
            this.labelMMRevisionDate.AutoSize = true;
            this.labelMMRevisionDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMMRevisionDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMMRevisionDate.Location = new System.Drawing.Point(883, 154);
            this.labelMMRevisionDate.Name = "labelMMRevisionDate";
            this.labelMMRevisionDate.Size = new System.Drawing.Size(183, 18);
            this.labelMMRevisionDate.TabIndex = 51;
            this.labelMMRevisionDate.Text = "DOC REVISION DATE";
            this.labelMMRevisionDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMan
            // 
            this.labelMan.AutoSize = true;
            this.labelMan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMan.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMan.Location = new System.Drawing.Point(1289, 154);
            this.labelMan.Name = "labelMan";
            this.labelMan.Size = new System.Drawing.Size(156, 18);
            this.labelMan.TabIndex = 59;
            this.labelMan.Text = "MAN";
            this.labelMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelQualification
            // 
            this.labelQualification.AutoSize = true;
            this.labelQualification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQualification.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQualification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelQualification.Location = new System.Drawing.Point(1086, 154);
            this.labelQualification.Name = "labelQualification";
            this.labelQualification.Size = new System.Drawing.Size(196, 18);
            this.labelQualification.TabIndex = 60;
            this.labelQualification.Text = "QUALIF.";
            this.labelQualification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMMRevision
            // 
            this.labelMMRevision.AutoSize = true;
            this.labelMMRevision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMMRevision.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMMRevision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMMRevision.Location = new System.Drawing.Point(720, 154);
            this.labelMMRevision.Name = "labelMMRevision";
            this.labelMMRevision.Size = new System.Drawing.Size(156, 18);
            this.labelMMRevision.TabIndex = 51;
            this.labelMMRevision.Text = "DOC REVISION N";
            this.labelMMRevision.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMMRef
            // 
            this.labelMMRef.AutoSize = true;
            this.labelMMRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMMRef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMMRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMMRef.Location = new System.Drawing.Point(517, 154);
            this.labelMMRef.Name = "labelMMRef";
            this.labelMMRef.Size = new System.Drawing.Size(196, 18);
            this.labelMMRef.TabIndex = 52;
            this.labelMMRef.Text = "DOC REF.";
            this.labelMMRef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelJCRevDate
            // 
            this.labelJCRevDate.AutoSize = true;
            this.labelJCRevDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJCRevDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelJCRevDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelJCRevDate.Location = new System.Drawing.Point(883, 104);
            this.labelJCRevDate.Name = "labelJCRevDate";
            this.labelJCRevDate.Size = new System.Drawing.Size(196, 22);
            this.labelJCRevDate.TabIndex = 52;
            this.labelJCRevDate.Text = "REVISION DATE";
            this.labelJCRevDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelJCRevNumber
            // 
            this.labelJCRevNumber.AutoSize = true;
            this.labelJCRevNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelJCRevNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelJCRevNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelJCRevNumber.Location = new System.Drawing.Point(720, 104);
            this.labelJCRevNumber.Name = "labelJCRevNumber";
            this.labelJCRevNumber.Size = new System.Drawing.Size(156, 22);
            this.labelJCRevNumber.TabIndex = 51;
            this.labelJCRevNumber.Text = "REVISION N";
            this.labelJCRevNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerJCRevDate
            // 
            this.dateTimePickerJCRevDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerJCRevDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerJCRevDate.Location = new System.Drawing.Point(881, 127);
            this.dateTimePickerJCRevDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerJCRevDate.Name = "dateTimePickerJCRevDate";
            this.dateTimePickerJCRevDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerJCRevDate.TabIndex = 30;
            // 
            // labelMRO
            // 
            this.labelMRO.AutoSize = true;
            this.labelMRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMRO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMRO.Location = new System.Drawing.Point(517, 104);
            this.labelMRO.Name = "labelMRO";
            this.labelMRO.Size = new System.Drawing.Size(196, 22);
            this.labelMRO.TabIndex = 50;
            this.labelMRO.Text = "MRO";
            this.labelMRO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxQualification
            // 
            this.comboBoxQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQualification.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxQualification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxQualification.FormattingEnabled = true;
            this.comboBoxQualification.Location = new System.Drawing.Point(1084, 173);
            this.comboBoxQualification.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxQualification.Name = "comboBoxQualification";
            this.comboBoxQualification.Size = new System.Drawing.Size(200, 26);
            this.comboBoxQualification.TabIndex = 36;
            // 
            // textboxTitle
            // 
            this.textboxTitle.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.textboxTitle, 3);
            this.textboxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textboxTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxTitle.Location = new System.Drawing.Point(515, 77);
            this.textboxTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textboxTitle.MaxLength = 3000;
            this.textboxTitle.Name = "textboxTitle";
            this.textboxTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxTitle.Size = new System.Drawing.Size(566, 26);
            this.textboxTitle.TabIndex = 18;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDate.Location = new System.Drawing.Point(364, 54);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(146, 22);
            this.labelDate.TabIndex = 44;
            this.labelDate.Text = "DATE";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRelatedTask
            // 
            this.labelRelatedTask.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRelatedTask, 2);
            this.labelRelatedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRelatedTask.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRelatedTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRelatedTask.Location = new System.Drawing.Point(4, 154);
            this.labelRelatedTask.Name = "labelRelatedTask";
            this.labelRelatedTask.Size = new System.Drawing.Size(353, 18);
            this.labelRelatedTask.TabIndex = 42;
            this.labelRelatedTask.Text = "RELATED TASK / ATTACH.";
            this.labelRelatedTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACTATValue
            // 
            this.labelACTATValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACTATValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACTATValue.Location = new System.Drawing.Point(2, 127);
            this.labelACTATValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACTATValue.Name = "labelACTATValue";
            this.labelACTATValue.Size = new System.Drawing.Size(200, 22);
            this.labelACTATValue.TabIndex = 40;
            this.labelACTATValue.Text = "A/C TAT";
            this.labelACTATValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACTACValue
            // 
            this.labelACTACValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACTACValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACTACValue.Location = new System.Drawing.Point(205, 127);
            this.labelACTACValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACTACValue.Name = "labelACTACValue";
            this.labelACTACValue.Size = new System.Drawing.Size(150, 22);
            this.labelACTACValue.TabIndex = 41;
            this.labelACTACValue.Text = "A/C TAC";
            this.labelACTACValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACTotalTime
            // 
            this.labelACTotalTime.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACTotalTime.Location = new System.Drawing.Point(2, 104);
            this.labelACTotalTime.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACTotalTime.Name = "labelACTotalTime";
            this.labelACTotalTime.Size = new System.Drawing.Size(200, 22);
            this.labelACTotalTime.TabIndex = 40;
            this.labelACTotalTime.Text = "TAT";
            this.labelACTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACTotalCycles
            // 
            this.labelACTotalCycles.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACTotalCycles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACTotalCycles.Location = new System.Drawing.Point(207, 104);
            this.labelACTotalCycles.Name = "labelACTotalCycles";
            this.labelACTotalCycles.Size = new System.Drawing.Size(150, 22);
            this.labelACTotalCycles.TabIndex = 41;
            this.labelACTotalCycles.Text = "TAC";
            this.labelACTotalCycles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACTypeValue
            // 
            this.labelACTypeValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACTypeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACTypeValue.Location = new System.Drawing.Point(2, 77);
            this.labelACTypeValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACTypeValue.Name = "labelACTypeValue";
            this.labelACTypeValue.Size = new System.Drawing.Size(200, 22);
            this.labelACTypeValue.TabIndex = 39;
            this.labelACTypeValue.Text = "A/C Type";
            this.labelACTypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxZone
            // 
            this.textBoxZone.BackColor = System.Drawing.Color.White;
            this.textBoxZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxZone.Location = new System.Drawing.Point(1287, 127);
            this.textBoxZone.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxZone.MaxLength = 200;
            this.textBoxZone.Name = "textBoxZone";
            this.textBoxZone.Size = new System.Drawing.Size(160, 26);
            this.textBoxZone.TabIndex = 16;
            // 
            // labelACType
            // 
            this.labelACType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACType.Location = new System.Drawing.Point(2, 54);
            this.labelACType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACType.Name = "labelACType";
            this.labelACType.Size = new System.Drawing.Size(200, 22);
            this.labelACType.TabIndex = 0;
            this.labelACType.Text = "A/C Type";
            this.labelACType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelACReg
            // 
            this.labelACReg.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACReg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACReg.Location = new System.Drawing.Point(207, 54);
            this.labelACReg.Name = "labelACReg";
            this.labelACReg.Size = new System.Drawing.Size(150, 18);
            this.labelACReg.TabIndex = 18;
            this.labelACReg.Text = "A/C Reg.";
            this.labelACReg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ataChapterComboBox
            // 
            this.ataChapterComboBox.BackColor = System.Drawing.Color.White;
            this.ataChapterComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ataChapterComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ataChapterComboBox.FormattingEnabled = true;
            this.ataChapterComboBox.Location = new System.Drawing.Point(1084, 127);
            this.ataChapterComboBox.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ataChapterComboBox.Name = "ataChapterComboBox";
            this.ataChapterComboBox.Size = new System.Drawing.Size(200, 26);
            this.ataChapterComboBox.TabIndex = 1;
            // 
            // labelACRegValue
            // 
            this.labelACRegValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelACRegValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelACRegValue.Location = new System.Drawing.Point(205, 77);
            this.labelACRegValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelACRegValue.Name = "labelACRegValue";
            this.labelACRegValue.Size = new System.Drawing.Size(150, 22);
            this.labelACRegValue.TabIndex = 40;
            this.labelACRegValue.Text = "A/C Reg";
            this.labelACRegValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRelatedTaskValue
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.labelRelatedTaskValue, 2);
            this.labelRelatedTaskValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRelatedTaskValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRelatedTaskValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRelatedTaskValue.Location = new System.Drawing.Point(4, 173);
            this.labelRelatedTaskValue.Name = "labelRelatedTaskValue";
            this.labelRelatedTaskValue.Size = new System.Drawing.Size(353, 26);
            this.labelRelatedTaskValue.TabIndex = 43;
            this.labelRelatedTaskValue.Text = "Related Task";
            this.labelRelatedTaskValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDateValue
            // 
            this.labelDateValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateValue.Location = new System.Drawing.Point(362, 77);
            this.labelDateValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelDateValue.Name = "labelDateValue";
            this.labelDateValue.Size = new System.Drawing.Size(150, 22);
            this.labelDateValue.TabIndex = 45;
            this.labelDateValue.Text = "Date";
            this.labelDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStation
            // 
            this.labelStation.AutoSize = true;
            this.labelStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelStation.Location = new System.Drawing.Point(364, 104);
            this.labelStation.Name = "labelStation";
            this.labelStation.Size = new System.Drawing.Size(146, 22);
            this.labelStation.TabIndex = 46;
            this.labelStation.Text = "STATION";
            this.labelStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInterval.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelInterval.Location = new System.Drawing.Point(364, 154);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(146, 18);
            this.labelInterval.TabIndex = 47;
            this.labelInterval.Text = "INTERVAL";
            this.labelInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIntervalValue
            // 
            this.labelIntervalValue.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIntervalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelIntervalValue.Location = new System.Drawing.Point(362, 173);
            this.labelIntervalValue.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelIntervalValue.Name = "labelIntervalValue";
            this.labelIntervalValue.Size = new System.Drawing.Size(150, 22);
            this.labelIntervalValue.TabIndex = 49;
            this.labelIntervalValue.Text = "Interval";
            this.labelIntervalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMRO
            // 
            this.textBoxMRO.BackColor = System.Drawing.Color.White;
            this.textBoxMRO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMRO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxMRO.Location = new System.Drawing.Point(515, 127);
            this.textBoxMRO.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxMRO.MaxLength = 512;
            this.textBoxMRO.Name = "textBoxMRO";
            this.textBoxMRO.Size = new System.Drawing.Size(200, 26);
            this.textBoxMRO.TabIndex = 11;
            // 
            // textBoxStation
            // 
            this.textBoxStation.BackColor = System.Drawing.Color.White;
            this.textBoxStation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxStation.Location = new System.Drawing.Point(362, 127);
            this.textBoxStation.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxStation.MaxLength = 1000;
            this.textBoxStation.Name = "textBoxStation";
            this.textBoxStation.Size = new System.Drawing.Size(150, 26);
            this.textBoxStation.TabIndex = 5;
            // 
            // textBoxJCRevNumber
            // 
            this.textBoxJCRevNumber.BackColor = System.Drawing.Color.White;
            this.textBoxJCRevNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxJCRevNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxJCRevNumber.Location = new System.Drawing.Point(718, 127);
            this.textBoxJCRevNumber.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxJCRevNumber.MaxLength = 200;
            this.textBoxJCRevNumber.Name = "textBoxJCRevNumber";
            this.textBoxJCRevNumber.Size = new System.Drawing.Size(160, 26);
            this.textBoxJCRevNumber.TabIndex = 15;
            // 
            // labelATA
            // 
            this.labelATA.AutoSize = true;
            this.labelATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelATA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelATA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelATA.Location = new System.Drawing.Point(1086, 104);
            this.labelATA.Name = "labelATA";
            this.labelATA.Size = new System.Drawing.Size(196, 22);
            this.labelATA.TabIndex = 54;
            this.labelATA.Text = "ATA";
            this.labelATA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAccess
            // 
            this.labelAccess.AutoSize = true;
            this.labelAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAccess.Location = new System.Drawing.Point(1452, 104);
            this.labelAccess.Name = "labelAccess";
            this.labelAccess.Size = new System.Drawing.Size(196, 22);
            this.labelAccess.TabIndex = 55;
            this.labelAccess.Text = "ACCESS";
            this.labelAccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZone
            // 
            this.labelZone.AutoSize = true;
            this.labelZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelZone.Location = new System.Drawing.Point(1289, 104);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(156, 22);
            this.labelZone.TabIndex = 53;
            this.labelZone.Text = "ZONE";
            this.labelZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAccess
            // 
            this.textBoxAccess.BackColor = System.Drawing.Color.White;
            this.textBoxAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAccess.Location = new System.Drawing.Point(1450, 127);
            this.textBoxAccess.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxAccess.MaxLength = 200;
            this.textBoxAccess.Name = "textBoxAccess";
            this.textBoxAccess.Size = new System.Drawing.Size(200, 26);
            this.textBoxAccess.TabIndex = 17;
            // 
            // textBoxMMRevisionNumber
            // 
            this.textBoxMMRevisionNumber.BackColor = System.Drawing.Color.White;
            this.textBoxMMRevisionNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMMRevisionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxMMRevisionNumber.Location = new System.Drawing.Point(718, 173);
            this.textBoxMMRevisionNumber.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.textBoxMMRevisionNumber.MaxLength = 200;
            this.textBoxMMRevisionNumber.Name = "textBoxMMRevisionNumber";
            this.textBoxMMRevisionNumber.Size = new System.Drawing.Size(160, 26);
            this.textBoxMMRevisionNumber.TabIndex = 57;
            // 
            // dateTimePickerMMRevisionDate
            // 
            this.dateTimePickerMMRevisionDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerMMRevisionDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerMMRevisionDate.Location = new System.Drawing.Point(881, 173);
            this.dateTimePickerMMRevisionDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerMMRevisionDate.Name = "dateTimePickerMMRevisionDate";
            this.dateTimePickerMMRevisionDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerMMRevisionDate.TabIndex = 58;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 3);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTitle.Location = new System.Drawing.Point(517, 54);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(562, 22);
            this.labelTitle.TabIndex = 63;
            this.labelTitle.Text = "TITLE";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerCheckedDate
            // 
            this.dateTimePickerCheckedDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerCheckedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerCheckedDate.Location = new System.Drawing.Point(515, 238);
            this.dateTimePickerCheckedDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerCheckedDate.Name = "dateTimePickerCheckedDate";
            this.dateTimePickerCheckedDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerCheckedDate.TabIndex = 67;
            // 
            // dateTimePickerApprovedDate
            // 
            this.dateTimePickerApprovedDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerApprovedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerApprovedDate.Location = new System.Drawing.Point(1084, 238);
            this.dateTimePickerApprovedDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerApprovedDate.Name = "dateTimePickerApprovedDate";
            this.dateTimePickerApprovedDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerApprovedDate.TabIndex = 66;
            // 
            // comboBoxChechedBy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxChechedBy, 2);
            this.comboBoxChechedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxChechedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChechedBy.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxChechedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxChechedBy.FormattingEnabled = true;
            this.comboBoxChechedBy.Location = new System.Drawing.Point(718, 238);
            this.comboBoxChechedBy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxChechedBy.Name = "comboBoxChechedBy";
            this.comboBoxChechedBy.Size = new System.Drawing.Size(363, 26);
            this.comboBoxChechedBy.TabIndex = 21;
            // 
            // dateTimePickerPreparedDate
            // 
            this.dateTimePickerPreparedDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePickerPreparedDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerPreparedDate.Location = new System.Drawing.Point(2, 238);
            this.dateTimePickerPreparedDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.dateTimePickerPreparedDate.Name = "dateTimePickerPreparedDate";
            this.dateTimePickerPreparedDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerPreparedDate.TabIndex = 68;
            // 
            // comboBoxPreparedBy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxPreparedBy, 2);
            this.comboBoxPreparedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxPreparedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreparedBy.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxPreparedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxPreparedBy.FormattingEnabled = true;
            this.comboBoxPreparedBy.Location = new System.Drawing.Point(205, 238);
            this.comboBoxPreparedBy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxPreparedBy.Name = "comboBoxPreparedBy";
            this.comboBoxPreparedBy.Size = new System.Drawing.Size(307, 26);
            this.comboBoxPreparedBy.TabIndex = 20;
            // 
            // comboBoxApprovedBy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxApprovedBy, 2);
            this.comboBoxApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApprovedBy.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxApprovedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxApprovedBy.FormattingEnabled = true;
            this.comboBoxApprovedBy.Location = new System.Drawing.Point(1287, 238);
            this.comboBoxApprovedBy.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.comboBoxApprovedBy.Name = "comboBoxApprovedBy";
            this.comboBoxApprovedBy.Size = new System.Drawing.Size(363, 26);
            this.comboBoxApprovedBy.TabIndex = 63;
            // 
            // commonListViewControlEqipmentAndMaterials
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.commonListViewControlEqipmentAndMaterials, 12);
            this.commonListViewControlEqipmentAndMaterials.Displayer = null;
            this.commonListViewControlEqipmentAndMaterials.DisplayerText = null;
            this.commonListViewControlEqipmentAndMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonListViewControlEqipmentAndMaterials.Entity = null;
            this.commonListViewControlEqipmentAndMaterials.Location = new System.Drawing.Point(2, 369);
            this.commonListViewControlEqipmentAndMaterials.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.commonListViewControlEqipmentAndMaterials.Name = "commonListViewControlEqipmentAndMaterials";
            this.commonListViewControlEqipmentAndMaterials.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.commonListViewControlEqipmentAndMaterials.ShowGroups = true;
            this.commonListViewControlEqipmentAndMaterials.Size = new System.Drawing.Size(1648, 200);
            this.commonListViewControlEqipmentAndMaterials.TabIndex = 72;
            // 
            // jobCardTaskListControl
            // 
            this.jobCardTaskListControl.AttachedObject = null;
            this.jobCardTaskListControl.AutoSize = true;
            this.jobCardTaskListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.jobCardTaskListControl, 9);
            this.jobCardTaskListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobCardTaskListControl.JobCard = null;
            this.jobCardTaskListControl.Location = new System.Drawing.Point(2, 589);
            this.jobCardTaskListControl.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.jobCardTaskListControl.Name = "jobCardTaskListControl";
            this.jobCardTaskListControl.Size = new System.Drawing.Size(1648, 262);
            this.jobCardTaskListControl.TabIndex = 73;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.ButtonAdd);
            this.panelButtons.Controls.Add(this.buttonDelete);
            this.panelButtons.Location = new System.Drawing.Point(1452, 335);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(146, 30);
            this.panelButtons.TabIndex = 75;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAdd.ActiveBackgroundImage = null;
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
            this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
            this.ButtonAdd.Location = new System.Drawing.Point(80, 0);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = true;
            this.ButtonAdd.Size = new System.Drawing.Size(33, 30);
            this.ButtonAdd.TabIndex = 35;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "Add Item";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonDelete
			// 
			this.buttonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.ActiveBackgroundImage = null;
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.buttonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.buttonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.buttonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIconGraySmall;
            this.buttonDelete.Location = new System.Drawing.Point(113, 0);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.NormalBackgroundImage = null;
            this.buttonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonDelete.ShowToolTip = true;
            this.buttonDelete.Size = new System.Drawing.Size(33, 30);
            this.buttonDelete.TabIndex = 36;
            this.buttonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextMain = "";
            this.buttonDelete.TextSecondary = "";
            this.buttonDelete.ToolTipText = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.buttonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// JobCardControl
			// 
			this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "JobCardControl";
            this.Size = new System.Drawing.Size(1664, 972);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMan)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelBiWeeklyReport;
        private Label labelFooter;
        private TextBox textboxBiWeeklyReport;
        private TextBox textboxFooter;
        private FlowLayoutPanel flowLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxApplicability;
        private Label labelFormRev;
        private Label labelForm;
        private TextBox textBoxForm;
        private TextBox textboxFormRev;
        private Label labelFormRevDate;
        private DateTimePicker dateTimePickerFormRevDate;
        private TextBox textBoxWorkArea;
        private TextBox textBoxPhase;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox comboBoxWorkType;
        private Label labelJobCardHeader;
        private Label label1;
        private TextBox textboxJobCardHeader;
        private ComboBox comboBoxMMRef;
        private Label labelJobDescroption;
        private Label labelEquipmentAndMaterials;
        private Label label5;
        private Label label7;
        private Label labelApprovedBy;
        private Label label6;
        private Label labelCheckedBy;
        private TextBox textBoxAttachedTo;
        private Label label3;
        private Label label4;
        private Label labelPreparedBy;
        private Label labelAttachedTo;
        private Label label2;
        private NumericUpDown numericUpDownManHours;
        private NumericUpDown numericUpDownMan;
        private Label labelManHours;
        private Label labelMMRevisionDate;
        private Label labelMan;
        private Label labelQualification;
        private Label labelMMRevision;
        private Label labelMMRef;
        private Label labelJCRevDate;
        private Label labelJCRevNumber;
        private DateTimePicker dateTimePickerJCRevDate;
        private Label labelMRO;
        private ComboBox comboBoxQualification;
        private TextBox textboxTitle;
        private Label labelDate;
        private Label labelRelatedTask;
        private Label labelACTATValue;
        private Label labelACTACValue;
        private Label labelACTotalTime;
        private Label labelACTotalCycles;
        private Label labelACTypeValue;
        private TextBox textBoxZone;
        private Label labelACType;
        private Label labelACReg;
        private ATAChapterComboBox ataChapterComboBox;
        private Label labelACRegValue;
        private Label labelRelatedTaskValue;
        private Label labelDateValue;
        private Label labelStation;
        private Label labelInterval;
        private Label labelIntervalValue;
        private TextBox textBoxMRO;
        private TextBox textBoxStation;
        private TextBox textBoxJCRevNumber;
        private Label labelATA;
        private Label labelAccess;
        private Label labelZone;
        private TextBox textBoxAccess;
        private TextBox textBoxMMRevisionNumber;
        private DateTimePicker dateTimePickerMMRevisionDate;
        private Label labelTitle;
        private DateTimePicker dateTimePickerCheckedDate;
        private DateTimePicker dateTimePickerApprovedDate;
        private ComboBox comboBoxChechedBy;
        private DateTimePicker dateTimePickerPreparedDate;
        private ComboBox comboBoxPreparedBy;
        private ComboBox comboBoxApprovedBy;
        private CommonListViewControl commonListViewControlEqipmentAndMaterials;
        private JobCardTaskListControl jobCardTaskListControl;
        private Panel panelButtons;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT buttonDelete;

    }
}
