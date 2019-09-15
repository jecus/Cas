namespace CAS.UI.UIControls.Auxiliary
{
	partial class TreeDictionaryComboBox
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
			if (disposing)
			{
				treeCombobox.SelectedIndexChanged -= ComboBoxReasonSelectedIndexChanged;
				treeCombobox.TextUpdate -= ComboBoxReasonTextUpdate;
				buttonEdit.Click -= ButtonEditClick;

				this.SelectedIndexChanged = null;
			}
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
			this.treeCombobox = new CAS.UI.UIControls.Auxiliary.TreeCombobox();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// comboBoxReason
			// 
			this.treeCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeCombobox.FormattingEnabled = true;
			this.treeCombobox.Location = new System.Drawing.Point(0, 0);
			this.treeCombobox.Margin = new System.Windows.Forms.Padding(0);
			this.treeCombobox.Name = "treeCombobox";
			this.treeCombobox.Size = new System.Drawing.Size(146, 21);
			this.treeCombobox.TabIndex = 0;
			this.treeCombobox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReasonSelectedIndexChanged);
			this.treeCombobox.TextUpdate += new System.EventHandler(ComboBoxReasonTextUpdate);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonEdit.Location = new System.Drawing.Point(146, 0);
			this.buttonEdit.Margin = new System.Windows.Forms.Padding(0);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(24, 20);
			this.buttonEdit.TabIndex = 1;
			this.buttonEdit.Text = "...";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.ButtonEditClick);
			// 
			// DictionaryComboBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.treeCombobox);
			this.Name = "DictionaryComboBox";
			this.Size = new System.Drawing.Size(170, 20);
			this.ResumeLayout(false);

		}

		#endregion

		private CAS.UI.UIControls.Auxiliary.TreeCombobox treeCombobox;
		private System.Windows.Forms.Button buttonEdit;
	}
}
