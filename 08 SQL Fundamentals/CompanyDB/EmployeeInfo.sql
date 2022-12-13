CREATE VIEW [dbo].[EmployeeInfo]
	AS SELECT
		e.Id AS EmployeeId,
		COALESCE(e.EmployeeName, p.FirstName + ' ' + p.LastName) AS EmployeeFullName,
		a.ZipCode + '_' + a.State + ',' + a.City + '-' + a.Street EmployeeFullAddress,
		c.Name + '(' + e.Position + ')' EmployeeCompanyInfo
	FROM [dbo].[Employee] e
	JOIN [dbo].[Person] p ON p.Id = e.PersonId
	JOIN [dbo].[Address] a ON a.Id = e.AddressId
	JOIN [dbo].[Company] c ON c.AddressId = a.Id