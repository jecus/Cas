namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FuelControlItem
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownRemainAfter = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSpent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRemain = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownCorrenction = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownOnBoard = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.labelSpent = new System.Windows.Forms.Label();
            this.labelRemainAfter = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemainAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrenction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 6;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemainAfter, 5, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownSpent, 4, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownRemain, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.label17, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxTitle, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.label19, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownCorrenction, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownOnBoard, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.label18, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelSpent, 4, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelRemainAfter, 5, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(595, 39);
            this.tableLayoutPanelMain.TabIndex = 178;
            // 
            // numericUpDownRemainAfter
            // 
            this.numericUpDownRemainAfter.DecimalPlaces = 2;
            this.numericUpDownRemainAfter.Location = new System.Drawing.Point(496, 17);
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
            // numericUpDownSpent
            //
            this.numericUpDownSpent.DecimalPlaces = 2;
            this.numericUpDownSpent.Location = new System.Drawing.Point(397, 17);
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
            // numericUpDownRemain
            // 
            this.numericUpDownRemain.DecimalPlaces = 2;
            this.numericUpDownRemain.Location = new System.Drawing.Point(100, 17);
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
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 17);
            this.label17.TabIndex = 179;
            this.label17.Text = "Remain, KG";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(4, 17);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(92, 22);
            this.textBoxTitle.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(199, 0);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 17);
            this.label19.TabIndex = 180;
            this.label19.Text = "Refuel, KG";
            // 
            // numericUpDownCorrenction
            // 
            this.numericUpDownCorrenction.DecimalPlaces = 2;
            this.numericUpDownCorrenction.Location = new System.Drawing.Point(199, 17);
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
            this.numericUpDownOnBoard.Location = new System.Drawing.Point(298, 17);
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(298, 0);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 17);
            this.label18.TabIndex = 179;
            this.label18.Text = "On Board, KG";
            // 
            // labelSpent
            // 
            this.labelSpent.AutoSize = true;
            this.labelSpent.Location = new System.Drawing.Point(397, 0);
            this.labelSpent.Margin = new System.Windows.Forms.Padding(0);
            this.labelSpent.Name = "labelSpent";
            this.labelSpent.Size = new System.Drawing.Size(73, 17);
            this.labelSpent.TabIndex = 181;
            this.labelSpent.Text = "Spent, KG";
            // 
            // labelRemainAfter
            // 
            this.labelRemainAfter.AutoSize = true;
            this.labelRemainAfter.Location = new System.Drawing.Point(496, 0);
            this.labelRemainAfter.Margin = new System.Windows.Forms.Padding(0);
            this.labelRemainAfter.Name = "labelRemainAfter";
            this.labelRemainAfter.Size = new System.Drawing.Size(84, 17);
            this.labelRemainAfter.TabIndex = 182;
            this.labelRemainAfter.Text = "Remain, KG";
            // 
            // FuelControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FuelControlItem";
            this.Size = new System.Drawing.Size(595, 39);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemainAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRemain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCorrenction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOnBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownRemain;
        private System.Windows.Forms.NumericUpDown numericUpDownCorrenction;
        private System.Windows.Forms.NumericUpDown numericUpDownOnBoard;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.NumericUpDown numericUpDownRemainAfter;
        private System.Windows.Forms.NumericUpDown numericUpDownSpent;
        private System.Windows.Forms.Label labelSpent;
        private System.Windows.Forms.Label labelRemainAfter;
    }
}
