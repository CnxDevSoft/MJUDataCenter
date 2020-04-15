﻿const oLanguagePersonScriptOptions = {
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
                language: oLanguagePersonScriptOptions,
               // searching: false,
               // pageLength: 5
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