CREATE  VIEW  [dbo].[DC_ResearchGroup] as
select pg.PersonGroupId 
,pg.PersonGroupName
,r.ResearcherId,
CONCAT(r.TitleTH , ' ', r.FirstNameTH , ' ', r.LastNameTH ) as ResearcherName,
rd.ResearchId 
,rd.ResearchCode
,rd.ResearchNameTH 
,rd.ResearchNameEN 
,rd.StartDateResearch as ResearchStartDate
,rd.EndDateResearch as ResearchEndDate
from Researcher r 
inner join ResearcherGroup rg on r.ResearcherId  = rg.ResearcherId 
inner join PersonnelGroup  pg on rg.PersonGroupId  = pg.PersonGroupId 
inner join ResearchPersonnel  rp on r.ResearcherId  = rp.ResearcherId 
inner join ResearchData  rd on rd.ResearchId = rp.ResearchId
