using System.Drawing;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.Auxiliary
{
	partial class LifelengthViewer
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelLeftHeader = new System.Windows.Forms.Label();
			this.labelHoursHeader = new System.Windows.Forms.Label();
			this.labelCyclesHeader = new System.Windows.Forms.Label();
			this.CalendarHeader = new System.Windows.Forms.Label();
			this.FormattedCalendarHeader = new System.Windows.Forms.Label();
			this.textBoxCalendar = new System.Windows.Forms.TextBox();
			this.comboBoxCalendarType = new System.Windows.Forms.ComboBox();
			this.textBoxCycles = new System.Windows.Forms.TextBox();
			this.textBoxHours = new System.Windows.Forms.TextBox();
			this.textBoxFormattedCalendar = new System.Windows.Forms.TextBox();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelLeftHeader
			// 
			this.labelLeftHeader.AutoSize = true;
			this.labelLeftHeader.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLeftHeader.Location = new System.Drawing.Point(2, 20);
			this.labelLeftHeader.Margin = new System.Windows.Forms.Padding(2);
			this.labelLeftHeader.MinimumSize = new System.Drawing.Size(0, 23);
			this.labelLeftHeader.Name = "labelLeftHeader";
			this.labelLeftHeader.Size = new System.Drawing.Size(36, 23);
			this.labelLeftHeader.TabIndex = 15;
			this.labelLeftHeader.Text = "Left";
			this.labelLeftHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelHoursHeader
			// 
			this.labelHoursHeader.AutoSize = true;
			this.labelHoursHeader.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHoursHeader.Location = new System.Drawing.Point(42, 0);
			this.labelHoursHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHoursHeader.Name = "labelHoursHeader";
			this.labelHoursHeader.Size = new System.Drawing.Size(52, 18);
			this.labelHoursHeader.TabIndex = 14;
			this.labelHoursHeader.Text = "Hours";
			// 
			// labelCyclesHeader
			// 
			this.labelCyclesHeader.AutoSize = true;
			this.labelCyclesHeader.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCyclesHeader.Location = new System.Drawing.Point(133, 0);
			this.labelCyclesHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCyclesHeader.Name = "labelCyclesHeader";
			this.labelCyclesHeader.Size = new System.Drawing.Size(56, 18);
			this.labelCyclesHeader.TabIndex = 13;
			this.labelCyclesHeader.Text = "Cycles";
			// 
			// CalendarHeader
			// 
			this.CalendarHeader.AutoSize = true;
			this.CalendarHeader.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CalendarHeader.Location = new System.Drawing.Point(315, 0);
			this.CalendarHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.CalendarHeader.Name = "CalendarHeader";
			this.CalendarHeader.Size = new System.Drawing.Size(73, 18);
			this.CalendarHeader.TabIndex = 12;
			this.CalendarHeader.Text = "Calendar";
			// 
			// FormattedCalendarHeader
			// 
			this.FormattedCalendarHeader.AutoSize = true;
			this.FormattedCalendarHeader.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormattedCalendarHeader.Location = new System.Drawing.Point(224, 0);
			this.FormattedCalendarHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.FormattedCalendarHeader.Name = "FormattedCalendarHeader";
			this.FormattedCalendarHeader.Size = new System.Drawing.Size(73, 18);
			this.FormattedCalendarHeader.TabIndex = 12;
			this.FormattedCalendarHeader.Text = "Calendar";
			this.FormattedCalendarHeader.Visible = false;
			// 
			// textBoxCalendar
			// 
			this.textBoxCalendar.BackColor = System.Drawing.Color.White;
			this.textBoxCalendar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxCalendar.Location = new System.Drawing.Point(315, 20);
			this.textBoxCalendar.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCalendar.Name = "textBoxCalendar";
			this.textBoxCalendar.Size = new System.Drawing.Size(87, 23);
			this.textBoxCalendar.TabIndex = 2;
			this.textBoxCalendar.TextChanged += new System.EventHandler(this.TextBoxCalendarTextChanged);
			this.textBoxCalendar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxCalendarKeyUp);
			this.textBoxCalendar.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxCalendarPreviewKeyDown);
			this.textBoxCalendar.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxCalendarValidating);
			// 
			// comboBoxCalendarType
			// 
			this.comboBoxCalendarType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCalendarType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxCalendarType.FormattingEnabled = true;
			this.comboBoxCalendarType.Items.AddRange(new object[] {
			"Days",
			"Months",
			"Years"});
			this.comboBoxCalendarType.Location = new System.Drawing.Point(406, 20);
			this.comboBoxCalendarType.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxCalendarType.Name = "comboBoxCalendarType";
			this.comboBoxCalendarType.Size = new System.Drawing.Size(74, 24);
			this.comboBoxCalendarType.TabIndex = 3;
			this.comboBoxCalendarType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCalendarTypeSelectedIndexChanged);
			this.comboBoxCalendarType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxCycles
			// 
			this.textBoxCycles.BackColor = System.Drawing.Color.White;
			this.textBoxCycles.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxCycles.Location = new System.Drawing.Point(133, 20);
			this.textBoxCycles.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCycles.Name = "textBoxCycles";
			this.textBoxCycles.Size = new System.Drawing.Size(87, 23);
			this.textBoxCycles.TabIndex = 1;
			this.textBoxCycles.TextChanged += new System.EventHandler(this.TextBoxCyclesTextChanged);
			this.textBoxCycles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxCyclesKeyUp);
			this.textBoxCycles.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxCyclesPreviewKeyDown);
			this.textBoxCycles.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxCyclesValidating);
			// 
			// textBoxHours
			// 
			this.textBoxHours.BackColor = System.Drawing.Color.White;
			this.textBoxHours.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxHours.Location = new System.Drawing.Point(42, 20);
			this.textBoxHours.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHours.Name = "textBoxHours";
			this.textBoxHours.Size = new System.Drawing.Size(87, 23);
			this.textBoxHours.TabIndex = 0;
			this.textBoxHours.TextChanged += new System.EventHandler(this.TextBoxHoursTextChanged);
			this.textBoxHours.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxHoursKeyUp);
			this.textBoxHours.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TextBoxHoursPreviewKeyDown);
			this.textBoxHours.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursValidating);
			// 
			// textBoxFormattedCalendar
			// 
			this.textBoxFormattedCalendar.BackColor = System.Drawing.Color.White;
			this.textBoxFormattedCalendar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxFormattedCalendar.Location = new System.Drawing.Point(224, 20);
			this.textBoxFormattedCalendar.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxFormattedCalendar.Name = "textBoxFormattedCalendar";
			this.textBoxFormattedCalendar.ReadOnly = true;
			this.textBoxFormattedCalendar.Size = new System.Drawing.Size(87, 23);
			this.textBoxFormattedCalendar.TabIndex = 2;
			this.textBoxFormattedCalendar.Visible = false;
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.AutoSize = true;
			this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMain.ColumnCount = 6;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.Controls.Add(this.comboBoxCalendarType, 5, 1);
			this.tableLayoutPanelMain.Controls.Add(this.CalendarHeader, 4, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelCyclesHeader, 2, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelHoursHeader, 1, 0);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxCalendar, 4, 1);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxHours, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxCycles, 2, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelLeftHeader, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.FormattedCalendarHeader, 3, 0);
			this.tableLayoutPanelMain.Controls.Add(this.textBoxFormattedCalendar, 3, 1);
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 2;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(482, 46);
			this.tableLayoutPanelMain.TabIndex = 18;
			// 
			// LifelengthViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanelMain);
			this.ForeColor = System.Drawing.Color.DimGray;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "LifelengthViewer";
			this.Size = new System.Drawing.Size(485, 53);
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelLeftHeader;
		private System.Windows.Forms.Label labelHoursHeader;
		private System.Windows.Forms.Label labelCyclesHeader;
		private System.Windows.Forms.Label CalendarHeader;
		private System.Windows.Forms.Label FormattedCalendarHeader;
		private System.Windows.Forms.TextBox textBoxCalendar;
		private System.Windows.Forms.ComboBox comboBoxCalendarType;
		private System.Windows.Forms.TextBox textBoxCycles;
		private System.Windows.Forms.TextBox textBoxHours;
		private System.Windows.Forms.TextBox textBoxFormattedCalendar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;

	}
}