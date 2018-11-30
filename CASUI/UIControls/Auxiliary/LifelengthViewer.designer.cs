using System.Drawing;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CalendarHeader = new System.Windows.Forms.Label();
            this.labelCyclesHeader = new System.Windows.Forms.Label();
            this.labelHoursHeader = new System.Windows.Forms.Label();
            this.textBoxCalendar = new System.Windows.Forms.TextBox();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.textBoxCycles = new System.Windows.Forms.TextBox();
            this.labelLeftHeader = new System.Windows.Forms.Label();
            this.comboBoxCalendarType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.CalendarHeader, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCyclesHeader, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelHoursHeader, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCalendar, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxHours, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCycles, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLeftHeader, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCalendarType, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(423, 48);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // CalendarHeader
            // 
            this.CalendarHeader.AutoSize = true;
            this.CalendarHeader.Location = new System.Drawing.Point(255, 0);
            this.CalendarHeader.Name = "CalendarHeader";
            this.CalendarHeader.Size = new System.Drawing.Size(73, 18);
            this.CalendarHeader.TabIndex = 12;
            this.CalendarHeader.Text = "Calendar";
            // 
            // labelCyclesHeader
            // 
            this.labelCyclesHeader.AutoSize = true;
            this.labelCyclesHeader.Location = new System.Drawing.Point(164, 0);
            this.labelCyclesHeader.Name = "labelCyclesHeader";
            this.labelCyclesHeader.Size = new System.Drawing.Size(56, 18);
            this.labelCyclesHeader.TabIndex = 13;
            this.labelCyclesHeader.Text = "Cycles";
            // 
            // labelHoursHeader
            // 
            this.labelHoursHeader.AutoSize = true;
            this.labelHoursHeader.Location = new System.Drawing.Point(73, 0);
            this.labelHoursHeader.Name = "labelHoursHeader";
            this.labelHoursHeader.Size = new System.Drawing.Size(52, 18);
            this.labelHoursHeader.TabIndex = 14;
            this.labelHoursHeader.Text = "Hours";
            // 
            // textBoxCalendar
            // 
            this.textBoxCalendar.BackColor = System.Drawing.Color.White;
            this.textBoxCalendar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCalendar.Location = new System.Drawing.Point(255, 21);
            this.textBoxCalendar.Name = "textBoxCalendar";
            this.textBoxCalendar.Size = new System.Drawing.Size(85, 23);
            this.textBoxCalendar.TabIndex = 2;
            this.textBoxCalendar.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxCalendar_PreviewKeyDown);
            this.textBoxCalendar.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCalendar_Validating);
            this.textBoxCalendar.TextChanged += new System.EventHandler(textBoxCalendar_TextChanged);
            // 
            // textBoxHours
            // 
            this.textBoxHours.BackColor = System.Drawing.Color.White;
            this.textBoxHours.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHours.Location = new System.Drawing.Point(73, 21);
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(85, 23);
            this.textBoxHours.TabIndex = 0;
            this.textBoxHours.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxHours_PreviewKeyDown);
            this.textBoxHours.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHours_Validating);
            this.textBoxHours.TextChanged += new System.EventHandler(textBoxHours_TextChanged);
            // 
            // textBoxCycles
            // 
            this.textBoxCycles.BackColor = System.Drawing.Color.White;
            this.textBoxCycles.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCycles.Location = new System.Drawing.Point(164, 21);
            this.textBoxCycles.Name = "textBoxCycles";
            this.textBoxCycles.Size = new System.Drawing.Size(85, 23);
            this.textBoxCycles.TabIndex = 1;
            this.textBoxCycles.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBoxCycles_PreviewKeyDown);
            this.textBoxCycles.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCycles_Validating);
            this.textBoxCycles.TextChanged += new System.EventHandler(textBoxCycles_TextChanged);
            // 
            // labelLeftHeader
            // 
            this.labelLeftHeader.AutoSize = true;
            this.labelLeftHeader.Location = new System.Drawing.Point(3, 18);
            this.labelLeftHeader.Name = "labelLeftHeader";
            this.labelLeftHeader.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.labelLeftHeader.Size = new System.Drawing.Size(36, 25);
            this.labelLeftHeader.TabIndex = 15;
            this.labelLeftHeader.Text = "Left";
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
            this.comboBoxCalendarType.Location = new System.Drawing.Point(346, 21);
            this.comboBoxCalendarType.Name = "comboBoxCalendarType";
            this.comboBoxCalendarType.Size = new System.Drawing.Size(74, 24);
            this.comboBoxCalendarType.TabIndex = 3;
            this.comboBoxCalendarType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCalendarType_SelectedIndexChanged);
            // 
            // LifelengthViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "LifelengthViewer";
            this.Size = new System.Drawing.Size(423, 48);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label CalendarHeader;
        private System.Windows.Forms.Label labelCyclesHeader;
        private System.Windows.Forms.Label labelHoursHeader;
        private System.Windows.Forms.Label labelLeftHeader;
        private System.Windows.Forms.TextBox textBoxCalendar;
        private System.Windows.Forms.TextBox textBoxHours;
        private System.Windows.Forms.TextBox textBoxCycles;
        private System.Windows.Forms.ComboBox comboBoxCalendarType;
    }
}