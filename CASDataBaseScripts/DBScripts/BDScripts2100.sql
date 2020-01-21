if not exists ( select  *
			from    sys.columns c                        
			where   c.object_id = object_id('dbo.PurchaseRequestsRecords')
					and c.name = 'TransferInformationJSON' ) 

	alter table dbo.PurchaseRequestsRecords
	add TransferInformationJSON nvarchar(MAX)
GO