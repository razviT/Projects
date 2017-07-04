var inputParagraph = document.createElement("p");
inputParagraph.style.fontSize = "25px";
var text = document.createTextNode(" Input text: ");
var textInput = document.createElement("textarea");
textInput.id = "textInputId";
textInput.value = "";
inputParagraph.appendChild(text);
inputParagraph.appendChild(textInput);