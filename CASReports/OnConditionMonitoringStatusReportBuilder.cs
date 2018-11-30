using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class OnConditionMonitoringStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public ComponentStatusReportBuilder(Aircraft reportedAircraft):base(reportedAircraft)
        public OnConditionMonitoringStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
