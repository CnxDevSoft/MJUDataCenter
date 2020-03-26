CREATE view [dbo].[DC_ResearchMoney] as
select rd.ResearchId
,CONCAT(rc.TitleTH , ' ', rc.FirstNameTH , ' ', rc.LastNameTH ) as ResearcherName
,rd.ResearchNameTH 
,rd.ResearchNameEN
,rd.ResearchCode
,rd.ResearchMoney
,rd.StartDataResearch as ResearchStartDate
,rm.ResearchMoneyTypeId as ResearchEndDate
,mt.MoneyTypeName
,rp.ResearcherId
from ResearchData rd
inner join ResearchMoney rm on rd.ResearchId = rm.ResearchId
inner join MoneyType mt on rm.ResearchMoneyTypeId = mt.MoneyTypeId
inner join ResearchPersonnel rp on rd.ResearchId = rp.ResearchId
inner join Researcher rc on rp.ResearcherId = rc.ResearcherId