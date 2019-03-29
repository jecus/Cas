using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.Filter;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;


namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///Форма отображает категории отложенных дефектов данного самолета
    ///</summary>
    public partial class DeferredCategoriesForm : Form
    {
        #region Fields

        private Aircraft _currentAircraft;
        private List<DeferredCategory> _defferedCategories;
        
        #endregion

        #region Constructors

        #region public DefferedCategoriesForm()
        ///<summary>
        ///Конструктор создающий пустую форму
        ///</summary>
        public DeferredCategoriesForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DefferedCategoriesForm(Aircraft currentAircraft)
        ///<summary>
        ///Конструктор заполняющий всю необходимую информацию о переданном объекте
        ///</summary>
        public DeferredCategoriesForm(Aircraft currentAircraft)
        {
            InitializeComponent();

            _currentAircraft = currentAircraft;

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties
        #endregion

        #region Methods

        #region private GetChar(DefferedCategory defferedCategory)
        ///<summary>
        /// Возаращает первую букву в названии категории
        ///</summary>
        ///<param name="defferedCategory"></param>
        ///<returns></returns>
        private char GetChar(DeferredCategory defferedCategory)
        {
            return char.ToUpper(defferedCategory.FullName.ToCharArray()[0]);
        }
        #endregion

        #region private void UpdateInformation()
        ///<summary>
        ///обновление информации в контроле
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentAircraft == null) return;

            _defferedCategories = new List<DeferredCategory>(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DefferedCategorieDTO, DeferredCategory>
		        (new Filter("AircraftModelId", _currentAircraft.Model.ItemId),true));

            listViewDefferedCategories.Items.Clear();
            List<DeferredCategory> records = new List<DeferredCategory>();

            //LINQ запрос для сортировки записей по дате
            records.AddRange(_defferedCategories.ToArray());
            List<DeferredCategory> sortrecords = (from record in records
                                         orderby GetChar(record) ascending
                                         select record).ToList();

            foreach (DeferredCategory t in sortrecords)
            {
                string[] subs = new[]
                                    {
                                        t.FullName,
                                        t.AircraftModel.ToString(),
                                        t.Threshold.FirstPerformanceSinceEffectiveDate +
                                        (!t.Threshold.RepeatInterval.IsNullOrZero() 
                                             ?  " rpt. "+ t.Threshold.RepeatInterval
                                             : ""),
                                    };

                ListViewItem newItem = new ListViewItem(subs) {Tag = t};
                listViewDefferedCategories.Items.Add(newItem);
            }
        }
        
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            DeferredCategoryAddingForm form = new DeferredCategoryAddingForm(_currentAircraft);
            form.ShowDialog();

            if(form.DialogResult != DialogResult.OK)return;

            if(form.DefferedCategory != null) _defferedCategories.Add(form.DefferedCategory);
            UpdateInformation();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewDefferedCategories.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listViewDefferedCategories.SelectedItems.Count; i++)
                {
                    DeferredCategory item = (DeferredCategory)listViewDefferedCategories.SelectedItems[i].Tag;
                    GlobalObjects.CasEnvironment.Manipulator.Delete(item);
                }

                UpdateInformation();
            }
        }
        #endregion

        #region private void ListViewDefferedCategoriesMouseDoubleClick(object sender, MouseEventArgs e)

        private void ListViewDefferedCategoriesMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listViewDefferedCategories.SelectedItems.Count > 0)
            {
                DeferredCategoryAddingForm form = new DeferredCategoryAddingForm(_currentAircraft,
                    (DeferredCategory)listViewDefferedCategories.SelectedItems[0].Tag);
                form.ShowDialog();

                if(form.DialogResult == DialogResult.OK) UpdateInformation();
            }
        }
        #endregion

        #region private void ListViewDefferedCategoriesMouseClick(object sender, MouseEventArgs e)

        private void ListViewDefferedCategoriesMouseClick(object sender, MouseEventArgs e)
        {
            ButtonDelete.Enabled = listViewDefferedCategories.SelectedItems.Count > 0;
        }

        #endregion

        #endregion

        #region Events
        #endregion
    }
}
