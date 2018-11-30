namespace CAS.UI.UIControls.FiltersControls
{
    partial class MaintenanceFilterControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxConditionMonitoring = new System.Windows.Forms.CheckBox();
            this.checkBoxOnCondition = new System.Windows.Forms.CheckBox();
            this.checkBoxHardTime = new System.Windows.Forms.CheckBox();
            this.checkBoxUnknown = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUnknown);
            this.groupBox1.Controls.Add(this.checkBoxHardTime);
            this.groupBox1.Controls.Add(this.checkBoxOnCondition);
            this.groupBox1.Controls.Add(this.checkBoxConditionMonitoring);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 49);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maintenance frequency";
            // 
            // checkBoxConditionMonitoring
            // 
            this.checkBoxConditionMonitoring.AutoSize = true;
            this.checkBoxConditionMonitoring.Checked = true;
            this.checkBoxConditionMonitoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConditionMonitoring.Location = new System.Drawing.Point(18, 22);
            this.checkBoxConditionMonitoring.Name = "checkBoxConditionMonitoring";
            this.checkBoxConditionMonitoring.Size = new System.Drawing.Size(45, 20);
            this.checkBoxConditionMonitoring.TabIndex = 0;
            this.checkBoxConditionMonitoring.Text = "CM";
            this.checkBoxConditionMonitoring.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnCondition
            // 
            this.checkBoxOnCondition.AutoSize = true;
            this.checkBoxOnCondition.Checked = true;
            this.checkBoxOnCondition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnCondition.Location = new System.Drawing.Point(167, 22);
            this.checkBoxOnCondition.Name = "checkBoxOnCondition";
            this.checkBoxOnCondition.Size = new System.Drawing.Size(44, 20);
            this.checkBoxOnCondition.TabIndex = 1;
            this.checkBoxOnCondition.Text = "OC";
            this.checkBoxOnCondition.UseVisualStyleBackColor = true;
            // 
            // checkBoxHardTime
            // 
            this.checkBoxHardTime.AutoSize = true;
            this.checkBoxHardTime.Checked = true;
            this.checkBoxHardTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHardTime.Location = new System.Drawing.Point(96, 22);
            this.checkBoxHardTime.Name = "checkBoxHardTime";
            this.checkBoxHardTime.Size = new System.Drawing.Size(43, 20);
            this.checkBoxHardTime.TabIndex = 2;
            this.checkBoxHardTime.Text = "HT";
            this.checkBoxHardTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnknown
            // 
            this.checkBoxUnknown.AutoSize = true;
            this.checkBoxUnknown.Checked = true;
            this.checkBoxUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnknown.Location = new System.Drawing.Point(246, 22);
            this.checkBoxUnknown.Name = "checkBoxUnknown";
            this.checkBoxUnknown.Size = new System.Drawing.Size(48, 20);
            this.checkBoxUnknown.TabIndex = 3;
            this.checkBoxUnknown.Text = "Unk";
            this.checkBoxUnknown.UseVisualStyleBackColor = true;
            // 
            // MaintananceFilterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "MaintananceFilterControl";
            this.Size = new System.Drawing.Size(355, 49);
            this.Load += new System.EventHandler(this.MaintananceFilterControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUnknown;
        private System.Windows.Forms.CheckBox checkBoxHardTime;
        private System.Windows.Forms.CheckBox checkBoxOnCondition;
        private System.Windows.Forms.CheckBox checkBoxConditionMonitoring;


    }
}