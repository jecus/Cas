using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
    ///<summary>
    /// Форма, позволяющая делать выбор между компонентами и их расходниками для включения
    /// <br/> в запросный/закупочный акт
    ///</summary>
    public partial class SelectAccessoryForm : Form
    {
        #region Fields
        
        private CommonCollection<Component> _details = new CommonCollection<Component>();
        private CommonCollection<ComponentDirective> _detailDirectives = new CommonCollection<ComponentDirective>();

        #endregion

        #region Properties

        ///<summary>
        /// Возвращает список выбранных комплектующих
        ///</summary>
        public IEnumerable<KeyValuePair<Product, double>> Accessories
        {
            get
            {
                List<KeyValuePair<Product, double>> accessories = new List<KeyValuePair<Product, double>>();
                foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>()
                                                                      .Where(r=>r.Tag is Component && r.ReadOnly == false))
                {
                    if(row.Cells.Count < 3 
                        || !(row.Cells[1] is DataGridViewCheckBoxCell)
                        || !(row.Cells[2] is DataGridViewCheckBoxCell)) 
                        continue;

                    Component d = (Component)row.Tag;

                    DataGridViewCheckBoxCell componentCell = (DataGridViewCheckBoxCell)row.Cells[1];
                    DataGridViewCheckBoxCell kitCell = (DataGridViewCheckBoxCell)row.Cells[2];

                    if ((bool) componentCell.Value)
                    {
                        accessories.Add(new KeyValuePair<Product, double>(d.Product, 1));
                    }
                    if ((bool) kitCell.Value)
                    {
                        accessories.AddRange(d.Kits.Select(k=> new KeyValuePair<Product, double>(k.Product, k.Quantity)));
                    }
                }
                foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>().Where(r => r.Tag is ComponentDirective))
                {
                    if (row.Cells.Count < 3
                        || !(row.Cells[1] is DataGridViewCheckBoxCell)
                        || !(row.Cells[2] is DataGridViewCheckBoxCell))
                        continue;

                    ComponentDirective d = (ComponentDirective)row.Tag;

                    DataGridViewCheckBoxCell componentCell = (DataGridViewCheckBoxCell)row.Cells[1];
                    DataGridViewCheckBoxCell kitCell = (DataGridViewCheckBoxCell)row.Cells[2];

                    if ((bool)componentCell.Value && accessories.All(a => a.Key.ItemId != d.ParentComponent.Product.ItemId))
                        accessories.Add(new KeyValuePair<Product, double>(d.ParentComponent.Product, 1));
                    if ((bool)kitCell.Value)
                        accessories.AddRange(d.Kits.Select(k => new KeyValuePair<Product, double>( k.Product, k.Quantity)));
                }
                return accessories;
            }
        }

        #endregion

        #region Constructors

        ///<summary>
        ///</summary>
        private SelectAccessoryForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public SelectAccessoryForm(IEnumerable<Component> details, IEnumerable<ComponentDirective>detailDirectives) : this()
        {
            if(_details == null)
                _details = new CommonCollection<Component>();
            _details.AddRange(details);

            if (_detailDirectives == null)
                _detailDirectives = new CommonCollection<ComponentDirective>();
            _detailDirectives.AddRange(detailDirectives);

            UpdateInformation();
        }

        #endregion

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            dataGridViewItems.Rows.Clear();

            if(_details == null)return;

            foreach (Component detail in _details)
            {
                DataGridViewRow row = new DataGridViewRow {Tag = detail};
                DataGridViewCell discCell = new DataGridViewTextBoxCell {Value = detail.ToString()};
                DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = true };
                DataGridViewCell kitCell = new DataGridViewCheckBoxCell { Value = detail.Kits.Count > 0 };
                
                row.Cells.AddRange(new[]{discCell,compntCell,kitCell});
                
                dataGridViewItems.Rows.Add(row);
            }

            foreach (ComponentDirective detailDirective in _detailDirectives)
            {
                DataGridViewRow row = new DataGridViewRow { Tag = detailDirective };
                DataGridViewCell discCell = new DataGridViewTextBoxCell { Value = detailDirective.ToString() };
                DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = true };
                DataGridViewCell kitCell = new DataGridViewCheckBoxCell { Value = detailDirective.Kits.Count > 0 };

                row.Cells.AddRange(new[] { discCell, compntCell, kitCell });

                dataGridViewItems.Rows.Add(row);
            }
        }
        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            message = "";

            #region Проверка продуктов для деталей

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>()
                .Where(r => r.Tag is Component && r.ReadOnly == false))
            {
                if (row.Cells.Count < 3
                    || !(row.Cells[1] is DataGridViewCheckBoxCell)
                    || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;

                Component d = (Component) row.Tag;

                DataGridViewCheckBoxCell componentCell = (DataGridViewCheckBoxCell) row.Cells[1];
                DataGridViewCheckBoxCell kitCell = (DataGridViewCheckBoxCell) row.Cells[2];

                if ((bool) componentCell.Value)
                {
                    if (d.Product == null && !GlobalObjects.KitsCore.SetStandartAndProduct(d, ""))
                    {
                        string m =
                            string.Format(
                                "For Component P/N:{0} can not determinate Product. \nDeterminate product Manualy?",
                                d.PartNumber);
                        DialogResult res =
                            MessageBox.Show(m, (string) new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (res == DialogResult.Yes)
                        {
                            ComponentModel dm = new ComponentModel
                            {
                                BatchNumber = d.BatchNumber,
                                CostNew = d.CostNew,
                                CostOverhaul = d.CostOverhaul,
                                CostServiceable = d.CostServiceable,
                                Description = d.Description,
                                GoodsClass = d.GoodsClass,
                                ManufactureReg = d.ManufactureRegion,
                                Manufacturer = d.Manufacturer,
                                Measure = d.Measure,
                                PartNumber = d.PartNumber,
                                Remarks = d.Remarks,
                                SerialNumber = d.SerialNumber,
                                SupplierRelations = d.SupplierRelations
                            };
                            //Создание формы для формирования нового продукта
                            CommonEditorForm accessoryDescriptionForm =
                                new CommonEditorForm(dm);

                            if (accessoryDescriptionForm.ShowDialog(Owner) == DialogResult.OK)
                            {
                                d.Model = accessoryDescriptionForm.CurrentObject as ComponentModel;

                                if (d.Model == null)
                                {
                                    message += string.Format("For Component P/N:{0} can not determinate Product.",
                                        d.PartNumber);
                                    message += "\nAbort operation";
                                    return false;
                                }
                                GlobalObjects.CasEnvironment.Manipulator.Save(d);
                            }
                            else
                            {
                                message += string.Format("For Component P/N:{0} can not determinate Product.", d.PartNumber);
                                message += "\nAbort operation";
                                return false;
                            }
                        }
                        else
                        {
                            message += string.Format("For Component P/N:{0} can not determinate Product.", d.PartNumber);
                            message += "\nAbort operation";
                            return false;
                        }
                    }
                }
                if ((bool) kitCell.Value)
                {
                    foreach (AccessoryRequired kit in d.Kits)
                    {
                        if (kit.Product == null && !GlobalObjects.KitsCore.SetStandartAndProduct(kit, ""))
                        {
                            string m =
                                string.Format("For KIT P/N:{0} can not determinate Product. \nDeterminate product Manualy?",
                                    kit.PartNumber);
                            DialogResult res =
                                MessageBox.Show(m, (string) new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (res == DialogResult.Yes)
                            {
                                //Создание формы для формирования нового продукта
                                Product p = new Product
                                {
                                    BatchNumber = kit.BatchNumber,
                                    CostNew = kit.CostNew,
                                    CostOverhaul = kit.CostOverhaul,
                                    CostServiceable = kit.CostServiceable,
                                    Description = kit.Description,
                                    GoodsClass = kit.GoodsClass,
                                    Manufacturer = kit.Manufacturer,
                                    Measure = kit.Measure,
                                    PartNumber = kit.PartNumber,
                                    Remarks = kit.Remarks,
                                    SerialNumber = kit.SerialNumber,
                                    SupplierRelations = kit.SupplierRelations
                                };
                                //Создание формы для формирования нового продукта
                                ProductForm accessoryDescriptionForm =
                                    new ProductForm(p);

                                if (accessoryDescriptionForm.ShowDialog(Owner) == DialogResult.OK)
                                {
                                    kit.Product = accessoryDescriptionForm.CurrentObject as Product;

                                    if (kit.Product == null)
                                    {
                                        message += string.Format("For KIT P/N:{0} can not determinate Product.",
                                            kit.PartNumber);
                                        message += "\nAbort operation";
                                        return false;
                                    }

                                    GlobalObjects.CasEnvironment.Manipulator.Save(kit);
                                }
                                else
                                {
                                    message += string.Format("For KIT P/N:{0} can not determinate Product.", kit.PartNumber);
                                    message += "\nAbort operation";
                                    return false;
                                }
                            }
                            else
                            {
                                message += string.Format("For KIT P/N:{0} can not determinate Product.", kit.PartNumber);
                                message += "\nAbort operation";
                                return false;
                            }
                        }
                    }
                }
            }
            #endregion

            #region Проверка продуктов для задач по компонентам

            foreach (DataGridViewRow row in dataGridViewItems.Rows.OfType<DataGridViewRow>().Where(r => r.Tag is ComponentDirective))
            {
                if (row.Cells.Count < 3
                    || !(row.Cells[1] is DataGridViewCheckBoxCell)
                    || !(row.Cells[2] is DataGridViewCheckBoxCell))
                    continue;

                ComponentDirective dd = (ComponentDirective)row.Tag;

                DataGridViewCheckBoxCell componentCell = (DataGridViewCheckBoxCell)row.Cells[1];
                DataGridViewCheckBoxCell kitCell = (DataGridViewCheckBoxCell)row.Cells[2];

                if ((bool) componentCell.Value)
                {
                    if (dd.ParentComponent.Product == null && !GlobalObjects.KitsCore.SetStandartAndProduct(dd.ParentComponent, ""))
                    {
                        string m =
                            string.Format("For Component P/N:{0} Can determinate Product. \nDeterminate product Manualy?",
                            dd.ParentComponent.PartNumber);
                        DialogResult res =
                            MessageBox.Show(m, (string)new GlobalTermsProvider()["SystemName"],
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (res == DialogResult.Yes)
                        {
                            //Создание формы для формирования нового продукта
                            ComponentModel dm = new ComponentModel
                            {
                                BatchNumber = dd.ParentComponent.BatchNumber,
                                CostNew = dd.ParentComponent.CostNew,
                                CostOverhaul = dd.ParentComponent.CostOverhaul,
                                CostServiceable = dd.ParentComponent.CostServiceable,
                                Description = dd.ParentComponent.Description,
                                GoodsClass = dd.ParentComponent.GoodsClass,
                                ManufactureReg = dd.ParentComponent.ManufactureRegion,
                                Manufacturer = dd.ParentComponent.Manufacturer,
                                Measure = dd.ParentComponent.Measure,
                                PartNumber = dd.ParentComponent.PartNumber,
                                Remarks = dd.ParentComponent.Remarks,
                                SerialNumber = dd.ParentComponent.SerialNumber,
                                SupplierRelations = dd.ParentComponent.SupplierRelations
                            };
                            //Создание формы для формирования нового продукта
                            CommonEditorForm accessoryDescriptionForm =
                                new CommonEditorForm(dm);

                            if (accessoryDescriptionForm.ShowDialog(Owner) == DialogResult.OK)
                            {
                                dd.ParentComponent.Model = accessoryDescriptionForm.CurrentObject as ComponentModel;

                                if (dd.ParentComponent.Model == null)
                                {
                                    message += string.Format("For Component P/N:{0} Can determinate Product.", dd.ParentComponent.PartNumber);
                                    return false;
                                }
                                GlobalObjects.CasEnvironment.Manipulator.Save(dd.ParentComponent);
                            }
                            else
                            {
                                message += string.Format("For Component P/N:{0} Can determinate Product.", dd.ParentComponent.PartNumber);
                                return false;
                            }
                        }
                        else
                        {
                            message += string.Format("For Component P/N:{0} Can determinate Product.", dd.ParentComponent.PartNumber);
                            return false;
                        }
                    }
                }
                if ((bool)kitCell.Value)
                {
                    foreach (AccessoryRequired kit in dd.Kits)
                    {
                        if (kit.Product == null && !GlobalObjects.KitsCore.SetStandartAndProduct(kit, ""))
                        {
                            string m =
                                string.Format("For KIT P/N:{0} Can determinate Product. \nDeterminate product Manualy?",
                                kit.PartNumber);
                            DialogResult res =
                                MessageBox.Show(m, (string)new GlobalTermsProvider()["SystemName"],
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (res == DialogResult.Yes)
                            {
                                //Создание формы для формирования нового продукта
                                Product p = new Product
                                {
                                    BatchNumber = kit.BatchNumber,
                                    CostNew = kit.CostNew,
                                    CostOverhaul = kit.CostOverhaul,
                                    CostServiceable = kit.CostServiceable,
                                    Description = kit.Description,
                                    GoodsClass = kit.GoodsClass,
                                    Manufacturer = kit.Manufacturer,
                                    Measure = kit.Measure,
                                    PartNumber = kit.PartNumber,
                                    Remarks = kit.Remarks,
                                    SerialNumber = kit.SerialNumber,
                                    SupplierRelations = kit.SupplierRelations
                                };
                                //Создание формы для формирования нового продукта
                                ProductForm accessoryDescriptionForm =
                                    new ProductForm(p);

                                if (accessoryDescriptionForm.ShowDialog(Owner) == DialogResult.OK)
                                {
                                    kit.Product = accessoryDescriptionForm.CurrentObject as Product;

                                    if (kit.Product == null)
                                    {
                                        message += string.Format("For KIT P/N:{0} Can determinate Product.", kit.PartNumber);
                                        return false;
                                    }
                                    GlobalObjects.CasEnvironment.Manipulator.Save(kit);
                                }
                                else
                                {
                                    message += string.Format("For KIT P/N:{0} Can determinate Product.", kit.PartNumber);
                                    return false;
                                }
                            }
                            else
                            {
                                message += string.Format("For KIT P/N:{0} Can determinate Product.", kit.PartNumber);
                                return false;
                            }
                        }
                    }
                }
            }
            #endregion

            return true;
        }

        #endregion

        #region private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        private void DataGridViewItemsDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Program.Provider.Logger.Log("Error in Work Package Closing Form Data Grid", e.Exception);
        }
        #endregion

        #region private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)

        private void DataGridViewItemsCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            Point po = ((DataGridView)sender).CurrentCellAddress;

            if (po.X == 1)
                dataGridViewItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion

        #region private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)

        private void DataGridViewItemsCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            #region //Проверка колонки "Выполнено"
            if (e.ColumnIndex == 1)
            {
                DataGridViewCell cell = dataGridViewItems[e.ColumnIndex, e.RowIndex];
                DataGridViewRow currentRow = dataGridViewItems.Rows[e.RowIndex];
                if(!(currentRow.Tag is ComponentDirective))
                    return;

                ComponentDirective dd = (ComponentDirective) currentRow.Tag;
                Component d = dd.ParentComponent;
                DataGridViewRow row =
                    dataGridViewItems.Rows.OfType<DataGridViewRow>().FirstOrDefault(r => r.Tag is Component && ((Component)r.Tag).ItemId == d.ItemId);
                if (row != null)
                {
                    row.ReadOnly = !(bool)cell.Value;
                    if (!(bool) cell.Value)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            #endregion
        }
        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)
        private void ButtonOkClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #endregion
    }
}
