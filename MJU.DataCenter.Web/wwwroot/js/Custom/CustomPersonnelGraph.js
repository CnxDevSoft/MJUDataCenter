﻿
async function AllPersonGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $allPersonalChart = $('#allpersonal-chart')
            var chart = new Chart($allPersonalChart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: [
                        {
                            backgroundColor: '#007bff',
                            borderColor: '#007bff',
                            data: data.graphDataSet[0].data
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
                    }
                }
            })

            var tempData = [];

            $.each(data.label, function (key, title) {
                tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
            });

            $.each(tempData, function (key, item) {
                $("#allPersonGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')'+'">'
                    + item.val + '</button></td></tr>');
            });

            AllPersonGraphDS();

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonAgeGraph() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPositionGeneration/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var barChartData = {
                labels: data.label,
                datasets: [
                    {
                        label: data.graphDataSet[0].label,
                        backgroundColor: 'rgba(148,117,229,0.5)',
                        borderColor: 'rgba(148,117,229,0.5)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(148,117,229,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(148,117,229,1)',
                        data: data.graphDataSet[0].data
                    },
                    {
                        label: data.graphDataSet[1].label,
                        backgroundColor: 'rgba(75,202,219, 0.5)',
                        borderColor: 'rgba(75,202,219, 0.5)',
                        pointRadius: false,
                        pointColor: 'rgba(75,202,219, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(75,202,219,1)',
                        data: data.graphDataSet[1].data
                    },
                ]
            }
            var stackedBarChartCanvas = $('#stackedBarChart').get(0).getContext('2d')
            var stackedBarChartData = jQuery.extend(true, {}, barChartData)
            var stackedBarChartOptions = {
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    xAxes: [{
                        stacked: true,
                    }],
                    yAxes: [{
                        stacked: true
                    }]
                }
            }
            var stackedBarChart = new Chart(stackedBarChartCanvas, {
                type: 'bar',
                data: stackedBarChartData,
                options: stackedBarChartOptions
            })
        })
}
async function PersonEducationGraph() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelEducation/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var donutChartCanvas = $('#pieChart').get(0).getContext('2d')
            var donutData = {
                labels: data.label,
                datasets: [
                    {
                        data: data.graphDataSet[0].data,
                        backgroundColor: ['#f56954', '#00a65a', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
                    }
                ]
            }
            var donutOptions = {
                maintainAspectRatio: false,
                responsive: true,
            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            var donutChart = new Chart(donutChartCanvas, {
                type: 'pie',
                data: donutData,
                options: donutOptions
            })
        })
}
async function PersonTypeGraph() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPosition/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var donutChartCanvas = $('#pie2Chart').get(0).getContext('2d')
            var donutData = {
                labels: data.label,
                datasets: [
                    {
                        data: data.graphDataSet[0].data,
                        backgroundColor: ['#9475E5', '#4BCADB', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
                    }
                ]
            }
            var donutOptions = {
                maintainAspectRatio: false,
                responsive: true,
            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            var donutChart = new Chart(donutChartCanvas, {
                type: 'pie',
                data: donutData,
                options: donutOptions
            })
        })
}
async function PersonWorkAgeGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personWorkAge-chart')
            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: [
                        {
                            label: '1',
                            backgroundColor: 'rgba(148,117,229,0.5)',
                            borderColor: 'rgba(148,117,229,1)',
                            data: data.graphDataSet[0].data
                        },
                        {
                            label: '2',
                            backgroundColor: '#007bff',
                            borderColor: '#007bff',
                            data: data.graphDataSet[0].data
                        },
                        {
                            label: '3',
                            backgroundColor: '#007bff',
                            borderColor: '#007bff',
                            data: data.graphDataSet[0].data
                        }
                    ],
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
                    }
                }
            })

            var tempData = [];

            //$.each(data.label, function (key, title) {
            //    tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
            //});

            //$.each(tempData, function (key, item) {
            //    $("#allPersonGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
            //        + item.val + '</button></td></tr>');
            //});

          //  AllPersonGraphDS();

            $('[data-toggle="tooltip"]').tooltip();
        });
}









async function PersonForcastGenerationGraph() {
    var url ='https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/1/10?api-version=1.0'

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            PersonForcastGenerationRenderGraph(data);
        });
}
async function PersonForcastGenerationRenderGraph(data) {
    $("#personForcastGenerationBox").empty(); // this is my <canvas> element
    $("#personForcastGenerationBox").append('<canvas id="personForcastGeneration-chart" height="350"><canvas>');

    $('#personLabel').empty();
    $('#personLabel').append(data.viewLabel.person +' คน');
    $('#personStartLabel').empty();
    $('#personStartLabel').append(data.viewLabel.personStart + ' คน');
    $('#personPredictionRateLabel').empty();
    $('#personPredictionRateLabel').append(data.viewLabel.predictionRetiredPersonRate + '%');
    $('#personRetiredRateLabel').empty();
    $('#personRetiredRateLabel').append(data.viewLabel.retiredPersonRate + '%');

    'use strict'

    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }

    var mode = 'nearest'
    var intersect = true
    var $personForcastGenerationChart = $('#personForcastGeneration-chart')
    var personForcastGenerationChart = new Chart($personForcastGenerationChart, {
        data: {
            labels: data.label,
            datasets: [{
                type: 'line',
                data: data.graphDataSet[0].data,
                backgroundColor: 'transparent',
                borderColor: '#017f3f',
                pointBorderColor: '#017f3f',
                pointBackgroundColor: '#017f3f',
                fill: true
                // pointHoverBackgroundColor: '#007bff',
                // pointHoverBorderColor    : '#007bff'
            },
            {
                type: 'line',
                data: data.graphDataSet[1].data,
                backgroundColor: 'tansparent',
                borderColor: '#ced4da',
                pointBorderColor: '#ced4da',
                pointBackgroundColor: '#ced4da',
                fill: false
                // pointHoverBackgroundColor: '#ced4da',
                // pointHoverBorderColor    : '#ced4da'
            },
            {
                type: 'line',
                data: data.graphDataSet[2].data,
                backgroundColor: 'tansparent',
                borderColor: 'red',
                pointBorderColor: 'red',
                pointBackgroundColor: 'red',
                fill: false,
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
                        suggestedMax: 200
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
        }
    })
    chartClicked(personForcastGenerationChart, "personForcastGeneration");
}


function chartClicked(chart, chartName) {

    var element = '#' + chartName + "-chart";
    // var modal = '#' + chartName + 'Modal';
    $(element).click(function (event) {
        var activePoint = chart.getElementAtEvent(event);

        if (activePoint.length > 0) {
            var clickedDatasetIndex = activePoint[0]._datasetIndex;
            var clickedElementIndex = activePoint[0]._index;
            var clickedDatasetPoint = chart.data.datasets[clickedDatasetIndex];
            var modelLabel = chart.data.labels[clickedElementIndex];
            var clickedDatasetPoint = clickedDatasetPoint.data[clickedElementIndex];

            var url = 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearchData?Type=1&api-version=1.0';

            fetch(url)
                .then((response) => {
                    return response.json();
                })
                .then((data) => {
                    modalRender(chartName, element, modelLabel, data, clickedDatasetIndex)
                });

            console.log("Clicked: " + modelLabel + " - " + clickedDatasetIndex);
        }
    });
}

function modalRender(chartName, element, modelLabel, data, clickedDatasetIndex) {

    var box = '#' + chartName + 'Box';
    var section = '#' + chartName + 'Section';
    var label = '#' + chartName + 'Label';
    var labelType = '#' + chartName + 'TypeLabel';
    var table = '#' + chartName + 'Table';
    var modal = '#' + chartName + 'Modal';

    $(section).empty();
    $(label).empty();
    $(label).text(modelLabel);

    var labelTypeValue = '';
    if (clickedDatasetIndex == 0) labelTypeValue = 'บุคลากรปัจจุบัน';
    else if (clickedDatasetIndex == 1) labelTypeValue = 'บุคลากรที่คาดว่าจะเกษียณ';
    else if (clickedDatasetIndex == 2) labelTypeValue = 'บุคลากรที่เกษียณแล้ว';
    
    $(labelType).empty();
    $(labelType).text(labelTypeValue);
    

    var dataTable = $(table).DataTable();
    dataTable.clear().destroy();

    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/GetDataTablePersonRetired/' + clickedDatasetIndex + '/' + modelLabel +'?api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            $.each(data, function (key, value) {
                $(section).append('<tr><td>'+ value.personnelName +'</td><td>' +
                    moment(value.dateOfBirth).format("DD/MM/YYYY") + '</td><td>' +
                    value.age + '</td><td>' +
                    value.position + '</td><td>' +
                    value.division + '</td><td>' +
                    value.faculty + '</td></tr > ')
            });

            $(modal).modal('show');
            $(modal).on('shown.bs.modal', function () {
            })
            $(table).DataTable({
                language: {
                    sLengthMenu: "Show _MENU_"
                }
            });
        });
}


async function DisplayPersonProfileModal(firstNameVal, lastNameVal) {

    var table = '#researchInfoTable';
    var modal = '#researchInfoModal';
    var section = '#researchInfoSection';
    var url = 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearcherResearchData/?api-version=1.0&firstName=' + firstNameVal + '&lastName=' + lastNameVal+'?api-version=1.0';

    var dataTable = $(table).DataTable();
    dataTable.clear().destroy();

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            $.each(data, function (key, value) {
                $(section).append('<tr><td><a href="#" class="text-green">' + value.researcherName + '</a></td><td>' +
                    value.departmentNameTh + '</td></tr > ')
            });

            $(modal).modal('show');
            $(modal).on('shown.bs.modal', function () {
            })
            $(table).DataTable({
                language: {
                    sLengthMenu: "Show _MENU_"
                }
            });
        });
}



async function AllPersonGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {

            RenderAllPersonGraphDS(data);
            Load();
        });
}

async function RenderAllPersonGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#allPersonGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="allPersonGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName +'</b></a>'

        $('#allpersonalGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="allPersonGraphDSCollapse' + key +'">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub" id="sub-' + key +'-table">';
        var startThead = '<thead id="sub-allpersonalGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-allpersonalGraphDataSource-tbody">';
        $.each(result.person, function (key, item) {
            startBody += '<tr><td><a href="#" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
                '<td>' + item.position + '</td >' +
                '<td>' + item.positionType + '</td >' +
                '<td>' + item.faculty + '</td>' +
             
                '</tr >';
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#allpersonalGraphDataSourceModal-card-body').append(html);

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