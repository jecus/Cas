using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class BaseListViewControl<T>
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
            this.panelBottomContainer = new System.Windows.Forms.Panel();
            this.quickSearchControl = new CAS.UI.UIControls.Auxiliary.QuickSearchControl();
            this.labelTotal = new System.Windows.Forms.Label();
            this.itemsListView = new System.Windows.Forms.ListView();
            this.panelBottomContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottomContainer
            // 
            this.panelBottomContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panelBottomContainer.Controls.Add(this.quickSearchControl);
            this.panelBottomContainer.Controls.Add(this.labelTotal);
            this.panelBottomContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomContainer.Location = new System.Drawing.Point(0, 707);
            this.panelBottomContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBottomContainer.Name = "panelBottomContainer";
            this.panelBottomContainer.Size = new System.Drawing.Size(1067, 31);
            this.panelBottomContainer.TabIndex = 1;
            // 
            // quickSearchControl
            // 
            this.quickSearchControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.quickSearchControl.Location = new System.Drawing.Point(0, 0);
            this.quickSearchControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
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
            // itemsListView
            // 
            this.itemsListView.AllowColumnReorder = true;
            this.itemsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsListView.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.itemsListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.itemsListView.FullRowSelect = true;
            this.itemsListView.Location = new System.Drawing.Point(0, 0);
            this.itemsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemsListView.Name = "itemsListView";
            this.itemsListView.ShowItemToolTips = true;
            this.itemsListView.Size = new System.Drawing.Size(1800, 707);
            this.itemsListView.TabIndex = 2;
            this.itemsListView.UseCompatibleStateImageBehavior = false;
            this.itemsListView.View = System.Windows.Forms.View.Details;
            this.itemsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ItemsListViewColumnClick);
            this.itemsListView.SelectedIndexChanged += new System.EventHandler(this.ItemsListViewSelectedIndexChanged);
            this.itemsListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ItemsListViewKeyPress);
            this.itemsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemsListViewMouseClick);
            this.itemsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ItemsListViewMouseDoubleClick);
            this.itemsListView.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ItemsListViewPreviewKeyDown);
            // 
            // BaseListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemsListView);
            this.Controls.Add(this.panelBottomContainer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BaseListViewControl";
            this.Size = new System.Drawing.Size(1067, 738);
            this.Load += new System.EventHandler(BaseListViewControlLoad);
            this.panelBottomContainer.ResumeLayout(false);
            this.panelBottomContainer.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelBottomContainer;
        public System.Windows.Forms.Label labelTotal;
        private QuickSearchControl quickSearchControl;
        protected System.Windows.Forms.ListView itemsListView;
    }
}
