function Convert() {
    var numberValue = $("#numberToConvert").val();
    $("#convert").attr('disabled', 'disabled');
    $("#convert").text("Converting...");
    $.ajax({
        type: "POST",
        url: "/Home/ConvertToWords",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(numberValue),
        success: function (data) {
            $("#msg").text(data);
            ShowSuccess("Successfully converted and saved to database");
        },
        error: function (data, status, error) {
            $("#msg").text(data.responseText);
            ShowError(data.responseText);
        },
        complete: function (data) {
            $("#convert").text("Convert and save to database");
            $("#convert").removeAttr('disabled');
        }
    })
}
function ShowSuccess(message) {
    $("#notification").text(message);
    $("#notification").addClass("show");
    setTimeout(function () { $("#notification").removeClass("show") }, 3000);
}

function ShowError(message) {
    $("#notification").text(message);
    $("#notification").addClass("showError");
    setTimeout(function () { $("#notification").removeClass("showError") }, 3000);
}