using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PowerUnitRunupControl
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
            this.comboBoxEngine = new System.Windows.Forms.ComboBox();
            this.labelFlightEngine = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelAirTime = new System.Windows.Forms.Label();
            this.labelTimeOnLand = new System.Windows.Forms.Label();
            this.comboBoxOffPhase = new System.Windows.Forms.ComboBox();
            this.labelOffPhase = new System.Windows.Forms.Label();
            this.labelShutdownTime = new System.Windows.Forms.Label();
            this.labelRunUpPhase = new System.Windows.Forms.Label();
            this.comboBoxRunupType = new System.Windows.Forms.ComboBox();
            this.labelRunupType = new System.Windows.Forms.Label();
            this.comboBoxRunupPhase = new System.Windows.Forms.ComboBox();
            this.labelShutdownType = new System.Windows.Forms.Label();
            this.labelRunupCondition = new System.Windows.Forms.Label();
            this.reasonComboBox = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
            this.comboBoxRunupCond = new System.Windows.Forms.ComboBox();
            this.comboBoxShutDownType = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOff = new System.Windows.Forms.DateTimePicker();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dateTimePickerAirTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLandTime = new System.Windows.Forms.DateTimePicker();
            this.labelReason = new System.Windows.Forms.Label();
            this.labelWorkTime = new System.Windows.Forms.Label();
            this.labelWork120 = new System.Windows.Forms.Label();
            this.labelLifelenght = new System.Windows.Forms.Label();
            this.dateTimePickerWorkTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWork120 = new System.Windows.Forms.DateTimePicker();
            this.textBoxLifelenght = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxEngine
            // 
            this.comboBoxEngine.FormattingEnabled = true;
            this.comboBoxEngine.Location = new System.Drawing.Point(3, 13);
            this.comboBoxEngine.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxEngine.Name = "comboBoxEngine";
            this.comboBoxEngine.Size = new System.Drawing.Size(150, 21);
            this.comboBoxEngine.TabIndex = 0;
            this.comboBoxEngine.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEngineSelectedIndexChanged);
            this.comboBoxEngine.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelFlightEngine
			// 
			this.labelFlightEngine.AutoSize = true;
            this.labelFlightEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFlightEngine.Location = new System.Drawing.Point(3, 0);
            this.labelFlightEngine.Name = "labelFlightEngine";
            this.labelFlightEngine.Size = new System.Drawing.Size(50, 13);
            this.labelFlightEngine.TabIndex = 140;
            this.labelFlightEngine.Text = "Engine:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(159, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(61, 13);
            this.labelTime.TabIndex = 171;
            this.labelTime.Text = "Start time";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 15;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.textBoxLifelenght, 13, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerWork120, 12, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelWorkTime, 11, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelWork120, 12, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelLifelenght, 13, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelAirTime, 10, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelTimeOnLand, 9, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxOffPhase, 5, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelOffPhase, 5, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelShutdownTime, 4, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelRunUpPhase, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelFlightEngine, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxEngine, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxRunupType, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelTime, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelRunupType, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxRunupPhase, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelShutdownType, 7, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelRunupCondition, 6, 0);
            this.tableLayoutPanelMain.Controls.Add(this.reasonComboBox, 8, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxRunupCond, 6, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxShutDownType, 7, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerStart, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerOff, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 14, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerAirTime, 10, 1);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerLandTime, 9, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelReason, 8, 0);
            this.tableLayoutPanelMain.Controls.Add(this.dateTimePickerWorkTime, 11, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1279, 42);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // labelAirTime
            // 
            this.labelAirTime.AutoSize = true;
            this.labelAirTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAirTime.Location = new System.Drawing.Point(953, 0);
            this.labelAirTime.Name = "labelAirTime";
            this.labelAirTime.Size = new System.Drawing.Size(53, 13);
            this.labelAirTime.TabIndex = 185;
            this.labelAirTime.Text = "Air Time";
            // 
            // labelTimeOnLand
            // 
            this.labelTimeOnLand.AutoSize = true;
            this.labelTimeOnLand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeOnLand.Location = new System.Drawing.Point(881, 0);
            this.labelTimeOnLand.Name = "labelTimeOnLand";
            this.labelTimeOnLand.Size = new System.Drawing.Size(66, 13);
            this.labelTimeOnLand.TabIndex = 184;
            this.labelTimeOnLand.Text = "Land Time";
            // 
            // comboBoxOffPhase
            // 
            this.comboBoxOffPhase.FormattingEnabled = true;
            this.comboBoxOffPhase.Location = new System.Drawing.Point(476, 13);
            this.comboBoxOffPhase.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxOffPhase.Name = "comboBoxOffPhase";
            this.comboBoxOffPhase.Size = new System.Drawing.Size(87, 21);
            this.comboBoxOffPhase.TabIndex = 5;
            this.comboBoxOffPhase.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelOffPhase
			// 
			this.labelOffPhase.AutoSize = true;
            this.labelOffPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOffPhase.Location = new System.Drawing.Point(476, 0);
            this.labelOffPhase.Name = "labelOffPhase";
            this.labelOffPhase.Size = new System.Drawing.Size(62, 13);
            this.labelOffPhase.TabIndex = 179;
            this.labelOffPhase.Text = "Off phase";
            // 
            // labelShutdownTime
            // 
            this.labelShutdownTime.AutoSize = true;
            this.labelShutdownTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShutdownTime.Location = new System.Drawing.Point(407, 0);
            this.labelShutdownTime.Name = "labelShutdownTime";
            this.labelShutdownTime.Size = new System.Drawing.Size(51, 13);
            this.labelShutdownTime.TabIndex = 177;
            this.labelShutdownTime.Text = "Off time";
            // 
            // labelRunUpPhase
            // 
            this.labelRunUpPhase.AutoSize = true;
            this.labelRunUpPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRunUpPhase.Location = new System.Drawing.Point(314, 0);
            this.labelRunUpPhase.Name = "labelRunUpPhase";
            this.labelRunUpPhase.Size = new System.Drawing.Size(87, 13);
            this.labelRunUpPhase.TabIndex = 175;
            this.labelRunUpPhase.Text = "Run-up Phase";
            // 
            // comboBoxRunupType
            // 
            this.comboBoxRunupType.FormattingEnabled = true;
            this.comboBoxRunupType.Location = new System.Drawing.Point(228, 13);
            this.comboBoxRunupType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxRunupType.Name = "comboBoxRunupType";
            this.comboBoxRunupType.Size = new System.Drawing.Size(80, 21);
            this.comboBoxRunupType.TabIndex = 2;
            this.comboBoxRunupType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelRunupType
			// 
			this.labelRunupType.AutoSize = true;
            this.labelRunupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRunupType.Location = new System.Drawing.Point(228, 0);
            this.labelRunupType.Name = "labelRunupType";
            this.labelRunupType.Size = new System.Drawing.Size(80, 13);
            this.labelRunupType.TabIndex = 174;
            this.labelRunupType.Text = "Run-up Type";
            // 
            // comboBoxRunupPhase
            // 
            this.comboBoxRunupPhase.FormattingEnabled = true;
            this.comboBoxRunupPhase.Location = new System.Drawing.Point(314, 13);
            this.comboBoxRunupPhase.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxRunupPhase.Name = "comboBoxRunupPhase";
            this.comboBoxRunupPhase.Size = new System.Drawing.Size(87, 21);
            this.comboBoxRunupPhase.TabIndex = 3;
            this.comboBoxRunupPhase.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelShutdownType
			// 
			this.labelShutdownType.AutoSize = true;
            this.labelShutdownType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShutdownType.Location = new System.Drawing.Point(662, 0);
            this.labelShutdownType.Name = "labelShutdownType";
            this.labelShutdownType.Size = new System.Drawing.Size(61, 13);
            this.labelShutdownType.TabIndex = 182;
            this.labelShutdownType.Text = "Shut.type";
            // 
            // labelRunupCondition
            // 
            this.labelRunupCondition.AutoSize = true;
            this.labelRunupCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRunupCondition.Location = new System.Drawing.Point(569, 0);
            this.labelRunupCondition.Name = "labelRunupCondition";
            this.labelRunupCondition.Size = new System.Drawing.Size(85, 13);
            this.labelRunupCondition.TabIndex = 181;
            this.labelRunupCondition.Text = "Run-up Cond.";
            // 
            // reasonComboBox
            // 
            this.reasonComboBox.AutoSize = true;
            this.reasonComboBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reasonComboBox.Location = new System.Drawing.Point(755, 13);
            this.reasonComboBox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.reasonComboBox.Name = "reasonComboBox";
            this.reasonComboBox.SelectedReason = null;
            this.reasonComboBox.Size = new System.Drawing.Size(120, 29);
            this.reasonComboBox.TabIndex = 8;
            this.reasonComboBox.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxRunupCond
			// 
			this.comboBoxRunupCond.FormattingEnabled = true;
            this.comboBoxRunupCond.Location = new System.Drawing.Point(569, 13);
            this.comboBoxRunupCond.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxRunupCond.Name = "comboBoxRunupCond";
            this.comboBoxRunupCond.Size = new System.Drawing.Size(87, 21);
            this.comboBoxRunupCond.TabIndex = 6;
            this.comboBoxRunupCond.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxShutDownType
			// 
			this.comboBoxShutDownType.FormattingEnabled = true;
            this.comboBoxShutDownType.Location = new System.Drawing.Point(662, 13);
            this.comboBoxShutDownType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxShutDownType.Name = "comboBoxShutDownType";
            this.comboBoxShutDownType.Size = new System.Drawing.Size(87, 21);
            this.comboBoxShutDownType.TabIndex = 7;
            this.comboBoxShutDownType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.CustomFormat = "HH:mm";
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(158, 15);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(65, 20);
            this.dateTimePickerStart.TabIndex = 177;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // dateTimePickerOff
            // 
            this.dateTimePickerOff.CustomFormat = "HH:mm";
            this.dateTimePickerOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOff.Location = new System.Drawing.Point(406, 15);
            this.dateTimePickerOff.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerOff.Name = "dateTimePickerOff";
            this.dateTimePickerOff.ShowUpDown = true;
            this.dateTimePickerOff.Size = new System.Drawing.Size(65, 20);
            this.dateTimePickerOff.TabIndex = 177;
            this.dateTimePickerOff.ValueChanged += new System.EventHandler(this.DateTimePickerValueChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(1250, 13);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(26, 23);
            this.buttonDelete.TabIndex = 29;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // dateTimePickerAirTime
            // 
            this.dateTimePickerAirTime.CustomFormat = "HH:mm";
            this.dateTimePickerAirTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAirTime.Location = new System.Drawing.Point(952, 15);
            this.dateTimePickerAirTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerAirTime.Name = "dateTimePickerAirTime";
            this.dateTimePickerAirTime.ShowUpDown = true;
            this.dateTimePickerAirTime.Size = new System.Drawing.Size(65, 20);
            this.dateTimePickerAirTime.TabIndex = 10;
            this.dateTimePickerAirTime.ValueChanged += new System.EventHandler(this.DateTimePickerAirTimeValueChanged);
            // 
            // dateTimePickerLandTime
            // 
            this.dateTimePickerLandTime.CustomFormat = "HH:mm";
            this.dateTimePickerLandTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerLandTime.Location = new System.Drawing.Point(880, 15);
            this.dateTimePickerLandTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerLandTime.Name = "dateTimePickerLandTime";
            this.dateTimePickerLandTime.ShowUpDown = true;
            this.dateTimePickerLandTime.Size = new System.Drawing.Size(65, 20);
            this.dateTimePickerLandTime.TabIndex = 9;
            this.dateTimePickerLandTime.ValueChanged += new System.EventHandler(this.DateTimePickerLandTimeValueChanged);
            // 
            // labelReason
            // 
            this.labelReason.AutoSize = true;
            this.labelReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReason.Location = new System.Drawing.Point(755, 0);
            this.labelReason.Name = "labelReason";
            this.labelReason.Size = new System.Drawing.Size(50, 13);
            this.labelReason.TabIndex = 183;
            this.labelReason.Text = "Reason";
            // 
            // labelWorkTime
            // 
            this.labelWorkTime.AutoSize = true;
            this.labelWorkTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWorkTime.Location = new System.Drawing.Point(1022, 0);
            this.labelWorkTime.Name = "labelWorkTime";
            this.labelWorkTime.Size = new System.Drawing.Size(68, 13);
            this.labelWorkTime.TabIndex = 185;
            this.labelWorkTime.Text = "Work Time";
            // 
            // labelWork120
            // 
            this.labelWork120.AutoSize = true;
            this.labelWork120.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWork120.Location = new System.Drawing.Point(1098, 0);
            this.labelWork120.Name = "labelWork120";
            this.labelWork120.Size = new System.Drawing.Size(70, 13);
            this.labelWork120.TabIndex = 186;
            this.labelWork120.Text = "Wt20%land";
            // 
            // labelLifelenght
            // 
            this.labelLifelenght.AutoSize = true;
            this.labelLifelenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLifelenght.Location = new System.Drawing.Point(1174, 0);
            this.labelLifelenght.Name = "labelLifelenght";
            this.labelLifelenght.Size = new System.Drawing.Size(63, 13);
            this.labelLifelenght.TabIndex = 187;
            this.labelLifelenght.Text = "Lifelenght";
            // 
            // textBoxWorkTime
            //
            this.dateTimePickerWorkTime.CustomFormat = "HH:mm";
            this.dateTimePickerWorkTime.Enabled = false;
            this.dateTimePickerWorkTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWorkTime.Location = new System.Drawing.Point(1022, 16);
            this.dateTimePickerWorkTime.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerWorkTime.Name = "dateTimePickerWorkTime";
            this.dateTimePickerWorkTime.ShowUpDown = true;
            this.dateTimePickerWorkTime.Size = new System.Drawing.Size(70, 20);
            this.dateTimePickerWorkTime.TabIndex = 188;
            // 
            // textBoxWork120
            //
            this.dateTimePickerWork120.CustomFormat = "HH:mm";
            this.dateTimePickerWork120.Enabled = false;
            this.dateTimePickerWork120.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWork120.Location = new System.Drawing.Point(1098, 16);
            this.dateTimePickerWork120.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerWork120.Name = "dateTimePickerWork120";
            this.dateTimePickerWork120.ShowUpDown = true;
            this.dateTimePickerWork120.Size = new System.Drawing.Size(70, 20);
            this.dateTimePickerWork120.TabIndex = 189;
            // 
            // textBox2Lifelenght
            // 
            this.textBoxLifelenght.Enabled = false;
            this.textBoxLifelenght.Location = new System.Drawing.Point(1174, 16);
            this.textBoxLifelenght.Name = "textBox2Lifelenght";
            this.textBoxLifelenght.Size = new System.Drawing.Size(70, 20);
            this.textBoxLifelenght.TabIndex = 189;
            // 
            // PowerUnitRunupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name = "PowerUnitRunupControl";
            this.Size = new System.Drawing.Size(1282, 45);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEngine;
        private System.Windows.Forms.Label labelFlightEngine;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ComboBox comboBoxOffPhase;
        private System.Windows.Forms.Label labelOffPhase;
        private System.Windows.Forms.Label labelShutdownTime;
        private System.Windows.Forms.Label labelRunUpPhase;
        private System.Windows.Forms.ComboBox comboBoxRunupType;
        private System.Windows.Forms.Label labelRunupType;
        private System.Windows.Forms.ComboBox comboBoxRunupPhase;
        private System.Windows.Forms.Label labelRunupCondition;
        private System.Windows.Forms.Label labelShutdownType;
        private System.Windows.Forms.Label labelReason;
        private System.Windows.Forms.Button buttonDelete;
        private Auxiliary.ReasonComboBox reasonComboBox;
        private System.Windows.Forms.ComboBox comboBoxRunupCond;
        private System.Windows.Forms.ComboBox comboBoxShutDownType;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerOff;
        private System.Windows.Forms.Label labelAirTime;
        private System.Windows.Forms.Label labelTimeOnLand;
        private System.Windows.Forms.DateTimePicker dateTimePickerAirTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerLandTime;
        private System.Windows.Forms.TextBox textBoxLifelenght;
        private System.Windows.Forms.DateTimePicker dateTimePickerWork120;
        private System.Windows.Forms.Label labelWorkTime;
        private System.Windows.Forms.Label labelWork120;
        private System.Windows.Forms.Label labelLifelenght;
        private System.Windows.Forms.DateTimePicker dateTimePickerWorkTime;
    }
}
