using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.MaintananceProgram;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    partial class ProcedureSummary
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
            this.labelDirective = new System.Windows.Forms.Label();
            this.labelDirectiveValue = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDescriptionValue = new System.Windows.Forms.Label();
            this.labelEffectiveDate = new System.Windows.Forms.Label();
            this.labelEffectiveDateValue = new System.Windows.Forms.Label();
            this.labelApplicability = new System.Windows.Forms.Label();
            this.labelApplicabilityValue = new System.Windows.Forms.Label();
            this.labelRemarksLast = new System.Windows.Forms.Label();
            this.linkDetailInfoFirst = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.linkDirectiveStatus = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.labelCheckListValue = new System.Windows.Forms.Label();
            this.labelCheckList = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Compliance = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLastCompliance = new System.Windows.Forms.Label();
            this.labelAircraftTsnCsn = new System.Windows.Forms.Label();
            this.labelRemains = new System.Windows.Forms.Label();
            this.labelCompliance = new System.Windows.Forms.Label();
            this.labelNextCompliance = new System.Windows.Forms.Label();
            this.labelComponentTsnCsn = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDateNext = new System.Windows.Forms.Label();
            this.labelDateLast = new System.Windows.Forms.Label();
            this.labelComponentTsnCsnLast = new System.Windows.Forms.Label();
            this.labelAircraftTsnCsnLast = new System.Windows.Forms.Label();
            this.labelComponentTsnCsnNext = new System.Windows.Forms.Label();
            this.labelAircraftTsnCsnNext = new System.Windows.Forms.Label();
            this.labelRemainsValue = new System.Windows.Forms.Label();
            this.panel_Performance = new System.Windows.Forms.Panel();
            this.labelKit = new System.Windows.Forms.Label();
            this.labelNDT = new System.Windows.Forms.Label();
            this.labelKitValue = new System.Windows.Forms.Label();
            this.labelHiddenRemarksValue = new System.Windows.Forms.Label();
            this.labelNDTvalue = new System.Windows.Forms.Label();
            this.labelHiddenRemarks = new System.Windows.Forms.Label();
            this.labelManHoursValue = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelManHours = new System.Windows.Forms.Label();
            this.labelCostValue = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.labelRemarksValue = new System.Windows.Forms.Label();
            this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.labelRptInterval = new System.Windows.Forms.Label();
            this.labelRptIntervalValue = new System.Windows.Forms.Label();
            this.labelFirstPerformance = new System.Windows.Forms.Label();
            this.labelFirstPerformanceValue = new System.Windows.Forms.Label();
            this.labelRefDocs = new System.Windows.Forms.Label();
            this.labelRefDocsValue = new System.Windows.Forms.Label();
            this.flowLayoutPanel_Compliance.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Performance.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDirective
            // 
            this.labelDirective.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDirective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDirective.Location = new System.Drawing.Point(4, 0);
            this.labelDirective.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDirective.Name = "labelDirective";
            this.labelDirective.Size = new System.Drawing.Size(200, 37);
            this.labelDirective.TabIndex = 2;
            this.labelDirective.Text = "Title:";
            this.labelDirective.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDirectiveValue
            // 
            this.labelDirectiveValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDirectiveValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDirectiveValue.Location = new System.Drawing.Point(212, 0);
            this.labelDirectiveValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDirectiveValue.Name = "labelDirectiveValue";
            this.labelDirectiveValue.Size = new System.Drawing.Size(153, 37);
            this.labelDirectiveValue.TabIndex = 3;
            this.labelDirectiveValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDirectiveValue.TextChanged += new System.EventHandler(this.LabelDirectiveValueTextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(4, 222);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(200, 37);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescriptionValue
            // 
            this.labelDescriptionValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDescriptionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescriptionValue.Location = new System.Drawing.Point(212, 230);
            this.labelDescriptionValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescriptionValue.MaximumSize = new System.Drawing.Size(1325, 111);
            this.labelDescriptionValue.Name = "labelDescriptionValue";
            this.labelDescriptionValue.Size = new System.Drawing.Size(1325, 111);
            this.labelDescriptionValue.TabIndex = 6;
            this.labelDescriptionValue.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelEffectiveDate
            // 
            this.labelEffectiveDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEffectiveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectiveDate.Location = new System.Drawing.Point(4, 37);
            this.labelEffectiveDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEffectiveDate.Name = "labelEffectiveDate";
            this.labelEffectiveDate.Size = new System.Drawing.Size(200, 37);
            this.labelEffectiveDate.TabIndex = 7;
            this.labelEffectiveDate.Text = "Effective Date:";
            this.labelEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEffectiveDateValue
            // 
            this.labelEffectiveDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEffectiveDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectiveDateValue.Location = new System.Drawing.Point(212, 37);
            this.labelEffectiveDateValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEffectiveDateValue.Name = "labelEffectiveDateValue";
            this.labelEffectiveDateValue.Size = new System.Drawing.Size(240, 37);
            this.labelEffectiveDateValue.TabIndex = 8;
            this.labelEffectiveDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEffectiveDateValue.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelApplicability
            // 
            this.labelApplicability.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApplicability.Location = new System.Drawing.Point(4, 111);
            this.labelApplicability.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApplicability.Name = "labelApplicability";
            this.labelApplicability.Size = new System.Drawing.Size(200, 37);
            this.labelApplicability.TabIndex = 9;
            this.labelApplicability.Text = "Applicability:";
            this.labelApplicability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelApplicabilityValue
            // 
            this.labelApplicabilityValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelApplicabilityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApplicabilityValue.Location = new System.Drawing.Point(212, 111);
            this.labelApplicabilityValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApplicabilityValue.Name = "labelApplicabilityValue";
            this.labelApplicabilityValue.Size = new System.Drawing.Size(240, 37);
            this.labelApplicabilityValue.TabIndex = 10;
            this.labelApplicabilityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelApplicabilityValue.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelRemarksLast
            // 
            this.labelRemarksLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemarksLast.AutoSize = true;
            this.labelRemarksLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarksLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarksLast.Location = new System.Drawing.Point(1205, 252);
            this.labelRemarksLast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarksLast.MaximumSize = new System.Drawing.Size(227, 369);
            this.labelRemarksLast.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelRemarksLast.Name = "labelRemarksLast";
            this.labelRemarksLast.Size = new System.Drawing.Size(27, 25);
            this.labelRemarksLast.TabIndex = 20;
            this.labelRemarksLast.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // linkDetailInfoFirst
            // 
            this.linkDetailInfoFirst.Displayer = null;
            this.linkDetailInfoFirst.DisplayerText = null;
            this.linkDetailInfoFirst.Entity = null;
            this.linkDetailInfoFirst.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkDetailInfoFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.linkDetailInfoFirst.Location = new System.Drawing.Point(4, 0);
            this.linkDetailInfoFirst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkDetailInfoFirst.Name = "linkDetailInfoFirst";
            this.linkDetailInfoFirst.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkDetailInfoFirst.Size = new System.Drawing.Size(133, 37);
            this.linkDetailInfoFirst.TabIndex = 4;
            this.linkDetailInfoFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDetailInfoFirst.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.DetailReferenceDisplayerRequested);
            this.linkDetailInfoFirst.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // linkDirectiveStatus
            // 
            this.linkDirectiveStatus.AutoSize = true;
            this.linkDirectiveStatus.Displayer = null;
            this.linkDirectiveStatus.DisplayerText = null;
            this.linkDirectiveStatus.Entity = null;
            this.linkDirectiveStatus.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkDirectiveStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.linkDirectiveStatus.Location = new System.Drawing.Point(-4, 295);
            this.linkDirectiveStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkDirectiveStatus.MinimumSize = new System.Drawing.Size(27, 21);
            this.linkDirectiveStatus.Name = "linkDirectiveStatus";
            this.linkDirectiveStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkDirectiveStatus.Size = new System.Drawing.Size(27, 21);
            this.linkDirectiveStatus.TabIndex = 31;
            this.linkDirectiveStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDirectiveStatus.Visible = false;
            this.linkDirectiveStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDirectiveStatusDisplayerRequested);
            // 
            // labelCheckListValue
            // 
            this.labelCheckListValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCheckListValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCheckListValue.Location = new System.Drawing.Point(212, 74);
            this.labelCheckListValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckListValue.Name = "labelCheckListValue";
            this.labelCheckListValue.Size = new System.Drawing.Size(267, 37);
            this.labelCheckListValue.TabIndex = 115;
            this.labelCheckListValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCheckList
            // 
            this.labelCheckList.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCheckList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCheckList.Location = new System.Drawing.Point(4, 74);
            this.labelCheckList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCheckList.Name = "labelCheckList";
            this.labelCheckList.Size = new System.Drawing.Size(200, 37);
            this.labelCheckList.TabIndex = 114;
            this.labelCheckList.Text = "Check List:";
            this.labelCheckList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel_Compliance
            // 
            this.flowLayoutPanel_Compliance.AutoSize = true;
            this.flowLayoutPanel_Compliance.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel_Compliance.Controls.Add(this.panel_Performance);
            this.flowLayoutPanel_Compliance.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_Compliance.Location = new System.Drawing.Point(4, 389);
            this.flowLayoutPanel_Compliance.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel_Compliance.Name = "flowLayoutPanel_Compliance";
            this.flowLayoutPanel_Compliance.Size = new System.Drawing.Size(1475, 364);
            this.flowLayoutPanel_Compliance.TabIndex = 125;
            this.flowLayoutPanel_Compliance.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 493F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 529F));
            this.tableLayoutPanel1.Controls.Add(this.labelLastCompliance, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAircraftTsnCsn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelRemains, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCompliance, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelNextCompliance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelComponentTsnCsn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelDateNext, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelDateLast, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelComponentTsnCsnLast, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelAircraftTsnCsnLast, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelComponentTsnCsnNext, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAircraftTsnCsnNext, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelRemainsValue, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1467, 171);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // labelLastCompliance
            // 
            this.labelLastCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLastCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLastCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLastCompliance.Location = new System.Drawing.Point(7, 91);
            this.labelLastCompliance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelLastCompliance.Name = "labelLastCompliance";
            this.labelLastCompliance.Size = new System.Drawing.Size(227, 37);
            this.labelLastCompliance.TabIndex = 16;
            this.labelLastCompliance.Text = "Last Compliance";
            this.labelLastCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTsnCsn
            // 
            this.labelAircraftTsnCsn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftTsnCsn.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsn.Location = new System.Drawing.Point(1086, 6);
            this.labelAircraftTsnCsn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelAircraftTsnCsn.Name = "labelAircraftTsnCsn";
            this.labelAircraftTsnCsn.Size = new System.Drawing.Size(231, 37);
            this.labelAircraftTsnCsn.TabIndex = 13;
            this.labelAircraftTsnCsn.Text = "Aircraft TSN/CSN";
            this.labelAircraftTsnCsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAircraftTsnCsn.Visible = false;
            // 
            // labelRemains
            // 
            this.labelRemains.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemains.Location = new System.Drawing.Point(7, 133);
            this.labelRemains.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelRemains.Name = "labelRemains";
            this.labelRemains.Size = new System.Drawing.Size(227, 37);
            this.labelRemains.TabIndex = 26;
            this.labelRemains.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompliance
            // 
            this.labelCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompliance.Location = new System.Drawing.Point(7, 4);
            this.labelCompliance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompliance.Name = "labelCompliance";
            this.labelCompliance.Size = new System.Drawing.Size(227, 37);
            this.labelCompliance.TabIndex = 11;
            this.labelCompliance.Text = "Compliance";
            this.labelCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNextCompliance
            // 
            this.labelNextCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNextCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNextCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNextCompliance.Location = new System.Drawing.Point(7, 49);
            this.labelNextCompliance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelNextCompliance.Name = "labelNextCompliance";
            this.labelNextCompliance.Size = new System.Drawing.Size(227, 37);
            this.labelNextCompliance.TabIndex = 21;
            this.labelNextCompliance.Text = "Next Compliance";
            this.labelNextCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComponentTsnCsn
            // 
            this.labelComponentTsnCsn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelComponentTsnCsn.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsn.Location = new System.Drawing.Point(573, 4);
            this.labelComponentTsnCsn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponentTsnCsn.Name = "labelComponentTsnCsn";
            this.labelComponentTsnCsn.Size = new System.Drawing.Size(232, 37);
            this.labelComponentTsnCsn.TabIndex = 32;
            this.labelComponentTsnCsn.Text = "Component TSN/CSN";
            this.labelComponentTsnCsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelComponentTsnCsn.Visible = false;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDate.Location = new System.Drawing.Point(266, 4);
            this.labelDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(152, 37);
            this.labelDate.TabIndex = 12;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDateNext
            // 
            this.labelDateNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNext.AutoSize = true;
            this.labelDateNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateNext.Location = new System.Drawing.Point(328, 53);
            this.labelDateNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateNext.MaximumSize = new System.Drawing.Size(153, 369);
            this.labelDateNext.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelDateNext.Name = "labelDateNext";
            this.labelDateNext.Size = new System.Drawing.Size(27, 25);
            this.labelDateNext.TabIndex = 22;
            this.labelDateNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDateLast
            // 
            this.labelDateLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateLast.AutoSize = true;
            this.labelDateLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateLast.Location = new System.Drawing.Point(328, 97);
            this.labelDateLast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelDateLast.MaximumSize = new System.Drawing.Size(153, 1231);
            this.labelDateLast.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelDateLast.Name = "labelDateLast";
            this.labelDateLast.Size = new System.Drawing.Size(27, 25);
            this.labelDateLast.TabIndex = 17;
            this.labelDateLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComponentTsnCsnLast
            // 
            this.labelComponentTsnCsnLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelComponentTsnCsnLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsnLast.Location = new System.Drawing.Point(447, 91);
            this.labelComponentTsnCsnLast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelComponentTsnCsnLast.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelComponentTsnCsnLast.Name = "labelComponentTsnCsnLast";
            this.labelComponentTsnCsnLast.Size = new System.Drawing.Size(485, 37);
            this.labelComponentTsnCsnLast.TabIndex = 34;
            this.labelComponentTsnCsnLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelComponentTsnCsnLast.Visible = false;
            // 
            // labelAircraftTsnCsnLast
            // 
            this.labelAircraftTsnCsnLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAircraftTsnCsnLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsnLast.Location = new System.Drawing.Point(941, 87);
            this.labelAircraftTsnCsnLast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTsnCsnLast.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelAircraftTsnCsnLast.Name = "labelAircraftTsnCsnLast";
            this.labelAircraftTsnCsnLast.Size = new System.Drawing.Size(521, 41);
            this.labelAircraftTsnCsnLast.TabIndex = 18;
            this.labelAircraftTsnCsnLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAircraftTsnCsnLast.Visible = false;
            // 
            // labelComponentTsnCsnNext
            // 
            this.labelComponentTsnCsnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelComponentTsnCsnNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsnNext.Location = new System.Drawing.Point(447, 45);
            this.labelComponentTsnCsnNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComponentTsnCsnNext.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelComponentTsnCsnNext.Name = "labelComponentTsnCsnNext";
            this.labelComponentTsnCsnNext.Size = new System.Drawing.Size(485, 41);
            this.labelComponentTsnCsnNext.TabIndex = 116;
            this.labelComponentTsnCsnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelComponentTsnCsnNext.Visible = false;
            // 
            // labelAircraftTsnCsnNext
            // 
            this.labelAircraftTsnCsnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAircraftTsnCsnNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsnNext.Location = new System.Drawing.Point(941, 45);
            this.labelAircraftTsnCsnNext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAircraftTsnCsnNext.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelAircraftTsnCsnNext.Name = "labelAircraftTsnCsnNext";
            this.labelAircraftTsnCsnNext.Size = new System.Drawing.Size(521, 41);
            this.labelAircraftTsnCsnNext.TabIndex = 23;
            this.labelAircraftTsnCsnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelAircraftTsnCsnNext.Visible = false;
            // 
            // labelRemainsValue
            // 
            this.labelRemainsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRemainsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemainsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemainsValue.Location = new System.Drawing.Point(447, 133);
            this.labelRemainsValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelRemainsValue.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelRemainsValue.Name = "labelRemainsValue";
            this.labelRemainsValue.Size = new System.Drawing.Size(485, 37);
            this.labelRemainsValue.TabIndex = 27;
            this.labelRemainsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRemainsValue.Visible = false;
            // 
            // panel_Performance
            // 
            this.panel_Performance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel_Performance.Controls.Add(this.labelKit);
            this.panel_Performance.Controls.Add(this.labelNDT);
            this.panel_Performance.Controls.Add(this.labelKitValue);
            this.panel_Performance.Controls.Add(this.labelHiddenRemarksValue);
            this.panel_Performance.Controls.Add(this.labelNDTvalue);
            this.panel_Performance.Controls.Add(this.labelHiddenRemarks);
            this.panel_Performance.Controls.Add(this.labelManHoursValue);
            this.panel_Performance.Controls.Add(this.labelCost);
            this.panel_Performance.Controls.Add(this.labelManHours);
            this.panel_Performance.Controls.Add(this.labelCostValue);
            this.panel_Performance.Controls.Add(this.labelRemarks);
            this.panel_Performance.Controls.Add(this.labelRemarksValue);
            this.panel_Performance.Location = new System.Drawing.Point(4, 183);
            this.panel_Performance.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Performance.Name = "panel_Performance";
            this.panel_Performance.Size = new System.Drawing.Size(1437, 160);
            this.panel_Performance.TabIndex = 48;
            // 
            // labelKit
            // 
            this.labelKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKit.Location = new System.Drawing.Point(7, 15);
            this.labelKit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKit.Name = "labelKit";
            this.labelKit.Size = new System.Drawing.Size(133, 37);
            this.labelKit.TabIndex = 35;
            this.labelKit.Text = "Kit Requered";
            this.labelKit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNDT
            // 
            this.labelNDT.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNDT.Location = new System.Drawing.Point(7, 117);
            this.labelNDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNDT.Name = "labelNDT";
            this.labelNDT.Size = new System.Drawing.Size(133, 37);
            this.labelNDT.TabIndex = 36;
            this.labelNDT.Text = "NDT:";
            this.labelNDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNDT.Visible = false;
            // 
            // labelKitValue
            // 
            this.labelKitValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelKitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKitValue.Location = new System.Drawing.Point(148, 15);
            this.labelKitValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelKitValue.Name = "labelKitValue";
            this.labelKitValue.Size = new System.Drawing.Size(133, 37);
            this.labelKitValue.TabIndex = 37;
            this.labelKitValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHiddenRemarksValue
            // 
            this.labelHiddenRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHiddenRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelHiddenRemarksValue.Location = new System.Drawing.Point(1120, 23);
            this.labelHiddenRemarksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHiddenRemarksValue.Name = "labelHiddenRemarksValue";
            this.labelHiddenRemarksValue.Size = new System.Drawing.Size(293, 135);
            this.labelHiddenRemarksValue.TabIndex = 40;
            // 
            // labelNDTvalue
            // 
            this.labelNDTvalue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNDTvalue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNDTvalue.Location = new System.Drawing.Point(148, 117);
            this.labelNDTvalue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNDTvalue.Name = "labelNDTvalue";
            this.labelNDTvalue.Size = new System.Drawing.Size(133, 37);
            this.labelNDTvalue.TabIndex = 38;
            this.labelNDTvalue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelNDTvalue.Visible = false;
            // 
            // labelHiddenRemarks
            // 
            this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelHiddenRemarks.Location = new System.Drawing.Point(945, 15);
            this.labelHiddenRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHiddenRemarks.Name = "labelHiddenRemarks";
            this.labelHiddenRemarks.Size = new System.Drawing.Size(167, 37);
            this.labelHiddenRemarks.TabIndex = 39;
            this.labelHiddenRemarks.Text = "HiddenRemarks";
            this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManHoursValue
            // 
            this.labelManHoursValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManHoursValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManHoursValue.Location = new System.Drawing.Point(148, 80);
            this.labelManHoursValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManHoursValue.Name = "labelManHoursValue";
            this.labelManHoursValue.Size = new System.Drawing.Size(133, 37);
            this.labelManHoursValue.TabIndex = 44;
            this.labelManHoursValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCost
            // 
            this.labelCost.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCost.Location = new System.Drawing.Point(7, 52);
            this.labelCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(133, 28);
            this.labelCost.TabIndex = 41;
            this.labelCost.Text = "Cost";
            this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManHours
            // 
            this.labelManHours.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManHours.Location = new System.Drawing.Point(7, 80);
            this.labelManHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelManHours.Name = "labelManHours";
            this.labelManHours.Size = new System.Drawing.Size(133, 37);
            this.labelManHours.TabIndex = 43;
            this.labelManHours.Text = "Man Hours";
            this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCostValue
            // 
            this.labelCostValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCostValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCostValue.Location = new System.Drawing.Point(148, 52);
            this.labelCostValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCostValue.Name = "labelCostValue";
            this.labelCostValue.Size = new System.Drawing.Size(133, 28);
            this.labelCostValue.TabIndex = 42;
            this.labelCostValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(348, 15);
            this.labelRemarks.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(167, 37);
            this.labelRemarks.TabIndex = 15;
            this.labelRemarks.Text = "Remarks";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRemarksValue
            // 
            this.labelRemarksValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarksValue.Location = new System.Drawing.Point(539, 18);
            this.labelRemarksValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRemarksValue.MinimumSize = new System.Drawing.Size(27, 25);
            this.labelRemarksValue.Name = "labelRemarksValue";
            this.labelRemarksValue.Size = new System.Drawing.Size(287, 135);
            this.labelRemarksValue.TabIndex = 25;
            this.labelRemarksValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRemarksValue.Visible = false;
            // 
            // imageLinkLabelStatus
            // 
            this.imageLinkLabelStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.imageLinkLabelStatus.Enabled = false;
            this.imageLinkLabelStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
            this.imageLinkLabelStatus.ImageBackColor = System.Drawing.Color.Transparent;
            this.imageLinkLabelStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageLinkLabelStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.imageLinkLabelStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.imageLinkLabelStatus.Location = new System.Drawing.Point(8, 345);
            this.imageLinkLabelStatus.Margin = new System.Windows.Forms.Padding(5);
            this.imageLinkLabelStatus.Name = "imageLinkLabelStatus";
            this.imageLinkLabelStatus.Size = new System.Drawing.Size(333, 31);
            this.imageLinkLabelStatus.TabIndex = 129;
            this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // labelRptInterval
            // 
            this.labelRptInterval.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRptInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRptInterval.Location = new System.Drawing.Point(955, 338);
            this.labelRptInterval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRptInterval.Name = "labelRptInterval";
            this.labelRptInterval.Size = new System.Drawing.Size(167, 37);
            this.labelRptInterval.TabIndex = 128;
            this.labelRptInterval.Text = "Repeat interval:";
            this.labelRptInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRptIntervalValue
            // 
            this.labelRptIntervalValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRptIntervalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRptIntervalValue.Location = new System.Drawing.Point(1129, 330);
            this.labelRptIntervalValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRptIntervalValue.Name = "labelRptIntervalValue";
            this.labelRptIntervalValue.Size = new System.Drawing.Size(333, 55);
            this.labelRptIntervalValue.TabIndex = 130;
            this.labelRptIntervalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstPerformance
            // 
            this.labelFirstPerformance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFirstPerformance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFirstPerformance.Location = new System.Drawing.Point(353, 338);
            this.labelFirstPerformance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstPerformance.Name = "labelFirstPerformance";
            this.labelFirstPerformance.Size = new System.Drawing.Size(187, 37);
            this.labelFirstPerformance.TabIndex = 126;
            this.labelFirstPerformance.Text = "First Performance:";
            this.labelFirstPerformance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstPerformanceValue
            // 
            this.labelFirstPerformanceValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFirstPerformanceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFirstPerformanceValue.Location = new System.Drawing.Point(548, 330);
            this.labelFirstPerformanceValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFirstPerformanceValue.Name = "labelFirstPerformanceValue";
            this.labelFirstPerformanceValue.Size = new System.Drawing.Size(393, 55);
            this.labelFirstPerformanceValue.TabIndex = 127;
            this.labelFirstPerformanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRefDocs
            // 
            this.labelRefDocs.AutoSize = true;
            this.labelRefDocs.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRefDocs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRefDocs.Location = new System.Drawing.Point(4, 155);
            this.labelRefDocs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRefDocs.Name = "labelRefDocs";
            this.labelRefDocs.Size = new System.Drawing.Size(126, 23);
            this.labelRefDocs.TabIndex = 131;
            this.labelRefDocs.Text = "Ref. Docs.:";
            this.labelRefDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRefDocsValue
            // 
            this.labelRefDocsValue.AutoEllipsis = true;
            this.labelRefDocsValue.AutoSize = true;
            this.labelRefDocsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRefDocsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRefDocsValue.Location = new System.Drawing.Point(212, 159);
            this.labelRefDocsValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRefDocsValue.MinimumSize = new System.Drawing.Size(133, 12);
            this.labelRefDocsValue.Name = "labelRefDocsValue";
            this.labelRefDocsValue.Size = new System.Drawing.Size(133, 18);
            this.labelRefDocsValue.TabIndex = 132;
            this.labelRefDocsValue.Text = "Ref Docs Value";
            this.labelRefDocsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProcedureSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.labelRefDocs);
            this.Controls.Add(this.labelRefDocsValue);
            this.Controls.Add(this.flowLayoutPanel_Compliance);
            this.Controls.Add(this.imageLinkLabelStatus);
            this.Controls.Add(this.labelRptInterval);
            this.Controls.Add(this.labelRptIntervalValue);
            this.Controls.Add(this.labelFirstPerformance);
            this.Controls.Add(this.labelFirstPerformanceValue);
            this.Controls.Add(this.labelCheckListValue);
            this.Controls.Add(this.labelCheckList);
            this.Controls.Add(this.labelDirective);
            this.Controls.Add(this.labelRemarksLast);
            this.Controls.Add(this.labelDirectiveValue);
            this.Controls.Add(this.linkDetailInfoFirst);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDescriptionValue);
            this.Controls.Add(this.labelEffectiveDate);
            this.Controls.Add(this.labelEffectiveDateValue);
            this.Controls.Add(this.labelApplicability);
            this.Controls.Add(this.labelApplicabilityValue);
            this.Controls.Add(this.linkDirectiveStatus);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1549, 308);
            this.Name = "ProcedureSummary";
            this.Size = new System.Drawing.Size(1549, 757);
            this.flowLayoutPanel_Compliance.ResumeLayout(false);
            this.flowLayoutPanel_Compliance.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_Performance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelDirective;
        private Label labelDirectiveValue;
        private Label labelDescription;
        private Label labelDescriptionValue;
        private Label labelEffectiveDate;
        private Label labelEffectiveDateValue;
        private Label labelApplicability;
        private Label labelApplicabilityValue;
        private Label labelRemarksLast;
        private ReferenceLinkLabel linkDetailInfoFirst;
        private ReferenceLinkLabel linkDirectiveStatus;
        private Label labelCheckListValue;
        private Label labelCheckList;
        private FlowLayoutPanel flowLayoutPanel_Compliance;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelLastCompliance;
        private Label labelAircraftTsnCsn;
        private Label labelRemains;
        private Label labelCompliance;
        private Label labelNextCompliance;
        private Label labelComponentTsnCsn;
        private Label labelDate;
        private Label labelDateNext;
        private Label labelDateLast;
        private Label labelComponentTsnCsnLast;
        private Label labelAircraftTsnCsnLast;
        private Label labelComponentTsnCsnNext;
        private Label labelAircraftTsnCsnNext;
        private Label labelRemainsValue;
        private Panel panel_Performance;
        private Label labelKit;
        private Label labelNDT;
        private Label labelKitValue;
        private Label labelHiddenRemarksValue;
        private Label labelNDTvalue;
        private Label labelHiddenRemarks;
        private Label labelManHoursValue;
        private Label labelCost;
        private Label labelManHours;
        private Label labelCostValue;
        private Label labelRemarks;
        private Label labelRemarksValue;
        private AvControls.StatusImageLink.StatusImageLinkLabel imageLinkLabelStatus;
        private Label labelRptInterval;
        private Label labelRptIntervalValue;
        private Label labelFirstPerformance;
        private Label labelFirstPerformanceValue;
        private Label labelRefDocs;
        private Label labelRefDocsValue;

    }
}
