using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    /// <summary>
    /// Форма для формирования начального акта
    /// </summary>
    public partial class InitialOrderComposeForm : MetroForm
    {
        #region Fields

        private const string DefaultPriority = "None";
        private const string TaskPriority = "Task Performance";

        private readonly BaseEntityObject _parent;
        private readonly List<InitialOrderRecord> _resultRecords = new List<InitialOrderRecord>(); 
        #endregion

        #region Properties

        /// <summary>
        /// Возвращает записи, сформированные при работе формы
        /// </summary>
        public List<InitialOrderRecord> ResultRecords
        {
            get
            {
                return _resultRecords;     
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Создает форму для формирования начального акта
        /// </summary>
        public InitialOrderComposeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает форму для формирования начального акта на основе переданных продуктов
        /// </summary>
        public InitialOrderComposeForm(BaseEntityObject parent, IEnumerable<Product> products) : this()
        {
            _parent = parent;

            UpdateInformation(products);
        }

        /// <summary>
        /// Создает форму для формирования начального акта на основе переданных данных о планировании исползования расходников
        /// </summary>
        public InitialOrderComposeForm(BaseEntityObject parent, IEnumerable<ScheduleDirectiveProduct> scheduleProducts)
            : this()
        {
            _parent = parent;

            UpdateInformation(scheduleProducts);
        }
        #endregion

        #region private void UpdateInformation(IEnumerable<Product> products)
        ///<summary>
        ///</summary>
        private void UpdateInformation(IEnumerable<Product> products)
        {
            dataGridViewItems.Rows.Clear();

            _resultRecords.Clear();

            DataGridViewComboBoxColumn comboBoxColumn = ColumnPriority;
            IDictionaryCollection dc;
            try
            {
                dc = GlobalObjects.CasEnvironment.GetDictionary<DeferredCategory>();
            }
            catch (Exception)
            {
                dc = null;
            }
            if (dc != null)
            {
                List<KeyValuePair<string, IDictionaryItem>> list;
                if (_parent is Aircraft)
                {
                    list = dc.OfType<DeferredCategory>()
                        .Where(d => d.AircraftModel != null && d.AircraftModel.Equals(((Aircraft)_parent).Model))
                        .Select(di => new KeyValuePair<string, IDictionaryItem>(di.ToString(), di))
                        .ToList();   
                }
                else
                {
                    list = new List<KeyValuePair<string, IDictionaryItem>>();
                }
                comboBoxColumn.DisplayMember = "Key";
                comboBoxColumn.ValueMember = "Value";
                comboBoxColumn.DataSource = list;

                comboBoxPriority.DisplayMember = "Key";
                comboBoxPriority.ValueMember = "Value";
                comboBoxPriority.DataSource = list;
            }

            if(products == null)
                return;

            comboBoxPriority.SelectedIndexChanged -= ComboBoxPrioritySelectedIndexChanged;
            checkBoxNew.CheckedChanged -= CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged -= CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged -= CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged -= CheckBoxRepairCheckedChanged;

            foreach (Product product in products)
            {

                dataGridViewItems.Rows.Add(1);
                DataGridViewRow r = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];

                r.Cells[ColumnProduct.Index].Value = product.ToString();
                r.Cells[ColumnQuantity.Index].Value = 1;
                r.Cells[ColumnPriority.Index].Value = null;
                r.Cells[ColumnNew.Index].Value = true;
                r.Cells[ColumnServiceable.Index].Value = true;
                r.Cells[ColumnOH.Index].Value = true;
                r.Cells[ColumnRepair.Index].Value = true;

                r.Tag = product;
            }

            comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            checkBoxNew.CheckedChanged += CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged += CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged += CheckBoxRepairCheckedChanged;
        }
        #endregion

        #region private void UpdateInformation(IEnumerable<ScheduleDirectiveProduct> scheduleProducts)
        ///<summary>
        ///</summary>
        private void UpdateInformation(IEnumerable<ScheduleDirectiveProduct> scheduleProducts)
        {
            dataGridViewItems.Rows.Clear();

            _resultRecords.Clear();

            DataGridViewComboBoxColumn comboBoxColumn = ColumnPriority;
            IDictionaryCollection dc;
            try
            {
                dc = GlobalObjects.CasEnvironment.GetDictionary<DeferredCategory>();
            }
            catch (Exception)
            {
                dc = null;
            }
            if (dc != null)
            {
                List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();

                list.Add(new KeyValuePair<string, object>(DefaultPriority, DefaultPriority));
                list.Add(new KeyValuePair<string, object>(TaskPriority, TaskPriority));
                if (_parent is Aircraft)
                {
                    list.AddRange(dc.OfType<DeferredCategory>()
                                    .Where(d => d.AircraftModel != null && d.AircraftModel.Equals(((Aircraft)_parent).Model))
                                    .Select(di => new KeyValuePair<string, object>(di.ToString(), di))
                                    .ToList());
                }

                comboBoxColumn.DisplayMember = "Key";
                comboBoxColumn.ValueMember = "Value";
                comboBoxColumn.DataSource = list;

                comboBoxPriority.DisplayMember = "Key";
                comboBoxPriority.ValueMember = "Value";
                comboBoxPriority.DataSource = new List<KeyValuePair<string, object>>(list);
            }

            if (scheduleProducts == null)
                return;

            comboBoxPriority.SelectedIndexChanged -= ComboBoxPrioritySelectedIndexChanged;
            checkBoxNew.CheckedChanged -= CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged -= CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged -= CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged -= CheckBoxRepairCheckedChanged;

            foreach (ScheduleDirectiveProduct product in scheduleProducts)
            {

                dataGridViewItems.Rows.Add(1);
                DataGridViewRow r = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];

                r.Cells[ColumnProduct.Index].Value = product.Product.ToString();
                r.Cells[ColumnTask.Index].Value = product.Directive.ToString();
                r.Cells[ColumnQuantity.Index].Value = 1;
                r.Cells[ColumnPriority.Index].Value = TaskPriority;
                r.Cells[ColumnNew.Index].Value = true;
                r.Cells[ColumnServiceable.Index].Value = true;
                r.Cells[ColumnOH.Index].Value = true;
                r.Cells[ColumnRepair.Index].Value = true;

                r.Tag = product;
            }


            comboBoxPriority.SelectedValue = TaskPriority;

            comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            checkBoxNew.CheckedChanged += CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged += CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged += CheckBoxRepairCheckedChanged;
        }
        #endregion

        #region private bool ValidateData()

        private bool ValidateData()
        {
            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                if (Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value) == 0.0)
                {
                    MessageBox.Show("Not set Quantity",
                                     new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);

                    row.Cells[ColumnQuantity.Index].Style.BackColor = Color.Red;

                    return false;
                }
            }
            return true;
        }
        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private void SaveData()
        {
            #region Product

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>().Where(r => r.Tag is Product))
            {
                Product p = (Product)row.Tag;
                double quantity = Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value);
                DeferredCategory category = row.Cells[ColumnPriority.Index].Value as DeferredCategory;
                bool @new = Convert.ToBoolean(row.Cells[ColumnNew.Index].Value);
                bool serv = Convert.ToBoolean(row.Cells[ColumnServiceable.Index].Value);
                bool overhaul = Convert.ToBoolean(row.Cells[ColumnOH.Index].Value);
                bool repair = Convert.ToBoolean(row.Cells[ColumnRepair.Index].Value);

                InitialOrderRecord record =
                    _resultRecords.FirstOrDefault(r => r.PackageItemType == p.SmartCoreObjectType &&
                                                       r.PackageItemId == p.ItemId);
                if (record != null)
                {
                    record.Quantity += quantity;

                    if (@new)
                        record.CostCondition = record.CostCondition | ComponentStatus.New;
                    if (serv)
                        record.CostCondition = record.CostCondition | ComponentStatus.Serviceable;
                    if (overhaul)
                        record.CostCondition = record.CostCondition | ComponentStatus.Overhaul;
                    if (repair)
                        record.CostCondition = record.CostCondition | ComponentStatus.Repair;
                }
                else
                {
                    ComponentStatus costCondition = ComponentStatus.Unknown;
                    if (@new)
                        costCondition = costCondition | ComponentStatus.New;
                    if (serv)
                        costCondition = costCondition | ComponentStatus.Serviceable;
                    if (overhaul)
                        costCondition = costCondition | ComponentStatus.Overhaul;
                    if (repair)
                        costCondition = costCondition | ComponentStatus.Repair;

                    record = new InitialOrderRecord(-1, p, quantity, _parent, DateTime.Now, costCondition, null, category);

                    _resultRecords.Add(record);
                }
            }
            #endregion

            #region ScheduleDirectiveProduct

            foreach (DataGridViewRow row in dataGridViewItems.Rows
                        .OfType<DataGridViewRow>()
                        .Where(r => r.Tag is ScheduleDirectiveProduct))
            {
                ScheduleDirectiveProduct p = (ScheduleDirectiveProduct)row.Tag;
                object priotiryValue = row.Cells[ColumnPriority.Index].Value;

                if (priotiryValue is DeferredCategory ||
                    priotiryValue.ToString() == DefaultPriority)
                {
                    double quantity = Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value);
                    DeferredCategory category = priotiryValue as DeferredCategory;
                    bool @new = Convert.ToBoolean(row.Cells[ColumnNew.Index].Value);
                    bool serv = Convert.ToBoolean(row.Cells[ColumnServiceable.Index].Value);
                    bool overhaul = Convert.ToBoolean(row.Cells[ColumnOH.Index].Value);
                    bool repair = Convert.ToBoolean(row.Cells[ColumnRepair.Index].Value);

                    InitialOrderRecord record =
                        _resultRecords.FirstOrDefault(r => r.PackageItemType == p.Product.SmartCoreObjectType &&
                                                           r.PackageItemId == p.Product.ItemId);
                    if (record != null)
                    {
                        record.Quantity += quantity;

                        if (@new)
                            record.CostCondition = record.CostCondition | ComponentStatus.New;
                        if (serv)
                            record.CostCondition = record.CostCondition | ComponentStatus.Serviceable;
                        if (overhaul)
                            record.CostCondition = record.CostCondition | ComponentStatus.Overhaul;
                        if (repair)
                            record.CostCondition = record.CostCondition | ComponentStatus.Repair;
                    }
                    else
                    {
                        ComponentStatus costCondition = ComponentStatus.Unknown;
                        if (@new)
                            costCondition = costCondition | ComponentStatus.New;
                        if (serv)
                            costCondition = costCondition | ComponentStatus.Serviceable;
                        if (overhaul)
                            costCondition = costCondition | ComponentStatus.Overhaul;
                        if (repair)
                            costCondition = costCondition | ComponentStatus.Repair;

                        record = new InitialOrderRecord(-1, p.Product, quantity, _parent, 
                                                        DateTime.Now, costCondition, null, category);

                        _resultRecords.Add(record);
                    }    
                }
                else if (priotiryValue.ToString() == TaskPriority)
                {
                    double quantity = Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value);
                    NextPerformance performance = p.Performance;
                    bool @new = Convert.ToBoolean(row.Cells[ColumnNew.Index].Value);
                    bool serv = Convert.ToBoolean(row.Cells[ColumnServiceable.Index].Value);
                    bool overhaul = Convert.ToBoolean(row.Cells[ColumnOH.Index].Value);
                    bool repair = Convert.ToBoolean(row.Cells[ColumnRepair.Index].Value);

                    ComponentStatus costCondition = ComponentStatus.Unknown;
                    if (@new)
                        costCondition = costCondition | ComponentStatus.New;
                    if (serv)
                        costCondition = costCondition | ComponentStatus.Serviceable;
                    if (overhaul)
                        costCondition = costCondition | ComponentStatus.Overhaul;
                    if (repair)
                        costCondition = costCondition | ComponentStatus.Repair;

                    InitialOrderRecord record = 
                        new InitialOrderRecord(-1, p.Product, quantity, _parent, 
                                               DateTime.Now, costCondition, performance);

                    _resultRecords.Add(record);    
                }
            }
            #endregion
        }

        #endregion

        #region private void CheckBoxNewCheckedChanged(object sender, EventArgs e)

        private void CheckBoxNewCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNew.CheckState == CheckState.Indeterminate)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[ColumnNew.Index].Value = checkBoxNew.Checked;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void CheckBoxServiceableCheckedChanged(object sender, EventArgs e)
        private void CheckBoxServiceableCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxServiceable.CheckState == CheckState.Indeterminate)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[ColumnServiceable.Index].Value = checkBoxServiceable.Checked;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void CheckBoxOverhaulCheckedChanged(object sender, EventArgs e)

        private void CheckBoxOverhaulCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOverhaul.CheckState == CheckState.Indeterminate)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[ColumnOH.Index].Value = checkBoxOverhaul.Checked;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void CheckBoxRepairCheckedChanged(object sender, EventArgs e)

        private void CheckBoxRepairCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRepair.CheckState == CheckState.Indeterminate)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[ColumnRepair.Index].Value = checkBoxRepair.Checked;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void ComboBoxPrioritySelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxPrioritySelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPriority.SelectedItem == null)
                return;

            dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
            {
                row.Cells[ColumnPriority.Index].Value = comboBoxPriority.SelectedValue;
            }

            dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        }
        #endregion

        #region private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)

        private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            #region //Проверка колонки "Приоритет"
            if (e.ColumnIndex == ColumnPriority.Index)
            {
                comboBoxPriority.SelectedIndexChanged -= ComboBoxPrioritySelectedIndexChanged;

                DeferredCategory selectedValue = dataGridViewItems[ColumnPriority.Index, e.RowIndex].Value as DeferredCategory;
                DataGridViewRow row = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells[ColumnPriority.Index].Value is DeferredCategory &&
                                         (DeferredCategory)r.Cells[ColumnPriority.Index].Value != selectedValue);
                DeferredCategory anotherValue = row != null
                    ? row.Cells[ColumnPriority.Index].Value as DeferredCategory
                    : null;
                DataGridViewRow rowWithNullValue = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells[ColumnPriority.Index].Value as DeferredCategory == null);

                if (selectedValue != null && anotherValue != null ||
                    selectedValue == null && anotherValue != null ||
                    selectedValue != null && rowWithNullValue != null)
                    comboBoxPriority.SelectedItem = null;
                else comboBoxPriority.SelectedItem = selectedValue;

                comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            }
            #endregion

            #region //Проверка колонки "Кол-во"
            if (e.ColumnIndex == ColumnQuantity.Index)
            {
                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                decimal value = Convert.ToDecimal(cell.Value);

                cell.Style.BackColor = value > 0 ? Color.White : Color.Red;
            }
            #endregion

            #region //Проверка колонки "Заказать новые"
            if (e.ColumnIndex == ColumnNew.Index)
            {
                checkBoxNew.CheckedChanged -= CheckBoxNewCheckedChanged;

                IEnumerable<DataGridViewRow> rows = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .ToArray();

                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnNew.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnNew.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxNew.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxNew.CheckState = CheckState.Checked;
                else checkBoxNew.CheckState = CheckState.Unchecked;

                checkBoxNew.CheckedChanged += CheckBoxNewCheckedChanged;
            }
            #endregion

            #region //Проверка колонки "Заказать после ТО"
            if (e.ColumnIndex == ColumnServiceable.Index)
            {
                checkBoxServiceable.CheckedChanged -= CheckBoxServiceableCheckedChanged;

                IEnumerable<DataGridViewRow> rows = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .ToArray();

                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnServiceable.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnServiceable.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxServiceable.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxServiceable.CheckState = CheckState.Checked;
                else checkBoxServiceable.CheckState = CheckState.Unchecked;

                checkBoxServiceable.CheckedChanged += CheckBoxServiceableCheckedChanged;
            }
            #endregion

            #region //Проверка колонки "Заказать после Кап. ремонта"
            if (e.ColumnIndex == ColumnOH.Index)
            {
                checkBoxOverhaul.CheckedChanged -= CheckBoxOverhaulCheckedChanged;

                IEnumerable<DataGridViewRow> rows = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .ToArray();

                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnOH.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnOH.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxOverhaul.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxOverhaul.CheckState = CheckState.Checked;
                else checkBoxOverhaul.CheckState = CheckState.Unchecked;

                checkBoxOverhaul.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            }
            #endregion

            #region //Проверка колонки "Заказать после ремонта"
            if (e.ColumnIndex == ColumnRepair.Index)
            {
                checkBoxRepair.CheckedChanged -= CheckBoxOverhaulCheckedChanged;

                IEnumerable<DataGridViewRow> rows = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .ToArray();

                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnRepair.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnRepair.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxRepair.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxRepair.CheckState = CheckState.Checked;
                else checkBoxRepair.CheckState = CheckState.Unchecked;

                checkBoxRepair.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            }
            #endregion
        }
        #endregion

        #region private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.Provider.Logger.Log("Error in Compose Initial Form Data Grid", e.Exception);
        }
        #endregion

        #region private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)
        private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            Point po = ((DataGridView)sender).CurrentCellAddress;

            if (po.X == ColumnPriority.Index || 
                po.X == ColumnNew.Index || 
                po.X == ColumnServiceable.Index ||
                po.X == ColumnOH.Index ||
                po.X == ColumnRepair.Index)
                dataGridViewItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region private void ButtonComposeClick(object sender, EventArgs e)
        private void ButtonComposeClick(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error, while close work package.", ex);
                return;
            }

            DialogResult = DialogResult.OK;
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        #endregion

    }
}
