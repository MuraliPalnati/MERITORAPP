﻿$(document).ready(function () {
    var token = $('input[name="__RequestVerificationToken"]').val();
    var headers = {};
    headers['__RequestVerificationToken'] = token;
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
        meritor.ajaxCall('/Account/Login', 'POST', login, successFn, errorFn,headers);

        //meritor.ajaxCall('/Account/Teja', 'GET', null, successFn, errorFn);
    });
});