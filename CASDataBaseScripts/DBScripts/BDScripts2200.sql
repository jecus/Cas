if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'IsFindingControl' ) 

	alter table dbo.Directives
    add IsFindingControl bit default 0
GO