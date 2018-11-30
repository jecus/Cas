namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class CompliancePDFItem
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
            this.labelCheckName = new System.Windows.Forms.Label();
            this.windowsFormAttachedFileControl1 = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.extendableRichContainerTaskCards = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanelMpds = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCheckName
            // 
            this.labelCheckName.AutoSize = true;
            this.labelCheckName.Font = new System.Drawing.Font("Verdana", 11.25F);
            this.labelCheckName.ForeColor = System.Drawing.Color.DimGray;
            this.labelCheckName.Location = new System.Drawing.Point(1, 20);
            this.labelCheckName.Name = "labelCheckName";
            this.labelCheckName.Size = new System.Drawing.Size(61, 18);
            this.labelCheckName.TabIndex = 2;
            this.labelCheckName.Text = "Check:";
            // 
            // windowsFormAttachedFileControl1
            // 
            this.windowsFormAttachedFileControl1.AttachedFile = null;
            this.windowsFormAttachedFileControl1.AutoSize = true;
            this.windowsFormAttachedFileControl1.BackColor = System.Drawing.Color.Transparent;
            this.windowsFormAttachedFileControl1.Description1 = null;
            this.windowsFormAttachedFileControl1.Description2 = null;
            this.windowsFormAttachedFileControl1.Filter = "PDF file (*.pdf)|*.pdf";
            this.windowsFormAttachedFileControl1.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.windowsFormAttachedFileControl1.IconNotEnabled = null;
            this.windowsFormAttachedFileControl1.Location = new System.Drawing.Point(114, 3);
            this.windowsFormAttachedFileControl1.MaximumSize = new System.Drawing.Size(350, 100);
            this.windowsFormAttachedFileControl1.MinimumSize = new System.Drawing.Size(350, 75);
            this.windowsFormAttachedFileControl1.Name = "windowsFormAttachedFileControl1";
            this.windowsFormAttachedFileControl1.Size = new System.Drawing.Size(350, 75);
            this.windowsFormAttachedFileControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.windowsFormAttachedFileControl1);
            this.panel1.Controls.Add(this.labelCheckName);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 81);
            this.panel1.TabIndex = 5;
            // 
            // extendableRichContainerTaskCards
            // 
            this.extendableRichContainerTaskCards.AfterCaptionControl = this.checkBoxSelectAll;
            this.extendableRichContainerTaskCards.AfterCaptionControl2 = null;
            this.extendableRichContainerTaskCards.AfterCaptionControl3 = null;
            this.extendableRichContainerTaskCards.AutoSize = true;
            this.extendableRichContainerTaskCards.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainerTaskCards.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainerTaskCards.Caption = "Task Cards";
            this.extendableRichContainerTaskCards.CaptionFont = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainerTaskCards.Condition = null;
            this.extendableRichContainerTaskCards.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainerTaskCards.Extendable = true;
            this.extendableRichContainerTaskCards.Extended = false;
            this.extendableRichContainerTaskCards.Location = new System.Drawing.Point(114, 86);
            this.extendableRichContainerTaskCards.MainControl = null;
            this.extendableRichContainerTaskCards.MaximumSize = new System.Drawing.Size(355, 240);
            this.extendableRichContainerTaskCards.MinimumSize = new System.Drawing.Size(355, 0);
            this.extendableRichContainerTaskCards.Name = "extendableRichContainerTaskCards";
            this.extendableRichContainerTaskCards.Size = new System.Drawing.Size(355, 23);
            this.extendableRichContainerTaskCards.TabIndex = 3;
            this.extendableRichContainerTaskCards.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
            this.extendableRichContainerTaskCards.Extending += new System.EventHandler(this.ExtendableRichContainerTaskCardsExtending);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.checkBoxSelectAll.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(101, 3);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(79, 17);
            this.checkBoxSelectAll.TabIndex = 4;
            this.checkBoxSelectAll.Text = "Select All";
            this.checkBoxSelectAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBoxSelectAll.ThreeState = true;
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
            // 
            // flowLayoutPanelMpds
            // 
            this.flowLayoutPanelMpds.AutoScroll = true;
            this.flowLayoutPanelMpds.AutoSize = true;
            this.flowLayoutPanelMpds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMpds.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMpds.Location = new System.Drawing.Point(114, 112);
            this.flowLayoutPanelMpds.MaximumSize = new System.Drawing.Size(355, 1200);
            this.flowLayoutPanelMpds.MinimumSize = new System.Drawing.Size(355, 0);
            this.flowLayoutPanelMpds.Name = "flowLayoutPanelMpds";
            this.flowLayoutPanelMpds.Size = new System.Drawing.Size(355, 0);
            this.flowLayoutPanelMpds.TabIndex = 6;
            this.flowLayoutPanelMpds.Visible = false;
            this.flowLayoutPanelMpds.WrapContents = false;
            // 
            // CompliancePDFItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.extendableRichContainerTaskCards);
            this.Controls.Add(this.flowLayoutPanelMpds);
            this.Controls.Add(this.panel1);
            this.Name = "CompliancePDFItem";
            this.Size = new System.Drawing.Size(523, 115);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.Auxiliary.AttachedFileControl windowsFormAttachedFileControl1;
        public System.Windows.Forms.Label labelCheckName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMpds;
        private ReferenceControls.ExtendableRichContainer extendableRichContainerTaskCards;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
    }
}
