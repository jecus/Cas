using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий отображение фильтра по ATA Chapter
    ///</summary>
    public partial class ATAChapterFilterControl : UserControl, IFilterControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ATAChapterFilterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создается элемент отображения фильтра по типу технического обслуживания
        /// </summary>
        /// <param name="ataChaptersCollection">Отображаемые главы</param>
        public ATAChapterFilterControl(ATAChapterCollection ataChaptersCollection):this()
        {
            SetAtaChapters(ataChaptersCollection);
        }

        private void SetAtaChapters(ATAChapterCollection ataChaptersCollection)
        {
            for (int i = 0; i < ataChaptersCollection.Count; i++)
            {
                checkedListBoxATAChapter.Items.Add(ataChaptersCollection[i].FullName, true);
            }
        }

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public IFilter GetFilter()
        {
            SelectByFilter(textBoxSelection.Text);
            bool[] typesAppliance = new bool[checkedListBoxATAChapter.Items.Count];
            for (int i = 0; i < typesAppliance.Length; i++)
            {
                typesAppliance[i] = checkedListBoxATAChapter.CheckedIndices.Contains(i);
            }
            return new ATAChapterFilter(typesAppliance);
        }

        public void SetFilterParameters(IFilter filter)
        {
            
        }

        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get
            {
                SelectByFilter(textBoxSelection.Text);
                return checkedListBoxATAChapter.SelectedIndices.Count != checkedListBoxATAChapter.Items.Count;
            }
            set 
            {
                
            }
        }

        private void SetAllValuesBy(bool value)
        {
            for (int i = 0; i < checkedListBoxATAChapter.Items.Count; i++)
            {
                checkedListBoxATAChapter.SetItemChecked(i, value);
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectByFilter(textBoxSelection.Text);
            checkedListBoxATAChapter.Visible = true;
        }

        private void SelectByFilter(string text)
        {
            SetAllValuesBy(false);
            string[] selections = text.Split(',');
            for (int i = 0; i < selections.Length; i++)
            {
                string s = selections[i];
                for (int j = 0; j < checkedListBoxATAChapter.Items.Count; j++)
                {
                    if (checkedListBoxATAChapter.Items[j].ToString().Contains(s.Trim()))
                        checkedListBoxATAChapter.SetItemChecked(j, true);
                }
            }
        }

        private void checkedListBoxATAChapter_MouseLeave(object sender, EventArgs e)
        {
            //checkedListBoxATAChapter.Visible = false;
        }

        private void ATAChapterFilterControl_Load(object sender, EventArgs e)
        {
            buttonSelect.BackColor = Css.CommonAppearance.Colors.BackColor;
            buttonSelect.ForeColor = Css.SimpleLink.Colors.LinkColor;
            buttonSelect.Font = new Font(Css.SimpleLink.Fonts.Font, FontStyle.Underline);

            checkedListBoxATAChapter.BackColor = Css.CommonAppearance.Colors.BackColor;
            Css.OrdinaryText.Adjust(checkedListBoxATAChapter);
        }

        private void checkedListBoxATAChapter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}