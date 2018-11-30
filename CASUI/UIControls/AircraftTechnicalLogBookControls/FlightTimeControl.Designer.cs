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
            this.textTakeOffLDG = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textOutIn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBlock
            // 
            this.textBlock.Location = new System.Drawing.Point(218, 34);
            this.textBlock.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textBlock.MaximumSize = new System.Drawing.Size(200, 18);
            this.textBlock.Name = "textBlock";
            this.textBlock.ReadOnly = true;
            this.textBlock.Size = new System.Drawing.Size(45, 18);
            this.textBlock.TabIndex = 34;
            this.textBlock.TabStop = false;
            this.textBlock.Text = "04:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(180, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Block";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(179, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Flight";
            // 
            // textFlight
            // 
            this.textFlight.Location = new System.Drawing.Point(218, 63);
            this.textFlight.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textFlight.MaximumSize = new System.Drawing.Size(200, 18);
            this.textFlight.Name = "textFlight";
            this.textFlight.ReadOnly = true;
            this.textFlight.Size = new System.Drawing.Size(45, 18);
            this.textFlight.TabIndex = 31;
            this.textFlight.TabStop = false;
            this.textFlight.Text = "03:40";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Take-off - LDG";
            // 
            // textTakeOffLDG
            // 
            this.textTakeOffLDG.Location = new System.Drawing.Point(86, 63);
            this.textTakeOffLDG.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textTakeOffLDG.MaximumSize = new System.Drawing.Size(200, 18);
            this.textTakeOffLDG.Name = "textTakeOffLDG";
            this.textTakeOffLDG.Size = new System.Drawing.Size(88, 18);
            this.textTakeOffLDG.TabIndex = 29;
            this.textTakeOffLDG.Text = "18:55 - 22:35";
            this.textTakeOffLDG.Leave += new System.EventHandler(this.textTakeOffLDG_Leave);
            this.textTakeOffLDG.TextChanged += new System.EventHandler(this.textTakeOffLDG_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Out - In";
            // 
            // textOutIn
            // 
            this.textOutIn.Location = new System.Drawing.Point(86, 34);
            this.textOutIn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textOutIn.MaximumSize = new System.Drawing.Size(200, 18);
            this.textOutIn.Name = "textOutIn";
            this.textOutIn.Size = new System.Drawing.Size(88, 18);
            this.textOutIn.TabIndex = 27;
            this.textOutIn.Text = "18:45 - 22:45";
            this.textOutIn.Leave += new System.EventHandler(this.textOutIn_Leave);
            this.textOutIn.TextChanged += new System.EventHandler(this.textOutIn_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Block / Airborne Time";
            // 
            // FlightTimeControl
            // 
            this.Controls.Add(this.textBlock);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textFlight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textTakeOffLDG);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textOutIn);
            this.Controls.Add(this.label8);
            this.Name = "FlightTimeControl";
            this.Size = new System.Drawing.Size(268, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBlock;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textFlight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTakeOffLDG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textOutIn;
        private System.Windows.Forms.Label label8;
    }
}
