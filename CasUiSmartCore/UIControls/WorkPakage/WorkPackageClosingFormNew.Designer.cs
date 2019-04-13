using MetroFramework.Controls;

namespace CAS.UI.UIControls.WorkPakage
{
    partial class WorkPackageClosingFormNew
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTaskCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCycles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDate = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn();
			this.buttonCloseWP = new System.Windows.Forms.Button();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelClosingDate = new MetroFramework.Controls.MetroLabel();
			this.checkBoxSelectAll = new MetroFramework.Controls.MetroCheckBox();
			this.panelButtons = new MetroFramework.Controls.MetroPanel();
			this.documentControl6 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl5 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl4 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl3 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl2 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCalendarColumn1 = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.documentControl7 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl8 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl9 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl10 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
			this.panelButtons.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
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
            this.ColumnType,
            this.ColumnTask,
            this.ColumnTaskCard,
            this.ColumnClosed,
            this.ColumnHours,
            this.ColumnCycles,
            this.ColumnDays,
            this.ColumnDate});
			this.dataGridViewItems.Location = new System.Drawing.Point(4, 62);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(866, 296);
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
			this.ColumnTask.Width = 320;
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
			this.ColumnDate.Width = 75;
			// 
			// buttonCloseWP
			// 
			this.buttonCloseWP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCloseWP.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCloseWP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCloseWP.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCloseWP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCloseWP.Location = new System.Drawing.Point(619, 288);
			this.buttonCloseWP.Name = "buttonCloseWP";
			this.buttonCloseWP.Size = new System.Drawing.Size(163, 33);
			this.buttonCloseWP.TabIndex = 56;
			this.buttonCloseWP.Text = "Close work package";
			this.buttonCloseWP.Click += new System.EventHandler(this.ButtonCloceWpClick);
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(105, 22);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(198, 22);
			this.dateTimePickerClosingDate.TabIndex = 11;
			this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(788, 288);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 292;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// labelClosingDate
			// 
			this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClosingDate.Location = new System.Drawing.Point(5, 18);
			this.labelClosingDate.Name = "labelClosingDate";
			this.labelClosingDate.Size = new System.Drawing.Size(100, 30);
			this.labelClosingDate.TabIndex = 10;
			this.labelClosingDate.Text = "Closing Date:";
			this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxSelectAll
			// 
			this.checkBoxSelectAll.AutoSize = true;
			this.checkBoxSelectAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxSelectAll.Location = new System.Drawing.Point(307, 22);
			this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxSelectAll.Name = "checkBoxSelectAll";
			this.checkBoxSelectAll.Size = new System.Drawing.Size(103, 15);
			this.checkBoxSelectAll.TabIndex = 58;
			this.checkBoxSelectAll.Text = "Select All Items";
			this.checkBoxSelectAll.UseSelectable = true;
			this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.flowLayoutPanel1);
			this.panelButtons.Controls.Add(this.checkBox1);
			this.panelButtons.Controls.Add(this.checkedListBox1);
			this.panelButtons.Controls.Add(this.lifelengthViewer1);
			this.panelButtons.Controls.Add(this.checkBoxSelectAll);
			this.panelButtons.Controls.Add(this.labelClosingDate);
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.dateTimePickerClosingDate);
			this.panelButtons.Controls.Add(this.buttonCloseWP);
			this.panelButtons.HorizontalScrollbarBarColor = true;
			this.panelButtons.HorizontalScrollbarHighlightOnWheel = false;
			this.panelButtons.HorizontalScrollbarSize = 10;
			this.panelButtons.Location = new System.Drawing.Point(4, 363);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(866, 324);
			this.panelButtons.TabIndex = 58;
			this.panelButtons.VerticalScrollbarBarColor = true;
			this.panelButtons.VerticalScrollbarHighlightOnWheel = false;
			this.panelButtons.VerticalScrollbarSize = 10;
			// 
			// documentControl6
			// 
			this.documentControl6.CurrentDocument = null;
			this.documentControl6.Location = new System.Drawing.Point(3, 191);
			this.documentControl6.Name = "documentControl6";
			this.documentControl6.Size = new System.Drawing.Size(419, 41);
			this.documentControl6.TabIndex = 67;
			// 
			// documentControl5
			// 
			this.documentControl5.CurrentDocument = null;
			this.documentControl5.Location = new System.Drawing.Point(3, 238);
			this.documentControl5.Name = "documentControl5";
			this.documentControl5.Size = new System.Drawing.Size(419, 41);
			this.documentControl5.TabIndex = 66;
			// 
			// documentControl4
			// 
			this.documentControl4.CurrentDocument = null;
			this.documentControl4.Location = new System.Drawing.Point(3, 285);
			this.documentControl4.Name = "documentControl4";
			this.documentControl4.Size = new System.Drawing.Size(419, 41);
			this.documentControl4.TabIndex = 65;
			// 
			// documentControl3
			// 
			this.documentControl3.CurrentDocument = null;
			this.documentControl3.Location = new System.Drawing.Point(3, 332);
			this.documentControl3.Name = "documentControl3";
			this.documentControl3.Size = new System.Drawing.Size(419, 41);
			this.documentControl3.TabIndex = 64;
			// 
			// documentControl2
			// 
			this.documentControl2.CurrentDocument = null;
			this.documentControl2.Location = new System.Drawing.Point(3, 426);
			this.documentControl2.Name = "documentControl2";
			this.documentControl2.Size = new System.Drawing.Size(419, 41);
			this.documentControl2.TabIndex = 63;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(236, 107);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(148, 15);
			this.checkBox1.TabIndex = 62;
			this.checkBox1.Text = "Close With Mtop Check";
			this.checkBox1.UseSelectable = true;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(12, 107);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(219, 124);
			this.checkedListBox1.TabIndex = 61;
			this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
			// 
			// lifelengthViewer1
			// 
			this.lifelengthViewer1.AutoSize = true;
			this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer1.CalendarApplicable = false;
			this.lifelengthViewer1.CyclesApplicable = false;
			this.lifelengthViewer1.EnabledCalendar = false;
			this.lifelengthViewer1.EnabledCycle = true;
			this.lifelengthViewer1.EnabledHours = true;
			this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer1.HeaderCalendar = "Calendar";
			this.lifelengthViewer1.HeaderCycles = "Cycles";
			this.lifelengthViewer1.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer1.HeaderHours = "Hours";
			this.lifelengthViewer1.HoursApplicable = false;
			this.lifelengthViewer1.LeftHeader = "Left";
			this.lifelengthViewer1.Location = new System.Drawing.Point(12, 49);
			this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer1.Modified = false;
			this.lifelengthViewer1.Name = "lifelengthViewer1";
			this.lifelengthViewer1.ReadOnly = false;
			this.lifelengthViewer1.ShowCalendar = true;
			this.lifelengthViewer1.ShowFormattedCalendar = false;
			this.lifelengthViewer1.ShowLeftHeader = false;
			this.lifelengthViewer1.ShowMinutes = true;
			this.lifelengthViewer1.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewer1.SystemCalculated = true;
			this.lifelengthViewer1.TabIndex = 60;
			this.lifelengthViewer1.LifelengthChanged += new System.EventHandler(this.lifelengthViewer1_LifelengthChanged_1);
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(3, 379);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(419, 41);
			this.documentControl1.TabIndex = 59;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.HeaderText = "Type";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 75;
			// 
			// dataGridViewTextBoxColumn2
			// 
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn2.HeaderText = "Task";
			this.dataGridViewTextBoxColumn2.MaxInputLength = 3072;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Width = 200;
			// 
			// dataGridViewTextBoxColumn3
			// 
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridViewTextBoxColumn3.HeaderText = "Task Card";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.HeaderText = "Hours";
			this.dataGridViewTextBoxColumn4.MaxInputLength = 16;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 75;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "Cycles";
			this.dataGridViewTextBoxColumn5.MaxInputLength = 16;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.Width = 75;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "Days";
			this.dataGridViewTextBoxColumn6.MaxInputLength = 16;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Width = 75;
			// 
			// dataGridViewCalendarColumn1
			// 
			this.dataGridViewCalendarColumn1.HeaderText = "Date";
			this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
			this.dataGridViewCalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewCalendarColumn1.Width = 200;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Controls.Add(this.documentControl1);
			this.flowLayoutPanel1.Controls.Add(this.documentControl2);
			this.flowLayoutPanel1.Controls.Add(this.documentControl3);
			this.flowLayoutPanel1.Controls.Add(this.documentControl4);
			this.flowLayoutPanel1.Controls.Add(this.documentControl5);
			this.flowLayoutPanel1.Controls.Add(this.documentControl6);
			this.flowLayoutPanel1.Controls.Add(this.documentControl7);
			this.flowLayoutPanel1.Controls.Add(this.documentControl8);
			this.flowLayoutPanel1.Controls.Add(this.documentControl9);
			this.flowLayoutPanel1.Controls.Add(this.documentControl10);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(415, 22);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(443, 260);
			this.flowLayoutPanel1.TabIndex = 293;
			// 
			// documentControl7
			// 
			this.documentControl7.CurrentDocument = null;
			this.documentControl7.Location = new System.Drawing.Point(3, 3);
			this.documentControl7.Name = "documentControl7";
			this.documentControl7.Size = new System.Drawing.Size(419, 41);
			this.documentControl7.TabIndex = 294;
			// 
			// documentControl8
			// 
			this.documentControl8.CurrentDocument = null;
			this.documentControl8.Location = new System.Drawing.Point(3, 50);
			this.documentControl8.Name = "documentControl8";
			this.documentControl8.Size = new System.Drawing.Size(419, 41);
			this.documentControl8.TabIndex = 295;
			// 
			// documentControl9
			// 
			this.documentControl9.CurrentDocument = null;
			this.documentControl9.Location = new System.Drawing.Point(3, 97);
			this.documentControl9.Name = "documentControl9";
			this.documentControl9.Size = new System.Drawing.Size(419, 41);
			this.documentControl9.TabIndex = 296;
			// 
			// documentControl10
			// 
			this.documentControl10.CurrentDocument = null;
			this.documentControl10.Location = new System.Drawing.Point(3, 144);
			this.documentControl10.Name = "documentControl10";
			this.documentControl10.Size = new System.Drawing.Size(419, 41);
			this.documentControl10.TabIndex = 297;
			// 
			// WorkPackageClosingFormNew
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(872, 699);
			this.Controls.Add(this.dataGridViewItems);
			this.Controls.Add(this.panelButtons);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(964, 699);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(770, 188);
			this.Name = "WorkPackageClosingFormNew";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Work Package Closing Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
			this.panelButtons.ResumeLayout(false);
			this.panelButtons.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.DataGridView dataGridViewItems;
		private System.Windows.Forms.Button buttonCloseWP;
		private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private System.Windows.Forms.Button buttonCancel;
		private MetroLabel labelClosingDate;
		private MetroCheckBox checkBoxSelectAll;
		private DocumentationControls.DocumentControl documentControl1;
		private Auxiliary.LifelengthViewer lifelengthViewer1;
		private MetroPanel panelButtons;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private Auxiliary.DataGridViewElements.DataGridViewCalendarColumn dataGridViewCalendarColumn1;
		private MetroCheckBox checkBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaskCard;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnClosed;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHours;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCycles;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDays;
		private Auxiliary.DataGridViewElements.DataGridViewCalendarColumn ColumnDate;
		private DocumentationControls.DocumentControl documentControl6;
		private DocumentationControls.DocumentControl documentControl5;
		private DocumentationControls.DocumentControl documentControl4;
		private DocumentationControls.DocumentControl documentControl3;
		private DocumentationControls.DocumentControl documentControl2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private DocumentationControls.DocumentControl documentControl7;
		private DocumentationControls.DocumentControl documentControl8;
		private DocumentationControls.DocumentControl documentControl9;
		private DocumentationControls.DocumentControl documentControl10;
	}
}