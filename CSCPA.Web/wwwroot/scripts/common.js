var common = {
    currrentTemplateId: "",
    showLoader: function showLoader($obj) {
        $obj.LoadingOverlay("show", {
            color: "rgba(0, 0, 0, 0.4)"
        });
    },

    hideLoader: function ($obj) {
        $obj.LoadingOverlay("hide", true);
    },

    showToast: function (alert) {
        if (!alert.Title) {
            swal({
                position: 'top',
                type: alert.Status.toLowerCase(),
                title: alert.Message,
                showConfirmButton: true,
                toast: true
            });
        } else {
            swal({
                position: 'top',
                type: alert.Status.toLowerCase(),
                title: alert.Title,
                text: alert.Message,
                showConfirmButton: true,
                toast: true
            });
        }
    },

    showGridLayoutModel: function (gridId,moduleName) {
        $('.modal-title').text("Add Layout");
        $('#txtGridId').dxTextBox("instance").option('value', moduleName);
        $('#gridId').dxTextBox("instance").option('value', gridId);
        $('#GridLayoutAddEdit').modal("show");
        $('#txtLayoutname').dxTextBox("instance").reset();
    },

    createLayout: function () {
        const viewgridId = $('#gridId').dxTextBox("instance").option('value');
        const layout = $("#" + viewgridId).dxDataGrid("instance").state();
        const gridId = $('#txtGridId').dxTextBox("instance").option('value');
        const layoutName = $('#txtLayoutname').dxTextBox("instance").option('value');
        const isPublic = $('#checkPublic').dxCheckBox("instance").option('value');
        $.ajax({
            url: "/GridLayout/Add",
            type: "POST",
            data: {
                layoutName: layoutName,
                gridId: gridId,
                Layout: JSON.stringify(layout),
                isPublic: isPublic
            },
            dataType: "json",
            success: function (data) {
                common.showToast(data);
                $('#GridLayoutAddEdit').modal("hide");
                $("#Layouts").dxSelectBox("getDataSource").reload();
            },
            error: function (xhr, textStatus, errorThrown) {
                common.showErrorToast();
            }
        });
    },

    addLayout: function (layoutDropdownId, gridId, moduleName) {
        let templateId = $('#' + layoutDropdownId).dxSelectBox("instance").option('value');
        common.showGridLayoutModel(gridId, moduleName);
    },

    deleteLayout: function (layoutDropdownId, gridId) {
        let templateId = $('#' + layoutDropdownId).dxSelectBox("instance").option('value');
        if (!templateId) {
            swal('Please select layout to delete!', '', 'info');
        } else {
            $.ajax({
                url: "/GridLayout/Delete",
                type: "Delete",
                data: { key: templateId },
                success: function (data) {
                    common.showToast(data);
                    debugger;
                    common.getlastLayout(gridId);
                },
                error: function (xhr, textStatus, errorThrown) {
                    common.showErrorToast();
                },
                beforeSend: function () {
                    common.showLoader($("#DeleteState"));
                },
                complete: function () {
                    common.hideLoader($("#DeleteState"));
                }
            });
        }
    },

    getlastLayout: function (moduleName) {
        $.ajax({
            url: "/GridLayout/LastLayout",
            type: "GET",
            data: { gridId: moduleName },
            success: function (data) {
                $("#Layouts").dxSelectBox("getDataSource").reload();
                $("#Layouts").dxSelectBox("instance").option("value", data);
            }
        });
    },

    updateLayout: function (layoutDropdownId, gridId, moduleName) {
        let templateId = $('#' + layoutDropdownId).dxSelectBox("instance").option('value');
        if (!templateId) {
            swal('Please select layout to update!','','info');
            //common.showGridLayoutModel(gridId,moduleName);
        }
        else {
            const state = $("#" +gridId).dxDataGrid("instance").state();
            $.ajax({
                url: "/GridLayout/Edit",
                type: "POST",
                data: {
                    id: currrentTemplateId,
                    Layout: JSON.stringify(state),
                },
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

    loadTemplate: function (e, gridId) {
        currrentTemplateId = e.value;
        if (e.value != null) {
            $.ajax({
                url: "/GridLayout/GetById",
                type: "GET",
                data: { layoutId: e.value },
                success: function (data) {
                    $("#" + gridId).dxDataGrid("instance").state(JSON.parse(data.Layout));
                },
                error: function (xhr, textStatus, errorThrown) {

                    //common.showErrorToast();
                    //alert('Request Status: ' + xhr.status + '; Status Text: ' + textStatus + '; Error: ' + errorThrown);
                },
                beforeSend: function () {
                    //common.showLoader($("#LRPCompanyAddEditDevForm"));
                },
                complete: function () {
                    //common.hideLoader($("#LRPCompanyAddEditDevForm"));
                }
            });
        }
    },
    exporting: function (e) {
        /*        var dataGrid = e.component,
                        visibleRows = dataGrid.getVisibleColumns();
                    var columnNames = [];
                    for (var i = 1; i < visibleRows.length; i++) {
                        columnNames.push(visibleRows[i].dataField);
                    }
                    //columnNames = JSON.stringify({ 'columnName': columnNames });
                    //alert(columnNames);
                    //var fields = visibleRows[2].dataField;
                    debugger;
                    $.ajax({
                        url: "/LRPCompany/GetExcel",
                        type: "POST",
                        data: { columnName: columnNames },
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
                            common.showLoader($("#LRPCompanyAddEditDevForm"));
                        },
                        complete: function () {
                            common.hideLoader($("#LRPCompanyAddEditDevForm"));
                            lrpCompanyList.refreshList();
                        }
                    });*/
        var workbook = new ExcelJS.Workbook();
        var worksheet = workbook.addWorksheet('ExcelData');

        DevExpress.excelExporter.exportDataGrid({
            component: e.component,
            worksheet: worksheet,
            autoFilterEnabled: true
        }).then(function () {
            workbook.xlsx.writeBuffer().then(function (buffer) {
                saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'ExcelData.xlsx');
            });
        });
        e.cancel = true;
    },

    showToastLongTime: function (alert) {

        if (!alert.Title) {
            window.swal({
                position: 'top-middle',
                type: alert.Status.toLowerCase(),
                title: alert.Message,
                showConfirmButton: false,
                timer: 20000,
                toast: true
            });
        } else {
            window.swal({
                position: 'top-middle',
                type: alert.Status.toLowerCase(),
                title: alert.Title,
                text: alert.Message,
                showConfirmButton: false,
                timer: 20000,
                toast: true
            });
        }
    },

    showErrorToast: function () {
        var errorToast = {
            ToastType: 'error',
            Message: "Error occurred.",
            title: '',
        };
        swal({
            position: 'top',
            type: errorToast.ToastType,
            title: errorToast.title,
            text: errorToast.Message,
            showConfirmButton: true,
            toast: true
        });
    },

    showErrorToastWithButton: function (title, msg) {
        sweetToast(
            title,
            msg,
            'error'
        )
    },

    showSuccessToast: function () {
        var successToast = {
            ToastType: 'Success',
            Message: "Operation completed successfully."
        };
        showToast(successToast);
    },

    convertToEmpty: function (value) {
        if (value === undefined || value === null || value === "null")
            return '';
        else
            return value;
    },

    convertUTCToLocalDateTime: function (utcDt, utcDtFormat) {
        var toDt = moment.utc(utcDt, utcDtFormat).toDate();
        return moment(toDt).format('YYYY-MM-DD hh:mm:ss A');
    },

    convertUTCToLocalTime: function (utcDt, utcDtFormat) {
        if (utcDt && utcDt != "0001-01-01 00:00:00" && utcDt != null) {
            var toDt = moment.utc(utcDt, utcDtFormat).toDate();
            return moment(toDt).format('hh:mm');
        } else {
            return "00:00:00"
        }
    },

    getCurrentTimeZone: function () {
        return Intl.DateTimeFormat().resolvedOptions().timeZone;
    },

    updateQueryStringParameter: function (uri, key, value) {
        var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
        var separator = uri.indexOf('?') !== -1 ? "&" : "?";
        if (uri.match(re)) {
            return uri.replace(re, '$1' + key + "=" + value + '$2');
        } else {
            return uri + separator + key + "=" + value;
        }
    },

    getUrlParam: function (key) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(key);
    },

    dxFormData: function ($form) {
        var values = $form.dxForm('instance').option('formData');
        var token = $('input[name="__RequestVerificationToken"]').val();
        values["__RequestVerificationToken"] = token;
        return values;
    },

    convertDateToDbFormat: function (value) {
        if (value) {
            var newdate = new Date(value);
            return newdate.getFullYear() + "-" + (newdate.getMonth() + 1) + "-" + newdate.getDate() + " " + newdate.getHours() + ":" + newdate.getMinutes() + ":" + newdate.getSeconds();
        }
        else
            return value;
    }
}
