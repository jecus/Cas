using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CASTerms;
using Microsoft.Office.Interop.Excel;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using Font = System.Drawing.Font;
using Label = System.Windows.Forms.Label;
using Point = System.Drawing.Point;

namespace CAS.UI.UIControls.Auxiliary.Importing
{
    public partial class ExcelImportFileControl : UserControl
    {
        #region Fields

        private Type _typeToImport;
        private Workbook _workbook;
        private _Worksheet _worksheet;

        #endregion

        #region Properties

        public Type TypeToImport
        {
            get { return _typeToImport; }
            set
            {
                _typeToImport = value;
                UpdateControl();
            }
        }

        public _Workbook Workbook
        {
            get { return _workbook; }
        }

        public _Worksheet Worksheet
        {
            get { return _worksheet; }
        }
        #endregion

        #region Constructors

        #region public ExcelImportFileControl()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        public ExcelImportFileControl()
        {
            InitializeComponent();
        }

        #endregion

        #region public ExcelImportFileControl(Type typeToImport) : this()
        /// <summary>
        /// Создает форму для редактирования переданного объекта
        /// </summary>
        public ExcelImportFileControl(Type typeToImport)
            : this()
        {
            if(typeToImport == null)
                throw new ArgumentNullException("typeToImport", "can not be null");
            _typeToImport = typeToImport;

            UpdateControl();
        }

        #endregion
        
        #endregion

        #region Methods

        #region protected List<PropertyInfo> GetTypeProperties(Type type)
        protected List<PropertyInfo> GetTypeProperties(Type type)
        {
            if (type == null) return null;
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                type.GetProperties().Where(p => p.GetCustomAttributes(typeof(ExcelImportAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                ExcelImportAttribute lvda = (ExcelImportAttribute)
                    propertyInfo.GetCustomAttributes(typeof(ExcelImportAttribute), false).FirstOrDefault();
                if (lvda.Order > 0) orderedProperties.Add(lvda.Order, propertyInfo);
                else unOrderedProperties.Add(propertyInfo);
            }

            var ordered = orderedProperties.OrderBy(p => p.Key).ToList();

            properties.Clear();
            properties.AddRange(ordered.Select(keyValuePair => keyValuePair.Value));
            properties.AddRange(unOrderedProperties);

            return properties;

        }
        #endregion

        #region private Control GetControl(BaseEntityObject obj, PropertyInfo propertyInfo, int controlWidth)
        private Control GetControl(PropertyInfo propertyInfo,
                                   int controlWidth,
                                   bool controlEnabled)
        {

            #region ЭУ для StaticDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(StaticDictionary)))
            {
                ComboBox nc = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList, 
                    Enabled = controlEnabled, 
                    Tag = propertyInfo, 
                    Width = controlWidth
                };
                return nc;
            }
            #endregion

            #region  ЭУ для AbstractDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
            {
                ComboBox nc = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Enabled = controlEnabled,
                    Tag = propertyInfo,
                    Width = controlWidth
                };
                return nc;
            }
            #endregion

            #region ЭУ для BaseEntityObject

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
            {
                ComboBox nc = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Enabled = controlEnabled,
                    Tag = propertyInfo,
                    Width = controlWidth
                };
                return nc;
            }
            #endregion

            #region ЭУ для Enum

            if (propertyInfo.PropertyType.IsEnum)
            {
                ComboBox nc = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Enabled = controlEnabled,
                    Tag = propertyInfo,
                    Width = controlWidth
                };
                return nc;
            }
            #endregion

            #region  ЭУ для базовых типов

            string typeName = propertyInfo.PropertyType.Name.ToLower();
            switch (typeName)
            {
                case "string":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "int32":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "int16":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "datetime":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "bool":
                case "boolean":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "double":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "directivethreshold":
                    {
                        return new ImportDirectiveThresholdControl { Enabled = controlEnabled, Tag = propertyInfo };
                    }
                //case "detaildirectivethreshold":
                //    {
                //        //object val = propertyInfo.GetValue(obj, null);
                //        //return new DetailDirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DetailDirectiveThreshold)val, Tag = propertyInfo };
                //    }
                case "lifelength":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                case "timespan":
                    {
                        ComboBox nc = new ComboBox
                        {
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Enabled = controlEnabled,
                            Tag = propertyInfo,
                            Width = controlWidth
                        };
                        return nc;
                    }
                default:
                    return null;
            }
            #endregion
            return null;
        }
        #endregion

        #region protected virtual bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidateData(out string message)
        {
            message = "";
            foreach (Control control in panelControls.Controls)
            {
                if (control is ThresholdControl)
                {
                    return ((ThresholdControl)control).ValidateData();
                }
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    NotNullAttribute notNullAttribute =
                        (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();

                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (controlVal == null && notNullAttribute != null)
                    {
                        if (message != "") message += "\n ";
                        ExcelImportAttribute fca = (ExcelImportAttribute)
                            propertyInfo.GetCustomAttributes(typeof(ExcelImportAttribute), false).First();
                        message += $"'{fca.Title}' should not be empty";
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region protected virtual void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        protected virtual void ApplyChanges()
        {
            foreach (Control control in panelControls.Controls)
            {
                if (control is ThresholdControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_typeToImport, null);
                    object controlVal = ((ThresholdControl)control).Threshold;
                    if (val.ToString() != controlVal.ToString())
                        propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_typeToImport, null);
                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_typeToImport, null);
                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
            }
        }
        #endregion

        #region private void UpdateControl(object sender, RunWorkerCompletedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        protected void UpdateControl()
        {
            Text = $"{_typeToImport.Name} Import Form";

            panelControls.Controls.Clear();

            if (_typeToImport == null) return;

            List<PropertyInfo> properties = GetTypeProperties(_typeToImport);

            if (properties.Count == 0) return;

            int columnCount = 1;//количество колонок ЭУ

            List<Label> labels = new List<Label>();
            List<Control> controls = new List<Control>();
            Dictionary<PropertyInfo, Control> pairControls= new Dictionary<PropertyInfo, Control>();
            string errorMessage = "";
            foreach (PropertyInfo t in properties)
            {
                PropertyInfo pairProperty = null;
                ExcelImportAttribute attr =
                    (ExcelImportAttribute)t.GetCustomAttributes(typeof(ExcelImportAttribute), false).First();
                labels.Add(new Label { Text = attr.Title, AutoSize = true });

                //Если значение должно быть не пустым или не NULL
                //то шрифт леибла утснанавливается в ЖИРНЫЙ(BOLD)
                NotNullAttribute notNullAttribute =
                    (NotNullAttribute)t.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                if (notNullAttribute != null)
                    labels.Last().Font = new Font(labels.Last().Font, FontStyle.Bold);

                Control c = null;
                if (!string.IsNullOrEmpty(attr.PairControlPropertyName))
                    pairProperty = _typeToImport.GetProperty(attr.PairControlPropertyName);

                if (pairProperty != null)
                {
                    try
                    {
                        c = GetControl(pairProperty, attr.PairControlWidht, attr.PairControlEnabled);
                    }
                    catch (Exception ex)
                    {
                        if (errorMessage != "") errorMessage += "\n ";
                        errorMessage += $"Pair property '{attr.PairControlPropertyName}' raise error {ex.Message}";
                    }
                    if (c is ThresholdControl) columnCount = 2;
                    pairControls.Add(t, c);
                }

                c = null;

                try
                {
                    int cw = pairProperty != null ? attr.Width - attr.PairControlWidht - 5 : attr.Width;
                    c = GetControl(t, cw, true);   
                }
                catch (Exception ex)
                {
                    if (errorMessage != "") 
                        errorMessage += "\n ";
                    errorMessage += $"'{attr.Title}' raise error {ex.Message}";
                }
                if (c is LifelengthViewer) ((LifelengthViewer)c).LeftHeader = attr.Title;
                if (c is ThresholdControl) columnCount = 2;
                controls.Add(c);
            }

            #region Компоновка контролов в одну колонку
            if (columnCount == 1)
            {
                #region расчет длины лейблов и контролов

                int maxLabelXSize = 0;
                int maxControlXSize = 0;//максимальная длиня ЭУ
                for (int i = 0; i < labels.Count; i++)
                {
                    //на каждый лейбл приходится по одному контролу, 
                    //поэтому обе коллекции просматриваются одновременно
                    if (controls[i] != null && controls[i] is LifelengthViewer)
                    {
                        LifelengthViewer llv = (LifelengthViewer)controls[i];
                        if (llv.LeftHeaderWidth > maxLabelXSize)
                            maxLabelXSize = llv.LeftHeaderWidth;
                        if (llv.WidthWithoutLeftHeader > maxControlXSize)
                            maxControlXSize = llv.WidthWithoutLeftHeader;
                        if (i > 0 && controls[i - 1] != null && controls[i - 1] is LifelengthViewer)
                            llv.ShowHeaders = false;
                        continue;
                    }
                    //выше рассматривались контролы, имеющие собственные лейблы
                    //теперь идет просмотр самих леблов
                    if (labels[i].PreferredWidth > maxLabelXSize)
                        maxLabelXSize = labels[i].PreferredWidth;
                    //размеры контролов
                    if (controls[i] != null && controls[i].Size.Width > maxControlXSize)
                    {
                        maxControlXSize = controls[i].Size.Width;
                    }
                }
                #endregion

                for (int i = 0; i < properties.Count; i++)
                {
                    Control pairControl = null;
                    if (pairControls.ContainsKey(properties[i]))
                        pairControl = pairControls[properties[i]];

                    if (i == 0)
                    {
                        labels[i].Location = new Point(3, 3);
                        if (controls[i] != null)
                        {
                            if (controls[i] is LifelengthViewer)
                            {
                                controls[i].Location =
                                    new Point((maxLabelXSize + labels[i].Location.X) - ((LifelengthViewer)controls[i]).LeftHeaderWidth, 3);
                            }
                            else
                            {
                                if (pairControl != null)
                                {
                                    pairControl.Location = new Point(maxLabelXSize + labels[i].Location.X + 5, 3);

                                    controls[i].Location = new Point(pairControl.Location.X + pairControl.Size.Width + 5, 3);
                                    controls[i].Width = maxControlXSize - (pairControl.Size.Width + 5);
                                }
                                else
                                {
                                    controls[i].Location = new Point(maxLabelXSize + labels[i].Location.X + 5, 3);
                                    controls[i].Width = maxControlXSize;
                                }
                            }
                        }
                    }
                    else
                    {
                        Point labelLocation = new Point(3, 0);
                        if (controls[i - 1] != null)
                            labelLocation.Y = controls[i - 1].Location.Y + controls[i - 1].Size.Height + 5;
                        else labelLocation.Y = labels[i - 1].Location.Y + labels[i - 1].Size.Height + 5;

                        labels[i].Location = labelLocation;
                        if (controls[i] != null)
                        {
                            if (controls[i] is LifelengthViewer)
                            {
                                controls[i].Location =
                                    new Point((maxLabelXSize + labelLocation.X) - ((LifelengthViewer)controls[i]).LeftHeaderWidth, labelLocation.Y);
                            }
                            else
                            {
                                if (pairControl != null)
                                {
                                    pairControl.Location = new Point(maxLabelXSize + labelLocation.X + 5, labelLocation.Y);

                                    controls[i].Location = new Point(pairControl.Location.X + pairControl.Size.Width + 5, labelLocation.Y);
                                    controls[i].Width = maxControlXSize - (pairControl.Size.Width + 5);
                                }
                                else
                                {
                                    controls[i].Location = new Point(maxLabelXSize + labelLocation.X + 5, labelLocation.Y);
                                    controls[i].Width = maxControlXSize;
                                }
                            }
                        }
                    }


                    if (controls[i] == null || (controls[i] != null && !(controls[i] is LifelengthViewer)))
                    {
                        //Если контрол не является LifelengthViewer-ом то нужно добавить лейбл
                        panelControls.Controls.Add(labels[i]);
                    }
                    if (pairControl != null)
                        panelControls.Controls.Add(pairControl);

                    panelControls.Controls.Add(controls[i]);
                }
            }
            #endregion

            #region Компоновка контролов в две колонки
            if (columnCount == 2)
            {
                #region расчет длины лейблов и контролов

                int fMaxLabelXSize = 0, sMaxLabelXSize = 0;
                int fMaxControlXSize = 0, sMaxControlXSize = 0;
                bool checkFirst = true;//флаг проверяемой колонки

                for (int i = 0; i < labels.Count; i++)
                {
                    //на каждый лейбл приходится по одному контролу, 
                    //поэтому обе коллекции просматриваются одновременно
                    if (controls[i] != null && controls[i] is ThresholdControl)
                    {
                        //контрол порога выполнения директивы
                        //влияет на длину лейблов обоих колонок
                        ThresholdControl ddtc = (ThresholdControl)controls[i];
                        //размеры заголовков
                        if (ddtc.MaxFirstColLabelWidth > fMaxLabelXSize)
                            fMaxLabelXSize = ddtc.MaxFirstColLabelWidth;
                        if (ddtc.MaxSecondColLabelWidth > sMaxLabelXSize)
                            sMaxLabelXSize = ddtc.MaxSecondColLabelWidth;

                        //размеры контролов
                        if (ddtc.MaxFirstColControlWidth > fMaxControlXSize)
                            fMaxControlXSize = ddtc.MaxFirstColControlWidth;
                        if (ddtc.MaxSecondColControlWidth > sMaxControlXSize)
                            sMaxControlXSize = ddtc.MaxSecondColControlWidth;

                        //т.к. DetailDirectiveThresholdControl занимает 2 колонки, 
                        //то следующий контрол всегда будет располагаться в первой колонке
                        checkFirst = true;
                        continue;
                    }

                    if (controls[i] != null && controls[i] is LifelengthViewer)
                    {
                        LifelengthViewer llv = (LifelengthViewer)controls[i];

                        if (checkFirst && llv.LeftHeaderWidth > fMaxLabelXSize)
                            fMaxLabelXSize = llv.LeftHeaderWidth;
                        if (!checkFirst && llv.LeftHeaderWidth > sMaxLabelXSize)
                            sMaxLabelXSize = llv.LeftHeaderWidth;

                        //размеры контролов
                        if (checkFirst && llv.WidthWithoutLeftHeader > fMaxControlXSize)
                            fMaxControlXSize = llv.WidthWithoutLeftHeader;
                        if (!checkFirst && llv.WidthWithoutLeftHeader > sMaxControlXSize)
                            sMaxControlXSize = llv.WidthWithoutLeftHeader;

                        checkFirst = !checkFirst;
                        continue;
                    }

                    //выше рассматривались контролы, имеющие собственные лейблы
                    //теперь идет просмотр самих леблов
                    if (checkFirst && labels[i].PreferredWidth > fMaxLabelXSize)
                        fMaxLabelXSize = labels[i].PreferredWidth;
                    if (!checkFirst && labels[i].PreferredWidth > sMaxLabelXSize)
                        sMaxLabelXSize = labels[i].PreferredWidth;

                    //размеры контролов
                    if (controls[i] != null)
                    {
                        if (checkFirst && controls[i].Size.Width > fMaxControlXSize)
                            fMaxControlXSize = controls[i].Size.Width;
                        if (!checkFirst && controls[i].Size.Width > sMaxControlXSize)
                            sMaxControlXSize = controls[i].Size.Width;
                    }

                    checkFirst = !checkFirst;
                }
                #endregion

                checkFirst = true;
                const int firstCol = 3;
                int secondCol = (3 + fMaxLabelXSize + 5 + fMaxControlXSize + 50);
                for (int i = 0; i < labels.Count; i++)
                {
                    int top, left, labelSize, controlsize;
                    if (i == 0)
                    {
                        top = 3;
                        left = firstCol;
                        labelSize = fMaxLabelXSize;
                        controlsize = fMaxControlXSize;
                    }
                    else
                    {
                        if (checkFirst
                            || (controls[i] != null && controls[i] is ThresholdControl))
                        {
                            left = firstCol;
                            labelSize = fMaxLabelXSize;
                            controlsize = fMaxControlXSize;

                            //определение самого нижнего Bottoma 2-х предыдущих контролов
                            int bottom1, bottom2;
                            //определение нижней точки предыдущего контрола 
                            //(он будет либо во второй колонке предыдущего ряда, либо занимать весь ряд)
                            if (controls[i - 1] != null)
                                bottom2 = controls[i - 1].Bottom + 5;
                            else bottom2 = labels[i - 1].Bottom + 5;
                            //определение нижней точки пред-предыдущего контрола
                            //он может и отсутствовать
                            if ((i - 2) >= 0)
                            {
                                if (controls[i - 2] != null)
                                    bottom1 = controls[i - 2].Bottom + 5;
                                else bottom1 = labels[i - 2].Bottom + 5;
                            }
                            else bottom1 = 0;

                            top = bottom1 > bottom2 ? bottom1 : bottom2;
                        }
                        else
                        {
                            left = secondCol;
                            labelSize = sMaxLabelXSize;
                            controlsize = sMaxControlXSize;

                            top = controls[i - 1] != null ? controls[i - 1].Location.Y : labels[i - 1].Location.Y;
                        }
                    }

                    if (controls[i] != null && controls[i] is ThresholdControl)
                    {
                        ThresholdControl ddtc = (ThresholdControl)controls[i];
                        controls[i].Location = new Point(3, top);
                        //выравнивание первой колонки
                        ddtc.SetFirstColumnPos(firstCol + fMaxLabelXSize);
                        //выравнивание второй колонки
                        ddtc.SetSecondColumnPos(secondCol + sMaxLabelXSize);

                        panelControls.Controls.Add(controls[i]);
                        checkFirst = true;
                        continue;
                    }

                    if (controls[i] != null && controls[i] is LifelengthViewer)
                    {
                        controls[i].Location =
                            new Point((labelSize + left) - ((LifelengthViewer)controls[i]).LeftHeaderWidth, top);
                        panelControls.Controls.Add(controls[i]);
                        checkFirst = !checkFirst;
                        continue;
                    }

                    labels[i].Location = new Point(left, top);
                    if (controls[i] != null)
                    {
                        controls[i].Location = new Point(labelSize + left + 5, top);
                        controls[i].Width = controlsize;
                    }
                    panelControls.Controls.Add(labels[i]);
                    panelControls.Controls.Add(controls[i]);
                    checkFirst = !checkFirst;
                }
            }
            #endregion

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region private void UpdateComboboxes()
        private void UpdateComboboxes()
        {
            if (_worksheet == null)
            {
                foreach (Control control in panelControls.Controls)
                {
                    if (control is ComboBox)
                    {
                        ComboBox combo = (ComboBox)control;
                        combo.Items.Clear();
                    }
                }
            }
            else
            {
                List<KeyValuePair<string, Range>> columnHeaders = new List<KeyValuePair<string, Range>>();
                if (checkBoxHeaders.Checked)
                {
                    for (int i = 1; i <= _worksheet.Columns.Count; i++)
                    {
                        //columnHeaders.Add(new KeyValuePair<string, Range>(_worksheet.Cells[1, i] + "(" + _worksheet.Columns[i] + ")", _worksheet.Columns[i] as Range));
                        //columnHeaders.Add(new KeyValuePair<string, Range>(_worksheet.Columns[i], _worksheet.Columns[i] as Range));
                    }
                }
                else
                {
                    for (int i = 1; i <= _worksheet.Columns.Count; i++)
                    {
                        //columnHeaders.Add(new KeyValuePair<string, Range>(_worksheet.Columns[i], _worksheet.Columns[i] as Range));
                    }
                }
                foreach (Control control in panelControls.Controls)
                {
                    if (control is ComboBox)
                    {
                        ComboBox combo = (ComboBox)control;
                        combo.Items.Clear();

                        combo.DisplayMember = "Key";
                        combo.ValueMember = "Value";
                        combo.DataSource = columnHeaders;
                    }
                }
            }
        }
        #endregion

        #region private void ButtonBrowseClick(object sender, EventArgs e)
        private void ButtonBrowseClick(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog { Filter = "Excel (*.XLS)|*.XLS" };
            if (opf.ShowDialog() != DialogResult.OK)
                return;

            string filename = opf.FileName;
            textBoxFile.Text = filename;

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            _Workbook excelWorkBook =
                excelApp.Workbooks.Open(filename, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false,
                                        false, 0, true, 1, 0);
            comboBoxSheets.Items.Clear();
            List<KeyValuePair<string, Worksheet>> sheets = new List<KeyValuePair<string, Worksheet>>();
            foreach (Worksheet ws in excelWorkBook.Worksheets)
            {
                sheets.Add(new KeyValuePair<string, Worksheet>(ws.Name, ws));
            }
            comboBoxSheets.DisplayMember = "Key";
            comboBoxSheets.ValueMember = "Value";
            comboBoxSheets.DataSource = sheets;

            excelWorkBook.Close(true, null, null);
            excelApp.Quit();

            releaseObject(excelWorkBook);
            releaseObject(excelApp);
        }
        #endregion

        #region private void ComboBoxSheetsSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxSheetsSelectedIndexChanged(object sender, EventArgs e)
        {
            _worksheet = comboBoxSheets.SelectedValue as _Worksheet;

            UpdateComboboxes();
        }
        #endregion

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex);
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
    }
}
