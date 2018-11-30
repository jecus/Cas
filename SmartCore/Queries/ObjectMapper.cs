using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Management;

namespace SmartCore.Queries
{
    public class ObjectMapper
    {
        #region private static object GetValueByType(BaseEntityObject targetObject, PropertyInfo targetProperty,IEnumerable<PropertyInfo> targetObjectProperties,TableColumnAttribute tca, TableAttribute dbTable,DataRow row)
        private static object GetValueByType(BaseEntityObject targetObject,
                                      PropertyInfo targetProperty,
                                      IEnumerable<PropertyInfo> targetObjectProperties,
                                      TableColumnAttribute tca,
                                      TableAttribute dbTable,
                                      DataRow row)
        {
            if (targetObject == null || tca == null || targetObjectProperties == null || !targetObjectProperties.Any())
                return null;

            string[] path = tca.TypeBy.Split('.');
            if (path.Length == 0)
                return null;

            PropertyInfo typeProperty = null;
            IEnumerable<PropertyInfo> localProps = targetObjectProperties;
            object localValue = targetObject;
            object resultValue;

            for (int i = 0; i < path.Length; i++)
            {
                if (!string.IsNullOrEmpty(path[i]))
                    typeProperty = localProps.Where(p => p.Name == path[i]).First();

                if (i < path.Length - 1 && typeProperty != null && localValue != null)
                {
                    localValue = typeProperty.GetValue(localValue, null);
                    localProps = typeProperty.PropertyType.GetProperties();
                }
            }

            if (typeProperty != null)
            {
                if (localValue != null && localValue is Type)
                    resultValue = DbTypes.GetValue((Type)localValue, row[dbTable.TableName + tca.ColumnName]);
                else resultValue = DbTypes.GetValue(targetProperty.PropertyType, row[dbTable.TableName + tca.ColumnName]);
            }
            else resultValue = DbTypes.GetValue(targetProperty.PropertyType, row[dbTable.TableName + tca.ColumnName]);

            return resultValue;
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
            if (items == null || items.OfType<BaseEntityObject>().Count() == 0 || dataSet == null) return;

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
                        if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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

                foreach (BaseEntityObject item in objects)
                {
                    DataRow row = dataSet.Tables[0].Rows
                        .Cast<DataRow>()
                        .FirstOrDefault(r => (int)r[dbTable.TableName + dbTable.PrimaryKey] == item.ItemId);
                    if (row == null) continue;

                    object value = null;
                    if (isBaseSmartCore)
                    {
                        //Если тип своиства является BaseSmartCoreObject, вызывается функция заполнения
                        //полей этого типа
                        CasDataTable table = dataSet.Tables[0] as CasDataTable;
                        string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");
                        value = table != null
                            ? FillChildOneToOne(t.PropertyType, row, table, dataSet, tablePrefix, setForced)
                            : null;
                    }
                    else if (isBaseEntityOneToMany)
                    {
                        //Если тип своиства является коллекция объектов BaseSmartCoreObject, вызывается функция заполнения
                        //полей этого типа
                        //Поиск атрибута определяющего отношения объектов
                        CasDataTable table = dataSet.Tables[0] as CasDataTable;
                        ChildAttribute cha =
                            (ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
                        //Определение текущей ветки запроса
                        string currentBranch = table != null ? table.Branch + t.Name : t.Name;
                        //Поиск таблицы, содержащие данные нужной ветки запроса
                        CasDataTable dataTable =
                            dataSet.Tables.OfType<CasDataTable>()
                                          .Where(tb => tb.Branch == currentBranch)
                                          .FirstOrDefault();
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
                        ChildAttribute cha =
                            (ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).FirstOrDefault();
                        //Определение текущей ветки запроса
                        string currentBranch = table != null ? table.Branch + t.Name : t.Name;
                        //Поиск таблицы, содержащие данные нужной ветки запроса
                        CasDataTable dataTable =
                            dataSet.Tables.OfType<CasDataTable>()
                                          .Where(tb => tb.Branch == currentBranch)
                                          .FirstOrDefault();
                        value = dataTable != null
                            ? FillChildManyToMany(dataTable, t.PropertyType, dataSet, cha, item, cha.LoadChild, true, setForced)
                            : null;
                    }
                    else
                    {
                        if (tca != null)
                            if (!(string.IsNullOrEmpty(tca.TypeBy)))
                            {
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);

                                value = GetValueByType(item, t, properties, tca, dbTable, row);
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
                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                    //if (typeProperty != null)
                    //{
                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                    //    if (coreType != null && coreType.ObjectType != null)
                    //        value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
                    //    else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
                    //}
                    //else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);

                    value = GetValueByType(item, t, properties, tca, dbTable, row);
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
                if (!(string.IsNullOrEmpty(tca.TypeBy)))
                {
                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                    //if (typeProperty != null)
                    //{
                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                    //    if (coreType != null && coreType.ObjectType != null)
                    //        value = DbTypes.GetValue(coreType.ObjectType, row[dbTable.TableName + tca.ColumnName]);
                    //    else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);
                    //}
                    //else value = DbTypes.GetValue(t.PropertyType, row[dbTable.TableName + tca.ColumnName]);

                    value = GetValueByType(item, t, properties, tca, dbTable, row);
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
        /// <param name="setForced">Выставлять принудительные поля</param>
        private static object FillChild(DataRow row, Type type, string tablePrefix = "", bool setForced = false)
        {
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
                            //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                            //if (typeProperty != null)
                            //{
                            //    SmartCoreType coreType = typeProperty.GetValue(ob, null) as SmartCoreType;
                            //    if (coreType != null && coreType.ObjectType != null)
                            //        value = DbTypes.GetValue(coreType.ObjectType, row[tablePrefix + tca.ColumnName]);
                            //    else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
                            //}
                            //else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);

                            value = GetValueByType(ob as BaseEntityObject, t, properties, tca, dbTable, row);
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
        /// <param name="tablePrefix"></param>
        /// <param name="setForced">Выставлять принудительные поля</param>
        private static object FillChildOneToOne(Type elementType, DataRow row, CasDataTable dataTable, DataSet dataSet,
                                                string tablePrefix = "", bool setForced = false)
        {
            Type type = elementType;
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
            BaseEntityObject item = (BaseEntityObject)type.GetConstructor(new Type[0]).Invoke(null);
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
                                && ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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
                        dataSet.Tables.OfType<CasDataTable>()
                                      .Where(tb => tb.Branch == currentBranch)
                                      .FirstOrDefault();
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
                            //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                            //if (typeProperty != null)
                            //{
                            //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                            //    if (coreType != null && coreType.ObjectType != null)
                            //        value = DbTypes.GetValue(coreType.ObjectType, row[tablePrefix + tca.ColumnName]);
                            //    else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
                            //}
                            //else value = DbTypes.GetValue(t.PropertyType, row[tablePrefix + tca.ColumnName]);
                            value = GetValueByType(item, t, properties, tca, dbTable, row);
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
                                                || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
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
                                                || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
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

            PropertyInfo pk = properties.Where(p => p.Name == "ItemId").FirstOrDefault();
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
                                && ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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

                            string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

                            value = FillChildOneToOne(t.PropertyType, rows[i], dataTable, dataSet, tablePrefix, setForced);
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currebtBranch)
                                              .FirstOrDefault();
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
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item, t, properties, tca, dbTable, rows[i]);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                value = GetValueByType(item, t, properties, tca, dbTable, rows[i]);
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

        #region private static ICommonCollection FillChildManyToMany(CasDataTable dataTable, Type collectionGenericType, DataSet dataSet, ChildAttribute childAttribute, BaseEntityObject parentObject = null,bool loadChild = false, bool checkType = false)

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
                             .Where(tb => tb.Branch == dataTable.Branch + binderTypeTable.TableName)
                             .FirstOrDefault();
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
                                                || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
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
                                                || p.GetCustomAttributes(typeof(ChildAttribute), false).Length != 0)
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

                foreach (DataRow r in binderRows)
                {
                    int id = (int)r[binderTypeTable.TableName + childAttribute.ForeignKeyColumn2];
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

            PropertyInfo pk = properties.Where(p => p.Name == "ItemId").FirstOrDefault();
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
                                && ((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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

                            string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

                            value = FillChildOneToOne(t.PropertyType, rows[i], dataTable, dataSet, tablePrefix, setForced);
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currentBranch)
                                              .FirstOrDefault();
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
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item, t, properties, tca, dbTable, rows[i]);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, rows[i][dbTable.TableName + tca.ColumnName]);

                                value = GetValueByType(item, t, properties, tca, dbTable, rows[i]);
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

            Type genericType = typeof(List<>);
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
                            if (tca != null)
                                if (!(string.IsNullOrEmpty(tca.TypeBy)))
                                {
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item as BaseEntityObject, t, properties, tca, dbTable, table.Rows[i]);
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
                properties.RemoveAll(p => p.GetCustomAttributes(typeof(ChildAttribute), false).Length > 0);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                value = GetValueByType(item as BaseEntityObject, t, properties, tca, dbTable, table.Rows[i]);
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
            CasDataTable table = ((CasDataTable)dataSet.Tables[0]);
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
                //Поиск своиства ключевого столбца (для присвоения свойства ItemId)
                //и, если оно есть, удаление его из сохрвняемых свойств 
                PropertyInfo pk = properties.Where(p => p.Name == "ItemId").FirstOrDefault();
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
                                if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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

                            string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

                            value = FillChildOneToOne(t.PropertyType, table.Rows[i], table, dataSet, tablePrefix, setForced);
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currentBranch)
                                              .FirstOrDefault();
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currentBranch)
                                              .FirstOrDefault();
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
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item, t, properties, tca, dbTable, table.Rows[i]);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                value = GetValueByType(item as BaseEntityObject, t, properties, tca, dbTable, table.Rows[i]);
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
            CommonCollection<T> collection = new CommonCollection<T>();
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
            where TV : List<T>, new()
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
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item, t, properties, tca, dbTable, table.Rows[i]);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                value = GetValueByType(item, t, properties, tca, dbTable, table.Rows[i]);
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
            CasDataTable table = ((CasDataTable)dataSet.Tables[0]);
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
            ICommonCollection items = (ICommonCollection)Activator.CreateInstance(genericList);

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
                //Поиск своиства ключевого столбца (для присвоения свойства ItemId)
                //и, если оно есть, удаление его из сохрвняемых свойств 
                PropertyInfo pk = properties.Where(p => p.Name == "ItemId").FirstOrDefault();
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
                                if (((ChildAttribute)t.GetCustomAttributes(typeof(ChildAttribute), false).First()).RelationType == RelationType.OneToMany)
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

                            string tablePrefix = dbTable.TableName + (tca != null ? tca.ColumnName : cca != null ? cca.ColumnName : "");

                            value = FillChildOneToOne(t.PropertyType, table.Rows[i], table, dataSet, tablePrefix, setForced);
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currentBranch)
                                              .FirstOrDefault();
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
                                dataSet.Tables.OfType<CasDataTable>()
                                              .Where(tb => tb.Branch == currentBranch)
                                              .FirstOrDefault();
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
                                    //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                    //if (typeProperty != null)
                                    //{
                                    //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                    //    if (coreType != null && coreType.ObjectType != null)
                                    //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    //}
                                    //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                    value = GetValueByType(item, t, properties, tca, dbTable, table.Rows[i]);
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
                                //PropertyInfo typeProperty = properties.Where(p => p.Name == tca.TypeBy).First();
                                //if (typeProperty != null)
                                //{
                                //    SmartCoreType coreType = typeProperty.GetValue(item, null) as SmartCoreType;
                                //    if (coreType != null && coreType.ObjectType != null)
                                //        value = DbTypes.GetValue(coreType.ObjectType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //    else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                //}
                                //else value = DbTypes.GetValue(t.PropertyType, table.Rows[i][dbTable.TableName + tca.ColumnName]);
                                value = GetValueByType(item, t, properties, tca, dbTable, table.Rows[i]);
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

