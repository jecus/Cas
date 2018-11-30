using System;
using System.Windows.Forms;

namespace CAS.UI.Interfaces
{

    /*
     * При перегрузке все поля TextBox (например) должны быть подписаны на событие OnChanging и вызывать метод SetModified()
     */

    /// <summary>
    /// Представляет собой базу для контрола, который будет редактировать свойства какого-либо объекта
    /// </summary>
    public partial class EditObjectControl : UserControl
    {

        /*
         * Свойства
         */

        #region public Object AttachedObject
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        private Object _attachedObject;
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        public Object AttachedObject
        {
            get { return _attachedObject; }
            set 
            {
                if (AttachedObject != value)
                {
                    ObjectChanging();
                    _attachedObject = value;
                    ObjectChanged();
                    FillControls();
                }
            }
        }
        #endregion

        #region public bool Modified { get; }
        /// <summary>
        /// Были ли сделаны изменения внутри контрола
        /// </summary>
        private bool _modified; 
        /// <summary>
        /// Были ли сделаны изменения внутри контрола
        /// </summary>
        public bool Modified { get { return _modified; } }
        #endregion

        #region public event ControlEventHandler ControlModified;
        /// <summary>
        /// Событие срабатывает в момент изменения данных пользователем
        /// </summary>
        public event ControlEventHandler ControlModified;
        #endregion

        /*
         * Оба конструктора наследуемого контрола должны ссылаться на базовый с параметром
         */

        #region public EditObjectControl()
        /// <summary>
        /// Создает контрол не связанный с объектом
        /// </summary>
        public EditObjectControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public EditObjectControl(Object AttachedObject) : this()
        /// <summary>
        /// Создает контрол редактирования свойств объекта и привязывает к нему объект
        /// </summary>
        /// <param name="AttachedObject"></param>
        public EditObjectControl(Object AttachedObject)
            : this()
        {
            FillControls();
        }
        #endregion

        /*
         * Методы должны быть перегружены
         */
        #region public virtual bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public virtual bool GetChangeStatus()
        {
            return false;
        }

        #endregion

        #region public virtual void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public virtual void ApplyChanges()
        {
            _modified = false;
        }
        #endregion

        #region public virtual void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public virtual void FillControls()
        {
            
            ////Обязательно все изменения обернуть в BeginUpdate() и EndUpdate()
              
            //  BeginUpdate();
            //  textBox1.Text = "";
            //  textBox2.Text = "";
            ////  ...
            //  EndUpdate();
             
        }
        #endregion

        #region public virtual bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckData()
        {
            return true;
        }
        #endregion

        #region public virtual bool CheckData(out string message)
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckData(out string message)
        {
            message = "";
            return true;
        }
        #endregion

        #region  public virtual void SaveData()
        /// <summary>
        /// Сохранет информацию контрола в БД
        /// </summary>
        /// <returns></returns>
        public virtual void SaveData()
        {
        }

        #endregion

        #region public virtual void ObjectChanging()
        /// <summary>
        /// Процедура вызывается, когда связанный объект будет меняться.
        /// Здесь следует отписаться от событий старого объекта
        /// </summary>
        public virtual void ObjectChanging()
        {
        }
        #endregion

        #region public virtual void ObjectChanged()
        /// <summary>
        /// Процедура вызывается, когда объект поменялся
        /// Следует подписаться на события нового объекта
        /// Метод FillControls вызывается автоматически
        /// </summary>
        public virtual void ObjectChanged()
        {
        }
        #endregion

        /*
         * Работа с контролом 
         */

        #region protected void SetModified()
        /// <summary>
        /// Выставляет значение флага Modified а также вызывает событие о том, что объект был изменен
        /// </summary>
        protected void SetModified()
        {
            if (_isUpdating) return;

            //
            _modified = true;
            if (ControlModified != null) ControlModified(this, new ControlEventArgs(this));
        }
        #endregion

        #region protected void BeginUpdate()
        /// <summary>
        /// Приостанавливает регистрацию событий изменения в контроле
        /// </summary>
        protected void BeginUpdate()
        {
            _isUpdating = true;
        }
        #endregion

        #region protected void EndUpdate()
        /// <summary>
        /// Возобновляет регистрацию событий изменения в контроле
        /// </summary>
        protected void EndUpdate()
        {
            _isUpdating = false;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool _IsUpdating = false;
        /// <summary>
        /// Обновляет ли контрол в данный момент
        /// </summary>
        private bool _isUpdating;
        #endregion

        
    }
}
