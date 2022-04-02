using System;
using SmartCore.Entities.General;

namespace SmartCore.CAA.Audit
{
    public class AuditPublish : BaseEntityObject
    {
        public int WorkFlowStageId { get; set; }
        public int AllTask { get; set; }
        public int TaskInProgress { get; set; }
        public int MyTask { get; set; }

        public int Persent
        {
            get
            {
                if (WorkFlowStageId == WorkFlowStage.Evaluation.ItemId || WorkFlowStageId == WorkFlowStage.CAR.ItemId)
                {
                    var res = ((double)(AllTask - TaskInProgress) / AllTask) * 100;
                    return (int)Math.Round(res);
                }

                if (WorkFlowStageId == WorkFlowStage.Closed.ItemId)
                {
                    var res = (double)(TaskInProgress / AllTask) * 100;
                    return (int)Math.Round(res);
                }
                if (WorkFlowStageId == WorkFlowStage.RCA.ItemId || WorkFlowStageId == WorkFlowStage.CAP.ItemId)
                {
                    var res = ((double)(AllTask - TaskInProgress) / AllTask) * 100;
                    return (int)Math.Round(res);
                }

                return 0;
            }
        }
    }
}