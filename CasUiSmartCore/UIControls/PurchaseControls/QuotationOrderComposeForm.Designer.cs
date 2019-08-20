namespace CAS.UI.UIControls.PurchaseControls
{
	partial class QuotationOrderComposeForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationOrderComposeForm));
			this.checkBoxNew = new System.Windows.Forms.CheckBox();
			this.checkBoxServiceable = new System.Windows.Forms.CheckBox();
			this.checkBoxOverhaul = new System.Windows.Forms.CheckBox();
			this.dataGridViewItems = new System.Windows.Forms.DataGridView();
			this.ColumnProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnQuantity = new CAS.UI.UIControls.Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn();
			this.ColumnOrder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnNew = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnServiceable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnOH = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnRepair = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonCompose = new System.Windows.Forms.Button();
			this.checkBoxRepair = new System.Windows.Forms.CheckBox();
			this.checkBoxOrder = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxNew
			// 
			this.checkBoxNew.AutoSize = true;
			this.checkBoxNew.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxNew.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxNew.Location = new System.Drawing.Point(352, 62);
			this.checkBoxNew.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxNew.Name = "checkBoxNew";
			this.checkBoxNew.Size = new System.Drawing.Size(54, 18);
			this.checkBoxNew.TabIndex = 59;
			this.checkBoxNew.Text = "New";
			this.checkBoxNew.UseVisualStyleBackColor = true;
			this.checkBoxNew.CheckedChanged += new System.EventHandler(this.CheckBoxNewCheckedChanged);
			// 
			// checkBoxServiceable
			// 
			this.checkBoxServiceable.AutoSize = true;
			this.checkBoxServiceable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxServiceable.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxServiceable.Location = new System.Drawing.Point(427, 62);
			this.checkBoxServiceable.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxServiceable.Name = "checkBoxServiceable";
			this.checkBoxServiceable.Size = new System.Drawing.Size(57, 18);
			this.checkBoxServiceable.TabIndex = 60;
			this.checkBoxServiceable.Text = "Serv.";
			this.checkBoxServiceable.UseVisualStyleBackColor = true;
			this.checkBoxServiceable.CheckedChanged += new System.EventHandler(this.CheckBoxServiceableCheckedChanged);
			// 
			// checkBoxOverhaul
			// 
			this.checkBoxOverhaul.AutoSize = true;
			this.checkBoxOverhaul.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxOverhaul.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxOverhaul.Location = new System.Drawing.Point(502, 62);
			this.checkBoxOverhaul.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxOverhaul.Name = "checkBoxOverhaul";
			this.checkBoxOverhaul.Size = new System.Drawing.Size(45, 18);
			this.checkBoxOverhaul.TabIndex = 61;
			this.checkBoxOverhaul.Text = "OH";
			this.checkBoxOverhaul.UseVisualStyleBackColor = true;
			this.checkBoxOverhaul.CheckedChanged += new System.EventHandler(this.CheckBoxOverhaulCheckedChanged);
			// 
			// dataGridViewItems
			// 
			this.dataGridViewItems.AllowUserToAddRows = false;
			this.dataGridViewItems.AllowUserToDeleteRows = false;
			this.dataGridViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			this.dataGridViewItems.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.ColumnProduct,
			this.ColumnQuantity,
			this.ColumnOrder,
			this.ColumnNew,
			this.ColumnServiceable,
			this.ColumnOH,
			this.ColumnRepair});
			this.dataGridViewItems.Location = new System.Drawing.Point(2, 87);
			this.dataGridViewItems.Margin = new System.Windows.Forms.Padding(2);
			this.dataGridViewItems.Name = "dataGridViewItems";
			this.dataGridViewItems.RowHeadersVisible = false;
			this.dataGridViewItems.RowTemplate.Height = 24;
			this.dataGridViewItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewItems.Size = new System.Drawing.Size(676, 148);
			this.dataGridViewItems.TabIndex = 64;
			this.dataGridViewItems.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewItemsCellValueChanged);
			this.dataGridViewItems.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewItemsCurrentCellDirtyStateChanged);
			this.dataGridViewItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewItemsDataError);
			// 
			// ColumnProduct
			// 
			this.ColumnProduct.HeaderText = "Product";
			this.ColumnProduct.Name = "ColumnProduct";
			this.ColumnProduct.ReadOnly = true;
			this.ColumnProduct.Width = 175;
			// 
			// ColumnQuantity
			// 
			this.ColumnQuantity.DecimalPlaces = 2;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnQuantity.DefaultCellStyle = dataGridViewCellStyle1;
			this.ColumnQuantity.HeaderText = "Q-ty";
			this.ColumnQuantity.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.ColumnQuantity.Name = "ColumnQuantity";
			this.ColumnQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.ColumnQuantity.Width = 75;
			// 
			// ColumnOrder
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.NullValue = false;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ColumnOrder.DefaultCellStyle = dataGridViewCellStyle2;
			this.ColumnOrder.HeaderText = "Order";
			this.ColumnOrder.Name = "ColumnOrder";
			this.ColumnOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// ColumnNew
			// 
			this.ColumnNew.HeaderText = "New";
			this.ColumnNew.Name = "ColumnNew";
			this.ColumnNew.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnNew.Width = 75;
			// 
			// ColumnServiceable
			// 
			this.ColumnServiceable.HeaderText = "Serv.";
			this.ColumnServiceable.Name = "ColumnServiceable";
			this.ColumnServiceable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnServiceable.Width = 75;
			// 
			// ColumnOH
			// 
			this.ColumnOH.HeaderText = "OH";
			this.ColumnOH.Name = "ColumnOH";
			this.ColumnOH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnOH.Width = 75;
			// 
			// ColumnRepair
			// 
			this.ColumnRepair.HeaderText = "Repair";
			this.ColumnRepair.Name = "ColumnRepair";
			this.ColumnRepair.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ColumnRepair.Width = 75;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(583, 240);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 66;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonCompose
			// 
			this.buttonCompose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCompose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCompose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCompose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCompose.Location = new System.Drawing.Point(493, 240);
			this.buttonCompose.Name = "buttonCompose";
			this.buttonCompose.Size = new System.Drawing.Size(84, 33);
			this.buttonCompose.TabIndex = 65;
			this.buttonCompose.Text = "Compose";
			this.buttonCompose.Click += new System.EventHandler(this.ButtonComposeClick);
			// 
			// checkBoxRepair
			// 
			this.checkBoxRepair.AutoSize = true;
			this.checkBoxRepair.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRepair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxRepair.Location = new System.Drawing.Point(577, 62);
			this.checkBoxRepair.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxRepair.Name = "checkBoxRepair";
			this.checkBoxRepair.Size = new System.Drawing.Size(66, 18);
			this.checkBoxRepair.TabIndex = 67;
			this.checkBoxRepair.Text = "Repair";
			this.checkBoxRepair.UseVisualStyleBackColor = true;
			this.checkBoxRepair.CheckedChanged += new System.EventHandler(this.CheckBoxRepairCheckedChanged);
			// 
			// checkBoxOrder
			// 
			this.checkBoxOrder.AutoSize = true;
			this.checkBoxOrder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxOrder.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxOrder.Location = new System.Drawing.Point(266, 62);
			this.checkBoxOrder.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxOrder.Name = "checkBoxOrder";
			this.checkBoxOrder.Size = new System.Drawing.Size(62, 18);
			this.checkBoxOrder.TabIndex = 68;
			this.checkBoxOrder.Text = "Order";
			this.checkBoxOrder.UseVisualStyleBackColor = true;
			this.checkBoxOrder.CheckedChanged += new System.EventHandler(this.CheckBoxOrderCheckedChanged);
			// 
			// QuotationOrderComposeForm
			// 
			this.AcceptButton = this.buttonCompose;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(681, 275);
			this.Controls.Add(this.checkBoxOrder);
			this.Controls.Add(this.checkBoxRepair);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonCompose);
			this.Controls.Add(this.dataGridViewItems);
			this.Controls.Add(this.checkBoxOverhaul);
			this.Controls.Add(this.checkBoxServiceable);
			this.Controls.Add(this.checkBoxNew);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuotationOrderComposeForm";
			this.Text = "Compose Initial Order Form";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxNew;
		private System.Windows.Forms.CheckBox checkBoxServiceable;
		private System.Windows.Forms.CheckBox checkBoxOverhaul;
		private System.Windows.Forms.DataGridView dataGridViewItems;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonCompose;
		private System.Windows.Forms.CheckBox checkBoxRepair;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProduct;
		private Auxiliary.DataGridViewElements.DataGridViewNumericUpDownColumn ColumnQuantity;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOrder;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnNew;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnServiceable;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnOH;
		private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnRepair;
		private System.Windows.Forms.CheckBox checkBoxOrder;
	}
}