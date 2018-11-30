using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using SmartCore.Auxiliary;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonDateTimePeriodFilterControl : CommonFilterControl
    {
	    private readonly DateTime _minDate;
	    private readonly DateTime _maxDate;

	    public CommonFilter<DateTime> Filter
        {
            get { return AttachedObject as CommonFilter<DateTime>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonDateTimePeriodFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonStringFilterControl(CommonFilter<DateTime> filter) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonDateTimePeriodFilterControl(CommonFilter<DateTime> filter, DateTime minDate, DateTime maxDate)
            : this()
        {
	        _minDate = minDate;
	        _maxDate = maxDate;
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
                var dateTimeTo= dateTimePickerDateTo.Value.Date.Add(dateTimePickerTimeTo.Value.TimeOfDay);
                var dateTimeFrom = dateTimePickerDateFrom.Value.Date.Add(dateTimePickerTimeFrom.Value.TimeOfDay);
                var values = new object []{ dateTimeFrom, dateTimeTo };

                Filter.SetParameters(FilterType.Between, values);
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
                var dateTimeTo = dateTimePickerDateTo.Value.Date.Add(dateTimePickerTimeTo.Value.TimeOfDay);
                var dateTimeFrom = dateTimePickerDateFrom.Value.Date.Add(dateTimePickerTimeFrom.Value.TimeOfDay);
                if (dateTimeFrom > dateTimeTo)
                {
                    if (message == "") message += "\n";
                    message += "From date must be less then To date";
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
            dateTimePickerDateFrom.Value= _minDate;
            dateTimePickerTimeFrom.Value = _minDate;
            dateTimePickerDateTo.Value= _maxDate;
            dateTimePickerTimeTo.Value = _maxDate;
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

			if (Filter != null && Filter.Values.Length > 0)
			{
				dateTimePickerDateFrom.Value = Filter.Values[0].Date;
				dateTimePickerDateTo.Value = Filter.Values[1].Date;
				dateTimePickerTimeFrom.Value = Filter.Values[0];
				dateTimePickerTimeTo.Value = Filter.Values[1];
			}
			else
			{
				dateTimePickerDateFrom.Value = _minDate;
				dateTimePickerTimeFrom.Value = _minDate;
				dateTimePickerDateTo.Value = _maxDate;
				dateTimePickerTimeTo.Value = _maxDate;
			}

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
                var dateTimeTo = dateTimePickerDateTo.Value.Date.Add(dateTimePickerTimeTo.Value.TimeOfDay);
                var dateTimeFrom = dateTimePickerDateFrom.Value.Date.Add(dateTimePickerTimeFrom.Value.TimeOfDay);
                var values = new [] { dateTimeFrom, dateTimeTo };

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
