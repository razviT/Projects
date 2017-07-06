var inputDiv = $("<div>", { id: "inputDivId", class: "inputStyle" });
var textDiv = $("<div>", { id: "TextDivId", class: "textStyle" });
var textNode = $(document.createTextNode("Input text :"));
var textInput = $("<textarea>", {
    id: "textInputId", height: "14px", width: "800px"
});
$(textInput).css("background", "#EDFFDD");
$(textDiv).append(textNode);
$(textDiv).append(textInput);