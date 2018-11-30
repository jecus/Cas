using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAS.UI.Interfaces
{


    /// <summary>
    /// Диалог редактирования объекта
    /// </summary>
    public partial class EditObjectDialog : Form
    {

        /*
         * Свойства
         */

        #region public Object AttachedObject
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        private Object _AttachedObject = null;
        /// <summary>
        /// Редактируемый объект
        /// </summary>
        public Object AttachedObject
        {
            get { return _AttachedObject; }
            set
            {
                if (AttachedObject != value)
                {
                    ObjectChanging();
                    _AttachedObject = value;
                    ChangeObject();
                    ObjectChanged();
                }
            }
        }
        #endregion

        #region public bool Modified { get; }
        /// <summary>
        /// Были ли сделаны изменения внутри контрола
        /// </summary>
        private bool _Modified;
        /// <summary>
        /// Были ли сделаны изменения внутри контрола
        /// </summary>
        public bool Modified { get { return _Modified; } }
        #endregion

        #region public event EditObjectControlModifiedEventHandler EditObjectControlModified;
        /// <summary>
        /// Событие возникает, когда были внесены изменения в один из контролов диалога
        /// </summary>
        public delegate void EditObjectControlModifiedEventHandler();
        /// <summary>
        /// Событие возникает, когда были внесены изменения в один из контролов диалога
        /// </summary>
        public event EditObjectControlModifiedEventHandler EditObjectControlModified;
        #endregion

        /*
         * Конструкторы скрыты, возможен только вызов через статический метод Show
         */

        #region protected EditObjectDialog()
        /// <summary>
        /// Создает диалог не связанный с объектом
        /// </summary>
        protected EditObjectDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region protected EditObjectDialog(Object AttachedObject) : this()
        /// <summary>
        /// Создает диалог редактирования объекта
        /// </summary>
        /// <param name="AttachedObject"></param>
        protected EditObjectDialog(Object AttachedObject)
            : this()
        {
            this.AttachedObject = AttachedObject;
        }
        #endregion

        /*
         * Работа с диалогом
         */

        #region protected static void RegisterDialog(Object AttachedObject)
        /// <summary>
        /// Регистрирует диалог в общей куче, чтобы потом его открыть
        /// </summary>
        /// <param name="AttachedObject"></param>
        protected static void RegisterDialog(EditObjectDialog dlg)
        {
            _OpenedDialogs.Add(dlg);
            dlg.FormClosed += new FormClosedEventHandler(dlg_FormClosed);
        }
        #endregion

        #region private static void dlg_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// При закрытии диалога удаляем его из коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void dlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            EditObjectDialog dlg = sender as EditObjectDialog;
            if (dlg == null) return;
            //
            if (_OpenedDialogs.Contains(dlg))
                _OpenedDialogs.Remove(dlg);
        }
        #endregion

        #region protected static EditObjectDialog GetDialogByObject(Object AttachedObject)
        /// <summary>
        /// Находит диалог по объекту
        /// </summary>
        /// <param name="AttachedObject"></param>
        /// <returns></returns>
        protected static EditObjectDialog GetDialogByObject(Object AttachedObject)
        {
            foreach (EditObjectDialog dlg in _OpenedDialogs)
                if (dlg.AttachedObject == AttachedObject)
                    return dlg;
            
            //
            return null;
        }
        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)
        /// <summary>
        /// Диалог сам обрабатывает контролы EdiObjectControl
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            EditObjectControl c = e.Control as EditObjectControl;
            if (c != null)
            {
                c.ControlModified += new ControlEventHandler(EditObjectControl_ControlModified);
            }
        }
        #endregion

        #region protected override void OnControlRemoved(ControlEventArgs e)
        /// <summary>
        /// Когда контрол был удален, мы должны отписаться от его событий
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            EditObjectControl c = e.Control as EditObjectControl;
            if (c != null)
            {
                c.ControlModified -= EditObjectControl_ControlModified;
            }
        }
        #endregion

        #region protected void SetModified()
        /// <summary>
        /// Выставляет значение флага Modified а также вызывает событие о том, что объект был изменен
        /// </summary>
        protected void SetModified()
        {
            if (EditObjectControlModified != null) EditObjectControlModified();
        }
        #endregion

        #region protected bool CheckData()
        /// <summary>
        /// Проверяет введенные данные
        /// </summary>
        /// <returns></returns>
        protected bool CheckData()
        {
            return CheckData(this);
        }
        #endregion

        #region protected void ApplyChanges()
        /// <summary>
        /// Применяет объекту все сделанные изменения в контролах
        /// </summary>
        protected void ApplyChanges()
        {
            ApplyChanges(this);
        }
        #endregion

        #region protected bool Save()
        /// <summary>
        /// Сохранить сделанные изменения в объекте в базу данных
        /// </summary>
        /// <returns></returns>
        protected bool Save()
        {

            // Проверяем внесенные изменения
            if (!CheckData()) return false;

            // Применяем изменения к объекту 
            ApplyChanges();

            // Вызываем перегруженный метод сохранения объекта, т.к. EditObjectDialog не имеет представления об объекте
            SaveObjectCalled();

            // Операция прошла успешно
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private static List<EditObjectDialog> _OpenedDialogs = new List<EditObjectDialog>();
        /// <summary>
        /// Список открытых диалогов
        /// </summary>
        private static List<EditObjectDialog> _OpenedDialogs = new List<EditObjectDialog>();
        #endregion

        #region private void EditObjectControl_ControlModified(object sender, ControlEventArgs e)
        /// <summary>
        /// Были внесены изменения в один из контролов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditObjectControl_ControlModified(object sender, ControlEventArgs e)
        {
            SetModified();
        }
        #endregion

        #region private bool CheckData(Control control)
        /// <summary>
        /// Вызывает метод провердки введенных данных всех контролов
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private bool CheckData(Control control)
        {
            if (control == null || control.Controls == null) return true;


            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in control.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    if (!cc.CheckData()) return false;
                    else // Рекурсивно просматриваем объекты панели например
                        if (!CheckData(c)) return false;
            }


            // Все проверки завершились успешно
            return true;
        }
        #endregion

        #region private void ApplyChanges(Control control)
        /// <summary>
        /// Вызывает метод ApplyChanges у каждого контрола
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private void ApplyChanges(Control control)
        {
            if (control == null || control.Controls == null) return;

            // Просматриваем до первой "провалившейся" проверки
            foreach (Control c in control.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null) cc.ApplyChanges();
                else // Рекурсивно просматриваем объекты панели например
                    ApplyChanges(c);
            }
        }
        #endregion

        #region private void ObjectChanging(Control control)
        /// <summary>
        /// Метод вызывается, когда объект привязанный к диалогу будет изменен
        /// Вызов базового метода обязателен
        /// </summary>
        private void ObjectChanging(Control control)
        {
            if (control == null || control.Controls == null) return;
            //
            foreach (Control c in control.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    cc.ObjectChanging();
                else // Рекурсивно просматриваем объекты панели например
                    ObjectChanging(c);
            }
        }
        #endregion

        #region private void ObjectChanged(Control control)
        /// <summary>
        /// Метод вызывается, когда объект привязанный к диалогу изменился
        /// Вызов базового метода обязателен
        /// </summary>
        private void ObjectChanged(Control control)
        {
            if (control == null || control.Controls == null) return;
            //
            foreach (Control c in control.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    cc.ObjectChanged();
                else // Рекурсивно просматриваем объекты панели например
                    ObjectChanged(c);
            }
        }
        #endregion

        #region private void ChangeObject(Control control)
        /// <summary>
        /// Изменить объект всем контролам
        /// </summary>
        /// <param name="control"></param>
        private void ChangeObject(Control control)
        {
            if (control == null || control.Controls == null) return;
            //
            foreach (Control c in control.Controls)
            {
                EditObjectControl cc = c as EditObjectControl;
                if (cc != null)
                    cc.AttachedObject = _AttachedObject;
                else // Рекурсивно просматриваем объекты панели например
                    ChangeObject(c);
            }
        }
        #endregion


        /*
         * Методы должны быть перегружены - скопировать здесь и вставить в диалог наследник - заменить virtual на override ОБЯЗАТЕЛЬНО !
         */

        #region public static void Show(Object AttachedObject)
        /// <summary>
        /// Вызывает диалог редактирования объекта.
        /// Данный метод придется вручную переписать.
        /// </summary>
        /// <param name="AttachedObject"></param>
        public static void Show(Object AttachedObject)
        {
            EditObjectDialog dlg = GetDialogByObject(AttachedObject);
            if (dlg == null)
            {
                dlg = new EditObjectDialog(AttachedObject);
                RegisterDialog(dlg);
            }
            dlg.Show();
        }
        #endregion

        #region protected virtual bool SaveObjectCalled()
        /// <summary>
        /// Было вызвано сохранение объекта
        /// </summary>
        protected virtual bool SaveObjectCalled()
        {
            return true;
        }
        #endregion

        #region protected virtual void ObjectChanging()
        /// <summary>
        /// Метод вызывается, когда объект привязанный к диалогу будет изменен
        /// Вызов базового метода обязателен
        /// </summary>
        protected virtual void ObjectChanging()
        {
            ObjectChanging(this);
        }
        #endregion

        #region protected virtual void ObjectChanged()
        /// <summary>
        /// Метод вызывается, когда объект привязанный к диалогу изменился
        /// Вызов базового метода обязателен
        /// </summary>
        protected virtual void ObjectChanged()
        {
            ObjectChanged(this);
        }
        #endregion

        #region protected virtual void ChangeObject()
        /// <summary>
        /// Изменить объект всем контролам
        /// </summary>
        /// <param name="control"></param>
        protected virtual void ChangeObject()
        {
            ChangeObject(this);
        }
        #endregion

    }
}