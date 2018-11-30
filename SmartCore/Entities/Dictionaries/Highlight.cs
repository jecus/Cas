using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class Highlight
    {
        #region private static List<Highlight> _Items = new List<Highlight>();
        /// <summary>
        /// Содержит все элементы - это пригодиться нам, когда мы захотим получить тип базового агрегата по его id
        /// </summary>
        private static List<Highlight> _Items = new List<Highlight>();
        #endregion

        public static IEnumerable<Highlight> HighlightList
        {
            get
            {
                return _Items;
            }
        }

        /*
         * Предопределенные типы
         */

        #region public static Highlight Blue = new Highlight(1, "Blue", "Blue", -3618561, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight Blue = new Highlight(1, "Blue", "Blue", -3618561, -16777216);
        #endregion

        #region public static Highlight Green = new Highlight(2, "Green", "Green", -6422619, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight Green = new Highlight(2, "Green", "Green", -6422619, -16777216);
        #endregion

        #region public static Highlight Yellow = new Highlight(3, "Yellow", "Yellow", -76, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight Yellow = new Highlight(3, "Yellow", "Yellow", -76, -16777216);
        #endregion

        #region public static Highlight White = new Highlight(4, "White", "White", -1, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight White = new Highlight(4, "White", "White", -1, -16777216);
        #endregion

        #region public static Highlight Grey = new Highlight(5, "Grey", "Grey", -4144960, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight Grey = new Highlight(5, "Grey", "Grey", -4144960, -16777216);
		#endregion

		#region public static Highlight GrayLight = new Highlight(5, "GrayLight", "GrayLight", -3092272, -16777216);
		/// <summary>
		/// 
		/// </summary>
		public static Highlight GrayLight = new Highlight(5, "GrayLight", "GrayLight", -3092272, -16777216);
        #endregion

        #region public static Highlight Red = new Highlight(6, "Red", "Red", -21846, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight Red = new Highlight(6, "Red", "Red", -21846, -16777216);
        #endregion

        #region public static Highlight PurpleLight = new Highlight(7, "PurpleLight", "PurpleLight", -32513, -16777216);
        /// <summary>
        /// 
        /// </summary>
        public static Highlight PurpleLight = new Highlight(7, "PurpleLight", "PurpleLight", -32513, -16777216);
		#endregion

	    public static Highlight DarkGreen = new Highlight(8, "DarkGreen", "DarkGreen", System.Drawing.Color.MediumSeaGreen.ToArgb(), -16777216);
	    public static Highlight Orange = new Highlight(9, "Orange", "Orange", System.Drawing.Color.Orange.ToArgb(), -16777216);


		/*
         * Методы
         */

		#region public static Highlight GetHighlightById(Int32? id)

		/// <summary>
		/// Возвращает тип базового агрегата по его Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Highlight GetHighlightById(Int32? id)
        {
            foreach (Highlight t in _Items)
                if (t.ItemId == id)
                    return t;
            //
            return White;
        }

        #endregion

        #region public override string ToString()
        /// <summary> 
        /// Представляет тип агрегата в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName;
        }
        #endregion

        /*
         * Свойства
         */

        #region public Int32 ItemID { get; set; }


        /// <summary>
        /// номер записи в базе данных
        /// </summary>
        public Int32 ItemId { get; set; }

        #endregion

        #region         public String ShortName { get; set; }


        /// <summary>
        /// Короткое имя
        /// </summary>
        public String ShortName { get; set; }

        #endregion

        #region public String FullName { get; set; }


        /// <summary>
        /// Полное имя
        /// </summary>
        public String FullName { get; set; }

        #endregion

        #region public Int32 Color { get; set; }


        /// <summary>
        /// Цвет 
        /// </summary>
        public Int32 Color { get; set; }

        #endregion

        #region public Int32 FaceColor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 FaceColor { get; set; }

		#endregion

		/*
         * Реализация
         */

		#region public Highlight(int itemId, string shortName, string fullName, int color, int faceColor)

		/// <summary>
		/// Конструктор создает запись о типе агрегата
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="color"></param>
		/// <param name="faceColor"></param>
		public Highlight(int itemId, string shortName, string fullName, int color, int faceColor)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            Color = color;
            FaceColor = faceColor;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    }
}
