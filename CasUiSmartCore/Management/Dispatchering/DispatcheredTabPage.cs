using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvControls.AvMultitabControl;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Implimetation of <see cref="MultitabPage"/> as <see cref="IDisplayer"/> to be dispatchered by <see cref="Dispatcher"/>
    /// </summary>
    public partial class DispatcheredTabPage : MultitabPage, IDisplayer
    {
        #region History Stack

        /// <summary>
        /// Этот класс хранит историю открытых скринов, 
        /// работает как explorer
        /// </summary>
        private class MyStack
        {
            public MyStack(IDisplayingEntity entity, string tabText)
            {
                CurrentEntity = entity;
                TabText = tabText;
            }
            /// <summary>
            /// Текущий элемент списка скринов (содержимого вкладки)
            /// </summary>
            public IDisplayingEntity CurrentEntity { get; set; }
            public string TabText { get; set; }

            public MyStack Next { get; set; }
            public MyStack Prev { get; set; }
        }

        void ClearNext(MyStack stack)
        {
            if (stack == null)
            {
                return;
            }

            if (stack.Next != null)
            {
                ClearNext(stack.Next);
                stack.Next.CurrentEntity.OnDisplayerRemoved();
                stack.Next = null;
            }
        }

        private MyStack Stack { get; set; }

        private MyStack First(MyStack stack)
        {
            MyStack result = stack;
            while (result.Prev != null)
            {
                result = result.Prev;
            }
            return result;
        }

        public void PreviousPage()
        {
            if (Stack.Prev != null)
            {
                Stack = Stack.Prev;

                _entity = Stack.CurrentEntity;
                Text = Stack.TabText;
                ShowScreen();
            }
        }
        public void NextPage()
        {
            if (Stack.Next != null)
            {
                Stack = Stack.Next;

                _entity = Stack.CurrentEntity;
                Text = Stack.TabText;
                ShowScreen();
            }
        }

        public event EventHandler ScreenChanged;
        void OnScreenChanget()
        {
            if (ScreenChanged != null)
                ScreenChanged.Invoke(this, EventArgs.Empty);
        }

        public bool CanPreviousPage()
        {
            if (Stack == null)
            {
                return false;
            }

            return Stack.Prev != null;
        }

        public bool CanNextPage()
        {
            if (Stack == null)
            {
                return false;
            }

            return Stack.Next != null;
        }

        #region Для кнопки закрытия

        ///<summary>
        /// Событие, сигнализирующее об изменении количества вкладок у родителя данной вкладки
        ///</summary>
        public event EventHandler CountScreenChanget;
        /// <summary>
        /// Возбуждает событие изменения количества вкладок у родителя данной вкладки
        /// </summary>
        private void InvokeCountScreenChanget()
        {
            if (CountScreenChanget != null)
                CountScreenChanget(this, new EventArgs());

            if (Owner != null)
            {
                Owner.CloseButton.Enabled = CanEnableCloseTab();
            }
        }

        #region private void DispatcheredTabPageOwnerChanget(object sender, EventArgs e)
        /// <summary>
        /// Реагирует на смену владельца данной вкладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DispatcheredTabPageOwnerChanget(object sender, EventArgs e)
        {
            if (Owner != null)
            {
                //Оптисывание и новое подписывание на событие,
                //что бы не было 2 и более подписывания на одно событие
                Owner.TabPages.CollectionChanged -= TabPagesCollectionChanged;
                Owner.TabPages.CollectionChanged += TabPagesCollectionChanged;
                Owner.Closed -= OwnerClosed;
                Owner.Closed += OwnerClosed;
            }
        }
        #endregion

        private void OwnerClosed(object sender, AvControls.AvMultitabControl.Auxiliary.AvMultitabControlEventArgs e)
        {
            InvokeCountScreenChanget();
        }

        #region private void TabPagesCollectionChanged(object sender, CollectionChangeEventArgs e)
        /// <summary>
        /// Реагирует на изменение коллекции вкладок владельца данной вкладки
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Аргументы события</param>
        private void TabPagesCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            InvokeCountScreenChanget();
        }
        #endregion

        public bool CanEnableCloseTab()
        {
            if (Owner == null)
            {
                return false;
            }
            return Owner.TabCount > 1;
        }

        /// <summary>
        /// Вызывается при нажатии кнопки закрытия программы
        /// </summary>
        public event EventHandler ClosingWindow;

        public void OnClosingWindow()
        {
            EventHandler handler = ClosingWindow;
            if (handler != null) handler(this, new EventArgs());
        }

        /// <summary>
        /// Вызывается при отмене закрытия программы 
        /// </summary>
        public event EventHandler CancelClosingWindow;

        public void OnCancelClosingWindow()
        {
            EventHandler handler = CancelClosingWindow;
            if (handler != null) handler(this, new EventArgs());
        }

        public AvMultitabControl ParentControl
        {
            get { return Owner; }
        }

        #endregion

        #region private void AddScreen()
        /// <summary>
        /// Добавляет скрин в стек
        /// </summary>
        private void AddScreen()
        {
            if (Stack == null)
            {
                Stack = new MyStack(_entity, Text);
            }
            else
            {
                ClearNext(Stack);
                Stack.Next = new MyStack(_entity, Text) { Prev = Stack };
                Stack = Stack.Next;
            }
            OnScreenChanget();
        }
        #endregion

        void ShowScreen()
        {
            Controls.Clear();
            Controls.Add((Control)_entity);
            _entity.Show();
            Show();

            OnScreenChanget();
        }

        #endregion

        #region Fields
        /// <summary>
        /// Текущее содержимое вкладки
        /// </summary>
        private IDisplayingEntity _entity;
        private bool _performCloseChecking = true;
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public DispatcheredTabPage()
        {
            InitializeComponent();
            OwnerChanget += DispatcheredTabPageOwnerChanget;
        }

        /// <summary>
        /// Создает новую вкладку
        /// </summary>
        /// <param name="text">Текст заголовка вкладки</param>
        public DispatcheredTabPage(string text)
            : base(text)
        {
            OwnerChanget += DispatcheredTabPageOwnerChanget;
        }

        #endregion

        #region Methods
        #endregion

        #region public IDisplayingEntity Entity

        #region public IDisplayingEntity Entity
        /// <summary>
        /// Скрин, отображаемый вкладкой
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDisplayingEntity Entity
        {

            get { return _entity; }
            set
            {
                if (value != null)
                {
                    _entity = value;

                    //if (entity is ScreenControl)
                    //{
                    //    ((ScreenControl) entity).Displayer = this;
                    //}
                    if (_entity as IReference != null)
                    {
                        ((IReference)_entity).Displayer = this;
                    }
                    ShowScreen();
                    //Show(value);
                    AddScreen();
                    InvokeCountScreenChanget();
                }
                else
                {
                    throw new NullReferenceException("Entity is null");
                }
            }
        }
        #endregion

        #region public bool PerformCloseChecking
        /// <summary>
        /// Выполнять ли проверку на закрытие перед закрытием отображателя
        /// </summary>
        public bool PerformCloseChecking
        {
            get { return _performCloseChecking; }
            set { _performCloseChecking = value; }
        }
        #endregion

        #region public void Show(DisplayingEntity entity)
        /// <summary>
        /// Invokes displaying of entity
        /// </summary>
        /// <param name="newEntity">Entity to display</param>
        public void Show(IDisplayingEntity newEntity)  // старый метод
        {
            if (newEntity is Control)
            {
                Entity = newEntity;
            }
        }
        #endregion

        #region public bool ContainedDataEquals(IDisplayer obj)
        /// <summary>
        /// Checks whether contained data of two displayers are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayer obj)
        {
            return obj.Entity.ContainedData.Equals(Entity.ContainedData);
        }
        #endregion

        #region public bool ContainedDisplayingEntityEquals(IDisplayer obj)
        /// <summary>
        /// Checks whether displaying entities have same type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ContainedDisplayingEntityEquals(IDisplayer obj)
        {
            return obj.Entity.GetType() == _entity.GetType();
        }
        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Действия, происходящие при деактвации отображателя
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            if (_entity != null)
                _entity.OnDisplayerDeselecting(arguments);
        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Проверяется возможность удаления отображателя
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (_entity != null)
            {
                MyStack stack = First(Stack);
                while (stack != null)
                {
                    stack.CurrentEntity.OnDisplayerRemoving(arguments);

                    if (arguments.Cancel) return;

                    stack = stack.Next;
                }
            }
            InvokeDisplayerRemoving();
        }
        #endregion

        #region public void OnDisplayerRemoved(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Проверяется возможность удаление отображателя
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoved(DisplayerCancelEventArgs arguments)
        {
            if (_entity != null)
            {
                MyStack stack = First(Stack);
                while (stack != null)
                {
                    stack.CurrentEntity.OnDisplayerRemoved();
                    stack = stack.Next;
                }
            }
            InvokeDisplayerRemoved();
        }
        #endregion

        #region public event EventHandler DisplayerRemoving
        /// <summary>
        /// Возникает при удалении отображателя
        /// </summary>
        public event EventHandler DisplayerRemoving;

        /// <summary>
        /// Возбуждает событие <see cref="DisplayerRemoving"/>
        /// </summary>
        private void InvokeDisplayerRemoving()
        {
            if (DisplayerRemoving != null)
                DisplayerRemoving.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region public event EventHandler DisplayerRemoved
        /// <summary>
        /// Событие происходящее после удаления отображателя
        /// </summary>
        public event EventHandler DisplayerRemoved;

        /// <summary>
        /// Возбуждает событие <see cref="DisplayerRemoved"/>
        /// </summary>
        private void InvokeDisplayerRemoved()
        {
            if (DisplayerRemoved != null)
                DisplayerRemoved.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #endregion
    }
}
