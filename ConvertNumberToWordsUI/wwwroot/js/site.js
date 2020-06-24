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
        },
        error: function (data, status, error) {
            debugger;
            $("#msg").text(data.responseText);
        },
        complete: function (data) {
            $("#convert").text("Convert and save to database");
            $("#convert").removeAttr('disabled');
        }
    })
}