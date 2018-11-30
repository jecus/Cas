using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class LLPStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public LLPStatusReportBuilder():base()
        public LLPStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public LLPStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
        public LLPStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "LLP Status";
            }
        }
        #endregion

        #endregion

    }
}
