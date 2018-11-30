if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MpdRef' ) 

	alter table dbo.MaintenanceDirectives
    add MpdRef nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MpdRevisionNum' ) 

	alter table dbo.MaintenanceDirectives
    add MpdRevisionNum nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MpdOldTaskCard' ) 

	alter table dbo.MaintenanceDirectives
    add MpdOldTaskCard nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'Workarea' ) 

	alter table dbo.MaintenanceDirectives
    add Workarea nvarchar(256)
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'Category' ) 

	alter table dbo.MaintenanceDirectives
    add Category INT NOT NULL default -1
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'MpdRevisionDate' ) 

	alter table dbo.MaintenanceDirectives
    add MpdRevisionDate datetime
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.MaintenanceDirectives')
                    and c.name = 'Skill' ) 

	alter table dbo.MaintenanceDirectives
    add Skill INT NOT NULL default -1
GO

---------------------------------------------------------------
if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.Specialists')
                    and c.name = 'Additional' ) 

	alter table dbo.Specialists
    add Additional nvarchar(256)
GO

--------------------------ATA---------------------------------
--------------------------05---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0510','Time Limits')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0520','Scheduled Maintenance Checks')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0520','Scheduled Maintenance Checks')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0530','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0540')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0540','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0550')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0550','Unscheduled Maintenance Checks')
go

--------------------------07---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0710','Jacking')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0720','Shoring')
go

--------------------------08---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0800')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0800','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0810')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0810','Weighing & Balancing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0820')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0820','Leveling')
go

--------------------------09---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0900')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0900','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0910')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0910','Towing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '0920')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('0920','Taxiing')
go

--------------------------10---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1000','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1010')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1010','Parking / Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1020')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1020','Mooring')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1030')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1030','Return To Service')
go

--------------------------11---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1110','Exterior Colour Schemes & Markings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1120','Exterior Placards & Markings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1130','Interior Placards')
go

--------------------------12---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1210','Replenishing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1220','Scheduled Servicing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1230','Unscheduled Servicing')
go

--------------------------18---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1800')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1800','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1810')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1810','Vibration Analysis')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '1820')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('1820','Noise Analysis')
go

--------------------------20---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2000','General')
go

--------------------------21---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2110','Compression')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2120','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2130','Pressurization Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2140')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2140','Heating')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2150')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2150','Cooling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2160')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2160','Temperature Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2170')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2170','Moisture / Air Contaminant Control')
go

--------------------------22---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2210','Autopilot')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2220','Speed-Attitude Correction')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2230','Auto Throttle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2240')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2240','System Monitor')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2250')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2250','Aerodynamic Load Alleviating')
go

--------------------------23---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2310','Speech Communications')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2315')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2315','SATCOM')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2320','Data Transmission & Automatic Calling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2330','Passenger Address, Entertainment, & Comfort')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2340')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2340','Interphone')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2350')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2350','Audio Integrating')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2360')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2360','Static Discharging')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2370')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2370','Audio & Video Monitoring')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2380')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2380','Integrated Automatic Tuning')
go

--------------------------24---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2410','Generator Drive')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2420','AC Generation')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2430','DC Generation')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2440')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2440','External Power')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2450')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2450','AC Electrical Load Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2460')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2460','DC Electrical Load Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2470')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2470','Primary & Secondary Power')
go

--------------------------25---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2510','Flight Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2520','Passenger Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2530','Buffet / Galley')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2540')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2540','Lavatories')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2550')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2550','Cargo Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2560')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2560','Emergency')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2570')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2570','Accessory Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2580')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2580','Insulation')
go

--------------------------26---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2610','Detection')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2620','Extinguishing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2630')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2630','Explosion Suppression')
go

--------------------------27---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2710','Aileron & Tab')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2720','Rudder & Tab')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2730')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2730','Elevator & Tab')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2740')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2740','Horizontal Stabilizer / Stabilator')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2750')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2750','Flaps')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2760')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2760','Spoiler, Drag Devices & Variable Aerodynamic Fairings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2770')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2770','Gust Lock & Damper')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2780')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2780','Lift Augmenting')
go

--------------------------28---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2800')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2800','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2810')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2810','Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2820')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2820','Distribution-Drain Valves')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2830')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2830','Dump')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2840')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2840','Indicating')
go

--------------------------29---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2900')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2900','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2910')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2910','Main')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2920')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2920','Auxiliary')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '2930')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('2930','Indicating')
go

--------------------------30---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3000','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3010')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3010','Airfoil')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3020')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3020','Air Intakes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3030')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3030','Pitot & Static')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3040')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3040','Windows, Windshields, & Doors')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3050')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3050','Antennas & Radomes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3060')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3060','Propellers / Rotors')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3070')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3070','Water Lines')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3080')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3080','Detection')
go


--------------------------31---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3110','Instrument & Control Panels')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3120','Independent Instruments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3130','Recorders')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3140')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3140','Central Computers')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3150')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3150','Central Warning Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3160')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3160','Central Display Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3170')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3170','Automatic Data Reporting Systems')
go



--------------------------32---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3210','Main Gear & Doors')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3220','Nose Gear / Tail Gear & Doors')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3230','Extension & Retraction')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3240')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3240','Wheels & Brakes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3250')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3250','Steering')
go


if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3260')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3260','Position & Warning , and Ground Safety Switch')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3270')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3270','Supplementary Gear - Skis, Floats')
go

--------------------------33---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3310','Flight Compartment & Annunciator Panel')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3320','Passenger Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3330','Cargo & Service Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3340')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3340','Exterior Lighting')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3350')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3350','Emergency Lighting')
go

--------------------------34---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3410','Flight Environment Data')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3420','Attitude & Direction')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3430','Landing & Taxiing Aids')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3440')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3440','Independent Position Determining')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3450')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3450','Dependent Position Determining')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3460')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3460','Flight Management Computing')
go

--------------------------35---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3510','Crew')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3520','Passenger')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3530','Portable')
go

--------------------------36---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3610','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3620','Indicating')
go

--------------------------37---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3710','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3720','Indicating')
go

--------------------------38---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3800')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3800','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3810')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3810','Potable')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3820')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3820','Wash')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3830')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3830','Waste Disposal')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3840')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3840','Air Supply')
go

--------------------------39---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3900')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3900','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3910')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3910','Instrument & Control Panels')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3920')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3920','Electrical & Electronic Equipment Racks')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3930')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3930','Electrical & Electronic Junction Boxes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3940')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3940','Multipurpose Electronic Components')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3950')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3950','Integrated Circuits')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '3960')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('3960','Printed Circuit Card Assemblies')
go

--------------------------41---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4110','Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4120','Dump')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4130','Indication')
go

--------------------------42---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4220','Core System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4230','Network Components')
go

--------------------------44---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4410','Cabin Core System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4420','Inflight Entertainment System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4430','External Communication System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4440')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4440','Cabin Mass Memory System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4450')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4450','Cabin Monitoring System')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4460')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4460','Miscellaneous Cabin System')
go

--------------------------46---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4610','Airplane General Information Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4620','Flight Deck Information Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4630')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4630','Maintenance Information Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4640')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4640','Passenger Cabin Information Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4650')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4650','Miscellaneous Information Systems')
go

--------------------------47---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4710','Generation/Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4720','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4730')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4730','Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4740')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4740','Indicating')
go

--------------------------49---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4900')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4900','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4910')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4910','Power Plant')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4920')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4920','Engine')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4930')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4930','Engine Fuel & Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4940')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4940','Ignition / Starting')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4950')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4950','Air')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4960')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4960','Engine Controls')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4970')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4970','Indicating')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4980')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4980','Exhaust')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '4990')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('4990','Oil')
go


--------------------------50---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5000','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5010')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5010','Cargo Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5020')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5020','Cargo Loading Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5030')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5030','Cargo Related Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5040')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5040','Unassigned')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5050')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5050','Accessory Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5060')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5060','Insulation')
go

--------------------------51---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5110','Cargo Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5120','Cargo Loading Systems')
go


if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5130','Cargo Related Systems')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5140')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5140','Unassigned')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5150')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5150','Accessory Compartments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5160')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5160','Insulation')
go

--------------------------52---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5210','Passenger / Crew')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5220','Emergency Exit')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5230','Cargo')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5240')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5240','Service')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5250')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5250','Fixed Interior')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5260')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5260','Entrance Stairs')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5270')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5270','Monitoring & Operation & Warning')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5280')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5280','Landing Gear')
go


--------------------------53---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5310','Main Frame')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5320','Auxiliary Structure')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5330','Plates-Skin')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5340')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5340','Attach Fittings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5350')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5350','Aerodynamic Fairings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5360')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5360','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5370')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5370','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5380')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5380','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5390')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5390','')
go

--------------------------54---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5410','Nacelle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5420','Nacelle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5430','Nacelle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5440')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5440','Nacelle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5450')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5450','Pylon')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5460')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5460','Pylon')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5470')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5470','Pylon')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5480')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5480','Pylon')
go

--------------------------55---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5510','Horizontal Stabilizer / Stabilator Or Canard')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5520','Elevator')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5530','Vertical Stabilizer')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5540')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5540','Rudder')
go

--------------------------56---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5610','Flight Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5620','Passenger Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5630')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5630','Door')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5640')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5640','Inspection & Observation')
go

--------------------------57---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5710','Center Wing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5720','Outer Wing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5730')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5730','Wing Tip')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5740')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5740','Leading Edge & Leading Edge Devices')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5750')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5750','Trailing Edge & Trailing Edge Devices')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5760')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5760','Ailerons & Elevons')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5770')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5770','Spoilers')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5780')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5780','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '5790')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('5790','Wing Folding System')
go

--------------------------60---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6000','General')
go

--------------------------61---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6110','Propeller Assembly')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6120','Controlling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6130','Braking')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6140')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6140','Indicating')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6150')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6150','Propulsor Duct')
go

--------------------------62---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6210','Rotor Blades')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6220','Rotor Head(S)')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6230','Rotor Shaft(S) / Swashplate Assembly(Ies)')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6240')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6240','Indicating')
go

--------------------------63---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6310','Engine / Gearbox Couplings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6320','Gearbox(es)')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6330','Mounts, Attachments')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6340')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6340','Indicating')
go

--------------------------64---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6410','Rotor Blades')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6420','Rotor Head')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6430','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6440')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6440','Indicating')
go

--------------------------65---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6510','Shafts')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6520','Gearboxes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6530','')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6540')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6540','Indicating')
go

--------------------------66---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6610','Rotor Blades')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6620','Tail Pylon')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6630')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6630','Controls & Indicating')
go

--------------------------67---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6710','Rotor Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6720','Anti-Torque Rotor Control (Yaw Control)')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '6730')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('6730','Servo-Control System')
go

--------------------------70---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7000','General')
go

--------------------------71---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7110','Cowling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7120','Mounts')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7130')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7130','Fire seals & Shrouds')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7140')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7140','Attach Fittings')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7150')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7150','Electrical Harness')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7160')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7160','Engine Air Intakes')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7170')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7170','Engine Drains')
go

--------------------------72T---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T00')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T00','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T10')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T10','Reduction Gear & Shaft (Turboprop &/Or Front Mounted Driven Propulsor)')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T20')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T20','Air Inlet Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T30')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T30','Compressor Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T40')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T40','Combustion Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T50')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T50','Turbine Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T60')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T60','Accessory Drives')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T70')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T70','By-Pass Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72T80')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72T80','Propulsor Section (Rear Mounted)')
go

--------------------------72R---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R00')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R00','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R10')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R10','Front Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R20')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R20','Power Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R30')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R30','Cylinder Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R40')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R40','SuperCharger Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '72R50')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('72R50','Lubrication')
go




--------------------------73---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7310','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7320','Controlling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7330')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7330','Indicating')
go

--------------------------74---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7410','Electrical Power Supply')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7420','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7430','Switching')
go

--------------------------75---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7500')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7500','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7510')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7510','Engine Anti-Icing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7520')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7520','Engine Cooling')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7530')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7530','Compressor Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7540')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7540','Indicating')
go

--------------------------76---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7600')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7600','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7610')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7610','Power Control')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7620')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7620','Emergency Shutdown')
go

--------------------------77---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7710')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7710','Power')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7720','Temperature')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7730')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7730','Analyzers')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7740')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7740','Integrated Engine Instrument Systems')
go

--------------------------78---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7800')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7800','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7810')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7810','Collector-Nozzle')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7820')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7820','Noise Suppressor')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7830')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7830','Thrust Reverser')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7840')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7840','Supplemental Air')
go

--------------------------79---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7900')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7900','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7910')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7910','Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7920')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7920','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '7930')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('7930','Indicating')
go

--------------------------80---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8000')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8000','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8010')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8010','Cranking')
go

--------------------------81---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8100','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8110')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8110','Power Recovery')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8120')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8120','Turbo-Supercharger')
go

--------------------------82---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8200')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8200','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8210')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8210','Storage')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8220')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8220','Distribution')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8230')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8230','Dumping & Purging')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8240')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8240','Indicating')
go

--------------------------83---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8300')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8300','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8310')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8310','Drive Shaft Section')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8320')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8320','Gear Box Section')
go

--------------------------84---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8400')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8400','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '8410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('8410','Jet Assist Takeoff')
go

--------------------------91---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9100')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9100','General')
go

--------------------------97---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9700')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9700','General')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9701')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9701','Zone 100 Fuselage Lower')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9702')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9702','Zone 200 Fuselage Top')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9703')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9703','Zone 300 Stabilizers')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9704')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9704','Zone 400 Nacelles-Pylons')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9705')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9705','Zone 500 Left Wing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9706')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9706','Zone 600 Right Wing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9707')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9707','Zone 700 Landing Gear Compartment')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9708')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9708','Zone 800 Doors')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9709')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9709','Zone 900 Lavatories & Galleys')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '9720')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('9720','Electrical Standard Items/Practices')
go

--------------------------104---------------------------------
if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '10410')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('10410','Technical Training Servicing')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '10420')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('10420','Technical Training Familization')
go

if not exists ( select  *
            from    Dictionaries.ATAChapter a                       
            where    a.ShortName = '10430')

			Insert into Dictionaries.ATAChapter (ShortName, FullName) Values('10430','Technical Training Maintenance')
go

----------------------------------------------------------------------------
if object_id('dbo.FlightNumbers') is null

    create table dbo.FlightNumbers (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightNo nvarchar(128) null
		, Description nvarchar(MAX) null
		, Remarks nvarchar(MAX) null
		, HiddenRemarks nvarchar(MAX) null
		, MaxFuelAmount float null
		, MinFuelAmount float null
		, MaxPayload float null
		, MaxCargoWeight float null
		, MaxTakeOffWeight float null
		, MaxLandWeight float null
		, FlightAircraftCode INT DEFAULT 0
		, FlightType INT DEFAULT 0
		, FlightCategory INT DEFAULT 0
		, Distance INT DEFAULT 0
		, DistanceMeasure INT DEFAULT -1
		, StationFrom INT DEFAULT -1
		, StationTo INT DEFAULT -1
		, MinLevel INT DEFAULT 0
		, MaxPassengerAmount INT DEFAULT 0
		, Threshold varbinary(21) 
		, IsClosed bit 

	)
GO


if object_id('Dictionaries.AirportsCodes') is null

    create table Dictionaries.AirportsCodes (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, Iata nvarchar(256)
		, Icao nvarchar(256)
		, FullName nvarchar(256)
		, City nvarchar(256)
		, Country nvarchar(256)
		, Iso nvarchar(256)
	)
go

if object_id('Dictionaries.FlightNum') is null

    create table Dictionaries.FlightNum (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightNumber nvarchar(256)
	)
go


if object_id('dbo.FlightNumberAircraftModelRelations') is null

    create table dbo.FlightNumberAircraftModelRelations (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, AircraftModelId INT
		, FlightNumberId INT
	)
GO


if object_id('dbo.FlightNumberAirportRelations') is null

    create table dbo.FlightNumberAirportRelations (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightNumberId INT
		, AirportId INT
	)
GO


if object_id('dbo.FlightNumberCrewRecords') is null

    create table dbo.FlightNumberCrewRecords (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightNumberId INT
		, SpecializationId INT
		, Count INT
	)
GO


if object_id('dbo.FlightNumberPeriods') is null

    create table dbo.FlightNumberPeriods (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightNumberId INT
		, PeriodFrom INT
		, PeriodTo INT
		, IsMonday bit
		, IsThursday bit
		, IsWednesday bit
		, IsTuesday bit
		, IsFriday bit
		, IsSaturday bit
		, IsSunday bit
		, IsSunday bit
		, DepartureDate datetime
		, ArrivalDate datetime
	)
GO


if object_id('dbo.FlightTrips') is null

    create table dbo.FlightTrips (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, TripName int
		, Remarks nvarchar(256)
		, DayOfWeek int
	)
GO

if object_id('dbo.FlightTripRecords') is null

    create table dbo.FlightTripRecords (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, FlightTripId int
		, FlightPeriodId int
	)
GO


if object_id('Dictionaries.TripName') is null

    create table Dictionaries.TripName (
          ItemId int IDENTITY PRIMARY KEY not null 
        , IsDeleted  bit not null DEFAULT 0
		, TripName nvarchar(256)
	)
go


------------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.ATLBs')
                    and c.name = 'AtlbStatus' ) 

	alter table dbo.ATLBs
    add AtlbStatus int not null default 0
GO

------------------------------------------------------------------------------------

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'StationToId' ) 

	alter table dbo.AircraftFlights
    add StationFromId int not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'StationToId' ) 

	alter table dbo.AircraftFlights
    add StationToId int not null default 0
GO

if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.AircraftFlights')
                    and c.name = 'FlightNumber' ) 

	alter table dbo.AircraftFlights
    add FlightNumber int not null default 0
GO


if not exists ( select  *
            from    sys.columns c                        
            where   c.object_id = object_id('dbo.FlightTrips')
                    and c.name = 'SupplierID' ) 

	alter table dbo.FlightTrips
    add SupplierID int not null default -1
GO


-----------------------------------------------------------------------
if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'ATLB')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('ATLB', 23)
go

-----------------------------------------------------------------------
if not exists ( select  *
            from    Dictionaries.DocumentSubType a                       
            where    a.Name = 'Flight Schedule')

			Insert into Dictionaries.DocumentSubType (Name, DocumentTypeId) Values('Flight Schedule', 19)
go


