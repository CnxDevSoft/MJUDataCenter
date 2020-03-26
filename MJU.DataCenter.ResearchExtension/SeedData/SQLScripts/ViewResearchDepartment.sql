CREATE View [dbo].[DC_ResearchDepartment] as
select r.ResearcherId 
,CONCAT(r.TitleTH , ' ', r.FirstNameTH , ' ', r.LastNameTH ) as ResearcherName,
r.DepartmentId 
,r.DepartmentCode
,r.DepartmentNameTH 
,rd.ResearchId 
,rd.ResearchNameEN 
,rd.ResearchNameTH
,rd.ResearchCode
,rd.StartDataResearch as ResearchStartDate
,rd.EndDateResearch as ResearchEndDate
from Researcher r 
inner join ResearchPersonnel rp on r.ResearcherId  = rp.ResearcherId 
inner join ResearchData  rd on rp.ResearchId  = rd.ResearchId