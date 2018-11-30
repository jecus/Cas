using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Calculations;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class ComponentDirectiveThresholdControl : ThresholdControl
    {
        #region Properties

        #region public override int MaxFirstColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка в первой колонке
        ///</summary>
        public override int MaxFirstColLabelWidth
        {
            get
            {
                int width = 0;
                if (lifelengthViewer_FirstPerformance.LeftHeaderWidth > width)
                    width = lifelengthViewer_FirstPerformance.LeftHeaderWidth;
                if (lifelengthViewerRptInterval.LeftHeaderWidth > width)
                    width = lifelengthViewerRptInterval.LeftHeaderWidth;
                if (lifelengthViewerWarranty.LeftHeaderWidth > width)
                    width = lifelengthViewerWarranty.LeftHeaderWidth;

                return width;
            }
        }
        #endregion

        #region public override int MaxFirstColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контрола без заголовка в первой колонке
        ///</summary>
        public override int MaxFirstColControlWidth
        {
            get
            {
                int width = 0;
                if (lifelengthViewer_FirstPerformance.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_FirstPerformance.WidthWithoutLeftHeader;
                if (lifelengthViewerRptInterval.WidthWithoutLeftHeader > width)
                    width = lifelengthViewerRptInterval.WidthWithoutLeftHeader;
                if (lifelengthViewerWarranty.WidthWithoutLeftHeader > width)
                    width = lifelengthViewerWarranty.WidthWithoutLeftHeader;

                return width;
            }
        }
        #endregion

        #region public override int MaxSecondColLabelWidth
        ///<summary>
        /// Возвращает максимальную длину заголовка во второй колонке
        ///</summary>
        public override int MaxSecondColLabelWidth
        {
            get
            {
                int width = 0;
                if (lifelengthViewer_FirstNotify.LeftHeaderWidth > width)
                    width = lifelengthViewer_FirstNotify.LeftHeaderWidth;
                if (lifelengthViewerRptNotify.LeftHeaderWidth > width)
                    width = lifelengthViewerRptNotify.LeftHeaderWidth;
                if (lifelengthViewerWarrantyNotify.LeftHeaderWidth > width)
                    width = lifelengthViewerWarrantyNotify.LeftHeaderWidth;

                return width;
            }
        }
        #endregion

        #region public override int MaxSecondColControlWidth
        ///<summary>
        /// Возвращает максимальную длину контролов без заголовков во второй колонке
        ///</summary>
        public override int MaxSecondColControlWidth
        {
            get
            {
                int width = 0;
                if (lifelengthViewer_FirstNotify.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_FirstNotify.WidthWithoutLeftHeader;
                if (lifelengthViewerRptNotify.WidthWithoutLeftHeader > width)
                    width = lifelengthViewerRptNotify.WidthWithoutLeftHeader;
                if (lifelengthViewerWarrantyNotify.WidthWithoutLeftHeader > width)
                    width = lifelengthViewerWarrantyNotify.WidthWithoutLeftHeader;

                return width;
            }
        }
        #endregion
       
        #endregion

        #region public override void SetFirstColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ первой колонки от левого края контрола
        /// (выравнивание производится по 1 textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        public override void SetFirstColumnPos(int pos)
        {
            lifelengthViewer_FirstPerformance.Location = 
                new Point(pos - lifelengthViewer_FirstPerformance.LeftHeaderWidth, lifelengthViewer_FirstPerformance.Location.Y);

            lifelengthViewerRptInterval.Location =
                new Point(pos - lifelengthViewerRptInterval.LeftHeaderWidth, lifelengthViewerRptInterval.Location.Y);

            lifelengthViewerWarranty.Location =
                new Point(pos - lifelengthViewerWarranty.LeftHeaderWidth, lifelengthViewerWarranty.Location.Y);   

            radio_WhicheverFirst.Location = new Point(lifelengthViewer_FirstPerformance.Location.X
                                                      + lifelengthViewer_FirstPerformance.Width
                                                      - radio_WhicheverFirst.Width, 
                                                      radio_WhicheverFirst.Location.Y);
        }
        #endregion

        #region public override void SetSecondColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ второй колонки от левого края контрола
        /// (выравнивание производится по 1-му textbox-у lifelenghtviewer-а)
        /// </summary>
        /// <param name="pos">отступ</param>
        public override void SetSecondColumnPos(int pos)
        {
            lifelengthViewer_FirstNotify.Location =
                new Point(pos - lifelengthViewer_FirstNotify.LeftHeaderWidth, lifelengthViewer_FirstNotify.Location.Y);

            lifelengthViewerRptNotify.Location =
                new Point(pos - lifelengthViewerRptNotify.LeftHeaderWidth, lifelengthViewerRptNotify.Location.Y);

            lifelengthViewerWarrantyNotify.Location =
                new Point(pos - lifelengthViewerWarrantyNotify.LeftHeaderWidth, lifelengthViewerWarrantyNotify.Location.Y);
           
            radio_WhicheverLater.Location = new Point(lifelengthViewer_FirstNotify.Location.X,
                                                      radio_WhicheverLater.Location.Y);
        }
        #endregion

        #region public DetailDirectiveThresholdControl()
        ///<summary>
        ///</summary>
        public ComponentDirectiveThresholdControl()
        {
            InitializeComponent();
        }
        #endregion

        #region protected override void ApplyThreshold(AbstractThreshold threshold)
        protected override void ApplyThreshold(IThreshold threshold)
        {
            if (threshold as ComponentDirectiveThreshold == null)
            {
                MessageBox.Show(
                    "тип переданного порогового значения не соответстует типу порогового значения данного ЭУ",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ComponentDirectiveThreshold detDirThresh = threshold as ComponentDirectiveThreshold;

            lifelengthViewer_FirstPerformance.Lifelength = detDirThresh.FirstPerformanceSinceNew;
            lifelengthViewer_FirstNotify.Lifelength = detDirThresh.FirstNotification;
            lifelengthViewerRptInterval.Lifelength = detDirThresh.RepeatInterval;
            lifelengthViewerRptNotify.Lifelength = detDirThresh.RepeatNotification;
            lifelengthViewerWarranty.Lifelength = detDirThresh.Warranty;
            lifelengthViewerWarrantyNotify.Lifelength = detDirThresh.WarrantyNotification;

            if (detDirThresh.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                radio_WhicheverFirst.Checked = true;
            else radio_WhicheverLater.Checked = true;
        }
        #endregion

        #region protected override AbstractThreshold GetThreshold()
        /// <summary>
        /// Считывает все контролы и формирует один Threshold
        /// </summary>
        protected override IThreshold GetThreshold()
        {
            ComponentDirectiveThreshold threshold = new ComponentDirectiveThreshold();

            threshold.FirstPerformanceSinceNew = lifelengthViewer_FirstPerformance.Lifelength;
            threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
            threshold.RepeatInterval = lifelengthViewerRptInterval.Lifelength;
            threshold.RepeatNotification = lifelengthViewerRptNotify.Lifelength;
            threshold.Warranty = lifelengthViewerWarranty.Lifelength;
            threshold.WarrantyNotification = lifelengthViewerWarrantyNotify.Lifelength;
            threshold.FirstPerformanceConditionType = radio_WhicheverFirst.Checked
                                                      ? ThresholdConditionType.WhicheverFirst
                                                      : ThresholdConditionType.WhicheverLater; 

            return threshold;
        }
        #endregion
    }
}
