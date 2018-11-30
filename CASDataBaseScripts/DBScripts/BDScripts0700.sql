
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MTOPCheck')
                    and c.name = 'IsZeroPhase' ) 

	alter table dbo.MTOPCheck
    add IsZeroPhase bit default 1
GO



if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Documents')
                    and c.name = 'ParentAircraftId' ) 

	alter table dbo.Documents
    add ParentAircraftId int default 0
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'LLPLifeTemp' ) 

	alter table dbo.ComponentLLPCategoryData
    add LLPLifeTemp varbinary(50)
GO



