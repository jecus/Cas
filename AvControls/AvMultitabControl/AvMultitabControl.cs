#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AvControls.AvMultitabControl.Auxiliary;
using AvControls.AvMultitabControl.Design;
using AvControls.Properties;

#endregion

namespace AvControls.AvMultitabControl
{
    /// <summary>
    /// Мульти-страничный контрол
    /// </summary>
    [DefaultProperty("TabPages"), Designer(typeof (AvMultitabControlDesigner)), ToolboxItem(true)]
    public class AvMultitabControl : ContainerControl
    {
        #region Delegates

        public delegate void AvMultitabControlCancelEventHandler(object sender, AvMultitabControlCancelEventArgs e);

        public delegate void AvMultitabControlEventHandler(object sender, AvMultitabControlEventArgs e);

        #endregion

        private readonly Size _inActiveTabAngleSize = new Size(6, 6);
        private readonly Size _serviceButtonSize = new Size(0x10, 15);
        /// <summary>
        /// Контекстное меню для открытых в вкладок
        /// </summary>
        private readonly ContextMenuStrip _activePagesMenu = new ContextMenuStrip();
        private readonly Font _avMultitabActiveFont = new Font("Tahoma", 8.25f, FontStyle.Bold);
        private readonly Font _avMultitabInactiveFont = new Font("Tahoma", 8.25f, FontStyle.Regular);
        private readonly ServiceButton _closeButton;
        private readonly AvProfessionalColorTable _colorTable;
        private readonly Size _defaultSize = new Size(240, 20);
        private readonly ServiceButton _dropDownButton;
        private readonly ContextMenuStrip _switchPagesMenu = new ContextMenuStrip();
        private readonly TabPageCollection _tabPages;
        private readonly List<int> _titlePosition = new List<int>();
        private readonly List<int> _titleWidth = new List<int>();
        private readonly ToolTip _toolTip;
        private const int ToolTipDelay = 5;

        private Color _activeBorderColor = Color.FromArgb(0x7f, 0x9d, 0xb9);
        private Color _activeBottomColor = Color.FromArgb(0xff, 0xff, 0xff);
        private Color _activeElementBgColor = Color.FromArgb(0xc1, 210, 0xee);
        private Color _activeElementBorderColor = Color.FromArgb(0x31, 0x6a, 0xc5);
        private string _activeTabsButtonHint = "Active Tabs";
        private Color _activeTopColor = Color.FromArgb(0xff, 0xff, 0xff);
        private Color _backColor = Color.FromArgb(0xe4, 0xe2, 0xd5);
        private string _closeButtonHint = "Close";
        private bool closeFirstPage = true;
        private IContainer components;
        private Point _currentCursorLocation;
        private Color _inactiveBorderColor = Color.FromArgb(0xac, 0xa8, 0x99);
        private Color _inactiveBottomColor = Color.FromArgb(0xf1, 0xef, 0xe2);
        private Color _inactiveTopColor = Color.FromArgb(0xfe, 0xfd, 0xfd);
        private int _maxTabWidth = 0xb9;
        private int _oldControlWidth;
        private MultitabPage _selectedTab;
        private bool _showToolTips = true;
        private int _switchPagesMenuCurrentItem;
        private string _toolTipText = "";
        private bool _toolTipTextAlreadyShown;
        private int _visiblePagesCount;

        public AvMultitabControl()
        {
            _tabPages = new TabPageCollection(this);
            TabPages.CollectionChanged += TabPagesCollectionChanged;
            _closeButton = new ServiceButton(Resources.AvMultitabCloseButton, Resources.AvMultitabCloseButtonInactive);
            _closeButton.FlatAppearance.MouseOverBackColor = ActiveElementBgColor;
            _closeButton.ActiveBorderColor = ActiveBorderColor;
            _closeButton.BackColor = BackColor;
            _closeButton.Size = _serviceButtonSize;
            _closeButton.Name = "closeButton";
            _closeButton.UseVisualStyleBackColor = true;
            _closeButton.Enabled = false;
            _closeButton.MouseClick += CloseButtonMouseClick;
            _closeButton.GotFocus += CloseButtonGotFocus;
            _dropDownButton = new ServiceButton(Resources.AvMultitabDropDownButton,
                                               Resources.AvMultitabDropDownButtonInactive);
            _dropDownButton.FlatAppearance.MouseOverBackColor = ActiveElementBgColor;
            _dropDownButton.ActiveBorderColor = ActiveBorderColor;
            _dropDownButton.BackColor = BackColor;
            _dropDownButton.Size = _serviceButtonSize;
            _dropDownButton.Name = "dropDownButton";
            _dropDownButton.UseVisualStyleBackColor = true;
            _dropDownButton.Enabled = false;
            _dropDownButton.MouseClick += DropDownButtonMouseClick;
            _dropDownButton.GotFocus += DropDownButtonGotFocus;
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(_closeButton, CloseButtonHint);
            _toolTip.SetToolTip(_dropDownButton, ActiveTabsButtonHint);
            Controls.Add(_closeButton);
            Controls.Add(_dropDownButton);
            _colorTable = new AvProfessionalColorTable(this);
            _activePagesMenu.Renderer = new ToolStripProfessionalRenderer(_colorTable);
            _switchPagesMenu.KeyUp += SwitchPagesMenuKeyUp;
            _switchPagesMenu.KeyDown += SwitchPagesMenuKeyDown;
            _switchPagesMenu.Renderer = new ToolStripProfessionalRenderer(_colorTable);
            InitializeComponent();
        }

        [Description("Цвет границы активной вкладки"), Category("Appearance")]
        public Color ActiveBorderColor
        {
            get { return _activeBorderColor; }
            set
            {
                _activeBorderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Нижний цвет градиента для заголовка активной вкладки")]
        public Color ActiveBottomColor
        {
            get { return _activeBottomColor; }
            set
            {
                _activeBottomColor = value;
                base.Invalidate();
            }
        }

        [Description("Цвет фона активного элемента"), Category("Appearance")]
        public Color ActiveElementBgColor
        {
            get { return _activeElementBgColor; }
            set
            {
                _activeElementBgColor = value;
                CloseButton.FlatAppearance.MouseOverBackColor = _activeElementBgColor;
                DropDownButton.FlatAppearance.MouseOverBackColor = _activeElementBgColor;
            }
        }

        [Category("Appearance"), Description("Цвет границы активного элемента")]
        public Color ActiveElementBorderColor
        {
            get { return _activeElementBorderColor; }
            set
            {
                _activeElementBorderColor = value;
                CloseButton.ActiveBorderColor = _activeElementBorderColor;
                DropDownButton.ActiveBorderColor = _activeElementBorderColor;
            }
        }

        [Browsable(false)]
        public ContextMenuStrip ActivePagesMenu
        {
            get { return _activePagesMenu; }
        }

        [Category("HintTexts"), Description("Текст подсказки, при наведении мышкой на кнопку выпадающего меню")]
        public string ActiveTabsButtonHint
        {
            get { return _activeTabsButtonHint; }
            set
            {
                if (value == null)
                {
                    _activeTabsButtonHint = "";
                }
                else
                {
                    _activeTabsButtonHint = value;
                }
            }
        }

        [Category("Appearance"), Description("Верхний цвет градиента для заголовка активной вкладки")]
        public Color ActiveTopColor
        {
            get { return _activeTopColor; }
            set
            {
                _activeTopColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Цвет фона на заднем плане элемента управления")]
        public override Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                _dropDownButton.BackColor = value;
                _closeButton.BackColor = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public int BorderSize
        {
            get { return 1; }
        }

        [Browsable(false)]
        public ServiceButton CloseButton
        {
            get { return _closeButton; }
        }

        [Category("HintTexts"), Description("Текст подсказки, при наведении мышкой на кнопку закрытия вкладки")]
        public string CloseButtonHint
        {
            get { return _closeButtonHint; }
            set
            {
                if (value == null)
                {
                    _closeButtonHint = "";
                }
                else
                {
                    _closeButtonHint = value;
                }
            }
        }

        protected override Size DefaultSize
        {
            get { return _defaultSize; }
        }

        [Browsable(false)]
        public ServiceButton DropDownButton
        {
            get { return _dropDownButton; }
        }

        [Description("Цвет границы неактивной вкладки"), Category("Appearance")]
        public Color InactiveBorderColor
        {
            get { return _inactiveBorderColor; }
            set
            {
                _inactiveBorderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Нижний цвет градиента для заголовка неактивной вкладки")]
        public Color InactiveBottomColor
        {
            get { return _inactiveBottomColor; }
            set
            {
                _inactiveBottomColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Верхний цвет градиента для заголовка неактивной вкладки")]
        public Color InactiveTopColor
        {
            get { return _inactiveTopColor; }
            set
            {
                _inactiveTopColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("Максимальная ширина отдельной вкладки в пикселях")]
        public int MaxTabWidth
        {
            get { return _maxTabWidth; }
            set
            {
                if ((value < 120) || (value > (0.8*Width)))
                {
                    throw new ArgumentOutOfRangeException("value",
                                                          "Width of tab must be greater than 120px and less than 80% of control's width");
                }
                _maxTabWidth = value;
            }
        }

        /// <summary>
        /// Возвращает или задает выбранную вкладку
        /// </summary>
        [Browsable(false)]
        public MultitabPage SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                if (((value != null) && (TabPages.Count != 0)) && (value != _selectedTab))
                {
                    if (!TabPages.Contains(value))
                    {
                        throw new ArgumentException("This tab doesn't exist in collection", "value");
                    }
                    if (TabPages.Contains(_selectedTab))
                    {
                        TabPages[TabPages.IndexOf(_selectedTab)].Hide();
                    }
                    _selectedTab = value;
                    if (TabPages.IndexOf(_selectedTab) < (TabPages.Count - _visiblePagesCount))
                    {
                        TabPages.Remove(_selectedTab);
                        TabPages.Insert(TabPages.Count, _selectedTab);
                    }
                    TabPages[TabPages.IndexOf(_selectedTab)].Show();
                }
            }
        }

        [Category("Behavior"), Description("Отображение подсказок для отдельных вкладок")]
        public bool ShowToolTips
        {
            get { return _showToolTips; }
            set
            {
                if (_showToolTips != value)
                {
                    if (value)
                    {
                        _toolTip.SetToolTip(DropDownButton, ActiveTabsButtonHint);
                        _toolTip.SetToolTip(CloseButton, CloseButtonHint);
                    }
                    else
                    {
                        _toolTip.RemoveAll();
                    }
                    _showToolTips = value;
                }
            }
        }

        [Browsable(false)]
        public int TabCount
        {
            get { return TabPages.Count; }
        }

        [Description("Коллекция вкладок, относящихся к данному элементу управления"),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Category("Behavior")]
        public TabPageCollection TabPages
        {
            get { return _tabPages; }
        }

        [Browsable(false)]
        public int TitleHeight
        {
            get { return 20; }
        }

        public virtual Type TypeOfPages
        {
            get { return typeof(MultitabPage); }
        }

        public event AvMultitabControlEventHandler Closed;

        public event AvMultitabControlCancelEventHandler Closing;

        public event AvMultitabControlEventHandler Deselected;
        /// <summary>
        /// Событие, оповещающее об начале снятия выбора в мультивкладочном контроле
        /// </summary>
        public event AvMultitabControlCancelEventHandler Deselecting;
        /// <summary>
        /// Вызывается при смене текущей вкладки MultiTab Control-а
        /// </summary>
        public event AvMultitabControlEventHandler Selected;

        public event AvMultitabControlCancelEventHandler Selecting;

        private void AvMultitabControlControlAdded(object sender, ControlEventArgs e)
        {
            if (!(e.Control is MultitabPage) && !(e.Control is ServiceButton))
            {
                Controls.Remove(e.Control);
            }
        }

        private void AvMultitabControlKeyDown(object sender, KeyEventArgs e)
        {
            if (TabPages.Count == 0) return;
            if ((e.Control && (e.KeyCode == Keys.F4)) || (e.Control && (e.KeyCode == Keys.W)))
            {
                CloseTab(SelectedTab);
            }
            if ((e.Control && (e.KeyCode == Keys.Tab)) || ((e.Control && e.Shift) && (e.KeyCode == Keys.Tab)))
            {
                _switchPagesMenu.Hide();
                _switchPagesMenu.Items.Clear();
                _switchPagesMenuCurrentItem = 0;
                foreach (MultitabPage t in TabPages.QueueList)
                {
                    _switchPagesMenu.Items.Add(t.Text, t.Icon, TabClicked).
                        Tag = t;
                }
                _switchPagesMenu.Show(this, ((Width/2) - (_switchPagesMenu.Width/2)),
                                      ((Height/2) - (_switchPagesMenu.Height/2)));
                if (_switchPagesMenu.Items.Count > 1)
                {
                    _switchPagesMenu.Items[1].Select();
                    _switchPagesMenuCurrentItem = 1;
                }
                else
                {
                    _switchPagesMenu.Items[0].Select();
                    _switchPagesMenuCurrentItem = 0;
                }
            }
        }

        private void AvMultitabControlMouseClick(object sender, MouseEventArgs e)
        {
            int pageByPoint = GetPageByPoint(e.Location);
            if (pageByPoint != -1)
            {
                if ((e.Button == MouseButtons.Left) && (SelectedTab != TabPages[pageByPoint]))
                {
                    SelectTab(pageByPoint);
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    CloseTab(pageByPoint);
                }
            }
            else if ((e.Button == MouseButtons.Middle) && (TabPages.Count > 0))
            {
                CloseTab(SelectedTab);
            }
        }

        private void AvMultitabControlMouseHover(object sender, EventArgs e)
        {
            if (!_toolTipTextAlreadyShown)
            {
                Graphics graphics = CreateGraphics();
                SizeF ef = graphics.MeasureString(_toolTipText, new Font("Tahoma", 8.25f, FontStyle.Regular));
                graphics.Dispose();
                int num = ((int) (ef.Width/2f)) - 3;
                _toolTip.Show(_toolTipText, this, _currentCursorLocation.X - num, _currentCursorLocation.Y + 20,
                             0x3e8*ToolTipDelay);
                _toolTipTextAlreadyShown = true;
            }
        }

        private void AvMultitabControlMouseMove(object sender, MouseEventArgs e)
        {
            if ((ShowToolTips && ((e.X <= ((((Width - 5) - (2*_serviceButtonSize.Width)) - 2) - 20)) && (e.Y <= 20))) &&
                (e.Location != _currentCursorLocation))
            {
                _toolTipTextAlreadyShown = false;
                int pageByPoint = GetPageByPoint(e.Location);
                if (pageByPoint != -1)
                {
                    _toolTipText = TabPages[pageByPoint].ToolTipText;
                    Point position = Cursor.Position;
                    Cursor.Position = new Point(0, 0);
                    Cursor.Position = position;
                }
                else
                {
                    _toolTipText = "";
                    if (_toolTip.Active)
                    {
                        _toolTip.Hide(this);
                    }
                }
                _currentCursorLocation = e.Location;
            }
        }

        private string ChangeCaption(string caption)
        {
            string str;
            Graphics graphics = CreateGraphics();
            if (graphics.MeasureString(caption, _avMultitabActiveFont).Width > ((MaxTabWidth - 3) - 14))
            {
                int startIndex = (caption.Length/2) - 1;
                int num2 = caption.Length - (caption.Length/2);
                bool flag = true;
                str = caption.Substring(0, (caption.Length/2) - 1) + "..." +
                      caption.Substring((caption.Length - (caption.Length/2)) + 1);
                SizeF ef = graphics.MeasureString(str, _avMultitabActiveFont);
                while (ef.Width > ((MaxTabWidth - 3) - 14))
                {
                    string str2;
                    if (flag)
                    {
                        str2 = str.Substring(startIndex);
                        str = str.Substring(0, startIndex - 1) + str2;
                        startIndex--;
                        num2--;
                    }
                    else
                    {
                        str2 = str.Substring(num2 + 2);
                        str = str.Substring(0, num2 + 1) + str2;
                    }
                    ef = graphics.MeasureString(str, _avMultitabActiveFont);
                    flag = !flag;
                }
            }
            else
            {
                str = caption;
            }
            graphics.Dispose();
            return str;
        }

        private void CloseButtonGotFocus(object sender, EventArgs e)
        {
            Focus();
        }

        private void CloseButtonMouseClick(object sender, MouseEventArgs e)
        {
            CloseTab(SelectedTab);
        }

        public void CloseTab(MultitabPage tabPage)
        {
            //if (tabPages.Count == 1 && tabPage.Text != "Login")
            //{
            //    string message = "All the tabs will be closed.\nDo your really want to exit the program?";
            //    DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
            //                                       MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //    if (result != DialogResult.Yes)
            //    {
            //        return;
            //    }
            //}

            if (!TabPages.Contains(tabPage))
            {
                throw new ArgumentException("This tab doesn't exist in collection", "tabPage");
            }

            AvMultitabControlCancelEventArgs e = new AvMultitabControlCancelEventArgs(AvMultitabControlAction.Closing,
                                                                                      tabPage);
            OnClosing(e);
            if (!e.Cancel)
            {
                TabPages.Remove(tabPage);
                OnClosed(new AvMultitabControlEventArgs(AvMultitabControlAction.Closed, tabPage));
                if (tabPage == SelectedTab)
                {
                    MultitabPage page = TabPages.Count != 0 ? TabPages.QueueList[0] : null;
                    if ((tabPage == SelectedTab) && (page != null))
                    {
                        AvMultitabControlCancelEventArgs args2 =
                            new AvMultitabControlCancelEventArgs(AvMultitabControlAction.Selecting, page);
                        OnSelecting(args2);
                        if (!args2.Cancel)
                        {
                            SelectedTab = page;
                            Invalidate();
                            OnSelected(new AvMultitabControlEventArgs(AvMultitabControlAction.Selected, SelectedTab));
                        }
                    }
                }
            }

            if (_tabPages.Count == 0 && tabPage.Text != "Login")
            {
                Application.Exit();
            }
        }

        public void CloseTab(int index)
        {
            if ((index < 0) || (index > (TabPages.Count - 1)))
            {
                throw new IndexOutOfRangeException(
                    "Value of index must be greater than zero and less than elements' count collection");
            }
            CloseTab(TabPages[index]);
        }

        public virtual MultitabPage CreateNewTabPage()
        {
            return CreateNewTabPage("");
        }

        public virtual MultitabPage CreateNewTabPage(string caption)
        {
            return new MultitabPage(caption);
        }

        private bool CursorOnPage(int width, int position, Point point, int stepNumber)
        {
            int num = 0;
            if (stepNumber > 14)
            {
                num++;
            }
            bool flag = point.Y == ((TitleHeight - stepNumber) - 1);
            bool flag2 = point.X >= ((((position + _inActiveTabAngleSize.Width) - 0x10) + stepNumber) + num);
            bool flag3 = point.X <= ((position + width) - num);
            return ((flag && flag2) && flag3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DrawBorder(Rectangle clipRectangle)
        {
            Graphics graphics = CreateGraphics();
            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            ControlPaint.DrawBorder(graphics, bounds, InactiveBorderColor, ButtonBorderStyle.Solid);
            if (clipRectangle.Top < TitleHeight)
            {
                graphics.DrawLine(new Pen(ActiveBorderColor), clipRectangle.Left, TitleHeight - 1, (Width - 2) - 1,
                                  TitleHeight - 1);
            }
            graphics.Dispose();
        }

        private int DrawPage(int left, string caption, bool full, bool active)
        {
            Point[] pointArray;
            LinearGradientBrush brush;
            Graphics graphics = CreateGraphics();
            string text = ChangeCaption(caption);
            SizeF ef = graphics.MeasureString(text, _avMultitabActiveFont);
            if (ef.Width == 0f)
            {
                ef.Width = 4f;
            }
            Size size = new Size((14 + ((int) ef.Width)) + 3, 0x10);
            Rectangle layoutRectangle = new Rectangle(left, TitleHeight - 0x10,
                                                      (((_inActiveTabAngleSize.Width - 0x10) + 14) + ((int) ef.Width)) +
                                                      3, 0x10);
            Point location = new Point((left + _inActiveTabAngleSize.Width) - 0x10, TitleHeight - 0x10);
            Rectangle rect = new Rectangle(location, size);
            SolidBrush brush2 = new SolidBrush(ForeColor);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            int num = (((_inActiveTabAngleSize.Width - 0x10) + 14) + ((int) ef.Width)) + 3;
            if (active || full)
            {
                pointArray = new[]
                                 {
                                     new Point((left + _inActiveTabAngleSize.Width) - 0x10, TitleHeight - 1),
                                     new Point((left + _inActiveTabAngleSize.Width) - 2, ((TitleHeight - 0x10) + 2) - 1),
                                     new Point((left + _inActiveTabAngleSize.Width) + 2, (TitleHeight - 0x10) - 1),
                                     new Point(
                                         (((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3) -
                                         2,
                                         (TitleHeight - 0x10) - 1),
                                     new Point(
                                         ((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3,
                                         ((TitleHeight - 0x10) + 2) - 1),
                                     new Point(
                                         ((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3,
                                         TitleHeight - 1)
                                 };
            }
            else
            {
                pointArray = new[]
                                 {
                                     new Point(left, TitleHeight - 1),
                                     new Point(left, ((TitleHeight - 0x10) + _inActiveTabAngleSize.Height) - 1),
                                     new Point((left + _inActiveTabAngleSize.Width) - 2, ((TitleHeight - 0x10) + 2) - 1),
                                     new Point((left + _inActiveTabAngleSize.Width) + 2, (TitleHeight - 0x10) - 1),
                                     new Point(
                                         (((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3) -
                                         2,
                                         (TitleHeight - 0x10) - 1),
                                     new Point(
                                         ((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3,
                                         ((TitleHeight - 0x10) + 2) - 1),
                                     new Point(
                                         ((((left + _inActiveTabAngleSize.Width) - 0x10) + 14) + ((int) ef.Width)) + 3,
                                         TitleHeight - 1)
                                 };
            }
            if (active)
            {
                brush = new LinearGradientBrush(rect, _activeTopColor, _activeBottomColor, LinearGradientMode.Vertical);
                graphics.FillPolygon(brush, pointArray);
                graphics.DrawPolygon(new Pen(ActiveBorderColor), pointArray);
                graphics.DrawString(text, _avMultitabActiveFont, brush2, layoutRectangle, format);
            }
            else if (full)
            {
                brush = new LinearGradientBrush(rect, _inactiveTopColor, _inactiveBottomColor, LinearGradientMode.Vertical);
                graphics.FillPolygon(brush, pointArray);
                graphics.DrawPolygon(new Pen(InactiveBorderColor), pointArray);
                graphics.DrawString(text, _avMultitabInactiveFont, brush2, layoutRectangle, format);
            }
            else
            {
                brush = new LinearGradientBrush(rect, _inactiveTopColor, _inactiveBottomColor, LinearGradientMode.Vertical);
                graphics.FillPolygon(brush, pointArray);
                graphics.DrawLine(new Pen(InactiveBorderColor), pointArray[1], pointArray[2]);
                graphics.DrawLine(new Pen(InactiveBorderColor), pointArray[2], pointArray[3]);
                graphics.DrawLine(new Pen(InactiveBorderColor), pointArray[3], pointArray[4]);
                graphics.DrawLine(new Pen(InactiveBorderColor), pointArray[4], pointArray[5]);
                graphics.DrawLine(new Pen(InactiveBorderColor), pointArray[5], pointArray[6]);
                graphics.DrawString(text, _avMultitabInactiveFont, brush2, layoutRectangle, format);
            }
            if (active)
            {
                graphics.DrawLine(new Pen(ActiveBottomColor), pointArray[0].X + BorderSize, pointArray[0].Y,
                                  pointArray[5].X - BorderSize, pointArray[5].Y);
            }
            else if (full)
            {
                graphics.DrawLine(new Pen(ActiveBorderColor), pointArray[0].X, pointArray[0].Y, pointArray[5].X,
                                  pointArray[5].Y);
            }
            else
            {
                graphics.DrawLine(new Pen(ActiveBorderColor), pointArray[0].X, pointArray[0].Y, pointArray[6].X,
                                  pointArray[6].Y);
            }
            format.Dispose();
            brush.Dispose();
            brush2.Dispose();
            graphics.Dispose();
            return num;
        }

        private void DrawPages()
        {
            _titleWidth.Clear();
            _titlePosition.Clear();
            Graphics graphics = CreateGraphics();
            new SolidBrush(BackColor);
            graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(0, 0, Width, TitleHeight));
            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            ControlPaint.DrawBorder(graphics, bounds, InactiveBorderColor, ButtonBorderStyle.Solid);
            graphics.DrawLine(new Pen(ActiveBorderColor), 2, TitleHeight - 1, (Width - 2) - 1, TitleHeight - 1);
            int left = (0x10 - _inActiveTabAngleSize.Width) + 4;
            int num2 = 0;
            int num3 = TabPages.Count - 1;
            int item = 0;
            while ((left < (((((Width - 5) - (2*_serviceButtonSize.Width)) - 2) - 20) - item)) && (num3 >= 0))
            {
                if ((num2 == 0) && (num3 != TabPages.IndexOf(SelectedTab)))
                {
                    item = DrawPage(left, TabPages[num3].Text, true, false);
                }
                else if (num3 == TabPages.IndexOf(SelectedTab))
                {
                    item = DrawPage(left, TabPages[num3].Text, true, true);
                }
                else
                {
                    item = DrawPage(left, TabPages[num3].Text, false, false);
                }
                _titlePosition.Add(left);
                _titleWidth.Add(item);
                left += item + 1;
                num2++;
                num3--;
                if (num2 < TabPages.Count)
                {
                    string text = ChangeCaption(TabPages[num3].Text);
                    SizeF ef = graphics.MeasureString(text, _avMultitabActiveFont);
                    item = (((_inActiveTabAngleSize.Width - 0x10) + 14) + ((int) ef.Width)) + 3;
                }
            }
            _visiblePagesCount = num2;
            if ((TabPages.Count > _visiblePagesCount) &&
                (DropDownButton.BackgroundImage != Resources.AvMultitabDropDownButtonFull))
            {
                DropDownButton.BackgroundImage = Resources.AvMultitabDropDownButtonFull;
            }
            if (((TabPages.Count <= _visiblePagesCount) && (_visiblePagesCount != 0)) &&
                (DropDownButton.BackgroundImage != Resources.AvMultitabDropDownButton))
            {
                DropDownButton.BackgroundImage = Resources.AvMultitabDropDownButton;
            }
            graphics.Dispose();
        }

        private void DropDownButtonGotFocus(object sender, EventArgs e)
        {
            Focus();
        }

        private void DropDownButtonMouseClick(object sender, MouseEventArgs e)
        {
            _activePagesMenu.Items.Clear();
            List<MultitabPage> list = new List<MultitabPage>();
            for (int i = 0; i < TabPages.Count; i++)
            {
                list.Add(TabPages[i]);
            }
            list.Sort(new AvTabPagesComparer());
            for (int j = 0; j < TabPages.Count; j++)
            {
                _activePagesMenu.Items.Add(list[j].Text, list[j].Icon, TabClicked).Tag = list[j];
            }
            _activePagesMenu.Show(this, DropDownButton.Left, DropDownButton.Top + DropDownButton.Height);
        }

        public int GetPageByPoint(Point point)
        {
            int num = TabPages.Count - 1;
            for (int i = 0; i < _visiblePagesCount; i++)
            {
                if (i == 0)
                {
                    if ((i >= (_visiblePagesCount - 1)) || (TabPages[num - 1] != SelectedTab))
                    {
                        if (IsOnPage(_titleWidth[i], _titlePosition[i], point, true, false))
                        {
                            return num;
                        }
                    }
                    else if (IsOnPage(_titleWidth[i], _titlePosition[i], point, true, true))
                    {
                        return num;
                    }
                }
                else if ((i < (_visiblePagesCount - 1)) && (TabPages[num - 1] == SelectedTab))
                {
                    if (IsOnPage(_titleWidth[i], _titlePosition[i], point, false, true))
                    {
                        return num;
                    }
                }
                else if (IsOnPage(_titleWidth[i], _titlePosition[i], point, false, false))
                {
                    return num;
                }
                num--;
            }
            return -1;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            Size = new Size(400, 200);
            MouseMove += AvMultitabControlMouseMove;
            MouseClick += AvMultitabControlMouseClick;
            ControlAdded += AvMultitabControlControlAdded;
            MouseHover += AvMultitabControlMouseHover;
            KeyDown += AvMultitabControlKeyDown;
            ResumeLayout(false);
        }

        private bool IsOnPage(int width, int position, Point point, bool full, bool activeNextPage)
        {
            if (full)
            {
                if (!activeNextPage)
                {
                    for (int n = 0; n <= 0x10; n++)
                    {
                        if (CursorOnPage(width, position, point, n))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                for (int k = 0; k < (0x10 - _inActiveTabAngleSize.Height); k++)
                {
                    if (((point.Y == ((TitleHeight - k) - 1)) &&
                         (point.X >= (((position + _inActiveTabAngleSize.Width) - 0x10) + k))) &&
                        (point.X <= ((((position + width) + _inActiveTabAngleSize.Width) - 0x10) + k)))
                    {
                        return true;
                    }
                }
                for (int m = 0x10 - _inActiveTabAngleSize.Height; m <= 0x10; m++)
                {
                    if (CursorOnPage(width, position, point, m))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (!activeNextPage)
            {
                for (int num4 = 0; num4 < (0x10 - _inActiveTabAngleSize.Height); num4++)
                {
                    if (((point.Y == ((TitleHeight - num4) - 1)) && (point.X >= position)) &&
                        (point.X <= (position + width)))
                    {
                        return true;
                    }
                }
                for (int num5 = 0x10 - _inActiveTabAngleSize.Height; num5 <= 0x10; num5++)
                {
                    if (CursorOnPage(width, position, point, num5))
                    {
                        return true;
                    }
                }
                return false;
            }
            for (int i = 0; i < (0x10 - _inActiveTabAngleSize.Height); i++)
            {
                if (((point.Y == ((TitleHeight - i) - 1)) && (point.X >= position)) &&
                    (point.X <= ((((position + width) + _inActiveTabAngleSize.Width) - 0x10) + i)))
                {
                    return true;
                }
            }
            for (int j = 0x10 - _inActiveTabAngleSize.Height; j <= 0x10; j++)
            {
                if (CursorOnPage(width, position, point, j))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual void OnClosed(AvMultitabControlEventArgs e)
        {
            if (Closed != null)
            {
                Closed(this, e);
            }
        }

        protected virtual void OnClosing(AvMultitabControlCancelEventArgs e)
        {
            if (Closing != null)
            {
                Closing(this, e);
            }
        }

        protected virtual void OnDeselected(AvMultitabControlEventArgs e)
        {
            if (Deselected != null)
            {
                Deselected(this, e);
            }
        }

        protected virtual void OnDeselecting(AvMultitabControlCancelEventArgs e)
        {
            if (Deselecting != null)
            {
                Deselecting(this, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if ((e.ClipRectangle.Left < (((Width - 20) - (2*_serviceButtonSize.Width)) - 5)) &&
                (e.ClipRectangle.Top < TitleHeight))
            {
                DrawPages();
            }
            else
            {
                DrawBorder(e.ClipRectangle);
            }
            if (_oldControlWidth != Width)
            {
                CloseButton.Location = new Point(((Width - CloseButton.Width) - 5) - 1, 3);
                DropDownButton.Location =
                    new Point(((((Width - CloseButton.Width) - 2) - DropDownButton.Width) - 5) - 1, 3);
                _oldControlWidth = Width;
            }
        }

        protected virtual void OnSelected(AvMultitabControlEventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }

        protected virtual void OnSelecting(AvMultitabControlCancelEventArgs e)
        {
            if (Selecting != null)
            {
                Selecting(this, e);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (Width < DefaultSize.Width)
            {
                Width = DefaultSize.Width;
            }
            if (Height < DefaultSize.Height)
            {
                Height = DefaultSize.Height;
            }
            if (_oldControlWidth != Width)
            {
                CloseButton.Location = new Point(((Width - CloseButton.Width) - 5) - 1, 3);
                DropDownButton.Location =
                    new Point(((((Width - CloseButton.Width) - 2) - DropDownButton.Width) - 5) - 1, 3);
                _oldControlWidth = Width;
            }
        }

        #region public void SelectTab(MultitabPage tabPage)
        /// <summary>
        /// Производит смену выбора вкладки
        /// </summary>
        /// <param name="tabPage">выбираемая вкладка</param>
        public void SelectTab(MultitabPage tabPage)
        {
            if (!TabPages.Contains(tabPage))
            {
                throw new ArgumentException("This tab doesn't exist in collection", "tabPage");
            }
            if (tabPage != SelectedTab)
            {
                AvMultitabControlCancelEventArgs e =
                    new AvMultitabControlCancelEventArgs(AvMultitabControlAction.Deselecting, SelectedTab);
                AvMultitabControlCancelEventArgs args2 =
                    new AvMultitabControlCancelEventArgs(AvMultitabControlAction.Selecting, tabPage);
                OnDeselecting(e);
                if (!e.Cancel)
                {
                    OnDeselected(new AvMultitabControlEventArgs(AvMultitabControlAction.Deselected, SelectedTab));
                    OnSelecting(args2);
                    if (!args2.Cancel)
                    {
                        SelectedTab = tabPage;
                        TabPages.QueueList.Remove(tabPage);
                        TabPages.QueueList.Insert(0, tabPage);
                        Invalidate();
                        OnSelected(new AvMultitabControlEventArgs(AvMultitabControlAction.Selected, SelectedTab));
                    }
                }
            }
        }
        #endregion

        public void SelectTab(int index)
        {
            if ((index < 0) || (index > (TabPages.Count - 1)))
            {
                throw new IndexOutOfRangeException(
                    "Value of index must be greater than zero and less than elements' count collection");
            }
            SelectTab(TabPages[index]);
        }

        private void SwitchPagesMenuKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.Shift) && (e.KeyCode == Keys.Tab))
            {
                _switchPagesMenuCurrentItem--;
                if (_switchPagesMenuCurrentItem < 0)
                {
                    _switchPagesMenuCurrentItem = _switchPagesMenu.Items.Count - 1;
                }
                _switchPagesMenu.Items[_switchPagesMenuCurrentItem].Select();
            }
            else if (e.Control && (e.KeyCode == Keys.Tab))
            {
                _switchPagesMenuCurrentItem++;
                if (_switchPagesMenuCurrentItem > (_switchPagesMenu.Items.Count - 1))
                {
                    _switchPagesMenuCurrentItem = 0;
                }
                _switchPagesMenu.Items[_switchPagesMenuCurrentItem].Select();
            }
        }

        private void SwitchPagesMenuKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                _switchPagesMenu.Hide();
                SelectTab(TabPages.IndexOf(TabPages.QueueList[_switchPagesMenuCurrentItem]));
            }
        }

        public void TabClicked(object sender, EventArgs e)
        {
            if (sender is ToolStripItem)
            {
                MultitabPage tag = (sender as ToolStripItem).Tag as MultitabPage;
                SelectTab(tag);
            }
        }

        private void TabPagesCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if ((e.Action == CollectionChangeAction.Add) && TabPages.PageAddedViaPropertyGrid)
            {
                TabPages.Insert(TabPages.Count, e.Element as MultitabPage, true);
            }
            _closeButton.Enabled = TabCount > 1;
        }

        #region Nested type: TabPageCollection

        /// <summary>
        /// Описывает коллекцию для удобной работы с вкладками
        /// </summary>
        public class TabPageCollection : CollectionBase
        {
            /// <summary>
            /// Владелец данной коллекции вкладок
            /// </summary>
            private readonly AvMultitabControl _owner;
            /// <summary>
            /// Список вкладок
            /// </summary>
            private readonly List<MultitabPage> _queueList = new List<MultitabPage>();
            private bool _pageAddedViaPropertyGrid = true;

            public TabPageCollection(AvMultitabControl owner)
            {
                if (owner == null)
                {
                    throw new ArgumentNullException("owner", "Value of owner control is null");
                }
                _owner = owner;
            }

            public MultitabPage this[int index]
            {
                get
                {
                    if ((index >= 0) && (index <= (_owner.TabPages.Count - 1)))
                    {
                        return (List[index] as MultitabPage);
                    }
                    return null;
                }
                set
                {
                    if ((index < 0) || (index > List.Count))
                    {
                        throw new IndexOutOfRangeException("Value of index must be greater than zero and less than elements' count collection");
                    }
                    if (value == null)
                    {
                        throw new ArgumentNullException("value", "The given argument is null");
                    }
                    List[index] = value;
                }
            }

            public bool PageAddedViaPropertyGrid
            {
                get { return _pageAddedViaPropertyGrid; }
                set { _pageAddedViaPropertyGrid = value; }
            }

            public List<MultitabPage> QueueList
            {
                get { return _queueList; }
            }

            public void Add(MultitabPage page)
            {
                if (page == null)
                {
                    throw new ArgumentNullException("page", "Value of this page is null");
                }
                if (List.Contains(page)) return;
                Insert(List.Count, page);
                _owner.Invalidate();
            }

            public void AddRange(IEnumerable<MultitabPage> pages)
            {
                foreach (MultitabPage t in pages)
                {
                    if (t == null)
                    {
                        throw new ArgumentNullException("pages", "At least one element of array is null");
                    }
                    Insert(List.Count, t);
                }
            }

            #region private void CheckAllChildControls(Control control)
            /// <summary>
            /// Подписывает все вложенные элементы на события добавления контрола и нажатие клавиши
            /// </summary>
            /// <param name="control"></param>
            private void CheckAllChildControls(Control control)
            {
                control.KeyDown -= _owner.AvMultitabControlKeyDown;
                control.KeyDown += _owner.AvMultitabControlKeyDown;

                control.ControlAdded -= PageControlAdded;
                control.ControlAdded += PageControlAdded;
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    CheckAllChildControls(control.Controls[i]);
                }
            }
            #endregion

            #region private void UncheckAllChildControls(Control control)
            /// <summary>
            /// Отписывает все вложенные элементы от события добавления контрола и нажатие клавиши
            /// </summary>
            /// <param name="control"></param>
            private void UncheckAllChildControls(Control control)
            {
                control.KeyDown -= _owner.AvMultitabControlKeyDown;
                control.ControlAdded -= PageControlAdded;
                for (int i = 0; i < control.Controls.Count; i++)
                {
                    UncheckAllChildControls(control.Controls[i]);
                }
            }
            #endregion

            #region public new void Clear()
            /// <summary>
            /// Очищает коллекцию
            /// </summary>
            public new void Clear()
            {
                foreach (MultitabPage page in _queueList)
                    UncheckAllChildControls(page);

                _owner.Controls.Clear();
                List.Clear();
                QueueList.Clear();
                _owner.DropDownButton.Enabled = false;
                _owner.CloseButton.Enabled = false;
                _owner.Invalidate();
            }
            #endregion

            public bool Contains(MultitabPage page)
            {
                return List.Contains(page);
            }

            public int IndexOf(MultitabPage page)
            {
                if (List.Contains(page))
                {
                    return List.IndexOf(page);
                }
                return -1;
            }

            #region public void Insert(int index, MultitabPage page, bool pageAlreadyAdded = false)
            /// <summary>
            /// Вставляет переданную вкладку на указанную позицию в списке
            /// </summary>
            /// <param name="index">позиция, на которую необходимо вставить вкладку</param>
            /// <param name="page">вставляемая вкладка</param>
            /// <param name="pageAlreadyAdded">флаг показывающий была ли страница в вписвке до её нынешнего добавления</param>
            public void Insert(int index, MultitabPage page, bool pageAlreadyAdded = false)
            {
                if ((index > List.Count) || (index < 0))
                {
                    throw new IndexOutOfRangeException("Value of index must be greater than zero and less than elements' count collection");
                }
                if (page == null)
                {
                    throw new ArgumentNullException("page", "Value of inserting page is null");
                }
                if (!List.Contains(page) || PageAddedViaPropertyGrid)
                {
                    page.Location = new Point(_owner.BorderSize, _owner.TitleHeight);
                    page.Size = new Size(_owner.Width - (2*_owner.BorderSize),
                                         (_owner.Height - _owner.TitleHeight) - _owner.BorderSize);
                    page.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
                    page.Owner = _owner;
                    page.Parent = _owner;
                    CheckAllChildControls(page);
                    page.BackColor = Color.Transparent;
                    if (!pageAlreadyAdded)
                    {
                        PageAddedViaPropertyGrid = false;
                        //List.Insert(index, page);вставка в начало
                        List.Insert(0, page);
                        PageAddedViaPropertyGrid = true;
                    }
                    QueueList.Insert(0, page);
                    if (List.Count > 1)
                    {
                        _owner.DropDownButton.Enabled = true;
                        _owner.CloseButton.Enabled = true;
                    }
                    _owner.SelectedTab = page;
                    _owner.Controls.Add(page);
                    _owner.Invalidate();
                }
            }
            #endregion

            protected override void OnInsertComplete(int index, object item)
            {
                OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, item));
            }

            protected override void OnRemove(int index, object item)
            {
                base.OnRemove(index, item);
                OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, item));
            }

            private void PageControlAdded(object sender, ControlEventArgs e)
            {
                CheckAllChildControls(e.Control);
            }

            #region public void Remove(MultitabPage page)
            /// <summary>
            /// Удаляет вкладу из коллекции. (Также удаляет её из вложенных ЭУ родителя коллекции)
            /// </summary>
            /// <param name="page"></param>
            public void Remove(MultitabPage page)
            {
                if (!List.Contains(page))
                {
                    return;
                }
                _owner.Controls.Remove(page);
                List.Remove(page);
                if (QueueList.Contains(page))
                {
                    QueueList.Remove(page);
                }
                if (List.Count == 0)
                {
                    _owner.DropDownButton.Enabled = false;
                    _owner.CloseButton.Enabled = false;
                }
                _owner.Invalidate();
                return;
            }
            #endregion

            #region public new void RemoveAt(int index)
            /// <summary>
            /// Удаляет вкладку с указанным индексом
            /// </summary>
            /// <param name="index">Индекс удаляемой вкладки</param>
            public new void RemoveAt(int index)
            {
                if ((index < 0) || (index >= List.Count))
                {
                    throw new IndexOutOfRangeException("Value of index must be greater than zero and less than elements' count collection");
                }
                Remove(List[index] as MultitabPage);
            }
            #endregion

            #region Events

            /// <summary>
            /// Событие возникающее при изменении коллекции
            /// </summary>
            [Browsable(false)]
            public event CollectionChangeEventHandler CollectionChanged;

            /// <summary>
            /// Возбуждает событие изменения коллекции
            /// </summary>
            /// <param name="e"></param>
            protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
            {
                if (CollectionChanged != null)
                {
                    CollectionChanged(this, e);
                }
            }

            #endregion

        }

        #endregion
    }
}