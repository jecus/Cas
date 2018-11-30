if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ScheduleItem' ) 

	alter table dbo.MaintenanceDirectives
    add ScheduleItem nvarchar(256)
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ScheduleRef' ) 

	alter table dbo.MaintenanceDirectives
    add ScheduleRef nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ScheduleRevisionNum' ) 

	alter table dbo.MaintenanceDirectives
    add ScheduleRevisionNum nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ScheduleRevisionDate' ) 

	alter table dbo.MaintenanceDirectives
    add ScheduleRevisionDate datetime
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'ZoneArea' ) 

	alter table dbo.ComponentDirectives
    add ZoneArea nvarchar(256)
GO
---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'AccessDirective' ) 

	alter table dbo.ComponentDirectives
    add AccessDirective nvarchar(256)
GO
---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'AAM' ) 

	alter table dbo.ComponentDirectives
    add AAM nvarchar(256)
GO
---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'CMM' ) 

	alter table dbo.ComponentDirectives
    add CMM nvarchar(256)
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Combination' ) 

	alter table dbo.Specialists
    add Combination nvarchar(MAX)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOpsRecords')
                    and c.name = 'IsDispatcherEditLdg' ) 

	alter table dbo.FlightPlanOpsRecords
    add IsDispatcherEditLdg bit default 1
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOpsRecords')
                    and c.name = 'StatusId' ) 

	alter table dbo.FlightPlanOpsRecords
    add StatusId int not null default -1
GO


