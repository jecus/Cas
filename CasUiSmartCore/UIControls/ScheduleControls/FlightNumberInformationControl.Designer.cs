using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.ScheduleControls
{
	partial class FlightNumberInformationControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlightNumberInformationControl));
			this.labelAircraftCode = new System.Windows.Forms.Label();
			this.comboBoxAircraftCode = new System.Windows.Forms.ComboBox();
			this.labelFlightCategory = new System.Windows.Forms.Label();
			this.comboBoxFlightCategory = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxFlightType = new System.Windows.Forms.ComboBox();
			this.labelStationFrom = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelTo = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.textBoxRemarks = new System.Windows.Forms.TextBox();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.textBoxHiddenRemarks = new System.Windows.Forms.TextBox();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this._flightNumberPeriodListControl = new CAS.UI.UIControls.ScheduleControls.FlightNumberPeriodListControl();
			this.dictionaryComboBoxFlightNo = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.dictComboBoxStationFrom = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.dictComboBoxStationTo = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.SuspendLayout();
			// 
			// labelAircraftCode
			// 
			this.labelAircraftCode.AutoSize = true;
			this.labelAircraftCode.Location = new System.Drawing.Point(3, 80);
			this.labelAircraftCode.Name = "labelAircraftCode";
			this.labelAircraftCode.Size = new System.Drawing.Size(59, 13);
			this.labelAircraftCode.TabIndex = 42;
			this.labelAircraftCode.Text = "Aircr. Code";
			// 
			// comboBoxAircraftCode
			// 
			this.comboBoxAircraftCode.FormattingEnabled = true;
			this.comboBoxAircraftCode.Location = new System.Drawing.Point(70, 77);
			this.comboBoxAircraftCode.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.comboBoxAircraftCode.Name = "comboBoxAircraftCode";
			this.comboBoxAircraftCode.Size = new System.Drawing.Size(190, 21);
			this.comboBoxAircraftCode.TabIndex = 4;
			this.comboBoxAircraftCode.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelFlightCategory
			// 
			this.labelFlightCategory.AutoSize = true;
			this.labelFlightCategory.Location = new System.Drawing.Point(3, 57);
			this.labelFlightCategory.Name = "labelFlightCategory";
			this.labelFlightCategory.Size = new System.Drawing.Size(54, 13);
			this.labelFlightCategory.TabIndex = 38;
			this.labelFlightCategory.Text = "Flight Cat.";
			// 
			// comboBoxFlightCategory
			// 
			this.comboBoxFlightCategory.FormattingEnabled = true;
			this.comboBoxFlightCategory.Location = new System.Drawing.Point(70, 53);
			this.comboBoxFlightCategory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.comboBoxFlightCategory.Name = "comboBoxFlightCategory";
			this.comboBoxFlightCategory.Size = new System.Drawing.Size(190, 21);
			this.comboBoxFlightCategory.TabIndex = 3;
			this.comboBoxFlightCategory.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Flight Type";
			// 
			// comboBoxFlightType
			// 
			this.comboBoxFlightType.FormattingEnabled = true;
			this.comboBoxFlightType.Location = new System.Drawing.Point(70, 29);
			this.comboBoxFlightType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.comboBoxFlightType.Name = "comboBoxFlightType";
			this.comboBoxFlightType.Size = new System.Drawing.Size(190, 21);
			this.comboBoxFlightType.TabIndex = 2;
			this.comboBoxFlightType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelStationFrom
			// 
			this.labelStationFrom.AutoSize = true;
			this.labelStationFrom.Location = new System.Drawing.Point(3, 104);
			this.labelStationFrom.Name = "labelStationFrom";
			this.labelStationFrom.Size = new System.Drawing.Size(33, 13);
			this.labelStationFrom.TabIndex = 29;
			this.labelStationFrom.Text = "From:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Flight No";
			// 
			// labelTo
			// 
			this.labelTo.AutoSize = true;
			this.labelTo.Location = new System.Drawing.Point(3, 128);
			this.labelTo.Name = "labelTo";
			this.labelTo.Size = new System.Drawing.Size(23, 13);
			this.labelTo.TabIndex = 77;
			this.labelTo.Text = "To:";
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(3, 398);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(63, 13);
			this.labelDescription.TabIndex = 119;
			this.labelDescription.Text = "Description:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(70, 395);
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxDescription.MaxLength = 1024;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(250, 68);
			this.textBoxDescription.TabIndex = 120;
			this.textBoxDescription.Text = "Description";
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Location = new System.Drawing.Point(326, 397);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(52, 13);
			this.labelRemarks.TabIndex = 121;
			this.labelRemarks.Text = "Remarks:";
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Location = new System.Drawing.Point(384, 395);
			this.textBoxRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxRemarks.MaxLength = 1024;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.Size = new System.Drawing.Size(250, 68);
			this.textBoxRemarks.TabIndex = 122;
			this.textBoxRemarks.Text = "Remarks";
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.AutoSize = true;
			this.labelHiddenRemarks.Location = new System.Drawing.Point(640, 400);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(84, 13);
			this.labelHiddenRemarks.TabIndex = 123;
			this.labelHiddenRemarks.Text = "Hidden remarks:";
			// 
			// textBoxHiddenRemarks
			// 
			this.textBoxHiddenRemarks.Location = new System.Drawing.Point(730, 397);
			this.textBoxHiddenRemarks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.textBoxHiddenRemarks.MaxLength = 1024;
			this.textBoxHiddenRemarks.Multiline = true;
			this.textBoxHiddenRemarks.Name = "textBoxHiddenRemarks";
			this.textBoxHiddenRemarks.Size = new System.Drawing.Size(250, 66);
			this.textBoxHiddenRemarks.TabIndex = 124;
			this.textBoxHiddenRemarks.Text = "Hidden Remarks";
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(0, 385);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Horizontal;
			this.delimiter1.Size = new System.Drawing.Size(1150, 1);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 126;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(264, 0);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 386);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 82;
			// 
			// _flightNumberPeriodListControl
			// 
			this._flightNumberPeriodListControl.AutoScroll = true;
			this._flightNumberPeriodListControl.AutoSize = true;
			this._flightNumberPeriodListControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._flightNumberPeriodListControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this._flightNumberPeriodListControl.Location = new System.Drawing.Point(271, 0);
			this._flightNumberPeriodListControl.MaximumSize = new System.Drawing.Size(1200, 150);
			this._flightNumberPeriodListControl.MinimumSize = new System.Drawing.Size(880, 375);
			this._flightNumberPeriodListControl.Name = "_flightNumberPeriodListControl";
			this._flightNumberPeriodListControl.Size = new System.Drawing.Size(880, 375);
			this._flightNumberPeriodListControl.TabIndex = 24;
			// 
			// dictionaryComboBoxFlightNo
			// 
			this.dictionaryComboBoxFlightNo.Displayer = null;
			this.dictionaryComboBoxFlightNo.DisplayerText = null;
			this.dictionaryComboBoxFlightNo.Entity = null;
			this.dictionaryComboBoxFlightNo.Location = new System.Drawing.Point(70, 4);
			this.dictionaryComboBoxFlightNo.Name = "dictionaryComboBoxFlightNo";
			this.dictionaryComboBoxFlightNo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxFlightNo.Size = new System.Drawing.Size(192, 21);
			this.dictionaryComboBoxFlightNo.TabIndex = 130;
			this.dictionaryComboBoxFlightNo.Type = null;
			this.dictionaryComboBoxFlightNo.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictComboBoxStationFrom
			// 
			this.dictComboBoxStationFrom.Displayer = null;
			this.dictComboBoxStationFrom.DisplayerText = null;
			this.dictComboBoxStationFrom.Entity = null;
			this.dictComboBoxStationFrom.Location = new System.Drawing.Point(70, 101);
			this.dictComboBoxStationFrom.Name = "dictComboBoxStationFrom";
			this.dictComboBoxStationFrom.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictComboBoxStationFrom.Size = new System.Drawing.Size(192, 21);
			this.dictComboBoxStationFrom.TabIndex = 131;
			this.dictComboBoxStationFrom.Type = null;
			this.dictComboBoxStationFrom.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// dictComboBoxStationTo
			// 
			this.dictComboBoxStationTo.Displayer = null;
			this.dictComboBoxStationTo.DisplayerText = null;
			this.dictComboBoxStationTo.Entity = null;
			this.dictComboBoxStationTo.Location = new System.Drawing.Point(70, 125);
			this.dictComboBoxStationTo.Name = "dictComboBoxStationTo";
			this.dictComboBoxStationTo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictComboBoxStationTo.Size = new System.Drawing.Size(192, 21);
			this.dictComboBoxStationTo.TabIndex = 132;
			this.dictComboBoxStationTo.Type = null;
			this.dictComboBoxStationTo.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// FlightNumberInformationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.dictComboBoxStationTo);
			this.Controls.Add(this.dictComboBoxStationFrom);
			this.Controls.Add(this.dictionaryComboBoxFlightNo);
			this.Controls.Add(this._flightNumberPeriodListControl);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.textBoxHiddenRemarks);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.labelTo);
			this.Controls.Add(this.labelAircraftCode);
			this.Controls.Add(this.comboBoxAircraftCode);
			this.Controls.Add(this.labelFlightCategory);
			this.Controls.Add(this.comboBoxFlightCategory);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBoxFlightType);
			this.Controls.Add(this.labelStationFrom);
			this.Controls.Add(this.label3);
			this.Name = "FlightNumberInformationControl";
			this.Size = new System.Drawing.Size(1154, 463);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label labelAircraftCode;
		private ComboBox comboBoxAircraftCode;
		private Label labelFlightCategory;
		private ComboBox comboBoxFlightCategory;
		private Label label2;
		private ComboBox comboBoxFlightType;
		private Label labelStationFrom;
		private Label label3;
		private Label labelTo;
		private Delimiter delimiter2;
		private Label labelDescription;
		private TextBox textBoxDescription;
		private Label labelRemarks;
		private TextBox textBoxRemarks;
		private Label labelHiddenRemarks;
		private TextBox textBoxHiddenRemarks;
		private Delimiter delimiter1;
		private FlightNumberPeriodListControl _flightNumberPeriodListControl;
		private LookupCombobox dictionaryComboBoxFlightNo;
		private LookupCombobox dictComboBoxStationFrom;
		private LookupCombobox dictComboBoxStationTo;
	}
}
