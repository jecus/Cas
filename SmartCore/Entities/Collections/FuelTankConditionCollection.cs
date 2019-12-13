using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Collections
{


    /// <summary>
    /// Содержит состояние всех топливных баков воздушного судна
    /// </summary>
    [Serializable]
    public class FuelTankConditionCollection// : StringConvertibleCollection
    {

        /*
         * Реализация коллекции
         */

        #region private List<FuelTankCondition> _Tanks = new List<FuelTankCondition>();
        /// <summary>
        /// Внутренняя коллекция всех топливных баков
        /// </summary>
        private List<FuelTankCondition> _Tanks = new List<FuelTankCondition>();
        #endregion

        #region public FuelTankCondition this[int index]
        /// <summary>
        /// Состояние топливного бака под указанным порядковым номером
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FuelTankCondition this[int index]
        {
            get { return _Tanks[index]; }
            set { _Tanks[index] = value; }
        }
        #endregion

        #region public int Count
        /// <summary>
        /// Количество топливных баков
        /// </summary>
        public int Count
        {
            get { return _Tanks.Count; }
        }
        #endregion

        #region public void Add(FuelTankCondition tank)
        /// <summary>
        /// Добавляет информацию о топливном баке в коллекцию
        /// </summary>
        public void Add(FuelTankCondition tank)
        {
            _Tanks.Add(tank);
        //    tank.DataChange += FuelTankConditionCollection_DataChange;
        //    OnCollectionChange();
        }
        #endregion

        #region public void RemoveAt(int index)
        /// <summary>
        /// Удаляет информацию о баке под заданным номером
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            _Tanks.RemoveAt(index);
        //    OnCollectionChange();
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Возвращает количество элементов в коллекции
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Count = " + _Tanks.Count;
        }
        #endregion

        #region public string CollectionToString()
        /// <summary>
        /// Преобразует объекты коллекции в String
        /// </summary>
        /// <returns></returns>
        public string CollectionToString()
        {
            string collection = string.Empty;
            for (int i = 0; i < _Tanks.Count; i++)
            {
                collection += _Tanks[i].ToString();

                if (i < (_Tanks.Count - 1))
                {
                    collection += ":";
                }
            }
            return collection;
        }
        #endregion

        #region public void StringToCollection(string Data)
        /// <summary>
        /// Преобразует String в коллекцию
        /// </summary>
        /// <returns></returns>
        public void StringToCollection(string Data)
        {
            if (Data == null)
                return;
            // Разбиваем по разделителю
            string[] values = Data.Split(new char[] { ':' });

            SetObjects(values);

            if (_Tanks.Count == 0)
            {
                //в БД не нашлось записей по данному ВС
                //GlobalObjects.CasEnvironment.BaseDetails[index].DetailType.ItemId == 3;
            }
        }
        #endregion
        /*
         * Дополнительное свойство
         */

        #region public FuelTankCondition TotalFuel
        /// <summary>
        /// Общее состояние всех баков
        /// </summary>
        public FuelTankCondition TotalFuel
        {
            get
            {
                FuelTankCondition tank = new FuelTankCondition();
                tank.Tank = "Total";
                for (int i = 0; i < _Tanks.Count; i++)
                {
                    tank.Remaining += _Tanks[i].Remaining;
                    tank.OnBoard += _Tanks[i].OnBoard;
                    tank.Correction += _Tanks[i].Correction;
                    tank.ActualUpliftLit += _Tanks[i].ActualUpliftLit;
                    tank.Density += _Tanks[i].Density;
                    tank.CalculateUplift += _Tanks[i].CalculateUplift;
                    tank.Discrepancy += _Tanks[i].Discrepancy;
                }

                //
                return tank;
            }
        }
        #endregion

        /*
         * Два конструктора
         */

        #region public FuelTankConditionCollection()
        /// <summary>
        /// Создает пустую коллекцию топливных баков ВС
        /// </summary>
        public FuelTankConditionCollection()
        {
        }
        #endregion

        #region public FuielTankConditionCollection(string Data) : base (Data)
        /// <summary>
        /// Создает и заполняет коллекцию топливных баков ВС
        /// </summary>
        /// <param name="Data"></param>
        public FuelTankConditionCollection(string Data)
        //    : base(Data)
        {
        }
        #endregion

        /*
        * Реализация StringConvertibleCollection
        */

        #region protected override string[] GetObjects()
        /// <summary>
        /// Представляет коллекцию в виде массива строк
        /// </summary>
        /// <returns></returns>
        protected/* override*/ string[] GetObjects()
        {
            string[] objects = new string[_Tanks.Count];
            for (int i = 0; i < _Tanks.Count; i++)
                objects[i] = _Tanks[i].ToString();

            //
            return objects;
        }
        #endregion

        #region protected override void SetObjects(string[] objects)
        /// <summary>
        /// Загружает всю коллекцию из объектов строк
        /// </summary>
        /// <param name="objects"></param>
        protected /*override*/ void SetObjects(string[] objects)
        {
            _Tanks.Clear();
            for (int i = 0; i < objects.Length; i++)
            {
                _Tanks.Add(new FuelTankCondition(objects[i]));
            //    _Tanks[i].DataChange += FuelTankConditionCollection_DataChange;
            }

            
        }

        #endregion

        #region void FuelTankConditionCollection_DataChange(object sender, EventArgs e)

        void FuelTankConditionCollection_DataChange(object sender, EventArgs e)
        {
        //    OnCollectionChange();
        }

        #endregion

    }


}
