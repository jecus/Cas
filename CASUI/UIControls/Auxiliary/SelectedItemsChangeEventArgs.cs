using System;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Аргументы события SelectedItemChange
    /// </summary>
    public class SelectedItemsChangeEventArgs : EventArgs
    {
        private readonly int itemsCount=0;

        /// <summary>
        /// Создаются аргументы события SelectedItemChange
        /// </summary>
        /// <param name="itemsCount">Количество выделенных элементов</param>
        public SelectedItemsChangeEventArgs(int itemsCount)
        {
            this.itemsCount = itemsCount;
        }

        /// <summary>
        /// Количество выделенных элементов
        /// </summary>
        public int ItemsCount
        {
            get { return itemsCount; }
        }
    }
}
