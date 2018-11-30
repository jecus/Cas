using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;
using SmartCore.Management;

namespace SmartCore.Queries
{
	public class BaseQueries
	{

		#region public static SqlParameter[] GetParameters(BaseCasObject item)
		/// <summary>
		/// Возвращает список параметров, которые могут использоваться в запросах
		/// </summary>
		public static SqlParameter[] GetParameters(BaseEntityObject item)
		{
			Type T = item.GetType();
			//определение своиств типа
			List<PropertyInfo> preProrerty = T.GetProperties().ToList();
			List<PropertyInfo> properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0).ToList();
			List<SqlParameter> parameters = new List<SqlParameter>();

			foreach (PropertyInfo prop in properties)
			{
				var tca =(TableColumnAttribute)prop.GetCustomAttributes(typeof(TableColumnAttribute), false).First();
				var sqlParameter = DbTypes.SqlParameter("@" + tca.ColumnName, prop.PropertyType, prop.GetValue(item, null));
				if (sqlParameter.SqlDbType == SqlDbType.VarBinary && sqlParameter.Value == DBNull.Value)
					sqlParameter.Value = -1;
				parameters.Add(sqlParameter);

			}

			return parameters.ToArray();
		}

		#endregion

		#region public static string GetDeleteQuery(BaseCasObject item)
		///<summary>
		/// Возвращает строку SQL запроса удаление данных из БД 
		/// </summary>
		public static string GetDeleteQuery(BaseEntityObject item)
		{
			//определение типа
			Type type = item.GetType();
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			return $@"Set dateformat dmy; DELETE FROM [{dbTable.TableScheme}].{dbTable.TableName} WHERE {dbTable.PrimaryKey} = {item.ItemId}";
		}

		#endregion

		#region public static string GetDeleteQuery<T>(ICommonFilter[] filters)

		public static string GetDeleteQuery<T>(ICommonFilter[] filters) where T : BaseEntityObject
		{
			//определение типа
			Type type = typeof (T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute) type.GetCustomAttributes(typeof (TableAttribute), true).FirstOrDefault();

			var query = $"Set dateformat dmy; DELETE FROM [{dbTable.TableScheme}].{dbTable.TableName}";

			string whereConditionResult = " where ";
			string filterString = GetFiltersString(dbTable, filters);

			if (filterString.Trim() != "")
			{
				//Если строка фильтра и строка состояния объекта не является пустой
				//в конец строки состояния добавляется слово and
				if (whereConditionResult != " where ")
					whereConditionResult += " and ";

				//добавление строки фильтрации в конец строки состояния объекта
				whereConditionResult += filterString;
			}

			return query += whereConditionResult;
		}

		#endregion

		#region public static string GetMarkAsDeletedQuery<T>(ICommonFilter[] filters)

		public static string GetMarkAsDeletedQuery<T>(ICommonFilter[] filters) where T : BaseEntityObject
		{
			if (filters == null)
				throw new ArgumentNullException(nameof(filters), "Can not be null");

			if(!filters.Any())
				throw new ArgumentException("Should not be empty", nameof(filters));

			//определение типа
			Type type = typeof (T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute) type.GetCustomAttributes(typeof (TableAttribute), true).FirstOrDefault();

			var query = $"Set dateformat dmy; Update [{dbTable.TableScheme}].{dbTable.TableName} Set IsDeleted = 1";

			string whereConditionResult = " where ";
			string filterString = GetFiltersString(dbTable, filters);

			if (filterString.Trim() != "")
			{
				//Если строка фильтра и строка состояния объекта не является пустой
				//в конец строки состояния добавляется слово and
				if (whereConditionResult != " where ")
					whereConditionResult += " and ";

				//добавление строки фильтрации в конец строки состояния объекта
				whereConditionResult += filterString;
			}

			return query += whereConditionResult;
		}

		#endregion

		#region public static string GetMarkAsDeletedQuery(BaseEntityObject item)

		public static string GetMarkAsDeletedQuery(BaseEntityObject item)
		{
			//определение типа
			var type = item.GetType();
			//Определение атрибута сохраняемой таблицы
			var dbTable = (TableAttribute) type.GetCustomAttributes(typeof (TableAttribute), true).FirstOrDefault();

			return $"Set dateformat dmy; Update [{dbTable.TableScheme}].{dbTable.TableName} Set IsDeleted = 1 Where {dbTable.PrimaryKey} = {item.ItemId}";
		}

		#endregion

		#region public static String GetInsertQuery(BaseCasObject item)
		/// <summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		/// <param name="item">Объект, для которого создается строка запроса</param>
		/// <returns></returns>
		public static String GetInsertQuery(BaseEntityObject item)
		{
			//определение типа
			Type T = item.GetType();
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)T.GetCustomAttributes(typeof(TableAttribute), true).First();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(T.GetProperties());

			List<PropertyInfo> properties = preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													 ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly).ToList();

			var result = string.Format(@"Set dateformat dmy; Insert Into [{0}].{1}", dbTable.TableScheme, dbTable.TableName);

			result += "(";
			for (int i = 0; i < properties.Count; i++)
			{
				var tca = (TableColumnAttribute)properties[i].GetCustomAttributes(typeof (TableColumnAttribute), false).First();
				result += tca.ColumnName;
				if (i != properties.Count - 1) result += ",";
			}
			result += ") Values (";
			for (int i = 0; i < properties.Count; i++)
			{
				var tca = (TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).First();
				result += "@" + tca.ColumnName;
				if (i != properties.Count - 1) result += ",";
			}
			result += ") SELECT SCOPE_IDENTITY();";
			return result;
		}

		#endregion

		#region public static String GetInsertQuery(Type type)
		/// <summary>
		/// Возвращает строку SQL запроса добавление данных в БД 
		/// </summary>
		/// <param name="type">Тип объектов, для которого создается строка запроса</param>
		/// <returns></returns>
		public static String GetInsertQuery(Type type)
		{
			//определение типа
			var T = type;
			//Определение атрибута сохраняемой таблицы
			var dbTable = (TableAttribute)T.GetCustomAttributes(typeof(TableAttribute), true).First();
			//определение своиств типа
			var preProrerty = new List<PropertyInfo>(T.GetProperties());

			var properties = preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													 ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly).ToList();

			var result = $@"Set dateformat dmy; Insert Into [{dbTable.TableScheme}].{dbTable.TableName}";

			result += "(";
			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).First();
				result += tca.ColumnName;
				if (i != (properties.Count - 1)) result += ",";
			}
			result += ") Values (";
			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).First();
				result += "@" + tca.ColumnName;
				if (i != (properties.Count - 1)) result += ",";
			}
			result += ") SELECT SCOPE_IDENTITY();";
			return result;
		}

		#endregion

		#region public static String GetUpdateQuery(this BaseCasObject item)
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		/// <param name="item">Объект, для которого создается строка запроса</param>
		/// <param name="updateForced">Флаг, показывающий нужно ли обновлять принудительные поля</param>
		/// <returns></returns>
		public static String GetUpdateQuery(BaseEntityObject item, bool updateForced = false)
		{
			//определение типа
			Type T = item.GetType();
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)T.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(T.GetProperties());
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (updateForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				//и которые загружаются/сохраняются принудительно
				properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
									&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly
									&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false).ToList();
			}

			String result = String.Format(@"Set dateformat dmy; Update [{0}].{1}",
										  dbTable.TableScheme, dbTable.TableName) + " Set ";
			if(properties.Count > 0)
			{
				PropertyInfo isDeletedProperty = properties.FirstOrDefault(p => p.Name.ToLower() == "isdeleted");
				if (isDeletedProperty != null)
				{
					//Свойство IsDeleted дложно быть всегда первым в запросе на оновление
					//Это необходимо для правильного логирования записей
					properties.Remove(isDeletedProperty);
					properties.Insert(0, isDeletedProperty);
				}
			}
			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)properties[i].GetCustomAttributes(typeof (TableColumnAttribute), false).First();
				result += tca.ColumnName + " = @" + tca.ColumnName;
				if (i != (properties.Count - 1)) result += ", ";
			}
			result += String.Format(" Where {0} = @{1}", dbTable.PrimaryKey, dbTable.PrimaryKey);

			return result;
		}

		#endregion

		#region public static String GetUpdateQuery(Type type, bool updateForced = false)
		/// <summary>
		/// Возвращает строку SQL запроса на обновление данных в БД 
		/// </summary>
		/// <param name="type">Тип, объекты для которого создается строка запроса</param>
		/// <param name="updateForced">Флаг, показывающий нужно ли обновлять принудительные поля</param>
		/// <returns></returns>
		public static String GetUpdateQuery(Type type, bool updateForced = false)
		{
			//определение типа
			Type T = type;
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)T.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(T.GetProperties());
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (updateForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				//и которые загружаются/сохраняются принудительно
				properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
									&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.ReadOnly
									&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false).ToList();
			}

			String result = String.Format(@"Set dateformat dmy; Update [{0}].{1}",
										  dbTable.TableScheme, dbTable.TableName) + " Set ";
			if (properties.Count > 0)
			{
				PropertyInfo isDeletedProperty = properties.FirstOrDefault(p => p.Name.ToLower() == "isdeleted");
				if (isDeletedProperty != null)
				{
					//Свойство IsDeleted дложно быть всегда первым в запросе на оновление
					//Это необходимо для правильного логирования записей
					properties.Remove(isDeletedProperty);
					properties.Insert(0, isDeletedProperty);
				}
			}
			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).First();
				result += tca.ColumnName + " = @" + tca.ColumnName;
				if (i != (properties.Count - 1)) result += ", ";
			}
			result += String.Format(" Where {0} = @{1}", dbTable.PrimaryKey, dbTable.PrimaryKey);

			return result;
		}

		#endregion

		#region private static String GetTypeFieldsOnly(Type type, bool includeTableNamePrefix, bool checkType = false)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД состоящую только из полей заданного типа
		/// <br/> Поля вложенных типов (помеченных атрибутом Child) игнорируются
		/// </summary>
		private static String GetTypeFieldsOnly(Type type, string includeTableNamePrefix = null,
												bool checkType = false, bool selectForced = false,
												bool loadChild = false)
		{
			#region Проверка типа
			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
			//определение своиств, имеющих атрибут "сохраняемое"
			//исключая своиства "только запись" и свойства вложенных типов
			List<PropertyInfo> properties;

			if (selectForced && loadChild)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly
									   && p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
									   || (p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else if (loadChild)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly
									   && ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || (p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly
									   && ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false
									   && p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			String result = "";
			string tableNamePrefix = "";
			string asTablePrefix;
			if (includeTableNamePrefix != null)
			{
				if (includeTableNamePrefix != "")
				{
					tableNamePrefix = includeTableNamePrefix + '.';
					asTablePrefix = includeTableNamePrefix;
				}
				else
				{
					tableNamePrefix = dbTable.TableName + '.';
					asTablePrefix = dbTable.TableName;
				}
			}
			else asTablePrefix = dbTable.TableName;

			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
						(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
				if (tca != null)
				{
					result += tableNamePrefix + tca.ColumnName + " as " + asTablePrefix + tca.ColumnName;
					if (i != (properties.Count - 1)) result += ", ";
				}

				SubQueryAttribute cca =
						(SubQueryAttribute)properties[i].GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
				if (cca != null)
				{
					result += cca.Condition + " as " + asTablePrefix + cca.ColumnName;
					if (i != (properties.Count - 1)) result += ", ";
				}
			}
			return result;
		}
		#endregion

		#region private static String GetFiltersString(TableAttribute dbTable, IQueryFilter[] filters)
		/// <summary>
		/// Возвращает строку-фильтр SQL запроса на селектирование данных из БД
		/// </summary>
		private static String GetFiltersString(TableAttribute dbTable, ICommonFilter[] filters)
		{
			string filterString = "";

			if (filters != null && filters.Length > 0)
			{
				//Поиск фильтров, удовлетворяющих необходимым условиям
				//1.Наличие фильтруемого поля
				//2.Наличие необходимых атрибутов для определения колонок фильтруемой таблицы
				//  Вслучае наличия у фильтруемого своиства атрибутов TableColumnAttribute и SubQueryAttribute
				//  предпочтение отдается TableColumnAttribute
				//3.Наличие значений для критериев фильтрации

				#region Старый код с ограничением на атрибут Child
				//List<IQueryFilter> successFilters =
				//    filters.Where(t => t != null && t.FilterProperty != null
				//                       && ((t.FilterProperty.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
				//                            && t.FilterProperty.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
				//                            || t.FilterProperty.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0)
				//                       && t.Values != null && t.Values.Length > 0).ToList();
				#endregion

				List<ICommonFilter> successFilters =
					filters.Where(t => t != null && t.FilterProperty != null
									   && ((t.FilterProperty.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0)
											|| t.FilterProperty.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0)
									   && t.GetValidValuesCount() > 0).ToList();

				successFilters.AddRange(filters.Where(f => f.FilterProperty == null && f.GetValidValuesCount() > 0));
				for (int i = 0; i < successFilters.Count; i++)
				{
					string filterSubString = "";
					string filterField = "";

					if(successFilters[i].FilterProperty != null)
					{
						TableColumnAttribute tca =
							(TableColumnAttribute)successFilters[i].FilterProperty.GetCustomAttributes(typeof(TableColumnAttribute), false)
													.FirstOrDefault();
						SubQueryAttribute cca =
							(SubQueryAttribute)successFilters[i].FilterProperty.GetCustomAttributes(typeof(SubQueryAttribute), false)
								.FirstOrDefault();
						if (tca != null)
						{
							filterField = dbTable.TableName + "." + tca.ColumnName;
						}
						else if (cca != null)
						{
							filterField += dbTable.TableName + "." + cca.Condition;
						}

						//Если атрибуты не содержали имен колонок таблиц
						//переход на след. итерацию
						if (filterField.Trim() == "") continue;

						object value = DbTypes.DbObject(successFilters[i].Values[0]);
						object valueString = (value is string || value is bool)
												 ? "'" + value + "'"
												 : value;
						switch (successFilters[i].FilterType)
						{
							case FilterType.Less:
								filterSubString += string.Format("({0} is null or {0} < {1})",
																 filterField,
																 valueString);
								break;
							case FilterType.LessOrEqual:
								filterSubString += string.Format("({0} is null or {0} <= {1})",
																 filterField,
																 valueString);
								break;
							case FilterType.Equal:
								filterSubString += filterField + " = " + valueString;
								break;
							case FilterType.GratherOrEqual:
								filterSubString += filterField + " >= " + valueString;
								break;
							case FilterType.Grather:
								filterSubString += filterField + " > " + valueString;
								break;
							case FilterType.NotEqual:
								filterSubString += string.Format("({0} is null or {0} != {1})",
																 filterField,
																 valueString);
								break;
							case FilterType.In:
								filterSubString += filterField + " in (";
								for (int v = 0; v < successFilters[i].Values.Length; v++)
								{
									if (v > 0) filterSubString += ",";
									filterSubString += DbTypes.DbObject(successFilters[i].Values[v]);
								}
								filterSubString += ")";
								break;
							case FilterType.Between:
								filterSubString += filterField + $" BETWEEN {successFilters[i].Values[0]} and {successFilters[i].Values[successFilters[i].Values.Length - 1]}";break;
							default:
								break;
						}
					}
					else
					{
						object value = DbTypes.DbObject(successFilters[i].Values[0]);
						if(!(value is string))
							continue;
						filterSubString += string.Format("({0})", value);
					}

					if (filterSubString.Trim() == "") continue;

					if (i > 0) filterString += "\nand ";
					filterString += filterSubString;
				}
			}

			return filterString;
		}
		#endregion

		#region public static String GetFields<T>(bool includeTableNamePrefix) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetFields<T>(bool includeTableNamePrefix, bool selectForced = false) where T : BaseEntityObject, new()
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}

			String result = "";
			String tableNamePrefix = ""; if (includeTableNamePrefix) tableNamePrefix = dbTable.TableName + '.';
			for (int i = 0; i < properties.Count; i++)
			{
				TableColumnAttribute tca =
						(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
				if(tca != null)
				{
					result += tableNamePrefix + tca.ColumnName + " as " + dbTable.TableName + tca.ColumnName;
					if (i != (properties.Count - 1)) result += ", ";
				}

				SubQueryAttribute cca =
						(SubQueryAttribute)properties[i].GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
				if (cca != null)
				{
					result += cca.Condition + " as " + dbTable.TableName + cca.ColumnName;
					if (i != (properties.Count - 1)) result += ", ";
				}
			}
			return result;

		}
		#endregion

		#region public static String GetFields<T>() where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetFields<T>() where T : BaseEntityObject, new()
		{
			return GetFields<T>(false);
		}
		#endregion

		#region public static String GetFields(Type type, bool includeTableNamePrefix, bool checkType = false)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetFields(Type type, bool includeTableNamePrefix, bool loadChild = false,
									   bool checkType = false, bool selectForced = false)
		{
			#region Проверка типа
			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				preProrerty.Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}

			String result = "";
			String tableNamePrefix = ""; if (includeTableNamePrefix) tableNamePrefix = dbTable.TableName + '.';
			if(loadChild)
			{
				for (int i = 0; i < properties.Count; i++)
				{
					Type baseType = properties[i].PropertyType;
					bool isBaseSmartCore = false;
					while (baseType != null)
					{
						if (baseType.Name == typeof(BaseEntityObject).Name &&
						   (properties[i].PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
							properties[i].PropertyType.GetCustomAttributes(typeof(SubQueryAttribute),false).FirstOrDefault() != null) &&
							properties[i].GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseSmartCore = true;
							break;
						}
						baseType = baseType.BaseType;
					}

					if(isBaseSmartCore)
					{
						//Если тип своиства является BaseSmartCoreObject, то в строку запроса
						//добавляются все поля этого типа
						result += GetFields(properties[i].PropertyType, true, true);
					}
					else
					{
						TableColumnAttribute tca =
								(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if(tca != null)
							result += tableNamePrefix + tca.ColumnName + " as " + dbTable.TableName + tca.ColumnName;

						SubQueryAttribute cca =
							(SubQueryAttribute)properties[i].GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							result += cca.Condition + " as " + dbTable.TableName + cca.ColumnName;
					}
					if (i != (properties.Count - 1)) result += ", ";
				}
			}
			else
			{
				for (int i = 0; i < properties.Count; i++)
				{
					TableColumnAttribute tca =
							(TableColumnAttribute)properties[i].GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
					result += tableNamePrefix + tca.ColumnName + " as " + dbTable.TableName + tca.ColumnName;
					if (i != (properties.Count - 1)) result += ", ";
				}
			}
			return result;

		}
		#endregion

		#region public static String GetSelectQuery<T>(bool includeTableNamePrefix) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQuery<T>(bool includeTableNamePrefix = false) where T : BaseEntityObject, new()
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение типа
			String result = "";
			result += String.Format(@"Select {0} from[{1}].{2} ", GetFields<T>(includeTableNamePrefix), dbTable.TableScheme, dbTable.TableName);

			return result;
		}
		#endregion

		#region public static String GetSelectQueryWithWhere<T>(bool loadChild = false, bool checkType = false) where T : BaseSmartCoreObject, new()

		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД  
		/// </summary>
		/// <param name="filters">Фильтрация по определенным полям. Null или пустой массив не учитываются</param>
		/// <param name="loadChild">Загружать вложенные объекты</param>
		/// <param name="getDeleted">Загружать недействительные записи</param>
		public static String GetSelectQueryWithWhere<T>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntityObject, new()
		{
			return GetSelectQueryWithWhere(typeof(T), filters, loadChild, false, getDeleted);
		}
		#endregion

		#region  public static String GetItemsCountQuery<T>() where T : BaseSmartCoreObject
		/// <summary>
		/// Возвращает строку SQL запроса на извлечения количества элементов определенного типа из БД 
		/// </summary>
		public static String GetItemsCountQuery<T>() where T : BaseEntityObject
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение типа
			String result = "";
			result += String.Format(@"Select Count({0}) from[{1}].{2} ", dbTable.PrimaryKey, dbTable.TableScheme, dbTable.TableName);

			return result;
		}
		#endregion

		#region public static String GetCountPerformancesQuery<T>(SmartCoreType parentType, int parentId) where T : AbstractPerformanceRecord
		/// <summary>
		/// Возвращает строку SQL запроса на извлечения количества элементов определенного типа из БД 
		/// </summary>
		public static String GetCountPerformancesQuery<T>(SmartCoreType parentType, int parentId) where T : AbstractPerformanceRecord
		{
			//определение типа
			Type type = typeof(T);

			PropertyInfo parentIdProperty = type.GetProperty("ParentId");
			PropertyInfo parentTypeIdProperty = type.GetProperty("ParentType");

			#region Проверка типа

			if (parentIdProperty == null)
				throw new NullReferenceException("отстутствует свойство ParentId");
			if (parentTypeIdProperty == null)
				throw new NullReferenceException("отстутствует свойство ParentType");

			TableColumnAttribute parentTypeIdAttr =
				(TableColumnAttribute)parentTypeIdProperty.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
			TableColumnAttribute parentIdAttr =
				(TableColumnAttribute)parentIdProperty.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();

			if (parentIdAttr == null)
				throw new NullReferenceException("отстутствует атрибут TableColumnAttribute у свойства ParentId");
			if (parentTypeIdAttr == null)
				throw new NullReferenceException("отстутствует атрибут TableColumnAttribute у свойства ParentType");

			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			string whereResult = " where ";
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();
			if (attributes.Count != 0)
			{
				whereResult = attributes.Aggregate(whereResult, (current, t) => current + (t.ColumnName + " = " + t.Condition + " and "));
			}
			whereResult += string.Format("{0} = {1} and {2} = {3}",
										 parentTypeIdAttr.ColumnName, parentType.ItemId,
										 parentIdAttr.ColumnName, parentId);

			return String.Format(@"Select Count({0}) from[{1}].{2} {3}", dbTable.PrimaryKey, dbTable.TableScheme, dbTable.TableName, whereResult);
		}
		#endregion

		#region  public static String GetPerformancesQuery<T>(SmartCoreType parentType, int parentId, bool lastOnly) where T : AbstractPerformanceRecord, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetPerformancesQuery<T>(SmartCoreType parentType, int parentId, bool lastOnly) where T : AbstractPerformanceRecord, new()
		{
			//определение типа
			Type type = typeof(T);

			PropertyInfo parentIdProperty = type.GetProperty("ParentId");
			PropertyInfo parentTypeIdProperty = type.GetProperty("ParentType");
			PropertyInfo recordDateProprety = type.GetProperty("RecordDate");

			#region Проверка типа

			if (parentIdProperty == null)
				throw new NullReferenceException("отстутствует свойство ParentId");
			if (parentTypeIdProperty == null)
				throw new NullReferenceException("отстутствует свойство ParentType");
			if (recordDateProprety == null)
				throw new NullReferenceException("отстутствует свойство RecordDate");

			TableColumnAttribute parentTypeIdAttr =
				(TableColumnAttribute) parentTypeIdProperty.GetCustomAttributes(typeof (TableColumnAttribute), false).FirstOrDefault();
			TableColumnAttribute parentIdAttr =
				(TableColumnAttribute) parentIdProperty.GetCustomAttributes(typeof (TableColumnAttribute), false).FirstOrDefault();
			TableColumnAttribute recordDateAttr =
				(TableColumnAttribute) recordDateProprety.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();

			if (parentIdAttr == null)
				throw new NullReferenceException("отстутствует атрибут TableColumnAttribute у свойства ParentId");
			if (parentTypeIdAttr == null)
				throw new NullReferenceException("отстутствует атрибут TableColumnAttribute у свойства ParentType");
			if (recordDateAttr == null)
				throw new NullReferenceException("отстутствует атрибут TableColumnAttribute у свойства RecordDate");

			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			string whereResult = " where ";
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();
			if (attributes.Count != 0)
			{
				whereResult = attributes.Aggregate(whereResult, (current, t) => current + (t.ColumnName + " = " + t.Condition + " and "));
			}
			whereResult += string.Format("{0} = {1} and {2} = {3} order by [{4}] desc",
										 parentTypeIdAttr.ColumnName, parentType.ItemId,
										 parentIdAttr.ColumnName, parentId,
										 recordDateAttr.ColumnName);

			if(lastOnly)
				return String.Format(@"set dateformat dmy Select TOP(1) {0} from[{1}].{2} {3}",
								 GetFields<T>(false), dbTable.TableScheme, dbTable.TableName, whereResult);
			return String.Format(@"set dateformat dmy Select {0} from[{1}].{2} {3}",
								   GetFields<T>(false), dbTable.TableScheme, dbTable.TableName, whereResult);
		}
		#endregion

		#region private static List<DbQuery> GetSelectQueryWithoutWhere(Type type, bool includeTableNamePrefix, bool checkType = false)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// <br/> IsDeleted и другие состояния записи игнорируются
		/// </summary>
		private static List<DbQuery> GetSelectQueryWithoutWhere(Type type, string whereString, bool includeTableNamePrefix,
																bool loadChild = false, bool checkType = false, bool selectForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			//определение типа
			StringCollection fields = null, joins = null;
			List<DbQuery>subs = null;

			GetSelectSubQuery(type, includeTableNamePrefix, ref fields, ref joins, ref subs, whereString, dbTable.TableName, null, null, "", null, loadChild, false, selectForced);

			String result = "";
			if (fields != null)
			{
				string f = "";
				for (int i = 0; i < fields.Count; i++)
				{
					f += fields[i];
					if (i < fields.Count - 1)
						f += ", ";
				}

				result += String.Format(@"Select {0} from[{1}].{2}",
										f,
										dbTable.TableScheme,
										dbTable.TableName);
			}
			if (joins != null)
				result += " " + joins.Cast<string>().Aggregate("", (current, field) => current + field);

			List<DbQuery> results = new List<DbQuery> { new DbQuery(type, result, dbTable.TableName) };
			results.AddRange(subs);

			return results;
		}
		#endregion

		#region private static void GetSelectSubQuery(Type type, bool includeTableNamePrefix, bool checkType = false)

		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		/// <param name="type">Тип, объекты которого необходимо загрузить</param>
		/// <param name="includeTableNamePrefix">Включать название таблицы в качестве префикса для полей</param>
		/// <param name="fields">Коллекция полей запроса</param>
		/// <param name="joins">Коллекция конструкций JOIN запроса</param>
		/// <param name="subs">Коллекция подзапросов для объектов в соотношении "1 к *" и "* к *" </param>
		/// <param name="parentWhere">Строка фильтра родительского типа</param>
		/// <param name="branch">Ветвь запроса</param>
		/// <param name="parentTable">Атрибут родительской таблицы</param>
		/// <param name="parentColumn">Атрибут колонки в родительской таблице</param>
		/// <param name="childData">Атрибут, содержащий данные о способе загрузки дочерних элементов для родительского типа</param>
		/// <param name="loadChild">загружать дочерние объекты для данного типа</param>
		/// <param name="checkType">Проверять данный тип на возможность произведения загрузки</param>
		/// <param name="selectForced">Загружать свойства помеченные принудительно</param>
		private static void GetSelectSubQuery(Type type, bool includeTableNamePrefix,
											  ref StringCollection fields, ref StringCollection joins,
											  ref List<DbQuery> subs,
											  string parentWhere, string branch,
											  TableAttribute parentTable = null, TableColumnAttribute parentColumn = null,
											  string parentPrefix = "",
											  ChildAttribute childData = null,
											  bool loadChild = false, bool checkType = false, bool selectForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			if (fields == null) fields = new StringCollection();
			if (joins == null) joins = new StringCollection();
			if (subs == null) subs = new List<DbQuery>();
			//Определение атрибута сохраняемой таблицы
			TableAttribute currentTypeTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			//if (parentTable != null && parentColumn != null)
			//{
			//    //формирование запроса для отношения 1 к 1

			//    //Формирования табличного префикса в названии каждой колнки
			//    //из названия родтелькой таблицы и колонки
			//    string tablePrefix = parentTable.TableName + parentColumn.ColumnName;

			//    fields.Add(GetTypeFieldsOnly(type, tablePrefix));
			//    string leftJoin = "";
			//    leftJoin += String.Format("LEFT JOIN {0}.{1} {2} ON {3}.{4} = {5}.{6}.{7} \n",
			//                                          currentTypeTable.TableScheme, currentTypeTable.TableName, tablePrefix,
			//                                          tablePrefix, currentTypeTable.PrimaryKey,
			//                                          parentTable.TableScheme, parentTable.TableName, parentColumn.ColumnName);
			//    joins.Add(leftJoin);
			//}
			//else
			//{
			//    //Формирование строки запроса из полей заданного типа
			//    fields.Add(GetTypeFieldsOnly(type, includeTableNamePrefix ? "" : null, checkType, selectForced));
			//}
			if (parentTable != null && parentColumn != null)
			{
				//формирование запроса для отношения 1 к 1

				//Формирования табличного префикса в названии каждой колнки
				//из названия родтелькой таблицы и колонки
				string tablePrefix = parentTable.TableName + parentColumn.ColumnName;

				fields.Add(GetTypeFieldsOnly(type, tablePrefix));
				if (string.IsNullOrEmpty(parentPrefix))
				{
					parentPrefix = tablePrefix;
					string leftJoin =
						String.Format("LEFT JOIN {0}.{1} {2} ON {3}.{4} = {5}.{6}.{7} \n",
															currentTypeTable.TableScheme, currentTypeTable.TableName, tablePrefix,
															tablePrefix, currentTypeTable.PrimaryKey,
															parentTable.TableScheme, parentTable.TableName, parentColumn.ColumnName);
					joins.Add(leftJoin);
				}
				else
				{
					string leftJoin =
					String.Format("LEFT JOIN {0}.{1} {2} ON {3}.{4} = {5}.{6} \n",
													  currentTypeTable.TableScheme, currentTypeTable.TableName, tablePrefix,
													  tablePrefix, currentTypeTable.PrimaryKey,
													  parentPrefix, parentColumn.ColumnName);
					joins.Add(leftJoin);
				}
			}
			else
			{
				//Формирование строки запроса из полей заданного типа
				fields.Add(GetTypeFieldsOnly(type, includeTableNamePrefix ? "" : null, checkType, selectForced));
			}
			if (!loadChild) return;

			// Определение конструкций для загрузки вложенных типов (помеченных атрибутом Child), 
			// являющихся BaseSmartCoreObject

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к 1

			//определение своиств, имеющих атрибут "сохраняемое"
			//а так же являющихся вложенными типами
			//и имеющих отношение с данным типом 1 к 1
			List<PropertyInfo> properties;
			if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			foreach (PropertyInfo t in properties)
			{
				Type baseType = t.PropertyType;
				//Определение атрибута сохраняемой таблицы
				TableAttribute childTypeTable = (TableAttribute)t.PropertyType
												.GetCustomAttributes(typeof(TableAttribute), true)
												.FirstOrDefault();
				TableColumnAttribute tca = (TableColumnAttribute)t
											.GetCustomAttributes(typeof(TableColumnAttribute), true)
											.FirstOrDefault();
				ChildAttribute child = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name &&
						childTypeTable != null && child != null)
					{

						string oneToOneParentWhere =
							string.Format(" Select {0}.{1} from {0} {2}",
											currentTypeTable.TableName, tca.ColumnName,
											parentWhere);

						string currentBranch = branch + tca.ColumnName;
						//GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
						//                  ref fields, ref joins, ref subs, oneToOneParentWhere, currentBranch,
						//                  currentTypeTable, tca, child, child.LoadChild, false, selectForced);
						GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
										  ref fields, ref joins, ref subs, oneToOneParentWhere, currentBranch,
										  currentTypeTable, tca, parentPrefix, child, child.LoadChild, false, selectForced);
						break;
					}
					baseType = baseType.BaseType;
				}
			}
			#endregion

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к *

			//Поиск своиств имеющих только атрибут Child
			//с пареметром RelationType = 1 ко многим
			properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
											 .ToList();

			if(properties.Count == 0)return;

			foreach (PropertyInfo t in properties)
			{
				Type genericType = t.PropertyType;
				ChildAttribute currentChild = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (genericType != null)
				{
					if (genericType.Name == typeof(CommonCollection<>).Name)
					{
						Type genericArgument = genericType.GetGenericArguments()[0];
						Type baseType = genericArgument;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name)
							{
								//Определение атрибута сохраняемой таблицы
								string oneToManyParentWhere;
								string currentBranch = branch + t.Name;
								if(childData == null)
								{
									oneToManyParentWhere =
										string.Format(" Select {0}.{1} from [{2}].{0} {3}",
										currentTypeTable.TableName, currentTypeTable.PrimaryKey,
										currentTypeTable.TableScheme, parentWhere);
								}
								else
								{
									oneToManyParentWhere = parentWhere;
								}
								subs.AddRange(GetSelectSubQueryOneToMany(genericArgument, includeTableNamePrefix,
																		 currentBranch, currentChild, oneToManyParentWhere,
																		 currentChild.LoadChild, checkType, selectForced));
								break;
							}
							baseType = baseType.BaseType;
						}
						break;
					}
					genericType = genericType.BaseType;
				}
			}
			#endregion

			#region Определение конструкций для загрузки вложенных типов при отношении * к *

			//Поиск своиств имеющих только атрибут Child
			//с пареметром RelationType = многие ко многим
			properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.ManyToMany
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
											 .ToList();

			if (properties.Count == 0) return;

			foreach (PropertyInfo t in properties)
			{
				Type genericType = t.PropertyType;
				ChildAttribute currentChild = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (genericType != null)
				{
					if (genericType.Name == typeof(CommonCollection<>).Name)
					{
						Type genericArgument = genericType.GetGenericArguments()[0];
						Type baseType = genericArgument;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name)
							{
								//Определение атрибута сохраняемой таблицы
								string manyToManyParentWhere;
								string currentBranch = branch + t.Name;
								if (childData == null)
								{
									manyToManyParentWhere =
										string.Format(" Select {0}.{1} from [{2}].{0} {3}", // TODO:
										currentTypeTable.TableName, currentTypeTable.PrimaryKey,
										currentTypeTable.TableScheme, parentWhere);
								}
								else
								{
									manyToManyParentWhere = parentWhere;
								}
								subs.AddRange(GetSelectSubQueryManyToMany(genericArgument, includeTableNamePrefix,
																		  currentBranch, currentChild, manyToManyParentWhere,
																		  currentChild.LoadChild, checkType, selectForced));
								break;
							}
							baseType = baseType.BaseType;
						}
						break;
					}
					genericType = genericType.BaseType;
				}
			}
			#endregion
		}
		#endregion

		#region private static IEnumerable<DbQuery> GetSelectSubQueryOneToMany(Type type, bool includeTableNamePrefix, ChildAttribute childAttribute, string parentWhere, bool loadChild = false, bool checkType = false)

		private static IEnumerable<DbQuery> GetSelectSubQueryOneToMany(Type type, bool includeTableNamePrefix,
															string branch,
															ChildAttribute childAttribute, string parentWhere,
															bool loadChild = false, bool checkType = false, bool selectForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			List<DbQuery> queries = new List<DbQuery>();

			#region Формирование строки запроса из полей заданного типа
			TableAttribute currentTypeTable = (TableAttribute)type
									.GetCustomAttributes(typeof(TableAttribute), true)
									.FirstOrDefault();

			string query = GetTypeFieldsOnly(type, includeTableNamePrefix ? "" : null);
			string currentWhere;
			string currentBranch = branch;

			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			string whereConditionResult = " where ";

			for (int i = 0; i < attributes.Count; i++)
			{
				//if (attributes[i].ColumnName.ToLower() == "isdeleted" && getDeleted)
				//{
				//    //загружаются недействительные записи
				//    continue;
				//}
				whereConditionResult += currentTypeTable.TableName + "." + attributes[i].ColumnName + " = " + attributes[i].Condition;
				whereConditionResult += " and ";
			}

			if (childAttribute.ForeignKeyTypeColumn != null)
			{
				if(childAttribute.ForeignKeyTypeValues.Length == 1)
				{
					currentWhere =
						string.Format(" {0} {1}.{2} = {3} and {1}.{4} in ({5})",
							whereConditionResult,
							currentTypeTable.TableName, childAttribute.ForeignKeyTypeColumn,
							childAttribute.ForeignKeyTypeValues[0], childAttribute.ForeignKeyColumn,
							parentWhere);
				}
				else
				{
					string values = "";
					for (int i = 0; i < childAttribute.ForeignKeyTypeValues.Length; i++)
					{
						if (i > 0)
							values += ", ";
						values += childAttribute.ForeignKeyTypeValues[i];
					}
					currentWhere =
						string.Format(" {0} {1}.{2} in ({3}) and {1}.{4} in ({5})",
							whereConditionResult,
							currentTypeTable.TableName, childAttribute.ForeignKeyTypeColumn,
							values, childAttribute.ForeignKeyColumn,
							parentWhere);
				}
			}
			else
			{
				currentWhere =
					string.Format(" {0} {1}.{2} in ({3})",
								   whereConditionResult,
								   currentTypeTable.TableName, childAttribute.ForeignKeyColumn,
								   parentWhere);
			}

			#endregion

			if (!loadChild)
			{
				query = String.Format(@"Select {0} from[{1}].{2} {3}",
									   query,
									   currentTypeTable.TableScheme,
									   currentTypeTable.TableName,
									   currentWhere);
				queries.Add(new DbQuery(type, query, currentBranch));
				return queries;
			}

			StringCollection fields = null, joins = null;
			List<DbQuery> subs = null;
			// Определение конструкций для загрузки вложенных типов (помеченных атрибутом Child), 
			// являющихся BaseSmartCoreObject

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к 1

			//определение своиств, имеющих атрибут "сохраняемое"
			//а так же являющихся вложенными типами
			//и имеющих отношение с данным типом 1 к 1
			List<PropertyInfo> properties;
			if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			foreach (PropertyInfo t in properties)
			{
				Type baseType = t.PropertyType;
				//Определение атрибута сохраняемой таблицы
				TableAttribute childTypeTable = (TableAttribute)t.PropertyType
												.GetCustomAttributes(typeof(TableAttribute), true)
												.FirstOrDefault();
				TableColumnAttribute tca = (TableColumnAttribute)t
											.GetCustomAttributes(typeof(TableColumnAttribute), true)
											.FirstOrDefault();
				ChildAttribute child = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name &&
						childTypeTable != null && child != null)
					{

						string oneToOneParentWhere =
							string.Format(" Select {0}.{1} from {0} {2}",
											currentTypeTable.TableName, tca.ColumnName,
											currentWhere);
						//if(t.PropertyType.Name == "MaintenanceCheck")
						//{
						//    t.PropertyType.Name.ToString();
						//}
						//GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
						//                  ref fields, ref joins, ref subs, oneToOneParentWhere, 
						//                  currentBranch + tca.ColumnName,
						//                  currentTypeTable, tca, child, child.LoadChild, false, selectForced);
						GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
										 ref fields, ref joins, ref subs, oneToOneParentWhere,
										 currentBranch + tca.ColumnName,
										 currentTypeTable, tca, "", child, child.LoadChild, false, selectForced);

						if (subs.Count > 0)
						{
							queries.AddRange(subs);
							subs.Clear();
						}
						break;
					}
					baseType = baseType.BaseType;
				}
			}
			#endregion

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к *
			//Поиск своиств имеющих только атрибут Child
			//с пареметром RelationType = 1 ко многим
			properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
											 .ToList();

			foreach (PropertyInfo t in properties)
			{
				Type genericType = t.PropertyType;
				ChildAttribute child = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (genericType != null)
				{
					if (genericType.Name == typeof(CommonCollection<>).Name)
					{
						Type genericArgument = genericType.GetGenericArguments()[0];
						Type baseType = genericArgument;

						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name)
							{
								string oneToManyParentWhere =
									string.Format(" Select {0}.{1} from {0} {2}",
									currentTypeTable.TableName, currentTypeTable.PrimaryKey,
									currentWhere);
								queries.AddRange(GetSelectSubQueryOneToMany(genericArgument, includeTableNamePrefix,
																			currentBranch + t.Name, child, oneToManyParentWhere,
																			child.LoadChild, checkType, selectForced));
								break;
							}
							baseType = baseType.BaseType;
						}
						break;
					}
					genericType = genericType.BaseType;
				}
			}
			#endregion

			#region Добавление строк, сформированных в для объектов в соотношении 1 к 1

			if (fields != null)
			{
				query += ", ";
				for (int i = 0; i < fields.Count; i++)
				{
					query += fields[i];
					if (i < fields.Count - 1)
						query += ", ";
				}
			}
			query = String.Format(@"Select {0} from[{1}].{2}",
									query,
									currentTypeTable.TableScheme,
									currentTypeTable.TableName);
			//добавление конструкций JOIN для объектов в соотношении 1 к 1
			if (joins != null)
				query += " " + joins.Cast<string>().Aggregate("", (current, field) => current + field);
			//добавление конструкции Where
			query += currentWhere;
			queries.Add(new DbQuery(type, query, branch));

			#endregion

			return queries.ToArray();
		}

		#endregion

		#region private static IEnumerable<DbQuery> GetSelectSubQueryManyToMany(Type type, bool includeTableNamePrefix, ChildAttribute childAttribute, string parentWhere, bool loadChild = false, bool checkType = false)

		private static IEnumerable<DbQuery> GetSelectSubQueryManyToMany(Type type, bool includeTableNamePrefix,
																		string branch,
																		ChildAttribute childAttribute, string parentWhere,
																		bool loadChild = false, bool checkType = false, bool selectForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			List<DbQuery> queries = new List<DbQuery>();

			#region Формирование строки запроса из полей заданного и связующего типов

			TableAttribute currentTypeTable =
				(TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			string query = GetTypeFieldsOnly(type, includeTableNamePrefix ? "" : null);
			string currentWhere;
			string currentBranch = branch;



			Type binderType = childAttribute.Type;
			TableAttribute binderTypeTable =
				(TableAttribute)binderType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

			string binderQuery = GetTypeFieldsOnly(binderType, includeTableNamePrefix ? "" : null, loadChild:true);
			string binderWhere = " where ";
			string binderBranch = branch + binderTypeTable.TableName;

			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			string whereConditionResult = " where ";

			for (int i = 0; i < attributes.Count; i++)
			{
				//if (attributes[i].ColumnName.ToLower() == "isdeleted" && getDeleted)
				//{
				//    //загружаются недействительные записи
				//    continue;
				//}
				whereConditionResult += currentTypeTable.TableName + "." + attributes[i].ColumnName + " = " + attributes[i].Condition;
				whereConditionResult += " and ";
			}

			if (string.IsNullOrEmpty(childAttribute.ForeignKeyTypeColumn))
			{
				currentWhere = string.Format(" {0} {1}.{2} in ({3})",
											 whereConditionResult,
											 currentTypeTable.TableName, childAttribute.ForeignKeyColumn,
											 parentWhere);
				//binderWhere = ""; //todo:
			}
			else
			{

				//                string m =
				//                    @"where supplier.itemid in (select sipplierid 
				//		          from kitsupplierrelations 
				//			  where kitsupplierrelation.parenttype = accessorydescription and kitsupplierrelation.parentid in (select itemid 
				//										   from accessorydesc))";

				//                string q =
				//                    @"{0} {1}.{2} in (select {4}.{3} 
				//		              from {4} 
				//			          where {4}.{5} = {6} and {4}.{7} in ({5}))";
				string values = "";
				if (childAttribute.ForeignKeyTypeValues.Length == 1)
				{
					values = " = " + childAttribute.ForeignKeyTypeValues[0];
				}
				else
				{
					values = " in ( ";
					for (int i = 0; i < childAttribute.ForeignKeyTypeValues.Length; i++)
					{
						if (i > 0)
							values += ", ";
						values += childAttribute.ForeignKeyTypeValues[i];
					}
					values += ") ";
				}

				currentWhere = string.Format(@"{0} {1}.{2} in (select {4}.{3} 
                                                               from {4} 
                                                               where {4}.IsDeleted = 0 and {4}.{5} {6} and {4}.{7} in ({8}))",
											 whereConditionResult,
											 currentTypeTable.TableName, currentTypeTable.PrimaryKey,
											 childAttribute.ForeignKeyColumn2,
											 binderTypeTable.TableName, childAttribute.ForeignKeyTypeColumn, values,
											 childAttribute.ForeignKeyColumn,
											 parentWhere);

				binderWhere += string.Format(@"{0}.{1} {2} and {0}.{3} in ({4})",
											 binderTypeTable.TableName, childAttribute.ForeignKeyTypeColumn, values,
											 childAttribute.ForeignKeyColumn,
											 parentWhere);
			}

			#endregion

			if (!loadChild)
			{
				query = String.Format(@"Select {0} from[{1}].{2} {3}",
									   query,
									   currentTypeTable.TableScheme,
									   currentTypeTable.TableName,
									   currentWhere);
				queries.Add(new DbQuery(type, query, currentBranch));

				binderQuery = String.Format(@"Select {0} from[{1}].{2} {3}",
									   binderQuery,
									   binderTypeTable.TableScheme,
									   binderTypeTable.TableName,
									   binderWhere);
				queries.Add(new DbQuery(binderType, binderQuery, binderBranch));

				return queries;
			}

			StringCollection fields = null, joins = null;
			List<DbQuery> subs = null;
			// Определение конструкций для загрузки вложенных типов (помеченных атрибутом Child), 
			// являющихся BaseSmartCoreObject

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к 1

			//определение своиств, имеющих атрибут "сохраняемое"
			//а так же являющихся вложенными типами
			//и имеющих отношение с данным типом 1 к 1
			List<PropertyInfo> properties;
			if (selectForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									   && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			foreach (PropertyInfo t in properties)
			{
				Type baseType = t.PropertyType;
				//Определение атрибута сохраняемой таблицы
				TableAttribute childTypeTable = (TableAttribute)t.PropertyType
												.GetCustomAttributes(typeof(TableAttribute), true)
												.FirstOrDefault();
				TableColumnAttribute tca = (TableColumnAttribute)t
											.GetCustomAttributes(typeof(TableColumnAttribute), true)
											.FirstOrDefault();
				ChildAttribute child = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name &&
						childTypeTable != null && child != null)
					{

						string oneToOneParentWhere =
							string.Format(" Select {0}.{1} from {0} {2}",
											currentTypeTable.TableName, tca.ColumnName,
											currentWhere);
						//if(t.PropertyType.Name == "MaintenanceCheck")
						//{
						//    t.PropertyType.Name.ToString();
						//}
						//GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
						//                  ref fields, ref joins, ref subs, oneToOneParentWhere,
						//                  currentBranch + tca.ColumnName,
						//                  currentTypeTable, tca, child, child.LoadChild, false, selectForced);
						GetSelectSubQuery(t.PropertyType, includeTableNamePrefix,
										  ref fields, ref joins, ref subs, oneToOneParentWhere,
										  currentBranch + tca.ColumnName,
										  currentTypeTable, tca, "", child, child.LoadChild, false, selectForced);

						if (subs.Count > 0)
						{
							queries.AddRange(subs);
							subs.Clear();
						}
						break;
					}
					baseType = baseType.BaseType;
				}
			}
			#endregion

			#region Определение конструкций для загрузки вложенных типов при отношении 1 к *
			//Поиск своиств имеющих только атрибут Child
			//с пареметром RelationType = 1 ко многим
			properties = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
														 && p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
														 && ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
											 .ToList();

			foreach (PropertyInfo t in properties)
			{
				Type genericType = t.PropertyType;
				ChildAttribute child = (ChildAttribute)t
											.GetCustomAttributes(typeof(ChildAttribute), true)
											.FirstOrDefault();
				while (genericType != null)
				{
					if (genericType.Name == typeof(CommonCollection<>).Name)
					{
						Type genericArgument = genericType.GetGenericArguments()[0];
						Type baseType = genericArgument;
						currentBranch += t.Name;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name)
							{
								string oneToManyParentWhere =
									string.Format(" Select {0}.{1} from {0} {2}",
									currentTypeTable.TableName, currentTypeTable.PrimaryKey,
									currentWhere);
								queries.AddRange(GetSelectSubQueryOneToMany(genericArgument, includeTableNamePrefix,
																			currentBranch, child, oneToManyParentWhere,
																			child.LoadChild, checkType, selectForced));
								break;
							}
							baseType = baseType.BaseType;
						}
						break;
					}
					genericType = genericType.BaseType;
				}
			}
			#endregion

			#region Добавление строк, сформированных в для объектов в соотношении 1 к 1

			if (fields != null)
			{
				query += ", ";
				for (int i = 0; i < fields.Count; i++)
				{
					query += fields[i];
					if (i < fields.Count - 1)
						query += ", ";
				}
			}
			query = String.Format(@"Select {0} from[{1}].{2}",
									query,
									currentTypeTable.TableScheme,
									currentTypeTable.TableName);
			//добавление конструкций JOIN для объектов в соотношении 1 к 1
			if (joins != null)
				query += " " + joins.Cast<string>().Aggregate("", (current, field) => current + field);
			//добавление конструкции Where
			query += currentWhere;
			queries.Add(new DbQuery(type, query, branch));

			binderQuery = String.Format(@"Select {0} from[{1}].{2} {3}",
									   binderQuery,
									   binderTypeTable.TableScheme,
									   binderTypeTable.TableName,
									   binderWhere);
			queries.Add(new DbQuery(binderType, binderQuery, binderBranch));

			#endregion

			return queries.ToArray();
		}

		#endregion

		#region public static String GetSelectQueryWithWhere(Type type, IQueryFilter[] filters = null, bool loadFullHierarchy = false, bool checkType = false)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД  
		/// </summary>
		public static String GetSelectQueryWithWhere(Type type,
													 ICommonFilter[] filters = null,
													 bool loadChild = false,
													 bool checkType = false,
													 bool getDeleted = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			#region Определение конструкции Where для фильтрации по основному типу

			ConditionAttribute isDeletedAttr =
				attributes.Where(a => a.ColumnName.ToLower() == "isdeleted").FirstOrDefault();

			if (getDeleted && isDeletedAttr != null)
				attributes.Remove(isDeletedAttr);

			string whereConditionResult = " where ";

			for (int i = 0; i < attributes.Count; i++)
			{
				//if (attributes[i].ColumnName.ToLower() == "isdeleted" && getDeleted)
				//{
				//    //загружаются недействительные записи
				//    continue;
				//}
				whereConditionResult += dbTable.TableName + "." + attributes[i].ColumnName + " = " + attributes[i].Condition;
				if (i < attributes.Count - 1) whereConditionResult += " and ";
			}

			string filterString = GetFiltersString(dbTable, filters);

			if (filterString.Trim() != "")
			{
				//Если строка фильтра и строка состояния объекта не является пустой
				//в конец строки состояния добавляется слово and
				if (whereConditionResult != " where ") whereConditionResult += " and ";

				//добавление строки фильтрации в конец строки состояния объекта
				whereConditionResult += filterString;
			}
			#endregion

			if ((attributes.Count == 0 || (attributes.Count == 1 && attributes[0].ColumnName.ToLower() == "isdeleted" && getDeleted))
				&& (filters == null || filters.Length == 0))
			{
				return GetSelectQueryWithoutWhere(type, "", loadChild ? true : false, loadChild)[0].QueryString;
			}

			return GetSelectQueryWithoutWhere(type, whereConditionResult, loadChild ? true : false, loadChild)[0].QueryString + whereConditionResult;
		}
		#endregion

		#region public static List<DbQuery> GetSelectQueryWithWhereAll(Type type, IQueryFilter[] filters = null, bool loadFullHierarchy = false, bool checkType = false, bool getForced = false)
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД  
		/// </summary>
		public static List<DbQuery> GetSelectQueryWithWhereAll(Type type,
													 ICommonFilter[] filters = null,
													 bool loadChild = false,
													 bool checkType = false,
													 bool getDeleted = false,
													 bool getForced = false,
													 bool ignoreConditions = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				if(!type.IsSubclassOf(typeof(BaseEntityObject)))
				{
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			#region Определение конструкции Where для фильтрации по основному типу

			ConditionAttribute isDeletedAttr = attributes.FirstOrDefault(a => a.ColumnName.ToLower() == "isdeleted");
			if (ignoreConditions && isDeletedAttr != null)
			{
				attributes.Clear();
				attributes.Add(isDeletedAttr);
			}
			if (getDeleted && isDeletedAttr != null)
				attributes.Remove(isDeletedAttr);

			string whereConditionResult = " where ";

			for (int i = 0; i < attributes.Count; i++)
			{
				//if (attributes[i].ColumnName.ToLower() == "isdeleted" && getDeleted)
				//{
				//    //загружаются недействительные записи
				//    continue;
				//}
				whereConditionResult += dbTable.TableName + "." + attributes[i].ColumnName + " = " + attributes[i].Condition;
				if (i < attributes.Count - 1) whereConditionResult += " and ";
			}

			string filterString = GetFiltersString(dbTable, filters);

			if (filterString.Trim() != "")
			{
				//Если строка фильтра и строка состояния объекта не является пустой
				//в конец строки состояния добавляется слово and
				if (whereConditionResult != " where ") whereConditionResult += " and ";

				//добавление строки фильтрации в конец строки состояния объекта
				whereConditionResult += filterString;
			}
			#endregion

			if ((attributes.Count == 0 || (attributes.Count == 1 && attributes[0].ColumnName.ToLower() == "isdeleted" && getDeleted))
				&& (filters == null || filters.Length == 0))
			{
				return GetSelectQueryWithoutWhere(type, "", loadChild ? true : false, loadChild, false, getForced);
			}

			List<DbQuery> queries = GetSelectQueryWithoutWhere(type, whereConditionResult, loadChild ? true : false,
															   loadChild, false, getForced);
			queries[0].QueryString += whereConditionResult;

			return queries;
		}
		#endregion

		#region public static string GetSelectQueryPrimaryColumnOnly(Type type, PropertyInfo columnProperty, IQueryFilter[] filters = null, bool checkType = false, bool getForced = false)
		/// <summary>
		/// Возвращает строку SQL запроса на выборку данных из БД. Выбирается только данные переданной колонки
		/// </summary>
		public static string GetSelectQueryColumnOnly(Type type,
													  PropertyInfo columnProperty,
													  ICommonFilter[] filters = null,
													  bool checkType = false,
													  bool getDeleted = false,
													  bool getForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				if (!type.IsSubclassOf(typeof(BaseEntityObject)))
				{
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion

			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//Определение атрибута сохраняемой таблицы
			TableColumnAttribute tableColumn = (TableColumnAttribute)columnProperty.GetCustomAttributes(typeof(TableColumnAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			#region Определение конструкции Where для фильтрации по основному типу

			ConditionAttribute isDeletedAttr = attributes.FirstOrDefault(a => a.ColumnName.ToLower() == "isdeleted");

			if (getDeleted && isDeletedAttr != null)
				attributes.Remove(isDeletedAttr);

			string whereConditionResult = " where ";

			for (int i = 0; i < attributes.Count; i++)
			{
				//if (attributes[i].ColumnName.ToLower() == "isdeleted" && getDeleted)
				//{
				//    //загружаются недействительные записи
				//    continue;
				//}
				whereConditionResult += dbTable.TableName + "." + attributes[i].ColumnName + " = " + attributes[i].Condition;
				if (i < attributes.Count - 1) whereConditionResult += " and ";
			}

			string filterString = GetFiltersString(dbTable, filters);

			if (filterString.Trim() != "")
			{
				//Если строка фильтра и строка состояния объекта не является пустой
				//в конец строки состояния добавляется слово and
				if (whereConditionResult != " where ") whereConditionResult += " and ";

				//добавление строки фильтрации в конец строки состояния объекта
				whereConditionResult += filterString;
			}
			#endregion

			string result = string.Format("Select {0} from [{1}].{2}", tableColumn.ColumnName, dbTable.TableScheme, dbTable.TableName);

			if ((attributes.Count == 0 || (attributes.Count == 1 && attributes[0].ColumnName.ToLower() == "isdeleted" && getDeleted))
				&& (filters == null || filters.Length == 0))
			{
				return result;
			}

			result += whereConditionResult;

			return result;
		}
		#endregion


		#region public static String GetSelectQueryById<T>(Int32 itemId) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД по заданному Id 
		/// <br/> IsDeleted и другие состояния записи игнорируются
		/// </summary>
		public static String GetSelectQueryById<T>(Int32 itemId, bool loadChild = false) where T : BaseEntityObject, new()
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации

			return GetSelectQueryWithoutWhere(typeof(T), "", loadChild ? true : false, loadChild)[0].QueryString +
				string.Format(@"where {0}.{1} = {2}", dbTable.TableName, dbTable.PrimaryKey, itemId);

		}
		#endregion

		#region public static String GetSelectQueryByIdRange<T>(int[] itemIds) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQueryByIdRange<T>(int[] itemIds) where T : BaseEntityObject, new()
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();


			string s = "";
			for (int i = 0; i < itemIds.Length; i++)
			{
				s += itemIds[i].ToString();
				if (i < itemIds.Length - 1) s += ",";
			}

			if (attributes.Count == 0)  return GetSelectQueryWithWhere<T>() + string.Format(@"where {0} in ({1})", dbTable.PrimaryKey, s);
			return GetSelectQueryWithWhere<T>() + string.Format(@"and {0} in ({1})", dbTable.PrimaryKey, s);
		}
		#endregion

		#region public static String GetSelectQueryWithWhereById<T>() where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД 
		/// </summary>
		public static String GetSelectQueryWithWhereById<T>(int itemId, bool loadChild = false) where T : BaseEntityObject, new()
		{
			//определение типа
			Type type = typeof(T);
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение атрибутов фильтрации
			List<ConditionAttribute> attributes =
				type.GetCustomAttributes(typeof(ConditionAttribute), false).Cast<ConditionAttribute>().ToList();

			if (attributes.Count == 0) return GetSelectQueryWithWhere(type, loadChild:loadChild) +
				string.Format(@"where {0}.{1} = {2}", dbTable.TableName, dbTable.PrimaryKey, itemId);

			return GetSelectQueryWithWhere(type, loadChild:loadChild) + string.Format(@"and {0}.{1} = {2}", dbTable.TableName, dbTable.PrimaryKey, itemId);
		}
		#endregion

		#region public static List<DbQuery> GetSelectQueryWithWhereAll<T>(IQueryFilter[] filters = null, bool loadChild = false, bool checkType = false, bool getDeleted = false) where T : BaseEntityObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на селектирование данных из БД  
		/// </summary>
		public static List<DbQuery> GetSelectQueryWithWhereAll<T>(ICommonFilter[] filters = null,
																  bool loadChild = false,
																  bool getDeleted = false) where T : BaseEntityObject, new()
		{
			return GetSelectQueryWithWhereAll(typeof(T), filters, loadChild, getDeleted);
		}
		#endregion

		#region public static string GetSelectQueryColumnOnly<T>(PropertyInfo columnProperty, ICommonFilter[] filters = null, bool getDeleted = false) where T : BaseEntityObject, new()
		/// <summary>
		/// Возвращает строку SQL запроса на выборку данных из определенной колонки таблицы БД
		/// </summary>
		public static string GetSelectQueryColumnOnly<T>(PropertyInfo columnProperty, ICommonFilter[] filters = null, bool getDeleted = false) where T : BaseEntityObject, new()
		{
			return GetSelectQueryColumnOnly(typeof(T), columnProperty, filters, getDeleted);
		}
		#endregion


		#region public static void SetFields(IEnumerable items, DataSet dataSet, bool setForced = false)
		/// <summary>
		/// Заполняет поля объектов
		/// </summary>
		/// <param name="items">Коллекция объектов для заполнения. Объекты дложны иметь itemID > 0</param>
		/// <param name="dataSet">Набор данных содержащий данные для заполнения</param>
		/// <param name="setForced">Флаг, Заполнять принудительные поля</param>
		public static void SetFields(IEnumerable items, DataSet dataSet, bool setForced = false)
		{
			if(items == null || items.OfType<BaseEntityObject>().Count() == 0|| dataSet == null)return;

			List<BaseEntityObject> objects = items.OfType<BaseEntityObject>().ToList();
			Type type = objects[0].GetType();

			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;
			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												||(p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}

			foreach (PropertyInfo t in properties)
			{
				Type baseType = t.PropertyType;
				bool isBaseSmartCore = false;
				bool isBaseEntityOneToMany = false;
				bool isBaseEntityManyToMany = false;

				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name &&
						(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
						 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
						t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
					{
						//Если тип своиства является наследником BaseSmartCoreObject
						//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
						isBaseSmartCore = true;
						break;
					}
					if (baseType.Name == typeof(CommonCollection<>).Name
						&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
						&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
						&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
					{
						if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany &&
						    ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseEntityOneToMany = true;
							break;
						}
						if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.ManyToMany)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseEntityManyToMany = true;
							break;
						}
					}
					baseType = baseType.BaseType;
				}

				TableColumnAttribute tca =
					(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
				SubQueryAttribute cca =
					(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
				ChildAttribute cha =
					(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();

				foreach (BaseEntityObject item in objects)
				{
					DataRow row = dataSet.Tables[0].Rows
						.Cast<DataRow>()
						.FirstOrDefault(r => (int)r[dbTable.TableName + dbTable.PrimaryKey] == item.ItemId);
					if(row == null) continue;

					object value = null;
					if (isBaseSmartCore)
					{
						//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
						//полей этого типа
						CasDataTable table = dataSet.Tables[0] as CasDataTable;
						string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");
						value = table != null
							? FillChildOneToOne(t.PropertyType, row, table, dataSet, cha, tablePrefix, setForced)
							: null;
					}
					else if (isBaseEntityOneToMany)
					{
						//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
						//полей этого типа
						//Поиск атрибута определяющего отношения объектов
						CasDataTable table = dataSet.Tables[0] as CasDataTable;
						//Определение текущей ветки запроса
						string currentBranch = table != null ? table.Branch + t.Name : t.Name;
						//Поиск таблицы, содержащие данные нужной ветки запроса
						CasDataTable dataTable =
							dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
						value = dataTable != null
							? FillChildOneToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, true, setForced)
							: null;
					}
					else if (isBaseEntityManyToMany)
					{
						//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
						//полей этого типа
						//Поиск атрибута определяющего отношения объектов
						CasDataTable table = dataSet.Tables[0] as CasDataTable;
						//Определение текущей ветки запроса
						string currentBranch = table != null ? table.Branch + t.Name : t.Name;
						//Поиск таблицы, содержащие данные нужной ветки запроса
						CasDataTable dataTable =
							dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
						value = dataTable != null
							? FillChildManyToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, true, setForced)
							: null;
					}
					else
					{
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + cca.ColumnName]);
					}
					t.SetValue(item, value, null);
				}
			}
		}
		#endregion

		#region public static void SetFields(BaseEntityObject item, DataSet dataSet, bool setForced = false)
		/// <summary>
		/// Заполняет поля объекта
		/// </summary>
		/// <param name="item">объект для заполнения. Объект должен иметь itemID > 0</param>
		/// <param name="dataSet">Набор данных содержащий данные для заполнения</param>
		/// <param name="setForced">Флаг, Заполнять принудительные поля</param>
		public static void SetFields(BaseEntityObject item, DataSet dataSet, bool setForced = false)
		{
			if (item == null || dataSet == null) return;

			Type type = item.GetType();

			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;
			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
			}

			foreach (PropertyInfo t in properties)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();

				DataRow row = dataSet.Tables[0].Rows
						.Cast<DataRow>()
						.FirstOrDefault(r => (int)r[dbTable.TableName + dbTable.PrimaryKey] == item.ItemId);
				if (row == null) continue;

				object value;
				if (!(string.IsNullOrEmpty(tca.TypeBy)))
				{
					PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
					if (typeProperty != null)
					{
						SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
						if (coreType != null && coreType.ObjectType != null)
							value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
						else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
					}
					else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
				}
				else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);

				t.SetValue(item, value, null);
			}
		}
		#endregion

		#region public static void Fill(DataRow row, BaseCasObject item)

		/// <summary>
		/// Заполняет поля 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="item"></param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		public static void Fill(DataRow row, BaseEntityObject item, bool setForced = false)
		{
			//определение типа 
			Type T = item.GetType();
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)T.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;
			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				T.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
											 ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				T.GetProperties().Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
											 ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
											 ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false).ToList();
			}
			foreach (PropertyInfo t in properties)
			{
				TableColumnAttribute tca =
					(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();

				object value;
				if(!(string.IsNullOrEmpty(tca.TypeBy)))
				{
					PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
					if (typeProperty != null)
					{
						SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
						if (coreType != null && coreType.ObjectType != null)
							value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
						else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
					}
					else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
				}
				else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);

				t.SetValue(item, value, null);
			}
		}
		#endregion

		#region private static object FillChild(DataRow row, Type type)

		/// <summary>
		/// Заполняет поля 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="type"></param>
		/// <param name="tablePrefix"></param>
		/// <param name="loadChild"></param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		private static object FillChild(DataRow row, Type type, string tablePrefix = "", bool loadChild = false, bool setForced = false)
		{
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (dbTable == null || DbTypes.ToInt32(row[tablePrefix + dbTable.PrimaryKey]) <= 0)
				return null;

			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
									   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
									   || p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			object ob = type.GetConstructor(new Type[0]).Invoke(null);
			//префикс перед полем таблицы
			if (string.IsNullOrEmpty(tablePrefix)) tablePrefix = dbTable.TableName;

			foreach (PropertyInfo t in properties)
			{
				Type baseType = t.PropertyType;
				bool isBaseSmartCore = false;
				object value = null;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name &&
						(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
						 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
						t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
					{
						//Если тип своиства является наследником BaseSmartCoreObject
						//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
						isBaseSmartCore = true;
						break;
					}
					baseType = baseType.BaseType;
				}
				if (isBaseSmartCore)
				{
					//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
					//полей этого типа
					TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
					SubQueryAttribute cca =
						(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();

					string childTablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

					value = FillChild(row, t.PropertyType, childTablePrefix, setForced);
				}
				else
				{
					TableColumnAttribute tca =
						(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
					if (tca != null)
						if (!(string.IsNullOrEmpty(tca.TypeBy)))
						{
							PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
							if (typeProperty != null)
							{
								SmartCoreType coreType = typeProperty.GetValue(ob, null) as SmartCoreType;
								if (coreType != null && coreType.ObjectType != null)
									value = DbTypes.GetValue(coreType.ObjectType, row[tablePrefix + tca.ColumnName]);
								else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
						}
						else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);

					SubQueryAttribute cca =
						(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
					if (cca != null)
						value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + cca.ColumnName]);
				}
				t.SetValue(ob, value, null);
			}

			return ob;
		}
		#endregion

		#region private static object FillChild(DataRow row, Type type)

		/// <summary>
		/// Заполняет поля 
		/// </summary>
		/// <param name="elementType">Тип объекта</param>
		/// <param name="row">Строка, из которой берутся данные для заполения объета</param>
		/// <param name="dataTable">Таблица, содержащая строку с данными</param>
		/// <param name="dataSet">Набор данных, содержащий все таблицы запроса</param>
		/// <param name="childAttribute"></param>
		/// <param name="tablePrefix"></param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		private static object FillChildOneToOne(Type elementType, DataRow row, CasDataTable dataTable, DataSet dataSet,
												ChildAttribute childAttribute,
												string tablePrefix = "", bool setForced = false)
		{

			if (childAttribute == null || elementType == null)
			{
				//Если не задан атрибут, определяющий взаимоотношения между родителем и дочерним элементом
				//то невозможно определить каким образом формировать дочерний элемент
				return null;
			}

			Type type = elementType;
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			if (dbTable == null || DbTypes.ToInt32(row[tablePrefix + dbTable.PrimaryKey]) <= 0)
				return null;
			//Создание нового эдемента
			BaseEntityObject item = (BaseEntityObject)type.GetConstructor(new Type[0]).Invoke(null);
			if (childAttribute.LoadChild)
			{
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0).ToList();
				}

				//префикс перед полем таблицы
				if (string.IsNullOrEmpty(tablePrefix)) tablePrefix = dbTable.TableName;


				foreach (PropertyInfo t in properties)
				{
					Type baseType = t.PropertyType;
					bool isBaseSmartCore = false;
					bool isBaseEntityOneToMany = false;
					object value = null;
					while (baseType != null)
					{
						if (baseType.Name == typeof(BaseEntityObject).Name &&
							(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
							 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
							t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseSmartCore = true;
							break;
						}

						if (baseType.Name == typeof(CommonCollection<>).Name
									&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
									&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
									&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
									&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
									&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseEntityOneToMany = true;
							break;
						}
						baseType = baseType.BaseType;
					}
					if (isBaseSmartCore)
					{
						//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
						//полей этого типа
						TableColumnAttribute tca =
									(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();

						string childTablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

						value = FillChild(row, t.PropertyType, childTablePrefix, setForced);

						//if (t.PropertyType.Name == "GoodStandart" && value != null &&
						//    ((GoodStandart) value).FullName != "")
						//{
						//    t.PropertyType.Name.ToString();
						//}
					}
					else if (isBaseEntityOneToMany)
					{
						//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
						//полей этого типа
						//Поиск атрибута определяющего отношения объектов
						ChildAttribute cha =
							(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
						//Определение родительского объекта
						BaseEntityObject parent = string.IsNullOrEmpty(cha.ParentProperty) ? null : item;
						//Определение текущей ветки запроса
						string currentBranch = dataTable.Branch + t.Name;
						//Поиск таблицы, содержащие данные нужной ветки запроса
						CasDataTable typeDataTable =
							dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
						value = typeDataTable != null
							? FillChildOneToMany(typeDataTable, t.PropertyType, dataSet, cha, parent, cha.LoadChild, true, setForced)
							: null;
					}
					else
					{
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, row[tablePrefix + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + cca.ColumnName]);
					}
					t.SetValue(item, value, null);
				}

				return item;
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				//префикс перед полем таблицы
				if (string.IsNullOrEmpty(tablePrefix))
					tablePrefix = dbTable.TableName;

				foreach (PropertyInfo t in properties)
				{
					object value = null;
					TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
					if (tca != null)
						if (!(string.IsNullOrEmpty(tca.TypeBy)))
						{
							PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
							if (typeProperty != null)
							{
								SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
								if (coreType != null && coreType.ObjectType != null)
									value = DbTypes.GetValue(coreType.ObjectType, row[tablePrefix + tca.ColumnName]);
								else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
						}
						else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);

					SubQueryAttribute cca =
						(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
					if (cca != null)
						value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + cca.ColumnName]);

					t.SetValue(item, value, null);
				}
			}
			return item;
		}
		#endregion

		#region private static ICommonCollection FillChildOneToMany(CasDataTable dataTable, Type collectionGenericType, DataSet dataSet, ChildAttribute childAttribute, BaseEntityObject parentObject = null,bool loadChild = false, bool checkType = false)

		/// <summary>
		/// Заполняет поля для объектов в соотношении 1 к *
		/// </summary>
		/// <param name="dataTable">Таблица содержащая элементы</param>
		/// <param name="collectionGenericType">Тип, определяющий тип коллекции для элементов</param>
		/// <param name="dataSet">Набор данных, содержащий все таблицы</param>
		/// <param name="childAttribute">Атрибут, определяющий взаимоотношения объектов данного типа с родителем</param>
		/// <param name="parentObject">Родительский объект для элементов</param>
		/// <param name="loadChild">загружать дочерние данные (помеченные атрибутом child)</param>
		/// <param name="checkType">производить проверку типа на возможность построения элементов</param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		private static ICommonCollection FillChildOneToMany(CasDataTable dataTable, Type collectionGenericType,
															DataSet dataSet,
															ChildAttribute childAttribute, BaseEntityObject parentObject,
															bool loadChild = false, bool checkType = false, bool setForced = false)
		{
			#region Проверка типа

			if (parentObject == null || childAttribute == null ||
				string.IsNullOrEmpty(childAttribute.ForeignKeyColumn))
			{
				//Если родительский объект не задан, 
				//то нельзя определить элементы пренадлежащие именно ему
				//Если не задан атрибут, определяющий взаимоотношения между родителем и дочерними элементами
				//то невозможно определить по каким критериям опередлять объекты пренадлежащие данному родителю
				return null;
			}

			Type type = dataTable.ElementType;

			if (checkType)
			{
				if (dataTable.ElementType == null)
					throw new NullReferenceException("dataTable.ElementType не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = dataTable.ElementType;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new Exception("dataTable.ElementType не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => ((p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly))
												&& p.GetCustomAttributes(typeof(ParentAttribute), false).Length == 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => ((p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly))
												&& p.GetCustomAttributes(typeof(ParentAttribute), false).Length == 0).ToList();
			}
			#region Фильтрация строк

			List<DataRow> rows = new List<DataRow>();
			if (string.IsNullOrEmpty(childAttribute.ForeignKeyTypeColumn))
			{
				//Производится проверка на наличие колонки с внешним ключем в переданной таблице
				if (dataTable.Columns.Contains(dbTable.TableName + childAttribute.ForeignKeyColumn))
				{
					//Колонка с внешним ключем присутствует в таблице
					//В список строк добавляются строки имеющие определенное значение (parentObject.ItemId)
					//в колонке с внешним ключем
					rows.AddRange(dataTable.Rows.Cast<DataRow>()
												.Where(row => (int)row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId));
				}
				else
				{
					//Колонка с внешним ключем отсутствует в таблице    

					//Это может произойти если свойство из данного типа (dataTable.ElementType), 
					//помеченное как ссылка на родителя
					//является для данного типа (dataTable.ElementType) дочерним объектом

					//Нужно найти в данном типе свойство, которое сохраняется в БД
					//в колонке с названием, прописанным во внешнем ключе
					PropertyInfo fkp =
						properties.FirstOrDefault(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).ColumnName == childAttribute.ForeignKeyColumn);
					if(fkp != null)
					{
						TableAttribute fkpTable = (TableAttribute)fkp.PropertyType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
						if (fkpTable != null &&
						   dataTable.Columns.Contains(dbTable.TableName + fkp.Name + fkpTable.PrimaryKey))
						{
							rows.AddRange(dataTable.Rows.Cast<DataRow>()
														.Where(row => (int)row[dbTable.TableName + fkp.Name + fkpTable.PrimaryKey] == parentObject.ItemId));
						}
					}
				}
			}
			else
			{
				rows.AddRange(dataTable.Rows.Cast<DataRow>()
											.Where(row => (int)row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId &&
														  (int)row[dbTable.TableName + childAttribute.ForeignKeyTypeColumn] == parentObject.SmartCoreObjectType.ItemId));
			}

			//rows.AddRange(string.IsNullOrEmpty(childAttribute.ForeignKeyTypeColumn)
			//                  ? dataTable.Rows.Cast<DataRow>()
			//                                  .Where(row => (int) row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId)
			//                  : dataTable.Rows.Cast<DataRow>()
			//                                  .Where(row => (int) row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId &&
			//                                                (int) row[dbTable.TableName + childAttribute.ForeignKeyTypeColumn] == parentObject.SmartCoreObjectType.ItemId));

			if (rows.Count == 0) return null;
			#endregion

			PropertyInfo pk = properties.FirstOrDefault(p => p.Name == "ItemId");
			if (pk != null) properties.Remove(pk);

			ICommonCollection items = (ICommonCollection)Activator.CreateInstance(collectionGenericType);
			if (loadChild)
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					//Если свойство, хранящее хнаяения для поля ItemID найдено, то оно заполняется первым
					if (pk != null) pk.SetValue(item, DbTypes.GetValue(typeof(int), rows[i][dbTable.TableName + dbTable.PrimaryKey]), null);

					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						bool isBaseEntityOneToMany = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							if (baseType.Name == typeof(CommonCollection<>).Name
								&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
								&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
								&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseEntityOneToMany = true;
								break;
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();

							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChildOneToOne(t.PropertyType, rows[i], dataTable, dataSet, cha, tablePrefix, setForced);
						}
						else if (isBaseEntityOneToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currebtBranch = dataTable.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable typeDataTable =
								dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currebtBranch);
							value = typeDataTable != null
								? FillChildOneToMany(typeDataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, checkType, setForced)
								: null;
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if (tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}

			#region Выставление родителя

			if (!string.IsNullOrEmpty(childAttribute.ParentProperty))
			{
				//Если в атрибуте взаимоотношения элементов данного типа с
				//другими элементами определено родительское своиство и задан сам родитель
				//то нужно произвести попытку присвоения родителя каждому из элементов

				//Поиск своиства, ссылающегося на родителя
				PropertyInfo parentProperty = type.GetProperty(childAttribute.ParentProperty);

				if(parentProperty != null)
				{
					Type baseType = parentProperty.PropertyType;
					bool isBaseSmartCore = false;
					while (baseType != null)
					{
						if (baseType.Name == typeof(BaseEntityObject).Name ||
							baseType.GetInterface(typeof(IBaseEntityObject).Name) != null)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseSmartCore = true;
							break;
						}
						baseType = baseType.BaseType;
					}
					if(isBaseSmartCore)
					{
						foreach (object item in items)
						{
							parentProperty.SetValue(item, parentObject, null);
						}
					}
				}
			}
			#endregion

			return items;
		}
		#endregion

		#region private static ICommonCollection FillChildManyToMany(CasDataTable dataTable, Type collectionGenericType, DataSet dataSet, ChildAttribute childAttribute, BaseEntityObject parentObject = null,bool loadChild = false, bool checkType = false)

		/// <summary>
		/// Заполняет поля для объектов в соотношении 1 к *
		/// </summary>
		/// <param name="dataTable">Таблица содержащая элементы</param>
		/// <param name="binderTable">Таблица содержащая свями между текущим и родительский элементом</param>
		/// <param name="collectionGenericType">Тип, определяющий тип коллекции для элементов</param>
		/// <param name="dataSet">Набор данных, содержащий все таблицы</param>
		/// <param name="childAttribute">Атрибут, определяющий взаимоотношения объектов данного типа с родителем</param>
		/// <param name="parentObject">Родительский объект для элементов</param>
		/// <param name="loadChild">загружать дочерние данные (помеченные атрибутом child)</param>
		/// <param name="checkType">производить проверку типа на возможность построения элементов</param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		private static ICommonCollection FillChildManyToMany(CasDataTable dataTable,
															 Type collectionGenericType,
															 DataSet dataSet,
															 ChildAttribute childAttribute, BaseEntityObject parentObject,
															 bool loadChild = false, bool checkType = false, bool setForced = false)
		{
			#region Проверка типа

			if (parentObject == null || childAttribute == null ||
				childAttribute.Type == null ||
				string.IsNullOrEmpty(childAttribute.ForeignKeyColumn))
			{
				//Если родительский объект не задан, 
				//то нельзя определить элементы пренадлежащие именно ему
				//Если не задан атрибут, определяющий взаимоотношения между родителем и дочерними элементами
				//то невозможно определить по каким критериям опередлять объекты пренадлежащие данному родителю
				return null;
			}

			Type type = dataTable.ElementType;
			Type binderType = childAttribute.Type;

			if (checkType)
			{
				if (dataTable.ElementType == null)
					throw new NullReferenceException("dataTable.ElementType не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = dataTable.ElementType;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new Exception("dataTable.ElementType не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//Определение атрибута связной таблицы
			TableAttribute binderTypeTable = (TableAttribute)binderType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			CasDataTable binderTable =
			   dataSet.Tables.OfType<CasDataTable>()
							 .FirstOrDefault(tb => tb.Branch == dataTable.Branch + binderTypeTable.TableName);
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => ((p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly))
												&& p.GetCustomAttributes(typeof(ParentAttribute), false).Length == 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => ((p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly
												&& ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
												|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
												|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
												&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly))
												&& p.GetCustomAttributes(typeof(ParentAttribute), false).Length == 0).ToList();
			}
			#region Фильтрация строк

			List<DataRow> rows = new List<DataRow>();
			List<DataRow> binderRows = new List<DataRow>();

			if (string.IsNullOrEmpty(childAttribute.ForeignKeyTypeColumn))
			{
				//Производится проверка на наличие колонки с внешним ключем в переданной таблице
				if (dataTable.Columns.Contains(dbTable.TableName + childAttribute.ForeignKeyColumn))
				{
					//Колонка с внешним ключем присутствует в таблице
					//В список строк добавляются строки имеющие определенное значение (parentObject.ItemId)
					//в колонке с внешним ключем
					rows.AddRange(dataTable.Rows.Cast<DataRow>()
												.Where(row => (int)row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId));
				}
				else
				{
					//Колонка с внешним ключем отсутствует в таблице    

					//Это может произойти если свойство из данного типа (dataTable.ElementType), 
					//помеченное как ссылка на родителя
					//является для данного типа (dataTable.ElementType) дочерним объектом

					//Нужно найти в данном типе свойство, которое сохраняется в БД
					//в колонке с названием, прописанным во внешнем ключе
					PropertyInfo fkp =
						properties.FirstOrDefault(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													   ((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).ColumnName == childAttribute.ForeignKeyColumn);
					if (fkp != null)
					{
						TableAttribute fkpTable = (TableAttribute)fkp.PropertyType.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
						if (fkpTable != null &&
						   dataTable.Columns.Contains(dbTable.TableName + fkp.Name + fkpTable.PrimaryKey))
						{
							rows.AddRange(dataTable.Rows.Cast<DataRow>()
														.Where(row => (int)row[dbTable.TableName + fkp.Name + fkpTable.PrimaryKey] == parentObject.ItemId));
						}
					}
				}
			}
			else
			{
				binderRows.AddRange(binderTable.Rows.Cast<DataRow>()
													.Where(row => (int)row[binderTypeTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId &&
																  (int)row[binderTypeTable.TableName + childAttribute.ForeignKeyTypeColumn] == parentObject.SmartCoreObjectType.ItemId));

				if (binderRows.Count == 0)
					return null;

				foreach(DataRow r in binderRows)
				{
					int id = (int)DbTypes.GetValue(typeof(int), r[binderTypeTable.TableName + childAttribute.ForeignKeyColumn2]);

					rows.AddRange(dataTable.Rows.Cast<DataRow>()
											.Where(row => (int)row[dbTable.TableName + dbTable.PrimaryKey] == id));

				}
			}

			//rows.AddRange(string.IsNullOrEmpty(childAttribute.ForeignKeyTypeColumn)
			//                  ? dataTable.Rows.Cast<DataRow>()
			//                                  .Where(row => (int) row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId)
			//                  : dataTable.Rows.Cast<DataRow>()
			//                                  .Where(row => (int) row[dbTable.TableName + childAttribute.ForeignKeyColumn] == parentObject.ItemId &&
			//                                                (int) row[dbTable.TableName + childAttribute.ForeignKeyTypeColumn] == parentObject.SmartCoreObjectType.ItemId));

			if (rows.Count == 0) return null;
			#endregion

			PropertyInfo pk = properties.FirstOrDefault(p => p.Name == "ItemId");
			if (pk != null) properties.Remove(pk);

			ICommonCollection items = (ICommonCollection)Activator.CreateInstance(collectionGenericType);
			if (loadChild)
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					//Если свойство, хранящее хнаяения для поля ItemID найдено, то оно заполняется первым
					if (pk != null) pk.SetValue(item, DbTypes.GetValue(typeof(int), rows[i][dbTable.TableName + dbTable.PrimaryKey]), null);

					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						bool isBaseEntityOneToMany = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							if (baseType.Name == typeof(CommonCollection<>).Name
								&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
								&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
								&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseEntityOneToMany = true;
								break;
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChildOneToOne(t.PropertyType, rows[i], dataTable, dataSet, cha, tablePrefix, setForced);
						}
						else if (isBaseEntityOneToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currentBranch = dataTable.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable typeDataTable =
								dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
							value = typeDataTable != null
								? FillChildOneToMany(typeDataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, checkType, setForced)
								: null;
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if (tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}

			#region Выставление родителя

			if (!string.IsNullOrEmpty(childAttribute.ParentProperty))
			{
				//Если в атрибуте взаимоотношения элементов данного типа с
				//другими элементами определено родительское своиство и задан сам родитель
				//то нужно произвести попытку присвоения родителя каждому из элементов

				//Поиск своиства, ссылающегося на родителя
				PropertyInfo parentProperty = type.GetProperty(childAttribute.ParentProperty);

				if (parentProperty != null)
				{
					Type baseType = parentProperty.PropertyType;
					bool isBaseSmartCore = false;
					while (baseType != null)
					{
						if (baseType.Name == typeof(BaseEntityObject).Name ||
							baseType.GetInterface(typeof(IBaseEntityObject).Name) != null)
						{
							//Если тип своиства является наследником BaseSmartCoreObject
							//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
							isBaseSmartCore = true;
							break;
						}
						baseType = baseType.BaseType;
					}
					if (isBaseSmartCore)
					{
						foreach (object item in items)
						{
							parentProperty.SetValue(item, parentObject, null);
						}
					}
				}
			}
			#endregion

			return items;
		}
		#endregion


		#region public static List<T> GetObjectList<T>(DataTable table, bool loadChild = false) where T : BaseEntityObject, new()

		/// <summary>
		/// Преобразует строки таблицы в объекты переданного типа
		/// </summary>
		/// <param name="table"></param>
		/// <param name="loadChild"></param>
		/// <param name="setForced">Флаг - выставлять принулительные поля</param>
		/// <returns></returns>
		public static List<T> GetObjectList<T>(DataTable table, bool loadChild = false, bool setForced = false) where T : BaseEntityObject, new()
		{
			return (List<T>)GetObjectList(typeof(T), table, loadChild, false, setForced);
		}
		#endregion

		#region public static IList GetObjectList(Type type, DataTable table, bool loadChild = false, bool checkType = false)

		/// <summary>
		/// Получает список объектов определенного типа из запроса, при необходимости заполняя дочерние объекты
		/// </summary>
		/// <param name="type">тип объектов</param>
		/// <param name="table">таблица, содержащая результаты запроса</param>
		/// <param name="loadChild">флаг, стоит ли заполнять дочерние элементы</param>
		/// <param name="checkType">флаг, стоит ли проверить тип на иерархию наследования</param>
		/// <param name="setForced">Выставлять принудительные поля</param>
		/// <returns></returns>
		public static IList GetObjectList(Type type, DataTable table, bool loadChild = false,
										  bool checkType = false, bool setForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly) ||
												p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false) ||
												p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}

			Type genericType = typeof (List<>);
			Type genericList = genericType.MakeGenericType(type);
			IList items = (IList)Activator.CreateInstance(genericList);

			if (loadChild)
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					object item = ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();

							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChild(table.Rows[i], t.PropertyType, tablePrefix, setForced);
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if(tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				properties.RemoveAll(p => p.GetCustomAttributes(typeof (ChildAttribute), false).Length > 0);
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					object item = ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			return items;
		}
		#endregion

		#region public static IList GetObjectList(Type type, DataTable table, bool loadChild = false, bool checkType = false)

		/// <summary>
		/// Получает список объектов определенного типа из запроса, при необходимости заполняя дочерние объекты
		/// </summary>
		/// <param name="dataSet">Набор данных, первая таблица которого содержит элементы корневого типа</param>
		/// <param name="loadChild">флаг, стоит ли заполнять дочерние элементы</param>
		/// <param name="checkType">флаг, стоит ли проверить тип на иерархию наследования</param>
		/// <param name="setForced">флаг, стоит ли выставлять принудительные поля</param>
		/// <returns></returns>
		public static IList GetObjectList(DataSet dataSet, bool loadChild = false, bool checkType = false, bool setForced = false)
		{

			if (dataSet.Tables.Count == 0 || !(dataSet.Tables[0] is CasDataTable))
				return null;
			CasDataTable table = ((CasDataTable) dataSet.Tables[0]);
			Type type = table.ElementType;

			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new NullReferenceException("type не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			Type genericType = typeof(List<>);
			Type genericList = genericType.MakeGenericType(type);
			IList items = (IList)Activator.CreateInstance(genericList);

			if (loadChild)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
													&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
													&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
				}
				//Поиск своиства ключевого столбца (для присвоения свойства ItemId)
				//и, если оно есть, удаление его из сохрвняемых свойств 
				PropertyInfo pk = properties.FirstOrDefault(p => p.Name == "ItemId");
				if (pk != null) properties.Remove(pk);

				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					//Если свойство, хранящее хнаяения для поля ItemID найдено, то оно заполняется первым
					if(pk != null) pk.SetValue(item, DbTypes.GetValue(typeof(int), table.Rows[i][dbTable.TableName + dbTable.PrimaryKey]),null);

					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						bool isBaseEntityOneToMany = false;
						bool isBaseEntityManyToMany = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							if (baseType.Name == typeof(CommonCollection<>).Name
								&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
							{
								if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
									&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
								{
									//Если тип своиства является наследником BaseSmartCoreObject
									//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
									isBaseEntityOneToMany = true;
									break;
								}
								if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.ManyToMany)
								{
									//Если тип своиства является наследником BaseSmartCoreObject
									//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
									isBaseEntityManyToMany = true;
									break;
								}
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();

							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChildOneToOne(t.PropertyType, table.Rows[i], table, dataSet, cha, tablePrefix, setForced);
						}
						else if (isBaseEntityOneToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currentBranch = table.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable dataTable =
								dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
							value = dataTable != null
								? FillChildOneToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, checkType, setForced)
								: null;
						}
						else if (isBaseEntityManyToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currentBranch = table.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable dataTable =
								dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
							value = dataTable != null
								? FillChildManyToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, true, setForced)
								: null;
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if (tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					object item = ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.First(p => p.Name == tca.TypeBy);
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			return items;
		}
		#endregion

		#region public static BaseItemsCollection<T> GetObjectCollection<T>(DataTable table) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Получает коллекцию объектов из запроса
		/// </summary>
		/// <param name="table"></param>
		/// <returns></returns>
		public static CommonCollection<T> GetObjectCollection<T>(DataTable table) where T : BaseEntityObject, new()
		{
			CommonCollection<T>collection = new CommonCollection<T>();
			collection.AddRange(GetObjectList<T>(table).ToArray());
			return collection;
		}
		#endregion

		#region public static BaseItemsCollection<T> GetObjectCollection<T>(DataSet dataSet, bool loadChild = false, bool setForced = false) where T : BaseSmartCoreObject, new()
		/// <summary>
		/// Получает коллекцию объектов из запроса
		/// </summary>
		/// <returns></returns>
		public static CommonCollection<T> GetObjectCollection<T>(DataSet dataSet, bool loadChild = false, bool setForced = false)
			where T : BaseEntityObject, new()
		{
			CommonCollection<T> collection = new CommonCollection<T>();
			collection.AddRange((List<T>)GetObjectList(dataSet, loadChild, true, setForced));
			return collection;
		}
		#endregion

		#region public static List<T> GetObjectList<T>(DataTable table, bool loadChild = false) where T : BaseEntityObject, new()

		/// <summary>
		/// Преобразует строки таблицы в объекты переданного типа
		/// </summary>
		/// <param name="dataSet">Набор данных, первая таблица которого содержит элементы корневого типа</param>
		/// <param name="loadChild">флаг, стоит ли заполнять дочерние элементы</param>
		/// <param name="setForced">флаг, стоит ли заполнять поля, помеченные как принудительные</param>
		/// <returns></returns>
		public static List<T> GetObjectList<T>(DataSet dataSet, bool loadChild = false, bool setForced = false) where T : BaseEntityObject, new()
		{
			return (List<T>)GetObjectList(dataSet, loadChild, setForced);
		}
		#endregion

		#region public static TV GetObjectCollection<T, TV>(DataTable table, bool loadChild = false)

		/// <summary>
		/// Преобразует строки переданной таблицы в коллекцию типа TV состоящую из объектов типа T
		/// </summary>
		/// <param name="table">Таблица, строки которой нужно преобразовать в элементы</param>
		/// <param name="loadChild">загружать вложенные объекты (помеченные атрибутом Child)</param>
		/// <returns></returns>
		public static TV GetObjectCollection<T, TV>(DataTable table, bool loadChild = false)
			where T : BaseEntityObject, new()
			where TV : CommonCollection<T>, new()
		{
			TV collection = new TV();
			collection.AddRange(GetObjectList<T>(table, loadChild).ToArray());
			return collection;
		}
		#endregion

		#region public static ICommonCollection GetObjectCollection(Type type, DataTable table, bool loadChild = false, bool checkType = false, bool setForced = false)

		/// <summary>
		/// Получает список объектов определенного типа из запроса, при необходимости заполняя дочерние объекты
		/// </summary>
		/// <param name="type">тип объектов</param>
		/// <param name="table">таблица, содержащая результаты запроса</param>
		/// <param name="loadChild">флаг, стоит ли заполнять дочерние элементы</param>
		/// <param name="checkType">флаг, стоит ли проверить тип на иерархию наследования</param>
		/// <param name="setForced">флаг, стоит ли выставлять принудительные поля</param>
		/// <returns></returns>
		public static ICommonCollection GetObjectCollection(Type type, DataTable table, bool loadChild = false,
															bool checkType = false, bool setForced = false)
		{
			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new ArgumentNullException("type", "не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			//определение своиств, имеющих атрибут "сохраняемое"
			List<PropertyInfo> properties;

			if (setForced)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только считывают информацию из БД
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly) ||
												p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				//исключая своиства, которые только записывают информацию в БД
				//и которые загружаются/сохраняются принудительно
				properties =
				type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
												((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false) ||
												p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
			}
			Type genericType = typeof(CommonCollection<>);
			Type genericList = genericType.MakeGenericType(type);
			ICommonCollection items = (ICommonCollection)Activator.CreateInstance(genericList);

			if (loadChild)
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();

							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChild(table.Rows[i], t.PropertyType, tablePrefix, setForced);
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if (tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			return items;
		}
		#endregion

		#region public static ICommonCollection GetObjectCollection(Type type, DataTable table, bool loadChild = false, bool checkType = false)

		/// <summary>
		/// Получает список объектов определенного типа из запроса, при необходимости заполняя дочерние объекты
		/// </summary>
		/// <param name="dataSet">Набор данных, первая таблица которого содержит элементы корневого типа</param>
		/// <param name="loadChild">флаг, стоит ли заполнять дочерние элементы</param>
		/// <param name="checkType">флаг, стоит ли проверить тип на иерархию наследования</param>
		/// <param name="setForced">флаг, стоит ли выставлять принудительные поля</param>
		/// <returns></returns>
		public static ICommonCollection GetObjectCollection(DataSet dataSet, bool loadChild = false, bool checkType = false, bool setForced = false)
		{

			if (dataSet.Tables.Count == 0 || !(dataSet.Tables[0] is CasDataTable))
				return null;
			CasDataTable table = (CasDataTable)dataSet.Tables[0];
			Type type = table.ElementType;

			#region Проверка типа

			if (checkType)
			{
				if (type == null)
					throw new NullReferenceException("type не должен быть null");

				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				Type baseType = type;
				while (baseType != null)
				{
					if (baseType.Name == typeof(BaseEntityObject).Name) break;
					baseType = baseType.BaseType;
				}

				if (baseType == null)
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentException("type", "не является наследником " + typeof(BaseEntityObject).Name);
				}
			}
			#endregion
			//Определение атрибута сохраняемой таблицы
			TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
			Type genericType = typeof(CommonCollection<>);
			Type genericList = genericType.MakeGenericType(type);
			var items = (ICommonCollection)Activator.CreateInstance(genericList);

			if (loadChild)
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
													&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0
													|| (p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0
													&& ((ChildAttribute)p.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)).ToList();
				}
				//Поиск своиства ключевого столбца (для присвоения свойства ItemId)
				//и, если оно есть, удаление его из сохрвняемых свойств 
				PropertyInfo pk = properties.FirstOrDefault(p => p.Name == "ItemId");
				if (pk != null) properties.Remove(pk);

				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					//Если свойство, хранящее хнаяения для поля ItemID найдено, то оно заполняется первым
					if (pk != null) pk.SetValue(item, DbTypes.GetValue(typeof(int), table.Rows[i][dbTable.TableName + dbTable.PrimaryKey]), null);

					foreach (PropertyInfo t in properties)
					{
						Type baseType = t.PropertyType;
						bool isBaseSmartCore = false;
						bool isBaseEntityOneToMany = false;
						bool isBaseEntityManyToMany = false;
						object value = null;
						while (baseType != null)
						{
							if (baseType.Name == typeof(BaseEntityObject).Name &&
								(t.PropertyType.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault() != null ||
								 t.PropertyType.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault() != null) &&
								t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault() != null)
							{
								//Если тип своиства является наследником BaseSmartCoreObject
								//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
								isBaseSmartCore = true;
								break;
							}
							if (baseType.Name == typeof(CommonCollection<>).Name
								&& t.GetCustomAttributes(typeof(TableColumnAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(SubQueryAttribute), false).Length == 0
								&& t.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
							{
								if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany
									&& ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).ColumnAccessType != ColumnAccessType.WriteOnly)
								{
									//Если тип своиства является наследником BaseSmartCoreObject
									//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
									isBaseEntityOneToMany = true;
									break;
								}
								if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.ManyToMany)
								{
									//Если тип своиства является наследником BaseSmartCoreObject
									//и имеет атрибут TableAttribute, то простваляется флаг isBaseSmartCore
									isBaseEntityManyToMany = true;
									break;
								}
							}
							baseType = baseType.BaseType;
						}
						if (isBaseSmartCore)
						{
							//Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();

							string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

							value = FillChildOneToOne(t.PropertyType, table.Rows[i], table, dataSet, cha, tablePrefix, setForced);
						}
						else if (isBaseEntityOneToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currentBranch = table.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable dataTable =
								dataSet.Tables.OfType<CasDataTable>().FirstOrDefault(tb => tb.Branch == currentBranch);
							value = dataTable != null
								? FillChildOneToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, checkType, setForced)
								: null;
						}
						else if (isBaseEntityManyToMany)
						{
							//Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
							//полей этого типа
							//Поиск атрибута определяющего отношения объектов
							ChildAttribute cha =
								(ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
							//Определение текущей ветки запроса
							string currentBranch = table.Branch + t.Name;
							//Поиск таблицы, содержащие данные нужной ветки запроса
							CasDataTable dataTable = dataSet.Tables
											  .OfType<CasDataTable>()
											  .FirstOrDefault(tb => tb.Branch == currentBranch);
							value = dataTable != null
								? FillChildManyToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, true, setForced)
								: null;
						}
						else
						{
							TableColumnAttribute tca =
								(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
							if (tca != null)
								if (!(string.IsNullOrEmpty(tca.TypeBy)))
								{
									PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
									if (typeProperty != null)
									{
										SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
										if (coreType != null && coreType.ObjectType != null)
											value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
										else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									}
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

							SubQueryAttribute cca =
								(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
							if (cca != null)
								value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						}
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			else
			{
				//определение своиств, имеющих атрибут "сохраняемое"
				List<PropertyInfo> properties;

				if (setForced)
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только считывают информацию из БД
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				else
				{
					//определение своиств, имеющих атрибут "сохраняемое"
					//исключая своиства, которые только записывают информацию в БД
					//и которые загружаются/сохраняются принудительно
					properties =
					type.GetProperties().Where(p => (p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0 &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).AccessType != ColumnAccessType.WriteOnly &&
													((TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).First()).Forced == false &&
													 p.GetCustomAttributes(typeof(ChildAttribute), false).Length == 0)
													|| p.GetCustomAttributes(typeof(SubQueryAttribute), false).Length != 0).ToList();
				}
				ConstructorInfo ci = type.GetConstructor(new Type[0]);
				for (int i = 0; i < table.Rows.Count; i++)
				{
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);
					foreach (PropertyInfo t in properties)
					{
						object value = null;
						TableColumnAttribute tca =
							(TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
						if (tca != null)
							if (!(string.IsNullOrEmpty(tca.TypeBy)))
							{
								PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
								if (typeProperty != null)
								{
									SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
									if (coreType != null && coreType.ObjectType != null)
										value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
									else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
								}
								else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
							}
							else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);

						SubQueryAttribute cca =
							(SubQueryAttribute)t.GetCustomAttributes(typeof(SubQueryAttribute), false).FirstOrDefault();
						if (cca != null)
							value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + cca.ColumnName]);
						t.SetValue(item, value, null);
					}
					items.Add(item);
				}
			}
			return items;
		}
		#endregion
	}
}
