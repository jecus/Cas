using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
    public class DataGridViewGroup
    {
        private string _header;

        public string Header
        {
            get { return _header; }
        }

        private bool _fullRow;

        public bool FullRow
        {
            get { return _fullRow; }
        }

        private string _key;

        public string Key
        {
            get { return _key; }
        }

        public DataGridViewGroup(string key, string header)
        {
            _header = header;
            _key = key;
        }
    }

    /// <summary>
    /// Описывает коллекцию строк древовидного DataGridView-а
    /// </summary>
    public class DataGridViewGroupCollection : IList<DataGridViewGroup>, System.Collections.IList
    {
        #region Fields

        private List<DataGridViewGroup> _list;
        private DataGridView _owner;

        #endregion

        #region Constructors
        internal DataGridViewGroupCollection(DataGridView owner)
        {
            _owner = owner;
            _list = new List<DataGridViewGroup>();
        }
        #endregion

        #region Public Members
        public void Add(DataGridViewGroup item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            if(_list.Any(i => i.Key == item.Key && i.Header == item.Header))
                return;
            
            _list.Add(item);
        }

        #region public DataGridViewGroup Add(string key, string headerText)

        /// <summary>
        /// Добавляет TreeDataGridViewRow в коллекцию
        /// </summary>
        /// <param name="key"> текст первой ячейки строки</param>
        /// <param name="headerText"></param>
        /// <returns>Новая строка</returns>
        public DataGridViewGroup Add(string key, string headerText)
        {
            DataGridViewGroup node = _list.FirstOrDefault(i => i.Key == key);
            if (node!= null)
                return node;
            node = new DataGridViewGroup(headerText, key);
            Add(node);
            return node;
        }
        #endregion

        #region public void Insert(int index, DataGridViewGroup item)
        public void Insert(int index, DataGridViewGroup item)
        {
            _list.Insert(index, item);
        }
        #endregion

        #region public bool Remove(DataGridViewGroup item)

        public bool Remove(DataGridViewGroup item)
        {
            // The parent is notified first then the row is removed from the child collection.
            return _list.Remove(item);
        }
        #endregion
        public void CopyTo(DataGridViewGroup[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        #region public void RemoveAt(int index)
        public void RemoveAt(int index)
        {
            DataGridViewGroup row = _list[index];

            // The parent is notified first then the row is removed from the child collection.
            _list.RemoveAt(index);
        }

        DataGridViewGroup IList<DataGridViewGroup>.this[int index]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        #endregion

        #region public void Clear()
        public void Clear()
        {
            // The parent is notified first then the row is removed from the child collection.
            _list.Clear();
        }
        #endregion

        #region public int IndexOf(DataGridViewGroup item)
        public int IndexOf(DataGridViewGroup item)
        {
            return _list.IndexOf(item);
        }
        #endregion

        #region public DataGridViewGroup this[string key]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="Exception"></exception>
        public DataGridViewGroup this[string key]
        {
            get
            {
                return _list.FirstOrDefault(i => i.Key == key) ?? (Add("Default", "Default"));
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }
        #endregion

        #region public bool Contains(DataGridViewGroup item)
        public bool Contains(DataGridViewGroup item)
        {
            return _list.Contains(item);
        }
        #endregion

        #region public int Count
        public int Count
        {
            get { return _list.Count; }
        }

        public bool IsReadOnly { get; private set; }

        #endregion

        #endregion

        #region IList Interface
        void System.Collections.IList.Remove(object value)
        {
            Remove(value as DataGridViewGroup);
        }


        int System.Collections.IList.Add(object value)
        {
            DataGridViewGroup item = value as DataGridViewGroup;
            if (item == null)
                return -1;
            
            DataGridViewGroup group = _list.FirstOrDefault(i => i.Key == item.Key);
            if (group != null)
                return _list.IndexOf(group);
            
            Add(item);
            return _list.IndexOf(item);
        }

        void System.Collections.IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }


        void System.Collections.IList.Clear()
        {
            Clear();
        }

        bool System.Collections.IList.IsReadOnly
        {
            get { return false; }
        }

        bool System.Collections.IList.IsFixedSize
        {
            get { return false; }
        }

        int System.Collections.IList.IndexOf(object item)
        {
            return IndexOf(item as DataGridViewGroup);
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            Insert(index, value as DataGridViewGroup);
        }
        int System.Collections.ICollection.Count
        {
            get { return Count; }
        }
        bool System.Collections.IList.Contains(object value)
        {
            return Contains(value as DataGridViewGroup);
        }
        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        object System.Collections.IList.this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }



        #region IEnumerable<ExpandableRow> Members

        public IEnumerator<DataGridViewGroup> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        #endregion


        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        #endregion

        #region ICollection Members

        bool System.Collections.ICollection.IsSynchronized
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        object System.Collections.ICollection.SyncRoot
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }

}
