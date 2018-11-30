#region

using System.ComponentModel;

#endregion

namespace AvControls.AvMultitabControl.Auxiliary
{
    /// <summary>
    /// Описывает агрумент отмены действия (выбора, снятия выбора, закрытия и т.д.) в мультивкладочном контроле
    /// </summary>
    public class AvMultitabControlCancelEventArgs : CancelEventArgs
    {
        /// <summary>
        /// Действие, которое требуется отменить
        /// </summary>
        private readonly AvMultitabControlAction _action;
        /// <summary>
        /// Вкладка, для которой выполняется действие
        /// </summary>
        private readonly MultitabPage _tabPage;

        public AvMultitabControlCancelEventArgs(AvMultitabControlAction action, MultitabPage tabPage)
        {
            _action = action;
            _tabPage = tabPage;
        }

        /// <summary>
        /// Возвращает действие, которое необходимо отменить
        /// </summary>
        public AvMultitabControlAction Action
        {
            get { return _action; }
        }

        /// <summary>
        /// Возвращает вкладку, связанную с действием
        /// </summary>
        public MultitabPage TabPage
        {
            get { return _tabPage; }
        }
    }
}