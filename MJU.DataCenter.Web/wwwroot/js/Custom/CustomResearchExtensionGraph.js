async function ResearchDepartmentGraph(startDate, endDate) {
    var url = startDate != null && endDate != null ? 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchDepartment/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchDepartment?Type=1&api-version=1.0'

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
                    backgroundColor: '#007bff',
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

                // $("#researchDepartmentTable").empty();
                $("#researchDepartmentSection").empty();
                $("#researchDepartmentLabel").empty();
                //  $("#researchDepartmentLabel").append(new Number(data.value[item[0]._index]).toLocaleString("th-TH") );
                $("#researchDepartmentLabel").text(item[0]._model.label);

                var table = $('#researchDepartmentTable').DataTable();
                table.clear().destroy();

                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    $("#researchDepartmentSection").append('<tr><td>TH: ' + value.researchNameTh + '<br/>EN: ' + value.researchNameEn + ' </td><td>' +
                        RenderReseacherName(value.researcher) + '</td><td>' + moment(value.researchEndDate).format("DD/MM/YYYY") + '</td></tr > ')
                });

                $('#researchDepartmentModal').modal('show');
                $('#researchDepartmentModal').on('shown.bs.modal', function () {

                })
                $('#researchDepartmentTable').DataTable({
                    language: {
                        sLengthMenu: "Show _MENU_"
                    }
                });
            }
        }



    });

    var tempData = [];

    $.each(data.label, function (key, title) {
        tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
    });

    $.each(tempData, function (key, item) {
        $("#researchDepartmentGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            + item.val + '</button></td></tr>');
    });

    ResearchDepartmentGraphDS();

    $('[data-toggle="tooltip"]').tooltip();
}

function RenderReseacherName(reseacherList) {
    var listName = '';
    $.each(reseacherList, function (key, value) {
        if (key > 0) {
            listName += '<br/>';
        }
        listName += '' +value.researcherName;      
    });

    return listName;
}


async function ResearchPersonGroupGraph(startDate, endDate) {
    var url = startDate != null && endDate != null ? 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchGroup/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&api-version=1.0' :'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchGroup?Type=1&api-version=1.0'
    
    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            moneyPersonGroupRender(data);

        });
}

async function moneyPersonGroupRender(data) {

    $('#moneyPersonGroupBox').empty(); // this is my <canvas> element
    $('#moneyPersonGroupBox').append('<canvas id="moneyPersonGroup-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

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
    var $moneyPersonGroupChart = $('#moneyPersonGroup-chart')
    var chart = new Chart($moneyPersonGroupChart, {
        type: 'bar',
        data: {
            labels: data.label,
            datasets: [
                {
                    backgroundColor: '#007bff',
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
                $("#moneyPersonGroupSection").empty();
                $("#moneyPersonGroupLabel").empty();
                $("#moneyPersonGroupLabel").text(item[0]._model.label);

                var table = $('#moneyPersonGroupTable').DataTable();
                table.clear().destroy();

                // $("#moneyPersonGroupLabel").append(new Number(data.value[item[0]._index]).toLocaleString("th-TH"));
                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    $("#moneyPersonGroupSection").append('<tr><td>TH: ' + value.researchNameTh + '<br/>EN: ' + value.researchNameEn + ' </td><td>' +
                        RenderReseacherName(value.researcher) + '</td><td>' + moment(value.researchEndDate).format("DD/MM/YYYY") + '</td></tr > ')
                });
                $('#moneyPersonGroupModal').modal('show');
                $('#moneyPersonGroupModal').on('shown.bs.modal', function () {
                })
                $('#moneyPersonGroupTable').DataTable({
                    language: {
                        sLengthMenu: "Show _MENU_"
                    }
                });
            }
        }
    })
}

async function ResearchMoneyRangeGraph(startDate,endDate) {
    var url = startDate != null && endDate != null ? 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchMoney/?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchMoney?Type=1&api-version=1.0'

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchMoneyRangeRender(data);

        });
}

async function ResearchMoneyRangeRender(data) {

    $('#allMoneyRangeBox').empty(); // this is my <canvas> element
    $('#allMoneyRangeBox').append('<canvas id="allMoneyRange-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

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
    var $allMoneyRangeChart = $('#allMoneyRange-chart')
    var chart = new Chart($allMoneyRangeChart, {
        type: 'horizontalBar',
        data: {
            labels: data.label,
            //['ต่ำกว่า 100,000', '100,000 - 500,000', '500,001 - 1,000,000', '1,000,001 - 5,000,000', '5,000,001 - 10,000,000', '10,000,001 - 20,000,000', '20,000,000 ขึ้นไป'],
            //  datasLabels: [1001,1002,1003,1004,1005,1006,1007],
            datasets: [
                {
                    backgroundColor: '#007bff',
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
                $("#allMoneyRangeSection").empty();
                $("#allMoneyRangeLabel").empty();

                $("#allMoneyRangeLabel").text(item[0]._model.label);
                var table = $('#allMoneyRangeTable').DataTable();
                table.clear().destroy();

                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    $("#allMoneyRangeSection").append('<tr><td>TH: ' + value.researchNameTh + '<br/>EN: ' + value.researchNameEn + ' </td><td>' +
                        RenderReseacherName(value.researcher) + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td></tr > ')
                });
                $('#allMoneyRangeModal').modal('show');
                $('#allMoneyRangeModal').on('shown.bs.modal', function () {
                })
                $('#allMoneyRangeTable').DataTable({
                    language: {
                        sLengthMenu: "Show _MENU_"
                    }
                });
            }
        }
    })
}

async function ResearchMoneyTypeGraph(startDate,endDate) {
    var url = startDate != null && endDate != null ? 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchData?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchData?Type=1&api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            moneyTypeRender(data);
        });
}

async function moneyTypeRender(data) {

    $('#moneyTypeBox').empty(); // this is my <canvas> element
    $('#moneyTypeBox').append('<canvas id="moneyType-chart" style="min-height: 300px; height: 300px; max-height: 300px; max-width: 100%;"><canvas>');

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
    var $moneyTypeChart = $('#moneyType-chart');

    var chart = new Chart($moneyTypeChart, {
        type: 'horizontalBar',
        data: {
            labels: data.label,
            datasets: [
                {
                    backgroundColor: '#007bff',
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

                if (item.length == 0) return;

                $("#moneyTypeSection").empty();
                $("#moneyTypeLabel").empty();
                $("#moneyTypeLabel").text(item[0]._model.label);

                var table = $('#moneyTypeTable').DataTable();
                table.clear().destroy();

               /* $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    $("#moneyTypeSection").append('<tr><td>' + value.researchNameTh + ' </td><td>' +
                        value.researcherName + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td> <!--<td></td>--></tr > ')
                });*/
                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    $("#moneyTypeSection").append('<tr><td>TH: ' + value.researchNameTh + '<br/>EN: ' + value.researchNameEn + ' </td><td>' +
                        RenderReseacherName(value.researcher) + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td></tr > ')
                });

                $('#moneyTypeModal').modal('show');
                $('#moneyTypeModal').on('shown.bs.modal', function () {
                })
                $('#moneyTypeTable').DataTable({
                    language: {
                        sLengthMenu: "Show _MENU_"
                    }
                });
            }
        }
    })
}




async function ResearchDepartmentGraphDS() {

    fetch('https://localhost/MJU.DataCenter.researchextension/api/ResearchDepartment/GetDataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {

            RenderResearchDepartmentGraphDS(data);
            Load();
        });
}

async function RenderResearchDepartmentGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researchDepartmentGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researchDepartmentGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.departmentName + '</b></a>'

        $('#researchDepartmentGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="researchDepartmentGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub" id="sub-' + key + '-table">';
        var startThead = '<thead id="sub-researchDepartmentGraphDataSource-thead">';
        var thead = '<tr><th>ชื่องานวิจัย</th><th>ชื่อนักวิจัย</th><th>หน่วยงาน</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';
        var endThead = '</thead>';

        var startBody = '<tbody id="sub-researchDepartmentGraphDataSource-tbody">';
        $.each(result.researchData, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green">' + item.researchNameTh +
                '</a></td><td>' + item.researcherName + '</td>' +
                '<td>' + item.departmentNameTh + '</td >' +
                '<td>' + moment(item.researchStartDate).format("DD/MM/YYYY") + '</td >' +
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

async function Load() {
    $('.dataTable-sub').DataTable({
        language: {
            sLengthMenu: ""
        },
        searching: false,
        pageLength: 5
    });
}


