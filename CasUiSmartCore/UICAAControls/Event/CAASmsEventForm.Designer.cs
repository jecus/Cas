using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.SMSControls
{
	partial class CAASmsEventForm
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
			MetroFramework.Controls.MetroLabel labelDescription;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAASmsEventForm));
			this.textBoxDescription = new MetroFramework.Controls.MetroTextBox();
			this.labelConditions = new MetroFramework.Controls.MetroLabel();
			this.flowLayoutPanelConditions = new System.Windows.Forms.FlowLayoutPanel();
			this.panelAddCondition = new System.Windows.Forms.Panel();
			this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelRiskIndex = new MetroFramework.Controls.MetroLabel();
			this.textBoxRiskIndex = new MetroFramework.Controls.MetroTextBox();
			this.comboBoxIncident = new System.Windows.Forms.ComboBox();
			this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
			this.labelEventDate = new MetroFramework.Controls.MetroLabel();
			this.labelRemarks = new MetroFramework.Controls.MetroLabel();
			this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
			this.labelIncident = new MetroFramework.Controls.MetroLabel();
			this.labelClass = new MetroFramework.Controls.MetroLabel();
			this.labelEventCategory = new MetroFramework.Controls.MetroLabel();
			this.labelEventType = new MetroFramework.Controls.MetroLabel();
			this.dictionaryComboEventType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.dictionaryComboEventClass = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			labelDescription = new MetroFramework.Controls.MetroLabel();
			this.flowLayoutPanelConditions.SuspendLayout();
			this.panelAddCondition.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelDescription
			// 
			labelDescription.AutoSize = true;
			labelDescription.Location = new System.Drawing.Point(11, 60);
			labelDescription.Name = "labelDescription";
			labelDescription.Size = new System.Drawing.Size(77, 19);
			labelDescription.TabIndex = 0;
			labelDescription.Text = "Description:";
			labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxDescription.CustomButton.Image = null;
			this.textBoxDescription.CustomButton.Location = new System.Drawing.Point(278, 2);
			this.textBoxDescription.CustomButton.Name = "";
			this.textBoxDescription.CustomButton.Size = new System.Drawing.Size(75, 75);
			this.textBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxDescription.CustomButton.TabIndex = 1;
			this.textBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxDescription.CustomButton.UseSelectable = true;
			this.textBoxDescription.CustomButton.Visible = false;
			this.textBoxDescription.Lines = new string[0];
			this.textBoxDescription.Location = new System.Drawing.Point(119, 63);
			this.textBoxDescription.MaxLength = 256;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.PasswordChar = '\0';
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxDescription.SelectedText = "";
			this.textBoxDescription.SelectionLength = 0;
			this.textBoxDescription.SelectionStart = 0;
			this.textBoxDescription.ShortcutsEnabled = true;
			this.textBoxDescription.Size = new System.Drawing.Size(356, 80);
			this.textBoxDescription.TabIndex = 2;
			this.textBoxDescription.UseSelectable = true;
			this.textBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelConditions
			// 
			this.labelConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.labelConditions.Location = new System.Drawing.Point(14, 312);
			this.labelConditions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelConditions.Name = "labelConditions";
			this.labelConditions.Size = new System.Drawing.Size(462, 19);
			this.labelConditions.TabIndex = 15;
			this.labelConditions.Text = "Conditions";
			this.labelConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanelConditions
			// 
			this.flowLayoutPanelConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanelConditions.AutoScroll = true;
			this.flowLayoutPanelConditions.Controls.Add(this.panelAddCondition);
			this.flowLayoutPanelConditions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelConditions.Location = new System.Drawing.Point(14, 333);
			this.flowLayoutPanelConditions.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelConditions.MaximumSize = new System.Drawing.Size(485, 162);
			this.flowLayoutPanelConditions.Name = "flowLayoutPanelConditions";
			this.flowLayoutPanelConditions.Size = new System.Drawing.Size(462, 162);
			this.flowLayoutPanelConditions.TabIndex = 8;
			this.flowLayoutPanelConditions.WrapContents = false;
			// 
			// panelAddCondition
			// 
			this.panelAddCondition.Controls.Add(this.linkLabelAddNew);
			this.panelAddCondition.Location = new System.Drawing.Point(0, 0);
			this.panelAddCondition.Margin = new System.Windows.Forms.Padding(0);
			this.panelAddCondition.Name = "panelAddCondition";
			this.panelAddCondition.Size = new System.Drawing.Size(462, 30);
			this.panelAddCondition.TabIndex = 19;
			// 
			// linkLabelAddNew
			// 
			this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddNew.Location = new System.Drawing.Point(180, 4);
			this.linkLabelAddNew.Name = "linkLabelAddNew";
			this.linkLabelAddNew.Size = new System.Drawing.Size(114, 23);
			this.linkLabelAddNew.TabIndex = 2;
			this.linkLabelAddNew.TabStop = true;
			this.linkLabelAddNew.Text = "Add new condition";
			this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewConditionLinkClicked);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(347, 602);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(56, 27);
			this.buttonOK.TabIndex = 10;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(406, 602);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(69, 27);
			this.buttonCancel.TabIndex = 11;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// labelRiskIndex
			// 
			this.labelRiskIndex.AutoSize = true;
			this.labelRiskIndex.Location = new System.Drawing.Point(11, 229);
			this.labelRiskIndex.Name = "labelRiskIndex";
			this.labelRiskIndex.Size = new System.Drawing.Size(66, 19);
			this.labelRiskIndex.TabIndex = 242;
			this.labelRiskIndex.Text = "Risk index";
			// 
			// textBoxRiskIndex
			// 
			this.textBoxRiskIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxRiskIndex.CustomButton.Image = null;
			this.textBoxRiskIndex.CustomButton.Location = new System.Drawing.Point(339, 2);
			this.textBoxRiskIndex.CustomButton.Name = "";
			this.textBoxRiskIndex.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxRiskIndex.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRiskIndex.CustomButton.TabIndex = 1;
			this.textBoxRiskIndex.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRiskIndex.CustomButton.UseSelectable = true;
			this.textBoxRiskIndex.CustomButton.Visible = false;
			this.textBoxRiskIndex.Lines = new string[0];
			this.textBoxRiskIndex.Location = new System.Drawing.Point(119, 229);
			this.textBoxRiskIndex.MaxLength = 256;
			this.textBoxRiskIndex.Name = "textBoxRiskIndex";
			this.textBoxRiskIndex.PasswordChar = '\0';
			this.textBoxRiskIndex.ReadOnly = true;
			this.textBoxRiskIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRiskIndex.SelectedText = "";
			this.textBoxRiskIndex.SelectionLength = 0;
			this.textBoxRiskIndex.SelectionStart = 0;
			this.textBoxRiskIndex.ShortcutsEnabled = true;
			this.textBoxRiskIndex.Size = new System.Drawing.Size(357, 20);
			this.textBoxRiskIndex.TabIndex = 241;
			this.textBoxRiskIndex.UseSelectable = true;
			this.textBoxRiskIndex.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRiskIndex.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// comboBoxIncident
			// 
			this.comboBoxIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxIncident.FormattingEnabled = true;
			this.comboBoxIncident.Location = new System.Drawing.Point(119, 252);
			this.comboBoxIncident.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxIncident.Name = "comboBoxIncident";
			this.comboBoxIncident.Size = new System.Drawing.Size(356, 21);
			this.comboBoxIncident.TabIndex = 6;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			// 
			// 
			// 
			this.textBoxRemarks.CustomButton.Image = null;
			this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(268, 2);
			this.textBoxRemarks.CustomButton.Name = "";
			this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(85, 85);
			this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxRemarks.CustomButton.TabIndex = 1;
			this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxRemarks.CustomButton.UseSelectable = true;
			this.textBoxRemarks.CustomButton.Visible = false;
			this.textBoxRemarks.Lines = new string[0];
			this.textBoxRemarks.Location = new System.Drawing.Point(119, 507);
			this.textBoxRemarks.MaxLength = 256;
			this.textBoxRemarks.Multiline = true;
			this.textBoxRemarks.Name = "textBoxRemarks";
			this.textBoxRemarks.PasswordChar = '\0';
			this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxRemarks.SelectedText = "";
			this.textBoxRemarks.SelectionLength = 0;
			this.textBoxRemarks.SelectionStart = 0;
			this.textBoxRemarks.ShortcutsEnabled = true;
			this.textBoxRemarks.Size = new System.Drawing.Size(356, 90);
			this.textBoxRemarks.TabIndex = 9;
			this.textBoxRemarks.UseSelectable = true;
			this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			// 
			// labelEventDate
			// 
			this.labelEventDate.AutoSize = true;
			this.labelEventDate.Location = new System.Drawing.Point(11, 277);
			this.labelEventDate.Name = "labelEventDate";
			this.labelEventDate.Size = new System.Drawing.Size(71, 19);
			this.labelEventDate.TabIndex = 235;
			this.labelEventDate.Text = "Event Date";
			// 
			// labelRemarks
			// 
			this.labelRemarks.AutoSize = true;
			this.labelRemarks.Location = new System.Drawing.Point(11, 507);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(59, 19);
			this.labelRemarks.TabIndex = 234;
			this.labelRemarks.Text = "Remarks";
			// 
			// dateTimePickerEventDate
			// 
			this.dateTimePickerEventDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePickerEventDate.Location = new System.Drawing.Point(119, 277);
			this.dateTimePickerEventDate.Margin = new System.Windows.Forms.Padding(2);
			this.dateTimePickerEventDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
			this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
			this.dateTimePickerEventDate.Size = new System.Drawing.Size(356, 20);
			this.dateTimePickerEventDate.TabIndex = 7;
			this.dateTimePickerEventDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
			// 
			// labelIncident
			// 
			this.labelIncident.AutoSize = true;
			this.labelIncident.Location = new System.Drawing.Point(11, 252);
			this.labelIncident.Name = "labelIncident";
			this.labelIncident.Size = new System.Drawing.Size(109, 19);
			this.labelIncident.TabIndex = 239;
			this.labelIncident.Text = "Incident/Accident";
			// 
			// labelClass
			// 
			this.labelClass.AutoSize = true;
			this.labelClass.Location = new System.Drawing.Point(11, 176);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(70, 19);
			this.labelClass.TabIndex = 238;
			this.labelClass.Text = "Event class";
			// 
			// labelEventCategory
			// 
			this.labelEventCategory.AutoSize = true;
			this.labelEventCategory.Location = new System.Drawing.Point(11, 202);
			this.labelEventCategory.Name = "labelEventCategory";
			this.labelEventCategory.Size = new System.Drawing.Size(99, 19);
			this.labelEventCategory.TabIndex = 236;
			this.labelEventCategory.Text = "Event Category";
			// 
			// labelEventType
			// 
			this.labelEventType.AutoSize = true;
			this.labelEventType.Location = new System.Drawing.Point(11, 150);
			this.labelEventType.Name = "labelEventType";
			this.labelEventType.Size = new System.Drawing.Size(69, 19);
			this.labelEventType.TabIndex = 232;
			this.labelEventType.Text = "Event type";
			// 
			// dictionaryComboEventType
			// 
			this.dictionaryComboEventType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.dictionaryComboEventType.Displayer = null;
			this.dictionaryComboEventType.DisplayerText = null;
			this.dictionaryComboEventType.Entity = null;
			this.dictionaryComboEventType.Location = new System.Drawing.Point(119, 150);
			this.dictionaryComboEventType.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboEventType.Name = "dictionaryComboEventType";
			this.dictionaryComboEventType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboEventType.Size = new System.Drawing.Size(356, 21);
			this.dictionaryComboEventType.TabIndex = 243;
			this.dictionaryComboEventType.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxEventTypeSelectedIndexChanged);
			// 
			// dictionaryComboEventClass
			// 
			this.dictionaryComboEventClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.dictionaryComboEventClass.Displayer = null;
			this.dictionaryComboEventClass.DisplayerText = null;
			this.dictionaryComboEventClass.Entity = null;
			this.dictionaryComboEventClass.Location = new System.Drawing.Point(119, 176);
			this.dictionaryComboEventClass.Margin = new System.Windows.Forms.Padding(4);
			this.dictionaryComboEventClass.Name = "dictionaryComboEventClass";
			this.dictionaryComboEventClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboEventClass.Size = new System.Drawing.Size(356, 21);
			this.dictionaryComboEventClass.TabIndex = 244;
			this.dictionaryComboEventClass.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboEventClassSelectedIndexChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(119, 201);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(356, 21);
			this.comboBox1.TabIndex = 245;
			// 
			// CAASmsEventForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(485, 636);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.dictionaryComboEventClass);
			this.Controls.Add(this.dictionaryComboEventType);
			this.Controls.Add(this.labelRiskIndex);
			this.Controls.Add(this.textBoxRiskIndex);
			this.Controls.Add(this.comboBoxIncident);
			this.Controls.Add(this.textBoxRemarks);
			this.Controls.Add(this.labelEventDate);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.dateTimePickerEventDate);
			this.Controls.Add(this.labelIncident);
			this.Controls.Add(this.labelClass);
			this.Controls.Add(this.labelEventCategory);
			this.Controls.Add(this.labelEventType);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.flowLayoutPanelConditions);
			this.Controls.Add(this.labelConditions);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(labelDescription);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(485, 534);
			this.Name = "CAASmsEventForm";
			this.Text = "SMS Event Form";
			this.flowLayoutPanelConditions.ResumeLayout(false);
			this.panelAddCondition.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.ComboBox comboBox1;

		#endregion
		private MetroTextBox textBoxDescription;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private MetroLabel labelConditions;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConditions;
		private System.Windows.Forms.Panel panelAddCondition;
		private System.Windows.Forms.LinkLabel linkLabelAddNew;
		private MetroLabel labelRiskIndex;
		private MetroTextBox textBoxRiskIndex;
		private System.Windows.Forms.ComboBox comboBoxIncident;
		private MetroTextBox textBoxRemarks;
		private MetroLabel labelEventDate;
		private MetroLabel labelRemarks;
		private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
		private MetroLabel labelIncident;
		private MetroLabel labelClass;
		private MetroLabel labelEventCategory;
		private MetroLabel labelEventType;
		private Auxiliary.DictionaryComboBox dictionaryComboEventType;
		private Auxiliary.DictionaryComboBox dictionaryComboEventClass;
	}
}