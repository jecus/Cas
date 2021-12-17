using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class SupplierBindProductsForm : MetroForm
    {

        #region Fields

        private CommonCollection<Product> _tasksForSelect = new CommonCollection<Product>();
        private CommonCollection<KitSuppliersRelation> _bindedTasks = new CommonCollection<KitSuppliersRelation>(); 
        private readonly Supplier _supplier;

        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Constructors

        #region private SupplierBindProductsForm()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        private SupplierBindProductsForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public SupplierBindProductsForm(Supplier supplier) : this()

        /// <summary>
        /// Создает форму для привязки задач к выполнению чека программы обслуживания
        /// </summary>
        public SupplierBindProductsForm(Supplier supplier)
            : this()
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier", "must be not null");
            _supplier = supplier;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listViewTasksForSelect.SetItemsArray(_tasksForSelect.ToArray());
            listViewBindedTasks.SetItemsArray(_bindedTasks.ToArray());
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_supplier == null)
            {
                e.Cancel = true;
                return;
            }

            if (_tasksForSelect == null)
                _tasksForSelect = new CommonCollection<Product>();
            _tasksForSelect.Clear();

            if (_bindedTasks == null)
                _bindedTasks = new CommonCollection<KitSuppliersRelation>();
            _bindedTasks.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");
            try
            {
                _tasksForSelect.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<AccessoryDescriptionDTO, Product>(new Filter("ModelingObjectTypeId", -1),true));

                List<Product> supplierProducts = GlobalObjects.PurchaseCore.GetProducts(_supplier);
                foreach (Product supplierProduct in supplierProducts)
                {
                    _tasksForSelect.RemoveById(supplierProduct.ItemId);
                    _bindedTasks.Add(supplierProduct.SupplierRelations.FirstOrDefault(ksr => ksr.SupplierId == _supplier.ItemId));
                }
            }
            catch (Exception ex)
            {
                string s = $"Error while load Products For selection for supplier {_supplier} id: {_supplier.ItemId}";
                Program.Provider.Logger.Log(s, ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            return listViewBindedTasks.GetChangeStatus();
        }

        #endregion

        #region private bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        private bool ValidateData(out string message)
        {
            if (!listViewBindedTasks.ValidateData(out message))
                return false;
            return true;
        }

        #endregion

        #region private void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        private void ApplyChanges()
        {
            listViewBindedTasks.ApplyChanges();
        }
        #endregion

        #region private void AbortChanges()
        private void AbortChanges()
        {
        }
        #endregion

        #region private void Save()
        private void Save()
        {
            foreach (BaseEntityObject selectedItem in listViewBindedTasks.SelectedItems)
            {
                KitSuppliersRelation ksr = selectedItem as KitSuppliersRelation;

                if (ksr == null)
                    continue;

                try
                {
                    GlobalObjects.CasEnvironment.Manipulator.Save(ksr);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while delete bind task record", ex);
                }    
            }

        }
        #endregion

        #region private void ButtonCloseClick(object sender, EventArgs e)

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            if(listViewTasksForSelect.SelectedItems.Count == 0)
                return;

            foreach (BaseEntityObject selectedItem in listViewTasksForSelect.SelectedItems)
            {
                Product product = selectedItem as Product;
                if (product == null)
                    continue;
                
                product.Suppliers.Add(_supplier);
                KitSuppliersRelation record = new KitSuppliersRelation
                {
                    Supplier = _supplier,
                    KitId = product.ItemId,
                    ParentTypeId = product.SmartCoreObjectType.ItemId,
                };

                try
                {
                    GlobalObjects.NewKeeper.Save(record);

                    product.SupplierRelations.Add(record);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while save bind task record", ex);
                }
            }

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewBindedTasks.SelectedItems.Count == 0)
                return;

            foreach (BaseEntityObject selectedItem in listViewBindedTasks.SelectedItems)
            {
                KitSuppliersRelation ksr = selectedItem as KitSuppliersRelation;

                if (ksr == null)
                    continue;

                try
                {
                    GlobalObjects.NewKeeper.Delete(ksr);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while delete bind task record", ex);
                }
            }

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)
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
            if (GetChangeStatus())
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    AcceptButton.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (result == DialogResult.No)
                {
                    AbortChanges();
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                {
                    ApplyChanges();
                    Save();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        #region private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        {
            listViewTasksForSelect.ViewedType = typeof (Product);
            listViewBindedTasks.ViewedType = typeof (KitSuppliersRelation);
            listViewBindedTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonAdd.Enabled = listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #region private void ListViewSelectedSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        private void ListViewSelectedSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonDelete.Enabled = listViewBindedTasks.SelectedItems.Count > 0;
        }
        #endregion

        #endregion
    }

}