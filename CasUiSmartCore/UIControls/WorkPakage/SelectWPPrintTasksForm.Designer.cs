using MetroFramework.Controls;

namespace CAS.UI.UIControls.WorkPakage
{
    partial class SelectWPPrintTasksForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectWPPrintTasksForm));
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnPrintInWP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnQty = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.buttonOK = new System.Windows.Forms.Button();
			this.checkBoxPrintDupliates = new MetroFramework.Controls.MetroCheckBox();
			this.checkBoxPrintIncoming = new MetroFramework.Controls.MetroCheckBox();
			this.textBoxNumber = new MetroFramework.Controls.MetroTextBox();
			this.labelJONumber = new MetroFramework.Controls.MetroLabel();
			this.comboBoxRoutingTaskGrouping = new System.Windows.Forms.ComboBox();
			this.labelRtGrouping = new MetroFramework.Controls.MetroLabel();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTaskCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewItems
			// 
			this.dataGridViewItems.AllowUserToAddRows = false;
			this.dataGridViewItems.AllowUserToDeleteRows = false;
			this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDescription,
            this.ColumnTaskCard,
            this.ColumnPrintInWP,
            this.ColumnQty});
			this.dataGridViewItems.Location = new System.Drawing.Point(10, 62);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowHeadersWidth = 4;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(825, 383);
			this.dataGridViewItems.TabIndex = 0;
			// 
			// ColumnPrintInWP
			// 
			this.ColumnPrintInWP.HeaderText = "Print";
			this.ColumnPrintInWP.Name = "ColumnPrintInWP";
			this.ColumnPrintInWP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnPrintInWP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// ColumnQty
			// 
			this.ColumnQty.HeaderText = "Q-ty";
			this.ColumnQty.Items.AddRange(new object[] {
            "One for all",
            "One for One"});
			this.ColumnQty.Name = "ColumnQty";
			this.ColumnQty.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnQty.Width = 80;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(760, 460);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// checkBoxPrintDupliates
			// 
			this.checkBoxPrintDupliates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxPrintDupliates.AutoSize = true;
			this.checkBoxPrintDupliates.Location = new System.Drawing.Point(10, 478);
			this.checkBoxPrintDupliates.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxPrintDupliates.Name = "checkBoxPrintDupliates";
			this.checkBoxPrintDupliates.Size = new System.Drawing.Size(160, 15);
			this.checkBoxPrintDupliates.TabIndex = 4;
			this.checkBoxPrintDupliates.Text = "Print Duplicate Task Cards";
			this.checkBoxPrintDupliates.UseSelectable = true;
			// 
			// checkBoxPrintIncoming
			// 
			this.checkBoxPrintIncoming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxPrintIncoming.AutoSize = true;
			this.checkBoxPrintIncoming.Location = new System.Drawing.Point(10, 452);
			this.checkBoxPrintIncoming.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxPrintIncoming.Name = "checkBoxPrintIncoming";
			this.checkBoxPrintIncoming.Size = new System.Drawing.Size(160, 15);
			this.checkBoxPrintIncoming.TabIndex = 2;
			this.checkBoxPrintIncoming.Text = "Print Incoming Inspection";
			this.checkBoxPrintIncoming.UseSelectable = true;
			this.checkBoxPrintIncoming.Click += new System.EventHandler(this.CheckBoxPrintIncomingClick);
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			// 
			// 
			// 
			this.textBoxNumber.CustomButton.Image = null;
			this.textBoxNumber.CustomButton.Location = new System.Drawing.Point(170, 2);
			this.textBoxNumber.CustomButton.Name = "";
			this.textBoxNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxNumber.CustomButton.TabIndex = 1;
			this.textBoxNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxNumber.CustomButton.UseSelectable = true;
			this.textBoxNumber.CustomButton.Visible = false;
			this.textBoxNumber.Lines = new string[0];
			this.textBoxNumber.Location = new System.Drawing.Point(376, 450);
			this.textBoxNumber.MaxLength = 32767;
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.PasswordChar = '\0';
			this.textBoxNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxNumber.SelectedText = "";
			this.textBoxNumber.SelectionLength = 0;
			this.textBoxNumber.SelectionStart = 0;
			this.textBoxNumber.ShortcutsEnabled = true;
			this.textBoxNumber.Size = new System.Drawing.Size(188, 20);
			this.textBoxNumber.TabIndex = 3;
			this.textBoxNumber.UseSelectable = true;
			this.textBoxNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelJONumber
			// 
			this.labelJONumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelJONumber.AutoSize = true;
			this.labelJONumber.Location = new System.Drawing.Point(206, 448);
			this.labelJONumber.Name = "labelJONumber";
			this.labelJONumber.Size = new System.Drawing.Size(78, 19);
			this.labelJONumber.TabIndex = 6;
			this.labelJONumber.Text = "JO Number";
			// 
			// comboBoxRoutingTaskGrouping
			// 
			this.comboBoxRoutingTaskGrouping.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.comboBoxRoutingTaskGrouping.FormattingEnabled = true;
			this.comboBoxRoutingTaskGrouping.Location = new System.Drawing.Point(376, 476);
			this.comboBoxRoutingTaskGrouping.Name = "comboBoxRoutingTaskGrouping";
			this.comboBoxRoutingTaskGrouping.Size = new System.Drawing.Size(187, 21);
			this.comboBoxRoutingTaskGrouping.TabIndex = 5;
			// 
			// labelRtGrouping
			// 
			this.labelRtGrouping.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelRtGrouping.AutoSize = true;
			this.labelRtGrouping.Location = new System.Drawing.Point(206, 474);
			this.labelRtGrouping.Name = "labelRtGrouping";
			this.labelRtGrouping.Size = new System.Drawing.Size(142, 19);
			this.labelRtGrouping.TabIndex = 8;
			this.labelRtGrouping.Text = "Routine tasks grouping";
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Item";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 440;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn2.HeaderText = "Task Card";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 200;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.HeaderText = "Item";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.ReadOnly = true;
			this.ColumnDescription.Width = 440;
			// 
			// ColumnTaskCard
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnTaskCard.DefaultCellStyle = dataGridViewCellStyle1;
			this.ColumnTaskCard.HeaderText = "Task Card";
			this.ColumnTaskCard.Name = "ColumnTaskCard";
			this.ColumnTaskCard.Width = 200;
			// 
			// SelectWPPrintTasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 499);
			this.Controls.Add(this.labelRtGrouping);
			this.Controls.Add(this.comboBoxRoutingTaskGrouping);
			this.Controls.Add(this.labelJONumber);
			this.Controls.Add(this.textBoxNumber);
			this.Controls.Add(this.checkBoxPrintIncoming);
			this.Controls.Add(this.checkBoxPrintDupliates);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.dataGridViewItems);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectWPPrintTasksForm";
			this.Resizable = false;
			this.Text = "Select Items to print";
			this.Activated += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Activated);
			this.Deactivate += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Deactivate);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.Button buttonOK;
        private MetroCheckBox checkBoxPrintDupliates;
        private MetroCheckBox checkBoxPrintIncoming;
        private MetroTextBox textBoxNumber;
        private MetroLabel labelJONumber;
        private System.Windows.Forms.ComboBox comboBoxRoutingTaskGrouping;
        private MetroLabel labelRtGrouping;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaskCard;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPrintInWP;
		private System.Windows.Forms.DataGridViewComboBoxColumn ColumnQty;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
	}
}