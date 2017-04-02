function Meritor() {

    this.ajaxCall = function (url, methodType, jsonData, successFn, errorFn,headers) {
        $.ajax({
            url: url,
            type: methodType,
            headers: headers,
            data: JSON.stringify(jsonData),
            contentType: 'application/json',
            success: successFn,
            error: errorFn,
            cache: false
        });
    };
}