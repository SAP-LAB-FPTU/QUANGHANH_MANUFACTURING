var flag = false;
$(document).ready(function () {
    if (!flag) {
        $("input.select-dropdown.dropdown-trigger").remove();
        $("ul.dropdown-content.select-dropdown").remove();
        $("svg.caret").remove();

        $("#wrapper-advancedSearch").hide();
    }

    $("#normalSearch").on('click','#buttonAdvancedSearch',function() {
        $(this).attr("id", "buttonedAdvancedSearch");
        $("#advancedSearch").html("<div class='col m12'><div class='col m12'><div class='div-center custom-divider'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Mã Nhân Viên</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên nhân viên</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Tên phòng ban</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên phân xưởng</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12 center'><button class='btn blue darken-1 btn-small'>Tìm kiếm</button></div></div>");
        $("#wrapper-advancedSearch").show();

        $("#normalSearch").on('click', '#buttonedAdvancedSearch',function () {
            $(this).attr("id", "buttonAdvancedSearch");
            $("#wrapper-advancedSearch").hide();
        });
    });

});
function abc() {
    if (!flag) {
        $("input.inputEdit").attr("disabled", "disabled");
        $("select.custom-select").attr("disabled", "disabled");
        $("#save").remove();
        $("#pencilandsave").html("<a id='pencil' class='a-float' href='#' onclick='abc()'><i class='material-icons my-float'>create</i></a>");
        flag = true;
    } else {
        $("input.inputEdit").removeAttr("disabled");
        $("select.custom-select").removeAttr("disabled");
        $("#pencil").remove();
        $("#pencilandsave").html("<a id='save' class='a-float modal-trigger' href='#updateBrief'><i class='material-icons my-float'>save</i></a>");
        flag = false;
    }
}