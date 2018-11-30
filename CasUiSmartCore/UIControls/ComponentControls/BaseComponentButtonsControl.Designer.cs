namespace CAS.UI.UIControls.ComponentControls
{
    partial class BaseComponentButtonsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseComponentButtonsControl));
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.ContainerFrameApus = new CAS.UI.UIControls.ReferenceControls.ReferenceControlCollectionContainer();
            this.ContainerEngines = new CAS.UI.UIControls.ReferenceControls.ReferenceControlCollectionContainer();
            this.ContainerPropellers = new CAS.UI.UIControls.ReferenceControls.ReferenceControlCollectionContainer();
            this.ContainerLG = new CAS.UI.UIControls.ReferenceControls.ReferenceControlCollectionContainer();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.ContainerFrameApus);
            this.flowLayoutPanelMain.Controls.Add(this.ContainerEngines);
            this.flowLayoutPanelMain.Controls.Add(this.ContainerPropellers);
            this.flowLayoutPanelMain.Controls.Add(this.ContainerLG);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(630, 552);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(630, 552);
            this.flowLayoutPanelMain.TabIndex = 3;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // ContainerFrameApus
            // 
            this.ContainerFrameApus.AutoSize = true;
            this.ContainerFrameApus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContainerFrameApus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ContainerFrameApus.Caption = "Frame, APUs";
            this.ContainerFrameApus.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.ContainerFrameApus.Extended = false;
            this.ContainerFrameApus.Location = new System.Drawing.Point(2, 2);
            this.ContainerFrameApus.Margin = new System.Windows.Forms.Padding(2);
            this.ContainerFrameApus.Name = "ContainerFrameApus";
            this.ContainerFrameApus.Size = new System.Drawing.Size(146, 42);
            this.ContainerFrameApus.TabIndex = 1;
            // 
            // ContainerEngines
            // 
            this.ContainerEngines.AutoSize = true;
            this.ContainerEngines.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContainerEngines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ContainerEngines.Caption = "Engines";
            this.ContainerEngines.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.ContainerEngines.Extended = false;
            this.ContainerEngines.Location = new System.Drawing.Point(2, 2);
            this.ContainerEngines.Margin = new System.Windows.Forms.Padding(2);
            this.ContainerEngines.Name = "ContainerEngines";
            this.ContainerEngines.Size = new System.Drawing.Size(146, 42);
            this.ContainerEngines.TabIndex = 2;
            this.ContainerEngines.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerEngines.UpperLeftIcon")));
            // 
            // ContainerPropellers
            // 
            this.ContainerPropellers.AutoSize = true;
            this.ContainerPropellers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContainerPropellers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ContainerPropellers.Caption = "Propellers";
            this.ContainerPropellers.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.ContainerPropellers.Extended = false;
            this.ContainerPropellers.Location = new System.Drawing.Point(2, 48);
            this.ContainerPropellers.Margin = new System.Windows.Forms.Padding(2);
            this.ContainerPropellers.Name = "ContainerPropellers";
            this.ContainerPropellers.Size = new System.Drawing.Size(167, 42);
            this.ContainerPropellers.TabIndex = 3;
            this.ContainerPropellers.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerPropellers.UpperLeftIcon")));
            // 
            // ContainerLG
            // 
            this.ContainerLG.AutoSize = true;
            this.ContainerLG.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ContainerLG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ContainerLG.Caption = "Landing Gears";
            this.ContainerLG.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.ContainerLG.Extended = false;
            this.ContainerLG.Location = new System.Drawing.Point(2, 94);
            this.ContainerLG.Margin = new System.Windows.Forms.Padding(2);
            this.ContainerLG.Name = "ContainerLG";
            this.ContainerLG.Size = new System.Drawing.Size(218, 42);
            this.ContainerLG.TabIndex = 4;
            this.ContainerLG.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("ContainerLG.UpperLeftIcon")));
            // 
            // BaseDetailButtonsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(40, 50);
            this.Name = "BaseComponentButtonsControl";
            this.Size = new System.Drawing.Size(634, 556);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private ReferenceControls.ReferenceControlCollectionContainer ContainerFrameApus;
        private ReferenceControls.ReferenceControlCollectionContainer ContainerEngines;
        private ReferenceControls.ReferenceControlCollectionContainer ContainerPropellers;
        private ReferenceControls.ReferenceControlCollectionContainer ContainerLG;
    }
}
