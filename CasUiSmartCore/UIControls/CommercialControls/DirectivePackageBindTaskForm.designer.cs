using System.Windows.Forms;
using CAS.UI.UIControls.MaintananceProgram;

namespace CAS.UI.UIControls.CommercialControls
{
    partial class DirectivePackageBindTaskForm
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
            if (disposing)
            {
                if (_animatedThreadWorker != null)
                {
                    if (_animatedThreadWorker.IsBusy)
                    {
                        _animatedThreadWorker.CancelAsync();
                    }
                    _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
                    _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
                }
            }
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
            this.listViewTasksForSelect = new CAS.UI.UIControls.CommercialControls.DirectivePackageBindTaskListView();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonAdd.Location = new System.Drawing.Point(838, 684);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 33);
            this.buttonAdd.TabIndex = 12;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonClose.Location = new System.Drawing.Point(919, 684);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 33);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // listViewTasksForSelect
            // 
            this.listViewTasksForSelect.Displayer = null;
            this.listViewTasksForSelect.DisplayerText = null;
            this.listViewTasksForSelect.Entity = null;
            this.listViewTasksForSelect.Location = new System.Drawing.Point(0, 0);
            this.listViewTasksForSelect.Margin = new System.Windows.Forms.Padding(4);
            this.listViewTasksForSelect.Name = "listViewTasksForSelect";
            this.listViewTasksForSelect.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.listViewTasksForSelect.ShowGroups = true;
            this.listViewTasksForSelect.Size = new System.Drawing.Size(1003, 677);
            this.listViewTasksForSelect.TabIndex = 14;
            this.listViewTasksForSelect.SelectedItemsChanged += new System.EventHandler<CAS.UI.UIControls.Auxiliary.SelectedItemsChangeEventArgs>(this.ListViewSelectedTasksSelectedItemsChanged);
            // 
            // DirectivePackageBindTaskForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Controls.Add(this.listViewTasksForSelect);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClose);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 640);
            this.Name = "DirectivePackageBindTaskForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directive Package Select Task Form";
            this.Activated += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Activated);
            this.Deactivate += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Deactivate);
            this.Load += new System.EventHandler(this.MaintenanceCheckBindTaskFormLoad);
            this.ResumeLayout(false);

        }
        #endregion

        private Button buttonAdd;
        private Button buttonClose;
        private DirectivePackageBindTaskListView listViewTasksForSelect;
    }
}