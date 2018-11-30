using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.DirectivesControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Templates;
using Component = SmartCore.Entities.General.Accessory.Component;


namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class TemplateAircraftAddToDataBaseForm : Form
    {

        #region Fields

        private Int32 _transferedAircraftId;
        private TemplateAircraft _templateAircraft;
        private Aircraft _transferedAircraft;
        private List<Template> _templates;

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        private Operator _currentOperator;
        
        #endregion

        #region Constructors

        #region private TemplateAircraftAddToDataBaseForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        private TemplateAircraftAddToDataBaseForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public TemplateAircraftAddToDataBaseForm(Operator @operator) : this()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        public TemplateAircraftAddToDataBaseForm(Operator @operator) : this()
        {
            _currentOperator = @operator;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

            _animatedThreadWorker.RunWorkerAsync();

            //_templates = GlobalObjects.CasEnvironment.Loader.GetTemplates();
            //{
            //    foreach (Template template in _templates)
            //    {
            //        comboBoxTemplates.Items.Add(template);
            //    }
            //}
        }

        #endregion
     
        #endregion

        #region Properties

        #region private int TransferedAircraftId
        /// <summary>
        /// ID созданого ВС (возвращает 0 если операция не произашла)
        /// </summary>
        private int TransferedAircraftId
        {
            get { return _transferedAircraftId; }
            set { _transferedAircraftId = value; }
        }

        #endregion

        #region public Aircraft TransferedAircraft
        /// <summary>
        /// Transfered Aircraft
        /// </summary>
        public Aircraft TransferedAircraft
        {
            get { return _transferedAircraft; }
        }
        #endregion

        #region public Operator Operator

        /// <summary>
        /// Вовзращает или устанавливает эксплуатанта, к которому добавляются воздушное судно
        /// </summary>
        public Operator Operator
        {
            get { return _currentOperator; }
        }

        #endregion

        #endregion

        #region Methods

        #region private Control GetControl(BaseSmartCoreObject obj, PropertyInfo propertyInfo)
        private Control GetControl(BaseEntityObject obj, PropertyInfo propertyInfo)
        {
            #region ЭУ для прикрепленного файла

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(AttachedFile)))
            {
                object val = propertyInfo.GetValue(obj, null);
                return new AttachedFileControl
                {
                    AttachedFile = (AttachedFile)val,
                    Filter = "PDF file (*.pdf)|*.pdf",
                    Icon = Properties.Resources.PDFIconSmall,
                    MaximumSize = new Size(350, 75),
                    Size = new Size(350, 75),
                    Tag = propertyInfo
                };
            }
            #endregion

            #region ЭУ для StaticDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(StaticDictionary)))
            {
                object val = propertyInfo.GetValue(obj, null);
                ComboBox nc = new ComboBox { Tag = propertyInfo };

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

            #region ЭУ для AbstractDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractDictionary)))
            {
                AbstractDictionary val = (AbstractDictionary)propertyInfo.GetValue(obj, null);
                DictionaryComboBox dc = new DictionaryComboBox { Type = propertyInfo.PropertyType, SelectedItem = val, Tag = propertyInfo };
                return dc;
            }
            #endregion

	        if (propertyInfo.PropertyType.IsSubclassOf(typeof(AbstractModel)))
	        {
		        var val = (AircraftModel)propertyInfo.GetValue(obj, null);
		        var dictionaryComboBoxAircraftModel = new LookupCombobox {Type = typeof(AircraftModel), Tag = propertyInfo , SelectedItem = val };
		        return dictionaryComboBoxAircraftModel;
			}


            #region ЭУ для BaseEntityObject

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject)))
            {
                object val = propertyInfo.GetValue(obj, null);
                return new TextBox { Text = val != null ? val.ToString() : "", ReadOnly = true, AutoSize = true, Tag = propertyInfo };
            }
            #endregion

            #region ЭУ для IsEnum

            if (propertyInfo.PropertyType.IsEnum)
            {
                object val = propertyInfo.GetValue(obj, null);
                if (propertyInfo.PropertyType.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0)
                {
                    CommonFlagsControl cfc = new CommonFlagsControl { SourceEnum = propertyInfo.PropertyType, Tag = propertyInfo };
                    return cfc;
                }

                ComboBox nc = new ComboBox { Tag = propertyInfo };
                foreach (object o in Enum.GetValues(propertyInfo.PropertyType))
                    nc.Items.Add(o);
                nc.SelectedItem = val;
                return nc;
            }
            #endregion

            #region ЭУ для базовых типов

            string typeName = propertyInfo.PropertyType.Name.ToLower();
            switch (typeName)
            {
                case "string":
                    {
                        string val = (string)propertyInfo.GetValue(obj, null);
                        return new TextBox { Text = val, MinimumSize = new Size(20, 17), AutoSize = true, Tag = propertyInfo };
                    }
                case "int32":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        MinMaxValueAttribute mmValue =
                            (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                        NumericUpDown nud = new NumericUpDown();
                        if (mmValue != null)
                        {
                            nud.Maximum = (decimal)mmValue.Max;
                            nud.Minimum = (decimal)mmValue.Min;
                        }
                        nud.Value = (int)val;
                        nud.DecimalPlaces = 0;
                        nud.MinimumSize = new Size(20, 17);
                        nud.Tag = propertyInfo;

                        return nud;
                    }
                case "int16":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        MinMaxValueAttribute mmValue =
                            (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                        NumericUpDown nud = new NumericUpDown();
                        if (mmValue != null)
                        {
                            nud.Maximum = (decimal)mmValue.Max;
                            nud.Minimum = (decimal)mmValue.Min;
                        }
                        nud.Value = (Int16)val;
                        nud.DecimalPlaces = 0;
                        nud.MinimumSize = new Size(20, 17);
                        nud.Tag = propertyInfo;

                        return nud;
                    }
                case "datetime":
                    {
                        DateTime val = (DateTime)propertyInfo.GetValue(obj, null);
                        return new DateTimePicker
                        {
                            MinDate = DateTimeExtend.GetCASMinDateTime(),
                            Value = val > DateTimePicker.MinimumDateTime ? new DateTime(val.Ticks): DateTimePicker.MinimumDateTime,
                            MinimumSize = new Size(20, 17),
                            //AutoSize = true,
                            Tag = propertyInfo
                        };
                    }
                case "bool":
                case "boolean":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new CheckBox
                        {
                            Checked = (bool)val,
                            MinimumSize = new Size(20, 17),
                            //AutoSize = true,
                            Tag = propertyInfo
                        };
                    }
                case "double":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        MinMaxValueAttribute mmValue =
                            (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                        NumericUpDown nud = new NumericUpDown();
                        if (mmValue != null)
                        {
                            nud.Maximum = (decimal)mmValue.Max;
                            nud.Minimum = (decimal)mmValue.Min;
                        }
                        nud.Value = (decimal) (double) val;
                        nud.DecimalPlaces = 2;
                        nud.MinimumSize = new Size(20, 17);
                        nud.Tag = propertyInfo;
                        
                        return nud;
                    }
                //case "kitcostcondition":
                //case "weathercondition":
                //    return DataType.SmallInt;
                //case "highlight":
                //case "timespan":
                //case "workpackagestatus":
                //    return DataType.Int;
                case "directivethreshold":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new DirectiveThresholdControl { Threshold = (DirectiveThreshold)val, Tag = propertyInfo };
                    }
                case "componentdirectivethreshold":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new ComponentDirectiveThresholdControl { Threshold = (ComponentDirectiveThreshold)val, Tag = propertyInfo };
                    }
                case "lifelength":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new LifelengthViewer
                        {
                            Lifelength = (Lifelength) val,
                            MinimumSize = new Size(20, 17),
                            Tag = propertyInfo
                        };
                    }
                default:
                    return null;
            }
            #endregion
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus(BaseEntityObject obj)
        {
            foreach (Control control in splitContainerMain.Panel2.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(obj, null);
                    string controlVal = control.Text;
                    if (val != controlVal)
                        return true;
                }
                if (control is NumericUpDown && control.Tag != null)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    string typeName = propertyInfo.PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "int32":
                            {
                                int val = (int)propertyInfo.GetValue(obj, null);
                                int controlVal = (int)((NumericUpDown)control).Value;
                                if (val != controlVal) 
                                    return true;

                                break;
                            }
                        case "int16":
                            {
                                Int16 val = (Int16)propertyInfo.GetValue(obj, null);
                                Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                                if (val != controlVal)
                                    return true;

                                break;
                            }
                        case "double":
                            {
                                double val = (double)propertyInfo.GetValue(obj, null);
                                double controlVal = (double)((NumericUpDown)control).Value;
                                if (val != controlVal)
                                    return true;

                                break;
                            }
                    }
                }
                if (control is DateTimePicker)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    DateTime val = (DateTime)propertyInfo.GetValue(obj, null);
                    if (val != ((DateTimePicker)control).Value) 
                        return true;
                }
                if (control is CheckBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    bool val = (bool)propertyInfo.GetValue(obj, null);
                    bool controlVal = ((CheckBox)control).Checked;
                    if (val != controlVal)
                        return true;
                }
                if (control is AttachedFileControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    AttachedFileControl attachedFileControl = ((AttachedFileControl) control);
                    if (attachedFileControl.GetChangeStatus())
                        return true;
                }
                //|| (control is IThresholdControl && control.Tag != null && ((IThresholdControl)control).Threshold != (AttachedFile)control.Tag)
                if (control is LifelengthViewer)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    Lifelength val = (Lifelength)propertyInfo.GetValue(obj, null);
                    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                    if (!val.IsEqual(controlVal))
                        return true;
                }
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(obj, null);
                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if (!val.Equals(controlVal))
                        return true;
                }
                if (control is ThresholdControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(obj, null);
                    object controlVal = ((ThresholdControl)control).Threshold;
                    if (val.ToString() != controlVal.ToString())
                        return true;
                }
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(obj, null);
                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (!val.Equals(controlVal))
                        return true;
                }
            }

            return false;
        }

        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";
            foreach (Control control in splitContainerMain.Panel2.Controls)
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
                        ListViewDataAttribute fca = (ListViewDataAttribute)
                            propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).First();
                        message += string.Format("'{0}' should not be empty", fca.Title);
                        return false;
                    }
                }
                if (control is DateTimePicker)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;
                    DateTime checkVal = DateTimeExtend.GetCASMinDateTime();
                    if (((DateTimePicker)control).Value < checkVal)
                    {
                        if (message != "") message += "\n ";
                        ListViewDataAttribute fca = (ListViewDataAttribute)
                            propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).First();
                        message += string.Format("'{0}' should be {1} or higher", fca.Title, SmartCore.Auxiliary.Convert.GetDateFormat(checkVal));
                        return false;
                    }
                }
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if (controlVal == null)
                    {
                        if (message != "") message += "\n ";

                        message += "Not set " + propertyInfo.Name;
                        return false;
                    }
                }
	            if (control is LookupCombobox)
	            {
		            PropertyInfo propertyInfo = control.Tag as PropertyInfo;
		            if (propertyInfo == null) continue;

		            object controlVal = ((LookupCombobox)control).SelectedItem;
		            if (controlVal == null)
		            {
			            if (message != "") message += "\n ";

			            message += "Not set " + propertyInfo.Name;
			            return false;
		            }
	            }
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

        #region public void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        private void ApplyChanges(BaseEntityObject obj)
        {
            foreach (Control control in splitContainerMain.Panel2.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if(propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(obj, null);
                    string controlVal = control.Text;
                    if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);
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
                            int val = (int)propertyInfo.GetValue(obj, null);
                            int controlVal = (int)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);

                            break;
                        }
                        case "int16":
                        {
                            Int16 val = (Int16)propertyInfo.GetValue(obj, null);
                            Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);

                            break;
                        }
                        case "double":
                        {
                            double val = (double)propertyInfo.GetValue(obj, null);
                            double controlVal = (double)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);

                            break;
                        }
                    }
                }
                if (control is DateTimePicker)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;
                    
                    DateTime val = (DateTime)propertyInfo.GetValue(obj, null);
                    DateTime controlVal = ((DateTimePicker) control).Value;
                    if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);
                }
                if (control is CheckBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    bool val = (bool)propertyInfo.GetValue(obj, null);
                    bool controlVal = ((CheckBox)control).Checked;
                    if (val != controlVal) propertyInfo.SetValue(obj, controlVal, null);
                }
                if (control is AttachedFileControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    AttachedFileControl attachedFileControl = ((AttachedFileControl) control);
                    if(attachedFileControl.GetChangeStatus())
                    {
                        attachedFileControl.ApplyChanges();
                        propertyInfo.SetValue(obj, attachedFileControl.AttachedFile, null);
                    }
                }
                    //|| (control is IThresholdControl && control.Tag != null && ((IThresholdControl)control).Threshold != (AttachedFile)control.Tag)
                if (control is LifelengthViewer)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    Lifelength val = (Lifelength)propertyInfo.GetValue(obj, null);
                    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                    if (!val.IsEqual(controlVal)) propertyInfo.SetValue(obj, controlVal, null);
                }
                if (control is ThresholdControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(obj, null);
                    object controlVal = ((ThresholdControl)control).Threshold;
                    if (val.ToString() != controlVal.ToString())
                        propertyInfo.SetValue(obj, controlVal, null);
                }
				if (control is DictionaryComboBox)
				{
					PropertyInfo propertyInfo = control.Tag as PropertyInfo;
					if (propertyInfo == null) continue;

					object val = propertyInfo.GetValue(obj, null);
					object controlVal = ((DictionaryComboBox)control).SelectedItem;
					if (!val.Equals(controlVal)) propertyInfo.SetValue(obj, controlVal, null);
				}
	            if (control is LookupCombobox)
	            {
		            PropertyInfo propertyInfo = control.Tag as PropertyInfo;
		            if (propertyInfo == null) continue;

		            object val = propertyInfo.GetValue(obj, null);
		            object controlVal = ((LookupCombobox)control).SelectedItem;
		            if (!val.Equals(controlVal)) propertyInfo.SetValue(obj, controlVal, null);
	            }
				if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(obj, null);
                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (!val.Equals(controlVal)) propertyInfo.SetValue(obj, controlVal, null);
                }
            }
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Template template in _templates)
            {
                comboBoxTemplates.Items.Add(template);
            }
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            var loader = GlobalObjects.CasEnvironment.Loader;

            _animatedThreadWorker.ReportProgress(0, "load templates");
            var templates = loader.GetObjectList<Template>();

            _animatedThreadWorker.ReportProgress(6, "load template aircrafts");
            var templateAircrafts = loader.GetObjectListAll<TemplateAircraft>(loadChild:true);

            _animatedThreadWorker.ReportProgress(12, "load template base details");
            var templateBaseDetails = loader.GetObjectList<TemplateBaseComponent>();

            _animatedThreadWorker.ReportProgress(18, "load template details");
            var templateDetails = loader.GetObjectList<TemplateComponent>();
			//TODO:(Evgenii Babak) Переименовать Detail в Component
			_animatedThreadWorker.ReportProgress(25, "load template detail directives");
            var templateDetailDirectives = loader.GetObjectList<TemplateComponentDirective>();

            _animatedThreadWorker.ReportProgress(37, "load template directives");
            var templateDirectives = loader.GetObjectList<TemplateDirective>();

            _animatedThreadWorker.ReportProgress(43, "load template maintenance checks");
            var templateMaintenanceChecks = loader.GetObjectList<TemplateMaintenanceCheck>(loadChild:true);
			//TODO:(Evgenii Babak) Переименовать Detail в Component
			_animatedThreadWorker.ReportProgress(50, "binding detail with detail directives");
            
            double unit = 12.5/templateDetails.Count;
            double diff = 0;
            foreach (TemplateComponent templateDetail in templateDetails)
            {
                diff += unit;
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				_animatedThreadWorker.ReportProgress(50 + (int)diff, "binding detail with detail directives");

                templateDetail.ComponentDirectives =
                        templateDetailDirectives.Where(tdd => tdd.ComponentId == templateDetail.ItemId).ToList();
            }

            unit = 12.5 / templateBaseDetails.Count;
            diff = 0;
            foreach (TemplateBaseComponent templateBaseComponent in templateBaseDetails)
            {
                diff += unit;
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				_animatedThreadWorker.ReportProgress(75 + (int)diff, "binding base details");

                templateBaseComponent.Components = templateDetails.Where(td => td.ParentId == templateBaseComponent.ItemId).ToList();
                templateBaseComponent.Directives = templateDirectives.Where(td => td.ComponentId == templateBaseComponent.ItemId).ToList();
                templateBaseComponent.ComponentDirectives =
                    templateDetailDirectives.Where(tdd => tdd.ComponentId == templateBaseComponent.ItemId).ToList();
            }

            unit = 12.5 / templates.Count;
            diff = 0;
            foreach (Template template in templates)
            {
                diff += unit;
                _animatedThreadWorker.ReportProgress(87 + (int)diff, "binding templates");

                TemplateAircraft templateAircraft = templateAircrafts.Where(ta => ta.TemplateId == template.ItemId).FirstOrDefault();
                templateAircraft.MaintenanceChecks = templateMaintenanceChecks.Where(tmc => tmc.TemplateId == template.ItemId).ToList();
                templateAircraft.BaseComponents = templateBaseDetails.Where(tbd => tbd.TemplateId == template.ItemId).ToList();
                template.TemplateAircraft = templateAircraft;
            }

            _templates = templates;

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "Create aircraft from template");
            Manipulator manipulator = GlobalObjects.CasEnvironment.Manipulator;

            if(_templateAircraft == null)return;
            if (_currentOperator.ItemId <= 0) throw new Exception("1650: Can not add aircraft to not existing operator");
            
            //_transferedAircraft = GlobalObjects.CasEnvironment.Manipulator.CreateAircraftFromTemplate(ta, _currentOperator);
            // Создание нового ВС на основе шаблона
            List<BaseComponent> baseComponents = new List<BaseComponent>();
            List<Component> components = new List<Component>();
            List<ComponentDirective> componentDirectives = new List<ComponentDirective>();
            List<Directive> directives = new List<Directive>();
            List<MaintenanceCheck> maintenanceChecks;

            _animatedThreadWorker.ReportProgress(10, "binding directives");

            #region Связывание директив
            foreach (var templateBaseComponent in _templateAircraft.BaseComponents)
            {
                var bd = BaseComponent.CreateFromTemplate(templateBaseComponent);
                if (bd.ManufactureDate.Ticks == DateTimeExtend.GetCASMinDateTime().Ticks)
                    bd.ManufactureDate = _templateAircraft.ManufactureDate;
	            bd.StartDate = _templateAircraft.ManufactureDate;
                baseComponents.Add(bd);

                componentDirectives.AddRange(templateBaseComponent.ComponentDirectives
                    .Select(templateDetailDirective =>
                        new ComponentDirective(templateDetailDirective, bd)));

                foreach (var templatePrimeDirective in templateBaseComponent.Directives)
                {
                    var directive = new Directive(templatePrimeDirective) { ParentBaseComponent = bd };
                    directives.Add(directive);
                }

                foreach (var templateComponent in templateBaseComponent.Components)
                {
                    Component component = new Component(templateComponent) { ParentBaseComponent = bd };
                    if (component.ManufactureDate == DateTimeExtend.GetCASMinDateTime())
                        component.ManufactureDate = bd.ManufactureDate;

                    components.Add(component);

                    componentDirectives.AddRange(templateComponent.ComponentDirectives
                        .Select(templateDetailDirective =>
                            new ComponentDirective(templateDetailDirective, component)));
                }
            }
            maintenanceChecks = _templateAircraft.MaintenanceChecks
                .Select(templateMaintenanceCheck =>
                    new MaintenanceCheck(templateMaintenanceCheck)).ToList();
            #endregion

            #region Подсчет сохраняемых элементов
            int countOfObjects = 1;
            countOfObjects += baseComponents.Count;
            countOfObjects += components.Count;
            countOfObjects += componentDirectives.Count;
            countOfObjects += directives.Count;
            countOfObjects += maintenanceChecks.Count;

            double unit = 80.0/countOfObjects;
            double diff = 0;
            #endregion

            #region Созранение элементов
            _animatedThreadWorker.ReportProgress(20, "save aircraft");
            Aircraft aircraft =
                new Aircraft(_templateAircraft, baseComponents.Where(d => d.BaseComponentType.ItemId == BaseComponentType.Frame.ItemId).FirstOrDefault());
            // Сохраняем воздушное судно в базе 
            GlobalObjects.AircraftsCore.RegisterAircraft(aircraft, _currentOperator.ItemId);

            diff += unit;

            foreach (var baseComponent in baseComponents)
            {
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				_animatedThreadWorker.ReportProgress(20 + (int)diff, "Save Base Details");
				GlobalObjects.ComponentCore.AddBaseComponent(baseComponent, aircraft, baseComponent.ManufactureDate, null, null, true, false);
                diff += unit;
            }
            foreach (var component in components)
            {
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				_animatedThreadWorker.ReportProgress(20 + (int)diff, "Save Details");
				GlobalObjects.ComponentCore.AddComponent(component, component.ParentBaseComponent, component.ManufactureDate, "", ComponentStorePosition.UNK, destinationResponsible:true);
                diff += unit;
            }
            foreach (var componentDirective in componentDirectives)
            {
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				_animatedThreadWorker.ReportProgress(20 + (int)diff, "Save Detail Directives");
				GlobalObjects.ComponentCore.AddComponentDirective(componentDirective.ParentComponent, componentDirective);
                diff += unit;
            }
            foreach (Directive directive in directives)
            {
                _animatedThreadWorker.ReportProgress(20 + (int)diff, "Save Directives");
                GlobalObjects.DirectiveCore.Save(directive);
                diff += unit;
            }
            foreach (MaintenanceCheck maintenanceCheck in maintenanceChecks)
            {
                _animatedThreadWorker.ReportProgress(20 + (int)diff, "Save Maintenance Checks");
                GlobalObjects.MaintenanceCore.AddMaintenanceCheck(maintenanceCheck, aircraft);
                diff += unit;
            }

            // Регистрируем frame для ВС чтобы не вызывать никаких ошибок
            //AddBaseDetail(aircraft.Frame, aircraft, aircraft.ManufactureDate, null, null);
            //aircraft.AircraftFrameId = aircraft.Frame.BaseDetailID;

            // Перезагружаем систему 
            //_casEnvironment.Reset();

            #endregion

            _transferedAircraft = aircraft;

            _animatedThreadWorker.ReportProgress(100, "Create Complete");
        }
        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ComboBoxTemplatesSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxTemplatesSelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewTemplate.Nodes.Clear();

            if (comboBoxTemplates.SelectedItem == null) return;
            _templateAircraft = ((Template) comboBoxTemplates.SelectedItem).TemplateAircraft;
            
            //Корень дерева - самолет
            TreeNode rootNode = new TreeNode(_templateAircraft.Model.ToString()) { Tag = _templateAircraft };
            treeViewTemplate.Nodes.Add(rootNode);

            #region Ветка базовых деталей
            if (_templateAircraft.BaseComponents.Count > 0)
            {
                TreeNode baseDetailRootNode = new TreeNode("Base Components");
                rootNode.Nodes.Add(baseDetailRootNode);

                foreach (var templateBaseComponent in _templateAircraft.BaseComponents)
                {
                    TreeNode baseComponentChildNode = new TreeNode(templateBaseComponent.Description) { Tag = templateBaseComponent };
                    baseDetailRootNode.Nodes.Add(baseComponentChildNode);

                    #region Директивы по обслуживанию компонентов базовой детали
                    if (templateBaseComponent.ComponentDirectives.Count > 0)
                    {
                        TreeNode baseComponentDirectivesRoot = new TreeNode(templateBaseComponent.Description + " Component Directives");
                        baseComponentChildNode.Nodes.Add(baseComponentDirectivesRoot);

                        foreach (var templateComponentDirective in templateBaseComponent.ComponentDirectives)
                        {
                            baseComponentDirectivesRoot.Nodes.Add(new TreeNode(templateComponentDirective.DirectiveType != null 
                                ? templateComponentDirective.DirectiveType.ToString() 
                                : "") 
                                { Tag = templateComponentDirective });
                        }
                    }
                    #endregion

                    #region Директивы летной годности

                    if(templateBaseComponent.Directives.Count > 0)
                    {
                        TreeNode baseDetailAdDirectivesRoot = new TreeNode(templateBaseComponent.Description + " " + " AD Directives");
                        baseComponentChildNode.Nodes.Add(baseDetailAdDirectivesRoot);
                        foreach (var dt in DirectiveType.Items)
                        {
                            TemplateDirective[] typedDirectives =
                                templateBaseComponent.Directives.Where(d => d.DirectiveType == dt).ToArray();

                            if(typedDirectives.Count() != 0)
                            {
                                TreeNode baseComponentAdDirectives = new TreeNode(dt.FullName);
                                baseDetailAdDirectivesRoot.Nodes.Add(baseComponentAdDirectives);

                                foreach (var templatePrimeDirective in typedDirectives)
                                {
                                    TreeNode detailNode = new TreeNode(templatePrimeDirective.ToString()) { Tag = templatePrimeDirective };
                                    baseComponentAdDirectives.Nodes.Add(detailNode);
                                }   
                            }
                        }   
                    }

                    #endregion

                    #region Компоненты базовой детали
                    if (templateBaseComponent.Components.Count > 0)
                    {
                        TreeNode baseDetailComponentsRoot = new TreeNode(templateBaseComponent.Description + " Components");
                        baseComponentChildNode.Nodes.Add(baseDetailComponentsRoot);

                        foreach (var templateComponent in templateBaseComponent.Components)
                        {
                            TreeNode detailNode = new TreeNode(templateComponent.Description){Tag = templateComponent};
                            baseDetailComponentsRoot.Nodes.Add(detailNode);

                            foreach (var componentDirective in templateComponent.ComponentDirectives)
                            {
                                detailNode.Nodes.Add(new TreeNode(componentDirective.DirectiveType != null? componentDirective.DirectiveType.ToString(): "")
                                                         {Tag = componentDirective});
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region Ветка директив

            #endregion

            #region Ветка Чеков обслуживания

            if (_templateAircraft.MaintenanceChecks.Count > 0)
            {
                TreeNode maintenaceRootNode = new TreeNode("Maintenance Checks");
                rootNode.Nodes.Add(maintenaceRootNode);

                foreach (TemplateMaintenanceCheck maintenanceCheck in _templateAircraft.MaintenanceChecks)
                {
                    maintenaceRootNode.Nodes.Add(new TreeNode(maintenanceCheck.Name + " " + 
                                                             (maintenanceCheck.Schedule?"Schedule":"Unschedule")) 
                                                             {Tag = maintenanceCheck});
                }
            }

            #endregion

            treeViewTemplate.SelectedNode = rootNode;
        }
        #endregion

        #region private void TreeViewTemplateAfterSelect(object sender, TreeViewEventArgs e)
        private void TreeViewTemplateAfterSelect(object sender, TreeViewEventArgs e)
        {
            splitContainerMain.Panel2.Controls.Clear();

            if (e.Node.Tag == null || !(e.Node.Tag is BaseEntityObject)) return;

            Type type = e.Node.Tag.GetType();
            //определение своиств типа
            List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                preProrerty.Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();
            
            if(properties.Count == 0)return;

            int columnCount = 1;//количество колонок ЭУ
            
            List<Label> labels = new List<Label>();
            List<Control> controls = new List<Control>();
            
            foreach (PropertyInfo t in properties)
            {
                ListViewDataAttribute attr =
                    (ListViewDataAttribute)t.GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];
                labels.Add(new Label {Text = attr.Title, AutoSize = true});

                //Если значение должно быть не пустым или не NULL
                //то шрифт леибла утснанавливается в ЖИРНЫЙ(BOLD)
                NotNullAttribute notNullAttribute =
                    (NotNullAttribute)t.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                if (notNullAttribute != null)
                    labels.Last().Font = new Font(labels.Last().Font, FontStyle.Bold);
                
                Control c = GetControl((BaseEntityObject) e.Node.Tag, t);
                if (c is LifelengthViewer) ((LifelengthViewer) c).LeftHeader = attr.Title;
                if (c is ThresholdControl) columnCount = 2;
                controls.Add(c);
            }

            #region Компоновка контролов в одну колонку
            if (columnCount == 1)
            {
                #region расчет длины лейблов и контролов

                int maxLabelXSize = 0;
                int maxControlXSize = 0;

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

                for (int i = 0; i < labels.Count; i++)
                {
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
                                controls[i].Location = new Point(maxLabelXSize + labels[i].Location.X + 5, 3);
                                controls[i].Width = maxControlXSize;
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
                                controls[i].Location = new Point(maxLabelXSize + labelLocation.X + 5, labelLocation.Y);
                                controls[i].Width = maxControlXSize;
                            }
                        }
                    }


                    if (controls[i] == null || (controls[i] != null && !(controls[i] is LifelengthViewer)))
                    {
                        //Если контрол не является LifelengthViewer-ом то нужно добавить лейбл
                        splitContainerMain.Panel2.Controls.Add(labels[i]);
                    }
                    splitContainerMain.Panel2.Controls.Add(controls[i]);
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
                
                for(int i = 0; i< labels.Count; i++)
                {
                    //на каждый лейбл приходится по одному контролу, 
                    //поэтому обе коллекции просматриваются одновременно
                    if(controls[i] != null && controls[i] is ThresholdControl)
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

                    if(controls[i] != null && controls[i] is LifelengthViewer)
                    {
                        LifelengthViewer llv = (LifelengthViewer) controls[i];

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
                    if(controls[i] != null)
                    {
                        if (checkFirst && controls[i].Size.Width> fMaxControlXSize)
                            fMaxControlXSize = controls[i].Size.Width;
                        if (!checkFirst && controls[i].Size.Width > sMaxControlXSize)
                            sMaxControlXSize = controls[i].Size.Width;
                    }

                    checkFirst = !checkFirst;
                }
                #endregion

                checkFirst = true;
                const int firstCol = 3;
                int  secondCol = (3 + fMaxLabelXSize + 5 + fMaxControlXSize + 50);
                for (int i = 0; i < labels.Count; i++)
                {
                    int top, left, labelSize, controlSize;
                    if (i == 0)
                    {
                        top = 3;
                        left = firstCol;
                        labelSize = fMaxLabelXSize;
                        controlSize = fMaxControlXSize;
                    }
                    else
                    {
                        if (checkFirst 
                            || (controls[i] != null && controls[i] is ThresholdControl))
                        {
                            left = firstCol;
                            labelSize = fMaxLabelXSize;
                            controlSize = fMaxControlXSize;

                            //определение самого нижнего Bottoma 2-х предыдущих контролов
                            int bottom1, bottom2;
                            //определение нижней точки предыдущего контрола 
                            //(он будет либо во второй колонке предыдущего ряда, либо занимать весь ряд)
                            if (controls[i - 1] != null)
                                bottom2 = controls[i-1].Bottom + 5;
                            else bottom2 = labels[i - 1].Bottom + 5;
                            //определение нижней точки пред-предыдущего контрола
                            //он может и отсутствовать
                            if ((i - 2) >= 0)
                            {
                                if(controls[i - 2] != null)
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
                            controlSize = sMaxControlXSize;

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

                        splitContainerMain.Panel2.Controls.Add(controls[i]);
                        checkFirst = true;
                        continue;
                    }

                    if (controls[i] != null &&  controls[i] is LifelengthViewer)
                    {
                        controls[i].Location =
                            new Point((labelSize + left) - ((LifelengthViewer)controls[i]).LeftHeaderWidth, top);
                        splitContainerMain.Panel2.Controls.Add(controls[i]);
                        checkFirst = !checkFirst;
                        continue;
                    }

                    labels[i].Location = new Point(left, top);
                    if (controls[i] != null)
                    {
                        controls[i].Location = new Point(labelSize + left + 5, top);
                        controls[i].Width = controlSize;
                    }
                    splitContainerMain.Panel2.Controls.Add(labels[i]);
                    splitContainerMain.Panel2.Controls.Add(controls[i]);
                    checkFirst = !checkFirst;
                }
            }
            #endregion
        }
        #endregion

        #region private void TreeViewTemplateBeforeSelect(object sender, TreeViewCancelEventArgs e)
        private void TreeViewTemplateBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(treeViewTemplate.SelectedNode == null || !(treeViewTemplate.SelectedNode.Tag is BaseEntityObject))return;

            BaseEntityObject obj = treeViewTemplate.SelectedNode.Tag as BaseEntityObject;
            
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if(GetChangeStatus(obj))
            {
                if(MessageBox.Show("Do you want to save changes?", (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ApplyChanges(obj);   
                }
            }
        }
        #endregion

        #region private void ButtonCreateAircraftClick(object sender, EventArgs e)

        private void ButtonCreateAircraftClick(object sender, EventArgs e)
        {
            if(comboBoxTemplates.SelectedItem == null)return;

            //проверка того сохранены ли данные в открытой ветке дерева
            if (treeViewTemplate.SelectedNode != null && treeViewTemplate.SelectedNode.Tag is BaseEntityObject)
            {
                BaseEntityObject obj = treeViewTemplate.SelectedNode.Tag as BaseEntityObject;
               
                string message;
                if (!ValidateData(out message))
                {
                    message += "\nAbort operation";
                    MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (GetChangeStatus(obj))
                {
                    if (MessageBox.Show("Do you want to save changes?", (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        ApplyChanges(obj);
                    }
                }
            }

            _animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoCreate;
            _animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCreateCompleted;

            _animatedThreadWorker.RunWorkerAsync();

            //TemplateAircraft ta = ((Template) comboBoxTemplates.SelectedItem).TemplateAircraft;
            //_transferedAircraft = GlobalObjects.CasEnvironment.Manipulator.CreateAircraftFromTemplate(ta, _currentOperator);

            //DialogResult = DialogResult.OK;
            //Close();
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

        #endregion
    }

}