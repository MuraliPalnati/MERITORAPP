$(document).ready(function () {
    var meritor = new Meritor();
    $('#Password').attr('disabled', 'disabled');

    $('#UserName').change(function () {
        var login = {
            UserName: $('#UserName').val(),
        };
        var successFn = function (data, response, xhr) {
            if (data.toLowerCase() == 'true') {
                $('#Password').removeAttr('disabled');
                meritor.showDialog('Valid User');
            }
            else {
                $('#Password').attr('disabled', 'disabled');
                $('#Password').val('');
                $('#ErrorMessage').val("InValid User");
            }
        };
        var errorFn = function (data, response, hhr) {
            alert('errorFn');
        };
        meritor.ajaxCall('/Account/IsValidUser', 'POST', login, successFn, errorFn);
        //meritor.ajaxCall('/Account/Teja', 'GET', null, successFn, errorFn);
    });


    $('#teja').click(function () {
        alert('Hi');
        var login = {
            UserName: $('#UserName').val(),
        };
        var successFn = function (data, response, xhr) {
            alert('errorFn');
        };
        var errorFn = function (data, response, hhr) {
            alert('errorFn');
        };
        meritor.ajaxCall('/Teja/Kanu', 'POST', login, successFn, errorFn);
    });
});