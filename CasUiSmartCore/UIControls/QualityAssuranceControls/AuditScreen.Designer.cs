
namespace CAS.UI.UIControls.QualityAssuranceControls
{
    partial class AuditScreen
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
            this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.buttonReleaseToService = new AvControls.AvButtonT.AvButtonT();
            this.buttonClose = new AvControls.AvButtonT.AvButtonT();
            this.buttonPublish = new AvControls.AvButtonT.AvButtonT();
            this.buttonAddNonRoutineJob = new AvControls.AvButtonT.AvButtonT();
            this.headerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.Location = new System.Drawing.Point(0, 0);
            this.headerControl.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.headerControl.ShowEditButton = true;
            this.headerControl.ShowPrintButton = true;
            this.headerControl.Size = new System.Drawing.Size(1517, 71);
            this.headerControl.EditButtonClick += new System.EventHandler(this.ButtonEditClick);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
            this.panelTopContainer.Controls.Add(this.labelDateAsOf);
            //this.panelTopContainer.Controls.Add(this._buttonApplyFilter);
            this.panelTopContainer.Controls.Add(this.buttonAddNonRoutineJob);
            this.panelTopContainer.Controls.Add(this.buttonReleaseToService);
            this.panelTopContainer.Controls.Add(this.buttonPublish);
            this.panelTopContainer.Controls.Add(this.buttonClose);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 158);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1523, 405);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // labelDateAsOf
            // 
            this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateAsOf.Location = new System.Drawing.Point(76, 37);
            this.labelDateAsOf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateAsOf.Name = "labelDateAsOf";
            this.labelDateAsOf.Size = new System.Drawing.Size(0, 18);
            this.labelDateAsOf.TabIndex = 21;
            // 
            // labelTitle
            // 
            this.labelTitle.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.labelTitle.Enabled = false;
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
            this.labelTitle.ImageBackColor = System.Drawing.Color.Transparent;
            this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelTitle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.labelTitle.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.labelTitle.Location = new System.Drawing.Point(37, 4);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(800, 33);
            this.labelTitle.Status = AvControls.Statuses.NotActive;
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // buttonReleaseToService
            // 
            this.buttonReleaseToService.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonReleaseToService.ActiveBackgroundImage = null;
            this.buttonReleaseToService.Click += new System.EventHandler(ButtonReleaseToService);
            this.buttonReleaseToService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReleaseToService.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonReleaseToService.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonReleaseToService.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonReleaseToService.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonReleaseToService.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonReleaseToService.Icon = global::CAS.UI.Properties.Resources.PrintIcon;
            this.buttonReleaseToService.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonReleaseToService.IconNotEnabled = global::CAS.UI.Properties.Resources.PrintIcon_gray;
            this.buttonReleaseToService.Location = new System.Drawing.Point(928, 0);
            this.buttonReleaseToService.Margin = new System.Windows.Forms.Padding(5);
            this.buttonReleaseToService.Name = "buttonReleaseToService";
            this.buttonReleaseToService.NormalBackgroundImage = null;
            this.buttonReleaseToService.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonReleaseToService.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonReleaseToService.ShowToolTip = false;
            this.buttonReleaseToService.Size = new System.Drawing.Size(267, 73);
            this.buttonReleaseToService.TabIndex = 18;
            this.buttonReleaseToService.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReleaseToService.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReleaseToService.TextMain = "Overview of the";
            this.buttonReleaseToService.TextSecondary = "Work package";
            this.buttonReleaseToService.ToolTipText = "";
            // 
            // buttonClose
            // 
            this.buttonClose.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonClose.ActiveBackgroundImage = null;
            this.buttonClose.Click += new System.EventHandler(ButtonCloseClick);
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonClose.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonClose.Icon = global::CAS.UI.Properties.Resources.WPPerformIcon;
            this.buttonClose.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.IconNotEnabled = global::CAS.UI.Properties.Resources.WPPerformIconGray;
            this.buttonClose.Location = new System.Drawing.Point(1355, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.NormalBackgroundImage = null;
            this.buttonClose.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonClose.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonClose.ShowToolTip = false;
            this.buttonClose.Size = new System.Drawing.Size(160, 73);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonClose.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClose.TextMain = "Close";
            this.buttonClose.TextSecondary = "";
            this.buttonClose.ToolTipText = "";
            // 
            // buttonPublish
            // 
            this.buttonPublish.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonPublish.ActiveBackgroundImage = null;
            this.buttonPublish.Click += new System.EventHandler(ButtonPublishClick);
            this.buttonPublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPublish.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPublish.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonPublish.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPublish.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonPublish.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.buttonPublish.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPublish.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonPublish.Location = new System.Drawing.Point(1195, 0);
            this.buttonPublish.Margin = new System.Windows.Forms.Padding(5);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.NormalBackgroundImage = null;
            this.buttonPublish.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonPublish.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonPublish.ShowToolTip = false;
            this.buttonPublish.Size = new System.Drawing.Size(160, 73);
            this.buttonPublish.TabIndex = 19;
            this.buttonPublish.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPublish.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPublish.TextMain = "Publish";
            this.buttonPublish.TextSecondary = "";
            this.buttonPublish.ToolTipText = "";
            // 
            // buttonAddNonRoutineJob
            // 
            this.buttonAddNonRoutineJob.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.buttonAddNonRoutineJob.ActiveBackgroundImage = null;
            this.buttonAddNonRoutineJob.Click +=new System.EventHandler(ButtonAddNonRoutineJobClick);
            this.buttonAddNonRoutineJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddNonRoutineJob.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddNonRoutineJob.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNonRoutineJob.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAddNonRoutineJob.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonAddNonRoutineJob.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.buttonAddNonRoutineJob.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.buttonAddNonRoutineJob.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddNonRoutineJob.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.buttonAddNonRoutineJob.Location = new System.Drawing.Point(728, 0);
            this.buttonAddNonRoutineJob.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAddNonRoutineJob.Name = "buttonAddNonRoutineJob";
            this.buttonAddNonRoutineJob.NormalBackgroundImage = null;
            this.buttonAddNonRoutineJob.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonAddNonRoutineJob.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonAddNonRoutineJob.ShowToolTip = false;
            this.buttonAddNonRoutineJob.Size = new System.Drawing.Size(200, 73);
            this.buttonAddNonRoutineJob.TabIndex = 17;
            this.buttonAddNonRoutineJob.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddNonRoutineJob.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddNonRoutineJob.TextMain = "Add Non-";
            this.buttonAddNonRoutineJob.TextSecondary = "Routine Job";
            this.buttonAddNonRoutineJob.ToolTipText = "";
            // 
            // WorkPackageScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WorkPackageScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(1523, 622);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private AvControls.AvButtonT.AvButtonT buttonClose;
        private AvControls.AvButtonT.AvButtonT buttonPublish;
        private AvControls.AvButtonT.AvButtonT buttonAddNonRoutineJob;
        private AvControls.AvButtonT.AvButtonT buttonReleaseToService;
        private System.Windows.Forms.Label labelDateAsOf;
    }
}
