if object_id('dbo.EmployeeMedicalRecors') is null

    create table dbo.EmployeeMedicalRecors (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, ClassId INT DEFAULT 0
		, IssueDate DATETIME NOT NULL
		, Notify varbinary(21) 
		, Repeat varbinary(21) 
		, SpecialistId INT DEFAULT 0
		, Remarks nvarchar(Max) null
	)
GO

------------------------------------------------------------------------------------

if object_id('Dictionaries.EmployeeSubject') is null

    create table Dictionaries.EmployeeSubjects (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Name nvarchar(50) null
		, FullName nvarchar(256) not null
		, LicenceTypeId int DEFAULT -1
	)
GO

------------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsTraining')
                    and c.name = 'AircraftTypeID' ) 

	alter table dbo.SpecialistsTraining
    add AircraftTypeID int not null default -1 
GO

------------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsTraining')
                    and c.name = 'EmployeeSubjectID' ) 

	alter table dbo.SpecialistsTraining
    add EmployeeSubjectID int not null default -1 
GO

------------------------------------------------------------------------------------
if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Personnel Training')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Personnel Training', 23)
GO

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Medical Records')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Medical Records', 3)
GO

-----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsCAA')
                    and c.name = 'Notify' ) 

	alter table dbo.SpecialistsCAA
    add Notify varbinary(21) 

GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsCAA')
                    and c.name = 'IssueDate' ) 

	alter table dbo.SpecialistsCAA
    add IssueDate DATETIME 

GO

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Personnel License')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Personnel License', 1)
GO

------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicense')
                    and c.name = 'Notify' ) 

	alter table dbo.SpecialistsLicense
    add Notify varbinary(21) 

GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicense')
                    and c.name = 'IssueDate' ) 

	alter table dbo.SpecialistsLicense
    add IssueDate DATETIME 

GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicense')
                    and c.name = 'ValidToDate' ) 

	alter table dbo.SpecialistsLicense
    add ValidToDate DATETIME 

GO
