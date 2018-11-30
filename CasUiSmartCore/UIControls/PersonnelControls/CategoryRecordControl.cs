using System;
using System.Drawing;
using CAS.UI.Interfaces;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class CategoryRecordControl : EditObjectControl
    {
        #region public CategoryRecord CategoryRecord

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public CategoryRecord CategoryRecord
        {
            get { return AttachedObject as CategoryRecord; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public AircraftWorkerCategory AircraftWorkerCategory

        /// <summary>
        /// 
        /// </summary>
        public AircraftWorkerCategory AircraftWorkerCategory
        {
            get { return dictionaryComboBoxCategory.SelectedItem != null ? dictionaryComboBoxCategory.SelectedItem as AircraftWorkerCategory : null; }
        }

        #endregion

        #region public AircraftModel AircraftModel

        /// <summary>
        /// 
        /// </summary>
        public AircraftModel AircraftModel
        {
            get { return dictionaryComboBoxACType.SelectedItem != null ? dictionaryComboBoxACType.SelectedItem as AircraftModel : null; }
        }

        #endregion

        /*
         * Конструктор
         */

        #region public CategoryRecordControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private CategoryRecordControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public CategoryRecordControl(CategoryRecord runup) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public CategoryRecordControl(CategoryRecord runup)
            : this()
        {
            AttachedObject = runup;
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {
            if (CategoryRecord != null)
            {
                if (dictionaryComboBoxCategory.SelectedItem is AircraftWorkerCategory)
                {
                    CategoryRecord.AircraftWorkerCategory = ((AircraftWorkerCategory)dictionaryComboBoxCategory.SelectedItem);
                }
                if (dictionaryComboBoxACType.SelectedItem is AircraftModel)
                {
                    CategoryRecord.AircraftModel = ((AircraftModel)dictionaryComboBoxACType.SelectedItem);
                }
            }

            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {

            BeginUpdate();

            dictionaryComboBoxCategory.Type = typeof(AircraftWorkerCategory);
            dictionaryComboBoxACType.Type = typeof(AircraftModel);

            if (CategoryRecord != null)
            {
                if (CategoryRecord.ItemId > 0)
                {
                    dictionaryComboBoxCategory.SelectedItem = CategoryRecord.AircraftWorkerCategory;
                    dictionaryComboBoxACType.SelectedItem = CategoryRecord.AircraftModel;
                }

                if (dictionaryComboBoxCategory.SelectedItem != null && dictionaryComboBoxCategory.SelectedItem.IsDeleted)
                    dictionaryComboBoxCategory.BackColor = Color.FromArgb(Highlight.Red.Color);
                else dictionaryComboBoxCategory.BackColor = Color.White;

                if (dictionaryComboBoxACType.SelectedItem != null && dictionaryComboBoxACType.SelectedItem.IsDeleted)
                    dictionaryComboBoxACType.BackColor = Color.FromArgb(Highlight.Red.Color);
                else dictionaryComboBoxACType.BackColor = Color.White;
            }
            EndUpdate();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            return dictionaryComboBoxCategory.SelectedItem != null && dictionaryComboBoxACType.SelectedItem != null;
        }
        #endregion

        /*
         * Реализация
         */

        #region public bool ShowHeaders { get; set; }

        /// <summary>
        /// Отображать ли заголовки
        /// </summary>
        public bool ShowHeaders
        {
            get { return labelCategory.Visible; }
            set
            {
                labelCategory.Visible = value;
                labelAircraftType.Visible = value;
            }
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ComboSpecialistSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboBoxModuleSelectedIndexChanged(object sender, EventArgs e)
        {
            if (dictionaryComboBoxCategory.SelectedItem != null && dictionaryComboBoxCategory.SelectedItem.IsDeleted)
                dictionaryComboBoxCategory.BackColor = Color.FromArgb(Highlight.Red.Color);
            else dictionaryComboBoxCategory.BackColor = Color.White;
        }

        #endregion

        #region private void DictionaryComboBoxAcTypeSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboBoxAcTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (dictionaryComboBoxACType.SelectedItem != null && dictionaryComboBoxACType.SelectedItem.IsDeleted)
                dictionaryComboBoxACType.BackColor = Color.FromArgb(Highlight.Red.Color);
            else dictionaryComboBoxACType.BackColor = Color.White;
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}
