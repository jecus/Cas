using System;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;

namespace SmartCore.CAA.Repositories
{
    public class CaaPerformanceRepository : ICaaPerformanceRepository
    {

	    public Lifelength CalcRemain(DateTime issueDateValidTo, Lifelength repeat = null)
	    {
		    if (repeat?.Days != null)
			    issueDateValidTo = issueDateValidTo.AddDays(repeat.Days.Value);
		    
		    var t = issueDateValidTo - DateTime.Today;
			return new Lifelength(t.Days, null, null);
	    }
	    
        public void GetNextPerformance(SmartCore.Entities.General.Document directive)
		{
			// Если следующего выполнения нет - то все остальные данные не имеют смысла
			if ((directive.IssueValidTo == false && directive.RevisionValidTo == false) || directive.IsClosed)
			{
				directive.Remains = null;
				directive.RevisionRemains = null;
				directive.NextPerformanceDate = null;
				directive.Condition = ConditionState.NotEstimated;
			}
			else // Директива имеет следующее выполнение 
			{
				Lifelength issueNotify = null, revisionNotify = null, performanceSource = null;

				// расчитываем remains
				if (directive.IssueValidTo)
				{
					var t = directive.IssueDateValidTo - DateTime.Today;
					directive.Remains = new Lifelength(t.Days, null, null);

					issueNotify = directive.IssueNotify > 0
						? new Lifelength(directive.IssueNotify, null, null)
						: null;
					performanceSource =
						new Lifelength(directive
							.Remains); //TODO:(Evgenii Babak) выяснить почему у performanceSource такое же значение, что и у Remains
				}

				if (directive.RevisionValidTo)
				{
					var t = directive.RevisionDateValidTo - DateTime.Today;
					directive.RevisionRemains = new Lifelength(t.Days, null, null);

					revisionNotify = directive.RevisionNotify > 0
						? new Lifelength(directive.RevisionNotify, null, null)
						: null;
					performanceSource =
						new Lifelength(directive
							.RevisionRemains); //TODO:(Evgenii Babak) выяснить почему у performanceSource такое же значение, что и у RevisionRemains
				}

				if (directive.Remains != null && directive.RevisionRemains != null)
				{
					//if (directive.Remains.IsLessOrEqualByAnyParameter(directive.RevisionRemains))
					//{
					//	directive.Condition = computeConditionState(performanceSource, directive.Remains, null, issueNotify, x => x.IsOverdue());
					//	directive.NextPerformanceDate = directive.IssueDateValidTo;
					//}
					//else
					//{
					directive.Condition = computeConditionState(performanceSource, directive.RevisionRemains, null,
						revisionNotify, x => x.IsOverdue());
					directive.NextPerformanceDate = directive.RevisionDateValidTo;
					//}
				}
				else if (directive.Remains != null)
				{
					directive.Condition = computeConditionState(performanceSource, directive.Remains, null, issueNotify,
						x => x.IsOverdue());
					directive.NextPerformanceDate = directive.IssueDateValidTo;
				}
				else
				{
					directive.Condition = computeConditionState(performanceSource, directive.RevisionRemains, null,
						revisionNotify, x => x.IsOverdue());
					directive.NextPerformanceDate = directive.RevisionDateValidTo;
				}
			}
		}
		
		private ConditionState computeConditionState(Lifelength performanceSource, Lifelength remains,
			Lifelength current, Lifelength notify, Func<Lifelength, bool> getIsOverdueFunc)
		{
			if (notify != null && !notify.IsNullOrZero())
			{
				if (getIsOverdueFunc(remains))
					return ConditionState.Overdue;

				var notifyRemains = new Lifelength(performanceSource);
				notifyRemains.Substract(notify);

				if (current != null && !current.IsNullOrZero())
					notifyRemains.Substract(current);

				notifyRemains.Resemble(notify);
				return getIsOverdueFunc(notifyRemains) ? ConditionState.Notify : ConditionState.Satisfactory;
			}

			return getIsOverdueFunc(remains) ? ConditionState.Overdue : ConditionState.Satisfactory;
		}
    }
}