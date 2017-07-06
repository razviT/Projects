var letterAndStringDiv = $("<div>", { id: "letterInputDivId", class: "lettersAndStringStyle" });
var letterInput = $("<input>", { id: "letterInputId" });
$(letterInput).css("marginLeft", "3px");
var textNodeTwo = $(document.createTextNode("Input letter :"));
$(letterAndStringDiv).append(textNodeTwo);
$(letterAndStringDiv).append(letterInput);