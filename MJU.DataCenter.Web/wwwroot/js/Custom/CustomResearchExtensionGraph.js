async function ResearchDepartmentGraph() {
    fetch('https://localhost:44341/api/ResearchDepartment/1')
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            allResearchRender(data);
        });
}

async function allResearchRender(data) {
    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }
    var mode = 'index'
    var intersect = true
    var $allResearchChart = $('#allResearch-chart')
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
                $("#researchDepartmentSection").empty();
                $("#researchDepartmentLabel").empty();
                //  $("#researchDepartmentLabel").append(new Number(data.value[item[0]._index]).toLocaleString("th-TH") );
                $("#researchDepartmentLabel").text(item[0]._model.label);
                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    console.log(value)
                    $("#researchDepartmentSection").append('<tr><td>' + value.researchNameTh + ' </td><td>' +
                        value.researcherName + '</td><!--<td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td> <td></td>--></tr > ')
                });
                $('#researchDepartmentModal').modal('show');
                $('#researchDepartmentModal').on('shown.bs.modal', function () {
                })
            }
        }
    })
}

async function ResearchPersonGroupGraph() {
    fetch('https://localhost:44341/api/ResearchGroup/1')
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            moneyPersonGroupRender(data);

        });
}

async function moneyPersonGroupRender(data) {
    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }
    var mode = 'index'
    var intersect = true
    var $moneyPersonGroupChart = $('#moneyPersonGroup-chart')
    var chart = new Chart($moneyPersonGroupChart, {
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
                $("#moneyPersonGroupSection").empty();
                $("#moneyPersonGroupLabel").empty();
                $("#moneyPersonGroupLabel").text(item[0]._model.label);
                // $("#moneyPersonGroupLabel").append(new Number(data.value[item[0]._index]).toLocaleString("th-TH"));
                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    console.log(value)
                    $("#moneyPersonGroupSection").append('<tr><td>' + value.researchNameTh + ' </td><td>' +
                        value.researcherName + '</td> <!--<td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td> <td></td>--></tr > ')
                });
                $('#moneyPersonGroupModal').modal('show');
                $('#moneyPersonGroupModal').on('shown.bs.modal', function () {
                })
            }
        }
    })
}

async function ResearchMoneyRangeGraph() {
    fetch('https://localhost:44341/api/ResearchMoney/1')
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            ResearchMoneyRangeRender(data);

        });
}

async function ResearchMoneyRangeRender(data) {
    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
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
                $("#moneyResearchSection").empty();
                $("#ResearchMoneyLabel").empty();
                $("#ResearchMoneyLabel").text(item[0]._model.label);

                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    console.log(value)
                    $("#moneyResearchSection").append('<tr><td>' + value.researchNameTh + ' </td><td>' +
                        value.researcherName + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td> <td></td></tr > ')
                });
                $('#ResearchMoneyModal').modal('show');
                $('#ResearchMoneyModal').on('shown.bs.modal', function () {
                })
            }
        }
    })
}

async function ResearchMoneyTypeGraph() {
    fetch('https://localhost:44341/api/ResearchData/1')
        .then((response) => {
            Render();
            return response.json();
        })
        .then((data) => {
            moneyTypeRender(data);
        });
}

async function moneyTypeRender(data) {
    'use strict'
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }
    var mode = 'index'
    var intersect = true
    var $moneyTypeChart = $('#moneyType-chart')
    var chart = new Chart($moneyTypeChart, {
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
                $("#moneyTypeSection").empty();
                $("#moneyTypeLabel").empty();
                $("#moneyTypeLabel").text(item[0]._model.label);
                // $("#moneyTypeLabel").append(new Number(data.value[item[0]._index]).toLocaleString("th-TH"));
                $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
                    console.log(value)
                    $("#moneyTypeSection").append('<tr><td>' + value.researchNameTh + ' </td><td>' +
                        value.researcherName + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td> <!--<td></td>--></tr > ')
                });
                $('#moneyTypeModal').modal('show');
                $('#moneyTypeModal').on('shown.bs.modal', function () {
                })
            }
        }
    })
}