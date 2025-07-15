var lrpVendorList = {
    instance: function () {
        return $("#LRPVendorList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPVendorList").dxDataGrid("instance").refresh();
    },
    onSectionChnage: function (data) {
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
                    let dataGrid = $("#LRPVendorList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPVendorList").dxDataGrid("instance");
                    $.when(dataGrid.getDataSource().store().remove(e.row.data.ObjectUID)).done(function () {
                        dataGrid.refresh();
                    });
                }
            });
    },

    onEditorPreparing: function (e) {
        if (e.parentType === "dataRow" && e.dataField === "CountryStateId") {
            e.editorOptions.disabled = (typeof e.row.data.CountryId !== "number");
        }
    },
    getCountryStates: function (options) {
        $.ajax({
            url: "/CountryState/Lookup",
            type: "GET",
            data: { filter: options.data ? "['CountryId', '=', '" + options.data.CountryId + "']" : null },
            success: function (data) {
                return {
                    store: DevExpress.data.AspNet.createStore({
                        type: "array",
                        loadMode: "raw",
                        load: function () {
                            return data.data
                        }
                    }),
                }
            },
        });


    },
    setCountryValue: function (rowData, value) {
        rowData.CountryId = value;
        rowData.CountryStateId = null;

    },

    toolbar_preparing: function (e) {
        var dataGrid = e.component;

        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "plus",
                onClick: function (e) {
                    lrpVendorAddEdit.showModel(e, lrpVendorList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpVendorList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#LRPVendorList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("VendorList");
})

var lrpVendorAddEdit = {
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
                hideModelCallback(lrpVendorAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " Vendor")
        $model.modal("show");
        var url = "/LRPVendor/";
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
        var validationResult = $("#LRPVendorAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/LRPVendor/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPVendorAddEditDevForm")),
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
                    common.showLoader($("#LRPVendorAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPVendorAddEditDevForm"));
                    lrpVendorList.refreshList();
                }
            });
        }
    }
}

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
                    lrpVendorList.refreshList();
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
                        url: "/LRPVendorVoucher/Delete?key=" + e.row.data.ObjectUID,
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
                            lrpVendorList.refreshList();
                        }
                    });
                }
            });
    },
}