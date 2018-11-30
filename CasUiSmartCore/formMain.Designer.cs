using System.Drawing;
using AvControls.AvMultitabControl;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MainControls;

namespace CAS.UI
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.dispatcheredMultitabControl = new CAS.UI.Management.Dispatchering.DispatcheredMultitabControl();
            this.loginPage = new CAS.UI.Management.Dispatchering.DispatcheredTabPage();
            this.dispatcheredUILoginPage1 = new DispatcheredUILoginPage();
            this.dispatcheredMultitabControl.SuspendLayout();
            this.loginPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dispatcheredMultitabControl
            // 
            this.dispatcheredMultitabControl.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.dispatcheredMultitabControl.ActiveBottomColor = System.Drawing.Color.White;
            this.dispatcheredMultitabControl.ActiveElementBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.dispatcheredMultitabControl.ActiveElementBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.dispatcheredMultitabControl.ActiveTabsButtonHint = "Active Tabs";
            this.dispatcheredMultitabControl.ActiveTopColor = System.Drawing.Color.White;
            this.dispatcheredMultitabControl.CloseButtonHint = "Close";
            this.dispatcheredMultitabControl.ClosingCanBeCanceled = false;
            this.dispatcheredMultitabControl.Controls.Add(this.loginPage);
            this.dispatcheredMultitabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispatcheredMultitabControl.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.dispatcheredMultitabControl.InactiveBottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(226)))));
            this.dispatcheredMultitabControl.InactiveTopColor = System.Drawing.Color.White;
            this.dispatcheredMultitabControl.Location = new System.Drawing.Point(0, 0);
            this.dispatcheredMultitabControl.MaxTabWidth = 185;
            this.dispatcheredMultitabControl.Name = "dispatcheredMultitabControl";
            this.dispatcheredMultitabControl.SelectedTab = this.loginPage;
            this.dispatcheredMultitabControl.ShowToolTips = true;
            this.dispatcheredMultitabControl.Size = new System.Drawing.Size(1272, 726);
            this.dispatcheredMultitabControl.TabIndex = 0;
            this.dispatcheredMultitabControl.TabPages.AddRange(new AvControls.AvMultitabControl.MultitabPage[] {
            this.loginPage});
            // 
            // loginPage
            // 
            this.loginPage.BackColor = System.Drawing.Color.Transparent;
            this.loginPage.Controls.Add(this.dispatcheredUILoginPage1);
            this.loginPage.Icon = null;
            this.loginPage.Name = "loginPage";
            this.loginPage.Owner = this.dispatcheredMultitabControl;
            this.loginPage.PerformCloseChecking = true;
            this.loginPage.Size = new System.Drawing.Size(1270, 705);
            this.loginPage.Text = "Login";
            this.loginPage.ToolTipText = "Login";
            // 
            // dispatcheredUILoginPage1
            // 
            this.dispatcheredUILoginPage1.BackColor = System.Drawing.Color.White;
            this.dispatcheredUILoginPage1.ContainedData = this.dispatcheredUILoginPage1;
            this.dispatcheredUILoginPage1.Displayer = null;
            this.dispatcheredUILoginPage1.DisplayerText = "";
            this.dispatcheredUILoginPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dispatcheredUILoginPage1.Entity = this.dispatcheredUILoginPage1;
            this.dispatcheredUILoginPage1.Location = new System.Drawing.Point(0, 0);
            this.dispatcheredUILoginPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dispatcheredUILoginPage1.Name = "dispatcheredUILoginPage1";
            this.dispatcheredUILoginPage1.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.CloseDisplayerContainingEntity;
            this.dispatcheredUILoginPage1.Size = new System.Drawing.Size(1270, 705);
            this.dispatcheredUILoginPage1.TabIndex = 0;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 726);
            this.Controls.Add(this.dispatcheredMultitabControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 750);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.formMain_Activated);
            this.Deactivate += new System.EventHandler(this.formMain_Deactivate);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.SizeChanged += new System.EventHandler(this.formMain_SizeChanged);
            this.dispatcheredMultitabControl.ResumeLayout(false);
            this.loginPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal DispatcheredMultitabControl dispatcheredMultitabControl;
        private DispatcheredTabPage loginPage;
        private DispatcheredUILoginPage dispatcheredUILoginPage1;
    }
}