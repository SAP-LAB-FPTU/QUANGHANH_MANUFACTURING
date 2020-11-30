$(function () {
    $('.wizard .prev').click(function () {
        var wizard = $(this).parent('.wizard');

        $('.step.active', wizard).hide();

        var currentStep = $('.step.active', wizard);
        currentStep.hide();
        currentStep.removeClass('active');

        var newStep = currentStep.prev('.step', wizard);
        newStep.addClass('active');
        newStep.show();

        if ($('.step:first', wizard)[0] == newStep[0]) {
            $(this).hide();
        }

        $('.next', wizard).show();
    });

    $('.wizard .next').click(function () {
        var wizard = $(this).parent('.wizard');

        $('.step.active', wizard).hide();

        var currentStep = $('.step.active', wizard);
        currentStep.hide();
        currentStep.removeClass('active');

        var newStep = currentStep.next('.step', wizard);
        newStep.addClass('active');
        newStep.show();

        if ($('.step:last', wizard)[0] == newStep[0]) {
            $(this).hide();
        }

        $('.prev', wizard).show();
    });
});