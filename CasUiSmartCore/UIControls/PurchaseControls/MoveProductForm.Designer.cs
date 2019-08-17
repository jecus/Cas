using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.PurchaseControls
{
	partial class MoveProductForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveProductForm));
			this.labelComponent = new MetroFramework.Controls.MetroLabel();
			this.labelDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBoxStore = new System.Windows.Forms.ComboBox();
			this.labelMoveToStore = new MetroFramework.Controls.MetroLabel();
			this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
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
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAll = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.ColumnReplace = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
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
			this.buttonOK.Location = new System.Drawing.Point(627, 643);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 13;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
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
			this.comboBoxStore.Location = new System.Drawing.Point(173, 445);
			this.comboBoxStore.Name = "comboBoxStore";
			this.comboBoxStore.Size = new System.Drawing.Size(610, 24);
			this.comboBoxStore.TabIndex = 20;
			// 
			// labelMoveToStore
			// 
			this.labelMoveToStore.ForeColor = System.Drawing.Color.DimGray;
			this.labelMoveToStore.Location = new System.Drawing.Point(18, 445);
			this.labelMoveToStore.Name = "labelMoveToStore";
			this.labelMoveToStore.Size = new System.Drawing.Size(150, 20);
			this.labelMoveToStore.TabIndex = 19;
			this.labelMoveToStore.Text = "Choose Store:";
			this.labelMoveToStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.dataGridViewComponents.Size = new System.Drawing.Size(610, 323);
			this.dataGridViewComponents.TabIndex = 24;
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
			this.delimiter1.Location = new System.Drawing.Point(19, 437);
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
			// MoveProductForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 690);
			this.Controls.Add(this.comboBoxReleased);
			this.Controls.Add(this.labelReleased);
			this.Controls.Add(this.comboBoxRecived);
			this.Controls.Add(this.labelReceived);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.dataGridViewComponents);
			this.Controls.Add(this.comboBoxStore);
			this.Controls.Add(this.labelMoveToStore);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.dateTimePickerDate);
			this.Controls.Add(this.labelDate);
			this.Controls.Add(this.labelComponent);
			this.MaximumSize = new System.Drawing.Size(800, 720);
			this.MinimumSize = new System.Drawing.Size(800, 690);
			this.Name = "MoveProductForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Move Store Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroLabel labelComponent;
		private MetroLabel labelDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private MetroLabel labelRemarks;
		private MetroTextBox textBoxRemarks;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
		private CAS.UI.UIControls.Auxiliary.Delimiter delimiter2;
		private System.Windows.Forms.ComboBox comboBoxStore;
		private MetroLabel labelMoveToStore;
		private System.Windows.Forms.DataGridView dataGridViewComponents;
		private MetroTextBox textBoxDescription;
		private MetroLabel labelDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
		private DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
		private System.Windows.Forms.ComboBox comboBoxRecived;
		private MetroLabel labelReceived;
		private System.Windows.Forms.ComboBox comboBoxReleased;
		private MetroLabel labelReleased;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
		private DataGridViewNumericUpDownColumn ColumnAll;
		private DataGridViewNumericUpDownColumn ColumnReplace;
	}
}