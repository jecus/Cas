using System.Threading;
using AvControls.AvButtonT;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenancePlanningControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
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

                if(_checkItems != null)
                {
                    _checkItems.CollectionChanged -= ItemsCollectionChanged;
                    foreach (MaintenanceCheck liminationItem in _checkItems)
                    {
                        liminationItem.PropertyChanged -= ItemPropertyChanged;
                    }

                    _checkItems.Clear();
                }

                if (_currentForecast != null)
                {
                    _currentForecast.Dispose();
                    _currentForecast = null;
                }
                if(_openPubWorkPackages != null)
                    _openPubWorkPackages.Clear();
                if(_openPubQuotations != null)
                    _openPubQuotations.Clear();

                if(directivesViewer != null)
                {
                    directivesViewer.DisposeView();
                }

                radioButtonByDate.CheckedChanged -= RadioButtonCheckedChanged;
                radioButtonByPerformance.CheckedChanged -= RadioButtonCheckedChanged;
                radioButtonByPeriod.CheckedChanged -= RadioButtonCheckedChanged;
                dateTimePickerFrom.ValueChanged -= DateTimePickerValueChanged;
                dateTimePickerTo.ValueChanged -= DateTimePickerValueChanged;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.directivesViewer = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView();
            this.comboBoxCheck = new System.Windows.Forms.ComboBox();
            this.comboBoxPerformance = new System.Windows.Forms.ComboBox();
            this.labelCheck = new System.Windows.Forms.Label();
            this.labelPerformance = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelApprovals = new System.Windows.Forms.Label();
            this.numericUpDownApprovals = new System.Windows.Forms.NumericUpDown();
            this.radioButtonByPerformance = new System.Windows.Forms.RadioButton();
            this.radioButtonByDate = new System.Windows.Forms.RadioButton();
            this.labelByDate = new System.Windows.Forms.Label();
            this.comboBoxByDate = new System.Windows.Forms.ComboBox();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.radioButtonByPeriod = new System.Windows.Forms.RadioButton();
            this.labelPeriodFrom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApprovals)).BeginInit();
            this.SuspendLayout();
            // 
            // directivesViewer
            // 
            this.directivesViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.directivesViewer.Displayer = null;
            this.directivesViewer.DisplayerText = null;
            this.directivesViewer.Entity = null;
            this.directivesViewer.Location = new System.Drawing.Point(0, 89);
            this.directivesViewer.Name = "directivesViewer";
            this.directivesViewer.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.directivesViewer.ShowGroups = true;
            this.directivesViewer.Size = new System.Drawing.Size(895, 378);
            this.directivesViewer.TabIndex = 6;
            // 
            // comboBoxCheck
            // 
            this.comboBoxCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCheck.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxCheck.FormattingEnabled = true;
            this.comboBoxCheck.Location = new System.Drawing.Point(81, 2);
            this.comboBoxCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCheck.Name = "comboBoxCheck";
            this.comboBoxCheck.Size = new System.Drawing.Size(137, 25);
            this.comboBoxCheck.TabIndex = 2;
            this.comboBoxCheck.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCheckSelectedIndexChanged);
            // 
            // comboBoxPerformance
            // 
            this.comboBoxPerformance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPerformance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPerformance.FormattingEnabled = true;
            this.comboBoxPerformance.Location = new System.Drawing.Point(319, 2);
            this.comboBoxPerformance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxPerformance.Name = "comboBoxPerformance";
            this.comboBoxPerformance.Size = new System.Drawing.Size(249, 25);
            this.comboBoxPerformance.TabIndex = 3;
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheck.ForeColor = System.Drawing.Color.DimGray;
            this.labelCheck.Location = new System.Drawing.Point(25, 5);
            this.labelCheck.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(56, 17);
            this.labelCheck.TabIndex = 4;
            this.labelCheck.Text = "Check:";
            // 
            // labelPerformance
            // 
            this.labelPerformance.AutoSize = true;
            this.labelPerformance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPerformance.ForeColor = System.Drawing.Color.DimGray;
            this.labelPerformance.Location = new System.Drawing.Point(221, 5);
            this.labelPerformance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPerformance.Name = "labelPerformance";
            this.labelPerformance.Size = new System.Drawing.Size(101, 17);
            this.labelPerformance.TabIndex = 5;
            this.labelPerformance.Text = "Performance:";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(574, 58);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 24);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "Calculate";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // labelApprovals
            // 
            this.labelApprovals.AutoSize = true;
            this.labelApprovals.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApprovals.ForeColor = System.Drawing.Color.DimGray;
            this.labelApprovals.Location = new System.Drawing.Point(572, 5);
            this.labelApprovals.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelApprovals.Name = "labelApprovals";
            this.labelApprovals.Size = new System.Drawing.Size(90, 17);
            this.labelApprovals.TabIndex = 7;
            this.labelApprovals.Text = "Approv. %:";
            // 
            // numericUpDownApprovals
            // 
            this.numericUpDownApprovals.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.numericUpDownApprovals.Location = new System.Drawing.Point(574, 30);
            this.numericUpDownApprovals.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.numericUpDownApprovals.Size = new System.Drawing.Size(112, 24);
            this.numericUpDownApprovals.TabIndex = 3;
            this.numericUpDownApprovals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // radioButtonByPerformance
            // 
            this.radioButtonByPerformance.AutoSize = true;
            this.radioButtonByPerformance.Checked = true;
            this.radioButtonByPerformance.Location = new System.Drawing.Point(8, 8);
            this.radioButtonByPerformance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonByPerformance.Name = "radioButtonByPerformance";
            this.radioButtonByPerformance.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByPerformance.TabIndex = 1;
            this.radioButtonByPerformance.TabStop = true;
            this.radioButtonByPerformance.UseVisualStyleBackColor = true;
            this.radioButtonByPerformance.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonByDate
            // 
            this.radioButtonByDate.AutoSize = true;
            this.radioButtonByDate.Location = new System.Drawing.Point(8, 36);
            this.radioButtonByDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonByDate.Name = "radioButtonByDate";
            this.radioButtonByDate.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByDate.TabIndex = 1;
            this.radioButtonByDate.UseVisualStyleBackColor = true;
            this.radioButtonByDate.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // labelByDate
            // 
            this.labelByDate.AutoSize = true;
            this.labelByDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelByDate.ForeColor = System.Drawing.Color.DimGray;
            this.labelByDate.Location = new System.Drawing.Point(25, 33);
            this.labelByDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelByDate.Name = "labelByDate";
            this.labelByDate.Size = new System.Drawing.Size(47, 17);
            this.labelByDate.TabIndex = 11;
            this.labelByDate.Text = "Next:";
            // 
            // comboBoxByDate
            // 
            this.comboBoxByDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxByDate.Enabled = false;
            this.comboBoxByDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxByDate.FormattingEnabled = true;
            this.comboBoxByDate.Location = new System.Drawing.Point(81, 30);
            this.comboBoxByDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxByDate.Name = "comboBoxByDate";
            this.comboBoxByDate.Size = new System.Drawing.Size(487, 25);
            this.comboBoxByDate.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dateTimePickerTo.Location = new System.Drawing.Point(342, 58);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(226, 24);
            this.dateTimePickerTo.TabIndex = 3;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTo.ForeColor = System.Drawing.Color.DimGray;
            this.labelTo.Location = new System.Drawing.Point(310, 63);
            this.labelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(32, 17);
            this.labelTo.TabIndex = 14;
            this.labelTo.Text = "To:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.dateTimePickerFrom.Location = new System.Drawing.Point(81, 58);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(226, 24);
            this.dateTimePickerFrom.TabIndex = 2;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // radioButtonByPeriod
            // 
            this.radioButtonByPeriod.AutoSize = true;
            this.radioButtonByPeriod.Location = new System.Drawing.Point(8, 66);
            this.radioButtonByPeriod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonByPeriod.Name = "radioButtonByPeriod";
            this.radioButtonByPeriod.Size = new System.Drawing.Size(14, 13);
            this.radioButtonByPeriod.TabIndex = 1;
            this.radioButtonByPeriod.UseVisualStyleBackColor = true;
            this.radioButtonByPeriod.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // labelPeriodFrom
            // 
            this.labelPeriodFrom.AutoSize = true;
            this.labelPeriodFrom.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPeriodFrom.ForeColor = System.Drawing.Color.DimGray;
            this.labelPeriodFrom.Location = new System.Drawing.Point(25, 63);
            this.labelPeriodFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPeriodFrom.Name = "labelPeriodFrom";
            this.labelPeriodFrom.Size = new System.Drawing.Size(50, 17);
            this.labelPeriodFrom.TabIndex = 12;
            this.labelPeriodFrom.Text = "From:";
            // 
            // MaintenancePlanningControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelByDate);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.radioButtonByPerformance);
            this.Controls.Add(this.radioButtonByPeriod);
            this.Controls.Add(this.comboBoxByDate);
            this.Controls.Add(this.labelPeriodFrom);
            this.Controls.Add(this.radioButtonByDate);
            this.Controls.Add(this.labelCheck);
            this.Controls.Add(this.comboBoxCheck);
            this.Controls.Add(this.comboBoxPerformance);
            this.Controls.Add(this.numericUpDownApprovals);
            this.Controls.Add(this.labelPerformance);
            this.Controls.Add(this.directivesViewer);
            this.Controls.Add(this.labelApprovals);
            this.Controls.Add(this.buttonOK);
            this.Name = "MaintenancePlanningControl";
            this.Size = new System.Drawing.Size(898, 470);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownApprovals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView directivesViewer;
        private System.Windows.Forms.ComboBox comboBoxCheck;
        private System.Windows.Forms.ComboBox comboBoxPerformance;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.Label labelPerformance;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelApprovals;
        private System.Windows.Forms.NumericUpDown numericUpDownApprovals;
        private System.Windows.Forms.RadioButton radioButtonByPerformance;
        private System.Windows.Forms.RadioButton radioButtonByDate;
        private System.Windows.Forms.Label labelByDate;
        private System.Windows.Forms.ComboBox comboBoxByDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.RadioButton radioButtonByPeriod;
        private System.Windows.Forms.Label labelPeriodFrom;

    }
}
