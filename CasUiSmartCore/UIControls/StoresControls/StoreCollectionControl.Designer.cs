using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.StoresControls
{
    partial class StoreCollectionControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы .
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
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;
			this.ReferenceButtonAdd = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
			this.linkInventoryControl = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.linkShoundBeOnStock = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.panelButtons.SuspendLayout();
			this.flowLayoutPanelAircrafts.SuspendLayout();
			this.SuspendLayout();
			// 
			// ReferenceButtonAdd
			// 
			this.ReferenceButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ReferenceButtonAdd.ActiveBackgroundImage = null;
			this.ReferenceButtonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
			this.ReferenceButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.ReferenceButtonAdd.Location = new System.Drawing.Point(4, 4);
			this.ReferenceButtonAdd.Margin = new System.Windows.Forms.Padding(4);
			this.ReferenceButtonAdd.Name = "ReferenceButtonAdd";
			this.ReferenceButtonAdd.NormalBackgroundImage = null;
			this.ReferenceButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ReferenceButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ReferenceButtonAdd.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.ReferenceButtonAdd.ShowToolTip = false;
			this.ReferenceButtonAdd.Size = new System.Drawing.Size(90, 26);
			this.ReferenceButtonAdd.TabIndex = 10;
			this.ReferenceButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ReferenceButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ReferenceButtonAdd.TextMain = "Add Store";
			this.ReferenceButtonAdd.TextSecondary = "";
			this.ReferenceButtonAdd.ToolTipText = "";
			this.ReferenceButtonAdd.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceButtonAddDisplayerRequested);
			this.ReferenceButtonAdd.Enabled = !(userType == UserType.ReadOnly);
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = null;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.None;
			this.ButtonDelete.IconNotEnabled = null;
			this.ButtonDelete.Location = new System.Drawing.Point(102, 4);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(100, 26);
			this.ButtonDelete.TabIndex = 7;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Store";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.ButtonDelete.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Stores";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = true;
			this.extendableRichContainer.Location = new System.Drawing.Point(4, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer.MaximumSize = new System.Drawing.Size(200, 40);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(200, 34);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// panelButtons
			// 
			this.panelButtons.AutoSize = true;
			this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelButtons.Controls.Add(this.ButtonDelete);
			this.panelButtons.Controls.Add(this.ReferenceButtonAdd);
			this.panelButtons.Location = new System.Drawing.Point(0, 56);
			this.panelButtons.Margin = new System.Windows.Forms.Padding(0);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(206, 34);
			this.panelButtons.TabIndex = 37;
			// 
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoSize = true;
			this.flowLayoutPanelAircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelAircrafts.Controls.Add(this.linkInventoryControl);
			this.flowLayoutPanelAircrafts.Controls.Add(this.linkShoundBeOnStock);
			this.flowLayoutPanelAircrafts.Controls.Add(this.panelButtons);
			this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(2, 44);
			this.flowLayoutPanelAircrafts.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelAircrafts.MaximumSize = new System.Drawing.Size(400, 0);
			this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(50, 40);
			this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
			this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(258, 90);
			this.flowLayoutPanelAircrafts.TabIndex = 39;
			// 
			// linkInventoryControl
			// 
			this.linkInventoryControl.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkInventoryControl.AutoSize = true;
			this.linkInventoryControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.linkInventoryControl.Displayer = null;
			this.linkInventoryControl.DisplayerText = null;
			this.linkInventoryControl.Entity = null;
			this.linkInventoryControl.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.linkInventoryControl.ImageBackColor = System.Drawing.Color.Transparent;
			this.linkInventoryControl.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.linkInventoryControl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkInventoryControl.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.linkInventoryControl.Location = new System.Drawing.Point(4, 4);
			this.linkInventoryControl.Margin = new System.Windows.Forms.Padding(4);
			this.linkInventoryControl.MaximumSize = new System.Drawing.Size(250, 20);
			this.linkInventoryControl.Name = "linkInventoryControl";
			this.linkInventoryControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkInventoryControl.Size = new System.Drawing.Size(250, 20);
			this.linkInventoryControl.TabIndex = 5;
			this.linkInventoryControl.Text = "Inventory Control";
			this.linkInventoryControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkInventoryControl.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.linkInventoryControl.DisplayerRequested += LinkInventoryControl_DisplayerRequested;
			// 
			// linkShoundBeOnStock
			// 
			this.linkShoundBeOnStock.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkShoundBeOnStock.AutoSize = true;
			this.linkShoundBeOnStock.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.linkShoundBeOnStock.Displayer = null;
			this.linkShoundBeOnStock.DisplayerText = null;
			this.linkShoundBeOnStock.Enabled = false;
			this.linkShoundBeOnStock.Entity = null;
			this.linkShoundBeOnStock.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.linkShoundBeOnStock.ImageBackColor = System.Drawing.Color.Transparent;
			this.linkShoundBeOnStock.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.linkShoundBeOnStock.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkShoundBeOnStock.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.linkShoundBeOnStock.Location = new System.Drawing.Point(4, 32);
			this.linkShoundBeOnStock.Margin = new System.Windows.Forms.Padding(4);
			this.linkShoundBeOnStock.MaximumSize = new System.Drawing.Size(250, 20);
			this.linkShoundBeOnStock.Name = "linkShoundBeOnStock";
			this.linkShoundBeOnStock.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkShoundBeOnStock.Size = new System.Drawing.Size(250, 20);
			this.linkShoundBeOnStock.TabIndex = 4;
			this.linkShoundBeOnStock.Text = "Should Be On Stock";
			this.linkShoundBeOnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkShoundBeOnStock.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// StoreCollectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.extendableRichContainer);
			this.Controls.Add(this.flowLayoutPanelAircrafts);
			this.MaximumSize = new System.Drawing.Size(400, 0);
			this.Name = "StoreCollectionControl";
			this.Size = new System.Drawing.Size(262, 136);
			this.panelButtons.ResumeLayout(false);
			this.flowLayoutPanelAircrafts.ResumeLayout(false);
			this.flowLayoutPanelAircrafts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private Management.Dispatchering.RichReferenceButton ReferenceButtonAdd;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel linkInventoryControl;
        private Management.Dispatchering.ReferenceStatusImageLinkLabel linkShoundBeOnStock;
    }
}
