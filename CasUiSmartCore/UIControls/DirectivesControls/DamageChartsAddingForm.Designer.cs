namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DamageChartsAddingForm
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
            this.textBoxChartName = new System.Windows.Forms.TextBox();
            this.labelChartName = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.fileControlDamageFile = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.labelChartFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxChartName
            // 
            this.textBoxChartName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxChartName.Location = new System.Drawing.Point(150, 9);
            this.textBoxChartName.MaxLength = 256;
            this.textBoxChartName.Name = "textBoxChartName";
            this.textBoxChartName.Size = new System.Drawing.Size(362, 25);
            this.textBoxChartName.TabIndex = 24;
            // 
            // labelChartName
            // 
            this.labelChartName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelChartName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelChartName.Location = new System.Drawing.Point(6, 9);
            this.labelChartName.Name = "labelChartName";
            this.labelChartName.Size = new System.Drawing.Size(138, 25);
            this.labelChartName.TabIndex = 25;
            this.labelChartName.Text = "Chart name:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(250, 125);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 26;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(342, 125);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // fileControlDamageFile
            // 
            this.fileControlDamageFile.AttachedFile = null;
            this.fileControlDamageFile.AutoSize = true;
            this.fileControlDamageFile.BackColor = System.Drawing.Color.Transparent;
            this.fileControlDamageFile.Description1 = null;
            this.fileControlDamageFile.Description2 = null;
            this.fileControlDamageFile.Filter = null;
            this.fileControlDamageFile.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControlDamageFile.Location = new System.Drawing.Point(150, 41);
            this.fileControlDamageFile.MaximumSize = new System.Drawing.Size(350, 75);
            this.fileControlDamageFile.MinimumSize = new System.Drawing.Size(350, 75);
            this.fileControlDamageFile.Name = "fileControlDamageFile";
            this.fileControlDamageFile.Size = new System.Drawing.Size(350, 75);
            this.fileControlDamageFile.TabIndex = 28;
            // 
            // labelChartFile
            // 
            this.labelChartFile.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelChartFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelChartFile.Location = new System.Drawing.Point(6, 41);
            this.labelChartFile.Name = "labelChartFile";
            this.labelChartFile.Size = new System.Drawing.Size(138, 25);
            this.labelChartFile.TabIndex = 29;
            this.labelChartFile.Text = "File:";
            // 
            // DamageChartsAddingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(526, 156);
            this.Controls.Add(this.labelChartFile);
            this.Controls.Add(this.fileControlDamageFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelChartName);
            this.Controls.Add(this.textBoxChartName);
            this.Name = "DamageChartsAddingForm";
            this.ShowIcon = false;
            this.Text = " Add damage chart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxChartName;
        private System.Windows.Forms.Label labelChartName;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private Auxiliary.AttachedFileControl fileControlDamageFile;
        private System.Windows.Forms.Label labelChartFile;

    }
}