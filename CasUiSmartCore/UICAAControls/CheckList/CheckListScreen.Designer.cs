using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class CheckListsScreen
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
			this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelTitle = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.buttonApplyFilter = new AvControls.AvButtonT.AvButtonT();
            
            this.buttonRevisions = new AvControls.AvButtonT.AvButtonT();
            this.buttonPel = new AvControls.AvButtonT.AvButtonT();
            this.buttonAddNew = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 129);
            this.panel1.Size = new System.Drawing.Size(917, 413);
            // 
            // aircraftHeaderControl1
            //
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControlButtonReloadClick);
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this.labelTitle);
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
            
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            this.labelTitle.ForeColor = System.Drawing.Color.DimGray;
            this.labelTitle.Enabled = false;
            this.labelTitle.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.labelTitle.Location = new System.Drawing.Point(28, 3);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Size = new System.Drawing.Size(600, 27);
            this.labelTitle.TabIndex = 16;
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApplyFilter
			// 
			this.buttonApplyFilter.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonApplyFilter.ActiveBackgroundImage = null;
			this.buttonApplyFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonApplyFilter.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApplyFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonApplyFilter.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonApplyFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonApplyFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.buttonApplyFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonApplyFilter.IconNotEnabled = null;
			this.buttonApplyFilter.Location = new System.Drawing.Point(0, 0);
			this.buttonApplyFilter.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonApplyFilter.Name = "buttonApplyFilter";
			this.buttonApplyFilter.NormalBackgroundImage = null;
			this.buttonApplyFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonApplyFilter.ShowToolTip = true;
			this.buttonApplyFilter.Size = new System.Drawing.Size(52, 57);
			this.buttonApplyFilter.TabIndex = 18;
			this.buttonApplyFilter.TextMain = "";
			this.buttonApplyFilter.TextSecondary = "";
			this.buttonApplyFilter.ToolTipText = "Apply filter";
			this.buttonApplyFilter.Click += ButtonApplyFilterClick;
            
			// 
			// buttonRevisions
			// 
			this.buttonRevisions.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonRevisions.ActiveBackgroundImage = null;
			this.buttonRevisions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonRevisions.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonRevisions.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonRevisions.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonRevisions.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonRevisions.Icon = global::CAS.UI.Properties.Resources.REV;
			this.buttonRevisions.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRevisions.IconNotEnabled = null;
			this.buttonRevisions.Location = new System.Drawing.Point(0, 0);
			this.buttonRevisions.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonRevisions.Name = "buttonRevisions";
			this.buttonRevisions.NormalBackgroundImage = null;
			this.buttonRevisions.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonRevisions.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonRevisions.ShowToolTip = true;
			this.buttonRevisions.Size = new System.Drawing.Size(52, 57);
			this.buttonRevisions.TabIndex = 18;
			this.buttonRevisions.TextMain = "";
			this.buttonRevisions.TextSecondary = "";
			this.buttonRevisions.ToolTipText = "Edition/Revison";
			this.buttonRevisions.Click += ButtonRevisionsClick;
			// 
			// buttonPel
			// 
			this.buttonPel.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonPel.ActiveBackgroundImage = null;
			this.buttonPel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonPel.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonPel.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonPel.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonPel.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonPel.Icon = global::CAS.UI.Properties.Resources.PEL;
			this.buttonPel.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonPel.IconNotEnabled = null;
			this.buttonPel.Location = new System.Drawing.Point(0, 0);
			this.buttonPel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.buttonPel.Name = "buttonPel";
			this.buttonPel.NormalBackgroundImage = null;
			this.buttonPel.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonPel.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonPel.ShowToolTip = true;
			this.buttonPel.Size = new System.Drawing.Size(52, 57);
			this.buttonPel.TabIndex = 18;
			this.buttonPel.TextMain = "";
			this.buttonPel.TextSecondary = "";
			this.buttonPel.ToolTipText = "PEL";
			this.buttonPel.Visible = false;
			this.buttonPel.Click += ButtonPelClick;
			// 
			// buttonAddNew
			// 
			this.buttonAddNew.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.buttonAddNew.ActiveBackgroundImage = null;
			this.buttonAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonAddNew.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddNew.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonAddNew.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.buttonAddNew.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAddNew.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.buttonAddNew.Location = new System.Drawing.Point(66, 0);
			this.buttonAddNew.Name = "buttonAddDocument";
			this.buttonAddNew.NormalBackgroundImage = null;
			this.buttonAddNew.ShowToolTip = true;
			this.buttonAddNew.Size = new System.Drawing.Size(52, 57);
			this.buttonAddNew.TabIndex = 0;
			this.buttonAddNew.TextMain = "";
			this.buttonAddNew.TextSecondary = "";
			this.buttonAddNew.Visible = false;
			this.buttonAddNew.ToolTipText = "Add new";
			this.buttonAddNew.DisplayerRequested += ButtonAddDisplayerRequested;
			this.buttonAddNew.Enabled = !(userType == UserType.ReadOnly);
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
			this.buttonDeleteSelected.Location = new System.Drawing.Point(135, 0);
			this.buttonDeleteSelected.Name = "buttonDeleteSelected";
			this.buttonDeleteSelected.NormalBackgroundImage = null;
			this.buttonDeleteSelected.ShowToolTip = true;
			this.buttonDeleteSelected.Size = new System.Drawing.Size(52, 57);
			this.buttonDeleteSelected.TabIndex = 20;
			this.buttonDeleteSelected.TextMain = "";
			this.buttonDeleteSelected.TextSecondary = "";
			this.buttonDeleteSelected.ToolTipText = "Delete selected";
			this.buttonDeleteSelected.Click += ButtonDeleteClick;
			this.buttonDeleteSelected.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(124, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 15;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(55, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox3.Location = new System.Drawing.Point(55, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(5, 50);
			this.pictureBox3.TabIndex = 15;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox6.Location = new System.Drawing.Point(55, 3);
			this.pictureBox6.Name = "pictureBox3";
			this.pictureBox6.Size = new System.Drawing.Size(5, 50);
			this.pictureBox6.TabIndex = 15;
			this.pictureBox6.TabStop = false;
			this.pictureBox6.Visible = true;
			// 
			// labelDateAsOf
			// 
			this.labelDateAsOf.AutoSize = true;
            this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(122, 122, 122);
            this.labelDateAsOf.Location = new System.Drawing.Point(57, 30);
            this.labelDateAsOf.Size = new System.Drawing.Size(47, 19);
            this.labelDateAsOf.TabIndex = 21;
            this.labelDateAsOf.Name = "_labelDateAsOf";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.buttonDeleteSelected);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
			this.flowLayoutPanel1.Controls.Add(this.buttonAddNew);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox3);
			this.flowLayoutPanel1.Controls.Add(this.buttonRevisions);
			this.flowLayoutPanel1.Controls.Add(this.pictureBox6);
			this.flowLayoutPanel1.Controls.Add(this.buttonPel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// RequestForQuotationListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RequestForQuotationListScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(917, 590);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private CAS.UI.Management.Dispatchering.RichReferenceButton buttonAddNew;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonApplyFilter;

        private AvControls.AvButtonT.AvButtonT buttonPel;
        private AvControls.AvButtonT.AvButtonT buttonRevisions;
        private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}
