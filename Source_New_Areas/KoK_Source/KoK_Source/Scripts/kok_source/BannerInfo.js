//$('#btnAdd').click(function () {
//    var requestUrl = $(this).data('request-url');
//    if ($('#myBanner').submit()) {
//        alert("a");
//    }
//});
function AjaxUpdateActive(thisme) {
    var val = 0;
    if ($(thisme).is(":checked")) {
        val = 1;
    }
    var postData = {
        id: $(thisme).attr('id'),
        active: val
    }
    var requestUrl = $('#UrlAjaxUpdateActive').data('request-url');
    $.ajax({
        url: requestUrl,
        type: "POST",
        data: JSON.stringify(postData),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
           
        },
        error: function (er) {
            return;
        }
    });
}
function AjaxRemoveBanner(thisme, id) {
    var postData = {
        id: id
    }
    var requestUrl = $('#UrlAjaxDeleteBanner').data('request-url');

    $.ajax({
        url: requestUrl,
        type: "POST",
        data: JSON.stringify(postData),
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            if (response.returnCode != 0) {
                $(thisme).closest('tr').prev().remove();
                $(thisme).closest('tr').remove();
            }
        },
        error: function (er) {
            return;
        }
    });
}