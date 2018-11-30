using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonIntFilterControl : CommonFilterControl
    {
        public CommonFilter<int> Filter
        {
            get { return AttachedObject as CommonFilter<int>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonIntFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonIntFilterControl(CommonFilter<int> filter) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonIntFilterControl(CommonFilter<int> filter)
            : this()
        {
            AttachedObject = filter;
        }
        #endregion

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (Filter != null)
            {
                FilterType ft = (FilterType) comboBoxFilterType.SelectedValue;
                string[] subStrings = textBoxFilter.Text.Split(';', ' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                List<Int32> values = new List<int>();
                foreach (string s in subStrings)
                {
                    int result;
                    if (int.TryParse(s, out result))
                    {
                        values.Add(result);
                    }
                }
                Filter.SetParameters(ft, values.Cast<object>().ToArray());
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override bool CheckData(out string message)
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData(out string message)
        {
            message = "";
            if (Filter != null)
            {
                if (comboBoxFilterType.SelectedValue == null)
                {
                    if (message == "") message += "\n";
                    message += "Not set property filter type";
                    return false;
                }

                string[] subStrings = textBoxFilter.Text.Split(';', ' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                foreach (string s in subStrings)
                {
                    int result;
                    if (!int.TryParse(s, out result))
                    {
                        if (message == "") message += "\n";
                        message += "Filter value is not properly formatted." +
                                   "\nUse the following format: NN; NNN; NN";
                        textBoxFilter.BackColor = Color.Red;
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region public override void ClearFilter()
        /// <summary>
        /// Производит очистку фильтра
        /// </summary>
        public override void ClearFilter()
        {
            comboBoxFilterType.SelectedValue = FilterType.Equal;
            textBoxFilter.Text = "";
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            comboBoxFilterType.Items.Clear();

            Type enumType = typeof (FilterType);
            List<KeyValuePair<string, FilterType>> list = new List<KeyValuePair<string, FilterType>>();
            foreach (FilterType ft in Enum.GetValues(enumType))
            {
                //Тип фильтрации FilterType.In не добавляется
                //т.к. он будет эквивалентен FilterType.Equal
                if(ft == FilterType.In)
                    continue;

                string name = Enum.GetName(enumType, ft);
                string desc = name;
                FieldInfo fi = enumType.GetField(name);
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    string s = attributes[0].Description;
                    if (!string.IsNullOrEmpty(s))
                    {
                        desc = s;
                    }
                }
                list.Add(new KeyValuePair<string, FilterType>(desc, ft));
            }
            comboBoxFilterType.DisplayMember = "Key";
            comboBoxFilterType.ValueMember = "Value";
            comboBoxFilterType.DataSource = list;

            textBoxFilter.Text = "";

            if (Filter != null)
            {
                comboBoxFilterType.SelectedValue = Filter.FilterType;
                if (Filter.Values.Length > 0)
                {
                    for (int i = 0; i < Filter.Values.Length; i++)
                    {
                        if (i > 0) textBoxFilter.Text += "; ";
                        textBoxFilter.Text += Filter.Values[i];
                    }
                }
            }
            else comboBoxFilterType.SelectedValue = FilterType.Equal;

            EndUpdate();
        }
        #endregion

        #region public override bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public override bool GetChangeStatus()
        {
            if (Filter != null)
            {
                FilterType ft = (FilterType)comboBoxFilterType.SelectedValue;
                if (Filter.FilterType != ft)
                    return true;

                string[] subStrings = textBoxFilter.Text.Split(';', ' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();
                List<int> values = new List<int>();
                foreach (string s in subStrings)
                {
                    int result;
                    if(int.TryParse(s, out result))
                    {
                        values.Add(result);    
                    }
                }
                if (values.Count != Filter.Values.Length)
                    return true;
                if (values.Where((t, i) => t != Filter.Values[i]).Any())
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        #endregion

        #region private void TextBoxFilterTextChanged(object sender, System.EventArgs e)
        private void TextBoxFilterTextChanged(object sender, System.EventArgs e)
        {
            if (textBoxFilter.BackColor == Color.Red)
                textBoxFilter.BackColor = Color.White;
        }
        #endregion

        #region private void TextBoxFilterKeyPress(object sender, KeyPressEventArgs e)
        private void TextBoxFilterKeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (!(char.IsDigit(c) || c == ';' || c == '-' || c == '\b'))
            {
                //Если нажатая клавиша является не цифрой или не знаками ; - 
                //или не является пробелом, то обрабока события завершается 
                e.Handled = true;
            }
        }
        #endregion
    }
}
