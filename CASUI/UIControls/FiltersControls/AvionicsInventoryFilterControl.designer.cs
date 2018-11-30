namespace CAS.UI.UIControls.FiltersControls
{
    partial class AvionicsInventoryFilterControl
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
            this.checkBoxOptional = new System.Windows.Forms.CheckBox();
            this.checkBoxRequired = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxOptional
            // 
            this.checkBoxOptional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxOptional.AutoSize = true;
            this.checkBoxOptional.Checked = true;
            this.checkBoxOptional.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOptional.Location = new System.Drawing.Point(198, 23);
            this.checkBoxOptional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxOptional.Name = "checkBoxOptional";
            this.checkBoxOptional.Size = new System.Drawing.Size(74, 20);
            this.checkBoxOptional.TabIndex = 8;
            this.checkBoxOptional.Text = "Optional";
            this.checkBoxOptional.UseVisualStyleBackColor = true;
            // 
            // checkBoxRequired
            // 
            this.checkBoxRequired.AutoSize = true;
            this.checkBoxRequired.Checked = true;
            this.checkBoxRequired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRequired.Location = new System.Drawing.Point(52, 23);
            this.checkBoxRequired.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxRequired.Name = "checkBoxRequired";
            this.checkBoxRequired.Size = new System.Drawing.Size(78, 20);
            this.checkBoxRequired.TabIndex = 7;
            this.checkBoxRequired.Text = "Required";
            this.checkBoxRequired.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRequired);
            this.groupBox1.Controls.Add(this.checkBoxOptional);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(320, 62);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Avionics inventory";
            // 
            // AvionicsInventoryFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AvionicsInventoryFilterControl";
            this.Size = new System.Drawing.Size(320, 62);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxOptional;
        private System.Windows.Forms.CheckBox checkBoxRequired;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}