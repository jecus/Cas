using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightDistanceControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightDistanceControl));
            this.label1 = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.numericUpDownDistance = new System.Windows.Forms.NumericUpDown();
            this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
            this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAfter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBefore = new System.Windows.Forms.NumericUpDown();
            this.labelBefore = new System.Windows.Forms.Label();
            this.labelAfter = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMeters = new System.Windows.Forms.NumericUpDown();
            this.labelMeters = new System.Windows.Forms.Label();
            this.dictComboBoxLevel = new Auxiliary.DictionaryComboBox();
            this.numericUpDownFeet = new System.Windows.Forms.NumericUpDown();
            this.labelIVFR = new System.Windows.Forms.Label();
            this.textIVFR = new System.Windows.Forms.TextBox();
            this.labelTrack = new System.Windows.Forms.Label();
            this.textBoxTrack = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight Distance";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(3, 37);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(33, 13);
            this.labelLevel.TabIndex = 4;
            this.labelLevel.Text = "Level";
            // 
            // labelMeasure
            // 
            this.labelMeasure.AutoSize = true;
            this.labelMeasure.Location = new System.Drawing.Point(206, 94);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(48, 13);
            this.labelMeasure.TabIndex = 6;
            this.labelMeasure.Text = "Measure";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(206, 67);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(49, 13);
            this.labelDistance.TabIndex = 14;
            this.labelDistance.Text = "Distance";
            // 
            // numericUpDownDistance
            // 
            this.numericUpDownDistance.Location = new System.Drawing.Point(260, 65);
            this.numericUpDownDistance.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownDistance.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDownDistance.Name = "numericUpDownDistance";
            this.numericUpDownDistance.Size = new System.Drawing.Size(136, 20);
            this.numericUpDownDistance.TabIndex = 17;
            // 
            // comboBoxMeasure
            // 
            this.comboBoxMeasure.FormattingEnabled = true;
            this.comboBoxMeasure.Location = new System.Drawing.Point(260, 91);
            this.comboBoxMeasure.Name = "comboBoxMeasure";
            this.comboBoxMeasure.Size = new System.Drawing.Size(137, 21);
            this.comboBoxMeasure.TabIndex = 18;
            this.comboBoxMeasure.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// delimiter5
			// 
			this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
            this.delimiter5.Location = new System.Drawing.Point(404, 36);
            this.delimiter5.Margin = new System.Windows.Forms.Padding(4);
            this.delimiter5.Name = "delimiter5";
            this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter5.Size = new System.Drawing.Size(1, 74);
            this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter5.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(417, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Center of Gravity";
            // 
            // numericUpDownAfter
            // 
            this.numericUpDownAfter.DecimalPlaces = 2;
            this.numericUpDownAfter.Location = new System.Drawing.Point(480, 65);
            this.numericUpDownAfter.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownAfter.Name = "numericUpDownAfter";
            this.numericUpDownAfter.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownAfter.TabIndex = 67;
            // 
            // numericUpDownBefore
            // 
            this.numericUpDownBefore.DecimalPlaces = 2;
            this.numericUpDownBefore.Location = new System.Drawing.Point(480, 35);
            this.numericUpDownBefore.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownBefore.Name = "numericUpDownBefore";
            this.numericUpDownBefore.Size = new System.Drawing.Size(80, 20);
            this.numericUpDownBefore.TabIndex = 66;
            // 
            // labelBefore
            // 
            this.labelBefore.AutoSize = true;
            this.labelBefore.Location = new System.Drawing.Point(412, 36);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(63, 13);
            this.labelBefore.TabIndex = 68;
            this.labelBefore.Text = "Before flight";
            // 
            // labelAfter
            // 
            this.labelAfter.AutoSize = true;
            this.labelAfter.Location = new System.Drawing.Point(412, 66);
            this.labelAfter.Name = "labelAfter";
            this.labelAfter.Size = new System.Drawing.Size(54, 13);
            this.labelAfter.TabIndex = 69;
            this.labelAfter.Text = "After flight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(565, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 70;
            this.label3.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 71;
            this.label4.Text = "%";
            // 
            // numericUpDownMeters
            // 
            this.numericUpDownMeters.Enabled = false;
            this.numericUpDownMeters.Location = new System.Drawing.Point(67, 65);
            this.numericUpDownMeters.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownMeters.Maximum = new decimal(new int[] {
            400000,
            0,
            0,
            0});
            this.numericUpDownMeters.Name = "numericUpDownMeters";
            this.numericUpDownMeters.ReadOnly = true;
            this.numericUpDownMeters.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownMeters.TabIndex = 73;
            this.numericUpDownMeters.ThousandsSeparator = true;
            // 
            // labelMeters
            // 
            this.labelMeters.AutoSize = true;
            this.labelMeters.Location = new System.Drawing.Point(3, 68);
            this.labelMeters.Name = "labelMeters";
            this.labelMeters.Size = new System.Drawing.Size(60, 13);
            this.labelMeters.TabIndex = 72;
            this.labelMeters.Text = "Meter/Feet";
            // 
            // comboBoxLevel
            // 
            this.dictComboBoxLevel.Displayer = null;
            this.dictComboBoxLevel.DisplayerText = null;
            this.dictComboBoxLevel.Entity = null;
            this.dictComboBoxLevel.Location = new System.Drawing.Point(67, 34);
            this.dictComboBoxLevel.Name = "comboBoxLevel";
            this.dictComboBoxLevel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictComboBoxLevel.Size = new System.Drawing.Size(133, 21);
            this.dictComboBoxLevel.TabIndex = 74;
            this.dictComboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.DictComboBoxLevelSelectedIndexChanged);
            // 
            // numericUpDownFeet
            // 
            this.numericUpDownFeet.Enabled = false;
            this.numericUpDownFeet.Location = new System.Drawing.Point(136, 65);
            this.numericUpDownFeet.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownFeet.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownFeet.Name = "numericUpDownFeet";
            this.numericUpDownFeet.ReadOnly = true;
            this.numericUpDownFeet.Size = new System.Drawing.Size(64, 20);
            this.numericUpDownFeet.TabIndex = 75;
            this.numericUpDownFeet.ThousandsSeparator = true;
            // 
            // labelIVFR
            // 
            this.labelIVFR.AutoSize = true;
            this.labelIVFR.Location = new System.Drawing.Point(3, 94);
            this.labelIVFR.Name = "labelIVFR";
            this.labelIVFR.Size = new System.Drawing.Size(50, 13);
            this.labelIVFR.TabIndex = 77;
            this.labelIVFR.Text = "IFR/VFR";
            // 
            // textIVFR
            // 
            this.textIVFR.Location = new System.Drawing.Point(67, 90);
            this.textIVFR.Name = "textIVFR";
            this.textIVFR.ReadOnly = true;
            this.textIVFR.Size = new System.Drawing.Size(133, 20);
            this.textIVFR.TabIndex = 76;
            // 
            // labelTrack
            // 
            this.labelTrack.AutoSize = true;
            this.labelTrack.Location = new System.Drawing.Point(206, 38);
            this.labelTrack.Name = "labelTrack";
            this.labelTrack.Size = new System.Drawing.Size(35, 13);
            this.labelTrack.TabIndex = 79;
            this.labelTrack.Text = "Track";
            // 
            // textBox1
            // 
            this.textBoxTrack.Location = new System.Drawing.Point(260, 34);
            this.textBoxTrack.Name = "textBox1";
            this.textBoxTrack.ReadOnly = true;
            this.textBoxTrack.Size = new System.Drawing.Size(137, 20);
            this.textBoxTrack.TabIndex = 78;
            // 
            // FlightDistanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.labelTrack);
            this.Controls.Add(this.textBoxTrack);
            this.Controls.Add(this.labelIVFR);
            this.Controls.Add(this.textIVFR);
            this.Controls.Add(this.numericUpDownFeet);
            this.Controls.Add(this.dictComboBoxLevel);
            this.Controls.Add(this.numericUpDownMeters);
            this.Controls.Add(this.labelMeters);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAfter);
            this.Controls.Add(this.labelBefore);
            this.Controls.Add(this.numericUpDownAfter);
            this.Controls.Add(this.numericUpDownBefore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.delimiter5);
            this.Controls.Add(this.comboBoxMeasure);
            this.Controls.Add(this.numericUpDownDistance);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.labelMeasure);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightDistanceControl";
            this.Size = new System.Drawing.Size(583, 116);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMeters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelMeasure;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.NumericUpDown numericUpDownDistance;
        private System.Windows.Forms.ComboBox comboBoxMeasure;
        private Auxiliary.Delimiter delimiter5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAfter;
        private System.Windows.Forms.NumericUpDown numericUpDownBefore;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.Label labelAfter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMeters;
        private System.Windows.Forms.Label labelMeters;
        private Auxiliary.DictionaryComboBox dictComboBoxLevel;
        private System.Windows.Forms.NumericUpDown numericUpDownFeet;
        private System.Windows.Forms.Label labelIVFR;
        private System.Windows.Forms.TextBox textIVFR;
        private System.Windows.Forms.Label labelTrack;
        private System.Windows.Forms.TextBox textBoxTrack;

    }
}
