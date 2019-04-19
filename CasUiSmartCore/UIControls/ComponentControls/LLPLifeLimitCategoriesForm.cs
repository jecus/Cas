using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.DetailsControls;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// Форма для редактирования категорий жизненного цикла вращающихся деталей двигателей
    ///</summary>
    public partial class LLPLifeLimitCategoriesForm : MetroForm
    {
        #region Fields

        private readonly Aircraft _currentAircraft;
        private readonly List<LifeLimitCategoriesFormItem> _llItems = new List<LifeLimitCategoriesFormItem>();
        
        #endregion
       
        #region Constructors

        #region public LLPLifeLimitCategoriesForm()
        ///<summary>
        ///</summary>
        public LLPLifeLimitCategoriesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public LLPLifeLimitCategoriesForm(Aircraft currentAircraft)
        ///<summary>
        ///Конструктор заполняющий всю необходимую информацию о переданном объекте
        ///</summary>
        public LLPLifeLimitCategoriesForm(Aircraft currentAircraft)
        {
            InitializeComponent();

            _currentAircraft = currentAircraft;

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties
        #endregion

        #region Methods

        #region char GetChar(LLPLifeLimitCategory lifelimitCategory)
        ///<summary>
        /// возвращает первую букву из типа категории
        ///</summary>
        ///<param name="lifelimitCategory"></param>
        ///<returns></returns>
        public char GetChar(LLPLifeLimitCategory lifelimitCategory)
        {
            return lifelimitCategory.GetChar();
        }
        #endregion

        #region private void UpdateInformation()
        ///<summary>
        ///обновление информации в контроле
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentAircraft == null) return;

            var list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                            .OfType<LLPLifeLimitCategory>()
                            .Where(llp => llp.AircraftModel?.ItemId == _currentAircraft.Model?.ItemId)
                            .ToList();

            if(list.Count == 0)
            {
                var a = new LLPLifeLimitCategory(LLPLifeLimitCategoryType.A, "", _currentAircraft.Model);
                var b = new LLPLifeLimitCategory(LLPLifeLimitCategoryType.B, "", _currentAircraft.Model);
                var c = new LLPLifeLimitCategory(LLPLifeLimitCategoryType.C, "", _currentAircraft.Model);
                var d = new LLPLifeLimitCategory(LLPLifeLimitCategoryType.D, "", _currentAircraft.Model);
                list = new List<LLPLifeLimitCategory>(new[]{a,b,c,d});   
            }
            //LINQ запрос для сортировки записей по дате;
            var sortrecords = (from record in list
                                                      orderby GetChar(record) ascending
                                                      select record).ToList();

            foreach (var llc in sortrecords)
            {
                var newKitControl = new LifeLimitCategoriesFormItem(llc);
                _llItems.Add(newKitControl);
                flowLayoutPanelCharts.Controls.Add(newKitControl);    
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
            foreach (LifeLimitCategoriesFormItem item in _llItems)
            {
                if (item.ValidateData()) continue;
                
                if (message != "") message += "\n ";
                message += "Not set Category Name";
                return false;
            } 
            return true;
        }

        #endregion

        #region private bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        private bool GetChangeStatus()
        {
            return _llItems.Any(item => item.GetChangeStatus());
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
            foreach (LifeLimitCategoriesFormItem item in _llItems)
            {
                item.ApplyChanges();
            }
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
            foreach (LifeLimitCategoriesFormItem item in _llItems)
            {
                item.SaveData();
            }
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
            DialogResult = DialogResult.OK;
        }
        #endregion
        
        #endregion
    }
}
