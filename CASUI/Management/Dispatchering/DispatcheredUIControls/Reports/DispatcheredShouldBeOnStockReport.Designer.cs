using System;
using System.Collections.Generic;
using System.Text;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    public partial class DispatcheredShouldBeOnStockReport
    {
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;

        private void InitializeComponent()
        {
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.DisplayGroupTree = false;
            this.crystalReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer2.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.SelectionFormula = "";
            this.crystalReportViewer2.Size = new System.Drawing.Size(758, 631);
            this.crystalReportViewer2.TabIndex = 0;
            this.crystalReportViewer2.ViewTimeSelectionFormula = "";
            // 
            // DispatcheredStoreReport
            // 
            this.Controls.Add(this.crystalReportViewer2);
            this.Name = "DispatcheredShouldBeOnStockReport";
            this.Size = new System.Drawing.Size(758, 631);
            this.ResumeLayout(false);

        }
    }
}
