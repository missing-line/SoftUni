--01.DDL
CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	CountryCode VARCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(15, 2) NOT NULL --
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(15,2) NOT NULL,
	Type NVARCHAR(30) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id  INT PRIMARY KEY IDENTITY,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	BookDate	  DATE NOT NULL,
	ArrivalDate	  DATE NOT NULL,
	ReturnDate	  DATE NOT NULL,
	CancelDate    DATE,
	CONSTRAINT BookDate_CH CHECK (BookDate < ArrivalDate),
	CONSTRAINT ArrivalDateReturnDate_CH CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id  INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20) ,
	LastName NVARCHAR(50) NOT NULL,
	CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,

)

CREATE TABLE AccountsTrips
(
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	TripId  INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
	Luggage INT CHECK(Luggage >= 0),
	PRIMARY KEY(AccountId, TripId)
)

--02. Insert
INSERT INTO Accounts(FirstName,MiddleName,LastName,CityId,BirthDate,Email) VALUES
('John',	'Smith',	'Smith',	'34',	'1975-07-21',	'j_smith@gmail.com'),
('Gosho',	NULL,	'Petrov',	'11',		'1978-05-16',	'g_petrov@gmail.com'),
('Ivan',	'Petrovich',	'Pavlov',	'59',	'1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich',	'Wilhelm',	'Nietzsche',	'2',	'1844-10-15',	'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId,BookDate,ArrivalDate,ReturnDate,CancelDate) VALUES
(101,	'2015-04-12',	'2015-04-14',	'2015-04-20',	'2015-02-02'),
(102,	'2015-07-07',	'2015-07-15',	'2015-07-22',	'2015-04-29'),
(103,	'2013-07-17',	'2013-07-23',	'2013-07-24',	NULL),
(104,	'2012-03-17',	'2012-03-31',	'2012-04-01',	'2012-01-10'),
(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)
	
--03. Update
UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN(5,7,9)

--04. Delete
DELETE FROM AccountsTrips 
WHERE AccountId = 47

DELETE FROM Accounts
WHERE Id = 47

--05. Bulgarian Cities
SELECT Id, Name FROM Cities
WHERE CountryCode = 'BG'
ORDER BY Name

--06. People Born After 1991
SELECT  CONCAT(FirstName  , ISNULL(' ' + MiddleName, '' ), ' ' , LastName )
		,YEAR(BirthDate)
FROM Accounts
WHERE YEAR(BirthDate) > '1991'
ORDER BY YEAR(BirthDate) DESC, FirstName

--07. EEE-Mails

SELECT A.FirstName,A.LastName, FORMAT(A.BirthDate,'MM-dd-yyyy'),C.Name, A.Email 
FROM Accounts AS A
	JOIN Cities AS C ON C.Id = A.CityId
WHERE A.Email LIKE 'e%' 
ORDER BY C.Name DESC

--08. City Statistics
SELECT C.Name, COUNT(H.Id) AS C
FROM Cities AS C
LEFT JOIN Hotels AS H ON H.CityId = C.Id
GROUP BY C.Name
ORDER BY C DESC , C.Name

--09. Expensive First Class Rooms
SELECT R.Id, R.Price, H.Name, C.Name 
FROM Rooms AS R
	JOIN Hotels AS H ON R.HotelId = H.Id
	JOIN Cities AS C ON C.Id = H.CityId
WHERE R.Type = 'First Class'
ORDER BY R.Price DESC, R.Id

--10. Longest and Shortest Trips
SELECT 
	a.Id AS [AccountId],  a.FirstName  + ' ' + a.LastName AS [FullName] 
	,MAX(DATEDIFF(DAY,ArrivalDate,ReturnDate)) as [LongestTrip]
	,MIN(DATEDIFF(DAY,ArrivalDate,ReturnDate)) as [ShortTrip]
FROM AccountsTrips AS ar
	JOIN Accounts AS a ON a.Id = ar.AccountId AND a.MiddleName IS NULL
	JOIN Trips AS t ON t.Id = ar.TripId AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName,a.LastName
ORDER BY [LongestTrip] DESC,  [AccountId]

--11. Metropolis
SELECT TOP 5  C.Id, C.Name ,C.CountryCode , COUNT(A.Id) AS C
FROM Cities AS C
	JOIN Accounts AS A  ON A.CityId = C.Id
GROUP BY   C.Id, C.Name ,C.CountryCode
ORDER BY C DESC

--12. Romantic Getaways
SELECT
  A.Id,
  A.Email,
  C.Name   AS City,
  COUNT(T.Id) AS Trips
FROM Accounts A
  JOIN AccountsTrips AT on A.Id = AT.AccountId
  JOIN Trips T on AT.TripId = T.Id
  JOIN Rooms R on T.RoomId = R.Id
  JOIN Hotels H on R.HotelId = H.Id
  JOIN Cities C on H.CityId = C.Id
WHERE A.CityId = H.CityId
GROUP BY A.Id, A.Email, A.CityId, C.Name
ORDER BY Trips DESC, A.Id

--13. Lucrative Destinations
SELECT TOP 10
	C.Id
	, C.Name
	,SUM(H.BaseRate + R.Price) AS [Total Revenue]
	,COUNT(T.Id) AS C
FROM Cities AS C
	JOIN Hotels AS H ON C.Id = H.CityId
	JOIN Rooms AS R ON R.HotelId = H.Id
	JOIN Trips AS T ON T.RoomId = R.Id
WHERE YEAR(T.BookDate) = '2016'
GROUP BY C.Id, C.Name
ORDER BY [Total Revenue] DESC, C DESC

--14. Trip Revenues
SELECT T.Id, H.Name, R.Type,
CASE
	WHEN T.CancelDate IS NOT NULL THEN 0
	ELSE SUM(R.Price + H.BaseRate)
END AS RAVENU
FROM Trips AS T
	JOIN Rooms AS R ON R.Id = T.RoomId
	JOIN Hotels AS H ON H.Id = R.HotelId
	JOIN AccountsTrips AS AT ON AT.TripId = T.Id
GROUP BY T.Id, H.Name ,R.Type, T.CancelDate
ORDER by R.Type , T.Id

--15. Top Travelers
--Order them by Total Revenue (descending), then by Trip count (descending)
SELECT T.Id, T.Email,T.CountryCode ,T.C 
FROM 
(
SELECT A.Id, A.Email,C.CountryCode 
,COUNT(T.Id) AS C
,ROW_NUMBER() OVER(PARTITION BY  C.CountryCode  ORDER BY COUNT(T.Id) DESC) AS R
FROM AccountsTrips AS AT
	JOIN Accounts AS A ON A.Id = AT.AccountId
	JOIN Trips AS T ON T.Id = AT.TripId
	JOIN Rooms AS R ON R.Id = T.RoomId
	JOIN Hotels AS H ON H.Id = R.HotelId
	JOIN Cities AS C ON C.Id = H.CityId
GROUP BY A.Id, A.Email,C.CountryCode 
) AS T
WHERE T.R = 1
ORDER BY T.C DESC, T.Id

--16. Luggage Fees
SELECT AT.TripId,
	SUM(AT.Luggage) AS C
	,CASE  
		WHEN SUM(AT.Luggage) > 5 THEN '$' + CAST( SUM(AT.Luggage) * 5 AS nvarchar )
		ELSE '$0'
	 END AS [Fee] 
FROM AccountsTrips AS AT 
	 JOIN Trips AS T ON T.Id = AT.TripId
GROUP BY AT.TripId
HAVING SUM(AT.Luggage) > 0
ORDER BY C DESC


--17. GDPR Violation
SELECT T.Id ,  CONCAT(A.FirstName , ISNULL(' ' + A.MiddleName, '') , ' ' , A.LastName) AS FULLNAME
		,C.Name
		,C1.Name
		,CASE
			WHEN T.CancelDate IS NULL THEN CAST( DATEDIFF(DAY, T.ArrivalDate, T.ReturnDate) AS nvarchar) + ' days'
			ELSE 'Canceled'
		 END 	
FROM Accounts AS A
	JOIN Cities AS C ON C.Id = A.CityId
	JOIN AccountsTrips AS AT ON AT.AccountId = A.Id
	JOIN Trips AS T ON T.Id = AT.TripId
	JOIN Rooms AS R ON R.Id = T.RoomId
	JOIN Hotels AS H ON H.Id = R.HotelId
	JOIN Cities AS C1 ON C1.Id = H.CityId
ORDER BY FULLNAME , T.Id

--18. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX) AS
BEGIN
	DECLARE @availableRoom NVARCHAR(MAX) = 
		(
			SELECT TOP(1) CONCAT('Room ', r.Id, ': ', r.Type, ' (', r.Beds, ' beds) - ', '$', (h.BaseRate + r.Price) * @People)     
				FROM Rooms AS r
					JOIN Hotels AS h ON h.Id = r.HotelId 
						AND r.HotelId = @HotelId 
						AND r.Beds > @People
					JOIN Trips AS t ON t.RoomId = r.Id	 
						AND t.CancelDate IS NULL 	
			WHERE @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
		 );
		
		IF 	@availableRoom IS NULL
			BEGIN
			RETURN 'No rooms available';
			END	

	RETURN  @availableRoom; 	
END;

--19. Switch Room
CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
	AS
		BEGIN
			DECLARE @hotelRoomId INT = (SELECT H.Id
                                  FROM Hotels H
                                    JOIN Rooms R on H.Id = R.HotelId
                                  WHERE R.Id = @TargetRoomId);
			DECLARE @hotelTargetId INT = 
			(
				SELECT H.Id
                       FROM Hotels H
                         JOIN Rooms R on H.Id = R.HotelId
                         JOIN Trips T on R.Id = T.RoomId
                       WHERE T.Id = @TripId
			);
			IF (@hotelRoomId != @hotelTargetId)
				BEGIN
					RAISERROR('Target room is in another hotel!',16,1);
					RETURN;
				END
			
			DECLARE @PeopleCount INT = (SELECT COUNT(*)
                                FROM AccountsTrips
                                WHERE TripId = @TripId)

			 DECLARE @TargetRoomBeds INT = (SELECT Beds
                                   FROM Rooms
                                   WHERE Id = @TargetRoomId)

			IF (@PeopleCount > @TargetRoomBeds)		
				BEGIN
					RAISERROR('Not enough beds in target room!',16,2);
					RETURN;
				END

		UPDATE Trips 
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
		END

--20. Cancel Trip
CREATE TRIGGER tr_CalcelTrip ON Trips  INSTEAD OF DELETE
AS
	BEGIN
		 UPDATE Trips
      		 SET CancelDate = GETDATE()
     		 WHERE Id IN (SELECT Id FROM deleted
                  			 WHERE CancelDate IS NULL)
	END;