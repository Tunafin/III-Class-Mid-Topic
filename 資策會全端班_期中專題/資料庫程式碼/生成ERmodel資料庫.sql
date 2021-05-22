CREATE DATABASE [mySharkDB];
GO

USE [mySharkDB];
GO


CREATE TABLE [班級]
(
	[班級ID] [int] IDENTITY(1,1) NOT NULL ,
	[班級名稱] [nvarchar](20) NOT NULL,

	PRIMARY KEY (班級ID)
);
GO

CREATE TABLE [學生]
(
	[學生ID] [int] IDENTITY(1,1) NOT NULL ,
	[班級ID] [int] NOT NULL,
	[姓名] [nvarchar](20) NOT NULL,
	[密碼] [varchar](20) NOT NULL,
	[在學中] [bit] NOT NULL,
	[主修] [varchar](30)
	

	PRIMARY KEY (學生ID),
	FOREIGN KEY (班級ID) REFERENCES 班級(班級ID)
);
GO
ALTER TABLE [dbo].[學生] ADD  CONSTRAINT [DF_學生_密碼]  DEFAULT ((1234)) FOR [密碼]
GO
ALTER TABLE [dbo].[學生] ADD  CONSTRAINT [DF_學生_在學中]  DEFAULT ((1)) FOR [在學中]
GO


CREATE TABLE [店家]
(
	[店家ID] [int] IDENTITY(1,1) NOT NULL ,
	[店家名稱] [nvarchar](20) NOT NULL,
	[電話] [nvarchar](20),
	[地址] [nvarchar](50),
	[客製化標題] [nvarchar](20),
	[客製化多選] [bit] NOT NULL,

	PRIMARY KEY (店家ID)
);
GO
ALTER TABLE [dbo].[店家] ADD  CONSTRAINT [DF_店家_客製化多選]  DEFAULT ((0)) FOR [客製化多選]
GO



CREATE TABLE [菜單]
(
	[餐點ID] [int] IDENTITY(1,1) NOT NULL ,
	[店家ID] [int] NOT NULL,
	[餐點名稱] [nvarchar](20) NOT NULL,
	[單價] [int] NOT NULL,
	[分類] [nvarchar](20),
	[客製化項目S] [varchar](50),

	PRIMARY KEY (餐點ID),
	FOREIGN KEY (店家ID) REFERENCES 店家 (店家ID)
);
GO

CREATE TABLE [訂單]
(
	[訂單ID] [int] IDENTITY(1,1) NOT NULL ,
	[班級ID] [int] NOT NULL,
	[店家ID] [int] NOT NULL,
	[訂購人] [nvarchar](20),
	[日期] [date] NOT NULL,
	[已鎖定] [bit],
	[最後修改時間] [datetime],

	PRIMARY KEY (訂單ID),
	FOREIGN KEY (班級ID) REFERENCES 班級 (班級ID),
	FOREIGN KEY (店家ID) REFERENCES 店家 (店家ID)
);
GO

CREATE TABLE [訂單明細]
(
	[訂單明細ID] [int] IDENTITY(1,1) NOT NULL ,
	[訂單ID] [int] NOT NULL ,
	[學生ID] [int] NOT NULL,
	[餐點ID] [int] NOT NULL,
	[數量] [int] ,

	PRIMARY KEY (訂單明細ID,訂單ID),
	FOREIGN KEY (訂單ID) REFERENCES 訂單 (訂單ID),
	FOREIGN KEY (學生ID) REFERENCES 學生 (學生ID),
	FOREIGN KEY (餐點ID) REFERENCES 菜單 (餐點ID)
);
GO

CREATE TABLE [dbo].[客製化]
(
	[客製化ID] [int] NOT NULL PRIMARY KEY,
	[客製化名稱] [nvarchar](20) NOT NULL,
	[客製化價錢] [int] NOT NULL,
);
GO
ALTER TABLE [dbo].[客製化] ADD  CONSTRAINT [DF_客製化_客製化價錢]  DEFAULT ((0)) FOR [客製化價錢]
GO

