using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Форма для редактирования добавления и удаления подтипов документов
    ///</summary>
    public partial class ReasonAddingForm : Form
    {
        #region Fields

        private String _reasonCategory;
       
        #endregion

        #region Constructors

        #region public ReasonAddingForm()
        ///<summary>
        /// Создает объект без дополнительной информации
        ///</summary>
        public ReasonAddingForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public ReasonAddingForm(Reason reasonCategory) : this()
        ///<summary>
        ///</summary>
        public ReasonAddingForm(String reasonCategory)
            : this()
        {
            _reasonCategory = reasonCategory;
            UpdateInformation();
        }
        #endregion

        #endregion

        #region Methods

        #region public void UpdateInformation()

        public void UpdateInformation()
        {
            listView.Items.Clear();

            List<Reason> list = 
                new List<Reason>(GlobalObjects.CasEnvironment.Reasons.GetItemsByCategory(_reasonCategory));
            foreach (Reason item in list)
            {
                ListViewItem listViewItem = new ListViewItem(item.ToString()) { Tag = item };
                listView.Items.Add(listViewItem);
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

            //Проверка на то, не существует ли причина с данным именем в словаре
            Reason exist =
                GlobalObjects.CasEnvironment.Reasons.Where(d => d.FullName == textBoxName.Text.Trim()). FirstOrDefault();
            if(exist != null)
            {
                MessageBox.Show("Item with this name is already exist.",
                                new GlobalTermsProvider()["SystemName"].ToString());
                return;
            }

            Reason newSubType = new Reason{FullName = textBoxName.Text.Trim(), Category = _reasonCategory};
            ListViewItem listViewItem = new ListViewItem(newSubType.ToString()) { Tag = newSubType };
            listView.Items.Add(listViewItem);

            textBoxName.Text = "";

            GlobalObjects.AircraftFlightsCore.AddReason(newSubType);
        }
        #endregion

        #region private void ListViewCheckTypeAfterLabelEdit(object sender, LabelEditEventArgs e)
        private void ListViewCheckTypeAfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if(e.Label == null)return;
            string name = e.Label.Trim();
           
            Reason exist =
                GlobalObjects.CasEnvironment.Reasons.Where(d => d.FullName == name).FirstOrDefault();
            //Проверка на то, не существует ли такой причины в словаре
            if (name == "" || exist != null)
            {
                e.CancelEdit = true;
                return;
            }
            Reason docSubType = ((Reason)listView.Items[e.Item].Tag);
            docSubType.FullName = e.Label.Trim();
            GlobalObjects.CasEnvironment.NewKeeper.Save(docSubType);
        }
        #endregion

        #endregion
    }
}
