namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class HydraulicControl
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
            this.numericUpDownRemain = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownRemainAfter = new System.Windows.Forms.NumericUpDown();
            this.labelRemainAfter = new System.Windows.Forms.Label();
            this.labelDetail = new System.Windows.Forms.Label();
            this.textBoxHydraulicSystem = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelSpent = new System.Windows.Forms.Label();
            this.numericUpDownSpent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCorrenction = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOnBoard = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelMain.SuspendLayout();
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
            this.labelOnAdded.Location = new System.Drawing.Point(214, 4);
            this.labelOnAdded.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelOnAdded.Name = "labelOnAdded";
            this.labelOnAdded.Size = new System.Drawing.Size(54, 17);
            this.labelOnAdded.TabIndex = 16;
            this.labelOnAdded.Text = "Added";
            // 
            // labelRemain
            // 
            this.labelRemain.AutoSize = true;
            this.labelRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemain.Location = new System.Drawing.Point(115, 4);
            this.labelRemain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelRemain.Name = "labelRemain";
            this.labelRemain.Size = new System.Drawing.Size(62, 17);
            this.labelRemain.TabIndex = 15;
            this.labelRemain.Text = "Remain";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 7;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemain, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemainAfter, 5, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelRemainAfter, 5, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelOnAdded, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelRemain, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelDetail, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxHydraulicSystem, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 6, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelSpent, 4, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownSpent, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownCorrenction, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownOnBoard, 3, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(649, 49);
            this.tableLayoutPanelMain.TabIndex = 177;
            // 
            // numericUpDownRemain
            // 
            this.numericUpDownRemain.DecimalPlaces = 2;
            this.numericUpDownRemain.Location = new System.Drawing.Point(111, 21);
            this.numericUpDownRemain.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownRemain.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRemain.Name = "numericUpDownRemain";
            this.numericUpDownRemain.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownRemain.TabIndex = 2;
            this.numericUpDownRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownRemain.ValueChanged += new System.EventHandler(this.NumericUpDownRemainValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(313, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 178;
            this.label1.Text = "On Board";
            // 
            // numericUpDownRemainAfter
            // 
            this.numericUpDownRemainAfter.DecimalPlaces = 2;
            this.numericUpDownRemainAfter.Location = new System.Drawing.Point(507, 21);
            this.numericUpDownRemainAfter.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownRemainAfter.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRemainAfter.Name = "numericUpDownRemainAfter";
            this.numericUpDownRemainAfter.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownRemainAfter.TabIndex = 6;
            this.numericUpDownRemainAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownRemainAfter.ValueChanged += new System.EventHandler(this.NumericUpDownRemainAfterValueChanged);
            // 
            // labelRemainAfter
            // 
            this.labelRemainAfter.AutoSize = true;
            this.labelRemainAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemainAfter.Location = new System.Drawing.Point(511, 4);
            this.labelRemainAfter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelRemainAfter.Name = "labelRemainAfter";
            this.labelRemainAfter.Size = new System.Drawing.Size(62, 17);
            this.labelRemainAfter.TabIndex = 179;
            this.labelRemainAfter.Text = "Remain";
            // 
            // labelDetail
            // 
            this.labelDetail.AutoSize = true;
            this.labelDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDetail.Location = new System.Drawing.Point(4, 4);
            this.labelDetail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(55, 17);
            this.labelDetail.TabIndex = 140;
            this.labelDetail.Text = "Detail:";
            // 
            // textBoxHydraulicSystem
            // 
            this.textBoxHydraulicSystem.Location = new System.Drawing.Point(4, 21);
            this.textBoxHydraulicSystem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxHydraulicSystem.Name = "textBoxHydraulicSystem";
            this.textBoxHydraulicSystem.Size = new System.Drawing.Size(103, 24);
            this.textBoxHydraulicSystem.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(610, 21);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelSpent
            // 
            this.labelSpent.AutoSize = true;
            this.labelSpent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpent.Location = new System.Drawing.Point(412, 4);
            this.labelSpent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.labelSpent.Name = "labelSpent";
            this.labelSpent.Size = new System.Drawing.Size(50, 17);
            this.labelSpent.TabIndex = 178;
            this.labelSpent.Text = "Spent";
            // 
            // numericUpDownSpent
            // 
            this.numericUpDownSpent.DecimalPlaces = 2;
            this.numericUpDownSpent.Location = new System.Drawing.Point(408, 21);
            this.numericUpDownSpent.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownSpent.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownSpent.Name = "numericUpDownSpent";
            this.numericUpDownSpent.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownSpent.TabIndex = 5;
            this.numericUpDownSpent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSpent.ValueChanged += new System.EventHandler(this.NumericUpDownSpentValueChanged);
            // 
            // numericUpDownCorrenction
            // 
            this.numericUpDownCorrenction.DecimalPlaces = 2;
            this.numericUpDownCorrenction.Location = new System.Drawing.Point(210, 21);
            this.numericUpDownCorrenction.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownCorrenction.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCorrenction.Name = "numericUpDownCorrenction";
            this.numericUpDownCorrenction.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownCorrenction.TabIndex = 3;
            this.numericUpDownCorrenction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownCorrenction.ValueChanged += new System.EventHandler(this.NumericUpDownCorrenctionValueChanged);
            // 
            // numericUpDownOnBoard
            // 
            this.numericUpDownOnBoard.DecimalPlaces = 2;
            this.numericUpDownOnBoard.Enabled = false;
            this.numericUpDownOnBoard.Location = new System.Drawing.Point(309, 21);
            this.numericUpDownOnBoard.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownOnBoard.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOnBoard.Name = "numericUpDownOnBoard";
            this.numericUpDownOnBoard.Size = new System.Drawing.Size(99, 22);
            this.numericUpDownOnBoard.TabIndex = 4;
            this.numericUpDownOnBoard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownOnBoard.ValueChanged += new System.EventHandler(this.NumericUpDownOnBoardValueChanged);
            // 
            // ComponentOilControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HydraulicControl";
            this.Size = new System.Drawing.Size(649, 49);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxHydraulicSystem;
        private System.Windows.Forms.Label labelRemainAfter;
        private System.Windows.Forms.Label labelSpent;
        private System.Windows.Forms.NumericUpDown numericUpDownSpent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownRemainAfter;
        private System.Windows.Forms.NumericUpDown numericUpDownRemain;
        private System.Windows.Forms.NumericUpDown numericUpDownCorrenction;
        private System.Windows.Forms.NumericUpDown numericUpDownOnBoard;
    }
}
