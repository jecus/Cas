using LTR.Core.Core.Interfaces;
using LTR.Core.Types.Aircrafts;
using LTR.UI.UIControls.AircraftsControls;

namespace LTR.UI.UIControls.TemplatesControls
{
    public class TemplateAircraftCollectionListControl : AbstractAircraftCollectionControl
    {

        #region Constructor

        public TemplateAircraftCollectionListControl(TemplateAircraftCollection aircraftCollection) : base(aircraftCollection)
        {
        }

        #endregion

        #region Methods

        #region public override string GetDisplayerText(IAircraft iaircraft)

        public override string GetDisplayerText(IAircraft iaircraft)
        {
            //TemplateAircraft aircraft = (TemplateAircraft) iaircraft;
            return ""; //tobo 
        }

        #endregion

        #region public override string GetText(IAircraft iaircraft)

        public override string GetText(IAircraft iaircraft)
        {
            return ""; //todo
        }

        #endregion
        
        #endregion

    }
}
