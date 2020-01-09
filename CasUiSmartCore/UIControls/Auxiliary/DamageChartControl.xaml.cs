using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using Button = System.Windows.Controls.Button;
using ContextMenu = System.Windows.Controls.ContextMenu;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;
using ToolTip = System.Windows.Controls.ToolTip;
using UserControl = System.Windows.Controls.UserControl;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Логика взаимодействия для DamageChartControl.xaml
    /// </summary>
    public partial class DamageChartControl : UserControl
    {
        private DamageDocument _document;

        private List<DamageChartImage> _chartImages = new List<DamageChartImage>
        {
            new DamageChartImage("B-737-500 Rear Left", Properties.Resources.B737500RearLeft, 63, 30),
            new DamageChartImage("B-737-500 Right side", Properties.Resources.B737500Side, 36,12),
            new DamageChartImage("B-737-500 Top", Properties.Resources.B737500Top, 24, 12),
        };

        #region public DamageDocument DamageDocument
        public DamageDocument DamageDocument
        {
            get { return _document; }
            set
            {
                _document = value; 
                UpdateInformation();
            }
        }
        #endregion

        public DamageChartControl()
        {
            InitializeComponent();
        }

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            ChartComboBox.Items.Clear();
            foreach (DamageChartImage t in _chartImages)
                ChartComboBox.Items.Add(t);
    
            if(_document == null)
                return;

            DamageChartImage dci = _chartImages.FirstOrDefault(ci => ci.ChartName == _document.DamageChart2DImageName);

            if(dci == null)
                return;
            
            ChartComboBox.SelectedItem = dci;

            foreach (DamageSector damageSector in _document.DamageSectors)
            {
                if(damageSector.DamageChartColumn < 0 || (damageSector.DamageChartColumn + 1) > ChartGrid.ColumnDefinitions.Count ||
                   damageSector.DamageChartRow < 0 || (damageSector.DamageChartRow + 1) > ChartGrid.RowDefinitions.Count)
                    continue;

                UIElement uiElement = null;
                foreach (UIElement child in ChartGrid.Children)
                {
                    if (Grid.GetColumn(child) == damageSector.DamageChartColumn &&
                        Grid.GetRow(child) == damageSector.DamageChartRow)
                    {
                        uiElement = child;
                    }
                }
                
                if(uiElement == null)
                    continue;

                ToggleButton button = uiElement as ToggleButton;
                if (button == null)
                    continue;
                button.IsChecked = true;
                button.Tag = damageSector;
                button.ToolTip = new ToolTip
                {
                    Content = string.IsNullOrEmpty(damageSector.Remarks) ? "No Information" : damageSector.Remarks
                };// damageSector.Remarks;
            }
        }
        #endregion

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            DamageChartImage dci = ChartComboBox.SelectedItem as DamageChartImage;
            if (dci != null && dci.ChartName != _document.DamageChart2DImageName)
                return true;
            //Проверка на содержание объекта в коллекции
            List<ToggleButton> checkedButtons =
                ChartGrid.Children.OfType<ToggleButton>().Where(tb => tb.IsChecked == true).ToList();

            if (checkedButtons.Count != _document.DamageSectors.Count)
                return true;
            if (checkedButtons.Any(cb => cb.Tag as DamageSector == null))
                return true;
            return false;
        }
        #endregion

        #region public void SaveData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            DamageChartImage dci = ChartComboBox.SelectedItem as DamageChartImage;
            if (dci != null)
                _document.DamageChart2DImageName = dci.ChartName;
            else _document.DamageChart2DImageName = "";

            List<ToggleButton> checkedButtons =
                ChartGrid.Children.OfType<ToggleButton>().Where(tb => tb.IsChecked == true).ToList();

            List<DamageSector> sectorsToDelete = new List<DamageSector>(_document.DamageSectors);
            _document.DamageSectors.Clear();

            foreach (ToggleButton checkedButton in checkedButtons.Where(cb => cb.Tag as DamageSector != null))
            {
                sectorsToDelete.Remove((DamageSector) checkedButton.Tag);
                
                _document.DamageSectors.Add((DamageSector) checkedButton.Tag);
            }
            foreach (DamageSector sectorToDelete in sectorsToDelete)
            {
                if (sectorToDelete.ItemId > 0)
                {
                    sectorToDelete.IsDeleted = true;
                    _document.DamageSectors.Add(sectorToDelete);
                }
            }
            foreach (ToggleButton checkedButton in checkedButtons.Where(cb => cb.Tag as DamageSector == null))
            {
                DamageSector newDamageSector = new DamageSector()
                {
                    DamageChartColumn = Grid.GetColumn(checkedButton),
                    DamageChartRow = Grid.GetRow(checkedButton),
                    DamageDocument = _document,
                };

                checkedButton.Tag = newDamageSector;
               
                _document.DamageSectors.Add(newDamageSector);
            }
        }
        #endregion

        #region private void ChartComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        private void ChartComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChartGrid.ColumnDefinitions.Clear();
            ChartGrid.RowDefinitions.Clear();
            foreach (UIElement uiElement in ChartGrid.Children)
            {
                if (uiElement is Button)
                    ((Button)uiElement).Click -= MainWindowClick;
            }
            ChartGrid.Children.Clear();
            //MainCanvas.Children.Clear();

            DamageChartImage dci = ChartComboBox.SelectedItem as DamageChartImage;
            if (dci == null || dci.ImagePath == null || dci.CountColumns <= 0 || dci.CountRows <= 0)
                return;

            try
            {

                ImageSourceConverter converter = new ImageSourceConverter();
                string path =
	                $@"{(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))}\{dci.ImagePath}";
                ImageSource imageSource = (ImageSource)converter.ConvertFromString(path);

                this.Width = imageSource.Width;
                this.Height = imageSource.Height;
                ChartGrid.Background = new ImageBrush(imageSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            for (int i = 0; i < dci.CountColumns; i++)
                ChartGrid.ColumnDefinitions.Add(new ColumnDefinition()); 

            for (int i = 0; i < dci.CountRows; i++)
                ChartGrid.RowDefinitions.Add(new RowDefinition());

            //Grid.SetRowSpan(MainCanvas, ChartGrid.RowDefinitions.Count);
            //Grid.SetColumnSpan(MainCanvas, ChartGrid.ColumnDefinitions.Count);
            for (int i = 0; i < ChartGrid.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < ChartGrid.RowDefinitions.Count; j++)
                {
                    ToggleButton newButton = new ToggleButton
                    {
                        Content = "X",
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                    };
                    //newButton.Click += MainWindow_Click;

                    Grid.SetColumn(newButton, i);
                    Grid.SetRow(newButton, j);
                    ChartGrid.Children.Add(newButton);
                }
            }
        }
        #endregion

        void MainWindowClick(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            if (button == null)
                return;

            if (button.IsChecked == true && button.Tag == null)
            {
                DamageSector newDamageSector = new DamageSector()
                {
                    DamageChartColumn = Grid.GetColumn(button),
                    DamageChartRow = Grid.GetRow(button),
                    DamageDocument = _document,
                };

                button.Tag = newDamageSector;

                _document.DamageSectors.Add(newDamageSector);
            }
            button.IsChecked = !button.IsChecked;

            //button.IsPressed = !button.IsPressed;
        }

        void ContextMenuButtonClick(object sender, RoutedEventArgs e)
        {

            System.Windows.Controls.MenuItem menuItem = sender as System.Windows.Controls.MenuItem;
            if (menuItem == null)
                return;

            DependencyObject parent = menuItem.Parent;
            ToggleButton button = menuItem.Tag as ToggleButton;
            while (parent != null)
            {
                if (parent is ContextMenu)
                {
                    parent = ((ContextMenu) parent).PlacementTarget;
                }
                if (parent is ToggleButton)
                {
                    button = parent as ToggleButton;
                    break;
                }
                if (parent is FrameworkElement)
                {
                    parent = ((FrameworkElement) parent).Parent;
                }
                else parent = null;
            }
            if (button == null)
                return;

            DamageSector sector = button.Tag as DamageSector;
            if (sector == null)
                return;

            CommonEditorForm form = new CommonEditorForm(sector, sector.ItemId > 0);
            if (form.ShowDialog() == DialogResult.OK)
            {
                button.ToolTip = new ToolTip
                {
                    Content = string.IsNullOrEmpty(sector.Remarks) ? "No Information" : sector.Remarks
                };
            }
        }
        private void MainCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //MainCanvas.Children.Clear();

            //Ellipse el = new Ellipse {Height = 10, Width = 10, Fill = new SolidColorBrush(Colors.Red)};
            //Canvas.SetTop(el, e.GetPosition(MainCanvas).Y);
            //Canvas.SetLeft(el, e.GetPosition(MainCanvas).X);
            //MainCanvas.Children.Add(el);
        }

        private void ButtonContextMenu_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ContextMenu contextMenu = sender as ContextMenu;
            if(contextMenu == null)
                return;
            
            ToggleButton button = contextMenu.Parent as ToggleButton;
            if (button == null)
                return;

            DamageSector sector = button.Tag as DamageSector;
            if (sector == null)
                return;

            CommonEditorForm form = new CommonEditorForm(sector, sector.ItemId > 0);
            form.ShowDialog();
        }
    }
}
