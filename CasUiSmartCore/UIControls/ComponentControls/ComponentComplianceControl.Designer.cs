using System.Windows.Forms;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentComplianceControl
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
                if (_toolStripMenuItemsWorkPackages != null)
                {
                    foreach (ToolStripMenuItem item in _toolStripMenuItemsWorkPackages.DropDownItems)
                    {
                        item.Click -= AddToWorkPackageItemClick;
                        item.Tag = null;
                    }

                    if (!_toolStripMenuItemsWorkPackages.IsDisposed)
                        _toolStripMenuItemsWorkPackages.Dispose();
                }

                if (_openPubWorkPackages != null)
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Need New Compliance", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Last Compliance", System.Windows.Forms.HorizontalAlignment.Left);
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTSNCSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWorkType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnWorkType,
            this.columnDate,
            this.columnTSNCSN,
            this.columnRemarks});
            this.listViewCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            listViewGroup1.Header = "Need New Compliance";
            listViewGroup1.Name = "GroupNewCompliance";
            listViewGroup2.Header = "Last Compliance";
            listViewGroup2.Name = "ListViewGroupLast";
            this.listViewCompliance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewCompliance.Margin = new System.Windows.Forms.Padding(5);
            this.listViewCompliance.Size = new System.Drawing.Size(1125, 293);
            this.listViewCompliance.ShowItemToolTips = true;
            this.listViewCompliance.Click += new System.EventHandler(this.ListViewComplainceClick);
            this.listViewCompliance.DoubleClick += new System.EventHandler(this.ListViewComplainceDoubleClick);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(4, 302);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(157, 302);
            this.ButtonEdit.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(316, 302);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // panelContainer
            // 
            this.panelContainer.Margin = new System.Windows.Forms.Padding(5);
            this.panelContainer.Size = new System.Drawing.Size(1127, 372);
            // 
            // ButtonRegisterActualState
            // 
            this.ButtonRegisterActualState.Location = new System.Drawing.Point(500, 302);
            this.ButtonRegisterActualState.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ButtonRegisterActualState.Visible = true;
            this.ButtonRegisterActualState.Click += new System.EventHandler(this.ButtonRegisterActualStateClick);
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date";
            this.columnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnDate.Width = 180;
            // 
            // columnTSNCSN
            // 
            this.columnTSNCSN.Text = "TSN/CSN";
            this.columnTSNCSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTSNCSN.Width = 180;
            // 
            // columnWorkType
            // 
            this.columnWorkType.Text = "WorkType";
            this.columnWorkType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnWorkType.Width = 180;
            // 
            // columnRemarks
            // 
            this.columnRemarks.Text = "Remarks";
            this.columnRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnRemarks.Width = 180;
            // 
            // DetailComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ComponentComplianceControl";
            this.Size = new System.Drawing.Size(1135, 436);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnTSNCSN;
        private System.Windows.Forms.ColumnHeader columnWorkType;
        private System.Windows.Forms.ColumnHeader columnRemarks;

    }
}
