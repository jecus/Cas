-------------------------------------------------------------------------------------------
--LIfelenght"+"Json"
-------------------------------------------------------------------------------------------
--dbo.Components
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'LifelengthJson' ) 
begin
	alter table dbo.Components
	add LifelengthJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'WarrantyJson' ) 
begin
	alter table dbo.Components
	add WarrantyJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'WarrantyNotifyJson' ) 
begin
	alter table dbo.Components
	add WarrantyNotifyJson nvarchar(max)
end


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'LifeLimitJson' ) 
begin
	alter table dbo.Components
	add LifeLimitJson nvarchar(max)
end


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'LifeLimitNotifyJson' ) 
begin
	alter table dbo.Components
	add LifeLimitNotifyJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Components')
                    and c.name = 'StartLifelengthJson' ) 
begin
	alter table dbo.Components
	add StartLifelengthJson nvarchar(max)
end


-------------------------------------------------------------------------------------------
--dbo.ComponentLLPCategoryChangeRecords
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryChangeRecords')
                    and c.name = 'OnLifeLengthJson' ) 
begin
	alter table dbo.ComponentLLPCategoryChangeRecords
	add OnLifeLengthJson nvarchar(max)
end

-------------------------------------------------------------------------------------------
--dbo.ComponentLLPCategoryData
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'LLPLifeLengthJson' ) 
begin
	alter table dbo.ComponentLLPCategoryData
	add LLPLifeLengthJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'LLPLifeLimitJson' ) 
begin
	alter table dbo.ComponentLLPCategoryData
	add LLPLifeLimitJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ComponentLLPCategoryData')
                    and c.name = 'NotifyJson' ) 
begin
	alter table dbo.ComponentLLPCategoryData
	add NotifyJson nvarchar(max)
end


-------------------------------------------------------------------------------------------
--dbo.Runups

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Runups')
                    and c.name = 'OnLifelengthJson' ) 
begin
	alter table dbo.Runups
	add OnLifelengthJson nvarchar(max)
end


-------------------------------------------------------------------------------------------
--dbo.Cas3MaintenanceCheck

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheck')
                    and c.name = 'IntervalJson' ) 
begin
	alter table dbo.Cas3MaintenanceCheck
	add IntervalJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Cas3MaintenanceCheck')
                    and c.name = 'NotifyJson' ) 
begin
	alter table dbo.Cas3MaintenanceCheck
	add NotifyJson nvarchar(max)
end


-------------------------------------------------------------------------------------------
--dbo.DirectivesRecords

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'OnLifelengthJson' ) 
begin
	alter table dbo.DirectivesRecords
	add OnLifelengthJson nvarchar(max)
end



if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.DirectivesRecords')
                    and c.name = 'CalculatedPerformanceSourceJson' ) 
begin
	alter table dbo.DirectivesRecords
	add CalculatedPerformanceSourceJson nvarchar(max)
end

-------------------------------------------------------------------------------------------
--dbo.MaintenanceProgramChangeRecords

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceProgramChangeRecords')
                    and c.name = 'OnLifelengthJson' ) 
begin
	alter table dbo.MaintenanceProgramChangeRecords
	add OnLifelengthJson nvarchar(max)
end



if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceProgramChangeRecords')
                    and c.name = 'CalculatedPerformanceSourceJson' ) 
begin
	alter table dbo.MaintenanceProgramChangeRecords
	add CalculatedPerformanceSourceJson nvarchar(max)
end

-------------------------------------------------------------------------------------------
--dbo.ActualStateRecords

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ActualStateRecords')
                    and c.name = 'OnLifelengthJson' ) 
begin
	alter table dbo.ActualStateRecords
	add OnLifelengthJson nvarchar(max)
end

-------------------------------------------------------------------------------------------
--dbo.InitionalOrderRecords

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'LifeLimitJson' ) 
begin
	alter table dbo.InitionalOrderRecords
	add LifeLimitJson nvarchar(max)
end

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.InitionalOrderRecords')
                    and c.name = 'LifeLimitNotifyJson' ) 
begin
	alter table dbo.InitionalOrderRecords
	add LifeLimitNotifyJson nvarchar(max)
end


-------------------------------------------------------------------------------------------
--Dictionaries.EventCategories

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventCategories')
                    and c.name = 'MinReportPeriodJson' ) 
begin
	alter table Dictionaries.EventCategories
	add MinReportPeriodJson nvarchar(max)
end


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('Dictionaries.EventCategories')
                    and c.name = 'MaxReportPeriodJson' ) 
begin
	alter table Dictionaries.EventCategories
	add MaxReportPeriodJson nvarchar(max)
end