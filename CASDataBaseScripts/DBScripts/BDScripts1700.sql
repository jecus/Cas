if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'APUCalc' ) 

	alter table dbo.MaintenanceDirectives
    add APUCalc bit not null default 0
GO
