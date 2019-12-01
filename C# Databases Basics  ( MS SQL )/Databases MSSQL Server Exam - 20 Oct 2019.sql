--1. DDL 
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	Password NVARCHAR (50) NOT NULL,
	Name NVARCHAR(50) ,
	Birthdate DATETIME ,
	Age INT CHECK(Age BETWEEN 14 AND 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName	NVARCHAR(25),
	LastName	NVARCHAR(25),
	Birthdate	DATETIME,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) --
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description NVARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2.Insert
INSERT INTO Employees(FirstName	,LastName,	Birthdate,	DepartmentId) VALUES
('Marlo'	,'O''Malley'		,'1958-9-21',	1),
('Niki'		,'Stanaghan'		,'1969-11-26',	4),
('Ayrton'	,'Senna'			,'1960-03-21',	9),
('Ronnie'	,'Peterson'			,'1944-02-14',	9),
('Giovanna'	,'Amati'			,'1959-07-20',	5)

INSERT INTO Reports(CategoryId	,StatusId	,OpenDate	,CloseDate	,Description	,UserId	,EmployeeId) VALUES
(1	,1,	'2017-04-13',	NULL,			'Stuck Road on Str.133',			6,	2),
(6	,3,	'2015-09-05',	'2015-12-06',	'Charity trail running',			3,	5),
(14	,2,	'2015-09-07',	NULL,			'Falling bricks on Str.58',			5,	2),
(4	,3,	'2017-07-03',	'2017-07-06',	'Cut off streetlight on Str.11',	1,	1)


--03. Update
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--04. Delete
DELETE FROM Reports
WHERE StatusId = 4

--05. Unassigned Reports
SELECT Description , FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate , Description

--06. Reports & Categories
SELECT R.Description ,C.Name 
FROM Reports AS R
	JOIN Categories AS C ON C.Id = R.CategoryId
ORDER BY  R.Description ,C.Name

--07. Most Reported Category
SELECT TOP 5
	C.Name, COUNT(R.Id) AS C
FROM Categories AS C
	JOIN Reports AS R ON R.CategoryId = C.Id
GROUP BY C.Name
ORDER BY C DESC, C.Name

-- 08. Birthday Report
SELECT 
	U.Username 
	, C.Name
FROM Reports AS R
	LEFT JOIN Categories AS C ON R.CategoryId = C.Id
	LEFT JOIN Users AS U ON U.Id = R.UserId
WHERE DAY(R.OpenDate) = DAY(U.Birthdate) AND MONTH(R.OpenDate) = MONTH(U.Birthdate)
ORDER BY U.Username , C.Name

-- 09. User per Employee
SELECT
	E.FirstName + ' ' + E.LastName AS F
	, COUNT(U.Id) AS C
FROM Reports AS R
	RIGHT JOIN Employees AS E ON E.Id = R.EmployeeId
	LEFT JOIN Users AS U ON U.Id = R.UserId
GROUP BY E.FirstName ,E.LastName
ORDER BY C DESC , F

--10. Full Info

SELECT 
	CASE 
		WHEN E.FirstName IS NULL AND E.LastName IS NULL THEN 'None'
		ELSE E.FirstName + ' ' + E.LastName
	END AS F
	,ISNULL( D.Name , 'None')
	,C.Name 
	,R.Description 
	,ISNULL( FORMAT( R.OpenDate, 'dd.MM.yyyy') , 'None'	)
	,S.Label 
	,ISNULL(U.Name , 'None')
FROM Reports AS R
	LEFT  JOIN Employees AS E ON E.Id = R.EmployeeId
	LEFT JOIN Categories AS C ON C.Id = R.CategoryId
	LEFT JOIN Status AS S ON S.Id = R.StatusId
	LEFT JOIN Users AS U ON U.Id = R.UserId
	LEFT JOIN Departments AS D ON D.Id = E.DepartmentId
ORDER BY E.FirstName DESC, E.LastName DESC, D.Name, C.Name, R.Description, R.OpenDate, S.Label, U.Name

--11. Hours to Complete
CREATE FUNCTION  udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT AS 
BEGIN
	IF(@StartDate IS NULL)
		BEGIN
			RETURN 0;
		END;
	IF(@EndDate IS NULL)
		BEGIN
			RETURN 0;
		END;
	DECLARE @total INT = DATEDIFF(HOUR, @StartDate, @EndDate);

	RETURN @total;
END;

--12. Assign Employee
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	BEGIN
		DECLARE @empId INT = (SELECT D.Id FROM Employees AS E
								JOIN Departments AS D ON D.Id = E.DepartmentId AND E.Id = @EmployeeId);

		DECLARE @repoId INT = (SELECT D.Id FROM Reports AS R
								JOIN Categories AS C ON C.Id = R.CategoryId AND R.Id = @ReportId
								JOIN Departments AS D ON D.Id = C.DepartmentId);

		IF(@empId <> @repoId)
			BEGIN;
				RAISERROR('Employee doesn''t belong to the appropriate department!',16 , 1);
				RETURN;
			END;

		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId

	END;



 







