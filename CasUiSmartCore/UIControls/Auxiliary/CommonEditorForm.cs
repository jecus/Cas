using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using Convert = System.Convert;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Общая Форма для редактирования объектов
    /// </summary>
    public partial class CommonEditorForm : Form
    {
        #region Fields

        private bool _saveChangesToDatabase;
        private BaseEntityObject _currentObject;
        private string _typeName;

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        
        #endregion

        #region Constructors

        #region public CommonEditorForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        public CommonEditorForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public CommonEditorForm(BaseSmartCoreObject editingObject) : this()
        /// <summary>
        /// Создает форму для редактирования переданного объекта
        /// </summary>
        public CommonEditorForm(BaseEntityObject editingObject, bool saveChangesToDatabase = true) : this()
        {
            if(editingObject == null)
                throw new ArgumentNullException("editingObject", "can not be null");
            _currentObject = editingObject;
            _saveChangesToDatabase = saveChangesToDatabase;

            Type t = _currentObject.GetType();
            DescriptionAttribute da =
                t.GetCustomAttributes(typeof (DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            _typeName = da != null && !string.IsNullOrEmpty(da.Description) 
                ? da.Description 
                : t.Name;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

            _animatedThreadWorker.RunWorkerAsync();
        }

        #endregion
     
        #endregion

        #region Properties

        ///<summary>
        /// Возвращает редактируемый объект
        ///</summary>
        public virtual  BaseEntityObject CurrentObject
        {
            get { return _currentObject; }
        }
        #endregion

        #region Methods

        #region protected List<PropertyInfo> GetTypeProperties(Type type)
        protected List<PropertyInfo> GetTypeProperties(Type type)
        {
            if (type == null) return null;
            //определение своиств, имеющих атрибут "отображаемое в списке"
            List<PropertyInfo> properties =
                type.GetProperties().Where(p => p.GetCustomAttributes(typeof(FormControlAttribute), false).Length != 0).ToList();

            //поиск своиств у которых задан порядок отображения
            //своиства, имеющие порядок отображения
            Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
            //своиства, НЕ имеющие порядок отображения
            List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                FormControlAttribute lvda = (FormControlAttribute)
                    propertyInfo.GetCustomAttributes(typeof(FormControlAttribute), false).FirstOrDefault();
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

        #region protected virtual void SetFormControls()
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetFormControls()
        {
            Text = string.Format("{0} {1} Form", _typeName, _currentObject != null ? _currentObject.ItemId <= 0 ? "Adding" : "Editing" : "");

            panelMain.Controls.Clear();

            if (_currentObject == null) return;

            List<PropertyInfo> properties = GetTypeProperties(_currentObject.GetType());

            if (properties.Count == 0) return;

            int columnCount = properties.Count > 15 ? 2 : 1;//количество колонок ЭУ

            List<Label> labels = new List<Label>();
            List<Control> controls = new List<Control>();
            Dictionary<PropertyInfo, Control> pairControls = new Dictionary<PropertyInfo, Control>();
            string errorMessage = "";
            foreach (PropertyInfo t in properties)
            {
                PropertyInfo pairProperty = null;
                FormControlAttribute attr =
                    (FormControlAttribute)t.GetCustomAttributes(typeof(FormControlAttribute), false).First();
                labels.Add(new Label { Text = attr.Title, AutoSize = true });

                //Если значение должно быть не пустым или не NULL
                //то шрифт леибла утснанавливается в ЖИРНЫЙ(BOLD)
                NotNullAttribute notNullAttribute =
                    (NotNullAttribute)t.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();
                if (notNullAttribute != null)
                    labels.Last().Font = new Font(labels.Last().Font, FontStyle.Bold);

                Control c = null;
                if (!string.IsNullOrEmpty(attr.PairControlPropertyName))
                    pairProperty = _currentObject.GetType().GetProperty(attr.PairControlPropertyName);

                if (pairProperty != null)
                {
                    try
                    {
                        c = GetControl(_currentObject, pairProperty, attr.PairControlWidht, 1, attr.PairControlEnabled, attr.RichTextBox);
                    }
                    catch (Exception ex)
                    {
                        if (errorMessage != "") errorMessage += "\n ";
                        errorMessage += string.Format("Pair property '{0}' raise error {1}", attr.PairControlPropertyName, ex.Message);
                    }
                    if (c is ThresholdControl) columnCount = 2;
                    pairControls.Add(t, c);
                }

                c = null;

                try
                {
                    int cw = pairProperty != null ? attr.Width - attr.PairControlWidht - 5 : attr.Width;
                    c = GetControl(_currentObject, t, cw, attr.Lines, attr.Enabled, attr.RichTextBox);
                }
                catch (Exception ex)
                {
                    if (errorMessage != "") errorMessage += "\n ";
                    errorMessage += string.Format("'{0}' raise error {1}", attr.Title, ex.Message);
                }
                if (c is LifelengthViewer) ((LifelengthViewer)c).LeftHeader = attr.Title;
                if (c is ThresholdControl || c is CommonDataGridViewControl) columnCount = 2;
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
                        panelMain.Controls.Add(labels[i]);
                    }
                    if (pairControl != null)
                        panelMain.Controls.Add(pairControl);

                    panelMain.Controls.Add(controls[i]);
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
                    if (controls[i] is CommonDataGridViewControl)
                    {
                        //контрол порога выполнения директивы
                        //влияет на длину лейблов обоих колонок
                        checkFirst = true;
                        continue;
                    }
                    if (controls[i] is ThresholdControl)
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

                    if (controls[i] is LifelengthViewer)
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
                        if (controls[i] is CommonDataGridViewControl)
                        {
                            left = firstCol;
                            labelSize = labels[i].PreferredWidth;
                            controlSize = (fMaxLabelXSize + 5 + fMaxControlXSize + 50 + sMaxLabelXSize + 5 + sMaxControlXSize);

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
                        else if (checkFirst || controls[i] is ThresholdControl)
                        {
                            left = firstCol;
                            labelSize = fMaxLabelXSize;
                            controlSize = fMaxControlXSize;

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
                            controlSize = sMaxControlXSize;

                            top = controls[i - 1] != null ? controls[i - 1].Location.Y : labels[i - 1].Location.Y;
                        }
                    }

                    if (controls[i] is CommonDataGridViewControl)
                    {
                        labels[i].Location = new Point(3 + (controlSize / 2 - labelSize / 2), top);
                        panelMain.Controls.Add(labels[i]);

                        controls[i].Location = new Point(3, top + labels[i].PreferredHeight + 5);
                        try
                        {
                            controls[i].Width = controlSize;
                        }
                        catch (Exception ex)
                        {
                            string s = ex.ToString();
                            s.ToLower();
                        }
                        finally
                        {
                            panelMain.Controls.Add(controls[i]);
                        }

                        checkFirst = true;
                        continue;
                    }

                    if (controls[i] is ThresholdControl)
                    {
                        ThresholdControl ddtc = (ThresholdControl)controls[i];
                        controls[i].Location = new Point(3, top);
                        //выравнивание первой колонки
                        ddtc.SetFirstColumnPos(firstCol + fMaxLabelXSize);
                        //выравнивание второй колонки
                        ddtc.SetSecondColumnPos(secondCol + sMaxLabelXSize);

                        panelMain.Controls.Add(controls[i]);
                        checkFirst = true;
                        continue;
                    }

                    if (controls[i] is LifelengthViewer)
                    {
                        controls[i].Location =
                            new Point((labelSize + left) - ((LifelengthViewer)controls[i]).LeftHeaderWidth, top);
                        panelMain.Controls.Add(controls[i]);
                        checkFirst = !checkFirst;
                        continue;
                    }

                    labels[i].Location = new Point(left, top);
                    if (controls[i] != null)
                    {
                        controls[i].Location = new Point(labelSize + left + 5, top);
                        controls[i].Width = controlSize;
                    }
                    panelMain.Controls.Add(labels[i]);
                    panelMain.Controls.Add(controls[i]);
                    checkFirst = !checkFirst;
                }
            }
            #endregion

            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage, (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                                     Owner.Location.Y + Owner.Height / 2 - Height / 2);    
        }
        #endregion

        #region private Control GetControl(BaseEntityObject obj, PropertyInfo propertyInfo, int controlWidth, int controlLines, bool controlEnabled)
        private Control GetControl(BaseEntityObject obj, 
                                   PropertyInfo propertyInfo, 
                                   int controlWidth, 
                                   int controlLines, 
                                   bool controlEnabled,
                                   bool richTextBox)
        {

            Type propertyType = propertyInfo.PropertyType;
            FormControlAttribute fca =
                    (FormControlAttribute)propertyInfo.GetCustomAttributes(typeof(FormControlAttribute), false).First();

            #region ЭУ для прикрепленного файла

            if (propertyInfo.PropertyType.Name == typeof(AttachedFile).Name ||
                propertyInfo.PropertyType.IsSubclassOf(typeof(AttachedFile)))
            {
                object val = propertyInfo.GetValue(obj, null);

	            var flag = propertyInfo.Name.StartsWith("Image");
	            var filter = flag ? "Image Files|*.jpg;*.jpeg;*.png" : "PDF file (*.pdf)|*.pdf";
	            var icon = flag ? Properties.Resources.ImageIcon_Small : Properties.Resources.PDFIconSmall;

				return new AttachedFileControl
                {
                    AttachedFile = (AttachedFile)val,
                    Enabled = controlEnabled,
                    Filter = filter,
                    Icon = icon,
                    MaximumSize = new Size(350, 100),
                    Size = new Size(350, 75),
                    Tag = propertyInfo
                };
            }
            #endregion

            #region ЭУ для StaticTreeDictionary

            if (propertyInfo.PropertyType.IsSubclassOf(typeof(StaticTreeDictionary)))
            {
                object val = propertyInfo.GetValue(obj, null);

                TreeDictionaryComboBox dc = new TreeDictionaryComboBox
                {
                    Enabled = controlEnabled,
                    Name = propertyInfo.Name,
                    SelectedItem = val,
                    RootNodesNames = fca.TreeDictRootNodes,
                    Tag = propertyInfo,
                    Type = propertyInfo.PropertyType,
                    Width = controlWidth,
                };
                //для возможности вызова новой вкладки
                Program.MainDispatcher.ProcessControl(dc);
                return dc;
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
                if (fca.Enabled)
                {
                    LookupCombobox lcb = new LookupCombobox
                    {
                        AutoSize = true,
                        Enabled = controlEnabled,
                        Tag = propertyInfo,
                        SelectedItem = val as BaseEntityObject,
                        Type = propertyInfo.PropertyType,
                        Width = controlWidth,
                    };

                    lcb.SelectedIndexChanged += LookUpComboBoxSelectedIndexChanged;

                    return lcb;
                }
                
                TextBox tb = new TextBox
                {
                    AutoSize = true,
                    Enabled = controlEnabled,
                    Multiline = controlLines > 1,
                    Tag = propertyInfo,
                    Text = val != null ? val.ToString() : "",
                    Width = controlWidth,
                };
                if (controlLines > 1)
                    tb.Height = tb.Font.Height * controlLines;
                return tb;
            }
            #endregion

            #region ЭУ для IEnumerable<>

            if (propertyType.Name.ToLower() != "string" && 
                propertyType.GetInterface(typeof(IEnumerable<>).Name) != null)
            {
                //Если свойство не string (string реализует интерфейс IEnumerable<>)
                //и реализует интерфейс IEnumerable<> то
                //производится поиск параметра универсального типа
                Type t = propertyType;

                while (t != null)
                {
                    if (t.IsGenericType)
                    {
                        propertyType = t.GetGenericArguments().FirstOrDefault();
                        break;
                    }
                    t = t.BaseType;
                }
            }

            if (propertyType != null && propertyType.IsSubclassOf(typeof(BaseEntityObject)))
            {
                
                IEnumerable val = propertyInfo.GetValue(obj, null) as IEnumerable;
                CommonDataGridViewControl dataGridView = new CommonDataGridViewControl
                {
                    AutoSize = true,
                    Enabled = controlEnabled,
                    Height = controlLines > 1 ? Font.Height * controlLines :  Height,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    ShowQuickSearch = false,
                    RowHeadersVisible = false,
                    Tag = propertyInfo,
                    Width = controlWidth
                };
                if (fca.ListViewPropertiesNames != null && fca.ListViewPropertiesNames.Count > 0)
                {
                    foreach (string listViewPropertyName in fca.ListViewPropertiesNames)
                    {
                        PropertyInfo listViewProperty = propertyType.GetProperty(listViewPropertyName);
                        if (listViewProperty != null)
                            dataGridView.ViewedTypeProperties.Add(listViewProperty);    
                    }
                }
                dataGridView.ViewedType = propertyType;
                
                if(val != null)
                    dataGridView.SetItemsArray(val.OfType<BaseEntityObject>());

                return dataGridView;
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

            #region  ЭУ для базовых типов

            string typeName = propertyInfo.PropertyType.Name.ToLower();
            switch (typeName)
            {
                case "string":
                    {
                        string val = (string)propertyInfo.GetValue(obj, null);
                        Control control;
                        if (richTextBox)
                        {
                            RichTextBox richText = new RichTextBox
                            {
                                AutoSize = true,
                                Enabled = controlEnabled,
                                MinimumSize = new Size(20, 17),
                                Multiline = controlLines > 1,
                                Tag = propertyInfo,
                                Width = controlWidth,
                            };
                            try
                            {
                                richText.Rtf = val;
                            }
                            catch (Exception)
                            {
                                richText.Text = val;
                            }
                            if (controlLines > 1)
                            {
                                richText.ScrollBars = RichTextBoxScrollBars.Both;
                                richText.Height = richText.Font.Height * controlLines + 7;
                            }
                            control = richText;
                        }
                        else
                        {
                            TextBox textBox = new TextBox
                            {
                                AutoSize = true,
                                Enabled = controlEnabled,
                                MinimumSize = new Size(20, 17),
                                Multiline = controlLines > 1,
                                Tag = propertyInfo,
                                Text = val,
                                Width = controlWidth,
                            };
                            if (controlLines > 1)
                            {
                                textBox.ScrollBars = ScrollBars.Vertical;
                                textBox.Height = textBox.Font.Height * controlLines + 7;
                            }
                            control = textBox;
                        }
                        return control;
                    }
                case "int32":
                    {
                        Int32 val = (Int32)propertyInfo.GetValue(obj, null);
                        MinMaxValueAttribute mmValue =
                            (MinMaxValueAttribute)propertyInfo.GetCustomAttributes(typeof(MinMaxValueAttribute), false).FirstOrDefault();
                        NumericUpDown nud = new NumericUpDown();
                        if (mmValue != null)
                        {
                            nud.Maximum = (decimal)mmValue.Max;
                            nud.Minimum = (decimal)mmValue.Min;

                            if (val < (Int32)mmValue.Min) val = (Int32)mmValue.Min;
                            if (val > (Int32)mmValue.Max) val = (Int32)mmValue.Max;
                        }
                        nud.Enabled = controlEnabled;
                        nud.Value = val;
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
                        nud.Enabled = controlEnabled;
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
                            Enabled = controlEnabled,
                            MinDate = DateTimeExtend.GetCASMinDateTime(),
                            MinimumSize = new Size(20, 17),
                            //AutoSize = true,
                            Tag = propertyInfo,
                            Value = val > DateTimePicker.MinimumDateTime ? new DateTime(val.Ticks) : DateTimePicker.MinimumDateTime
                        };
                    }
                case "bool":
                case "boolean":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new CheckBox
                        {
                            Checked = (bool)val,
                            Enabled = controlEnabled,
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
                        nud.Enabled = controlEnabled;
                        nud.Value = (decimal) (double) val;
                        nud.DecimalPlaces = 2;
                        nud.MinimumSize = new Size(20, 17);
                        nud.Tag = propertyInfo;
                        
                        return nud;
                    }
                case "directivethreshold":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new DirectiveThresholdControl { Enabled = controlEnabled, Threshold = (DirectiveThreshold)val, Tag = propertyInfo };
                    }
                case "detaildirectivethreshold":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new ComponentDirectiveThresholdControl { Enabled = controlEnabled, Threshold = (ComponentDirectiveThreshold)val, Tag = propertyInfo };
                    }
                case "lifelength":
                    {
                        object val = propertyInfo.GetValue(obj, null);
                        return new LifelengthViewer
                        {
                            Enabled = controlEnabled,
                            Lifelength = (Lifelength) val,
                            MinimumSize = new Size(20, 17),
                            Tag = propertyInfo
                        };
                    }
                case "timespan":
                    {
                        TimeSpan val = (TimeSpan)propertyInfo.GetValue(obj, null);
                        return new DateTimePicker
                        {
                            CustomFormat = "HH:mm",
                            Enabled = controlEnabled,
                            Format = DateTimePickerFormat.Custom,
                            MinDate = DateTimeExtend.GetCASMinDateTime(),
                            MinimumSize = new Size(20, 17),
                            //AutoSize = true,
                            ShowUpDown = true,
                            Tag = propertyInfo,
                            Value = DateTime.Today.Add(val)
                        };
                    }
                default:
                    return null;
            }
            #endregion
        }

        #endregion

        #region protected virtual bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetChangeStatus()
        {
            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_currentObject, null);
                    string controlVal = control.Text;
                    if (val != controlVal)
                        return true;
                }
                else if (control is RichTextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_currentObject, null);
                    string controlVal = ((RichTextBox)control).Rtf;
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
                                int val = (int)propertyInfo.GetValue(_currentObject, null);
                                int controlVal = (int)((NumericUpDown)control).Value;
                                if (val != controlVal) 
                                    return true;

                                break;
                            }
                        case "int16":
                            {
                                Int16 val = (Int16)propertyInfo.GetValue(_currentObject, null);
                                Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                                if (val != controlVal)
                                    return true;

                                break;
                            }
                        case "double":
                            {
                                double val = (double)propertyInfo.GetValue(_currentObject, null);
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

                    string typeName = propertyInfo.PropertyType.Name.ToLower();
                    switch (typeName)
                    {
                        case "datetime":
                            {
                                DateTime val = (DateTime)propertyInfo.GetValue(_currentObject, null);
                                if (val != ((DateTimePicker)control).Value)
                                    return true; 
                                break;
                            }
                        case "timespan":
                            {
                                TimeSpan val = (TimeSpan)propertyInfo.GetValue(_currentObject, null);
                                if (val != ((DateTimePicker)control).Value.TimeOfDay)
                                    return true;
                                break;
                            }
                        default:
                            return false;
                    }
                }
                if (control is CheckBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    bool val = (bool)propertyInfo.GetValue(_currentObject, null);
                    bool controlVal = ((CheckBox)control).Checked;
                    if (val != controlVal)
                        return true;
                }
                //if (control is AttachedFileControl)
                //{
                //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                //    if (propertyInfo == null) continue;

                //    AttachedFile val = (AttachedFile)propertyInfo.GetValue(obj, null);
                //    AttachedFile controlVal = ((AttachedFileControl)control).AttachedFile;
                //    if (val != controlVal)
                //        return true;
                //}
                if (control is AttachedFileControl)
                {
                    return ((AttachedFileControl) control).GetChangeStatus();
                }
                if (control is CommonDataGridViewControl)
                {
                    return ((CommonDataGridViewControl)control).GetChangeStatus();
                }
                if (control is LifelengthViewer)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    Lifelength val = (Lifelength)propertyInfo.GetValue(_currentObject, null);
                    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                    if (!val.IsEqual(controlVal))
                        return true;
                }
                if (control is TreeDictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((TreeDictionaryComboBox)control).SelectedItem;
                    if ((val == null && controlVal != null) ||
                        (val != null && !val.Equals(controlVal)))
                        return true;
                }
                if (control is LookupCombobox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((LookupCombobox)control).SelectedItem;
                    if ((val == null && controlVal != null) ||
                        (val != null && !val.Equals(controlVal)))
                        return true;
                }
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if ((val == null && controlVal != null) || 
                        (val != null && !val.Equals(controlVal)))
                        return true;
                }
                if (control is ThresholdControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((ThresholdControl)control).Threshold;
                    if (val.ToString() != controlVal.ToString())
                        return true;
                }
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (!val.Equals(controlVal))
                        return true;
                }
            }

            return false;
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
            foreach (Control control in panelMain.Controls)
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
                        FormControlAttribute fca = (FormControlAttribute)
                            propertyInfo.GetCustomAttributes(typeof (FormControlAttribute), false).First();
                        message += string.Format("'{0}' should not be empty", fca.Title);
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
                        FormControlAttribute fca = (FormControlAttribute)
                            propertyInfo.GetCustomAttributes(typeof(FormControlAttribute), false).First();
                        message += string.Format("'{0}' should not be empty", fca.Title);
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
                if (control is CommonDataGridViewControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) 
                        continue;

                    string m;
                    if (((CommonDataGridViewControl)control).ValidateData(out m))
                        return true;
                    if (m != "") 
                        message += "\n ";
                    message += m;
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
                if (control is TreeDictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object controlVal = ((TreeDictionaryComboBox)control).SelectedItem;
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
                    NotNullAttribute notNullAttribute =
                        (NotNullAttribute)propertyInfo.GetCustomAttributes(typeof(NotNullAttribute), false).FirstOrDefault();

                    if (controlVal == null && notNullAttribute != null)
                    {
                        if (message != "") message += "\n ";

                        message += "Not set " + propertyInfo.Name;
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

        #region protected virtual void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        protected virtual void ApplyChanges()
        {
            foreach (Control control in panelMain.Controls)
            {
                if (control is TextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    if(propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_currentObject, null);
                    string controlVal = control.Text;
                    if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is RichTextBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) 
                        continue;

                    if (propertyInfo.PropertyType.Name.ToLower() != "string") continue;

                    string val = (string)propertyInfo.GetValue(_currentObject, null);
                    string controlVal = ((RichTextBox)control).Rtf;
                    if (val != controlVal) 
                        propertyInfo.SetValue(_currentObject, controlVal, null);
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
                            int val = (int)propertyInfo.GetValue(_currentObject, null);
                            int controlVal = (int)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);

                            break;
                        }
                        case "int16":
                        {
                            Int16 val = (Int16)propertyInfo.GetValue(_currentObject, null);
                            Int16 controlVal = (Int16)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);

                            break;
                        }
                        case "double":
                        {
                            double val = (double)propertyInfo.GetValue(_currentObject, null);
                            double controlVal = (double)((NumericUpDown)control).Value;
                            if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);

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
                                DateTime val = (DateTime)propertyInfo.GetValue(_currentObject, null);
                                DateTime controlVal = ((DateTimePicker)control).Value;
                                if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);
                                break;
                            }
                        case "timespan":
                            {
                                TimeSpan val = (TimeSpan)propertyInfo.GetValue(_currentObject, null);
                                TimeSpan controlVal = ((DateTimePicker)control).Value.TimeOfDay;
                                if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);
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

                    bool val = (bool)propertyInfo.GetValue(_currentObject, null);
                    bool controlVal = ((CheckBox)control).Checked;
                    if (val != controlVal) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is AttachedFileControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    AttachedFileControl fileControl = ((AttachedFileControl) control);
                    AttachedFile val = (AttachedFile)propertyInfo.GetValue(_currentObject, null);
                    AttachedFile controlVal = fileControl.AttachedFile;

                    fileControl.ApplyChanges();

                    if (val != controlVal) 
                        propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is CommonDataGridViewControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) 
                        continue;

                    CommonDataGridViewControl commonDataGridViewControl = ((CommonDataGridViewControl)control);
                    commonDataGridViewControl.ApplyChanges();

                    ICommonCollection val = (ICommonCollection)propertyInfo.GetValue(_currentObject, null);
                    val.Clear();
                    val = commonDataGridViewControl.GetItemsArray();
                    propertyInfo.SetValue(_currentObject, val, null);
                }
                if (control is LifelengthViewer)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) 
                        continue;

                    Lifelength val = (Lifelength)propertyInfo.GetValue(_currentObject, null);
                    Lifelength controlVal = ((LifelengthViewer)control).Lifelength;
                    if (!val.IsEqual(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is ThresholdControl)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((ThresholdControl)control).Threshold;
                    if (val.ToString() != controlVal.ToString())
                        propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is TreeDictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((TreeDictionaryComboBox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is LookupCombobox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((LookupCombobox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is DictionaryComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
                if (control is ComboBox)
                {
                    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    if (propertyInfo == null) continue;

                    object val = propertyInfo.GetValue(_currentObject, null);
                    object controlVal = ((ComboBox)control).SelectedItem;
                    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                }
            }
        }
        #endregion

        #region protected virtual void AbortChanges()
        /// <summary>
        /// Производит откат изменений
        /// </summary>
        protected virtual void AbortChanges()
        {
        }
        #endregion

        #region protected virtual void Save()
        /// <summary>
        /// Производит сохранение объекта в БД
        /// </summary>
        protected virtual void Save()
        {
            if(!_saveChangesToDatabase)
                return;

            try
            {
                foreach (Control control in panelMain.Controls)
                {
                    if (control is AttachedFileControl)
                    {
                        PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                        if (propertyInfo == null) continue;

	                    if (!(_currentObject is IFileContainer))
	                    {
							AttachedFileControl attachedFileControl = ((AttachedFileControl)control);
							attachedFileControl.Save();
						}

                        AttachedFile val = (AttachedFile)propertyInfo.GetValue(_currentObject, null);
                        AttachedFile controlVal = ((AttachedFileControl)control).AttachedFile;
                        if (val != controlVal)
                            propertyInfo.SetValue(_currentObject, controlVal, null);
                    }
                }

                GlobalObjects.CasEnvironment.Manipulator.SaveAll(_currentObject, true);
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
           
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            _animatedThreadWorker.ReportProgress(0, "load templates");

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void LookUpComboBoxSelectedIndexChanged(object sender, EventArgs e)
        private void LookUpComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LookupCombobox lcb = sender as LookupCombobox;
            if(lcb == null) return;

            PropertyInfo lcbPropertyInfo = lcb.Tag as PropertyInfo;
            if (lcbPropertyInfo == null) return;

            BaseEntityObject value = lcb.SelectedItem;
            //определение своиств, имеющих атрибут "отображаемое на форме"
            //и связанных с данныс свойством
            List<PropertyInfo> properties =
                _currentObject.GetType().GetProperties().
                Where(p => p.GetCustomAttributes(typeof(FormControlAttribute), false).Length != 0 &&
                           ((FormControlAttribute)p.GetCustomAttributes(typeof(FormControlAttribute), false).First()).BindToProperty == lcbPropertyInfo.Name &&
                           !string.IsNullOrEmpty(((FormControlAttribute)p.GetCustomAttributes(typeof(FormControlAttribute), false).First()).BindToPropertyPropertyName))
                .ToList();
            
            foreach (PropertyInfo propertyInfo in properties)
            {
                FormControlAttribute fca = (FormControlAttribute)
                        propertyInfo.GetCustomAttributes(typeof (FormControlAttribute), false).First();
                Control control = panelMain.Controls.OfType<Control>().FirstOrDefault(c => c.Tag == propertyInfo);
                if(control == null ) continue;
                if (value == null)
                {
                    if (!fca.EnableIfNotNull)
                    {
                        if (control is TextBoxBase)
                            ((TextBoxBase) control).ReadOnly = false;
                        else control.Enabled = true;
                    }
                }
                else
                {
                    PropertyInfo p = value.GetType().GetProperty(fca.BindToPropertyPropertyName);
                    if (p == null) continue;
                   
                    bool controlEnabled = fca.EnableIfNotNull;
                    object propValue = p.GetValue(value, null);

                    if (control is TextBox)
                    {
                        TextBox tb = (TextBox) control;
                        tb.ReadOnly = !controlEnabled;
                        tb.Text = (propValue as string) ?? "";
                    }
                    if (control is RichTextBox)
                    {
                        RichTextBox rtb = (RichTextBox)control;
                        rtb.ReadOnly = !controlEnabled;
                        rtb.Text = (propValue as string) ?? "";
                    }
                    if (control is NumericUpDown)
                    {
                        NumericUpDown nud = (NumericUpDown)control;
                        nud.Enabled = controlEnabled;

                        string typeName = p.PropertyType.Name.ToLower();
                        switch (typeName)
                        {
                            case "int32":
                            {
                                nud.Value = Convert.ToInt32(propValue);
                                break;
                            }
                            case "int16":
                            {
                                nud.Value = Convert.ToInt16(propValue);
                                break;
                            }    
                            case "double":
                            {
                                nud.Value = (decimal)Convert.ToDouble(propValue);
                                break;
                            }
                        }
                    }
                    if (control is DateTimePicker)
                    {
                        DateTimePicker dtp = (DateTimePicker)control;
                        dtp.Enabled = controlEnabled;

                        string typeName = p.PropertyType.Name.ToLower();
                        switch (typeName)
                        {
                            case "datetime":
                                {
                                    dtp.Value = Convert.ToDateTime(propValue);
                                    break;
                                }
                            case "timespan":
                                {
                                    dtp.Value = DateTime.Today.Add((TimeSpan)propValue);
                                    break;
                                }
                        }
                    }
                    if (control is CheckBox)
                    {
                        CheckBox cb = (CheckBox)control;
                        cb.Enabled = controlEnabled;
                        cb.Checked = propValue != null && (bool)propValue;
                    }
                    if (control is AttachedFileControl)
                    {
                        AttachedFileControl afc = (AttachedFileControl)control;
                        afc.Enabled = controlEnabled;
                        afc.AttachedFile = propValue as AttachedFile;
                    }
                    //if (control is CommonDataGridViewControl)
                    //{
                    //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    //    if (propertyInfo == null)
                    //        continue;

                    //    CommonDataGridViewControl commonDataGridViewControl = ((CommonDataGridViewControl)control);
                    //    commonDataGridViewControl.ApplyChanges();

                    //    ICommonCollection val = (ICommonCollection)propertyInfo.GetValue(_currentObject, null);
                    //    val.Clear();
                    //    val = commonDataGridViewControl.GetItemsArray();
                    //    propertyInfo.SetValue(_currentObject, val, null);
                    //}
                    if (control is LifelengthViewer)
                    {
                        LifelengthViewer llv = (LifelengthViewer)control;
                        llv.Enabled = controlEnabled;
                        llv.Lifelength = propValue as Lifelength;
                    }
                    //if (control is ThresholdControl)
                    //{
                    //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    //    if (propertyInfo == null) continue;

                    //    object val = propertyInfo.GetValue(_currentObject, null);
                    //    object controlVal = ((ThresholdControl)control).Threshold;
                    //    if (val.ToString() != controlVal.ToString())
                    //        propertyInfo.SetValue(_currentObject, controlVal, null);
                    //}
                    if (control is TreeDictionaryComboBox)
                    {
                        TreeDictionaryComboBox tdcb = (TreeDictionaryComboBox)control;
                        tdcb.Enabled = controlEnabled;
                        tdcb.SelectedItem = propValue;
                    }
                    //if (control is DictionaryComboBox)
                    //{
                    //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    //    if (propertyInfo == null) continue;

                    //    object val = propertyInfo.GetValue(_currentObject, null);
                    //    object controlVal = ((DictionaryComboBox)control).SelectedItem;
                    //    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                    //}
                    //if (control is ComboBox)
                    //{
                    //    PropertyInfo propertyInfo = control.Tag as PropertyInfo;
                    //    if (propertyInfo == null) continue;

                    //    object val = propertyInfo.GetValue(_currentObject, null);
                    //    object controlVal = ((ComboBox)control).SelectedItem;
                    //    if (val == null || controlVal == null || !val.Equals(controlVal)) propertyInfo.SetValue(_currentObject, controlVal, null);
                    //}
                }
            }
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

        #region private void FormLoad(object sender, EventArgs e)

        private void FormLoad(object sender, EventArgs e)
        {
            SetFormControls();
        }
        #endregion

        #endregion
    }

}