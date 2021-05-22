CREATE DATABASE [mySharkDB];
GO

USE [mySharkDB];
GO


CREATE TABLE [�Z��]
(
	[�Z��ID] [int] IDENTITY(1,1) NOT NULL ,
	[�Z�ŦW��] [nvarchar](20) NOT NULL,

	PRIMARY KEY (�Z��ID)
);
GO

CREATE TABLE [�ǥ�]
(
	[�ǥ�ID] [int] IDENTITY(1,1) NOT NULL ,
	[�Z��ID] [int] NOT NULL,
	[�m�W] [nvarchar](20) NOT NULL,
	[�K�X] [varchar](20) NOT NULL,
	[�b�Ǥ�] [bit] NOT NULL,
	[�D��] [varchar](30)
	

	PRIMARY KEY (�ǥ�ID),
	FOREIGN KEY (�Z��ID) REFERENCES �Z��(�Z��ID)
);
GO
ALTER TABLE [dbo].[�ǥ�] ADD  CONSTRAINT [DF_�ǥ�_�K�X]  DEFAULT ((1234)) FOR [�K�X]
GO
ALTER TABLE [dbo].[�ǥ�] ADD  CONSTRAINT [DF_�ǥ�_�b�Ǥ�]  DEFAULT ((1)) FOR [�b�Ǥ�]
GO


CREATE TABLE [���a]
(
	[���aID] [int] IDENTITY(1,1) NOT NULL ,
	[���a�W��] [nvarchar](20) NOT NULL,
	[�q��] [nvarchar](20),
	[�a�}] [nvarchar](50),
	[�Ȼs�Ƽ��D] [nvarchar](20),
	[�Ȼs�Ʀh��] [bit] NOT NULL,

	PRIMARY KEY (���aID)
);
GO
ALTER TABLE [dbo].[���a] ADD  CONSTRAINT [DF_���a_�Ȼs�Ʀh��]  DEFAULT ((0)) FOR [�Ȼs�Ʀh��]
GO



CREATE TABLE [���]
(
	[�\�IID] [int] IDENTITY(1,1) NOT NULL ,
	[���aID] [int] NOT NULL,
	[�\�I�W��] [nvarchar](20) NOT NULL,
	[���] [int] NOT NULL,
	[����] [nvarchar](20),
	[�Ȼs�ƶ���S] [varchar](50),

	PRIMARY KEY (�\�IID),
	FOREIGN KEY (���aID) REFERENCES ���a (���aID)
);
GO

CREATE TABLE [�q��]
(
	[�q��ID] [int] IDENTITY(1,1) NOT NULL ,
	[�Z��ID] [int] NOT NULL,
	[���aID] [int] NOT NULL,
	[�q�ʤH] [nvarchar](20),
	[���] [date] NOT NULL,
	[�w��w] [bit],
	[�̫�ק�ɶ�] [datetime],

	PRIMARY KEY (�q��ID),
	FOREIGN KEY (�Z��ID) REFERENCES �Z�� (�Z��ID),
	FOREIGN KEY (���aID) REFERENCES ���a (���aID)
);
GO

CREATE TABLE [�q�����]
(
	[�q�����ID] [int] IDENTITY(1,1) NOT NULL ,
	[�q��ID] [int] NOT NULL ,
	[�ǥ�ID] [int] NOT NULL,
	[�\�IID] [int] NOT NULL,
	[�ƶq] [int] ,

	PRIMARY KEY (�q�����ID,�q��ID),
	FOREIGN KEY (�q��ID) REFERENCES �q�� (�q��ID),
	FOREIGN KEY (�ǥ�ID) REFERENCES �ǥ� (�ǥ�ID),
	FOREIGN KEY (�\�IID) REFERENCES ��� (�\�IID)
);
GO

CREATE TABLE [dbo].[�Ȼs��]
(
	[�Ȼs��ID] [int] NOT NULL PRIMARY KEY,
	[�Ȼs�ƦW��] [nvarchar](20) NOT NULL,
	[�Ȼs�ƻ���] [int] NOT NULL,
);
GO
ALTER TABLE [dbo].[�Ȼs��] ADD  CONSTRAINT [DF_�Ȼs��_�Ȼs�ƻ���]  DEFAULT ((0)) FOR [�Ȼs�ƻ���]
GO

