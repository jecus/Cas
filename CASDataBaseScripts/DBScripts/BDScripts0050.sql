if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Remarks' ) 

	alter table dbo.Documents
    add Remarks nvarchar(MAX) null 
go