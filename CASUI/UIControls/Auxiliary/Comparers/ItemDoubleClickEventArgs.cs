using System;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// јргументы событи€ ItemDoubleClick
    /// </summary>
    /// <typeparam name="T">“ип элемента</typeparam>
    public class ItemDoubleClickEventArgs<T>:EventArgs 
    {
        private readonly T item;

        /// <summary>
        /// —оздаютс€ аргументы событи€ ItemDoubleClick
        /// </summary>
        /// <param name="_item"></param>
        public ItemDoubleClickEventArgs(T _item)
        {
            item = _item;
        }
        /// <summary>
        /// Ёлемент
        /// </summary>
        public T Item
        {
            get { return item; }
        }
    }
}
