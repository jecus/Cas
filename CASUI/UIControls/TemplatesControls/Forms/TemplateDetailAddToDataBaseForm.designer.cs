using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    partial class TemplateDetailAddToDataBaseForm
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
            this.comboBoxOperators = new System.Windows.Forms.ComboBox();
            this.buttonAddTemplate = new System.Windows.Forms.Button();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelOperator = new System.Windows.Forms.Label();
            this.comboBoxAircrafts = new System.Windows.Forms.ComboBox();
            this.labelAircraft = new System.Windows.Forms.Label();
            this.comboBoxBaseDetails = new System.Windows.Forms.ComboBox();
            this.labelBaseDetail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(120, 140);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(150, 20);
            this.textBoxAmount.TabIndex = 0;
            // 
            // comboBoxOperators
            // 
            this.comboBoxOperators.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperators.Location = new System.Drawing.Point(120, 20);
            this.comboBoxOperators.Name = "comboBoxOperators";
            this.comboBoxOperators.Size = new System.Drawing.Size(150, 21);
            this.comboBoxOperators.TabIndex = 0;
            // 
            // buttonAddTemplate
            // 
            this.buttonAddTemplate.Location = new System.Drawing.Point(100, 180);
            this.buttonAddTemplate.Name = "buttonAddTemplate";
            this.buttonAddTemplate.Size = new System.Drawing.Size(100, 24);
            this.buttonAddTemplate.TabIndex = 1;
            this.buttonAddTemplate.Text = "Add To DataBase";
            this.buttonAddTemplate.Click += new System.EventHandler(this.buttonAddTemplate_Click);
            // 
            // labelAmount
            // 
            this.labelAmount.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelAmount.Location = new System.Drawing.Point(25, 140);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(100, 20);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "Amount";
            // 
            // labelOperator
            // 
            this.labelOperator.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelOperator.Location = new System.Drawing.Point(25, 20);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(100, 20);
            this.labelOperator.TabIndex = 3;
            this.labelOperator.Text = "Operator";
            // 
            // comboBoxAircrafts
            // 
            this.comboBoxAircrafts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAircrafts.Enabled = false;
            this.comboBoxAircrafts.Location = new System.Drawing.Point(120, 60);
            this.comboBoxAircrafts.Name = "comboBoxAircrafts";
            this.comboBoxAircrafts.Size = new System.Drawing.Size(150, 21);
            this.comboBoxAircrafts.TabIndex = 4;
            // 
            // labelAircraft
            // 
            this.labelAircraft.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraft.Location = new System.Drawing.Point(25, 60);
            this.labelAircraft.Name = "labelAircraft";
            this.labelAircraft.Size = new System.Drawing.Size(100, 20);
            this.labelAircraft.TabIndex = 5;
            this.labelAircraft.Text = "Aircraft";
            // 
            // comboBoxBaseDetails
            // 
            this.comboBoxBaseDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaseDetails.Enabled = false;
            this.comboBoxBaseDetails.Location = new System.Drawing.Point(120, 100);
            this.comboBoxBaseDetails.Name = "comboBoxBaseDetails";
            this.comboBoxBaseDetails.Size = new System.Drawing.Size(150, 21);
            this.comboBoxBaseDetails.TabIndex = 4;
            // 
            // labelBaseDetail
            // 
            this.labelBaseDetail.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelBaseDetail.Location = new System.Drawing.Point(25, 100);
            this.labelBaseDetail.Name = "labelBaseDetail";
            this.labelBaseDetail.Size = new System.Drawing.Size(100, 20);
            this.labelBaseDetail.TabIndex = 5;
            this.labelBaseDetail.Text = "BaseDetail";
            // 
            // TemplateDetailAddToDataBaseForm
            // 
            this.AcceptButton = this.buttonAddTemplate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.comboBoxAircrafts);
            this.Controls.Add(this.labelAircraft);
            this.Controls.Add(this.comboBoxOperators);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.buttonAddTemplate);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelOperator);
            this.Controls.Add(this.comboBoxBaseDetails);
            this.Controls.Add(this.labelBaseDetail);
            this.Name = "TemplateDetailAddToDataBaseForm";
            this.Text = (string)new TermsProvider()["SystemName"];
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAmount;
        private ComboBox comboBoxOperators;
        private Button buttonAddTemplate;
        private Label labelAmount;
        private Label labelOperator;
        private ComboBox comboBoxAircrafts;
        private Label labelAircraft;
        private ComboBox comboBoxBaseDetails;
        private Label labelBaseDetail;

    }
}