using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace CAS.UI.UIControls.Auxiliary.Importing
{
    /// <summary>
    /// Общая Форма для редактирования объектов
    /// </summary>
    public partial class CommonExcelImportForm : MetroForm
    {
        #region Fields

        private bool _saveChangesToDatabase;
        private Type _typeToImport;
        private List<Control> _importingControls = new List<Control>(); 
        private ExcelImportFileControl _excelImportFileControl = new ExcelImportFileControl();

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        #endregion

        #region Constructors

        #region public CommonExcelImportForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        public CommonExcelImportForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public CommonExcelImportForm(Type typeToImport, bool saveChangesToDatabase = true) : this()
        /// <summary>
        /// Создает форму для редактирования переданного объекта
        /// </summary>
        public CommonExcelImportForm(Type typeToImport, bool saveChangesToDatabase = true)
            : this()
        {
            if(typeToImport == null)
                throw new ArgumentNullException("typeToImport", "can not be null");
            _typeToImport = typeToImport;
            _saveChangesToDatabase = saveChangesToDatabase;

            _importingControls.Clear();
            _importingControls.Add(_excelImportFileControl);

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion
     
        #endregion

        #region Properties

        /////<summary>
        ///// Возвращает редактируемый объект
        /////</summary>
        //public BaseEntityObject CurrentObject
        //{
        //    get { return _typeToImport; }
        //}
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
        private Control GetControl(BaseEntityObject obj, 
                                   PropertyInfo propertyInfo, 
                                   int controlWidth, 
                                   bool controlEnabled)
        {

            #region ЭУ для прикрепленного файла

            if (propertyInfo.PropertyType.Name == nameof(AttachedFile) ||
                propertyInfo.PropertyType.IsSubclassOf(typeof(AttachedFile)))
            {
                object val = propertyInfo.GetValue(obj, null);
                return new AttachedFileControl
                {
                    AttachedFile = (AttachedFile)val,
                    Enabled = controlEnabled,
                    Filter = "PDF file (*.pdf)|*.pdf",
                    Icon = Properties.Resources.PDFIconSmall,
                    MaximumSize = new Size(350, 100),
                    Size = new Size(350, 75),
                    Tag = propertyInfo
                };
            }
            #endregion

            #region ЭУ для StaticDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(StaticDictionary)))
            {
                object val = propertyInfo.GetValue(obj, null);

                if(propertyInfo.PropertyType.GetCustomAttributes(typeof(TableAttribute),false).Length > 0)
                {
                    DictionaryComboBox dc = new DictionaryComboBox
                    {
                        Enabled = controlEnabled,
                        Name = propertyInfo.Name,
                        SelectedItem = (StaticDictionary)val,
                        Tag = propertyInfo,
                        Type = propertyInfo.PropertyType,
                    };
                    //для возможности вызова новой вкладки
                    Program.MainDispatcher.ProcessControl(dc);
                    //
                    return dc;    
                }
                ComboBox nc = new ComboBox
                                  {
                                      Enabled = controlEnabled,
                                      Tag = propertyInfo,
                                      Width = controlWidth,
                                  };

                //поиск своиства Items у типа StaticDictionary
                Type t = propertyInfo.PropertyType;
                PropertyInfo p = t.GetProperty("Items");

                ConstructorInfo ci = t.GetConstructor(new Type[0]);
                StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                IEnumerable staticList = (IEnumerable)p.GetValue(instance, null);

                foreach (StaticDictionary o in staticList)
                    nc.Items.Add(o);
                nc.SelectedItem = val;
                return nc;
            }
            #endregion

            #region  ЭУ для AbstractDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
            {
                AbstractDictionary val = (AbstractDictionary)propertyInfo.GetValue(obj, null);
                DictionaryComboBox dc = new DictionaryComboBox
                {
                    Enabled = controlEnabled,
                    SelectedItem = val,
                    Tag = propertyInfo,
                    Type = propertyInfo.PropertyType,
                };
                //для возможности вызова новой вкладки
                Program.MainDispatcher.ProcessControl(dc);
                //
                return dc;
            }
            #endregion

            #region ЭУ для BaseEntityObject

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
            {
                object val = propertyInfo.GetValue(obj, null);
                TextBox tb = new TextBox
                {
                    AutoSize = true,
                    Enabled = controlEnabled,
                    Tag = propertyInfo,
                    Text = val != null ? val.ToString() : "",
                    Width = controlWidth,
                };
                return tb;
            }
            #endregion

            #region ЭУ для Enum

            if (propertyInfo.PropertyType.IsEnum)
            {
                object val = propertyInfo.GetValue(obj, null);
                if (propertyInfo.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                {
                    CommonFlagsControl cfc = new CommonFlagsControl
                    {
                        Enabled = controlEnabled,
                        SourceEnum = propertyInfo.PropertyType,
                        Tag = propertyInfo
                    };
                    return cfc;
                }
                ComboBox nc = new ComboBox { Enabled = controlEnabled, Tag = propertyInfo };
                foreach (object o in Enum.GetValues(propertyInfo.PropertyType))
                    nc.Items.Add(o);
                nc.SelectedItem = val;
                return nc;
            }
            #endregion

            //#region  ЭУ для базовых типов

            //string typeName = propertyInfo.PropertyType.Name.ToLower();
            //switch (typeName)
            //{
            //    case "string":
            //        {
            //            string val = (string)propertyInfo.GetValue(obj, null);
            //            Control control;
            //            if (richTextBox)
            //            {
            //                RichTextBox richText = new RichTextBox
            //                {
            //                    AutoSize = true,
            //                    Enabled = controlEnabled,
            //                    MinimumSize = new Size(20, 17),
            //                    Multiline = controlLines > 1,
            //                    Tag = propertyInfo,
            //                    Width = controlWidth,
            //                };
            //                try
            //                {
            //                    richText.Rtf = val;
            //                }
            //                catch (Exception)
            //                {
            //                    richText.Text = val;
            //                }
            //                if (controlLines > 1)
            //                {
            //                    richText.ScrollBars = RichTextBoxScrollBars.Both;
            //                    richText.Height = richText.Font.Height * controlLines + 7;
            //                }
            //                control = richText;
            //            }
            //            else
            //            {
            //                TextBox textBox = new TextBox
            //                {
            //                    AutoSize = true,
            //                    Enabled = controlEnabled,
            //                    MinimumSize = new Size(20, 17),
            //                    Multiline = controlLines > 1,
            //                    Tag = propertyInfo,
            //                    Text = val,
            //                    Width = controlWidth,
            //                };
            //                if (controlLines > 1)
            //                {
            //                    textBox.ScrollBars = ScrollBars.Vertical;
            //                    textBox.Height = textBox.Font.Height * controlLines + 7;
            //                }
            //                control = textBox;
            //            }
            //            return control;
            //        }
            //    case "int32":
            //        {
            //            Int32 val = (Int32)propertyInfo.GetValue(obj, null);
            //            MinMaxValueAttribute mmValue =
            //                (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
            //            NumericUpDown nud = new NumericUpDown();
            //            if (mmValue != null)
            //            {
            //                nud.Maximum = (decimal)mmValue.Max;
            //                nud.Minimum = (decimal)mmValue.Min;

            //                if (val < (Int32)mmValue.Min) val = (Int32)mmValue.Min;
            //                if (val > (Int32)mmValue.Max) val = (Int32)mmValue.Max;
            //            }
            //            nud.Enabled = controlEnabled;
            //            nud.Value = val;
            //            nud.DecimalPlaces = 0;
            //            nud.MinimumSize = new Size(20, 17);
            //            nud.Tag = propertyInfo;

            //            return nud;
            //        }
            //    case "int16":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            MinMaxValueAttribute mmValue =
            //                (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
            //            NumericUpDown nud = new NumericUpDown();
            //            if (mmValue != null)
            //            {
            //                nud.Maximum = (decimal)mmValue.Max;
            //                nud.Minimum = (decimal)mmValue.Min;
            //            }
            //            nud.Enabled = controlEnabled;
            //            nud.Value = (Int16)val;
            //            nud.DecimalPlaces = 0;
            //            nud.MinimumSize = new Size(20, 17);
            //            nud.Tag = propertyInfo;

            //            return nud;
            //        }
            //    case "datetime":
            //        {
            //            DateTime val = (DateTime)propertyInfo.GetValue(obj, null);
            //            return new DateTimePicker
            //            {
            //                Enabled = controlEnabled,
            //                MinDate = new DateTime(1950,1,1),
            //                MinimumSize = new Size(20, 17),
            //                //AutoSize = true,
            //                Tag = propertyInfo,
            //                Value = val > DateTimePicker.MinimumDateTime ? new DateTime(val.Ticks) : DateTimePicker.MinimumDateTime
            //            };
            //        }
            //    case "bool":
            //    case "boolean":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            return new CheckBox
            //            {
            //                Checked = (bool)val,
            //                Enabled = controlEnabled,
            //                MinimumSize = new Size(20, 17),
            //                //AutoSize = true,
            //                Tag = propertyInfo
            //            };
            //        }
            //    case "double":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            MinMaxValueAttribute mmValue =
            //                (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
            //            NumericUpDown nud = new NumericUpDown();
            //            if (mmValue != null)
            //            {
            //                nud.Maximum = (decimal)mmValue.Max;
            //                nud.Minimum = (decimal)mmValue.Min;
            //            }
            //            nud.Enabled = controlEnabled;
            //            nud.Value = (decimal) (double) val;
            //            nud.DecimalPlaces = 2;
            //            nud.MinimumSize = new Size(20, 17);
            //            nud.Tag = propertyInfo;
                        
            //            return nud;
            //        }
            //    case "directivethreshold":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            return new DirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DirectiveThreshold)val, Tag = propertyInfo };
            //        }
            //    case "detaildirectivethreshold":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            return new DetailDirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DetailDirectiveThreshold)val, Tag = propertyInfo };
            //        }
            //    case "lifelength":
            //        {
            //            object val = propertyInfo.GetValue(obj, null);
            //            return new LifelengthViewer
            //            {
            //                Enabled = controlEnabled,
            //                Lifelength = (Lifelength) val,
            //                MinimumSize = new Size(20, 17),
            //                Tag = propertyInfo
            //            };
            //        }
            //    case "timespan":
            //        {
            //            TimeSpan val = (TimeSpan)propertyInfo.GetValue(obj, null);
            //            return new DateTimePicker
            //            {
            //                CustomFormat = "HH:mm",
            //                Enabled = controlEnabled,
            //                Format = DateTimePickerFormat.Custom,
            //                MinDate = new DateTime(1950, 1, 1),
            //                MinimumSize = new Size(20, 17),
            //                //AutoSize = true,
            //                ShowUpDown = true,
            //                Tag = propertyInfo,
            //                Value = DateTime.Today.Add(val)
            //            };
            //        }
            //    default:
            //        return null;
            //}
            //#endregion
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
            foreach (Control control in _importingControls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string controlVal = control.Text;

                    NotNullAttribute notNullAttribute =
                        (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                    if (controlVal == null || (notNullAttribute != null && controlVal.Trim() == ""))
                    {
                        if (message != "") message += "\n ";
                        ExcelImportAttribute fca = (ExcelImportAttribute)
                            propertyInfo.GetCustomAttributes(typeof (ExcelImportAttribute), false).First();
                        message += $"'{fca.Title}' should not be empty";
                        return false;
                    }
                }
                if (control is RichTextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") 
                        continue;

                    string controlVal = ((RichTextBox)control).Rtf;

                    NotNullAttribute notNullAttribute =
                        (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                    if (controlVal == null || (notNullAttribute != null && controlVal.Trim() == ""))
                    {
                        if (message != "") message += "\n ";
                        ExcelImportAttribute fca = (ExcelImportAttribute)
                            propertyInfo.GetCustomAttributes(typeof(ExcelImportAttribute), false).First();
                        message += $"'{fca.Title}' should not be empty";
                        return false;
                    }
                }
                //if (control is NumericUpDown && control.Tag != null)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    string typeName = propertyInfo.PropertyType.Name.ToLower();
                //    switch (typeName)
                //    {
                //        case "int32":
                //            {
                //                int val = (int)propertyInfo.GetValue(obj, null);
                //                int controlVal = (int)((NumericUpDown)control).Value;
                //                if (val != controlVal)
                //                    return true;

                //                break;
                //            }
                //        case "int16":
                //            {
                //                Int16 val = (Int16)propertyInfo.GetValue(obj, null);
                //                Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                //                if (val != controlVal)
                //                    return true;

                //                break;
                //            }
                //        case "double":
                //            {
                //                double val = (double)propertyInfo.GetValue(obj, null);
                //                double controlVal = (double)((NumericUpDown)control).Value;
                //                if (val != controlVal)
                //                    return true;

                //                break;
                //            }
                //    }
                //}
                //if (control is DateTimePicker)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    DateTime val = (DateTime)propertyInfo.GetValue(obj, null);
                //    if (val != ((DateTimePicker)control).Value)
                //        return true;
                //}
                //if (control is CheckBox)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    bool val = (bool)propertyInfo.GetValue(obj, null);
                //    bool controlVal = ((CheckBox)control).Checked;
                //    if (val != controlVal)
                //        return true;
                //}
                if (control is AttachedFileControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    string m;
                    if (((AttachedFileControl)control).ValidateData(out m))
                        return true;
                    if (m != "") message += "\n ";

                    message += "Not set " + propertyInfo.Name;
                    return false;
                }
                //if (control is LifelengthViewer)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    Lifelength val = (Lifelength)propertyInfo.GetValue(obj, null);
                //    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                //    if (!val.IsEqual(controlVal))
                //        return true;
                //}
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if (controlVal == null)
                    {
                        if(message != "") message += "\n ";

                        message += "Not set " + propertyInfo.Name;
                        return false;
                    }
                }
                //if (control is ThresholdControl)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    object val = propertyInfo.GetValue(obj, null);
                //    object controlVal = ((ThresholdControl)control).Threshold;
                //    if (val.ToString() != controlVal.ToString())
                //        return true;
                //}
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (controlVal == null)
                    {
                        if (message != "") message += "\n ";

                        message += "Not set " + propertyInfo.Name;
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region protected virtual bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetChangeStatus()
        {

            return false;
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
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if(propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_typeToImport, null);
                    string controlVal = control.Text;
                    if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is RichTextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) 
                        continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_typeToImport, null);
                    string controlVal = ((RichTextBox)control).Rtf;
                    if (val != controlVal) 
                        propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is NumericUpDown)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    string typeName = propertyInfo.PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "int32":
                        {
                            int val = (int)propertyInfo.GetValue(_typeToImport, null);
                            int controlVal = (int)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);

                            break;
                        }
                        case "int16":
                        {
                            Int16 val = (Int16)propertyInfo.GetValue(_typeToImport, null);
                            Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);

                            break;
                        }
                        case "double":
                        {
                            double val = (double)propertyInfo.GetValue(_typeToImport, null);
                            double controlVal = (double)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);

                            break;
                        }
                    }
                }
                if (control is DateTimePicker)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    string typeName = propertyInfo.PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "datetime":
                            {
                                DateTime val = (DateTime)propertyInfo.GetValue(_typeToImport, null);
                                DateTime controlVal = ((DateTimePicker)control).Value;
                                if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);
                                break;
                            }
                        case "timespan":
                            {
                                TimeSpan val = (TimeSpan)propertyInfo.GetValue(_typeToImport, null);
                                TimeSpan controlVal = ((DateTimePicker)control).Value.TimeOfDay;
                                if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);
                                break;
                            }
                        default:
                            break;
                    }
                }
                if (control is CheckBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    bool val = (bool)propertyInfo.GetValue(_typeToImport, null);
                    bool controlVal = ((CheckBox)control).Checked;
                    if (val != controlVal) propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is AttachedFileControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    AttachedFileControl fileControl = ((AttachedFileControl) control);
                    AttachedFile val = (AttachedFile)propertyInfo.GetValue(_typeToImport, null);
                    AttachedFile controlVal = fileControl.AttachedFile;

                    fileControl.ApplyChanges();

                    if (val != controlVal) 
                        propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
                if (control is LifelengthViewer)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    Lifelength val = (Lifelength)propertyInfo.GetValue(_typeToImport, null);
                    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                    if (!val.IsEqual(controlVal)) propertyInfo.SetValue(_typeToImport, controlVal, null);
                }
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

        #region protected virtual void AbortChanges()
        protected virtual void AbortChanges()
        {
        }
        #endregion

        #region protected virtual void Save()
        protected virtual void Save()
        {
            if(!_saveChangesToDatabase)
                return;

            try
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is AttachedFileControl)
                    {
                        PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                        if (propertyInfo == null) continue;

                        AttachedFileControl attachedFileControl = ((AttachedFileControl)control);
                        attachedFileControl.Save();

                        AttachedFile val = (AttachedFile)propertyInfo.GetValue(_typeToImport, null);
                        AttachedFile controlVal = ((AttachedFileControl)control).AttachedFile;
                        if (val != controlVal)
                            propertyInfo.SetValue(_typeToImport, controlVal, null);
                    }
                }

                //GlobalObjects.CasEnvironment.Manipulator.Save(_typeToImport);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save smsEventType", ex);
            }
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Text = string.Format("{0} Import Form", _typeToImport.Name);

            //flowLayoutPanel1.Controls.Clear();
            
            //flowLayoutPanel1.Controls.Add(_excelImportFileControl);
            //flowLayoutPanel1.Controls.Add(panelButtons);

            //if (_typeToImport == null) 
            //    return;

            //_excelImportFileControl.TypeToImport = _typeToImport;
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "load templates");

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void ButtonPrevClick(object sender, EventArgs e)
        private void ButtonPrevClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region private void ButtonNextClick(object sender, EventArgs e)
        private void ButtonNextClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ButtonCreateAircraftClick(object sender, EventArgs e)

        private void ButtonCreateAircraftClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (result == DialogResult.No)
                {
                    AbortChanges();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    ApplyChanges();
                    Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }

        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        private void CommonExcelImportForm_Load(object sender, EventArgs e)
        {
            Text = $"{_typeToImport.Name} Import Form";

            flowLayoutPanel1.Controls.Clear();

            flowLayoutPanel1.Controls.Add(_excelImportFileControl);
            flowLayoutPanel1.Controls.Add(panelButtons);

            if (_typeToImport == null)
                return;

            _excelImportFileControl.TypeToImport = _typeToImport;

            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                                     Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }


        #endregion
    }

}