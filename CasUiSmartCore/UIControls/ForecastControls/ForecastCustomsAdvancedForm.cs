using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.ForecastControls
{
    ///<summary>
    /// Расширенная форма для редактирования ресурсов прогноза
    ///</summary>
    public partial class ForecastCustomsAdvancedForm : MetroForm
    {
        private Forecast _currentForecast;
        private List<ForecastAdvancedControlItem> _forecastControlItems = new List<ForecastAdvancedControlItem>();

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public ForecastCustomsAdvancedForm()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        ///<param name="forecast">Прогноз для редактирования</param>
        public ForecastCustomsAdvancedForm(Forecast forecast) : this()
        {
            _currentForecast = forecast;
            UpdateInformation();
        }

        #region Methods

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            List<ForecastData> forecastDatas = _currentForecast.ForecastDatas;

            flowLayoutPanelMain.Controls.Clear();
            _forecastControlItems.Clear();

            List<IGrouping<int, ForecastData>> groupedForecast =
                forecastDatas.GroupBy(fd => fd.BaseComponent.BaseComponentType.ItemId).ToList();

            //Первыми необходимо выводить данные по планеру и двигателям
            IGrouping<int, ForecastData> frameGroup = 
                groupedForecast.Where(g => g.Key == BaseComponentType.Frame.ItemId).FirstOrDefault();
            IGrouping<int, ForecastData> engineGroup =
                groupedForecast.Where(g => g.Key == BaseComponentType.Engine.ItemId).FirstOrDefault();

            if(frameGroup != null)
            {
                //Создание отдельной панели для новой группы
                FlowLayoutPanel forecastGroupPanel = new FlowLayoutPanel
                {
                    AutoScroll = true,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    FlowDirection = FlowDirection.LeftToRight,
                    MaximumSize = new Size(460, 400),
                    MinimumSize = new Size(460, 220),
                };
                flowLayoutPanelMain.Controls.Add(forecastGroupPanel);
                foreach (ForecastData forecastData in frameGroup)
                {
                    //добавление нового ЭУ в новую панель группы
                    ForecastAdvancedControlItem item = new ForecastAdvancedControlItem(forecastData);
                    forecastGroupPanel.Controls.Add(item);
                    _forecastControlItems.Add(item);
                }

                groupedForecast.Remove(frameGroup);
            }

            if (engineGroup != null)
            {
                //Создание отдельной панели для новой группы
                FlowLayoutPanel forecastGroupPanel = new FlowLayoutPanel
                {
                    AutoScroll = true,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    FlowDirection = FlowDirection.LeftToRight,
                    MaximumSize = new Size(460, 500),
                    MinimumSize = new Size(460, 220),
                };
                flowLayoutPanelMain.Controls.Add(forecastGroupPanel);
                foreach (ForecastData forecastData in engineGroup)
                {
                    //добавление нового ЭУ в новую панель группы
                    ForecastAdvancedControlItem item = new ForecastAdvancedControlItem(forecastData);
                    forecastGroupPanel.Controls.Add(item);
                    _forecastControlItems.Add(item);
                }

                groupedForecast.Remove(engineGroup);
            }

            foreach (IGrouping<int, ForecastData> forecastGroup in groupedForecast)
            {
                //Создание отдельной панели для новой группы
                FlowLayoutPanel forecastGroupPanel = new FlowLayoutPanel
                {
                    AutoScroll = true,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    FlowDirection = FlowDirection.LeftToRight,
                    MaximumSize = new Size(460, 500),
                    MinimumSize = new Size(460, 220),
                };
                flowLayoutPanelMain.Controls.Add(forecastGroupPanel);
                foreach (ForecastData forecastData in forecastGroup)
                {
                    //добавление нового ЭУ в новую панель группы
                    ForecastAdvancedControlItem item = new ForecastAdvancedControlItem(forecastData);
                    forecastGroupPanel.Controls.Add(item);
                    _forecastControlItems.Add(item);
                }
            }
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
            foreach (ForecastAdvancedControlItem control in _forecastControlItems)
            {
                if (!control.SaveData()) return false;
                ForecastData fd = control.CurrneForecastData;
                fd.IncludeNotifyes = checkBoxNotifyes.Checked;
                fd.IncludePercents = checkBoxIncludePercents.Checked;
                fd.Percents = (int)numericUpDownPercents.Value;
            }

            return true;
        }

        #endregion

        #region private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            _currentForecast.ForecastDate = dateTimePicker1.Value;
            foreach (ForecastAdvancedControlItem item in _forecastControlItems)
            {
                item.DateChanged(dateTimePicker1.Value);
            }
        }
        #endregion

        #region private void CheckBoxIncludePercentsClick(object sender, EventArgs e)

        private void CheckBoxIncludePercentsClick(object sender, EventArgs e)
        {
            numericUpDownPercents.Enabled = checkBoxIncludePercents.Checked;
        }
        #endregion

        #region private void ButtonOkClick(object sender, System.EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (SaveData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #endregion
    }
}
