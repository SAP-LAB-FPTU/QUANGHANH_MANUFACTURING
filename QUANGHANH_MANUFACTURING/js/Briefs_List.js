$(document).ready(function () {
    $("#wrapper-advancedSearch").hide();
    $("#normalSearch").on('click', '#buttonAdvancedSearch', function () {
        $(this).attr("id", "buttonedAdvancedSearch");
        $("#advancedSearch").html("<div class='col m12'><div class='col m12'><div class='div-center custom-divider'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Mã Thiết bị</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên thiết bị</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Nhà cung cấp</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Vị trí hiện tại</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12 center'><button class='btn blue darken-1 btn-small'>Tìm kiếm</button></div></div>");
        $("#wrapper-advancedSearch").show();

        $("#normalSearch").on('click', '#buttonedAdvancedSearch', function () {
            $(this).attr("id", "buttonAdvancedSearch");
            $("#wrapper-advancedSearch").hide();
        });
    });
});