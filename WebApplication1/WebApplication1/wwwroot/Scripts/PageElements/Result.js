var outputDiv = $("<div>", { id: "outputDivId", class: "outputStyle", hidden: true });
var resultingText = $("<textarea>", { id: "resultingTextId", value: "", height: "14px", width: "790px" });
var writing = $(document.createTextNode("Output text:"));
$(writing).css("color", "red");
$(outputDiv).append(writing);
$(outputDiv).append(resultingText);