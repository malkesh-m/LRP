var bdgreportList = {
    instance: function () {
        return $("#BdgreportList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#BdgreportList").dxDataGrid("instance").refresh();
    },
    onSectionChange: function (data) {

        let deleteButton = $("#Delete").dxButton("instance");
        deleteButton.option("disabled", !data.selectedRowsData.length);
    },
    onDeleteBtnClick: function () {
        event.preventDefault();
        swal({
            title: "Do you want to delete it?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            closeOnConfirm: true,
            closeOnCancel: true
        },
            function (isConfirm) {
                if (isConfirm) {
                    let dataGrid = $("#BdgreportList").dxDataGrid("instance");
                    $.when.apply($, dataGrid.getSelectedRowsData().map(function (data) {
                        return dataGrid.getDataSource().store().remove(data.ObjectUID);
                    })).done(function () {
                        dataGrid.refresh();
                    });
                }
            });

    },
    onRowRemoving: function (e) {
        event.preventDefault();
        swal({
            title: "Do you want to delete it?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            closeOnConfirm: true,
            closeOnCancel: true
        },
            function (isConfirm) {
                if (isConfirm) {
                    let dataGrid = $("#BdgreportList").dxDataGrid("instance");
                    $.when(dataGrid.getDataSource().store().remove(e.row.data.ObjectUID)).done(function () {
                        dataGrid.refresh();
                    });
                }
            });
    },
    toolbar_preparing: function (e) {
        var dataGrid = e.component;

        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "plus",
                onClick: function (e) {
                    bdgreportAddEdit.showModel(e, bdgreportList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    bdgreportList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#BdgreportList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("BdgreportList");
})
var bdgreportAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(bdgreportAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " Bdg Report")
        $model.modal("show");
        var url = "/Bdgreport/";
        if (e.row)
            url += "Edit/" + e.row.data.ObjectUID.toUpperCase();
        else
            url += "Add";
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
    },

    showParameterModel: function (e,state, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(bdgreportAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((state == "edit" ? "Edit" : "Add") + " Bdg Report Parameter")
        $model.modal("show");
        var url = "/BdgreportParameter/";
        if (state == "edit")
            url += "Edit/" + e.row.data.ObjectUID.toUpperCase();
        else
            url += "Add/" + e.row.data.ObjectUID.toUpperCase();
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
    },

    save: function () {

        var validationResult = $("#BdgreportAddEditDevForm").dxForm("instance").validate();
        var files = $("#fileUpload").dxFileUploader('instance').option('value');
        var data = common.dxFormData($("#BdgreportAddEditDevForm"));
        var url = "/Bdgreport/AddEdit";
        formData = new FormData();
        var reportfile = typeof ($("input[name=ReportFile]").val()) === 'undefined'  ? "" : $("input[name=ReportFile]").val();
        var name = typeof ($("input[name=Name]").val()) === 'undefined' ? "" : $("input[name=Name]").val();
        var descript = $("#Description").dxTextArea('instance').option('value');
        var description = typeof (descript) === 'undefined' ? "" : descript;
        formData.append('ObjectUID', data['ObjectUID']);
        formData.append('name', name);
        formData.append('reportFile', reportfile);
        formData.append('bdgcompanyId', $("#Bdgcompany").dxSelectBox('instance').option('value'));
        formData.append('sortOrder', $("input[name=SortOrder]").val());
        formData.append('showInCrystalViewer', $("input[name=ShowInCrystalViewer]").val());
        formData.append('portalId', $("#Portal").dxSelectBox('instance').option('value'));
        formData.append('description', description);
        formData.append("source", files[0]);
        if (validationResult.isValid) {

            jQuery.ajax({
                type: 'POST',
                url: url,
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {

                    common.showToast(data);
                    if (data.Status === "Success") {
                        $("#ModelAddEdit").modal("hide");
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    var error = errorThrown;
                    common.showErrorToast();
                },
                beforeSend: function () {
                    common.showLoader($("#BdgreportAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#BdgreportAddEditDevForm"));
                    bdgreportList.refreshList();
                }
            });
        }
    },

    saveParameter: function () {

        var validationResult = $("#BdgreportParameterAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/BdgreportParameter/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#BdgreportParameterAddEditDevForm")),
                success: function (data) {

                    common.showToast(data);
                    if (data.Status === "Success") {
                        $("#ModelAddEdit").modal("hide");
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    common.showErrorToast();
                },
                beforeSend: function () {
                    common.showLoader($("#BdgreportParameterAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#BdgreportParameterAddEditDevForm"));
                    bdgreportList.refreshList();
                }
            });
        }
    },
    RemoveParameter: function (e) {
        event.preventDefault();
        swal({
            title: "Do you want to delete it?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel",
            closeOnConfirm: true,
            closeOnCancel: true
        },
            function (isConfirm) {
                if (isConfirm) {
                    $.ajax({
                        url: "/BdgreportParameter/Delete?key=" + e.row.data.ObjectUID,
                        type: "DELETE",
                        dataType: "json",
                        success: function (data) {

                            common.showToast(data);
                            if (data.Status === "Success") {
                                $("#ModelAddEdit").modal("hide");
                            }
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            common.showErrorToast();
                        },
                        beforeSend: function () {
                            common.showLoader($("#BdgreportParameterAddEditDevForm"));
                        },
                        complete: function () {
                            common.hideLoader($("#BdgreportParameterAddEditDevForm"));
                            bdgreportList.refreshList();
                        }
                    });
                }
            });
    },
    refreshAddEdit: function () {
        $("#BdgreportParameterAddEditDevForm").dxForm("instance").refresh();
    },
    isDropdown: function (e) {
        
        var isSelect = $("#BdgreportParameterType").dxSelectBox('instance').option('text');
        var formInstance = $("#BdgreportParameterAddEditDevForm").dxForm("instance");
        if (isSelect.toLowerCase() == "dropdown") {
            formInstance.itemOption("Name", "visible", true);
            formInstance.itemOption("NameAlias", "visible", true);
            formInstance.itemOption("Display", "visible", true);
        }

        else {
            formInstance.itemOption("Name", "visible", false);
            formInstance.itemOption("NameAlias", "visible", false);
            formInstance.itemOption("Display", "visible", false);
        }
    },
    getLookupTable: function (e) {
        
        
        var resp;
        jQuery.ajax({
            type: 'GET',
            url: "/BdgreportParameter/LookupTable",
            dataType: "json",
            async: false,
            success: function (data) {
                resp = data;
                var formInstance = $("#BdgreportParameterAddEditDevForm").dxForm("instance");
                formInstance.itemOption("Name", "dataSource", data);
                //callback.call(resp);
            },
            error: function (xhr, textStatus, errorThrown) {
                var error = errorThrown;
                common.showErrorToast();
            },
            beforeSend: function () {
                common.showLoader($("#BdgreportParameterAddEditDevForm"));
            },
            complete: function () {
                common.hideLoader($("#BdgreportParameterAddEditDevForm"));
                bdgreportList.refreshList();
            }
        });
        //$("#BdgreportParameterType").dxSelectBox('instance').option('dataSource', resp);
        
       /* $("#TableName").dxSelectBox({
            dataSource: resp
        });*/
        //return resp;
    }
}
function dataType(type) {
    if (type.toLowerCase() == "string")
        return "dxTextBox";
    else if (type.toLowerCase() == "checkbox")
        return "dxCheckBox";
    else if (type.toLowerCase() == "date")
        return "dxCalendar";
    else if (type.toLowerCase() == "dropdown")
        return "dxSelectBox";
    else if (type.toLowerCase() == "radio")
        return "dxRadioGroup";
}
let id;
let params;
let reportName;
var reportAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(reportAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text("Report Parameters")
        $model.modal("show");
        id = e.row.data.ObjectUID.toUpperCase();
        var url = "/Report/Add/" + e.row.data.ObjectUID.toUpperCase();
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
    },

    save: function () {
        var validationResult = $("#reportAddEditDevForm").dxForm("instance").validate();
        var files = $("#fileUpload").dxFileUploader('instance').option('value');
        var data = common.dxFormData($("#reportAddEditDevForm"));
        var url = "/report/AddEdit";
        formData = new FormData();
        var reportfile = typeof ($("input[name=ReportFile]").val()) === 'undefined' ? "" : $("input[name=ReportFile]").val();
        var name = typeof ($("input[name=Name]").val()) === 'undefined' ? "" : $("input[name=Name]").val();
        var descript = $("#Description").dxTextArea('instance').option('value');
        var description = typeof (descript) === 'undefined' ? "" : descript;
        formData.append('ObjectUID', data['ObjectUID']);
        formData.append('name', name);
        formData.append('reportFile', reportfile);
        formData.append('bdgcompanyId', $("#Bdgcompany").dxSelectBox('instance').option('value'));
        formData.append('sortOrder', $("input[name=SortOrder]").val());
        formData.append('showInCrystalViewer', $("input[name=ShowInCrystalViewer]").val());
        formData.append('portalId', $("#Portal").dxSelectBox('instance').option('value'));
        formData.append('description', description);
        formData.append("source", files[0]);
        if (validationResult.isValid) {

            jQuery.ajax({
                type: 'POST',
                url: url,
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (data) {

                    common.showToast(data);
                    if (data.Status === "Success") {
                        $("#ModelAddEdit").modal("hide");
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    var error = errorThrown;
                    common.showErrorToast();
                },
                beforeSend: function () {
                    common.showLoader($("#reportAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#reportAddEditDevForm"));
                    bdgreportList.refreshList();
                }
            });
        }
    },
    parameter: function () {
        let param;
        jQuery.ajax({
            type: 'POST',
            url: "/report/ParametersList/" + id,
            dataType: "json",
            success: function (data) {
                
                params = [];
                for (var i = 0; i < data.length; i++) {
                    reportName = data[i].ReportName;
                    if (data[i].ParameterType.toLowerCase() == "dropdown") {
                        var dropValues = data[i].DropdownText.replace(" ", "").split(",");
                        var sourceData = reportAddEdit.getLookup("tableName=" + data[i].TableName + "&textName=" + dropValues[0] + "&valueName=" + dropValues[1]);
                        param = {
                            dataField: data[i].ParameterName,
                            editorType: dataType(data[i].ParameterType),
                            editorOptions: {
                                dataSource: sourceData,
                                displayExpr: "Text",
                                valueExpr: "Value",
                            }
                        }
                    }
                    else if (data[i].ParameterType.toLowerCase() == "radio") {
                        var radioValue = data[i].ParameterDefaultValue.split(",");
                        param = {
                            dataField: data[i].ParameterName,
                            editorType: dataType(data[i].ParameterType),
                            editorOptions: {
                                dataSource: radioValue,
                                value: radioValue[0],
                                layout: "horizontal"
                            },
                            visible: true
                        }
                    }
                    else {
                        param = {
                            dataField: data[i].ParameterName,
                            editorType: dataType(data[i].ParameterType),
                        }
                    }

                    params.push(param);

                }
                var form = $("#form").dxForm({
                    colCount: 2,
                    items: [
                        {
                            itemType: "group",
                            items: [

                                {
                                    itemType: "group",
                                    items: [{
                                        itemType: "group",
                                        name: "Parameters",
                                        items: params
                                    }]
                                }
                            ]
                        },
                    ]
                }).dxForm("instance");

            },
            error: function (xhr, textStatus, errorThrown) {
                var error = errorThrown;
                common.showErrorToast();
            },
            beforeSend: function () {
                common.showLoader($("#reportAddEditDevForm"));
            },
            complete: function () {
                common.hideLoader($("#reportAddEditDevForm"));
                bdgreportList.refreshList();
            }
        });
    },
    showReport: function (e, hideModelCallback) {
        let formData = "";
        for (var i = 0; i < params.length; i++) {
            if (i != 0)
                formData += "$"
            paramvalue = typeof ($("input[name=" + params[i].dataField + "]").val()) === 'undefined' ? "" : $("input[name=" + params[i].dataField + "]").val();
            formData += params[i].dataField + ":" + paramvalue;
        }
        var postData = { model: formData };

        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpVendorVoucherApplicabilityAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text(" LRP Vendor Voucher Applicability Report")
        $model.modal("show");



        var url = "/Report/ReportView?reportName=" + reportName + "&model=" + formData;
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });

    },
    getLookup: function (e) {
        
        var resp;
       // var url = "/" + e + "/Lookup1";
        var url = "/BdgreportParameter/ParameteData?"+e;
        jQuery.ajax({
            type: 'GET',
            url:url,
            dataType: "json",
            async: false,
            success: function (data) {
                resp = data;
                //callback.call(resp);
            },
            error: function (xhr, textStatus, errorThrown) {
                var error = errorThrown;
                common.showErrorToast();
            },
            beforeSend: function () {
                common.showLoader($("#reportAddEditDevForm"));
            },
            complete: function () {
                common.hideLoader($("#reportAddEditDevForm"));
                bdgreportList.refreshList();
            }
        });
        return resp;
    }
}

