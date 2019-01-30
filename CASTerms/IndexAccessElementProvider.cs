using System;
using System.Collections.Generic;

namespace CASTerms
{
    /// <summary>
    /// Sets interface to access to terms of project
    /// </summary>
    public abstract class IndexAccessElementProvider
    {
        
        #region Indexers

        #region public abstract CoreType this[int index]
        /// <summary>
        /// Returns an item from terms dictionary by it's code
        /// </summary>
        /// <param name="keyCode">Key code of requested item </param>
        /// <returns></returns>
        public abstract object this[int keyCode] { get; }
        #endregion

        #region public abstract CoreType this[string key]
        /// <summary>
        /// Returns an item from terms dictionary by specified key
        /// </summary>
        /// <param name="key">Key of requested term</param>
        /// <returns></returns>
        public abstract object this[string key] { get; }
        #endregion

        #endregion

        #region protected class Hash
        /// <summary>
        /// Class for information keeping with search by string key
        /// </summary>
        protected class Hash : Dictionary<string, object>
        {
            #region Fields
            private List<string> keyList = new List<string>();
            #endregion

            #region public void Add(string key, object value)
            /// <summary>
            /// Adds the specified key and value to the hash
            /// </summary>
            /// <param name="key">The key of element to add</param>
            /// <param name="value">The value of element to add</param>
            public new void Add(string key, object value)
            {
                if (ContainsKey(key.ToLower())) throw new ArgumentException("Same key already exists", "key");
                keyList.Add(key);
                base.Add(key.ToLower(), value);
            }
            #endregion

            #region public bool Remove(string key)
            /// <summary>
            /// Removes the value with specified key from hash
            /// </summary>
            /// <param name="key">The key of elemnt to remove</param>
            /// <returns></returns>
            public new bool Remove(string key)
            {
                keyList.Remove(key);
                return base.Remove(key.ToLower());
            }
            #endregion

            #region public object this[string key]
            /// <summary>
            /// gets or sets the value associated with specified key
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public new object this[string key]
            {
                get { return base[key.ToLower()]; }
                set { base[key.ToLower()] = value; }
            }
            #endregion

            #region public object this[int key]

            public object this[int key]
            {
                get { return base[keyList[key]]; }
                set { base[keyList[key]] = value; }
            }

            #endregion

        }
        #endregion

    }
}