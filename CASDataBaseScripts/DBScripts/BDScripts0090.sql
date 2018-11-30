if object_id('Dictionaries.LocationsType') is null

    create table Dictionaries.LocationsType (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go

---------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Locations')
                    and c.name = 'LocationsTypeId' ) 

	alter table Dictionaries.Locations
    add LocationsTypeId int not null default -1
go

-------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'ReceivedSpecialistId' ) 

	alter table dbo.TransferRecords
    add ReceivedSpecialistId int default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'ReleasedSpecialistId' ) 

	alter table dbo.TransferRecords
    add ReleasedSpecialistId int default -1
go


-----------------------------------------------------------------
if exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '03')

			update Dictionaries.ATAChapter set FullName = 'SUPPORT EQUIPMENT' , ShortName = '0310' where ShortName = '03'
go


if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '01')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('01','MAINTENANCE POLICY')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '03')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('03','SUPPORT')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0320','SUPPORT MATERIALS')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0330','SUPPORT CHEMICAL PRODUCT')
go


-------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'QuantityInput' ) 

	alter table dbo.Components
    add QuantityInput float default 0 

	Declare @update varchar(Max) = 'update Components set QuantityInput = QuantityIn'
	exec(@update)
go


--------------------------------------------
if object_id('dbo.SpecialistsTraining') is null

    create table dbo.SpecialistsTraining (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , SpecialistId  int not null
        , TrainingId  int 
        , SupplierId  int 
        , ManHours  float 
        , Cost  float 
        , Remarks  nvarchar(MAX) 
        , HiddenRemark  nvarchar(MAX) 
        , Description  nvarchar(MAX) 
        , FormFileID  int
        , Threshold varbinary(200)
        , IsClosed bit

	)
go


--------------------------------------------
if object_id('dbo.MailRecords') is null

    create table dbo.MailRecords (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , DocTypeId  int 
        , DocClassId  int 
        , SupplierId  int 
        , MailNumber  nvarchar(128) 
        , ReferenceNumber  nvarchar(128) 
        , ReceiveMailDate  datetime
        , CreateMailRecordDate  datetime
        , PublishingDate  datetime
        , ClosingDate  datetime
        , Title  nvarchar(MAX) 
        , Remarks  nvarchar(MAX) 
        , Description nvarchar(MAX) 
        , MailFileId  int
        , IsClosed bit
		, DepartmentId  int
		, ResponsibleId  int
		, ExecutorId  int
		, NomenclatureId  int
		, LocationId  int
		, RevisionNotify  int
		, PerformeUpTo  bit
		, PerformeUpToDate  datetime 
		, ParentId  int
		, MailChatId  int
		, Status  int
	)
go


if object_id('dbo.MailChats') is null

    create table dbo.MailChats (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, SupplierFromId  int
		, SupplierToId  int
		, CreateDate  datetime
		, Description nvarchar(450)
	)
go
