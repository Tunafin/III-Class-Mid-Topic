--select  [分類] from [菜單]  where [店家ID] = 3 group by [分類],[餐點ID] order by [餐點ID] 

SELECT  [分類], 
(
    SELECT TOP 1 [餐點ID] 
    FROM  [菜單] AS T2
    WHERE T2.[分類] = T1.[分類]
    GROUP BY [餐點ID]
) AS [餐點ID]
FROM [菜單] AS T1
where [店家ID] = 3
GROUP BY [分類]
ORDER BY [餐點ID]






