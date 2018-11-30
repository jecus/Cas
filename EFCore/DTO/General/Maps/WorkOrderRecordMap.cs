﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class WorkOrderRecordMap : EntityTypeConfiguration<WorkOrderRecordDTO>
	{
		public WorkOrderRecordMap()
		{
			ToTable("dbo.WorkOrderRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.DirectivesId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectivesId");

			Property(i => i.PackageItemTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PackageItemTypeId");
		}
	}
}