using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.StoresControls
{
	partial class StoreAllScreen
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
			var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.metroCheckBox1 = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxSeparatorD = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorF = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorCPK = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorC = new System.Windows.Forms.PictureBox();
			this._buttonTransferDetails = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxSeparatorTC = new System.Windows.Forms.PictureBox();
			this._buttonMoveToAircraft = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this._buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this._statusImageLinkLabel1 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._statusImageLinkLabel2 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this._statusImageLinkLabel3 = new CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel();
			this.comboBoxWorkPackage = new System.Windows.Forms.ComboBox();
			this.labelWorkPackage = new System.Windows.Forms.Label();
			this.buttonCalculate = new System.Windows.Forms.Button();
			this.buttonMoveTo = new System.Windows.Forms.Button();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorF)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorCPK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorC)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorTC)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.EditButtonToolTipText = "Edit Store";
			this.headerControl.Margin = new System.Windows.Forms.Padding(5);
			this.headerControl.ShowEditButton = false;
			this.headerControl.ShowForecastButton = false;
			this.headerControl.ShowPrintButton = false;
			this.headerControl.Size = new System.Drawing.Size(735, 58);

			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);

			this.headerControl.SaveButtonClick += HeaderControl_SaveButtonClick;
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(739, 205);
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
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorF);
			this.flowLayoutPanel1.Controls.Add(this._buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorC);
			this.flowLayoutPanel1.Controls.Add(this._buttonTransferDetails);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorTC);
			this.flowLayoutPanel1.Controls.Add(this._buttonMoveToAircraft);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(426, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(307, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel1);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel2);
			this.panelTopContainer.Controls.Add(this._statusImageLinkLabel3);
			this.panelTopContainer.Controls.Add(this.comboBoxWorkPackage);
			this.panelTopContainer.Controls.Add(this.labelWorkPackage);
			this.panelTopContainer.Controls.Add(this.buttonCalculate);
			this.panelTopContainer.Controls.Add(this.buttonMoveTo);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			this.panelTopContainer.Controls.Add(this.metroCheckBox1);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);

			// 
			// metroCheckBox1
			// 
			this.metroCheckBox1.AutoSize = true;
			this.metroCheckBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroCheckBox1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.metroCheckBox1.Location = new System.Drawing.Point(345, 5);
			this.metroCheckBox1.Name = "calculateCheck";
			this.metroCheckBox1.Size = new System.Drawing.Size(114, 15);
			this.metroCheckBox1.TabIndex = 0;
			this.metroCheckBox1.Text = "with calculation";
			// 
			// buttonDeleteSelected
			// 
			this.buttonDeleteSelected.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonDeleteSelected.ActiveBackgroundImage = null;
			this.buttonDeleteSelected.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDeleteSelected.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDeleteSelected.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDeleteSelected.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDeleteSelected.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDeleteSelected.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.buttonDeleteSelected.Location = new System.Drawing.Point(252, 0);
			this.buttonDeleteSelected.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.MinimumSize = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(55, 63);
			this.buttonDeleteSelected.TabIndex = 22;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.BottomLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// pictureBoxSeparatorD
			// 
			this.pictureBoxSeparatorD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorD.Location = new System.Drawing.Point(247, 3);
			this.pictureBoxSeparatorD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorD.Name = "pictureBoxSeparatorD";
			this.pictureBoxSeparatorD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorD.TabIndex = 21;
			this.pictureBoxSeparatorD.TabStop = false;
			// 
			// pictureBoxSeparatorF
			// 
			this.pictureBoxSeparatorF.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorF.Location = new System.Drawing.Point(247, 3);
			this.pictureBoxSeparatorF.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorF.Name = "pictureBoxSeparatorF";
			this.pictureBoxSeparatorF.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorF.TabIndex = 21;
			this.pictureBoxSeparatorF.TabStop = false;
			// 
			// pictureBoxSeparatorCPK
			// 
			this.pictureBoxSeparatorCPK.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorCPK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorCPK.Location = new System.Drawing.Point(184, 3);
			this.pictureBoxSeparatorCPK.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorCPK.Name = "pictureBoxSeparatorCPK";
			this.pictureBoxSeparatorCPK.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorCPK.TabIndex = 23;
			this.pictureBoxSeparatorCPK.TabStop = false;
			// 
			// pictureBoxSeparatorC
			// 
			this.pictureBoxSeparatorC.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorC.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorC.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorC.Name = "pictureBoxSeparatorC";
			this.pictureBoxSeparatorC.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorC.TabIndex = 24;
			this.pictureBoxSeparatorC.TabStop = false;
			// 
			// _buttonTransferDetails
			// 
			this._buttonTransferDetails.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this._buttonTransferDetails.ActiveBackgroundImage = null;
			this._buttonTransferDetails.Cursor = System.Windows.Forms.Cursors.Hand;
			this._buttonTransferDetails.Dock = System.Windows.Forms.DockStyle.Right;
			this._buttonTransferDetails.Enabled = false;
			this._buttonTransferDetails.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonTransferDetails.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this._buttonTransferDetails.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonTransferDetails.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonTransferDetails.Icon = global::CAS.UI.Properties.Resources.TransferComponentRed;
			this._buttonTransferDetails.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this._buttonTransferDetails.IconNotEnabled = global::CAS.UI.Properties.Resources.TransferComponentGray;
			this._buttonTransferDetails.Location = new System.Drawing.Point(63, 0);
			this._buttonTransferDetails.Margin = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.MinimumSize = new System.Drawing.Size(52, 57);
			this._buttonTransferDetails.Name = "_buttonTransferDetails";
			this._buttonTransferDetails.NormalBackgroundImage = null;
			this._buttonTransferDetails.PaddingMain = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this._buttonTransferDetails.ShowToolTip = true;
			this._buttonTransferDetails.Size = new System.Drawing.Size(55, 63);
			this._buttonTransferDetails.TabIndex = 19;
			this._buttonTransferDetails.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this._buttonTransferDetails.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this._buttonTransferDetails.TextMain = "";
			this._buttonTransferDetails.TextSecondary = "";
			this._buttonTransferDetails.ToolTipText = "Transfered details";
			this._buttonTransferDetails.Click += new System.EventHandler(this.ButtonTransferedDetailsClick);
			// 
			// pictureBoxSeparatorTC
			// 
			this.pictureBoxSeparatorTC.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorTC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorTC.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeparatorTC.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorTC.Name = "pictureBoxSeparatorTC";
			this.pictureBoxSeparatorTC.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorTC.TabIndex = 25;
			this.pictureBoxSeparatorTC.TabStop = false;
			// 
			// _buttonMoveToAircraft
			// 
			this._buttonMoveToAircraft.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this._buttonMoveToAircraft.ActiveBackgroundImage = null;
			this._buttonMoveToAircraft.Cursor = System.Windows.Forms.Cursors.Hand;
			this._buttonMoveToAircraft.Dock = System.Windows.Forms.DockStyle.Right;
			this._buttonMoveToAircraft.Enabled = false;
			this._buttonMoveToAircraft.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonMoveToAircraft.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonMoveToAircraft.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonMoveToAircraft.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonMoveToAircraft.Icon = global::CAS.UI.Properties.Resources.TransferComponentUpGreenArrow;
			this._buttonMoveToAircraft.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this._buttonMoveToAircraft.IconNotEnabled = global::CAS.UI.Properties.Resources.TransferComponentUpGreenArrowGray;
			this._buttonMoveToAircraft.Location = new System.Drawing.Point(0, 0);
			this._buttonMoveToAircraft.Margin = new System.Windows.Forms.Padding(0);
			this._buttonMoveToAircraft.MinimumSize = new System.Drawing.Size(52, 57);
			this._buttonMoveToAircraft.Name = "_buttonMoveToAircraft";
			this._buttonMoveToAircraft.NormalBackgroundImage = null;
			this._buttonMoveToAircraft.PaddingMain = new System.Windows.Forms.Padding(0);
			this._buttonMoveToAircraft.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this._buttonMoveToAircraft.ShowToolTip = true;
			this._buttonMoveToAircraft.Size = new System.Drawing.Size(55, 63);
			this._buttonMoveToAircraft.TabIndex = 18;
			this._buttonMoveToAircraft.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonMoveToAircraft.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonMoveToAircraft.TextMain = "";
			this._buttonMoveToAircraft.TextSecondary = "";
			this._buttonMoveToAircraft.ToolTipText = "Move to...";
			this._buttonMoveToAircraft.Click += new System.EventHandler(this.ButtonMoveToAircraftClick);
			// 
			// labelDateAsOf
			// 
			this.labelDateAsOf.AutoSize = true;
			this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateAsOf.Location = new System.Drawing.Point(57, 30);
			this.labelDateAsOf.Name = "labelDateAsOf";
			this.labelDateAsOf.Size = new System.Drawing.Size(0, 17);
			this.labelDateAsOf.TabIndex = 21;
			// 
			// _buttonApplyFilter
			// 
			this._buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this._buttonApplyFilter.ActiveBackgroundImage = null;
			this._buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this._buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this._buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this._buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this._buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this._buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this._buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this._buttonApplyFilter.IconNotEnabled = null;
			this._buttonApplyFilter.Location = new System.Drawing.Point(63, 0);
			this._buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.Name = "buttonApplyFilter";
			this._buttonApplyFilter.NormalBackgroundImage = null;
			this._buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this._buttonApplyFilter.ShowToolTip = true;
			this._buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this._buttonApplyFilter.TabIndex = 18;
			this._buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this._buttonApplyFilter.TextMain = "";
			this._buttonApplyFilter.TextSecondary = "";
			this._buttonApplyFilter.ToolTipText = "Apply filter";
			this._buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
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
			this._statusImageLinkLabel1.Location = new System.Drawing.Point(28, 3);
			this._statusImageLinkLabel1.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel1.Name = "_statusImageLinkLabel1";
			this._statusImageLinkLabel1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel1.Size = new System.Drawing.Size(180, 27);
			this._statusImageLinkLabel1.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel1.TabIndex = 16;
			this._statusImageLinkLabel1.Text = "Should be on stock";
			this._statusImageLinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel1.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel1.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkShoulBeOnStockDisplayerRequested);
			// 
			// _statusImageLinkLabel2
			// 
			this._statusImageLinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel2.Displayer = null;
			this._statusImageLinkLabel2.DisplayerText = null;
			this._statusImageLinkLabel2.Entity = null;
			this._statusImageLinkLabel2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel2.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabel2.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabel2.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel2.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabel2.Location = new System.Drawing.Point(28, 30);
			this._statusImageLinkLabel2.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel2.Name = "_statusImageLinkLabel2";
			this._statusImageLinkLabel2.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel2.Size = new System.Drawing.Size(180, 27);
			this._statusImageLinkLabel2.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel2.TabIndex = 16;
			this._statusImageLinkLabel2.Text = "Location";
			this._statusImageLinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel2.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel2.DisplayerRequested += _statusImageLinkLabel2_DisplayerRequested;
			// 
			// _statusImageLinkLabel3
			// 
			this._statusImageLinkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel3.Displayer = null;
			this._statusImageLinkLabel3.DisplayerText = null;
			this._statusImageLinkLabel3.Entity = null;
			this._statusImageLinkLabel3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel3.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this._statusImageLinkLabel3.ImageBackColor = System.Drawing.Color.Transparent;
			this._statusImageLinkLabel3.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this._statusImageLinkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._statusImageLinkLabel3.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this._statusImageLinkLabel3.Location = new System.Drawing.Point(206, 3);
			this._statusImageLinkLabel3.Margin = new System.Windows.Forms.Padding(0);
			this._statusImageLinkLabel3.Name = "_statusImageLinkLabel3";
			this._statusImageLinkLabel3.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this._statusImageLinkLabel3.Size = new System.Drawing.Size(185, 27);
			this._statusImageLinkLabel3.Status = AvControls.Statuses.Pending;
			this._statusImageLinkLabel3.TabIndex = 22;
			this._statusImageLinkLabel3.Text = "Tracking";
			this._statusImageLinkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._statusImageLinkLabel3.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this._statusImageLinkLabel3.DisplayerRequested += _statusImageLinkLabel3_DisplayerRequested;
			// 
			// comboBoxWorkPackage
			// 
			this.comboBoxWorkPackage.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkPackage.FormattingEnabled = true;
			this.comboBoxWorkPackage.Location = new System.Drawing.Point(345, 30);
			this.comboBoxWorkPackage.Name = "comboBoxWorkPackage";
			this.comboBoxWorkPackage.Size = new System.Drawing.Size(504, 25);
			this.comboBoxWorkPackage.TabIndex = 73;
			this.comboBoxWorkPackage.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelWorkPackage
			// 
			this.labelWorkPackage.AutoSize = true;
			this.labelWorkPackage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWorkPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWorkPackage.Location = new System.Drawing.Point(306, 33);
			this.labelWorkPackage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelWorkPackage.Name = "labelWorkPackage";
			this.labelWorkPackage.Size = new System.Drawing.Size(33, 14);
			this.labelWorkPackage.TabIndex = 72;
			this.labelWorkPackage.Text = "WP:";
			// 
			// buttonCalculate
			// 
			this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonCalculate.ForeColor = System.Drawing.Color.DimGray;
			this.buttonCalculate.Location = new System.Drawing.Point(855, 30);
			this.buttonCalculate.Name = "buttonCalculate";
			this.buttonCalculate.Size = new System.Drawing.Size(70, 23);
			this.buttonCalculate.TabIndex = 43;
			this.buttonCalculate.Text = "Calculate";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculateClick);
			// 
			// buttonMoveTo
			// 
			this.buttonMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonMoveTo.ForeColor = System.Drawing.Color.DimGray;
			this.buttonMoveTo.Location = new System.Drawing.Point(924, 30);
			this.buttonMoveTo.Name = "buttonMoveTo";
			this.buttonMoveTo.Size = new System.Drawing.Size(70, 23);
			this.buttonMoveTo.TabIndex = 43;
			this.buttonMoveTo.Text = "Move To";
			this.buttonMoveTo.UseVisualStyleBackColor = true;
			this.buttonMoveTo.Click += new System.EventHandler(this.ButtonMoveToClick);

			// 
			// StoreScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "StoreScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(739, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorF)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorCPK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorC)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorTC)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private AvControls.AvButtonT.AvButtonT _buttonApplyFilter;
		private AvControls.AvButtonT.AvButtonT _buttonTransferDetails;
		private AvControls.AvButtonT.AvButtonT _buttonMoveToAircraft;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel1;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel2;
		private CAS.UI.Management.Dispatchering.ReferenceStatusImageLinkLabel _statusImageLinkLabel3;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorD;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorF;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorCPK;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorC;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorTC;
		private System.Windows.Forms.ComboBox comboBoxWorkPackage;
		private System.Windows.Forms.Label labelWorkPackage;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.Button buttonMoveTo;
		private System.Windows.Forms.CheckBox metroCheckBox1;
	}
}
