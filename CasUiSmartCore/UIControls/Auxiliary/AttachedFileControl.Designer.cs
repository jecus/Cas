using System.Threading;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class AttachedFileControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            FileChanged = null;
            EnabledChanged -= AvButtonTEnabledChanged;

            flowLayoutPanelMain.SizeChanged -= FlowLayoutPanelMainSizeChanged;
            linkLabelBrowse.LinkClicked -= LinkLabelBrowseLinkClicked;
            linkLabelBrowse.MouseHover -= ControlMouseHover;
            linkLabelBrowse.MouseLeave -= ControlMouseLeave;
            linkLabelRemove.LinkClicked -= LinkLabelRemoveLinkClicked;
            linkLabelRemove.MouseHover -= ControlMouseHover;
            linkLabelRemove.MouseLeave -= ControlMouseLeave;
            pictureBox.SizeChanged -= PictureBoxPdfSizeChanged;

            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();

            while (backgroundWorker.IsBusy)
            {
                Thread.Sleep(500);
            }

            backgroundWorker.DoWork -= BackgroundWorkerDoWork;
            backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
            backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.Dispose();

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelDescription = new System.Windows.Forms.Label();
            this.linkLabelBrowse = new System.Windows.Forms.LinkLabel();
            this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelDescription.Location = new System.Drawing.Point(3, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(47, 13);
            this.labelDescription.TabIndex = 0;
            // 
            // linkLabelBrowse
            // 
            this.linkLabelBrowse.AutoSize = true;
            this.linkLabelBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelBrowse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.linkLabelBrowse.Location = new System.Drawing.Point(3, 13);
            this.linkLabelBrowse.Name = "linkLabelBrowse";
            this.linkLabelBrowse.Size = new System.Drawing.Size(42, 13);
            this.linkLabelBrowse.TabIndex = 1;
            this.linkLabelBrowse.TabStop = true;
            this.linkLabelBrowse.Text = "Browse";
            this.linkLabelBrowse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelBrowseLinkClicked);
            this.linkLabelBrowse.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.linkLabelBrowse.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // linkLabelRemove
            // 
            this.linkLabelRemove.AutoSize = true;
            this.linkLabelRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.linkLabelRemove.Location = new System.Drawing.Point(3, 26);
            this.linkLabelRemove.Name = "linkLabelRemove";
            this.linkLabelRemove.Size = new System.Drawing.Size(47, 13);
            this.linkLabelRemove.TabIndex = 2;
            this.linkLabelRemove.TabStop = true;
            this.linkLabelRemove.Text = "Remove";
            this.linkLabelRemove.Visible = false;
            this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelRemoveLinkClicked);
            this.linkLabelRemove.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            this.linkLabelRemove.MouseHover += new System.EventHandler(this.ControlMouseHover);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(40, 34);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            this.pictureBox.SizeChanged += new System.EventHandler(this.PictureBoxPdfSizeChanged);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.Controls.Add(this.labelDescription);
            this.flowLayoutPanelMain.Controls.Add(this.linkLabelBrowse);
            this.flowLayoutPanelMain.Controls.Add(this.linkLabelRemove);
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(43, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(171, 62);
            this.flowLayoutPanelMain.TabIndex = 10;
            this.flowLayoutPanelMain.WrapContents = false;
            this.flowLayoutPanelMain.SizeChanged += new System.EventHandler(this.FlowLayoutPanelMainSizeChanged);
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(0, 34);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(40, 10);
            this.progressBarLoad.TabIndex = 11;
            this.progressBarLoad.Visible = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // AttachedFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.progressBarLoad);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.pictureBox);
            this.Name = "AttachedFileControl";
            this.Size = new System.Drawing.Size(214, 62);
            this.EnabledChanged += new System.EventHandler(this.AvButtonTEnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.LinkLabel linkLabelBrowse;
        private System.Windows.Forms.LinkLabel linkLabelRemove;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.ProgressBar progressBarLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
