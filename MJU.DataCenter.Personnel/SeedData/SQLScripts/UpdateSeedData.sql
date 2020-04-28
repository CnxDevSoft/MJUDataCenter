
update Person set AdminPositionType = N'คณบดี', AdminPositionId = 30 where AdminPositionType = N'อธิการบดี'

update Person set AdminPositionType = N'อธิการบดี', AdminPositionId = 10 , PersonnelType = N'ข้าราชการ', PersonnelTypeId = N'ค' where PersonnelId = 80