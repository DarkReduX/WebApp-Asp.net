CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Ip] NCHAR(30) NOT NULL, 
    [Type] NCHAR(10) NOT NULL, 
    [Continent_Code] NCHAR(10) NOT NULL, 
    [Continent_Name] NCHAR(20) NOT NULL, 
    [Country_Code] NCHAR(10) NOT NULL, 
    [Country_Name] NCHAR(20) NOT NULL, 
    [Region_Code] NCHAR(10) NOT NULL, 
    [Region_Name] NCHAR(20) NOT NULL, 
    [City] NCHAR(10) NOT NULL, 
    [Zip] NCHAR(10) NOT NULL, 
    [Latitude] NCHAR(20) NOT NULL, 
    [Longitude] NCHAR(20) NOT NULL
)
