using System;

namespace SmartCore.Entities.General.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ListViewDataAttribute : Attribute
    {
        private bool _readOnly = false;
        private readonly int _order = -1;
        private readonly float _headerWidth = 0.1f;
        private readonly string _title = "";

        public ListViewDataAttribute(string title)
        {
            _title = title;
        }

        public ListViewDataAttribute(string title, int order)
        {
	        _order = order;
			_title = title;
        }

		public ListViewDataAttribute(float headerWidht, string title)
        {
            _headerWidth = headerWidht;
            _title = title;
        }

        #region public ListViewDataAttribute(float headerWidht, string title, bool readOnly = false)

        /// <summary>
        /// Создает экземпляр атрибута
        /// </summary>
        /// <param name="headerWidht">Задает длину колонки. Значения больше 1 обозначают абсолютный размер в пикселях, меньше 1 - размер относительно ширины экрана</param>
        /// <param name="title">Задает текст колонки</param>
        /// <param name="readOnly">Указывает что столбец доступен тоько для чтения</param>
        public ListViewDataAttribute(float headerWidht, string title, bool readOnly = false)
        {
            _headerWidth = headerWidht;
            _title = title;
            _readOnly = readOnly;
        }
        #endregion

        #region public ListViewDataAttribute(float headerWidht, string title, int order, bool readOnly = false)

        /// <summary>
        /// Создает экземпляр атрибута
        /// </summary>
        /// <param name="headerWidht">Задает длину колонки. Значения больше 1 обозначают абсолютный размер в пикселях, меньше 1 - размер относительно ширины экрана</param>
        /// <param name="title">Задает текст колонки</param>
        /// <param name="order">Порялковый номер колонки</param>
        /// <param name="readOnly">Указывает что столбец доступен тоько для чтения</param>
        public ListViewDataAttribute(float headerWidht, string title, int order, bool readOnly = false)
        {
            _order = order;
            _headerWidth = headerWidht;
            _title = title;
            _readOnly = readOnly;
        }
        #endregion

        public float HeaderWidth
        {
            get { return _headerWidth; }
        }

        public int Order
        {
            get { return _order; }
        }

        public string Title
        {
            get { return _title; }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
        }
    }
}
