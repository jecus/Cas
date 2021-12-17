using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.PersonnelControls;
using CASTerms;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.QualityAssuranceControls
{

    /// <summary>
    /// Контрол позволяет внести информацию по экипажу полета
    /// </summary>
    public partial class ProcedureDocRefListControl : Interfaces.EditObjectControl
    {

        #region public Procedure Procedure
        /// <summary>
        /// Сотрудник, с которым связан контрол
        /// </summary>
        public Procedure Procedure
        {
            get { return AttachedObject as Procedure; }
            set { AttachedObject = value; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public ProcedureDocRefListControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ProcedureDocRefListControl()
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
            if (Procedure != null)
            {
                Procedure.DocumentReferences.Clear();
                List<ProcedureDocRefControl> fcs = flowLayoutPanelMain.Controls.OfType<ProcedureDocRefControl>().ToList();

                foreach (ProcedureDocRefControl fc in fcs)
                {
                    fc.ApplyChanges();
                    Procedure.DocumentReferences.Add(fc.ProcedureDocumentReference);
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

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            // В этом контроле только текстовые данные
            List<CategoryRecordControl> fcs = flowLayoutPanelMain.Controls.OfType<CategoryRecordControl>().ToList();

            //if(fcs.Count == 0)
            //{
            //    MessageBox.Show(flowLayoutPanelMain, "Not assigned crew", "Error");
            //    return false;    
            //}

            foreach (CategoryRecordControl fc in fcs.Where(fc => !fc.CheckData()))
            {
                MessageBox.Show(fc, "Not specified Category", "Error");
                return false;
            }

            foreach (CategoryRecordControl fc in fcs)
            {
                if(fcs.Count(f => f.AircraftWorkerCategory.ItemId == fc.AircraftWorkerCategory.ItemId && f.AircraftModel == fc.AircraftModel) > 1)
                {
                    MessageBox.Show(fc, "Can't have one Category more that once", "Error");
                    return false;
                }
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

            if (Procedure != null && Procedure.DocumentReferences != null)
            {
                for (int i = 0; i < Procedure.DocumentReferences.Count; i++)
                {
                    // Добавляем контрол для ввода данных по маслу
                    ProcedureDocRefControl c = new ProcedureDocRefControl(Procedure.DocumentReferences[i]);
                    c.Deleted += ConditionControlDeleted;
                    if (i > 0) c.ShowHeaders = false;
                    flowLayoutPanelMain.Controls.Add(c);
                }  
            }

            flowLayoutPanelMain.Controls.Add(panelAdd);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcedureDocRefControl performance =
                new ProcedureDocRefControl(new ProcedureDocumentReference { Procedure = Procedure });
            performance.Deleted += ConditionControlDeleted;
            if (flowLayoutPanelMain.Controls.Count > 1) performance.ShowHeaders = false;
            flowLayoutPanelMain.Controls.Remove(panelAdd);
            flowLayoutPanelMain.Controls.Add(performance);
            flowLayoutPanelMain.Controls.Add(panelAdd);
            performance.Focus();
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
            ProcedureDocRefControl control = (ProcedureDocRefControl)sender;
            ProcedureDocumentReference cond = control.ProcedureDocumentReference;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Category record?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.NewKeeper.Delete(cond);
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
    }
}

