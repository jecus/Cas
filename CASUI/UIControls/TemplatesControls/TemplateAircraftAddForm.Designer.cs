using System.Drawing;
using System.Windows.Forms;
using LTR.Core.ProjectTerms;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.TemplatesControls
{
    partial class TemplateAircraftAddForm
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
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            comboBoxOperators = new ComboBox();
            buttonAddTemplate = new Button();
            labelAmount = new Label();
            labelOperator = new Label();
            this.SuspendLayout();
            //
            // labelOperator
            //
            labelOperator.Location = new Point(25, 20);
            labelOperator.Size = new Size(100, 20);
            labelOperator.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelOperator.Text = "Operator";
            //
            // comboBoxOperators
            //
            comboBoxOperators.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperators.Location = new Point(120, 20);
            comboBoxOperators.Size = new System.Drawing.Size(150, 20);
            //
            // labelAmount
            //
            labelAmount.Location = new Point(25, 60);
            labelAmount.Size = new Size(100, 20);
            labelAmount.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelAmount.Text = "Amount";
            // 
            // textBoxAmount
            // 
            textBoxAmount.Location = new System.Drawing.Point(120, 60);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new System.Drawing.Size(150, 20);
            textBoxAmount.TabIndex = 0;
            //
            // buttonAddTemplate
            //
            buttonAddTemplate.Location = new Point(100, 100);
            buttonAddTemplate.Size = new Size(100, 24);
            buttonAddTemplate.Text = "Add To DataBase";
            buttonAddTemplate.Click += buttonAddTemplate_Click;
            // 
            // TemplateAircraftAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Controls.Add(this.comboBoxOperators);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.buttonAddTemplate);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelOperator);
            this.Name = "TemplateAircraftAddForm";
            this.Text = (string) new StaticProjectTermsProvider()["SystemName"];
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAmount;
        private ComboBox comboBoxOperators;
        private Button buttonAddTemplate;
        private Label labelAmount;
        private Label labelOperator;
    }
}