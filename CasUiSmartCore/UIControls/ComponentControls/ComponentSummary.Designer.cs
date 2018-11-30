using System.Windows.Forms;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentSummary
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

            if(disposing)
            {
                if(_baseComponentComponents != null && _baseComponentComponents.Count > 0)
                    _baseComponentComponents.Clear();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentSummary));
			this.labelMPDItem = new System.Windows.Forms.Label();
			this.labelMPDItemValue = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelDescriptionValue = new System.Windows.Forms.Label();
			this.labelPartNumber = new System.Windows.Forms.Label();
			this.labelPartNumberValue = new System.Windows.Forms.Label();
			this.flowLayoutPanel_Compliance = new System.Windows.Forms.FlowLayoutPanel();
			this.labelSerialNumber = new System.Windows.Forms.Label();
			this.labelSerialNumberValue = new System.Windows.Forms.Label();
			this.labelPositionValue = new System.Windows.Forms.Label();
			this.labelPosition = new System.Windows.Forms.Label();
			this.labelManufactureDateValue = new System.Windows.Forms.Label();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.labelManufacturerValue = new System.Windows.Forms.Label();
			this.labelManufacturer = new System.Windows.Forms.Label();
			this.labelModelValue = new System.Windows.Forms.Label();
			this.labelModel = new System.Windows.Forms.Label();
			this.labelATAChapterValue = new System.Windows.Forms.Label();
			this.labelATAChapter = new System.Windows.Forms.Label();
			this.labelCompntLifeLimitValue = new System.Windows.Forms.Label();
			this.labelCompntTCSN = new System.Windows.Forms.Label();
			this.labelCompntTCSNonInstallValue = new System.Windows.Forms.Label();
			this.labelCompntTCSNonInstall = new System.Windows.Forms.Label();
			this.labelCompntTCSNsinceInstallValue = new System.Windows.Forms.Label();
			this.labelCompntTCSNsinceInstall = new System.Windows.Forms.Label();
			this.labelCompntTCSNValue = new System.Windows.Forms.Label();
			this.labelCompntLifeLimit = new System.Windows.Forms.Label();
			this.labelCompntInstallDateValue = new System.Windows.Forms.Label();
			this.labelCompntInstallDate = new System.Windows.Forms.Label();
			this.labelAircraftTCSN = new System.Windows.Forms.Label();
			this.labelAircraftTCSNValue = new System.Windows.Forms.Label();
			this.labelSupplierValue = new System.Windows.Forms.Label();
			this.labelSupplier = new System.Windows.Forms.Label();
			this.labelAvionicsInventoryValue = new System.Windows.Forms.Label();
			this.labelAvionicsInventory = new System.Windows.Forms.Label();
			this.labelMaintFreqValue = new System.Windows.Forms.Label();
			this.labelMaintFreq = new System.Windows.Forms.Label();
			this.labelCostServiceableValue = new System.Windows.Forms.Label();
			this.labelCostServiceable = new System.Windows.Forms.Label();
			this.labelCostOverhaulValue = new System.Windows.Forms.Label();
			this.labelCostOverhaul = new System.Windows.Forms.Label();
			this.labelCostNewValue = new System.Windows.Forms.Label();
			this.labelCostNew = new System.Windows.Forms.Label();
			this.labelDeliveryDateValue = new System.Windows.Forms.Label();
			this.labelDeliveryDate = new System.Windows.Forms.Label();
			this.labelWarrantyValue = new System.Windows.Forms.Label();
			this.labelWarranty = new System.Windows.Forms.Label();
			this.labelCompntLifeLimitRemainsValue = new System.Windows.Forms.Label();
			this.labelCompntLifeLimitRemains = new System.Windows.Forms.Label();
			this.labelAircraftTCSNonInstall = new System.Windows.Forms.Label();
			this.labelAircraftTCSNonInstallValue = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelRemarks = new System.Windows.Forms.Label();
			this.labelRemarksValue = new System.Windows.Forms.Label();
			this.labelHiddenRemarks = new System.Windows.Forms.Label();
			this.labelHiddenRemarksValue = new System.Windows.Forms.Label();
			this.labelClassValue = new System.Windows.Forms.Label();
			this.labelClass = new System.Windows.Forms.Label();
			this.delimiter4 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter2 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.delimiter1 = new CAS.UI.UIControls.Auxiliary.Delimiter();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelMPDItem
			// 
			this.labelMPDItem.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMPDItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItem.Location = new System.Drawing.Point(400, 0);
			this.labelMPDItem.Name = "labelMPDItem";
			this.labelMPDItem.Size = new System.Drawing.Size(150, 30);
			this.labelMPDItem.TabIndex = 2;
			this.labelMPDItem.Text = "MPD Item:";
			this.labelMPDItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMPDItemValue
			// 
			this.labelMPDItemValue.AutoEllipsis = true;
			this.labelMPDItemValue.AutoSize = true;
			this.labelMPDItemValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMPDItemValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMPDItemValue.Location = new System.Drawing.Point(556, 0);
			this.labelMPDItemValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelMPDItemValue.Name = "labelMPDItemValue";
			this.labelMPDItemValue.Size = new System.Drawing.Size(100, 30);
			this.labelMPDItemValue.TabIndex = 3;
			this.labelMPDItemValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescription
			// 
			this.labelDescription.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescription.Location = new System.Drawing.Point(3, 117);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(150, 30);
			this.labelDescription.TabIndex = 5;
			this.labelDescription.Text = "Description:";
			this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDescriptionValue
			// 
			this.labelDescriptionValue.AutoEllipsis = true;
			this.labelDescriptionValue.AutoSize = true;
			this.labelDescriptionValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDescriptionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDescriptionValue.Location = new System.Drawing.Point(159, 117);
			this.labelDescriptionValue.MaximumSize = new System.Drawing.Size(994, 30);
			this.labelDescriptionValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelDescriptionValue.Name = "labelDescriptionValue";
			this.labelDescriptionValue.Size = new System.Drawing.Size(100, 30);
			this.labelDescriptionValue.TabIndex = 6;
			this.labelDescriptionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPartNumber
			// 
			this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumber.Location = new System.Drawing.Point(800, 0);
			this.labelPartNumber.Name = "labelPartNumber";
			this.labelPartNumber.Size = new System.Drawing.Size(150, 30);
			this.labelPartNumber.TabIndex = 7;
			this.labelPartNumber.Text = "Part No:";
			this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPartNumberValue
			// 
			this.labelPartNumberValue.AutoEllipsis = true;
			this.labelPartNumberValue.AutoSize = true;
			this.labelPartNumberValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPartNumberValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPartNumberValue.Location = new System.Drawing.Point(956, 0);
			this.labelPartNumberValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelPartNumberValue.Name = "labelPartNumberValue";
			this.labelPartNumberValue.Size = new System.Drawing.Size(100, 30);
			this.labelPartNumberValue.TabIndex = 8;
			this.labelPartNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel_Compliance
			// 
			this.flowLayoutPanel_Compliance.AutoSize = true;
			this.flowLayoutPanel_Compliance.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel_Compliance.Location = new System.Drawing.Point(2, 475);
			this.flowLayoutPanel_Compliance.MinimumSize = new System.Drawing.Size(1074, 20);
			this.flowLayoutPanel_Compliance.Name = "flowLayoutPanel_Compliance";
			this.flowLayoutPanel_Compliance.Size = new System.Drawing.Size(1102, 20);
			this.flowLayoutPanel_Compliance.TabIndex = 49;
			// 
			// labelSerialNumber
			// 
			this.labelSerialNumber.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSerialNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNumber.Location = new System.Drawing.Point(800, 30);
			this.labelSerialNumber.Name = "labelSerialNumber";
			this.labelSerialNumber.Size = new System.Drawing.Size(150, 30);
			this.labelSerialNumber.TabIndex = 50;
			this.labelSerialNumber.Text = "Serial No:";
			this.labelSerialNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSerialNumberValue
			// 
			this.labelSerialNumberValue.AutoEllipsis = true;
			this.labelSerialNumberValue.AutoSize = true;
			this.labelSerialNumberValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSerialNumberValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSerialNumberValue.Location = new System.Drawing.Point(956, 30);
			this.labelSerialNumberValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelSerialNumberValue.Name = "labelSerialNumberValue";
			this.labelSerialNumberValue.Size = new System.Drawing.Size(100, 30);
			this.labelSerialNumberValue.TabIndex = 51;
			this.labelSerialNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPositionValue
			// 
			this.labelPositionValue.AutoEllipsis = true;
			this.labelPositionValue.AutoSize = true;
			this.labelPositionValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelPositionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPositionValue.Location = new System.Drawing.Point(159, 61);
			this.labelPositionValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelPositionValue.Name = "labelPositionValue";
			this.labelPositionValue.Size = new System.Drawing.Size(100, 30);
			this.labelPositionValue.TabIndex = 53;
			this.labelPositionValue.Text = "Data value";
			this.labelPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPosition
			// 
			this.labelPosition.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelPosition.Location = new System.Drawing.Point(3, 60);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(150, 30);
			this.labelPosition.TabIndex = 52;
			this.labelPosition.Text = "Position:";
			this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufactureDateValue
			// 
			this.labelManufactureDateValue.AutoEllipsis = true;
			this.labelManufactureDateValue.AutoSize = true;
			this.labelManufactureDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDateValue.Location = new System.Drawing.Point(159, 238);
			this.labelManufactureDateValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelManufactureDateValue.Name = "labelManufactureDateValue";
			this.labelManufactureDateValue.Size = new System.Drawing.Size(100, 30);
			this.labelManufactureDateValue.TabIndex = 55;
			this.labelManufactureDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDate.Location = new System.Drawing.Point(3, 238);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(150, 30);
			this.labelManufactureDate.TabIndex = 54;
			this.labelManufactureDate.Text = "MF Date:";
			this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturerValue
			// 
			this.labelManufacturerValue.AutoEllipsis = true;
			this.labelManufacturerValue.AutoSize = true;
			this.labelManufacturerValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufacturerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturerValue.Location = new System.Drawing.Point(159, 30);
			this.labelManufacturerValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelManufacturerValue.Name = "labelManufacturerValue";
			this.labelManufacturerValue.Size = new System.Drawing.Size(100, 30);
			this.labelManufacturerValue.TabIndex = 58;
			this.labelManufacturerValue.Text = "Data value";
			this.labelManufacturerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufacturer
			// 
			this.labelManufacturer.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelManufacturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufacturer.Location = new System.Drawing.Point(3, 29);
			this.labelManufacturer.Name = "labelManufacturer";
			this.labelManufacturer.Size = new System.Drawing.Size(150, 30);
			this.labelManufacturer.TabIndex = 57;
			this.labelManufacturer.Text = "Manufacturer:";
			this.labelManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelModelValue
			// 
			this.labelModelValue.AutoEllipsis = true;
			this.labelModelValue.AutoSize = true;
			this.labelModelValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelModelValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelModelValue.Location = new System.Drawing.Point(159, 0);
			this.labelModelValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelModelValue.Name = "labelModelValue";
			this.labelModelValue.Size = new System.Drawing.Size(100, 30);
			this.labelModelValue.TabIndex = 60;
			this.labelModelValue.Text = "Data value";
			this.labelModelValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelModel
			// 
			this.labelModel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelModel.Location = new System.Drawing.Point(3, 0);
			this.labelModel.Name = "labelModel";
			this.labelModel.Size = new System.Drawing.Size(150, 30);
			this.labelModel.TabIndex = 59;
			this.labelModel.Text = "Model:";
			this.labelModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelATAChapterValue
			// 
			this.labelATAChapterValue.AutoEllipsis = true;
			this.labelATAChapterValue.AutoSize = true;
			this.labelATAChapterValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelATAChapterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelATAChapterValue.Location = new System.Drawing.Point(556, 29);
			this.labelATAChapterValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelATAChapterValue.Name = "labelATAChapterValue";
			this.labelATAChapterValue.Size = new System.Drawing.Size(100, 30);
			this.labelATAChapterValue.TabIndex = 62;
			this.labelATAChapterValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelATAChapter
			// 
			this.labelATAChapter.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelATAChapter.Location = new System.Drawing.Point(400, 29);
			this.labelATAChapter.Name = "labelATAChapter";
			this.labelATAChapter.Size = new System.Drawing.Size(150, 30);
			this.labelATAChapter.TabIndex = 61;
			this.labelATAChapter.Text = "ATA Chapter:";
			this.labelATAChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntLifeLimitValue
			// 
			this.labelCompntLifeLimitValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntLifeLimitValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntLifeLimitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntLifeLimitValue.Location = new System.Drawing.Point(840, 80);
			this.labelCompntLifeLimitValue.Name = "labelCompntLifeLimitValue";
			this.labelCompntLifeLimitValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntLifeLimitValue.TabIndex = 74;
			this.labelCompntLifeLimitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntTCSN
			// 
			this.labelCompntTCSN.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntTCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSN.Location = new System.Drawing.Point(540, 42);
			this.labelCompntTCSN.Name = "labelCompntTCSN";
			this.labelCompntTCSN.Size = new System.Drawing.Size(210, 30);
			this.labelCompntTCSN.TabIndex = 73;
			this.labelCompntTCSN.Text = "Component Total:";
			this.labelCompntTCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntTCSNonInstallValue
			// 
			this.labelCompntTCSNonInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntTCSNonInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSNonInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSNonInstallValue.Location = new System.Drawing.Point(302, 118);
			this.labelCompntTCSNonInstallValue.Name = "labelCompntTCSNonInstallValue";
			this.labelCompntTCSNonInstallValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntTCSNonInstallValue.TabIndex = 72;
			this.labelCompntTCSNonInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntTCSNonInstall
			// 
			this.labelCompntTCSNonInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntTCSNonInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSNonInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSNonInstall.Location = new System.Drawing.Point(4, 118);
			this.labelCompntTCSNonInstall.Name = "labelCompntTCSNonInstall";
			this.labelCompntTCSNonInstall.Size = new System.Drawing.Size(245, 30);
			this.labelCompntTCSNonInstall.TabIndex = 71;
			this.labelCompntTCSNonInstall.Text = "Component on Install.:";
			this.labelCompntTCSNonInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntTCSNsinceInstallValue
			// 
			this.labelCompntTCSNsinceInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntTCSNsinceInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSNsinceInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSNsinceInstallValue.Location = new System.Drawing.Point(840, 4);
			this.labelCompntTCSNsinceInstallValue.Name = "labelCompntTCSNsinceInstallValue";
			this.labelCompntTCSNsinceInstallValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntTCSNsinceInstallValue.TabIndex = 70;
			this.labelCompntTCSNsinceInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntTCSNsinceInstall
			// 
			this.labelCompntTCSNsinceInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntTCSNsinceInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSNsinceInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSNsinceInstall.Location = new System.Drawing.Point(540, 4);
			this.labelCompntTCSNsinceInstall.Name = "labelCompntTCSNsinceInstall";
			this.labelCompntTCSNsinceInstall.Size = new System.Drawing.Size(226, 30);
			this.labelCompntTCSNsinceInstall.TabIndex = 69;
			this.labelCompntTCSNsinceInstall.Text = "Component since install:";
			this.labelCompntTCSNsinceInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntTCSNValue
			// 
			this.labelCompntTCSNValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntTCSNValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntTCSNValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntTCSNValue.Location = new System.Drawing.Point(840, 42);
			this.labelCompntTCSNValue.Name = "labelCompntTCSNValue";
			this.labelCompntTCSNValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntTCSNValue.TabIndex = 68;
			this.labelCompntTCSNValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntLifeLimit
			// 
			this.labelCompntLifeLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntLifeLimit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntLifeLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntLifeLimit.Location = new System.Drawing.Point(540, 80);
			this.labelCompntLifeLimit.Name = "labelCompntLifeLimit";
			this.labelCompntLifeLimit.Size = new System.Drawing.Size(226, 30);
			this.labelCompntLifeLimit.TabIndex = 67;
			this.labelCompntLifeLimit.Text = "Component Life Limit:";
			this.labelCompntLifeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntInstallDateValue
			// 
			this.labelCompntInstallDateValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntInstallDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntInstallDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntInstallDateValue.Location = new System.Drawing.Point(302, 80);
			this.labelCompntInstallDateValue.Name = "labelCompntInstallDateValue";
			this.labelCompntInstallDateValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntInstallDateValue.TabIndex = 66;
			this.labelCompntInstallDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntInstallDate
			// 
			this.labelCompntInstallDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntInstallDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntInstallDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntInstallDate.Location = new System.Drawing.Point(4, 80);
			this.labelCompntInstallDate.Name = "labelCompntInstallDate";
			this.labelCompntInstallDate.Size = new System.Drawing.Size(200, 30);
			this.labelCompntInstallDate.TabIndex = 65;
			this.labelCompntInstallDate.Text = "Component install. date:";
			this.labelCompntInstallDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTCSN
			// 
			this.labelAircraftTCSN.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelAircraftTCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTCSN.Location = new System.Drawing.Point(4, 4);
			this.labelAircraftTCSN.Name = "labelAircraftTCSN";
			this.labelAircraftTCSN.Size = new System.Drawing.Size(200, 30);
			this.labelAircraftTCSN.TabIndex = 63;
			this.labelAircraftTCSN.Text = "Aircraft Current:";
			this.labelAircraftTCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTCSNValue
			// 
			this.labelAircraftTCSNValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelAircraftTCSNValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTCSNValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTCSNValue.Location = new System.Drawing.Point(302, 4);
			this.labelAircraftTCSNValue.Name = "labelAircraftTCSNValue";
			this.labelAircraftTCSNValue.Size = new System.Drawing.Size(200, 30);
			this.labelAircraftTCSNValue.TabIndex = 64;
			this.labelAircraftTCSNValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelSupplierValue
			// 
			this.labelSupplierValue.AutoEllipsis = true;
			this.labelSupplierValue.AutoSize = true;
			this.labelSupplierValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSupplierValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplierValue.Location = new System.Drawing.Point(159, 208);
			this.labelSupplierValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelSupplierValue.Name = "labelSupplierValue";
			this.labelSupplierValue.Size = new System.Drawing.Size(100, 30);
			this.labelSupplierValue.TabIndex = 80;
			this.labelSupplierValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSupplier
			// 
			this.labelSupplier.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupplier.Location = new System.Drawing.Point(3, 208);
			this.labelSupplier.Name = "labelSupplier";
			this.labelSupplier.Size = new System.Drawing.Size(150, 30);
			this.labelSupplier.TabIndex = 79;
			this.labelSupplier.Text = "Supplier:";
			this.labelSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAvionicsInventoryValue
			// 
			this.labelAvionicsInventoryValue.AutoEllipsis = true;
			this.labelAvionicsInventoryValue.AutoSize = true;
			this.labelAvionicsInventoryValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAvionicsInventoryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAvionicsInventoryValue.Location = new System.Drawing.Point(556, 60);
			this.labelAvionicsInventoryValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelAvionicsInventoryValue.Name = "labelAvionicsInventoryValue";
			this.labelAvionicsInventoryValue.Size = new System.Drawing.Size(100, 30);
			this.labelAvionicsInventoryValue.TabIndex = 82;
			this.labelAvionicsInventoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAvionicsInventory
			// 
			this.labelAvionicsInventory.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAvionicsInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAvionicsInventory.Location = new System.Drawing.Point(400, 60);
			this.labelAvionicsInventory.Name = "labelAvionicsInventory";
			this.labelAvionicsInventory.Size = new System.Drawing.Size(150, 30);
			this.labelAvionicsInventory.TabIndex = 81;
			this.labelAvionicsInventory.Text = "Avnx. Inventory:";
			this.labelAvionicsInventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaintFreqValue
			// 
			this.labelMaintFreqValue.AutoEllipsis = true;
			this.labelMaintFreqValue.AutoSize = true;
			this.labelMaintFreqValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaintFreqValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaintFreqValue.Location = new System.Drawing.Point(956, 60);
			this.labelMaintFreqValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelMaintFreqValue.Name = "labelMaintFreqValue";
			this.labelMaintFreqValue.Size = new System.Drawing.Size(100, 30);
			this.labelMaintFreqValue.TabIndex = 84;
			this.labelMaintFreqValue.Text = "HT/ OC/ CM";
			this.labelMaintFreqValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaintFreq
			// 
			this.labelMaintFreq.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMaintFreq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaintFreq.Location = new System.Drawing.Point(800, 60);
			this.labelMaintFreq.Name = "labelMaintFreq";
			this.labelMaintFreq.Size = new System.Drawing.Size(150, 30);
			this.labelMaintFreq.TabIndex = 83;
			this.labelMaintFreq.Text = "Maint. Proc.:";
			this.labelMaintFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostServiceableValue
			// 
			this.labelCostServiceableValue.AutoEllipsis = true;
			this.labelCostServiceableValue.AutoSize = true;
			this.labelCostServiceableValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostServiceableValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostServiceableValue.Location = new System.Drawing.Point(556, 269);
			this.labelCostServiceableValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelCostServiceableValue.Name = "labelCostServiceableValue";
			this.labelCostServiceableValue.Size = new System.Drawing.Size(100, 30);
			this.labelCostServiceableValue.TabIndex = 90;
			this.labelCostServiceableValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostServiceable
			// 
			this.labelCostServiceable.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCostServiceable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostServiceable.Location = new System.Drawing.Point(400, 268);
			this.labelCostServiceable.Name = "labelCostServiceable";
			this.labelCostServiceable.Size = new System.Drawing.Size(150, 30);
			this.labelCostServiceable.TabIndex = 89;
			this.labelCostServiceable.Text = "Cost serviceable:";
			this.labelCostServiceable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostOverhaulValue
			// 
			this.labelCostOverhaulValue.AutoEllipsis = true;
			this.labelCostOverhaulValue.AutoSize = true;
			this.labelCostOverhaulValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostOverhaulValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostOverhaulValue.Location = new System.Drawing.Point(556, 239);
			this.labelCostOverhaulValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelCostOverhaulValue.Name = "labelCostOverhaulValue";
			this.labelCostOverhaulValue.Size = new System.Drawing.Size(100, 30);
			this.labelCostOverhaulValue.TabIndex = 88;
			this.labelCostOverhaulValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostOverhaul
			// 
			this.labelCostOverhaul.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCostOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostOverhaul.Location = new System.Drawing.Point(400, 238);
			this.labelCostOverhaul.Name = "labelCostOverhaul";
			this.labelCostOverhaul.Size = new System.Drawing.Size(150, 30);
			this.labelCostOverhaul.TabIndex = 87;
			this.labelCostOverhaul.Text = "Cost overhaul:";
			this.labelCostOverhaul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostNewValue
			// 
			this.labelCostNewValue.AutoEllipsis = true;
			this.labelCostNewValue.AutoSize = true;
			this.labelCostNewValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCostNewValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostNewValue.Location = new System.Drawing.Point(556, 208);
			this.labelCostNewValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelCostNewValue.Name = "labelCostNewValue";
			this.labelCostNewValue.Size = new System.Drawing.Size(100, 30);
			this.labelCostNewValue.TabIndex = 86;
			this.labelCostNewValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCostNew
			// 
			this.labelCostNew.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCostNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostNew.Location = new System.Drawing.Point(400, 208);
			this.labelCostNew.Name = "labelCostNew";
			this.labelCostNew.Size = new System.Drawing.Size(150, 30);
			this.labelCostNew.TabIndex = 85;
			this.labelCostNew.Text = "Cost new:";
			this.labelCostNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDeliveryDateValue
			// 
			this.labelDeliveryDateValue.AutoEllipsis = true;
			this.labelDeliveryDateValue.AutoSize = true;
			this.labelDeliveryDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDeliveryDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDeliveryDateValue.Location = new System.Drawing.Point(159, 268);
			this.labelDeliveryDateValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelDeliveryDateValue.Name = "labelDeliveryDateValue";
			this.labelDeliveryDateValue.Size = new System.Drawing.Size(100, 30);
			this.labelDeliveryDateValue.TabIndex = 92;
			this.labelDeliveryDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDeliveryDate
			// 
			this.labelDeliveryDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDeliveryDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDeliveryDate.Location = new System.Drawing.Point(3, 268);
			this.labelDeliveryDate.Name = "labelDeliveryDate";
			this.labelDeliveryDate.Size = new System.Drawing.Size(150, 30);
			this.labelDeliveryDate.TabIndex = 91;
			this.labelDeliveryDate.Text = "Delivery Date:";
			this.labelDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelWarrantyValue
			// 
			this.labelWarrantyValue.AutoEllipsis = true;
			this.labelWarrantyValue.AutoSize = true;
			this.labelWarrantyValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelWarrantyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWarrantyValue.Location = new System.Drawing.Point(953, 208);
			this.labelWarrantyValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelWarrantyValue.Name = "labelWarrantyValue";
			this.labelWarrantyValue.Size = new System.Drawing.Size(110, 30);
			this.labelWarrantyValue.TabIndex = 94;
			this.labelWarrantyValue.Text = "WarrantyValue";
			this.labelWarrantyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelWarranty
			// 
			this.labelWarranty.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWarranty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelWarranty.Location = new System.Drawing.Point(800, 208);
			this.labelWarranty.Name = "labelWarranty";
			this.labelWarranty.Size = new System.Drawing.Size(150, 30);
			this.labelWarranty.TabIndex = 93;
			this.labelWarranty.Text = "Warranty:";
			this.labelWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompntLifeLimitRemainsValue
			// 
			this.labelCompntLifeLimitRemainsValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelCompntLifeLimitRemainsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntLifeLimitRemainsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntLifeLimitRemainsValue.Location = new System.Drawing.Point(840, 118);
			this.labelCompntLifeLimitRemainsValue.Name = "labelCompntLifeLimitRemainsValue";
			this.labelCompntLifeLimitRemainsValue.Size = new System.Drawing.Size(200, 30);
			this.labelCompntLifeLimitRemainsValue.TabIndex = 96;
			this.labelCompntLifeLimitRemainsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelCompntLifeLimitRemains
			// 
			this.labelCompntLifeLimitRemains.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelCompntLifeLimitRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCompntLifeLimitRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCompntLifeLimitRemains.Location = new System.Drawing.Point(540, 118);
			this.labelCompntLifeLimitRemains.Name = "labelCompntLifeLimitRemains";
			this.labelCompntLifeLimitRemains.Size = new System.Drawing.Size(226, 30);
			this.labelCompntLifeLimitRemains.TabIndex = 95;
			this.labelCompntLifeLimitRemains.Text = "Life Limit Remains:";
			this.labelCompntLifeLimitRemains.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTCSNonInstall
			// 
			this.labelAircraftTCSNonInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelAircraftTCSNonInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTCSNonInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTCSNonInstall.Location = new System.Drawing.Point(4, 42);
			this.labelAircraftTCSNonInstall.Name = "labelAircraftTCSNonInstall";
			this.labelAircraftTCSNonInstall.Size = new System.Drawing.Size(245, 30);
			this.labelAircraftTCSNonInstall.TabIndex = 97;
			this.labelAircraftTCSNonInstall.Text = "Aircraft on Install:";
			this.labelAircraftTCSNonInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTCSNonInstallValue
			// 
			this.labelAircraftTCSNonInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.labelAircraftTCSNonInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTCSNonInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTCSNonInstallValue.Location = new System.Drawing.Point(302, 42);
			this.labelAircraftTCSNonInstallValue.Name = "labelAircraftTCSNonInstallValue";
			this.labelAircraftTCSNonInstallValue.Size = new System.Drawing.Size(200, 30);
			this.labelAircraftTCSNonInstallValue.TabIndex = 98;
			this.labelAircraftTCSNonInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.labelAircraftTCSN, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntLifeLimitRemainsValue, 3, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelAircraftTCSNonInstall, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntLifeLimitRemains, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntInstallDate, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSNonInstall, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelAircraftTCSNonInstallValue, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelAircraftTCSNValue, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntInstallDateValue, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSNonInstallValue, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSNsinceInstall, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSN, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntLifeLimit, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSNsinceInstallValue, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntTCSNValue, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelCompntLifeLimitValue, 3, 2);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 313);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 153);
			this.tableLayoutPanel1.TabIndex = 99;
			// 
			// labelRemarks
			// 
			this.labelRemarks.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarks.Location = new System.Drawing.Point(3, 147);
			this.labelRemarks.Name = "labelRemarks";
			this.labelRemarks.Size = new System.Drawing.Size(150, 30);
			this.labelRemarks.TabIndex = 103;
			this.labelRemarks.Text = "Remarks:";
			this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRemarksValue
			// 
			this.labelRemarksValue.AutoEllipsis = true;
			this.labelRemarksValue.AutoSize = true;
			this.labelRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemarksValue.Location = new System.Drawing.Point(159, 147);
			this.labelRemarksValue.MaximumSize = new System.Drawing.Size(994, 30);
			this.labelRemarksValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelRemarksValue.Name = "labelRemarksValue";
			this.labelRemarksValue.Size = new System.Drawing.Size(100, 30);
			this.labelRemarksValue.TabIndex = 104;
			this.labelRemarksValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHiddenRemarks
			// 
			this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarks.Location = new System.Drawing.Point(3, 177);
			this.labelHiddenRemarks.Name = "labelHiddenRemarks";
			this.labelHiddenRemarks.Size = new System.Drawing.Size(150, 30);
			this.labelHiddenRemarks.TabIndex = 105;
			this.labelHiddenRemarks.Text = "HiddenRemarks:";
			this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelHiddenRemarksValue
			// 
			this.labelHiddenRemarksValue.AutoEllipsis = true;
			this.labelHiddenRemarksValue.AutoSize = true;
			this.labelHiddenRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelHiddenRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelHiddenRemarksValue.Location = new System.Drawing.Point(159, 177);
			this.labelHiddenRemarksValue.MaximumSize = new System.Drawing.Size(994, 30);
			this.labelHiddenRemarksValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelHiddenRemarksValue.Name = "labelHiddenRemarksValue";
			this.labelHiddenRemarksValue.Size = new System.Drawing.Size(100, 30);
			this.labelHiddenRemarksValue.TabIndex = 106;
			this.labelHiddenRemarksValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelClassValue
			// 
			this.labelClassValue.AutoEllipsis = true;
			this.labelClassValue.AutoSize = true;
			this.labelClassValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelClassValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClassValue.Location = new System.Drawing.Point(159, 87);
			this.labelClassValue.MinimumSize = new System.Drawing.Size(100, 30);
			this.labelClassValue.Name = "labelClassValue";
			this.labelClassValue.Size = new System.Drawing.Size(100, 30);
			this.labelClassValue.TabIndex = 108;
			this.labelClassValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelClass
			// 
			this.labelClass.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelClass.Location = new System.Drawing.Point(3, 88);
			this.labelClass.Name = "labelClass";
			this.labelClass.Size = new System.Drawing.Size(150, 30);
			this.labelClass.TabIndex = 107;
			this.labelClass.Text = "Class:";
			this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// delimiter4
			// 
			this.delimiter4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter4.BackgroundImage")));
			this.delimiter4.Location = new System.Drawing.Point(793, 208);
			this.delimiter4.Name = "delimiter4";
			this.delimiter4.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter4.Size = new System.Drawing.Size(1, 90);
			this.delimiter4.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter4.TabIndex = 102;
			// 
			// delimiter3
			// 
			this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
			this.delimiter3.Location = new System.Drawing.Point(393, 208);
			this.delimiter3.Name = "delimiter3";
			this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter3.Size = new System.Drawing.Size(1, 90);
			this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter3.TabIndex = 101;
			// 
			// delimiter2
			// 
			this.delimiter2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter2.BackgroundImage")));
			this.delimiter2.Location = new System.Drawing.Point(793, 10);
			this.delimiter2.Name = "delimiter2";
			this.delimiter2.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter2.Size = new System.Drawing.Size(1, 80);
			this.delimiter2.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter2.TabIndex = 100;
			// 
			// delimiter1
			// 
			this.delimiter1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter1.BackgroundImage")));
			this.delimiter1.Location = new System.Drawing.Point(393, 10);
			this.delimiter1.Name = "delimiter1";
			this.delimiter1.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
			this.delimiter1.Size = new System.Drawing.Size(1, 80);
			this.delimiter1.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
			this.delimiter1.TabIndex = 56;
			// 
			// DetailSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.labelClassValue);
			this.Controls.Add(this.labelClass);
			this.Controls.Add(this.labelMPDItem);
			this.Controls.Add(this.labelHiddenRemarks);
			this.Controls.Add(this.labelHiddenRemarksValue);
			this.Controls.Add(this.labelRemarks);
			this.Controls.Add(this.labelRemarksValue);
			this.Controls.Add(this.delimiter4);
			this.Controls.Add(this.delimiter3);
			this.Controls.Add(this.delimiter2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.labelWarrantyValue);
			this.Controls.Add(this.labelWarranty);
			this.Controls.Add(this.labelDeliveryDateValue);
			this.Controls.Add(this.labelDeliveryDate);
			this.Controls.Add(this.labelCostServiceableValue);
			this.Controls.Add(this.labelCostServiceable);
			this.Controls.Add(this.labelCostOverhaulValue);
			this.Controls.Add(this.labelCostOverhaul);
			this.Controls.Add(this.labelCostNewValue);
			this.Controls.Add(this.labelCostNew);
			this.Controls.Add(this.labelMaintFreqValue);
			this.Controls.Add(this.labelMaintFreq);
			this.Controls.Add(this.labelAvionicsInventoryValue);
			this.Controls.Add(this.labelAvionicsInventory);
			this.Controls.Add(this.labelSupplierValue);
			this.Controls.Add(this.labelSupplier);
			this.Controls.Add(this.labelATAChapterValue);
			this.Controls.Add(this.labelATAChapter);
			this.Controls.Add(this.labelModelValue);
			this.Controls.Add(this.labelModel);
			this.Controls.Add(this.labelManufacturerValue);
			this.Controls.Add(this.labelManufacturer);
			this.Controls.Add(this.delimiter1);
			this.Controls.Add(this.labelManufactureDateValue);
			this.Controls.Add(this.labelManufactureDate);
			this.Controls.Add(this.labelPositionValue);
			this.Controls.Add(this.labelPosition);
			this.Controls.Add(this.labelSerialNumberValue);
			this.Controls.Add(this.labelSerialNumber);
			this.Controls.Add(this.flowLayoutPanel_Compliance);
			this.Controls.Add(this.labelMPDItemValue);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.labelDescriptionValue);
			this.Controls.Add(this.labelPartNumber);
			this.Controls.Add(this.labelPartNumberValue);
			this.MinimumSize = new System.Drawing.Size(1000, 450);
			this.Name = "ComponentSummary";
			this.Size = new System.Drawing.Size(1159, 500);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label labelMPDItem;
        private Label labelMPDItemValue;
        private Label labelDescription;
        private Label labelDescriptionValue;
        private Label labelPartNumber;
        private Label labelPartNumberValue;
        private FlowLayoutPanel flowLayoutPanel_Compliance;
        private Label labelSerialNumber;
        private Label labelSerialNumberValue;
        private Label labelPositionValue;
        private Label labelPosition;
        private Label labelManufactureDateValue;
        private Label labelManufactureDate;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter1;
        private Label labelManufacturerValue;
        private Label labelManufacturer;
        private Label labelModelValue;
        private Label labelModel;
        private Label labelATAChapterValue;
        private Label labelATAChapter;
        private Label labelCompntLifeLimitValue;
        private Label labelCompntTCSN;
        private Label labelCompntTCSNonInstallValue;
        private Label labelCompntTCSNonInstall;
        private Label labelCompntTCSNsinceInstallValue;
        private Label labelCompntTCSNsinceInstall;
        private Label labelCompntTCSNValue;
        private Label labelCompntLifeLimit;
        private Label labelCompntInstallDateValue;
        private Label labelCompntInstallDate;
        private Label labelAircraftTCSN;
        private Label labelAircraftTCSNValue;
        private Label labelSupplierValue;
        private Label labelSupplier;
        private Label labelAvionicsInventoryValue;
        private Label labelAvionicsInventory;
        private Label labelMaintFreqValue;
        private Label labelMaintFreq;
        private Label labelCostServiceableValue;
        private Label labelCostServiceable;
        private Label labelCostOverhaulValue;
        private Label labelCostOverhaul;
        private Label labelCostNewValue;
        private Label labelCostNew;
        private Label labelDeliveryDateValue;
        private Label labelDeliveryDate;
        private Label labelWarrantyValue;
        private Label labelWarranty;
        private Label labelCompntLifeLimitRemainsValue;
        private Label labelCompntLifeLimitRemains;
        private Label labelAircraftTCSNonInstall;
        private Label labelAircraftTCSNonInstallValue;
        private TableLayoutPanel tableLayoutPanel1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter2;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter4;
        private Label labelRemarks;
        private Label labelRemarksValue;
        private Label labelHiddenRemarks;
        private Label labelHiddenRemarksValue;
		private Label labelClassValue;
		private Label labelClass;
	}
}
