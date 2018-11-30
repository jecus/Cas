using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Controls;
using LTR.UI.UIControls.DirectivesControls;

namespace LTR.UI.UIControls.Auxiliary
{
    internal static class UsefullMethods
    {

        #region public static void SelectAllChildControls(Control control)

        /// <summary>
        /// Этот метод подписывает для каждого внутреннего элемента управления событие MouseHover и в обработчике этого события выделяет его. 
        /// Необходим для корректной работы AutoScroll на страницах нашей любимой программы )))
        /// </summary>
        /// <param name="control"></param>
        public static void SelectAllChildControls(Control control)
        {
            control.MouseMove -= UsefullMethods_MouseHover;
            control.MouseMove += UsefullMethods_MouseHover;

            for (int i = 0; i < control.Controls.Count ; i++)
            {
                control.Controls[i].MouseMove -= UsefullMethods_MouseHover;
                control.Controls[i].MouseMove += UsefullMethods_MouseHover;
                SelectAllChildControls(control.Controls[i]);
            }
        }

        #endregion

        #region private void UsefullMethods_MouseHover(object sender, EventArgs e)

        private static void UsefullMethods_MouseHover(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if ((control != null) && !(control is ComplianceListView))
                control.Select();
        }

        #endregion

        #region public static string EnumToString(Enum item)
        /// <summary>
        /// Метод преобразования перечисления в строковое представление
        /// </summary>
        /// <param name="item">Значение, которое надо преобразовать</param>
        /// <returns></returns>
        public static string EnumToString(Enum item)
        {
            FieldInfo info = item.GetType().GetField(item.ToString());
            object[] descriptionAttributes = info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (descriptionAttributes == null)
                return item.ToString();
            if (descriptionAttributes.Length < 1)
                return item.ToString();
            return ((DescriptionAttribute)descriptionAttributes[0]).Description;
        }

        #endregion

    }
}
