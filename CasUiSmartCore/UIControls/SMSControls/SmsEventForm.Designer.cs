namespace CAS.UI.UIControls.SMSControls
{
    partial class SmsEventForm
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
            System.Windows.Forms.Label labelDescription;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsEventForm));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelConditions = new System.Windows.Forms.Label();
            this.flowLayoutPanelConditions = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddCondition = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelRiskIndex = new System.Windows.Forms.Label();
            this.textBoxRiskIndex = new System.Windows.Forms.TextBox();
            this.comboBoxIncident = new System.Windows.Forms.ComboBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelEventDate = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.labelIncident = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelEventCategory = new System.Windows.Forms.Label();
            this.labelEventType = new System.Windows.Forms.Label();
            this.dictionaryComboEventType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.dictionaryComboEventClass = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.dictionaryComboBoxCategory = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            labelDescription = new System.Windows.Forms.Label();
            this.flowLayoutPanelConditions.SuspendLayout();
            this.panelAddCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelDescription.Location = new System.Drawing.Point(10, 14);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new System.Drawing.Size(75, 13);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(110, 12);
            this.textBoxDescription.MaxLength = 256;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(356, 80);
            this.textBoxDescription.TabIndex = 2;
            // 
            // labelConditions
            // 
            this.labelConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConditions.Location = new System.Drawing.Point(3, 261);
            this.labelConditions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelConditions.Name = "labelConditions";
            this.labelConditions.Size = new System.Drawing.Size(464, 19);
            this.labelConditions.TabIndex = 15;
            this.labelConditions.Text = "Conditions";
            this.labelConditions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelConditions
            // 
            this.flowLayoutPanelConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelConditions.AutoScroll = true;
            this.flowLayoutPanelConditions.Controls.Add(this.panelAddCondition);
            this.flowLayoutPanelConditions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelConditions.Location = new System.Drawing.Point(5, 282);
            this.flowLayoutPanelConditions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.panelAddCondition.Size = new System.Drawing.Size(435, 30);
            this.panelAddCondition.TabIndex = 19;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(166, 4);
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
            this.buttonOK.Location = new System.Drawing.Point(338, 539);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.buttonCancel.Location = new System.Drawing.Point(397, 539);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 27);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // labelRiskIndex
            // 
            this.labelRiskIndex.AutoSize = true;
            this.labelRiskIndex.Location = new System.Drawing.Point(10, 183);
            this.labelRiskIndex.Name = "labelRiskIndex";
            this.labelRiskIndex.Size = new System.Drawing.Size(56, 13);
            this.labelRiskIndex.TabIndex = 242;
            this.labelRiskIndex.Text = "Risk index";
            // 
            // textBoxRiskIndex
            // 
            this.textBoxRiskIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRiskIndex.Location = new System.Drawing.Point(110, 180);
            this.textBoxRiskIndex.MaxLength = 256;
            this.textBoxRiskIndex.Name = "textBoxRiskIndex";
            this.textBoxRiskIndex.ReadOnly = true;
            this.textBoxRiskIndex.Size = new System.Drawing.Size(356, 20);
            this.textBoxRiskIndex.TabIndex = 241;
            // 
            // comboBoxIncident
            // 
            this.comboBoxIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIncident.FormattingEnabled = true;
            this.comboBoxIncident.Location = new System.Drawing.Point(110, 201);
            this.comboBoxIncident.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxIncident.Name = "comboBoxIncident";
            this.comboBoxIncident.Size = new System.Drawing.Size(356, 21);
            this.comboBoxIncident.TabIndex = 6;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRemarks.Location = new System.Drawing.Point(110, 448);
            this.textBoxRemarks.MaxLength = 256;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(356, 83);
            this.textBoxRemarks.TabIndex = 9;
            // 
            // labelEventDate
            // 
            this.labelEventDate.AutoSize = true;
            this.labelEventDate.Location = new System.Drawing.Point(10, 232);
            this.labelEventDate.Name = "labelEventDate";
            this.labelEventDate.Size = new System.Drawing.Size(61, 13);
            this.labelEventDate.TabIndex = 235;
            this.labelEventDate.Text = "Event Date";
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Location = new System.Drawing.Point(10, 452);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(49, 13);
            this.labelRemarks.TabIndex = 234;
            this.labelRemarks.Text = "Remarks";
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(110, 226);
            this.dateTimePickerEventDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePickerEventDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(356, 20);
            this.dateTimePickerEventDate.TabIndex = 7;
            this.dateTimePickerEventDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
            // 
            // labelIncident
            // 
            this.labelIncident.AutoSize = true;
            this.labelIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIncident.Location = new System.Drawing.Point(10, 206);
            this.labelIncident.Name = "labelIncident";
            this.labelIncident.Size = new System.Drawing.Size(92, 13);
            this.labelIncident.TabIndex = 239;
            this.labelIncident.Text = "Incident/Accident";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.Location = new System.Drawing.Point(10, 132);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(62, 13);
            this.labelClass.TabIndex = 238;
            this.labelClass.Text = "Event class";
            // 
            // labelEventCategory
            // 
            this.labelEventCategory.AutoSize = true;
            this.labelEventCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEventCategory.Location = new System.Drawing.Point(10, 159);
            this.labelEventCategory.Name = "labelEventCategory";
            this.labelEventCategory.Size = new System.Drawing.Size(80, 13);
            this.labelEventCategory.TabIndex = 236;
            this.labelEventCategory.Text = "Event Category";
            // 
            // labelEventType
            // 
            this.labelEventType.AutoSize = true;
            this.labelEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEventType.Location = new System.Drawing.Point(10, 106);
            this.labelEventType.Name = "labelEventType";
            this.labelEventType.Size = new System.Drawing.Size(58, 13);
            this.labelEventType.TabIndex = 232;
            this.labelEventType.Text = "Event type";
            // 
            // dictionaryComboEventType
            // 
            this.dictionaryComboEventType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryComboEventType.Displayer = null;
            this.dictionaryComboEventType.DisplayerText = null;
            this.dictionaryComboEventType.Entity = null;
            this.dictionaryComboEventType.Location = new System.Drawing.Point(110, 99);
            this.dictionaryComboEventType.Margin = new System.Windows.Forms.Padding(4);
            this.dictionaryComboEventType.Name = "dictionaryComboEventType";
            this.dictionaryComboEventType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboEventType.Size = new System.Drawing.Size(356, 21);
            this.dictionaryComboEventType.TabIndex = 243;
            this.dictionaryComboEventType.SelectedIndexChanged += new System.EventHandler(this.LookupComboboxEventTypeSelectedIndexChanged);
            // 
            // dictionaryComboEventClass
            // 
            this.dictionaryComboEventClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryComboEventClass.Displayer = null;
            this.dictionaryComboEventClass.DisplayerText = null;
            this.dictionaryComboEventClass.Entity = null;
            this.dictionaryComboEventClass.Location = new System.Drawing.Point(110, 125);
            this.dictionaryComboEventClass.Margin = new System.Windows.Forms.Padding(4);
            this.dictionaryComboEventClass.Name = "dictionaryComboEventClass";
            this.dictionaryComboEventClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboEventClass.Size = new System.Drawing.Size(356, 20);
            this.dictionaryComboEventClass.TabIndex = 244;
            this.dictionaryComboEventClass.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboEventClassSelectedIndexChanged);
            // 
            // dictionaryComboBoxCategory
            // 
            this.dictionaryComboBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dictionaryComboBoxCategory.Displayer = null;
            this.dictionaryComboBoxCategory.DisplayerText = null;
            this.dictionaryComboBoxCategory.Entity = null;
            this.dictionaryComboBoxCategory.Location = new System.Drawing.Point(110, 151);
            this.dictionaryComboBoxCategory.Margin = new System.Windows.Forms.Padding(4);
            this.dictionaryComboBoxCategory.Name = "dictionaryComboBoxCategory";
            this.dictionaryComboBoxCategory.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxCategory.Size = new System.Drawing.Size(356, 21);
            this.dictionaryComboBoxCategory.TabIndex = 245;
            this.dictionaryComboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboBoxCategorySelectedIndexChanged);
            // 
            // SmsEventForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(469, 571);
            this.Controls.Add(this.dictionaryComboBoxCategory);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(485, 534);
            this.Name = "SmsEventForm";
            this.Text = "SMS Event Form";
            this.flowLayoutPanelConditions.ResumeLayout(false);
            this.panelAddCondition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelConditions;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConditions;
        private System.Windows.Forms.Panel panelAddCondition;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.Label labelRiskIndex;
        private System.Windows.Forms.TextBox textBoxRiskIndex;
        private System.Windows.Forms.ComboBox comboBoxIncident;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelEventDate;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.Label labelIncident;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelEventCategory;
        private System.Windows.Forms.Label labelEventType;
        private Auxiliary.DictionaryComboBox dictionaryComboEventType;
        private Auxiliary.DictionaryComboBox dictionaryComboEventClass;
        private Auxiliary.DictionaryComboBox dictionaryComboBoxCategory;
    }
}