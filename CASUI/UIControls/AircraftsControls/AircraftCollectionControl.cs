using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Отображает список ВС
    /// </summary>
    [ToolboxItem(false)]
    public class AircraftCollectionControl : AbstractAircraftCollectionControl
    {

        #region Fields

        private AnimatedThreadWorker animatedThreadWorker;
        private List<Aircraft> aircraftCollection;
        private Aircraft tempAircraft;
        private AircraftReferenceStatusImageLinkLabel tempAircraftListItemReference;
        private List<AircraftReferenceStatusImageLinkLabel> aircraftItems;
        //private const int HEIGHT = 520;

        #endregion

        #region Constructor

        ///<summary>
        /// Cоздается графический элемент на основе данной бизнес коллекции
        ///</summary>
        ///<param name="aircraftCollection">Данная бизнес коллекция</param>
        public AircraftCollectionControl(List<Aircraft> aircraftCollection)
        {
            //Height = HEIGHT;
            aircraftsListStatistics.Amount = aircraftCollection.Count;
            TopMargin = 20;
            Collection = aircraftCollection;
            FillUIElementsFromCollection();
        }

        #endregion

        #region Properties

        #region public List<Aircraft> Collection

        /// <summary>
        /// Возвращает коллекцию ВС
        /// </summary>
        public List<Aircraft> Collection
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
        /// Заполняет графический элемент из бизнес коллекции
        /// </summary>
        public override void FillUIElementsFromCollection()
        {
            int count = Collection.Count;
            aircraftItems = new List<AircraftReferenceStatusImageLinkLabel>();
            flowLayoutPanelAircrafts.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                AircraftReferenceStatusImageLinkLabel tempLabel = new AircraftReferenceStatusImageLinkLabel(Collection[i]);
                tempLabel.Text = Collection[i].RegistrationNumber;
                tempLabel.Width = 150;
                tempLabel.Enabled = true;
                if (OperatorCollection.Instance.Count == 1)
                    tempLabel.DisplayerText = Collection[i].RegistrationNumber;
                else
                    tempLabel.DisplayerText = Collection[i].Operator.Name + ". " + Collection[i].RegistrationNumber;
                tempLabel.DisplayerRequested += tempButton_DisplayerRequested;
                tempLabel.ReflectionType = ReflectionTypes.DisplayInNew;

                aircraftItems.Add(tempLabel);
                aircraftCollection[i].Saved -= AircraftCollectionControl_Saved;
                aircraftCollection[i].Saved += AircraftCollectionControl_Saved;
            }
            aircraftsListStatistics.Amount = aircraftItems.Count;
            aircraftItems.Sort(new AircraftReferenceStatusImageLinkLabelComparer());
            flowLayoutPanelAircrafts.Controls.AddRange(aircraftItems.ToArray());
        }

        #endregion

        #region private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            tempAircraft = (Aircraft)((AircraftReferenceStatusImageLinkLabel)sender).Aircraft;


            if (animatedThreadWorker == null)
            {

                if (TaskStart!=null)
                   TaskStart(this,new EventArgs());

                tempAircraftListItemReference = (AircraftReferenceStatusImageLinkLabel)sender;
                e.Cancel = true;

                animatedThreadWorker = new AnimatedThreadWorker(BackgroundAircraftLoad, sender, this);
                animatedThreadWorker.State = "Loading " + tempAircraft.RegistrationNumber;
                animatedThreadWorker.StartThread();
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;


           }
            else 
                e.RequestedEntity = new DispatcheredAircraftScreen(tempAircraft);

        }

        #endregion

        #region private void AircraftCollectionControl_Saved(object sender, EventArgs e)

        private void AircraftCollectionControl_Saved(object sender, EventArgs e)
        {
            for (int i = 0; i < aircraftItems.Count; i++)
            {
                if (aircraftItems[i].Aircraft == (Aircraft)sender)
                    aircraftItems[i].UpdateInformation();
            }
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            tempAircraftListItemReference.DisplayRequested();
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            tempAircraftListItemReference = null;
            if (TaskEnd != null)
                TaskEnd(this, new EventArgs());
        }

        #endregion

        #region private void BackgroundAircraftLoad(object sender)

        private void BackgroundAircraftLoad(object sender)
        {
            try
            {            
                if (tempAircraft is AircraftProxy)
                    ((AircraftProxy)tempAircraft).LoadRealObject();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
        }

        #endregion

        #region private void SetEnabledToAircraftButtons(bool isEnabled)
        /// <summary>
        /// Изменяет свойство Enabled у кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetEnabledToAircraftButtons(bool isEnabled)
        {
            for (int i = 0; i < aircraftItems.Count; i++)
            {
                if (aircraftItems[i] != tempAircraftListItemReference)
                    aircraftItems[i].Enabled = isEnabled;
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
