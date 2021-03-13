using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceDirectiveInformationControl
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

			dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;
			lookupComboboxJobCard.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelATAChapter = new System.Windows.Forms.Label();
			this.labelTaskNumberCheck = new System.Windows.Forms.Label();
			this.labelEffectivityDate = new System.Windows.Forms.Label();
			this.labelApplicability = new System.Windows.Forms.Label();
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
			this.labelSubject = new System.Windows.Forms.Label();
			this.textboxDescription = new System.Windows.Forms.TextBox();
			this.textboxApplicability = new System.Windows.Forms.TextBox();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textboxTaskNumberCheck = new System.Windows.Forms.TextBox();
			this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
			this.textboxRemarks = new System.Windows.Forms.TextBox();
			this.textboxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.labelEngOrderNo = new System.Windows.Forms.Label();
			this.textBoxEngOrderNo = new System.Windows.Forms.TextBox();
			this.labelMPDTaskNumber = new System.Windows.Forms.Label();
			this.textBoxMpdTaskNumber = new System.Windows.Forms.TextBox();
			this.labelMaintManual = new System.Windows.Forms.Label();
			this.textBoxMaintenanceManual = new System.Windows.Forms.TextBox();
			this.labelAccess = new System.Windows.Forms.Label();
			this.textBoxAccess = new System.Windows.Forms.TextBox();
			this.labelZone = new System.Windows.Forms.Label();
			this.textBoxZone = new System.Windows.Forms.TextBox();
			this.labelTaskCardNumber = new System.Windows.Forms.Label();
			this.textBoxTaskCardNumber = new System.Windows.Forms.TextBox();
			this.labelMRB = new System.Windows.Forms.Label();
			this.textBoxMRB = new System.Windows.Forms.TextBox();
			this.labelCriticalSystem = new System.Windows.Forms.Label();
			this.labelProgram = new System.Windows.Forms.Label();
			this.comboBoxProgram = new System.Windows.Forms.ComboBox();
			this.comboBoxCriticalSystem = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxMpdRef = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxMpdRevNum = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dateTimePickerRevDate = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxOldTaslCard = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxWorkArea = new System.Windows.Forms.TextBox();
			this.comboBoxCategory = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dateTimePickerScheuleDate = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxScheuleRev = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBoxScheuleRef = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxScheduleItem = new System.Windows.Forms.TextBox();
			this.checkBoxIsApplicability = new System.Windows.Forms.CheckBox();
			this.checkBoxOperatorTask = new System.Windows.Forms.CheckBox();
			this.label12 = new System.Windows.Forms.Label();
			this.lookupComboboxJobCard = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.FileControlMRB = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlMaintenanceManual = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlTaskCardNumber = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlEO = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlTaskNumberCheck = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.ataChapterComboBox = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.comboBoxProgramIndicator = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.labelRVSM = new System.Windows.Forms.Label();
			this.checkBoxRVSM = new System.Windows.Forms.CheckBox();
			this.labelETOPS = new System.Windows.Forms.Label();
			this.checkBoxETOPS = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// labelATAChapter
			// 
			this.labelATAChapter.AutoSize = true;
			this.labelATAChapter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelATAChapter.Location = new System.Drawing.Point(10, 10);
			this.labelATAChapter.Name = "labelATAChapter";
			this.labelATAChapter.Size = new System.Drawing.Size(88, 14);
			this.labelATAChapter.TabIndex = 0;
			this.labelATAChapter.Text = "ATA Chapter:";
			// 
			// labelTaskNumberCheck
			// 
			this.labelTaskNumberCheck.AutoSize = true;
			this.labelTaskNumberCheck.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTaskNumberCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTaskNumberCheck.Location = new System.Drawing.Point(10, 178);
			this.labelTaskNumberCheck.Name = "labelTaskNumberCheck";
			this.labelTaskNumberCheck.Size = new System.Drawing.Size(72, 14);
			this.labelTaskNumberCheck.TabIndex = 0;
			this.labelTaskNumberCheck.Text = "MPD Item:";
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.AutoSize = true;
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(510, 10);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(99, 14);
			this.labelEffectivityDate.TabIndex = 0;
			this.labelEffectivityDate.Text = "Effective Date:";
			// 
			// labelApplicability
			// 
			this.labelApplicability.AutoSize = true;
			this.labelApplicability.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelApplicability.Location = new System.Drawing.Point(10, 811);
			this.labelApplicability.Name = "labelApplicability";
			this.labelApplicability.Size = new System.Drawing.Size(85, 14);
			this.labelApplicability.TabIndex = 0;
			this.labelApplicability.Text = "Applicability:";
			// 
			// labelBiWeeklyReport
			// 
			this.labelBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
			this.labelBiWeeklyReport.Name = "labelBiWeeklyReport";
			this.labelBiWeeklyReport.Size = new System.Drawing.Size(150, 25);
			this.labelBiWeeklyReport.TabIndex = 0;
			this.labelBiWeeklyReport.Text = "BiWeekly Report";
			// 
			// labelSubject
			// 
			this.labelSubject.AutoSize = true;
			this.labelSubject.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSubject.Location = new System.Drawing.Point(10, 714);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(82, 14);
			this.labelSubject.TabIndex = 0;
			this.labelSubject.Text = "Description:";
			// 
			// textboxDescription
			// 
			this.textboxDescription.BackColor = System.Drawing.Color.White;
			this.textboxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxDescription.Location = new System.Drawing.Point(115, 711);
			this.textboxDescription.MaxLength = 3000;
			this.textboxDescription.Multiline = true;
			this.textboxDescription.Name = "textboxDescription";
			this.textboxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxDescription.Size = new System.Drawing.Size(350, 88);
			this.textboxDescription.TabIndex = 18;
			// 
			// textboxApplicability
			// 
			this.textboxApplicability.BackColor = System.Drawing.Color.White;
			this.textboxApplicability.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxApplicability.Location = new System.Drawing.Point(115, 805);
			this.textboxApplicability.MaxLength = 1000;
			this.textboxApplicability.Multiline = true;
			this.textboxApplicability.Name = "textboxApplicability";
			this.textboxApplicability.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxApplicability.Size = new System.Drawing.Size(350, 88);
			this.textboxApplicability.TabIndex = 19;
			// 
			// dateTimePickerEffDate
			// 
			this.dateTimePickerEffDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerEffDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(655, 10);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 22);
			this.dateTimePickerEffDate.TabIndex = 2;
			this.dateTimePickerEffDate.ValueChanged += new System.EventHandler(this.DateTimePickerEffDateValueChanged);
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(525, 714);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(66, 14);
			this.labelRemarks.TabIndex = 0;
			this.labelRemarks.Text = "Remarks:";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.AutoSize = true;
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(525, 811);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(114, 14);
			this.labelHiddenRemarks.TabIndex = 0;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
			// 
			// textboxTaskNumberCheck
			// 
			this.textboxTaskNumberCheck.BackColor = System.Drawing.Color.White;
			this.textboxTaskNumberCheck.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxTaskNumberCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxTaskNumberCheck.Location = new System.Drawing.Point(115, 175);
			this.textboxTaskNumberCheck.MaxLength = 50;
			this.textboxTaskNumberCheck.Name = "textboxTaskNumberCheck";
			this.textboxTaskNumberCheck.Size = new System.Drawing.Size(350, 22);
			this.textboxTaskNumberCheck.TabIndex = 3;
			// 
			// textboxBiWeeklyReport
			// 
			this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
			this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
			this.textboxBiWeeklyReport.MaxLength = 1000;
			this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
			this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 22);
			this.textboxBiWeeklyReport.TabIndex = 9;
			// 
			// textboxRemarks
			// 
			this.textboxRemarks.BackColor = System.Drawing.Color.White;
			this.textboxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxRemarks.Location = new System.Drawing.Point(655, 711);
			this.textboxRemarks.MaxLength = 34000;
			this.textboxRemarks.Multiline = true;
			this.textboxRemarks.Name = "textboxRemarks";
			this.textboxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxRemarks.Size = new System.Drawing.Size(350, 88);
			this.textboxRemarks.TabIndex = 22;
			// 
			// textboxHiddenRemarks
			// 
			this.textboxHiddenRemarks.BackColor = System.Drawing.Color.White;
			this.textboxHiddenRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxHiddenRemarks.Location = new System.Drawing.Point(655, 808);
			this.textboxHiddenRemarks.MaxLength = 34000;
			this.textboxHiddenRemarks.Multiline = true;
			this.textboxHiddenRemarks.Name = "textboxHiddenRemarks";
			this.textboxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxHiddenRemarks.Size = new System.Drawing.Size(350, 88);
			this.textboxHiddenRemarks.TabIndex = 23;
			// 
			// labelEngOrderNo
			// 
			this.labelEngOrderNo.AutoSize = true;
			this.labelEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEngOrderNo.Location = new System.Drawing.Point(510, 178);
			this.labelEngOrderNo.Name = "labelEngOrderNo";
			this.labelEngOrderNo.Size = new System.Drawing.Size(109, 14);
			this.labelEngOrderNo.TabIndex = 11;
			this.labelEngOrderNo.Text = "Airline Job Card:";
			// 
			// textBoxEngOrderNo
			// 
			this.textBoxEngOrderNo.BackColor = System.Drawing.Color.White;
			this.textBoxEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxEngOrderNo.Location = new System.Drawing.Point(655, 175);
			this.textBoxEngOrderNo.MaxLength = 200;
			this.textBoxEngOrderNo.Name = "textBoxEngOrderNo";
			this.textBoxEngOrderNo.Size = new System.Drawing.Size(325, 22);
			this.textBoxEngOrderNo.TabIndex = 9;
			this.textBoxEngOrderNo.Visible = false;
			// 
			// labelMPDTaskNumber
			// 
			this.labelMPDTaskNumber.AutoSize = true;
			this.labelMPDTaskNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMPDTaskNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDTaskNumber.Location = new System.Drawing.Point(10, 574);
			this.labelMPDTaskNumber.Name = "labelMPDTaskNumber";
			this.labelMPDTaskNumber.Size = new System.Drawing.Size(60, 14);
			this.labelMPDTaskNumber.TabIndex = 14;
			this.labelMPDTaskNumber.Text = "Doc. No:";
			// 
			// textBoxMpdTaskNumber
			// 
			this.textBoxMpdTaskNumber.BackColor = System.Drawing.Color.White;
			this.textBoxMpdTaskNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMpdTaskNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMpdTaskNumber.Location = new System.Drawing.Point(115, 571);
			this.textBoxMpdTaskNumber.MaxLength = 200;
			this.textBoxMpdTaskNumber.Name = "textBoxMpdTaskNumber";
			this.textBoxMpdTaskNumber.Size = new System.Drawing.Size(350, 22);
			this.textBoxMpdTaskNumber.TabIndex = 15;
			// 
			// labelMaintManual
			// 
			this.labelMaintManual.AutoSize = true;
			this.labelMaintManual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMaintManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaintManual.Location = new System.Drawing.Point(10, 453);
			this.labelMaintManual.Name = "labelMaintManual";
			this.labelMaintManual.Size = new System.Drawing.Size(99, 14);
			this.labelMaintManual.TabIndex = 18;
			this.labelMaintManual.Text = "Maint. Manual:";
			// 
			// textBoxMaintenanceManual
			// 
			this.textBoxMaintenanceManual.BackColor = System.Drawing.Color.White;
			this.textBoxMaintenanceManual.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMaintenanceManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMaintenanceManual.Location = new System.Drawing.Point(115, 450);
			this.textBoxMaintenanceManual.MaxLength = 512;
			this.textBoxMaintenanceManual.Name = "textBoxMaintenanceManual";
			this.textBoxMaintenanceManual.Size = new System.Drawing.Size(350, 22);
			this.textBoxMaintenanceManual.TabIndex = 11;
			// 
			// labelAccess
			// 
			this.labelAccess.AutoSize = true;
			this.labelAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAccess.Location = new System.Drawing.Point(10, 658);
			this.labelAccess.Name = "labelAccess";
			this.labelAccess.Size = new System.Drawing.Size(54, 14);
			this.labelAccess.TabIndex = 20;
			this.labelAccess.Text = "Access:";
			// 
			// textBoxAccess
			// 
			this.textBoxAccess.BackColor = System.Drawing.Color.White;
			this.textBoxAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAccess.Location = new System.Drawing.Point(115, 655);
			this.textBoxAccess.MaxLength = 1000;
			this.textBoxAccess.Multiline = true;
			this.textBoxAccess.Name = "textBoxAccess";
			this.textBoxAccess.Size = new System.Drawing.Size(350, 51);
			this.textBoxAccess.TabIndex = 17;
			// 
			// labelZone
			// 
			this.labelZone.AutoSize = true;
			this.labelZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelZone.Location = new System.Drawing.Point(10, 630);
			this.labelZone.Name = "labelZone";
			this.labelZone.Size = new System.Drawing.Size(44, 14);
			this.labelZone.TabIndex = 22;
			this.labelZone.Text = "Zone:";
			// 
			// textBoxZone
			// 
			this.textBoxZone.BackColor = System.Drawing.Color.White;
			this.textBoxZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxZone.Location = new System.Drawing.Point(115, 627);
			this.textBoxZone.MaxLength = 200;
			this.textBoxZone.Name = "textBoxZone";
			this.textBoxZone.Size = new System.Drawing.Size(350, 22);
			this.textBoxZone.TabIndex = 16;
			// 
			// labelTaskCardNumber
			// 
			this.labelTaskCardNumber.AutoSize = true;
			this.labelTaskCardNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTaskCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTaskCardNumber.Location = new System.Drawing.Point(510, 318);
			this.labelTaskCardNumber.Name = "labelTaskCardNumber";
			this.labelTaskCardNumber.Size = new System.Drawing.Size(95, 14);
			this.labelTaskCardNumber.TabIndex = 25;
			this.labelTaskCardNumber.Text = "Task Card No:";
			// 
			// textBoxTaskCardNumber
			// 
			this.textBoxTaskCardNumber.BackColor = System.Drawing.Color.White;
			this.textBoxTaskCardNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxTaskCardNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTaskCardNumber.Location = new System.Drawing.Point(655, 315);
			this.textBoxTaskCardNumber.MaxLength = 200;
			this.textBoxTaskCardNumber.Name = "textBoxTaskCardNumber";
			this.textBoxTaskCardNumber.Size = new System.Drawing.Size(350, 22);
			this.textBoxTaskCardNumber.TabIndex = 13;
			// 
			// labelMRB
			// 
			this.labelMRB.AutoSize = true;
			this.labelMRB.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMRB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMRB.Location = new System.Drawing.Point(10, 313);
			this.labelMRB.Name = "labelMRB";
			this.labelMRB.Size = new System.Drawing.Size(71, 14);
			this.labelMRB.TabIndex = 28;
			this.labelMRB.Text = "MRB Item:";
			// 
			// textBoxMRB
			// 
			this.textBoxMRB.BackColor = System.Drawing.Color.White;
			this.textBoxMRB.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMRB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMRB.Location = new System.Drawing.Point(115, 310);
			this.textBoxMRB.MaxLength = 200;
			this.textBoxMRB.Name = "textBoxMRB";
			this.textBoxMRB.Size = new System.Drawing.Size(350, 22);
			this.textBoxMRB.TabIndex = 7;
			// 
			// labelCriticalSystem
			// 
			this.labelCriticalSystem.AutoSize = true;
			this.labelCriticalSystem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCriticalSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCriticalSystem.Location = new System.Drawing.Point(525, 627);
			this.labelCriticalSystem.Name = "labelCriticalSystem";
			this.labelCriticalSystem.Size = new System.Drawing.Size(104, 14);
			this.labelCriticalSystem.TabIndex = 35;
			this.labelCriticalSystem.Text = "Critical System:";
			// 
			// labelProgram
			// 
			this.labelProgram.AutoSize = true;
			this.labelProgram.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProgram.Location = new System.Drawing.Point(525, 602);
			this.labelProgram.Name = "labelProgram";
			this.labelProgram.Size = new System.Drawing.Size(65, 14);
			this.labelProgram.TabIndex = 33;
			this.labelProgram.Text = "Program:";
			// 
			// comboBoxProgram
			// 
			this.comboBoxProgram.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxProgram.FormattingEnabled = true;
			this.comboBoxProgram.Location = new System.Drawing.Point(655, 599);
			this.comboBoxProgram.Name = "comboBoxProgram";
			this.comboBoxProgram.Size = new System.Drawing.Size(350, 22);
			this.comboBoxProgram.TabIndex = 20;
			// 
			// comboBoxCriticalSystem
			// 
			this.comboBoxCriticalSystem.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxCriticalSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCriticalSystem.FormattingEnabled = true;
			this.comboBoxCriticalSystem.Location = new System.Drawing.Point(655, 624);
			this.comboBoxCriticalSystem.Name = "comboBoxCriticalSystem";
			this.comboBoxCriticalSystem.Size = new System.Drawing.Size(350, 22);
			this.comboBoxCriticalSystem.TabIndex = 21;
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(655, 680);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(350, 22);
			this.comboBox1.TabIndex = 36;
			this.comboBox1.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(525, 683);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 14);
			this.label1.TabIndex = 37;
			this.label1.Text = "Critical System:";
			this.label1.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(10, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 39;
			this.label2.Text = "MPD Ref:";
			// 
			// textBoxMpdRef
			// 
			this.textBoxMpdRef.BackColor = System.Drawing.Color.White;
			this.textBoxMpdRef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMpdRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMpdRef.Location = new System.Drawing.Point(115, 41);
			this.textBoxMpdRef.MaxLength = 50;
			this.textBoxMpdRef.Name = "textBoxMpdRef";
			this.textBoxMpdRef.Size = new System.Drawing.Size(350, 22);
			this.textBoxMpdRef.TabIndex = 40;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(10, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 14);
			this.label3.TabIndex = 41;
			this.label3.Text = "MPD Revision:";
			// 
			// textBoxMpdRevNum
			// 
			this.textBoxMpdRevNum.BackColor = System.Drawing.Color.White;
			this.textBoxMpdRevNum.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxMpdRevNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMpdRevNum.Location = new System.Drawing.Point(115, 69);
			this.textBoxMpdRevNum.MaxLength = 50;
			this.textBoxMpdRevNum.Name = "textBoxMpdRevNum";
			this.textBoxMpdRevNum.Size = new System.Drawing.Size(81, 22);
			this.textBoxMpdRevNum.TabIndex = 42;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(202, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 14);
			this.label4.TabIndex = 43;
			this.label4.Text = "Date:";
			// 
			// dateTimePickerRevDate
			// 
			this.dateTimePickerRevDate.Location = new System.Drawing.Point(250, 69);
			this.dateTimePickerRevDate.Name = "dateTimePickerRevDate";
			this.dateTimePickerRevDate.Size = new System.Drawing.Size(215, 20);
			this.dateTimePickerRevDate.TabIndex = 44;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(525, 453);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(122, 14);
			this.label5.TabIndex = 45;
			this.label5.Text = "Old Task Card NO:";
			// 
			// textBoxOldTaslCard
			// 
			this.textBoxOldTaslCard.BackColor = System.Drawing.Color.White;
			this.textBoxOldTaslCard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxOldTaslCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxOldTaslCard.Location = new System.Drawing.Point(655, 450);
			this.textBoxOldTaslCard.MaxLength = 50;
			this.textBoxOldTaslCard.Name = "textBoxOldTaslCard";
			this.textBoxOldTaslCard.Size = new System.Drawing.Size(350, 22);
			this.textBoxOldTaslCard.TabIndex = 46;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(10, 602);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 14);
			this.label6.TabIndex = 48;
			this.label6.Text = "Work area:";
			// 
			// textBoxWorkArea
			// 
			this.textBoxWorkArea.BackColor = System.Drawing.Color.White;
			this.textBoxWorkArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxWorkArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxWorkArea.Location = new System.Drawing.Point(115, 599);
			this.textBoxWorkArea.MaxLength = 200;
			this.textBoxWorkArea.Name = "textBoxWorkArea";
			this.textBoxWorkArea.Size = new System.Drawing.Size(350, 22);
			this.textBoxWorkArea.TabIndex = 47;
			// 
			// comboBoxCategory
			// 
			this.comboBoxCategory.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxCategory.FormattingEnabled = true;
			this.comboBoxCategory.Location = new System.Drawing.Point(655, 652);
			this.comboBoxCategory.Name = "comboBoxCategory";
			this.comboBoxCategory.Size = new System.Drawing.Size(350, 22);
			this.comboBoxCategory.TabIndex = 49;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label7.Location = new System.Drawing.Point(525, 655);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(70, 14);
			this.label7.TabIndex = 50;
			this.label7.Text = "Category:";
			// 
			// dateTimePickerScheuleDate
			// 
			this.dateTimePickerScheuleDate.Location = new System.Drawing.Point(790, 69);
			this.dateTimePickerScheuleDate.Name = "dateTimePickerScheuleDate";
			this.dateTimePickerScheuleDate.Size = new System.Drawing.Size(215, 20);
			this.dateTimePickerScheuleDate.TabIndex = 56;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label8.Location = new System.Drawing.Point(742, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 14);
			this.label8.TabIndex = 55;
			this.label8.Text = "Date:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label9.Location = new System.Drawing.Point(510, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(99, 14);
			this.label9.TabIndex = 53;
			this.label9.Text = "Schedule Rev.:";
			// 
			// textBoxScheuleRev
			// 
			this.textBoxScheuleRev.BackColor = System.Drawing.Color.White;
			this.textBoxScheuleRev.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxScheuleRev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxScheuleRev.Location = new System.Drawing.Point(655, 69);
			this.textBoxScheuleRev.MaxLength = 50;
			this.textBoxScheuleRev.Name = "textBoxScheuleRev";
			this.textBoxScheuleRev.Size = new System.Drawing.Size(81, 22);
			this.textBoxScheuleRev.TabIndex = 54;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label10.Location = new System.Drawing.Point(510, 44);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(93, 14);
			this.label10.TabIndex = 51;
			this.label10.Text = "Schedule Ref:";
			// 
			// textBoxScheuleRef
			// 
			this.textBoxScheuleRef.BackColor = System.Drawing.Color.White;
			this.textBoxScheuleRef.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxScheuleRef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxScheuleRef.Location = new System.Drawing.Point(655, 41);
			this.textBoxScheuleRef.MaxLength = 50;
			this.textBoxScheuleRef.Name = "textBoxScheuleRef";
			this.textBoxScheuleRef.Size = new System.Drawing.Size(350, 22);
			this.textBoxScheuleRef.TabIndex = 52;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label11.Location = new System.Drawing.Point(510, 98);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(102, 14);
			this.label11.TabIndex = 57;
			this.label11.Text = "Schedule Item:";
			// 
			// textBoxScheduleItem
			// 
			this.textBoxScheduleItem.BackColor = System.Drawing.Color.White;
			this.textBoxScheduleItem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxScheduleItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxScheduleItem.Location = new System.Drawing.Point(655, 95);
			this.textBoxScheduleItem.MaxLength = 50;
			this.textBoxScheduleItem.Name = "textBoxScheduleItem";
			this.textBoxScheduleItem.Size = new System.Drawing.Size(350, 22);
			this.textBoxScheduleItem.TabIndex = 58;
			// 
			// checkBoxIsApplicability
			// 
			this.checkBoxIsApplicability.AutoSize = true;
			this.checkBoxIsApplicability.Location = new System.Drawing.Point(72, 828);
			this.checkBoxIsApplicability.Name = "checkBoxIsApplicability";
			this.checkBoxIsApplicability.Size = new System.Drawing.Size(15, 14);
			this.checkBoxIsApplicability.TabIndex = 59;
			this.checkBoxIsApplicability.UseVisualStyleBackColor = true;
			this.checkBoxIsApplicability.CheckedChanged += new System.EventHandler(this.checkBoxIsApplicability_CheckedChanged);
			// 
			// checkBoxOperatorTask
			// 
			this.checkBoxOperatorTask.AutoSize = true;
			this.checkBoxOperatorTask.Location = new System.Drawing.Point(655, 154);
			this.checkBoxOperatorTask.Name = "checkBoxOperatorTask";
			this.checkBoxOperatorTask.Size = new System.Drawing.Size(15, 14);
			this.checkBoxOperatorTask.TabIndex = 60;
			this.checkBoxOperatorTask.UseVisualStyleBackColor = true;
			this.checkBoxOperatorTask.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label12.Location = new System.Drawing.Point(517, 154);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(101, 14);
			this.label12.TabIndex = 61;
			this.label12.Text = "Operator Task:";
			// 
			// lookupComboboxJobCard
			// 
			this.lookupComboboxJobCard.Displayer = null;
			this.lookupComboboxJobCard.DisplayerText = null;
			this.lookupComboboxJobCard.Enabled = false;
			this.lookupComboboxJobCard.Entity = null;
			this.lookupComboboxJobCard.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxJobCard.Location = new System.Drawing.Point(655, 175);
			this.lookupComboboxJobCard.Margin = new System.Windows.Forms.Padding(4);
			this.lookupComboboxJobCard.Name = "lookupComboboxJobCard";
			this.lookupComboboxJobCard.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxJobCard.Size = new System.Drawing.Size(350, 22);
			this.lookupComboboxJobCard.TabIndex = 38;
			this.lookupComboboxJobCard.Type = null;
			// 
			// FileControlMRB
			// 
			this.FileControlMRB.AutoSize = true;
			this.FileControlMRB.Description1 = "";
			this.FileControlMRB.Description2 = "";
			this.FileControlMRB.Filter = null;
			this.FileControlMRB.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.FileControlMRB.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.FileControlMRB.Location = new System.Drawing.Point(115, 338);
			this.FileControlMRB.Margin = new System.Windows.Forms.Padding(4);
			this.FileControlMRB.MaximumSize = new System.Drawing.Size(350, 100);
			this.FileControlMRB.Name = "FileControlMRB";
			this.FileControlMRB.ShowLinkLabelBrowse = true;
			this.FileControlMRB.ShowLinkLabelRemove = false;
			this.FileControlMRB.Size = new System.Drawing.Size(350, 37);
			this.FileControlMRB.TabIndex = 8;
			// 
			// fileControlMaintenanceManual
			// 
			this.fileControlMaintenanceManual.AutoSize = true;
			this.fileControlMaintenanceManual.Description1 = "";
			this.fileControlMaintenanceManual.Description2 = "";
			this.fileControlMaintenanceManual.Filter = null;
			this.fileControlMaintenanceManual.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlMaintenanceManual.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlMaintenanceManual.Location = new System.Drawing.Point(115, 478);
			this.fileControlMaintenanceManual.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlMaintenanceManual.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlMaintenanceManual.Name = "fileControlMaintenanceManual";
			this.fileControlMaintenanceManual.ShowLinkLabelBrowse = true;
			this.fileControlMaintenanceManual.ShowLinkLabelRemove = false;
			this.fileControlMaintenanceManual.Size = new System.Drawing.Size(350, 37);
			this.fileControlMaintenanceManual.TabIndex = 12;
			// 
			// fileControlTaskCardNumber
			// 
			this.fileControlTaskCardNumber.AutoSize = true;
			this.fileControlTaskCardNumber.Description1 = "";
			this.fileControlTaskCardNumber.Description2 = "";
			this.fileControlTaskCardNumber.Filter = null;
			this.fileControlTaskCardNumber.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlTaskCardNumber.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlTaskCardNumber.Location = new System.Drawing.Point(655, 343);
			this.fileControlTaskCardNumber.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlTaskCardNumber.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlTaskCardNumber.Name = "fileControlTaskCardNumber";
			this.fileControlTaskCardNumber.ShowLinkLabelBrowse = true;
			this.fileControlTaskCardNumber.ShowLinkLabelRemove = false;
			this.fileControlTaskCardNumber.Size = new System.Drawing.Size(350, 37);
			this.fileControlTaskCardNumber.TabIndex = 14;
			// 
			// fileControlEO
			// 
			this.fileControlEO.AutoSize = true;
			this.fileControlEO.Description1 = "";
			this.fileControlEO.Description2 = "";
			this.fileControlEO.Enabled = false;
			this.fileControlEO.Filter = null;
			this.fileControlEO.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlEO.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlEO.Location = new System.Drawing.Point(655, 203);
			this.fileControlEO.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlEO.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlEO.Name = "fileControlEO";
			this.fileControlEO.ShowLinkLabelBrowse = true;
			this.fileControlEO.ShowLinkLabelRemove = false;
			this.fileControlEO.Size = new System.Drawing.Size(350, 37);
			this.fileControlEO.TabIndex = 10;
			this.fileControlEO.Visible = false;
			// 
			// fileControlTaskNumberCheck
			// 
			this.fileControlTaskNumberCheck.AutoSize = true;
			this.fileControlTaskNumberCheck.Description1 = "";
			this.fileControlTaskNumberCheck.Description2 = "";
			this.fileControlTaskNumberCheck.Filter = null;
			this.fileControlTaskNumberCheck.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlTaskNumberCheck.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlTaskNumberCheck.Location = new System.Drawing.Point(115, 203);
			this.fileControlTaskNumberCheck.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlTaskNumberCheck.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlTaskNumberCheck.Name = "fileControlTaskNumberCheck";
			this.fileControlTaskNumberCheck.ShowLinkLabelBrowse = true;
			this.fileControlTaskNumberCheck.ShowLinkLabelRemove = false;
			this.fileControlTaskNumberCheck.Size = new System.Drawing.Size(350, 37);
			this.fileControlTaskNumberCheck.TabIndex = 4;
			// 
			// ataChapterComboBox
			// 
			this.ataChapterComboBox.BackColor = System.Drawing.Color.White;
			this.ataChapterComboBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ataChapterComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.ataChapterComboBox.FormattingEnabled = true;
			this.ataChapterComboBox.Location = new System.Drawing.Point(115, 10);
			this.ataChapterComboBox.Name = "ataChapterComboBox";
			this.ataChapterComboBox.Size = new System.Drawing.Size(350, 22);
			this.ataChapterComboBox.TabIndex = 1;
			// 
			// comboBoxProgramIndicator
			// 
			this.comboBoxProgramIndicator.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxProgramIndicator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxProgramIndicator.FormattingEnabled = true;
			this.comboBoxProgramIndicator.Location = new System.Drawing.Point(655, 571);
			this.comboBoxProgramIndicator.Name = "comboBoxProgramIndicator";
			this.comboBoxProgramIndicator.Size = new System.Drawing.Size(350, 22);
			this.comboBoxProgramIndicator.TabIndex = 62;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label13.Location = new System.Drawing.Point(525, 574);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(125, 14);
			this.label13.TabIndex = 63;
			this.label13.Text = "Program Indicator:";
			// 
			// labelRVSM
			// 
			this.labelRVSM.AutoSize = true;
			this.labelRVSM.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRVSM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRVSM.Location = new System.Drawing.Point(713, 154);
			this.labelRVSM.Name = "labelRVSM";
			this.labelRVSM.Size = new System.Drawing.Size(46, 14);
			this.labelRVSM.TabIndex = 65;
			this.labelRVSM.Text = "RVSM:";
			// 
			// checkBoxRVSM
			// 
			this.checkBoxRVSM.AutoSize = true;
			this.checkBoxRVSM.Location = new System.Drawing.Point(765, 154);
			this.checkBoxRVSM.Name = "checkBoxRVSM";
			this.checkBoxRVSM.Size = new System.Drawing.Size(15, 14);
			this.checkBoxRVSM.TabIndex = 64;
			this.checkBoxRVSM.UseVisualStyleBackColor = true;
			// 
			// labelETOPS
			// 
			this.labelETOPS.AutoSize = true;
			this.labelETOPS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelETOPS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelETOPS.Location = new System.Drawing.Point(822, 154);
			this.labelETOPS.Name = "labelETOPS";
			this.labelETOPS.Size = new System.Drawing.Size(53, 14);
			this.labelETOPS.TabIndex = 67;
			this.labelETOPS.Text = "ETOPS:";
			// 
			// checkBoxETOPS
			// 
			this.checkBoxETOPS.AutoSize = true;
			this.checkBoxETOPS.Location = new System.Drawing.Point(881, 154);
			this.checkBoxETOPS.Name = "checkBoxETOPS";
			this.checkBoxETOPS.Size = new System.Drawing.Size(15, 14);
			this.checkBoxETOPS.TabIndex = 66;
			this.checkBoxETOPS.UseVisualStyleBackColor = true;
			// 
			// MaintenanceDirectiveInformationControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.labelETOPS);
			this.Controls.Add(this.checkBoxETOPS);
			this.Controls.Add(this.labelRVSM);
			this.Controls.Add(this.checkBoxRVSM);
			this.Controls.Add(this.comboBoxProgramIndicator);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.checkBoxOperatorTask);
			this.Controls.Add(this.checkBoxIsApplicability);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBoxScheduleItem);
			this.Controls.Add(this.dateTimePickerScheuleDate);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxScheuleRev);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxScheuleRef);
			this.Controls.Add(this.comboBoxCategory);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxWorkArea);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBoxOldTaslCard);
			this.Controls.Add(this.dateTimePickerRevDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxMpdRevNum);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxMpdRef);
			this.Controls.Add(this.lookupComboboxJobCard);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxCriticalSystem);
			this.Controls.Add(this.comboBoxProgram);
			this.Controls.Add(this.labelCriticalSystem);
			this.Controls.Add(this.labelProgram);
			this.Controls.Add(this.FileControlMRB);
			this.Controls.Add(this.labelMRB);
			this.Controls.Add(this.textBoxMRB);
			this.Controls.Add(this.fileControlMaintenanceManual);
			this.Controls.Add(this.fileControlTaskCardNumber);
			this.Controls.Add(this.labelTaskCardNumber);
			this.Controls.Add(this.textBoxTaskCardNumber);
			this.Controls.Add(this.fileControlEO);
			this.Controls.Add(this.fileControlTaskNumberCheck);
			this.Controls.Add(this.labelZone);
			this.Controls.Add(this.textBoxZone);
			this.Controls.Add(this.labelAccess);
			this.Controls.Add(this.textBoxAccess);
			this.Controls.Add(this.labelMaintManual);
			this.Controls.Add(this.textBoxMaintenanceManual);
			this.Controls.Add(this.labelMPDTaskNumber);
			this.Controls.Add(this.textBoxMpdTaskNumber);
			this.Controls.Add(this.labelEngOrderNo);
			this.Controls.Add(this.textBoxEngOrderNo);
			this.Controls.Add(this.ataChapterComboBox);
			this.Controls.Add(this.textboxDescription);
			this.Controls.Add(this.labelATAChapter);
			this.Controls.Add(this.labelTaskNumberCheck);
			this.Controls.Add(this.textboxTaskNumberCheck);
			this.Controls.Add(this.labelEffectivityDate);
			this.Controls.Add(this.dateTimePickerEffDate);
			this.Controls.Add(this.labelApplicability);
			this.Controls.Add(this.textboxApplicability);
			this.Controls.Add(this.labelSubject);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textboxRemarks);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.textboxHiddenRemarks);
			this.Name = "MaintenanceDirectiveInformationControl";
			this.Size = new System.Drawing.Size(1012, 899);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelATAChapter;
		private Label labelTaskNumberCheck;
		private Label labelEffectivityDate;
		private Label labelApplicability;
		private Label labelBiWeeklyReport;
		private Label labelSubject;
		private Label labelRemarks;
		private Label labelHiddenRemarks;
		private TextBox textboxTaskNumberCheck;
		private DateTimePicker dateTimePickerEffDate;
		private TextBox textboxApplicability;
		private TextBox textboxBiWeeklyReport;
		private TextBox textboxDescription;
		private TextBox textboxRemarks;
		private TextBox textboxHiddenRemarks;
		private Label labelEngOrderNo;
		private TextBox textBoxEngOrderNo;
		private ATAChapterComboBox ataChapterComboBox;
		private Label labelMPDTaskNumber;
		private TextBox textBoxMpdTaskNumber;
		private Label labelMaintManual;
		private TextBox textBoxMaintenanceManual;
		private Label labelAccess;
		private TextBox textBoxAccess;
		private Label labelZone;
		private TextBox textBoxZone;
		private AttachedFileControl fileControlTaskNumberCheck;
		private AttachedFileControl fileControlEO;
		private AttachedFileControl fileControlTaskCardNumber;
		private Label labelTaskCardNumber;
		private TextBox textBoxTaskCardNumber;
		private AttachedFileControl fileControlMaintenanceManual;
		private AttachedFileControl FileControlMRB;
		private Label labelMRB;
		private TextBox textBoxMRB;
		private Label labelCriticalSystem;
		private Label labelProgram;
		private ComboBox comboBoxProgram;
		private ComboBox comboBoxCriticalSystem;
		private ComboBox comboBox1;
		private Label label1;
		private LookupCombobox lookupComboboxJobCard;
		private Label label2;
		private TextBox textBoxMpdRef;
		private Label label3;
		private TextBox textBoxMpdRevNum;
		private Label label4;
		private DateTimePicker dateTimePickerRevDate;
		private Label label5;
		private TextBox textBoxOldTaslCard;
		private Label label6;
		private TextBox textBoxWorkArea;
		private ComboBox comboBoxCategory;
		private Label label7;
		private DateTimePicker dateTimePickerScheuleDate;
		private Label label8;
		private Label label9;
		private TextBox textBoxScheuleRev;
		private Label label10;
		private TextBox textBoxScheuleRef;
		private Label label11;
		private TextBox textBoxScheduleItem;
		private CheckBox checkBoxIsApplicability;
		private CheckBox checkBoxOperatorTask;
		private Label label12;
		private ComboBox comboBoxProgramIndicator;
		private Label label13;
		private Label labelRVSM;
		private CheckBox checkBoxRVSM;
		private Label labelETOPS;
		private CheckBox checkBoxETOPS;
	}
}
