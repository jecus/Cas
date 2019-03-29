using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Entities.General.Hangar;

namespace CAS.UI.UIControls.HangarControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по Задачам рабочей карты
    /// </summary>
    public partial class HangarMaintenanceListControl : Interfaces.EditObjectControl
    {

        #region public Hangar Hangar
        /// <summary>
        /// Ангар, с которой связан контрол
        /// </summary>
        public Hangar Hangar
        {
            get { return AttachedObject as Hangar; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public HangarMaintenanceListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public HangarMaintenanceListControl()
        {
            InitializeComponent();
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
            if (Hangar != null)
            {
                //Hangar.JobCardTasks.Clear();
                //List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

                //foreach (JobCardTaskControl fc in fcs)
                //{
                //    fc.ApplyChanges();
                //    Hangar.JobCardTasks.Add(fc.JobCardTask);
                //}
            }
            //
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
            BuildControls();
            EndUpdate();
        }
        #endregion

        #region public override bool GetChangeStatus()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool GetChangeStatus()
        {
            //Проверка на содержание объекта в коллекции
            IEnumerable<HangarMaintenanceControl> conds = flowLayoutPanelMain.Controls.OfType<HangarMaintenanceControl>();
            if (conds.Any(cond => cond.GetChangeStatus()))
            {
                return true;
            }
            return false;
            //
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
            // В этом контроле только текстовые данные
            List<HangarMaintenanceControl> fcs = flowLayoutPanelMain.Controls.OfType<HangarMaintenanceControl>().ToList();

            foreach (HangarMaintenanceControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not Valid Work Package", "Error");
                return false;
            }

            return true;
            //
        }
        #endregion

        /*
         * Реализация
         */

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            // Освобождаем старые контролы
            flowLayoutPanelMain.Controls.Clear();

            //if (Hangar != null && Hangar.JobCardTasks != null)
            //{
            //    for (int i = 0; i < Hangar.JobCardTasks.Count; i++)
            //    {
            //        // Добавляем контрол для ввода данных по маслу
            //        JobCardTaskControl c = new JobCardTaskControl(Hangar.JobCardTasks[i]){Dock = DockStyle.Top};
            //        c.Deleted += ConditionControlDeleted;
            //        if (Hangar.JobCardTasks.Count <= 1)
            //            c.EnableToDelete = false;
            //        flowLayoutPanelMain.Controls.Add(c);
            //    }  
            //}

            if (flowLayoutPanelMain.Controls.Count == 0)
            {
                HangarMaintenanceControl hmc = new HangarMaintenanceControl();
                flowLayoutPanelMain.Controls.Add(hmc);
                hmc.FillControls();
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HangarMaintenanceControl performance =
                new HangarMaintenanceControl();
            performance.Deleted += ConditionControlDeleted;

            performance.Dock = DockStyle.Top;

            flowLayoutPanelMain.Controls.Add(performance);
            performance.FillControls();

        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            HangarMaintenanceControl control = (HangarMaintenanceControl)sender;

            if (MessageBox.Show("Do you really want to delete Work Package from Hangar Maintenance?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                //try
                //{
                //    GlobalObjects.CasEnvironment.Keeper.Delete(cond);
                //}
                //catch (Exception ex)
                //{
                //    Program.Provider.Logger.Log("Error while removing data", ex);
                //}

                flowLayoutPanelMain.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            //else if (cond.ItemId <= 0)
            //{
            //    flowLayoutPanelMain.Controls.Remove(control);
            //    control.Deleted -= ConditionControlDeleted;
            //    control.Dispose();
            //}
        }

        #endregion
    }
}

