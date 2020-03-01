using System.Windows.Forms;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
	partial class MaintenanceCheckExtensionForm
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
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelInterval = new MetroFramework.Controls.MetroLabel();
			this.checkBoxSelectAll = new MetroFramework.Controls.MetroCheckBox();
			this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
			this.buttonApply = new System.Windows.Forms.Button();
			this.listViewTasksForSelect = new CAS.UI.UIControls.MaintananceProgram.MaintenanceDirectiveLightListView();
			this.numericUpDownExtension = new System.Windows.Forms.NumericUpDown();
			this.labelExtension = new MetroFramework.Controls.MetroLabel();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonAddDoc = new System.Windows.Forms.Button();
			this.metroLabelSearch = new MetroFramework.Controls.MetroLabel();
			this.textBoxSearch = new MetroFramework.Controls.MetroTextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtension)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(1255, 557);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 13;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// labelInterval
			// 
			this.labelInterval.AutoSize = true;
			this.labelInterval.ForeColor = System.Drawing.Color.Black;
			this.labelInterval.Location = new System.Drawing.Point(17, 89);
			this.labelInterval.Name = "labelInterval";
			this.labelInterval.Size = new System.Drawing.Size(52, 19);
			this.labelInterval.TabIndex = 21;
			this.labelInterval.Text = "Interval";
			// 
			// checkBoxSelectAll
			// 
			this.checkBoxSelectAll.AutoSize = true;
			this.checkBoxSelectAll.Checked = true;
			this.checkBoxSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxSelectAll.Location = new System.Drawing.Point(87, 93);
			this.checkBoxSelectAll.Margin = new System.Windows.Forms.Padding(2);
			this.checkBoxSelectAll.Name = "checkBoxSelectAll";
			this.checkBoxSelectAll.Size = new System.Drawing.Size(69, 15);
			this.checkBoxSelectAll.TabIndex = 22;
			this.checkBoxSelectAll.Text = "Select all";
			this.checkBoxSelectAll.UseSelectable = true;
			this.checkBoxSelectAll.CheckedChanged += new System.EventHandler(this.CheckBoxSelectAllCheckedChanged);
			// 
			// checkedListBoxItems
			// 
			this.checkedListBoxItems.CheckOnClick = true;
			this.checkedListBoxItems.FormattingEnabled = true;
			this.checkedListBoxItems.Location = new System.Drawing.Point(17, 114);
			this.checkedListBoxItems.Margin = new System.Windows.Forms.Padding(2);
			this.checkedListBoxItems.Name = "checkedListBoxItems";
			this.checkedListBoxItems.Size = new System.Drawing.Size(396, 109);
			this.checkedListBoxItems.TabIndex = 23;
			this.checkedListBoxItems.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxItemsSelectedIndexChanged);
			// 
			// buttonApply
			// 
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonApply.Location = new System.Drawing.Point(514, 140);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 33);
			this.buttonApply.TabIndex = 250;
			this.buttonApply.Text = "Apply";
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// listViewTasksForSelect
			// 
			this.listViewTasksForSelect.ConfigurePaste = null;
			this.listViewTasksForSelect.Displayer = null;
			this.listViewTasksForSelect.DisplayerText = null;
			this.listViewTasksForSelect.EnableCustomSorting = true;
			this.listViewTasksForSelect.Entity = null;
			this.listViewTasksForSelect.IgnoreEnterPress = false;
			this.listViewTasksForSelect.Location = new System.Drawing.Point(17, 229);
			this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
			this.listViewTasksForSelect.MenuOpeningAction = null;
			this.listViewTasksForSelect.Name = "listViewTasksForSelect";
			this.listViewTasksForSelect.OldColumnIndex = 1;
			this.listViewTasksForSelect.PasteComplete = null;
			this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(1316, 312);
			this.listViewTasksForSelect.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
			this.listViewTasksForSelect.TabIndex = 1;
			this.listViewTasksForSelect.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.listViewTasksForSelect_SelectedItemsChanged);
			// 
			// numericUpDownExtension
			// 
			this.numericUpDownExtension.Location = new System.Drawing.Point(514, 114);
			this.numericUpDownExtension.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.numericUpDownExtension.Name = "numericUpDownExtension";
			this.numericUpDownExtension.Size = new System.Drawing.Size(75, 20);
			this.numericUpDownExtension.TabIndex = 251;
			// 
			// labelExtension
			// 
			this.labelExtension.AutoSize = true;
			this.labelExtension.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelExtension.Location = new System.Drawing.Point(418, 114);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(85, 19);
			this.labelExtension.TabIndex = 252;
			this.labelExtension.Text = "Extension % :";
			this.labelExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonReset
			// 
			this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReset.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonReset.Location = new System.Drawing.Point(514, 179);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(75, 33);
			this.buttonReset.TabIndex = 253;
			this.buttonReset.Text = "Reset";
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonAddDoc
			// 
			this.buttonAddDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddDoc.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAddDoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAddDoc.Location = new System.Drawing.Point(418, 140);
			this.buttonAddDoc.Name = "buttonAddDoc";
			this.buttonAddDoc.Size = new System.Drawing.Size(90, 72);
			this.buttonAddDoc.TabIndex = 254;
			this.buttonAddDoc.Text = "Add Document";
			this.buttonAddDoc.Click += new System.EventHandler(this.buttonAddDoc_Click);
			// 
			// metroLabelSearch
			// 
			this.metroLabelSearch.AutoSize = true;
			this.metroLabelSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.metroLabelSearch.Location = new System.Drawing.Point(17, 60);
			this.metroLabelSearch.Name = "metroLabelSearch";
			this.metroLabelSearch.Size = new System.Drawing.Size(55, 19);
			this.metroLabelSearch.TabIndex = 255;
			this.metroLabelSearch.Text = "Search :";
			this.metroLabelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSearch
			// 
			// 
			// 
			// 
			this.textBoxSearch.CustomButton.Image = null;
			this.textBoxSearch.CustomButton.Location = new System.Drawing.Point(317, 2);
			this.textBoxSearch.CustomButton.Name = "";
			this.textBoxSearch.CustomButton.Size = new System.Drawing.Size(15, 15);
			this.textBoxSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
			this.textBoxSearch.CustomButton.TabIndex = 1;
			this.textBoxSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
			this.textBoxSearch.CustomButton.UseSelectable = true;
			this.textBoxSearch.CustomButton.Visible = false;
			this.textBoxSearch.ForeColor = System.Drawing.Color.DimGray;
			this.textBoxSearch.Lines = new string[0];
			this.textBoxSearch.Location = new System.Drawing.Point(78, 59);
			this.textBoxSearch.MaxLength = 32767;
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.PasswordChar = '\0';
			this.textBoxSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.textBoxSearch.SelectedText = "";
			this.textBoxSearch.SelectionLength = 0;
			this.textBoxSearch.SelectionStart = 0;
			this.textBoxSearch.ShortcutsEnabled = true;
			this.textBoxSearch.Size = new System.Drawing.Size(335, 20);
			this.textBoxSearch.TabIndex = 256;
			this.textBoxSearch.UseSelectable = true;
			this.textBoxSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
			this.textBoxSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
			// 
			// MaintenanceCheckExtensionForm
			// 
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(1342, 596);
			this.Controls.Add(this.textBoxSearch);
			this.Controls.Add(this.metroLabelSearch);
			this.Controls.Add(this.buttonAddDoc);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.numericUpDownExtension);
			this.Controls.Add(this.labelExtension);
			this.Controls.Add(this.listViewTasksForSelect);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.checkBoxSelectAll);
			this.Controls.Add(this.labelInterval);
			this.Controls.Add(this.checkedListBoxItems);
			this.Controls.Add(this.buttonClose);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "MaintenanceCheckExtensionForm";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Extension Form";
			this.Load += new System.EventHandler(this.LDNDCheckFormNewLoad);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtension)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Button buttonClose;
		private MetroLabel labelInterval;
		private MetroCheckBox checkBoxSelectAll;
		private CheckedListBox checkedListBoxItems;
		private Button buttonApply;
		private MaintenanceDirectiveLightListView listViewTasksForSelect;
		private NumericUpDown numericUpDownExtension;
		private MetroLabel labelExtension;
		private Button buttonReset;
		private Button buttonAddDoc;
		private MetroLabel metroLabelSearch;
		private MetroTextBox textBoxSearch;
	}
}