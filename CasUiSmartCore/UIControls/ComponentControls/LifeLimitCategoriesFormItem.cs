using System;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class LifeLimitCategoriesFormItem : UserControl
    {
        #region Fields
        private LLPLifeLimitCategory _currentCategory;
        #endregion

        #region Properties

        #endregion

        #region Constructors
        
        #region public LifeLimitCategoriesFormItem()
        ///<summary>
        ///</summary>
        public LifeLimitCategoriesFormItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public LifeLimitCategoriesFormItem(LLPLifeLimitCategory category)
        ///<summary>
        /// Конструктор, принимающий KIT для отображения
        ///</summary>
        public LifeLimitCategoriesFormItem(LLPLifeLimitCategory category)
        {
            _currentCategory = category;
            InitializeComponent();
            UpdateInformation();
        }
        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            if (_currentCategory == null) return;
            dictionaryComboBoxAircraftModel.Type = typeof(AircraftModel);
            dictionaryComboBoxAircraftModel.SelectedItem = _currentCategory.AircraftModel;
            textBoxCategoryType.Text = _currentCategory.CategoryType.FullName;
            textBoxCategoryName.Text = _currentCategory.Category;
        }
        #endregion

        #region public bool ValidateData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool ValidateData()
        {
            if (string.IsNullOrEmpty(textBoxCategoryName.Text))
                return false;

            return true;
        }
        #endregion

        #region  public bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            if (textBoxCategoryName.Text != _currentCategory.Category
               || dictionaryComboBoxAircraftModel.SelectedItem != _currentCategory.AircraftModel)
                return true;

            return false;
        }
        #endregion

        #region public void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public void ApplyChanges()
        {
            _currentCategory.Category = textBoxCategoryName.Text;
            _currentCategory.AircraftModel = (AircraftModel)dictionaryComboBoxAircraftModel.SelectedItem;
        }
        #endregion

        #region public void SaveData()

        ///<summary>
        ///</summary>
        ///<returns></returns>
        public void SaveData()
        {
            try
            {
                GlobalObjects.CasEnvironment.Manipulator.Save(_currentCategory);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return;
            }
            return;
        }
        #endregion
        
        #endregion
    }
}
