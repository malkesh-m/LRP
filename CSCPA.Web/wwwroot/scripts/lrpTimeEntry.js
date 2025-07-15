var lrpTimeEntryList = {
    instance: function () {
        return $("#LRPTimeEntryList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPTimeEntryList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#LRPTimeEntryList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPTimeEntryList").dxDataGrid("instance");
                    $.when(dataGrid.getDataSource().store().remove(e.row.data.ObjectUid)).done(function () {
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
                    lrpTimeEntryAddEdit.showModel(e, lrpTimeEntryList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpTimeEntryList.onDeleteBtnClick();
                }
            }
        });
    }
}

var lrpTimeEntryAddEdit = {
    hideModelCallbackData: undefined,

    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(lrpTimeEntryAddEdit.hideModelCallbackData);
                return;
            }
        });

        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " TimeEntry")
        $model.modal("show");
        var url = "/LRPTimeEntry/";
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
        var validationResult = $("#LRPTimeEntryAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            var data = common.dxFormData($("#LRPTimeEntryAddEditDevForm"));
            data['LrpDateStart'] = common.convertDateToDbFormat(data['LrpDateStart']);
            data['LrpDateEnd'] = common.convertDateToDbFormat(data['LrpDateEnd']);

            $.ajax({
                url: "/LRPTimeEntry/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPTimeEntryAddEditDevForm")),
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
                    common.showLoader($("#LRPTimeEntryAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPTimeEntryAddEditDevForm"));
                    lrpTimeEntryList.refreshList();
                }
            });
        }
    }
}
$(function () {
    $("#LRPTimeEntryList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("TimeEntryList");
})
