namespace CAS.UI.UIControls.QualityAssuranceControls
{
    partial class AuditClosingFormNew
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
            if(disposing)
            {
                checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

                dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;
                dataGridViewItems.CurrentCellDirtyStateChanged -= DataGridViewItemsCurrentCellDirtyStateChanged;
                dataGridViewItems.DataError -= DataGridViewItemsDataError;
                dataGridViewItems.CellContentClick -= DataGridViewItemsCellContentClick;
            }
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelClosingDate = new System.Windows.Forms.Label();
            this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
            this.buttonCloseWP = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTaskCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCycles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClosingDate
            // 
            this.labelClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClosingDate.Location = new System.Drawing.Point(12, 7);
            this.labelClosingDate.Name = "labelClosingDate";
            this.labelClosingDate.Size = new System.Drawing.Size(100, 30);
            this.labelClosingDate.TabIndex = 10;
            this.labelClosingDate.Text = "Closing Date:";
            this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerClosingDate
            // 
            this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerClosingDate.Location = new System.Drawing.Point(112, 11);
            this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
            this.dateTimePickerClosingDate.Size = new System.Drawing.Size(198, 22);
            this.dateTimePickerClosingDate.TabIndex = 11;
            this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
            // 
            // buttonCloseWP
            // 
            this.buttonCloseWP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCloseWP.Location = new System.Drawing.Point(112, 77);
            this.buttonCloseWP.Name = "buttonCloseWP";
            this.buttonCloseWP.Size = new System.Drawing.Size(116, 23);
            this.buttonCloseWP.TabIndex = 56;
            this.buttonCloseWP.Text = "Close Audit";
            this.buttonCloseWP.UseVisualStyleBackColor = true;
            this.buttonCloseWP.Click += new System.EventHandler(this.ButtonCloceWpClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(234, 77);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 57;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.checkBoxSelectAll);
            this.panelButtons.Controls.Add(this.labelClosingDate);
            this.panelButtons.Controls.Add(this.fileControl);
            this.panelButtons.Controls.Add(this.buttonCancel);
            this.panelButtons.Controls.Add(this.dateTimePickerClosingDate);
            this.panelButtons.Controls.Add(this.buttonCloseWP);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 302);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(872, 103);
            this.panelButtons.TabIndex = 58;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxSelectAll.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxSelectAll.Location = new System.Drawing.Point(314, 11);
            this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(122, 18);
            this.checkBoxSelectAll.TabIndex = 58;
            this.checkBoxSelectAll.Text = "Select All Items";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
            // 
            // fileControl
            // 
            this.fileControl.AttachedFile = null;
            this.fileControl.AutoSize = true;
            this.fileControl.BackColor = System.Drawing.Color.Transparent;
            this.fileControl.Description1 = null;
            this.fileControl.Description2 = null;
            this.fileControl.Filter = null;
            this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControl.IconNotEnabled = null;
            this.fileControl.Location = new System.Drawing.Point(441, 7);
            this.fileControl.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControl.Name = "fileControl";
            this.fileControl.Size = new System.Drawing.Size(350, 75);
            this.fileControl.TabIndex = 55;
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
            this.ColumnType,
            this.ColumnTask,
            this.ColumnTaskCard,
            this.ColumnClosed,
            this.ColumnHours,
            this.ColumnCycles,
            this.ColumnDays,
            this.ColumnDate});
            this.dataGridViewItems.Location = new System.Drawing.Point(0, -2);
            this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.RowHeadersVisible = false;
            this.dataGridViewItems.RowTemplate.Height = 24;
            this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItems.Size = new System.Drawing.Size(871, 301);
            this.dataGridViewItems.TabIndex = 58;
            this.dataGridViewItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewItemsCellContentClick);
            this.dataGridViewItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewItemsCellValueChanged);
            this.dataGridViewItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewItemsCurrentCellDirtyStateChanged);
            this.dataGridViewItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewItemsDataError);
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 75;
            // 
            // ColumnTask
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTask.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnTask.HeaderText = "Task";
            this.ColumnTask.MaxInputLength = 3072;
            this.ColumnTask.Name = "ColumnTask";
            this.ColumnTask.ReadOnly = true;
            this.ColumnTask.Width = 200;
            // 
            // ColumnTaskCard
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTaskCard.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnTaskCard.HeaderText = "Task Card";
            this.ColumnTaskCard.Name = "ColumnTaskCard";
            this.ColumnTaskCard.ReadOnly = true;
            // 
            // ColumnClosed
            // 
            this.ColumnClosed.HeaderText = "Perform";
            this.ColumnClosed.Name = "ColumnClosed";
            this.ColumnClosed.Width = 50;
            // 
            // ColumnHours
            // 
            this.ColumnHours.HeaderText = "Hours";
            this.ColumnHours.MaxInputLength = 16;
            this.ColumnHours.Name = "ColumnHours";
            this.ColumnHours.Width = 75;
            // 
            // ColumnCycles
            // 
            this.ColumnCycles.HeaderText = "Cycles";
            this.ColumnCycles.MaxInputLength = 16;
            this.ColumnCycles.Name = "ColumnCycles";
            this.ColumnCycles.Width = 75;
            // 
            // ColumnDays
            // 
            this.ColumnDays.HeaderText = "Days";
            this.ColumnDays.MaxInputLength = 16;
            this.ColumnDays.Name = "ColumnDays";
            this.ColumnDays.ReadOnly = true;
            this.ColumnDays.Width = 75;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDate.Width = 200;
            // 
            // WorkPackageClosingFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(872, 405);
            this.Controls.Add(this.dataGridViewItems);
            this.Controls.Add(this.panelButtons);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(964, 499);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 188);
            this.Name = "WorkPackageClosingFormNew";
            this.ShowIcon = false;
            this.Text = "Work Package Closing Form";
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelClosingDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
        private CAS.UI.UIControls.Auxiliary.AttachedFileControl fileControl;
        private System.Windows.Forms.Button buttonCloseWP;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaskCard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnClosed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCycles;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDays;
        private Auxiliary.DataGridViewElements.DataGridViewCalendarColumn ColumnDate;
    }
}