using System.ComponentModel;
using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CAAEducation
{
    partial class EducationsComplianceControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            NextCourse = new ColumnHeader();
            NextLimitDate = new ColumnHeader();
            columnRemarks = new ColumnHeader();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Need new compliance:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Last compliance", System.Windows.Forms.HorizontalAlignment.Left);
            this.listViewCompliance = new System.Windows.Forms.ListView();
            this.NextCourse = new System.Windows.Forms.ColumnHeader();
            this.NextLimitDate = new System.Windows.Forms.ColumnHeader();
            this.columnRemarks = new System.Windows.Forms.ColumnHeader();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.NextCourse, this.NextLimitDate, this.columnRemarks });
            this.listViewCompliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewCompliance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listViewCompliance.FullRowSelect = true;
            listViewGroup1.Header = "Need new compliance:";
            listViewGroup1.Name = "GroupNewCompliance";
            listViewGroup2.Header = "Last compliance";
            listViewGroup2.Name = "ListViewGroupLast";
            this.listViewCompliance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2 });
            this.listViewCompliance.Location = new System.Drawing.Point(0, 0);
            this.listViewCompliance.Name = "listViewCompliance";
            this.listViewCompliance.ShowItemToolTips = true;
            this.listViewCompliance.Size = new System.Drawing.Size(951, 236);
            this.listViewCompliance.TabIndex = 0;
            this.listViewCompliance.UseCompatibleStateImageBehavior = false;
            this.listViewCompliance.View = System.Windows.Forms.View.Details;
            this.listViewCompliance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewComplainceMouseDoubleClick);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.listViewCompliance);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(951, 236);
            this.panelContainer.TabIndex = 1;
            
            // 
            // NextCourse
            // 
            this.NextCourse.Text = "Courses";
            this.NextCourse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextCourse.Width = 200;
            // 
            // columnWorkType
            // 
            this.NextLimitDate.Text = "Date";
            this.NextLimitDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextLimitDate.Width = 200;
            // 
            // columnWorkType
            // 
            this.columnRemarks.Text = "Remark";
            this.columnRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnRemarks.Width = 200;
            
            // 
            // EducationsComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Name = "EducationsComplianceControl";
            this.Size = new System.Drawing.Size(951, 236);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        public System.Windows.Forms.ListView listViewCompliance;
        public System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ColumnHeader NextCourse;
        private System.Windows.Forms.ColumnHeader NextLimitDate;
        private System.Windows.Forms.ColumnHeader columnRemarks;

        #endregion
    }
}