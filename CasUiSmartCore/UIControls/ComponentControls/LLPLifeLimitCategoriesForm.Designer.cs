namespace CAS.UI.UIControls.ComponentControls
{
    partial class LLPLifeLimitCategoriesForm
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
            this.flowLayoutPanelCharts = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCategoryName = new System.Windows.Forms.Label();
            this.labelCategoryType = new System.Windows.Forms.Label();
            this.labelKits = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanelCharts.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCharts
            // 
            this.flowLayoutPanelCharts.AutoScroll = true;
            this.flowLayoutPanelCharts.Controls.Add(this.panelLabel);
            this.flowLayoutPanelCharts.Location = new System.Drawing.Point(7, 12);
            this.flowLayoutPanelCharts.Name = "flowLayoutPanelCharts";
            this.flowLayoutPanelCharts.Size = new System.Drawing.Size(484, 335);
            this.flowLayoutPanelCharts.TabIndex = 14;
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.label1);
            this.panelLabel.Controls.Add(this.labelCategoryName);
            this.panelLabel.Controls.Add(this.labelCategoryType);
            this.panelLabel.Controls.Add(this.labelKits);
            this.panelLabel.Location = new System.Drawing.Point(3, 3);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(474, 45);
            this.panelLabel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(314, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 45;
            this.label1.Text = "Aircraft Model:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCategoryName
            // 
            this.labelCategoryName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCategoryName.Location = new System.Drawing.Point(158, 20);
            this.labelCategoryName.Name = "labelCategoryName";
            this.labelCategoryName.Size = new System.Drawing.Size(150, 25);
            this.labelCategoryName.TabIndex = 44;
            this.labelCategoryName.Text = "Category Name:";
            this.labelCategoryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCategoryType
            // 
            this.labelCategoryType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCategoryType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCategoryType.Location = new System.Drawing.Point(2, 20);
            this.labelCategoryType.Name = "labelCategoryType";
            this.labelCategoryType.Size = new System.Drawing.Size(150, 25);
            this.labelCategoryType.TabIndex = 43;
            this.labelCategoryType.Text = "Category Type:";
            this.labelCategoryType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelKits
            // 
            this.labelKits.AutoSize = true;
            this.labelKits.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelKits.Location = new System.Drawing.Point(158, 0);
            this.labelKits.Name = "labelKits";
            this.labelKits.Size = new System.Drawing.Size(121, 13);
            this.labelKits.TabIndex = 3;
            this.labelKits.Text = "Life Limit categories";
            this.labelKits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonOk
            // 
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.Location = new System.Drawing.Point(408, 353);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(30, 23);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.Location = new System.Drawing.Point(444, 353);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(47, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // LLPLifeLimitCategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 380);
            this.Controls.Add(this.flowLayoutPanelCharts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "LLPLifeLimitCategoriesForm";
            this.ShowIcon = false;
            this.Text = "LLP Life Limit Categories";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KitFormFormClosed);
            this.flowLayoutPanelCharts.ResumeLayout(false);
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCharts;
        private System.Windows.Forms.Panel panelLabel;
        private System.Windows.Forms.Label labelKits;
        public System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.Label labelCategoryType;
    }
}