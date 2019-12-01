--01. DDL
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username  NVARCHAR(30) NOT NULL,
	Password  NVARCHAR(30) NOT NULL,
	Email	  NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId	 INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId	 INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	PRIMARY KEY(RepositoryId , ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(255) NOT NULL,
	IssueStatus NVARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message NVARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Size DECIMAL (15, 2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL,
)

--02. Insert
INSERT INTO Files(Name,Size,ParentId,CommitId) VALUES
('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues(Title,IssueStatus,RepositoryId,AssigneeId) VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html',	'open',	4,	3),
('Implement documentation for UsersService.cs',	'closed',	8,	2),
('Unreachable code in Index.cs',	'open',	9,	8)

--03. Update
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--04. Delete
DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories
						WHERE Name = 'Softuni-Teamwork')


DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories
						WHERE Name = 'Softuni-Teamwork')


-- 05. Commits
SELECT Id , Message , RepositoryId, ContributorId
FROM Commits
ORDER BY  Id , Message , RepositoryId, ContributorId

--06. Heavy HTML
SELECT Id, Name ,Size
FROM Files
WHERE Name LIKE '%html%' and Size > 1000
ORDER BY Size DESC , Name ASC

-- 07. Issues and Users
SELECT I.Id, U.Username + ' : ' + I.Title AS IssueAssignee
FROM Users AS U
	JOIN Issues AS I ON I.AssigneeId = U.Id
ORDER BY I.Id DESC, IssueAssignee

--08. Non-Directory Files
SELECT Id, Name, CAST(Size AS varchar) + 'KB' 
FROM Files
WHERE Id NOT IN(SELECT ParentId FROM Files WHERE ParentId IS NOT NULL) 
ORDER BY  Id, Name, Size DESC

--09. Most Contributed Repositories
SELECT TOP 5 R.Id, R.Name, COUNT(C.Id) AS C 
FROM Repositories AS R
JOIN Commits AS C ON C.RepositoryId = R.Id
JOIN RepositoriesContributors AS RC ON RC.RepositoryId = R.Id
GROUP BY R.Name, R.Id
ORDER BY  C DESC , R.Id, R.Name

-- 10. User and Files
SELECT S.Username, AVG(F.Size)  AS A
FROM Users AS S
JOIN Commits AS C ON C.ContributorId = S.Id
JOIN Files AS F ON F.CommitId = C.Id 
GROUP BY  S.Username
ORDER BY A DESC , S.Username

--11. User Total Commits
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(MAX)) 
RETURNS INT AS 
BEGIN
	DECLARE @count INT = (SELECT COUNT(*) FROM Users AS U
							JOIN Commits AS C ON C.ContributorId = U.Id
							WHERE U.Username = @username);
	RETURN @count;
END;

--12. Find by Extensions
CREATE PROCEDURE usp_FindByExtension(@extension VARCHAR(MAX))
AS	
	SELECT Id, Name , CAST(SIZE AS varchar) + 'KB'  
	FROM Files
	WHERE Name LIKE '%' + @extension + '%'
	ORDER BY Id, Name ,Size
