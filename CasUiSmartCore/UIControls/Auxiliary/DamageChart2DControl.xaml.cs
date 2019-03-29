using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Media;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using Button = System.Windows.Controls.Button;
using ContextMenu = System.Windows.Controls.ContextMenu;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Логика взаимодействия для DamageChart2DControl.xaml
    /// </summary>
    public partial class DamageChart2DControl : UserControl
    {

        #region Fields

        private DamageItem _currentDirctive;
        private Aircraft _currentAircraft;

        private DamageChartImage _selectDamageChartImage = new DamageChartImage("SelectChart", Properties.Resources.SelectDamageChartIcon, 0, 0);
        private DamageChartImage _b737300400500Bs46Leftside = new DamageChartImage("B-737-300/400/500 BODY SECTION 46 LEFT SIDE", Properties.Resources.B737300400500BS46Left, 64, 28);
        private DamageChartImage _b737300400500Bs46Rightside = new DamageChartImage("B-737-300/400/500 BODY SECTION 46 RIGTH SIDE", Properties.Resources.B737300400500BS46Right, 64, 25);
        private DamageChartImage _b737300400500WingLowerSurface = new DamageChartImage("B-737-300/400/500 LOWER WING SURFACE", Properties.Resources.B737300400500WingLowerSurface, 64, 42);
        private DamageChartImage _b737300400500WingUpperSurface = new DamageChartImage("B-737-300/400/500 UPPER WING SURFACE", Properties.Resources.B737300400500WingUpperSurface, 64, 44);
        private DamageChartImage _b737500RearLeft = new DamageChartImage("B-737-500 Rear Left",Properties.Resources.B737500RearLeft, 63, 30);
        private DamageChartImage _b737500Side = new DamageChartImage("B-737-500 Right side", Properties.Resources.B737500Side, 36, 12);
        private DamageChartImage _b737500Top = new DamageChartImage("B-737-500 Top", Properties.Resources.B737500Top, 24, 12);

        private List<DamageChartImage> _chartImages = new List<DamageChartImage>();

        #endregion

        #region Constructors

        #region public DamageChart2DControl()
        public DamageChart2DControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChart2DControl(DamageItem directive, Aircraft currentAircarft) : this()
        ///<summary>
        ///</summary>
        public DamageChart2DControl(DamageItem directive, Aircraft currentAircarft) : this()
        {
            _currentDirctive = directive;
            _currentAircraft = currentAircarft;

            UpdateInformation();
        }
        #endregion

        #endregion

        #region public void UpdateInformation(DamageItem directive, Aircraft currentAircarft)
        ///<summary>
        ///</summary>
        public void UpdateInformation(DamageItem directive, Aircraft currentAircarft)
        {
            _currentDirctive = directive;
            _currentAircraft = currentAircarft;

            UpdateInformation();
        }
        #endregion

        #region  private void UpdateInformation()
        ///<summary>
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentDirctive == null || _currentDirctive.DamageDocs == null
                || _currentAircraft == null) return;

            _chartImages.Clear();
            _chartImages.AddRange(new[]
            {
                _b737300400500Bs46Leftside, 
                _b737300400500Bs46Rightside, 
                _b737300400500WingLowerSurface, 
                _b737300400500WingUpperSurface, 
                _b737500RearLeft, 
                _b737500Side, 
                _b737500Top, 
                _selectDamageChartImage
            });

            ChartComboBox.Items.Clear();
            foreach (DamageChartImage t in _chartImages)
                ChartComboBox.Items.Add(t);

            DamageChartsListView.Items.Clear();

            if (_currentDirctive.DamageDocs.Count == 0)
            {
                //если у родителя нет ни одного Damage Doc-а, то ему добавляется в коллекцию Damage Doc-ов
                //пустой Damage Doc, ради того, что бы при появлении формы она не была пустой
                //если пользователь не изменит объект пустого Damage Doc-а, то данный Damage Doc при 
                //закрытии формы не сохранится и произоидет удаление всех пустых Damage Doc-ов из
                //коллекции Damage Doc-ов родителя

                DamageDocument damageDoc = new DamageDocument(1, _currentDirctive.ItemId);
                _currentDirctive.DamageDocs.Add(damageDoc);

                DamageDocument imageDoc = new DamageDocument(2, _currentDirctive.ItemId);
                _currentDirctive.DamageDocs.Add(imageDoc);
            }

            int countCharts = 0, countImages = 0;
            foreach (DamageDocument document in _currentDirctive.DamageDocs)
            {

                if (document.DocumentTypeId == 1)
                {
                    DamageChartImage dci = _chartImages.FirstOrDefault(ci => ci.ChartName == document.DamageChart2DImageName);

                    if (dci != null)
                    {
                        document.DamageChart2DImageName = dci.ChartName;
                        document.DamageChartImage = dci.Image;
                    }

                    DamageChartsListView.Items.Add(document);
                }
                if (document.DocumentTypeId == 2)
                {
                    //DamageChartImageControl docControl = new DamageChartImageControl(doc);
                    //if (countImages == 0) docControl.Extended = true;
                    //else docControl.Extended = false;
                    //countImages++;

                    //_damageImagesFileControls.Add(docControl);
                    //docControl.Deleted += ImageDeleted;
                    //flowLayoutPanelImages.Controls.Remove(panelButtonsImages);
                    //flowLayoutPanelImages.Controls.Add(docControl);
                    //flowLayoutPanelImages.Controls.Add(panelButtonsImages);
                }
            }

            DamageChartsListView.SelectedIndex = 0;

            DamageDocument doc = DamageChartsListView.SelectedItem as DamageDocument;
            if (doc == null)
                return;

            foreach (DamageSector damageSector in doc.DamageSectors)
            {
                if (damageSector.DamageChartColumn < 0 || (damageSector.DamageChartColumn + 1) > ChartGrid.ColumnDefinitions.Count ||
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

                if (uiElement == null)
                    continue;

                ToggleButton button = uiElement as ToggleButton;
                if (button == null)
                    continue;
                button.IsChecked = true;
                button.Tag = damageSector;

                 System.Windows.Controls.RichTextBox rtb = new System.Windows.Controls.RichTextBox {FontFamily = FontFamily, FontSize = FontSize};
                FlowDocumentScrollViewer flowDocument = new FlowDocumentScrollViewer();
                string tooltipTex = string.IsNullOrEmpty(damageSector.Remarks) ? "No Information" : damageSector.Remarks;
                try
                {
                    //TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                    var documentBytes = Encoding.UTF8.GetBytes(tooltipTex);
                    using (var reader = new MemoryStream(documentBytes))
                    {
                        reader.Position = 0;
                        rtb.SelectAll();
                        rtb.Selection.Load(reader, System.Windows.DataFormats.Rtf);
                    }
                    flowDocument.Document = rtb.Document;
                }
                catch (Exception)
                {
                }
                button.ToolTip = flowDocument;
            }
        }
        #endregion

        #region public virtual bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public virtual bool GetChangeStatus()
        {
            List<DamageDocument> damageDocuments = DamageChartsListView.Items.OfType<DamageDocument>()
                .Where(d => d.DamageChart2DImageName != _selectDamageChartImage.ChartName).ToList();

            //Разное кол-во элементов в списке и кол-во элементов в объекте
            if (damageDocuments.Count != _currentDirctive.DamageDocs.Count)
                return true;
            //Наличие в списке несохраненного элемента
            if (damageDocuments.FirstOrDefault(d => d.ItemId <= 0) != null)
                return true;
            foreach (DamageDocument document in damageDocuments)
            {
                //Наличие в графике несохраненного сектора
                if (document.DamageSectors.FirstOrDefault(d => d.ItemId <= 0) != null)
                    return true;
                //Наличие в графике удаляемого сектора
                if (document.DamageSectors.FirstOrDefault(d => d.IsDeleted) != null)
                    return true;
            }
            return false;
        }

        #endregion

        #region public virtual bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateData(out string message)
        {
            message = "";

            return true;
        }

        #endregion

        #region public virtual void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public virtual void ApplyChanges()
        {
            List<DamageDocument> docsInList = DamageChartsListView.Items.OfType<DamageDocument>()
                .Where(d => d.DamageChart2DImageName != _selectDamageChartImage.ChartName).ToList();

            List<DamageDocument> docsToDelete = new List<DamageDocument>(_currentDirctive.DamageDocs);
            _currentDirctive.DamageDocs.Clear();

            foreach (DamageDocument doc in docsInList)
            {
                if (docsToDelete.Contains(doc))
                    docsToDelete.Remove(doc);
                _currentDirctive.DamageDocs.Add(doc);
            }
            foreach (DamageDocument docToDelete in docsToDelete)
            {
                if (docToDelete.ItemId > 0)
                {
                    docToDelete.IsDeleted = true;
                    _currentDirctive.DamageDocs.Add(docToDelete);
                }
            }
        }
        #endregion

        #region public virtual void AbortChanges()
        public virtual void AbortChanges()
        {
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
                    ((Button)uiElement).Click -= DamageSectorButtonClick;
            }
            ChartGrid.Children.Clear();

            DamageChartImage dci = ChartComboBox.SelectedItem as DamageChartImage ?? _selectDamageChartImage;
            if (dci == null || dci.Image == null)
                return;

            try
            {
                BitmapConverter converter = new BitmapConverter();
                ImageSource imageSource = (ImageSource)converter.Convert(dci.Image,null,null,null);

                ChartGrid.Width = imageSource.Width;
                ChartGrid.Height = imageSource.Height;
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
                    newButton.Click += DamageSectorButtonClick;

                    Grid.SetColumn(newButton, i);
                    Grid.SetRow(newButton, j);
                    ChartGrid.Children.Add(newButton);
                }
            }

            DamageDocument doc = DamageChartsListView.SelectedItem as DamageDocument;
            if (doc == null)
                return;
            if (doc.DamageChart2DImageName == dci.ChartName)
            {
                foreach (DamageSector damageSector in doc.DamageSectors)
                {
                    if (damageSector.DamageChartColumn < 0 || (damageSector.DamageChartColumn + 1) > ChartGrid.ColumnDefinitions.Count ||
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

                    if (uiElement == null)
                        continue;

                    ToggleButton button = uiElement as ToggleButton;
                    if (button == null)
                        continue;
                    button.IsChecked = true;
                    button.Tag = damageSector;

                    System.Windows.Controls.RichTextBox rtb = new System.Windows.Controls.RichTextBox() { FontFamily = FontFamily, FontSize = FontSize };
                    FlowDocumentScrollViewer flowDocument = new FlowDocumentScrollViewer();
                    string tooltipTex = string.IsNullOrEmpty(damageSector.Remarks) ? "No Information" : damageSector.Remarks;
                    try
                    {
                        //TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                        var documentBytes = Encoding.UTF8.GetBytes(tooltipTex);
                        using (var reader = new MemoryStream(documentBytes))
                        {
                            reader.Position = 0;
                            rtb.SelectAll();
                            rtb.Selection.Load(reader, System.Windows.DataFormats.Rtf);
                        }
                        flowDocument.Document = rtb.Document;
                    }
                    catch (Exception)
                    {
                    }
                    button.ToolTip = flowDocument;
                }    
            }
            else
            {
                doc.DamageChartImage = dci.Image;
                doc.DamageChart2DImageName = dci.ChartName;
            }
        }
        #endregion

        #region private void DamageSectorButtonClick(object sender, RoutedEventArgs e)
        private void DamageSectorButtonClick(object sender, RoutedEventArgs e)
        {
            DamageDocument doc = DamageChartsListView.SelectedItem as DamageDocument;
            if (doc == null)
                return;

            ToggleButton button = sender as ToggleButton;
            if (button == null)
                return;

            if (button.IsChecked == true)
            {
                if (button.Tag == null)
                {
                    DamageSector newDamageSector = new DamageSector
                    {
                        DamageChartColumn = Grid.GetColumn(button),
                        DamageChartRow = Grid.GetRow(button),
                        DamageDocument = doc,
                    };

                    button.Tag = newDamageSector;

                    doc.DamageSectors.Add(newDamageSector);
                }
                else
                {
                    DamageSector damageSector = button.Tag as DamageSector;
                    if(damageSector == null)
                        return;
                    if (damageSector.ItemId > 0)
                        damageSector.IsDeleted = false;
                }
            }
            else
            {
                if (button.Tag != null)
                {
                    DamageSector damageSector = button.Tag as DamageSector;
                    if (damageSector == null)
                        return;
                    if (damageSector.ItemId > 0)
                        damageSector.IsDeleted = true;
                    else button.Tag = null;
                }  
            }
            //button.IsChecked = !button.IsChecked;
        }
        #endregion

        #region private void ContextMenuButtonClick(object sender, RoutedEventArgs e)
        private void ContextMenuButtonClick(object sender, RoutedEventArgs e)
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
                    parent = ((ContextMenu)parent).PlacementTarget;
                }
                if (parent is ToggleButton)
                {
                    button = parent as ToggleButton;
                    break;
                }
                if (parent is FrameworkElement)
                {
                    parent = ((FrameworkElement)parent).Parent;
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
                System.Windows.Controls.RichTextBox rtb = new System.Windows.Controls.RichTextBox() {FontFamily = FontFamily, FontSize = FontSize};
                FlowDocumentScrollViewer flowDocument = new FlowDocumentScrollViewer();
                string tooltipTex = string.IsNullOrEmpty(sector.Remarks) ? "No Information" : sector.Remarks;
                try
                {
                    //TextRange tr = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                    var documentBytes = Encoding.UTF8.GetBytes(tooltipTex);
                    using (var reader = new MemoryStream(documentBytes))
                    {
                        reader.Position = 0;
                        rtb.SelectAll();
                        rtb.Selection.Load(reader, System.Windows.DataFormats.Rtf);
                    }

                    //using (var reader = new MemoryStream(documentBytes))
                    //{
                    //    tr.Load(reader, System.Windows.DataFormats.Rtf);
                    //}
                    flowDocument.Document = rtb.Document;
                }
                catch (Exception)
                {
                }
                button.ToolTip = flowDocument;
            }
        }
        #endregion

        #region private void AddNewChartButtonOnClick(object sender, RoutedEventArgs e)
        private void AddNewChartButtonOnClick(object sender, RoutedEventArgs e)
        {
            DamageDocument newDoc = new DamageDocument(1, _currentDirctive.ItemId);
            DamageChartImage dci =
                _chartImages.FirstOrDefault(ci => ci.ChartName == newDoc.DamageChart2DImageName) ?? _selectDamageChartImage;

            if (dci != null)
            {
                newDoc.DamageChart2DImageName = dci.ChartName;
                newDoc.DamageChartImage = dci.Image;
            }

            DamageChartsListView.Items.Add(newDoc);
            DamageChartsListView.SelectedIndex = DamageChartsListView.Items.Count - 1;

        }
        #endregion

        #region private void PrevLargeChartButton_OnClick(object sender, RoutedEventArgs e)
        private void PrevLargeChartButton_OnClick(object sender, RoutedEventArgs e)
        {
            if(DamageChartsListView.SelectedIndex > 0)
                DamageChartsListView.SelectedIndex -= 1;
        }
        #endregion

        #region private void NextLargeChartButton_OnClick(object sender, RoutedEventArgs e)
        private void NextLargeChartButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (DamageChartsListView.SelectedIndex < DamageChartsListView.Items.Count - 1)
                DamageChartsListView.SelectedIndex += 1;
        }
        #endregion

        #region private void DamageChartsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        private void DamageChartsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DamageDocument doc = DamageChartsListView.SelectedItem as DamageDocument;
            if(doc == null)
                return;

            DamageChartImage dci =
                _chartImages.FirstOrDefault(ci => ci.ChartName == doc.DamageChart2DImageName) ?? _selectDamageChartImage;

            if (dci == null)
                return;

            ChartComboBox.SelectedItem = dci;
        }
        #endregion

        #region private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            FrameworkElement uiElement = sender as FrameworkElement;
            if(uiElement == null)
                return;
            DamageDocument doc = uiElement.Tag as DamageDocument;

            if (doc != null)
            {
                DamageChartsListView.Items.Remove(doc);
            }

            if (DamageChartsListView.Items.Count > 0)
                DamageChartsListView.SelectedIndex = 0;
        }
        #endregion
    }
}
