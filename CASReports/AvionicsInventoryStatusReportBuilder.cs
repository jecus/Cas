using System;
using System.Collections.Generic;
using System.Text;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTRReports
{
    public class AvionicsInventoryStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public AvionicsInventoryStatusReportBuilder():base()
        public AvionicsInventoryStatusReportBuilder():base()
        {
            
        }
        #endregion

        #region public AvionicsInventoryStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
        public AvionicsInventoryStatusReportBuilder(Aircraft reportedAircraft, Detail[] details, string dateAsOf) : base(reportedAircraft , details,dateAsOf)
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
                return "Avionics Inventory Status";
            }
        }
        #endregion

        #endregion

    }
}
