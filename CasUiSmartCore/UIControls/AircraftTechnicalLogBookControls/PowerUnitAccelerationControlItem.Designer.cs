using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PowerUnitAccelerationControlItem
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
            this.numericUpDownAir = new System.Windows.Forms.NumericUpDown();
            this.labelAir = new System.Windows.Forms.Label();
            this.labelFlightEngine = new System.Windows.Forms.Label();
            this.comboBoxEngine = new System.Windows.Forms.ComboBox();
            this.labelAccelerationTime = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.numericUpDownAccelerationTime = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccelerationTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownAir, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelAir, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelFlightEngine, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxEngine, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelAccelerationTime, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.numericUpDownAccelerationTime, 1, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(340, 39);
            this.tableLayoutPanelMain.TabIndex = 177;
            // 
            // numericUpDownAir
            // 
            this.numericUpDownAir.Location = new System.Drawing.Point(235, 16);
            this.numericUpDownAir.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownAir.Name = "numericUpDownAir";
            this.numericUpDownAir.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownAir.TabIndex = 184;
            this.numericUpDownAir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAir.ValueChanged += new System.EventHandler(this.NumericUpDownAirValueChanged);
            // 
            // labelAir
            // 
            this.labelAir.AutoSize = true;
            this.labelAir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAir.Location = new System.Drawing.Point(235, 0);
            this.labelAir.Name = "labelAir";
            this.labelAir.Size = new System.Drawing.Size(22, 13);
            this.labelAir.TabIndex = 179;
            this.labelAir.Text = "Air";
            // 
            // labelFlightEngine
            // 
            this.labelFlightEngine.AutoSize = true;
            this.labelFlightEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFlightEngine.Location = new System.Drawing.Point(3, 0);
            this.labelFlightEngine.Name = "labelFlightEngine";
            this.labelFlightEngine.Size = new System.Drawing.Size(50, 13);
            this.labelFlightEngine.TabIndex = 140;
            this.labelFlightEngine.Text = "Engine:";
            // 
            // comboBoxEngine
            // 
            this.comboBoxEngine.FormattingEnabled = true;
            this.comboBoxEngine.Location = new System.Drawing.Point(3, 13);
            this.comboBoxEngine.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.comboBoxEngine.Name = "comboBoxEngine";
            this.comboBoxEngine.Size = new System.Drawing.Size(150, 21);
            this.comboBoxEngine.TabIndex = 141;
            this.comboBoxEngine.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEngineSelectedIndexChanged);
            this.comboBoxEngine.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelAccelerationTime
			// 
			this.labelAccelerationTime.AutoSize = true;
            this.labelAccelerationTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccelerationTime.Location = new System.Drawing.Point(159, 0);
            this.labelAccelerationTime.Name = "labelAccelerationTime";
            this.labelAccelerationTime.Size = new System.Drawing.Size(48, 13);
            this.labelAccelerationTime.TabIndex = 178;
            this.labelAccelerationTime.Text = "Ground";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(311, 13);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(26, 23);
            this.buttonDelete.TabIndex = 177;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // numericUpDownAccelerationTime
            // 
            this.numericUpDownAccelerationTime.Location = new System.Drawing.Point(159, 16);
            this.numericUpDownAccelerationTime.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericUpDownAccelerationTime.Name = "numericUpDownAccelerationTime";
            this.numericUpDownAccelerationTime.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownAccelerationTime.TabIndex = 183;
            this.numericUpDownAccelerationTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownAccelerationTime.ValueChanged += new System.EventHandler(this.NumericUpDownTimeInRegimeValueChanged);
            // 
            // PowerUnitAccelerationControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Name = "PowerUnitAccelerationControlItem";
            this.Size = new System.Drawing.Size(346, 42);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccelerationTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelFlightEngine;
        private System.Windows.Forms.ComboBox comboBoxEngine;
        private System.Windows.Forms.Label labelAccelerationTime;
        private System.Windows.Forms.NumericUpDown numericUpDownAccelerationTime;
        private System.Windows.Forms.NumericUpDown numericUpDownAir;
        private System.Windows.Forms.Label labelAir;
    }
}
