CREATE TABLE Rockets(Id INT IDENTITY(1,1) primary key, Name varchar(max), IsActive BIT)
GO
CREATE TABLE Satellites(Id INT IDENTITY(1,1),RocketId INT Foreign key references Rockets(Id),  Name varchar(max), IsActive BIT)