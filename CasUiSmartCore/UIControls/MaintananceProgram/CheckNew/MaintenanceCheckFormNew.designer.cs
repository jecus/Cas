using System.Windows.Forms;
using MetroFramework.Controls;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
	partial class MaintenanceCheckFormNew
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
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.listViewTasksForSelect = new CAS.UI.UIControls.MaintananceProgram.MaintenanceDirectiveLightListView();
			this.listViewBindedTasks = new CAS.UI.UIControls.MaintananceProgram.MaintenanceDirectiveLightListView();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.labelInterval = new MetroFramework.Controls.MetroLabel();
			this.checkBoxSelectAll = new MetroFramework.Controls.MetroCheckBox();
			this.checkedListBoxItems = new System.Windows.Forms.CheckedListBox();
			this.deleteButton = new AvControls.AvButtonT.AvButtonT();
			this.addButton = new AvControls.AvButtonT.AvButtonT();
			this.editButton = new AvControls.AvButtonT.AvButtonT();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonApply = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonAdd.Location = new System.Drawing.Point(787, 759);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(126, 33);
			this.buttonAdd.TabIndex = 12;
			this.buttonAdd.Text = "Add to Check";
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(919, 759);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 33);
			this.buttonClose.TabIndex = 13;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerMain.Location = new System.Drawing.Point(14, 196);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.listViewTasksForSelect);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.AutoScroll = true;
			this.splitContainerMain.Panel2.Controls.Add(this.listViewBindedTasks);
			this.splitContainerMain.Size = new System.Drawing.Size(979, 550);
			this.splitContainerMain.SplitterDistance = 344;
			this.splitContainerMain.TabIndex = 14;
			// 
			// listViewTasksForSelect
			// 
			this.listViewTasksForSelect.Displayer = null;
			this.listViewTasksForSelect.DisplayerText = null;
			this.listViewTasksForSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewTasksForSelect.Entity = null;
			this.listViewTasksForSelect.Location = new System.Drawing.Point(0, 0);
			this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
			this.listViewTasksForSelect.Name = "listViewTasksForSelect";
			this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(979, 344);
			this.listViewTasksForSelect.TabIndex = 1; 
			// 
			// listViewBindedTasks
			// 
			this.listViewBindedTasks.Displayer = null;
			this.listViewBindedTasks.DisplayerText = null;
			this.listViewBindedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewBindedTasks.Entity = null;
			this.listViewBindedTasks.Location = new System.Drawing.Point(0, 0);
			this.listViewBindedTasks.Margin = new System.Windows.Forms.Padding(4);
			this.listViewBindedTasks.Name = "listViewBindedTasks";
			this.listViewBindedTasks.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewBindedTasks.Size = new System.Drawing.Size(979, 202);
			this.listViewBindedTasks.TabIndex = 2;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(696, 759);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 15;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
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
			// deleteButton
			// 
			this.deleteButton.ActiveBackColor = System.Drawing.Color.Transparent;
			this.deleteButton.ActiveBackgroundImage = null;
			this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.deleteButton.Enabled = false;
			this.deleteButton.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.deleteButton.FontSecondary = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.deleteButton.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.deleteButton.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.deleteButton.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.deleteButton.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.deleteButton.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.deleteButton.Location = new System.Drawing.Point(540, 63);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.NormalBackgroundImage = null;
			this.deleteButton.PaddingMain = new System.Windows.Forms.Padding(0);
			this.deleteButton.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.deleteButton.ShowToolTip = false;
			this.deleteButton.Size = new System.Drawing.Size(50, 54);
			this.deleteButton.TabIndex = 26;
			this.deleteButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.deleteButton.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.deleteButton.TextMain = "";
			this.deleteButton.TextSecondary = "";
			this.deleteButton.ToolTipText = "";
			this.deleteButton.Click += DeleteButton_Click;
			// 
			// addButton
			// 
			this.addButton.ActiveBackColor = System.Drawing.Color.Transparent;
			this.addButton.ActiveBackgroundImage = null;
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.addButton.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.addButton.FontSecondary = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.addButton.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.addButton.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.addButton.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.addButton.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.addButton.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
			this.addButton.Location = new System.Drawing.Point(426, 63);
			this.addButton.Name = "addButton";
			this.addButton.NormalBackgroundImage = null;
			this.addButton.PaddingMain = new System.Windows.Forms.Padding(0);
			this.addButton.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.addButton.ShowToolTip = false;
			this.addButton.Size = new System.Drawing.Size(52, 54);
			this.addButton.TabIndex = 25;
			this.addButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.addButton.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.addButton.TextMain = "";
			this.addButton.TextSecondary = "";
			this.addButton.ToolTipText = "";
			this.addButton.Click += AddButton_Click;
			// 
			// editButton
			// 
			this.editButton.ActiveBackColor = System.Drawing.Color.Transparent;
			this.editButton.ActiveBackgroundImage = null;
			this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.editButton.Enabled = false;
			this.editButton.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.editButton.FontSecondary = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.editButton.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.editButton.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.editButton.Icon = global::CAS.UI.Properties.Resources.EditIcon;
			this.editButton.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.editButton.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
			this.editButton.Location = new System.Drawing.Point(484, 63);
			this.editButton.Name = "editButton";
			this.editButton.NormalBackgroundImage = null;
			this.editButton.PaddingMain = new System.Windows.Forms.Padding(0);
			this.editButton.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.editButton.ShowToolTip = false;
			this.editButton.Size = new System.Drawing.Size(50, 54);
			this.editButton.TabIndex = 27;
			this.editButton.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.editButton.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.editButton.TextMain = "";
			this.editButton.TextSecondary = "";
			this.editButton.ToolTipText = "";
			this.editButton.Click += EditButton_Click;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(426, 124);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(164, 21);
			this.comboBox1.TabIndex = 28;
			this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
			// 
			// buttonApply
			// 
			this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonApply.Enabled = true;
			this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonApply.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonApply.Location = new System.Drawing.Point(515, 156);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 33);
			this.buttonApply.TabIndex = 250;
			this.buttonApply.Text = "Apply";
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// LDNDCheckFormNew
			// 
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(1006, 798);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.editButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.checkBoxSelectAll);
			this.Controls.Add(this.labelInterval);
			this.Controls.Add(this.checkedListBoxItems);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonClose);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 640);
			this.Name = "LDNDCheckFormNew";
			this.Resizable = false;
			this.ShowIcon = false;
			this.Text = "Maintenance Check Bind Task Form";
			this.Load += new System.EventHandler(this.LDNDCheckFormNewLoad);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SplitContainer splitContainerMain;
		private Button buttonAdd;
		private Button buttonClose;
		private Button buttonDelete;
		private MaintenanceDirectiveLightListView listViewTasksForSelect;
		private MaintenanceDirectiveLightListView listViewBindedTasks;
		private MetroLabel labelInterval;
		private MetroCheckBox checkBoxSelectAll;
		private CheckedListBox checkedListBoxItems;
		public AvControls.AvButtonT.AvButtonT deleteButton;
		public AvControls.AvButtonT.AvButtonT addButton;
		public AvControls.AvButtonT.AvButtonT editButton;
		private ComboBox comboBox1;
		private Button buttonApply;
	}
}