using CAS.UI.Helpers;

namespace CAS.UI.UIControls.Auxiliary.Importing
{
    partial class ExcelImportFileControl
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.comboBoxSheets = new System.Windows.Forms.ComboBox();
            this.labelSheet = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkBoxHeaders = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.AutoSize = true;
            this.panelControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControls.Location = new System.Drawing.Point(0, 80);
            this.panelControls.Margin = new System.Windows.Forms.Padding(0);
            this.panelControls.MinimumSize = new System.Drawing.Size(240, 120);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(240, 120);
            this.panelControls.TabIndex = 0;
            // 
            // comboBoxSheets
            // 
            this.comboBoxSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSheets.Font = new System.Drawing.Font("Verdana", 9F);
            this.comboBoxSheets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxSheets.FormattingEnabled = true;
            this.comboBoxSheets.Location = new System.Drawing.Point(126, 35);
            this.comboBoxSheets.Name = "comboBoxSheets";
            this.comboBoxSheets.Size = new System.Drawing.Size(350, 26);
            this.comboBoxSheets.TabIndex = 35;
            this.comboBoxSheets.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSheetsSelectedIndexChanged);
            this.comboBoxSheets.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelSheet
			// 
			this.labelSheet.AutoSize = true;
            this.labelSheet.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSheet.Location = new System.Drawing.Point(3, 38);
            this.labelSheet.Name = "labelSheet";
            this.labelSheet.Size = new System.Drawing.Size(117, 18);
            this.labelSheet.TabIndex = 37;
            this.labelSheet.Text = "Shoose sheet:";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelFile.Location = new System.Drawing.Point(3, 6);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(39, 18);
            this.labelFile.TabIndex = 36;
            this.labelFile.Text = "File:";
            // 
            // textBoxFile
            // 
            this.textBoxFile.BackColor = System.Drawing.Color.White;
            this.textBoxFile.Enabled = false;
            this.textBoxFile.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxFile.Location = new System.Drawing.Point(126, 3);
            this.textBoxFile.MaxLength = 200;
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(350, 26);
            this.textBoxFile.TabIndex = 34;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.Font = new System.Drawing.Font("Verdana", 9F);
            this.buttonBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonBrowse.Location = new System.Drawing.Point(482, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(87, 26);
            this.buttonBrowse.TabIndex = 38;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // checkBoxHeaders
            // 
            this.checkBoxHeaders.AutoSize = true;
            this.checkBoxHeaders.Checked = true;
            this.checkBoxHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHeaders.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxHeaders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.checkBoxHeaders.Location = new System.Drawing.Point(485, 37);
            this.checkBoxHeaders.Name = "checkBoxHeaders";
            this.checkBoxHeaders.Size = new System.Drawing.Size(228, 22);
            this.checkBoxHeaders.TabIndex = 39;
            this.checkBoxHeaders.Text = "1st Row is Column Header";
            this.checkBoxHeaders.UseVisualStyleBackColor = true;
            // 
            // ExcelImportFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.checkBoxHeaders);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.comboBoxSheets);
            this.Controls.Add(this.labelSheet);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.panelControls);
            this.MinimumSize = new System.Drawing.Size(240, 120);
            this.Name = "ExcelImportFileControl";
            this.Size = new System.Drawing.Size(716, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.ComboBox comboBoxSheets;
        private System.Windows.Forms.Label labelSheet;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkBoxHeaders;
    }
}
