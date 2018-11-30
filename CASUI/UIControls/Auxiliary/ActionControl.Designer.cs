using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class ActionControl
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
            this.splitViewer1 = new Controls.SplitViewer.SplitViewer();
            this.SuspendLayout();
            // 
            // splitViewer1
            // 
            this.splitViewer1.AutoSize = true;
            this.splitViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.splitViewer1.BackColor = System.Drawing.Color.Transparent;
            this.splitViewer1.ControlsAmount = 2;
            this.splitViewer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitViewer1.Location = new System.Drawing.Point(0, 0);
            this.splitViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitViewer1.Name = "splitViewer1";
            this.splitViewer1.Size = new System.Drawing.Size(8, 58);
            this.splitViewer1.TabIndex = 3;
            // 
            // ActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitViewer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(58, 58);
            this.Name = "ActionControl";
            this.Size = new System.Drawing.Size(58, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Controls.SplitViewer.SplitViewer splitViewer1;


    }
}
