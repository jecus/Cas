namespace CAS.UI.UIControls.HangarControls
{
    partial class HangarScreen
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

            //_directiveGeneralInformation.EffDateChanget -= FlightDateRouteControl1FlightDateChanget;

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.hangarMaintenanceListControl = new CAS.UI.UIControls.HangarControls.HangarMaintenanceListControl();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.headerControl.ShowPrintButton = true;
            this.headerControl.Size = new System.Drawing.Size(1430, 71);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlButtonSaveClick);
            this.headerControl.SaveButton2Click += new System.EventHandler(this.HeaderControlButtonSaveAndAddClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelMain);
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1436, 536);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            // 
            // hangarMaintenanceListControl
            // 
            this.hangarMaintenanceListControl.AttachedObject = null;
            this.hangarMaintenanceListControl.AutoSize = true;
            this.hangarMaintenanceListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hangarMaintenanceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hangarMaintenanceListControl.Hangar = null;
            this.hangarMaintenanceListControl.Location = new System.Drawing.Point(5, 5);
            this.hangarMaintenanceListControl.Margin = new System.Windows.Forms.Padding(5);
            this.hangarMaintenanceListControl.Name = "hangarMaintenanceListControl";
            this.hangarMaintenanceListControl.Size = new System.Drawing.Size(1648, 808);
            this.hangarMaintenanceListControl.TabIndex = 0;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.Controls.Add(this.hangarMaintenanceListControl);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(1436, 536);
            this.flowLayoutPanelMain.TabIndex = 1;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // HangarScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ChildClickable = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HangarScreen";
            this.OperatorClickable = true;
            this.ShowAircraftStatusPanel = false;
            this.ShowTopPanelContainer = false;
            this.Size = new System.Drawing.Size(1436, 670);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HangarMaintenanceListControl hangarMaintenanceListControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;


    }
}
