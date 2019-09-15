using AvControls.StatusImageLink;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.ComponentControls
{
	partial class ComponentCompliancePerformanceControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (lookupComboboxMaintenanceDirective != null)
			{
				lookupComboboxMaintenanceDirective.CancelAsync();
				lookupComboboxMaintenanceDirective.SelectedIndexChanged -= LookupComboboxMaintenanceDirectiveSelectedIndexChanged;
			}
			if (disposing)
			{
				comboBoxMpdTaskType.Items.Clear();
				comboBoxWorkType.Items.Clear();
				comboBoxWorkType.SelectedIndexChanged -= ComboBoxWorkTypeSelectedIndexChanged;
				linkLabelJobCard.LinkClicked -= LinkLabelJobCardLinkClicked;
				linkLabelRemove.LinkClicked -= LinkLabelClearLinkClicked;
				linkLabelEditKit.LinkClicked -= LinkLabelEditKitLinkClicked;
				checkBoxClose.CheckedChanged -= CheckBoxCloseCheckedChanged;
				extendableRichContainer.Extending -= ExtendableRichContainerExtending;
			}
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
			this.labelParagraph = new System.Windows.Forms.Label();
			this.textBoxParagraph = new System.Windows.Forms.TextBox();
			this.labelManHours = new System.Windows.Forms.Label();
			this.labelCost = new System.Windows.Forms.Label();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxManHours = new System.Windows.Forms.TextBox();
			this.textBoxCost = new System.Windows.Forms.TextBox();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.linkLabelJobCard = new System.Windows.Forms.LinkLabel();
			this.lifelengthViewerRptInterval = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerRptNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarrantyNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
			this.labelFAAForm = new System.Windows.Forms.Label();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstPerformance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.radio_WhicheverLater = new System.Windows.Forms.RadioButton();
			this.radio_WhicheverFirst = new System.Windows.Forms.RadioButton();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.checkBoxClose = new System.Windows.Forms.CheckBox();
			this.groupBoxClose = new System.Windows.Forms.GroupBox();
			this._mainPanel = new System.Windows.Forms.Panel();
			this.textBoxCMM = new System.Windows.Forms.TextBox();
			this.labelCMM = new System.Windows.Forms.Label();
			this.textBoxAAM = new System.Windows.Forms.TextBox();
			this.labelAMM = new System.Windows.Forms.Label();
			this.textBoxAcess = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxZoneArea = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxRelationType = new System.Windows.Forms.ComboBox();
			this.comboBoxNdt = new System.Windows.Forms.ComboBox();
			this.labelNdt = new System.Windows.Forms.Label();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.labelMPDTaskType = new System.Windows.Forms.Label();
			this.lookupComboboxMaintenanceDirective = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelMPDItem = new System.Windows.Forms.Label();
			this.comboBoxMpdTaskType = new System.Windows.Forms.ComboBox();
			this.labelEffectivityDate = new System.Windows.Forms.Label();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelExtendable = new System.Windows.Forms.Panel();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.groupBoxClose.SuspendLayout();
			this._mainPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelExtendable.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageLinkLabelStatus
			// 
			this.imageLinkLabelStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
			this.imageLinkLabelStatus.Enabled = false;
			this.imageLinkLabelStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.imageLinkLabelStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.imageLinkLabelStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.imageLinkLabelStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.imageLinkLabelStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.imageLinkLabelStatus.Location = new System.Drawing.Point(10, 7);
			this.imageLinkLabelStatus.Margin = new System.Windows.Forms.Padding(2);
			this.imageLinkLabelStatus.Name = "imageLinkLabelStatus";
			this.imageLinkLabelStatus.Size = new System.Drawing.Size(146, 20);
			this.imageLinkLabelStatus.TabIndex = 0;
			this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// comboBoxWorkType
			// 
			this.comboBoxWorkType.BackColor = System.Drawing.Color.White;
			this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkType.Location = new System.Drawing.Point(156, 5);
			this.comboBoxWorkType.Name = "comboBoxWorkType";
			this.comboBoxWorkType.Size = new System.Drawing.Size(263, 22);
			this.comboBoxWorkType.TabIndex = 26;
			this.comboBoxWorkType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWorkTypeSelectedIndexChanged);
			this.comboBoxWorkType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelParagraph
			// 
			this.labelParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelParagraph.Location = new System.Drawing.Point(425, 3);
			this.labelParagraph.Name = "labelParagraph";
			this.labelParagraph.Size = new System.Drawing.Size(30, 25);
			this.labelParagraph.TabIndex = 27;
			this.labelParagraph.Text = "§:";
			this.labelParagraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxParagraph
			// 
			this.textBoxParagraph.BackColor = System.Drawing.Color.White;
			this.textBoxParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxParagraph.Location = new System.Drawing.Point(461, 5);
			this.textBoxParagraph.MaxLength = 4;
			this.textBoxParagraph.Name = "textBoxParagraph";
			this.textBoxParagraph.Size = new System.Drawing.Size(46, 22);
			this.textBoxParagraph.TabIndex = 28;
			// 
			// labelManHours
			// 
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(5, 198);
			this.labelManHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(150, 25);
			this.labelManHours.TabIndex = 1;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCost
			// 
			this.labelCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(5, 228);
			this.labelCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(150, 25);
			this.labelCost.TabIndex = 3;
			this.labelCost.Text = "Cost (USD):";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(546, 88);
			this.labelKitRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(93, 25);
			this.labelKitRequired.TabIndex = 5;
			this.labelKitRequired.Text = "Kit Required:";
			this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(5, 299);
			this.labelRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(150, 20);
			this.labelRemarks.TabIndex = 7;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManHours
			// 
			this.textBoxManHours.BackColor = System.Drawing.Color.White;
			this.textBoxManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManHours.Location = new System.Drawing.Point(155, 198);
			this.textBoxManHours.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxManHours.Name = "textBoxManHours";
			this.textBoxManHours.Size = new System.Drawing.Size(350, 22);
			this.textBoxManHours.TabIndex = 2;
			// 
			// textBoxCost
			// 
			this.textBoxCost.BackColor = System.Drawing.Color.White;
			this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCost.Location = new System.Drawing.Point(155, 230);
			this.textBoxCost.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCost.Name = "textBoxCost";
			this.textBoxCost.Size = new System.Drawing.Size(350, 22);
			this.textBoxCost.TabIndex = 4;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Location = new System.Drawing.Point(696, 88);
			this.textBoxKitRequired.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(306, 22);
			this.textBoxKitRequired.TabIndex = 6;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(155, 299);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(350, 75);
			this.textBoxRemarks.TabIndex = 8;
			// 
			// linkLabelJobCard
			// 
			this.linkLabelJobCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelJobCard.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelJobCard.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelJobCard.Location = new System.Drawing.Point(153, 584);
			this.linkLabelJobCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelJobCard.Name = "linkLabelJobCard";
			this.linkLabelJobCard.Size = new System.Drawing.Size(64, 20);
			this.linkLabelJobCard.TabIndex = 9;
			this.linkLabelJobCard.TabStop = true;
			this.linkLabelJobCard.Text = "Job Card";
			this.linkLabelJobCard.Visible = false;
			this.linkLabelJobCard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelJobCardLinkClicked);
			// 
			// lifelengthViewerRptInterval
			// 
			this.lifelengthViewerRptInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerRptInterval.AutoSize = true;
			this.lifelengthViewerRptInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRptInterval.CalendarApplicable = false;
			this.lifelengthViewerRptInterval.CyclesApplicable = false;
			this.lifelengthViewerRptInterval.EnabledCalendar = true;
			this.lifelengthViewerRptInterval.EnabledCycle = true;
			this.lifelengthViewerRptInterval.EnabledHours = true;
			this.lifelengthViewerRptInterval.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRptInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerRptInterval.HeaderCalendar = "Calendar";
			this.lifelengthViewerRptInterval.HeaderCycles = "Cycles";
			this.lifelengthViewerRptInterval.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerRptInterval.HeaderHours = "Hours";
			this.lifelengthViewerRptInterval.HoursApplicable = false;
			this.lifelengthViewerRptInterval.LeftHeader = "Repeat every:";
			this.lifelengthViewerRptInterval.Location = new System.Drawing.Point(42, 463);
			this.lifelengthViewerRptInterval.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRptInterval.Modified = false;
			this.lifelengthViewerRptInterval.Name = "lifelengthViewerRptInterval";
			this.lifelengthViewerRptInterval.ReadOnly = false;
			this.lifelengthViewerRptInterval.ShowCalendar = true;
			this.lifelengthViewerRptInterval.ShowFormattedCalendar = false;
			this.lifelengthViewerRptInterval.ShowHeaders = false;
			this.lifelengthViewerRptInterval.ShowMinutes = false;
			this.lifelengthViewerRptInterval.Size = new System.Drawing.Size(464, 35);
			this.lifelengthViewerRptInterval.SystemCalculated = true;
			this.lifelengthViewerRptInterval.TabIndex = 12;
			// 
			// lifelengthViewerRptNotify
			// 
			this.lifelengthViewerRptNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerRptNotify.AutoSize = true;
			this.lifelengthViewerRptNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRptNotify.CalendarApplicable = false;
			this.lifelengthViewerRptNotify.CyclesApplicable = false;
			this.lifelengthViewerRptNotify.EnabledCalendar = true;
			this.lifelengthViewerRptNotify.EnabledCycle = true;
			this.lifelengthViewerRptNotify.EnabledHours = true;
			this.lifelengthViewerRptNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRptNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerRptNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerRptNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerRptNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerRptNotify.HeaderHours = "Hours";
			this.lifelengthViewerRptNotify.HoursApplicable = false;
			this.lifelengthViewerRptNotify.LeftHeader = "Notify:";
			this.lifelengthViewerRptNotify.Location = new System.Drawing.Point(632, 463);
			this.lifelengthViewerRptNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRptNotify.Modified = false;
			this.lifelengthViewerRptNotify.Name = "lifelengthViewerRptNotify";
			this.lifelengthViewerRptNotify.ReadOnly = false;
			this.lifelengthViewerRptNotify.ShowCalendar = true;
			this.lifelengthViewerRptNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerRptNotify.ShowHeaders = false;
			this.lifelengthViewerRptNotify.ShowMinutes = false;
			this.lifelengthViewerRptNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerRptNotify.SystemCalculated = true;
			this.lifelengthViewerRptNotify.TabIndex = 14;
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
			this.lifelengthViewerWarranty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerWarranty.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderCycles = "Cycles";
			this.lifelengthViewerWarranty.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderHours = "Hours";
			this.lifelengthViewerWarranty.HoursApplicable = false;
			this.lifelengthViewerWarranty.LeftHeader = "Warranty:";
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(70, 502);
			this.lifelengthViewerWarranty.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerWarranty.Modified = false;
			this.lifelengthViewerWarranty.Name = "lifelengthViewerWarranty";
			this.lifelengthViewerWarranty.ReadOnly = false;
			this.lifelengthViewerWarranty.ShowCalendar = true;
			this.lifelengthViewerWarranty.ShowFormattedCalendar = false;
			this.lifelengthViewerWarranty.ShowHeaders = false;
			this.lifelengthViewerWarranty.ShowMinutes = false;
			this.lifelengthViewerWarranty.Size = new System.Drawing.Size(437, 35);
			this.lifelengthViewerWarranty.SystemCalculated = true;
			this.lifelengthViewerWarranty.TabIndex = 17;
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
			this.lifelengthViewerWarrantyNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerWarrantyNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerWarrantyNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderHours = "Hours";
			this.lifelengthViewerWarrantyNotify.HoursApplicable = false;
			this.lifelengthViewerWarrantyNotify.LeftHeader = "Notify:";
			this.lifelengthViewerWarrantyNotify.Location = new System.Drawing.Point(632, 502);
			this.lifelengthViewerWarrantyNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerWarrantyNotify.Modified = false;
			this.lifelengthViewerWarrantyNotify.Name = "lifelengthViewerWarrantyNotify";
			this.lifelengthViewerWarrantyNotify.ReadOnly = false;
			this.lifelengthViewerWarrantyNotify.ShowCalendar = true;
			this.lifelengthViewerWarrantyNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerWarrantyNotify.ShowHeaders = false;
			this.lifelengthViewerWarrantyNotify.ShowMinutes = false;
			this.lifelengthViewerWarrantyNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerWarrantyNotify.SystemCalculated = true;
			this.lifelengthViewerWarrantyNotify.TabIndex = 19;
			// 
			// linkLabelRemove
			// 
			this.linkLabelRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelRemove.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemove.Location = new System.Drawing.Point(509, 606);
			this.linkLabelRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelRemove.Name = "linkLabelRemove";
			this.linkLabelRemove.Size = new System.Drawing.Size(120, 24);
			this.linkLabelRemove.TabIndex = 20;
			this.linkLabelRemove.TabStop = true;
			this.linkLabelRemove.Text = "Remove";
			this.linkLabelRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClearLinkClicked);
			// 
			// labelFAAForm
			// 
			this.labelFAAForm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFAAForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFAAForm.Location = new System.Drawing.Point(546, 120);
			this.labelFAAForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelFAAForm.Name = "labelFAAForm";
			this.labelFAAForm.Size = new System.Drawing.Size(83, 20);
			this.labelFAAForm.TabIndex = 53;
			this.labelFAAForm.Text = "CRS Form:";
			this.labelFAAForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(547, 297);
			this.labelHiddenRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(145, 24);
			this.labelHiddenRemarks.TabIndex = 57;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
			this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxHiddenRemarks
			// 
			this.textBoxHiddenRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(696, 299);
			this.textBoxHiddenRemarks.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHiddenRemarks.MaxLength = 34000;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(350, 75);
			this.textBoxHiddenRemarks.TabIndex = 58;
			// 
			// lifelengthViewer_FirstNotify
			// 
			this.lifelengthViewer_FirstNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_FirstNotify.AutoSize = true;
			this.lifelengthViewer_FirstNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_FirstNotify.CalendarApplicable = false;
			this.lifelengthViewer_FirstNotify.CyclesApplicable = false;
			this.lifelengthViewer_FirstNotify.EnabledCalendar = true;
			this.lifelengthViewer_FirstNotify.EnabledCycle = true;
			this.lifelengthViewer_FirstNotify.EnabledHours = true;
			this.lifelengthViewer_FirstNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_FirstNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
			this.lifelengthViewer_FirstNotify.HoursApplicable = false;
			this.lifelengthViewer_FirstNotify.LeftHeader = "Notify:";
			this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(632, 407);
			this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstNotify.Modified = false;
			this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
			this.lifelengthViewer_FirstNotify.ReadOnly = false;
			this.lifelengthViewer_FirstNotify.ShowCalendar = true;
			this.lifelengthViewer_FirstNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstNotify.ShowMinutes = false;
			this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(413, 52);
			this.lifelengthViewer_FirstNotify.SystemCalculated = true;
			this.lifelengthViewer_FirstNotify.TabIndex = 60;
			// 
			// lifelengthViewer_FirstPerformance
			// 
			this.lifelengthViewer_FirstPerformance.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_FirstPerformance.AutoSize = true;
			this.lifelengthViewer_FirstPerformance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_FirstPerformance.CalendarApplicable = false;
			this.lifelengthViewer_FirstPerformance.CyclesApplicable = false;
			this.lifelengthViewer_FirstPerformance.EnabledCalendar = true;
			this.lifelengthViewer_FirstPerformance.EnabledCycle = true;
			this.lifelengthViewer_FirstPerformance.EnabledHours = true;
			this.lifelengthViewer_FirstPerformance.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_FirstPerformance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewer_FirstPerformance.HeaderCalendar = "Calendar";
			this.lifelengthViewer_FirstPerformance.HeaderCycles = "Cycles";
			this.lifelengthViewer_FirstPerformance.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_FirstPerformance.HeaderHours = "Hours";
			this.lifelengthViewer_FirstPerformance.HoursApplicable = false;
			this.lifelengthViewer_FirstPerformance.LeftHeader = "Perform at:";
			this.lifelengthViewer_FirstPerformance.Location = new System.Drawing.Point(59, 408);
			this.lifelengthViewer_FirstPerformance.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstPerformance.Modified = false;
			this.lifelengthViewer_FirstPerformance.Name = "lifelengthViewer_FirstPerformance";
			this.lifelengthViewer_FirstPerformance.ReadOnly = false;
			this.lifelengthViewer_FirstPerformance.ShowCalendar = true;
			this.lifelengthViewer_FirstPerformance.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstPerformance.ShowMinutes = false;
			this.lifelengthViewer_FirstPerformance.Size = new System.Drawing.Size(446, 52);
			this.lifelengthViewer_FirstPerformance.SystemCalculated = true;
			this.lifelengthViewer_FirstPerformance.TabIndex = 59;
			// 
			// radio_WhicheverLater
			// 
			this.radio_WhicheverLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.radio_WhicheverLater.AutoSize = true;
			this.radio_WhicheverLater.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radio_WhicheverLater.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radio_WhicheverLater.Location = new System.Drawing.Point(622, 586);
			this.radio_WhicheverLater.Margin = new System.Windows.Forms.Padding(2);
			this.radio_WhicheverLater.Name = "radio_WhicheverLater";
			this.radio_WhicheverLater.Size = new System.Drawing.Size(128, 18);
			this.radio_WhicheverLater.TabIndex = 62;
			this.radio_WhicheverLater.Text = "Whichever Later";
			this.radio_WhicheverLater.UseVisualStyleBackColor = true;
			// 
			// radio_WhicheverFirst
			// 
			this.radio_WhicheverFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.radio_WhicheverFirst.AutoSize = true;
			this.radio_WhicheverFirst.Checked = true;
			this.radio_WhicheverFirst.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radio_WhicheverFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radio_WhicheverFirst.Location = new System.Drawing.Point(392, 586);
			this.radio_WhicheverFirst.Margin = new System.Windows.Forms.Padding(2);
			this.radio_WhicheverFirst.Name = "radio_WhicheverFirst";
			this.radio_WhicheverFirst.Size = new System.Drawing.Size(122, 18);
			this.radio_WhicheverFirst.TabIndex = 61;
			this.radio_WhicheverFirst.TabStop = true;
			this.radio_WhicheverFirst.Text = "Whichever First";
			this.radio_WhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(1008, 86);
			this.linkLabelEditKit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 63;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// checkBoxClose
			// 
			this.checkBoxClose.AutoSize = true;
			this.checkBoxClose.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxClose.Location = new System.Drawing.Point(8, 21);
			this.checkBoxClose.Name = "checkBoxClose";
			this.checkBoxClose.Size = new System.Drawing.Size(68, 22);
			this.checkBoxClose.TabIndex = 25;
			this.checkBoxClose.Text = "Close";
			this.checkBoxClose.UseVisualStyleBackColor = true;
			this.checkBoxClose.CheckedChanged += new System.EventHandler(this.CheckBoxCloseCheckedChanged);
			// 
			// groupBoxClose
			// 
			this.groupBoxClose.Controls.Add(this.checkBoxClose);
			this.groupBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.groupBoxClose.Location = new System.Drawing.Point(1050, 413);
			this.groupBoxClose.Name = "groupBoxClose";
			this.groupBoxClose.Size = new System.Drawing.Size(86, 161);
			this.groupBoxClose.TabIndex = 64;
			this.groupBoxClose.TabStop = false;
			this.groupBoxClose.Text = "STATUS";
			// 
			// _mainPanel
			// 
			this._mainPanel.Controls.Add(this.textBoxCMM);
			this._mainPanel.Controls.Add(this.labelCMM);
			this._mainPanel.Controls.Add(this.textBoxAAM);
			this._mainPanel.Controls.Add(this.labelAMM);
			this._mainPanel.Controls.Add(this.textBoxAcess);
			this._mainPanel.Controls.Add(this.label3);
			this._mainPanel.Controls.Add(this.textBoxZoneArea);
			this._mainPanel.Controls.Add(this.label2);
			this._mainPanel.Controls.Add(this.documentControl1);
			this._mainPanel.Controls.Add(this.label1);
			this._mainPanel.Controls.Add(this.comboBoxRelationType);
			this._mainPanel.Controls.Add(this.comboBoxNdt);
			this._mainPanel.Controls.Add(this.labelNdt);
			this._mainPanel.Controls.Add(this.fileControl);
			this._mainPanel.Controls.Add(this.labelMPDTaskType);
			this._mainPanel.Controls.Add(this.lookupComboboxMaintenanceDirective);
			this._mainPanel.Controls.Add(this.labelMPDItem);
			this._mainPanel.Controls.Add(this.comboBoxMpdTaskType);
			this._mainPanel.Controls.Add(this.labelEffectivityDate);
			this._mainPanel.Controls.Add(this.dateTimePickerEffDate);
			this._mainPanel.Controls.Add(this.imageLinkLabelStatus);
			this._mainPanel.Controls.Add(this.groupBoxClose);
			this._mainPanel.Controls.Add(this.lifelengthViewerWarrantyNotify);
			this._mainPanel.Controls.Add(this.linkLabelEditKit);
			this._mainPanel.Controls.Add(this.lifelengthViewerWarranty);
			this._mainPanel.Controls.Add(this.labelParagraph);
			this._mainPanel.Controls.Add(this.lifelengthViewerRptNotify);
			this._mainPanel.Controls.Add(this.textBoxParagraph);
			this._mainPanel.Controls.Add(this.lifelengthViewerRptInterval);
			this._mainPanel.Controls.Add(this.comboBoxWorkType);
			this._mainPanel.Controls.Add(this.linkLabelRemove);
			this._mainPanel.Controls.Add(this.radio_WhicheverLater);
			this._mainPanel.Controls.Add(this.linkLabelJobCard);
			this._mainPanel.Controls.Add(this.radio_WhicheverFirst);
			this._mainPanel.Controls.Add(this.textBoxRemarks);
			this._mainPanel.Controls.Add(this.lifelengthViewer_FirstNotify);
			this._mainPanel.Controls.Add(this.labelRemarks);
			this._mainPanel.Controls.Add(this.lifelengthViewer_FirstPerformance);
			this._mainPanel.Controls.Add(this.textBoxKitRequired);
			this._mainPanel.Controls.Add(this.labelHiddenRemarks);
			this._mainPanel.Controls.Add(this.labelKitRequired);
			this._mainPanel.Controls.Add(this.textBoxHiddenRemarks);
			this._mainPanel.Controls.Add(this.textBoxCost);
			this._mainPanel.Controls.Add(this.labelCost);
			this._mainPanel.Controls.Add(this.labelFAAForm);
			this._mainPanel.Controls.Add(this.textBoxManHours);
			this._mainPanel.Controls.Add(this.labelManHours);
			this._mainPanel.Location = new System.Drawing.Point(3, 55);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(1143, 612);
			this._mainPanel.TabIndex = 65;
			this._mainPanel.Visible = false;
			// 
			// textBoxCMM
			// 
			this.textBoxCMM.BackColor = System.Drawing.Color.White;
			this.textBoxCMM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCMM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCMM.Location = new System.Drawing.Point(156, 171);
			this.textBoxCMM.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCMM.Name = "textBoxCMM";
			this.textBoxCMM.Size = new System.Drawing.Size(350, 22);
			this.textBoxCMM.TabIndex = 206;
			// 
			// labelCMM
			// 
			this.labelCMM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCMM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCMM.Location = new System.Drawing.Point(6, 171);
			this.labelCMM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCMM.Name = "labelCMM";
			this.labelCMM.Size = new System.Drawing.Size(150, 25);
			this.labelCMM.TabIndex = 205;
			this.labelCMM.Text = "CMM Ref:";
			this.labelCMM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAAM
			// 
			this.textBoxAAM.BackColor = System.Drawing.Color.White;
			this.textBoxAAM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxAAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAAM.Location = new System.Drawing.Point(156, 145);
			this.textBoxAAM.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxAAM.Name = "textBoxAAM";
			this.textBoxAAM.Size = new System.Drawing.Size(350, 22);
			this.textBoxAAM.TabIndex = 204;
			// 
			// labelAMM
			// 
			this.labelAMM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAMM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAMM.Location = new System.Drawing.Point(6, 145);
			this.labelAMM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAMM.Name = "labelAMM";
			this.labelAMM.Size = new System.Drawing.Size(150, 25);
			this.labelAMM.TabIndex = 203;
			this.labelAMM.Text = "AMM Ref:";
			this.labelAMM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxAcess
			// 
			this.textBoxAcess.BackColor = System.Drawing.Color.White;
			this.textBoxAcess.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxAcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAcess.Location = new System.Drawing.Point(156, 118);
			this.textBoxAcess.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxAcess.Name = "textBoxAcess";
			this.textBoxAcess.Size = new System.Drawing.Size(350, 22);
			this.textBoxAcess.TabIndex = 202;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(6, 118);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 25);
			this.label3.TabIndex = 201;
			this.label3.Text = "Access:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxZoneArea
			// 
			this.textBoxZoneArea.BackColor = System.Drawing.Color.White;
			this.textBoxZoneArea.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxZoneArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxZoneArea.Location = new System.Drawing.Point(156, 91);
			this.textBoxZoneArea.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxZoneArea.Name = "textBoxZoneArea";
			this.textBoxZoneArea.Size = new System.Drawing.Size(350, 22);
			this.textBoxZoneArea.TabIndex = 200;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(6, 91);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 25);
			this.label2.TabIndex = 199;
			this.label2.Text = "Zone-area:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(696, 116);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(349, 41);
			this.documentControl1.TabIndex = 198;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(35, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 14);
			this.label1.TabIndex = 197;
			this.label1.Text = "Work type:";
			// 
			// comboBoxRelationType
			// 
			this.comboBoxRelationType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxRelationType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxRelationType.FormattingEnabled = true;
			this.comboBoxRelationType.Location = new System.Drawing.Point(156, 61);
			this.comboBoxRelationType.Name = "comboBoxRelationType";
			this.comboBoxRelationType.Size = new System.Drawing.Size(351, 22);
			this.comboBoxRelationType.TabIndex = 196;
			this.comboBoxRelationType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxNdt
			// 
			this.comboBoxNdt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxNdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxNdt.FormattingEnabled = true;
			this.comboBoxNdt.Location = new System.Drawing.Point(696, 6);
			this.comboBoxNdt.Name = "comboBoxNdt";
			this.comboBoxNdt.Size = new System.Drawing.Size(306, 22);
			this.comboBoxNdt.TabIndex = 194;
			this.comboBoxNdt.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelNdt
			// 
			this.labelNdt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNdt.Location = new System.Drawing.Point(546, 8);
			this.labelNdt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelNdt.Name = "labelNdt";
			this.labelNdt.Size = new System.Drawing.Size(135, 20);
			this.labelNdt.TabIndex = 193;
			this.labelNdt.Text = "NDT";
			this.labelNdt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.Description1 = "";
			this.fileControl.Description2 = "";
			this.fileControl.Filter = null;
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControl.Location = new System.Drawing.Point(695, 118);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 67;
			this.fileControl.Visible = false;
			// 
			// labelMPDTaskType
			// 
			this.labelMPDTaskType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMPDTaskType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDTaskType.Location = new System.Drawing.Point(546, 33);
			this.labelMPDTaskType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMPDTaskType.Name = "labelMPDTaskType";
			this.labelMPDTaskType.Size = new System.Drawing.Size(111, 20);
			this.labelMPDTaskType.TabIndex = 192;
			this.labelMPDTaskType.Text = "MPD Work Type:";
			this.labelMPDTaskType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lookupComboboxMaintenanceDirective
			// 
			this.lookupComboboxMaintenanceDirective.ButtonCreateVisible = false;
			this.lookupComboboxMaintenanceDirective.Displayer = null;
			this.lookupComboboxMaintenanceDirective.DisplayerText = null;
			this.lookupComboboxMaintenanceDirective.Entity = null;
			this.lookupComboboxMaintenanceDirective.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxMaintenanceDirective.Location = new System.Drawing.Point(156, 33);
			this.lookupComboboxMaintenanceDirective.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lookupComboboxMaintenanceDirective.Name = "lookupComboboxMaintenanceDirective";
			this.lookupComboboxMaintenanceDirective.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxMaintenanceDirective.Size = new System.Drawing.Size(351, 22);
			this.lookupComboboxMaintenanceDirective.TabIndex = 190;
			this.lookupComboboxMaintenanceDirective.Type = null;
			this.lookupComboboxMaintenanceDirective.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxMaintenanceDirectiveSelectedIndexChanged);
			this.lookupComboboxMaintenanceDirective.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelMPDItem
			// 
			this.labelMPDItem.AutoSize = true;
			this.labelMPDItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItem.Location = new System.Drawing.Point(6, 36);
			this.labelMPDItem.Name = "labelMPDItem";
			this.labelMPDItem.Size = new System.Drawing.Size(63, 14);
			this.labelMPDItem.TabIndex = 191;
			this.labelMPDItem.Text = "For MPD:";
			// 
			// comboBoxMpdTaskType
			// 
			this.comboBoxMpdTaskType.BackColor = System.Drawing.Color.White;
			this.comboBoxMpdTaskType.Enabled = false;
			this.comboBoxMpdTaskType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxMpdTaskType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxMpdTaskType.Location = new System.Drawing.Point(695, 33);
			this.comboBoxMpdTaskType.Name = "comboBoxMpdTaskType";
			this.comboBoxMpdTaskType.Size = new System.Drawing.Size(350, 22);
			this.comboBoxMpdTaskType.TabIndex = 68;
			this.comboBoxMpdTaskType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.AutoSize = true;
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(5, 268);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(131, 17);
			this.labelEffectivityDate.TabIndex = 65;
			this.labelEffectivityDate.Text = "Conserv-n. Date:";
			this.labelEffectivityDate.Visible = false;
			// 
			// dateTimePickerEffDate
			// 
			this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(155, 262);
			this.dateTimePickerEffDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 25);
			this.dateTimePickerEffDate.TabIndex = 66;
			this.dateTimePickerEffDate.Visible = false;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.panelExtendable);
			this.flowLayoutPanel1.Controls.Add(this._mainPanel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1149, 670);
			this.flowLayoutPanel1.TabIndex = 66;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// panelExtendable
			// 
			this.panelExtendable.Controls.Add(this.extendableRichContainer);
			this.panelExtendable.Location = new System.Drawing.Point(3, 3);
			this.panelExtendable.Name = "panelExtendable";
			this.panelExtendable.Size = new System.Drawing.Size(1143, 46);
			this.panelExtendable.TabIndex = 36;
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = null;
			this.extendableRichContainer.AfterCaptionControl2 = null;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Directive Performance";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = false;
			this.extendableRichContainer.Location = new System.Drawing.Point(9, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(373, 40);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// ComponentCompliancePerformanceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.flowLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ComponentCompliancePerformanceControl";
			this.Size = new System.Drawing.Size(1149, 670);
			this.groupBoxClose.ResumeLayout(false);
			this.groupBoxClose.PerformLayout();
			this._mainPanel.ResumeLayout(false);
			this._mainPanel.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panelExtendable.ResumeLayout(false);
			this.panelExtendable.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private StatusImageLinkLabel imageLinkLabelStatus;
		private System.Windows.Forms.Label labelParagraph;
		private System.Windows.Forms.TextBox textBoxParagraph;
		private System.Windows.Forms.ComboBox comboBoxWorkType;
		private System.Windows.Forms.Label labelManHours;
		private System.Windows.Forms.Label labelCost;
		private System.Windows.Forms.Label labelKitRequired;
		private System.Windows.Forms.Label labelRemarks;
		private System.Windows.Forms.LinkLabel linkLabelJobCard;
		private System.Windows.Forms.TextBox textBoxManHours;
		private System.Windows.Forms.TextBox textBoxCost;
		private System.Windows.Forms.TextBox textBoxKitRequired;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private LifelengthViewer lifelengthViewerRptInterval;
		private LifelengthViewer lifelengthViewerRptNotify;
		private LifelengthViewer lifelengthViewerWarranty;
		private LifelengthViewer lifelengthViewerWarrantyNotify;
		private System.Windows.Forms.LinkLabel linkLabelRemove;
		private System.Windows.Forms.Label labelFAAForm;
		private System.Windows.Forms.Label labelHiddenRemarks;
		private System.Windows.Forms.TextBox textBoxHiddenRemarks;
		private LifelengthViewer lifelengthViewer_FirstNotify;
		private LifelengthViewer lifelengthViewer_FirstPerformance;
		private System.Windows.Forms.RadioButton radio_WhicheverLater;
		private System.Windows.Forms.RadioButton radio_WhicheverFirst;
		public System.Windows.Forms.LinkLabel linkLabelEditKit;
		private System.Windows.Forms.CheckBox checkBoxClose;
		private System.Windows.Forms.GroupBox groupBoxClose;
		private System.Windows.Forms.Panel _mainPanel;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panelExtendable;
		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.Label labelEffectivityDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerEffDate;
		private System.Windows.Forms.ComboBox comboBoxMpdTaskType;
		private LookupCombobox lookupComboboxMaintenanceDirective;
		private System.Windows.Forms.Label labelMPDItem;
		private System.Windows.Forms.Label labelMPDTaskType;
		private AttachedFileControl fileControl;
		private System.Windows.Forms.ComboBox comboBoxNdt;
		private System.Windows.Forms.Label labelNdt;
		private System.Windows.Forms.ComboBox comboBoxRelationType;
		private System.Windows.Forms.Label label1;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.TextBox textBoxCMM;
		private System.Windows.Forms.Label labelCMM;
		private System.Windows.Forms.TextBox textBoxAAM;
		private System.Windows.Forms.Label labelAMM;
		private System.Windows.Forms.TextBox textBoxAcess;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxZoneArea;
		private System.Windows.Forms.Label label2;
	}
}
