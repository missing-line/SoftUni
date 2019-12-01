--01. DDL
CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName   NVARCHAR(30) NOT NULL,
	MiddleName  NVARCHAR(25),
	LastName    NVARCHAR(30) NOT NULL,
	Age INT CHECK (Age >= 5 AND Age <= 100),
	Address  NVARCHAR(50) ,
	Phone  NVARCHAR(10),
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	[Name]  NVARCHAR(20) NOT NULL,
	Lessons INT CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade >= 2 AND Grade <= 6	)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date  DATETIME,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
)

CREATE TABLE StudentsExams
(
	StudentId  INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(15,2) CHECK(Grade >= 2 AND Grade <= 6	),
	PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone VARCHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
	PRIMARY KEY (StudentId, TeacherId)
)

--02. Insert
INSERT INTO Teachers(FirstName,	LastName,	[Address],	Phone,	SubjectId) VALUES
('Ruthanne',	'Bamb',	'84948 Mesta Junction',	'3105500146',	6),
('Gerrard',	'Lowin',	'370 Talisman Plaza',	'3324874824',	2),
('Merrile',	'Lambdin',	'81 Dahle Plaza',	'4373065154',	5),
('Bert',	'Ivie',	'2 Gateway Circle',	'4409584510',	4)

INSERT INTO Subjects([Name], Lessons) VALUES
('Geometry'	,12),
('Health'	,10),
('Drama'	,7),
('Sports'	,9)

--03. Update
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN(1,2) AND Grade >= 5.50

--04. Delete
DELETE FROM StudentsTeachers
WHERE TeacherId IN(SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--05. Teen Students
SELECT FirstName , LastName ,Age FROM Students
WHERE Age >= 12
ORDER BY FirstName , LastName ,Age

--06. Cool Addresses
SELECT CONCAT(FirstName, ' ' , MiddleName, ' ' , LastName) 
	   ,Address 
FROM Students
WHERE Address LIKE '%road%'
ORDER BY FirstName , LastName ,Address

--07. 42 Phones
SELECT FirstName	   
	   ,Address
	   ,Phone
FROM Students
WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName

--08. Students Teachers
SELECT S.FirstName, S.LastName, COUNT(T.Id)
FROM Teachers AS  T
	JOIN StudentsTeachers AS ST ON ST.TeacherId = T.Id
	JOIN Students AS S ON S.Id = ST.StudentId
GROUP BY S.FirstName, S.LastName

--09. Subjects with Students
SELECT T.FirstName + ' '+ T.LastName AS FullName
	   , S.Name  + '-' + CAST(S.Lessons AS nvarchar) as Subjects
	   ,COUNT(ST.StudentId) AS StudentsCount
FROM Teachers AS T
JOIN Subjects AS S ON S.Id = T.SubjectId
JOIN StudentsTeachers AS ST ON ST.TeacherId = T.Id
GROUP BY T.FirstName , T.LastName, S.Name , S.Lessons
order by StudentsCount DESC , FullName, Subjects

--10. Students to Go
SELECT  S.FirstName + ' ' + S.LastName AS FullName
FROM Students AS  S
WHERE S.Id NOT IN(SELECT SE.StudentId FROM StudentsExams AS SE
		  JOIN Students AS S ON S.Id = SE.StudentId)
ORDER BY FullName

--11. Busiest Teachers
SELECT TOP 10 T.FirstName , T.LastName , COUNT(ST.StudentId) AS C
FROM Teachers AS T
	JOIN StudentsTeachers AS ST ON T.Id = ST.TeacherId
GROUP BY  T.FirstName , T.LastName
ORDER BY C DESC, T.FirstName , T.LastName

--12. Top Students
SELECT TOP 10  S.FirstName
	   , S.LastName 
	   , CONVERT(NUMERIC(10,2),AVG(SE.Grade)) AS [AVG] 
FROM Students AS S
	JOIN StudentsExams AS SE ON SE.StudentId = S.Id
GROUP BY S.FirstName, S.LastName
ORDER BY AVG DESC , S.FirstName, S.LastName

--13. Second Highest Grade
SELECT T.FirstName
	   , T.LastName 
	   , T.Grade FROM
(
SELECT   S.FirstName
	   , S.LastName 
	   , SS.Grade 
	   ,ROW_NUMBER() OVER(PARTITION BY  S.FirstName ORDER BY SS.Grade DESC ) AS RANK
FROM Students AS S	
	JOIN StudentsSubjects AS SS ON SS.StudentId = S.Id
	) AS  T
WHERE T.RANK = 2
ORDER BY T.FirstName , T.LastName 

--14. Not So In The Studying
SELECT DISTINCT CONCAT(S.FirstName, ISNULL(' ' + S.MiddleName, NULL),' ', S.LastName) AS FullName
FROM Students AS S
WHERE S.Id NOT IN(SELECT StudentId FROM StudentsSubjects)
ORDER BY FullName

--15. Top Student per Teacher
SELECT  t.TeacherName, t.SubjectName, t.StudentName, t.Grade FROM
(
SELECT temp.TeacherName, temp.SubjectName, temp.StudentName, temp.Grade
,ROW_NUMBER() OVER(PARTITION BY temp.TeacherName order by temp.Grade DESC) AS [RANK]
FROM
(
SELECT		t.FirstName + ' ' + t.LastName as [TeacherName]
		,sj.Name as [SubjectName]
		,s.FirstName + ' ' + s.LastName as [StudentName]
		,FORMAT(AVG(se.Grade),'N2') as [Grade]
	FROMStudentsTeachers as st
		JOIN Teachers as t on t.Id = st.TeacherId
		JOIN Students as s on s.Id = st.StudentId
		JOIN StudentsSubjects as se on se.StudentId = s.Id 
		JOIN Subjects as sj on sj.Id = se.SubjectId AND T.SubjectId = sj.Id
GROUP BY t.FirstName , t.LastName , s.FirstName , s.LastName , sj.Name
) AS temp
) AS t
WHERE T.RANK = 1
ORDER BY t.SubjectName,  t.TeacherName, t.Grade DESC

--16. Average Grade per Subject
SELECT S.Name , AVG(SS.Grade) FROM Subjects AS S
JOIN StudentsSubjects AS SS ON SS.SubjectId = S.Id
GROUP BY S.Name, S.Id
ORDER BY S.Id

--17. Exams Information
SELECT T.Q, T.Name ,COUNT(T.StudentId) FROM
(
SELECT 
	   CASE
			WHEN MONTH(Date) BETWEEN 1 AND 3 THEN 'Q1'
			WHEN MONTH(Date) BETWEEN 4 AND 6 THEN 'Q2'
			WHEN MONTH(Date) BETWEEN 7 AND 9 THEN 'Q3'
			WHEN MONTH(Date) BETWEEN 10 AND 12 THEN 'Q4'
			ELSE 'TBA'
	   END AS Q
	   ,S.Name
	   ,SE.StudentId
FROM Subjects AS S
JOIN Exams AS E ON E.SubjectId = S.Id
JOIN StudentsExams AS SE ON SE.ExamId = E.Id
WHERE SE.Grade >= 4
) AS T
GROUP BY T.Q, T.Name
ORDER BY T.Q

--18. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX) AS 
BEGIN
	DECLARE @studentFirstName NVARCHAR(MAX)	= (SELECT FirstName FROM Students WHERE Id = @studentId);

	IF(@studentFirstName IS NULL)
		BEGIN			
			RETURN 'The student with provided id does not exist in the school!';
		END;
	
	IF(@grade > 6.00)
		BEGIN
			RETURN 'Grade cannot be above 6.00!'
		END;
	

	DECLARE @count INT = (SELECT COUNT(*) FROM StudentsExams 
							WHERE StudentId = @studentId AND Grade BETWEEN @grade AND  @grade + 0.50);

	RETURN 'You have to update ' + CAST(@count as nvarchar) +  ' grades for the student '  + @studentFirstName;
END;

--19. Exclude From School
CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
	BEGIN	

		IF((SELECT Id FROM Students WHERE Id = @StudentId) IS NULL)
			BEGIN
				RAISERROR('This school has no student with the provided id!', 16 , 1);
				RETURN;
			END;
		
		DELETE FROM StudentsExams WHERE StudentId = @StudentId;
		DELETE FROM StudentsSubjects WHERE StudentId = @StudentId;
		DELETE FROM StudentsTeachers WHERE StudentId = @StudentId;
		DELETE FROM Students WHERE Id = @StudentId
			
	END;
--20. Deleted Students
CREATE TRIGGER tr_DeleteStudent ON Students FOR DELETE
AS
	INSERT INTO ExcludedStudents
	SELECT Id, FirstName + ' ' + LastName FROM deleted 




