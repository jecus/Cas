using System.Windows.Forms;
using CAS.Core.ProjectTerms;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    partial class TemplateAddBaseDetailForm
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
            this.radioButtonEngine = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radioButtonAPU = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonEngine
            // 
            this.radioButtonEngine.AutoSize = true;
            this.radioButtonEngine.Checked = true;
            this.radioButtonEngine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonEngine.Location = new System.Drawing.Point(85, 57);
            this.radioButtonEngine.Name = "radioButtonEngine";
            this.radioButtonEngine.Size = new System.Drawing.Size(57, 17);
            this.radioButtonEngine.TabIndex = 1;
            this.radioButtonEngine.TabStop = true;
            this.radioButtonEngine.Text = "Engine";
            this.radioButtonEngine.UseVisualStyleBackColor = true;
            this.radioButtonEngine.CheckedChanged += new System.EventHandler(this.radioButtonEngine_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(85, 124);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 34);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(195, 124);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 34);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // radioButtonAPU
            // 
            this.radioButtonAPU.AutoSize = true;
            this.radioButtonAPU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonAPU.Location = new System.Drawing.Point(85, 83);
            this.radioButtonAPU.Name = "radioButtonAPU";
            this.radioButtonAPU.Size = new System.Drawing.Size(46, 17);
            this.radioButtonAPU.TabIndex = 6;
            this.radioButtonAPU.Text = "APU";
            this.radioButtonAPU.UseVisualStyleBackColor = true;
            this.radioButtonAPU.CheckedChanged += new System.EventHandler(this.radioButtonAPU_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CAS.UI.Properties.Resources.GrayArrow;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(47, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(108, 13);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "Add base component";
            // 
            // TemplateAddBaseDetailForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(375, 183);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.radioButtonAPU);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonEngine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TemplateAddBaseDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAS. Add base component";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonEngine;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private RadioButton radioButtonAPU;
        private PictureBox pictureBox1;
        private Label labelTitle;
    }
}