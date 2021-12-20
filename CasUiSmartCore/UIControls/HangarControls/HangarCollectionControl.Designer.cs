using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.HangarControls
{
    partial class HangarCollectionControl
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
	        var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.ReferenceButtonAdd = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelButtons.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
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
            this.ReferenceButtonAdd.Size = new System.Drawing.Size(105, 26);
            this.ReferenceButtonAdd.TabIndex = 10;
            this.ReferenceButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReferenceButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReferenceButtonAdd.TextMain = "Add Hangar";
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
            this.ButtonDelete.Location = new System.Drawing.Point(117, 4);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(109, 26);
            this.ButtonDelete.TabIndex = 7;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete Hangar";
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
            this.extendableRichContainer.Caption = "Hangars";
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
            this.panelButtons.Location = new System.Drawing.Point(2, 2);
            this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(230, 34);
            this.panelButtons.TabIndex = 37;
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(2, 44);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(234, 38);
            this.flowLayoutPanelMain.TabIndex = 38;
            // 
            // HangarCollectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.extendableRichContainer);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.MaximumSize = new System.Drawing.Size(400, 0);
            this.Name = "HangarCollectionControl";
            this.Size = new System.Drawing.Size(238, 84);
            this.panelButtons.ResumeLayout(false);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private Management.Dispatchering.RichReferenceButton ReferenceButtonAdd;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
    }
}
