if object_id('dbo.MTOPCheck') is null

    create table dbo.MTOPCheck (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , Name nvarchar(150)
        , ParentAircraftId int not null
        , CheckTypeId int not null
        , Thresh varbinary(MAX) 
        , Repeat varbinary(MAX) 
        , Notify varbinary(MAX) 
	)
go

-------------------------------------------------------------
if object_id('dbo.MTOPCheckRecords') is null

    create table dbo.MTOPCheckRecords (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
		, CheckName nvarchar(150)
		, Remarks nvarchar(MAX)
		, RecordDate datetime 
		, GroupName int 
		, ParentId int 
		, IsControlPoint  bit not null DEFAULT 0
		, CalculatedPerformanceSource varbinary(MAX) 
		, AverageUtilization varbinary(50) 

	)
go

----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'LLPLifeLengthForDate' ) 

	alter table dbo.ComponentLLPCategoryData
    add LLPLifeLengthForDate varbinary(50)
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'Date' ) 

	alter table dbo.ComponentLLPCategoryData
    add Date datetime
GO


--------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'WorkPackageId' ) 

	alter table dbo.Discrepancies
    add WorkPackageId int
GO



--------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'PreConfirmTransfer' ) 

	alter table dbo.TransferRecords
    add PreConfirmTransfer bit default 1
GO



