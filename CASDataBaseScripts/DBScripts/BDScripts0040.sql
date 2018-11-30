----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackages')
                    and c.name = 'FileId' ) 

begin
	with workPackageFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.WorkPackages as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0
	),
	workPackageFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from workPackageFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using workPackageFileIds as S
	on S.ItemId = T.ParentId and 
	   2499 = T.ParentTypeId and --WorkPackage
	   11 = T.LinkType           --WorkPackageAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 2499, 11, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ATLBs')
                    and c.name = 'FileId' ) 

begin
	with atlbFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.ATLBs as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0
	),
	atlbFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from atlbFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using atlbFileIds as S
	on S.ItemId = T.ParentId and 
	   1040 = T.ParentTypeId and --ATLB
	   12 = T.LinkType           --ATLBAttachedFile 
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1040, 12, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'FileID' ) 

begin
	with transferRecordFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileID as FileID,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.TransferRecords as d left join dbo.Files as f on f.ItemId = d.FileID
		where d.FileID is not null and 
			  d.FileID > 0 and
			  f.IsDeleted = 0
	),
	transferRecorFileIds(IsDeleted, ItemId, FileID)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileID
		from transferRecordFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using transferRecorFileIds as S
	on S.ItemId = T.ParentId and 
	   2260 = T.ParentTypeId and --TransferRecord
	   13 = T.LinkType           --TransferRecordAttachedFile 
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 2260, 13, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'ResumeFileId' ) 

begin
	with sprcialistFileName(IsDeleted, ItemId, ResumeFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.ResumeFileId as ResumeFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Specialists as d left join dbo.Files as f on f.ItemId = d.ResumeFileId
		where d.ResumeFileId is not null and 
			  d.ResumeFileId > 0 and
			  f.IsDeleted = 0
	),
	specialistFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from sprcialistFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using specialistFileIds as S
	on S.ItemId = T.ParentId and 
	   1310 = T.ParentTypeId and --Specialist
	   14 = T.LinkType           --SpecialistAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1310, 14, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'PassportCopyFileId' ) 

begin
	with sprcialistFileName(IsDeleted, ItemId, ResumeFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.PassportCopyFileId as PassportCopyFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Specialists as d left join dbo.Files as f on f.ItemId = d.PassportCopyFileId
		where d.PassportCopyFileId is not null and 
			  d.PassportCopyFileId > 0 and
			  f.IsDeleted = 0
	),
	specialistFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from sprcialistFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using specialistFileIds as S
	on S.ItemId = T.ParentId and 
	   1310 = T.ParentTypeId and --Specialist
	   15 = T.LinkType           --SpecialistAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1310, 15, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'FileId' ) 

begin
	with directiveRecordFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.DirectivesRecords as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  d.ParentTypeId != 3 and -- MaintenanceCheck
			  f.IsDeleted = 0 and
			  f.FileSize is not null
	),
	directiveRecordFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from directiveRecordFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using directiveRecordFileIds as S
	on S.ItemId = T.ParentId and 
	   1260 = T.ParentTypeId and --DirectiveRecord
	   16 = T.LinkType           --DirectiveRecordAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1260, 16, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'FileId' ) 

begin
	with directiveRecordFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.DirectivesRecords as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  d.ParentTypeId = 3 and -- MaintenanceCheck
			  f.IsDeleted = 0 and
			  f.FileSize is not null
	),
	directiveRecordFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from directiveRecordFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using directiveRecordFileIds as S
	on S.ItemId = T.ParentId and 
	   1680 = T.ParentTypeId and --MaintenanceCheckRecord
	   17 = T.LinkType           --MaintenanceCheckRecordAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1680, 17, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Audits')
                    and c.name = 'FileId' ) 

begin
	with auditFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Audits as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0
	),
	auditFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from auditFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using auditFileIds as S
	on S.ItemId = T.ParentId and 
	   1080 = T.ParentTypeId and --Audit
	   18 = T.LinkType           --AuditAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1080, 18, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Procedures')
                    and c.name = 'CheckListFileId' ) 

begin
	with procedureFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.CheckListFileId as CheckListFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Procedures as d left join dbo.Files as f on f.ItemId = d.CheckListFileId
		where d.CheckListFileId is not null and 
			  d.CheckListFileId > 0 and
			  f.IsDeleted = 0
	),
	procedureFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from procedureFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using procedureFileIds as S
	on S.ItemId = T.ParentId and 
	   1840 = T.ParentTypeId and --Procedure
	   19 = T.LinkType           --ProcedureCheckListFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1840, 19, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end



----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Procedures')
                    and c.name = 'ProcedureFileId' ) 

begin
	with procedureFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.ProcedureFileId as ProcedureFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Procedures as d left join dbo.Files as f on f.ItemId = d.ProcedureFileId
		where d.ProcedureFileId is not null and 
			  d.ProcedureFileId > 0 and
			  f.IsDeleted = 0
	),
	procedureFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from procedureFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using procedureFileIds as S
	on S.ItemId = T.ParentId and 
	   1840 = T.ParentTypeId and --Procedure
	   20 = T.LinkType           --ProcedureFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1840, 20, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailLLPCategoryChangeRecords')
                    and c.name = 'FileId' ) 

begin
	with detailLLPFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.DetailLLPCategoryChangeRecords as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0
	),
	detailLLpFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from detailLLPFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using detailLLpFileIds as S
	on S.ItemId = T.ParentId and 
	   1200 = T.ParentTypeId and --DetailLLPCategoryChangeRecords
	   21 = T.LinkType           --DetailLLPCategoryChangeRecordAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1200, 21, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SupplierDocuments')
                    and c.name = 'FileId' ) 

begin
	with supplierDocFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.SupplierDocuments as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	supplierDocFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from supplierDocFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using supplierDocFileIds as S
	on S.ItemId = T.ParentId and 
	   2050 = T.ParentTypeId and --SupplierDocuments
	   22 = T.LinkType           --SupplierDocumentAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 2050, 22, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DamageCharts')
                    and c.name = 'FileID' ) 

begin
	with damageChartFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileID as FileID,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from Dictionaries.DamageCharts as d left join dbo.Files as f on f.ItemId = d.FileID
		where d.FileID is not null and 
			  d.FileID > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	damageChartFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from damageChartFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using damageChartFileIds as S
	on S.ItemId = T.ParentId and 
	   1180 = T.ParentTypeId and --DamageCharts
	   23 = T.LinkType           --DamageChartsAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1180, 23, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'FileId' ) 

begin
	with aircraftFlightFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.AircraftFlights as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	aircraftFlightFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from aircraftFlightFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using aircraftFlightFileIds as S
	on S.ItemId = T.ParentId and 
	   13 = T.ParentTypeId and --AircraftFlight
	   24 = T.LinkType           --AircraftFlightAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 13, 24, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end




----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DamageDocuments')
                    and c.name = 'FileID' ) 

begin
	with damageDocumentsFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileID as FileID,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.DamageDocuments as d left join dbo.Files as f on f.ItemId = d.FileID
		where d.FileID is not null and 
			  d.FileID > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	damageDocumentsFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from damageDocumentsFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using damageDocumentsFileIds as S
	on S.ItemId = T.ParentId and 
	   1185 = T.ParentTypeId and --DamageDocuments
	   26 = T.LinkType           --DamageDocFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1185, 26, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end



----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'InspectionDocumentsFileId' ) 
begin
	with directivesADFileNames(IsDeleted, ItemId, ADFileId, [FileName], FileSize)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.InspectionDocumentsFileId as InspectionDocumentsFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Directives as d left join dbo.Files as f on f.ItemId = d.InspectionDocumentsFileId
		where d.InspectionDocumentsFileId is not null and 
			  d.InspectionDocumentsFileId > 0 and
			  f.IsDeleted = 0
	),

	directivesADFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from directivesADFileNames as d
	)

	MERGE [dbo].[ItemsFilesLinks] as T
	using directivesADFileIds as S
	on S.ItemId = T.ParentId and 
	   1 = T.ParentTypeId and --Directive
	   27 = T.LinkType         --InspectionDocumentsFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1, 27, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go 


----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
                    and c.name = 'FileId' ) 

begin
	with PurchaseRequestsRecordsFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.PurchaseRequestsRecords as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	PurchaseRequestsRecordsFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from PurchaseRequestsRecordsFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using PurchaseRequestsRecordsFileIds as S
	on S.ItemId = T.ParentId and 
	   1860 = T.ParentTypeId and --PurchaseRequestsRecordsFileIds
	   28 = T.LinkType           --PurchaseRequestsRecordsFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1860, 28, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'FileId' ) 

begin
	with initialOrdersFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.InitialOrders as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	initialOrdersFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from initialOrdersFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using initialOrdersFileIds as S
	on S.ItemId = T.ParentId and 
	   1560 = T.ParentTypeId and --InitialOrders
	   29 = T.LinkType           --InitialOrdersAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1560, 29, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrder')
                    and c.name = 'FileId' ) 

begin
	with purchaseOrderFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.PurchaseOrder as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	purchaseOrderFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from purchaseOrderFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using purchaseOrderFileIds as S
	on S.ItemId = T.ParentId and 
	   1855 = T.ParentTypeId and --PurchaseOrder
	   30 = T.LinkType           --PurchaseOrdersAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1855, 30, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'FileId' ) 

begin
	with requestsForQuotationFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.RequestsForQuotation as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0 and 
			  f.FileSize is not null
	),
	requestsForQuotationFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from requestsForQuotationFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using requestsForQuotationFileIds as S
	on S.ItemId = T.ParentId and 
	   1900 = T.ParentTypeId and --RequestsForQuotation
	   31 = T.LinkType           --RequestsForQuotationAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1900, 31, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end


----------------------------------------------------------------------------------
if object_id('Dictionaries.ServiceTypes') is null

    create table Dictionaries.ServiceTypes (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) not null
		, FullName nvarchar(256)
	)
go


--Добавление колонок в таблицу Document
----------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'DepartmentId' ) 

	alter table dbo.Documents
    add DepartmentId int null 
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'RevisionValidTo' ) 

	alter table dbo.Documents
    add RevisionValidTo bit null 
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'RevisionDateValidTo' ) 

	alter table dbo.Documents
    add RevisionDateValidTo dateTime null 
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'RevisionNotify' ) 

	alter table dbo.Documents
    add RevisionNotify int null 
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Aboard' ) 

	alter table dbo.Documents
    add Aboard bit not null default (0)
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'IssueNumber' ) 

	alter table dbo.Documents
    add IssueNumber nvarchar(128) null 
go

--Изменение названия колонок в таблице Document
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'DateValidFrom' ) 

	exec sp_rename 'dbo.Documents.DateValidFrom', 'IssueDateValidFrom', 'COLUMN';
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ValidTo' ) 

	exec sp_rename 'dbo.Documents.ValidTo', 'IssueValidTo', 'COLUMN';
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'DateValidTo' ) 

	exec sp_rename 'dbo.Documents.DateValidTo', 'IssueDateValidTo', 'COLUMN';
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Notify' ) 

	exec sp_rename 'dbo.Documents.Notify', 'IssueNotify', 'COLUMN';
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'RevisionDate' ) 

	exec sp_rename 'dbo.Documents.RevisionDate', 'RevisionDateFrom', 'COLUMN';
go



----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'NomenсlatureId' ) 

	alter table dbo.Documents
    add NomenсlatureId int null 
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Location' ) 

begin
	-- Заполнение (Dictionaries.Nomenclatures) элементами из колонки Location таблицы dbo.Documents
	Declare @insert varchar(Max) = 'INSERT INTO Dictionaries.Nomenclatures(FullName, Name, DepartmentId)
									SELECT Distinct  Location, Location, -1
									FROM  Documents
									where Location is not null and Location != '''
	exec (@insert)

	--заполняем новую колонку dbo.Documents.NomenсlatureId соответствующими значениями из Dictionaries.Nomenclatures
	Declare @update varchar(Max) = 'update Documents
									SET NomenсlatureId  =  CASE WHEN (doc.Location IS NULL or doc.Location = '') THEN -1
																WHEN (doc.Location IS Not NULL) THEN (select ItemId from Dictionaries.Nomenclatures where doc.Location = FullName)
														   end
									FROM Documents as doc'

	exec (@update)
	
	--Удалить колонку dbo.Documents.Location
	alter table dbo.Documents
    drop column Location

	--Делаем колонку dbo.Documents.NomenсlatureId NOT NULL
	ALTER TABLE dbo.Documents
	ALTER COLUMN NomenсlatureId int NOT NULL
end
go

	
----------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ProlongationWayId' ) 

	alter table dbo.Documents
    add ProlongationWayId int null 
go


if exists ( select  *
				from    sys.columns c                        
				where   c.object_id = object_id('dbo.Documents')
						 and c.name = 'ProlongationWay' ) 
begin
	--заполняем новую колонку dbo.Documents.ProlongationWayId на основе значений из dbo.Documents.ProlongationWay
	Declare @update varchar(Max) = 'update Documents
									SET ProlongationWayId  =  CASE WHEN (doc.ProlongationWay = "Auto" or doc.ProlongationWay = "Automatic") THEN 1
																   WHEN (doc.ProlongationWay = "Manual" or doc.ProlongationWay = '' or doc.ProlongationWay IS NULL) THEN 2
															  end
									FROM Documents as doc'

	exec (@update)

	--Удалить колонку dbo.Documents.ProlongationWay
	alter table dbo.Documents
    drop column ProlongationWay

	
	--Делаем колонку dbo.Documents.NomenсlatureId NOT NULL
	ALTER TABLE dbo.Documents
	ALTER COLUMN ProlongationWayId int NOT NULL

end
go


----------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ServiceTypeId' ) 

	alter table dbo.Documents
    add ServiceTypeId int null 
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ServiceType' ) 

begin
	-- Заполнение (Dictionaries.ServiceTypes) элементами из колонки ServiceType таблицы dbo.Documents
	Declare @insert varchar(Max) = 'INSERT INTO Dictionaries.ServiceTypes(FullName, Name)
									SELECT Distinct  ServiceType, ServiceType
									FROM  Documents
									where ServiceType is not null and ServiceType != '''
	exec (@insert)

	--заполняем новую колонку dbo.Documents.ServiceTypeId соответствующими значениями из Dictionaries.ServiceType
	Declare @update varchar(Max) = 'update Documents
									SET ServiceTypeId  =  CASE WHEN (doc.ServiceType IS NULL or doc.ServiceType = '') THEN -1
													      WHEN (doc.ServiceType IS Not NULL) THEN (select ItemId from Dictionaries.ServiceTypes where doc.ServiceType = FullName)
									end
									FROM Documents as doc'

	exec (@update)

	--Удалить колонку dbo.Documents.ServiceType
	alter table dbo.Documents
    drop column ServiceType

	
	--Делаем колонку dbo.Documents.ServiceTypeId NOT NULL
	ALTER TABLE dbo.Documents
	ALTER COLUMN ServiceTypeId int NOT NULL
end
go

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailDirectives')
                    and c.name = 'MaintenanceDirectiveId' ) 

	alter table dbo.DetailDirectives
    drop column MaintenanceDirectiveId
go

----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailDirectives')
                    and c.name = 'Interval' ) 

	alter table dbo.DetailDirectives
    drop column Interval
go

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailDirectives')
                    and c.name = 'Notify' ) 

	alter table dbo.DetailDirectives
    drop column Notify
go



----------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ResponsibleOccupationId ' ) 

	alter table dbo.Documents
    add ResponsibleOccupationId  int not null 
	Default -1 
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Responsible ') 
begin

	DECLARE @ItemID int
	DECLARE @ShortName varchar(Max)
	DECLARE @CURSOR CURSOR

	/*Заполняем курсор*/
	SET @CURSOR  = CURSOR SCROLL
	FOR
	SELECT ItemID, ShortName from Dictionaries.Specializations

	/*Открываем курсор*/
	Open @CURSOR
	Fetch @CURSOR Into @ItemID, @ShortName
	WHILE @@FETCH_STATUS = 0
	
	begin
		Declare @update varchar(Max) = ('Update Documents 
									     SET ResponsibleOccupationId = '+Cast(@ItemID as varchar)+'
										 From Documents doc 
										 where doc.Responsible = '''+@ShortName+'''')
		exec(@update)
		Fetch Next From @CURSOR Into @ItemID, @ShortName
	end	
/*Закрываем курсор*/
Close @Cursor


	--Удалить колонку dbo.Documents.Responsible
	alter table dbo.Documents
    drop column Responsible
end
go


----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Specializations')
                    and c.name = 'DepartmentId' ) 

		alter table Dictionaries.Specializations
		add DepartmentId  int not null 
		Default -1 
go
----------------------------------------------------------------------------------
if not exists ( select  *
    from    sys.columns c                        
    where   c.object_id = object_id('Dictionaries.Specializations')
            and c.name = 'Level' ) 

		alter table Dictionaries.Specializations
		add Level int not null 
		Default 0 
go