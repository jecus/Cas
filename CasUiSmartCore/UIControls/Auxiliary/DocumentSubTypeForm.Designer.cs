namespace CAS.UI.UIControls.Auxiliary
{
    partial class DocumentSubTypeForm
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
			this.listViewDocTypes = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listViewDocTypes
			// 
			this.listViewDocTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.listViewDocTypes.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listViewDocTypes.HideSelection = false;
			this.listViewDocTypes.LabelEdit = true;
			this.listViewDocTypes.Location = new System.Drawing.Point(20, 89);
			this.listViewDocTypes.Name = "listViewDocTypes";
			this.listViewDocTypes.Size = new System.Drawing.Size(273, 244);
			this.listViewDocTypes.TabIndex = 0;
			this.listViewDocTypes.UseCompatibleStateImageBehavior = false;
			this.listViewDocTypes.View = System.Windows.Forms.View.Details;
			this.listViewDocTypes.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ListViewCheckTypeAfterLabelEdit);
			this.listViewDocTypes.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ListViewDocTypesBeforeLabelEdit);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Doc Sub Type Name";
			this.columnHeader1.Width = 272;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(20, 63);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(228, 20);
			this.textBoxName.TabIndex = 1;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(254, 61);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(40, 23);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// DocumentSubTypeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 353);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.listViewDocTypes);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DocumentSubTypeForm";
			this.ShowIcon = false;
			this.Text = "Edit Document Sub Types";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewDocTypes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonAdd;
    }
}