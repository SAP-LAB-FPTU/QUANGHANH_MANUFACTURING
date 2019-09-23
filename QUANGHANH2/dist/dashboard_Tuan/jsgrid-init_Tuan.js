! function (document, window, $) {
    "use strict";
    var Site = window.Site;
    $(document).ready(function ($) {

    }), jsGrid.setDefaults({
        tableClass: "jsgrid-table table table-striped table-hover"
    }), jsGrid.setDefaults("text", {
        _createTextBox: function () {
            return $("<input>").attr("type", "text").attr("class", "")
        }
    }), jsGrid.setDefaults("number", {
        _createTextBox: function () {
            return $("<input>").attr("type", "number").attr("class", "")
        }
    }), jsGrid.setDefaults("textarea", {
        _createTextBox: function () {
            return $("<input>").attr("type", "textarea").attr("class", "materialize-textarea")
        }
    }), jsGrid.setDefaults("control", {
        _createGridButton: function (cls, tooltip, clickHandler) {
            var grid = this._grid;
            return $("<button>").addClass(this.buttonClass).addClass(cls).attr({
                type: "button",
                title: tooltip
            }).on("click", function (e) {
                clickHandler(grid, e)
            })
        }
    }), jsGrid.setDefaults("select", {
        _createSelect: function () {
            var $result = $("<select>").attr("class", ""),
                valueField = this.valueField,
                textField = this.textField,
                selectedIndex = this.selectedIndex;
            return $.each(this.items, function (index, item) {
                var value = valueField ? item[valueField] : index,
                    text = textField ? item[textField] : item,
                    $option = $("<option>").attr("value", value).text(text).appendTo($result);
                $option.prop("selected", selectedIndex === index)
            }), $result
        }
    }),
        //REPORT SỰ CỐ
        function () {
            $("#table_suco").jsGrid({
                height: "250px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.suCo,
                fields: [{
                    name: "STT",
                    type: "number",
                    width: 40
                }, {
                    name: "Sự cố",
                    type: "text",
                    width: 150
                }, {
                    name: "Đơn vị",
                    type: "text",
                    width: 70
                }, {
                    name: "Tình trạng",
                    type: "text",
                    width: 70
                },]
            })
        }(),
        //REPORT PHÂN XƯỞNG HOÀN THÀNH CÔNG VIỆC
        function () {
            $("#table_hoanthanh").jsGrid({
                height: "250px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.hoanthanh,
                fields: [{
                    name: "STT",
                    type: "number",
                    width: 40
                }, {
                    name: "Phân xưởng",
                    type: "text",
                    width: 150
                }, {
                    name: "Mét lò (m)",
                    type: "number",
                    width: 70
                }, {
                    name: "Sản lượng (Tấn)",
                    type: "number",
                    width: 70
                }]
            })
        }(),
        //REPORT PHÂN XƯỞNG KHÔNG HOÀN THÀNH CÔNG VIỆC
        function () {
            $("#table_khonghoanthanh").jsGrid({
                height: "250px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.khonghoanthanh,
                fields: [{
                    name: "STT",
                    type: "number",
                    width: 40
                }, {
                    name: "Phân xưởng",
                    type: "text",
                    width: 150
                }, {
                    name: "Mét lò (m)",
                    type: "number",
                    width: 70
                }, {
                    name: "Sản lượng (Tấn)",
                    type: "number",
                    width: 70
                }]
            })
        }(),
        //REPORT TIẾN ĐỘ THI CÔNG
        function () {
            $("#table_tiendothicong").jsGrid({
                height: "250px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.tiendothicong,
                fields: [{
                    name: "STT",
                    type: "number",
                    width: 40
                }, {
                    name: "Phân xưởng",
                    type: "text",
                    width: 150
                }, {
                    name: "Chi tiết",
                    type: "text",
                    width: 140
                }]
            })
        }(),

        function () {
            var MyDateField = function (config) {
                jsGrid.Field.call(this, config)
            };
            MyDateField.prototype = new jsGrid.Field({
                sorter: function (date1, date2) {
                    return new Date(date1) - new Date(date2)
                },
                itemTemplate: function (value) {
                    return new Date(value).toDateString()
                },
                insertTemplate: function () {
                    if (!this.inserting) return "";
                    var $result = this.insertControl = this._createTextBox();
                    return $result
                },
                editTemplate: function (value) {
                    if (!this.editing) return this.itemTemplate(value);
                    var $result = this.editControl = this._createTextBox();
                    return $result.val(value), $result
                },
                insertValue: function () {
                    return this.insertControl.datepicker("getDate")
                },
                editValue: function () {
                    return this.editControl.datepicker("getDate")
                },
                _createTextBox: function () {
                    return $("<input>").attr("type", "text").addClass("form-control input-sm").datepicker({
                        autoclose: !0
                    })
                }
            }), jsGrid.fields.myDateField = MyDateField, $("#exampleCustomGridField").jsGrid({
                height: "500px",
                width: "100%",
                inserting: !0,
                editing: !0,
                sorting: !0,
                paging: !0,
                data: db.users,
                fields: [{
                    name: "Account",
                    width: 150,
                    align: "center"
                }, {
                    name: "Name",
                    type: "text"
                }, {
                    name: "RegisterDate",
                    type: "myDateField",
                    width: 100,
                    align: "center"
                }, {
                    type: "control",
                    editButton: !1,
                    modeSwitchButton: !1
                }]
            })
        }()
}(document, window, jQuery);