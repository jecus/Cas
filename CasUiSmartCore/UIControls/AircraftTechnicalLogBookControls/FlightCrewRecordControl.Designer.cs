using CAS.UI.Helpers;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class FlightCrewRecordControl
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
            this.comboSpecialization = new System.Windows.Forms.ComboBox();
            this.labelSpecialization = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelSpecialist = new System.Windows.Forms.Label();
            this.comboSpecialist = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboSpecialization
            // 
            this.comboSpecialization.FormattingEnabled = true;
            this.comboSpecialization.Location = new System.Drawing.Point(4, 19);
            this.comboSpecialization.Margin = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.comboSpecialization.Name = "comboSpecialization";
            this.comboSpecialization.Size = new System.Drawing.Size(200, 24);
            this.comboSpecialization.TabIndex = 3;
            this.comboSpecialization.SelectedIndexChanged += new System.EventHandler(this.ComboSpecializationSelectedIndexChanged);
            this.comboSpecialization.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelSpecialization
			// 
			this.labelSpecialization.AutoSize = true;
            this.labelSpecialization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpecialization.Location = new System.Drawing.Point(4, 0);
            this.labelSpecialization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecialization.Name = "labelSpecialization";
            this.labelSpecialization.Size = new System.Drawing.Size(95, 17);
            this.labelSpecialization.TabIndex = 0;
            this.labelSpecialization.Text = "Occupation:";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelSpecialization, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboSpecialization, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelSpecialist, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.comboSpecialist, 1, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 4);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(459, 47);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(420, 17);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(35, 28);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelSpecialist
            // 
            this.labelSpecialist.AutoSize = true;
            this.labelSpecialist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpecialist.Location = new System.Drawing.Point(212, 0);
            this.labelSpecialist.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecialist.Name = "labelSpecialist";
            this.labelSpecialist.Size = new System.Drawing.Size(70, 17);
            this.labelSpecialist.TabIndex = 0;
            this.labelSpecialist.Text = "Member:";
            // 
            // comboSpecialist
            // 
            this.comboSpecialist.FormattingEnabled = true;
            this.comboSpecialist.Location = new System.Drawing.Point(212, 19);
            this.comboSpecialist.Margin = new System.Windows.Forms.Padding(4, 2, 4, 4);
            this.comboSpecialist.Name = "comboSpecialist";
            this.comboSpecialist.Size = new System.Drawing.Size(200, 24);
            this.comboSpecialist.TabIndex = 4;
            this.comboSpecialist.SelectedIndexChanged += new System.EventHandler(this.ComboSpecialistSelectedIndexChanged);
            this.comboSpecialist.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// FlightCrewRecordControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FlightCrewRecordControl";
            this.Size = new System.Drawing.Size(463, 51);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboSpecialization;
        private System.Windows.Forms.Label labelSpecialization;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ComboBox comboSpecialist;
        private System.Windows.Forms.Label labelSpecialist;
        private System.Windows.Forms.Button buttonDelete;
    }
}
