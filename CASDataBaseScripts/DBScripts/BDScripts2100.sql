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
	add IsExtension bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'Extension' ) 

	alter table dbo.MaintenanceDirectives
	add Extension float not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Cas3WorkPakageRecord')
					and c.name = 'IsClosed' ) 

	alter table dbo.Cas3WorkPakageRecord
	add IsClosed bit not null default 0
GO

------------------------------------------------------------------------------------

if object_id('dbo.WorkStations') is null

    create table dbo.WorkStations (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , StoreName varchar(256) null
		, Location varchar(MAX) null
		, OperatorId int null
		, Adress varchar(MAX) null
		, Phone varchar(256) null
		, Email varchar(256) null
		, Contact varchar(256) null
		, Remarks varchar(MAX) null
		, Corrector int NOT NULL
		, Updated datetime2(7) NOT NULL
	)
go