namespace CAS.UI.UIControls.SMSControls
{
    partial class SmsEventTypeForm
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
            System.Windows.Forms.Label labelName;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsEventTypeForm));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelConditions = new System.Windows.Forms.Label();
            this.flowLayoutPanelConditions = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddCondition = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listViewCompliance = new System.Windows.Forms.ListView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelRiskLevel = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            labelDescription = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();
            this.flowLayoutPanelConditions.SuspendLayout();
            this.panelAddCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelDescription.Location = new System.Drawing.Point(13, 46);
            labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new System.Drawing.Size(95, 17);
            labelDescription.TabIndex = 0;
            labelDescription.Text = "Description:";
            labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelName.Location = new System.Drawing.Point(13, 16);
            labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(54, 17);
            labelName.TabIndex = 0;
            labelName.Text = "Name:";
            labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(116, 43);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDescription.MaxLength = 256;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(504, 98);
            this.textBoxDescription.TabIndex = 2;
            // 
            // labelConditions
            // 
            this.labelConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelConditions.Location = new System.Drawing.Point(3, 145);
            this.labelConditions.Name = "labelConditions";
            this.labelConditions.Size = new System.Drawing.Size(619, 23);
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
            this.flowLayoutPanelConditions.Location = new System.Drawing.Point(5, 171);
            this.flowLayoutPanelConditions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelConditions.MaximumSize = new System.Drawing.Size(647, 199);
            this.flowLayoutPanelConditions.Name = "flowLayoutPanelConditions";
            this.flowLayoutPanelConditions.Size = new System.Drawing.Size(616, 199);
            this.flowLayoutPanelConditions.TabIndex = 3;
            this.flowLayoutPanelConditions.WrapContents = false;
            // 
            // panelAddCondition
            // 
            this.panelAddCondition.Controls.Add(this.linkLabelAddNew);
            this.panelAddCondition.Location = new System.Drawing.Point(0, 0);
            this.panelAddCondition.Margin = new System.Windows.Forms.Padding(0);
            this.panelAddCondition.Name = "panelAddCondition";
            this.panelAddCondition.Size = new System.Drawing.Size(580, 37);
            this.panelAddCondition.TabIndex = 19;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(0, 5);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(580, 28);
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
            this.buttonOK.Location = new System.Drawing.Point(451, 560);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 33);
            this.buttonOK.TabIndex = 7;
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
            this.buttonCancel.Location = new System.Drawing.Point(531, 560);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(92, 33);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCompliance.FullRowSelect = true;
            this.listViewCompliance.Location = new System.Drawing.Point(5, 401);
            this.listViewCompliance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewCompliance.Name = "listViewCompliance";
            this.listViewCompliance.Size = new System.Drawing.Size(616, 152);
            this.listViewCompliance.TabIndex = 4;
            this.listViewCompliance.UseCompatibleStateImageBehavior = false;
            this.listViewCompliance.View = System.Windows.Forms.View.Details;
            this.listViewCompliance.Click += new System.EventHandler(this.ListViewComplainceClick);
            this.listViewCompliance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewComplainceMouseDoubleClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonAdd.Location = new System.Drawing.Point(5, 560);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 33);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonEdit.Location = new System.Drawing.Point(87, 560);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 33);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonDelete.Location = new System.Drawing.Point(168, 560);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(87, 33);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelRiskLevel
            // 
            this.labelRiskLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRiskLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRiskLevel.Location = new System.Drawing.Point(3, 374);
            this.labelRiskLevel.Name = "labelRiskLevel";
            this.labelRiskLevel.Size = new System.Drawing.Size(619, 23);
            this.labelRiskLevel.TabIndex = 17;
            this.labelRiskLevel.Text = "Risk Lelel";
            this.labelRiskLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(116, 14);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxName.MaxLength = 256;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(504, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // SmsEventTypeForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(625, 612);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(labelName);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelRiskLevel);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.flowLayoutPanelConditions);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.labelConditions);
            this.Controls.Add(this.listViewCompliance);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(labelDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(641, 648);
            this.Name = "SmsEventTypeForm";
            this.Text = "SMS Event Type Form";
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
        public System.Windows.Forms.ListView listViewCompliance;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelRiskLevel;
        private System.Windows.Forms.TextBox textBoxName;
    }
}