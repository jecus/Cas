using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class DamageChartImageControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {

	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.panelMain = new System.Windows.Forms.Panel();
            this.FileControlChartFile = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.Controls.Add(this.panelLabel);
            this.flowLayoutPanelMain.Controls.Add(this.panelMain);
            this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(312, 116);
            this.flowLayoutPanelMain.TabIndex = 1;
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.extendableRichContainer1);
            this.panelLabel.Location = new System.Drawing.Point(3, 3);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(306, 26);
            this.panelLabel.TabIndex = 41;
            // 
            // extendableRichContainer1
            // 
            this.extendableRichContainer1.AfterCaptionControl = null;
            this.extendableRichContainer1.AfterCaptionControl2 = null;
            this.extendableRichContainer1.AfterCaptionControl3 = null;
            this.extendableRichContainer1.AutoSize = true;
            this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer1.Caption = "labelCaption";
            this.extendableRichContainer1.CaptionFont = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer1.Condition = null;
            this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer1.Extendable = true;
            this.extendableRichContainer1.Extended = true;
            this.extendableRichContainer1.Location = new System.Drawing.Point(3, 4);
            this.extendableRichContainer1.MainControl = null;
            this.extendableRichContainer1.MaximumSize = new System.Drawing.Size(225, 50);
            this.extendableRichContainer1.Name = "extendableRichContainer1";
            this.extendableRichContainer1.Size = new System.Drawing.Size(114, 22);
            this.extendableRichContainer1.TabIndex = 41;
            this.extendableRichContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
            this.extendableRichContainer1.Extending += new System.EventHandler(this.ExtendableRichContainer1Extending);
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.FileControlChartFile);
            this.panelMain.Location = new System.Drawing.Point(3, 35);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(306, 46);
            this.panelMain.TabIndex = 2;
            // 
            // FileControlChartFile
            // 
            this.FileControlChartFile.AutoSize = true;
            this.FileControlChartFile.BackColor = System.Drawing.Color.Transparent;
            this.FileControlChartFile.Description1 = null;
            this.FileControlChartFile.Description2 = null;
            this.FileControlChartFile.Filter = "image Files|*.jpg; *.png";
            this.FileControlChartFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FileControlChartFile.Icon = global::CAS.UI.Properties.Resources.ImageIcon;
            this.FileControlChartFile.IconNotEnabled = null;
            this.FileControlChartFile.Location = new System.Drawing.Point(3, 3);
            this.FileControlChartFile.MaximumSize = new System.Drawing.Size(300, 150);
            this.FileControlChartFile.MinimumSize = new System.Drawing.Size(300, 40);
            this.FileControlChartFile.Name = "FileControlChartFile";
            this.FileControlChartFile.Size = new System.Drawing.Size(300, 40);
            this.FileControlChartFile.TabIndex = 38;
            this.FileControlChartFile.FileChanged += new CAS.UI.UIControls.Auxiliary.AttachedFileControl.FileChangedEventHandler(this.FileControlChartFileFileChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.ButtonDelete);
            this.panelButtons.Location = new System.Drawing.Point(3, 87);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(306, 26);
            this.panelButtons.TabIndex = 39;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 8.25F);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = null;
            this.ButtonDelete.Location = new System.Drawing.Point(231, 3);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(72, 23);
            this.ButtonDelete.TabIndex = 0;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "delete";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = null;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.ButtonDelete.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// DamageChartImageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "DamageChartImageControl";
            this.Size = new System.Drawing.Size(312, 116);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButtons;
        private AttachedFileControl FileControlChartFile;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private System.Windows.Forms.Panel panelLabel;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer1;

    }
}
