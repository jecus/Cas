using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using EFCore.DTO.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.KitControls
{
    ///<summary>
    /// Форма для отображения и редактирования списка поставщиков комплектующего
    ///</summary>
    public partial class AccessorySupplierForm : Form
    {
        #region  Fields
        private readonly ISupplied _parentKit;

        private readonly List<KitSupplierFormItem> _kitSuppliersControls = new List<KitSupplierFormItem>();
        #endregion

        #region Constructors
        
        #region public KitSupplierForm()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public AccessorySupplierForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public KitSupplierForm(ISupplied parentKit) : this()
        ///<summary>
        ///</summary>
        public AccessorySupplierForm(ISupplied parentKit)
            : this()
        {
            _parentKit = parentKit;
            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if (_parentKit == null) return;

            flowLayoutPanelCharts.Controls.Remove(panelButtons);
            for (int i = 0; i < _parentKit.SupplierRelations.Count; i ++)
            {
                KitSupplierFormItem newKitSupplierControl = new KitSupplierFormItem(_parentKit.SupplierRelations[i]);
                if (i > 0)
                    newKitSupplierControl.Extended = false;
                
                _kitSuppliersControls.Add(newKitSupplierControl);
                newKitSupplierControl.Deleted += KitSupplierDeleted;

                flowLayoutPanelCharts.Controls.Add(newKitSupplierControl);
            }
            flowLayoutPanelCharts.Controls.Add(panelButtons);
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

            foreach (KitSupplierFormItem kitControl in _kitSuppliersControls)
            {
                string m;
                if (!kitControl.ValidateData(out m))
                {
                    if (message != "") message += "\n ";
                    message += m;
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            KitSuppliersRelation newksr = new KitSuppliersRelation(_parentKit);
            _parentKit.SupplierRelations.Add(newksr);

            KitSupplierFormItem newKitSupplierControl = new KitSupplierFormItem(newksr);
            _kitSuppliersControls.Add(newKitSupplierControl);
            newKitSupplierControl.Deleted += KitSupplierDeleted;
            flowLayoutPanelCharts.Controls.Remove(panelButtons);
            flowLayoutPanelCharts.Controls.Add(newKitSupplierControl);
            flowLayoutPanelCharts.Controls.Add(panelButtons);

        }
        #endregion

        #region private void KitDeleted(object sender, EventArgs e)
        private void KitSupplierDeleted(object sender, EventArgs e)
        {
            KitSupplierFormItem control = (KitSupplierFormItem)sender;
            control.Deleted -= KitSupplierDeleted;

            KitSuppliersRelation ksr = control.KitSuppliersRelation;
            //У связи поставщика с китами нет дочерних объектов для сохранения
            //поэтому он удаляется напрямую - через Keeper, а не Manipulator
            GlobalObjects.CasEnvironment.NewKeeper.Delete(ksr);
            
            _parentKit.SupplierRelations.Remove(ksr);
            _kitSuppliersControls.Remove(control);
            flowLayoutPanelCharts.Controls.Remove(control);
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

            foreach (KitSupplierFormItem item in _kitSuppliersControls)
            {
                //if (item.GetChangeStatus())
                //{
                //    item.SaveData();
                //}
                //else
                //{
                //    if (item.KitSuppliersRelation.ItemId <= 0)//объект новый и небыл сохранен
                //        _parentKit.SupplierRelations.Remove(item.KitSuppliersRelation);
                //}
                if (item.GetChangeStatus())
                {
                    item.ApplyChanges();
                }
                else
                {
                    if (item.KitSuppliersRelation.ItemId <= 0)//объект новый и небыл сохранен
                        _parentKit.SupplierRelations.Remove(item.KitSuppliersRelation);
                }
            }
           
            var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>();
            _parentKit.Suppliers.Clear();
            foreach (KitSuppliersRelation ksr in _parentKit.SupplierRelations)
                _parentKit.Suppliers.Add(suppliers.First(s => s.ItemId == ksr.SupplierId));
           
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void KitFormFormClosed(object sender, FormClosedEventArgs e)
        private void KitFormFormClosed(object sender, FormClosedEventArgs e)
        {
           var suppliers = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SupplierDTO, Supplier>();
            _parentKit.Suppliers.Clear();
            foreach (KitSuppliersRelation ksr in _parentKit.SupplierRelations)
                if (ksr.SupplierId > 0)
                {
                    _parentKit.Suppliers.Add(suppliers.First(s => s.ItemId == ksr.SupplierId));
                }

            DialogResult = DialogResult.OK;
        }
        #endregion

        #endregion
    }
}
