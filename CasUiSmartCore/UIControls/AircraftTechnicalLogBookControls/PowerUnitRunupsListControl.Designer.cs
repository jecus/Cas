namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PowerUnitRunupsListControl
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddRunUp = new System.Windows.Forms.Panel();
            this.linkLabelAddNewRunUp = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelAddRunUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.panelAddRunUp);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(1400, 10000);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(1000, 25);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1000, 36);
            this.flowLayoutPanelMain.TabIndex = 1;
            // 
            // panelAddRunUp
            // 
            this.panelAddRunUp.Controls.Add(this.linkLabelAddNewRunUp);
            this.panelAddRunUp.Location = new System.Drawing.Point(3, 3);
            this.panelAddRunUp.Name = "panelAddRunUp";
            this.panelAddRunUp.Size = new System.Drawing.Size(994, 30);
            this.panelAddRunUp.TabIndex = 3;
            // 
            // linkLabelAddNewRunUp
            // 
            this.linkLabelAddNewRunUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNewRunUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNewRunUp.Location = new System.Drawing.Point(440, 4);
            this.linkLabelAddNewRunUp.Name = "linkLabelAddNewRunUp";
            this.linkLabelAddNewRunUp.Size = new System.Drawing.Size(115, 23);
            this.linkLabelAddNewRunUp.TabIndex = 2;
            this.linkLabelAddNewRunUp.TabStop = true;
            this.linkLabelAddNewRunUp.Text = "Add new Run Up";
            this.linkLabelAddNewRunUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNewRunUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // PowerUnitRunupsListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1400, 960);
            this.Name = "PowerUnitRunupsListControl";
            this.Size = new System.Drawing.Size(1006, 42);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.panelAddRunUp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelAddRunUp;
        private System.Windows.Forms.LinkLabel linkLabelAddNewRunUp;
    }
}
