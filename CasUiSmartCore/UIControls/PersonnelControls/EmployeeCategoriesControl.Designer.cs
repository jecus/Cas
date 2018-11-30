using System.Threading;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.UIControls.PersonnelControls
{
    partial class EmployeeCategoriesControl
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

            //dateTimePickerDateOfBirth.ValueChanged -= DateTimePickerEffDateValueChanged;

            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelBiWeeklyReport = new System.Windows.Forms.Label();
            this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
            this.employeeCategoriesListControl = new CAS.UI.UIControls.PersonnelControls.EmployeeCategoriesListControl();
            this.SuspendLayout();
            // 
            // labelBiWeeklyReport
            // 
            this.labelBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.labelBiWeeklyReport.Name = "labelBiWeeklyReport";
            this.labelBiWeeklyReport.Size = new System.Drawing.Size(150, 25);
            this.labelBiWeeklyReport.TabIndex = 0;
            this.labelBiWeeklyReport.Text = "BiWeekly Report";
            // 
            // textboxBiWeeklyReport
            // 
            this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
            this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
            this.textboxBiWeeklyReport.MaxLength = 1000;
            this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
            this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 26);
            this.textboxBiWeeklyReport.TabIndex = 9;
            // 
            // employeeCategoriesListControl1
            // 
            this.employeeCategoriesListControl.AttachedObject = null;
            this.employeeCategoriesListControl.AutoSize = true;
            this.employeeCategoriesListControl.Location = new System.Drawing.Point(5, 5);
            this.employeeCategoriesListControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.employeeCategoriesListControl.Name = "employeeCategoriesListControl1";
            this.employeeCategoriesListControl.Size = new System.Drawing.Size(552, 283);
            this.employeeCategoriesListControl.TabIndex = 0;
            // 
            // EmployeeCategoriesControl
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.employeeCategoriesListControl);
            this.Name = "EmployeeCategoriesControl";
            this.Size = new System.Drawing.Size(1075, 293);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelBiWeeklyReport;
        private TextBox textboxBiWeeklyReport;
        private EmployeeCategoriesListControl employeeCategoriesListControl;

    }
}
