using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class OnConditionStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public OnConditionStatusReportBuilder():base()
        public OnConditionStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public ComponentStatusReportBuilder(Aircraft reportedAircraft):base(reportedAircraft)
        public OnConditionStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "OnCondition Status";
            }
        }
        #endregion

        #endregion

    }
}
