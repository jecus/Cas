namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class AircraftInformationControl
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
            this.label22 = new System.Windows.Forms.Label();
            this.textModel = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textAircraft = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCompany = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 55;
            this.label22.Text = "Model";
            // 
            // textModel
            // 
            this.textModel.Location = new System.Drawing.Point(70, 92);
            this.textModel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textModel.MaximumSize = new System.Drawing.Size(200, 18);
            this.textModel.Name = "textModel";
            this.textModel.ReadOnly = true;
            this.textModel.Size = new System.Drawing.Size(137, 18);
            this.textModel.TabIndex = 2;
            this.textModel.Text = "Boeing 737-200";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 66);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 53;
            this.label21.Text = "Aircraft";
            // 
            // textAircraft
            // 
            this.textAircraft.Location = new System.Drawing.Point(70, 63);
            this.textAircraft.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textAircraft.MaximumSize = new System.Drawing.Size(200, 18);
            this.textAircraft.Name = "textAircraft";
            this.textAircraft.ReadOnly = true;
            this.textAircraft.Size = new System.Drawing.Size(137, 18);
            this.textAircraft.TabIndex = 1;
            this.textAircraft.Text = "YA-PIR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Company";
            // 
            // textCompany
            // 
            this.textCompany.Location = new System.Drawing.Point(70, 34);
            this.textCompany.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.textCompany.MaximumSize = new System.Drawing.Size(200, 18);
            this.textCompany.Name = "textCompany";
            this.textCompany.ReadOnly = true;
            this.textCompany.Size = new System.Drawing.Size(137, 18);
            this.textCompany.TabIndex = 0;
            this.textCompany.Text = "Pamir Airwais, PRI";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(3, 3);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 49;
            this.label20.Text = "Aircraft";
            // 
            // AircraftInformationControl
            // 
            this.Controls.Add(this.label22);
            this.Controls.Add(this.textModel);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textAircraft);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textCompany);
            this.Controls.Add(this.label20);
            this.Name = "AircraftInformationControl";
            this.Size = new System.Drawing.Size(211, 115);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textModel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textAircraft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCompany;
        private System.Windows.Forms.Label label20;
    }
}
