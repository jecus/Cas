namespace CAS.UI.UIControls.Auxiliary
{
    partial class QuickSearchControl
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
            this.labelQuickSearch = new System.Windows.Forms.Label();
            this.pictureBoxQuickSearch = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuickSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQuickSearch
            // 
            this.labelQuickSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(136)))), ((int)(((byte)(233)))));
            this.labelQuickSearch.Font = new System.Drawing.Font("Verdana", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.labelQuickSearch.ForeColor = System.Drawing.Color.White;
            this.labelQuickSearch.Location = new System.Drawing.Point(-3, 0);
            this.labelQuickSearch.Name = "labelQuickSearch";
            this.labelQuickSearch.Size = new System.Drawing.Size(150, 25);
            this.labelQuickSearch.TabIndex = 0;
            this.labelQuickSearch.Text = "Quick search";
            this.labelQuickSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxQuickSearch
            // 
            this.pictureBoxQuickSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(136)))), ((int)(((byte)(233)))));
            this.pictureBoxQuickSearch.BackgroundImage = global::CAS.UI.Properties.Resources.SearchIcon;
            this.pictureBoxQuickSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxQuickSearch.Location = new System.Drawing.Point(147, 0);
            this.pictureBoxQuickSearch.Name = "pictureBoxQuickSearch";
            this.pictureBoxQuickSearch.Size = new System.Drawing.Size(30, 25);
            this.pictureBoxQuickSearch.TabIndex = 1;
            this.pictureBoxQuickSearch.TabStop = false;
            // 
            // QuickSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxQuickSearch);
            this.Controls.Add(this.labelQuickSearch);
            this.Name = "QuickSearchControl";
            this.Size = new System.Drawing.Size(180, 25);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuickSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelQuickSearch;
        private System.Windows.Forms.PictureBox pictureBoxQuickSearch;
    }
}
