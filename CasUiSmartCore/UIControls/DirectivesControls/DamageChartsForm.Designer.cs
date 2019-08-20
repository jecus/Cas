using AvControls.AvButtonT;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.DirectivesControls
{
    partial class DamageChartsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.listViewDamageCharts = new System.Windows.Forms.ListView();
			this.columnChartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnAircraftModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnChartFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.SuspendLayout();
			// 
			// listViewDamageCharts
			// 
			this.listViewDamageCharts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnChartName,
            this.columnAircraftModel,
            this.columnChartFileName});
			this.listViewDamageCharts.FullRowSelect = true;
			this.listViewDamageCharts.HideSelection = false;
			this.listViewDamageCharts.Location = new System.Drawing.Point(7, 63);
			this.listViewDamageCharts.Name = "listViewDamageCharts";
			this.listViewDamageCharts.Size = new System.Drawing.Size(587, 181);
			this.listViewDamageCharts.TabIndex = 0;
			this.listViewDamageCharts.UseCompatibleStateImageBehavior = false;
			this.listViewDamageCharts.View = System.Windows.Forms.View.Details;
			this.listViewDamageCharts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDefferedCategoriesMouseClick);
			this.listViewDamageCharts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDefferedCategoriesMouseDoubleClick);
			// 
			// columnChartName
			// 
			this.columnChartName.Text = "Chart name";
			this.columnChartName.Width = 98;
			// 
			// columnAircraftModel
			// 
			this.columnAircraftModel.Text = "Aircraft Model";
			this.columnAircraftModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnAircraftModel.Width = 171;
			// 
			// columnChartFileName
			// 
			this.columnChartFileName.Text = "Chart file";
			this.columnChartFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnChartFileName.Width = 294;
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.Enabled = false;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.ButtonDelete.Location = new System.Drawing.Point(273, 258);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(267, 54);
			this.ButtonDelete.TabIndex = 10;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete damage";
			this.ButtonDelete.TextSecondary = "chart";
			this.ButtonDelete.ToolTipText = null;
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAdd.ActiveBackgroundImage = null;
			this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.ButtonAdd.Location = new System.Drawing.Point(46, 258);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = false;
			this.ButtonAdd.Size = new System.Drawing.Size(221, 54);
			this.ButtonAdd.TabIndex = 9;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "Add damage";
			this.ButtonAdd.TextSecondary = "chart";
			this.ButtonAdd.ToolTipText = null;
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// DamageChartsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 335);
			this.Controls.Add(this.ButtonDelete);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.listViewDamageCharts);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(600, 370);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 300);
			this.Name = "DamageChartsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Damage charts";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDamageCharts;
        private System.Windows.Forms.ColumnHeader columnChartName;
        private System.Windows.Forms.ColumnHeader columnChartFileName;
        private System.Windows.Forms.ColumnHeader columnAircraftModel;
        public AvButtonT ButtonDelete;
        public AvButtonT ButtonAdd;
    }
}