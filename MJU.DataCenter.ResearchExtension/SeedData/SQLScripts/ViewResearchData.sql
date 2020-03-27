CREATE view [dbo].[DC_researchData]	as 
select r.ResearcherId ,CONCAT(r.TitleTH , ' ', r.FirstNameTH , ' ', r.LastNameTH ) as ResearcherName
,rd.ResearchId 
,rd.ResearchCode
,rd.ResearchNameTH
,rd.ResearchNameEN
,rd.StartDateResearch as ResearchStartDate
,rd.EndDateResearch as ResearchEndDate
,rd.ResearchMoney
,rm.ResearchMoneyTypeId
,mt.MoneyTypeName
from ResearchData rd 
inner join ResearchMoney rm on rd.ResearchId = rm.ResearchId
inner join MoneyType mt on mt.MoneyTypeId = rm.ResearchMoneyTypeId
inner join ResearchPersonnel rp on rm.ResearchId  = rp.ResearchId 
inner join Researcher r on rp.ResearcherId  = r.ResearcherId 


