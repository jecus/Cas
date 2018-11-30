using CAS.Core.ProjectTerms;
using CAS.UI.UIControls.FiltersControls;
using DirectiveOpenessFilterControl=CAS.UI.UIControls.FiltersControls.DirectiveOpenessFilterControl;
using DirectiveTitleFilterControl=CAS.UI.UIControls.FiltersControls.DirectiveTitleFilterControl;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class DirectiveFilterSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectiveFilterSelectionForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonReloadAsDateOf = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.checkBoxDateAsOf = new System.Windows.Forms.CheckBox();
            this.abstractDirectiveTitleFilterControl1 = new CAS.UI.UIControls.FiltersControls.DirectiveTitleFilterControl();
            this.abstractDirectiveDescriptionFilterControl2 = new CAS.UI.UIControls.FiltersControls.DirectiveDescriptionFilterControl();
            this.directiveConditionFilterControl1 = new CAS.UI.UIControls.FiltersControls.DirectiveConditionFilterControl();
            this.directiveOpenessFilterControl1 = new CAS.UI.UIControls.FiltersControls.DirectiveOpenessFilterControl();
            this.checkBoxAF = new System.Windows.Forms.CheckBox();
            this.checkBoxAP = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(350, 277);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(105, 37);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApply.Location = new System.Drawing.Point(239, 277);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(105, 37);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "Apply Filter";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonReloadAsDateOf
            // 
            this.buttonReloadAsDateOf.Location = new System.Drawing.Point(381, 51);
            this.buttonReloadAsDateOf.Name = "buttonReloadAsDateOf";
            this.buttonReloadAsDateOf.Size = new System.Drawing.Size(0, 0);
            this.buttonReloadAsDateOf.TabIndex = 29;
            this.buttonReloadAsDateOf.Text = "...";
            this.buttonReloadAsDateOf.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(202, 51);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(242, 23);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(12, 277);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(105, 37);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 56;
            this.label8.Text = "Directive Filter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFilter.Location = new System.Drawing.Point(128, 277);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(105, 37);
            this.buttonClearFilter.TabIndex = 6;
            this.buttonClearFilter.Text = "Clear Filter";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // checkBoxDateAsOf
            // 
            this.checkBoxDateAsOf.AutoSize = true;
            this.checkBoxDateAsOf.Location = new System.Drawing.Point(65, 53);
            this.checkBoxDateAsOf.Name = "checkBoxDateAsOf";
            this.checkBoxDateAsOf.Size = new System.Drawing.Size(85, 20);
            this.checkBoxDateAsOf.TabIndex = 57;
            this.checkBoxDateAsOf.Text = "Date as of";
            this.checkBoxDateAsOf.UseVisualStyleBackColor = true;
            // 
            // abstractDirectiveTitleFilterControl1
            // 
            this.abstractDirectiveTitleFilterControl1.AutoSize = true;
            this.abstractDirectiveTitleFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abstractDirectiveTitleFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.abstractDirectiveTitleFilterControl1.FilterAppliance = true;
            this.abstractDirectiveTitleFilterControl1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.abstractDirectiveTitleFilterControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.abstractDirectiveTitleFilterControl1.Location = new System.Drawing.Point(65, 80);
            this.abstractDirectiveTitleFilterControl1.Mask = "*";
            this.abstractDirectiveTitleFilterControl1.Name = "abstractDirectiveTitleFilterControl1";
            this.abstractDirectiveTitleFilterControl1.SerialFilterAppliance = true;
            this.abstractDirectiveTitleFilterControl1.Size = new System.Drawing.Size(382, 32);
            this.abstractDirectiveTitleFilterControl1.TabIndex = 2;
            // 
            // abstractDirectiveDescriptionFilterControl2
            // 
            this.abstractDirectiveDescriptionFilterControl2.AutoSize = true;
            this.abstractDirectiveDescriptionFilterControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.abstractDirectiveDescriptionFilterControl2.BackColor = System.Drawing.Color.Transparent;
            this.abstractDirectiveDescriptionFilterControl2.FilterAppliance = true;
            this.abstractDirectiveDescriptionFilterControl2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.abstractDirectiveDescriptionFilterControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.abstractDirectiveDescriptionFilterControl2.Location = new System.Drawing.Point(65, 80);
            this.abstractDirectiveDescriptionFilterControl2.Mask = "*";
            this.abstractDirectiveDescriptionFilterControl2.Name = "abstractDirectiveDescriptionFilterControl2";
            this.abstractDirectiveDescriptionFilterControl2.SerialFilterAppliance = true;
            this.abstractDirectiveDescriptionFilterControl2.Size = new System.Drawing.Size(382, 32);
            this.abstractDirectiveDescriptionFilterControl2.TabIndex = 2;
            this.abstractDirectiveDescriptionFilterControl2.Visible = false;
            // 
            // directiveConditionFilterControl1
            // 
            this.directiveConditionFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.directiveConditionFilterControl1.FilterAppliance = false;
            this.directiveConditionFilterControl1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.directiveConditionFilterControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.directiveConditionFilterControl1.Location = new System.Drawing.Point(12, 148);
            this.directiveConditionFilterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.directiveConditionFilterControl1.Name = "directiveConditionFilterControl1";
            this.directiveConditionFilterControl1.NotificationAppliance = true;
            this.directiveConditionFilterControl1.SatisfactoryAppliance = true;
            this.directiveConditionFilterControl1.Size = new System.Drawing.Size(443, 57);
            this.directiveConditionFilterControl1.TabIndex = 3;
            this.directiveConditionFilterControl1.UnsatisfactoryAppliance = true;
            // 
            // directiveOpenessFilterControl1
            // 
            this.directiveOpenessFilterControl1.AutoSize = true;
            this.directiveOpenessFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.directiveOpenessFilterControl1.ClosedAppliance = true;
            this.directiveOpenessFilterControl1.FilterAppliance = false;
            this.directiveOpenessFilterControl1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.directiveOpenessFilterControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.directiveOpenessFilterControl1.Location = new System.Drawing.Point(12, 212);
            this.directiveOpenessFilterControl1.Name = "directiveOpenessFilterControl1";
            this.directiveOpenessFilterControl1.OpenAppliance = true;
            this.directiveOpenessFilterControl1.RepeatableAppliance = true;
            this.directiveOpenessFilterControl1.Size = new System.Drawing.Size(443, 54);
            this.directiveOpenessFilterControl1.TabIndex = 4;
            // 
            // checkBoxAF
            // 
            this.checkBoxAF.AutoSize = true;
            this.checkBoxAF.Checked = true;
            this.checkBoxAF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAF.Location = new System.Drawing.Point(65, 122);
            this.checkBoxAF.Name = "checkBoxAF";
            this.checkBoxAF.Size = new System.Drawing.Size(42, 20);
            this.checkBoxAF.TabIndex = 58;
            this.checkBoxAF.Text = "AF";
            this.checkBoxAF.UseVisualStyleBackColor = true;
            this.checkBoxAF.Visible = false;
            this.checkBoxAF.CheckedChanged += new System.EventHandler(checkBoxAF_CheckedChanged);
            // 
            // checkBoxAP
            // 
            this.checkBoxAP.AutoSize = true;
            this.checkBoxAP.Checked = true;
            this.checkBoxAP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAP.Location = new System.Drawing.Point(128, 122);
            this.checkBoxAP.Name = "checkBoxAP";
            this.checkBoxAP.Size = new System.Drawing.Size(42, 20);
            this.checkBoxAP.TabIndex = 59;
            this.checkBoxAP.Text = "AP";
            this.checkBoxAP.UseVisualStyleBackColor = true;
            this.checkBoxAP.Visible = false;
            this.checkBoxAP.CheckedChanged += new System.EventHandler(checkBoxAP_CheckedChanged);
            // 
            // DirectiveFilterSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 328);
            this.Controls.Add(this.checkBoxAP);
            this.Controls.Add(this.checkBoxAF);
            this.Controls.Add(this.checkBoxDateAsOf);
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.abstractDirectiveTitleFilterControl1);
            this.Controls.Add(this.abstractDirectiveDescriptionFilterControl2);
            this.Controls.Add(this.directiveConditionFilterControl1);
            this.Controls.Add(this.directiveOpenessFilterControl1);
            this.Controls.Add(this.buttonReloadAsDateOf);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "DirectiveFilterSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectiveFilterSelectionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonReloadAsDateOf;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DirectiveOpenessFilterControl directiveOpenessFilterControl1;
        private DirectiveConditionFilterControl directiveConditionFilterControl1;
        private DirectiveTitleFilterControl abstractDirectiveTitleFilterControl1;
        private DirectiveDescriptionFilterControl abstractDirectiveDescriptionFilterControl2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.CheckBox checkBoxDateAsOf;
        private System.Windows.Forms.CheckBox checkBoxAF;
        private System.Windows.Forms.CheckBox checkBoxAP;
    }
}