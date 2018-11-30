namespace CAS.UI.UIControls.FiltersControls
{
    partial class ConditionStatusControl
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
            this.checkBoxSatisfactoryAppliance = new System.Windows.Forms.CheckBox();
            this.checkBoxUnsatisfactoryAppliance = new System.Windows.Forms.CheckBox();
            this.checkBoxNotificationAppliance = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxSatisfactoryAppliance
            // 
            this.checkBoxSatisfactoryAppliance.AutoSize = true;
            this.checkBoxSatisfactoryAppliance.Checked = true;
            this.checkBoxSatisfactoryAppliance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSatisfactoryAppliance.Location = new System.Drawing.Point(17, 24);
            this.checkBoxSatisfactoryAppliance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxSatisfactoryAppliance.Name = "checkBoxSatisfactoryAppliance";
            this.checkBoxSatisfactoryAppliance.Size = new System.Drawing.Size(94, 20);
            this.checkBoxSatisfactoryAppliance.TabIndex = 0;
            this.checkBoxSatisfactoryAppliance.Text = "Satisfactory";
            this.checkBoxSatisfactoryAppliance.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnsatisfactoryAppliance
            // 
            this.checkBoxUnsatisfactoryAppliance.AutoSize = true;
            this.checkBoxUnsatisfactoryAppliance.Checked = true;
            this.checkBoxUnsatisfactoryAppliance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnsatisfactoryAppliance.Location = new System.Drawing.Point(117, 24);
            this.checkBoxUnsatisfactoryAppliance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxUnsatisfactoryAppliance.Name = "checkBoxUnsatisfactoryAppliance";
            this.checkBoxUnsatisfactoryAppliance.Size = new System.Drawing.Size(107, 20);
            this.checkBoxUnsatisfactoryAppliance.TabIndex = 1;
            this.checkBoxUnsatisfactoryAppliance.Text = "Unsatisfactory";
            this.checkBoxUnsatisfactoryAppliance.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotificationAppliance
            // 
            this.checkBoxNotificationAppliance.AutoSize = true;
            this.checkBoxNotificationAppliance.Checked = true;
            this.checkBoxNotificationAppliance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNotificationAppliance.Location = new System.Drawing.Point(230, 24);
            this.checkBoxNotificationAppliance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxNotificationAppliance.Name = "checkBoxNotificationAppliance";
            this.checkBoxNotificationAppliance.Size = new System.Drawing.Size(90, 20);
            this.checkBoxNotificationAppliance.TabIndex = 4;
            this.checkBoxNotificationAppliance.Text = "Notification";
            this.checkBoxNotificationAppliance.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxSatisfactoryAppliance);
            this.groupBox1.Controls.Add(this.checkBoxNotificationAppliance);
            this.groupBox1.Controls.Add(this.checkBoxUnsatisfactoryAppliance);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(350, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition Status";
            // 
            // ConditionStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConditionStatusControl";
            this.Size = new System.Drawing.Size(350, 58);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSatisfactoryAppliance;
        private System.Windows.Forms.CheckBox checkBoxUnsatisfactoryAppliance;
        private System.Windows.Forms.CheckBox checkBoxNotificationAppliance;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}