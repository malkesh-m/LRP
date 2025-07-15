
var bdgBudgetList = {
    instance: function () {
        return $("#BdgBudgetList").dxDataGrid("instance");
    },
    refreshList: function () {
        $("#BdgBudgetList").dxDataGrid("instance").refresh();
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
                    let dataGrid = $("#BdgBudgetList").dxDataGrid("instance");
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
                    let dataGrid = $("#BdgBudgetList").dxDataGrid("instance");
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
                icon: "filter",
                onClick: function (e) {
                    bdgBudgetAddEdit.showModel(e, bdgBudgetList.refreshList());
                }
            }
        });
    }
}
let departments;
let year;
var bdgBudgetAddEdit = {
    hideModelCallbackData: undefined,


    showModel: function (e, hideModelCallback) {
        var $model = $("#ModelAddEdit");
        $model.unbind("hidden.bs.modal");
        $model.on("hidden.bs.modal", function (e) {
            if (hideModelCallback) {
                hideModelCallback(bdgBudgetAddEdit.hideModelCallbackData);
                return;
            }
        });
        var $modelBody = $model.find(".modal-body");
        $modelBody.html("");
        $('.modal-title').text((e.row ? "Edit" : "Add") + " BdgBudget")
        $model.modal("show");
        var url = "/BdgBudget/";
        if (e.row)
            url += "Edit/" + e.row.data.ObjectUID.toUpperCase();
        else
            url += "SelectYearDepartment";
        $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });
    },

    save: function () {

        var validationResult = $("#BdgBudgetAddEditDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            $.ajax({
                url: "/BdgBudget/AddEdit",
                type: "POST",
                dataType: "json",
                data: common.dxFormData($("#BdgBudgetAddEditDevForm")),
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
                    common.showLoader($("#BdgBudgetAddEditDevForm"));
                },
                complete: function () {
                    common.hideLoader($("#BdgBudgetAddEditDevForm"));
                    bdgBudgetList.refreshList();
                }
            });
        }
    },
    saveAddBudget: function (e, hideModelCallback) {

        var validationResult = $("#BdgBudgetSelectYearDepartmentDevForm").dxForm("instance").validate();
        if (validationResult.isValid) {
            departments = $("#selectDepartment").dxTagBox("instance").option("value");
            year = $("#selectYear").dxSelectBox("instance").option("value");
            var $model = $("#ModelAddEdit");
            $model.unbind("hidden.bs.modal");
            $model.on("hidden.bs.modal", function (e) {
                if (hideModelCallback) {
                    hideModelCallback(bdgBudgetAddEdit.hideModelCallbackData);
                    return;
                }
            });
            var $modelBody = $model.find(".modal-body");
            $modelBody.html("");
            $('.modal-title').text("Add BdgBudget")
            $model.modal("show");
            var url = "/BdgBudget/Add";
               
            $modelBody.load(url, function () { })
            .ajaxStart(function () {
                common.showLoader($modelBody);
            })
            .ajaxStop(function () {
                common.hideLoader($modelBody);
            });

        }
    },
    parameter: function (e) {
        let param;
     
        let params = [{
            itemType: "group",
            itemOption:"LableGroup",
            colCount: 6,

            name: "Parameters",
            items: [{
                dataField: "Department",
            }, 
            {
                dataField: "AccountName",
            },
            {
                dataField: "AccountCode",
            },
            {
                dataField: "YTDActualAmount",
            },
            {
                dataField: "YTDProjectedAmount",
            },
            {
                dataField: "PyBudgetAmount",
            }
            ]
        }];
        var sourceData = bdgBudgetAddEdit.getLookup();

        for (var i = 0; i < departments.length; i++) {

            param = {
                itemType: "group",
                colCount: 6,

                name: "Parameters",
                items: [{
                    dataField: "BdgdepartmentId"+[i],
                        editorType: "dxSelectBox",
                        editorOptions: {
                            dataSource: sourceData,
                            displayExpr: "Text",
                            valueExpr: "Value",
                            value: departments[i],
                           
                        }
                    }, {
                    dataField: "YearSetupId" + [i],
                    editorType: "dxTextBox",
                    value: year[i],
                        visible: false
                    },
                    {
                        dataField: "AccountName",
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "AccountCode" + [i],
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "YtdactualAmount" + [i],
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "YtdprojectedAmount" + [i],
                        editorType: "dxTextBox"
                    },
                    {
                        dataField: "PybudgetAmount" + [i],
                        editorType: "dxTextBox"
                    }
                ]
            }
            params.push(param);
        }
        var form = $("#BdgDepartmentForm").dxForm({
            items: [
                {
                    itemType: "group",
                    items: [
                        {
                            itemType: "group",
                            items: params
                        }
                    ]
                },
            ]
        }).dxForm("instance");

        $(".dx-field-item-label-text").text("");
     
    },
    getLookup: function (e) {

        var resp;
        var url = "/BdgDepartment/JsonLookup?";
        jQuery.ajax({
            type: 'GET',
            url: url,
            dataType: "json",
            async: false,
            success: function (data) {
                resp = data;
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
            }
        });
        return resp;
    },
    getGridData: function () {

        var resp;
        things = [];
        for (var i = 0; i < departments.length; i++) {
            things.push(departments[i]);
        }
        jQuery.ajax({
            type: 'POST',
            url: "/BdgBudget/GetGridData",
            dataType: "json",
            data: { 'year': year, 'departments': things },
            async: false,
            success: function (data) {
               
                resp = data;
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
            }
        });
        $("#BdgBudgetAddEditList").dxDataGrid("instance").option("dataSource", resp);
        return resp;
    },
    loadGridData: function () {
        var resp;
        jQuery.ajax({
            type: 'GET',
            url: "/BdgBudget/GridList",
            dataType: "json",
            success: function (data) {
                resp = data;
                $("#BdgBudgetList").dxDataGrid("instance").option("dataSource", data);
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
            }
        });
        
    },
    refreshList: function () {
        $("#BdgBudgetAddEditList").dxDataGrid("instance").refresh();
    },
    saveBudget: function () {
       
        $("#BdgBudgetAddEditList").dxDataGrid("saveEditData");
        var paramams = [];


        var dataParam;
        $("#BdgBudgetAddEditList").dxDataGrid("instance").getDataSource().store().load().done(function (data) {
            dataParam = data;
        });
        var filterGrid = $("#BdgBudgetList").dxDataGrid("instance");
        var filterParam = [];
        var accountName ;
        var accountCode;
        var bdgDepartment;
        var yearSetupId;
        var ytdactualAmount ;
        var ytdprojectedAmount ;
        var pybudgetAmount ;
        for (var i = 0; i < dataParam.length; i++) {
            if(i != 0)
                filterParam.push("or");

                accountName = dataParam[i].AccountName === null ? "" : ["AccountName","=", dataParam[i].AccountName];
                accountCode = dataParam[i].AccountCode === null ? "" : ["AccountCode", "=",dataParam[i].AccountCode];
                bdgDepartment = dataParam[i].BdgdepartmentId === null ? "" : ["BdgdepartmentId", "=", dataParam[i].BdgdepartmentId];
                yearSetupId = dataParam[i].YearSetupId === null ? "" : ["YearSetupId", "=",dataParam[i].YearSetupId];
                ytdactualAmount = dataParam[i].YtdactualAmount === null ? "" : ["YtdactualAmount", "=",dataParam[i].YtdactualAmount];
                ytdprojectedAmount = dataParam[i].YtdprojectedAmount === null ? "" : ["YtdprojectedAmount", "=",dataParam[i].YtdprojectedAmount];
                pybudgetAmount = dataParam[i].PybudgetAmount === null ? "" : ["PybudgetAmount", "=",dataParam[i].PybudgetAmount];
           
            var filterData;
            filterData = [bdgDepartment, "and", accountName, "and", accountCode, "and", yearSetupId, "and", ytdactualAmount, "and", ytdprojectedAmount, "and", pybudgetAmount];

            filterParam.push(filterData);

        }
        filterGrid.filter(filterParam);
        $("#ModelAddEdit").modal("hide");

    },
}
$(function () {
    $("#BdgBudgetList > div > div.dx-datagrid-header-panel > div > div > div.dx-toolbar-after > div:nth-child(2) > div > div").attr("id", "Delete");
    common.getlastLayout("bdgBudgetList");
    
})
