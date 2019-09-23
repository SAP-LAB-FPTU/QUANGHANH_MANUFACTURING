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

    $("#tlhd").change( () => function () {
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
    }
}