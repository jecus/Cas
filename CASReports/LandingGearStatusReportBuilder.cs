using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class LandingGearStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public LandingGearStatusReportBuilder():base()
        public LandingGearStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public LandingGearStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
        public LandingGearStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
        {
        }
        #endregion

        #endregion

        #region Properties

        #region public override string ReportTitle
        public override string ReportTitle
        {
            get
            {
                return "Landing Gear Status";
            }
        }
        #endregion

        #endregion

    }
}
