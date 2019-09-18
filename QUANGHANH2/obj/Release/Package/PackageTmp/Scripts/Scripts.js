function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $('#table-wrapper2').html(response);
                alert("Stupid");
                //refreshAddNewTab($(form).attr('data-restUrl'), true);
                //if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                //    activatejQueryTable();
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);

    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            //$("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
            //$('ul.nav.nav-tabs a:eq(1)').html('Edit');
            //$('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $(".modal-body").html(response);
            //$('input#save-edit-button').attr("value", "Cập nhật");
            if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                activatejQueryTable();
        }
    });
}

function Delete(url) {
    $.ajax({
        type: 'POST',
        url: url,
        success: function (response) {
            $('#table-wrapper2').html(response);
            if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                activatejQueryTable();
        }

    });
}