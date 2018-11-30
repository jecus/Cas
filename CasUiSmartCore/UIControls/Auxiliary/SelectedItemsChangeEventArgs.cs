using System;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Аргументы события SelectedItemChange
    /// </summary>
    public class SelectedItemsChangeEventArgs : EventArgs
    {
        private readonly int _itemsCount;

        /// <summary>
        /// Создаются аргументы события SelectedItemChange
        /// </summary>
        /// <param name="itemsCount">Количество выделенных элементов</param>
        public SelectedItemsChangeEventArgs(int itemsCount)
        {
            _itemsCount = itemsCount;
        }

        /// <summary>
        /// Количество выделенных элементов
        /// </summary>
        public int ItemsCount
        {
            get { return _itemsCount; }
        }
    }
}
