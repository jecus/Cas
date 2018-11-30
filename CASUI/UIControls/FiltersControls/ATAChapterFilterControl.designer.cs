namespace CAS.UI.UIControls.FiltersControls
{
    partial class ATAChapterFilterControl
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
            this.checkedListBoxATAChapter = new System.Windows.Forms.CheckedListBox();
            this.textBoxSelection = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxATAChapter
            // 
            this.checkedListBoxATAChapter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                         | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxATAChapter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.checkedListBoxATAChapter.CausesValidation = false;
            this.checkedListBoxATAChapter.CheckOnClick = true;
            this.checkedListBoxATAChapter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.checkedListBoxATAChapter.FormattingEnabled = true;
            this.checkedListBoxATAChapter.Location = new System.Drawing.Point(176, 34);
            this.checkedListBoxATAChapter.Name = "checkedListBoxATAChapter";
            this.checkedListBoxATAChapter.Size = new System.Drawing.Size(209, 70);
            this.checkedListBoxATAChapter.TabIndex = 15;
            this.checkedListBoxATAChapter.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxATAChapter_SelectedIndexChanged);
            this.checkedListBoxATAChapter.MouseLeave += new System.EventHandler(this.checkedListBoxATAChapter_MouseLeave);
            // 
            // textBoxSelection
            // 
            this.textBoxSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                 | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelection.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSelection.Location = new System.Drawing.Point(176, 5);
            this.textBoxSelection.Name = "textBoxSelection";
            this.textBoxSelection.Size = new System.Drawing.Size(209, 23);
            this.textBoxSelection.TabIndex = 16;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelect.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.buttonSelect.FlatAppearance.BorderSize = 0;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelect.Location = new System.Drawing.Point(392, 1);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(35, 32);
            this.buttonSelect.TabIndex = 17;
            this.buttonSelect.Text = "...";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "ATA Chapter:";
            // 
            // ATAChapterFilterControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxSelection);
            this.Controls.Add(this.checkedListBoxATAChapter);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ATAChapterFilterControl";
            this.Size = new System.Drawing.Size(444, 110);
            this.Load += new System.EventHandler(this.ATAChapterFilterControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxATAChapter;
        private System.Windows.Forms.TextBox textBoxSelection;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Label label1;
    }
}