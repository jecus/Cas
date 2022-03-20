using System.ComponentModel;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.radChat2 = new Telerik.WinControls.UI.RadChat();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChat2)).BeginInit();
            this.SuspendLayout();
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Location = new System.Drawing.Point(0, 0);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.ShowGrid = false;
            this.radChartView1.Size = new System.Drawing.Size(480, 320);
            this.radChartView1.TabIndex = 0;

            // 
            // radChat2
            // 
            this.radChat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChat2.Location = new System.Drawing.Point(20, 60);
            this.radChat2.Name = "radChat2";
            this.radChat2.Size = new System.Drawing.Size(566, 598);
            this.radChat2.TabIndex = 0;
            this.radChat2.Text = "radChat2";
            this.radChat2.ThemeName = "TelerikMetroBlue";
            this.radChat2.TimeSeparatorInterval = System.TimeSpan.Parse("1.00:00:00");
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 678);
            this.Controls.Add(this.radChat2);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChat2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private RadChartView radChartView1;
        private RadChat radChat2;
    }
}