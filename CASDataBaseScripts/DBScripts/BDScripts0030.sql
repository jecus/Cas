--Скрипт для создания линков между файлами и NonRoutineJob на основе имеющихся в БД директив и файлов TaskNumberCheck
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.NonRoutineJobs')
                    and c.name = 'FileId' ) 


begin
	with NonRoutineJobsFile(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select n.IsDeleted as IsDeleted,
			   n.ItemId as ItemId, 
			   n.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from Dictionaries.NonRoutineJobs as n left join dbo.Files as f on f.ItemId = n.FileId
		where n.FileId is not null and 
			  n.FileId > 0 and
			  f.IsDeleted = 0
	),
	NonRoutineJobsFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select n.IsDeleted as IsDeleted,
			   n.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = n.[FileName] and f.FileSize = n.FileSize) as FileId
		from NonRoutineJobsFile as n
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using NonRoutineJobsFileIds as S
	on S.ItemId = T.ParentId and 
	   4 = T.ParentTypeId and --NRJ
	   9 = T.LinkType         --AttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 4, 9, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;

end

----------------------------------------------------------------------------------

Update dir
Set dir.ADType = CASE When (det.BaseDetailTypeId = 2) Then 5
					  When (det.BaseDetailTypeId = 3) Then 4
					  When (det.BaseDetailTypeId = 4) Then 0
					  When (det.BaseDetailTypeId = 6) Then 3
					  end
from Directives dir inner join Details det
on dir.DetailID = det.ItemId
where dir.ADType not in (1, 2)

----------------------------------------------------------------------------------
if object_id('dbo.ItemsRelations') is null

    create table dbo.ItemsRelations (
          ItemId int IDENTITY PRIMARY KEY not null
        , IsDeleted  bit not null
        , FirstItemId int not null
        , FirtsItemTypeId int not null
        , SecondItemId int not null
        , SecondItemTypeId int not null
        , RelationTypeId int not null

	)
go
	
----------------------------------------------------------------------------------
if object_id('Dictionaries.Departments') is null

    create table Dictionaries.Departments (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go



----------------------------------------------------------------------------------
if object_id('Dictionaries.Nomenclatures') is null

    create table Dictionaries.Nomenclatures (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, DepartmentId int not null
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go

----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'FileId' ) 

begin
	with documentsFileName(IsDeleted, ItemId, FileId, [FileName], FileSize)
	AS
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   d.FileId as FileId,
			   f.[FileName] as [FileName],
			   f.FileSize as FileSize 
		from dbo.Documents as d left join dbo.Files as f on f.ItemId = d.FileId
		where d.FileId is not null and 
			  d.FileId > 0 and
			  f.IsDeleted = 0
	),
	documentFileIds(IsDeleted, ItemId, FileId)
	AS 
	(
		select d.IsDeleted as IsDeleted,
			   d.ItemId as ItemId, 
			   (select top 1 ItemId 
				from dbo.Files f
				where f.[FileName] = d.[FileName] and f.FileSize = d.FileSize) as FileId
		from documentsFileName as d
	)
	MERGE [dbo].[ItemsFilesLinks] as T
	using documentFileIds as S
	on S.ItemId = T.ParentId and 
	   1275 = T.ParentTypeId and --Document
	   10 = T.LinkType         --DocumentAttachedFile
	WHEN NOT MATCHED BY TARGET
	THEN INSERT(IsDeleted, ParentId, ParentTypeId, LinkType, FileId) VALUES (0, S.ItemId, 1275, 10, S.FileId)
	WHEN MATCHED 
	THEN UPDATE SET T.IsDeleted = S.IsDeleted, T.FileId = S.FileId;
end