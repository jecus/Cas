namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    partial class PassengerListControl
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
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.textFirstTotal = new System.Windows.Forms.TextBox();
            this.textBusinessTotal = new System.Windows.Forms.TextBox();
            this.textEconomyTotal = new System.Windows.Forms.TextBox();
            this.labelTitle4 = new System.Windows.Forms.Label();
            this.textBoxAllTotal = new System.Windows.Forms.TextBox();
            this.textBoxAllMax = new System.Windows.Forms.TextBox();
            this.textBoxFirstMax = new System.Windows.Forms.TextBox();
            this.textBoxBusinessMax = new System.Windows.Forms.TextBox();
            this.textBoxEconomyMax = new System.Windows.Forms.TextBox();
            this.labelMax = new System.Windows.Forms.Label();
            this.textBoxAllPersents = new System.Windows.Forms.TextBox();
            this.textBoxFirstPersents = new System.Windows.Forms.TextBox();
            this.textBoxBusinessPersents = new System.Windows.Forms.TextBox();
            this.textBoxEconomyPersents = new System.Windows.Forms.TextBox();
            this.labelPersents = new System.Windows.Forms.Label();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Passengers";
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelMain.Controls.Add(this.panelAdd);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanelMain.MaximumSize = new System.Drawing.Size(398, 144);
            this.flowLayoutPanelMain.MinimumSize = new System.Drawing.Size(398, 25);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(398, 144);
            this.flowLayoutPanelMain.TabIndex = 41;
            this.flowLayoutPanelMain.WrapContents = false;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(0, 0);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(0);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(398, 30);
            this.panelAdd.TabIndex = 3;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(164, 4);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(70, 23);
            this.linkLabelAddNew.TabIndex = 2;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelAddNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelAddNewLinkClicked);
            // 
            // textFirstTotal
            // 
            this.textFirstTotal.Location = new System.Drawing.Point(281, 167);
            this.textFirstTotal.Name = "textFirstTotal";
            this.textFirstTotal.ReadOnly = true;
            this.textFirstTotal.Size = new System.Drawing.Size(61, 20);
            this.textFirstTotal.TabIndex = 90;
            this.textFirstTotal.TabStop = false;
            // 
            // textBusinessTotal
            // 
            this.textBusinessTotal.Location = new System.Drawing.Point(217, 167);
            this.textBusinessTotal.Name = "textBusinessTotal";
            this.textBusinessTotal.ReadOnly = true;
            this.textBusinessTotal.Size = new System.Drawing.Size(61, 20);
            this.textBusinessTotal.TabIndex = 89;
            this.textBusinessTotal.TabStop = false;
            // 
            // textEconomyTotal
            // 
            this.textEconomyTotal.Location = new System.Drawing.Point(152, 167);
            this.textEconomyTotal.Name = "textEconomyTotal";
            this.textEconomyTotal.ReadOnly = true;
            this.textEconomyTotal.Size = new System.Drawing.Size(61, 20);
            this.textEconomyTotal.TabIndex = 88;
            this.textEconomyTotal.TabStop = false;
            // 
            // labelTitle4
            // 
            this.labelTitle4.AutoSize = true;
            this.labelTitle4.Location = new System.Drawing.Point(2, 171);
            this.labelTitle4.Name = "labelTitle4";
            this.labelTitle4.Size = new System.Drawing.Size(31, 13);
            this.labelTitle4.TabIndex = 87;
            this.labelTitle4.Text = "Total";
            // 
            // textBoxAllTotal
            // 
            this.textBoxAllTotal.Location = new System.Drawing.Point(38, 167);
            this.textBoxAllTotal.Name = "textBoxAllTotal";
            this.textBoxAllTotal.ReadOnly = true;
            this.textBoxAllTotal.Size = new System.Drawing.Size(61, 20);
            this.textBoxAllTotal.TabIndex = 91;
            this.textBoxAllTotal.TabStop = false;
            // 
            // textBoxAllMax
            // 
            this.textBoxAllMax.Location = new System.Drawing.Point(38, 193);
            this.textBoxAllMax.Name = "textBoxAllMax";
            this.textBoxAllMax.ReadOnly = true;
            this.textBoxAllMax.Size = new System.Drawing.Size(61, 20);
            this.textBoxAllMax.TabIndex = 96;
            this.textBoxAllMax.TabStop = false;
            // 
            // textBoxFirstMax
            // 
            this.textBoxFirstMax.Location = new System.Drawing.Point(281, 193);
            this.textBoxFirstMax.Name = "textBoxFirstMax";
            this.textBoxFirstMax.ReadOnly = true;
            this.textBoxFirstMax.Size = new System.Drawing.Size(61, 20);
            this.textBoxFirstMax.TabIndex = 95;
            this.textBoxFirstMax.TabStop = false;
            // 
            // textBoxBusinessMax
            // 
            this.textBoxBusinessMax.Location = new System.Drawing.Point(217, 193);
            this.textBoxBusinessMax.Name = "textBoxBusinessMax";
            this.textBoxBusinessMax.ReadOnly = true;
            this.textBoxBusinessMax.Size = new System.Drawing.Size(61, 20);
            this.textBoxBusinessMax.TabIndex = 94;
            this.textBoxBusinessMax.TabStop = false;
            // 
            // textBoxEconomyMax
            // 
            this.textBoxEconomyMax.Location = new System.Drawing.Point(152, 193);
            this.textBoxEconomyMax.Name = "textBoxEconomyMax";
            this.textBoxEconomyMax.ReadOnly = true;
            this.textBoxEconomyMax.Size = new System.Drawing.Size(61, 20);
            this.textBoxEconomyMax.TabIndex = 93;
            this.textBoxEconomyMax.TabStop = false;
            // 
            // labelMax
            // 
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(2, 197);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(30, 13);
            this.labelMax.TabIndex = 92;
            this.labelMax.Text = "Max.";
            // 
            // textBoxAllPersents
            // 
            this.textBoxAllPersents.Location = new System.Drawing.Point(38, 219);
            this.textBoxAllPersents.Name = "textBoxAllPersents";
            this.textBoxAllPersents.ReadOnly = true;
            this.textBoxAllPersents.Size = new System.Drawing.Size(61, 20);
            this.textBoxAllPersents.TabIndex = 101;
            this.textBoxAllPersents.TabStop = false;
            // 
            // textBoxFirstPersents
            // 
            this.textBoxFirstPersents.Location = new System.Drawing.Point(281, 219);
            this.textBoxFirstPersents.Name = "textBoxFirstPersents";
            this.textBoxFirstPersents.ReadOnly = true;
            this.textBoxFirstPersents.Size = new System.Drawing.Size(61, 20);
            this.textBoxFirstPersents.TabIndex = 100;
            this.textBoxFirstPersents.TabStop = false;
            // 
            // textBoxBusinessPersents
            // 
            this.textBoxBusinessPersents.Location = new System.Drawing.Point(217, 219);
            this.textBoxBusinessPersents.Name = "textBoxBusinessPersents";
            this.textBoxBusinessPersents.ReadOnly = true;
            this.textBoxBusinessPersents.Size = new System.Drawing.Size(61, 20);
            this.textBoxBusinessPersents.TabIndex = 99;
            this.textBoxBusinessPersents.TabStop = false;
            // 
            // textBoxEconomyPersents
            // 
            this.textBoxEconomyPersents.Location = new System.Drawing.Point(152, 219);
            this.textBoxEconomyPersents.Name = "textBoxEconomyPersents";
            this.textBoxEconomyPersents.ReadOnly = true;
            this.textBoxEconomyPersents.Size = new System.Drawing.Size(61, 20);
            this.textBoxEconomyPersents.TabIndex = 98;
            this.textBoxEconomyPersents.TabStop = false;
            // 
            // labelPersents
            // 
            this.labelPersents.AutoSize = true;
            this.labelPersents.Location = new System.Drawing.Point(2, 223);
            this.labelPersents.Name = "labelPersents";
            this.labelPersents.Size = new System.Drawing.Size(15, 13);
            this.labelPersents.TabIndex = 97;
            this.labelPersents.Text = "%";
            // 
            // PassengerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxAllPersents);
            this.Controls.Add(this.textBoxFirstPersents);
            this.Controls.Add(this.textBoxBusinessPersents);
            this.Controls.Add(this.textBoxEconomyPersents);
            this.Controls.Add(this.labelPersents);
            this.Controls.Add(this.textBoxAllMax);
            this.Controls.Add(this.textBoxFirstMax);
            this.Controls.Add(this.textBoxBusinessMax);
            this.Controls.Add(this.textBoxEconomyMax);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.textBoxAllTotal);
            this.Controls.Add(this.textFirstTotal);
            this.Controls.Add(this.textBusinessTotal);
            this.Controls.Add(this.textEconomyTotal);
            this.Controls.Add(this.labelTitle4);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.label11);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PassengerListControl";
            this.Size = new System.Drawing.Size(404, 248);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private System.Windows.Forms.TextBox textFirstTotal;
        private System.Windows.Forms.TextBox textBusinessTotal;
        private System.Windows.Forms.TextBox textEconomyTotal;
        private System.Windows.Forms.Label labelTitle4;
        private System.Windows.Forms.TextBox textBoxAllTotal;
        private System.Windows.Forms.TextBox textBoxAllMax;
        private System.Windows.Forms.TextBox textBoxFirstMax;
        private System.Windows.Forms.TextBox textBoxBusinessMax;
        private System.Windows.Forms.TextBox textBoxEconomyMax;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.TextBox textBoxAllPersents;
        private System.Windows.Forms.TextBox textBoxFirstPersents;
        private System.Windows.Forms.TextBox textBoxBusinessPersents;
        private System.Windows.Forms.TextBox textBoxEconomyPersents;
        private System.Windows.Forms.Label labelPersents;
    }
}
