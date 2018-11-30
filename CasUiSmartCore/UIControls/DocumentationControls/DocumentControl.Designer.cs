namespace CAS.UI.UIControls.DocumentationControls
{
	partial class DocumentControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.linkLabelRemoveDocument = new System.Windows.Forms.LinkLabel();
			this.linkLabelEditDocument = new System.Windows.Forms.LinkLabel();
			this.labelDocument = new System.Windows.Forms.Label();
			this.linkLabelAddDocument = new System.Windows.Forms.LinkLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.linkLabelRemoveDocument, 4, 0);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelEditDocument, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelDocument, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelAddDocument, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(471, 41);
			this.tableLayoutPanel1.TabIndex = 12;
			// 
			// linkLabelRemoveDocument
			// 
			this.linkLabelRemoveDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelRemoveDocument.AutoSize = true;
			this.linkLabelRemoveDocument.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelRemoveDocument.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelRemoveDocument.Location = new System.Drawing.Point(417, 14);
			this.linkLabelRemoveDocument.Name = "linkLabelRemoveDocument";
			this.linkLabelRemoveDocument.Size = new System.Drawing.Size(51, 12);
			this.linkLabelRemoveDocument.TabIndex = 16;
			this.linkLabelRemoveDocument.TabStop = true;
			this.linkLabelRemoveDocument.Text = "Remove";
			this.linkLabelRemoveDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemoveDocument_LinkClicked);
			// 
			// linkLabelEditDocument
			// 
			this.linkLabelEditDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelEditDocument.AutoSize = true;
			this.linkLabelEditDocument.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditDocument.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditDocument.Location = new System.Drawing.Point(386, 14);
			this.linkLabelEditDocument.Name = "linkLabelEditDocument";
			this.linkLabelEditDocument.Size = new System.Drawing.Size(25, 12);
			this.linkLabelEditDocument.TabIndex = 15;
			this.linkLabelEditDocument.TabStop = true;
			this.linkLabelEditDocument.Text = "Edit";
			this.linkLabelEditDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEditDocument_LinkClicked);
			// 
			// labelDocument
			// 
			this.labelDocument.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelDocument.AutoSize = true;
			this.labelDocument.Font = new System.Drawing.Font("Verdana", 8.25F);
			this.labelDocument.ForeColor = System.Drawing.Color.DimGray;
			this.labelDocument.Location = new System.Drawing.Point(3, 15);
			this.labelDocument.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelDocument.Name = "labelDocument";
			this.labelDocument.Size = new System.Drawing.Size(31, 13);
			this.labelDocument.TabIndex = 12;
			this.labelDocument.Text = "Title";
			// 
			// linkLabelAddDocument
			// 
			this.linkLabelAddDocument.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.linkLabelAddDocument.AutoSize = true;
			this.linkLabelAddDocument.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelAddDocument.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelAddDocument.Location = new System.Drawing.Point(294, 14);
			this.linkLabelAddDocument.Name = "linkLabelAddDocument";
			this.linkLabelAddDocument.Size = new System.Drawing.Size(86, 12);
			this.linkLabelAddDocument.TabIndex = 14;
			this.linkLabelAddDocument.TabStop = true;
			this.linkLabelAddDocument.Text = "Add Document";
			this.linkLabelAddDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddDocument_LinkClicked);
			// 
			// DocumentControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "DocumentControl";
			this.Size = new System.Drawing.Size(471, 41);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.LinkLabel linkLabelRemoveDocument;
		private System.Windows.Forms.LinkLabel linkLabelEditDocument;
		private System.Windows.Forms.Label labelDocument;
		private System.Windows.Forms.LinkLabel linkLabelAddDocument;
	}
}
