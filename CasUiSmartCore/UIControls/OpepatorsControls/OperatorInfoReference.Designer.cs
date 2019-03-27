using System;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;

namespace CAS.UI.UIControls.OpepatorsControls
{
	partial class OperatorInfoReference
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatorInfoReference));
			this.labelName = new System.Windows.Forms.Label();
			this.labelNameValue = new System.Windows.Forms.Label();
			this.labelIcao = new System.Windows.Forms.Label();
			this.labelIcaoValue = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.labelAddressValue = new System.Windows.Forms.Label();
			this.labelPhone = new System.Windows.Forms.Label();
			this.labelPhoneValue = new System.Windows.Forms.Label();
			this.labelFax = new System.Windows.Forms.Label();
			this.labelFaxValue = new System.Windows.Forms.Label();
			this.labelEmail = new System.Windows.Forms.Label();
			this.labelEmailValue = new System.Windows.Forms.LinkLabel();
			this.operatorInfoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelEditOperatorInfo = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			this.linkLabelEditPassword = new LinkLabel();
			this.operatorInfoTableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.operatorInfoTableLayoutPanel.AutoSize = true;
			this.operatorInfoTableLayoutPanel.ColumnCount = 2;
			this.operatorInfoTableLayoutPanel.RowCount = 8;
			this.operatorInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.operatorInfoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelName, 0, 0);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelNameValue, 1, 0);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelIcao, 0, 1);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelIcaoValue, 1, 1);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelAddress, 0, 2);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelAddressValue, 1, 2);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelPhone, 0, 3);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelPhoneValue, 1, 3);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelFax, 0, 4);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelFaxValue, 1, 4);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelEmail, 0, 5);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.labelEmailValue, 1, 5);
			this.operatorInfoTableLayoutPanel.Controls.Add(this.linkLabelEditOperatorInfo, 0, 6);
			this.operatorInfoTableLayoutPanel.SetColumnSpan(this.linkLabelEditOperatorInfo, 2);
            this.operatorInfoTableLayoutPanel.Controls.Add(this.linkLabelEditPassword, 0, 7);
            this.operatorInfoTableLayoutPanel.SetColumnSpan(this.linkLabelEditPassword, 2);
            this.operatorInfoTableLayoutPanel.Location = new System.Drawing.Point(3, 43);
			this.operatorInfoTableLayoutPanel.Name = "operatorInfoTableLayoutPanel";
			this.operatorInfoTableLayoutPanel.Dock = DockStyle.Fill;
			this.operatorInfoTableLayoutPanel.Size = new System.Drawing.Size(336, 14);
			this.operatorInfoTableLayoutPanel.TabIndex = 3;
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(51, 17);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name";
			// 
			// labelNameValue
			// 
			this.labelNameValue.AutoSize = true;
			this.labelNameValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNameValue.MaximumSize = new System.Drawing.Size(250, 100);
			this.labelNameValue.MinimumSize = new System.Drawing.Size(10, 20);
			this.labelNameValue.Name = "labelNameValue";
			this.labelNameValue.Size = new System.Drawing.Size(85, 20);
			this.labelNameValue.TabIndex = 1;
			this.labelNameValue.Text = "NameValue";
			// 
			// labelIcao
			// 
			this.labelIcao.AutoSize = true;
			this.labelIcao.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelIcao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIcao.Name = "labelIcao";
			this.labelIcao.Size = new System.Drawing.Size(92, 17);
			this.labelIcao.TabIndex = 2;
			this.labelIcao.Text = "ICAO code";
			// 
			// labelIcaoValue
			// 
			this.labelIcaoValue.AutoSize = true;
			this.labelIcaoValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelIcaoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIcaoValue.MaximumSize = new System.Drawing.Size(250, 20);
			this.labelIcaoValue.MinimumSize = new System.Drawing.Size(10, 20);
			this.labelIcaoValue.Name = "labelIcaoValue";
			this.labelIcaoValue.Size = new System.Drawing.Size(82, 20);
			this.labelIcaoValue.TabIndex = 3;
			this.labelIcaoValue.Text = "CodeValue";
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(71, 17);
			this.labelAddress.TabIndex = 4;
			this.labelAddress.Text = "Address";
			// 
			// labelAddressValue
			// 
			this.labelAddressValue.AutoSize = true;
			this.labelAddressValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAddressValue.MaximumSize = new System.Drawing.Size(250, 200);
			this.labelAddressValue.Name = "labelAddressValue";
			this.labelAddressValue.Size = new System.Drawing.Size(97, 17);
			this.labelAddressValue.TabIndex = 5;
			this.labelAddressValue.Text = "labelAddress";
			// 
			// labelPhone
			// 
			this.labelPhone.AutoSize = true;
			this.labelPhone.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhone.Name = "labelPhone";
			this.labelPhone.Size = new System.Drawing.Size(57, 17);
			this.labelPhone.TabIndex = 6;
			this.labelPhone.Text = "Phone";
			// 
			// labelPhoneValue
			// 
			this.labelPhoneValue.AutoSize = true;
			this.labelPhoneValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPhoneValue.MaximumSize = new System.Drawing.Size(250, 20);
			this.labelPhoneValue.Name = "labelPhoneValue";
			this.labelPhoneValue.Size = new System.Drawing.Size(89, 17);
			this.labelPhoneValue.TabIndex = 7;
			this.labelPhoneValue.Text = "PhoneValue";
			// 
			// labelFax
			// 
			this.labelFax.AutoSize = true;
			this.labelFax.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelFax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFax.Name = "labelFax";
			this.labelFax.Size = new System.Drawing.Size(35, 17);
			this.labelFax.TabIndex = 8;
			this.labelFax.Text = "Fax";
			// 
			// labelFaxValue
			// 
			this.labelFaxValue.AutoSize = true;
			this.labelFaxValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFaxValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFaxValue.MaximumSize = new System.Drawing.Size(250, 20);
			this.labelFaxValue.Name = "labelFaxValue";
			this.labelFaxValue.Size = new System.Drawing.Size(71, 17);
			this.labelFaxValue.TabIndex = 9;
			this.labelFaxValue.Text = "FaxValue";
			// 
			// labelEmail
			// 
			this.labelEmail.AutoSize = true;
			this.labelEmail.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelEmail.Name = "labelEmail";
			this.labelEmail.Size = new System.Drawing.Size(49, 17);
			this.labelEmail.TabIndex = 10;
			this.labelEmail.Text = "Email";
			// 
			// labelEmailValue
			// 
			this.labelEmailValue.AutoSize = true;
			this.labelEmailValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelEmailValue.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelEmailValue.MaximumSize = new System.Drawing.Size(250, 100);
			this.labelEmailValue.Name = "labelEmailValue";
			this.labelEmailValue.Size = new System.Drawing.Size(82, 17);
			this.labelEmailValue.TabIndex = 11;
			this.labelEmailValue.TabStop = true;
			this.labelEmailValue.Text = "EmailValue";
			this.labelEmailValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelEmailValueLinkClicked);
			// 
			// linkLabelEditOperatorInfo
			// 
			this.linkLabelEditOperatorInfo.AutoSize = true;
			this.linkLabelEditOperatorInfo.Displayer = null;
			this.linkLabelEditOperatorInfo.DisplayerText = null;
			this.linkLabelEditOperatorInfo.Entity = null;
			this.linkLabelEditOperatorInfo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditOperatorInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditOperatorInfo.Name = "linkLabelEditOperatorInfo";
			this.linkLabelEditOperatorInfo.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.linkLabelEditOperatorInfo.Size = new System.Drawing.Size(144, 17);
			this.linkLabelEditOperatorInfo.TabIndex = 12;
			this.linkLabelEditOperatorInfo.TabStop = true;
			this.linkLabelEditOperatorInfo.Text = "Edit operator\'s info";
			this.linkLabelEditOperatorInfo.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkLabelEditOperatorInfoDisplayerRequested);
            // 
            // linkLabelEditPassword
            // 
            this.linkLabelEditPassword.AutoSize = true;
            this.linkLabelEditPassword.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkLabelEditPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelEditPassword.Location = new System.Drawing.Point(0, 0);
            this.linkLabelEditPassword.Name = "linkLabelEditPassword";
            this.linkLabelEditPassword.Size = new System.Drawing.Size(144, 17);
            this.linkLabelEditPassword.TabIndex = 12;
            this.linkLabelEditPassword.TabStop = true;
            this.linkLabelEditPassword.Text = "Edit password";
			this.linkLabelEditPassword.Click += LinkLabelEditPassword_Click;  
            // 
            // OperatorInfoReference
            //
            this.MainControl = operatorInfoTableLayoutPanel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Caption = "General information";
			this.Name = "OperatorInfoReference";
			this.Size = new System.Drawing.Size(342, 60);
			this.UpperLeftIcon = ((System.Drawing.Image)(resources.GetObject("$this.UpperLeftIcon")));
			this.operatorInfoTableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		#endregion

		private System.Windows.Forms.Label labelAddress;
		private System.Windows.Forms.Label labelAddressValue;
		private System.Windows.Forms.Label labelFax;
		private System.Windows.Forms.Label labelFaxValue;
		private System.Windows.Forms.Label labelIcao;
		private System.Windows.Forms.Label labelIcaoValue;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelNameValue;
		private System.Windows.Forms.Label labelPhone;
		private System.Windows.Forms.Label labelPhoneValue;
		private System.Windows.Forms.Label labelEmail;
		private System.Windows.Forms.LinkLabel labelEmailValue;
		private TableLayoutPanel operatorInfoTableLayoutPanel;
		private CAS.UI.Management.Dispatchering.ReferenceLinkLabel linkLabelEditOperatorInfo;
		private LinkLabel linkLabelEditPassword;

	}
}
