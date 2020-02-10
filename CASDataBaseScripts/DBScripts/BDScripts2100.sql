if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'TransferInformationJSON' ) 

	alter table dbo.PurchaseRequestsRecords
	add TransferInformationJSON nvarchar(MAX)
GO

delete FROM dbo.Cas3MaintenanceCheck;

-------------------------------------------------------------------------------------

delete  FROM dbo.WorkPackages where IsDeleted = 1;

delete  FROM dbo.Aircrafts where IsDeleted = 1;

delete  FROM dbo.WorkPackages where ParentId not in (SELECT ItemId FROM dbo.Aircrafts);



if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsExtension' ) 

	alter table dbo.MaintenanceDirectives
	add IsExtension bit default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'Extension' ) 

	alter table dbo.MaintenanceDirectives
	add Extension float not null default 0
GO