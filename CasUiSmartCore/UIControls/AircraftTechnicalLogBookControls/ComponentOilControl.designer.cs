using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
	partial class ComponentOilControl
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
			this.labelOnAdded = new System.Windows.Forms.Label();
			this.labelRemain = new System.Windows.Forms.Label();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.numericUpDownFlow = new System.Windows.Forms.NumericUpDown();
			this.labelFlow = new System.Windows.Forms.Label();
			this.numericUpDownRemain = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownRemainAfter = new System.Windows.Forms.NumericUpDown();
			this.labelRemainAfter = new System.Windows.Forms.Label();
			this.labelDetail = new System.Windows.Forms.Label();
			this.comboBoxDetail = new System.Windows.Forms.ComboBox();
			this.labelSpent = new System.Windows.Forms.Label();
			this.numericUpDownSpent = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownCorrenction = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownOnBoard = new System.Windows.Forms.NumericUpDown();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.tableLayoutPanelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemainAfter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrenction)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnBoard)).BeginInit();
			this.SuspendLayout();
			// 
			// labelOnAdded
			// 
			this.labelOnAdded.AutoSize = true;
			this.labelOnAdded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelOnAdded.Location = new System.Drawing.Point(161, 3);
			this.labelOnAdded.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelOnAdded.Name = "labelOnAdded";
			this.labelOnAdded.Size = new System.Drawing.Size(37, 13);
			this.labelOnAdded.TabIndex = 16;
			this.labelOnAdded.Text = "Uplift";
			// 
			// labelRemain
			// 
			this.labelRemain.AutoSize = true;
			this.labelRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemain.Location = new System.Drawing.Point(87, 3);
			this.labelRemain.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelRemain.Name = "labelRemain";
			this.labelRemain.Size = new System.Drawing.Size(49, 13);
			this.labelRemain.TabIndex = 15;
			this.labelRemain.Text = "Remain";
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.AutoSize = true;
			this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelMain.ColumnCount = 8;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownFlow, 6, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelFlow, 6, 0);
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemain, 1, 1);
			this.tableLayoutPanelMain.Controls.Add(this.label1, 3, 0);
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemainAfter, 5, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelRemainAfter, 5, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelOnAdded, 2, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelRemain, 1, 0);
			this.tableLayoutPanelMain.Controls.Add(this.labelDetail, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.comboBoxDetail, 0, 1);
			this.tableLayoutPanelMain.Controls.Add(this.labelSpent, 4, 0);
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownSpent, 4, 1);
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownCorrenction, 2, 1);
			this.tableLayoutPanelMain.Controls.Add(this.numericUpDownOnBoard, 3, 1);
			this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 7, 1);
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 2;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(571, 39);
			this.tableLayoutPanelMain.TabIndex = 177;
			// 
			// numericUpDownFlow
			// 
			this.numericUpDownFlow.DecimalPlaces = 2;
			this.numericUpDownFlow.Enabled = false;
			this.numericUpDownFlow.Location = new System.Drawing.Point(454, 16);
			this.numericUpDownFlow.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownFlow.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownFlow.Name = "numericUpDownFlow";
			this.numericUpDownFlow.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownFlow.TabIndex = 178;
			this.numericUpDownFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownFlow.ValueChanged += new System.EventHandler(this.NumericUpDownFlowValueChanged);
			// 
			// labelFlow
			// 
			this.labelFlow.AutoSize = true;
			this.labelFlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelFlow.Location = new System.Drawing.Point(457, 3);
			this.labelFlow.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelFlow.Name = "labelFlow";
			this.labelFlow.Size = new System.Drawing.Size(79, 13);
			this.labelFlow.TabIndex = 180;
			this.labelFlow.Text = "Consumption";
			// 
			// numericUpDownRemain
			// 
			this.numericUpDownRemain.DecimalPlaces = 2;
			this.numericUpDownRemain.Location = new System.Drawing.Point(84, 16);
			this.numericUpDownRemain.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownRemain.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownRemain.Name = "numericUpDownRemain";
			this.numericUpDownRemain.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownRemain.TabIndex = 2;
			this.numericUpDownRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownRemain.ValueChanged += new System.EventHandler(this.NumericUpDownRemainValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(235, 3);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 178;
			this.label1.Text = "On Board";
			// 
			// numericUpDownRemainAfter
			// 
			this.numericUpDownRemainAfter.DecimalPlaces = 2;
			this.numericUpDownRemainAfter.Location = new System.Drawing.Point(380, 16);
			this.numericUpDownRemainAfter.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownRemainAfter.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownRemainAfter.Name = "numericUpDownRemainAfter";
			this.numericUpDownRemainAfter.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownRemainAfter.TabIndex = 6;
			this.numericUpDownRemainAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownRemainAfter.ValueChanged += new System.EventHandler(this.NumericUpDownRemainAfterValueChanged);
			// 
			// labelRemainAfter
			// 
			this.labelRemainAfter.AutoSize = true;
			this.labelRemainAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelRemainAfter.Location = new System.Drawing.Point(383, 3);
			this.labelRemainAfter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelRemainAfter.Name = "labelRemainAfter";
			this.labelRemainAfter.Size = new System.Drawing.Size(49, 13);
			this.labelRemainAfter.TabIndex = 179;
			this.labelRemainAfter.Text = "Remain";
			// 
			// labelDetail
			// 
			this.labelDetail.AutoSize = true;
			this.labelDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDetail.Location = new System.Drawing.Point(3, 3);
			this.labelDetail.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelDetail.Name = "labelDetail";
			this.labelDetail.Size = new System.Drawing.Size(50, 13);
			this.labelDetail.TabIndex = 140;
			this.labelDetail.Text = "Engine:";
			// 
			// comboBoxDetail
			// 
			this.comboBoxDetail.FormattingEnabled = true;
			this.comboBoxDetail.Location = new System.Drawing.Point(3, 16);
			this.comboBoxDetail.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.comboBoxDetail.Name = "comboBoxDetail";
			this.comboBoxDetail.Size = new System.Drawing.Size(78, 21);
			this.comboBoxDetail.TabIndex = 1;
			this.comboBoxDetail.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailSelectedIndexChanged);
			this.comboBoxDetail.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelSpent
			// 
			this.labelSpent.AutoSize = true;
			this.labelSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSpent.Location = new System.Drawing.Point(309, 3);
			this.labelSpent.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.labelSpent.Name = "labelSpent";
			this.labelSpent.Size = new System.Drawing.Size(40, 13);
			this.labelSpent.TabIndex = 178;
			this.labelSpent.Text = "Spent";
			// 
			// numericUpDownSpent
			// 
			this.numericUpDownSpent.DecimalPlaces = 2;
			this.numericUpDownSpent.Location = new System.Drawing.Point(306, 16);
			this.numericUpDownSpent.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownSpent.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownSpent.Name = "numericUpDownSpent";
			this.numericUpDownSpent.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownSpent.TabIndex = 5;
			this.numericUpDownSpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownSpent.ValueChanged += new System.EventHandler(this.NumericUpDownSpentValueChanged);
			// 
			// numericUpDownCorrenction
			// 
			this.numericUpDownCorrenction.DecimalPlaces = 2;
			this.numericUpDownCorrenction.Location = new System.Drawing.Point(158, 16);
			this.numericUpDownCorrenction.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownCorrenction.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownCorrenction.Name = "numericUpDownCorrenction";
			this.numericUpDownCorrenction.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownCorrenction.TabIndex = 3;
			this.numericUpDownCorrenction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownCorrenction.ValueChanged += new System.EventHandler(this.NumericUpDownCorrenctionValueChanged);
			// 
			// numericUpDownOnBoard
			// 
			this.numericUpDownOnBoard.DecimalPlaces = 2;
			this.numericUpDownOnBoard.Enabled = false;
			this.numericUpDownOnBoard.Location = new System.Drawing.Point(232, 16);
			this.numericUpDownOnBoard.Margin = new System.Windows.Forms.Padding(0);
			this.numericUpDownOnBoard.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDownOnBoard.Name = "numericUpDownOnBoard";
			this.numericUpDownOnBoard.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownOnBoard.TabIndex = 4;
			this.numericUpDownOnBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDownOnBoard.ValueChanged += new System.EventHandler(this.NumericUpDownOnBoardValueChanged);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(542, 16);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(26, 23);
			this.buttonDelete.TabIndex = 7;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// ComponentOilControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanelMain);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ComponentOilControl";
			this.Size = new System.Drawing.Size(571, 39);
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemainAfter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrenction)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnBoard)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelOnAdded;
		private System.Windows.Forms.Label labelRemain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.Button buttonDelete;
		private System.Windows.Forms.Label labelDetail;
		private System.Windows.Forms.ComboBox comboBoxDetail;
		private System.Windows.Forms.Label labelRemainAfter;
		private System.Windows.Forms.Label labelSpent;
		private System.Windows.Forms.NumericUpDown numericUpDownSpent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownRemainAfter;
		private System.Windows.Forms.NumericUpDown numericUpDownRemain;
		private System.Windows.Forms.NumericUpDown numericUpDownCorrenction;
		private System.Windows.Forms.NumericUpDown numericUpDownOnBoard;
		private System.Windows.Forms.NumericUpDown numericUpDownFlow;
		private System.Windows.Forms.Label labelFlow;
	}
}
