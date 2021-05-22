

SET IDENTITY_INSERT [dbo].[班級] ON 
GO
INSERT [dbo].[班級] ([班級ID], [班級名稱]) VALUES (101, N'向日葵班')
GO
INSERT [dbo].[班級] ([班級ID], [班級名稱]) VALUES (102, N'玫瑰班')
GO
INSERT [dbo].[班級] ([班級ID], [班級名稱]) VALUES (103, N'櫻花班')
GO
INSERT [dbo].[班級] ([班級ID], [班級名稱]) VALUES (104, N'紫羅蘭班')
GO
SET IDENTITY_INSERT [dbo].[班級] OFF
GO








GO
SET IDENTITY_INSERT [dbo].[學生] ON 
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (1, 101, N'野原新之助', N'1234', 1, N'數學')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (2, 101, N'風間徹', N'1234', 1, N'數學')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (3, 101, N'櫻田妮妮', N'1234', 1, N'英文')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (4, 101, N'佐藤正男', N'1234', 1, N'微積分')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (5, 101, N'阿呆', N'1234', 1, N'自然')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (6, 101, N'野原廣智', N'1234', 1, N'英文')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (7, 101, N'時川翔', N'1234', 1, N'英文')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (8, 102, N'河村獵豹', N'1234', 1, N'微積分')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (9, 102, N'仁', N'1234', 1, N'數學')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (10, 102, N'輝信', N'1234', 1, N'資訊')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (11, 102, N'根井丸', N'1234', 1, N'資訊')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (12, 103, N'詩織', N'1234', 1, N'資訊')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (13, 103, N'遙', N'1234', 1, N'微積分')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (14, 103, N'小俊', N'1234', 1, N'微積分')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (15, 103, N'卡莉', N'1234', 1, N'微積分')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (16, 103, N'崎山', N'1234', 1, N'英文')
GO
INSERT [dbo].[學生] ([學生ID], [班級ID], [姓名], [密碼], [在學中], [主修]) VALUES (17, 104, N'愛藤皆子', N'1234', 1, N'自然')
GO
SET IDENTITY_INSERT [dbo].[學生] OFF
GO





SET IDENTITY_INSERT [dbo].[店家] ON 
GO
INSERT [dbo].[店家] ([店家ID], [店家名稱], [電話], [地址], [客製化標題], [客製化多選]) VALUES (1, N'熊大便當店', NULL, NULL, N'附餐飲料(擇一)', 0)
GO
INSERT [dbo].[店家] ([店家ID], [店家名稱], [電話], [地址], [客製化標題], [客製化多選]) VALUES (2, N'拉拉熊拉麵專賣店', NULL, NULL, N'加購專區', 1)
GO
INSERT [dbo].[店家] ([店家ID], [店家名稱], [電話], [地址], [客製化標題], [客製化多選]) VALUES (3, N'熊讚麵館', NULL, NULL, N'客製化', 1)
GO
SET IDENTITY_INSERT [dbo].[店家] OFF
GO


--匯入菜單
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'豆乳雞丁飯', 60, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'無骨雞排飯', 60, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'檸檬雞腿飯', 70, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'海南雞腿飯', 70, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'椒麻雞腿飯', 75, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'香酥雞排飯', 75, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'炭烤雞排飯', 80, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'酥炸雞腿飯', 80, N'Chicken')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'蜜汁雞腿飯', 80, N'Chicken')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'蒜泥白肉飯', 60, N'Pork')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'礁岩排骨飯', 65, N'Pork')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'香烤排骨飯', 65, N'Pork')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'蜜汁排骨飯', 65, N'Pork')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'紅燒軟骨飯', 70, N'Pork')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'豆鼓燒肉飯', 70, N'Pork')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'秋刀魚飯', 60, N'Fish')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'鯖魚飯', 65, N'Fish')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'蒲燒鯛魚飯', 65, N'Fish')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'魚排飯', 70, N'Fish')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (1, N'鱈魚飯', 75, N'Fish')


INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'東京豚骨拉麵', 109, N'日式')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'東京醬油拉麵', 109, N'日式')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'九州白湯拉麵', 109, N'日式')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'札幌味噌拉麵', 109, N'日式')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'韓式泡菜拉麵', 119, N'韓式')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'釜山紅湯拉麵', 119, N'韓式')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'霸王海鮮濃口拉麵', 169, N'海鮮')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'霸王海陸濃口拉麵', 189, N'海鮮')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'龍王海鮮濃口拉麵', 189, N'海鮮')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'龍王海陸濃口拉麵', 209, N'海鮮')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'東京煉獄拉麵', 119, N'地獄')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'九州地獄拉麵', 119, N'地獄')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'札幌魔獄拉麵', 119, N'地獄')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'黑蒜豚骨拉麵', 129, N'獨特')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'泰式豚骨拉麵', 129, N'獨特')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (2, N'珍珠奶茶拉麵', 177, N'獨特')


INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'紅燒牛肉麵', 90, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'紅燒排骨麵', 80, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'紅燒牛肉湯麵', 60, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'牛肉炸醬麵', 80, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'炸醬麵', 60, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'擔仔麵', 50, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'麻醬麵', 50, N'招牌麵食')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'經典乾麵', 40, N'招牌麵食')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'排骨蛋炒飯', 80, N'炒飯')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'蝦仁蛋炒飯', 70, N'炒飯')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'肉絲蛋炒飯', 70, N'炒飯')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'什蔬蛋炒飯', 65, N'炒飯')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'經典蛋炒飯', 55, N'炒飯')

INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'豬肉水餃10顆', 55, N'其他')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'韭菜水餃10顆', 55, N'其他')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'肉燥飯(大)', 35, N'其他')
INSERT [dbo].[菜單] ([店家ID], [餐點名稱], [單價], [分類]) VALUES (3, N'肉燥飯(小)', 25, N'其他')




--匯入客製化
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (11, N'紅茶', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (12, N'多娜茶', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (13, N'養樂多', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (14, N'香菜汁(+10元)', 10)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (21, N'加麵(+10元)', 10)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (22, N'加起司(+15元)', 15)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (23, N'加泡菜(+20元)', 20)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (24, N'加溏心蛋(+25元)', 25)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (25, N'加叉燒(+30元)', 30)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (31, N'加蒜', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (32, N'加醋', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (33, N'加辣', 0)
GO
INSERT [dbo].[客製化] ([客製化ID], [客製化名稱], [客製化價錢]) VALUES (34, N'加香菜', 0)
GO







