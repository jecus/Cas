namespace CAS.UI.UIControls.PersonnelControls.EmployeeTraining
{
	partial class EmployeeTrainingControl
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
			this.labelTraining = new System.Windows.Forms.Label();
			this.labelEffectivityDate = new System.Windows.Forms.Label();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.groupBoxClose = new System.Windows.Forms.GroupBox();
			this.checkBoxClose = new System.Windows.Forms.CheckBox();
			this.comboBoxTrainingType = new System.Windows.Forms.ComboBox();
			this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this._mainPanel = new System.Windows.Forms.Panel();
			this.lookupComboboxSubject = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxAircraftModel = new System.Windows.Forms.ComboBox();
			this.labelSupplier = new System.Windows.Forms.Label();
			this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.lifelengthViewerRptNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerRptInterval = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstPerformance = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.textBoxCost = new System.Windows.Forms.TextBox();
			this.labelCost = new System.Windows.Forms.Label();
			this.textBoxManHours = new System.Windows.Forms.TextBox();
			this.labelManHours = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.labelForm = new System.Windows.Forms.Label();
			this.groupBoxClose.SuspendLayout();
			this._mainPanel.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTraining
			// 
			this.labelTraining.AutoSize = true;
			this.labelTraining.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTraining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTraining.Location = new System.Drawing.Point(35, 9);
			this.labelTraining.Name = "labelTraining";
			this.labelTraining.Size = new System.Drawing.Size(93, 14);
			this.labelTraining.TabIndex = 197;
			this.labelTraining.Text = "Training type:";
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.AutoSize = true;
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(545, 145);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(111, 17);
			this.labelEffectivityDate.TabIndex = 65;
			this.labelEffectivityDate.Text = "Effective Date:";
			// 
			// dateTimePickerEffDate
			// 
			this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(695, 139);
			this.dateTimePickerEffDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 25);
			this.dateTimePickerEffDate.TabIndex = 66;
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
			// groupBoxClose
			// 
			this.groupBoxClose.Controls.Add(this.checkBoxClose);
			this.groupBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.groupBoxClose.Location = new System.Drawing.Point(1050, 324);
			this.groupBoxClose.Name = "groupBoxClose";
			this.groupBoxClose.Size = new System.Drawing.Size(86, 110);
			this.groupBoxClose.TabIndex = 64;
			this.groupBoxClose.TabStop = false;
			this.groupBoxClose.Text = "STATUS";
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
			// 
			// comboBoxTrainingType
			// 
			this.comboBoxTrainingType.BackColor = System.Drawing.Color.White;
			this.comboBoxTrainingType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxTrainingType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxTrainingType.Location = new System.Drawing.Point(156, 5);
			this.comboBoxTrainingType.Name = "comboBoxTrainingType";
			this.comboBoxTrainingType.Size = new System.Drawing.Size(351, 22);
			this.comboBoxTrainingType.TabIndex = 26;
			// 
			// linkLabelRemove
			// 
			this.linkLabelRemove.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemove.Location = new System.Drawing.Point(509, 417);
			this.linkLabelRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelRemove.Name = "linkLabelRemove";
			this.linkLabelRemove.Size = new System.Drawing.Size(120, 24);
			this.linkLabelRemove.TabIndex = 20;
			this.linkLabelRemove.TabStop = true;
			this.linkLabelRemove.Text = "Remove";
			this.linkLabelRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked_1);
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.BackColor = System.Drawing.Color.White;
			this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxRemarks.Location = new System.Drawing.Point(156, 252);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxRemarks.Size = new System.Drawing.Size(350, 75);
			this.textBoxRemarks.TabIndex = 8;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(6, 252);
			this.labelRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(150, 20);
			this.labelRemarks.TabIndex = 7;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _mainPanel
			// 
			this._mainPanel.Controls.Add(this.documentControl1);
			this._mainPanel.Controls.Add(this.lookupComboboxSubject);
			this._mainPanel.Controls.Add(this.label2);
			this._mainPanel.Controls.Add(this.label1);
			this._mainPanel.Controls.Add(this.comboBoxAircraftModel);
			this._mainPanel.Controls.Add(this.labelSupplier);
			this._mainPanel.Controls.Add(this.comboBoxSupplier);
			this._mainPanel.Controls.Add(this.textBoxDescription);
			this._mainPanel.Controls.Add(this.labelDescription);
			this._mainPanel.Controls.Add(this.labelTraining);
			this._mainPanel.Controls.Add(this.labelEffectivityDate);
			this._mainPanel.Controls.Add(this.dateTimePickerEffDate);
			this._mainPanel.Controls.Add(this.imageLinkLabelStatus);
			this._mainPanel.Controls.Add(this.groupBoxClose);
			this._mainPanel.Controls.Add(this.lifelengthViewerRptNotify);
			this._mainPanel.Controls.Add(this.lifelengthViewerRptInterval);
			this._mainPanel.Controls.Add(this.comboBoxTrainingType);
			this._mainPanel.Controls.Add(this.linkLabelRemove);
			this._mainPanel.Controls.Add(this.textBoxRemarks);
			this._mainPanel.Controls.Add(this.lifelengthViewer_FirstNotify);
			this._mainPanel.Controls.Add(this.labelRemarks);
			this._mainPanel.Controls.Add(this.lifelengthViewer_FirstPerformance);
			this._mainPanel.Controls.Add(this.labelHiddenRemarks);
			this._mainPanel.Controls.Add(this.textBoxHiddenRemarks);
			this._mainPanel.Controls.Add(this.textBoxCost);
			this._mainPanel.Controls.Add(this.labelCost);
			this._mainPanel.Controls.Add(this.labelForm);
			this._mainPanel.Controls.Add(this.textBoxManHours);
			this._mainPanel.Controls.Add(this.labelManHours);
			this._mainPanel.Location = new System.Drawing.Point(3, 3);
			this._mainPanel.Name = "_mainPanel";
			this._mainPanel.Size = new System.Drawing.Size(1143, 437);
			this._mainPanel.TabIndex = 65;
			// 
			// lookupComboboxSubject
			// 
			this.lookupComboboxSubject.Displayer = null;
			this.lookupComboboxSubject.DisplayerText = null;
			this.lookupComboboxSubject.Entity = null;
			this.lookupComboboxSubject.Location = new System.Drawing.Point(155, 60);
			this.lookupComboboxSubject.Name = "lookupComboboxSubject";
			this.lookupComboboxSubject.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxSubject.Size = new System.Drawing.Size(353, 21);
			this.lookupComboboxSubject.TabIndex = 206;
			this.lookupComboboxSubject.Type = null;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(7, 57);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(121, 20);
			this.label2.TabIndex = 204;
			this.label2.Text = "Subject:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(7, 32);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 20);
			this.label1.TabIndex = 203;
			this.label1.Text = "Type of Aircraft:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxAircraftModel
			// 
			this.comboBoxAircraftModel.BackColor = System.Drawing.Color.White;
			this.comboBoxAircraftModel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAircraftModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxAircraftModel.Location = new System.Drawing.Point(155, 32);
			this.comboBoxAircraftModel.Name = "comboBoxAircraftModel";
			this.comboBoxAircraftModel.Size = new System.Drawing.Size(352, 22);
			this.comboBoxAircraftModel.TabIndex = 202;
			// 
			// labelSupplier
			// 
			this.labelSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplier.Location = new System.Drawing.Point(7, 163);
			this.labelSupplier.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(150, 25);
			this.labelSupplier.TabIndex = 201;
			this.labelSupplier.Text = "Supplier:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxSupplier
			// 
			this.comboBoxSupplier.BackColor = System.Drawing.Color.White;
			this.comboBoxSupplier.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupplier.Location = new System.Drawing.Point(157, 165);
			this.comboBoxSupplier.Name = "comboBoxSupplier";
			this.comboBoxSupplier.Size = new System.Drawing.Size(351, 22);
			this.comboBoxSupplier.TabIndex = 200;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(157, 85);
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(350, 75);
			this.textBoxDescription.TabIndex = 199;
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(7, 85);
			this.labelDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(150, 20);
			this.labelDescription.TabIndex = 198;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
			this.lifelengthViewerRptNotify.Location = new System.Drawing.Point(632, 390);
			this.lifelengthViewerRptNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRptNotify.Modified = false;
			this.lifelengthViewerRptNotify.Name = "lifelengthViewerRptNotify";
			this.lifelengthViewerRptNotify.ReadOnly = false;
			this.lifelengthViewerRptNotify.ShowCalendar = true;
			this.lifelengthViewerRptNotify.ShowCalendarOnly = true;
			this.lifelengthViewerRptNotify.ShowFormattedCalendar = false;
			this.lifelengthViewerRptNotify.ShowHeaders = false;
			this.lifelengthViewerRptNotify.ShowMinutes = false;
			this.lifelengthViewerRptNotify.Size = new System.Drawing.Size(231, 35);
			this.lifelengthViewerRptNotify.SystemCalculated = true;
			this.lifelengthViewerRptNotify.TabIndex = 14;
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
			this.lifelengthViewerRptInterval.Location = new System.Drawing.Point(44, 390);
			this.lifelengthViewerRptInterval.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerRptInterval.Modified = false;
			this.lifelengthViewerRptInterval.Name = "lifelengthViewerRptInterval";
			this.lifelengthViewerRptInterval.ReadOnly = false;
			this.lifelengthViewerRptInterval.ShowCalendar = true;
			this.lifelengthViewerRptInterval.ShowCalendarOnly = true;
			this.lifelengthViewerRptInterval.ShowFormattedCalendar = false;
			this.lifelengthViewerRptInterval.ShowHeaders = false;
			this.lifelengthViewerRptInterval.ShowMinutes = false;
			this.lifelengthViewerRptInterval.Size = new System.Drawing.Size(282, 35);
			this.lifelengthViewerRptInterval.SystemCalculated = true;
			this.lifelengthViewerRptInterval.TabIndex = 12;
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
			this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(632, 335);
			this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstNotify.Modified = false;
			this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
			this.lifelengthViewer_FirstNotify.ReadOnly = false;
			this.lifelengthViewer_FirstNotify.ShowCalendar = true;
			this.lifelengthViewer_FirstNotify.ShowCalendarOnly = true;
			this.lifelengthViewer_FirstNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstNotify.ShowMinutes = false;
			this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(231, 52);
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
			this.lifelengthViewer_FirstPerformance.Location = new System.Drawing.Point(62, 335);
			this.lifelengthViewer_FirstPerformance.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstPerformance.Modified = false;
			this.lifelengthViewer_FirstPerformance.Name = "lifelengthViewer_FirstPerformance";
			this.lifelengthViewer_FirstPerformance.ReadOnly = false;
			this.lifelengthViewer_FirstPerformance.ShowCalendar = true;
			this.lifelengthViewer_FirstPerformance.ShowCalendarOnly = true;
			this.lifelengthViewer_FirstPerformance.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstPerformance.ShowMinutes = false;
			this.lifelengthViewer_FirstPerformance.Size = new System.Drawing.Size(264, 52);
			this.lifelengthViewer_FirstPerformance.SystemCalculated = true;
			this.lifelengthViewer_FirstPerformance.TabIndex = 59;
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(546, 250);
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
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(695, 252);
			this.textBoxHiddenRemarks.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxHiddenRemarks.MaxLength = 34000;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(350, 75);
			this.textBoxHiddenRemarks.TabIndex = 58;
			// 
			// textBoxCost
			// 
			this.textBoxCost.BackColor = System.Drawing.Color.White;
			this.textBoxCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxCost.Location = new System.Drawing.Point(157, 224);
			this.textBoxCost.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxCost.Name = "textBoxCost";
			this.textBoxCost.Size = new System.Drawing.Size(350, 22);
			this.textBoxCost.TabIndex = 4;
			// 
			// labelCost
			// 
			this.labelCost.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCost.Location = new System.Drawing.Point(7, 222);
			this.labelCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelCost.Name = "labelCost";
			this.labelCost.Size = new System.Drawing.Size(150, 25);
			this.labelCost.TabIndex = 3;
			this.labelCost.Text = "Cost (USD):";
			this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxManHours
			// 
			this.textBoxManHours.BackColor = System.Drawing.Color.White;
			this.textBoxManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManHours.Location = new System.Drawing.Point(157, 192);
			this.textBoxManHours.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxManHours.Name = "textBoxManHours";
			this.textBoxManHours.Size = new System.Drawing.Size(350, 22);
			this.textBoxManHours.TabIndex = 2;
			// 
			// labelManHours
			// 
			this.labelManHours.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManHours.Location = new System.Drawing.Point(7, 192);
			this.labelManHours.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelManHours.Name = "labelManHours";
			this.labelManHours.Size = new System.Drawing.Size(150, 25);
			this.labelManHours.TabIndex = 1;
			this.labelManHours.Text = "Man Hours:";
			this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this._mainPanel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1149, 445);
			this.flowLayoutPanel1.TabIndex = 67;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(695, 174);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(350, 41);
			this.documentControl1.TabIndex = 207;
			// 
			// labelForm
			// 
			this.labelForm.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelForm.Location = new System.Drawing.Point(546, 174);
			this.labelForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelForm.Name = "labelForm";
			this.labelForm.Size = new System.Drawing.Size(150, 20);
			this.labelForm.TabIndex = 53;
			this.labelForm.Text = "Form:";
			this.labelForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// EmployeeTrainingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "EmployeeTrainingControl";
			this.Size = new System.Drawing.Size(1149, 445);
			this.groupBoxClose.ResumeLayout(false);
			this.groupBoxClose.PerformLayout();
			this._mainPanel.ResumeLayout(false);
			this._mainPanel.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelTraining;
		private System.Windows.Forms.Label labelEffectivityDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerEffDate;
		private AvControls.StatusImageLink.StatusImageLinkLabel imageLinkLabelStatus;
		private System.Windows.Forms.GroupBox groupBoxClose;
		private System.Windows.Forms.CheckBox checkBoxClose;
		private Auxiliary.LifelengthViewer lifelengthViewerRptNotify;
		private Auxiliary.LifelengthViewer lifelengthViewerRptInterval;
		private System.Windows.Forms.ComboBox comboBoxTrainingType;
		private System.Windows.Forms.LinkLabel linkLabelRemove;
		private System.Windows.Forms.TextBox textBoxRemarks;
		private Auxiliary.LifelengthViewer lifelengthViewer_FirstNotify;
		private System.Windows.Forms.Label labelRemarks;
		private Auxiliary.LifelengthViewer lifelengthViewer_FirstPerformance;
		private System.Windows.Forms.Panel _mainPanel;
		private System.Windows.Forms.Label labelHiddenRemarks;
		private System.Windows.Forms.TextBox textBoxHiddenRemarks;
		private System.Windows.Forms.TextBox textBoxCost;
		private System.Windows.Forms.Label labelCost;
		private System.Windows.Forms.TextBox textBoxManHours;
		private System.Windows.Forms.Label labelManHours;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelSupplier;
		private System.Windows.Forms.ComboBox comboBoxSupplier;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxAircraftModel;
		private System.Windows.Forms.Label label2;
		private Auxiliary.LookupCombobox lookupComboboxSubject;
		private DocumentationControls.DocumentControl documentControl1;
		private System.Windows.Forms.Label labelForm;
	}
}
