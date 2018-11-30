using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvControls.AvMultitabControl.Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Это контейнер для всех скринов
    /// </summary>
    public partial class ScreenControl : UserControl, IReference, IDisplayingEntity
    {
        #region Fields

        private BaseEntityObject _current;

        protected readonly AnimatedThreadWorker AnimatedThreadWorker = new AnimatedThreadWorker();
        #endregion

        #region Implementation of IReference

        private IDisplayer _displayer;

        #region public IDisplayer Displayer
        public IDisplayer Displayer
        {
            get { return _displayer; }
            set
            {        
                _displayer = value;
                aircraftHeaderControl1.CurrentDisplayer = _displayer;
                headerControl.CurrentDisplayer = _displayer;

                if (value != null)
                {
                    value.ScreenChanged += ScreenChanget;
                    value.ClosingWindow += ClosingWindow;
                    value.CancelClosingWindow += CancelClosingWindow;
                    if (value.ParentControl != null)
                    {
                        value.ParentControl.Selected += ParentControlSelected;
                    }
                }
            }
        }
        #endregion

        #region public string DisplayerText { get; set; }
        
        public string DisplayerText { get; set; }
        #endregion

        #region public IDisplayingEntity Entity{ get; set;}
        public IDisplayingEntity Entity{ get; set;}
        #endregion

        #region public ReflectionTypes ReflectionType{ get; set; }

        public ReflectionTypes ReflectionType{ get; set; }
        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        ///<summary>
        ///</summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #region protected void InvokeDisplayerRequested(ReferenceEventArgs e)
        ///<summary>
        /// Запускает событие об создании новой вкладки
        ///</summary>
        ///<param name="e">экран и параметры новой вкладки</param>
        protected void InvokeDisplayerRequested(ReferenceEventArgs e)
        {
            EventHandler<ReferenceEventArgs> handler = DisplayerRequested;
            if (handler != null) handler(this, e);
        }
        #endregion

        #endregion

        #region IDisplayingEntity

        #region public object ContainedData
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return CurrentAircraft; }
            set { CurrentAircraft = (Aircraft) value; }
        }
        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {

            if (!(obj is ScreenControl)) return false;

            return ((ScreenControl) obj).DisplayerText == DisplayerText;
            //if (obj.ContainedData == null) return false;
            //if (CurrentAircraft == null) return false;

            //return
            //    ((Aircraft)obj.ContainedData).AircraftID == CurrentAircraft.AircraftID;
        }
        #endregion

        #region public virtual void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public virtual void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());
        }
        #endregion

        #region public virtual void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public virtual void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            //if (GetChangeStatus())
            //{
            //    switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
            //                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
            //                            MessageBoxDefaultButton.Button1))
            //    {
            //        case DialogResult.Yes:
            //            //arguments.Cancel = !Save(); 
            //            SaveData();
            //            break;
            //        case DialogResult.Cancel:
            //            arguments.Cancel = true;
            //            break;
            //    }
            //}

            if (EntityRemoving != null)
            {
                EntityCancelEventArgs eventArgs = new EntityCancelEventArgs(this);

                EntityRemoving(this, eventArgs);

                if(eventArgs.Cancel)
                    return;
            }

            if (!IsDisposed)
            {
                try
                {
                    DisposeScreen();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error in removed screen " + GetType(), ex);
                }
            }
        }
        #endregion

        #region public void OnDisplayerRemoved()
        /// <summary>
        /// Возбуждает событие после удаления отображаемого объекта
        /// </summary>
        public void OnDisplayerRemoved()
        {
            if (EntityRemoved != null)
                EntityRemoved(this, new EventArgs());
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {

        }
        #endregion

        #region public void SetEnabled(bool isEnbaled)
        /// <summary>
        /// Set page enable
        /// </summary>
        /// <param name="isEnbaled"></param>
        public void SetEnabled(bool isEnbaled)
        {
            headerControl.Enabled = isEnbaled;
            footerControl1.Enabled = isEnbaled;
            aircraftHeaderControl1.Enabled = isEnbaled;
        }
        #endregion

        #region public event EventHandler InitComplition;
        ///<summary>
        ///</summary>
        public event EventHandler InitComplition;
        #endregion

        #region  public event EventHandler<EntityCancelEventArgs> EntityRemoving

        /// <summary>
        /// Событие, оповещающее об удалении содержимого с отображателя (вкладки)
        /// </summary>
        public event EventHandler<EntityCancelEventArgs> EntityRemoving;
        
        #endregion

        #region public event EventHandler DisplayerRemoved;
        /// <summary>
        /// Возникает после удаления содержимого
        /// </summary>
        public event EventHandler EntityRemoved;

        #endregion

        #region public virtual void DisposeScreen()
        ///<summary>
        /// Освобождает ресурсы занимаемые экраном
        ///</summary>
        public virtual void DisposeScreen()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();

            AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.RunWorkerCompleted -= AnimatedThreadWorkerRunWorkerCompleted;

            AnimatedThreadWorker.Dispose();

            Dispose(true);
        }
        #endregion

        #region protected virtual void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        protected virtual void CancelAsync()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
        }
        #endregion

        #endregion

        #region BaseField

        ///<summary>
        ///</summary>
     
        public string ReportText { get; set; }

        #endregion

        #region Properties

        #region public bool ChildClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли 1-й дочерний элемент навигационного контрола нажатия
        /// </summary>
        public bool ChildClickable
        {
            get { return aircraftHeaderControl1.ChildClickable; }
            set { aircraftHeaderControl1.ChildClickable = value; }
        }

        #endregion

        #region public BaseSmartCoreObject CurrentParent

        /// <summary>
        /// Указывает на текущий Aircraft
        /// </summary>
        public BaseEntityObject CurrentParent
        {
            get { return _current ?? aircraftHeaderControl1.Operator; }
            set
            {
                _current = value;
                aircraftHeaderControl1.Child = _current;
            }
        }
        #endregion

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// Указывает на текущий Aircraft
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get { return _current as Aircraft; }
            set
            {
                _current = value;
                aircraftHeaderControl1.Child = _current;
                if(statusControl.Visible)
                    statusControl.Aircraft = value;
            }
        }
        #endregion

        #region public Operator CurrentOperator

        /// <summary>
        /// Указывает на текущий Aircraft
        /// </summary>
        public Operator CurrentOperator
        {
            get { return aircraftHeaderControl1.Operator; }
            set
            {
                aircraftHeaderControl1.Operator = value;
                if (statusControl.Visible)
                    statusControl.Operator = value;
            }
        }
        #endregion

        #region public Store CurrentStore

        /// <summary>
        /// Указывает на текущий Склад
        /// </summary>
        public Store CurrentStore
        {
            get { return _current as Store; }
            set
            {
                _current = value;
                aircraftHeaderControl1.Child = _current;
            }
        }
        #endregion

        #region public bool NextClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли элемент "След. экран" навигационного контрола нажатия
        /// </summary>
        public bool NextClickable
        {
            get { return aircraftHeaderControl1.NextClickable; }
            set { aircraftHeaderControl1.NextClickable = value; }
        }

        #endregion

        #region public bool OperatorClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли элемент "Текущий оператор" навигационного контрола нажатия
        /// </summary>
        public bool OperatorClickable
        {
            get { return aircraftHeaderControl1.OperatorClickable; }
            set { aircraftHeaderControl1.OperatorClickable = value; }
        }

        #endregion

        #region public bool PrevClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли элемент "Пред. экран" навигационного контрола нажатия
        /// </summary>
        public bool PrevClickable
        {
            get { return aircraftHeaderControl1.PrevClickable; }
            set { aircraftHeaderControl1.PrevClickable = value; }
        }

        #endregion

        #region public bool SaveAndAddButtonEnabled
        /// <summary>
        /// Возврашает или задает значение того, доступна ли кнопка Save and Add
        /// </summary>
        public bool SaveAndAddButtonEnabled
        {
            get { return headerControl.SaveAndAddButtonEnabled; }
            set { headerControl.SaveAndAddButtonEnabled = value; }
        }

        #endregion

        #region public bool ShowTopPanelContainer
        /// <summary>
        /// Показать/скрыть панель для кнопок, нахлдящююся под основным заголовком
        /// </summary>
        public bool ShowTopPanelContainer
        {
            get { return panelTopContainer.Visible; }
            set { panelTopContainer.Visible = value; Update(); }
        }
        #endregion

        #region public bool ShowAircraftStatusPanel
        /// <summary>
        /// Показать/Скрыть панель, показывающую текущий статус самолета
        /// </summary>
        public bool ShowAircraftStatusPanel
        {
            get { return statusControl.Visible; }
            set { statusControl.Visible = value; Update();}
        }
        #endregion

        #region public string StatusTitle
        ///<summary>
        /// Текст панели статуса самолета
        ///</summary>
        public string StatusTitle
        {
            get { return statusControl.Title; }
            set { statusControl.Title = value; }
        }
        #endregion

        #region public ContextMenuStrip ButtonPrintMenuStrip
        ///<summary>
        /// Устанавливает или возвращает контекстное меню ButtonPrint
        ///</summary>
        public ContextMenuStrip ButtonPrintMenuStrip
        {
            get { return headerControl.PrintButtonContextMenuStrip; }
            set { headerControl.PrintButtonContextMenuStrip = value; }
        }
        #endregion
        
        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public ScreenControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
            AnimatedThreadWorker.RunWorkerCompleted += AnimatedThreadWorkerRunWorkerCompleted;
        }
        #endregion

        #region protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        /// <summary>
        /// производит действия по завершению работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        #endregion

        #region protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// Производит работу над отображаемыми в странице элементами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            AnimatedThreadWorker.ReportProgress(0, "load directives");

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region protected virtual void ScreenChanget(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие смены скрина в данной вкладке
        /// </summary>
        protected virtual void ScreenChanget(object sender, EventArgs e)
        {
        }
        #endregion

        #region protected virtual void CancelClosingWindow(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие отмены закрытия программы
        /// </summary>
        protected virtual void CancelClosingWindow(object sender, EventArgs e)
        {
        }
        #endregion

        #region protected virtual void ClosingWindow(object sender, EventArgs e)
        /// <summary>
        /// Метод, обрабатывающий событие нажатия кнопки закрытия программы
        /// </summary>
        protected virtual void ClosingWindow(object sender, EventArgs e)
        {
        }
        #endregion

        #region protected virtual void ParentControlSelected(object sender, AvMultitabControlEventArgs e)
        /// <summary>
        /// Метод обрабатывает событие смены текущей вкладки в MultiTabControl-е
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ParentControlSelected(object sender, AvMultitabControlEventArgs e)
        {
        }
        #endregion
    }
}
