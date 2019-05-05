using CAS.UI.UIControls.PurchaseControls;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class SelectMPDComplianceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMPDComplianceForm));
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnComponent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnKIT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.buttonOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewItems
			// 
			this.dataGridViewItems.AllowUserToAddRows = false;
			this.dataGridViewItems.AllowUserToDeleteRows = false;
			this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDescription,
            this.ColumnComponent,
            this.ColumnKIT});
			this.dataGridViewItems.Location = new System.Drawing.Point(9, 63);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowHeadersWidth = 4;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(428, 316);
			this.dataGridViewItems.TabIndex = 0;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.HeaderText = "Description";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.ReadOnly = true;
			this.ColumnDescription.Width = 180;
			// 
			// ColumnComponent
			// 
			this.ColumnComponent.HeaderText = "Component";
			this.ColumnComponent.Name = "ColumnComponent";
			this.ColumnComponent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnComponent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// ColumnKIT
			// 
			this.ColumnKIT.HeaderText = "KIT";
			this.ColumnKIT.Name = "ColumnKIT";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(362, 388);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// SelectMPDComplianceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 427);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.dataGridViewItems);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectMPDComplianceForm";
			this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
			this.Text = "Select Component, Kit Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnKIT;
        private System.Windows.Forms.Button buttonOK;
    }
}