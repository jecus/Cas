namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightFluidsControl
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
            this.checkDeIce = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textTimePeriod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFluidType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAEACode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkDeIce
            // 
            this.checkDeIce.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.checkDeIce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkDeIce.Location = new System.Drawing.Point(3, 3);
            this.checkDeIce.Name = "checkDeIce";
            this.checkDeIce.Size = new System.Drawing.Size(124, 16);
            this.checkDeIce.TabIndex = 2;
            this.checkDeIce.Text = "Ground De Ice";
            this.checkDeIce.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Time";
            // 
            // textTimePeriod
            // 
            this.textTimePeriod.Location = new System.Drawing.Point(39, 35);
            this.textTimePeriod.Name = "textTimePeriod";
            this.textTimePeriod.Size = new System.Drawing.Size(88, 20);
            this.textTimePeriod.TabIndex = 3;
            this.textTimePeriod.Text = "18:45 - 22:45";
            this.textTimePeriod.Leave += new System.EventHandler(this.TextTimePeriodLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Fluid Type";
            // 
            // textFluidType
            // 
            this.textFluidType.Location = new System.Drawing.Point(66, 64);
            this.textFluidType.Name = "textFluidType";
            this.textFluidType.Size = new System.Drawing.Size(61, 20);
            this.textFluidType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "AEA Code";
            // 
            // textAEACode
            // 
            this.textAEACode.Location = new System.Drawing.Point(66, 93);
            this.textAEACode.Name = "textAEACode";
            this.textAEACode.Size = new System.Drawing.Size(61, 20);
            this.textAEACode.TabIndex = 5;
            // 
            // FlightFluidsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textAEACode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFluidType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTimePeriod);
            this.Controls.Add(this.checkDeIce);
            this.Name = "FlightFluidsControl";
            this.Size = new System.Drawing.Size(133, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkDeIce;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textTimePeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFluidType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAEACode;
    }
}
