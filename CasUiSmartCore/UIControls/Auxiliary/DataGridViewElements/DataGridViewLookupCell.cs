using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary.DataGridViewElements
{
    /// <summary>
    /// Ячейка для отображения справочника элементов
    /// </summary>
    public class DataGridViewLookupCell : DataGridViewTextBoxCell
    {
        // Used in KeyEntersEditMode function
        [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern short VkKeyScan(char key);

        private Type _viewedType;

        // The bitmap used to paint the non-edited cells via a call to NumericUpDown.DrawToBitmap
        [ThreadStatic]
        private static Bitmap _renderingBitmap;

        // The NumericUpDown control used to paint the non-edited cells via a call to NumericUpDown.DrawToBitmap
        [ThreadStatic]
        private static TextBox _paintingLookupCombobox;
        /// <summary>
        /// Создает новый экземпляр ячейки для отображения справочника
        /// </summary>
        public DataGridViewLookupCell()
        {
             //Use the short date format. 

            // Create a thread specific NumericUpDown control used for the painting of the non-edited cells
            if (_paintingLookupCombobox == null || _paintingLookupCombobox.IsDisposed)
            {
                _paintingLookupCombobox = new TextBox();
                //_paintingLookupCombobox.ButtonReloadVisible = false;
                //_paintingLookupCombobox.ButtonViewListVisible = false;
                //_paintingLookupCombobox.ComboBoxStyle = ComboBoxStyle.DropDownList;
                // Some properties only need to be set once for the lifetime of the control:
                _paintingLookupCombobox.BorderStyle = BorderStyle.None;
                _paintingLookupCombobox.ReadOnly = true;
                //_paintingLookupCombobox.Type = _viewedType;
            }

            //Create a thread specific bitmap used for the painting of the non-edited cells
            if (_renderingBitmap == null)
            {
                _renderingBitmap = new Bitmap(100, 22);
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value. 
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewLookupEditingControl ctl = DataGridView.EditingControl as DataGridViewLookupEditingControl;
            // Use the default row value when Value property is null. 
            if(ctl != null)
            {
                if (ctl.ButtonReloadVisible || ctl.ButtonViewListVisible)
                {
                    ctl.ButtonReloadVisible = false;
                    ctl.ButtonViewListVisible = false;
                    ctl.ComboBoxStyle = ComboBoxStyle.DropDownList;
                }
                if (ctl.Type == null)
                {
                    ctl.Type = _viewedType;

                    string initialFormattedValueStr = initialFormattedValue as string;
                    if (initialFormattedValueStr == null)
                    {
                        ctl.Text = string.Empty;
                    }
                    else
                    {
                        ctl.Text = initialFormattedValueStr;
                    }
                }
                if (Value == null)
                {
                    ctl.SelectedItem = DefaultNewRowValue != null ? DefaultNewRowValue as BaseEntityObject : null;
                }
                else
                {
                    ctl.SelectedItem = Value as BaseEntityObject;
                }   
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses. 
                return typeof(DataGridViewLookupEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(BaseEntityObject);
            }
        }

        public override Type FormattedValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains. 

                return typeof(BaseEntityObject);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value. 
                return null;
            }
        }

        /// <summary>
        /// Represents the implicit cell that gets cloned when adding rows to the grid.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Type Type
        {
            get
            {
                if (DataGridView == null)
                {
                    return _viewedType;
                }
                DataGridViewLookupEditingControl ctl = DataGridView.EditingControl as DataGridViewLookupEditingControl;
                // Use the default row value when Value property is null. 
                if (ctl != null)
                {
                    return ctl.Type;
                }
                return null;
            }
            set
            {
                if (value != null && !value.IsSubclassOf(typeof(BaseEntityObject)))
                {
                    throw new InvalidCastException("Must be a BaseEntityObject");
                }
                
                if (DataGridView == null)
                    _viewedType = value;
                else
                {
                    DataGridViewLookupEditingControl ctl = DataGridView.EditingControl as DataGridViewLookupEditingControl;
                    if (ctl == null)
                    {
                        throw new InvalidCastException("Must be a DataGridViewLookupEditingControl");
                    }
                    ctl.Type = value;    
                }
            }
        }

        //#region private DataGridViewLookupEditingControl EditingLookup
        ///// <summary>
        ///// Возвращает текущий DataGridView EditingControl как DataGridViewCalendarEditingControl
        ///// </summary>
        //private DataGridViewLookupEditingControl EditingLookup
        //{
        //    get
        //    {
        //        return DataGridView.EditingControl as DataGridViewLookupEditingControl;
        //    }
        //}
        //#endregion

        #region Methods

        //#region private DateTime Constrain(DateTime value)
        ///// <summary>
        ///// Returns the provided value constrained to be within the min and max. 
        ///// </summary>
        //private DateTime Constrain(DateTime value)
        //{
        //    Debug.Assert(_minDate <= _maxDate);
        //    if (value < _minDate)
        //    {
        //        value = _minDate;
        //    }
        //    if (value > _maxDate)
        //    {
        //        value = _maxDate;
        //    }
        //    return value;
        //}
        //#endregion

        //#region internal void SetMaximum(int rowIndex, DateTime value)
        //internal void SetMaximum(int rowIndex, DateTime value)
        //{
        //    _maxDate = value;
        //    if (_minDate > _maxDate)
        //    {
        //        _minDate = _maxDate;
        //    }
        //    object cellValue = GetValue(rowIndex);
        //    if (cellValue != null)
        //    {
        //        DateTime currentValue = System.Convert.ToDateTime(cellValue);
        //        DateTime constrainedValue = Constrain(currentValue);
        //        if (constrainedValue != currentValue)
        //        {
        //            SetValue(rowIndex, constrainedValue);
        //        }
        //    }
        //    Debug.Assert(_maxDate == value);
        //    if (OwnsEditingCalendar(rowIndex))
        //    {
        //        EditingLookup.MaxDate = value;
        //    }
        //}
        //#endregion

        //#region internal void SetMinimum(int rowIndex, DateTime value)

        //internal void SetMinimum(int rowIndex, DateTime value)
        //{
        //    _minDate = value;
        //    if (_minDate > _maxDate)
        //    {
        //        _maxDate = value;
        //    }
        //    object cellValue = GetValue(rowIndex);
        //    if (cellValue != null)
        //    {
        //        DateTime currentValue = Convert.ToDateTime(cellValue);
        //        DateTime constrainedValue = Constrain(currentValue);
        //        if (constrainedValue != currentValue)
        //        {
        //            SetValue(rowIndex, constrainedValue);
        //        }
        //    }
        //    Debug.Assert(this._minDate == value);
        //    if (OwnsEditingCalendar(rowIndex))
        //    {
        //        EditingLookup.MinDate = value;
        //    }
        //}
        //#endregion

        //#region private void OnCommonChange()
        //private void OnCommonChange()
        //{
        //    if (DataGridView != null && !DataGridView.IsDisposed && !DataGridView.Disposing)
        //    {
        //        if (RowIndex == -1)
        //        {
        //            // Invalidate and autosize column
        //            DataGridView.InvalidateColumn(ColumnIndex);

        //            // TODO: Add code to autosize the cell's column, the rows, the column headers 
        //            // and the row headers depending on their autosize settings.
        //            // The DataGridView control does not expose a public method that takes care of this.
        //        }
        //        else
        //        {
        //            // The DataGridView control exposes a public method called UpdateCellValue
        //            // that invalidates the cell so that it gets repainted and also triggers all
        //            // the necessary autosizing: the cell's column and/or row, the column headers
        //            // and the row headers are autosized depending on their autosize settings.
        //            DataGridView.UpdateCellValue(ColumnIndex, RowIndex);
        //        }
        //    }
        //}
        //#endregion

        //#region private bool OwnsEditingCalendar(int rowIndex)
        ///// <summary>
        ///// Определяет, показан ли для данной ячейки с заданным номером строки редактирующий контрол или нет
        ///// Индеск строки необходим, потому что ячейка может быть общей для нескольких строк
        ///// </summary>
        //private bool OwnsEditingCalendar(int rowIndex)
        //{
        //    if (rowIndex == -1 || this.DataGridView == null)
        //    {
        //        return false;
        //    }
        //    DataGridViewLookupEditingControl lookupEditingControl = DataGridView.EditingControl as DataGridViewLookupEditingControl;
        //    return lookupEditingControl != null && rowIndex == ((IDataGridViewEditingControl)lookupEditingControl).EditingControlRowIndex;
        //}
        //#endregion

        /// <summary>
        /// Clones a DataGridViewNumericUpDownCell cell, copies all the custom properties.
        /// </summary>
        public override object Clone()
        {
            DataGridViewLookupCell dataGridViewCell = base.Clone() as DataGridViewLookupCell;
            if (dataGridViewCell != null)
            {
                dataGridViewCell.Type = _viewedType;
            }
            return dataGridViewCell;
        }

        ///// <summary>
        ///// DetachEditingControl gets called by the DataGridView control when the editing session is ending
        ///// </summary>
        //[EditorBrowsable(EditorBrowsableState.Advanced)]
        //public override void DetachEditingControl()
        //{
        //    DataGridView dataGridView = DataGridView;
        //    if (dataGridView == null || dataGridView.EditingControl == null)
        //    {
        //        throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
        //    }

        //    LookupCombobox lookupCombobox = dataGridView.EditingControl as LookupCombobox;
        //    if (lookupCombobox != null)
        //    {
        //        // Editing controls get recycled. Indeed, when a DataGridViewNumericUpDownCell cell gets edited
        //        // after another DataGridViewNumericUpDownCell cell, the same editing control gets reused for 
        //        // performance reasons (to avoid an unnecessary control destruction and creation). 
        //        // Here the undo buffer of the TextBox inside the NumericUpDown control gets cleared to avoid
        //        // interferences between the editing sessions.
        //        ComboBox textBox = lookupCombobox.Controls[1] as ComboBox;
        //        if (textBox != null)
        //        {
        //            textBox.ClearUndo();
        //        }
        //    }

        //    base.DetachEditingControl();
        //}

        #region private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
        /// <summary>
        /// Adjusts the location and size of the editing control given the alignment characteristics of the cell
        /// </summary>
        private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
        {
            // Add a 1 pixel padding on the left and right of the editing control
            editingControlBounds.X += 1;
            editingControlBounds.Width = Math.Max(0, editingControlBounds.Width - 2);

            // Adjust the vertical location of the editing control:
            int preferredHeight = cellStyle.Font.Height + 3;
            if (preferredHeight < editingControlBounds.Height)
            {
                switch (cellStyle.Alignment)
                {
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.MiddleCenter:
                    case DataGridViewContentAlignment.MiddleRight:
                        editingControlBounds.Y += (editingControlBounds.Height - preferredHeight) / 2;
                        break;
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.BottomRight:
                        editingControlBounds.Y += editingControlBounds.Height - preferredHeight;
                        break;
                }
            }

            return editingControlBounds;
        }
        #endregion

        #region protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
        /// <summary>
        /// Customized implementation of the GetErrorIconBounds function in order to draw the potential 
        /// error icon next to the up/down buttons and not on top of them.
        /// </summary>
        protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
        {
            const int buttonsWidth = 16;

            Rectangle errorIconBounds = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
            if (DataGridView.RightToLeft == RightToLeft.Yes)
            {
                errorIconBounds.X = errorIconBounds.Left + buttonsWidth;
            }
            else
            {
                errorIconBounds.X = errorIconBounds.Left - buttonsWidth;
            }
            return errorIconBounds;
        }
        #endregion

        /// <summary>
        /// Customized implementation of the GetFormattedValue function in order to include the decimal and thousand separator
        /// characters in the formatted representation of the cell value.
        /// </summary>
        protected override object GetFormattedValue(object value,
                                                    int rowIndex,
                                                    ref DataGridViewCellStyle cellStyle,
                                                    TypeConverter valueTypeConverter,
                                                    TypeConverter formattedValueTypeConverter,
                                                    DataGridViewDataErrorContexts context)
        {
            //return value;
            //By default, the base implementation converts the Decimal 1234.5 into the string "1234.5"
            object formattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
            //string formattedNumber = formattedValue as string;
            //if (!string.IsNullOrEmpty(formattedNumber) && value != null)
            //{
            //    Decimal unformattedDecimal = Convert.ToDecimal(value);
            //    Decimal formattedDecimal = Convert.ToDecimal(formattedNumber);
            //    if (unformattedDecimal == formattedDecimal)
            //    {
            //        return formattedDecimal;//.ToString((ThousandsSeparator ? "N" : "F") + DecimalPlaces);
            //    }
            //}
            return formattedValue;
        }

        #region protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)

        /// <summary>
        /// Custom implementation of the GetPreferredSize function. This implementation uses the preferred size of the base 
        /// DataGridViewTextBoxCell cell and adds room for the up/down buttons.
        /// </summary>
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            if (DataGridView == null)
            {
                return new Size(-1, -1);
            }

            Size preferredSize = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            if (constraintSize.Width == 0)
            {
                const int buttonsWidth = 16; // Account for the width of the up/down buttons.
                const int buttonMargin = 8;  // Account for some blank pixels between the text and buttons.
                preferredSize.Width += buttonsWidth + buttonMargin;
            }
            return preferredSize;
        }
        #endregion

        #region public override bool KeyEntersEditMode(KeyEventArgs e)
        /// <summary>
        /// Custom implementation of the KeyEntersEditMode function. This function is called by the DataGridView control
        /// to decide whether a keystroke must start an editing session or not. In this case, a new session is started when
        /// a digit or negative sign key is hit.
        /// </summary>
        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            Keys negativeSignKey = Keys.None;
            string negativeSignStr = numberFormatInfo.NegativeSign;
            if (!string.IsNullOrEmpty(negativeSignStr) && negativeSignStr.Length == 1)
            {
                negativeSignKey = (Keys)(VkKeyScan(negativeSignStr[0]));
            }

            if ((char.IsDigit((char)e.KeyCode) ||
                 (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
                 negativeSignKey == e.KeyCode ||
                 Keys.Subtract == e.KeyCode) &&
                !e.Shift && !e.Alt && !e.Control)
            {
                return true;
            }
            return false;
        }
        #endregion

        //#region private void OnCommonChange()
        ///// <summary>
        ///// Called when a cell characteristic that affects its rendering and/or preferred size has changed.
        ///// This implementation only takes care of repainting the cells. The DataGridView's autosizing methods
        ///// also need to be called in cases where some grid elements autosize.
        ///// </summary>
        //private void OnCommonChange()
        //{
        //    if (DataGridView != null && !DataGridView.IsDisposed && !DataGridView.Disposing)
        //    {
        //        if (RowIndex == -1)
        //        {
        //            // Invalidate and autosize column
        //            DataGridView.InvalidateColumn(ColumnIndex);

        //            // TODO: Add code to autosize the cell's column, the rows, the column headers 
        //            // and the row headers depending on their autosize settings.
        //            // The DataGridView control does not expose a public method that takes care of this.
        //        }
        //        else
        //        {
        //            // The DataGridView control exposes a public method called UpdateCellValue
        //            // that invalidates the cell so that it gets repainted and also triggers all
        //            // the necessary autosizing: the cell's column and/or row, the column headers
        //            // and the row headers are autosized depending on their autosize settings.
        //            DataGridView.UpdateCellValue(ColumnIndex, RowIndex);
        //        }
        //    }
        //}
        //#endregion

        ///// <summary>
        ///// Determines whether this cell, at the given row index, shows the grid's editing control or not.
        ///// The row index needs to be provided as a parameter because this cell may be shared among multiple rows.
        ///// </summary>
        //private bool OwnsEditingNumericUpDown(int rowIndex)
        //{
        //    if (rowIndex == -1 || this.DataGridView == null)
        //    {
        //        return false;
        //    }
        //    DataGridViewNumericUpDownEditingControl numericUpDownEditingControl = this.DataGridView.EditingControl as DataGridViewNumericUpDownEditingControl;
        //    return numericUpDownEditingControl != null && rowIndex == ((IDataGridViewEditingControl)numericUpDownEditingControl).EditingControlRowIndex;
        //}

        public override object ParseFormattedValue(object formattedValue,
                                                   DataGridViewCellStyle cellStyle,
                                                   TypeConverter formattedValueTypeConverter,
                                                   TypeConverter valueTypeConverter)
        {
            //return formattedValue;
            return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
        }

        #region protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        /// <summary>
        /// Custom paints the cell. The base implementation of the DataGridViewTextBoxCell type is called first,
        /// dropping the icon error and content foreground parts. Those two parts are painted by this custom implementation.
        /// In this sample, the non-edited NumericUpDown control is painted by using a call to Control.DrawToBitmap. This is
        /// an easy solution for painting controls but it's not necessarily the most performant. An alternative would be to paint
        /// the NumericUpDown control piece by piece (text and up/down buttons).
        /// </summary>
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
                                      object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (DataGridView == null)
            {
                return;
            }

            //string valueText = value != null ? value.ToString() : "";
            //string formattedValueText = formattedValue != null ? formattedValue.ToString() : "";
            // First paint the borders and background of the cell.
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle,
                       paintParts & ~(DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.ContentForeground));
            Point ptCurrentCell = DataGridView.CurrentCellAddress;
            bool cellCurrent = ptCurrentCell.X == ColumnIndex && ptCurrentCell.Y == rowIndex;
            bool cellEdited = cellCurrent && DataGridView.EditingControl != null;

            // If the cell is in editing mode, there is nothing else to paint
            if (!cellEdited)
            {
                if (PartPainted(paintParts, DataGridViewPaintParts.ContentForeground))
                {
                    // Paint a NumericUpDown control
                    // Take the borders into account
                    Rectangle borderWidths = BorderWidths(advancedBorderStyle);
                    Rectangle valBounds = cellBounds;
                    valBounds.Offset(borderWidths.X, borderWidths.Y);
                    valBounds.Width -= borderWidths.Right;
                    valBounds.Height -= borderWidths.Bottom;
                    // Also take the padding into account
                    if (cellStyle.Padding != Padding.Empty)
                    {
                        if (DataGridView.RightToLeft == RightToLeft.Yes)
                        {
                            valBounds.Offset(cellStyle.Padding.Right, cellStyle.Padding.Top);
                        }
                        else
                        {
                            valBounds.Offset(cellStyle.Padding.Left, cellStyle.Padding.Top);
                        }
                        valBounds.Width -= cellStyle.Padding.Horizontal;
                        valBounds.Height -= cellStyle.Padding.Vertical;
                    }
                    // Determine the NumericUpDown control location
                    valBounds = GetAdjustedEditingControlBounds(valBounds, cellStyle);

                    bool cellSelected = (cellState & DataGridViewElementStates.Selected) != 0;

                    if (_renderingBitmap.Width < valBounds.Width ||
                        _renderingBitmap.Height < valBounds.Height)
                    {
                        // The static bitmap is too small, a bigger one needs to be allocated.
                        _renderingBitmap.Dispose();
                        _renderingBitmap = new Bitmap(valBounds.Width, valBounds.Height);
                    }
                    // Make sure the NumericUpDown control is parented to a visible control
                    if (_paintingLookupCombobox.Parent == null || !_paintingLookupCombobox.Parent.Visible)
                    {
                        _paintingLookupCombobox.Parent = DataGridView;
                    }
                    // Set all the relevant properties
                    //if (_paintingLookupCombobox.Type == null)
                    //    _paintingLookupCombobox.Type = _viewedType;

                    BaseEntityObject baseEntityObject = formattedValue as BaseEntityObject;

                    _paintingLookupCombobox.Font = cellStyle.Font;
                    _paintingLookupCombobox.ForeColor = cellStyle.ForeColor;
                    _paintingLookupCombobox.Width = valBounds.Width;
                    _paintingLookupCombobox.Height = valBounds.Height;
                    _paintingLookupCombobox.RightToLeft = DataGridView.RightToLeft;
                    _paintingLookupCombobox.Location = new Point(0, -_paintingLookupCombobox.Height - 100);
                    _paintingLookupCombobox.Text = baseEntityObject != null ? baseEntityObject.ToString() : "";

                    Color backColor;
                    if (PartPainted(paintParts, DataGridViewPaintParts.SelectionBackground) && cellSelected)
                    {
                        backColor = cellStyle.SelectionBackColor;
                    }
                    else
                    {
                        backColor = cellStyle.BackColor;
                    }
                    if (PartPainted(paintParts, DataGridViewPaintParts.Background))
                    {
                        if (backColor.A < 255)
                        {
                            // The NumericUpDown control does not support transparent back colors
                            backColor = Color.FromArgb(255, backColor);
                        }
                        _paintingLookupCombobox.BackColor = backColor;
                    }
                    // Finally paint the NumericUpDown control
                    Rectangle srcRect = new Rectangle(0, 0, valBounds.Width, valBounds.Height);
                    if (srcRect.Width > 0 && srcRect.Height > 0)
                    {
                        _paintingLookupCombobox.DrawToBitmap(_renderingBitmap, srcRect);
                        graphics.DrawImage(_renderingBitmap, new Rectangle(valBounds.Location, valBounds.Size),
                                           srcRect, GraphicsUnit.Pixel);
                    }
                }
                if (PartPainted(paintParts, DataGridViewPaintParts.ErrorIcon))
                {
                    // Paint the potential error icon on top of the NumericUpDown control
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText,
                               cellStyle, advancedBorderStyle, DataGridViewPaintParts.ErrorIcon);
                }
            }
        }
        #endregion

        #region private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        /// <summary>
        /// Little utility function called by the Paint function to see if a particular part needs to be painted. 
        /// </summary>
        private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        {
            return (paintParts & paintPart) != 0;
        }
        #endregion

        #region public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        /// <summary>
        /// Custom implementation of the PositionEditingControl method called by the DataGridView control when it
        /// needs to relocate and/or resize the editing control.
        /// </summary>
        public override void PositionEditingControl(bool setLocation,
                                            bool setSize,
                                            Rectangle cellBounds,
                                            Rectangle cellClip,
                                            DataGridViewCellStyle cellStyle,
                                            bool singleVerticalBorderAdded,
                                            bool singleHorizontalBorderAdded,
                                            bool isFirstDisplayedColumn,
                                            bool isFirstDisplayedRow)
        {
            Rectangle editingControlBounds = PositionEditingPanel(cellBounds,
                                                        cellClip,
                                                        cellStyle,
                                                        singleVerticalBorderAdded,
                                                        singleHorizontalBorderAdded,
                                                        isFirstDisplayedColumn,
                                                        isFirstDisplayedRow);
            editingControlBounds = GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
            DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
            DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Returns a standard textual representation of the cell.
        /// </summary>
        public override string ToString()
        {
            return "DataGridViewLookupCell { ColumnIndex=" + ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
        }
        #endregion

        #endregion
    }
}
