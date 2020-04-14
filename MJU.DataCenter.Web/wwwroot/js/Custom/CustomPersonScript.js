
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
        var checkDatableLoaded = $('.dataTable-sub-' + chartName).hasClass("datableLoaded");
        if (checkDatableLoaded == false) {
            $('.dataTable-sub-' + chartName).DataTable({
                language: oLanguageOptions,
                searching: false,
                pageLength: 5
            });
            $('.dataTable-sub-' + chartName).addClass('datableLoaded');
        }
        $(modalTab).modal('show');
    });
}


async function DisplayPersonInfoDetailModal(citizenId) {

    var modal = '#personDetailModal';
    alert(citizenId);






    $(modal).modal('show');
    $(modal).on('shown.bs.modal', function () {
    })


    //fetch(url)
    //    .then((response) => {
    //        return response.json();
    //    })
    //    .then((data) => {

         
   
    //    });
}