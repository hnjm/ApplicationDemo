﻿CREATE TABLE Demo.Navigation
(
	Id INT PRIMARY KEY IDENTITY,
	NavigationId INT FOREIGN KEY REFERENCES Demo.Navigation(Id), -- ParentId BuiltIn naming convention.
	Name NVARCHAR(256) NOT NULL UNIQUE,
	TextHtml NVARCHAR(256),
	PageName NVARCHAR(256),
	Sort FLOAT,
)

GO
CREATE VIEW Demo.NavigationBuiltIn AS
SELECT
	Navigation.Id,
	Navigation.Name AS IdName,
	Navigation.NavigationId,
	(SELECT Name FROM Demo.Navigation Navigation2 WHERE Navigation2.Id = Navigation.NavigationId) AS NavigationIdName,
	Navigation.Name,
	Navigation.TextHtml,
	Navigation.PageName,
	Navigation.Sort
FROM
	Demo.Navigation Navigation

GO
CREATE VIEW Demo.NavigationDisplay AS
WITH Cte (Id, NavigationId, Name, Level, Path) AS
(
	SELECT Id, NavigationId, Name, 0 AS Level, CAST(Name as NVARCHAR(1024)) AS Path FROM Demo.Navigation WHERE Navigationid IS NULL
	UNION ALL
	SELECT Navigation.Id, Navigation.NavigationId, Navigation.Name, Cte.Level + 1 AS Level, CAST(CONCAT(Cte.Path, ' > ', Navigation.Name) AS NVARCHAR(1024)) AS Path
	FROM Demo.Navigation Navigation
	INNER JOIN Cte ON Cte.Id = Navigation.NavigationId

)
SELECT * FROM Cte