async function AllPersonGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost:44307/api/PersonnelGroup/1')
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
        })
}
async function PersonAgeGraph() {
    fetch('https://localhost:44307/api/PersonnelPositionGeneration/1')
        .then(res => res.json())
        .then((data) => {
            var barChartData = {
                labels: data.label,
                //  labels: ["January\nFirst Month\nJellyfish\n30 of them", "February\nSecond Month\nFoxes\n20 of them", "March\nThird Month\nMosquitoes\nNone of them", "April", "May", "June", "July"],
                datasets: [
                    {
                        label: data.graphDataSet[0].label,
                        backgroundColor: 'rgba(60,141,188,0.9)',
                        borderColor: 'rgba(60,141,188,0.8)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data: data.graphDataSet[0].data
                    },
                    {
                        label: data.graphDataSet[1].label,
                        backgroundColor: 'rgba(210, 214, 222, 1)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
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
    fetch('https://localhost:44307/api/PersonnelEducation/1')
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
    fetch('https://localhost:44307/api/PersonnelPosition/1')
        .then(res => res.json())
        .then((data) => {
            var donutChartCanvas = $('#pie2Chart').get(0).getContext('2d')
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


async function PersonForcastGenrationGraph() {

    $("#personForcastGenerationBox").empty(); // this is my <canvas> element
    $("#personForcastGenerationBox").append('<canvas id="personForcastGeneration-chart" height="350"><canvas>');

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
            labels: ['ปี 2560', 'ปี 2561', 'ปี 2562', 'ปี 2563', 'ปี 2564', 'ปี 2565', 'ปี 2566'],
            datasets: [{
                type: 'line',
                data: [100, 120, 170, 167, 180, 177, 160],
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
                data: [60, 80, 70, 67, 80, 77, 100],
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
                data: [55, 80, 99],
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

            var url = 'https://localhost:44341/api/ResearchData?Type=1&api-version=1.0';

            fetch(url)
                .then((response) => {
                    return response.json();
                })
                .then((data) => {
                    modalRender(chartName, element, modelLabel, data)
                });

            console.log("Clicked: " + modelLabel + " - " + clickedDatasetPoint);
        }
    });
}

function modalRender(chartName, element, modelLabel, data) {

    var box = '#' + chartName + 'Box';
    var section = '#' + chartName + 'Section';
    var label = '#' + chartName + 'Label';
    var table = '#' + chartName + 'Table';
    var modal = '#' + chartName + 'Modal';



    $(section).empty();
    $(label).empty();
    $(label).text(modelLabel);

    var table = $(table).DataTable();
    table.clear().destroy();





    /* $.each(data.viewData[item[0]._index].lisViewData, function (key, value) {
         $(section).append('<tr><td>TH: ' + value.researchNameTh + '<br/>EN: ' + value.researchNameEn + ' </td><td>' +
             RenderReseacherName(value.researcher) + '</td> <td>' + new Number(value.researchMoney).toLocaleString("th-TH") + '</td></tr > ')
     });*/

    $(modal).modal('show');

    $(modal).on('shown.bs.modal', function () {
    })
    $(table).DataTable({
        language: {
            sLengthMenu: "Show _MENU_"
        }
    });
}