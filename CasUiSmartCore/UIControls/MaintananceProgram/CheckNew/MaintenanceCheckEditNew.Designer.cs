using System.Windows.Forms;
using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
	partial class MaintenanceCheckEditNew
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label1;
			this._lifelengthViewerInterval = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this._textBoxName = new System.Windows.Forms.TextBox();
			this._buttonCancel = new System.Windows.Forms.Button();
			this._buttonOk = new System.Windows.Forms.Button();
			this.comboBoxCheckType = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label4.Location = new System.Drawing.Point(19, 70);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(59, 18);
			label4.TabIndex = 11;
			label4.Text = "Name:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			label1.Location = new System.Drawing.Point(19, 99);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(101, 18);
			label1.TabIndex = 12;
			label1.Text = "Check Type:";
			// 
			// _lifelengthViewerInterval
			// 
			this._lifelengthViewerInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._lifelengthViewerInterval.AutoSize = true;
			this._lifelengthViewerInterval.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._lifelengthViewerInterval.CalendarApplicable = false;
			this._lifelengthViewerInterval.CyclesApplicable = false;
			this._lifelengthViewerInterval.EnabledCalendar = true;
			this._lifelengthViewerInterval.EnabledCycle = true;
			this._lifelengthViewerInterval.EnabledHours = true;
			this._lifelengthViewerInterval.FieldsBackColor = System.Drawing.SystemColors.Window;
			this._lifelengthViewerInterval.ForeColor = System.Drawing.Color.DimGray;
			this._lifelengthViewerInterval.HeaderCalendar = "Calendar";
			this._lifelengthViewerInterval.HeaderCycles = "Cycles";
			this._lifelengthViewerInterval.HeaderFormattedCalendar = "Calendar";
			this._lifelengthViewerInterval.HeaderHours = "Hours";
			this._lifelengthViewerInterval.HoursApplicable = false;
			this._lifelengthViewerInterval.LeftHeader = "Interval";
			this._lifelengthViewerInterval.Location = new System.Drawing.Point(22, 121);
			this._lifelengthViewerInterval.Margin = new System.Windows.Forms.Padding(2);
			this._lifelengthViewerInterval.Modified = false;
			this._lifelengthViewerInterval.Name = "_lifelengthViewerInterval";
			this._lifelengthViewerInterval.ReadOnly = false;
			this._lifelengthViewerInterval.ShowCalendar = true;
			this._lifelengthViewerInterval.ShowFormattedCalendar = false;
			this._lifelengthViewerInterval.ShowMinutes = true;
			this._lifelengthViewerInterval.Size = new System.Drawing.Size(419, 52);
			this._lifelengthViewerInterval.SystemCalculated = true;
			this._lifelengthViewerInterval.TabIndex = 5;
			// 
			// _textBoxName
			// 
			this._textBoxName.Location = new System.Drawing.Point(155, 70);
			this._textBoxName.Name = "_textBoxName";
			this._textBoxName.Size = new System.Drawing.Size(206, 20);
			this._textBoxName.TabIndex = 0;
			// 
			// _buttonCancel
			// 
			this._buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this._buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._buttonCancel.Location = new System.Drawing.Point(396, 182);
			this._buttonCancel.Name = "_buttonCancel";
			this._buttonCancel.Size = new System.Drawing.Size(75, 33);
			this._buttonCancel.TabIndex = 8;
			this._buttonCancel.Text = "Cancel";
			this._buttonCancel.UseVisualStyleBackColor = true;
			this._buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// _buttonOk
			// 
			this._buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._buttonOk.DialogResult = DialogResult.OK;
			this._buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this._buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this._buttonOk.Location = new System.Drawing.Point(315, 182);
			this._buttonOk.Name = "_buttonOk";
			this._buttonOk.Size = new System.Drawing.Size(75, 33);
			this._buttonOk.TabIndex = 7;
			this._buttonOk.Text = "Ok";
			this._buttonOk.UseVisualStyleBackColor = true;
			this._buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// comboBoxCheckType
			// 
			this.comboBoxCheckType.FormattingEnabled = true;
			this.comboBoxCheckType.Location = new System.Drawing.Point(155, 95);
			this.comboBoxCheckType.Name = "comboBoxCheckType";
			this.comboBoxCheckType.Size = new System.Drawing.Size(206, 21);
			this.comboBoxCheckType.TabIndex = 13;
			// 
			// MaintenanceCheckEditNew
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 226);
			this.Controls.Add(this._lifelengthViewerInterval);
			this.Controls.Add(this.comboBoxCheckType);
			this.Controls.Add(this._buttonOk);
			this.Controls.Add(label1);
			this.Controls.Add(this._buttonCancel);
			this.Controls.Add(label4);
			this.Controls.Add(this._textBoxName);
			this.Name = "MaintenanceCheckEditNew";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Maintenance Check Edit New";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox _textBoxName;
		private System.Windows.Forms.Button _buttonCancel;
		private System.Windows.Forms.Button _buttonOk;
		private CAS.UI.UIControls.Auxiliary.LifelengthViewer _lifelengthViewerInterval;
		private System.Windows.Forms.ComboBox comboBoxCheckType;
	}
}