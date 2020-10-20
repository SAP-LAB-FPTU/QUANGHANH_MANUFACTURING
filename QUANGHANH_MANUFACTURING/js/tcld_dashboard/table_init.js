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
            $("#table_nghidai").jsGrid({
                height: "300px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.nghidai,
                fields: [{
                    name: "STT",
                    type: "number",
                    width: 40
                }, {
                    name: "Họ và tên",
                    type: "text",
                    width: 150
                }, {
                    name: "Số thẻ",
                    type: "text",
                    width: 70
                }, {
                    name: "Từ ngày",
                    type: "text",
                    width: 70
                },]
            })
        }(),
        function () {
            $("#table_sanluong").jsGrid({
                height: "300px",
                width: "100%",
                sorting: !0,
                paging: !0,
                data: db.sanluong,
                fields: [{
                    name: "STT",
                    type: "text",
                    width: 40
                }, {
                    name: "Danh mục",
                    type: "text",
                    width: 150
                }, {
                    name: "DVT",
                    type: "text",
                    width: 70
                }, {
                    name: "Thực hiện",
                    type: "number",
                    width: 70
                }, {
                    name: "Chênh lệch",
                    type: "number",
                    width: 70
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