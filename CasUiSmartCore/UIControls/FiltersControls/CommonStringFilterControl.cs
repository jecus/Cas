using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonStringFilterControl : CommonFilterControl
    {
        public CommonFilter<string> Filter
        {
            get { return AttachedObject as CommonFilter<string>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonStringFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonStringFilterControl(CommonFilter<string> filter) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonStringFilterControl(CommonFilter<string> filter)
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
                string[] values = textBoxFilter.Text.Split(';', ' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

                Filter.SetParameters(ft, values);
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
            //comboBoxFilterType.Items.AddRange(new object[] {FilterType.Equal, FilterType.NotEqual});
            //comboBoxFilterType.SelectedItem = FilterType.Equal;

            Type enumType = typeof(FilterType);
            List<KeyValuePair<string, FilterType>> list = new List<KeyValuePair<string, FilterType>>();
            foreach (FilterType ft in Enum.GetValues(enumType))
            {
                if (!(ft == FilterType.Equal || ft == FilterType.NotEqual))
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

            if(Filter != null)
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
                string[] values = textBoxFilter.Text.Split(';', ' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

                if (Filter.FilterType != ft)
                    return true;
                if (values.Length != Filter.Values.Length)
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
    }
}
