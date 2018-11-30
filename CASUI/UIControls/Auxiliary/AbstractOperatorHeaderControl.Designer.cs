namespace CAS.UI.UIControls.Auxiliary
{
    partial class AbstractOperatorHeaderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitViewer1 = new Controls.SplitViewer.SplitViewer();
            this.SuspendLayout();
            // 
            // splitViewer1
            // 
            this.splitViewer1.BackColor = System.Drawing.Color.Transparent;
            this.splitViewer1.ControlsAmount = 4;
            this.splitViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitViewer1.Location = new System.Drawing.Point(0, 0);
            this.splitViewer1.Name = "splitViewer1";
            this.splitViewer1.Size = new System.Drawing.Size(400, 47);
            this.splitViewer1.TabIndex = 0;
            // 
            // AbstractOperatorHeaderControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitViewer1);
            this.Name = "OperatorHeaderControl";
            this.Size = new System.Drawing.Size(500, 47);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /// <summary>
        /// Элемент управления отображения кнопок с разделителями
        /// </summary>
        protected Controls.SplitViewer.SplitViewer splitViewer1;

    }
}