//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
	/// <summary>
	/// Описывает коллекцию строк древовидного DataGridView-а
	/// </summary>
	public class TreeDataGridViewRowCollection : IList<TreeDataGridViewRow>, System.Collections.IList
    {
        #region Fields

        private List<TreeDataGridViewRow> _list;
	    private TreeDataGridViewRow _owner;

        #endregion

        #region Constructors
        internal TreeDataGridViewRowCollection(TreeDataGridViewRow owner)
		{
			_owner = owner;
			_list = new List<TreeDataGridViewRow>();
		}
        #endregion

        #region Public Members

        #region public void Add(TreeDataGridViewRow item)
        public void Add(TreeDataGridViewRow item)
		{
			// The row needs to exist in the child collection before the parent is notified.
            if (_owner.Grid.ShowGroups && !item.IsGroupRow)
            {
                AddToGroup(item);
            }
            else
            {
                AddAsRow(item);    
            }
		}
        #endregion

        #region public TreeDataGridViewRow Add(string text)
        /// <summary>
        /// Добавляет TreeDataGridViewRow в коллекцию
        /// </summary>
        /// <param name="text"> текст первой ячейки строки</param>
        /// <returns>Новая строка</returns>
        public TreeDataGridViewRow Add(string text)
        {
            TreeDataGridViewRow node = new TreeDataGridViewRow();
            Add(node);

            node.Cells[0].Value = text;
            return node;
        }
        #endregion

        #region public TreeDataGridViewRow Add(params object[] values)
        /// <summary>
        /// Добавляет строку в коллекцию
        /// </summary>
        /// <param name="values">Значения, которыми будут заполнены ячейки строки</param>
        /// <returns>Новая строка</returns>
        /// <exception cref="ArgumentOutOfRangeException">Возбуждает исключение если кол-во параметров и ячеек несовпадает</exception>
        public TreeDataGridViewRow Add(params object[] values)
        {
            TreeDataGridViewRow node = new TreeDataGridViewRow();
            Add(node);

            int cell = 0;

            if (values.Length > node.Cells.Count )
                throw new ArgumentOutOfRangeException("values");

            foreach (object o in values)
            {
                node.Cells[cell].Value = o;
                cell++;
            }
            return node;
        }
        #endregion

        #region public TreeDataGridViewRow Add(int count)
        /// <summary>
        /// Добавляет строку в коллекцию
        /// </summary>
        /// <param name="count">Значения, которыми будут заполнены ячейки строки</param>
        /// <returns>Новая строка</returns>
        /// <exception cref="ArgumentOutOfRangeException">Возбуждает исключение если кол-во параметров и ячеек несовпадает</exception>
        public int Add(int count)
        {
            if (count < 1)
                return -1;
            for (int i = 0; i < count; i++)
            {
                TreeDataGridViewRow node = new TreeDataGridViewRow();
                Add(node);    
            }
            return Count - 1;
        }
        #endregion

        #region public TreeDataGridViewRow Add()
        /// <summary>
        /// Добавляет строку в коллекцию
        /// </summary>
        /// <returns>Новая строка</returns>
        /// <exception cref="ArgumentOutOfRangeException">Возбуждает исключение если кол-во параметров и ячеек несовпадает</exception>
        public TreeDataGridViewRow Add()
        {
            TreeDataGridViewRow node = new TreeDataGridViewRow();
            Add(node);
            return node;
        }
        #endregion

        #region public void AddRange(TreeDataGridViewRow[] rows)
        /// <summary>
        /// Добавляет строку в коллекцию
        /// </summary>
        /// <param name="rows">Значения, которыми будут заполнены ячейки строки</param>
        /// <returns>Новая строка</returns>
        /// <exception cref="ArgumentOutOfRangeException">Возбуждает исключение если кол-во параметров и ячеек несовпадает</exception>
        public void AddRange(TreeDataGridViewRow[] rows)
        {
            if (rows == null || rows.Length == 0)
                return;
            foreach (TreeDataGridViewRow t in rows)
            {
                Add(t);
            }
        }

	    #endregion

        #region private void AddToGroup(TreeDataGridViewRow item)
        private void AddToGroup(TreeDataGridViewRow item)
        {
            if (item.Group == null)
            {
                item.Group = _owner.Grid.Groups["Default"];
            }

            bool hadChildren;
            TreeDataGridViewRow r = _owner.Grid.Nodes.FirstOrDefault(i => i.Tag == item.Group);
            if (r == null)
            {
                //если строки, которая представляет нужную группу нет
                //то производится добавление строки для представленияя группы

                r = new TreeDataGridViewRow(_owner.Grid) { IsGroupRow = true, Tag = item.Group };
                r.Grid = _owner.Grid;

                hadChildren = _owner.HasChildren;
                r.Owner = this;

                _list.Add(r);

                _owner.AddChildNode(r);

                // if the owner didn't have children but now does (asserted) and it is sited update it
                if (!hadChildren && _owner.IsSited)
                {
                    _owner.Grid.InvalidateRow(_owner.RowIndex);
                }
            }

            item.Grid = _owner.Grid;

            hadChildren = r.HasChildren;
            item.Owner = r.Nodes;

            r.Nodes.AddAsRow(item);

            r.AddChildNode(item);
        }
        #endregion

        #region private void AddAsRow(TreeDataGridViewRow item)
        private void AddAsRow(TreeDataGridViewRow item)
        {
            item.Grid = _owner.Grid;

            bool hadChildren = _owner.HasChildren;
            item.Owner = this;

            _list.Add(item);

            _owner.AddChildNode(item);

            // if the owner didn't have children but now does (asserted) and it is sited update it
            if (!hadChildren && _owner.IsSited)
            {
                _owner.Grid.InvalidateRow(_owner.RowIndex);
            }
        }
        #endregion

        #region public void Insert(int index, TreeDataGridViewRow item)
        public void Insert(int index, TreeDataGridViewRow item)
        {
            // The row needs to exist in the child collection before the parent is notified.
            item.Grid = _owner.Grid;
            item.Owner = this;

            _list.Insert(index, item);

            _owner.InsertChildNode(index, item);
        }
        #endregion

        #region public bool Remove(TreeDataGridViewRow item)
        public bool Remove(TreeDataGridViewRow item)
		{
			// The parent is notified first then the row is removed from the child collection.
			_owner.RemoveChildNode(item);
			item.Grid = null;
			return _list.Remove(item);
		}
        #endregion

        #region public void RemoveAt(int index)
        public void RemoveAt(int index)
		{
			TreeDataGridViewRow row = _list[index];

			// The parent is notified first then the row is removed from the child collection.
			_owner.RemoveChildNode(row);
			row.Grid = null;
            row.Owner = null;
            row.Index = -1;
			_list.RemoveAt(index);
		}
        #endregion

        #region public void Clear()
        public void Clear()
		{
			// The parent is notified first then the row is removed from the child collection.
			_owner.ClearNodes();
			_list.Clear();
		}
        #endregion

        #region public int IndexOf(TreeDataGridViewRow item)
        public int IndexOf(TreeDataGridViewRow item)
        {
            return _list.IndexOf(item);
        }
        #endregion

        #region public TreeDataGridViewRow this[int index]
        public TreeDataGridViewRow this[int index]
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
        #endregion

        #region public bool Contains(TreeDataGridViewRow item)
        public bool Contains(TreeDataGridViewRow item)
		{
			return _list.Contains(item);
		}
        #endregion

        #region public void CopyTo(TreeDataGridViewRow[] array, int arrayIndex)
        public void CopyTo(TreeDataGridViewRow[] array, int arrayIndex)
		{
			throw new Exception("The method or operation is not implemented.");
		}
        #endregion

        #region public int Count
        public int Count
		{
			get{ return _list.Count; }
		}
        #endregion

        #region public bool IsReadOnly
        public bool IsReadOnly
		{
			get { return false; }
		}
        #endregion

        #endregion

        #region IList Interface
        void System.Collections.IList.Remove(object value)
        {
            Remove(value as TreeDataGridViewRow);
        }


        int System.Collections.IList.Add(object value)
        {
            TreeDataGridViewRow item = value as TreeDataGridViewRow;
            Add(item);
            return item.Index;
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
			get { return IsReadOnly;}
		}

		bool System.Collections.IList.IsFixedSize
		{
			get { return false; }
		}

        int System.Collections.IList.IndexOf(object item)
        {
            return IndexOf(item as TreeDataGridViewRow);
        }

        void System.Collections.IList.Insert(int index, object value)
        {
            Insert(index, value as TreeDataGridViewRow);
        }
        int System.Collections.ICollection.Count
        {
            get { return Count; }
        }
        bool System.Collections.IList.Contains(object value)
        {
            return Contains(value as TreeDataGridViewRow);
        }
        void System.Collections.ICollection.CopyTo(Array array, int index)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        object System.Collections.IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }



		#region IEnumerable<ExpandableRow> Members

		public IEnumerator<TreeDataGridViewRow> GetEnumerator()
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
