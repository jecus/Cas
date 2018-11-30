using System.Drawing;

namespace CAS.UI.UIControls.Auxiliary.Importing
{
    ///<summary>
    /// Эу для предстваления порогового значения выполнения директивы
    ///</summary>
    public partial class ImportDirectiveThresholdControl : ThresholdControl //UserControl, IThresholdControl
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
                if (labelSinceNew.Location.X + labelSinceNew.Width > width)
                    width = labelSinceNew.Location.X + labelSinceNew.Width;
                if (labelSinceEffDate.Location.X + labelSinceEffDate.Width > width)
                    width = labelSinceEffDate.Location.X + labelSinceEffDate.Width;
                if (labelWhichEverOccures.Location.X + labelWhichEverOccures.Width > width)
                    width = labelWhichEverOccures.Location.X + labelWhichEverOccures.Width;

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
                if ((comboBoxCalandarNew.Location.X + comboBoxCalandarNew.Width) - comboBoxNewHours.Location.X > width)
                    width = (comboBoxCalandarNew.Location.X + comboBoxCalandarNew.Width) - comboBoxNewHours.Location.X;
                if ((comboBoxCanendarEffDate.Location.X + comboBoxCanendarEffDate.Width) - comboBoxEffDateHours.Location.X > width)
                    width = (comboBoxCanendarEffDate.Location.X + comboBoxCanendarEffDate.Width) - comboBoxEffDateHours.Location.X;
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
                if (labelRepeat.Location.X + labelRepeat.Width > width)
                    width = labelRepeat.Location.X + labelRepeat.Width;
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
                if ((comboBoxCalendarRepeat.Location.X + comboBoxCalendarRepeat.Width) - comboBoxHoursRepeat.Location.X > width)
                    width = (comboBoxCalendarRepeat.Location.X + comboBoxCalendarRepeat.Width) - comboBoxHoursRepeat.Location.X;
                return width;
            }
        }
        #endregion

        #endregion

        #region public Constructors
        ///<summary>
        ///</summary>
        public ImportDirectiveThresholdControl()
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
                new Point(pos - comboBoxEffDateHours.Location.X, groupFirstPerformance.Location.Y);
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
                new Point(pos - comboBoxHoursRepeat.Location.X, groupBox_Repetative.Location.Y);
        }
        #endregion

        #endregion
    }
}
