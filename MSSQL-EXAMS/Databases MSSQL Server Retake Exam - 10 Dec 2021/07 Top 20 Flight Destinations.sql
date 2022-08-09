--Task 7
SELECT TOP(20) 
	fd.Id DestinationId,
	[Start],
	P.FullName,
	a.AirportName,
	fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Airports AS a ON fd.AirportId = a.Id
WHERE Day([Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC,a.AirportName
