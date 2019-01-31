if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'IdNumber' ) 

	alter table dbo.Documents
    add IdNumber nvarchar(128)
GO

--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'Reference' ) 

	alter table Dictionaries.AccessoryDescriptions
    add Reference nvarchar(128)
GO
