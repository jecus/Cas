using CAS.UI.Helpers;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    partial class ProcedureDocRefControl
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
            this.labelDocumentRef = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelDocFile = new System.Windows.Forms.Label();
            this.attachedFileControl = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.comboBoxDocument = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDocumentRef
            // 
            this.labelDocumentRef.AutoSize = true;
            this.labelDocumentRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocumentRef.Location = new System.Drawing.Point(3, 0);
            this.labelDocumentRef.Name = "labelDocumentRef";
            this.labelDocumentRef.Size = new System.Drawing.Size(39, 13);
            this.labelDocumentRef.TabIndex = 0;
            this.labelDocumentRef.Text = "Name";
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelDocumentRef, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelDocFile, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.attachedFileControl, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxDocument, 0, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(697, 84);
            this.tableLayoutPanelMain.TabIndex = 176;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(668, 13);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(26, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // labelDocFile
            // 
            this.labelDocFile.AutoSize = true;
            this.labelDocFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDocFile.Location = new System.Drawing.Point(312, 0);
            this.labelDocFile.Name = "labelDocFile";
            this.labelDocFile.Size = new System.Drawing.Size(31, 13);
            this.labelDocFile.TabIndex = 0;
            this.labelDocFile.Text = "File:";
            // 
            // attachedFileControl
            // 
            this.attachedFileControl.AutoSize = true;
            this.attachedFileControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attachedFileControl.Description1 = "This record does not contain a file proving the Document. Enclose PDF file to pro" +
    "ve the Document.";
            this.attachedFileControl.Description2 = "Attached file proves the Document.";
            this.attachedFileControl.Filter = "Adobe PDF Files|*.pdf";
            this.attachedFileControl.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.attachedFileControl.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
            this.attachedFileControl.Location = new System.Drawing.Point(312, 16);
            this.attachedFileControl.MaximumSize = new System.Drawing.Size(350, 75);
            this.attachedFileControl.MinimumSize = new System.Drawing.Size(350, 25);
            this.attachedFileControl.Name = "attachedFileControl";
            this.attachedFileControl.ShowLinkLabelBrowse = false;
            this.attachedFileControl.ShowLinkLabelRemove = false;
            this.attachedFileControl.Size = new System.Drawing.Size(350, 65);
            this.attachedFileControl.TabIndex = 8;
            // 
            // comboBoxDocument
            // 
            this.comboBoxDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDocument.Location = new System.Drawing.Point(4, 17);
            this.comboBoxDocument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxDocument.Name = "comboBoxDocument";
            this.comboBoxDocument.Size = new System.Drawing.Size(301, 21);
            this.comboBoxDocument.TabIndex = 7;
            this.comboBoxDocument.SelectedIndexChanged += new System.EventHandler(this.DictionaryComboBoxModuleSelectedIndexChanged);
            this.comboBoxDocument.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// ProcedureDocRefControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProcedureDocRefControl";
            this.Size = new System.Drawing.Size(700, 87);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDocumentRef;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelDocFile;
        private System.Windows.Forms.ComboBox comboBoxDocument;
        private Auxiliary.AttachedFileControl attachedFileControl;
    }
}
