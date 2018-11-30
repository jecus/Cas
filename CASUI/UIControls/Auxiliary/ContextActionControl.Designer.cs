using Controls.SplitViewer;
using CAS.UI.Appearance;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class ContextActionControl
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
            this.buttonHelp = new CAS.UI.Management.Dispatchering.HelpRequestingButtonT();
            this.buttonCloseTab = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonPrint = new CAS.UI.Management.Dispatchering.RichReferenceButton();
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
            this.splitViewer1.TabIndex = 0;
            // 
            // buttonHelp
            // 
            this.buttonHelp.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonHelp.BackColor = System.Drawing.Color.Transparent;
            this.buttonHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonHelp.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonHelp.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonHelp.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonHelp.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonHelp.Icon = icons.Help;
            this.buttonHelp.IconNotEnabled = icons.HelpGray;
            this.buttonHelp.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonHelp.Location = new System.Drawing.Point(525, 144);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.NormalBackgroundImage = null;
            this.buttonHelp.PaddingMain = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonHelp.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonHelp.Size = new System.Drawing.Size(120, 54);
            this.buttonHelp.TabIndex = 10;
            this.buttonHelp.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonHelp.TextMain = "Help";
            this.buttonHelp.TextSecondary = "";
            this.buttonHelp.TopicID = null;
            // 
            // buttonCloseTab
            // 
            this.buttonCloseTab.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonCloseTab.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonCloseTab.BackColor = System.Drawing.Color.Transparent;
            this.buttonCloseTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCloseTab.Displayer = null;
            this.buttonCloseTab.DisplayerText = null;
            this.buttonCloseTab.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonCloseTab.Entity = null;
            this.buttonCloseTab.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonCloseTab.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCloseTab.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonCloseTab.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonCloseTab.Icon = icons.Close;
            this.buttonCloseTab.IconNotEnabled = icons.CloseGray;
            this.buttonCloseTab.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCloseTab.Location = new System.Drawing.Point(666, 144);
            this.buttonCloseTab.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.Name = "buttonCloseTab";
            this.buttonCloseTab.NormalBackgroundImage = null;
            this.buttonCloseTab.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonCloseTab.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.buttonCloseTab.Size = new System.Drawing.Size(150, 54);
            this.buttonCloseTab.TabIndex = 11;
            this.buttonCloseTab.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCloseTab.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonCloseTab.TextMain = "Close tab";
            this.buttonCloseTab.TextSecondary = "";
            // 
            // buttonPrint
            // 
            this.buttonPrint.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.ActiveBackgroundImage = global::CAS.UI.Properties.Resources.HeaderBarClicked;
            this.buttonPrint.BackColor = System.Drawing.Color.Transparent;
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.Displayer = null;
            this.buttonPrint.DisplayerText = null;
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPrint.Entity = null;
            this.buttonPrint.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.buttonPrint.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPrint.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPrint.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.buttonPrint.Icon = icons.Print;
            this.buttonPrint.IconNotEnabled = icons.PrintGray;
            this.buttonPrint.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPrint.Location = new System.Drawing.Point(666, 144);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.NormalBackgroundImage = null;
            this.buttonPrint.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonPrint.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonPrint.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.buttonPrint.Size = new System.Drawing.Size(140, 54);
            this.buttonPrint.TabIndex = 9;
            this.buttonPrint.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrint.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.buttonPrint.TextMain = "Preview";
            //this.buttonPrint.TextSecondary = "Print, Export";
            // 
            // ContextActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitViewer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(58, 58);
            this.Name = "ContextActionControl";
            this.Size = new System.Drawing.Size(58, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitViewer splitViewer1;
        private HelpRequestingButtonT buttonHelp;
        private RichReferenceButton buttonCloseTab;
        private RichReferenceButton buttonPrint;

    }
}
