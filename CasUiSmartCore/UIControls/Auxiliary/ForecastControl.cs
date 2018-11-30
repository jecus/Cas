#region

using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using AvControls.AvButtonT;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;

#endregion

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public class ForecastControl : UserControl, IReference
    {
        #region Fields

        private readonly Icons _icons = new Icons();
        ///<summary>
        ///</summary>
        public AvButtonT AvButtonForecast;
        ContextMenuStrip _contextMenuStrip;
        ToolStripMenuItem _customMenuItem;
        ToolStripMenuItem _monthMenuItem;
        ToolStripMenuItem _noForecastMenuItem;
        ToolStripMenuItem _thisWeekMenuItem;
        ToolStripMenuItem _todayMenuItem;
        ToolStripSeparator _toolStripSeparator1;
        ToolStripMenuItem _twoWeeksMenuItem;

        #endregion

        #region Properties
        ///<summary>
        /// Показать/Скрыть пункт меню "Без прогноза"
        ///</summary>
        public bool ShowNoForecastMenuItem
        {
            get { return _contextMenuStrip.Items.Contains(_noForecastMenuItem); }
            set
            {
                if(value)
                    _contextMenuStrip.Items.Insert(0,_noForecastMenuItem);
                else
                    _contextMenuStrip.Items.Remove(_noForecastMenuItem);
            }
        }

        #endregion

        #region Constructors
        ///<summary>
        ///</summary>
        public ForecastControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            AvButtonForecast = new AvButtonT();
            _contextMenuStrip = new ContextMenuStrip();
            _noForecastMenuItem = new ToolStripMenuItem();
            _todayMenuItem = new ToolStripMenuItem();
            _thisWeekMenuItem = new ToolStripMenuItem();
            _twoWeeksMenuItem = new ToolStripMenuItem();
            _monthMenuItem = new ToolStripMenuItem();
            _customMenuItem = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();

            //
            // avButtonForecast
            //
            AvButtonForecast.ActiveBackgroundImage = _icons.HeaderBarClicked;
            AvButtonForecast.Dock = DockStyle.Right;
            AvButtonForecast.Icon = _icons.Forecast;
            AvButtonForecast.IconNotEnabled = _icons.ReloadGray;
            AvButtonForecast.IconLayout = ImageLayout.Center;
            AvButtonForecast.FontMain = new Font("Verdana", 14F, (((FontStyle.Bold | FontStyle.Underline))),
                                                 GraphicsUnit.Pixel);
            AvButtonForecast.FontSecondary = Css.HeaderControl.Fonts.SecondaryFont;
            AvButtonForecast.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            AvButtonForecast.ForeColorSecondary = Css.HeaderControl.Colors.SecondaryColor;
            AvButtonForecast.Margin = new Padding(0);
            AvButtonForecast.ShowToolTip = true;
            AvButtonForecast.TextMain = "";
            AvButtonForecast.TextSecondary = "";
            AvButtonForecast.TextAlignMain = ContentAlignment.MiddleLeft;
            AvButtonForecast.TextAlignSecondary = ContentAlignment.TopLeft;
            AvButtonForecast.ToolTipText = "Calculate Forecast";
            AvButtonForecast.Width = 70;
            AvButtonForecast.Height = 58;
            AvButtonForecast.Click += AvButtonForecastClick;

            //
            // contextMenuStrip
            //
            _contextMenuStrip.AutoSize = true;
            _contextMenuStrip.Tag = 1;
            _contextMenuStrip.Closed += ContextMenuStripClosed;

            _customMenuItem.Click += MenuItemClick;
            _noForecastMenuItem.Click += MenuItemClick;
            _todayMenuItem.Click += MenuItemClick;
            _thisWeekMenuItem.Click += MenuItemClick;
            _twoWeeksMenuItem.Click += MenuItemClick;
            _monthMenuItem.Click += MenuItemClick;

            //
            // todayMenuItem
            //
            _noForecastMenuItem.Text = "No Forecast";
            _noForecastMenuItem.Font = new Font("Verdana", 10F);

            //
            // todayMenuItem
            //
            _todayMenuItem.Text = "Today";
            _todayMenuItem.Font = new Font("Verdana", 10F);

            //
            // thisWeekMenuItem
            //
            _thisWeekMenuItem.Text = "This week";
            _thisWeekMenuItem.Font = new Font("Verdana", 10F);

            //
            // twoWeeksMenuItem
            //
            _twoWeeksMenuItem.Text = "Two weeks";
            _twoWeeksMenuItem.Font = new Font("Verdana", 10F);

            //
            // monthMenuItem
            //
            _monthMenuItem.Text = "Month";
            _monthMenuItem.Font = new Font("Verdana", 10F);

            //
            // customMenuItem
            //
            _customMenuItem.Text = "Custom";
            _customMenuItem.Font = new Font("Verdana", 10F);

            _contextMenuStrip.Items.Add(_noForecastMenuItem);
            _contextMenuStrip.Items.Add(_todayMenuItem);
            _contextMenuStrip.Items.Add(_thisWeekMenuItem);
            _contextMenuStrip.Items.Add(_twoWeeksMenuItem);
            _contextMenuStrip.Items.Add(_monthMenuItem);
            _contextMenuStrip.Items.Add(_toolStripSeparator1);
            _contextMenuStrip.Items.Add(_customMenuItem);

            Controls.Add(AvButtonForecast);
        }
        #endregion

        #region void ContextMenuStripClosed(object sender, ToolStripDropDownClosedEventArgs e)

        private void ContextMenuStripClosed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            _contextMenuStrip.Tag = 3;
        }

        #endregion

        #region void MenuItemClick(object sender, EventArgs e)
        void MenuItemClick(object sender, EventArgs e)
        {
            //if (DisplayerRequested != null)
            //{
            //    DisplayerRequested(((ToolStripMenuItem)sender).Text, new ReferenceEventArgs(Entity, ReflectionType, DisplayerText));
            //}
            InvokeMenuClick(sender, e);
        }
        #endregion

        #region private void AvButtonForecastClick(object sender, EventArgs e)

        private void AvButtonForecastClick(object sender, EventArgs e)
        {
            // 1 -закрыто по нажатию на кнопку
            // 2 - открыто
            // 3 - закрыто по нажатию вне области

            if ((int)_contextMenuStrip.Tag == 1)
            {
                _contextMenuStrip.Show(this, AvButtonForecast.Left, 58);
                _contextMenuStrip.Tag = 2;
            }
            if ((int)_contextMenuStrip.Tag == 3)
            {
                _contextMenuStrip.Tag = 1;
            }
        }

        #endregion

        #endregion

        #region Implementation of IReference

        public IDisplayer Displayer { get; set; }
        public string DisplayerText { get; set; }
        public IDisplayingEntity Entity { get; set; }
        public ReflectionTypes ReflectionType { get; set; }

        ///<summary>
        ///</summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #region Events

        ///<summary>
        ///</summary>
        public event EventHandler MenuClick;

        ///<summary>
        ///</summary>
        ///<param name="sender"></param>
        ///<param name="e"></param>
        public void InvokeMenuClick(object sender, EventArgs e)
        {
            EventHandler handler = MenuClick;
            if (handler != null) handler(((ToolStripMenuItem)sender).Text, e);
        }

        #endregion
    }
}