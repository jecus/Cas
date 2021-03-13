using AvControls.StatusImageLink;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceDirectiveParametersControl
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
			if(lookupComboboxMaintenanceCheck != null)
			{
				lookupComboboxMaintenanceCheck.CancelAsync();
				lookupComboboxMaintenanceCheck.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;
			}

			if(checkBoxKitsApplicable != null)
				checkBoxKitsApplicable.CheckedChanged -= new System.EventHandler(checkBoxKitsApplicable_CheckedChanged);

			checkBoxClose.CheckedChanged -= CheckBoxCloseCheckedChanged;
			linkLabelEditKit.LinkClicked -= LinkLabelEditKitLinkClicked;
			linkLabelEditComponents.LinkClicked -= LinkLabelEditComponentsLinkClicked;
		
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
			this.lifelengthViewer_RepeatNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.radio_RepeatWhicheverFirst = new System.Windows.Forms.RadioButton();
			this.groupBox_Repetative = new System.Windows.Forms.GroupBox();
			this.radio_RepeatWhicheverLast = new System.Windows.Forms.RadioButton();
			this.lifelengthViewer_Repeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.groupFirstPerformance = new System.Windows.Forms.GroupBox();
			this.radio_FirstWhicheverLast = new System.Windows.Forms.RadioButton();
			this.radio_FirstWhicheverFirst = new System.Windows.Forms.RadioButton();
			this.lifelengthViewer_SinceEffDate = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_SinceNew = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelThreshold = new System.Windows.Forms.Label();
			this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.labelParagraph = new System.Windows.Forms.Label();
			this.checkBoxClose = new System.Windows.Forms.CheckBox();
			this.groupBoxClose = new System.Windows.Forms.GroupBox();
			this.textBoxParagraph = new System.Windows.Forms.TextBox();
			this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.textBoxCost = new System.Windows.Forms.TextBox();
			this.labelCost = new System.Windows.Forms.Label();
			this.textBoxManHours = new System.Windows.Forms.TextBox();
			this.labelManHours = new System.Windows.Forms.Label();
			this.labelForComponent = new System.Windows.Forms.Label();
			this.textBoxElapsed = new System.Windows.Forms.TextBox();
			this.labelElapsed = new System.Windows.Forms.Label();
			this.labelNDT = new System.Windows.Forms.Label();
			this.lookupComboboxMaintenanceCheck = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelCheck = new System.Windows.Forms.Label();
			this.linkLabelEditComponents = new System.Windows.Forms.LinkLabel();
			this.textBoxComponents = new System.Windows.Forms.TextBox();
			this.comboBoxNdt = new System.Windows.Forms.ComboBox();
			this.checkBoxKitsApplicable = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxSkill = new System.Windows.Forms.ComboBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.textBoxAd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.textBoxMPD = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBoxAPU = new System.Windows.Forms.CheckBox();
			this.checkBoxSBControl = new System.Windows.Forms.CheckBox();
			this.labelSBControl = new System.Windows.Forms.Label();
			this.groupBox_Repetative.SuspendLayout();
			this.groupFirstPerformance.SuspendLayout();
			this.groupBoxClose.SuspendLayout();
			this.SuspendLayout();
			// 
			// lifelengthViewer_RepeatNotify
			// 
			this.lifelengthViewer_RepeatNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_RepeatNotify.AutoSize = true;
			this.lifelengthViewer_RepeatNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_RepeatNotify.CalendarApplicable = false;
			this.lifelengthViewer_RepeatNotify.CyclesApplicable = false;
			this.lifelengthViewer_RepeatNotify.EnabledCalendar = true;
			this.lifelengthViewer_RepeatNotify.EnabledCycle = true;
			this.lifelengthViewer_RepeatNotify.EnabledHours = true;
			this.lifelengthViewer_RepeatNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_RepeatNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_RepeatNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_RepeatNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_RepeatNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_RepeatNotify.HeaderHours = "Hours";
			this.lifelengthViewer_RepeatNotify.HoursApplicable = false;
			this.lifelengthViewer_RepeatNotify.LeftHeader = "Notify";
			this.lifelengthViewer_RepeatNotify.Location = new System.Drawing.Point(93, 76);
			this.lifelengthViewer_RepeatNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_RepeatNotify.Modified = false;
			this.lifelengthViewer_RepeatNotify.Name = "lifelengthViewer_RepeatNotify";
			this.lifelengthViewer_RepeatNotify.ReadOnly = false;
			this.lifelengthViewer_RepeatNotify.ShowCalendar = true;
			this.lifelengthViewer_RepeatNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_RepeatNotify.ShowHeaders = false;
			this.lifelengthViewer_RepeatNotify.ShowMinutes = true;
			this.lifelengthViewer_RepeatNotify.Size = new System.Drawing.Size(407, 35);
			this.lifelengthViewer_RepeatNotify.SystemCalculated = true;
			this.lifelengthViewer_RepeatNotify.TabIndex = 1;
			// 
			// radio_RepeatWhicheverFirst
			// 
			this.radio_RepeatWhicheverFirst.AutoSize = true;
			this.radio_RepeatWhicheverFirst.Checked = true;
			this.radio_RepeatWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_RepeatWhicheverFirst.Location = new System.Drawing.Point(73, 163);
			this.radio_RepeatWhicheverFirst.Name = "radio_RepeatWhicheverFirst";
			this.radio_RepeatWhicheverFirst.Size = new System.Drawing.Size(140, 22);
			this.radio_RepeatWhicheverFirst.TabIndex = 2;
			this.radio_RepeatWhicheverFirst.TabStop = true;
			this.radio_RepeatWhicheverFirst.Text = "Whichever First";
			this.radio_RepeatWhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// groupBox_Repetative
			// 
			this.groupBox_Repetative.AutoSize = true;
			this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverLast);
			this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_RepeatNotify);
			this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverFirst);
			this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_Repeat);
			this.groupBox_Repetative.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox_Repetative.Location = new System.Drawing.Point(510, 250);
			this.groupBox_Repetative.Name = "groupBox_Repetative";
			this.groupBox_Repetative.Size = new System.Drawing.Size(506, 206);
			this.groupBox_Repetative.TabIndex = 9;
			this.groupBox_Repetative.TabStop = false;
			this.groupBox_Repetative.Text = "REPEAT";
			// 
			// radio_RepeatWhicheverLast
			// 
			this.radio_RepeatWhicheverLast.AutoSize = true;
			this.radio_RepeatWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_RepeatWhicheverLast.Location = new System.Drawing.Point(334, 163);
			this.radio_RepeatWhicheverLast.Name = "radio_RepeatWhicheverLast";
			this.radio_RepeatWhicheverLast.Size = new System.Drawing.Size(146, 22);
			this.radio_RepeatWhicheverLast.TabIndex = 3;
			this.radio_RepeatWhicheverLast.Text = "Whichever Later";
			this.radio_RepeatWhicheverLast.UseVisualStyleBackColor = true;
			// 
			// lifelengthViewer_Repeat
			// 
			this.lifelengthViewer_Repeat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_Repeat.AutoSize = true;
			this.lifelengthViewer_Repeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_Repeat.CalendarApplicable = false;
			this.lifelengthViewer_Repeat.CyclesApplicable = false;
			this.lifelengthViewer_Repeat.EnabledCalendar = true;
			this.lifelengthViewer_Repeat.EnabledCycle = true;
			this.lifelengthViewer_Repeat.EnabledHours = true;
			this.lifelengthViewer_Repeat.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_Repeat.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_Repeat.HeaderCalendar = "Calendar";
			this.lifelengthViewer_Repeat.HeaderCycles = "Cycles";
			this.lifelengthViewer_Repeat.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_Repeat.HeaderHours = "Hours";
			this.lifelengthViewer_Repeat.HoursApplicable = false;
			this.lifelengthViewer_Repeat.LeftHeader = "Repeat Interval";
			this.lifelengthViewer_Repeat.Location = new System.Drawing.Point(27, 18);
			this.lifelengthViewer_Repeat.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_Repeat.Modified = false;
			this.lifelengthViewer_Repeat.Name = "lifelengthViewer_Repeat";
			this.lifelengthViewer_Repeat.ReadOnly = false;
			this.lifelengthViewer_Repeat.ShowCalendar = true;
			this.lifelengthViewer_Repeat.ShowFormattedCalendar = false;
			this.lifelengthViewer_Repeat.ShowMinutes = true;
			this.lifelengthViewer_Repeat.Size = new System.Drawing.Size(473, 52);
			this.lifelengthViewer_Repeat.SystemCalculated = true;
			this.lifelengthViewer_Repeat.TabIndex = 0;
			// 
			// groupFirstPerformance
			// 
			this.groupFirstPerformance.AutoSize = true;
			this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverLast);
			this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverFirst);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceEffDate);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceNew);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_FirstNotify);
			this.groupFirstPerformance.ForeColor = System.Drawing.Color.DimGray;
			this.groupFirstPerformance.Location = new System.Drawing.Point(10, 250);
			this.groupFirstPerformance.Name = "groupFirstPerformance";
			this.groupFirstPerformance.Size = new System.Drawing.Size(494, 206);
			this.groupFirstPerformance.TabIndex = 8;
			this.groupFirstPerformance.TabStop = false;
			this.groupFirstPerformance.Text = "FIRST PERFORMANCE";
			// 
			// radio_FirstWhicheverLast
			// 
			this.radio_FirstWhicheverLast.AutoSize = true;
			this.radio_FirstWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_FirstWhicheverLast.Location = new System.Drawing.Point(322, 163);
			this.radio_FirstWhicheverLast.Name = "radio_FirstWhicheverLast";
			this.radio_FirstWhicheverLast.Size = new System.Drawing.Size(146, 22);
			this.radio_FirstWhicheverLast.TabIndex = 4;
			this.radio_FirstWhicheverLast.Text = "Whichever Later";
			this.radio_FirstWhicheverLast.UseVisualStyleBackColor = true;
			// 
			// radio_FirstWhicheverFirst
			// 
			this.radio_FirstWhicheverFirst.AutoSize = true;
			this.radio_FirstWhicheverFirst.Checked = true;
			this.radio_FirstWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_FirstWhicheverFirst.Location = new System.Drawing.Point(60, 163);
			this.radio_FirstWhicheverFirst.Name = "radio_FirstWhicheverFirst";
			this.radio_FirstWhicheverFirst.Size = new System.Drawing.Size(140, 22);
			this.radio_FirstWhicheverFirst.TabIndex = 3;
			this.radio_FirstWhicheverFirst.TabStop = true;
			this.radio_FirstWhicheverFirst.Text = "Whichever First";
			this.radio_FirstWhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// lifelengthViewer_SinceEffDate
			// 
			this.lifelengthViewer_SinceEffDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_SinceEffDate.AutoSize = true;
			this.lifelengthViewer_SinceEffDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_SinceEffDate.CalendarApplicable = false;
			this.lifelengthViewer_SinceEffDate.CyclesApplicable = false;
			this.lifelengthViewer_SinceEffDate.EnabledCalendar = true;
			this.lifelengthViewer_SinceEffDate.EnabledCycle = true;
			this.lifelengthViewer_SinceEffDate.EnabledHours = true;
			this.lifelengthViewer_SinceEffDate.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_SinceEffDate.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_SinceEffDate.HeaderCalendar = "Calendar";
			this.lifelengthViewer_SinceEffDate.HeaderCycles = "Cycles";
			this.lifelengthViewer_SinceEffDate.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_SinceEffDate.HeaderHours = "Hours";
			this.lifelengthViewer_SinceEffDate.HoursApplicable = false;
			this.lifelengthViewer_SinceEffDate.LeftHeader = "Since Eff. Date";
			this.lifelengthViewer_SinceEffDate.Location = new System.Drawing.Point(16, 76);
			this.lifelengthViewer_SinceEffDate.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_SinceEffDate.Modified = false;
			this.lifelengthViewer_SinceEffDate.Name = "lifelengthViewer_SinceEffDate";
			this.lifelengthViewer_SinceEffDate.ReadOnly = false;
			this.lifelengthViewer_SinceEffDate.ShowCalendar = true;
			this.lifelengthViewer_SinceEffDate.ShowFormattedCalendar = false;
			this.lifelengthViewer_SinceEffDate.ShowHeaders = false;
			this.lifelengthViewer_SinceEffDate.ShowMinutes = true;
			this.lifelengthViewer_SinceEffDate.Size = new System.Drawing.Size(469, 35);
			this.lifelengthViewer_SinceEffDate.SystemCalculated = true;
			this.lifelengthViewer_SinceEffDate.TabIndex = 1;
			// 
			// lifelengthViewer_SinceNew
			// 
			this.lifelengthViewer_SinceNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_SinceNew.AutoSize = true;
			this.lifelengthViewer_SinceNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_SinceNew.CalendarApplicable = false;
			this.lifelengthViewer_SinceNew.CyclesApplicable = false;
			this.lifelengthViewer_SinceNew.EnabledCalendar = true;
			this.lifelengthViewer_SinceNew.EnabledCycle = true;
			this.lifelengthViewer_SinceNew.EnabledHours = true;
			this.lifelengthViewer_SinceNew.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_SinceNew.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_SinceNew.HeaderCalendar = "Calendar";
			this.lifelengthViewer_SinceNew.HeaderCycles = "Cycles";
			this.lifelengthViewer_SinceNew.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_SinceNew.HeaderHours = "Hours";
			this.lifelengthViewer_SinceNew.HoursApplicable = false;
			this.lifelengthViewer_SinceNew.LeftHeader = "Since New";
			this.lifelengthViewer_SinceNew.Location = new System.Drawing.Point(48, 18);
			this.lifelengthViewer_SinceNew.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_SinceNew.Modified = false;
			this.lifelengthViewer_SinceNew.Name = "lifelengthViewer_SinceNew";
			this.lifelengthViewer_SinceNew.ReadOnly = false;
			this.lifelengthViewer_SinceNew.ShowCalendar = true;
			this.lifelengthViewer_SinceNew.ShowFormattedCalendar = false;
			this.lifelengthViewer_SinceNew.ShowMinutes = true;
			this.lifelengthViewer_SinceNew.Size = new System.Drawing.Size(437, 52);
			this.lifelengthViewer_SinceNew.SystemCalculated = true;
			this.lifelengthViewer_SinceNew.TabIndex = 0;
			// 
			// lifelengthViewer_FirstNotify
			// 
			this.lifelengthViewer_FirstNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifelengthViewer_FirstNotify.AutoSize = true;
			this.lifelengthViewer_FirstNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_FirstNotify.CalendarApplicable = false;
			this.lifelengthViewer_FirstNotify.CyclesApplicable = false;
			this.lifelengthViewer_FirstNotify.EnabledCalendar = true;
			this.lifelengthViewer_FirstNotify.EnabledCycle = true;
			this.lifelengthViewer_FirstNotify.EnabledHours = true;
			this.lifelengthViewer_FirstNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_FirstNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
			this.lifelengthViewer_FirstNotify.HoursApplicable = false;
			this.lifelengthViewer_FirstNotify.LeftHeader = "Notify";
			this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(78, 117);
			this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstNotify.Modified = false;
			this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
			this.lifelengthViewer_FirstNotify.ReadOnly = false;
			this.lifelengthViewer_FirstNotify.ShowCalendar = true;
			this.lifelengthViewer_FirstNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstNotify.ShowHeaders = false;
			this.lifelengthViewer_FirstNotify.ShowMinutes = true;
			this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(407, 35);
			this.lifelengthViewer_FirstNotify.SystemCalculated = true;
			this.lifelengthViewer_FirstNotify.TabIndex = 2;
			// 
			// labelThreshold
			// 
			this.labelThreshold.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelThreshold.Location = new System.Drawing.Point(473, 219);
			this.labelThreshold.Name = "labelThreshold";
			this.labelThreshold.Size = new System.Drawing.Size(80, 25);
			this.labelThreshold.TabIndex = 80;
			this.labelThreshold.Text = "Threshold";
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
			this.imageLinkLabelStatus.Location = new System.Drawing.Point(10, 6);
			this.imageLinkLabelStatus.Margin = new System.Windows.Forms.Padding(2);
			this.imageLinkLabelStatus.Name = "imageLinkLabelStatus";
			this.imageLinkLabelStatus.Size = new System.Drawing.Size(75, 20);
			this.imageLinkLabelStatus.TabIndex = 68;
			this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(976, 82);
			this.linkLabelEditKit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 4;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// labelParagraph
			// 
			this.labelParagraph.AutoSize = true;
			this.labelParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelParagraph.Location = new System.Drawing.Point(395, 7);
			this.labelParagraph.Name = "labelParagraph";
			this.labelParagraph.Size = new System.Drawing.Size(20, 14);
			this.labelParagraph.TabIndex = 76;
			this.labelParagraph.Text = "§:";
			this.labelParagraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxClose
			// 
			this.checkBoxClose.AutoSize = true;
			this.checkBoxClose.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxClose.Location = new System.Drawing.Point(8, 21);
			this.checkBoxClose.Name = "checkBoxClose";
			this.checkBoxClose.Size = new System.Drawing.Size(68, 22);
			this.checkBoxClose.TabIndex = 0;
			this.checkBoxClose.Text = "Close";
			this.checkBoxClose.UseVisualStyleBackColor = true;
			this.checkBoxClose.CheckedChanged += new System.EventHandler(this.CheckBoxCloseCheckedChanged);
			// 
			// groupBoxClose
			// 
			this.groupBoxClose.Controls.Add(this.checkBoxClose);
			this.groupBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.groupBoxClose.Location = new System.Drawing.Point(1022, 250);
			this.groupBoxClose.Name = "groupBoxClose";
			this.groupBoxClose.Size = new System.Drawing.Size(86, 204);
			this.groupBoxClose.TabIndex = 10;
			this.groupBoxClose.TabStop = false;
			this.groupBoxClose.Text = "STATUS";
			// 
			// textBoxParagraph
			// 
			this.textBoxParagraph.BackColor = System.Drawing.Color.White;
			this.textBoxParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxParagraph.Location = new System.Drawing.Point(421, 4);
			this.textBoxParagraph.MaxLength = 4;
			this.textBoxParagraph.Name = "textBoxParagraph";
			this.textBoxParagraph.Size = new System.Drawing.Size(56, 22);
			this.textBoxParagraph.TabIndex = 1;
			// 
			// comboBoxWorkType
			// 
			this.comboBoxWorkType.BackColor = System.Drawing.Color.White;
			this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkType.Location = new System.Drawing.Point(127, 4);
			this.comboBoxWorkType.Name = "comboBoxWorkType";
			this.comboBoxWorkType.Size = new System.Drawing.Size(262, 22);
			this.comboBoxWorkType.TabIndex = 0;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Location = new System.Drawing.Point(685, 84);
			this.textBoxKitRequired.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(273, 22);
			this.textBoxKitRequired.TabIndex = 6;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.AutoSize = true;
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(537, 87);
			this.labelKitRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(120, 14);
			this.labelKitRequired.TabIndex = 74;
			this.labelKitRequired.Text = "Part and Material:";
			this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCost
			// 
			this.textBoxCost.BackColor = System.Drawing.Color.White;
			this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCost.Location = new System.Drawing.Point(127, 84);
			this.textBoxCost.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCost.Name = "textBoxCost";
			this.textBoxCost.Size = new System.Drawing.Size(350, 22);
			this.textBoxCost.TabIndex = 5;
			// 
			// labelCost
			// 
			this.labelCost.AutoSize = true;
			this.labelCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(7, 87);
			this.labelCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(81, 14);
			this.labelCost.TabIndex = 72;
			this.labelCost.Text = "Cost (USD):";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManHours
			// 
			this.textBoxManHours.BackColor = System.Drawing.Color.White;
			this.textBoxManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManHours.Location = new System.Drawing.Point(127, 58);
			this.textBoxManHours.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxManHours.Name = "textBoxManHours";
			this.textBoxManHours.Size = new System.Drawing.Size(140, 22);
			this.textBoxManHours.TabIndex = 2;
			// 
			// labelManHours
			// 
			this.labelManHours.AutoSize = true;
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(7, 61);
			this.labelManHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(79, 14);
			this.labelManHours.TabIndex = 70;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelForComponent
			// 
			this.labelForComponent.AutoSize = true;
			this.labelForComponent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelForComponent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelForComponent.Location = new System.Drawing.Point(7, 114);
			this.labelForComponent.Name = "labelForComponent";
			this.labelForComponent.Size = new System.Drawing.Size(104, 14);
			this.labelForComponent.TabIndex = 182;
			this.labelForComponent.Text = "For Component";
			// 
			// textBoxElapsed
			// 
			this.textBoxElapsed.BackColor = System.Drawing.Color.White;
			this.textBoxElapsed.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxElapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxElapsed.Location = new System.Drawing.Point(337, 58);
			this.textBoxElapsed.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxElapsed.Name = "textBoxElapsed";
			this.textBoxElapsed.Size = new System.Drawing.Size(140, 22);
			this.textBoxElapsed.TabIndex = 3;
			// 
			// labelElapsed
			// 
			this.labelElapsed.AutoSize = true;
			this.labelElapsed.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelElapsed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelElapsed.Location = new System.Drawing.Point(271, 61);
			this.labelElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelElapsed.Name = "labelElapsed";
			this.labelElapsed.Size = new System.Drawing.Size(62, 14);
			this.labelElapsed.TabIndex = 185;
			this.labelElapsed.Text = "Elapsed:";
			this.labelElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNDT
			// 
			this.labelNDT.AutoSize = true;
			this.labelNDT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNDT.Location = new System.Drawing.Point(537, 61);
			this.labelNDT.Name = "labelNDT";
			this.labelNDT.Size = new System.Drawing.Size(36, 14);
			this.labelNDT.TabIndex = 4;
			this.labelNDT.Text = "NDT:";
			this.labelNDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lookupComboboxMaintenanceCheck
			// 
			this.lookupComboboxMaintenanceCheck.ButtonCreateVisible = false;
			this.lookupComboboxMaintenanceCheck.ButtonEditVisible = false;
			this.lookupComboboxMaintenanceCheck.Displayer = null;
			this.lookupComboboxMaintenanceCheck.DisplayerText = null;
			this.lookupComboboxMaintenanceCheck.Entity = null;
			this.lookupComboboxMaintenanceCheck.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxMaintenanceCheck.Location = new System.Drawing.Point(665, 111);
			this.lookupComboboxMaintenanceCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lookupComboboxMaintenanceCheck.Name = "lookupComboboxMaintenanceCheck";
			this.lookupComboboxMaintenanceCheck.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxMaintenanceCheck.Size = new System.Drawing.Size(348, 22);
			this.lookupComboboxMaintenanceCheck.TabIndex = 188;
			this.lookupComboboxMaintenanceCheck.Type = null;
			this.lookupComboboxMaintenanceCheck.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxMaintenanceCheckSelectedIndexChanged);
			// 
			// labelCheck
			// 
			this.labelCheck.AutoSize = true;
			this.labelCheck.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCheck.Location = new System.Drawing.Point(537, 114);
			this.labelCheck.Name = "labelCheck";
			this.labelCheck.Size = new System.Drawing.Size(50, 14);
			this.labelCheck.TabIndex = 189;
			this.labelCheck.Text = "Check:";
			// 
			// linkLabelEditComponents
			// 
			this.linkLabelEditComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditComponents.Location = new System.Drawing.Point(440, 109);
			this.linkLabelEditComponents.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelEditComponents.Name = "linkLabelEditComponents";
			this.linkLabelEditComponents.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditComponents.TabIndex = 190;
			this.linkLabelEditComponents.TabStop = true;
			this.linkLabelEditComponents.Text = "Edit";
			this.linkLabelEditComponents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditComponents.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditComponentsLinkClicked);
			// 
			// textBoxComponents
			// 
			this.textBoxComponents.BackColor = System.Drawing.Color.White;
			this.textBoxComponents.Enabled = false;
			this.textBoxComponents.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxComponents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxComponents.Location = new System.Drawing.Point(127, 111);
			this.textBoxComponents.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxComponents.Name = "textBoxComponents";
			this.textBoxComponents.Size = new System.Drawing.Size(309, 22);
			this.textBoxComponents.TabIndex = 191;
			// 
			// comboBoxNdt
			// 
			this.comboBoxNdt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxNdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxNdt.FormattingEnabled = true;
			this.comboBoxNdt.Location = new System.Drawing.Point(665, 58);
			this.comboBoxNdt.Name = "comboBoxNdt";
			this.comboBoxNdt.Size = new System.Drawing.Size(293, 22);
			this.comboBoxNdt.TabIndex = 192;
			// 
			// checkBoxKitsApplicable
			// 
			this.checkBoxKitsApplicable.AutoSize = true;
			this.checkBoxKitsApplicable.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxKitsApplicable.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxKitsApplicable.Location = new System.Drawing.Point(665, 87);
			this.checkBoxKitsApplicable.Name = "checkBoxKitsApplicable";
			this.checkBoxKitsApplicable.Size = new System.Drawing.Size(15, 14);
			this.checkBoxKitsApplicable.TabIndex = 1;
			this.checkBoxKitsApplicable.UseVisualStyleBackColor = true;
			this.checkBoxKitsApplicable.CheckedChanged += new System.EventHandler(this.checkBoxKitsApplicable_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(36, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 14);
			this.label1.TabIndex = 193;
			this.label1.Text = "Work Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(9, 37);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 14);
			this.label2.TabIndex = 194;
			this.label2.Text = "Skill:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSkill
			// 
			this.comboBoxSkill.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSkill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSkill.FormattingEnabled = true;
			this.comboBoxSkill.Location = new System.Drawing.Point(127, 31);
			this.comboBoxSkill.Name = "comboBoxSkill";
			this.comboBoxSkill.Size = new System.Drawing.Size(351, 22);
			this.comboBoxSkill.TabIndex = 195;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel1.Location = new System.Drawing.Point(440, 135);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(37, 23);
			this.linkLabel1.TabIndex = 197;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Edit";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// textBoxAd
			// 
			this.textBoxAd.BackColor = System.Drawing.Color.White;
			this.textBoxAd.Enabled = false;
			this.textBoxAd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxAd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAd.Location = new System.Drawing.Point(127, 137);
			this.textBoxAd.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxAd.Name = "textBoxAd";
			this.textBoxAd.Size = new System.Drawing.Size(309, 22);
			this.textBoxAd.TabIndex = 198;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(7, 140);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 14);
			this.label3.TabIndex = 196;
			this.label3.Text = "For AD";
			// 
			// linkLabel2
			// 
			this.linkLabel2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel2.Location = new System.Drawing.Point(440, 161);
			this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(37, 23);
			this.linkLabel2.TabIndex = 200;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Edit";
			this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// textBoxMPD
			// 
			this.textBoxMPD.BackColor = System.Drawing.Color.White;
			this.textBoxMPD.Enabled = false;
			this.textBoxMPD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxMPD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMPD.Location = new System.Drawing.Point(127, 163);
			this.textBoxMPD.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxMPD.Name = "textBoxMPD";
			this.textBoxMPD.Size = new System.Drawing.Size(309, 22);
			this.textBoxMPD.TabIndex = 201;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(7, 166);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 14);
			this.label4.TabIndex = 199;
			this.label4.Text = "Related TC";
			// 
			// linkLabel3
			// 
			this.linkLabel3.Enabled = false;
			this.linkLabel3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabel3.Location = new System.Drawing.Point(440, 187);
			this.linkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(37, 23);
			this.linkLabel3.TabIndex = 203;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Edit";
			this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.White;
			this.textBox3.Enabled = false;
			this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBox3.Location = new System.Drawing.Point(127, 189);
			this.textBox3.Margin = new System.Windows.Forms.Padding(2);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(309, 22);
			this.textBox3.TabIndex = 204;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(7, 192);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 14);
			this.label5.TabIndex = 202;
			this.label5.Text = "For SB";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(537, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 14);
			this.label6.TabIndex = 205;
			this.label6.Text = "APU Hour:";
			// 
			// checkBoxAPU
			// 
			this.checkBoxAPU.AutoSize = true;
			this.checkBoxAPU.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxAPU.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxAPU.Location = new System.Drawing.Point(665, 140);
			this.checkBoxAPU.Name = "checkBoxAPU";
			this.checkBoxAPU.Size = new System.Drawing.Size(15, 14);
			this.checkBoxAPU.TabIndex = 206;
			this.checkBoxAPU.UseVisualStyleBackColor = true;
			this.checkBoxAPU.CheckedChanged += new System.EventHandler(this.CheckBoxAPU_CheckedChanged);
			// 
			// checkBoxSBControl
			// 
			this.checkBoxSBControl.AutoSize = true;
			this.checkBoxSBControl.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxSBControl.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxSBControl.Location = new System.Drawing.Point(848, 140);
			this.checkBoxSBControl.Name = "checkBoxSBControl";
			this.checkBoxSBControl.Size = new System.Drawing.Size(15, 14);
			this.checkBoxSBControl.TabIndex = 208;
			this.checkBoxSBControl.UseVisualStyleBackColor = true;
			// 
			// labelSBControl
			// 
			this.labelSBControl.AutoSize = true;
			this.labelSBControl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSBControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSBControl.Location = new System.Drawing.Point(764, 140);
			this.labelSBControl.Name = "labelSBControl";
			this.labelSBControl.Size = new System.Drawing.Size(78, 14);
			this.labelSBControl.TabIndex = 207;
			this.labelSBControl.Text = "SB Control:";
			// 
			// MaintenanceDirectiveParametersControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.checkBoxSBControl);
			this.Controls.Add(this.labelSBControl);
			this.Controls.Add(this.checkBoxAPU);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.textBoxMPD);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.textBoxAd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxSkill);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBoxKitsApplicable);
			this.Controls.Add(this.comboBoxNdt);
			this.Controls.Add(this.linkLabelEditComponents);
			this.Controls.Add(this.textBoxComponents);
			this.Controls.Add(this.lookupComboboxMaintenanceCheck);
			this.Controls.Add(this.labelCheck);
			this.Controls.Add(this.labelNDT);
			this.Controls.Add(this.textBoxElapsed);
			this.Controls.Add(this.labelElapsed);
			this.Controls.Add(this.labelForComponent);
			this.Controls.Add(this.groupBox_Repetative);
			this.Controls.Add(this.groupFirstPerformance);
			this.Controls.Add(this.labelThreshold);
			this.Controls.Add(this.imageLinkLabelStatus);
			this.Controls.Add(this.linkLabelEditKit);
			this.Controls.Add(this.labelParagraph);
			this.Controls.Add(this.groupBoxClose);
			this.Controls.Add(this.textBoxParagraph);
			this.Controls.Add(this.comboBoxWorkType);
			this.Controls.Add(this.textBoxKitRequired);
			this.Controls.Add(this.labelKitRequired);
			this.Controls.Add(this.textBoxCost);
			this.Controls.Add(this.labelCost);
			this.Controls.Add(this.textBoxManHours);
			this.Controls.Add(this.labelManHours);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MaintenanceDirectiveParametersControl";
			this.Size = new System.Drawing.Size(1114, 459);
			this.groupBox_Repetative.ResumeLayout(false);
			this.groupBox_Repetative.PerformLayout();
			this.groupFirstPerformance.ResumeLayout(false);
			this.groupFirstPerformance.PerformLayout();
			this.groupBoxClose.ResumeLayout(false);
			this.groupBoxClose.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private LifelengthViewer lifelengthViewer_RepeatNotify;
		private System.Windows.Forms.RadioButton radio_RepeatWhicheverFirst;
		private System.Windows.Forms.GroupBox groupBox_Repetative;
		private System.Windows.Forms.RadioButton radio_RepeatWhicheverLast;
		private LifelengthViewer lifelengthViewer_Repeat;
		private System.Windows.Forms.GroupBox groupFirstPerformance;
		private System.Windows.Forms.RadioButton radio_FirstWhicheverLast;
		private System.Windows.Forms.RadioButton radio_FirstWhicheverFirst;
		private LifelengthViewer lifelengthViewer_SinceEffDate;
		private LifelengthViewer lifelengthViewer_SinceNew;
		private LifelengthViewer lifelengthViewer_FirstNotify;
		private System.Windows.Forms.Label labelThreshold;
		private StatusImageLinkLabel imageLinkLabelStatus;
		private System.Windows.Forms.LinkLabel linkLabelEditKit;
		private System.Windows.Forms.Label labelParagraph;
		private System.Windows.Forms.CheckBox checkBoxClose;
		private System.Windows.Forms.GroupBox groupBoxClose;
		private System.Windows.Forms.TextBox textBoxParagraph;
		private System.Windows.Forms.ComboBox comboBoxWorkType;
		private System.Windows.Forms.TextBox textBoxKitRequired;
		private System.Windows.Forms.Label labelKitRequired;
		private System.Windows.Forms.TextBox textBoxCost;
		private System.Windows.Forms.Label labelCost;
		private System.Windows.Forms.TextBox textBoxManHours;
		private System.Windows.Forms.Label labelManHours;
		private System.Windows.Forms.Label labelForComponent;
		private System.Windows.Forms.TextBox textBoxElapsed;
		private System.Windows.Forms.Label labelElapsed;
		private System.Windows.Forms.Label labelNDT;
		private LookupCombobox lookupComboboxMaintenanceCheck;
		private System.Windows.Forms.Label labelCheck;
		private System.Windows.Forms.LinkLabel linkLabelEditComponents;
		private System.Windows.Forms.TextBox textBoxComponents;
		private System.Windows.Forms.ComboBox comboBoxNdt;
		private System.Windows.Forms.CheckBox checkBoxKitsApplicable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxSkill;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TextBox textBoxAd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.TextBox textBoxMPD;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBoxAPU;
		private System.Windows.Forms.CheckBox checkBoxSBControl;
		private System.Windows.Forms.Label labelSBControl;
	}
}
