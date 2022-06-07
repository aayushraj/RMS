﻿$(document).ready(function () {
    $('table').DataTable();
    $('select').select2();
    

});

var dynamicFn = function (htmlId1, htmlId2, htmlId3, url) {
    $(htmlId1).hide();
    $(htmlId2).hide();
    $(htmlId3).show();


    $.ajax({
        url: url,
        data: $('#form').serialize(),
        method: "post",
        success: function (data) {
            console.log("sucess");
            $('#LastPaid').show();
            $('#LoadingImage').hide();
            $('#LastPaid').html(data);

        },

        error: function () {
            console.log("Error");
        }


    })
}

var toastrOptions = function () {
    toastr.options = {
        "closeButton": true,
        "progressBar": true,
        "preventDuplicates": true,
        "showDuration": "100",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "show",
        "hideMethod": "hide",
        "positionClass": "toast-top-right"
    };
}
//this is success toast

var toastSuccess = function (msg) {
    toastrOptions();
    toastr.success(msg)
}

var toasterror = function (statusCode) {
    toastrOptions();
    var msg = "";
    switch (statusCode) {
        case 500:
            msg = "Internal Server Error"
            break;
        default: break;
    }
    toastr.error(msg);

}


