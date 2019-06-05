namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentComplianceLifeLimitControl
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
			this.lifelengthViewerWarrantyNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthTCSNOnInstall = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelFAAForm = new System.Windows.Forms.Label();
			this.labelManHours = new System.Windows.Forms.Label();
			this.textBoxManHours = new System.Windows.Forms.TextBox();
			this.labelCostNew = new System.Windows.Forms.Label();
			this.textBoxCost = new System.Windows.Forms.TextBox();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.labelCostOverhaul = new System.Windows.Forms.Label();
			this.textBoxCostOverhaul = new System.Windows.Forms.TextBox();
			this.labelCostServicible = new System.Windows.Forms.Label();
			this.textBoxCostServicible = new System.Windows.Forms.TextBox();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.panelWarranty = new System.Windows.Forms.Panel();
			this.panelComponentCurrent = new System.Windows.Forms.Panel();
			this.flowLayoutPanelLifeLimit = new System.Windows.Forms.FlowLayoutPanel();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.panelWarranty.SuspendLayout();
			this.panelComponentCurrent.SuspendLayout();
			this.flowLayoutPanelLifeLimit.SuspendLayout();
			this.SuspendLayout();
			// 
			// lifelengthViewerWarrantyNotify
			// 
			this.lifelengthViewerWarrantyNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerWarrantyNotify.AutoSize = true;
			this.lifelengthViewerWarrantyNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerWarrantyNotify.CalendarApplicable = false;
			this.lifelengthViewerWarrantyNotify.CyclesApplicable = false;
			this.lifelengthViewerWarrantyNotify.EnabledCalendar = true;
			this.lifelengthViewerWarrantyNotify.EnabledCycle = true;
			this.lifelengthViewerWarrantyNotify.EnabledHours = true;
			this.lifelengthViewerWarrantyNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerWarrantyNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerWarrantyNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerWarrantyNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderHours = "Hours";
			this.lifelengthViewerWarrantyNotify.HoursApplicable = false;
			this.lifelengthViewerWarrantyNotify.LeftHeader = "Notify:";
			this.lifelengthViewerWarrantyNotify.Location = new System.Drawing.Point(621, 0);
			this.lifelengthViewerWarrantyNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarrantyNotify.Modified = false;
			this.lifelengthViewerWarrantyNotify.Name = "lifelengthViewerWarrantyNotify";
			this.lifelengthViewerWarrantyNotify.ReadOnly = false;
			this.lifelengthViewerWarrantyNotify.ShowCalendar = true;
			this.lifelengthViewerWarrantyNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerWarrantyNotify.ShowHeaders = false;
			this.lifelengthViewerWarrantyNotify.ShowMinutes = false;
			this.lifelengthViewerWarrantyNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerWarrantyNotify.SystemCalculated = true;
			this.lifelengthViewerWarrantyNotify.TabIndex = 72;
			// 
			// lifelengthViewerWarranty
			// 
			this.lifelengthViewerWarranty.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerWarranty.AutoSize = true;
			this.lifelengthViewerWarranty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerWarranty.CalendarApplicable = false;
			this.lifelengthViewerWarranty.CyclesApplicable = false;
			this.lifelengthViewerWarranty.EnabledCalendar = true;
			this.lifelengthViewerWarranty.EnabledCycle = true;
			this.lifelengthViewerWarranty.EnabledHours = true;
			this.lifelengthViewerWarranty.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerWarranty.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerWarranty.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderCycles = "Cycles";
			this.lifelengthViewerWarranty.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderHours = "Hours";
			this.lifelengthViewerWarranty.HoursApplicable = false;
			this.lifelengthViewerWarranty.LeftHeader = "Warranty:";
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(57, 0);
			this.lifelengthViewerWarranty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarranty.Modified = false;
			this.lifelengthViewerWarranty.Name = "lifelengthViewerWarranty";
			this.lifelengthViewerWarranty.ReadOnly = false;
			this.lifelengthViewerWarranty.ShowCalendar = true;
			this.lifelengthViewerWarranty.ShowFormattedCalendar = false;
			this.lifelengthViewerWarranty.ShowHeaders = false;
			this.lifelengthViewerWarranty.ShowMinutes = false;
			this.lifelengthViewerWarranty.Size = new System.Drawing.Size(437, 35);
			this.lifelengthViewerWarranty.SystemCalculated = true;
			this.lifelengthViewerWarranty.TabIndex = 70;
			// 
			// lifelengthTCSNOnInstall
			// 
			this.lifelengthTCSNOnInstall.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthTCSNOnInstall.AutoSize = true;
			this.lifelengthTCSNOnInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthTCSNOnInstall.CalendarApplicable = false;
			this.lifelengthTCSNOnInstall.CyclesApplicable = false;
			this.lifelengthTCSNOnInstall.Enabled = false;
			this.lifelengthTCSNOnInstall.EnabledCalendar = true;
			this.lifelengthTCSNOnInstall.EnabledCycle = true;
			this.lifelengthTCSNOnInstall.EnabledHours = true;
			this.lifelengthTCSNOnInstall.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthTCSNOnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthTCSNOnInstall.HeaderCalendar = "Calendar";
			this.lifelengthTCSNOnInstall.HeaderCycles = "Cycles";
			this.lifelengthTCSNOnInstall.HeaderFormattedCalendar = "Calendar";
			this.lifelengthTCSNOnInstall.HeaderHours = "Hours";
			this.lifelengthTCSNOnInstall.HoursApplicable = false;
			this.lifelengthTCSNOnInstall.LeftHeader = "Compnt current:";
			this.lifelengthTCSNOnInstall.Location = new System.Drawing.Point(11, 2);
			this.lifelengthTCSNOnInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthTCSNOnInstall.Modified = false;
			this.lifelengthTCSNOnInstall.Name = "lifelengthTCSNOnInstall";
			this.lifelengthTCSNOnInstall.ReadOnly = false;
			this.lifelengthTCSNOnInstall.ShowCalendar = true;
			this.lifelengthTCSNOnInstall.ShowFormattedCalendar = false;
			this.lifelengthTCSNOnInstall.ShowMinutes = false;
			this.lifelengthTCSNOnInstall.Size = new System.Drawing.Size(484, 52);
			this.lifelengthTCSNOnInstall.SystemCalculated = true;
			this.lifelengthTCSNOnInstall.TabIndex = 64;
			// 
			// labelFAAForm
			// 
			this.labelFAAForm.AutoSize = true;
			this.labelFAAForm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFAAForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFAAForm.Location = new System.Drawing.Point(544, 43);
			this.labelFAAForm.Name = "labelFAAForm";
			this.labelFAAForm.Size = new System.Drawing.Size(72, 14);
			this.labelFAAForm.TabIndex = 73;
			this.labelFAAForm.Text = "CRS Form:";
			this.labelFAAForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManHours
			// 
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(4, 9);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(119, 25);
			this.labelManHours.TabIndex = 75;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManHours
			// 
			this.textBoxManHours.BackColor = System.Drawing.Color.White;
			this.textBoxManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManHours.Location = new System.Drawing.Point(154, 9);
			this.textBoxManHours.Name = "textBoxManHours";
			this.textBoxManHours.Size = new System.Drawing.Size(350, 22);
			this.textBoxManHours.TabIndex = 76;
			// 
			// labelCostNew
			// 
			this.labelCostNew.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostNew.Location = new System.Drawing.Point(4, 38);
			this.labelCostNew.Name = "labelCostNew";
			this.labelCostNew.Size = new System.Drawing.Size(119, 25);
			this.labelCostNew.TabIndex = 77;
			this.labelCostNew.Text = "Cost new:";
			this.labelCostNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCost
			// 
			this.textBoxCost.BackColor = System.Drawing.Color.White;
			this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCost.Location = new System.Drawing.Point(154, 38);
			this.textBoxCost.Name = "textBoxCost";
			this.textBoxCost.Size = new System.Drawing.Size(350, 22);
			this.textBoxCost.TabIndex = 78;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(544, 9);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(121, 25);
			this.labelKitRequired.TabIndex = 79;
			this.labelKitRequired.Text = "Part and Material:";
			this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Location = new System.Drawing.Point(693, 9);
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(306, 22);
			this.textBoxKitRequired.TabIndex = 80;
			// 
			// labelCostOverhaul
			// 
			this.labelCostOverhaul.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostOverhaul.Location = new System.Drawing.Point(3, 66);
			this.labelCostOverhaul.Name = "labelCostOverhaul";
			this.labelCostOverhaul.Size = new System.Drawing.Size(120, 25);
			this.labelCostOverhaul.TabIndex = 81;
			this.labelCostOverhaul.Text = "Cost Overhaul:";
			this.labelCostOverhaul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCostOverhaul
			// 
			this.textBoxCostOverhaul.BackColor = System.Drawing.Color.White;
			this.textBoxCostOverhaul.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCostOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCostOverhaul.Location = new System.Drawing.Point(154, 66);
			this.textBoxCostOverhaul.Name = "textBoxCostOverhaul";
			this.textBoxCostOverhaul.Size = new System.Drawing.Size(350, 22);
			this.textBoxCostOverhaul.TabIndex = 82;
			// 
			// labelCostServicible
			// 
			this.labelCostServicible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostServicible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostServicible.Location = new System.Drawing.Point(3, 95);
			this.labelCostServicible.Name = "labelCostServicible";
			this.labelCostServicible.Size = new System.Drawing.Size(120, 25);
			this.labelCostServicible.TabIndex = 83;
			this.labelCostServicible.Text = "Cost Serviceable:";
			this.labelCostServicible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCostServicible
			// 
			this.textBoxCostServicible.BackColor = System.Drawing.Color.White;
			this.textBoxCostServicible.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCostServicible.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCostServicible.Location = new System.Drawing.Point(154, 97);
			this.textBoxCostServicible.Name = "textBoxCostServicible";
			this.textBoxCostServicible.Size = new System.Drawing.Size(350, 22);
			this.textBoxCostServicible.TabIndex = 84;
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(543, 140);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(122, 30);
			this.labelHiddenRemarks.TabIndex = 87;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
			this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHiddenRemarks
			// 
			this.textBoxHiddenRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(693, 140);
			this.textBoxHiddenRemarks.MaxLength = 34000;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(350, 71);
			this.textBoxHiddenRemarks.TabIndex = 88;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(3, 140);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(144, 25);
			this.labelRemarks.TabIndex = 85;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(154, 140);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(350, 70);
			this.textBoxRemarks.TabIndex = 86;
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(1006, 7);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 89;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// panelWarranty
			// 
			this.panelWarranty.Controls.Add(this.lifelengthViewerWarranty);
			this.panelWarranty.Controls.Add(this.lifelengthViewerWarrantyNotify);
			this.panelWarranty.Location = new System.Drawing.Point(3, 69);
			this.panelWarranty.Name = "panelWarranty";
			this.panelWarranty.Size = new System.Drawing.Size(1048, 38);
			this.panelWarranty.TabIndex = 90;
			// 
			// panelComponentCurrent
			// 
			this.panelComponentCurrent.Controls.Add(this.lifelengthTCSNOnInstall);
			this.panelComponentCurrent.Location = new System.Drawing.Point(3, 3);
			this.panelComponentCurrent.Name = "panelComponentCurrent";
			this.panelComponentCurrent.Size = new System.Drawing.Size(1048, 60);
			this.panelComponentCurrent.TabIndex = 91;
			// 
			// flowLayoutPanelLifeLimit
			// 
			this.flowLayoutPanelLifeLimit.AutoSize = true;
			this.flowLayoutPanelLifeLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelLifeLimit.Controls.Add(this.panelComponentCurrent);
			this.flowLayoutPanelLifeLimit.Controls.Add(this.panelWarranty);
			this.flowLayoutPanelLifeLimit.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelLifeLimit.Location = new System.Drawing.Point(6, 224);
			this.flowLayoutPanelLifeLimit.Name = "flowLayoutPanelLifeLimit";
			this.flowLayoutPanelLifeLimit.Size = new System.Drawing.Size(1054, 110);
			this.flowLayoutPanelLifeLimit.TabIndex = 92;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.Description1 = "";
			this.fileControl.Description2 = "";
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControl.Location = new System.Drawing.Point(693, 38);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 93;
			this.fileControl.Visible = false;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(693, 37);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(350, 41);
			this.documentControl1.TabIndex = 94;
			// 
			// ComponentComplianceLifeLimitControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(this.flowLayoutPanelLifeLimit);
			this.Controls.Add(this.linkLabelEditKit);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.textBoxHiddenRemarks);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelCostServicible);
			this.Controls.Add(this.textBoxCostServicible);
			this.Controls.Add(this.labelCostOverhaul);
			this.Controls.Add(this.textBoxCostOverhaul);
			this.Controls.Add(this.labelManHours);
			this.Controls.Add(this.textBoxManHours);
			this.Controls.Add(this.labelCostNew);
			this.Controls.Add(this.textBoxCost);
			this.Controls.Add(this.labelKitRequired);
			this.Controls.Add(this.textBoxKitRequired);
			this.Controls.Add(this.labelFAAForm);
			this.Name = "ComponentComplianceLifeLimitControl";
			this.Size = new System.Drawing.Size(1063, 337);
			this.panelWarranty.ResumeLayout(false);
			this.panelWarranty.PerformLayout();
			this.panelComponentCurrent.ResumeLayout(false);
			this.panelComponentCurrent.PerformLayout();
			this.flowLayoutPanelLifeLimit.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerWarrantyNotify;
        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerWarranty;
        private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthTCSNOnInstall;
        private System.Windows.Forms.Label labelFAAForm;
        private System.Windows.Forms.Label labelManHours;
        private System.Windows.Forms.TextBox textBoxManHours;
        private System.Windows.Forms.Label labelCostNew;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Label labelKitRequired;
        private System.Windows.Forms.TextBox textBoxKitRequired;
        private System.Windows.Forms.Label labelCostOverhaul;
        private System.Windows.Forms.TextBox textBoxCostOverhaul;
        private System.Windows.Forms.Label labelCostServicible;
        private System.Windows.Forms.TextBox textBoxCostServicible;
        private System.Windows.Forms.Label labelHiddenRemarks;
        private System.Windows.Forms.TextBox textBoxHiddenRemarks;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        public System.Windows.Forms.LinkLabel linkLabelEditKit;
        private System.Windows.Forms.Panel panelWarranty;
        private System.Windows.Forms.Panel panelComponentCurrent;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLifeLimit;
        private Auxiliary.AttachedFileControl fileControl;
		private DocumentationControls.DocumentControl documentControl1;
	}
}
