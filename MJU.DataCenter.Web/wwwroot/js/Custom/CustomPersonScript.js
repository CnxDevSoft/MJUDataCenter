
async function ToggleChart(chartName) {

    var canvasTab = '#' + chartName + '-canvas';
    var tableTab = '#' + chartName + '-table';
    var modalTab = '#allPersonGraphDataSourceModal';

    $("#switch-allpersonal-label-canvas").click(function () {
        $(tableTab).hide();
        $(canvasTab).show();
        //alert("1");
    });
    $("#switch-allpersonal-label-table").click(function () {
        $(canvasTab).hide();
        $(tableTab).show();
    });
    $("#allpersonal-datasource").click(function () {

        alert('1');
        $(modalTab).modal('show');
    });


}