using System.Windows.Forms;

namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceCheckBindTaskInWPForm
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
			this.listViewTasksForSelect = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView();
			this.listViewBindedTasks = new CAS.UI.UIControls.MaintananceProgram.MaintenanceCheckBindTaskListView();
			this.buttonDelete = new System.Windows.Forms.Button();
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
			this.buttonAdd.Location = new System.Drawing.Point(787, 744);
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
			this.buttonClose.Location = new System.Drawing.Point(919, 744);
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
			this.splitContainerMain.Size = new System.Drawing.Size(979, 670);
			this.splitContainerMain.SplitterDistance = 412;
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
			this.listViewTasksForSelect.ShowGroups = true;
			this.listViewTasksForSelect.Size = new System.Drawing.Size(979, 412);
			this.listViewTasksForSelect.TabIndex = 1;
			this.listViewTasksForSelect.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewSelectedTasksSelectedItemsChanged);
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
			this.listViewBindedTasks.ShowGroups = true;
			this.listViewBindedTasks.Size = new System.Drawing.Size(979, 254);
			this.listViewBindedTasks.TabIndex = 2;
			this.listViewBindedTasks.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewBindedTasksSelectedItemsChanged);
			// 
			// buttonDelete
			// 
			this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonDelete.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonDelete.Location = new System.Drawing.Point(696, 744);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(85, 33);
			this.buttonDelete.TabIndex = 15;
			this.buttonDelete.Text = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// MaintenanceCheckBindTaskInWPForm
			// 
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(1006, 783);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.buttonClose);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 640);
			this.Name = "MaintenanceCheckBindTaskInWPForm";
			this.ShowIcon = false;
			this.Text = "Maintenance Check Bind Task Form";
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
        private MaintenanceCheckBindTaskListView listViewTasksForSelect;
        private MaintenanceCheckBindTaskListView listViewBindedTasks;
    }
}