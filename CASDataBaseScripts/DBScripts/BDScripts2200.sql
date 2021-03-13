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