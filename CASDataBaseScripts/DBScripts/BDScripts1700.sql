if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'APUCalc' ) 

	alter table dbo.MaintenanceDirectives
    add APUCalc bit not null default 0
GO
------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'SBSubjects' ) 

	alter table dbo.MaintenanceDirectives
    add SBSubjects nvarchar(MAX) not null default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'AffectedBy' ) 

	alter table dbo.MaintenanceDirectives
    add AffectedBy int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Affects' ) 

	alter table dbo.MaintenanceDirectives
    add Affects int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Reason' ) 

	alter table dbo.MaintenanceDirectives
    add Reason int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Orders' ) 

	alter table dbo.MaintenanceDirectives
    add Orders int not null default -1
GO
