var Example;
(function (Example) {
    class Prompt {
        showAlert(message) {
            return prompt(message, "Hey");
        }
    }
    Example.Prompt = Prompt;
})(Example || (Example = {}));
export function getPromptInstance() {
    return new Example.Prompt();
}
//# sourceMappingURL=Example.js.map