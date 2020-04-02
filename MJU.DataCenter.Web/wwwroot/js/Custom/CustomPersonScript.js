
async function ToggleChart(chartName) {
    
    var canvasTab = '#' + chartName + '-chart-canvas';
    var tableTab = '#' + chartName + '-chart-table';
    var modalTab = '#' + chartName + 'GraphDataSourceModal';
    var labelCanvasTab = '#switch-' + chartName + '-label-canvas';
    var labelTableTab = '#switch-' + chartName + '-label-table';
    var datasourceTab = '#' + chartName + '-datasource';

    $(labelCanvasTab).click(function () {
        $(tableTab).hide();
        $(canvasTab).show();
    });
    $(labelTableTab).click(function () {
        $(canvasTab).hide();
        $(tableTab).show();
    });
    $(datasourceTab).click(function () {
   
       // AllPersonGraphDS();
        $(modalTab).modal('show');
    });
}