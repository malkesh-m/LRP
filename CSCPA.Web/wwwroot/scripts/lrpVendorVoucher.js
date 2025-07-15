var lrpVendorVoucherList = {
    instance: function () {
        return $("#LRPVendorVoucherList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPVendorVoucherList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#LRPVendorVoucherList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPVendorVoucherList").dxDataGrid("instance");
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
                    lrpVendorVoucherAddEdit.showModel(e, lrpVendorVoucherList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpVendorVoucherList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#LRPVendorVoucherList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("VendorVoucherList");
})

var lrpVendorVoucherAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpVendorVoucherAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " LRP Vendor voucher")
        $model.modal("show");
        var url = "/LRPVendorVoucher/";
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

    save: function () {

        var validationResult = $("#LRPVendorVoucherAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            var data = common.dxFormData($("#LRPVendorVoucherAddEditDevForm"));
            data['InvoiceDate'] = common.convertDateToDbFormat(data['InvoiceDate']);
            data['Pstgdate'] = common.convertDateToDbFormat(data['Pstgdate']);
            $.ajax({
                url: "/LRPVendorVoucher/AddEdit",
                type: "POST",
                dataType: "json",
                data: data,
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
                    common.showLoader($("#LRPVendorVoucherAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPVendorVoucherAddEditDevForm"));
                    lrpVendorVoucherList.refreshList();
                }
            });
        }
    }
}

var lrpVendorVoucherApplicabilityAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
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
        $('.modal-title').text((e.row ? "Edit" : "Add") + " LRP Vendor Voucher Applicability")
        $model.modal("show");
        var url = "/LRPVendorVoucherApplicability/";
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
    showModelParameter: function (e, hideModelCallback) {
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
        $('.modal-title').text("LRP Vendor Voucher Applicability Report")
        $model.modal("show");
        var url = "/LRPVendorVoucherApplicability/";
        if (!e.row)
            url += "ReportParameter";
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
    },

    save: function () {

        var validationResult = $("#LRPVendorVoucherApplicabilityAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            var data = common.dxFormData($("#LRPVendorVoucherApplicabilityAddEditDevForm"));
            data['DocumentDate'] = common.convertDateToDbFormat(data['DocumentDate']);
            $.ajax({
                url: "/LRPVendorVoucherApplicability/AddEdit",
                type: "POST",
                dataType: "json",
                data: data,
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
                    common.showLoader($("#LRPVendorVoucherApplicabilityAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPVendorVoucherApplicabilityAddEditDevForm"));
                    lrpVendorVoucherApplicabilityList.refreshList();
                }
            });
        }
    },

    /*    reprotParameter: function () {
            var param1 = $('#lrpDocumentType').dxSelectBox("instance").option('value');
            var param2 = $('#lrpVendorVoucher').dxSelectBox("instance").option('value');
            window.location.href = "/LRPVendorVoucherApplicability/Report?Parameter1=" + param1 + "&Parameter2=" + param2;
    
        }*/
    reprotParameter: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpVendorVoucherApplicabilityAddEdit.hideModelCallbackData);
                return;
            }
        });
        var param1 = $('#lrpDocumentType').dxSelectBox("instance").option('value');
        var param2 = $('#lrpVendorVoucher').dxSelectBox("instance").option('value');
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text(" LRP Vendor Voucher Applicability Report")
        $model.modal("show");
        var url = "/LRPVendorVoucherApplicability/Report?Parameter1=" + param1 + "&Parameter2=" + param2;
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
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
                        url: "/LRPVendorVoucherApplicability/Delete?key=" + e.row.data.ObjectUID,
                        type: "DELETE",
                        dataType: "json",
                        success: function (data) {

                            common.showToast(data);
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            common.showErrorToast();
                        },
                        beforeSend: function () {
                        },
                        complete: function () {
                            lrpVendorVoucherList.refreshList();
                        }
                    });
                }
            });
    },
}


var lrpVendorVoucherDistributionAddEdit = {
    hideModelCallbackData: undefined,
    onchangeCountry: function (e) {
        $("#State").dxSelectBox("instance").getDataSource().filter(["CountryID", "=", e.value]);
        $("#State").dxSelectBox("instance").getDataSource().reload();
    },

    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpVendorVoucherDistributionAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " LRP Vendor Voucher Distribution")
        $model.modal("show");
        var url = "/LRPVendorVoucherDistribution/";
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

    save: function () {
        var validationResult = $("#LRPVendorVoucherDistributionAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/LRPVendorVoucherDistribution/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPVendorVoucherDistributionAddEditDevForm")),
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
                    common.showLoader($("#LRPVendorVoucherDistributionAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPVendorVoucherDistributionAddEditDevForm"));
                    lrpVendorVoucherDistributionList.refreshList();
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
                        url: "/LRPVendorVoucherDistribution/Delete?key=" + e.row.data.ObjectUID,
                        type: "DELETE",
                        dataType: "json",
                        success: function (data) {

                            common.showToast(data);
                        },
                        error: function (xhr, textStatus, errorThrown) {
                            common.showErrorToast();
                        },
                        beforeSend: function () {
                        },
                        complete: function () {
                            lrpVendorVoucherList.refreshList();
                        }
                    });
                }
            });
    },
}