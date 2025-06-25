USE COGNIZANT
GO

SELECT *
FROM (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER       (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
) AS Ranked
WHERE RowNum <= 3 OR RankNum <= 3 OR DenseRankNum <= 3
ORDER BY Category, Price DESC;
