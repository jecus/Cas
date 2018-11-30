
namespace CAS.UI.UIControls.NonRoutineJobsControls
{
    partial class NonRoutineJobsStatusListScreen
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
            this.headerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(1551, 71);
            this.headerControl.Controls.SetChildIndex(this.aircraftHeaderControl1, 0);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1557, 364);
            // 
            // NonRoutineJobCategoriesListScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "NonRoutineJobsStatusListScreen";
            this.ShowAircraftStatusPanel = true;
            this.Size = new System.Drawing.Size(1557, 635);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
