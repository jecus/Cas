using System.Linq;
using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.DataAccesses.Kits;
using SmartCore.DataAccesses.NonRoutines;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;

namespace SmartCore.NonRoutineJobs
{
	public class NonRoutineJobHelper
	{

		#region private NonRoutineJob Convert(NonRoutineJobDTO nrjDTO, ICasEnvironment casEnvironment)

		public static NonRoutineJob Convert(NonRoutineJobDTO nrjDTO, ICasEnvironment casEnvironment)
		{
			var nrj = new NonRoutineJob
			{
				ATAChapter = (AtaChapter)casEnvironment.GetDictionary<AtaChapter>().GetItemById(nrjDTO.ATAChapterId),
				ItemId = nrjDTO.ItemId,
				IsDeleted = nrjDTO.IsDeleted,
				ManHours = nrjDTO.ManHours,
				Title = nrjDTO.Title,
				Cost = nrjDTO.Cost,
				KitRequired = nrjDTO.KitRequired,
				Description = nrjDTO.Description
			};

			foreach (var kit in nrjDTO.Kits)
			{
				nrj.Kits.Add(new AccessoryRequired
				{
					ItemId = kit.ItemId,
					IsDeleted = kit.IsDeleted,
					Description = kit.Description,
					Manufacturer = kit.Manufacturer,
					ParentTypeId = kit.ParentTypeId,
					ParentId = kit.ParentId,
					Product = kit.Product,
					Quantity = kit.Quantity,
					PartNumber = kit.PartNumber,
					ParentObject = nrj

				});
			}

			nrjDTO.Kits.Clear();

			var nrjDTOFile = nrjDTO.Files.SingleOrDefault();
			if (nrjDTOFile != null)
			{
				nrj.AttachedFile = new AttachedFile
				{
					FileData = nrjDTOFile.File.FileData,
					FileName = nrjDTOFile.File.FileName,
					FileSize = nrjDTOFile.File.FileSize,
					ItemId = nrjDTOFile.File.ItemId
				};
			}

			nrjDTO.Files.Clear();

			return nrj;
		}

		#endregion

		#region private NonRoutineJobDTO Convert(NonRoutineJob nonRoutineJob)

		public static NonRoutineJobDTO Convert(NonRoutineJob nonRoutineJob)
		{
			var nonRoutineJobDTO = new NonRoutineJobDTO
			{
				ATAChapterId = nonRoutineJob.ATAChapter.ItemId,
				ItemId = nonRoutineJob.ItemId,
				IsDeleted = nonRoutineJob.IsDeleted,
				ManHours = nonRoutineJob.ManHours,
				Title = nonRoutineJob.Title,
				Cost = nonRoutineJob.Cost,
				KitRequired = nonRoutineJob.KitRequired,
				Description = nonRoutineJob.Description
			};

			foreach (var kit in nonRoutineJob.Kits)
			{
				nonRoutineJobDTO.Kits.Add(new KitDTO
				{
					ItemId = kit.ItemId,
					IsDeleted = kit.IsDeleted,
					Description = kit.Description,
					Manufacturer = kit.Manufacturer,
					ParentTypeId = kit.ParentTypeId,
					ParentId = kit.ParentId,
					Product = kit.Product,
					Quantity = kit.Quantity,
					PartNumber = kit.PartNumber,

				});
			}

			if (nonRoutineJob.AttachedFile != null)
			{
				nonRoutineJobDTO.Files.Add(new ItemFileLinkDTO
				{
					LinkType = (short)FileLinkType.NonRoutineJobTaskCardFile,
					ParentTypeId = SmartCoreType.NonRoutineJob.ItemId,
					ParentId = nonRoutineJob.ItemId,
					File = new AttachedFileDTO
					{
						ItemId = nonRoutineJob.AttachedFile.ItemId,
						IsDeleted = nonRoutineJob.AttachedFile.IsDeleted,
						FileName = nonRoutineJob.AttachedFile.FileName,
						FileData = nonRoutineJob.AttachedFile.FileData,
						FileSize = nonRoutineJob.AttachedFile.FileSize
					}
				});
			}


			return nonRoutineJobDTO;
		}

		#endregion
	}
}