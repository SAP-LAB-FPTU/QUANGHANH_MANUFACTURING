var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;
var flag = false;
$(document).ready(function () {
    if (!flag) {
        $("input.inputEdit").attr("disabled", "disabled");
        $("td.td-edit").attr("contenteditable", "false");
        $("select.sl-edit").attr("disabled", "disabled");
        $("input.select-dropdown.dropdown-trigger").remove();
        $("ul.dropdown-content.select-dropdown").remove();
        $("svg.caret").remove();

        $("select.custom-select").attr("disabled", "disabled");
        $("#buttonThem3").attr("disabled","disabled")
        $("#wrapper-advancedSearch").hide();
    }
});
function abc() {
    if (!flag) {
        $("input.inputEdit").removeAttr("disabled");
        $("td.td-edit").attr("contenteditable", "true");
        $("select.sl-edit").removeAttr("disabled");             
        $("select.custom-select").removeAttr("disabled");
        $("#buttonThem3").removeAttr("disabled");
        $("#pencil").remove();
        $("#pencilandsave").html("<a id='save' class='float modal-trigger' href='#updateBrief'><i class='material-icons my-float'>save</i></a>");
        flag = true;
    } else {
        $("input.inputEdit").attr("disabled", "disabled");
        $("td.td-edit").attr("contenteditable", "false");
        $("select.sl-edit").attr("disabled", "disabled");
        $("select.custom-select").attr("disabled", "disabled");
        $("#save").remove();
        $("#pencilandsave").html("<a id='pencil' class='float' href='#' onclick='abc()'><i class='material-icons my-float'>create</i></a>");
        flag = false;
    }
}
var rowcount = 1;
$(document).ready(function () {
    $(".div_them3").on('click', '#buttonThem3', function () {
        rowcount++;
        //If there is no data then no row is added
        $("#table-gd").append('<tr> ' +
            ' <td id = "col' + rowcount + '1" > ' +
            ' <select class="custom-select" name="giaDinh"> ' +
            '    <option value="">Loại gia đình</option> ' +
            '   <option value="Bản thân">Bản thân</option> ' +
            '  <option value="Nhà vợ">Nhà vợ</option> ' +
            '  <option value="Nhà chồng">Nhà chồng</option> ' +
            ' </select> ' +
            ' </td> ' +
            ' <td id="col' + rowcount + '2"> ' +
            '    <input name="ngaySinhGiaDinh" id="input' + rowcount + '2" type="text" autocomplete="off" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="dd/mm/yyyy" /> ' +
            ' </td> ' +
            ' <td id="col13" class="editable"><input id="input' + rowcount + '3" autocomplete="off" name="hoTen" style="border:none" /></td> ' +
            ' <td id="col14" class="editable"><input id="input' + rowcount + '4" autocomplete="off" name="moiQuanHe" style="border:none" /></td> ' +
            ' <td id="col15" class="editable"><input id="input' + rowcount + '5" autocomplete="off" name="lyLich" style="border:none" /></td> ' +
            ' </tr >');
    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
});

