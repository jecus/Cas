using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.OpepatorsControls;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение информации об операторе или коллекции шаблонных ВС
    ///</summary>
    public partial class AbstractOperatorHeaderControl : UserControl
    {

        #region Fields

        private Operator _currentOperator;
        private bool _operatorClickable;

        private bool _nextClickable;
        private bool _prevClickable;

        private BaseEntityObject _child;
        private bool _childClickable;
        private RichReferenceButton _childButton;
        private readonly Color _normalColor = Color.FromArgb(122, 122, 122);
        private readonly Color _selectColor = Color.FromArgb(150, 150, 150);
        //private readonly Icons icons = new Icons();

        

        #endregion

        #region Properties

        #region public IDisplayer CurrentDisplayer
        private IDisplayer _currentDisplayer;
        ///<summary>
        /// Указывает на отобрахаемый скрин
        ///</summary>
        public IDisplayer CurrentDisplayer
        {
            get { return _currentDisplayer; }
            set
            {
                _currentDisplayer = value;
                if (_currentDisplayer != null)
                {
                    _currentDisplayer.ScreenChanged += CurrentDisplayerScreenChanget;
                }
            }
        }
        #endregion

        #region void CurrentDisplayerScreenChanget(object sender, EventArgs e)
        void CurrentDisplayerScreenChanget(object sender, EventArgs e)
        {
            previousButton.Enabled = _currentDisplayer.CanPreviousPage();
            nextButton.Enabled=_currentDisplayer.CanNextPage();
        }
        #endregion

        #endregion

        #region Constructor

        #region public AbstractOperatorHeaderControl()

        ///<summary>
        /// Создается новый объект отображения оператора
        ///</summary>
        
        public AbstractOperatorHeaderControl()
        {
            InitializeComponent();
        }

        #endregion
       
        #endregion

        #region Properties

        #region public RichReferenceButton LogotypeButton

        /// <summary>
        /// Возвращает кнопку, которая отображает иконку оператора
        /// </summary>
        public RichReferenceButton LogotypeButton
        {
            get
            {
                return logotypeButton;
            }
        }

        #endregion

        #region public RichReferenceButton TitleButton

        /// <summary>
        /// Возвращает кнопку, которая отображает название оператора
        /// </summary>
        public RichReferenceButton TitleButton
        {
            get
            {
                return titleButton;
            }
        }

        #endregion

        #region public RichReferenceButton PreviousButton

        /// <summary>
        /// Возвращает кнопку "Назад"
        /// </summary>
        public RichReferenceButton PreviousButton
        {
            get { return previousButton; }
        }

        #endregion

        #region public RichReferenceButton NextButton

        /// <summary>
        /// Возвращает кнопку "Вперед"
        /// </summary>
        public RichReferenceButton NextButton
        {
            get { return nextButton; }
        }

        #endregion

        #region public bool NextClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли элемент "След. экран" навигационного контрола нажатия
        /// </summary>
        public bool NextClickable
        {
            get
            {
                return _nextClickable;
            }
            set
            {
                _nextClickable = value;
                nextButton.Cursor = _nextClickable ? Cursors.Hand : Cursors.Default;
            }
        }

        #endregion

        #region public bool OperatorClickable

        /// <summary>
        /// Возвращет или устанавливает значение, показывающее нужно ли переходить на какую-либо страницу, 
        /// при клике на иконку или текст
        /// </summary>
        public bool OperatorClickable
        {
            get
            {
                return _operatorClickable;
            }
            set
            {
                _operatorClickable = value;
                UpdateOperatorHeaderControl();
            }
        }

        #endregion

        #region public Operator Operator

        /// <summary>
        /// Возвращает или устанавливает текущий эксплуатант
        /// </summary>
        public Operator Operator
        {
            get
            {
                return _currentOperator;
            }
            set
            {

                if (_currentOperator != null) 
                    _currentOperator.PropertyChanged -= CurrentOperatorPropertyChanged;

                _currentOperator = value;

                if (_currentOperator != null)
                {
                    _currentOperator.PropertyChanged += CurrentOperatorPropertyChanged;
                    UpdateOperatorInfo(_currentOperator);
                }
            }
        }
        #endregion

        #region public bool PrevClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли элемент "Пред. экран" навигационного контрола нажатия
        /// </summary>
        public bool PrevClickable
        {
            get
            {
                return _prevClickable;
            }
            set
            {
                _prevClickable = value;
                previousButton.Cursor = _prevClickable ? Cursors.Hand : Cursors.Default;
            }
        }

        #endregion

        #region public BaseSmartCoreObject Child
        /// <summary>
        /// </summary>
        public BaseEntityObject Child
        {
            get { return _child; }
            set
            {
                if (value != null && value is Aircraft)
                    Aircraft = (Aircraft) value;
                else if (value != null && value is Store)
                    Store = (Store) value;
                else
                {
                    _child = value;
                    if (value == null)
                    {
                        if (_childButton != null)
                        {
                            _childButton.TextMain = "UNK";
                            _childButton.TextSecondary = "unk";
                        }
                    }
                    else
                    {
                        CreateChild();
                        _childButton.TextMain = value.ToString();
                        _childButton.TextSecondary = "";
                    }
                }
            }
        }

        #endregion

        #region public Aircraft Aircraft
        /// <summary>
        /// </summary>
        public Aircraft Aircraft
        {
            get { return _child as Aircraft; }
            set
            {
                _child = value;
                if (value == null)
                {
                    if(_childButton != null)
                    {
                        _childButton.TextMain = "UNK";
                        _childButton.TextSecondary = "unk";   
                    }
                }
                else
                {
                    CreateChild();
                    _childButton.TextMain = value.RegistrationNumber;
                    _childButton.TextSecondary = value.Model.ToString();
                    
                    StringBuilder b = new StringBuilder();
                    b.AppendLine("Reg.Num: " + value.RegistrationNumber);
                    b.AppendLine("Model: " + value.Model.ShortName);
                    b.AppendLine("L/N: " + value.LineNumber);
                    b.AppendLine("S/N: " + value.SerialNumber);
                    b.AppendLine("V/N: " + value.VariableNumber);
                    _childButton.ShowToolTip = true;
                    _childButton.ToolTipText = b.ToString();
                    Operator = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == value.OperatorId);
                }
            }
        }

        #endregion

        #region public Store Store
        /// <summary>
        /// </summary>
        public Store Store
        {
            get { return _child as Store; }
            set
            {
                _child = value;
                if (value == null)
                {
                    if (_childButton != null)
                    {
                        _childButton.TextMain = "UNK";
                        _childButton.TextSecondary = "unk";
                    }
                }
                else
                {
                    CreateChild();
                    _childButton.TextMain = value.Name;
                    _childButton.TextSecondary = value.Location;
                    Operator = value.Operator;
                }
            }
        }

        #endregion
        
        #region public bool ChildClickable
        /// <summary>
        /// Возврашает или задает значение того, обрабатывает ли 1-й дочерний элемент нажатия
        /// </summary>
        public bool ChildClickable
        {
            get { return _childClickable; }
            set
            {
                _childClickable = value;
                if (_childButton == null)
                    return;
                _childButton.Cursor = _childClickable ? Cursors.Hand : Cursors.Default;
            }
        }

        #endregion
       
        #endregion

        #region Methods

        #region protected void UpdateOperatorInfo(Operator op)

        /// <summary>
        /// Обновить информацию по оператору
        /// </summary>
        protected void UpdateOperatorInfo(Operator op)
        {
            if(op == null)return;
            TitleButton.TextMain = op.Name;
            TitleButton.ChangeWidth();
            TitleButton.DisplayerText = op.Name;
            TitleButton.ReflectionType = ReflectionTypes.DisplayInCurrent;
            LogotypeButton.Icon = op.LogoTypeImage;
            LogotypeButton.DisplayerText = op.Name;
            LogotypeButton.ReflectionType = ReflectionTypes.DisplayInCurrent;
        }

        #endregion

        #region private void UpdateOperatorHeaderControl()

        /// <summary>
        /// Обновляется отображение элментов управления
        /// </summary>
        private void UpdateOperatorHeaderControl()
        {
            if (_operatorClickable)
            {
                logotypeButton.Cursor = Cursors.Hand;
                titleButton.Cursor = Cursors.Hand;
                
            }
            else
            {
                logotypeButton.Cursor = Cursors.Default;
                titleButton.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region private void CreateChild()
        private void CreateChild()
        {
            if (_childButton == null)
            {
                _childButton = new RichReferenceButton();
                _childButton.Icon = Properties.Resources.GreenArrow;
                _childButton.IconLayout = ImageLayout.Center;
                _childButton.ReflectionType = ReflectionTypes.DisplayInNew;
                _childButton.Dock = DockStyle.Left;
                _childButton.Size = new Size(270, 47);
                _childButton.PaddingMain = new Padding(0, 8, 0, 0);
                _childButton.FontMain = new Font("Verdana", 16, GraphicsUnit.Pixel);
                _childButton.ForeColorMain = Css.OrdinaryText.Colors.ForeColor;
                _childButton.ForeColorSecondary = Css.OrdinaryText.Colors.ForeColor;
                _childButton.DisplayerRequested += ChildDisplayerRequested;

                if(splitViewer1.ControlsAmount < 5) splitViewer1.ControlsAmount = 5;
                splitViewer1[4] = _childButton;
            }   
        }
        #endregion

        #region private void LogotypeButtonMouseMove(object sender, MouseEventArgs e)

        private void LogotypeButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (_operatorClickable)
                titleButton.ForeColor = _selectColor;
        }

        #endregion

        #region private void LogotypeButtonMouseLeave(object sender, EventArgs e)

        private void LogotypeButtonMouseLeave(object sender, EventArgs e)
        {
            if (_operatorClickable)
                titleButton.ForeColor = _normalColor;
        }

        #endregion

        #region private void LogotypeButtonDisplayerRequested(object sender, ReferenceEventArgs e);

        private void LogotypeButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (_currentOperator != null && _operatorClickable)
            {
                e.DisplayerText = _currentOperator.Name;
#if DEBUG
                e.RequestedEntity = new OperatorSymmaryDemoScreen(_currentOperator);
#else
                e.RequestedEntity = new OperatorSymmaryDemoScreen(_currentOperator);
#endif
                Keyboard keyboard = new Keyboard();
                e.TypeOfReflection = keyboard.ShiftKeyDown ? ReflectionTypes.DisplayInNew : ReflectionTypes.DisplayInCurrent;
            }
            else
                e.Cancel = true;    
        }

        #endregion

        #region private void PreviousButtonDisplayerRequested(object sender, ReferenceEventArgs e)

        private void PreviousButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (_currentDisplayer != null && _prevClickable)
            {
                _currentDisplayer.PreviousPage();
            }
            //e.TypeOfReflection = ReflectionTypes.DisplayPreviousPage;
        }

        #endregion

        #region private void NextButtonDisplayerRequested(object sender, ReferenceEventArgs e)

        private void NextButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (_currentDisplayer!=null && _nextClickable)
            {
                _currentDisplayer.NextPage();
            }
            //e.TypeOfReflection = ReflectionTypes.DisplayNextPage;
        }

        #endregion

        #region private void ChildDisplayerRequested(object sender, ReferenceEventArgs e);

        private void ChildDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (_child == null || !_childClickable || (!(_child is Aircraft) && !(_child is Store)))
            {
                e.Cancel = true;
                return;
            }

            Keyboard keyboard = new Keyboard();
            e.TypeOfReflection = keyboard.ShiftKeyDown ? ReflectionTypes.DisplayInNew : ReflectionTypes.DisplayInCurrent;
            if(_child is Aircraft)
            {
                Aircraft a = _child as Aircraft;
                e.DisplayerText = a.RegistrationNumber;
                //e.RequestedEntity = new DispatcheredAircraftScreen(a);
                e.RequestedEntity = new AircraftScreen(a);
            }
            if (_child is Store)
            {
                Store s = _child as Store;
                e.DisplayerText = s.Operator.Name + " : " + s.Name;
                e.RequestedEntity = new StoreScreen(s);    
            }
        }

        #endregion

        #region void CurrentOperatorPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        void CurrentOperatorPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateOperatorInfo(_currentOperator);
        }
        #endregion

        #endregion

    }
}