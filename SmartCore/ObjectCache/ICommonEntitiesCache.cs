using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.ObjectCache
{
    public interface ICommonEntitiesCache
    {
        ICommonCollection GetObjectCollection();
        ICommonCollection<T> GetObjectCollection<T>() where T : IBaseEntityObject;
    }


    public interface ICommonDictionariesCache
    {
        IDictionaryCollection GetDictionary<T>() where T : IDictionaryItem;
        IDictionaryCollection GetDictionary(Type type);
        void Clear();
        void Add(Type t, IDictionaryCollection dictionary);
    }
}
