namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PowerUnitWorkControl
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
            this.powerUnitRunupsListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PowerUnitRunupsListControl();
            this.powerUnitTimeInRegimeListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PowerUnitTimeInRegimeListControl();
            this.powerUnitAccelerationListControl = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.PowerUnitAccelerationListControl();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.powerUnitRunupsListControl);
            this.flowLayoutPanelMain.Controls.Add(this.powerUnitTimeInRegimeListControl);
            this.flowLayoutPanelMain.Controls.Add(this.powerUnitAccelerationListControl);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1014, 146);
            this.flowLayoutPanelMain.TabIndex = 0;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // powerUnitRunupsListControl
            // 
            this.powerUnitRunupsListControl.AttachedObject = null;
            this.powerUnitRunupsListControl.AutoSize = true;
            this.powerUnitRunupsListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.powerUnitRunupsListControl.EndTime = new System.DateTime(2013, 2, 1, 0, 0, 0, 0);
            this.powerUnitRunupsListControl.Location = new System.Drawing.Point(4, 4);
            this.powerUnitRunupsListControl.Margin = new System.Windows.Forms.Padding(4);
            this.powerUnitRunupsListControl.MaximumSize = new System.Drawing.Size(1280, 960);
            this.powerUnitRunupsListControl.Name = "powerUnitRunupsListControl";
            this.powerUnitRunupsListControl.Size = new System.Drawing.Size(1006, 42);
            this.powerUnitRunupsListControl.StartTime = new System.DateTime(2013, 2, 1, 0, 0, 0, 0);
            this.powerUnitRunupsListControl.TabIndex = 6;
            this.powerUnitRunupsListControl.WorkTimeChanged += new System.EventHandler(this.PowerUnitRunupsListControlWorkTimeChanged);
            // 
            // powerUnitTimeInRegimeListControl
            // 
            this.powerUnitTimeInRegimeListControl.AttachedObject = null;
            this.powerUnitTimeInRegimeListControl.AutoSize = true;
            this.powerUnitTimeInRegimeListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.powerUnitTimeInRegimeListControl.Location = new System.Drawing.Point(4, 54);
            this.powerUnitTimeInRegimeListControl.Margin = new System.Windows.Forms.Padding(4);
            this.powerUnitTimeInRegimeListControl.MaximumSize = new System.Drawing.Size(1280, 960);
            this.powerUnitTimeInRegimeListControl.Name = "powerUnitTimeInRegimeListControl";
            this.powerUnitTimeInRegimeListControl.Size = new System.Drawing.Size(838, 40);
            this.powerUnitTimeInRegimeListControl.TabIndex = 7;
            // 
            // powerUnitAccelerationListControl1
            // 
            this.powerUnitAccelerationListControl.AttachedObject = null;
            this.powerUnitAccelerationListControl.AutoSize = true;
            this.powerUnitAccelerationListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.powerUnitAccelerationListControl.Location = new System.Drawing.Point(4, 102);
            this.powerUnitAccelerationListControl.Margin = new System.Windows.Forms.Padding(4);
            this.powerUnitAccelerationListControl.MaximumSize = new System.Drawing.Size(960, 960);
            this.powerUnitAccelerationListControl.Name = "powerUnitAccelerationListControl1";
            this.powerUnitAccelerationListControl.Size = new System.Drawing.Size(353, 40);
            this.powerUnitAccelerationListControl.TabIndex = 1;
            // 
            // PowerUnitWorkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1280, 960);
            this.MinimumSize = new System.Drawing.Size(1017, 450);
            this.Name = "PowerUnitWorkControl";
            this.Size = new System.Drawing.Size(1017, 450);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private PowerUnitRunupsListControl powerUnitRunupsListControl;
        private PowerUnitTimeInRegimeListControl powerUnitTimeInRegimeListControl;
        private PowerUnitAccelerationListControl powerUnitAccelerationListControl;
    }
}
