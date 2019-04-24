if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'PublishedById' ) 

	alter table dbo.PurchaseOrders
    add PublishedById int null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'ClosedById' ) 

	alter table dbo.PurchaseOrders
    add ClosedById int null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'PublishedByUser' ) 

	alter table dbo.PurchaseOrders
    add PublishedByUser nvarchar(128)null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'CloseByUser' ) 

	alter table dbo.PurchaseOrders
    add CloseByUser nvarchar(128)null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'Number' ) 

	alter table dbo.PurchaseOrders
    add Number nvarchar(128)null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
                    and c.name = 'CurrencyId' ) 

	alter table dbo.PurchaseRequestsRecords
    add CurrencyId int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'IsEffectivity' ) 

	alter table Dictionaries.AccessoryDescriptions
    add IsEffectivity nvarchar(MAX)null
GO
--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'UiType' ) 

	alter table dbo.Users
    add UiType binary not null default 0
GO