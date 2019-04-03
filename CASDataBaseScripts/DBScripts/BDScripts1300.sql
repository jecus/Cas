--------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Users')
                    and c.name = 'UserType' ) 

	alter table dbo.Users
    add UserType INT not null default 1
GO


--------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PickUp' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__PickU__4A64ABE3

	alter table dbo.InitialOrders
    drop COLUMN  PickUp
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipTo' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__ShipT__497087AA

	alter table dbo.InitialOrders
    drop COLUMN  ShipTo
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'DIMS' ) 

    alter table dbo.InitialOrders 
	drop constraint DF__InitialOrd__DIMS__487C6371

	alter table dbo.InitialOrders
    drop COLUMN  DIMS
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Weight' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__Weigh__47883F38

	alter table dbo.InitialOrders
    drop COLUMN  Weight
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'Invoice' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__Invoi__46941AFF

	alter table dbo.InitialOrders
    drop COLUMN  Invoice
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PO' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOrder__PO__459FF6C6

	alter table dbo.InitialOrders
    drop COLUMN  PO
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'QR' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOrder__QR__44ABD28D

	alter table dbo.InitialOrders
    drop COLUMN  QR
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'RFQ' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOrde__RFQ__43B7AE54

	alter table dbo.InitialOrders
    drop COLUMN  RFQ
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ApprovedById' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__Appro__40DB41A9

	alter table dbo.InitialOrders
    drop COLUMN  ApprovedById
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CarrierId' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__Carri__3FE71D70

	alter table dbo.InitialOrders
    drop COLUMN  CarrierId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'IncoTerm' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__IncoT__3EF2F937

	alter table dbo.InitialOrders
    drop COLUMN  IncoTerm
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'ShipBy' ) 

	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__ShipB__3DFED4FE

	alter table dbo.InitialOrders
    drop COLUMN  ShipBy
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CountryId' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__Count__3D0AB0C5

	alter table dbo.InitialOrders
    drop COLUMN  CountryId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'TypeOfOperation' ) 
	alter table dbo.InitialOrders 
	drop constraint DF__InitialOr__TypeO__3C168C8C

	alter table dbo.InitialOrders
    drop COLUMN  TypeOfOperation
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'PublishedByUser' ) 

	alter table dbo.InitialOrders
    add PublishedByUser nvarchar(128) null 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitialOrders')
                    and c.name = 'CloseByUser' ) 

	alter table dbo.InitialOrders
    add CloseByUser nvarchar(128) null 
GO
--------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'Remarks' ) 

	alter table dbo.InitionalOrderRecords
    add Remarks nvarchar(MAX) null 
GO
----------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PickUp' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__PickU__59A6EF73

	alter table dbo.RequestsForQuotation
    drop COLUMN  PickUp
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ShipTo' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__ShipT__58B2CB3A

	alter table dbo.RequestsForQuotation
    drop COLUMN  ShipTo
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'DIMS' ) 

    alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsFo__DIMS__57BEA701

	alter table dbo.RequestsForQuotation
    drop COLUMN  DIMS
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Weight' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__Weigh__56CA82C8

	alter table dbo.RequestsForQuotation
    drop COLUMN  Weight
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'Invoice' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__Invoi__55D65E8F

	alter table dbo.RequestsForQuotation
    drop COLUMN  Invoice
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PO' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsForQ__PO__54E23A56

	alter table dbo.RequestsForQuotation
    drop COLUMN  PO
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'QR' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsForQ__QR__53EE161D

	alter table dbo.RequestsForQuotation
    drop COLUMN  QR
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'RFQ' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsFor__RFQ__52F9F1E4

	alter table dbo.RequestsForQuotation
    drop COLUMN  RFQ
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ApprovedById' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__Appro__501D8539

	alter table dbo.RequestsForQuotation
    drop COLUMN  ApprovedById
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'CarrierId' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__Carri__4F296100

	alter table dbo.RequestsForQuotation
    drop COLUMN  CarrierId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'IncoTerm' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__IncoT__4E353CC7

	alter table dbo.RequestsForQuotation
    drop COLUMN  IncoTerm
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'ShipBy' ) 

	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__ShipB__4D41188E

	alter table dbo.RequestsForQuotation
    drop COLUMN  ShipBy
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'CountryId' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__Count__4C4CF455

	alter table dbo.RequestsForQuotation
    drop COLUMN  CountryId
GO

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'TypeOfOperation' ) 
	alter table dbo.RequestsForQuotation 
	drop constraint DF__RequestsF__TypeO__4B58D01C

	alter table dbo.RequestsForQuotation
    drop COLUMN  TypeOfOperation
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'PublishedByUser' ) 

	alter table dbo.RequestsForQuotation
    add PublishedByUser nvarchar(128) null 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestsForQuotation')
                    and c.name = 'CloseByUser' ) 

	alter table dbo.RequestsForQuotation
    add CloseByUser nvarchar(128) null 

--------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.RequestForQuotationRecords')
                    and c.name = 'Remarks' ) 

	alter table dbo.RequestForQuotationRecords
    add Remarks nvarchar(MAX) null 
GO