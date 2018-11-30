using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.Messages;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения списка выполненных работ по Maintenance Status
    /// </summary>
    public class MaintenanceStatusComplianceControl : UserControl
    {

        #region Fields

        private Aircraft aircraft;

        private AvButtonT buttonRegisterCompliance;
        private Button buttonApply;
        private AvButtonT buttonDeleteRecord;
        private AvButtonT buttonEditRecord;
        private DateTimePicker dateTimePickerSince;
        private DateTimePicker dateTimePickerTill;
        private MaintenancePerformance[] displayedItems = new MaintenancePerformance[0];
        private Label labelSince;
        private Label labelTill;
        private MaintenanceComplianceListView maintenanceComplianceListView;
        readonly Icons icons = new Icons();

        /// <summary>
        /// Определяется свойтсво только для чтения
        /// </summary>
        private bool readOnly = false;

        private const int BOTTOM_MARGIN = 10;
        private const int LEFT_MARGIN = 10;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка выполненных работ по Maintenance Status
        /// </summary>
        /// <param name="aircraft">ВС</param>
        public MaintenanceStatusComplianceControl(Aircraft aircraft)
        {
            this.aircraft = aircraft;
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region public bool ReadOnly

        /// <summary>
        /// Определяется свойтсво только для чтения
        /// </summary>
        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                buttonRegisterCompliance.Enabled = !value;
            }
        }

        #endregion

        #region public MaintenancePerformance[] DisplayedItems

        /// <summary>
        /// Отображаемые элементы
        /// </summary>
        public MaintenancePerformance[] DisplayedItems
        {
            get { return displayedItems; }
        }

        #endregion

        #region public DateTime SelectionSince

        /// <summary>
        /// Начало выборки
        /// </summary>
        public DateTime SelectionSince
        {
            get { return dateTimePickerSince.Value; }
        }

        #endregion

        #region public DateTime SelectionTill

        /// <summary>
        /// Конец выборки
        /// </summary>
        public DateTime SelectionTill
        {
            get { return dateTimePickerTill.Value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            buttonRegisterCompliance = new AvButtonT();
            buttonDeleteRecord = new AvButtonT();
            buttonEditRecord = new AvButtonT();
            maintenanceComplianceListView = new MaintenanceComplianceListView();
            dateTimePickerSince = new DateTimePicker();
            dateTimePickerTill = new DateTimePicker();
            labelSince = new Label();
            labelTill = new Label();
            buttonApply = new Button();
            // 
            // labelSince
            // 
            labelSince.AutoSize = true;
            labelSince.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSince.Location = new Point(LEFT_MARGIN, 5);
            labelSince.Size = new Size(59, 13);
            labelSince.Text = "Date From:";
            // 
            // dateTimePickerSince
            // 
            dateTimePickerSince.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerSince.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerSince.MaxDate = DateTime.Today;
            dateTimePickerSince.Format = DateTimePickerFormat.Custom;
            dateTimePickerSince.Location = new Point(LEFT_MARGIN + 100, 0);
            dateTimePickerSince.Size = new Size(151, 23);
            dateTimePickerSince.TabIndex = 0;
            dateTimePickerSince.ValueChanged += dateTimePickerSince_ValueChanged;
            dateTimePickerSince.Value = new DateTime(1950, 1, 1);
            // 
            // labelTill
            // 
            labelTill.AutoSize = true;
            labelTill.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTill.Location = new Point(LEFT_MARGIN + 270, 5);
            labelTill.Size = new Size(49, 13);
            labelTill.Text = "Date To:";
            // 
            // dateTimePickerTill
            // 
            dateTimePickerTill.CustomFormat = new TermsProvider()["DateFormat"].ToString();
            dateTimePickerTill.MaxDate = DateTime.Today;
            dateTimePickerTill.Font = Css.OrdinaryText.Fonts.RegularFont;
            dateTimePickerTill.Format = DateTimePickerFormat.Custom;
            dateTimePickerTill.Location = new Point(LEFT_MARGIN + 350, 0);
            dateTimePickerTill.Size = new Size(145, 23);
            dateTimePickerTill.TabIndex = 1;
            dateTimePickerTill.ValueChanged += dateTimePickerTill_ValueChanged;
            // 
            // buttonApply
            // 
            buttonApply.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonApply.Location = new Point(LEFT_MARGIN + 520, 0);
            buttonApply.Size = new Size(75, 25);
            buttonApply.TabIndex = 2;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            //
            // maintenanceComplianceListView
            //
          //maintenanceComplianceListView.DoubleClickEnable = true;
            maintenanceComplianceListView.Location = new Point(LEFT_MARGIN, 40);
            //maintenanceComplianceListView.Scrollable = true;
            //maintenanceComplianceListView.ShowGroups = true;
            maintenanceComplianceListView.Width = 1250;
            //maintenanceComplianceListView.Height = 1250;
           // maintenanceComplianceListView.TabIndex = 3;
            maintenanceComplianceListView.ItemDoubleClick += maintenanceComplianceListView1_ItemDoubleClick;
            maintenanceComplianceListView.SelectedItemsChanged += maintenanceComplianceListView_SelectedItemsChanged;
            maintenanceComplianceListView_SelectedItemsChanged(maintenanceComplianceListView, new SelectedItemsChangeEventArgs(0));
            maintenanceComplianceListView.SizeChanged += maintenanceComplianceListView_SizeChanged;
            // 
            // buttonRegisterCompliance
            // 
            buttonRegisterCompliance.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonRegisterCompliance.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonRegisterCompliance.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonRegisterCompliance.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonRegisterCompliance.Icon = icons.Add; 
            buttonRegisterCompliance.IconNotEnabled = icons.AddGray; 
            buttonRegisterCompliance.Size = new Size(150, 50);
            buttonRegisterCompliance.TabIndex = 4;
            buttonRegisterCompliance.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonRegisterCompliance.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonRegisterCompliance.TextMain = "Register Compliance";
            buttonRegisterCompliance.TextSecondary = "";
            buttonRegisterCompliance.Click += buttonAddRecord_Click;
            buttonRegisterCompliance.Enabled = aircraft.HasPermission(Users.CurrentUser, DataEvent.Update);
            // 
            // buttonEditRecord
            // 
            buttonEditRecord.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditRecord.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEditRecord.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditRecord.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonEditRecord.Icon = icons.Edit;
            buttonEditRecord.IconNotEnabled = icons.EditGray;
            buttonEditRecord.IconLayout = ImageLayout.Center;
            buttonEditRecord.Size = new Size(130, 50);
            buttonEditRecord.TabIndex = 5;
            buttonEditRecord.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonEditRecord.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEditRecord.TextMain = "Edit";
            buttonEditRecord.TextSecondary = "";
            buttonEditRecord.Click += buttonEditRecord_Click;
            // 
            // buttonDeleteRecord
            // 
            buttonDeleteRecord.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteRecord.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteRecord.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteRecord.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteRecord.Icon = icons.Delete;
            buttonDeleteRecord.IconNotEnabled = icons.DeleteGray;
            buttonDeleteRecord.IconLayout = ImageLayout.Center;
            buttonDeleteRecord.Size = new Size(150, 50);
            buttonDeleteRecord.TabIndex = 6;
            buttonDeleteRecord.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteRecord.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonDeleteRecord.TextMain = "Remove";
            buttonDeleteRecord.TextSecondary = "";
            buttonDeleteRecord.Click += buttonDeleteRecord_Click;
            // 
            // MaintenanceStatusComplianceControl
            // 
            Size = new Size(1250, 300);
            SizeChanged += MaintenanceStatusComplianceControl_SizeChanged;
            Controls.Add(buttonApply);
            Controls.Add(labelTill);
            Controls.Add(labelSince);
            Controls.Add(dateTimePickerTill);
            Controls.Add(dateTimePickerSince);
            Controls.Add(maintenanceComplianceListView);
            Controls.Add(buttonRegisterCompliance);
            Controls.Add(buttonDeleteRecord);
            Controls.Add(buttonEditRecord);
            maintenanceComplianceListView_SizeChanged(this, null);
        }

        #endregion

        #region private void MaintenanceStatusComplianceControl_SizeChanged(object sender, EventArgs e)

        private void MaintenanceStatusComplianceControl_SizeChanged(object sender, EventArgs e)
        {
            maintenanceComplianceListView.Width = Width - LEFT_MARGIN;
        }

        #endregion

        #region private void maintenanceComplianceListView1_ItemDoubleClick(object sender, ItemDoubleClickEventArgs<MaintenancePerformance> e)

        private void maintenanceComplianceListView1_ItemDoubleClick(object sender, ItemDoubleClickEventArgs<MaintenancePerformance> e)
        {
            if (aircraft.HasPermission(Users.CurrentUser, DataEvent.Update))
                EditSelectedItem();
        }

        #endregion

        #region private void maintenanceComplianceListView_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void maintenanceComplianceListView_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            bool permission = aircraft.HasPermission(Users.CurrentUser, DataEvent.Update);

            buttonEditRecord.Enabled = (permission && (e.ItemsCount > 0) && (e.ItemsCount < 2));
            buttonDeleteRecord.Enabled = (permission && (e.ItemsCount > 0));
        }

        #endregion

        #region private void maintenanceComplianceListView_SizeChanged(object sender, EventArgs e)

        private void maintenanceComplianceListView_SizeChanged(object sender, EventArgs e)
        {
            buttonRegisterCompliance.Location = new Point(maintenanceComplianceListView.Left, maintenanceComplianceListView.Bottom + BOTTOM_MARGIN);
            buttonEditRecord.Location = new Point(buttonRegisterCompliance.Right, maintenanceComplianceListView.Bottom + BOTTOM_MARGIN);
            buttonDeleteRecord.Location = new Point(buttonEditRecord.Right, maintenanceComplianceListView.Bottom + BOTTOM_MARGIN);
            Height = buttonRegisterCompliance.Bottom + 10;
        }

        #endregion

        #region private void DisplayItems()

        /// <summary>
        /// Отобразить элементы
        /// </summary>
        private void DisplayItems()
        {
            if (aircraft != null)
            {
                MaintenancePerformance[] records = aircraft.GetMaintenanceRecords();
                MaintenancePerformance[] filteredItems =
                    MaintenancePerformancesCollection.GetRecords(
                        new RecordsCollection<MaintenancePerformance>.RecordsForPeriodSelector(
                            dateTimePickerSince.Value.Date, dateTimePickerTill.Value.Date), records);
                displayedItems = filteredItems;
                maintenanceComplianceListView.SetItemsArray(filteredItems);
                if (ItemsChanged != null)
                    ItemsChanged(maintenanceComplianceListView.ItemsListView.Items.Count == 0);
                maintenanceComplianceListView_SelectedItemsChanged(maintenanceComplianceListView, new SelectedItemsChangeEventArgs(0));
            }
        }

        #endregion

        #region public void DisplayItems(Aircraft parentAircraft)

        /// <summary>
        /// Отобразить элементы
        /// </summary>
        public void DisplayItems(Aircraft parentAircraft)
        {
            aircraft = parentAircraft;
            DisplayItems();
        }

        #endregion

        #region private void buttonRegisterCompliance_Click(object sender, EventArgs e)

        private void buttonAddRecord_Click(object sender, EventArgs e)
        {
            AddNewItem();
        }

        #endregion

        #region private void AddNewItem()

        private void AddNewItem()
        {
            MaintenancePerformanceForm form = new MaintenancePerformanceForm(aircraft.RegistrationNumber + ". Maintenance Status. New check");
            form.ReadOnly = readOnly;
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                MaintenancePerformance newItem = new MaintenancePerformance();
                if (form.SaveDisplayedData(newItem))
                {
                    aircraft.AddMaintenancePerformance(newItem);
                    DisplayItems();
                }
                else
                    CASMessage.Show(MessageType.InvalidValue, new object[] { "Check" });
            }
        }

        #endregion

        #region private void buttonEditRecord_Click(object sender, EventArgs e)

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            EditSelectedItem();
        }

        #endregion

        #region private void EditSelectedItem()

        private void EditSelectedItem()
        {
            MaintenancePerformance selectedItem = maintenanceComplianceListView.SelectedItem;
            if (selectedItem == null) return;
            string caption = aircraft.RegistrationNumber + ". Maintenance Status. " + selectedItem.CheckTypeExtended + " check";
            MaintenancePerformanceForm form = new MaintenancePerformanceForm(caption);
            form.ReadOnly = readOnly;
            form.UpdateDisplayedData(selectedItem);
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (form.SaveDisplayedData(selectedItem))
                {
                    selectedItem.Save(false);
                    DisplayItems();
                }
                else
                    CASMessage.Show(MessageType.InvalidValue, new object[] { "Check" });
            }
        }

        #endregion

        #region private void buttonDeleteRecord_Click(object sender, EventArgs e)

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            string message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "record");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    RemoveSelectedItems();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
                DisplayItems();
            }
        }

        #endregion

        #region private void RemoveSelectedItems()

        private void RemoveSelectedItems()
        {
            List<MaintenancePerformance> selectedItems = maintenanceComplianceListView.SelectedItems;
            if (selectedItems != null)
            {
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    MaintenancePerformance item = selectedItems[i];
                    aircraft.RemoveMaintenancePerformance(item);
                }
            }
        }

        #endregion

        #region private void dateTimePickerTill_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerTill_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
          //  DisplayItems();
        }

        #endregion

        #region private void dateTimePickerSince_ValueChanged(object sender, EventArgs e)

        private void dateTimePickerSince_ValueChanged(object sender, EventArgs e)
        {
            ValidateDates();
            //DisplayItems();
        }

        #endregion

        #region private void ValidateDates()

        private void ValidateDates()
        {
            if (dateTimePickerSince.Value > dateTimePickerTill.Value)
            {
                DateTime buffer = dateTimePickerTill.Value;
                dateTimePickerTill.Value = dateTimePickerSince.Value;
                dateTimePickerSince.Value = buffer;
            }
        }

        #endregion

        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            DisplayItems();
        }

        #endregion

        #endregion

        #region Delegates

        public delegate void MaintenanceListViewEventHandler(bool noRecords);

        #endregion

        #region Events

        public event MaintenanceListViewEventHandler ItemsChanged;

        #endregion
    }
}