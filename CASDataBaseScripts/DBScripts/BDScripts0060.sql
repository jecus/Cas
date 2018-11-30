--dbo.ActualStateRecords
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'ComponentId' ) 
begin
	alter table ActualStateRecords
	add ComponentId int not null 
	Default 0 

	Declare @updateASRComponentId   varchar(Max) = 'update ActualStateRecords set ComponentId = rec.DetailId FROM ActualStateRecords rec'
	exec (@updateASRComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.ActualStateRecords
	drop column DetailId
end

--dbo.DetailDirectives
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailDirectives')) 

		exec sp_rename 'DetailDirectives', 'ComponentDirectives'
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'ComponentId' ) 
begin
	alter table ComponentDirectives
	add ComponentId int not null 
	Default 0 

	Declare @updateCDComponentId varchar(Max) = 'update ComponentDirectives set ComponentId = dd.DetailID  FROM ComponentDirectives dd'
	exec (@updateCDComponentId)
end

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentDirectives')
                    and c.name = 'DetailID' ) 
begin
	alter table dbo.ComponentDirectives
    drop column DetailID
end


--dbo.DetailLLPCategoryChangeRecords
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailLLPCategoryChangeRecords')) 

	exec sp_rename 'DetailLLPCategoryChangeRecords', 'ComponentLLPCategoryChangeRecords';
go


--dbo.DetailLLPCategoryData
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailLLPCategoryData')) 

	exec sp_rename 'DetailLLPCategoryData', 'ComponentLLPCategoryData';
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'ComponentId' ) 
begin
	alter table ComponentLLPCategoryData
	add ComponentId int not null 
	Default 0 

	Declare @updateLLPComponentId varchar(Max) = 'update ComponentLLPCategoryData set ComponentId = dd.DetailID  FROM ComponentLLPCategoryData dd'
	exec (@updateLLPComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'DetailID' ) 
begin
	alter table dbo.ComponentLLPCategoryData
    drop column DetailID
end

--dbo.Detail
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Details')) 

	exec sp_rename 'Details', 'Components';
go

--BaseDetailTypeId----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'BaseComponentTypeId' ) 
begin
	alter table Components
	add BaseComponentTypeId int not null 
	Default 0 

	Declare @updateBaseComponentTypeId varchar(Max) = 'update Components set BaseComponentTypeId = d.BaseDetailTypeId FROM Components d'
	exec (@updateBaseComponentTypeId)
end


if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('dbo.Components')
                     and c.name = 'BaseDetailTypeId' ) 
begin
	if exists ( select 1 
                from sys.default_constraints 
                where object_id = object_id('dbo.DF_Details_BaseDetailTypeId') 
                      AND parent_object_id = object_id('dbo.Components')
                  )
		begin

			alter table dbo.Components
			DROP CONSTRAINT DF_Details_BaseDetailTypeId

		end

	alter table dbo.Components
    drop column BaseDetailTypeId
end

--IsBaseDetail----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'IsBaseComponent' ) 
begin
	alter table Components
	add IsBaseComponent bit not null 
	Default 0 

	Declare @updateIsBaseComponent varchar(Max) = 'update Components set IsBaseComponent = d.IsBaseDetail FROM Components d'
	exec (@updateIsBaseComponent)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('dbo.Components')
                     and c.name = 'IsBaseDetail' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('dbo.DF_Details_IsBaseDetail') 
                      AND parent_object_id = object_id('dbo.Components')
                  )
		begin

			alter table dbo.Components
			DROP CONSTRAINT DF_Details_IsBaseDetail

		end

	alter table dbo.Components
    drop column IsBaseDetail
end

--DetailType----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'ComponentType' ) 
begin
	alter table Components
	add ComponentType int not null 
	Default 0 

	Declare @updateComponentType varchar(Max) = 'update Components set ComponentType = d.DetailType FROM Components d'
	exec (@updateComponentType)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('dbo.Components')
                     and c.name = 'DetailType' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('dbo.DF_Details_Emergency') 
                      AND parent_object_id = object_id('dbo.Components')
                  )
		begin

			alter table dbo.Components
			DROP CONSTRAINT DF_Details_Emergency

		end

	alter table dbo.Components
    drop column DetailType
end



--DetailLabel----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'ComponentLabel' ) 
begin
	alter table Components
	add ComponentLabel int

	Declare @updateComponentLabel varchar(Max) = 'update Components set ComponentLabel = d.DetailLabel FROM Components d'
	exec (@updateComponentLabel)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('dbo.Components')
                     and c.name = 'DetailLabel' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('dbo.DF_Details_DetailLabel') 
                      AND parent_object_id = object_id('dbo.Components')
                  )
		begin

			alter table dbo.Components
			DROP CONSTRAINT DF_Details_DetailLabel

		end

	alter table dbo.Components
    drop column DetailLabel
end


--dbo.DetailWorkInRegimeParams
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DetailWorkInRegimeParams')) 

	exec sp_rename 'DetailWorkInRegimeParams', 'ComponentWorkInRegimeParams';
go


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentWorkInRegimeParams')
                    and c.name = 'ComponentId' ) 
begin
	alter table ComponentWorkInRegimeParams
	add ComponentId int  

	Declare @updateWorkInRegimeComponentId varchar(Max) = 'update ComponentWorkInRegimeParams set ComponentId = d.DetailId FROM ComponentWorkInRegimeParams d'
	exec (@updateWorkInRegimeComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentWorkInRegimeParams')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.ComponentWorkInRegimeParams
    drop column DetailId
end


--dbo.Directives
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'ComponentId' ) 
begin
	alter table Directives
	add ComponentId int

	Declare @updateDirectiveComponentId varchar(Max) = 'update Directives set ComponentId = d.DetailId FROM Directives d'
	exec (@updateDirectiveComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Directives')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.Directives
	drop column DetailId
end


--dbo.MaintenanceDirectiveBindDetailRecords
----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectiveBindDetailRecords')) 

	exec sp_rename 'MaintenanceDirectiveBindDetailRecords', 'MaintenanceDirectiveBindComponentRecords';
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectiveBindComponentRecords')
                    and c.name = 'ComponentId' ) 
begin
	alter table MaintenanceDirectiveBindComponentRecords
	add ComponentId int

	Declare @updateBindCompRecComponentId varchar(Max) = 'update MaintenanceDirectiveBindComponentRecords set ComponentId = d.DetailId FROM MaintenanceDirectiveBindComponentRecords d'
	exec (@updateBindCompRecComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectiveBindComponentRecords')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.MaintenanceDirectiveBindComponentRecords
	drop column DetailId
end


--dbo.MaintenanceDirectives
----------------------------------------------------------------------------------
--DetailId
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ComponentId' ) 
begin
	alter table MaintenanceDirectives
	add ComponentId int 

	Declare @updateMPDComponentId varchar(Max) = 'update MaintenanceDirectives set ComponentId = d.DetailId FROM MaintenanceDirectives d'
	exec (@updateMPDComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.MaintenanceDirectives
	drop column DetailId
end


--ForComponentId
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ForComponentId' ) 
begin
	alter table MaintenanceDirectives
	add ForComponentId int 

	Declare @updateMpdForComponentId varchar(Max) = 'update MaintenanceDirectives set ForComponentId = d.ForDetailId FROM MaintenanceDirectives d'
	exec (@updateMpdForComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'ForDetailId' ) 
begin
	alter table dbo.MaintenanceDirectives
	drop column ForDetailId
end



--dbo.OilConditions
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OilConditions')
                    and c.name = 'ComponentId' ) 
begin
	alter table OilConditions
	add ComponentId int 

	Declare @updateOilConditionsComponentId varchar(Max) = 'update OilConditions set ComponentId = d.DetailId FROM OilConditions d'
	exec (@updateOilConditionsComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.OilConditions')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.OilConditions
	drop column DetailId
end


--dbo.PrimeDirectives
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PrimeDirectives')
                    and c.name = 'ComponentId' ) 
begin
	alter table PrimeDirectives
	add ComponentId int not null 
	Default 0

	Declare @updatePrimeDirectivesComponentId varchar(Max) = 'update PrimeDirectives set ComponentId = d.DetailId FROM PrimeDirectives d'
	exec (@updatePrimeDirectivesComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.PrimeDirectives')
                    and c.name = 'DetailId' ) 
begin
	alter table dbo.PrimeDirectives
	drop column DetailId
end

--dbo.Runups
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Runups')
                    and c.name = 'BaseComponentId' ) 
begin
	alter table Runups
	add BaseComponentId int 

	Declare @updateRunups varchar(Max) = 'update Runups set BaseComponentId = d.BaseDetailId FROM Runups d'
	exec (@updateRunups)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Runups')
                    and c.name = 'BaseDetailId' ) 
begin
	alter table dbo.Runups
	drop column BaseDetailId
end

--dbo.StockDetailInfos
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockDetailInfos')) 

	exec sp_rename 'StockDetailInfos', 'StockComponentInfos';
go

--DetailClass
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'ComponentClass' ) 
begin
	alter table StockComponentInfos
	add ComponentClass int 

	Declare @updateComponentClass varchar(Max) = 'update StockComponentInfos set ComponentClass = d.DetailClass FROM StockComponentInfos d'
	exec (@updateComponentClass)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'DetailClass' ) 
begin
	alter table dbo.StockComponentInfos
	drop column DetailClass
end


--DetailModel--------------------------------------------------------------------
if not exists ( select  *
				from    sys.columns c                        
				where   c.object_id = object_id('dbo.StockComponentInfos')
						and c.name = 'ComponentModel' ) 
begin
	alter table StockComponentInfos
	add ComponentModel int 

	Declare @updateComponentModel varchar(Max) = 'update StockComponentInfos set ComponentModel = d.DetailModel FROM StockComponentInfos d'
	exec (@updateComponentModel)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'DetailModel' ) 
begin
	alter table dbo.StockComponentInfos
	drop column DetailModel
end

--DetailType--------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'ComponentType' ) 
begin
	alter table StockComponentInfos
	add ComponentType int 

	Declare @updateComponentType varchar(Max) = 'update StockComponentInfos set ComponentType = d.DetailType FROM StockComponentInfos d'
	exec (@updateComponentType)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.StockComponentInfos')
                    and c.name = 'DetailType' ) 
begin
	alter table dbo.StockComponentInfos
	drop column DetailType
end


--dbo.TransferRecords
----------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.TransferRecords')
                    and c.name = 'FromBaseComponentID' ) 
begin
	alter table TransferRecords
	add FromBaseComponentID int not null 
	default 0

	Declare @update varchar(Max) = 'update TransferRecords set FromBaseComponentID = d.FromBaseDetailID FROM TransferRecords d'
	exec (@update)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('dbo.TransferRecords')
                     and c.name = 'FromBaseDetailID' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('dbo.DF_TransferRecords_FromBaseDetailID') 
                      AND parent_object_id = object_id('dbo.TransferRecords')
                  )
		begin

			alter table dbo.TransferRecords
			DROP CONSTRAINT DF_TransferRecords_FromBaseDetailID

		end

	alter table dbo.TransferRecords
    drop column FromBaseDetailID
end



------------------------------Dictionaries--------------------------------------------
--Dictionaries.GoodStandarts
----------------------------------------------------------------------------------
--DetailType
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'ComponentType' ) 
begin
	alter table Dictionaries.GoodStandarts
	add ComponentType int 

	Declare @updateGoodStandartsComponentType varchar(Max) = 'update Dictionaries.GoodStandarts set ComponentType = d.DetailType FROM Dictionaries.GoodStandarts d'
	exec (@updateGoodStandartsComponentType)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'DetailType' ) 
begin
	alter table Dictionaries.GoodStandarts
	drop column DetailType
end


--DetailClass
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'ComponentClass' ) 
begin
	alter table Dictionaries.GoodStandarts
	add ComponentClass int 

	Declare @updateGoodStandartsComponentClass varchar(Max) = 'update Dictionaries.GoodStandarts set ComponentClass = d.DetailClass FROM Dictionaries.GoodStandarts d'
	exec (@updateGoodStandartsComponentClass)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.GoodStandarts')
                    and c.name = 'DetailClass' ) 
begin
	alter table Dictionaries.GoodStandarts
	drop column DetailClass
end


--Dictionaries.AccessoryDescriptions
----------------------------------------------------------------------------------
--DetailClass
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'ComponentClass' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	add ComponentClass smallint 

	Declare @updateAccessDescComponentClass varchar(Max) = 'update Dictionaries.AccessoryDescriptions set ComponentClass = d.DetailClass FROM Dictionaries.AccessoryDescriptions d'
	exec (@updateAccessDescComponentClass)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'DetailClass' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	drop column DetailClass
end


--DetailModel
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'ComponentModel' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	add ComponentModel int 

	Declare @updateAccessDescComponentModel varchar(Max) = 'update Dictionaries.AccessoryDescriptions set ComponentModel = d.DetailModel FROM Dictionaries.AccessoryDescriptions d'
	exec (@updateAccessDescComponentModel)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'DetailModel' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	drop column DetailModel
end


--DetailType
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'ComponentType' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	add ComponentType int 

	Declare @updateAccessDescComponentType varchar(Max) = 'update Dictionaries.AccessoryDescriptions set ComponentType = d.DetailType FROM Dictionaries.AccessoryDescriptions d'
	exec (@updateAccessDescComponentType)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.AccessoryDescriptions')
                    and c.name = 'DetailType' ) 
begin
	alter table Dictionaries.AccessoryDescriptions
	drop column DetailType
end

--Dictionaries.DetailsRecordsTypes
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DetailsRecordsTypes')) 

	exec sp_rename 'Dictionaries.DetailsRecordsTypes', 'ComponentsRecordsTypes';
go

--Dictionaries.DetailsTypes
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.DetailsTypes')) 

	exec sp_rename 'Dictionaries.DetailsTypes', 'ComponentsTypes';
go




------------------------------Templates--------------------------------------------
--Template.DetailDirectives
----------------------------------------------------------------------------------

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.DetailDirectives')) 

	exec sp_rename 'Template.DetailDirectives', 'ComponentDirectives';
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.ComponentDirectives')
                    and c.name = 'ComponentId' ) 
begin
	alter table Template.ComponentDirectives
	add ComponentId int

	Declare @updateTemplateDDComponentId varchar(Max) = 'update Template.ComponentDirectives set ComponentId = dd.DetailId FROM Template.ComponentDirectives dd'
	exec (@updateTemplateDDComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.ComponentDirectives')
                    and c.name = 'DetailId' ) 
begin
	alter table Template.ComponentDirectives
	drop column DetailId
end



--Template.Details
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Details')) 

	exec sp_rename 'Template.Details', 'Components';
go

--BaseDetailTypeId----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Components')
                    and c.name = 'BaseComponentTypeId' ) 
begin
	alter table Template.Components
	add BaseComponentTypeId int

	Declare @updateTemplateBaseComponentTypeId varchar(Max) = 'update Template.Components set BaseComponentTypeId = d.BaseDetailType FROM Template.Components d'
	exec (@updateTemplateBaseComponentTypeId)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('Template.Components')
                     and c.name = 'BaseDetailType' ) 
begin
	alter table Template.Components
    drop column BaseDetailType
end

--IsBaseDetail----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Components')
                    and c.name = 'IsBaseComponent' ) 
begin
	alter table Template.Components
	add IsBaseComponent bit not null 
	Default 0 

	Declare @updateTemplateIsBaseComponent varchar(Max) = 'update Template.Components set IsBaseComponent = d.IsBaseDetail FROM Template.Components d'
	exec (@updateTemplateIsBaseComponent)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('Template.Components')
                     and c.name = 'IsBaseDetail' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('Template.DF_Details_IsBaseDetail_1') 
                      AND parent_object_id = object_id('Template.Components')
                  )
		begin

			alter table Template.Components
			DROP CONSTRAINT DF_Details_IsBaseDetail_1

		end

	alter table Template.Components
    drop column IsBaseDetail
end

--DetailType----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Components')
                    and c.name = 'ComponentType' ) 
begin
	alter table Template.Components
	add ComponentType int 

	Declare @updateTemplateComponentType varchar(Max) = 'update Template.Components set ComponentType = d.DetailType FROM Template.Components d'
	exec (@updateTemplateComponentType)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('Template.Components')
                     and c.name = 'DetailType' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('Template.DF_Details_DetailType') 
                      AND parent_object_id = object_id('Template.Components')
                  )
		begin

			alter table Template.Components
			DROP CONSTRAINT DF_Details_DetailType

		end

	alter table Template.Components
    drop column DetailType
end



--Template.Directives
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Directives')
                    and c.name = 'ComponentId' ) 
begin
	alter table Template.Directives
	add ComponentId int

	Declare @updateTemplateDirectivesComponentId varchar(Max) = 'update Template.Directives set ComponentId = d.DetailId FROM Template.Directives d'
	exec (@updateTemplateDirectivesComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Template.Directives')
                    and c.name = 'DetailId' ) 
begin
	alter table Template.Directives
	drop column DetailId
end




------------------------------Logs--------------------------------------------
--Logs.DetailDirectives
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.DetailDirectives')) 

		exec sp_rename 'Logs.DetailDirectives', 'ComponentDirectives'
go

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.ComponentDirectives')
                    and c.name = 'ComponentId' ) 
begin
	alter table Logs.ComponentDirectives
	add ComponentId int

	Declare @updateLogsCDComponentId varchar(Max) = 'update Logs.ComponentDirectives set ComponentId = dd.DetailID  FROM Logs.ComponentDirectives dd'
	exec (@updateLogsCDComponentId)
end

if  exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.ComponentDirectives')
                    and c.name = 'DetailID' ) 
begin
	alter table Logs.ComponentDirectives
    drop column DetailID
end


--Logs.ActualStateRecords
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.ActualStateRecords')
                    and c.name = 'ComponentId' ) 
begin
	alter table Logs.ActualStateRecords
	add ComponentId int 

	Declare @updateLogsASRComponentId   varchar(Max) = 'update Logs.ActualStateRecords set ComponentId = rec.DetailId FROM Logs.ActualStateRecords rec'
	exec (@updateLogsASRComponentId)
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.ActualStateRecords')
                    and c.name = 'DetailId' ) 
begin
	alter table Logs.ActualStateRecords
	drop column DetailId
end



--Logs.Details
----------------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.Details')) 

	exec sp_rename 'Logs.Details', 'Components';
go


--IsBaseDetail----------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.Components')
                    and c.name = 'IsBaseComponent' ) 
begin
	alter table Logs.Components
	add IsBaseComponent bit not null 
	Default 0 

	Declare @updateLogsIsBaseComponent varchar(Max) = 'update Logs.Components set IsBaseComponent = d.IsBaseDetail FROM Logs.Components d'
	exec (@updateLogsIsBaseComponent)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('Logs.Components')
                     and c.name = 'IsBaseDetail' ) 
begin
	IF EXISTS ( select 1 
                from sys.default_constraints 
                where object_id = object_id('Logs.DF_Details_IsBaseDetail_1') 
                AND parent_object_id = object_id('Logs.Components'))
		begin

			alter table Logs.Components
			DROP CONSTRAINT DF_Details_IsBaseDetail_1

		end

	alter table Logs.Components
    drop column IsBaseDetail
end


--Logs.Directives
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.Directives')
                    and c.name = 'ComponentId' ) 
begin
	alter table Logs.Directives
	add ComponentId int

	Declare @updateLogsDirectivesComponentId varchar(Max) = 'update Logs.Directives set ComponentId = d.DetailId FROM Logs.Directives d'
	exec (@updateLogsDirectivesComponentId)
end
---------------------------------------------------------------------------
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.Directives')
                    and c.name = 'DetailId' ) 
begin
	alter table Logs.Directives
	drop column DetailId
end


--Logs.TransferRecords
----------------------------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.TransferRecords')
                    and c.name = 'FromBaseComponentID' ) 
begin
	alter table Logs.TransferRecords
	add FromBaseComponentID int

	Declare @updateLogsFromBaseComponentID varchar(Max) = 'update Logs.TransferRecords set FromBaseComponentID = d.FromBaseDetailID FROM Logs.TransferRecords d'
	exec (@updateLogsFromBaseComponentID)
end

if exists ( select  *
             from    sys.columns c                        
             where   c.object_id = object_id('Logs.TransferRecords')
                     and c.name = 'FromBaseDetailID' ) 
begin
	alter table Logs.TransferRecords
    drop column FromBaseDetailID
end



-------------------------------------------------------------------------------------------
--Удаление таблиц BaseDetails
if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Logs.BaseDetails')) 
begin
	drop table Logs.BaseDetails
end

if exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.BaseDetails')) 
begin
	drop table dbo.BaseDetails
end