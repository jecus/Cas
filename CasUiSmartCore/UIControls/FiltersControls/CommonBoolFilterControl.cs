using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Filters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Отображает флаги определенного перечисления
    ///</summary>
    public partial class CommonBoolFilterControl : CommonFilterControl
    {

	    public ICommonFilter<bool> Filter
        {
            get { return AttachedObject as ICommonFilter<bool>; }
            set { AttachedObject = value; }
        }

        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        private CommonBoolFilterControl()
        {
            InitializeComponent();
        }

        #region public CommonBoolFilterControl(ICommonFilter<bool> filter) : this()
        /// <summary>
        /// Простой конструктор для создания ЭУ
        /// </summary>
        public CommonBoolFilterControl(ICommonFilter<bool> filter)
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
				var values = new List<object>();
				if (checkBoxValue.CheckState == CheckState.Checked)
					values.Add(true);
				else if (checkBoxValue.CheckState == CheckState.Unchecked)
					values.Add(false);

				Filter.SetParameters(values);
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
	        checkBoxValue.CheckState = CheckState.Indeterminate;
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();

            if(Filter != null)
            {
	            if (Filter.Values.Length > 0)
		            checkBoxValue.Checked = Filter.Values[0];
				else checkBoxValue.CheckState = CheckState.Indeterminate;
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
                if (Filter.Values.Length != 1)
                    return true;

	            var state = checkBoxValue.CheckState;
	            bool? changedValue = null;

	            if (state == CheckState.Checked)
					changedValue = true;
	            if (state == CheckState.Unchecked)
		            changedValue = false;
				if (state == CheckState.Indeterminate)
					changedValue = null;

	            return Filter.Values[0] != changedValue;
            }
            return false;
        }

        #endregion
    }
}
