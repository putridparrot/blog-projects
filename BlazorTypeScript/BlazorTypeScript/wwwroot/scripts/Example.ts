namespace Example {
    export class Prompt {
        public showAlert(message: string): string {
            return prompt(message, "Hey");
        }
    }
}

export function getPromptInstance(): Example.Prompt {
    return new Example.Prompt();
}
