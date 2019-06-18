namespace CAS.UI.UIControls.NewGrid
{
	partial class BaseGridViewControl<T>
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
			Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
			this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
			this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
			this.panelBottomContainer = new System.Windows.Forms.Panel();
			this.labelTotal = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
			this.panelBottomContainer.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// radGridView1
			// 
			this.radGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.radGridView1.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.radGridView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.radGridView1.Location = new System.Drawing.Point(0, 0);
			// 
			// 
			// 
			this.radGridView1.MasterTemplate.AllowAddNewRow = false;
			this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
			this.radGridView1.Name = "radGridView1";
			this.radGridView1.ReadOnly = true;
			// 
			// 
			// 
			this.radGridView1.RootElement.EnableRippleAnimation = true;
			this.radGridView1.Size = new System.Drawing.Size(800, 575);
			this.radGridView1.TabIndex = 0;
			this.radGridView1.ThemeName = "TelerikMetroBlue";
			this.radGridView1.DoubleClick += RadGridView1_DoubleClick;
			this.radGridView1.KeyDown += RadGridView1_KeyDown;
			this.radGridView1.ContextMenuOpening += RadGridView1_ContextMenuOpening;
			this.radGridView1.SelectionChanged += RadGridView1_SelectionChanged;
			this.radGridView1.CellClick += RadGridView1_CellClick;
			this.radGridView1.GroupSummaryEvaluate += RadGridView1_GroupSummaryEvaluate;
			// 
			// panelBottomContainer
			// 
			this.panelBottomContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.panelBottomContainer.Controls.Add(this.labelTotal);
			this.panelBottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelBottomContainer.Location = new System.Drawing.Point(0, 575);
			this.panelBottomContainer.Name = "panelBottomContainer";
			this.panelBottomContainer.Size = new System.Drawing.Size(800, 25);
			this.panelBottomContainer.TabIndex = 3;
			// 
			// label1
			// 
			this.labelTotal.AutoSize = true;
			this.labelTotal.Dock = System.Windows.Forms.DockStyle.Right;
			this.labelTotal.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
			this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelTotal.Location = new System.Drawing.Point(722, 0);
			this.labelTotal.Name = "label1";
			this.labelTotal.Padding = new System.Windows.Forms.Padding(0, 5, 25, 0);
			this.labelTotal.Size = new System.Drawing.Size(78, 22);
			this.labelTotal.TabIndex = 0;
			this.labelTotal.Text = "Total:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.panel1.Controls.Add(this.radGridView1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 575);
			this.panel1.TabIndex = 5;
			// 
			// BaseGridViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelBottomContainer);
			this.Name = "BaseGridViewControl";
			this.Size = new System.Drawing.Size(800, 600);
			((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
			this.panelBottomContainer.ResumeLayout(false);
			this.panelBottomContainer.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public Telerik.WinControls.UI.RadGridView radGridView1;
		private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
		private System.Windows.Forms.Panel panelBottomContainer;
		public System.Windows.Forms.Label labelTotal;
		private System.Windows.Forms.Panel panel1;
	}
}
