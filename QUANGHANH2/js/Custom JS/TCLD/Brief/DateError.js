$(document).ready(function () {
    var arr = $("#NgaySinh").val().split("/")
    if ($("#NgaySinh").val() != null && $("#NgaySinh").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgaySinhFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])

    }
    $("#save").click(function () {
        var temp = $("#NgaySinhFix").val();
        var arr = temp.split("/");
        $('#NgaySinh').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayThamGiaCachMang").val().split("/")
    if ($("#NgayThamGiaCachMang").val() != null && $("#NgayThamGiaCachMang").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayThamGiaCachMangFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])

    }
    $("#save").click(function () {
        var temp = $("#NgayThamGiaCachMangFix").val();
        var arr = temp.split("/");
        $('#NgayThamGiaCachMang').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayVaoDangCSVN").val().split("/")
    if ($("#NgayVaoDangCSVN").val() != null && $("#NgayVaoDangCSVN").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayVaoDangCSVNFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayVaoDangCSVNFix").val();
        var arr = temp.split("/");
        $('#NgayVaoDangCSVN').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayChinhThuc").val().split("/")
    if ($("#NgayChinhThuc").val() != null && $("#NgayChinhThuc").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayChinhThucFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayChinhThucFix").val();
        var arr = temp.split("/");
        $('#NgayChinhThuc').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayVaoToChucCTXH").val().split("/")
    if ($("#NgayVaoToChucCTXH").val() != null && $("#NgayVaoToChucCTXH").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayVaoToChucCTXHFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayVaoToChucCTXHFix").val();
        var arr = temp.split("/");
        $('#NgayVaoToChucCTXH').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});

$(document).ready(function () {
    var arr = $("#NgayNhapNgu").val().split("/")
    if ($("#NgayNhapNgu").val() != null && $("#NgayNhapNgu").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayNhapNguFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayNhapNguFix").val();
        var arr = temp.split("/");
        $('#NgayNhapNgu').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayXuatNgu").val().split("/")
    if ($("#NgayXuatNgu").val() != null && $("#NgayXuatNgu").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayXuatNguFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayXuatNguFix").val();
        var arr = temp.split("/");
        $('#NgayXuatNgu').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});

$(document).ready(function () {
    var arr = $("#NgayCapCMND").val().split("/")
    if ($("#NgayCapCMND").val() != null && $("#NgayCapCMND").val() != "") {

        var arr1 = arr[2].split(" ")
        $("#NgayCapCMNDFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayCapCMNDFix").val();
        var arr = temp.split("/");
        $('#NgayCapCMND').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});


$(document).ready(function () {
    var arr = $("#NgayDiLam").val().split("/")
    if ($("#NgayDiLam").val() != null && $("#NgayDiLam").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayDiLamFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayDiLamFix").val();
        var arr = temp.split("/");
        $('#NgayDiLam').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#NgayTuyenDungTruoc").val().split("/")
    if ($("#NgayTuyenDungTruoc").val() != null && $("#NgayTuyenDungTruoc").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayTuyenDungTruocFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayTuyenDungTruocFix").val();
        var arr = temp.split("/");
        $('#NgayTuyenDungTruoc').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});

