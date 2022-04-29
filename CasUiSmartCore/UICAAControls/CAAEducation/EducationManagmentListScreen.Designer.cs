using CASTerms;
using Entity.Abstractions;

namespace CAS.UI.UICAAControls.CAAEducation
{
    partial class EducationManagmentListScreen
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
            this.buttonDeleteSelected = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radio_ByName = new System.Windows.Forms.RadioButton();
            this.radio_ByCode = new System.Windows.Forms.RadioButton();
            this.radio_Non = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
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
			this.panelTopContainer.Controls.Add(this.flowLayoutPanel2);
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
			this.flowLayoutPanel1.Controls.Add(this.pictureBox2);
			this.flowLayoutPanel1.Controls.Add(this.buttonApplyFilter);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel1.TabIndex = 3;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.radio_Non);
			this.flowLayoutPanel2.Controls.Add(this.radio_ByCode);
			this.flowLayoutPanel2.Controls.Add(this.radio_ByName);
			
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(1291, 0);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel2.Name = "flowLayoutPanel1";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(190, 62);
			this.flowLayoutPanel2.TabIndex = 3;
			this.flowLayoutPanel2.WrapContents = false;
			// 
            // radio_WhicheverLater
            // 
            this.radio_ByName.AutoSize = true;
            this.radio_ByName.Checked = true;
            this.radio_ByName.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radio_ByName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.radio_ByName.Location = new System.Drawing.Point(775, 163);
            this.radio_ByName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radio_ByName.Name = "radio_ByName";
            this.radio_ByName.Size = new System.Drawing.Size(149, 22);
            this.radio_ByName.TabIndex = 68;
            this.radio_ByName.Text = "Group By Name";
            this.radio_ByName.UseVisualStyleBackColor = true;
            this.radio_ByName.CheckedChanged += Radio_ByNameOnCheckedChanged;
            // 
            // radio_WhicheverFirst
            // 
            this.radio_ByCode.AutoSize = true;
            this.radio_ByCode.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radio_ByCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.radio_ByCode.Location = new System.Drawing.Point(448, 163);
            this.radio_ByCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radio_ByCode.Name = "radio_ByCode";
            this.radio_ByCode.Size = new System.Drawing.Size(143, 22);
            this.radio_ByCode.TabIndex = 67;
            this.radio_ByCode.TabStop = true;
            this.radio_ByCode.Text = "Group By Code";
            this.radio_ByCode.UseVisualStyleBackColor = true;
            this.radio_ByCode.CheckedChanged += Radio_ByNameOnCheckedChanged;
            // 
            // radio_WhicheverFirst
            // 
            this.radio_Non.AutoSize = true;
            this.radio_Non.Checked = true;
            this.radio_Non.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radio_Non.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.radio_Non.Location = new System.Drawing.Point(448, 163);
            this.radio_Non.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radio_Non.Name = "radio_Non";
            this.radio_Non.Size = new System.Drawing.Size(143, 22);
            this.radio_Non.TabIndex = 67;
            this.radio_Non.TabStop = true;
            this.radio_Non.Text = "No Gropping";
            this.radio_Non.UseVisualStyleBackColor = true;
            this.radio_Non.CheckedChanged += Radio_ByNameOnCheckedChanged;
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.StatusImageLink.StatusImageLinkLabel labelTitle;
        private AvControls.AvButtonT.AvButtonT buttonDeleteSelected;
        private AvControls.AvButtonT.AvButtonT buttonApplyFilter;
        private System.Windows.Forms.Label labelDateAsOf;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radio_ByName;
        private System.Windows.Forms.RadioButton radio_ByCode;
        private System.Windows.Forms.RadioButton radio_Non;
	}
}
