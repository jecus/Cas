using System;
using System.ComponentModel;
using System.Windows.Forms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary.DataGridViewElements
{
    /// <summary>
    /// Колонка для отображения даты
    /// </summary>
    public class DataGridViewLookupColumn : DataGridViewColumn
    {
        /// <summary>
        /// Инициализирует новый объект колонки для отображения даты
        /// </summary>
        public DataGridViewLookupColumn()
            : base(new DataGridViewLookupCell())
        {
            DefaultCellStyle.NullValue = null;
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
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewLookupCell)))
                {
                    throw new InvalidCastException("Must be a LookupCell");
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>
        /// Represents the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [Browsable(false)]
        public Type ViewedType
        {
            get
            {
                DataGridViewLookupCell lookupCell = base.CellTemplate as DataGridViewLookupCell;
                if (lookupCell == null)
                    return null;
                return lookupCell.Type;
            }
            set
            {
                DataGridViewLookupCell lookupCell = base.CellTemplate as DataGridViewLookupCell;
                if (lookupCell == null)
                {
                    throw new InvalidCastException("Must be a LookupCell");
                }
                if (value != null && !value.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    throw new InvalidCastException("Must be a BaseEntityObject");
                }
                lookupCell.Type = value;
            }
        }
    }
}
