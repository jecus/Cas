using System;

namespace SmartCore.Entities.General.Attributes
{
    /// <summary>
    /// Атрибут, указывающий что свойсто может быть импортировано с таблиц Excel
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelImportAttribute : Attribute
    {
        private int _order = -1;
        private int _width = 100;
        private string _title = "";

        private string _pairControlPropertyName = "";
        private int _pairControlWidht = 20;
        private bool _pairControlEnabled = true;
        private bool _pairControlBefore;

        public ExcelImportAttribute(string title)
        {
            _title = title;
        }

        public ExcelImportAttribute(int widht, string title)
        {
            _width = widht;
            _title = title;
        }

        #region public ExcelImportAttribute(int widht, string title, string pairControlPropertyName, int pairControlWidth, bool pairControlBefore, bool pairControlEnabled)
        /// <summary>
        /// Создает объект с дополнительными параметрами
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="title"></param>
        /// <param name="pairControlPropertyName">Имя своиста парного контрола (Н: другого булевого своиства, опред. применимость данного своиства)</param>
        /// <param name="pairControlWidth">Длина парного контрола</param>
        /// <param name="pairControlBefore">Парный контрол будет находится перед данным контролом</param>
        /// <param name="pairControlEnabled">Парный контрол доступен</param>
        public ExcelImportAttribute(int widht, string title,
                                    string pairControlPropertyName, int pairControlWidth,
                                    bool pairControlBefore = false, bool pairControlEnabled = true
            )
        {
            _width = widht;
            _title = title;
            _pairControlPropertyName = pairControlPropertyName;
            _pairControlWidht = pairControlWidth;
            _pairControlBefore = pairControlBefore;
            _pairControlEnabled = pairControlEnabled;
        }

        #endregion

        public int Width
        {
            get { return _width; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public string Title
        {
            get { return _title; }
        }

        #region public string PairControlPropertyName
        /// <summary>
        /// имя своиства, определяющего парный контрол
        /// </summary>
        public string PairControlPropertyName
        {
            get { return _pairControlPropertyName; }
        }
        #endregion

        #region public int PairControlWidht
        /// <summary>
        /// Длина парного контрола
        /// </summary>
        public int PairControlWidht
        {
            get { return _pairControlWidht; }
        }
        #endregion

        #region public bool PairControlBafore
        /// <summary>
        /// Парный контрол находится перед текущим контролом
        /// </summary>
        public bool PairControlBafore
        {
            get { return _pairControlBefore; }
        }
        #endregion

        #region public bool PairControlEnabled
        /// <summary>
        /// Доступен ли парный контрол
        /// </summary>
        public bool PairControlEnabled
        {
            get { return _pairControlEnabled; }
        }
        #endregion
    }
}
