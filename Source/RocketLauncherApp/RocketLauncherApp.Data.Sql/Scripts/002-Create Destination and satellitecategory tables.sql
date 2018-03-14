 CREATE TABLE DESTINATIONS (Id INT IDENTITY(1,1) primary key, Name varchar(max))
 go
 CREATE TABLE SatelliteCategories (Id INT IDENTITY(1,1) primary key, Name varchar(max))
 go
 Alter table Satellites Add SatelliteCategoryId Int Foreign key References SatelliteCategories(Id)
 go
 Alter TAble Rockets Add DestinationId INT foreign key references Destinations(Id)