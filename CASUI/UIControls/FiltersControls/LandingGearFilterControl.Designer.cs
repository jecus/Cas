using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class LandingGearFilterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxGeneral = new System.Windows.Forms.CheckBox();
            this.checkBoxLeft = new System.Windows.Forms.CheckBox();
            this.checkBoxRigth = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxGeneral
            // 
            this.checkBoxGeneral.AutoSize = true;
            this.checkBoxGeneral.Checked = true;
            this.checkBoxGeneral.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBoxGeneral.Location = new System.Drawing.Point(28, 23);
            this.checkBoxGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxGeneral.Name = "checkBoxGeneral";
            this.checkBoxGeneral.Size = new System.Drawing.Size(63, 17);
            this.checkBoxGeneral.TabIndex = 3;
            this.checkBoxGeneral.Text = "General";
            this.checkBoxGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxLeft
            // 
            this.checkBoxLeft.AutoSize = true;
            this.checkBoxLeft.Checked = true;
            this.checkBoxLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBoxLeft.Location = new System.Drawing.Point(134, 23);
            this.checkBoxLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxLeft.Name = "checkBoxLeft";
            this.checkBoxLeft.Size = new System.Drawing.Size(44, 17);
            this.checkBoxLeft.TabIndex = 4;
            this.checkBoxLeft.Text = "Left";
            this.checkBoxLeft.UseVisualStyleBackColor = true;
            // 
            // checkBoxRigth
            // 
            this.checkBoxRigth.AutoSize = true;
            this.checkBoxRigth.Checked = true;
            this.checkBoxRigth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRigth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBoxRigth.Location = new System.Drawing.Point(228, 23);
            this.checkBoxRigth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxRigth.Name = "checkBoxRigth";
            this.checkBoxRigth.Size = new System.Drawing.Size(51, 17);
            this.checkBoxRigth.TabIndex = 5;
            this.checkBoxRigth.Text = "Right";
            this.checkBoxRigth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxGeneral);
            this.groupBox1.Controls.Add(this.checkBoxRigth);
            this.groupBox1.Controls.Add(this.checkBoxLeft);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 56);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Landing gear";
            // 
            // LandingGearFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LandingGearFilterControl";
            this.Size = new System.Drawing.Size(302, 56);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxGeneral;
        private System.Windows.Forms.CheckBox checkBoxLeft;
        private System.Windows.Forms.CheckBox checkBoxRigth;
        private System.Windows.Forms.GroupBox groupBox1;

        public void SetFilterParameters(IFilter filter)
        {
            
        }
    }
}