
if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Component compliance')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Component compliance', 23)
go

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Component CRS Form')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Component CRS Form', 23)
go

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Shipping document')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Shipping document', 23)
go

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Work package')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Work package', 23)
go


if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Description' ) 

			ALTER TABLE Documents ALTER COLUMN Description nvarchar(Max);
go

--Components-----------------------------------------------------------------
begin
DECLARE @WpItemId int, @LinkItemId int, @Title nvarchar(MAX), @Description nvarchar(MAX)
DECLARE @ComponentParentType int = 5 /*Id типа компонента*/
DECLARE @LinkFileTypeId int = 10 /*Id типа файла*/
DECLARE @DocumentTypeId int = 23 /*Id типа документа(Technical records)*/
DECLARE @FileLinkTypeId int = 32 /*IncomingFile*/
DECLARE @DocumentSubTypeId int  /*Id сабтипа документа*/
DECLARE @DocumentId int  /*id нового документа*/
select @DocumentSubTypeId = ItemId from Dictionaries.DocumentSubType where Name = 'Shipping document'

DECLARE abc CURSOR FOR 
(select c.ItemId, 'P/N: '+c.PartNumber + ' S/N: ' + c.SerialNumber, c.Description, l.ItemId
		from dbo.Components as c
		left join ItemsFilesLinks l on c.ItemId = l.ParentId and l.ParentTypeId = @ComponentParentType
		left join dbo.Files as f on f.ItemId = l.FileId
 where c.IsDeleted = 0 and l.LinkType = @FileLinkTypeId and f.FileData is not null)

OPEN abc;
FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
WHILE (@@FETCH_STATUS = 0)
BEGIN

	begin
		Insert Into Documents(ParentId, ParentTypeId, SubTypeId, DocTypeId, IsClosed, ContractNumber, Description, ProlongationWayId)
		Values(@WpItemId, @ComponentParentType, @DocumentSubTypeId, @DocumentTypeId, 1, @Title, @Description, -1)
		SET @DocumentId = SCOPE_IDENTITY();

		Update ItemsFilesLinks set ParentId = @DocumentId, ParentTypeId = 1275, LinkType = @LinkFileTypeId where ItemId = @LinkItemId

	end

   FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
END
CLOSE abc;
DEALLOCATE abc;

end
go
-------------------------------------------------------------------------------------------------------------------------------------------------------
begin
DECLARE @WpItemId int, @LinkItemId int, @Title nvarchar(MAX), @Description nvarchar(MAX)
DECLARE @ComponentParentType int = 5 /*Id типа компонента*/
DECLARE @LinkFileTypeId int = 10 /*Id типа файла*/
DECLARE @DocumentTypeId int = 23 /*Id типа документа(Technical records)*/
DECLARE @FileLinkTypeId int = 8 /*FaaFormFile*/
DECLARE @DocumentSubTypeId int  /*Id сабтипа документа*/
DECLARE @DocumentId int  /*id нового документа*/
select @DocumentSubTypeId = ItemId from Dictionaries.DocumentSubType where Name = 'Component CRS Form'

DECLARE abc CURSOR FOR 
(select c.ItemId, 'P/N: '+c.PartNumber + ' S/N: ' + c.SerialNumber, c.Description, l.ItemId
		from dbo.Components as c
		left join ItemsFilesLinks l on c.ItemId = l.ParentId and l.ParentTypeId = @ComponentParentType
		left join dbo.Files as f on f.ItemId = l.FileId
 where c.IsDeleted = 0 and l.LinkType = @FileLinkTypeId and f.FileData is not null)

OPEN abc;
FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
WHILE (@@FETCH_STATUS = 0)
BEGIN

	begin
		Insert Into Documents(ParentId, ParentTypeId, SubTypeId, DocTypeId, IsClosed, ContractNumber, Description, ProlongationWayId)
		Values(@WpItemId, @ComponentParentType, @DocumentSubTypeId, @DocumentTypeId, 1, @Title, @Description, -1)
		SET @DocumentId = SCOPE_IDENTITY();

		Update ItemsFilesLinks set ParentId = @DocumentId, ParentTypeId = 1275, LinkType = @LinkFileTypeId where ItemId = @LinkItemId

	end

   FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
END
CLOSE abc;
DEALLOCATE abc;

end
go

--ComponentDirective
----------------------------------------------------------------------------------------------------------------------------------------------

begin
DECLARE @WpItemId int, @LinkItemId int, @Title nvarchar(MAX), @Description nvarchar(MAX)
DECLARE @ComponentDirectiveParentType int = 2 /*Id типа компонента*/
DECLARE @LinkFileTypeId int = 10 /*Id типа файла*/
DECLARE @DocumentTypeId int = 23 /*Id типа документа(Technical records)*/
DECLARE @FileLinkTypeId int = 8 /*FaaFormFile*/
DECLARE @DocumentSubTypeId int  /*Id сабтипа документа*/
DECLARE @DocumentId int  /*id нового документа*/
select @DocumentSubTypeId = ItemId from Dictionaries.DocumentSubType where Name = 'Component CRS Form'

DECLARE abc CURSOR FOR 
(select cd.ItemId, 'P/N: '+c.PartNumber + ' S/N: ' + c.SerialNumber, c.Description, l.ItemId 
		from dbo.ComponentDirectives as cd
		left join ItemsFilesLinks l on cd.ItemId = l.ParentId and l.ParentTypeId = @ComponentDirectiveParentType
		left join Components c on cd.ComponentId = c.ItemId
		left join dbo.Files as f on f.ItemId = l.FileId
 where cd.IsDeleted = 0 and l.LinkType = @FileLinkTypeId and f.FileData is not null and cd.ComponentId > 0)

OPEN abc;
FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
WHILE (@@FETCH_STATUS = 0)
BEGIN

	begin
		Insert Into Documents(ParentId, ParentTypeId, SubTypeId, DocTypeId, IsClosed, ContractNumber, Description, ProlongationWayId)
		Values(@WpItemId, @ComponentDirectiveParentType, @DocumentSubTypeId, @DocumentTypeId, 1, @Title, @Description, -1)
		SET @DocumentId = SCOPE_IDENTITY();

		Update ItemsFilesLinks set ParentId = @DocumentId, ParentTypeId = 1275, LinkType = @LinkFileTypeId where ItemId = @LinkItemId

	end

   FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId
END
CLOSE abc;
DEALLOCATE abc;

end
go

--WorkPackage
-----------------------------------------------------------------------------------------------------------------------------
begin
DECLARE @WpItemId int, @LinkItemId int, @Title nvarchar(MAX), @Description nvarchar(MAX), @WpClosingDate datetime
DECLARE @WpParentType int = 2499 /*Id типа рабочего пакета*/
DECLARE @LinkFileTypeId int = 10 /*Id типа файла*/
DECLARE @DocumentTypeId int = 23 /*Id типа документа*/
DECLARE @DocumentSubTypeId int  /*Id сабтипа документа*/
DECLARE @DocumentId int  /*id нового документа*/
select @DocumentSubTypeId = ItemId from Dictionaries.DocumentSubType where Name = 'Work package'

DECLARE abc CURSOR FOR 
(select w.ItemId, w.Title, w.Description, l.ItemId, w.ClosingDate
		from dbo.WorkPackages as w 
		left join ItemsFilesLinks l on w.ItemId = l.ParentId and l.ParentTypeId = @WpParentType
		left join dbo.Files as f on f.ItemId = l.FileId
 where w.IsDeleted = 0 and w.Status = 3 and f.FileData is not null)

OPEN abc;
FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId, @WpClosingDate
WHILE (@@FETCH_STATUS = 0)
BEGIN

	begin
		Insert Into Documents(ParentId, ParentTypeId, SubTypeId, DocTypeId, IsClosed, ContractNumber, Description, ProlongationWayId, IssueDateValidFrom)
		Values(@WpItemId, @WpParentType, @DocumentSubTypeId, @DocumentTypeId, 1, @Title, @Description, -1, @WpClosingDate)
		SET @DocumentId = SCOPE_IDENTITY();

		Update ItemsFilesLinks set ParentId = @DocumentId, ParentTypeId = 1275, LinkType = @LinkFileTypeId where ItemId = @LinkItemId

	end

   FETCH NEXT FROM abc INTO @WpItemId, @Title, @Description, @LinkItemId, @WpClosingDate
END
CLOSE abc;
DEALLOCATE abc;

end
go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Directive compliance')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Directive compliance', 23)
go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'SupplierId' ) 

	alter table dbo.Documents
    add SupplierId int not null default -1 
go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Supplier')
                    and c.name = 'SupplierClassId' ) 

	alter table dbo.Supplier
    add SupplierClassId int not null default -1 
go


---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'FromSupplierId' ) 

	alter table dbo.Components
    add FromSupplierId int not null default -1 
go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'FromSupplierReciveDate' ) 

	alter table dbo.Components
    add FromSupplierReciveDate datetime
go

---------------------------------------------------------------------------------------------------------------------

if object_id('dbo.ProductCost') is null

    create table dbo.ProductCost (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, SupplierId int
		, KitId int
		, ParentId int
		, ParentTypeId int
		, QtyIn float
		, UnitPrice float
		, TotalPrice float
		, ShipPrice float
		, SubTotal float
		, Tax float
		, Tax1 float
		, Tax2 float
		, Total float
		, CurrencyId int default -1

	)
go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Supplier')
                    and c.name = 'Subject' ) 

	alter table dbo.Supplier
    add Subject VARCHAR(MAX)

go

---------------------------------------------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'FromSupplierId' ) 

	alter table dbo.TransferRecords
    add FromSupplierId INT NOT NULL DEFAULT 0

GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'SupplierReceiptDate' ) 

	alter table dbo.TransferRecords
    add SupplierReceiptDate DATETIME 

GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'SupplierNotify' ) 

	alter table dbo.TransferRecords
    add SupplierNotify varbinary(21) 

GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'FromSpecialistId' ) 

	alter table dbo.TransferRecords
    add FromSpecialistId INT NOT NULL DEFAULT 0

GO





