var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;

$(document).ready(function () {
    //
    $("#wrapper-advancedSearch").hide();

    $("#normalSearch").on('click', '#buttonAdvancedSearch', function () {
        $(this).attr("id", "buttonedAdvancedSearch");
        $("#advancedSearch").html("<div class='col m12'><div class='col m12'></div><div class='input-field col m12'><div class='col m4'><label class='custom-label'>Mã thiết bị</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên thiết bị</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Đơn vị sử dụng</label><select class='form-control'> <option>Phân xưởng cơ khí</option><option>Phân xưởng đào lò</option><option>Phân xưởng phục vụ</option><option>Phân xưởng khai thác</option> <option>Phân xưởng lộ thiên</option></select></div></div></div><div class='input-field col m12 center'><button class='btn blue darken-1 btn-small'>Tìm kiếm</button></div></div>");
        $("#wrapper-advancedSearch").show();

        $("#normalSearch").on('click', '#buttonedAdvancedSearch', function () {
            $(this).attr("id", "buttonAdvancedSearch");
            $("#wrapper-advancedSearch").hide();
        });
    });

    //
    $("#myTable").on('click', '#buttonChon', function () {
        //visible the table with style well-md
        $("#table2").removeAttr("hidden", "hidden");

        //invisibile when the first loading, visible when user choose button "Chọn"
        var outlineTable = "<table id='myTable2' class='stripped responsive-table'><thead><tr><th>Mã thiết bị</th><th>Tên thiết bị</th><th>Đơn vị sử dụng</th><th>Tình trạng thiết bị</th></tr></thead><tbody id='body-table-wrapper2'></tbody><tr id='buttonTienHanhDieuChuyen'></tr>";
        var count = $("#table-wrapper2 > table").length;
        if (count == 0) {
            $("#table-wrapper2").html(outlineTable);
        }

        //disabled buttton "Chọn" when it's clicked
        $(this).attr('disabled', 'disabled');

        //add row to below table when click button "Chọn"
        currentRow = $(this).closest("tr");

        col1 = currentRow.find("td:eq(1)").text();
        col2 = currentRow.find("td:eq(2)").text();
        col3 = currentRow.find("td:eq(3)").text();
        col4 = currentRow.find("td:eq(4)").text();

        $("#body-table-wrapper2").append("<tr id='" + col1 + "'><td>" + col1 + "</td><td>" + col2 + "</td><td>" + col3 + "</td><td>"+ col4 +"</td><td class='right'><button id='buttonBoChon' class='btn red darken-2' value='" + col1 + "'>Bỏ chọn</button></td></tr>");
        $("#buttonTienHanhDieuChuyen").html("<td></td><td></td><td></td><td></td><td class='right'><a href='/phong-cdvt/trung-dai-tu-chon' class='btn blue darken - 2'>Tiến hành trung đại tu</a></td>");

        //remove row when click "Bỏ Chọn" and check if remove all then table will be invisible
        $("#myTable2").on('click', '#buttonBoChon', function () {
            //enabled button "Chọn" when click "Bỏ Chọn"
            $("." + $(this).val() + "").removeAttr("disabled");

            //remove the row clicked "Bỏ Chọn"
            x = $(this).closest("tr").find("td:eq(0)").text();
            $('#myTable2 > tbody > tr').remove('#' + x);

            //invisible table or button "Tiến hành điều động" if remove all row
            var count = $('#myTable2 > #body-table-wrapper2 > tr').length;
            if (count == 0) {
                $("#buttonTienHanhDieuDong").html("");
                $("#table-wrapper2").html("");
                $("#table2").attr('hidden', 'hidden');
            }
        });
    });
});
