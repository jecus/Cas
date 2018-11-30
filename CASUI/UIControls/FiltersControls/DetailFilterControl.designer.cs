using CAS.UI.UIControls.FiltersControls;
using PartNoFilterControl=CAS.UI.UIControls.FiltersControls.PartNoFilterControl;
using SerialNoFilterControl=CAS.UI.UIControls.FiltersControls.SerialNoFilterControl;

namespace CAS.UI.UIControls.FiltersControls
{
    partial class DetailFilterControl
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
            this.detailConditionFilterControl1 = new DetailConditionFilterControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.partNoFilterControl1 = new PartNoFilterControl();
            this.serialNoFilterControl1 = new SerialNoFilterControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.detailConditionFilterControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 158);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // detailConditionFilterControl1
            // 
            this.detailConditionFilterControl1.AutoSize = true;
            this.detailConditionFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.detailConditionFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.detailConditionFilterControl1.FilterAppliance = true;
            this.detailConditionFilterControl1.Location = new System.Drawing.Point(249, 3);
            this.detailConditionFilterControl1.Name = "detailConditionFilterControl1";
            this.detailConditionFilterControl1.NotificationAppliance = true;
            this.detailConditionFilterControl1.SatisfactoryAppliance = true;
            this.detailConditionFilterControl1.Size = new System.Drawing.Size(161, 114);
            this.detailConditionFilterControl1.TabIndex = 0;
            this.detailConditionFilterControl1.UnsatisfactoryAppliance = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.partNoFilterControl1);
            this.panel1.Controls.Add(this.serialNoFilterControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 152);
            this.panel1.TabIndex = 1;
            // 
            // partNoFilterControl1
            // 
            this.partNoFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.partNoFilterControl1.FilterAppliance = true;
            this.partNoFilterControl1.Location = new System.Drawing.Point(3, 76);
            this.partNoFilterControl1.Name = "partNoFilterControl1";
            this.partNoFilterControl1.Size = new System.Drawing.Size(234, 73);
            this.partNoFilterControl1.TabIndex = 1;
            // 
            // serialNoFilterControl1
            // 
            this.serialNoFilterControl1.BackColor = System.Drawing.Color.Transparent;
            this.serialNoFilterControl1.FilterAppliance = true;
            this.serialNoFilterControl1.Location = new System.Drawing.Point(3, 3);
            this.serialNoFilterControl1.Name = "serialNoFilterControl1";
            this.serialNoFilterControl1.Size = new System.Drawing.Size(230, 69);
            this.serialNoFilterControl1.TabIndex = 0;
            // 
            // DetailFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DetailFilterControl";
            this.Size = new System.Drawing.Size(984, 158);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DetailConditionFilterControl detailConditionFilterControl1;
        private System.Windows.Forms.Panel panel1;
        private PartNoFilterControl partNoFilterControl1;
        private SerialNoFilterControl serialNoFilterControl1;
    }
}