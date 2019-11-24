declare @table sysname, @column sysname, @type sysname, @default sysname

declare cols cursor for
SELECT 
	'['+SCHEMA_NAME(tbl.schema_id)+'].['+tbl.name+']' as 'table',
	col.name as 'column',
	tp.name as 'type',
	def.name as 'default'
from sys.columns col
	inner join sys.tables tbl on tbl.[object_id] = col.[object_id]
	inner join sys.types tp on tp.system_type_id = col.system_type_id
		and tp.name in ('datetime', 'date', 'time', 'datetime2', 'smalldatetime')
	left join sys.default_constraints def on def.parent_object_id = col.[object_id]
		and def.parent_column_id = col.column_id
order by tbl.name, col.name

open cols
fetch from cols into @table, @column, @type, @default
while @@FETCH_STATUS = 0
begin
	declare @cmd nvarchar(max)
	declare @count int

	set @cmd = 'alter table '+@table+' alter column '+@column+' datetimeoffset(2)
				Update '+@table+' set '+@column+' = TODATETIMEOFFSET('+@column+', ''+06:00'')'

	IF @default is not null
		exec('alter table '+@table+' drop constraint '+@default+'')

	exec('update '+@table+' set '+@column+' = SYSDATETIME() where '+@column+' < ''1940-01-01''')

	IF @type like 'datetime2'
		exec('Update '+@table+' set '+@column+' = Convert(datetime2(0), '+@column+') '+@cmd+'')
	Else exec (@cmd)
	

	fetch from cols into @table, @column, @type, @default
end
close cols
deallocate cols