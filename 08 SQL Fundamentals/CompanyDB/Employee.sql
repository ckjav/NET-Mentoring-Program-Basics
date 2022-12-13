CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY,
	AddressId INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Address](Id),
	PersonId INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Person](Id),
	CompanyName NVARCHAR(20),
	Position NVARCHAR(30),
	EmployeeName NVARCHAR(100)
)
