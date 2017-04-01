$(document).ready(function () {
    var meritor = new Meritor();
    $('#UserName').change(function () {
        var login = {
            UserName: $('#UserName').val(),
        };
        var successFn = function (data, response, xhr) {
            alert('successFn');
        };
        var errorFn = function (data, response, hhr) {
            alert('errorFn');
        };
        mer.ajaxCall('/Account/Login', 'POST', login, successFn, errorFn);

        //meritor.ajaxCall('/Account/Teja', 'GET', null, successFn, errorFn);
    });
});