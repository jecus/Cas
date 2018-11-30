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
            this.textDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkDY
            // 
            this.checkDY.AutoSize = true;
            this.checkDY.Location = new System.Drawing.Point(191, 36);
            this.checkDY.Name = "checkDY";
            this.checkDY.Size = new System.Drawing.Size(39, 17);
            this.checkDY.TabIndex = 22;
            this.checkDY.Text = "DY";
            this.checkDY.UseVisualStyleBackColor = true;
            this.checkDY.CheckedChanged += new System.EventHandler(this.checkDY_CheckedChanged);
            // 
            // checkTC
            // 
            this.checkTC.AutoSize = true;
            this.checkTC.Location = new System.Drawing.Point(145, 36);
            this.checkTC.Name = "checkTC";
            this.checkTC.Size = new System.Drawing.Size(39, 17);
            this.checkTC.TabIndex = 21;
            this.checkTC.Text = "TC";
            this.checkTC.UseVisualStyleBackColor = true;
            this.checkTC.CheckedChanged += new System.EventHandler(this.checkTC_CheckedChanged);
            // 
            // checkPFC
            // 
            this.checkPFC.AutoSize = true;
            this.checkPFC.Location = new System.Drawing.Point(93, 36);
            this.checkPFC.Name = "checkPFC";
            this.checkPFC.Size = new System.Drawing.Size(45, 17);
            this.checkPFC.TabIndex = 20;
            this.checkPFC.Text = "PFC";
            this.checkPFC.UseVisualStyleBackColor = true;
            this.checkPFC.CheckedChanged += new System.EventHandler(this.checkPFC_CheckedChanged);
            // 
            // textAuth
            // 
            this.textAuth.Location = new System.Drawing.Point(162, 63);
            this.textAuth.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textAuth.MaximumSize = new System.Drawing.Size(200, 18);
            this.textAuth.Name = "textAuth";
            this.textAuth.Size = new System.Drawing.Size(67, 18);
            this.textAuth.TabIndex = 24;
            this.textAuth.Text = "01.04.2010";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Auth.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Date";
            // 
            // textDate
            // 
            this.textDate.Location = new System.Drawing.Point(39, 63);
            this.textDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textDate.MaximumSize = new System.Drawing.Size(200, 18);
            this.textDate.Name = "textDate";
            this.textDate.Size = new System.Drawing.Size(67, 18);
            this.textDate.TabIndex = 23;
            this.textDate.Text = "01.04.2010";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Check complete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Release to Service";
            // 
            // ReleaseToServiceControl
            // 
            this.Controls.Add(this.checkDY);
            this.Controls.Add(this.checkTC);
            this.Controls.Add(this.checkPFC);
            this.Controls.Add(this.textAuth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ReleaseToServiceControl";
            this.Size = new System.Drawing.Size(231, 84);
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
        private System.Windows.Forms.TextBox textDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
