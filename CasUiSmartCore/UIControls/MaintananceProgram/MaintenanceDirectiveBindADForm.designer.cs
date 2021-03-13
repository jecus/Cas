using System.Windows.Forms;
using CAS.UI.UIControls.DirectivesControls;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.MaintananceProgram
{
	partial class MaintenanceDirectiveBindADForm
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
			this.listViewTasksForSelect = new PrimeDirectiveListView(DirectiveType.AirworthenessDirectives);
			this.listViewBindedTasks = new PrimeDirectiveListView(DirectiveType.AirworthenessDirectives);
			this.comboBoxRelationType = new System.Windows.Forms.ComboBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
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
			this.buttonAdd.Location = new System.Drawing.Point(769, 738);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(144, 33);
			this.buttonAdd.TabIndex = 12;
			this.buttonAdd.Text = "Add to Directive";
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClose.Location = new System.Drawing.Point(919, 738);
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
			this.splitContainerMain.Location = new System.Drawing.Point(15, 63);
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
			this.splitContainerMain.Size = new System.Drawing.Size(979, 666);
			this.splitContainerMain.SplitterDistance = 392;
			this.splitContainerMain.TabIndex = 14;
			// 
			// listViewTasksForSelect
			// 
			this.listViewTasksForSelect.ConfigurePaste = null;
			this.listViewTasksForSelect.Displayer = null;
			this.listViewTasksForSelect.DisplayerText = null;
			this.listViewTasksForSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewTasksForSelect.EnableCustomSorting = true;
			this.listViewTasksForSelect.Entity = null;
			this.listViewTasksForSelect.IgnoreEnterPress = false;
			this.listViewTasksForSelect.Location = new System.Drawing.Point(0, 0);
			this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
			this.listViewTasksForSelect.MenuOpeningAction = null;
			this.listViewTasksForSelect.Name = "listViewTasksForSelect";
			this.listViewTasksForSelect.OldColumnIndex = 1;
			this.listViewTasksForSelect.PasteComplete = null;
			this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(979, 392);
			this.listViewTasksForSelect.TabIndex = 1;
			this.listViewTasksForSelect.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewSelectedTasksSelectedItemsChanged);
			// 
			// listViewBindedTasks
			// 
			this.listViewBindedTasks.ConfigurePaste = null;
			this.listViewBindedTasks.Displayer = null;
			this.listViewBindedTasks.DisplayerText = null;
			this.listViewBindedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewBindedTasks.EnableCustomSorting = true;
			this.listViewBindedTasks.Entity = null;
			this.listViewBindedTasks.IgnoreEnterPress = false;
			this.listViewBindedTasks.Location = new System.Drawing.Point(0, 0);
			this.listViewBindedTasks.Margin = new System.Windows.Forms.Padding(4);
			this.listViewBindedTasks.MenuOpeningAction = null;
			this.listViewBindedTasks.Name = "listViewBindedTasks";
			this.listViewBindedTasks.OldColumnIndex = 1;
			this.listViewBindedTasks.PasteComplete = null;
			this.listViewBindedTasks.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.listViewBindedTasks.Size = new System.Drawing.Size(979, 270);
			this.listViewBindedTasks.TabIndex = 2;
			this.listViewBindedTasks.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewBindedTasksSelectedItemsChanged);
			// 
			// comboBoxRelationType
			// 
			this.comboBoxRelationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxRelationType.BackColor = System.Drawing.Color.White;
			this.comboBoxRelationType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxRelationType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxRelationType.FormattingEnabled = true;
			this.comboBoxRelationType.Location = new System.Drawing.Point(385, 745);
			this.comboBoxRelationType.Name = "comboBoxRelationType";
			this.comboBoxRelationType.Size = new System.Drawing.Size(196, 22);
			this.comboBoxRelationType.TabIndex = 16;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(678, 738);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 15;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOk.Location = new System.Drawing.Point(587, 738);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(85, 33);
			this.buttonOk.TabIndex = 17;
			this.buttonOk.Text = "Ok";
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// DirectiveBindMPDForm
			// 
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(1006, 777);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.comboBoxRelationType);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonClose);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 640);
			this.Name = "DirectiveBindMPDForm";
			this.ShowIcon = false;
			this.Text = "Directive Bind Mpds Form";
			this.Activated += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Activated);
			this.Deactivate += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Deactivate);
			this.Load += new System.EventHandler(this.MaintenanceCheckBindTaskFormLoad);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private SplitContainer splitContainerMain;
		private Button buttonAdd;
		private Button buttonClose;
		private Button buttonDelete;
		private PrimeDirectiveListView listViewTasksForSelect;
		private PrimeDirectiveListView listViewBindedTasks;
		private ComboBox comboBoxRelationType;
		private Button buttonOk;
	}
}