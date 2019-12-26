using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using SmartCore.Aircrafts;
using SmartCore.Calculations;
using SmartCore.DtoHelper;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkShop;

namespace SmartCore.Management
{
    /// <summary>
    /// Осуществляет конвертацию между стандартными типами и типами базы данных
    /// </summary>
    public static class DbTypes
    {
        private static CasEnvironment _casEnvironment;
        public static CasEnvironment CasEnvironment
        {
            set { _casEnvironment = value; }
        }

		private static IAircraftsCore _aircraftsCore;
		public static IAircraftsCore AircraftsCore
		{
			set { _aircraftsCore = value; }
		}


		#region public static string TimeToString(TimeSpan time)
		/// <summary>
		/// Представляет время в виде строки
		/// </summary>
		/// <returns></returns>
		public static int TimeToInt(TimeSpan time)
        {
            //Переводим в минуты и сохраняем в виде строки
            int m = time.Hours * 60 + time.Minutes;
            return m;
        }
        #endregion

        #region public static TimeSpan ToTime(string o)
        /// <summary> 
        /// Переводит строку (количество минут) в дату
        /// </summary>
        /// <returns></returns>
        public static TimeSpan ToTime(object o)
        {
            TimeSpan time = new TimeSpan(0);
            if (o == null || o == DBNull.Value) return time;

            int i = (int)o;
            time = time.Add(new TimeSpan(0, i, 0));
            return time;
        }
        #endregion

		#region DateTime ToDateTime(object)
		/// <summary>
		/// Переводит дату из формата базы данных в обычную дату
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static DateTime ToDateTime(object o)
		{
		    if (o == null || o == DBNull.Value)
				return new DateTime();
		    return (DateTime)o;
		}

        #endregion

		#region DateTime? ToDateTimeNullable (object)
		/// <summary>
		/// Переводит дату из формата базы данных в обычную дату. Поддерживает значение null
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static DateTime? ToDateTimeNullable(object o)
		{
		    if (o == null || o == DBNull.Value)
				return null;
		    return (DateTime)o;
		}

        #endregion

        #region public static Int32 ToInt32(object o)
        /// <summary>
		/// Возвращает целое из объекта базы данных
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static Int32 ToInt32(object o)
        {
            if (o == null || o == DBNull.Value)
				return new int();
            return Convert.ToInt32 (o);
        }

        #endregion

		#region public static Int32? ToInt32Nullable (object o)
		/// <summary>
		/// Возвращает целое из объекта базы данных
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static Int32? ToInt32Nullable(object o)
		{
		    if (o == null || o == DBNull.Value)
				return null;
		    return Convert.ToInt32(o);
		}

        #endregion

		#region public static string ToString(object o)
		/// <summary>
		/// Возвращает строку из объекта базы данных
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static string ToString(object o)
		{
		    if (o == null || o == DBNull.Value)
				return "";
		    return (string)o;
		}

        #endregion

		#region object dbObject (object o)
		/// <summary>
		/// Возвращает пригодное для базы данных значение объекта
		/// </summary>
        /// <param name="o"></param>
		/// <returns></returns>
		public static object DbObject(object o)
		{
            if (o == null)
                return DBNull.Value;
            if (o is BaseEntityObject) 
                return ((BaseEntityObject)o).ItemId;
            if (o is IBaseEntityObject)
                return ((IBaseEntityObject)o).ItemId;
		    if (o is DateTime)
		    {
			    //return ((DateTime) o).ToSqlDate();
			    return (((DateTime)o).Day + "." + ((DateTime)o).Month + "." + ((DateTime)o).Year + " " +
			          ((DateTime)o).TimeOfDay.Hours + ":" + ((DateTime)o).TimeOfDay.Minutes + ":" + ((DateTime)o).TimeOfDay.Seconds);

		    }
            if (o is TimeSpan) return TimeToInt((TimeSpan) o);
            if (o is AverageUtilization) 
                return ((AverageUtilization)o).ConvertToByteArray();
            if (o is ComponentDirectiveThreshold)
                return ((ComponentDirectiveThreshold)o).ToBinary();
            if (o is DirectiveThreshold) 
                return ((DirectiveThreshold) o).ToBinary();
            if (o is Highlight) return ((Highlight)o).Color;
            if (o is Lifelength) return ((Lifelength) o).ConvertToByteArray();
            if (o is MaintenanceDirectiveThreshold)
                return ((MaintenanceDirectiveThreshold)o).ToBinary();
			if (o is TrainingThreshold)
				return ((TrainingThreshold)o).ToBinary();
			if (o.GetType().IsEnum)
                return Convert.ToInt16(o);
            return o;
		}
		#endregion

        #region static string DbObjectString (object o)
        /// <summary>
        /// Возвращает пригодное для базы данных значение объекта
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string DbObjectString(object o)
        {
            if (o == null)
                return "is null";
            if (o is BaseEntityObject)
                return ((BaseEntityObject)o).ItemId.ToString();
            if (o is IBaseEntityObject)
                return ((IBaseEntityObject)o).ItemId.ToString();
            if (o is DateTime)
            {
                return (((DateTime)o).Day + "." + ((DateTime)o).Month + "." + ((DateTime)o).Year + " " +
                        ((DateTime)o).TimeOfDay.Hours + ":" + ((DateTime)o).TimeOfDay.Minutes + ":" + ((DateTime)o).TimeOfDay.Seconds);

            }
            if (o is TimeSpan) return TimeToInt((TimeSpan)o).ToString();
            if (o is bool) return ((bool) o) ? "'true'" : "'false'";
            if (o is string) return "'" + o + "'";
            if (o is Highlight) return ((Highlight)o).Color.ToString();
            return o.ToString();
        }
        #endregion

        #region private static SqlDbType GetSqlDbType(Type type)
        private static SqlDbType GetSqlDbType(Type type)
        {
            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (type.IsSubclassOf(typeof(BaseEntityObject)))
                return SqlDbType.Int;
            if (type.IsEnum)
                return SqlDbType.SmallInt;
            Type nullable = Nullable.GetUnderlyingType(type);
            if (nullable != null)
            {
                string typeName = nullable.Name.ToLower();
                switch (typeName)
                {
                    case "int32": return SqlDbType.Int;
                    case "int16": return SqlDbType.SmallInt;
                    case "datetime": return SqlDbType.DateTime;
                    case "bool": return SqlDbType.Bit;
                    case "boolean": return SqlDbType.Bit;
                    case "double": return SqlDbType.Float;
                    default: return SqlDbType.NVarChar;
                }
            }
            else
            {
                string typeName = type.Name.ToLower();
                switch (typeName)
                {
                    case "averageutilization": return SqlDbType.VarBinary;
                    case "bool": return SqlDbType.Bit;
                    case "boolean": return SqlDbType.Bit;
                    case "byte[]": return SqlDbType.VarBinary;
                    case "datetime": return SqlDbType.DateTime;
                    case "componentdirectivethreshold": return SqlDbType.VarBinary;
                    case "directivethreshold": return SqlDbType.VarBinary;
                    case "trainingthreshold": return SqlDbType.VarBinary;
                    case "double": return SqlDbType.Float;
                    case "highlight": return SqlDbType.Int;
                    case "int16": return SqlDbType.SmallInt;
                    case "int32": return SqlDbType.Int;
                    case "lifelength": return SqlDbType.VarBinary;
                    case "maintenancedirectivethreshold": return SqlDbType.VarBinary;
                    case "string": return SqlDbType.NVarChar;
                    case "timespan": return SqlDbType.Int;

                    default: return SqlDbType.NVarChar;
                }
            }
        }
        #endregion

        #region public static SqlParameter SqlParameter(string name, object o)

        /// <summary>
        /// Преобразует значение в SqlParameter
        /// </summary>
        /// <param name="name">Имя параметра</param>
        /// <param name="objectType">Тип объета для преобразования</param>
        /// <param name="o">Объект для преобразования</param>
        /// <returns></returns>
        public static SqlParameter SqlParameter(string name, Type objectType, object o)
        {
            object dbvalue = DbObject(o);
            SqlParameter parameter = new SqlParameter();
            if (dbvalue == DBNull.Value)
            {
                parameter.IsNullable = true;
                parameter.ParameterName = name;
                parameter.SqlDbType = GetSqlDbType(objectType);
                parameter.SqlValue = dbvalue;
            }
            else
            {
                parameter.ParameterName = name;
                parameter.Value = dbvalue;
            }
            return parameter;
        }
        #endregion

		#region bool ToBool(object)
		/// <summary>
		/// Возвращает булево значение
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static bool ToBool(object o)
		{
		    if (o == null || o == DBNull.Value)
				return false;
		    return (bool)o;
		}

        #endregion

		#region bool? ToBoolNullable (object o)
		/// <summary>
		/// Возвращает булево значение, допускающее null
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static bool? ToBoolNullable(object o)
		{
		    if (o == null || o == DBNull.Value)
				return null;
		    return (bool)o;
		}

        #endregion

		#region byte[] ToBytes(object o)
		/// <summary>
		/// Возвращает массив байтов. Null допускается
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static byte[] ToBytes(object o)
		{
		    if (o == null || o == DBNull.Value)
				return null;
		    return (byte[])o;
		}

        #endregion

        #region double ToDouble (object)
        /// <summary>
        /// Возвращает с плавающей точкой из объекта базы данных
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Double ToDouble(object o)
        {
            if (o == null || o == DBNull.Value)
                return new int();
            return Convert.ToDouble(o);
        }

        #endregion

        #region double ToDoubleNullable (object)
        /// <summary>
        /// Возвращает с плавающей точкой из объекта базы данных
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static double? ToDoubleNullable(object o)
        {
            if (o == null || o == DBNull.Value)
                return null;
            return Convert.ToDouble(o);
        }

        #endregion

        #region Int16 ToInt16 (object)
        /// <summary>
        /// Возвращает целое 16bit из объекта базы данных
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Int16 ToInt16(object o)
        {
            if (o == null || o == DBNull.Value)
                return new int();
            return Convert.ToInt16(o);
        }

        #endregion

        #region Int16 ToInt16Nullable (object)
        /// <summary>
        /// Возвращает целое 16bit из объекта базы данных
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Int16? ToInt16Nullable(object o)
        {
            if (o == null || o == DBNull.Value)
                return null;
            return Convert.ToInt16(o);
        }

        #endregion

        #region public static Int64 Int64FromByteArray(byte[] data, int sourceStartIndex)

        public static Int64 Int64FromByteArray(byte[] data, int sourceStartIndex)
        {
            int typeSize = sizeof(Int64);
            const Int32 bitsInByte = 8;
            Int64 result = 0;

            if (null == data) throw new ArgumentNullException("data", "Parameter must not be null");
            if (sizeof(Int64) + sourceStartIndex > data.Length) throw new ArgumentException("Copied length must be non less than " + typeSize);

            for (int i = 0; i < typeSize; i++)
            {
                result |= (Int64)data[i + sourceStartIndex] << (i * bitsInByte);
            }

            return result;
        }

        #endregion

        #region public static byte[] Int64ToByteArray(Int64 value)
        /// <summary>
        /// Сериализует значение числа типа <see cref="Int64"/> побайтово в массив байтов. 
        /// Младший байт числа будет сохранён в нулевой элемент массива и т. д.
        /// </summary>
        /// <param name="value">Сериализуемое значение</param>
        /// <returns>Массив байт, хранящий число</returns>
        public static byte[] Int64ToByteArray(Int64 value)
        {
            int typeSize = sizeof(Int64);
            const Int32 bitsInByte = 8;
            byte[] result = new byte[typeSize];

            for (int i = 0; i < typeSize; i++)
            {
                result[i] = (byte)((value >> (i * bitsInByte)) & 255);
            }

            return result;
        }
        #endregion

        #region public static Double DoubleFromByteArray(byte[] data, int sourceStartIndex)

        public static Double DoubleFromByteArray(byte[] data, int sourceStartIndex)
        {
            if (null == data) throw new ArgumentNullException("data", "Parameter must not be null");
            if (sizeof(Double) + sourceStartIndex > data.Length) throw new ArgumentException("Copied length must be non less than " + 8);

            double doub = BitConverter.ToDouble(data, sourceStartIndex);

            return doub;
        }
        #endregion

        #region public static byte[] DoubleToByteArray(Double value)
        /// <summary>
        /// Сериализует значение числа типа <see cref="Double"/> побайтово в массив байтов. 
        /// Младший байт числа будет сохранён в нулевой элемент массива и т. д.
        /// </summary>
        /// <param name="value">Сериализуемое значение</param>
        /// <returns>Массив байт, хранящий число</returns>
        public static byte[] DoubleToByteArray(Double value)
        {
            // в массив байт
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        #endregion

        #region public static byte[] Int32ToByteArray(Int32 value)
        /// <summary>
        /// Сериализует значение числа типа <see cref="Int32"/> побайтово в массив байтов. 
        /// Младший байт числа будет сохранён в нулевой элемент массива и т. д.
        /// </summary>
        /// <param name="value">Сеиализуемое значение</param>
        /// <returns>Массив байт, хранящий число</returns>
        public static byte[] Int32ToByteArray(Int32 value)
        {
            int typeSize = sizeof(Int32);
            const Int32 bitsInByte = 8;
            byte[] result = new byte[typeSize];

            for (int i = 0; i < typeSize; i++)
            {
                result[i] = (byte)((value >> (i * bitsInByte)) % 256);
            }

            return result;
        }
        #endregion

        #region public static Int32 Int32FromByteArray(byte[] data, int sourceStartIndex)
        /// <summary>
        /// Извлекает из массива байт число типа <see cref="Int32"/>.
        /// Берёт значение младшего байта числа из нулевого элемента массива и т. д.
        /// </summary>
        /// <param name="data">Массив-источник</param>
        /// <param name="sourceStartIndex">Стартовый индекс массива с которого следует начинать копирование</param>
        /// <returns>Извлечённое число</returns>
        public static Int32 Int32FromByteArray(byte[] data, int sourceStartIndex)
        {
            int typeSize = sizeof(Int32);
            const Int32 bitsInByte = 8;
            Int32 result = 0;

            if (null == data) throw new ArgumentNullException("data", "Parameter must not be null");
            if (sizeof(Int32) + sourceStartIndex > data.Length) throw new ArgumentException("Copied length must be non less than " + typeSize);

            for (int i = 0; i < typeSize; i++)
            {
                result |= data[i + sourceStartIndex] << (i * bitsInByte);
            }

            return result;
        }
        #endregion
    
        #region Lifelength ToLifelength (object)
        /// <summary>
        /// Переводит объкт баззы данных в Lifelength
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Lifelength ToLifelength(object o)
        {
            if (o == null || o == DBNull.Value)
                return Lifelength.Null;
            return Lifelength.ConvertFromByteArray((byte[])o);
        }

		#endregion

		#region private static ComponentDirectiveThreshold ToComponentDirectiveThreshold(object o)
		/// <summary>
		/// Переводит объкт баззы данных в Lifelength
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		private static ComponentDirectiveThreshold ToComponentDirectiveThreshold(object o)
        {
            if (o == null || o == DBNull.Value)
                return null;
            return new ComponentDirectiveThreshold(ToBytes(o));
        }

		#endregion

		private static object ToTrainingThreshold(object o)
		{
			if (o == null || o == DBNull.Value)
				return null;
			return new TrainingThreshold(ToBytes(o));
		}

		#region public static DirectiveThreshold ToDirectiveThreshold(object o)
		/// <summary>
		/// Переводит объкт баззы данных в Lifelength
		/// </summary>
		/// <param name="o"></param>
		/// <returns></returns>
		public static DirectiveThreshold ToDirectiveThreshold(object o)
        {
            if (o == null || o == DBNull.Value)
                return null;
            return DirectiveThreshold.ConvertFromByteArray((byte[])o);
        }

        #endregion

        #region private static MaintenanceDirectiveThreshold ToMaintenanceDirectiveThreshold(object o)
        /// <summary>
        /// Переводит объкт баззы данных в MaintenanceDirectiveThreshold
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static MaintenanceDirectiveThreshold ToMaintenanceDirectiveThreshold(object o)
        {
            if (o == null || o == DBNull.Value)
                return null;
            return MaintenanceDirectiveThreshold.ConvertFromByteArray((byte[])o);
        }

        #endregion

        #region static AverageUtilization ToAverageUtilization(object o)
        /// <summary>
        /// Переводит объкт баззы данных в ToAverageUtilization
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static AverageUtilization ToAverageUtilization(object o)
        {
            if (o == null || o == DBNull.Value)
                return new AverageUtilization(0,0,UtilizationInterval.Dayly);
            return AverageUtilization.ConvertFromByteArray((byte[])o);
        }

        #endregion

        #region public static Image BytesToImage (byte [] bytes)
        /// <summary>
        /// Получение изображения из массива байтов (для логотипа)
        /// </summary>
        /// <param name="bytes">Массив байтов</param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return new Bitmap(1, 1);

            MemoryStream ms = new MemoryStream(bytes);
            Image image = new Bitmap(ms, true);

            return image;
        }
        #endregion

        #region  public static byte [] ImageToBytes (Image image, ImageFormat format)
        /// <summary>
        /// Перевод изображения в массив байт
        /// </summary>
        /// <param name="image">Изображение для перевода</param>
        /// <returns></returns>
        /// <param name="format">Формат изображения</param>
        public static byte [] ImageToBytes (Image image, ImageFormat format)
        {
            if (image == null) return null;
    
            MemoryStream ms = new MemoryStream();
            image.Save (ms, format);
       
            byte [] arr = new byte [ms.Length];
            ms.Position = 0;
            ms.Read (arr, 0, (int)ms.Length);
            return arr;
        }
        #endregion

        //#region  public static void SetValue(TableColumnAttribute tca, BaseEntityObject item, PropertyInfo currentProperty, object value)
        //public static void SetValue(TableColumnAttribute tca, BaseEntityObject item, PropertyInfo currentProperty, object value)
        //{
        //    object objectValue;
        //    if (!(string.IsNullOrEmpty(tca.TypeBy)))
        //    {
        //        PropertyInfo typeProperty = item.GetType().GetProperties().Where(p => p.Name == tca.TypeBy).First();
        //        if (typeProperty != null)
        //        {
        //            SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
        //            if (coreType != null && coreType.ObjectType != null)
        //                objectValue = GetValue(coreType.ObjectType, value);
        //            else objectValue = GetValue(currentProperty.PropertyType, value);
        //        }
        //        else objectValue = GetValue(currentProperty.PropertyType, value);
        //    }
        //    else objectValue = GetValue(currentProperty.PropertyType, value);

        //    currentProperty.SetValue(item, objectValue, null);
        //}
        //#endregion

        #region  public static void Fill(Type type, object value)
        public static object GetValue(Type type, object value)
        {
            //Проверка, является ли переданный тип наследником BaseSmartCoreObject
            if (type.IsSubclassOf(typeof(AbstractDictionary)))
            {
                try
                {
                    var typeDict = _casEnvironment.GetDictionary(type);
                    return typeDict == null ? null : typeDict.GetItemById(ToInt32(value));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (type.IsSubclassOf(typeof(StaticDictionary)))
            {
                try
                {
                    //поиск в типе своиства Items
                    PropertyInfo itemsProp = type.GetProperty("Items");
                    //поиск у типа конструктора беза параметров
                    ConstructorInfo ci = type.GetConstructor(new Type[0]);
                    //создание экземпляра статического словаря 
                    //(при этом будут созданы все его статические элементы, 
                    //которые будут доступны через статическое своиство Items)
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);
                    //Получение элементов статического своиства Items
                    IEnumerable staticList = (IEnumerable)itemsProp.GetValue(instance, null);

                    int id = ToInt32(value);
                    StaticDictionary res = staticList.Cast<StaticDictionary>().FirstOrDefault(o => o.ItemId == id) ??
                                           staticList.Cast<StaticDictionary>().FirstOrDefault(o => o.ItemId == -1);
                    return res;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if(type.IsEnum)
            {
                try
                {
                    object o = Enum.Parse(type, value.ToString());
                    return o;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(Aircraft).Name)
            {
                try
                {
                    var aircraft = _aircraftsCore.GetAircraftById(ToInt32(value));
                    return aircraft;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(BaseComponent).Name)
            {
                try
                {
                    BaseComponent bd = _casEnvironment.BaseComponents.GetItemById(ToInt32(value));//TODO(Evgenii Babak): использовать ComponentCore
                    return bd;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(Hangar).Name)
            {
                try
                {
                    Hangar hangar = _casEnvironment.Hangars.GetItemById(ToInt32(value));
                    return hangar;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(Operator).Name)
            {
                try
                {
                    Operator op = _casEnvironment.Operators.GetItemById(ToInt32(value));
                    return op;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(Store).Name)
            {
                try
                {
                    Store store = _casEnvironment.Stores.GetItemById(ToInt32(value));
                    return store;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (type.Name == typeof(WorkShop).Name)
            {
                try
                {
                    WorkShop workShop = _casEnvironment.WorkShops.GetItemById(ToInt32(value));
                    return workShop;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            Type nullable = Nullable.GetUnderlyingType(type);
            if(nullable != null)
            {
				//TODO:(Evgenii Babak) использовать Nameof() вместо названия типа
                string typeName = nullable.Name.ToLower();
                switch (typeName)
                {
                    case "int32": return ToInt32Nullable(value);
                    case "int16": return ToInt16Nullable(value);
                    case "datetime": return ToDateTimeNullable(value);
                    case "bool": return ToBoolNullable(value);
                    case "boolean": return ToBoolNullable(value);
                    case "double": return ToDoubleNullable(value);
                    default:
                        return null;
                }    
            }
            else
            {
                string typeName = type.Name.ToLower();
                switch (typeName)
                {
                    case "string": return ToString(value);
                    case "int32": return ToInt32(value);
                    case "int16": return ToInt16(value);
                    case "datetime": return ToDateTime(value);
                    case "bool": return ToBool(value);
                    case "boolean": return ToBool(value);
                    case "byte[]": return ToBytes(value);
                    case "double": return ToDouble(value);
                    case "adtype":
                        return (ADType)ToInt16(value);
                    case "averageutilization":
                        return ToAverageUtilization(value);
                    case "avionicsinventorymarktype":
                    //case "atachapter":
                    //    return _casEnvironment.Dictionaries[typeof(AtaChapter)].GetItemById(ToInt32(value));
                    case "componentdirectivethreshold":
                        return ToComponentDirectiveThreshold(value);
					case "trainingthreshold":
						return ToTrainingThreshold(value);
					case "componenttype": return BaseComponentType.GetComponentTypeById(ToInt32(value));
                    case "componentrecordtype":
                        return ComponentRecordType.GetItemById(ToInt32(value));
                    case "detectionphase": return (DetectionPhase)ToInt16(value);
                    case "directivethreshold":
                        return ToDirectiveThreshold(value);
                    case "directivetype":
                        return DirectiveWorkType.GetItemById(ToInt32(value));
                    case "highlight": return Highlight.GetHighlightById(ToInt32(value));
                    case "componentstatus": return (ComponentStatus)ToInt16(value);
                    case "lifelength": return ToLifelength(value);
                    case "landinggearmarktype": return (LandingGearMarkType)ToInt32(value);
                    case "maintenancedirectivethreshold":
                        return ToMaintenanceDirectiveThreshold(value);
                    case "maintenancecontrolprocess": return MaintenanceControlProcess.GetItemById(ToInt32(value));
                    case "powerloss": return (PowerLoss)ToInt16(value);
                    case "runupcondition": return (RunUpCondition)ToInt16(value);
                    case "runuptype": return (RunUpType)ToInt16(value);
                    case "shutdowntype": return (ShutDownType)ToInt16(value);
                    case "thrustlever": return (ThrustLever)ToInt16(value);
                    case "timespan": return ToTime(value);
                    case "weathercondition": return (WeatherCondition)ToInt16(value);
                    case "workpackagestatus": return (WorkPackageStatus)ToInt32(value);
                    default:
                        return null;
                }    
            }
        }

	    #endregion

    }
}
