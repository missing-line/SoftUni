--01. DDL
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30) NOT NULL,
	Price DECIMAL(15,2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone VARCHAR(12) NOT NULL,
	Salary DECIMAL(15,2) NOT NULL,
)

CREATE TABLE Orders
(
	Id INT PRIMARY KEY IDENTITY,
	DateTime DATETIME NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderId INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	ItemId INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	Quantity INT CHECK(Quantity >= 1)  ,
	PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts
(
	Id INT  IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CheckIn DATETIME NOT NULL,
	CheckOut DATETIME  NOT NULL,
	PRIMARY KEY(Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CHECKTIMEOUT CHECK(CheckIn < CheckOut) 

--02. Insert
INSERT INTO Employees (FirstName,LastName,Phone,Salary) VALUES
('Stoyan',	'Petrov	'	,'888-785-8573',	500.25),
('Stamat',	'Nikolov'	,'789-613-1122',	999995.25),
('Evgeni',	'Petkov'	,'645-369-9517',	1234.51),
('Krasimir','Vidolov'	,'321-471-9982',	50.25)

INSERT INTO Items(Name,Price,CategoryId) VALUES
('Tesla battery',	154.25,	8),
('Chess',	30.25,	8),
('Juice',	5.32,	1),
('Glasses',	10	,8),
('Bottle of water',	1,	1)


--03. Update
UPDATE Items
SET Price += 0.27 * Price
WHERE CategoryId IN(1,2,3)

--04. Delete
DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48

--05. Richest People
SELECT Id, FirstName FROM Employees
WHERE Salary > 6500
ORDER BY FirstName , Id

--06. Cool Phone Numbers
SELECT FirstName + ' ' + LastName AS FullName , Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName , Id

--07. Employee Statistics
SELECT FirstName, LastName , COUNT(O.Id) AS C
FROM Employees AS E
	JOIN Orders AS O ON O.EmployeeId = E.Id
GROUP BY  FirstName, LastName
ORDER BY C DESC , FirstName

--08. Hard Workers Club
SELECT FirstName , LastName , AVG(DATEDIFF(HOUR, S.CheckIn , S.CheckOut)) AS C
FROM Employees AS E
	JOIN Shifts AS S ON S.EmployeeId = E.Id
GROUP BY FirstName , LastName , E.Id
HAVING AVG(DATEDIFF(HOUR, S.CheckIn , S.CheckOut)) > 7
ORDER BY C DESC , E.Id

--09. The Most Expensive Order
SELECT TOP 1
	O.Id 
	,SUM( I.Price * OI.Quantity) AS TOTAL
FROM OrderItems AS OI
 JOIN Items AS I ON I.Id = OI.ItemId
 JOIN Orders AS O ON O.Id = OI.OrderId
GROUP BY O.Id
ORDER BY TOTAL DESC

--10. Rich Item, Poor Item
SELECT TOP 10
	O.Id 
	,MAX(I.Price)  AS M
	,MIN(I1.Price) AS M1
FROM OrderItems AS OI
 JOIN Items AS I ON I.Id = OI.ItemId
 JOIN Orders AS O ON O.Id = OI.OrderId
 JOIN Items AS I1 ON I1.Id = OI.ItemId
GROUP BY O.Id
ORDER BY M DESC , O.Id


--11. Cashiers
SELECT DISTINCT
	E.Id 
	, E.FirstName 
	, E.LastName 
FROM Employees AS E
 JOIN Orders AS O ON O.EmployeeId = E.Id
 ORDER BY E.Id

--12. Lazy Employees
SELECT DISTINCT
	E.Id, E.FirstName + ' ' + E.LastName 
FROM Employees AS E
	JOIN Shifts AS S ON S.EmployeeId = E.Id
WHERE DATEDIFF(HOUR, S.CheckIn , S.CheckOut) < 4
ORDER BY  E.Id

--13. Sellers
SELECT TOP 10 
		E.FirstName + ' ' + E.LastName AS FULLNAME
		,SUM(OI.Quantity * I.Price ) AS TOTAL
		,SUM(OI.Quantity) AS C
FROM Employees AS E
	JOIN Orders AS O ON O.EmployeeId = E.Id
	JOIN OrderItems AS OI ON OI.OrderId = O.Id
	JOIN Items AS I ON I.Id = OI.ItemId
WHERE O.DateTime < '2018-06-15'
GROUP BY E.FirstName , E.LastName
ORDER BY TOTAL DESC , C DESC

--14. Tough Days
SELECT CONCAT(e.FirstName,' ', e.LastName) AS [Full Name] 
	  ,DATENAME(WEEKDAY, s.CheckIn ) AS [Day of the week]
FROM Employees AS e
    LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
	JOIN Shifts AS s ON s.EmployeeId = e.Id 
	WHERE o.EmployeeId IS NULL AND DATEDIFF(HOUR, s.CheckIn,s.CheckOut) > 12
ORDER BY e.Id

--15. Top Order per Employee
SELECT k.[Full Name]
       , DATEDIFF(HOUR, s.CheckIn,s.CheckOut) as [WorkHours]
       , k.TotalPrice 
FROM
(
SELECT  o.Id AS OrderId
		,e.Id as EmpId
		,o.DateTimE as dateTime
		,CONCAT(e.FirstName,' ', e.LastName) AS [Full Name] 		
		,SUM(oi.Quantity * i.Price) AS [TotalPrice]
		,ROW_NUMBER() OVER
		(
			PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price) DESC
		)   AS [RowNumber]		
FROM Employees AS e	
	JOIN Orders AS o ON o.EmployeeId = e.Id
	JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id,e.FirstName, e.LastName, e.Id,o.DateTimE
) AS k
JOIN Shifts AS s ON s.EmployeeId = k.EmpId AND k.dateTime BETWEEN s.CheckIn AND s.CheckOut
WHERE K.RowNumber = 1
ORDER BY k.[Full Name] ASC, [WorkHours] DESC , k.TotalPrice DESC


--16. Average Profit per Day
SELECT DATEPART(DAY,o.DateTimE) AS [Day]
	  ,FORMAT(AVG(i.Price * oi.Quantity),'N2') AS [Total profit]
	FROM Orders AS o	
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY,o.DateTimE)
ORDER BY [Day]

--17. Top Products
SELECT I.Name , C.Name , SUM(OI.Quantity)AS C, SUM(I.Price * OI.Quantity)  AS S
FROM Items AS I
	LEFT JOIN Categories AS C ON C.Id = I.CategoryId
	LEFT JOIN OrderItems AS OI ON OI.ItemId = I.Id
	LEFT JOIN Orders AS O ON O.Id = OI.OrderId
GROUP BY I.Name , C.Name
ORDER BY S DESC, C DESC

--18. Promotion Days
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME
,@StartDate DATETIME
, @EndDate DATETIME
, @Discount DECIMAL(18,2)
, @FirstItemId INT
, @SecondItemId INT
, @ThirdItemId INT)
RETURNS NVARCHAR(MAX) AS
BEGIN
	

	DECLARE @first INT = (SELECT Id FROM Items WHERE Id = @FirstItemId);
	DECLARE @second INT = (SELECT Id FROM Items WHERE Id = @SecondItemId);
	DECLARE @third INT = (SELECT Id FROM Items WHERE Id = @ThirdItemId);

	IF (@first IS NULL OR @second IS NULL OR @third IS NULL)
		BEGIN
			RETURN('One of the items does not exists!');	
		END;
	
	IF(@CurrentDate  NOT BETWEEN @StartDate AND @EndDate)
		BEGIN
			RETURN('The current date is not within the promotion dates!');			
		END;

	DECLARE @firstName NVARCHAR(MAX) = (SELECT Name FROM Items WHERE Id = @FirstItemId);
	DECLARE @secondName  NVARCHAR(MAX) = (SELECT Name FROM Items WHERE Id = @SecondItemId);
	DECLARE @thirdName  NVARCHAR(MAX) = (SELECT Name FROM Items WHERE Id = @ThirdItemId);

	DECLARE @fDiscount MONEY = (SELECT Price - ( Price * (@Discount / 100))
											FROM Items WHERE Id = @FirstItemId);

	DECLARE @sDiscount MONEY = (SELECT Price - ( Price * (@Discount / 100))
											FROM Items WHERE Id = @SecondItemId);	

	DECLARE @tDiscount MONEY = (SELECT Price - ( Price * (@Discount / 100))
											FROM Items WHERE Id = @ThirdItemId);

		RETURN @firstName + ' price: ' + CAST(ROUND(@fDiscount,2) as varchar) + ' <-> ' +
				@secondName + ' price: ' + CAST(ROUND(@sDiscount,2) as varchar)+ ' <-> ' +
				@thirdName + ' price: ' + CAST(ROUND(@tDiscount,2) as varchar)
END;




--19. Cancel Order

CREATE PROC usp_CancelOrder(@OrderId INT, @CancelDate DATE)
AS
BEGIN
	IF((SELECT Id FROM Orders WHERE Id = @OrderId) IS NULL)
		BEGIN
			RAISERROR('The order does not exist!' , 16 , 1);
			RETURN;
		END;

	DECLARE @diffDays INT = (SELECT DATEDIFF(DAY,DateTime, @CancelDate) 
								FROM Orders 
								WHERE Id = @OrderId);
	
	IF(@diffDays > 3)
		BEGIN
			RAISERROR('You cannot cancel the order!',16 , 2);
			RETURN;
		END;

	DELETE FROM OrderItems WHERE OrderId = @OrderId;
	DELETE FROM Orders WHERE Id = @OrderId;
END;


--20. Deleted Orders
CREATE TRIGGER  tr_DeleteOrderRalations ON OrderItems FOR DELETE
AS
	INSERT INTO DeletedOrders
	SELECT OrderId, ItemId, Quantity FROM deleted
	

