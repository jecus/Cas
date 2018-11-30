using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.PersonnelControls
{
    /// <summary>
    /// Форма для редактирование рабочих категории
    /// </summary>
    public partial class AircraftWorkerCategoryForm : CommonEditorForm
    {
        private AircraftWorkerCategory _currentItem;

        /// <summary>
        /// Простой конструктор по умолчанию
        /// </summary>
        public AircraftWorkerCategoryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор с переданный объектом для редактирования
        /// </summary>
        /// <param name="currentItem"></param>
        public AircraftWorkerCategoryForm(AircraftWorkerCategory currentItem) : this()
        {
            _currentItem = currentItem;
            UpdateInformation();
        }

        #region Properties

        ///<summary>
        /// Возвращает редактируемый объект
        ///</summary>
        public override BaseEntityObject CurrentObject
        {
            get { return _currentItem; }
        }
        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            textBoxName.Text = string.Empty;

            flowLayoutPanelMain.Controls.Clear();
            flowLayoutPanelMain.Controls.Add(panelAdd);

            if (_currentItem == null) 
                return;

            textBoxName.Text = _currentItem.Category;

            // Освобождаем старые контролы
            flowLayoutPanelMain.Controls.Clear();

            if (_currentItem != null && _currentItem.ModuleRecords != null)
            {
                for (int i = 0; i < _currentItem.ModuleRecords.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    ModuleRecordControl c = new ModuleRecordControl(_currentItem.ModuleRecords[i]);
                    c.Deleted += ConditionControlDeleted;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region protected override void SetFormControls()
        protected override void SetFormControls()
        {

        }
        #endregion

        #region protected override bool GetChangeStatus()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        protected override bool GetChangeStatus()
        {
            if (textBoxName.Text != _currentItem.Category)
                return true;

            // В этом контроле только текстовые данные
            List<ModuleRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<ModuleRecordControl>().ToList();

            //if(fcs.Count == 0)
            //{
            //    MessageBox.Show(flowLayoutPanelMain, "Not assigned crew", "Error");
            //    return false;    
            //}

            foreach (ModuleRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Module", "Error");
                return false;
            }

            foreach (ModuleRecordControl fc in fcs)
            {
                if (fcs.Where(f => f.Module.ItemId == fc.Module.ItemId).Count() > 1)
                {
                    MessageBox.Show(fc, "Can't have one Module more that once", "Error");
                    return false;
                }
            }

            return fcs.All(fc => fcs.Where(f => f.Module.ItemId == fc.Module.ItemId).Count() <= 1);
            //
        }
        #endregion

        #region protected override public ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        protected override bool ValidateData(out string message)
        {
            message = "";

            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                if (message != "") message += "\n ";
                message += "Not set Category Name";
                textBoxName.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region protected override bool ApplyChanges()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        protected override void ApplyChanges()
        {
            _currentItem.Category = textBoxName.Text;

            _currentItem.ModuleRecords.Clear();
            List<ModuleRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<ModuleRecordControl>().ToList();

            foreach (ModuleRecordControl fc in fcs)
            {
                fc.ApplyChanges();
                _currentItem.ModuleRecords.Add(fc.ModuleRecord);
            }
        }
        #endregion

        #region protected override void AbortChanges()
        protected override void AbortChanges()
        {
        }
        #endregion

        #region protected override void Save()
        protected override void Save()
        {
            try
            {
                GlobalObjects.CasEnvironment.Manipulator.Save(_currentItem);

                foreach (ModuleRecord relation in _currentItem.ModuleRecords)
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Save(relation);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }
        #endregion

        #region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModuleRecordControl performance =
                new ModuleRecordControl(new ModuleRecord { AircraftWorkerCategory = _currentItem });
            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelMain.Controls.Count > 1) 
                performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            ModuleRecordControl control = (ModuleRecordControl)sender;
            ModuleRecord cond = control.ModuleRecord;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete module record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
        }

        #endregion

        #endregion
    }
}
