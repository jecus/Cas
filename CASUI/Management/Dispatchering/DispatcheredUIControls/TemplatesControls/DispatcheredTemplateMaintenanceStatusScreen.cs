using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения информации Maintenance Status в  шаблонах
    /// </summary>
    public class DispatcheredTemplateMaintenanceStatusScreen : TemplateMaintenanceStatusScreen, IDisplayingEntity
    {

        #region Fields

        private readonly TemplateAircraft aircraft;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации Maintenance Status в  шаблонах
        /// </summary>
        /// <param name="aircraft">Шаблонное ВС</param>
        public DispatcheredTemplateMaintenanceStatusScreen(TemplateAircraft aircraft) : base(aircraft)
        {
            this.aircraft = aircraft;
            Dock = DockStyle.Fill;
        }

        #endregion

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return null; }
            set { }
        }

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredTemplateMaintenanceStatusScreen))
            {
                return false;
            }
            DispatcheredTemplateMaintenanceStatusScreen objControl = (DispatcheredTemplateMaintenanceStatusScreen)obj;
            return (aircraft.Equals(objControl.aircraft));
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
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (limitationsControl.InfoViewerMaxResource.Modified || limitationsControl.InfoViewerNotification.Modified)
            {
                DialogResult result =
                    MessageBox.Show("Do you want to save changes?",
                                    (string)new TermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                    SaveData();
                if (result == DialogResult.Cancel)
                    arguments.Cancel = true;
            }
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
        }

        #endregion

        #region public void SetEnabled(bool isEnbaled)

        public void SetEnabled(bool isEnbaled)
        {

        }

        #endregion
        
        #region public event EventHandler InitComplition;

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion

    }
}
