------------------------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Aircrafts')
                    and c.name = 'EngineUtilizationMethod' ) 
    
	alter table dbo.Aircrafts drop column EngineUtilizationMethod 
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Aircrafts')
                    and c.name = 'ApuUtizationPerFlightinMinutes' ) 

	alter table dbo.Aircrafts
    add ApuUtizationPerFlightinMinutes smallint null 
go

-----------------------------------------------------------------------------------

if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('dbo.Directives')
                        and c.name = 'NDTType' ) 
    
	alter table dbo.Directives
    add NDTType smallint null 
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'NonDestructiveTest' ) 
begin
	update dbo.Directives
	set NDTType = 1
	where NonDestructiveTest = 1

	update dbo.Directives
	set NDTType = 0
	where NonDestructiveTest = 0
end
go  

if exists ( select  *
			from    sys.default_constraints
			where   name = 'DF_Directives_NonDestructiveTest' ) 
	
	alter table dbo.Directives drop CONSTRAINT DF_Directives_NonDestructiveTest
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'NonDestructiveTest' ) 
	alter table dbo.Directives drop column NonDestructiveTest 
go 

alter table dbo.Directives alter column NDTType smallint not null 
go

---------------------------------------------------------------------------------------

if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('dbo.DetailDirectives')
                        and c.name = 'NDTType' ) 
    
	alter table dbo.DetailDirectives
    add NDTType smallint null 
go

update dbo.DetailDirectives
set NDTType = 0
where NDTType is null
go
 
alter table dbo.DetailDirectives alter column NDTType smallint not null 
go

---------------------------------------------------------------------------------------

if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('dbo.MaintenanceDirectives')
                        and c.name = 'NDTType' ) 
    
	alter table dbo.MaintenanceDirectives
    add NDTType smallint null 
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'NDT' ) 
begin
	update dbo.MaintenanceDirectives
	set NDTType = 1
	where NDT = 1

	update dbo.MaintenanceDirectives
	set NDTType = 0
	where NDT = 0

	update dbo.MaintenanceDirectives
	set NDTType = 0
	where NDTType is null
end
go  

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'NDT' ) 
	alter table dbo.MaintenanceDirectives drop column NDT 
go 

alter table dbo.MaintenanceDirectives alter column NDTType smallint not null 
go

-------------------------------------------------------------------------------------

if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('Template.Directives')
                        and c.name = 'NDTType' ) 
    
	alter table Template.Directives
    add NDTType smallint null 
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Directives')
                    and c.name = 'NonDestructiveTest' ) 
begin
	update Template.Directives
	set NDTType = 1
	where NonDestructiveTest = 1

	update Template.Directives
	set NDTType = 0
	where NonDestructiveTest = 0
end
go  

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Directives')
                    and c.name = 'NonDestructiveTest' ) 
	alter table Template.Directives drop column NonDestructiveTest 
go 

update Template.Directives
set NDTType = 0
where NDTType is null
go

alter table Template.Directives alter column NDTType smallint not null 
go

-------------------------------------------------------------------------------------

if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('Template.DetailDirectives')
                        and c.name = 'NDTType' ) 
    
	alter table Template.DetailDirectives
    add NDTType smallint null 
go

update Template.DetailDirectives
set NDTType = 0
where NDTType is null
go
 
alter table Template.DetailDirectives alter column NDTType smallint not null 
go
----------------------------------------------------------------------------------

if object_id('dbo.ItemsFilesLinks') is null

    create table dbo.ItemsFilesLinks (
          ItemId int IDENTITY PRIMARY KEY not null
        , IsDeleted  bit not null
        , ParentId int not null
        , ParentTypeId int not null
        , LinkType smallint not null
        , FileId int
	)
go

----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'ADFileId' ) 
begin
	with directivesADFileNames(IsDeleted, ItemId, ADFileId, [FileName], FileSize)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.ADFileId as ADFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Directives as d left join dbo.Files as f on f.ItemId = d.ADFileId
		where d.ADFileId is not null and 
			  d.ADFileId > 0 and
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
	   1 = T.LinkType         --ADFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1, 1, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go 

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'ServiceBulletinFileID' ) 
begin
	with directivesSBFileNames(IsDeleted, ItemId, SBFileId, [FileName], FileSize)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.ServiceBulletinFileID as SBFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Directives as d left join dbo.Files as f on f.ItemId = d.ServiceBulletinFileID
		where d.ServiceBulletinFileID is not null and 
			  d.ServiceBulletinFileID > 0 and
			  f.IsDeleted = 0
	),

	directivesSBFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from directivesSBFileNames as d
	)

	MERGE [dbo].[ItemsFilesLinks] as T
	using directivesSBFileIds as S
	on S.ItemId = T.ParentId and 
	   1 = T.ParentTypeId and --Directive
	   2 = T.LinkType         --SBFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1, 2, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'EngineeringOrderFileID' ) 
begin
	with directivesEOFileNames(IsDeleted, ItemId, EOFileId, [FileName], FileSize)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.EngineeringOrderFileID as EOFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Directives as d left join dbo.Files as f on f.ItemId = d.EngineeringOrderFileID
		where d.EngineeringOrderFileID is not null and 
			  d.EngineeringOrderFileID > 0 and
			  f.IsDeleted = 0
	),

	directivesEOFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from directivesEOFileNames as d
	)

	MERGE [dbo].[ItemsFilesLinks] as T
	using directivesEOFileIds as S
	on S.ItemId = T.ParentId and 
	   1 = T.ParentTypeId and --Directive
	   3 = T.LinkType         --EOFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1, 3, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и компонентами на основе имеющихся в БД компонентов и файлов FaaForm
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Details')
                    and c.name = 'FaaFormFileID' ) 

begin
	with detailsFaaFormFileName(IsDeleted, ItemId, FaaFormFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FaaFormFileID as FaaFormFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Details as d left join dbo.Files as f on f.ItemId = d.FaaFormFileID
		where d.FaaFormFileID is not null and 
			  d.FaaFormFileID > 0 and
			  f.IsDeleted = 0
	),
	detailsFaaFormFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from detailsFaaFormFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using detailsFaaFormFileIds as S
	on S.ItemId = T.ParentId and 
	   5 = T.ParentTypeId and --Detail
	   8 = T.LinkType         --FaaFormFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 5, 8, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и задачами по компонентам на основе имеющихся в БД задач по компонентам и файлов FaaForm
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailDirectives')
                    and c.name = 'FaaFormFileID' ) 

begin
	with detailDirectivesFaaFormFileName(IsDeleted, ItemId, FaaFormFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FaaFormFileID as FaaFormFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.DetailDirectives as d left join dbo.Files as f on f.ItemId = d.FaaFormFileID
		where d.FaaFormFileID is not null and 
			  d.FaaFormFileID > 0 and
			  f.IsDeleted = 0
	),
	detailDirectivesFaaFormFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from detailDirectivesFaaFormFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using detailDirectivesFaaFormFileIds as S
	on S.ItemId = T.ParentId and 
	   2 = T.ParentTypeId and --DetailDirectives
	   8 = T.LinkType         --FaaFormFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 2, 8, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов EngineeringOrder
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'EngineeringOrderFileId' ) 

begin
	with maintenanceDirectivesEngineeringOrderFileName(IsDeleted, ItemId, EngineeringOrderFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.EngineeringOrderFileId as EngineeringOrderFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.EngineeringOrderFileId
		where d.EngineeringOrderFileId is not null and 
			  d.EngineeringOrderFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesEngineeringOrderFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesEngineeringOrderFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesEngineeringOrderFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   3 = T.LinkType         --EngineeringOrderFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 3, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go


--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов MaintenanceManual
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MaintenanceManualFileId' ) 

begin
	with maintenanceDirectivesMaintenanceManualFileName(IsDeleted, ItemId, MaintenanceManualFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.MaintenanceManualFileId as MaintenanceManualFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.MaintenanceManualFileId
		where d.MaintenanceManualFileId is not null and 
			  d.MaintenanceManualFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesMaintenanceManualFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesMaintenanceManualFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesMaintenanceManualFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   4 = T.LinkType         --MaintenanceManualFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 4, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов MRBFile
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MRBFileId' ) 

begin
	with maintenanceDirectivesMRBFileName(IsDeleted, ItemId, MRBFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.MRBFileId as MRBFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.MRBFileId
		where d.MRBFileId is not null and 
			  d.MRBFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesMRBFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesMRBFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesMRBFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   6 = T.LinkType         --MRBFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 6, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов ServiceBulletin
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ServiceBulletinFileId' ) 

begin
	with maintenanceDirectivesServiceBulletinFileName(IsDeleted, ItemId, ServiceBulletinFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.ServiceBulletinFileId as ServiceBulletinFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.ServiceBulletinFileId
		where d.ServiceBulletinFileId is not null and 
			  d.ServiceBulletinFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesServiceBulletinFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesServiceBulletinFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesServiceBulletinFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   2 = T.LinkType         --ServiceBulletinFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 2, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов TaskCardNumber
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'TaskCardNumberFileId' ) 

begin
	with maintenanceDirectivesTaskCardNumberFileName(IsDeleted, ItemId, TaskCardNumberFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.TaskCardNumberFileId as TaskCardNumberFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.TaskCardNumberFileId
		where d.TaskCardNumberFileId is not null and 
			  d.TaskCardNumberFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesTaskCardNumberFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesTaskCardNumberFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesTaskCardNumberFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   7 = T.LinkType         --TaskCardNumberFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 7, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end
go

--Скрипт для создания линков между файлами и директивами на основе имеющихся в БД директив и файлов TaskNumberCheck
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'TaskNumberCheckFileId' ) 

begin
	with maintenanceDirectivesTaskNumberCheckFileName(IsDeleted, ItemId, TaskNumberCheckFileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.TaskNumberCheckFileId as TaskNumberCheckFileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.MaintenanceDirectives as d left join dbo.Files as f on f.ItemId = d.TaskNumberCheckFileId
		where d.TaskNumberCheckFileId is not null and 
			  d.TaskNumberCheckFileId > 0 and
			  f.IsDeleted = 0
	),
	maintenanceDirectivesTaskNumberCheckFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from maintenanceDirectivesTaskNumberCheckFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using maintenanceDirectivesTaskNumberCheckFileIds as S
	on S.ItemId = T.ParentId and 
	   14 = T.ParentTypeId and --MaintenanceDirectives
	   5 = T.LinkType         --TaskNumberCheckFileId
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 14, 5, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'ADFileId' ) 
begin
	with FileIds(FileId)
	AS 
	(
		select d.ADFileId as FileId 
		from dbo.Directives as d
		where d.ADFileId is not null and 
			  d.ADFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.ADFileID)

	    union

		select d.ServiceBulletinFileID as FileId
		from dbo.Directives as d
		where d.ServiceBulletinFileID is not null and 
			  d.ServiceBulletinFileID > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.ServiceBulletinFileID)
		
		union

		select d.EngineeringOrderFileID as FileId
		from dbo.Directives as d
		where d.EngineeringOrderFileID is not null and 
			  d.EngineeringOrderFileID > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.EngineeringOrderFileID)

		union

		select d.FaaFormFileID as FileId
		from dbo.Details as d
		where d.FaaFormFileID is not null and 
			  d.FaaFormFileID > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.FaaFormFileID)

		union

		select d.FaaFormFileID as FileId
		from dbo.DetailDirectives as d
		where d.FaaFormFileID is not null and 
			  d.FaaFormFileID > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.FaaFormFileID)

		union

		select d.EngineeringOrderFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.EngineeringOrderFileId is not null and 
			  d.EngineeringOrderFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.EngineeringOrderFileID)

		union

		select d.MaintenanceManualFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.MaintenanceManualFileId is not null and 
			  d.MaintenanceManualFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.MaintenanceManualFileId)

		union

		select d.MRBFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.MRBFileId is not null and 
			  d.MRBFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.MRBFileId)

		union

		select d.ServiceBulletinFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.ServiceBulletinFileId is not null and 
			  d.ServiceBulletinFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.ServiceBulletinFileId)

		union

		select d.TaskCardNumberFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.TaskCardNumberFileId is not null and 
			  d.TaskCardNumberFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.TaskCardNumberFileId)

		union

		select d.TaskNumberCheckFileId as FileId
		from dbo.MaintenanceDirectives as d
		where d.TaskNumberCheckFileId is not null and 
			  d.TaskNumberCheckFileId > 0 and
			  Not Exists (select *
			              from dbo.ItemsFilesLinks f
			              where f.FileId = d.TaskCardNumberFileId)
	)

	Delete From [dbo].Files
	where ItemID in (select FileId From FileIds)
end
go 

----------------------------------------------------------------------------------
if not exists ( select  *
                from    sys.columns c                        
                where   c.object_id = object_id('dbo.MaintenanceDirectives')
                        and c.name = 'KitsApplicable' ) 
    
	alter table dbo.MaintenanceDirectives
    add KitsApplicable bit null 
go

update dbo.MaintenanceDirectives
set KitsApplicable = 1
where KitsApplicable is null
go

alter table dbo.MaintenanceDirectives alter column KitsApplicable bit not null 
go
