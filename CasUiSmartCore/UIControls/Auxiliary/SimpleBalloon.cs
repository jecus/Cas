using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{

    /// <summary>
    /// Всплывающие подсказки
    /// </summary>
    public class SimpleBalloon
    {

        /*
         * Скрытые свойтсва
         */

        #region private static ToolTip activeToolTip;
        /// <summary>
        /// Всплывающая подсказка, которую мы используем
        /// </summary>
        private static ToolTip activeToolTip;
        #endregion

        #region private static bool firstRun = true;
        /// <summary>
        /// Вызывали ли мы всплывающую подсказку до этого или нет
        /// </summary>
        private static bool firstRun = true;
        #endregion

        #region private static TextBox previousParent;
        /// <summary>
        /// Предыдущий контрол, над которым показывали подсказку
        /// </summary>
        private static TextBox previousParent;
        #endregion

        /*
         * Вызов всплывающей подсказки статическим методом Show
         */

        #region public static void Show(TextBox textBox, ToolTipIcon toolTipIcon, string toolTipTitle, string toolTipText)
        /// <summary>
        /// Показывает всплывающие подсказки
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="toolTipIcon"></param>
        /// <param name="toolTipTitle"></param>
        /// <param name="toolTipText"></param>
        public static void Show(TextBox textBox, ToolTipIcon toolTipIcon, string toolTipTitle, string toolTipText)
        {
            // Не фатально, ошибок вызывать не нужно, достаточно не показывать подсказку
            if (textBox == null || GetForm(textBox) == null) return;

            // Ставим курсор в редактируемое поле и выделяем текст внутри контрола
            textBox.Focus();
            textBox.SelectAll();

            // Задаем свойства всплывающей подсказке
            activeToolTip.ToolTipIcon = toolTipIcon;
            activeToolTip.ToolTipTitle = toolTipTitle;

            // Показываем всплывающую подсказку
            Show(textBox, toolTipText);

            // Подписываемся на события контрола, чтобы во время убрать подсказку
            HandleEvents(textBox);
        }
        #endregion

        /*
         * Реализация
         */

        #region static SimpleBalloon()
        /// <summary>
        /// Статический конструктор создает всплывающую подсказку и задает начальные параметры
        /// </summary>
        static SimpleBalloon()
        {
            activeToolTip = new ToolTip();
            activeToolTip.IsBalloon = true;
            activeToolTip.AutomaticDelay = 5000;
        }
        #endregion

        #region private static void Show(TextBox textBox, string toolTipText)
        /// <summary>
        /// Показывает всплывающую подсказку, учитывая баг при первом запуске
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="toolTipText"></param>
        private static void Show(TextBox textBox, string toolTipText)
        {
            // Баг при первом запуске - стрелочка направлена вниз, при последующих запусках стрелочка показывает вверх
            // Вызываем первый запуск умышленно, чтобы стрелочка всегда показывала вверх
            if (firstRun)
            {
                firstRun = false;
                activeToolTip.Show(toolTipText, textBox, GetPoint(textBox));
                activeToolTip.Hide(textBox);
            }

            // Показываем всплывающую подсказку 
            if (!activeToolTip.Active)
                activeToolTip.Active = true;

            activeToolTip.Show(toolTipText, textBox, GetPoint(textBox));
        }
        #endregion

        #region private static void HandleEvents(TextBox parent)
        /// <summary>
        /// Подписываемся на события контрола, чтобы во время убрать подсказку
        /// </summary>
        /// <param name="parent"></param>
        private static void HandleEvents(TextBox parent)
        {

            if (previousParent == parent) return;

            // Отписываемся от событий прошлого контрола
            if (previousParent != null)
            {
                previousParent.KeyDown -= textBox_KeyDown;
                previousParent.Leave -= parent_Leave;
                previousParent.LostFocus -= textBox_LostFocus;
                Form previousForm = GetForm(previousParent);
                if (previousForm != null)
                {
                    previousForm.MouseDown -= textBox_MouseDown;
                    previousForm.MouseWheel -= textBox_MouseWheel;
                    previousForm.Scroll -= parentForm_Scroll;
                }
                
            }

            // Меняем родителя
            previousParent = parent;

            // Подписываемся на события нового контрола
            parent.KeyDown += textBox_KeyDown;
            parent.Leave += parent_Leave;
            parent.LostFocus += textBox_LostFocus;
            Form parentForm = GetForm(parent);
            parentForm.MouseDown += textBox_MouseDown;
            parentForm.MouseWheel += textBox_MouseWheel;
            parentForm.Scroll += parentForm_Scroll;
        }
        #endregion

        #region private static Form GetForm(Control control)
        /// <summary>
        /// Find control's parent form
        /// </summary>
        /// <param name="control">control</param>
        /// <returns>control's parent form</returns>
        private static Form GetForm(Control control)
        {
            Control c = control;
            while (c != null && !(c is Form))
                c = c.Parent;
            if (c!= null && c is Form) return (Form) c;
            return null;
        }

        #endregion

        #region private static Point GetPoint(TextBox c)
        /// <summary>
        /// Получает точку, в которой требуется показать подсказку
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static Point GetPoint(TextBox c)
        {
            // Вычисляем место, где заканчивается введенный текст
            Graphics graphics = Graphics.FromHwnd(c.Handle);
            int x = (int)graphics.MeasureString(c.Text, c.Font).Width;
            int y = c.Height;
            return new Point(x, y);
        }
        #endregion

        /*
         * Обработка вспомогательных событий
         */

        #region static void parent_Leave(object sender, EventArgs e)
        static void parent_Leave(object sender, EventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

        #region static void textBox_KeyDown(object sender, KeyEventArgs e)
        static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

        #region static void parentForm_Scroll(object sender, ScrollEventArgs e)
        static void parentForm_Scroll(object sender, ScrollEventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

        #region static void textBox_MouseWheel(object sender, MouseEventArgs e)
        static void textBox_MouseWheel(object sender, MouseEventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

        #region static void textBox_MouseDown(object sender, MouseEventArgs e)
        static void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

        #region static void textBox_LostFocus(object sender, EventArgs e)
        static void textBox_LostFocus(object sender, EventArgs e)
        {
            activeToolTip.Active = false;
        }
        #endregion

    }
}