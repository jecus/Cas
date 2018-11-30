using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonBaseEntityObjectFilterControl : CommonFilterControl
    {
        private IBaseEntityObject[] _filterValues;

        public ICommonFilter<IBaseEntityObject> Filter
        {
            get { return AttachedObject as ICommonFilter<IBaseEntityObject>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonBaseEntityObjectFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonBaseEntityObjectFilterControl(ICommonFilter<IBaseEntityObject> filter, IBaseEntityObject[] filterValues) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonBaseEntityObjectFilterControl(ICommonFilter<IBaseEntityObject> filter, IBaseEntityObject[] filterValues)
            : this()
        {
            _filterValues = filterValues;
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
                BaseEntityObject[] values = checkedListBoxItems.CheckedItems.OfType<BaseEntityObject>().ToArray();
                Filter.SetParameters(FilterType.In, values, _filterValues.Distinct().ToArray()); 
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
            return true;
        }
        #endregion

        #region public override void ClearFilter()
        /// <summary>
        /// Производит очистку фильтра
        /// </summary>
        public override void ClearFilter()
        {
            checkBoxSelectAll.Checked = false;

            //for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
            //{
            //    checkedListBoxItems.SetItemChecked(i,false);
            //}
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            checkedListBoxItems.Items.Clear();
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            if (Filter != null)
            {
                if (_filterValues != null && _filterValues.Length > 0)
                {
                    List<IBaseEntityObject> tempResult =
                        _filterValues.Distinct()
                                     .OrderBy(l => l)
                                     .ToList();

                    foreach (IBaseEntityObject ll in tempResult)
                    {
                        checkedListBoxItems.Items.Add(ll, Filter.Values.Contains(ll, new BaseEntityObject()));
                    }

                    int countValidItems = Filter.GetValidValuesCount();
                    if (countValidItems == 0)
                        checkBoxSelectAll.CheckState = CheckState.Unchecked;
                    else if (countValidItems == checkedListBoxItems.Items.Count)
                        checkBoxSelectAll.CheckState = CheckState.Checked;
                    else checkBoxSelectAll.CheckState = CheckState.Indeterminate;
                }
            }

            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;
            checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;

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
                BaseEntityObject[] values = checkedListBoxItems.CheckedItems.OfType<BaseEntityObject>().ToArray();

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

        #region private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)

        private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            if (checkedListBoxItems.CheckedItems.Count == 0)
                checkBoxSelectAll.CheckState = CheckState.Unchecked;
            else if (checkedListBoxItems.CheckedItems.Count == checkedListBoxItems.Items.Count)
                checkBoxSelectAll.CheckState = CheckState.Checked;
            else checkBoxSelectAll.CheckState = CheckState.Indeterminate;
            checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;
        }
        #endregion

        #region private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)

        private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelectAll.CheckState == CheckState.Checked)
            {
                checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;

                for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
                {
                    checkedListBoxItems.SetItemChecked(i, true);
                }

                checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;
            }
            else if (checkBoxSelectAll.CheckState == CheckState.Unchecked)
            {
                checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;

                for (int i = 0; i < checkedListBoxItems.Items.Count; i++)
                {
                    checkedListBoxItems.SetItemChecked(i, false);
                }

                checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;
            }
        }
        #endregion
    }
}
