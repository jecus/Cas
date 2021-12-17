using AvControls.AvButtonT;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceGeneralDateControl
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
			if (disposing)
			{
				comboBoxSchedule.SelectedIndexChanged -= ComboBoxScheduleSelectedIndexChanged;
				comboBoxCheckNaming.SelectedIndexChanged -= ComboBoxCheckNamingSelectedIndexChanged;
				checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;

				listViewMaintenanceChecks.SelectedIndexChanged -= ListViewMaintenanceChecksSelectedIndexChanged;
				listViewMaintenanceChecks.MouseDoubleClick -= ListViewMaintenanceChecksMouseDoubleClick;
			}

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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
			"C01",
			"24000H",
			"2400H",
			"1000000",
			"10000",
			"Yes"}, -1);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaintenanceGeneralDateControl));
			this.listViewMaintenanceChecks = new System.Windows.Forms.ListView();
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderInterval = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderNotify = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ManHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.KitRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStripCheck = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.avButtonAddCheck = new AvControls.AvButtonT.AvButtonT();
			this.avButtonEditCheck = new AvControls.AvButtonT.AvButtonT();
			this.avButtonDeleteCheck = new AvControls.AvButtonT.AvButtonT();
			this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderWorkArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderManHours = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderKitRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.avButtonAddJobCard = new AvControls.AvButtonT.AvButtonT();
			this.avButtonViewJobCard = new AvControls.AvButtonT.AvButtonT();
			this.avButtonEditJobCard = new AvControls.AvButtonT.AvButtonT();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.labelCheckNaming = new System.Windows.Forms.Label();
			this.comboBoxCheckNaming = new System.Windows.Forms.ComboBox();
			this.comboBoxSchedule = new System.Windows.Forms.ComboBox();
			this.labelProgram = new System.Windows.Forms.Label();
			this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
			this.listViewBindedTasks = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.listViewTasksForSelect = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView();
			this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
			this.contextMenuStripCheck.SuspendLayout();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// listViewMaintenanceChecks
			// 
			this.listViewMaintenanceChecks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeaderName,
			this.columnHeaderInterval,
			this.columnHeaderNotify,
			this.Cost,
			this.ManHours,
			this.KitRequired});
			this.listViewMaintenanceChecks.ContextMenuStrip = this.contextMenuStripCheck;
			this.listViewMaintenanceChecks.FullRowSelect = true;
			this.listViewMaintenanceChecks.GridLines = true;
			this.listViewMaintenanceChecks.HideSelection = false;
			this.listViewMaintenanceChecks.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
			listViewItem1});
			this.listViewMaintenanceChecks.Location = new System.Drawing.Point(0, 123);
			this.listViewMaintenanceChecks.MultiSelect = false;
			this.listViewMaintenanceChecks.Name = "listViewMaintenanceChecks";
			this.listViewMaintenanceChecks.Size = new System.Drawing.Size(375, 454);
			this.listViewMaintenanceChecks.TabIndex = 0;
			this.listViewMaintenanceChecks.UseCompatibleStateImageBehavior = false;
			this.listViewMaintenanceChecks.View = System.Windows.Forms.View.Details;
			this.listViewMaintenanceChecks.SelectedIndexChanged += new System.EventHandler(this.ListViewMaintenanceChecksSelectedIndexChanged);
			this.listViewMaintenanceChecks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewMaintenanceChecksMouseDoubleClick);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 50;
			// 
			// columnHeaderInterval
			// 
			this.columnHeaderInterval.Text = "Interval";
			this.columnHeaderInterval.Width = 75;
			// 
			// columnHeaderNotify
			// 
			this.columnHeaderNotify.Text = "Notify";
			this.columnHeaderNotify.Width = 75;
			// 
			// Cost
			// 
			this.Cost.Text = "Cost";
			// 
			// ManHours
			// 
			this.ManHours.Text = "M.H.";
			this.ManHours.Width = 50;
			// 
			// KitRequired
			// 
			this.KitRequired.Text = "Kit";
			this.KitRequired.Width = 50;
			// 
			// contextMenuStripCheck
			// 
			this.contextMenuStripCheck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripSeparator2,
			this.addToolStripMenuItem,
			this.editToolStripMenuItem,
			this.deleteToolStripMenuItem,
			this.toolStripSeparator1});
			this.contextMenuStripCheck.Name = "contextMenuStripLimitation";
			this.contextMenuStripCheck.ShowImageMargin = false;
			this.contextMenuStripCheck.Size = new System.Drawing.Size(83, 82);
			this.contextMenuStripCheck.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripLimitationOpening);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(79, 6);
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItemClick);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(79, 6);
			// 
			// avButtonAddCheck
			// 
			this.avButtonAddCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonAddCheck.ActiveBackgroundImage = null;
			this.avButtonAddCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonAddCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonAddCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonAddCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonAddCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonAddCheck.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.avButtonAddCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonAddCheck.IconNotEnabled = null;
			this.avButtonAddCheck.Location = new System.Drawing.Point(3, 63);
			this.avButtonAddCheck.Name = "avButtonAddCheck";
			this.avButtonAddCheck.NormalBackgroundImage = null;
			this.avButtonAddCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonAddCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonAddCheck.ShowToolTip = true;
			this.avButtonAddCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonAddCheck.TabIndex = 3;
			this.avButtonAddCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddCheck.TextMain = "";
			this.avButtonAddCheck.TextSecondary = "";
			this.avButtonAddCheck.ToolTipText = "Add";
			this.avButtonAddCheck.Click += new System.EventHandler(this.AvButtonAddClick);
			this.avButtonAddCheck.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// avButtonEditCheck
			// 
			this.avButtonEditCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonEditCheck.ActiveBackgroundImage = null;
			this.avButtonEditCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonEditCheck.Enabled = false;
			this.avButtonEditCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonEditCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonEditCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonEditCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonEditCheck.Icon = global::CAS.UI.Properties.Resources.EditIcon;
			this.avButtonEditCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonEditCheck.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
			this.avButtonEditCheck.Location = new System.Drawing.Point(63, 63);
			this.avButtonEditCheck.Name = "avButtonEditCheck";
			this.avButtonEditCheck.NormalBackgroundImage = null;
			this.avButtonEditCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonEditCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonEditCheck.ShowToolTip = true;
			this.avButtonEditCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonEditCheck.TabIndex = 4;
			this.avButtonEditCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditCheck.TextMain = "";
			this.avButtonEditCheck.TextSecondary = "";
			this.avButtonEditCheck.ToolTipText = "Edit";
			this.avButtonEditCheck.Click += new System.EventHandler(this.AvButtonEditClick);
			this.avButtonEditCheck.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// avButtonDeleteCheck
			// 
			this.avButtonDeleteCheck.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonDeleteCheck.ActiveBackgroundImage = null;
			this.avButtonDeleteCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonDeleteCheck.Enabled = false;
			this.avButtonDeleteCheck.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonDeleteCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonDeleteCheck.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonDeleteCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonDeleteCheck.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.avButtonDeleteCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonDeleteCheck.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.avButtonDeleteCheck.Location = new System.Drawing.Point(123, 63);
			this.avButtonDeleteCheck.Name = "avButtonDeleteCheck";
			this.avButtonDeleteCheck.NormalBackgroundImage = null;
			this.avButtonDeleteCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonDeleteCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonDeleteCheck.ShowToolTip = true;
			this.avButtonDeleteCheck.Size = new System.Drawing.Size(54, 54);
			this.avButtonDeleteCheck.TabIndex = 5;
			this.avButtonDeleteCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonDeleteCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonDeleteCheck.TextMain = "";
			this.avButtonDeleteCheck.TextSecondary = "";
			this.avButtonDeleteCheck.ToolTipText = "Delete";
			this.avButtonDeleteCheck.Click += new System.EventHandler(this.AvButtonDeleteClick);
			this.avButtonDeleteCheck.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// columnHeaderTitle
			// 
			this.columnHeaderTitle.Text = "Title";
			this.columnHeaderTitle.Width = 156;
			// 
			// columnHeaderWorkArea
			// 
			this.columnHeaderWorkArea.Text = "WorkArea";
			this.columnHeaderWorkArea.Width = 78;
			// 
			// columnHeaderManHours
			// 
			this.columnHeaderManHours.Text = "ManHours";
			this.columnHeaderManHours.Width = 85;
			// 
			// columnHeaderCost
			// 
			this.columnHeaderCost.Text = "Cost";
			this.columnHeaderCost.Width = 70;
			// 
			// columnHeaderRev
			// 
			this.columnHeaderRev.Text = "Rev";
			this.columnHeaderRev.Width = 66;
			// 
			// columnHeaderRemarks
			// 
			this.columnHeaderRemarks.Text = "Remarks";
			this.columnHeaderRemarks.Width = 76;
			// 
			// columnHeaderKitRequired
			// 
			this.columnHeaderKitRequired.Text = "KitRequired";
			this.columnHeaderKitRequired.Width = 100;
			// 
			// avButtonAddJobCard
			// 
			this.avButtonAddJobCard.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonAddJobCard.ActiveBackgroundImage = null;
			this.avButtonAddJobCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonAddJobCard.Enabled = false;
			this.avButtonAddJobCard.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonAddJobCard.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonAddJobCard.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonAddJobCard.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonAddJobCard.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.avButtonAddJobCard.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonAddJobCard.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.avButtonAddJobCard.Location = new System.Drawing.Point(719, 63);
			this.avButtonAddJobCard.Name = "avButtonAddJobCard";
			this.avButtonAddJobCard.NormalBackgroundImage = null;
			this.avButtonAddJobCard.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonAddJobCard.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonAddJobCard.ShowToolTip = true;
			this.avButtonAddJobCard.Size = new System.Drawing.Size(54, 54);
			this.avButtonAddJobCard.TabIndex = 9;
			this.avButtonAddJobCard.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddJobCard.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonAddJobCard.TextMain = "";
			this.avButtonAddJobCard.TextSecondary = "";
			this.avButtonAddJobCard.ToolTipText = "Add Item";
			this.avButtonAddJobCard.Click += new System.EventHandler(this.AvButtonAddJobCardClick);
			this.avButtonAddJobCard.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// avButtonViewJobCard
			// 
			this.avButtonViewJobCard.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonViewJobCard.ActiveBackgroundImage = null;
			this.avButtonViewJobCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonViewJobCard.Enabled = false;
			this.avButtonViewJobCard.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonViewJobCard.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonViewJobCard.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonViewJobCard.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonViewJobCard.Icon = global::CAS.UI.Properties.Resources.PDFIcon;
			this.avButtonViewJobCard.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonViewJobCard.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIcon_gray;
			this.avButtonViewJobCard.Location = new System.Drawing.Point(899, 63);
			this.avButtonViewJobCard.Name = "avButtonViewJobCard";
			this.avButtonViewJobCard.NormalBackgroundImage = null;
			this.avButtonViewJobCard.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonViewJobCard.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonViewJobCard.ShowToolTip = true;
			this.avButtonViewJobCard.Size = new System.Drawing.Size(54, 54);
			this.avButtonViewJobCard.TabIndex = 12;
			this.avButtonViewJobCard.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonViewJobCard.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonViewJobCard.TextMain = "";
			this.avButtonViewJobCard.TextSecondary = "";
			this.avButtonViewJobCard.ToolTipText = "View JobCard";
			this.avButtonViewJobCard.Click += new System.EventHandler(this.AvButtonViewJobCardClick);
			// 
			// avButtonEditJobCard
			// 
			this.avButtonEditJobCard.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonEditJobCard.ActiveBackgroundImage = null;
			this.avButtonEditJobCard.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonEditJobCard.Enabled = false;
			this.avButtonEditJobCard.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.avButtonEditJobCard.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.avButtonEditJobCard.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.avButtonEditJobCard.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.avButtonEditJobCard.Icon = global::CAS.UI.Properties.Resources.EditIcon;
			this.avButtonEditJobCard.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonEditJobCard.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
			this.avButtonEditJobCard.Location = new System.Drawing.Point(839, 63);
			this.avButtonEditJobCard.Name = "avButtonEditJobCard";
			this.avButtonEditJobCard.NormalBackgroundImage = null;
			this.avButtonEditJobCard.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonEditJobCard.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonEditJobCard.ShowToolTip = true;
			this.avButtonEditJobCard.Size = new System.Drawing.Size(54, 54);
			this.avButtonEditJobCard.TabIndex = 10;
			this.avButtonEditJobCard.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditJobCard.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonEditJobCard.TextMain = "";
			this.avButtonEditJobCard.TextSecondary = "";
			this.avButtonEditJobCard.ToolTipText = "Edit Item";
			this.avButtonEditJobCard.Click += new System.EventHandler(this.AvButtonEditJobCardClick);
			this.avButtonEditJobCard.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(374, 6);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = SmartControls.General.DelimiterOrientation.Vertical;
			this.delimiter1.Size = new System.Drawing.Size(1, 102);
			this.delimiter1.Style = SmartControls.General.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 8;
			// 
			// labelCheckNaming
			// 
			this.labelCheckNaming.AutoSize = true;
			this.labelCheckNaming.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelCheckNaming.ForeColor = System.Drawing.Color.Black;
			this.labelCheckNaming.Location = new System.Drawing.Point(3, 6);
			this.labelCheckNaming.Name = "labelCheckNaming";
			this.labelCheckNaming.Size = new System.Drawing.Size(100, 16);
			this.labelCheckNaming.TabIndex = 15;
			this.labelCheckNaming.Text = "Check Naming";
			// 
			// comboBoxCheckNaming
			// 
			this.comboBoxCheckNaming.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxCheckNaming.FormattingEnabled = true;
			this.comboBoxCheckNaming.Items.AddRange(new object[] {
			"By Name",
			"By Ordinal №"});
			this.comboBoxCheckNaming.Location = new System.Drawing.Point(123, 3);
			this.comboBoxCheckNaming.Name = "comboBoxCheckNaming";
			this.comboBoxCheckNaming.Size = new System.Drawing.Size(129, 24);
			this.comboBoxCheckNaming.TabIndex = 1;
			this.comboBoxCheckNaming.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxSchedule
			// 
			this.comboBoxSchedule.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxSchedule.FormattingEnabled = true;
			this.comboBoxSchedule.Items.AddRange(new object[] {
			"OPS",
			"Store"});
			this.comboBoxSchedule.Location = new System.Drawing.Point(123, 33);
			this.comboBoxSchedule.Name = "comboBoxSchedule";
			this.comboBoxSchedule.Size = new System.Drawing.Size(129, 24);
			this.comboBoxSchedule.TabIndex = 2;
			this.comboBoxSchedule.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelProgram
			// 
			this.labelProgram.AutoSize = true;
			this.labelProgram.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.labelProgram.ForeColor = System.Drawing.Color.Black;
			this.labelProgram.Location = new System.Drawing.Point(3, 36);
			this.labelProgram.Name = "labelProgram";
			this.labelProgram.Size = new System.Drawing.Size(68, 16);
			this.labelProgram.TabIndex = 17;
			this.labelProgram.Text = "Schedule";
			// 
			// checkBoxSelectAll
			// 
			this.checkBoxSelectAll.AutoSize = true;
			this.checkBoxSelectAll.Checked = true;
			this.checkBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSelectAll.Location = new System.Drawing.Point(454, 7);
			this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxSelectAll.Name = "checkBoxSelectAll";
			this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 17);
			this.checkBoxSelectAll.TabIndex = 30;
			this.checkBoxSelectAll.Text = "Select all";
			this.checkBoxSelectAll.UseVisualStyleBackColor = true;
			this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(381, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 29;
			this.label1.Text = "Interval";
			// 
			// checkedListBoxItems
			// 
			this.checkedListBoxItems.CheckOnClick = true;
			this.checkedListBoxItems.FormattingEnabled = true;
			this.checkedListBoxItems.Location = new System.Drawing.Point(384, 28);
			this.checkedListBoxItems.Margin = new System.Windows.Forms.Padding(2);
			this.checkedListBoxItems.Name = "checkedListBoxItems";
			this.checkedListBoxItems.Size = new System.Drawing.Size(330, 94);
			this.checkedListBoxItems.TabIndex = 31;
			// 
			// listViewBindedTasks
			// 
			this.listViewBindedTasks.Displayer = null;
			this.listViewBindedTasks.DisplayerText = null;
			this.listViewBindedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewBindedTasks.Entity = null;
			this.listViewBindedTasks.Location = new System.Drawing.Point(0, 0);
			this.listViewBindedTasks.Margin = new System.Windows.Forms.Padding(4);
			this.listViewBindedTasks.Name = "listViewBindedTasks";
			this.listViewBindedTasks.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewBindedTasks.ShowGroups = true;
			this.listViewBindedTasks.Size = new System.Drawing.Size(572, 237);
			this.listViewBindedTasks.TabIndex = 2;
			this.listViewBindedTasks.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewBindedTasksSelectedItemsChanged);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerMain.Location = new System.Drawing.Point(384, 123);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.listViewBindedTasks);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.AutoScroll = true;
			this.splitContainerMain.Panel2.Controls.Add(this.listViewTasksForSelect);
			this.splitContainerMain.Size = new System.Drawing.Size(572, 454);
			this.splitContainerMain.SplitterDistance = 237;
			this.splitContainerMain.TabIndex = 27;
			// 
			// listViewTasksForSelect
			// 
			this.listViewTasksForSelect.Displayer = null;
			this.listViewTasksForSelect.DisplayerText = null;
			this.listViewTasksForSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewTasksForSelect.Entity = null;
			this.listViewTasksForSelect.Location = new System.Drawing.Point(0, 0);
			this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
			this.listViewTasksForSelect.Name = "listViewTasksForSelect";
			this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewTasksForSelect.ShowGroups = true;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(572, 213);
			this.listViewTasksForSelect.TabIndex = 1;
			this.listViewTasksForSelect.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewTasksForSelectSelectedItemsChanged);
			// 
			// buttonDelete
			// 
			this.buttonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonDelete.ActiveBackgroundImage = null;
			this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDelete.Enabled = false;
			this.buttonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.buttonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.buttonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.buttonDelete.Location = new System.Drawing.Point(779, 63);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.NormalBackgroundImage = null;
			this.buttonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDelete.ShowToolTip = true;
			this.buttonDelete.Size = new System.Drawing.Size(54, 54);
			this.buttonDelete.TabIndex = 32;
			this.buttonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.TextMain = "";
			this.buttonDelete.TextSecondary = "";
			this.buttonDelete.ToolTipText = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// MaintenanceGeneralDateControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.checkBoxSelectAll);
			this.Controls.Add(this.checkedListBoxItems);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelProgram);
			this.Controls.Add(this.comboBoxSchedule);
			this.Controls.Add(this.listViewMaintenanceChecks);
			this.Controls.Add(this.labelCheckNaming);
			this.Controls.Add(this.comboBoxCheckNaming);
			this.Controls.Add(this.avButtonAddJobCard);
			this.Controls.Add(this.avButtonAddCheck);
			this.Controls.Add(this.avButtonViewJobCard);
			this.Controls.Add(this.avButtonEditJobCard);
			this.Controls.Add(this.avButtonEditCheck);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.avButtonDeleteCheck);
			this.DoubleBuffered = true;
			this.Name = "MaintenanceGeneralDateControl";
			this.Size = new System.Drawing.Size(959, 580);
			this.contextMenuStripCheck.ResumeLayout(false);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listViewMaintenanceChecks;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderInterval;
		private System.Windows.Forms.ColumnHeader columnHeaderNotify;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripCheck;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private AvButtonT avButtonAddCheck;
		private AvButtonT avButtonEditCheck;
		private AvButtonT avButtonDeleteCheck;
		private System.Windows.Forms.ColumnHeader columnHeaderTitle;
		private System.Windows.Forms.ColumnHeader columnHeaderWorkArea;
		private System.Windows.Forms.ColumnHeader columnHeaderManHours;
		private System.Windows.Forms.ColumnHeader columnHeaderCost;
		private System.Windows.Forms.ColumnHeader columnHeaderRev;
		private System.Windows.Forms.ColumnHeader columnHeaderRemarks;
		private System.Windows.Forms.ColumnHeader columnHeaderKitRequired;
		private SmartControls.General.Delimiter delimiter1;
		private AvButtonT avButtonAddJobCard;
		private AvButtonT avButtonViewJobCard;
		private AvButtonT avButtonEditJobCard;
		private System.Windows.Forms.ColumnHeader Cost;
		private System.Windows.Forms.ColumnHeader ManHours;
		private System.Windows.Forms.ColumnHeader KitRequired;
		private System.Windows.Forms.Label labelCheckNaming;
		private System.Windows.Forms.ComboBox comboBoxCheckNaming;
		private System.Windows.Forms.ComboBox comboBoxSchedule;
		private System.Windows.Forms.Label labelProgram;
		private System.Windows.Forms.CheckBox checkBoxSelectAll;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckedListBox checkedListBoxItems;
		private MaintenanceCheckBindTaskListView listViewBindedTasks;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private MaintenanceCheckBindTaskListView listViewTasksForSelect;
		private AvButtonT buttonDelete;
	}
}
