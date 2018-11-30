using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class DirectiveFilterControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.directiveOpenessFilterControl1 = new DirectiveOpenessFilterControl();
            this.directiveTitleFilterControl1 = new DirectiveTitleFilterControl();
            this.directiveConditionFilterControl1 = new DirectiveConditionFilterControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.directiveOpenessFilterControl1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.directiveTitleFilterControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.directiveConditionFilterControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 120);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // directiveOpenessFilterControl1
            // 
            this.directiveOpenessFilterControl1.AutoSize = true;
            this.directiveOpenessFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.directiveOpenessFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.directiveOpenessFilterControl1.ClosedAppliance = true;
            this.directiveOpenessFilterControl1.FilterAppliance = true;
            this.directiveOpenessFilterControl1.Location = new System.Drawing.Point(358, 3);
            this.directiveOpenessFilterControl1.Name = "directiveOpenessFilterControl1";
            this.directiveOpenessFilterControl1.OpenAppliance = true;
            this.directiveOpenessFilterControl1.Size = new System.Drawing.Size(155, 85);
            this.directiveOpenessFilterControl1.TabIndex = 0;
            // 
            // directiveTitleFilterControl1
            // 
            this.directiveTitleFilterControl1.AutoSize = true;
            this.directiveTitleFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.directiveTitleFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.directiveTitleFilterControl1.FilterAppliance = true;
            this.directiveTitleFilterControl1.Location = new System.Drawing.Point(3, 3);
            this.directiveTitleFilterControl1.Name = "directiveTitleFilterControl1";
            this.directiveTitleFilterControl1.Size = new System.Drawing.Size(171, 61);
            this.directiveTitleFilterControl1.TabIndex = 1;
            // 
            // directiveConditionFilterControl1
            // 
            this.directiveConditionFilterControl1.AutoSize = true;
            this.directiveConditionFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.directiveConditionFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.directiveConditionFilterControl1.FilterAppliance = true;
            this.directiveConditionFilterControl1.Location = new System.Drawing.Point(180, 3);
            this.directiveConditionFilterControl1.Name = "directiveConditionFilterControl1";
            this.directiveConditionFilterControl1.NotificationAppliance = true;
            this.directiveConditionFilterControl1.SatisfactoryAppliance = true;
            this.directiveConditionFilterControl1.Size = new System.Drawing.Size(161, 114);
            this.directiveConditionFilterControl1.TabIndex = 2;
            this.directiveConditionFilterControl1.UnsatisfactoryAppliance = true;
            // 
            // DirectiveFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DirectiveFilterControl";
            this.Size = new System.Drawing.Size(534, 120);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DirectiveOpenessFilterControl directiveOpenessFilterControl1;
        private DirectiveTitleFilterControl directiveTitleFilterControl1;
        private DirectiveConditionFilterControl directiveConditionFilterControl1;
    }
}