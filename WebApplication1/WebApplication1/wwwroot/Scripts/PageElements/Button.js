var buttonDiv = $("<div>", { id: "buttonDivId" });
var button = $("<button>", { id: "buttonId", class: "buttonStyle" });
$(button).css("marginLeft", "185px");
var buttonText = $(document.createTextNode("Replace letter"));
$(button).append(buttonText);
$(buttonDiv).append(button);