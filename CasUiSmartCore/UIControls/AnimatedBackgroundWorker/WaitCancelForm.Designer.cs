namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    partial class WaitCancelForm
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
                if (_backGroundWorker != null)
                    _backGroundWorker.RunWorkerCompleted -= BackGroundWorkerRunWorkerCompleted;
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
			this.labelText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(22, 57);
			this.labelText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(249, 13);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "waiting for the completion of the asynchronous task";
			// 
			// WaitCancelForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 86);
			this.ControlBox = false;
			this.Controls.Add(this.labelText);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "WaitCancelForm";
			this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
			this.Resizable = false;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Wait Cancel Form";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
    }
}