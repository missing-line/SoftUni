--
CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Phone varchar(12) NOT NULL
)

CREATE TABLE Mechanics 
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName  NVARCHAR(50) NOT NULL,
	LastName   NVARCHAR(50) NOT NULL,
	Address   NVARCHAR(255) NOT NULL,
)

CREATE TABLE Models
(
	ModelId  INT PRIMARY KEY IDENTITY,
	Name  NVARCHAR(50) UNIQUE NOT NULL, 
)

CREATE TABLE Jobs 
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status nvarchar(11) Default  'Pending' CHECK(Status IN('Pending', 'In Progress' , 'Finished')),
	ClientId  INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId  INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 'False'
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber NVARCHAR(50) UNIQUE NOT NULL,
	Description NVARCHAR(255),
	Price DECIMAL (4,2) CHECK(Price > 0 ),
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0
)

CREATE TABLE OrderParts 
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) NOT NULL,
	PartId  INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0),
	PRIMARY KEY( OrderId, PartId )
)

CREATE TABLE PartsNeeded 
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	PartId  INT FOREIGN KEY REFERENCES Parts(PartId) NOT NULL,
	Quantity INT DEFAULT 1 CHECK(Quantity > 0),
	PRIMARY KEY( JobId, PartId )
)

--02. Insert
INSERT INTO Clients(FirstName, LastName, Phone) VALUES
('Teri',		'Ennaco', '570-889-5187'),
('Merlyn',		'Lawler', '201-588-7810'),
('Georgene',	'Montezuma', '925-615-5185'),
('Jettie',		'Mconnell', '908-802-3564'),
('Lemuel',		'Latzke', '631-748-6479'),
('Melodie',		'Knipp', '805-690-1682'),
('Candida',		'Corbley','908-275-8357')

INSERT INTO Parts(SerialNumber, [Description] ,Price, VendorId) VALUES
('WP8182119' ,'Door Boot Seal', 117.86, 2),
('W10780048','Suspension Rod',42.81, 1),
('W10841140','Silicone Adhesive',6.77, 4),
('WPY055980','High Temperature Adhesive',13.94, 3)


--03. Update
UPDATE Jobs
SET Status = 'In Progress',
	MechanicId = (SELECT MechanicId FROM Mechanics 
					WHERE FirstName + ' ' + LastName = 'Ryan Harnos') 
WHERE Status = 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders 
WHERE OrderId  = 19

--05. Clients by Name
SELECT FirstName, LastName ,Phone FROM Clients
ORDER BY LastName, ClientId


--06. Job Status
SELECT Status, IssueDate FROM Jobs
WHERE Status <> 'Finished'
ORDER BY Status, JobId

--07. Mechanic Assignments
SELECT M.FirstName + ' ' + M.LastName
	   ,J.Status
	   ,J.IssueDate
FROM Mechanics AS M
JOIN Jobs AS J ON M.MechanicId = J.MechanicId
ORDER BY M.MechanicId, J.IssueDate, J.JobId

--08. Current Clients
SELECT C.FirstName + ' ' + C.LastName 		
	   ,DATEDIFF(DAY, J.IssueDate, '2017-04-24') AS T
	   , J.Status
	   FROM Clients AS C 
JOIN Jobs AS J ON J.ClientId = C.ClientId
WHERE J.Status <> 'Finished'
ORDER BY T DESC , C.ClientId

--09. Mechanic Performance
SELECT M.FirstName + ' ' + M.LastName
	   ,AVG(DATEDIFF(DAY,J.IssueDate, J.FinishDate))
FROM Mechanics AS M
JOIN Jobs AS J ON J.MechanicId = M.MechanicId
GROUP BY M.FirstName,M.LastName, M.MechanicId
ORDER BY M.MechanicId 

--10. Hard Earners
SELECT TOP 3 M.FirstName + ' ' + M.LastName
	   ,COUNT(J.JobId) AS C
FROM Mechanics AS M
JOIN Jobs AS J ON J.MechanicId = M.MechanicId
WHERE J.Status <> 'Finished'
GROUP BY M.FirstName,M.LastName, M.MechanicId
HAVING COUNT(J.JobId) > 1
ORDER BY C DESC, M.MechanicId 

--11. Available Mechanics
SELECT FirstName + ' ' + LastName 
FROM Mechanics
WHERE MechanicId NOT IN (
		SELECT DISTINCT  M.MechanicId
		FROM Mechanics AS M
		 JOIN Jobs AS J ON J.MechanicId = M.MechanicId
		WHERE J.Status = 'In Progress'
)
ORDER BY MechanicId


--12. Parts Cost
SELECT ISNULL(SUM(P.Price * OP.Quantity), 0) 
FROM Parts AS P
	JOIN OrderParts AS OP ON OP.PartId = P.PartId
	JOIN Orders AS O ON OP.OrderId = O.OrderId
WHERE DATEDIFF(WEEK, O.IssueDate, '2017-04-24') <= 3

--13. Past Expenses
SELECT  J.JobId , ISNULL(SUM(OP.Quantity * P.Price),0)AS S
FROM Parts AS P 
	JOIN OrderParts AS OP ON OP.PartId = P.PartId
	JOIN Orders AS O ON O.OrderId = OP.OrderId
	RIGHT JOIN Jobs AS J ON J.JobId = O.JobId
WHERE J.Status = 'Finished'
GROUP BY J.JobId
ORDER BY S DESC , J.JobId

--14. Model Repair Time
SELECT M.ModelId, M.Name ,CAST(AVG(DATEDIFF(DAY, J.IssueDate, J.FinishDate)) AS varchar) + ' days'  AS A
FROM Models AS M
JOIN Jobs AS J ON J.ModelId = M.ModelId
WHERE J.Status = 'Finished'
GROUP BY M.ModelId, M.Name
ORDER BY AVG(DATEDIFF(DAY, J.IssueDate, J.FinishDate)) ASC

--15. Faultiest Model
SELECT TOP (1) 
m.Name AS Model
, COUNT(*) AS [Times Serviced],
 (
     SELECT 
		ISNULL(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
     FROM Parts AS p
          JOIN OrderParts AS op ON op.PartId = p.PartId
          JOIN Orders AS o ON o.OrderId = op.OrderId
          JOIN Jobs AS j ON j.JobId = o.JobId
     WHERE j.ModelId = m.ModelId
 ) AS [Parts Total]
FROM Models AS m
     JOIN Jobs AS j ON j.ModelId = m.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY [Times Serviced] DESC;

--16. Missing Parts
SELECT p.PartId,
       p.Description,
       ISNULL(pn.Quantity, 0) AS Required,
       ISNULL(p.StockQty, 0) AS [In Stock],
       ISNULL(CASE
                  WHEN o.Delivered = 0
                  THEN op.Quantity
                  ELSE 0
              END, 0) AS Ordered
FROM Parts AS p
     JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
     LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
     JOIN Jobs AS j ON j.JobId = pn.JobId
     LEFT JOIN Orders AS o ON o.JobId = j.JobId
WHERE pn.Quantity > ISNULL(p.StockQty + CASE
                                            WHEN o.Delivered = 0 THEN op.Quantity
                                            ELSE 0
                                        END, 0)  AND j.Status <> 'Finished'
ORDER BY p.PartId;

--17. Cost of Order 
CREATE FUNCTION udf_GetCost(@JobId  INT)
RETURNS DECIMAL(18, 2) AS 
BEGIN
	DECLARE @totalSum DECIMAL(18, 2) = (
	SELECT ISNULL(SUM(P.Price * OP.Quantity),0)
	FROM Jobs AS J
	JOIN Orders AS  O ON O.JobId = J.JobId AND J.JobId = @JobId
	JOIN OrderParts AS OP ON OP.OrderId = O.OrderId
	JOIN Parts AS P ON P.PartId = OP.PartId);

	RETURN @totalSum;
END

--18. Place Order
CREATE PROCEDURE usp_PlaceOrder (@jobId INT, @partSerialNumber VARCHAR(MAX),@quantity INT)
AS
 BEGIN	     
         IF(@quantity <= 0)
             BEGIN;
                 THROW 50012, 'Part quantity must be more than zero!', 1;
			 END;

         IF((SELECT JobId  FROM Jobs WHERE JobId = @jobId) IS NULL)
             BEGIN;
                 THROW 50013, 'Job not found!', 1;
			END;

         IF((SELECT Status FROM Jobs WHERE JobId = @jobId ) = 'Finished')
             BEGIN;
                 THROW 50011, 'This job is not active!', 1;
			 END;

         IF((SELECT SerialNumber  FROM Parts  WHERE SerialNumber = @partSerialNumber) IS NULL)
             BEGIN;
                 THROW 50014, 'Part not found!', 1;
			END;
	  
         IF( (SELECT JobId FROM Orders WHERE JobId = @jobId AND IssueDate IS NULL) IS NULL)
             BEGIN
                 INSERT INTO Orders(JobId,IssueDate, Delivered ) VALUES
                 (@jobId,  NULL, 0);
			 END;
	    
         DECLARE @orderId INT = (SELECT TOP 1 OrderId FROM Orders  WHERE JobId = @jobId AND IssueDate IS NULL );
         DECLARE @partId INT =  (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber );

         IF(( SELECT PartId FROM OrderParts WHERE PartId = @partId AND OrderId = @orderId ) IS NULL)
             BEGIN
                 INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
                 (@orderId, @partId, @quantity );
			 END;	    
          ELSE
             BEGIN
                 UPDATE OrderParts
                   SET
                       Quantity+=@quantity
                 WHERE PartId = @partId
                       AND OrderId = @orderId;
             END;
 END;


--19. Detect Delivery
CREATE TRIGGER tr_DeleteDelivery ON Orders FOR UPDATE
AS
	IF	((SELECT Delivered FROM deleted) = 0)
		BEGIN
			  WITH cte_OrderDataFromOrderParts(OrderId, PartId,  Quantity)
                      AS 
						 (SELECT OrderId,PartId,SUM(Quantity) AS Quantity 
							 FROM OrderParts
							 WHERE OrderId =(SELECT OrderId FROM inserted) 
							 GROUP BY OrderId,PartId)
				  
                      UPDATE Parts
                        SET StockQty +=cte.Quantity
                        FROM cte_OrderDataFromOrderParts AS cte
                        WHERE Parts.PartId = cte.PartId;
		END

--20. Vendor Preference 

WITH cte_Parts
     AS (
     SELECT m.MechanicId,
            v.VendorId,
            SUM(op.Quantity) AS PartsForMechanicByVendor
     FROM Mechanics AS m
          JOIN jobs AS j ON j.MechanicId = m.MechanicId
          JOIN Orders AS o ON o.JobId = j.JobId
          JOIN OrderParts AS op ON op.OrderId = o.OrderId
          JOIN Parts AS p ON p.PartId = op.PartId
          JOIN Vendors AS v ON v.VendorId = p.VendorId
     GROUP BY m.MechanicId,v.VendorId)

     SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
            v.Name AS Vendor,
            cte.PartsForMechanicByVendor AS Parts,
CONCAT(FLOOR(cte.PartsForMechanicByVendor * 1.0 /
			(  SELECT SUM(PartsForMechanicByVendor)  FROM cte_Parts WHERE MechanicId = m.MechanicId ) * 100), '%'  ) AS Preference
     FROM cte_Parts AS cte
          JOIN Mechanics AS m ON m.MechanicId = cte.MechanicId
          JOIN Vendors AS v ON v.VendorId = cte.VendorId
     ORDER BY Mechanic,Parts DESC,Vendor;

