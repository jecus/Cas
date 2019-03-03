
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectWPPrintTasksForm));
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTaskCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnPrintInWP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnQty = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.buttonOK = new System.Windows.Forms.Button();
			this.checkBoxPrintDupliates = new System.Windows.Forms.CheckBox();
			this.checkBoxPrintIncoming = new System.Windows.Forms.CheckBox();
			this.textBoxNumber = new System.Windows.Forms.TextBox();
			this.labelJONumber = new System.Windows.Forms.Label();
			this.comboBoxRoutingTaskGrouping = new System.Windows.Forms.ComboBox();
			this.labelRtGrouping = new System.Windows.Forms.Label();
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
			this.dataGridViewItems.Location = new System.Drawing.Point(10, 11);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowHeadersWidth = 4;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(825, 326);
			this.dataGridViewItems.TabIndex = 0;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.HeaderText = "Item";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.ReadOnly = true;
			this.ColumnDescription.Width = 300;
			// 
			// ColumnTaskCard
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnTaskCard.DefaultCellStyle = dataGridViewCellStyle1;
			this.ColumnTaskCard.HeaderText = "Task Card";
			this.ColumnTaskCard.Name = "ColumnTaskCard";
			this.ColumnTaskCard.Width = 250;
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
			this.ColumnQty.Width = 150;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(779, 368);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(56, 19);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// checkBoxPrintDupliates
			// 
			this.checkBoxPrintDupliates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxPrintDupliates.AutoSize = true;
			this.checkBoxPrintDupliates.Location = new System.Drawing.Point(10, 368);
			this.checkBoxPrintDupliates.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxPrintDupliates.Name = "checkBoxPrintDupliates";
			this.checkBoxPrintDupliates.Size = new System.Drawing.Size(152, 17);
			this.checkBoxPrintDupliates.TabIndex = 4;
			this.checkBoxPrintDupliates.Text = "Print Duplicate Task Cards";
			this.checkBoxPrintDupliates.UseVisualStyleBackColor = true;
			// 
			// checkBoxPrintIncoming
			// 
			this.checkBoxPrintIncoming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxPrintIncoming.AutoSize = true;
			this.checkBoxPrintIncoming.Location = new System.Drawing.Point(10, 342);
			this.checkBoxPrintIncoming.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxPrintIncoming.Name = "checkBoxPrintIncoming";
			this.checkBoxPrintIncoming.Size = new System.Drawing.Size(145, 17);
			this.checkBoxPrintIncoming.TabIndex = 2;
			this.checkBoxPrintIncoming.Text = "Print Incoming Inspection";
			this.checkBoxPrintIncoming.UseVisualStyleBackColor = true;
			this.checkBoxPrintIncoming.Click += new System.EventHandler(this.CheckBoxPrintIncomingClick);
			// 
			// textBoxNumber
			// 
			this.textBoxNumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.textBoxNumber.Location = new System.Drawing.Point(227, 340);
			this.textBoxNumber.Name = "textBoxNumber";
			this.textBoxNumber.Size = new System.Drawing.Size(187, 20);
			this.textBoxNumber.TabIndex = 3;
			// 
			// labelJONumber
			// 
			this.labelJONumber.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelJONumber.AutoSize = true;
			this.labelJONumber.Location = new System.Drawing.Point(161, 343);
			this.labelJONumber.Name = "labelJONumber";
			this.labelJONumber.Size = new System.Drawing.Size(60, 13);
			this.labelJONumber.TabIndex = 6;
			this.labelJONumber.Text = "JO Number";
			// 
			// comboBoxRoutingTaskGrouping
			// 
			this.comboBoxRoutingTaskGrouping.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.comboBoxRoutingTaskGrouping.FormattingEnabled = true;
			this.comboBoxRoutingTaskGrouping.Location = new System.Drawing.Point(586, 340);
			this.comboBoxRoutingTaskGrouping.Name = "comboBoxRoutingTaskGrouping";
			this.comboBoxRoutingTaskGrouping.Size = new System.Drawing.Size(164, 21);
			this.comboBoxRoutingTaskGrouping.TabIndex = 5;
			// 
			// labelRtGrouping
			// 
			this.labelRtGrouping.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.labelRtGrouping.AutoSize = true;
			this.labelRtGrouping.Location = new System.Drawing.Point(464, 343);
			this.labelRtGrouping.Name = "labelRtGrouping";
			this.labelRtGrouping.Size = new System.Drawing.Size(116, 13);
			this.labelRtGrouping.TabIndex = 8;
			this.labelRtGrouping.Text = "Routine tasks grouping";
			// 
			// SelectWPPrintTasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 391);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaskCard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPrintInWP;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWPACCPrintTitle;
        //private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnWPACCPrintTaskCard;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnQty;
        private System.Windows.Forms.CheckBox checkBoxPrintDupliates;
        private System.Windows.Forms.CheckBox checkBoxPrintIncoming;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelJONumber;
        private System.Windows.Forms.ComboBox comboBoxRoutingTaskGrouping;
        private System.Windows.Forms.Label labelRtGrouping;
    }
}