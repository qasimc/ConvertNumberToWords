function Convert() {
    var numberValue = $("#numberToConvert").val();
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
        }
    })
}