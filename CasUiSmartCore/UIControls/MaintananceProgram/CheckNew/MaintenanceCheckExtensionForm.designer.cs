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
			this.buttonClose.Location = new System.Drawing.Point(845, 557);
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
			this.labelInterval.Location = new System.Drawing.Point(14, 57);
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
			this.checkBoxSelectAll.Location = new System.Drawing.Point(84, 61);
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
			this.checkedListBoxItems.Location = new System.Drawing.Point(14, 82);
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
			this.buttonApply.Location = new System.Drawing.Point(511, 108);
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
			this.listViewTasksForSelect.Location = new System.Drawing.Point(14, 197);
			this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
			this.listViewTasksForSelect.MenuOpeningAction = null;
			this.listViewTasksForSelect.Name = "listViewTasksForSelect";
			this.listViewTasksForSelect.OldColumnIndex = 1;
			this.listViewTasksForSelect.PasteComplete = null;
			this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(908, 344);
			this.listViewTasksForSelect.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
			this.listViewTasksForSelect.TabIndex = 1;
			// 
			// numericUpDownExtension
			// 
			this.numericUpDownExtension.DecimalPlaces = 2;
			this.numericUpDownExtension.Location = new System.Drawing.Point(511, 82);
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
			this.labelExtension.Location = new System.Drawing.Point(415, 82);
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.Size = new System.Drawing.Size(90, 19);
			this.labelExtension.TabIndex = 252;
			this.labelExtension.Text = "Extensions % :";
			this.labelExtension.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaintenanceCheckExtensionForm
			// 
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(932, 596);
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
	}
}