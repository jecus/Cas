using System;
using System.Reflection;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.General.Attributes
{
    #region public class DictionaryCollectionAttribute : Attribute
    /// <summary>
    /// Назначает классу коллекцию для работы с экземплярами данного класса. 
    /// Коллекция должна реализовывать интерфейс IDictionaryCollection и наследоваться от класса BaseItemsCollection
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DictionaryCollectionAttribute : Attribute
    {
        private readonly Type _collectionType;

        public DictionaryCollectionAttribute(Type collectionType)
        {
            _collectionType = collectionType;
        }

        public IDictionaryCollection GetInstance()
        {
            if (_collectionType == null)
                throw new Exception("_collectionType: не должен быть null");

            Type @interface = _collectionType.GetInterface(typeof (IDictionaryCollection).Name);
            if(@interface == null)
                throw new Exception("_collectionType: " + _collectionType + " не реализует интерфейс IDictionaryCollection");

            //_collectionType.IsSubclassOf(typeof(CommonCollection<>)) почему то возвращает false

            Type t = _collectionType;
            bool find = false;
            while (t != null)
            {
                if(t.Name == typeof(CommonCollection<>).Name)
                {
                    find = true;
                    break;
                }
                t = t.BaseType;
            }
            if (find==false)
                throw new Exception("_collectionType: " + _collectionType + " не является наследником BaseItemsCollection<>");

            ConstructorInfo ci = _collectionType.GetConstructor(new Type[0]);
            if (ci == null)
                throw new Exception("Type: " + _collectionType + " не имеет открытого конструктора по умолчанию");
            
            IDictionaryCollection collection = (IDictionaryCollection)ci.Invoke(null);
            return collection;
        }
    }
    #endregion
}
