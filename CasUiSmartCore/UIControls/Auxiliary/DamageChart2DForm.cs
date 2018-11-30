using System;
using System.Windows;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.Auxiliary
{
    public partial class DamageChart2DForm : Form
    {
        #region Fields

        private DamageItem _currentDirctive;
        private Aircraft _currentAircraft;

        #endregion

        #region public DamageChart2DForm()
        public DamageChart2DForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChart2DForm(DamageItem directive, Aircraft currentAircarft) : this()
        ///<summary>
        ///</summary>
        public DamageChart2DForm(DamageItem directive, Aircraft currentAircarft) : this()
        {
            _currentDirctive = directive;
            _currentAircraft = currentAircarft;

            UpdateInformation();
        }
        #endregion

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            DamageChart2DControl chart2DControl = elementHost.Child as DamageChart2DControl;
            
            if (chart2DControl == null)
            {
                chart2DControl = new DamageChart2DControl(_currentDirctive, _currentAircraft);
                elementHost.Child = chart2DControl;
            }
            else
            {
                chart2DControl.UpdateInformation(_currentDirctive, _currentAircraft);
            }
        }
        #endregion

        #region protected virtual bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetChangeStatus()
        {
            return damageChart2DControl.GetChangeStatus();
        }

        #endregion

        #region protected virtual bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidateData(out string message)
        {
            return damageChart2DControl.ValidateData(out message);
        }

        #endregion

        #region protected virtual void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        protected virtual void ApplyChanges()
        {
            damageChart2DControl.ApplyChanges();
        }
        #endregion

        #region protected virtual void AbortChanges()
        protected virtual void AbortChanges()
        {
            damageChart2DControl.AbortChanges();
        }
        #endregion

        #region protected virtual void Save()
        protected virtual void Save()
        {

            try
            {
                foreach (DamageDocument damageDocument in _currentDirctive.DamageDocs)
                {
                    GlobalObjects.DirectiveCore.AddDamageDocument(damageDocument);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save smsEventType", ex);
            }
        }
        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ButtonCreateAircraftClick(object sender, EventArgs e)

        private void ButtonCreateAircraftClick(object sender, EventArgs e)
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                System.Windows.Forms.MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GetChangeStatus())
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Do you want to save changes?",
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
    }
}
