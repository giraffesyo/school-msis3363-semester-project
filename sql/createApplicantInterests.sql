USE [F18_ksmmcquad]
GO

/****** Object:  Table [dbo].[applicantInterests]    Script Date: 12/9/2018 9:59:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[applicantInterests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[applicantId] [int] NOT NULL,
	[careerTopicId] [int] NOT NULL,
 CONSTRAINT [PK_applicantInterests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[applicantInterests]  WITH CHECK ADD  CONSTRAINT [FK_applicantInterests_applicants] FOREIGN KEY([applicantId])
REFERENCES [dbo].[applicants] ([id])
GO

ALTER TABLE [dbo].[applicantInterests] CHECK CONSTRAINT [FK_applicantInterests_applicants]
GO

ALTER TABLE [dbo].[applicantInterests]  WITH CHECK ADD  CONSTRAINT [FK_applicantInterests_careerTopics] FOREIGN KEY([careerTopicId])
REFERENCES [dbo].[careerTopics] ([id])
GO

ALTER TABLE [dbo].[applicantInterests] CHECK CONSTRAINT [FK_applicantInterests_careerTopics]
GO


