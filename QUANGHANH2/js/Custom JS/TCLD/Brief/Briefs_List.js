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
    if (document.getElementById("tlhd-" + str).value == "khac") {
        if ($("#div2-" + str).length) {
            $("#div2-" + str).remove();
        }
        $("#lydo-" + str).append("<div id='div2-" + str + "'>" +
            "<input id='khac" + str + "' name='elseCase' class='form-control' placeholder='Trường hợp khác' required autocomplete='off' />" +
            "</div>");

    } else {
        $("#div2-" + str).remove();
    }
    
}
function onSelectTypeOfEndContract2() {
    if (document.getElementById("select-dept-for-all").value == "khac") {
        if ($("#divHeader").length) {
            $("#divHeader").remove();
        }
        $("#lydo-header").append("<div id='divHeader'>" +
            "<input id='khac-header' name='elseCase' class='form-control' placeholder='Trường hợp khác' required autocomplete='off' />" +
            "</div>");

    } else {
        $("#divHeader").remove();
    }

}