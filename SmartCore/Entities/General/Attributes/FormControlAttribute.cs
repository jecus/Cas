using System;
using System.Collections.Generic;

namespace SmartCore.Entities.General.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormControlAttribute : Attribute
    {
        private int _order = -1;
        private int _width = 100;
        private int _height;
        private int _lines = 1;
        private bool _richTextBox;
        private string _title = "";
        private bool _enabled = true;

        private string _bindToProperty;
        private string _bindToPropertyPropertyName;
        private bool _enableIfNotNull = true;

        private string _pairControlPropertyName = "";
        private int _pairControlWidht = 20;
        private bool _pairControlEnabled = true;
        private bool _pairControlBefore;

        private List<string> _listViewPropertiesNames = new List<string>();
        private string[] _treeDictNodes = new string[0]; 
        public FormControlAttribute(string title)
        {
            _title = title;
        }

        public FormControlAttribute(int widht, string title)
        {
            _width = widht;
            _title = title;
        }

        public FormControlAttribute(int widht, string title, int lines)
        {
            _lines = lines;
            _width = widht;
            _title = title;
        }

        public FormControlAttribute(int widht, string title, int lines, bool richTextBox = false)
        {
            _lines = lines;
            _width = widht;
            _title = title;
            _richTextBox = richTextBox;
        }

        /// <summary>
        /// Создает артибут обозначающий что свойсто может отображаться в форме для редактирования в ввиде ЭУ
        /// </summary>
        /// <param name="widht">Длина ЭУ</param>
        /// <param name="title">Текст надписи</param>
        /// <param name="lines">кол-во линий ЭУ (для текствых свойств и коллекций)</param>
        /// <param name="listViewPropertiesNames">Своиства типа помеченного данным атрибутом свойства, 
        /// <br/>которые будут использоваться для создания и заполнения колонок списка элементов
        /// <br/>Только для коллекций</param>
        public FormControlAttribute(int widht, string title, int lines, string[] listViewPropertiesNames)
        {
            _lines = lines;
            _width = widht;
            _title = title;

            if (listViewPropertiesNames.Length > 0)
            {
                if(_listViewPropertiesNames == null)
                    _listViewPropertiesNames = new List<string>();
                _listViewPropertiesNames.Clear();

                _listViewPropertiesNames.AddRange(listViewPropertiesNames);
            }
        }

        /// <summary>
        /// Создает артибут обозначающий что свойсто может отображаться в форме для редактирования в ввиде ЭУ
        /// </summary>
        /// <param name="widht">Длина ЭУ</param>
        /// <param name="title">Текст надписи</param>
        /// <param name="bindToProperty">Своиство в том же типе, что и своиство, помеченное данным атрибутом, 
        /// <br/>от которого зависит значение данного свойства</param>
        /// <param name="bindToPropertyPropertyName">Название свойства в типе свойства с которым связано данное свойство</param>
        /// <param name="enableIfNotNull">Может ли пользователь менять значение данного свойства в ЭУ, 
        /// <br/>если значение свойства, от которого оно зависит !NULL</param>
        public FormControlAttribute(int widht, string title, string bindToProperty, string bindToPropertyPropertyName, bool enableIfNotNull)
        {
            _width = widht;
            _title = title;
            _bindToProperty = bindToProperty;
            _bindToPropertyPropertyName = bindToPropertyPropertyName;
            _enableIfNotNull = enableIfNotNull;
        }

        /// <summary>
        /// Создает артибут обозначающий что свойсто может отображаться в форме для редактирования в ввиде ЭУ
        /// </summary>
        /// <param name="widht">Длина ЭУ</param>
        /// <param name="title">Текст надписи</param>
        /// <param name="lines">кол-во линий ЭУ (для текствых свойств и коллекций)</param>
        /// <param name="bindToProperty">Своиство в том же типе, что и своиство, помеченное данным атрибутом, 
        /// <br/>от которого зависит значение данного свойства</param>
        /// <param name="bindToPropertyPropertyName">Название свойства в типе свойства с которым связано данное свойство</param>
        /// <param name="enableIfNotNull">Может ли пользователь менять значение данного свойства в ЭУ, 
        /// <br/>если значение свойства, от которого оно зависит !NULL</param>
        public FormControlAttribute(int widht, string title, int lines, string bindToProperty, string bindToPropertyPropertyName, bool enableIfNotNull)
        {
            _lines = lines;
            _width = widht;
            _title = title;
            _bindToProperty = bindToProperty;
            _bindToPropertyPropertyName = bindToPropertyPropertyName;
            _enableIfNotNull = enableIfNotNull;
        }

        #region public FormControlAttribute(int widht, string title, int lines, string pairControlPropertyName, int pairControlWidth, bool pairControlBefore, bool pairControlEnabled)
        /// <summary>
        /// Создает объект с дополнительными параметрами
        /// </summary>
        /// <param name="widht"></param>
        /// <param name="title"></param>
        /// <param name="lines"></param>
        /// <param name="pairControlPropertyName">Имя своиста парного контрола (Н: другого булевого своиства, опред. применимость данного своиства)</param>
        /// <param name="pairControlWidth">Длина парного контрола</param>
        /// <param name="pairControlBefore">Парный контрол будет находится перед данным контролом</param>
        /// <param name="pairControlEnabled">Парный контрол доступен</param>
        public FormControlAttribute(int widht, string title, int lines,
                                    string pairControlPropertyName, int pairControlWidth,
                                    bool pairControlBefore = false, bool pairControlEnabled = true
            )
        {
            _lines = lines;
            _width = widht;
            _title = title;
            _pairControlPropertyName = pairControlPropertyName;
            _pairControlWidht = pairControlWidth;
            _pairControlBefore = pairControlBefore;
            _pairControlEnabled = pairControlEnabled;
        }

        #endregion

        public int Lines
        {
            get { return _lines; }
        }

        public List<string> ListViewPropertiesNames
        {
            get { return _listViewPropertiesNames; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
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

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public bool RichTextBox
        {
            get { return _richTextBox; }
            set { _richTextBox = value; }
        }

        /// <summary>
        /// Возвращает узлы древовидного словаря, которые требуется отобразить в контроле
        /// </summary>
        public string[] TreeDictRootNodes
        {
            get { return _treeDictNodes; }
            set { _treeDictNodes = value; }
        }

        /// <summary>
        /// Возвращает своиство в том же типе, что и своиство, помеченное данным атрибутом, 
        /// <br/>от которого зависит значение данного свойства
        /// </summary>
        public string BindToProperty
        {
            get { return _bindToProperty; }
        }

        /// <summary>
        /// Возвращает название свойства в типе свойства с которым связано данное свойство
        /// </summary>
        public string BindToPropertyPropertyName
        {
            get { return _bindToPropertyPropertyName; }
        }

        /// <summary>
        /// Возвращает значение может ли пользователь менять значение данного свойства в ЭУ, 
        /// <br/>если значение свойства, от которого оно зависит !NULL
        /// </summary>
        public bool EnableIfNotNull
        {
            get { return _enableIfNotNull; }
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
