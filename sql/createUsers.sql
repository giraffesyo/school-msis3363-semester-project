USE [F18_ksmmcquad]
GO

/****** Object:  Table [dbo].[users]    Script Date: 12/9/2018 10:00:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](254) NOT NULL,
	[password] [varchar](128) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[phone] [varchar](12) NOT NULL,
	[companyId] [int] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[department] [varchar](50) NOT NULL,
	[newsletter] [bit] NOT NULL,
	[administrator] [bit] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_administrator]  DEFAULT ((0)) FOR [administrator]
GO

ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_companies] FOREIGN KEY([companyId])
REFERENCES [dbo].[companies] ([id])
GO

ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_companies]
GO


