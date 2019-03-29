using System;
using System.Reflection;
using EFCore.DTO.Dictionaries;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.Entities.Dictionaries
{
    [Table("DamageCharts","dictionaries","ItemId")]
	[Dto(typeof(DamageChartDTO))]
    public class DamageChart : BaseEntityObject, IFileContainer
	{
		private static Type _thisType;

		#region public String ChartName { get; set; }
		/// <summary>
		/// Общее имя 
		/// </summary>
		[TableColumnAttribute("ChartName")]
        public String ChartName { get; set; }
        #endregion

        #region public AircraftModel AircraftModel { get; set; }
        /// <summary>
        /// Короткое имя
        /// </summary>
        [TableColumnAttribute("AircraftModelId")]
        [Child(false)]
        public AircraftModel AircraftModel { get; set; }


		public static PropertyInfo AircraftModelId
		{
			get { return GetCurrentType().GetProperty("AircraftModel"); }
		}

		#endregion



		#region  public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// Файл листа повреждений
		/// </summary>
		public AttachedFile AttachedFile
	    {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.DamageChartAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.DamageChartAttachedFile);
			}
		}

	    #endregion


		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

	    [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1180)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
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

		#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
            return ChartName;
        }
        #endregion

        #region public DamageChart()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public DamageChart()
        {
            IsDeleted = false;
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.DamageChart;
            ChartName = "";
            AircraftModel = null;
            AttachedFile = null;
        }
        #endregion

        #region public DamageChart(Int32 itemId, String chartName, AircraftModel aircraftModel, int fileId)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="chartName"></param>
        /// <param name="aircraftModel"></param>
        /// <param name="fileId"></param>
        public DamageChart(Int32 itemId, String chartName, AircraftModel aircraftModel)
        {
            IsDeleted = false;
            ItemId = itemId;
            ChartName = chartName;
            AircraftModel = aircraftModel;
        }
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(DamageChart));
		}
		#endregion

	}
}
