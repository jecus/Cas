namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class ReleaseToServiceControl
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
			this.checkDY = new System.Windows.Forms.CheckBox();
			this.checkTC = new System.Windows.Forms.CheckBox();
			this.checkPFC = new System.Windows.Forms.CheckBox();
			this.textAuth = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
			this.checkBoxC = new System.Windows.Forms.CheckBox();
			this.checkBoxA = new System.Windows.Forms.CheckBox();
			this.checkBoxSC = new System.Windows.Forms.CheckBox();
			this.checkBoxRC = new System.Windows.Forms.CheckBox();
			this.checkAdd = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkDY
			// 
			this.checkDY.AutoSize = true;
			this.checkDY.Location = new System.Drawing.Point(191, 25);
			this.checkDY.Name = "checkDY";
			this.checkDY.Size = new System.Drawing.Size(41, 17);
			this.checkDY.TabIndex = 22;
			this.checkDY.Text = "DY";
			this.checkDY.UseVisualStyleBackColor = true;
			this.checkDY.CheckedChanged += new System.EventHandler(this.CheckDyCheckedChanged);
			// 
			// checkTC
			// 
			this.checkTC.AutoSize = true;
			this.checkTC.Location = new System.Drawing.Point(145, 25);
			this.checkTC.Name = "checkTC";
			this.checkTC.Size = new System.Drawing.Size(40, 17);
			this.checkTC.TabIndex = 21;
			this.checkTC.Text = "TC";
			this.checkTC.UseVisualStyleBackColor = true;
			this.checkTC.CheckedChanged += new System.EventHandler(this.CheckTcCheckedChanged);
			// 
			// checkPFC
			// 
			this.checkPFC.AutoSize = true;
			this.checkPFC.Location = new System.Drawing.Point(93, 25);
			this.checkPFC.Name = "checkPFC";
			this.checkPFC.Size = new System.Drawing.Size(46, 17);
			this.checkPFC.TabIndex = 20;
			this.checkPFC.Text = "PFC";
			this.checkPFC.UseVisualStyleBackColor = true;
			this.checkPFC.CheckedChanged += new System.EventHandler(this.CheckPfcCheckedChanged);
			// 
			// textAuth
			// 
			this.textAuth.Location = new System.Drawing.Point(46, 92);
			this.textAuth.Name = "textAuth";
			this.textAuth.Size = new System.Drawing.Size(225, 20);
			this.textAuth.TabIndex = 24;
			this.textAuth.Text = "01.04.2010";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 94);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 13);
			this.label5.TabIndex = 28;
			this.label5.Text = "Auth.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 27;
			this.label4.Text = "Date";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 26;
			this.label3.Text = "Check complete";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Release to Service";
			// 
			// dateTimePickerDate
			// 
			this.dateTimePickerDate.Location = new System.Drawing.Point(46, 63);
			this.dateTimePickerDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerDate.Name = "dateTimePickerDate";
			this.dateTimePickerDate.Size = new System.Drawing.Size(225, 20);
			this.dateTimePickerDate.TabIndex = 29;
			// 
			// checkBoxC
			// 
			this.checkBoxC.AutoSize = true;
			this.checkBoxC.Location = new System.Drawing.Point(238, 41);
			this.checkBoxC.Name = "checkBoxC";
			this.checkBoxC.Size = new System.Drawing.Size(33, 17);
			this.checkBoxC.TabIndex = 53;
			this.checkBoxC.Text = "C";
			this.checkBoxC.UseVisualStyleBackColor = true;
			// 
			// checkBoxA
			// 
			this.checkBoxA.AutoSize = true;
			this.checkBoxA.Location = new System.Drawing.Point(191, 41);
			this.checkBoxA.Name = "checkBoxA";
			this.checkBoxA.Size = new System.Drawing.Size(33, 17);
			this.checkBoxA.TabIndex = 52;
			this.checkBoxA.Text = "A";
			this.checkBoxA.UseVisualStyleBackColor = true;
			// 
			// checkBoxSC
			// 
			this.checkBoxSC.AutoSize = true;
			this.checkBoxSC.Location = new System.Drawing.Point(145, 41);
			this.checkBoxSC.Name = "checkBoxSC";
			this.checkBoxSC.Size = new System.Drawing.Size(40, 17);
			this.checkBoxSC.TabIndex = 51;
			this.checkBoxSC.Text = "SC";
			this.checkBoxSC.UseVisualStyleBackColor = true;
			// 
			// checkBoxRC
			// 
			this.checkBoxRC.AutoSize = true;
			this.checkBoxRC.Location = new System.Drawing.Point(93, 41);
			this.checkBoxRC.Name = "checkBoxRC";
			this.checkBoxRC.Size = new System.Drawing.Size(41, 17);
			this.checkBoxRC.TabIndex = 50;
			this.checkBoxRC.Text = "RC";
			this.checkBoxRC.UseVisualStyleBackColor = true;
			// 
			// checkAdd
			// 
			this.checkAdd.AutoSize = true;
			this.checkAdd.Location = new System.Drawing.Point(238, 25);
			this.checkAdd.Name = "checkAdd";
			this.checkAdd.Size = new System.Drawing.Size(49, 17);
			this.checkAdd.TabIndex = 54;
			this.checkAdd.Text = "ADD";
			this.checkAdd.UseVisualStyleBackColor = true;
			// 
			// ReleaseToServiceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkAdd);
			this.Controls.Add(this.checkBoxC);
			this.Controls.Add(this.checkBoxA);
			this.Controls.Add(this.checkBoxSC);
			this.Controls.Add(this.checkBoxRC);
			this.Controls.Add(this.dateTimePickerDate);
			this.Controls.Add(this.checkDY);
			this.Controls.Add(this.checkTC);
			this.Controls.Add(this.checkPFC);
			this.Controls.Add(this.textAuth);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ReleaseToServiceControl";
			this.Size = new System.Drawing.Size(284, 115);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkDY;
        private System.Windows.Forms.CheckBox checkTC;
        private System.Windows.Forms.CheckBox checkPFC;
        private System.Windows.Forms.TextBox textAuth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
		private System.Windows.Forms.CheckBox checkBoxC;
		private System.Windows.Forms.CheckBox checkBoxA;
		private System.Windows.Forms.CheckBox checkBoxSC;
		private System.Windows.Forms.CheckBox checkBoxRC;
		private System.Windows.Forms.CheckBox checkAdd;
	}
}
