--Task 5
--Extract information about all the Tourists 
--name, age, phone number and nationality.
--Order the result by nationality (ascending),
--then by age (descending), 
--and then by tourist name (ascending).

SELECT 
	[Name],
	Age,
	PhoneNumber,
	Nationality
FROM Tourists
ORDER BY Nationality ASC,Age DESC,[Name] ASC
