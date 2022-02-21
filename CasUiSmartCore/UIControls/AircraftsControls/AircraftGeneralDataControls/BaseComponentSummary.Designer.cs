using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    partial class BaseComponentSummary
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
                extendableRichContainer.Extending -= ExtendableRichContainerExtending;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseComponentSummary));
            this.flowLayoutPanel_Compliance = new System.Windows.Forms.FlowLayoutPanel();
            this.labelManufactureDateValue = new System.Windows.Forms.Label();
            this.labelManufactureDate = new System.Windows.Forms.Label();
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
            this.labelCompntLifeLimitRemainsValue = new System.Windows.Forms.Label();
            this.labelCompntLifeLimitRemains = new System.Windows.Forms.Label();
            this.labelAircraftTCSNonInstall = new System.Windows.Forms.Label();
            this.labelAircraftTCSNonInstallValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.labelRemarksValue = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelExtendable = new System.Windows.Forms.Panel();
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanelLinks = new System.Windows.Forms.FlowLayoutPanel();
            this.referenceLinkLabelBaseDetail = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.referenceLinkLabelComponents = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.referenceLinkLabelLLPStatus = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.delimiter3 = new CAS.UI.UIControls.Auxiliary.Delimiter();
            this.labelWarrantyValue = new System.Windows.Forms.Label();
            this.labelWarranty = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelExtendable.SuspendLayout();
            this._mainPanel.SuspendLayout();
            this.flowLayoutPanelLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_Compliance
            // 
            this.flowLayoutPanel_Compliance.AutoSize = true;
            this.flowLayoutPanel_Compliance.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_Compliance.Location = new System.Drawing.Point(3, 303);
            this.flowLayoutPanel_Compliance.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel_Compliance.MinimumSize = new System.Drawing.Size(1432, 25);
            this.flowLayoutPanel_Compliance.Name = "flowLayoutPanel_Compliance";
            this.flowLayoutPanel_Compliance.Size = new System.Drawing.Size(1469, 25);
            this.flowLayoutPanel_Compliance.TabIndex = 49;
            // 
            // labelManufactureDateValue
            // 
            this.labelManufactureDateValue.AutoEllipsis = true;
            this.labelManufactureDateValue.AutoSize = true;
            this.labelManufactureDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManufactureDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufactureDateValue.Location = new System.Drawing.Point(224, 31);
            this.labelManufactureDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManufactureDateValue.MinimumSize = new System.Drawing.Size(133, 37);
            this.labelManufactureDateValue.Name = "labelManufactureDateValue";
            this.labelManufactureDateValue.Size = new System.Drawing.Size(133, 37);
            this.labelManufactureDateValue.TabIndex = 55;
            this.labelManufactureDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManufactureDate
            // 
            this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManufactureDate.Location = new System.Drawing.Point(16, 29);
            this.labelManufactureDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManufactureDate.Name = "labelManufactureDate";
            this.labelManufactureDate.Size = new System.Drawing.Size(200, 37);
            this.labelManufactureDate.TabIndex = 54;
            this.labelManufactureDate.Text = "MF Date:";
            this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompntLifeLimitValue
            // 
            this.labelCompntLifeLimitValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntLifeLimitValue.AutoSize = true;
            this.labelCompntLifeLimitValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntLifeLimitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntLifeLimitValue.Location = new System.Drawing.Point(442, 106);
            this.labelCompntLifeLimitValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntLifeLimitValue.Name = "labelCompntLifeLimitValue";
            this.labelCompntLifeLimitValue.Size = new System.Drawing.Size(0, 18);
            this.labelCompntLifeLimitValue.TabIndex = 74;
            this.labelCompntLifeLimitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntTCSN
            // 
            this.labelCompntTCSN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntTCSN.AutoSize = true;
            this.labelCompntTCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSN.Location = new System.Drawing.Point(233, 60);
            this.labelCompntTCSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSN.Name = "labelCompntTCSN";
            this.labelCompntTCSN.Size = new System.Drawing.Size(145, 18);
            this.labelCompntTCSN.TabIndex = 73;
            this.labelCompntTCSN.Text = "Component Total:";
            this.labelCompntTCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompntTCSNonInstallValue
            // 
            this.labelCompntTCSNonInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntTCSNonInstallValue.AutoSize = true;
            this.labelCompntTCSNonInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSNonInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSNonInstallValue.Location = new System.Drawing.Point(215, 154);
            this.labelCompntTCSNonInstallValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSNonInstallValue.Name = "labelCompntTCSNonInstallValue";
            this.labelCompntTCSNonInstallValue.Size = new System.Drawing.Size(0, 18);
            this.labelCompntTCSNonInstallValue.TabIndex = 72;
            this.labelCompntTCSNonInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntTCSNonInstall
            // 
            this.labelCompntTCSNonInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntTCSNonInstall.AutoSize = true;
            this.labelCompntTCSNonInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSNonInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSNonInstall.Location = new System.Drawing.Point(5, 154);
            this.labelCompntTCSNonInstall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSNonInstall.Name = "labelCompntTCSNonInstall";
            this.labelCompntTCSNonInstall.Size = new System.Drawing.Size(180, 18);
            this.labelCompntTCSNonInstall.TabIndex = 71;
            this.labelCompntTCSNonInstall.Text = "Component on Install.:";
            this.labelCompntTCSNonInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompntTCSNsinceInstallValue
            // 
            this.labelCompntTCSNsinceInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntTCSNsinceInstallValue.AutoSize = true;
            this.labelCompntTCSNsinceInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSNsinceInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSNsinceInstallValue.Location = new System.Drawing.Point(442, 14);
            this.labelCompntTCSNsinceInstallValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSNsinceInstallValue.Name = "labelCompntTCSNsinceInstallValue";
            this.labelCompntTCSNsinceInstallValue.Size = new System.Drawing.Size(0, 18);
            this.labelCompntTCSNsinceInstallValue.TabIndex = 70;
            this.labelCompntTCSNsinceInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntTCSNsinceInstall
            // 
            this.labelCompntTCSNsinceInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntTCSNsinceInstall.AutoSize = true;
            this.labelCompntTCSNsinceInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSNsinceInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSNsinceInstall.Location = new System.Drawing.Point(233, 14);
            this.labelCompntTCSNsinceInstall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSNsinceInstall.Name = "labelCompntTCSNsinceInstall";
            this.labelCompntTCSNsinceInstall.Size = new System.Drawing.Size(191, 18);
            this.labelCompntTCSNsinceInstall.TabIndex = 69;
            this.labelCompntTCSNsinceInstall.Text = "Component since install:";
            this.labelCompntTCSNsinceInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompntTCSNValue
            // 
            this.labelCompntTCSNValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntTCSNValue.AutoSize = true;
            this.labelCompntTCSNValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntTCSNValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntTCSNValue.Location = new System.Drawing.Point(442, 60);
            this.labelCompntTCSNValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntTCSNValue.Name = "labelCompntTCSNValue";
            this.labelCompntTCSNValue.Size = new System.Drawing.Size(0, 18);
            this.labelCompntTCSNValue.TabIndex = 68;
            this.labelCompntTCSNValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntLifeLimit
            // 
            this.labelCompntLifeLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntLifeLimit.AutoSize = true;
            this.labelCompntLifeLimit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntLifeLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntLifeLimit.Location = new System.Drawing.Point(233, 106);
            this.labelCompntLifeLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntLifeLimit.Name = "labelCompntLifeLimit";
            this.labelCompntLifeLimit.Size = new System.Drawing.Size(173, 18);
            this.labelCompntLifeLimit.TabIndex = 67;
            this.labelCompntLifeLimit.Text = "Component Life Limit:";
            this.labelCompntLifeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompntInstallDateValue
            // 
            this.labelCompntInstallDateValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntInstallDateValue.AutoSize = true;
            this.labelCompntInstallDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntInstallDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntInstallDateValue.Location = new System.Drawing.Point(215, 106);
            this.labelCompntInstallDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntInstallDateValue.Name = "labelCompntInstallDateValue";
            this.labelCompntInstallDateValue.Size = new System.Drawing.Size(0, 18);
            this.labelCompntInstallDateValue.TabIndex = 66;
            this.labelCompntInstallDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntInstallDate
            // 
            this.labelCompntInstallDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntInstallDate.AutoSize = true;
            this.labelCompntInstallDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntInstallDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntInstallDate.Location = new System.Drawing.Point(5, 106);
            this.labelCompntInstallDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntInstallDate.Name = "labelCompntInstallDate";
            this.labelCompntInstallDate.Size = new System.Drawing.Size(192, 18);
            this.labelCompntInstallDate.TabIndex = 65;
            this.labelCompntInstallDate.Text = "Component install. date:";
            this.labelCompntInstallDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTCSN
            // 
            this.labelAircraftTCSN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAircraftTCSN.AutoSize = true;
            this.labelAircraftTCSN.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTCSN.Location = new System.Drawing.Point(5, 14);
            this.labelAircraftTCSN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTCSN.Name = "labelAircraftTCSN";
            this.labelAircraftTCSN.Size = new System.Drawing.Size(129, 18);
            this.labelAircraftTCSN.TabIndex = 63;
            this.labelAircraftTCSN.Text = "Aircraft Current:";
            this.labelAircraftTCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTCSNValue
            // 
            this.labelAircraftTCSNValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftTCSNValue.AutoSize = true;
            this.labelAircraftTCSNValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTCSNValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTCSNValue.Location = new System.Drawing.Point(215, 14);
            this.labelAircraftTCSNValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTCSNValue.Name = "labelAircraftTCSNValue";
            this.labelAircraftTCSNValue.Size = new System.Drawing.Size(0, 18);
            this.labelAircraftTCSNValue.TabIndex = 64;
            this.labelAircraftTCSNValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntLifeLimitRemainsValue
            // 
            this.labelCompntLifeLimitRemainsValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompntLifeLimitRemainsValue.AutoSize = true;
            this.labelCompntLifeLimitRemainsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntLifeLimitRemainsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntLifeLimitRemainsValue.Location = new System.Drawing.Point(433, 154);
            this.labelCompntLifeLimitRemainsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntLifeLimitRemainsValue.MinimumSize = new System.Drawing.Size(18, 18);
            this.labelCompntLifeLimitRemainsValue.Name = "labelCompntLifeLimitRemainsValue";
            this.labelCompntLifeLimitRemainsValue.Size = new System.Drawing.Size(18, 18);
            this.labelCompntLifeLimitRemainsValue.TabIndex = 96;
            this.labelCompntLifeLimitRemainsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompntLifeLimitRemains
            // 
            this.labelCompntLifeLimitRemains.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCompntLifeLimitRemains.AutoSize = true;
            this.labelCompntLifeLimitRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompntLifeLimitRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompntLifeLimitRemains.Location = new System.Drawing.Point(233, 154);
            this.labelCompntLifeLimitRemains.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompntLifeLimitRemains.Name = "labelCompntLifeLimitRemains";
            this.labelCompntLifeLimitRemains.Size = new System.Drawing.Size(148, 18);
            this.labelCompntLifeLimitRemains.TabIndex = 95;
            this.labelCompntLifeLimitRemains.Text = "Life Limit Remains:";
            this.labelCompntLifeLimitRemains.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTCSNonInstall
            // 
            this.labelAircraftTCSNonInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAircraftTCSNonInstall.AutoSize = true;
            this.labelAircraftTCSNonInstall.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTCSNonInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTCSNonInstall.Location = new System.Drawing.Point(5, 60);
            this.labelAircraftTCSNonInstall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTCSNonInstall.Name = "labelAircraftTCSNonInstall";
            this.labelAircraftTCSNonInstall.Size = new System.Drawing.Size(140, 18);
            this.labelAircraftTCSNonInstall.TabIndex = 97;
            this.labelAircraftTCSNonInstall.Text = "Aircraft on Install:";
            this.labelAircraftTCSNonInstall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTCSNonInstallValue
            // 
            this.labelAircraftTCSNonInstallValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftTCSNonInstallValue.AutoSize = true;
            this.labelAircraftTCSNonInstallValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTCSNonInstallValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTCSNonInstallValue.Location = new System.Drawing.Point(206, 60);
            this.labelAircraftTCSNonInstallValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTCSNonInstallValue.MinimumSize = new System.Drawing.Size(18, 18);
            this.labelAircraftTCSNonInstallValue.Name = "labelAircraftTCSNonInstallValue";
            this.labelAircraftTCSNonInstallValue.Size = new System.Drawing.Size(18, 18);
            this.labelAircraftTCSNonInstallValue.TabIndex = 98;
            this.labelAircraftTCSNonInstallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 70);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 188);
            this.tableLayoutPanel1.TabIndex = 99;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(16, 262);
            this.labelRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(200, 37);
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
            this.labelRemarksValue.Location = new System.Drawing.Point(245, 262);
            this.labelRemarksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarksValue.MaximumSize = new System.Drawing.Size(1325, 37);
            this.labelRemarksValue.MinimumSize = new System.Drawing.Size(133, 37);
            this.labelRemarksValue.Name = "labelRemarksValue";
            this.labelRemarksValue.Size = new System.Drawing.Size(133, 37);
            this.labelRemarksValue.TabIndex = 104;
            this.labelRemarksValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelExtendable);
            this.flowLayoutPanel1.Controls.Add(this._mainPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1484, 405);
            this.flowLayoutPanel1.TabIndex = 107;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelExtendable
            // 
            this.panelExtendable.Controls.Add(this.extendableRichContainer);
            this.panelExtendable.Location = new System.Drawing.Point(4, 4);
            this.panelExtendable.Margin = new System.Windows.Forms.Padding(4);
            this.panelExtendable.Name = "panelExtendable";
            this.panelExtendable.Size = new System.Drawing.Size(1472, 57);
            this.panelExtendable.TabIndex = 36;
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = null;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Directive Performance";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.Condition = null;
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = false;
            this.extendableRichContainer.Location = new System.Drawing.Point(12, 5);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(5);
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(497, 49);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // _mainPanel
            // 
            this._mainPanel.AutoSize = true;
            this._mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._mainPanel.Controls.Add(this.flowLayoutPanelLinks);
            this._mainPanel.Controls.Add(this.labelRemarks);
            this._mainPanel.Controls.Add(this.labelRemarksValue);
            this._mainPanel.Controls.Add(this.delimiter3);
            this._mainPanel.Controls.Add(this.flowLayoutPanel_Compliance);
            this._mainPanel.Controls.Add(this.tableLayoutPanel1);
            this._mainPanel.Controls.Add(this.labelWarrantyValue);
            this._mainPanel.Controls.Add(this.labelWarranty);
            this._mainPanel.Controls.Add(this.labelManufactureDate);
            this._mainPanel.Controls.Add(this.labelManufactureDateValue);
            this._mainPanel.Location = new System.Drawing.Point(4, 69);
            this._mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1476, 332);
            this._mainPanel.TabIndex = 65;
            this._mainPanel.Visible = false;
            // 
            // flowLayoutPanelLinks
            // 
            this.flowLayoutPanelLinks.AutoSize = true;
            this.flowLayoutPanelLinks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelLinks.Controls.Add(this.referenceLinkLabelBaseDetail);
            this.flowLayoutPanelLinks.Controls.Add(this.referenceLinkLabelComponents);
            this.flowLayoutPanelLinks.Controls.Add(this.referenceLinkLabelLLPStatus);
            this.flowLayoutPanelLinks.Location = new System.Drawing.Point(12, 8);
            this.flowLayoutPanelLinks.Name = "flowLayoutPanelLinks";
            this.flowLayoutPanelLinks.Size = new System.Drawing.Size(271, 18);
            this.flowLayoutPanelLinks.TabIndex = 109;
            this.flowLayoutPanelLinks.WrapContents = false;
            // 
            // referenceLinkLabelBaseDetail
            // 
            this.referenceLinkLabelBaseDetail.AutoSize = true;
            this.referenceLinkLabelBaseDetail.Displayer = null;
            this.referenceLinkLabelBaseDetail.DisplayerText = null;
            this.referenceLinkLabelBaseDetail.Entity = null;
            this.referenceLinkLabelBaseDetail.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.referenceLinkLabelBaseDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.referenceLinkLabelBaseDetail.Location = new System.Drawing.Point(4, 0);
            this.referenceLinkLabelBaseDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.referenceLinkLabelBaseDetail.Name = "referenceLinkLabelBaseDetail";
            this.referenceLinkLabelBaseDetail.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.referenceLinkLabelBaseDetail.Size = new System.Drawing.Size(86, 18);
            this.referenceLinkLabelBaseDetail.TabIndex = 108;
            this.referenceLinkLabelBaseDetail.TabStop = true;
            this.referenceLinkLabelBaseDetail.Text = "Equipment";
            this.referenceLinkLabelBaseDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.referenceLinkLabelBaseDetail.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelBaseDetailDisplayerRequested);
            // 
            // referenceLinkLabelComponents
            // 
            this.referenceLinkLabelComponents.AutoSize = true;
            this.referenceLinkLabelComponents.Displayer = null;
            this.referenceLinkLabelComponents.DisplayerText = null;
            this.referenceLinkLabelComponents.Entity = null;
            this.referenceLinkLabelComponents.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.referenceLinkLabelComponents.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.referenceLinkLabelComponents.Location = new System.Drawing.Point(114, 0);
            this.referenceLinkLabelComponents.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.referenceLinkLabelComponents.Name = "referenceLinkLabelComponents";
            this.referenceLinkLabelComponents.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.referenceLinkLabelComponents.Size = new System.Drawing.Size(96, 18);
            this.referenceLinkLabelComponents.TabIndex = 109;
            this.referenceLinkLabelComponents.TabStop = true;
            this.referenceLinkLabelComponents.Text = "Component";
            this.referenceLinkLabelComponents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.referenceLinkLabelComponents.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelComponentsDisplayerRequested);
            // 
            // referenceLinkLabelLLPStatus
            // 
            this.referenceLinkLabelLLPStatus.AutoSize = true;
            this.referenceLinkLabelLLPStatus.Displayer = null;
            this.referenceLinkLabelLLPStatus.DisplayerText = null;
            this.referenceLinkLabelLLPStatus.Entity = null;
            this.referenceLinkLabelLLPStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.referenceLinkLabelLLPStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.referenceLinkLabelLLPStatus.Location = new System.Drawing.Point(234, 0);
            this.referenceLinkLabelLLPStatus.Margin = new System.Windows.Forms.Padding(20, 0, 4, 0);
            this.referenceLinkLabelLLPStatus.Name = "referenceLinkLabelLLPStatus";
            this.referenceLinkLabelLLPStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.referenceLinkLabelLLPStatus.Size = new System.Drawing.Size(33, 18);
            this.referenceLinkLabelLLPStatus.TabIndex = 110;
            this.referenceLinkLabelLLPStatus.TabStop = true;
            this.referenceLinkLabelLLPStatus.Text = "LLP";
            this.referenceLinkLabelLLPStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.referenceLinkLabelLLPStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelLLPStatusDisplayerRequested);
            // 
            // delimiter3
            // 
            this.delimiter3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delimiter3.BackgroundImage")));
            this.delimiter3.Location = new System.Drawing.Point(521, 31);
            this.delimiter3.Margin = new System.Windows.Forms.Padding(5);
            this.delimiter3.Name = "delimiter3";
            this.delimiter3.Orientation = CAS.UI.UIControls.Auxiliary.DelimiterOrientation.Vertical;
            this.delimiter3.Size = new System.Drawing.Size(1, 35);
            this.delimiter3.Style = CAS.UI.UIControls.Auxiliary.DelimiterStyle.Dotted;
            this.delimiter3.TabIndex = 101;
            // 
            // labelWarrantyValue
            // 
            this.labelWarrantyValue.AutoEllipsis = true;
            this.labelWarrantyValue.AutoSize = true;
            this.labelWarrantyValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelWarrantyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelWarrantyValue.Location = new System.Drawing.Point(734, 29);
            this.labelWarrantyValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWarrantyValue.MinimumSize = new System.Drawing.Size(133, 37);
            this.labelWarrantyValue.Name = "labelWarrantyValue";
            this.labelWarrantyValue.Size = new System.Drawing.Size(133, 37);
            this.labelWarrantyValue.TabIndex = 94;
            this.labelWarrantyValue.Text = "WarrantyValue";
            this.labelWarrantyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWarranty
            // 
            this.labelWarranty.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarranty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelWarranty.Location = new System.Drawing.Point(530, 29);
            this.labelWarranty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWarranty.Name = "labelWarranty";
            this.labelWarranty.Size = new System.Drawing.Size(200, 37);
            this.labelWarranty.TabIndex = 93;
            this.labelWarranty.Text = "Warranty:";
            this.labelWarranty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BaseDetailSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseComponentSummary";
            this.Size = new System.Drawing.Size(1484, 405);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelExtendable.ResumeLayout(false);
            this.panelExtendable.PerformLayout();
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            this.flowLayoutPanelLinks.ResumeLayout(false);
            this.flowLayoutPanelLinks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel_Compliance;
        private Label labelManufactureDateValue;
        private Label labelManufactureDate;
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
        private Label labelCompntLifeLimitRemainsValue;
        private Label labelCompntLifeLimitRemains;
        private Label labelAircraftTCSNonInstall;
        private Label labelAircraftTCSNonInstallValue;
        private TableLayoutPanel tableLayoutPanel1;
        private CAS.UI.UIControls.Auxiliary.Delimiter delimiter3;
        private Label labelRemarks;
        private Label labelRemarksValue;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelExtendable;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private Panel _mainPanel;
        private Label labelWarrantyValue;
        private Label labelWarranty;
        private Management.Dispatchering.ReferenceLinkLabel referenceLinkLabelBaseDetail;
        private FlowLayoutPanel flowLayoutPanelLinks;
        private Management.Dispatchering.ReferenceLinkLabel referenceLinkLabelComponents;
        private Management.Dispatchering.ReferenceLinkLabel referenceLinkLabelLLPStatus;

    }
}
