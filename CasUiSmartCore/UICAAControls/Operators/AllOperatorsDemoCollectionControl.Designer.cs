namespace CAS.UI.UICAAControls.Operators
{
	partial class AllOperatorsDemoCollectionControl
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelAircrafts.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoSize = true;
			this.flowLayoutPanelAircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelAircrafts.Controls.Add(this.panelButtons);
			this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(2, 44);
			this.flowLayoutPanelAircrafts.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelAircrafts.MaximumSize = new System.Drawing.Size(400, 0);
			this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(50, 40);
			this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
			this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(258, 178);
			this.flowLayoutPanelAircrafts.TabIndex = 1;
            // 
			// panelButtons
			// 
			this.panelButtons.AutoSize = true;
			this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButtons.Location = new System.Drawing.Point(2, 142);
			this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(227, 34);
			this.panelButtons.TabIndex = 11;
            // 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Operators";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = true;
			this.extendableRichContainer.Location = new System.Drawing.Point(4, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer.MaximumSize = new System.Drawing.Size(350, 34);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(350, 34);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// AircraftDemoCollectionControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.extendableRichContainer);
			this.Controls.Add(this.flowLayoutPanelAircrafts);
			this.MaximumSize = new System.Drawing.Size(400, 0);
			this.Name = "AircraftDemoCollectionControl";
			this.Size = new System.Drawing.Size(262, 224);
			this.flowLayoutPanelAircrafts.ResumeLayout(false);
			this.flowLayoutPanelAircrafts.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;
        private UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.Panel panelButtons;
    }
}
