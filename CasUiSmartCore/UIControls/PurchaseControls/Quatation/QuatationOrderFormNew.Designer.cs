using  MetroFramework.Controls;
using CASTerms;
using EntityCore.DTO.General;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.PurchaseControls.Initial
{
	partial class QuatationOrderFormNew
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
			this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
			this.buttonAddQualificationNumber = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonAddSupplierForAll = new System.Windows.Forms.Button();
			this.buttonExtended = new System.Windows.Forms.Button();
			this.documentControl10 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl9 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl8 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl7 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl6 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl5 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl4 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl3 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl2 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.documentControl1 = new CAS.UI.UIControls.DocumentationControls.DocumentControl();
			this.listViewInitialItems = new CAS.UI.UIControls.PurchaseControls.Quatation.QuatationOrderListViewNew();
			this.SuspendLayout();
			// 
			// ButtonDelete
			// 
			this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonDelete.ActiveBackgroundImage = null;
			this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 8F);
			this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 8F);
			this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
			this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonDelete.IconNotEnabled = null;
			this.ButtonDelete.Location = new System.Drawing.Point(889, 705);
			this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
			this.ButtonDelete.Name = "ButtonDelete";
			this.ButtonDelete.NormalBackgroundImage = null;
			this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonDelete.ShowToolTip = false;
			this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
			this.ButtonDelete.TabIndex = 289;
			this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonDelete.TextMain = "Delete Selected";
			this.ButtonDelete.TextSecondary = "";
			this.ButtonDelete.ToolTipText = "";
			this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
			// 
			// buttonAddQualificationNumber
			// 
			this.buttonAddQualificationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddQualificationNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddQualificationNumber.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddQualificationNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAddQualificationNumber.Location = new System.Drawing.Point(537, 732);
			this.buttonAddQualificationNumber.Name = "buttonAddQualificationNumber";
			this.buttonAddQualificationNumber.Size = new System.Drawing.Size(95, 33);
			this.buttonAddQualificationNumber.TabIndex = 318;
			this.buttonAddQualificationNumber.Text = "Add QO №";
			this.buttonAddQualificationNumber.Click += new System.EventHandler(this.buttonAddQualificationNumber_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button3.Location = new System.Drawing.Point(638, 732);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(125, 33);
			this.button3.TabIndex = 269;
			this.button3.Text = "Edit Prices";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Enabled = false;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.button2.Location = new System.Drawing.Point(406, 732);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 33);
			this.button2.TabIndex = 268;
			this.button2.Text = "Add Suppliers";
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(1119, 732);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 33);
			this.buttonOk.TabIndex = 293;
			this.buttonOk.Text = "OK";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(1200, 732);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 292;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.ItemHeight = 17;
			this.comboBox1.Location = new System.Drawing.Point(23, 737);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(233, 25);
			this.comboBox1.TabIndex = 316;
			// 
			// buttonAddSupplierForAll
			// 
			this.buttonAddSupplierForAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddSupplierForAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddSupplierForAll.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddSupplierForAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAddSupplierForAll.Location = new System.Drawing.Point(262, 732);
			this.buttonAddSupplierForAll.Name = "buttonAddSupplierForAll";
			this.buttonAddSupplierForAll.Size = new System.Drawing.Size(138, 33);
			this.buttonAddSupplierForAll.TabIndex = 317;
			this.buttonAddSupplierForAll.Text = "Add Supplier All";
			this.buttonAddSupplierForAll.Click += new System.EventHandler(this.buttonAddSupplierForAll_Click);
			// 
			// buttonExtended
			// 
			this.buttonExtended.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExtended.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExtended.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonExtended.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonExtended.Location = new System.Drawing.Point(1018, 732);
			this.buttonExtended.Name = "buttonExtended";
			this.buttonExtended.Size = new System.Drawing.Size(95, 33);
			this.buttonExtended.TabIndex = 319;
			this.buttonExtended.Text = "Extended";
			this.buttonExtended.Click += new System.EventHandler(this.buttonExtended_Click);
			// 
			// documentControl10
			// 
			this.documentControl10.CurrentDocument = null;
			this.documentControl10.Location = new System.Drawing.Point(1017, 463);
			this.documentControl10.Name = "documentControl10";
			this.documentControl10.Size = new System.Drawing.Size(268, 41);
			this.documentControl10.TabIndex = 315;
			// 
			// documentControl9
			// 
			this.documentControl9.CurrentDocument = null;
			this.documentControl9.Location = new System.Drawing.Point(1017, 416);
			this.documentControl9.Name = "documentControl9";
			this.documentControl9.Size = new System.Drawing.Size(268, 41);
			this.documentControl9.TabIndex = 314;
			// 
			// documentControl8
			// 
			this.documentControl8.CurrentDocument = null;
			this.documentControl8.Location = new System.Drawing.Point(1017, 369);
			this.documentControl8.Name = "documentControl8";
			this.documentControl8.Size = new System.Drawing.Size(268, 41);
			this.documentControl8.TabIndex = 313;
			// 
			// documentControl7
			// 
			this.documentControl7.CurrentDocument = null;
			this.documentControl7.Location = new System.Drawing.Point(1017, 322);
			this.documentControl7.Name = "documentControl7";
			this.documentControl7.Size = new System.Drawing.Size(268, 41);
			this.documentControl7.TabIndex = 312;
			// 
			// documentControl6
			// 
			this.documentControl6.CurrentDocument = null;
			this.documentControl6.Location = new System.Drawing.Point(1017, 275);
			this.documentControl6.Name = "documentControl6";
			this.documentControl6.Size = new System.Drawing.Size(268, 41);
			this.documentControl6.TabIndex = 311;
			// 
			// documentControl5
			// 
			this.documentControl5.CurrentDocument = null;
			this.documentControl5.Location = new System.Drawing.Point(1017, 228);
			this.documentControl5.Name = "documentControl5";
			this.documentControl5.Size = new System.Drawing.Size(268, 41);
			this.documentControl5.TabIndex = 310;
			// 
			// documentControl4
			// 
			this.documentControl4.CurrentDocument = null;
			this.documentControl4.Location = new System.Drawing.Point(1017, 181);
			this.documentControl4.Name = "documentControl4";
			this.documentControl4.Size = new System.Drawing.Size(268, 41);
			this.documentControl4.TabIndex = 309;
			// 
			// documentControl3
			// 
			this.documentControl3.CurrentDocument = null;
			this.documentControl3.Location = new System.Drawing.Point(1017, 134);
			this.documentControl3.Name = "documentControl3";
			this.documentControl3.Size = new System.Drawing.Size(268, 41);
			this.documentControl3.TabIndex = 308;
			// 
			// documentControl2
			// 
			this.documentControl2.CurrentDocument = null;
			this.documentControl2.Location = new System.Drawing.Point(1017, 87);
			this.documentControl2.Name = "documentControl2";
			this.documentControl2.Size = new System.Drawing.Size(268, 41);
			this.documentControl2.TabIndex = 307;
			// 
			// documentControl1
			// 
			this.documentControl1.CurrentDocument = null;
			this.documentControl1.Location = new System.Drawing.Point(1017, 40);
			this.documentControl1.Name = "documentControl1";
			this.documentControl1.Size = new System.Drawing.Size(268, 41);
			this.documentControl1.TabIndex = 306;
			// 
			// listViewInitialItems
			// 
			this.listViewInitialItems.ConfigurePaste = null;
			this.listViewInitialItems.Displayer = null;
			this.listViewInitialItems.DisplayerText = null;
			this.listViewInitialItems.EnableCustomSorting = false;
			this.listViewInitialItems.Entity = null;
			this.listViewInitialItems.IgnoreEnterPress = false;
			this.listViewInitialItems.Location = new System.Drawing.Point(23, 63);
			this.listViewInitialItems.MenuOpeningAction = null;
			this.listViewInitialItems.Name = "listViewInitialItems";
			this.listViewInitialItems.OldColumnIndex = 0;
			this.listViewInitialItems.PasteComplete = null;
			this.listViewInitialItems.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewInitialItems.Size = new System.Drawing.Size(988, 635);
			this.listViewInitialItems.SortMultiplier = 0;
			this.listViewInitialItems.TabIndex = 294;
			this.listViewInitialItems.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewInitialItems_SelectedItemsChanged);
			// 
			// QuatationOrderFormNew
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1288, 779);
			this.Controls.Add(this.buttonExtended);
			this.Controls.Add(this.buttonAddQualificationNumber);
			this.Controls.Add(this.buttonAddSupplierForAll);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.documentControl10);
			this.Controls.Add(this.documentControl9);
			this.Controls.Add(this.documentControl8);
			this.Controls.Add(this.documentControl7);
			this.Controls.Add(this.documentControl6);
			this.Controls.Add(this.documentControl5);
			this.Controls.Add(this.documentControl4);
			this.Controls.Add(this.documentControl3);
			this.Controls.Add(this.documentControl2);
			this.Controls.Add(this.documentControl1);
			this.Controls.Add(this.listViewInitialItems);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.ButtonDelete);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QuatationOrderFormNew";
			this.Resizable = false;
			this.Text = "Quotation Form";
			this.ResumeLayout(false);

		}

		#endregion
		private AvControls.AvButtonT.AvButtonT ButtonDelete;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private CAS.UI.UIControls.PurchaseControls.Quatation.QuatationOrderListViewNew listViewInitialItems;
		private System.Windows.Forms.Button button2;
		private DocumentationControls.DocumentControl documentControl1;
		private DocumentationControls.DocumentControl documentControl2;
		private DocumentationControls.DocumentControl documentControl3;
		private DocumentationControls.DocumentControl documentControl4;
		private DocumentationControls.DocumentControl documentControl5;
		private DocumentationControls.DocumentControl documentControl6;
		private DocumentationControls.DocumentControl documentControl7;
		private DocumentationControls.DocumentControl documentControl8;
		private DocumentationControls.DocumentControl documentControl9;
		private DocumentationControls.DocumentControl documentControl10;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button buttonAddSupplierForAll;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button buttonAddQualificationNumber;
		private System.Windows.Forms.Button buttonExtended;
	}
}