function Meritor() {
    this.ajaxCall = function (url, methodType, jsonData, successFn, errorFn) {
        var token = $('input[name="__RequestVerificationToken"]').val();
        var headers = {};
        headers['__RequestVerificationToken'] = token;
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
        this.showDialog = function (message) {
            $('#dialog-content').remove();
            var div = $("<section>", { id: "dialog-content" });;
            div.append(message);
        };
    };
}