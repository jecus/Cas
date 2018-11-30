namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceProgramControl
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
            this.flowLayoutPanelContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.maintenanceScheduleItem1 = new CAS.UI.UIControls.MaintananceProgram.MaintenanceProgramControlItem();
            this.panelExtendable = new System.Windows.Forms.Panel();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelContainer.SuspendLayout();
            this.panelExtendable.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelContainer
            // 
            this.flowLayoutPanelContainer.AutoSize = true;
            this.flowLayoutPanelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelContainer.Controls.Add(this.maintenanceScheduleItem1);
            this.flowLayoutPanelContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelContainer.Location = new System.Drawing.Point(4, 53);
            this.flowLayoutPanelContainer.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelContainer.Name = "flowLayoutPanelContainer";
            this.flowLayoutPanelContainer.Size = new System.Drawing.Size(204, 239);
            this.flowLayoutPanelContainer.TabIndex = 0;
            this.flowLayoutPanelContainer.WrapContents = false;
            // 
            // maintenanceScheduleItem1
            // 
            this.maintenanceScheduleItem1.AutoSize = true;
            this.maintenanceScheduleItem1.Location = new System.Drawing.Point(0, 4);
            this.maintenanceScheduleItem1.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.maintenanceScheduleItem1.Name = "maintenanceScheduleItem1";
            this.maintenanceScheduleItem1.Size = new System.Drawing.Size(200, 231);
            this.maintenanceScheduleItem1.TabIndex = 0;
            // 
            // panelExtendable
            // 
            this.panelExtendable.Controls.Add(this.extendableRichContainer);
            this.panelExtendable.Location = new System.Drawing.Point(0, 0);
            this.panelExtendable.Margin = new System.Windows.Forms.Padding(0);
            this.panelExtendable.Name = "panelExtendable";
            this.panelExtendable.Size = new System.Drawing.Size(1000, 49);
            this.panelExtendable.TabIndex = 36;
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = null;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Directive Performance";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.Condition = null;
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = false;
            this.extendableRichContainer.Location = new System.Drawing.Point(0, 3);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(5);
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(497, 49);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.panelExtendable);
            this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelContainer);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1000, 296);
            this.flowLayoutPanelMain.TabIndex = 37;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // MaintenanceProgramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MaintenanceProgramControl";
            this.Size = new System.Drawing.Size(1003, 299);
            this.flowLayoutPanelContainer.ResumeLayout(false);
            this.flowLayoutPanelContainer.PerformLayout();
            this.panelExtendable.ResumeLayout(false);
            this.panelExtendable.PerformLayout();
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaintenanceProgramControlItem maintenanceScheduleItem1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelContainer;
        private System.Windows.Forms.Panel panelExtendable;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
    }
}
