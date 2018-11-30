using System;
using System.Linq;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Представляет стастический древовидный словарь. 
    /// <br/>Каждый статический словарь должен содержать открытое статичесоке своиство Items
    /// <br/>Каждый статический словарь должен содержать открытое статичесоке своиство Unknown c id равным -1
    /// <br/>Каждый статический древовидный словарь должен содержать открытое статичесоке своиство Roots для обозначения корневых элементов
    /// </summary>

    [Serializable]
    public abstract class StaticTreeDictionary : StaticDictionary, IDictionaryTreeItem
    {
        protected StaticTreeDictionary _parent;
        protected StaticTreeDictionary _prev;
        protected StaticTreeDictionary _next;
        protected IDictionaryCollection _children;
        /*
        * Свойства
        */
        /// <summary>
        /// Родительский узел словаря
        /// </summary>
        IDictionaryTreeItem IDictionaryTreeItem.Parent { get { return _parent; } }

        /// <summary>
        /// Предыдущий элемент на уровне
        /// </summary>
        IDictionaryTreeItem IDictionaryTreeItem.Prev { get { return _prev; } }

        /// <summary>
        /// Следующий элемент на уровне
        /// </summary>
        IDictionaryTreeItem IDictionaryTreeItem.Next { get { return _next; } }

        #region public StaticTreeDictionary Parent
        /// <summary>
        /// Родительский узел словаря
        /// </summary>
        public StaticTreeDictionary Parent
        {
            get { return _parent; } 
            protected set { _parent = value; }
        }
        #endregion

        #region public StaticTreeDictionary Prev
        /// <summary>
        /// Предыдущий элемент на уровне
        /// </summary>
        public StaticTreeDictionary Prev
        {
            get { return _prev; }
            protected set { _prev = value; }
        }
        #endregion

        #region public StaticTreeDictionary Next
        /// <summary>
        /// Следующий элемент на уровне
        /// </summary>
        public StaticTreeDictionary Next
        {
            get { return _next; }
            protected set { _next = value; }
        }
        #endregion

        #region public IDictionaryCollection Children
        /// <summary>
        /// Дочерние элементы словаря
        /// </summary>
        public IDictionaryCollection Children
        {
            get { return _children ?? (_children = new CommonDictionaryCollection<StaticTreeDictionary>()); }
        }

        #endregion

        #region public bool IsNodeOrSubNodeOf(IDictionaryTreeItem node)
        /// <summary>
        /// Возвращает значение является ли данный узел равным или подузлом переданного элемента
        /// </summary>
        public bool IsNodeOrSubNodeOf(IDictionaryTreeItem node)
        {
            if (ItemId == node.ItemId)
                return true;

            if (_parent == null)
                return false;
            return _parent.IsNodeOrSubNodeOf(node);
        }

        #endregion

        #region public bool IsNodeOrSubNodeOf(IDictionaryTreeItem[] nodes)
        /// <summary>
        /// Возвращает значение является ли данный узел равным или подузлом переданных элементов
        /// </summary>
        public bool IsNodeOrSubNodeOf(IDictionaryTreeItem[] nodes)
        {
            if (nodes == null || nodes.Length == 0)
                return false;

            return nodes.Any(node => IsNodeOrSubNodeOf(node));
        }

        #endregion
    }
}

