using CAS.UI.UIControls.Auxiliary.DataGridViewElements;

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
			this.labelComponent = new System.Windows.Forms.Label();
			this.labelDate = new System.Windows.Forms.Label();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.labelMoveToAircraft = new System.Windows.Forms.Label();
			this.labelMoveToBaseDetail = new System.Windows.Forms.Label();
			this.comboBoxBaseComponent = new System.Windows.Forms.ComboBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxStore = new System.Windows.Forms.ComboBox();
			this.labelMoveToStore = new System.Windows.Forms.Label();
			this.radioButtonStore = new System.Windows.Forms.RadioButton();
			this.radioButtonAircraft = new System.Windows.Forms.RadioButton();
			this.labelMoveTo = new System.Windows.Forms.Label();
			this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelReason = new System.Windows.Forms.Label();
			this.comboBoxReason = new System.Windows.Forms.ComboBox();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewNumericUpDownColumn1 = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.dataGridViewNumericUpDownColumn2 = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.comboBoxRecived = new System.Windows.Forms.ComboBox();
			this.labelReceived = new System.Windows.Forms.Label();
			this.comboBoxReleased = new System.Windows.Forms.ComboBox();
			this.labelReleased = new System.Windows.Forms.Label();
			this.radioButtonSupplier = new System.Windows.Forms.RadioButton();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ReceiptDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.NotifylifelengthViewer = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.comboBoxStaff = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.radioButtonStaff = new System.Windows.Forms.RadioButton();
			this.comboBoxAircraft = new System.Windows.Forms.ComboBox();
			this.ColumnComponent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAll = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.ColumnReplace = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
			this.SuspendLayout();
			// 
			// labelComponent
			// 
			this.labelComponent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelComponent.ForeColor = System.Drawing.Color.DimGray;
			this.labelComponent.Location = new System.Drawing.Point(6, 63);
			this.labelComponent.Name = "labelComponent";
			this.labelComponent.Size = new System.Drawing.Size(150, 20);
			this.labelComponent.TabIndex = 0;
			this.labelComponent.Text = "Component";
			this.labelComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDate
			// 
			this.labelDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDate.ForeColor = System.Drawing.Color.DimGray;
			this.labelDate.Location = new System.Drawing.Point(6, 9);
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
			this.dateTimePickerDate.Location = new System.Drawing.Point(162, 9);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(610, 23);
			this.dateTimePickerDate.TabIndex = 4;
			this.dateTimePickerDate.ValueChanged += new System.EventHandler(this.DateTimePickerDateValueChanged);
			// 
			// labelMoveToAircraft
			// 
			this.labelMoveToAircraft.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMoveToAircraft.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToAircraft.Location = new System.Drawing.Point(6, 244);
			this.labelMoveToAircraft.Name = "labelMoveToAircraft";
			this.labelMoveToAircraft.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToAircraft.TabIndex = 5;
			this.labelMoveToAircraft.Text = "Choose Aircraft:";
			this.labelMoveToAircraft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMoveToBaseDetail
			// 
			this.labelMoveToBaseDetail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMoveToBaseDetail.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToBaseDetail.Location = new System.Drawing.Point(6, 274);
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
			this.comboBoxBaseComponent.Location = new System.Drawing.Point(162, 273);
			this.comboBoxBaseComponent.Name = "comboBoxBaseComponent";
			this.comboBoxBaseComponent.Size = new System.Drawing.Size(610, 24);
			this.comboBoxBaseComponent.TabIndex = 8;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.labelRemarks.Location = new System.Drawing.Point(438, 422);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(74, 20);
			this.labelRemarks.TabIndex = 11;
			this.labelRemarks.Text = "Remarks";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxRemarks.Location = new System.Drawing.Point(504, 422);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(270, 88);
			this.textBoxRemarks.TabIndex = 12;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(527, 617);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 13;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Location = new System.Drawing.Point(608, 617);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 14;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApplyClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonCancel.Location = new System.Drawing.Point(689, 617);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
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
			this.comboBoxStore.Location = new System.Drawing.Point(162, 213);
			this.comboBoxStore.Name = "comboBoxStore";
			this.comboBoxStore.Size = new System.Drawing.Size(610, 24);
			this.comboBoxStore.TabIndex = 20;
	        this.comboBoxAircraft.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAircraftSelectedIndexChanged);
			// 
			// labelMoveToStore
			// 
			this.labelMoveToStore.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMoveToStore.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToStore.Location = new System.Drawing.Point(6, 217);
			this.labelMoveToStore.Name = "labelMoveToStore";
			this.labelMoveToStore.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToStore.TabIndex = 19;
			this.labelMoveToStore.Text = "Choose Store:";
			this.labelMoveToStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonStore
			// 
			this.radioButtonStore.AutoSize = true;
			this.radioButtonStore.Location = new System.Drawing.Point(285, 178);
			this.radioButtonStore.Name = "radioButtonStore";
			this.radioButtonStore.Size = new System.Drawing.Size(50, 17);
			this.radioButtonStore.TabIndex = 21;
			this.radioButtonStore.Text = "Store";
			this.radioButtonStore.UseVisualStyleBackColor = true;
			this.radioButtonStore.CheckedChanged += new System.EventHandler(this.RadioButtonStoreCheckedChanged);
			// 
			// radioButtonAircraft
			// 
			this.radioButtonAircraft.AutoSize = true;
			this.radioButtonAircraft.Location = new System.Drawing.Point(341, 178);
			this.radioButtonAircraft.Name = "radioButtonAircraft";
			this.radioButtonAircraft.Size = new System.Drawing.Size(58, 17);
			this.radioButtonAircraft.TabIndex = 22;
			this.radioButtonAircraft.Text = "Aircraft";
			this.radioButtonAircraft.UseVisualStyleBackColor = true;
			this.radioButtonAircraft.CheckedChanged += new System.EventHandler(this.radioButtonAircraft_CheckedChanged);
			// 
			// labelMoveTo
			// 
			this.labelMoveTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMoveTo.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveTo.Location = new System.Drawing.Point(89, 175);
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
			this.dataGridViewComponents.Location = new System.Drawing.Point(162, 55);
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
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Enabled = false;
			this.radioButton1.Location = new System.Drawing.Point(405, 178);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(79, 17);
			this.radioButton1.TabIndex = 25;
			this.radioButton1.Text = "Work Shop";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Enabled = false;
			this.radioButton2.Location = new System.Drawing.Point(490, 178);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(60, 17);
			this.radioButton2.TabIndex = 26;
			this.radioButton2.Text = "Hangar";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Enabled = false;
			this.radioButton3.Location = new System.Drawing.Point(556, 178);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(60, 17);
			this.radioButton3.TabIndex = 27;
			this.radioButton3.Text = "Vehicle";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxDescription.Location = new System.Drawing.Point(162, 421);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(270, 88);
			this.textBoxDescription.TabIndex = 29;
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.DimGray;
			this.labelDescription.Location = new System.Drawing.Point(6, 422);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(150, 20);
			this.labelDescription.TabIndex = 28;
			this.labelDescription.Text = "Description";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelReason
			// 
			this.labelReason.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelReason.ForeColor = System.Drawing.Color.DimGray;
			this.labelReason.Location = new System.Drawing.Point(6, 392);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(71, 20);
			this.labelReason.TabIndex = 30;
			this.labelReason.Text = "Reason:";
			this.labelReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxReason
			// 
			this.comboBoxReason.FormattingEnabled = true;
			this.comboBoxReason.Location = new System.Drawing.Point(162, 394);
			this.comboBoxReason.Name = "comboBoxReason";
			this.comboBoxReason.Size = new System.Drawing.Size(610, 21);
			this.comboBoxReason.TabIndex = 31;
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
			this.delimiter2.Location = new System.Drawing.Point(9, 47);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter2.Size = new System.Drawing.Size(770, 2);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Solid;
			this.delimiter2.TabIndex = 18;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(10, 170);
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
			this.fileControl.Location = new System.Drawing.Point(162, 544);
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
			this.comboBoxRecived.Location = new System.Drawing.Point(504, 515);
			this.comboBoxRecived.Name = "comboBoxRecived";
			this.comboBoxRecived.Size = new System.Drawing.Size(270, 21);
			this.comboBoxRecived.TabIndex = 33;
			// 
			// labelReceived
			// 
			this.labelReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelReceived.ForeColor = System.Drawing.Color.DimGray;
			this.labelReceived.Location = new System.Drawing.Point(438, 513);
			this.labelReceived.Name = "labelReceived";
			this.labelReceived.Size = new System.Drawing.Size(73, 20);
			this.labelReceived.TabIndex = 32;
			this.labelReceived.Text = "Received";
			this.labelReceived.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxReleased
			// 
			this.comboBoxReleased.FormattingEnabled = true;
			this.comboBoxReleased.Location = new System.Drawing.Point(161, 514);
			this.comboBoxReleased.Name = "comboBoxReleased";
			this.comboBoxReleased.Size = new System.Drawing.Size(271, 21);
			this.comboBoxReleased.TabIndex = 35;
			// 
			// labelReleased
			// 
			this.labelReleased.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelReleased.ForeColor = System.Drawing.Color.DimGray;
			this.labelReleased.Location = new System.Drawing.Point(6, 516);
			this.labelReleased.Name = "labelReleased";
			this.labelReleased.Size = new System.Drawing.Size(74, 20);
			this.labelReleased.TabIndex = 34;
			this.labelReleased.Text = "Released";
			this.labelReleased.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonSupplier
			// 
			this.radioButtonSupplier.AutoSize = true;
			this.radioButtonSupplier.Location = new System.Drawing.Point(163, 178);
			this.radioButtonSupplier.Name = "radioButtonSupplier";
			this.radioButtonSupplier.Size = new System.Drawing.Size(63, 17);
			this.radioButtonSupplier.TabIndex = 36;
			this.radioButtonSupplier.Text = "Supplier";
			this.radioButtonSupplier.UseVisualStyleBackColor = true;
			this.radioButtonSupplier.CheckedChanged += new System.EventHandler(this.radioButtonSupplier_CheckedChanged);
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxSupplier.FormattingEnabled = true;
			this.comboBoxSupplier.Location = new System.Drawing.Point(163, 303);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(609, 24);
			this.comboBoxSupplier.TabIndex = 38;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.DimGray;
			this.label1.Location = new System.Drawing.Point(7, 304);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 20);
			this.label1.TabIndex = 37;
			this.label1.Text = "Choose Supplier:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.DimGray;
			this.label2.Location = new System.Drawing.Point(7, 365);
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
			this.ReceiptDatedateTimePicker.Location = new System.Drawing.Point(162, 365);
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
			this.NotifylifelengthViewer.Location = new System.Drawing.Point(549, 356);
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
			this.comboBoxStaff.Location = new System.Drawing.Point(163, 333);
			this.comboBoxStaff.Name = "comboBoxStaff";
			this.comboBoxStaff.Size = new System.Drawing.Size(609, 24);
			this.comboBoxStaff.TabIndex = 44;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(7, 334);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 21);
			this.label3.TabIndex = 43;
			this.label3.Text = "Choose Employer:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButtonStaff
			// 
			this.radioButtonStaff.AutoSize = true;
			this.radioButtonStaff.Location = new System.Drawing.Point(232, 178);
			this.radioButtonStaff.Name = "radioButtonStaff";
			this.radioButtonStaff.Size = new System.Drawing.Size(47, 17);
			this.radioButtonStaff.TabIndex = 45;
			this.radioButtonStaff.Text = "Staff";
			this.radioButtonStaff.UseVisualStyleBackColor = true;
			this.radioButtonStaff.CheckedChanged += new System.EventHandler(this.radioButtonStaff_CheckedChanged);
			// 
			// comboBoxAircraft
			// 
			this.comboBoxAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxAircraft.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxAircraft.ForeColor = System.Drawing.Color.DimGray;
			this.comboBoxAircraft.FormattingEnabled = true;
			this.comboBoxAircraft.Location = new System.Drawing.Point(161, 243);
			this.comboBoxAircraft.Name = "comboBoxAircraft";
			this.comboBoxAircraft.Size = new System.Drawing.Size(610, 24);
			this.comboBoxAircraft.TabIndex = 46;
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
			// MoveComponentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.ClientSize = new System.Drawing.Size(784, 648);
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
			this.MaximumSize = new System.Drawing.Size(800, 690);
			this.MinimumSize = new System.Drawing.Size(800, 690);
			this.Name = "MoveComponentForm";
			this.ShowIcon = false;
			this.Text = "MoveDetailForm";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.Label labelMoveToAircraft;
        private System.Windows.Forms.Label labelMoveToBaseDetail;
        private System.Windows.Forms.ComboBox comboBoxBaseComponent;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter2;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Label labelMoveToStore;
        private System.Windows.Forms.RadioButton radioButtonStore;
        private System.Windows.Forms.RadioButton radioButtonAircraft;
        private System.Windows.Forms.Label labelMoveTo;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelReason;
		private System.Windows.Forms.ComboBox comboBoxReason;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
		private System.Windows.Forms.ComboBox comboBoxRecived;
		private System.Windows.Forms.Label labelReceived;
		private System.Windows.Forms.ComboBox comboBoxReleased;
		private System.Windows.Forms.Label labelReleased;
		private System.Windows.Forms.RadioButton radioButtonSupplier;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker ReceiptDatedateTimePicker;
		private Auxiliary.LifelengthViewer NotifylifelengthViewer;
		private System.Windows.Forms.ComboBox comboBoxStaff;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radioButtonStaff;
		private System.Windows.Forms.ComboBox comboBoxAircraft;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnComponent;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
		private DataGridViewNumericUpDownColumn ColumnAll;
		private DataGridViewNumericUpDownColumn ColumnReplace;
	}
}