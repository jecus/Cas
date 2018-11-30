using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class GenericScreenControl<T>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericScreenControl<T>));
            this.footerControl1 = new CAS.UI.UIControls.Auxiliary.FooterControl();
            this.statusControl = new StatusControl();
            this.headerControl = new CAS.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftHeaderControl1 = new CAS.UI.UIControls.Auxiliary.AbstractOperatorHeaderControl();
            this.panelTopContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.directivesViewer = new CAS.UI.UIControls.Auxiliary.BaseListViewControl<T>();
            this.headerControl.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // footerControl1
            // 
            this.footerControl1.AutoSize = true;
            this.footerControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.footerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerControl1.Location = new System.Drawing.Point(0, 730);
            this.footerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.footerControl1.MinimumSize = new System.Drawing.Size(0, 59);
            this.footerControl1.Name = "footerControl1";
            this.footerControl1.Size = new System.Drawing.Size(1525, 59);
            this.footerControl1.TabIndex = 0;
            // 
            // statusControl
            // 
            this.statusControl.Aircraft = null;
            this.statusControl.BackColor = System.Drawing.Color.Transparent;
            this.statusControl.ConditionState = null;
            this.statusControl.Location = new System.Drawing.Point(5, 167);
            this.statusControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.statusControl.MaximumSize = new System.Drawing.Size(1067, 43);
            this.statusControl.MinimumSize = new System.Drawing.Size(1067, 43);
            this.statusControl.Name = "statusControl";
            this.statusControl.Size = new System.Drawing.Size(1067, 43);
            this.statusControl.TabIndex = 3;
            this.statusControl.Title = "Title";
            // 
            // headerControl
            // 
            this.headerControl.BackColor = System.Drawing.Color.Transparent;
            this.headerControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl.BackgroundImage")));
            this.headerControl.Controls.Add(this.aircraftHeaderControl1);
            this.headerControl.CurrentDisplayer = null;
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl.EditButtonDisplayerText = "Edit operator";
            this.headerControl.EditReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.headerControl.Location = new System.Drawing.Point(5, 5);
            this.headerControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.headerControl.Name = "headerControl";
            this.headerControl.ShowEditButton = false;
            this.headerControl.ShowForecastButton = false;
            this.headerControl.ShowHelpButton = false;
            this.headerControl.ShowPrintButton = false;
            this.headerControl.ShowReloadButton = true;
            this.headerControl.ShowSaveButton = false;
            this.headerControl.ShowSaveButton2 = false;
            this.headerControl.Size = new System.Drawing.Size(1515, 71);
            this.headerControl.TabIndex = 0;
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.Aircraft = null;
            this.aircraftHeaderControl1.ChildClickable = false;
            this.aircraftHeaderControl1.AutoSize = true;
            this.aircraftHeaderControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftHeaderControl1.BackColor = System.Drawing.Color.Transparent;
            this.aircraftHeaderControl1.CurrentDisplayer = null;
            this.aircraftHeaderControl1.Location = new System.Drawing.Point(0, 0);
            this.aircraftHeaderControl1.Name = "aircraftHeaderControl1";
            this.aircraftHeaderControl1.OperatorClickable = false;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            this.aircraftHeaderControl1.Size = new System.Drawing.Size(670, 62);
            this.aircraftHeaderControl1.TabIndex = 0;
            // 
            // panelTopContainer
            // 
            this.panelTopContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopContainer.Location = new System.Drawing.Point(4, 85);
            this.panelTopContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTopContainer.Name = "panelTopContainer";
            this.panelTopContainer.Size = new System.Drawing.Size(1517, 73);
            this.panelTopContainer.TabIndex = 6;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.AutoSize = true;
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanelHeader.ColumnCount = 1;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Controls.Add(this.statusControl, 0, 2);
            this.tableLayoutPanelHeader.Controls.Add(this.panelTopContainer, 0, 1);
            this.tableLayoutPanelHeader.Controls.Add(this.headerControl, 0, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 3;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(1525, 215);
            this.tableLayoutPanelHeader.TabIndex = 2;
            // 
            // directivesViewer
            // 
            this.directivesViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directivesViewer.Location = new System.Drawing.Point(0, 215);
            this.directivesViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.directivesViewer.Name = "directivesViewer";
            this.directivesViewer.Size = new System.Drawing.Size(1500, 500);
            this.directivesViewer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1525, 515);
            this.panel1.Controls.Add(directivesViewer);
            this.panel1.TabIndex = 3;
            // 
            // GenericScreenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Controls.Add(this.footerControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GenericScreenControl";
            this.Size = new System.Drawing.Size(1525, 789);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.Auxiliary.FooterControl footerControl1;
        public StatusControl statusControl;
        public HeaderControl headerControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        public Panel panel1;
        public AbstractOperatorHeaderControl aircraftHeaderControl1;
        public Panel panelTopContainer;
        public CAS.UI.UIControls.Auxiliary.BaseListViewControl<T> directivesViewer;
    }
}
