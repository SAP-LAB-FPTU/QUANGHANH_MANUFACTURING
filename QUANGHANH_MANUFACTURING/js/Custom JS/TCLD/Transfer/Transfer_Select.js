var currentRow;
var col1;
var col2;
var col3;
var col4;
var x;

$(document).ready(function () {
    $("#myTable").on('click', '#buttonChon', function () {
        //visible the table with style well-md
        $("#table2").removeAttr("hidden", "hidden");

        //invisibile when the first loading, visible when user choose button "Chọn"
        var outlineTable = "<table id='myTable2' class='striped responsive-table table-bordered'><thead><tr><th class='center'>Mã nhân viên</th><th class='center'>Họ và tên</th><th class='center'>Phân xưởng hiện tại</th><th class='center'>Chức vụ hiện tại</th><th class='center'></th></tr></thead><tbody id='body-table-wrapper2'></tbody><tr id='buttonTienHanhDieuChuyen'></tr>";
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

        $("#body-table-wrapper2").append("<tr id='" + col1 + "'><td class='center'>" + col1 + "</td><td class='center'>" + col2 + "</td><td class='center'>" + col3 + "</td><td class='center'>" + col4 + "</td><td class='center'><button id='buttonBoChon' class='btn red darken-2' value='" + col1 + "'>Bỏ chọn</button></td></tr>");
        $("#buttonTienHanhDieuChuyen").html("<td class='center'></td><td class='center'></td><td class='center'></td><td class='center'></td><td class='center'><a id='tienhanhdieuchuyen' class='btn blue darken-2'>Tiến hành điều chuyển</a></td>");

        //remove row when click "Bỏ Chọn" and check if remove all then table will be invisible
        $("#myTable2").on('click', '#buttonBoChon', function () {
            //enabled button "Chọn" when click "Bỏ Chọn"
            $("." + $(this).val() + "").removeAttr("disabled");

            //remove the row clicked "Bỏ Chọn"
            x = $(this).closest("tr").find("td:eq(0)").text();
            $('#myTable2 > tbody > tr').remove('#' + x);

            //invisible table or button "Tiến hành điều chuyển" if remove all row
            var count = $('#myTable2 > #body-table-wrapper2 > tr').length;
            if (count == 0) {
                $("#buttonTienHanhDieuDong").html("");
                $("#table-wrapper2").html("");
                $("#table2").attr('hidden', 'hidden');
            }
        });

        //button TienHanhDieuChuyen
        $("#tienhanhdieuchuyen").on("click", function () {
            $("#chondieuchuyen").hide();
            $("#chondiadiemthoigiandieuchuyen").show();    
        });

        //button QuayLaiDieuChuyen
        $("#quaylaichondieuchuyen").on("click", function () {
            $("#chondieuchuyen").show();
            $("#chondiadiemthoigiandieuchuyen").hide(); 
        });
    });
});
