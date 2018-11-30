using System;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение информации о шаблонном ВС в заголовке
    ///</summary>
    public class TemplateAircraftHeaderControl : AbstractOperatorHeaderControl
    {

        #region Fields

        private TemplateAircraft aircraft;
        readonly Icons icons = new Icons();
        private bool aircraftClickable = false;
        private TemplateAircraftStateItem aircraftDisplayer;

        #endregion
        
        #region Constructors

        #region public TemplateAircraftHeaderControl()

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонном ВС в заголовке
        /// </summary>
        public TemplateAircraftHeaderControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public TemplateAircraftHeaderControl(TemplateAircraft aircraft) : this(aircraft, false, false)

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонном ВС в заголовке
        /// </summary>
        /// <param name="aircraft">Шаблонное ВС</param>
        public TemplateAircraftHeaderControl(TemplateAircraft aircraft) : this(aircraft, false, false)
        {
        }

        #endregion

        #region public TemplateAircraftHeaderControl(TemplateAircraft aircraft, bool templatesClicable) : this(aircraft, templatesClicable, false)

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонном ВС в заголовке
        /// </summary>
        /// <param name="aircraft">Шаблонное ВС</param>
        /// <param name="templatesClicable">Открывать ли страницу с шаблонами при щелчке мыши на иконку и "Templates"</param>
        public TemplateAircraftHeaderControl(TemplateAircraft aircraft, bool templatesClicable) : this(aircraft, templatesClicable, false)
        {
        }

        #endregion

        #region public TemplateAircraftHeaderControl(TemplateAircraft aircraft, bool templatesClicable, bool aircraftClicable)

        /// <summary>
        /// Создает элемент управления для отображения информации о шаблонном ВС в заголовке
        /// </summary>
        /// <param name="aircraft">Шаблонное ВС</param>
        /// <param name="templatesClicable">Открывать ли страницу с шаблонами при щелчке мыши на иконку и "Templates"</param>
        /// <param name="aircraftClicable">Открывать ли страницу с шаблонным ВС при щелчке мыши на модель ВС</param>
        public TemplateAircraftHeaderControl(TemplateAircraft aircraft, bool templatesClicable, bool aircraftClicable)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display Null aircraft");
            InitializeComponents();
            Aircraft = aircraft;
            OperatorClickable = templatesClicable;
            AircraftClickable = aircraftClicable;
        }

        #endregion

        #endregion

        #region Properties

        #region public bool AircraftClickable
        /// <summary>
        /// Отлавливается ли нажатие на ВС 
        /// </summary>
        public bool AircraftClickable
        {
            get { return aircraftClickable; }
            set
            {
                aircraftClickable = value;
                UpdateAircraftHeaderControl();
            }
        }
        #endregion

        #region public TemplateAircraft Aircraft

        /// <summary>
        /// Возвращает отображаемое шаблонное ВС
        /// </summary>
        public TemplateAircraft Aircraft
        {
            get
            {
                return aircraft;
            }
            set
            {
                aircraft = value;
                UpdateInformation();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aircraftDisplayer = new TemplateAircraftStateItem();
            splitViewer1.ControlsAmount = 5;
            splitViewer1[4] = aircraftDisplayer;
            aircraftDisplayer.DisplayerRequested += AircraftDisplayer_DisplayerRequested;
        }

        #endregion

        #region private void UpdateAircraftHeaderControl()
        /// <summary>
        /// Обновляется отображение элментов управления
        /// </summary>
        private void UpdateAircraftHeaderControl()
        {
            if (aircraftDisplayer == null)
                return;
            if (aircraftClickable)
            {
                aircraftDisplayer.Cursor = Cursors.Hand;
            }
            else
            {
                aircraftDisplayer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            UpdateOperatorInfo("Templates", icons.Templates);
            if (aircraftDisplayer != null)
                aircraftDisplayer.CurrentItem = aircraft;
        }

        #endregion

        #region private void AircraftDisplayer_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void AircraftDisplayer_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AircraftClickable)
            {
                //e.DisplayerText = "Templates. " + aircraft.Model;
                e.DisplayerText = aircraft.Model;
                e.RequestedEntity = new DispatcheredTemplateAircraftScreen(aircraft);
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (OperatorClickable)
            {
                e.DisplayerText = "Templates";
                e.RequestedEntity = new DispatcheredTemplateAircraftCollectionScreen();
            }
            else
                e.Cancel = true;
        }

        #endregion

        #endregion

    }
}
