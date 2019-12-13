using System;
using SmartCore.DataAccesses.AttachedFiles;
using SmartCore.DataAccesses.Kits;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.DataAccesses.NonRoutines
{

	[Table("NonRoutineJobs", "Dictionaries", "ItemId")]
	[Dto(typeof(NonRoutineJobDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class NonRoutineJobDTO : BaseEntityObject, IFileDTOContainer
	{
		/*
		*  Свойства
		*/

		/// <summary>
		/// Часть воздушного судна, где требуется провести работу
		/// </summary>
		[TableColumn("AtaChapterId")]
		public int ATAChapterId { get; set; }
		/// <summary>
		/// название работы
		/// </summary>
		[TableColumn("Title")]
		public string Title { get; set; }
		/// <summary>
		/// описание работы
		/// </summary>
		[TableColumn("Description")]
		public string Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("KitRequired")]
		public string KitRequired { get; set; }//TODO:(Evgenii Babak) проверить назначение этого свойства
		/// <summary>
		/// Количество человеко часов, необходимых для выполнения работы
		/// </summary>
		[TableColumn("ManHours")]
		public double ManHours { get; set; }

		[TableColumn("Cost")]
		public double Cost { get; set; }

		private CommonCollection<KitDTO> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4)]
		public CommonCollection<KitDTO> Kits
		{
			get { return _kits ?? (_kits = new CommonCollection<KitDTO>()); }
			internal set
			{
				if (_kits != value)
				{
					if (_kits != null)
						_kits.Clear();
					if (value != null)
						_kits = value;
				}
			}
		}

		private CommonCollection<ItemFileLinkDTO> _files;
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4, ColumnAccessType.ReadOnly)]
		public CommonCollection<ItemFileLinkDTO> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLinkDTO>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}


		/*
		*  Методы 
		*/

		/// <summary>
		/// Создает нерутинную работу без дополнительной информации
		/// </summary>
		public NonRoutineJobDTO()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.NonRoutineJob;
		}
	}
}
