
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'IsApplicability' ) 

	alter table dbo.MaintenanceDirectives
    add IsApplicability bit default 1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'IsApplicability' ) 

	alter table dbo.Directives
    add IsApplicability bit default 1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'IsOperatorTask' ) 

	alter table dbo.MaintenanceDirectives
    add IsOperatorTask bit default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ProgramIndicator' ) 

	alter table dbo.MaintenanceDirectives
    add ProgramIndicator int default -1
GO



if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'StcNo' ) 

	alter table dbo.Directives
    add StcNo nvarchar(256)
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'DamageClass' ) 

	alter table dbo.Directives
    add DamageClass int default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'CorrectiveAction' ) 

	alter table dbo.Directives
    add CorrectiveAction nvarchar(MAX)
GO


