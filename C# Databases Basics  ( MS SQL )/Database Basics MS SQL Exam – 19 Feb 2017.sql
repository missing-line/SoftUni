--01.DDL
CREATE TABLE Countries 
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers 
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName 	NVARCHAR(25),
	LastName	NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products 
(
	Id INT PRIMARY KEY IDENTITY,
	Name  	NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price	MONEY CHECK(Price > 0)	
)

CREATE TABLE Feedbacks  
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),
	Rate DECIMAL(18,2) CHECK(Rate >= 0 AND Rate<= 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId  INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors   
(
	Id  INT PRIMARY KEY IDENTITY,
	Name  	NVARCHAR(25) UNIQUE, 
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId  INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients   
(
	Id INT PRIMARY KEY IDENTITY,
	Name  NVARCHAR(30),
	Description   NVARCHAR(200),
	OriginCountryId  INT FOREIGN KEY REFERENCES Countries (Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id),
)

CREATE TABLE ProductsIngredients  
(
	ProductId INT FOREIGN KEY REFERENCES Products  (Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients  (Id),
	PRIMARY KEY (ProductId,IngredientId )
)


--02. Insert
INSERT INTO Distributors(Name ,CountryId,AddressText,Summary ) VALUES
('Deloitte & Touche',		2 ,		'6 Arch St #9757', 		'Customizable neutral traveling'),
('Congress Title', 			13 ,	'58 Hancock St',		'Customer loyalty'),
('Kitchen People',			1 ,		'3 E 31st St #77', 		'Triple-buffered stable delivery'),
('General Color Co Inc',	21,		'6185 Bohn St #72',		'Focus group'),
('Beck Corporation',		23,		'21 E 64th Ave',       'Quality-focused 4th generation hardware')

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise' ,'Rautenstrauch',15,'M','0195698399',5),
('Kendra','Loud',22,'F','0063631526',11),
('Lourdes','Bauswell',50,'M','0139037043',8),
('Hannah','Edmison',18,'F','0043343686',1),
('Tom','Loeza',31,'M','0144876096',23),
('Queenie','Kramarczyk',30,'F','0064215793',29),
('Hiu','Portaro',25,'M','0068277755',16),
('Josefa','Opitz',43,'F','0197887645',17)


--03. Update 
UPDATE Ingredients 
SET DistributorId = 35
WHERE Name IN ('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete 
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price
SELECT Name, Price, Description
FROM Products 
ORDER BY Price DESC, Name

--06. Ingredients
SELECT Name, Description, OriginCountryId  FROM Ingredients
WHERE OriginCountryId IN(1,10,20)
ORDER BY Id

--07. Ingredients from Bulgaria and Greece
SELECT TOP 15 I.Name, I.Description, C.Name FROM Countries AS C 
 JOIN Ingredients AS I ON C.Id = I.OriginCountryId
WHERE C.Name IN('Bulgaria','Greece')
ORDER BY I.Name , C.Name

--08. Best Rated Products
SELECT TOP 10
		P.Name
		, P.Description 
		, AVG(F.Rate)
		, COUNT(*) 
FROM Feedbacks AS F
JOIN Products AS P ON P.Id = F.ProductId
GROUP BY P.Name , P.Description
ORDER BY  AVG(F.Rate) DESC, COUNT(*) DESC

--09. Negative Feedback
SELECT F.ProductId ,F.Rate ,F.Description ,C.Id ,C.Age ,C.Gender
FROM Customers AS C
JOIN Feedbacks AS F ON F.CustomerId = C.Id
WHERE F.Rate < 5.0
ORDER BY F.ProductId DESC,F.Rate

--10. Customers without Feedback
SELECT  
	CONCAT(C.FirstName , ' ' + C.LastName)
	, C.PhoneNumber 
	, C.Gender
FROM Customers AS C
	LEFT JOIN Feedbacks AS F ON F.CustomerId = C.Id
WHERE F.CustomerId IS NULL
ORDER BY C.Id

--11. Honorable Mentions
SELECT 
	F.ProductId 
	, C.FirstName + ' ' + C.LastName AS FULLNAME 
	, F.Description
FROM Feedbacks AS F
JOIN Customers AS C ON C.Id = F.CustomerId
WHERE C.Id IN ( SELECT CustomerId
				FROM Feedbacks
				GROUP BY CustomerId
				HAVING COUNT(*) >= 3 )
ORDER BY F.ProductId , FULLNAME , F.Id 

--12. Customers by Criteria
SELECT 
		c.FirstName, C.Age, C.PhoneNumber 
FROM Customers AS C
	JOIN Countries AS C1 ON C1.Id = C.CountryId
WHERE C.Age >= 21 AND ( C.FirstName LIKE '%an%' OR C.PhoneNumber LIKE '%38') AND C1.Name <> 'Greece'
ORDER BY C.FirstName , C.Age

--13. Middle Range Distributors
SELECT 
	D.Name, I.Name, P.Name, AVG(F.Rate)
FROM Ingredients AS I
JOIN ProductsIngredients AS P1 ON P1.IngredientId = I.Id
JOIN Products AS P ON P.Id = P1.ProductId
JOIN Feedbacks AS F ON F.ProductId = P.Id
JOIN Distributors AS D ON D.Id = I.DistributorId
GROUP BY D.Name, I.Name, P.Name
HAVING AVG(F.Rate) BETWEEN 5 AND 8
ORDER BY D.Name, I.Name, P.Name

--14. The Most Positive Country
SELECT TOP 1 WITH TIES
C1.Name , AVG(F.Rate) AS A FROM Feedbacks AS F
JOIN Customers AS C ON C.Id = F.CustomerId
JOIN Countries AS C1 ON C1.Id = C.CountryId
GROUP BY C1.Name
ORDER BY A DESC

--15. Country Representative
SELECT R.CountryName,
       R.DisributorName
FROM
(
SELECT 
	C.Name AS CountryName 
	, D.Name AS DisributorName
	, COUNT(I.Id) AS C
	,DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Rank
FROM Countries AS C
	LEFT JOIN Distributors AS D ON D.CountryId = C.Id
	LEFT JOIN Ingredients AS I ON  I.DistributorId = D.Id
GROUP BY  C.Name , D.Name
) AS R
WHERE Rank = 1
ORDER BY CountryName, DisributorName

--16. Customers With Countries
CREATE VIEW v_UserWithCountries 
AS
SELECT C1.FirstName + ' ' + C1.LastName AS CustomerName, C1.Age, C1.Gender, C2.Name AS CountryName
FROM Customers AS C1
JOIN Countries AS C2 ON C2.Id = C1.CountryId

--17. Feedback by Product Name
CREATE FUNCTION udf_GetRating(@productName NVARCHAR(25))
RETURNS NVARCHAR(MAX)
AS
	BEGIN
		DECLARE @rate DECIMAL(4, 2) = (SELECT AVG(F.Rate) FROM Products AS P
								 JOIN Feedbacks AS F ON F.ProductId = P.Id 
								 WHERE P.Name = @productName);

		IF(@rate IS NULL)
			BEGIN
				RETURN 'No rating';
			END
		 IF(@rate < 5)
			BEGIN
				RETURN 'Bad';
			END
		 IF(@rate >= 5 AND @rate <= 8)
			BEGIN
				RETURN 'Average';
			END
		
		RETURN 'Good';
			
	END

--18. Send Feedback
CREATE PROCEDURE usp_SendFeedback(@customerId INT, @productId INT, @rate DECIMAL, @description NVARCHAR(MAX))
AS
	BEGIN
		DECLARE @countRate INT = (SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = @customerId);

		IF(@countRate >= 3)
			BEGIN				
				RAISERROR('You are limited to only 3 feedbacks per product!',16 ,1);
				RETURN;
			END;

		INSERT INTO Feedbacks(CustomerId, ProductId , Rate,  Description) VALUES
		(@customerId, @productId, @rate, @description)
	END


--19. Delete Products

CREATE TRIGGER tr_DeleteProduct ON Products INSTEAD OF DELETE
AS
	BEGIN
		DELETE FROM Feedbacks WHERE ProductId = (SELECT Id FROM deleted)
		DELETE FROM ProductsIngredients WHERE ProductId = (SELECT Id FROM deleted)
		DELETE FROM Products WHERE Id = (SELECT Id FROM deleted)
	END









