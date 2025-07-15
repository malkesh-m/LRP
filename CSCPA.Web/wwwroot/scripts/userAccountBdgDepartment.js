var userAccountBdgDepartmentList = {
    instance: function () {
        return $("#UserAccountBdgDepartmentList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#UserAccountBdgDepartmentList").dxDataGrid("instance").refresh();
    },
    onSectionChange: function (data) {
        debugger;
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
                    let dataGrid = $("#UserAccountBdgDepartmentList").dxDataGrid("instance");
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
                    let dataGrid = $("#UserAccountBdgDepartmentList").dxDataGrid("instance");
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
                    userAccountBdgDepartmentAddEdit.showModel(e, userAccountBdgDepartmentList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    userAccountBdgDepartmentList.onDeleteBtnClick();
                }
            }
        });
    }
}
$(function () {
    $("#UserAccountBdgDepartmentList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("UserAccountBDGDepartmentList");
})

var userAccountBdgDepartmentAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(userAccountBdgDepartmentAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " User Account Bdg Department")
        $model.modal("show");
        var url = "/UserAccountBdgDepartment/";
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
        var validationResult = $("#UserAccountBdgDepartmentAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/UserAccountBdgDepartment/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#UserAccountBdgDepartmentAddEditDevForm")),
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
                    common.showLoader($("#UserAccountBdgDepartmentAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#UserAccountBdgDepartmentAddEditDevForm"));
                    userAccountBdgDepartmentList.refreshList();
                }
            });
        }
    },
    onchangeisLrpDepartment: function (e) {
        debugger
        if (e.value) {
            $("#UserAccountBdgDepartmentAddEditDevForm > div > div > div > div:nth-child(1) > div > div").hide();
            $("#UserAccountBdgDepartmentAddEditDevForm > div > div > div > div:nth-child(3) > div > div").show();
        }
        else {
            $("#UserAccountBdgDepartmentAddEditDevForm > div > div > div > div:nth-child(3) > div > div").hide();
            $("#UserAccountBdgDepartmentAddEditDevForm > div > div > div > div:nth-child(1) > div > div").show();
        }
    }
}
