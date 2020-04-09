
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
                    },
                    onClick: function (evt, item) {

                        PersonGroupDrillDown(data.label[item[0]._index]);
                    }
                }
            })

            var tempData = [];

            $.each(data.label, function (key, title) {
                tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
            });

            var sumValue = 0;
            $.each(tempData, function (key, item) {
                $("#allPersonGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a onClick="PersonGroupDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
                    + item.val + '</a></td></tr>');
                sumValue += item.val;
            });

            $("#allPersonGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onClick="PersonGroupDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</a></td></tr>');

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


    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGenderGeneration/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {

            $("#bb-male").text(data[0].personGenderGeneration[0].person);
            $("#bb-female").text(data[1].personGenderGeneration[0].person);

            $("#x-male").text(data[0].personGenderGeneration[1].person);
            $("#x-female").text(data[1].personGenderGeneration[1].person);

            $("#y-male").text(data[0].personGenderGeneration[2].person);
            $("#y-female").text(data[1].personGenderGeneration[2].person);

            $("#z-male").text(data[0].personGenderGeneration[3].person);
            $("#z-female").text(data[1].personGenderGeneration[3].person);

        });


}
async function PersonEducationGraph() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelEducation/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personEducation-Chart').get(0).getContext('2d')
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
                onClick: function (evt, item) {

                    PersonEducationDrillDown(data.label[item[0]._index]);
                }
            }

            var donutChart = new Chart($chart, {
                type: 'pie',
                data: donutData,
                options: donutOptions
            });

            var tempData = [];

            $.each(data.label, function (key, title) {
                tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
            });

            var sumValue = 0;
            $.each(tempData, function (key, item) {
                $("#personEducationGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a  onClick="PersonEducationDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
                    + item.val + '</button></td></tr>');
                sumValue += item.val;
            });

            $("#personEducationGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onClick="PersonEducationDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</button></td></tr>');

            PersonEducationGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonTypeGraph() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPosition/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personType-chart').get(0).getContext('2d')
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
                onClick: function (evt, item) {

                    PersonPositionDrillDown(data.label[item[0]._index]);
                }
            }
            //Create pie or douhnut chart
            // You can switch between pie and douhnut using the method below.
            var donutChart = new Chart($chart, {
                type: 'pie',
                data: donutData,
                options: donutOptions
            });

            var tempData = [];
            $.each(data.label, function (key, title) {
                tempData.push({ "key": key, "val": data.graphDataSet[0].data[key], "title": title });
            });

            var sumValue = 0;
            $.each(tempData, function (key, item) {
                $("#personTypeGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a onclick="PersonPositionDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
                    + item.val + '</button></td></tr>');
                sumValue += item.val;
            });

            $("#personTypeGraphDataTable-tbody").append('<tr><td> รวม </td><td><a onclick="PersonPositionDrillDown()" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</button></td></tr>');

            PersonTypeGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonWorkAgeGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        //  fontStyle: 'bold',
        //  fontSize: 16,
        beginAtZero: true,
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupWorkDuration/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personWorkAge-chart')
            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        mode: mode,
                        intersect: intersect
                    },
                }
            })
            var sumColumns = [];
            var sumValue = 0;
            $.each(data.label, function (key, item) {
                var sumRow = data.graphDataSet[0].data[key] + data.graphDataSet[1].data[key] + data.graphDataSet[2].data[key] + data.graphDataSet[3].data[key]
                    + data.graphDataSet[4].data[key] + data.graphDataSet[5].data[key];

                $("#personWorkAgeGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' +
                    '<td>' + data.graphDataSet[0].data[key] + '</td>' +
                    '<td>' + data.graphDataSet[1].data[key] + '</td>' +
                    '<td>' + data.graphDataSet[2].data[key] + '</td>' +
                    '<td>' + data.graphDataSet[3].data[key] + '</td>' +
                    '<td>' + data.graphDataSet[4].data[key] + '</td>' +
                    '<td>' + data.graphDataSet[5].data[key] + '</td>' +
                    '<td>' + sumRow + '</td></tr>'
                );
                var sumColumn = 0;
                $.each(data.graphDataSet, function (keys, items) {
                    sumColumn += data.graphDataSet[keys].data[key];
                });

                sumValue += sumColumn;
                sumColumns.push(sumColumn);



            });

            $("#personWorkAgeGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' +
                '<td>' + sumColumns[0] + '</td>' +
                '<td>' + sumColumns[1] + '</td>' +
                '<td>' + sumColumns[2] + '</td>' +
                '<td>' + sumColumns[3] + '</td>' +
                '<td>' + sumColumns[4] + '</td>' +
                '<td>' + sumColumns[5] + '</td>' +
                '<td>' + sumValue + '</td></tr > '
            );


            PersonWorkAgeGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupAdminPosition/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personPosition-chart')
            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            //  ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                //  display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            //  ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        // mode: mode,
                        // intersect: intersect
                    },
                }
            })
            $("#personPositionGraphDataTable-thead > tr").append('<th>ตำแหน่งบริหาร</th>');

            var sumColumns = [];
            var labelColumns = []
            var sumRows = [];

            $.each(data.graphDataSet, function (key, item) {
                $("#personPositionGraphDataTable-thead > tr").append(
                    '<th>' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
                labelColumns.push(item.label)
            });

            $("#personPositionGraphDataTable-thead > tr").append(
                '<th>รวม</th>'
            );

            var sumValue = 0;
            $.each(data.label, function (key, item) {
                var html = '';
                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td  onClick="PersonPositionAdminDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personPositionGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td onClick="PersonPositionAdminDrillDown('+"'"+item+"',"+"'"+"'"+')">' + sumRow + '</td></tr>');
            });
            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td onClick="PersonPositionAdminDrillDown('+"'" + "'"+",'"+labelColumns[key]+"'"+')">'+ item + '</td>';

            });
            lastHtml += '<td onClick="PersonPositionAdminDrillDown(' + "'" + "',"+"'" + "'"+')">' + sumValue + '</td>';
            $("#personPositionGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' + lastHtml + '</tr>');

            PersonPositionGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionLevelGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'index'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupPositionLevel/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personPositionLevel-chart')
            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            //  ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                //  display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            //  ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        // mode: mode,
                        // intersect: intersect
                    },
                }
            })
            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;

            $("#personPositionLevelGraphDataTable-thead").append('<th>ประเภทบุคลากร</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personPositionLevelGraphDataTable-thead").append(
                    '<th>' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
            });
            $("#personPositionLevelGraphDataTable-thead").append(
                '<th>รวม</th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td>' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personPositionLevelGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td>' + sumRow + '</td></tr>');
            });

            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td>' + item + '</td>';

            });
            lastHtml += '<td>' + sumValue + '</td>';
            $("#personPositionLevelGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' + lastHtml + '</tr>');

            PersonPositionLevelGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonFacultyGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 1
    }
    var mode = 'nearest'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupFaculty/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personFaculty-chart')


            var ctx = $($chart).get(0).getContext('2d')
            var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
            gradientStroke.addColorStop(0, "#80b6f4");
            gradientStroke.addColorStop(0.2, "#94d973");
            gradientStroke.addColorStop(0.5, "#fad874");
            gradientStroke.addColorStop(1, "#f49080");


            var chart = new Chart($chart, {
                type: 'line',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                ////  display: true,
                                //lineWidth: '4px',
                                //color: 'rgba(0, 0, 0, .2)',
                                //zeroLineColor: 'transparent'
                            },
                            ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        mode: mode,
                        // intersect: intersect
                    },
                }
            })


            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;


            $("#personFacultyGraphDataTable-thead").append('<th>ประเภทและบุคลากร</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personFacultyGraphDataTable-thead").append(
                    '<th>' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
            });

            $("#personFacultyGraphDataTable-thead").append(
                '<th>รวม</th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td>' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personFacultyGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td>' + sumRow + '</td></tr>');
            });


            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td>' + item + '</td>';

            });
            lastHtml += '<td>' + sumValue + '</td>';
            $("#personFacultyGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' + lastHtml + '</tr>');

            PersonFacultyGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionFacultyGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 1
    }
    var mode = 'nearest'
    var intersect = true
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPositionFaculty/1?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personPositionFaculty-chart')

            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            //  ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                //  display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            //  ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        // mode: mode,
                        // intersect: intersect
                    },
                }
            })

            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;


            $("#personPositionFacultyGraphDataTable-thead").append('<th>หน่วยงาน</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personPositionFacultyGraphDataTable-thead").append(
                    '<th>' + item.label + '</th>'
                );

                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
            });

            $("#personPositionFacultyGraphDataTable-thead").append(
                '<th>รวม</th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td>' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personPositionFacultyGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td>' + sumRow + '</td></tr>');

            });

            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td>' + item + '</td>';

            });
            lastHtml += '<td>' + sumValue + '</td>';
            $("#personPositionFacultyGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' + lastHtml + '</tr>');

            PersonPositionFacultyGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonRetiredGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 1
    }
    var mode = 'nearest'
    var intersect = true
    var date = new Date();
    var lastDate = date.setDate(date.getFullYear() - 10).toLocaleString();
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupRetiredYear?Type=1&StartDate=2553-01-01&EndDate=2563-01-01&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            var $chart = $('#personRetired-chart')

            var ctx = $($chart).get(0).getContext('2d')
            var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
            gradientStroke.addColorStop(0, "#80b6f4");
            gradientStroke.addColorStop(0.2, "#94d973");
            gradientStroke.addColorStop(0.5, "#fad874");
            gradientStroke.addColorStop(1, "#f49080");


            var chart = new Chart($chart, {
                type: 'line',
                data: {
                    labels: data.label,
                    datasets: data.graphDataSet,

                },
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    scales: {
                        xAxes: [{
                            stacked: true,
                            //  ticks: ticksStyle
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                //  display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            //  ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        // mode: mode,
                        // intersect: intersect
                    },
                }
            })

            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;

            $("#personRetiredGraphDataTable-thead").append('<th>ปีที่เกษียน</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personRetiredGraphDataTable-thead").append(
                    '<th>' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
            });
            $("#personRetiredGraphDataTable-thead").append(
                '<th>รวม</th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td>' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personRetiredGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td>' + sumRow + '</td></tr>');
            });

            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td>' + item + '</td>';

            });
            lastHtml += '<td>' + sumValue + '</td>';
            $("#personRetiredGraphDataTable-tbody").append(
                '<tr><td>รวม</td>' + lastHtml + '</tr>');
            PersonRetiredGraphDS();
            $('[data-toggle="tooltip"]').tooltip();
        });
}


function RenderDataSet(data, gradientStroke) {
    var datasets = [];
    $.each(data.graphDataSet, function (index, item) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        datasets.push({
            "label": item.label, "data": item.data,
            "fill": true,
            //   "backgroundColor": ['rgb(255, 99, 132)','rgb(0, 255, 0)','rgb(255, 99, 132)','rgb(128, 255, 0)','rgb(0, 255, 255)','rgb(255, 255, 0)','rgb(255, 255, 128)'],
            // "borderColor": ['rgb(255, 99, 132)', 'rgb(0, 255, 0)', 'rgb(255, 99, 132)', 'rgb(128, 255, 0)', 'rgb(0, 255, 255)', 'rgb(255, 255, 0)', 'rgb(255, 255, 128)'],
            "backgroundColor": 'rgba(' + r + ',' + g + ',' + b + ',0.5)',
            "borderColor": 'rgba(' + r + ',' + g + ',' + b + ',1)',
        })
    });
    return datasets;
}


async function PersonForcastGenerationGraph() {
    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/1/10?api-version=1.0'

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
    $('#personLabel').append(data.viewLabel.person + ' คน');
    $('#personStartLabel').empty();
    $('#personStartLabel').append(data.viewLabel.personStart + ' คน');
    $('#personPredictionRateLabel').empty();
    $('#personPredictionRateLabel').append(data.viewLabel.predictionRetiredPersonRate + '%');
    $('#personRetiredRateLabel').empty();
    $('#personRetiredRateLabel').append(data.viewLabel.retiredPersonRate + '%');

    'use strict'

    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        stepSize: 5
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
                backgroundColor: 'rgba(214,237,154,0.5)',
                borderColor: '#017f3f',
                pointBorderColor: '#017f3f',
                pointBackgroundColor: '#017f3f',
                fill: true,
                // steppedLine: true
                // pointHoverBackgroundColor: '#007bff',
                // pointHoverBorderColor    : '#007bff'
            },
            {
                type: 'line',
                data: data.graphDataSet[1].data,
                backgroundColor: '#ced4da',
                borderColor: '#ced4da',
                pointBorderColor: '#ced4da',
                pointBackgroundColor: '#ced4da',
                fill: true,

                // pointHoverBackgroundColor: '#ced4da',
                // pointHoverBorderColor    : '#ced4da'
            },
            {
                type: 'line',
                data: data.graphDataSet[2].data,
                backgroundColor: 'red',
                borderColor: 'red',
                pointBorderColor: 'red',
                pointBackgroundColor: 'red',
                fill: true,
            }

            ]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            tooltips: {
                // mode: mode,
                // intersect: intersect
            },
            hover: {
                //  mode: mode,
                //  intersect: intersect
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{

                    // display: false,
                    //gridLines: {
                    //    display: true,
                    //    lineWidth: '4px',
                    //    color: 'rgba(0, 0, 0, .2)',
                    //    zeroLineColor: 'transparent'
                    //},
                    ticks: $.extend({
                        beginAtZero: true,
                        suggestedMax: 200,
                    }, ticksStyle)
                }],
                xAxes: [{
                    //display: true,
                    //gridLines: {
                    //    display: false
                    //},
                    //ticks: ticksStyle
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

            var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/GetDataTablePersonRetired/' + clickedDatasetIndex + '/' + modelLabel + '?api-version=1.0';

            fetch(url)
                .then((response) => {
                    return response.json();
                })
                .then((data) => {
                    modalRender(chartName, element, modelLabel, data, clickedDatasetIndex)
                });

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

    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/GetDataTablePersonRetired/' + clickedDatasetIndex + '/' + modelLabel + '?api-version=1.0';

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            $.each(data, function (key, value) {
                $(section).append('<tr><td>' + value.personnelName + '</td><td>' +
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
    var url = 'https://localhost/MJU.DataCenter.ResearchExtension/api/ResearcherResearchData/?api-version=1.0&firstName=' + firstNameVal + '&lastName=' + lastNameVal + '?api-version=1.0';

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
        });
}
async function RenderAllPersonGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#allPersonGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="allPersonGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'

        $('#allpersonalGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="allPersonGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-allpersonal" id="sub-allpersonal-' + key + '-table">';
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

async function PersonWorkAgeGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupWorkDuration/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonWorkAgeGraphDS(data);
        });
}
async function RenderPersonWorkAgeGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personWorkAgeGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personWorkAgeGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'

        $('#personWorkAgeGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personWorkAgeGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personWorkAge" id="sub-personWorkAge-' + key + '-table">';
        var startThead = '<thead id="sub-personWorkAgeGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th><th>ช่วงอายุงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personWorkAgeGraphDataSource-tbody">';

        $.each(result.personGroupWorkDuration, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '<td>' + item.workDuration + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#personWorkAgeGraphDataSourceModal-card-body').append(html);
    });
}

async function PersonPositionGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupAdminPosition/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionGraphDS(data);
        });
}
async function RenderPersonPositionGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personPositionGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.adminPositionType + '</b></a>'

        $('#personPositionGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPosition" id="sub-personPosition-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionGraphDataSource-tbody">';

        $.each(result.personGroupAdminPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#personPositionGraphDataSourceModal-card-body').append(html);
    });
}

async function PersonPositionLevelGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupPositionLevel/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionLevelGraphDS(data);
        });
}
async function RenderPersonPositionLevelGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personPositionLevelGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionLevelGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'

        $('#personPositionLevelGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionLevelGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPosition" id="sub-personPosition-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionLevelGraphDataSource-tbody">';

        $.each(result.personGroupPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#personPositionLevelGraphDataSourceModal-card-body').append(html);
    });
}


async function PersonFacultyGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupFaculty/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonFacultyGraphDS(data);
        });
}
async function RenderPersonFacultyGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personFacultyGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personFacultyGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b>'
            + result.faculty + '</b></a>'

        $('#personFacultyGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personFacultyGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personFaculty" id="sub-personFaculty-' + key + '-table">';
        var startThead = '<thead id="sub-personFacultyGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personFacultyGraphDataSource-tbody">';
        $.each(result.personGroupFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#personFacultyGraphDataSourceModal-card-body').append(html);
    });
}

async function PersonPositionFacultyGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPositionFaculty/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionFacultyGraphDS(data);
        });
}
async function RenderPersonPositionFacultyGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personPositionFacultyGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personPositionFacultyGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b>'
            + result.faculty + '</b></a>'

        $('#personPositionFacultyGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionFacultyGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPositionFaculty" id="sub-personPositionFaculty-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionFacultyGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionFacultyGraphDataSource-tbody">';
        $.each(result.personPositionFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;

        $('#personPositionFacultyGraphDataSourceModal-card-body').append(html);
    });
}

async function PersonRetiredGraphDS() {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupRetiredYear/DataSource?StartDate=2553-01-01&EndDate=2563-01-01&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderRetiredGraphDS(data);
        });
}
async function RenderRetiredGraphDS(data) {
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personRetiredGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personRetiredGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b>'
            + result.reitredYear + '</b></a>'

        $('#personRetiredGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personRetiredGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personRetired" id="sub-personRetired-' + key + '-table">';
        var startThead = '<thead id="sub-personRetiredGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';
        var endThead = '</thead>';
        var startBody = '<tbody id="sub-personRetiredGraphDataSource-tbody">';
        $.each(result.personGroupRetiredYear, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';
        var endTable = '</table>';
        var endRow = '</div>';
        var html = startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow;
        $('#personRetiredGraphDataSourceModal-card-body').append(html);
    });
}

async function PersonEducationGraphDS() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelEducation/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonEducationGraphDS(data);
        });
}
async function RenderPersonEducationGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personEducationGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personEducationDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.educationTypeName + '</b></a>'

        $('#personEducationGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personEducationGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personEducation" id="sub-personEducation-' + key + '-table">';
        var startThead = '<thead id="sub-personEducationGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personEducationGraphDataSource-tbody">';
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

        $('#personEducationGraphDataSourceModal-card-body').append(html);

    });
}


async function PersonTypeGraphDS() {
    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelPosition/DataSource?api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonTypeGraphDS(data);
        });
}
async function RenderPersonTypeGraphDS(data) {

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personTypeGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personTypeDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personPositionTypeName + '</b></a>'

        $('#personTypeGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personTypeGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personType" id="sub-personType-' + key + '-table">';
        var startThead = '<thead id="sub-personTypeGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personTypeGraphDataSource-tbody">';
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

        $('#personTypeGraphDataSourceModal-card-body').append(html);

    });
}

async function LoadDataTable(name, key) {

    var dataTableName = '#sub-' + name + '-' + key + '-table';
    $(dataTableName).DataTable({
        language: {
            sLengthMenu: ""
        },
        searching: false,
        pageLength: 5
    });
}
async function Load() {

    $('.dataTable-sub-allpersonal').DataTable({
        language: {
            sLengthMenu: ""
        },
        searching: false,
        pageLength: 5
    });
}


//DrillDown

async function PersonGroupDrillDown(type) {
    var url = type != null ? 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/DataSource?type=' + type + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/DataSource?api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderAllPersonDrillDownGraphDS(data).then();
        });



}

async function RenderAllPersonDrillDownGraphDS(data) {

    $('#allpersonnelDrillDownGraphDataSourceModal-card-body').empty();

    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#allPersonDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="allPersonDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'
            $('#allpersonnelDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#allPersoneDrillDownGraphDataSourceLabel').append(result.personGroupTypeName)
        }
        


        var startRow = '<div class="collapse multi-collapse" id="allPersonDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonnelDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-allpersonal" id="dataPersonnelDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-allpersonalDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-allpersonalDrillDownGraphDataSource-tbody">';
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

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#allpersonnelDrillDownGraphDataSourceModal-card-body').append(html);

        $('#allpersonaleDrillDownGraphDataSourceModal').modal('show');
        $('#allpersonaleDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonnelDrillDownTable' + key).DataTable({
            language: {
                sLengthMenu: "Show _MENU_"
            }
        });

    });
}


async function PersonEducationDrillDown(type) {
    var url = type != null ? 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelEducation/DataSource?type=' + type + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelEducation/DataSource?api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonEducationDrillDownGraphDS(data).then();
        });



}

async function RenderPersonEducationDrillDownGraphDS(data) {
    $('#personEducationDrillDownGraphDataSourceModal-card-body').empty();

    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personEducationDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personEducationDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.educationTypeName + '</b></a>'
            $('#personEducationDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personEducationDrillDownGraphDataSourceLabel').append(result.educationTypeName)
        }

        var startRow = '<div class="collapse multi-collapse" id="personEducationDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonEducationDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personEducation" id="dataPersonEducationDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personEducationDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personEducationGraphDataSource-tbody">';
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

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#personEducationDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personEducationDrillDownGraphDataSourceModal').modal('show');
        $('#personEducationDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonEducationDrillDownTable' + key).DataTable({
            language: {
                sLengthMenu: "Show _MENU_"
            }
        });

    });
}

async function PersonPositionDrillDown(type) {
    var url = type != null ? 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelPosition/DataSource?type=' + type + '&api-version=1.0' : 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelPosition/DataSource?api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionDrillDownGraphDS(data).then();
        });



}

async function RenderPersonPositionDrillDownGraphDS(data) {
    $('#personPositionDrillDownGraphDataSourceModal-card-body').empty();

    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personPositionDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personPositionTypeName + '</b></a>'

            $('#personPositionDrillDownGraphDataSourceModal-card-body').append(link)
        } else {

            $('#personPositionDrillDownGraphDataSourceLabel').append(result.personPositionTypeName)
        }

        var startRow = '<div class="collapse multi-collapse" id="personPositionDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonPositionDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPosition" id="dataPersonPositionDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personPositionDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionGraphDataSource-tbody">';
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

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#personPositionDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personPositionDrillDownGraphDataSourceModal').modal('show');
        $('#personPositionDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonPositionDrillDownTable' + key).DataTable({
            language: {
                sLengthMenu: "Show _MENU_"
            }
        });

    });
}   

async function PersonPositionAdminDrillDown(adminPositionType,personnelType) {
    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroupAdminPosition/DataSource?adminPositionType='+adminPositionType+'&personnelType='+personnelType+'&&api-version=1.0'

    console.log(url)
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionAdminDrillDownGraphDS(data).then();
        });


}


async function RenderPersonPositionAdminDrillDownGraphDS(data) {

    $('#personPositionAdminDrillDownGraphDataSourceModal-card-body').empty();
        console.log(data)
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#personPositionAdminDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionAdminDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.adminPositionType + '</b></a>'

            $('#personPositionAdminDrillDownGraphDataSourceModal-card-body').append(link)
        } else {

            $('#personPositionAdminDrillDownGraphDataSourceLabel').append(result.personPositionTypeName)
        }

        var startRow = '<div class="collapse multi-collapse" id="personPositionAdminDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonPositionAdminDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPositionAdmin" id="dataPersonPositionAdminDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personPositionAdminDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionAdminGraphDataSource-tbody">';
        $.each(result.personGroupAdminPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" class="text-green">' + sItem.personName + '</a></td><td>' +
                    sItem.gender + '</td>' +
                    '<td>' + sItem.position + '</td >' +
                    '<td>' + sItem.positionType + '</td >' +
                    '<td>' + sItem.faculty + '</td>' +
                    '</tr >';
            });
        });
        var endbody = '</tbody>';

        var endTable = '</table>';
        var endRow = '</div>';

        var html = data.length > 1 ? startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
            : startTable + startThead + thead + endThead + startBody + endbody + endTable;


        $('#personPositionAdminDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personPositionAdminDrillDownGraphDataSourceModal').modal('show');
        $('#personPositionAdminDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonPositionAdminDrillDownTable' + key).DataTable({
            language: {
                sLengthMenu: "Show _MENU_"
            }
        });

       
       
    });
}
