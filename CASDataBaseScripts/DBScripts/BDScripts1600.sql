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