--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'UserType' ) 

	alter table dbo.Users
    add UserType INT not null default 1
GO


--------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PickUp' ) 

	alter table dbo.InitialOrders
    drop COLUMN  PickUp
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipTo' ) 

	alter table dbo.InitialOrders
    drop COLUMN  ShipTo
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'DIMS' ) 

	alter table dbo.InitialOrders
    drop COLUMN  DIMS
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Weight' ) 

	alter table dbo.InitialOrders
    drop COLUMN  Weight
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Invoice' ) 

	alter table dbo.InitialOrders
    drop COLUMN  Invoice
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PO' ) 

	alter table dbo.InitialOrders
    drop COLUMN  PO
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'QR' ) 

	alter table dbo.InitialOrders
    drop COLUMN  QR
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'RFQ' ) 

	alter table dbo.InitialOrders
    drop COLUMN  RFQ
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ApprovedById' ) 

	alter table dbo.InitialOrders
    drop COLUMN  ApprovedById
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CarrierId' ) 

	alter table dbo.InitialOrders
    drop COLUMN  CarrierId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'IncoTerm' ) 

	alter table dbo.InitialOrders
    drop COLUMN  IncoTerm
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipBy' ) 

	alter table dbo.InitialOrders
    drop COLUMN  ShipBy
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CountryId' ) 

	alter table dbo.InitialOrders
    drop COLUMN  CountryId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'TypeOfOperation' ) 

	alter table dbo.InitialOrders
    drop COLUMN  TypeOfOperation
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PublishedByUser' ) 

	alter table dbo.InitialOrders
    add PublishedByUser nvarchar(128) null 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CloseByUser' ) 

	alter table dbo.InitialOrders
    add CloseByUser nvarchar(128) null 
GO
