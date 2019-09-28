if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'DesignationId' ) 

	alter table dbo.PurchaseRequestsRecords
	add DesignationId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'PayTermId' ) 

	alter table dbo.PurchaseRequestsRecords
	add PayTermId int not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'IncoTermId' ) 

	alter table dbo.PurchaseRequestsRecords
	add IncoTermId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'ShipCompanyId' ) 

	alter table dbo.PurchaseRequestsRecords
	add ShipCompanyId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'ShipTo' ) 

	alter table dbo.PurchaseRequestsRecords
	add ShipTo nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'CargoVolume' ) 

	alter table dbo.PurchaseRequestsRecords
	add CargoVolume nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'BruttoWeight' ) 

	alter table dbo.PurchaseRequestsRecords
	add BruttoWeight nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'NettoWeight' ) 

	alter table dbo.PurchaseRequestsRecords
	add NettoWeight nvarchar (MAX) 
GO

------------------------------------------------------------------------------------

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.ComponentDirectives')
					and c.name = 'ExpiryDate' ) 

	alter table dbo.ComponentDirectives
	add ExpiryDate datetime2
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.ComponentDirectives')
					and c.name = 'ExpiryRemainNotify' ) 

	alter table dbo.ComponentDirectives
	add ExpiryRemainNotify varbinary(21)
GO

