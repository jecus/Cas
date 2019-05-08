if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'DirectiveOrder' ) 

	alter table dbo.Directives
    add DirectiveOrder smallint not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'SupersedesId' ) 

	alter table dbo.Directives
    add SupersedesId int null
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'SupersededId' ) 

	alter table dbo.Directives
    add SupersededId int null 
GO

--------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Zone' ) 

	alter table dbo.Directives
    add Zone nvarchar(256) null 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Access' ) 

	alter table dbo.Directives
    add Access nvarchar(MAX) null 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Workarea' ) 

	alter table dbo.Directives
    add Workarea nvarchar(256) null 
GO