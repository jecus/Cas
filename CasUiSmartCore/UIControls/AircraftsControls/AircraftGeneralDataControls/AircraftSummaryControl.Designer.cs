using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    partial class AircraftSummaryControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _checkItems = null;
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.Label labelCurrent;
			this.labelMSGValue = new System.Windows.Forms.Label();
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.labelCurrentValue = new System.Windows.Forms.Label();
			this.labelManufactureDate = new System.Windows.Forms.Label();
			this.labelManufactureDateValue = new System.Windows.Forms.Label();
			this.labelAircraftTypeCertificateNo = new System.Windows.Forms.Label();
			this.labelAircraftTypeCertificateNoValue = new System.Windows.Forms.Label();
			this.labelOperator = new System.Windows.Forms.Label();
			this.labelOwner = new System.Windows.Forms.Label();
			this.labelOperatorValue = new System.Windows.Forms.Label();
			this.labelOwnerValue = new System.Windows.Forms.Label();
			this.labelAWC = new System.Windows.Forms.Label();
			this.labelAWCValue = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelOther = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelMaxTakeOffCrossWeight = new System.Windows.Forms.Label();
			this.labelMaxTakeOffCrossWeightValue = new System.Windows.Forms.Label();
			this.labelMaxTaxiWeight = new System.Windows.Forms.Label();
			this.labelMaxTaxiWeightValue = new System.Windows.Forms.Label();
			this.labelMaxZeroFuelWeight = new System.Windows.Forms.Label();
			this.labelMaxZeroFuelWeightValue = new System.Windows.Forms.Label();
			this.labelCockpitSeating = new System.Windows.Forms.Label();
			this.labelCockpitSeatingValue = new System.Windows.Forms.Label();
			this.labelGalleys = new System.Windows.Forms.Label();
			this.labelGalleysValue = new System.Windows.Forms.Label();
			this.labelMaxLandingWeight = new System.Windows.Forms.Label();
			this.labelMaxLandingWeightValue = new System.Windows.Forms.Label();
			this.labelBasicEmptyWeight = new System.Windows.Forms.Label();
			this.labelBasicEmptyWeightValue = new System.Windows.Forms.Label();
			this.labelBasicEmptyWeightCargoConfig = new System.Windows.Forms.Label();
			this.labelBasicEmptyWeightCargoConfigValue = new System.Windows.Forms.Label();
			this.labelOpertionalEmptyWeight = new System.Windows.Forms.Label();
			this.labelFuelCapacity = new System.Windows.Forms.Label();
			this.labelMaxCruiseAltitude = new System.Windows.Forms.Label();
			this.labelMaxPayload = new System.Windows.Forms.Label();
			this.labelCruiseFuelFlow = new System.Windows.Forms.Label();
			this.labelCruise = new System.Windows.Forms.Label();
			this.labelCargoCapacityContainer = new System.Windows.Forms.Label();
			this.labelOpertionalEmptyWeightValue = new System.Windows.Forms.Label();
			this.labelFuelCapacityValue = new System.Windows.Forms.Label();
			this.labelMaxCruiseAltitudeValue = new System.Windows.Forms.Label();
			this.labelMaxPayloadValue = new System.Windows.Forms.Label();
			this.labelCruiseFuelFlowValue = new System.Windows.Forms.Label();
			this.labelCruiseValue = new System.Windows.Forms.Label();
			this.labelCargoCapacityContainerValue = new System.Windows.Forms.Label();
			this.labelLavatory = new System.Windows.Forms.Label();
			this.labelLavatoryValue = new System.Windows.Forms.Label();
			this.labelOven = new System.Windows.Forms.Label();
			this.labelOvenValue = new System.Windows.Forms.Label();
			this.labelBoiler = new System.Windows.Forms.Label();
			this.labelBoilerValue = new System.Windows.Forms.Label();
			this.labelSeatingEconomy = new System.Windows.Forms.Label();
			this.labelSeatingFirst = new System.Windows.Forms.Label();
			this.labelSeatingBusiness = new System.Windows.Forms.Label();
			this.labelSeatingEconomyValue = new System.Windows.Forms.Label();
			this.labelSeatingFirstValue = new System.Windows.Forms.Label();
			this.labelSeatingBusinessValue = new System.Windows.Forms.Label();
			this.labelAirStairDoors = new System.Windows.Forms.Label();
			this.labelAirStairDoorsValue = new System.Windows.Forms.Label();
			this.tableLayoutPanelChecksDocs = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanelChecks = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelInspection = new System.Windows.Forms.FlowLayoutPanel();
			this.labelInspection = new System.Windows.Forms.Label();
			this.referenceLinkLabelForecast = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			this.tableLayoutPanelNextChecks = new System.Windows.Forms.TableLayoutPanel();
			this.labelNextCheck = new System.Windows.Forms.Label();
			this.labelNextDate = new System.Windows.Forms.Label();
			this.labelNextTsnCan = new System.Windows.Forms.Label();
			this.labelRemains = new System.Windows.Forms.Label();
			this.tableLayoutPanelLastChecks = new System.Windows.Forms.TableLayoutPanel();
			this.labelLastCheck = new System.Windows.Forms.Label();
			this.labelLastDate = new System.Windows.Forms.Label();
			this.labelLastTsnCsn = new System.Windows.Forms.Label();
			this.flowLayoutPanelDocs = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanelCertificates = new System.Windows.Forms.FlowLayoutPanel();
			this.labelDocuments = new System.Windows.Forms.Label();
			this.referenceLinkLabelDocuments = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			this.referenceLinkLabelAvionxInv = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			this.tableLayoutPanelDocs = new System.Windows.Forms.TableLayoutPanel();
			this.labelDocDescription = new System.Windows.Forms.Label();
			this.labelDocRemain = new System.Windows.Forms.Label();
			this.labelDocNumber = new System.Windows.Forms.Label();
			this.labelDocValidTo = new System.Windows.Forms.Label();
			this.labelDocIssue = new System.Windows.Forms.Label();
			this.linkMonthlyUtilization = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
			labelCurrent = new System.Windows.Forms.Label();
			this.flowLayoutPanelMain.SuspendLayout();
			this.tableLayoutPanelMain.SuspendLayout();
			this.tableLayoutPanelChecksDocs.SuspendLayout();
			this.flowLayoutPanelChecks.SuspendLayout();
			this.flowLayoutPanelInspection.SuspendLayout();
			this.tableLayoutPanelNextChecks.SuspendLayout();
			this.tableLayoutPanelLastChecks.SuspendLayout();
			this.flowLayoutPanelDocs.SuspendLayout();
			this.flowLayoutPanelCertificates.SuspendLayout();
			this.tableLayoutPanelDocs.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelCurrent
			// 
			labelCurrent.AutoSize = true;
			labelCurrent.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			labelCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			labelCurrent.Location = new System.Drawing.Point(3, 5);
			labelCurrent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			labelCurrent.Name = "labelCurrent";
			labelCurrent.Size = new System.Drawing.Size(79, 17);
			labelCurrent.TabIndex = 27;
			labelCurrent.Text = "TSN/CSN:";
			labelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelMSGValue
			// 
			this.labelMSGValue.AutoSize = true;
			this.labelMSGValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMSGValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMSGValue.Location = new System.Drawing.Point(109, 0);
			this.labelMSGValue.Margin = new System.Windows.Forms.Padding(0);
			this.labelMSGValue.Name = "labelMSGValue";
			this.labelMSGValue.Size = new System.Drawing.Size(82, 17);
			this.labelMSGValue.TabIndex = 38;
			this.labelMSGValue.Text = "MSG Value";
			this.labelMSGValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoSize = true;
			this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelMain.Controls.Add(this.tableLayoutPanelMain);
			this.flowLayoutPanelMain.Controls.Add(this.tableLayoutPanelChecksDocs);
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(2, 17);
			this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(1258, 483);
			this.flowLayoutPanelMain.TabIndex = 36;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.AutoSize = true;
			this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMain.ColumnCount = 8;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.Controls.Add(labelCurrent, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelCurrentValue, 1, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelManufactureDate, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelManufactureDateValue, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelAircraftTypeCertificateNo, 2, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelAircraftTypeCertificateNoValue, 3, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelOperator, 4, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelOwner, 4, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelOperatorValue, 5, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelOwnerValue, 5, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelAWC, 2, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelAWCValue, 3, 1);
			this.tableLayoutPanelMain.Controls.Add(this.label1, 0, 3);
			this.tableLayoutPanelMain.Controls.Add(this.labelOther, 4, 3);
			this.tableLayoutPanelMain.Controls.Add(this.label2, 6, 3);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxTakeOffCrossWeight, 0, 5);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxTakeOffCrossWeightValue, 1, 5);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxTaxiWeight, 0, 6);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxTaxiWeightValue, 1, 6);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxZeroFuelWeight, 0, 7);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxZeroFuelWeightValue, 1, 7);
			this.tableLayoutPanelMain.Controls.Add(this.labelCockpitSeating, 4, 5);
			this.tableLayoutPanelMain.Controls.Add(this.labelCockpitSeatingValue, 5, 5);
			this.tableLayoutPanelMain.Controls.Add(this.labelGalleys, 4, 6);
			this.tableLayoutPanelMain.Controls.Add(this.labelGalleysValue, 5, 6);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxLandingWeight, 0, 8);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxLandingWeightValue, 1, 8);
			this.tableLayoutPanelMain.Controls.Add(this.labelBasicEmptyWeight, 0, 9);
			this.tableLayoutPanelMain.Controls.Add(this.labelBasicEmptyWeightValue, 1, 9);
			this.tableLayoutPanelMain.Controls.Add(this.labelBasicEmptyWeightCargoConfig, 0, 10);
			this.tableLayoutPanelMain.Controls.Add(this.labelBasicEmptyWeightCargoConfigValue, 1, 10);
			this.tableLayoutPanelMain.Controls.Add(this.labelOpertionalEmptyWeight, 0, 11);
			this.tableLayoutPanelMain.Controls.Add(this.labelFuelCapacity, 0, 12);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxCruiseAltitude, 0, 13);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxPayload, 0, 14);
			this.tableLayoutPanelMain.Controls.Add(this.labelCruiseFuelFlow, 0, 15);
			this.tableLayoutPanelMain.Controls.Add(this.labelCruise, 0, 16);
			this.tableLayoutPanelMain.Controls.Add(this.labelCargoCapacityContainer, 0, 17);
			this.tableLayoutPanelMain.Controls.Add(this.labelOpertionalEmptyWeightValue, 1, 11);
			this.tableLayoutPanelMain.Controls.Add(this.labelFuelCapacityValue, 1, 12);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxCruiseAltitudeValue, 1, 13);
			this.tableLayoutPanelMain.Controls.Add(this.labelMaxPayloadValue, 1, 14);
			this.tableLayoutPanelMain.Controls.Add(this.labelCruiseFuelFlowValue, 1, 15);
			this.tableLayoutPanelMain.Controls.Add(this.labelCruiseValue, 1, 16);
			this.tableLayoutPanelMain.Controls.Add(this.labelCargoCapacityContainerValue, 1, 17);
			this.tableLayoutPanelMain.Controls.Add(this.labelLavatory, 4, 7);
			this.tableLayoutPanelMain.Controls.Add(this.labelLavatoryValue, 5, 7);
			this.tableLayoutPanelMain.Controls.Add(this.labelOven, 4, 8);
			this.tableLayoutPanelMain.Controls.Add(this.labelOvenValue, 5, 8);
			this.tableLayoutPanelMain.Controls.Add(this.labelBoiler, 4, 9);
			this.tableLayoutPanelMain.Controls.Add(this.labelBoilerValue, 5, 9);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingEconomy, 4, 10);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingFirst, 4, 11);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingBusiness, 4, 12);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingEconomyValue, 5, 10);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingFirstValue, 5, 11);
			this.tableLayoutPanelMain.Controls.Add(this.labelSeatingBusinessValue, 5, 12);
			this.tableLayoutPanelMain.Controls.Add(this.labelAirStairDoors, 4, 13);
			this.tableLayoutPanelMain.Controls.Add(this.labelAirStairDoorsValue, 5, 13);
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(2, 2);
			this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 18;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(1254, 352);
			this.tableLayoutPanelMain.TabIndex = 35;
			// 
			// labelCurrentValue
			// 
			this.labelCurrentValue.AutoSize = true;
			this.labelCurrentValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCurrentValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCurrentValue.Location = new System.Drawing.Point(220, 5);
			this.labelCurrentValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCurrentValue.Name = "labelCurrentValue";
			this.labelCurrentValue.Size = new System.Drawing.Size(104, 17);
			this.labelCurrentValue.TabIndex = 40;
			this.labelCurrentValue.Text = "Current Value";
			this.labelCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelManufactureDate
			// 
			this.labelManufactureDate.AutoSize = true;
			this.labelManufactureDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDate.Location = new System.Drawing.Point(3, 27);
			this.labelManufactureDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelManufactureDate.Name = "labelManufactureDate";
			this.labelManufactureDate.Size = new System.Drawing.Size(109, 17);
			this.labelManufactureDate.TabIndex = 3;
			this.labelManufactureDate.Text = "Manufactured:";
			this.labelManufactureDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelManufactureDateValue
			// 
			this.labelManufactureDateValue.AutoSize = true;
			this.labelManufactureDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelManufactureDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelManufactureDateValue.Location = new System.Drawing.Point(220, 27);
			this.labelManufactureDateValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelManufactureDateValue.Name = "labelManufactureDateValue";
			this.labelManufactureDateValue.Size = new System.Drawing.Size(174, 17);
			this.labelManufactureDateValue.TabIndex = 39;
			this.labelManufactureDateValue.Text = "Manufacture Date Value";
			this.labelManufactureDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTypeCertificateNo
			// 
			this.labelAircraftTypeCertificateNo.AutoSize = true;
			this.labelAircraftTypeCertificateNo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTypeCertificateNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTypeCertificateNo.Location = new System.Drawing.Point(473, 5);
			this.labelAircraftTypeCertificateNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAircraftTypeCertificateNo.Name = "labelAircraftTypeCertificateNo";
			this.labelAircraftTypeCertificateNo.Size = new System.Drawing.Size(146, 17);
			this.labelAircraftTypeCertificateNo.TabIndex = 11;
			this.labelAircraftTypeCertificateNo.Text = "Type Certificate No:";
			this.labelAircraftTypeCertificateNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAircraftTypeCertificateNoValue
			// 
			this.labelAircraftTypeCertificateNoValue.AutoSize = true;
			this.labelAircraftTypeCertificateNoValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAircraftTypeCertificateNoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAircraftTypeCertificateNoValue.Location = new System.Drawing.Point(625, 5);
			this.labelAircraftTypeCertificateNoValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAircraftTypeCertificateNoValue.Name = "labelAircraftTypeCertificateNoValue";
			this.labelAircraftTypeCertificateNoValue.Size = new System.Drawing.Size(238, 17);
			this.labelAircraftTypeCertificateNoValue.TabIndex = 32;
			this.labelAircraftTypeCertificateNoValue.Text = "Aircraft Type Certificate No Value";
			// 
			// labelOperator
			// 
			this.labelOperator.AutoSize = true;
			this.labelOperator.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOperator.Location = new System.Drawing.Point(869, 27);
			this.labelOperator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOperator.Name = "labelOperator";
			this.labelOperator.Size = new System.Drawing.Size(77, 17);
			this.labelOperator.TabIndex = 10;
			this.labelOperator.Text = "Operator:";
			this.labelOperator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOwner
			// 
			this.labelOwner.AutoSize = true;
			this.labelOwner.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOwner.Location = new System.Drawing.Point(869, 5);
			this.labelOwner.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOwner.Name = "labelOwner";
			this.labelOwner.Size = new System.Drawing.Size(59, 17);
			this.labelOwner.TabIndex = 9;
			this.labelOwner.Text = "Owner:";
			this.labelOwner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOperatorValue
			// 
			this.labelOperatorValue.AutoSize = true;
			this.labelOperatorValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOperatorValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOperatorValue.Location = new System.Drawing.Point(1011, 27);
			this.labelOperatorValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOperatorValue.Name = "labelOperatorValue";
			this.labelOperatorValue.Size = new System.Drawing.Size(113, 17);
			this.labelOperatorValue.TabIndex = 35;
			this.labelOperatorValue.Text = "Operator Value";
			this.labelOperatorValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOwnerValue
			// 
			this.labelOwnerValue.AutoSize = true;
			this.labelOwnerValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOwnerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOwnerValue.Location = new System.Drawing.Point(1011, 5);
			this.labelOwnerValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOwnerValue.Name = "labelOwnerValue";
			this.labelOwnerValue.Size = new System.Drawing.Size(90, 17);
			this.labelOwnerValue.TabIndex = 31;
			this.labelOwnerValue.Text = "OwnerValue";
			this.labelOwnerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAWC
			// 
			this.labelAWC.AutoSize = true;
			this.labelAWC.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAWC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAWC.Location = new System.Drawing.Point(473, 27);
			this.labelAWC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAWC.Name = "labelAWC";
			this.labelAWC.Size = new System.Drawing.Size(93, 17);
			this.labelAWC.TabIndex = 80;
			this.labelAWC.Text = "AWC up To:";
			this.labelAWC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAWCValue
			// 
			this.labelAWCValue.AutoSize = true;
			this.labelAWCValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAWCValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAWCValue.Location = new System.Drawing.Point(625, 27);
			this.labelAWCValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAWCValue.Name = "labelAWCValue";
			this.labelAWCValue.Size = new System.Drawing.Size(85, 17);
			this.labelAWCValue.TabIndex = 81;
			this.labelAWCValue.Text = "AWC Value";
			this.labelAWCValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(3, 49);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(127, 17);
			this.label1.TabIndex = 78;
			this.label1.Text = "PERFORMANCE";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOther
			// 
			this.labelOther.AutoSize = true;
			this.tableLayoutPanelMain.SetColumnSpan(this.labelOther, 2);
			this.labelOther.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelOther.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOther.Location = new System.Drawing.Point(869, 49);
			this.labelOther.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOther.Name = "labelOther";
			this.labelOther.Size = new System.Drawing.Size(230, 17);
			this.labelOther.TabIndex = 77;
			this.labelOther.Text = "INTERIOR CONFIGURATION";
			this.labelOther.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label2.Location = new System.Drawing.Point(1189, 49);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 17);
			this.label2.TabIndex = 79;
			this.label2.Text = "OTHER";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxTakeOffCrossWeight
			// 
			this.labelMaxTakeOffCrossWeight.AutoSize = true;
			this.labelMaxTakeOffCrossWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxTakeOffCrossWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxTakeOffCrossWeight.Location = new System.Drawing.Point(3, 71);
			this.labelMaxTakeOffCrossWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxTakeOffCrossWeight.Name = "labelMaxTakeOffCrossWeight";
			this.labelMaxTakeOffCrossWeight.Size = new System.Drawing.Size(211, 17);
			this.labelMaxTakeOffCrossWeight.TabIndex = 44;
			this.labelMaxTakeOffCrossWeight.Text = "Max. Take-Off Cross Weight:";
			this.labelMaxTakeOffCrossWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxTakeOffCrossWeightValue
			// 
			this.labelMaxTakeOffCrossWeightValue.AutoSize = true;
			this.labelMaxTakeOffCrossWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxTakeOffCrossWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxTakeOffCrossWeightValue.Location = new System.Drawing.Point(220, 71);
			this.labelMaxTakeOffCrossWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxTakeOffCrossWeightValue.Name = "labelMaxTakeOffCrossWeightValue";
			this.labelMaxTakeOffCrossWeightValue.Size = new System.Drawing.Size(247, 17);
			this.labelMaxTakeOffCrossWeightValue.TabIndex = 72;
			this.labelMaxTakeOffCrossWeightValue.Text = "Max. Take-Off Cross Weight Value";
			this.labelMaxTakeOffCrossWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxTaxiWeight
			// 
			this.labelMaxTaxiWeight.AutoSize = true;
			this.labelMaxTaxiWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxTaxiWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxTaxiWeight.Location = new System.Drawing.Point(3, 93);
			this.labelMaxTaxiWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxTaxiWeight.Name = "labelMaxTaxiWeight";
			this.labelMaxTaxiWeight.Size = new System.Drawing.Size(133, 17);
			this.labelMaxTaxiWeight.TabIndex = 51;
			this.labelMaxTaxiWeight.Text = "Max. Taxi Weight:";
			this.labelMaxTaxiWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxTaxiWeightValue
			// 
			this.labelMaxTaxiWeightValue.AutoSize = true;
			this.labelMaxTaxiWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxTaxiWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxTaxiWeightValue.Location = new System.Drawing.Point(220, 93);
			this.labelMaxTaxiWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxTaxiWeightValue.Name = "labelMaxTaxiWeightValue";
			this.labelMaxTaxiWeightValue.Size = new System.Drawing.Size(169, 17);
			this.labelMaxTaxiWeightValue.TabIndex = 73;
			this.labelMaxTaxiWeightValue.Text = "Max. Taxi Weight Value";
			this.labelMaxTaxiWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxZeroFuelWeight
			// 
			this.labelMaxZeroFuelWeight.AutoSize = true;
			this.labelMaxZeroFuelWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxZeroFuelWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxZeroFuelWeight.Location = new System.Drawing.Point(3, 115);
			this.labelMaxZeroFuelWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxZeroFuelWeight.Name = "labelMaxZeroFuelWeight";
			this.labelMaxZeroFuelWeight.Size = new System.Drawing.Size(172, 17);
			this.labelMaxZeroFuelWeight.TabIndex = 45;
			this.labelMaxZeroFuelWeight.Text = "Max. Zero Fuel Weight:";
			this.labelMaxZeroFuelWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxZeroFuelWeightValue
			// 
			this.labelMaxZeroFuelWeightValue.AutoSize = true;
			this.labelMaxZeroFuelWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxZeroFuelWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxZeroFuelWeightValue.Location = new System.Drawing.Point(220, 115);
			this.labelMaxZeroFuelWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxZeroFuelWeightValue.Name = "labelMaxZeroFuelWeightValue";
			this.labelMaxZeroFuelWeightValue.Size = new System.Drawing.Size(208, 17);
			this.labelMaxZeroFuelWeightValue.TabIndex = 67;
			this.labelMaxZeroFuelWeightValue.Text = "Max. Zero Fuel Weight Value";
			this.labelMaxZeroFuelWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCockpitSeating
			// 
			this.labelCockpitSeating.AutoSize = true;
			this.labelCockpitSeating.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCockpitSeating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCockpitSeating.Location = new System.Drawing.Point(869, 71);
			this.labelCockpitSeating.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCockpitSeating.Name = "labelCockpitSeating";
			this.labelCockpitSeating.Size = new System.Drawing.Size(124, 17);
			this.labelCockpitSeating.TabIndex = 36;
			this.labelCockpitSeating.Text = "Cockpit Seating:";
			this.labelCockpitSeating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCockpitSeatingValue
			// 
			this.labelCockpitSeatingValue.AutoSize = true;
			this.labelCockpitSeatingValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCockpitSeatingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCockpitSeatingValue.Location = new System.Drawing.Point(1011, 71);
			this.labelCockpitSeatingValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCockpitSeatingValue.Name = "labelCockpitSeatingValue";
			this.labelCockpitSeatingValue.Size = new System.Drawing.Size(160, 17);
			this.labelCockpitSeatingValue.TabIndex = 43;
			this.labelCockpitSeatingValue.Text = "Cockpit Seating Value";
			this.labelCockpitSeatingValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelGalleys
			// 
			this.labelGalleys.AutoSize = true;
			this.labelGalleys.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelGalleys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelGalleys.Location = new System.Drawing.Point(869, 93);
			this.labelGalleys.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelGalleys.Name = "labelGalleys";
			this.labelGalleys.Size = new System.Drawing.Size(63, 17);
			this.labelGalleys.TabIndex = 37;
			this.labelGalleys.Text = "Galleys:";
			this.labelGalleys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelGalleysValue
			// 
			this.labelGalleysValue.AutoSize = true;
			this.labelGalleysValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelGalleysValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelGalleysValue.Location = new System.Drawing.Point(1011, 93);
			this.labelGalleysValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelGalleysValue.Name = "labelGalleysValue";
			this.labelGalleysValue.Size = new System.Drawing.Size(99, 17);
			this.labelGalleysValue.TabIndex = 45;
			this.labelGalleysValue.Text = "Galleys Value";
			this.labelGalleysValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxLandingWeight
			// 
			this.labelMaxLandingWeight.AutoSize = true;
			this.labelMaxLandingWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxLandingWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxLandingWeight.Location = new System.Drawing.Point(3, 137);
			this.labelMaxLandingWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxLandingWeight.Name = "labelMaxLandingWeight";
			this.labelMaxLandingWeight.Size = new System.Drawing.Size(161, 17);
			this.labelMaxLandingWeight.TabIndex = 43;
			this.labelMaxLandingWeight.Text = "Max. Landing Weight:";
			this.labelMaxLandingWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxLandingWeightValue
			// 
			this.labelMaxLandingWeightValue.AutoSize = true;
			this.labelMaxLandingWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxLandingWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxLandingWeightValue.Location = new System.Drawing.Point(220, 137);
			this.labelMaxLandingWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxLandingWeightValue.Name = "labelMaxLandingWeightValue";
			this.labelMaxLandingWeightValue.Size = new System.Drawing.Size(197, 17);
			this.labelMaxLandingWeightValue.TabIndex = 71;
			this.labelMaxLandingWeightValue.Text = "Max. Landing Weight Value";
			this.labelMaxLandingWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBasicEmptyWeight
			// 
			this.labelBasicEmptyWeight.AutoSize = true;
			this.labelBasicEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBasicEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBasicEmptyWeight.Location = new System.Drawing.Point(3, 159);
			this.labelBasicEmptyWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBasicEmptyWeight.Name = "labelBasicEmptyWeight";
			this.labelBasicEmptyWeight.Size = new System.Drawing.Size(154, 17);
			this.labelBasicEmptyWeight.TabIndex = 36;
			this.labelBasicEmptyWeight.Text = "Basic Empty Weight:";
			this.labelBasicEmptyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBasicEmptyWeightValue
			// 
			this.labelBasicEmptyWeightValue.AutoSize = true;
			this.labelBasicEmptyWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBasicEmptyWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBasicEmptyWeightValue.Location = new System.Drawing.Point(220, 159);
			this.labelBasicEmptyWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBasicEmptyWeightValue.Name = "labelBasicEmptyWeightValue";
			this.labelBasicEmptyWeightValue.Size = new System.Drawing.Size(190, 17);
			this.labelBasicEmptyWeightValue.TabIndex = 63;
			this.labelBasicEmptyWeightValue.Text = "Basic Empty Weight Value";
			this.labelBasicEmptyWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBasicEmptyWeightCargoConfig
			// 
			this.labelBasicEmptyWeightCargoConfig.AutoSize = true;
			this.labelBasicEmptyWeightCargoConfig.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBasicEmptyWeightCargoConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBasicEmptyWeightCargoConfig.Location = new System.Drawing.Point(3, 181);
			this.labelBasicEmptyWeightCargoConfig.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBasicEmptyWeightCargoConfig.Name = "labelBasicEmptyWeightCargoConfig";
			this.labelBasicEmptyWeightCargoConfig.Size = new System.Drawing.Size(207, 17);
			this.labelBasicEmptyWeightCargoConfig.TabIndex = 37;
			this.labelBasicEmptyWeightCargoConfig.Text = "Basic Empty Weight (Cargo)";
			this.labelBasicEmptyWeightCargoConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBasicEmptyWeightCargoConfigValue
			// 
			this.labelBasicEmptyWeightCargoConfigValue.AutoSize = true;
			this.labelBasicEmptyWeightCargoConfigValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBasicEmptyWeightCargoConfigValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBasicEmptyWeightCargoConfigValue.Location = new System.Drawing.Point(220, 181);
			this.labelBasicEmptyWeightCargoConfigValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBasicEmptyWeightCargoConfigValue.Name = "labelBasicEmptyWeightCargoConfigValue";
			this.labelBasicEmptyWeightCargoConfigValue.Size = new System.Drawing.Size(193, 17);
			this.labelBasicEmptyWeightCargoConfigValue.TabIndex = 64;
			this.labelBasicEmptyWeightCargoConfigValue.Text = "BEW(Cargo Config.) Value";
			this.labelBasicEmptyWeightCargoConfigValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOpertionalEmptyWeight
			// 
			this.labelOpertionalEmptyWeight.AutoSize = true;
			this.labelOpertionalEmptyWeight.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOpertionalEmptyWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOpertionalEmptyWeight.Location = new System.Drawing.Point(3, 203);
			this.labelOpertionalEmptyWeight.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOpertionalEmptyWeight.Name = "labelOpertionalEmptyWeight";
			this.labelOpertionalEmptyWeight.Size = new System.Drawing.Size(198, 17);
			this.labelOpertionalEmptyWeight.TabIndex = 52;
			this.labelOpertionalEmptyWeight.Text = "Operational Empty Weight:";
			this.labelOpertionalEmptyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFuelCapacity
			// 
			this.labelFuelCapacity.AutoSize = true;
			this.labelFuelCapacity.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFuelCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFuelCapacity.Location = new System.Drawing.Point(3, 225);
			this.labelFuelCapacity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelFuelCapacity.Name = "labelFuelCapacity";
			this.labelFuelCapacity.Size = new System.Drawing.Size(106, 17);
			this.labelFuelCapacity.TabIndex = 41;
			this.labelFuelCapacity.Text = "Fuel Capacity:";
			this.labelFuelCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxCruiseAltitude
			// 
			this.labelMaxCruiseAltitude.AutoSize = true;
			this.labelMaxCruiseAltitude.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxCruiseAltitude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxCruiseAltitude.Location = new System.Drawing.Point(3, 247);
			this.labelMaxCruiseAltitude.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxCruiseAltitude.Name = "labelMaxCruiseAltitude";
			this.labelMaxCruiseAltitude.Size = new System.Drawing.Size(155, 17);
			this.labelMaxCruiseAltitude.TabIndex = 42;
			this.labelMaxCruiseAltitude.Text = "Max. Cruise Altitude:";
			this.labelMaxCruiseAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxPayload
			// 
			this.labelMaxPayload.AutoSize = true;
			this.labelMaxPayload.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxPayload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxPayload.Location = new System.Drawing.Point(3, 269);
			this.labelMaxPayload.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxPayload.Name = "labelMaxPayload";
			this.labelMaxPayload.Size = new System.Drawing.Size(100, 17);
			this.labelMaxPayload.TabIndex = 62;
			this.labelMaxPayload.Text = "Max Payload:";
			this.labelMaxPayload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCruiseFuelFlow
			// 
			this.labelCruiseFuelFlow.AutoSize = true;
			this.labelCruiseFuelFlow.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCruiseFuelFlow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCruiseFuelFlow.Location = new System.Drawing.Point(3, 291);
			this.labelCruiseFuelFlow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCruiseFuelFlow.Name = "labelCruiseFuelFlow";
			this.labelCruiseFuelFlow.Size = new System.Drawing.Size(127, 17);
			this.labelCruiseFuelFlow.TabIndex = 40;
			this.labelCruiseFuelFlow.Text = "Cruise Fuel Flow:";
			this.labelCruiseFuelFlow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCruise
			// 
			this.labelCruise.AutoSize = true;
			this.labelCruise.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCruise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCruise.Location = new System.Drawing.Point(3, 313);
			this.labelCruise.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCruise.Name = "labelCruise";
			this.labelCruise.Size = new System.Drawing.Size(110, 17);
			this.labelCruise.TabIndex = 39;
			this.labelCruise.Text = "Cruise (Mach):";
			this.labelCruise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCargoCapacityContainer
			// 
			this.labelCargoCapacityContainer.AutoSize = true;
			this.labelCargoCapacityContainer.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCargoCapacityContainer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCargoCapacityContainer.Location = new System.Drawing.Point(3, 335);
			this.labelCargoCapacityContainer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCargoCapacityContainer.Name = "labelCargoCapacityContainer";
			this.labelCargoCapacityContainer.Size = new System.Drawing.Size(193, 17);
			this.labelCargoCapacityContainer.TabIndex = 38;
			this.labelCargoCapacityContainer.Text = "Cargo Capacity Container:";
			this.labelCargoCapacityContainer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOpertionalEmptyWeightValue
			// 
			this.labelOpertionalEmptyWeightValue.AutoSize = true;
			this.labelOpertionalEmptyWeightValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOpertionalEmptyWeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOpertionalEmptyWeightValue.Location = new System.Drawing.Point(220, 203);
			this.labelOpertionalEmptyWeightValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOpertionalEmptyWeightValue.Name = "labelOpertionalEmptyWeightValue";
			this.labelOpertionalEmptyWeightValue.Size = new System.Drawing.Size(234, 17);
			this.labelOpertionalEmptyWeightValue.TabIndex = 68;
			this.labelOpertionalEmptyWeightValue.Text = "Operational Empty Weight Value";
			this.labelOpertionalEmptyWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelFuelCapacityValue
			// 
			this.labelFuelCapacityValue.AutoSize = true;
			this.labelFuelCapacityValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelFuelCapacityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelFuelCapacityValue.Location = new System.Drawing.Point(220, 225);
			this.labelFuelCapacityValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelFuelCapacityValue.Name = "labelFuelCapacityValue";
			this.labelFuelCapacityValue.Size = new System.Drawing.Size(142, 17);
			this.labelFuelCapacityValue.TabIndex = 66;
			this.labelFuelCapacityValue.Text = "Fuel Capacity Value";
			this.labelFuelCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxCruiseAltitudeValue
			// 
			this.labelMaxCruiseAltitudeValue.AutoSize = true;
			this.labelMaxCruiseAltitudeValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxCruiseAltitudeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxCruiseAltitudeValue.Location = new System.Drawing.Point(220, 247);
			this.labelMaxCruiseAltitudeValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxCruiseAltitudeValue.Name = "labelMaxCruiseAltitudeValue";
			this.labelMaxCruiseAltitudeValue.Size = new System.Drawing.Size(191, 17);
			this.labelMaxCruiseAltitudeValue.TabIndex = 65;
			this.labelMaxCruiseAltitudeValue.Text = "Max. Cruise Altitude Value";
			this.labelMaxCruiseAltitudeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelMaxPayloadValue
			// 
			this.labelMaxPayloadValue.AutoSize = true;
			this.labelMaxPayloadValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelMaxPayloadValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelMaxPayloadValue.Location = new System.Drawing.Point(220, 269);
			this.labelMaxPayloadValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelMaxPayloadValue.Name = "labelMaxPayloadValue";
			this.labelMaxPayloadValue.Size = new System.Drawing.Size(136, 17);
			this.labelMaxPayloadValue.TabIndex = 70;
			this.labelMaxPayloadValue.Text = "Max Payload Value";
			this.labelMaxPayloadValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCruiseFuelFlowValue
			// 
			this.labelCruiseFuelFlowValue.AutoSize = true;
			this.labelCruiseFuelFlowValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCruiseFuelFlowValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCruiseFuelFlowValue.Location = new System.Drawing.Point(220, 291);
			this.labelCruiseFuelFlowValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCruiseFuelFlowValue.Name = "labelCruiseFuelFlowValue";
			this.labelCruiseFuelFlowValue.Size = new System.Drawing.Size(163, 17);
			this.labelCruiseFuelFlowValue.TabIndex = 65;
			this.labelCruiseFuelFlowValue.Text = "Cruise Fuel Flow Value";
			this.labelCruiseFuelFlowValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCruiseValue
			// 
			this.labelCruiseValue.AutoSize = true;
			this.labelCruiseValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCruiseValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCruiseValue.Location = new System.Drawing.Point(220, 313);
			this.labelCruiseValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCruiseValue.Name = "labelCruiseValue";
			this.labelCruiseValue.Size = new System.Drawing.Size(146, 17);
			this.labelCruiseValue.TabIndex = 64;
			this.labelCruiseValue.Text = "Cruise (Mach) Value";
			this.labelCruiseValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCargoCapacityContainerValue
			// 
			this.labelCargoCapacityContainerValue.AutoSize = true;
			this.labelCargoCapacityContainerValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelCargoCapacityContainerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCargoCapacityContainerValue.Location = new System.Drawing.Point(220, 335);
			this.labelCargoCapacityContainerValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelCargoCapacityContainerValue.Name = "labelCargoCapacityContainerValue";
			this.labelCargoCapacityContainerValue.Size = new System.Drawing.Size(229, 17);
			this.labelCargoCapacityContainerValue.TabIndex = 66;
			this.labelCargoCapacityContainerValue.Text = "Cargo Capacity Container Value";
			this.labelCargoCapacityContainerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelLavatory
			// 
			this.labelLavatory.AutoSize = true;
			this.labelLavatory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLavatory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLavatory.Location = new System.Drawing.Point(869, 115);
			this.labelLavatory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelLavatory.Name = "labelLavatory";
			this.labelLavatory.Size = new System.Drawing.Size(75, 17);
			this.labelLavatory.TabIndex = 38;
			this.labelLavatory.Text = "Lavatory:";
			this.labelLavatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelLavatoryValue
			// 
			this.labelLavatoryValue.AutoSize = true;
			this.labelLavatoryValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLavatoryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLavatoryValue.Location = new System.Drawing.Point(1011, 115);
			this.labelLavatoryValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelLavatoryValue.Name = "labelLavatoryValue";
			this.labelLavatoryValue.Size = new System.Drawing.Size(111, 17);
			this.labelLavatoryValue.TabIndex = 38;
			this.labelLavatoryValue.Text = "Lavatory Value";
			this.labelLavatoryValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOven
			// 
			this.labelOven.AutoSize = true;
			this.labelOven.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOven.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOven.Location = new System.Drawing.Point(869, 137);
			this.labelOven.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOven.Name = "labelOven";
			this.labelOven.Size = new System.Drawing.Size(50, 17);
			this.labelOven.TabIndex = 43;
			this.labelOven.Text = "Oven:";
			this.labelOven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelOvenValue
			// 
			this.labelOvenValue.AutoSize = true;
			this.labelOvenValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelOvenValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelOvenValue.Location = new System.Drawing.Point(1011, 137);
			this.labelOvenValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelOvenValue.Name = "labelOvenValue";
			this.labelOvenValue.Size = new System.Drawing.Size(86, 17);
			this.labelOvenValue.TabIndex = 44;
			this.labelOvenValue.Text = "Oven Value";
			this.labelOvenValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBoiler
			// 
			this.labelBoiler.AutoSize = true;
			this.labelBoiler.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBoiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBoiler.Location = new System.Drawing.Point(869, 159);
			this.labelBoiler.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBoiler.Name = "labelBoiler";
			this.labelBoiler.Size = new System.Drawing.Size(53, 17);
			this.labelBoiler.TabIndex = 44;
			this.labelBoiler.Text = "Boiler:";
			this.labelBoiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelBoilerValue
			// 
			this.labelBoilerValue.AutoSize = true;
			this.labelBoilerValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelBoilerValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBoilerValue.Location = new System.Drawing.Point(1011, 159);
			this.labelBoilerValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelBoilerValue.Name = "labelBoilerValue";
			this.labelBoilerValue.Size = new System.Drawing.Size(89, 17);
			this.labelBoilerValue.TabIndex = 48;
			this.labelBoilerValue.Text = "Boiler Value";
			this.labelBoilerValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingEconomy
			// 
			this.labelSeatingEconomy.AutoSize = true;
			this.labelSeatingEconomy.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingEconomy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingEconomy.Location = new System.Drawing.Point(869, 181);
			this.labelSeatingEconomy.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingEconomy.Name = "labelSeatingEconomy";
			this.labelSeatingEconomy.Size = new System.Drawing.Size(136, 17);
			this.labelSeatingEconomy.TabIndex = 39;
			this.labelSeatingEconomy.Text = "Seating Economy:";
			this.labelSeatingEconomy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingFirst
			// 
			this.labelSeatingFirst.AutoSize = true;
			this.labelSeatingFirst.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingFirst.Location = new System.Drawing.Point(869, 203);
			this.labelSeatingFirst.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingFirst.Name = "labelSeatingFirst";
			this.labelSeatingFirst.Size = new System.Drawing.Size(103, 17);
			this.labelSeatingFirst.TabIndex = 52;
			this.labelSeatingFirst.Text = "Seating First:";
			this.labelSeatingFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingBusiness
			// 
			this.labelSeatingBusiness.AutoSize = true;
			this.labelSeatingBusiness.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingBusiness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingBusiness.Location = new System.Drawing.Point(869, 225);
			this.labelSeatingBusiness.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingBusiness.Name = "labelSeatingBusiness";
			this.labelSeatingBusiness.Size = new System.Drawing.Size(135, 17);
			this.labelSeatingBusiness.TabIndex = 50;
			this.labelSeatingBusiness.Text = "Seating Business:";
			this.labelSeatingBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingEconomyValue
			// 
			this.labelSeatingEconomyValue.AutoSize = true;
			this.labelSeatingEconomyValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingEconomyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingEconomyValue.Location = new System.Drawing.Point(1011, 181);
			this.labelSeatingEconomyValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingEconomyValue.Name = "labelSeatingEconomyValue";
			this.labelSeatingEconomyValue.Size = new System.Drawing.Size(172, 17);
			this.labelSeatingEconomyValue.TabIndex = 42;
			this.labelSeatingEconomyValue.Text = "Seating Economy Value";
			this.labelSeatingEconomyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingFirstValue
			// 
			this.labelSeatingFirstValue.AutoSize = true;
			this.labelSeatingFirstValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingFirstValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingFirstValue.Location = new System.Drawing.Point(1011, 203);
			this.labelSeatingFirstValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingFirstValue.Name = "labelSeatingFirstValue";
			this.labelSeatingFirstValue.Size = new System.Drawing.Size(139, 17);
			this.labelSeatingFirstValue.TabIndex = 46;
			this.labelSeatingFirstValue.Text = "Seating First Value";
			this.labelSeatingFirstValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSeatingBusinessValue
			// 
			this.labelSeatingBusinessValue.AutoSize = true;
			this.labelSeatingBusinessValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelSeatingBusinessValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSeatingBusinessValue.Location = new System.Drawing.Point(1011, 225);
			this.labelSeatingBusinessValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelSeatingBusinessValue.Name = "labelSeatingBusinessValue";
			this.labelSeatingBusinessValue.Size = new System.Drawing.Size(171, 17);
			this.labelSeatingBusinessValue.TabIndex = 47;
			this.labelSeatingBusinessValue.Text = "Seating Business Value";
			this.labelSeatingBusinessValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAirStairDoors
			// 
			this.labelAirStairDoors.AutoSize = true;
			this.labelAirStairDoors.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAirStairDoors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAirStairDoors.Location = new System.Drawing.Point(869, 247);
			this.labelAirStairDoors.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAirStairDoors.Name = "labelAirStairDoors";
			this.labelAirStairDoors.Size = new System.Drawing.Size(119, 17);
			this.labelAirStairDoors.TabIndex = 45;
			this.labelAirStairDoors.Text = "Air Stair Doors:";
			this.labelAirStairDoors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelAirStairDoorsValue
			// 
			this.labelAirStairDoorsValue.AutoSize = true;
			this.labelAirStairDoorsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelAirStairDoorsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAirStairDoorsValue.Location = new System.Drawing.Point(1011, 247);
			this.labelAirStairDoorsValue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelAirStairDoorsValue.Name = "labelAirStairDoorsValue";
			this.labelAirStairDoorsValue.Size = new System.Drawing.Size(155, 17);
			this.labelAirStairDoorsValue.TabIndex = 40;
			this.labelAirStairDoorsValue.Text = "Air Stair Doors Value";
			this.labelAirStairDoorsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanelChecksDocs
			// 
			this.tableLayoutPanelChecksDocs.AutoSize = true;
			this.tableLayoutPanelChecksDocs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelChecksDocs.ColumnCount = 2;
			this.tableLayoutPanelChecksDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelChecksDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelChecksDocs.Controls.Add(this.flowLayoutPanelChecks, 0, 0);
			this.tableLayoutPanelChecksDocs.Controls.Add(this.flowLayoutPanelDocs, 1, 0);
			this.tableLayoutPanelChecksDocs.Location = new System.Drawing.Point(2, 358);
			this.tableLayoutPanelChecksDocs.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanelChecksDocs.Name = "tableLayoutPanelChecksDocs";
			this.tableLayoutPanelChecksDocs.RowCount = 1;
			this.tableLayoutPanelChecksDocs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelChecksDocs.Size = new System.Drawing.Size(638, 123);
			this.tableLayoutPanelChecksDocs.TabIndex = 41;
			// 
			// flowLayoutPanelChecks
			// 
			this.flowLayoutPanelChecks.AutoSize = true;
			this.flowLayoutPanelChecks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelChecks.Controls.Add(this.flowLayoutPanelInspection);
			this.flowLayoutPanelChecks.Controls.Add(this.tableLayoutPanelNextChecks);
			this.flowLayoutPanelChecks.Controls.Add(this.tableLayoutPanelLastChecks);
			this.flowLayoutPanelChecks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelChecks.Location = new System.Drawing.Point(2, 2);
			this.flowLayoutPanelChecks.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelChecks.Name = "flowLayoutPanelChecks";
			this.flowLayoutPanelChecks.Size = new System.Drawing.Size(302, 119);
			this.flowLayoutPanelChecks.TabIndex = 42;
			this.flowLayoutPanelChecks.WrapContents = false;
			// 
			// flowLayoutPanelInspection
			// 
			this.flowLayoutPanelInspection.AutoSize = true;
			this.flowLayoutPanelInspection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelInspection.Controls.Add(this.labelInspection);
			this.flowLayoutPanelInspection.Controls.Add(this.labelMSGValue);
			this.flowLayoutPanelInspection.Controls.Add(this.referenceLinkLabelForecast);
			this.flowLayoutPanelInspection.Location = new System.Drawing.Point(2, 16);
			this.flowLayoutPanelInspection.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
			this.flowLayoutPanelInspection.Name = "flowLayoutPanelInspection";
			this.flowLayoutPanelInspection.Size = new System.Drawing.Size(277, 17);
			this.flowLayoutPanelInspection.TabIndex = 41;
			this.flowLayoutPanelInspection.WrapContents = false;
			// 
			// labelInspection
			// 
			this.labelInspection.AutoSize = true;
			this.labelInspection.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelInspection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelInspection.Location = new System.Drawing.Point(0, 0);
			this.labelInspection.Margin = new System.Windows.Forms.Padding(0);
			this.labelInspection.Name = "labelInspection";
			this.labelInspection.Size = new System.Drawing.Size(109, 17);
			this.labelInspection.TabIndex = 82;
			this.labelInspection.Text = "INSPECTION";
			this.labelInspection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// referenceLinkLabelForecast
			// 
			this.referenceLinkLabelForecast.AutoSize = true;
			this.referenceLinkLabelForecast.Displayer = null;
			this.referenceLinkLabelForecast.DisplayerText = null;
			this.referenceLinkLabelForecast.Entity = null;
			this.referenceLinkLabelForecast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.referenceLinkLabelForecast.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.referenceLinkLabelForecast.Location = new System.Drawing.Point(206, 0);
			this.referenceLinkLabelForecast.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.referenceLinkLabelForecast.Name = "referenceLinkLabelForecast";
			this.referenceLinkLabelForecast.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.referenceLinkLabelForecast.Size = new System.Drawing.Size(68, 17);
			this.referenceLinkLabelForecast.TabIndex = 37;
			this.referenceLinkLabelForecast.TabStop = true;
			this.referenceLinkLabelForecast.Text = "Forecast";
			this.referenceLinkLabelForecast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.referenceLinkLabelForecast.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelForecastDisplayerRequested);
			// 
			// tableLayoutPanelNextChecks
			// 
			this.tableLayoutPanelNextChecks.AutoSize = true;
			this.tableLayoutPanelNextChecks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelNextChecks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanelNextChecks.ColumnCount = 4;
			this.tableLayoutPanelNextChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelNextChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelNextChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelNextChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelNextChecks.Controls.Add(this.labelNextCheck, 0, 0);
			this.tableLayoutPanelNextChecks.Controls.Add(this.labelNextDate, 1, 0);
			this.tableLayoutPanelNextChecks.Controls.Add(this.labelNextTsnCan, 2, 0);
			this.tableLayoutPanelNextChecks.Controls.Add(this.labelRemains, 3, 0);
			this.tableLayoutPanelNextChecks.Location = new System.Drawing.Point(2, 51);
			this.tableLayoutPanelNextChecks.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
			this.tableLayoutPanelNextChecks.Name = "tableLayoutPanelNextChecks";
			this.tableLayoutPanelNextChecks.RowCount = 1;
			this.tableLayoutPanelNextChecks.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelNextChecks.Size = new System.Drawing.Size(298, 24);
			this.tableLayoutPanelNextChecks.TabIndex = 39;
			// 
			// labelNextCheck
			// 
			this.labelNextCheck.AutoSize = true;
			this.labelNextCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNextCheck.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextCheck.Location = new System.Drawing.Point(4, 6);
			this.labelNextCheck.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelNextCheck.Name = "labelNextCheck";
			this.labelNextCheck.Size = new System.Drawing.Size(88, 17);
			this.labelNextCheck.TabIndex = 54;
			this.labelNextCheck.Text = "Next Check";
			this.labelNextCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNextDate
			// 
			this.labelNextDate.AutoSize = true;
			this.labelNextDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNextDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextDate.Location = new System.Drawing.Point(99, 6);
			this.labelNextDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelNextDate.Name = "labelNextDate";
			this.labelNextDate.Size = new System.Drawing.Size(41, 17);
			this.labelNextDate.TabIndex = 55;
			this.labelNextDate.Text = "Date";
			this.labelNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelNextTsnCan
			// 
			this.labelNextTsnCan.AutoSize = true;
			this.labelNextTsnCan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelNextTsnCan.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelNextTsnCan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNextTsnCan.Location = new System.Drawing.Point(147, 6);
			this.labelNextTsnCan.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelNextTsnCan.Name = "labelNextTsnCan";
			this.labelNextTsnCan.Size = new System.Drawing.Size(73, 17);
			this.labelNextTsnCan.TabIndex = 56;
			this.labelNextTsnCan.Text = "TSN/CSN";
			this.labelNextTsnCan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelRemains
			// 
			this.labelRemains.AutoSize = true;
			this.labelRemains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelRemains.Location = new System.Drawing.Point(227, 6);
			this.labelRemains.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelRemains.Name = "labelRemains";
			this.labelRemains.Size = new System.Drawing.Size(67, 17);
			this.labelRemains.TabIndex = 57;
			this.labelRemains.Text = "Remains";
			this.labelRemains.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanelLastChecks
			// 
			this.tableLayoutPanelLastChecks.AutoSize = true;
			this.tableLayoutPanelLastChecks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelLastChecks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanelLastChecks.ColumnCount = 3;
			this.tableLayoutPanelLastChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelLastChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelLastChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelLastChecks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
			this.tableLayoutPanelLastChecks.Controls.Add(this.labelLastCheck, 0, 0);
			this.tableLayoutPanelLastChecks.Controls.Add(this.labelLastDate, 1, 0);
			this.tableLayoutPanelLastChecks.Controls.Add(this.labelLastTsnCsn, 2, 0);
			this.tableLayoutPanelLastChecks.Location = new System.Drawing.Point(2, 93);
			this.tableLayoutPanelLastChecks.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
			this.tableLayoutPanelLastChecks.Name = "tableLayoutPanelLastChecks";
			this.tableLayoutPanelLastChecks.RowCount = 1;
			this.tableLayoutPanelLastChecks.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelLastChecks.Size = new System.Drawing.Size(227, 24);
			this.tableLayoutPanelLastChecks.TabIndex = 40;
			// 
			// labelLastCheck
			// 
			this.labelLastCheck.AutoSize = true;
			this.labelLastCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelLastCheck.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLastCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLastCheck.Location = new System.Drawing.Point(4, 6);
			this.labelLastCheck.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelLastCheck.Name = "labelLastCheck";
			this.labelLastCheck.Size = new System.Drawing.Size(85, 17);
			this.labelLastCheck.TabIndex = 54;
			this.labelLastCheck.Text = "Last Check";
			this.labelLastCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLastDate
			// 
			this.labelLastDate.AutoSize = true;
			this.labelLastDate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelLastDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLastDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLastDate.Location = new System.Drawing.Point(96, 6);
			this.labelLastDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelLastDate.Name = "labelLastDate";
			this.labelLastDate.Size = new System.Drawing.Size(41, 17);
			this.labelLastDate.TabIndex = 55;
			this.labelLastDate.Text = "Date";
			this.labelLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelLastTsnCsn
			// 
			this.labelLastTsnCsn.AutoSize = true;
			this.labelLastTsnCsn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelLastTsnCsn.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelLastTsnCsn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelLastTsnCsn.Location = new System.Drawing.Point(147, 6);
			this.labelLastTsnCsn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 0);
			this.labelLastTsnCsn.Name = "labelLastTsnCsn";
			this.labelLastTsnCsn.Size = new System.Drawing.Size(73, 17);
			this.labelLastTsnCsn.TabIndex = 56;
			this.labelLastTsnCsn.Text = "TSN/CSN";
			this.labelLastTsnCsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// flowLayoutPanelDocs
			// 
			this.flowLayoutPanelDocs.AutoSize = true;
			this.flowLayoutPanelDocs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelDocs.Controls.Add(this.flowLayoutPanelCertificates);
			this.flowLayoutPanelDocs.Controls.Add(this.tableLayoutPanelDocs);
			this.flowLayoutPanelDocs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelDocs.Location = new System.Drawing.Point(308, 2);
			this.flowLayoutPanelDocs.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelDocs.Name = "flowLayoutPanelDocs";
			this.flowLayoutPanelDocs.Size = new System.Drawing.Size(328, 77);
			this.flowLayoutPanelDocs.TabIndex = 43;
			this.flowLayoutPanelDocs.WrapContents = false;
			// 
			// flowLayoutPanelCertificates
			// 
			this.flowLayoutPanelCertificates.AutoSize = true;
			this.flowLayoutPanelCertificates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelCertificates.Controls.Add(this.labelDocuments);
			this.flowLayoutPanelCertificates.Controls.Add(this.referenceLinkLabelDocuments);
			this.flowLayoutPanelCertificates.Controls.Add(this.referenceLinkLabelAvionxInv);
			this.flowLayoutPanelCertificates.Location = new System.Drawing.Point(2, 16);
			this.flowLayoutPanelCertificates.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
			this.flowLayoutPanelCertificates.Name = "flowLayoutPanelCertificates";
			this.flowLayoutPanelCertificates.Size = new System.Drawing.Size(324, 17);
			this.flowLayoutPanelCertificates.TabIndex = 84;
			this.flowLayoutPanelCertificates.WrapContents = false;
			// 
			// labelDocuments
			// 
			this.labelDocuments.AutoSize = true;
			this.labelDocuments.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocuments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocuments.Location = new System.Drawing.Point(0, 0);
			this.labelDocuments.Margin = new System.Windows.Forms.Padding(0);
			this.labelDocuments.Name = "labelDocuments";
			this.labelDocuments.Size = new System.Drawing.Size(117, 17);
			this.labelDocuments.TabIndex = 82;
			this.labelDocuments.Text = "CERTIFICATE";
			this.labelDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// referenceLinkLabelDocuments
			// 
			this.referenceLinkLabelDocuments.AutoSize = true;
			this.referenceLinkLabelDocuments.Displayer = null;
			this.referenceLinkLabelDocuments.DisplayerText = null;
			this.referenceLinkLabelDocuments.Entity = null;
			this.referenceLinkLabelDocuments.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.referenceLinkLabelDocuments.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.referenceLinkLabelDocuments.Location = new System.Drawing.Point(132, 0);
			this.referenceLinkLabelDocuments.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.referenceLinkLabelDocuments.Name = "referenceLinkLabelDocuments";
			this.referenceLinkLabelDocuments.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.referenceLinkLabelDocuments.Size = new System.Drawing.Size(88, 17);
			this.referenceLinkLabelDocuments.TabIndex = 37;
			this.referenceLinkLabelDocuments.TabStop = true;
			this.referenceLinkLabelDocuments.Text = "Documents";
			this.referenceLinkLabelDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.referenceLinkLabelDocuments.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelDocumentsDisplayerRequested);
			// 
			// referenceLinkLabelAvionxInv
			// 
			this.referenceLinkLabelAvionxInv.AutoSize = true;
			this.referenceLinkLabelAvionxInv.Displayer = null;
			this.referenceLinkLabelAvionxInv.DisplayerText = null;
			this.referenceLinkLabelAvionxInv.Entity = null;
			this.referenceLinkLabelAvionxInv.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.referenceLinkLabelAvionxInv.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.referenceLinkLabelAvionxInv.Location = new System.Drawing.Point(238, 0);
			this.referenceLinkLabelAvionxInv.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
			this.referenceLinkLabelAvionxInv.Name = "referenceLinkLabelAvionxInv";
			this.referenceLinkLabelAvionxInv.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.referenceLinkLabelAvionxInv.Size = new System.Drawing.Size(83, 17);
			this.referenceLinkLabelAvionxInv.TabIndex = 83;
			this.referenceLinkLabelAvionxInv.TabStop = true;
			this.referenceLinkLabelAvionxInv.Text = "Equipment";
			this.referenceLinkLabelAvionxInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.referenceLinkLabelAvionxInv.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ReferenceLinkLabelAvionxInvDisplayerRequested);
			// 
			// tableLayoutPanelDocs
			// 
			this.tableLayoutPanelDocs.AutoSize = true;
			this.tableLayoutPanelDocs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelDocs.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanelDocs.ColumnCount = 5;
			this.tableLayoutPanelDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDocs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelDocs.Controls.Add(this.labelDocDescription, 0, 0);
			this.tableLayoutPanelDocs.Controls.Add(this.labelDocRemain, 4, 0);
			this.tableLayoutPanelDocs.Controls.Add(this.labelDocNumber, 1, 0);
			this.tableLayoutPanelDocs.Controls.Add(this.labelDocValidTo, 3, 0);
			this.tableLayoutPanelDocs.Controls.Add(this.labelDocIssue, 2, 0);
			this.tableLayoutPanelDocs.Location = new System.Drawing.Point(2, 51);
			this.tableLayoutPanelDocs.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
			this.tableLayoutPanelDocs.Name = "tableLayoutPanelDocs";
			this.tableLayoutPanelDocs.RowCount = 1;
			this.tableLayoutPanelDocs.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelDocs.Size = new System.Drawing.Size(313, 24);
			this.tableLayoutPanelDocs.TabIndex = 83;
			// 
			// labelDocDescription
			// 
			this.labelDocDescription.AutoSize = true;
			this.labelDocDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDocDescription.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocDescription.Location = new System.Drawing.Point(4, 6);
			this.labelDocDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelDocDescription.Name = "labelDocDescription";
			this.labelDocDescription.Size = new System.Drawing.Size(87, 17);
			this.labelDocDescription.TabIndex = 54;
			this.labelDocDescription.Text = "Description";
			this.labelDocDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDocRemain
			// 
			this.labelDocRemain.AutoSize = true;
			this.labelDocRemain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDocRemain.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocRemain.Location = new System.Drawing.Point(250, 6);
			this.labelDocRemain.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelDocRemain.Name = "labelDocRemain";
			this.labelDocRemain.Size = new System.Drawing.Size(59, 17);
			this.labelDocRemain.TabIndex = 58;
			this.labelDocRemain.Text = "Remain";
			this.labelDocRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDocNumber
			// 
			this.labelDocNumber.AutoSize = true;
			this.labelDocNumber.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDocNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocNumber.Location = new System.Drawing.Point(98, 6);
			this.labelDocNumber.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelDocNumber.Name = "labelDocNumber";
			this.labelDocNumber.Size = new System.Drawing.Size(24, 17);
			this.labelDocNumber.TabIndex = 55;
			this.labelDocNumber.Text = "№";
			this.labelDocNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDocValidTo
			// 
			this.labelDocValidTo.AutoSize = true;
			this.labelDocValidTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDocValidTo.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocValidTo.Location = new System.Drawing.Point(182, 6);
			this.labelDocValidTo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelDocValidTo.Name = "labelDocValidTo";
			this.labelDocValidTo.Size = new System.Drawing.Size(61, 17);
			this.labelDocValidTo.TabIndex = 57;
			this.labelDocValidTo.Text = "Valid To";
			this.labelDocValidTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDocIssue
			// 
			this.labelDocIssue.AutoSize = true;
			this.labelDocIssue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDocIssue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelDocIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDocIssue.Location = new System.Drawing.Point(129, 6);
			this.labelDocIssue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
			this.labelDocIssue.Name = "labelDocIssue";
			this.labelDocIssue.Size = new System.Drawing.Size(46, 17);
			this.labelDocIssue.TabIndex = 56;
			this.labelDocIssue.Text = "Issue";
			this.labelDocIssue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkMonthlyUtilization
			// 
			this.linkMonthlyUtilization.AutoSize = true;
			this.linkMonthlyUtilization.Displayer = null;
			this.linkMonthlyUtilization.DisplayerText = null;
			this.linkMonthlyUtilization.Entity = null;
			this.linkMonthlyUtilization.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkMonthlyUtilization.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkMonthlyUtilization.Location = new System.Drawing.Point(4, 0);
			this.linkMonthlyUtilization.Name = "linkMonthlyUtilization";
			this.linkMonthlyUtilization.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
			this.linkMonthlyUtilization.Size = new System.Drawing.Size(136, 17);
			this.linkMonthlyUtilization.TabIndex = 0;
			this.linkMonthlyUtilization.TabStop = true;
			this.linkMonthlyUtilization.Text = "Monthly Utilization";
			this.linkMonthlyUtilization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AircraftSummaryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Controls.Add(this.linkMonthlyUtilization);
			this.Name = "AircraftSummaryControl";
			this.Size = new System.Drawing.Size(1262, 502);
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.tableLayoutPanelChecksDocs.ResumeLayout(false);
			this.tableLayoutPanelChecksDocs.PerformLayout();
			this.flowLayoutPanelChecks.ResumeLayout(false);
			this.flowLayoutPanelChecks.PerformLayout();
			this.flowLayoutPanelInspection.ResumeLayout(false);
			this.flowLayoutPanelInspection.PerformLayout();
			this.tableLayoutPanelNextChecks.ResumeLayout(false);
			this.tableLayoutPanelNextChecks.PerformLayout();
			this.tableLayoutPanelLastChecks.ResumeLayout(false);
			this.tableLayoutPanelLastChecks.PerformLayout();
			this.flowLayoutPanelDocs.ResumeLayout(false);
			this.flowLayoutPanelDocs.PerformLayout();
			this.flowLayoutPanelCertificates.ResumeLayout(false);
			this.flowLayoutPanelCertificates.PerformLayout();
			this.tableLayoutPanelDocs.ResumeLayout(false);
			this.tableLayoutPanelDocs.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        private ReferenceLinkLabel linkMonthlyUtilization;
        #endregion

        private Label labelMSGValue;
        private FlowLayoutPanel flowLayoutPanelMain;
        private Label labelInspection;
        private TableLayoutPanel tableLayoutPanelNextChecks;
        private Label labelNextCheck;
        private Label labelNextDate;
        private Label labelNextTsnCan;
        private Label labelRemains;
        private TableLayoutPanel tableLayoutPanelLastChecks;
        private Label labelLastCheck;
        private Label labelLastDate;
        private Label labelLastTsnCsn;
        private TableLayoutPanel tableLayoutPanelChecksDocs;
        private FlowLayoutPanel flowLayoutPanelChecks;
        private FlowLayoutPanel flowLayoutPanelDocs;
        private Label labelDocuments;
        private TableLayoutPanel tableLayoutPanelDocs;
        private Label labelDocRemain;
        private Label labelDocDescription;
        private Label labelDocNumber;
        private Label labelDocIssue;
        private Label labelDocValidTo;
        private FlowLayoutPanel flowLayoutPanelInspection;
        private ReferenceLinkLabel referenceLinkLabelForecast;
        private FlowLayoutPanel flowLayoutPanelCertificates;
        private ReferenceLinkLabel referenceLinkLabelDocuments;
        private ReferenceLinkLabel referenceLinkLabelAvionxInv;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelCurrentValue;
        private Label labelManufactureDate;
        private Label labelManufactureDateValue;
        private Label labelAircraftTypeCertificateNo;
        private Label labelAircraftTypeCertificateNoValue;
        private Label labelOperator;
        private Label labelOwner;
        private Label labelOperatorValue;
        private Label labelOwnerValue;
        private Label labelAWC;
        private Label labelAWCValue;
        private Label label1;
        private Label labelOther;
        private Label label2;
        private Label labelMaxTakeOffCrossWeight;
        private Label labelMaxTakeOffCrossWeightValue;
        private Label labelMaxTaxiWeight;
        private Label labelMaxTaxiWeightValue;
        private Label labelMaxZeroFuelWeight;
        private Label labelMaxZeroFuelWeightValue;
        private Label labelCockpitSeating;
        private Label labelCockpitSeatingValue;
        private Label labelGalleys;
        private Label labelGalleysValue;
        private Label labelMaxLandingWeight;
        private Label labelMaxLandingWeightValue;
        private Label labelBasicEmptyWeight;
        private Label labelBasicEmptyWeightValue;
        private Label labelBasicEmptyWeightCargoConfig;
        private Label labelBasicEmptyWeightCargoConfigValue;
        private Label labelOpertionalEmptyWeight;
        private Label labelFuelCapacity;
        private Label labelMaxCruiseAltitude;
        private Label labelMaxPayload;
        private Label labelCruiseFuelFlow;
        private Label labelCruise;
        private Label labelCargoCapacityContainer;
        private Label labelOpertionalEmptyWeightValue;
        private Label labelFuelCapacityValue;
        private Label labelMaxCruiseAltitudeValue;
        private Label labelMaxPayloadValue;
        private Label labelCruiseFuelFlowValue;
        private Label labelCruiseValue;
        private Label labelCargoCapacityContainerValue;
        private Label labelLavatory;
        private Label labelLavatoryValue;
        private Label labelOven;
        private Label labelOvenValue;
        private Label labelBoiler;
        private Label labelBoilerValue;
        private Label labelSeatingEconomy;
        private Label labelSeatingFirst;
        private Label labelSeatingBusiness;
        private Label labelSeatingEconomyValue;
        private Label labelSeatingFirstValue;
        private Label labelSeatingBusinessValue;
        private Label labelAirStairDoors;
        private Label labelAirStairDoorsValue;
    }
}
