using System.Drawing;

namespace LTR.UI.UIControls.DetailsControls
{
    partial class DetailInformationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelManufacturer = new System.Windows.Forms.Label();
            this.labelManufactureDate = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.comboBoxAtaChapter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPartNo = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelSerialNo = new System.Windows.Forms.Label();
            this.textBoxSerialNo = new System.Windows.Forms.TextBox();
            this.panelMaintFreq = new System.Windows.Forms.Panel();
            this.radioButtonConditionMonitoring = new System.Windows.Forms.RadioButton();
            this.radioButtonOther = new System.Windows.Forms.RadioButton();
            this.radioButtonHardTime = new System.Windows.Forms.RadioButton();
            this.radioButtonOnCondition = new System.Windows.Forms.RadioButton();
            this.labelAtaChapter = new System.Windows.Forms.Label();
            this.textBoxPartNo = new System.Windows.Forms.TextBox();
            this.labelMaintFreq = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPartNoValue = new System.Windows.Forms.Label();
            this.panel1View = new System.Windows.Forms.Panel();
            this.labelSerialNoValue = new System.Windows.Forms.Label();
            this.labelAtaChapterValue = new System.Windows.Forms.Label();
            this.labelDescriptionValue = new System.Windows.Forms.Label();
            this.labelMaintFreqValue = new System.Windows.Forms.Label();
            this.panel1Edit = new System.Windows.Forms.Panel();
            this.panel2View = new System.Windows.Forms.Panel();
            this.labelRemarksValue = new System.Windows.Forms.Label();
            this.labelManufactureDateValue = new System.Windows.Forms.Label();
            this.labelManufacturerValue = new System.Windows.Forms.Label();
            this.labelModelValue = new System.Windows.Forms.Label();
            this.labelPositionValue = new System.Windows.Forms.Label();
            this.panel2Edit = new System.Windows.Forms.Panel();
            this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.textBoxManufacturer = new System.Windows.Forms.TextBox();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxPosition = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panelMaintFreq.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1View.SuspendLayout();
            this.panel1Edit.SuspendLayout();
            this.panel2View.SuspendLayout();
            this.panel2Edit.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPosition
            // 
            this.labelPosition.Font = defaultFont;
            this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPosition.Location = new System.Drawing.Point(49, 25);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPosition.Size = new System.Drawing.Size(138, 19);
            this.labelPosition.TabIndex = 22;
            this.labelPosition.Text = "Position:";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelModel
            // 
            this.labelModel.Font = defaultFont;
            this.labelModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelModel.Location = new System.Drawing.Point(49, 57);
            this.labelModel.Name = "labelModel";
            this.labelModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelModel.Size = new System.Drawing.Size(138, 19);
            this.labelModel.TabIndex = 23;
            this.labelModel.Text = "Model:";
            this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelManufacturer
            // 
            this.labelManufacturer.Font = defaultFont;
            this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufacturer.Location = new System.Drawing.Point(17, 89);
            this.labelManufacturer.Name = "labelManufacturer";
            this.labelManufacturer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelManufacturer.Size = new System.Drawing.Size(170, 19);
            this.labelManufacturer.TabIndex = 24;
            this.labelManufacturer.Text = "Manufacturer:";
            this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.Font = defaultFont;
            this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufactureDate.Location = new System.Drawing.Point(-26, 121);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelManufactureDate.Size = new System.Drawing.Size(213, 19);
            this.labelManufactureDate.TabIndex = 25;
            this.labelManufactureDate.Text = "Manufacture Date:";
            this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = defaultFont;
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(49, 153);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelRemarks.Size = new System.Drawing.Size(138, 19);
            this.labelRemarks.TabIndex = 26;
            this.labelRemarks.Text = "Remarks:";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxAtaChapter
            // 
            this.comboBoxAtaChapter.BackColor = System.Drawing.Color.White;
            this.comboBoxAtaChapter.Font = defaultFont;
            this.comboBoxAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxAtaChapter.FormattingEnabled = true;
            this.comboBoxAtaChapter.Location = new System.Drawing.Point(12, 86);
            this.comboBoxAtaChapter.Name = "comboBoxAtaChapter";
            this.comboBoxAtaChapter.Size = new System.Drawing.Size(379, 26);
            this.comboBoxAtaChapter.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPartNo);
            this.panel1.Controls.Add(this.panel1View);
            this.panel1.Controls.Add(this.labelSerialNo);
            this.panel1.Controls.Add(this.labelAtaChapter);
            this.panel1.Controls.Add(this.labelMaintFreq);
            this.panel1.Controls.Add(this.labelDescription);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 308);
            this.panel1.TabIndex = 18;
            // 
            // labelPartNo
            // 
            this.labelPartNo.Font = defaultFont;
            this.labelPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPartNo.Location = new System.Drawing.Point(33, 25);
            this.labelPartNo.Name = "labelPartNo";
            this.labelPartNo.Size = new System.Drawing.Size(107, 19);
            this.labelPartNo.TabIndex = 21;
            this.labelPartNo.Text = "Part No:";
            this.labelPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.Font = defaultFont;
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescription.Location = new System.Drawing.Point(12, 118);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(379, 26);
            this.textBoxDescription.TabIndex = 20;
            this.textBoxDescription.Text = "...";
            // 
            // labelSerialNo
            // 
            this.labelSerialNo.Font = defaultFont;
            this.labelSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSerialNo.Location = new System.Drawing.Point(33, 59);
            this.labelSerialNo.Name = "labelSerialNo";
            this.labelSerialNo.Size = new System.Drawing.Size(107, 19);
            this.labelSerialNo.TabIndex = 22;
            this.labelSerialNo.Text = "Serial No:";
            this.labelSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxSerialNo
            // 
            this.textBoxSerialNo.BackColor = System.Drawing.Color.White;
            this.textBoxSerialNo.Font = defaultFont;
            this.textBoxSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxSerialNo.Location = new System.Drawing.Point(12, 54);
            this.textBoxSerialNo.Name = "textBoxSerialNo";
            this.textBoxSerialNo.Size = new System.Drawing.Size(379, 26);
            this.textBoxSerialNo.TabIndex = 18;
            this.textBoxSerialNo.Text = "...";
            // 
            // panelMaintFreq
            // 
            this.panelMaintFreq.Controls.Add(this.radioButtonConditionMonitoring);
            this.panelMaintFreq.Controls.Add(this.radioButtonOther);
            this.panelMaintFreq.Controls.Add(this.radioButtonHardTime);
            this.panelMaintFreq.Controls.Add(this.radioButtonOnCondition);
            this.panelMaintFreq.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelMaintFreq.Location = new System.Drawing.Point(17, 140);
            this.panelMaintFreq.Name = "panelMaintFreq";
            this.panelMaintFreq.Size = new System.Drawing.Size(338, 114);
            this.panelMaintFreq.TabIndex = 13;
            // 
            // radioButtonConditionMonitoring
            // 
            this.radioButtonConditionMonitoring.AutoSize = true;
            this.radioButtonConditionMonitoring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonConditionMonitoring.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.radioButtonConditionMonitoring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.radioButtonConditionMonitoring.Location = new System.Drawing.Point(131, 16);
            this.radioButtonConditionMonitoring.Name = "radioButtonConditionMonitoring";
            this.radioButtonConditionMonitoring.Size = new System.Drawing.Size(193, 22);
            this.radioButtonConditionMonitoring.TabIndex = 1;
            this.radioButtonConditionMonitoring.TabStop = true;
            this.radioButtonConditionMonitoring.Text = "Condition Monitoring";
            this.radioButtonConditionMonitoring.UseVisualStyleBackColor = true;
            // 
            // radioButtonOther
            // 
            this.radioButtonOther.AutoSize = true;
            this.radioButtonOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonOther.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.radioButtonOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.radioButtonOther.Location = new System.Drawing.Point(131, 61);
            this.radioButtonOther.Name = "radioButtonOther";
            this.radioButtonOther.Size = new System.Drawing.Size(73, 22);
            this.radioButtonOther.TabIndex = 3;
            this.radioButtonOther.TabStop = true;
            this.radioButtonOther.Text = "Other";
            this.radioButtonOther.UseVisualStyleBackColor = true;
            // 
            // radioButtonHardTime
            // 
            this.radioButtonHardTime.AutoSize = true;
            this.radioButtonHardTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonHardTime.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.radioButtonHardTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.radioButtonHardTime.Location = new System.Drawing.Point(1, 61);
            this.radioButtonHardTime.Name = "radioButtonHardTime";
            this.radioButtonHardTime.Size = new System.Drawing.Size(110, 22);
            this.radioButtonHardTime.TabIndex = 2;
            this.radioButtonHardTime.TabStop = true;
            this.radioButtonHardTime.Text = "Hard Time";
            this.radioButtonHardTime.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnCondition
            // 
            this.radioButtonOnCondition.AutoSize = true;
            this.radioButtonOnCondition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonOnCondition.Font = new System.Drawing.Font("Verdana", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.radioButtonOnCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(175)))), ((int)(((byte)(204)))));
            this.radioButtonOnCondition.Location = new System.Drawing.Point(1, 16);
            this.radioButtonOnCondition.Name = "radioButtonOnCondition";
            this.radioButtonOnCondition.Size = new System.Drawing.Size(130, 22);
            this.radioButtonOnCondition.TabIndex = 0;
            this.radioButtonOnCondition.TabStop = true;
            this.radioButtonOnCondition.Text = "On Condition";
            this.radioButtonOnCondition.UseVisualStyleBackColor = true;
            // 
            // labelAtaChapter
            // 
            this.labelAtaChapter.Font = defaultFont;
            this.labelAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAtaChapter.Location = new System.Drawing.Point(7, 91);
            this.labelAtaChapter.Name = "labelAtaChapter";
            this.labelAtaChapter.Size = new System.Drawing.Size(133, 19);
            this.labelAtaChapter.TabIndex = 23;
            this.labelAtaChapter.Text = "ATA Chapter:";
            this.labelAtaChapter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPartNo
            // 
            this.textBoxPartNo.BackColor = System.Drawing.Color.White;
            this.textBoxPartNo.Font = defaultFont;
            this.textBoxPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPartNo.Location = new System.Drawing.Point(12, 22);
            this.textBoxPartNo.Name = "textBoxPartNo";
            this.textBoxPartNo.Size = new System.Drawing.Size(379, 26);
            this.textBoxPartNo.TabIndex = 17;
            this.textBoxPartNo.Text = "...";
            // 
            // labelMaintFreq
            // 
            this.labelMaintFreq.Font = defaultFont;
            this.labelMaintFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaintFreq.Location = new System.Drawing.Point(24, 155);
            this.labelMaintFreq.Name = "labelMaintFreq";
            this.labelMaintFreq.Size = new System.Drawing.Size(116, 19);
            this.labelMaintFreq.TabIndex = 25;
            this.labelMaintFreq.Text = "Maint. Freq.:";
            this.labelMaintFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = defaultFont;
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(33, 123);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(107, 19);
            this.labelDescription.TabIndex = 24;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelPosition);
            this.panel2.Controls.Add(this.panel2View);
            this.panel2.Controls.Add(this.labelModel);
            this.panel2.Controls.Add(this.labelManufacturer);
            this.panel2.Controls.Add(this.labelManufactureDate);
            this.panel2.Controls.Add(this.labelRemarks);
            this.panel2.Location = new System.Drawing.Point(554, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 308);
            this.panel2.TabIndex = 19;
            // 
            // labelPartNoValue
            // 
            this.labelPartNoValue.AutoSize = true;
            labelPartNoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPartNoValue.Font = defaultFont;
            this.labelPartNoValue.Location = new System.Drawing.Point(3, 27);
            this.labelPartNoValue.Name = "labelPartNoValue";
            this.labelPartNoValue.Size = new System.Drawing.Size(23, 18);
            this.labelPartNoValue.TabIndex = 20;
            this.labelPartNoValue.Text = "...";
            // 
            // panel1View
            // 
            this.panel1View.Controls.Add(this.labelMaintFreqValue);
            this.panel1View.Controls.Add(this.labelDescriptionValue);
            this.panel1View.Controls.Add(this.labelAtaChapterValue);
            this.panel1View.Controls.Add(this.labelSerialNoValue);
            this.panel1View.Controls.Add(this.labelPartNoValue);
            this.panel1View.Location = new System.Drawing.Point(146, 0);
            this.panel1View.Name = "panel1View";
            this.panel1View.Size = new System.Drawing.Size(399, 308);
            this.panel1View.TabIndex = 21;
            // 
            // labelSerialNoValue
            // 
            this.labelSerialNoValue.AutoSize = true;
            labelSerialNoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSerialNoValue.Font = defaultFont;
            this.labelSerialNoValue.Location = new System.Drawing.Point(3, 59);
            this.labelSerialNoValue.Name = "labelSerialNoValue";
            this.labelSerialNoValue.Size = new System.Drawing.Size(23, 18);
            this.labelSerialNoValue.TabIndex = 21;
            this.labelSerialNoValue.Text = "...";
            // 
            // labelAtaChapterValue
            // 
            this.labelAtaChapterValue.AutoSize = true;
            labelAtaChapterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAtaChapterValue.Font = defaultFont;
            this.labelAtaChapterValue.Location = new System.Drawing.Point(3, 91);
            this.labelAtaChapterValue.Name = "labelAtaChapterValue";
            this.labelAtaChapterValue.Size = new System.Drawing.Size(23, 18);
            this.labelAtaChapterValue.TabIndex = 22;
            this.labelAtaChapterValue.Text = "...";
            // 
            // labelDescriptionValue
            // 
            this.labelDescriptionValue.AutoSize = true;
            labelDescriptionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescriptionValue.Font = defaultFont;
            this.labelDescriptionValue.Location = new System.Drawing.Point(3, 123);
            this.labelDescriptionValue.Name = "labelDescriptionValue";
            this.labelDescriptionValue.Size = new System.Drawing.Size(23, 18);
            this.labelDescriptionValue.TabIndex = 23;
            this.labelDescriptionValue.Text = "...";
            // 
            // labelMaintFreqValue
            // 
            this.labelMaintFreqValue.AutoSize = true;
            labelMaintFreqValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelMaintFreqValue.Font = defaultFont;
            this.labelMaintFreqValue.Location = new System.Drawing.Point(3, 155);
            this.labelMaintFreqValue.Name = "labelMaintFreqValue";
            this.labelMaintFreqValue.Size = new System.Drawing.Size(23, 18);
            this.labelMaintFreqValue.TabIndex = 24;
            this.labelMaintFreqValue.Text = "...";
            // 
            // panel1Edit
            // 
            this.panel1Edit.Controls.Add(this.textBoxPartNo);
            this.panel1Edit.Controls.Add(this.textBoxSerialNo);
            this.panel1Edit.Controls.Add(this.textBoxDescription);
            this.panel1Edit.Controls.Add(this.comboBoxAtaChapter);
            this.panel1Edit.Controls.Add(this.panelMaintFreq);
            this.panel1Edit.Location = new System.Drawing.Point(149, 3);
            this.panel1Edit.Name = "panel1Edit";
            this.panel1Edit.Size = new System.Drawing.Size(416, 359);
            this.panel1Edit.TabIndex = 22;
            this.panel1Edit.Visible = false;
            // 
            // panel2View
            // 
            this.panel2View.Controls.Add(this.labelRemarksValue);
            this.panel2View.Controls.Add(this.labelManufactureDateValue);
            this.panel2View.Controls.Add(this.labelManufacturerValue);
            this.panel2View.Controls.Add(this.labelModelValue);
            this.panel2View.Controls.Add(this.labelPositionValue);
            this.panel2View.Location = new System.Drawing.Point(196, 0);
            this.panel2View.Name = "panel2View";
            this.panel2View.Size = new System.Drawing.Size(417, 308);
            this.panel2View.TabIndex = 23;
            // 
            // labelRemarksValue
            // 
            this.labelRemarksValue.AutoSize = true;
            labelRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarksValue.Font = defaultFont;
            this.labelRemarksValue.Location = new System.Drawing.Point(15, 153);
            this.labelRemarksValue.Name = "labelRemarksValue";
            this.labelRemarksValue.Size = new System.Drawing.Size(23, 18);
            this.labelRemarksValue.TabIndex = 29;
            this.labelRemarksValue.Text = "...";
            // 
            // labelManufactureDateValue
            // 
            this.labelManufactureDateValue.AutoSize = true;
            labelManufactureDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufactureDateValue.Font = defaultFont;
            this.labelManufactureDateValue.Location = new System.Drawing.Point(15, 121);
            this.labelManufactureDateValue.Name = "labelManufactureDateValue";
            this.labelManufactureDateValue.Size = new System.Drawing.Size(23, 18);
            this.labelManufactureDateValue.TabIndex = 28;
            this.labelManufactureDateValue.Text = "...";
            // 
            // labelManufacturerValue
            // 
            this.labelManufacturerValue.AutoSize = true;
            labelManufacturerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufacturerValue.Font = defaultFont;
            this.labelManufacturerValue.Location = new System.Drawing.Point(15, 89);
            this.labelManufacturerValue.Name = "labelManufacturerValue";
            this.labelManufacturerValue.Size = new System.Drawing.Size(23, 18);
            this.labelManufacturerValue.TabIndex = 27;
            this.labelManufacturerValue.Text = "...";
            // 
            // labelModelValue
            // 
            this.labelModelValue.AutoSize = true;
            this.labelModelValue.Font = defaultFont;
            this.labelModelValue.Location = new System.Drawing.Point(15, 57);
            labelModelValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelModelValue.Name = "labelModelValue";
            this.labelModelValue.Size = new System.Drawing.Size(23, 18);
            this.labelModelValue.TabIndex = 26;
            this.labelModelValue.Text = "...";
            // 
            // labelPositionValue
            // 
            this.labelPositionValue.AutoSize = true;
            labelPositionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPositionValue.Font = defaultFont;
            this.labelPositionValue.Location = new System.Drawing.Point(15, 25);
            this.labelPositionValue.Name = "labelPositionValue";
            this.labelPositionValue.Size = new System.Drawing.Size(23, 18);
            this.labelPositionValue.TabIndex = 25;
            this.labelPositionValue.Text = "...";
            // 
            // panel2Edit
            // 
            this.panel2Edit.Controls.Add(this.dateTimePickerManufactureDate);
            this.panel2Edit.Controls.Add(this.textBoxRemarks);
            this.panel2Edit.Controls.Add(this.textBoxManufacturer);
            this.panel2Edit.Controls.Add(this.textBoxModel);
            this.panel2Edit.Controls.Add(this.textBoxPosition);
            this.panel2Edit.Location = new System.Drawing.Point(750, 3);
            this.panel2Edit.Name = "panel2Edit";
            this.panel2Edit.Size = new System.Drawing.Size(432, 359);
            this.panel2Edit.TabIndex = 24;
            this.panel2Edit.Visible = false;
            // 
            // dateTimePickerManufactureDate
            // 
            dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(3, 118);
            this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
            this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerManufactureDate.TabIndex = 28;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.White;
            this.textBoxRemarks.Font = defaultFont;
            this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxRemarks.Location = new System.Drawing.Point(3, 150);
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(417, 26);
            this.textBoxRemarks.TabIndex = 32;
            this.textBoxRemarks.Text = "...";
            // 
            // textBoxManufacturer
            // 
            this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
            this.textBoxManufacturer.Font = defaultFont;
            this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxManufacturer.Location = new System.Drawing.Point(3, 86);
            this.textBoxManufacturer.Name = "textBoxManufacturer";
            this.textBoxManufacturer.Size = new System.Drawing.Size(417, 26);
            this.textBoxManufacturer.TabIndex = 31;
            this.textBoxManufacturer.Text = "...";
            // 
            // textBoxModel
            // 
            this.textBoxModel.BackColor = System.Drawing.Color.White;
            this.textBoxModel.Font = defaultFont;
            this.textBoxModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxModel.Location = new System.Drawing.Point(3, 54);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(417, 26);
            this.textBoxModel.TabIndex = 30;
            this.textBoxModel.Text = "...";
            // 
            // textBoxPosition
            // 
            this.textBoxPosition.BackColor = System.Drawing.Color.White;
            this.textBoxPosition.Font = defaultFont;
            this.textBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPosition.Location = new System.Drawing.Point(3, 22);
            this.textBoxPosition.Name = "textBoxPosition";
            this.textBoxPosition.Size = new System.Drawing.Size(417, 26);
            this.textBoxPosition.TabIndex = 29;
            this.textBoxPosition.Text = "...";
            // 
            // DetailInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.panel2Edit);
            this.Controls.Add(this.panel1Edit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "DetailInformationControl";
            this.Size = new System.Drawing.Size(1185, 620);
            this.panel1.ResumeLayout(false);
            this.panelMaintFreq.ResumeLayout(false);
            this.panelMaintFreq.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1View.ResumeLayout(false);
            this.panel1View.PerformLayout();
            this.panel1Edit.ResumeLayout(false);
            this.panel1Edit.PerformLayout();
            this.panel2View.ResumeLayout(false);
            this.panel2View.PerformLayout();
            this.panel2Edit.ResumeLayout(false);
            this.panel2Edit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelManufacturer;
        private System.Windows.Forms.Label labelManufactureDate;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.ComboBox comboBoxAtaChapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxSerialNo;
        private System.Windows.Forms.TextBox textBoxPartNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMaintFreq;
        private System.Windows.Forms.RadioButton radioButtonConditionMonitoring;
        private System.Windows.Forms.RadioButton radioButtonOther;
        private System.Windows.Forms.RadioButton radioButtonHardTime;
        private System.Windows.Forms.RadioButton radioButtonOnCondition;
        private System.Windows.Forms.Label labelPartNo;
        private System.Windows.Forms.Label labelSerialNo;
        private System.Windows.Forms.Label labelAtaChapter;
        private System.Windows.Forms.Label labelMaintFreq;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelPartNoValue;
        private System.Windows.Forms.Panel panel1View;
        private System.Windows.Forms.Panel panel1Edit;
        private System.Windows.Forms.Label labelMaintFreqValue;
        private System.Windows.Forms.Label labelDescriptionValue;
        private System.Windows.Forms.Label labelAtaChapterValue;
        private System.Windows.Forms.Label labelSerialNoValue;
        private System.Windows.Forms.Panel panel2View;
        private System.Windows.Forms.Panel panel2Edit;
        private System.Windows.Forms.DateTimePicker dateTimePickerManufactureDate;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.TextBox textBoxManufacturer;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxPosition;
        private System.Windows.Forms.Label labelRemarksValue;
        private System.Windows.Forms.Label labelManufactureDateValue;
        private System.Windows.Forms.Label labelManufacturerValue;
        private System.Windows.Forms.Label labelModelValue;
        private System.Windows.Forms.Label labelPositionValue;
    }
}