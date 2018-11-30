namespace CAS.UI.UIControls.Auxiliary
{
    partial class TreeCombobox
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
                this.treeView.NodeMouseDoubleClick -= TreeViewNodeMouseDoubleClick;    
            }
            if (disposing && (components != null))
            {
                components.Dispose();

                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
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
            this.dropDown = new System.Windows.Forms.ToolStripDropDown();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // dropDown
            // 
            this.dropDown.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.dropDown.Name = "dropDown";
            this.dropDown.Size = new System.Drawing.Size(2, 4);
            // 
            // treeView
            // 
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.FullRowSelect = true;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(121, 97);
            this.treeView.TabIndex = 0;
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewNodeMouseDoubleClick);
            // 
            // TreeCombobox
            // 
            this.Size = new System.Drawing.Size(121, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripDropDown dropDown;
        private System.Windows.Forms.TreeView treeView;
    }
}
