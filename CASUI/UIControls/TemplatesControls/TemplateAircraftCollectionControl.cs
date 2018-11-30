using System;
using System.Collections.Generic;
using System.ComponentModel;
using CAS.UI.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения списока шаблонных ВС
    /// </summary>
    [ToolboxItem(false)]
    public class TemplateAircraftCollectionControl : AbstractAircraftCollectionControl
    {

        #region Fields

        //private TemplateAircraftCollection aircraftCollection;
        private List<TemplateAircraft> aircraftCollection = new List<TemplateAircraft>();
        private readonly List<AircraftReferenceStatusImageLinkLabel> items = new List<AircraftReferenceStatusImageLinkLabel>();
        private readonly Icons icons = new Icons();
        //private const int HEIGHT = 780;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает экземпляр элемента управления для отображения списка шаблонных ВС
        /// </summary>
        public TemplateAircraftCollectionControl()
        {
            TopMargin = 20;
            FillUIElementsFromCollection();
        }

        #endregion

        #region Properties

        #region public List<TemplateAircraft> Collection

        /// <summary>
        /// Возвращает коллекцию ВС
        /// </summary>
        public List<TemplateAircraft> Collection
        {
            get
            {
                return aircraftCollection;
            }
            set
            {
                aircraftCollection = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public override void FillUIElementsFromCollection()

        /// <summary>
        /// Осуществляет заполнение пользовательских элементов управления на основе данных бизнес коллекции
        /// </summary>
        public override void FillUIElementsFromCollection()
        {
            //Collection = TemplateAircraftCollection.Instance;
            Collection.Clear();
            for (int i = 0; i < TemplateAircraftCollection.Instance.Count; i++ )
                Collection.Add(TemplateAircraftCollection.Instance[i]);
            aircraftsListStatistics.Amount = Collection.Count;
            items.Clear();
            flowLayoutPanelAircrafts.Controls.Clear();
            Collection.Sort(new TemplateAircraftModelComparer());
            for (int i = 0; i < Collection.Count; i++)
            {
                AircraftReferenceStatusImageLinkLabel tempLabel = new AircraftReferenceStatusImageLinkLabel(Collection[i]);
                //tempButton.SecondaryTextPosition = 60;
                tempLabel.Text = Collection[i].Model;
                tempLabel.Width = 300;
                tempLabel.Enabled = true;
          //      tempButton.Icon = icons.GreenArrow;
             //   tempButton.SecondText = "";
                tempLabel.DisplayerText = Collection[i].Model;
                tempLabel.DisplayerRequested += tempButton_DisplayerRequested;
                tempLabel.ReflectionType = ReflectionTypes.DisplayInNew;

                items.Add(tempLabel);
            }
            aircraftsListStatistics.Amount = items.Count;
            Array.Sort(items.ToArray(), new AircraftReferenceStatusImageLinkLabelComparer());
            flowLayoutPanelAircrafts.Controls.AddRange(items.ToArray());
        }

        #endregion

        #region private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredTemplateAircraftScreen((TemplateAircraft)((AircraftReferenceStatusImageLinkLabel)sender).Aircraft);
        }

        #endregion

        #region public void SetEnabledToAircraftButtons(bool isEnabled)

        /// <summary>
        /// Изменяет свойство Enabled у кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetEnabledToAircraftButtons(bool isEnabled)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Enabled = isEnabled;
            }
        }

        #endregion


        #endregion

        #region Events
        /// <summary>
        /// Событие оповещающее о начале работы в другом потоке
        /// </summary>
        public event EventHandler TaskStart;

        /// <summary>
        /// Событие оповещающее о конце работы в другом потоке
        /// </summary>
        public event EventHandler TaskEnd;

        #endregion

    }
}
