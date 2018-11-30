Update AircraftEquipments set AircraftId = -1 where AircraftId is Null
Alter Table AircraftEquipments Alter Column AircraftId int not null

Update AircraftFlights set ATLBID = -1 where ATLBID is Null
Alter Table AircraftFlights Alter Column ATLBID int not null

Update FlightNumbers set FlightType = -1 where FlightType is Null
Alter Table FlightNumbers Alter Column FlightType int not null

Update FlightNumberPeriods set FlightNumberId = -1 where FlightNumberId is Null
Alter Table FlightNumberPeriods Alter Column FlightNumberId int not null

Update Runups set FlightId = -1 where FlightId is Null
Alter Table Runups Alter Column FlightId int not null

Update EngineTimeInRegimeRecords set FlightId = -1 where FlightId is Null
Alter Table EngineTimeInRegimeRecords Alter Column FlightId int not null

Update Discrepancies set DirectiveId = -1 where DirectiveId is Null
Alter Table Discrepancies Alter Column DirectiveId int not null

Update AuditRecords set AuditId = -1 where AuditId is Null
Alter Table AuditRecords Alter Column AuditId int not null

Update TransferRecords set ParentID = -1 where ParentID is Null
Alter Table TransferRecords Alter Column ParentID int not null

Update Kits set ParentID = -1 where ParentID is Null
Alter Table Kits Alter Column ParentID int not null

Update KitSuppliers set KitId = -1 where KitId is Null
Alter Table KitSuppliers Alter Column KitId int not null

Update Cas3WorkPakageRecord set WorkPakageId = -1 where WorkPakageId is Null
Alter Table Cas3WorkPakageRecord Alter Column WorkPakageId int not null

Update FlightTripRecords set FlightPeriodId = -1 where FlightPeriodId is Null
Alter Table FlightTripRecords Alter Column FlightPeriodId int not null

Update ProductCost set ParentId = -1 where ParentId is Null
Alter Table ProductCost Alter Column ParentId int not null

Update [MaintenanceDirectives] set IsOperatorTask = 1 where IsOperatorTask is Null
Alter Table [MaintenanceDirectives] Alter Column IsOperatorTask bit not null

Update [MaintenanceDirectives] set ProgramIndicator = -1 where ProgramIndicator is Null
Alter Table [MaintenanceDirectives] Alter Column ProgramIndicator int not null

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'ShortName' ) 

	alter table dbo.Specialists
    add ShortName nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Supplier')
                    and c.name = 'AirCode' ) 

	alter table dbo.Supplier
    add AirCode nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Adress' ) 

	alter table dbo.Stores
    add Adress nvarchar(MAX)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Phone' ) 

	alter table dbo.Stores
    add Phone nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Email' ) 

	alter table dbo.Stores
    add Email nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Contact' ) 

	alter table dbo.Stores
    add Contact nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'DescRus' ) 

	alter table Dictionaries.AccessoryDescriptions
    add DescRus nvarchar(MAX)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'HTS' ) 

	alter table Dictionaries.AccessoryDescriptions
    add HTS nvarchar(MAX)  default ''
GO


if object_id('dbo.Users') is null

    create table dbo.Users (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , Name nvarchar(100)
        , Surname nvarchar(100)
        , Login nvarchar(100)
        , Password nvarchar(100)
	)
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'Priority' ) 

	alter table dbo.InitionalOrderRecords
    add Priority int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'TypeOfOperation' ) 

	alter table dbo.InitialOrders
    add TypeOfOperation int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CountryId' ) 

	alter table dbo.InitialOrders
    add CountryId int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipBy' ) 

	alter table dbo.InitialOrders
    add ShipBy int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'IncoTerm' ) 

	alter table dbo.InitialOrders
    add IncoTerm int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CarrierId' ) 

	alter table dbo.InitialOrders
    add CarrierId int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ApprovedById' ) 

	alter table dbo.InitialOrders
    add ApprovedById int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PublishedById' ) 

	alter table dbo.InitialOrders
    add PublishedById int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ClosedById' ) 

	alter table dbo.InitialOrders
    add ClosedById int  default -1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'RFQ' ) 

	alter table dbo.InitialOrders
    add RFQ nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'QR' ) 

	alter table dbo.InitialOrders
    add QR nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PO' ) 

	alter table dbo.InitialOrders
    add PO nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Invoice' ) 

	alter table dbo.InitialOrders
    add Invoice nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Weight' ) 

	alter table dbo.InitialOrders
    add Weight nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'DIMS' ) 

	alter table dbo.InitialOrders
    add DIMS nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipTo' ) 

	alter table dbo.InitialOrders
    add ShipTo nvarchar(MAX)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PickUp' ) 

	alter table dbo.InitialOrders
    add PickUp nvarchar(MAX)  default ''
GO



-----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'TypeOfOperation' ) 

	alter table dbo.RequestsForQuotation
    add TypeOfOperation int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'CountryId' ) 

	alter table dbo.RequestsForQuotation
    add CountryId int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ShipBy' ) 

	alter table dbo.RequestsForQuotation
    add ShipBy int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'IncoTerm' ) 

	alter table dbo.RequestsForQuotation
    add IncoTerm int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'CarrierId' ) 

	alter table dbo.RequestsForQuotation
    add CarrierId int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ApprovedById' ) 

	alter table dbo.RequestsForQuotation
    add ApprovedById int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PublishedById' ) 

	alter table dbo.RequestsForQuotation
    add PublishedById int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ClosedById' ) 

	alter table dbo.RequestsForQuotation
    add ClosedById int  default -1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'RFQ' ) 

	alter table dbo.RequestsForQuotation
    add RFQ nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'QR' ) 

	alter table dbo.RequestsForQuotation
    add QR nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PO' ) 

	alter table dbo.RequestsForQuotation
    add PO nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Invoice' ) 

	alter table dbo.RequestsForQuotation
    add Invoice nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Weight' ) 

	alter table dbo.RequestsForQuotation
    add Weight nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'DIMS' ) 

	alter table dbo.RequestsForQuotation
    add DIMS nvarchar(256)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ShipTo' ) 

	alter table dbo.RequestsForQuotation
    add ShipTo nvarchar(MAX)  default ''
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PickUp' ) 

	alter table dbo.RequestsForQuotation
    add PickUp nvarchar(MAX)  default ''
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'Priority' ) 

	alter table dbo.RequestForQuotationRecords
    add Priority int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'DefferedCategory' ) 

	alter table dbo.RequestForQuotationRecords
    add DefferedCategory int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'DestinationObjectId' ) 

	alter table dbo.RequestForQuotationRecords
    add DestinationObjectId int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'DestinationObjectType' ) 

	alter table dbo.RequestForQuotationRecords
    add DestinationObjectType int  default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'InitialReason' ) 

	alter table dbo.RequestForQuotationRecords
    add InitialReason int  default -1
GO