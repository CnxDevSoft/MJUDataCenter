function RenderReseacherName(researcherList) {
    //var listName = '';
    //$.each(researcherList, function (key, value) {
    //    if (key > 0) {
    //        listName += '<br/>';
    //    }
    //    listName += '<a href="#" onclick="DisplayPersonInfoDetailModal(' + value.citizenId + ')" class="text-green">' + value.researcherName + '</a>';
    //});

    //return listName;
    return '<a href="#" onclick="DisplayPersonInfoDetailModal(' + researcherList[0].citizenId + ')" class="text-green">' + researcherList[0].researcherName + '</a>'
}