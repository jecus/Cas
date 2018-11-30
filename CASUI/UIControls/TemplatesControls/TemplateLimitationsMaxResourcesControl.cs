using System;
using System.Drawing;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Management;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Aircrafts.Parts.Templates;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Элемент управления для отображения ограничений шаблонного агрегата
    /// </summary>
    public class TemplateDatailLimitationsMaxResourcesControl : UserControl
    {

        #region Fields

        private TemplateAbstractDetail currentDetail;
        private readonly InfoViewer maxResourcesInfo;
        private readonly InfoViewer notifyWhenRemainsInfo;
        private readonly Label labelRemark;

        #endregion

        #region Constructors

        #region public DatailLimitationsMaxResourcesControl()

        /// <summary>
        /// Создает элемент управления для отображения ограничений заданного агрегата
        /// </summary>
        public TemplateDatailLimitationsMaxResourcesControl()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            maxResourcesInfo = new InfoViewer();
            notifyWhenRemainsInfo = new InfoViewer();
            labelRemark = new Label();
            //
            // maxResourcesInfo
            //
            maxResourcesInfo.LifelengthViewer1.ShowHeaders = true;
            maxResourcesInfo.Location = new Point(0, 0);
            maxResourcesInfo.LabelTitle.Text = "Max resources";
            maxResourcesInfo.LeftHeaderWidth = 150;
            maxResourcesInfo.LifelengthViewer1.LeftHeader = "Since new";
            maxResourcesInfo.LifelengthViewer2.LeftHeader = "Since overhaul";
            maxResourcesInfo.LifelengthViewer3.LeftHeader = "Since inspection";
            maxResourcesInfo.LifelengthViewer4.LeftHeader = "Since shop visit";
            maxResourcesInfo.LifelengthViewer5.LeftHeader = "Since hot section " + "\r\n" + " inspection";
            maxResourcesInfo.ReadOnly = false;
            //
            // notifyWhenRemainsInfo
            //
            notifyWhenRemainsInfo.LifelengthViewer1.ShowHeaders = true;
            notifyWhenRemainsInfo.Location = new Point(maxResourcesInfo.Right + 100, 0);
            notifyWhenRemainsInfo.LabelTitle.Text = "Notify when remains";
            notifyWhenRemainsInfo.LeftHeaderWidth = 150;
            notifyWhenRemainsInfo.LifelengthViewer1.LeftHeader = "Since new";
            notifyWhenRemainsInfo.LifelengthViewer2.LeftHeader = "Since overhaul";
            notifyWhenRemainsInfo.LifelengthViewer3.LeftHeader = "Since inspection";
            notifyWhenRemainsInfo.LifelengthViewer4.LeftHeader = "Since shop visit";
            notifyWhenRemainsInfo.LifelengthViewer5.LeftHeader = "Since hot section " + "\r\n" + " inspection";
            notifyWhenRemainsInfo.ReadOnly = false;
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

        #region public DatailLimitationsMaxResourcesControl(TemplateAbstractDetail detail) : this()

        /// <summary>
        /// Создает элемент управления для отображения ограничений заданного агрегата
        /// </summary>
        /// <param name="detail">Текущий шаблонный агрегат</param>
        public TemplateDatailLimitationsMaxResourcesControl(TemplateAbstractDetail detail) : this()
        {
            if (detail == null)
                throw new ArgumentNullException("detail", "Argument cannot be null");
            CurrentDetail = detail;
        }

        #endregion

        #endregion

        #region Properties

        #region public TemplateAbstractDetail CurrentDetail

        /// <summary>
        /// Возвращает или устанавливает шаблонный агрегат, с которым работает данный элемент управления
        /// </summary>
        public TemplateAbstractDetail CurrentDetail
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
                return maxResourcesInfo.LifelengthViewer1.Lifelength;
            }
            set
            {
                maxResourcesInfo.LifelengthViewer1.Lifelength = value;
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
                return maxResourcesInfo.LifelengthViewer2.Lifelength;
            }
            set
            {
                maxResourcesInfo.LifelengthViewer2.Lifelength = value;
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
                return maxResourcesInfo.LifelengthViewer3.Lifelength;
            }
            set
            {
                maxResourcesInfo.LifelengthViewer3.Lifelength = value;
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
                return maxResourcesInfo.LifelengthViewer4.Lifelength;
            }
            set
            {
                maxResourcesInfo.LifelengthViewer4.Lifelength = value;
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
                return maxResourcesInfo.LifelengthViewer5.Lifelength;
            }
            set
            {
                maxResourcesInfo.LifelengthViewer5.Lifelength = value;
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
                return notifyWhenRemainsInfo.LifelengthViewer1.Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifelengthViewer1.Lifelength = value;
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
                return notifyWhenRemainsInfo.LifelengthViewer2.Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifelengthViewer2.Lifelength = value;
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
                return notifyWhenRemainsInfo.LifelengthViewer3.Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifelengthViewer3.Lifelength = value;
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
                return notifyWhenRemainsInfo.LifelengthViewer4.Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifelengthViewer4.Lifelength = value;
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
                return notifyWhenRemainsInfo.LifelengthViewer5.Lifelength;
            }
            set
            {
                notifyWhenRemainsInfo.LifelengthViewer5.Lifelength = value;
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

        #region public bool GetChangeStatus(TemplateAbstractDetail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus(TemplateAbstractDetail detail)
        {

            //return (detail.Limitation.Modified);
            throw new NotImplementedException("Methods is not implemented");
        }

        #endregion

        #region public bool GetChangeStatusOfNewDetail()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatusOfNewDetail()
        {
            return ((maxResourcesInfo.LifelengthViewer1.Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifelengthViewer2.Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifelengthViewer3.Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifelengthViewer4.Lifelength != Lifelength.NullLifelength) ||
                    (maxResourcesInfo.LifelengthViewer5.Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifelengthViewer1.Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifelengthViewer2.Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifelengthViewer3.Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifelengthViewer4.Lifelength != Lifelength.NullLifelength) ||
                    (notifyWhenRemainsInfo.LifelengthViewer5.Lifelength != Lifelength.NullLifelength));
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

        #region public void UpdateInformation(TemplateAbstractDetail sourceDetail)

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        /// <param name="sourceDetail">Агрегат по которому отображается информация</param>
        public void UpdateInformation(TemplateAbstractDetail sourceDetail)
        {
            if (sourceDetail == null) throw new ArgumentNullException("sourceDetail");
  /*          SinceNewLimitation = sourceDetail.Limitation.MaxResourceSinceNew;
            SinceLastShopVisitLimitation = sourceDetail.Limitation.MaxResourceSinceShopVisit;
            SinceLastInspectionLimitation = sourceDetail.Limitation.MaxResourceSinceInspection;
            SinceLastOverhaulLimitation = sourceDetail.Limitation.MaxResourceSinceOverhaul;
            SinceLastHotInspectionLimitation = sourceDetail.Limitation.MaxResourceSinceHotSectionInspection;

            SinceNewNotification = sourceDetail.Limitation.NotificationSinceNew;
            SinceLastShopVisitNotification = sourceDetail.Limitation.NotificationSinceShopVisit;
            SinceLastInspectionNotification = sourceDetail.Limitation.NotificationSinceInspection;
            SinceLastOverhaulNotification = sourceDetail.Limitation.NotificationSinceOverhaul;
            SinceLastHostInspectionNotification = sourceDetail.Limitation.NotificationSinceHotSectionInspection;
*/
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

        #region public void SaveData(TemplateAbstractDetail destinationDetail)

        /// <summary>
        /// Задаются данные агрегату
        /// </summary>
        /// <param name="destinationDetail">Агрегат у которого задаются данные</param>
        public void SaveData(TemplateAbstractDetail destinationDetail)
        {
            if (destinationDetail == null) throw new ArgumentNullException("destinationDetail");

            /*destinationDetail.Limitation.MaxResourceSinceNew = SinceNewLimitation;
            destinationDetail.Limitation.MaxResourceSinceShopVisit = SinceLastShopVisitLimitation;
            destinationDetail.Limitation.MaxResourceSinceInspection = SinceLastInspectionLimitation;
            destinationDetail.Limitation.MaxResourceSinceOverhaul = SinceLastOverhaulLimitation;
            destinationDetail.Limitation.MaxResourceSinceHotSectionInspection = SinceLastHotInspectionLimitation;

            destinationDetail.Limitation.NotificationSinceNew = SinceNewNotification;
            destinationDetail.Limitation.NotificationSinceShopVisit = SinceLastShopVisitNotification;
            destinationDetail.Limitation.NotificationSinceInspection = SinceLastInspectionNotification;
            destinationDetail.Limitation.NotificationSinceOverhaul = SinceLastOverhaulNotification;
            destinationDetail.Limitation.NotificationSinceHotSectionInspection = SinceLastHostInspectionNotification;*/
        }

        #endregion

        #region public void ClearAllFields()

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

        #endregion

    }
}
