var glInquiryList = {
    instance: function () {
        return $("#GLInquiryList").dxDataGrid("instance");
    },
    refreshList: function () {
        var dataGrid = $("#GLInquiryList").dxDataGrid("instance");
        dataGrid.refresh();
        dataGrid.deselectAll();
        dataGrid.clearSelection();
    },
    onSectionChnage: function (data) {
        let deleteButton = $("#Delete").dxButton("instance");
        let massUpdateButton = $("#MassUpdate").dxButton("instance");
        deleteButton.option("disabled", !data.selectedRowsData.length);
        massUpdateButton.option("disabled", !data.selectedRowsData.length);
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
                    let dataGrid = $("#GLInquiryList").dxDataGrid("instance");
                    $.when.apply($, dataGrid.getSelectedRowsData().map(function (data) {
                        return dataGrid.getDataSource().store().remove(data.ObjectUid);
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
                    let dataGrid = $("#GLInquiryList").dxDataGrid("instance");
                    $.when(dataGrid.getDataSource().store().remove(e.row.data.ObjectUid)).done(function () {
                        dataGrid.refresh();
                    });
                }
            });
    },
    onmassUpdateBtnClick: function () {
        let txtCode = $('#txtCode').dxTextBox("instance").option('value')
        let txtEmployee = $('#txtEmployee').dxTextBox("instance").option('value')
        let txtFinalId = $('#txtFinalId').dxTextBox("instance").option('value')
        let txtDescription = $('#txtDescription').dxTextBox("instance").option('value')
        let txtCheckNo = $('#txtCheckNo').dxTextBox("instance").option('value')
        let txtSalesTaxAmount = $('#txtSalesTaxAmount').dxTextBox("instance").option('value')
        let txtSalesTaxRate = $('#txtSalesTaxRate').dxTextBox("instance").option('value')
        var datas = {};

        if (txtCode !== "") {
            datas["Lm2Code"] = txtCode;
        }
        if (txtEmployee !== "") {
            datas["EmployeeCode"] = txtEmployee;
        }
        if (txtFinalId !== "") {
            datas["FinalId"] = txtFinalId;
        }
        if (txtDescription !== "") {
            datas["Description"] = txtDescription;
        }
        if (txtCheckNo !== "") {
            datas["CheckNo"] = txtCheckNo;
        }
        if (txtSalesTaxAmount !== "") {
            datas["SalesTaxAmount"] = txtSalesTaxAmount;
        }
        if (txtSalesTaxRate !== "") {
            datas["SalesTaxRate"] = txtSalesTaxRate;
        }
        let dataGrid = $("#GLInquiryList").dxDataGrid("instance");
        $.when.apply($, dataGrid.getSelectedRowsData().map(function (data) {
            return dataGrid.getDataSource().store().update(data.ObjectUid, datas);
        })).done(function () {
            dataGrid.deselectAll();
            dataGrid.refresh();
        });
    },
    loadTemplate: function (e) {
        $.ajax({
            url: "/Home/GetGridState",
            type: "GET",
            dataType: "json",
            dataType: "json",
            success: function (data) {
                $("#GLInquiryList").dxDataGrid("instance").state(JSON.parse(data.Data));
            },
            error: function (xhr, textStatus, errorThrown) {
                common.showErrorToast();
            },
            beforeSend: function () {
            },
            complete: function () {
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
    saveState: function () {
        if ($('#Layouts').text() === "Add New") {
            common.showGridLayoutModel();
        }
        else {
            const state = $("#GLInquiryList").dxDataGrid("instance").state();
            $.ajax({
                url: "/Home/SaveGridState",
                type: "POST",
                dataType: "json",
                data: { jsonInput: JSON.stringify(state) },
                dataType: "json",
                success: function (data) {
                    common.showToast(data);

                },
                error: function (xhr, textStatus, errorThrown) {
                    common.showErrorToast();
                },
                beforeSend: function () {
                    common.showLoader($("#SaveState"));
                },
                complete: function () {
                    common.hideLoader($("#SaveState"));
                }
            });
        }
    },
    toolbar_preparing: function (e) {
        var dataGrid = e.component;

        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "plus",
                disabled: true,
                onClick: function (e) {
                    glInquiryAddEdit.showModel(e, glInquiryList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    glInquiryList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#GLInquiryList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    $("#GLInquiryList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(1)").hide();
    common.getlastLayout("glInquiryList");
})
var glInquiryAddEdit = {
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
                hideModelCallback(glInquiryAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " GL Transaction")
        $model.modal("show");
        var url = "/BdgLRPGL/";
        if (e.row)
            url += "Edit/" + e.row.data.ObjectUid.toUpperCase();
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

        var validationResult = $("#LRPGLInquiryAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/BdgLRPGL/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPGLInquiryAddEditDevForm")),
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
                    common.showLoader($("#LRPGLInquiryAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPGLInquiryAddEditDevForm"));
                    glInquiryList.refreshList();
                }
            });
        }
    }
}