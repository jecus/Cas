
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'IsReliability' ) 

	alter table dbo.Discrepancies
    add IsReliability bit not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'DeffeñtPhase' ) 

	alter table dbo.Discrepancies
    add DeffeñtPhase int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'DeffeñtCategory' ) 

	alter table dbo.Discrepancies
    add DeffeñtCategory int not null default -1
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'DeffectConfirm' ) 

	alter table dbo.Discrepancies
    add DeffectConfirm int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'ActionType' ) 

	alter table dbo.Discrepancies
    add ActionType int not null default -1
GO




if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'IsOccurrence' ) 

	alter table dbo.Discrepancies
    add IsOccurrence bit not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Substruction' ) 

	alter table dbo.Discrepancies
    add Substruction bit not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'EngineShutUp' ) 

	alter table dbo.Discrepancies
    add EngineShutUp bit not null default 0
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'ConsequenceFault' ) 

	alter table dbo.Discrepancies
    add ConsequenceFault int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'ConsequenceOps' ) 

	alter table dbo.Discrepancies
    add ConsequenceOps int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'ConsequenceType' ) 

	alter table dbo.Discrepancies
    add ConsequenceType int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'BaseComponentId' ) 

	alter table dbo.Discrepancies
    add BaseComponentId int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'InterruptionType' ) 

	alter table dbo.Discrepancies
    add InterruptionType int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'TimeDelay' ) 

	alter table dbo.Discrepancies
    add TimeDelay int not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Remarks' ) 

	alter table dbo.Discrepancies
    add Remarks nvarchar(MAX) not null default '' 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Messages' ) 

	alter table dbo.Discrepancies
    add Messages nvarchar(MAX) not null default '' 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'FDR' ) 

	alter table dbo.Discrepancies
    add FDR nvarchar(MAX) not null default '' 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'EngineRemarks' ) 

	alter table dbo.Discrepancies
    add EngineRemarks nvarchar(MAX) not null default '' 
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Auth' ) 

	alter table dbo.Discrepancies
    add Auth int not null default -1
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Occurrence' ) 

	alter table dbo.Discrepancies
    add Occurrence int not null default -1
GO


if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'MPD Compliance')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('MPD Compliance', 23)
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Discrepancies')
                    and c.name = 'Status' ) 

	alter table dbo.Discrepancies
    add Status int not null default 0
GO




if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3WorkPakageRecord')
                    and c.name = 'GroupNumber' ) 

	alter table dbo.Cas3WorkPakageRecord
    add GroupNumber int 
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3WorkPakageRecord')
                    and c.name = 'ParentCheckId' ) 

	alter table dbo.Cas3WorkPakageRecord
    add ParentCheckId int 
GO





