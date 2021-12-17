using System.Collections.Generic;
using System.Linq;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions.Filters;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.NewLoader;
using SmartCore.WorkPackages;

namespace SmartCore.NonRoutineJobs
{
	public class NonRoutineJobCore : INonRoutineJobCore
	{
		private readonly ICasEnvironment _casEnvironment;
		private readonly IWorkPackageCore _workPackageCore;
		private readonly INonRoutineJobDataAccess _nonRoutineJobDataAccess;
		private readonly INewLoader _newLoader;

		public NonRoutineJobCore(ICasEnvironment casEnvironment, IWorkPackageCore workPackageCore,
								 INonRoutineJobDataAccess nonRoutineJobDataAccess, INewLoader newLoader)
		{
			_casEnvironment = casEnvironment;
			_workPackageCore = workPackageCore;
			_nonRoutineJobDataAccess = nonRoutineJobDataAccess;
			_newLoader = newLoader;
		}

		#region public NonRoutineJob[] GetNonRoutineJobsStatus(Aircraft aircraft)
		/// <summary>
		/// Возвращает все NonRoutineJobs воздушного судна
		/// </summary>
		/// <returns></returns>
		public NonRoutineJob[] GetNonRoutineJobsStatus(Aircraft aircraft)
		{
			var preJobs = _nonRoutineJobDataAccess.GetNonRoutineJobDTOsFromAircraftWorkPackages(aircraft.ItemId);

			//поиск всех записей о использовании нерутинных работ в рабочих пакетах данного самолета
			var wpIds = _newLoader.GetSelectColumnOnly<WorkPackageDTO>(new []{ new Filter("ParentId", aircraft.ItemId) }, "ItemId");
			var wprList = _newLoader.GetObjectListAll<WorkPackageRecordDTO, WorkPackageRecord>(new List<Filter>()
			{
				new Filter("WorkPackageItemType",SmartCoreType.NonRoutineJob.ItemId),
				new Filter("WorkPakageId",wpIds)
			});

			//загрузка всех рабочих пакетов заданного самолета
			var wpList = _workPackageCore.GetWorkPackages(aircraft);

			var preJobsDict = preJobs.Select(j => NonRoutineJobHelper.Convert(j,_casEnvironment)).ToDictionary(p => p.ItemId);

			//связывание нерутинных работ с рабочими пакетами
			var resultJobs = new List<NonRoutineJob>();
			foreach (var wpr in wprList)
			{
				var nonRoutineJob = preJobsDict[wpr.DirectiveId];

				resultJobs.Add(nonRoutineJob);
				nonRoutineJob.WorkPackageRecord = wpr;

				//поиск рабочего пакета
				var wp = wpList.FirstOrDefault(w => w.ItemId == wpr.WorkPakageId);
				if (wp != null)
				{
					wpr.WorkPackage = wp;
					nonRoutineJob.ParentWorkPackage = wp;
				}
			}
			return resultJobs.ToArray();
		}

		#endregion

		#region public IEnumerable<NonRoutineJob> GetNonRoutineJobs()

		public IEnumerable<NonRoutineJob> GetNonRoutineJobs()
		{
			var dtos = _nonRoutineJobDataAccess.GetNonRoutineJobDTOs();
			var res = dtos.Select(n => NonRoutineJobHelper.Convert(n, _casEnvironment));

			return res;
		}

		#endregion

		#region public void Save(NonRoutineJob nonRoutineJob)

		public void Save(NonRoutineJob nonRoutineJob)
		{
			var nrjDTO = NonRoutineJobHelper.Convert(nonRoutineJob);
			_nonRoutineJobDataAccess.Save(nrjDTO);
		}

		#endregion

		#region public void Delete(NonRoutineJob nonRoutineJob)

		public void Delete(NonRoutineJob nonRoutineJob)
		{
			var nrjDTO = NonRoutineJobHelper.Convert(nonRoutineJob);
			_nonRoutineJobDataAccess.Delete(nrjDTO);
		}

		#endregion


	}
}