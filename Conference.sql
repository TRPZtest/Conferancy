DROP TABLE IF EXISTS Users
DROP TABLE IF EXISTS Regions
DROP TABLE IF EXISTS SortingProperties
DROP TABLE IF EXISTS SortingColumns

Create TABLE Regions(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50)
)

Create table Users(
	Id BIGINT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,	
	Password VARCHAR(200	) NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL,
	Birthday Date NOT NULL, 
	PhoneNumber VARCHAR(15),
	RegionId INT NOT NULL Foreign KEY REFERENCES Regions(id),	
)

GO
Create Table SortingColumns(
	Id BIGINT IDENTITY PRIMARY KEY,
	ColumnName VARCHAR(50) NOT NULL,	
)

Create table SortingProperties(
	Id BIGINT IDENTITY PRIMARY KEY,	
	DisplayName VARCHAR(50) NOT NULL,
	IsDescending BIT NOT NULL,
	SortingColumnId BIGINT NOT NULL FOREIGN KEY REFERENCES SortingColumns(Id)
)

Go
CREATE OR ALTER VIEW UsersView
AS
SELECT  
	u.Id,
	CONCAT(u.FirstName, ' ', u.LastName) AS FullName,
	datediff(year,[Birthday], getdate()) AS Age,
	r.Name as RegionName,
	u.Email,
	u.PhoneNumber
FROM Users u
JOIN Regions r ON r.Id = u.RegionID

GO 
INSERT INTO SortingColumns
VALUES
('FullName'),
('Age'),
('RegionName')

GO
INSERT INTO SortingProperties VALUES
('FullName a-b', 0, 1),
('FullName b-a', 1, 1),
('Age 0-9', 0, 2),
('Age 9-0', 1, 2),
('Regions a-b', 0, 3),
('Regions b-a', 1, 3)

insert INTO Regions
VALUES
('Poltava'),
('Kyiv'),
('Lutsk'),
('Donetsk'),
('Chernihiv')

insert INTO Users
VALUES
('John', 'Doe', 'Password', 'emailSample2@gmail.com','2000-3-11', '+380661918722', 1)

INSERT INTO Users
VALUES ('Bob', 'Johnson', 'Secret123', 'emailSample3@gmail.com', '1998-5-20', '+12015559999', 1);

INSERT INTO Users
VALUES ('Emily', 'Davis', 'Pass1234', 'emailSample4@gmail.com', '2002-9-3', '+4402034567890', 2);


