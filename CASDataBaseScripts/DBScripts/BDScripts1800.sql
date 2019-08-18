if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'IsForbidden' ) 

	alter table Dictionaries.AccessoryDescriptions
	add IsForbidden bit not null default 0
GO