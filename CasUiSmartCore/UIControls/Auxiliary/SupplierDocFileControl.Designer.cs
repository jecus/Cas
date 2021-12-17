using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class SupplierDocFileControl
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
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.textBoxDocumentName = new System.Windows.Forms.TextBox();
            this.FileControlChartFile = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.labelDocName = new System.Windows.Forms.Label();
            this.labelDocType = new System.Windows.Forms.Label();
            this.textBoxDocType = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelMain.Controls.Add(this.panelLabel);
            this.flowLayoutPanelMain.Controls.Add(this.panelMain);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(521, 180);
            this.flowLayoutPanelMain.TabIndex = 1;
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.extendableRichContainer1);
            this.panelLabel.Location = new System.Drawing.Point(3, 3);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(510, 26);
            this.panelLabel.TabIndex = 40;
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
            this.panelMain.Controls.Add(this.ButtonDelete);
            this.panelMain.Controls.Add(this.textBoxDocumentName);
            this.panelMain.Controls.Add(this.FileControlChartFile);
            this.panelMain.Controls.Add(this.labelDocName);
            this.panelMain.Controls.Add(this.labelDocType);
            this.panelMain.Controls.Add(this.textBoxDocType);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(3, 35);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(513, 137);
            this.panelMain.TabIndex = 42;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = null;
            this.ButtonDelete.Location = new System.Drawing.Point(438, 111);
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
            this.ButtonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// textBoxDocumentName
			// 
			this.textBoxDocumentName.BackColor = System.Drawing.Color.White;
            this.textBoxDocumentName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocumentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDocumentName.Location = new System.Drawing.Point(92, 4);
            this.textBoxDocumentName.MaxLength = 200;
            this.textBoxDocumentName.Name = "textBoxDocumentName";
            this.textBoxDocumentName.Size = new System.Drawing.Size(405, 22);
            this.textBoxDocumentName.TabIndex = 39;
            // 
            // FileControlChartFile
            // 
            this.FileControlChartFile.AutoSize = true;
            this.FileControlChartFile.BackColor = System.Drawing.Color.Transparent;
            this.FileControlChartFile.Description1 = null;
            this.FileControlChartFile.Description2 = null;
            this.FileControlChartFile.Filter = "Adobe PDF Files|*.pdf";
            this.FileControlChartFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FileControlChartFile.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.FileControlChartFile.IconNotEnabled = null;
            this.FileControlChartFile.Location = new System.Drawing.Point(6, 59);
            this.FileControlChartFile.MaximumSize = new System.Drawing.Size(350, 100);
            this.FileControlChartFile.MinimumSize = new System.Drawing.Size(350, 75);
            this.FileControlChartFile.Name = "FileControlChartFile";
            this.FileControlChartFile.Size = new System.Drawing.Size(350, 75);
            this.FileControlChartFile.TabIndex = 38;
            // 
            // labelDocName
            // 
            this.labelDocName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDocName.Location = new System.Drawing.Point(3, 2);
            this.labelDocName.Name = "labelDocName";
            this.labelDocName.Size = new System.Drawing.Size(83, 25);
            this.labelDocName.TabIndex = 34;
            this.labelDocName.Text = "Doc. name:";
            this.labelDocName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDocType
            // 
            this.labelDocType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDocType.Location = new System.Drawing.Point(3, 30);
            this.labelDocType.Name = "labelDocType";
            this.labelDocType.Size = new System.Drawing.Size(83, 25);
            this.labelDocType.TabIndex = 36;
            this.labelDocType.Text = "Doc. type:";
            this.labelDocType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDocType
            // 
            this.textBoxDocType.BackColor = System.Drawing.Color.White;
            this.textBoxDocType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDocType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDocType.Location = new System.Drawing.Point(92, 32);
            this.textBoxDocType.MaxLength = 200;
            this.textBoxDocType.Name = "textBoxDocType";
            this.textBoxDocType.Size = new System.Drawing.Size(405, 22);
            this.textBoxDocType.TabIndex = 37;
            // 
            // SupplierDocFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "SupplierDocFileControl";
            this.Size = new System.Drawing.Size(521, 180);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer1;
        private System.Windows.Forms.Panel panelMain;
        private AttachedFileControl FileControlChartFile;
        private System.Windows.Forms.Label labelDocName;
        private System.Windows.Forms.Label labelDocType;
        private System.Windows.Forms.TextBox textBoxDocType;
        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.TextBox textBoxDocumentName;

    }
}
