using AvControls.StatusImageLink;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    partial class ProcedureParametersControl
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
            this.lookupComboboxMaintenanceCheck = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.labelCheck = new System.Windows.Forms.Label();
            this.linkLabelEditComponents = new System.Windows.Forms.LinkLabel();
            this.textBoxComponents = new System.Windows.Forms.TextBox();
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
            this.lifelengthViewer_RepeatNotify.EnabledCycle = false;
            this.lifelengthViewer_RepeatNotify.EnabledHours = false;
            this.lifelengthViewer_RepeatNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_RepeatNotify.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_RepeatNotify.HeaderCalendar = "Calendar";
            this.lifelengthViewer_RepeatNotify.HeaderCycles = "Cycles";
            this.lifelengthViewer_RepeatNotify.HeaderHours = "Hours";
            this.lifelengthViewer_RepeatNotify.HoursApplicable = false;
            this.lifelengthViewer_RepeatNotify.LeftHeader = "Notify";
            this.lifelengthViewer_RepeatNotify.Location = new System.Drawing.Point(73, 76);
            this.lifelengthViewer_RepeatNotify.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_RepeatNotify.Modified = false;
            this.lifelengthViewer_RepeatNotify.Name = "lifelengthViewer_RepeatNotify";
            this.lifelengthViewer_RepeatNotify.ReadOnly = false;
            this.lifelengthViewer_RepeatNotify.ShowCalendar = true;
            this.lifelengthViewer_RepeatNotify.ShowHeaders = false;
            this.lifelengthViewer_RepeatNotify.ShowLeftHeader = true;
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
            this.groupBox_Repetative.Location = new System.Drawing.Point(533, 137);
            this.groupBox_Repetative.Name = "groupBox_Repetative";
            this.groupBox_Repetative.Size = new System.Drawing.Size(486, 204);
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
            this.lifelengthViewer_Repeat.EnabledCycle = false;
            this.lifelengthViewer_Repeat.EnabledHours = false;
            this.lifelengthViewer_Repeat.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_Repeat.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_Repeat.HeaderCalendar = "Calendar";
            this.lifelengthViewer_Repeat.HeaderCycles = "Cycles";
            this.lifelengthViewer_Repeat.HeaderHours = "Hours";
            this.lifelengthViewer_Repeat.HoursApplicable = false;
            this.lifelengthViewer_Repeat.LeftHeader = "Repeat Interval";
            this.lifelengthViewer_Repeat.Location = new System.Drawing.Point(7, 18);
            this.lifelengthViewer_Repeat.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_Repeat.Modified = false;
            this.lifelengthViewer_Repeat.Name = "lifelengthViewer_Repeat";
            this.lifelengthViewer_Repeat.ReadOnly = false;
            this.lifelengthViewer_Repeat.ShowCalendar = true;
            this.lifelengthViewer_Repeat.ShowHeaders = true;
            this.lifelengthViewer_Repeat.ShowLeftHeader = true;
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
            this.groupFirstPerformance.Location = new System.Drawing.Point(10, 137);
            this.groupFirstPerformance.Name = "groupFirstPerformance";
            this.groupFirstPerformance.Size = new System.Drawing.Size(477, 204);
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
            this.lifelengthViewer_SinceEffDate.EnabledCycle = false;
            this.lifelengthViewer_SinceEffDate.EnabledHours = false;
            this.lifelengthViewer_SinceEffDate.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_SinceEffDate.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_SinceEffDate.HeaderCalendar = "Calendar";
            this.lifelengthViewer_SinceEffDate.HeaderCycles = "Cycles";
            this.lifelengthViewer_SinceEffDate.HeaderHours = "Hours";
            this.lifelengthViewer_SinceEffDate.HoursApplicable = false;
            this.lifelengthViewer_SinceEffDate.LeftHeader = "Since Eff. Date";
            this.lifelengthViewer_SinceEffDate.Location = new System.Drawing.Point(-2, 76);
            this.lifelengthViewer_SinceEffDate.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_SinceEffDate.Modified = false;
            this.lifelengthViewer_SinceEffDate.Name = "lifelengthViewer_SinceEffDate";
            this.lifelengthViewer_SinceEffDate.ReadOnly = false;
            this.lifelengthViewer_SinceEffDate.ShowCalendar = true;
            this.lifelengthViewer_SinceEffDate.ShowHeaders = false;
            this.lifelengthViewer_SinceEffDate.ShowLeftHeader = true;
            this.lifelengthViewer_SinceEffDate.ShowMinutes = true;
            this.lifelengthViewer_SinceEffDate.Size = new System.Drawing.Size(470, 35);
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
            this.lifelengthViewer_SinceNew.EnabledCalendar = false;
            this.lifelengthViewer_SinceNew.EnabledCycle = false;
            this.lifelengthViewer_SinceNew.EnabledHours = false;
            this.lifelengthViewer_SinceNew.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_SinceNew.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_SinceNew.HeaderCalendar = "Calendar";
            this.lifelengthViewer_SinceNew.HeaderCycles = "Cycles";
            this.lifelengthViewer_SinceNew.HeaderHours = "Hours";
            this.lifelengthViewer_SinceNew.HoursApplicable = false;
            this.lifelengthViewer_SinceNew.LeftHeader = "Since New";
            this.lifelengthViewer_SinceNew.Location = new System.Drawing.Point(31, 18);
            this.lifelengthViewer_SinceNew.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_SinceNew.Modified = false;
            this.lifelengthViewer_SinceNew.Name = "lifelengthViewer_SinceNew";
            this.lifelengthViewer_SinceNew.ReadOnly = false;
            this.lifelengthViewer_SinceNew.ShowCalendar = true;
            this.lifelengthViewer_SinceNew.ShowHeaders = true;
            this.lifelengthViewer_SinceNew.ShowLeftHeader = true;
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
            this.lifelengthViewer_FirstNotify.EnabledCycle = false;
            this.lifelengthViewer_FirstNotify.EnabledHours = false;
            this.lifelengthViewer_FirstNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
            this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
            this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
            this.lifelengthViewer_FirstNotify.HoursApplicable = false;
            this.lifelengthViewer_FirstNotify.LeftHeader = "Notify";
            this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(61, 117);
            this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(2);
            this.lifelengthViewer_FirstNotify.Modified = false;
            this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
            this.lifelengthViewer_FirstNotify.ReadOnly = false;
            this.lifelengthViewer_FirstNotify.ShowCalendar = true;
            this.lifelengthViewer_FirstNotify.ShowHeaders = false;
            this.lifelengthViewer_FirstNotify.ShowLeftHeader = true;
            this.lifelengthViewer_FirstNotify.ShowMinutes = true;
            this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(407, 35);
            this.lifelengthViewer_FirstNotify.SystemCalculated = true;
            this.lifelengthViewer_FirstNotify.TabIndex = 2;
            // 
            // labelThreshold
            // 
            this.labelThreshold.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelThreshold.Location = new System.Drawing.Point(473, 109);
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
            this.imageLinkLabelStatus.Status = AvControls.Statuses.NotActive;
            this.imageLinkLabelStatus.TabIndex = 68;
            this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // linkLabelEditKit
            // 
            this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelEditKit.Location = new System.Drawing.Point(976, 55);
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
            this.groupBoxClose.Location = new System.Drawing.Point(1025, 137);
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
            this.textBoxKitRequired.Location = new System.Drawing.Point(665, 57);
            this.textBoxKitRequired.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxKitRequired.Name = "textBoxKitRequired";
            this.textBoxKitRequired.Size = new System.Drawing.Size(306, 22);
            this.textBoxKitRequired.TabIndex = 6;
            // 
            // labelKitRequired
            // 
            this.labelKitRequired.AutoSize = true;
            this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKitRequired.Location = new System.Drawing.Point(537, 60);
            this.labelKitRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelKitRequired.Name = "labelKitRequired";
            this.labelKitRequired.Size = new System.Drawing.Size(88, 14);
            this.labelKitRequired.TabIndex = 74;
            this.labelKitRequired.Text = "Kit Required:";
            this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxCost
            // 
            this.textBoxCost.BackColor = System.Drawing.Color.White;
            this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCost.Location = new System.Drawing.Point(127, 57);
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
            this.labelCost.Location = new System.Drawing.Point(7, 60);
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
            this.textBoxManHours.Location = new System.Drawing.Point(127, 31);
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
            this.labelManHours.Location = new System.Drawing.Point(7, 34);
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
            this.labelForComponent.Location = new System.Drawing.Point(7, 87);
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
            this.textBoxElapsed.Location = new System.Drawing.Point(337, 31);
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
            this.labelElapsed.Location = new System.Drawing.Point(271, 34);
            this.labelElapsed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelElapsed.Name = "labelElapsed";
            this.labelElapsed.Size = new System.Drawing.Size(62, 14);
            this.labelElapsed.TabIndex = 185;
            this.labelElapsed.Text = "Elapsed:";
            this.labelElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lookupComboboxMaintenanceCheck
            // 
            this.lookupComboboxMaintenanceCheck.ButtonCreateVisible = false;
            this.lookupComboboxMaintenanceCheck.ButtonEditVisible = false;
            this.lookupComboboxMaintenanceCheck.Displayer = null;
            this.lookupComboboxMaintenanceCheck.DisplayerText = null;
            this.lookupComboboxMaintenanceCheck.Entity = null;
            this.lookupComboboxMaintenanceCheck.Font = new System.Drawing.Font("Verdana", 9F);
            this.lookupComboboxMaintenanceCheck.Location = new System.Drawing.Point(665, 84);
            this.lookupComboboxMaintenanceCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lookupComboboxMaintenanceCheck.Name = "lookupComboboxMaintenanceCheck";
            this.lookupComboboxMaintenanceCheck.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.lookupComboboxMaintenanceCheck.Size = new System.Drawing.Size(348, 22);
            this.lookupComboboxMaintenanceCheck.TabIndex = 188;
            this.lookupComboboxMaintenanceCheck.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxMaintenanceCheckSelectedIndexChanged);
            this.lookupComboboxMaintenanceCheck.Visible = false;
            // 
            // labelCheck
            // 
            this.labelCheck.AutoSize = true;
            this.labelCheck.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCheck.Location = new System.Drawing.Point(537, 87);
            this.labelCheck.Name = "labelCheck";
            this.labelCheck.Size = new System.Drawing.Size(50, 14);
            this.labelCheck.TabIndex = 189;
            this.labelCheck.Text = "Check:";
            this.labelCheck.Visible = false;
            // 
            // linkLabelEditComponents
            // 
            this.linkLabelEditComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabelEditComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelEditComponents.Location = new System.Drawing.Point(440, 82);
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
            this.textBoxComponents.Location = new System.Drawing.Point(127, 84);
            this.textBoxComponents.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxComponents.Name = "textBoxComponents";
            this.textBoxComponents.Size = new System.Drawing.Size(309, 22);
            this.textBoxComponents.TabIndex = 191;
            // 
            // MaintenanceDirectiveParametersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.linkLabelEditComponents);
            this.Controls.Add(this.textBoxComponents);
            this.Controls.Add(this.lookupComboboxMaintenanceCheck);
            this.Controls.Add(this.labelCheck);
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
            this.Size = new System.Drawing.Size(1114, 344);
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
        private LookupCombobox lookupComboboxMaintenanceCheck;
        private System.Windows.Forms.Label labelCheck;
        private System.Windows.Forms.LinkLabel linkLabelEditComponents;
        private System.Windows.Forms.TextBox textBoxComponents;
    }
}
