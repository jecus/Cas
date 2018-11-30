using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.ProjectTerms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls
{
    /// <summary>
    /// Отображает общую информацию о ВС
    /// </summary>
    public partial class DispatcheredAircraftGeneralDataScreen : AircraftGeneralDataScreen, IDisplayingEntity
    {
        /// <summary>
        /// Создает элемент управления для отображения информации о ВС
        /// </summary>
        public DispatcheredAircraftGeneralDataScreen(Aircraft currentAircraft):base(currentAircraft)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }


        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentAircraft; }
            set
            {
                if (value is Aircraft)
                    currentAircraft = value as Aircraft;
            }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredAircraftGeneralDataScreen)) return false;
            if (!(obj.ContainedData is Aircraft)) return false;

            return (currentAircraft.ID == ((Aircraft)obj.ContainedData).ID);
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (aircraftControl.GetChangeStatus() || powerPlantsControl.GetChangeStatus() || APUControl.GetChangeStatus() || performanceDataControl.GetChangeStatus() || landingGearsControl.GetChangeStatus() || interiorConfigurationControl.GetChangeStatus() || otherControl.GetChangeStatus())
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                       MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        Save();
                        arguments.Cancel = false;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {
            SetPageEnable(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion

    }
}
