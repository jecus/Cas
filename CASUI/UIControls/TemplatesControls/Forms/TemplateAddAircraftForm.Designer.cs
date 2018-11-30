using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    partial class TemplateAddAircraftForm
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
            this.radioButtonWestAircraft = new System.Windows.Forms.RadioButton();
            this.radioButtonSovietAircraft = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelModel = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonWestAircraft
            // 
            this.radioButtonWestAircraft.Checked = true;
            this.radioButtonWestAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonWestAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.radioButtonWestAircraft.Location = new System.Drawing.Point(104, 98);
            this.radioButtonWestAircraft.Name = "radioButtonWestAircraft";
            this.radioButtonWestAircraft.Size = new System.Drawing.Size(100, 27);
            this.radioButtonWestAircraft.TabIndex = 0;
            this.radioButtonWestAircraft.TabStop = true;
            this.radioButtonWestAircraft.Text = "West Aircraft";
            this.radioButtonWestAircraft.UseVisualStyleBackColor = true;
            // 
            // radioButtonSovietAircraft
            // 
            this.radioButtonSovietAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioButtonSovietAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.radioButtonSovietAircraft.Location = new System.Drawing.Point(210, 98);
            this.radioButtonSovietAircraft.Name = "radioButtonSovietAircraft";
            this.radioButtonSovietAircraft.Size = new System.Drawing.Size(100, 27);
            this.radioButtonSovietAircraft.TabIndex = 1;
            this.radioButtonSovietAircraft.Text = "Soviet Aircraft";
            this.radioButtonSovietAircraft.UseVisualStyleBackColor = true;
            this.radioButtonSovietAircraft.CheckedChanged += new System.EventHandler(this.radioButtonSovietAircraft_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOK.Location = new System.Drawing.Point(75, 141);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(115, 34);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "Create";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(210, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(115, 34);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.labelModel.Location = new System.Drawing.Point(34, 66);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(82, 13);
            this.labelModel.TabIndex = 4;
            this.labelModel.Text = "Template model";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(172, 63);
            this.textBoxModel.MaxLength = 40;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(200, 20);
            this.textBoxModel.TabIndex = 5;
            this.textBoxModel.Text = "New Aircraft";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CAS.UI.Properties.Resources.GrayArrow;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.labelHeader.Location = new System.Drawing.Point(52, 10);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(76, 13);
            this.labelHeader.TabIndex = 7;
            this.labelHeader.Text = "New Template";
            // 
            // TemplateAddAircraftForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(394, 187);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.radioButtonSovietAircraft);
            this.Controls.Add(this.radioButtonWestAircraft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateAddAircraftForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new aircraft template";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonWestAircraft;
        private System.Windows.Forms.RadioButton radioButtonSovietAircraft;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.TextBox textBoxModel;
        private PictureBox pictureBox1;
        private Label labelHeader;
    }
}