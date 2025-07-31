var lrpVendorReportList = {
    instance: function () {
        return $("#LRPVendorReportList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPVendorReportList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#LRPVendorReportList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPVendorReportList").dxDataGrid("instance");
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

    getCountryStates: function (countryId) {
        return new DevExpress.data.CustomStore({
            loadMode: "raw",
            load: function () {
                return $.ajax({
                    url: "/CountryState/GetLookup",
                    type: "GET",
                    data: { countryId: countryId }
                }).then(function (response) {
                    return response.data; // assumes your response is { data: [...] }
                });
            }
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
                    lrpVendorReportAddEdit.showModel(e, lrpVendorReportList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpVendorReportList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#LRPVendorReportList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("VendorReportList");
})

var lrpVendorReportAddEdit = {
    hideModelCallbackData: undefined,
    onchangeCountry: function (e) {
        var countryId = e.value;
        var stateSelectBox = $("#State").dxSelectBox("instance");

        if (!countryId) {
            // Clear states if no country selected
            stateSelectBox.option({
                dataSource: [],
                value: null
            });
            return;
        }

        // AJAX call to fetch states for selected country
        $.ajax({
            url: "/CountryState/Edit", // ✅ your backend endpoint
            type: "GET",
            data: { id: countryId },
            success: function (response) {
                stateSelectBox.option({
                    dataSource: response.data, // expects array of { ObjectUID, Name }
                    value: null // Clear previously selected state
                });
            },
            error: function () {
                console.error("Failed to load states");
            }
        });
    },
    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpVendorReportAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " LRP Vendor Report")
        $model.modal("show");
        var url = "/LRPVendorReport/";
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
        var validationResult = $("#LRPVendorReportAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/LRPVendorReport/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPVendorReportAddEditDevForm")),
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
                    common.showLoader($("#LRPVendorReportAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPVendorReportAddEditDevForm"));
                    lrpVendorReportList.refreshList();
                }
            });
        }
    }
}