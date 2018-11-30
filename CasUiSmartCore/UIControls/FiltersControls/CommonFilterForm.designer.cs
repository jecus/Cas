using System.Windows.Forms;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class CommonFilterForm
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
                if(_animatedThreadWorker.IsBusy)
                    _animatedThreadWorker.CancelAsync();

                _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
                _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
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
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panelMain = new System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.radioButtonOr = new System.Windows.Forms.RadioButton();
			this.radioButtonAnd = new System.Windows.Forms.RadioButton();
			this.buttonClearFilter = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonOK.Location = new System.Drawing.Point(244, 3);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 33);
			this.buttonOK.TabIndex = 12;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(325, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 13;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelMain.Location = new System.Drawing.Point(3, 3);
			this.panelMain.MinimumSize = new System.Drawing.Size(400, 120);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(400, 120);
			this.panelMain.TabIndex = 14;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.panelMain);
			this.flowLayoutPanel1.Controls.Add(this.panelButtons);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 168);
			this.flowLayoutPanel1.TabIndex = 15;
			// 
			// panelButtons
			// 
			this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.panelButtons.Controls.Add(this.radioButtonOr);
			this.panelButtons.Controls.Add(this.radioButtonAnd);
			this.panelButtons.Controls.Add(this.buttonClearFilter);
			this.panelButtons.Controls.Add(this.buttonOK);
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Location = new System.Drawing.Point(3, 129);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(400, 36);
			this.panelButtons.TabIndex = 0;
			// 
			// radioButtonOr
			// 
			this.radioButtonOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonOr.AutoSize = true;
			this.radioButtonOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonOr.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonOr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonOr.Location = new System.Drawing.Point(80, 9);
			this.radioButtonOr.Name = "radioButtonOr";
			this.radioButtonOr.Size = new System.Drawing.Size(42, 21);
			this.radioButtonOr.TabIndex = 61;
			this.radioButtonOr.Text = "Or";
			this.radioButtonOr.UseVisualStyleBackColor = true;
			// 
			// radioButtonAnd
			// 
			this.radioButtonAnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.radioButtonAnd.AutoSize = true;
			this.radioButtonAnd.Checked = true;
			this.radioButtonAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.radioButtonAnd.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.radioButtonAnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.radioButtonAnd.Location = new System.Drawing.Point(17, 9);
			this.radioButtonAnd.Name = "radioButtonAnd";
			this.radioButtonAnd.Size = new System.Drawing.Size(53, 21);
			this.radioButtonAnd.TabIndex = 60;
			this.radioButtonAnd.TabStop = true;
			this.radioButtonAnd.Text = "And";
			this.radioButtonAnd.UseVisualStyleBackColor = true;
			// 
			// buttonClearFilter
			// 
			this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClearFilter.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonClearFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonClearFilter.Location = new System.Drawing.Point(128, 3);
			this.buttonClearFilter.Name = "buttonClearFilter";
			this.buttonClearFilter.Size = new System.Drawing.Size(110, 33);
			this.buttonClearFilter.TabIndex = 14;
			this.buttonClearFilter.Text = "Clear Filter";
			this.buttonClearFilter.Click += new System.EventHandler(this.ButtonClearFilterClick);
			// 
			// CommonFilterForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(406, 171);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1280, 768);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(285, 165);
			this.Name = "CommonFilterForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Filter Form";
			this.Activated += new System.EventHandler(this.Form_Activated);
			this.Deactivate += new System.EventHandler(this.Form_Deactivate);
			this.Load += new System.EventHandler(this.FormLoad);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.panelButtons.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Button buttonOK;
        private Button buttonCancel;
        private Panel panelMain;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelButtons;
        private Button buttonClearFilter;
        private RadioButton radioButtonOr;
        private RadioButton radioButtonAnd;
    }
}