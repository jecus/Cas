using System;
using System.Collections.Generic;
using System.Text;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Класс, описывающий отображение пояснения 
    ///</summary>
    public class AircraftsListReference: RichReferenceContainer
    {
        private int amount = 0;

        ///<summary>
        /// Создается новый объект отображения информации о ВС
        ///</summary>
        public AircraftsListReference()
        {
            InitializeComponent();
            labelAmount.Text = AircraftsAmountText;
        }

        #region public int Amount
        ///<summary>
        /// Количесвто ВС
        ///</summary>
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                labelAmount.Text = AircraftsAmountText;
            }
        }
        #endregion

        #region public string AircraftsAmountText
        ///<summary>
        /// Текст, описывающий количество ВС
        ///</summary>
        public string AircraftsAmountText
        {
            get
            {
                return amount + " Aircrafts";
            }
        }
        #endregion

        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Panel mainPanel;

        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.labelAmount = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.labelAmount);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(10, 36);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(160, 19);
            this.mainPanel.TabIndex = 1;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(3, 0);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(51, 19);
            this.labelAmount.TabIndex = 0;
            this.labelAmount.Text = "";
            Css.OrdinaryText.Adjust(labelAmount); 
            // 
            // AircraftsListReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.MainControl = this.mainPanel;
            this.Name = "AircraftsListReference";
            this.Size = new System.Drawing.Size(176, 67);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
