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
function AjaxRemove(thisme, id) {
    var postData = {
        id: id
    }
    var requestUrl = $('#UrlAjaxDelete').data('request-url');
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
function remove_unicode(str) {
    str = str.toLowerCase();
    str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
    str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
    str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
    str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
    str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
    str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
    str = str.replace(/đ/g, "d");
    str = str.replace(/!|@|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\;|\'| |\"|\&|\#|\[|\]|~|$|_/g, "-");

    str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1- 
    str = str.replace(/^\-+|\-+$/g, "");

    return str;
}