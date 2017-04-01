function Meritor() {

    this.ajaxCall = function (url, methodType, jsonData, successFn, errorFn) {
        $.ajax({
            url: url,
            type: methodType,
            data: JSON.stringify(jsonData),
            contentType: 'application/json',
            success: successFn,
            error: errorFn,
            cache: false
        });
    };
}