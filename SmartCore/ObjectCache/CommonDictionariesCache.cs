using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.ObjectCache
{
    public class CommonDictionariesCache : ICommonDictionariesCache
    {
        private readonly Dictionary<Type, IDictionaryCollection> _dictionaries;

        public CommonDictionariesCache()
        {
            _dictionaries = new Dictionary<Type, IDictionaryCollection>();
        }

        public IDictionaryCollection GetDictionary<T>() where T : IDictionaryItem
        {
            var type = typeof (T);
            return _dictionaries.ContainsKey(typeof(T)) ? _dictionaries[type] : null;
        }

        public IDictionaryCollection GetDictionary(Type type)
        {
            return _dictionaries.ContainsKey(type) ? _dictionaries[type] : null;
        }

        public void Add(Type t, IDictionaryCollection dictionary)
        {
            _dictionaries.Add(t, dictionary);
        }

        public void Clear()
        {
            if (_dictionaries == null) 
                return;
            
            foreach (KeyValuePair<Type, IDictionaryCollection> pair in _dictionaries)
            {
                if (pair.Value != null) pair.Value.Clear();
            }
            _dictionaries.Clear();
        }
    }
}
