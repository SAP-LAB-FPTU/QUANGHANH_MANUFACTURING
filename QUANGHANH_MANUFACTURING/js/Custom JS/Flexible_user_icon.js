$(window).resize(function () {
    if ($(window).width() <= 500) {
        $("#user-icon").hide();
    } else {
        $("#user-icon").show();
    }
});