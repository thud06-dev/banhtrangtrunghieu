//$('#btnSaveData').click(function () {
//    var requestUrl = $(this).data('request-url');
//    var postData = {
//        BANNER_ID: $('#BANNER_ID').val(),
//        BANNER_NAME: $('#BANNER_NAME').val(),
//        BANNER_DESC: $('#BANNER_DESC').val(),
//        BANNER_FILE: $('#BANNER_FILE').val()
//    };
//    $.ajax({
//        type: "POST",
//        url: requestUrl,
//        data: JSON.stringify(postData),
//        contentType: 'application/json; charset=utf-8',
//        success: function (data) {
//            window.location = data;
//        },
//        error: function () {
//            return;
//        }
//    });
//    //function successFunc(data, status) {
//    //    alert(data);
//    //}

//    //function errorFunc() {
//    //    alert('error');
//    //}
//});
//$('#file-att').on('change', function () {
//    var files = this.files;
//    var requestUrl = $(this).data('request-url');
//    var data = new FormData();
//    if (files.length > 0) {
//        data.append("File", files[0]);
//    }
//    var reader = new FileReader();

//    reader.onload = function (e) {
//        $('#display_img')
//            .attr('src', e.target.result)
//            .width(150)
//            .height(200);
//    };

//    reader.readAsDataURL(this.files[0]);
//    $.ajax({
//        url: requestUrl,
//        type: "POST",
//        processData: false,
//        contentType: false,
//        data: data,
//        success: function (response) {
//            $('#BANNER_FILE').val(files[0].name);

//        },
//        error: function (er) {
//            alert(er);
//        }

//    });
//});

//function AjaxUpload(e) {
//    debugger;
//    var files = e.files;
//    var requestUrl = $('#file-att').data('request-url');
//    var data = new FormData();
//    if (files.length > 0) {
//        data.append("File", files[0]);
//    }
//    $.ajax({
//        url: requestUrl,
//        type: "POST",
//        processData: false,
//        contentType: false,
//        data: data,
//        success: function (response) {
//            $('#BANNER_FILE').val(files[0].name);
//        },
//        error: function (er) {
//            return;
//        }

//    });
//};
//$('#file-att').on('change', function() {
//    var files = this.files;
//    $('#BANNER_FILE').val(files[0].name);
//})