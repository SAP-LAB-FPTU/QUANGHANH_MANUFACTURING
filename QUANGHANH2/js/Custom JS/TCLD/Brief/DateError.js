$(document).ready(function () {

    $("#NgaySinhFix").val($("#NgaySinh").val())
    $("#save").click(function () {
        var temp = $("#NgaySinhFix").val();
        var arr = temp.split("/");
        $('#NgaySinh').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayThamGiaCachMangFix").val($("#NgayThamGiaCachMang").val())
    $("#save").click(function () {
        var temp = $("#NgayThamGiaCachMangFix").val();
        var arr = temp.split("/");
        $('#NgayThamGiaCachMang').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayThamGiaCachMangFix").val($("#NgayThamGiaCachMang").val())
    $("#save").click(function () {
        var temp = $("#NgayThamGiaCachMangFix").val();
        var arr = temp.split("/");
        $('#NgayThamGiaCachMang').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayVaoDangCSVNFix").val($("#NgayVaoDangCSVN").val())
    $("#save").click(function () {
        var temp = $("#NgayVaoDangCSVNFix").val();
        var arr = temp.split("/");
        $('#NgayVaoDangCSVN').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayChinhThucFix").val($("#NgayChinhThuc").val())
    $("#save").click(function () {
        var temp = $("#NgayChinhThucFix").val();
        var arr = temp.split("/");
        $('#NgayChinhThuc').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayVaoToChucCTXHFix").val($("#NgayVaoToChucCTXH").val())
    $("#save").click(function () {
        var temp = $("#NgayVaoToChucCTXHFix").val();
        var arr = temp.split("/");
        $('#NgayVaoToChucCTXH').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayVaoToChucCTXHFix").val($("#NgayVaoToChucCTXH").val())
    $("#save").click(function () {
        var temp = $("#NgayVaoToChucCTXHFix").val();
        var arr = temp.split("/");
        $('#NgayVaoToChucCTXH').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayNhapNguFix").val($("#NgayNhapNgu").val())
    $("#save").click(function () {
        var temp = $("#NgayNhapNguFix").val();
        var arr = temp.split("/");
        $('#NgayNhapNgu').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayXuatNguFix").val($("#NgayXuatNgu").val())
    $("#save").click(function () {
        var temp = $("#NgayXuatNguFix").val();
        var arr = temp.split("/");
        $('#NgayXuatNgu').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayXuatNguFix").val($("#NgayXuatNgu").val())
    $("#save").click(function () {
        var temp = $("#NgayXuatNguFix").val();
        var arr = temp.split("/");
        $('#NgayXuatNgu').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

    $("#NgayCapCMNDFix").val($("#NgayCapCMND").val())
    $("#save").click(function () {
        var temp = $("#NgayCapCMNDFix").val();
        var arr = temp.split("/");
        $('#NgayCapCMND').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });

});