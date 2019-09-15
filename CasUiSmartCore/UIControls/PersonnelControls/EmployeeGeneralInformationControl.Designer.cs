using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PersonnelControls
{
	partial class EmployeeGeneralInformationControl
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

			//dateTimePickerDateOfBirth.ValueChanged -= DateTimePickerEffDateValueChanged;

			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Обязательный метод для поддержки конструктора - не изменяйте 
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelBirthDate = new System.Windows.Forms.Label();
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.textboxAddress = new System.Windows.Forms.TextBox();
			this.dateTimePickerDateOfBirth = new System.Windows.Forms.DateTimePicker();
			this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
			this.labelFirstName = new System.Windows.Forms.Label();
			this.textBoxFirstName = new System.Windows.Forms.TextBox();
			this.labelFamilyStatus = new System.Windows.Forms.Label();
			this.LabelLastName = new System.Windows.Forms.Label();
			this.textBoxLastName = new System.Windows.Forms.TextBox();
			this.labelPassportCopy = new System.Windows.Forms.Label();
			this.labelNationality = new System.Windows.Forms.Label();
			this.comboBoxGender = new System.Windows.Forms.ComboBox();
			this.labelGender = new System.Windows.Forms.Label();
			this.labelPhoto = new System.Windows.Forms.Label();
			this._pictureBoxTransparentLogotype = new System.Windows.Forms.PictureBox();
			this.labelResume = new System.Windows.Forms.Label();
			this.labelOccupation = new System.Windows.Forms.Label();
			this.labelPhoneMobile = new System.Windows.Forms.Label();
			this.textBoxPhoneMobile = new System.Windows.Forms.TextBox();
			this.labelPhone = new System.Windows.Forms.Label();
			this.textBoxPhone = new System.Windows.Forms.TextBox();
			this.labelEmail = new System.Windows.Forms.Label();
			this.textBoxEmail = new System.Windows.Forms.TextBox();
			this.labelSkype = new System.Windows.Forms.Label();
			this.textBoxSkype = new System.Windows.Forms.TextBox();
			this.labelEducation = new System.Windows.Forms.Label();
			this.textBoxInformation = new System.Windows.Forms.TextBox();
			this.labelInformation = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBoxSign = new System.Windows.Forms.PictureBox();
			this.comboBoxfamilyStatus = new System.Windows.Forms.ComboBox();
			this.comboBoxEducation = new System.Windows.Forms.ComboBox();
			this.textBoxNationality = new System.Windows.Forms.TextBox();
			this.comboBoxNationality = new System.Windows.Forms.ComboBox();
			this.labelPosition = new System.Windows.Forms.Label();
			this.comboBoxPosition = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dictionaryComboBoxOccupation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.fileControlResume = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.fileControlPassportCopy = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxAdditional = new System.Windows.Forms.TextBox();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxShortName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this._pictureBoxTransparentLogotype)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSign)).BeginInit();
			this.SuspendLayout();
			// 
			// labelBirthDate
			// 
			this.labelBirthDate.AutoSize = true;
			this.labelBirthDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBirthDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBirthDate.Location = new System.Drawing.Point(10, 71);
			this.labelBirthDate.Name = "labelBirthDate";
			this.labelBirthDate.Size = new System.Drawing.Size(91, 14);
			this.labelBirthDate.TabIndex = 0;
			this.labelBirthDate.Text = "Date of Birth:";
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
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddress.Location = new System.Drawing.Point(10, 220);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(63, 14);
			this.labelAddress.TabIndex = 0;
			this.labelAddress.Text = "Address:";
			// 
			// textboxAddress
			// 
			this.textboxAddress.BackColor = System.Drawing.Color.White;
			this.textboxAddress.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxAddress.Location = new System.Drawing.Point(115, 217);
			this.textboxAddress.MaxLength = 3000;
			this.textboxAddress.Multiline = true;
			this.textboxAddress.Name = "textboxAddress";
			this.textboxAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textboxAddress.Size = new System.Drawing.Size(350, 88);
			this.textboxAddress.TabIndex = 6;
			// 
			// dateTimePickerDateOfBirth
			// 
			this.dateTimePickerDateOfBirth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDateOfBirth.Location = new System.Drawing.Point(115, 65);
			this.dateTimePickerDateOfBirth.Name = "dateTimePickerDateOfBirth";
			this.dateTimePickerDateOfBirth.Size = new System.Drawing.Size(350, 22);
			this.dateTimePickerDateOfBirth.TabIndex = 2;
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
			// labelFirstName
			// 
			this.labelFirstName.AutoSize = true;
			this.labelFirstName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFirstName.Location = new System.Drawing.Point(10, 13);
			this.labelFirstName.Name = "labelFirstName";
			this.labelFirstName.Size = new System.Drawing.Size(79, 14);
			this.labelFirstName.TabIndex = 14;
			this.labelFirstName.Text = "First Name:";
			// 
			// textBoxFirstName
			// 
			this.textBoxFirstName.BackColor = System.Drawing.Color.White;
			this.textBoxFirstName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxFirstName.Location = new System.Drawing.Point(115, 10);
			this.textBoxFirstName.MaxLength = 200;
			this.textBoxFirstName.Name = "textBoxFirstName";
			this.textBoxFirstName.Size = new System.Drawing.Size(350, 22);
			this.textBoxFirstName.TabIndex = 19;
			// 
			// labelFamilyStatus
			// 
			this.labelFamilyStatus.AutoSize = true;
			this.labelFamilyStatus.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFamilyStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFamilyStatus.Location = new System.Drawing.Point(10, 192);
			this.labelFamilyStatus.Name = "labelFamilyStatus";
			this.labelFamilyStatus.Size = new System.Drawing.Size(95, 14);
			this.labelFamilyStatus.TabIndex = 20;
			this.labelFamilyStatus.Text = "Family Status:";
			// 
			// LabelLastName
			// 
			this.LabelLastName.AutoSize = true;
			this.LabelLastName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LabelLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.LabelLastName.Location = new System.Drawing.Point(10, 41);
			this.LabelLastName.Name = "LabelLastName";
			this.LabelLastName.Size = new System.Drawing.Size(79, 14);
			this.LabelLastName.TabIndex = 22;
			this.LabelLastName.Text = "Last Name:";
			// 
			// textBoxLastName
			// 
			this.textBoxLastName.BackColor = System.Drawing.Color.White;
			this.textBoxLastName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxLastName.Location = new System.Drawing.Point(115, 38);
			this.textBoxLastName.MaxLength = 200;
			this.textBoxLastName.Name = "textBoxLastName";
			this.textBoxLastName.Size = new System.Drawing.Size(196, 22);
			this.textBoxLastName.TabIndex = 1;
			// 
			// labelPassportCopy
			// 
			this.labelPassportCopy.AutoSize = true;
			this.labelPassportCopy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPassportCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPassportCopy.Location = new System.Drawing.Point(503, 483);
			this.labelPassportCopy.Name = "labelPassportCopy";
			this.labelPassportCopy.Size = new System.Drawing.Size(98, 14);
			this.labelPassportCopy.TabIndex = 25;
			this.labelPassportCopy.Text = "Characteristic:";
			// 
			// labelNationality
			// 
			this.labelNationality.AutoSize = true;
			this.labelNationality.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNationality.Location = new System.Drawing.Point(10, 127);
			this.labelNationality.Name = "labelNationality";
			this.labelNationality.Size = new System.Drawing.Size(79, 14);
			this.labelNationality.TabIndex = 28;
			this.labelNationality.Text = "Nationality:";
			// 
			// comboBoxGender
			// 
			this.comboBoxGender.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxGender.FormattingEnabled = true;
			this.comboBoxGender.Location = new System.Drawing.Point(115, 93);
			this.comboBoxGender.Name = "comboBoxGender";
			this.comboBoxGender.Size = new System.Drawing.Size(350, 25);
			this.comboBoxGender.TabIndex = 3;
			this.comboBoxGender.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelGender
			// 
			this.labelGender.AutoSize = true;
			this.labelGender.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelGender.Location = new System.Drawing.Point(10, 98);
			this.labelGender.Name = "labelGender";
			this.labelGender.Size = new System.Drawing.Size(35, 14);
			this.labelGender.TabIndex = 39;
			this.labelGender.Text = "Sex:";
			this.labelGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPhoto
			// 
			this.labelPhoto.AutoSize = true;
			this.labelPhoto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhoto.Location = new System.Drawing.Point(10, 402);
			this.labelPhoto.Name = "labelPhoto";
			this.labelPhoto.Size = new System.Drawing.Size(86, 14);
			this.labelPhoto.TabIndex = 41;
			this.labelPhoto.Text = "Photo (.png)";
			this.labelPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _pictureBoxTransparentLogotype
			// 
			this._pictureBoxTransparentLogotype.BackColor = System.Drawing.Color.White;
			this._pictureBoxTransparentLogotype.BackgroundImage = global::CAS.UI.Properties.Resources.EmptyLogotypeIcon;
			this._pictureBoxTransparentLogotype.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this._pictureBoxTransparentLogotype.Cursor = System.Windows.Forms.Cursors.Hand;
			this._pictureBoxTransparentLogotype.Location = new System.Drawing.Point(115, 402);
			this._pictureBoxTransparentLogotype.Name = "_pictureBoxTransparentLogotype";
			this._pictureBoxTransparentLogotype.Size = new System.Drawing.Size(90, 120);
			this._pictureBoxTransparentLogotype.TabIndex = 42;
			this._pictureBoxTransparentLogotype.TabStop = false;
			this._pictureBoxTransparentLogotype.Click += new System.EventHandler(this.PictureBoxLogotypeClick);
			// 
			// labelResume
			// 
			this.labelResume.AutoSize = true;
			this.labelResume.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelResume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelResume.Location = new System.Drawing.Point(503, 384);
			this.labelResume.Name = "labelResume";
			this.labelResume.Size = new System.Drawing.Size(62, 14);
			this.labelResume.TabIndex = 48;
			this.labelResume.Text = "Resume:";
			// 
			// labelOccupation
			// 
			this.labelOccupation.AutoSize = true;
			this.labelOccupation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelOccupation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOccupation.Location = new System.Drawing.Point(503, 156);
			this.labelOccupation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOccupation.Name = "labelOccupation";
			this.labelOccupation.Size = new System.Drawing.Size(82, 14);
			this.labelOccupation.TabIndex = 49;
			this.labelOccupation.Text = "Occupation:";
			// 
			// labelPhoneMobile
			// 
			this.labelPhoneMobile.AutoSize = true;
			this.labelPhoneMobile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPhoneMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhoneMobile.Location = new System.Drawing.Point(503, 13);
			this.labelPhoneMobile.Name = "labelPhoneMobile";
			this.labelPhoneMobile.Size = new System.Drawing.Size(96, 14);
			this.labelPhoneMobile.TabIndex = 53;
			this.labelPhoneMobile.Text = "Phone Mobile:";
			// 
			// textBoxPhoneMobile
			// 
			this.textBoxPhoneMobile.BackColor = System.Drawing.Color.White;
			this.textBoxPhoneMobile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPhoneMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPhoneMobile.Location = new System.Drawing.Point(608, 10);
			this.textBoxPhoneMobile.MaxLength = 200;
			this.textBoxPhoneMobile.Name = "textBoxPhoneMobile";
			this.textBoxPhoneMobile.Size = new System.Drawing.Size(350, 22);
			this.textBoxPhoneMobile.TabIndex = 52;
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhone.Location = new System.Drawing.Point(503, 41);
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(52, 14);
			this.labelPhone.TabIndex = 55;
			this.labelPhone.Text = "Phone:";
			// 
			// textBoxPhone
			// 
			this.textBoxPhone.BackColor = System.Drawing.Color.White;
			this.textBoxPhone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPhone.Location = new System.Drawing.Point(608, 38);
			this.textBoxPhone.MaxLength = 200;
			this.textBoxPhone.Name = "textBoxPhone";
			this.textBoxPhone.Size = new System.Drawing.Size(183, 22);
			this.textBoxPhone.TabIndex = 54;
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEmail.Location = new System.Drawing.Point(503, 71);
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(50, 14);
			this.labelEmail.TabIndex = 57;
			this.labelEmail.Text = "E-mail:";
			// 
			// textBoxEmail
			// 
			this.textBoxEmail.BackColor = System.Drawing.Color.White;
			this.textBoxEmail.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxEmail.Location = new System.Drawing.Point(608, 68);
			this.textBoxEmail.MaxLength = 200;
			this.textBoxEmail.Name = "textBoxEmail";
			this.textBoxEmail.Size = new System.Drawing.Size(350, 22);
			this.textBoxEmail.TabIndex = 56;
			// 
			// labelSkype
			// 
			this.labelSkype.AutoSize = true;
			this.labelSkype.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSkype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSkype.Location = new System.Drawing.Point(503, 98);
			this.labelSkype.Name = "labelSkype";
			this.labelSkype.Size = new System.Drawing.Size(50, 14);
			this.labelSkype.TabIndex = 59;
			this.labelSkype.Text = "Skype:";
			// 
			// textBoxSkype
			// 
			this.textBoxSkype.BackColor = System.Drawing.Color.White;
			this.textBoxSkype.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxSkype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSkype.Location = new System.Drawing.Point(608, 98);
			this.textBoxSkype.MaxLength = 200;
			this.textBoxSkype.Name = "textBoxSkype";
			this.textBoxSkype.Size = new System.Drawing.Size(350, 22);
			this.textBoxSkype.TabIndex = 58;
			// 
			// labelEducation
			// 
			this.labelEducation.AutoSize = true;
			this.labelEducation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelEducation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEducation.Location = new System.Drawing.Point(503, 127);
			this.labelEducation.Name = "labelEducation";
			this.labelEducation.Size = new System.Drawing.Size(74, 14);
			this.labelEducation.TabIndex = 61;
			this.labelEducation.Text = "Education:";
			// 
			// textBoxInformation
			// 
			this.textBoxInformation.BackColor = System.Drawing.Color.White;
			this.textBoxInformation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxInformation.Location = new System.Drawing.Point(115, 311);
			this.textBoxInformation.MaxLength = 3000;
			this.textBoxInformation.Multiline = true;
			this.textBoxInformation.Name = "textBoxInformation";
			this.textBoxInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxInformation.Size = new System.Drawing.Size(350, 88);
			this.textBoxInformation.TabIndex = 64;
			// 
			// labelInformation
			// 
			this.labelInformation.AutoSize = true;
			this.labelInformation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInformation.Location = new System.Drawing.Point(10, 314);
			this.labelInformation.Name = "labelInformation";
			this.labelInformation.Size = new System.Drawing.Size(85, 28);
			this.labelInformation.TabIndex = 63;
			this.labelInformation.Text = "Add \r\nInformation:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(211, 402);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 14);
			this.label1.TabIndex = 65;
			this.label1.Text = "Sign (.png)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBoxSign
			// 
			this.pictureBoxSign.BackColor = System.Drawing.Color.White;
			this.pictureBoxSign.BackgroundImage = global::CAS.UI.Properties.Resources.EmptyLogotypeIcon;
			this.pictureBoxSign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBoxSign.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBoxSign.Location = new System.Drawing.Point(293, 402);
			this.pictureBoxSign.Name = "pictureBoxSign";
			this.pictureBoxSign.Size = new System.Drawing.Size(172, 120);
			this.pictureBoxSign.TabIndex = 66;
			this.pictureBoxSign.TabStop = false;
			this.pictureBoxSign.Click += new System.EventHandler(this.PictureBoxLogotypeSignClick);
			// 
			// comboBoxfamilyStatus
			// 
			this.comboBoxfamilyStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxfamilyStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxfamilyStatus.FormattingEnabled = true;
			this.comboBoxfamilyStatus.Location = new System.Drawing.Point(115, 184);
			this.comboBoxfamilyStatus.Name = "comboBoxfamilyStatus";
			this.comboBoxfamilyStatus.Size = new System.Drawing.Size(350, 25);
			this.comboBoxfamilyStatus.TabIndex = 67;
			this.comboBoxfamilyStatus.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxEducation
			// 
			this.comboBoxEducation.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxEducation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxEducation.FormattingEnabled = true;
			this.comboBoxEducation.Location = new System.Drawing.Point(608, 124);
			this.comboBoxEducation.Name = "comboBoxEducation";
			this.comboBoxEducation.Size = new System.Drawing.Size(350, 25);
			this.comboBoxEducation.TabIndex = 68;
			this.comboBoxEducation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxNationality
			// 
			this.textBoxNationality.BackColor = System.Drawing.Color.White;
			this.textBoxNationality.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxNationality.Location = new System.Drawing.Point(115, 156);
			this.textBoxNationality.MaxLength = 200;
			this.textBoxNationality.Name = "textBoxNationality";
			this.textBoxNationality.Size = new System.Drawing.Size(350, 22);
			this.textBoxNationality.TabIndex = 4;
			// 
			// comboBoxNationality
			// 
			this.comboBoxNationality.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxNationality.FormattingEnabled = true;
			this.comboBoxNationality.Location = new System.Drawing.Point(115, 125);
			this.comboBoxNationality.Name = "comboBoxNationality";
			this.comboBoxNationality.Size = new System.Drawing.Size(350, 25);
			this.comboBoxNationality.TabIndex = 69;
			this.comboBoxNationality.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPosition.Location = new System.Drawing.Point(503, 282);
			this.labelPosition.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(62, 14);
			this.labelPosition.TabIndex = 70;
			this.labelPosition.Text = "Position:";
			// 
			// comboBoxPosition
			// 
			this.comboBoxPosition.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxPosition.FormattingEnabled = true;
			this.comboBoxPosition.Location = new System.Drawing.Point(608, 280);
			this.comboBoxPosition.Name = "comboBoxPosition";
			this.comboBoxPosition.Size = new System.Drawing.Size(350, 25);
			this.comboBoxPosition.TabIndex = 71;
			this.comboBoxPosition.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(503, 313);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 14);
			this.label2.TabIndex = 73;
			this.label2.Text = "Place of work:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(503, 344);
			this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 14);
			this.label3.TabIndex = 74;
			this.label3.Text = "Status:";
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(608, 339);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(350, 25);
			this.comboBoxStatus.TabIndex = 75;
			this.comboBoxStatus.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dictionaryComboBoxLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(608, 312);
			this.dictionaryComboBoxLocation.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(350, 22);
			this.dictionaryComboBoxLocation.TabIndex = 72;
			this.dictionaryComboBoxLocation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictionaryComboBoxOccupation
			// 
			this.dictionaryComboBoxOccupation.Displayer = null;
			this.dictionaryComboBoxOccupation.DisplayerText = null;
			this.dictionaryComboBoxOccupation.Entity = null;
			this.dictionaryComboBoxOccupation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dictionaryComboBoxOccupation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dictionaryComboBoxOccupation.Location = new System.Drawing.Point(608, 157);
			this.dictionaryComboBoxOccupation.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboBoxOccupation.Name = "dictionaryComboBoxOccupation";
			this.dictionaryComboBoxOccupation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxOccupation.Size = new System.Drawing.Size(350, 22);
			this.dictionaryComboBoxOccupation.TabIndex = 16;
			this.dictionaryComboBoxOccupation.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// fileControlResume
			// 
			this.fileControlResume.AutoSize = true;
			this.fileControlResume.Description1 = "";
			this.fileControlResume.Description2 = "";
			this.fileControlResume.Filter = null;
			this.fileControlResume.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlResume.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlResume.Location = new System.Drawing.Point(630, 381);
			this.fileControlResume.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlResume.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlResume.Name = "fileControlResume";
			this.fileControlResume.ShowLinkLabelBrowse = true;
			this.fileControlResume.ShowLinkLabelRemove = false;
			this.fileControlResume.Size = new System.Drawing.Size(350, 37);
			this.fileControlResume.TabIndex = 15;
			// 
			// fileControlPassportCopy
			// 
			this.fileControlPassportCopy.AutoSize = true;
			this.fileControlPassportCopy.Description1 = "";
			this.fileControlPassportCopy.Description2 = "";
			this.fileControlPassportCopy.Filter = null;
			this.fileControlPassportCopy.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
			this.fileControlPassportCopy.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
			this.fileControlPassportCopy.Location = new System.Drawing.Point(630, 480);
			this.fileControlPassportCopy.Margin = new System.Windows.Forms.Padding(4);
			this.fileControlPassportCopy.MaximumSize = new System.Drawing.Size(350, 100);
			this.fileControlPassportCopy.Name = "fileControlPassportCopy";
			this.fileControlPassportCopy.ShowLinkLabelBrowse = true;
			this.fileControlPassportCopy.ShowLinkLabelRemove = false;
			this.fileControlPassportCopy.Size = new System.Drawing.Size(350, 37);
			this.fileControlPassportCopy.TabIndex = 14;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label4.Location = new System.Drawing.Point(797, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 14);
			this.label4.TabIndex = 76;
			this.label4.Text = "Additional:";
			// 
			// textBoxAdditional
			// 
			this.textBoxAdditional.BackColor = System.Drawing.Color.White;
			this.textBoxAdditional.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAdditional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAdditional.Location = new System.Drawing.Point(877, 38);
			this.textBoxAdditional.MaxLength = 200;
			this.textBoxAdditional.Name = "textBoxAdditional";
			this.textBoxAdditional.Size = new System.Drawing.Size(81, 22);
			this.textBoxAdditional.TabIndex = 77;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(608, 192);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(350, 79);
			this.checkedListBox1.TabIndex = 78;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label5.Location = new System.Drawing.Point(503, 195);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 14);
			this.label5.TabIndex = 79;
			this.label5.Text = "Conbination:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(317, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 14);
			this.label6.TabIndex = 81;
			this.label6.Text = "Short Name:";
			// 
			// textBoxShortName
			// 
			this.textBoxShortName.BackColor = System.Drawing.Color.White;
			this.textBoxShortName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxShortName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxShortName.Location = new System.Drawing.Point(409, 37);
			this.textBoxShortName.MaxLength = 200;
			this.textBoxShortName.Name = "textBoxShortName";
			this.textBoxShortName.Size = new System.Drawing.Size(56, 22);
			this.textBoxShortName.TabIndex = 80;
			// 
			// EmployeeGeneralInformationControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxShortName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.textBoxAdditional);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(this.comboBoxPosition);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.comboBoxNationality);
			this.Controls.Add(this.comboBoxEducation);
			this.Controls.Add(this.comboBoxfamilyStatus);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBoxSign);
			this.Controls.Add(this.textBoxInformation);
			this.Controls.Add(this.labelInformation);
			this.Controls.Add(this.labelEducation);
			this.Controls.Add(this.labelSkype);
			this.Controls.Add(this.textBoxSkype);
			this.Controls.Add(this.labelEmail);
			this.Controls.Add(this.textBoxEmail);
			this.Controls.Add(this.labelPhone);
			this.Controls.Add(this.textBoxPhone);
			this.Controls.Add(this.labelPhoneMobile);
			this.Controls.Add(this.textBoxPhoneMobile);
			this.Controls.Add(this.dictionaryComboBoxOccupation);
			this.Controls.Add(this.labelOccupation);
			this.Controls.Add(this.labelResume);
			this.Controls.Add(this.labelPhoto);
			this.Controls.Add(this._pictureBoxTransparentLogotype);
			this.Controls.Add(this.comboBoxGender);
			this.Controls.Add(this.labelGender);
			this.Controls.Add(this.labelNationality);
			this.Controls.Add(this.textBoxNationality);
			this.Controls.Add(this.fileControlResume);
			this.Controls.Add(this.labelPassportCopy);
			this.Controls.Add(this.fileControlPassportCopy);
			this.Controls.Add(this.LabelLastName);
			this.Controls.Add(this.textBoxLastName);
			this.Controls.Add(this.labelFamilyStatus);
			this.Controls.Add(this.labelFirstName);
			this.Controls.Add(this.textBoxFirstName);
			this.Controls.Add(this.textboxAddress);
			this.Controls.Add(this.labelBirthDate);
			this.Controls.Add(this.dateTimePickerDateOfBirth);
			this.Controls.Add(this.labelAddress);
			this.Name = "EmployeeGeneralInformationControl";
			this.Size = new System.Drawing.Size(988, 528);
			((System.ComponentModel.ISupportInitialize)(this._pictureBoxTransparentLogotype)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSign)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Label labelBirthDate;
		private Label labelBiWeeklyReport;
		private Label labelAddress;
		private DateTimePicker dateTimePickerDateOfBirth;
		private TextBox textboxBiWeeklyReport;
		private TextBox textboxAddress;
		private Label labelFirstName;
		private TextBox textBoxFirstName;
		private Label labelFamilyStatus;
		private Label LabelLastName;
		private TextBox textBoxLastName;
		private AttachedFileControl fileControlPassportCopy;
		private AttachedFileControl fileControlResume;
		private Label labelPassportCopy;
		private Label labelNationality;
		private ComboBox comboBoxGender;
		private Label labelGender;
		private Label labelPhoto;
		private PictureBox _pictureBoxTransparentLogotype;
		private Label labelResume;
		private DictionaryComboBox dictionaryComboBoxOccupation;
		private Label labelOccupation;
		private Label labelPhoneMobile;
		private TextBox textBoxPhoneMobile;
		private Label labelPhone;
		private TextBox textBoxPhone;
		private Label labelEmail;
		private TextBox textBoxEmail;
		private Label labelSkype;
		private TextBox textBoxSkype;
		private Label labelEducation;
		private TextBox textBoxInformation;
		private Label labelInformation;
		private Label label1;
		private PictureBox pictureBoxSign;
		private ComboBox comboBoxfamilyStatus;
		private ComboBox comboBoxEducation;
		private TextBox textBoxNationality;
		private ComboBox comboBoxNationality;
		private Label labelPosition;
		private ComboBox comboBoxPosition;
		private DictionaryComboBox dictionaryComboBoxLocation;
		private Label label2;
		private Label label3;
		private ComboBox comboBoxStatus;
		private Label label4;
		private TextBox textBoxAdditional;
		private CheckedListBox checkedListBox1;
		private Label label5;
		private Label label6;
		private TextBox textBoxShortName;
	}
}
