--1. Number of Users for Email Provider
SELECT T.Email, COUNT(T.Email) AS C FROM 
(
SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS Email 
,Id
FROM Users
) AS T
GROUP BY Email
ORDER BY C DESC, T.Email

--02. All Users in Games
SELECT G.Name,	GT.Name	,U.Username, UG.Level, UG.Cash, C.Name
FROM Games AS G
	JOIN GameTypes AS  GT ON GT.Id = G.GameTypeId
	JOIN UsersGames AS UG ON UG.GameId = G.Id
	JOIN Users AS U ON U.Id = UG.UserId
	JOIN Characters AS C ON C.Id = UG.CharacterId
ORDER BY UG.Level DESC, U.Username,  G.Name

--03. Users in Games with Their Items
SELECT U.Username , G.Name , COUNT(I.Id), SUM(I.Price)
FROM Users AS U
	JOIN UsersGames AS UG ON UG.UserId = U.Id
	JOIN UserGameItems AS UGI ON UGI.UserGameId = UG.Id
	JOIN Items AS I ON I.Id = UGI.ItemId
	JOIN Games AS G ON UG.GameId = G.Id
GROUP BY U.Username , G.Name 
HAVING COUNT(I.Id) >= 10
ORDER BY COUNT(I.Id) DESC , SUM(I.Price) DESC , U.Username

--05. All Items with Greater than Average Statistics
DECLARE  @speed INT = (SELECT AVG(S.Speed) FROM Items AS I
						JOIN [Statistics] AS  S ON I.StatisticId = S.Id);
DECLARE  @mind INT = (SELECT AVG(S.Mind) FROM Items AS I
						JOIN [Statistics] AS  S ON I.StatisticId = S.Id);
DECLARE  @luck INT = (SELECT AVG(S.Luck) FROM Items AS I
JOIN [Statistics] AS  S ON I.StatisticId = S.Id);

SELECT I.Name , I.Price , I.MinLevel , S.Strength , S.Defence
,S.Speed , S.Luck , S.Mind 
FROM Items AS I
JOIN [Statistics] AS  S ON I.StatisticId = S.Id
WHERE S.Speed > @speed AND S.Mind > @mind AND S.Luck > @luck
ORDER BY I.Name

--06. Display All Items about Forbidden Game Type
SELECT I.Name,	I.Price,I.MinLevel, GT.Name	
FROM Items AS I 
LEFT JOIN GameTypeForbiddenItems AS G ON  G.ItemId = I.Id
LEFT JOIN GameTypes AS  GT ON GT.Id = G.GameTypeId
ORDER BY  GT.Name	DESC, I.Name

--07. Buy Items for User in Game

DECLARE @itemsPrice MONEY = (SELECT SUM(Price) FROM Items WHERE Name 
IN('Blackguard'
, 'Bottomless Potion of Amplification'
,'Eye of Etlich (Diablo III)'
,'Gem of Efficacious Toxin'
,'Golden Gorget of Leoric'
,'Hellfire Amulet'));

DECLARE @userGameId  INT = (
								SELECT Id 
								FROM UsersGames AS ug
								WHERE ug.GameId = 
									  (SELECT Id FROM Games WHERE Name = 'Edinburgh') AND
									  ug.UserId =
									  (SELECT Id FROM Users WHERE Username = 'Alex')
								)
UPDATE UsersGames
SET Cash -= @itemsPrice
WHERE Id = @userGameId

INSERT INTO UserGameItems
SELECT I.Id, @userGameId FROM Items AS I 
WHERE I.Name IN('Blackguard'
						,'Bottomless Potion of Amplification'
						,'Eye of Etlich (Diablo III)'
						,'Gem of Efficacious Toxin'
						,'Golden Gorget of Leoric'
						,'Hellfire Amulet');
	



SELECT U.Username , G.Name , UG.Cash , I.Name
FROM Games AS G 
	JOIN UsersGames AS UG ON UG.GameId = G.Id
	JOIN Users AS U ON U.Id = UG.UserId
	JOIN UserGameItems AS UI ON UI.UserGameId = UG.Id
	JOIN Items AS I ON I.Id = UI.ItemId
WHERE G.Id = (SELECT Id FROM Games WHERE Name = 'Edinburgh')
ORDER BY I.Name

--