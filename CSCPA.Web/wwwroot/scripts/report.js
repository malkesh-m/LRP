var reportList = {
    instance: function () {
        return $("#ReportList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#ReportList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#ReportList").dxDataGrid("instance");
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
                    let dataGrid = $("#ReportList").dxDataGrid("instance");
                    $.when(dataGrid.getDataSource().store().remove(e.row.data.ObjectUID)).done(function () {
                        dataGrid.refresh();
                    });
                }
            });
    },
    
}
$(function () {
    $("#ReportList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("ReportList");
})
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
                    reportList.refreshList();
                }
            });
        }
    },
    parameter: function () {
        let param;
        jQuery.ajax({
            type: 'POST',
            url: "/report/ParametersList/"+id,
            dataType: "json",
            success: function (data) {
                
                params = [];
                for (var i = 0; i < data.length; i++) {
                    reportName = data[i].ReportName;
                    if (data[i].ParameterType.toLowerCase() == "dropdown") {
                        var ddd = reportAddEdit.getLookup(data[i].TableName);
                        param = {
                            dataField: data[i].ParameterName,
                            editorType: dataType(data[i].ParameterType),
                            editorOptions: {
                                dataSource: ddd,
                                displayExpr: "Name",
                                valueExpr: "ObjectUid",
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
                            },
                            visible:true
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
                reportList.refreshList();
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
        jQuery.ajax({
            type: 'GET',
            url: "/" + e + "/Lookup1",
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
                reportList.refreshList();
            }
        });
        return resp;
    }
}
