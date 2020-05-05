
async function PersonPositionFacultySubGraph($chart, data, token, userName) {
    debugger;
    var $chart = $chart.get(0).getContext('2d')
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
                PersonPositionFacultyDrillDown(data.graphDataSet[0].label, data.label[item[0]._index]);
            }
        }
    }
    var chart = new Chart($chart, {
        type: 'doughnut',
        data: donutData,
        options: donutOptions
    });

    function handleClick(evt) {
        var activeElement = chart.getElementAtEvent(evt);
        PersonPositionFacultyDrillDown(data.label[activeElement[0]._index], data.graphDataSet[activeElement[0]._datasetIndex].label)
    }
    var sumColumns = [];
    var sumRows = [];
    var sumValue = 0;
    var labelColumns = [];
    $("#personPositionFacultyGraphDataTable-thead").append('<th>ตำแหน่งทางวิชาการ</th>');
    $.each(data.graphDataSet, function (key, item) {
        $("#personPositionFacultyGraphDataTable-thead").append(
            '<th>จำนวน</th>'
        );
        var sumColumn = 0;
        $.each(data.label, function (keys, item) {
            sumColumn += data.graphDataSet[key].data[keys];
        });
        sumColumns.push(sumColumn);
        labelColumns.push(item.label);
    });
    $.each(data.label, function (key, item) {
        var html = '';

        var sumRow = 0;
        $.each(data.graphDataSet, function (keys, sItem) {
            html += '<td><a class="text-green" href="#" onClick="PersonPositionFacultyDrillDown(' + "'" + data.graphDataSet[keys].label + "'," + "'" + item + "'" + ')">' + data.graphDataSet[keys].data[key] + '</a></td>';
            sumRow += data.graphDataSet[keys].data[key];
        });
        sumValue += sumRow;
        sumRows.push(sumRow);
        $("#personPositionFacultyGraphDataTable-tbody").append(
            '<tr><td>' + item + '</td>' + html + '</tr>');

    });
    var lastHtml;
    $.each(sumColumns, function (key, item) {
        lastHtml += '<td><a class="text-green" href="#" onClick="PersonPositionFacultyDrillDown(' + "'" + labelColumns[key] + "'" + ",'" + '' + "'" + ')"><strong>' + item + '</strong></a></td>';
    });
    $("#personPositionFacultyGraphDataTable-tbody").append(
        '<tr><td><strong>รวม</strong></td>' + lastHtml + '</tr>');

    $('[data-toggle="tooltip"]').tooltip();
}