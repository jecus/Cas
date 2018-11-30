using LTR.UI.Management.Dispatchering;
using SampleHelpRequester=LTR.UI.SampleHelpRequester;

namespace LTR.UI
{
    ///<summary>
    ///</summary>
    partial class SampleStartPage
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

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }
        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sampleHelpRequester1 = new LTR.UI.SampleHelpRequester();
            this.SuspendLayout();
            // 
            // sampleHelpRequester1
            // 
            this.sampleHelpRequester1.Location = new System.Drawing.Point(19, 16);
            this.sampleHelpRequester1.Name = "sampleHelpRequester1";
            this.sampleHelpRequester1.Size = new System.Drawing.Size(271, 87);
            this.sampleHelpRequester1.TabIndex = 0;
            this.sampleHelpRequester1.TopicID = "знак плюс";
            // 
            // SampleStartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sampleHelpRequester1);
            this.Name = "SampleStartPage";
            this.Size = new System.Drawing.Size(327, 163);
            this.ResumeLayout(false);

        }

        #endregion

        private SampleHelpRequester sampleHelpRequester1;
    }
}