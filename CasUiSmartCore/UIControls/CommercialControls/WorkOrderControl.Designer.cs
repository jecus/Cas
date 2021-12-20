using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.JobCardControls;
using CASTerms;
using CAS.UI.Helpers;
using Entity.Abstractions;
namespace CAS.UI.UIControls.CommercialControls
{
	partial class WorkOrderControl
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
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
			this.labelFooter = new System.Windows.Forms.Label();
			this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
			this.textboxFooter = new System.Windows.Forms.TextBox();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.numericUpDownCost = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonAddTask = new AvControls.AvButtonT.AvButtonT();
			this.buttonDeleteTask = new AvControls.AvButtonT.AvButtonT();
			this.workOrderViewControl = new CAS.UI.UIControls.CommercialControls.WorkOrderViewControl();
			this.labelFormRev = new System.Windows.Forms.Label();
			this.labelForm = new System.Windows.Forms.Label();
			this.textBoxForm = new System.Windows.Forms.TextBox();
			this.textboxFormRev = new System.Windows.Forms.TextBox();
			this.labelFormRevDate = new System.Windows.Forms.Label();
			this.dateTimePickerFormRevDate = new System.Windows.Forms.DateTimePicker();
			this.labelWorkOrderHeader = new System.Windows.Forms.Label();
			this.textboxWorkOrderHeader = new System.Windows.Forms.TextBox();
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
			this.textboxNumber = new System.Windows.Forms.TextBox();
			this.labelDate = new System.Windows.Forms.Label();
			this.labelACTATValue = new System.Windows.Forms.Label();
			this.labelACTACValue = new System.Windows.Forms.Label();
			this.labelACTotalTime = new System.Windows.Forms.Label();
			this.labelACTotalCycles = new System.Windows.Forms.Label();
			this.labelACTypeValue = new System.Windows.Forms.Label();
			this.labelACType = new System.Windows.Forms.Label();
			this.labelACReg = new System.Windows.Forms.Label();
			this.labelACRegValue = new System.Windows.Forms.Label();
			this.labelDateValue = new System.Windows.Forms.Label();
			this.labelStation = new System.Windows.Forms.Label();
			this.labelNumber = new System.Windows.Forms.Label();
			this.dateTimePickerCheckedDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerApprovedDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxChechedBy = new System.Windows.Forms.ComboBox();
			this.dateTimePickerPreparedDate = new System.Windows.Forms.DateTimePicker();
			this.comboBoxPreparedBy = new System.Windows.Forms.ComboBox();
			this.comboBoxApprovedBy = new System.Windows.Forms.ComboBox();
			this.commonListViewControlEqipmentAndMaterials = new CAS.UI.UIControls.Auxiliary.CommonListViewControl();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
			this.numericUpDownMan = new System.Windows.Forms.NumericUpDown();
			this.labelMan = new System.Windows.Forms.Label();
			this.numericUpDownManHours = new System.Windows.Forms.NumericUpDown();
			this.labelManHours = new System.Windows.Forms.Label();
			this.labelCost = new System.Windows.Forms.Label();
			this.labelTasks = new System.Windows.Forms.Label();
			this.comboBoxRequest = new System.Windows.Forms.ComboBox();
			this.labelRequest = new System.Windows.Forms.Label();
			this.textBoxCustomer = new System.Windows.Forms.TextBox();
			this.labelCustomer = new System.Windows.Forms.Label();
			this.textBoxStation = new System.Windows.Forms.TextBox();
			this.labelMRO = new System.Windows.Forms.Label();
			this.textBoxMRO = new System.Windows.Forms.TextBox();
			this.flowLayoutPanelMain.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).BeginInit();
			this.panel1.SuspendLayout();
			this.panelButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMan)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).BeginInit();
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
			this.labelFooter.Location = new System.Drawing.Point(2, 884);
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
			this.textboxFooter.Location = new System.Drawing.Point(2, 903);
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
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1658, 998);
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
			this.tableLayoutPanel1.Controls.Add(this.labelDescription, 3, 6);
			this.tableLayoutPanel1.Controls.Add(this.labelTitle, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBoxTitle, 3, 5);
			this.tableLayoutPanel1.Controls.Add(this.textBoxDescription, 3, 7);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownCost, 8, 17);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 8, 14);
			this.tableLayoutPanel1.Controls.Add(this.workOrderViewControl, 0, 15);
			this.tableLayoutPanel1.Controls.Add(this.labelFooter, 0, 18);
			this.tableLayoutPanel1.Controls.Add(this.textboxFooter, 0, 19);
			this.tableLayoutPanel1.Controls.Add(this.labelFormRev, 7, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelForm, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBoxForm, 6, 1);
			this.tableLayoutPanel1.Controls.Add(this.textboxFormRev, 7, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelFormRevDate, 8, 0);
			this.tableLayoutPanel1.Controls.Add(this.dateTimePickerFormRevDate, 8, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelWorkOrderHeader, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textboxWorkOrderHeader, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelEquipmentAndMaterials, 1, 12);
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
			this.tableLayoutPanel1.Controls.Add(this.textboxNumber, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelDate, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelACTATValue, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelACTACValue, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelACTotalTime, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelACTotalCycles, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelACTypeValue, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelACType, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelACReg, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelACRegValue, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelDateValue, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelStation, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelNumber, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.dateTimePickerCheckedDate, 3, 10);
			this.tableLayoutPanel1.Controls.Add(this.dateTimePickerApprovedDate, 6, 10);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxChechedBy, 4, 10);
			this.tableLayoutPanel1.Controls.Add(this.dateTimePickerPreparedDate, 0, 10);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxPreparedBy, 1, 10);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxApprovedBy, 7, 10);
			this.tableLayoutPanel1.Controls.Add(this.commonListViewControlEqipmentAndMaterials, 0, 13);
			this.tableLayoutPanel1.Controls.Add(this.panelButtons, 8, 12);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownMan, 6, 17);
			this.tableLayoutPanel1.Controls.Add(this.labelMan, 6, 16);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownManHours, 7, 17);
			this.tableLayoutPanel1.Controls.Add(this.labelManHours, 7, 16);
			this.tableLayoutPanel1.Controls.Add(this.labelCost, 8, 16);
			this.tableLayoutPanel1.Controls.Add(this.labelTasks, 1, 14);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxRequest, 6, 7);
			this.tableLayoutPanel1.Controls.Add(this.labelRequest, 6, 6);
			this.tableLayoutPanel1.Controls.Add(this.textBoxCustomer, 6, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelCustomer, 6, 4);
			this.tableLayoutPanel1.Controls.Add(this.textBoxStation, 2, 5);
			this.tableLayoutPanel1.Controls.Add(this.labelMRO, 2, 6);
			this.tableLayoutPanel1.Controls.Add(this.textBoxMRO, 2, 7);
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
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1652, 992);
			this.tableLayoutPanel1.TabIndex = 29;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelDescription, 3);
			this.labelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(517, 154);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(562, 18);
			this.labelDescription.TabIndex = 90;
			this.labelDescription.Text = "DESCRIPTION";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 3);
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTitle.Location = new System.Drawing.Point(517, 104);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(562, 22);
			this.labelTitle.TabIndex = 89;
			this.labelTitle.Text = "TITLE";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxTitle, 3);
			this.textBoxTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTitle.Location = new System.Drawing.Point(515, 127);
			this.textBoxTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textBoxTitle.MaxLength = 3000;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxTitle.Size = new System.Drawing.Size(566, 26);
			this.textBoxTitle.TabIndex = 88;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxDescription, 3);
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(515, 173);
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textBoxDescription.MaxLength = 3000;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(566, 26);
			this.textBoxDescription.TabIndex = 87;
			// 
			// numericUpDownCost
			// 
			this.numericUpDownCost.DecimalPlaces = 2;
			this.numericUpDownCost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.numericUpDownCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownCost.Location = new System.Drawing.Point(1450, 857);
			this.numericUpDownCost.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.numericUpDownCost.Maximum = new decimal(new int[] {
			1000000000,
			0,
			0,
			0});
			this.numericUpDownCost.Name = "numericUpDownCost";
			this.numericUpDownCost.Size = new System.Drawing.Size(200, 26);
			this.numericUpDownCost.TabIndex = 85;
			this.numericUpDownCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonAddTask);
			this.panel1.Controls.Add(this.buttonDeleteTask);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(1450, 518);
			this.panel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 30);
			this.panel1.TabIndex = 76;
			// 
			// buttonAddTask
			// 
			this.buttonAddTask.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonAddTask.ActiveBackgroundImage = null;
			this.buttonAddTask.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddTask.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonAddTask.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.buttonAddTask.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonAddTask.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.buttonAddTask.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonAddTask.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
			this.buttonAddTask.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddTask.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.buttonAddTask.Location = new System.Drawing.Point(134, 0);
			this.buttonAddTask.Margin = new System.Windows.Forms.Padding(5);
			this.buttonAddTask.Name = "buttonAddTask";
			this.buttonAddTask.NormalBackgroundImage = null;
			this.buttonAddTask.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddTask.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddTask.ShowToolTip = true;
			this.buttonAddTask.Size = new System.Drawing.Size(33, 30);
			this.buttonAddTask.TabIndex = 35;
			this.buttonAddTask.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddTask.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddTask.TextMain = "";
			this.buttonAddTask.TextSecondary = "";
			this.buttonAddTask.ToolTipText = "Add Item";
			this.buttonAddTask.Click += new System.EventHandler(this.ButtonAddTaskClick);
			this.buttonAddTask.Enabled = !(userType == UserType.ReadOnly);
			// 
			// buttonDeleteTask
			// 
			this.buttonDeleteTask.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonDeleteTask.ActiveBackgroundImage = null;
			this.buttonDeleteTask.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDeleteTask.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonDeleteTask.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.buttonDeleteTask.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonDeleteTask.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.buttonDeleteTask.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonDeleteTask.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.buttonDeleteTask.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDeleteTask.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIconGraySmall;
			this.buttonDeleteTask.Location = new System.Drawing.Point(167, 0);
			this.buttonDeleteTask.Margin = new System.Windows.Forms.Padding(5);
			this.buttonDeleteTask.Name = "buttonDeleteTask";
			this.buttonDeleteTask.NormalBackgroundImage = null;
			this.buttonDeleteTask.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteTask.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDeleteTask.ShowToolTip = true;
			this.buttonDeleteTask.Size = new System.Drawing.Size(33, 30);
			this.buttonDeleteTask.TabIndex = 36;
			this.buttonDeleteTask.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteTask.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteTask.TextMain = "";
			this.buttonDeleteTask.TextSecondary = "";
			this.buttonDeleteTask.ToolTipText = "Delete";
			this.buttonDeleteTask.Click += new System.EventHandler(this.ButtonDeleteTaskClick);
			this.buttonDeleteTask.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// workOrderViewControl
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.workOrderViewControl, 9);
			this.workOrderViewControl.Displayer = null;
			this.workOrderViewControl.DisplayerText = null;
			this.workOrderViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workOrderViewControl.Entity = null;
			this.workOrderViewControl.Location = new System.Drawing.Point(2, 549);
			this.workOrderViewControl.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.workOrderViewControl.Name = "workOrderViewControl";
			this.workOrderViewControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.workOrderViewControl.ShowAddNew = false;
			this.workOrderViewControl.Size = new System.Drawing.Size(1648, 288);
			this.workOrderViewControl.TabIndex = 39;
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
			this.labelForm.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelForm.Location = new System.Drawing.Point(1086, 1);
			this.labelForm.Name = "labelForm";
			this.labelForm.Size = new System.Drawing.Size(55, 18);
			this.labelForm.TabIndex = 28;
			this.labelForm.Text = "Form:";
			this.labelForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxForm
			// 
			this.textBoxForm.BackColor = System.Drawing.Color.White;
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
			// labelWorkOrderHeader
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.labelWorkOrderHeader, 6);
			this.labelWorkOrderHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelWorkOrderHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWorkOrderHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWorkOrderHeader.Location = new System.Drawing.Point(2, 1);
			this.labelWorkOrderHeader.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.labelWorkOrderHeader.Name = "labelWorkOrderHeader";
			this.labelWorkOrderHeader.Size = new System.Drawing.Size(1079, 25);
			this.labelWorkOrderHeader.TabIndex = 0;
			this.labelWorkOrderHeader.Text = "Work Order Header";
			this.labelWorkOrderHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textboxWorkOrderHeader
			// 
			this.textboxWorkOrderHeader.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxWorkOrderHeader, 6);
			this.textboxWorkOrderHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textboxWorkOrderHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxWorkOrderHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxWorkOrderHeader.Location = new System.Drawing.Point(2, 27);
			this.textboxWorkOrderHeader.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textboxWorkOrderHeader.MaxLength = 1000;
			this.textboxWorkOrderHeader.Name = "textboxWorkOrderHeader";
			this.textboxWorkOrderHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxWorkOrderHeader.Size = new System.Drawing.Size(1079, 26);
			this.textboxWorkOrderHeader.TabIndex = 19;
			// 
			// labelEquipmentAndMaterials
			// 
			this.labelEquipmentAndMaterials.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelEquipmentAndMaterials, 7);
			this.labelEquipmentAndMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelEquipmentAndMaterials.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEquipmentAndMaterials.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEquipmentAndMaterials.Location = new System.Drawing.Point(207, 286);
			this.labelEquipmentAndMaterials.Name = "labelEquipmentAndMaterials";
			this.labelEquipmentAndMaterials.Size = new System.Drawing.Size(1238, 30);
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
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(4, 219);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(196, 18);
			this.label2.TabIndex = 62;
			this.label2.Text = "DATE";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textboxNumber
			// 
			this.textboxNumber.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textboxNumber, 3);
			this.textboxNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxNumber.Location = new System.Drawing.Point(515, 77);
			this.textboxNumber.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textboxNumber.MaxLength = 3000;
			this.textboxNumber.Name = "textboxNumber";
			this.textboxNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxNumber.Size = new System.Drawing.Size(566, 26);
			this.textboxNumber.TabIndex = 18;
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
			// labelNumber
			// 
			this.labelNumber.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelNumber, 3);
			this.labelNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNumber.Location = new System.Drawing.Point(517, 54);
			this.labelNumber.Name = "labelNumber";
			this.labelNumber.Size = new System.Drawing.Size(562, 22);
			this.labelNumber.TabIndex = 63;
			this.labelNumber.Text = "NUMBER";
			this.labelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.comboBoxChechedBy.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			this.comboBoxPreparedBy.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
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
			this.comboBoxApprovedBy.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// commonListViewControlEqipmentAndMaterials
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.commonListViewControlEqipmentAndMaterials, 12);
			this.commonListViewControlEqipmentAndMaterials.Displayer = null;
			this.commonListViewControlEqipmentAndMaterials.DisplayerText = null;
			this.commonListViewControlEqipmentAndMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
			this.commonListViewControlEqipmentAndMaterials.Entity = null;
			this.commonListViewControlEqipmentAndMaterials.Location = new System.Drawing.Point(2, 317);
			this.commonListViewControlEqipmentAndMaterials.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.commonListViewControlEqipmentAndMaterials.Name = "commonListViewControlEqipmentAndMaterials";
			this.commonListViewControlEqipmentAndMaterials.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.commonListViewControlEqipmentAndMaterials.ShowGroups = true;
			this.commonListViewControlEqipmentAndMaterials.Size = new System.Drawing.Size(1648, 200);
			this.commonListViewControlEqipmentAndMaterials.TabIndex = 72;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.ButtonAdd);
			this.panelButtons.Controls.Add(this.buttonDelete);
			this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelButtons.Location = new System.Drawing.Point(1450, 286);
			this.panelButtons.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(200, 30);
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
			this.ButtonAdd.Location = new System.Drawing.Point(134, 0);
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
			this.ButtonAdd.Enabled = !(userType == UserType.ReadOnly);
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
			this.buttonDelete.Location = new System.Drawing.Point(167, 0);
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
			this.buttonDelete.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// numericUpDownMan
			// 
			this.numericUpDownMan.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownMan.Location = new System.Drawing.Point(1084, 857);
			this.numericUpDownMan.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.numericUpDownMan.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownMan.Name = "numericUpDownMan";
			this.numericUpDownMan.Size = new System.Drawing.Size(200, 26);
			this.numericUpDownMan.TabIndex = 63;
			this.numericUpDownMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownMan.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// labelMan
			// 
			this.labelMan.AutoSize = true;
			this.labelMan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelMan.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMan.Location = new System.Drawing.Point(1086, 838);
			this.labelMan.Name = "labelMan";
			this.labelMan.Size = new System.Drawing.Size(196, 18);
			this.labelMan.TabIndex = 59;
			this.labelMan.Text = "MAN";
			this.labelMan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numericUpDownManHours
			// 
			this.numericUpDownManHours.DecimalPlaces = 2;
			this.numericUpDownManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDownManHours.Location = new System.Drawing.Point(1287, 857);
			this.numericUpDownManHours.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.numericUpDownManHours.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericUpDownManHours.Name = "numericUpDownManHours";
			this.numericUpDownManHours.Size = new System.Drawing.Size(160, 26);
			this.numericUpDownManHours.TabIndex = 62;
			this.numericUpDownManHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelManHours
			// 
			this.labelManHours.AutoSize = true;
			this.labelManHours.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(1289, 838);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(156, 18);
			this.labelManHours.TabIndex = 62;
			this.labelManHours.Text = "M/H";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCost
			// 
			this.labelCost.AutoSize = true;
			this.labelCost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(1452, 838);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(196, 18);
			this.labelCost.TabIndex = 86;
			this.labelCost.Text = "COST";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTasks
			// 
			this.labelTasks.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelTasks, 7);
			this.labelTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTasks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTasks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTasks.Location = new System.Drawing.Point(207, 518);
			this.labelTasks.Name = "labelTasks";
			this.labelTasks.Size = new System.Drawing.Size(1238, 30);
			this.labelTasks.TabIndex = 74;
			this.labelTasks.Text = "TASKS - COMPONENTS - GROUND EQUIPMENT";
			this.labelTasks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// comboBoxRequest
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxRequest, 3);
			this.comboBoxRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRequest.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxRequest.FormattingEnabled = true;
			this.comboBoxRequest.Location = new System.Drawing.Point(1084, 173);
			this.comboBoxRequest.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.comboBoxRequest.Name = "comboBoxRequest";
			this.comboBoxRequest.Size = new System.Drawing.Size(566, 26);
			this.comboBoxRequest.TabIndex = 76;
			this.comboBoxRequest.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelRequest
			// 
			this.labelRequest.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelRequest, 3);
			this.labelRequest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelRequest.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRequest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRequest.Location = new System.Drawing.Point(1086, 154);
			this.labelRequest.Name = "labelRequest";
			this.labelRequest.Size = new System.Drawing.Size(562, 18);
			this.labelRequest.TabIndex = 52;
			this.labelRequest.Text = "REQUEST";
			this.labelRequest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxCustomer
			// 
			this.textBoxCustomer.BackColor = System.Drawing.Color.White;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxCustomer, 3);
			this.textBoxCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCustomer.Location = new System.Drawing.Point(1084, 127);
			this.textBoxCustomer.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textBoxCustomer.MaxLength = 200;
			this.textBoxCustomer.Name = "textBoxCustomer";
			this.textBoxCustomer.Size = new System.Drawing.Size(566, 26);
			this.textBoxCustomer.TabIndex = 16;
			// 
			// labelCustomer
			// 
			this.labelCustomer.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelCustomer, 3);
			this.labelCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCustomer.Location = new System.Drawing.Point(1086, 104);
			this.labelCustomer.Name = "labelCustomer";
			this.labelCustomer.Size = new System.Drawing.Size(562, 22);
			this.labelCustomer.TabIndex = 53;
			this.labelCustomer.Text = "CUSTOMER";
			this.labelCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			// labelMRO
			// 
			this.labelMRO.AutoSize = true;
			this.labelMRO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelMRO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMRO.Location = new System.Drawing.Point(364, 154);
			this.labelMRO.Name = "labelMRO";
			this.labelMRO.Size = new System.Drawing.Size(146, 18);
			this.labelMRO.TabIndex = 50;
			this.labelMRO.Text = "MRO";
			this.labelMRO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxMRO
			// 
			this.textBoxMRO.BackColor = System.Drawing.Color.White;
			this.textBoxMRO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMRO.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMRO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMRO.Location = new System.Drawing.Point(362, 173);
			this.textBoxMRO.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.textBoxMRO.MaxLength = 512;
			this.textBoxMRO.Name = "textBoxMRO";
			this.textBoxMRO.Size = new System.Drawing.Size(150, 26);
			this.textBoxMRO.TabIndex = 11;
			// 
			// WorkOrderControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Name = "WorkOrderControl";
			this.Size = new System.Drawing.Size(1668, 1012);
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCost)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panelButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMan)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownManHours)).EndInit();
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
		private Label labelFormRev;
		private Label labelForm;
		private TextBox textBoxForm;
		private TextBox textboxFormRev;
		private Label labelFormRevDate;
		private DateTimePicker dateTimePickerFormRevDate;
		private Label labelWorkOrderHeader;
		private TextBox textboxWorkOrderHeader;
		private Label labelTasks;
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
		private Label labelMan;
		private Label labelRequest;
		private Label labelMRO;
		private TextBox textboxNumber;
		private Label labelDate;
		private Label labelACTotalTime;
		private Label labelACTotalCycles;
		private Label labelACTypeValue;
		private Label labelACType;
		private Label labelACReg;
		private Label labelACRegValue;
		private Label labelDateValue;
		private Label labelStation;
		private Label labelCustomer;
		private Label labelNumber;
		private DateTimePicker dateTimePickerCheckedDate;
		private DateTimePicker dateTimePickerApprovedDate;
		private ComboBox comboBoxChechedBy;
		private DateTimePicker dateTimePickerPreparedDate;
		private ComboBox comboBoxPreparedBy;
		private ComboBox comboBoxApprovedBy;
		private Panel panelButtons;
		private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT buttonDelete;
		private WorkOrderViewControl workOrderViewControl;
		private CommonListViewControl commonListViewControlEqipmentAndMaterials;
		private Panel panel1;
		private AvControls.AvButtonT.AvButtonT buttonAddTask;
		private AvControls.AvButtonT.AvButtonT buttonDeleteTask;
		private NumericUpDown numericUpDownCost;
		private Label labelCost;
		private Label labelACTATValue;
		private Label labelACTACValue;
		private TextBox textBoxMRO;
		private TextBox textBoxStation;
		private TextBox textBoxCustomer;
		private ComboBox comboBoxRequest;
		private Label labelDescription;
		private Label labelTitle;
		private TextBox textBoxTitle;
		private TextBox textBoxDescription;

	}
}
