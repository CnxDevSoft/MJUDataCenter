
INSERT [dbo].[AspNetUsers]  VALUES (1, N'general@general.com', N'GENERAL@GENERAL.COM', N'general@general.com', N'GENERAL@GENERAL.COM', 0, N'AQAAAAEAACcQAAAAEFhv7fUKpIsHFNYO0xDn1fJJCFCuglQ3vy+ngrwp38qe1DY5FzukqsFkjvvOcwcw2g==', N'MNK4NDGM5VI5GWSQAD4BNLBC6ZS2QXH2', N'a52e28f9-ea0c-4f2e-aec0-d7f5f0c4315b', NULL, 0, 0, NULL, 0, 0, NULL, NULL, N'f6c558f3-6d35-499b-9a28-3507acd7a266')
INSERT [dbo].[AspNetUsers]  VALUES (2, N'office@office.com', N'OFFICE@OFFICE.COM', N'office@office.com', N'OFFICE@OFFICE.COM', 0, N'AQAAAAEAACcQAAAAEPQK2tt2TLwpKZO4DoZ0Nm5rGIeph0rcGBLP4nHENOOxAm4hKVITY8Kuj9XyPyIE3A==', N'BBUC2VUP4CCUVKL2TJDIQNB64KHURWJL', N'8639ba95-b13d-4bf5-8212-0665c8a4b30b', NULL, 0, 0, NULL, 1, 0, NULL, NULL, N'c8f28971-ca16-48cf-aaeb-feb79a027695')



INSERT [dbo].[AspNetRoles] VALUES (1, N'SuperAdmin', N'SuperAdmin', NULL)
INSERT [dbo].[AspNetRoles] VALUES (2, N'Developer', N'Developer', NULL)
INSERT [dbo].[AspNetRoles] VALUES (3, N'User', N'User', NULL)

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (1, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (2, 3)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (3, 1)
/** [DepartmentRole] **/

INSERT INTO [dbo].[DepartmentRole] VALUES('General',null,null,1,N'ผู้บริหาร')
INSERT INTO [dbo].[DepartmentRole] VALUES('Office',20001,'782c03ba-e85c-4a1e-94ca-90538e4eb1be',1,N'สำนักงานมหาวิทยาลัย')
INSERT INTO [dbo].[DepartmentRole] VALUES('Science',20002,'3bfa3858-dbce-479c-893c-f6ab359ad208',1,N'คณะวิทยาศาสตร์')
INSERT INTO [dbo].[DepartmentRole] VALUES('Engineer',20003,'6feca641-b4db-44b8-b000-cf364394d203',1,N'คณะวิศวกรรมและอุตสาหกรรมเกษตร')
INSERT INTO [dbo].[DepartmentRole] VALUES('BusinessAdministration',20004,'e87b5c7f-1175-47cf-a762-1ace8b5d27d8',1,N'คณะบริหารธุรกิจ')
INSERT INTO [dbo].[DepartmentRole] VALUES('Agriculture',20005,'192287b3-afed-46e7-95c3-f3d897c022b7',1,N'คณะผลิตกรรมการเกษตร')
INSERT INTO [dbo].[DepartmentRole] VALUES('FisheriesTechnologyAndWaterResources',20006,'85704fc2-1a05-4fc7-b84c-d4ecd8afcf59',1,N'คณะบริหารธุรกิจ')
INSERT INTO [dbo].[DepartmentRole] VALUES('TourismDevelopment',20007,'f2fad6ae-eacd-49a3-8dd3-ab9cdc4fe2d9',1,N'คณะพัฒนาการท่องเที่ยว')
INSERT INTO [dbo].[DepartmentRole] VALUES('LiberalArts',20008,'0abac389-431b-4e73-8fee-9f8270a9bdf8',1,N'คณะศิลปศาสตร์')
INSERT INTO [dbo].[DepartmentRole] VALUES('Economics',20009,'0d44070b-047c-44a2-93ae-239236e11c7e',1,N'คณะเศรษฐศาสตร์')
INSERT INTO [dbo].[DepartmentRole] VALUES('AnimalScienceAndTechnology',20010,'be1b82e3-a8fb-4a18-bcca-d29a35641862',1,N'คณะสัตวศาสตร์และเทคโนโลยี')
INSERT INTO [dbo].[DepartmentRole] VALUES('BusinessAdministration',20011,'a9a01d1b-e209-4551-b8ed-70d1ccf03961',1,N'คณะสารสนเทศและการสื่อสาร')


