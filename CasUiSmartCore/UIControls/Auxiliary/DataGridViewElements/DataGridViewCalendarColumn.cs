using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.DataGridViewElements
{
    /// <summary>
    /// Колонка для отображения даты
    /// </summary>
    public class DataGridViewCalendarColumn : DataGridViewColumn
    {
        /// <summary>
        /// Инициализирует новый объект колонки для отображения даты
        /// </summary>
        public DataGridViewCalendarColumn() : base(new DataGridViewCalendarCell())
        {
        }

        /// <summary>
        /// Represents the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell. 
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewCalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
