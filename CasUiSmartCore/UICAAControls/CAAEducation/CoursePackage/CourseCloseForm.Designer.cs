using MetroFramework.Controls;

namespace CAS.UI.UICAAControls.CAAEducation.CoursePackage
{
	partial class CAACourseCloseForm
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
			MetroFramework.Controls.MetroLabel label11;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnTaskCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCycles = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDate = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn();
			this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTask = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			label11 = new MetroFramework.Controls.MetroLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
			this.SuspendLayout();
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label11.Location = new System.Drawing.Point(23, 360);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(86, 19);
			label11.TabIndex = 53;
			label11.Text = "Closing Date:";
			label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.DimGray;
			this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(180, 360);
			this.dateTimePickerClosingDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerClosingDate.TabIndex = 52;
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(638, 372);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 242;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(719, 372);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 241;
			this.buttonClose.Text = "Cancel";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// dataGridViewItems
			// 
			this.dataGridViewItems.AllowUserToAddRows = false;
			this.dataGridViewItems.AllowUserToDeleteRows = false;
			this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColumnType, this.ColumnTask, this.ColumnClosed });
			this.dataGridViewItems.Location = new System.Drawing.Point(22, 62);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(772, 293);
			this.dataGridViewItems.TabIndex = 243;
			// 
			// ColumnTaskCard
			// 
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnTaskCard.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColumnTaskCard.HeaderText = "Task Card";
			this.ColumnTaskCard.Name = "ColumnTaskCard";
			this.ColumnTaskCard.ReadOnly = true;
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
			// ColumnType
			// 
			this.ColumnType.HeaderText = "First Name";
			this.ColumnType.Name = "ColumnType";
			this.ColumnType.ReadOnly = true;
			this.ColumnType.Width = 320;
			// 
			// ColumnTask
			// 
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnTask.DefaultCellStyle = dataGridViewCellStyle1;
			this.ColumnTask.HeaderText = "Last Name";
			this.ColumnTask.MaxInputLength = 3072;
			this.ColumnTask.Name = "ColumnTask";
			this.ColumnTask.ReadOnly = true;
			this.ColumnTask.Width = 320;
			// 
			// ColumnClosed
			// 
			this.ColumnClosed.HeaderText = "Document";
			this.ColumnClosed.Name = "ColumnClosed";
			this.ColumnClosed.Width = 200;
			// 
			// CAACourseCloseForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(800, 414);
			this.Controls.Add(this.dataGridViewItems);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(label11);
			this.Controls.Add(this.dateTimePickerClosingDate);
			this.Location = new System.Drawing.Point(15, 15);
			this.MaximumSize = new System.Drawing.Size(937, 750);
			this.MinimumSize = new System.Drawing.Size(800, 382);
			this.Name = "CAACourseCloseForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Work Package Editor Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.DataGridView dataGridViewItems;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTask;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTaskCard;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnClosed;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHours;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCycles;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDays;
		private CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewCalendarColumn ColumnDate;

		#endregion

		private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonClose;
	}
}