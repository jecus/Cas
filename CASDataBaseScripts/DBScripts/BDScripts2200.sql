if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Directives')
					and c.name = 'IsFindingControl' ) 

	alter table dbo.Directives
	add IsFindingControl bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsSBControl' ) 

	alter table dbo.MaintenanceDirectives
	add IsSBControl bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'Limitation' ) 

	alter table Dictionaries.AccessoryDescriptions
	add Limitation nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
					and c.name = 'Reason' ) 

	alter table Dictionaries.AccessoryDescriptions
	add Reason nvarchar(MAX)
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsRVSM' ) 

	alter table dbo.MaintenanceDirectives
	add IsRVSM bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.MaintenanceDirectives')
					and c.name = 'IsETOPS' ) 

	alter table dbo.MaintenanceDirectives
	add IsETOPS bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.ItemsRelations')
					and c.name = 'AdditionalInformationJSON' ) 

	alter table dbo.ItemsRelations
	add AdditionalInformationJSON nvarchar(MAX)
GO

delete from dbo.ItemsRelations  where IsDeleted = 1
update dbo.ItemsRelations set AdditionalInformationJSON = '{}' where FirtsItemTypeId = 2 or SecondItemTypeId = 2

update  i set AdditionalInformationJSON = JSON_MODIFY(JSON_MODIFY(i.AdditionalInformationJSON, '$.Mpd', mpd.TaskCardNumber), '$.Component', c.PartNumber) 
from dbo.ItemsRelations i
inner join dbo.ComponentDirectives cd on cd.ItemId = i.FirstItemId 
inner join dbo.Components c on c.ItemId = cd.ComponentId
inner join dbo.MaintenanceDirectives mpd on mpd.ItemId = i.SecondItemId
where i.FirtsItemTypeId = 2

update  i set AdditionalInformationJSON = JSON_MODIFY(JSON_MODIFY(i.AdditionalInformationJSON, '$.Mpd', mpd.TaskCardNumber), '$.Component', c.PartNumber) 
from dbo.ItemsRelations i
inner join dbo.ComponentDirectives cd on cd.ItemId = i.SecondItemId 
inner join dbo.Components c on c.ItemId = cd.ComponentId
inner join dbo.MaintenanceDirectives mpd on mpd.ItemId = i.FirstItemId
where i.SecondItemTypeId = 2

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Components')
					and c.name = 'IsRVSM' ) 

	alter table dbo.Components
	add IsRVSM bit not null default 0
GO

if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.Components')
					and c.name = 'IsETOPS' ) 

	alter table dbo.Components
	add IsETOPS bit not null default 0
GO



-----------------------------------------------------------------------INDEX------------------------------------------------------------
CREATE NONCLUSTERED INDEX [IX_IsBaseComp_Deleted] ON [dbo].[Components]
(
	[IsDeleted] ASC,
	[IsBaseComponent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_ComponentId_Deleted] ON [dbo].[MaintenanceDirectives]
(
	[IsDeleted] ASC,
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_ParentType] ON [dbo].[ItemsFilesLinks]  ( [ParentTypeId] ) 
INCLUDE ( [IsDeleted],[ParentId],[LinkType],[FileId],[Corrector],[Updated] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_ParentId_ParentType_DestObjType] ON [dbo].[TransferRecords]
(
	[IsDeleted] ASC,
	[ParentType] ASC,
	[DestinationObjectType] ASC,
	[DestinationObjectID] ASC,
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_ParentTypeId_ParentId_Deleted] ON [dbo].[Kits]
(
	[IsDeleted] ASC,
	[ParentTypeId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_IsDeleted_ParentTypeId_AccessoryDescriptionId] ON [dbo].[Kits]  
(   [IsDeleted],
	[ParentTypeId],
	[AccessoryDescriptionId] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_DirectiveType_Deleted] ON [dbo].[Directives]  
( [IsDeleted],[DirectiveType] , [Title] ) INCLUDE ( [ComponentId] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



CREATE NONCLUSTERED INDEX [IX_DirectiveType_Deleted(Title)] ON [dbo].[Directives]  
( [IsDeleted],[DirectiveType],[ComponentId] ) INCLUDE ( [Title] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_sBaseComp]
ON [dbo].[Components]  ( [IsBaseComponent] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_ComponentId_Deleted] 
ON [dbo].[ComponentLLPCategoryData]  ( [IsDeleted],[ComponentId] ) 
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted] 
ON [dbo].[ComponentLLPCategoryData]  ( [IsDeleted] ) 
INCLUDE ( [LLPCategoryId],[LLPLifeLength],[LLPLifeLimit],[Notify],[ComponentId],[LLPLifeLengthCurrent],[LLPLifeLengthForDate],[Date],[Corrector],[Updated] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_AircraftId_Deleted] ON [dbo].[ATLBs]
(
	[IsDeleted] ASC,
	[AircraftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_AtlbId_Deleted] ON [dbo].[AircraftFlights]
(
	[IsDeleted] ASC,
	[ATLBID] ASC
)
INCLUDE([ItemId],[AircraftId],[FlightNo],[Remarks],[FlightDate],[StationFrom],[StationTo],[DelayTime],[DelayReasonId],[OutTime],[InTime],[TakeOffTime],[LDGTime],[NightTime],[CRSID],[FileID],[Tanks],[Fluids],[EnginesGeneralCondition],[Highlight],[Correct],[Reference],[Cycles],[PageNo],[FlightType],[Level],[Distance],[DistanceMeasure],[TakeOffWeight],[AlignmentBefore],[AlignmentAfter],[FlightCategory],[AtlbRecordType],[FlightAircraftCode],[CancelReasonId],[StationFromId],[StationToId],[FlightNumber],[Corrector],[Updated])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_CompId_Deleted] ON [dbo].[ComponentDirectives]
(
	[IsDeleted] ASC,
	[ComponentId] ASC
)
INCLUDE([ItemID],[DirectiveType],[Threshold],[ManHours],[Remarks],[Cost],[Highlight],[KitRequired],[FaaFormFileID],[JobCardsID],[EOFileID],[HiddenRemarks],[IsClosed],[MPDTaskTypeId],[NDTType],[ZoneArea],[AccessDirective],[AAM],[CMM],[Corrector],[Updated],[ExpiryDate],[ExpiryRemainNotify],[IsExpiry]) 
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



CREATE NONCLUSTERED INDEX [IX_ParentTypeId_1] ON [dbo].[TransferRecords]  ( [ParentType] ) INCLUDE ( [ParentID],[DestinationObjectID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



 CREATE NONCLUSTERED INDEX [IX_ParentTypeId_2] ON [dbo].[TransferRecords]  ( [ParentType],[DestinationObjectID] ) INCLUDE ( [ParentID] )
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[Discrepancies]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[EngineConditions]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[LandingGearCondition]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[OilConditions]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[FlightCargoRecords]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[FlightPassengerRecords]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[Runups]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[EngineTimeInRegimeRecords]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[EngineAccelerationTime]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted] ON [dbo].[CRSs]  ( [IsDeleted])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[FlightCrews]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_Deleted_FlightId] ON [dbo].[HydraulicConditions]  ( [IsDeleted],[FlightID] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_AircraftId_Deleted] ON [dbo].[AircraftFlights]  ( [IsDeleted],[AircraftId] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_DiscrepancyID] ON [dbo].[CorrectiveActions]  ( [DiscrepancyID] ) INCLUDE ( [IsDeleted],[Description],[ShortDescription],[ADDNo],[IsClosed],[PartNumberOff],[SerialNumberOff],[PartNumberOn],[SerialNumberOn],[CRSID],[Corrector],[Updated] )
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_ParentId_Deleted] ON [dbo].[WorkPackages]
(
	[IsDeleted] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_WPId_WPRId_Deleted] ON [dbo].[Cas3WorkPakageRecord]
(
	[isDeleted] ASC,
	[WorkPakageId] ASC,
	[WorkPackageItemType] ASC
)
INCLUDE([ItemId],[DirectivesId],[PerfNumFromStart],[PerfNumFromRecord],[FromRecordId],[JobCardNumber],[ParentCheckId],[GroupNumber],[Corrector],[Updated],[IsClosed]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_RunUp_FlightId] ON [dbo].[Runups]  ( [FlightId] ) INCLUDE ( [IsDeleted],[StartTime],[RunUpType],[RunUpPhase],[RunUpCondition],[EndTime],[EndPhase],[ShutDownReasonId],[ShutDownType],[LandTime],[AirTime],[RecordDate],[OnLifelength],[BaseComponentId],[Corrector],[Updated] )
GO

CREATE NONCLUSTERED INDEX [IX_ComponentId_Deleted] ON [dbo].[ActualStateRecords]  ( [IsDeleted],[ComponentId] ) INCLUDE ( [FlightRegimeId],[Remarks],[OnLifelength],[RecordDate],[WorkRegimeTypeId],[Corrector],[Updated] )
GO

CREATE NONCLUSTERED INDEX [IX_ParentId_Deleted] ON [dbo].[TransferRecords]  
( [IsDeleted],[ParentID] ) INCLUDE ( [ParentType],[FromAircraftID],[FromStoreID],[DestinationObjectID],[DestinationObjectType],[ConsumableId],[TransferDate],[DestConfirmTransferDate],[WorkPackageID],[PerformanceNum],[Remarks],[Reference],[PODR],[DODR],[Position],[FromBaseComponentID],[Description],[ReasonId],[State],[ReplaceComponentId],[IsReplaceComponentRemoved],[ReceivedSpecialistId],[ReleasedSpecialistId],[FromSupplierId],[SupplierReceiptDate],[SupplierNotify],[FromSpecialistId],[PreConfirmTransfer],[Corrector],[Updated] )
GO