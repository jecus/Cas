using System.Threading;

namespace CAS.UI.UIControls.ForecastControls
{
    partial class ForecastCustomsWriteData
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
                if (_animatedThreadWorker.IsBusy)
                    _animatedThreadWorker.CancelAsync();

                while (_animatedThreadWorker.IsBusy)
                {
                    Thread.Sleep(500);
                }

                _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
                _animatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;
                _animatedThreadWorker.Dispose();

                if (_checkItems != null)
                    _checkItems.Clear();

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
            this.dateTimePickerForecastDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lifelengthViewerDifferentSource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewer_ForecastResource = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewerCurrent = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDateResource = new System.Windows.Forms.TabPage();
            this.tabPageCheck = new System.Windows.Forms.TabPage();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.radioButtonByPeriod = new System.Windows.Forms.RadioButton();
            this.labelPeriodFrom = new System.Windows.Forms.Label();
            this.comboBoxPerformance = new System.Windows.Forms.ComboBox();
            this.numericUpDownApprovals = new System.Windows.Forms.NumericUpDown();
            this.labelPerformance = new System.Windows.Forms.Label();
            this.labelApprovals = new System.Windows.Forms.Label();
            this.labelByDate = new System.Windows.Forms.Label();
            this.radioButtonByPerformance = new System.Windows.Forms.RadioButton();
            this.comboBoxByDate = new System.Windows.Forms.ComboBox();
            this.radioButtonByDate = new System.Windows.Forms.RadioButton();
            this.labelCheck = new System.Windows.Forms.Label();
            this.comboBoxCheck = new System.Windows.Forms.ComboBox();
            this.labelCycles = new System.Windows.Forms.Label();
            this.numericUpDownCycles = new System.Windows.Forms.NumericUpDown();
            this.labelHours = new System.Windows.Forms.Label();
            this.numericUpDownHours = new System.Windows.Forms.NumericUpDown();
            this.radioButtonDayly = new System.Windows.Forms.RadioButton();
            this.checkBoxNotifyes = new System.Windows.Forms.CheckBox();
            this.radioButtonMonthly = new System.Windows.Forms.RadioButton();
            this.numericUpDownPercents = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIncludePercents = new System.Windows.Forms.CheckBox();
            this.tabControlMain.SuspendLayout();
            this.tabPageDateResource.SuspendLayout();
            this.tabPageCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerForecastDate
            // 
            this.dateTimePickerForecastDate.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.dateTimePickerForecastDate.Location = new System.Drawing.Point(106, 142);
            this.dateTimePickerForecastDate.Name = "dateTimePickerForecastDate";
            this.dateTimePickerForecastDate.Size = new System.Drawing.Size(347, 26);
            this.dateTimePickerForecastDate.TabIndex = 0;
            this.dateTimePickerForecastDate.ValueChanged += new System.EventHandler(this.DateTimePickerForecastDateValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date as of:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(304, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(385, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // lifelengthViewerDifferentSource
            // 
            this.lifelengthViewerDifferentSource.AutoSize = true;
            this.lifelengthViewerDifferentSource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerDifferentSource.CalendarApplicable = false;
            this.lifelengthViewerDifferentSource.CyclesApplicable = false;
            this.lifelengthViewerDifferentSource.Enabled = false;
            this.lifelengthViewerDifferentSource.EnabledCalendar = true;
            this.lifelengthViewerDifferentSource.EnabledCycle = true;
            this.lifelengthViewerDifferentSource.EnabledHours = true;
            this.lifelengthViewerDifferentSource.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerDifferentSource.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerDifferentSource.HeaderCalendar = "Calendar";
            this.lifelengthViewerDifferentSource.HeaderCycles = "Cycles";
            this.lifelengthViewerDifferentSource.HeaderHours = "Hours";
            this.lifelengthViewerDifferentSource.HoursApplicable = false;
            this.lifelengthViewerDifferentSource.LeftHeader = "Different";
            this.lifelengthViewerDifferentSource.Location = new System.Drawing.Point(29, 63);
            this.lifelengthViewerDifferentSource.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewerDifferentSource.Modified = false;
            this.lifelengthViewerDifferentSource.Name = "lifelengthViewerDifferentSource";
            this.lifelengthViewerDifferentSource.ReadOnly = false;
            this.lifelengthViewerDifferentSource.ShowCalendar = true;
            this.lifelengthViewerDifferentSource.ShowHeaders = false;
            this.lifelengthViewerDifferentSource.ShowLeftHeader = true;
            this.lifelengthViewerDifferentSource.ShowMinutes = true;
            this.lifelengthViewerDifferentSource.Size = new System.Drawing.Size(427, 35);
            this.lifelengthViewerDifferentSource.SystemCalculated = true;
            this.lifelengthViewerDifferentSource.TabIndex = 37;
            // 
            // lifelengthViewer_ForecastResource
            // 
            this.lifelengthViewer_ForecastResource.AutoSize = true;
            this.lifelengthViewer_ForecastResource.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer_ForecastResource.CalendarApplicable = false;
            this.lifelengthViewer_ForecastResource.CyclesApplicable = false;
            this.lifelengthViewer_ForecastResource.Enabled = false;
            this.lifelengthViewer_ForecastResource.EnabledCalendar = true;
            this.lifelengthViewer_ForecastResource.EnabledCycle = true;
            this.lifelengthViewer_ForecastResource.EnabledHours = true;
            this.lifelengthViewer_ForecastResource.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_ForecastResource.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_ForecastResource.HeaderCalendar = "Calendar";
            this.lifelengthViewer_ForecastResource.HeaderCycles = "Cycles";
            this.lifelengthViewer_ForecastResource.HeaderHours = "Hours";
            this.lifelengthViewer_ForecastResource.HoursApplicable = false;
            this.lifelengthViewer_ForecastResource.LeftHeader = "Forecast";
            this.lifelengthViewer_ForecastResource.Location = new System.Drawing.Point(30, 102);
            this.lifelengthViewer_ForecastResource.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_ForecastResource.Modified = false;
            this.lifelengthViewer_ForecastResource.Name = "lifelengthViewer_ForecastResource";
            this.lifelengthViewer_ForecastResource.ReadOnly = false;
            this.lifelengthViewer_ForecastResource.ShowCalendar = true;
            this.lifelengthViewer_ForecastResource.ShowHeaders = false;
            this.lifelengthViewer_ForecastResource.ShowLeftHeader = true;
            this.lifelengthViewer_ForecastResource.ShowMinutes = true;
            this.lifelengthViewer_ForecastResource.Size = new System.Drawing.Size(426, 35);
            this.lifelengthViewer_ForecastResource.SystemCalculated = true;
            this.lifelengthViewer_ForecastResource.TabIndex = 10;
            // 
            // lifelengthViewerCurrent
            // 
            this.lifelengthViewerCurrent.AutoSize = true;
            this.lifelengthViewerCurrent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerCurrent.CalendarApplicable = false;
            this.lifelengthViewerCurrent.CyclesApplicable = false;
            this.lifelengthViewerCurrent.Enabled = false;
            this.lifelengthViewerCurrent.EnabledCalendar = true;
            this.lifelengthViewerCurrent.EnabledCycle = true;
            this.lifelengthViewerCurrent.EnabledHours = true;
            this.lifelengthViewerCurrent.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerCurrent.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerCurrent.HeaderCalendar = "Calendar";
            this.lifelengthViewerCurrent.HeaderCycles = "Cycles";
            this.lifelengthViewerCurrent.HeaderHours = "Hours";
            this.lifelengthViewerCurrent.HoursApplicable = false;
            this.lifelengthViewerCurrent.LeftHeader = "Current";
            this.lifelengthViewerCurrent.Location = new System.Drawing.Point(36, 7);
            this.lifelengthViewerCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewerCurrent.Modified = false;
            this.lifelengthViewerCurrent.Name = "lifelengthViewerCurrent";
            this.lifelengthViewerCurrent.ReadOnly = false;
            this.lifelengthViewerCurrent.ShowCalendar = true;
            this.lifelengthViewerCurrent.ShowHeaders = true;
            this.lifelengthViewerCurrent.ShowLeftHeader = true;
            this.lifelengthViewerCurrent.ShowMinutes = true;
            this.lifelengthViewerCurrent.Size = new System.Drawing.Size(420, 52);
            this.lifelengthViewerCurrent.SystemCalculated = true;
            this.lifelengthViewerCurrent.TabIndex = 38;
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdvanced.Location = new System.Drawing.Point(223, 290);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(75, 23);
            this.buttonAdvanced.TabIndex = 39;
            this.buttonAdvanced.Text = "Advanced";
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.ButtonAdvancedClick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageDateResource);
            this.tabControlMain.Controls.Add(this.tabPageCheck);
            this.tabControlMain.Location = new System.Drawing.Point(3, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(470, 200);
            this.tabControlMain.TabIndex = 40;
            this.tabControlMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlMainSelected);
            // 
            // tabPageDateResource
            // 
            this.tabPageDateResource.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDateResource.Controls.Add(this.lifelengthViewerCurrent);
            this.tabPageDateResource.Controls.Add(this.dateTimePickerForecastDate);
            this.tabPageDateResource.Controls.Add(this.label1);
            this.tabPageDateResource.Controls.Add(this.lifelengthViewerDifferentSource);
            this.tabPageDateResource.Controls.Add(this.lifelengthViewer_ForecastResource);
            this.tabPageDateResource.Location = new System.Drawing.Point(4, 22);
            this.tabPageDateResource.Name = "tabPageDateResource";
            this.tabPageDateResource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDateResource.Size = new System.Drawing.Size(462, 174);
            this.tabPageDateResource.TabIndex = 0;
            this.tabPageDateResource.Text = "Date/Resource";
            // 
            // tabPageCheck
            // 
            this.tabPageCheck.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageCheck.Controls.Add(this.dateTimePickerTo);
            this.tabPageCheck.Controls.Add(this.labelTo);
            this.tabPageCheck.Controls.Add(this.dateTimePickerFrom);
            this.tabPageCheck.Controls.Add(this.radioButtonByPeriod);
            this.tabPageCheck.Controls.Add(this.labelPeriodFrom);
            this.tabPageCheck.Controls.Add(this.comboBoxPerformance);
            this.tabPageCheck.Controls.Add(this.numericUpDownApprovals);
            this.tabPageCheck.Controls.Add(this.labelPerformance);
            this.tabPageCheck.Controls.Add(this.labelApprovals);
            this.tabPageCheck.Controls.Add(this.labelByDate);
            this.tabPageCheck.Controls.Add(this.radioButtonByPerformance);
            this.tabPageCheck.Controls.Add(this.comboBoxByDate);
            this.tabPageCheck.Controls.Add(this.radioButtonByDate);
            this.tabPageCheck.Controls.Add(this.labelCheck);
            this.tabPageCheck.Controls.Add(this.comboBoxCheck);
            this.tabPageCheck.Location = new System.Drawing.Point(4, 22);
            this.tabPageCheck.Name = "tabPageCheck";
            this.tabPageCheck.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCheck.Size = new System.Drawing.Size(462, 174);
            this.tabPageCheck.TabIndex = 1;
            this.tabPageCheck.Text = "Check/Period";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dateTimePickerTo.Location = new System.Drawing.Point(106, 148);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(347, 24);
            this.dateTimePickerTo.TabIndex = 24;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.DateTimePickerFromToValueChanged);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTo.ForeColor = System.Drawing.Color.DimGray;
            this.labelTo.Location = new System.Drawing.Point(64, 155);
            this.labelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(32, 17);
            this.labelTo.TabIndex = 26;
            this.labelTo.Text = "To:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dateTimePickerFrom.Location = new System.Drawing.Point(106, 120);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(347, 24);
            this.dateTimePickerFrom.TabIndex = 23;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.DateTimePickerFromToValueChanged);
            // 
            // radioButtonByPeriod
            // 
            this.radioButtonByPeriod.AutoSize = true;
            this.radioButtonByPeriod.Location = new System.Drawing.Point(10, 129);
            this.radioButtonByPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonByPeriod.Name = "radioButtonByPeriod";
            this.radioButtonByPeriod.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByPeriod.TabIndex = 22;
            this.radioButtonByPeriod.UseVisualStyleBackColor = true;
            this.radioButtonByPeriod.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // labelPeriodFrom
            // 
            this.labelPeriodFrom.AutoSize = true;
            this.labelPeriodFrom.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriodFrom.ForeColor = System.Drawing.Color.DimGray;
            this.labelPeriodFrom.Location = new System.Drawing.Point(46, 125);
            this.labelPeriodFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPeriodFrom.Name = "labelPeriodFrom";
            this.labelPeriodFrom.Size = new System.Drawing.Size(50, 17);
            this.labelPeriodFrom.TabIndex = 25;
            this.labelPeriodFrom.Text = "From:";
            // 
            // comboBoxPerformance
            // 
            this.comboBoxPerformance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerformance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPerformance.FormattingEnabled = true;
            this.comboBoxPerformance.Location = new System.Drawing.Point(106, 34);
            this.comboBoxPerformance.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPerformance.Name = "comboBoxPerformance";
            this.comboBoxPerformance.Size = new System.Drawing.Size(347, 25);
            this.comboBoxPerformance.TabIndex = 19;
            // 
            // numericUpDownApprovals
            // 
            this.numericUpDownApprovals.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.numericUpDownApprovals.Location = new System.Drawing.Point(106, 92);
            this.numericUpDownApprovals.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownApprovals.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownApprovals.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownApprovals.Name = "numericUpDownApprovals";
            this.numericUpDownApprovals.Size = new System.Drawing.Size(347, 24);
            this.numericUpDownApprovals.TabIndex = 18;
            this.numericUpDownApprovals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelPerformance
            // 
            this.labelPerformance.AutoSize = true;
            this.labelPerformance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPerformance.ForeColor = System.Drawing.Color.DimGray;
            this.labelPerformance.Location = new System.Drawing.Point(27, 37);
            this.labelPerformance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(69, 17);
            this.labelPerformance.TabIndex = 20;
            this.labelPerformance.Text = "Perform:";
            // 
            // labelApprovals
            // 
            this.labelApprovals.AutoSize = true;
            this.labelApprovals.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApprovals.ForeColor = System.Drawing.Color.DimGray;
            this.labelApprovals.Location = new System.Drawing.Point(23, 94);
            this.labelApprovals.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApprovals.Name = "labelApprovals";
            this.labelApprovals.Size = new System.Drawing.Size(73, 17);
            this.labelApprovals.TabIndex = 21;
            this.labelApprovals.Text = "Appr. %:";
            // 
            // labelByDate
            // 
            this.labelByDate.AutoSize = true;
            this.labelByDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelByDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelByDate.Location = new System.Drawing.Point(49, 66);
            this.labelByDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelByDate.Name = "labelByDate";
            this.labelByDate.Size = new System.Drawing.Size(47, 17);
            this.labelByDate.TabIndex = 17;
            this.labelByDate.Text = "Next:";
            // 
            // radioButtonByPerformance
            // 
            this.radioButtonByPerformance.AutoSize = true;
            this.radioButtonByPerformance.Checked = true;
            this.radioButtonByPerformance.Location = new System.Drawing.Point(10, 11);
            this.radioButtonByPerformance.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonByPerformance.Name = "radioButtonByPerformance";
            this.radioButtonByPerformance.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByPerformance.TabIndex = 12;
            this.radioButtonByPerformance.TabStop = true;
            this.radioButtonByPerformance.UseVisualStyleBackColor = true;
            this.radioButtonByPerformance.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // comboBoxByDate
            // 
            this.comboBoxByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxByDate.Enabled = false;
            this.comboBoxByDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxByDate.FormattingEnabled = true;
            this.comboBoxByDate.Location = new System.Drawing.Point(106, 63);
            this.comboBoxByDate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxByDate.Name = "comboBoxByDate";
            this.comboBoxByDate.Size = new System.Drawing.Size(347, 25);
            this.comboBoxByDate.TabIndex = 15;
            // 
            // radioButtonByDate
            // 
            this.radioButtonByDate.AutoSize = true;
            this.radioButtonByDate.Location = new System.Drawing.Point(10, 69);
            this.radioButtonByDate.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonByDate.Name = "radioButtonByDate";
            this.radioButtonByDate.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByDate.TabIndex = 13;
            this.radioButtonByDate.UseVisualStyleBackColor = true;
            this.radioButtonByDate.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheck.ForeColor = System.Drawing.Color.DimGray;
            this.labelCheck.Location = new System.Drawing.Point(40, 8);
            this.labelCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(56, 17);
            this.labelCheck.TabIndex = 16;
            this.labelCheck.Text = "Check:";
            // 
            // comboBoxCheck
            // 
            this.comboBoxCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheck.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCheck.FormattingEnabled = true;
            this.comboBoxCheck.Location = new System.Drawing.Point(106, 5);
            this.comboBoxCheck.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCheck.Name = "comboBoxCheck";
            this.comboBoxCheck.Size = new System.Drawing.Size(347, 25);
            this.comboBoxCheck.TabIndex = 14;
            this.comboBoxCheck.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCheckSelectedIndexChanged);
            // 
            // labelCycles
            // 
            this.labelCycles.AutoSize = true;
            this.labelCycles.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelCycles.ForeColor = System.Drawing.Color.DimGray;
            this.labelCycles.Location = new System.Drawing.Point(47, 233);
            this.labelCycles.Name = "labelCycles";
            this.labelCycles.Size = new System.Drawing.Size(56, 18);
            this.labelCycles.TabIndex = 41;
            this.labelCycles.Text = "Cycles";
            // 
            // numericUpDownCycles
            // 
            this.numericUpDownCycles.DecimalPlaces = 1;
            this.numericUpDownCycles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownCycles.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownCycles.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownCycles.Location = new System.Drawing.Point(113, 231);
            this.numericUpDownCycles.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericUpDownCycles.Name = "numericUpDownCycles";
            this.numericUpDownCycles.Size = new System.Drawing.Size(256, 22);
            this.numericUpDownCycles.TabIndex = 49;
            this.numericUpDownCycles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCycles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCycles.ValueChanged += new System.EventHandler(this.NumericUpDownsValueChanged);
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelHours.ForeColor = System.Drawing.Color.DimGray;
            this.labelHours.Location = new System.Drawing.Point(51, 206);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(52, 18);
            this.labelHours.TabIndex = 42;
            this.labelHours.Text = "Hours";
            // 
            // numericUpDownHours
            // 
            this.numericUpDownHours.DecimalPlaces = 1;
            this.numericUpDownHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownHours.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownHours.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownHours.Location = new System.Drawing.Point(113, 204);
            this.numericUpDownHours.Maximum = new decimal(new int[] {
            744,
            0,
            0,
            0});
            this.numericUpDownHours.Name = "numericUpDownHours";
            this.numericUpDownHours.Size = new System.Drawing.Size(256, 22);
            this.numericUpDownHours.TabIndex = 48;
            this.numericUpDownHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHours.ValueChanged += new System.EventHandler(this.NumericUpDownsValueChanged);
            // 
            // radioButtonDayly
            // 
            this.radioButtonDayly.AutoSize = true;
            this.radioButtonDayly.Checked = true;
            this.radioButtonDayly.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radioButtonDayly.ForeColor = System.Drawing.Color.DimGray;
            this.radioButtonDayly.Location = new System.Drawing.Point(375, 204);
            this.radioButtonDayly.Name = "radioButtonDayly";
            this.radioButtonDayly.Size = new System.Drawing.Size(67, 22);
            this.radioButtonDayly.TabIndex = 43;
            this.radioButtonDayly.TabStop = true;
            this.radioButtonDayly.Text = "Dayly";
            this.radioButtonDayly.UseVisualStyleBackColor = true;
            this.radioButtonDayly.Click += new System.EventHandler(this.RadioButtonDaylyClick);
            // 
            // checkBoxNotifyes
            // 
            this.checkBoxNotifyes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxNotifyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNotifyes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxNotifyes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxNotifyes.Location = new System.Drawing.Point(113, 260);
            this.checkBoxNotifyes.Name = "checkBoxNotifyes";
            this.checkBoxNotifyes.Size = new System.Drawing.Size(142, 25);
            this.checkBoxNotifyes.TabIndex = 47;
            this.checkBoxNotifyes.Text = "Include Notifyes";
            // 
            // radioButtonMonthly
            // 
            this.radioButtonMonthly.AutoSize = true;
            this.radioButtonMonthly.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.radioButtonMonthly.ForeColor = System.Drawing.Color.DimGray;
            this.radioButtonMonthly.Location = new System.Drawing.Point(375, 231);
            this.radioButtonMonthly.Name = "radioButtonMonthly";
            this.radioButtonMonthly.Size = new System.Drawing.Size(85, 22);
            this.radioButtonMonthly.TabIndex = 44;
            this.radioButtonMonthly.Text = "Monthly";
            this.radioButtonMonthly.UseVisualStyleBackColor = true;
            this.radioButtonMonthly.Click += new System.EventHandler(this.RadioButtonDaylyClick);
            // 
            // numericUpDownPercents
            // 
            this.numericUpDownPercents.Enabled = false;
            this.numericUpDownPercents.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownPercents.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDownPercents.Location = new System.Drawing.Point(399, 263);
            this.numericUpDownPercents.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPercents.Name = "numericUpDownPercents";
            this.numericUpDownPercents.Size = new System.Drawing.Size(61, 22);
            this.numericUpDownPercents.TabIndex = 46;
            this.numericUpDownPercents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownPercents.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBoxIncludePercents
            // 
            this.checkBoxIncludePercents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxIncludePercents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxIncludePercents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxIncludePercents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxIncludePercents.Location = new System.Drawing.Point(302, 260);
            this.checkBoxIncludePercents.Name = "checkBoxIncludePercents";
            this.checkBoxIncludePercents.Size = new System.Drawing.Size(91, 25);
            this.checkBoxIncludePercents.TabIndex = 45;
            this.checkBoxIncludePercents.Text = "Percents:";
            this.checkBoxIncludePercents.Click += new System.EventHandler(this.CheckBoxIncludePercentsClick);
            // 
            // ForecastCustomsWriteData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 325);
            this.Controls.Add(this.labelCycles);
            this.Controls.Add(this.numericUpDownCycles);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.numericUpDownHours);
            this.Controls.Add(this.radioButtonDayly);
            this.Controls.Add(this.checkBoxNotifyes);
            this.Controls.Add(this.radioButtonMonthly);
            this.Controls.Add(this.numericUpDownPercents);
            this.Controls.Add(this.checkBoxIncludePercents);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonAdvanced);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForecastCustomsWriteData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forecast Parameters Form";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDateResource.ResumeLayout(false);
            this.tabPageDateResource.PerformLayout();
            this.tabPageCheck.ResumeLayout(false);
            this.tabPageCheck.PerformLayout();
            this.Activated += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Activated);
            this.Deactivate += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerForecastDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public Auxiliary.LifelengthViewer lifelengthViewer_ForecastResource;
        public Auxiliary.LifelengthViewer lifelengthViewerDifferentSource;
        public Auxiliary.LifelengthViewer lifelengthViewerCurrent;
        private System.Windows.Forms.Button buttonAdvanced;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDateResource;
        private System.Windows.Forms.TabPage tabPageCheck;
        private System.Windows.Forms.Label labelByDate;
        private System.Windows.Forms.RadioButton radioButtonByPerformance;
        private System.Windows.Forms.ComboBox comboBoxByDate;
        private System.Windows.Forms.RadioButton radioButtonByDate;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.ComboBox comboBoxCheck;
        private System.Windows.Forms.ComboBox comboBoxPerformance;
        private System.Windows.Forms.NumericUpDown numericUpDownApprovals;
        private System.Windows.Forms.Label labelPerformance;
        private System.Windows.Forms.Label labelApprovals;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.RadioButton radioButtonByPeriod;
        private System.Windows.Forms.Label labelPeriodFrom;
        private System.Windows.Forms.Label labelCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownCycles;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.NumericUpDown numericUpDownHours;
        private System.Windows.Forms.RadioButton radioButtonDayly;
        private System.Windows.Forms.CheckBox checkBoxNotifyes;
        private System.Windows.Forms.RadioButton radioButtonMonthly;
        private System.Windows.Forms.NumericUpDown numericUpDownPercents;
        private System.Windows.Forms.CheckBox checkBoxIncludePercents;
    }
}