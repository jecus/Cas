using System.Drawing;
using LTR.Core.ProjectTerms;

namespace LTR.UI.UIControls.Auxiliary
{
    partial class UICopyrightControlСовсемWide
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCopyrights = new System.Windows.Forms.Label();
            this.labelVersionInfo = new System.Windows.Forms.Label();
            this.linkLabelSupport = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.labelCopyrights, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVersionInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabelSupport, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // labelCopyrights
            // 
            this.labelCopyrights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyrights.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCopyrights.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCopyrights.Location = new System.Drawing.Point(300, 10);
            this.labelCopyrights.Name = "labelCopyrights";
            this.labelCopyrights.Size = new System.Drawing.Size(447, 20);
            this.labelCopyrights.TabIndex = 1;
            this.labelCopyrights.Text = (string)new StaticProjectTermsProvider()["Copyright"];
            this.labelCopyrights.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersionInfo
            // 
            this.labelVersionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersionInfo.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersionInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelVersionInfo.Location = new System.Drawing.Point(13, 10);
            this.labelVersionInfo.Name = "labelVersionInfo";
            this.labelVersionInfo.Size = new System.Drawing.Size(300, 20);
            this.labelVersionInfo.TabIndex = 0;
            this.labelVersionInfo.Text = (string) new StaticProjectTermsProvider()["SystemName"]
                                         + " v" + (string) new StaticProjectTermsProvider()["ProductVersion"];
            this.labelVersionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelSupport
            // 
            this.linkLabelSupport.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabelSupport.AutoEllipsis = true;
            this.linkLabelSupport.AutoSize = true;
            this.linkLabelSupport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelSupport.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelSupport.ForeColor = System.Drawing.Color.Transparent;
            this.linkLabelSupport.LinkColor = System.Drawing.Color.Black;
            this.linkLabelSupport.Location = new System.Drawing.Point(692, 10);
            this.linkLabelSupport.Name = "linkLabelSupport";
            this.linkLabelSupport.Size = new System.Drawing.Size(222, 20);
            this.linkLabelSupport.TabIndex = 2;
            this.linkLabelSupport.TabStop = true;
            this.linkLabelSupport.Text = (string)new StaticProjectTermsProvider()["ProductWebsite"];
            this.linkLabelSupport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelSupport.VisitedLinkColor = System.Drawing.Color.White;
            this.linkLabelSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSupport_LinkClicked);
            // 
            // UICopyrightControlСовсемWide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UICopyrightControlСовсемWide";
            this.Size = new System.Drawing.Size(927, 40);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCopyrights;
        private System.Windows.Forms.Label labelVersionInfo;
        private System.Windows.Forms.LinkLabel linkLabelSupport;
    }
}
