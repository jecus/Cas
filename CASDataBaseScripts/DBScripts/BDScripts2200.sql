if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Directives')
					and c.name = 'IsFindingControl' ) 

	alter table dbo.Directives
	add IsFindingControl bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsSBControl' ) 

	alter table dbo.MaintenanceDirectives
	add IsSBControl bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'Limitation' ) 

	alter table Dictionaries.AccessoryDescriptions
	add Limitation nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'Reason' ) 

	alter table Dictionaries.AccessoryDescriptions
	add Reason nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsRVSM' ) 

	alter table dbo.MaintenanceDirectives
	add IsRVSM bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsETOPS' ) 

	alter table dbo.MaintenanceDirectives
	add IsETOPS bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.ItemsRelations')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.ItemsRelations
	add AdditionalInformationJSON nvarchar(MAX)
GO

delete from dbo.ItemsRelations  where IsDeleted = 1
update dbo.ItemsRelations set AdditionalInformationJSON = '{}' where FirtsItemTypeId = 2 or SecondItemTypeId = 2

update  i set AdditionalInformationJSON = JSON_MODIFY(JSON_MODIFY(i.AdditionalInformationJSON, '$.Mpd', mpd.TaskCardNumber), '$.Component', c.PartNumber) 
from dbo.ItemsRelations i
inner join dbo.ComponentDirectives cd on cd.ItemId = i.FirstItemId 
inner join dbo.Components c on c.ItemId = cd.ComponentId
inner join dbo.MaintenanceDirectives mpd on mpd.ItemId = i.SecondItemId
where i.FirtsItemTypeId = 2

update  i set AdditionalInformationJSON = JSON_MODIFY(JSON_MODIFY(i.AdditionalInformationJSON, '$.Mpd', mpd.TaskCardNumber), '$.Component', c.PartNumber) 
from dbo.ItemsRelations i
inner join dbo.ComponentDirectives cd on cd.ItemId = i.SecondItemId 
inner join dbo.Components c on c.ItemId = cd.ComponentId
inner join dbo.MaintenanceDirectives mpd on mpd.ItemId = i.FirstItemId
where i.SecondItemTypeId = 2

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Components')
					and c.name = 'IsRVSM' ) 

	alter table dbo.Components
	add IsRVSM bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Components')
					and c.name = 'IsETOPS' ) 

	alter table dbo.Components
	add IsETOPS bit not null default 0
GO