CREATE TABLE [dbo].[ResearchData](
	[ResearchId] [int] IDENTITY(1,1) NOT NULL,
	[ResearchCode] [int] NULL,
	[ResearchNameTH] [nvarchar](max) NULL,
	[ResearchNameEN] [nvarchar](max) NULL,
	[StartDateResearch] [datetime] NULL,
	[EndDateResearch] [datetime] NULL,
	[ResearchMoney] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



CREATE TABLE [dbo].[ResearchMoney](
	[ResearchMoneyId] [int] IDENTITY(1,1) NOT NULL,
	[ResearchId] [int] NULL,
	[ResearchMoneyTypeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearchMoneyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[MoneyType](
	[MoneyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[MoneyTypeName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MoneyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



CREATE TABLE [dbo].[PersonnelGroup](
	[PersonGroupId] [int] IDENTITY(1,1) NOT NULL,
	[PersonGroupName] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


CREATE TABLE [dbo].[ResearcherGroup](
	[ResearcherGroupId] [int] IDENTITY(1,1) NOT NULL,
	[ResearcherId] [int] NULL,
	[PersonGroupId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearcherGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[ResearcherPaper](
	[ResearcherPaperId] [int] IDENTITY(1,1) NOT NULL,
	[PaperId] [int] NULL,
	[ResearcherId] [int] NULL,
	[PaperPercent] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearcherPaperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]



CREATE TABLE [dbo].[Researcher](
	[ResearcherId] [int] IDENTITY(1,1) NOT NULL,
	[CitizenId] [nvarchar](max) NULL,
	[TitleTH] [nvarchar](max) NULL,
	[FirstNameTH] [nvarchar](max) NULL,
	[LastNameTH] [nvarchar](max) NULL,
	[DepartmentId] [int] NULL,
	[DepartmentCode] [int] NULL,
	[DepartmentNameTH] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearcherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[ResearchPaper](
	[ResearchPaperId] [int] IDENTITY(1,1) NOT NULL,
	[ResearcherId] [int] NULL,
	[PaperNameTH] [nvarchar](max) NULL,
	[PaperNameEN] [nvarchar](max) NULL,
	[Weigth] [int] NULL,
	[PaperCreateData] [datetime] NULL,
	[MagazineId] [int] NULL,
	[MagazineName] [nvarchar](max) NULL,
	[MagzineVolum] [int] NULL,
	[ResearchId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearchPaperId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



CREATE TABLE [dbo].[ResearchPersonnel](
	[ResearchPersonnelId] [int] IDENTITY(1,1) NOT NULL,
	[ResearcherId] [int] NULL,
	[ResearchId] [int] NULL,
	[ResearchWorkPercent] [decimal](5, 2) NULL,
	[ResearchMoney] [decimal](22, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ResearchPersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
