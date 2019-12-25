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

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.InitionalOrderRecords')
					and c.name = 'AirportCodeId' ) 

	alter table dbo.InitionalOrderRecords
	add AirportCodeId int not null default -1 
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.InitionalOrderRecords')
					and c.name = 'Reference' ) 

	alter table dbo.InitionalOrderRecords
	add Reference nvarchar (MAX)
GO

---------------------------------------------------------------------------

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'ShipTo' ) 

	alter table dbo.PurchaseOrders
	drop column ShipTo 
GO


if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'ShipToId' ) 

	alter table dbo.PurchaseOrders
	add ShipToId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'Net' ) 

	alter table dbo.PurchaseOrders
	add Net float not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'IncoTermRef' ) 

	alter table dbo.PurchaseOrders
	add IncoTermRef nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'StationId' ) 

	alter table dbo.PurchaseOrders
	add StationId int not null default -1
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'TrackingNo' ) 

	alter table dbo.PurchaseOrders
	add TrackingNo nvarchar(MAX)
GO

-----------------------------------------------------------------------------

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.InitialOrders')
					and c.name = 'AuthorId' ) 

	alter table dbo.InitialOrders
	add AuthorId int not null default -1
GO

---------------------------------------------------------------------------

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.InitialOrders')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.InitialOrders
	add AdditionalInformationJSON nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseOrders')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.PurchaseOrders
	add AdditionalInformationJSON nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.RequestsForQuotation')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.RequestsForQuotation
	add AdditionalInformationJSON nvarchar(MAX)
GO

-----------------------------------------------------------------------

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'EngineRef' ) 

	alter table Dictionaries.AccessoryDescriptions
	add EngineRef nvarchar (MAX)
GO

  insert into [ScatDBTest].[Dictionaries].[DocumentSubType](DocumentTypeId, Name, Corrector)
  values (10, 'IPC Ref', 1)


  ----------------------------------------------------------------------
GO  
	CREATE SEQUENCE InitialOrderSequence  
		START WITH 10000  INCREMENT BY 1 ;  
GO  

-------------------------------------------------------------------------

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.InitionalOrderRecords')
					and c.name = 'InitialReason' ) 

	alter table dbo.InitionalOrderRecords
	drop column InitialReason 
GO

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.RequestForQuotationRecords')
					and c.name = 'InitialReason' ) 
	alter table dbo.RequestForQuotationRecords 
	drop constraint DF__RequestFo__Initi__5E6BA490

	alter table dbo.RequestForQuotationRecords
	drop COLUMN  InitialReason
GO

--------------------------------------------------------------------------
if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.ActualStateRecords')) 
begin
	drop table Logs.ActualStateRecords
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.AircraftFlights')) 
begin
	drop table Logs.AircraftFlights
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Aircrafts')) 
begin
	drop table Logs.Aircrafts
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.ATLBs')) 
begin
	drop table Logs.ATLBs
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.ComponentDirectives')) 
begin
	drop table Logs.ComponentDirectives
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.ComponentPurchaseRequests')) 
begin
	drop table Logs.ComponentPurchaseRequests
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Components')) 
begin
	drop table Logs.Components
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.CorrectiveActions')) 
begin
	drop table Logs.CorrectiveActions
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.CRSs')) 
begin
	drop table Logs.CRSs
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Directives')) 
begin
	drop table Logs.Directives
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.DirectivesRecords')) 
begin
	drop table Logs.DirectivesRecords
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Discrepancies')) 
begin
	drop table Logs.Discrepancies
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.EngineConditions')) 
begin
	drop table Logs.EngineConditions
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.EngineeringOrderTasks')) 
begin
	drop table Logs.EngineeringOrderTasks
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.LandingGearCondition')) 
begin
	drop table Logs.LandingGearCondition
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.MaintenanceDirectives')) 
begin
	drop table Logs.MaintenanceDirectives
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.MaintenanceLimitations')) 
begin
	drop table Logs.MaintenanceLimitations
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.MaintenancePerformances')) 
begin
	drop table Logs.MaintenancePerformances
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.ModificationItems')) 
begin
	drop table Logs.ModificationItems
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.NonRoutineJobs')) 
begin
	drop table Logs.NonRoutineJobs
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Operators')) 
begin
	drop table Logs.Operators
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.OperatorsPositions')) 
begin
	drop table Logs.OperatorsPositions
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.PrimeDirectives')) 
begin
	drop table Logs.PrimeDirectives
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.PurchaseOrders')) 
begin
	drop table Logs.PurchaseOrders
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.RequestsForQuotation')) 
begin
	drop table Logs.RequestsForQuotation
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.RequisitionForms')) 
begin
	drop table Logs.RequisitionForms
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.Supplier')) 
begin
	drop table Logs.Supplier
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.TransferRecords')) 
begin
	drop table Logs.TransferRecords
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.WorkPackageRecords')) 
begin
	drop table Logs.WorkPackageRecords
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.WorkPackageRelations')) 
begin
	drop table Logs.WorkPackageRelations
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Logs.WorkPackages')) 
begin
	drop table Logs.WorkPackages
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Proxy.AircraftDirectives')) 
begin
	drop table Proxy.AircraftDirectives
end

if exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Proxy.Aircrafts')) 
begin
	drop table Proxy.Aircrafts
end

-------------------------------------------------------------------------------

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.PurchaseRequestsRecords
	add AdditionalInformationJSON nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'CostType' ) 

	alter table dbo.PurchaseRequestsRecords
	add CostType smallint not null default 1
GO