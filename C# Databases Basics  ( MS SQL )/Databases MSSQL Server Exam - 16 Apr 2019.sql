--01. DDL
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	Range  INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime	 DATETIME,
	ArrivalTime		 DATETIME,
	Origin			NVARCHAR(50) NOT NULL,	
	Destination		NVARCHAR(50) NOT NULL,
	PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL

)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,	
	LastName NVARCHAR(30) NOT NULL,	
	Age INT NOT NULL, 
	Address NVARCHAR(30) NOT NULL,	
	PassportId NVARCHAR(11) NOT NULL --
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	Type NVARCHAR(30) NOT NULL,	
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
	LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(15, 2) NOT NULL
)

--02. Insert
INSERT INTO Planes(Name, Seats, Range) VALUES
('Airbus 336',	112,	5132),
('Airbus 330',	432,	5325),
('Boeing 369',	231,	2355),
('Stelt 297',	254,	2143),
('Boeing 338',	165,	5111),
('Airbus 558',	387,	1342),
('Boeing 128',	345,	5541)


INSERT INTO LuggageTypes(Type) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--03. Update
UPDATE Tickets
SET Price += Price * 0.13
WHERE FlightId = (
SELECT F.Id FROM Flights AS F
JOIN Tickets AS T ON T.FlightId = F.Id
WHERE F.Destination = 'Carlsbad')

--04. Delete
DELETE FROM Tickets
WHERE FlightId = (SELECT Id FROM Flights
WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. Trips
SELECT Origin, Destination FROM Flights
ORDER BY Origin, Destination

--06. The "Tr" Planes
SELECT * FROM Planes 
WHERE Name LIKE '%tr%'
ORDER BY Id, Name, Seats, Range

--07. Flight Profits
SELECT t.FlightId, SUM(t.Price) as [TotalPrice] FROM Flights AS f
	JOIN Tickets AS t ON t.FlightId = f.Id 
GROUP BY t.FlightId
ORDER BY TotalPrice desc, t.FlightId

--08. Passanger and Prices
SELECT TOP(10) p.FirstName
			, p.LastName
				, t.Price AS PRICE 
	FROM Passengers AS p
		JOIN Tickets AS T ON t.PassengerId = p.Id
ORDER BY PRICE DESC, p.FirstName, p.LastName

--09. Top Luggages
SELECT LT.Type, COUNT(LT.Id) AS C 
	FROM Passengers AS P
		JOIN Luggages AS L ON L.PassengerId = P.Id
		JOIN LuggageTypes AS LT ON LT.Id = L.LuggageTypeId
GROUP BY LT.Type
ORDER BY C DESC, LT.Type

--10. Passanger Trips
SELECT  FirstName + ' ' + LastName AS [FULLNAME]
		,F.Origin
		,F.Destination
FROM Passengers AS PS
	JOIN Tickets AS T ON T.PassengerId = PS.Id
	JOIN Flights AS F ON F.Id = T.FlightId
ORDER BY FULLNAME , Origin, Destination

--11. Non Adventures People
SELECT   P.FirstName
		,P.LastName
		,P.Age 
	FROM Tickets AS T
		RIGHT JOIN Passengers AS P ON P.Id = T.PassengerId
WHERE T.PassengerId IS NULL
ORDER BY AGE DESC, FirstName, LastName

--12. Lost Luggages
SELECT p.PassportId
	   ,p.Address 
    FROM Passengers AS p
		LEFT JOIN Luggages AS l ON l.PassengerId = p.Id
    WHERE l.Id IS NULL
 ORDER BY p.PassportId, p.Address

 --13. Count of Trips
SELECT P.FirstName
		, P.LastName
		, COUNT(T.Id) AS TRIPS 
FROM Passengers AS P
		LEFT JOIN Tickets AS T ON T.PassengerId = P.Id
GROUP BY P.FirstName, P.LastName
ORDER BY TRIPS DESC , P.FirstName, P.LastName

--14. Full Info
SELECT   P.FirstName + ' ' + P.LastName AS FULLNAME
		 ,PL.Name
		 ,F.Origin + ' - '+ F.Destination
		 ,LT.Type
FROM Passengers AS P
		JOIN Tickets AS T ON T.PassengerId = P.Id
		JOIN Flights AS F ON F.Id = T.FlightId
		JOIN Planes AS PL ON PL.Id = F.PlaneId
		JOIN Luggages AS L ON L.Id = T.LuggageId
		JOIN LuggageTypes AS LT ON LT.Id = L.LuggageTypeId
ORDER BY FULLNAME ,PL.Name,F.Origin,  F.Destination ,LT.Type

--15. Most Expesnive Trips
SELECT TEMP.FirstName,TEMP.LastName, TEMP.Destination, TEMP.Price FROM
(
	SELECT P.FirstName, P.LastName, F.Destination ,T.Price
			,ROW_NUMBER() OVER(PARTITION BY  P.FirstName, P.LastName ORDER BY  T.Price DESC) AS[RANK]
	FROM Passengers AS P
		JOIN Tickets AS  T ON T.PassengerId = P.Id
		JOIN Flights AS F ON F.Id = T.FlightId
) AS  TEMP
WHERE TEMP.RANK = 1
ORDER BY TEMP.Price DESC, TEMP.FirstName,TEMP.LastName, TEMP.Destination

--16. Destinations Info
SELECT F.Destination, COUNT(T.Id) AS C 
FROM Tickets AS T
	RIGHT JOIN Flights AS F ON F.Id = T.FlightId
GROUP BY F.Destination
ORDER BY C DESC ,  F.Destination

--17. PSP
SELECT  PL.Name
		,PL.Seats
		, COUNT(T.PassengerId) AS C 
FROM Planes AS PL
	     LEFT JOIN Flights AS F ON F.PlaneId = PL.Id
		 LEFT JOIN  Tickets AS T ON T.FlightId = F.Id	    
GROUP BY PL.Name, PL.Seats
ORDER BY  C DESC,  PL.Name,PL.Seats

--18. Vacation
CREATE FUNCTION  udf_CalculateTickets(@origin NVARCHAR(MAX), @destination NVARCHAR(MAX), @peopleCount INT) 
RETURNS NVARCHAR(MAX)
AS 
	BEGIN
		IF(@peopleCount <= 0)
			BEGIN
				RETURN 'Invalid people count!';
			END

		DECLARE @FLIGHT INT = (SELECT Id FROM Flights WHERE Origin = @origin AND Destination = @destination);
		
		IF(@FLIGHT IS NULL)
			BEGIN
				RETURN 'Invalid flight!';
			END	
		
		DECLARE @price MONEY = (SELECT T.Price * @peopleCount 
								FROM Tickets AS T
								JOIN Flights AS F ON F.Id = T.FlightId AND F.Id = @FLIGHT);

		RETURN 'Total price ' + CAST(@price AS nvarchar(MAX));
	END

--19.	Wrong Data
CREATE PROCEDURE usp_CancelFlights
AS 
	BEGIN
		UPDATE Flights
		SET ArrivalTime = NULL , 
			DepartureTime = NULL
		WHERE ArrivalTime > DepartureTime 
	END;

--20. Deleted Planes
CREATE TRIGGER tr_CALCELPLANES ON Planes FOR DELETE
AS
	INSERT INTO DeletedPlanes(Id,Name,Seats, Range)
	SELECT Id,Name,Seats, Range FROM deleted


