namespace CAS.UI.UIControls.AircraftsControls
{
    partial class AircraftCollectionControl
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
            this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
            this.linkReport = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.linkForecastScreen = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.linkWorkPackages = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.ReferenceButtonAdd = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.panelExtendable = new System.Windows.Forms.Panel();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.flowLayoutPanelAircrafts.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelExtendable.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAircrafts
            // 
            this.flowLayoutPanelAircrafts.AutoSize = true;
            this.flowLayoutPanelAircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelAircrafts.Controls.Add(this.linkReport);
            this.flowLayoutPanelAircrafts.Controls.Add(this.linkForecastScreen);
            this.flowLayoutPanelAircrafts.Controls.Add(this.linkWorkPackages);
            this.flowLayoutPanelAircrafts.Controls.Add(this.panelButtons);
            this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(3, 52);
            this.flowLayoutPanelAircrafts.MaximumSize = new System.Drawing.Size(400, 0);
            this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(50, 40);
            this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
            this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(256, 90);
            this.flowLayoutPanelAircrafts.TabIndex = 1;
            // 
            // linkReport
            // 
            this.linkReport.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkReport.AutoSize = true;
            this.linkReport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.linkReport.Displayer = null;
            this.linkReport.DisplayerText = null;
            this.linkReport.Enabled = false;
            this.linkReport.Entity = null;
            this.linkReport.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.linkReport.ImageBackColor = System.Drawing.Color.Transparent;
            this.linkReport.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.linkReport.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkReport.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.linkReport.Location = new System.Drawing.Point(3, 3);
            this.linkReport.MaximumSize = new System.Drawing.Size(250, 20);
            this.linkReport.Name = "linkReport";
            this.linkReport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkReport.Size = new System.Drawing.Size(250, 20);
            this.linkReport.Status = AvControls.Statuses.NotActive;
            this.linkReport.TabIndex = 4;
            this.linkReport.Text = "Air Fleet Brief Report";
            this.linkReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkReport.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.linkReport.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkReportDisplayerRequested);
            // 
            // linkForecastScreen
            // 
            this.linkForecastScreen.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkForecastScreen.AutoSize = true;
            this.linkForecastScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.linkForecastScreen.Displayer = null;
            this.linkForecastScreen.DisplayerText = null;
            this.linkForecastScreen.Enabled = false;
            this.linkForecastScreen.Entity = null;
            this.linkForecastScreen.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.linkForecastScreen.ImageBackColor = System.Drawing.Color.Transparent;
            this.linkForecastScreen.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.linkForecastScreen.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkForecastScreen.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.linkForecastScreen.Location = new System.Drawing.Point(3, 29);
            this.linkForecastScreen.MaximumSize = new System.Drawing.Size(250, 20);
            this.linkForecastScreen.Name = "linkForecastScreen";
            this.linkForecastScreen.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkForecastScreen.Size = new System.Drawing.Size(250, 20);
            this.linkForecastScreen.Status = AvControls.Statuses.NotActive;
            this.linkForecastScreen.TabIndex = 5;
            this.linkForecastScreen.Text = "Forecast All Aircraft";
            this.linkForecastScreen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkForecastScreen.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.linkForecastScreen.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkForecastAllAircraftDisplayerRequested);
            // 
            // linkWorkPackages
            // 
            this.linkWorkPackages.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkWorkPackages.AutoSize = true;
            this.linkWorkPackages.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.linkWorkPackages.Displayer = null;
            this.linkWorkPackages.DisplayerText = null;
            this.linkWorkPackages.Enabled = false;
            this.linkWorkPackages.Entity = null;
            this.linkWorkPackages.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.linkWorkPackages.ImageBackColor = System.Drawing.Color.Transparent;
            this.linkWorkPackages.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.linkWorkPackages.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkWorkPackages.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.linkWorkPackages.Location = new System.Drawing.Point(3, 29);
            this.linkWorkPackages.MaximumSize = new System.Drawing.Size(250, 20);
            this.linkWorkPackages.Name = "linkWorkPackages";
            this.linkWorkPackages.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkWorkPackages.Size = new System.Drawing.Size(250, 20);
            this.linkWorkPackages.Status = AvControls.Statuses.NotActive;
            this.linkWorkPackages.TabIndex = 6;
            this.linkWorkPackages.Text = "All Work packages";
            this.linkWorkPackages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkWorkPackages.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.linkWorkPackages.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAllWorkPackagesDisplayerRequested);
            
            // 
            // panelButtons
            // 
            this.panelButtons.AutoSize = true;
            this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Controls.Add(this.ReferenceButtonAdd);
            this.panelButtons.Controls.Add(this.ButtonDelete);
            this.panelButtons.Location = new System.Drawing.Point(2, 54);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(227, 34);
            this.panelButtons.TabIndex = 11;
            // 
            // ReferenceButtonAdd
            // 
            this.ReferenceButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ReferenceButtonAdd.ActiveBackgroundImage = null;
            this.ReferenceButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReferenceButtonAdd.Displayer = null;
            this.ReferenceButtonAdd.DisplayerText = "";
            this.ReferenceButtonAdd.Entity = null;
            this.ReferenceButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ReferenceButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ReferenceButtonAdd.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.ReferenceButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ReferenceButtonAdd.Icon = null;
            this.ReferenceButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.None;
            this.ReferenceButtonAdd.IconNotEnabled = null;
            this.ReferenceButtonAdd.Location = new System.Drawing.Point(1, 4);
            this.ReferenceButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ReferenceButtonAdd.Name = "ReferenceButtonAdd";
            this.ReferenceButtonAdd.NormalBackgroundImage = null;
            this.ReferenceButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ReferenceButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ReferenceButtonAdd.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.ReferenceButtonAdd.ShowToolTip = false;
            this.ReferenceButtonAdd.Size = new System.Drawing.Size(97, 26);
            this.ReferenceButtonAdd.TabIndex = 9;
            this.ReferenceButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReferenceButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReferenceButtonAdd.TextMain = "Add Aircraft";
            this.ReferenceButtonAdd.TextSecondary = "";
            this.ReferenceButtonAdd.ToolTipText = "";
            this.ReferenceButtonAdd.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceButtonAddDisplayerRequested);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = null;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonDelete.IconNotEnabled = null;
            this.ButtonDelete.Location = new System.Drawing.Point(106, 4);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(117, 26);
            this.ButtonDelete.TabIndex = 10;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete Aircraft";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = "";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // panelExtendable
            // 
            this.panelExtendable.AutoSize = true;
            this.panelExtendable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelExtendable.Controls.Add(this.extendableRichContainer);
            this.panelExtendable.Location = new System.Drawing.Point(3, 3);
            this.panelExtendable.Name = "panelExtendable";
            this.panelExtendable.Size = new System.Drawing.Size(207, 47);
            this.panelExtendable.TabIndex = 37;
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = null;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Aircrafts";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = true;
            this.extendableRichContainer.Location = new System.Drawing.Point(3, 3);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
            this.extendableRichContainer.MaximumSize = new System.Drawing.Size(200, 40);
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(200, 40);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // AircraftCollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelExtendable);
            this.Controls.Add(this.flowLayoutPanelAircrafts);
            this.MaximumSize = new System.Drawing.Size(400, 0);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "AircraftCollectionControl";
            this.Size = new System.Drawing.Size(262, 145);
            this.flowLayoutPanelAircrafts.ResumeLayout(false);
            this.flowLayoutPanelAircrafts.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelExtendable.ResumeLayout(false);
            this.panelExtendable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel linkReport;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel linkForecastScreen;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel linkWorkPackages;
        private Management.Dispatchering.RichReferenceButton ReferenceButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private System.Windows.Forms.Panel panelExtendable;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.Panel panelButtons;
    }
}
