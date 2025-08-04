var lrpUserAccountList = {
    instance: function () {
        return $("#LRPUserAccountList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#LRPUserAccountList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#LRPUserAccountList").dxDataGrid("instance");
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
                    let dataGrid = $("#LRPUserAccountList").dxDataGrid("instance");
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
                    lrpUserAccountAddEdit.showModel(e, lrpUserAccountList.refreshList());
                }
            }
        }, {
            location: "after",
            widget: "dxButton",
            options: {
                icon: "trash",
                disabled: true,
                onClick: function (e) {
                    lrpUserAccountList.onDeleteBtnClick();
                }
            }
        });
    },
    onTabChanged: function (e) {
        var selectedIndex = e.component.option("selectedIndex");
        var userId = e.component.option("items")[selectedIndex].tabExtras.ObjectUID;

        console.log("Tab changed. Index:", selectedIndex, "UserId:", userId);

        if (selectedIndex === 0) {
            var deptElement = $("#tab-bdgDept-container-" + userId);
            if (deptElement.length && $.trim(deptElement.html()) === "") {
                console.log("Loading Department Grid...");
                deptElement.load('/UserAccount/DepartmentGridByUserAccountId?userAccountId=' + userId, function (response, status, xhr) {
                    console.log("Dept Tab Load Status:", status);
                    if (status === "error") {
                        console.error("Error loading Department tab:", xhr.status, xhr.statusText);
                    }
                });
            }
        }
        else if (selectedIndex === 1) {
            var lrpCompanyElement = $("#tab-lrpCompany-container-" + userId);
            if (lrpCompanyElement.length && $.trim(lrpCompanyElement.html()) === "") {
                console.log("Loading LRP Company Grid...");
                lrpCompanyElement.load('/UserAccount/LRPCompanyGridByUserAccountId?userAccountId=' + userId, function (response, status, xhr) {
                    console.log("LRP Company Tab Load Status:", status);
                    if (status === "error") {
                        console.error("Error loading LRP Company tab:", xhr.status, xhr.statusText);
                    }
                });
            }
        }
        else if (selectedIndex === 2) {
            var roleElement = $("#tab-role-container-" + userId);
            if (roleElement.length && $.trim(roleElement.html()) === "") {
                console.log("Loading Role Grid...");
                roleElement.load('/UserAccount/RoleGridByUserAccountId?userAccountId=' + userId, function (response, status, xhr) {
                    console.log("Role Tab Load Status:", status);
                    if (status === "error") {
                        console.error("Error loading Role tab:", xhr.status, xhr.statusText);
                    }
                });
            }
        }
    },

    onDetailExpanded: function (e) {
        var userId = e.key;
        console.log("Detail expanded for UserId:", userId);

        var deptElement = $("#tab-bdgDept-container-" + userId);
        if (deptElement.length && $.trim(deptElement.html()) === "") {
            deptElement.load('/UserAccount/DepartmentGridByUserAccountId?userAccountId=' + userId, function (response, status, xhr) {
                console.log("Default Department Tab Load Status:", status);
                if (status === "error") {
                    console.error("Error loading default Department tab:", xhr.status, xhr.statusText);
                }
            });
        }
    }
}
$(function () {
    $("#LRPUserAccountList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("UserAccountList");
})

var lrpUserAccountAddEdit = {
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
                hideModelCallback(lrpUserAccountAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " User Account")
        $model.modal("show");
        var url = "/UserAccount/";
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
        var validationResult = $("#LRPUserAccountAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/UserAccount/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#LRPUserAccountAddEditDevForm")),
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
                    common.showLoader($("#LRPUserAccountAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#LRPUserAccountAddEditDevForm"));
                    lrpUserAccountList.refreshList();
                }
            });
        }
    }
}