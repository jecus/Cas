--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'UserType' ) 

	alter table dbo.Users
    add UserType INT not null default 1
GO
