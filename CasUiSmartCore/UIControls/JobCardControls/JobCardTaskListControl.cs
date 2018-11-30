using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General.Deprecated;

namespace CAS.UI.UIControls.JobCardControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по Задачам рабочей карты
    /// </summary>
    public partial class JobCardTaskListControl : Interfaces.EditObjectControl
    {

        #region public Specialist Employee
        /// <summary>
        /// Рабочая карта, с которой связан контрол
        /// </summary>
        public JobCard JobCard
        {
            get { return AttachedObject as JobCard; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public JobCardTaskListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public JobCardTaskListControl()
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
            if (JobCard != null)
            {
                JobCard.JobCardTasks.Clear();
                List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

                foreach (JobCardTaskControl fc in fcs)
                {
                    fc.ApplyChanges();
                    JobCard.JobCardTasks.Add(fc.JobCardTask);
                }
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
            IEnumerable<JobCardTaskControl> conds = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>();
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
            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();

            if (fcs.Count == 0)
            {
                MessageBox.Show(flowLayoutPanelMain, "Not assigned Job Card Task", "Error");
                return false;
            }

            foreach (JobCardTaskControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Job Card Task", "Error");
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

            if (JobCard != null && JobCard.JobCardTasks != null)
            {
                for (int i = 0; i < JobCard.JobCardTasks.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    JobCardTaskControl c = new JobCardTaskControl(JobCard.JobCardTasks[i]){Dock = DockStyle.Top};
                    c.Deleted += ConditionControlDeleted;
                    if (JobCard.JobCardTasks.Count <= 1)
                        c.EnableToDelete = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JobCardTaskControl performance =
                new JobCardTaskControl(new JobCardTask { JobCard = JobCard });
            performance.Deleted += ConditionControlDeleted;

            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();
            if (fcs.Count > 1)
            {
                foreach (JobCardTaskControl fc in fcs)
                {
                    fc.EnableToDelete = true;    
                }
            }

            performance.Dock = DockStyle.Top;

            flowLayoutPanelMain.Controls.Add(performance);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            JobCardTaskControl control = (JobCardTaskControl)sender;
            JobCardTask cond = control.JobCardTask;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Job Card Task?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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

            List<JobCardTaskControl> fcs = flowLayoutPanelMain.Controls.OfType<JobCardTaskControl>().ToList();
            if (fcs.Count == 1)
            {
                fcs[0].EnableToDelete = false;
            }
        }

        #endregion
    }
}

