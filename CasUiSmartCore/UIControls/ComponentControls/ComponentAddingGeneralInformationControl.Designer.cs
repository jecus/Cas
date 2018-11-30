using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentAddingGeneralInformationControl
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

            comboBoxModel.SelectedIndexChanged -= DictionaryComboProductSelectedIndexChanged;

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentAddingGeneralInformationControl));
			this.labelMPDItem = new System.Windows.Forms.Label();
			this.labelAtaChapter = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelPartNo = new System.Windows.Forms.Label();
			this.labelSerialNo = new System.Windows.Forms.Label();
			this.labelInstallationData = new System.Windows.Forms.Label();
			this.labelInstallationDate = new System.Windows.Forms.Label();
			this.labelComponentTSNCSN = new System.Windows.Forms.Label();
			this.labelAircraftTSNCSN = new System.Windows.Forms.Label();
			this.labelActualState = new System.Windows.Forms.Label();
			this.labelDateAsOf = new System.Windows.Forms.Label();
			this.labelComponentCurrentTSNCSN = new System.Windows.Forms.Label();
			this.labelTCSI = new System.Windows.Forms.Label();
			this.textBoxMPDItem = new System.Windows.Forms.TextBox();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.textBoxPartNo = new System.Windows.Forms.TextBox();
			this.textBoxSerialNo = new System.Windows.Forms.TextBox();
			this.dateTimePickerInstallationDate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerDateAsOf = new System.Windows.Forms.DateTimePicker();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.dateTimePickerManufactureDate = new System.Windows.Forms.DateTimePicker();
			this.labelDeliveryDate = new System.Windows.Forms.Label();
			this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
			this.labelPosition = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.textBoxPosition = new System.Windows.Forms.TextBox();
			this.textBoxManufacturer = new System.Windows.Forms.TextBox();
			this.labelModel = new System.Windows.Forms.Label();
			this.comboBoxModel = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.textBoxALTPN = new System.Windows.Forms.TextBox();
			this.comboBoxAtaChapter = new CAS.UI.UIControls.Auxiliary.ATAChapterComboBox();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.lifelengthViewerComponentCurrentTSNCSN = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerComponentTCSI = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerComponentTCSNOnInstall = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewerAircraftTCSNOnInstall = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelAltPn = new System.Windows.Forms.Label();
			this.checkBoxLLPMark = new System.Windows.Forms.CheckBox();
			this.comboBoxMaintenenceType = new System.Windows.Forms.ComboBox();
			this.labelMaintenenceType = new System.Windows.Forms.Label();
			this.labelLocation = new System.Windows.Forms.Label();
			this.labelQuantity = new System.Windows.Forms.Label();
			this.comboBoxStorePosition = new System.Windows.Forms.ComboBox();
			this.comboBoxComponentType = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
			this.labelComponentType = new System.Windows.Forms.Label();
			this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
			this.labelBatchNumber = new System.Windows.Forms.Label();
			this.textBoxBatchNumber = new System.Windows.Forms.TextBox();
			this.labelIdNumber = new System.Windows.Forms.Label();
			this.textBoxIdNumber = new System.Windows.Forms.TextBox();
			this.checkBoxPOOL = new System.Windows.Forms.CheckBox();
			this.checkBoxDangerous = new System.Windows.Forms.CheckBox();
			this.labelProductCode = new System.Windows.Forms.Label();
			this.textBoxProductCode = new System.Windows.Forms.TextBox();
			this.comboBoxStatus = new System.Windows.Forms.ComboBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.dictionaryComboBoxLocation = new CAS.UI.UIControls.Auxiliary.DictionaryComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
			this.SuspendLayout();
			// 
			// labelMPDItem
			// 
			this.labelMPDItem.AutoSize = true;
			this.labelMPDItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItem.Location = new System.Drawing.Point(3, 291);
			this.labelMPDItem.Name = "labelMPDItem";
			this.labelMPDItem.Size = new System.Drawing.Size(72, 14);
			this.labelMPDItem.TabIndex = 0;
			this.labelMPDItem.Text = "MPD Item:";
			this.labelMPDItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAtaChapter
			// 
			this.labelAtaChapter.AutoSize = true;
			this.labelAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAtaChapter.Location = new System.Drawing.Point(394, 14);
			this.labelAtaChapter.Name = "labelAtaChapter";
			this.labelAtaChapter.Size = new System.Drawing.Size(90, 14);
			this.labelAtaChapter.TabIndex = 0;
			this.labelAtaChapter.Text = "ATA:";
			this.labelAtaChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(3, 132);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(82, 14);
			this.labelDescription.TabIndex = 0;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPartNo
			// 
			this.labelPartNo.AutoSize = true;
			this.labelPartNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNo.Location = new System.Drawing.Point(3, 63);
			this.labelPartNo.Name = "labelPartNo";
			this.labelPartNo.Size = new System.Drawing.Size(59, 14);
			this.labelPartNo.TabIndex = 0;
			this.labelPartNo.Text = "Part No:";
			this.labelPartNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSerialNo
			// 
			this.labelSerialNo.AutoSize = true;
			this.labelSerialNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNo.Location = new System.Drawing.Point(3, 87);
			this.labelSerialNo.Name = "labelSerialNo";
			this.labelSerialNo.Size = new System.Drawing.Size(68, 14);
			this.labelSerialNo.TabIndex = 0;
			this.labelSerialNo.Text = "Serial No:";
			this.labelSerialNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelInstallationData
			// 
			this.labelInstallationData.AutoSize = true;
			this.labelInstallationData.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelInstallationData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInstallationData.Location = new System.Drawing.Point(490, 122);
			this.labelInstallationData.Name = "labelInstallationData";
			this.labelInstallationData.Size = new System.Drawing.Size(136, 17);
			this.labelInstallationData.TabIndex = 0;
			this.labelInstallationData.Text = "Installation Data";
			this.labelInstallationData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelInstallationDate
			// 
			this.labelInstallationDate.AutoSize = true;
			this.labelInstallationDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelInstallationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInstallationDate.Location = new System.Drawing.Point(393, 207);
			this.labelInstallationDate.Name = "labelInstallationDate";
			this.labelInstallationDate.Size = new System.Drawing.Size(89, 14);
			this.labelInstallationDate.TabIndex = 0;
			this.labelInstallationDate.Text = "Install. Date:";
			this.labelInstallationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelComponentTSNCSN
			// 
			this.labelComponentTSNCSN.AutoSize = true;
			this.labelComponentTSNCSN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComponentTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComponentTSNCSN.Location = new System.Drawing.Point(394, 240);
			this.labelComponentTSNCSN.Name = "labelComponentTSNCSN";
			this.labelComponentTSNCSN.Size = new System.Drawing.Size(239, 14);
			this.labelComponentTSNCSN.TabIndex = 0;
			this.labelComponentTSNCSN.Text = "Component TSN/CSN on Installation:";
			this.labelComponentTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTSNCSN
			// 
			this.labelAircraftTSNCSN.AutoSize = true;
			this.labelAircraftTSNCSN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTSNCSN.Location = new System.Drawing.Point(394, 319);
			this.labelAircraftTSNCSN.Name = "labelAircraftTSNCSN";
			this.labelAircraftTSNCSN.Size = new System.Drawing.Size(210, 14);
			this.labelAircraftTSNCSN.TabIndex = 0;
			this.labelAircraftTSNCSN.Text = "Aircraft TSN/CSN on Installation:";
			this.labelAircraftTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelActualState
			// 
			this.labelActualState.AutoSize = true;
			this.labelActualState.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelActualState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelActualState.Location = new System.Drawing.Point(793, 122);
			this.labelActualState.Name = "labelActualState";
			this.labelActualState.Size = new System.Drawing.Size(101, 17);
			this.labelActualState.TabIndex = 0;
			this.labelActualState.Text = "Actual State";
			this.labelActualState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDateAsOf
			// 
			this.labelDateAsOf.AutoSize = true;
			this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateAsOf.Location = new System.Drawing.Point(790, 178);
			this.labelDateAsOf.Name = "labelDateAsOf";
			this.labelDateAsOf.Size = new System.Drawing.Size(79, 14);
			this.labelDateAsOf.TabIndex = 0;
			this.labelDateAsOf.Text = "Date As Of:";
			this.labelDateAsOf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelComponentCurrentTSNCSN
			// 
			this.labelComponentCurrentTSNCSN.AutoSize = true;
			this.labelComponentCurrentTSNCSN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComponentCurrentTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComponentCurrentTSNCSN.Location = new System.Drawing.Point(793, 240);
			this.labelComponentCurrentTSNCSN.Name = "labelComponentCurrentTSNCSN";
			this.labelComponentCurrentTSNCSN.Size = new System.Drawing.Size(193, 14);
			this.labelComponentCurrentTSNCSN.TabIndex = 0;
			this.labelComponentCurrentTSNCSN.Text = "Component current TSN/CSN:";
			this.labelComponentCurrentTSNCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTCSI
			// 
			this.labelTCSI.AutoSize = true;
			this.labelTCSI.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelTCSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTCSI.Location = new System.Drawing.Point(793, 319);
			this.labelTCSI.Name = "labelTCSI";
			this.labelTCSI.Size = new System.Drawing.Size(259, 14);
			this.labelTCSI.TabIndex = 0;
			this.labelTCSI.Text = "Component TSN/CSN  since Installation:";
			this.labelTCSI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxMPDItem
			// 
			this.textBoxMPDItem.BackColor = System.Drawing.Color.White;
			this.textBoxMPDItem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxMPDItem.Location = new System.Drawing.Point(103, 288);
			this.textBoxMPDItem.MaxLength = 50;
			this.textBoxMPDItem.Name = "textBoxMPDItem";
			this.textBoxMPDItem.Size = new System.Drawing.Size(250, 22);
			this.textBoxMPDItem.TabIndex = 8;
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.BackColor = System.Drawing.Color.White;
			this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxDescription.Location = new System.Drawing.Point(103, 132);
			this.textBoxDescription.MaxLength = 250;
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxDescription.Size = new System.Drawing.Size(250, 88);
			this.textBoxDescription.TabIndex = 5;
			// 
			// textBoxPartNo
			// 
			this.textBoxPartNo.BackColor = System.Drawing.Color.White;
			this.textBoxPartNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPartNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPartNo.Location = new System.Drawing.Point(103, 59);
			this.textBoxPartNo.MaxLength = 100;
			this.textBoxPartNo.Name = "textBoxPartNo";
			this.textBoxPartNo.Size = new System.Drawing.Size(250, 22);
			this.textBoxPartNo.TabIndex = 2;
			// 
			// textBoxSerialNo
			// 
			this.textBoxSerialNo.BackColor = System.Drawing.Color.White;
			this.textBoxSerialNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSerialNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxSerialNo.Location = new System.Drawing.Point(103, 84);
			this.textBoxSerialNo.MaxLength = 100;
			this.textBoxSerialNo.Name = "textBoxSerialNo";
			this.textBoxSerialNo.Size = new System.Drawing.Size(250, 22);
			this.textBoxSerialNo.TabIndex = 3;
			// 
			// dateTimePickerInstallationDate
			// 
			this.dateTimePickerInstallationDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerInstallationDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerInstallationDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerInstallationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerInstallationDate.Location = new System.Drawing.Point(499, 201);
			this.dateTimePickerInstallationDate.Name = "dateTimePickerInstallationDate";
			this.dateTimePickerInstallationDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerInstallationDate.TabIndex = 20;
			this.dateTimePickerInstallationDate.ValueChanged += new System.EventHandler(this.DateTimePickerInstallationDateValueChanged);
			// 
			// dateTimePickerDateAsOf
			// 
			this.dateTimePickerDateAsOf.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDateAsOf.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDateAsOf.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDateAsOf.Location = new System.Drawing.Point(897, 173);
			this.dateTimePickerDateAsOf.Name = "dateTimePickerDateAsOf";
			this.dateTimePickerDateAsOf.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerDateAsOf.TabIndex = 27;
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDate.Location = new System.Drawing.Point(394, 150);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(88, 14);
			this.labelManufactureDate.TabIndex = 0;
			this.labelManufactureDate.Text = "Manuf. Date:";
			this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerManufactureDate
			// 
			this.dateTimePickerManufactureDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerManufactureDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerManufactureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerManufactureDate.Location = new System.Drawing.Point(499, 144);
			this.dateTimePickerManufactureDate.Name = "dateTimePickerManufactureDate";
			this.dateTimePickerManufactureDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerManufactureDate.TabIndex = 18;
			this.dateTimePickerManufactureDate.ValueChanged += new System.EventHandler(this.DateTimePickerManufactureDateValueChanged);
			// 
			// labelDeliveryDate
			// 
			this.labelDeliveryDate.AutoSize = true;
			this.labelDeliveryDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDeliveryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDeliveryDate.Location = new System.Drawing.Point(394, 178);
			this.labelDeliveryDate.Name = "labelDeliveryDate";
			this.labelDeliveryDate.Size = new System.Drawing.Size(96, 14);
			this.labelDeliveryDate.TabIndex = 0;
			this.labelDeliveryDate.Text = "Delivery Date:";
			this.labelDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dateTimePickerDeliveryDate
			// 
			this.dateTimePickerDeliveryDate.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDeliveryDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.dateTimePickerDeliveryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(499, 173);
			this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
			this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(250, 22);
			this.dateTimePickerDeliveryDate.TabIndex = 19;
			// 
			// labelPosition
			// 
			this.labelPosition.AutoSize = true;
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPosition.Location = new System.Drawing.Point(3, 347);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelPosition.Size = new System.Drawing.Size(62, 14);
			this.labelPosition.TabIndex = 0;
			this.labelPosition.Text = "Position:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.AutoSize = true;
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(3, 40);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(95, 14);
			this.labelManufacturer.TabIndex = 0;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxPosition
			// 
			this.textBoxPosition.BackColor = System.Drawing.Color.White;
			this.textBoxPosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxPosition.Location = new System.Drawing.Point(103, 344);
			this.textBoxPosition.Name = "textBoxPosition";
			this.textBoxPosition.Size = new System.Drawing.Size(250, 22);
			this.textBoxPosition.TabIndex = 10;
			// 
			// textBoxManufacturer
			// 
			this.textBoxManufacturer.BackColor = System.Drawing.Color.White;
			this.textBoxManufacturer.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxManufacturer.Location = new System.Drawing.Point(103, 35);
			this.textBoxManufacturer.MaxLength = 100;
			this.textBoxManufacturer.Name = "textBoxManufacturer";
			this.textBoxManufacturer.Size = new System.Drawing.Size(250, 22);
			this.textBoxManufacturer.TabIndex = 1;
			// 
			// labelModel
			// 
			this.labelModel.AutoSize = true;
			this.labelModel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelModel.Location = new System.Drawing.Point(3, 14);
			this.labelModel.Name = "labelModel";
			this.labelModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelModel.Size = new System.Drawing.Size(49, 14);
			this.labelModel.TabIndex = 0;
			this.labelModel.Text = "Model:";
			this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxModel
			// 
			this.comboBoxModel.Displayer = null;
			this.comboBoxModel.DisplayerText = null;
			this.comboBoxModel.Entity = null;
			this.comboBoxModel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxModel.Location = new System.Drawing.Point(103, 9);
			this.comboBoxModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.comboBoxModel.Name = "comboBoxModel";
			this.comboBoxModel.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxModel.Size = new System.Drawing.Size(250, 22);
			this.comboBoxModel.TabIndex = 0;
			this.comboBoxModel.Type = null;
			this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboProductSelectedIndexChanged);
			// 
			// textBoxALTPN
			// 
			this.textBoxALTPN.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxALTPN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxALTPN.Location = new System.Drawing.Point(103, 260);
			this.textBoxALTPN.MaxLength = 200;
			this.textBoxALTPN.Name = "textBoxALTPN";
			this.textBoxALTPN.Size = new System.Drawing.Size(250, 22);
			this.textBoxALTPN.TabIndex = 7;
			// 
			// comboBoxAtaChapter
			// 
			this.comboBoxAtaChapter.BackColor = System.Drawing.Color.White;
			this.comboBoxAtaChapter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxAtaChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxAtaChapter.Location = new System.Drawing.Point(499, 9);
			this.comboBoxAtaChapter.Name = "comboBoxAtaChapter";
			this.comboBoxAtaChapter.Size = new System.Drawing.Size(250, 22);
			this.comboBoxAtaChapter.TabIndex = 14;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(385, 10);
			this.delimiter1.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter1.Size = new System.Drawing.Size(1, 365);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 16;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(785, 10);
			this.delimiter2.Margin = new System.Windows.Forms.Padding(4);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 365);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 19;
			// 
			// lifelengthViewerComponentCurrentTSNCSN
			// 
			this.lifelengthViewerComponentCurrentTSNCSN.AutoSize = true;
			this.lifelengthViewerComponentCurrentTSNCSN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerComponentCurrentTSNCSN.CalendarApplicable = false;
			this.lifelengthViewerComponentCurrentTSNCSN.CyclesApplicable = false;
			this.lifelengthViewerComponentCurrentTSNCSN.EnabledCalendar = false;
			this.lifelengthViewerComponentCurrentTSNCSN.EnabledCycle = true;
			this.lifelengthViewerComponentCurrentTSNCSN.EnabledHours = true;
			this.lifelengthViewerComponentCurrentTSNCSN.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerComponentCurrentTSNCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerComponentCurrentTSNCSN.HeaderCalendar = "Calendar";
			this.lifelengthViewerComponentCurrentTSNCSN.HeaderCycles = "Cycles";
			this.lifelengthViewerComponentCurrentTSNCSN.HeaderHours = "Hours";
			this.lifelengthViewerComponentCurrentTSNCSN.HoursApplicable = false;
			this.lifelengthViewerComponentCurrentTSNCSN.LeftHeader = "Left";
			this.lifelengthViewerComponentCurrentTSNCSN.Location = new System.Drawing.Point(793, 265);
			this.lifelengthViewerComponentCurrentTSNCSN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerComponentCurrentTSNCSN.Modified = false;
			this.lifelengthViewerComponentCurrentTSNCSN.Name = "lifelengthViewerComponentCurrentTSNCSN";
			this.lifelengthViewerComponentCurrentTSNCSN.ReadOnly = false;
			this.lifelengthViewerComponentCurrentTSNCSN.ShowCalendar = true;
			this.lifelengthViewerComponentCurrentTSNCSN.ShowLeftHeader = false;
			this.lifelengthViewerComponentCurrentTSNCSN.ShowMinutes = false;
			this.lifelengthViewerComponentCurrentTSNCSN.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
			this.lifelengthViewerComponentCurrentTSNCSN.TabIndex = 28;
			this.lifelengthViewerComponentCurrentTSNCSN.LifelengthChanged += new System.EventHandler(this.LifelengthViewerComponentCurrentTsncsnLifelengthChanged);
			// 
			// lifelengthViewerComponentTCSI
			// 
			this.lifelengthViewerComponentTCSI.AutoSize = true;
			this.lifelengthViewerComponentTCSI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerComponentTCSI.CalendarApplicable = false;
			this.lifelengthViewerComponentTCSI.CyclesApplicable = false;
			this.lifelengthViewerComponentTCSI.EnabledCalendar = false;
			this.lifelengthViewerComponentTCSI.EnabledCycle = true;
			this.lifelengthViewerComponentTCSI.EnabledHours = true;
			this.lifelengthViewerComponentTCSI.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerComponentTCSI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerComponentTCSI.HeaderCalendar = "Calendar";
			this.lifelengthViewerComponentTCSI.HeaderCycles = "Cycles";
			this.lifelengthViewerComponentTCSI.HeaderHours = "Hours";
			this.lifelengthViewerComponentTCSI.HoursApplicable = false;
			this.lifelengthViewerComponentTCSI.LeftHeader = "Left";
			this.lifelengthViewerComponentTCSI.Location = new System.Drawing.Point(793, 348);
			this.lifelengthViewerComponentTCSI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerComponentTCSI.Modified = false;
			this.lifelengthViewerComponentTCSI.Name = "lifelengthViewerComponentTCSI";
			this.lifelengthViewerComponentTCSI.ReadOnly = false;
			this.lifelengthViewerComponentTCSI.ShowCalendar = true;
			this.lifelengthViewerComponentTCSI.ShowLeftHeader = false;
			this.lifelengthViewerComponentTCSI.ShowMinutes = false;
			this.lifelengthViewerComponentTCSI.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerComponentTCSI.SystemCalculated = true;
			this.lifelengthViewerComponentTCSI.TabIndex = 29;
			this.lifelengthViewerComponentTCSI.LifelengthChanged += new System.EventHandler(this.LifelengthViewerComponentTcsiLifelengthChanged);
			// 
			// lifelengthViewerComponentTCSNOnInstall
			// 
			this.lifelengthViewerComponentTCSNOnInstall.AutoSize = true;
			this.lifelengthViewerComponentTCSNOnInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerComponentTCSNOnInstall.CalendarApplicable = false;
			this.lifelengthViewerComponentTCSNOnInstall.CyclesApplicable = false;
			this.lifelengthViewerComponentTCSNOnInstall.EnabledCalendar = false;
			this.lifelengthViewerComponentTCSNOnInstall.EnabledCycle = true;
			this.lifelengthViewerComponentTCSNOnInstall.EnabledHours = true;
			this.lifelengthViewerComponentTCSNOnInstall.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerComponentTCSNOnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerComponentTCSNOnInstall.HeaderCalendar = "Calendar";
			this.lifelengthViewerComponentTCSNOnInstall.HeaderCycles = "Cycles";
			this.lifelengthViewerComponentTCSNOnInstall.HeaderHours = "Hours";
			this.lifelengthViewerComponentTCSNOnInstall.HoursApplicable = false;
			this.lifelengthViewerComponentTCSNOnInstall.LeftHeader = "Left";
			this.lifelengthViewerComponentTCSNOnInstall.Location = new System.Drawing.Point(397, 265);
			this.lifelengthViewerComponentTCSNOnInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerComponentTCSNOnInstall.Modified = false;
			this.lifelengthViewerComponentTCSNOnInstall.Name = "lifelengthViewerComponentTCSNOnInstall";
			this.lifelengthViewerComponentTCSNOnInstall.ReadOnly = false;
			this.lifelengthViewerComponentTCSNOnInstall.ShowCalendar = true;
			this.lifelengthViewerComponentTCSNOnInstall.ShowLeftHeader = false;
			this.lifelengthViewerComponentTCSNOnInstall.ShowMinutes = false;
			this.lifelengthViewerComponentTCSNOnInstall.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;
			this.lifelengthViewerComponentTCSNOnInstall.TabIndex = 21;
			this.lifelengthViewerComponentTCSNOnInstall.LifelengthChanged += new System.EventHandler(this.LifelengthViewerComponentTsncsnLifelengthChanged);
			// 
			// lifelengthViewerAircraftTCSNOnInstall
			// 
			this.lifelengthViewerAircraftTCSNOnInstall.AutoSize = true;
			this.lifelengthViewerAircraftTCSNOnInstall.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewerAircraftTCSNOnInstall.CalendarApplicable = false;
			this.lifelengthViewerAircraftTCSNOnInstall.CyclesApplicable = false;
			this.lifelengthViewerAircraftTCSNOnInstall.EnabledCalendar = false;
			this.lifelengthViewerAircraftTCSNOnInstall.EnabledCycle = true;
			this.lifelengthViewerAircraftTCSNOnInstall.EnabledHours = true;
			this.lifelengthViewerAircraftTCSNOnInstall.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewerAircraftTCSNOnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.lifelengthViewerAircraftTCSNOnInstall.HeaderCalendar = "Calendar";
			this.lifelengthViewerAircraftTCSNOnInstall.HeaderCycles = "Cycles";
			this.lifelengthViewerAircraftTCSNOnInstall.HeaderHours = "Hours";
			this.lifelengthViewerAircraftTCSNOnInstall.HoursApplicable = false;
			this.lifelengthViewerAircraftTCSNOnInstall.LeftHeader = "Left";
			this.lifelengthViewerAircraftTCSNOnInstall.Location = new System.Drawing.Point(396, 348);
			this.lifelengthViewerAircraftTCSNOnInstall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lifelengthViewerAircraftTCSNOnInstall.Modified = false;
			this.lifelengthViewerAircraftTCSNOnInstall.Name = "lifelengthViewerAircraftTCSNOnInstall";
			this.lifelengthViewerAircraftTCSNOnInstall.ReadOnly = false;
			this.lifelengthViewerAircraftTCSNOnInstall.ShowCalendar = true;
			this.lifelengthViewerAircraftTCSNOnInstall.ShowLeftHeader = false;
			this.lifelengthViewerAircraftTCSNOnInstall.ShowMinutes = false;
			this.lifelengthViewerAircraftTCSNOnInstall.Size = new System.Drawing.Size(354, 52);
			this.lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = true;
			this.lifelengthViewerAircraftTCSNOnInstall.TabIndex = 22;
			this.lifelengthViewerAircraftTCSNOnInstall.LifelengthChanged += new System.EventHandler(this.LifelengthViewerAircraftTcsnOnInstallLifelengthChanged);
			// 
			// labelAltPn
			// 
			this.labelAltPn.AutoSize = true;
			this.labelAltPn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAltPn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAltPn.Location = new System.Drawing.Point(3, 263);
			this.labelAltPn.Name = "labelAltPn";
			this.labelAltPn.Size = new System.Drawing.Size(60, 14);
			this.labelAltPn.TabIndex = 0;
			this.labelAltPn.Text = "ALT P/N:";
			this.labelAltPn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// checkBoxLLPMark
			// 
			this.checkBoxLLPMark.AutoSize = true;
			this.checkBoxLLPMark.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxLLPMark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxLLPMark.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxLLPMark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxLLPMark.Location = new System.Drawing.Point(795, 12);
			this.checkBoxLLPMark.Name = "checkBoxLLPMark";
			this.checkBoxLLPMark.Size = new System.Drawing.Size(91, 18);
			this.checkBoxLLPMark.TabIndex = 23;
			this.checkBoxLLPMark.Text = "Is LLP Disk";
			this.checkBoxLLPMark.CheckedChanged += new System.EventHandler(this.CheckBoxLLPMarkCheckedChanged);
			// 
			// comboBoxMaintenenceType
			// 
			this.comboBoxMaintenenceType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxMaintenenceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxMaintenenceType.FormattingEnabled = true;
			this.comboBoxMaintenenceType.Location = new System.Drawing.Point(898, 35);
			this.comboBoxMaintenenceType.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxMaintenenceType.Name = "comboBoxMaintenenceType";
			this.comboBoxMaintenenceType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxMaintenenceType.TabIndex = 24;
			// 
			// labelMaintenenceType
			// 
			this.labelMaintenenceType.AutoSize = true;
			this.labelMaintenenceType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaintenenceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaintenenceType.Location = new System.Drawing.Point(793, 40);
			this.labelMaintenenceType.Name = "labelMaintenenceType";
			this.labelMaintenenceType.Size = new System.Drawing.Size(85, 14);
			this.labelMaintenenceType.TabIndex = 0;
			this.labelMaintenenceType.Text = "Maint. Proc.:";
			this.labelMaintenenceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelLocation
			// 
			this.labelLocation.AutoSize = true;
			this.labelLocation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLocation.Location = new System.Drawing.Point(3, 403);
			this.labelLocation.Name = "labelLocation";
			this.labelLocation.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelLocation.Size = new System.Drawing.Size(65, 14);
			this.labelLocation.TabIndex = 79;
			this.labelLocation.Text = "Location:";
			this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelLocation.Visible = false;
			// 
			// labelQuantity
			// 
			this.labelQuantity.AutoSize = true;
			this.labelQuantity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelQuantity.Location = new System.Drawing.Point(793, 94);
			this.labelQuantity.Name = "labelQuantity";
			this.labelQuantity.Size = new System.Drawing.Size(66, 14);
			this.labelQuantity.TabIndex = 83;
			this.labelQuantity.Text = "Quantity:";
			this.labelQuantity.Visible = false;
			// 
			// comboBoxStorePosition
			// 
			this.comboBoxStorePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStorePosition.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStorePosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStorePosition.FormattingEnabled = true;
			this.comboBoxStorePosition.Location = new System.Drawing.Point(498, 97);
			this.comboBoxStorePosition.Name = "comboBoxStorePosition";
			this.comboBoxStorePosition.Size = new System.Drawing.Size(250, 22);
			this.comboBoxStorePosition.TabIndex = 11;
			this.comboBoxStorePosition.Visible = false;
			// 
			// comboBoxComponentType
			// 
			this.comboBoxComponentType.Displayer = null;
			this.comboBoxComponentType.DisplayerText = null;
			this.comboBoxComponentType.DropDownHeight = 106;
			this.comboBoxComponentType.Entity = null;
			this.comboBoxComponentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxComponentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxComponentType.Location = new System.Drawing.Point(898, 63);
			this.comboBoxComponentType.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxComponentType.Name = "comboBoxComponentType";
			this.comboBoxComponentType.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.comboBoxComponentType.RootNodesNames = null;
			this.comboBoxComponentType.Size = new System.Drawing.Size(250, 22);
			this.comboBoxComponentType.TabIndex = 25;
			this.comboBoxComponentType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxComponentTypeSelectedIndexChanged);
			// 
			// labelComponentType
			// 
			this.labelComponentType.AutoSize = true;
			this.labelComponentType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelComponentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelComponentType.Location = new System.Drawing.Point(793, 66);
			this.labelComponentType.Name = "labelComponentType";
			this.labelComponentType.Size = new System.Drawing.Size(46, 14);
			this.labelComponentType.TabIndex = 82;
			this.labelComponentType.Text = "Class:";
			// 
			// numericUpDownQuantity
			// 
			this.numericUpDownQuantity.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.numericUpDownQuantity.Location = new System.Drawing.Point(898, 91);
			this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownQuantity.Name = "numericUpDownQuantity";
			this.numericUpDownQuantity.Size = new System.Drawing.Size(252, 22);
			this.numericUpDownQuantity.TabIndex = 26;
			this.numericUpDownQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownQuantity.Visible = false;
			// 
			// labelBatchNumber
			// 
			this.labelBatchNumber.AutoSize = true;
			this.labelBatchNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBatchNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBatchNumber.Location = new System.Drawing.Point(3, 235);
			this.labelBatchNumber.Name = "labelBatchNumber";
			this.labelBatchNumber.Size = new System.Drawing.Size(68, 14);
			this.labelBatchNumber.TabIndex = 85;
			this.labelBatchNumber.Text = "Batch No:";
			this.labelBatchNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxBatchNumber
			// 
			this.textBoxBatchNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxBatchNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxBatchNumber.Location = new System.Drawing.Point(103, 232);
			this.textBoxBatchNumber.MaxLength = 200;
			this.textBoxBatchNumber.Name = "textBoxBatchNumber";
			this.textBoxBatchNumber.Size = new System.Drawing.Size(250, 22);
			this.textBoxBatchNumber.TabIndex = 6;
			// 
			// labelIdNumber
			// 
			this.labelIdNumber.AutoSize = true;
			this.labelIdNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelIdNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelIdNumber.Location = new System.Drawing.Point(3, 319);
			this.labelIdNumber.Name = "labelIdNumber";
			this.labelIdNumber.Size = new System.Drawing.Size(47, 14);
			this.labelIdNumber.TabIndex = 84;
			this.labelIdNumber.Text = "ID No:";
			this.labelIdNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxIdNumber
			// 
			this.textBoxIdNumber.BackColor = System.Drawing.Color.White;
			this.textBoxIdNumber.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxIdNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxIdNumber.Location = new System.Drawing.Point(103, 316);
			this.textBoxIdNumber.MaxLength = 50;
			this.textBoxIdNumber.Name = "textBoxIdNumber";
			this.textBoxIdNumber.Size = new System.Drawing.Size(250, 22);
			this.textBoxIdNumber.TabIndex = 9;
			// 
			// checkBoxPOOL
			// 
			this.checkBoxPOOL.AutoSize = true;
			this.checkBoxPOOL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxPOOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxPOOL.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxPOOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxPOOL.Location = new System.Drawing.Point(897, 12);
			this.checkBoxPOOL.Name = "checkBoxPOOL";
			this.checkBoxPOOL.Size = new System.Drawing.Size(74, 18);
			this.checkBoxPOOL.TabIndex = 86;
			this.checkBoxPOOL.Text = "Is POOL";
			// 
			// checkBoxDangerous
			// 
			this.checkBoxDangerous.AutoSize = true;
			this.checkBoxDangerous.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxDangerous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxDangerous.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxDangerous.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxDangerous.Location = new System.Drawing.Point(977, 12);
			this.checkBoxDangerous.Name = "checkBoxDangerous";
			this.checkBoxDangerous.Size = new System.Drawing.Size(108, 18);
			this.checkBoxDangerous.TabIndex = 87;
			this.checkBoxDangerous.Text = "Is Dangerous";
			// 
			// labelProductCode
			// 
			this.labelProductCode.AutoSize = true;
			this.labelProductCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProductCode.Location = new System.Drawing.Point(3, 111);
			this.labelProductCode.Name = "labelProductCode";
			this.labelProductCode.Size = new System.Drawing.Size(45, 14);
			this.labelProductCode.TabIndex = 88;
			this.labelProductCode.Text = "Code:";
			this.labelProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxProductCode
			// 
			this.textBoxProductCode.BackColor = System.Drawing.Color.White;
			this.textBoxProductCode.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxProductCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxProductCode.Location = new System.Drawing.Point(103, 108);
			this.textBoxProductCode.MaxLength = 100;
			this.textBoxProductCode.Name = "textBoxProductCode";
			this.textBoxProductCode.Size = new System.Drawing.Size(250, 22);
			this.textBoxProductCode.TabIndex = 4;
			// 
			// comboBoxStatus
			// 
			this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxStatus.FormattingEnabled = true;
			this.comboBoxStatus.Location = new System.Drawing.Point(103, 372);
			this.comboBoxStatus.Name = "comboBoxStatus";
			this.comboBoxStatus.Size = new System.Drawing.Size(250, 22);
			this.comboBoxStatus.TabIndex = 90;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelStatus.Location = new System.Drawing.Point(3, 375);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.labelStatus.Size = new System.Drawing.Size(53, 14);
			this.labelStatus.TabIndex = 91;
			this.labelStatus.Text = "Status:";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dictionaryComboBoxLocation
			// 
			this.dictionaryComboBoxLocation.Displayer = null;
			this.dictionaryComboBoxLocation.DisplayerText = null;
			this.dictionaryComboBoxLocation.Entity = null;
			this.dictionaryComboBoxLocation.Location = new System.Drawing.Point(103, 401);
			this.dictionaryComboBoxLocation.Name = "dictionaryComboBoxLocation";
			this.dictionaryComboBoxLocation.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.dictionaryComboBoxLocation.Size = new System.Drawing.Size(250, 21);
			this.dictionaryComboBoxLocation.TabIndex = 92;
			this.dictionaryComboBoxLocation.Visible = false;
			// 
			// ComponentAddingGeneralInformationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.dictionaryComboBoxLocation);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.comboBoxStatus);
			this.Controls.Add(this.labelProductCode);
			this.Controls.Add(this.textBoxProductCode);
			this.Controls.Add(this.checkBoxDangerous);
			this.Controls.Add(this.checkBoxPOOL);
			this.Controls.Add(this.labelBatchNumber);
			this.Controls.Add(this.textBoxBatchNumber);
			this.Controls.Add(this.labelIdNumber);
			this.Controls.Add(this.textBoxIdNumber);
			this.Controls.Add(this.labelQuantity);
			this.Controls.Add(this.comboBoxComponentType);
			this.Controls.Add(this.labelComponentType);
			this.Controls.Add(this.numericUpDownQuantity);
			this.Controls.Add(this.labelLocation);
			this.Controls.Add(this.labelMaintenenceType);
			this.Controls.Add(this.comboBoxMaintenenceType);
			this.Controls.Add(this.checkBoxLLPMark);
			this.Controls.Add(this.comboBoxStorePosition);
			this.Controls.Add(this.labelAltPn);
			this.Controls.Add(this.textBoxALTPN);
			this.Controls.Add(this.labelModel);
			this.Controls.Add(this.comboBoxModel);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.textBoxPosition);
			this.Controls.Add(this.textBoxManufacturer);
			this.Controls.Add(this.labelDeliveryDate);
			this.Controls.Add(this.dateTimePickerDeliveryDate);
			this.Controls.Add(this.labelManufactureDate);
			this.Controls.Add(this.dateTimePickerManufactureDate);
			this.Controls.Add(this.labelMPDItem);
			this.Controls.Add(this.textBoxMPDItem);
			this.Controls.Add(this.labelAtaChapter);
			this.Controls.Add(this.comboBoxAtaChapter);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelPartNo);
			this.Controls.Add(this.textBoxPartNo);
			this.Controls.Add(this.labelSerialNo);
			this.Controls.Add(this.textBoxSerialNo);
			this.Controls.Add(this.labelDateAsOf);
			this.Controls.Add(this.dateTimePickerDateAsOf);
			this.Controls.Add(this.labelComponentTSNCSN);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.labelInstallationData);
			this.Controls.Add(this.labelInstallationDate);
			this.Controls.Add(this.dateTimePickerInstallationDate);
			this.Controls.Add(this.labelAircraftTSNCSN);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.labelActualState);
			this.Controls.Add(this.labelComponentCurrentTSNCSN);
			this.Controls.Add(this.lifelengthViewerComponentCurrentTSNCSN);
			this.Controls.Add(this.labelTCSI);
			this.Controls.Add(this.lifelengthViewerComponentTCSI);
			this.Controls.Add(this.lifelengthViewerComponentTCSNOnInstall);
			this.Controls.Add(this.lifelengthViewerAircraftTCSNOnInstall);
			this.Name = "ComponentAddingGeneralInformationControl";
			this.Size = new System.Drawing.Size(1153, 425);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMPDItem;
        private System.Windows.Forms.Label labelAtaChapter;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelPartNo;
        private System.Windows.Forms.Label labelSerialNo;
        private System.Windows.Forms.Label labelInstallationData;
        private System.Windows.Forms.Label labelInstallationDate;
        private System.Windows.Forms.Label labelComponentTSNCSN;
        private System.Windows.Forms.Label labelAircraftTSNCSN;
        private System.Windows.Forms.Label labelActualState;
        private System.Windows.Forms.Label labelDateAsOf;
        private System.Windows.Forms.Label labelComponentCurrentTSNCSN;
        private System.Windows.Forms.Label labelTCSI;
        private System.Windows.Forms.TextBox textBoxMPDItem;
        private ATAChapterComboBox comboBoxAtaChapter;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxPartNo;
        private System.Windows.Forms.TextBox textBoxSerialNo;
        private DateTimePicker dateTimePickerInstallationDate;
        private LifelengthViewer lifelengthViewerComponentTCSNOnInstall;
        private LifelengthViewer lifelengthViewerAircraftTCSNOnInstall;
        private DateTimePicker dateTimePickerDateAsOf;
        private LifelengthViewer lifelengthViewerComponentCurrentTSNCSN;
        private LifelengthViewer lifelengthViewerComponentTCSI;
        private System.Windows.Forms.ComboBox comboBoxStorePosition;
        private Delimiter delimiter1;
        private Delimiter delimiter2;
        private Label labelManufactureDate;
        private DateTimePicker dateTimePickerManufactureDate;
        //private LifelengthViewer lifelengthViewerComponentTSNCSN;
        private Label labelDeliveryDate;
        private DateTimePicker dateTimePickerDeliveryDate;
        private Label labelPosition;
        private Label labelManufacturer;
        private TextBox textBoxPosition;
        private TextBox textBoxManufacturer;
        private Label labelModel;
        private LookupCombobox comboBoxModel;
        private TextBox textBoxALTPN;
        private Label labelAltPn;
        private CheckBox checkBoxLLPMark;
        private ComboBox comboBoxMaintenenceType;
        private Label labelMaintenenceType;
        private Label labelLocation;
        private Label labelQuantity;
        private TreeDictionaryComboBox comboBoxComponentType;
        private Label labelComponentType;
        private NumericUpDown numericUpDownQuantity;
        private Label labelBatchNumber;
        private TextBox textBoxBatchNumber;
        private Label labelIdNumber;
        private TextBox textBoxIdNumber;
        private CheckBox checkBoxPOOL;
        private CheckBox checkBoxDangerous;
        private Label labelProductCode;
        private TextBox textBoxProductCode;
        private ComboBox comboBoxStatus;
        private Label labelStatus;
		private DictionaryComboBox dictionaryComboBoxLocation;
	}
}
