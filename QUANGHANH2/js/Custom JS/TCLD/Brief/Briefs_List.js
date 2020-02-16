$(document).ready(function () {

    $("#wrapper-advancedSearch").hide();
    $("#normalSearch").on('click', '#buttonAdvancedSearch', function () {
        $(this).attr("id", "buttonedAdvancedSearch");
        $("#advancedSearch").html("<div class='col m12'><div class='col m12'><div class='div-center custom-divider'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Mã Nhân Viên</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên nhân viên</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Tên phòng ban</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên phân xưởng</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12 center'><button class='btn blue darken-1 btn-small'><i class='fas fas fa - search'></i></button></div></div>");
        $("#wrapper-advancedSearch").show();

        $("#normalSearch").on('click', '#buttonedAdvancedSearch', function () {
            $(this).attr("id", "buttonAdvancedSearch");
            $("#wrapper-advancedSearch").hide();
        });
    });

    $("#tlhd").change(() => function () {
        // $(".abc").show();
        alert("hehe")
    });
});


function onSelectTypeOfEndContract() {
    if (document.getElementById("tlhd").value == "Đi đơn vị ngoài") {
        $("#containerOption1").show();
        $("#containerOption2").hide();
    } else if (document.getElementById("tlhd").value == "Các trường hợp khác") {
        $("#containerOption2").show();
        $("#containerOption1").hide();
    } else {
        $("#containerOption1").hide();
        $("#containerOption2").hide();
    }
}

function onSelectTypeOfEndContract1(str) {
    if (document.getElementById("tlhd-" + str).value == "dvn") {
        $("#lydo-" + str).append("<div id='div1-" + str + "'><label> " +
            "  <input name='group1-" + str + "' type='radio' value='Đi các đơn vị trong TKV' checked /> " +
            "   <span>Đi các đơn vị trong TKV</span> " +
            "</label> " +
            "<label> " +
            "   <input name='group1-" + str + "' value='Đi các đơn vị ngoài TKV' type='radio' /> " +
            "    <span>Đi các đơn vị ngoài TKV</span> " +
            "</label></div>");
        $("#div2-" + str).hide();
    } else if (document.getElementById("tlhd-" + str).value == "khac") {
        $("#lydo-" + str).append("<div id='div2-" + str + "'><label> " +
            "  <input name='group2-" + str + "' id='else1-" + str + "' type='radio' value='Hết hạn HĐLĐ' checked /> " +
            "   <span>TLHĐ</span> " +
            "</label> " +
            "<label> " +
            "   <input name='group2-" + str + "' id='else2-" + str + "' value type='radio' /> " +
            "   <span><input id='else" + str + "' name='elseCase' class='form-control' placeholder='Trường hợp khác' required disabled autocomplete='off' /></span>" +
            "</label></div>");
        $("#div1-" + str).hide();
        if ($("#else1-" + str).is(":checked")) {
            $("tlhd-" + str).val($("#else1-" + str).val());
        }
        if ($("#else2-" + str).is(":checked")) {
            $("tlhd-" + str).val($("#else2-" + str).val());
        }
        $("#else2-" + str).click(function (event) {
            $("#else" + str).prop("disabled", false);
        });
        $("#else1-" + str).click(function (event) {
            $("#else" + str).prop("disabled", true);
        });
        $("#else" + str).change(function () {
            $("#else2-" + str).val($("#else" + str).val);
        });
    } else {
        $("#div1-" + str).hide();
        $("#div2-" + str).hide();
    }
}