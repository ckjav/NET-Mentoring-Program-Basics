MERGE INTO Person AS TARGET
USING (VALUES
	(1, 'Andrew', 'White')
)
AS SOURCE([ID], FirstName, LastName)
ON TARGET.[ID] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT (FirstName, LastName)
VALUES (FirstName, LastName);