var buttonParagraph = document.createElement("p");
buttonParagraph.style.fontSize = "25px";
var button = document.createElement("button");
var buttonText = document.createTextNode("Replace letter");
button.id = "buttonId";
button.style.fontFamily = "cursive";
button.appendChild(buttonText);
buttonParagraph.appendChild(button);