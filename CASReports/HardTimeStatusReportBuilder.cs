using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class HardTimeStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public HardTimeStatusReportBuilder():base()
        public HardTimeStatusReportBuilder():base()
        {
            
        }
        #endregion
        
        #region public ComponentStatusReportBuilder(Aircraft reportedAircraft):base(reportedAircraft)
        public HardTimeStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "Hard Time Status";
            }
        }
        #endregion

        #endregion

    }
}
