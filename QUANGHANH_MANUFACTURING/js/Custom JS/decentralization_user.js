var user_roll
$(document).ready(function () {
    user_roll = $(".user_roll").attr("id");

    //TCLD chung menu
    if (user_roll == "vld-antoan") {
        $(".u-text > d4").html("Nguyễn Bá Vương")
        $(".u-text > p").html("vuong.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Bá Vương<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")
    }
    if (user_roll == "baocao-sanluon-laodong") {
        $(".u-text > d4").html("Nguyễn Văn Học")
        $(".u-text > p").html("hoc.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Văn Học<span class='new badge red' data-badge-caption='Phó phòng TCLĐ'></span></a>")
    }
    if (user_roll == "dieuchuyen") {
        $(".u-text > d4").html("Nguyễn Văn Long")
        $(".u-text > p").html("long.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Văn Long<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")
    }
    if (user_roll == "baohiem") {
        $(".u-text > d4").html("Nguyễn Thị Hòa")
        $(".u-text > p").html("hoa.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Thị Hòa<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")
    }
    if (user_roll == "nghiphep-baoholaodong") {
        $(".u-text > d4").html("Nguyễn Thị Trà")
        $(".u-text > p").html("tra.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Thị Trà<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")
    }

    //TCLD riêng
    //Chú học 

    //Điều khiển
    if (user_roll == "nguyenvanhochq234") {
        $(".u-text > d4").html("Nguyễn Văn Học")
        $(".u-text > p").html("hoc.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Văn Học<span class='new badge red' data-badge-caption='Phó Phòng TCLĐ'></span></a>")

        $("#hoso").hide();
        $("#chungchi").hide();
        $("#dieuchuyen").hide();
    } 
    if (user_roll == "nguyenvanlongsd223") {
        $(".u-text > d4").html("Nguyễn Văn Long")
        $(".u-text > p").html("long.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Văn Long<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")

        $("#hoso").hide();
        $("#chungchi").hide();
        $("#dashboard").hide();
        $("#nsldvatienluong").hide();
    } 
    if (user_roll == "nguyenbavuonglk523") {
        $(".u-text > d4").html("Nguyễn Bá Vương")
        $(".u-text > p").html("vuong.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Bá Vương<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")

        $("#hoso").hide();
        $("#dieuchuyen").hide();
        $("#dashboard").hide();
        $("#nsldvatienluong").hide();
    } 
    if (user_roll == "nguyenthihoart953") {
        $(".u-text > d4").html("Nguyễn Thị Hòa")
        $(".u-text > p").html("vuong.tcld@thanquanghanh.com.vn")

        $("#user-icon").html("<a href='javascript: void (0);'>Nguyễn Thị Hòa<span class='new badge red' data-badge-caption='Chuyên Viên TCLĐ'></span></a>")

        $("#chungchi").hide();
        $("#dieuchuyen").hide();
        $("#dashboard").hide();
        $("#nsldvatienluong").hide();
    } 
    //KCS

    //Phân-xưởng
});