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
            this.labelText.Location = new System.Drawing.Point(13, 13);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(331, 17);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "waiting for the completion of the asynchronous task";
            // 
            // WaitCancelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 51);
            this.ControlBox = false;
            this.Controls.Add(this.labelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WaitCancelForm";
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