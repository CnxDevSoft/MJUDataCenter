
var personnelRootPath = 'https://localhost/MJU.DataCenter.Personnel/api/';
var researchExtensionRootPath = 'https://localhost/MJU.DataCenter.ResearchExtension/api/';
/*
async function SetTempAuthorization(token, userName) {
    tokenTemp = token;
    userNameTemp = userName
}*/
async function GetPersonCount(/*token, userName*/) {
    fetch(personnelRootPath + 'PersonnelDashboard/PersonnelCount?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            console.log("testdata", data.personnelCount, data.personnel);
            $("#PersonCount").text(data.personnelCount);
            $("#Person").text(data.personnel);
        });

}
async function GetResearchCount(/*token, userName*/) {
    fetch(researchExtensionRootPath + 'ResearchExtensionDashboard/ResearchExtensionCount?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            console.log("testdata", data.research, data.researchCount);
            $("#ResearchCount").text(data.researchCount);
            $("#Research").text(data.research);
        });

}