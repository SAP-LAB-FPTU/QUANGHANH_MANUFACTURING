var isShow = true; // make sure first time advance search always hide

function displayAdvancesearch() {
    isShow = !isShow
    if (isShow) {
        $('#advanced-search-area').show();
    } else {
        $('#advanced-search-area').hide();
    }
}

function loadWindows() {
        if ($(window).width() <= 1050) {
            $("#searchButton").html('<i class="fas fas fa-search"></i>');
            $("#buttonAdvancedSearch").html('<i class="fas fa-angle-down"></i>');
            $("#searchArea").attr('placeholder', 'Mã nhân viên')
        } else {
            $("#searchButton").html('Tìm kiếm');
            $("#buttonAdvancedSearch").html('Tìm kiếm  nâng cao');
            $("#searchArea").attr('placeholder', 'Tìm kiếm theo mã nhân viên')
        }
}

loadWindows()
$(document).ready(function () {
    displayAdvancesearch();
    $(window).on('resize', function () {
        if ($(window).width() <= 1050) {
            $("#searchButton").html('<i class="fas fas fa-search"></i>');
            $("#buttonAdvancedSearch").html('<i class="fas fa-angle-down"></i>');
            $("#searchArea").attr('placeholder', 'Mã nhân viên')
        } else {
            $("#searchButton").html('Tìm kiếm');
            $("#buttonAdvancedSearch").html('Tìm kiếm  nâng cao');
            $("#searchArea").attr('placeholder', 'Tìm kiếm theo mã nhân viên')
        }
    });
    $("#buttonAdvancedSearch").on('click', () => {
        $("#advancedSearch").html("<div class='col m12'><div class='col m12'><div class='div-center custom-divider'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Mã Nhân Viên</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên nhân viên</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12'><div class='col m2'></div><div class='col m4'><label class='custom-label'>Tên phòng ban</label><input class='form-control' type='text' /></div><div class='col m4'><label class='custom-label'>Tên phân xưởng</label><input class='form-control' type='text' /></div><div class='col m2'></div></div><div class='input-field col m12 center'><button class='btn blue darken-1 btn-small'>Tìm kiếm</button></div></div>");
        $("#wrapper-advancedSearch").show();
        displayAdvancesearch();
    })
});