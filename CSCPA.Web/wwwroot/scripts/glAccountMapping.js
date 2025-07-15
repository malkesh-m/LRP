var glAccountMappingList = {
    instance: function () {
        return $("#GLAccountMappingList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#GLAccountMappingList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#GLAccountMappingList").dxDataGrid("instance");
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
                debugger;
                if (isConfirm) {
                    let dataGrid = $("#GLAccountMappingList").dxDataGrid("instance");
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
                    glAccountMappingAddEdit.showModel(e, glAccountMappingList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    glAccountMappingList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#GLAccountMappingList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("CodeList");

})
var glAccountMappingAddEdit = {
    hideModelCallbackData: undefined,

    onchangeAccountGroup: function (e) {
        $("#BdgaccountGroupSubGroup").dxSelectBox("instance").getDataSource().filter(["FilterValue", "=", e.value]);
        /*setTimeout(function () {
           // var ID = $('#AccountDefinitionForm').dxForm('instance').option('formData').CommodityTypeID;
            var editor = $("#BdgaccountGroupSubGroup").dxSelectBox("instance");
            if (editor) {
                var dataSource = editor.getDataSource();
                dataSource.filter(["BdgaccountGroupId", "=", e.value]);
                dataSource.load();
            }
        }, 0);*/
        $("#BdgaccountGroupSubGroup").dxSelectBox("instance").getDataSource().reload();
    },
    onchangeSubGroup: function (e) {
        $("#BdgaccountGroupSubGroupSubGroup").dxSelectBox("instance").getDataSource().filter(["FilterValue", "=", e.value]);
 /*       debugger;
           // var ID = $('#AccountDefinitionForm').dxForm('instance').option('formData').CommodityTypeID;
        var editor = $("#BdgaccountGroupSubGroupSubGroup").dxSelectBox("instance");
            if (editor) {
                var dataSource = editor.getDataSource();
                dataSource.filter(["FilterValue", "=", e.value]);
                dataSource.load();
            }*/
        $("#BdgaccountGroupSubGroupSubGroup").dxSelectBox("instance").getDataSource().reload();
    },
    onchangeSubSubGroup: function (e) {
        $("#BdgaccountGroupSubGroupSubGroupSubGroup").dxSelectBox("instance").getDataSource().filter(["FilterValue", "=", e.value]);
        $("#BdgaccountGroupSubGroupSubGroupSubGroup").dxSelectBox("instance").getDataSource().reload();
    },
    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(glAccountMappingAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " GL Account Mapping")
        $model.modal("show");
        var url = "/GLAccountMapping/";
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

        var validationResult = $("#GLAccountMappingAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/GLAccountMapping/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#GLAccountMappingAddEditDevForm")),
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
                    common.showLoader($("#GLAccountMappingAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#GLAccountMappingAddEditDevForm"));
                    glAccountMappingList.refreshList();
                }
            });
        }
    }
}