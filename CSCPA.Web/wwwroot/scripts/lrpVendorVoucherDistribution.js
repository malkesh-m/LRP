var lrpVendorVoucherDistributionList = {
    instance: function () {
        return $("#LRPVendorVoucherDistributionList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPVendorVoucherDistributionList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#LRPVendorVoucherDistributionList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPVendorVoucherDistributionList").dxDataGrid("instance");
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
                    lrpVendorVoucherDistributionAddEdit.showModel(e, lrpVendorVoucherDistributionList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpVendorVoucherDistributionList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#LRPVendorVoucherDistributionList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("VendorVoucherDistributionList");
})

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
    }
}