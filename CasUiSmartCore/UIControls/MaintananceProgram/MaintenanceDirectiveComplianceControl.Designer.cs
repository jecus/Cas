using System.Windows.Forms;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceDirectiveComplianceControl
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
            if (disposing)
            {
                if(_toolStripMenuItemsWorkPackages != null)
                {
                    foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                    {
                        item.Click -= AddToWorkPackageItemClick;
                        item.Tag = null;
                    }  
  
                    if(!_toolStripMenuItemsWorkPackages.IsDisposed)
                        _toolStripMenuItemsWorkPackages.Dispose();
                }

                if(_openPubWorkPackages != null)
                    _openPubWorkPackages.Clear();
                _openPubWorkPackages = null;
            }
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Need new compliance:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Last compliance", System.Windows.Forms.HorizontalAlignment.Left);
            this.NextEstimated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextEstimatedData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextLimitData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWorkType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWorkType,
            this.NextEstimated,
            this.NextEstimatedData,
            this.NextLimit,
            this.NextLimitData,
            this.columnRemarks});
            this.listViewCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewCompliance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listViewCompliance.GridLines = false;
            listViewGroup1.Header = "Need new compliance:";
            listViewGroup1.Name = "GroupNewCompliance";
            listViewGroup2.Header = "Last compliance";
            listViewGroup2.Name = "ListViewGroupLast";
            this.listViewCompliance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewCompliance.ShowItemToolTips = true;
            this.listViewCompliance.Size = new System.Drawing.Size(845, 238);
            this.listViewCompliance.Click += new System.EventHandler(this.ListViewComplainceClick);
            this.listViewCompliance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewComplainceMouseDoubleClick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(3, 244);
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(118, 244);
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(237, 244);
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // panelContainer
            // 
            this.panelContainer.Size = new System.Drawing.Size(845, 301);
            // 
            // NextEstimated
            // 
            this.NextEstimated.Text = "Next(E)";
            this.NextEstimated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextEstimated.Width = 80;
            // 
            // NextEstimatedData
            // 
            this.NextEstimatedData.Text = "Next Estimated Data";
            this.NextEstimatedData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextEstimatedData.Width = 120;
            // 
            // NextLimit
            // 
            this.NextLimit.Text = "Next(L)";
            this.NextLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextLimit.Width = 80;
            // 
            // NextEstimatedData
            // 
            this.NextLimitData.Text = "Next Limit Data";
            this.NextLimitData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextLimitData.Width = 120;
            // 
            // columnWorkType
            // 
            this.columnWorkType.Text = "WorkType";
            this.columnWorkType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnWorkType.Width = 200;
            // 
            // columnRemarks
            // 
            this.columnRemarks.Text = "Remarks";
            this.columnRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnRemarks.Width = 200;
            // 
            // DirectiveComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Name = "DirectiveComplianceControl";
            this.Size = new System.Drawing.Size(851, 350);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader NextEstimated;
        private System.Windows.Forms.ColumnHeader NextEstimatedData;
        private System.Windows.Forms.ColumnHeader NextLimit;
        private System.Windows.Forms.ColumnHeader NextLimitData;
        private System.Windows.Forms.ColumnHeader columnWorkType;
        private System.Windows.Forms.ColumnHeader columnRemarks;
    }
}
