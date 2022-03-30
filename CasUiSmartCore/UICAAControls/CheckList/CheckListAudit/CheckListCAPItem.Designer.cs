using System.ComponentModel;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    partial class CheckListCAPItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.Label labelStatus;
            System.Windows.Forms.Label label1label1;
            this.ButtonWf = new AvControls.AvButtonT.AvButtonT();
            this.avButtonT1 = new AvControls.AvButtonT.AvButtonT();
            this.metroTextBoxComment = new MetroFramework.Controls.MetroTextBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            labelStatus = new System.Windows.Forms.Label();
            label1label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonWf
            // 
            this.ButtonWf.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonWf.ActiveBackgroundImage = null;
            this.ButtonWf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonWf.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.ButtonWf.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.ButtonWf.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonWf.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonWf.Icon = global::CAS.UI.Properties.Resources.GreenArrow;
            this.ButtonWf.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonWf.IconNotEnabled = null;
            this.ButtonWf.Location = new System.Drawing.Point(39, 33);
            this.ButtonWf.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonWf.Name = "ButtonWf";
            this.ButtonWf.NormalBackgroundImage = null;
            this.ButtonWf.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonWf.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonWf.ShowToolTip = false;
            this.ButtonWf.Size = new System.Drawing.Size(169, 33);
            this.ButtonWf.TabIndex = 366;
            this.ButtonWf.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonWf.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonWf.TextMain = "Workflow Comments";
            this.ButtonWf.TextSecondary = "";
            this.ButtonWf.ToolTipText = "";
            this.ButtonWf.Click += new System.EventHandler(this.ButtonWf_Click);
            // 
            // avButtonT1
            // 
            this.avButtonT1.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonT1.ActiveBackgroundImage = null;
            this.avButtonT1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonT1.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.avButtonT1.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.avButtonT1.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.avButtonT1.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.avButtonT1.Icon = global::CAS.UI.Properties.Resources.GreenArrow;
            this.avButtonT1.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonT1.IconNotEnabled = null;
            this.avButtonT1.Location = new System.Drawing.Point(39, 74);
            this.avButtonT1.Margin = new System.Windows.Forms.Padding(4);
            this.avButtonT1.Name = "avButtonT1";
            this.avButtonT1.NormalBackgroundImage = null;
            this.avButtonT1.PaddingMain = new System.Windows.Forms.Padding(0);
            this.avButtonT1.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonT1.ShowToolTip = false;
            this.avButtonT1.Size = new System.Drawing.Size(169, 33);
            this.avButtonT1.TabIndex = 368;
            this.avButtonT1.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonT1.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonT1.TextMain = "Workflow Documents";
            this.avButtonT1.TextSecondary = "";
            this.avButtonT1.ToolTipText = "";
            // 
            // metroTextBoxComment
            // 
            // 
            // 
            // 
            this.metroTextBoxComment.CustomButton.Image = null;
            this.metroTextBoxComment.CustomButton.Location = new System.Drawing.Point(310, 2);
            this.metroTextBoxComment.CustomButton.Name = "";
            this.metroTextBoxComment.CustomButton.Size = new System.Drawing.Size(69, 69);
            this.metroTextBoxComment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxComment.CustomButton.TabIndex = 1;
            this.metroTextBoxComment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxComment.CustomButton.UseSelectable = true;
            this.metroTextBoxComment.CustomButton.Visible = false;
            this.metroTextBoxComment.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxComment.Lines = new string[0];
            this.metroTextBoxComment.Location = new System.Drawing.Point(203, 33);
            this.metroTextBoxComment.MaxLength = 32767;
            this.metroTextBoxComment.Multiline = true;
            this.metroTextBoxComment.Name = "metroTextBoxComment";
            this.metroTextBoxComment.PasswordChar = '\0';
            this.metroTextBoxComment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxComment.SelectedText = "";
            this.metroTextBoxComment.SelectionLength = 0;
            this.metroTextBoxComment.SelectionStart = 0;
            this.metroTextBoxComment.ShortcutsEnabled = true;
            this.metroTextBoxComment.Size = new System.Drawing.Size(382, 74);
            this.metroTextBoxComment.TabIndex = 369;
            this.metroTextBoxComment.UseSelectable = true;
            this.metroTextBoxComment.Visible = false;
            this.metroTextBoxComment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxComment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccept.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAccept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonAccept.Location = new System.Drawing.Point(97, 113);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(100, 33);
            this.buttonAccept.TabIndex = 370;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReject.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonReject.Location = new System.Drawing.Point(203, 113);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(100, 33);
            this.buttonReject.TabIndex = 371;
            this.buttonReject.Text = "Reject";
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new System.Drawing.Font("Verdana", 9F);
            labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            labelStatus.Location = new System.Drawing.Point(3, 15);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new System.Drawing.Size(106, 14);
            labelStatus.TabIndex = 367;
            labelStatus.Text = "Workflow Stage";
            labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1label1
            // 
            label1label1.AutoSize = true;
            label1label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1label1.Location = new System.Drawing.Point(203, 15);
            label1label1.Name = "label1label1";
            label1label1.Size = new System.Drawing.Size(119, 14);
            label1label1.TabIndex = 372;
            label1label1.Text = "Final Action Taken";
            label1label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckListCAPItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(label1label1);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.metroTextBoxComment);
            this.Controls.Add(this.avButtonT1);
            this.Controls.Add(labelStatus);
            this.Controls.Add(this.ButtonWf);
            this.Name = "CheckListCAPItem";
            this.Size = new System.Drawing.Size(588, 149);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        System.Windows.Forms.Label labelStatus;
        System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox metroTextBoxComment;

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonReject;

        private AvControls.AvButtonT.AvButtonT avButtonT1;

        private AvControls.AvButtonT.AvButtonT ButtonWf;

        #endregion
    }
}