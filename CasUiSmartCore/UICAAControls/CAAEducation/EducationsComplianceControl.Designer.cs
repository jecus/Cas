using System.ComponentModel;
using System.Windows.Forms;
using AvControls.AvButtonT;

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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Need new compliance:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Last compliance", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Need new compliance:", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Last compliance", System.Windows.Forms.HorizontalAlignment.Left);
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.listViewCompliance = new System.Windows.Forms.ListView();
            this.NextCourse = new System.Windows.Forms.ColumnHeader();
            this.NextLimitDate = new System.Windows.Forms.ColumnHeader();
            this.columnRemarks = new System.Windows.Forms.ColumnHeader();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.Enabled = false;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
            this.ButtonDelete.Location = new System.Drawing.Point(140, 225);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(151, 66);
            this.ButtonDelete.TabIndex = 8;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = "";
            this.ButtonDelete.Click += ButtonDeleteOnClick;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAdd.ActiveBackgroundImage = null;
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.ButtonAdd.Location = new System.Drawing.Point(4, 225);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = false;
            this.ButtonAdd.Size = new System.Drawing.Size(126, 66);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "Add";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "";
            this.ButtonAdd.Click += ButtonAddOnClick;
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.NextCourse, this.NextLimitDate, this.columnRemarks });
            this.listViewCompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listViewCompliance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listViewCompliance.FullRowSelect = true;
            listViewGroup1.Header = "Need new compliance:";
            listViewGroup1.Name = "GroupNewCompliance";
            listViewGroup2.Header = "Last compliance";
            listViewGroup2.Name = "ListViewGroupLast";
            listViewGroup3.Header = "Need new compliance:";
            listViewGroup3.Name = "GroupNewCompliance";
            listViewGroup4.Header = "Last compliance";
            listViewGroup4.Name = "ListViewGroupLast";
            this.listViewCompliance.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4 });
            this.listViewCompliance.Location = new System.Drawing.Point(0, 0);
            this.listViewCompliance.Name = "listViewCompliance";
            this.listViewCompliance.ShowItemToolTips = true;
            this.listViewCompliance.Size = new System.Drawing.Size(951, 227);
            this.listViewCompliance.TabIndex = 0;
            this.listViewCompliance.UseCompatibleStateImageBehavior = false;
            this.listViewCompliance.View = System.Windows.Forms.View.Details;
            this.listViewCompliance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewComplainceMouseDoubleClick);
            this.listViewCompliance.SelectedIndexChanged += ListViewComplianceOnSelectedIndexChanged;
            // 
            // NextCourse
            // 
            this.NextCourse.Text = "Courses";
            this.NextCourse.Width = 200;
            // 
            // NextLimitDate
            // 
            this.NextLimitDate.Text = "Date";
            this.NextLimitDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NextLimitDate.Width = 200;
            // 
            // columnRemarks
            // 
            this.columnRemarks.Text = "Remark";
            this.columnRemarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnRemarks.Width = 200;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.ButtonDelete);
            this.panelContainer.Controls.Add(this.ButtonAdd);
            this.panelContainer.Controls.Add(this.listViewCompliance);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(951, 301);
            this.panelContainer.TabIndex = 1;
            // 
            // EducationsComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "EducationsComplianceControl";
            this.Size = new System.Drawing.Size(951, 310);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        public System.Windows.Forms.ListView listViewCompliance;
        public System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ColumnHeader NextCourse;
        private System.Windows.Forms.ColumnHeader NextLimitDate;
        private System.Windows.Forms.ColumnHeader columnRemarks;
        public AvControls.AvButtonT.AvButtonT ButtonAdd;
        public AvControls.AvButtonT.AvButtonT ButtonDelete;
        #endregion
    }
}