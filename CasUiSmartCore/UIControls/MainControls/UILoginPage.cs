using System;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls;
using CAS.UI.UICAAControls.CurrentOperator;
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


            var isCAA = (bool)sender;
            if (isCAA)
            {
                if(GlobalObjects.CaaEnvironment.IdentityUser.OperatorId <= 0)
                    s = new OperatorSymmaryCAADemoScreen(GlobalObjects.CaaEnvironment.Operators[0]);
                else
                {
                    var op = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i =>
                        i.ItemId == GlobalObjects.CaaEnvironment.IdentityUser.OperatorId);
                    if(op != null)
                        s = new CurrentOperatorSymmaryCAADemoScreen(op);
                    else throw new Exception("Operator not found!");
                }
            }
            else s = new OperatorSymmaryDemoScreen(GlobalObjects.CasEnvironment.Operators[0]);

#if RELEASE
            try
            {
#endif
            referenceLoginControl.DisplayObject(
               new ReferenceEventArgs(s, ReflectionTypes.DisplayInNew, GlobalObjects.CasEnvironment?.Operators[0].Name ?? "CAA"));
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
            int aircraftOffset = -500;
            int descriptionOffset = 50;
            pictureBoxTopAircraft.Left = (Width - pictureBoxTopAircraft.Width) / 2 + aircraftOffset;
            pictureBoxTopAircraft.Top = (panelBottomContentContainer.Top - pictureBoxTopAircraft.Height) / 2;

            //pictureBoxTopText.Left = (Width - pictureBoxTopText.Width) / 2 + aircraftOffset;
            //pictureBoxTopText.Top = (panelBottomContentContainer.Top - pictureBoxTopText.Height) / 2;

            pictureBoxTopText.Top = pictureBoxTopAircraft.Top + (pictureBoxTopAircraft.Height - pictureBoxTopText.Height) / 2;
            pictureBoxTopText.Left = pictureBoxTopAircraft.Left + pictureBoxTopAircraft.Width + descriptionOffset;

            panelDescription.Top = pictureBoxTopAircraft.Top + (pictureBoxTopAircraft.Height - panelDescription.Height) / 2;
            panelDescription.Left = pictureBoxTopAircraft.Left + pictureBoxTopAircraft.Width + descriptionOffset;
        }

        #endregion


       #endregion

    }
}