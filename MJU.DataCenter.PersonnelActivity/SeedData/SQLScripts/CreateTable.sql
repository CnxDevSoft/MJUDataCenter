Create table Activity(
	ActivityId int IDENTITY(1,1) NOT NULL,
	ActivityTh nvarchar(max) NULL,
	ActivityEn nvarchar(max) NULL,
	StartDate dateTime NULL,
	EndDate dateTime NULL,
	IsAllDay bit NULL,
	WorkLoadQty int NULL,
	Location nvarchar(max) NULL,
	FacultyId int NULL,
	FacultyName nvarchar(max) NULL,
	ActivityTypeId int NULL,
	ActivityTypeName nvarchar(max) NULL,
PRIMARY KEY CLUSTERED 
(
	ActivityId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

create table PersonnelActivity(
	PersonnelActivityId int IDENTITY(1,1) NOT NULL,
	PersonnelId int NULL,
	ActivityId int NULL,
	CitizenId nvarchar(max) NULL,
	PersonnelName nvarchar(max) NULL,
	HourQty int NULL,
	FacultyId int NULL,
	FacultyName nvarchar(max) NULL,
	PersonnelStatus bit null
PRIMARY KEY CLUSTERED 
(
	PersonnelActivityId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
