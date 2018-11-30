namespace CAS.UI.UIControls.ReferenceControls
{
    ///<summary>
    /// Элемент управления, предназначенный для отображения статистики списка каких-либо объектов
    ///</summary>
    public partial class ObjectsListStatistics : RichReferenceContainer
    {
        #region Fields

        private int _amount;
        private string _objectText = "Aircraft";

        #endregion

        #region Properties

        #region public string ObjectText

        /// <summary>
        /// Отображаемый текст
        /// </summary>
        public string ObjectText
        {
            get { return _objectText; }
            set
            {
                _objectText = value;
                UpdateCaptions();
            }
        }

        #endregion

        #region public int Amount

        ///<summary>
        /// Количесвто ВС
        ///</summary>
        public int Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                UpdateCaptions();
            }
        }

        #endregion

        #endregion

        #region Constuctors
        ///<summary>
        /// Простои конструктор по умолчанию
        ///</summary>
        public ObjectsListStatistics()
        {
            InitializeComponent();
        }
        #endregion

        #region private void UpdateCaptions()
        private void UpdateCaptions()
        {
            labelAmount.Text = _amount + " " + _objectText;
            Caption = _objectText;
        }
        #endregion
    }
}
