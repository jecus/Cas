using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class CommonDataGridViewControl
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
                dataGridView.Rows.Clear();
                dataGridView.ColumnHeaderMouseClick -= DataGridViewColumnHeaderMouseClick;
                //dataGridView.CurrentCellDirtyStateChanged -= DataGridViewItemsCurrentCellDirtyStateChanged;
                //this.itemsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ItemsListViewItemSelectionChanged);
                dataGridView.SelectionChanged -= DataGridViewSelectionChanged;
                dataGridView.KeyPress -= DataGridViewKeyPress;
                dataGridView.MouseClick -= DataGridViewMouseClick;
                dataGridView.MouseDoubleClick -= DataGridViewMouseDoubleClick;
                dataGridView.PreviewKeyDown -= DataGridViewPreviewKeyDown;
                dataGridView.DataError -= dataGridView_DataError;
                dataGridView.DefaultValuesNeeded -= DataGridViewDefaultValuesNeeded;
                dataGridView.UserDeletedRow -= DataGridViewUserDeletedRow;
                linkLabelAddNew.LinkClicked -= LinkLabelAddNewLinkClicked;
				this.dataGridView.CellValueChanged -= DataGridView_CellValueChanged;
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.linkLabelDelete = new System.Windows.Forms.LinkLabel();
            this.panelBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottomContainer
            // 
            this.panelBottomContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panelBottomContainer.Controls.Add(this.linkLabelDelete);
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
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(1067, 707);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewColumnHeaderMouseClick);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            this.dataGridView.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewDefaultValuesNeeded);
            this.dataGridView.SelectionChanged += new System.EventHandler(this.DataGridViewSelectionChanged);
            this.dataGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DataGridViewUserDeletedRow);
            this.dataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridViewKeyPress);
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            this.dataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseDoubleClick);
            this.dataGridView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.DataGridViewPreviewKeyDown);
			this.dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            // 
            // linkLabelDelete
            // 
            this.linkLabelDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabelDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelDelete.Location = new System.Drawing.Point(333, 0);
            this.linkLabelDelete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelDelete.Name = "linkLabelDelete";
            this.linkLabelDelete.Size = new System.Drawing.Size(93, 31);
            this.linkLabelDelete.TabIndex = 4;
            this.linkLabelDelete.TabStop = true;
            this.linkLabelDelete.Text = "Delete";
            this.linkLabelDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelDeleteLinkClicked);
            // 
            // CommonDataGridViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelBottomContainer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CommonDataGridViewControl";
            this.Size = new System.Drawing.Size(1067, 738);
            this.panelBottomContainer.ResumeLayout(false);
            this.panelBottomContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }


		#endregion

		private System.Windows.Forms.Panel panelBottomContainer;
        private System.Windows.Forms.Label labelTotal;
        private QuickSearchControl quickSearchControl;
        protected DataGridView dataGridView;
        private LinkLabel linkLabelAddNew;
        private LinkLabel linkLabelDelete;
    }
}
