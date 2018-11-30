using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для представления определенного словаря
    /// </summary>
    [Designer(typeof(DictionaryComboboxDesigner))]
    public partial class TreeDictionaryComboBox : UserControl, IReference
    {
        #region Fields

        private Type _type;
        private string[] _rootNodesNames;
        private ScreenControl _screenControl;
        private IDictionaryCollection _typeItemsCollection;
        private object _selectedItem;
       
        private string _filterString = "";
        private string defaultText = "Select Item";
        private string notApplicableText = "N/A NOT APPLICABLE";
        
        private int _lastSelectedItemId = -1;
        
        #endregion

        #region Implementation of IReference

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        #endregion

        #region public DisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        #endregion

        #region public ReflectionTypes ReflectionType
        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        ///<summary>
        ///</summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для представления определенного словаря
        /// </summary>
        public TreeDictionaryComboBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region protected override Size DefaultSize
        protected override Size DefaultSize
        {
            get
            {
                return new Size(144, PreferredSize.Height);
            }
        }
        #endregion

        #region public int DropDownHeight

        /// <summary>
        /// Высоты выпадающей панели
        /// </summary>
        public int DropDownHeight 
        { 
            get { return treeCombobox.DropDownHeight; } 
            set { treeCombobox.DropDownHeight = value;} 
        }

        #endregion

        //#region  public override Font Font
        ///// <devdoc>
        /////    <para>
        /////       Возвращает или задает шрифт комбобокса.
        /////    </para>
        ///// </devdoc>
        //public override Font Font
        //{
        //    get { return comboBoxReason.Font; }
        //    set
        //    {
        //        comboBoxReason.Font = value;
        //    }
        //}
        //#endregion

        #region public override Color BackColor
        /// <devdoc>
        ///    <para>
        ///       Возвращает или задает цвет заднего фона комбобокса.
        ///    </para>
        /// </devdoc>
        public override Color BackColor
        {
            get { return treeCombobox.BackColor; }
            set { treeCombobox.BackColor = value; }
        }
        #endregion

        #region public override Color ForeColor
        /// <devdoc>
        ///    <para>
        ///       Возвращает или задает цвет шрифта комбобокса.
        ///    </para>
        /// </devdoc>
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                treeCombobox.ForeColor = value;
                buttonEdit.ForeColor = value;
            }
        }
        #endregion

        #region public override Size MaximumSize
        public override Size MaximumSize
        {
            get { return base.MaximumSize; }
            set
            {
                base.MaximumSize = new Size(value.Width, 0);
            }
        }
        #endregion

        #region public override Size MinimumSize
        public override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set
            {
                base.MinimumSize = new Size(value.Width, 0);
            }
        }
        #endregion

        #region public new Padding Padding
        /// <devdoc>
        ///    <para>
        ///    <para>[To be supplied.]</para>
        ///    </para>
        /// </devdoc>
        [Browsable(false),
         EditorBrowsable(EditorBrowsableState.Never),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Padding Padding
        {
            get { return base.Padding; }
            set { base.Padding = value; }
        }
        #endregion

        #region public Type Type { get; set; }
        ///<summary>
        ///</summary>
        public string[] RootNodesNames
        {
            get { return _rootNodesNames; }
            set
            {
                _rootNodesNames = value;
            }
        }
        #endregion

        #region public Type Type { get; set; }
        ///<summary>
        ///</summary>
        public Type Type
        {
            get { return _type; }
            set
            {
                _type = value; 
                if(_type != null)
                    UpdateInformation();
            }
        }
        #endregion

        #region public ScreenControl ScreenControl { get; set; }
        ///<summary>
        ///</summary>
        public ScreenControl ScreenControl
        {
            get { return _screenControl; }
            set
            {
                _screenControl = value;
            }
        }
        #endregion

        #region public Dictionary SelectedItem

        /// <summary>
        /// Выбранный элемент (установка)
        /// </summary>
        public object SelectedItem
        {
            get
            {
                if (treeCombobox != null && treeCombobox.SelectedItem != null
                    && treeCombobox.SelectedItem.ToString() != "N/A")
                    return treeCombobox.SelectedItem;
                return null;
            }
            set
            {
                if (treeCombobox == null) return;
                
                treeCombobox.SelectedItem = value;
                
                _type = treeCombobox.SelectedItem is AbstractDictionary || treeCombobox.SelectedItem is StaticTreeDictionary 
                    ? treeCombobox.SelectedItem.GetType() 
                    : null;
                
                buttonEdit.Enabled = _type != null;
                
                _selectedItem = value;
            }
        }

        #endregion

        #region public TreeNodeCollection Nodes
        /// <summary>
        /// Дерево для добавления элементов
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes
        {
            get { return treeCombobox.Nodes; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void ComboBoxLostFocus(object sender, EventArgs e)

        private void ComboBoxLostFocus(object sender, EventArgs e)
        {
            if (treeCombobox.Text == "")
                treeCombobox.Text = notApplicableText;
            else
                for (int i = 0; i < _typeItemsCollection.Count; i++)
                {
                    IDictionaryItem d = _typeItemsCollection[i];
                    string ataChapter = treeCombobox.Text;
                    int value;
                    if (treeCombobox.Text.Length == 1 && int.TryParse(treeCombobox.Text, out value))
                        ataChapter = "0" + treeCombobox.Text;
                    if (d.FullName.ToLower() == ataChapter.ToLower())
                        Text = d.FullName;
                }
        }

        #endregion

        #region private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)

        private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)
        {
            if (treeCombobox.Text == defaultText || treeCombobox.Text == notApplicableText)
                treeCombobox.Text = "";
        }

        #endregion

        #region private void comboBoxReason_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeCombobox.SelectedItem != null)
            {
                if (treeCombobox.SelectedItem is BaseEntityObject)
                    _lastSelectedItemId = ((BaseEntityObject)treeCombobox.SelectedItem).ItemId;
                else if (treeCombobox.SelectedItem is Enum)
                    _lastSelectedItemId = Convert.ToInt16(treeCombobox.SelectedItem);
                else _lastSelectedItemId = -1;

                _type = treeCombobox.SelectedItem is AbstractDictionary || treeCombobox.SelectedItem is StaticTreeDictionary 
                    ? treeCombobox.SelectedItem.GetType() 
                    : null;
                buttonEdit.Enabled = _type != null;
            }
            else _lastSelectedItemId = -1;

            InvokeSelectedIndexChanged();
        }
        #endregion

        #region private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void DictionaryCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (InvokeRequired) 
                BeginInvoke(new Action(UpdateItems));
            else UpdateItems();
        }
        #endregion

        #region public void ClearValue()

        /// <summary>
        /// Обнуляет выбранную ATA-главу и ставит текст "Select ATA Chapter"
        /// </summary>
        public void ClearValue()
        {
            Text = defaultText;
        }

        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (_screenControl != null && _screenControl.IsDisposed)
                _screenControl = null;
            if (_screenControl == null)
            {
                _screenControl = new CommonListScreen(_type);
            }
            
            //Отписка от событий, что бы они не были подписаны 2 и более раз
            _screenControl.EntityRemoving -= ScreenControlEntityRemoving;
            _screenControl.EntityRemoved -= ScreenControlEntityRemoved;
            //Подписка на события
            _screenControl.EntityRemoving += ScreenControlEntityRemoving;
            _screenControl.EntityRemoved += ScreenControlEntityRemoved;

            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = ReflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                ReferenceEventArgs refe = null != Displayer 
                    ? new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText) 
                    : new ReferenceEventArgs(Entity, reflection, DisplayerText);

                DescriptionAttribute da =
                        _type.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                string typeName = da != null && !string.IsNullOrEmpty(da.Description)
                    ? da.Description
                    : _type.Name;

                refe.DisplayerText = typeName;
                refe.RequestedEntity = _screenControl;
                refe.TypeOfReflection = ReflectionTypes.DisplayInNew;
                DisplayerRequested(this, refe);
            }
        }

        #endregion

        #region private UpdateInformation()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        private void UpdateInformation()
        {
            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;
            
            buttonEdit.Visible = !_type.IsSubclassOf(typeof(StaticDictionary));
            AdjustSizes();

            try
            {
                if (_type.IsSubclassOf(typeof (StaticDictionary)))
                {
                    //поиск своиства Items у типа StaticDictionary
                    PropertyInfo p = _type.GetProperty("Items");

                    ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                    StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                    _typeItemsCollection = (IDictionaryCollection)p.GetValue(instance, null);
                }
                if (_type.IsSubclassOf(typeof(AbstractDictionary)))
                    _typeItemsCollection = GlobalObjects.CasEnvironment.GetDictionary(_type);
            }
            catch (Exception)
            {
                _typeItemsCollection = null;
            }

            UpdateItems();

            LostFocus += ComboBoxLostFocus;
            GotFocus += ATAChapterComboBoxGotFocus;
            
            if (_typeItemsCollection != null)
                _typeItemsCollection.CollectionChanged += DictionaryCollectionChanged;
        }
        #endregion
       
        #region private UpdateItems()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        private void UpdateItems()
        {
            treeCombobox.Nodes.Clear();
            treeCombobox.Nodes.Add("N/A");
            if(_typeItemsCollection != null)
            {
                try
                {
                    if (_type.IsSubclassOf(typeof(StaticTreeDictionary)))
                    {
                        if (_rootNodesNames == null || _rootNodesNames.Length <= 0)
                        {
                            //поиск своиства Roots у типа StaticDictionary
                            PropertyInfo p = _type.GetProperty("Roots");

                            ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                            StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                            IDictionaryCollection roots = (IDictionaryCollection)p.GetValue(instance, null);

                            StaticTreeDictionary currentNode = roots[0] as StaticTreeDictionary;
                            if (currentNode == null)
                                return;
                            TreeNode currentParent = null;
                            while (currentNode != null)
                            {
                                TreeNode newNode = new TreeNode { Text = currentNode.ToString(), Name = currentNode.ToString(), };
                                //if (currentNode.Children.Count == 0)
                                    newNode.Tag = currentNode;

                                if (currentParent == null)
                                {
                                    Nodes.Add(newNode);
                                }
                                else
                                {
                                    currentParent.Nodes.Add(newNode);
                                }

                                if (currentNode.Children.Count > 0)
                                {
                                    //Если у выбранного узла есть подузлы - осуществляется переход на первый подузел
                                    currentNode = currentNode.Children[0] as StaticTreeDictionary;
                                    currentParent = newNode;
                                }
                                else
                                {
                                    //У выбранного узла подузлов нет
                                    if (currentNode.Next != null)
                                    {
                                        //Если есть след. узел на этом уровне - переход на него
                                        currentNode = currentNode.Next;
                                    }
                                    else
                                    {
                                        //На данном уровне след. узла нет.
                                        StaticTreeDictionary parent = currentNode.Parent;
                                        while (parent != null)
                                        {
                                            currentParent = currentParent != null ? currentParent.Parent : null;
                                            //Переход вверх по дереву до тех пор, пока на уровне не появится след.узел
                                            //переход на след. узел на верхнем уровне
                                            if (parent.Next != null)
                                            {
                                                currentNode = parent.Next;
                                                break;
                                            }
                                            parent = parent.Parent;
                                        }

                                        if (parent == null)
                                            currentNode = null;
                                    }
                                }
                            }   
                        }
                        else
                        {
                            ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                            object instance = ci.Invoke(null);

                            foreach (string rootNodeName in _rootNodesNames)
                            {
                                //поиск своиства Roots у типа StaticDictionary
                                //PropertyInfo[] typeProperties = _type.GetField(BindingFlags.Public | BindingFlags.Static);
                                FieldInfo p = _type.GetField(rootNodeName);
                                //p = typeProperties.FirstOrDefault(prop => prop.Name == rootNodeName);
                                if(p == null)
                                    continue;
                                StaticTreeDictionary currentRoot = p.GetValue(instance) as StaticTreeDictionary;
                                StaticTreeDictionary currentNode = currentRoot;
                                if (currentNode == null)
                                    return;
                                TreeNode currentParent = null;
                                while (currentNode != null)
                                {
                                    TreeNode newNode = new TreeNode { Text = currentNode.ToString(), Name = currentNode.ToString(), };
                                    //if (currentNode.Children.Count == 0)
                                        newNode.Tag = currentNode;

                                    if (currentParent == null)
                                    {
                                        Nodes.Add(newNode);
                                    }
                                    else
                                    {
                                        currentParent.Nodes.Add(newNode);
                                    }

                                    if (currentNode.Children.Count > 0)
                                    {
                                        //Если у выбранного узла есть подузлы - осуществляется переход на первый подузел
                                        currentNode = currentNode.Children[0] as StaticTreeDictionary;
                                        currentParent = newNode;
                                    }
                                    else
                                    {
                                        if (currentNode == currentRoot)
                                            break;
                                        //У выбранного узла подузлов нет
                                        if (currentNode.Next != null)
                                        {
                                            //Если есть след. узел на этом уровне - переход на него
                                            currentNode = currentNode.Next;
                                        }
                                        else
                                        {
                                            //На данном уровне след. узла нет.
                                            StaticTreeDictionary parent = currentNode.Parent;
                                            while (parent != null && parent != currentRoot)
                                            {
                                                currentParent = currentParent != null ? currentParent.Parent : null;
                                                //Переход вверх по дереву до тех пор, пока на уровне не появится след.узел
                                                //переход на след. узел на верхнем уровне
                                                if (parent.Next != null)
                                                {
                                                    currentNode = parent.Next;
                                                    break;
                                                }
                                                parent = parent.Parent;
                                            }

                                            if (parent == null || parent == currentRoot)
                                                currentNode = null;
                                        }
                                    }
                                }   
                            }     
                        }
                    }
                    if (_type.IsSubclassOf(typeof (AbstractDictionary)))
                    {
                        foreach (IDictionaryItem dic in _typeItemsCollection)
                            treeCombobox.Nodes.Add(new TreeNode { Text = dic.ToString(), Tag = dic });
                    }

                    if (_lastSelectedItemId > 0)
                        treeCombobox.SelectedItem = _typeItemsCollection.GetItemById(_lastSelectedItemId);
                }
                catch (Exception)
                {
                    _typeItemsCollection = null;
                }
            }
            
            if (_selectedItem != null)
                treeCombobox.SelectedItem = _selectedItem;
            else treeCombobox.Text = defaultText;
            treeCombobox.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion

        #region private void AdjustSizes()
        private void AdjustSizes()
        {
            Height = treeCombobox.PreferredHeight;

            int comboboxWidth = Width;
            if (buttonEdit.Visible)
                comboboxWidth -= buttonEdit.Width;
            treeCombobox.Width = comboboxWidth;
            treeCombobox.DropDownWidth = Width;
        }
        #endregion

        #region protected override void OnFontChanged(EventArgs e)
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Height = treeCombobox.PreferredHeight;
            treeCombobox.Width = Width - buttonEdit.Width;
        }
        #endregion

        #region private void ScreenControlEntityRemoving(object sender, EntityCancelEventArgs e)

        private void ScreenControlEntityRemoving(object sender, EntityCancelEventArgs e)
        {
            if(e.Entity == _screenControl)
                e.Cancel = true;
        }
        #endregion

        #region private void ScreenControlEntityRemoved(object sender, EventArgs e)

        private void ScreenControlEntityRemoved(object sender, EventArgs e)
        {
            _screenControl.EntityRemoving -= ScreenControlEntityRemoving;
            _screenControl.EntityRemoved -= ScreenControlEntityRemoved;
        }
        #endregion

        #region private void ComboBoxReasonTextUpdate(object sender, EventArgs e)
        private void ComboBoxReasonTextUpdate(object sender, EventArgs e)
        {
            _filterString = treeCombobox.Text;

            if (string.IsNullOrEmpty(_filterString))
                UpdateItems();
            else
            {
                treeCombobox.Nodes.Clear();
                treeCombobox.Nodes.Add("N/A");

                if (_typeItemsCollection != null)
                {
                    try
                    {
                        if (_type.IsSubclassOf(typeof(StaticTreeDictionary)))
                        {
                            if (_rootNodesNames == null || _rootNodesNames.Length <= 0)
                            {
                                //поиск своиства Roots у типа StaticDictionary
                                PropertyInfo p = _type.GetProperty("Items");

                                ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                                StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

                                IDictionaryCollection items = (IDictionaryCollection)p.GetValue(instance, null);

                                foreach (IDictionaryTreeItem dic in items
                                                     .OfType<IDictionaryTreeItem>()
                                                     .Where(i => i.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
                                {
                                    treeCombobox.Nodes.Add(new TreeNode { Text = dic.ToString(), Name = dic.ToString(), Tag = dic});
                                }

                                buttonEdit.Enabled = false;
                            }
                            else
                            {
                                ConstructorInfo ci = _type.GetConstructor(new Type[0]);
                                object instance = ci.Invoke(null);

                                foreach (string rootNodeName in _rootNodesNames)
                                {
                                    //поиск своиства Roots у типа StaticDictionary
                                    FieldInfo p = _type.GetField(rootNodeName);
                                    if (p == null)
                                        continue;
                                    StaticTreeDictionary currentRoot = p.GetValue(instance) as StaticTreeDictionary;
                                    StaticTreeDictionary currentNode = currentRoot;
                                    if (currentNode == null)
                                        return;
                                    while (currentNode != null)
                                    {
                                        if (currentNode.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant()))
                                        {
                                            TreeNode newNode = new TreeNode
                                            {
                                                Text = currentNode.ToString(),
                                                Name = currentNode.ToString(),
                                                Tag = currentNode,
                                            };
                                            Nodes.Add(newNode);
                                        }
                                        if (currentNode.Children.Count > 0)
                                        {
                                            //Если у выбранного узла есть подузлы - осуществляется переход на первый подузел
                                            currentNode = currentNode.Children[0] as StaticTreeDictionary;
                                        }
                                        else
                                        {
                                            //У выбранного узла подузлов нет
                                            if (currentNode.Next != null)
                                            {
                                                //Если есть след. узел на этом уровне - переход на него
                                                currentNode = currentNode.Next;
                                            }
                                            else
                                            {
                                                //На данном уровне след. узла нет.
                                                StaticTreeDictionary parent = currentNode.Parent;
                                                while (parent != null && parent != currentRoot)
                                                {
                                                    //Переход вверх по дереву до тех пор, пока на уровне не появится след.узел
                                                    //переход на след. узел на верхнем уровне
                                                    if (parent.Next != null)
                                                    {
                                                        currentNode = parent.Next;
                                                        break;
                                                    }
                                                    parent = parent.Parent;
                                                }

                                                if (parent == null || parent == currentRoot)
                                                    currentNode = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (_type.IsSubclassOf(typeof(AbstractDictionary)))
                        {
                            foreach (IDictionaryItem dic in _typeItemsCollection)
                                treeCombobox.Nodes.Add(new TreeNode { Text = dic.ToString(), Tag = dic });
                        }
                    }
                    catch (Exception)
                    {
                        _typeItemsCollection = null;
                    }
                }
                treeCombobox.DropDownStyle = ComboBoxStyle.DropDown;
                treeCombobox.SelectionStart = _filterString.Length;
            }
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AdjustSizes();
        }
        #endregion

        #endregion

        #region Events

        #region public new event EventHandler PaddingChanged
        ///<summary>
        /// Происходит при заполении элемента управления
        ///</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { base.PaddingChanged += value; }
            remove { base.PaddingChanged -= value; }
        }
        #endregion

        #region public event EventHandler SelectedIndexChanged;
        ///<summary>
        /// Возникает при изменении выбора в элементе управления
        ///</summary>
        [Category("Value changed")]
        [Description("Возникает при изменении выборав элементе управления")]
        public event EventHandler SelectedIndexChanged;

        ///<summary>
        /// Сигнализирует об изменении выбора в элементе управления
        ///</summary>
        private void InvokeSelectedIndexChanged()
        {
            EventHandler handler = SelectedIndexChanged;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #endregion
    }
}
