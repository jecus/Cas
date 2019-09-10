namespace CAS.UI.UIControls.AircraftsControls
{
	partial class AircraftDemoCollectionControl
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
			this.linkBiWeekly = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.linkPowerPlants = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.linkReliability = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.aDFleet = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.componentFleet = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.ReferenceButtonAdd = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.flowLayoutPanelAircrafts.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelAircrafts
			// 
			this.flowLayoutPanelAircrafts.AutoSize = true;
			this.flowLayoutPanelAircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelAircrafts.Controls.Add(this.linkBiWeekly);
			this.flowLayoutPanelAircrafts.Controls.Add(this.linkPowerPlants);
			this.flowLayoutPanelAircrafts.Controls.Add(this.linkReliability);
			this.flowLayoutPanelAircrafts.Controls.Add(this.aDFleet);
			this.flowLayoutPanelAircrafts.Controls.Add(this.componentFleet);
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
			// linkBiWeekly
			// 
			this.linkBiWeekly.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkBiWeekly.AutoSize = true;
			this.linkBiWeekly.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.linkBiWeekly.Displayer = null;
			this.linkBiWeekly.DisplayerText = null;
			this.linkBiWeekly.Enabled = false;
			this.linkBiWeekly.Entity = null;
			this.linkBiWeekly.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.linkBiWeekly.ImageBackColor = System.Drawing.Color.Transparent;
			this.linkBiWeekly.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.linkBiWeekly.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkBiWeekly.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.linkBiWeekly.Location = new System.Drawing.Point(4, 4);
			this.linkBiWeekly.Margin = new System.Windows.Forms.Padding(4);
			this.linkBiWeekly.MaximumSize = new System.Drawing.Size(250, 20);
			this.linkBiWeekly.Name = "linkBiWeekly";
			this.linkBiWeekly.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkBiWeekly.Size = new System.Drawing.Size(250, 20);
			this.linkBiWeekly.TabIndex = 4;
			this.linkBiWeekly.Text = "Bi Weekly";
			this.linkBiWeekly.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkBiWeekly.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.linkBiWeekly.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkReportDisplayerRequested);
			// 
			// linkPowerPlants
			// 
			this.linkPowerPlants.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkPowerPlants.AutoSize = true;
			this.linkPowerPlants.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.linkPowerPlants.Displayer = null;
			this.linkPowerPlants.DisplayerText = null;
			this.linkPowerPlants.Enabled = false;
			this.linkPowerPlants.Entity = null;
			this.linkPowerPlants.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.linkPowerPlants.ImageBackColor = System.Drawing.Color.Transparent;
			this.linkPowerPlants.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.linkPowerPlants.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkPowerPlants.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.linkPowerPlants.Location = new System.Drawing.Point(4, 32);
			this.linkPowerPlants.Margin = new System.Windows.Forms.Padding(4);
			this.linkPowerPlants.MaximumSize = new System.Drawing.Size(250, 20);
			this.linkPowerPlants.Name = "linkPowerPlants";
			this.linkPowerPlants.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkPowerPlants.Size = new System.Drawing.Size(250, 20);
			this.linkPowerPlants.TabIndex = 13;
			this.linkPowerPlants.Text = "Power Plants";
			this.linkPowerPlants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkPowerPlants.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.linkPowerPlants.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkPowerPlanst);
			// 
			// linkReliability
			// 
			this.linkReliability.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkReliability.AutoSize = true;
			this.linkReliability.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.linkReliability.Displayer = null;
			this.linkReliability.DisplayerText = null;
			this.linkReliability.Enabled = false;
			this.linkReliability.Entity = null;
			this.linkReliability.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.linkReliability.ImageBackColor = System.Drawing.Color.Transparent;
			this.linkReliability.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.linkReliability.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkReliability.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.linkReliability.Location = new System.Drawing.Point(4, 60);
			this.linkReliability.Margin = new System.Windows.Forms.Padding(4);
			this.linkReliability.MaximumSize = new System.Drawing.Size(250, 20);
			this.linkReliability.Name = "linkReliability";
			this.linkReliability.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkReliability.Size = new System.Drawing.Size(250, 20);
			this.linkReliability.TabIndex = 12;
			this.linkReliability.Text = "Reliability";
			this.linkReliability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkReliability.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			// 
			// aDFleet
			// 
			this.aDFleet.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.aDFleet.AutoSize = true;
			this.aDFleet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.aDFleet.Displayer = null;
			this.aDFleet.DisplayerText = null;
			this.aDFleet.Enabled = true;
			this.aDFleet.Entity = null;
			this.aDFleet.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.aDFleet.ImageBackColor = System.Drawing.Color.Transparent;
			this.aDFleet.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.aDFleet.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.aDFleet.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.aDFleet.Location = new System.Drawing.Point(4, 88);
			this.aDFleet.Margin = new System.Windows.Forms.Padding(4);
			this.aDFleet.MaximumSize = new System.Drawing.Size(250, 20);
			this.aDFleet.Name = "aDFleet";
			this.aDFleet.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.aDFleet.Size = new System.Drawing.Size(250, 20);
			this.aDFleet.TabIndex = 14;
			this.aDFleet.Text = "AD Fleet";
			this.aDFleet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.aDFleet.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.aDFleet.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkAdFleet);
			// 
			// componentFleet
			// 
			this.componentFleet.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.componentFleet.AutoSize = true;
			this.componentFleet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.componentFleet.Displayer = null;
			this.componentFleet.DisplayerText = null;
			this.componentFleet.Enabled = true;
			this.componentFleet.Entity = null;
			this.componentFleet.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.componentFleet.ImageBackColor = System.Drawing.Color.Transparent;
			this.componentFleet.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.componentFleet.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.componentFleet.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.componentFleet.Location = new System.Drawing.Point(4, 116);
			this.componentFleet.Margin = new System.Windows.Forms.Padding(4);
			this.componentFleet.MaximumSize = new System.Drawing.Size(250, 20);
			this.componentFleet.Name = "componentFleet";
			this.componentFleet.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.componentFleet.Size = new System.Drawing.Size(250, 20);
			this.componentFleet.TabIndex = 12;
			this.componentFleet.Text = "Component Fleet";
			this.componentFleet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.componentFleet.TextFont = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.componentFleet.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkComponentFleet);
			// 
			// panelButtons
			// 
			this.panelButtons.AutoSize = true;
			this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelButtons.Controls.Add(this.ReferenceButtonAdd);
			this.panelButtons.Controls.Add(this.ButtonDelete);
			this.panelButtons.Location = new System.Drawing.Point(2, 142);
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
			this.ReferenceButtonAdd.Enabled = false;
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
			this.ButtonDelete.Enabled = false;
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
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Aircrafts";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = true;
			this.extendableRichContainer.Location = new System.Drawing.Point(4, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer.MaximumSize = new System.Drawing.Size(200, 34);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(143, 34);
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
		private Management.Dispatchering.ReferenceStatusImageLinkLabel linkBiWeekly;
		private Management.Dispatchering.RichReferenceButton ReferenceButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.Panel panelButtons;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel linkPowerPlants;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel linkReliability;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel componentFleet;
		private Management.Dispatchering.ReferenceStatusImageLinkLabel aDFleet;
	}
}
