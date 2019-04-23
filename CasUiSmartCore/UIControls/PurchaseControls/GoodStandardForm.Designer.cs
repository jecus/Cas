using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.General;

namespace CAS.UI.UIControls.PurchaseControls
{
    partial class GoodStandardForm
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
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoodStandardForm));
            this.labelRemarks = new System.Windows.Forms.Label();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelPartNumber = new System.Windows.Forms.Label();
            this.textBoxPartNumber = new System.Windows.Forms.TextBox();
            this.labelProducts = new System.Windows.Forms.Label();
            this.dataGridViewProducts = new CAS.UI.UIControls.Auxiliary.CommonListViewControl();
            this.comboBoxDefaultProduct = new System.Windows.Forms.ComboBox();
            this.labelDefaultProduct = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxDetailClass = new CAS.UI.UIControls.Auxiliary.TreeDictionaryComboBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
            this.SuspendLayout();
            // 
            // labelRemarks
            // 
            this.labelRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelRemarks.Location = new System.Drawing.Point(5, 177);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(63, 24);
            this.labelRemarks.TabIndex = 88;
            this.labelRemarks.Text = "Remarks:";
            this.labelRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxRemarks
            // 
            this.textBoxRemarks.BackColor = System.Drawing.Color.White;
            this.textBoxRemarks.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxRemarks.Location = new System.Drawing.Point(129, 177);
            this.textBoxRemarks.MaxLength = 100;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(685, 162);
            this.textBoxRemarks.TabIndex = 8;
            this.textBoxRemarks.Text = "Line1\r\nLin2\r\nLine3\r\nLine4\r\nLine5\r\nLine 6";
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDescription.Location = new System.Drawing.Point(5, 90);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(89, 25);
            this.labelDescription.TabIndex = 81;
            this.labelDescription.Text = "Description:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxDescription.Location = new System.Drawing.Point(129, 93);
            this.textBoxDescription.MaxLength = 128;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(685, 78);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelPartNumber
            // 
            this.labelPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelPartNumber.Location = new System.Drawing.Point(5, 63);
            this.labelPartNumber.Name = "labelPartNumber";
            this.labelPartNumber.Size = new System.Drawing.Size(69, 25);
            this.labelPartNumber.TabIndex = 79;
            this.labelPartNumber.Text = "P/N:";
            this.labelPartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxPartNumber
            // 
            this.textBoxPartNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPartNumber.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPartNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxPartNumber.Location = new System.Drawing.Point(129, 65);
            this.textBoxPartNumber.MaxLength = 128;
            this.textBoxPartNumber.Name = "textBoxPartNumber";
            this.textBoxPartNumber.Size = new System.Drawing.Size(685, 22);
            this.textBoxPartNumber.TabIndex = 2;
            // 
            // labelProducts
            // 
            this.labelProducts.AutoSize = true;
            this.labelProducts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelProducts.Location = new System.Drawing.Point(399, 374);
            this.labelProducts.Name = "labelProducts";
            this.labelProducts.Size = new System.Drawing.Size(62, 14);
            this.labelProducts.TabIndex = 102;
            this.labelProducts.Text = "Products";
            this.labelProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.Displayer = null;
            this.dataGridViewProducts.DisplayerText = null;
            this.dataGridViewProducts.Entity = null;
            this.dataGridViewProducts.Location = new System.Drawing.Point(3, 396);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.dataGridViewProducts.ShowGroups = true;
            this.dataGridViewProducts.Size = new System.Drawing.Size(811, 244);
            this.dataGridViewProducts.TabIndex = 10;
            // 
            // comboBoxDefaultProduct
            // 
            this.comboBoxDefaultProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDefaultProduct.FormattingEnabled = true;
            this.comboBoxDefaultProduct.Location = new System.Drawing.Point(129, 345);
            this.comboBoxDefaultProduct.Name = "comboBoxDefaultProduct";
            this.comboBoxDefaultProduct.Size = new System.Drawing.Size(685, 21);
            this.comboBoxDefaultProduct.TabIndex = 9;
            // 
            // labelDefaultProduct
            // 
            this.labelDefaultProduct.AutoSize = true;
            this.labelDefaultProduct.Font = new System.Drawing.Font("Verdana", 9F);
            this.labelDefaultProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDefaultProduct.Location = new System.Drawing.Point(0, 348);
            this.labelDefaultProduct.Name = "labelDefaultProduct";
            this.labelDefaultProduct.Size = new System.Drawing.Size(118, 14);
            this.labelDefaultProduct.TabIndex = 104;
            this.labelDefaultProduct.Text = "Recomend. Prod.:";
            this.labelDefaultProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelName.Location = new System.Drawing.Point(5, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(69, 25);
            this.labelName.TabIndex = 106;
            this.labelName.Text = "Name:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.White;
            this.textBoxName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxName.Location = new System.Drawing.Point(129, 8);
            this.textBoxName.MaxLength = 128;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(685, 22);
            this.textBoxName.TabIndex = 0;
            // 
            // comboBoxDetailClass
            // 
            this.comboBoxDetailClass.Displayer = null;
            this.comboBoxDetailClass.DisplayerText = null;
            this.comboBoxDetailClass.DropDownHeight = 106;
            this.comboBoxDetailClass.Entity = null;
            this.comboBoxDetailClass.Location = new System.Drawing.Point(129, 36);
            this.comboBoxDetailClass.Name = "comboBoxDetailClass";
            this.comboBoxDetailClass.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.comboBoxDetailClass.RootNodesNames = null;
            this.comboBoxDetailClass.Size = new System.Drawing.Size(685, 21);
            this.comboBoxDetailClass.TabIndex = 1;
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.labelClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelClass.Location = new System.Drawing.Point(5, 37);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(47, 14);
            this.labelClass.TabIndex = 108;
            this.labelClass.Text = "Class:";
            this.labelClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAdd.ActiveBackgroundImage = null;
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
            this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
            this.ButtonAdd.Location = new System.Drawing.Point(764, 369);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = true;
            this.ButtonAdd.Size = new System.Drawing.Size(25, 24);
            this.ButtonAdd.TabIndex = 37;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "Add Item";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// buttonDelete
			// 
			this.buttonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.ActiveBackgroundImage = null;
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.buttonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.buttonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.buttonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIconGraySmall;
            this.buttonDelete.Location = new System.Drawing.Point(789, 369);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.NormalBackgroundImage = null;
            this.buttonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.buttonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.buttonDelete.ShowToolTip = true;
            this.buttonDelete.Size = new System.Drawing.Size(25, 24);
            this.buttonDelete.TabIndex = 38;
            this.buttonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.TextMain = "";
            this.buttonDelete.TextSecondary = "";
            this.buttonDelete.ToolTipText = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.buttonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);

			this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Controls.Add(this.textBoxName);
            this.panelMain.Controls.Add(this.labelClass);
            //this.panelMain.Controls.Add(this.labelCostOverhaul);
            //this.panelMain.Controls.Add(this.numericCostOverhaul);
            //this.panelMain.Controls.Add(this.labelCostServiceable);
            //this.panelMain.Controls.Add(this.numericCostServiceable);
            //this.panelMain.Controls.Add(this.labelCoatNew);
            //this.panelMain.Controls.Add(this.numericCostNew);
            this.panelMain.Controls.Add(this.labelRemarks);
            this.panelMain.Controls.Add(this.textBoxRemarks);
            this.panelMain.Controls.Add(this.labelDefaultProduct);
            this.panelMain.Controls.Add(this.comboBoxDefaultProduct);
            this.panelMain.Controls.Add(this.labelProducts);
            this.panelMain.Controls.Add(this.dataGridViewProducts);
            this.panelMain.Controls.Add(this.labelDescription);
            this.panelMain.Controls.Add(this.textBoxDescription);
            this.panelMain.Controls.Add(this.labelPartNumber);
            this.panelMain.Controls.Add(this.textBoxPartNumber);
            //this.panelMain.Controls.Add(this.comboBoxMeasure);
            //this.panelMain.Controls.Add(this.labelMeasure);
            this.panelMain.Controls.Add(this.comboBoxDetailClass);
            this.panelMain.Controls.Add(this.ButtonAdd);
            this.panelMain.Controls.Add(this.buttonDelete);
            // 
            // GoodStandardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 680);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1023, 767);
            this.MinimumSize = new System.Drawing.Size(284, 164);
            this.Name = "GoodStandardForm";
            this.Text = "Standard Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.TextBox textBoxRemarks;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelPartNumber;
        private System.Windows.Forms.TextBox textBoxPartNumber;
        private System.Windows.Forms.Label labelProducts;
        private CommonListViewControl dataGridViewProducts;
        private System.Windows.Forms.ComboBox comboBoxDefaultProduct;
        private System.Windows.Forms.Label labelDefaultProduct;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private TreeDictionaryComboBox comboBoxDetailClass;
        private System.Windows.Forms.Label labelClass;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT buttonDelete;

    }
}