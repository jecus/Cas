using System;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Форма для редактирования добавления и удаления подтипов документов
    ///</summary>
    public partial class DocumentSubTypeForm : MetroForm
    {
        #region Fields

        private DocumentType _parentDocType;
       
        #endregion

        #region Constructors

        #region public DocumentSubTypeForm()
        ///<summary>
        /// Создает объект без дополнительной информации
        ///</summary>
        public DocumentSubTypeForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DocumentSubTypeForm(DocumentType parentDocType) : this()
        ///<summary>
        ///</summary>
        public DocumentSubTypeForm(DocumentType parentDocType) : this()
        {
            _parentDocType = parentDocType;
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            listViewDocTypes.Items.Clear();
            if(_parentDocType == null)return;

            Text = "Edit " + _parentDocType.FullName + " Types:";
            listViewDocTypes.Columns[0].Text = _parentDocType.FullName + " Types";

            var dst = (DocumentSubTypeCollection) GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
            var list = dst.GetSubTypesByDocType(_parentDocType);
            foreach (DocumentSubType item in list)
            {
                ListViewItem listViewItem = new ListViewItem(item.ToString()) { Tag = item };
                listViewDocTypes.Items.Add(listViewItem);
            }
        }
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            if (textBoxName.Text.Trim()=="")
            {
                return;
            }

            //Проверка на то, не существует ли такой подтип для данного типа документов в словаре
            //DocumentSubType exist =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().
            //    Where(d => d.DocumentTypeId == _parentDocType.ItemID && d.FullName == textBoxName.Text.Trim()).
            //        FirstOrDefault();
            var dst = (DocumentSubTypeCollection)GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
            var exist = dst.ToArray().FirstOrDefault(d => d.DocumentTypeId == _parentDocType.ItemId && 
                                                          d.FullName == textBoxName.Text.Trim());

            if(exist != null)
            {
                MessageBox.Show("Item with this name is already exist.",
                                new GlobalTermsProvider()["SystemName"].ToString());
                return;
            }

            DocumentSubType newSubType = new DocumentSubType
                                             {
                                                 DocumentTypeId = _parentDocType.ItemId, 
                                                 FullName = textBoxName.Text.Trim()
                                             };
            ListViewItem listViewItem = new ListViewItem(newSubType.ToString()) { Tag = newSubType };
            listViewDocTypes.Items.Add(listViewItem);

            textBoxName.Text = "";

            GlobalObjects.CasEnvironment.NewKeeper.Save(newSubType);
            dst.Add(newSubType);
        }
        #endregion

        #region private void ListViewDocTypesBeforeLabelEdit(object sender, LabelEditEventArgs e)
        private void ListViewDocTypesBeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            DocumentSubType docSubType = (DocumentSubType) listViewDocTypes.Items[e.Item].Tag;
            if (docSubType.FullName == "AW" || docSubType.FullName == "AOC")
            {
                e.CancelEdit = true;
                return;
            }
        }
        #endregion

        #region private void ListViewCheckTypeAfterLabelEdit(object sender, LabelEditEventArgs e)
        private void ListViewCheckTypeAfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if(e.Label == null)return;
            string name = e.Label.Trim();
           
            //DocumentSubType exist =
            //    GlobalObjects.CasEnvironment.DocSubTypes.ToArray().
            //    Where(d => d.DocumentTypeId == _parentDocType.ItemID && d.FullName == name).
            //        FirstOrDefault();

            var dst = (DocumentSubTypeCollection)GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>();
            var exist = dst.ToArray().FirstOrDefault(d => d.DocumentTypeId == _parentDocType.ItemId && d.FullName == name);
            //Проверка на то, не существует ли такой подтип для данного типа документов в словаре
            if (name == "" || exist != null)
            {
                e.CancelEdit = true;
                return;
            }
            DocumentSubType docSubType = ((DocumentSubType)listViewDocTypes.Items[e.Item].Tag);
            docSubType.FullName = e.Label.Trim();
            GlobalObjects.CasEnvironment.NewKeeper.Save(docSubType);
        }
        #endregion

        #endregion
    }
}
