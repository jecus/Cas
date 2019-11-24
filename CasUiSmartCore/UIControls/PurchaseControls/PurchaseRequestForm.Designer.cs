using MetroFramework.Controls;

namespace CAS.UI.UIControls.PurchaseControls
{
	partial class PurchaseRequestForm
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
			this.textBoxAuthor = new MetroFramework.Controls.MetroTextBox();
			this.labelPublishDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerPublishDate = new System.Windows.Forms.DateTimePicker();
			this.labelOpeningDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerOpeningDate = new System.Windows.Forms.DateTimePicker();
			this.labelClosingDate = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerClosingDate = new System.Windows.Forms.DateTimePicker();
			this.labelAuthor = new MetroFramework.Controls.MetroLabel();
			this.labelDescription = new MetroFramework.Controls.MetroLabel();
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelTitle = new MetroFramework.Controls.MetroLabel();
			this.textBoxTitle = new MetroFramework.Controls.MetroTextBox();
			this.label1 = new MetroFramework.Controls.MetroLabel();
			this.textBox_Remarks = new MetroFramework.Controls.MetroTextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panelMain = new System.Windows.Forms.Panel();
			this.flowLayoutPanelFileControls = new System.Windows.Forms.FlowLayoutPanel();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelMain.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.flowLayoutPanelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxAuthor
			// 
			// 
			// 
			// 
			this.textBoxAuthor.CustomButton.Image = null;
			this.textBoxAuthor.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxAuthor.CustomButton.Name = "";
			this.textBoxAuthor.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxAuthor.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxAuthor.CustomButton.TabIndex = 1;
			this.textBoxAuthor.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxAuthor.CustomButton.UseSelectable = true;
			this.textBoxAuthor.CustomButton.Visible = false;
			this.textBoxAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAuthor.Lines = new string[0];
			this.textBoxAuthor.Location = new System.Drawing.Point(127, 100);
			this.textBoxAuthor.MaxLength = 32767;
			this.textBoxAuthor.Name = "textBoxAuthor";
			this.textBoxAuthor.PasswordChar = '\0';
			this.textBoxAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxAuthor.SelectedText = "";
			this.textBoxAuthor.SelectionLength = 0;
			this.textBoxAuthor.SelectionStart = 0;
			this.textBoxAuthor.ShortcutsEnabled = true;
			this.textBoxAuthor.Size = new System.Drawing.Size(252, 22);
			this.textBoxAuthor.TabIndex = 117;
			this.textBoxAuthor.UseSelectable = true;
			this.textBoxAuthor.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxAuthor.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelPublishDate
			// 
			this.labelPublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPublishDate.Location = new System.Drawing.Point(3, 159);
			this.labelPublishDate.Name = "labelPublishDate";
			this.labelPublishDate.Size = new System.Drawing.Size(118, 20);
			this.labelPublishDate.TabIndex = 116;
			this.labelPublishDate.Text = "Publishing Date:";
			this.labelPublishDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerPublishDate
			// 
			this.dateTimePickerPublishDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerPublishDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerPublishDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerPublishDate.Location = new System.Drawing.Point(127, 156);
			this.dateTimePickerPublishDate.Name = "dateTimePickerPublishDate";
			this.dateTimePickerPublishDate.Size = new System.Drawing.Size(252, 22);
			this.dateTimePickerPublishDate.TabIndex = 115;
			this.dateTimePickerPublishDate.ValueChanged += new System.EventHandler(this.DateTimePickerPublishDateValueChanged);
			// 
			// labelOpeningDate
			// 
			this.labelOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOpeningDate.Location = new System.Drawing.Point(3, 131);
			this.labelOpeningDate.Name = "labelOpeningDate";
			this.labelOpeningDate.Size = new System.Drawing.Size(118, 20);
			this.labelOpeningDate.TabIndex = 114;
			this.labelOpeningDate.Text = "Opening Date:";
			this.labelOpeningDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerOpeningDate
			// 
			this.dateTimePickerOpeningDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerOpeningDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerOpeningDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerOpeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerOpeningDate.Location = new System.Drawing.Point(127, 128);
			this.dateTimePickerOpeningDate.Name = "dateTimePickerOpeningDate";
			this.dateTimePickerOpeningDate.Size = new System.Drawing.Size(252, 22);
			this.dateTimePickerOpeningDate.TabIndex = 113;
			this.dateTimePickerOpeningDate.ValueChanged += new System.EventHandler(this.DateTimePickerOpeningDateValueChanged);
			// 
			// labelClosingDate
			// 
			this.labelClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClosingDate.Location = new System.Drawing.Point(3, 187);
			this.labelClosingDate.Name = "labelClosingDate";
			this.labelClosingDate.Size = new System.Drawing.Size(118, 20);
			this.labelClosingDate.TabIndex = 112;
			this.labelClosingDate.Text = "Closing Date:";
			this.labelClosingDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerClosingDate
			// 
			this.dateTimePickerClosingDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClosingDate.Font = new System.Drawing.Font("Verdana", 9F);
			this.dateTimePickerClosingDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerClosingDate.Location = new System.Drawing.Point(127, 184);
			this.dateTimePickerClosingDate.Name = "dateTimePickerClosingDate";
			this.dateTimePickerClosingDate.Size = new System.Drawing.Size(252, 22);
			this.dateTimePickerClosingDate.TabIndex = 111;
			this.dateTimePickerClosingDate.ValueChanged += new System.EventHandler(this.DateTimePickerClosingDateValueChanged);
			// 
			// labelAuthor
			// 
			this.labelAuthor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAuthor.Location = new System.Drawing.Point(3, 102);
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Size = new System.Drawing.Size(118, 20);
			this.labelAuthor.TabIndex = 110;
			this.labelAuthor.Text = "Author:";
			this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(3, 30);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(118, 20);
			this.labelDescription.TabIndex = 109;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxDescription
			// 
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(188, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(61, 61);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(127, 28);
			this.textBoxDescription.MaxLength = 32767;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(252, 66);
			this.textBoxDescription.TabIndex = 108;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelTitle
			// 
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTitle.Location = new System.Drawing.Point(3, 1);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(118, 20);
			this.labelTitle.TabIndex = 107;
			this.labelTitle.Text = "Title:";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxTitle
			// 
			// 
			// 
			// 
			this.textBoxTitle.CustomButton.Image = null;
			this.textBoxTitle.CustomButton.Location = new System.Drawing.Point(232, 2);
			this.textBoxTitle.CustomButton.Name = "";
			this.textBoxTitle.CustomButton.Size = new System.Drawing.Size(17, 17);
			this.textBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxTitle.CustomButton.TabIndex = 1;
			this.textBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxTitle.CustomButton.UseSelectable = true;
			this.textBoxTitle.CustomButton.Visible = false;
			this.textBoxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxTitle.Lines = new string[0];
			this.textBoxTitle.Location = new System.Drawing.Point(127, 2);
			this.textBoxTitle.MaxLength = 32767;
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.PasswordChar = '\0';
			this.textBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxTitle.SelectedText = "";
			this.textBoxTitle.SelectionLength = 0;
			this.textBoxTitle.SelectionStart = 0;
			this.textBoxTitle.ShortcutsEnabled = true;
			this.textBoxTitle.Size = new System.Drawing.Size(252, 22);
			this.textBoxTitle.TabIndex = 106;
			this.textBoxTitle.UseSelectable = true;
			this.textBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(3, 212);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(118, 20);
			this.label1.TabIndex = 105;
			this.label1.Text = "Remarks:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox_Remarks
			// 
			// 
			// 
			// 
			this.textBox_Remarks.CustomButton.Image = null;
			this.textBox_Remarks.CustomButton.Location = new System.Drawing.Point(176, 1);
			this.textBox_Remarks.CustomButton.Name = "";
			this.textBox_Remarks.CustomButton.Size = new System.Drawing.Size(75, 75);
			this.textBox_Remarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBox_Remarks.CustomButton.TabIndex = 1;
			this.textBox_Remarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBox_Remarks.CustomButton.UseSelectable = true;
			this.textBox_Remarks.CustomButton.Visible = false;
			this.textBox_Remarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBox_Remarks.Lines = new string[0];
			this.textBox_Remarks.Location = new System.Drawing.Point(127, 212);
			this.textBox_Remarks.MaxLength = 32767;
			this.textBox_Remarks.Multiline = true;
			this.textBox_Remarks.Name = "textBox_Remarks";
			this.textBox_Remarks.PasswordChar = '\0';
			this.textBox_Remarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBox_Remarks.SelectedText = "";
			this.textBox_Remarks.SelectionLength = 0;
			this.textBox_Remarks.SelectionStart = 0;
			this.textBox_Remarks.ShortcutsEnabled = true;
			this.textBox_Remarks.Size = new System.Drawing.Size(252, 77);
			this.textBox_Remarks.TabIndex = 104;
			this.textBox_Remarks.UseSelectable = true;
			this.textBox_Remarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBox_Remarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(224, 3);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 102;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(305, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 103;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelMain.Controls.Add(this.flowLayoutPanelFileControls);
			this.panelMain.Controls.Add(this.labelTitle);
			this.panelMain.Controls.Add(this.textBox_Remarks);
			this.panelMain.Controls.Add(this.textBoxAuthor);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.labelPublishDate);
			this.panelMain.Controls.Add(this.textBoxTitle);
			this.panelMain.Controls.Add(this.dateTimePickerPublishDate);
			this.panelMain.Controls.Add(this.textBoxDescription);
			this.panelMain.Controls.Add(this.labelOpeningDate);
			this.panelMain.Controls.Add(this.labelDescription);
			this.panelMain.Controls.Add(this.dateTimePickerOpeningDate);
			this.panelMain.Controls.Add(this.labelAuthor);
			this.panelMain.Controls.Add(this.labelClosingDate);
			this.panelMain.Controls.Add(this.dateTimePickerClosingDate);
			this.panelMain.Location = new System.Drawing.Point(3, 3);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(383, 508);
			this.panelMain.TabIndex = 118;
			// 
			// flowLayoutPanelFileControls
			// 
			this.flowLayoutPanelFileControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelFileControls.AutoScroll = true;
			this.flowLayoutPanelFileControls.Location = new System.Drawing.Point(1, 295);
			this.flowLayoutPanelFileControls.MinimumSize = new System.Drawing.Size(381, 2);
			this.flowLayoutPanelFileControls.Name = "flowLayoutPanelFileControls";
			this.flowLayoutPanelFileControls.Size = new System.Drawing.Size(381, 213);
			this.flowLayoutPanelFileControls.TabIndex = 118;
			this.flowLayoutPanelFileControls.Visible = false;
			// 
			// panelButtons
			// 
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Controls.Add(this.buttonOk);
			this.panelButtons.Location = new System.Drawing.Point(3, 517);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(383, 40);
			this.panelButtons.TabIndex = 119;
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoSize = true;
			this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelMain.Controls.Add(this.panelMain);
			this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(1, 63);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(389, 560);
			this.flowLayoutPanelMain.TabIndex = 120;
			// 
			// PurchaseRequestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(391, 625);
			this.Controls.Add(this.flowLayoutPanelMain);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PurchaseRequestForm";
			this.ShowIcon = false;
			this.Text = "Purchase Order Form";
			this.panelMain.ResumeLayout(false);
			this.panelButtons.ResumeLayout(false);
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MetroTextBox textBoxAuthor;
		private MetroLabel labelPublishDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerPublishDate;
		private MetroLabel labelOpeningDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerOpeningDate;
		private MetroLabel labelClosingDate;
		private System.Windows.Forms.DateTimePicker dateTimePickerClosingDate;
		private MetroLabel labelAuthor;
		private MetroLabel labelDescription;
		private MetroTextBox textBoxDescription;
		private MetroLabel labelTitle;
		private MetroTextBox textBoxTitle;
		private MetroLabel label1;
		private MetroTextBox textBox_Remarks;
		public System.Windows.Forms.Button buttonOk;
		public System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileControls;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;

	}
}