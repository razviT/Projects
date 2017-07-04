var inputParagraph = document.createElement("p");
var header = document.createElement("p");
var text = document.createTextNode(" Input text: ");
header.appendChild(text);
var textInput = document.createElement("textarea");
textInput.id = "textInputId";
textInput.value = "";
inputParagraph.appendChild(textInput);