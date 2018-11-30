namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightGeneralInformationControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.textFlightNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flight General Information";
            // 
            // textFlightNo
            // 
            this.textFlightNo.Location = new System.Drawing.Point(70, 34);
            this.textFlightNo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textFlightNo.MaximumSize = new System.Drawing.Size(200, 18);
            this.textFlightNo.Name = "textFlightNo";
            this.textFlightNo.Size = new System.Drawing.Size(137, 18);
            this.textFlightNo.TabIndex = 3;
            this.textFlightNo.Text = "1258";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Flight No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date";
            // 
            // textDate
            // 
            this.textDate.Location = new System.Drawing.Point(70, 63);
            this.textDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textDate.MaximumSize = new System.Drawing.Size(200, 18);
            this.textDate.Name = "textDate";
            this.textDate.Size = new System.Drawing.Size(137, 18);
            this.textDate.TabIndex = 5;
            this.textDate.Text = "01.04.2010";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Station";
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(102, 92);
            this.textFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textFrom.MaximumSize = new System.Drawing.Size(200, 18);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(38, 18);
            this.textFrom.TabIndex = 8;
            this.textFrom.Text = "FRU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "from";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "to";
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(169, 92);
            this.textTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textTo.MaximumSize = new System.Drawing.Size(200, 18);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(38, 18);
            this.textTo.TabIndex = 12;
            this.textTo.Text = "MSK";
            // 
            // FlightGeneralInformationControl
            // 
            this.Controls.Add(this.textTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFlightNo);
            this.Controls.Add(this.label1);
            this.Name = "FlightGeneralInformationControl";
            this.Size = new System.Drawing.Size(212, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFlightNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textTo;

    }
}
