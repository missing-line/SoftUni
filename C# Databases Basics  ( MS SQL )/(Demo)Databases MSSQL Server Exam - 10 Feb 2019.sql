--01. DDL
CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)
CREATE TABLE Spaceships
(
	Id  INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)


CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL ,
	BirthDate DATE NOT NULL
)
CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart 	DATETIME NOT NULL,
	JourneyEnd		DATETIME NOT NULL,  
	Purpose VARCHAR(11) CHECK(Purpose IN('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL

)
CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber VARCHAR(10) UNIQUE NOT NULL,
	JobDuringJourney VARCHAR(8)  CHECK(JobDuringJourney IN('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL,
)

--02. Insert
INSERT INTO Planets(Name) VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships(Name,Manufacturer,LightSpeedRate) VALUES
('Golf','VW',3),
('WakaWaka','Wakanda',4),
('Falcon9',	'SpaceX',1),
('Bed','Vidolov',6)

--03. Update
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--04. Delete
DELETE FROM TravelCards
WHERE JourneyId IN(1,2,3)

DELETE FROM Journeys
WHERE Id IN(1,2,3)

--05. Select All Travel Cards
SELECT CardNumber, JobDuringJourney 
FROM TravelCards
ORDER BY CardNumber

--06. Select All Colonists
SELECT Id,FirstName + ' ' + LastName  ,Ucn 
FROM Colonists
ORDER BY  FirstName, LastName ,Ucn 

--07. Select All Military Journeys
SELECT Id,convert(varchar, JourneyStart, 103) AS [JourneyStart]
		, convert(varchar, JourneyEnd, 103) AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--08. Select All Pilots
SELECT C.Id, C.FirstName + ' ' + C.LastName
FROM  Journeys AS J
	JOIN TravelCards T ON T.JourneyId = J.Id
	JOIN Colonists AS C ON C.Id = T.ColonistId
WHERE JobDuringJourney = 'Pilot'
ORDER BY C.Id

--09. Count Colonists
SELECT COUNT(*) 
FROM Colonists AS C
	JOIN TravelCards AS T ON T.ColonistId = C.Id
	JOIN Journeys AS J ON J.Id = T.JourneyId
WHERE J.Purpose = 'Technical'

--10. Select The Fastest Spaceship
SELECT TOP 1 S.Name ,S1.Name
FROM Spaceships AS S
	JOIN Journeys AS J ON J.SpaceshipId = S.Id
	JOIN Spaceports  AS S1 ON J.DestinationSpaceportId = S1.Id
ORDER BY S.LightSpeedRate DESC

--11. Select Spaceships With Pilots
SELECT T.Name ,T.Manufacturer FROM
(
SELECT DATEDIFF(YEAR,C.BirthDate, '2019-01-01') as Age
	   ,S.Name
	   ,S.Manufacturer
FROM Spaceships  AS S
	JOIN Journeys AS J ON J.SpaceshipId = S.Id
	JOIN TravelCards AS T ON T.JourneyId = J.Id
	JOIN Colonists AS C ON C.Id = T.ColonistId
WHERE T.JobDuringJourney = 'Pilot'
) AS  T
WHERE T.Age < 30
ORDER BY T.Name

--12. Select All Educational Mission
SELECT P.Name , S.Name
FROM Planets AS P
	JOIN Spaceports AS S ON S.PlanetId = P.Id
	JOIN Journeys AS J ON J.DestinationSpaceportId = S.Id
WHERE J.Purpose = 'Educational'
ORDER BY S.Name DESC


--13. Planets And Journeys
SELECT P.Name ,COUNT(J.Id)
FROM Planets AS P
	JOIN Spaceports AS S ON S.PlanetId = P.Id
	JOIN Journeys AS J ON J.DestinationSpaceportId = S.Id
GROUP BY P.Name
ORDER BY COUNT(J.Id) DESC, P.Name

--14. Extract The Shortest Journey
SELECT TOP 1
	T.Id 
	,T.P 
	, T.S 
	,T.Purpose
FROM
(
SELECT J.Id , P.Name AS P, S.Name AS S , J.Purpose
	   ,DATEDIFF(MINUTE, J.JourneyStart , J.JourneyEnd) AS L
FROM Journeys AS J
	JOIN Spaceports AS S ON S.Id = J.DestinationSpaceportId
	JOIN Planets AS P ON P.Id = S.PlanetId
) AS T
ORDER BY T.L

--15. Select The Less Popular Job
SELECT T.Id ,T.JOB FROM
(
	SELECT TOP 1 J.Id , T.JobDuringJourney AS JOB
		,DATEDIFF(HOUR, J.JourneyStart, J.JourneyEnd)	 AS DIFF	
	FROM Journeys AS J
		JOIN TravelCards AS T ON T.JourneyId = J.Id
		JOIN Colonists AS C ON C.Id = T.ColonistId
	ORDER BY DIFF DESC
) AS T 

--16. Select Special Colonists
SELECT T.JobDuringJourney, T.FULLNAME, T.R
FROM
(
SELECT T.JobDuringJourney
		,C.FirstName + ' ' + C.LastName AS FULLNAME	
		,ROW_NUMBER() OVER(PARTITION BY T.JobDuringJourney ORDER BY  C.BirthDate) AS R
FROM Journeys AS J
	JOIN TravelCards AS T ON T.JourneyId = J.Id
	JOIN Colonists AS C ON C.Id = T.ColonistId
) AS T
WHERE T.R = 2

--17. Planets and Spaceports
SELECT P.Name, COUNT(S.Id) AS C
FROM Planets AS P
	LEFT JOIN Spaceports AS S ON S.PlanetId = P.Id
GROUP BY P.Name
ORDER BY C DESC , P.Name

--18. Get Colonists Count
CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT AS
BEGIN
	DECLARE @count INT =(SELECT COUNT(*)
		FROM Colonists AS C
		JOIN TravelCards AS T ON T.JourneyId = C.Id
		JOIN Journeys AS J ON J.Id = T.JourneyId
		JOIN Spaceports AS S ON S.Id = J.DestinationSpaceportId
		JOIN Planets AS P ON P.Id = S.PlanetId AND P.Name = @PlanetName); 

	RETURN @count;
END;

--19. Change Journey Purpose
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(MAX))
AS
	
	IF ((SELECT Id FROM Journeys WHERE Id = @JourneyId) IS NULL)
		BEGIN
			
			RAISERROR('The journey does not exist!', 16 , 1);
			RETURN;
		END;
	IF((SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose)
		BEGIN
			
			RAISERROR('You cannot change the purpose!', 16 , 2);
			RETURN;
		END;
	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId

--20. Deleted Journeys
CREATE TRIGGER tr_DeleteJourney ON Journeys FOR DELETE
AS
	INSERT INTO DeletedJourneys(Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId)
	SELECT Id, JourneyStart, JourneyEnd, Purpose, DestinationSpaceportId, SpaceshipId FROM deleted




	