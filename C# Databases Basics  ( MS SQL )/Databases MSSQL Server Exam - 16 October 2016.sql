--1: DDL
CREATE TABLE Flights
(
	FlightID INT ,
	DepartureTime DATETIME NOT NULL,
	ArrivalTime DATETIME NOT NULL,
	Status VARCHAR(9) CHECK (Status IN('Departing', 'Delayed', 'Arrived', 'Cancelled')),
	OriginAirportID INT  NOT NULL,
	DestinationAirportID INT  NOT NULL,
	AirlineID INT  NOT NULL,
	CONSTRAINT PK_Flights PRIMARY KEY(FlightID),
	CONSTRAINT FK_OriginAirport FOREIGN KEY(OriginAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_DestinationAirpor FOREIGN KEY(DestinationAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_Airline FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
)

CREATE TABLE Tickets
(
	TicketID INT,
	Price DECIMAL(8,2) NOT NULL,
	Class VARCHAR(6) CHECK(Class IN('First', 'Second', 'Third')),
	Seat VARCHAR(5) NOT NULL,
	CustomerID  INT NOT NULL,
	FlightID INT  NOT NULL,
	CONSTRAINT PK_Tickets PRIMARY KEY(TicketID),
	CONSTRAINT FK_Customer FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_Flight FOREIGN KEY(FlightID) REFERENCES Flights(FlightID),
)

--DML - 01. Data Insertion
INSERT INTO Flights(FlightID,DepartureTime,ArrivalTime,Status,OriginAirportID,DestinationAirportID,AirlineID) VALUES
(1,	'2016-10-13 06:00 AM',	'2016-10-13 10:00 AM'	,'Delayed'	,1,	4,	1),
(2,	'2016-10-12 12:00 PM',	'2016-10-12 12:01 PM',	'Departing',1,  3,	2),
(3,	'2016-10-14 03:00 PM',	'2016-10-20 04:00 AM'	,'Delayed',	4,	2,	4),
(4,'2016-10-12 01:24 PM',	'2016-10-12 4:31 PM',	'Departing',3,	1,	3),
(5,	'2016-10-12 08:11 AM',	'2016-10-12 11:22 PM',	'Departing',4,	1,	1),
(6,	'1995-06-21 12:30 PM',	'1995-06-22 08:30 PM',	'Arrived',	2,	3,	5),
(7,	'2016-10-12 11:34 PM',	'2016-10-13 03:00 AM',	'Departing',2,	4,	2),
(8,	'2016-11-11 01:00 PM',	'2016-11-12 10:00 PM',	'Delayed',	4,	3,	1),
(9,	'2015-10-01 12:00 PM',	'2015-12-01 01:00 AM',	'Arrived',	1,	2,	1),
(10,'2016-10-12 07:30 PM',	'2016-10-13 12:30 PM',	'Departing',2,	1,	7)


INSERT INTO Tickets(TicketID,Price,Class,Seat,CustomerID,FlightID) VALUES
(1,	3000.00,	'First',	'233-A',		3,		8),
(2,	1799.90,	'Second',	'123-D',		1,		1),
(3,	1200.50,	'Second',	'12-Z',			2,		5),
(4,	410.68,		'Third',	'45-Q',			2,		8),
(5,	560.00,		'Third',	'201-R',		4,		6),
(6,	2100.00,	'Second',	'13-T',			1,		9),
(7,	5500.00	,	'First',	'98-O',			2,		7)

--DML - 02. Update Flights
UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

--DML - 03. Update Tickets
UPDATE Tickets
SET Price += Price * 0.5
WHERE TicketID  IN(
	SELECT T.TicketID FROM Flights AS F
	JOIN Airlines AS A ON A.AirlineID = F.AirlineID
	JOIN Tickets AS T ON T.FlightID  = F.FlightID
	WHERE A.Rating = 200
);


--DML - 04. Table Creation
CREATE TABLE CustomerReviews
(
	ReviewID INT,
	ReviewContent VARCHAR(255) NOT NULL,
	ReviewGrade INT CHECK(ReviewGrade >= 0 AND ReviewGrade <= 10),
	AirlineID 	INT NOT NULL,
	CustomerID	INT NOT NULL,
	CONSTRAINT PK_ReviewKey PRIMARY KEY(ReviewID),
	CONSTRAINT FK_AirlineKey FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
	CONSTRAINT FK_CustomerKeyy FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
)

CREATE TABLE CustomerBankAccounts
(
	AccountID INT,
	AccountNumber VARCHAR(10) UNIQUE,
	Balance DECIMAL(10,2) NOT NULL,
	CustomerID INT NOT NULL,
	CONSTRAINT PK_AccountKey PRIMARY KEY(AccountID),
	CONSTRAINT FK_CustomerKey FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),

)

--DML - 05. Fillin New Tables

INSERT INTO CustomerReviews(ReviewID,ReviewContent,ReviewGrade,AirlineID,CustomerID) VALUES
(1,	'Me is very happy. Me likey this airline. Me good.',	10,	1,	1),
(2,	'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!',	10,	1,	4),
(3,	'Meh...',	5,	4,	3),
(4,	'Well Ive seen better, but Ive certainly seen a lot worse...',	7,	3,	5)





INSERT INTO CustomerBankAccounts(AccountID,AccountNumber,Balance,CustomerID) VALUES
(1,	'123456790',	2569.23,	1),
(2,	'18ABC23672',	14004568.23,	2),
(3,	'F0RG0100N3',	19345.20,	5)


--Querying - 01. Extract All Tickets
SELECT TicketID, Price, Class, Seat FROM Tickets 
ORDER BY TicketID

--Querying - 02. Extract All Customers
SELECT CustomerID, FirstName + ' ' + LastName AS FULLNAME
,Gender
FROM Customers 
ORDER BY FULLNAME, CustomerID

--Querying - 03. Extract Delayed Flights

SELECT FlightID, DepartureTime, ArrivalTime
FROM Flights 
WHERE Status = 'Delayed'
ORDER BY FlightID

-- Querying - 04. Top 5 Airlines

SELECT DISTINCT TOP(5)  A.AirlineID, A.AirlineName, A.Nationality,  A.Rating
	FROM Airlines AS A
		JOIN Flights AS F ON F.AirlineID = A.AirlineID
ORDER BY Rating DESC, AirlineID ASC

--Querying - 05. All Tickets Below 5000

SELECT T.TicketID,	A.AirportName,	C.FirstName + ' ' + C.LastName
	FROM Tickets as T
JOIN Customers AS C ON C.CustomerID = T.CustomerID
JOIN Flights AS F ON T.FlightID = F.FlightID
JOIN AirportS AS A ON A.AirportID = F.DestinationAirportID
WHERE Price < 5000 AND Class = 'First'

-- Querying - 06. Customers From Home

SELECT DISTINCT C.CustomerID,C.FirstName + ' ' + C.LastName, T.TownName  FROM Customers AS C
JOIN Towns AS T ON T.TownID = C.HomeTownID
JOIN Airports AS A ON A.TownID = T.TownID
JOIN Flights AS F ON F.OriginAirportID = A.AirportID
JOIN Tickets AS TT ON TT.CustomerID = C.CustomerID and F.FlightID = TT.FlightID
WHERE F.Status = 'Departing'

--Querying - 07. Customers who will fly

SELECT distinct C.CustomerID, C.FirstName + ' ' + C.LastName, DATEDIFF(YEAR, C.DateOfBirth, '2016') AS Age FROM Customers AS C
JOIN Tickets AS T ON T.CustomerID = C.CustomerID
JOIN Flights AS F ON F.FlightID = T.FlightID
WHERE F.Status = 'Departing'
ORDER BY Age, C.CustomerID asc

--Querying - 08. Top 3 Customers Delayed

SELECT TOP 3 C.CustomerID, C.FirstName + ' ' + C.LastName  AS FULLNAME, T.Price, A.AirportName FROM Tickets AS T
JOIN Customers AS C ON C.CustomerID = T.CustomerID
JOIN Flights AS F ON F.FlightID = T.FlightID
JOIN Airports AS A ON A.AirportID = F.DestinationAirportID
WHERE F.Status = 'Delayed'
ORDER BY T.Price DESC, C.CustomerID

-- Querying - 09. Last 5 Departing Flights

SELECT  T.FlightID, T.DepartureTime ,T.ArrivalTime, T.ORIGIN, T.AirportName 
FROM
(
	SELECT TOP(5) F.FlightID, F.DepartureTime , F.ArrivalTime ,A1.AirportName AS ORIGIN , A.AirportName
		FROM Flights AS F
			JOIN Airports AS A ON A.AirportID = F.DestinationAirportID
			JOIN Airports AS A1 ON A1.AirportID = F.OriginAirportID		
	WHERE F.Status = 'Departing'
	ORDER BY F.DepartureTime DESC
) AS T
ORDER BY T.DepartureTime , T.FlightID


--Querying - 10. Customers Below 21

SELECT DISTINCT
	C.CustomerID
	, C.FirstName + ' ' + C.LastName AS  FULLNAME
	, DATEDIFF(YEAR, C.DateOfBirth, '2016') AS Age
FROM Customers AS C
	JOIN Tickets AS T ON T.CustomerID = C.CustomerID
	JOIN Flights AS F ON F.FlightID = T.FlightID
WHERE F.Status = 'Arrived' AND DATEDIFF(YEAR, C.DateOfBirth, '2016') < 21
ORDER BY Age DESC, C.CustomerID


--Querying - 11. AIrports and Passengers

SELECT A.AirportID, A.AirportName, COUNT(*) FROM Airports AS A
JOIN Flights AS F ON F.OriginAirportID = A.AirportID
JOIN Tickets AS T ON T.FlightID = F.FlightID
WHERE F.Status = 'Departing'
GROUP BY A.AirportID, A.AirportName
ORDER BY A.AirportID ASC

--Programmibility - 01. Submit Review

CREATE PROCEDURE usp_SubmitReview(@CustomerID INT,
								  @ReviewContent VARCHAR(MAX),
								  @ReviewGrade INT,
								  @AirlineName VARCHAR(MAX))
AS
	BEGIN 
		DECLARE @AirlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @AirlineName);
		IF(@AirlineId IS NULL)
			BEGIN
				RAISERROR('Airline does not exist.',16, 1);
				RETURN;
			END;
		DECLARE @LASTID INT = ISNULL((SELECT IDENT_CURRENT('CustomerReviews')), 0) + 1

		INSERT INTO CustomerReviews(ReviewID,ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
			(@LASTID, @ReviewContent,   @ReviewGrade, @AirlineId, @CustomerID)
	END;

--Programmibility - 02. Ticket Purchase

CREATE PROCEDURE usp_PurchaseTicket(@CustomerID INT,
									@FlightID INT,
									@TicketPrice DECIMAL(8,2),
									@Class VARCHAR(6),
									@Seat VARCHAR(5))
AS
	BEGIN
		DECLARE @currenntBalance DECIMAL(10,2) = (SELECT Balance FROM CustomerBankAccounts 
													WHERE CustomerID = @CustomerID);

		IF(ISNULL(@currenntBalance, 0) < @TicketPrice )
			BEGIN
				RAISERROR('Insufficient bank account balance for ticket purchase.', 16 , 1);
				RETURN;
			END;

		DECLARE @lastId INT = (SELECT MAX(TicketID) FROM Tickets) + 1;

		INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID ,FlightID) VALUES
		(@lastId, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

		UPDATE CustomerBankAccounts
		SET Balance -= @TicketPrice
		WHERE CustomerID = @CustomerID
		
	END;




