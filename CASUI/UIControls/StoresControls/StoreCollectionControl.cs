using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.StoresControls;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Элемент управления для отображения списка складов
    /// </summary>
    public class StoreCollectionControl : AbstractAircraftCollectionControl
    {

        #region Fields

        private AnimatedThreadWorker animatedThreadWorker;
        private AircraftReferenceStatusImageLinkLabel item;
        private List<AircraftReferenceStatusImageLinkLabel> items;
        private List<Store> storeCollection;
        private AircraftProxy tempStore;
     //  private const int HEIGHT = 200;
        
        #endregion

        #region Constructor

        ///<summary>
        /// Cоздается элемент управления для отображения списка складов
        ///</summary>
        ///<param name="storeCollection">Коллекция складов</param>
        public StoreCollectionControl(List<Store> storeCollection)
        {
            //Height = HEIGHT;
            AutoSize = true;
            AutoSizeMode=AutoSizeMode.GrowAndShrink;
            aircraftsListStatistics.Caption = "Stores";
            aircraftsListStatistics.ObjectText = "Store";
            aircraftsListStatistics.Amount = storeCollection.Count;
            //flowLayoutPanelAircrafts.AutoScroll = true;
            TopMargin = 20;
            Collection = storeCollection;
            FillUIElementsFromCollection();
        }

        #endregion

        #region Properties

        #region public List<AircraftProxy> Collection

        /// <summary>
        /// Возвращает коллекцию складов
        /// </summary>
        public List<Store> Collection
        {
            get { return storeCollection; }
            set { storeCollection = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public override void FillUIElementsFromCollection()

        /// <summary>
        /// Обновляет отображаемую информацию
        /// </summary>
        public override void FillUIElementsFromCollection()
        {
            int count = Collection.Count;
            items = new List<AircraftReferenceStatusImageLinkLabel>();
            flowLayoutPanelAircrafts.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                AircraftReferenceStatusImageLinkLabel tempItem = new AircraftReferenceStatusImageLinkLabel(Collection[i]);
                tempItem.Text = Collection[i].Name;
                tempItem.Enabled = true;
                tempItem.DisplayerText = Collection[i].Operator.Name + ". " + Collection[i].Name;
                tempItem.DisplayerRequested += tempButton_DisplayerRequested;
                tempItem.ReflectionType = ReflectionTypes.DisplayInNew;

                items.Add(tempItem);
                storeCollection[i].Saved -= StoreCollectionControl_Saved;
                storeCollection[i].Saved += StoreCollectionControl_Saved;
            }
            aircraftsListStatistics.Amount = items.Count;
            items.Sort(new AircraftReferenceStatusImageLinkLabelComparer());
            flowLayoutPanelAircrafts.Controls.AddRange(items.ToArray());
        }

        #endregion

        #region private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void tempButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {

            tempStore = (AircraftProxy)((Store)(((AircraftReferenceStatusImageLinkLabel)sender).Aircraft)).GetProxy();

            if (animatedThreadWorker == null)
            {
                if (TaskStart != null)
                    TaskStart(this, new EventArgs());
                item = (AircraftReferenceStatusImageLinkLabel)sender;
                e.Cancel = true;
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundAircraftLoad, sender, this);
                animatedThreadWorker.State = "Loading " + tempStore.RegistrationNumber;
                animatedThreadWorker.StartThread();
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
            }
            else e.RequestedEntity = new DispatcheredStoreScreen(tempStore);

        }

        #endregion

        #region private void StoreCollectionControl_Saved(object sender, EventArgs e)

        private void StoreCollectionControl_Saved(object sender, EventArgs e)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Aircraft == (Store)sender)
                    items[i].UpdateInformation();
            }
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            item.DisplayRequested();
            animatedThreadWorker.StopThread();
            animatedThreadWorker = null;
            item = null;
            if (TaskEnd != null)
                TaskEnd(this, new EventArgs());
        }

        #endregion

        #region private void BackgroundAircraftLoad(object sender)

        private void BackgroundAircraftLoad(object sender)
        {
            try
            {
                if (tempStore is AircraftProxy)
                    tempStore.LoadRealObject();
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
        /// Изменить свойство Enabled у кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetEnabledToAircraftButtons(bool isEnabled)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] != item)
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