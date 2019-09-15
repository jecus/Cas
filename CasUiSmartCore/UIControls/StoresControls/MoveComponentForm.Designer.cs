using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.StoresControls
{
	partial class MoveComponentForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveComponentForm));
			this.labelComponent = new MetroFramework.Controls.MetroLabel();
			this.labelDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.labelMoveToAircraft = new MetroFramework.Controls.MetroLabel();
			this.labelMoveToBaseDetail = new MetroFramework.Controls.MetroLabel();
			this.comboBoxBaseComponent = new System.Windows.Forms.ComboBox();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxStore = new System.Windows.Forms.ComboBox();
			this.labelMoveToStore = new MetroFramework.Controls.MetroLabel();
			this.radioButtonStore = new MetroFramework.Controls.MetroRadioButton();
			this.radioButtonAircraft = new MetroFramework.Controls.MetroRadioButton();
			this.labelMoveTo = new MetroFramework.Controls.MetroLabel();
			this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
			this.ColumnComponent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAll = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.ColumnReplace = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.radioButton1 = new MetroFramework.Controls.MetroRadioButton();
			this.radioButton2 = new MetroFramework.Controls.MetroRadioButton();
			this.radioButton3 = new MetroFramework.Controls.MetroRadioButton();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.labelReason = new MetroFramework.Controls.MetroLabel();
			this.comboBoxReason = new System.Windows.Forms.ComboBox();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewNumericUpDownColumn1 = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.dataGridViewNumericUpDownColumn2 = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.comboBoxRecived = new System.Windows.Forms.ComboBox();
			this.labelReceived = new MetroFramework.Controls.MetroLabel();
			this.comboBoxReleased = new System.Windows.Forms.ComboBox();
			this.labelReleased = new MetroFramework.Controls.MetroLabel();
			this.radioButtonSupplier = new MetroFramework.Controls.MetroRadioButton();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.label2 = new MetroFramework.Controls.MetroLabel();
			this.ReceiptDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.NotifylifelengthViewer = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.comboBoxStaff = new System.Windows.Forms.ComboBox();
			this.label3 = new MetroFramework.Controls.MetroLabel();
			this.radioButtonStaff = new MetroFramework.Controls.MetroRadioButton();
			this.comboBoxAircraft = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
			this.SuspendLayout();
			// 
			// labelComponent
			// 
			this.labelComponent.ForeColor = System.Drawing.Color.DimGray;
			this.labelComponent.Location = new System.Drawing.Point(17, 109);
			this.labelComponent.Name = "labelComponent";
			this.labelComponent.Size = new System.Drawing.Size(150, 20);
			this.labelComponent.TabIndex = 0;
			this.labelComponent.Text = "Component";
			this.labelComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDate
			// 
			this.labelDate.ForeColor = System.Drawing.Color.DimGray;
			this.labelDate.Location = new System.Drawing.Point(17, 63);
			this.labelDate.Name = "labelDate";
			this.labelDate.Size = new System.Drawing.Size(150, 20);
			this.labelDate.TabIndex = 3;
			this.labelDate.Text = "Date:";
			this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerDate
			// 
			this.dateTimePickerDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePickerDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDate.Location = new System.Drawing.Point(172, 63);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(610, 23);
			this.dateTimePickerDate.TabIndex = 4;
			this.dateTimePickerDate.ValueChanged += new System.EventHandler(this.DateTimePickerDateValueChanged);
			// 
			// labelMoveToAircraft
			// 
			this.labelMoveToAircraft.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToAircraft.Location = new System.Drawing.Point(17, 297);
			this.labelMoveToAircraft.Name = "labelMoveToAircraft";
			this.labelMoveToAircraft.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToAircraft.TabIndex = 5;
			this.labelMoveToAircraft.Text = "Choose Aircraft:";
			this.labelMoveToAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMoveToBaseDetail
			// 
			this.labelMoveToBaseDetail.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToBaseDetail.Location = new System.Drawing.Point(17, 327);
			this.labelMoveToBaseDetail.Name = "labelMoveToBaseDetail";
			this.labelMoveToBaseDetail.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToBaseDetail.TabIndex = 7;
			this.labelMoveToBaseDetail.Text = "Choose Base Detail:";
			this.labelMoveToBaseDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxBaseComponent
			// 
			this.comboBoxBaseComponent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxBaseComponent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxBaseComponent.FormattingEnabled = true;
			this.comboBoxBaseComponent.Location = new System.Drawing.Point(172, 327);
			this.comboBoxBaseComponent.Name = "comboBoxBaseComponent";
			this.comboBoxBaseComponent.Size = new System.Drawing.Size(610, 24);
			this.comboBoxBaseComponent.TabIndex = 8;
			this.comboBoxBaseComponent.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelRemarks
			// 
			this.labelRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.labelRemarks.Location = new System.Drawing.Point(447, 476);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(61, 20);
			this.labelRemarks.TabIndex = 11;
			this.labelRemarks.Text = "Remarks";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(183, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(83, 83);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(514, 476);
			this.textBoxRemarks.MaxLength = 32767;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(269, 88);
			this.textBoxRemarks.TabIndex = 12;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(546, 643);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 13;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonApply.Location = new System.Drawing.Point(627, 643);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 33);
			this.buttonApply.TabIndex = 14;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(708, 643);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 15;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// comboBoxStore
			// 
			this.comboBoxStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStore.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxStore.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxStore.FormattingEnabled = true;
			this.comboBoxStore.Location = new System.Drawing.Point(172, 267);
			this.comboBoxStore.Name = "comboBoxStore";
			this.comboBoxStore.Size = new System.Drawing.Size(610, 24);
			this.comboBoxStore.TabIndex = 20;
			this.comboBoxStore.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMoveToStore
			// 
			this.labelMoveToStore.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToStore.Location = new System.Drawing.Point(17, 267);
			this.labelMoveToStore.Name = "labelMoveToStore";
			this.labelMoveToStore.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToStore.TabIndex = 19;
			this.labelMoveToStore.Text = "Choose Store:";
			this.labelMoveToStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonStore
			// 
			this.radioButtonStore.AutoSize = true;
			this.radioButtonStore.Location = new System.Drawing.Point(295, 232);
			this.radioButtonStore.Name = "radioButtonStore";
			this.radioButtonStore.Size = new System.Drawing.Size(50, 15);
			this.radioButtonStore.TabIndex = 21;
			this.radioButtonStore.Text = "Store";
			this.radioButtonStore.UseSelectable = true;
			this.radioButtonStore.CheckedChanged += new System.EventHandler(this.RadioButtonStoreCheckedChanged);
			// 
			// radioButtonAircraft
			// 
			this.radioButtonAircraft.AutoSize = true;
			this.radioButtonAircraft.Location = new System.Drawing.Point(351, 232);
			this.radioButtonAircraft.Name = "radioButtonAircraft";
			this.radioButtonAircraft.Size = new System.Drawing.Size(62, 15);
			this.radioButtonAircraft.TabIndex = 22;
			this.radioButtonAircraft.Text = "Aircraft";
			this.radioButtonAircraft.UseSelectable = true;
			this.radioButtonAircraft.CheckedChanged += new System.EventHandler(this.radioButtonAircraft_CheckedChanged);
			// 
			// labelMoveTo
			// 
			this.labelMoveTo.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveTo.Location = new System.Drawing.Point(99, 227);
			this.labelMoveTo.Name = "labelMoveTo";
			this.labelMoveTo.Size = new System.Drawing.Size(68, 20);
			this.labelMoveTo.TabIndex = 23;
			this.labelMoveTo.Text = "Move to:";
			this.labelMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dataGridViewComponents
			// 
			this.dataGridViewComponents.AllowUserToAddRows = false;
			this.dataGridViewComponents.AllowUserToDeleteRows = false;
			this.dataGridViewComponents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewComponents.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ColumnComponent,
			this.ColumnDescription,
			this.ColumnAll,
			this.ColumnReplace});
			this.dataGridViewComponents.Location = new System.Drawing.Point(172, 109);
			this.dataGridViewComponents.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewComponents.Name = "dataGridViewComponents";
			this.dataGridViewComponents.RowHeadersVisible = false;
			this.dataGridViewComponents.RowHeadersWidth = 4;
			this.dataGridViewComponents.RowTemplate.Height = 24;
			this.dataGridViewComponents.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridViewComponents.Size = new System.Drawing.Size(610, 110);
			this.dataGridViewComponents.TabIndex = 24;
			// 
			// ColumnComponent
			// 
			this.ColumnComponent.FalseValue = "True";
			this.ColumnComponent.HeaderText = "";
			this.ColumnComponent.Name = "ColumnComponent";
			this.ColumnComponent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnComponent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnComponent.Width = 25;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.HeaderText = "Component";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.Width = 460;
			// 
			// ColumnAll
			// 
			this.ColumnAll.HeaderText = "All";
			this.ColumnAll.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.ColumnAll.Name = "ColumnAll";
			this.ColumnAll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnAll.ThousandsSeparator = true;
			this.ColumnAll.Width = 60;
			// 
			// ColumnReplace
			// 
			this.ColumnReplace.HeaderText = "Replace";
			this.ColumnReplace.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.ColumnReplace.Name = "ColumnReplace";
			this.ColumnReplace.ThousandsSeparator = true;
			this.ColumnReplace.Width = 60;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Enabled = false;
			this.radioButton1.Location = new System.Drawing.Point(415, 232);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(81, 15);
			this.radioButton1.TabIndex = 25;
			this.radioButton1.Text = "Work Shop";
			this.radioButton1.UseSelectable = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Enabled = false;
			this.radioButton2.Location = new System.Drawing.Point(500, 232);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(62, 15);
			this.radioButton2.TabIndex = 26;
			this.radioButton2.Text = "Hangar";
			this.radioButton2.UseSelectable = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Enabled = false;
			this.radioButton3.Location = new System.Drawing.Point(566, 232);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(60, 15);
			this.radioButton3.TabIndex = 27;
			this.radioButton3.Text = "Vehicle";
			this.radioButton3.UseSelectable = true;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(185, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(83, 83);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(172, 475);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(271, 88);
			this.textBoxDescription.TabIndex = 29;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelDescription
			// 
			this.labelDescription.ForeColor = System.Drawing.Color.DimGray;
			this.labelDescription.Location = new System.Drawing.Point(17, 475);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(150, 20);
			this.labelDescription.TabIndex = 28;
			this.labelDescription.Text = "Description";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReason
			// 
			this.labelReason.ForeColor = System.Drawing.Color.DimGray;
			this.labelReason.Location = new System.Drawing.Point(17, 448);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(71, 20);
			this.labelReason.TabIndex = 30;
			this.labelReason.Text = "Reason:";
			this.labelReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxReason
			// 
			this.comboBoxReason.FormattingEnabled = true;
			this.comboBoxReason.Location = new System.Drawing.Point(172, 448);
			this.comboBoxReason.Name = "comboBoxReason";
			this.comboBoxReason.Size = new System.Drawing.Size(610, 21);
			this.comboBoxReason.TabIndex = 31;
			this.comboBoxReason.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Component";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 230;
			// 
			// dataGridViewNumericUpDownColumn1
			// 
			this.dataGridViewNumericUpDownColumn1.HeaderText = "All";
			this.dataGridViewNumericUpDownColumn1.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.dataGridViewNumericUpDownColumn1.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
			this.dataGridViewNumericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewNumericUpDownColumn1.ThousandsSeparator = true;
			this.dataGridViewNumericUpDownColumn1.Width = 60;
			// 
			// dataGridViewNumericUpDownColumn2
			// 
			this.dataGridViewNumericUpDownColumn2.HeaderText = "Replace";
			this.dataGridViewNumericUpDownColumn2.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.dataGridViewNumericUpDownColumn2.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.dataGridViewNumericUpDownColumn2.Name = "dataGridViewNumericUpDownColumn2";
			this.dataGridViewNumericUpDownColumn2.ThousandsSeparator = true;
			this.dataGridViewNumericUpDownColumn2.Width = 60;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(19, 101);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter2.Size = new System.Drawing.Size(770, 2);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
			this.delimiter2.TabIndex = 18;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(20, 224);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(770, 2);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
			this.delimiter1.TabIndex = 17;
			// 
			// fileControl
			// 
			this.fileControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.fileControl.AutoSize = true;
			this.fileControl.BackColor = System.Drawing.Color.Transparent;
			this.fileControl.Description1 = "This record does not contain a file proving the tranfering of the component. Encl" +
	"ose PDF file to prove the transfer of the component.";
			this.fileControl.Description2 = "Attached file proves the transfer of the component.";
			this.fileControl.Filter = "Adobe PDF Files|*.pdf";
			this.fileControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.fileControl.ForeColor = System.Drawing.Color.DimGray;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = null;
			this.fileControl.Location = new System.Drawing.Point(172, 598);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 52);
			this.fileControl.TabIndex = 16;
			// 
			// comboBoxRecived
			// 
			this.comboBoxRecived.FormattingEnabled = true;
			this.comboBoxRecived.Location = new System.Drawing.Point(514, 569);
			this.comboBoxRecived.Name = "comboBoxRecived";
			this.comboBoxRecived.Size = new System.Drawing.Size(268, 21);
			this.comboBoxRecived.TabIndex = 33;
			this.comboBoxRecived.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelReceived
			// 
			this.labelReceived.ForeColor = System.Drawing.Color.DimGray;
			this.labelReceived.Location = new System.Drawing.Point(447, 569);
			this.labelReceived.Name = "labelReceived";
			this.labelReceived.Size = new System.Drawing.Size(74, 20);
			this.labelReceived.TabIndex = 32;
			this.labelReceived.Text = "Received";
			this.labelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxReleased
			// 
			this.comboBoxReleased.FormattingEnabled = true;
			this.comboBoxReleased.Location = new System.Drawing.Point(172, 568);
			this.comboBoxReleased.Name = "comboBoxReleased";
			this.comboBoxReleased.Size = new System.Drawing.Size(270, 21);
			this.comboBoxReleased.TabIndex = 35;
			this.comboBoxReleased.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelReleased
			// 
			this.labelReleased.ForeColor = System.Drawing.Color.DimGray;
			this.labelReleased.Location = new System.Drawing.Point(17, 567);
			this.labelReleased.Name = "labelReleased";
			this.labelReleased.Size = new System.Drawing.Size(74, 20);
			this.labelReleased.TabIndex = 34;
			this.labelReleased.Text = "Released";
			this.labelReleased.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonSupplier
			// 
			this.radioButtonSupplier.AutoSize = true;
			this.radioButtonSupplier.Location = new System.Drawing.Point(173, 232);
			this.radioButtonSupplier.Name = "radioButtonSupplier";
			this.radioButtonSupplier.Size = new System.Drawing.Size(66, 15);
			this.radioButtonSupplier.TabIndex = 36;
			this.radioButtonSupplier.Text = "Supplier";
			this.radioButtonSupplier.UseSelectable = true;
			this.radioButtonSupplier.CheckedChanged += new System.EventHandler(this.radioButtonSupplier_CheckedChanged);
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(172, 357);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(610, 24);
			this.comboBoxSupplier.TabIndex = 38;
			this.comboBoxSupplier.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(17, 357);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 20);
			this.label1.TabIndex = 37;
			this.label1.Text = "Choose Supplier:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(17, 419);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(130, 20);
			this.label2.TabIndex = 39;
			this.label2.Text = "Receipt Date:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReceiptDatedateTimePicker
			// 
			this.ReceiptDatedateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ReceiptDatedateTimePicker.CalendarForeColor = System.Drawing.Color.DimGray;
			this.ReceiptDatedateTimePicker.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ReceiptDatedateTimePicker.Location = new System.Drawing.Point(172, 419);
			this.ReceiptDatedateTimePicker.Name = "ReceiptDatedateTimePicker";
			this.ReceiptDatedateTimePicker.Size = new System.Drawing.Size(368, 23);
			this.ReceiptDatedateTimePicker.TabIndex = 41;
			// 
			// NotifylifelengthViewer
			// 
			this.NotifylifelengthViewer.AutoSize = true;
			this.NotifylifelengthViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.NotifylifelengthViewer.CalendarApplicable = false;
			this.NotifylifelengthViewer.CyclesApplicable = false;
			this.NotifylifelengthViewer.EnabledCalendar = true;
			this.NotifylifelengthViewer.EnabledCycle = true;
			this.NotifylifelengthViewer.EnabledHours = true;
			this.NotifylifelengthViewer.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.NotifylifelengthViewer.ForeColor = System.Drawing.Color.DimGray;
			this.NotifylifelengthViewer.HeaderCalendar = "Calendar";
			this.NotifylifelengthViewer.HeaderCycles = "Cycles";
			this.NotifylifelengthViewer.HeaderFormattedCalendar = "Calendar";
			this.NotifylifelengthViewer.HeaderHours = "Hours";
			this.NotifylifelengthViewer.HoursApplicable = false;
			this.NotifylifelengthViewer.LeftHeader = "Notify";
			this.NotifylifelengthViewer.Location = new System.Drawing.Point(557, 412);
			this.NotifylifelengthViewer.Margin = new System.Windows.Forms.Padding(2);
			this.NotifylifelengthViewer.Modified = false;
			this.NotifylifelengthViewer.Name = "NotifylifelengthViewer";
			this.NotifylifelengthViewer.ReadOnly = false;
			this.NotifylifelengthViewer.ShowCalendar = true;
			this.NotifylifelengthViewer.ShowCalendarOnly = true;
			this.NotifylifelengthViewer.ShowFormattedCalendar = false;
			this.NotifylifelengthViewer.ShowHeaders = false;
			this.NotifylifelengthViewer.ShowMinutes = false;
			this.NotifylifelengthViewer.Size = new System.Drawing.Size(225, 35);
			this.NotifylifelengthViewer.SystemCalculated = true;
			this.NotifylifelengthViewer.TabIndex = 42;
			// 
			// comboBoxStaff
			// 
			this.comboBoxStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxStaff.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxStaff.FormattingEnabled = true;
			this.comboBoxStaff.Location = new System.Drawing.Point(172, 387);
			this.comboBoxStaff.Name = "comboBoxStaff";
			this.comboBoxStaff.Size = new System.Drawing.Size(610, 24);
			this.comboBoxStaff.TabIndex = 44;
			this.comboBoxStaff.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(17, 387);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 21);
			this.label3.TabIndex = 43;
			this.label3.Text = "Choose Employer:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonStaff
			// 
			this.radioButtonStaff.AutoSize = true;
			this.radioButtonStaff.Location = new System.Drawing.Point(242, 232);
			this.radioButtonStaff.Name = "radioButtonStaff";
			this.radioButtonStaff.Size = new System.Drawing.Size(47, 15);
			this.radioButtonStaff.TabIndex = 45;
			this.radioButtonStaff.Text = "Staff";
			this.radioButtonStaff.UseSelectable = true;
			this.radioButtonStaff.CheckedChanged += new System.EventHandler(this.radioButtonStaff_CheckedChanged);
			// 
			// comboBoxAircraft
			// 
			this.comboBoxAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxAircraft.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxAircraft.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircraft.FormattingEnabled = true;
			this.comboBoxAircraft.Location = new System.Drawing.Point(172, 297);
			this.comboBoxAircraft.Name = "comboBoxAircraft";
			this.comboBoxAircraft.Size = new System.Drawing.Size(610, 24);
			this.comboBoxAircraft.TabIndex = 46;
			this.comboBoxAircraft.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAircraftSelectedIndexChanged);
			this.comboBoxAircraft.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// MoveComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 690);
			this.Controls.Add(this.comboBoxAircraft);
			this.Controls.Add(this.radioButtonStaff);
			this.Controls.Add(this.comboBoxStaff);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.NotifylifelengthViewer);
			this.Controls.Add(this.ReceiptDatedateTimePicker);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBoxSupplier);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioButtonSupplier);
			this.Controls.Add(this.comboBoxReleased);
			this.Controls.Add(this.labelReleased);
			this.Controls.Add(this.comboBoxRecived);
			this.Controls.Add(this.labelReceived);
			this.Controls.Add(this.comboBoxReason);
			this.Controls.Add(this.labelReason);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.dataGridViewComponents);
			this.Controls.Add(this.labelMoveTo);
			this.Controls.Add(this.radioButtonAircraft);
			this.Controls.Add(this.radioButtonStore);
			this.Controls.Add(this.comboBoxStore);
			this.Controls.Add(this.labelMoveToStore);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.comboBoxBaseComponent);
			this.Controls.Add(this.labelMoveToBaseDetail);
			this.Controls.Add(this.labelMoveToAircraft);
			this.Controls.Add(this.dateTimePickerDate);
			this.Controls.Add(this.labelDate);
			this.Controls.Add(this.labelComponent);
			this.MaximumSize = new System.Drawing.Size(800, 720);
			this.MinimumSize = new System.Drawing.Size(800, 690);
			this.Name = "MoveComponentForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Move Detail Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroLabel labelComponent;
		private MetroLabel labelDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private MetroLabel labelMoveToAircraft;
		private MetroLabel labelMoveToBaseDetail;
		private System.Windows.Forms.ComboBox comboBoxBaseComponent;
		private MetroLabel labelRemarks;
		private MetroTextBox textBoxRemarks;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter2;
		private System.Windows.Forms.ComboBox comboBoxStore;
		private MetroLabel labelMoveToStore;
		private MetroRadioButton radioButtonStore;
		private MetroRadioButton radioButtonAircraft;
		private MetroLabel labelMoveTo;
		private System.Windows.Forms.DataGridView dataGridViewComponents;
		private MetroRadioButton radioButton1;
		private MetroRadioButton radioButton2;
		private MetroRadioButton radioButton3;
		private MetroTextBox textBoxDescription;
		private MetroLabel labelDescription;
		private MetroLabel labelReason;
		private System.Windows.Forms.ComboBox comboBoxReason;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
		private System.Windows.Forms.ComboBox comboBoxRecived;
		private MetroLabel labelReceived;
		private System.Windows.Forms.ComboBox comboBoxReleased;
		private MetroLabel labelReleased;
		private MetroRadioButton radioButtonSupplier;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private MetroLabel label1;
		private MetroLabel label2;
		private System.Windows.Forms.DateTimePicker ReceiptDatedateTimePicker;
		private Auxiliary.LifelengthViewer NotifylifelengthViewer;
		private System.Windows.Forms.ComboBox comboBoxStaff;
		private MetroLabel label3;
		private MetroRadioButton radioButtonStaff;
		private System.Windows.Forms.ComboBox comboBoxAircraft;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnComponent;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
		private DataGridViewNumericUpDownColumn ColumnAll;
		private DataGridViewNumericUpDownColumn ColumnReplace;
	}
}