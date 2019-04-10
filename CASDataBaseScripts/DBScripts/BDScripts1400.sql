--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.ActualStateRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.ActualStateRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

