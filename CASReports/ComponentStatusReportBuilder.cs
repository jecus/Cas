using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class ComponentStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public ComponentStatusReportBuilder():base()
        public ComponentStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public ComponentStatusReportBuilder(Aircraft reportedAircraft):base(reportedAircraft)
        public ComponentStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "Component Status";
            }
        }
        #endregion

        #endregion

    }
}
