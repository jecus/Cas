using MetroFramework.Controls;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
	partial class LoadingForm
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
			this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
			this.panelStage = new System.Windows.Forms.Panel();
			this.labelStage = new MetroFramework.Controls.MetroLabel();
			this.progressBarStage = new MetroFramework.Controls.MetroProgressBar();
			this.panelPersentage = new System.Windows.Forms.Panel();
			this.labelPersentage = new MetroFramework.Controls.MetroLabel();
			this.progressBarPersentage = new MetroFramework.Controls.MetroProgressBar();
			this.panelButtons = new System.Windows.Forms.Panel();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanelMain.SuspendLayout();
			this.panelStage.SuspendLayout();
			this.panelPersentage.SuspendLayout();
			this.panelButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanelMain
			// 
			this.flowLayoutPanelMain.AutoSize = true;
			this.flowLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanelMain.Controls.Add(this.panelStage);
			this.flowLayoutPanelMain.Controls.Add(this.panelPersentage);
			this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
			this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanelMain.Location = new System.Drawing.Point(22, 62);
			this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
			this.flowLayoutPanelMain.Size = new System.Drawing.Size(233, 115);
			this.flowLayoutPanelMain.TabIndex = 1;
			this.flowLayoutPanelMain.WrapContents = false;
			// 
			// panelStage
			// 
			this.panelStage.AutoSize = true;
			this.panelStage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelStage.Controls.Add(this.labelStage);
			this.panelStage.Controls.Add(this.progressBarStage);
			this.panelStage.Location = new System.Drawing.Point(2, 2);
			this.panelStage.Margin = new System.Windows.Forms.Padding(2);
			this.panelStage.Name = "panelStage";
			this.panelStage.Size = new System.Drawing.Size(229, 40);
			this.panelStage.TabIndex = 1;
			// 
			// labelStage
			// 
			this.labelStage.AutoSize = true;
			this.labelStage.Location = new System.Drawing.Point(2, 0);
			this.labelStage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelStage.Name = "labelStage";
			this.labelStage.Size = new System.Drawing.Size(45, 19);
			this.labelStage.TabIndex = 1;
			this.labelStage.Text = "Stage:";
			// 
			// progressBarStage
			// 
			this.progressBarStage.Location = new System.Drawing.Point(2, 19);
			this.progressBarStage.Margin = new System.Windows.Forms.Padding(2);
			this.progressBarStage.Name = "progressBarStage";
			this.progressBarStage.Size = new System.Drawing.Size(225, 19);
			this.progressBarStage.TabIndex = 0;
			// 
			// panelPersentage
			// 
			this.panelPersentage.AutoSize = true;
			this.panelPersentage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelPersentage.Controls.Add(this.labelPersentage);
			this.panelPersentage.Controls.Add(this.progressBarPersentage);
			this.panelPersentage.Location = new System.Drawing.Point(2, 46);
			this.panelPersentage.Margin = new System.Windows.Forms.Padding(2);
			this.panelPersentage.Name = "panelPersentage";
			this.panelPersentage.Size = new System.Drawing.Size(229, 40);
			this.panelPersentage.TabIndex = 2;
			// 
			// labelPersentage
			// 
			this.labelPersentage.AutoSize = true;
			this.labelPersentage.Location = new System.Drawing.Point(2, 0);
			this.labelPersentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPersentage.Name = "labelPersentage";
			this.labelPersentage.Size = new System.Drawing.Size(76, 19);
			this.labelPersentage.TabIndex = 1;
			this.labelPersentage.Text = "Persentage:";
			// 
			// progressBarPersentage
			// 
			this.progressBarPersentage.Location = new System.Drawing.Point(2, 19);
			this.progressBarPersentage.Margin = new System.Windows.Forms.Padding(2);
			this.progressBarPersentage.Name = "progressBarPersentage";
			this.progressBarPersentage.Size = new System.Drawing.Size(225, 19);
			this.progressBarPersentage.TabIndex = 0;
			// 
			// panelButtons
			// 
			this.panelButtons.AutoSize = true;
			this.panelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelButtons.Controls.Add(this.buttonCancel);
			this.panelButtons.Location = new System.Drawing.Point(2, 90);
			this.panelButtons.Margin = new System.Windows.Forms.Padding(2);
			this.panelButtons.Name = "panelButtons";
			this.panelButtons.Size = new System.Drawing.Size(229, 23);
			this.panelButtons.TabIndex = 3;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(171, 2);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(56, 19);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// LoadingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(271, 161);
			this.Controls.Add(this.flowLayoutPanelMain);
			this.Name = "LoadingForm";
			this.Resizable = false;
			this.Text = "Loading";
			this.flowLayoutPanelMain.ResumeLayout(false);
			this.flowLayoutPanelMain.PerformLayout();
			this.panelStage.ResumeLayout(false);
			this.panelStage.PerformLayout();
			this.panelPersentage.ResumeLayout(false);
			this.panelPersentage.PerformLayout();
			this.panelButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
		private System.Windows.Forms.Panel panelStage;
		private MetroLabel labelStage;
		private MetroProgressBar progressBarStage;
		private System.Windows.Forms.Panel panelPersentage;
		private MetroLabel labelPersentage;
		private MetroProgressBar progressBarPersentage;
		private System.Windows.Forms.Panel panelButtons;
		private System.Windows.Forms.Button buttonCancel;
	}
}