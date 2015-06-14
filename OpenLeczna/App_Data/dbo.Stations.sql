CREATE TABLE [dbo].[Stations]
(
	[Name] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [GeoPositionId] INT NULL, 
    CONSTRAINT [FK_Stations_ToGeoPositions] FOREIGN KEY ([GeoPositionId]) REFERENCES [GeoPositions]([Id])
)
