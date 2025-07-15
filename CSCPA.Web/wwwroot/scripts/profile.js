function addList() {
    var select = document.getElementById("year");
    for (var i = 2011; i >= 1900; --i) {
        var option = document.createElement('option');
        option.text = option.value = i;
        select.add(option, 0);
    }
}

var profileList = {
    onchangeCountry: function (e) {
        $("#State").dxSelectBox("instance").getDataSource().filter(["CountryID", "=", $("#Country").dxSelectBox('instance').option('value')]);
        $("#State").dxSelectBox("instance").getDataSource().reload();
        profileList.setCountry();
    },
    setCountry: function (e) {
        $("#hiddenCountry").val($("#Country").dxSelectBox('instance').option('value'));
        $("#hiddenState").val($("#State").dxSelectBox('instance').option('value'));
    },
}
$("#submitPassword").click(function () {
    var password = $("#Password").val();
    var confirmPassword = $("#ConfirmPassword").val();
    if (password == confirmPassword) {
        $("#confirmError").text("");
        var parameter = "id=" + $("#ObjectUID").val() + "&password=" + password;
        $.ajax({
            url: "/Profile/ChangePassword?" + parameter,
            type: "POST",
            dataType: "json",
            success: function (data) {

                common.showToast(data);
            },
            error: function (xhr, textStatus, errorThrown) {
                common.showErrorToast();
            },
            beforeSend: function () {
                common.showLoader($("#ChangePassword"));
            },
            complete: function () {
                common.hideLoader($("#ChangePassword"));
            }
        });
    }
    else {
        $("#confirmError").text("Password and Confirm password shoud be same.");
    }
    
});
