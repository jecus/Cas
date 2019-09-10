using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightSmsEventControl
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

            dictionaryComboEventType.SelectedIndexChanged -= LookupComboboxEventTypeSelectedIndexChanged;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelEventType = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelRiskIndex = new System.Windows.Forms.Label();
            this.textBoxRiskIndex = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.dictionaryComboBoxCategory = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.dictionaryComboEventType = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.comboBoxIncident = new System.Windows.Forms.ComboBox();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelEventDate = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.dateTimePickerEventDate = new System.Windows.Forms.DateTimePicker();
            this.labelIncident = new System.Windows.Forms.Label();
            this.dictionaryComboEventClass = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelEventCategory = new System.Windows.Forms.Label();
            this.flowLayoutPanelConditions = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddCondition = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.panelExtendable = new System.Windows.Forms.Panel();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain.SuspendLayout();
            this.flowLayoutPanelConditions.SuspendLayout();
            this.panelAddCondition.SuspendLayout();
            this.panelExtendable.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEventType
            // 
            this.labelEventType.AutoSize = true;
            this.labelEventType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEventType.Location = new System.Drawing.Point(3, 10);
            this.labelEventType.Name = "labelEventType";
            this.labelEventType.Size = new System.Drawing.Size(58, 13);
            this.labelEventType.TabIndex = 13;
            this.labelEventType.Text = "Event type";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(729, 5);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(26, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.labelRiskIndex);
            this.panelMain.Controls.Add(this.textBoxRiskIndex);
            this.panelMain.Controls.Add(this.textBoxDescription);
            this.panelMain.Controls.Add(this.labelDescription);
            this.panelMain.Controls.Add(this.dictionaryComboBoxCategory);
            this.panelMain.Controls.Add(this.dictionaryComboEventType);
            this.panelMain.Controls.Add(this.comboBoxIncident);
            this.panelMain.Controls.Add(this.textBoxRemarks);
            this.panelMain.Controls.Add(this.labelEventDate);
            this.panelMain.Controls.Add(this.labelRemarks);
            this.panelMain.Controls.Add(this.dateTimePickerEventDate);
            this.panelMain.Controls.Add(this.labelIncident);
            this.panelMain.Controls.Add(this.dictionaryComboEventClass);
            this.panelMain.Controls.Add(this.labelClass);
            this.panelMain.Controls.Add(this.labelEventCategory);
            this.panelMain.Controls.Add(this.labelEventType);
            this.panelMain.Controls.Add(this.buttonDelete);
            this.panelMain.Location = new System.Drawing.Point(3, 38);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(758, 158);
            this.panelMain.TabIndex = 187;
            this.panelMain.Visible = false;
            // 
            // labelRiskIndex
            // 
            this.labelRiskIndex.AutoSize = true;
            this.labelRiskIndex.Location = new System.Drawing.Point(502, 10);
            this.labelRiskIndex.Name = "labelRiskIndex";
            this.labelRiskIndex.Size = new System.Drawing.Size(56, 13);
            this.labelRiskIndex.TabIndex = 228;
            this.labelRiskIndex.Text = "Risk index";
            // 
            // textBoxRiskIndex
            // 
            this.textBoxRiskIndex.Location = new System.Drawing.Point(568, 7);
            this.textBoxRiskIndex.MaxLength = 256;
            this.textBoxRiskIndex.Name = "textBoxRiskIndex";
            this.textBoxRiskIndex.ReadOnly = true;
            this.textBoxRiskIndex.Size = new System.Drawing.Size(156, 20);
            this.textBoxRiskIndex.TabIndex = 227;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(71, 55);
            this.textBoxDescription.MaxLength = 256;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(425, 47);
            this.textBoxDescription.TabIndex = 225;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 58);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 226;
            this.labelDescription.Text = "Description";
            // 
            // dictionaryComboBoxCategory
            // 
            this.dictionaryComboBoxCategory.Displayer = null;
            this.dictionaryComboBoxCategory.DisplayerText = null;
            this.dictionaryComboBoxCategory.Entity = null;
            this.dictionaryComboBoxCategory.Location = new System.Drawing.Point(338, 5);
            this.dictionaryComboBoxCategory.Name = "dictionaryComboBoxCategory";
            this.dictionaryComboBoxCategory.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboBoxCategory.Size = new System.Drawing.Size(158, 21);
            this.dictionaryComboBoxCategory.TabIndex = 224;
            this.dictionaryComboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboBoxCategorySelectedIndexChanged);
            // 
            // dictionaryComboEventType
            // 
            this.dictionaryComboEventType.Displayer = null;
            this.dictionaryComboEventType.DisplayerText = null;
            this.dictionaryComboEventType.Entity = null;
            this.dictionaryComboEventType.Location = new System.Drawing.Point(71, 5);
            this.dictionaryComboEventType.Name = "dictionaryComboEventType";
            this.dictionaryComboEventType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboEventType.Size = new System.Drawing.Size(158, 21);
            this.dictionaryComboEventType.TabIndex = 1;
            // 
            // comboBoxIncident
            // 
            this.comboBoxIncident.FormattingEnabled = true;
            this.comboBoxIncident.Location = new System.Drawing.Point(338, 29);
            this.comboBoxIncident.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxIncident.Name = "comboBoxIncident";
            this.comboBoxIncident.Size = new System.Drawing.Size(158, 21);
            this.comboBoxIncident.TabIndex = 4;
            this.comboBoxIncident.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// textBoxRemarks
			// 
			this.textBoxRemarks.Location = new System.Drawing.Point(71, 108);
            this.textBoxRemarks.MaxLength = 256;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(425, 47);
            this.textBoxRemarks.TabIndex = 184;
            // 
            // labelEventDate
            // 
            this.labelEventDate.AutoSize = true;
            this.labelEventDate.Location = new System.Drawing.Point(502, 58);
            this.labelEventDate.Name = "labelEventDate";
            this.labelEventDate.Size = new System.Drawing.Size(61, 13);
            this.labelEventDate.TabIndex = 218;
            this.labelEventDate.Text = "Event Date";
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Location = new System.Drawing.Point(3, 111);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(49, 13);
            this.labelRemarks.TabIndex = 185;
            this.labelRemarks.Text = "Remarks";
            // 
            // dateTimePickerEventDate
            // 
            this.dateTimePickerEventDate.Location = new System.Drawing.Point(568, 55);
            this.dateTimePickerEventDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerEventDate.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEventDate.Name = "dateTimePickerEventDate";
            this.dateTimePickerEventDate.Size = new System.Drawing.Size(156, 20);
            this.dateTimePickerEventDate.TabIndex = 219;
            this.dateTimePickerEventDate.Value = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
            // 
            // labelIncident
            // 
            this.labelIncident.AutoSize = true;
            this.labelIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIncident.Location = new System.Drawing.Point(240, 35);
            this.labelIncident.Name = "labelIncident";
            this.labelIncident.Size = new System.Drawing.Size(92, 13);
            this.labelIncident.TabIndex = 223;
            this.labelIncident.Text = "Incident/Accident";
            // 
            // dictionaryComboEventClass
            // 
            this.dictionaryComboEventClass.Displayer = null;
            this.dictionaryComboEventClass.DisplayerText = null;
            this.dictionaryComboEventClass.Entity = null;
            this.dictionaryComboEventClass.Location = new System.Drawing.Point(71, 29);
            this.dictionaryComboEventClass.Name = "dictionaryComboEventClass";
            this.dictionaryComboEventClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dictionaryComboEventClass.Size = new System.Drawing.Size(158, 20);
            this.dictionaryComboEventClass.TabIndex = 3;
            this.dictionaryComboEventClass.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboEventClassSelectedIndexChanged);
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.Location = new System.Drawing.Point(3, 35);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(62, 13);
            this.labelClass.TabIndex = 221;
            this.labelClass.Text = "Event class";
            // 
            // labelEventCategory
            // 
            this.labelEventCategory.AutoSize = true;
            this.labelEventCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEventCategory.Location = new System.Drawing.Point(240, 10);
            this.labelEventCategory.Name = "labelEventCategory";
            this.labelEventCategory.Size = new System.Drawing.Size(80, 13);
            this.labelEventCategory.TabIndex = 219;
            this.labelEventCategory.Text = "Event Category";
            // 
            // flowLayoutPanelConditions
            // 
            this.flowLayoutPanelConditions.AutoScroll = true;
            this.flowLayoutPanelConditions.Controls.Add(this.panelAddCondition);
            this.flowLayoutPanelConditions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelConditions.Location = new System.Drawing.Point(3, 202);
            this.flowLayoutPanelConditions.MaximumSize = new System.Drawing.Size(647, 200);
            this.flowLayoutPanelConditions.Name = "flowLayoutPanelConditions";
            this.flowLayoutPanelConditions.Size = new System.Drawing.Size(496, 140);
            this.flowLayoutPanelConditions.TabIndex = 3;
            this.flowLayoutPanelConditions.Visible = false;
            this.flowLayoutPanelConditions.WrapContents = false;
            // 
            // panelAddCondition
            // 
            this.panelAddCondition.Controls.Add(this.linkLabelAddNew);
            this.panelAddCondition.Location = new System.Drawing.Point(0, 0);
            this.panelAddCondition.Margin = new System.Windows.Forms.Padding(0);
            this.panelAddCondition.Name = "panelAddCondition";
            this.panelAddCondition.Size = new System.Drawing.Size(441, 31);
            this.panelAddCondition.TabIndex = 19;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(152, 2);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(152, 22);
            this.linkLabelAddNew.TabIndex = 2;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new condition";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewConditionLinkClicked);
            // 
            // panelExtendable
            // 
            this.panelExtendable.AutoSize = true;
            this.panelExtendable.Controls.Add(this.extendableRichContainer);
            this.panelExtendable.Location = new System.Drawing.Point(3, 3);
            this.panelExtendable.Name = "panelExtendable";
            this.panelExtendable.Size = new System.Drawing.Size(434, 29);
            this.panelExtendable.TabIndex = 187;
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = null;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Directive Performance";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = false;
            this.extendableRichContainer.Location = new System.Drawing.Point(0, 4);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(431, 22);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelMain.Controls.Add(this.panelExtendable);
            this.flowLayoutPanelMain.Controls.Add(this.panelMain);
            this.flowLayoutPanelMain.Controls.Add(this.flowLayoutPanelConditions);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(764, 345);
            this.flowLayoutPanelMain.TabIndex = 188;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // FlightSmsEventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FlightSmsEventControl";
            this.Size = new System.Drawing.Size(770, 351);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.flowLayoutPanelConditions.ResumeLayout(false);
            this.panelAddCondition.ResumeLayout(false);
            this.panelExtendable.ResumeLayout(false);
            this.panelExtendable.PerformLayout();
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEventType;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelExtendable;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConditions;
        private System.Windows.Forms.Label labelEventCategory;
        private Auxiliary.DictionaryComboBox dictionaryComboEventClass;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelEventDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDate;
        private System.Windows.Forms.Label labelIncident;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.ComboBox comboBoxIncident;
        private Auxiliary.DictionaryComboBox dictionaryComboEventType;
        private System.Windows.Forms.Label labelRiskIndex;
        private System.Windows.Forms.TextBox textBoxRiskIndex;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private Auxiliary.DictionaryComboBox dictionaryComboBoxCategory;
        private System.Windows.Forms.Panel panelAddCondition;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
    }
}
