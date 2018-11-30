
if object_id('Dictionaries.SchedulePeriods') is null

    create table Dictionaries.SchedulePeriods (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , Schedule  int not null
		, DateFrom Datetime 
		, DateTo Datetime
	)
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightNumberPeriods')
                    and c.name = 'Schedule' ) 

	alter table dbo.FlightNumberPeriods
    add Schedule int not null default 0
GO


if object_id('dbo.FlightPlanOps') is null

    create table dbo.FlightPlanOps (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
        , Remarks  varchar(Max)
		, DateFrom Datetime 
		, DateTo Datetime
	)
go


if object_id('dbo.FlightPlanOpsRecords') is null

    create table dbo.FlightPlanOpsRecords (
          ItemId int IDENTITY PRIMARY KEY not null 
		, IsDeleted  bit not null DEFAULT 0
		, FlightPlanOpsId  int 
		, AircraftId  int 
		, AircraftExchangeId  int 
		, DelayReasonId  int 
		, CancelReasonId  int 
		, ReasonId  int 
		, FlightTrackRecordId  int 
		, PeriodFrom  int 
		, PeriodTo  int 
		, PlanDate Datetime 
		, ParentFlightId int 
		, Remarks varchar(MAX) 
		, HiddenRemarks varchar(MAX)
		, IsDispatcherEdit bit default 1

	)
go


if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Flight Schedule(Reason)')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Flight Schedule(Reason)', 22)
go

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Flight Schedule(Delay)')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Flight Schedule(Delay)', 19)
go

if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Flight Schedule(Cancellation)')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Flight Schedule(Cancellation)', 19)
go

