-- Create Leads table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leads](
    [LeadId] [uniqueidentifier] NOT NULL,
    [FirstName] [nvarchar](100) NOT NULL,
    [LastName] [nvarchar](100) NOT NULL,
    [Email] [nvarchar](100) NOT NULL,
    [PhoneNumber] [nvarchar](15) NOT NULL,
    [Source] [int] NOT NULL,
    [CreatedAt] [datetime] NOT NULL,
    [Status] [int] NOT NULL,
    [Notes] [nvarchar](255) NULL,
    [IsDeleted] [bit] NOT NULL
    ) ON [PRIMARY]
    GO
ALTER TABLE [dbo].[Leads] ADD  CONSTRAINT [PK_Leads] PRIMARY KEY CLUSTERED
    (
    [LeadId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
ALTER TABLE [dbo].[Leads] ADD  CONSTRAINT [DEFAULT_Leads_LeadId]  DEFAULT (newid()) FOR [LeadId]
    GO
ALTER TABLE [dbo].[Leads] ADD  CONSTRAINT [DEFAULT_Leads_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
    GO
ALTER TABLE [dbo].[Leads] ADD  CONSTRAINT [DEFAULT_Leads_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
    GO




GO

-- Create LeadImages table
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[LeadImages](
    [LeadImageId] [int] IDENTITY(1,1) NOT NULL,
    [Image] [varbinary](max) NULL,
    [LeadId] [uniqueidentifier] NOT NULL,
    [IsDeleted] [bit] NOT NULL
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO
ALTER TABLE [dbo].[LeadImages] ADD  CONSTRAINT [PK_LeadImages] PRIMARY KEY CLUSTERED
    (
    [LeadImageId] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    GO
ALTER TABLE [dbo].[LeadImages] ADD  CONSTRAINT [DEFAULT_LeadImages_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
    GO
ALTER TABLE [dbo].[LeadImages]  WITH CHECK ADD  CONSTRAINT [FK_LeadImages_Leads] FOREIGN KEY([LeadId])
    REFERENCES [dbo].[Leads] ([LeadId])
    GO
ALTER TABLE [dbo].[LeadImages] CHECK CONSTRAINT [FK_LeadImages_Leads]
    GO

