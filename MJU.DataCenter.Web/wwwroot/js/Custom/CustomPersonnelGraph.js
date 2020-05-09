const oLanguagePersonGraphOptions = {
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


async function AllPersonGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16,
    }
    var mode = 'index'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelGroup/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
            var $allPersonalChart = $('#allpersonal-chart')
            var chart = new Chart($allPersonalChart, {
                type: 'horizontalBar',
                data: {
                    labels: data.label,
                    datasets: [
                        {
                            backgroundColor: ['#9475E5', '#4BCADB', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
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
                        display: false,
                        labels: {
                            fontFamily: "'Kanit', sans-serif"
                        }
                    },
                    scales: {
                        yAxes: [{
                            radius: 25,
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
                            radius: 25,
                            display: true,
                            gridLines: {
                                display: false
                            },
                            ticks: ticksStyle
                        }]
                    },
                    onClick: function (evt, item) {
                        if (item.length > 0) {
                            PersonGroupDrillDown(data.label[item[0]._index]);
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
                $("#allPersonGraphDataTable-tbody").append('<tr><td>' + item.title + '</td><td><a onClick="PersonGroupDrillDown(' + "'" + item.title + "'" + ')" data-placement="right" data-toggle="tooltip" title="' + item.title + '(' + item.val + ')' + '">'
                    + item.val + '</a></td></tr>');
                sumValue += item.val;
            });

            $("#allPersonGraphDataTable-tbody").append('<tr><td><strong class="th-text-green">รวม</strong></td><td><a onClick="PersonGroupDrillDown(' + "''" + ')" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</a></td></tr>');

            //AllPersonGraphDS(token, userName);

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonAgeGraph() {

    fetch(personnelRootPath + 'PersonnelPositionGeneration/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
            var ticksStyle = {
                fontColor: '#495057',
                fontStyle: 'bold',
                fontSize: 10,
            }
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
                        ticks: ticksStyle
                    }],
                    yAxes: [{
                        stacked: true,
                        ticks: ticksStyle
                    }]
                },
                onClick: handleClick

            }
            var stackedBarChart = new Chart(stackedBarChartCanvas, {
                type: 'bar',
                data: stackedBarChartData,
                options: stackedBarChartOptions

            })

            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = stackedBarChart.getElementAtEvent(evt);
                    PersonGenerationDrillDown(activeElement[0]._index, data.graphDataSet[activeElement[0]._datasetIndex].label)
                }
            }
        })


    fetch(personnelRootPath + 'PersonnelGenderGeneration/1?' + 'Token=' + accessToken + '&api-version=1.0')
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

            $("#click-bb-male").click(function (evt) {
                var genderId = data[0].genderId;
                var genderName = data[0].gender;
                var generationType = 0;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-bb-female").click(function (evt) {
                var genderId = data[1].genderId;
                var genderName = data[1].gender;
                var generationType = 0;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-x-male").click(function (evt) {
                var genderId = data[0].genderId;
                var genderName = data[0].gender;
                var generationType = 1;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-x-female").click(function (evt) {
                var genderId = data[1].genderId;
                var genderName = data[1].gender;
                var generationType = 1;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-y-male").click(function (evt) {
                var genderId = data[0].genderId;
                var genderName = data[0].gender;
                var generationType = 2;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-y-female").click(function (evt) {
                var genderId = data[1].genderId;
                var genderName = data[1].gender;
                var generationType = 2;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-z-male").click(function (evt) {
                var genderId = data[0].genderId;
                var genderName = data[0].gender;
                var generationType = 3;

                genderClick(genderId, genderName, generationType);
            });
            $("#click-z-female").click(function (evt) {
                var genderId = data[1].genderId;
                var genderName = data[1].gender;
                var generationType = 3;

                genderClick(genderId, genderName, generationType);
            });
        });
}
async function PersonEducationGraph() {
    fetch(personnelRootPath + 'PersonnelEducation/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
            var $chart = $('#personEducation-Chart').get(0).getContext('2d')
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
                    if (item.length > 0) {
                        PersonEducationDrillDown(data.label[item[0]._index]);
                    }
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

            $("#personEducationGraphDataTable-tbody").append('<tr><td><strong class="th-text-green">รวม</strong></td><td><a onClick="PersonEducationDrillDown(' + "''" + ')" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</button></td></tr>');
            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonTypeGraph() {
    fetch(personnelRootPath + 'PersonnelPosition/1/?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
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
                    if (item.length > 0) {
                        PersonPositionDrillDown(data.label[item[0]._index]);
                    }
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

            $("#personTypeGraphDataTable-tbody").append('<tr><td><strong class="th-text-green">รวม</strong></td><td><a onclick="PersonPositionDrillDown(' + "''" + ')" data-placement="right" data-toggle="tooltip" title="รวม(' + sumValue + ')' + '">'
                + sumValue + '</button></td></tr>');

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function EducationInPersonTypeGraph() {

}
async function PersonWorkAgeGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        //  fontStyle: 'bold',
        //  fontSize: 16,
        beginAtZero: true,
    }
    var mode = 'point'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelGroupWorkDuration/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
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
                        }],
                        yAxes: [{
                            stacked: true,
                            gridLines: {
                                display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                        }]
                    },
                    tooltips: {
                        mode: mode,
                        intersect: intersect
                    },
                    onClick: handleClick

                }
            })

            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    PersonWorkDurationDrillDown(data.label[activeElement[0]._index], activeElement[0]._datasetIndex)
                }
            }

            var sumColumns = [];
            var sumValue = 0;
            $.each(data.label, function (key, item) {
                var sumRow = data.graphDataSet[0].data[key] + data.graphDataSet[1].data[key] + data.graphDataSet[2].data[key] + data.graphDataSet[3].data[key]
                    + data.graphDataSet[4].data[key] + data.graphDataSet[5].data[key];

                $("#personWorkAgeGraphDataTable-tbody").append(
                    '<tr><td >' + item + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',0)">' + data.graphDataSet[0].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',1)">' + data.graphDataSet[1].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',2)">' + data.graphDataSet[2].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',3)">' + data.graphDataSet[3].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',4)">' + data.graphDataSet[4].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',5)">' + data.graphDataSet[5].data[key] + '</td>' +
                    '<td onclick="PersonWorkDurationDrillDown(' + "'" + data.label[key] + "'" + ',' + "''" + ')">' + sumRow + '</td></tr>'
                );
            });


            $.each(data.graphDataSet, function (keys, items) {
                var sumColumn = 0;
                $.each(data.label, function (key, item) {
                    sumColumn += data.graphDataSet[keys].data[key];

                })
                sumValue += sumColumn;
                sumColumns.push(sumColumn);

            });

            $("#personWorkAgeGraphDataTable-tbody").append(
                '<tr><td><strong class="th-text-green">รวม</strong></td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',0)">' + sumColumns[0] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',1)">' + sumColumns[1] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',2)">' + sumColumns[2] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',3)">' + sumColumns[3] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',4)">' + sumColumns[4] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',5)">' + sumColumns[5] + '</td>' +
                '<td onclick="PersonWorkDurationDrillDown(' + "''" + ',' + "''" + ')">' + sumValue + '</td></tr > '
            );

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'point'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelGroupAdminPosition/1/?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
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
                        mode: mode,
                        intersect: intersect
                    },
                    onClick: handleClick
                }
            })

            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    PersonPositionAdminDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
                }
            }


            $("#personPositionGraphDataTable-thead > tr").append('<th class="th-text-green">ตำแหน่งบริหาร</th>');

            var sumColumns = [];
            var labelColumns = []
            var sumRows = [];

            $.each(data.graphDataSet, function (key, item) {
                $("#personPositionGraphDataTable-thead > tr").append(
                    '<th class="th-text-green">' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
                labelColumns.push(item.label)
            });

            $("#personPositionGraphDataTable-thead > tr").append(
                '<th><strong class="th-text-green">รวม</strong></th>'
            );

            var sumValue = 0;
            $.each(data.label, function (key, item) {
                var html = '';
                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td onClick="PersonPositionAdminDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personPositionGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td onClick="PersonPositionAdminDrillDown(' + "'" + item + "'," + "'" + "'" + ')">' + sumRow + '</td></tr>');
            });
            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td onClick="PersonPositionAdminDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'" + ')">' + item + '</td>';

            });
            lastHtml += '<td onClick="PersonPositionAdminDrillDown(' + "'" + "'," + "'" + "'" + ')">' + sumValue + '</td>';
            $("#personPositionGraphDataTable-tbody").append(
                '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionLevelGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        fontSize: 16
    }
    var mode = 'point'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelGroupPositionLevel/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
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
                        mode: mode,
                        intersect: intersect
                    },
                    onClick: handleClick
                }
            })
            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    PersonPositionLevelDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)

                    console.log(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
                }
            }

            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;
            var labelColumns = [];

            $("#personPositionLevelGraphDataTable-thead").append('<th class="th-text-green">ประเภทบุคลากร</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personPositionLevelGraphDataTable-thead").append(
                    '<th class="th-text-green">' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
                labelColumns.push(item.label);
            });
            $("#personPositionLevelGraphDataTable-thead").append(
                '<th><strong class="th-text-green">รวม</strong></th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {

                    html += '<td onClick="PersonPositionLevelDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personPositionLevelGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td onClick="PersonPositionLevelDrillDown(' + "'" + item + "'," + "'" + "'" + ')">' + sumRow + '</td></tr>');
            });

            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td onClick="PersonPositionLevelDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'" + ')">' + item + '</td>';
            });
            lastHtml += '<td onClick="PersonPositionLevelDrillDown(' + "'" + "'," + "'" + "'" + ')">' + sumValue + '</td>';
            $("#personPositionLevelGraphDataTable-tbody").append(
                '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonFacultyGraph() {
    var ticksStyle = {
        fontColor: '#495057',
        // fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 10
    }
    var mode = 'nearest'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelGroupFaculty/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
            var $chart = $('#personFaculty-chart')

            var ctx = $($chart).get(0).getContext('2d')
            var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
            gradientStroke.addColorStop(0, "#80b6f4");
            gradientStroke.addColorStop(0.2, "#94d973");
            gradientStroke.addColorStop(0.5, "#fad874");
            gradientStroke.addColorStop(1, "#f49080");

            $chart.height = 500;

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
                                // display: true,
                                lineWidth: '4px',
                                color: 'rgba(0, 0, 0, .2)',
                                zeroLineColor: 'transparent'
                            },
                            ticks: ticksStyle
                        }]
                    },
                    tooltips: {
                        mode: mode,
                        // intersect: intersect
                    },
                    onClick: handleClick
                }
            })
            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    PersonGroupFacultyDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)

                    console.log(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
                }
            }

            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;
            var labelColumns = [];

            $("#personFacultyGraphDataTable-thead").append('<th class="th-text-green">ประเภทและบุคลากร</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personFacultyGraphDataTable-thead").append(
                    '<th class="th-text-green">' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
                labelColumns.push(item.label);
            });

            $("#personFacultyGraphDataTable-thead").append(
                '<th><strong class="th-text-green">รวม</strong></th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td onClick="PersonGroupFacultyDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personFacultyGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td onClick="PersonGroupFacultyDrillDown(' + "'" + item + "'," + "'" + "'" + ')">' + sumRow + '</td></tr>');
            });


            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td onClick="PersonGroupFacultyDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'" + ')">' + item + '</td>';

            });
            lastHtml += '<td onClick="PersonGroupFacultyDrillDown(' + "'" + "'," + "'" + "'" + ')">' + sumValue + '</td>';
            $("#personFacultyGraphDataTable-tbody").append(
                '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

            $('[data-toggle="tooltip"]').tooltip();
        });
}
async function PersonPositionFacultyGraph(token, userName) {
    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 1
    }
    var mode = 'nearest'
    var intersect = true
    fetch(personnelRootPath + 'PersonnelPositionFaculty/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
            var $chart = $('#personPositionFaculty-chart')
            if (data.isSubGraphDataSet) {

                PersonPositionFacultySubGraph($chart, data);
            }
            else {
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
                            mode: mode,
                            intersect: intersect
                        },
                        onClick: handleClick
                    }
                })

                function handleClick(evt, item) {
                    if (item.length > 0) {
                        var activeElement = chart.getElementAtEvent(evt);
                        PersonPositionFacultyDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
                    }
                }
                var sumColumns = [];
                var sumRows = [];
                var sumValue = 0;
                var labelColumns = [];

                $("#personPositionFacultyGraphDataTable-thead").append('<th class="th-text-green">หน่วยงาน</th>');
                $.each(data.graphDataSet, function (key, item) {
                    $("#personPositionFacultyGraphDataTable-thead").append(
                        '<th class="th-text-green">' + item.label + '</th>'
                    );

                    var sumColumn = 0;

                    $.each(data.label, function (keys, item) {
                        sumColumn += data.graphDataSet[key].data[keys];
                    });
                    sumColumns.push(sumColumn);
                    labelColumns.push(item.label);
                });

                $("#personPositionFacultyGraphDataTable-thead").append(
                    '<th><strong class="th-text-green">รวม</strong></th>'
                );

                $.each(data.label, function (key, item) {
                    var html = '';

                    var sumRow = 0;
                    $.each(data.graphDataSet, function (keys, sItem) {
                        html += '<td onClick="PersonPositionFacultyDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                        sumRow += data.graphDataSet[keys].data[key];
                    });

                    sumValue += sumRow;
                    sumRows.push(sumRow);


                    $("#personPositionFacultyGraphDataTable-tbody").append(
                        '<tr><td>' + item + '</td>' + html + '<td onClick="PersonPositionFacultyDrillDown(' + "'" + item + "'," + "'" + "'" + ')">' + sumRow + '</td></tr>');

                });

                var lastHtml;
                $.each(sumColumns, function (key, item) {
                    lastHtml += '<td onClick="PersonPositionFacultyDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'" + ')">' + item + '</td>';

                });
                lastHtml += '<td onClick="PersonPositionFacultyDrillDown(' + "'" + "'," + "'" + "'" + ')">' + sumValue + '</td>';
                $("#personPositionFacultyGraphDataTable-tbody").append(
                    '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

                $('[data-toggle="tooltip"]').tooltip();

            }

        });
}
async function PersonRetiredGraph(token, userName) {
    var endDate = moment(moment().add(543, 'Y')).format('YYYY-MM-DD');
    var startDate = moment(moment(endDate).add(-10, 'Y')).endOf('year').format('YYYY-MM-DD');
                                   

    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold',
        // fontSize: 16,
        stepSize: 1
    }
    var mode = 'nearest'

    var url = personnelRootPath + 'PersonnelGroupRetiredYear?Type=1&StartDate=' + startDate + '&EndDate=' + endDate + '&Token=' + accessToken + '&api-version=1.0';

    console.log(url)
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            Chart.defaults.global.defaultFontFamily = "'Kanit', sans-serif";
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
                    onClick: handleClick
                }
            })



            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    PersonRetiredDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label, startDate, endDate)
                }
            }
            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;
            var labelColumns = [];

            $("#personRetiredGraphDataTable-thead").append('<th class="th-text-green">ปีที่เกษียน</th>');
            $.each(data.graphDataSet, function (key, item) {
                $("#personRetiredGraphDataTable-thead").append(
                    '<th class="th-text-green">' + item.label + '</th>'
                );
                var sumColumn = 0;

                $.each(data.label, function (keys, item) {
                    sumColumn += data.graphDataSet[key].data[keys];
                });
                sumColumns.push(sumColumn);
                labelColumns.push(item.label);
            });
            $("#personRetiredGraphDataTable-thead").append(
                '<th><strong class="th-text-green">รวม</strong></th>'
            );

            $.each(data.label, function (key, item) {
                var html = '';

                var sumRow = 0;
                $.each(data.graphDataSet, function (keys, sItem) {
                    html += '<td onClick="PersonRetiredDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'," + "'" + startDate + "'" + ",'" + endDate + "'" + ')">' + data.graphDataSet[keys].data[key] + '</td>';
                    sumRow += data.graphDataSet[keys].data[key];
                });

                sumValue += sumRow;
                sumRows.push(sumRow);

                $("#personRetiredGraphDataTable-tbody").append(
                    '<tr><td>' + item + '</td>' + html + '<td onClick="PersonRetiredDrillDown(' + "'" + item + "'," + "'" + "'," + "'" + startDate + "'," + "'" + endDate + "'" + ')">' + sumRow + '</td></tr>');
            });

            var lastHtml;
            $.each(sumColumns, function (key, item) {
                lastHtml += '<td onClick="PersonRetiredDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'," + "'" + startDate + "'," + "'" + endDate + "'" + ')">' + item + '</td>';

            });
            lastHtml += '<td onClick="PersonRetiredDrillDown(' + "'" + "'," + "'" + "'," + "'" + startDate + "'," + "'" + endDate + "'" + ')">' + sumValue + '</td>';
            $("#personRetiredGraphDataTable-tbody").append(
                '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

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
function genderClick(genderId, genderName, generationType) {
    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelGenderGeneration/DataSourceByType/' + generationType + '/' + genderId + '/' + genderName + '?Token=' + accessToken + '&api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {

            $('#researcherGenderDrillDownGraphDataSourceModal-card-body').empty();
            $.each(data, function (key, result) {

                var link = '<a class="btn btn-default collapse-ds" data-toggle="collapse" href="#researcherGenderDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="researcherGenderDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.gender + '</b></a>'
                var labelEmty = $("#researcherGenderDrillDownGraphDataSourceLabel").empty();
                var label = $("#researcherGenderDrillDownGraphDataSourceLabel").text(data[0].gender + ' ' + data[0].personGenderGeneration[0].generetion);
                $('#researcherGenderDrillDownGraphDataSourceModal-card-body').append(link)
                var startRow = '<div class="collapse multi-collapse" id="researcherGenderDrillDownGraphDSCollapse' + key + '">';
                var table = $('#dataTable').DataTable();
                table.clear().destroy();

                var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researcherGenderDrillDown" id="dataTableResearcherGenderDrillDown' + key + '">';

                var startThead = '<thead id="sub-researcherGenderDrillDownGraphDataSource-thead">';
                var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

                var endThead = '</thead>';

                var startBody = '<tbody id="sub-researcherGenderDrillDownGraphDataSource-tbody">';
                $.each(result.personGenderGeneration[0].person, function (key, item) {
                    startBody += '<tr><td><a href="#" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
                        '<td>' + moment(item.dateOfBirth).format("DD/MM/YYYY") + '</td >' +
                        '<td>' + item.position + '</td >' +
                        '<td>' + item.division + '</td>' +

                        '</tr >';

                });
                var endbody = '</tbody>';

                var endTable = '</table>';
                var endRow = '</div>';

                var html = data.length > 1 ? labelEmty + label + startRow + startTable + startThead + thead + endThead + startBody + endbody + endTable + endRow
                    : startTable + startThead + thead + endThead + startBody + endbody + endTable;


                $('#researcherGenderDrillDownGraphDataSourceModal-card-body').append(html);

                $('#researcherGenderDrillDownGraphDataSourceModal').modal('show');
                $('#researcherGenderDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

                })

                $('#dataTableResearcherGenderDrillDown' + key).DataTable({
                    language: oLanguagePersonGraphOptions
                });
            });
        });
}

async function PersonForcastGenerationGraph(token, userName) {
    var url = personnelRootPath + 'PersonnelRetired/1/10?Token=' + accessToken + '&api-version=1.0'

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






async function AllPersonGraphDS(token, userName) {

    fetch('https://localhost/MJU.DataCenter.Personnel/api/PersonnelGroup/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderAllPersonGraphDS(data);
        });
}
async function RenderAllPersonGraphDS(data) {
    $('#allpersonalGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#allPersonGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="allPersonGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.personGroupTypeName + '</b></a>'
        var table = $('#sub-allpersonal-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#allpersonalGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="allPersonGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-allpersonal" id="sub-allpersonal-' + key + '-table">';
        var startThead = '<thead id="sub-allpersonalGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-allpersonalGraphDataSource-tbody">';
        $.each(result.person, function (key, item) {
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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

        $('#allpersonalGraphDataSourceModal').modal('show');
        $('#allpersonalGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-allpersonal-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });

    });
}



async function PersonWorkAgeGraphDS(token, userName) {

    fetch(personnelRootPath + 'PersonnelGroupWorkDuration/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonWorkAgeGraphDS(data);
        });
}
async function RenderPersonWorkAgeGraphDS(data) {
    $('#personWorkAgeGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personWorkAgeGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personWorkAgeGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.personGroupTypeName + '</b></a>'
        var table = $('#sub-personWorkAge-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personWorkAgeGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personWorkAgeGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personWorkAge" id="sub-personWorkAge-' + key + '-table">';
        var startThead = '<thead id="sub-personWorkAgeGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th><th>ช่วงอายุงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personWorkAgeGraphDataSource-tbody">';

        $.each(result.personGroupWorkDuration, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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
        $('#personWorkAgeGraphDataSourceModal').modal('show');
        $('#personWorkAgeGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personWorkAge-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionGraphDS(token, userName) {

    fetch(personnelRootPath + 'PersonnelGroupAdminPosition/DataSource?UserName=' + userName + ' &Token=' + token + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionGraphDS(data);
        });
}
async function RenderPersonPositionGraphDS(data) {

    $('#personPositionGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.adminPositionType + '</b></a>'
        var table = $('#sub-personPosition-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personPositionGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPosition" id="sub-personPosition-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionGraphDataSource-tbody">';

        $.each(result.personGroupAdminPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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

        $('#personPositionGraphDataSourceModal').modal('show');
        $('#personPositionGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personPosition-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionLevelGraphDS(token, userName) {

    fetch(personnelRootPath + 'PersonnelGroupPositionLevel/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionLevelGraphDS(data);
        });
}
async function RenderPersonPositionLevelGraphDS(data) {
    $('#personPositionLevelGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionLevelGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionLevelGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.personGroupTypeName + '</b></a>'
        var table = $('#sub-personPosition-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personPositionLevelGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionLevelGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPosition" id="sub-personPosition-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionLevelGraphDataSource-tbody">';

        $.each(result.personGroupPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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
        $('#personPositionLevelGraphDataSourceModal').modal('show');
        $('#personPositionLevelGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personPosition-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}


async function PersonFacultyGraphDS(token, userName) {

    fetch(personnelRootPath + 'PersonnelGroupFaculty/DataSource?UserName=' + userName + ' &Token=' + token + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonFacultyGraphDS(data);
        });
}
async function RenderPersonFacultyGraphDS(data) {
    $('#personFacultyGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personFacultyGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personFacultyGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">'
            + result.faculty + '</b></a>'

        var table = $('#sub-personFaculty-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personFacultyGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personFacultyGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personFaculty" id="sub-personFaculty-' + key + '-table">';
        var startThead = '<thead id="sub-personFacultyGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personFacultyGraphDataSource-tbody">';
        $.each(result.personGroupFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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
        $('#personFacultyGraphDataSourceModal').modal('show');
        $('#personFacultyGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personFaculty-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionFacultyGraphDS(token, userName) {
    console.log('dsadasd')
    fetch(personnelRootPath + 'PersonnelPositionFaculty/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionFacultyGraphDS(data);
        });
}
async function RenderPersonPositionFacultyGraphDS(data) {
    $('#personPositionFacultyGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionFacultyGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personPositionFacultyGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">'
            + result.faculty + '</b></a>'
        var table = $('#sub-personPositionFaculty-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personPositionFacultyGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personPositionFacultyGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPositionFaculty" id="sub-personPositionFaculty-' + key + '-table">';
        var startThead = '<thead id="sub-personPositionFacultyGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionFacultyGraphDataSource-tbody">';
        $.each(result.personPositionFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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
        $('#personPositionFacultyGraphDataSourceModal').modal('show');
        $('#personPositionFacultyGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personPositionFaculty-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonRetiredGraphDS(token, userName) {

    var endDate = moment(moment().add(543, 'Y')).format('YYYY-MM-DD');
    var startDate = moment(moment(endDate).add(-10, 'Y')).endOf('year').format('YYYY-MM-DD');
    fetch(personnelRootPath + 'PersonnelGroupRetiredYear/DataSource?StartDate=' + startDate + '&EndDate=' + endDate+'&Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderRetiredGraphDS(data);
        });
}
async function RenderRetiredGraphDS(data) {
    $('#personRetiredGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personRetiredGraphDSCollapse' + key
            + '" role="button" aria-expanded="false" aria-controls="personRetiredGraphDSCollapse'
            + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">'
            + result.reitredYear + '</b></a>'
        var table = $('#sub-personRetired-' + key + '-table').DataTable();
        table.clear().destroy();

        $('#personRetiredGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personRetiredGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personRetired" id="sub-personRetired-' + key + '-table">';
        var startThead = '<thead id="sub-personRetiredGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';
        var endThead = '</thead>';
        var startBody = '<tbody id="sub-personRetiredGraphDataSource-tbody">';
        $.each(result.personGroupRetiredYear, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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

        $('#personRetiredGraphDataSourceModal').modal('show');
        $('#personRetiredGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personRetired-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonEducationGraphDS(token, userName) {
    fetch(personnelRootPath + 'PersonnelEducation/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonEducationGraphDS(data);
        });
}
async function RenderPersonEducationGraphDS(data) {
    $('#personEducationGraphDataSourceModal-card-body').empty();
    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personEducationGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personEducationDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.educationTypeName + '</b></a>'
        var table = $('#sub-personEducation-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personEducationGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personEducationGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personEducation" id="sub-personEducation-' + key + '-table">';
        var startThead = '<thead id="sub-personEducationGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personEducationGraphDataSource-tbody">';
        $.each(result.person, function (key, item) {
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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
        $('#personEducationGraphDataSourceModal').modal('show');
        $('#personEducationGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personEducation-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}


async function PersonTypeGraphDS(token, userName) {
    fetch(personnelRootPath + 'PersonnelPosition/DataSource?Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {
            RenderPersonTypeGraphDS(data);
        });
}
async function RenderPersonTypeGraphDS(data) {
    $('#personTypeGraphDataSourceModal-card-body').empty();

    $.each(data, function (key, result) {
        var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personTypeGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personTypeDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b class="th-text-green">' + result.personPositionTypeName + '</b></a>'
        var table = $('#sub-personType-' + key + '-table').DataTable();
        table.clear().destroy();
        $('#personTypeGraphDataSourceModal-card-body').append(link)
        var startRow = '<div class="collapse multi-collapse" id="personTypeGraphDSCollapse' + key + '">';
        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personType" id="sub-personType-' + key + '-table">';
        var startThead = '<thead id="sub-personTypeGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personTypeGraphDataSource-tbody">';
        $.each(result.person, function (key, item) {
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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
        $('#personTypeGraphDataSourceModal').modal('show');
        $('#personTypeGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#sub-personType-' + key + '-table').DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function LoadDataTable(name, key) {

    var dataTableName = '#sub-' + name + '-' + key + '-table';
    $(dataTableName).DataTable({
        language: oLanguagePersonGraphOptions,
        searching: false,
        pageLength: 5
    });
}
async function Load() {

    $('.dataTable-sub-allpersonal').DataTable({
        language: oLanguagePersonGraphOptions,
        searching: false,
        pageLength: 5
    });
}


//DrillDown
async function PersonGenerationDrillDown(generaTion, type) {

    var url = personnelRootPath + 'PersonnelPositionGeneration/DataSource?positionType=' + type + '&index=' + generaTion + '&Token=' + accessToken + '&api-version=1.0';
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonGenerationDrillDown(data).then();
        });
}

async function RenderPersonGenerationDrillDown(data) {
    $('#personnelPositionGenerationDrillDownGraphDataSourceModal-card-body').empty();
    $('#personnelPositionGenerationDrillDownGraphDataSourceLabel').empty()
    $('#personnelPositionGenerationDrillDownGraphDataSourceLabel').append("ประเภทบุคลากร")
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personnelPositionGenerationDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personnelPositionGenerationDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.persionPostionName + '</b></a>'
            $('#personnelPositionGenerationDrillDownGraphDataSourceModal-card-body').append(link)

        } else {
            $('#personnelPositionGenerationDrillDownGraphDataSourceLabel').empty()
            $('#personnelPositionGenerationDrillDownGraphDataSourceLabel').append(result.persionPostionName)
        }



        var startRow = '<div class="collapse multi-collapse" id="personnelPositionGenerationDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonnelPositionGenerationDrillDown' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personnelPositionGeneration" id="dataPersonnelPositionGenerationDrillDown' + key + '">';
        var startThead = '<thead id="sub-personnelPositionGenerationDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personnelPositionGenerationDrillDownGraphDataSource-tbody">';

        $.each(result.personPostionGeneration[0].person, function (key, item) {
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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


        $('#personnelPositionGenerationDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personnelPositionGenerationDrillDownGraphDataSourceModal').modal('show');
        $('#personnelPositionGenerationDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonnelPositionGenerationDrillDown' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });

    });

}

async function PersonGroupDrillDown(type) {
    var url = personnelRootPath + 'PersonnelGroup/DataSource?type=' + type + '&Token=' + accessToken + '&api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderAllPersonDrillDownGraphDS(data).then();
        });



}

async function RenderAllPersonDrillDownGraphDS(data) {

    $('#allpersonnelDrillDownGraphDataSourceModal-card-body').empty();
    $('#allPersoneDrillDownGraphDataSourceLabel').empty()
    $('#allPersoneDrillDownGraphDataSourceLabel').append("ประเภทบุคลากร")
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#allPersonDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="allPersonDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'
            $('#allpersonnelDrillDownGraphDataSourceModal-card-body').append(link)

        } else {
            $('#allPersoneDrillDownGraphDataSourceLabel').empty()
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
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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
            language: oLanguagePersonGraphOptions
        });

    });
}

async function PersonEducationDrillDown(type) {
    var url = personnelRootPath + 'PersonnelEducation/DataSource?type=' + type + '&Token=' + accessToken + '&api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonEducationDrillDownGraphDS(data).then();
        });



}

async function RenderPersonEducationDrillDownGraphDS(data) {
    $('#personEducationDrillDownGraphDataSourceModal-card-body').empty();
    $('#personEducationDrillDownGraphDataSourceLabel').empty()
    $('#personEducationDrillDownGraphDataSourceLabel').append("ระดับการศึกษา")
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personEducationDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personEducationDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.educationTypeName + '</b></a>'
            $('#personEducationDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personEducationDrillDownGraphDataSourceLabel').empty()
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
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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
            language: oLanguagePersonGraphOptions
        });

    });
}

async function PersonPositionDrillDown(type) {
    var url = personnelRootPath + 'PersonnelPosition/DataSource?type=' + type + '&Token=' + accessToken + '&api-version=1.0'
    console.log(url)
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionDrillDownGraphDS(data).then();
        });
}

async function RenderPersonPositionDrillDownGraphDS(data) {
    $('#personPositionDrillDownGraphDataSourceModal-card-body').empty();
    $('#personPositionDrillDownGraphDataSourceLabel').empty()
    $('#personPositionDrillDownGraphDataSourceLabel').append("ประเภทบุคลากร")
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personPositionTypeName + '</b></a>'

            $('#personPositionDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personPositionDrillDownGraphDataSourceLabel').empty()
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
            startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + item.citizenId + ')" class="text-green">' + item.personName + '</a></td><td>' + item.gender + '</td>' +
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
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionAdminDrillDown(adminPositionType, personnelType) {
    var url = personnelRootPath + 'PersonnelGroupAdminPosition/DataSource?adminPositionType=' + adminPositionType + '&personnelType=' + personnelType + '&Token=' + accessToken + '&api-version=1.0'

    console.log(url)
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionAdminDrillDownGraphDS(data).then();
        });


}


async function RenderPersonPositionAdminDrillDownGraphDS(data) {
    $('#personPositionAdminDrillDownGraphDataSourceModal-card-body').empty();
    $('#personPositionAdminDrillDownGraphDataSourceLabel').empty()
    $('#personPositionAdminDrillDownGraphDataSourceLabel').append("รายการตำแหน่งผู้บริหาร")
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionAdminDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionAdminDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.adminPositionType + '</b></a>'

            $('#personPositionAdminDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personPositionAdminDrillDownGraphDataSourceLabel').empty()
            $('#personPositionAdminDrillDownGraphDataSourceLabel').append(result.adminPositionType)
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
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionLevelDrillDown(personnelType, posotionLevel) {

    var url = personnelRootPath + 'PersonnelGroupPositionLevel/DataSource?personnelType=' + personnelType + '&positionLevel=' + posotionLevel + '&Token=' + accessToken + '&api-version=1.0'

    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionLevelDrillDownGraphDS(data).then();
        });


}

async function RenderPersonPositionLevelDrillDownGraphDS(data) {
    $('#personPositionLevelDrillDownGraphDataSourceModal-card-body').empty();
    $('#personPositionLevelDrillDownGraphDataSourceLabel').empty();
    $('#personPositionLevelDrillDownGraphDataSourceLabel').append("ประเภทบุคลากร")
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionLevelDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personPositionLevelDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'

            $('#personPositionLevelDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personPositionLevelDrillDownGraphDataSourceLabel').empty();
            $('#personPositionLevelDrillDownGraphDataSourceLabel').append(result.personGroupTypeName)
        }

        var startRow = '<div class="collapse multi-collapse" id="personPositionLevelDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonPositionLevelDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPositionLevel" id="dataPersonPositionLevelDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personPositionLevelDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionLevelGraphDataSource-tbody">';
        $.each(result.personGroupPosition, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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


        $('#personPositionLevelDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personPositionLevelDrillDownGraphDataSourceModal').modal('show');
        $('#personPositionLevelDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonPositionLevelDrillDownTable' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonGroupFacultyDrillDown(faculty, personnelType) {

    var url = personnelRootPath + 'PersonnelGroupFaculty/DataSource?faculty=' + faculty + '&personnelType=' + personnelType + '&Token=' + accessToken + '&api-version=1.0'

    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonGroupFacultyDrillDownGraphDS(data).then();
        });


}

async function RenderPersonGroupFacultyDrillDownGraphDS(data) {

    $('#personGroupFacultyDrillDownGraphDataSourceModal-card-body').empty();
    $('#personGroupFacultyDrillDownGraphDataSourceLabel').empty()
    $('#personGroupFacultyDrillDownGraphDataSourceLabel').append("หน่วยงาน/สังกัด")
    $.each(data, function (key, result) {
        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personGroupFacultyDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personGroupFacultyDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.faculty + '</b></a>'

            $('#personGroupFacultyDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personGroupFacultyDrillDownGraphDataSourceLabel').empty()
            $('#personGroupFacultyDrillDownGraphDataSourceLabel').append(result.faculty)
        }

        var startRow = '<div class="collapse multi-collapse" id="personGroupFacultyDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonGroupFacultyDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personGroupFaculty" id="dataPersonGroupFacultyDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personGroupFacultyDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personGroupFacultyGraphDataSource-tbody">';
        $.each(result.personGroupFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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


        $('#personGroupFacultyDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personGroupFacultyDrillDownGraphDataSourceModal').modal('show');
        $('#personGroupFacultyDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonGroupFacultyDrillDownTable' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonPositionFacultyDrillDown(faculty, personnelType, indexTable) {
    var url = personnelRootPath + 'PersonnelPositionFaculty/DataSource?faculty=' + faculty + '&position=' + personnelType + '&Token=' + accessToken + '&api-version=1.0'
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonPositionFacultyDrillDownGraphDS(data);
        });
}

async function RenderPersonPositionFacultyDrillDownGraphDS(data) {

    $('#personPositionFacultyDrillDownGraphDataSourceModal-card-body').empty();
    $('#personPositionFacultyDrillDownGraphDataSourceLabel').empty()
    $('#personPositionFacultyDrillDownGraphDataSourceLabel').append("หน่วยงาน/สังกัด")
    $.each(data, function (key, result) {

        if (data.length > 1) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personPositionFacultyDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="persoPositionFacultyDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.faculty + '</b></a>'

            $('#personPositionFacultyDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personPositionFacultyDrillDownGraphDataSourceLabel').empty()
            $('#personPositionFacultyDrillDownGraphDataSourceLabel').append(result.faculty)
        }

        var startRow = '<div class="collapse multi-collapse" id="personPositionFacultyDrillDownGraphDSCollapse' + key + '">';

        var table = $('#dataPersonPositionFacultyDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personPositionFaculty" id="dataPersonPositionFacultyDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personPositionFacultyDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personPositionFacultyGraphDataSource-tbody">';
        $.each(result.personPositionFaculty, function (key, item) {
            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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


        $('#personPositionFacultyDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personPositionFacultyDrillDownGraphDataSourceModal').modal('show');
        $('#personPositionFacultyDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonPositionFacultyDrillDownTable' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}


async function PersonRetiredDrillDown(retiredYear, personnelType, startDate, endDate) {
    var url = personnelRootPath + 'PersonnelGroupRetiredYear/DataSource?StartDate=' + startDate + '&EndDate=' + endDate
        + '&RetiredYear=' + retiredYear + '&PersonnelType=' + personnelType + '&Token=' + accessToken + '&api-version=1.0'

    fetch(url)
        .then(res => res.json())
        .then((data) => {
            RenderPersonRetiredDrillDownGraphDS(data).then();
        });


}

async function RenderPersonRetiredDrillDownGraphDS(data) {

    $('#personRetiredDrillDownGraphDataSourceModal-card-body').empty();
    $('#personRetiredDrillDownGraphDataSourceLabel').empty()
    $('#personRetiredDrillDownGraphDataSourceLabel').append("ปีที่เกษียณอายุ")
    $.each(data, function (key, result) {
        if (data.length > 1 && result.personGroupRetiredYear.length > 0) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personRetiredDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personRetiredDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.reitredYear + '</b></a>'

            $('#personRetiredDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personRetiredDrillDownGraphDataSourceLabel').empty()
            $('#personRetiredDrillDownGraphDataSourceLabel').append('ปี พ.ศ.' + result.reitredYear)
        }

        var startRow = '<div class="collapse multi-collapse" id="personRetiredDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonRetiredDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personRetired" id="dataPersonRetiredDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personRetiredDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-persoRetiredGraphDataSource-tbody">';
        $.each(result.personGroupRetiredYear, function (key, item) {

            $.each(item.person, function (index, sItem) {
                startBody += '<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + sItem.citizenId + ')" class="text-green">' + sItem.personName + '</a></td><td>' +
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


        $('#personRetiredDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personRetiredDrillDownGraphDataSourceModal').modal('show');
        $('#personRetiredDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonRetiredDrillDownTable' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}

async function PersonWorkDurationDrillDown(personnelType, index) {

    var url = personnelRootPath + 'PersonnelGroupWorkDuration/DataSource?personType=' + personnelType + '&index=' + index + '&Token=' + accessToken + '&api-version=1.0'
    console.log(url)
    fetch(url)
        .then(res => res.json())
        .then((data) => {
            console.log(data)
            RenderPersonWorkDurationDrillDownGraphDS(data).then();
        });


}
async function RenderPersonWorkDurationDrillDownGraphDS(data) {

    $('#personWorkDurationDrillDownGraphDataSourceModal-card-body').empty();
    $('#personWorkDurationDrillDownGraphDataSourceLabel').empty()
    $('#personWorkDurationDrillDownGraphDataSourceLabel').append("ประเภทบุคลากร")
    $.each(data, function (key, result) {
        if (data.length > 1 && result.personGroupWorkDuration.length > 0) {
            var link = '<a class="btn btn-default btn-bgwhite collapse-ds" data-toggle="collapse" href="#personWorkDurationDrillDownGraphDSCollapse' + key + '" role="button" aria-expanded="false" aria-controls="personWorkDurationDrillDownGraphDSCollapse' + key + '"><i class="fas fa-angle-double-down"></i> <b>' + result.personGroupTypeName + '</b></a>'

            $('#personWorkDurationDrillDownGraphDataSourceModal-card-body').append(link)
        } else {
            $('#personWorkDurationDrillDownGraphDataSourceLabel').empty()
            $('#personWorkDurationDrillDownGraphDataSourceLabel').append(result.personGroupTypeName)
        }

        var startRow = '<div class="collapse multi-collapse" id="personWorkDurationDrillDownGraphDSCollapse' + key + '">';
        var table = $('#dataPersonWorkDurationDrillDownTable' + key).DataTable();
        table.clear().destroy();

        var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-personRetired" id="dataPersonWorkDurationDrillDownTable' + key + '">';
        var startThead = '<thead id="sub-personWorkDurationDrillDownGraphDataSource-thead">';
        var thead = '<tr><th>ชื่อ-นามสกุล</th><th>เพศ</th><th>ตำแหน่ง</th><th>ประเภท</th><th>หน่วยงาน</th></tr>';

        var endThead = '</thead>';

        var startBody = '<tbody id="sub-personWorkDurationGraphDataSource-tbody">';
        $.each(result.personGroupWorkDuration, function (key, item) {
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


        $('#personWorkDurationDrillDownGraphDataSourceModal-card-body').append(html);

        $('#personWorkDurationDrillDownGraphDataSourceModal').modal('show');
        $('#personWorkDurationDrillDownGraphDataSourceModal').on('shown.bs.modal', function () {

        })

        $('#dataPersonWorkDurationDrillDownTable' + key).DataTable({
            language: oLanguagePersonGraphOptions
        });
    });
}


function RenderReseachMoney(researcheMoneyist) {
    var listName = '';
    console.log(researcheMoneyist)
    $.each(researcheMoneyist, function (key, value) {
        if (key > 0) {
            listName += '<br/>';
        }
        listName += (key + 1) + '.' + value.moneyTypeName;
    });

    //return listName;
    return listName
}

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

            var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/GetDataTablePersonRetired/' + clickedDatasetIndex + '/' + modelLabel + '?Token=' + accessToken + '&api-version=1.0'

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

    var url = 'https://localhost/MJU.DataCenter.Personnel/api/PersonnelRetired/GetDataTablePersonRetired/' + clickedDatasetIndex + '/' + modelLabel + '?Token=' + accessToken + '&api-version=1.0'

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
                language: oLanguagePersonGraphOptions
            });
        });
}

async function DisplayResearcherProfileModal(firstNameVal, lastNameVal) {

    var table = '#researchInfoTable';
    var modal = '#researchInfoModal';
    var section = '#researchInfoSection';
    var url = researchExtensionRootPath+'ResearcherResearchData/?firstName=' + firstNameVal + '&lastName=' + lastNameVal + '&Token=' + accessToken + '&api-version=1.0'

    var dataTable = $(table).DataTable();
    dataTable.clear().destroy();

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            $.each(data, function (key, value) {
                $(section).append('<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + value.citizenId + ')" class="text-green">' + value.researcherName + '</a></td><td>' +
                    value.departmentNameTh + '</td></tr > ')
            });

            $(modal).modal('show');
            $(modal).on('shown.bs.modal', function () {
            })
            $(table).DataTable({
                language: oLanguagePersonGraphOptions
            });
        });


}
async function DisplayPersonInfoDetailModal(citizenId) {

    var modal = '#personDetailModal';

    var urlResearch = researchExtensionRootPath + 'PersonnelResearchData/' + citizenId + '?&Token=' + accessToken + '&api-version=1.0'

    fetch(urlResearch)
        .then(res => res.json())
        .then((data) => {
            console.log(data)
            $('#personNameTh').empty();
            $('#personNameTh').append(data.researcherName);
          //  $('#personNameEn').empty();
          //  $('#personNameEn').append(data.researcherName);

            var table = $('#userDetailTable').DataTable();
            table.clear().destroy();
            var html = '<div class="col-md-12">';

            var startTable = '<table class="table table-striped table-valign-middle dataTable dataTable-sub-researchMoneyRangeDrillDown" id="userDetailTable">';

            var startThead = '<thead id="sub-researchMoneyRangeDrillDownDrillDownGraphDataSource-thead">';
            var thead = '<tr><th>รายชื่องานวิจัย</th><th>งบประมาณ</th><th>วันที่เริ่มทำวิจัย</th><th>วันที่สิ้นสุดงานวิจัย</th></tr>';

            var endThead = '</thead>';

            var startBody = '<tbody id="sub-researchMoneyRangeDrillDownGraphDataSource-tbody">';
            $.each(data.personResearchDetail, function (key, item) {
                console.log(item)
                startBody += '<tr><td><a href="#" class="text-green" onclick="DisplayResearchDetailModal(' + item.researchId + ')">' + item.researchNameEn + '</a></td>' +
                    //'<td>' + RenderReseacherName(item.personResearcher) + '</td>' +
                    //'<td>' + RenderReseachMoney(item.researchMoneyData) + '</td>' +
                    '<td>' + new Number(item.researchMoney).toLocaleString("th-TH") + '</td>' +
                    '<td>' + moment(item.researchStartDate).format('DD/MM/YYYY') + '</td>' +
                    '<td>' + moment(item.researchEndDate).format('DD/MM/YYYY') + '</td>' +
                    '</tr >';

            });
            var endbody = '</tbody>';

            var endTable = '</table></div></div>';

            html = startTable + startThead + thead + endThead + startBody + endbody + endTable;

            $('#research').empty();
            $('#research').append('<div class="row"><div class="col-md-4"><div class="info-box">' +
                '<span class="info-box-icon bg-green elevation-1" > <i class="fas fa-dollar-sign"></i></span>' +
                '<div class="info-box-content">' +
                '<span class="info-box-text chartCard">ผลรวมงบประมาณงานวิจัย</span>' +
                '<span class="info-box-number">' + new Number(data.summaryResearchMoney).toLocaleString("th-TH") +' บาท</span>' +
                '</div></div></div>')
            $('#research').append(html);

            $('#userDetailTable').DataTable({
                language: oLanguagePersonGraphOptions
            });


        });

    var urlPerson = personnelRootPath + 'PersonnelDetail/' + citizenId + '?Token=' + accessToken + '&api-version=1.0'
    fetch(urlPerson)
        .then(res => res.json())
        .then((data) => {
            if (data != null) {
                $('#personNameTh').empty();
                //$('#personNameEn').empty();
                $('#personPosition').empty();
                $('#personType').empty();
                $('#personSection').empty();
                $('#personDivision').empty();
                $('#personFaculty').empty();
                $('#personStartDate').empty();
                $('#personRetiredYear').empty();
                $('#personSalary').empty();
                $('#personAddress').empty();

                $('#personNameTh').append(data.personName);
               // $('#personNameEn').append(data.personName);
                $('#personPosition').append(data.position + '(' + data.positionLevel + ')');
                $('#personType').append(data.personnelType);
                $('#personSection').append(data.section);
                $('#personDivision').append(data.division);
                $('#personFaculty').append(data.faculty);
                $('#personStartDate').append(moment(data.startDate).format('DD/MM/YYYY'));
                $('#personRetiredYear').append(data.retiredYear);
                $('#personSalary').append(new Number(data.salary).toLocaleString("th-TH") + ' บาท');
                $('#personAddress').append(data.address + ' ' + data.zipCode);

                $('.educationGroup').empty();

                if (data.personEducation.length > 0) {
                    var educationGroupText = 'ไม่มีข้อมูล';
                    $.each(data.personEducation, function (key, item) {
                      
                        educationGroupText = '<strong><i class="fas fa-book mr-1"></i>' + item.educationLevel + '</strong>' +
                            '<div class="text-muted educationText">ปีที่จบ ' +moment(item.graduateDate).format('YYYY')+ '</div>' +
                            '<div class="text-muted educationText">' + data.titleEducation + '</div>' +
                            '<div class="text-muted educationText">' + data.education + '</div>' +
                            '<div class="text-muted educationText">' + data.major + '</div>' +
                            '<div class="text-muted educationText">' + data.university + '</div>'+
                            '<div class="text-muted educationText">ประเทศ ' + data.country + '</div>'
                            ;
                        $('.educationGroup').append(educationGroupText);
                    });
        
                }
                

                //$('#personEducationLevel').empty();
                //$('#personEducation').empty();
                //$('#personEducationCountry').empty();

                //$('#personEducationLevel').append(' ' + data.educationLevel);
                //$('#personEducation').append(data.education);
                //$('#personEducationCountry').append('ประเทศ' + data.country);




            }

        }).then(function () {

            $(modal).modal('show');
            $(modal).on('shown.bs.modal', function () {
            })
        });





}

async function DisplayPersonnelProfileModal(firstNameVal, lastNameVal) {

    var table = '#personInfoTable';
    var modal = '#personInfoModal';
    var section = '#personInfoSection';
    var url = personnelRootPath+'PersonnelDetail?FirstName=' + firstNameVal + '&lastName=' + lastNameVal + '&Token=' + accessToken + '&api-version=1.0'

    var dataTable = $(table).DataTable();
    dataTable.clear().destroy();

    fetch(url)
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            $.each(data, function (key, value) {
                $(section).append('<tr><td><a href="#" onclick="DisplayPersonInfoDetailModal(' + value.citizenId + ')" class="text-green">' + value.personName + '</a></td><td>' +
                    value.faculty + '</td></tr > ')
            });

            $(modal).modal('show');
            $(modal).on('shown.bs.modal', function () {
            })
            $(table).DataTable({
                language: oLanguagePersonGraphOptions
            });
        });


}