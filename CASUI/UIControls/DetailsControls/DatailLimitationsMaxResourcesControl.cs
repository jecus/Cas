using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{
/*
    /// <summary>
    /// Элемент управления для отображения ограничений агрегата
    /// </summary>
    public class DatailLimitationsMaxResourcesControl : UserControl
    {
        #region Fields

        private AbstractDetail currentDetail;
        private readonly InfoViewer maxResourcesInfo;
        private readonly InfoViewer notifyWhenRemainsInfo;
        private readonly Label labelRemark;

        #endregion
        
        #region Constructors

        #region public DatailLimitationsMaxResourcesControl()

        /// <summary>
        /// Создает элемент управления для отображения ограничений заданного агрегата
        /// </summary>
        public DatailLimitationsMaxResourcesControl()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            maxResourcesInfo = new InfoViewer(5);
            notifyWhenRemainsInfo = new InfoViewer(5);
            labelRemark = new Label();
            //
            // maxResourcesInfo
            //
            maxResourcesInfo.LifeLengthViewers[0].ShowHeaders = true;
            maxResourcesInfo.Location = new Point(0, 0);
            maxResourcesInfo.LabelTitle.Text = "Max resources";
            maxResourcesInfo.LeftHeaderWidth = 150;
            maxResourcesInfo.LifeLengthViewers[0].LeftHeader = "Since new";
            maxResourcesInfo.LifeLengthViewers[1].LeftHeader = "Since overhaul";
            maxResourcesInfo.LifeLengthViewers[2].LeftHeader = "Since inspection";
            maxResourcesInfo.LifeLengthViewers[3].LeftHeader = "Since shop visit";
            maxResourcesInfo.LifeLengthViewers[4].LeftHeader = "Since hot section " + "\r\n" + " inspection";
            maxResourcesInfo.LifeLengthViewers[4].Visible = false;
            maxResourcesInfo.FirstLifelengthViewerLostFocusByShiftTabClicked = true;
            maxResourcesInfo.ReadOnly = false;
            maxResourcesInfo.ShowMinutes = false;
            maxResourcesInfo.LastLifelengthViewerTabClicked += maxResourcesInfo_LastLifelengthViewerTabClicked;
            maxResourcesInfo.FirstLifelengthViewerShiftTabClicked += maxResourcesInfo_FirstLifelengthViewerShiftTabClicked;
            maxResourcesInfo.LifelengthViewerLostFocus += maxResourcesInfo_LifelengthViewerLostFocus;
            //
            // notifyWhenRemainsInfo
            //
            notifyWhenRemainsInfo.LifeLengthViewers[0].ShowHeaders = true;
            notifyWhenRemainsInfo.Location = new Point(maxResourcesInfo.Right + 100, 0);
            notifyWhenRemainsInfo.LabelTitle.Text = "Notify when remains";
            notifyWhenRemainsInfo.LeftHeaderWidth = 150;
            notifyWhenRemainsInfo.LifeLengthViewers[0].LeftHeader = "Since new";
            notifyWhenRemainsInfo.LifeLengthViewers[1].LeftHeader = "Since overhaul";
            notifyWhenRemainsInfo.LifeLengthViewers[2].LeftHeader = "Since inspection";
            notifyWhenRemainsInfo.LifeLengthViewers[3].LeftHeader = "Since shop visit";
            notifyWhenRemainsInfo.LifeLengthViewers[4].LeftHeader = "Since hot section " + "\r\n" + " inspection";
            notifyWhenRemainsInfo.LifeLengthViewers[4].Visible = false;
            notifyWhenRemainsInfo.LastLifelengthViewerLostFocusByTabClicked = true;
            notifyWhenRemainsInfo.ReadOnly = false;
            notifyWhenRemainsInfo.ShowMinutes = false;
            notifyWhenRemainsInfo.LastLifelengthViewerTabClicked += notifyWhenRemainsInfo_LastLifelengthViewerTabClicked;
            notifyWhenRemainsInfo.FirstLifelengthViewerShiftTabClicked += notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked;
            //
            // labelRemark
            //
            labelRemark.AutoSize = true;
            labelRemark.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelRemark.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelRemark.Text = "Use double click to set applicability of the field";
         
            Controls.Add(maxResourcesInfo);
            Controls.Add(notifyWhenRemainsInfo);
            Controls.Add(labelRemark);

            labelRemark.Location = new Point(0, maxResourcesInfo.Bottom + 20);
        }

        #endregion
        
        #region public DatailLimitationsMaxResourcesControl(AbstractDetail detail) : this()

        /// <summary>
        /// Создает элемент управления для отображения ограничений заданного агрегата
        /// </summary>
        /// <param name="detail">Текущий агрегат</param>
        public DatailLimitationsMaxResourcesControl(AbstractDetail detail) : this()
        {
            if (detail == null)
                throw new ArgumentNullException("detail", "Argument cannot be null");
            CurrentDetail = detail;
        }

        #endregion
        
        #endregion

        #region Properties

        #region public AbstractDetail CurrentDetail

        /// <summary>
        /// Возвращает или устанавливает агрегат, с которым работает данный элемент управления
        /// </summary>
        public AbstractDetail CurrentDetail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
                UpdateInformation();
            }
        }

        #endregion

        #region public Lifelength SinceNewLimitation

        /// <summary>
        /// Ограничение с начала эксплуатации
        /// </summary>
        public Lifelength SinceNewLimitation
        {
            get
            {
                return maxResourcesInfo.LifeLengthViewers[0].Lifelength;
            }
            set
            {
                maxResourcesInfo.LifeLengthViewers[0].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastOverhaulLimitation

        /// <summary>
        /// Ограничение с последнего ремонта
        /// </summary>
        public Lifelength SinceLastOverhaulLimitation
        {
            get
            {
                return maxResourcesInfo.LifeLengthViewers[1].Lifelength;
            }
            set
            {
                maxResourcesInfo.LifeLengthViewers[1].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastInspectionLimitation

        /// <summary>
        /// Ограничение с последнего осмотра эксплуатации
        /// </summary>
        public Lifelength SinceLastInspectionLimitation
        {
            get
            {
                return maxResourcesInfo.LifeLengthViewers[2].Lifelength;
            }
            set
            {
                maxResourcesInfo.LifeLengthViewers[2].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastShopVisitLimitation

        /// <summary>
        /// Ограничение с последнего момента закупки
        /// </summary>
        public Lifelength SinceLastShopVisitLimitation
        {
            get
            {
                return maxResourcesInfo.LifeLengthViewers[3].Lifelength;
            }
            set
            {
                maxResourcesInfo.LifeLengthViewers[3].Lifelength = value;
            }
        }

        #endregion
        
        #region public Lifelength SinceLastHotInspectionLimitation

        /// <summary>
        /// Ограничение с последнего момента hot inspection
        /// </summary>
        public Lifelength SinceLastHotInspectionLimitation
        {
            get
            {
                return maxResourcesInfo.LifeLengthViewers[4].Lifelength;
            }
            set
            {
                maxResourcesInfo.LifeLengthViewers[4].Lifelength = value;
            }
        }

        #endregion
         

        #region public Lifelength SinceNewNotification

        /// <summary>
        /// Уведомление ограничения с начала эксплуатации
        /// </summary>
        public Lifelength SinceNewNotification
        {
            get
            {
                return notifyWhenRemainsInfo.LifeLengthViewers[0].Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifeLengthViewers[0].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastOverhaulNotification

        /// <summary>
        /// Уведомление ограничения с последнего ремонта
        /// </summary>
        public Lifelength SinceLastOverhaulNotification
        {
            get
            {
                return notifyWhenRemainsInfo.LifeLengthViewers[1].Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifeLengthViewers[1].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastInspectionNotification

        /// <summary>
        /// Уведомление ограничения с последнего осмотра эксплуатации
        /// </summary>
        public Lifelength SinceLastInspectionNotification
        {
            get
            {
                return notifyWhenRemainsInfo.LifeLengthViewers[2].Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifeLengthViewers[2].Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength SinceLastShopVisitNotification

        /// <summary>
        /// Уведомление ограничения с последнего момента закупки
        /// </summary>
        public Lifelength SinceLastShopVisitNotification
        {
            get
            {
                return notifyWhenRemainsInfo.LifeLengthViewers[3].Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifeLengthViewers[3].Lifelength = value;
            }
        }

        #endregion
        
        #region public Lifelength SinceLastHostInspectionNotification

        /// <summary>
        /// Уведомление ограничения с последнего Hot section inspection
        /// </summary>
        public Lifelength SinceLastHostInspectionNotification
        {
            get
            {
                return notifyWhenRemainsInfo.LifeLengthViewers[4].Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifeLengthViewers[4].Lifelength = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return GetChangeStatus(currentDetail);
        }

        #endregion

        #region public bool GetChangeStatus(AbstractDetail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus(AbstractDetail detail)
        {
            return (maxResourcesInfo.Modified || notifyWhenRemainsInfo.Modified);
            //detail.Limitation.Modified
        }

        #endregion

        #region public bool GetChangeStatusOfNewDetail()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatusOfNewDetail()
        {
            return ((maxResourcesInfo.LifeLengthViewers[0].Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifeLengthViewers[1].Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifeLengthViewers[2].Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifeLengthViewers[3].Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifeLengthViewers[4].Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifeLengthViewers[0].Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifeLengthViewers[1].Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifeLengthViewers[2].Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifeLengthViewers[3].Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifeLengthViewers[4].Lifelength != Lifelength.NullLifelength));
        }

        #endregion
        
        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        public void UpdateInformation()
        {
            if (currentDetail != null) 
                UpdateInformation(currentDetail);
        }

        #endregion

        #region public void UpdateInformation(AbstractDetail sourceDetail)

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        /// <param name="sourceDetail">Агрегат по которому отображается информация</param>
        public void UpdateInformation(AbstractDetail sourceDetail)
        {
            if (sourceDetail == null) throw new ArgumentNullException("sourceDetail");

            SinceNewLimitation = sourceDetail.Limitation.MaxResourceSinceNew;
            SinceLastShopVisitLimitation = sourceDetail.Limitation.MaxResourceSinceShopVisit;
            SinceLastInspectionLimitation = sourceDetail.Limitation.MaxResourceSinceInspection;
            SinceLastOverhaulLimitation = sourceDetail.Limitation.MaxResourceSinceOverhaul;
            
            SinceNewNotification = sourceDetail.Limitation.NotificationSinceNew;
            SinceLastShopVisitNotification = sourceDetail.Limitation.NotificationSinceShopVisit;
            SinceLastInspectionNotification = sourceDetail.Limitation.NotificationSinceInspection;
            SinceLastOverhaulNotification = sourceDetail.Limitation.NotificationSinceOverhaul;
            

            if (sourceDetail is Engine)
            {
                notifyWhenRemainsInfo.LifeLengthViewers[4].Visible = true;
                maxResourcesInfo.LifeLengthViewers[4].Visible = true;
                SinceLastHotInspectionLimitation = sourceDetail.Limitation.MaxResourceSinceHotSectionInspection;
                SinceLastHostInspectionNotification = sourceDetail.Limitation.NotificationSinceHotSectionInspection;
            }

            bool permission = (currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update));
            maxResourcesInfo.ReadOnly = !permission;
            notifyWhenRemainsInfo.ReadOnly = !permission;
            labelRemark.Visible = permission;

        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Задаются данные агрегату
        /// </summary>
        public void SaveData()
        {
            if (currentDetail != null) 
                SaveData(currentDetail);
        }

        #endregion

        #region public void SaveData(Detail destinationDetail)

        /// <summary>
        /// Задаются данные агрегату
        /// </summary>
        /// <param name="destinationDetail">Агрегат у которого задаются данные</param>
        public void SaveData(AbstractDetail destinationDetail)
        {
            if (destinationDetail == null) throw new ArgumentNullException("destinationDetail");

            maxResourcesInfo.LifeLengthViewers[0].SaveData(destinationDetail.Limitation.MaxResourceSinceNew);
            maxResourcesInfo.LifeLengthViewers[1].SaveData(destinationDetail.Limitation.MaxResourceSinceOverhaul);
            maxResourcesInfo.LifeLengthViewers[2].SaveData(destinationDetail.Limitation.MaxResourceSinceInspection);
            maxResourcesInfo.LifeLengthViewers[3].SaveData(destinationDetail.Limitation.MaxResourceSinceShopVisit);
            maxResourcesInfo.LifeLengthViewers[4].SaveData(destinationDetail.Limitation.MaxResourceSinceHotSectionInspection);

            notifyWhenRemainsInfo.LifeLengthViewers[0].SaveData(destinationDetail.Limitation.NotificationSinceNew);
            notifyWhenRemainsInfo.LifeLengthViewers[1].SaveData(destinationDetail.Limitation.NotificationSinceOverhaul);
            notifyWhenRemainsInfo.LifeLengthViewers[2].SaveData(destinationDetail.Limitation.NotificationSinceInspection);
            notifyWhenRemainsInfo.LifeLengthViewers[3].SaveData(destinationDetail.Limitation.NotificationSinceShopVisit);
            notifyWhenRemainsInfo.LifeLengthViewers[4].SaveData(destinationDetail.Limitation.NotificationSinceHotSectionInspection);
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearAllFields()
        {
            SinceNewLimitation = new Lifelength();
            SinceLastOverhaulLimitation = new Lifelength();
            SinceLastInspectionLimitation = new Lifelength();
            SinceLastShopVisitLimitation = new Lifelength();
            SinceLastHotInspectionLimitation = new Lifelength();

            SinceNewNotification = new Lifelength();
            SinceLastOverhaulNotification = new Lifelength();
            SinceLastInspectionNotification = new Lifelength();
            SinceLastShopVisitNotification = new Lifelength();
            SinceLastHostInspectionNotification = new Lifelength();
        }

        #endregion

        #region private void maxResourcesInfo_LastLifelengthViewerTabClicked(int position)

        private void maxResourcesInfo_LastLifelengthViewerTabClicked(int position)
        {
            notifyWhenRemainsInfo.FocusFirstElement(position);
        }

        #endregion

        #region private void notifyWhenRemainsInfo_LastLifelengthViewerTabClicked(int position)

        private void notifyWhenRemainsInfo_LastLifelengthViewerTabClicked(int position)
        {
           // if ((notifyWhenRemainsInfo.LifeLengthViewers[4].Visible && position <4) || (!notifyWhenRemainsInfo.LifeLengthViewers[4].Visible && position < 3))
                maxResourcesInfo.FocusFirstElement(++position);
        }

        #endregion

        #region private void maxResourcesInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void maxResourcesInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            if (position > 0)
                notifyWhenRemainsInfo.FocusLastElement(--position);   
        }

        #endregion

        #region private void notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            maxResourcesInfo.FocusLastElement(position);
        }

        #endregion

        #region private void maxResourcesInfo_LifelengthViewerLostFocus(int position)

        private void maxResourcesInfo_LifelengthViewerLostFocus(int position)
        {
            if (!maxResourcesInfo.LifeLengthViewers[position].HoursApplicable && 
                !maxResourcesInfo.LifeLengthViewers[position].CyclesApplicable &&
                !maxResourcesInfo.LifeLengthViewers[position].CalendarApplicable)
            {
                if (maxResourcesInfo.LifeLengthViewers[position].HoursApplicable)
                    notifyWhenRemainsInfo.LifeLengthViewers[position].Hours = new TimeSpan((int)(0.1* maxResourcesInfo.LifeLengthViewers[position].Hours.Hours), 0, 0);
            }
        }

        #endregion

                
        #endregion

    }
*/
}
