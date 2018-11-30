using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Элемент управления, предназначенный для отображения статистики списка каких-либо объектов
    ///</summary>
    public class ObjectsListStatistics : RichReferenceContainer
    {

        #region Fields

        private int amount = 0;
        private Label labelAmount;
        private Panel mainPanel;
        private string objectText = "Aircraft";

        #endregion

        #region Constructor

        ///<summary>
        /// Создается новый объект отображения информации о ВС
        ///</summary>
        public ObjectsListStatistics()
        {
            InitializeComponent();
            labelAmount.Text = ObjectsAmountText;
        }

        #endregion

        #region Properties

        #region public string ObjectText

        /// <summary>
        /// Отображаемый текст
        /// </summary>
        public string ObjectText
        {
            get { return objectText; }
            set { objectText = value; }
        }

        #endregion

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
                labelAmount.Text = ObjectsAmountText;
            }
        }

        #endregion

        #region public string ObjectsAmountText

        ///<summary>
        /// Текст, описывающий количество ВС (или чего-то другого)
        ///</summary>
        public string ObjectsAmountText
        {
            get { return amount + " " + objectText + (amount == 1 ? "" : "s"); }
            set { objectText = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            labelAmount = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.Controls.Add(labelAmount);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(10, 36);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(160, 19);
            mainPanel.TabIndex = 1;
            // 
            // labelAmount
            // 
            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(3, 0);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(51, 19);
            labelAmount.TabIndex = 0;
            labelAmount.Text = "";
            Css.OrdinaryText.Adjust(labelAmount);
            // 
            // ObjectsListStatistics
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            MainControl = mainPanel;
            Name = "ObjectsListStatistics";
            Size = new Size(176, 67);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #endregion

    }
}