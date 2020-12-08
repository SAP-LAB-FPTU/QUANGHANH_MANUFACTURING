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
        $(".btnSelect").attr("disabled","disabled")
        $(".btnSelect1").attr("disabled","disabled")
        $("#buttonThem2").attr("disabled","disabled")
        $(".delete-view").attr("disabled","disabled")
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
        $(".btnSelect").removeAttr("disabled");
        $(".btnSelect1").removeAttr("disabled");
        $("#buttonThem2").removeAttr("disabled");
        $(".delete-view").removeAttr("disabled");
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
            option_family +
            ' </select> ' +
            ' </td> ' +
            ' <td id="col' + rowcount + '2"> ' +
            '    <input name="ngaySinhGiaDinh" data-auto-close="true" id="input' + rowcount + '2" type="text" autocomplete="off" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="dd/mm/yyyy" /> ' +
            ' </td> ' +
            ' <td id="col13" class="editable"><input id="input' + rowcount + '3" autocomplete="off" name="hoTen" style="border:none" /></td> ' +
            ' <td id="col' + rowcount + '4">' +
            ' <select class="custom-select" name="moiQuanHe"> ' +
            '    <option value="">Loại quan hệ</option> ' +
            option_relationship +
            ' </select> ' +
            '</td > ' +
            '<td id="col15" class="editable"><input id="input' + rowcount + '5" autocomplete="off" name="lyLich" style="border:none" /></td> ' +
            ' </tr >');
    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
});

var rowcount1 = 1;
$(document).ready(function () {
    $(".div_them").on('click', '#buttonThem1', function () {
        rowcount1++;
        //If there is no data then no row is added
        $("#table-htlv1").append('<tr><td id="col' + rowcount1 + '1 " class="editable"><input name="tenTruong" id="input' + rowcount1 + '1" style="border: none"/></td >' +
            '<td contenteditable="true" id="col' + rowcount1 + '2" class="editable"></td>' +
            '<td><div class="row"><div class="col l3"> <label class="custom-label">Từ:</label></div>' +
            '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
            '</div><div class="row" style="margin-top:5px">' +
            '<div class="col l3"> <label class="custom-label">Đến:</label></div>' +
            '<div class="col l9"><input id="ns" type="text" class="datepicker-here datepicker-add center form-control resize-form" data-language="vi" placeholder="mm/yyyy" data-min-view="months" data-view="months" data-date-format="MM yyyy" /></div>' +
            '</div></td>' +
            '<td contenteditable="true" id="col' + rowcount1 + '4" class="editable"></td>' +
            '<td contenteditable="true" id="col' + rowcount1 + '5" class="editable"></td></tr>"');
    });
});
//
var rowcount2 = 1;
$(document).ready(function () {
    $(".div_them2").on('click', '#buttonThem2', function () {
        rowcount2++;
        //If there is no data then no row is added
        $("#table-htlv2").append('<tr>' +
            '<td id = "col' + rowcount2 + '1" > <input id="input' + rowcount2 + '1" autocomplete="off" class="inputEdit" name="donVi" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '2"><input id="input' + rowcount2 + '2" autocomplete="off" class="inputEdit" name="chucDanh" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '3"><input id="input' + rowcount2 + '3" autocomplete="off" class="inputEdit" name="chucVu" style="border:none" /></td>' +
            '<td id="col' + rowcount2 + '4" class="editable"><input autocomplete="off" name="tuNgayDenNgay" id="input' + rowcount2 + '4" type="text" data-auto-close="true" data-range="true" placeholder="dd/mm/yyyy - dd/mm/yyyy" data-multiple-dates-separator=" - " data-language="vi" class="inputEdit datepicker-here form-control" style="border:none" /></td>' +
            '</tr> '
        );
    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
    $('.btnSelect1').click(function () {
        var data = document.getElementById("table-gd").rows.length;
        document.getElementById("table-gd").deleteRow(data - 1);
        rowcount--;
    });
    $('.btnSelect').click(function () {
        var data = document.getElementById("table-htlv2").rows.length;
        document.getElementById("table-htlv2").deleteRow(data - 1);
        rowcount--;
    });
});

