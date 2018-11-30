using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Класс, описывающий отображение информации о ВС в заголовке
    ///</summary>
    public class AircraftHeaderControl : AbstractOperatorHeaderControl
    {

        #region Fields

        private Aircraft aircraft;
        private bool aircraftClickable = false;
        private AircraftStateItem aircraftDisplayer;

        #endregion

        #region Constructors

        #region public AircraftHeaderControl()

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        public AircraftHeaderControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public AircraftHeaderControl(Aircraft aircraft):this(aircraft,false, false)

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        public AircraftHeaderControl(Aircraft aircraft):this(aircraft,false, false)
        {
        }

        #endregion

        #region public AircraftHeaderControl(Aircraft aircraft, bool operatorClickable): this(aircraft, operatorClickable, false)

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        /// <param name="operatorClickable">Показывает, нужно ли переходить на вкладку эксплуатанта после клика на иконку или название оператора</param>
        public AircraftHeaderControl(Aircraft aircraft, bool operatorClickable): this(aircraft, operatorClickable, false)
        {
        }

        #endregion

        #region public AircraftHeaderControl(Aircraft aircraft, bool operatorClickable, bool aircraftClickable)

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        /// <param name="operatorClickable">Показывает, нужно ли переходить на вкладку эксплуатанта после клика на иконку или название оператора</param>
        /// <param name="aircraftClickable">Показывает, нужно ли переходить на вкладку ВС после клика на название ВС</param>
        public AircraftHeaderControl(Aircraft aircraft, bool operatorClickable, bool aircraftClickable)
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "Cannot display Null aircraft");

            InitializeComponents();
            OperatorClickable = operatorClickable;
            AircraftClickable = aircraftClickable;
            Aircraft = aircraft;
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

        #region public Aircraft Aircraft

        ///<summary>
        /// Отображаемое ВС 
        ///</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Aircraft Aircraft
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
            aircraftDisplayer = new AircraftStateItem();
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
        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        private void UpdateInformation()
        {
            if (aircraft != null)
            {
                if (aircraft.Parent is Operator)
                {
                    UpdateOperatorInfo(aircraft.Operator.Name, aircraft.Operator.LogoType);
                }
                aircraftDisplayer.CurrentItem = aircraft;
            }
        }
        #endregion

        #region private void AircraftDisplayer_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void AircraftDisplayer_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AircraftClickable)
            {
                e.DisplayerText = Aircraft.Operator.Name + " : " + aircraft.RegistrationNumber;
                e.RequestedEntity = new DispatcheredAircraftScreen(aircraft);
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (OperatorClickable && Aircraft.Operator != null)
            {
                e.DisplayerText = Aircraft.Operator.Name;
                e.RequestedEntity = new DispatcheredAircraftCollectionScreen(Aircraft.Operator);
            }
            else
                e.Cancel = true;
        }

        #endregion

        #endregion

    }
}
