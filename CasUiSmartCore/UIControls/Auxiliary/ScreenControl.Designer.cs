using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class ScreenControl
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

            if(disposing)
            {
                if(_displayer != null)
                {
                    _displayer.ScreenChanged -= ScreenChanget;
                    _displayer.ClosingWindow -= ClosingWindow;
                    _displayer.CancelClosingWindow -= CancelClosingWindow;
                    if (_displayer.ParentControl != null)
                    {
                        _displayer.ParentControl.Selected -= ParentControlSelected;
                    }
                }
                DisplayerRequested = null;
                InitComplition = null;
                EntityRemoving = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenControl));
            this.panelTopContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.headerControl = new CAS.UI.UIControls.Auxiliary.HeaderControl();
            this.aircraftHeaderControl1 = new CAS.UI.UIControls.Auxiliary.AbstractOperatorHeaderControl();
            this.statusControl = new CAS.UI.UIControls.Auxiliary.StatusControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.footerControl1 = new CAS.UI.UIControls.Auxiliary.FooterControl();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.headerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTopContainer
            // 
            this.panelTopContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelTopContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopContainer.Location = new System.Drawing.Point(3, 61);
            this.panelTopContainer.Name = "panelTopContainer";
            this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
            this.panelTopContainer.TabIndex = 6;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.AutoSize = true;
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanelHeader.ColumnCount = 1;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.statusControl, 0, 2);
            this.tableLayoutPanelHeader.Controls.Add(this.panelTopContainer, 0, 1);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 3;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(1144, 169);
            this.tableLayoutPanelHeader.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.headerControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1140, 54);
            this.panel2.TabIndex = 1;
            // 
            // headerControl
            // 
            this.headerControl.BackColor = System.Drawing.Color.Transparent;
            this.headerControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("headerControl.BackgroundImage")));
            this.headerControl.CloseButtonDisplayerText = null;
            this.headerControl.Controls.Add(this.aircraftHeaderControl1);
            this.headerControl.CurrentDisplayer = null;
            this.headerControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerControl.EditButtonDisplayerText = "Edit operator";
            this.headerControl.EditButtonShowToolTip = true;
            this.headerControl.EditButtonToolTipText = "Edit Data";
            this.headerControl.EditReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.headerControl.HelpButtonTopicId = null;
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.Margin = new System.Windows.Forms.Padding(4);
            this.headerControl.Name = "headerControl";
            this.headerControl.PrintButtonContextMenuStrip = null;
            this.headerControl.PrintButtonToolTipText = "Print Priview";
            this.headerControl.ReloadButtonToolTipText = "Refresh";
            this.headerControl.Save2ButtonShowToolTip = true;
            this.headerControl.Save2ButtonToolTipText = "Save And Add Another";
            this.headerControl.SaveButtonShowToolTip = true;
            this.headerControl.SaveButtonToolTipText = "Save Data";
            this.headerControl.ShowNoForecastMenuItem = true;
            this.headerControl.Size = new System.Drawing.Size(1140, 54);
            this.headerControl.TabIndex = 0;
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.Aircraft = null;
            this.aircraftHeaderControl1.AutoSize = true;
            this.aircraftHeaderControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftHeaderControl1.BackColor = System.Drawing.Color.Transparent;
            this.aircraftHeaderControl1.Child = null;
            this.aircraftHeaderControl1.ChildClickable = false;
            this.aircraftHeaderControl1.CurrentDisplayer = null;
            this.aircraftHeaderControl1.Location = new System.Drawing.Point(0, 0);
            this.aircraftHeaderControl1.Name = "aircraftHeaderControl1";
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.Operator = null;
            this.aircraftHeaderControl1.OperatorClickable = false;
            this.aircraftHeaderControl1.PrevClickable = true;
            this.aircraftHeaderControl1.Size = new System.Drawing.Size(392, 60);
            this.aircraftHeaderControl1.Store = null;
            this.aircraftHeaderControl1.TabIndex = 0;
            // 
            // statusControl
            // 
            this.statusControl.Aircraft = null;
            this.statusControl.BackColor = System.Drawing.Color.Transparent;
            this.statusControl.ConditionState = null;
            this.statusControl.Location = new System.Drawing.Point(4, 130);
            this.statusControl.Margin = new System.Windows.Forms.Padding(4);
            this.statusControl.MaximumSize = new System.Drawing.Size(800, 35);
            this.statusControl.MinimumSize = new System.Drawing.Size(800, 35);
            this.statusControl.Name = "statusControl";
            this.statusControl.Size = new System.Drawing.Size(800, 35);
            this.statusControl.TabIndex = 3;
            this.statusControl.Title = "Title";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 424);
            this.panel1.TabIndex = 3;
            // 
            // footerControl1
            // 
            this.footerControl1.AutoSize = true;
            this.footerControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.footerControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerControl1.Location = new System.Drawing.Point(0, 593);
            this.footerControl1.Margin = new System.Windows.Forms.Padding(0);
            this.footerControl1.MinimumSize = new System.Drawing.Size(0, 48);
            this.footerControl1.Name = "footerControl1";
            this.footerControl1.Size = new System.Drawing.Size(1144, 48);
            this.footerControl1.TabIndex = 0;
            // 
            // ScreenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanelHeader);
            this.Controls.Add(this.footerControl1);
            this.DoubleBuffered = true;
            this.Name = "ScreenControl";
            this.Size = new System.Drawing.Size(1144, 641);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.Auxiliary.FooterControl footerControl1;
        protected StatusControl statusControl;
        protected HeaderControl headerControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        protected Panel panel1;
        protected AbstractOperatorHeaderControl aircraftHeaderControl1;
        protected Panel panelTopContainer;
        private Panel panel2;
    }
}