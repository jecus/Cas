---------------------------------------------------------------------------------------------------
--увеличивет поиск с 1340 на 46 чтений и время с 33мс до 5мс (следовательно компоненты грузятся не 3,5 секунды а 0,5)
CREATE NONCLUSTERED INDEX IX_TransferRecords_FindComponents
ON dbo.TransferRecords (DestinationObjectID,DestinationObjectType,ParentID,ParentType,IsDeleted);

---------------------------------------------------------------------------------------------------
CREATE NONCLUSTERED INDEX IX_ComponentDirectives_FindComponent ON [dbo].[ComponentDirectives]
(
	[ComponentId] ASC,
	[IsDeleted] ASC
)
INCLUDE ( 	[ItemID],
	[DirectiveType],
	[Threshold],
	[ManHours],
	[Remarks],
	[Cost],
	[Highlight],
	[KitRequired],
	[FaaFormFileID],
	[JobCardsID],
	[EOFileID],
	[HiddenRemarks],
	[IsClosed],
	[MPDTaskTypeId],
	[NDTType],
	[ZoneArea],
	[AccessDirective],
	[AAM],
	[CMM],
	[Corrector],
	[Updated],
	[ExpiryDate],
	[ExpiryRemainNotify],
	[IsExpiry])
GO
---------------------------------------------------------------------------------------------------