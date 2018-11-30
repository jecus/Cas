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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightFluidsControl));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textOnBoard = new System.Windows.Forms.TextBox();
            this.textAdded = new System.Windows.Forms.TextBox();
            this.checkDeIce = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textTimePeriod = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFluidType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAEACode = new System.Windows.Forms.TextBox();
            this.delimiter5 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "On Board";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Added";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hydraulic Fluid";
            // 
            // textOnBoard
            // 
            this.textOnBoard.Location = new System.Drawing.Point(61, 63);
            this.textOnBoard.Margin = new System.Windows.Forms.Padding(3, 3, 15, 8);
            this.textOnBoard.MaximumSize = new System.Drawing.Size(200, 18);
            this.textOnBoard.Name = "textOnBoard";
            this.textOnBoard.Size = new System.Drawing.Size(56, 18);
            this.textOnBoard.TabIndex = 1;
            // 
            // textAdded
            // 
            this.textAdded.Location = new System.Drawing.Point(61, 34);
            this.textAdded.Margin = new System.Windows.Forms.Padding(3, 3, 15, 8);
            this.textAdded.MaximumSize = new System.Drawing.Size(200, 18);
            this.textAdded.Name = "textAdded";
            this.textAdded.Size = new System.Drawing.Size(56, 18);
            this.textAdded.TabIndex = 0;
            // 
            // checkDeIce
            // 
            this.checkDeIce.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.checkDeIce.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkDeIce.Location = new System.Drawing.Point(165, 2);
            this.checkDeIce.Name = "checkDeIce";
            this.checkDeIce.Size = new System.Drawing.Size(124, 16);
            this.checkDeIce.TabIndex = 2;
            this.checkDeIce.Text = "Ground De Ice";
            this.checkDeIce.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(166, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Time";
            // 
            // textTimePeriod
            // 
            this.textTimePeriod.Location = new System.Drawing.Point(201, 34);
            this.textTimePeriod.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textTimePeriod.MaximumSize = new System.Drawing.Size(200, 18);
            this.textTimePeriod.Name = "textTimePeriod";
            this.textTimePeriod.Size = new System.Drawing.Size(88, 18);
            this.textTimePeriod.TabIndex = 3;
            this.textTimePeriod.Text = "18:45 - 22:45";
            this.textTimePeriod.Leave += new System.EventHandler(this.textTimePeriod_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Fluid Type";
            // 
            // textFluidType
            // 
            this.textFluidType.Location = new System.Drawing.Point(228, 63);
            this.textFluidType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textFluidType.MaximumSize = new System.Drawing.Size(200, 18);
            this.textFluidType.Name = "textFluidType";
            this.textFluidType.Size = new System.Drawing.Size(61, 18);
            this.textFluidType.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "AEA Code";
            // 
            // textAEACode
            // 
            this.textAEACode.Location = new System.Drawing.Point(228, 92);
            this.textAEACode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textAEACode.MaximumSize = new System.Drawing.Size(200, 18);
            this.textAEACode.Name = "textAEACode";
            this.textAEACode.Size = new System.Drawing.Size(61, 18);
            this.textAEACode.TabIndex = 5;
            // 
            // delimiter5
            // 
            this.delimiter5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter5.BackgroundImage")));
            this.delimiter5.Location = new System.Drawing.Point(143, 34);
            this.delimiter5.Margin = new System.Windows.Forms.Padding(15);
            this.delimiter5.Name = "delimiter5";
            this.delimiter5.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter5.Size = new System.Drawing.Size(1, 74);
            this.delimiter5.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter5.TabIndex = 63;
            // 
            // FlightFluidsControl
            // 
            this.Controls.Add(this.delimiter5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textAEACode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textFluidType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textTimePeriod);
            this.Controls.Add(this.checkDeIce);
            this.Controls.Add(this.textOnBoard);
            this.Controls.Add(this.textAdded);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FlightFluidsControl";
            this.Size = new System.Drawing.Size(293, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textOnBoard;
        private System.Windows.Forms.TextBox textAdded;
        private System.Windows.Forms.CheckBox checkDeIce;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textTimePeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFluidType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAEACode;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter5;
    }
}
