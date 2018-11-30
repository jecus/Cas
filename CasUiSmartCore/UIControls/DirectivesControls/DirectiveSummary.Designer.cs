using System;
using System.Drawing;
using System.Windows.Forms;
using AvControls.StatusImageLink;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DirectiveSummary
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
            this.labelATAChapterValue = new System.Windows.Forms.Label();
            this.labelATAChapter = new System.Windows.Forms.Label();
            this.labelSBValue = new System.Windows.Forms.Label();
            this.labelSB = new System.Windows.Forms.Label();
            this.linkDetailInfoFirst = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.linkDirectiveStatus = new CAS.UI.Management.Dispatchering.ReferenceLinkLabel();
            this.labelEOValue = new System.Windows.Forms.Label();
            this.labelEO = new System.Windows.Forms.Label();
            this.labelRptIntervalValue = new System.Windows.Forms.Label();
            this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
            this.labelRptInterval = new System.Windows.Forms.Label();
            this.labelFirstPerformance = new System.Windows.Forms.Label();
            this.labelFirstPerformanceValue = new System.Windows.Forms.Label();
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
            this.flowLayoutPanel_Compliance.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Performance.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDirective
            // 
            this.labelDirective.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDirective.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDirective.Location = new System.Drawing.Point(3, 0);
            this.labelDirective.Name = "labelDirective";
            this.labelDirective.Size = new System.Drawing.Size(150, 30);
            this.labelDirective.TabIndex = 2;
            this.labelDirective.Text = "Directive:";
            this.labelDirective.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDirectiveValue
            // 
            this.labelDirectiveValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDirectiveValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDirectiveValue.Location = new System.Drawing.Point(159, 0);
            this.labelDirectiveValue.Name = "labelDirectiveValue";
            this.labelDirectiveValue.Size = new System.Drawing.Size(115, 30);
            this.labelDirectiveValue.TabIndex = 3;
            this.labelDirectiveValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDirectiveValue.TextChanged += new System.EventHandler(this.LabelDirectiveValueTextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(3, 180);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(150, 30);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescriptionValue
            // 
            this.labelDescriptionValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDescriptionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescriptionValue.Location = new System.Drawing.Point(159, 187);
            this.labelDescriptionValue.MaximumSize = new System.Drawing.Size(994, 90);
            this.labelDescriptionValue.Name = "labelDescriptionValue";
            this.labelDescriptionValue.Size = new System.Drawing.Size(994, 90);
            this.labelDescriptionValue.TabIndex = 6;
            this.labelDescriptionValue.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelEffectiveDate
            // 
            this.labelEffectiveDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEffectiveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectiveDate.Location = new System.Drawing.Point(3, 30);
            this.labelEffectiveDate.Name = "labelEffectiveDate";
            this.labelEffectiveDate.Size = new System.Drawing.Size(150, 30);
            this.labelEffectiveDate.TabIndex = 7;
            this.labelEffectiveDate.Text = "Effective Date:";
            this.labelEffectiveDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEffectiveDateValue
            // 
            this.labelEffectiveDateValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEffectiveDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEffectiveDateValue.Location = new System.Drawing.Point(159, 30);
            this.labelEffectiveDateValue.Name = "labelEffectiveDateValue";
            this.labelEffectiveDateValue.Size = new System.Drawing.Size(180, 30);
            this.labelEffectiveDateValue.TabIndex = 8;
            this.labelEffectiveDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEffectiveDateValue.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelApplicability
            // 
            this.labelApplicability.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelApplicability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApplicability.Location = new System.Drawing.Point(3, 150);
            this.labelApplicability.Name = "labelApplicability";
            this.labelApplicability.Size = new System.Drawing.Size(150, 30);
            this.labelApplicability.TabIndex = 9;
            this.labelApplicability.Text = "Applicability:";
            this.labelApplicability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelApplicabilityValue
            // 
            this.labelApplicabilityValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelApplicabilityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelApplicabilityValue.Location = new System.Drawing.Point(159, 150);
            this.labelApplicabilityValue.Name = "labelApplicabilityValue";
            this.labelApplicabilityValue.Size = new System.Drawing.Size(180, 30);
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
            this.labelRemarksLast.Location = new System.Drawing.Point(904, 205);
            this.labelRemarksLast.MaximumSize = new System.Drawing.Size(170, 300);
            this.labelRemarksLast.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelRemarksLast.Name = "labelRemarksLast";
            this.labelRemarksLast.Size = new System.Drawing.Size(20, 20);
            this.labelRemarksLast.TabIndex = 20;
            this.labelRemarksLast.TextChanged += new System.EventHandler(this.ControlTextChanged);
            // 
            // labelATAChapterValue
            // 
            this.labelATAChapterValue.AutoSize = true;
            this.labelATAChapterValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelATAChapterValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelATAChapterValue.Location = new System.Drawing.Point(159, 120);
            this.labelATAChapterValue.MinimumSize = new System.Drawing.Size(20, 30);
            this.labelATAChapterValue.Name = "labelATAChapterValue";
            this.labelATAChapterValue.Size = new System.Drawing.Size(20, 30);
            this.labelATAChapterValue.TabIndex = 65;
            this.labelATAChapterValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelATAChapter
            // 
            this.labelATAChapter.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelATAChapter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelATAChapter.Location = new System.Drawing.Point(3, 120);
            this.labelATAChapter.Name = "labelATAChapter";
            this.labelATAChapter.Size = new System.Drawing.Size(150, 30);
            this.labelATAChapter.TabIndex = 64;
            this.labelATAChapter.Text = "ATA Chapter:";
            this.labelATAChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSBValue
            // 
            this.labelSBValue.AutoSize = true;
            this.labelSBValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSBValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSBValue.Location = new System.Drawing.Point(159, 60);
            this.labelSBValue.MinimumSize = new System.Drawing.Size(20, 30);
            this.labelSBValue.Name = "labelSBValue";
            this.labelSBValue.Size = new System.Drawing.Size(20, 30);
            this.labelSBValue.TabIndex = 112;
            this.labelSBValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSB
            // 
            this.labelSB.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSB.Location = new System.Drawing.Point(3, 60);
            this.labelSB.Name = "labelSB";
            this.labelSB.Size = new System.Drawing.Size(150, 30);
            this.labelSB.TabIndex = 111;
            this.labelSB.Text = "Serv. Bulletin:";
            this.labelSB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkDetailInfoFirst
            // 
            this.linkDetailInfoFirst.Displayer = null;
            this.linkDetailInfoFirst.DisplayerText = null;
            this.linkDetailInfoFirst.Entity = null;
            this.linkDetailInfoFirst.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.linkDetailInfoFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.linkDetailInfoFirst.Location = new System.Drawing.Point(3, 0);
            this.linkDetailInfoFirst.Name = "linkDetailInfoFirst";
            this.linkDetailInfoFirst.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkDetailInfoFirst.Size = new System.Drawing.Size(100, 30);
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
            this.linkDirectiveStatus.Location = new System.Drawing.Point(-3, 240);
            this.linkDirectiveStatus.MinimumSize = new System.Drawing.Size(20, 17);
            this.linkDirectiveStatus.Name = "linkDirectiveStatus";
            this.linkDirectiveStatus.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.linkDirectiveStatus.Size = new System.Drawing.Size(20, 17);
            this.linkDirectiveStatus.TabIndex = 31;
            this.linkDirectiveStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkDirectiveStatus.Visible = false;
            this.linkDirectiveStatus.DisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.LinkDirectiveStatusDisplayerRequested);
            // 
            // labelEOValue
            // 
            this.labelEOValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEOValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEOValue.Location = new System.Drawing.Point(159, 90);
            this.labelEOValue.Name = "labelEOValue";
            this.labelEOValue.Size = new System.Drawing.Size(200, 30);
            this.labelEOValue.TabIndex = 115;
            this.labelEOValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelEO
            // 
            this.labelEO.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelEO.Location = new System.Drawing.Point(3, 90);
            this.labelEO.Name = "labelEO";
            this.labelEO.Size = new System.Drawing.Size(150, 30);
            this.labelEO.TabIndex = 114;
            this.labelEO.Text = "Enginrng. Order:";
            this.labelEO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRptIntervalValue
            // 
            this.labelRptIntervalValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRptIntervalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRptIntervalValue.Location = new System.Drawing.Point(847, 268);
            this.labelRptIntervalValue.Name = "labelRptIntervalValue";
            this.labelRptIntervalValue.Size = new System.Drawing.Size(250, 45);
            this.labelRptIntervalValue.TabIndex = 129;
            this.labelRptIntervalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.imageLinkLabelStatus.Location = new System.Drawing.Point(6, 280);
            this.imageLinkLabelStatus.Name = "imageLinkLabelStatus";
            this.imageLinkLabelStatus.Size = new System.Drawing.Size(250, 25);
            this.imageLinkLabelStatus.Status = AvControls.Statuses.NotActive;
            this.imageLinkLabelStatus.TabIndex = 128;
            this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // labelRptInterval
            // 
            this.labelRptInterval.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRptInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRptInterval.Location = new System.Drawing.Point(716, 275);
            this.labelRptInterval.Name = "labelRptInterval";
            this.labelRptInterval.Size = new System.Drawing.Size(125, 30);
            this.labelRptInterval.TabIndex = 127;
            this.labelRptInterval.Text = "Repeat interval:";
            this.labelRptInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstPerformance
            // 
            this.labelFirstPerformance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFirstPerformance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFirstPerformance.Location = new System.Drawing.Point(265, 275);
            this.labelFirstPerformance.Name = "labelFirstPerformance";
            this.labelFirstPerformance.Size = new System.Drawing.Size(140, 30);
            this.labelFirstPerformance.TabIndex = 125;
            this.labelFirstPerformance.Text = "First Performance:";
            this.labelFirstPerformance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstPerformanceValue
            // 
            this.labelFirstPerformanceValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelFirstPerformanceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFirstPerformanceValue.Location = new System.Drawing.Point(411, 268);
            this.labelFirstPerformanceValue.Name = "labelFirstPerformanceValue";
            this.labelFirstPerformanceValue.Size = new System.Drawing.Size(295, 45);
            this.labelFirstPerformanceValue.TabIndex = 126;
            this.labelFirstPerformanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel_Compliance
            // 
            this.flowLayoutPanel_Compliance.AutoSize = true;
            this.flowLayoutPanel_Compliance.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel_Compliance.Controls.Add(this.panel_Performance);
            this.flowLayoutPanel_Compliance.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_Compliance.Location = new System.Drawing.Point(6, 316);
            this.flowLayoutPanel_Compliance.Name = "flowLayoutPanel_Compliance";
            this.flowLayoutPanel_Compliance.Size = new System.Drawing.Size(1102, 296);
            this.flowLayoutPanel_Compliance.TabIndex = 130;
            this.flowLayoutPanel_Compliance.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 370F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 391F));
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 139);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // labelLastCompliance
            // 
            this.labelLastCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLastCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLastCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLastCompliance.Location = new System.Drawing.Point(6, 74);
            this.labelLastCompliance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelLastCompliance.Name = "labelLastCompliance";
            this.labelLastCompliance.Size = new System.Drawing.Size(170, 30);
            this.labelLastCompliance.TabIndex = 16;
            this.labelLastCompliance.Text = "Last Compliance";
            this.labelLastCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTsnCsn
            // 
            this.labelAircraftTsnCsn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAircraftTsnCsn.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsn.Location = new System.Drawing.Point(813, 5);
            this.labelAircraftTsnCsn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelAircraftTsnCsn.Name = "labelAircraftTsnCsn";
            this.labelAircraftTsnCsn.Size = new System.Drawing.Size(173, 30);
            this.labelAircraftTsnCsn.TabIndex = 13;
            this.labelAircraftTsnCsn.Text = "Aircraft TSN/CSN";
            this.labelAircraftTsnCsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRemains
            // 
            this.labelRemains.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemains.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemains.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemains.Location = new System.Drawing.Point(6, 108);
            this.labelRemains.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelRemains.Name = "labelRemains";
            this.labelRemains.Size = new System.Drawing.Size(170, 30);
            this.labelRemains.TabIndex = 26;
            this.labelRemains.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompliance
            // 
            this.labelCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCompliance.Location = new System.Drawing.Point(6, 3);
            this.labelCompliance.Name = "labelCompliance";
            this.labelCompliance.Size = new System.Drawing.Size(170, 30);
            this.labelCompliance.TabIndex = 11;
            this.labelCompliance.Text = "Compliance";
            this.labelCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNextCompliance
            // 
            this.labelNextCompliance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNextCompliance.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNextCompliance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNextCompliance.Location = new System.Drawing.Point(6, 40);
            this.labelNextCompliance.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelNextCompliance.Name = "labelNextCompliance";
            this.labelNextCompliance.Size = new System.Drawing.Size(170, 30);
            this.labelNextCompliance.TabIndex = 21;
            this.labelNextCompliance.Text = "Next Compliance";
            this.labelNextCompliance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComponentTsnCsn
            // 
            this.labelComponentTsnCsn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelComponentTsnCsn.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsn.Location = new System.Drawing.Point(431, 3);
            this.labelComponentTsnCsn.Name = "labelComponentTsnCsn";
            this.labelComponentTsnCsn.Size = new System.Drawing.Size(174, 30);
            this.labelComponentTsnCsn.TabIndex = 32;
            this.labelComponentTsnCsn.Text = "Component TSN/CSN";
            this.labelComponentTsnCsn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDate.Location = new System.Drawing.Point(200, 3);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(114, 30);
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
            this.labelDateNext.Location = new System.Drawing.Point(247, 43);
            this.labelDateNext.MaximumSize = new System.Drawing.Size(115, 300);
            this.labelDateNext.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelDateNext.Name = "labelDateNext";
            this.labelDateNext.Size = new System.Drawing.Size(20, 20);
            this.labelDateNext.TabIndex = 22;
            this.labelDateNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDateLast
            // 
            this.labelDateLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateLast.AutoSize = true;
            this.labelDateLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateLast.Location = new System.Drawing.Point(247, 79);
            this.labelDateLast.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelDateLast.MaximumSize = new System.Drawing.Size(115, 1000);
            this.labelDateLast.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelDateLast.Name = "labelDateLast";
            this.labelDateLast.Size = new System.Drawing.Size(20, 20);
            this.labelDateLast.TabIndex = 17;
            this.labelDateLast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelComponentTsnCsnLast
            // 
            this.labelComponentTsnCsnLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelComponentTsnCsnLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsnLast.Location = new System.Drawing.Point(336, 74);
            this.labelComponentTsnCsnLast.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelComponentTsnCsnLast.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelComponentTsnCsnLast.Name = "labelComponentTsnCsnLast";
            this.labelComponentTsnCsnLast.Size = new System.Drawing.Size(364, 30);
            this.labelComponentTsnCsnLast.TabIndex = 34;
            this.labelComponentTsnCsnLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAircraftTsnCsnLast
            // 
            this.labelAircraftTsnCsnLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAircraftTsnCsnLast.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsnLast.Location = new System.Drawing.Point(707, 71);
            this.labelAircraftTsnCsnLast.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelAircraftTsnCsnLast.Name = "labelAircraftTsnCsnLast";
            this.labelAircraftTsnCsnLast.Size = new System.Drawing.Size(385, 33);
            this.labelAircraftTsnCsnLast.TabIndex = 18;
            this.labelAircraftTsnCsnLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelComponentTsnCsnNext
            // 
            this.labelComponentTsnCsnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelComponentTsnCsnNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelComponentTsnCsnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelComponentTsnCsnNext.Location = new System.Drawing.Point(336, 37);
            this.labelComponentTsnCsnNext.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelComponentTsnCsnNext.Name = "labelComponentTsnCsnNext";
            this.labelComponentTsnCsnNext.Size = new System.Drawing.Size(364, 33);
            this.labelComponentTsnCsnNext.TabIndex = 116;
            this.labelComponentTsnCsnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAircraftTsnCsnNext
            // 
            this.labelAircraftTsnCsnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAircraftTsnCsnNext.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTsnCsnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTsnCsnNext.Location = new System.Drawing.Point(707, 37);
            this.labelAircraftTsnCsnNext.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelAircraftTsnCsnNext.Name = "labelAircraftTsnCsnNext";
            this.labelAircraftTsnCsnNext.Size = new System.Drawing.Size(385, 33);
            this.labelAircraftTsnCsnNext.TabIndex = 23;
            this.labelAircraftTsnCsnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRemainsValue
            // 
            this.labelRemainsValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRemainsValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemainsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemainsValue.Location = new System.Drawing.Point(336, 108);
            this.labelRemainsValue.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelRemainsValue.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelRemainsValue.Name = "labelRemainsValue";
            this.labelRemainsValue.Size = new System.Drawing.Size(364, 30);
            this.labelRemainsValue.TabIndex = 27;
            this.labelRemainsValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel_Performance.Location = new System.Drawing.Point(3, 148);
            this.panel_Performance.Name = "panel_Performance";
            this.panel_Performance.Size = new System.Drawing.Size(1078, 130);
            this.panel_Performance.TabIndex = 48;
            // 
            // labelKit
            // 
            this.labelKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelKit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKit.Location = new System.Drawing.Point(5, 12);
            this.labelKit.Name = "labelKit";
            this.labelKit.Size = new System.Drawing.Size(100, 30);
            this.labelKit.TabIndex = 35;
            this.labelKit.Text = "Kit Requered";
            this.labelKit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNDT
            // 
            this.labelNDT.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNDT.Location = new System.Drawing.Point(5, 95);
            this.labelNDT.Name = "labelNDT";
            this.labelNDT.Size = new System.Drawing.Size(100, 30);
            this.labelNDT.TabIndex = 36;
            this.labelNDT.Text = "NDT:";
            this.labelNDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelKitValue
            // 
            this.labelKitValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelKitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKitValue.Location = new System.Drawing.Point(111, 12);
            this.labelKitValue.Name = "labelKitValue";
            this.labelKitValue.Size = new System.Drawing.Size(100, 30);
            this.labelKitValue.TabIndex = 37;
            this.labelKitValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHiddenRemarksValue
            // 
            this.labelHiddenRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHiddenRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelHiddenRemarksValue.Location = new System.Drawing.Point(840, 19);
            this.labelHiddenRemarksValue.Name = "labelHiddenRemarksValue";
            this.labelHiddenRemarksValue.Size = new System.Drawing.Size(220, 110);
            this.labelHiddenRemarksValue.TabIndex = 40;
            // 
            // labelNDTvalue
            // 
            this.labelNDTvalue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelNDTvalue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelNDTvalue.Location = new System.Drawing.Point(111, 95);
            this.labelNDTvalue.Name = "labelNDTvalue";
            this.labelNDTvalue.Size = new System.Drawing.Size(100, 30);
            this.labelNDTvalue.TabIndex = 38;
            this.labelNDTvalue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHiddenRemarks
            // 
            this.labelHiddenRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHiddenRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelHiddenRemarks.Location = new System.Drawing.Point(709, 12);
            this.labelHiddenRemarks.Name = "labelHiddenRemarks";
            this.labelHiddenRemarks.Size = new System.Drawing.Size(125, 30);
            this.labelHiddenRemarks.TabIndex = 39;
            this.labelHiddenRemarks.Text = "HiddenRemarks";
            this.labelHiddenRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManHoursValue
            // 
            this.labelManHoursValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManHoursValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManHoursValue.Location = new System.Drawing.Point(111, 65);
            this.labelManHoursValue.Name = "labelManHoursValue";
            this.labelManHoursValue.Size = new System.Drawing.Size(100, 30);
            this.labelManHoursValue.TabIndex = 44;
            this.labelManHoursValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCost
            // 
            this.labelCost.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCost.Location = new System.Drawing.Point(5, 42);
            this.labelCost.Name = "labelCost";
            this.labelCost.Size = new System.Drawing.Size(100, 23);
            this.labelCost.TabIndex = 41;
            this.labelCost.Text = "Cost";
            this.labelCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelManHours
            // 
            this.labelManHours.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelManHours.Location = new System.Drawing.Point(5, 65);
            this.labelManHours.Name = "labelManHours";
            this.labelManHours.Size = new System.Drawing.Size(100, 30);
            this.labelManHours.TabIndex = 43;
            this.labelManHours.Text = "Man Hours";
            this.labelManHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCostValue
            // 
            this.labelCostValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCostValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCostValue.Location = new System.Drawing.Point(111, 42);
            this.labelCostValue.Name = "labelCostValue";
            this.labelCostValue.Size = new System.Drawing.Size(100, 23);
            this.labelCostValue.TabIndex = 42;
            this.labelCostValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRemarks
            // 
            this.labelRemarks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(261, 12);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(125, 30);
            this.labelRemarks.TabIndex = 15;
            this.labelRemarks.Text = "Remarks";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRemarksValue
            // 
            this.labelRemarksValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemarksValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelRemarksValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarksValue.Location = new System.Drawing.Point(404, 15);
            this.labelRemarksValue.MinimumSize = new System.Drawing.Size(20, 20);
            this.labelRemarksValue.Name = "labelRemarksValue";
            this.labelRemarksValue.Size = new System.Drawing.Size(215, 110);
            this.labelRemarksValue.TabIndex = 25;
            this.labelRemarksValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRemarksValue.Visible = false;
            // 
            // DirectiveSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.flowLayoutPanel_Compliance);
            this.Controls.Add(this.labelRptIntervalValue);
            this.Controls.Add(this.imageLinkLabelStatus);
            this.Controls.Add(this.labelRptInterval);
            this.Controls.Add(this.labelFirstPerformance);
            this.Controls.Add(this.labelFirstPerformanceValue);
            this.Controls.Add(this.labelEOValue);
            this.Controls.Add(this.labelEO);
            this.Controls.Add(this.labelSBValue);
            this.Controls.Add(this.labelSB);
            this.Controls.Add(this.labelATAChapterValue);
            this.Controls.Add(this.labelATAChapter);
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
            this.MinimumSize = new System.Drawing.Size(1162, 250);
            this.Name = "DirectiveSummary";
            this.Size = new System.Drawing.Size(1162, 615);
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
        private Label labelATAChapterValue;
        private Label labelATAChapter;
        private Label labelSBValue;
        private Label labelSB;
        private Label labelEOValue;
        private Label labelEO;
        private Label labelRptIntervalValue;
        private StatusImageLinkLabel imageLinkLabelStatus;
        private Label labelRptInterval;
        private Label labelFirstPerformance;
        private Label labelFirstPerformanceValue;
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

    }
}
