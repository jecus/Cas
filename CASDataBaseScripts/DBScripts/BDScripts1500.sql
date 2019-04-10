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