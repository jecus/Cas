namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class ComponentOilControl
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
            this.textOnBoard = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textAdded = new System.Windows.Forms.TextBox();
            this.textDetail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textOnBoard
            // 
            this.textOnBoard.Location = new System.Drawing.Point(196, 0);
            this.textOnBoard.Margin = new System.Windows.Forms.Padding(0);
            this.textOnBoard.MaximumSize = new System.Drawing.Size(200, 18);
            this.textOnBoard.Name = "textOnBoard";
            this.textOnBoard.Size = new System.Drawing.Size(38, 18);
            this.textOnBoard.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "On Board";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Added";
            // 
            // textAdded
            // 
            this.textAdded.Location = new System.Drawing.Point(97, 0);
            this.textAdded.Margin = new System.Windows.Forms.Padding(0);
            this.textAdded.MaximumSize = new System.Drawing.Size(200, 18);
            this.textAdded.Name = "textAdded";
            this.textAdded.Size = new System.Drawing.Size(38, 18);
            this.textAdded.TabIndex = 1;
            // 
            // textDetail
            // 
            this.textDetail.Location = new System.Drawing.Point(0, 0);
            this.textDetail.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textDetail.MaximumSize = new System.Drawing.Size(200, 18);
            this.textDetail.Name = "textDetail";
            this.textDetail.Size = new System.Drawing.Size(50, 18);
            this.textDetail.TabIndex = 0;
            // 
            // ComponentOilControl
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.textDetail);
            this.Controls.Add(this.textOnBoard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textAdded);
            this.Name = "ComponentOilControl";
            this.Size = new System.Drawing.Size(234, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textOnBoard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textAdded;
        private System.Windows.Forms.TextBox textDetail;
    }
}
