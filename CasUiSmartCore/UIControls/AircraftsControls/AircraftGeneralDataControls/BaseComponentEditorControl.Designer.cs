using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
	sealed partial class BaseComponentEditorControl
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
			System.Windows.Forms.GroupBox groupBox1;
			System.Windows.Forms.GroupBox groupBox2;
			System.Windows.Forms.GroupBox groupBox3;
			System.Windows.Forms.GroupBox groupBox4;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseComponentEditorControl));
			this.lifelengthViewerStart = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
			this.lifelengthViewerInstallation = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.dateTimePickerInstallation = new System.Windows.Forms.DateTimePicker();
			this.lifelengthViewerLifeLimit = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerWarranty = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelCaption = new System.Windows.Forms.Label();
			this.labelEngineModel = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.labelPosition = new System.Windows.Forms.Label();
			this.labelSerialNumber = new System.Windows.Forms.Label();
			this.labelTSNCSN = new System.Windows.Forms.Label();
			this.labelCompliance = new System.Windows.Forms.Label();
			this.labelComplianceTSNCSN = new System.Windows.Forms.Label();
			this.labelComplianceDate = new System.Windows.Forms.Label();
			this.labelComplianceWorkType = new System.Windows.Forms.Label();
			this.labelNext = new System.Windows.Forms.Label();
			this.labelNextTSNCSN = new System.Windows.Forms.Label();
			this.labelNextDate = new System.Windows.Forms.Label();
			this.labelNextRemains = new System.Windows.Forms.Label();
			this.labelNextWorkType = new System.Windows.Forms.Label();
			this.comboBoxEngineModel = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.textBoxPosition = new System.Windows.Forms.TextBox();
			this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
			this.textBoxTSNCSN = new System.Windows.Forms.TextBox();
			this.textBoxComplianceTSNCSN = new System.Windows.Forms.TextBox();
			this.textBoxComplianceDate = new System.Windows.Forms.TextBox();
			this.textBoxComplianceWorktype = new System.Windows.Forms.TextBox();
			this.textBoxNextTSNCSN = new System.Windows.Forms.TextBox();
			this.textBoxNextDate = new System.Windows.Forms.TextBox();
			this.textBoxNextRemains = new System.Windows.Forms.TextBox();
			this.textBoxNextWorkType = new System.Windows.Forms.TextBox();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
			this.labelPN = new System.Windows.Forms.Label();
			this.textBoxPartialNumber = new System.Windows.Forms.TextBox();
			this.linkViewInfo = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			this.delimiter1 = new SmartControls.General.Delimiter();
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox2 = new System.Windows.Forms.GroupBox();
			groupBox3 = new System.Windows.Forms.GroupBox();
			groupBox4 = new System.Windows.Forms.GroupBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(this.lifelengthViewerStart);
			groupBox1.Controls.Add(this.dateTimePickerStart);
			groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			groupBox1.Location = new System.Drawing.Point(6, 320);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(371, 112);
			groupBox1.TabIndex = 28;
			groupBox1.TabStop = false;
			groupBox1.Text = "Start";
			// 
			// lifelengthViewerStart
			// 
			this.lifelengthViewerStart.AutoSize = true;
			this.lifelengthViewerStart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerStart.CalendarApplicable = false;
			this.lifelengthViewerStart.CyclesApplicable = false;
			this.lifelengthViewerStart.EnabledCalendar = false;
			this.lifelengthViewerStart.EnabledCycle = true;
			this.lifelengthViewerStart.EnabledHours = true;
			this.lifelengthViewerStart.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerStart.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerStart.HeaderCalendar = "Calendar";
			this.lifelengthViewerStart.HeaderCycles = "Cycles";
			this.lifelengthViewerStart.HeaderHours = "Hours";
			this.lifelengthViewerStart.HoursApplicable = false;
			this.lifelengthViewerStart.LeftHeader = "";
			this.lifelengthViewerStart.Location = new System.Drawing.Point(6, 50);
			this.lifelengthViewerStart.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerStart.Modified = false;
			this.lifelengthViewerStart.Name = "lifelengthViewerStart";
			this.lifelengthViewerStart.ReadOnly = false;
			this.lifelengthViewerStart.ShowCalendar = true;
			this.lifelengthViewerStart.ShowLeftHeader = false;
			this.lifelengthViewerStart.ShowMinutes = true;
			this.lifelengthViewerStart.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerStart.SystemCalculated = true;
			this.lifelengthViewerStart.TabIndex = 26;
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerStart.Location = new System.Drawing.Point(6, 19);
			this.dateTimePickerStart.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerStart.Name = "dateTimePickerStart";
			this.dateTimePickerStart.Size = new System.Drawing.Size(176, 25);
			this.dateTimePickerStart.TabIndex = 27;
			this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(this.lifelengthViewerInstallation);
			groupBox2.Controls.Add(this.dateTimePickerInstallation);
			groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			groupBox2.Location = new System.Drawing.Point(6, 438);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(371, 112);
			groupBox2.TabIndex = 29;
			groupBox2.TabStop = false;
			groupBox2.Text = "Installation";
			// 
			// lifelengthViewerInstallation
			// 
			this.lifelengthViewerInstallation.AutoSize = true;
			this.lifelengthViewerInstallation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerInstallation.CalendarApplicable = false;
			this.lifelengthViewerInstallation.CyclesApplicable = false;
			this.lifelengthViewerInstallation.EnabledCalendar = false;
			this.lifelengthViewerInstallation.EnabledCycle = true;
			this.lifelengthViewerInstallation.EnabledHours = true;
			this.lifelengthViewerInstallation.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerInstallation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerInstallation.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerInstallation.HeaderCalendar = "Calendar";
			this.lifelengthViewerInstallation.HeaderCycles = "Cycles";
			this.lifelengthViewerInstallation.HeaderHours = "Hours";
			this.lifelengthViewerInstallation.HoursApplicable = false;
			this.lifelengthViewerInstallation.LeftHeader = "";
			this.lifelengthViewerInstallation.Location = new System.Drawing.Point(6, 50);
			this.lifelengthViewerInstallation.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerInstallation.Modified = false;
			this.lifelengthViewerInstallation.Name = "lifelengthViewerInstallation";
			this.lifelengthViewerInstallation.ReadOnly = false;
			this.lifelengthViewerInstallation.ShowCalendar = true;
			this.lifelengthViewerInstallation.ShowLeftHeader = false;
			this.lifelengthViewerInstallation.ShowMinutes = true;
			this.lifelengthViewerInstallation.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerInstallation.SystemCalculated = true;
			this.lifelengthViewerInstallation.TabIndex = 26;
			// 
			// dateTimePickerInstallation
			// 
			this.dateTimePickerInstallation.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerInstallation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerInstallation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerInstallation.Location = new System.Drawing.Point(6, 19);
			this.dateTimePickerInstallation.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerInstallation.Name = "dateTimePickerInstallation";
			this.dateTimePickerInstallation.Size = new System.Drawing.Size(176, 25);
			this.dateTimePickerInstallation.TabIndex = 27;
			this.dateTimePickerInstallation.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(this.lifelengthViewerLifeLimit);
			groupBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			groupBox3.Location = new System.Drawing.Point(6, 556);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(371, 87);
			groupBox3.TabIndex = 30;
			groupBox3.TabStop = false;
			groupBox3.Text = "Life Limit";
			// 
			// lifelengthViewerLifeLimit
			// 
			this.lifelengthViewerLifeLimit.AutoSize = true;
			this.lifelengthViewerLifeLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerLifeLimit.CalendarApplicable = false;
			this.lifelengthViewerLifeLimit.CyclesApplicable = false;
			this.lifelengthViewerLifeLimit.EnabledCalendar = true;
			this.lifelengthViewerLifeLimit.EnabledCycle = true;
			this.lifelengthViewerLifeLimit.EnabledHours = true;
			this.lifelengthViewerLifeLimit.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerLifeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerLifeLimit.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerLifeLimit.HeaderCalendar = "Calendar";
			this.lifelengthViewerLifeLimit.HeaderCycles = "Cycles";
			this.lifelengthViewerLifeLimit.HeaderHours = "Hours";
			this.lifelengthViewerLifeLimit.HoursApplicable = false;
			this.lifelengthViewerLifeLimit.LeftHeader = "";
			this.lifelengthViewerLifeLimit.Location = new System.Drawing.Point(6, 26);
			this.lifelengthViewerLifeLimit.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerLifeLimit.Modified = false;
			this.lifelengthViewerLifeLimit.Name = "lifelengthViewerLifeLimit";
			this.lifelengthViewerLifeLimit.ReadOnly = false;
			this.lifelengthViewerLifeLimit.ShowCalendar = true;
			this.lifelengthViewerLifeLimit.ShowLeftHeader = false;
			this.lifelengthViewerLifeLimit.ShowMinutes = true;
			this.lifelengthViewerLifeLimit.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerLifeLimit.SystemCalculated = true;
			this.lifelengthViewerLifeLimit.TabIndex = 26;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(this.lifelengthViewerWarranty);
			groupBox4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			groupBox4.Location = new System.Drawing.Point(6, 651);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(371, 87);
			groupBox4.TabIndex = 31;
			groupBox4.TabStop = false;
			groupBox4.Text = "Warranty";
			// 
			// lifelengthViewerWarranty
			// 
			this.lifelengthViewerWarranty.AutoSize = true;
			this.lifelengthViewerWarranty.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerWarranty.CalendarApplicable = false;
			this.lifelengthViewerWarranty.CyclesApplicable = false;
			this.lifelengthViewerWarranty.EnabledCalendar = true;
			this.lifelengthViewerWarranty.EnabledCycle = true;
			this.lifelengthViewerWarranty.EnabledHours = true;
			this.lifelengthViewerWarranty.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.lifelengthViewerWarranty.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewerWarranty.HeaderCalendar = "Calendar";
			this.lifelengthViewerWarranty.HeaderCycles = "Cycles";
			this.lifelengthViewerWarranty.HeaderHours = "Hours";
			this.lifelengthViewerWarranty.HoursApplicable = false;
			this.lifelengthViewerWarranty.LeftHeader = "";
			this.lifelengthViewerWarranty.Location = new System.Drawing.Point(6, 26);
			this.lifelengthViewerWarranty.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewerWarranty.Modified = false;
			this.lifelengthViewerWarranty.Name = "lifelengthViewerWarranty";
			this.lifelengthViewerWarranty.ReadOnly = false;
			this.lifelengthViewerWarranty.ShowCalendar = true;
			this.lifelengthViewerWarranty.ShowLeftHeader = false;
			this.lifelengthViewerWarranty.ShowMinutes = true;
			this.lifelengthViewerWarranty.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerWarranty.SystemCalculated = true;
			this.lifelengthViewerWarranty.TabIndex = 26;
			// 
			// labelCaption
			// 
			this.labelCaption.AutoSize = true;
			this.labelCaption.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCaption.Location = new System.Drawing.Point(142, 9);
			this.labelCaption.Name = "labelCaption";
			this.labelCaption.Size = new System.Drawing.Size(36, 17);
			this.labelCaption.TabIndex = 0;
			this.labelCaption.Text = "pos";
			this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelEngineModel
			// 
			this.labelEngineModel.AutoSize = true;
			this.labelEngineModel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEngineModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEngineModel.Location = new System.Drawing.Point(9, 42);
			this.labelEngineModel.Name = "labelEngineModel";
			this.labelEngineModel.Size = new System.Drawing.Size(100, 17);
			this.labelEngineModel.TabIndex = 1;
			this.labelEngineModel.Text = "Engine Model";
			this.labelEngineModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(9, 83);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(100, 17);
			this.labelManufacturer.TabIndex = 2;
			this.labelManufacturer.Text = "Manufacturer";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPosition.Location = new System.Drawing.Point(9, 124);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(63, 17);
			this.labelPosition.TabIndex = 3;
			this.labelPosition.Text = "Position";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.AutoSize = true;
			this.labelSerialNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNumber.Location = new System.Drawing.Point(9, 165);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(106, 17);
			this.labelSerialNumber.TabIndex = 4;
			this.labelSerialNumber.Text = "Serial Number";
			this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTSNCSN
			// 
			this.labelTSNCSN.AutoSize = true;
			this.labelTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTSNCSN.Location = new System.Drawing.Point(9, 247);
			this.labelTSNCSN.Name = "labelTSNCSN";
			this.labelTSNCSN.Size = new System.Drawing.Size(73, 17);
			this.labelTSNCSN.TabIndex = 5;
			this.labelTSNCSN.Text = "TSN/CSN";
			this.labelTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompliance
			// 
			this.labelCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompliance.Location = new System.Drawing.Point(0, 0);
			this.labelCompliance.Name = "labelCompliance";
			this.labelCompliance.Size = new System.Drawing.Size(100, 23);
			this.labelCompliance.TabIndex = 0;
			this.labelCompliance.Text = "Compliance";
			this.labelCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelComplianceTSNCSN
			// 
			this.labelComplianceTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComplianceTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComplianceTSNCSN.Location = new System.Drawing.Point(0, 0);
			this.labelComplianceTSNCSN.Name = "labelComplianceTSNCSN";
			this.labelComplianceTSNCSN.Size = new System.Drawing.Size(100, 23);
			this.labelComplianceTSNCSN.TabIndex = 0;
			this.labelComplianceTSNCSN.Text = "TSN/CSN";
			this.labelComplianceTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelComplianceDate
			// 
			this.labelComplianceDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComplianceDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComplianceDate.Location = new System.Drawing.Point(0, 0);
			this.labelComplianceDate.Name = "labelComplianceDate";
			this.labelComplianceDate.Size = new System.Drawing.Size(100, 23);
			this.labelComplianceDate.TabIndex = 0;
			this.labelComplianceDate.Text = "Date";
			this.labelComplianceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelComplianceWorkType
			// 
			this.labelComplianceWorkType.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComplianceWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComplianceWorkType.Location = new System.Drawing.Point(0, 0);
			this.labelComplianceWorkType.Name = "labelComplianceWorkType";
			this.labelComplianceWorkType.Size = new System.Drawing.Size(100, 23);
			this.labelComplianceWorkType.TabIndex = 0;
			this.labelComplianceWorkType.Text = "Work Type";
			this.labelComplianceWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNext
			// 
			this.labelNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNext.Location = new System.Drawing.Point(0, 0);
			this.labelNext.Name = "labelNext";
			this.labelNext.Size = new System.Drawing.Size(100, 23);
			this.labelNext.TabIndex = 0;
			this.labelNext.Text = "Next";
			this.labelNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNextTSNCSN
			// 
			this.labelNextTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextTSNCSN.Location = new System.Drawing.Point(0, 0);
			this.labelNextTSNCSN.Name = "labelNextTSNCSN";
			this.labelNextTSNCSN.Size = new System.Drawing.Size(100, 23);
			this.labelNextTSNCSN.TabIndex = 0;
			this.labelNextTSNCSN.Text = "TSN/CSN";
			this.labelNextTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNextDate
			// 
			this.labelNextDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextDate.Location = new System.Drawing.Point(0, 0);
			this.labelNextDate.Name = "labelNextDate";
			this.labelNextDate.Size = new System.Drawing.Size(100, 23);
			this.labelNextDate.TabIndex = 0;
			this.labelNextDate.Text = "Date";
			this.labelNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNextRemains
			// 
			this.labelNextRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextRemains.Location = new System.Drawing.Point(0, 0);
			this.labelNextRemains.Name = "labelNextRemains";
			this.labelNextRemains.Size = new System.Drawing.Size(100, 23);
			this.labelNextRemains.TabIndex = 0;
			this.labelNextRemains.Text = "Remains";
			this.labelNextRemains.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelNextWorkType
			// 
			this.labelNextWorkType.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextWorkType.Location = new System.Drawing.Point(0, 0);
			this.labelNextWorkType.Name = "labelNextWorkType";
			this.labelNextWorkType.Size = new System.Drawing.Size(100, 23);
			this.labelNextWorkType.TabIndex = 0;
			this.labelNextWorkType.Text = "Work Type";
			this.labelNextWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxEngineModel
			// 
			this.comboBoxEngineModel.Displayer = null;
			this.comboBoxEngineModel.DisplayerText = null;
			this.comboBoxEngineModel.Entity = null;
			this.comboBoxEngineModel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxEngineModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxEngineModel.Location = new System.Drawing.Point(145, 39);
			this.comboBoxEngineModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.comboBoxEngineModel.Name = "comboBoxEngineModel";
			this.comboBoxEngineModel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxEngineModel.Size = new System.Drawing.Size(232, 25);
			this.comboBoxEngineModel.TabIndex = 6;
			this.comboBoxEngineModel.Type = null;
			this.comboBoxEngineModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxEngineModel_SelectedIndexChanged);
			this.comboBoxEngineModel.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(145, 80);
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(232, 25);
			this.textBoxManufacturer.TabIndex = 7;
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.BackColor = System.Drawing.Color.White;
			this.textBoxPosition.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPosition.Location = new System.Drawing.Point(145, 121);
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.Size = new System.Drawing.Size(232, 25);
			this.textBoxPosition.TabIndex = 8;
			// 
			// textBoxSerialNumber
			// 
			this.textBoxSerialNumber.BackColor = System.Drawing.Color.White;
			this.textBoxSerialNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSerialNumber.Location = new System.Drawing.Point(145, 162);
			this.textBoxSerialNumber.Name = "textBoxSerialNumber";
			this.textBoxSerialNumber.Size = new System.Drawing.Size(232, 25);
			this.textBoxSerialNumber.TabIndex = 9;
			// 
			// textBoxTSNCSN
			// 
			this.textBoxTSNCSN.BackColor = System.Drawing.Color.White;
			this.textBoxTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTSNCSN.Location = new System.Drawing.Point(145, 244);
			this.textBoxTSNCSN.Name = "textBoxTSNCSN";
			this.textBoxTSNCSN.ReadOnly = true;
			this.textBoxTSNCSN.Size = new System.Drawing.Size(232, 25);
			this.textBoxTSNCSN.TabIndex = 10;
			// 
			// textBoxComplianceTSNCSN
			// 
			this.textBoxComplianceTSNCSN.BackColor = System.Drawing.Color.White;
			this.textBoxComplianceTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxComplianceTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxComplianceTSNCSN.Location = new System.Drawing.Point(0, 0);
			this.textBoxComplianceTSNCSN.Name = "textBoxComplianceTSNCSN";
			this.textBoxComplianceTSNCSN.ReadOnly = true;
			this.textBoxComplianceTSNCSN.Size = new System.Drawing.Size(100, 25);
			this.textBoxComplianceTSNCSN.TabIndex = 0;
			// 
			// textBoxComplianceDate
			// 
			this.textBoxComplianceDate.BackColor = System.Drawing.Color.White;
			this.textBoxComplianceDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxComplianceDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxComplianceDate.Location = new System.Drawing.Point(0, 0);
			this.textBoxComplianceDate.Name = "textBoxComplianceDate";
			this.textBoxComplianceDate.ReadOnly = true;
			this.textBoxComplianceDate.Size = new System.Drawing.Size(100, 25);
			this.textBoxComplianceDate.TabIndex = 0;
			// 
			// textBoxComplianceWorktype
			// 
			this.textBoxComplianceWorktype.BackColor = System.Drawing.Color.White;
			this.textBoxComplianceWorktype.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxComplianceWorktype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxComplianceWorktype.Location = new System.Drawing.Point(0, 0);
			this.textBoxComplianceWorktype.Name = "textBoxComplianceWorktype";
			this.textBoxComplianceWorktype.ReadOnly = true;
			this.textBoxComplianceWorktype.Size = new System.Drawing.Size(100, 25);
			this.textBoxComplianceWorktype.TabIndex = 0;
			// 
			// textBoxNextTSNCSN
			// 
			this.textBoxNextTSNCSN.BackColor = System.Drawing.Color.White;
			this.textBoxNextTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxNextTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNextTSNCSN.Location = new System.Drawing.Point(0, 0);
			this.textBoxNextTSNCSN.Name = "textBoxNextTSNCSN";
			this.textBoxNextTSNCSN.ReadOnly = true;
			this.textBoxNextTSNCSN.Size = new System.Drawing.Size(100, 25);
			this.textBoxNextTSNCSN.TabIndex = 0;
			// 
			// textBoxNextDate
			// 
			this.textBoxNextDate.BackColor = System.Drawing.Color.White;
			this.textBoxNextDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxNextDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNextDate.Location = new System.Drawing.Point(0, 0);
			this.textBoxNextDate.Name = "textBoxNextDate";
			this.textBoxNextDate.ReadOnly = true;
			this.textBoxNextDate.Size = new System.Drawing.Size(100, 25);
			this.textBoxNextDate.TabIndex = 0;
			// 
			// textBoxNextRemains
			// 
			this.textBoxNextRemains.BackColor = System.Drawing.Color.White;
			this.textBoxNextRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxNextRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNextRemains.Location = new System.Drawing.Point(0, 0);
			this.textBoxNextRemains.Name = "textBoxNextRemains";
			this.textBoxNextRemains.ReadOnly = true;
			this.textBoxNextRemains.Size = new System.Drawing.Size(100, 25);
			this.textBoxNextRemains.TabIndex = 0;
			// 
			// textBoxNextWorkType
			// 
			this.textBoxNextWorkType.BackColor = System.Drawing.Color.White;
			this.textBoxNextWorkType.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxNextWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNextWorkType.Location = new System.Drawing.Point(0, 0);
			this.textBoxNextWorkType.Name = "textBoxNextWorkType";
			this.textBoxNextWorkType.ReadOnly = true;
			this.textBoxNextWorkType.Size = new System.Drawing.Size(100, 25);
			this.textBoxNextWorkType.TabIndex = 0;
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDate.Location = new System.Drawing.Point(9, 288);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(132, 17);
			this.labelManufactureDate.TabIndex = 15;
			this.labelManufactureDate.Text = "Manufacture Date";
			this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerManufactureDate
			// 
			this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(145, 285);
			this.dateTimePickerManufactureDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
			this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(232, 25);
			this.dateTimePickerManufactureDate.TabIndex = 16;
			this.dateTimePickerManufactureDate.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// labelPN
			// 
			this.labelPN.AutoSize = true;
			this.labelPN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPN.Location = new System.Drawing.Point(9, 206);
			this.labelPN.Name = "labelPN";
			this.labelPN.Size = new System.Drawing.Size(96, 17);
			this.labelPN.TabIndex = 17;
			this.labelPN.Text = "Part Number";
			this.labelPN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPartialNumber
			// 
			this.textBoxPartialNumber.BackColor = System.Drawing.Color.White;
			this.textBoxPartialNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPartialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartialNumber.Location = new System.Drawing.Point(145, 203);
			this.textBoxPartialNumber.Name = "textBoxPartialNumber";
			this.textBoxPartialNumber.Size = new System.Drawing.Size(232, 25);
			this.textBoxPartialNumber.TabIndex = 18;
			// 
			// linkViewInfo
			// 
			this.linkViewInfo.AutoSize = true;
			this.linkViewInfo.Displayer = null;
			this.linkViewInfo.DisplayerText = null;
			this.linkViewInfo.Entity = null;
			this.linkViewInfo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkViewInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkViewInfo.Location = new System.Drawing.Point(9, 9);
			this.linkViewInfo.Name = "linkViewInfo";
			this.linkViewInfo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.linkViewInfo.Size = new System.Drawing.Size(73, 17);
			this.linkViewInfo.TabIndex = 11;
			this.linkViewInfo.TabStop = true;
			this.linkViewInfo.Text = "View Info";
			this.linkViewInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.delimiter1.Location = new System.Drawing.Point(392, 0);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = SmartControls.General.DelimiterOrientation.Vertical;
			this.delimiter1.Size = new System.Drawing.Size(1, 772);
			this.delimiter1.Style = SmartControls.General.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 32;
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = null;
			this.ButtonDelete.Location = new System.Drawing.Point(305, 744);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(72, 23);
			this.ButtonDelete.TabIndex = 33;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "delete";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = null;
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.ButtonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// BaseDetailEditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(groupBox4);
			this.Controls.Add(groupBox3);
			this.Controls.Add(groupBox2);
			this.Controls.Add(groupBox1);
			this.Controls.Add(this.labelPN);
			this.Controls.Add(this.textBoxPartialNumber);
			this.Controls.Add(this.labelManufactureDate);
			this.Controls.Add(this.dateTimePickerManufactureDate);
			this.Controls.Add(this.labelCaption);
			this.Controls.Add(this.labelEngineModel);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.labelSerialNumber);
			this.Controls.Add(this.labelTSNCSN);
			this.Controls.Add(this.comboBoxEngineModel);
			this.Controls.Add(this.textBoxManufacturer);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.textBoxSerialNumber);
			this.Controls.Add(this.textBoxTSNCSN);
			this.Controls.Add(this.linkViewInfo);
			this.Name = "BaseComponentEditorControl";
			this.Size = new System.Drawing.Size(393, 772);
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private Label labelCaption = new Label();
		private Label labelEngineModel = new Label();
		private Label labelManufacturer = new Label();
		private Label labelPosition = new Label();
		private Label labelSerialNumber = new Label();
		private Label labelTSNCSN = new Label();
		private Label labelCompliance = new Label();
		private Label labelComplianceTSNCSN = new Label();
		private Label labelComplianceDate = new Label();
		private Label labelComplianceWorkType = new Label();
		private Label labelNext = new Label();
		private Label labelNextTSNCSN = new Label();
		private Label labelNextDate = new Label();
		private Label labelNextRemains = new Label();
		private Label labelNextWorkType = new Label();
		private LookupCombobox comboBoxEngineModel = new LookupCombobox();
		private TextBox textBoxManufacturer = new TextBox();
		private TextBox textBoxPosition = new TextBox();
		private TextBox textBoxSerialNumber = new TextBox();
		private TextBox textBoxTSNCSN = new TextBox();
		private TextBox textBoxComplianceTSNCSN = new TextBox();
		private TextBox textBoxComplianceDate = new TextBox();
		private TextBox textBoxComplianceWorktype = new TextBox();
		private TextBox textBoxNextTSNCSN = new TextBox();
		private TextBox textBoxNextDate = new TextBox();
		private TextBox textBoxNextRemains = new TextBox();
		private TextBox textBoxNextWorkType = new TextBox();
		private ReferenceLinkLabel linkViewInfo = new ReferenceLinkLabel();

		#endregion
		private Label labelManufactureDate;
		private DateTimePicker dateTimePickerManufactureDate;
		private Label labelPN;
		private TextBox textBoxPartialNumber;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerStart;
		private DateTimePicker dateTimePickerStart;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerInstallation;
		private DateTimePicker dateTimePickerInstallation;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerLifeLimit;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerWarranty;
		private SmartControls.General.Delimiter delimiter1;
		private AvControls.AvButtonT.AvButtonT ButtonDelete;

	}
}
