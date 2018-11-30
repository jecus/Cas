using System;
using System.Drawing;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Quality;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
    ///<summary>
    /// ЭУ для редектирования данных по запускам силовыз установок
    ///</summary>
    public partial class ProcedureDocRefControl : EditObjectControl
    {
        #region private CommonCollection<Document> _documents = new CommonCollection<Document>();

        private CommonCollection<Document> _documents = new CommonCollection<Document>();
        #endregion

        #region public ProcedureDocumentRelation ProcedureDocumentReference

        /// <summary>
        /// Запись с которой связан контрол
        /// </summary>
        public ProcedureDocumentReference ProcedureDocumentReference
        {
            get { return AttachedObject as ProcedureDocumentReference; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public Document Document

        /// <summary>
        /// 
        /// </summary>
        public Document Document
        {
            get { return comboBoxDocument.SelectedItem != null ? comboBoxDocument.SelectedItem as Document : null; }
        }

        #endregion

        /*
         * Конструктор
         */

        #region public ProcedureDocRefControl()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        private ProcedureDocRefControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public ProcedureDocRefControl(ProcedureDocumentRelation runup) : this()
        /// <summary>
        /// Контрол редактирует данные о залитом масле для одного агрегата
        /// </summary>
        public ProcedureDocRefControl(ProcedureDocumentReference runup)
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
            if (ProcedureDocumentReference != null)
            {
                if (comboBoxDocument.SelectedItem is Document)
                {
                    ProcedureDocumentReference.Document = ((Document)comboBoxDocument.SelectedItem);
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

            _documents.Clear();
            _documents.AddRange(GlobalObjects.DocumentCore.
                GetDocuments(ProcedureDocumentReference.Procedure.ParentOperator, DocumentType.Other, true));
            
            comboBoxDocument.Items.Clear();
            comboBoxDocument.Items.AddRange(_documents.ToArray());

            if (ProcedureDocumentReference != null)
            {
                if (ProcedureDocumentReference.ItemId > 0)
                {
                    comboBoxDocument.SelectedItem =
                        _documents.GetItemById(ProcedureDocumentReference.Document != null
                        ? ProcedureDocumentReference.Document.ItemId
                        : -1);
                }
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
            return comboBoxDocument.SelectedItem != null;
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
            get { return labelDocumentRef.Visible; }
            set
            {
                labelDocumentRef.Visible = value;
                labelDocFile.Visible = value;
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
            if (comboBoxDocument.SelectedItem as Document != null)
            {
                Document doc = comboBoxDocument.SelectedItem as Document;
                if (doc.AttachedFile != null)
                {
                    attachedFileControl.AttachedFile = doc.AttachedFile;
                    attachedFileControl.ShowLinkLabelRemove = false;
                    attachedFileControl.ShowLinkLabelBrowse = true;
                }
                else
                {
                    attachedFileControl.AttachedFile = null;
                    attachedFileControl.ShowLinkLabelRemove = false;
                    attachedFileControl.ShowLinkLabelBrowse = false;    
                }
                if(doc.IsDeleted)
                    comboBoxDocument.BackColor = Color.FromArgb(Highlight.Red.Color);
                else comboBoxDocument.BackColor = Color.White;
            }
            else comboBoxDocument.BackColor = Color.White;
        }

        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}
