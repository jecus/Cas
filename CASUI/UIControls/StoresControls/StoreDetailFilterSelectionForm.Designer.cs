using CAS.Core.ProjectTerms;
using ATAChapterFilterControl=CAS.UI.UIControls.FiltersControls.ATAChapterFilterControl;
using AvionicsInventoryFilterControl=CAS.UI.UIControls.FiltersControls.AvionicsInventoryFilterControl;
using DetailConditionFilterControl=CAS.UI.UIControls.FiltersControls.DetailConditionFilterControl;
using LandingGearFilterControl=CAS.UI.UIControls.FiltersControls.LandingGearFilterControl;
using MaintenanceFilterControl=CAS.UI.UIControls.FiltersControls.MaintenanceFilterControl;
using PartNoFilterControl=CAS.UI.UIControls.FiltersControls.PartNoFilterControl;
using SerialNoFilterControl=CAS.UI.UIControls.FiltersControls.SerialNoFilterControl;

namespace CAS.UI.UIControls.StoresControls
{
    partial class StoreDetailFilterSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StoreDetailFilterSelectionForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.serialNoFilterControl1 = new SerialNoFilterControl();
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
            this.textBoxSerialMask = new System.Windows.Forms.TextBox();
            this.checkBoxSerialFilterAppliance = new System.Windows.Forms.CheckBox();
            this.checkBoxUnknown = new System.Windows.Forms.CheckBox();
            this.checkBoxHardTime = new System.Windows.Forms.CheckBox();
            this.checkBoxOnCondition = new System.Windows.Forms.CheckBox();
            this.checkBoxConditionMonitoring = new System.Windows.Forms.CheckBox();
            this.checkBoxNotSatisfactory = new System.Windows.Forms.CheckBox();
            this.checkBoxNotification = new System.Windows.Forms.CheckBox();
            this.checkBoxSatisfactory = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.landingGearFilterControl1 = new LandingGearFilterControl();
            this.avionicsInventoryFilterControl1 = new AvionicsInventoryFilterControl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(435, 346);
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
            this.buttonApply.Location = new System.Drawing.Point(324, 346);
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
            this.panel2.Controls.Add(this.serialNoFilterControl1);
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
            // serialNoFilterControl1
            // 
            this.serialNoFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.serialNoFilterControl1.FilterAppliance = false;
            this.serialNoFilterControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serialNoFilterControl1.Location = new System.Drawing.Point(30, 320);
            this.serialNoFilterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.serialNoFilterControl1.Name = "serialNoFilterControl1";
            this.serialNoFilterControl1.Size = new System.Drawing.Size(358, 26);
            this.serialNoFilterControl1.TabIndex = 1;
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
            this.labelATAChapter.Location = new System.Drawing.Point(12, 55);
            this.labelATAChapter.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.labelATAChapter.Name = "labelATAChapter";
            this.labelATAChapter.Size = new System.Drawing.Size(96, 16);
            this.labelATAChapter.TabIndex = 31;
            this.labelATAChapter.Text = "ATA Chapter:";
            // 
            // textBoxATAChapter
            // 
            this.textBoxATAChapter.Location = new System.Drawing.Point(201, 52);
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
            this.checkedListBoxATAChapter.Location = new System.Drawing.Point(201, 81);
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
            this.textBoxPartMask.Location = new System.Drawing.Point(201, 206);
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
            this.checkBoxPartFilterAppliance.Location = new System.Drawing.Point(16, 208);
            this.checkBoxPartFilterAppliance.Name = "checkBoxPartFilterAppliance";
            this.checkBoxPartFilterAppliance.Size = new System.Drawing.Size(110, 20);
            this.checkBoxPartFilterAppliance.TabIndex = 35;
            this.checkBoxPartFilterAppliance.Text = "Part Number:";
            this.checkBoxPartFilterAppliance.UseVisualStyleBackColor = true;
            this.checkBoxPartFilterAppliance.Click += new System.EventHandler(this.checkBoxPartFilterAppliance_Click);
            // 
            // textBoxSerialMask
            // 
            this.textBoxSerialMask.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSerialMask.Location = new System.Drawing.Point(201, 241);
            this.textBoxSerialMask.MaxLength = 30;
            this.textBoxSerialMask.Name = "textBoxSerialMask";
            this.textBoxSerialMask.Size = new System.Drawing.Size(339, 23);
            this.textBoxSerialMask.TabIndex = 38;
            this.textBoxSerialMask.TextChanged += new System.EventHandler(this.textBoxSerialMask_TextChanged);
            // 
            // checkBoxSerialFilterAppliance
            // 
            this.checkBoxSerialFilterAppliance.AutoSize = true;
            this.checkBoxSerialFilterAppliance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSerialFilterAppliance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSerialFilterAppliance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSerialFilterAppliance.Location = new System.Drawing.Point(16, 243);
            this.checkBoxSerialFilterAppliance.Name = "checkBoxSerialFilterAppliance";
            this.checkBoxSerialFilterAppliance.Size = new System.Drawing.Size(118, 20);
            this.checkBoxSerialFilterAppliance.TabIndex = 37;
            this.checkBoxSerialFilterAppliance.Text = "Serial Number:";
            this.checkBoxSerialFilterAppliance.UseVisualStyleBackColor = true;
            this.checkBoxSerialFilterAppliance.Click += new System.EventHandler(this.checkBoxSerialFilterAppliance_Click);
            // 
            // checkBoxUnknown
            // 
            this.checkBoxUnknown.AutoSize = true;
            this.checkBoxUnknown.Checked = true;
            this.checkBoxUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnknown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUnknown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUnknown.Location = new System.Drawing.Point(494, 277);
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
            this.checkBoxHardTime.Location = new System.Drawing.Point(302, 277);
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
            this.checkBoxOnCondition.Location = new System.Drawing.Point(399, 277);
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
            this.checkBoxConditionMonitoring.Location = new System.Drawing.Point(202, 277);
            this.checkBoxConditionMonitoring.Name = "checkBoxConditionMonitoring";
            this.checkBoxConditionMonitoring.Size = new System.Drawing.Size(42, 20);
            this.checkBoxConditionMonitoring.TabIndex = 40;
            this.checkBoxConditionMonitoring.Text = "CM";
            this.checkBoxConditionMonitoring.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotSatisfactory
            // 
            this.checkBoxNotSatisfactory.AutoSize = true;
            this.checkBoxNotSatisfactory.Checked = true;
            this.checkBoxNotSatisfactory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNotSatisfactory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxNotSatisfactory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNotSatisfactory.Location = new System.Drawing.Point(319, 309);
            this.checkBoxNotSatisfactory.Name = "checkBoxNotSatisfactory";
            this.checkBoxNotSatisfactory.Size = new System.Drawing.Size(100, 20);
            this.checkBoxNotSatisfactory.TabIndex = 47;
            this.checkBoxNotSatisfactory.Text = "Unsatisfacory";
            this.checkBoxNotSatisfactory.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotification
            // 
            this.checkBoxNotification.AutoSize = true;
            this.checkBoxNotification.Checked = true;
            this.checkBoxNotification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxNotification.Location = new System.Drawing.Point(445, 309);
            this.checkBoxNotification.Name = "checkBoxNotification";
            this.checkBoxNotification.Size = new System.Drawing.Size(87, 20);
            this.checkBoxNotification.TabIndex = 46;
            this.checkBoxNotification.Text = "Notification";
            this.checkBoxNotification.UseVisualStyleBackColor = true;
            // 
            // checkBoxSatisfactory
            // 
            this.checkBoxSatisfactory.AutoSize = true;
            this.checkBoxSatisfactory.Checked = true;
            this.checkBoxSatisfactory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSatisfactory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSatisfactory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSatisfactory.Location = new System.Drawing.Point(201, 309);
            this.checkBoxSatisfactory.Name = "checkBoxSatisfactory";
            this.checkBoxSatisfactory.Size = new System.Drawing.Size(91, 20);
            this.checkBoxSatisfactory.TabIndex = 45;
            this.checkBoxSatisfactory.Text = "Satisfactory";
            this.checkBoxSatisfactory.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 81);
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
            this.label6.Location = new System.Drawing.Point(12, 279);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Maintenance frequency:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(13, 311);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 16);
            this.label7.TabIndex = 51;
            this.label7.Text = "Condition Status:";
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(213, 346);
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
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 54;
            this.label8.Text = "Store Filter";
            // 
            // buttonOK
            // 
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Location = new System.Drawing.Point(19, 346);
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
            // StoreDetailFilterSelectionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(555, 400);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxNotSatisfactory);
            this.Controls.Add(this.checkBoxNotification);
            this.Controls.Add(this.checkBoxSatisfactory);
            this.Controls.Add(this.checkBoxUnknown);
            this.Controls.Add(this.checkBoxHardTime);
            this.Controls.Add(this.checkBoxOnCondition);
            this.Controls.Add(this.checkBoxConditionMonitoring);
            this.Controls.Add(this.textBoxSerialMask);
            this.Controls.Add(this.checkBoxSerialFilterAppliance);
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
            this.Name = "StoreDetailFilterSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DetailFilterSelection_FormClosing);
            this.Load += new System.EventHandler(this.DetailFilterSelection_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private SerialNoFilterControl serialNoFilterControl1;
        private PartNoFilterControl partNoFilterControl1;
        //private ATAChapterFilterControl ataChapterFilterControl1;
        private System.Windows.Forms.Button buttonClose;
        private AvionicsInventoryFilterControl avionicsInventoryFilterControl1;
        private LandingGearFilterControl landingGearFilterControl1;
        private DetailConditionFilterControl detailConditionFilterControl2;
        private MaintenanceFilterControl maintenanceFilterControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonApply;
        private ATAChapterFilterControl ataChapterFilterControl1;
        private System.Windows.Forms.CheckedListBox checkedListBoxItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelATAChapter;
        private System.Windows.Forms.TextBox textBoxATAChapter;
        private System.Windows.Forms.CheckedListBox checkedListBoxATAChapter;
        private System.Windows.Forms.TextBox textBoxPartMask;
        private System.Windows.Forms.CheckBox checkBoxPartFilterAppliance;
        private System.Windows.Forms.TextBox textBoxSerialMask;
        private System.Windows.Forms.CheckBox checkBoxSerialFilterAppliance;
        private System.Windows.Forms.CheckBox checkBoxUnknown;
        private System.Windows.Forms.CheckBox checkBoxHardTime;
        private System.Windows.Forms.CheckBox checkBoxOnCondition;
        private System.Windows.Forms.CheckBox checkBoxConditionMonitoring;
        private System.Windows.Forms.CheckBox checkBoxNotSatisfactory;
        private System.Windows.Forms.CheckBox checkBoxNotification;
        private System.Windows.Forms.CheckBox checkBoxSatisfactory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOK;
    }
}