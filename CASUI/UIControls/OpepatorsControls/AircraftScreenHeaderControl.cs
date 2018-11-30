using System;
using System.Collections.Generic;
using System.Text;
using Controls.AvButtonM;
using LTR.Core;

namespace LTR.UI.UIControls.OpepatorsControls
{
    public class AircraftScreenHeaderControl : OperatorHeaderControl
    {
        #region Fields
        private AvButtonM aircraftDisplayer;
        #endregion

        #region Constructors

        #region public AircraftScreenHeaderControl()
        ///<summary>
        /// Creates instance of control providing information about aircraft and it's operator
        ///</summary>
        public AircraftScreenHeaderControl()
        {
            InitializeComponents();
        }
        #endregion

        #region public AircraftScreenHeaderControl(Aircraft aircraft)
        /// <summary>
        /// Creates instance of control providing information about aircraft and it's operator
        /// </summary>
        /// <param name="aircraft">Aircraft to display</param>
        public AircraftScreenHeaderControl(Aircraft aircraft)
        {
            if (aircraft == null) throw new ArgumentNullException("aircraft");
            OperatorImage = ((Operator)aircraft.Parent).LogoType;
            OperatorText = ((Operator)aircraft.Parent).Name;

            InitializeComponents();
        }
        #endregion

        #endregion

        #region Methods
        private void InitializeComponents()
        {
            aircraftDisplayer = new AvButtonM();

            //Management.Icons
        }
        #endregion

    }
}
