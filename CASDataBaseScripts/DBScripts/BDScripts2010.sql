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
