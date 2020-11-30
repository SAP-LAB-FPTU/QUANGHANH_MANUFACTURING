var rowcount = 1;

$(document).ready(function () {
    $('#buttonRemove').click(function () {
        var data = document.getElementById("table-input-body").rows.length;
        document.getElementById("table-input-body").deleteRow(data - 1);
        rowcount--;
    });
    $(".div_them3").on('click', '#buttonAdd', function () {
        rowcount++;
        //If there is no data then no row is added
        $("#table-input-body").append('<tr>' +
            '<td> <input autocomplete="off" style="border:none" name="tieuChi" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="donViDo" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="thietDienDao" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="buocChong" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="CNKT" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="chong" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="chen" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="thucHien" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="keHoach" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="chenhLech" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="phanTramHT" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="luyKe" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="KHDC" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="phanTramTD" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="tong" /></td> ' +
            '<td> <input autocomplete="off" style="border:none" name="motNgay" /></td> ' +
            '<td> <input autocomplete="off" class="input-field" style="border:none" name="ghiChu" /></td> ' +
            '</tr>');

    });
    $(document).on("click", ".datepicker-here", function () {
        $(this).datepicker({
            language: 'vi'
        }).focus();
    });
});