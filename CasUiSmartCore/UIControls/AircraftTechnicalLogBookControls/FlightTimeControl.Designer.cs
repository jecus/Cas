namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightTimeControl
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
            this.textBlock = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textFlight = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.reasonComboBox = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
            this.dateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTakeOff = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLDG = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerNight = new System.Windows.Forms.DateTimePicker();
            this.labelDay = new System.Windows.Forms.Label();
            this.textBoxDay = new System.Windows.Forms.TextBox();
            this.labelNight = new System.Windows.Forms.Label();
            this.reasonComboBoxCancelled = new CAS.UI.UIControls.Auxiliary.ReasonComboBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelCancellation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // textBlock
            // 
            this.textBlock.Location = new System.Drawing.Point(250, 34);
            this.textBlock.Name = "textBlock";
            this.textBlock.ReadOnly = true;
            this.textBlock.Size = new System.Drawing.Size(45, 20);
            this.textBlock.TabIndex = 34;
            this.textBlock.TabStop = false;
            this.textBlock.Text = "04:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Block";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(212, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Flight";
            // 
            // textFlight
            // 
            this.textFlight.Location = new System.Drawing.Point(250, 63);
            this.textFlight.Name = "textFlight";
            this.textFlight.ReadOnly = true;
            this.textFlight.Size = new System.Drawing.Size(45, 20);
            this.textFlight.TabIndex = 31;
            this.textFlight.TabStop = false;
            this.textFlight.Text = "03:40";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Take-off - LDG";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Out - In";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Block / Airborne Time";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(3, 123);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(34, 13);
            this.labelDelay.TabIndex = 36;
            this.labelDelay.Text = "Delay";
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Location = new System.Drawing.Point(250, 121);
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownDelay.TabIndex = 6;
            this.numericUpDownDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // reasonComboBox
            // 
            this.reasonComboBox.AutoSize = true;
            this.reasonComboBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reasonComboBox.Location = new System.Drawing.Point(86, 121);
            this.reasonComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.reasonComboBox.Name = "reasonComboBox";
            this.reasonComboBox.SelectedReason = null;
            this.reasonComboBox.Size = new System.Drawing.Size(119, 29);
            this.reasonComboBox.TabIndex = 5;
            // 
            // dateTimePickerIn
            // 
            this.dateTimePickerIn.CustomFormat = "HH:mm";
            this.dateTimePickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerIn.Location = new System.Drawing.Point(152, 34);
            this.dateTimePickerIn.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerIn.Name = "dateTimePickerIn";
            this.dateTimePickerIn.ShowUpDown = true;
            this.dateTimePickerIn.Size = new System.Drawing.Size(56, 20);
            this.dateTimePickerIn.TabIndex = 2;
            this.dateTimePickerIn.ValueChanged += new System.EventHandler(this.DateTimePickerOutValueChanged);
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.CustomFormat = "HH:mm";
            this.dateTimePickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOut.Location = new System.Drawing.Point(86, 34);
            this.dateTimePickerOut.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.ShowUpDown = true;
            this.dateTimePickerOut.Size = new System.Drawing.Size(56, 20);
            this.dateTimePickerOut.TabIndex = 1;
            this.dateTimePickerOut.ValueChanged += new System.EventHandler(this.DateTimePickerOutValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "-";
            // 
            // dateTimePickerTakeOff
            // 
            this.dateTimePickerTakeOff.CustomFormat = "HH:mm";
            this.dateTimePickerTakeOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTakeOff.Location = new System.Drawing.Point(86, 63);
            this.dateTimePickerTakeOff.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTakeOff.Name = "dateTimePickerTakeOff";
            this.dateTimePickerTakeOff.ShowUpDown = true;
            this.dateTimePickerTakeOff.Size = new System.Drawing.Size(56, 20);
            this.dateTimePickerTakeOff.TabIndex = 3;
            this.dateTimePickerTakeOff.ValueChanged += new System.EventHandler(this.DateTimePickerLDGValueChanged);
            // 
            // dateTimePickerLDG
            // 
            this.dateTimePickerLDG.CustomFormat = "HH:mm";
            this.dateTimePickerLDG.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerLDG.Location = new System.Drawing.Point(151, 63);
            this.dateTimePickerLDG.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerLDG.Name = "dateTimePickerLDG";
            this.dateTimePickerLDG.ShowUpDown = true;
            this.dateTimePickerLDG.Size = new System.Drawing.Size(56, 20);
            this.dateTimePickerLDG.TabIndex = 4;
            this.dateTimePickerLDG.ValueChanged += new System.EventHandler(this.DateTimePickerLDGValueChanged);
            // 
            // dateTimePickerNight
            // 
            this.dateTimePickerNight.CustomFormat = "HH:mm";
            this.dateTimePickerNight.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerNight.Location = new System.Drawing.Point(151, 92);
            this.dateTimePickerNight.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerNight.Name = "dateTimePickerNight";
            this.dateTimePickerNight.ShowUpDown = true;
            this.dateTimePickerNight.Size = new System.Drawing.Size(56, 20);
            this.dateTimePickerNight.TabIndex = 45;
            this.dateTimePickerNight.ValueChanged += new System.EventHandler(this.DateTimePickerNightValueChanged);
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(212, 95);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(26, 13);
            this.labelDay.TabIndex = 47;
            this.labelDay.Text = "Day";
            // 
            // textBoxDay
            // 
            this.textBoxDay.Location = new System.Drawing.Point(250, 92);
            this.textBoxDay.Name = "textBoxDay";
            this.textBoxDay.ReadOnly = true;
            this.textBoxDay.Size = new System.Drawing.Size(45, 20);
            this.textBoxDay.TabIndex = 46;
            this.textBoxDay.TabStop = false;
            this.textBoxDay.Text = "03:40";
            // 
            // labelNight
            // 
            this.labelNight.AutoSize = true;
            this.labelNight.Location = new System.Drawing.Point(114, 95);
            this.labelNight.Name = "labelNight";
            this.labelNight.Size = new System.Drawing.Size(32, 13);
            this.labelNight.TabIndex = 48;
            this.labelNight.Text = "Night";
            // 
            // reasonComboBoxCancelled
            // 
            this.reasonComboBoxCancelled.AutoSize = true;
            this.reasonComboBoxCancelled.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reasonComboBoxCancelled.Location = new System.Drawing.Point(86, 153);
            this.reasonComboBoxCancelled.Margin = new System.Windows.Forms.Padding(4);
            this.reasonComboBoxCancelled.Name = "reasonComboBoxCancelled";
            this.reasonComboBoxCancelled.SelectedReason = null;
            this.reasonComboBoxCancelled.Size = new System.Drawing.Size(119, 24);
            this.reasonComboBoxCancelled.TabIndex = 49;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(212, 123);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 50;
            this.labelTime.Text = "Time";
            // 
            // labelCancellation
            // 
            this.labelCancellation.AutoSize = true;
            this.labelCancellation.Location = new System.Drawing.Point(3, 155);
            this.labelCancellation.Name = "labelCancellation";
            this.labelCancellation.Size = new System.Drawing.Size(65, 13);
            this.labelCancellation.TabIndex = 51;
            this.labelCancellation.Text = "Cancellation";
            // 
            // FlightTimeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCancellation);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.reasonComboBoxCancelled);
            this.Controls.Add(this.labelNight);
            this.Controls.Add(this.dateTimePickerNight);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.textBoxDay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerTakeOff);
            this.Controls.Add(this.dateTimePickerLDG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerOut);
            this.Controls.Add(this.dateTimePickerIn);
            this.Controls.Add(this.reasonComboBox);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.textBlock);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textFlight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightTimeControl";
            this.Size = new System.Drawing.Size(300, 183);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBlock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textFlight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private Auxiliary.ReasonComboBox reasonComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTakeOff;
        private System.Windows.Forms.DateTimePicker dateTimePickerLDG;
        private System.Windows.Forms.DateTimePicker dateTimePickerNight;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.TextBox textBoxDay;
        private System.Windows.Forms.Label labelNight;
        private Auxiliary.ReasonComboBox reasonComboBoxCancelled;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelCancellation;
    }
}
