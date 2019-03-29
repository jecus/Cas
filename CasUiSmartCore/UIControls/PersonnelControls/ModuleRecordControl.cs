using System;
using System.Drawing;
using CAS.UI.Interfaces;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class ModuleRecordControl : EditObjectControl
    {
        #region public ModuleRecord ModuleRecord

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public ModuleRecord ModuleRecord
        {
            get { return AttachedObject as ModuleRecord; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public KnowledgeModule Module

        /// <summary>
        /// 
        /// </summary>
        public KnowledgeModule Module
        {
            get { return dictionaryComboBoxModule.SelectedItem != null ? dictionaryComboBoxModule.SelectedItem as KnowledgeModule : null; }
        }

        #endregion

        /*
         * Конструктор
         */

        #region public ModuleRecordControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private ModuleRecordControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public ModuleRecordControl(ModuleRecord runup) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public ModuleRecordControl(ModuleRecord runup)
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
            if (ModuleRecord != null)
            {
                if (dictionaryComboBoxModule.SelectedItem is KnowledgeModule)
                {
                    ModuleRecord.KnowledgeModule = ((KnowledgeModule)dictionaryComboBoxModule.SelectedItem);
                }
                ModuleRecord.KnowledgeLevel = (int)numericUpDownLevel.Value;
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

            Program.MainDispatcher.ProcessControl(dictionaryComboBoxModule);
            
            dictionaryComboBoxModule.Type = typeof(KnowledgeModule);

            if (ModuleRecord != null)
            {
                if (ModuleRecord.ItemId > 0)
                {
                    dictionaryComboBoxModule.SelectedItem = ModuleRecord.KnowledgeModule;
                    numericUpDownLevel.Value = ModuleRecord.KnowledgeLevel;
                }

                if (dictionaryComboBoxModule.SelectedItem != null && dictionaryComboBoxModule.SelectedItem.IsDeleted)
                    dictionaryComboBoxModule.BackColor = Color.FromArgb(Highlight.Red.Color);
                else dictionaryComboBoxModule.BackColor = Color.White;
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
            return dictionaryComboBoxModule.SelectedItem != null;
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
            get { return labelModule.Visible; }
            set
            {
                labelModule.Visible = value;
                labelLevel.Visible = value;
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
        private void dictionaryComboBoxModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dictionaryComboBoxModule.SelectedItem != null && dictionaryComboBoxModule.SelectedItem.IsDeleted)
                dictionaryComboBoxModule.BackColor = Color.FromArgb(Highlight.Red.Color);
            else dictionaryComboBoxModule.BackColor = Color.White;
        }

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}
