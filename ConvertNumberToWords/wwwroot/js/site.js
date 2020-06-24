// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Convert() {
    var numberValue = $("#numberToConvert").val();
    $.ajax({
        type: "POST",
        url: "/Home/ConvertToWords/1234",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(numberValue),
        success: function (data) {
           
            $("#msg").text(data);
        },
        error: function (data, status, error) {
            alert('failed');
        }
    })
}