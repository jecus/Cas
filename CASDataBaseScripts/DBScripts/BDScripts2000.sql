if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.Departments')
					and c.name = 'Address' ) 

	alter table Dictionaries.Departments
	add Address nvarchar (256) 
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.Departments')
					and c.name = 'Phone' ) 

	alter table Dictionaries.Departments
	add Phone nvarchar (256) 
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.Departments')
					and c.name = 'Fax' ) 

	alter table Dictionaries.Departments
	add Fax nvarchar (256) 
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.Departments')
					and c.name = 'Email' ) 

	alter table Dictionaries.Departments
	add Email nvarchar (256) 
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.Departments')
					and c.name = 'Website' ) 

	alter table Dictionaries.Departments
	add Website nvarchar (256) 
GO
