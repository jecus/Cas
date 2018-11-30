using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentAddCompliancePerformanceControl
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
			this.labelWorkType = new System.Windows.Forms.Label();
			this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
			this.radio_WhicheverFirst = new System.Windows.Forms.RadioButton();
			this.radio_WhicheverLater = new System.Windows.Forms.RadioButton();
			this.checkBox_Repeat = new System.Windows.Forms.CheckBox();
			this.labelManHours = new System.Windows.Forms.Label();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.textBoxManHours = new System.Windows.Forms.TextBox();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.labelCost = new System.Windows.Forms.Label();
			this.textBoxCost = new System.Windows.Forms.TextBox();
			this.labelFAAForm = new System.Windows.Forms.Label();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.lifelengthViewerWarrantyNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerRptInterval = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstPerformance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerRptNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelEffectivityDate = new System.Windows.Forms.Label();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.labelMPDTaskType = new System.Windows.Forms.Label();
			this.lookupComboboxMaintenanceDirective = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.labelMPDItem = new System.Windows.Forms.Label();
			this.comboBoxMpdTaskType = new System.Windows.Forms.ComboBox();
			this.fileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.SuspendLayout();
			// 
			// labelWorkType
			// 
			this.labelWorkType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWorkType.Location = new System.Drawing.Point(10, 10);
			this.labelWorkType.Name = "labelWorkType";
			this.labelWorkType.Size = new System.Drawing.Size(150, 25);
			this.labelWorkType.TabIndex = 0;
			this.labelWorkType.Text = "Work Type:";
			this.labelWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxWorkType
			// 
			this.comboBoxWorkType.BackColor = System.Drawing.Color.White;
			this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkType.Location = new System.Drawing.Point(160, 10);
			this.comboBoxWorkType.Name = "comboBoxWorkType";
			this.comboBoxWorkType.Size = new System.Drawing.Size(350, 22);
			this.comboBoxWorkType.TabIndex = 1;
			this.comboBoxWorkType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWorkTypeSelectedIndexChanged);
			// 
			// radio_WhicheverFirst
			// 
			this.radio_WhicheverFirst.AutoSize = true;
			this.radio_WhicheverFirst.Checked = true;
			this.radio_WhicheverFirst.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radio_WhicheverFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radio_WhicheverFirst.Location = new System.Drawing.Point(388, 381);
			this.radio_WhicheverFirst.Name = "radio_WhicheverFirst";
			this.radio_WhicheverFirst.Size = new System.Drawing.Size(122, 18);
			this.radio_WhicheverFirst.TabIndex = 14;
			this.radio_WhicheverFirst.TabStop = true;
			this.radio_WhicheverFirst.Text = "Whichever First";
			this.radio_WhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// radio_WhicheverLater
			// 
			this.radio_WhicheverLater.AutoSize = true;
			this.radio_WhicheverLater.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radio_WhicheverLater.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radio_WhicheverLater.Location = new System.Drawing.Point(640, 381);
			this.radio_WhicheverLater.Name = "radio_WhicheverLater";
			this.radio_WhicheverLater.Size = new System.Drawing.Size(128, 18);
			this.radio_WhicheverLater.TabIndex = 16;
			this.radio_WhicheverLater.Text = "Whichever Later";
			this.radio_WhicheverLater.UseVisualStyleBackColor = true;
			// 
			// checkBox_Repeat
			// 
			this.checkBox_Repeat.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBox_Repeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBox_Repeat.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBox_Repeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBox_Repeat.Location = new System.Drawing.Point(64, 321);
			this.checkBox_Repeat.Name = "checkBox_Repeat";
			this.checkBox_Repeat.Size = new System.Drawing.Size(92, 25);
			this.checkBox_Repeat.TabIndex = 7;
			this.checkBox_Repeat.Text = "Repetative";
			this.checkBox_Repeat.CheckedChanged += new System.EventHandler(this.CheckBoxLastComplianceCheckedChanged);
			// 
			// labelManHours
			// 
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(10, 64);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(150, 25);
			this.labelManHours.TabIndex = 45;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(550, 64);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(150, 25);
			this.labelKitRequired.TabIndex = 46;
			this.labelKitRequired.Text = "Kit Required:";
			this.labelKitRequired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManHours
			// 
			this.textBoxManHours.BackColor = System.Drawing.Color.White;
			this.textBoxManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManHours.Location = new System.Drawing.Point(160, 66);
			this.textBoxManHours.Name = "textBoxManHours";
			this.textBoxManHours.Size = new System.Drawing.Size(350, 22);
			this.textBoxManHours.TabIndex = 47;
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Location = new System.Drawing.Point(700, 64);
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(350, 22);
			this.textBoxKitRequired.TabIndex = 48;
			// 
			// labelCost
			// 
			this.labelCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(10, 103);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(150, 25);
			this.labelCost.TabIndex = 49;
			this.labelCost.Text = "Cost:";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxCost
			// 
			this.textBoxCost.BackColor = System.Drawing.Color.White;
			this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCost.Location = new System.Drawing.Point(160, 103);
			this.textBoxCost.Name = "textBoxCost";
			this.textBoxCost.Size = new System.Drawing.Size(350, 22);
			this.textBoxCost.TabIndex = 50;
			// 
			// labelFAAForm
			// 
			this.labelFAAForm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFAAForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFAAForm.Location = new System.Drawing.Point(550, 106);
			this.labelFAAForm.Name = "labelFAAForm";
			this.labelFAAForm.Size = new System.Drawing.Size(150, 25);
			this.labelFAAForm.TabIndex = 51;
			this.labelFAAForm.Text = "CRS Form:";
			this.labelFAAForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(10, 180);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(147, 25);
			this.labelRemarks.TabIndex = 53;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(550, 180);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(150, 30);
			this.labelHiddenRemarks.TabIndex = 54;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
			this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(160, 180);
			this.textBoxRemarks.MaxLength = 340000;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(350, 70);
			this.textBoxRemarks.TabIndex = 55;
			// 
			// textBoxHiddenRemarks
			// 
			this.textBoxHiddenRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(700, 180);
			this.textBoxHiddenRemarks.MaxLength = 34000;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(350, 70);
			this.textBoxHiddenRemarks.TabIndex = 56;
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
			this.lifelengthViewerWarrantyNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerWarrantyNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerWarrantyNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarrantyNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerWarrantyNotify.HeaderHours = "Hours";
			this.lifelengthViewerWarrantyNotify.HoursApplicable = false;
			this.lifelengthViewerWarrantyNotify.LeftHeader = "Notify:";
			this.lifelengthViewerWarrantyNotify.Location = new System.Drawing.Point(640, 347);
			this.lifelengthViewerWarrantyNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarrantyNotify.Modified = false;
			this.lifelengthViewerWarrantyNotify.Name = "lifelengthViewerWarrantyNotify";
			this.lifelengthViewerWarrantyNotify.ReadOnly = false;
			this.lifelengthViewerWarrantyNotify.ShowCalendar = true;
			this.lifelengthViewerWarrantyNotify.ShowHeaders = false;
			this.lifelengthViewerWarrantyNotify.ShowMinutes = false;
			this.lifelengthViewerWarrantyNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerWarrantyNotify.SystemCalculated = true;
			this.lifelengthViewerWarrantyNotify.TabIndex = 19;
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
			this.lifelengthViewerWarranty.HeaderHours = "Hours";
			this.lifelengthViewerWarranty.HoursApplicable = false;
			this.lifelengthViewerWarranty.LeftHeader = "Warranty:";
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(73, 349);
			this.lifelengthViewerWarranty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerWarranty.Modified = false;
			this.lifelengthViewerWarranty.Name = "lifelengthViewerWarranty";
			this.lifelengthViewerWarranty.ReadOnly = false;
			this.lifelengthViewerWarranty.ShowCalendar = true;
			this.lifelengthViewerWarranty.ShowHeaders = false;
			this.lifelengthViewerWarranty.ShowMinutes = false;
			this.lifelengthViewerWarranty.Size = new System.Drawing.Size(437, 35);
			this.lifelengthViewerWarranty.SystemCalculated = true;
			this.lifelengthViewerWarranty.TabIndex = 18;
			// 
			// lifelengthViewerRptInterval
			// 
			this.lifelengthViewerRptInterval.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerRptInterval.AutoSize = true;
			this.lifelengthViewerRptInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRptInterval.CalendarApplicable = false;
			this.lifelengthViewerRptInterval.CyclesApplicable = false;
			this.lifelengthViewerRptInterval.Enabled = false;
			this.lifelengthViewerRptInterval.EnabledCalendar = true;
			this.lifelengthViewerRptInterval.EnabledCycle = true;
			this.lifelengthViewerRptInterval.EnabledHours = true;
			this.lifelengthViewerRptInterval.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRptInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerRptInterval.HeaderCalendar = "Calendar";
			this.lifelengthViewerRptInterval.HeaderCycles = "Cycles";
			this.lifelengthViewerRptInterval.HeaderHours = "Hours";
			this.lifelengthViewerRptInterval.HoursApplicable = false;
			this.lifelengthViewerRptInterval.LeftHeader = "Repeat every:";
			this.lifelengthViewerRptInterval.Location = new System.Drawing.Point(46, 317);
			this.lifelengthViewerRptInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerRptInterval.Modified = true;
			this.lifelengthViewerRptInterval.Name = "lifelengthViewerRptInterval";
			this.lifelengthViewerRptInterval.ReadOnly = false;
			this.lifelengthViewerRptInterval.ShowCalendar = true;
			this.lifelengthViewerRptInterval.ShowHeaders = false;
			this.lifelengthViewerRptInterval.ShowMinutes = false;
			this.lifelengthViewerRptInterval.Size = new System.Drawing.Size(464, 35);
			this.lifelengthViewerRptInterval.SystemCalculated = true;
			this.lifelengthViewerRptInterval.TabIndex = 3;
			this.lifelengthViewerRptInterval.LifelengthChanged += new System.EventHandler(this.lifelengthViewerInterval_LifelengthChanged);
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
			this.lifelengthViewer_FirstNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
			this.lifelengthViewer_FirstNotify.HoursApplicable = false;
			this.lifelengthViewer_FirstNotify.LeftHeader = "Notify:";
			this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(640, 264);
			this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewer_FirstNotify.Modified = false;
			this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
			this.lifelengthViewer_FirstNotify.ReadOnly = false;
			this.lifelengthViewer_FirstNotify.ShowCalendar = true;
			this.lifelengthViewer_FirstNotify.ShowMinutes = false;
			this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(413, 52);
			this.lifelengthViewer_FirstNotify.SystemCalculated = true;
			this.lifelengthViewer_FirstNotify.TabIndex = 13;
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
			this.lifelengthViewer_FirstPerformance.HeaderHours = "Hours";
			this.lifelengthViewer_FirstPerformance.HoursApplicable = false;
			this.lifelengthViewer_FirstPerformance.LeftHeader = "Perform at:";
			this.lifelengthViewer_FirstPerformance.Location = new System.Drawing.Point(64, 264);
			this.lifelengthViewer_FirstPerformance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewer_FirstPerformance.Modified = false;
			this.lifelengthViewer_FirstPerformance.Name = "lifelengthViewer_FirstPerformance";
			this.lifelengthViewer_FirstPerformance.ReadOnly = false;
			this.lifelengthViewer_FirstPerformance.ShowCalendar = true;
			this.lifelengthViewer_FirstPerformance.ShowMinutes = false;
			this.lifelengthViewer_FirstPerformance.Size = new System.Drawing.Size(446, 52);
			this.lifelengthViewer_FirstPerformance.SystemCalculated = true;
			this.lifelengthViewer_FirstPerformance.TabIndex = 11;
			this.lifelengthViewer_FirstPerformance.LifelengthChanged += new System.EventHandler(this.lifelengthViewerComponentLastPerformance_LifelengthChanged);
			// 
			// lifelengthViewerRptNotify
			// 
			this.lifelengthViewerRptNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewerRptNotify.AutoSize = true;
			this.lifelengthViewerRptNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerRptNotify.CalendarApplicable = false;
			this.lifelengthViewerRptNotify.CyclesApplicable = false;
			this.lifelengthViewerRptNotify.Enabled = false;
			this.lifelengthViewerRptNotify.EnabledCalendar = true;
			this.lifelengthViewerRptNotify.EnabledCycle = true;
			this.lifelengthViewerRptNotify.EnabledHours = true;
			this.lifelengthViewerRptNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerRptNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerRptNotify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerRptNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewerRptNotify.HeaderCycles = "Cycles";
			this.lifelengthViewerRptNotify.HeaderHours = "Hours";
			this.lifelengthViewerRptNotify.HoursApplicable = false;
			this.lifelengthViewerRptNotify.LeftHeader = "Notify:";
			this.lifelengthViewerRptNotify.Location = new System.Drawing.Point(640, 315);
			this.lifelengthViewerRptNotify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerRptNotify.Modified = false;
			this.lifelengthViewerRptNotify.Name = "lifelengthViewerRptNotify";
			this.lifelengthViewerRptNotify.ReadOnly = false;
			this.lifelengthViewerRptNotify.ShowCalendar = true;
			this.lifelengthViewerRptNotify.ShowHeaders = false;
			this.lifelengthViewerRptNotify.ShowMinutes = false;
			this.lifelengthViewerRptNotify.Size = new System.Drawing.Size(413, 35);
			this.lifelengthViewerRptNotify.SystemCalculated = true;
			this.lifelengthViewerRptNotify.TabIndex = 5;
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.AutoSize = true;
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(10, 145);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(131, 17);
			this.labelEffectivityDate.TabIndex = 67;
			this.labelEffectivityDate.Text = "Conserv-n. Date:";
			this.labelEffectivityDate.Visible = false;
			// 
			// dateTimePickerEffDate
			// 
			this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(160, 139);
			this.dateTimePickerEffDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 25);
			this.dateTimePickerEffDate.TabIndex = 68;
			this.dateTimePickerEffDate.Visible = false;
			// 
			// labelMPDTaskType
			// 
			this.labelMPDTaskType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMPDTaskType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDTaskType.Location = new System.Drawing.Point(550, 38);
			this.labelMPDTaskType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelMPDTaskType.Name = "labelMPDTaskType";
			this.labelMPDTaskType.Size = new System.Drawing.Size(144, 20);
			this.labelMPDTaskType.TabIndex = 196;
			this.labelMPDTaskType.Text = "MPD Work Type:";
			this.labelMPDTaskType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lookupComboboxMaintenanceDirective
			// 
			this.lookupComboboxMaintenanceDirective.ButtonCreateVisible = false;
			this.lookupComboboxMaintenanceDirective.ButtonEditVisible = false;
			this.lookupComboboxMaintenanceDirective.Displayer = null;
			this.lookupComboboxMaintenanceDirective.DisplayerText = null;
			this.lookupComboboxMaintenanceDirective.Entity = null;
			this.lookupComboboxMaintenanceDirective.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxMaintenanceDirective.Location = new System.Drawing.Point(160, 38);
			this.lookupComboboxMaintenanceDirective.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lookupComboboxMaintenanceDirective.Name = "lookupComboboxMaintenanceDirective";
			this.lookupComboboxMaintenanceDirective.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxMaintenanceDirective.Size = new System.Drawing.Size(351, 22);
			this.lookupComboboxMaintenanceDirective.TabIndex = 194;
			this.lookupComboboxMaintenanceDirective.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxMaintenanceDirectiveSelectedIndexChanged);
			// 
			// labelMPDItem
			// 
			this.labelMPDItem.AutoSize = true;
			this.labelMPDItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItem.Location = new System.Drawing.Point(10, 41);
			this.labelMPDItem.Name = "labelMPDItem";
			this.labelMPDItem.Size = new System.Drawing.Size(72, 14);
			this.labelMPDItem.TabIndex = 195;
			this.labelMPDItem.Text = "MPD Item:";
			// 
			// comboBoxMpdTaskType
			// 
			this.comboBoxMpdTaskType.BackColor = System.Drawing.Color.White;
			this.comboBoxMpdTaskType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxMpdTaskType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxMpdTaskType.Location = new System.Drawing.Point(699, 38);
			this.comboBoxMpdTaskType.Name = "comboBoxMpdTaskType";
			this.comboBoxMpdTaskType.Size = new System.Drawing.Size(350, 22);
			this.comboBoxMpdTaskType.TabIndex = 193;
			// 
			// fileControl
			// 
			this.fileControl.AutoSize = true;
			this.fileControl.Description1 = "";
			this.fileControl.Description2 = "";
			this.fileControl.Filter = "Adobe PDF Files|*.pdf";
			this.fileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControl.Location = new System.Drawing.Point(700, 103);
			this.fileControl.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControl.Name = "fileControl";
			this.fileControl.ShowLinkLabelBrowse = true;
			this.fileControl.ShowLinkLabelRemove = false;
			this.fileControl.Size = new System.Drawing.Size(350, 37);
			this.fileControl.TabIndex = 197;
			this.fileControl.Visible = false;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(700, 103);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(349, 41);
			this.documentControl1.TabIndex = 199;
			// 
			// ComponentAddCompliancePerformanceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.fileControl);
			this.Controls.Add(this.labelMPDTaskType);
			this.Controls.Add(this.lookupComboboxMaintenanceDirective);
			this.Controls.Add(this.labelMPDItem);
			this.Controls.Add(this.comboBoxMpdTaskType);
			this.Controls.Add(this.labelEffectivityDate);
			this.Controls.Add(this.dateTimePickerEffDate);
			this.Controls.Add(this.checkBox_Repeat);
			this.Controls.Add(this.lifelengthViewer_FirstPerformance);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.textBoxHiddenRemarks);
			this.Controls.Add(this.labelFAAForm);
			this.Controls.Add(this.labelCost);
			this.Controls.Add(this.textBoxCost);
			this.Controls.Add(this.labelManHours);
			this.Controls.Add(this.labelKitRequired);
			this.Controls.Add(this.textBoxManHours);
			this.Controls.Add(this.textBoxKitRequired);
			this.Controls.Add(this.radio_WhicheverLater);
			this.Controls.Add(this.radio_WhicheverFirst);
			this.Controls.Add(this.labelWorkType);
			this.Controls.Add(this.comboBoxWorkType);
			this.Controls.Add(this.lifelengthViewer_FirstNotify);
			this.Controls.Add(this.lifelengthViewerRptInterval);
			this.Controls.Add(this.lifelengthViewerRptNotify);
			this.Controls.Add(this.lifelengthViewerWarrantyNotify);
			this.Controls.Add(this.lifelengthViewerWarranty);
			this.Name = "ComponentAddCompliancePerformanceControl";
			this.Size = new System.Drawing.Size(1053, 410);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWorkType;
        private System.Windows.Forms.ComboBox comboBoxWorkType;
        private LifelengthViewer lifelengthViewerRptInterval;
        private LifelengthViewer lifelengthViewerRptNotify;
        private LifelengthViewer lifelengthViewer_FirstPerformance;
        private LifelengthViewer lifelengthViewer_FirstNotify;
        private System.Windows.Forms.RadioButton radio_WhicheverFirst;
        private System.Windows.Forms.RadioButton radio_WhicheverLater;
        private System.Windows.Forms.CheckBox checkBox_Repeat;
        private LifelengthViewer lifelengthViewerWarranty;
        private LifelengthViewer lifelengthViewerWarrantyNotify;
        private System.Windows.Forms.Label labelManHours;
        private System.Windows.Forms.Label labelKitRequired;
        private System.Windows.Forms.TextBox textBoxManHours;
        private System.Windows.Forms.TextBox textBoxKitRequired;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Label labelFAAForm;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.Label labelHiddenRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.TextBox textBoxHiddenRemarks;
        private System.Windows.Forms.Label labelEffectivityDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEffDate;
        private System.Windows.Forms.Label labelMPDTaskType;
        private LookupCombobox lookupComboboxMaintenanceDirective;
        private System.Windows.Forms.Label labelMPDItem;
        private System.Windows.Forms.ComboBox comboBoxMpdTaskType;
        private AttachedFileControl fileControl;
		private DocumentationControls.DocumentControl documentControl1;
	}
}
