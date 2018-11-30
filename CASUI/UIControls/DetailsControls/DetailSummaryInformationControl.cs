using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.ProjectTerms;

namespace CAS.UI.UIControls.DetailsControls
{
   /*     
    /// <summary>
    /// Элемент управления, предназначенный для отображения общей информации об агрегате
    /// </summary>
    public partial class DetailSummaryInformationControl : UserControl
    {

        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly InfoViewer currentStateInfo;
        private readonly InfoViewer remainsInfo;
        //private readonly Size defaultSize = new Size(InfoViewer.DefaultSize.Width * 3, 250);

        #endregion
        
        #region Constructors

        #region public DetailSummaryInformationControl()

        /// <summary>
        /// Создает элемент управления для отображения общей информации об агрегате
        /// </summary>
        public DetailSummaryInformationControl()
        {
            currentStateInfo = new InfoViewer(5);
            remainsInfo = new InfoViewer(5);
            AutoSize = true;
            //
            // currentStateInfo
            //
            currentStateInfo.LifeLengthViewers[0].ShowHeaders = true;
            currentStateInfo.Location = new Point(0, 0);
            currentStateInfo.LeftHeaderWidth = 150;
            currentStateInfo.LabelTitle.Text = "Current state (" + DateTime.Now.ToString(new TermsProvider()["DateFormat"].ToString()) + ")";
            currentStateInfo.LifeLengthViewers[0].LeftHeader = "Since new";
            currentStateInfo.LifeLengthViewers[1].LeftHeader = "Since overhaul";
            currentStateInfo.LifeLengthViewers[2].LeftHeader = "Since inspection";
            currentStateInfo.LifeLengthViewers[3].LeftHeader = "Since shop visit";
            currentStateInfo.LifeLengthViewers[4].LeftHeader = "Since hot section inspection";
            currentStateInfo.FirstLifelengthViewerLostFocusByShiftTabClicked = true;
            currentStateInfo.ShowMinutes = false;
            currentStateInfo.LastLifelengthViewerTabClicked += currentStateInfo_LastLifelengthViewerTabClicked;
            currentStateInfo.FirstLifelengthViewerShiftTabClicked += currentStateInfo_FirstLifelengthViewerShiftTabClicked;
            //
            // remainsInfo
            //
            remainsInfo.LifeLengthViewers[0].ShowHeaders = true;
            remainsInfo.Location = new Point(currentStateInfo.Right + 100, 0);
            remainsInfo.LeftHeaderWidth = 150;
            remainsInfo.LabelTitle.Text = "Remains";
            remainsInfo.LifeLengthViewers[0].LeftHeader = "To max";
            remainsInfo.LifeLengthViewers[1].LeftHeader = "To overhaul";
            remainsInfo.LifeLengthViewers[2].LeftHeader = "To inspection";
            remainsInfo.LifeLengthViewers[3].LeftHeader = "To shop visit";
            remainsInfo.LifeLengthViewers[4].LeftHeader = "To hot section inspection";
            remainsInfo.LastLifelengthViewerLostFocusByTabClicked = true;
            remainsInfo.ShowMinutes = false;
            remainsInfo.LastLifelengthViewerTabClicked += remainsInfo_LastLifelengthViewerTabClicked;
            remainsInfo.FirstLifelengthViewerShiftTabClicked += remainsInfo_FirstLifelengthViewerShiftTabClicked;


            Controls.Add(currentStateInfo);
            Controls.Add(remainsInfo);

        }

        #endregion

        #region public DetailSummaryInformationControl(AbstractDetail detail) : this()

        /// <summary>
        /// Создает элемент управления для отображения общей информации об агрегате
        /// </summary>
        /// <param name="detail">Текущий агрегат</param>
        public DetailSummaryInformationControl(AbstractDetail detail) : this()
        {
            currentDetail = detail;
            if (detail == null) 
                throw new ArgumentNullException("detail", "Argument cannot be null");
            UpdateInformation();
        }

        #endregion

        #endregion
        
        #region Methods

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        public void UpdateInformation()
        {
            currentStateInfo.LifeLengthViewers[4].Visible = false;
            remainsInfo.LifeLengthViewers[4].Visible = false;

            if (currentDetail is Engine)
            {
                currentStateInfo.LifeLengthViewers[4].Visible = true;
                remainsInfo.LifeLengthViewers[4].Visible = true;

                if (currentDetail.Limitation.ResourceSinceNew != currentDetail.Limitation.ResourceSinceHotSectionInspection)
                    currentStateInfo.LifeLengthViewers[4].Lifelength = currentDetail.Limitation.ResourceSinceHotSectionInspection;
                else currentStateInfo.LifeLengthViewers[4].Lifelength = new Lifelength();
                remainsInfo.LifeLengthViewers[4].Lifelength = currentDetail.Limitation.LeftTillSinceHotSectionInspectionExpiration;
            }

            currentStateInfo.LifeLengthViewers[0].Lifelength = currentDetail.Limitation.ResourceSinceNew;
            if (currentDetail.Limitation.ResourceSinceNew != currentDetail.Limitation.ResourceSinceOverhaul)
                currentStateInfo.LifeLengthViewers[1].Lifelength = currentDetail.Limitation.ResourceSinceOverhaul;
            else 
                currentStateInfo.LifeLengthViewers[1].Lifelength = new Lifelength();
            if (currentDetail.Limitation.ResourceSinceNew != currentDetail.Limitation.ResourceSinceInspection)
                currentStateInfo.LifeLengthViewers[2].Lifelength = currentDetail.Limitation.ResourceSinceInspection;
            else
                currentStateInfo.LifeLengthViewers[2].Lifelength = new Lifelength();
            if (currentDetail.Limitation.ResourceSinceNew != currentDetail.Limitation.ResourceSinceShopVisit)
                currentStateInfo.LifeLengthViewers[3].Lifelength = currentDetail.Limitation.ResourceSinceShopVisit;
            else
                currentStateInfo.LifeLengthViewers[3].Lifelength = new Lifelength();

            remainsInfo.LifeLengthViewers[0].Lifelength = currentDetail.Limitation.LeftTillSinceNewExpiration;
            remainsInfo.LifeLengthViewers[1].Lifelength = currentDetail.Limitation.LeftTillSinceOverhaulExpiration;
            remainsInfo.LifeLengthViewers[2].Lifelength = currentDetail.Limitation.LeftTillSinceInspectionExpiration;
            remainsInfo.LifeLengthViewers[3].Lifelength = currentDetail.Limitation.LeftTillSinceShopVisitExpiration;
        }

        #endregion

        #region private void currentStateInfo_LastLifelengthViewerTabClicked(int position)

        private void currentStateInfo_LastLifelengthViewerTabClicked(int position)
        {
            remainsInfo.FocusFirstElement(position);
        }

        #endregion

        #region private void remainsInfo_LastLifelengthViewerTabClicked(int position)

        private void remainsInfo_LastLifelengthViewerTabClicked(int position)
        {
            currentStateInfo.FocusFirstElement(++position);
        }

        #endregion

        #region private void currentStateInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void currentStateInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            if (position > 0)
                remainsInfo.FocusLastElement(--position);
        }

        #endregion

        #region private void remainsInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void remainsInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            currentStateInfo.FocusLastElement(position);
        }

        #endregion

        #endregion

    }*/

    

}



