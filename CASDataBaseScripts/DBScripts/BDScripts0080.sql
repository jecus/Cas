if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'LLPLifeLengthCurrent' ) 

	alter table dbo.ComponentLLPCategoryData
    add LLPLifeLengthCurrent varbinary(50)
go


------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Information' ) 

	alter table dbo.Specialists
    add Information nvarchar(MAX)
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Education' ) 

	alter table dbo.Specialists
    add Education smallint not null Default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Location' ) 

	alter table dbo.Specialists
    add Location smallint not null Default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Status' ) 

	alter table dbo.Specialists
    add Status smallint not null Default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Position' ) 

	alter table dbo.Specialists
    add Position smallint not null Default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Sign' ) 

	alter table dbo.Specialists
    add Sign varbinary(MAX)
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'FamilyStatus' ) 

	alter table dbo.Specialists
    drop column FamilyStatus
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'FamilyStatus' ) 

	alter table dbo.Specialists
    add FamilyStatus smallint not null Default -1
go

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Citizenship' ) 

	alter table dbo.Specialists
    drop column Citizenship
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Citizenship' ) 

	alter table dbo.Specialists
    add Citizenship smallint not null Default -1
go


if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'PassportSeries' ) 

	alter table dbo.Specialists
    drop column PassportSeries
go

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'PassportNumber' ) 

	alter table dbo.Specialists
    drop column PassportNumber
go

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'DateOfIssue' ) 

	alter table dbo.Specialists
    drop column DateOfIssue
go

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'ExpirationDate' ) 

	alter table dbo.Specialists
    drop column ExpirationDate
go

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'AuthorityIssuedDocument' ) 

	alter table dbo.Specialists
    drop column AuthorityIssuedDocument
go

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'INN' ) 

	alter table dbo.Specialists
    drop column INN
go

------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Specializations')
                    and c.name = 'KeyPersonel' ) 

	alter table Dictionaries.Specializations
    add KeyPersonel bit not null default 0 

go


-----------------------------------------------------------
--Specialist
-----------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'PersonnelCategoryId' ) 

	alter table dbo.Specialists
    add PersonnelCategoryId int not null default -1
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'ClassNumber' ) 

	alter table dbo.Specialists
    add ClassNumber int not null default 0
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'ClassIssueDate' ) 

	alter table dbo.Specialists
    add ClassIssueDate datetime
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'GradeNumber' ) 

	alter table dbo.Specialists
    add GradeNumber int not null default 0
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'GradeIssueDate' ) 

	alter table dbo.Specialists
    add GradeIssueDate datetime
go

if object_id('dbo.SpecialistsLicense') is null

    create table dbo.SpecialistsLicense (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , Confirmation  bit not null DEFAULT 0
        , LicenseTypeID  int not null DEFAULT -1
        , AircraftTypeID  int not null DEFAULT 0 
		, SpecialistId int not null
	)
go

if object_id('dbo.SpecialistsCAA') is null

    create table dbo.SpecialistsCAA (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , NumberCAA nvarchar(25)
        , CAAId  int not null DEFAULT -1
        , CAAType  int not null DEFAULT 0
        , ValidTo  datetime not null
		, SpecialistLicenseId int not null
	)
go

if object_id('dbo.SpecialistsLicenseDetail') is null

    create table dbo.SpecialistsLicenseDetail (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Description nvarchar(MAX)
        , IssueDate  datetime not null
		, SpecialistLicenseId int not null
		, SpecialistId int not null
	)
go

if object_id('dbo.SpecialistsLicenseRating') is null

    create table dbo.SpecialistsLicenseRating (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , IssueDate  datetime not null
		, SpecialistLicenseId int not null
		, RightsId int not null
		, FunctionId int not null
	)
go

if object_id('dbo.SpecialistsInstrumentRating') is null

    create table dbo.SpecialistsInstrumentRating (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , IssueDate  datetime not null
		, SpecialistLicenseId int not null
		, IcaoId int not null
		, MC int not null
		, MV int not null
		, RVR int not null
		, TORVR int not null
	)
go


if object_id('dbo.SpecialistsLicenseRemark') is null

    create table dbo.SpecialistsLicenseRemark (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
        , IssueDate  datetime not null
		, RightsId int not null
		, RestrictionId int not null
		, SpecialistLicenseId int not null
		, SpecialistId int not null
	)
go


if object_id('Dictionaries.Restriction') is null

    create table Dictionaries.Restriction (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go

if object_id('Dictionaries.LicenseRemarkRights') is null

    create table Dictionaries.LicenseRemarkRights (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
	)
go

----------------------------------------------------------------------
if object_id('dbo.WorkPackageSpecialists') is null

    create table dbo.WorkPackageSpecialists (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, WorkPackageId int not null
		, SpecialistId int not null
	)
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackages')
                    and c.name = 'EmployeesRemark' ) 

	alter table dbo.WorkPackages
    add EmployeesRemark nvarchar(MAX)
go