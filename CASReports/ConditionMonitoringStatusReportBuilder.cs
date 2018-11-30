using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class ConditionMonitoringStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public ConditionMonitoringStatusReportBuilder():base()
        public ConditionMonitoringStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public ConditionMonitoringStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
        public ConditionMonitoringStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "Condition Monitoring Status";
            }
        }
        #endregion

        #endregion

    }
}
