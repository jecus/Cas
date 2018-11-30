using System.ComponentModel;
using System.Threading;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class LoginControl
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

            if(backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();

            while (backgroundWorker.IsBusy)
            {
                Thread.Sleep(500);
            }

            backgroundWorker.Dispose();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker = new BackgroundWorker();
            this.SuspendLayout();

            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
            // 
            // LoginControl
            // 
            this.Name = "UILoginControl";
            this.Size = new System.Drawing.Size(600, 367);
            this.ResumeLayout(false);
        }

        #endregion



    }
}