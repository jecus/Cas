using System.Windows.Forms;
using ATAChapterFilterControl=CAS.UI.UIControls.FiltersControls.ATAChapterFilterControl;
using AvionicsInventoryFilterControl=CAS.UI.UIControls.FiltersControls.AvionicsInventoryFilterControl;
using DetailConditionFilterControl=CAS.UI.UIControls.FiltersControls.DetailConditionFilterControl;
using LandingGearFilterControl=CAS.UI.UIControls.FiltersControls.LandingGearFilterControl;
using MaintenanceFilterControl=CAS.UI.UIControls.FiltersControls.MaintenanceFilterControl;
using PartNoFilterControl=CAS.UI.UIControls.FiltersControls.PartNoFilterControl;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    partial class TemplateDetailFilterSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateDetailFilterSelection));
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ataChapterFilterControl1 = new ATAChapterFilterControl();
            this.partNoFilterControl1 = new PartNoFilterControl();
            this.maintenanceFilterControl2 = new MaintenanceFilterControl();
            this.detailConditionFilterControl2 = new DetailConditionFilterControl();
            this.label3 = new System.Windows.Forms.Label();
            this.labelATAChapter = new System.Windows.Forms.Label();
            this.textBoxATAChapter = new System.Windows.Forms.TextBox();
            this.checkedListBoxATAChapter = new System.Windows.Forms.CheckedListBox();
            this.textBoxPartMask = new System.Windows.Forms.TextBox();
            this.checkBoxPartFilterAppliance = new System.Windows.Forms.CheckBox();
            this.checkBoxUnknown = new System.Windows.Forms.CheckBox();
            this.checkBoxHardTime = new System.Windows.Forms.CheckBox();
            this.checkBoxOnCondition = new System.Windows.Forms.CheckBox();
            this.checkBoxConditionMonitoring = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.landingGearFilterControl1 = new LandingGearFilterControl();
            this.avionicsInventoryFilterControl1 = new AvionicsInventoryFilterControl();
            this.checkBoxComponentAppliance = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(434, 319);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(105, 37);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Cancel";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(80, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 71);
            this.panel1.TabIndex = 25;
            // 
            // buttonApply
            // 
            this.buttonApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.Location = new System.Drawing.Point(323, 319);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(105, 37);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Apply Filter";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // checkedListBoxItems
            // 
            this.checkedListBoxItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkedListBoxItems.Location = new System.Drawing.Point(740, 6);
            this.checkedListBoxItems.Name = "checkedListBoxItems";
            this.checkedListBoxItems.Size = new System.Drawing.Size(339, 76);
            this.checkedListBoxItems.TabIndex = 28;
            this.checkedListBoxItems.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ataChapterFilterControl1);
            this.panel2.Controls.Add(this.partNoFilterControl1);
            this.panel2.Controls.Add(this.maintenanceFilterControl2);
            this.panel2.Controls.Add(this.detailConditionFilterControl2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(736, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(451, 507);
            this.panel2.TabIndex = 29;
            // 
            // ataChapterFilterControl1
            // 
            this.ataChapterFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.ataChapterFilterControl1.FilterAppliance = false;
            this.ataChapterFilterControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ataChapterFilterControl1.Location = new System.Drawing.Point(30, 176);
            this.ataChapterFilterControl1.Name = "ataChapterFilterControl1";
            this.ataChapterFilterControl1.Size = new System.Drawing.Size(417, 102);
            this.ataChapterFilterControl1.TabIndex = 27;
            // 
            // partNoFilterControl1
            // 
            this.partNoFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.partNoFilterControl1.FilterAppliance = false;
            this.partNoFilterControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.partNoFilterControl1.Location = new System.Drawing.Point(30, 286);
            this.partNoFilterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.partNoFilterControl1.Name = "partNoFilterControl1";
            this.partNoFilterControl1.Size = new System.Drawing.Size(358, 29);
            this.partNoFilterControl1.TabIndex = 2;
            // 
            // maintenanceFilterControl2
            // 
            this.maintenanceFilterControl2.AcceptConditionMonitoring = true;
            this.maintenanceFilterControl2.AcceptHardTime = true;
            this.maintenanceFilterControl2.AcceptOnCondition = true;
            this.maintenanceFilterControl2.AcceptUnknown = true;
            this.maintenanceFilterControl2.BackColor = System.Drawing.Color.Transparent;
            this.maintenanceFilterControl2.FilterAppliance = true;
            this.maintenanceFilterControl2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maintenanceFilterControl2.Location = new System.Drawing.Point(12, 352);
            this.maintenanceFilterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maintenanceFilterControl2.Name = "maintenanceFilterControl2";
            this.maintenanceFilterControl2.Size = new System.Drawing.Size(324, 64);
            this.maintenanceFilterControl2.TabIndex = 24;
            // 
            // detailConditionFilterControl2
            // 
            this.detailConditionFilterControl2.BackColor = System.Drawing.Color.Transparent;
            this.detailConditionFilterControl2.FilterAppliance = false;
            this.detailConditionFilterControl2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.detailConditionFilterControl2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.detailConditionFilterControl2.Location = new System.Drawing.Point(61, 415);
            this.detailConditionFilterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.detailConditionFilterControl2.Name = "detailConditionFilterControl2";
            this.detailConditionFilterControl2.NotificationAppliance = true;
            this.detailConditionFilterControl2.SatisfactoryAppliance = true;
            this.detailConditionFilterControl2.Size = new System.Drawing.Size(327, 64);
            this.detailConditionFilterControl2.TabIndex = 23;
            this.detailConditionFilterControl2.UnsatisfactoryAppliance = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(573, 204);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "More:";
            this.label3.Visible = false;
            // 
            // labelATAChapter
            // 
            this.labelATAChapter.AutoSize = true;
            this.labelATAChapter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelATAChapter.Location = new System.Drawing.Point(11, 101);
            this.labelATAChapter.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.labelATAChapter.Name = "labelATAChapter";
            this.labelATAChapter.Size = new System.Drawing.Size(96, 16);
            this.labelATAChapter.TabIndex = 31;
            this.labelATAChapter.Text = "ATA Chapter:";
            // 
            // textBoxATAChapter
            // 
            this.textBoxATAChapter.Location = new System.Drawing.Point(200, 98);
            this.textBoxATAChapter.Name = "textBoxATAChapter";
            this.textBoxATAChapter.Size = new System.Drawing.Size(339, 23);
            this.textBoxATAChapter.TabIndex = 32;
            this.textBoxATAChapter.Leave += new System.EventHandler(this.textBoxATAChapter_Leave);
            this.textBoxATAChapter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxATAChapter_KeyPress);
            // 
            // checkedListBoxATAChapter
            // 
            this.checkedListBoxATAChapter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.checkedListBoxATAChapter.CheckOnClick = true;
            this.checkedListBoxATAChapter.HorizontalScrollbar = true;
            this.checkedListBoxATAChapter.Location = new System.Drawing.Point(200, 127);
            this.checkedListBoxATAChapter.Name = "checkedListBoxATAChapter";
            this.checkedListBoxATAChapter.Size = new System.Drawing.Size(339, 112);
            this.checkedListBoxATAChapter.Sorted = true;
            this.checkedListBoxATAChapter.TabIndex = 34;
            this.checkedListBoxATAChapter.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxATAChapter_SelectedIndexChanged);
            this.checkedListBoxATAChapter.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxATAChapter_ItemCheck);
            this.checkedListBoxATAChapter.Click += new System.EventHandler(this.checkedListBoxATAChapter_Click);
            // 
            // textBoxPartMask
            // 
            this.textBoxPartMask.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPartMask.Location = new System.Drawing.Point(200, 252);
            this.textBoxPartMask.MaxLength = 30;
            this.textBoxPartMask.Name = "textBoxPartMask";
            this.textBoxPartMask.Size = new System.Drawing.Size(339, 23);
            this.textBoxPartMask.TabIndex = 36;
            this.textBoxPartMask.TextChanged += new System.EventHandler(this.textBoxPartMask_TextChanged);
            // 
            // checkBoxPartFilterAppliance
            // 
            this.checkBoxPartFilterAppliance.AutoSize = true;
            this.checkBoxPartFilterAppliance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPartFilterAppliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPartFilterAppliance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxPartFilterAppliance.Location = new System.Drawing.Point(15, 254);
            this.checkBoxPartFilterAppliance.Name = "checkBoxPartFilterAppliance";
            this.checkBoxPartFilterAppliance.Size = new System.Drawing.Size(110, 20);
            this.checkBoxPartFilterAppliance.TabIndex = 35;
            this.checkBoxPartFilterAppliance.Text = "Part Number:";
            this.checkBoxPartFilterAppliance.UseVisualStyleBackColor = true;
            this.checkBoxPartFilterAppliance.Click += new System.EventHandler(this.checkBoxPartFilterAppliance_Click);
            // 
            // checkBoxUnknown
            // 
            this.checkBoxUnknown.AutoSize = true;
            this.checkBoxUnknown.Checked = true;
            this.checkBoxUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnknown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUnknown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUnknown.Location = new System.Drawing.Point(491, 283);
            this.checkBoxUnknown.Name = "checkBoxUnknown";
            this.checkBoxUnknown.Size = new System.Drawing.Size(45, 20);
            this.checkBoxUnknown.TabIndex = 43;
            this.checkBoxUnknown.Text = "Unk";
            this.checkBoxUnknown.UseVisualStyleBackColor = true;
            // 
            // checkBoxHardTime
            // 
            this.checkBoxHardTime.AutoSize = true;
            this.checkBoxHardTime.Checked = true;
            this.checkBoxHardTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHardTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxHardTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxHardTime.Location = new System.Drawing.Point(299, 283);
            this.checkBoxHardTime.Name = "checkBoxHardTime";
            this.checkBoxHardTime.Size = new System.Drawing.Size(40, 20);
            this.checkBoxHardTime.TabIndex = 42;
            this.checkBoxHardTime.Text = "HT";
            this.checkBoxHardTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxOnCondition
            // 
            this.checkBoxOnCondition.AutoSize = true;
            this.checkBoxOnCondition.Checked = true;
            this.checkBoxOnCondition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnCondition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxOnCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxOnCondition.Location = new System.Drawing.Point(396, 283);
            this.checkBoxOnCondition.Name = "checkBoxOnCondition";
            this.checkBoxOnCondition.Size = new System.Drawing.Size(41, 20);
            this.checkBoxOnCondition.TabIndex = 41;
            this.checkBoxOnCondition.Text = "OC";
            this.checkBoxOnCondition.UseVisualStyleBackColor = true;
            // 
            // checkBoxConditionMonitoring
            // 
            this.checkBoxConditionMonitoring.AutoSize = true;
            this.checkBoxConditionMonitoring.Checked = true;
            this.checkBoxConditionMonitoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxConditionMonitoring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxConditionMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxConditionMonitoring.Location = new System.Drawing.Point(199, 283);
            this.checkBoxConditionMonitoring.Name = "checkBoxConditionMonitoring";
            this.checkBoxConditionMonitoring.Size = new System.Drawing.Size(42, 20);
            this.checkBoxConditionMonitoring.TabIndex = 40;
            this.checkBoxConditionMonitoring.Text = "CM";
            this.checkBoxConditionMonitoring.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 49;
            this.label5.Text = "More:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 285);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Maintenance frequency:";
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(212, 319);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(105, 37);
            this.buttonClear.TabIndex = 52;
            this.buttonClear.Text = "Clear Filter";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 16);
            this.label8.TabIndex = 54;
            this.label8.Text = "Component Status Filter";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(200, 68);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(339, 24);
            this.comboBoxComponent.TabIndex = 56;
            this.comboBoxComponent.SelectedIndexChanged += new System.EventHandler(this.comboBoxComponent_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(12, 319);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(105, 37);
            this.buttonOK.TabIndex = 58;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // landingGearFilterControl1
            // 
            this.landingGearFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.landingGearFilterControl1.FilterAppliance = true;
            this.landingGearFilterControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.landingGearFilterControl1.Location = new System.Drawing.Point(937, 1252);
            this.landingGearFilterControl1.Margin = new System.Windows.Forms.Padding(3, 17, 3, 17);
            this.landingGearFilterControl1.Name = "landingGearFilterControl1";
            this.landingGearFilterControl1.Size = new System.Drawing.Size(337, 347);
            this.landingGearFilterControl1.TabIndex = 10;
            // 
            // avionicsInventoryFilterControl1
            // 
            this.avionicsInventoryFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.avionicsInventoryFilterControl1.FilterAppliance = false;
            this.avionicsInventoryFilterControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.avionicsInventoryFilterControl1.Location = new System.Drawing.Point(898, 862);
            this.avionicsInventoryFilterControl1.Margin = new System.Windows.Forms.Padding(3, 17, 3, 17);
            this.avionicsInventoryFilterControl1.Name = "avionicsInventoryFilterControl1";
            this.avionicsInventoryFilterControl1.Size = new System.Drawing.Size(419, 409);
            this.avionicsInventoryFilterControl1.TabIndex = 9;
            // 
            // checkBoxComponentAppliance
            // 
            this.checkBoxComponentAppliance.AutoSize = true;
            this.checkBoxComponentAppliance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxComponentAppliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxComponentAppliance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxComponentAppliance.Location = new System.Drawing.Point(15, 68);
            this.checkBoxComponentAppliance.Name = "checkBoxComponentAppliance";
            this.checkBoxComponentAppliance.Size = new System.Drawing.Size(102, 20);
            this.checkBoxComponentAppliance.TabIndex = 60;
            this.checkBoxComponentAppliance.Text = "Component:";
            this.checkBoxComponentAppliance.UseVisualStyleBackColor = true;
            // 
            // TemplateDetailFilterSelection
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(554, 369);
            this.Controls.Add(this.checkBoxComponentAppliance);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxUnknown);
            this.Controls.Add(this.checkBoxHardTime);
            this.Controls.Add(this.checkBoxOnCondition);
            this.Controls.Add(this.checkBoxConditionMonitoring);
            this.Controls.Add(this.textBoxPartMask);
            this.Controls.Add(this.checkBoxPartFilterAppliance);
            this.Controls.Add(this.checkedListBoxATAChapter);
            this.Controls.Add(this.textBoxATAChapter);
            this.Controls.Add(this.labelATAChapter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkedListBoxItems);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.landingGearFilterControl1);
            this.Controls.Add(this.avionicsInventoryFilterControl1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateDetailFilterSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetailFilterSelection_FormClosing);
            this.Load += new System.EventHandler(this.DetailFilterSelection_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private PartNoFilterControl partNoFilterControl1;
        private Button buttonClose;
        private AvionicsInventoryFilterControl avionicsInventoryFilterControl1;
        private LandingGearFilterControl landingGearFilterControl1;
        private DetailConditionFilterControl detailConditionFilterControl2;
        private MaintenanceFilterControl maintenanceFilterControl2;
        private Panel panel1;
        private Button buttonApply;
        private ATAChapterFilterControl ataChapterFilterControl1;
        private CheckedListBox checkedListBoxItems;
        private Panel panel2;
        private Label label3;
        private Label labelATAChapter;
        private TextBox textBoxATAChapter;
        private CheckedListBox checkedListBoxATAChapter;
        private TextBox textBoxPartMask;
        private CheckBox checkBoxPartFilterAppliance;
        private CheckBox checkBoxUnknown;
        private CheckBox checkBoxHardTime;
        private CheckBox checkBoxOnCondition;
        private CheckBox checkBoxConditionMonitoring;
        private Label label5;
        private Label label6;
        private Button buttonClear;
        private PictureBox pictureBox1;
        private Label label8;
        private ComboBox comboBoxComponent;
        private Button buttonOK;
        private CheckBox checkBoxComponentAppliance;
    }
}