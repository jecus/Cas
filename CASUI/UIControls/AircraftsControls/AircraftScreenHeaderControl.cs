using System;
using System.Drawing;
using System.Windows.Forms;
using LTR.Core;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using LTR.UI.UIControls.AircraftsControls;
using LTR.UI.UIControls.OpepatorsControls;

namespace LTR.UI.UIControls.AircraftsControls
{
    ///<summary>
    /// Класс, описывающий контрол отображаемый в заголовке
    ///</summary>
    public class AircraftScreenHeaderControl : OperatorHeaderControl//, IReference
    {

        #region Fields

        private Aircraft aircraft;
        private AircraftStateItem aircraftDisplayer;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructors

        #region public AircraftScreenHeaderControl() : this(null)

        ///<summary>
        /// Creates instance of control providing information about aircraft and it's operator
        ///</summary>
        public AircraftScreenHeaderControl()
        {
        }

        #endregion
        
        #region public AircraftScreenHeaderControl(Aircraft aircraft)

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        public AircraftScreenHeaderControl(Aircraft aircraft):this(aircraft,false)
        {
        }

        #endregion

        #region public AircraftScreenHeaderControl(Aircraft aircraft, bool operatorClickable):base(aircraft.Parent as Operator, operatorClickable)

        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        public AircraftScreenHeaderControl(Aircraft aircraft, bool operatorClickable):base(aircraft.Parent as Operator, operatorClickable)
        {
            this.aircraft = aircraft;

            InitializeComponents();
            reflectionType = ReflectionTypes.DisplayInNew;
            //TitleButton.Click += title_Click;
            UpdateInformation();
        }

        #endregion

        #endregion

     /*   #region Properties

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return null; }
            set { }
        }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return "Operator"; }
            set { }
        }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return null; }
            set { }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #region public Aircraft Aircraft

        ///<summary>
        /// Отображаемое ВС 
        ///</summary>
        public Aircraft Aircraft
        {
            get { return aircraft; }
            set
            {
                aircraft = value;
                UpdateInformation();
            }
        }

        #endregion

        #endregion*/

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            if (aircraft != null)
                aircraftDisplayer = new AircraftStateItem(aircraft);
            else
                aircraftDisplayer = new AircraftStateItem();
            splitViewer1.ControlsAmount = 3;
            splitViewer1[2] = aircraftDisplayer;

            aircraftDisplayer.ForeColorMain = Color.FromArgb(49, 82, 128);
            aircraftDisplayer.PaddingMain = new Padding(0, 8, 0, 0);
            aircraftDisplayer.FontMain = new Font("Verdana", 16, GraphicsUnit.Pixel);
        }

        #endregion

        #region public void UpdateInformation()
        /// <summary>
        /// Обновляется отображаемая информация
        /// </summary>
        public void UpdateInformation()
        {
            if (aircraft != null)
            {
                if (aircraft.Parent is Operator)
                {
                    LogotypeButton.Icon = ((Operator) aircraft.Parent).LogoType;
                    TitleButton.Text = ((Operator) aircraft.Parent).Name;
                }
                aircraftDisplayer.CurrentItem = aircraft;
                aircraftDisplayer.UpdateInformation();
            }
        }
        #endregion

   /*     #region private void title_Click(object sender, EventArgs e)

        private void title_Click(object sender, EventArgs e)
        {
            OnDisplayerRequested();
        }

        #endregion

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// Вызывается событие DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested && aircraft != null && aircraft.Operator != null)
            {

                DisplayerRequested(this, new ReferenceEventArgs(new DispatcheredOperatorScreen(aircraft.Operator), reflectionType, DisplayerText));
            }
        }
        #endregion*/

        #endregion

        #region Events

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion
        
    }
}