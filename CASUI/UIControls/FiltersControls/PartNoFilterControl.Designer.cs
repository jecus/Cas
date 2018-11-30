namespace CAS.UI.UIControls.FiltersControls
{
    partial class PartNoFilterControl
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
            this.textBoxSerialMask = new System.Windows.Forms.TextBox();
            this.checkBoxSerialFilterAppliance = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxSerialMask
            // 
            this.textBoxSerialMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                  | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSerialMask.Location = new System.Drawing.Point(145, 0);
            this.textBoxSerialMask.MaxLength = 30;
            this.textBoxSerialMask.Name = "textBoxSerialMask";
            this.textBoxSerialMask.ReadOnly = true;
            this.textBoxSerialMask.Size = new System.Drawing.Size(168, 23);
            this.textBoxSerialMask.TabIndex = 20;
            this.textBoxSerialMask.TextChanged += new System.EventHandler(this.textBoxSerialMask_TextChanged);
            // 
            // checkBoxSerialFilterAppliance
            // 
            this.checkBoxSerialFilterAppliance.AutoSize = true;
            this.checkBoxSerialFilterAppliance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSerialFilterAppliance.Location = new System.Drawing.Point(0, 2);
            this.checkBoxSerialFilterAppliance.Name = "checkBoxSerialFilterAppliance";
            this.checkBoxSerialFilterAppliance.Size = new System.Drawing.Size(79, 20);
            this.checkBoxSerialFilterAppliance.TabIndex = 19;
            this.checkBoxSerialFilterAppliance.Text = "Part No.";
            this.checkBoxSerialFilterAppliance.UseVisualStyleBackColor = true;
            this.checkBoxSerialFilterAppliance.CheckedChanged += new System.EventHandler(this.checkBoxSerialFilterAppliance_CheckedChanged);
            // 
            // PartNoFilterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.textBoxSerialMask);
            this.Controls.Add(this.checkBoxSerialFilterAppliance);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "PartNoFilterControl";
            this.Size = new System.Drawing.Size(313, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSerialMask;
        private System.Windows.Forms.CheckBox checkBoxSerialFilterAppliance;
    }
}