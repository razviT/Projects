function getData() {
    info.text = $(textInput).val();
    info.letter = $(letterInput).val();
    info.stringToAdd = $(stringInput).val();
}

function createTextArea() {
    $(outputDiv).attr("hidden", false);
}
function createNewText(info) {
    $.ajax({
        url: 'api/values',
        dataType: 'text',
        type: 'POST',
        contentType: 'application/json ; charset=utf - 8',
        data: JSON.stringify(info),
        success: function (data) {
            $(resultingText).val(data);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            $(resultingText).val("erroooooor");
        }
    });
}

$(button).click(function () {
    getData();
    createTextArea();
    createNewText(info);
});