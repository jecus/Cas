using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Класс, описывающий ссылку на Descrepancies
    ///</summary>
    public class DiscrepanciesReference:RichReferenceContainer
    {
        private int discrepanciesAmount;
        private int aircraftsAmount;
        private FlowLayoutPanel mainPanel;
        private Label descrepanciesText;
        private Label aircraftsLimitationText;
        private ReferenceLinkLabel reference;

        ///<summary> 
        ///</summary>
        public DiscrepanciesReference()
        {
            Caption = "Discrepancies";
            //
            // descrepanciesText
            //
            descrepanciesText = new Label();
            descrepanciesText.Text = DiscrepanciesText;
            descrepanciesText.AutoSize = true;
            descrepanciesText.Font = new Font("Verdana", 15, GraphicsUnit.Pixel);
            DescriptionTextColor = Color.FromArgb(122, 122, 122);
            descrepanciesText.ForeColor = DescriptionTextColor;
            //
            // aircraftsLimitationText
            //
            aircraftsLimitationText = new Label();
            aircraftsLimitationText.Text = AircraftsLimitationText;
            aircraftsLimitationText.AutoSize = true;
            aircraftsLimitationText.Font = new Font("Verdana", 15, GraphicsUnit.Pixel);
            aircraftsLimitationText.ForeColor = Color.FromArgb(122, 122, 122);
            //
            // reference
            //
            reference = new ReferenceLinkLabel();
            reference.AutoSize = true;
            reference.Text = "Show discrepancies";
            reference.Font = new Font("Verdana", 15, GraphicsUnit.Pixel);
            reference.DisplayerText = "Discrepancies";
            reference.ReflectionType = ReflectionTypes.DisplayInNew;
            reference.LinkColor = Color.FromArgb(62, 155, 246);
            reference.ActiveLinkColor = Color.FromArgb(62, 155, 246);
            reference.VisitedLinkColor = Color.FromArgb(62, 155, 246);
            reference.ForeColor = Color.Transparent;
            //
            // mainPanel
            //
            mainPanel = new FlowLayoutPanel();
            mainPanel.FlowDirection = FlowDirection.TopDown;
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //mainPanel.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(descrepanciesText);
            mainPanel.Controls.Add(aircraftsLimitationText);
            mainPanel.Controls.Add(reference);
            MainControl = mainPanel;
        }

        /// <summary>
        /// Описание ссылки перехода
        /// </summary>
        public ReferenceLinkLabel Reference
        {
            get { return reference; }
        }

        #region public int DiscrepanciesAmount
        ///<summary>
        /// Количество ограничений
        ///</summary>
        public int DiscrepanciesAmount
        {
            get { return discrepanciesAmount; }
            set { discrepanciesAmount = value; }
        }
        #endregion

        #region public int AircraftsAmount
        ///<summary>
        /// Количество ВС с ограничениями
        ///</summary>
        public int AircraftsAmount
        {
            get { return aircraftsAmount; }
            set { aircraftsAmount = value; }
        }
        #endregion

        #region public string AircraftsLimitationText
        ///<summary>
        /// Текст, описывающий количество ВС с ограничениями
        ///</summary>
        public string AircraftsLimitationText
        {
            get
            {
                return aircraftsAmount + " aircrafts has limitation";
            }
        }
        #endregion

        #region public string DiscrepanciesText
        ///<summary>
        /// Текст описывающий Descrepancies
        ///</summary>
        public string DiscrepanciesText
        {
            get
            {
                return discrepanciesAmount.ToString() + " discrepancies are available";
            }
        }
        #endregion
    }
}
