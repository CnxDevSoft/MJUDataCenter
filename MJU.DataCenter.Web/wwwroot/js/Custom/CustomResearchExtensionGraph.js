var tokenTemp;
var userNameTemp;
var personnelRootPath = 'https://localhost/MJU.DataCenter.Personnel/api/';
var researchExtensionRootPath = 'https://localhost/MJU.DataCenter.ResearchExtension/api/';

async function SetTempAuthorization(token, userName) {
    tokenTemp = token;
    userNameTemp = userName
}

const obackgroudColor = ["rgba(165,96,229,0.8)", "rgba(127,157,240, 0.8)", "rgba(118,119,232, 0.5)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,0.5)", "rgba(214,237,154,0.5)", "rgba(114, 249, 156,0.5)"];
const oborderColor = ["rgba(165,96,229,1)", "rgba(127,157,240, 1)", "rgba(118,119,232, 1)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,1)", "rgba(214,237,154,1)", "rgba(114, 249, 156,1)"];
const oLanguageOptions = {
    sLengthMenu: "แสดง _MENU_",
    sSearch: "ค้นหา",
    sInfo: "แสดง _START_ ถึง _END_ จาก _TOTAL_ ข้อมูล",
    paginate: {
        "first": "เริ่มต้น",
        "last": "สุดท้าย",
        "next": "ถัดไป",
        "previous": "ย้อนกลับ"
    }
}

async function ResearchFacultyGraph(startDate, endDate, token, userName) {
    var url = startDate != null && endDate != null ? researchExtensionRootPath+'ResearchFaculty/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0'
        : researchExtensionRootPath+'ResearchFaculty?Type=1' + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchDepartmentRender(data);
        });
}
async function ResearchDepartmentRender(data) {

    $('#researchDepartmentBox').empty(); // this is my <canvas> element
    $('#researchDepartmentBox').append('<canvas id="researchDepartment-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        beginAtZero: true,
        stepSize: 10,
        suggestedMin: 0,
        suggestedMax: 100
    }
    var mode = 'index'
    var intersect = true
    var $allResearchChart = $('#researchDepartment-chart');


    var chart = new Chart($allResearchChart, {
        type: 'horizontalBar',
        data: {
            labels: data.label, //['หน่วยงาน 1', 'หน่วยงาน 2', 'หน่วยงาน 3', 'หน่วยงาน 4', 'หน่วยงาน 5', 'หน่วยงาน 6', 'หน่วยงาน 7'],
            //  datasLabels: [1001,1002,1003,1004,1005,1006,1007],
            datasets: [
                {
                    backgroundColor: "rgba(114, 249, 156,0.5)",
                    borderColor: '#007bff',
                    data: data.graphDataSet[0].data,//[50, 25, 1300, 10, 30, 40, 200],
                    //label: [1101,1102,1103,1104,1105]
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                mode: mode,
                intersect: intersect
            },
            hover: {
                mode: mode,
                intersect: intersect
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    // display: false,
                    gridLines: {
                        display: true,
                        lineWidth: '4px',
                        color: 'rgba(0, 0, 0, .2)',
                        zeroLineColor: 'transparent'
                    },
                    ticks: $.extend({
                        beginAtZero: true,
                        // Include a dollar sign in the ticks
                        callback: function (value, index, values) {
                            if (value >= 1000) {
                                value /= 1000
                                value += 'k'
                            }
                            return value;// '$' + value
                        }
                    }, ticksStyle)
                }],
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    ticks: ticksStyle
                }]
            },
            onClick: function (evt, item) {
                if (item.length > 0) {
                    ResearchDepartmentTableDrillDown(item[0]._model.label)
                }              
            }
        }
    });

    var tempData = [];

    $.each(data.label, function (key, title) {
        tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
    });
    var sumValue = 0;
    $.each(tempData, function (key, item) {
        $("#researchDepartmentGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a onClick="ResearchDepartmentTableDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            + item.val + '</button></td></tr>');
        sumValue += item.val;
        //.....onclick even+any funtion
    });
    $("#researchDepartmentGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onClick="ResearchDepartmentTableDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
        + sumValue + '</a></td></tr>');

    /*$("#researchDepartmentGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onClick="ResearchDepartmentTableDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
        + sumValue + '</a></td></tr>');*/

    ResearchDepartmentGraphDS();

    $('[data-toggle="tooltip"]').tooltip();
}
async function ResearchDepartmentGraphDS() {

    fetch(researchExtensionRootPath+'ResearchFaculty/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0')
        .then(res => res.json())
        .then((data) => {

            RenderResearchDepartmentGraphDS(data);
            Load();
        });
}
async function RenderResearchDepartmentGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchDepartmentGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchDepartmentGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.facultyName + '</b></a>'

        $('#researchDepartmentGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="researchDepartmentGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub" id="sub-' + key + '-table">';
        var startThead = '<thead id="sub-researchDepartmentGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>วันที่สิ้นสุดงานวิจัย</th></tr>';
        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchDepartmentGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + moment(item.researchEndDate).format("DD/MM/YYYY") + '</td>' +

                '</tr >';

        });

        var endbody = '</tbody>';
        var endTable = '</table>';
        var endRow = '</div>';
        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;
        $('#researchDepartmentGraphDataSourceModal-card-body').append(html);
    });
}


async function ResearchPersonGroupGraph(startDate, endDate, token, userName) {
    var url = startDate != null && endDate != null ? researchExtensionRootPath +'ResearchGroup/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0'
        : researchExtensionRootPath +'ResearchGroup?Type=1' + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchPersonGroupRender(data);

        });
}
async function ResearchPersonGroupRender(data) {

    $('#researchPersonGroup-chart-canvas').empty(); // this is my <canvas> element
    $('#researchPersonGroup-chart-canvas').append('<canvas id="researchPersongroup-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        beginAtZero: true,
        stepSize: 10,
        suggestedMin: 0,
        suggestedMax: 100
    }
    var mode = 'index'
    var intersect = true
    var $chart = $('#researchPersongroup-chart')
    var chart = new Chart($chart, {
        type: 'bar',
        data: {
            labels: data.label,
            datasets: [
                {
                    backgroundColor: ["rgba(165,96,229,0.8)", "rgba(127,157,240, 0.8)", "rgba(118,119,232, 0.5)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,0.5)", "rgba(214,237,154,0.5)", "rgba(114, 249, 156,0.5)"],
                    borderColor: '#007bff',
                    data: data.graphDataSet[0].data,
                    //label: [1101,1102,1103,1104,1105]
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                mode: mode,
                intersect: intersect
            },
            hover: {
                mode: mode,
                intersect: intersect
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    // display: false,
                    gridLines: {
                        display: true,
                        lineWidth: '4px',
                        color: 'rgba(0, 0, 0, .2)',
                        zeroLineColor: 'transparent'
                    },
                }],
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    ticks: ticksStyle
                }]
            },
            onClick: function (evt, item) {
                ResearchGroupTableDrillDown(item[0]._model.label);
               
            }
        }
    })
    var tempData = [];
    $.each(data.label, function (key, title) {
        tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
    });
    var sumValue = 0;
    $.each(tempData, function (key, item) {
        $("#researchPersonGroupGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a onClick="ResearchGroupTableDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            + item.val + '</button></td></tr>');
        sumValue += item.val;
    });
    $("#researchPersonGroupGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onClick="ResearchGroupTableDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
        + sumValue + '</a></td></tr>');
    ReseachPersonGroupGraphDS();
    $('[data-toggle="tooltip"]').tooltip();
}
async function ReseachPersonGroupGraphDS() {

    fetch(researchExtensionRootPath +'ResearchGroup/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderReseachPersonGroupGraphDS(data);
        });
}
async function RenderReseachPersonGroupGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchPersonGroupGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="researchPersonGroupGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupName + '</b></a>'
        $('#researchPersonGroupGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="researchPersonGroupGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchPersonGroup" id="sub-researchPersonGroup-' + key + '-table">';
        var startThead = '<thead id="sub-researchPersonGroupGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>วันที่สิ้นสุดงานวิจัย</th></tr>';
        var endThead = '</thead>';
        var startBody = '<tbody id="sub-researchPersonGroupGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a  href="#" class="text-green" onclick="DisplayResearhDetailModal(' + item.citizenId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + moment(item.researchEndDate).format("DD/MM/YYYY") + '</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#researchPersonGroupGraphDataSourceModal-card-body').append(html);
    });
}

async function ResearchMoneyRangeGraph(startDate, endDate, token, userName) {
    var url = startDate != null && endDate != null ? researchExtensionRootPath +'ResearchMoney/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&UserName=' + userName + ' &Token=' + token + '&api-version=1.0'
        : researchExtensionRootPath +'ResearchMoney?Type=1' + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchMoneyRangeRender(data);

        });
}
async function ResearchMoneyRangeRender(data) {

    var chartName = 'researchMoneyRange';

    $('#' + chartName + '-chart-canvas').empty(); // this is my <canvas> element
    $('#' + chartName + '-chart-canvas').append('<canvas id="' + chartName + '-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        beginAtZero: true,
        stepSize: 10,
        suggestedMin: 0,
        suggestedMax: 100
    }
    var mode = 'index'
    var intersect = true
    var $chart = $('#' + chartName + '-chart')
    var chart = new Chart($chart, {
        type: 'horizontalBar',
        data: {
            labels: data.label,
            //['ต่ำกว่า 100,000', '100,000 - 500,000', '500,001 - 1,000,000', '1,000,001 - 5,000,000', '5,000,001 - 10,000,000', '10,000,001 - 20,000,000', '20,000,000 ขึ้นไป'],
            //  datasLabels: [1001,1002,1003,1004,1005,1006,1007],
            datasets: [
                {
                    backgroundColor: ["rgba(165,96,229,0.8)", "rgba(127,157,240, 0.8)", "rgba(118,119,232, 0.5)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,0.5)", "rgba(214,237,154,0.5)", "rgba(114, 249, 156,0.5)"],
                    borderColor: '#007bff',
                    data: data.graphDataSet[0].data
                    //[50, 25, 130, 10, 30, 40, 20],
                    //label: [1101,1102,1103,1104,1105]
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                mode: mode,
                intersect: intersect
            },
            hover: {
                mode: mode,
                intersect: intersect
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    // display: false,
                    gridLines: {
                        display: true,
                        lineWidth: '4px',
                        color: 'rgba(0, 0, 0, .2)',
                        zeroLineColor: 'transparent'
                    },
                    ticks: $.extend({
                        beginAtZero: true,
                        // Include a dollar sign in the ticks
                        callback: function (value, index, values) {
                            if (value >= 1000) {
                                value /= 1000
                                value += 'k'
                            }
                            return value;// '$' + value
                        }
                    }, ticksStyle)
                }],
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    ticks: ticksStyle
                }]
            },
            onClick: function (evt, item) {
                ResearchMoneyRangeDrillDown(item[0]._index);
               
            }
        }
    })

    var tempData = [];

    $.each(data.label, function (key, title) {
        tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
    });
    var sumValue = 0;
    $.each(tempData, function (key, item) {
        $('#' + chartName + 'GraphDataTable-tbody').append('<tr><td>' + item.title + '</td><td><a onClick="ResearchMoneyRangeDrillDown(' + "'"+ key + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            + item.val + '</button></td></tr>');
        sumValue += item.val;
    });
    $('#' + chartName + 'GraphDataTable-tbody').append('<tr><td> รวม </td><td><a onClick="ResearchMoneyRangeDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
        + sumValue + '</a></td></tr>');
    ResearchMoneyRangeGraphDS();

    $('[data-toggle="tooltip"]').tooltip();

}
async function ResearchMoneyRangeGraphDS() {

    fetch(researchExtensionRootPath +'ResearchMoney/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderResearchMoneyRangeGraphDS(data);
        });
}
async function RenderResearchMoneyRangeGraphDS(data) {

    var chartName = 'researchMoneyRange';
    console.log(data);
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#' + chartName + 'GraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="' + chartName + 'GraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.researchRankMoneyName + '</b></a>'
        $('#' + chartName + 'GraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="' + chartName + 'GraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-' + chartName + '" id="sub-' + chartName + '-' + key + '-table">';
        var startThead = '<thead id="sub-' + chartName + 'GraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>จำนวนเงิน</th></tr>';
        var endThead = '</thead>';
        var startBody = '<tbody id="sub-' + chartName + 'GraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearhDetailModal(' + item.citizenId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + new Number(item.researchMoney).toLocaleString("th-TH") + ' บาท</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#' + chartName + 'GraphDataSourceModal-card-body').append(html);
    });
}

async function ResearchMoneyTypeGraph(startDate, endDate, token, userName) {
    var url = startDate != null && endDate != null ? researchExtensionRootPath +'ResearchData?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0'
        : researchExtensionRootPath +'ResearchData?Type=1' + '&UserName=' + userName + ' &Token=' + token + ' &api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchMoneyTypeRender(data);
        });
}
async function ResearchMoneyTypeRender(data) {

    var chartName = 'researchMoneyType';

    $('#' + chartName + '-chart-canvas').empty(); // this is my <canvas> element
    $('#' + chartName + '-chart-canvas').append('<canvas id="' + chartName + '-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        beginAtZero: true,
        stepSize: 10,
        suggestedMin: 0,
        suggestedMax: 100
    }
    var mode = 'index'
    var intersect = true
    var $chart = $('#' + chartName + '-chart');

    var chart = new Chart($chart, {
        type: 'horizontalBar',
        data: {
            labels: data.label,
            datasets: [
                {
                    backgroundColor: obackgroudColor,
                    borderColor: ["rgba(165,96,229,1)", "rgba(127,157,240, 1)", "rgba(118,119,232, 1)", "rgba(41, 182, 246, 0.5)", "rgba(75, 202, 219,1)", "rgba(214,237,154,1)", "rgba(114, 249, 156,1)"],
                    data: data.graphDataSet[0].data,
                    //label: [1101,1102,1103,1104,1105]
                }
            ]
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                mode: mode,
                intersect: intersect
            },
            hover: {
                mode: mode,
                intersect: intersect
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    // display: false,
                    gridLines: {
                        display: true,
                        lineWidth: '4px',
                        color: 'rgba(0, 0, 0, .2)',
                        zeroLineColor: 'transparent'
                    },
                }],
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    ticks: ticksStyle
                }]
            },
            onClick: function (evt, item) {
                if (item.length > 0) {
                    ResearchMoneyTypeDrillDown(item[0]._model.label);
                }
            }
        }
    })

    var tempData = [];

    $.each(data.label, function (key, title) {
        tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
    });
    var sumValue = 0;
    $.each(tempData, function (key, item) {
        $('#' + chartName + 'GraphDataTable-tbody').append('<tr><td>' + item.title + '</td><td><a  onClick="ResearchMoneyTypeDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            + item.val + '</button></td></tr>');
        sumValue += item.val;
    });
    $('#' + chartName + 'GraphDataTable-tbody').append('<tr><td> รวม </td><td><a onClick="ResearchMoneyTypeDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
        + sumValue + '</a></td></tr>');
    ResearchMoneyTypeGraphDS();

    $('[data-toggle="tooltip"]').tooltip();

}
async function ResearchMoneyTypeGraphDS() {

    fetch(researchExtensionRootPath +'ResearchData/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderResearchMoneyTypeGraphDS(data);
        });
}
async function RenderResearchMoneyTypeGraphDS(data) {

    var chartName = 'researchMoneyType';

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#' + chartName + 'GraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="' + chartName + 'GraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.moneyTypeName + '</b></a>'
        $('#' + chartName + 'GraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="' + chartName + 'GraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-' + chartName + '" id="sub-' + chartName + '-' + key + '-table">';
        var startThead = '<thead id="sub-' + chartName + 'GraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>จำนวนเงิน</th></tr>';
        var endThead = '</thead>';
        var startBody = '<tbody id="sub-' + chartName + 'GraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + new Number(item.researchMoney).toLocaleString("th-TH")+ ' บาท</td>' +
                '</tr >';
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#' + chartName + 'GraphDataSourceModal-card-body').append(html);
    });
}



async function Load() {
    $('.dataTable-sub').DataTable({
        language: oLanguageOptions,
        // searching: false,
        // pageLength: 5
    });
}

//drilldown department
async function RenderResearchDepartmentDrillDownGraphDS(data) {

    $('#researchDepartmentDrillDownGraphDataSourceModal-card-body').empty();
    $('#researchDepartmentDrillDownGraphDataSourceLabel').empty()
    $('#researchDepartmentDrillDownGraphDataSourceLabel').append("ประเภทหน่วยงาน")

    $.each(data, function (key, result) {
        console.log(result)
        if (data.length>1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchDepartmentDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchDepartmentDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.facultyName + '</b></a>'
            $('#researchDepartmentDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#researchDepartmentDrillDownGraphDataSourceLabel').empty()
            $('#researchDepartmentDrillDownGraphDataSourceLabel').append(result.facultyName)
        }
        var startRow = '<div class="collapse multi-collapse" id="researchDepartmentDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataTable').DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchDepartmentDrillDown" id="dataTableResearchDepartmentDrillDown' + key + '">';

        var startThead = '<thead id="sub-researchDepartmentDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>วันที่สิ้นสุดงานวิจัย</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchDepartmentDrillDownGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.researchId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + moment(item.researchEndDate).format("DD/MM/YYYY") + '</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#researchDepartmentDrillDownGraphDataSourceModal-card-body').append(html);

        $('#researchDepartmentDrillDownGraphDataSourceModal').modal('show');
        $('#researchDepartmentDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataTableResearchDepartmentDrillDown' + key).DataTable({
            language: oLanguageOptions
        });

    });
}

async function ResearchDepartmentTableDrillDown(type) {

    var url = type != null ? researchExtensionRootPath +'ResearchFaculty/GetDataSource?Type=' + type
        + '&UserName=' + userNameTemp + '&Token=' + tokenTemp + '&api-version=1.0'
        : researchExtensionRootPath +'ResearchFaculty/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderResearchDepartmentDrillDownGraphDS(data).then();
        });

}

//drilldown researchGroup

async function ResearchGroupTableDrillDown(type) {
    var url = type != null ? researchExtensionRootPath +'ResearchGroup/GetDataSource?Type=' + type + '&UserName=' + userNameTemp + '&Token=' + tokenTemp + '&api-version=1.0'
        : researchExtensionRootPath +'ResearchGroup/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            console.log(data)
            console.log(url)
            RenderResearchGroupTableDrillDown(data).then();
        });
}

async function RenderResearchGroupTableDrillDown(data) {

    $('#researchGroupDrillDownGraphDataSourceModal-card-body').empty();
    $('#researchGroupDrillDownGraphDataSourceLabel').empty();
    $('#researchGroupDrillDownGraphDataSourceLabel').append("ประเภทหน่วยงาน");
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchGroupDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchGroupDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupName + '</b></a>'
            $('#researchGroupDrillDownGraphDataSourceModal-card-body').append(link)

        } else {
            $('#researchGroupDrillDownGraphDataSourceLabel').empty()
            $('#researchGroupDrillDownGraphDataSourceLabel').append(result.personGroupName)
        }
        var startRow = '<div class="collapse multi-collapse" id="researchGroupDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataTable').DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchGroupDrillDown" id="dataTableResearchGroupDrillDown' + key + '">';

        var startThead = '<thead id="sub-researchGroupDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>วันที่สิ้นสุดงานวิจัย</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchGroupDrillDownGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + moment(item.researchEndDate).format("DD/MM/YYYY") + '</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#researchGroupDrillDownGraphDataSourceModal-card-body').append(html);

        $('#researchGroupDrillDownGraphDataSourceModal').modal('show');
        $('#researchGroupDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataTableResearchGroupDrillDown' + key).DataTable({
            language: oLanguageOptions
        });

    });

}

//drilldown researchMoneyRange

async function RenderResearchMoneyRangeDrillDown(data) {

    $('#researchMoneyRangeDrillDownGraphDataSourceModal-card-body').empty();
    $('#researchMoneyRangeDrillDownGraphDataSourceLabel').empty()
    $('#researchMoneyRangeDrillDownGraphDataSourceLabel').append("งบประมาณ")
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchMoneyRangeDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchMoneyRangeDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.researchRankMoneyName + '</b></a>'
            $('#researchMoneyRangeDrillDownGraphDataSourceModal-card-body').append(link)

        } else {
            $('#researchMoneyRangeDrillDownGraphDataSourceLabel').empty()
            $('#researchMoneyRangeDrillDownGraphDataSourceLabel').append(result.researchRankMoneyName)
        }
        var startRow = '<div class="collapse multi-collapse" id="researchMoneyRangeDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataTable').DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchMoneyRangeDrillDown" id="dataTableResearchMoneyRangeDrillDown' + key + '">';

        var startThead = '<thead id="sub-researchMoneyRangeDrillDownDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>จำนวนเงิน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchMoneyRangeDrillDownGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researchNameEn + '</a></td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + new Number(item.researchMoney).toLocaleString("th-TH") + ' บาท</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#researchMoneyRangeDrillDownGraphDataSourceModal-card-body').append(html);

        $('#researchMoneyRangeDrillDownGraphDataSourceModal').modal('show');
        $('#researchMoneyRangeDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataTableResearchMoneyRangeDrillDown' + key).DataTable({
            language: oLanguageOptions
        });

    });

}

async function ResearchMoneyRangeDrillDown(type) {

    var url = type != null ? researchExtensionRootPath +'ResearchMoney/GetDataSource?Type=' + type + '&UserName=' + userNameTemp + '&Token=' + tokenTemp + '&api-version=1.0'
        : researchExtensionRootPath +'ResearchMoney/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0';


    fetch(url)
        .then(res => res.json())
        .then((data) => {
            console.log(data)
            RenderResearchMoneyRangeDrillDown(data).then();
        });
}

//drilldown researchMoneyType
async function RenderResearchMoneyTypeDrillDown(data) {

    $('#researchMoneyTypeDrillDownGraphDataSourceModal-card-body').empty();
    $('#researchMoneyTypeDrillDownGraphDataSourceLabel').empty()
    $('#researchMoneyTypeDrillDownGraphDataSourceLabel').append("แหล่งทุน")
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchMoneyTypeDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchMoneyTypeDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.moneyTypeName + '</b></a>'
            $('#researchMoneyTypeDrillDownGraphDataSourceModal-card-body').append(link)

        } else {
            $('#researchMoneyTypeDrillDownGraphDataSourceLabel').empty()
            $('#researchMoneyTypeDrillDownGraphDataSourceLabel').append(result.moneyTypeName)
        }
        var startRow = '<div class="collapse multi-collapse" id="researchMoneyTypeDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataTable').DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchMoneyTypeDrillDown" id="dataTableResearchMoneyTypeNameDrillDown' + key + '">';

        var startThead = '<thead id="sub-researchMoneyTypeDrillDownDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>รายชื่องานวิจัย</th><th>ผู้ทำวิจัย</th><th>จำนวนเงิน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchMoneyTypeDrillDownGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researchNameEn + '</td><td>' + RenderReseacherName(item.researcher) + '</td>' +
                '<td>' + new Number(item.researchMoney).toLocaleString("th-TH") + ' บาท</td>' +

                '</tr >';

        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#researchMoneyTypeDrillDownGraphDataSourceModal-card-body').append(html);

        $('#researchMoneyTypeDrillDownGraphDataSourceModal').modal('show');
        $('#researchMoneyTypeDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataTableResearchMoneyTypeNameDrillDown' + key).DataTable({
            language: oLanguageOptions
        });

    });
}

async function ResearchMoneyTypeDrillDown(type) {
    var url = type != null ? researchExtensionRootPath +'ResearchData/GetDataSource?Type=' + type + '&UserName=' + userNameTemp + '&Token=' + tokenTemp + '&api-version=1.0'
        : researchExtensionRootPath +'ResearchData/GetDataSource' + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderResearchMoneyTypeDrillDown(data).then();
        });
}

async function DisplayResearchDetailModal(researchId) {

    console.log(researchId)

    var modal = '#researchDetailModal';
    $('#researchDetailSection').empty();
    $('#researchNameEn').empty();
    $('#researchNameTh').empty();
    $('#researcherCount').empty();
    $('#researchdateTimeRange').empty();
    $('#researchMoneyType').empty();

    var url = researchExtensionRootPath + 'PersonnelResearchData/ResearchDetail/' + researchId + '?UserName=' + userNameTemp + ' &Token=' + tokenTemp + ' &api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {

            $('#researchNameEn').append(data.researchNameEn)
            $('#researchNameTh').append(data.researchNameTh)
            $('#researcherCount').append(data.researcherCount+' คน')
            $('#researchdateTimeRange').append(moment(data.researchStartDate).format('DD/MM/YYYY') + ' - ' + moment(data.researchEndDate).format('DD/MM/YYYY'))
            var moneyType = '';

            var table = $('#researchDetailTable').DataTable();
            table.clear().destroy();

            $.each(data.researchMoney, function (key, item) {
                moneyType += '<strong><i class="fa fa-university mr-1"></i>' + item.researchMoneyTypeName + '</strong><p>' + new Number(item.researchMoney).toLocaleString("th-TH") + ' บาท</p>'
                    '<br/>';

            });

            $('#researchMoneyType').append(moneyType);


            var tableBody='';
            $.each(data.researcher, function (key, item) {
                tableBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.resaerchId + ')">' + item.researcherName + '</td><td>' + item.facultyName + '</td>' +
                    '<td>' + item.researchGroupName + '</td>' +
                    '</tr >';

            });
            $('#researchDetailSection').append(tableBody);
            $("#researchDetailTable").DataTable({
                language: oLanguageOptions
            });
        });

    $(modal).modal('show');

    $(modal).on('shown.bs.modal', function () {
    })

  

    

}






