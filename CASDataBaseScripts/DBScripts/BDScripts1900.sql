if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'DesignationId' ) 

	alter table dbo.PurchaseOrders
	add DesignationId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'PayTermId' ) 

	alter table dbo.PurchaseOrders
	add PayTermId int not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'IncoTermId' ) 

	alter table dbo.PurchaseOrders
	add IncoTermId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'ShipCompanyId' ) 

	alter table dbo.PurchaseOrders
	add ShipCompanyId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'ShipTo' ) 

	alter table dbo.PurchaseOrders
	add ShipTo nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'CargoVolume' ) 

	alter table dbo.PurchaseOrders
	add CargoVolume nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'BruttoWeight' ) 

	alter table dbo.PurchaseOrders
	add BruttoWeight nvarchar (MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'NettoWeight' ) 

	alter table dbo.PurchaseOrders
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
