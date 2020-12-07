$(document).ready(function () {
    var arr = $("#BASIC_INFO_date_of_birth").val().split("/")
    if ($("#BASIC_INFO_date_of_birth").val() != null && $("#BASIC_INFO_date_of_birth").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgaySinhFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])

    }
    $("#save").click(function () {
        var temp = $("#NgaySinhFix").val();
        var arr = temp.split("/");
        $('#BASIC_INFO_date_of_birth').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#PARTY_day_on_VCP").val().split("/")
    if ($("#PARTY_day_on_VCP").val() != null && $("#PARTY_day_on_VCP").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayVaoDangCSVNFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayVaoDangCSVNFix").val();
        var arr = temp.split("/");
        $('#PARTY_day_on_VCP').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#PARTY_official_date").val().split("/")
    if ($("#PARTY_official_date").val() != null && $("#PARTY_official_date").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayChinhThucFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayChinhThucFix").val();
        var arr = temp.split("/");
        $('#PARTY_official_date').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#PARTY_date_of_joining_political_social_organization").val().split("/")
    if ($("#PARTY_date_of_joining_political_social_organization").val() != null && $("#PARTY_date_of_joining_political_social_organization").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayVaoToChucCTXHFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayVaoToChucCTXHFix").val();
        var arr = temp.split("/");
        $('#PARTY_date_of_joining_political_social_organization').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});

$(document).ready(function () {
    var arr = $("#PARTY_date_of_enlistment").val().split("/")
    if ($("#PARTY_date_of_enlistment").val() != null && $("#PARTY_date_of_enlistment").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayNhapNguFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayNhapNguFix").val();
        var arr = temp.split("/");
        $('#PARTY_date_of_enlistment').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});
$(document).ready(function () {
    var arr = $("#PARTY_date_of_discharge").val().split("/")
    if ($("#PARTY_date_of_discharge").val() != null && $("#PARTY_date_of_discharge").val() != "") {
        var arr1 = arr[2].split(" ")
        $("#NgayXuatNguFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayXuatNguFix").val();
        var arr = temp.split("/");
        $('#PARTY_date_of_discharge').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});

$(document).ready(function () {
    var arr = $("#BASIC_INFO_date_of_issuance_of_identity_card").val().split("/")
    if ($("#BASIC_INFO_date_of_issuance_of_identity_card").val() != null && $("#BASIC_INFO_date_of_issuance_of_identity_card").val() != "") {

        var arr1 = arr[2].split(" ")
        $("#NgayCapCMNDFix").val(arr[1] + "/" + arr[0] + "/" + arr1[0])
    }
    $("#save").click(function () {
        var temp = $("#NgayCapCMNDFix").val();
        var arr = temp.split("/");
        $('#BASIC_INFO_date_of_issuance_of_identity_card').val(arr[1] + "/" + arr[0] + "/" + arr[2])
    });
});



