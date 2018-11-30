using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    /// <summary>
    /// Форма для формирования котировочного акта
    /// </summary>
    public partial class QuotationOrderComposeForm : Form
    {
        #region Fields

        private readonly Supplier _toSupplier;
        private readonly List<RequestForQuotationRecord> _resultRecords = new List<RequestForQuotationRecord>();
        private readonly List<IORQORRelation> _iorqorRelations = new List<IORQORRelation>(); 
        #endregion

        #region Properties

        /// <summary>
        /// Возвращает записи, сформированные при работе формы
        /// </summary>
        public List<RequestForQuotationRecord> ResultRecord
        {
            get
            {
                return _resultRecords;     
            }
        }

        /// <summary>
        /// Возвращает записи, сформированные при работе формы
        /// </summary>
        public List<IORQORRelation> InitialQuotationRelations
        {
            get
            {
                return _iorqorRelations;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// Создает форму для формирования котировочного акта
        /// </summary>
        public QuotationOrderComposeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создает форму для формирования котировочного акта на основе переданных продуктов
        /// </summary>
        public QuotationOrderComposeForm(IEnumerable<Product> products, Supplier toSupplier = null)
            : this()
        {
            _toSupplier = toSupplier;

            UpdateInformation(products);
        }

        /// <summary>
        /// Создает форму для формирования котировочного акта на основе переданных записей в начальных актах
        /// </summary>
        public QuotationOrderComposeForm(IEnumerable<InitialOrderRecord> initialOrderRecords, Supplier toSupplier = null)
            : this()
        {
            _toSupplier = toSupplier;

            UpdateInformation(initialOrderRecords);
        }
        #endregion

        #region private void UpdateInformation(IEnumerable<Product> products)
        ///<summary>
        ///</summary>
        private void UpdateInformation(IEnumerable<Product> products)
        {
            dataGridViewItems.Rows.Clear();

            _resultRecords.Clear();

            //DataGridViewComboBoxColumn comboBoxColumn = ColumnPriority;
            //IDictionaryCollection dc;
            //try
            //{
            //    dc = GlobalObjects.CasEnvironment.Dictionaries[typeof(DeferredCategory)];
            //}
            //catch (Exception)
            //{
            //    dc = null;
            //}
            //if (dc != null)
            //{
            //    List<KeyValuePair<string, IDictionaryItem>> list;
            //    if (_parent is Aircraft)
            //    {
            //        list = dc.OfType<DeferredCategory>()
            //            .Where(d => d.AircraftModel != null && d.AircraftModel.Equals(((Aircraft)_parent).Model))
            //            .Select(di => new KeyValuePair<string, IDictionaryItem>(di.ToString(), di))
            //            .ToList();   
            //    }
            //    else
            //    {
            //        //list = dc.OfType<IDictionaryItem>()
            //        //    .Select(di => new KeyValuePair<string, IDictionaryItem>(di.ToString(), di))
            //        //    .ToList(); 
            //        list = new List<KeyValuePair<string, IDictionaryItem>>();
            //    }
            //    comboBoxColumn.DisplayMember = "Key";
            //    comboBoxColumn.ValueMember = "Value";
            //    comboBoxColumn.DataSource = list;

            //    comboBoxPriority.DisplayMember = "Key";
            //    comboBoxPriority.ValueMember = "Value";
            //    comboBoxPriority.DataSource = list;
            //}

            if(products == null)
                return;

            checkBoxOrder.CheckedChanged -= CheckBoxOrderCheckedChanged;
            checkBoxNew.CheckedChanged -= CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged -= CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged -= CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged -= CheckBoxRepairCheckedChanged;

            IEnumerable<IGrouping<Supplier, RequestForQuotationRecord>> quotationRecords;

            if (_toSupplier != null)
            {
                quotationRecords = 
                    products.Select(product => new RequestForQuotationRecord(product, 1, _toSupplier))
                            .GroupBy(qr => qr.ToSupplier);    
            }
            else
            {
                quotationRecords =
                    products.SelectMany(product => product.Suppliers.Select(supplier => new RequestForQuotationRecord(product, 1, supplier)))
                            .GroupBy(qr => qr.ToSupplier);    
            }

            foreach (IGrouping<Supplier, RequestForQuotationRecord> grouping in quotationRecords)
            {
                dataGridViewItems.Rows.Add(1);
                DataGridViewRow supplierRow = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];
                supplierRow.Cells[ColumnProduct.Index].Value = grouping.Key != null ? grouping.Key.ToString() : "No Supplier";
                supplierRow.Cells[ColumnQuantity.Index].Value = 0;
                supplierRow.Cells[ColumnQuantity.Index].ReadOnly = true;
                supplierRow.Cells[ColumnOrder.Index].Value = true;
                supplierRow.Cells[ColumnNew.Index].Value = true;
                supplierRow.Cells[ColumnServiceable.Index].Value = true;
                supplierRow.Cells[ColumnOH.Index].Value = true;
                supplierRow.Cells[ColumnRepair.Index].Value = true;
                supplierRow.Tag = grouping.Key;

                foreach (RequestForQuotationRecord record in grouping)
                {
                    dataGridViewItems.Rows.Add(1);
                    DataGridViewRow r = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];
                    r.Cells[ColumnProduct.Index].Value = record.Product.ToString();
                    r.Cells[ColumnQuantity.Index].Value = record.Quantity;
                    r.Cells[ColumnOrder.Index].Value = true;
                    r.Cells[ColumnNew.Index].Value = true;
                    r.Cells[ColumnServiceable.Index].Value = true;
                    r.Cells[ColumnOH.Index].Value = true;
                    r.Cells[ColumnRepair.Index].Value = true;
                    r.Tag = record;          
                }
            }

            //comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            checkBoxOrder.CheckedChanged += CheckBoxOrderCheckedChanged;
            checkBoxNew.CheckedChanged += CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged += CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged += CheckBoxRepairCheckedChanged;
        }
        #endregion

        #region private void UpdateInformation(IEnumerable<InitialOrderRecord> initialOrderRecords)
        ///<summary>
        ///</summary>
        private void UpdateInformation(IEnumerable<InitialOrderRecord> initialOrderRecords)
        {
            dataGridViewItems.Rows.Clear();

            _resultRecords.Clear();
            _iorqorRelations.Clear();

            //DataGridViewComboBoxColumn comboBoxColumn = ColumnPriority;
            //IDictionaryCollection dc;
            //try
            //{
            //    dc = GlobalObjects.CasEnvironment.Dictionaries[typeof(DeferredCategory)];
            //}
            //catch (Exception)
            //{
            //    dc = null;
            //}
            //if (dc != null)
            //{
            //    List<KeyValuePair<string, IDictionaryItem>> list;
            //    if (_parent is Aircraft)
            //    {
            //        list = dc.OfType<DeferredCategory>()
            //            .Where(d => d.AircraftModel != null && d.AircraftModel.Equals(((Aircraft)_parent).Model))
            //            .Select(di => new KeyValuePair<string, IDictionaryItem>(di.ToString(), di))
            //            .ToList();   
            //    }
            //    else
            //    {
            //        //list = dc.OfType<IDictionaryItem>()
            //        //    .Select(di => new KeyValuePair<string, IDictionaryItem>(di.ToString(), di))
            //        //    .ToList(); 
            //        list = new List<KeyValuePair<string, IDictionaryItem>>();
            //    }
            //    comboBoxColumn.DisplayMember = "Key";
            //    comboBoxColumn.ValueMember = "Value";
            //    comboBoxColumn.DataSource = list;

            //    comboBoxPriority.DisplayMember = "Key";
            //    comboBoxPriority.ValueMember = "Value";
            //    comboBoxPriority.DataSource = list;
            //}

            if (initialOrderRecords == null)
                return;

            checkBoxOrder.CheckedChanged -= CheckBoxOrderCheckedChanged;
            checkBoxNew.CheckedChanged -= CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged -= CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged -= CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged -= CheckBoxRepairCheckedChanged;

            IEnumerable<IGrouping<Supplier, RequestForQuotationRecord>> quotationRecords;

            if (_toSupplier != null)
            {
                IEnumerable<InitialOrderRecord> supplierInitials =
                    initialOrderRecords.Where(i => i.Product.Suppliers.ContainsById(_toSupplier.ItemId));

                List<RequestForQuotationRecord> requests = new List<RequestForQuotationRecord>();
                foreach (InitialOrderRecord initial in supplierInitials)
                {
                    RequestForQuotationRecord record = requests
                        .FirstOrDefault(r => r.PackageItemId == initial.Product.ItemId &&
                                             r.PackageItemType == initial.Product.SmartCoreObjectType);

                    if (record != null)
                        record.Quantity += initial.Quantity;
                    else
                    {
                        record = new RequestForQuotationRecord(initial.Product, initial.Quantity, _toSupplier);
                        requests.Add(record);
                    } 
   
                    _iorqorRelations.Add(new IORQORRelation(initial, record));
                }

                quotationRecords = requests.GroupBy(ior => ior.ToSupplier);
            }
            else
            {
                List<RequestForQuotationRecord> requests = new List<RequestForQuotationRecord>();
                foreach (InitialOrderRecord initial in initialOrderRecords)
                {
                    foreach (Supplier supplier in initial.Product.Suppliers)
                    {
                        RequestForQuotationRecord record = requests
                            .FirstOrDefault(r => r.PackageItemId == initial.Product.ItemId &&
                                                 r.PackageItemType == initial.Product.SmartCoreObjectType &&
                                                 r.ToSupplier.Equals(supplier));

                        if (record != null)
                            record.Quantity += initial.Quantity;
                        else
                        {
                            record = new RequestForQuotationRecord(initial.Product, initial.Quantity, supplier);
                            requests.Add(record);
                        }

                        _iorqorRelations.Add(new IORQORRelation(initial, record));    
                    }
                }

                quotationRecords = requests.GroupBy(ior => ior.ToSupplier);
            }

            foreach (IGrouping<Supplier, RequestForQuotationRecord> grouping in quotationRecords)
            {
                dataGridViewItems.Rows.Add(1);
                DataGridViewRow supplierRow = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];
                supplierRow.Cells[ColumnProduct.Index].Value = grouping.Key != null ? grouping.Key.ToString() : "No Supplier";
                supplierRow.Cells[ColumnQuantity.Index].Value = 0;
                supplierRow.Cells[ColumnQuantity.Index].ReadOnly = true;
                supplierRow.Cells[ColumnOrder.Index].Value = true;
                supplierRow.Cells[ColumnNew.Index].Value = true;
                supplierRow.Cells[ColumnServiceable.Index].Value = true;
                supplierRow.Cells[ColumnOH.Index].Value = true;
                supplierRow.Cells[ColumnRepair.Index].Value = true;
                supplierRow.Tag = grouping.Key;

                foreach (RequestForQuotationRecord record in grouping)
                {
                    dataGridViewItems.Rows.Add(1);
                    DataGridViewRow r = dataGridViewItems.Rows[dataGridViewItems.Rows.Count - 1];
                    r.Cells[ColumnProduct.Index].Value = record.Product.ToString();
                    r.Cells[ColumnQuantity.Index].Value = record.Quantity;
                    r.Cells[ColumnOrder.Index].Value = true;
                    r.Cells[ColumnNew.Index].Value = true;
                    r.Cells[ColumnServiceable.Index].Value = true;
                    r.Cells[ColumnOH.Index].Value = true;
                    r.Cells[ColumnRepair.Index].Value = true;
                    r.Tag = record;
                }
            }

            //comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            checkBoxOrder.CheckedChanged += CheckBoxOrderCheckedChanged;
            checkBoxNew.CheckedChanged += CheckBoxNewCheckedChanged;
            checkBoxOverhaul.CheckedChanged += CheckBoxOverhaulCheckedChanged;
            checkBoxServiceable.CheckedChanged += CheckBoxServiceableCheckedChanged;
            checkBoxRepair.CheckedChanged += CheckBoxRepairCheckedChanged;
        }
        #endregion

        #region private bool ValidateData()

        private bool ValidateData()
        {
            bool haveOrder = false;

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>().Where(r => r.ReadOnly == false))
            {
                if (Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value) == 0.0)
                {
                    MessageBox.Show("Not set Quantity",
                                     new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);

                    row.Cells[ColumnQuantity.Index].Style.BackColor = Color.Red;

                    return false;
                }

                haveOrder = haveOrder | Convert.ToBoolean(row.Cells[ColumnOrder.Index].Value);
            }

            if (!haveOrder)
            {
                MessageBox.Show("Not set Items for Order",
                                 new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                return false;
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
            foreach (DataGridViewRow row in dataGridViewItems.Rows
                        .OfType<DataGridViewRow>()
                        .Where(r => r.ReadOnly == false && 
                                    r.Tag is RequestForQuotationRecord && 
                                    Convert.ToBoolean(r.Cells[ColumnOrder.Index].Value)))
            {
                RequestForQuotationRecord record = (RequestForQuotationRecord)row.Tag;
                double quantity = Convert.ToDouble(row.Cells[ColumnQuantity.Index].Value);
                bool @new = Convert.ToBoolean(row.Cells[ColumnNew.Index].Value);
                bool serv = Convert.ToBoolean(row.Cells[ColumnServiceable.Index].Value);
                bool overhaul = Convert.ToBoolean(row.Cells[ColumnOH.Index].Value);
                bool repair = Convert.ToBoolean(row.Cells[ColumnRepair.Index].Value);

                record.Quantity = quantity;

                if (@new)
                    record.CostCondition = record.CostCondition | ComponentStatus.New;
                if (serv)
                    record.CostCondition = record.CostCondition | ComponentStatus.Serviceable;
                if (overhaul)
                    record.CostCondition = record.CostCondition | ComponentStatus.Overhaul;
                if (repair)
                    record.CostCondition = record.CostCondition | ComponentStatus.Repair;

                _resultRecords.Add(record);
            }
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

        #region private void CheckBoxOrderCheckedChanged(object sender, EventArgs e)
        private void CheckBoxOrderCheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region private void ComboBoxPrioritySelectedIndexChanged(object sender, EventArgs e)
        //private void ComboBoxPrioritySelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DeferredCategory priority = comboBoxPriority.SelectedItem as DeferredCategory;

        //    if (priority == null)
        //        return;

        //    dataGridViewItems.CellValueChanged -= DataGridViewItemsCellValueChanged;

        //    foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>())
        //    {
        //        row.Cells[ColumnPriority.Index].Value = priority;
        //    }

        //    dataGridViewItems.CellValueChanged += DataGridViewItemsCellValueChanged;
        //}
        #endregion

        #region private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)

        private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            #region //Проверка колонки "Приоритет"
            //if (e.ColumnIndex == ColumnPriority.Index)
            //{
            //    comboBoxPriority.SelectedIndexChanged -= ComboBoxPrioritySelectedIndexChanged;

            //    DeferredCategory selectedValue = dataGridViewItems[ColumnPriority.Index, e.RowIndex].Value as DeferredCategory;
            //    DataGridViewRow row = dataGridViewItems.Rows
            //        .OfType<DataGridViewRow>()
            //        .FirstOrDefault(r => r.Cells[ColumnPriority.Index].Value is DeferredCategory &&
            //                             (DeferredCategory)r.Cells[ColumnPriority.Index].Value != selectedValue);
            //    DeferredCategory anotherValue = row != null
            //        ? row.Cells[ColumnPriority.Index].Value as DeferredCategory
            //        : null;
            //    DataGridViewRow rowWithNullValue = dataGridViewItems.Rows
            //        .OfType<DataGridViewRow>()
            //        .FirstOrDefault(r => r.Cells[ColumnPriority.Index].Value as DeferredCategory == null);

            //    if (selectedValue != null && anotherValue != null ||
            //        selectedValue == null && anotherValue != null ||
            //        selectedValue != null && rowWithNullValue != null)
            //        comboBoxPriority.SelectedItem = null;
            //    else comboBoxPriority.SelectedItem = selectedValue;

            //    comboBoxPriority.SelectedIndexChanged += ComboBoxPrioritySelectedIndexChanged;
            //}
            #endregion

            #region //Проверка колонки "Кол-во"
            if (e.ColumnIndex == ColumnQuantity.Index)
            {
                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                decimal value = Convert.ToDecimal(cell.Value);

                cell.Style.BackColor = value > 0 ? Color.White : Color.Red;
            }
            #endregion

            #region //Проверка колонки "Заказ"
            if (e.ColumnIndex == ColumnOrder.Index)
            {
                checkBoxOrder.CheckedChanged -= CheckBoxNewCheckedChanged;

                IEnumerable<DataGridViewRow> rows = dataGridViewItems.Rows
                    .OfType<DataGridViewRow>()
                    .ToArray();

                Supplier supplier = dataGridViewItems.Rows[e.RowIndex].Tag as Supplier;
                if (supplier != null)
                {
                    IEnumerable<DataGridViewRow> supplierQuotationRows =
                        rows.Where(r => r.Tag is RequestForQuotationRecord && 
                                        supplier.Equals(((RequestForQuotationRecord) r.Tag).ToSupplier));

                    bool readOnly = !Convert.ToBoolean(dataGridViewItems[e.ColumnIndex, e.RowIndex]);
                    foreach (DataGridViewRow row in supplierQuotationRows)
                        row.ReadOnly = readOnly;
                }

                bool checkedValue = rows.FirstOrDefault(r => (bool)r.Cells[ColumnOrder.Index].Value) != null;
                bool unCheckedValue = rows.FirstOrDefault(r => !(bool)r.Cells[ColumnOrder.Index].Value) != null;
                if (checkedValue && unCheckedValue)
                    checkBoxOrder.CheckState = CheckState.Indeterminate;
                else if (checkedValue)
                    checkBoxOrder.CheckState = CheckState.Checked;
                else checkBoxOrder.CheckState = CheckState.Unchecked;

                checkBoxOrder.CheckedChanged += CheckBoxNewCheckedChanged;
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

            if (po.X == ColumnOrder.Index || 
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
