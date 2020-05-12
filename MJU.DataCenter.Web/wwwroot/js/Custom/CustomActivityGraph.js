
async function FacultyActivityGraph() {

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
            var $chart = $('#facultyActivity-chart')

            var ctx = $($chart).get(0).getContext('2d')
            var gradientStroke = ctx.createLinearGradient(500, 0, 100, 0);
            gradientStroke.addColorStop(0, "#80b6f4");
            gradientStroke.addColorStop(0.2, "#94d973");
            gradientStroke.addColorStop(0.5, "#fad874");
            gradientStroke.addColorStop(1, "#f49080");

            $chart.height = 500;

            var labelData = ["คณะวิศวกรรม", "คณะวิทยาศาสตร์", "บริหารธุรกิจ", "พืชศาสตร์"];   
            var datasets = [
                //{
                //    backgroundColor: "rgba(165,96,1,0.8)",
                //    borderColor: "rgba(165,96,1,1)",
                //    data: [10, 7],
                //    label: ["ประเภทที่ 1"]
                //},
                //{
                //    backgroundColor: "rgba(165,96,229,0.8)",
                //    borderColor: "rgba(165,96,229,1)",
                //    data: [15, 3],
                //    label: ["ประเภทที่ 2"]
                //},

                 {
                    backgroundColor: ["rgba(165,96,229,0.8)", "rgba(165,96,1,0.8)"],
                    borderColor: "rgba(165,96,229,1)",
                    data: [15, 3, 1,33],
                },

            ];

            var chart = new Chart($chart, {
                type: 'horizontalBar',
                data: {
                    labels: labelData,
                    datasets: datasets,
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
                    legend: {
                        display: false
                    },
                    onClick: handleClick
                }
            })
            function handleClick(evt, item) {
                if (item.length > 0) {
                    var activeElement = chart.getElementAtEvent(evt);
                    FacultyActivityDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)

                    //console.log(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
                }
            }

            var sumColumns = [];
            var sumRows = [];
            var sumValue = 0;
            var labelColumns = [];

            //$("#personFacultyGraphDataTable-thead").append('<th class="th-text-green">ประเภทและบุคลากร</th>');
            //$.each(data.graphDataSet, function (key, item) {
            //    $("#personFacultyGraphDataTable-thead").append(
            //        '<th class="th-text-green">' + item.label + '</th>'
            //    );
            //    var sumColumn = 0;

            //    $.each(data.label, function (keys, item) {
            //        sumColumn += data.graphDataSet[key].data[keys];
            //    });
            //    sumColumns.push(sumColumn);
            //    labelColumns.push(item.label);
            //});

            //$("#personFacultyGraphDataTable-thead").append(
            //    '<th><strong class="th-text-green">รวม</strong></th>'
            //);

            //$.each(data.label, function (key, item) {
            //    var html = '';

            //    var sumRow = 0;
            //    $.each(data.graphDataSet, function (keys, sItem) {
            //        html += '<td><a class="text-green" href="#" onClick="PersonGroupFacultyDrillDown(' + "'" + item + "'," + "'" + data.graphDataSet[keys].label + "'" + ')">' + data.graphDataSet[keys].data[key] + '</a></td>';
            //        sumRow += data.graphDataSet[keys].data[key];
            //    });

            //    sumValue += sumRow;
            //    sumRows.push(sumRow);

            //    $("#personFacultyGraphDataTable-tbody").append(
            //        '<tr><td>' + item + '</td>' + html + '<td><a class="text-green" href="#" onClick="PersonGroupFacultyDrillDown(' + "'" + item + "'," + "'" + "'" + ')">' + sumRow + '</a></td></tr>');
            //});


            //var lastHtml;
            //$.each(sumColumns, function (key, item) {
            //    lastHtml += '<td><a class="text-green" href="#" onClick="PersonGroupFacultyDrillDown(' + "'" + "'" + ",'" + labelColumns[key] + "'" + ')">' + item + '</a></td>';

            //});
            //lastHtml += '<td><a class="text-green" href="#" onClick="PersonGroupFacultyDrillDown(' + "'" + "'," + "'" + "'" + ')">' + sumValue + '</a></td>';
            //$("#personFacultyGraphDataTable-tbody").append(
            //    '<tr><td><strong class="th-text-green">รวม</strong></td>' + lastHtml + '</tr>');

            //$('[data-toggle="tooltip"]').tooltip();
        });
}

async function PersonnelActivityGraph() {

    fetch(personnelRootPath + 'PersonnelGroupFaculty/1?' + 'Token=' + accessToken + '&api-version=1.0')
        .then(res => res.json())
        .then((data) => {

            var labelData = ["คณะวิศวกรรม", "คณะวิทยาศาสตร์", "บริหารธุรกิจ", "พืชศาสตร์"];
            var datasets = [
                {
                    backgroundColor: ['#9475E5', '#4BCADB', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
                    borderColor: ['#9475E5', '#4BCADB', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
                    data: [100, 300, 200, 150],
                },
            ];

            var canvas = $('#personnelActivity-chart')
            var $chart = canvas.get(0).getContext('2d')
            var donutData = {
                labels: labelData,
                datasets: datasets
            }
            var donutOptions = {
                maintainAspectRatio: false,
                responsive: true,
                onClick: function (evt, item) {
                    if (item.length > 0) {
                        PersonPositionFacultyDrillDown(data.graphDataSet[0].label, data.label[item[0]._index]);
                    }
                }
            }
            var myPieChart = new Chart($chart, {
                type: 'doughnut',
                data: donutData,
                options: donutOptions,

            });

            function handleClick(evt) {
                var activeElement = chart.getElementAtEvent(evt);
                PersonnelActivityDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
            }
            //var sumColumns = [];
            //var sumRows = [];
            //var sumValue = 0;
            //var labelColumns = [];
            //$("#personnelActivityGraphDataTable-thead").append('<th>ตำแหน่งทางวิชาการ</th>');
            //$.each(data.graphDataSet, function (key, item) {
            //    $("#personPositionFacultyGraphDataTable-thead").append(
            //        '<th>จำนวน</th>'
            //    );
            //    var sumColumn = 0;
            //    $.each(data.label, function (keys, item) {
            //        sumColumn += data.graphDataSet[key].data[keys];
            //    });
            //    sumColumns.push(sumColumn);
            //    labelColumns.push(item.label);
            //});
            //$.each(data.label, function (key, item) {
            //    var html = '';

            //    var sumRow = 0;
            //    $.each(data.graphDataSet, function (keys, sItem) {
            //        html += '<td><a class="text-green" href="#" onClick="PersonPositionFacultyDrillDown(' + "'" + data.graphDataSet[keys].label + "'," + "'" + item + "'" + ')">' + data.graphDataSet[keys].data[key] + '</a></td>';
            //        sumRow += data.graphDataSet[keys].data[key];
            //    });
            //    sumValue += sumRow;
            //    sumRows.push(sumRow);
            //    $("#personPositionFacultyGraphDataTable-tbody").append(
            //        '<tr><td>' + item + '</td>' + html + '</tr>');

            //});
            //var lastHtml;
            //$.each(sumColumns, function (key, item) {
            //    lastHtml += '<td><a class="text-green" href="#" onClick="PersonPositionFacultyDrillDown(' + "'" + labelColumns[key] + "'" + ",'" + '' + "'" + ')"><strong>' + item + '</strong></a></td>';
            //});
            //$("#personPositionFacultyGraphDataTable-tbody").append(
            //    '<tr><td><strong>รวม</strong></td>' + lastHtml + '</tr>');

            //$('[data-toggle="tooltip"]').tooltip();

        });

}