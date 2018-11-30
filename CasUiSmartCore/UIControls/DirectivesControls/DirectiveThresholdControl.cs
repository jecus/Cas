using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Calculations;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// Эу для предстваления порогового значения выполнения директивы
    ///</summary>
    public partial class DirectiveThresholdControl : ThresholdControl //UserControl, IThresholdControl
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
                if (lifelengthViewer_SinceNew.Location.X + lifelengthViewer_SinceNew.LeftHeaderWidth > width)
                    width = lifelengthViewer_SinceNew.LeftHeaderWidth + lifelengthViewer_SinceNew.Location.X;
                if (lifelengthViewer_SinceEffDate.Location.X + lifelengthViewer_SinceEffDate.LeftHeaderWidth > width)
                    width = lifelengthViewer_SinceEffDate.LeftHeaderWidth + lifelengthViewer_SinceEffDate.Location.X;
                if (lifelengthViewer_FirstNotify.Location.X + lifelengthViewer_FirstNotify.LeftHeaderWidth > width)
                    width = lifelengthViewer_FirstNotify.LeftHeaderWidth + lifelengthViewer_FirstNotify.Location.X;

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
                if (lifelengthViewer_SinceNew.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_SinceNew.WidthWithoutLeftHeader;
                if (lifelengthViewer_SinceEffDate.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_SinceEffDate.WidthWithoutLeftHeader;
                if (lifelengthViewer_FirstNotify.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_FirstNotify.WidthWithoutLeftHeader;
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
                if (lifelengthViewer_Repeat.Location.X + lifelengthViewer_Repeat.LeftHeaderWidth > width)
                    width = lifelengthViewer_Repeat.LeftHeaderWidth + lifelengthViewer_Repeat.Location.X;
                if (lifelengthViewer_RepeatNotify.Location.X + lifelengthViewer_RepeatNotify.LeftHeaderWidth > width)
                    width = lifelengthViewer_RepeatNotify.LeftHeaderWidth + lifelengthViewer_RepeatNotify.Location.X;
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
                if (lifelengthViewer_Repeat.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_Repeat.WidthWithoutLeftHeader;
                if (lifelengthViewer_RepeatNotify.WidthWithoutLeftHeader > width)
                    width = lifelengthViewer_RepeatNotify.WidthWithoutLeftHeader;
                return width;
            }
        }
        #endregion

        #endregion

        #region public Constructors
        ///<summary>
        ///</summary>
        public DirectiveThresholdControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region public override void SetFirstColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ первого GroupView-а от левого края контрола
        /// </summary>
        /// <param name="pos">отступ</param>
        public override void SetFirstColumnPos(int pos)
        {
            groupFirstPerformance.Location =
                new Point(pos - (lifelengthViewer_SinceNew.Location.X + lifelengthViewer_SinceNew.LeftHeaderWidth)
                          , groupFirstPerformance.Location.Y);
        }
        #endregion

        #region public void SetSecondColumnPos(int pos)
        /// <summary>
        /// Устанавливает отступ второго GroupView-а от левого края контрола
        /// </summary>
        /// <param name="pos">отступ</param>
        public override void SetSecondColumnPos(int pos)
        {
            groupBox_Repetative.Location =
                new Point(pos - (lifelengthViewer_Repeat.Location.X + lifelengthViewer_Repeat.LeftHeaderWidth)
                          , groupBox_Repetative.Location.Y);
        }
        #endregion

        #region protected override void ApplyThreshold(AbstractThreshold threshold)
        protected override void ApplyThreshold(IThreshold threshold)
        {
            if (threshold as DirectiveThreshold == null)
            {
                MessageBox.Show(
                    "тип переданного порогового значения не соответстует типу порогового значения данного ЭУ",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DirectiveThreshold dirThresh = threshold as DirectiveThreshold;
            // First Performance 
            radio_FirstWhicheverLast.Checked =
                dirThresh.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? false : true;

            if (dirThresh.FirstPerformanceSinceNew != null)
            {
                lifelengthViewer_SinceNew.Lifelength = dirThresh.FirstPerformanceSinceNew;
            }

            if (dirThresh.FirstPerformanceSinceEffectiveDate != null)
            {
                lifelengthViewer_SinceEffDate.Lifelength = dirThresh.FirstPerformanceSinceEffectiveDate;
            }

            if (dirThresh.FirstNotification != null)
            {
                lifelengthViewer_FirstNotify.Lifelength = dirThresh.FirstNotification;
            }

            // Repeat Interval
            radio_RepeatWhicheverLast.Checked =
                dirThresh.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? false : true;
            // Выбираем способ повторения директивы
            if (threshold.PerformRepeatedly) checkBoxRepeat.Checked = true;
            else checkBoxRepeat.Checked = false;

            radio_RepeatWhicheverFirst.Enabled = radio_RepeatWhicheverLast.Enabled =
                lifelengthViewer_Repeat.Enabled = lifelengthViewer_RepeatNotify.Enabled = checkBoxRepeat.Checked;

            if (dirThresh.RepeatInterval != null)
                lifelengthViewer_Repeat.Lifelength = dirThresh.RepeatInterval;

            if (dirThresh.RepeatNotification != null)
                lifelengthViewer_RepeatNotify.Lifelength = dirThresh.RepeatNotification;
        }
        #endregion

        #region protected override AbstractThreshold GetThreshold()
        /// <summary>
        /// Считывает все контролы и формирует один Threshold
        /// </summary>
        protected override IThreshold GetThreshold()
        {
            DirectiveThreshold threshold = new DirectiveThreshold();

            // First performance
            Lifelength sinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
            Lifelength sinceEffDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);

            threshold.FirstPerformanceSinceNew = sinceNew;
            threshold.FirstPerformanceSinceEffectiveDate = sinceEffDate;

            threshold.PerformSinceNew = sinceNew.IsNullOrZero() ? false : true;
            threshold.PerformSinceEffectiveDate = sinceEffDate.IsNullOrZero() ? false : true;

            Lifelength nfp = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
            threshold.FirstNotification = nfp;

            if (radio_FirstWhicheverFirst.Checked) threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
            if (radio_FirstWhicheverLast.Checked) threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverLater;

            // Repeat interval
            if (checkBoxRepeat.Checked)
            {
                // директива выполняется повторно
                Lifelength rp = new Lifelength(lifelengthViewer_Repeat.Lifelength);
                Lifelength nrp = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);

                threshold.PerformRepeatedly = true;
                threshold.RepeatInterval = rp;
                threshold.RepeatNotification = nrp;

                if (radio_RepeatWhicheverFirst.Checked) threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
                if (radio_RepeatWhicheverLast.Checked) threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverLater;
            }

            return threshold;
        }
        #endregion

        #endregion
    }
}
