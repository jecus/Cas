using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonDictionaryFilterControl : CommonFilterControl
    {
        private IDictionaryCollection _typeItemsCollection;
        private readonly IDictionaryItem[] _filterValues;

        /// <summary>
        /// 
        /// </summary>
        public ICommonFilter<IDictionaryItem> Filter
        {
            get { return AttachedObject as ICommonFilter<IDictionaryItem>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonDictionaryFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonDictionaryFilterControl(ICommonFilter<IDictionaryItem> filter, IDictionaryItem[] filterValues) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonDictionaryFilterControl(ICommonFilter<IDictionaryItem> filter, IDictionaryItem[] filterValues)
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
                IDictionaryItem[] values = checkedListBoxItems.CheckedItems.OfType<IDictionaryItem>().ToArray();
                Filter.SetParameters(FilterType.In, values, _typeItemsCollection.ToArray());
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

            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;

            checkedListBoxItems.Items.Clear();
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            if(Filter != null)
            {
                Type filterType = Filter.GetType();
                if(filterType.IsGenericType)
                {
                    Type genericArgumentType = filterType.GetGenericArguments().FirstOrDefault();
                    if(genericArgumentType.IsSubclassOf(typeof(AbstractDictionary)))
                    {
                        try
                        {
                            _typeItemsCollection = GlobalObjects.CasEnvironment.GetDictionary(genericArgumentType);
                        }
                        catch (Exception)
                        {
                            _typeItemsCollection = null;
                        }     
                    }
                    if (genericArgumentType.IsSubclassOf(typeof(StaticDictionary)))
                    {
                        try
                        {
                            PropertyInfo p = genericArgumentType.GetProperty("Items");

                            ConstructorInfo ci = genericArgumentType.GetConstructor(new Type[0]);
                            StaticDictionary instance = (StaticDictionary)ci.Invoke(null);
                            _typeItemsCollection = (IDictionaryCollection)p.GetValue(instance, null);
                        }
                        catch (Exception)
                        {
                            _typeItemsCollection = null;
                        }
                    }
                }

                if (_typeItemsCollection != null)
                {
                    //в CheckListBox добавляются только элементы используемые в фильтруемых
                    //объектах
                    if(_filterValues != null && _filterValues.Length > 0)
                    {
                        foreach (IDictionaryItem dic in _typeItemsCollection.OfType<IDictionaryItem>().Where(i => _filterValues.Contains(i)))
                        {
                            checkedListBoxItems.Items.Add(dic, Filter.Values.Contains(dic));
                        }

                        int countValidItems = Filter.GetValidValuesCount();
                        if (countValidItems == 0)
                            checkBoxSelectAll.CheckState = CheckState.Unchecked;
                        else if (countValidItems == _filterValues.Length)
                            checkBoxSelectAll.CheckState = CheckState.Checked;
                        else checkBoxSelectAll.CheckState = CheckState.Indeterminate;
                    }
                }
            }

            checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;
            checkBoxSelectAll.CheckedChanged += CheckBoxSelectAllCheckedChanged;

            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged += DictionaryCollectionChanged;

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
                IDictionaryItem[] values = checkedListBoxItems.CheckedItems.OfType<IDictionaryItem>().ToArray();

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

        #region private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new Action(FillControls));
            else FillControls();
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
