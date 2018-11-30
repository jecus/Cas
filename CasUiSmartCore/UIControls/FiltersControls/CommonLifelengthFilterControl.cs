using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonLifelengthFilterControl : CommonFilterControl
    {
        private Orientation _orientation = Orientation.Vertical;
        private Lifelength[] _filterValues;

        ///<summary>
        ///</summary>
        public ICommonFilter<Lifelength> Filter
        {
            get { return AttachedObject as ICommonFilter<Lifelength>; }
            set { AttachedObject = value; }
        }

        ///<summary>
        /// Возвращает или задает направление контрола
        ///</summary>
        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                UpdateControl();
            }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonLifelengthFilterControl()
        {
            InitializeComponent();
        }

        private void UpdateControl()
        {
            if(_orientation == Orientation.Vertical)
            {
                radio_ByInterval.Location = 
                    new Point(radio_ByLifelength.Left, radio_ByLifelength.Bottom + 17);  
                checkBoxSelectAll.Location = 
                    new Point(radio_ByInterval.Right + 4, radio_ByInterval.Top);
                checkedListBoxItems.Location =
                    new Point(radio_ByInterval.Left - 4, checkBoxSelectAll.Bottom + 5);
                Size = 
                    new Size(lifelengthViewerLifelength.Right, checkedListBoxItems.Bottom + 4);
                checkedListBoxItems.Size =
                    new Size(lifelengthViewerLifelength.Right, Bottom - checkedListBoxItems.Top + 4);
            }
            else
            {
                radio_ByInterval.Location =
                    new Point(lifelengthViewerLifelength.Right + 4, radio_ByLifelength.Top);
                checkBoxSelectAll.Location =
                    new Point(radio_ByInterval.Right + 4, radio_ByInterval.Top);
                checkedListBoxItems.Location =
                    new Point(radio_ByInterval.Left - 4, checkBoxSelectAll.Bottom + 5);
                Size =
                    new Size(checkedListBoxItems.Right, checkedListBoxItems.Bottom + 4);
                checkedListBoxItems.Size =
                    new Size(Right - checkedListBoxItems.Left, Bottom + 4);
            }
        }

        #region public CommonLifelengthFilterControl(ICommonFilter<Lifelength> filter, Lifelength[] filterValues) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonLifelengthFilterControl(ICommonFilter<Lifelength> filter, Lifelength[] filterValues)
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
                if(radio_ByLifelength.Checked)
                {
                    FilterType ft = (FilterType)comboBoxFilterType.SelectedValue;
                    Lifelength[] values = lifelengthViewerLifelength.Lifelength.IsNullOrZero() 
                        ? new Lifelength[0] 
                        : new[]{lifelengthViewerLifelength.Lifelength};
                    Filter.SetParameters(ft, values);    
                }
                else
                {
                    Lifelength[] values = checkedListBoxItems.CheckedItems.OfType<Lifelength>().ToArray();
                    Lifelength[] allValues = checkedListBoxItems.Items.OfType<Lifelength>().ToArray(); 
                    //_filterValues.Where(l => !l.IsNullOrZero()).Distinct().ToArray();
                    Filter.SetParameters(FilterType.In, values, allValues);   
                }
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
            comboBoxFilterType.SelectedValue = FilterType.Equal;
            lifelengthViewerLifelength.Lifelength.Reset();
            checkBoxSelectAll.Checked = false;

            radio_ByLifelength.Checked = true;
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

            comboBoxFilterType.Items.Clear();

            Type enumType = typeof(FilterType);
            List<KeyValuePair<string, FilterType>> list = new List<KeyValuePair<string, FilterType>>();
            foreach (FilterType ft in Enum.GetValues(enumType))
            {
                if (ft == FilterType.Between || ft == FilterType.In)
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

            checkedListBoxItems.Items.Clear();
            checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
            checkBoxSelectAll.CheckedChanged -= CheckBoxSelectAllCheckedChanged;

            if(Filter != null)
            {
                if (_filterValues != null && _filterValues.Length > 0)
                {
                    IEnumerable<Lifelength> tempIntervals = 
                        _filterValues.Distinct()
                                     .OrderBy(l => l)
                                     .ToList();
                    var tempResult = new List<Lifelength>();
                    //Интервалы, содержащие только часы
                    var intervalsGroupHours =
                        tempIntervals.Where(i => i.Hours != null
                                              && i.Cycles == null
                                              && i.Days == null);
                    tempResult.AddRange(intervalsGroupHours.ToArray());
                    //Интервалы, содержащие только циклы
                    IEnumerable<Lifelength> intervalsGroupCycles =
                        tempIntervals.Where(i => i.Hours == null
                                              && i.Cycles != null
                                              && i.Days == null);
                    tempResult.AddRange(intervalsGroupCycles.ToArray());
                    //Интервалы, содержащие только дни
                    IEnumerable<Lifelength> intervalsGroupDays =
                        tempIntervals.Where(i => i.Hours == null
                                              && i.Cycles == null
                                              && i.Days != null);
                    tempResult.AddRange(intervalsGroupDays.ToArray());
                    //Интервалы, содержащие часы/циклы
                    IEnumerable<Lifelength> intervalsGroupHoursCycles =
                        tempIntervals.Where(i => i.Hours != null
                                              && i.Cycles != null
                                              && i.Days == null);
                    tempResult.AddRange(intervalsGroupHoursCycles.ToArray());
                    //Интервалы, содержащие часы/дни
                    IEnumerable<Lifelength> intervalsGroupHoursDays =
                        tempIntervals.Where(i => i.Hours != null
                                              && i.Cycles == null
                                              && i.Days != null);
                    tempResult.AddRange(intervalsGroupHoursDays.ToArray());
                    //Интервалы, содержащие только циклы/дни
                    IEnumerable<Lifelength> intervalsGroupCyclesDays =
                        tempIntervals.Where(i => i.Hours == null
                                              && i.Cycles != null
                                              && i.Days != null);
                    tempResult.AddRange(intervalsGroupCyclesDays.ToArray());
                    //Интервалы, содержащие часы/циклы/дни
                    IEnumerable<Lifelength> intervalsGroupAll =
                        tempIntervals.Where(i => i.Hours != null
                                              && i.Cycles != null
                                              && i.Days != null);
                    tempResult.AddRange(intervalsGroupAll.ToArray());

                    if (Filter.FilterType == FilterType.Between || Filter.FilterType == FilterType.In)
                    {
                        radio_ByInterval.Checked = true;
                        comboBoxFilterType.SelectedValue = FilterType.Equal;

                        foreach (Lifelength ll in tempResult)
                        {
                            checkedListBoxItems.Items.Add(ll, Filter.Values.Contains(ll, new Lifelength()));
                        }
                    }
                    else
                    {
                        radio_ByLifelength.Checked = true;
                        comboBoxFilterType.SelectedValue = Filter.FilterType;
                        checkedListBoxItems.Items.AddRange(tempResult.ToArray());
                        if (Filter.Values.Length > 0)
                            lifelengthViewerLifelength.Lifelength = Filter.Values[0];
                    }

                    int countValidItems = Filter.GetValidValuesCount();
                    if (countValidItems == 0)
                        checkBoxSelectAll.CheckState = CheckState.Unchecked;
                    else if (countValidItems == checkedListBoxItems.Items.Count)
                        checkBoxSelectAll.CheckState = CheckState.Checked;
                    else checkBoxSelectAll.CheckState = CheckState.Indeterminate;
                }
            }
            else comboBoxFilterType.SelectedValue = FilterType.Equal;

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
                if (radio_ByLifelength.Checked)
                {
                    FilterType ft = (FilterType)comboBoxFilterType.SelectedValue;
                    Lifelength value = lifelengthViewerLifelength.Lifelength;

                    if (Filter.FilterType != ft)
                        return true;
                    //if ((value.IsNullOrZero() && Filter.Values.Length > 0) ||
                    //    (!value.IsNullOrZero() && Filter.Values.Length != 1))
                    //    return true;
                    if (Filter.Values.Length != 1)
                        return true;
                    if (!value.Equals(Filter.Values[0]))
                    {
                        return true;
                    }
                    return false;
                }
                if (Filter.FilterType != FilterType.In)
                    return true;
                Lifelength[] values = checkedListBoxItems.CheckedItems.OfType<Lifelength>().ToArray();
                if (values.Length != Filter.Values.Length)
                    return true;
                if (values.Where((t, i) => !t.Equals(Filter.Values[i])).Any())
                {
                    return true;
                }
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

        #region private void RadioByLifelengthCheckedChanged(object sender, EventArgs e)

        private void RadioByLifelengthCheckedChanged(object sender, EventArgs e)
        {
            if(radio_ByLifelength.Checked)
            {
                lifelengthViewerLifelength.Enabled = true;
                comboBoxFilterType.Enabled = true;

                checkedListBoxItems.Enabled = false;
                checkBoxSelectAll.Enabled = false;
            }
            else
            {
                lifelengthViewerLifelength.Enabled = false;
                comboBoxFilterType.Enabled = false;

                checkedListBoxItems.Enabled = true;
                checkBoxSelectAll.Enabled = true;
            }
        }
        #endregion

    }
}
