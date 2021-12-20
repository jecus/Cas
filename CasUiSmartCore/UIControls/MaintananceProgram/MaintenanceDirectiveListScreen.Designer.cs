using System;
using CAS.UI.Interfaces;
using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceDirectiveListScreen
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
			this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBoxSeparatorBD = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeparatorEx = new System.Windows.Forms.PictureBox();
			this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonExport = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonAPUCalc = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonMaintCheck = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonExtension = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.buttonDocument = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.pictureBoxSeperatorBAN = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperato = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperator = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperatorM = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperatorE = new System.Windows.Forms.PictureBox();
			this.pictureBoxSeperatorD = new System.Windows.Forms.PictureBox();
			this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.buttonAddShowEquipmentAndMaterials = new CAS.UI.Management.Dispatchering.RichReferenceButton();
			this.headerControl.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorBAN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperato)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorM)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorE)).BeginInit();
			this.SuspendLayout();
			// 
			// headerControl
			// 
			this.headerControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.headerControl.ShowForecastButton = true;
			this.headerControl.ShowPrintButton = true;
			this.headerControl.Size = new System.Drawing.Size(735, 58);
			this.headerControl.ForecastContextMenuClick += new System.EventHandler(this.ForecastMenuClick);
			this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
			this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.HeaderControlButtonPrintDisplayerRequested);
			this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
			this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveButtonClick);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 130);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Size = new System.Drawing.Size(739, 205);
			// 
			// aircraftHeaderControl1
			// 
			this.aircraftHeaderControl1.ChildClickable = true;
			this.aircraftHeaderControl1.OperatorClickable = true;
			//
			// panelTopContainer
			//
			this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Controls.Add(this.labelDateAsOf);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorBD);
			this.flowLayoutPanel1.Controls.Add(this.buttonExport);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeparatorEx);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddNew);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperato);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddShowEquipmentAndMaterials);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperatorBAN);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperator);
			this.flowLayoutPanel1.Controls.Add(this.buttonAPUCalc);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperatorM);
			this.flowLayoutPanel1.Controls.Add(this.buttonMaintCheck);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperatorE);
			this.flowLayoutPanel1.Controls.Add(this.buttonExtension);
			this.flowLayoutPanel1.Controls.Add(this.buttonDocument);
			this.flowLayoutPanel1.Controls.Add(this.pictureBoxSeperatorD);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(552, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(181, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
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
			this.buttonDeleteSelected.Location = new System.Drawing.Point(126, 0);
			this.buttonDeleteSelected.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.MinimumSize = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDeleteSelected.PaddingSecondary = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(55, 63);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDeleteSelected.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// pictureBoxSeparatorBD
			// 
			this.pictureBoxSeparatorBD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorBD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorBD.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorBD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorBD.Name = "pictureBoxSeparatorBD";
			this.pictureBoxSeparatorBD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorBD.TabIndex = 24;
			this.pictureBoxSeparatorBD.TabStop = false;
			// 
			// pictureBoxSeparatorEx
			// 
			this.pictureBoxSeparatorEx.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeparatorEx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeparatorEx.Location = new System.Drawing.Point(121, 3);
			this.pictureBoxSeparatorEx.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeparatorEx.Name = "pictureBoxSeparatorEx";
			this.pictureBoxSeparatorEx.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeparatorEx.TabIndex = 24;
			this.pictureBoxSeparatorEx.TabStop = false;
			// 
			// buttonAddNew
			// 
			this.buttonAddNew.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddNew.ActiveBackgroundImage = null;
			this.buttonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddNew.Displayer = null;
			this.buttonAddNew.DisplayerText = "";
			this.buttonAddNew.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonAddNew.Entity = null;
			this.buttonAddNew.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.buttonAddNew.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddNew.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.buttonAddNew.Location = new System.Drawing.Point(63, 0);
			this.buttonAddNew.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.Name = "buttonAddNew";
			this.buttonAddNew.NormalBackgroundImage = null;
			this.buttonAddNew.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAddNew.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.buttonAddNew.ShowToolTip = true;
			this.buttonAddNew.Size = new System.Drawing.Size(55, 63);
			this.buttonAddNew.TabIndex = 19;
			this.buttonAddNew.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonAddNew.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonAddNew.TextMain = "";
			this.buttonAddNew.TextSecondary = "";
			this.buttonAddNew.ToolTipText = "Add new";
			this.buttonAddNew.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonAddDisplayerRequested);
			this.buttonAddNew.Enabled = !(userType == UserType.ReadOnly);
			// 
			// buttonExport
			// 
			this.buttonExport.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonExport.ActiveBackgroundImage = null;
			this.buttonExport.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExport.Displayer = null;
			this.buttonExport.DisplayerText = "";
			this.buttonExport.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonExport.Entity = null;
			this.buttonExport.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExport.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExport.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonExport.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonExport.Icon = global::CAS.UI.Properties.Resources.ExcelImport;
			this.buttonExport.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonExport.Location = new System.Drawing.Point(63, 0);
			this.buttonExport.Margin = new System.Windows.Forms.Padding(0);
			this.buttonExport.Name = "buttonExport";
			this.buttonExport.NormalBackgroundImage = null;
			this.buttonExport.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonExport.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonExport.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.buttonExport.ShowToolTip = true;
			this.buttonExport.Size = new System.Drawing.Size(55, 63);
			this.buttonExport.TabIndex = 25;
			this.buttonExport.TextAlignMain = System.Drawing.ContentAlignment.BottomCenter;
			this.buttonExport.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
			this.buttonExport.TextMain = "";
			this.buttonExport.TextSecondary = "";
			this.buttonExport.ToolTipText = "Export";
			this.buttonExport.Click += ExportMpd_Click;
			// 
			// pictureBoxSeperatorBAN
			// 
			this.pictureBoxSeperatorBAN.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperatorBAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperatorBAN.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperatorBAN.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperatorBAN.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperatorBAN.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperatorBAN.TabIndex = 25;
			this.pictureBoxSeperatorBAN.TabStop = false;
			// 
			// pictureBoxSeperato
			// 
			this.pictureBoxSeperato.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperato.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperato.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperato.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperato.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperato.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperato.TabIndex = 25;
			this.pictureBoxSeperato.TabStop = false;
			// 
			// pictureBoxSeperator
			// 
			this.pictureBoxSeperator.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperator.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperator.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperator.Name = "pictureBoxSeperatorBAN";
			this.pictureBoxSeperator.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperator.TabIndex = 25;
			this.pictureBoxSeperator.TabStop = false;
			// 
			// pictureBoxSeperatorM
			// 
			this.pictureBoxSeperatorM.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperatorM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperatorM.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperatorM.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperatorM.Name = "pictureBoxSeperatorM";
			this.pictureBoxSeperatorM.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperatorM.TabIndex = 25;
			this.pictureBoxSeperatorM.TabStop = false;
			// 
			// pictureBoxSeperatorE
			// 
			this.pictureBoxSeperatorE.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperatorE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperatorE.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperatorE.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperatorE.Name = "pictureBoxSeperatorE";
			this.pictureBoxSeperatorE.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperatorE.TabIndex = 25;
			this.pictureBoxSeperatorE.TabStop = false;
			// 
			// pictureBoxSeperatorD
			// 
			this.pictureBoxSeperatorD.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBoxSeperatorD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBoxSeperatorD.Location = new System.Drawing.Point(58, 3);
			this.pictureBoxSeperatorD.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.pictureBoxSeperatorD.Name = "pictureBoxSeperatorD";
			this.pictureBoxSeperatorD.Size = new System.Drawing.Size(5, 57);
			this.pictureBoxSeperatorD.TabIndex = 25;
			this.pictureBoxSeperatorD.TabStop = false;
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonApplyFilter.IconNotEnabled = null;
			this.buttonApplyFilter.Location = new System.Drawing.Point(0, 0);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(55, 63);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// buttonAPU
			// 
			this.buttonAPUCalc.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAPUCalc.ActiveBackgroundImage = null;
			this.buttonAPUCalc.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAPUCalc.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonAPUCalc.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAPUCalc.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonAPUCalc.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAPUCalc.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonAPUCalc.Icon = global::CAS.UI.Properties.Resources.APU;
			this.buttonAPUCalc.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAPUCalc.IconNotEnabled = null;
			this.buttonAPUCalc.Location = new System.Drawing.Point(0, 0);
			this.buttonAPUCalc.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAPUCalc.Name = "buttonApplyFilter";
			this.buttonAPUCalc.NormalBackgroundImage = null;
			this.buttonAPUCalc.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonAPUCalc.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonAPUCalc.ShowToolTip = true;
			this.buttonAPUCalc.Size = new System.Drawing.Size(55, 63);
			this.buttonAPUCalc.TabIndex = 18;
			this.buttonAPUCalc.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAPUCalc.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonAPUCalc.TextMain = "";
			this.buttonAPUCalc.TextSecondary = "";
			this.buttonAPUCalc.ToolTipText = "APUCalc";
			this.buttonAPUCalc.Click += new System.EventHandler(this.ButtonAPUCalc_Click);
			// 
			// buttonMaintCheck
			// 
			this.buttonMaintCheck.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonMaintCheck.ActiveBackgroundImage = null;
			this.buttonMaintCheck.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonMaintCheck.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonMaintCheck.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonMaintCheck.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonMaintCheck.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonMaintCheck.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonMaintCheck.Icon = global::CAS.UI.Properties.Resources.Check_List_Service_Maintenance;
			this.buttonMaintCheck.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonMaintCheck.IconNotEnabled = null;
			this.buttonMaintCheck.Location = new System.Drawing.Point(0, 0);
			this.buttonMaintCheck.Margin = new System.Windows.Forms.Padding(0);
			this.buttonMaintCheck.Name = "buttonMaintCheck";
			this.buttonMaintCheck.NormalBackgroundImage = null;
			this.buttonMaintCheck.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonMaintCheck.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonMaintCheck.ShowToolTip = true;
			this.buttonMaintCheck.Size = new System.Drawing.Size(55, 63);
			this.buttonMaintCheck.TabIndex = 18;
			this.buttonMaintCheck.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonMaintCheck.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonMaintCheck.TextMain = "";
			this.buttonMaintCheck.TextSecondary = "";
			this.buttonMaintCheck.ToolTipText = "Check Name";
			this.buttonMaintCheck.Click += new System.EventHandler(this.buttonMaintCheck_Click);
			// 
			// buttonExtension
			// 
			this.buttonExtension.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonExtension.ActiveBackgroundImage = null;
			this.buttonExtension.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonExtension.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonExtension.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExtension.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonExtension.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonExtension.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonExtension.Icon = global::CAS.UI.Properties.Resources.ExtensionIcon;
			this.buttonExtension.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonExtension.IconNotEnabled = null;
			this.buttonExtension.Location = new System.Drawing.Point(0, 0);
			this.buttonExtension.Margin = new System.Windows.Forms.Padding(0);
			this.buttonExtension.Name = "buttonExtension";
			this.buttonExtension.NormalBackgroundImage = null;
			this.buttonExtension.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonExtension.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonExtension.ShowToolTip = true;
			this.buttonExtension.Size = new System.Drawing.Size(55, 63);
			this.buttonExtension.TabIndex = 18;
			this.buttonExtension.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonExtension.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonExtension.TextMain = "";
			this.buttonExtension.TextSecondary = "";
			this.buttonExtension.ToolTipText = "Extension";
			this.buttonExtension.Click += new System.EventHandler(this.buttonExtension_Click);
			// 
			// buttonDocument
			// 
			this.buttonDocument.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonDocument.ActiveBackgroundImage = null;
			this.buttonDocument.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDocument.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonDocument.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDocument.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonDocument.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDocument.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonDocument.Icon = global::CAS.UI.Properties.Resources.DocumentGear;
			this.buttonDocument.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDocument.IconNotEnabled = null;
			this.buttonDocument.Location = new System.Drawing.Point(0, 0);
			this.buttonDocument.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDocument.Name = "buttonDocument";
			this.buttonDocument.NormalBackgroundImage = null;
			this.buttonDocument.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDocument.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDocument.ShowToolTip = true;
			this.buttonDocument.Size = new System.Drawing.Size(55, 63);
			this.buttonDocument.TabIndex = 18;
			this.buttonDocument.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDocument.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDocument.TextMain = "";
			this.buttonDocument.TextSecondary = "";
			this.buttonDocument.ToolTipText = "Document";
			this.buttonDocument.DisplayerRequested += new EventHandler<ReferenceEventArgs>(this.buttonDocument_Click);
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
			this.labelTitle.Status = AvControls.Statuses.NotActive;
			this.labelTitle.TabIndex = 16;
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelTitle.TextFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
			// MaintenanceDirectiveListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ChildClickable = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "MaintenanceDirectiveListScreen";
			this.OperatorClickable = true;
			this.ShowAircraftStatusPanel = false;
			this.Size = new System.Drawing.Size(739, 383);
			this.headerControl.ResumeLayout(false);
			this.headerControl.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorBD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeparatorEx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorBAN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperato)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorM)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSeperatorE)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNew;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonExport;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAPUCalc;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonMaintCheck;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonExtension;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonDocument;
		private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
		private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
		private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorBD;
		private System.Windows.Forms.PictureBox pictureBoxSeparatorEx;
		private System.Windows.Forms.PictureBox pictureBoxSeperatorBAN;
		private System.Windows.Forms.PictureBox pictureBoxSeperato;
		private System.Windows.Forms.PictureBox pictureBoxSeperator;
		private System.Windows.Forms.PictureBox pictureBoxSeperatorM;
		private System.Windows.Forms.PictureBox pictureBoxSeperatorE;
		private System.Windows.Forms.PictureBox pictureBoxSeperatorD;
		private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddShowEquipmentAndMaterials;
	}
}
