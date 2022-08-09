-- TASK 2
INSERT INTO Passengers
SELECT 
	CONCAT(FirstName, ' ', LastName) FullName,
	CONCAT(FirstName, LastName, '@gmail.com')Email
FROM Pilots
WHERE Id >= 5 AND Id <= 15
