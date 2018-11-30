using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LTR.UI.UIControls
{
    public class LoadingDisplayer
    {
        private static LoadingForm loadingForm;

        /// <summary>
        /// Launches waiting form in new thread
        /// </summary>
        public void Start()
        {
            Thread thread = new Thread(RunThread);
            thread.Start();
        }

        /// <summary>
        /// Stops work of waiting form
        /// </summary>
        public void Finish()
        {
            lock (loadingForm)
            {
                if (null != loadingForm) loadingForm.Close();
            }
        }

        private void RunThread()
        {
            loadingForm = new LoadingForm();
            loadingForm.ShowDialog();
            //loadingForm.TopMost = true;
            loadingForm.ShowInTaskbar = false;
            loadingForm.Refresh();
        }

        #region public class LoadingForm : Form
        public class LoadingForm : Form
        {
            private Label labelLoadingMessage;
            private PictureBox pictureBoxAnimation;

            public LoadingForm()
            {
                InitializeComponent();
                Refresh();
            }

            #region private void InitializeComponent()
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.labelLoadingMessage = new Label();
                pictureBoxAnimation = new PictureBox();
                this.SuspendLayout();
                // 
                // labelLoadingMessage
                // 
                this.labelLoadingMessage.AutoSize = true;
                this.labelLoadingMessage.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                this.labelLoadingMessage.ForeColor = Color.White;
                this.labelLoadingMessage.Location = new Point(76, 69);
                this.labelLoadingMessage.Name = "labelLoadingMessage";
                this.labelLoadingMessage.Size = new Size(236, 29);
                this.labelLoadingMessage.TabIndex = 0;
                this.labelLoadingMessage.Text = "»дЄт загрузка...";
                //
                // pictureBoxAnimation
                //
                pictureBoxAnimation.Location = new Point(10, 55);
                pictureBoxAnimation.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBoxAnimation.Image = Image.FromFile("C:\\223228249.gif");
                // 
                // LoadingForm
                // 
                this.AutoScaleDimensions = new SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.BackColor = Color.DodgerBlue;
                this.ClientSize = new Size(400, 180);
                this.Controls.Add(this.labelLoadingMessage);
                this.Controls.Add(this.pictureBoxAnimation);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Name = "LoadingForm";
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Text = "LoadingForm";
                this.TransparencyKey = Color.Fuchsia;
                this.ResumeLayout(false);
                this.PerformLayout();
            }

            #endregion


        }
        #endregion

    }
}
