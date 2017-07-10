let info = {
    text: "",
    letter: "",
    stringToAdd: ""
};
let generate = () => {
    $.ajax({
        url: 'api/values',
        dataType: 'text',
        type: 'POST',
        contentType: 'application/json ; charset=utf - 8',
        data: JSON.stringify(info),
        success: function (data) {
            ReactDOM.render(
                React.createElement("label", { key: "resultLabel" },
                    [
                        "Resulting text:",
                        React.createElement("textarea",
                            {
                                key: "result",
                                type: "text",
                                value: data
                            })
                    ]),
                document.getElementById("resultDiv")
            );
        },
        error: function (jqXhr, textStatus, errorThrown) {
            result = "error";
        }
    });
}

let Form = props => {
    return React.createElement("div", null,
        [
            React.createElement("label", { key: "inputTextLabel" },
                [
                    "Input Text : ",
                    React.createElement("textarea",
                        {
                            key: "inputText",
                            type: "text",
                            onChange: event => {
                                info.text = event.target.value;
                                render();
                            }
                        })
                ]),
            React.createElement("label", { key: "letterLabel" },
                [
                    "Input letter :",
                    React.createElement("input",
                        {
                            key: "inputLetter",
                            type: "text",
                            onChange: event => {
                                info.letter = event.target.value;
                                render();
                            }
                        })
                ]),
            React.createElement("label", { key: "stringLabel" },
                [
                    "Input string:",
                    React.createElement("input",
                        {
                            key: "inputString",
                            type: "text",
                            onChange: event => {
                                info.stringToAdd = event.target.value;
                                render();
                                generate();
                            }
                        })
                ]),

        ]
    )
}
let render = () =>
    ReactDOM.render(
        React.createElement(Form, { info }, null),
        document.getElementById("root")
    );
render();