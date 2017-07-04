function getData(data) {
    data.text = textInput.value;
    data.letter = letterInput.value;
    data.stringToAdd = stringInput.value;
}
function clear() {
    var myNode = document.getElementById("body");
    myNode.innerHTML = '';
}

function createTextArea() {
    block.hidden = false;
}

function createNewText(data) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState === XMLHttpRequest.DONE && this.status === 200) {
            var newText = this.responseText;
            resultingText.value = newText;
        }
    };
    xhttp.open("Post", "api/values", true);
    xhttp.setRequestHeader("Content-Type", "application/json");
    xhttp.send(JSON.stringify(data));
}

function doOnClick() {
    getData(data);
    //clear();
    createTextArea();
    createNewText(data);
}

button.onclick = doOnClick;