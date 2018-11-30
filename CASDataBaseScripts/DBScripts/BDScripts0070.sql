if object_id('Dictionaries.AircraftOtherParameters') is null

    create table Dictionaries.AircraftOtherParameters (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) not null
		, FullName nvarchar(256)
	)
go


if object_id('dbo.AircraftEquipments') is null

    create table dbo.AircraftEquipments (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Description nvarchar(256)
		, AircraftId int
		, AircraftOtherParameter int DEFAULT -1
		, AircraftEquipmetType int not null DEFAULT 0
	)
go


---------------------------------------------------------
if object_id('Dictionaries.Locations') is null

    create table Dictionaries.Locations (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go

----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'QuantityIn' ) 

	alter table dbo.Components
    add QuantityIn int default 0 

	Declare @update varchar(Max) = 'update Components set QuantityIn = Quantity'
	exec(@update)
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'LocationId' ) 

	alter table dbo.Components
    add LocationId int null 
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'Location' ) 

begin
	-- Заполнение (Dictionaries.Nomenclatures) элементами из колонки Location таблицы dbo.Documents
	Declare @insert varchar(Max) = 'INSERT INTO Dictionaries.Locations(FullName, Name)
									SELECT Distinct  Location, Location, -1
									FROM  Components
									where Location is not null and Location != '''''
	exec (@insert)

	--заполняем новую колонку dbo.Documents.NomenсlatureId соответствующими значениями из Dictionaries.Nomenclatures
	Declare @update varchar(Max) = 'update Components
									SET LocationId  =  CASE WHEN (doc.Location IS NULL or doc.Location = '''') THEN -1
																WHEN (doc.Location IS Not NULL) THEN (select ItemId from Dictionaries.Locations where doc.Location = FullName)
														   end
									FROM Components as doc'

	exec (@update)
	
	--Удалить колонку dbo.Documents.Location
	alter table dbo.Components
    drop column Location

	--Делаем колонку dbo.Documents.NomenсlatureId NOT NULL
	ALTER TABLE dbo.Components
	ALTER COLUMN LocationId int NOT NULL
end
go

----------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'LocationId' ) 

	alter table dbo.Documents
    add LocationId int not null default -1 
go

----------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'Incoming' ) 

	alter table dbo.Components
    add Incoming bit not null default 0 

go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'Discrepancy' ) 

	alter table dbo.Components
    add Discrepancy nvarchar(250) 
go

----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'Discription' ) 

	alter table dbo.TransferRecords
    add Description nvarchar(250) 
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'ReasonId' ) 

	alter table dbo.TransferRecords
    add ReasonId  int not null Default -1 
go

--------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'State' ) 

	alter table dbo.TransferRecords
    add State int null Default -1 
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'State' ) 

begin

	--заполняем новую колонку dbo.Documents.ServiceTypeId соответствующими значениями из Dictionaries.ServiceType
	Declare @update varchar(Max) = 'update TransferRecords
									SET State  =  CASE WHEN (t.Position = ''In'') THEN 1
													   WHEN (t.Position = ''Serviceable'') THEN 2
													   WHEN (t.Position = ''Unserviceable'') THEN 3
													   WHEN (t.Position = ''Unknown'' or t.Position = '''') THEN -1

									end
									FROM TransferRecords as t'

	exec (@update)
end
go



---------------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'IsPool' ) 

	alter table dbo.Components
    add IsPool bit not null DEFAULT 0
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'IsDangerous' ) 

	alter table dbo.Components
    add IsDangerous bit not null DEFAULT 0
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'IsDangerous' ) 

	alter table Dictionaries.AccessoryDescriptions
    add IsDangerous bit not null DEFAULT 0
go


---------------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'ReplaceComponentId' ) 

	alter table dbo.TransferRecords
    add ReplaceComponentId int not null DEFAULT 0
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'IsReplaceComponentRemoved' ) 

	alter table dbo.TransferRecords
    add IsReplaceComponentRemoved bit not null DEFAULT 0
go