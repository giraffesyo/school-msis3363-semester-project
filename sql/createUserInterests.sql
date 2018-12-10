USE [F18_ksmmcquad]
GO

/****** Object:  Table [dbo].[userInterests]    Script Date: 12/9/2018 10:00:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[userInterests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[videoTopicId] [int] NOT NULL,
 CONSTRAINT [PK_interest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[userInterests]  WITH CHECK ADD  CONSTRAINT [FK_userInterests_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[userInterests] CHECK CONSTRAINT [FK_userInterests_users]
GO

ALTER TABLE [dbo].[userInterests]  WITH CHECK ADD  CONSTRAINT [FK_userInterests_videoTopics] FOREIGN KEY([videoTopicId])
REFERENCES [dbo].[videoTopics] ([id])
GO

ALTER TABLE [dbo].[userInterests] CHECK CONSTRAINT [FK_userInterests_videoTopics]
GO


