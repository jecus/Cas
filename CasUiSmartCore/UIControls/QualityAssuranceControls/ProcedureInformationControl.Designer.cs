using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
	partial class ProcedureInformationControl
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
			lookupComboboxCheckList.SelectedIndexChanged -= LookupComboboxMaintenanceCheckSelectedIndexChanged;

			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelEffectivityDate = new System.Windows.Forms.Label();
			this.labelApplicability = new System.Windows.Forms.Label();
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
			this.labelSubject = new System.Windows.Forms.Label();
			this.textboxDescription = new System.Windows.Forms.TextBox();
			this.textboxApplicability = new System.Windows.Forms.TextBox();
			this.dateTimePickerEffDate = new System.Windows.Forms.DateTimePicker();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textboxTitle = new System.Windows.Forms.TextBox();
			this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
			this.textboxRemarks = new System.Windows.Forms.TextBox();
			this.textboxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.labelCheckList = new System.Windows.Forms.Label();
			this.textBoxEngOrderNo = new System.Windows.Forms.TextBox();
			this.labelDepartment = new System.Windows.Forms.Label();
			this.textBoxDepartment = new System.Windows.Forms.TextBox();
			this.lookupComboboxCheckList = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.fileControlCheckList = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlProcedure = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.procedureDocRefListControl = new CAS.UI.UIControls.QualityAssuranceControls.ProcedureDocRefListControl();
			this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
			this.labelLevel = new System.Windows.Forms.Label();
			this.labelRating = new System.Windows.Forms.Label();
			this.comboBoxRating = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTitle.Location = new System.Drawing.Point(10, 13);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(45, 18);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "Title:";
			// 
			// labelEffectivityDate
			// 
			this.labelEffectivityDate.AutoSize = true;
			this.labelEffectivityDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEffectivityDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEffectivityDate.Location = new System.Drawing.Point(510, 13);
			this.labelEffectivityDate.Name = "labelEffectivityDate";
			this.labelEffectivityDate.Size = new System.Drawing.Size(118, 18);
			this.labelEffectivityDate.TabIndex = 0;
			this.labelEffectivityDate.Text = "Effective Date:";
			// 
			// labelApplicability
			// 
			this.labelApplicability.AutoSize = true;
			this.labelApplicability.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelApplicability.Location = new System.Drawing.Point(10, 376);
			this.labelApplicability.Name = "labelApplicability";
			this.labelApplicability.Size = new System.Drawing.Size(99, 18);
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
			this.labelSubject.Location = new System.Drawing.Point(10, 279);
			this.labelSubject.Name = "labelSubject";
			this.labelSubject.Size = new System.Drawing.Size(97, 18);
			this.labelSubject.TabIndex = 0;
			this.labelSubject.Text = "Description:";
			// 
			// textboxDescription
			// 
			this.textboxDescription.BackColor = System.Drawing.Color.White;
			this.textboxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxDescription.Location = new System.Drawing.Point(115, 276);
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
			this.textboxApplicability.Location = new System.Drawing.Point(115, 370);
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
			this.dateTimePickerEffDate.Location = new System.Drawing.Point(630, 10);
			this.dateTimePickerEffDate.Name = "dateTimePickerEffDate";
			this.dateTimePickerEffDate.Size = new System.Drawing.Size(350, 26);
			this.dateTimePickerEffDate.TabIndex = 2;
			this.dateTimePickerEffDate.ValueChanged += new System.EventHandler(this.DateTimePickerEffDateValueChanged);
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(510, 279);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(81, 18);
			this.labelRemarks.TabIndex = 0;
			this.labelRemarks.Text = "Remarks:";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.AutoSize = true;
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(510, 376);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(136, 18);
			this.labelHiddenRemarks.TabIndex = 0;
			this.labelHiddenRemarks.Text = "Hidden Remarks:";
			// 
			// textboxTitle
			// 
			this.textboxTitle.BackColor = System.Drawing.Color.White;
			this.textboxTitle.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxTitle.Location = new System.Drawing.Point(115, 10);
			this.textboxTitle.MaxLength = 256;
			this.textboxTitle.Name = "textboxTitle";
			this.textboxTitle.Size = new System.Drawing.Size(350, 26);
			this.textboxTitle.TabIndex = 3;
			// 
			// textboxBiWeeklyReport
			// 
			this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
			this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
			this.textboxBiWeeklyReport.MaxLength = 1000;
			this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
			this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 26);
			this.textboxBiWeeklyReport.TabIndex = 9;
			// 
			// textboxRemarks
			// 
			this.textboxRemarks.BackColor = System.Drawing.Color.White;
			this.textboxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxRemarks.Location = new System.Drawing.Point(630, 276);
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
			this.textboxHiddenRemarks.Location = new System.Drawing.Point(630, 373);
			this.textboxHiddenRemarks.MaxLength = 34000;
			this.textboxHiddenRemarks.Multiline = true;
			this.textboxHiddenRemarks.Name = "textboxHiddenRemarks";
			this.textboxHiddenRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxHiddenRemarks.Size = new System.Drawing.Size(350, 88);
			this.textboxHiddenRemarks.TabIndex = 23;
			// 
			// labelCheckList
			// 
			this.labelCheckList.AutoSize = true;
			this.labelCheckList.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCheckList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCheckList.Location = new System.Drawing.Point(10, 120);
			this.labelCheckList.Name = "labelCheckList";
			this.labelCheckList.Size = new System.Drawing.Size(91, 18);
			this.labelCheckList.TabIndex = 11;
			this.labelCheckList.Text = "Check List:";
			// 
			// textBoxEngOrderNo
			// 
			this.textBoxEngOrderNo.BackColor = System.Drawing.Color.White;
			this.textBoxEngOrderNo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxEngOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxEngOrderNo.Location = new System.Drawing.Point(115, 117);
			this.textBoxEngOrderNo.MaxLength = 200;
			this.textBoxEngOrderNo.Name = "textBoxEngOrderNo";
			this.textBoxEngOrderNo.Size = new System.Drawing.Size(350, 26);
			this.textBoxEngOrderNo.TabIndex = 9;
			this.textBoxEngOrderNo.Visible = false;
			// 
			// labelDepartment
			// 
			this.labelDepartment.AutoSize = true;
			this.labelDepartment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDepartment.Location = new System.Drawing.Point(510, 120);
			this.labelDepartment.Name = "labelDepartment";
			this.labelDepartment.Size = new System.Drawing.Size(124, 18);
			this.labelDepartment.TabIndex = 14;
			this.labelDepartment.Text = "Audited Object:";
			// 
			// textBoxDepartment
			// 
			this.textBoxDepartment.BackColor = System.Drawing.Color.White;
			this.textBoxDepartment.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDepartment.Location = new System.Drawing.Point(630, 117);
			this.textBoxDepartment.MaxLength = 200;
			this.textBoxDepartment.Name = "textBoxDepartment";
			this.textBoxDepartment.Size = new System.Drawing.Size(350, 26);
			this.textBoxDepartment.TabIndex = 15;
			// 
			// lookupComboboxCheckList
			// 
			this.lookupComboboxCheckList.Displayer = null;
			this.lookupComboboxCheckList.DisplayerText = null;
			this.lookupComboboxCheckList.Entity = null;
			this.lookupComboboxCheckList.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxCheckList.Location = new System.Drawing.Point(115, 117);
			this.lookupComboboxCheckList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lookupComboboxCheckList.Name = "lookupComboboxCheckList";
			this.lookupComboboxCheckList.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxCheckList.Size = new System.Drawing.Size(350, 26);
			this.lookupComboboxCheckList.TabIndex = 38;
			this.lookupComboboxCheckList.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// fileControlCheckList
			// 
			this.fileControlCheckList.AutoSize = true;
			this.fileControlCheckList.Description1 = "";
			this.fileControlCheckList.Description2 = "";
			this.fileControlCheckList.Filter = null;
			this.fileControlCheckList.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlCheckList.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlCheckList.Location = new System.Drawing.Point(115, 145);
			this.fileControlCheckList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.fileControlCheckList.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlCheckList.Name = "fileControlCheckList";
			this.fileControlCheckList.ShowLinkLabelBrowse = true;
			this.fileControlCheckList.ShowLinkLabelRemove = false;
			this.fileControlCheckList.Size = new System.Drawing.Size(350, 46);
			this.fileControlCheckList.TabIndex = 10;
			// 
			// fileControlProcedure
			// 
			this.fileControlProcedure.AutoSize = true;
			this.fileControlProcedure.Description1 = "";
			this.fileControlProcedure.Description2 = "";
			this.fileControlProcedure.Filter = null;
			this.fileControlProcedure.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlProcedure.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlProcedure.Location = new System.Drawing.Point(115, 38);
			this.fileControlProcedure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.fileControlProcedure.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlProcedure.Name = "fileControlProcedure";
			this.fileControlProcedure.ShowLinkLabelBrowse = true;
			this.fileControlProcedure.ShowLinkLabelRemove = false;
			this.fileControlProcedure.Size = new System.Drawing.Size(350, 46);
			this.fileControlProcedure.TabIndex = 4;
			// 
			// procedureDocRefListControl
			// 
			this.procedureDocRefListControl.AttachedObject = null;
			this.procedureDocRefListControl.AutoSize = true;
			this.procedureDocRefListControl.Location = new System.Drawing.Point(13, 466);
			this.procedureDocRefListControl.Margin = new System.Windows.Forms.Padding(5);
			this.procedureDocRefListControl.Name = "procedureDocRefListControl";
			this.procedureDocRefListControl.Procedure = null;
			this.procedureDocRefListControl.Size = new System.Drawing.Size(847, 283);
			this.procedureDocRefListControl.TabIndex = 40;
			// 
			// numericUpDownLevel
			// 
			this.numericUpDownLevel.Font = new System.Drawing.Font("Verdana", 9F);
			this.numericUpDownLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDownLevel.Location = new System.Drawing.Point(115, 248);
			this.numericUpDownLevel.Maximum = new decimal(new int[] {
			4,
			0,
			0,
			0});
			this.numericUpDownLevel.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numericUpDownLevel.Name = "numericUpDownLevel";
			this.numericUpDownLevel.Size = new System.Drawing.Size(350, 26);
			this.numericUpDownLevel.TabIndex = 41;
			this.numericUpDownLevel.Value = new decimal(new int[] {
			1,
			0,
			0,
			0});
			// 
			// labelLevel
			// 
			this.labelLevel.AutoSize = true;
			this.labelLevel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLevel.Location = new System.Drawing.Point(10, 250);
			this.labelLevel.Name = "labelLevel";
			this.labelLevel.Size = new System.Drawing.Size(53, 18);
			this.labelLevel.TabIndex = 42;
			this.labelLevel.Text = "Level:";
			// 
			// labelRating
			// 
			this.labelRating.AutoSize = true;
			this.labelRating.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRating.Location = new System.Drawing.Point(510, 244);
			this.labelRating.Name = "labelRating";
			this.labelRating.Size = new System.Drawing.Size(61, 18);
			this.labelRating.TabIndex = 44;
			this.labelRating.Text = "Rating:";
			// 
			// comboBox1
			// 
			this.comboBoxRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRating.Font = new System.Drawing.Font("Verdana", 9F);
			this.comboBoxRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxRating.FormattingEnabled = true;
			this.comboBoxRating.Location = new System.Drawing.Point(630, 242);
			this.comboBoxRating.Name = "comboBox1";
			this.comboBoxRating.Size = new System.Drawing.Size(350, 26);
			this.comboBoxRating.TabIndex = 45;
			this.comboBoxRating.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// ProcedureInformationControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.comboBoxRating);
			this.Controls.Add(this.labelRating);
			this.Controls.Add(this.labelLevel);
			this.Controls.Add(this.numericUpDownLevel);
			this.Controls.Add(this.procedureDocRefListControl);
			this.Controls.Add(this.lookupComboboxCheckList);
			this.Controls.Add(this.fileControlCheckList);
			this.Controls.Add(this.fileControlProcedure);
			this.Controls.Add(this.labelDepartment);
			this.Controls.Add(this.textBoxDepartment);
			this.Controls.Add(this.labelCheckList);
			this.Controls.Add(this.textBoxEngOrderNo);
			this.Controls.Add(this.textboxDescription);
			this.Controls.Add(this.labelTitle);
			this.Controls.Add(this.textboxTitle);
			this.Controls.Add(this.labelEffectivityDate);
			this.Controls.Add(this.dateTimePickerEffDate);
			this.Controls.Add(this.labelApplicability);
			this.Controls.Add(this.textboxApplicability);
			this.Controls.Add(this.labelSubject);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textboxRemarks);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.textboxHiddenRemarks);
			this.Name = "ProcedureInformationControl";
			this.Size = new System.Drawing.Size(984, 754);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelTitle;
		private Label labelEffectivityDate;
		private Label labelApplicability;
		private Label labelBiWeeklyReport;
		private Label labelSubject;
		private Label labelRemarks;
		private Label labelHiddenRemarks;
		private TextBox textboxTitle;
		private DateTimePicker dateTimePickerEffDate;
		private TextBox textboxApplicability;
		private TextBox textboxBiWeeklyReport;
		private TextBox textboxDescription;
		private TextBox textboxRemarks;
		private TextBox textboxHiddenRemarks;
		private Label labelCheckList;
		private TextBox textBoxEngOrderNo;
		private Label labelDepartment;
		private TextBox textBoxDepartment;
		private AttachedFileControl fileControlProcedure;
		private AttachedFileControl fileControlCheckList;
		private LookupCombobox lookupComboboxCheckList;
		private ProcedureDocRefListControl procedureDocRefListControl;
		private NumericUpDown numericUpDownLevel;
		private Label labelLevel;
		private Label labelRating;
		private ComboBox comboBoxRating;

	}
}
