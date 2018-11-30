namespace CAS.UI.UIControls.MaintananceProgram
{
    partial class MaintenanceProgramControlItem
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
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCheckType = new System.Windows.Forms.Label();
            this.listViewProgramChecks = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // labelCheckType
            // 
            this.labelCheckType.AutoSize = true;
            this.labelCheckType.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCheckType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCheckType.Location = new System.Drawing.Point(3, 4);
            this.labelCheckType.Name = "labelCheckType";
            this.labelCheckType.Size = new System.Drawing.Size(90, 18);
            this.labelCheckType.TabIndex = 1;
            this.labelCheckType.Text = "CheckType";
            // 
            // listView1
            // 
            this.listViewProgramChecks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProgramChecks.FullRowSelect = true;
            this.listViewProgramChecks.GridLines = true;
            this.listViewProgramChecks.Location = new System.Drawing.Point(0, 25);
            this.listViewProgramChecks.Margin = new System.Windows.Forms.Padding(5);
            this.listViewProgramChecks.MultiSelect = false;
            this.listViewProgramChecks.Name = "listView1";
            this.listViewProgramChecks.Size = new System.Drawing.Size(1200, 158);
            this.listViewProgramChecks.TabIndex = 2;
            this.listViewProgramChecks.UseCompatibleStateImageBehavior = false;
            this.listViewProgramChecks.View = System.Windows.Forms.View.Details;
            // 
            // MaintenanceScheduleItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewProgramChecks);
            this.Controls.Add(this.labelCheckType);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Name = "MaintenanceProgramControlItem";
            this.Size = new System.Drawing.Size(1200, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCheckType;
        private System.Windows.Forms.ListView listViewProgramChecks;
    }
}
