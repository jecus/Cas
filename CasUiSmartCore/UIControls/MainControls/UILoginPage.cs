using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.OpepatorsControls;
using CASTerms;

namespace CAS.UI.UIControls.MainControls
{
    /// <summary>
    /// Элемент управления, необходимый для входа в систему
    /// </summary>
    internal partial class UILoginPage : UserControl 
    {
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для входа в систему
        /// </summary>
        public UILoginPage()
        {
            InitializeComponent();
            referenceLoginControl.ConnectedAction = ArgumentsCreation;
        }

        private void ArgumentsCreation(object sender, EventArgs e)
        {
            /*OperatorCollection operators = GlobalObjects.CasEnvironment.Operators;
            int count = operators.Count;
            DirectiveConditionState condition = DirectiveConditionState.Notify;
            foreach(Operator operator_ in operators)
            {
                AircraftCollection aircrafts = GlobalObjects.CasEnvironment.;
                int aircraftCount = aircrafts.Count;
                
                for (int j = 0; j < aircraftCount; j++)
                {
                    condition = aircrafts[j].ConditionState;
                }
            }*/
        }

        #endregion

        #region Properties

        #region public ReferenceUILoginControl LoginControl

        /// <summary>
        /// Возвращает контрол подключения к серверу
        /// </summary>
        public ReferenceUILoginControl LoginControl
        {
            get
            {
                return referenceLoginControl;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region void DispatcheredLoginControlConnected(object sender, EventArgs e)

        protected virtual void DispatcheredLoginControlConnected(object sender, EventArgs e)
        {
            ScreenControl s;
#if !KAC
            s = new OperatorSymmaryDemoScreen(GlobalObjects.CasEnvironment.Operators[0]);
#else
            s = new OperatorSummaryScreen(GlobalObjects.CasEnvironment.Operators[0]);
#endif

#if RELEASE
            try
            {
#endif
            referenceLoginControl.DisplayObject(
               new ReferenceEventArgs(s, ReflectionTypes.DisplayInNew, GlobalObjects.CasEnvironment.Operators[0].Name));
            //referenceLoginControl.DisplayObject(
            //    new ReferenceEventArgs(new DispatcheredAircraftCollectionScreen(), ReflectionTypes.DisplayInNew,
            //                               "Operators"));
#if RELEASE
            }
            catch
            {
                throw new Exception("Failed to connect to database. See UILoginPage.dispatcheredLoginControl_Connected");
            }
#endif
        }

        #endregion

        #region private void referenceLoginControl_ExitClicked(object sender, EventArgs e)

        private void dispatcheredLoginControl_ExitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
        
        #region protected override void OnSizeChanged(EventArgs e)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            int aircraftOffset = -50;
            int descriptionOffset = 50;
            pictureBoxTopAircraft.Left = (Width - pictureBoxTopAircraft.Width) / 2 + aircraftOffset;
            pictureBoxTopAircraft.Top = (panelBottomContentContainer.Top - pictureBoxTopAircraft.Height) / 2;
            panelDescription.Top = pictureBoxTopAircraft.Top + (pictureBoxTopAircraft.Height - panelDescription.Height) / 2;
            panelDescription.Left = pictureBoxTopAircraft.Left + pictureBoxTopAircraft.Width + descriptionOffset;
        }

        #endregion


       #endregion

    }
}