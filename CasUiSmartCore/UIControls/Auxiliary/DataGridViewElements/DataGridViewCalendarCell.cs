using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.DataGridViewElements
{
    /// <summary>
    /// Ячейка для отображения даты
    /// </summary>
    public class DataGridViewCalendarCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// Содержит значение минимальной даты
        /// </summary>
        private DateTime _minDate = DateTime.MinValue;
        /// <summary>
        /// Содержит значение максимальной даты
        /// </summary>
        private DateTime _maxDate = DateTime.MaxValue;
        /// <summary>
        /// Создает новую ячейку для отображения даты
        /// </summary>
        public DataGridViewCalendarCell()
        {
            // Use the short date format. 
            Style.Format = "dd.MM.yyyy";
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewCalendarEditingControl ctl = DataGridView.EditingControl as DataGridViewCalendarEditingControl;
            // Use the default row value when Value property is null. 
            if(ctl != null)
            {
                if (Value == null)
                {
                    ctl.Value = DefaultNewRowValue != null ? (DateTime)DefaultNewRowValue : DateTime.Now;
                }
                else
                {
                    ctl.Value = (DateTime)Value;
                }   
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(DataGridViewCalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return DateTime.Now;
            }
        }

        #region private DataGridViewCalendarEditingControl EditingCalendar
        /// <summary>
        /// Возвращает текущий DataGridView EditingControl как DataGridViewCalendarEditingControl
        /// </summary>
        private DataGridViewCalendarEditingControl EditingCalendar
        {
            get
            {
                return DataGridView.EditingControl as DataGridViewCalendarEditingControl;
            }
        }
        #endregion

        #region public DateTime MaxDate
        /// <summary>
        /// Возвращает или задает максимальную дату для ячейки
        /// </summary>
        public DateTime MaxDate
        {

            get
            {
                return _maxDate;
            }

            set
            {
                if (_maxDate != value)
                {
                    SetMaximum(RowIndex, value);
                    OnCommonChange();
                }
            }
        }
        #endregion

        /// <summary>
        ///  Возвращает или задает минимальную дату для ячейки
        /// </summary>
        public DateTime MinDate
        {

            get
            {
                return _minDate;
            }

            set
            {
                if (_minDate != value)
                {
                    SetMinimum(RowIndex, value);
                    OnCommonChange();
                }
            }
        }

        #region Methods

        #region private DateTime Constrain(DateTime value)
        /// <summary>
        /// Returns the provided value constrained to be within the min and max. 
        /// </summary>
        private DateTime Constrain(DateTime value)
        {
            Debug.Assert(_minDate <= _maxDate);
            if (value < _minDate)
            {
                value = _minDate;
            }
            if (value > _maxDate)
            {
                value = _maxDate;
            }
            return value;
        }
        #endregion

        #region internal void SetMaximum(int rowIndex, DateTime value)
        internal void SetMaximum(int rowIndex, DateTime value)
        {
            _maxDate = value;
            if (_minDate > _maxDate)
            {
                _minDate = _maxDate;
            }
            object cellValue = GetValue(rowIndex);
            if (cellValue != null)
            {
                DateTime currentValue = Convert.ToDateTime(cellValue);
                DateTime constrainedValue = Constrain(currentValue);
                if (constrainedValue != currentValue)
                {
                    SetValue(rowIndex, constrainedValue);
                }
            }
            Debug.Assert(_maxDate == value);
            if (OwnsEditingCalendar(rowIndex))
            {
                EditingCalendar.MaxDate = value;
            }
        }
        #endregion

        #region internal void SetMinimum(int rowIndex, DateTime value)

        internal void SetMinimum(int rowIndex, DateTime value)
        {
            _minDate = value;
            if (_minDate > _maxDate)
            {
                _maxDate = value;
            }
            object cellValue = GetValue(rowIndex);
            if (cellValue != null)
            {
                DateTime currentValue = Convert.ToDateTime(cellValue);
                DateTime constrainedValue = Constrain(currentValue);
                if (constrainedValue != currentValue)
                {
                    SetValue(rowIndex, constrainedValue);
                }
            }
            Debug.Assert(_minDate == value);
            if (OwnsEditingCalendar(rowIndex))
            {
                EditingCalendar.MinDate = value;
            }
        }
        #endregion

        #region private void OnCommonChange()
        private void OnCommonChange()
        {
            if (DataGridView != null && !DataGridView.IsDisposed && !DataGridView.Disposing)
            {
                if (RowIndex == -1)
                {
                    // Invalidate and autosize column
                    DataGridView.InvalidateColumn(ColumnIndex);

                    // TODO: Add code to autosize the cell's column, the rows, the column headers 
                    // and the row headers depending on their autosize settings.
                    // The DataGridView control does not expose a public method that takes care of this.
                }
                else
                {
                    // The DataGridView control exposes a public method called UpdateCellValue
                    // that invalidates the cell so that it gets repainted and also triggers all
                    // the necessary autosizing: the cell's column and/or row, the column headers
                    // and the row headers are autosized depending on their autosize settings.
                    DataGridView.UpdateCellValue(ColumnIndex, RowIndex);
                }
            }
        }
        #endregion

        #region private bool OwnsEditingCalendar(int rowIndex)
        /// <summary>
        /// Определяет, показан ли для данной ячейки с заданным номером строки редактирующий контрол или нет
        /// Индеск строки необходим, потому что ячейка может быть общей для нескольких строк
        /// </summary>
        private bool OwnsEditingCalendar(int rowIndex)
        {
            if (rowIndex == -1 || DataGridView == null)
            {
                return false;
            }
            DataGridViewCalendarEditingControl calendarEditingControl = DataGridView.EditingControl as DataGridViewCalendarEditingControl;
            return calendarEditingControl != null && rowIndex == ((IDataGridViewEditingControl)calendarEditingControl).EditingControlRowIndex;
        }
        #endregion

        #endregion
    }
}
