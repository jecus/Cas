using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UICAAControls.Airacraft
{
	partial class CAAAircraftControl
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
            System.Windows.Forms.Label labelAircraftTSNCSN;
            System.Windows.Forms.Label label1;
            this.labelAircraftModel = new System.Windows.Forms.Label();
            this.labelAircraftTypeCertificateNo = new System.Windows.Forms.Label();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.labelSerialNumber = new System.Windows.Forms.Label();
            this.labelVariableNumber = new System.Windows.Forms.Label();
            this.labelLineNumber = new System.Windows.Forms.Label();
            this.labelRegistrationNumber = new System.Windows.Forms.Label();
            this.labelOwner = new System.Windows.Forms.Label();
            this.labelOperator = new System.Windows.Forms.Label();
            this.textBoxAircraftTypeCertificateNo = new System.Windows.Forms.TextBox();
            this.textBoxSerialNumber = new System.Windows.Forms.TextBox();
            this.textBoxVariableNumber = new System.Windows.Forms.TextBox();
            this.textBoxLineNumber = new System.Windows.Forms.TextBox();
            this.textBoxRegistrationNumber = new System.Windows.Forms.TextBox();
            this.textBoxOwner = new System.Windows.Forms.TextBox();
            this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dictionaryComboBoxAircraftModel = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
            this.comboBoxMSG = new System.Windows.Forms.ComboBox();
            this.labelMSG = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxApuWorktime = new System.Windows.Forms.ComboBox();
            this.numericUpDownAPU = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTD = new System.Windows.Forms.DateTimePicker();
            this.lifelengthViewerStart = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.lifelengthViewerToday = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            labelAircraftTSNCSN = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPU)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAircraftTSNCSN
            // 
            labelAircraftTSNCSN.AutoSize = true;
            labelAircraftTSNCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            labelAircraftTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            labelAircraftTSNCSN.Location = new System.Drawing.Point(165, 295);
            labelAircraftTSNCSN.Name = "labelAircraftTSNCSN";
            labelAircraftTSNCSN.Size = new System.Drawing.Size(44, 17);
            labelAircraftTSNCSN.TabIndex = 8;
            labelAircraftTSNCSN.Text = "Start";
            labelAircraftTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(158, 327);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 17);
            label1.TabIndex = 27;
            label1.Text = "Today";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAircraftModel
            // 
            this.labelAircraftModel.AutoSize = true;
            this.labelAircraftModel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftModel.Location = new System.Drawing.Point(3, 5);
            this.labelAircraftModel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelAircraftModel.Name = "labelAircraftModel";
            this.labelAircraftModel.Size = new System.Drawing.Size(104, 17);
            this.labelAircraftModel.TabIndex = 2;
            this.labelAircraftModel.Text = "Aircraft Model";
            // 
            // labelAircraftTypeCertificateNo
            // 
            this.labelAircraftTypeCertificateNo.AutoSize = true;
            this.labelAircraftTypeCertificateNo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTypeCertificateNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTypeCertificateNo.Location = new System.Drawing.Point(3, 95);
            this.labelAircraftTypeCertificateNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelAircraftTypeCertificateNo.Name = "labelAircraftTypeCertificateNo";
            this.labelAircraftTypeCertificateNo.Size = new System.Drawing.Size(196, 17);
            this.labelAircraftTypeCertificateNo.TabIndex = 11;
            this.labelAircraftTypeCertificateNo.Text = "Aircraft Type Certificate No";
            this.labelAircraftTypeCertificateNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.AutoSize = true;
            this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufactureDate.Location = new System.Drawing.Point(77, 244);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(132, 17);
            this.labelManufactureDate.TabIndex = 3;
            this.labelManufactureDate.Text = "Manufacture Date";
            this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSerialNumber
            // 
            this.labelSerialNumber.AutoSize = true;
            this.labelSerialNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSerialNumber.Location = new System.Drawing.Point(3, 35);
            this.labelSerialNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelSerialNumber.Name = "labelSerialNumber";
            this.labelSerialNumber.Size = new System.Drawing.Size(106, 17);
            this.labelSerialNumber.TabIndex = 4;
            this.labelSerialNumber.Text = "Serial Number";
            this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVariableNumber
            // 
            this.labelVariableNumber.AutoSize = true;
            this.labelVariableNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelVariableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelVariableNumber.Location = new System.Drawing.Point(529, 65);
            this.labelVariableNumber.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.labelVariableNumber.Name = "labelVariableNumber";
            this.labelVariableNumber.Size = new System.Drawing.Size(122, 17);
            this.labelVariableNumber.TabIndex = 5;
            this.labelVariableNumber.Text = "Variable Number";
            this.labelVariableNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLineNumber
            // 
            this.labelLineNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLineNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLineNumber.Location = new System.Drawing.Point(529, 95);
            this.labelLineNumber.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.labelLineNumber.Name = "labelLineNumber";
            this.labelLineNumber.Size = new System.Drawing.Size(100, 23);
            this.labelLineNumber.TabIndex = 6;
            this.labelLineNumber.Text = "Line Number";
            this.labelLineNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRegistrationNumber
            // 
            this.labelRegistrationNumber.AutoSize = true;
            this.labelRegistrationNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRegistrationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRegistrationNumber.Location = new System.Drawing.Point(3, 65);
            this.labelRegistrationNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labelRegistrationNumber.Name = "labelRegistrationNumber";
            this.labelRegistrationNumber.Size = new System.Drawing.Size(153, 17);
            this.labelRegistrationNumber.TabIndex = 7;
            this.labelRegistrationNumber.Text = "Registration Number";
            this.labelRegistrationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelOwner.Location = new System.Drawing.Point(529, 5);
            this.labelOwner.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(53, 17);
            this.labelOwner.TabIndex = 9;
            this.labelOwner.Text = "Owner";
            this.labelOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelOperator
            // 
            this.labelOperator.AutoSize = true;
            this.labelOperator.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelOperator.Location = new System.Drawing.Point(529, 35);
            this.labelOperator.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(71, 17);
            this.labelOperator.TabIndex = 10;
            this.labelOperator.Text = "Operator";
            this.labelOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxAircraftTypeCertificateNo
            // 
            this.textBoxAircraftTypeCertificateNo.BackColor = System.Drawing.Color.White;
            this.textBoxAircraftTypeCertificateNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxAircraftTypeCertificateNo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAircraftTypeCertificateNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAircraftTypeCertificateNo.Location = new System.Drawing.Point(205, 93);
            this.textBoxAircraftTypeCertificateNo.Name = "textBoxAircraftTypeCertificateNo";
            this.textBoxAircraftTypeCertificateNo.Size = new System.Drawing.Size(271, 25);
            this.textBoxAircraftTypeCertificateNo.TabIndex = 17;
            // 
            // textBoxSerialNumber
            // 
            this.textBoxSerialNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSerialNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSerialNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxSerialNumber.Location = new System.Drawing.Point(205, 33);
            this.textBoxSerialNumber.Name = "textBoxSerialNumber";
            this.textBoxSerialNumber.Size = new System.Drawing.Size(271, 25);
            this.textBoxSerialNumber.TabIndex = 15;
            // 
            // textBoxVariableNumber
            // 
            this.textBoxVariableNumber.BackColor = System.Drawing.Color.White;
            this.textBoxVariableNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxVariableNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxVariableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxVariableNumber.Location = new System.Drawing.Point(672, 63);
            this.textBoxVariableNumber.Name = "textBoxVariableNumber";
            this.textBoxVariableNumber.Size = new System.Drawing.Size(271, 25);
            this.textBoxVariableNumber.TabIndex = 21;
            // 
            // textBoxLineNumber
            // 
            this.textBoxLineNumber.BackColor = System.Drawing.Color.White;
            this.textBoxLineNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxLineNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLineNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxLineNumber.Location = new System.Drawing.Point(672, 93);
            this.textBoxLineNumber.Name = "textBoxLineNumber";
            this.textBoxLineNumber.Size = new System.Drawing.Size(271, 25);
            this.textBoxLineNumber.TabIndex = 22;
            // 
            // textBoxRegistrationNumber
            // 
            this.textBoxRegistrationNumber.BackColor = System.Drawing.Color.White;
            this.textBoxRegistrationNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxRegistrationNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxRegistrationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxRegistrationNumber.Location = new System.Drawing.Point(205, 63);
            this.textBoxRegistrationNumber.Name = "textBoxRegistrationNumber";
            this.textBoxRegistrationNumber.Size = new System.Drawing.Size(271, 25);
            this.textBoxRegistrationNumber.TabIndex = 16;
            // 
            // textBoxOwner
            // 
            this.textBoxOwner.BackColor = System.Drawing.Color.White;
            this.textBoxOwner.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxOwner.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxOwner.Location = new System.Drawing.Point(672, 3);
            this.textBoxOwner.Name = "textBoxOwner";
            this.textBoxOwner.Size = new System.Drawing.Size(271, 25);
            this.textBoxOwner.TabIndex = 19;
            // 
            // dateTimePickerManufactureDate
            // 
            this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(215, 238);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(176, 25);
            this.dateTimePickerManufactureDate.TabIndex = 14;
            this.dateTimePickerManufactureDate.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dictionaryComboBoxAircraftModel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelAircraftModel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelVariableNumber, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelOwner, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxRegistrationNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxAircraftTypeCertificateNo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxLineNumber, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxVariableNumber, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOwner, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSerialNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelOperator, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelLineNumber, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelSerialNumber, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRegistrationNumber, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAircraftTypeCertificateNo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMSG, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelMSG, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxApuWorktime, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownAPU, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxOperator, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 212);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // dictionaryComboBoxAircraftModel
            // 
            this.dictionaryComboBoxAircraftModel.Displayer = null;
            this.dictionaryComboBoxAircraftModel.DisplayerText = null;
            this.dictionaryComboBoxAircraftModel.Entity = null;
            this.dictionaryComboBoxAircraftModel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dictionaryComboBoxAircraftModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dictionaryComboBoxAircraftModel.Location = new System.Drawing.Point(206, 4);
            this.dictionaryComboBoxAircraftModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dictionaryComboBoxAircraftModel.Name = "dictionaryComboBoxAircraftModel";
            this.dictionaryComboBoxAircraftModel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxAircraftModel.Size = new System.Drawing.Size(269, 25);
            this.dictionaryComboBoxAircraftModel.TabIndex = 28;
            this.dictionaryComboBoxAircraftModel.Type = null;
            // 
            // comboBoxMSG
            // 
            this.comboBoxMSG.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxMSG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxMSG.FormattingEnabled = true;
            this.comboBoxMSG.Location = new System.Drawing.Point(672, 123);
            this.comboBoxMSG.Name = "comboBoxMSG";
            this.comboBoxMSG.Size = new System.Drawing.Size(271, 25);
            this.comboBoxMSG.TabIndex = 28;
            // 
            // labelMSG
            // 
            this.labelMSG.AutoSize = true;
            this.labelMSG.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelMSG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMSG.Location = new System.Drawing.Point(529, 125);
            this.labelMSG.Margin = new System.Windows.Forms.Padding(50, 5, 3, 0);
            this.labelMSG.Name = "labelMSG";
            this.labelMSG.Size = new System.Drawing.Size(40, 17);
            this.labelMSG.TabIndex = 29;
            this.labelMSG.Text = "MSG";
            this.labelMSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label2.Location = new System.Drawing.Point(482, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "APU Work Time per flight";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(482, 186);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "APU Util.(FH/APUFH)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxApuWorktime
            // 
            this.comboBoxApuWorktime.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxApuWorktime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxApuWorktime.FormattingEnabled = true;
            this.comboBoxApuWorktime.Location = new System.Drawing.Point(672, 153);
            this.comboBoxApuWorktime.Name = "comboBoxApuWorktime";
            this.comboBoxApuWorktime.Size = new System.Drawing.Size(271, 25);
            this.comboBoxApuWorktime.TabIndex = 31;
            this.comboBoxApuWorktime.Visible = false;
            this.comboBoxApuWorktime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxApuWorktime_KeyPress);
            // 
            // numericUpDownAPU
            // 
            this.numericUpDownAPU.DecimalPlaces = 2;
            this.numericUpDownAPU.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownAPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownAPU.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownAPU.Location = new System.Drawing.Point(672, 184);
            this.numericUpDownAPU.Name = "numericUpDownAPU";
            this.numericUpDownAPU.Size = new System.Drawing.Size(91, 25);
            this.numericUpDownAPU.TabIndex = 33;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(215, 291);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(176, 25);
            this.dateTimePickerStart.TabIndex = 24;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.DateTimePickerStartValueChanged);
            // 
            // dateTimePickerTD
            // 
            this.dateTimePickerTD.Enabled = false;
            this.dateTimePickerTD.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dateTimePickerTD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerTD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTD.Location = new System.Drawing.Point(215, 323);
            this.dateTimePickerTD.Name = "dateTimePickerTD";
            this.dateTimePickerTD.Size = new System.Drawing.Size(176, 25);
            this.dateTimePickerTD.TabIndex = 26;
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
            this.lifelengthViewerStart.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerStart.HeaderCalendar = "Calendar";
            this.lifelengthViewerStart.HeaderCycles = "Cycles";
            this.lifelengthViewerStart.HeaderFormattedCalendar = "Calendar";
            this.lifelengthViewerStart.HeaderHours = "Hours";
            this.lifelengthViewerStart.HoursApplicable = false;
            this.lifelengthViewerStart.LeftHeader = "";
            this.lifelengthViewerStart.Location = new System.Drawing.Point(428, 267);
            this.lifelengthViewerStart.Margin = new System.Windows.Forms.Padding(4);
            this.lifelengthViewerStart.Modified = false;
            this.lifelengthViewerStart.Name = "lifelengthViewerStart";
            this.lifelengthViewerStart.ReadOnly = false;
            this.lifelengthViewerStart.ShowCalendar = false;
            this.lifelengthViewerStart.ShowFormattedCalendar = true;
            this.lifelengthViewerStart.ShowLeftHeader = false;
            this.lifelengthViewerStart.ShowMinutes = true;
            this.lifelengthViewerStart.Size = new System.Drawing.Size(276, 51);
            this.lifelengthViewerStart.SystemCalculated = true;
            this.lifelengthViewerStart.TabIndex = 15;
            // 
            // lifelengthViewerToday
            // 
            this.lifelengthViewerToday.AutoSize = true;
            this.lifelengthViewerToday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewerToday.CalendarApplicable = false;
            this.lifelengthViewerToday.CyclesApplicable = false;
            this.lifelengthViewerToday.Enabled = false;
            this.lifelengthViewerToday.EnabledCalendar = true;
            this.lifelengthViewerToday.EnabledCycle = true;
            this.lifelengthViewerToday.EnabledHours = true;
            this.lifelengthViewerToday.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewerToday.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewerToday.HeaderCalendar = "Calendar";
            this.lifelengthViewerToday.HeaderCycles = "Cycles";
            this.lifelengthViewerToday.HeaderFormattedCalendar = "Calendar";
            this.lifelengthViewerToday.HeaderHours = "Hours";
            this.lifelengthViewerToday.HoursApplicable = false;
            this.lifelengthViewerToday.LeftHeader = "";
            this.lifelengthViewerToday.Location = new System.Drawing.Point(428, 317);
            this.lifelengthViewerToday.Margin = new System.Windows.Forms.Padding(4);
            this.lifelengthViewerToday.Modified = false;
            this.lifelengthViewerToday.Name = "lifelengthViewerToday";
            this.lifelengthViewerToday.ReadOnly = false;
            this.lifelengthViewerToday.ShowCalendar = false;
            this.lifelengthViewerToday.ShowFormattedCalendar = true;
            this.lifelengthViewerToday.ShowHeaders = false;
            this.lifelengthViewerToday.ShowLeftHeader = false;
            this.lifelengthViewerToday.ShowMinutes = true;
            this.lifelengthViewerToday.Size = new System.Drawing.Size(276, 34);
            this.lifelengthViewerToday.SystemCalculated = true;
            this.lifelengthViewerToday.TabIndex = 25;
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Location = new System.Drawing.Point(672, 33);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(271, 25);
            this.comboBoxOperator.TabIndex = 34;
            // 
            // CAAAircraftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lifelengthViewerStart);
            this.Controls.Add(label1);
            this.Controls.Add(this.dateTimePickerTD);
            this.Controls.Add(this.lifelengthViewerToday);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.labelManufactureDate);
            this.Controls.Add(this.dateTimePickerManufactureDate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(labelAircraftTSNCSN);
            this.Name = "CAAAircraftControl";
            this.Size = new System.Drawing.Size(962, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAPU)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}


		private Label labelAircraftModel;
		private Label labelAircraftTypeCertificateNo;
		private Label labelManufactureDate;
		private Label labelSerialNumber;
		private Label labelVariableNumber;
		private Label labelLineNumber;
		private Label labelRegistrationNumber;
		private Label labelOwner;
		private Label labelOperator;
		private TextBox textBoxAircraftTypeCertificateNo;
		private TextBox textBoxSerialNumber;
		private TextBox textBoxVariableNumber;
		private TextBox textBoxLineNumber;
		private TextBox textBoxRegistrationNumber;
		private TextBox textBoxOwner;
		private DateTimePicker dateTimePickerManufactureDate;
        #endregion
		private TableLayoutPanel tableLayoutPanel1;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerStart;
		private DateTimePicker dateTimePickerStart;
		private DateTimePicker dateTimePickerTD;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer lifelengthViewerToday;
		private UIControls.Auxiliary.LookupCombobox dictionaryComboBoxAircraftModel;
		private ComboBox comboBoxMSG;
		private Label labelMSG;
		private ComboBox comboBoxApuWorktime;
		private Label label2;
		private Label label3;
		private NumericUpDown numericUpDownAPU;
        private ComboBox comboBoxOperator;
    }
}
