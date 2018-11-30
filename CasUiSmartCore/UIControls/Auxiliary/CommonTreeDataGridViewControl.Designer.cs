using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class CommonTreeDataGridViewControl
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
            if(disposing)
            {
                treeDataGridView.Rows.Clear();
                treeDataGridView.ColumnHeaderMouseClick -= DataGridViewColumnHeaderMouseClick;
                //this.itemsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ItemsListViewItemSelectionChanged);
                treeDataGridView.SelectionChanged -= DataGridViewSelectionChanged;
                treeDataGridView.KeyPress -= DataGridViewKeyPress;
                treeDataGridView.MouseClick -= DataGridViewMouseClick;
                treeDataGridView.MouseDoubleClick -= DataGridViewMouseDoubleClick;
                treeDataGridView.PreviewKeyDown -= DataGridViewPreviewKeyDown;
                treeDataGridView.DataError -= dataGridView_DataError;
                treeDataGridView.DefaultValuesNeeded -= DataGridViewDefaultValuesNeeded;
                treeDataGridView.UserDeletedRow -= DataGridViewUserDeletedRow;
                linkLabelAddNew.LinkClicked -= LinkLabelAddNewLinkClicked;
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
            this.panelBottomContainer = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.quickSearchControl = new CAS.UI.UIControls.Auxiliary.QuickSearchControl();
            this.labelTotal = new System.Windows.Forms.Label();
            this.treeDataGridView = new CAS.UI.UIControls.Auxiliary.TreeDataGridView.TreeDataGridView();
            this.panelBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottomContainer
            // 
            this.panelBottomContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panelBottomContainer.Controls.Add(this.linkLabelAddNew);
            this.panelBottomContainer.Controls.Add(this.quickSearchControl);
            this.panelBottomContainer.Controls.Add(this.labelTotal);
            this.panelBottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomContainer.Location = new System.Drawing.Point(0, 707);
            this.panelBottomContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottomContainer.Name = "panelBottomContainer";
            this.panelBottomContainer.Size = new System.Drawing.Size(1067, 31);
            this.panelBottomContainer.TabIndex = 1;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(240, 0);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(93, 31);
            this.linkLabelAddNew.TabIndex = 3;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // quickSearchControl
            // 
            this.quickSearchControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.quickSearchControl.Location = new System.Drawing.Point(0, 0);
            this.quickSearchControl.Margin = new System.Windows.Forms.Padding(5);
            this.quickSearchControl.Name = "quickSearchControl";
            this.quickSearchControl.Size = new System.Drawing.Size(240, 31);
            this.quickSearchControl.SuccessBackgroundColor = true;
            this.quickSearchControl.TabIndex = 1;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTotal.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.labelTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelTotal.Location = new System.Drawing.Point(979, 0);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Padding = new System.Windows.Forms.Padding(0, 6, 33, 0);
            this.labelTotal.Size = new System.Drawing.Size(88, 24);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "Total:";
            // 
            // treeDataGridView
            // 
            this.treeDataGridView.AllowUserToAddRows = false;
            this.treeDataGridView.AllowUserToDeleteRows = false;
            this.treeDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.treeDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.treeDataGridView.CollapseIcon = global::CAS.UI.Properties.Resources.RedMinusSmall;
            this.treeDataGridView.ExpandIcon = global::CAS.UI.Properties.Resources.GreenPlusSmall;
            this.treeDataGridView.ImageList = null;
            this.treeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.treeDataGridView.Name = "treeDataGridView";
            this.treeDataGridView.RowHeadersVisible = false;
            this.treeDataGridView.ShowLines = false;
            this.treeDataGridView.Size = new System.Drawing.Size(1067, 704);
            this.treeDataGridView.TabIndex = 2;
            this.treeDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewColumnHeaderMouseClick);
            this.treeDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.treeDataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewDefaultValuesNeeded);
            this.treeDataGridView.SelectionChanged += new System.EventHandler(this.DataGridViewSelectionChanged);
            this.treeDataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewUserDeletedRow);
            this.treeDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridViewKeyPress);
            this.treeDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            this.treeDataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseDoubleClick);
            this.treeDataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DataGridViewPreviewKeyDown);
            // 
            // CommonTreeDataGridViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeDataGridView);
            this.Controls.Add(this.panelBottomContainer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommonTreeDataGridViewControl";
            this.Size = new System.Drawing.Size(1067, 738);
            this.panelBottomContainer.ResumeLayout(false);
            this.panelBottomContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelBottomContainer;
        private System.Windows.Forms.Label labelTotal;
        private QuickSearchControl quickSearchControl;
        private LinkLabel linkLabelAddNew;
        protected TreeDataGridView.TreeDataGridView treeDataGridView;
    }
}
