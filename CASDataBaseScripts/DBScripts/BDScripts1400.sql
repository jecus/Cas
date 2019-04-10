--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.ActualStateRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.ActualStateRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftEquipments')
                    and c.name = 'Corrector' ) 

	alter table dbo.AircraftEquipments
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftEquipments')
                    and c.name = 'Updated' ) 

	alter table dbo.AircraftEquipments
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'Corrector' ) 

	alter table dbo.AircraftFlights
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'Updated' ) 

	alter table dbo.AircraftFlights
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Aircrafts')
                    and c.name = 'Corrector' ) 

	alter table dbo.Aircrafts
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Aircrafts')
                    and c.name = 'Updated' ) 

	alter table dbo.Aircrafts
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftSpecialEquipment')
                    and c.name = 'Corrector' ) 

	alter table dbo.AircraftSpecialEquipment
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftSpecialEquipment')
                    and c.name = 'Updated' ) 

	alter table dbo.AircraftSpecialEquipment
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftWorkerCategories')
                    and c.name = 'Corrector' ) 

	alter table dbo.AircraftWorkerCategories
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftWorkerCategories')
                    and c.name = 'Updated' ) 

	alter table dbo.AircraftWorkerCategories
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ATLBs')
                    and c.name = 'Corrector' ) 

	alter table dbo.ATLBs
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ATLBs')
                    and c.name = 'Updated' ) 

	alter table dbo.ATLBs
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AuditRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.AuditRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AuditRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.AuditRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Audits')
                    and c.name = 'Corrector' ) 

	alter table dbo.Audits
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Audits')
                    and c.name = 'Updated' ) 

	alter table dbo.Audits
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3JobCards')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3JobCards
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3JobCards')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3JobCards
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheck')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3MaintenanceCheck
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheck')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3MaintenanceCheck
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheckJobCards')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3MaintenanceCheckJobCards
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheckJobCards')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3MaintenanceCheckJobCards
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheckType')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3MaintenanceCheckType
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheckType')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3MaintenanceCheckType
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceWorkscope')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3MaintenanceWorkscope
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceWorkscope')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3MaintenanceWorkscope
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceWorkscopeApplicability')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3MaintenanceWorkscopeApplicability
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceWorkscopeApplicability')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3MaintenanceWorkscopeApplicability
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3Pors')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3Pors
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3Pors')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3Pors
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3RfQs')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3RfQs
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3RfQs')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3RfQs
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3WorkPakageRecord')
                    and c.name = 'Corrector' ) 

	alter table dbo.Cas3WorkPakageRecord
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3WorkPakageRecord')
                    and c.name = 'Updated' ) 

	alter table dbo.Cas3WorkPakageRecord
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CategoryRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.CategoryRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CategoryRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.CategoryRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'Corrector' ) 

	alter table dbo.ComponentDirectives
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'Updated' ) 

	alter table dbo.ComponentDirectives
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryChangeRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.ComponentLLPCategoryChangeRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryChangeRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.ComponentLLPCategoryChangeRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'Corrector' ) 

	alter table dbo.ComponentLLPCategoryData
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'Updated' ) 

	alter table dbo.ComponentLLPCategoryData
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentPurchaseRequests')
                    and c.name = 'Corrector' ) 

	alter table dbo.ComponentPurchaseRequests
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentPurchaseRequests')
                    and c.name = 'Updated' ) 

	alter table dbo.ComponentPurchaseRequests
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'Corrector' ) 

	alter table dbo.Components
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'Updated' ) 

	alter table dbo.Components
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentWorkInRegimeParams')
                    and c.name = 'Corrector' ) 

	alter table dbo.ComponentWorkInRegimeParams
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentWorkInRegimeParams')
                    and c.name = 'Updated' ) 

	alter table dbo.ComponentWorkInRegimeParams
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CorrectiveActions')
                    and c.name = 'Corrector' ) 

	alter table dbo.CorrectiveActions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CorrectiveActions')
                    and c.name = 'Updated' ) 

	alter table dbo.CorrectiveActions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CRSs')
                    and c.name = 'Corrector' ) 

	alter table dbo.CRSs
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.CRSs')
                    and c.name = 'Updated' ) 

	alter table dbo.CRSs
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DamageDocuments')
                    and c.name = 'Corrector' ) 

	alter table dbo.DamageDocuments
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DamageDocuments')
                    and c.name = 'Updated' ) 

	alter table dbo.DamageDocuments
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DamageSectors')
                    and c.name = 'Corrector' ) 

	alter table dbo.DamageSectors
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DamageSectors')
                    and c.name = 'Updated' ) 

	alter table dbo.DamageSectors
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DestinationObjectTypes')
                    and c.name = 'Corrector' ) 

	alter table dbo.DestinationObjectTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DestinationObjectTypes')
                    and c.name = 'Updated' ) 

	alter table dbo.DestinationObjectTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Corrector' ) 

	alter table dbo.Directives
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'Updated' ) 

	alter table dbo.Directives
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.DirectivesRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.DirectivesRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Corrector' ) 

	alter table dbo.Discrepancies
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Updated' ) 

	alter table dbo.Discrepancies
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Corrector' ) 

	alter table dbo.Documents
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'Updated' ) 

	alter table dbo.Documents
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EmployeeMedicalRecors')
                    and c.name = 'Corrector' ) 

	alter table dbo.EmployeeMedicalRecors
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EmployeeMedicalRecors')
                    and c.name = 'Updated' ) 

	alter table dbo.EmployeeMedicalRecors
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineAccelerationTime')
                    and c.name = 'Corrector' ) 

	alter table dbo.EngineAccelerationTime
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineAccelerationTime')
                    and c.name = 'Updated' ) 

	alter table dbo.EngineAccelerationTime
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineConditions')
                    and c.name = 'Corrector' ) 

	alter table dbo.EngineConditions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineConditions')
                    and c.name = 'Updated' ) 

	alter table dbo.EngineConditions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineeringOrderInformation')
                    and c.name = 'Corrector' ) 

	alter table dbo.EngineeringOrderInformation
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineeringOrderInformation')
                    and c.name = 'Updated' ) 

	alter table dbo.EngineeringOrderInformation
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineeringOrderTasks')
                    and c.name = 'Corrector' ) 

	alter table dbo.EngineeringOrderTasks
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineeringOrderTasks')
                    and c.name = 'Updated' ) 

	alter table dbo.EngineeringOrderTasks
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineTimeInRegimeRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.EngineTimeInRegimeRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EngineTimeInRegimeRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.EngineTimeInRegimeRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EventConditions')
                    and c.name = 'Corrector' ) 

	alter table dbo.EventConditions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EventConditions')
                    and c.name = 'Updated' ) 

	alter table dbo.EventConditions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Events')
                    and c.name = 'Corrector' ) 

	alter table dbo.Events
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Events')
                    and c.name = 'Updated' ) 

	alter table dbo.Events
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EventTypeRiskLevelChangeRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.EventTypeRiskLevelChangeRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.EventTypeRiskLevelChangeRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.EventTypeRiskLevelChangeRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Files')
                    and c.name = 'Corrector' ) 

	alter table dbo.Files
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Files')
                    and c.name = 'Updated' ) 

	alter table dbo.Files
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightCargoRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightCargoRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightCargoRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightCargoRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightCrews')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightCrews
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightCrews')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightCrews
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberAircraftModelRelations')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightNumberAircraftModelRelations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberAircraftModelRelations')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightNumberAircraftModelRelations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberAirportRelations')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightNumberAirportRelations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberAirportRelations')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightNumberAirportRelations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberCrewRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightNumberCrewRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberCrewRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightNumberCrewRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberPeriods')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightNumberPeriods
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberPeriods')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightNumberPeriods
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumbers')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightNumbers
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumbers')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightNumbers
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPassengerRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightPassengerRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPassengerRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightPassengerRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOps')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightPlanOps
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOps')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightPlanOps
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOpsRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightPlanOpsRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightPlanOpsRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightPlanOpsRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightTripRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightTripRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightTripRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightTripRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightTrips')
                    and c.name = 'Corrector' ) 

	alter table dbo.FlightTrips
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightTrips')
                    and c.name = 'Updated' ) 

	alter table dbo.FlightTrips
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Hangars')
                    and c.name = 'Corrector' ) 

	alter table dbo.Hangars
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Hangars')
                    and c.name = 'Updated' ) 

	alter table dbo.Hangars
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.HydraulicConditions')
                    and c.name = 'Corrector' ) 

	alter table dbo.HydraulicConditions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.HydraulicConditions')
                    and c.name = 'Updated' ) 

	alter table dbo.HydraulicConditions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Corrector' ) 

	alter table dbo.InitialOrders
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Updated' ) 

	alter table dbo.InitialOrders
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.InitionalOrderRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.InitionalOrderRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ItemsFilesLinks')
                    and c.name = 'Corrector' ) 

	alter table dbo.ItemsFilesLinks
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ItemsFilesLinks')
                    and c.name = 'Updated' ) 

	alter table dbo.ItemsFilesLinks
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ItemsRelations')
                    and c.name = 'Corrector' ) 

	alter table dbo.ItemsRelations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ItemsRelations')
                    and c.name = 'Updated' ) 

	alter table dbo.ItemsRelations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.JobCards')
                    and c.name = 'Corrector' ) 

	alter table dbo.JobCards
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.JobCards')
                    and c.name = 'Updated' ) 

	alter table dbo.JobCards
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.JobCardTasks')
                    and c.name = 'Corrector' ) 

	alter table dbo.JobCardTasks
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.JobCardTasks')
                    and c.name = 'Updated' ) 

	alter table dbo.JobCardTasks
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Kits')
                    and c.name = 'Corrector' ) 

	alter table dbo.Kits
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Kits')
                    and c.name = 'Updated' ) 

	alter table dbo.Kits
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.KitSuppliers')
                    and c.name = 'Corrector' ) 

	alter table dbo.KitSuppliers
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.KitSuppliers')
                    and c.name = 'Updated' ) 

	alter table dbo.KitSuppliers
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.KnowledgeModules')
                    and c.name = 'Corrector' ) 

	alter table dbo.KnowledgeModules
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.KnowledgeModules')
                    and c.name = 'Updated' ) 

	alter table dbo.KnowledgeModules
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.LandingGearCondition')
                    and c.name = 'Corrector' ) 

	alter table dbo.LandingGearCondition
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.LandingGearCondition')
                    and c.name = 'Updated' ) 

	alter table dbo.LandingGearCondition
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceChecksBindTaskRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceChecksBindTaskRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceChecksBindTaskRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceChecksBindTaskRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectiveBindComponentRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceDirectiveBindComponentRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectiveBindComponentRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceDirectiveBindComponentRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceDirectives
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceDirectives
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceLimitations')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceLimitations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceLimitations')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceLimitations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenancePerformances')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenancePerformances
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenancePerformances')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenancePerformances
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceProgramChangeRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceProgramChangeRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceProgramChangeRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceProgramChangeRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceSubChecks')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceSubChecks
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceSubChecks')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceSubChecks
    add Updated datetime2(7) not null default sysutcdatetime()
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceSubChecksRelation')
                    and c.name = 'Corrector' ) 

	alter table dbo.MaintenanceSubChecksRelation
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceSubChecksRelation')
                    and c.name = 'Updated' ) 

	alter table dbo.MaintenanceSubChecksRelation
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ModificationItems')
                    and c.name = 'Corrector' ) 

	alter table dbo.ModificationItems
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ModificationItems')
                    and c.name = 'Updated' ) 

	alter table dbo.ModificationItems
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ModuleRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.ModuleRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ModuleRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.ModuleRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MTOPCheck')
                    and c.name = 'Corrector' ) 

	alter table dbo.MTOPCheck
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MTOPCheck')
                    and c.name = 'Updated' ) 

	alter table dbo.MTOPCheck
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MTOPCheckRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.MTOPCheckRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MTOPCheckRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.MTOPCheckRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OAEStatus')
                    and c.name = 'Corrector' ) 

	alter table dbo.OAEStatus
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OAEStatus')
                    and c.name = 'Updated' ) 

	alter table dbo.OAEStatus
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OAEStatusRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.OAEStatusRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OAEStatusRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.OAEStatusRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OilConditions')
                    and c.name = 'Corrector' ) 

	alter table dbo.OilConditions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OilConditions')
                    and c.name = 'Updated' ) 

	alter table dbo.OilConditions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Operators')
                    and c.name = 'Corrector' ) 

	alter table dbo.Operators
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Operators')
                    and c.name = 'Updated' ) 

	alter table dbo.Operators
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OperatorsPositions')
                    and c.name = 'Corrector' ) 

	alter table dbo.OperatorsPositions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OperatorsPositions')
                    and c.name = 'Updated' ) 

	alter table dbo.OperatorsPositions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PrimeDirectives')
                    and c.name = 'Corrector' ) 

	alter table dbo.PrimeDirectives
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PrimeDirectives')
                    and c.name = 'Updated' ) 

	alter table dbo.PrimeDirectives
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ProcedureDocumentReferences')
                    and c.name = 'Corrector' ) 

	alter table dbo.ProcedureDocumentReferences
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ProcedureDocumentReferences')
                    and c.name = 'Updated' ) 

	alter table dbo.ProcedureDocumentReferences
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Procedures')
                    and c.name = 'Corrector' ) 

	alter table dbo.Procedures
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Procedures')
                    and c.name = 'Updated' ) 

	alter table dbo.Procedures
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ProductCost')
                    and c.name = 'Corrector' ) 

	alter table dbo.ProductCost
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ProductCost')
                    and c.name = 'Updated' ) 

	alter table dbo.ProductCost
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'Corrector' ) 

	alter table dbo.PurchaseOrders
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseOrders')
                    and c.name = 'Updated' ) 

	alter table dbo.PurchaseOrders
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequests')
                    and c.name = 'Corrector' ) 

	alter table dbo.PurchaseRequests
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequests')
                    and c.name = 'Updated' ) 

	alter table dbo.PurchaseRequests
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.PurchaseRequestsRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.PurchaseRequestsRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.QuotationCost')
                    and c.name = 'Corrector' ) 

	alter table dbo.QuotationCost
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.QuotationCost')
                    and c.name = 'Updated' ) 

	alter table dbo.QuotationCost
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.RequestForQuotationRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.RequestForQuotationRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.RequestRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.RequestRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Requests')
                    and c.name = 'Corrector' ) 

	alter table dbo.Requests
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Requests')
                    and c.name = 'Updated' ) 

	alter table dbo.Requests
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Corrector' ) 

	alter table dbo.RequestsForQuotation
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Updated' ) 

	alter table dbo.RequestsForQuotation
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequisitionForms')
                    and c.name = 'Corrector' ) 

	alter table dbo.RequisitionForms
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequisitionForms')
                    and c.name = 'Updated' ) 

	alter table dbo.RequisitionForms
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Runups')
                    and c.name = 'Corrector' ) 

	alter table dbo.Runups
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Runups')
                    and c.name = 'Updated' ) 

	alter table dbo.Runups
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SmsEventTypes')
                    and c.name = 'Corrector' ) 

	alter table dbo.SmsEventTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SmsEventTypes')
                    and c.name = 'Updated' ) 

	alter table dbo.SmsEventTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Corrector' ) 

	alter table dbo.Specialists
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Updated' ) 

	alter table dbo.Specialists
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsCAA')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsCAA
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsCAA')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsCAA
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsInstrumentRating')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsInstrumentRating
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsInstrumentRating')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsInstrumentRating
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicense')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsLicense
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicense')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsLicense
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseDetail')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsLicenseDetail
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseDetail')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsLicenseDetail
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseRating')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsLicenseRating
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseRating')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsLicenseRating
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseRemark')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsLicenseRemark
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsLicenseRemark')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsLicenseRemark
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsTraining')
                    and c.name = 'Corrector' ) 

	alter table dbo.SpecialistsTraining
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SpecialistsTraining')
                    and c.name = 'Updated' ) 

	alter table dbo.SpecialistsTraining
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'Corrector' ) 

	alter table dbo.StockComponentInfos
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'Updated' ) 

	alter table dbo.StockComponentInfos
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Corrector' ) 

	alter table dbo.Stores
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Stores')
                    and c.name = 'Updated' ) 

	alter table dbo.Stores
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Supplier')
                    and c.name = 'Corrector' ) 

	alter table dbo.Supplier
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Supplier')
                    and c.name = 'Updated' ) 

	alter table dbo.Supplier
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SupplierDocuments')
                    and c.name = 'Corrector' ) 

	alter table dbo.SupplierDocuments
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.SupplierDocuments')
                    and c.name = 'Updated' ) 

	alter table dbo.SupplierDocuments
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Temp_utilization')
                    and c.name = 'Corrector' ) 

	alter table dbo.Temp_utilization
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Temp_utilization')
                    and c.name = 'Updated' ) 

	alter table dbo.Temp_utilization
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Temp_Utilz')
                    and c.name = 'Corrector' ) 

	alter table dbo.Temp_Utilz
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Temp_Utilz')
                    and c.name = 'Updated' ) 

	alter table dbo.Temp_Utilz
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.TransferRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.TransferRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'Corrector' ) 

	alter table dbo.Users
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'Updated' ) 

	alter table dbo.Users
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.UsersPermissions')
                    and c.name = 'Corrector' ) 

	alter table dbo.UsersPermissions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.UsersPermissions')
                    and c.name = 'Updated' ) 

	alter table dbo.UsersPermissions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Vehicles')
                    and c.name = 'Corrector' ) 

	alter table dbo.Vehicles
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Vehicles')
                    and c.name = 'Updated' ) 

	alter table dbo.Vehicles
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkOrderRecords')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkOrderRecords
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkOrderRecords')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkOrderRecords
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkOrders')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkOrders
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkOrders')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkOrders
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackageRelations')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkPackageRelations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackageRelations')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkPackageRelations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackages')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkPackages
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackages')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkPackages
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackageSpecialists')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkPackageSpecialists
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkPackageSpecialists')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkPackageSpecialists
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkShops')
                    and c.name = 'Corrector' ) 

	alter table dbo.WorkShops
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.WorkShops')
                    and c.name = 'Updated' ) 

	alter table dbo.WorkShops
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.AccessoryDescriptions
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.AccessoryDescriptions
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AGWCategories')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.AGWCategories
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AGWCategories')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.AGWCategories
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AircraftOtherParameters')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.AircraftOtherParameters
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AircraftOtherParameters')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.AircraftOtherParameters
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AircraftsTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.AircraftsTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AircraftsTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.AircraftsTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Airports')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Airports
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Airports')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Airports
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AirportsCodes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.AirportsCodes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AirportsCodes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.AirportsCodes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ATAChapter')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.ATAChapter
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ATAChapter')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.ATAChapter
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.BiWeeklies')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.BiWeeklies
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.BiWeeklies')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.BiWeeklies
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ComponentsRecordsTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.ComponentsRecordsTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ComponentsRecordsTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.ComponentsRecordsTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ComponentsTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.ComponentsTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ComponentsTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.ComponentsTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.CruiseLevels')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.CruiseLevels
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.CruiseLevels')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.CruiseLevels
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DamageCharts')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DamageCharts
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DamageCharts')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DamageCharts
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DataEvents')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DataEvents
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DataEvents')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DataEvents
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DefferedCategories')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DefferedCategories
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DefferedCategories')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DefferedCategories
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Departments')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Departments
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Departments')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Departments
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DirectivesTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DirectivesTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DirectivesTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DirectivesTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DocumentOwnerTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DocumentOwnerTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DocumentOwnerTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DocumentOwnerTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DocumentSubType')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.DocumentSubType
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DocumentSubType')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.DocumentSubType
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EmployeeSubjects')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.EmployeeSubjects
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EmployeeSubjects')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.EmployeeSubjects
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventCategories')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.EventCategories
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventCategories')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.EventCategories
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventClasses')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.EventClasses
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventClasses')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.EventClasses
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.FlightNum')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.FlightNum
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.FlightNum')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.FlightNum
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.GoodStandarts
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.GoodStandarts
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Highlights')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Highlights
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Highlights')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Highlights
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LicenseRemarkRights')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.LicenseRemarkRights
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LicenseRemarkRights')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.LicenseRemarkRights
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LifeLimitCategories')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.LifeLimitCategories
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LifeLimitCategories')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.LifeLimitCategories
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Localities')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Localities
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Localities')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Localities
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Locations')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Locations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Locations')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Locations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LocationsType')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.LocationsType
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.LocationsType')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.LocationsType
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceChecksTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.MaintenanceChecksTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceChecksTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.MaintenanceChecksTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceJobCardSkills')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.MaintenanceJobCardSkills
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceJobCardSkills')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.MaintenanceJobCardSkills
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.MaintenanceTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.MaintenanceTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.MaintenanceTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Models')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Models
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Models')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Models
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Nomenclatures')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Nomenclatures
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Nomenclatures')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Nomenclatures
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.NonRoutineJobs')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.NonRoutineJobs
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.NonRoutineJobs')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.NonRoutineJobs
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.PositionsTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.PositionsTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.PositionsTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.PositionsTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.PrimeDirectivesTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.PrimeDirectivesTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.PrimeDirectivesTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.PrimeDirectivesTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Reasons')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Reasons
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Reasons')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Reasons
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Restriction')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Restriction
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Restriction')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Restriction
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.SchedulePeriods')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.SchedulePeriods
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.SchedulePeriods')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.SchedulePeriods
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ServiceTypes')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.ServiceTypes
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.ServiceTypes')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.ServiceTypes
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Specializations')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.Specializations
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.Specializations')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.Specializations
    add Updated datetime2(7) not null default sysutcdatetime()
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.TripName')
                    and c.name = 'Corrector' ) 

	alter table Dictionaries.TripName
    add Corrector INT not null default 1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.TripName')
                    and c.name = 'Updated' ) 

	alter table Dictionaries.TripName
    add Updated datetime2(7) not null default sysutcdatetime()
GO