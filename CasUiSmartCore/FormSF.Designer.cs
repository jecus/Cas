namespace CAS.UI
{
    partial class FormSF
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.attachedFileControl2 = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.attachedFileControl1 = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // attachedFileControl2
            // 
            this.attachedFileControl2.AutoSize = true;
            this.attachedFileControl2.Description1 = null;
            this.attachedFileControl2.Description2 = null;
            this.attachedFileControl2.Filter = null;
            this.attachedFileControl2.Icon = null;
            this.attachedFileControl2.IconNotEnabled = null;
            this.attachedFileControl2.Location = new System.Drawing.Point(36, 80);
            this.attachedFileControl2.Name = "attachedFileControl2";
            this.attachedFileControl2.Size = new System.Drawing.Size(150, 51);
            this.attachedFileControl2.TabIndex = 3;
            // 
            // attachedFileControl1
            // 
            this.attachedFileControl1.AutoSize = true;
            this.attachedFileControl1.Description1 = "ghghghghggjkhgscvkjhagsckvjhgaskchvgakjschgvakjhcvghghgh";
            this.attachedFileControl1.Description2 = "erwerwerwerwer";
            this.attachedFileControl1.Filter = null;
            this.attachedFileControl1.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.attachedFileControl1.IconNotEnabled = global::CAS.UI.Properties.Resources.PDFIconSmall_gray;
            this.attachedFileControl1.Location = new System.Drawing.Point(61, 152);
            this.attachedFileControl1.MaximumSize = new System.Drawing.Size(350, 350);
            this.attachedFileControl1.Name = "attachedFileControl1";
            this.attachedFileControl1.Size = new System.Drawing.Size(174, 52);
            this.attachedFileControl1.TabIndex = 2;
            // 
            // FormSF
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.attachedFileControl2);
            this.Controls.Add(this.attachedFileControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormSF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private UIControls.Auxiliary.AttachedFileControl attachedFileControl1;
        private UIControls.Auxiliary.AttachedFileControl attachedFileControl2;

   





    }
}