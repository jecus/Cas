using CASTerms;
using Entity.Abstractions;
using System.Windows.Forms;

namespace CAS.UI.UIControls.WorkPakage
{
	partial class WorkPackageScreen
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
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonAddNonRoutineJob = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS1 = new System.Windows.Forms.PictureBox();
			this.buttonAddShowEquipmentAndMaterials = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.pictureBoxS2 = new System.Windows.Forms.PictureBox();
			this.buttonPublish = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS3 = new System.Windows.Forms.PictureBox();
			this.buttonClose = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.buttonFilter = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxS4 = new System.Windows.Forms.PictureBox();
			this._statusImageLinkLabel1 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._statusImageLinkLabelFlight = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS4)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.headerControl.ShowEditButton = true;
			this.headerControl.ShowPrintButton = true;
			this.headerControl.Size = new System.Drawing.Size(773, 58);
			this.headerControl.EditButtonClick += new System.EventHandler(this.ButtonEditClick);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Size = new System.Drawing.Size(777, 205);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonClose);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS1);
			this.flowLayoutPanel1.Controls.Add(this.buttonPublish);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS2);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddShowEquipmentAndMaterials);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS3);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddNonRoutineJob);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxS4);
			this.flowLayoutPanel1.Controls.Add(this.buttonFilter);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(593, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel1);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabelFlight);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			// 
			// _statusImageLinkLabel1
			// 
			this._statusImageLinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel1.Displayer = null;
			this._statusImageLinkLabel1.DisplayerText = null;
			this._statusImageLinkLabel1.Entity = null;
			this._statusImageLinkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel1.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabel1.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabel1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel1.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabel1.Location = new System.Drawing.Point(28, 30);
			this._statusImageLinkLabel1.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel1.Name = "_statusImageLinkLabel1";
			this._statusImageLinkLabel1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel1.Size = new System.Drawing.Size(140, 27);
			this._statusImageLinkLabel1.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel1.TabIndex = 16;
			this._statusImageLinkLabel1.Text = "Add personnel";
			this._statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel1.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel1.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkWorkPackageEmployeeDisplayerRequested);
			// 
			// _statusImageLinkLabelFlight
			// 
			this._statusImageLinkLabelFlight.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabelFlight.Displayer = null;
			this._statusImageLinkLabelFlight.Enabled = false;
			this._statusImageLinkLabelFlight.DisplayerText = null;
			this._statusImageLinkLabelFlight.Entity = null;
			this._statusImageLinkLabelFlight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabelFlight.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabelFlight.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabelFlight.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabelFlight.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabelFlight.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabelFlight.Location = new System.Drawing.Point(180, 30);
			this._statusImageLinkLabelFlight.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabelFlight.Name = "_statusImageLinkLabel1";
			this._statusImageLinkLabelFlight.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabelFlight.Size = new System.Drawing.Size(180, 27);
			this._statusImageLinkLabelFlight.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabelFlight.TabIndex = 16;
			this._statusImageLinkLabelFlight.Text = "Open flight";
			this._statusImageLinkLabelFlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabelFlight.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabelFlight.DisplayerRequested += _statusImageLinkLabelFlight_DisplayerRequested;
			// 
			// buttonAddNonRoutineJob
			// 
			this.buttonAddNonRoutineJob.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddNonRoutineJob.ActiveBackgroundImage = null;
			this.buttonAddNonRoutineJob.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddNonRoutineJob.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNonRoutineJob.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNonRoutineJob.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNonRoutineJob.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNonRoutineJob.Icon = global::CAS.UI.Properties.Resources.AddJobIcon;
			this.buttonAddNonRoutineJob.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddNonRoutineJob.IconNotEnabled = global::CAS.UI.Properties.Resources.AddJobIcon_gray;
			this.buttonAddNonRoutineJob.Location = new System.Drawing.Point(0, 0);
			this.buttonAddNonRoutineJob.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddNonRoutineJob.Name = "buttonAddNonRoutineJob";
			this.buttonAddNonRoutineJob.NormalBackgroundImage = null;
			this.buttonAddNonRoutineJob.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddNonRoutineJob.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddNonRoutineJob.ShowToolTip = true;
			this.buttonAddNonRoutineJob.Size = new System.Drawing.Size(52, 57);
			this.buttonAddNonRoutineJob.TabIndex = 17;
			this.buttonAddNonRoutineJob.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonAddNonRoutineJob.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonAddNonRoutineJob.TextMain = "";
			this.buttonAddNonRoutineJob.TextSecondary = "";
			this.buttonAddNonRoutineJob.ToolTipText = "Add Non-Routine Job";
			this.buttonAddNonRoutineJob.Click += new System.EventHandler(this.ButtonAddNonRoutineJobClick);
			this.buttonAddNonRoutineJob.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// pictureBoxS1
			// 
			this.pictureBoxS1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS1.Location = new System.Drawing.Point(54, 3);
			this.pictureBoxS1.Name = "pictureBoxS1";
			this.pictureBoxS1.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS1.TabIndex = 15;
			this.pictureBoxS1.TabStop = false;
			// 
			// buttonReleaseToService
			// 
			// 
			// buttonAddShowEquipmentAndMaterials
			// 
			this.buttonAddShowEquipmentAndMaterials.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddShowEquipmentAndMaterials.ActiveBackgroundImage = null;
			this.buttonAddShowEquipmentAndMaterials.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddShowEquipmentAndMaterials.Displayer = null;
			this.buttonAddShowEquipmentAndMaterials.DisplayerText = "";
			this.buttonAddShowEquipmentAndMaterials.Entity = null;
			this.buttonAddShowEquipmentAndMaterials.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddShowEquipmentAndMaterials.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddShowEquipmentAndMaterials.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddShowEquipmentAndMaterials.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddShowEquipmentAndMaterials.Icon = global::CAS.UI.Properties.Resources.KitsIcon;
			this.buttonAddShowEquipmentAndMaterials.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddShowEquipmentAndMaterials.IconNotEnabled = global::CAS.UI.Properties.Resources.KitsIcon_gray;
			this.buttonAddShowEquipmentAndMaterials.Location = new System.Drawing.Point(63, 0);
			this.buttonAddShowEquipmentAndMaterials.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddShowEquipmentAndMaterials.Name = "buttonAddShowEquipmentAndMaterials";
			this.buttonAddShowEquipmentAndMaterials.NormalBackgroundImage = null;
			this.buttonAddShowEquipmentAndMaterials.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddShowEquipmentAndMaterials.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddShowEquipmentAndMaterials.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.buttonAddShowEquipmentAndMaterials.ShowToolTip = true;
			this.buttonAddShowEquipmentAndMaterials.Size = new System.Drawing.Size(52, 57);
			this.buttonAddShowEquipmentAndMaterials.TabIndex = 19;
			this.buttonAddShowEquipmentAndMaterials.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAddShowEquipmentAndMaterials.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonAddShowEquipmentAndMaterials.TextMain = "";
			this.buttonAddShowEquipmentAndMaterials.TextSecondary = "";
			this.buttonAddShowEquipmentAndMaterials.ToolTipText = "Show Equipment And Materials";
			this.buttonAddShowEquipmentAndMaterials.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonShowEquipmentAndMaterialsDisplayerRequested);
			// 
			// pictureBoxS2
			// 
			this.pictureBoxS2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS2.Location = new System.Drawing.Point(114, 3);
			this.pictureBoxS2.Name = "pictureBoxS2";
			this.pictureBoxS2.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS2.TabIndex = 20;
			this.pictureBoxS2.TabStop = false;
			// 
			// buttonPublish
			// 
			this.buttonPublish.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonPublish.ActiveBackgroundImage = null;
			this.buttonPublish.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPublish.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonPublish.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonPublish.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonPublish.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonPublish.Icon = global::CAS.UI.Properties.Resources.WorkPackagePublishIcon;
			this.buttonPublish.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonPublish.IconNotEnabled = global::CAS.UI.Properties.Resources.WorkPackagePublishIcon_gray;
			this.buttonPublish.Location = new System.Drawing.Point(120, 0);
			this.buttonPublish.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPublish.Name = "buttonPublish";
			this.buttonPublish.NormalBackgroundImage = null;
			this.buttonPublish.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonPublish.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonPublish.ShowToolTip = true;
			this.buttonPublish.Size = new System.Drawing.Size(52, 57);
			this.buttonPublish.TabIndex = 19;
			this.buttonPublish.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonPublish.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPublish.TextMain = "";
			this.buttonPublish.TextSecondary = "";
			this.buttonPublish.ToolTipText = "Publish";
			this.buttonPublish.Click += new System.EventHandler(this.ButtonPublishClick);
			this.buttonPublish.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// pictureBoxS3
			// 
			this.pictureBoxS3.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS3.Location = new System.Drawing.Point(174, 3);
			this.pictureBoxS3.Name = "pictureBoxS3";
			this.pictureBoxS3.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS3.TabIndex = 20;
			this.pictureBoxS3.TabStop = false;
			// 
			// buttonClose
			// 
			this.buttonClose.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonClose.ActiveBackgroundImage = null;
			this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonClose.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonClose.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonClose.Icon = global::CAS.UI.Properties.Resources.WPPerformIcon;
			this.buttonClose.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonClose.IconNotEnabled = global::CAS.UI.Properties.Resources.WPPerformIconGray;
			this.buttonClose.Location = new System.Drawing.Point(180, 0);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.NormalBackgroundImage = null;
			this.buttonClose.PaddingMain = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonClose.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonClose.ShowToolTip = true;
			this.buttonClose.Size = new System.Drawing.Size(52, 57);
			this.buttonClose.TabIndex = 20;
			this.buttonClose.TextAlignMain = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonClose.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.TextMain = "";
			this.buttonClose.TextSecondary = "";
			this.buttonClose.ToolTipText = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// labelDateAsOf
			// 
			this.labelDateAsOf.AutoSize = true;
			this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateAsOf.Location = new System.Drawing.Point(380, 35);
			this.labelDateAsOf.Name = "labelDateAsOf";
			this.labelDateAsOf.Size = new System.Drawing.Size(0, 17);
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
			this.labelTitle.Location = new System.Drawing.Point(28, 3);
			this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(600, 27);
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// pictureBoxS4
			// 
			this.pictureBoxS4.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxS4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxS4.Location = new System.Drawing.Point(55, 3);
			this.pictureBoxS4.Name = "pictureBoxS4";
			this.pictureBoxS4.Size = new System.Drawing.Size(5, 50);
			this.pictureBoxS4.TabIndex = 21;
			this.pictureBoxS4.TabStop = false;
			// 
			// buttonFilter
			// 
			this.buttonFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonFilter.ActiveBackgroundImage = null;
			this.buttonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonFilter.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonFilter.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonFilter.IconNotEnabled = global::CAS.UI.Properties.Resources.AddJobIcon_gray;
			this.buttonFilter.Location = new System.Drawing.Point(0, 0);
			this.buttonFilter.Margin = new System.Windows.Forms.Padding(0);
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.NormalBackgroundImage = null;
			this.buttonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonFilter.ShowToolTip = true;
			this.buttonFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonFilter.TabIndex = 22;
			this.buttonFilter.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonFilter.TextMain = "";
			this.buttonFilter.TextSecondary = "";
			this.buttonFilter.ToolTipText = "Apply Filter";
			this.buttonFilter.Click += ButtonFilter_Click;
			// 
			// WorkPackageScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "WorkPackageScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(777, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxS4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private AvControls.AvButtonT.AvButtonT buttonClose;
		private AvControls.AvButtonT.AvButtonT buttonPublish;
		private AvControls.AvButtonT.AvButtonT buttonAddNonRoutineJob;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddShowEquipmentAndMaterials;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.PictureBox pictureBoxS3;
		private System.Windows.Forms.PictureBox pictureBoxS2;
		private System.Windows.Forms.PictureBox pictureBoxS1;
		private PictureBox pictureBoxS4;
		private AvControls.AvButtonT.AvButtonT buttonFilter;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel1;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabelFlight;
	}
}
