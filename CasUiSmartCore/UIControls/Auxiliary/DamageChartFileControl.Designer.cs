namespace CAS.UI.UIControls.Auxiliary
{
    partial class DamageChartFileControl
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
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.panelMain = new System.Windows.Forms.Panel();
            this.fileControlChartFile = new CAS.UI.UIControls.Auxiliary.AttachedFileControl();
            this.labelChart = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.comboBoxDamageCharts = new System.Windows.Forms.ComboBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanelMain.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoSize = true;
            this.flowLayoutPanelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelMain.Controls.Add(this.panelLabel);
            this.flowLayoutPanelMain.Controls.Add(this.panelMain);
            this.flowLayoutPanelMain.Controls.Add(this.panelButtons);
            this.flowLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(317, 174);
            this.flowLayoutPanelMain.TabIndex = 1;
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.extendableRichContainer1);
            this.panelLabel.Location = new System.Drawing.Point(3, 3);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Size = new System.Drawing.Size(309, 26);
            this.panelLabel.TabIndex = 40;
            // 
            // extendableRichContainer1
            // 
            this.extendableRichContainer1.AfterCaptionControl = null;
            this.extendableRichContainer1.AfterCaptionControl2 = null;
            this.extendableRichContainer1.AfterCaptionControl3 = null;
            this.extendableRichContainer1.AutoSize = true;
            this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer1.Caption = "labelCaption";
            this.extendableRichContainer1.CaptionFont = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer1.Condition = null;
            this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer1.Extendable = true;
            this.extendableRichContainer1.Extended = true;
            this.extendableRichContainer1.Location = new System.Drawing.Point(3, 4);
            this.extendableRichContainer1.MainControl = null;
            this.extendableRichContainer1.MaximumSize = new System.Drawing.Size(225, 50);
            this.extendableRichContainer1.Name = "extendableRichContainer1";
            this.extendableRichContainer1.Size = new System.Drawing.Size(114, 22);
            this.extendableRichContainer1.TabIndex = 41;
            this.extendableRichContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
            this.extendableRichContainer1.Extending += new System.EventHandler(this.ExtendableRichContainer1Extending);
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Controls.Add(this.fileControlChartFile);
            this.panelMain.Controls.Add(this.labelChart);
            this.panelMain.Controls.Add(this.labelLocation);
            this.panelMain.Controls.Add(this.comboBoxDamageCharts);
            this.panelMain.Controls.Add(this.textBoxLocation);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(3, 35);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(309, 102);
            this.panelMain.TabIndex = 42;
            // 
            // FileControlChartFile
            // 
            this.fileControlChartFile.AutoSize = true;
            this.fileControlChartFile.BackColor = System.Drawing.Color.Transparent;
            this.fileControlChartFile.Description1 = null;
            this.fileControlChartFile.Description2 = null;
            this.fileControlChartFile.Filter = "Adobe PDF Files|*.pdf";
            this.fileControlChartFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fileControlChartFile.Icon = global::CAS.UI.Properties.Resources.PDFIconSmall;
            this.fileControlChartFile.IconNotEnabled = null;
            this.fileControlChartFile.Location = new System.Drawing.Point(6, 59);
            this.fileControlChartFile.MaximumSize = new System.Drawing.Size(300, 150);
            this.fileControlChartFile.MinimumSize = new System.Drawing.Size(300, 40);
            this.fileControlChartFile.Name = "FileControlChartFile";
            this.fileControlChartFile.Size = new System.Drawing.Size(300, 40);
            this.fileControlChartFile.TabIndex = 38;
            // 
            // labelChart
            // 
            this.labelChart.AutoSize = true;
            this.labelChart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelChart.Location = new System.Drawing.Point(3, 5);
            this.labelChart.Name = "labelChart";
            this.labelChart.Size = new System.Drawing.Size(47, 14);
            this.labelChart.TabIndex = 34;
            this.labelChart.Text = "Chart:";
            this.labelChart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLocation.Location = new System.Drawing.Point(3, 33);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(65, 14);
            this.labelLocation.TabIndex = 36;
            this.labelLocation.Text = "Location:";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxDamageCharts
            // 
            this.comboBoxDamageCharts.BackColor = System.Drawing.Color.White;
            this.comboBoxDamageCharts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxDamageCharts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.comboBoxDamageCharts.Location = new System.Drawing.Point(75, 2);
            this.comboBoxDamageCharts.Name = "comboBoxDamageCharts";
            this.comboBoxDamageCharts.Size = new System.Drawing.Size(229, 22);
            this.comboBoxDamageCharts.TabIndex = 35;
            this.comboBoxDamageCharts.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDamageChartsSelectedIndexChanged);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BackColor = System.Drawing.Color.White;
            this.textBoxLocation.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxLocation.Location = new System.Drawing.Point(75, 30);
            this.textBoxLocation.MaxLength = 4;
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(229, 22);
            this.textBoxLocation.TabIndex = 37;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panelButtons.Controls.Add(this.ButtonDelete);
            this.panelButtons.Location = new System.Drawing.Point(3, 143);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(309, 26);
            this.panelButtons.TabIndex = 39;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = null;
            this.ButtonDelete.Location = new System.Drawing.Point(231, 3);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(72, 23);
            this.ButtonDelete.TabIndex = 0;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "delete";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = null;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // DamageChartFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Name = "DamageChartFileControl";
            this.Size = new System.Drawing.Size(317, 174);
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.flowLayoutPanelMain.PerformLayout();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Panel panelButtons;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private ReferenceControls.ExtendableRichContainer extendableRichContainer1;
        private System.Windows.Forms.Panel panelMain;
        private AttachedFileControl fileControlChartFile;
        private System.Windows.Forms.Label labelChart;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.ComboBox comboBoxDamageCharts;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Panel panelLabel;

    }
}
