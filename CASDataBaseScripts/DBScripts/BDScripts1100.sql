if object_id('dbo.QuotationCost') is null

    create table dbo.QuotationCost (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , CostNew float not null
        , ProductID int not null
        , SupplierId int not null
        , QuotationId int not null 
        , CostServisible float not null 
        , CostOverhaul float not null 
        , CurrencyId int not null 
	)
go



if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Privy' ) 

	alter table dbo.Documents
    add Privy bit  not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LocationsType')
                    and c.name = 'DepartmentId' ) 

	alter table Dictionaries.LocationsType
    add DepartmentId int  not null default -1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Aircrafts')
                    and c.name = 'APUFH' ) 

	alter table dbo.Aircrafts
    add APUFH float  not null default 0
GO


alter table Dictionaries.AccessoryDescriptions alter column Description nvarchar(MAX)
go

alter table Dictionaries.AccessoryDescriptions alter column Remarks nvarchar(MAX)
go
