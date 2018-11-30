using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.KitControls
{
    ///<summary>
    ///</summary>
    public partial class KitForm : Form
    {
        #region  Fields

        private readonly IKitRequired _kitParentObject;
        private readonly AbstractAccessory _currentKit;

        private readonly List<KitFormItem> _kitControls = new List<KitFormItem>();
        #endregion

        #region Constructors

        #region public KitForm()
        ///<summary>
        ///</summary>
        public KitForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public KitForm(IKitRequired kitParent) :this()
        ///<summary>
        ///</summary>
        public KitForm(IKitRequired kitParent) :this()
        {
            _kitParentObject = kitParent;
            UpdateInformation();
        }
        #endregion

        #region public KitForm(AbstractAccessory kit) : this ()
        ///<summary>
        ///</summary>
        public KitForm(AbstractAccessory kit) : this ()
        {
            _currentKit = kit;
            UpdateControl();
        }
        #endregion

        #region public KitForm(AbstractAccessory kit) : this ()
        /////<summary>
        /////</summary>
        //public KitForm(RequestForQuotationRecord rfqr)
        //    : this()
        //{
        //    if(rfqr == null)
        //        throw new ArgumentNullException("rfqr", "must be not null");
        //    _rfqr = rfqr;
        //    _currentKit = rfqr.Product;
        //    UpdateControl();
        //}
        #endregion

        #endregion

        #region private void UpdateControl()

        private void UpdateControl()
        {
            flowLayoutPanelCharts.Controls.Remove(panelButtons);
                
            KitFormItem newKitControl = new KitFormItem(_currentKit) {ButtonDeleteVisible = false};
            _kitControls.Add(newKitControl);

            Size = new Size(655,300);
            flowLayoutPanelCharts.Controls.Add(newKitControl);
        }

        #endregion

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if(_kitParentObject == null)return;

            flowLayoutPanelCharts.Controls.Remove(panelButtons);

            //если у родителя нет ни одного КИТ-а, то ему добавляется в коллекцию КИТ-ов
            //пустой КИТ, ради того, что бы при появлении формы она не была пустой
            //если пользователь не изменит объект пустого КИТ-а, то данный КИТ при 
            //закрытии формы не сохранится и произоидет удаление всех пустых КИТ-ов из
            //коллекции КИТ-ов родителя
            if (_kitParentObject.Kits.Count == 0)
            {
                AccessoryRequired newKit = new AccessoryRequired(_kitParentObject);
                _kitParentObject.Kits.Add(newKit);
            }

            foreach (AccessoryRequired kit in _kitParentObject.Kits)
            {
                KitFormItem newKitControl = new KitFormItem(kit);
                _kitControls.Add(newKitControl);
                newKitControl.Deleted += KitDeleted;

                flowLayoutPanelCharts.Controls.Add(newKitControl);
                
            }
            flowLayoutPanelCharts.Controls.Add(panelButtons);
        }
        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            bool changed = false;
            foreach (KitFormItem kitControl in _kitControls)
            {
                if (kitControl.GetChangeStatus())
                {
                    changed = true;
                }
                else if (kitControl.Kit.ItemId <= 0)//объект новый и небыл сохранен
                    _kitParentObject.Kits.Remove((AccessoryRequired)kitControl.Kit);
            }
            return changed;
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

            foreach (KitFormItem kitControl in _kitControls)
            {
                string m;
                if(!kitControl.ValidateData(out m))
                {
                    if (message != "") message += "\n ";
                    message += m;
                    return false;
                }
            }
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
            foreach (KitFormItem control in _kitControls)
            {
                control.ApplyChanges();
            }
        }
        #endregion

        #region private void SaveData()
        private void SaveData()
        {
            foreach (KitFormItem item in _kitControls)
            {
                try
                {
                    GlobalObjects.CasEnvironment.Keeper.Save(item.Kit);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                }
            }
        }
        #endregion

        #region private void AbortChanges()
        private void AbortChanges()
        {
            try
            {
                foreach (KitFormItem item in _kitControls)
                {
                    if (item.Kit.ItemId <= 0)
                    {
                        _kitParentObject.Kits.Remove((AccessoryRequired)item.Kit);

                        //foreach (KitSuppliersRelation relation in item.Kit.SupplierRelations)
                        //{
                        //    GlobalObjects.CasEnvironment.Manipulator.Delete(relation, false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save consumable part", ex);
            }
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)
        private void ButtonAddClick(object sender, EventArgs e)
        {
            AccessoryRequired newKit = new AccessoryRequired(_kitParentObject);
            _kitParentObject.Kits.Add(newKit);

            KitFormItem newKitControl = new KitFormItem(newKit);
            _kitControls.Add(newKitControl);
            newKitControl.Deleted += KitDeleted;
            flowLayoutPanelCharts.Controls.Remove(panelButtons);
            flowLayoutPanelCharts.Controls.Add(newKitControl);
            flowLayoutPanelCharts.Controls.Add(panelButtons);

        }
        #endregion

        #region private void KitDeleted(object sender, EventArgs e)
        private void KitDeleted(object sender, EventArgs e)
        {
            KitFormItem control = (KitFormItem)sender;

            AbstractAccessory kit = control.Kit;
            GlobalObjects.CasEnvironment.Manipulator.Delete(kit);
            _kitParentObject.Kits.Remove((AccessoryRequired)control.Kit);
            _kitControls.Remove(control);
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
                    SaveData();
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

        #region private void ButtonCancelClick(object sender, EventArgs e)
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            if (GetChangeStatus())
            {
                DialogResult result = MessageBox.Show("Do you want to save changes?",
                                                      (string)new GlobalTermsProvider()["SystemName"],
                                                      MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                                      MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.None;
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
                    string message;
                    if (!ValidateData(out message))
                    {
                        message += "\nAbort operation";
                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ApplyChanges();
                    SaveData();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        #endregion

        #region private void KitFormFormClosed(object sender, FormClosedEventArgs e)
        private void KitFormFormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
