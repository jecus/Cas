using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    ///Форма отображает список листов повреждений 
    ///</summary>
    public partial class DamageChartsForm : MetroForm
    {
        #region Fields

        private Aircraft _currentAircraft;
        private IList<DamageChart> _damageCharts;
        
        #endregion

        #region Constructors

        #region public DamageChartsForm()
        ///<summary>
        ///Конструктор создающий пустую форму
        ///</summary>
        public DamageChartsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public DamageChartsForm(Aircraft currentAircraft)
        ///<summary>
        ///Конструктор заполняющий всю необходимую информацию о переданном объекте
        ///</summary>
        public DamageChartsForm(Aircraft currentAircraft)
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

        #region private GetName(DamageChart damageChart)
        ///<summary>
        /// Возвращает название документа о повреждении
        ///</summary>
        ///<param name="damageChart"></param>
        ///<returns></returns>
        private String GetName(DamageChart damageChart)
        {
            return damageChart.ChartName;
        }
        #endregion

        #region private void UpdateInformation()
        ///<summary>
        ///обновление информации в контроле
        ///</summary>
        private void UpdateInformation()
        {
            if (_currentAircraft == null) return;

            _damageCharts =
                GlobalObjects.CasEnvironment.GetDamageChartsByAircraftModel(_currentAircraft.Model);

            listViewDamageCharts.Items.Clear();
            List<DamageChart> records = new List<DamageChart>();

            //LINQ запрос для сортировки записей по дате
            records.AddRange(_damageCharts.ToArray());
            List<DamageChart> sortrecords = (from record in records
                                         orderby GetName(record) ascending
                                         select record).ToList();

            foreach (DamageChart t in sortrecords)
            {
                string[] subs = new []
                                    {
                                        t.ChartName,
                                        t.AircraftModel.ToString(),
                                        t.AttachedFile != null ?
                                        t.AttachedFile.FileName : "",
                                    };

                ListViewItem newItem = new ListViewItem(subs) {Tag = t};
                listViewDamageCharts.Items.Add(newItem);
            }
        }
        
        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            DamageChartsAddingForm form = new DamageChartsAddingForm(_currentAircraft);
            form.ShowDialog();

            if(form.DialogResult != DialogResult.OK)return;

            if (form.DamageChart != null) _damageCharts.Add(form.DamageChart);
            UpdateInformation();
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewDamageCharts.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listViewDamageCharts.SelectedItems.Count; i++)
                {
                    DamageChart item = (DamageChart)listViewDamageCharts.SelectedItems[i].Tag;
                    GlobalObjects.CasEnvironment.Manipulator.Delete(item);
                }

                UpdateInformation();
            }
        }
        #endregion

        #region private void ListViewDefferedCategoriesMouseDoubleClick(object sender, MouseEventArgs e)

        private void ListViewDefferedCategoriesMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listViewDamageCharts.SelectedItems.Count > 0)
            {
                DamageChartsAddingForm form = new DamageChartsAddingForm(_currentAircraft,
                    (DamageChart)listViewDamageCharts.SelectedItems[0].Tag);
                form.ShowDialog();

                if(form.DialogResult == DialogResult.OK) UpdateInformation();
            }
        }
        #endregion

        #region private void ListViewDefferedCategoriesMouseClick(object sender, MouseEventArgs e)

        private void ListViewDefferedCategoriesMouseClick(object sender, MouseEventArgs e)
        {
            ButtonDelete.Enabled = listViewDamageCharts.SelectedItems.Count > 0;
        }

        #endregion

        #endregion

        #region Events
        #endregion
    }
}
