USE [F18_ksmmcquad]
GO

/****** Object:  Table [dbo].[videos]    Script Date: 12/9/2018 10:01:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[videos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[link] [varchar](255) NOT NULL,
	[topicId] [int] NOT NULL,
 CONSTRAINT [PK_video] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[videos]  WITH CHECK ADD  CONSTRAINT [FK_videos_videoTopics] FOREIGN KEY([topicId])
REFERENCES [dbo].[videoTopics] ([id])
GO

ALTER TABLE [dbo].[videos] CHECK CONSTRAINT [FK_videos_videoTopics]
GO


