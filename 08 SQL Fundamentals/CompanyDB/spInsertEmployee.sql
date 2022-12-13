CREATE PROCEDURE [dbo].[spInsertEmployee]
	@employeeName NVARCHAR(100) = NULL,
	@firstName NVARCHAR(50) = NULL,
	@lastName NVARCHAR(50) = NULL,
	@companyName NVARCHAR(20),
	@position NVARCHAR(30) = NULL,
	@street NVARCHAR(50),
	@city NVARCHAR(20) = NULL,
	@state NVARCHAR(50) = NULL,
	@zipCode NVARCHAR(50) = NULL
AS

	IF (@employeeName = NULL OR TRIM(@employeeName) = '')
	BEGIN
		PRINT 'Employee name must not be null nor an empty string.'
		RETURN
	END
	IF (@firstName = NULL OR TRIM(@firstName) = '')
	BEGIN
		PRINT 'First name must not be null nor an empty string.'
		RETURN
	END
	IF (@lastName = NULL OR TRIM(@lastName) = '')
	BEGIN
		PRINT 'Last name must not be an empty string.'
		RETURN
	END

	INSERT INTO [dbo].[Person] (FirstName, LastName)
	VALUES (@firstName, @lastName);
	DECLARE @personId INT = @@IDENTITY

	INSERT INTO [dbo].[Address] (Street, City, State, ZipCode)
	VALUES (@street, @city, @state, @zipCode);
	DECLARE @addressId INT = @@IDENTITY

	INSERT INTO [dbo].[Employee] (AddressId, PersonId, CompanyName, Position, EmployeeName)
	VALUES (@addressId, @personId, @companyName, @position, @employeeName);

	INSERT INTO [dbo].[Company] (Name, AddressId)
	VALUES (@companyName, @addressId);

RETURN 0
