USE [ResearchExtension]
GO
Drop View [dbo].[DC_ResearchFaculty] 

USE [ResearchExtension]
GO
CREATE View [dbo].[DC_ResearchFaculty] as
select r.ResearcherId 
,CONCAT(r.TitleTH , ' ', r.FirstNameTH , ' ', r.LastNameTH ) as ResearcherName,
r.FacultyId 
,r.FacultyCode
,r.FacultyName 
,r.CitizenId
,rd.ResearchId 
,rd.ResearchNameEN 
,rd.ResearchNameTH
,rd.ResearchCode
,rd.StartDateResearch as ResearchStartDate
,rd.EndDateResearch as ResearchEndDate
from Researcher r 
inner join ResearchPersonnel rp on r.ResearcherId  = rp.ResearcherId 
inner join ResearchData  rd on rp.ResearchId  = rd.ResearchId 
